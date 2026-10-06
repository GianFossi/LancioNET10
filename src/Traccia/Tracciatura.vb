Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
<Serializable()> Public Class clsTracciatura
    <Serializable()> Public Structure typDaTos
        Dim bu(,) As Char
        Dim ici() As Short
        Dim hsym() As Short
        Dim icontr() As Short
        Dim NumeroTubiSettore() As Short
        Dim NumeroTubiFila() As Short
        Dim ntus() As Short
        Dim FilaIniziale() As Short
        Dim FilaFinale() As Short
        Dim hin As Short
        Dim Hout As Short
        Dim Elimin As Short
        Dim ntubi As Short
        Dim kymax As Short
        Dim FilaCentraleStorta As Boolean
        Dim Passi4CurveVert As Boolean
        Dim CurveInPianoVert As Boolean
        Dim TipoPasso As TipiPasso ' 60ø 30ø 45ø 90ø (1-4)
        Dim PassoFascio As PassiFascio 'tipo tracciatura (1-10) passi 1,2,3,4,4,4,6,6,8,8
        Dim TipoFascio As TipiFascio '1 FIX,2 FLOAT, 3 UTUBE,4 fontana
        Dim Nrod As Short
        Dim ntira As Short
        Dim ISEAL As Short
        Dim Interf As Single 'interferenza ammessa al montaggio dei fasci a fontana
        Dim NumeroSettori As Short 'numero settori
        Dim ktotal As Short
        Dim x() As Single
        Dim xs() As Single
        Dim xf() As Single
        Dim y() As Single
        Dim dt() As Single
        Dim URTY() As Single
        Dim tagli() As Single
        Dim td(,) As Single
        Dim seal(,) As Single
        Dim runn(,) As Single
        Dim dxv As Single
        Dim Didia As Single
        Dim GapCurve As Single 'aria nelle curve dei fasci a fontana
        Dim ILFINAL As Short
        Dim cinter As Single
        Dim coriext As Single 'diametro esterno corona interna
        Dim coriint As Single 'diametro interno corona interna
        Dim cori As Single
        Dim di1 As Single
        Dim OTL As Single
        Dim Primafi As Single
        Dim Passo As Single
        Dim passoint As Single 'passo corona interna
        Dim otimp As Single
        Dim otlmax As Single
        Dim Tagl As Single
        Dim yin As Single
        Dim yout As Single
        Dim DistSuSettoHor As Single
        Dim DistSuSettoVer As Single
        Dim Varco As Single 'varco senza pause RX su fasci a fontana
        Dim di0 As Single
        Dim dtin As Single
        Dim dtout As Single
        Dim roin As Single
        Dim win As Single
        Dim roout As Single
        Dim wout As Single
        Dim y0in As Single
        Dim y0out As Single
        Dim dtubo As Single
        Dim pdiaf As Single
        Dim p1 As Single
        Dim radiu As Single
        Dim tcava As Single
        Dim Spmm As Single
        Dim Spbwg As Single
        Dim Tublu As Single
        Dim TipoTolleranza As Single
        Dim TipoGiunto As Short
        Dim matub As Short
        Dim otvec As Single
        Dim Anomal0 As Short 'angolo medio del varco
        Dim Ntot As Short
        Dim XYBLOK As Single
        Dim MassimizzaOTL As Boolean
        Dim VaporBelt As Boolean
        Dim EsistePiatto As Boolean
        Dim PassoVerticale, PassoOrizzontale As Single
        Public Sub Initialize()
            ReDim bu(200, 200)
            ReDim ici(200)
            ReDim hsym(12)
            ReDim icontr(12)
            ReDim NumeroTubiSettore(12)
            ReDim NumeroTubiFila(300)
            ReDim ntus(300)
            ReDim FilaIniziale(12)
            ReDim FilaFinale(12)
            ReDim x(300)
            ReDim xs(300)
            ReDim xf(300)
            ReDim y(300)
            ReDim dt(51)
            ReDim URTY(5)
            ReDim tagli(10)
            ReDim td(3, 60)
            ReDim seal(10, 60)
            ReDim runn(4, 60)
        End Sub
    End Structure
    <NonSerialized()> Public DaPPSM As Boolean
    <NonSerialized()> Public icount As Short
    <NonSerialized()> Public Modo As Short
    <NonSerialized()> Public Area, Diaml, Perim As Single
    <NonSerialized()> Public P0, p1 As RoutBase1.clsPunti
    <NonSerialized()> Private icome1, ocome As String
    <NonSerialized()> Private kLinee As Short
    <NonSerialized()> Private Testo As String
    <NonSerialized()> Private j As Short
    <NonSerialized()> Private xx, yy As Single
    <NonSerialized()> Private i As Short
    <NonSerialized()> Private xxmin, xxmax As Single
    <NonSerialized()> Private UCI As Single
    <NonSerialized()> Private ici As Short
    <NonSerialized()> Private Nfile, NPrivate, jj As Short
    <NonSerialized()> Private jpiu As Short
    <NonSerialized()> Private Dist As Single
    <NonSerialized()> Private iC, iC0 As Short
    <NonSerialized()> Private xmin(), xmax(), Quot() As Single
    Public Enum TipiPasso
        _60 = 1
        _30 = 2
        _45 = 3
        _90 = 4
    End Enum
    Public Enum TipiFascio
        TesteFisse = 1
        TestaFlottante = 2
        Utube = 3
        Fontana = 4
    End Enum
    Public Enum PassiFascio
        _1 = 1
        _2U = 2
        _3 = 3
        _4par = 4
        _4croce = 5
        _4U = 6
        _6 = 7
        _6U = 8
        _8 = 9
        _8U = 10
        _10 = 11
        _10U = 12
    End Enum
    Public Function diadiffe() As Single
        Dim TOLL1, TOLL2 As Short
        Dim AG As Single
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.TestaFlottante Then
            TOLL2 = 5 : AG = 10 : If DaTos(iDat).di1 > 450 Then TOLL2 = 7
            If DaTos(iDat).di1 > 600 Then TOLL2 = 10
            If DaTos(iDat).di1 > 700 Then AG = 13
            If DaTos(iDat).di1 > 1225 Then AG = 16
            If DaTos(iDat).di1 > 1375 Then TOLL2 = 12
            GiocoDiaframmi = TOLL2 + 13 + 2 * AG
        Else
            TOLL1 = 3 : If DaTos(iDat).di1 > 450 Then TOLL1 = 4
            If DaTos(iDat).di1 > 600 Then TOLL1 = 5
            If DaTos(iDat).di1 > 1375 Then TOLL1 = 7
            GiocoDiaframmi = TOLL1 + 10
        End If
        Return GiocoDiaframmi
    End Function
    Public Function Esegui(ByRef Mode As Short, ByRef icome As String) As Short
        Try
            InizializzaGen()
            Modo = Mode
            With MainForm
                Select Case Mode
                    Case -1 'genera da PPSM
                        'Load(frmTraccia)
                        gencommes = icome.Substring(0, icome.Length - 4)
                    Case 0
                        icome = gencommes.Trim
                    Case 1 'retrieve commessa esistente
                        If Prelim(icome) = 1 Then
                            Esegui = 1
                            .Dispose()
                            Exit Function
                        End If
                        .mnuPref.Enabled = False
                        .mnuApri.Enabled = False
                        iPagina = 0
                        .mnuDati_Click(Me, New System.EventArgs)
                    Case 2 'retrieve per distrk
                        If Prelim(icome) = 1 Then
                            Esegui = 1
                            .Dispose()
                            Exit Function
                        End If
                        Modo = 3
                        .mnuCalcola_Click(Me, New EventArgs)
                        .mnuDisegna_Click(Me, New EventArgs)
                        .mnu4sp_Click(Me, New EventArgs)
                    Case 3 ' non mostrare interfaccia
                        If Prelim(icome) = 1 Then Esegui = 1
                        .Dispose()
                        Exit Function
                End Select
                .ShowDialog()
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Function Prelim(ByVal icome As String) As Integer
        DaPPSM = True
        With MainForm
            .cmdApri.Visible = False
            .mnuApri.Enabled = False
            .mnuEsci.Text = rmHelpStrings.GetString("mnuEsci")
        End With
        gencommes = icome.Substring(0, icome.Length - 4)
        If Not IO.File.Exists(icome) Then
            Return 1
        Else
            Carica()
        End If
        Return 0
    End Function

    Public Sub SuperRMT(Optional ByRef Mat As String = "", Optional ByRef PSP As Single = 0, _
                        Optional ByRef Silente As Boolean = False)
        '      Dim iUnit as short
        Dim iRes As Short
        Dim FileSt As String = ""
        Dim pNet0, Mom, pLor0 As Single
        Dim pSfri As Single
        Dim Riga As String
Rifai:  SaveAll()
        If Not Silente Then If Not OpFin() Then Exit Sub
        '       iUnit = FreeFile()
        Try
            FileSt = gencommes.Trim & ".RMT"
            Monitor.Motore.PrepRapp(FileSt)
