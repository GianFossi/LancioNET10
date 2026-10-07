Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmHTRI
    Inherits System.Windows.Forms.Form
    Public xBot, xTop, yTop, yBot As Single
    Public Gia As Short
    Public Espanso As Boolean
    Public Ricordo, SelNode, DragNode As System.Windows.Forms.TreeNode
    Private indrag As Boolean
    Private File2, NomeDAT As String
    Private NonOK As Boolean
    Private ItemUnderMouseToDrop As TreeNode
    Public SelezioneMultipla As New Collection
    Public locPen As Pen = New Pen(Color.Black)
    'UPGRADE_WARNING: L'evento chkHTRI.CheckStateChanged può essere generato quando il form è inizializzato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkHTRI_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkHTRI.CheckStateChanged
        Dim i, n As Short
        Dim u As String
        i = chkHTRI.CheckState
        'CLOSPREV()
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then n = 1
        u = objDatBase.PutBasCh(4, 73, Nrdit \ 2, n, objDatBase.MKI(i), 0)
        'Apri(Trim(job.Contratto))
    End Sub

    Private Sub cmdApri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdApri.Click
        If NonAncora Then
            If Not CheckLicenza() Then Exit Sub
            NonAncora = False
        End If
        CarPre()
    End Sub
    Private Sub cmdAzz_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAzz.Click
        AnnulMec()
    End Sub
    Private Sub cmdBil_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBil.Click
        Bilancio()
    End Sub
    Private Sub cmdCalcTer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalcTer.Click
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        ListView2.Items.Clear()
        ListView2.Items.Add("Calcolo in corso....")
        AddDistinta = 2 : DatiCos()
        If chkHTRI.CheckState = 1 Then AddDistinta = 2 : DatiCos()
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdCos_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCos.Click
        Dim n As Short
        AddDistinta = 0
        ModeFun = 1
        ModeAltern = 1
        DatiFun()
        altern(1)
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then n = 1
        AlternDati(n)
        DatiCos()
        ModeAltern = 0
        ModeFun = 0
    End Sub

    Private Sub cmdCurve_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCurve.Click
        '        Dim iF2 As Short
        '       iF2 = FreeFile()
        '      FileOpen(iF2, RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & RTrim(job.Contratto) & ".TE1", OpenMode.Random, , , Len(Lav(0)))
        '     FilePut(iF2, Lav(0), 1)
        '    FileClose(iF2)
        objVentil.CurvadaISA(Nrdit, Trim(job.Contratto), objDatBase)
    End Sub
    Private Sub cmdDati_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDati.Click
        EdiGen()
    End Sub

    Private Sub cmdDati4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDati4.Click
        Dati4()
    End Sub

    Private Sub cmdDati56_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDati56.Click
        Dati56()
    End Sub

    Private Sub cmdDatiBank_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDatiBank.Click
        PreparaPRO(iActBank, BankR(iActBank))
        AggFrame6()
    End Sub

    Private Sub cmdDatiGen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDatiGen.Click
        EdiGen()
    End Sub

    Private Sub cmdDatiIniz_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDatiIniz.Click
        optTM(0).Checked = True
        If Val(job.Comm.Ind(2).Data.Assieme) = 0 Then job.Comm.Ind(2).Data.Assieme = "1"
        ' Allocat1
        NonMostrareAlt = False
        altern(1)
        UpmHtr = True
        DatiCos()
        optTM(1).Checked = True
    End Sub

    Private Sub cmdDB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDB.Click
        ExamDB()
    End Sub

    Private Sub cmdDisPro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDisPro.Click
        FaseDisegno = 0
        Proposal(iActBank)
    End Sub

    Private Sub cmdDS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDS.Click
        EdiDS(3)
    End Sub
    Private Sub cmdDWG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDWG.Click
        Dim File, Sigla As String
        Select Case FaseDisegno
            Case 0
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.Str2Cifre(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Sigla = GlobalRoutines.Str2Cifre(iActBank)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                File = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Trim(job.Contratto)) + CDbl(Sigla))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ApriPri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Monitor.routines.ApriPri(File, "DWG", 0, 3, "", ACADobj)
                If Not ACADobj Is Nothing Then
                    ACADApp = ACADobj.Application
                    'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    cmdFull_Click(cmdFull, New System.EventArgs())
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ChiudiPRI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Monitor.routines.ChiudiPRI()
                    ACADApp.Update()
                    ACADApp.ZoomAll() '.ActiveDocument.Application.ZoomAll
                Else
                    cmdDWG.Enabled = False
                End If
            Case 1
                File = VB.Left(NomeDAT, Len(NomeDAT) - 4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ApriPri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Monitor.routines.ApriPri(File, "DWG", 0, 3, "", ACADobj)
                If Not ACADobj Is Nothing Then
                    ACADApp = ACADobj.Application
                    'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    DisHeadX(1)
                    ACADApp.Update() 'FA ERRORE
                    'Debug.Print ACADApp.ActiveDocument.Activespace; ACADApp.ActiveDocument.ActiveViewport.Name
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ACADApp.ActiveDocument.ActiveViewport.ZoomAll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ACADApp.ActiveDocument.ActiveViewport.ZoomAll()
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ChiudiPRI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Monitor.routines.ChiudiPRI()
                Else
                    cmdDWG.Enabled = False
                End If
        End Select
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub cmdDXF_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDXF.Click
        Dim File, Sigla As String
        Sigla = Trim(Str(iActBank))
        If Len(Sigla) = 1 Then Sigla = "0" & Sigla
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        File = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Trim(job.Contratto)) + CDbl(Sigla))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ApriPri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.routines.ApriPri(File, "DXF", 0, 2, "")
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        cmdFull_Click(cmdFull, New System.EventArgs())
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ChiudiPRI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.routines.ChiudiPRI()
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        MsgBox("E' stato generato il file " & File & ".DXF", MsgBoxStyle.Information)
    End Sub

    Private Sub cmdEliPRO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEliPRO.Click
        Kill(File2)
        AggFrame6()
    End Sub
    Public ReadOnly Property bigmenu(ByVal i As Integer) As System.Windows.Forms.ToolStripMenuItem
        Get
            Select Case i
                Case 0 : Return _bigMenu_0
                Case 1 : Return _bigMenu_0
                Case 2 : Return _bigMenu_0
                Case 3 : Return _bigMenu_0
                Case 4 : Return _bigMenu_0
            End Select
        End Get
    End Property
    Private Sub cmdFin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFin.Click
        OpFin()
    End Sub
    Private Sub cmdGeneraDB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGeneraDB.Click
        StruttItem()
    End Sub

    Private Sub cmdHeadx_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHeadx.Click
        FaseDisegno = 1
        EseguiHeadX(Val(job.Comm.Ind(1).Data.Assieme))
    End Sub

    'Private Sub cmdHelpCamini_Click()
    'Dim hwndHelp As Long
    '   hwndHelp = HtmlHelp(hWnd, RadiceHelp, HH_HELP_CONTEXT, IDH_HTRI_CAMINI)
    'End Sub
    Private Sub cmdListBoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdListBoc.Click
        Dim itp As String
        Dim n As Short
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then n = 1
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Bocchll(objDatBase.CVI(objDatBase.DatBase(2, 9, Nrdit \ 2, n, itp, 0)))
    End Sub
    Private Sub cmdMappa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMappa.Click
        Mappa()
    End Sub
    Private Sub cmdMFVC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMFVC.Click
        MonFVC()
    End Sub
    Public ReadOnly Property optCamini(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _optCamini_0
                Case 1 : Return _optCamini_1
            End Select
        End Get
    End Property
    Private Sub cmdNuovAlt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNuovAlt.Click
        Dim Valido As Boolean
        NonMostrareAlt = False
        altern(0, True)
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Monitor.Motore.InputForms Is Nothing
        Sommari(Valido)
        FillTree(1)
    End Sub

    Private Sub cmdNuovIt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNuovIt.Click
        Dim Esito As Short
        Dim Valido As Boolean
        InputDaBanco = True
        Esito = InserIte(NumIt)
        'If Esito Then
        '   Esito = EditEdit
        '   Sommari Valido
        '   FillTree 1
        'End If

    End Sub

    Private Sub cmdNuovo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNuovo.Click
        NuoPre()
    End Sub

    Private Sub cmdRapp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRapp.Click
        AddDistinta = 100
        'SALVA
        'CLOSPREV
        'Catena "HTRIFIN"
        Progetto(1)
    End Sub

    Private Sub cmdScelAlt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScelAlt.Click
        SceltaActAlt()
    End Sub

    Private Sub cmdSelVent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelVent.Click
        AddDistinta = 101 : Ventil1()
    End Sub

    Private Sub cmdSommario_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSommario.Click
        ' Sommari
        ' Allocat1
        LanciaUPTX2()
        SalvaSTR()
    End Sub

    Private Sub cmdSt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSt.Click
        Dim StamPort As String
        ' StamPort = Printer.Port
        'Monitor.routines.DoveDisegno = Printer
        'CommonDialog1.CancelError = True
        CommonDialog1Print.ShowDialog()
        ' Printer.ScaleMode = vbTwips
        DisVideo()
        ' Printer.EndDoc()
        Monitor.routines = Nothing
        DisVideo()
    End Sub
    Private Sub DisVideo()
        Select Case FaseDisegno
            Case 0
                Proposal(iActBank)
            Case 1
                DisHeadX(1)
        End Select
    End Sub
    Private Sub cmdStampe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStampe.Click
        Hstampe()
    End Sub

    Private Sub cmdVFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVFile.Click
        Shell("NotePad " & File2, AppWinStyle.NormalFocus)
    End Sub

    Private Sub cmdZon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdZon.Click
        NonMostrareAlt = False
        altern(-1)
    End Sub


    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Dim DirDir, Data As String
        If ListView6.Items.Count > 0 Then ListView6.Items.RemoveAt(ListView6.Items.Count)
        EseguiFile()
        If job.Comm.indice = 0 Then Exit Sub
        DirDir = Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch
        NomeDAT = DirDir & "\" & job.Comm.Ind.Item(job.Comm.indice).Data.File & ".DAT"
        If IO.File.Exists(NomeDAT) Then
            Data = CStr(FileDateTime(NomeDAT))
            ListView6.Items.Add("Il file testate/telai è stato generato il " & Data)
        Else
            ListView6.Items.Add("Il file testate/telai è stato soppresso " & Data)
        End If
        Command3.Enabled = True
        Command5.Enabled = True
        cmdHeadx.Enabled = True
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Shell("NotePad " & NomeDAT, AppWinStyle.NormalFocus)
    End Sub

    ' Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    ' Dim Index As Short = Command4.GetIndex(eventSender)
    ' Dim Esito As Boolean
    '     ItemnSt = job.Comm.Ind(1).Data.Assieme 'Item(i + 1)
    ' 'Nrdit = -2
    '     Esito = EditEdit()
    ' End Sub

    Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
        Kill(NomeDAT)
        ListView6.Items.RemoveAt(ListView6.Items.Count)
        ListView6.Items.Add("Il file testate/telai non esiste")
        Command3.Enabled = False
        Command5.Enabled = False
        cmdHeadx.Enabled = False
    End Sub

    'UPGRADE_WARNING: Form evento Apert.Activate presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub Apert_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If NonOK Then
            Hide()
            Me.Close()
        End If
    End Sub

    Private Sub Apert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' ReDim Lav(1) ', DatiPrg(0) As DatiDes
        Dim iErr, ifl As Short
        Dim Height0, dH As Single
        Dim FirmaAz, HelpFile As Str40
        Dim Fir As String
        Try
            objDatBase = New LegacyEstimateDatabase(Monitor.Motore)
            objVentil = New Ventil.clsVentil
            With objVentil
                .DoveDatBase = objDatBase
                .DoveMotore = Monitor.Motore
                .DoveScrivere = Me.ListView3
                .IniziaDaISA()
            End With
            If Len(Monitor.Motore.Inizio.Gancio) = 0 Then Monitor.Motore.Inizio.Gancio = " "
            If Not VB.Right(RTrim(Monitor.Motore.Inizio.Gancio), 1) = "1" Then Monitor.Motore.Inizio.Gancio = " "
            'If job Is Nothing Then
            job = New RoutBase1.clsjob(Monitor.Motore)
            'End If
            If Monitor.Motore.Inizio.Gancio.Trim.Length > 0 Then
                '  FileClose(1)
                ' FileOpen(1, Monitor.Motore.Inizio.Gancio, OpenMode.Random, , , Len(Lav(0)))
101:            LeggiLav(Monitor.Motore.Inizio.Gancio)
            End If
            With Monitor.Motore.About
                .ProgName = "ISA"
                .ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
                Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
                .ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
                .ProgDesc = "Thermal & mechanical calculations of Air Fin Coolers"
                Text = Text & "  (" & .ProgVers & ", " & .ProgDate & ")"
            End With
            Monitor.Motore.Problem.Extension = ".PRV"
            Monitor.Motore.Problem.nonSciolto = True
            FirmaAz.St = Monitor.Motore.Inizio.Firma
            Top = 0
            Left = 0
            Height0 = Height
            Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            dH = Height - Height0
            _Frames_5.Height += dH
            ListView3.Height += dH
            _Frames_1.Height += dH
            TreeView1.Height += dH
            Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
            Monitor.Motore.Inizio.LavoriSciolti = False
            AggStatusB()
            AbilitaMenu(False)
            Fir = Monitor.Motore.Inizio.ReadIniFile("", "Preferenze ISA", "CodiciDB")
            mnuAttivaCodici.Checked = Fir = "Si"
            nuovePar = Monitor.Motore.Inizio.ReadIniFile("", "Preferenze Ventil", "NuoveParabole") = "Si"
            mnuNuoveCurve.Checked = nuovePar
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            NonOK = True
        End Try
    End Sub

    Private Sub Apert_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        FineFlangia()
        eventArgs.Cancel = Cancel
    End Sub
    Private Sub Apert_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ExitAll()
    End Sub
    Public Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Espanso = Not Espanso
        EspCom()
        If Espanso Then Command1.Text = "&Comprimi" Else Command1.Text = "&Espandi"
    End Sub
    Public Sub EspCom()
        Dim Nodex As System.Windows.Forms.TreeNode
        For Each Nodex In TreeView1.Nodes
            If Espanso Then Nodex.Expand() Else Nodex.Collapse()
        Next Nodex
    End Sub
    Private Sub mnuUPM_Click(ByRef Index As Short)
    End Sub
    Public Sub mnuSommario_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSommario.Click
        System.Windows.Forms.Help.ShowHelpIndex(Me, RadiceHelp)
    End Sub
    Private Sub optCamini_CheckedChanged(ByVal Index As Integer)
        If optCamini(Index).Checked Then
            Dim junk As Short
            Dim u As String
            ' CLOSPREV()
            If optCamini(0).Checked Then junk = 1 Else junk = 2
            u = objDatBase.PutBasCh(1, 14, 1, 1, objDatBase.MKI(junk), 0)
            ' Apri(Trim(job.Contratto))
        End If
    End Sub

    Private Sub optTM_CheckedChanged(ByVal Index As Integer)
        If optTM(Index).Checked Then
            TreeView1_Click(TreeView1, New System.EventArgs())
            If optTM(1).Checked Then
                InitUPM()
                UpmHtr = True
            Else
                UpmHtr = False
            End If
        End If
    End Sub

    Private Sub Picture1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        Select Case Button
            Case 1
                '         MultiSelezione Shift
                If cmdZoom.Checked Then
                    xTop = X
                    yTop = Y
                    Gia = False
                End If
            Case 2
                '         ExecPopupMenu
        End Select

    End Sub

    Private Sub Picture1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        If Button = 1 And cmdZoom.Checked Then
            Dim r As New Rectangle(xTop, yTop, xBot - xTop, yBot - yTop)
            r = Picture1.RectangleToScreen(r)
            ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
            xBot = X : yBot = Y
            r = New Rectangle(xTop, yTop, xBot - xTop, yBot - yTop)
            r = Picture1.RectangleToScreen(r)
            ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
        End If

    End Sub
    Private Sub Picture1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        If Not cmdZoom.Checked Then Exit Sub
        '-------------------------------
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim b As SolidBrush = New SolidBrush(Color.FromArgb(200, 255, 255)) 'colorino di sfondo dello zoom
        If xBot < xTop Then GlobalRoutines.SWAP(xBot, xTop)
        If yBot < yTop Then GlobalRoutines.SWAP(yBot, yTop)
        With Funzioni.DisRut
            .MouseToWorld(xTop, yTop)
            .MouseToWorld(xBot, yBot)
            If Not .Scala(xTop, xBot, yBot, yTop) Then Exit Sub
            .PennaFill = b
            .quadrato(xTop, yBot, xBot, yTop, 0, 0, True)
            .quadrato(xTop, yBot, xBot, yTop, 0, 0, False)
        End With
        '-----------------------------
        Select Case FaseDisegno
            Case 0
                Proposal(iActBank)
            Case 1
                DisHeadX(1)
        End Select
        Picture1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub TreeView1_AfterLabelEdit(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        Dim Cancel As Boolean = eventArgs.CancelEdit
        Dim NewString As String = eventArgs.Label
        Dim j As Short
        Dim Nodex As System.Windows.Forms.TreeNode
        Dim k, Tipo As String
        Dim n, l As Short
        Dim Bank As String
        Dim u As String
        Nodex = TreeView1.SelectedNode
        k = Nodex.Name
        Tipo = VB.Left(k, 3)
        k = VB.Right(k, Len(k) - 4)
        Select Case Tipo
            Case "Ban"
                iActBank = Val(k)
                Bank = BankR(iActBank)
                BankR(iActBank) = Trim(NewString)
                SostNomeBanco(Bank, BankR(iActBank))
            Case "Ven"
                j = Val(k)
                Disposiz.BayNome(j) = NewString
            Case "Ite"
                j = Val(k)
                Item(j) = NewString
                ItemnSt = NewString
                job.Comm.Ind(1).Data.Assieme = NewString
                ' CLOSPREV()
                u = objDatBase.PutBasCh(2, 1, j, 1, ItemnSt, 0)
                ' Apri(Trim(job.Contratto))
            Case "Alt"
                j = Val(VB.Right(k, Len(k) - 4))
                n = InStr(k, "_") 'ITEM
                k = VB.Right(k, Len(k) - n)
                n = InStr(k, "_") 'ITEM
                k = VB.Right(k, Len(k) - n)
                l = Val(k) 'Alt
                'cosa ne fai?
        End Select
    End Sub

    Private Sub TreeView1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TreeView1.Click
        Dim Nodx As System.Windows.Forms.TreeNode
        Dim Key As String
        Dim j As Short
        Dim l, n, iF1 As Short
        Dim itp As String
        Dim i As Short
        Dim Risult As Boolean
        Dim DirDir, Data As String
        Dim Nody As System.Windows.Forms.TreeNode
        Nodx = TreeView1.SelectedNode
        _Frames_0.Visible = False
        _Frames_2.Visible = False
        _Frames_3.Visible = False
        _Frames_5.Visible = False
        _Frames_6.Visible = False
        _Frames_7.Visible = False
        ListView2.Items.Clear()
        If Nodx Is Nothing Then Exit Sub
        Key = Nodx.Name
        _cmdFun_0.Enabled = False
        _cmdFun_1.Enabled = False
        cmdBil.Enabled = False
        cmdZon.Enabled = False
        Select Case VB.Left(Key, 3)
            Case "Ban"
                _Frames_6.Visible = True
                iActBank = Val(VB.Right(Key, Len(Key) - 4))
                AggFrame6()
                ActivItem = 0
            Case "Ite"
                InputDaBanco = False
                j = Val(VB.Right(Key, Len(Key) - 4))
                'job.Comm.Ind(1).Data.Assieme = Item(j)
                job.Comm.Ind(1).Data.Assieme = ItemC(j)
                n = InStr(job.Comm.Ind(1).Data.Assieme, "|")
                If n > 0 Then job.Comm.Ind(1).Data.Assieme = VB.Left(job.Comm.Ind(1).Data.Assieme, n - 1)
                If ActivItem <> j Then
                    ActivAlt(j) = 1
                    job.Comm.Ind(2).Data.Assieme = Str(ActivAlt(j))
                    altern(1)
                End If
                ActivItem = j
                Nody = Nodx.Parent.Parent
                iActBank = Val(VB.Right(Nody.Name, Len(Nody.Name) - 4))
                Select Case optTM(0).Checked
                    Case True
                        cmdBil.Enabled = True
                        _Frames_0.Visible = True
                        _cmdFun_0.Enabled = True
                        _cmdFun_1.Enabled = True
                    Case False
                        _Frames_7.Visible = True
                        UpmHtr = True
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                        AddDistinta = 4 : DatiCos()
                        AddDistinta = 0
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        ListView6.Items.Clear()
                        If OKDati Then
                            ListView6.Items.Add("I dati costruttivi sono completi")
                            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                            If Len(Dir(CercaMec)) > 0 Then
                                ListView6.Items.Add("Il calcolo meccanico è stato eseguito")
                                If Not PreliminItem() Then
                                    ListView6.Items.Add("La DB non è impostata")
                                Else
                                    ListView6.Items.Add("La DB è stata impostata")
                                    DirDir = CStr(Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch)
                                    NomeDAT = DirDir & "\" + job.Comm.Ind.Item(job.Comm.indice).Data.File + ".DAT"
                                    If Not IO.File.Exists(NomeDAT) Then
                                        ListView6.Items.Add("Il file testate/telai non esiste")
                                        Command3.Enabled = False
                                        Command5.Enabled = False
                                        cmdHeadx.Enabled = False
                                    Else
                                        Data = CStr(FileDateTime(NomeDAT))
                                        ListView6.Items.Add("Il file testate/telai è stato generato il " & Data)
                                        Command3.Enabled = True
                                        Command5.Enabled = True
                                        cmdHeadx.Enabled = True
                                    End If
                                End If
                            Else
                                ListView6.Items.Add("Il calcolo meccanico non è stato eseguito")
                            End If
                        Else
                            ListView6.Items.Add("I dati costruttivi e/o i dati")
                            ListView6.Items.Add("funzionali non sono validi.")
                        End If
                End Select
            Case "Alt"
                InputDaBanco = False
                j = Val(VB.Right(Key, Len(Key) - 4)) 'ITEM
                job.Comm.Ind(1).Data.Assieme = ItemC(j)
                n = InStr(job.Comm.Ind(1).Data.Assieme, "|")
                If n > 0 Then job.Comm.Ind(1).Data.Assieme = VB.Left(job.Comm.Ind(1).Data.Assieme, n - 1)
                n = InStr(Key, "_")
                Key = VB.Right(Key, Len(Key) - n)
                n = InStr(Key, "_")
                Key = VB.Right(Key, Len(Key) - n)
                l = Val(Key) 'Alt
                job.Comm.Ind(2).Data.Assieme = Str(l)
                ActivAlt(j) = l
                Frame6.Text = "Dati Alternativa n°" & Str(l)
                Nody = Nodx.Parent.Parent.Parent
                iActBank = Val(VB.Right(Nody.Name, Len(Nody.Name) - 4))
                Select Case optTM(0).Checked
                    Case True
                        _Frames_2.Visible = True
                        cmdBil.Enabled = True
                        _cmdFun_0.Enabled = True
                        _cmdFun_1.Enabled = True
                        cmdZon.Enabled = True
                        NonMostrareAlt = False
                        altern(1)
                        ' CLOSPREV()
                        AlternDati(l)
                        AddDistinta = 101
                        Risult = objVentil.Esegui(AddDistinta, Nrdit, Val(job.Comm.Ind(2).Data.Assieme), Trim(job.Contratto), True)
                    Case False
                        _Frames_7.Visible = True
                        altern(1)
                        ENuovo()
                        ListView6.Items.Clear()
                        If VUOTO Then
                            ListView6.Items.Add("Non esiste un file di dati meccanici")
                        Else
                            ListView6.Items.Add("I calcoli meccanici sono stati eseguiti")
                        End If
                End Select
        End Select
    End Sub
    Private Sub TreeView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragDrop
        Dim InNode, OutNode As System.Windows.Forms.TreeNode
        Dim kIn, jIn, n As Short
        Dim jInStr, Testo As String
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        DragNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        ItemUnderMouseToDrop = TreeView1.SelectedNode

        'messagebox.show DragNode.Text + " rilasciato su " + TreeView1.DropHighlight.Text
        InNode = DragNode
        OutNode = ItemUnderMouseToDrop
        Select Case VB.Left(InNode.Name, 3)
            Case "Ban"
                MsgBox("   Operazione non valida." & vbCrLf & "I banchi non possono essere spostati.", MsgBoxStyle.Information)
                TreeView1_NodeClick(TreeView1, New System.Windows.Forms.TreeNodeMouseClickEventArgs(InNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                Exit Sub
            Case "Ven"
                Select Case VB.Left(OutNode.Name, 3)
                    Case "Ban" 'spostamento da un banco ad un altro
                        SpostaUnita(InNode, OutNode)
                    Case "Ven" 'cambiamento di ordine
                        If InNode.Parent Is OutNode.Parent Then
                            CambiaOrdineUnita(InNode, OutNode)
                        Else
                            Testo = "Per spostare un'unità da un banco ad un altro" & vbCrLf
                            Testo = Testo & "bisogna trascinare l'unità sull'icona del nuovo banco."
                            MsgBox(Testo, MsgBoxStyle.Information)
                            TreeView1_NodeClick(TreeView1, New System.Windows.Forms.TreeNodeMouseClickEventArgs(InNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                            Exit Sub
                        End If
                    Case "Ite", "Alt"
                        MsgBox("   Operazione non valida.", MsgBoxStyle.Information)
                        TreeView1_NodeClick(TreeView1, New System.Windows.Forms.TreeNodeMouseClickEventArgs(InNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                        Exit Sub
                End Select
            Case "Ite"
                Select Case VB.Left(OutNode.Name, 3)
                    Case "Ban"
                        MsgBox("   Operazione non valida." & vbCrLf & "Per spostare un item da un banco ad un altro bisogna spostare l'unità che lo contiene.", MsgBoxStyle.Information)
                        TreeView1_NodeClick(TreeView1, New System.Windows.Forms.TreeNodeMouseClickEventArgs(InNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                        Exit Sub
                    Case "Ven" 'raggruppamento/smontaggio
                    Case "Ite" 'raggruppamento/smontaggio/cambiamento di ordine
                        RaggruppaOrdine(InNode, OutNode)
                    Case "Alt"
                        MsgBox("   Operazione non valida.", MsgBoxStyle.Information)
                        TreeView1_NodeClick(TreeView1, New System.Windows.Forms.TreeNodeMouseClickEventArgs(InNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                        Exit Sub
                End Select
            Case "Alt"
                MsgBox("   Operazione non valida." & vbCrLf & "Le alternative non possono essere spostate.", MsgBoxStyle.Information)
                TreeView1_NodeClick(TreeView1, New System.Windows.Forms.TreeNodeMouseClickEventArgs(InNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                Exit Sub
        End Select
        'TreeView1_NodeClick TreeView1.DropHighlight
        FillTree(1)
        SalvaNITE()
    End Sub
    Private Sub TreeView1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragOver
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        'As the mouse moves over nodes, provide feedback to the user
        'by highlighting the node that is the current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = TreeView1.GetNodeAt(pt)

        'See if the targetNode is currently selected, if so no need to validate again
        If Not (TreeView1.SelectedNode Is targetNode) Then 'non c'era selectednode
            'Select the node currently under the cursor
            TreeView1.SelectedNode = targetNode

            'Check that the selected node is not the dropNode and also that it
            'is not a child of the dropNode and therefore an invalid target
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            Do Until targetNode Is Nothing
                If targetNode Is dropNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                targetNode = targetNode.Parent
            Loop
        End If

        'Currently selected node is a suitable target, allow the move
        e.Effect = DragDropEffects.Move
        '        Dim Node, Nodex As System.Windows.Forms.TreeNode
        '        If indrag Then
        ' Node = TreeView1.GetNodeAt(X, Y)
        ' 'UPGRADE_ISSUE: MSComctlLib.TreeView proprietà TreeView1.DropHighlight non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        ' TreeView1.DropHighlight = Node
        ' 'Debug.Print x, y, TreeView1.Height, TreeView1.Width
        ' Nodex = Node
        ' If Node Is Nothing Then Exit Sub
        ' Do Until Node.FirstNode Is Nothing
        ' Node = Node.FirstNode
        ' Loop
        ' Node.EnsureVisible()
        ' Select Case VB.Left(Nodex.Name, 3)
        '     Case "Ban"
        '     Case "Ven"
        ' 'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
        '				GoSub Assicura
        '        Case "Ite"
        '    Nodex = Nodex.Parent
        '    'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
        '					GoSub Assicura
        '            Case "Alt"
        '        Nodex = Nodex.Parent.Parent
        '        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
        '					GoSub Assicura
        '       End Select
        '       End If
        '       Exit Sub
        'Assicura:
        '        Node = Nodex
        '        If Not Node.NextNode Is Nothing Then
        ' Node.NextNode.EnsureVisible()
        ' Else
        ' Node = Node.Parent
        ' If Not Node.NextNode Is Nothing Then
        ' If Node.NextNode.FirstNode Is Nothing Then
        ' Node.NextNode.EnsureVisible()
        ' Else
        ' Node.NextNode.FirstNode.EnsureVisible()
        ' End If
        ' End If
        ' End If
        ' Node = Nodex
        ' If Not Node.PrevNode Is Nothing Then
        ' Node.PrevNode.EnsureVisible()
        ' Else
        ' Node = Node.Parent
        ' If Not Node.PrevNode Is Nothing Then
        ' If Node.NextNode Is Nothing Then
        ' Else
        ' Node = Node.NextNode.FirstNode
        ' End If
        ' If Node Is Nothing Then
        ' Node.Parent.EnsureVisible()
        ' Else
        ' Do Until Node.NextNode Is Nothing
        ' Node = Node.NextNode
        ' Loop
        ' Node.EnsureVisible()
        ' End If
        ' End If
        ' End If
        ' Node = Nodex.Parent
        ' If Node.FirstNode Is Nodex Then Node.EnsureVisible()
        ' 'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        ' Return
    End Sub
    Private Sub TreeView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragEnter
        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TreeView1_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Nodx, Nody As System.Windows.Forms.TreeNode
        Dim j As Short
        Dim Key As String
        Dim Valido As Boolean
        Select Case KeyCode
            Case System.Windows.Forms.Keys.Delete
                Nodx = TreeView1.SelectedNode
                If Nodx Is Nothing Then Exit Sub
                Key = Nodx.Name
                Select Case VB.Left(Key, 3)
                    Case "Ban"
                        iActBank = Val(VB.Right(Key, Len(Key) - 4))
                    Case "Ite"
                        j = Val(VB.Right(Key, Len(Key) - 4))
                        EliIte(j)
                    Case "Alt"
                        EliAlt()
                        Sommari(Valido)
                        FillTree(1)
                End Select
            Case System.Windows.Forms.Keys.Insert
                Nodx = TreeView1.SelectedNode
                If Nodx Is Nothing Then Exit Sub
                Key = Nodx.Name
                Select Case VB.Left(Key, 3)
                    Case "Ban"
                        iActBank = Val(VB.Right(Key, Len(Key) - 4))
                        cmdNuovIt_Click(cmdNuovIt, New System.EventArgs())
                    Case "Ite"
                        Nody.Text = Nodx.Parent.Text
                        Key = Nody.Name
                        iActBank = Val(VB.Right(Key, Len(Key) - 4))
                        cmdNuovIt_Click(cmdNuovIt, New System.EventArgs())
                    Case "Alt"
                End Select
            Case System.Windows.Forms.Keys.F1
        End Select

    End Sub

    Private Sub TreeView1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseDown
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim Node As System.Windows.Forms.TreeNode
        Dim i As Short
        Dim Key As String
        Dim pt As Point = CType(eventSender, TreeView).PointToClient(New Point(eventArgs.X, eventArgs.Y))
        If eventArgs.Button = System.Windows.Forms.MouseButtons.Right Then
            DragNode = TreeView1.GetNodeAt(pt) 'TreeView1.SelectedItem
        Else
            indrag = False
            Node = TreeView1.GetNodeAt(pt) 'TreeView1.SelectedItem
            If Node Is Nothing Then Exit Sub
            Key = VB.Left(Node.Name, 3)
            Select Case Key
                Case "Ite", "Alt"
                    If Shift = 1 Then
                        If SelezioneMultipla.Count() > 0 Then
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Key. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            If Not VB.Left(SelezioneMultipla.Item(1).Key, 3) = Key Then GoTo No1
                        End If
                        SelezioneMultipla.Add(Node)
                        Node.ImageIndex = 5
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Image. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SelezioneMultipla.Item(1).Image = 5
                    Else
No1:                    Ammazza()
                        SelezioneMultipla.Add(Node)
                    End If
                Case Else
                    Ammazza()
            End Select
        End If
        Exit Sub
    End Sub
    Private Sub Ammazza()
        Dim i As Integer
        Dim Key As String
        For i = SelezioneMultipla.Count() To 1 Step -1
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Key. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Key = VB.Left(SelezioneMultipla.Item(i).Key, 3)
            On Error Resume Next
            Select Case Key
                Case "Ban"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Image. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SelezioneMultipla.Item(i).Image = 2
                Case "Ven"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Image. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SelezioneMultipla.Item(i).Image = 4
                Case "Ite"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Image. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SelezioneMultipla.Item(i).Image = 1
                Case "Alt"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SelezioneMultipla().Image. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SelezioneMultipla.Item(i).Image = 3
            End Select
            On Error GoTo 0
            SelezioneMultipla.Remove(i)
        Next
    End Sub
    Private Sub TreeView1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseMove
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim pt As Point = CType(eventSender, TreeView).PointToClient(New Point(eventArgs.X, eventArgs.Y))
        If eventArgs.Button = System.Windows.Forms.MouseButtons.Right Then
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            indrag = True
            TreeView1.SelectedNode = TreeView1.GetNodeAt(pt)
            'UPGRADE_ISSUE: MSComctlLib.Node metodo TreeView1.SelectedItem.CreateDragImage non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'UPGRADE_ISSUE: MSComctlLib.TreeView metodo TreeView1.DragIcon non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'TreeView1.DragIcon = TreeView1.SelectedNode.CreateDragImage
            'UPGRADE_ISSUE: La costante vbBeginDrag non è stata aggiornata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: MSComctlLib.TreeView metodo TreeView1.Drag non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'TreeView1.Drag(vbBeginDrag)
        End If
    End Sub

    Public Sub TreeView1_NodeClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim Node As System.Windows.Forms.TreeNode = eventArgs.Node
        Dim j, n As Short
        Dim k As String
        If indrag Then
            'Set TreeView1.SelectedItem = Node
            Exit Sub
        End If
        If InStr(Node.Name, "Inv") > 0 Then
            k = VB.Right(Node.Name, Len(Node.Name) - 3)
            n = InStr(k, "_")
            ' kLato = Val(Left(k, n - 1))
            j = Val(VB.Right(k, Len(k) - n))
            ' mnuDatiElem.Caption = "&Dati per " + Trim(Involucr(kLato, j).Mark)
            ' mnuConvElem.Caption = "Con&verti " + Trim(Involucr(kLato, j).Mark)
            ' mnuInseElem.Caption = "&Inserisci prima di &" + Trim(Involucr(kLato, j).Mark)
            ' mnuCalcElem.Caption = "&Calcola " + Trim(Involucr(kLato, j).Mark)
            ''  mnuRapp.Caption = "Rapporto " + Trim(Involucr(j).Mark)
            ' mnuElimElemento.Caption = "&Elimina " + Trim(Involucr(kLato, j).Mark)
            ' mnuDatiElem.Enabled = True
            ' mnuConvElem.Enabled = True
            ' mnuInseElem.Enabled = True
            ' mnuCalcElem.Enabled = True
            ' mnuElimElemento.Enabled = True
            ''  mnuRapp.Enabled = True
            ' cmdCalc.Enabled = True
            ' cmdDati.Enabled = True
        End If
        If InStr(Node.Name, "Noz") > 0 Then
            k = VB.Right(Node.Name, Len(Node.Name) - 3)
            n = InStr(k, "_")
            ' kLato = Val(Left(k, n - 1))
            j = Val(VB.Right(k, Len(k) - n))
            ' mnuDatiElem.Caption = "Da&ti per " + Trim(Nozzles(kLato, j).Mark)
            ' mnuCalcElem.Caption = "Ca&lcola " + Trim(Nozzles(kLato, j).Mark)
            ' mnuElimElemento.Caption = "Eli&mina " + Trim(Nozzles(kLato, j).Mark)
            ' mnuDatiElem.Enabled = True
            ' mnuCalcElem.Enabled = True
            ' mnuElimElemento.Enabled = True
            ' cmdCalc.Enabled = True
            ' cmdDati.Enabled = True
            ' mnuConvElem.Enabled = False
            ' mnuInseElem.Enabled = False
        End If
        'UPGRADE_ISSUE: MSComctlLib.Node proprietà Node.Selected non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '	Node.Selected = True
        'UPGRADE_ISSUE: MSComctlLib.TreeView proprietà TreeView1.DropHighlight non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '		TreeView1.DropHighlight = Node
        SelNode = Node
    End Sub


    Public Sub SpostaUnita(ByRef InS As System.Windows.Forms.TreeNode, ByRef OutS As System.Windows.Forms.TreeNode)
        'Unità su Banco
        'If InS.Parent Is OutS Then 'sullo stesso banco
        CambiaOrdineUnita(InS, OutS.FirstNode)
        'Else
        'End If
    End Sub
    Public Sub RaggruppaOrdine(ByRef InS As System.Windows.Forms.TreeNode, ByRef OutS As System.Windows.Forms.TreeNode)

    End Sub
    Public Sub CambiaOrdineUnita(ByRef InS As System.Windows.Forms.TreeNode, ByRef OutS As System.Windows.Forms.TreeNode)
        'Unità su Unità
        Dim jIn, jOut As Short
        Dim keyIn, keyOut As String
        Dim NodePin, NodePOut As System.Windows.Forms.TreeNode
        Dim jBankIn, jBankOut As Short
        Dim jcOut, jcIn, k As Short
        Dim i As Short
        Dim Child As System.Windows.Forms.TreeNode
        Dim u As String
        keyIn = VB.Right(InS.Name, Len(InS.Name) - 4)
        If OutS.GetNodeCount(False) = 1 Then
            keyOut = VB.Right(OutS.Name, Len(OutS.Name) - 4)
        Else
            Child = OutS.FirstNode
            Do
                Child = Child.NextNode
            Loop Until Child.NextNode Is Nothing
            keyOut = VB.Right(Child.Name, Len(Child.Name) - 4)
        End If
        jIn = Val(keyIn) : jOut = Val(keyOut)
        NodePin = InS.Parent
        NodePOut = OutS.Parent
        keyIn = VB.Right(NodePin.Name, Len(NodePin.Name) - 4)
        keyOut = VB.Right(NodePOut.Name, Len(NodePOut.Name) - 4)
        jBankIn = Val(keyIn)
        jBankOut = Val(keyOut)
        For i = 1 To NumIt
            If Disposiz.jcont(i) = jIn Then jcIn = i : Exit For
        Next
        For i = 1 To NumIt
            If Disposiz.jcont(i) = jOut Then jcOut = i : Exit For
        Next
        If jcOut > jcIn Then
            For i = jcIn To jcOut - 1
                Disposiz.jcont(i) = Disposiz.jcont(i + 1)
            Next
            Disposiz.jcont(jcOut) = jIn
        Else
            For i = jcIn To jcOut + 1 Step -1
                Disposiz.jcont(i) = Disposiz.jcont(i - 1)
            Next
            Disposiz.jcont(jcOut) = jIn
        End If
        If jBankIn <> jBankOut Then '
            For i = 1 To 100
                If Disposiz.Nite(jBankIn, i) = jIn Then
                    For k = i To 99
                        Disposiz.Nite(jBankIn, k) = Disposiz.Nite(jBankIn, k + 1)
                    Next
                    Exit For
                End If
            Next
            For i = 1 To 100
                If Disposiz.Nite(jBankOut, i) = jOut Then
                    For k = 100 To i + 1 Step -1
                        Disposiz.Nite(jBankOut, k) = Disposiz.Nite(jBankOut, k - 1)
                    Next
                    Disposiz.Nite(jBankOut, i) = jIn
                    Exit For
                End If
            Next
            '  CLOSPREV()
            u = objDatBase.PutBasCh(2, 2, i, 1, BankR(jBankOut), 0)
            '  Apri(Trim(job.contratto))
            If Disposiz.Nite(jBankIn, 1) = 0 Then
                BankR(jBankIn) = " "
                For i = jBankIn To NumB - 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto BankR(i). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    BankR(i) = BankR(i + 1)
                    For k = 1 To 100
                        Disposiz.Nite(i, k) = Disposiz.Nite(i + 1, k)
                    Next
                Next
                NumB = NumB - 1
            End If
            AggNITEF()
        End If
    End Sub

    Public Sub AggFrame6()
        Dim Riga, Testo As String
        Riga = GlobalRoutines.myStr(CSng(iActBank), 2, 0, True)
        If iActBank < 10 Then Riga = "0" & VB.Right(Riga, 1)
        File2 = Monitor.Motore.Inizio.Workdir + "\" + VB.Left(job.Contratto, 4) + Riga + ".PRO"
        ListView5.Items.Clear()
        If IO.File.Exists(File2) Then
            cmdVFile.Enabled = True
            cmdDisPro.Enabled = True
            cmdDatiBank.Text = "Edit"
            ListView5.Items.Add("File 'Proposal' " & File2)
            Testo = CStr(FileDateTime(File2))
            ListView5.Items.Add("modificato il " & Testo)
            cmdEliPRO.Enabled = True
        Else
            cmdVFile.Enabled = False
            cmdDisPro.Enabled = False
            cmdDatiBank.Text = "Dati"
            ListView5.Items.Add("File 'Proposal' assente")
            cmdEliPRO.Enabled = False
        End If
    End Sub
    Private Sub TreeView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
        'Set the drag node and initiate the DragDrop
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub mnuNuovoProgetto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuovoProgetto.Click
        If NonAncora Then
            If Not CheckLicenza() Then Exit Sub
            NonAncora = False
        End If
        NuoPre()
    End Sub

    Private Sub mnuCaricaProgetto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCaricaProgetto.Click
        If NonAncora Then
            If Not CheckLicenza() Then Exit Sub
            NonAncora = False
        End If
        CarPre()
    End Sub

    Private Sub mnuDatiGenerali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatiGenerali.Click
        EdiGen()
    End Sub

    Private Sub mnuInsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInsEdit.Click
        EdiIte()
    End Sub

    Private Sub mnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuElimina.Click
        EliIte()
    End Sub

    Private Sub mnuEliProgetto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliProgetto.Click
        EliPre()
    End Sub

    Private Sub mnuChiudi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChiudi.Click
        ChiPre()
    End Sub

    Private Sub mnuEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEsci.Click
        Close()
    End Sub

    Private Sub mnuDatiProcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatiProcesso.Click
        ModeAltern = 0
        DatiFun()
    End Sub

    Private Sub mnuInsEdiAltern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInsEdiAltern.Click
        NonMostrareAlt = False
        altern(0)
        '  Do
        '    DoEvents
        '  Loop While Not Monitor.Motore.InputForms Is Nothing
        '      Sommari Valido
        '     FillTree 1
    End Sub

    Private Sub mnuEliAltern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliAltern.Click
        EliAlt()
        Dim Valido As Boolean
        Sommari(Valido)
        FillTree(1)
    End Sub

    Private Sub mnuBilancio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBilancio.Click
        Bilancio()
    End Sub

    Private Sub mnuDatiCos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatiCos.Click
        DatiCos()
    End Sub

    Private Sub mnuProgSemplice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProgSemplice.Click
        AddDistinta = 2
        DatiCos()
    End Sub

    Private Sub mnuProgAutomatico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProgAutomatico.Click
        MsgBox("lAVORI IN CORSO") ' 'Progetto automatico
    End Sub

    Private Sub mnuFunzionamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFunzionamento.Click
        MsgBox("lAVORI IN CORSO") ' AddDistinta = 305: DatiCos: StudiFun 'Verifiche
    End Sub

    Private Sub mnuVentil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVentil.Click
        AddDistinta = 101 : Ventil1() 'calcolo ventilatori
    End Sub

    Private Sub mnuDatiFinali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatiFinali.Click
        OpFin() ' AddDistinta = 103: Ventil1 'Dati Finali
    End Sub

    Private Sub mnuHTRI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHTRI.Click
        AddDistinta = 106 : Ventil1()
    End Sub

    Private Sub mnuMonFasVenCom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMonFasVenCom.Click
        MonFVC() 'AddDistinta = 102: GruppIt
    End Sub

    Private Sub mnuDataSheets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDataSheets.Click
        EdiDS(0)
        'AddDistinta = 10 + Itemm
        'If Asc(job.contratto) > 32 Then
        '    SALVA
        '    CLOSPREV
        'End If
        'Catena "DSDS"
    End Sub

    Private Sub mnuMappa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMappa.Click
        Mappa()
    End Sub

    Private Sub mnuSommario1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSommario1.Click
        LanciaUPTX2()

    End Sub

    Private Sub mnuCompattamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCompattamento.Click
        Compatta()
    End Sub

    Private Sub mnuStruttura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStruttura.Click
        optTM(1).Checked = True
        Struttura()
    End Sub

    Private Sub mnuDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDB.Click
        ExamDBGen()
    End Sub

    Private Sub mnuStampe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStampe.Click
        Hstampe()
    End Sub

    Private Sub mnuFostima_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFostima.Click
        ElaboraFS()
    End Sub

    Private Sub mnuAmministrazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAmministrazione.Click
        objDatBase.Rigenera()
    End Sub

    Private Sub mnuASMEtappi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuASMEtappi.Click
        StandAlone(1)
    End Sub

    Private Sub mnuASMEobround_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuASMEobround.Click
        StandAlone(2)
    End Sub

    Private Sub mnuCoverStuds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCoverStuds.Click
        StandAlone(3)
    End Sub

    Private Sub mnuCoverThru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCoverThru.Click
        StandAlone(4)
    End Sub

    Private Sub mnuVSRtappi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVSRtappi.Click
        StandAlone(5)
    End Sub

    Private Sub mnuTubi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTubi.Click
        StandAlone(6)
    End Sub

    Private Sub mnuSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSplit.Click
        StandAlone(7)
    End Sub

    Private Sub mnuAree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAree.Click
        If Not Monitor.Motore.Aree(True) Then Exit Sub
        AggStatusB()
    End Sub

    Private Sub mnuTipiLavori_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTipiLavori.Click
        Monitor.Motore.SetLavoriSciolti(1)
    End Sub

    Private Sub mnuLibrerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLibrerie.Click
        'Call Librerie
    End Sub

    Private Sub mnuAttivaCodici_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAttivaCodici.Click
        Dim Fir As String
        mnuAttivaCodici.Checked = Not mnuAttivaCodici.Checked
        If mnuAttivaCodici.Checked Then Fir = "Si" Else Fir = "No"
        Monitor.Motore.Inizio.WriteIniFile("", "Preferenze ISA", "CodiciDB", Fir)
    End Sub

    Private Sub mnuNuoveCurve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuoveCurve.Click
        Dim Testo As String
        nuovePar = Not nuovePar
        If nuovePar Then Testo = "Si" Else Testo = "No"
        Monitor.Motore.Inizio.WriteIniFile("", "Preferenze Ventil", "NuoveParabole", Testo)
        mnuNuoveCurve.Checked = nuovePar
    End Sub

    Private Sub _cmdCalc_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_0.Click
        Call ENuovo()
        Calcol()
    End Sub

    Private Sub _cmdCalc_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_1.Click
        ENuovo()
        Buckling()
    End Sub

    Private Sub _cmdCalc_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_2.Click
        ENuovo()
        AltriCt()
    End Sub

    Private Sub _cmdCalc_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_3.Click
        ENuovo()
        AltriCs()
    End Sub

    Private Sub _cmdFun_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdFun_0.Click
        ModeAltern = 1
        DatiFun()
        ModeAltern = 0
    End Sub

    Private Sub _cmdFun_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdFun_1.Click
        ModeAltern = 1
        DatiFun()
        ModeAltern = 0

    End Sub

    Private Sub _optCamini_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optCamini_0.CheckedChanged
        optCamini_CheckedChanged(0)
    End Sub
    Public ReadOnly Property optTM(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _optTM_0
                Case 1 : Return _optTM_1
            End Select
        End Get
    End Property
    Private Sub _optCamini_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optCamini_1.CheckedChanged
        optCamini_CheckedChanged(1)
    End Sub

    Private Sub _optTM_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optTM_0.CheckedChanged
        optTM_CheckedChanged(0)
    End Sub

    Private Sub _optTM_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optTM_1.CheckedChanged
        optTM_CheckedChanged(1)
    End Sub

    Private Sub NmnuCasse0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NmnuCasse0.Click
        menuPopup(0)
    End Sub

    Private Sub NmnuCasse1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NmnuCasse1.Click
        menuPopup(1)
    End Sub

    Private Sub NmnuCasse2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NmnuCasse2.Click
        menuPopup(2)
    End Sub

    Private Sub NmnuCasse3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NmnuCasse3.Click
        menuPopup(3)
    End Sub

    Private Sub NmnuCasse4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NmnuCasse4.Click
        menuPopup(4)
    End Sub

    Private Sub cmdFull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFull.Click
        If cmdZoom.Checked Then cmdZoom.CheckState = CheckState.Checked
        Monitor.routines.DoveDisegnog.Clear(Color.White)
        Select Case FaseDisegno
            Case 0
                Proposal(iActBank)
            Case 1
                DisHeadX(1)
        End Select

    End Sub
    Friend Sub cmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim i As Short
        For i = 0 To 4 : bigmenu(i).Enabled = True : Next
        Panel1.Visible = False
        cmdZoom.CheckState = CheckState.Unchecked
        Monitor.routines = Nothing
    End Sub
End Class