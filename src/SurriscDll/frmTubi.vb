Option Strict Off
Option Explicit On
Friend Class frmTubi
	Inherits System.Windows.Forms.Form
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim P0 As Object
		Dim tmin, S As Single
		S = Val(txtTemp(4).Text)
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		P0 = DesignData.PTubi / 10
		If S <= 0 Then
			MsgBox("Tensione ammissibile non valida", MsgBoxStyle.Critical)
			Exit Sub
		End If
		If Geom.RMinTubi < 1.5 * Geom.DiamExtTubi Then
			MsgBox("Raggio di curvatura minimo inaccettabile", MsgBoxStyle.Critical)
			Exit Sub
		End If
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tmin = P0 * Geom.DiamExtTubi / 2 / (S + 0.4 * P0) + DesignData.cTubi
		tmin = tmin / (1 - Geom.DiamExtTubi / 4 / Geom.RMinTubi)
        txtTemp(5).Text = Funzioni.mystr(tmin, 3, 3, False)
        If tmin > Geom.SpessTubi Then
            txtTemp(6).Text = Funzioni.mystr(tmin, 3, 3, False)
        End If
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        If Val(txtTemp(6).Text) < Val(txtTemp(5).Text) Then
            MsgBox("Spessore insufficiente", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Hide()
    End Sub

    Private Sub frmTubi_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        SigmaAmm()
        txtTemp(8).Text = Funzioni.mystr(Geom.DiamExtTubi, 3, 2, False)
        txtTemp(0).Text = Funzioni.mystr(DesignData.PTubi, 3, 2, False)
        txtTemp(1).Text = Funzioni.mystr(DesignData.TTubi, 3, 2, False)
        txtTemp(2).Text = Funzioni.mystr(Geom.RMinTubi, 3, 2, False)
        txtTemp(3).Text = Funzioni.mystr(DesignData.cTubi, 3, 2, False)
    End Sub

    'UPGRADE_WARNING: L'evento txtTemp.TextChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtTemp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(txtTemp, eventSender)
        Select Case Index
            Case 0 : DesignData.PTubi = Val(txtTemp(0).Text)
                SigmaAmm()
            Case 1 : DesignData.TTubi = Val(txtTemp(1).Text)
                SigmaAmm()
            Case 2 : Geom.RMinTubi = Val(txtTemp(2).Text)
            Case 3 : DesignData.cTubi = Val(txtTemp(3).Text)
            Case 6 : Geom.SpessTubi = Val(txtTemp(5).Text)
        End Select
    End Sub

    Private Sub SigmaAmm()
        Dim Sfo, Sfa, td As Single
        td = 1.8 * DesignData.TTubi + 32
        MatTubi.SigmaAmm(1, td, Sfa, Sfo)
        txtTemp(4).Text = Funzioni.mystr(Sfo, 3, 2, False)
    End Sub
End Class