Option Strict Off
Option Explicit On
Friend Class frmMsg
	Inherits System.Windows.Forms.Form
	Public Annullato As Boolean
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Annullato = True
	End Sub
End Class