Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Drawing.Drawing2D
Friend Class Apert
	Inherits System.Windows.Forms.Form
    Dim TipoStr(3) As String
    Private Gia, Inizializzando As Boolean
	Public Sub Calcola_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Calcola.Click '/17/01/01
		Dim iErr As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		IniziaCalcolo(iErr, True) '17/01/01
		If iErr = 1 Then
            Problem.Temp = Problem.Funz
			MsgBox("Problemi di convergenza", MsgBoxStyle.Critical)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		ElseIf iErr >= 2 Then 
			Critical = False
            Problem.Temp = Problem.Funz
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		DropVap()
		DropGas()
		OverAll()
        Problem.Temp = Problem.Funz
		Aggiorna()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
    Private Sub chkCross_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkCross.CheckStateChanged
        If Inizializzando Then Exit Sub
        Config.Nuovo = chkCross.CheckState = 1
    End Sub
	
	'UPGRADE_WARNING: L'evento chkInvert.CheckStateChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkInvert_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkInvert.CheckStateChanged
		Problem.FluidiInvertiti = chkInvert.CheckState = 1
		If Problem.FluidiInvertiti Then
			Frame3.Text = "Gas lato mantello"
		Else
			Frame3.Text = "Gas lato tubi"
		End If
	End Sub
	
	'UPGRADE_WARNING: L'evento cmbAltern.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbAltern_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbAltern.SelectedIndexChanged
		Dim i As Short
		If Not cmbAltern.Enabled Then Exit Sub
		i = cmbAltern.SelectedIndex + 1
		If i <= nAlt Then
			Salva()
			Apri(i)
		Else
			NuovAltern()
			AggAltern()
			cmbAltern.SelectedIndex = nAlt - 1
		End If
	End Sub
	'UPGRADE_WARNING: L'evento cmbVarDip.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbVarDip_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbVarDip.SelectedIndexChanged
		Config.VariabIndProg = cmbVarDip.SelectedIndex + 1
		cmbInc_SelectedIndexChanged(cmbInc, New System.EventArgs())
	End Sub
	Private Sub cmdBWG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Dim Index As Short = IndexedControls.IndexOf(cmdBWG, eventSender)
		Dim objBWG As LibMat.clsBWG
		objBWG = New LibMat.clsBWG
        objBWG.DoveMotore = Monitor.Motore
		With objBWG
			.Spess = Geom.SpessTubi
			.Diam = Geom.DiamExtTubi
			.BWG = Geom.BWGTubi
			.TextBWG = Str(.BWG)
			.Mostra()
			Geom.SpessTubi = .Spess
			Geom.DiamExtTubi = .Diam
			Geom.BWGTubi = .BWG
		End With
		'UPGRADE_NOTE: È possibile che l'oggetto objBWG non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		objBWG = Nothing
		If Index = 1 Then
            If Geom.IndMatTubi > 0 Then
                FormTubi = New frmTubi
                formTubi.ShowDialog()
                formTubi.dispose()
            End If
		End If
		Aggiorna()
	End Sub
	Private Sub cmdDS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDS.Click
        ScriviDS()
    End Sub
	Private Sub cmdMat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Dim Index As Short = IndexedControls.IndexOf(cmdMat, eventSender)
		Select Case Index
			Case 0
                MatTubi.Scelta(4, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoRam)
				Geom.IndMatTubi = MatTubi.Indmat
				txtTemp(60).Text = MatTubi.MatStr
				Problem.kHigh = MatTubi.Conducib(Problem.Temp.Tgasin)
				Problem.kLow = MatTubi.Conducib(Problem.Temp.Tvout)
		End Select
		Aggiorna()
	End Sub
	
	Private Sub cmdRapp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRapp.Click
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            ScriviRapporto9()
        Else
            ScriviRapporto()
        End If
    End Sub
	
	Public Sub cmdReg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Dim Index As Short = IndexedControls.IndexOf(cmdReg, eventSender)
		Dim savGeom As typGeom
		Dim Angol() As Single
		Dim i As Short
		Dim H1, zoom As Single
		Dim Qtot, Htot, Excess As Single
		Dim Cp0, Cp1 As Single
		Dim Grafico As RoutBase1.clsGrafico
		Dim Titolo As String
		Dim iErr As Short
		Dim Nograph As Boolean
		Dim tGrafMin, tGrafMax As Single '17/01/01
		ReDim Angol(nReg)
		Nograph = False
		If Geom.FiValv >= Geom.GasOutlet Then
			MsgBox("Diametro della farfalla di regolazione impossibile.")
			Exit Sub
		End If
		If Index > 1 Then
			Nograph = True
			Index = Index - 2
		End If
		tGrafMin = 9999# : tGrafMax = -9999 '17/01/01
		Config.Progetto = 1
		'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		For i = nReg To 1 Step -1
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto savProbl. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			savProbl = Problem
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto savGeom. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			savGeom = Geom
			If Index = 1 Then Problem.Rinside = 0 : Problem.Routside = 0
			zoom = 1
			Select Case Problem.QminReg
				Case 0 : zoom = 1
				Case Is <= 50 : zoom = 2
					'Case Is <= 35: zoom = 3
				Case Is <= 75 : zoom = 4
				Case Is <= 80 : zoom = 5
				Case Else : zoom = 10
			End Select
			zoom = 1
			fi = 1 - (nReg - i) / nReg / zoom
			Reg(Index).Bypass(i) = fi * 100 '17/01/01
			CalcTvapo(fi)
			IniziaCalcolo(iErr, False) '17/01/01
			If iErr = 1 Then
                Problem = savProbl
                Geom = savGeom
				Reg(Index).Tgdopo(i) = 0 'Problem.Temp.Tgasout'17/01/01
				Reg(Index).Tgprima(i) = 0 ' Problem.Temp.Tgasout'17/01/01
				Reg(Index).Tvap(i) = 0 'Surr.TempLTc'17/01/01
				GoTo Cont
			ElseIf iErr >= 2 Then 
				Exit Sub
			End If
			DropGas()
			DropVap()
			OverAll()
			Reg(Index).Tgprima(i) = Surr.TempLMf '17/01/01
			Reg(Index).Tvap(i) = Surr.TempLTc '17/01/01
			EntalpGas(H1)
			Htot = fi * H1
			Do 
				EntalpGas(Qtot)
				Excess = Qtot - Htot
				Cp0 = Prop.CpGas((Surr.TempLMc))
				Cp1 = Prop.CpGas((Surr.TempLMf))
				Surr.TempLMf = Surr.TempLMf + Excess / ((Cp0 + Cp1) / 2)
			Loop While System.Math.Abs(Excess) / Qtot > 0.0001
			Reg(Index).Tgdopo(i) = Surr.TempLMf '17/01/01
			CalcolaFarf(Index, i)
			'---------17/01/01------------
			If Reg(Index).Tgprima(i) < tGrafMin Then tGrafMin = Reg(Index).Tgprima(i)
			If Reg(Index).Tgdopo(i) < tGrafMin Then tGrafMin = Reg(Index).Tgdopo(i)
			If Reg(Index).Tvap(i) < tGrafMin Then tGrafMin = Reg(Index).Tvap(i)
			If Reg(Index).Tgprima(i) > tGrafMax Then tGrafMax = Reg(Index).Tgprima(i)
			If Reg(Index).Tgdopo(i) > tGrafMax Then tGrafMax = Reg(Index).Tgdopo(i)
			If Reg(Index).Tvap(i) > tGrafMax Then tGrafMax = Reg(Index).Tvap(i)
			'-----------------------------
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Problem. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Problem = savProbl
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Geom. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Geom = savGeom
Cont: 
		Next 
		'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		Grafico = New RoutBase1.clsGrafico
		Grafico.Motore = Monitor.Motore
		Titolo = Trim(Monitor.Motore.Problem.ClientPlant) & "- Item: " & Trim(Monitor.Motore.Problem.Item)
		If Index = 1 Then
			Titolo = Titolo & "|Apparecchio pulito"
		Else
			Titolo = Titolo & "|Apparecchio sporco"
		End If
		tGrafMax = (Int(tGrafMax / 100) + 1) * 100 '17/01/01
		tGrafMin = Int(tGrafMin / 100) * 100 '17/01/01
		Grafico.Inizializza(tGrafMax, tGrafMin, Reg(Index).Bypass(1), Reg(Index).Bypass(nReg), "Shell flow (%)", "Temperatures", Titolo) '17/01/01
        Grafico.DisCurva(Reg(Index).Bypass, Reg(Index).Tvap, 1, nReg, "Steam output", DashStyle.Solid) '17/01/01
        Grafico.DisCurva(Reg(Index).Bypass, Reg(Index).Tgprima, 1, nReg, "Gas before mix", DashStyle.Solid) '17/01/01
        Grafico.DisCurva(Reg(Index).Bypass, Reg(Index).Tgdopo, 1, nReg, "Gas after mix", DashStyle.DashDot) '17/01/01
		For i = 0 To nReg
			Angol(i) = tGrafMin + Reg(Index).Angolo(i) / 90 * (tGrafMax - tGrafMin)
		Next 
        Grafico.DisCurva(Reg(Index).Bypass, Angol, 1, nReg, "Butterfly angle", DashStyle.Solid)
		Grafico.Salva(VB.Left(FileData, Len(FileData) - 4) & "PIC" & Trim(Str(Index)) & ".WMF") '17/01/01
		If Nograph Then Grafico.Ammazza() '17/01/01
        Grafico = Nothing
	End Sub
    Private Sub cmdTipo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTipo.Click
        Dim FormTipo As frmTipo = New frmTipo
        FormTipo.ShowDialog()
        FormTipo.Dispose()
        txtTipo.Text = TipoStr(Config.Tipo)
        GestisciIncroci()
    End Sub
    Private Sub cmdTraccia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTraccia.Click
        Dim testo, File As String
        Dim FileTrac As String = ""
        Dim objTraccia As traccia.clsTracciatura
        objTraccia = New traccia.clsTracciatura
        objTraccia.DoveMotore = Monitor.Motore
        File = GenFileTraccia()
        If IO.File.Exists(File) Then
            testo = "Una tracciatura è già disponibile per questo apparecchio." & vbCrLf
            testo = testo & "Si desidera aggiornarla con i dati geometrici attuali?"
            If MsgBox(testo, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Genera(File)
        Else
            Genera(File)
        End If
        objTraccia.Esegui(1, File)
        LegacyTracciaExport.Scrivi(objTraccia, FileTrac)
        LeggiDT(FileTrac)
        'objTraccia.Class_Terminate()
        Monitor.Motore.Ammazza("TRAC")
        objTraccia = Nothing
        Aggiorna()
    End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Fase = Fase - 1
		VisualizzaFase(Fase + 1)
		Command1.Enabled = Fase > 1
		Command2.Enabled = Fase < 4
	End Sub
	'UPGRADE_WARNING: L'evento cmbInc.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbInc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbInc.SelectedIndexChanged
		Config.Progetto = cmbInc.SelectedIndex
		txtTemp(1).Visible = True
		txtTemp(3).Visible = True
		txtTemp(6).BackColor = System.Drawing.Color.White
		txtTemp(7).BackColor = System.Drawing.Color.White
		txtTemp(1).BackColor = System.Drawing.Color.White
		txtTemp(3).BackColor = System.Drawing.Color.White
		Command3.Visible = True
		Select Case Config.Progetto
			Case 0
				'1 portata gas 2 portata vapore 3 tgasout 4 tgasin
				Select Case Config.VariabIndProg
					Case 1 : txtTemp(6).BackColor = System.Drawing.Color.Yellow
					Case 2 : txtTemp(7).BackColor = System.Drawing.Color.Yellow
					Case 3 : txtTemp(1).BackColor = System.Drawing.Color.Yellow
					Case 4 : txtTemp(3).BackColor = System.Drawing.Color.Yellow
				End Select
			Case 1
				txtTemp(1).Visible = False
				txtTemp(3).Visible = False
				Command3.Visible = False
				Command2.Enabled = True
		End Select
		GestisciIncroci()
	End Sub
	Private Sub cmdGas_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGas.Click
        Dim ff As String = ""
		Dim Res As Boolean
		Dim T1, dt, T2 As Single
		Config.Autom = True
		Select Case Config.Autom
			Case True
				dt = Problem.Temp.Tgasin - Problem.Temp.Tgasout
				If dt > 0 And Problem.PressGasIn > 0 Then
					Gas.Manuale = False
                    Res = Gas.Accedi(VB.Left(FileData, Len(FileData) - 4) & Funzioni.Str2Cifre(Altern - 1) & ".PPG", ff) 'MODIFICA
                    Gas.prPressione = Problem.PressGasIn
                    T2 = Int((Problem.Temp.Tgasin + 4.9) / 5) * 5
                    T1 = Int(Problem.Temp.Tgasout / 5) * 5
                    Gas.prTmin = T1
                    Gas.prTmax = T2
                    Gas.prTincr = 5
                    Gas.mostra(1, ff)
                    Problem.Fluido = ff
                Else
                    MsgBox("Prego fornire valori validi per la pressione e le temperature del gas", MsgBoxStyle.Critical)
                End If
            Case False
                Gas.Manuale = True
                Dim FormProp As frmProp = New frmProp
                FormProp.ShowDialog()
                FormProp.Dispose()
        End Select
        Prop.Inizia(True)
        Aggiorna()
        Label1(7).Visible = False
        txtDuty.Visible = False
        Label3(8).Visible = False
        Command3.Enabled = True
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        If Not ValidaFase() Then Exit Sub
        Fase = Fase + 1
        VisualizzaFase(Fase - 1)
        Command1.Enabled = Fase > 1
        Command2.Enabled = Fase < 4
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        If Problem.PressGasIn = 0 Or Problem.PressVapIn = 0 Then
            MsgBox("Non sono state definite le pressioni di lavoro")
            Exit Sub
        End If
        'Gas.Inizia
        Bilancio()
    End Sub

    Public Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click '/17/01/01
        Dim savProbl As typProblem
        Dim savGeom As typGeom
        Dim savU As Single
        Dim iErr As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        savProbl = Problem
        savGeom = Geom
        Problem.Rinside = 0 : Problem.Routside = 0
        IniziaCalcolo(iErr, True) '17/01/01
        If iErr = 1 Then
            Problem = savProbl
            Geom = savGeom
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("Problemi di convergenza", MsgBoxStyle.Critical)
            If Config.Progetto = 1 And Config.Tipo = 2 And Not Config.Nuovo Then
            Else
                MsgBox("Problemi di convergenza", MsgBoxStyle.Critical)
            End If
            Exit Sub
        ElseIf iErr >= 2 Then
            Exit Sub
        End If
        DropGas()
        DropVap()
        OverAll()
        Problem.Temp = Problem.Funz
        Aggiorna()
        savU = Problem.UAll
        Problem = savProbl
        Geom = savGeom
        Problem.UAllC = savU
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Apert_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If Fase = 0 And Not Gia Then
            VisualizzaFase(0)
            NuovoLav()
            Fase = 1
            Gia = True
        End If
    End Sub

    Private Sub Apert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '    ReDim Lav(0) As Identif ', DatiPrg(0) As DatiDes
        Dim c As System.Windows.Forms.TextBox
        TipoStr(1) = "1 passo"
        TipoStr(2) = "1 p.+zona cieca"
        TipoStr(3) = "2 passi"
        Prop = New Proprietà
        cmbInc.Items.Add("Progetto")
        cmbInc.Items.Add("Verifica")
        cmbVarDip.Items.Add("Portata gas  ")
        cmbVarDip.Items.Add("Portata vapore")
        cmbVarDip.Items.Add("Temp usc. gas")
        cmbVarDip.Items.Add("Temp usc. vap")
        For Each c In txtTemp.Values
            c.BackColor = System.Drawing.Color.White
        Next c
        VisualizzaFase(0)
        Standard.OverOTL = 15
        Standard.SpessCieco = 10
        Standard.Lane = 60
        Standard.SpessTuboCentrale = 10
        Standard.SpessFasciameExt = 5
    End Sub
    Private Sub Apert_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not Schiavo Then
            Monitor.Motore.Ammazza("SURR")
        Else
            Monitor.Motore.Ammazza("SCHI")
        End If
        Prop = Nothing
        Surr = Nothing
    End Sub
    Public Sub mnuFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuFile, eventSender)
        Dim Nome, Vecchia As String
        Dim Res As Integer
        Try
            Select Case Index
                Case 1 'apri
                    NuovoLav()
                Case 2 'salva
                    Salva()
                Case 3 'salva con nome
                    CommonDialog1Save.Filter = "(*.SUR)|*.SUR|"
                    CommonDialog1Save.InitialDirectory = Monitor.Motore.Inizio.Datidir
                    CommonDialog1Save.ShowDialog()
                    Nome = CommonDialog1Save.FileName
                    Vecchia = FileData
                    FileData = Nome
                    Salva()
                    Vecchia = VB.Left(Vecchia, Len(Vecchia) - 3) & "PPG"
                    If IO.File.Exists(Vecchia) Then FileCopy(Vecchia, VB.Left(FileData, Len(FileData) - 3) & "PPG")
                Case 4 'esci
                    Res = MsgBox("Vuoi salvare le modifiche effettuate?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                    If Res = MsgBoxResult.Cancel Then Exit Sub
                    If Res = MsgBoxResult.Yes Then Salva()
                    Me.Close()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Public Sub mnuPropaga_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPropaga.Click
        Propaga()
    End Sub
    Private Sub optAut_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optAut, eventSender)
            If Index = 1 Then
                nomeGas.Visible = False
                Config.Autom = False
            Else
                Config.Autom = True
                nomeGas.Visible = True
                Prop.Inizia(True)
            End If
        End If
    End Sub
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
            Geom.TipoPassoInt = Index
            CalcCieco()
        End If
    End Sub
    Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(Option2, eventSender)
            Geom.TipoPassoExt = Index
            CalcFasciame()
        End If
    End Sub
    Private Sub optRug_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optRug, eventSender)
            Problem.Smooth = Index = 0
        End If
    End Sub
    Private Sub txtDescr_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDescr.TextChanged
        If Inizializzando Then Exit Sub
        Config.DescrAlt = txtDescr.Text
    End Sub
    Private Sub txtTemp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtTemp, eventSender)
        Dim u As Short
        Dim d, l As Single
        Select Case Index
            Case 0 : Problem.Temp.Tgasin = Val(txtTemp(Index).Text)
            Case 1 : Problem.Temp.Tgasout = Val(txtTemp(Index).Text)
            Case 2 : Problem.Temp.Tvin = Val(txtTemp(Index).Text)
            Case 3 : Problem.Temp.Tvout = Val(txtTemp(Index).Text)
            Case 4 : Problem.PressGasIn = Val(txtTemp(Index).Text)
                Prop.Inizia(False)
            Case 5 : Problem.PressVapIn = Val(txtTemp(Index).Text)
                Prop.Inizia(False)
            Case 6 : Problem.Qgas = Val(txtTemp(Index).Text)
            Case 7 : Problem.Qvap = Val(txtTemp(Index).Text)
            Case 8 : Geom.DiamExtTubi = Val(txtTemp(Index).Text)
            Case 9 : Geom.SpessTubi = Val(txtTemp(Index).Text)
            Case 10 : Problem.VelVapMax = Val(txtTemp(Index).Text)
                CalcNumTubi()
            Case 11 : Geom.NumeroTubi = Val(txtTemp(Index).Text)
                CalcDiamInt()
            Case 12 : Problem.VelGasMaxCen = Val(txtTemp(Index).Text)
                CalcDiamInt()
            Case 13 : Geom.DiamCentrale = Val(txtTemp(Index).Text)
                CalcCieco()
            Case 14 : Geom.PassoTubiInt = Val(txtTemp(Index).Text)
                CalcCieco()
            Case 15 : Geom.DiamFasciameInt = Val(txtTemp(Index).Text)
                CalcDintermedio()
            Case 37 : Geom.OTLint = Val(txtTemp(Index).Text)
                CalcDintermedio()
            Case 16 : Problem.VelGasMaxCieco = Val(txtTemp(Index).Text)
                CalcDintermedio()
            Case 17 : Geom.ITLout = Val(txtTemp(Index).Text)
            Case 18 : Geom.PassoTubiExt = Val(txtTemp(Index).Text)
                CalcFasciame()
            Case 38 : Geom.OTLout = Val(txtTemp(Index).Text)
                CalcFasciame()
            Case 19 : Geom.DiamFasciameExt = Val(txtTemp(Index).Text)
                CalcMantello()
            Case 20 : Problem.Rinside = Val(txtTemp(Index).Text)
            Case 21 : Problem.Routside = Val(txtTemp(Index).Text)
            Case 22 : Geom.LungDiritta = Val(txtTemp(Index).Text) / 1000
                l = 2 * Geom.LungDiritta
                If Config.Tipo = 2 Then l = l - Geom.LungCieca
                Geom.Area = PI * Geom.DiamExtTubi * Geom.NumeroTubi / 1000 * l
                txtTemp(63).Text = Funzioni.myStr(Geom.Area, 4, 2, False)
            Case 23 : Geom.LungCieca = Val(txtTemp(Index).Text) / 1000
            Case 25 : Geom.DropVap = Val(txtTemp(Index).Text) * 100
            Case 26 : Geom.DropGas = Val(txtTemp(Index).Text) * 100
            Case 33 : Geom.ITLint = Val(txtTemp(Index).Text)
                CalcCieco()
            Case 34 : Problem.UAll = Val(txtTemp(Index).Text)
            Case 39 : Geom.DiamMantello = Val(txtTemp(Index).Text)
            Case 40 : Problem.dpAllGas = Val(txtTemp(Index).Text) * 100
            Case 44 : Problem.dpAllVap = Val(txtTemp(Index).Text) * 100
            Case 41 : DesignData.PShell = Val(txtTemp(Index).Text)
            Case 42 : DesignData.PTubi = Val(txtTemp(Index).Text)
            Case 43 : DesignData.PTS = Val(txtTemp(Index).Text)
            Case 45 : DesignData.PCassa = Val(txtTemp(Index).Text)
            Case 46 : DesignData.TShell = Val(txtTemp(Index).Text)
            Case 47 : DesignData.TTubi = Val(txtTemp(Index).Text)
            Case 48 : DesignData.TTS = Val(txtTemp(Index).Text)
            Case 49 : DesignData.TCassa = Val(txtTemp(Index).Text)
            Case 50 : DesignData.cShell = Val(txtTemp(Index).Text)
            Case 51 : DesignData.cTubi = Val(txtTemp(Index).Text)
            Case 52 : DesignData.cTS = Val(txtTemp(Index).Text)
            Case 53 : DesignData.cCassa = Val(txtTemp(Index).Text)
            Case 54 : Geom.SteamInlet = Val(txtTemp(Index).Text)
            Case 55 : Geom.SteamOutlet = Val(txtTemp(Index).Text)
            Case 56 : Geom.GasOutlet = Val(txtTemp(Index).Text)
            Case 57 : u = Val(txtTemp(Index).Text)
                If u > 0 Then
                    d = 1000 * System.Math.Sqrt(4 / PI * Surr.PortLT / u * Prop.VolVap((Surr.TempLTf)))
                    txtTemp(54).Text = Funzioni.myStr(d, 4, 2, False)
                End If
            Case 58 : u = Val(txtTemp(Index).Text)
                If u > 0 Then
                    d = 1000 * System.Math.Sqrt(4 / PI * Surr.PortLT / u * Prop.VolVap((Surr.TempLTc)))
                    txtTemp(55).Text = Funzioni.myStr(d, 4, 2, False)
                End If
            Case 59 : u = Val(txtTemp(Index).Text)
                If u > 0 Then
                    d = 1000 * System.Math.Sqrt(4 / PI * (Surr.PortLM / u * Prop.VolGas((Surr.TempLMf)) + PI * (Geom.FiValv / 1000) ^ 2 / 4))
                    txtTemp(56).Text = Funzioni.myStr(d, 4, 2, False)
                End If
            Case 61 : Problem.kLow = Val(txtTemp(Index).Text)
            Case 62 : Problem.kHigh = Val(txtTemp(Index).Text)
            Case 64 : Geom.FiValv = Val(txtTemp(Index).Text)
            Case 65 : Geom.AreaForiValv = Val(txtTemp(Index).Text)
            Case 66 : Problem.QminReg = Val(txtTemp(Index).Text)
        End Select
        If Fase = 1 Then
            Label1(7).Visible = False
            txtDuty.Visible = False
            Label3(8).Visible = False
            If Config.Progetto = 0 Then Command2.Enabled = False
        End If
    End Sub
    Public Sub Aggiorna()
        If Problem.FluidiInvertiti Then chkInvert.CheckState = System.Windows.Forms.CheckState.Checked Else chkInvert.CheckState = System.Windows.Forms.CheckState.Unchecked
        nomeGas.Text = Problem.Fluido
        With Config
            If .Progetto > 1 Or .Progetto < 0 Then .Progetto = 1
            cmbInc.SelectedIndex = .Progetto
            If .Nuovo Then chkCross.CheckState = System.Windows.Forms.CheckState.Checked Else chkCross.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .VariabIndProg <= 0 Or .VariabIndProg > 2 Then .VariabIndProg = 1
            cmbVarDip.SelectedIndex = .VariabIndProg - 1
        End With
        txtTemp(0).Text = Funzioni.myStr(Problem.Temp.Tgasin, 4, 2, False)
        txtTemp(1).Text = Funzioni.myStr(Problem.Temp.Tgasout, 4, 2, False)
        txtTemp(2).Text = Funzioni.myStr(Problem.Temp.Tvin, 4, 2, False)
        txtTemp(3).Text = Funzioni.myStr(Problem.Temp.Tvout, 4, 2, False)
        txtTemp(4).Text = Funzioni.myStr(Problem.PressGasIn, 4, 2, False)
        txtTemp(5).Text = Funzioni.myStr(Problem.PressVapIn, 4, 2, False)
        txtTemp(6).Text = Funzioni.myStr(Problem.Qgas, 4, 2, False)
        txtTemp(7).Text = Funzioni.myStr(Problem.Qvap, 4, 2, False)
        If Fase = 3 Then
            txtTemp(8).Text = Funzioni.myStr(Geom.DiamExtTubi, 4, 2, False)
            txtTemp(9).Text = Funzioni.myStr(Geom.SpessTubi, 4, 2, False)
            txtTemp(10).Text = Funzioni.myStr(Problem.VelVapMax, 4, 2, False)
            txtTemp(11).Text = Funzioni.myStr(Geom.NumeroTubi, 4, 0, True)
            txtTemp(12).Text = Funzioni.myStr(Problem.VelGasMaxCen, 4, 2, False)
            txtTemp(13).Text = Funzioni.myStr(Geom.DiamCentrale, 4, 2, False)
            txtTemp(14).Text = Funzioni.myStr(Geom.PassoTubiInt, 4, 2, False)
            txtTemp(15).Text = Funzioni.myStr(Geom.DiamFasciameInt, 4, 2, False)
            txtTemp(16).Text = Funzioni.myStr(Problem.VelGasMaxCieco, 4, 2, False)
            txtTemp(17).Text = Funzioni.myStr(Geom.ITLout, 4, 2, False)
            txtTemp(18).Text = Funzioni.myStr(Geom.PassoTubiExt, 4, 2, False)
            txtTemp(19).Text = Funzioni.myStr(Geom.DiamFasciameExt, 4, 2, False)
            txtTemp(33).Text = Funzioni.myStr(Geom.ITLint, 4, 2, False)
            txtTemp(37).Text = Funzioni.myStr(Geom.OTLint, 4, 2, False)
            txtTemp(38).Text = Funzioni.myStr(Geom.OTLout, 4, 2, False)
            txtTemp(39).Text = Funzioni.myStr(Geom.DiamMantello, 4, 2, False)
        End If
        txtTemp(20).Text = Funzioni.myStr(Problem.Rinside, 1, 6, False)
        txtTemp(21).Text = Funzioni.myStr(Problem.Routside, 1, 6, False)
        txtTemp(22).Text = Funzioni.myStr(Geom.LungDiritta * 1000, 5, 2, False)
        txtTemp(23).Text = Funzioni.myStr(Geom.LungCieca * 1000, 5, 2, False)
        txtTemp(25).Text = Funzioni.myStr(Geom.DropVap / 100, 4, 2, False)
        If Geom.DropVap > Problem.dpAllVap Then
            txtTemp(25).BackColor = System.Drawing.Color.Red
        Else
            txtTemp(25).BackColor = System.Drawing.Color.White
        End If
        txtTemp(26).Text = Funzioni.myStr(Geom.DropGas / 100, 4, 2, False)
        If Geom.DropGas > Problem.dpAllGas Then
            txtTemp(26).BackColor = System.Drawing.Color.Red
        Else
            txtTemp(26).BackColor = System.Drawing.Color.White
        End If
        txtTemp(34).Text = Funzioni.myStr(Problem.UAll, 5, 2, False)
        If Fase = 2 Then
            txtTemp(40).Text = Funzioni.myStr(Problem.dpAllGas / 100, 4, 2, False)
            txtTemp(44).Text = Funzioni.myStr(Problem.dpAllVap / 100, 4, 2, False)
            txtTemp(41).Text = Funzioni.myStr(DesignData.PShell, 3, 2, False)
            txtTemp(42).Text = Funzioni.myStr(DesignData.PTubi, 3, 2, False)
            txtTemp(43).Text = Funzioni.myStr(DesignData.PTS, 3, 2, False)
            txtTemp(45).Text = Funzioni.myStr(DesignData.PCassa, 3, 2, False)
            txtTemp(46).Text = Funzioni.myStr(DesignData.TShell, 3, 2, False)
            txtTemp(47).Text = Funzioni.myStr(DesignData.TTubi, 3, 2, False)
            txtTemp(48).Text = Funzioni.myStr(DesignData.TTS, 3, 2, False)
            txtTemp(49).Text = Funzioni.myStr(DesignData.TCassa, 3, 2, False)
            txtTemp(50).Text = Funzioni.myStr(DesignData.cShell, 2, 3, False)
            txtTemp(51).Text = Funzioni.myStr(DesignData.cTubi, 2, 3, False)
            txtTemp(52).Text = Funzioni.myStr(DesignData.cTS, 2, 3, False)
            txtTemp(53).Text = Funzioni.myStr(DesignData.cCassa, 2, 3, False)
            txtTemp(54).Text = Funzioni.myStr(Geom.SteamInlet, 3, 2, False)
            txtTemp(55).Text = Funzioni.myStr(Geom.SteamOutlet, 3, 2, False)
            txtTemp(56).Text = Funzioni.myStr(Geom.GasOutlet, 3, 2, False)
            txtTemp(60).Text = MatTubi.MatStr
            txtTemp(61).Text = Funzioni.myStr(Problem.kLow, 3, 2, False)
            txtTemp(62).Text = Funzioni.myStr(Problem.kHigh, 3, 2, False)
            txtTemp(63).Text = Funzioni.myStr(Geom.Area, 4, 2, False)
            txtTemp(64).Text = Funzioni.myStr(Geom.FiValv, 4, 1, False)
            txtTemp(65).Text = Funzioni.myStr(Geom.AreaForiValv, 2, 3, False)
            If Problem.QminReg > 100 Or Problem.QminReg < 0 Then Problem.QminReg = 0
            txtTemp(66).Text = Funzioni.myStr(Problem.QminReg, 3, 2, False)
		End If
		On Error GoTo ErrAgg
		Option1(Geom.TipoPassoInt).Checked = True
		Option2(Geom.TipoPassoExt).Checked = True
		On Error GoTo 0
		If Config.Autom Then optAut(0).Checked = True Else optAut(1).Checked = True
		If Problem.Smooth Then optRug(0).Checked = True Else optRug(1).Checked = True
        If Config.Tipo = 0 Then Config.Tipo = 1
		txtTipo.Text = TipoStr(Config.Tipo)
		GestisciIncroci()
