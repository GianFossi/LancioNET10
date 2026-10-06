Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class Apert
	Inherits System.Windows.Forms.Form
	Public Ogg As clsPpg
    Public mygraphics As Graphics
    Public myfont As Font
    Public mybrush As SolidBrush
    Private Inizializzando As Boolean
    Private dovebitmap As Bitmap
    Private CarHeight, CarWidth As Single
    Private Gia As Boolean
    Public x, y As Single
    Public Function MisuraStringa(ByVal t As String) As SizeF
        Dim characterRanges As CharacterRange() = _
        {New CharacterRange(0, t.Length)}
        Dim layoutRect As RectangleF = New RectangleF(0, 0, Picture1.Width, Picture1.Height)
        Dim stringFormat As New StringFormat
        stringFormat.SetMeasurableCharacterRanges(characterRanges)
        Dim stringRegions(0) As [Region]
        stringRegions = mygraphics.MeasureCharacterRanges(t, _
        myfont, layoutRect, stringFormat)
        Dim Rect As RectangleF = stringRegions(0).GetBounds(mygraphics)
        Dim s As New SizeF(Rect.Width, Rect.Height)
        Return s
    End Function
    Public Sub Scrivi(ByRef t As String, Optional ByRef locy As Integer = -1, Optional ByRef locx As Integer = -1, Optional ByRef mode As Integer = -1, Optional ByRef PunVir As Boolean = False)
        Static sx, sY As Single
        Dim xx, yy As Single
        Dim Cont As Boolean
        Dim Lunghezza As Single
        If t.Length > 0 Then Lunghezza = MisuraStringa(t).Width
        If Not PunVir Then
            If locy > -1 Then
                y = locy * CarHeight
                Cont = False
            Else
                Cont = True
            End If
            If locx > 0 Then x = MisuraStringa(New String("A"c, CInt(locx))).Width
            If Cont Then
                x = sx
                y = sY
            End If
        End If
        If mode = 1 Then
            If PunVir Then
                mybrush.Color = Color.LightCoral
                mygraphics.FillRectangle(mybrush, New RectangleF(x, y, Lunghezza, CarHeight))
                mybrush.Color = Color.Black
            Else
                If Cont Then
                    xx = sx / CarWidth
                    yy = sY / CarHeight
                Else
                    yy = locy
                End If
                mybrush.Color = Color.LightCoral
                mygraphics.FillRectangle(mybrush, New RectangleF(x, yy * CarHeight, Lunghezza, CarHeight))
                mybrush.Color = Color.Black
                y = yy * CarHeight
            End If
        End If
        If PunVir Then
            sx = x + Lunghezza
            sY = y
        Else
            sx = 0
            sY += CarHeight
        End If
        mygraphics.DrawString(t, myfont, mybrush, x, y)
    End Sub
    Private Sub cmbUnita_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbUnita.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        ConvertiDatiGiu()
        Ogg.priUnit = cmbUnita.SelectedIndex + 1
        ConvertiDatiSu()
    End Sub
    Private Sub Inizializza()
        dovebitmap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height)
        mygraphics = Graphics.FromImage(dovebitmap)
        Picture1.Image = dovebitmap
        myfont = Picture1.Font
        mybrush = New SolidBrush(Color.Black)
        CarHeight = MisuraStringa("A").Height
        CarWidth = MisuraStringa("A").Width
    End Sub
	Private Sub cmdCalcola_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalcola.Click
		Dim iErr As Short
		Ogg.Calcola(iErr)
	End Sub
	
	Private Sub cmdGo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGo.Click
		mnuFile0.Visible = True
		Frame1.Visible = True
		Frame3.Visible = True
		Label1.Visible = False
		cmdGo.Visible = False
		Option1(0).Checked = True
		Option2(0).Checked = True
        Monitor.Motore.Mostra(myassembly)
	End Sub
	
	Private Sub cmdIndietro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdIndietro.Click
		If Ogg.prIppgas65 = 2 Then ConvertiDatiSu()
		Frame4.Visible = False
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If Ogg.prIppgas65 = 2 Then
			ConvertiDatiSu()
			Ogg.VerificaDati()
		End If
	End Sub
    Private Sub cmdOkVis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Picture1.Visible = False
    End Sub
    Private Sub cmdWald_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWald.Click
        Dim o As New Wald.clsWald
        o.DoveMotore = Monitor.Motore
        o.EseguiDaPPG(VB.Left(Ogg.FileData, Len(Ogg.FileData) - 4))
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Select Case Ogg.prIppgas65
            Case 0, 1
                Ogg.Gia = False
                Ogg.SelezioneMiscela(True)
                Frame4.Visible = False
            Case 2
                Frame4.Visible = True
                Frame4.BringToFront()
                Ogg.INPUTPHYSICALPROPERTY(1, "")
        End Select
    End Sub
    Private Sub Apert_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim Testo As String
        If Gia Then Exit Sub
        Gia = True
        If Ogg.Schiavo Then
            mnuFile0.Visible = True
            Frame1.Visible = True
            Label1.Visible = False
            cmdGo.Visible = False
            Option1(0).Checked = True
            Option2(0).Checked = True
            Ogg.Apri()
        Else
            Testo = "      PPGAS PROGRAM               1st issued on Dec. 9th,1983     " & vbCrLf
            Testo = Testo & "      PHYSICAL PROPERTIES OF A MIXTURE OF GASES INCLUDING :       " & vbCrLf
            Testo = Testo & "   CO H2O H2 N2 CO2 CH4 Ar NH3 O2 NO NO2 SO2 SO3 C2H4 C2H6 C3H8   " & vbCrLf
            Testo = Testo & "   and 49 other gases, using " & vbCrLf
            Testo = Testo & "       Carl L. Yaws, Friend & Adler, Herning & Zipperer, Gambill  " & vbCrLf
            Testo = Testo & "       & Godridge, Prausnitz & Gunn, Pitzer & Curl, Dean & Stiel, " & vbCrLf
            Testo = Testo & "       Abas-Zade & Thodos, Reid & Sherwood correlations or data,  " & vbCrLf
            Testo = Testo & "       W.C. Edmister's compressib. factor & press. correc. curves " & vbCrLf
            Testo = Testo & "       ANSI/ASME PTC4.4 Gas Turbine enthalpy calculat. proccedure " & vbCrLf
            Testo = Testo & "       and including four different H2SO4 dew point correlations  " & vbCrLf
            Testo = Testo & "                    Rev. " & Monitor.Motore.About.ProgVers & "  dated " & Monitor.Motore.About.ProgDate & vbCrLf
            Testo = Testo & "                    copyright Leonardo Presciuttini" & vbCrLf
            Testo = Testo & "                    licensed to " & Monitor.Motore.About.Company
            mnuFile0.Visible = False
            Label1.Text = Testo
            Frame1.Visible = False
            Label1.Visible = True
            cmdGo.Visible = True
            cmdGo.BringToFront()
        End If
    End Sub
	
	Private Sub Apert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cmbUnita.Items.Add("metriche (kcal, kg, hr, centipoises)")
		cmbUnita.Items.Add("SI       (Watt, kg, sec., °C) ")
		cmbUnita.Items.Add("British  (BTU, kg, hr, Ft °F) ")
		cmbUnita.SelectedIndex = 1
	End Sub
    Private Sub Apert_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim Cancel As Boolean = eventArgs.Cancel
        'Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        If Ogg.Schiavo Then Ogg.Salva()
        If Not Ogg.Stub Is Nothing Then Ogg.Stub.sClose()
        If Not Ogg.StubAcid Is Nothing Then Ogg.StubAcid.sClose()
        Monitor.Motore.Ammazza("PPGS")
        Dispose()
        'eventArgs.Cancel = Cancel
    End Sub
    Public Sub mnuCompos_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCompos.Click
        Try
            Dim Index As Short = mnuCompos.GetIndex(eventSender)
            Dim i As Short
            If mnuCompos(Index).Checked Then Exit Sub
            For i = 0 To 2 : mnuCompos(i).Checked = False : Next
            mnuCompos(Index).Checked = True
            Select Case Index
                Case 0
                    Command1.Text = "Composizione miscela"
                    Label2(0).Visible = True
                    Label3.Visible = True
                    Frame2(0).Visible = True
                    Frame2(1).Visible = True
                    Frame4.Visible = False
                    Frame6.Visible = False
                    Ogg.prIppgas65 = -1
                Case 1
                    Command1.Text = "Dati manuali"
                    Label2(0).Visible = False
                    Label3.Visible = False
                    Frame2(0).Visible = False
                    Frame2(1).Visible = False
                    Frame4.Visible = True
                    Frame6.Visible = False
                    Frame4.BringToFront()
                    Ogg.prIppgas65 = 2
                Case 2
                    Frame2(0).Visible = False
                    Frame2(1).Visible = False
                    Frame4.Visible = False
                    Frame6.Visible = True
                    Ogg.prIppgas65 = 3
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
	
	Public Sub mnuFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFile.Click
		Dim Index As Short = mnuFile.GetIndex(eventSender)
		Dim Nome As String
		Select Case Index
			Case 1 'apri
                Monitor.Motore.Mostra(myAssembly)
			Case 2 'salva
				cmdOk_Click(cmdOk, New System.EventArgs())
				Ogg.Salva()
			Case 3
				On Error GoTo ErrCC
				'UPGRADE_WARNING: Filter ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				CommonDialog1Save.Filter = "(*.PPG)|*.PPG|"
				CommonDialog1Save.InitialDirectory = Monitor.Motore.Inizio.Datidir
                CommonDialog1Save.FileName = IO.Path.GetFileName(Ogg.FileData)
                CommonDialog1Save.ShowDialog()
                Nome = CommonDialog1Save.FileName
                Ogg.FileData = Nome
                Ogg.Salva()
            Case 4 'esci
                cmdOk_Click(cmdOk, New System.EventArgs())
                'Ogg.Salva
                Me.Close()
        End Select
