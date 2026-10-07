Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmApert
	Inherits System.Windows.Forms.Form
	Private z1 As Short
    Private Bianco As Color
    Private Gialli As New Collection
    Private Inizializzando As Boolean
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(Check1, eventSender)
        Select Case Index
            Case 0 : ProblWLD.precEntalp = Check1(Index).CheckState = 1
            Case 1 : ProblWLD.precEntrop = Check1(Index).CheckState = 1
        End Select
    End Sub
    Private Sub Check2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(Check2, eventSender)
        Select Case Index
            Case 0 : If Check2(Index).CheckState = 1 Then ProblWLD.Tequi = 0 Else ProblWLD.Tequi = 1
            Case 1 : If Check2(Index).CheckState = 1 Then ProblWLD.Pequi = 0 Else ProblWLD.Pequi = 1
        End Select
        Label2(10).Visible = ProblWLD.Tequi = 0
        Text1(10).Visible = ProblWLD.Tequi = 0
        Label3(9).Visible = ProblWLD.Tequi = 0
        Label2(11).Visible = ProblWLD.Pequi = 0
        Text1(11).Visible = ProblWLD.Pequi = 0
        Label3(10).Visible = ProblWLD.Pequi = 0
        cmdPunti.Visible = (ProblWLD.Tequi = 1 Or ProblWLD.Pequi = 1)
    End Sub
	Private Sub cmbInteraz_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbInteraz.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        ProblWLD.iSetCost = cmbInteraz.SelectedIndex
    End Sub
	Private Sub cmbPrecis_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPrecis.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        ProblWLD.iPrecis = cmbPrecis.SelectedIndex
    End Sub
	Private Sub cmbTipCalc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipCalc.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Monitor.Ogg.TipCalc = cmbTipCalc.SelectedIndex + 1
    End Sub
	Private Sub cmbTrasf_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTrasf.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim ifl As Short
        Dim c As System.Windows.Forms.ComboBox
        Dim i As Short
        Label1(2).Text = "Variabili"
        AzzeraRisultati()
        With ProblWLD
            .X = cmbTrasf.SelectedIndex + 1
            ifl = FreeFile()
            cmbVariab.Visible = True
            Label1(2).Visible = True
            cmbZ.Visible = False
            Label1(3).Visible = False
            c = cmbVariab
            lstDiagn.Items.Clear()
            frmoptions(9).Visible = False
            Dim FileDati As String
            Select Case .X
                Case 1, 2 'Bubble dew
                    '    OPEN Archdir + "\ARCK02.DAT" FOR INPUT AS #4
                    .Variab(0) = 100
                    FileDati = rmHelpStrings.GetString("Bubbledew")
                    If Not ApriFile(FileDati, ifl) Then Exit Sub
                    Call Req(c, ifl)
                    FileClose(ifl)
                    If .Y = 0 Then .Y = 1
                    cmbVariab.SelectedIndex = .Y - 1
                    ' y = Quale%(ic, "Variabili", Stringa(), "Help non disponibile", 0)
                    ' If y < 1 Then GoTo Fine
                Case 3, 4 'Flash T,fraz /Flash P,fraz
                    '    OPEN Archdir + "\ARCK03.DAT" FOR INPUT AS #4
                    FileDati = rmHelpStrings.GetString("Flashfraz")
                    If Not ApriFile(FileDati, ifl) Then Exit Sub
                    Call Req(c, ifl)
                    FileClose(ifl)
                    If .Y = 0 Then .Y = 1
                    cmbVariab.SelectedIndex = .Y - 1
                    ' y = Quale%(ic, "Variabili", Stringa(), "Help non disponibile", 0)
                    ' If y < 1 Then GoTo Fine
                Case 5 'Flash T,P
                    Label1(2).Visible = False
                    cmbVariab.Visible = False
                    .iCode = 7 : .iV1 = 1 : .iV2 = 2
                    Inizializza()
                    Variabili(1)
                    Variabili(2)
                Case 6 'Flash
                    '    OPEN Archdir + "\ARCK04.DAT" FOR INPUT AS #4
                    FileDati = rmHelpStrings.GetString("Flash")
                    If Not ApriFile(FileDati, ifl) Then Exit Sub
                    Call Req(c, ifl)
                    FileClose(ifl)
                    Label1(2).Text = "Primo dato"
                    If .Y = 0 Then .Y = 1
                    If .Y > 3 Then .Y = 1
                    cmbVariab.SelectedIndex = .Y - 1
                    'y = Quale%(ic, "Primo dato", Stringa(), "Help non disponibile", 0)
                    'If y < 1 Then GoTo Fine
                    '    File1$ = Archdir + "\ARCK0" + RIGHT$(STR$(4 + y), 1) + ".DAT"
                    '    Z = Quale%(ic, "Variabili", Stringa(), "Help non disponibile", 0)
                    ' Z = Quale%(ic, FF$(13), Stringa(), FF$(14), 0)
                    ' If Z < 1 Then GoTo Fine
                    '  Case 7: ' ProblWLD.icode = 25 'P=f(H,T) o T=f(H,P) per liquidi
                    ' Label1(2).Visible = False
                    ' cmbVariab.Visible = False
                    ' ProblWLD.iV1 = 6: ProblWLD.iV2 = 9
                    '  Case 8: ' ProblWLD.icode = 26 'P=f(H,T) per gas
                    ' Label1(2).Visible = False
                    ' cmbVariab.Visible = False
                    ' ProblWLD.iV1 = 7: ProblWLD.iV2 = 9
                    '  Case 9, 10: 'Propr td
                    '      Stringa(1) = "H e T dati,P incognita"
                    '      Stringa(2) = "H e P dati,T incognita"
                    '      Stringa(3) = "S e T dati,P incognita"
                    '      Stringa(4) = "S e P dati,T incognita"
                    '       For i = 1 To 4: Stringa(i) = FF$(14 + i): Next
                    '      y = Quale%(4, "Variabili", Stringa(), "Help non disponibile", 0)
                    '      cmbVariab.Clear
                    '      For i = 1 To 4
                    '         cmbVariab.AddItem FF(14 + i)
                    '      Next
                    ''      y = Quale%(4, FF$(13), Stringa(), FF$(14), 0)
                    ''      If y < 1 Then GoTo Fine
                    '  Case 11, 12: 'proprietà di miscela liquida, di miscela vapore
                    '      frmOptions(9).Visible = False
                    '      Label1(2).Visible = False
                    '      cmbVariab.Visible = False
                    '      Label2(0).Visible = False
                    '      Text1(0).Visible = False
                    '      Label3(0).Visible = False
                    '      Check1(0).Visible = False
                    '      Check1(1).Visible = False
                    '      Text1(0) = "100"
                    '      For i = 1 To 2
                    '         Label2(i).Visible = True
                    '         Text1(i).Visible = True
                    '         Label3(i).Visible = True
                    '      Next
                    '      For i = 3 To 8
                    '         Label2(i).Visible = False
                    '         Text1(i).Visible = False
                    '         Label3(i).Visible = False
                    '         Text1(i) = "0"
                    '      Next
                    '      .iCode = 32 + .X - 8
                    '      .iV1 = 1: .iV2 = 2
                    '  Case 11, 12: 'heating curve cooling curve
                Case 7, 8 'heating curve cooling curve
                    Label2(2).Visible = True
                    For i = 0 To 8
                        Label2(i).Visible = (i = 1 Or i = 2)
                        Text1(i).Visible = (i = 1 Or i = 2)
                        Label3(i).Visible = (i = 1 Or i = 2)
                        If Not (i = 1 Or i = 2) Then Text1(i).Text = "0"
                    Next
                    Check1(0).Visible = False
                    Check1(1).Visible = False
                    Label1(2).Visible = False
                    cmbVariab.Visible = False
                    frmoptions(9).Visible = True
                    .iCode = 34 + .X - 10 + 4
                    .iV1 = 1 : .iV2 = 2
                    Aggiorna9()
                Case 9, 10 'proprietà
                    Label2(2).Visible = True
                    For i = 0 To 8
                        Label2(i).Visible = (i = 1 Or i = 2)
                        Text1(i).Visible = (i = 1 Or i = 2)
                        Label3(i).Visible = (i = 1 Or i = 2)
                        If i > 2 Then Text1(i).Text = "0"
                    Next
                    Text1(2 + .X - 8).Text = "1"
                    Check1(0).Visible = False
                    Check1(1).Visible = False
                    Label1(2).Visible = False
                    cmbVariab.Visible = False
                    frmoptions(9).Visible = False
                    .iCode = 34 + .X - 10
                    .iV1 = 1 : .iV2 = 2
                    '      Aggiorna9
            End Select
        End With
    End Sub
    Sub Req(ByVal c As System.Windows.Forms.ComboBox, ByVal ifl As Short)
        Dim Riga As String
        c.Items.Clear()
        Do
            Riga = LineInput(ifl)
            'If ProblWLD.x < 3 And c.ListCount = 2 Then Exit Do
            If EOF(ifl) Then Exit Do
            c.Items.Add(Riga)
        Loop
    End Sub
    Private Sub cmbVariab_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbVariab.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim c As System.Windows.Forms.ComboBox
        Dim ifl As Short
        Dim FileDati As String
        cmdProcedi.Enabled = True
        cmdRapp.Enabled = True
        AzzeraRisultati()
        AggAcqua()
        With ProblWLD
            .X = cmbTrasf.SelectedIndex + 1
            .Y = cmbVariab.SelectedIndex + 1
            Inizializza()
            Select Case .X
                Case 1, 2
                    frmoptions(9).Visible = False
                    Check1(0).Visible = False
                    Check1(1).Visible = False
                    .iV2 = 0
                    Select Case .Y
                        Case 1 : .iCode = .X : .iV1 = 1
                            Variabili(1)
                        Case 2 : .iCode = 3 + .X : .iV1 = 2
                            Variabili(2)
                        Case 3 : .iCode = 7 + .X : .iV1 = 6
                            Variabili(6)
                        Case 4 : .iCode = 12 + .X : .iV1 = 7
                            Variabili(8)
                        Case 5 : .iCode = 17 + .X : .iV1 = 9
                            cmdProcedi.Enabled = False
                            cmdRapp.Enabled = False
                            MostraAiuto(IDH_SPECNONIMPL)
                    End Select
                Case 3, 4
                    .iCode = .X : .ABC = Chr(64 + .Y)
                    frmoptions(9).Visible = False
                    Check1(0).Visible = False
                    Check1(1).Visible = False
                    Variabili(.X - 2)
                    .iV2 = 0
                    Select Case .Y
                        Case 1 : .iV1 = 3
                        Case 2 : .iV1 = 5
                            If Not AcquaPresente Then
                                MostraAiuto(IDH_NONACQUA, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessOkOnly)
                                .iV1 = 4
                            End If
                        Case 3 : .iV1 = 4
                    End Select
                    Variabili(.iV1)
                    If .X = 4 Then .iCode = 6
                Case 6
                    Select Case .Y
                        Case 1 : .iV1 = 6
                        Case 2 : .iV1 = 8
                        Case 3 : .iV1 = 9
                            cmdProcedi.Enabled = False
                            cmdRapp.Enabled = False
                            MostraAiuto(IDH_SPECNONIMPL)
                            Exit Sub
                    End Select
                    Variabili(.iV1)
                    cmbZ.Visible = True
                    Label1(3).Visible = True
                    Label1(3).Text = "Secondo dato"
                    ifl = FreeFile()
                    FileDati = rmHelpStrings.GetString("Arck10")
                    If Not ApriFile(FileDati, ifl) Then Exit Sub
                    c = cmbZ
                    Call Req(c, ifl)
                    FileClose(ifl)
                    If .Z = 0 Then .Z = 1
                    cmbZ.SelectedIndex = .Z - 1
                Case 9, 10
                    Select Case .Y
                        Case 1 : .iV1 = 6 : .iV2 = 1
                        Case 2 : .iV1 = 6 : .iV2 = 2
                        Case 3 : .iV1 = 7 : .iV2 = 1
                        Case 4 : .iV1 = 7 : .iV2 = 2
                    End Select
                    .iCode = 24 + 2 * .Y + .X - 2 + 4
            End Select
        End With
    End Sub
    Private Sub cmbZ_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbZ.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim Z As Short
        AzzeraRisultati()
        Inizializza()
        With ProblWLD
            Variabili(.iV1)
            .Z = cmbZ.SelectedIndex + 1
            'Y = cmbTrasf.ListIndex + 1
            Select Case .Z
                Case 1 : .iV2 = 1
                Case 2 : .iV2 = 2
                Case 3 : .iV2 = 3
                Case 4 : .iV2 = 5
                Case 5 : .iV2 = 4
            End Select
            Variabili(.iV2)
            z1 = .Z
            If z1 > 3 Then
                z1 = 3
            Else
                ProblWLD.ABC = Chr(64 + Z - 2)
            End If
            Select Case .Y
                Case 1 : .iCode = 9 + z1
                Case 2 : .iCode = 14 + z1
                Case 3 : .iCode = 19 + z1
            End Select
        End With
    End Sub
	
	Private Sub cmdFine_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFine.Click
		Hide()
	End Sub
	
	Private Sub cmdLista_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLista.Click
		Dim n, i As Short
		Dim Tit(1) As String
		Dim Archiv(100) As Short
		Dim dAiu(100) As String
        Dim Risp(100) As String
		Tit(0) = "Frazioni molari"
		Tit(1) = "Frazioni ponderali"
		n = NomiComponenti.Count()
		For i = 1 To n
            Nomi(i) = NomiComponenti.Item(i)
		Next 
		With ProblWLD
			If Not Monitor.Motore.CheckQuale(n, "Scelta componenti", Nomi, .SceltaComponenti, "") Then Exit Sub
			.Ncom = 0
			For i = 1 To n
				If .SceltaComponenti(i) Then
					.Ncom = .Ncom + 1
					.Sceltaf(.Ncom) = i
					'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto NomiComponenti(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Nomi(.Ncom) = NomiComponenti.Item(i)
				End If
			Next 
			If .Ncom > 50 Then
				Stop
			End If
			For i = 1 To .Ncom - 1
				If .Sceltaf(i) = 72 Then
                    Funzioni.SWAP(.Sceltaf(i), .Sceltaf(.Ncom))
                    Funzioni.SWAP(Nomi(i), Nomi(.Ncom))
                End If
            Next
            For i = 1 To .Ncom
                Risp(i) = Funzioni.myStr(.Compos(i), 3, 2, False)
            Next
            If Not Monitor.Motore.InputDati(.Ncom, Tit(.iPond), Nomi, Risp, "", Archiv, dAiu) Then Exit Sub
            For i = 1 To .Ncom
                .Compos(i) = Val(Risp(i))
            Next
        End With
        AggAcqua()
    End Sub

    Private Sub cmdProcedi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProcedi.Click
        Dim File1 As String = ""
        If ProblWLD.iCode = 35 Or ProblWLD.iCode = 36 Then Ridimensiona()
        Select Case Monitor.Ogg.TipCalc
            Case 1 : Manuale(File1)
                '       Ripet1 File1
            Case 2 : Retri()
            Case 3 : Lancia()
        End Select
        cmdRapp.Enabled = True
    End Sub

    Private Sub cmdPunti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPunti.Click
        Dim Strin() As String
        Dim RispT() As String
        Dim RispP() As String
        Dim Archiv() As Short
        Dim dAiu() As String
        Dim Nfin, i As Short
        If ProblWLD.Npun < 2 Then
            MsgBox("Il numero di punti deve essere non minore di due", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Ridimensiona()
        ReDim Strin(ProblWLD.Npun)
        ReDim RispT(ProblWLD.Npun)
        ReDim RispP(ProblWLD.Npun)
        ReDim Archiv(ProblWLD.Npun)
        ReDim dAiu(ProblWLD.Npun)
        FaseDati = 1
        Enabled = False '   Hide
        If ProblWLD.Tequi = 1 Then
            Nfin = Nfin + 1
            For i = 1 To ProblWLD.Npun - 1
                Strin(i) = "Punto n°" & Str(i + 1) & " [" & Trim(Label3(1).Text) & "]"
                RispT(i) = Funzioni.myStr(Tpun(i + 1), 3, 2, False)
            Next
            Monitor.Motore.InputDatiM(Nfin, ProblWLD.Npun - 1, "Temperature", Strin, RispT, RadiceHelp & "::/AssegnazPunti.htm", Archiv, dAiu)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputForms().Top. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.InputForms.Item(1).Top = 0
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputForms().Left. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.InputForms.Item(1).Left = 0
        End If
        If ProblWLD.Pequi = 1 Then
            Nfin = Nfin + 1
            For i = 1 To ProblWLD.Npun - 1
                Strin(i) = "Punto n°" & Str(i + 1) & " [" & Trim(Label3(2).Text) & "]"
                RispP(i) = Funzioni.myStr(Ppun(i + 1), 3, 2, False)
            Next
            Monitor.Motore.InputDatiM(Nfin, ProblWLD.Npun - 1, "Pressioni", Strin, RispP, RadiceHelp & "::/AssegnazPunti.htm", Archiv, dAiu)
            If Nfin = 1 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputForms().Top. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Monitor.Motore.InputForms.Item(1).Top = 0
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputForms().Left. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Monitor.Motore.InputForms.Item(1).Left = 0
            End If
        End If
    End Sub

    Private Sub cmdRapp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRapp.Click
        Rapporto(0)
    End Sub
    Private Sub frmApert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        RadiceHelp = Monitor.Motore.Inizio.AppLancio & "\BIN\AiutoWald.chm"
        Bianco = Text1(0).BackColor
        Carica()
    End Sub
    Public Sub mnuFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnufile, eventSender)
        Dim icome As String = ""
        Select Case Index
            Case 1
                Picture1.Visible = True
                CaricaFile(icome, ".WLD")
                Monitor.Motore.Problem.Commessa = icome
                If Len(icome) = 0 Then Exit Sub
                Inizializza()
                Leggi()
                Picture1.Visible = False
                cmdProcedi.Enabled = True
                cmdRapp.Enabled = True
            Case 2
                Scrivi()
            Case 3
                Monitor.Motore.Problem.Commessa = ""
                Picture1.Visible = True
                cmdProcedi.Enabled = False
                cmdRapp.Enabled = False
            Case 4
                Hide()
            Case 6
                StampaLibrerie()
        End Select
    End Sub

    Public Sub mnuPref_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuPref, eventSender)
        Select Case Index
            Case 0
                mnuPref(0).Checked = Not mnuPref(0).Checked
                If mnuPref(0).Checked Then ProblWLD.iStLib = 1 Else ProblWLD.iStLib = 0
        End Select
    End Sub

    Public Sub mnuWald_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWald.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub

    'UPGRADE_WARNING: L'evento optAbs.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optAbs_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optAbs, eventSender)
            AzzeraRisultati()
            With ProblWLD
                If .iUnit = 1 Then
                    .Variab(2) = .Variab(2) + CShort(1.0#) * CShort(0.5 + CShort(Index = 1)) * -2
                Else
                    .Variab(2) = .Variab(2) + CShort(14.7) * CShort(0.5 + CShort(Index = 1)) * -2
                End If
                .iAbs = Index
            End With
            AggUnit()
            AggTesti()
        End If
    End Sub

    'UPGRADE_WARNING: L'evento optAcq.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optAcq_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optAcq, eventSender)
            AzzeraRisultati()
            ProblWLD.iAcqua = Index + 1
        End If
    End Sub

    'UPGRADE_WARNING: L'evento optCost.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optCost_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optCost, eventSender)
            AzzeraRisultati()
            ProblWLD.iEquil = Index + 1
            AggCostanti()
        End If
    End Sub

    'UPGRADE_WARNING: L'evento optCrit.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optCrit_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optCrit, eventSender)
            AzzeraRisultati()
            ProblWLD.iCost = Index + 1
        End If
    End Sub

    'UPGRADE_WARNING: L'evento optHC.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optHC_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optHC, eventSender)
            AzzeraRisultati()
            ProblWLD.iHc = Index + 1
        End If
    End Sub

    'UPGRADE_WARNING: L'evento optId.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optId_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optId, eventSender)
            AzzeraRisultati()
            ProblWLD.iIdeal = Index + 1
        End If
    End Sub

    'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
            AzzeraRisultati()
            ProblWLD.iUnit = Index + 1
            AggUnit()
        End If
    End Sub

    'UPGRADE_WARNING: L'evento optPort.CheckedChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optPort_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optPort, eventSender)
            ProblWLD.iPond = Index
            AzzeraRisultati()
            AggUnit()
        End If
    End Sub

    Public Sub AggUnit()
        Select Case ProblWLD.iUnit
            Case 1 'metriche
                Select Case ProblWLD.iPond
                    Case 0 'molare
                        Label3(0).Text = "kg-mol/s"
                    Case 1 'ponderale
                        Label3(0).Text = "kg/s"
                End Select
                Label3(1).Text = "°C"
                Label3(9).Text = "°C"
                Select Case ProblWLD.iAbs
                    Case 0 'rel
                        Label3(2).Text = "ate"
                        Label3(10).Text = "ate"
                    Case 1 'abs
                        Label3(2).Text = "ata"
                        Label3(10).Text = "ata"
                End Select
                Select Case ProblWLD.iPond
                    Case 0
                        Label3(6).Text = "Cal/mol"
                        Label3(8).Text = "Cal/mol°C"
                    Case 1
                        Label3(6).Text = "Cal/kg"
                        Label3(8).Text = "Cal/kg°C"
                End Select
                Label3(7).Text = "Cal"
                Label3(14).Text = "m3/kg"
                Label3(20).Text = "m3/kg"
                Label3(13).Text = "kg/m3"
                Label3(19).Text = "kg/m3"
                Label3(12).Text = "cp"
                Label3(18).Text = "cp"
            Case 2 'British
                Select Case ProblWLD.iPond
                    Case 1 'molare
                        Label3(0).Text = "lb-mol"
                    Case 2 'ponderale
                        Label3(0).Text = "lb"
                End Select
                Label3(1).Text = "°F"
                Label3(9).Text = "°F"
                Select Case ProblWLD.iAbs
                    Case 0 'rel
                        Label3(2).Text = "psig"
                        Label3(10).Text = "psig"
                    Case 1 'abs
                        Label3(2).Text = "psia"
                        Label3(10).Text = "psia"
                End Select
                Select Case ProblWLD.iPond
                    Case 0
                        Label3(6).Text = "BTU/mol"
                        Label3(8).Text = "BTU/mol°F"
                    Case 1
                        Label3(6).Text = "BTU/lb"
                        Label3(8).Text = "BTU/lb°F"
                End Select
                Label3(7).Text = "BTU"
                Label3(14).Text = "ft3/lb"
                Label3(20).Text = "ft3/lb"
                Label3(13).Text = "lb/ft3"
                Label3(19).Text = "lb/ft3"
        End Select
        Label3(16).Text = Label3(6).Text
        Label3(22).Text = Label3(6).Text
        Label3(15).Text = Label3(8).Text
        Label3(21).Text = Label3(8).Text
    End Sub

    'UPGRADE_WARNING: L'evento Text1.TextChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Text1, eventSender)
        With ProblWLD
            Select Case Index
                Case 10 : .deltaT = Val(Text1(Index).Text)
                Case 11 : .deltaP = Val(Text1(Index).Text)
                Case Else : .Variab(Index) = Val(Text1(Index).Text)
                    AzzeraRisultati(False)
            End Select
        End With
    End Sub
    Public Sub AggTesti()
        Dim i As Short
        For i = 0 To 8
            Text1(i).Text = Funzioni.myStr(ProblWLD.Variab(i), 5, 2, False)
        Next
    End Sub
    Private Sub txtDebug_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        ProblWLD.iDebug = txtDebug.Value
        If ProblWLD.iDebug > 0 Then ProblWLD.kwrt = 2 Else ProblWLD.kwrt = 0
    End Sub
    Private Sub txtIter_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtIter.TextChanged
        If Inizializzando Then Exit Sub
        ProblWLD.nIter = Val(txtIter.Text)
    End Sub
    Private Sub txtPun_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPun.TextChanged
        If Inizializzando Then Exit Sub
        ProblWLD.Npun = Val(txtPun.Text)
        ' Ridimensiona
    End Sub
	Public Sub AggOption()
		With ProblWLD
			optAbs(.iAbs).Checked = True
			If .iAcqua = 0 Then .iAcqua = 1
			optAcq(.iAcqua - 1).Checked = True
			If .iEquil = 0 Then .iEquil = 1
			optCost(.iEquil - 1).Checked = True
			If .iCost = 0 Then .iCost = 1
			optCrit(.iCost - 1).Checked = True
			If .iHc = 0 Then .iHc = 1
			optHC(.iHc - 1).Checked = True
			If .iIdeal = 0 Then .iIdeal = 1
			optId(.iIdeal - 1).Checked = True
			If .iUnit = 0 Then .iUnit = 1
			Option1(.iUnit - 1).Checked = True
			optPort(.iPond).Checked = True
			cmbPrecis.SelectedIndex = .iPrecis
			If .nIter = 0 Then .nIter = 40
			txtIter.Text = Str(.nIter)
			txtDebug.Text = Str(.iDebug)
			mnuPref(0).Checked = .iStLib = 1
		End With
		AggCostanti()
	End Sub
	
	Public Sub Aggiorna9()
		txtPun.Text = Str(ProblWLD.Npun)
		If ProblWLD.Tequi = 0 Then Check2(0).CheckState = System.Windows.Forms.CheckState.Checked Else Check2(0).CheckState = System.Windows.Forms.CheckState.Unchecked
		If ProblWLD.Pequi = 0 Then Check2(1).CheckState = System.Windows.Forms.CheckState.Checked Else Check2(1).CheckState = System.Windows.Forms.CheckState.Unchecked
		Text1(10).Text = Str(ProblWLD.deltaT)
		Text1(11).Text = Str(ProblWLD.deltaP)
	End Sub
	
	Public Sub Carica()
		Dim ifl As Short
		Dim Riga As String
		Monitor.Motore.Problem.Extension = ".WLD"
        Monitor.Motore.Problem.TipoFile = "Termodinamica fluidi petroliferi"
        Monitor.Motore.About.ProgName = "* Wald * Thermal properties for petroleum fluids *"
        Monitor.Motore.About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
        Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
        Monitor.Motore.About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
        Monitor.Motore.About.ProgDesc = "Thermal Calculations"
        Monitor.Motore.About.Company = "Copyright (c) 2005 SSAP"
        Monitor.Motore.About.Code = ""
		Picture1.BringToFront()
		cmbPrecis.Items.Add("Precisione media")
		cmbPrecis.Items.Add("Precisione alta")
		cmbPrecis.Items.Add("Precisione bassa")
		cmbTipCalc.Items.Add("Da ISA")
		cmbTipCalc.Items.Add("Manuale")
		cmbTipCalc.Items.Add("Automatico")
		cmbTipCalc.SelectedIndex = 2
		ifl = FreeFile
        If Not ApriFile(rmHelpStrings.GetString("Trasformazioni"), ifl) Then Exit Sub
		'Open Monitor.Motore.Inizio.Archdir + "\" + FF(7) For Input As #ifl
		Do 
			Riga = LineInput(ifl)
			If EOF(ifl) Then Exit Do
			cmbTrasf.Items.Add(Riga)
		Loop 
		FileClose(ifl)
		AggTesti()
		AggOption()
	End Sub
	
	Public Sub Risultati(ByRef i As Short)
		Label2(i).Visible = True
		Text1(i).Visible = True
		Text1(i).Enabled = False
		Text1(i).BackColor = System.Drawing.Color.Yellow
		Label3(i).Visible = True
		Gialli.Add(i)
	End Sub
	Public Sub Variabili(ByRef i As Short)
		Label2(i).Visible = True
		Text1(i).Visible = True
		Text1(i).Enabled = True
        Text1(i).BackColor = Bianco
		Label3(i).Visible = True
		
	End Sub
	Public Sub AzzeraRisultati(Optional ByRef Uccidi As Boolean = True)
		Dim i, j As Short
		Dim FileTxt As String
		FileTxt = Monitor.Motore.Inizio.DiscoRam & "WALD1.TXT"
		For j = 1 To Gialli.Count()
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Gialli(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = Gialli.Item(1)
			Label2(i).Visible = False
			Text1(i).Visible = False
			Text1(i).Enabled = True
            Text1(i).BackColor = Bianco
			Label3(i).Visible = False
			Gialli.Remove(1)
		Next 
		If Uccidi Then
			'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Len(Dir(FileTxt)) > 0 Then Kill(FileTxt)
		End If
		cmdRapp.Enabled = False
	End Sub
	
	Public Sub Inizializza()
		Dim i As Short
		ProblWLD.Variab(0) = 100
		For i = 0 To 8
			Label2(i).Visible = False
			Text1(i).Visible = False
			Text1(i).Enabled = True
            Text1(i).BackColor = Bianco
			Label3(i).Visible = False
			If i > 0 Then Text1(i).Text = "0"
		Next 
		
	End Sub
    Public Sub AggCostanti()
        Dim File As String = ""
        Select Case ProblWLD.iEquil
            Case 1 : File = "RKS"
            Case 2 : File = "PR"
        End Select
        cmbInteraz.Items.Clear()
        cmbInteraz.Items.Add("(nessuno)")
        File = Monitor.Motore.Inizio.Archdir & "\" & File & "*.DAT"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        File = Dir(File)
        If Len(File) = 0 Then
            cmbInteraz.SelectedIndex = 0
            Exit Sub
        End If
        Do
            cmbInteraz.Items.Add(VB.Left(File, Len(File) - 4))
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            File = Dir()
        Loop While Len(File) > 0
        If ProblWLD.iSetCost > cmbInteraz.Items.Count - 1 Then ProblWLD.iSetCost = 0
        cmbInteraz.SelectedIndex = ProblWLD.iSetCost
    End Sub
End Class