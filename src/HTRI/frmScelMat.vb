Option Strict Off
Option Explicit On
Friend Class frmScelMat
	Inherits System.Windows.Forms.Form
    Public Matdim As LibMat.MaterialeNew1
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Hide()
	End Sub
	'UPGRADE_WARNING: Form evento frmScelMat.Activate presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmScelMat_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Text1.Text = ""
	End Sub
    Private Sub _HelpFile_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _HelpFile_0.Click
        Matdim.Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
        Text1.Text = Matdim.MatStr
    End Sub
End Class