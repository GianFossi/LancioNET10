Option Strict Off
Option Explicit On
Friend Class frmProp
	Inherits System.Windows.Forms.Form
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		If Problem.tmin >= Problem.Tmax Then
			MsgBox("Fornire prima i dati per la temeperatura minima e poi quelli per la temperatura massima", MsgBoxStyle.Critical)
		Else
			Prop.Transfer()
			Hide()
			Prop.Inizia(True)
		End If
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Hide()
	End Sub
	
	Private Sub frmProp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Aggiorna()
	End Sub
	
	'UPGRADE_WARNING: L'evento txtTemp.TextChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTemp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTemp.TextChanged
		Dim Index As Short = txtTemp.GetIndex(eventSender)
		With Problem
			Select Case Index
				Case 0 : .VolMin = Val(txtTemp(Index).Text)
				Case 1 : .VolMax = Val(txtTemp(Index).Text)
				Case 2 : .tmin = Val(txtTemp(Index).Text)
				Case 3 : .Tmax = Val(txtTemp(Index).Text)
				Case 4 : .ViscoMin = Val(txtTemp(Index).Text)
				Case 5 : .ViscoMax = Val(txtTemp(Index).Text)
				Case 6 : .CpMin = Val(txtTemp(Index).Text)
				Case 7 : .CpMax = Val(txtTemp(Index).Text)
				Case 8 : .kMin = Val(txtTemp(Index).Text)
				Case 9 : .kMax = Val(txtTemp(Index).Text)
			End Select
		End With
	End Sub
	
	Private Sub Aggiorna()
		With Problem
            txtTemp(0).Text = Funzioni.mystr(.VolMin, 4, 4, False)
            txtTemp(1).Text = Funzioni.mystr(.VolMax, 4, 4, False)
            txtTemp(2).Text = Funzioni.mystr(.tmin, 3, 2, False)
            txtTemp(3).Text = Funzioni.mystr(.Tmax, 3, 2, False)
            txtTemp(4).Text = Funzioni.mystr(.ViscoMin, 1, 6, False)
            txtTemp(5).Text = Funzioni.mystr(.ViscoMax, 1, 6, False)
            txtTemp(6).Text = Funzioni.mystr(.CpMin, 5, 2, False)
            txtTemp(7).Text = Funzioni.mystr(.CpMax, 5, 2, False)
            txtTemp(8).Text = Funzioni.mystr(.kMin, 2, 5, False)
            txtTemp(9).Text = Funzioni.mystr(.kMax, 2, 5, False)
		End With
	End Sub
End Class