Rifai1:     If PSP > 0 Then PesoSpTubi = PSP
            locMakeRMT(gencommes.Trim & ".ADU", iRes, Mom, pNet0, pLor0, pSfri, Mat, PesoSpTubi * 0.000000001, 0, Silente) ': CLOSE #6
            If iRes = 1 Then GoTo Rifai
            Monitor.Motore.Problem.ChiudiRapp()
            If Not DaPPSM Then
                Monitor.Motore.Inizio.SuperStampa(FileSt, StubWord)
            End If
        Catch e As Exception
            If Err.Number = 70 Then
                Riga = "Autorizzazione negata ad aprire in scrittura" & vbCrLf
                Riga = Riga & "il file di stampa " & FileSt & "." & vbCrLf
                Riga = Riga & "Controllare se è occupato da Winword"
                If MsgBox(Riga, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then GoTo Rifai1
            Else
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End If
        End Try
    End Sub
    Public Sub StubMakeRMT(ByRef commes As String, ByRef iRes As Short, ByRef Mom As Single, _
                          ByRef pNet0 As Single, ByRef pLor0 As Single, ByRef pSfri As Single, _
                          ByRef Mat As String, ByRef PesoSpec As Single, ByRef Mode As Short, _
                          Optional ByRef Silente As Boolean = False, Optional ByRef lTot As Single = 0)
        locMakeRMT(commes, iRes, Mom, pNet0, pLor0, pSfri, Mat, PesoSpec, Mode, _
                   Silente, lTot)
    End Sub
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        Tracciatura = Me
        QualeCorona = 1
        myAssembly = Me.GetType.Assembly
        rmTestiTraccia = New _
           System.Resources.ResourceManager("traccia.TestiTraccia", myAssembly)
        rmHelpStrings = New _
           System.Resources.ResourceManager("traccia.ProjectResources", myAssembly)
        rmHelpTopics = New _
           System.Resources.ResourceManager("traccia.HelpTopics", myAssembly)
        GlobalRoutines = New RoutBase1.clsTrigon
    End Sub
    Public Sub Dispose()
        Tracciatura = Nothing
    End Sub
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Monitor.Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("Trac")
            With Monitor.Motore
                RadiceHelp = .Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\BIN\AiutoTraccia.chm"
                Fact = GlobalRoutines.ValVir(.Inizio.ReadIniFile("", "Preferenze Traccia", "FattStrategiaAggiancio"))
            End With
            If Fact = 0 Then Fact = 2
        End Set
    End Property
    Public Property DiametroTubo() As Single
        Get
            DiametroTubo = DaTos(iDat).dtubo
        End Get
        Set(ByVal Value As Single)
            DaTos(iDat).dt(15) = Value
        End Set
    End Property
    Public ReadOnly Property OTL() As Single
        Get
            OTL = DaTos(iDat).OTL
        End Get
    End Property
    Public Property SpessoreTubo() As Single
        Get
            SpessoreTubo = DaTos(iDat).Spmm
        End Get
        Set(ByVal Value As Single)
            DaTos(iDat).dt(24) = Value
        End Set
    End Property
    Public Property NumeroTubi() As Single
        Get
            NumeroTubi = DaTos(iDat).ktotal
        End Get
        Set(ByVal Value As Single)
            DaTos(iDat).dt(11) = Value
        End Set
    End Property
    Public Property TipoFascio() As TipiFascio
        Get
            TipoFascio = DaTos(iDat).TipoFascio
        End Get
        Set(ByVal Value As TipiFascio)
            DaTos(iDat).TipoFascio = Value
            DaTos(iDat).dt(14) = CSng(Value)
        End Set
    End Property
    Public Property TipoPasso() As Short
        Get
            Select Case DaTos(iDat).TipoPasso
                Case TipiPasso._30, TipiPasso._60 : TipoPasso = 2 'triangolare
                Case TipiPasso._45, TipiPasso._90 : TipoPasso = 1 'quadrato
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case Value
                Case 1 : DaTos(iDat).TipoPasso = TipiPasso._30
                Case 2 : DaTos(iDat).TipoPasso = TipiPasso._90
            End Select
            DaTos(iDat).dt(12) = CSng(DaTos(iDat).TipoPasso)
        End Set
    End Property
    Public Property Passo() As Single
        Get
            Passo = DaTos(iDat).Passo
        End Get
        Set(ByVal Value As Single)
            DaTos(iDat).dt(16) = Value
        End Set
    End Property
    Public Property LunghezzaTubi() As Single
        Get
            LunghezzaTubi = DaTos(iDat).Tublu
        End Get
        Set(ByVal Value As Single)
            DaTos(iDat).dt(26) = Value
        End Set
    End Property
    Public Property RaggioMinimo() As Single
        Get
            If DaTos(iDat).TipoFascio = TipiFascio.TesteFisse Or DaTos(iDat).TipoFascio = TipiFascio.TestaFlottante Then
                RaggioMinimo = 0
            Else
                RaggioMinimo = DaTos(iDat).radiu
            End If
        End Get
        Set(ByVal Value As Single)
            DaTos(iDat).dt(21) = Value
        End Set
    End Property
    Sub DisTrk(ByRef icome As String, ByRef ocome As String, ByRef Mode As Short, ByRef Mode1 As Short, Optional ByRef Tipo As Short = 0)
        'Mode 0 senza quote;Mode 1 completo
        'Mode1 0 prima volta, 1 zoom
        'Tipo 2 DXF 4 RTF
        Dim dtempo As Single
        Dim PU0, factq As Single
        Dim PU6, PU7 As Single
        Dim TestoQuota As String = ""
        Dim PU8, PU9 As Single
        Dim PU10, PU11 As Single
        Dim RaggioShell As Single
        Dim difbaf, rotl, rdiaf As Single
        Dim DDIA, PSCAME As Single
        Dim AL As Single
        Dim ISU, isym, IGU As Short
        Dim k, j As Short
        Dim Testo, odiStr As String
        Dim IPRI As Short
        Dim xx, yy As Single
        Dim RJM, RJU, RJP As Single
        Dim QJM, QJU, QJP As Single
        Dim ici, i As Short
        Dim RDIS, RDI As Single
        Dim YARC, XARC, XYARC As Single
        Dim XT, RDI2, YT As Single
        Dim RUNX, RRO, RUNY As Single
        Dim catx, SEA2, caty As Single
        Dim sgx As Short
        Dim PX1, PX2 As Single
        Dim PX8, PX3, PX4, PX9 As Single
        Dim PY9, PY1, PY8, PX5 As Single
        Dim PY4, PY2, PY3, PY5 As Single
        Dim PXY2, PXY1, PXY3 As Single
        Dim PXY5, PXY4, F4 As Single
        Dim x1, y1 As Single
        Dim x2, y2 As Single
        Dim odi, DISVER, ppi As Single
        Dim VALI, SOMMA As Single
        Dim SNTUB As Short
        Dim tempo As Short
        Dim nDat, lociDat As Short
        Select Case Monitor.Routines.SwIUNpri
            Case 2 : tempo = 1
            Case 4, 5 : tempo = 1
            Case Else : tempo = 0
        End Select
        If Monitor.Routines.SwIUNpri < 4 Then MainForm.g.Clear(Color.White)
        xcsi = 0 : ypsi = 0
        If Mode1 = 0 Then
            Call scalavi(1.2)
            MainForm.g.Clear(Color.White)
        End If
        Call Monitor.Routines.refere(0, 0, 0)
        If (DaTos(0).tagli(4) <> 0 And DaTos(0).tagli(9) < 3.0!) Then DaTos(0).tagli(9) = DaTos(0).tagli(9) + 2
        DaTos(0).ntubi = DaTos(0).ktotal
        PU0 = Monitor.Routines.poynt(0.0!, 0.0!)
        RaggioShell = DaTos(0).di1 / 2.0!
        If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.45) Else Call Monitor.Routines.ctrait(0, 0.1)
        Monitor.Routines.cerc(0, 0, RaggioShell)
        Call Monitor.Routines.ctrait(2, 0.1)
        For AL = 0 To 360 Step 90 : Monitor.Routines.seg2(PU0, RaggioShell + 15, AL) : Next
        rotl = DaTos(0).OTL / 2 '(2 * DaTos(lociDat).frs)
        If Mode = 1 Then Monitor.Routines.cerc(0, 0, rotl)
        difbaf = difdia(DaTos(0).di1)
        rdiaf = ((DaTos(0).di1 - difbaf) / 2.0!) ' / DaTos(lociDat).frs
        If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.45) Else Call Monitor.Routines.ctrait(0, 0.1)
        Monitor.Routines.cerc(0, 0, rdiaf)
        DDIA = DaTos(0).di1 - difbaf
        PU6 = Monitor.Routines.poynt(0, RaggioShell)
        PU7 = Monitor.Routines.poynt(0, -RaggioShell)
        PU8 = Monitor.Routines.poynt(0, rdiaf)
        PU9 = Monitor.Routines.poynt(0, -rdiaf)
        PU10 = Monitor.Routines.poynt(0, rotl)
        PU11 = Monitor.Routines.poynt(0, -rotl)
        If tempo > 0 Then Monitor.Motore.Avanzamento = Monitor.Motore.Avanzamento + 10 / tempo
        '     TUBE LAYOUT**************************
        nDat = 0 : If DaTos(0).TipoFascio = TipiFascio.Fontana Then nDat = 1
        Try
            For lociDat = 0 To nDat
                If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4)
                isym = 1
                PSCAME = DaTos(lociDat).Passo / 4 ' (4! * DaTos(lociDat).frs)
                k = 0
10:             k = k + 1
                ISU = 0 : IGU = 0
                For j = DaTos(lociDat).FilaIniziale(k) To DaTos(lociDat).FilaFinale(k)
                    If (DaTos(lociDat).NumeroTubiFila(j) = 0) Then ISU = ISU + 1 Else Exit For
                Next
                For j = DaTos(lociDat).FilaFinale(k) To DaTos(lociDat).FilaIniziale(k) Step -1
                    If (DaTos(lociDat).NumeroTubiFila(j) = 0) Then IGU = IGU + 1 Else Exit For
                Next
                QualeCorona = lociDat + 1
                For j = DaTos(lociDat).FilaIniziale(k) To DaTos(lociDat).FilaFinale(k)
                    IPRI = 0
                    xx = DaTos(lociDat).x(j) ' / DaTos(lociDat).frs
                    yy = DaTos(lociDat).y(j) ' / DaTos(lociDat).frs
                    RJU = DaTos(lociDat).xs(j) ' / DaTos(lociDat).frs
                    If j > DaTos(lociDat).FilaIniziale(k) Then RJM = DaTos(lociDat).xs(j - 1) Else RJM = 9999
                    If j < DaTos(lociDat).FilaFinale(k) Then RJP = DaTos(lociDat).xs(j + 1) Else RJP = 9999
                    QJU = DaTos(lociDat).xf(j) ' / DaTos(lociDat).frs
                    If j > DaTos(lociDat).FilaIniziale(k) Then QJM = DaTos(lociDat).xf(j - 1) Else QJM = -9999
                    If j < DaTos(lociDat).FilaFinale(k) Then QJP = DaTos(lociDat).xf(j + 1) Else QJP = -9999
                    ici = DaTos(lociDat).ici(j) ' GlobalRoutines.ValVir(Mid$(Testo, 1, 7))
                    For i = 1 To ici
                        If DaTos(lociDat).bu(j, i) <> "1" Then GoTo 40
                        'nella prima e ultima fila   con qualche tubo
                        If j = DaTos(lociDat).FilaIniziale(k) + ISU Or j = DaTos(lociDat).FilaFinale(k) - IGU Then GoTo 88
                        'primo e ultimo tubo
                        If (xx = RJU Or xx = QJU Or i = ici) Then GoTo 88
                        'fine settore
                        If i < ici Then If DaTos(lociDat).bu(j, i + 1) = "9" Then GoTo 88
                        'inizio settore
                        If i > 1 Then If DaTos(lociDat).bu(j, i - 1) = "9" Then GoTo 88
                        If j > DaTos(lociDat).FilaIniziale(k) Then
                            If (DaTos(lociDat).NumeroTubiFila(j - 1) = 0) Then GoTo 88
                            If AssenteVicino(xx, j - 1, lociDat) Then GoTo 88
                        End If
                        If j < DaTos(lociDat).FilaFinale(k) Then
                            If (DaTos(lociDat).NumeroTubiFila(j + 1) = 0) Then GoTo 88
                            If AssenteVicino(xx, j + 1, lociDat) Then GoTo 88
                        End If
                        If (DaTos(lociDat).TipoFascio = TipiFascio.Utube And DaTos(lociDat).PassoFascio = 2) Then
                            If (xx < 0 And xx - RJM < 0.5) Then GoTo 88
                            If (xx > 0 And xx - QJM > -0.5) Then GoTo 88
                        Else
                            If (xx < 0 And yy < 0 And xx - RJM < 0.5) Then GoTo 88
                            If (xx < 0 And yy > 0 And xx - RJP < 0.5) Then GoTo 88
                            If (xx > 0 And yy < 0 And xx - QJM > -0.5) Then GoTo 88
                            If (xx > 0 And yy > 0 And xx - QJP > -0.5) Then GoTo 88
                        End If
                        If Not (i > ici - 2) Then ' GoTo 87
                            If DaTos(lociDat).bu(j, i + 1) = "0" And DaTos(lociDat).bu(j, i + 2) = "0" Then GoTo 88
                        End If
                        If Not (i < 3) Then ' GoTo 87 'ERA 2
                            If DaTos(lociDat).bu(j, i - 1) = "0" And DaTos(lociDat).bu(j, i - 2) = "0" Then GoTo 88
                        End If
                        Dim ii As Integer
                        Dim Log1 As Boolean = False
                        For ii = i + 2 To DaTos(lociDat).ici(j)
                            If DaTos(lociDat).bu(j, ii) = "1" Then Log1 = True : Exit For
                        Next
                        If i = ici Or i < ici And DaTos(lociDat).bu(j, i + 1) = "0" And Not Log1 Then GoTo 88
                        If (IPRI = 0) Then GoTo 88
                        GoTo 37
88:                     If isym = -1 And DaTos(lociDat).FilaCentraleStorta And j = DaTos(lociDat).kymax Then xx = -xx
                        If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4)
                        Monitor.Routines.cerc(xx, yy * isym, DaTos(lociDat).dtubo / 2)
                        If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.18)
                        Monitor.Routines.CLIN(xx, yy * isym, PSCAME, alfajp(DaTos(lociDat).TipoPasso))
                        If isym = -1 And DaTos(lociDat).FilaCentraleStorta And j = DaTos(lociDat).kymax Then xx = -xx
                        IPRI = 1
                        GoTo 40
35:                     If DaTos(lociDat).bu(j, i) <> "1" Then GoTo 40
37:                     If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.18)
                        Monitor.Routines.CLIN(xx, yy * isym, PSCAME, alfajp(DaTos(lociDat).TipoPasso))
                        '37 PU = poynt(XX, YY * ISYM)
40:                     If DaTos(lociDat).bu(j, i + 1) <> "9" Then ' 45
                            xx = xx + DaTos(lociDat).PassoOrizzontale
                        Else
                            i = i + 1
                            xx = -xx
                        End If
                    Next i 'IF (i < ici) THEN 20
                    If tempo > 0 Then
                        dtempo = 70 / tempo
                        If isym = 1 Then dtempo = dtempo / 2
                        dtempo = dtempo / (DaTos(lociDat).FilaFinale(k) + DaTos(lociDat).FilaIniziale(k) + 1) / DaTos(lociDat).NumeroSettori
                        Monitor.Motore.Avanzamento = Monitor.Motore.Avanzamento + dtempo
                    End If
