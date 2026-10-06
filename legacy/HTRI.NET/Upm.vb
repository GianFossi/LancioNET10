Option Strict Off
Option Explicit On
Imports RoutBase1
Imports System.Math
Imports System.Runtime.InteropServices
<Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure clsMecData
    Public KPJ1 As Single 'Dum As Single 'KPJ1  1
    Public NumIt As Short 'NUMIT 3
    Public Ndum As Short 'NDUM  4
    Public Tipo As Short 'vedi UPM.BAS, subr. Config'TIPO  5
    <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public Logic() As Integer 'ESIS APERTO
    <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public CUSTMR As String 'CUSTMR 10
    <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public PLTLOC As String 'PLTLOC 20
    <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public ENGR As String 'ENGR   30
    <VBFixedString(10), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> Public HEADER As String 'HEADER 32
    <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public SRVICE As String 'SRVICE 37
    Public P As Single 'P      57
    Public PJ As Single 'PJ     59
    Public T As Single 'T      61
    Public CA As Single 'CA     63
    '   IN3    AS LONG
    Public TOLL As Single 'TOLL   65
    Public IN4 As Integer 'IN4    67
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public UNIMIS As String 'UNIMIS 69
    <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public SP() As Single '70T1,T2,T3,T4
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public St21 As String '105LINGUA IRIS
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public St22 As String '105LINGUA IEL
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public St23 As String '105LINGUA IVK
    <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public ITEMNO As String 'ITEMNO 81
    <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public JOBNUM As String 'JOBNUM 91
    <VBFixedArray(5), MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public Buf() As Single
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public Lingua As String '105LINGUA
    Public nPassi As Short 'NPASSI  106
    Public nBocIn As Short 'NBOCIN  107
    Public nBocOut As Short 'NBOCOT  108
    Public DBocIn As Single 'FBOCIN  109
    Public DBocOut As Single 'FBOCOT  111
    <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Rating As String 'RATING  113
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public HorPas As String 'HORPAS  123
    Public TipTest As Short 'TIPTEST 124
    <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public Ammiss0() As Single 'SJ0     125
    <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public Ammiss() As Single 'S       133
    <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public Sj() As Single 'SJ      141
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATUG As String 'MATUG   145
    <VBFixedString(12), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=12)> Public ICKNR As String 'ICKNR   154
    <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public BF() As Single 'BF      160
    <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public DF() As Single 'DF      170
    <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public TK() As Single 'TK      180
    <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public TF() As Single 'TF      190
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATSH As String '        200
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATTP As String '        209
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATEN As String '        218
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATSE As String '        227
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATTUB As String '        236
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATTAP As String '        245
    Public LUNGF As Single '        254
    Public Largf As Single '        256
    Public NFASCI As Integer '        258
    <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public BANCO As String '        260
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public IREV As String '        262
    Public NROWS As Short '        263
    Public NTUB As Integer 'n. tubi per fascio       264
    Public DO_Renamed As Single '        266
    Public TSP As Single '        268
    Public DALETT As Single '        270
    Public ALINCH As Single '        272
    Public SPTUB As Single '        274
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public SPBWG As String '        276
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public SPTOL As String '        277
    <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public TIPAL As String '        278
    Public TVERT As Single '        279
    Public H As Single '        281
    Public HE As Single '        283
    Public HX3 As Single '        285
    Public HX4 As Single '        287
    Public NS As Integer '        289
    Public MATHOM As Integer '        291
    Public SUG As Single '        293
    Public EWPS As Single 'saldatura setti                 295
    Public EWC As Single '        297
    Public e As Single '        299
    <VBFixedString(10), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> Public Mec As String '        301
    <VBFixedArray(15), MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public Nfile() As Single 'file per camera           306
    <VBFixedArray(15), MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public HX5() As Single 'altezza camere            338
    <VBFixedArray(24), MarshalAs(UnmanagedType.ByValArray, SizeConst:=25)> Public VUOTO() As Single '        370
    Public StiffEff As Single '        420
    Public NsFunz As Short '        422
    Public NsPad As Short 'n. tubi per testata       423
    Public Gap As Single 'aria tubo/setto           424
    <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public Bcgl() As Short '        426
    Public PassoRinf As Single '        428
    Public BucoRinf As Single '        430
    Public xx As Single '        432
    Public NFMAX As Single 'n. totale file per testata 434
    Public DInmm As Single '        436
    Public DOutmm As Single '        438
    Public SpInmm As Single '        440
    Public SpOutmm As Single '        442
    <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public SchIn As String '        444
    <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public SchOut As String '        446
    Public PVERT As Single '        448
    Public VuotA As Single '        450
    Public VuotB As Single '        452
    Public AltBocIn As Single ' Altezza tronchetto
    Public AltBocOut As Single '        456
    Public AltFlIn As Single ' Altezza totale bocchello
    Public AltFlOut As Single '        460
    Public LarghIntTel As Single '        462
    Public XXcorr As Single '        464
    Public Nasello As Single '        466
    <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public Ricorda() As Short '        468
    Public PassFraz As Short '        472
    <VBFixedArray(179), MarshalAs(UnmanagedType.ByValArray, SizeConst:=180)> Public Padding() As Short '        468
    <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public MATGUAR As String
    Public iMATGUAR As Short
    Public iMATUG As Short
    Public iMATSH As Short
    Public iMATTP As Short
    Public iMATEN As Short
    Public iMATSE As Short
    Public iMATTUB As Short
    Public iMATTAP As Short
    Public Codice As Short '        670
    <VBFixedArray(15), MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public Saldatura() As Short '1 setto saldato con End 671
    <VBFixedArray(15), MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public Pacc() As Single '        687
    <VBFixedArray(15), MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public Passo() As Single '        719
    Public Property T3() As Single
        Get
            Return SP(2)
        End Get
        Set(ByVal value As Single)
            SP(2) = value
        End Set
    End Property
    Public Property T2() As Single
        Get
            Return SP(1)
        End Get
        Set(ByVal value As Single)
            SP(1) = value
        End Set
    End Property
    Public Property T1() As Single
        Get
            Return SP(0)
        End Get
        Set(ByVal value As Single)
            SP(0) = value
        End Set
    End Property
    Public Property ESIS() As Boolean
        Get
            Return Logic(0) <> 0
        End Get
        Set(ByVal value As Boolean)
            Logic(0) = CInt(value)
        End Set
    End Property
    Public Property St2(ByVal i As Integer) As String
        Get
            Select Case i
                Case 1 : Return St21
                Case 2 : Return St22
                Case 3 : Return St23
            End Select
        End Get
        Set(ByVal value As String)
            Select Case i
                Case 1 : St21 = value
                Case 2 : St22 = value
                Case 3 : St23 = value
            End Select
        End Set
    End Property
    Public Sub Initialize()
        ReDim Logic(1)
        ReDim SP(3)
        '  ReDim St2(3)
        ReDim Nfile(15)
        ReDim HX5(15)
        ReDim VUOTO(24)
        ReDim Bcgl(1)
        ReDim Ricorda(3)
        ReDim Saldatura(15)
        ReDim Pacc(15)
        ReDim Passo(15)
        ReDim Buf(5)
        ReDim Padding(179)
        ReDim Ammiss(3), Ammiss0(3), Sj(1)
        ReDim BF(4), DF(4), TK(4), TF(4)
        CUSTMR = ""
        PLTLOC = ""
        ENGR = ""
        HEADER = ""
        SRVICE = ""
        UNIMIS = ""
        St21 = ""
        St22 = ""
        St23 = ""
        ITEMNO = ""
        JOBNUM = ""
        Lingua = ""
        Rating = ""
        HorPas = ""
        MATUG = ""
        ICKNR = ""
        MATSH = ""
        MATTP = ""
        MATEN = ""
        MATSE = ""
        MATTUB = ""
        MATTAP = ""
        BANCO = ""
        IREV = ""
        SPBWG = ""
        SPTOL = ""
        TIPAL = ""
        Mec = ""
        SchIn = ""
        SchOut = ""
        MATGUAR = ""
    End Sub
    Public Property BLTNUM() As Single
        Get
            Return BF(3 - 1)
        End Get
        Set(ByVal value As Single)
            BF(3 - 1) = value
        End Set
    End Property
    Public Property ARMI() As Single
        Get
            Return TK(2 - 1)
        End Get
        Set(ByVal value As Single)
            TK(2 - 1) = value
        End Set
    End Property
    Public Property HG() As Single
        Get
            Return TK(1 - 1)
        End Get
        Set(ByVal value As Single)
            TK(1 - 1) = value
        End Set
    End Property
    Public Property GASLAR() As Single
        Get
            Return DF(4 - 1)
        End Get
        Set(ByVal value As Single)
            DF(4 - 1) = value
        End Set
    End Property
    Public Property FACTM() As Single
        Get
            Return DF(2 - 1)
        End Get
        Set(ByVal value As Single)
            DF(2 - 1) = value
        End Set
    End Property
    Public Property YGASK() As Single
        Get
            Return DF(1 - 1)
        End Get
        Set(ByVal value As Single)
            DF(1 - 1) = value
        End Set
    End Property

    Public Property SRTBLT()
        Get
            Return BF(5 - 1)
        End Get
        Set(ByVal value)
            BF(5 - 1) = value
        End Set
    End Property
    Public Property SBLT()
        Get
            Return BF(4 - 1)
        End Get
        Set(ByVal value)
            BF(4 - 1) = value
        End Set
    End Property
    Public Property RISLAR() As Single
        Get
            Return DF(4 - 1)
        End Get
        Set(ByVal value As Single)
            DF(4 - 1) = value
        End Set
    End Property
    Public Property TOLLAV() As Single
        Get
            Return DF(5 - 1)
        End Get
        Set(ByVal value As Single)
            DF(5 - 1) = value
        End Set
    End Property
    Public Property STAND(ByVal i As Integer) As Single
        Get
            Select Case i
                Case 1, 2, 3
                    Return DF(i + 2 - 1)
                Case Else
                    Return TK(i - 4)
            End Select
        End Get
        Set(ByVal value As Single)
            Select Case i
                Case 1, 2, 3
                    DF(i + 2 - 1) = value
                Case Else
                    TK(i - 4) = value
            End Select
        End Set
    End Property
    Public Property TT() As Single
        Get
            Return TK(5 - 1)
        End Get
        Set(ByVal value As Single)
            TK(5 - 1) = value
        End Set
    End Property
    Public Property TFTF() As Single
        Get
            Return TK(4 - 1)
        End Get
        Set(ByVal value As Single)
            TK(4 - 1) = value
        End Set
    End Property
    Public Property XSPAN() As Single
        Get
            Return TK(3 - 1)
        End Get
        Set(ByVal value As Single)
            TK(3 - 1) = XSPAN
        End Set
    End Property
    Public Property BLTARE() As Single
        Get
            Return BF(2 - 1)
        End Get
        Set(ByVal value As Single)
            BF(2 - 1) = value
        End Set
    End Property
End Structure
Module modUPM
    Structure Filef
        <VBFixedArray(15)> Dim Nfile() As Single
        Public Sub Initialize()
            ReDim Nfile(15)
        End Sub
    End Structure
    Private nIt As Short
    Public nCasseloc, ii As Short
    Public NewFUPM, FileUPM, FileMec As String
    Public MecData(4) As clsMecData
    Public nOut(4) As Short
    Public nIn(4) As Short
    Public KUN As Short
    Public HeaderSetti(2) As SettiHeader
    Public HeaderStruct(0) As StructHeader
    Public File(16) As Single
    Public TipC(4, 4) As String
    Public nCasse(4) As Short
    Public nset(4) As Short
    Public TipoFas, LungSel As Short
    Public iCassa, VUOTO, iTest As Short
    Public iCode As Short
    Public Prev As String
    Public iPag, nPag As Short
    Public SpsBWG, SpsTol As String
    Private iSW As Short
    Private CodMan(4) As String
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura nFILEF prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private nFILEF As Filef
    Private NewFILE(32) As Short
    Private Nalt As Short
    Private InLinea, Aggior As Boolean
    Private Aggiorna, PassFraz As Boolean
    Private nPassi As Short
    ' Private iC(13, 4) As Short
    Private BocIn, BocOut As Short
    Private DBocIn, DBocOut As Single
    Private TipIn, TipOut As Short
    Private Rat As String
    Private Dtub As Single
    Private SpanIn, SpanOut As Single
    Public Tipo(2, 30) As Short
    ' Private LungStx(7) As Short
    ' ===========================================================================
    Private NfSup, NS1, iSup, iInf As Short
    Private Q3, Q1, Q2, NewPas, Vuot As Single
    Private iAltra As Short
    '==========Config==================================================
    Private i As Short
    Private junk As Integer
    Private itp As String
    Private Esito, Ncasi As Short
    Private Tit, Testo As String
    Private Ialt(5) As Boolean
    Private nnseta, nnsetb As Short
    Private ncamI, ncamS, ncam As Short
    Private nsopra, nsotto As Short
    Private TubeSh As Short
    Private itnr As String
    Private com As String
    Private iCShort, iD As Short
    Private Archiv(5) As Short
    Private dAiu(5) As String
    Private jj As Short
    Private Stringa(5) As String
    Private Scelta As Short
    Private Sezione(2) As Single
    Private NfilA(16, 2) As Short
    Private nseta(2) As Short
    Private TipoFas1 As Short
    '==============CalcUpmGen===============================
    Private Logi2 As Short
    Private Help As String
    Private Ris As Boolean
    '==================UPM====================================
    Private A As String
    Private x As Integer
    Private IEL As String
    Private Riga As String
    Private Nscelta As Short
    Private Nsv As Short
    Private iVec As Short
    Private nPasf, Nsf As Short
    Private kk, TotfileN, TotfileV, k As Short
    '=========================================================
    Sub Buckling()
        '
    End Sub

    Function DatiGenI(ByRef Nr As Short) As Boolean
        Dim Tit As String
        Dim ifl As Short
        Dim Riga As String
        Dim ifl1 As Short
        DatiGenI = True
        If Nr > 0 Then
            'If Asc(Lav(0).job) > 32 Then Prev.St = Lav(0).job Else Prev.St = job.contratto
            Prev = job.Contratto
1:          Tit = "Commessa " & LTrim(job.contratto) ' "Commessa "
            If iCassa > 1 Then Tit = ""
        Else
            If Not Monitor.Motore.Mostra(myAssembly, 3) Then Return False
            Tit = "Dati gener." 'Trim$(at2(52)) '
            Prev = Left(job.Contratto, 4) '"SALV"
        End If
        'IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(Prev))
        nIt = Nr
        If nIt = 0 Then nIt = Val(Right(Trim(job.contratto), 2))
        If Nr > 0 Then
            Stop
