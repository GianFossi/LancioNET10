Option Strict Off
Option Explicit On
Friend Class nuovoLav
	Inherits System.Windows.Forms.Form
	Public Nuovo As Boolean
	Public Canceled As Boolean
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Hide()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Canceled = True
		Hide()
	End Sub
	
	'UPGRADE_WARNING: Form evento nuovoLav.Activate presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub nuovoLav_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If Not Nuovo Then
			Text = "ISA - Modifica Dati Generali"
		Else
            _Combo1_5.SelectedIndex = 0
            _Combo1_6.SelectedIndex = 0
		End If
		
	End Sub
	
	Private Sub nuovoLav_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim Data As String
        _Combo1_5.Items.Add("SI")
        _Combo1_5.Items.Add("ME")
        _Combo1_5.Items.Add("BR")
        _Combo1_6.Items.Add("IT")
        _Combo1_6.Items.Add("IN")
        _Combo1_6.Items.Add("FR")
		Data = CStr(Today)
		MaskEdBox1.Text = Data
	End Sub
End Class