80:             Next
                If (isym <> 1) Then GoTo 200
                If (DaTos(lociDat).hsym(k) <> 2) Then GoTo 100
                If (DaTos(lociDat).TipoFascio = TipiFascio.Utube And DaTos(lociDat).PassoFascio = PassiFascio._2U) Then GoTo 86 '85
                k = k + 1
                GoTo 100
86:             isym = -1
                k = k - 1
100:            If (k < DaTos(lociDat).NumeroSettori) Then GoTo 10
                Call Monitor.Routines.HCOTE(3)
                If lociDat = 1 Then Monitor.Routines.cerc(0, 0, DaTos(1).OTL / 2)
                CalcOTL(lociDat)
200:            If (DaTos(lociDat).cinter > 2.0!) Then
                    Monitor.Routines.cerc(0.0!, 0.0!, DaTos(lociDat).cinter) '/ 2 ' / (2! * DaTos(lociDat).frs))
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        '     ***************TIRANTI DISTANZIATORI*********************
        Try
            For lociDat = 0 To nDat
208:            For j = 1 To DaTos(lociDat).ntira
                    If (DaTos(lociDat).td(1, j) = 0 And DaTos(lociDat).td(2, j) = 0.0!) Then GoTo 210
209:                RDIS = DaTos(lociDat).td(3, j) / 2 ' (DaTos(lociDat).frs * 2!)
                    RDI = DaTos(lociDat).dtubo / 2 'RDIS - 3! ' / DaTos(lociDat).frs
                    XARC = DaTos(lociDat).td(1, j) ' / DaTos(lociDat).frs
                    YARC = DaTos(lociDat).td(2, j) ' / DaTos(lociDat).frs
                    XYARC = YARC
                    If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4)
                    Monitor.Routines.cerc(XARC, YARC, RDI)
                    Monitor.Routines.cerc(XARC, YARC, RDIS)
                    Call Monitor.Routines.ctrait(2, 0.1)
                    Monitor.Routines.CLIN(XARC, YARC, 1.2 * RDIS, alfajp(DaTos(lociDat).TipoPasso))
210:            Next
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        lociDat = 0
        Try
295:        If DaTos(lociDat).tagli(9) <> 0 Then
                '     ***************TAGLI DIAFRAMMI***************************
                '     TAGL() 1:PRIMO VALORE     2:SECONDO
                '
                '     TAGL() 3:PRIMO VALORE     4:SECONDO
                '
                '     TAGL() 5:X    6:Y        APERTURA SUPPORTO
                '            7:X    8:Y        TAGLI NORMALI
                '
                '     TAGL() 9: TIPO TAGLIO 0 NO TAGLIO 1H  2V
                '         10: TIPO TAGLIO SUPPORTO 0 NO 1 NORMALE 2 45 GRADI
                ' **************************************************************
                RDI2 = rdiaf ^ 2
                j = 0
                Do
                    j = j + 1
                    If (DaTos(lociDat).tagli(j) = 0.0!) Then Exit Do
                    If (DaTos(lociDat).tagli(9) = 1 Or DaTos(lociDat).tagli(9) = 3.0!) Then
                        '           TAGLIO ORIZZONTALE
                        YT = DaTos(lociDat).tagli(j) ' / DaTos(lociDat).frs
                        XT = System.Math.Sqrt(RDI2 - YT ^ 2)
                        If Mode = 1 Then Call Monitor.Routines.ctrait(1, 0.3) Else Call Monitor.Routines.ctrait(1, 0.1)
                        Monitor.Routines.segm(XT, YT, -XT, YT)
                    End If
                    If (DaTos(lociDat).tagli(9) = 2 Or DaTos(lociDat).tagli(9) = 4.0!) Then
                        '           TAGLIO VERTICALE
                        XT = DaTos(lociDat).tagli(j) ' / DaTos(lociDat).frs
                        YT = System.Math.Sqrt(RDI2 - XT ^ 2)
                        If Mode = 1 Then Call Monitor.Routines.ctrait(1, 0.3) Else Call Monitor.Routines.ctrait(1, 0.1)
                        Monitor.Routines.segm(XT, YT, XT, -YT)
                    End If
                Loop
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        '--------------CALL TACCHE
        '     ************************TONDI DI SCORRIMENTO********************
        '     DaTos(lociDat).runn(4,5)1:X   2:Y  3:ALFA  4:DIA   NROD:NUMERO RUNNERS
        Try
            For j = 1 To DaTos(lociDat).Nrod
                RRO = DaTos(lociDat).runn(4, j) / 2 ' (DaTos(lociDat).frs * 2)
                If (DaTos(lociDat).runn(1, j) = 0 And DaTos(lociDat).runn(2, j) = 0.0!) Then GoTo 330
                RUNX = DaTos(lociDat).runn(1, j) ' / DaTos(lociDat).frs
                RUNY = DaTos(lociDat).runn(2, j) ' / DaTos(lociDat).frs
                If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4)
                Monitor.Routines.cerc(RUNX, RUNY, RRO)
                Call Monitor.Routines.ctrait(2, 0.1)
                Monitor.Routines.CLIN(RUNX, RUNY, 1.2 * RRO, System.Math.PI / 2)
330:        Next
            '     ********************SEALING STRIPS******************************
            For j = 1 To DaTos(lociDat).ISEAL
                SEA2 = DaTos(lociDat).seal(3, j) '/ (2 * DaTos(lociDat).frs)
                sgx = System.Math.Sign(DaTos(lociDat).seal(1, j))
                '            sgy = Sgn(DaTos(lociDat).SEAL(2, j))
                '            IF (DaTos(lociDat).seal(10, j) = -6) THEN
                catx = SEA2 * System.Math.Sin(DaTos(lociDat).seal(7, j))
                caty = SEA2 * System.Math.Cos(DaTos(lociDat).seal(7, j))
                PX1 = DaTos(lociDat).seal(1, j) + catx ' / DaTos(lociDat).frs) + catx
                PX2 = PX1 - 2 * catx
                PX8 = (DaTos(lociDat).seal(1, j)) ' / DaTos(lociDat).frs)
                PX3 = (DaTos(lociDat).seal(8, j)) - catx ' / DaTos(lociDat).frs) - catx
                PX9 = (DaTos(lociDat).seal(8, j)) ' / DaTos(lociDat).frs)
                PX4 = PX3 + 2 * catx
                PY1 = (DaTos(lociDat).seal(2, j) - caty) ' / DaTos(lociDat).frs) - caty
                PY8 = (DaTos(lociDat).seal(2, j)) ' / DaTos(lociDat).frs)
                'PY8 = (-2 * SGY + DaTos(lociDat).seal(2, J) / DaTos(lociDat).frs)
                PY2 = PY1 + 2 * caty
                PY3 = (DaTos(lociDat).seal(9, j) + caty) ' / DaTos(lociDat).frs) + caty
                PY9 = (DaTos(lociDat).seal(9, j)) ' / DaTos(lociDat).frs)
                'PY9 = (-2 * SGY + DaTos(lociDat).seal(9, J) / DaTos(lociDat).frs)
                PY4 = PY3 - 2 * caty
                '            END IF
                PXY1 = PY1
                PXY2 = PY2
                PXY3 = PY3
                PXY4 = PY4
                PXY5 = PY5 'PY5 chi è?
                If (DaTos(lociDat).tagli(9) = 2.0!) Then F4 = 1.0!
                If (DaTos(lociDat).tagli(9) = 4 And PX1 > 0.0!) Then F4 = -1.0!
                If (DaTos(lociDat).tagli(9) = 4 And PX1 < 0.0!) Then F4 = 1.0!
                If (DaTos(lociDat).tagli(9) = 2 Or DaTos(lociDat).tagli(9) = 4.0!) Then
                    PXY1 = -PX1 * F4
                    PXY2 = -PX2 * F4
                    PXY3 = -PX3 * F4
                    PXY4 = -PX4 * F4
                    PXY5 = -PX5 * F4 'PX5 chi è?
                End If
                If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4) Else Call Monitor.Routines.ctrait(0, 0.1)
                Monitor.Routines.segm(PX1, PY1, PX2, PY2)
                Monitor.Routines.segm(PX2, PY2, PX3, PY3)
                Call Monitor.Routines.ctrait(2, 0.1)
                Monitor.Routines.segm(PX8, PY8, PX9, PY9)
                If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4) Else Call Monitor.Routines.ctrait(0, 0.1)
                Monitor.Routines.segm(PX4, PY4, PX1, PY1)
                Monitor.Routines.segm(PX3, PY3, PX4, PY4)
                '            IF (DaTos(lociDat).seal(10, j) <> -1 AND DaTos(lociDat).seal(10, j) <> -6!) THEN Se = segm(PX4, PY4, PX5, PY5)
334:        Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        '     ********************PIATTO D'URTO*******************************
        '     DaTos(lociDat).URTY() 1:DIST Y DA CL A FILO INFERIORE PIATTO D'URTO
        '     2: LARGHEZZA 3: SPESSORE
        '
        If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4) Else Call Monitor.Routines.ctrait(0, 0.1)
        If (DaTos(lociDat).URTY(1) = 0.0!) Then GoTo 500
        x1 = -DaTos(lociDat).URTY(2) / 2 ' (2 * DaTos(lociDat).frs)
        x2 = -x1
        y1 = DaTos(lociDat).URTY(1) ' / DaTos(lociDat).frs
        y2 = y1 + DaTos(lociDat).URTY(3) ' / DaTos(lociDat).frs
        Monitor.Routines.segm(x1, y1, x2, y1)
        Monitor.Routines.segm(x2, y1, x2, y2)
        Monitor.Routines.segm(x2, y2, x1, y2)
        Monitor.Routines.segm(x1, y2, x1, y1)
        If tempo > 0 Then Monitor.Motore.Avanzamento = Monitor.Motore.Avanzamento + 5 / tempo
500:    If Mode = 0 Then GoTo FineT
        If Mode = 1 Then Call Monitor.Routines.ctrait(0, 0.4) Else Call Monitor.Routines.ctrait(0, 0.1)
        Call Monitor.Routines.HCOTE(3)
        i = 1
        If Tipo = 4 Then i = 2
        factq = 2.5
        DISVER = RaggioShell + 54 * factq ' * scalu
        If i = 2 Then
            Monitor.Routines.ql2(PU6, PU7, 2, -DISVER, TestoQuota, "Di CORPO ", " I.D. SHELL")
            Monitor.Routines.ql2(PU8, PU9, 2, -DISVER + 7 * factq, TestoQuota, "D DIAFRAMMI ", " O.D. BAFFLES")
        Else
            Monitor.Routines.ql2(PU6, PU7, 2, -DISVER, TestoQuota, "D.I. CORPO ", " I.D. SHELL")
            Monitor.Routines.ql2(PU8, PU9, 2, -DISVER + 7 * factq, TestoQuota, "D. DIAFRAMMI ", " O.D. BAFFLES")
        End If
        Monitor.Routines.ql2(PU10, PU11, 2, -DISVER + 14 * factq, TestoQuota, "O.T.L. ", "")
        '--------------------------- ITALIANO ------------------------
        If (DaTos(lociDat).TipoTolleranza <> 1) Then Testo = " MIN. WALL   L=" Else Testo = " AV. WALL   L="
        If i = 2 Then
            Testo = "N° " & Str(DaTos(lociDat).ktotal) & " TUBI "
        Else
            Testo = "N%%d " & Str(DaTos(lociDat).ktotal) & " TUBI "
        End If
        If (DaTos(lociDat).TipoFascio = TipiFascio.Utube) Then Testo = Testo & "AD U "
        If i = 2 Then
            Testo = Testo & "d " & Str(DaTos(lociDat).dtubo) & " x" & Str(DaTos(lociDat).Spmm)
        Else
            Testo = Testo & "%%c " & Str(DaTos(lociDat).dtubo) & " x" & Str(DaTos(lociDat).Spmm)
        End If
        Testo = Testo & " L=" & Str(DaTos(lociDat).Tublu)
        Monitor.Routines.ECRIR(Testo)
510:    Monitor.Routines.texte0(-RaggioShell, RaggioShell + 40 * i * factq, 0.0!, 3, 0.1)
        Select Case DaTos(lociDat).TipoGiunto
            Case 1 : Testo = " SALDATI E MANDRINATI "
            Case 2 : Testo = " SALDATI E MANDRINATI LEGGERMENTE "
            Case 3 : Testo = " MANDRINATI "
        End Select
        Testo = "PASSO   " & Str(DaTos(lociDat).Passo) & Testo
        Monitor.Routines.ECRIR(Testo)