5:          '          UPMGTG(Prev, nIt, 1, iCassa)
3:          If Not Inq(Tit, , RadiceHelp & "::/Testpe.htm#DatiGen") Then DatiGenI = False : Exit Function
            If Asc(Risp(1)) <= 32 Then
                MsgBox("Inserire un codice alfanumerico di 4 caratteri per il numero di commessa", MsgBoxStyle.Critical)
                GoTo 5
            Else
                If Len(Trim(Risp(1))) <> 4 Then
                    MsgBox("Inserire un codice alfanumerico di 4 caratteri per il numero di commessa", MsgBoxStyle.Critical)
                    GoTo 5
                End If
            End If
            '          UPMPTG()
        Else
            ' UPMGTG(Prev, nIt, 3, iCassa)
        End If
    End Function

    Function DatiItem(ByRef It As String) As Boolean
        Dim Tit As String
        Dim ifl, iCv As Short
        Dim Help As String
        Help = RadiceHelp & "::/Testpe.htm#DatiIt"
        DatiItem = True
        UPMITM(1, iCassa)
        Tit = "Item " & It
        If It = "tubi" Then Tit = It '"tubi"Right$(at2(154), 4)
        If Monitor.Motore.Problem.Extension = ".MEC" Then
            ifl = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(1)))
            nCasseloc = LOF(ifl) \ Len(MecData(1))
            FileGet(ifl, MecData(iCassa), Max(Abs(iCassa), Max(iCassa, 1)))
            FileClose(ifl)
            If nCasseloc > 1 Then
                FaseDati = 14
                Inq(Tit, 1, Help)
                iCv = iCassa
                Do
                    System.Windows.Forms.Application.DoEvents()
                    If iCv <> iCassa Then
                        Monitor.Ritorna()
                        '  UPMGTG(Prev, nIt, 1, iCassa)
                        'Stop
                        DatiItem("")
                    End If
                Loop While Not Monitor.Motore.InputForms Is Nothing
                If OKDati Then
                    RegistraInq(ii, 1)
                    UPMPTM(iCassa)
                Else
                    DatiItem = False
                End If
            Else
                If Not Inq(Tit, , Help) Then DatiItem = False : Exit Function
                UPMPTM(iCassa)
            End If
        Else
            If Not Inq(Tit, , Help) Then DatiItem = False : Exit Function
            UPMPTM(iCassa)
        End If
        ifl = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(1)))
        FilePut(ifl, MecData(iCassa), Max(1, iCassa))
        FileClose(ifl)
    End Function

    Sub InitUPM()
        Dim i, ifl, j As Short
        ReDim Risp(65)
        ReDim Dom(65)
        '   ifl = FreeFile()
        '   FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM008.DAT"), OpenMode.Input, , OpenShare.Shared)
        '   For i = 1 To 7 : Input(ifl, LungStx(i)) : Next
        '   For j = 1 To 4 : For i = 1 To 13 : Input(ifl, iC(i, j)) : Next
        '   Next j
        '   FileClose(ifl)
        '--------------------------------------------------------
        'If AddDistinta = 0 And IUNL = 0 Then
        '10 Dim About As ProgDes
        '   About.ProgName = at2(19) '"UPM"
        '   About.ProgVers = at2(20) '"Vers. 0.00"
        '   About.VersDate = at2(21) '"15/07/93"
        '12 About.ProgDesc = at2(22) '"Calcolo Meccanico Testate AFC"
        '    LungTEM = 1014: LungMat = 44: LungInd = 804: LungPRE = 148
        'End If
        '    If Len(Gancio) = 0 Then Gancio = Chr$(32)
        '    If Asc(Gancio) > 32 Then
        '      Close #1
        '902   Open Gancio For Random As #1 Len = Len(Lav(0))
        '      Get #1, 1, Lav(0)
        '    End If
        '    DemoFinished = False
        Call InitStringUPM()
        '  INIZUPMF()
        For i = 0 To 4
            MecData(i).Initialize()
        Next
    End Sub

    Function UpmIniz() As Short
        'On Local Error GoTo ErrUI
        Dim Testo, Tit As String
        UpmIniz = True
2500:   If Not DatiGenI(Nrdit \ 2) Then UpmIniz = 1 : Exit Function
        ItemnSt = job.Comm.Ind(1).Data.Assieme.Trim
        SETRDIT(ItemnSt, Nrdit)
        If Nrdit = 0 Then
            iTest = 0
            UpmIniz = False
            Exit Function
        End If
2510:   If Not DatiItem(Trim(ItemnSt)) Then UpmIniz = False : Exit Function
        AlternU(Nalt)
        If Nalt <= 0 Then
            Testo = at1(49) & at1(50)
            '         Testo = "Questo item non possiede alcu-|"
            '    Testo = Testo + "na alternativa. Pertanto non  |"
            '    Testo = Testo + "c'e' niente da calcolare      |"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Nalt = 0 Then MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo))
            UpmIniz = False
2520:       Exit Function
        End If
        If Not DatiCassa(1) Then UpmIniz = False : Exit Function
2561:   Exit Function
        'ErrUI: Print "Err UpmIniz"; Err; Erl; Len(FileUPM); FileUPM: Stop
    End Function
    Sub AlternU(ByRef Nalt As Short)
        Dim i, iF1 As Short
        Dim Titolo As String
        Dim xAlt As Short
        'SEARCHA Ialta
        'For i = 1 To 5: Ialt(i) = Ialta.Ialt(i): Next
        Nalt = ActivAlt(Nrdit \ 2)
        'For i = 1 To 5
        ' If Ialt(i) > 0 Then Nalt = Nalt + 1
        'Next i
        If Nalt > 0 Then
            SETALT(Nalt)
        Else
            Nalt = actItem.Alterns.Count
        End If
        If Nalt = 1 Then
            ActivAlt(Nrdit \ 2) = 1
            job.Comm.Ind(2).Data.Assieme = Str(1)
            SETALT(1)
        ElseIf Nalt > 1 Then
            Nalt = -1
            MsgBox("Non è attiva alcuna alternativa. Procedura terminata")
        End If
        'If Nalt < 2 Then Exit Sub
        'Rif:
        'Dom$(1) = at2(46) ' "Nø dell'alternativa da calcolare"
        'Risp$(1) = Str(ActivAlt(Nrdit \ 2)) '"1"
        '  iF1 = FreeFile
        '  Open RTrim(Monitor.Motore.inizio.Archdir) + "\ARCH" + "1000.DAT" For Output As #iF1
        '  Print #iF1, "  25   0   0   0"
        '  For i = 1 To Nalt
        '     Print #iF1, Adjust("Alternativa esistente:" + Str$(i), 25)
        '  Next
        '  Archiv(1) = 1000
        '  Titolo = at2(47) ' "Scelta alternativa"
        '  If Not Monitor.Motore.inputdati(1, Titolo, Dom(), Risp(), "", Archiv(), Help()) Then Exit Sub
        '  Xalt = Val(Right(Trim(Risp(1)), 2))
        '  job.Comm.Ind(2).Data.Assieme = Str$(Xalt)
        '  SETALT Xalt
        ''DisplayU
        'Put #1, 1, Lav(0)
    End Sub

    Sub AnnulMec()
        Dim i As Short
        FileClose(33)
        FileUPM = CercaMec()
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(FileUPM)) > 0 Then IO.File.Delete(FileUPM)
        MecData(0).nPassi = 0
        Call AZZMEC()
        VUOTO = True
        For i = Apert.ListView1.Items.Count To 2 Step -1
            Apert.ListView1.Items.RemoveAt(i)
        Next
        Apert.ListView6.Items.Add("Il calcolo meccanico è stato annullato")
    End Sub

    Function CalcTubi(ByRef Nr As Short) As Boolean
        Dim i, ifl As Short
        Dim Stringa(14) As String
        Dim Tit As String
        Dim xVec As Short
        Dim dAiu(14) As String
        Dim groov, SP, Sall As Single
        Dim Corros, Eff As Single
        Dim itext As Short
        Dim tmin, t1 As Single
        Dim Text As String
        'On Local Error GoTo ErrTubi
        Dim Hel(9) As String
        Dim Riga As String
        CalcTubi = True
        FileClose(33)
        If Nr = 0 Then
            iCassa = 0
            If Not DatiGenI(Nr) Then CalcTubi = False : Exit Function
            iCassa = 0
900:        If Not DatiItem("tubi") Then CalcTubi = False : Exit Function
            'Open Monitor.Motore.Inizio.Workdir + "\SALV00.MEC" For Random As #33 Len = Len(MecData(0))
            FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        Else
901:        FileOpen(33, FileUPM, OpenMode.Random, , , Len(MecData(0)))
        End If
        FileGet(33, MecData(0), 1)
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM001.DAT"), OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 4
            Stringa(i) = LineInput(ifl)
            Stringa(i) = Left(Stringa(i), Len(Stringa(i)) - 1)
        Next
        For i = 1 To 8 : Dom(i) = LineInput(ifl) : Next
        Tit = LineInput(ifl)
        For i = 1 To 9 : Hel(i) = LineInput(ifl) : Next
        FileClose(ifl)
        'Stringa(1) = "Segmented"
        'Stringa(2) = "Extruded "
        'Stringa(3) = "Embedded "
        'Stringa(4) = "Wrap on  "
        'Dom$(1) = "Materiale tubi"
        'Dom$(2) = "Diametro est. [in]"
        'Dom$(3) = "Spessore (BWG)"
        'Dom$(4) = "Tolleranza"
        'Dom$(5) = "Tensione amm. [kg/cm2]"
        'Dom$(6) = "Tipo alette"
        'Dom$(7) = "Efficienza"
        'Dom$(8) = "Corrosione    [mm]"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Risp(5) = GlobalRoutines.myStr(12.0!, 6, 3, False) '"   12.000"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Risp(8) = GlobalRoutines.myStr(0.0!, 5, 0, False) ' "    0."
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Risp(7) = GlobalRoutines.myStr(1.0!, 2, 2, False) ' " 1.00"
        'IF Nr > 0 THEN
        Risp(1) = MecData(0).MATTUB
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Risp(2) = GlobalRoutines.myStr(MecData(0).DO_Renamed, 4, 2, False)
        Risp(3) = MecData(0).SPBWG
        Risp(4) = MecData(0).SPTOL
        Select Case MecData(0).TIPAL
            Case "SE" : xVec = 1
            Case "EX" : xVec = 2
            Case "EM" : xVec = 3
            Case "WO" : xVec = 4
            Case Else : xVec = 3
        End Select
        Risp(6) = RTrim(Stringa(xVec))
        'ELSE
        '   Risp$(1) = STRING$(16, CHR$(32))
        '   Risp$(2) = "   0.00"
        '   Risp$(3) = "14"
        '   Risp$(4) = "MW"
        '   xVec = 3
        '   Risp$(6) = RTRIM$(Stringa(xVec))
        'END IF
        'For i = 1 To 8: LungSt(i) = Len(Risp$(i)): Next
        'Tit$ = "Dati sui tubi"
RifTubi:
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(8, Tit, Dom, Risp, "", Archiv, dAiu) Then
            FileClose(33) : CalcTubi = False : Exit Function
        End If
        '    Case 3: 'BWG
        '     A$ = "Fornire codice compreso tra 2 e 20. |"
        'A$ = A$ + "Lo spessore sara' calcolato in auto-|"
        'A$ = A$ + "matico.                             |"
        '    a$ = Hel$(1)
        '    x = Alert(2, a$, 8, 11, 13, 64, "OK", "", "")
        '    Case 4: 'Tolleranza
        '     a$ = "Fornire codice MI per minimum wall e|"
        'a$ = a$ + "codice AV per average wall.         |"
        '    a$ = Hel$(2)
        '    x = Alert(2, a$, 8, 11, 13, 64, "OK", "", "")
        '    Case 6: 'Tipo alette
        '    xVec = Quale(4, "", Stringa(), Help$, xVec)
        '    Risp$(6) = RTrim$(Stringa(xVec))
        '    Case Else
        'End Select
        'Y = InputDati(0, 8, Tit$, Dom$(), Risp$(), LungSt())
        'Loop
        MecData(0).MATTUB = Risp(1)
        SpsBWG = Risp(3)
        MecData(0).SPBWG = Risp(3)
        SpsTol = Risp(4)
        MecData(0).SPTOL = Risp(4)
        MecData(0).DO_Renamed = Val(Risp(2))
        SP = 25.4 * objBWG.SpBWG(SpsBWG, SpsTol)
        If SP = 0.0! Then
            '     a$ = "La tolleranza o il BWG sono stati|"
            'a$ = a$ + "specificati in modo errato.      |"
            Tit = Hel(3)
            MsgBox(Tit)
            GoTo RifTubi
        End If
        If xVec = 3 Then groov = ReadLib(29, 1) Else groov = 0.0!
        Sall = Val(Risp(5))
        MecData(0).Ammiss(4) = Sall
        FilePut(33, MecData(0), 1)
        FileClose(33)
        Corros = Val(Risp(8))
        Eff = Val(Risp(7))
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + Hel(4)), OpenMode.Input, , OpenShare.Shared) ' "\TUBIMET.DAT"
        itext = FreeFile()
        FileOpen(itext, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        iPag = 1 : nPag = 1 ': IF Nr > 0 THEN iPag = 1 + nCasse(TipoFas): nPag = iPag + 1
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, iPag, nPag))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).ENGR, DateString))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, " ", MecData(0).ICKNR))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).CUSTMR, MecData(0).JOBNUM))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).SRVICE, MecData(0).ITEMNO))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).PLTLOC, MecData(0).IREV))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).MATTUB))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).SPBWG, MecData(0).SPTOL))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, Stringa(xVec)))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).P, MecData(0).P * 14.2233))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).T, MecData(0).T * 1.8 + 32))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, Corros, Corros / 25.4))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, Sall, Sall * 1422.33))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, MecData(0).DO_Renamed / 2, MecData(0).DO_Renamed / 2 / 25.4))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, Eff, Eff))
        tmin = MecData(0).P * MecData(0).DO_Renamed / 2 / (100 * Sall * Eff + 0.4 * MecData(0).P) + Corros
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, tmin, tmin / 25.4))
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, groov))
        t1 = SP - groov
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, SP, t1, t1 / 25.4))
        If t1 > tmin Then
            Text = Hel(5) '"t1 > t :   CHECKED"
        Else
            Text = Hel(6) '"t1 < t :   NOT CHECKED"
            Tit = Hel(8) & Str(tmin) '"spessore minimo ="
            Tit = Tit & Hel(9) & Str(t1) & "|" & Text ' "|spessore adott. ="
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Tit))
        End If
        Riga = Assumi(ifl, itext) : PrintLine(itext, GlobalRoutines.FormatS(Riga, Text))
        Riga = Assumi(ifl, itext)
        FileClose(ifl) : FileClose(itext)
        Exit Function
        'ErrTubi: Print "Err CalcTubi"; Err; Erl; FileUPM: Stop
    End Function

    Sub CasSplit()
        Dim Stringa3(10) As String
        Dim i, ifl As Short
        Dim Stringa(3) As String
        Dim Tit As String
        Dim dAiu(3) As String
        Dim Archiv(3) As Short
        Dim issue As Boolean
        Static x As Short
        If TipoFas < 2 Then Exit Sub
        If FileUPM = "" Then FileUPM = CercaMec()
