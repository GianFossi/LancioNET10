Option Strict On
Imports System.Drawing
Imports System.Windows.Forms
Namespace Global.LancioMigration
    Public Structure GridPosition
        Public RowNumber As Integer
        Public ColumnNumber As Integer
        Public Sub New(row As Integer, column As Integer)
            RowNumber = row
            ColumnNumber = column
        End Sub
    End Structure
    ' Supported WinForms control; small public-API bridge for legacy row coordinates.
    Public Class LegacyGridView
        Inherits DataGridView
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Shadows Property CurrentCell As GridPosition
            Get
                If MyBase.CurrentCell Is Nothing Then Return New GridPosition(-1, -1)
                Return New GridPosition(MyBase.CurrentCell.RowIndex, MyBase.CurrentCell.ColumnIndex)
            End Get
            Set(value As GridPosition)
                If value.RowNumber < 0 OrElse value.RowNumber >= Rows.Count OrElse value.ColumnNumber < 0 OrElse value.ColumnNumber >= Columns.Count Then Return
                If Not Columns(value.ColumnNumber).Visible Then Return
                MyBase.CurrentCell = Rows(value.RowNumber).Cells(value.ColumnNumber)
            End Set
        End Property
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Property CurrentRowIndex As Integer
            Get
                Return CurrentCell.RowNumber
            End Get
            Set(value As Integer)
                Dim column = CurrentCell.ColumnNumber
                If column < 0 Then
                    For Each candidate As DataGridViewColumn In Columns
                        If candidate.Visible Then
                            column = candidate.Index
                            Exit For
                        End If
                    Next
                End If
                CurrentCell = New GridPosition(value, column)
            End Set
        End Property
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Shadows Property Item(row As Integer, column As Integer) As Object
            Get
                Return Rows(row).Cells(column).Value
            End Get
            Set(value As Object)
                Rows(row).Cells(column).Value = value
            End Set
        End Property
        Public ReadOnly Property FirstVisibleColumn As Integer
            Get
                Return Math.Max(0, FirstDisplayedScrollingColumnIndex)
            End Get
        End Property
        Public ReadOnly Property VisibleColumnCount As Integer
            Get
                Return Columns.GetColumnCount(DataGridViewElementStates.Displayed)
            End Get
        End Property
        <System.ComponentModel.DefaultValue(75)>
        Public Property PreferredColumnWidth As Integer = 75
        Private rowHeight As Integer = 22
        <System.ComponentModel.DefaultValue(22)>
        Public Property PreferredRowHeight As Integer
            Get
                Return rowHeight
            End Get
            Set(value As Integer)
                rowHeight = Math.Max(2, value)
                RowTemplate.Height = rowHeight
                For Each row As DataGridViewRow In Rows
                    row.Height = rowHeight
                Next
            End Set
        End Property
        Public Sub SetDataBinding(source As Object, member As String)
            EndEdit()
            DataMember = member
            DataSource = source
        End Sub
        Public Function GetCellBounds(row As Integer, column As Integer) As Rectangle
            Return GetCellDisplayRectangle(column, row, False)
        End Function
        Protected Overrides Sub OnDataBindingComplete(e As DataGridViewBindingCompleteEventArgs)
            For Each column As DataGridViewColumn In Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
                If AutoGenerateColumns Then column.Width = Math.Max(2, PreferredColumnWidth)
            Next
            PreferredRowHeight = rowHeight
            MyBase.OnDataBindingComplete(e)
        End Sub
    End Class
    Public Class LegacyTextColumn
        Inherits DataGridViewTextBoxColumn
        <System.ComponentModel.DefaultValue("")>
        Public Property MappingName As String
            Get
                Return DataPropertyName
            End Get
            Set(value As String)
                DataPropertyName = value
            End Set
        End Property
        <System.ComponentModel.DefaultValue("")>
        Public Property Format As String
            Get
                Return DefaultCellStyle.Format
            End Get
            Set(value As String)
                DefaultCellStyle.Format = value
            End Set
        End Property
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Property FormatInfo As IFormatProvider
            Get
                Return DefaultCellStyle.FormatProvider
            End Get
            Set(value As IFormatProvider)
                DefaultCellStyle.FormatProvider = value
            End Set
        End Property
        <System.ComponentModel.DefaultValue(HorizontalAlignment.Left)>
        Public Property Alignment As HorizontalAlignment
            Get
                Select Case DefaultCellStyle.Alignment
                    Case DataGridViewContentAlignment.MiddleRight : Return HorizontalAlignment.Right
                    Case DataGridViewContentAlignment.MiddleCenter : Return HorizontalAlignment.Center
                    Case Else : Return HorizontalAlignment.Left
                End Select
            End Get
            Set(value As HorizontalAlignment)
                Select Case value
                    Case HorizontalAlignment.Right : DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case HorizontalAlignment.Center : DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else : DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End Select
            End Set
        End Property
        <System.ComponentModel.DefaultValue(100)>
        Public Shadows Property Width As Integer
            Get
                Return If(Visible, MyBase.Width, 0)
            End Get
            Set(value As Integer)
                Visible = value > 0
                If value > 0 Then MyBase.Width = Math.Max(MinimumWidth, value)
            End Set
        End Property
    End Class
End Namespace