520:    Monitor.Routines.texte0(-RaggioShell, RaggioShell + 35 * i * factq, 0, 3, 0.1)
        '--------------------------- INGLESE ------------------------
        If i = 2 Then
            Testo = "N° " & Str(DaTos(lociDat).ktotal)
        Else
            Testo = "N%%d " & Str(DaTos(lociDat).ktotal)
        End If
        If (DaTos(lociDat).TipoFascio = TipiFascio.Utube) Then Testo = Testo & " U"
        odi = Monitor.Routines.roundb(3, DaTos(lociDat).dtubo / 25.4)
        odiStr = LTrim(Str(odi)) : If odi < 1 Then odiStr = "0" & odiStr
        Testo = Testo & " TUBES  O.D. " & odiStr
        Testo = Testo & Chr(34) & " x" & Str(DaTos(lociDat).Spbwg) & " BWG"
        Testo = Testo & Str(DaTos(lociDat).Tublu)
        With Monitor.Routines
            .ECRIR(Testo)
530:        .texte0(-RaggioShell, RaggioShell + 30 * i * factq, 0, 3, 0.1)
            Select Case DaTos(lociDat).TipoGiunto
                Case 1 : Testo = " WELDED AND EXPANDED "
                Case 2 : Testo = " WELDED AND LIGHTLY EXPANDED "
                Case 3 : Testo = " EXPANDED "
            End Select
            ppi = .roundb(3, DaTos(lociDat).Passo / 25.4)
            odiStr = LTrim(Str(ppi)) : If ppi < 1 Then odiStr = "0" & odiStr
            Testo = "PITCH    " & odiStr & Chr(34) & Testo
            .ECRIR(Testo)
            .texte0(-RaggioShell, RaggioShell + 25 * i * factq, 0, 3, 0.1)
            If tempo > 0 Then Monitor.Motore.Avanzamento = Monitor.Motore.Avanzamento + 5 / tempo
            If Tracciatura.Diaml > 0 Then
                .ECRIR("Calcolo di DL=4 S/p")
                .texte0(-RaggioShell, RaggioShell + 20 * i * factq, 0, 3, 1)
                .ECRIR("Area  = " & GlobalRoutines.myStr((Tracciatura.Area), 7, 2, False) & " [mm2]")
                .texte0(-RaggioShell, RaggioShell + 15 * i * factq, 0, 3, 0.1)
                .ECRIR("Perim = " & GlobalRoutines.myStr((Tracciatura.Perim), 7, 2, False) & " [mm]")
                .texte0(-RaggioShell, RaggioShell + 10 * i * factq, 0, 3, 0.1)
                .ECRIR("DL    = " & GlobalRoutines.myStr((Tracciatura.Diaml), 7, 2, False) & " [mm]")
                .texte0(-RaggioShell, RaggioShell + 5 * i * factq, 0, 3, 0.1)
            End If
        End With
        For lociDat = 0 To nDat
            VALI = RaggioShell + 30 * factq '* scalu
            If lociDat = 1 Then VALI = -VALI
            SOMMA = 0
            j = 1
            For k = 1 To DaTos(lociDat).kymax
                '            If lociDat = 0 Then
                If k Mod 2 = 1 Then VALI = VALI - 10 * factq Else VALI = VALI + 10 * factq
                '            Else
                '               If k Mod 2 = 1 Then VALI = VALI + 10 * factq Else VALI = VALI - 10 * factq
                '            End If
                If (DaTos(lociDat).NumeroTubiFila(k) = 0) Then GoTo 499
                SNTUB = DaTos(lociDat).NumeroTubiFila(k)
                If (DaTos(lociDat).hsym(j) = 2 And DaTos(lociDat).TipoFascio <> TipiFascio.Utube) Then SNTUB = SNTUB * 2
                Monitor.Routines.ECRIR(Str(SNTUB))
                Monitor.Routines.texte0(-VALI, DaTos(lociDat).y(k) + 7, 0, 3, 0.1)
                SOMMA = SOMMA + DaTos(lociDat).NumeroTubiFila(k)
                If (SOMMA <> DaTos(lociDat).NumeroTubiSettore(j)) Then GoTo 499
                SOMMA = 0
                If (DaTos(lociDat).hsym(j) = 2) Then j = j + 2 Else j = j + 1
499:        Next
        Next lociDat
        '1998      orpax = -RaggioShell + 17 + (i - 1) * 6 * factq: orpay = RaggioShell + (-6 + 40) * i * factq
        '      poli orpax, orpay, DaTos(lociDat).TipoPasso, i
FineT:
        Monitor.Routines.refabs()
        MainForm.Picture1.Refresh()
        Exit Sub
    End Sub
    Public Sub Scrivi()
        SaveAll()
    End Sub
    Public Sub ScriviTraccia(ByRef File As String, ByRef Text As String, ByRef Ext As String, ByRef Mode As Short, ByRef Tipo As Short, ByRef liout As IO.StreamWriter)
        Monitor.Motore.ProgrInizio(Text)
        With Monitor.Routines
            .ApriPri(File, Ext, Mode, Tipo, "", , , liout)
            DisTrk(RTrim(gencommes) & ".TRK", RTrim(gencommes), 1, 0, Tipo)
            If icount > 0 Then DisTEMA(icount)
            Monitor.Motore.Avanzamento = 99
            .ChiudiPRI()
            .SwIUNpri = 0
            If Tipo = 4 And liout Is Nothing Then Monitor.Motore.Inizio.SuperStampa(RTrim(gencommes) & "T.RTF", StubWord)
        End With
        Monitor.Motore.ProgrAmmazza()
    End Sub
    Public Sub Calc4SsP(ByRef icome As String, ByRef Mode As Short)
        ReDim xmin(DaTos(iDat).kymax)
        ReDim xmax(DaTos(iDat).kymax)
        icount = 0
        Try
            For j = 1 To DaTos(iDat).kymax
                xx = DaTos(iDat).x(j) - DaTos(iDat).PassoOrizzontale : yy = DaTos(iDat).y(j)
                UCI = DaTos(iDat).ici(j) ' GlobalRoutines.ValVir(Mid$(Testo, 1, 7))
                ici = UCI
                xmin(j) = 1.0E+20 : xmax(j) = -1.0E+20
                For i = 1 To ici
                    If DaTos(iDat).bu(j, i) = "9" Then
                        xx = -xx - DaTos(iDat).PassoOrizzontale
                    Else
                        xx = xx + DaTos(iDat).PassoOrizzontale
                    End If
                    If DaTos(iDat).bu(j, i) = "1" Then
                        If xx < xmin(j) Then xmin(j) = xx
                        If xx > xmax(j) Then xmax(j) = xx
                    End If
                Next i
            Next
            P0 = New RoutBase1.clsPunti
            p1 = New RoutBase1.clsPunti
            P0.Inizia(2 * DaTos(iDat).kymax + 2)
            p1.Inizia(2 * DaTos(iDat).kymax + 2)
            Nfile = DaTos(iDat).kymax
            ReDim Quot(Nfile)
            For j = 1 To Nfile : Quot(j) = DaTos(iDat).y(j) : Next
            j = 1
            Do
                If j > Nfile Then Exit Do
                If xmin(j) = 1.0E+20 Or xmax(j) = -1.0E+20 Then
                    Nfile = Nfile - 1
                    If j = DaTos(iDat).kymax Then Exit Do
                    For jj = j To Nfile
                        xmin(jj) = xmin(jj + 1)
                        xmax(jj) = xmax(jj + 1)
                        Quot(jj) = Quot(jj + 1)
                    Next
                Else
                    j = j + 1
                End If
            Loop
            j = 1 : jpiu = 1
50:         Do
                Select Case j
                    Case Nfile
                        If DaTos(iDat).CurveInPianoVert Then
                            Generico()
                            Perim = Perim + 2 * System.Math.Abs(Quot(j))
                            Exit Do
                        Else
                            Area = Area + (xmax(j) - xmin(j)) * System.Math.Abs(Quot(j))
                            Perim = Perim + xmax(j) - xmin(j)
                            icount = icount + 1
                            P0.Punti.Item(icount + 1).TextData.X = 0
                            P0.Punti.Item(icount + 1).TextData.y = Quot(j)
                            p1.Punti.Item(icount + 1).TextData.X = P0.Punti.Item(icount + 1).TextData.X
                            p1.Punti.Item(icount + 1).TextData.y = P0.Punti.Item(icount + 1).TextData.y
                            icount = icount + 1
                            P0.Punti.Item(icount + 1).TextData.X = xmax(j)
                            p1.Punti.Item(icount + 1).TextData.X = xmin(j)
                            P0.Punti.Item(icount + 1).TextData.y = Quot(j)
                            p1.Punti.Item(icount + 1).TextData.y = Quot(j)
                        End If
                    Case 1
                        Area = (xmax(j) - xmin(j)) * System.Math.Abs(Quot(j))
                        Perim = xmax(j) - xmin(j)
                        P0.Punti.Item(1).TextData.X = 0
                        P0.Punti.Item(1).TextData.y = Quot(j)
                        p1.Punti.Item(1).TextData.X = P0.Punti.Item(1).TextData.X
                        p1.Punti.Item(1).TextData.y = P0.Punti.Item(1).TextData.y
                        P0.Punti.Item(2).TextData.X = xmax(j)
                        p1.Punti.Item(2).TextData.X = xmin(j)
                        P0.Punti.Item(2).TextData.y = Quot(j)
                        p1.Punti.Item(2).TextData.y = Quot(j)
                        icount = 1
                    Case Else
                        If Quot(j) * Quot(j - jpiu) <= 0 Then
                            If jpiu = -1 Then Exit Do
                            jpiu = -1
                            j = Nfile
                            iC0 = icount
                            GoTo Cont
                        End If
                        Generico()
                End Select
                j = j + jpiu
                If j > Nfile Then Exit Do
Cont:       Loop
            If DaTos(iDat).CurveInPianoVert Then
                icount = icount + 1
                P0.Punti.Item(icount + 1).TextData.X = P0.Punti.Item(icount).TextData.X
                p1.Punti.Item(icount + 1).TextData.X = p1.Punti.Item(icount).TextData.X
                P0.Punti.Item(icount + 1).TextData.y = 0
                p1.Punti.Item(icount + 1).TextData.y = 0
            Else
                For iC = iC0 + 1 To icount - (icount - iC0) \ 2
                    P0.SWAP(iC + 1, icount - (iC - iC0) + 2)
                    p1.SWAP(iC + 1, icount - (iC - iC0) + 2)
                Next
            End If
            icount = icount + 1
            P0.Punti.Item(icount + 1).TextData.X = 0
            P0.Punti.Item(icount + 1).TextData.y = 0
            Diaml = 4 * Area / Perim
        Catch e As Exception
            If Err.Number = 62 Then
                Testo = "File tracciatura corrotto." & vbCrLf & "(" & icome1 & ")" & vbCrLf
                Testo = Testo & "Non è quindi possibile calcolare il va-" & vbCrLf
                Testo = Testo & "lore esatto di Dl"
                MsgBox(Testo, MsgBoxStyle.OKOnly + MsgBoxStyle.Information)
                Tracciatura.Diaml = 0
            Else
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End If
        End Try
        If Not Mode = 0 Then
            datiout(1)
            If Not iPagina = -1 Then DisTrk(icome1, ocome, 1, 0)
            DisTEMA(icount)
        End If
    End Sub
    Private Sub Generico()
        xxmin = xmin(j)
        Do Until xxmin + DaTos(iDat).PassoOrizzontale > xmin(j - jpiu) + 0.1
            xxmin = xxmin + DaTos(iDat).PassoOrizzontale
        Loop
        xxmax = xmax(j)
        Do Until xxmax - DaTos(iDat).PassoOrizzontale < xmax(j - jpiu) - 0.1
            xxmax = xxmax - DaTos(iDat).PassoOrizzontale
        Loop
        Perim = Perim + xxmin - xmin(j)
        Area = Area + (xxmin - xmin(j)) * System.Math.Abs(Quot(j))
        Dist = System.Math.Sqrt((xxmin - xmin(j - jpiu)) ^ 2 + (Quot(j) - Quot(j - jpiu)) ^ 2)
        Perim = Perim + Dist
        Area = Area - (xxmin - xmin(j - jpiu)) * System.Math.Abs(Quot(j) + Quot(j - jpiu)) / 2
        Dist = System.Math.Sqrt((xxmax - xmax(j - jpiu)) ^ 2 + (Quot(j) - Quot(j - jpiu)) ^ 2)
        Perim = Perim + Dist
        Area = Area + (xxmax - xmax(j - jpiu)) * System.Math.Abs(Quot(j) + Quot(j - jpiu)) / 2
        Perim = Perim - xxmax + xmax(j)
        Area = Area - (xxmax - xmax(j)) * System.Math.Abs(Quot(j))
        icount = icount + 1
        P0.Punti.Item(icount + 1).TextData.X = xxmax
        p1.Punti.Item(icount + 1).TextData.X = xxmin
        P0.Punti.Item(icount + 1).TextData.y = Quot(j)
        p1.Punti.Item(icount + 1).TextData.y = Quot(j)
        icount = icount + 1
        P0.Punti.Item(icount + 1).TextData.X = xmax(j)
        p1.Punti.Item(icount + 1).TextData.X = xmin(j)
        P0.Punti.Item(icount + 1).TextData.y = Quot(j)
        p1.Punti.Item(icount + 1).TextData.y = Quot(j)
    End Sub