3916:   FileOpen(33, FileUPM, OpenMode.Random, , , Len(MecData(0)))
        For i = 1 To nCasse(TipoFas)
            FileGet(33, MecData(i), i)
        Next
        Dim HX5(16) As Single
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM002.DAT"), OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 3 : Stringa(i) = LineInput(ifl) : Next
        Tit = LineInput(ifl)
        For i = 1 To 4 : Dom(i) = LineInput(ifl) : Next
        FileClose(ifl)
        'Stringa(1) = "Senza pattino Teflon"
        'Stringa(2) = "Con   pattino Teflon"
        'Stringa(3) = "Casse a cop.flangiato"
        If x < 1 Or x > 2 Then x = 1
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        x = Monitor.Motore.Quale(3, Tit, Stringa, "", x) ' "Strisciamento"
        If x < 3 Then
            Vuot = ReadLib(27, x)
        Else
            Vuot = 110.0! 'PROVVISORIO
        End If
        'Dom$(1) = "Aria fra casse split [mm]"
        'Dom$(2) = "Fori casse A/B in linea?"
        Risp(1) = GlobalRoutines.myStr(Vuot, 4, 2, False)
        Risp(2) = "SI"
        Monitor.Motore.Chiamante = Monitor
        issue = Monitor.Motore.InputDati(2, Dom(3), Dom, Risp, "", Archiv, dAiu) ' "Splittaggio casse"
        Vuot = Val(Risp(1))
        Select Case TipoFas
            Case 2 : MecData(1).VuotA = Vuot : MecData(1).VuotB = 0.0!
            Case 3 : MecData(1).VuotA = 0.0! : MecData(1).VuotB = Vuot
            Case 4 : MecData(1).VuotA = Vuot : MecData(1).VuotB = Vuot
        End Select
        If Left(Risp(2), 1) <> "S" Then InLinea = False Else InLinea = True
        Aggior = False
        Select Case TipoFas
            Case 2 : iSup = 1 : iInf = 2 : iAltra = 3
                Fai()
            Case 3 : iSup = 2 : iInf = 3 : iAltra = 1
                Fai()
            Case 4 : iSup = 1 : iInf = 2
                iAltra = 4
                If MecData(1).NFMAX < MecData(3).NFMAX Then iAltra = 3
                Fai()
                iSup = 3 : iInf = 4
                iAltra = 1
                If MecData(1).NFMAX < MecData(3).NFMAX Then iAltra = 2
                Fai()
        End Select
        For i = 1 To nCasse(TipoFas)
            FilePut(33, MecData(i), i)
        Next
        FileClose(33)
        Exit Sub
    End Sub
    Private Sub Fai()
        Aggior = False
        NS1 = MecData(iSup).NS + 1
        NfSup = 0
        For ii = 1 To NS1 : NfSup = NfSup + MecData(iSup).Nfile(ii - 1) : Next
        If NS1 > 1 Then
            Q1 = Int(2 * (MecData(iSup).HX5(NS1 - 1) - MecData(iSup).VUOTO(NS1 - 1) / 2 - (System.Math.Abs(MecData(iSup).Nfile(NS1 - 1)) - 1) * MecData(1).PVERT)) / 2
        Else
            Q1 = MecData(iSup).xx '+ MecData(iSup).DO / 2
        End If
        If MecData(iInf).NS > 0 Then
            Q2 = Int(2 * (MecData(iInf).HX5(1 - 1) - MecData(iInf).VUOTO(1 - 1) / 2 - (System.Math.Abs(MecData(iInf).Nfile(1 - 1)) - 1) * MecData(1).PVERT)) / 2
        Else
            Q2 = MecData(iInf).xx '+ MecData(iInf).DO / 2
        End If
        Q3 = Vuot + MecData(iSup).SP(1 - 1) + MecData(iInf).SP(1 - 1)
        'NO! MecData(iSup).VUOTO(NS1) = Q1! + Q2! + Q3! - MecData(iSup).PVERT
        NewPas = Q1 + Q2 + Q3 '+ MecData(iSup).PVERT
        If MecData(iSup).Passo(NfSup - 1) < NewPas Then Aggior = True
        MecData(iSup).Passo(NfSup - 1) = NewPas
        If iAltra > 0 Then
            If InLinea Then MecData(iAltra).Pacc(NfSup - 1) = NewPas Else MecData(iAltra).Pacc(NfSup - 1) = 0.0!
        End If
        If Aggior And InLinea Then
            '               a$ = "Attenzione! Sono stati aggiornati|"
            '          a$ = a$ + "le altezze di alcune camere.     |"
            '          a$ = a$ + "Ripassare  il calcolo testate.   |"
            MsgBox(Dom(4))
        End If
        'da a ggiungere gonfiaggio iAltra
    End Sub
    Sub Bocchll(ByRef iTestin As Short)
        'On Local Error GoTo ErrBocchll
        Dim Stringa3(16) As String
        Dim i As Short
        Dim itp, Cod As String
        Dim ifl, j As Short
        Dim Riga, Tit As String
        Dim dAiu(13) As String
        Dim Archiv(13) As Short
        Dim u As String
        Dim SpanH As Single
        iTest = iTestin
        ENuovo()
        For i = 1 To 4
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CodMan(i) = objDatBase.DatBase(2, 66 + i, Nrdit \ 2, 1, itp, 0)
            If Asc(CodMan(i)) < 33 Then
                If i < 3 Then CodMan(i) = "15" Else CodMan(i) = "00"
            End If
        Next
        With objDatBase
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            BocIn = .CVI(.DatBase(4, 6, Nrdit \ 2, 1, itp, 0))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            BocOut = .CVI(.DatBase(4, 7, Nrdit \ 2, 1, itp, 0))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DBocIn = .CVS(.DatBase(7, 19, Nrdit \ 2, 1, itp, 0))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DBocOut = .CVS(.DatBase(7, 18, Nrdit \ 2, 1, itp, 0))
            Dtub = .CVS(.DatBase(5, 1, Nrdit \ 2, 1, itp, 0))
            Rat = .DatBase(2, 13, Nrdit \ 2, 1, itp, 1)
            iTest = .CVI(.DatBase(2, 9, Nrdit \ 2, 1, itp, 0))
            iCode = .CVI(.DatBase(2, 21, Nrdit \ 2, 1, itp, 0))
        End With
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        If Not VUOTO Then
            FileGet(33, MecData(0), 1)
            TipIn = MecData(0).Bcgl(1 - 1) '1=boccaglio 0=bocchello
            TipOut = MecData(0).Bcgl(2 - 1)
            ' SpanH = MecData(0).H
        Else
            If DBocIn < 5.9 Then TipIn = 0 Else TipIn = 1
            If DBocOut < 5.9 Then TipOut = 0 Else TipOut = 1
            '   Select Case iTest
            '     Case 3, 4
            '        SpanH = ReadLib(4, 3)
            '     Case Else
            '        SpanH = ReadLib(4, 2)
            '   End Select
        End If
Rifai:
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM006.dat"), OpenMode.Input, , OpenShare.Shared)
        For i = 3 To 9 Step 2 : Dom(i) = LineInput(ifl) : Next
        Riga = LineInput(ifl)
        Tit = LineInput(ifl)
        For i = 1 To 10 : Stringa3(i) = LineInput(ifl) : Next
        FileClose(ifl)
        Dom(1) = Stringa3(8) & Str(BocIn) & " D" & Str(DBocIn) & Chr(34) & Stringa3(10) ' ";Tipo:"'"Inlet:  Nø "
        Dom(2) = Stringa3(9) & Str(BocOut) & " D" & Str(DBocOut) & Chr(34) & Stringa3(10) ' ";Tipo:"' "Outlet: Nø "
        Select Case TipIn
            Case 1 : Risp(1) = "Sagomato"
            Case 2 : Risp(1) = "LWN"
            Case Else : Risp(1) = "WN"
        End Select
        Select Case TipOut
            Case 1 : Risp(2) = "Sagomato"
            Case 2 : Risp(2) = "LWN"
            Case Else : Risp(2) = "WN"
        End Select
        'Risp$(1) = Str$(TipIn)
        'Risp$(2) = Str$(TipOut)
        'Dom$(3) = "VENTS      Nø tot.:"
        'Dom$(5) = "DRAINS     Nø tot.:"
        'Dom$(7) = "TH.WELLS   Nø tot.:"
        'Dom$(9) = "PR.GAUGES. Nø tot.:"
        Dom(11) = "Tipo attacchi secondari"
        Select Case Asc(Right(CodMan(1), 1))
            Case Is < 65
                Risp(11) = "Manicotti"
            Case Else
                Risp(11) = "Bocchelli"
        End Select
        Archiv(11) = 119
        For i = 4 To 10 Step 2
            Dom(i) = Riga '"             size:"
            Cod = Right(CodMan((i - 2) \ 2), 1)
            If Asc(Cod) < 65 Then
                j = Val(Cod) - 3
            Else
                j = Asc(Cod) - 64
            End If
            If j < 1 Or j > 6 Then j = 1
            Risp(i) = Trim(Stringa3(j)) 'Right$(CodMan$((i - 2) \ 2), 1)
            Archiv(i) = 118
            Risp(i - 1) = Left(CodMan((i - 2) \ 2), 1)
        Next
        dAiu(1) = "*" ' Monitor.Motore.inizio.converticr(at2(81))
        dAiu(2) = dAiu(1)
        Archiv(1) = 120 : Archiv(2) = 120
        Dom(12) = "Span min Boc In"
        Risp(12) = Str(Int(SpanIn))
        Dom(13) = "Span min Boc Out"
        Risp(13) = Str(Int(SpanOut))
        'For i = 1 To 10: LungSt(i) = Len(Risp$(i)): Next
        'Tit$ = "Lista bocchelli"
        FaseDati = 9
        Apert.Enabled = False
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(1, 13, Tit, Dom, Risp, "", Archiv, dAiu)
        Monitor.Motore.InputForms(1 - 1).Top = 40
        Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
        If TipIn = 1 Then Monitor.Motore.InputForms(1 - 1).HelpFile(0).Visible = False
        If TipOut = 1 Then Monitor.Motore.InputForms(1 - 1).HelpFile(1).Visible = False
        MinSpan(1, TipIn, 1)
        MinSpan(2, TipOut, 1)
        AcqDati()
        'ErrBocchll: Print "Err Bocchll"; Err; Erl: Stop
    End Sub

    'Function CarPreU()
    'CarPreU = True
    'On Local Error GoTo 2111
    'If Asc(job.contratto) > 32 And Left$(job.contratto, 1) <> Chr$(36) Then
    ''a$ = RTRIM$(at1(4))
    ''     a$ = "Si prega di chiudere il preventivo|"
    ''a$ = a$ + "corrente prima di aprirne un'altro|"
    ''    X = Alert(2, a$, 8, 11, 13, 64, "OK", "", "")
    ''    EXIT SUB
    '    '    ChiPreU
    'End If
    'Gancio = Workdir + "\DATI.TE1"
    'Close #1
    'Open Gancio For Random As #1 Len = Len(Lav(0))
    'Get #1, 1, Lav(0)
    'job.Comm.Ind(1).Data.Assieme = Chr$(36): job.Comm.Ind(2).Data.Assieme = Chr$(48)
    'If Asc(job.contratto) > 32 Then
    '    ApriU LTrim$(RTrim$(job.contratto))
    ''    Prendi
    '    CLOSPREV
    ''    Lav(0).Clie = Risp$(2): Lav(0).Item = Risp$(3): Lav(0).Prev = Risp$(4): Lav(0).Comp = Risp$(5)
    ''    a$ = "        LAVORO CORRENTE:  | |"
    ''    a$ = a$ + " Numero Preventivo: " + job.contratto + CHR$(124)
    ''    a$ = a$ + " Cliente          : " + Lav(0).Clie + CHR$(124)
    ''    a$ = a$ + " Indirizzo        : " + Lav(0).Item + CHR$(124)
    ''    a$ = a$ + " Luogo impianto   : " + Lav(0).Prev + CHR$(124)
    '    a$ = at2(58)
    '    a$ = a$ + at2(59) + job.contratto + Chr$(124)
    '    a$ = a$ + at2(60) + Lav(0).Clie + Chr$(124)
    '    a$ = a$ + at2(61) + Lav(0).Item + Chr$(124)
    '    a$ = a$ + at2(62) + Lav(0).Prev + Chr$(124)
    '    x = Alert(2, a$, 8, 11, 18, 64, "Va bene", "Un altro", "Uno nuovo")
    '    If x = 0 Then job.contratto = String$(4, Chr$(32)): CarPreU = False: Exit Function
    'Else
    '    x = 2
    'End If
    'If x = 1 Then
    '   GoTo Fine4
    'ElseIf x = 2 Then
    '   LOCATE 23, 12
    '   Print RTrim$(at1(5))
    ''   PRINT "LISTA DEI PREVENTIVI PRESENTI NELLO SPAZIO DI LAVORO...."
    '   LOCATE 24, 27
    ''   PRINT "SCEGLI QUELLO DA APRIRE "; : LOCATE 23, 12
    '   Print RTrim$(at1(6));: LOCATE 23, 12
    '   a$ = at2(50) '"Lista preventivi"
    '   NomeFileUPM = ScegliFileUPM(a$, Workdir, "PRV", True)
    '    If DisplayType Then Color 1, 15 Else Color 0, 15      'Monochrome
    ''  LOCATE 23, 12: PRINT SPACE$(LEN(RTRIM$(at1(5))));
    ''  LOCATE 24, 27: PRINT SPACE$(LEN(RTRIM$(at1(6))));
    '    If DisplayType Then Color 15, 1 Else Color 15, 0      'Monochrome
    '   If Len(NomeFileUPM) = 0 Then GoTo Fine5
    '   job.contratto = Left$(NomeFileUPM, 4)
    '   ApriU LTrim$(RTrim$(job.contratto))
    '   job.Comm.Ind(1).Data.Assieme = Chr$(36)
    '  job.Comm.Ind(2).Data.Assieme = Chr$(48)
    '   GoTo Fine5
    'ElseIf x = 3 Then
    '   job.contratto = String$(4, Chr$(32))
    '   Put #1, 1, Lav(0)
    ''   NuoPreU
    'Else
    'job.contratto = String$(4, Chr$(32))
    'Exit Function
    'End If
    'Fine4:
    'ApriU LTrim$(RTrim$(job.contratto))
    'Put #1, 1, Lav(0)
    'Fine5:
    'DisplayU
    'Exit Function
    '2111:
    'If Err = 70 Then
    '   EditoreF WindowNext, Monitor.motore.inizio.Archdir + "\HTRI13.DAT", ""
    '   job.contratto = Space$(1)
    '   Resume Fine5
    'Else
    '  'PRINT "Errore irrecuperabile (CarPre)"; ERL; ERR: END
    '   Print RTrim$(at1(7)); Erl; Err: End
    'End If
    'End Function

    'Function EdiIteU()
    'On Local Error GoTo EIU
    'Dim Riga$(1)
    'EdiIteU = True
    'If Asc(job.contratto) < 33 Then i = CarPreU
    'If Asc(job.contratto) < 33 Then EdiIteU = False: Exit Function
    'If Asc(LTrim$(job.Comm.Ind(1).Data.Assieme)) > 32 And Left$(job.Comm.Ind(1).Data.Assieme, 1) <> Chr$(36) Then
    ''     a$ = "Vuoi lavorare sull'item corrente  |"
    ''a$ = a$ + "(" + RTRIM$(job.Comm.Ind(1).Data.Assieme) + ")" + ", o vuoi cambiare item?|"
    'a$ = RTrim$(at1(35)) + RTrim$(job.Comm.Ind(1).Data.Assieme) + at1(36)
    '300 If AddDistinta < 300 Then
    '    x = Alert(2, a$, 8, 11, 13, 64, "Corrente", "Cambia", "")
    '    Else
    '    x = 1
    '    End If
    '    If x = 0 Then EdiIteU = False: Exit Function
    '    If x = 1 Then
    '      Riso$(1) = job.Comm.Ind(1).Data.Assieme
    '      Help$ = at1(56)
    '      If AddDistinta < 300 Then
    '      Do
    '310   Esito = Cartigli(1, 1, "Item attuale", Help$, Tito$(), Riso$())
    '     Riso$(1) = LTrim$(Riso$(1))
    '      Loop Until Len(Riso$(1)) > 0 And Asc(Riso$(1)) > 32
    '     If Esito = 2 Then EdiIteU = False: Exit Function
    '     End If
    '      job.Comm.Ind(1).Data.Assieme = Riso$(1)
    '      Itemn.St = job.Comm.Ind(1).Data.Assieme
    '      Nrdit = -2
    '      Editi
    '      Exit Function
    '  End If
    'End If
    '    job.Comm.Ind(2).Data.Assieme = Chr$(48)
    '    If Len(Dir$(at1(55) + RTrim$(job.contratto))) > 0 Then Kill at1(55) + RTrim$(job.contratto)
    '    LISTITEM 0, 0
    '330 Open at1(55) + RTrim$(job.contratto) For Input As #3
    '    If LOF(3) = 0 Then
    '       Close #3
    'a$ = RTrim$(at1(10) + at1(11))
    ''         a$ = "In questo preventivo non e'  |"
    ''    a$ = a$ + "stato inserito ancora nessun |"
    ''    a$ = a$ + "Item. Non c'e' niente da cal-|"
    ''    a$ = a$ + "colare                      |"
    '    x = Alert(4, a$, 9, 10, 14, 70, "SI", "NO", "")
    '    If x = 2 Then EdiIteU = False: Exit Function
    '    i = 0
    '340 Inseri
    '    Editi
    '    NuovoU 1
    'Else
    'For i = 1 To 99
    '   Line Input #3, Item$(i)
    '   If EOF(3) Then Exit For
    'Next
    'Close #3
    'Item$(i + 1) = "Nuovo Item"
    'For j = 1 To i
    '   Item$(j) = Adjust$(LTrim$(RTrim$(Item$(j))), 20)
    '   Itemn.St = Item$(j)
    ''360 SETRDIT Itemn, Nrdit
    '   job.Comm.Ind(1).Data.Assieme = Itemn.St
    '  Call ENuovo 'FileUPM = CercaMec
    '   If Len(Dir$(FileUPM)) > 0 And Not VUOTO Then
    '       Item$(j) = Item$(j) + "(OK)"
    '  Else
    '       Item$(j) = Item$(j) + "(..)"
    '   End If
    'Next
    'x = myListBox(1, 1, 1, Item$(), i + 1, 0, "Items", True)
    '    Select Case x
    '        Case 0
    '           EdiIteU = False
    '            Exit Function
    '        Case i + 1
    '400         Inseri
    '4 '02         Editi
    '4 '04         NuovoU 1
    '        Case Else
    '            job.Comm.Ind(1).Data.Assieme = Item$(x)
    '            Itemn.St = Item$(x)
    '            Editi
    '    End Select
    'End If
    'Exit Function
    'EIU: Print "Err EdiIteU"; Err; Erl: End
    '-------------------------------------------------
    'End Function

    'Sub Editi()
    ''DisplayU
    'Put #1, 1, Lav(0)
    'Itemn.St = LTrim$(job.Comm.Ind(1).Data.Assieme)
    'SETRDIT Itemn, Nrdit
    'If AddDistinta > 299 Then Exit Sub
    'RISCRI 0, 0
    'Open at1(55) + RTrim$(job.contratto) For Input As #3
    'For i = 1 To 40: Line Input #3, Rispv$(i): Next i
    'Close #3
    'Open Archdir + at2(110) For Random Shared As #2 Len = 52 '"\DOAPAI.DAT"
    'For j = 1 To 4
    'If j = 4 And Not Contin Then Exit For
    'Rifai1:
    'For i = 1 To iC(13, j)
    '   Risp$(i) = Rispv$(iC(i, j))
    '   LungSt(i) = Len(Risp$(i))
    '   Get #2, iC(i, j), Domanda(0)
    '   Dom$(i) = Domanda(0).St
    '   Tipo(i) = Val(Mid$(Dom$(i), 21, 5))
    '   Archiv(i) = Val(Mid$(Dom$(i), 31, 5))
    '   Dom$(i) = Left$(Dom$(i), 20)
    '   If j = 1 And i = 6 And Risp$(i) = String$(2, Chr$(32)) Then Risp$(i) = "AL"
    '   If j = 1 And i = 7 And Risp$(i) = String$(2, Chr$(32)) Then Risp$(i) = "NO"
    'Next i
    'i& = STACK
    'Tit$ = at2(52) '"Dati generali
    'Y = inputdati(2, iC(13, j), Tit$, Dom$(), Risp$(), LungSt())
    'Do
    'Select Case Y
    '    Case -3
    '               junk = Alert(4, Help$, 4, 3, 10, 58, "OK", "", "")
    '    Case -2
    '               WindowClose 2: Close #2: Exit Sub
    '    Case -1
    '               WindowClose 2: Exit Do
    '    Case Else
    '       Select Case Tipo(Y)
    '          Case 0
    ''         a$ = "Dato in formato libero       |"
    '    a$ = at1(34)
    '    x = Alert(4, a$, 9, 10, 14, 70, "OK", "", "")
    '          Case 1
    '             If Archiv(Y) > 0 Then Risp$(Y) = Adjust(ReadArch$(Archiv(Y), x), LungSt(Y))
    '          Case 2
    ''         a$ = "Dato in formato F10.0        |"
    '    a$ = at1(37)
    '    x = Alert(4, a$, 9, 10, 14, 70, "OK", "", "")
    '       End Select
    'End Select
    'Y = inputdati(0, iC(13, j), Tit$, Dom$(), Risp$(), LungSt())
    'Loop
    ''    PRINT "Editi dopo  di Inputdati"; FRE(a$)
    ''PRINT "l"; FRE("l")
    ''PRINT "-1"; FRE(-1)
    ''PRINT "-2"; FRE(-2); STACK: u$ = INPUT$(1)
    'For i = 1 To iC(13, j)
    '   If Len(Risp$(i)) < LungSt(i) Then Risp$(i) = Risp$(i) + String$(LungSt(i) - Len(Risp$(i)), Chr$(32))
    '   Rispv$(iC(i, j)) = Risp$(i)
    'Next i
    'Select Case j
    '   Case 1
    '     Rispv$(iC(7, 1)) = UCase$(Rispv$(iC(7, 1)))
    '     Select Case Rispv$(iC(7, 1))
    '        Case "SI"
    '          Contin = True
    '        Case "NO"
    '          Contin = False
    '        Case Else
    'a$ = RTrim$(at1(12))
    ''         a$ = "Il valore per 'SERPENTINO VAPORE' puo'|"
    ''    a$ = a$ + "essere solo SI o NO.                  |"
    '    x = Alert(4, a$, 9, 10, 14, 70, "OK", "", "")
    '    GoTo Rifai1
    '     End Select
    'End Select
    'Next j
    'Close #2
    'Open at1(55) + RTrim$(job.contratto) For Output As #2
    'For i = 2 To 40
    ' If i > 28 And Not Contin Then Exit For
    ' Print #2, Rispv$(i)
    'Next
    'Close #2
    'LOOPDOM 0, 0
    'End Sub

    'Sub Inseri()
    'Riso$(1) = Space$(20)
    'Help$ = at1(56)
    '      Do
    'Esito = Cartigli(1, 1, "Nuovo Item", Help$, Tito$(), Riso$())
    '      Riso$(1) = LTrim$(Riso$(1))
    '      Loop Until Len(Riso$(1)) > 0 And Asc(Riso$(1)) > 32
    'If Esito = 2 Then Exit Sub
    'Riso$(1) = LTrim$(Riso$(1))
    'If Len(Riso$(1)) < 20 Then Riso$(1) = Riso$(1) + String$(20 - Len(Riso$(1)), " ")
    'Itemn.St = Riso$(1)
    'SETRDIT Itemn, Nrdit
    'If Nrdit > 0 Then
    '         a$ = "L'item " + RTrim$(Riso$(1)) + " esiste gia'.|"
    '               junk = Alert(4, Help$, 4, 3, 10, 58, "OK", "", "")
    '    Exit Sub
    'End If
    'Item$(i + 1) = Riso$(1)
    'job.Comm.Ind(1).Data.Assieme = Item$(i + 1)
    'Itemn.St = Item$(i + 1)
    'If Nrdit = 0 Then NEWITM 0, 0, Itemn
    'If i > 0 Then GoSub Copy
    'SETRDIT Itemn, Nrdit
    'Exit Sub
    'Copy:
    'a$ = RTrim$(at1(13))
    ''                 a$ = "Vuoi copiare i dati da un altro|"
    ''            a$ = a$ + "item per poi editarli?         |"
    '            x = Alert(2, a$, 8, 11, 13, 64, "NO", "SI", "")
    '            If x = 2 Then
    '            a$ = at2(23) ' "Items da copiare"
    'x = myListBox(1, 1, 1, Item$(), i, 0, a$, True)
    '            Itemv.St = Item$(x)
    '            COPIA Itemv, Itemn
    '            End If
    'Return
    'End Sub

    'Sub NuovoU(isw)
    'If isw = 0 Then
    '  If Asc(job.contratto) < 33 Then i = CarPreU
    '  If Asc(job.contratto) < 33 Then Exit Sub
    '  Fstr$ = Monitor.motore.inizio.workdir + "\" + RTrim$(job.contratto) + ".STR"
    '  If Len(Fstr$) > 0 Then Kill Fstr$
    '  Fstr$ = Monitor.motore.inizio.workdir + "\" + RTrim$(job.contratto) + ".SUM"
    '  If Len(Fstr$) > 0 Then Kill Fstr$
    '  Inseri
    'End If
    ''  IF NOT AcqDati THEN EXIT SUB
    'AddDistinta = 300
    'CLOSPREV
    'Catena "HTRI"
    'End Sub
    Function VerifArea() As Short
        Dim Stringa3(10) As String
        Dim ifl, i As Short
        Dim factor As Single
        Dim HXOut, HXIn, HX As Single
        Dim ASA As Short
        Dim AreaActI, AreaIn, Area As Single
        Dim AreaActO, AreaOut, dHX As Single
        Dim FdefIn, FdefOut As Single
        Dim Help As String
        Dim Risp As Integer
        Dim Stringa(3) As String
        Dim u As String
        Dim di, DN As Single
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM007.DAT"), OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 10 : Stringa3(i) = LineInput(ifl) : Next
        FileClose(ifl)
        factor = ReadLib(4, 1)
