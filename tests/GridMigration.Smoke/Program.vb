Imports System.Data
Imports System.Reflection
Imports System.Windows.Forms
Imports LancioMigration

Module Program
    Private checks As Integer
    <STAThread>
    Sub Main()
        For Each entry In New (String, String, Integer, Boolean)() {
            ("LibMat", "LibMat.frmScheda", 2, True),
            ("LibMat", "LibMat.frmNote", 2, True),
            ("LibMat", "LibMat.frmNonTrovato", 1, True),
            ("LibMat", "LibMat.frmDati", 1, False),
            ("LibMat", "LibMat.frmChart", 2, False),
            ("traccia", "traccia.frmGridn", 1, False),
            ("DataSheet", "DataSheet.frmProto", 1, True)}
            Dim formType = Assembly.Load(entry.Item1).GetType(entry.Item2, throwOnError:=True)
            Dim instance As Object = If(entry.Item4,
                Activator.CreateInstance(formType, BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic, Nothing, New Object() {False}, Nothing),
                Activator.CreateInstance(formType, nonPublic:=True))
            Using form = DirectCast(instance, Form)
                Dim fields = formType.GetFields(BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic).
                    Where(Function(field) GetType(DataGridView).IsAssignableFrom(field.FieldType)).ToArray()
                Check(fields.Length = entry.Item3, entry.Item2 & " grid count")
                For Each field In fields
                    Dim grid = DirectCast(field.GetValue(form), DataGridView)
                    Check(grid IsNot Nothing AndAlso grid.Parent IsNot Nothing, entry.Item2 & " attached grid")
                Next
            End Using
        Next
        Dim boltType = Assembly.Load("Tiranti").GetType("Tiranti.Tir1", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(boltType, BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic, Nothing, New Object() {False}, Nothing), Form)
            Dim toolbar = DirectCast(boltType.GetField("ToolBar2", BindingFlags.Instance Or BindingFlags.NonPublic).GetValue(form), ToolStrip)
            Check(toolbar.Items.Count = 5 AndAlso toolbar.Parent IsNot Nothing, "Tiranti toolbar")
            Check(CStr(toolbar.Items(4).Tag) = "Esci", "Tiranti exit command tag")
        End Using
        Using host As New Form(), grid As New LegacyGridView()
            grid.Dock = DockStyle.Fill
            host.Controls.Add(grid)
            Dim nameColumn As New LegacyTextColumn With {.MappingName = "Name", .HeaderText = "Name"}
            Dim valueColumn As New LegacyTextColumn With {.MappingName = "Value", .Format = "0.00", .Alignment = HorizontalAlignment.Right}
            grid.AutoGenerateColumns = False
            grid.Columns.AddRange(nameColumn, valueColumn)
            Dim data As New DataTable()
            data.Columns.Add("Name", GetType(String))
            data.Columns.Add("Value", GetType(Double))
            data.Rows.Add("first", 12.5)
            data.Rows.Add("second", 27.0)
            Dim view As New DataView(data) With {.AllowNew = False}
            grid.SetDataBinding(view, "")
            host.Show()
            Application.DoEvents()
            Check(grid.Rows.Count = 2, "binding row count")
            Check(grid.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable, "stable engineering row order")
            grid.CurrentCell = New GridPosition(1, 1)
            Check(grid.CurrentRowIndex = 1 AndAlso CDbl(grid.Item(1, 1)) = 27.0, "legacy row/column coordinates")
            Check(grid.BeginEdit(True), "begin numeric edit")
            DirectCast(grid.EditingControl, TextBox).Text = "31"
            Check(grid.EndEdit(), "commit numeric edit")
            grid.BindingContext(view).EndCurrentEdit()
            Check(CDbl(data.Rows(1)("Value")) = 31.0 AndAlso CDbl(data.Rows(0)("Value")) = 12.5, "edit commits selected data row only")
            nameColumn.Width = 0
            Check(Not nameColumn.Visible, "zero legacy width hides column")
            nameColumn.Width = 80
            Check(nameColumn.Visible AndAlso nameColumn.Width = 80, "hidden column can be restored")
            Check(valueColumn.DefaultCellStyle.Format = "0.00" AndAlso valueColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight, "numeric formatting")
            host.Close()
        End Using
        Dim multilineType = Assembly.Load("LibMat").GetType("LibMat.MultiLineColumn", throwOnError:=True)
        Using multiline = DirectCast(Activator.CreateInstance(multilineType), DataGridViewTextBoxColumn)
            Check(multiline.ReadOnly AndAlso multiline.DefaultCellStyle.WrapMode = DataGridViewTriState.True, "notes wrapping and read-only")
        End Using
        Console.WriteLine($"{checks} grid/toolbar checks passed. Engineering cases and real Office printing require separate validation.")
    End Sub
    Private Sub Check(condition As Boolean, description As String)
        If Not condition Then Throw New Exception(description)
        checks += 1
    End Sub
End Module