End Class
Module RM
    Private t1, DE1, L1 As Single
    Private i1, icot, Omog, i2 As Short
    Private cotub As String
    Private pesNet() As Single
    Private pesLor() As Single
    Private pesSfri() As Single
    Private lunTot() As Single
    Private lunTotn() As Single
    Private ii As Short
    Private Rmin() As Single
    Private NFIL() As Short
    Private LRP() As Short
    Private ntub2(,) As Short
    Private RM(,) As Single
    Private LR(,) As Single
    Private SVNE(,) As Single
    Private SVLO(,) As Single
    Private PNET(,) As Single
    Private PLOR(,) As Single
    Private SFRI(,) As Single
    Private iii As Short
    Private StriSt(6) As String
    Private ItaPr, ItaPlain As Short
    Private LaData As String
    Private i, ifl As Short
    Private k As Short
    Private Testo, Tipo As String
    Private y, x, kk As Short
    Private W As Single
    Private iRiga As Short
    Private Force() As Short
    Private ForceTot, Pagina As Short
    Private Par As String
    Private lTotn As Single
    Private Barre, Primo As Short
    Private BAR() As Short
    Private LBAR() As Single
    Private Z, iCod As Short
    Private File As String
    Private PassoBar As Single
    Private incr() As Single
    Private Passo() As String
    Private RigaB, Riga, RigaC As String
    Private Ni(23) As String
    Private Ne(23) As String
    Private Ris(23) As Boolean ': WIDTH "lpt1:", 255
    Private Par1 As String
    Private Stringa1() As String
    Private Risult() As String
    Private Risposta As String
    Private PressIdr As Single
    Private doc, Revisione As String
    Private Commessa, Tolleranza As String
    Private traccia As String
    Private nGru, nFilMax As Short
    Private Inox As String
    Private IncrLin As Single
    Private scort As Short
    Private DE() As Single
    Private t() As Single
    Private L() As Single
    Private RI As Short
    Private RaggioT, LunghT As Single
    Private ifl1, Intest As Short
    Private Title, Cod0, Prompt, Def As String
    Private Archivio(2) As Short
    Private dAiuto(2) As String
    Public Sub locMakeRMT(ByRef commes As String, ByRef iRes As Short, ByRef Mom As Single, _
                          ByRef pNet0 As Single, ByRef pLor0 As Single, ByRef pSfri As Single, _
                          ByRef Mat As String, ByRef PesoSpec As Single, ByRef Mode As Short, _
                          Optional ByRef Silente As Boolean = False, Optional ByRef lTot As Single = 0)
        'Mode 0 scrittura RMT,1 solo calcolo peso
        iRes = 0
        pNet0 = 0
        pLor0 = 0
        pSfri = 0
        cotub = commes ' RTrim$(Datidir) + "\" + RTrim$(gencommes) + ".ADU"
        icot = FreeFile()
        If Len(cotub) = 0 Then Exit Sub
        If Not System.IO.File.Exists(cotub) Then Exit Sub
        If Mode = 1 Then InitDaTos()
        FileOpen(icot, cotub, OpenMode.Input)
        ItaPr = 0 : ItaPlain = 0
        LaData = CStr(Today) 'Mid$(Date$, 4, 3) + Mid$(Date$, 1, 3) + Mid$(Date$, 7, 4)
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUTT.RTF", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        LeggiDati(iRes, Mat, PesoSpec, Mode, Silente)
        ReDim Rmin(nGru + 1)
        ReDim NFIL(nGru + 1)
        ReDim LRP(nGru + 1)
        ReDim DE(nGru + 1)
        ReDim t(nGru + 1)
        ReDim L(nGru + 1)
        ReDim incr(nGru + 1)
        ReDim Passo(nGru + 1)
        ReDim pesNet(nGru + 1)
        ReDim pesLor(nGru + 1)
        ReDim pesSfri(nGru + 1)
        ReDim lunTot(nGru + 1)
        ReDim lunTotn(nGru + 1)
        ReDim Force(nGru + 1)
        For i = 1 To nGru
            LeggiGru()
            Realloc()
            For k = 1 To NFIL(i)
                Input(icot, ntub2(i, k))
                Input(icot, Testo)
            Next k
        Next i
        If PassoBar = 0 Then
            If Inox = "SI" Then PassoBar = 300 Else PassoBar = 500
        End If
        '*****************************************
        'Peso con tracciatura
        kk = 0 : Mom = 0.0!
        For i = 1 To nGru
            If NFIL(i) > 0 Then
                For k = 1 To NFIL(i)
                    RM(i, k) = Rmin(i) + (incr(i) * (k - 1))
                    LR(i, k) = LRP(i) + (IncrLin * kk)
                    'If incr(i) < 0 Then LR(i, k) = LR(i, k) - incr(i)
                    SVNE(i, k) = (RM(i, k) * System.Math.PI) + (LR(i, k) * 2)
                    SVLO(i, k) = SVNE(i, k) + 100
                    W = SVLO(i, k)
                    SVLO(i, k) = CShort(Int(W / PassoBar) - CShort(Int(W / PassoBar) <> (W / PassoBar))) * PassoBar
                    PNET(i, k) = (DE(i) - t(i)) * System.Math.PI * SVNE(i, k) * t(i) * PesoSpec ' * Matdim(0).PSP * EXP9
                    Mom = Mom + (L(i) * L(i) + (L(i) + 2.0! / System.Math.PI * RM(i, k)) * System.Math.PI * RM(i, k)) * ntub2(i, k)
                    If Tolleranza = "MW" And Inox = "SI" Then PNET(i, k) = PNET(i, k) * 1.05 Else If Tolleranza = "MW" And Inox = "NO" Then PNET(i, k) = PNET(i, k) * 1.07
                    PLOR(i, k) = (PNET(i, k) / SVNE(i, k)) * SVLO(i, k)
                    If Inox = "SI" Then PLOR(i, k) = PLOR(i, k) * 1.002 Else PLOR(i, k) = PLOR(i, k) * 1.003
                    SFRI(i, k) = PLOR(i, k) - PNET(i, k)
                    kk = kk + 1
                Next k
            End If
        Next i
        For i = 1 To nGru
            Force(i) = 0
            pesNet(i) = 0 : pesLor(i) = 0 : pesSfri(i) = 0 : lunTot(i) = 0 : lunTotn(i) = 0
            If NFIL(i) > 0 Then
                For k = 1 To NFIL(i)
                    pesNet(i) = pesNet(i) + PNET(i, k) * ntub2(i, k)
                    pesLor(i) = pesLor(i) + PLOR(i, k) * ntub2(i, k)
                    pesSfri(i) = pesSfri(i) + SFRI(i, k) * ntub2(i, k)
                    lunTot(i) = lunTot(i) + (SVLO(i, k) / 1000) * ntub2(i, k)
                    lunTotn(i) = lunTotn(i) + (SVNE(i, k) / 1000) * ntub2(i, k)
                    Force(i) = Force(i) + ntub2(i, k)
                Next k
            End If
            pNet0 = pNet0 + pesNet(i)
            pLor0 = pLor0 + pesLor(i)
            pSfri = pSfri + pesSfri(i)
            lTot = lTot + lunTot(i)
            lTotn = lTotn + lunTotn(i)
        Next i
        If NFIL(1) > 0 Then
            Mom = Mom / lTotn / 1000
        Else
            Mom = L(i) / 2
            pNet0 = (DE(i) - t(i)) * System.Math.PI * L(i) * t(i) * PesoSpec ' * Matdim(0).PSP * EXP9
            If Tolleranza = "MW" And Inox = "SI" Then
                pNet0 = pNet0 * 1.05
            ElseIf Tolleranza = "MW" And Inox = "NO" Then
                pNet0 = pNet0 * 1.07
            End If
            pLor0 = pNet0
            If Inox = "SI" Then pLor0 = pLor0 * 1.002 Else pLor0 = pLor0 * 1.003
            pSfri = pLor0 - pNet0
            pNet0 = pNet0 * IncrLin
            pLor0 = pLor0 * IncrLin
            pSfri = pSfri * IncrLin
        End If
        If NFIL(1) = 0 Or Mode = 1 Then 'non tubi a U
            ' If iUnit Then FileClose(iUnit)
            FileClose(icot)
            '  iUnit = -1
            Exit Sub
        End If
        '**************************************
        'MF$ = "--"
        '********************************************
        '****** STAMPA PER RICHIESTE MATERIALI ******
        '********************************************
        '****** STAMPA RISULTATI ******
        If Tolleranza = "MW" Then Tolleranza = "Minimum Wall"
        If Tolleranza = "AV" Then Tolleranza = "Average"
        Par = "\par "
        Pagina = 1
        TestaVec()
        Figura()
        iRiga = 30
        For i = 1 To nGru
            LeggiVec()
            If Omog = 0 Or i = 1 Then kk = 1
            k = 1
            If nGru > 1 And Not Omog = 1 Then
                Monitor.Motore.Problem.Printa(Space(10) & "{\b Gruppo n°" & Str(i) & ":} N°" & Force(i) & " U-Tubes" & Par)
            Else
                If i = 1 Then
                    If Omog = 1 Then
                        ForceTot = 0
                        For iii = 1 To nGru
                            ForceTot = ForceTot + Force(iii)
                        Next
                        Monitor.Motore.Problem.Printa(Space(10) & "N°" & ForceTot & " U-Tubes" & Par)
                    Else
                        Monitor.Motore.Problem.Printa(Space(10) & "N°" & Force(i) & " U-Tubes" & Par)
                    End If
                End If
            End If
            If i = 1 Or (i > 1 And Omog = 0) Then
                iRiga = iRiga + 3
                If DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Fontana Then
                    Monitor.Motore.Problem.Printa(Space(10) & "OD." & Mid(Str(DE(i)), 2, Len(Str(DE(i))) - 1) & " Thk." & Mid(Str(t(i)), 2, Len(Str(t(i))) - 1) & " " & Tolleranza & " PITCH :" & DaTos(iDat).Passo & " (ext.)," & DaTos(1).Passo & " (int.)." & Par)
                Else
                    Monitor.Motore.Problem.Printa(Space(10) & "OD." & Mid(Str(DE(i)), 2, Len(Str(DE(i))) - 1) & " Thk." & Mid(Str(t(i)), 2, Len(Str(t(i))) - 1) & " " & Tolleranza & " PITCH :" & DaTos(iDat).Passo & Par)
                End If
                Monitor.Motore.Problem.Printa(Space(10) & "Material : " & Mat & Par)  ' M0$; Par
                TestTabella()
            End If
            For k = 1 To NFIL(i)
                If (k = NFIL(i) And Not Omog = 1) Or (i = nGru And Omog = 1) Then
                    If nGru > 1 And Omog = 1 Then
                        pesNet(i) = pNet0
                        pesLor(i) = pLor0
                        pesSfri(i) = pSfri
                        lunTot(i) = lTot
                        lunTotn(i) = lTotn
                    End If
                    PrintCorF()
                    iRiga = iRiga + 5
                    If iRiga > 50 Then
                        Monitor.Motore.Problem.Printa("\page ")
                        iRiga = 0
                    End If
                Else
                    PrintCorI()
                    iRiga = iRiga + 1
                End If
                kk = kk + 1
            Next k
            If Not (Omog = 1 Or nGru = 1) Then
                i1 = i : i2 = i
                Riepilogo()
            End If
        Next i
        If Omog = 1 Or nGru = 1 Then
            i1 = 1 : i2 = nGru
            Riepilogo()
        End If
        On Error GoTo 0
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RMTU03.DAT", OpenMode.Input, , OpenShare.Shared)
        Testo = LineInput(ifl)
        Monitor.Motore.Inizio.ConvertiCr(Testo)
        '        text$ = " La richiesta materiali e' stata generata. Il file|"
        'text$ = text$ + "testo corrispondente ha l'estensione .RMT         |"
        'text$ = text$ + " Ora vi sara' consentito di aggiungere alla RM, se|"
        'text$ = text$ + "richiesto, le prescrizioni di fabbricazione e     |"
        'text$ = text$ + "collaudo. Avete delle note da aggiungere?         |"
        If Silente Then
            FileClose(ifl) : FileClose(icot)
            Monitor.Motore.Problem.Printa("}")
            Exit Sub
        End If
        If MsgBox(Testo, MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            FileClose(ifl) : FileClose(icot)
            Monitor.Motore.Problem.Printa("}")
            Exit Sub
        End If
        '******************************************
        '****** NOTE PER RICHIESTE MATERIALE ******
        '******************************************
        For i = 1 To 22
            Ni(i) = LineInput(ifl)
            Ne(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        '3030 Ni(1) = "Tubi adatti ad essere curvati e mandrinati"
        '3040 Ne(1) = "Tubes suitable to be bent and expanded."
        '3050 Ni(2) = "Tubi adatti ad essere curvati,mandrinati e saldati"
        '3060 Ne(2) = "Tubes suitable to be bent,expanded and welded."
        '3070 Ni(3) = "Tutti i tubi devono essere controllati con EDDY CURRENT prima della curvatura"
        '3080 Ne(3) = "All the tubes shall be checked by EDDY CURRENT before bending."
        '3090 Ni(4) = "Sbavare le estremit… dei tubi dopo curvatura e rifilatura"
        '3100 Ne(4) = "Deburr the tube ends after bending and cutting."
        '3110 Ni(10) = "La lunghezza [SV] corrisponde all'esatto sviluppo del tubo finito.              L'eventuale sovralunghezza dovr… esere prevista dal fornitore o dall'ufficio    interno F.B.M. competente"
        '3120 Ne(10) = "The length [SV] corresponds to the exact development of the finished tube.      The possible overlength necessary for bending shall  be  foreseen by Supplier orby FBM qualified department."
        '3130 Ni(11) = "La lunghezza tel tubo in barre corrisponde all'esatto sviluppo del tubo+100 mm, arrotondata al multiplo di 300 per acciaio INOX o leghe speciali e al multiplo  di 500 per acciaio al carbonio e basso legati."
        '3140 Ne(11) = "The total length of the row tube before bending shall be equal to the exact tubedevelopement"
        '"+ 100 mm rounded to the nearest upper 300 mm multiple for stainlesssteel or special alloy and to the nearest upper 500 mm multiple for carbon steel"
        '3150 Ni(5) = "I tubi saranno piegati a freddo con una procedura che non contamini o danneggi  la superficie interna ed  esterna degli stessi; l'uso di lubrificanti Š ammesso solamente dietro approvazione F.B.M."
        '3160 Ne(5) = "The tubes will be cold bent by a process that shall not contaminate or damage   the external and internal surfaces of the same;the use of lubricant is permittedonly upon F.B.M.'s approval."
        '3170 Ni(6) = "Max.ovalizzazione delle curve ad U in qualsiasi sezione trasversale deve essere il 10% del diametro nominale esterno del tubo."
        '3180 Ne(6) = "Max.ovalization  of  U-bends  at  any  cross-section shall be 10% of the nominaloutside tube diameter."
        '3190 Ni(13) = "Spessore  minimo delle curve ad U in qualsiasi  sezione trasversale deve  essere##.## mm."
        '3200 Ne(13) = "Minimum wall thickness of U-bends at any cross-section shall be ##.## mm."
        '3210 Ni(7) = "La  porzione  piegata  del  tubo  ad U dovr… essere sostanzialmente uniforme in curvatura e non superare ñ 1.6 mm il raggio medio nominale."
        '3220 Ne(7) = "The bend portion of the U-tube shall be substantially uniform in curvature  and not exceed ñ 1.6 mm of the nominal centerline radius."
        '3230 Ni(8) = "La  lunghezza  totale  delle  parti rettilinee dei tubi misurata dall'estremit… della  curva  alla  estremit…  della  parte  diritta deve essere -0 +5 mm della lunghezza richiesta."
        '3240 Ne(8) = "The overall length of the tube legs measured from the top of the bend to the endof the tube leg shall be -0 +5 mm to the required length."
        '3250 Ni(16) = "Prima del trattamento termico i tubi  devono essere puliti esternamente mediantepanno imbevuto con \                                                           \"
        '3260 Ne(16) = "Before heat treatment,the outside surface of the tubes shall be cleaned by usinga clean cloth soaked with \                                                    \"
        '3270 Ni(17) = "Prevedere  un adeguato sistema  di mantenimento del grado di pulizia conseguito nella movimentazione ed in tutte le successive lavorazioni dei tubi."
        '3280 Ne(17) = "Appropriate  measures  shall  be  taken  to  maintain  the  achieved cleanlinessin further processing and handling of tubes."
        '3290 Ni(14) = "Le curve con  raggio ó  ####.# mm devono  subire  un Trattamento Termico atto a ristabilire le caratteristiche originarie del materiale.Il T.T.si estender… per ### mm oltre la zona di curvatura su entrambi i lati della curva."
        '3300 Ne(14) = "U-bends  having  radius ó ####.# mm  shall  be heat treated to re-estabilish theoriginal properties of the material. The heat treatment shall be extended ### mmpast the bent area on each side of the bend."
        '3310 Ni(15) = "L'interno dei tubi sar… protetto con un'adeguata atmosfera di protezione durantel'intero ciclo del T.T."
        '3320 Ne(15) = "The inside of the tubes shall be protected with a suitable protective atmosphereduring the entire heat treatment cycle."
        '3330 Ni(20) = "I tubi curvati devono essere  provati  idraulicamente  dopo curvatura e T.T. overichiesto."
        '"La  prova  idraulica  sar…  eseguita alla pressione di ####.# Mpa conacqua demineralizzata con le seguenti caratteristiche: Cloruri(Cl) 50 ppm max."
        '3340 Risposta = "The U-bend tubes shall be hydraulically tested after bending  and stress  reliefannealing."
        '"The  test  shall  be  performed  at  the  pressure of ####.# Mpa withdemineralized water with the following quality requirements: Chloride(Cl) 50 ppmmax."
        '3350 Ne(20) = Risposta
        '3360 Ni(18) = "Le superfici  esterne  delle  curve  ad  U  devono  essere esaminate con liquidipenetranti dopo curvatura,T.T. e prova idraulica. L'area  esaminata si estender…almeno 153 mm al di l… dell'area trattata termicamente."
        '3370 Ne(18) = "The O.D.surface of all U-bends shall be liquid penetrant examined after bending,stress relief annealing,and hydrotest testing.The examined area shall  extend atleast 153 mm past the heated area."
        '3380 Ni(19) = "Le superfici esterne delle  curve  ad  U  devono  essere esaminate con Magnafluxdopo curvatura,T.T. e prova idraulica. L'area  esaminata si estender… almeno 153mm al di l… dell'area trattata termicamente."
        '3390 Ne(19) = "The O.D.surface of all U-bends shall be M.T.examined after bending,stress reliefannealing, and hydrotest testing.The examined area  shall  extend atleast 153 mmpast the heated area."
        '3400 Ni(9) = "Tutti i tubi piegati ad U dovranno  mantenere la stessa marcatura originale dei tubi diritti."
        '3410 Ne(9) = "All U-tubes shall maintain the original marking of straight tubes."
        '3420 Ni(12) = "Il sistema di imballaggio e spedizione deve essere idoneo a proteggere i tubi daeventuali danneggiamenti e agenti atmosferici."
        '3430 Ne(12) = "Appropriate packing and shipment system shall be provided to protect each U-tubefrom any damage"
        '3440 Ni(21) = "I tubi curvati devono essere  provati  idraulicamente  dopo curvatura e T.T. overichiesto. La  prova  idraulica  sar…  eseguita alla pressione di ####.# Mpa"
        '3450 Ne(21) = "The U-bend tubes shall be hydraulically tested after bending  and stress  reliefannealing.The hydraulic test shall be performed at the pressure of ####.# Mpa"
        '     Ni(22) = "Nota vuota"
        '     Ne(22) = "Dummy note"
        ScelNot()
        If ItaPlain = 1 Then Monitor.Motore.Problem.Printa("}")
        FileClose(icot)
    End Sub
    Private Sub Sub3480() 'intestazione note
        Monitor.Motore.Problem.Printa("\page ")
        Pagina = Pagina + 1
        TestaVec()
        Par1 = "\pard\plain \f11\fs18 \par"
        Monitor.Motore.Problem.Printa(Par1)
        Monitor.Motore.Problem.Printa(Space(7) & "PRESCRIZIONI PER ACQUISTO E COSTRUZIONE DI TUBI A 'U'." & Par)
        Monitor.Motore.Problem.Printa(Space(7) & "======================================================" & Par)
        Monitor.Motore.Problem.Printa(Space(28) & "PURCHASING AND FABRICATION REQUIREMENTS OF U-TUBES" & Par)
        Monitor.Motore.Problem.Printa(Space(28) & "--------------------------------------------------" & Par)
    End Sub
    Private Sub ScelNot() '*******************************************
        '****** scelta delle note da stampare ******
        '*******************************************
        Sub3480()
        RI = 10 : kk = 0
        Monitor.Motore.CheckQuale(22, "Scelta prescrizioni di acquisto", Ni, Ris, "Nessun aiuto")
        For i = 1 To 22
            If Ris(i) Then
                kk = kk + 1
                Sub3920()
            End If
        Next i
        If kk = 0 Then Plain()
        Monitor.Motore.Problem.Printa("}")
    End Sub
    Private Sub Sub3920()
        '**********************************
        '****** stampa note standard ******
        '**********************************
        If RI > 50 Then
            RI = 7
            Sub5000()
        End If
        If i = 13 Then Sub4120()
        If i = 14 Then Sub4220()
        If i = 16 Then sub4350()
        If i = 20 Or i = 21 Then GoTo R4460
        x = Int(Len(Ni(i)) / 81) + 1
        Monitor.Motore.Problem.Print(kk & ")")
        For k = 1 To x
            Monitor.Motore.Problem.Printa(Space(2) & Mid(Ni(i), k * 80 - 79, -80 * CShort(k <> x) + (Len(Ni(i)) - (80 * (k - 1))) * -CShort(k = x)) & Par)
            RI = RI + 1
        Next k
        RI = RI + 1
        x = Int(Len(Ne(i)) / 81) + 1
        Italic()
R4460:  For k = 1 To x
            Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), k * 80 - 79, -80 * CShort(k <> x) + (Len(Ne(i)) - (80 * (k - 1))) * -CShort(k = x)) & Par)
            RI = RI + 1
        Next k
        Plain()
        RI = RI + 1
    End Sub
    Private Sub Sub4120()
        'INPUT #ICOT, T, Testo
        '?????T = GlobalRoutines.ValVir(InputBox("Spessore minimo ammiss. dopo curvatura", "Specifica spessore minimo", mystr(T(i) * 0.9, 4, 2, False)))
        If RI > 50 Then
            RI = 7
            Sub5000()
        End If
        'stampa nota 13
        Monitor.Motore.Problem.Print(kk & ")")
        Monitor.Motore.Problem.Printa(Space(2) & Mid(Ni(i), 1, 80) & Par)
        RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ni(i), 81, Len(Ni(i)) - 80), New Object() {t}))
        Monitor.Motore.Problem.Printa(Par)
        RI = RI + 1
        RI = RI + 1
        Italic()
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Ne(i), New Object() {t}))
        Monitor.Motore.Problem.Printa(Par)
        Plain()
        RI = RI + 1
        Monitor.Motore.Problem.Printa("")
        RI = RI + 1
    End Sub
    Private Sub Sub4220()
        'INPUT #ICOT, RaggioT, Testo
        'INPUT #ICOT, LunghT, Testo
        ReDim Stringa1(2)
        ReDim Risult(2)
        Stringa1(1) = "Raggio di curvat. da trattare"
        Stringa1(2) = "Lunghezza diritta da trattare"
        Risult(1) = GlobalRoutines.myStr(DE(i) * 4, 4, 2, False)
        Risult(2) = GlobalRoutines.myStr(DE(i) * 8, 4, 2, False)
        Archivio(1) = 0 : Archivio(2) = 0
        Monitor.Motore.InputDati(2, "Trattamento Termico", Stringa1, Risult, "No Help available", Archivio, dAiuto)
        RaggioT = GlobalRoutines.ValVir(Risult(1))
        LunghT = GlobalRoutines.ValVir(Risult(2))
        If RI > 50 Then
            RI = 7
            Sub5000()
        End If
        'stampa nota 14
        Monitor.Motore.Problem.Print(kk & ")")
        Monitor.Motore.Problem.Print(Space(2))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ni(i), 1, 80), RaggioT))
        Monitor.Motore.Problem.Printa(Par)
        RI = RI + 1
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ni(i), 81, 80) & Par)
        RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ni(i), 161, Len(Ni(i)) - 160), LunghT))
        Monitor.Motore.Problem.Printa(Par)
        RI = RI + 1
        RI = RI + 1
        Italic()
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ne(i), 1, 80), RaggioT))
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ne(i), 81, 80), LunghT))
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), 161, Len(Ne(i)) - 160) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Plain()
    End Sub
    Private Sub sub4350()
        'INPUT #ICOT, Risposta, Testo
        Risposta = InputBox("Risposta per la pulizia", "Solvente pulizia tubi", "Trielina")
        If RI > 50 Then
            RI = 7
            Sub5000()
        End If
        'stampa nota 16
        Monitor.Motore.Problem.Print(kk & ")")
        Monitor.Motore.Problem.Printa(Space(2) & Mid(Ni(i), 1, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ni(i), 81, 80), Risposta))
        Monitor.Motore.Problem.Printa(Par)
        RI = RI + 1
        RI = RI + 1
        Italic()
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), 1, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ne(i), 81, 80), Risposta))
        Monitor.Motore.Problem.Printa(Par)
        RI = RI + 1
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Plain()
    End Sub
    Private Sub sub4460()
        'INPUT #ICOT, MPA, Testo
        PressIdr = GlobalRoutines.ValVir(InputBox("Pressione di prova idraulica [MPa]", "Specifica prova idraulica", "  20.0"))
        PressIdr = GlobalRoutines.ValVir(Risult(1))
        If RI > 50 Then
            RI = 7
            Sub5000()
        End If
        If i <> 20 Then Sub4610() : Exit Sub
        'stampa nota 20
        Monitor.Motore.Problem.Print(kk & ")")
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ni(i), 1, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ni(i), 81, 80), PressIdr))
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ni(i), 161, Len(Ni(i)) - 160) & Par) : RI = RI + 1
        RI = RI + 1
        Italic()
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), 1, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ne(i), 81, 80), PressIdr))
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), 161, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), 241, Len(Ne(i)) - 240) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Plain()
    End Sub
    Private Sub Sub4610()
        'stampa nota 21
        Monitor.Motore.Problem.Print(kk & ")")
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ni(i), 1, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ni(i), 81, Len(Ni(i)) - 80), PressIdr))
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        RI = RI + 1
        Italic()
        Monitor.Motore.Problem.Printa(Space(7) & Mid(Ne(i), 1, 80) & Par) : RI = RI + 1
        Monitor.Motore.Problem.Print(Space(7))
        Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(Mid(Ne(i), 81, Len(Ne(i)) - 80), PressIdr))
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Monitor.Motore.Problem.Printa(Par) : RI = RI + 1
        Plain()
    End Sub
    Private Sub Sub5000()
        '***************************
        '****** cambio pagina ******
        '***************************
        If Pagina > 1 Then PiedeVec()
        Pagina = Pagina + 1
        TestaVec()
        Monitor.Motore.Problem.Printa(Par)
    End Sub
    Private Sub TestaVec()
        '**************************
        If Not Intest = 0 Then
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(1), Monitor.Motore.Inizio.Firma))
            Monitor.Motore.Problem.Printa(StriSt(2))  ' "                      =========================="
        Else
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(3), Monitor.Motore.Inizio.Firma, doc, Revisione))  '"1\  \                 FBM-HUDSON ITALIANA S.p.A.                 DOC.nø \          \"
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(4), Str(Pagina)))  '"                      ==========================                    sheet.nø ......."
        End If
        If Pagina = 1 Then
            Monitor.Motore.Problem.Printa(StriSt(5))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(6), Commessa, LaData))
        End If
    End Sub
    Private Sub PiedeVec()
        'PIEDE PAGINA
        '     If TipoStam = 3 Then Return
        '9510 Print #iUnit, Tab(15); "SPEC.Nø"; Documento; "    REV."; Revisione
    End Sub
    Private Sub LeggiVec()
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBU01.RTF", OpenMode.Input, , OpenShare.Shared)
        Riga = LineInput(ifl)
        RigaB = LineInput(ifl)
        RigaC = LineInput(ifl)
        FileClose(ifl)
    End Sub
    Private Sub Figura()
        File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUFG.RTF"
        Trasfer()
    End Sub
    Private Sub TestTabella()
        If Omog = 0 And nGru > 1 Then
            File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUTE.RTF"
        Else
            File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUTES.RTF"
        End If
        iCod = 1
        Trasfer()
    End Sub
    Private Sub Trasfer()
        ifl1 = FreeFile()
        FileOpen(ifl1, File, OpenMode.Input, , OpenShare.Shared)
        Do
            Risposta = LineInput(ifl1)
            If LTrim(Risposta) = "fine" Or EOF(ifl1) Then Exit Do
            If InStr(Risposta, "_\") = 0 Then
                Monitor.Motore.Problem.Printa(Risposta)
            Else
                Select Case iCod
                    Case 1, 4
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Risposta, kk, ntub2(i, k), RM(i, k), LR(i, k), SVNE(i, k), SVLO(i, k), PNET(i, k) * ntub2(i, k), PLOR(i, k) * ntub2(i, k), SFRI(i, k) * ntub2(i, k)))
                        If iCod = 4 Then iCod = 5
                    Case 2
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Risposta, Barre, LBAR(i)))
                    Case 3
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Risposta, scort, LBAR(kk)))
                    Case 5
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Risposta, lunTotn(i), lunTot(i), pesNet(i), pesLor(i), pesSfri(i)))
                    Case 6
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Risposta, i1))
                        iCod = 2
                End Select
            End If
        Loop
        FileClose(ifl1)
    End Sub
    Private Sub PrintCor()
        Monitor.Motore.Problem.Printa(Riga)
        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(RigaB, kk, ntub2(i, k), RM(i, k), LR(i, k), SVNE(i, k), SVLO(i, k), PNET(i, k) * ntub2(i, k), PLOR(i, k) * ntub2(i, k), SFRI(i, k) * ntub2(i, k)))
        Monitor.Motore.Problem.Printa(RigaC)
    End Sub
    Private Sub PrintCorF()
        File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUF2.RTF"
        iCod = 4
        Trasfer()
    End Sub
    Private Sub PrintCorI()
        If k = 1 And i = 1 Then Exit Sub
        If (kk + 19) Mod 32 = 0 Then
            File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUF1.RTF"
            Trasfer()
            Pagina = Pagina + 1
            TestaVec()
        Else
            PrintCor()
        End If
    End Sub
    Private Sub LeggiVecS()
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBU02.RTF", OpenMode.Input, , OpenShare.Shared)
        Riga = LineInput(ifl)
        RigaB = LineInput(ifl)
        RigaC = LineInput(ifl)
        FileClose(ifl)
    End Sub
    Private Sub LeggiDati(ByRef iRes As Short, ByRef Mat As String, ByRef PesoSpec As Single, ByRef Mode As Short, Optional ByRef Silente As Boolean = False)
        Input(icot, Cod0)
        Input(icot, Testo) : kk = 0
        Input(icot, Mat)
        Input(icot, Testo)
        If GlobalRoutines.ValVir(Cod0) = 0 And Not Silente And Not (Mode = 1 And PesoSpec > 0) Then
            Riga = "      Attenzione:" & vbCrLf
            Riga = Riga & "Non è stato specificato correttamente" & vbCrLf
            Riga = Riga & "il materiale. Vuoi tornare indietro?"
            If MsgBox(Riga, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                FileClose(icot)
                iRes = 1
                Exit Sub
            End If
        End If
        If PesoSpec = 0 Then
            Prompt = "Fornire il peso specifico" & vbCrLf
            Prompt = Prompt & "del materiale dei tubi in kg/m3"
            Title = "Peso specifico" : Def = "  7800.00"
            PesoSpec = GlobalRoutines.ValVir(InputBox(Prompt, Title, Def)) * 0.000000001
        End If
        '***************************************
        'Controllo codice materiale tubo
        '*****************************************
        If InStr(Testo, "DOCUMENTO") > 0 Then
            doc = Mat
        Else
            Input(icot, doc)
            Input(icot, Testo)
        End If
        Risposta = doc
        If Len(Risposta) <= 9 Then Risposta = Risposta & New String(Chr(9 - Len(Risposta)), 32)
        Input(icot, Revisione)
        Input(icot, Testo)
        Input(icot, Commessa)
        Input(icot, Testo)
        traccia = "SI"
        Input(icot, Risposta)
        Input(icot, Testo)
        If Mid(Risposta, 1, 1) = "S" Or Mid(Risposta, 1, 1) = "s" Then Tolleranza = "MW" Else Tolleranza = "AV"
        Input(icot, Intest)
        Input(icot, Testo)
        If InStr(Testo, "INOX") > 0 Then
            Risposta = CStr(Intest)
        Else
            Input(icot, PassoBar)
            Input(icot, Testo)
            Input(icot, Risposta)
            Input(icot, Testo)
        End If
        If Mid(Risposta, 1, 1) = "S" Or Mid(Risposta, 1, 1) = "s" Then Inox = "SI" Else Inox = "NO"
        If Not traccia = "NO" Then
            Input(icot, Tipo)
            Input(icot, Testo)
            Tipo = UCase(Left(Tipo, 1))
        End If
        Input(icot, IncrLin)
        Input(icot, Testo) '"DIAMETRO ESTERNO TUBI"
        Input(icot, DaTos(iDat).Passo)
        Input(icot, Testo)
        If InStr(Testo, "SPESSORE") > 0 Then
            DE1 = IncrLin
            t1 = DaTos(iDat).Passo
            Input(icot, L1)
            Input(icot, Testo)
            Input(icot, IncrLin)
            Input(icot, Testo)
            Input(icot, DaTos(iDat).Passo)
            Input(icot, Testo)
            Input(icot, nGru)
            Input(icot, Testo)
        Else
            Input(icot, nGru)
            Input(icot, Omog)
            Input(icot, Testo)
        End If
        If nGru = 0 Then nGru = 1
    End Sub
    Private Sub LeggiGru()
        Input(icot, DE(i))
        Input(icot, Testo)
        If InStr(Testo, "MINIMO") Then
            Rmin(1) = DE(1)
            DE(1) = DE1
            t(1) = t1
            L(1) = L1
        Else
            Input(icot, t(i))
            Input(icot, Testo)
            Input(icot, L(i))
            Input(icot, Testo)
            Input(icot, Rmin(i))
            Input(icot, Testo)
        End If
        Input(icot, incr(i))
        Input(icot, Testo)
        Input(icot, Passo(i))
        Input(icot, Testo)
        If InStr(Testo, "NUMERO") Then
            NFIL(1) = CShort(Passo(1))
            Passo(1) = CStr(DaTos(iDat).Passo)
        Else
            Input(icot, NFIL(i))
            Input(icot, Testo)
        End If
        If LRP(i) = 0 Then LRP(i) = L(i)
        If NFIL(i) > nFilMax Then nFilMax = NFIL(i)
    End Sub
    Private Sub Italic()
        If ItaPr = 0 Then
            Monitor.Motore.Problem.Printa("{\i\fs18\cgrid ")
            ItaPr = 1
        Else
            Monitor.Motore.Problem.Printa("}{\i\fs18\cgrid ")
        End If
    End Sub
    Private Sub Plain()
        Monitor.Motore.Problem.Printa("}{\fs18\cgrid ")
        ItaPlain = 1
    End Sub
    Private Sub Realloc()
        x = nGru + 1 : y = nFilMax + 1
        ReDim Preserve ntub2(x, y)
        ReDim Preserve RM(x, y)
        ReDim Preserve LR(x, y)
        ReDim Preserve SVNE(x, y)
        ReDim Preserve SVLO(x, y)
        ReDim Preserve PNET(x, y)
        ReDim Preserve PLOR(x, y)
        ReDim Preserve SFRI(x, y)
    End Sub
    Private Sub Riepilogo()
        LeggiVecS()
        kk = 0
        For ii = i1 To i2
            ForceTot = 0
            kk = kk + NFIL(ii)
            ForceTot = ForceTot + Force(ii)
        Next ii
        ReDim BAR(kk)
        ReDim LBAR(kk)
        kk = 1
        For ii = i1 To i2
            For k = 1 To NFIL(ii)
                BAR(kk) = ntub2(ii, k)
                LBAR(kk) = SVLO(ii, k)
                kk = kk + 1
            Next k
        Next ii
        kk = kk - 1
        For k = 1 To kk - 1
            If LBAR(k) > LBAR(k + 1) Then
                GlobalRoutines.SWAP(LBAR(k), LBAR(k + 1))
                GlobalRoutines.SWAP(BAR(k), BAR(k + 1))
                k = k - 2 : If k < 1 Then k = 1
            End If
        Next
        If (kk + 19) Mod 32 > 23 Then
            Pagina = Pagina + 1
            Monitor.Motore.Problem.Printa("\page ")
            TestaVec()
        End If
        Barre = 0 : Z = 1 : Primo = 1
R2820:  For iii = Z To (kk - 1)
            If LBAR(iii) <> LBAR(iii + 1) Then GoTo R2900
            For y = Z To iii
                Barre = Barre + BAR(y)
            Next y
            If Primo = 1 Then
                If nGru = 1 Or Omog = 1 Then
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUTF1.RTF"
                    iCod = 2 : i = iii
                    Trasfer() 'uhm
                Else
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUTF.RTF"
                    iCod = 6
                    Trasfer() 'uhm
                End If
                Primo = 0
            Else
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Riga, Barre, LBAR(iii)))
                Monitor.Motore.Problem.Printa(RigaB)
                Monitor.Motore.Problem.Printa(RigaC)
            End If
            Z = iii + 1 : Barre = 0
            GoTo R2820