917:    FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        FileGet(33, MecData(iCassa), Max(Abs(iCassa), 1))
        'HXIn = MecData(0).HX5(1) - MecData(0).Sp(3-1) / 2 + MecData(0).VUOTO(1)
        HXIn = MecData(iCassa).HX5(1 - 1) - MecData(iCassa).SP(3 - 1) / 2
        'HXOut = mecdata(icassa).HX5(mecdata(icassa).NS + 1) - mecdata(icassa).Sp(3-1) / 2 + mecdata(icassa).VUOTO(mecdata(icassa).NS)
        HXOut = MecData(iCassa).HX5(MecData(iCassa).NS + 1 - 1) - MecData(iCassa).SP(3 - 1) / 2
        If MecData(iCassa).nBocIn > 0 And MecData(iCassa).DBocIn > 0 Then
            ASA = Val(Mid(MecData(iCassa).Rating, 5, 5))
            DN = MecData(iCassa).DBocIn
            Call SubScelta(DN, ASA, di)
            AreaIn = PI * di ^ 2 / 4 * factor 'da cambiare chiamando B di LookTipoBocch
            AreaActI = MecData(iCassa).H * HXIn
            If iTest = 12 Then AreaActI = AreaActI + PI * MecData(iCassa).H ^ 2 / 8
            AreaActI = 2 * AreaActI
        Else
            AreaIn = 0
        End If
        If MecData(iCassa).nBocOut > 0 And MecData(iCassa).DBocOut > 0 Then
            ASA = Val(Mid(MecData(iCassa).Rating, 5, 5))
            DN = MecData(iCassa).DBocOut
            Call SubScelta(DN, ASA, di)
            AreaOut = PI * di ^ 2 / 4 * factor
            AreaActO = MecData(iCassa).H * HXOut
            If iTest = 12 Then AreaActO = AreaActO + PI * MecData(iCassa).H ^ 2 / 8
            AreaActO = 2 * AreaActO
        Else
            AreaOut = 0
        End If
        If AreaIn > 0 And AreaIn > AreaActI Then FdefIn = (AreaIn - AreaActI) / AreaIn * 100 Else FdefIn = 0
        If AreaOut > 0 And AreaOut > AreaActO Then FdefOut = (AreaOut - AreaActO) / AreaOut * 100 Else FdefOut = 0
        If FdefIn > 0 Or FdefOut > 0 Then
            Help = Stringa3(1) ' "La Sezione delle camere di ingresso|"
            'Help$ = Help$ + "e/o uscita e' insufficiente       |"
            Help = Help & Stringa3(2) + GlobalRoutines.myStr(FdefIn, 3, 0, False) + " %|" '"  Deficit cam.ingr: "
            Help = Help & Stringa3(3) + GlobalRoutines.myStr(FdefOut, 3, 0, False) + " %|" '"  Deficit cam.usc : "
            Help = Help & Stringa3(4) ' "    Vuoi correggere?"
            Risp = MsgBox(Monitor.Motore.Inizio.ConvertiCr(Help), MsgBoxStyle.Question + MsgBoxStyle.YesNo)
            If Risp = MsgBoxResult.No Then VerifArea = 0 : GoTo FinArea
            Stringa(1) = Stringa3(5) ' "Correzione della larghezza"
            Stringa(2) = Stringa3(6) ' "Correzione della altezza"
            Stringa(3) = Stringa3(7) ' "Passa ad OBROUND"
9120:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            i = Monitor.Motore.Quale(3, Stringa3(8), Stringa, Stringa3(9), 2)
            Select Case i
                Case 0 : VerifArea = 0 : GoTo FinArea
                Case 1
                    If FdefIn > FdefOut Then
                        HX = HXIn : Area = AreaIn / 2
                    Else
                        HX = HXOut : Area = AreaOut / 2
                    End If
                    If iTest = 12 Then
                        MecData(iCassa).H = CShort((System.Math.Sqrt(HX * HX + PI / 2 * Area) - HX) / PI * 4 + 1)
                    Else
                        MecData(iCassa).H = CShort(Area / HX + 1)
                    End If
                    VerifArea = 1
                Case 2
                    If FdefIn > 0 Then
                        AreaIn = AreaIn / 2
                        If iTest = 12 Then AreaIn = AreaIn - PI / 8 * MecData(iCassa).H ^ 2
                        dHX = AreaIn / MecData(iCassa).H - HXIn
                        MecData(iCassa).HX5(1 - 1) = CShort(HXIn + dHX + 1 + MecData(iCassa).SP(3 - 1) / 2)
                        dHX = MecData(iCassa).HX5(1 - 1) - HXIn
                        MecData(iCassa).XXcorr = MecData(iCassa).xx + dHX
                    End If
                    If FdefOut > 0 Then
                        AreaOut = AreaOut / 2
                        If iTest = 12 Then AreaOut = AreaOut - PI / 8 * MecData(iCassa).H ^ 2
                        dHX = AreaOut / MecData(iCassa).H - HXOut
                        MecData(iCassa).HX5(MecData(iCassa).NS + 1 - 1) = CShort(HXOut + dHX + 1 + MecData(iCassa).SP(3 - 1) / 2)
                        dHX = MecData(iCassa).HX5(MecData(iCassa).NS + 1 - 1) - HXIn
                        MecData(iCassa).XXcorr = MecData(iCassa).xx + dHX
                    End If
                    VerifArea = 1
                Case 3
                    iTest = 12
                    u = objDatBase.PutBasCh(2, 9, Nrdit \ 2, 1, objDatBase.MKI(iTest), 0)
                    VerifArea = 2
            End Select
            FilePut(33, MecData(iCassa), iCassa)
        End If
