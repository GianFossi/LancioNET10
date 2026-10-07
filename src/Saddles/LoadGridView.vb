Option Strict On
Imports System.Drawing
Imports System.Windows.Forms

Friend Class LoadGridView
    Inherits DataGridView
    Private title As String = ""
    <System.ComponentModel.DefaultValue("")>
    Public Property CaptionTitle As String
        Get
            Return title
        End Get
        Set(value As String)
            title = If(value, "")
            AccessibleName = title
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            ColumnHeadersHeight = If(title.Length = 0, 23, 45)
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnDataBindingComplete(e As DataGridViewBindingCompleteEventArgs)
        ' Engineering routines address the original DataView by row number.
        For Each column As DataGridViewColumn In Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        MyBase.OnDataBindingComplete(e)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If title.Length = 0 OrElse Not ColumnHeadersVisible Then Return
        Dim area As New Rectangle(1, 1, Math.Max(0, ClientSize.Width - 2), 21)
        e.Graphics.FillRectangle(SystemBrushes.Control, area)
        TextRenderer.DrawText(e.Graphics, title, Font, area, ForeColor,
                              TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis)
    End Sub
End Class