R2900:  Next iii
        For ii = Z To kk
            Barre = Barre + BAR(ii)
        Next ii
        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Riga, Barre, LBAR(kk)))
        Monitor.Motore.Problem.Printa(RigaB)
        If Inox = "NO" Then scort = Int(ForceTot * 0.003) + 1 Else scort = Int(ForceTot * 0.002) + 1
        File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUF3.RTF"
        iCod = 3
        Trasfer()
        PiedeVec()
    End Sub
End Module
Module OperazioniFinali
    Private ifl, ifl4, i As Short
    Private Text As String
    Private Form, File As String
    Private Risp, DatiD As String
    Private Valor As Single
    Private j, leno As Short
    Private Rmin(7) As String
    Private Raggio As Single
    Private LungForm As String
    Private Alun As Single
    Private n As Short
    Private incr As Single
    Private Tipo, Passo As String
    Private ifl1, NumUg As Short
    Private LunRet As Single
    Private cotub As String
    Public Function OpFin() As Boolean
        OpFin = True
        Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
        Mat = New LibMat.MaterialeNew1
        frmOpFin.DefInstance.ShowDialog()
        If Annullato Then
            frmOpFin.DefInstance.Dispose()
            OpFin = False
            Exit Function
        End If
        VariatiOpfin = False
        cotub = RTrim(gencommes) & ".ADU" 'RTrim$(Monitor.Motore.Inizio.Datidir) + "\" + RTrim$(gencommes) + ".ADU"
        If System.IO.File.Exists(cotub) And Not Tracciatura.DaPPSM Then
            Form = "Esiste una precedente versione del" & vbCrLf
            Form = Form & "file ADU(" & cotub & ")." & vbCrLf
            Form = Form & "Vuoi sovrascriverla?"
            If MsgBox(Form, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Dati per RM tubi ad U") = MsgBoxResult.No Then GoTo RetRet
        End If
        ifl4 = FreeFile()
        FileOpen(ifl4, cotub, OpenMode.Output)
        ifl1 = FreeFile()
        FileOpen(ifl1, RTrim(Monitor.Motore.Inizio.Archdir) & "\basetub1.adu", OpenMode.Input, , OpenShare.Shared)
        '1 numero materiale
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, Mat.Indmat))
        '  denominazione materiale
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, frmOpFin.DefInstance._Text1_0.Text))
        '2 numero documento
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, frmOpFin.DefInstance._Text1_1.Text))
        '3 revisione
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, frmOpFin.DefInstance._Text1_2.Text))
        '4 commessa
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, RTrim(gencommes)))
        '5 average minimum
        Form = LineInput(ifl1)
        If DaTos(iDat).dt(27) = 1 Then Risp = "SI" Else If DaTos(iDat).dt(27) = 2 Then Risp = "NO"
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, Risp))
        'intestatzione
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, UCase(Left(frmOpFin.DefInstance._Combo1_3.Text, 1)) = "S"))
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, GlobalRoutines.ValVir(frmOpFin.DefInstance._Combo1_6.Text)))
        '6 inox o speciale, normale
        Form = LineInput(ifl1)
        Risp = frmOpFin.DefInstance._Combo1_4.Text
        If UCase(Left(Risp, 1)) = "S" Then Risp = "SI" Else Risp = "NO"
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, Risp))
        '7 passo
        Form = LineInput(ifl1)
        CalcIncr()
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, Risp))
        '11 incremento chioma
        Form = LineInput(ifl1)
        Valor = GlobalRoutines.ValVir(frmOpFin.DefInstance._Text1_5.Text)
        If DaTos(iDat).TipoFascio < clsTracciatura.TipiFascio.Utube Then Valor = DaTos(iDat).ktotal
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, Valor))
        '12 passo
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, DaTos(iDat).dt(16)))
        '13 numero gruppi
        If DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Fontana Then
            If Not Fontana() Then Exit Function
            GoTo RetRet
        End If
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, 1, 0))
        '8 dia esterno
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, DaTos(iDat).dt(15)))
        '9 spessore
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, DaTos(iDat).dt(24)))
        '10 lunghezza rettilinea
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, DaTos(iDat).dt(26)))
        '14 raggio minimo
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, DaTos(iDat).dt(21)))
        '   incremento fila
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, incr))
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, Passo))
        '16 numero file
        Form = LineInput(ifl1)
        PrintLine(ifl4, GlobalRoutines.FormatS(Form, NumFileU))
        FileClose(ifl1)
        If DaTos(iDat).TipoFascio < clsTracciatura.TipiFascio.Utube Then GoTo RetRet
        If DaTos(iDat).PassoFascio <> 2 Then
            For j = 1 To NumFileMax
                Risp = Str(NumForcellePerFila(j)) : leno = Len(Risp) - 1
                Mid(Form, 1, 14) = Mid(Risp, 2, leno) & Space(14 - leno)
                Risp = Str(j) : leno = Len(Risp) - 1 : Risp = Chr(44) & Mid(Risp, 2, leno) & "¦ FILA"
                If NumForcellePerFila(j) <> 0 Then
                    PrintLine(ifl4, GlobalRoutines.FormatS("\            \ &", Form, Risp))
                Else
                    GoTo RetRet
                End If
            Next j
        Else
            For j = NumFileMax To 1 Step -1
                If NumForcellePerFila(j) <> 0 Then
                    Risp = Str(NumForcellePerFila(j)) : leno = Len(Risp) - 1
                    Mid(Form, 1, 14) = Mid(Risp, 2, leno) & Space(14 - leno)
                    Risp = Str(NumFileU - j + 1) : leno = Len(Risp) - 1 : Risp = Chr(44) & Mid(Risp, 2, leno) & "¦ FILA"
                    PrintLine(ifl4, GlobalRoutines.FormatS("\            \ &", Form, Risp))
                End If
            Next j
        End If