ErrCC:
    End Sub
    'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = Option1.GetIndex(eventSender)
            Ogg.prIppgas65 = Index
        End If
    End Sub
    Public Sub Aggiorna()
        txtPress.Text = Funzioni.mystr((Ogg.prPressione), 4, 2, False)
        cmbUnita.SelectedIndex = Ogg.priUnit - 1
        txtTemp(0).Text = Funzioni.mystr((Ogg.prTmin), 4, 2, False)
        txtTemp(1).Text = Funzioni.mystr((Ogg.prTmax), 4, 2, False)
        txtTemp(2).Text = Funzioni.mystr((Ogg.prTincr), 4, 2, False)
		Select Case Ogg.prIppgas65
			Case -1 To 1
				Option1(Ogg.prIppgas65).Checked = True
				Option2(Ogg.prPercVol).Checked = True
				mnuCompos_Click(mnuCompos.Item(0), New System.EventArgs())
				Frame4.Visible = False
			Case 2
				mnuCompos_Click(mnuCompos.Item(1), New System.EventArgs())
				Frame4.Visible = True
				Frame4.BringToFront()
				Ogg.INPUTPHYSICALPROPERTY(1, "")
			Case 3
				mnuCompos_Click(mnuCompos.Item(2), New System.EventArgs())
		End Select
		txtDen.Text = Ogg.prFluido
	End Sub
	'UPGRADE_WARNING: L'evento Option2.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option2.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = Option2.GetIndex(eventSender)
			Ogg.prPercVol = Index
		End If
	End Sub
	'UPGRADE_WARNING: L'evento optLG.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optLG_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optLG.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optLG.GetIndex(eventSender)
			If optLG(0).Checked Then
				Frame5(3).Visible = True
				Frame5(4).Visible = False
				Ifluide = 1
			Else
				Frame5(4).Visible = True
				Frame5(3).Visible = False
				Ifluide = 2
			End If
		End If
	End Sub
    Private Sub txtDen_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDen.TextChanged
        If Inizializzando Then Exit Sub
        Ogg.prFluido = txtDen.Text
    End Sub
    Private Sub txtMan_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMan.TextChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = txtMan.GetIndex(eventSender)
        Dim i As Short
        i = Index
        If Ifluide = 2 And Index > 12 Then i = i - 3
        With Ogg
            .prE3(2 * (i + 1)) = Funzioni.ValVir(txtMan(Index).Text)
            If Ifluide = 2 And Index > 12 Then
                .prE3(26) = -999
                If .prE3(23) > 0 Then Ogg.prPesoMoc(0) = .prE3(22) * 22.4 * (273.15 + .prE3(21)) * 1.01325 / 273.15 / .prE3(23)
                txtTemp1(15).Text = VB6.Format(Ogg.prPesoMoc(0), FormDen)
            End If
        End With
    End Sub
    Private Sub txtPress_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPress.TextChanged
        If Inizializzando Then Exit Sub
        Ogg.prPressione = Funzioni.ValVir(txtPress.Text)
    End Sub
    Private Sub txtTemp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTemp.TextChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = txtTemp.GetIndex(eventSender)
        Select Case Index
            Case 0 : Ogg.prTmin = Funzioni.ValVir(txtTemp(Index).Text)
            Case 1 : Ogg.prTmax = Funzioni.ValVir(txtTemp(Index).Text)
            Case 2 : Ogg.prTincr = Funzioni.ValVir(txtTemp(Index).Text)
        End Select
    End Sub
    Public Sub AggManual()
        Dim i As Short
        Dim f As String
        ConvertiDatiGiu()
        With Ogg
            For i = 1 To 13 - Ifluide + 1
                Select Case i
                    Case 1, 2, 3, 4
                        If .priUnit = 2 Then f = FormCp Else f = FormMu
                    Case 8, 9, 10 : f = FormMu
                    Case Else : f = FormDen
                End Select
                If Ifluide = 2 And i = 12 Then
                    txtTemp1(15).Text = VB6.Format(Ogg.prPesoMoc(0), FormCp)
                ElseIf Ifluide = 2 And i = 11 Then
                    'txtTemp1(14) = Format(.prE3(2 * i - 1), FormCp)
                Else
                    txtMan(i - 1).Text = VB6.Format(.prE3(2 * i), f)
                    txtTemp1(i - 1).Text = VB6.Format(.prE3(2 * i - 1), FormCp)
                End If
            Next
            If Ifluide = 2 Then
                txtMan(13).Text = VB6.Format(.prE3(22), FormDen)
                txtTemp1(13).Text = VB6.Format(.prE3(23), FormDen)
                txtTemp1(14).Text = VB6.Format(.prE3(21), FormDen)
            End If
        End With
    End Sub
    'UPGRADE_WARNING: L'evento txtTemp1.TextChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtTemp1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTemp1.TextChanged
        Dim Index As Short = txtTemp1.GetIndex(eventSender)
        Dim i As Short
        i = Index
        If Ifluide = 2 And Index > 12 Then i = i - 3
        With Ogg
            If Ifluide = 1 Then
                .prE3(2 * (i + 1) - 1) = Funzioni.ValVir(txtTemp1(Index).Text)
            ElseIf Ifluide = 2 And Index > 12 Then
                Select Case Index
                    Case 13 : .prE3(23) = Funzioni.ValVir(txtTemp1(Index).Text) 'pressione
                    Case 14 : .prE3(21) = Funzioni.ValVir(txtTemp1(Index).Text) 'temperatura
                End Select
                .prE3(26) = -999
                If .prE3(23) > 0 Then Ogg.prPesoMoc(0) = .prE3(22) * 22.4 * (273.15 + .prE3(21)) * 1.01325 / 273.15 / .prE3(23)
                txtTemp1(15).Text = VB6.Format(Ogg.prPesoMoc(0), FormDen)
            Else
                .prE3(2 * (i + 1) - 1) = Funzioni.ValVir(txtTemp1(Index).Text)
            End If
        End With
    End Sub

    Private Sub cmdOKGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKGo.Click
        Picture1.Visible = False
        cmdOKGo.Visible = False
    End Sub
End Class