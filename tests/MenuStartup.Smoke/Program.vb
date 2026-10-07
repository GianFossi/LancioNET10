Imports System.Windows.Forms
Module Program
    <STAThread>
    Sub Main()
        Dim mainType = System.Reflection.Assembly.Load("Lancio").GetType("Lancio.Form1", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(mainType, nonPublic:=True), Form)
            If form.MainMenuStrip Is Nothing OrElse form.MainMenuStrip.Items.Count = 0 Then Throw New Exception("Main menu missing")
            If Not form.Controls.Contains(form.MainMenuStrip) Then Throw New Exception("Menu not attached")
            Dim commands = DirectCast(mainType.GetField("mnuTerm").GetValue(form), System.Collections.IDictionary)
            If commands.Count <> 6 Then Throw New Exception("Indexed commands changed")
            If Not Object.ReferenceEquals(commands(0), mainType.GetField("_mnuTerm_0").GetValue(form)) Then Throw New Exception("Menu identity changed")
        End Using
        Dim asmeType = System.Reflection.Assembly.Load("AsmeVip").GetType("AsmeVip.Apert", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(asmeType, nonPublic:=True), Form)
            If form.MainMenuStrip Is Nothing OrElse form.MainMenuStrip.Items.Count = 0 Then Throw New Exception("ASME menu missing")
        End Using
        Dim wrcbType = System.Reflection.Assembly.Load("Wrcb").GetType("Wrcb.Apert", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(wrcbType, nonPublic:=True), Form)
            Dim status = DirectCast(wrcbType.GetField("StatusBar1", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(form), StatusStrip)
            If status.Items.Count <> 3 OrElse Not form.Controls.Contains(status) Then Throw New Exception("WRCB status fields missing")
            If Not DirectCast(status.Items(0), ToolStripStatusLabel).Spring Then Throw New Exception("WRCB workspace panel must fill available space")
            status.Items(1).Text = "Prev.: smoke"
            If status.Items(1).Text <> "Prev.: smoke" Then Throw New Exception("WRCB status text update failed")
        End Using
        Dim traceType = System.Reflection.Assembly.Load("traccia").GetType("traccia.frmTracciat", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(traceType, nonPublic:=True), Form)
            Dim status = DirectCast(traceType.GetField("StatusBar1", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public).GetValue(form), StatusStrip)
            If status.Items.Count <> 3 Then Throw New Exception("Traccia status panels missing")
            If Not form.Controls.Contains(status) Then Throw New Exception("Traccia status strip not attached")
        End Using
        Dim saddleType = System.Reflection.Assembly.Load("prgSaddles").GetType("Saddles.frmSaddles", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(saddleType, Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic,
                                                        Nothing, New Object() {False}, Nothing), Form)
            Dim grids = saddleType.GetFields(Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).Where(Function(field) GetType(DataGridView).IsAssignableFrom(field.FieldType)).ToArray()
            If grids.Length <> 13 Then Throw New Exception("Saddles input/result grids missing")
            For Each field In grids
                Dim grid = DirectCast(field.GetValue(form), DataGridView)
                If grid Is Nothing OrElse grid.Parent Is Nothing Then Throw New Exception("Saddles grid not initialized: " & field.Name)
            Next
            Dim inputGrid = DirectCast(saddleType.GetField("dgElemMant", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(form), DataGridView)
            inputGrid.BindingContext = New BindingContext()
            Dim values As New System.Data.DataTable()
            values.Columns.Add("Load", GetType(Double))
            values.Rows.Add(12.5)
            inputGrid.DataSource = values.DefaultView
            inputGrid.CreateControl()
            If inputGrid.Columns.Count <> 1 OrElse inputGrid.Columns(0).SortMode <> DataGridViewColumnSortMode.NotSortable Then Throw New Exception("Load row ordering changed")
        End Using
        Console.WriteLine("Main and ASME menu construction checks passed (forms not shown, calculations not executed).")
    End Sub
End Module