ExAgg: Exit Sub
ErrAgg: MsgBox("Il file di input non è valido", MsgBoxStyle.Critical)
		Resume 
	End Sub
	
	Private Sub NuovoLav()
		With Monitor.Motore
            If Not Schiavo Then .Mostra(myAssembly)
			If Not Schiavo And Len(Trim(.Problem.Commessa)) = 0 Then
				Frames(1).Visible = False
				'   Command1.Visible = False
				Command2.Visible = False
			Else
				Frames(1).Visible = True
				'   Command1.Visible = True
				Command2.Visible = True
				Prop.Inizia(False)
				Aggiorna()
			End If
		End With
	End Sub
	
	Private Sub VisualizzaFase(ByRef fp As Short)
		Dim f As System.Windows.Forms.GroupBox
		Dim i As Short
		Dim Log1 As Boolean
		Dim Log2 As Boolean
		Select Case Fase
			Case 0
				For	Each f In Frames.Values : f.Visible = False : Next f
				Frames(1).Visible = True
                Frames(1).Top = 26
				Command1.Enabled = False
			Case 1 'Bilancio
				For	Each f In Frames.Values : f.Visible = False : Next f
				Frames(Fase).Visible = True
                Frames(Fase).Top = 26
			Case 2
				Frames(fp).Visible = False
				Frames(Fase).Visible = True
                Frames(Fase).Top = 26
				DesTemp()
				Label3(48).Text = "@" & Str(Int(Problem.Temp.Tgasin)) & " °C"
				Label3(47).Text = "@" & Str(Int(Problem.Temp.Tvout)) & " °C"
				Aggiorna()
			Case 3 'Scelta numero di tubi e geometria radiale
				Frames(fp).Visible = False
				Frames(Fase).Visible = True
                Frames(Fase).Top = 26
				Label1(12).Text = "Velocità max gas nel varco centrale"
				Label1(13).Text = "Diam. varco centrale"
				Label1(15).Text = "Diam. int. tubo accecante"
				Label1(17).Text = "Vel. max gas all'esterno del tubo cieco"
				Select Case Config.Tipo
					Case 2 'con cieco
						Label1(15).Visible = True
						txtTemp(15).Visible = True
						Label3(15).Visible = True
					Case 1 '1 passo
						Label1(15).Visible = False
						txtTemp(15).Visible = False
						Label3(15).Visible = False
					Case 3 '2 passi
						Label1(12).Text = "Velocità max gas nel tubo centrale"
						Label1(13).Text = "Diam. tubo centrale"
						Label1(15).Text = "Diam. int. tubo intermedio"
						Label1(15).Visible = True
						txtTemp(15).Visible = True
						Label3(15).Visible = True
						Label1(17).Text = "Vel. max gas lambente il tubo intermedio"
				End Select
				Log1 = Config.Progetto = 0
				Log2 = Log1 And Config.Tipo > 1
				Label1(17).Visible = Log2
				txtTemp(16).Visible = Log2
				Label3(16).Visible = Log2
				Label1(12).Visible = Log1
				txtTemp(12).Visible = Log1
				Label3(12).Visible = Log1
				Aggiorna()
			Case 4 'calcolo di progetto
				Frames(fp).Visible = False
				Frames(Fase).Visible = True
                Frames(Fase).Top = 26
				Select Case Config.Tipo
					Case 2
						Label1(26).Visible = True
						txtTemp(24).Visible = True
						Label3(24).Visible = True
						Label1(25).Visible = True
						txtTemp(23).Visible = True
						Label3(23).Visible = True
					Case 1, 3
						Label1(26).Visible = False
						txtTemp(24).Visible = False
						Label3(24).Visible = False
						Label1(25).Visible = False
						txtTemp(23).Visible = False
						Label3(23).Visible = False
				End Select
				For i = 27 To 32
					txtTemp(i).Visible = Config.Progetto = 1
					Label1(i + 2).Visible = Config.Progetto = 1
					Label3(i).Visible = Config.Progetto = 1
				Next 
		End Select
	End Sub
	
	Private Sub GestisciIncroci()
		If Config.Tipo = 2 And Config.Progetto = 0 Then
			chkCross.CheckState = System.Windows.Forms.CheckState.Unchecked
			chkCross.Enabled = False
		Else
			chkCross.Enabled = True
		End If
	End Sub
	Public Sub AggAltern()
		Dim i, n As Short
		cmbAltern.Items.Clear()
		n = nAlt : If n = 0 Then n = 1
		For i = 1 To n
			cmbAltern.Items.Add(Str(i))
		Next 
		cmbAltern.Items.Add("Nuova")
	End Sub
	Public Sub NuovAltern()
		Apri(1)
		nAlt = nAlt + 1
		Altern = nAlt
		Salva()
	End Sub
End Class