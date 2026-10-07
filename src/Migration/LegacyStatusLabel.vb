Option Strict On
Namespace Global.LancioMigration
    Public Class LegacyStatusLabel
        Inherits System.Windows.Forms.ToolStripStatusLabel
        <System.ComponentModel.DefaultValue(0)>
        Public Property MinimumWidth As Integer
        Public Overrides Function GetPreferredSize(proposedSize As System.Drawing.Size) As System.Drawing.Size
            Dim preferred = MyBase.GetPreferredSize(proposedSize)
            preferred.Width = Math.Max(preferred.Width, MinimumWidth)
            Return preferred
        End Function
    End Class
End Namespace