FinArea:
        FileClose(33)
        Exit Function
    End Function
    Private Sub SubScelta(ByVal DN As Single, ByVal ASA As Short, ByRef di As Single)
        InitFlangia()
        With Flangia
            .K1 = 1
            .K2 = 1
            .K3 = 1
            If iCode = 2 Then .K3 = 4
            .Facing = 1
            .carica(Monitor.Motore.Inizio.DiscoRam)
            .SetDiam(DN)
            .SetRating(ASA)
            .leggi(.K1, .K2, 1, .TabFlan, .K3, False, Monitor.Motore.Inizio.DiscoRam)
            di = .Diamint
            DN = GlobalRoutines.ConvPoll(.strDiam)
        End With
        FineFlangia()
    End Sub
    Function AcqDati() As Boolean
        Dim itp, u As String
        Dim i As Short
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
950:    AcqDati = True
        ' Unimis = Readreco(1, 41, 1)
        '   Dom$(1) = "Temperatura di progetto  " + Misur$(Unimis, 1)
        '   Dom$(2) = "Pressione di progetto    " + Misur$(Unimis, 2)
        '   Dom$(3) = "Temperatura di esercizio " + Misur$(Unimis, 1)
        '   Dom$(4) = "Pressione di esercizio   " + Misur$(Unimis, 2)
        '   Dom$(5) = "Pressione di prova       " + Misur$(Unimis, 2)
        '   Dom$(6) = "Temperatura minima       " + Misur$(Unimis, 1)
        '   Dom$(1) = Adjust(at2(132), 26) + Misur$(UNIMIS, 1)
        '   Dom$(2) = Adjust(at2(133), 26) + Misur$(UNIMIS, 2)
        '   Dom$(3) = Adjust(at2(134), 26) + Misur$(UNIMIS, 1)
        '   Dom$(4) = Adjust(at2(135), 26) + Misur$(UNIMIS, 2)
        '   Dom$(5) = Adjust(at2(136), 26) + Misur$(UNIMIS, 2)
        '   Dom$(6) = Adjust(at2(137), 26) + Misur$(UNIMIS, 1)
        Dom(1) = Helpstringa(1132).PadRight(26) + Misur(actPRV.UnitaMisu, 1)
        Dom(2) = Helpstringa(1133).PadRight(26) + Misur(actPRV.UnitaMisu, 2)
        Dom(3) = Helpstringa(1134).PadRight(26) + Misur(actPRV.UnitaMisu, 1)
        Dom(4) = Helpstringa(1135).PadRight(26) + Misur(actPRV.UnitaMisu, 2)
        Dom(5) = Helpstringa(1136).PadRight(26) + Misur(actPRV.UnitaMisu, 2)
        Dom(6) = Helpstringa(1137).PadRight(26) + Misur(actPRV.UnitaMisu, 1)
        Risp(1) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(3, 24, Nrdit \ 2, 1, itp, 0)), 5, 5, False)
        Risp(2) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(3, 25, Nrdit \ 2, 1, itp, 0)), 5, 5, False)
        Risp(3) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(3, 2, Nrdit \ 2, 1, itp, 0)), 5, 5, False)
        Risp(4) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(3, 9, Nrdit \ 2, 1, itp, 0)), 5, 5, False)
        Risp(5) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(3, 26, Nrdit \ 2, 1, itp, 0)), 5, 5, False)
        Risp(6) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(3, 23, Nrdit \ 2, 1, itp, 0)), 5, 5, False)
        Dom(7) = "Slope"
        Risp(7) = objDatBase.DatBase(4, 16, Nrdit \ 2, 1, itp, 1).PadRight(10)
        Archiv(7) = 25
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(2, 7, "Dati di progetto", Dom, Risp, "", Archiv, dAiu) ') Then
    End Function
    Function Config() As Boolean
        If AddDistinta = 305 Then GoTo CC
        '---------------------------------------
        '951 If Not AcqDati Then Config = False: Exit Function
        'ENuovo
        If Nrdit <= 0 Then
            MostraAiuto(IDH_HTRI_TREENONSEL)
            Exit Function
        End If
        MecData(0).Logic(1 - 1) = 0
        MecData(0).Logic(2 - 1) = 0
        For i = 1 To 4 : MecData(0).SP(i - 1) = 0.0! : Next
        Config = True
        'FileUPM = Nomi$(1, 1)
906:    FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        FileGet(33, MecData(0), 1)
        If Not VUOTO Then
            Aggiorna = True
            nPassi = MecData(0).nPassi
            TipoFas = MecData(0).Tipo
            If nPassi < 0 Or nPassi > 16 Or TipoFas < 0 Or TipoFas > 4 Then
                MsgBox("Errore strano n°2. Provare ad annullare i calcoli meccanici")
                FileClose(33)
                Config = False
                Exit Function
            End If
            PassFraz = MecData(0).PassFraz
            If PassFraz Then
                '               A$ = "Vuoi rigenerare la struttura dei setti?|"
                '          A$ = A$ + "Se rispondi si, dovrai rigenerare la |struttura della commessa"
                '               junk = MsgBox(at2(158), vbQuestion + vbYesNo)
                junk = MostraAiuto(IDH_UPM_STRUTTSETTI, ChiaviMess.MessQuestion Or Chiavimess.MessYesNo Or ChiaviMess.MessHelpButton)
                If junk = ChiaviMess.MessSi Then
                    For i = 1 To nPassi
                        File(i) = objDatBase.CVS(objDatBase.DatBase(7, i + 1, Nrdit \ 2, 1, itp, 0))
                    Next
                    Esito = PasFrct(nPassi, 1)
                Else
990:                'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FileGet(33, HeaderSetti(1), 5)
                    'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FileGet(33, HeaderSetti(2), 6)
                    'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FileGet(33, HeaderStruct(0), 7)
                End If
            End If
        Else
            Aggiorna = False
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            nPassi = objDatBase.CVI(objDatBase.DatBase(4, 5, Nrdit \ 2, 1, itp, 0))
            PassFraz = False
            For i = 1 To nPassi
992:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                File(i) = objDatBase.CVS(objDatBase.DatBase(7, i + 1, Nrdit \ 2, 1, itp, 0))
                If Not PassFraz Then PassFraz = Not GiustoIntero(File(i))
            Next
            If PassFraz Then
                Esito = PasFrct(nPassi, 1)
                '          MouseShow
            Else
994:            Esito = PasFrct(nPassi, 2)
            End If
995:        MecData(0).PassFraz = PassFraz
            TipoFas = 0
            For i = 1 To 16 : MecData(0).HX5(i - 1) = 0.0! : Next
        End If
        Select Case nPassi
            Case 1
                '               A$ = "Le casse A e B sono identiche?"
                junk = MostraAiuto(IDH_UPM_DIVUG, ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion)
                If junk = ChiaviMess.MessSi Then
                    TipoFas = 0
996:                GoTo Regis1
                Else
                    TipoFas = 1
                    GoTo Regis1
                End If
            Case 2
                Ncasi = 2
            Case Else
                Ncasi = 4
        End Select
        If nPassi > 1 And VUOTO Then
            '           a$ = "Desideri verificare le dilatazioni |"
            '      a$ = a$ + "      differenziali dei tubi       |"
            '      a$ = a$ + "nella configurazione non splittata?|"
            junk = MostraAiuto(IDH_UPM_DOMSPLIT, ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion)
            If junk = ChiaviMess.MessSi Then
                MecData(0).nPassi = nPassi
                FilePut(33, MecData(0), 1)
                Esito = SplitCas(0)
                FilePut(33, MecData(0), 1)
CC:             Aggiorna = True : VUOTO = True
                FileGet(33, MecData(0), 1)
                nPassi = MecData(0).nPassi
            End If
        End If
        BocIn = objDatBase.CVI(objDatBase.DatBase(4, 6, Nrdit \ 2, 1, itp, 0))
        BocOut = objDatBase.CVI(objDatBase.DatBase(4, 7, Nrdit \ 2, 1, itp, 0))
        DBocIn = objDatBase.CVS(objDatBase.DatBase(7, 19, Nrdit \ 2, 1, itp, 0))
        DBocOut = objDatBase.CVS(objDatBase.DatBase(7, 18, Nrdit \ 2, 1, itp, 0))
        Dtub = objDatBase.CVS(objDatBase.DatBase(5, 1, Nrdit \ 2, 1, itp, 0))
        Rat = objDatBase.DatBase(2, 13, Nrdit \ 2, 1, itp, 1)
        iTest = objDatBase.CVI(objDatBase.DatBase(2, 9, Nrdit \ 2, 1, itp, 0))
        iCode = objDatBase.CVI(objDatBase.DatBase(2, 21, Nrdit \ 2, 1, itp, 0))
        'Tipo 0 :due casse uguali Ncasse=1
        'Dom$(1) = "Cassa A singola, B singola"  'Ncasse=2
        'Dom$(3) = "Cassa A singola, B split  "  'Ncasse=3
        'Dom$(2) = "Cassa A split,   B singola"  'Ncasse=3
        'Dom$(4) = "Cassa A split,   B split  "  'Ncasse=4
Rif2:
        Tit = "Configurazione Casse"
        For i = 1 To 4
            '  Ialt(i) = False
            Dom(i) = Helpstringa(1014 + i - 1) ' at2(13 + i)
        Next
        'Ialt(TipoFas) = True
        TipoFas1 = Monitor.Motore.Quale(Ncasi, Tit, Dom, RadiceHelp & "::/Split1.htm", TipoFas)
        If TipoFas1 = 0 Then
            FileClose(33) : Config = False : Exit Function
        End If
        Aggiorna = TipoFas1 <> TipoFas
        TipoFas = TipoFas1
Regis1:
        If PassFraz Then
            Call PossibiliSezioni(Sezione)
            Call NumSet(nseta, NfilA, Sezione)
            nnseta = nseta(1) : nnsetb = nseta(2)
            Aggiorna = True
        Else
            If (nPassi \ 2) * 2 < nPassi Then 'dispari
                nnseta = nPassi \ 2 : nnsetb = nnseta
            Else
                nnseta = 1 + (nPassi - 1) \ 2 : nnsetb = nnseta - 1
            End If
        End If
        For i = 1 To 4 : nset(i) = 0 : Next
        Select Case TipoFas
            Case 0 : nIn(1) = BocIn : nOut(1) = BocOut
            Case 1 : nset(1) = nnseta : nset(2) = nnsetb 'no split
                If (nPassi \ 2) * 2 = nPassi Then
                    nIn(1) = BocIn : nOut(1) = BocOut
                    nIn(2) = 0 : nOut(2) = 0
                Else
                    nIn(1) = BocIn : nOut(1) = 0
                    nIn(2) = 0 : nOut(2) = BocOut
                End If
            Case 2 'cassa A split
                If (nPassi \ 2) * 2 = nPassi Then
                    nIn(1) = BocIn : nOut(1) = 0
                    nIn(2) = 0 : nOut(2) = BocOut
                    nIn(3) = 0 : nOut(3) = 0
                Else
                    nIn(1) = BocIn : nOut(1) = 0
                    nIn(2) = 0 : nOut(2) = 0
                    nIn(3) = 0 : nOut(3) = BocOut
                End If
                Select Case nnseta
                    Case Is < 2 : nset(1) = 0 : nset(2) = 0 : nset(3) = nnsetb
                    Case Else
                        Dim Res As Short = Asplit()
                        If Res = 0 Then
                            Return False
                        ElseIf Res = -1 Then
                            GoTo Rif2
                        End If
                        nset(1) = ncamS - 1 : nset(2) = ncamI - 1 : nset(3) = nnsetb
                End Select
            Case 3 'cassa b split
                nIn(2) = 0 : nOut(2) = 0
                If (nPassi \ 2) * 2 = nPassi Then
                    nIn(1) = BocIn : nOut(1) = BocOut
                    nIn(3) = 0 : nOut(3) = 0
                Else
                    nIn(1) = BocIn : nOut(1) = 0
                    nIn(3) = 0 : nOut(3) = BocOut
                End If
                Select Case nnsetb
                    Case Is < 2 : nset(1) = nnseta : nset(2) = 0 : nset(3) = 0
                    Case Else
                        Dim Res As Short = Bsplit()
                        If Res = 0 Then
                            Return False
                        ElseIf Res = -1 Then
                            GoTo Rif2
                        End If
                        nset(1) = nnseta : nset(2) = ncamS - 1 : nset(3) = ncamI - 1
                End Select
            Case 4 'tutte e due
                nIn(3) = 0 : nOut(3) = 0
                If (nPassi \ 2) * 2 = nPassi Then
                    nIn(1) = BocIn : nOut(1) = 0
                    nIn(2) = 0 : nOut(2) = BocOut
                    nIn(4) = 0 : nOut(4) = 0
                Else
                    nIn(1) = BocIn : nOut(1) = 0
                    nIn(2) = 0 : nOut(2) = 0
                    nIn(4) = 0 : nOut(4) = BocOut
                End If
                Select Case nnseta
                    Case Is < 2 : nset(1) = 0 : nset(2) = 0
                    Case Else
                        ncam = nnseta + 1
                        Dim Res As Short = Asplit()
                        If Res = 0 Then
                            Return False
                        ElseIf Res = -1 Then
                            GoTo Rif2
                        End If
                        nset(1) = ncamS - 1 : nset(2) = ncamI - 1
                End Select
                Select Case nnsetb
                    Case Is < 2 : nset(3) = 0 : nset(4) = 0
                    Case Else
                        ncam = nnsetb + 1
                        Dim Res As Short = Bsplit()
                        If Res = 0 Then
                            Return False
                        ElseIf Res = -1 Then
                            GoTo Rif2
                        End If
                        nset(3) = ncamS - 1 : nset(4) = ncamI - 1
                End Select
        End Select
        If TipoFas = 1 And nPassi = 1 Then
            '         a$ = "Le casse di ingresso e uscita|"
            '    a$ = a$ + "saranno uguali?              |"
            junk = MostraAiuto(IDH_UPM_DIVUG, ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion)
            If junk = ChiaviMess.MessSi Then TipoFas = 0
        End If
        MecData(0).Codice = iCode
        MecData(0).TipTest = iTest
        If iCode = 3 Then
            MecData(0).EWPS = 0.7 : MecData(0).EWC = 0.7 : MecData(0).e = 1
        Else
            MecData(0).EWPS = 0.6 : MecData(0).EWC = 1.0! : MecData(0).e = 1
        End If
        '??????????????????????
        'MecData(0).HEADER = TipC$(TipoFas, 1)
        'MecData(0).NS = nset(1)
        'MecData(0).NsFunz = MecData(0).NS
        '???????????????????qui o dentro l'if seguente
        If VUOTO Or Aggiorna Then
            MecData(0).HEADER = TipC(TipoFas, 1)
            MecData(0).NS = nset(1)
            MecData(0).NsFunz = MecData(0).NS
            MecData(0).nPassi = nPassi
            MecData(0).Tipo = TipoFas
            MecData(0).HEADER = TipC(TipoFas, 1)
            MecData(0).NS = nset(1)
            MecData(0).NsFunz = MecData(0).NS
            If PassFraz Then
                For ii = 1 To 16 : MecData(0).Nfile(ii - 1) = 0 : Next
                For ii = 1 To nset(1) + 1 : MecData(0).Nfile(ii - 1) = System.Math.Abs(NfilA(ii, 1)) : Next
            End If
            MecData(0).DBocIn = DBocIn
            MecData(0).DBocOut = DBocOut
            MecData(0).xx = ReadLib(3, 1 + CShort(4 * (Dtub - 1.0!)))
            If MecData(0).xx = -1 Then
                MsgBox("Errore strano n°1. Chiamare l'autista")
                FileClose(33)
                Config = False
                Exit Function
            End If
            TubeSh = objDatBase.CVI(objDatBase.DatBase(4, 51, Nrdit \ 2, 1, itp, 0))
            Select Case TubeSh
                Case 0, 1, 2 'non definito
                    MecData(0).Gap = ReadLib(24, 1)
                Case 3 'expanded
                    MecData(0).Gap = ReadLib(24, 1)
                Case 4, 5 'welded
                    MecData(0).Gap = ReadLib(24, 2)
            End Select
            MecData(0).Gap = MecData(0).Gap + Dtub * 25.4 / 2.0!
            'MecData(0).Rating = Rat$
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        itnr = GlobalRoutines.myStr(CSng(Nrdit \ 2), 3, 0, True)
        If Nrdit \ 2 < 10 Then
            itnr = "00" & Right(itnr, 1)
        Else
            itnr = "0" & Right(itnr, 2)
        End If
        MecData(0).ICKNR = RTrim(job.contratto) & com & "CK" & itnr
        MecData(0).nBocOut = nOut(1)
        MecData(0).nBocIn = nIn(1)
        FilePut(33, MecData(0), 1)
        If TipoFas > 0 Then
            For i = 2 To nCasse(TipoFas)
                If Not VUOTO Then
                    FileGet(33, MecData(i), i)
                    If EOF(33) Then VUOTO = True
                End If
                With MecData(i)
                    .nBocOut = nOut(i)
                    .nBocIn = nIn(i)
                    If VUOTO Or Aggiorna Then
                        .HEADER = TipC(TipoFas, i)
                        .NS = nset(i)
                        If PassFraz Then
                            Select Case TipoFas
                                Case 1 : iCShort = 2 : iD = 0
                                Case 2
                                    If i = 2 Then iCShort = 1 : iD = nset(1) + 1 Else iCShort = 2 : iD = 0
                                Case 3
                                    If i = 3 Then iCShort = 2 : iD = nset(2) + 1 Else iCShort = 2 : iD = 0
                                Case 4
                                    If i = 2 Then
                                        iCShort = 1 : iD = nset(1) + 1
                                    ElseIf i = 3 Then
                                        iCShort = 2 : iD = 0
                                    Else
                                        iCShort = 2 : iD = nset(3) + 1
                                    End If
                            End Select
                            For ii = 1 To 16 : .Nfile(ii - 1) = 0 : Next
                            For ii = 1 To nset(i) + 1
                                .Nfile(ii - 1) = System.Math.Abs(NfilA(ii + iD, iCShort))
                            Next
                        End If
                    End If
                    .NsFunz = .NS
                End With
                FilePut(33, MecData(i), i)
            Next
        End If
        FileClose(33)
        'IUNG = TipoFas: IUNQ = VUOTO
        Exit Function
