Option Strict On
Imports System.Windows.Forms
Imports LancioMigration

' Public WinForms wrapping and automatic row sizing replace private DataGrid reflection.
Public Class MultiLineColumn
    Inherits LegacyTextColumn
    Public Sub New()
        Me.ReadOnly = True
        DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    <System.ComponentModel.DefaultValue(HorizontalAlignment.Left)>
    Public Property DataAlignment As HorizontalAlignment
        Get
            Return Alignment
        End Get
        Set(value As HorizontalAlignment)
            Alignment = value
        End Set
    End Property
    <System.ComponentModel.DefaultValue(True)>
    Public Property AutoAdjustHeight As Boolean
        Get
            Return DefaultCellStyle.WrapMode = DataGridViewTriState.True
        End Get
        Set(value As Boolean)
            DefaultCellStyle.WrapMode = If(value, DataGridViewTriState.True, DataGridViewTriState.False)
        End Set
    End Property
End Class