RetRet: FileClose(ifl4)
        DatiD = RTrim(Monitor.Motore.Inizio.Datidir) & "\" & Monitor.Motore.Inizio.CommPulita(gencommes) & ".ADU"
        If Not Monitor.Motore.Inizio.LavoriSciolti And Not System.IO.File.Exists(DatiD) Then FileCopy(cotub, DatiD)
        If frmOpFin.DefInstance.Check1.CheckState = 1 Then ControlADU(cotub)
        frmOpFin.DefInstance.Dispose()
    End Function
    Private Function Fontana() As Boolean
        Try
            File = Left(cotub, Len(cotub) - 3) & "MTO"
            Fontana = True
            If Not System.IO.File.Exists(File) Then
                Text = "Non è stata trovato il risultato  " & vbCrLf
                Text = Text & "dell' operazione di infilaggio tu-" & vbCrLf
                Text = Text & "bi.(MenuItem 5 della tracciatura)" & vbCrLf
                MsgBox(Text, MsgBoxStyle.Exclamation)
                FileClose(ifl4)
                Fontana = False
                Exit Function
            End If
            ifl = FreeFile()
            FileOpen(ifl, File, OpenMode.Input)
            Form = LineInput(ifl)
            i = 0
            Do Until EOF(ifl) Or Len(Form) = 0
                i = i + 1
                Form = LineInput(ifl)
            Loop
            FileClose(ifl)
            FileOpen(ifl, File, OpenMode.Input)
            Form = LineInput(ifl)
            ' numero gruppi
            Form = LineInput(ifl1)
            PrintLine(ifl4, GlobalRoutines.FormatS(Form, i, 1))
            For j = 1 To 7
                Rmin(j) = LineInput(ifl1)
            Next
            For j = 1 To i
                Form = LineInput(ifl)
                NumUg = GlobalRoutines.ValVir(prossimo(Form))
                Raggio = GlobalRoutines.ValVir(prossimo(Form))
                LunRet = GlobalRoutines.ValVir(prossimo(Form))
                '8 dia esterno
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(1), DaTos(iDat).dt(15)))
                '9 spessore
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(2), DaTos(iDat).dt(24)))
                '10 lunghezza rettilinea
                '     Print #ifl4, FormatS(Rmin(3), GlobalRoutines.ValVir(Mid$(Form, 21, 8))) ' DaTos(iDat).dt(26))
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(3), LunRet)) ' DaTos(iDat).dt(26))
                '14 raggio minimo
                'Raggio = GlobalRoutines.ValVir(Mid$(Form, 12, 8))
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(4), Raggio))
                '   incremento fila
                incr = 0 ' -(GlobalRoutines.ValVir(Mid$(Form, 33, 8)) - GlobalRoutines.ValVir(Mid$(Form, 17, 8)) - Raggio)
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(5), incr))
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(6), Passo))
                '16 numero file
                PrintLine(ifl4, GlobalRoutines.FormatS(Rmin(7), 1))
                '     Print #ifl4, FormatS(Rmin(7), NumUg)
                If j = 1 Then FileClose(ifl1)
                'Next
                '     Close #ifl
                '     Open File For Input As #ifl
                '     Line Input #ifl, Form
                'For j = 1 To i
                '     Line Input #ifl, Form
                '     n = GlobalRoutines.ValVir(Mid$(Form, 1, 8))
                '     Print #ifl4, Adjust(Str$(n), 14) + ",1¦ FILA"
                PrintLine(ifl4, GlobalRoutines.Adjust(Str(NumUg), 14) & ",1¦ FILA")
            Next
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub CalcIncr()
        If DaTos(iDat).dt(12) = 1 Then Tipo = "A" Else If DaTos(iDat).dt(12) = 2 Then Tipo = "C"
        If DaTos(iDat).dt(12) = 3 Then Tipo = "D" Else If DaTos(iDat).dt(12) = 4 Then Tipo = "B"
        If DaTos(iDat).PassoFascio > 2 Then
            If Tipo = "A" Then Tipo = "C" Else If Tipo = "C" Then Tipo = "A"
        End If
        Select Case Tipo
            Case "A" : incr = DaTos(iDat).Passo * System.Math.Cos(30 * System.Math.PI / 180)
                Passo = "triangolare"
            Case "B" : incr = DaTos(iDat).Passo
                Passo = "quadro"
            Case "C" : incr = DaTos(iDat).Passo / 2
                Passo = "triangolare ruotato"
            Case "D" : incr = (DaTos(iDat).Passo * System.Math.Sqrt(2)) / 2
                Passo = "quadro ruotato"
            Case "E" : incr = DaTos(iDat).Passo
                Passo = "" 'libero
        End Select
    End Sub
End Module