ErrConfig:
        If Err.Number = 10 And Erl() = 949 Then
            Resume Next
        Else
            Debug.Print("Err Config" & Err.Number & Erl()) : Stop
        End If
    End Function
    Private Sub SplitFraz()
SplitFraz:
        Dim icams(10) As Integer
        jj = 0
        For i = 1 To ncam - 1
            If NfilA(i, iCShort) > 0 Then
                jj = jj + 1
                nsopra = 0 : nsotto = 0
                For ii = 1 To i : nsopra = nsopra + System.Math.Abs(NfilA(ii, iCShort)) : Next
                For ii = i + 1 To ncam : nsotto = nsotto + System.Math.Abs(NfilA(ii, iCShort)) : Next
                Stringa(jj) = "Sopra: c." & Str(i) & ",f." & Str(nsopra) & ";sotto: c." & Str(ncam - i) & ",f." & Str(nsotto)
                icams(jj) = i
            End If
        Next
        If jj = 0 Then
            ncamS = 0
            System.Array.Clear(icams, 0, icams.Length)
            Exit Sub
        End If
        Scelta = Monitor.Motore.Quale(jj, Tit, Stringa, "", 0)
        If Scelta = 0 Then
            ncamS = 0
            System.Array.Clear(icams, 0, icams.Length)
            Exit Sub
        End If
        ncamS = icams(Scelta)
        System.Array.Clear(icams, 0, icams.Length)
    End Sub
    Private Function Splitta() As Boolean
Splitta1: Splitta = True
        Dom(1) = "N° camere cassa superiore" 'at2(29) '
        Dom(2) = "N° camere cassa inferiore" 'at2(30) '
        Risp(1) = GlobalRoutines.myStr(CSng(ncamS), 2, 0, True)
        Risp(2) = GlobalRoutines.myStr(CSng(ncamI), 2, 0, True)
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(2, Tit, Dom, Risp, "", Archiv, dAiu) Then
            Return False
        End If
        ncamS = Val(Risp(1))
        ncamI = Val(Risp(2))
        If ncamS < 1 Or ncamI < 1 Or ncamS + ncamI <> ncam Then
            Testo = "Il numero di camere della cassa superiore più quello|"
            Testo = Testo & "della cassa inferiore deve essere pari a" & Str(ncam)
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ISA")
            GoTo Splitta1
        End If
    End Function
    Private Function Bsplit() As Short
        Bsplit = 1
        ncam = nnsetb + 1
        Tit = Helpstringa(1028) ' at2(28) '"Splittaggio cassa B"
        If Not PassFraz Then
            ncamS = ncam - 1 : ncamI = 1
            If Not Splitta() Then Return 0
        Else
            iCShort = 2
            SplitFraz()
            If ncamS = 0 Then Beep() : Return -1
            ncamI = ncam - ncamS
        End If
    End Function
    Private Function Asplit() As Short
        Asplit = 1
        ncam = nnseta + 1
        Tit = Helpstringa(1027) ' at2(27) '"Splittaggio cassa A"
        If Not PassFraz Then
            ncamS = ncam \ 2 : ncamI = ncam - ncamS
            If Not Splitta() Then Return 0
        Else
            iCShort = 1
            SplitFraz()
            If ncamS = 0 Then Beep() : Return -1
            ncamI = ncam - ncamS
        End If
    End Function
    Public Sub SuperInit()
        'Tito$(1) = "Sigla Item : "
        ' =======================================================================
        ' Initialize
        ' =======================================================================
        '-------------------------------------------------------------
        'AddSuperSav = AddSuper
        'Call InitUPM
        'If AddDistinta = 100 Then ' proveniente da HTRI?
        '   DisplayU
        '   GoSub AddSu2
        '   AddDistinta = 0
        'ElseIf IUNL > 0 Then 'viene da Cover
        '   DisplayU
        '   If AddMembrat = 0 Then
        '      Itemm = IUNP
        '      NewFUPM = Nomi$(2, 1): Prev.St = Nomi$(3, 1)
        '      If IUNL < 33 Then GoSub Regis
        '   ElseIf AddMembrat < 0 Then 'errore in cover
        '   AddMembrat = -AddMembrat - 1
        '   AddSuper = 1
        '   GoSub AddSu2
        '   Else
        '   AddSuper = 1
        '   GoSub AddSu2
        '   End If
        'ElseIf AddDistinta = 301 Or AddDistinta = 302 Then
        '   AddDistinta = 0
        'ElseIf AddDistinta = 304 Then
        '   AddDistinta = 0
        'ElseIf AddDistinta = 305 Then 'proviene da UPM2?
        '   i = Config
        '   ApriU LTrim$(job.contratto)
        '   LungSel = i
        '   GoSub AddSu2
        '   AddDistinta = 0
        'End If
        '   If Asc(job.contratto) > 32 And Left$(job.contratto, 1) <> Chr$(36) Then
        '      ApriU LTrim$(job.contratto)
        '      Itemn.St = LTrim$(job.Comm.Ind(1).Data.Assieme)
        '      SETRDIT Itemn, Nrdit
        '   End If
        '    If AddDistinta > 299 Then
        '        AddDistinta = 0
        '    End If
        '    While IUNA
        '      GoSub Sleep2
        '    Wend
        '    While Not DemoFinished
        '        kbd$ = MenuInkey$''
        '
        '        While MenuCheck(2)
        '10          GoSub MenuTrap
        '        Wend

        '    Wend
        'MenuTrap:
        '    Menu = MenuCheck(0)
        '    Itemm = MenuCheck(1)

        '    Select Case Menu
        '        Case 1
        'doppio impiego
        '            Select Case Itemm
        '                Case 2: AZZMEC
        '                        LungAPR = EdiIteU
        '                        If LungAPR Then ENuovo
        '                        Nomi$(3, 1) = Prev.St
        '                Case 3: GoSub Domanda: DatiCosU   'OK
        '                Case 4: AnnulMec: EliIteU         'OK
        ''                CASE 5: NuovoU 0
        '                Case 6: 'NuoPreU                   'OK
        '                Case 7: ' ChiPreU                   'OK
        '                Case 10: DemoFinished = True
        '                If Asc(job.contratto) > 32 Then
        '                  job.Comm.Ind(1).Data.Assieme = Chr$(36)
        '                  job.Comm.Ind(2).Data.Assieme = Chr$(48)
        '30                Put #1, 1, Lav(0)
        '40                Close:  'CLOSPREV
        '                End If
        '            End Select
        '        Case 2
        '   MenuSet 2, 0, 1, at2(71), 1'"Calc.meccanico", 1
        '   MenuSet 2, 1, 1, at2(72), 1'"Lista bocchelli", 1
        '   MenuSet 2, 2, 1, at2(73), 1'"Testate (press.i.)", 1
        '   MenuSet 2, 3, 1, at2(74), 2'"Testate (press.e.)", 2
        '   MenuSet 2, 4, 1, at2(75), 5'"Calcolo split   ", 5
        '   MenuSet 2, 5, 1, at2(76), 1'"Annulla calcolo", 1
        '            If Itemm = 5 Then Call AnnulMec: Itemm = 1
        '            AddDistinta = 251: LungTEM = Itemm: IUNP = Nrdit
        '            'Nomi$(1, 1) = FileUPM': Catena "UPMU"
        '            If Asc(job.contratto) < 33 Then LungAPR = EdiIteU
        '            If LungAPR Then
        '42             ENuovo
        '               Select Case Itemm
        '                Case 1: Bocchll CVI(Datbase(2, 9, Nrdit \ 2, 1, itp$, 0))
        '                Case 2
        'Sleep2:               DisplayU: IUNA = True
        '                      key 1, "Test"
        '                      key 2, "Tubi"
        '                      key 3, "Splt"
        '                      key 4, "Fine"
        '                      For i = 5 To 10: key i, "": Next
        '                     KEY ON
        'Sleep1:              SLEEP
        '                     Do
        '                     In$ = INKEY$
        '                     LOOP WHILE In$ = ""
        '                     iSw = VAL(In$)
        '                     Select Case isw
        '                     Case 1: key OFF: Calcol
        '                     Case 2: key OFF: AltriCt
        '                     Case 3: key OFF: AltriCs
        '                     Case 4: key OFF: GoSub Fine
        '                     Case Else: BEEP: GoTo Sleep1
        '                     End Select
        '                     Return
        '                 Case 3: Buckling
        '            End Select
        '            End If
        '        Case 3
        '   MenuSet 3, 0, 1, "Stand-alone", 3
        '   MenuSet 3, 1, 1, "ASME-tappi", 6
        '   MenuSet 3, 7, 1, "VSR-tappi", 1
        '   MenuSet 3, 2, 1, "ASME-obround", 6
        '   MenuSet 3, 3, 1, "Cover-stud", 1
        '   MenuSet 3, 4, 1, "Cover-thrubolt", 2
        '   MenuSet 3, 5, 1, "Tubi di scambio", 1
        '   MenuSet 3, 6, 1, at2(75), 5'"Calcolo split   ", 9
        '   MenuSet 5, 0, 1, at2(77), 3'"Opzioni", 3
        '   MenuSet 5, 1, 1, at2(78), 1'"Colori", 1
        '   MenuSet 5, 2, 1, at2(79), 1'"Percorsi", 1
        '   MenuSet 5, 3, 1, at2(80), 1'"Stampa in linea", 1
        '            Select Case Itemm
        '                Case 1
        '         a$ = RTrim$(at1(20) + at1(21))
        '         a$ = "Dichiara il tuo tipo di video|"
        '    a$ = a$ + chr$(124)
        '    a$ = a$ + "Programma HTRI|"
        '    a$ = a$ + "Copyright (c) 1989-1992 FBM-Hudson Italiana SpA|"
        '    x = Alert(4, a$, 9, 10, 14, 70, "Color", "Monochrome", "")

        '    If x = 1 Then
        '        DisplayType = True
        '    Else
        '        DisplayType = False
        '    End If
        'DisplayU
        '            Case 2:
        '909                 InitDirect
        '910                 WorkS.St = Workdir
        '                    BaseArch.St = Archdir
        '                    DOAPAI BaseArch, WorkS
        '                    DisplayU
        '            Case 3: OpzStam
        '         End Select
        ''Š del 255 !!!!!!!!!!!!!!!!!
        ''                     AddSuper = 2
        ''                     GOSUB AddSu2
        '         Case Else
        '    End Select
        'Return
        'Domanda:
        '      If Len(Dir$(CercaMec)) = 0 Then Return
        ''     a$ = "Stai per (re)visionare i dati|"
        ''a$ = a$ + "costruttivi. Vuoi annullare i|"
        ''a$ = a$ + "risultati del dimensionamento|"
        ''a$ = a$ + "meccanico precedentemente ef-|"
        ''a$ = a$ + "fettuato?                    |"
        ' a$ = at2(130) + at2(131)
        '    x = Alert(4, a$, 9, 10, 20, 70, "SI", "NO", "")
        'If x = 1 Then AnnulMec
        'Return
        'Fine:
        ''FOR i = 1 TO 4: KEY(i) OFF: NEXT
        'IUNA = False
        'key OFF
        'Return
        'Prepara:
        '                   Nomi$(1, 1) = "": Nomi$(3, 1) = Prev.St
        '                   Nomi$(2, 1) = NewFUPM
        '                   AddDistinta = 0 ' Nrdit
        '                   AddMembrat = 0 ' iCassa
        '                   AddLibrerie = 1 'nCasse(TipoFas)
        '                   IUNQ = 0 ' TipoFas
        'Return
        'x$INCLUDE: 'Trucco2.bas'
        'DimDim:
        'If Err = 9 Then
        '   ReDim Record(JRECMAX) As RecAPR  'era 12
        '   ReDim Nomi$(1 To 20, 1 To 5)
        ''------------------
        '   ReDim Classe1(0 To 13) As Integer
        '   ReDim Classe2(0 To 8) As Integer
        '   ReDim Classe8(0 To 5) As Integer
        '   iTrucco = 0
        '   Resume Next
        'ElseIf Err = 52 And Erl = 30 Then
        '   Resume Next
        'End If
        'Print "Errore in Trucco2"; Err; Erl
        'Stop

    End Sub

    Public Sub Calcol()
        Dim i As Short
        LungSel = Config()
        '===================================================
        If Not LungSel Then Exit Sub
        iCassa = 1
        With Apert
            AppActivate(.Text)
            .mnuCasse.Items(0).Text = "Tutte in sequenza"
            For i = 1 To nCasse(TipoFas)
                .mnuCasse.Items(i).Text = TipC(TipoFas, i)
                .mnuCasse.Items(i).Visible = True
            Next
            For i = nCasse(TipoFas) + 1 To 4
                .mnuCasse.Items(i).Visible = False
            Next
            .mnuCasse.Show(50, 50)
            'UPGRADE_ISSUE: Form metodo Apert.PopupMenu non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            '  .PopupMenu(.mnuCasse0)
        End With
    End Sub
    Public Sub AltriCt()
        If CalcTubi(Nrdit \ 2) Then
            Registra(NewFUPM, 1, "t")
            Shell("NotePad " & NewFUPM, AppWinStyle.NormalFocus)
            '917                     EditoreF 2, NewFUPM, Tit$ '"Spessore tubi"
        End If
    End Sub

    Public Sub AltriCs()
918:    'Nomi$(1, 1) = FileUPM: Nomi$(2, 1) = NewFUPM
        FileClose(33)
        FileUPM = CercaMec()
        FileMec = FileUPM
        FileOpen(33, FileUPM, OpenMode.Random, , , Len(MecData(0)))
        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FileGet(33, MecData(0), 1)
        If MecData(0).nPassi > 1 Then
            '      AddDistinta = 304: IUNP = Nrdit: IUNG = TipoFas
            '      Catena "UPM2"
            InitUPM2(304, FileUPM)
        Else
            '               A$ = "Poich‚ questo item ha un solo|"
            '          A$ = A$ + "passaggio, questo calcolo non|"
            '          A$ = A$ + "avrebbe senso.               |"
            '               MsgBox at2(155)
            MostraAiuto(IDH_UPM_SPLIT_1p)
        End If
    End Sub
    Public Sub StandAlone(ByRef Itemm As Short)
        Dim Logi1, Ris As Boolean
        If NonAncora Then
            If Not CheckLicenza() Then Exit Sub
            NonAncora = False
        End If
50:     ChiPre()
        InitUPM()
51:     job.contratto = Space(1)
        Prev = Space(1)
        If Itemm < 7 Then iCode = 4 Else iCode = 3
        Select Case Itemm
            Case 1, 7 : iTest = 2
            Case 2 : iTest = 12
            Case 3 : iTest = 3
            Case 4 : iTest = 4
            Case 5
                If CalcTubi(0) Then
                    Registra(NewFUPM, 0, "") 'e' giusto 0 ???
                    Shell("NotePad " & NewFUPM, AppWinStyle.NormalFocus) ' Tit$ ' "Spessore tubi"
                    job.contratto = Space(1)
                End If
                Exit Sub
            Case 6 'AddDistinta = 303
                'Nomi$(1, 1) = FileUPM: Catena "UPM2"
                Logi1 = SplitCas(1) 'InitUPM2 303
        End Select
        Monitor.Motore.Problem.Extension = ".MEC"
52:     If Not DatiGenI(0) Then Exit Sub
        Tit = "Configurazione Casse"
        Dom(1) = Helpstringa(1250)
        For i = 1 To 4
            Dom(i + 1) = Helpstringa(1014 + i - 1) ' at2(13 + i)
        Next
        TipoFas = Monitor.Motore.Quale(5, Tit, Dom, RadiceHelp & "::/Split1.htm", MecData(0).Tipo + 1) - 1
        MecData(0).Tipo = TipoFas
        Nrdit = 0
        Dim iC1 As Integer = 0
        Dim iC2 As Integer = 0
        If TipoFas > 0 Then
            Dim iC As Integer
            Dim ifl As Integer = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
            For iC = 1 To nCasse(TipoFas)
                Try
                    FileGet(ifl, MecData(iC), iC)
                Catch ex As Exception
                    MecData(iC) = MecData(iC - 1)
                    FilePut(ifl, MecData(iC), iC)
                End Try
            Next
            FileClose(ifl)
            iC1 = 1 : iC2 = nCasse(TipoFas)
        End If
        If Len(Trim(job.Contratto)) > 4 Then job.Contratto = Mid(job.Contratto, 1, 4)
        For iCassa = iC1 To iC2
            If Not DatiItem("") Then Exit Sub
Rifaif:
            If Not DatiCassa(1) Then Exit Sub
            'SETPUT 0 già chiamato in SettiVuoti da DatiCassa
            Ris = True
            Select Case Itemm
                Case 1, 2, 7
                    If Itemm = 7 Then
                        Ris = TestapMain()
                    Else
                        If Not Tappi() Then Exit Sub
                        'Catena "TAPPI"
                    End If
                Case 3
                    Ris = CoverMain(1) 'stud
                Case 4
                    Ris = CoverMain(2) 'thrubolt
            End Select
        Next
Regis:
        If Ris Then
            '           Registra NewFUPM, 0,""
919:        '   Shell("NotePad " & NewFUPM, AppWinStyle.NormalFocus) 'EditoreF 2, NewFUPM, Tit$
921:        '  'a$ = at2(153) ' "Vuoi revisionare il presente calcolo?"
            ' 'X = Alert(4, a$, 9, 10, 11, 60, "NO", "SI", "")
            ''If IUNP > 0 Then Itemm = IUNP: iTest = IUNG
            ''If X = 2 Then
922:        ''   Kill NewFUPM
932:        ''   If Len(Dir$(at1(55) + Prev.St)) > 0 Then Kill at1(55) + Prev.St
            ''   If Len(RTrim$(job.contratto)) = 0 Then job.contratto = Prev.St
924:        ''   UPMGTG Prev, 0, 1, 0
            ''   GoTo Rifaif
            ''End If
            ''IUNL = 0: IUNP = 0: IUNG = 0
        End If
        job.Contratto = Space(1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Problem. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Problem.Extension = ".PRV"
    End Sub
    Public Function CalcUpmGen() As Short
        CalcUpmGen = True
        iTest = objDatBase.CVI(objDatBase.DatBase(2, 9, Nrdit \ 2, 1, itp, 0))
        iCode = objDatBase.CVI(objDatBase.DatBase(2, 21, Nrdit \ 2, 1, itp, 0))
        If iCassa > 1 Then
            FileClose(33)
916:        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
            FileGet(33, MecData(0), 1)
            FileGet(33, MecData(iCassa), Max(Abs(iCassa), 1))
            With MecData(iCassa)
                .MATUG = MecData(0).MATUG
                .MATTAP = MecData(0).MATTAP
                .MATTUB = MecData(0).MATTUB
                Try
                    For i = 1 To 4
                        If .Ammiss0(i) = 0.0! Then .Ammiss0(i) = MecData(0).Ammiss0(i)
                        If .Ammiss(i) = 0.0! Then .Ammiss(i) = MecData(0).Ammiss(i)
                    Next i 'c
                    For i = 1 To 5
                        If .BF(i - 1) = 0.0! Then .BF(i - 1) = MecData(0).BF(i - 1)
                        If .DF(i - 1) = 0.0! Then .DF(i - 1) = MecData(0).DF(i - 1)
                        If .TK(i - 1) = 0.0! Then .TK(i - 1) = MecData(0).TK(i - 1)
                    Next  'd
                    If .SUG = 0.0! Then .SUG = MecData(0).SUG
                    If .EWPS = 0.0! Then .EWPS = MecData(0).EWPS
                    If .EWC = 0.0! Then .EWC = MecData(0).EWC
                    If .e = 0.0! Then .e = MecData(0).e
                Catch ex As Exception
                    For i = 1 To 4
                        .Ammiss0(i) = MecData(0).Ammiss0(i)
                        .Ammiss(i) = MecData(0).Ammiss(i)
                    Next i 'c
                    For i = 1 To 5
                        .BF(i - 1) = MecData(0).BF(i - 1)
                        .DF(i - 1) = MecData(0).DF(i - 1)
                        .TK(i - 1) = MecData(0).TK(i - 1)
                    Next  'd
                    .SUG = MecData(0).SUG
                    .EWPS = MecData(0).EWPS
                    .EWC = MecData(0).EWC
                    .e = MecData(0).e
                End Try
            End With
            FilePut(33, MecData(iCassa), Max(Abs(iCassa), 1))
1911:       FileClose(33)
        End If
1912:   Logi2 = UpmIniz()
        If Logi2 >= 0 Then
            AddDistinta = -1
            CalcUpmGen = Logi2 : Exit Function
        End If
forfor1:
        Select Case iTest
            Case 2, 12 'plug
                Select Case iCode
                    Case 3, 4 'vsr,asme
                        If Not Calc34() Then Return False
                    Case 9 'API
                        If Not Calc34() Then Return False
                    Case Else
                        GoTo Nonorm
                End Select
            Case 3 'cover plate(stud)
                Select Case iCode
                    Case 3 'vsr
                        GoTo Nonorm
                    Case 4 'asme
                        'IUNL = 1 'codice chiamata
                        'GoSub Prepara
                        'MsgBox "Lavori in corso (COVER)" 'Catena "COVER"
                        CoverMain(1)
                    Case 9 'API
                    Case Else
                        GoTo Nonorm
                End Select
            Case 4 'cover plate(thrubolt)
                ' IUNL = 2 'codice chiamata
                'GoSub Prepara
                'MsgBox "Lavori in corso (COVER)" 'Catena "COVER"
                CoverMain(2)
                '    CASE 5  'cover plate(bonnet)
                '    CASE 6  'manifold
                '    CASE 7  'pipe & u-bend
                '    CASE 8  'transition
                '    CASE 9  'serp coil
            Case Else
                '        Help$ = "Non disponiamo di metodi per|"
                'Help$ = Help$ + "per il calcolo delle testate|"
                'Help$ = Help$ + "di tipo " + Datbase(2, 9, Nrdit \ 2, 1, itp$, 1)
                '    Help$ = at2(156) + Space$(1) + objDatBase.DatBase(2, 9, Nrdit \ 2, 1, itp$, 1)
                Help = CStr(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_UPM_NOMETHOD)) + Space(1) + objDatBase.DatBase(2, 9, Nrdit \ 2, 1, itp, 1))
                MostraAiuto(IDH_UPM_NOMETHOD, , Help)
                CalcUpmGen = False
                Exit Function
        End Select
        If TipoFas > 0 Then
            '   AddDistinta = 255: LungTEM = iCassa: LungAPR = iTest: LungMat = iCode
            '   IUNG = TipoFas: IUNP = Nrdit: Nomi$(1, 1) = FileUPM: Nomi$(2, 1) = NewFUPM: Nomi$(3, 1) = Prev.St
            '   GOSUB TextSav
            '   Catena "UPMU"
            i = VerifArea()
        Else
            i = 0
        End If
949:    If i = 1 Then
            Prev = job.Contratto
            '  UPMGTG(Prev, Nrdit \ 2, 2, iCassa)
            Stop
            If Not DatiCassa(2) Then CalcUpmGen = False : Exit Function
            GoTo forfor1
        ElseIf i = 2 Then
            CalcUpmGen = False
            Exit Function
        End If
        'Registra NewFUPM, iCassa
        'iCassa = iCassa + 1: If iCassa <= nCasse(TipoFas) Then GoTo forfor
        'NEXT 'e
        Exit Function
Nonorm:
        '        Help$ = "Non disponiamo di metodi per|"
        'Help$ = Help$ + "per il calcolo delle testate|"
        'Help$ = Help$ + "a norme " + Datbase(2, 21, Nrdit \ 2, 1, itp$, 1)
        Help = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_UPM_NOMETHOD)) + Space(1) + objDatBase.DatBase(2, 21, Nrdit \ 2, 1, itp, 1)
        'Help$ = at2(157) + Space$(1) + objDatBase.DatBase(2, 21, Nrdit \ 2, 1, itp$, 1)
        MostraAiuto(IDH_UPM_NOMETHOD2, , Help)
        '    MsgBox Monitor.Motore.Inizio.ConvertiCr(Help)
        CalcUpmGen = False
    End Function
    Private Function Calc34() As Boolean
        Calc34 = True
        If iCode = 3 Then
            Ris = TestapMain()
        Else
            If Not Tappi() Then
                Return False
            End If
        End If
    End Function
    Public Sub menuPopup(ByRef Index As Short)
        Dim i As Short
        iSW = Index + 1
        If iSW > 1 Then
            iCassa = iSW - 1
            If CalcUpmGen() >= 0 Then Exit Sub
        ElseIf iSW = 1 Then
            For i = 1 To nCasse(TipoFas)
                iCassa = i
                If CalcUpmGen() >= 0 Then Exit Sub
            Next
        End If
        If Len(NewFUPM) > 0 Then
            Shell("NotePad " & NewFUPM, AppWinStyle.NormalFocus)
            With Apert.ListView6
                If .Items.Count > 0 Then .Items.RemoveAt(1)
                If iSW > 1 Then
                    .Items.Add("Il calcolo meccanico è stato eseguito parzialmente")
                Else
                    .Items.Add("Il calcolo meccanico è stato eseguito")
                End If
            End With
        End If
        CasSplit()
    End Sub
    Function Misur(ByRef UniM As String, ByRef iC As Short) As String
        Select Case iC
            Case 1
                Select Case UniM
                    Case "ME", "SI" : Misur = " [øC]"
                    Case "BR" : Misur = " [øF]"
                    Case Else : Misur = " [??]"
                End Select
            Case 2
                Select Case UniM
                    Case "ME" : Misur = " [Kg/cm2]"
                    Case "BR" : Misur = " [psi]"
                    Case "SI" : Misur = " [kPa]"
                    Case Else : Misur = " [??]"
                End Select
            Case 3
                Select Case UniM
                    Case "ME", "SI" : Misur = " [mm]"
                    Case "BR" : Misur = " [in]"
                    Case Else : Misur = " [??]"
                End Select
            Case Else : Misur = " [?]"
        End Select
    End Function
    Public Function Tappi() As Boolean
        Dim A, File As String
        Dim iRec As Short
        Dim Ris As Boolean
        Dim Cod As String
        Tappi = True
        'If Nrdit > 0 Then
        '   'Call Apri(Trim(job.contratto))
        '   'a$ = Globalroutines.mystr(CSng(Nrdit \ 2), 2, 0, True)
        '   'If Left$(a$, 1) = Chr$(32) Then a$ = "0" + Right$(a$, 1)
        '   File = FileMEC ' Monitor.Motore.Inizio.Workdir + "\" + RTrim$(job.contratto) + a$ + ".MEC"
        'Else
        '   job.contratto = "SALV"
        '   File = Monitor.Motore.Inizio.Workdir + "\SALV00.MEC"
        'End If
        '   FileMEC = File$
        '220 Open File For Random As #33 Len = Len(lMecData)
        '   iRec = iCassa 'AddMembrat
        '   If iRec = 0 Then iRec = 1
        '   Get #33, iRec, lMecData
        If KUN = 0 Then
            Dom(1) = " Pressioni barg (psi); Sollecitazioni N/mm2 (psi)"
            Dom(2) = " Pressioni barg (psi); Sollecitazioni MPa   (psi)"
            Dom(3) = " Pressioni MPa  (psi); Sollecitazioni MPa   (psi)"
            Dom(4) = " Kg/cm2G    (psi); Sollecitazioni kg/mm2 (psi)"
            If Nrdit > 0 Then
                'Uni$ = Datbase(1, 6, 1, 1, itp$, 0)
                Select Case actPRV.UnitaMisu
                    Case "SI"
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        KUN = 1 + Monitor.Motore.Quale(3, "Unità del rapporto", Dom, "", 2)
                        If KUN < 2 Then KUN = 2
                    Case "ME" : KUN = 1
                    Case "BR" : KUN = 3
                End Select
                Prev = job.Contratto
            Else
                '???? Prev.St = "SALV"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                KUN = 1 + Monitor.Motore.Quale(4, "Unità del rapporto", Dom, "", 4)
                If KUN = 1 Then KUN = 4
                If KUN = 5 Then KUN = 1
            End If
        End If
        '     UPMGTG Prev, Nrdit \ 2, 1, iRec
        'Color 1
        'Select Case IUNL
        'Case 3
        'iTest = AddLibrerie
        Ris = UPM()
        If Not Ris Then
            Tappi = False
        Else
            Cod = ""
            If iCassa > 0 Then Cod = "b" & Str(iCassa)
            Registra(NewFUPM, iCassa, Cod)
        End If
        'End Select
Fine:
        FileClose(33)

    End Function
    Function UPM() As Boolean
        ReDim Archiv(3), dAiu(3)
        UPM = True
        FileClose(33)
230:    FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        FileGet(33, MecData(0), 1)
        FileClose(33)
        If MecData(0).DO_Renamed > 0.0! And MecData(0).TSP > 0.0! Then
            'a$ = at1(51) + at1(52)
            ''         a$ = "L'efficienza di legamento lato|"
            ''    a$ = a$ + "tappi deve essere calcolata in|"
            ''    a$ = a$ + "modo standard ?               |"
            '    X = MsgBox(Monitor.Motore.Inizio.ConvertiCr(a), vbQuestion + vbYesNoCancel)
            'If X = vbCancel Then UPM = False: Exit Function
            If Apert._Option2_0.Checked Then IEL = "SI" Else IEL = "NO"
            '    EFFPLG(IEL)
            '910:        FileOpen(3, gstrText & RTrim(job.contratto), OpenMode.Input)
            '           If LOF(3) > 0 Then
            'FileClose(3)
            If IEL = "NO" Then
                Tit = Helpstringa(1024) ' at2(24) '"Efficienza di legamento"
                If Not Inq(Tit) Then UPM = False : Exit Function
                'EFFPLP()
                Stop
                '            Else
                '               FileClose(3) : IO.File.Delete(gstrText & RTrim(job.Contratto))
            End If
            '      Else
            '         If Len(Dir(gstrText & RTrim(job.Contratto))) > 0 Then IO.File.Delete(gstrText & RTrim(job.Contratto))
        End If
920:    CALSTR(iCassa, nCasse(TipoFas), iTest, KUN)
Spessori:
930:    SPSGET()
        Tit = Helpstringa(1026) ' at2(26) '"Spessori"
        If Not Inq(Tit) Then UPM = False : Exit Function
        SPSPUT(iCassa)
        CALSTR(iCassa, nCasse(TipoFas), iTest, KUN)
        VIDEOUPM()
        'DisplayU
911:    FileOpen(3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        A = ""
        Do
            Riga = LineInput(3)
            Riga = Riga.PadRight(70)
            A = A & Riga & Chr(124)
            If EOF(3) Then Exit Do
        Loop
        FileClose(3) : IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        Dom(3) = "Cambia setti"
        Dom(1) = "Procedi"
        Dom(2) = "Cambia spessore"
        If Nrdit = 0 Then Nscelta = 2 Else Nscelta = 3
        A = Monitor.Motore.Inizio.ConvertiCr(A)
        x = 1
        x = Monitor.Motore.Quale(Nscelta, "Risultati del calcolo", Dom, "", x, A, 1)
        If x = 0 Then UPM = False : Exit Function
        If x = 3 Then
            FileClose(33)
912:        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(iCassa)))
            FileGet(33, MecData(iCassa), Max(Abs(iCassa), 1))
1907:       Dom(1) = "N° di setti: "
            Risp(1) = Str(MecData(iCassa).NS)
            'LungSt(1) = Len(Risp$(1))
            Tit = "Cambio setti"
            Monitor.Motore.Chiamante = Monitor
            If Not Monitor.Motore.InputDati(1, Tit, Dom, Risp, "", Archiv, dAiu) Then
                FileClose(33) : UPM = False : Exit Function
            End If
            Nsv = MecData(iCassa).NS
            MecData(iCassa).NS = Val(Risp(1))
            For i = 1 To MecData(iCassa).NS + 1
                Dom(i) = "File camera" & Str(i)
                If i < Nsv + 2 Then
                    Risp(i) = GlobalRoutines.myStr(System.Math.Abs(MecData(iCassa).Nfile(i - 1)), 3, 5, False)
                Else
                    Risp(i) = Str(0)
                End If
                '         LungSt(i) = Len(Risp$(i))
            Next  'a
            '       PRINT ".Ns+1"; mecdata(icassa).Ns + 1:u$=input$(1)
            Monitor.Motore.Chiamante = Monitor
            If Not Monitor.Motore.InputDati(MecData(iCassa).NS + 1, Tit, Dom, Risp, "", Archiv, dAiu) Then
                FileClose(33) : UPM = False : Exit Function
            End If
            For i = 1 To MecData(iCassa).NS + 1
                If MecData(iCassa).Nfile(i - 1) < 0 Then
                    MecData(iCassa).Nfile(i - 1) = -Val(Risp(i))
                Else
                    MecData(iCassa).Nfile(i - 1) = Val(Risp(i))
                End If
                MecData(iCassa).HX5(i - 1) = 0.0!
            Next  'b
            SetSegni()
            If iVec = 0 Then GoTo 1907
909:        FilePut(33, MecData(iCassa), Max(iCassa, 1))
            FileClose(33)
            If Not DatiCassa(2) Then UPM = False : Exit Function
            GoTo Spessori
        End If
        If x = 2 Then GoTo Spessori
        Prev = Trim(job.Contratto)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        REPORT(iCassa, iTest, Prev)
ExF:
        Exit Function
ErrUPM:
        If Erl() = 920 And Err.Number = 11 Then
            Help = "Ci sono errori nei dati.|Il calcolo non pu• continuare"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Help))
            UPM = False
            Resume ExF
        Else
            Debug.Print("Err TAPPI/UPM" & Err.Number & Erl()) : Stop
        End If
    End Function
    Private Sub SetSegni()
        If iCassa = 1 Then iVec = 0
        For i = 1 To 16
            nFILEF.Nfile(i - 1) = objDatBase.CVS(objDatBase.DatBase(7, 1 + i, Nrdit \ 2, 1, itp, 0)) : Next
        For i = MecData(0).nPassi + 1 To 16 : nFILEF.Nfile(i - 1) = 0 : Next
        nPasf = MecData(0).nPassi : Nsf = MecData(0).NS
        TipoFas = MecData(0).Tipo
        Call FILEFUNZ(-iCassa) ', TipoFas, nPasf, Nsf, nFILEF)
        TotfileN = 0 : TotfileV = 0
        kk = 0
        For i = 1 To MecData(0).NS + 1
            If nFILEF.Nfile(i - 1) > 0 Then kk = kk + 1
            NewFILE(i) = System.Math.Abs(MecData(0).Nfile(i - 1 - 1))
            MecData(0).Nfile(i - 1) = System.Math.Abs(MecData(0).Nfile(i - 1 - 1))
            TotfileN = TotfileN + NewFILE(i)
            TotfileV = TotfileV + nFILEF.Nfile(i - 1 - 1)
        Next
        If TotfileV <> TotfileN Then
            Help = " Hai commesso un errore. Il totale |"
            Help = Help & "delle file di questa cassa deve es-|"
            Help = Help & "pari a" & Str(TotfileV)
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Help))
            iVec = 0
            Exit Sub
        End If
        k = 1 ' + iVec
        For i = 1 To MecData(0).NS + 1
            If (nFILEF.Nfile(k - 1) <> NewFILE(i)) And (nFILEF.Nfile(k - 1) > 0) Then
                MecData(0).Nfile(i - 1) = -MecData(0).Nfile(i - 1)
                NewFILE(i + 1) = NewFILE(i + 1) + NewFILE(i)
                NewFILE(i) = 0
            Else
                k = k + 1
            End If
        Next
        iVec = k
        If kk + 1 <> iVec Then
            Help = " Hai commesso un errore: le parti- |"
            Help = Help & "zioni non sono posizionate corret- |"
            Help = Help & "tamente:|"
            For i = 1 To kk
                Help = Help & "passo" & Str(i) & ": file" & Str(nFILEF.Nfile(i - 1)) & "|"
            Next
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Help))
            iVec = 0
        End If
    End Sub

    Public Sub BocchllOut()
        Dim l, i As Short
        Dim u As String
        Dim HH, SP As Single
        Dim Sch As String
        Dim iRec As Short
        Dim D, HH1 As Single
        Dim x As Short
        '    Case 1, 2: 'Bocchelli di servizio
        '               Help$ = at2(81)
        '               junk = Alert(4, Help$, 4, 3, 10, 58, "OK", "", "")
        '    Case 3, 5, 7, 9: 'N. Bocchellini
        '               Help$ = at1(56)
        '               junk = Alert(4, Help$, 4, 3, 10, 58, "OK", "", "")
        '    Case 4, 6, 8, 10: 'Size bocchellini
        '               For i = 1 To 6: Stringa(i) = Stringa3$(i): Next
        ''               Stringa(1) = " 1/2" + CHR$(34) 'cod 4 A
        ''               Stringa(2) = " 3/4" + CHR$(34) 'cod 5 B
        ''               Stringa(3) = " 1" + CHR$(34)    'cod 6 C
        ''               Stringa(4) = " 1 1/4" + CHR$(34) 'cod 7 D
        ''               Stringa(5) = " 1 1/2" + CHR$(34) 'cod 8 E
        ''               Stringa(6) = " 1 1/2" + CHR$(34) 'cod A F
        '               For i = 1 To 5: Stringa(i) = "Manicotto da" + Stringa(i): Next
        '               Stringa(6) = Stringa3$(7) + Stringa(6) ' "Bocchello da"
        '               Help$ = at1(56)
        '               x = Quale%(6, "", Stringa(), Help$, 0)
        '               If x < 5 Then
        '                 Risp$(Y) = Right$(Str$(x + 3), 1)
        '               Else
        '                 Risp$(Y) = Chr$(65 + x - 6)
        '               End If
        'End Select
        For i = 1 To 10
            Select Case i
                Case 1, 2
                    Risp(i) = CStr(Val(Monitor.Motore.InputForms(1 - 1).ComboFisso(i - 1).ListIndex))
                Case 4, 6, 8, 10
                    l = Monitor.Motore.InputForms(1 - 1).ComboFisso(i - 1).ListIndex
                    Select Case Monitor.Motore.InputForms(1 - 1).ComboFisso(i - 1).ListIndex
                        Case 0 'manicotti
                            Risp(i) = Str(l + 4)
                        Case 1 'bocchelli
                            Risp(i) = Chr(65 + l)
                    End Select
                Case Else
                    Risp(i) = Monitor.Motore.InputForms(1 - 1).prisposte(i)
            End Select
        Next
        For i = 4 To 10 Step 2
        Next
        If Val(Risp(1)) < 0 Or Val(Risp(1)) > 2 Or Val(Risp(2)) < 0 Or Val(Risp(2)) > 2 Then
            'BEEP
            'GoTo Rifai
            MsgBox("Dati inaccettabili")
        End If
        TipIn = Val(Risp(1))
        TipOut = Val(Risp(2))
        For i = 1 To 4
            'Codice="nA" n numero A cod
            CodMan(i) = LTrim(RTrim(Risp(2 * i + 1))) & LTrim(RTrim(Risp(2 * i + 2)))
            If Len(CodMan(i)) <> 2 Then
                MsgBox("Dati inaccettabili")
                ' BEEP:      GoTo Rifai
            End If
        Next i
        ' CLOSPREV()
130:    For i = 1 To 4
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.PutBasCh. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            u = objDatBase.PutBasCh(2, 66 + i, Nrdit \ 2, 1, CodMan(i), 0)
        Next
        'Apri Trim(job.contratto)
        'Get #33, 1, MecData(0)
        MecData(0).Bcgl(1 - 1) = TipIn
        MecData(0).Bcgl(2 - 1) = TipOut
        MecData(0).DBocIn = DBocIn
        MecData(0).DBocOut = DBocOut
        MecData(0).Rating = Rat
        If VUOTO Then
            Select Case iTest
                Case 3, 4
                    MecData(0).H = ReadLib(4, 3)
                Case Else
                    MecData(0).H = ReadLib(4, 2)
            End Select
        End If
        'IF VUOTO THEN CLOSE #33: EXIT SUB
        'segue calcolo larghezza cassa
        If MecData(0).Tipo < 0 Or MecData(0).Tipo > 4 Then MecData(0).Tipo = 0
        FilePut(33, MecData(0), 1)
        TipoFas = MecData(0).Tipo
        For i = 1 To nCasse(TipoFas)
            FileGet(33, MecData(i), i)
            MecData(i).Bcgl(1 - 1) = MecData(0).Bcgl(1 - 1)
            MecData(i).Bcgl(2 - 1) = MecData(0).Bcgl(2 - 1)
            If MecData(i).nBocIn > 0 Then
                HH = SpanIn
            Else
                HH = 0
            End If
            If MecData(i).nBocOut > 0 Then
                HH1 = SpanOut
            Else
                HH1 = 0
            End If
            If HH1 > HH Then HH = HH1
            If VUOTO And HH > MecData(i).H Then MecData(i).H = HH
            FilePut(33, MecData(i), i)
        Next
        FileClose(33)
        '===========================================================
        'CLOSPREV
        For i = 1 To 6
            Risp(i) = Monitor.Motore.InputForms(2 - 1).prisposte(i)
        Next
        u = objDatBase.PutBasCh(3, 24, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(1))), 0)
        u = objDatBase.PutBasCh(3, 25, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(2))), 0)
        u = objDatBase.PutBasCh(3, 2, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(3))), 0)
        u = objDatBase.PutBasCh(3, 9, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(4))), 0)
        u = objDatBase.PutBasCh(3, 26, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(5))), 0)
        u = objDatBase.PutBasCh(3, 23, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(6))), 0)
        x = Monitor.Motore.InputForms(2 - 1).ComboFisso(6).ListIndex + 2
        u = objDatBase.PutBasCh(4, 16, Nrdit \ 2, 1, objDatBase.MKI(x), 1)
        '        Apri(Trim(job.contratto))
    End Sub

    Public Sub MinSpan(ByRef i As Short, ByRef iCode As Short, ByRef Mode As Short)
        'mode 0:visual;1 leggi
        'Dim Flangia As Grafica.Flangia
        Dim DN As Single
        Dim ASA As Short
        Dim HH, HH1 As Single
        Dim SP, D, di As Single
        Select Case i 'In Out
            Case 1
                If iCode = 1 Then 'Boccaglio
141:                HH = ReadLib(2 + CShort(MecData(0).DBocIn / 2), 4)
                Else
                    DN = MecData(0).DBocIn
                    ASA = Val(Mid(Rat, 5, 5))
                    SceltaMin(DN, ASA, D, di, SP, Mode)
                    HH = CShort(D - 2.0! * SP)
                    MecData(0).DInmm = D
                    MecData(0).SpInmm = SP
                End If
                Monitor.Motore.InputForms(1 - 1).prisposte(12) = Str(Int(HH))
            Case 2
                If iCode = 1 Then 'Boccaglio
143:                HH1 = ReadLib(2 + CShort(MecData(0).DBocOut / 2), 4)
                Else
                    DN = MecData(0).DBocOut
                    ASA = Val(Mid(Rat, 5, 5))
                    SceltaMin(DN, ASA, D, di, SP, Mode)
                    HH1 = CShort(D - 2.0! * SP)
                    MecData(0).DOutmm = D
                    MecData(0).SpOutmm = SP
                End If
                Monitor.Motore.InputForms(1 - 1).prisposte(13) = Str(Int(HH1))
        End Select
        FilePut(33, MecData(0), 1)
    End Sub
    Private Sub SceltaMin(ByRef DN As Single, ByRef ASA As Short, _
                          ByRef D As Single, ByRef di As Single, _
                          ByRef SP As Single, ByVal Mode As Short)
        InitFlangia()
        With Flangia
            .K1 = 1
            .K3 = 1
            .K2 = 1
            If iCode = 2 Then .K3 = 4
            .Facing = 1
            .carica(Monitor.Motore.Inizio.DiscoRam)
            .SetDiam(DN)
            .SetRating(ASA)
            If Mode = 0 Then
                .Scelta(Monitor.Motore.Inizio.DiscoRam)
            Else
                .leggi(.K1, .K2, 1, .TabFlan, .K3, False, Monitor.Motore.Inizio.DiscoRam)
            End If
            D = .DiamTr
            di = .Diamint
            SP = (.DiamTr - .Diamint) / 2
            DN = GlobalRoutines.ConvPoll(.strDiam)
            ASA = Val(.strRati)
        End With
        FineFlangia()
    End Sub
    Public Function DatiCassa(ByRef i As Short) As Boolean
        Dim Tit, Help As String
        Help = RadiceHelp & "::/Testpe.htm#Camere"
        DatiCassa = True
        UPMALT(i, iCassa, iTest)
        Tit = "Dati meccanici" 'at2(57) '
        FaseDati = 10
        If Not Inq(Tit, 1) Then DatiCassa = False : Exit Function
        '     UPMPLT iCassa
        SETGET(iCassa, 0)
        Tit = "Camere" ' at2(25)  '
        FaseDati = 10
        If Not Inq(Tit, 2, Help) Then DatiCassa = False : Exit Function
        '     Call SettiVuoti(iCassa)
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Monitor.Motore.InputForms Is Nothing
        If FaseDati = -1 Then FaseDati = 0 : Return False
        Dim ifl As Integer = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(1)))
        FilePut(ifl, MecData(iCassa), Max(1, iCassa))
        FileClose(ifl)
    End Function
    Public Sub InitStringUPM()
        Dim i, j As Short
        TipC(0, 1) = Helpstringa(1001) ' at2(1)
        TipC(1, 1) = Helpstringa(1002) ' at2(2)
        TipC(1, 2) = Helpstringa(1003) 'at2(3)
        For i = 2 To 3
            For j = 1 To 3
                TipC(i, j) = Helpstringa(1003 + (i - 2) * 3 + j) 'at2(3 + (i - 2) * 3 + j)
            Next j
        Next i
        For j = 1 To 4 : TipC(4, j) = Helpstringa(1009 + j) : Next j
        nCasse(0) = 1 : nCasse(1) = 2 : nCasse(2) = 3 : nCasse(3) = 3 : nCasse(4) = 4
    End Sub
End Module