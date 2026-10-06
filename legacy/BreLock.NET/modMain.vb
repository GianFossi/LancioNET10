Option Strict Off
Option Explicit On
Imports System.IO
Imports System.math
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Public Enum CodMAT
    MAT_SHELL = 1 'no
    MAT_FONDO = 2 'no
    MAT_TS = 3    '1
    MAT_TUBI = 4  '2
    MAT_CHANNEL = 5  '3
    MAT_CASSONETTO = 6 'no
    MAT_FL_CASSON = 7 'no
    MAT_SPLITRING = 8 'no
    MAT_PUSHRING = 9 'no
    MAT_INTSCREWS = 10 'no
    MAT_EXTSCREWS = 11 '4
    MAT_LOCKRING = 12 '5
    MAT_COVER = 13 '6
    MAT_DIAFR = 14 '7
    MAT_INSERTO = 15 'no
End Enum
Public Enum TipiCassonetto
    Conico = 0
    CilindricoDisass = 1
    CilindricoInLinea = 2
End Enum
Public Enum TipiBL
    BL_HH = 1
    BL_HL = 0
End Enum
Module modMain
    Public Const PI As Double = 3.14159265358979
    Public Const PSI As Single = 145.0377439
    Public Const NIUT As Single = 4.448222
    Public Const GRAV As Single = 9.80655
    Public Const INC As Single = 25.4
    '----------------------------------------------
    Public Const NumMat As Short = 15
    Public Const IDH_BASE_TAB As Short = 20
    Public Const IDH_BASE_TAB_0 As Short = 20
    Public Const IDH_BASE_TAB_1 As Short = 21
    Public Const IDH_BASE_TAB_2 As Short = 22
    Public Const IDH_BASE_TAB_3 As Short = 23
    Public Const IDH_BASE_TAB_4 As Short = 24
    Public Const IDH_BASE_TAB_5 As Short = 25
    Public Const IDH_BASE_TAB_6 As Short = 26
    Public Const IDH_BASE_TAB_7 As Short = 27
    Public Const IDH_BASE_TAB_8 As Short = 28
    Public Const STA_MANTELLO As Short = 100
    Public Const STA_PT As Short = 110
    Public Const STA_NUMSCR As Short = 120
    Public Const STA_ANELLI As Short = 130
    Public Const STA_CASSONETTO As Short = 140
    Public Const STA_CASSA As Short = 150
    Public Const STA_PUSHBARS As Short = 160
    Public Const STA_LOCKRING As Short = 170
    Public Const STA_DIAFR As Short = 180
    Public Const MSG_AMMISSCALDO As Short = 500
    Public Const MSG_AMMISSFREDDO As Short = 510
    Public Const MSG_YIELDCALDO As Short = 520
    Public Const MSG_YIELDFREDDO As Short = 530
    Public Const MSG_YOUNGCALDO As Short = 540
    Public Const MSG_YOUNGFREDDO As Short = 550
    Public Const MSG_ALFACALDO As Short = 560
    Public Const MSG_ALFAFREDDO As Short = 570
    Public Const MSG_FINE As Short = 600
    Public Const WRN_G1OUT As Short = 700
    Public Const WRN_G2OUT As Short = 710
    Public Const IDH_framCarichi As Short = 1000
    Public Const IDH_framCar_Seating As Short = 1010
    Public Const IDH_framCar_HT As Short = 1020
    Public Const IDH_framCar_Design As Short = 1030
    Public Const IDH_framCar_Plastic As Short = 1040
    Public Const IDH_framCar_Opzione As Short = 1060
    Public Const IDH_framViti As Short = 1200
    Public Const IDH_framViti_DiamNom As Short = 1210
    Public Const IDH_framViti_BC As Short = 1220
    Public Const IDH_framViti_Area As Short = 1230
    Public Const IDH_framViti_BSmin As Short = 1240
    Public Const IDH_framViti_BS As Short = 1250
    Public Const IDH_framViti_Numero As Short = 1260
    Public Const IDH_framViti_libTir As Short = 1270
    Public Const IDH_framGuarPT As Short = 1300
    Public Const IDH_framGuarPT_mat As Short = 1310
    Public Const IDH_framGuarPT_diam As Short = 1320
    Public Const IDH_framGuarPT_largh As Short = 1330
    Public Const IDH_framGuarPT_nubbin As Short = 1340
    Public Const IDH_framGuarPT_m As Short = 1350
    Public Const IDH_framGuarPT_Y As Short = 1370
    Public Const IDH_framGuarPT_Formula As Short = 1380
    Public Const IDH_framGuarPT_b As Short = 1390
    Public Const IDH_framGuarCh As Short = 1400
    Public Const IDH_framGuarCh_mat As Short = 1410
    Public Const IDH_framGuarCh_diam As Short = 1420
    Public Const IDH_framGuarCh_largh As Short = 1430
    Public Const IDH_framGuarCh_nubbin As Short = 1440
    Public Const IDH_framGuarCh_m As Short = 1450
    Public Const IDH_framGuarCh_Y As Short = 1470
    Public Const IDH_framGuarCh_Formula As Short = 1480
    Public Const IDH_framGuarCh_b As Short = 1490
    Public Const NumCalc As Short = 7
    '----------------------------------------------
    Public RadiceHelp, Radix As String
    Public Monitor As clsMonitor
    Public objmat As New LibMat.MaterialeNew1
    Public nomefile As String
    Public NormalColor As Integer
    Public ClickManuale As Boolean
    Public ModifiedData As Boolean
    Public Calcolato(10) As Boolean
    Public objBre As clsBreLoc
    '------------------------------------------------
    Public FormApert As frmApert
    Public myAssembly As System.Reflection.Assembly
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public GlobalRoutines As RoutBase1.clsTrigon
    Public Stub9 As StubW9.clsSW9
    Public Stub As StubW2000.clsSW2000
    Friend CalcolaTutto As Boolean
    Private DmedSR As Single
    Private M3, M4, M5 As Single
    Private X9A As Single
    Private POISS As Single = 0.3
    Private FileStampa As String
    Private Risposta() As String = {"", "YES", "NO"}
    Private RappS0sS As Single
    Private DiamAugmDesign As Single
    Private BraccioAugmDesign As Single
    Private DiamAugmAccident As Single
    Private BraccioAugmAccident As Single
    Private Chart As String
    Private Anew, Acorr As Single
    Friend DaASME As Boolean
    Friend optCalcolaBuckling, optVitiSnerv, _
           optVitiAutomatiche, optAutomEstensioni As Boolean
    '-------------------------------------------------
    Friend Const LICENSE_PARAMETERS As String = _
"<LicenseParameters><RSAKeyValue><Modulus>9SXb7j1wew1DBj8wYzKJTI0IrIiSCx7YHdr8rrT9DclCuZepHJdXPqDsOhTRL0M8tIPz7O5eWWRGTloHAajg8xC85Oed9Q9+PlxtYLgBJf3ttX22xj/mUU/ZRBDkLGgJM4ndggpDYMR2oCgvd6Aint4zkNIsrqUObnEj1CS9qd0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue><DesignSignature>QqzKnlQMHohmNQVmfFQIBvSlHkFlL4BEHrlpOS6jAZqC97covJ0p0PwENRmegQhQxSud0QhlLApz5+nuHI5A4oCdBh6n102lseedVKZulMfUmukcQ0mvLer7GtDrJFeDNfJpW8FpdHL7KdUBZ4cbvhzXcii6MqOHIhdDU5txRA4=</DesignSignature><RuntimeSignature>SCo56Zzb3BJtgLssa/zxx17u1VE5gEG7pe6p4GvMdy8IaFYxf/m2/6IEIRdbYvwArfgfqd7CFOSC83jbVZvfLVqy1SktG8eTJ6y7SiG5ksK3R20lGlKskhi6ZcTsr/k7vKpv0hvbUQj17mkCRUn4eMe4FMQ1IeZ4apTKzCzSKzw=</RuntimeSignature><KeyStrength>7</KeyStrength></LicenseParameters>"
    '--------------------------------------------------
    Friend Function EspandiMat(ByVal i As Integer) As Integer
        If objBre.TipoBL = TipiBL.BL_HH Then Return i
        Select Case i
            Case 1, 2, 3 : Return i + 2
            Case Else : Return i + 7
        End Select
    End Function
    Public Sub SigmaAmm(ByRef t As Single, ByRef Sfo As Single, ByRef Sfa As Single)
        'Dim t1 As Single
        With objmat
            If .Indmat = 0 Then Exit Sub
            't1 = t * 1.8 + 32
            .SigmaAmm(LibMat.Codes.div1MPa, t, Sfa, Sfo)
        End With
    End Sub
    Public Sub Snerv(ByRef t As Single, ByRef Sfo As Single, ByRef Sfa As Single)
        ' Dim t1 As Single
        With objmat
            If .Indmat = 0 Then Exit Sub
            't1 = 1.8 * t + 32
            .YieldTemp(LibMat.Codes.div1MPa, t, Sfa, Sfo)
        End With
    End Sub
    Public Function apri(Optional ByRef icome As String = "") As Boolean
        Dim bf As New BinaryFormatter
        If Not objBre.Sciolto And Not DaASME Then nomefile = icome
        Try
            Dim fs As FileStream = New FileStream(nomefile, FileMode.OpenOrCreate)
            objBre = CType(bf.Deserialize(fs), clsBreLoc)
            fs.Close()
        Catch ex As Exception
            Return False
        End Try
        apri = True
    End Function
    Public Function scrivi() As Boolean
        Dim bf As New BinaryFormatter
        If nomefile Is Nothing Then Exit Function
        If Len(nomefile) = 0 Then Exit Function
        scrivi = True
        Dim fs As FileStream = New FileStream(nomefile, FileMode.OpenOrCreate)
        bf.Serialize(fs, objBre)
        fs.Close()
        ModifiedData = False
    End Function
    Public Sub stampa(Optional ByVal FromAsmeVIP As Boolean = False)
        FINALE()
        If Not FromAsmeVIP Then
            Monitor.Motore.ProgrInizio(HelpStringa(1027), "BreLock")
            Monitor.Motore.Avanzamento = 10
            Application.DoEvents()
        End If
        STAMPAS(FromAsmeVIP)
        Monitor.Motore.Problem.Printa("\page ")
        Monitor.Motore.Problem.copia(Monitor.Motore.Inizio.Archdir + "\DeformThrEnd.rtf")
        If FromAsmeVIP Then Exit Sub
        Monitor.Motore.Problem.FineRapp()
        Monitor.Motore.Avanzamento = 50
        Application.DoEvents()
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Stub9 = New StubW9.clsSW9
            If Stub9.SuperStampa(FileStampa, Monitor.Motore.Inizio.VersOffice, True) > 0 Then
                Monitor.Motore.ProgrAmmazza()
                Exit Sub
            End If
            Stub9.sSaveAs(FileStampa)
            Monitor.Motore.Avanzamento = 90
            Application.DoEvents()
            Stub9.Massimizza()
        Else
            Stub = New StubW2000.clsSW2000
            If Stub.SuperStampa(FileStampa, Monitor.Motore.Inizio.VersOffice, True) > 0 Then
                Monitor.Motore.ProgrAmmazza()
                Exit Sub
            End If
            Stub.sSaveAs(FileStampa)
            Monitor.Motore.Avanzamento = 90
            Application.DoEvents()
            Stub.Massimizza()
        End If
        Monitor.Motore.ProgrAmmazza()
    End Sub
    Public Sub Azzera()
        With objBre
            .DesTempSS = 0
            .DesPresSS = 0
            .DesTempTS = 0
            .DesPresTS = 0
            .DiffPres = 0
            .P2idr = 0
            .IDShell = 0
            .CorrSh = 0
            .ThkMinSh = 0
            .ThkAdpSh = 0
            .Gasket = ""
            .G1out = 0
            .G1dente = -1
            .G1N = 0
            .G1AnExt = 0
            .G1AnInt = 0
            .Nubbin = 0
            .m = 0
            .Y = 0
            .B1 = 0
            .ThkMinHe = 0
            .ThkAdpHe = 0
            .CorrSh = 0
            .HemRadius = 0
            .TubeDout = 0
            .Passo = 0
            .CorrTSCh = 0
            .CorrTSSh = 0
            .Cava = 0
            .ThkMinTS = 0
            .ThkAdpTS = 0
            .EffDiff = 0
            .DNIntScr = 0
            .BCIntScr = 0
            .OffBCextScr = 0
            .AreBltScr = 0
            .NumScr = 0
            .Wseating = 0
            .Wtest = 0
            .Wdesign = 0
            .WplasticBox = 0
            .ODSplitRing = 0
            .IDSplitRing = 0
            .ThkReqSplitRing = 0
            .ThkAdpSplitRing = 0
            .ODInnerRing = 0
            .IDInnerRing = 0
            .ThkReqInnerRing = 0
            .ThkAdpInnerRing = 0
            .MDCompRing = 0
            .Corr = 0
            .Fascia = 0
            .RotBolt = 0
            .RotTest = 0
            .RotDes = 0
            .MaxDCasson = 0
            .MinDCasson = 0
            .AltCasson = 0
            .ThkCasson = 0
            .DiamApCono = 0
            .NoApCono = 0
            .CorrCono = 0
            .DOAnelCono = 0
            .DIAnelCono = 0
            .ThkMinFC = 0
            .ThkAdpFC = 0
            .IDChan = 0
            .CorrCh = 0
            .GskChan = ""
            .G2out = 0
            .offG2out = 0
            .G2N = 0
            .G2dente = -1
            .G2AnInt = 0
            .G2AnExt = 0
            .NubGskChan = 0
            .mGskChan = 0
            .YGskChan = 0
            .B2 = 0
            .ThkMinCh = 0
            .ThkAdpCh = 0
            .DNExtScr = 0
            .BCExtScr = 0
            .AreExtScr = 0
            .DPushBars = 0
            .NExtScr = 0
            .WseatingCh = 0
            .WtestCh = 0
            .WdesignCh = 0
            .SpostDiaf2 = 0
            .DNBltScr2 = 0
            .BCIntScr2 = 0
            .AreBltScr2 = 0
            .DNIntPushBar2 = 0
            .NumScr2 = 0
            .IDExtComprRing = 0
            .Wadd1 = 0
            .Wadd2 = 0
            .SpostDiaf1 = 0
            .SpessDiaf = 0
            .DNLockR = 0
            .Filetto.DMaxAn = 0
            .IDLockR = 0
            .ThkMinLR = 0
            .ThkAdpLR = 0
            .NmaxFilettiPoss = 0
            .NreqFiletti = 0
            .NmaxFiletti = 0
            .ODCover = 0
            .ThkMinCv = 0
            .ThkAdpCv = 0
            .ExtCrwMinThk = 0
            .ExtCrwAdpThk = 0
            .EngagedAccident = 0
            .EngagedDesign = 0
            .NonCalcolaFondo = False
            .ExtraDistBCIntExt = 0
            .DNStr1 = ""
            .DNStr2 = ""
            .DNStr3 = ""
            .au_IDChan = True
            .au_BCIntScr = True
            .au_IDInnerRing = True
            .au_IDSplitRing = True
            .au_MaxDCasson = True
            .au_MinDCasson = True
            .au_ODInnerRing = True
            .au_ThkAdpFC = True
            .au_ThkAdpInnerRing = True
            .au_ThkAdpLR = True
            .au_ThkAdpSplitRing = True
            .au_DiamIntGola = True
        End With
        nomefile = ""
        objBre.Inizializza()
    End Sub
    Public Function CheckDatiMantello() As Boolean
        Dim Testo As String = ""
        With objBre.Mater(CodMAT.MAT_SHELL)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_SHELL) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_FONDO)
            If .S <= 0 And Not objBre.NonCalcolaFondo Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_FONDO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre
            If .DesPresSS <= 0 Then
                MostraAiuto(1029, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .DesTempSS = 0 Then
                MostraAiuto(1030, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .IDShell <= 0 Then
                MostraAiuto(1031, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .HemRadius = 0 And Not objBre.NonCalcolaFondo Then
                MostraAiuto(1032, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .G1out = 0 Then
                MostraAiuto(1033, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .m = 0 Or .Y = 0 Then
                MostraAiuto(1034, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        CheckDatiMantello = True
    End Function
    Public Function CheckDatiPT() As Boolean
        Dim Testo As String = ""
        With objBre.Mater(CodMAT.MAT_TS)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_TS) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_TS) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_TUBI)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_TUBI) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_TUBI) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre
            If .TubeDout <= 0 Then
                MostraAiuto(1035, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .Passo <= .TubeDout Then
                MostraAiuto(1036, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .DiffPresHT = 0 And .EffDiff = 0 Then
                MostraAiuto(1037, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            ElseIf .DiffPresHT = 0 Then
                MostraAiuto(1038, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            ElseIf .DiffPresHT < 0.99 * 1.3 * RappS0sS * .EffDiff Then
                If MostraAiuto(1039, RoutBase1.ChiaviMess.MessQuestion + _
                                     RoutBase1.ChiaviMess.MessHelpButton + _
                                     RoutBase1.ChiaviMess.MessYesNo, Testo, Radix) = _
                   RoutBase1.ChiaviMess.Messno Then .DiffPresHT = 1.3 * RappS0sS * .EffDiff
            ElseIf .EffDiff = 0 Then
                MostraAiuto(1040, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        CheckDatiPT = True
    End Function
    Public Function Val_ODInnerRing(Optional ByRef Variato As Boolean = False) As Single
        With objBre
            Dim Vecchio As Single = .ODInnerRing
            Dim Nuovo As Single
            Select Case .TipoCassonetto
                Case TipiCassonetto.Conico
                    Nuovo = .IDChan - 2 * .lbRadialGap ' .G1out + 2 * .G1AnExt '+ 6.0#
                Case TipiCassonetto.CilindricoInLinea
                    Nuovo = CInt(.BCIntScr + 2 * .lbCarneRadialeEsternoIR + .DNIntScr + 0.49)
                Case TipiCassonetto.CilindricoDisass
            End Select
            Variato = Nuovo <> Vecchio
            Return Nuovo
        End With
    End Function
    Public Sub InizCassonetto5()
        With objBre
            If .au_MaxDCasson Then .MaxDCasson = .G1out - .G1N
            If .au_MinDCasson Then
                Select Case .TipoCassonetto
                    Case TipiCassonetto.Conico
                        .MinDCasson = .BCIntScr
                    Case TipiCassonetto.CilindricoInLinea
                        .MinDCasson = .G1out - .G1N
                End Select
            End If
        End With
    End Sub
    Public Sub InizShell()
        With objBre
            If .G1dente < 0 Then .G1dente = .lbSpessDenteInternoGskShel
            If .G1N = 0 Then .G1N = .lbNGskPT
            If .G1out = 0 Then
                .G1out = .IDShell + 2 * (.G1dente + .G1N + .G1AnInt)
            End If
        End With
    End Sub
    Friend Function BCIntScrMin() As Single
        With objBre
            Dim BC1 As Single = .G1out + 2 * (.G1AnExt - .lbCarneRadialeEsternoIR) - .DNIntScr
            Dim BC2 As Single = .IDSplitRing - 2 * .lbIstmoIRconSR - .DNIntScr
            Dim BC3 As Single = .ODInnerRing - 2 * .lbCarneRadialeEsternoIR - .DNIntScr
            If BC2 <= 0 Or BC3 <= 0 Then
                Return BC1
            Else
                Return GlobalRoutines.Minimo(BC1, BC2, BC3)
            End If
        End With
    End Function
    Public Sub InizIntScr3()
        With objBre
            If (.DNIntScr = 0) Then .DNIntScr = 20
            'If .BCIntScr < 0.99 * BC Or .BCIntScr > 1.01 * BC Then .BCIntScr = Int(BC + 0.49)
            If .au_BCIntScr Then
                Select Case .TipoCassonetto
                    Case TipiCassonetto.Conico
                        .BCIntScr = CInt(BCIntScrMin())
                    Case TipiCassonetto.CilindricoInLinea
                        InizCassonetto5()
                        .BCIntScr = .MinDCasson
                End Select

            End If
        End With
    End Sub
    Public Sub InizChan2()
        With objBre
            If .G1dente < 0 Then .G1dente = .lbSpessDenteInternoGskChan
            If .G1N = 0 Then .G1N = .lbNGskChan
            .G1out = .IDShell + 2 * (.G1dente + .G1N + .G1AnInt)
            If .au_IDChan Then '< .G1out + 2 * .G1AnExt + 2 * .lbRadialGap Then
                Dim VecchioIDChan As Single = .IDChan
                Select Case .TipoCassonetto
                    Case TipiCassonetto.Conico
                        .IDChan = .G1out + 2 * .G1AnExt + 2 * .lbRadialGap
                    Case TipiCassonetto.CilindricoInLinea
                        InizAnelli4()
                        .IDChan = .ODInnerRing + 2 * .lbRadialGap
                End Select
                If .IDChan < .IDShell + 2 * (.ThkCasson + 2 * .lbRadialGap) Then
                    .IDChan = .IDShell + 2 * (.ThkCasson + 2 * .lbRadialGap)
                End If
                If .IDChan <> VecchioIDChan Then .offG2out = 0
            End If
            RappS0sS = Math.Min(.Mater(CodMAT.MAT_TS).S0 / .Mater(CodMAT.MAT_TS).S, .Mater(CodMAT.MAT_TUBI).S0 / .Mater(CodMAT.MAT_TUBI).S)
            If .Ipres = 1 Then .EffDiff = .DiffPres
            If .DiffPresHT < 1.3 * .EffDiff Then .DiffPresHT = 1.3 * RappS0sS * .EffDiff
        End With
    End Sub
    Public Sub InizScrews7()
        Dim i, IndR As Integer
        With objBre
            If .DNExtScr = 0 Then .DNExtScr = 20
            If .TipoBL = TipiBL.BL_HH Then
                Dim IstmoEffettivo As Single = (.G2out - .G2N - .MDCompRing - .ThkExtComprRing - .ThkIntComprRing) / 2
                If .DNBltScr2 = 0 Then .DNBltScr2 = 20
                If IstmoEffettivo < objBre.lbIstmoMinimoIntExt Then
                    .ExtraDistBCIntExt = objBre.lbIstmoMinimoIntExt - IstmoEffettivo
                    For i = 4 To 6
                        Calcolato(i) = False
                    Next
                    FormApert.GuardaIndietro(7, IndR)
                End If
                .BCIntScr2 = .MDCompRing
            End If
            .BCExtScr = .G2out - .G2N - .OffBCextScr
            .IDExtComprRing = .BCExtScr - .DNExtScr - 10
            .ODExtComprRing = Min(.BCExtScr + .DNExtScr + 10, .G2out + 2 * .G2AnExt - 4)
        End With
        GSKCH()
    End Sub
    Public Function IDInnerRingOpt() As Single
        With objBre
            Return CInt(.BCIntScr - .DNIntScr - _
                        2 * (.lbSpazioIntScrCompRing + _
                             .lbThkCompRing + _
                             .ExtraDistBCIntExt)) ' 75.0#
        End With
    End Function
    Public Sub InizAnelli4()
        With objBre
            If .au_IDSplitRing Then
                .IDSplitRing = .IDChan - 2 * .lbSporgenzaSplitRing ' + 6.0# - 30.0#
            End If
            'If .ODSplitRing <= 0 Then
            .ODSplitRing = .IDChan - 2 * .lbSporgenzaSplitRing + 2 * .lbThkSplitRing ' 70.0#
            'End If
            If .au_IDInnerRing Then
                .IDInnerRing = IDInnerRingOpt()
            End If
            Dim Variato As Boolean
            Dim IndR As Integer
            If .au_ODInnerRing Then
                .ODInnerRing = Val_ODInnerRing(Variato)
                If Variato Then
                    Calcolato(3) = False
                    Calcolato(2) = False
                    FormApert.GuardaIndietro(4, IndR)
                End If
            End If
            'If .MDCompRing <= 0 Then
            .MDCompRing = .IDInnerRing + objBre.lbThkCompRing ' 25.0#
            'End If
            'If (.DIAnelCono <= 0) Then
            .DIAnelCono = .IDInnerRing - 2 * objBre.lbSporgenzaAnelCono '90
            'End If
            'If (.DOAnelCono <= 0) Then
            .DOAnelCono = .ODInnerRing
            'End If
            If (.ThkCasson <= 0) Then
                .ThkCasson = objBre.lbThkCasson ' 16.0
            End If
        End With
    End Sub

    Public Function CheckDatiScr() As Boolean
        Dim Testo As String
        With objBre.Mater(CodMAT.MAT_INTSCREWS)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(10) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(10) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(10) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre
            If .G1out <= 0 Then
                Exit Function
            End If
            If .m <= 0 Then
                Exit Function
            End If
            If .Y <= 0 Then
                Exit Function
            End If
            If .B1 <= 0 Then
                Exit Function
            End If
            If .DNIntScr = 0 Then
                Exit Function
            End If
            '  If .AreBltScr = 0 Then
            'Exit Function
            'End If
            If .BCIntScr = 0 Then
                Exit Function
            End If
        End With
        CheckDatiScr = True
    End Function

    Public Function CheckDatiAnelli() As Boolean
        Dim Testo As String
        With objBre.Mater(CodMAT.MAT_SPLITRING)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_SPLITRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_SPLITRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(CodMAT.MAT_SPLITRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY0 <= 0 Then
                Testo = HelpStringa(MSG_YIELDFREDDO) & " " & HelpStringa(CodMAT.MAT_SPLITRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_PUSHRING)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_PUSHRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_PUSHRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(CodMAT.MAT_PUSHRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY0 <= 0 Then
                Testo = HelpStringa(MSG_YIELDFREDDO) & " " & HelpStringa(CodMAT.MAT_PUSHRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre
            If .IDInnerRing = 0 Then
                Exit Function
            End If
            If .ODInnerRing <= .IDInnerRing Then
                Exit Function
            End If
            If .IDSplitRing <= .IDInnerRing Then
                Exit Function
            End If
            If .ODSplitRing <= .IDSplitRing Then
                Exit Function
            End If
            If .MDCompRing <= .IDInnerRing Then
                Exit Function
            End If
        End With
        CheckDatiAnelli = True
    End Function

    Public Function CheckDatiCassonetto() As Boolean
        Dim Testo As String
        With objBre.Mater(CodMAT.MAT_INSERTO)
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(CodMAT.MAT_INSERTO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY0 <= 0 Then
                Testo = HelpStringa(MSG_YIELDFREDDO) & " " & HelpStringa(CodMAT.MAT_INSERTO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_CASSONETTO)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_CASSONETTO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_CASSONETTO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY0 <= 0 Then
                Testo = HelpStringa(MSG_YIELDFREDDO) & " " & HelpStringa(CodMAT.MAT_CASSONETTO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .E <= 0 Then
                Testo = HelpStringa(MSG_YOUNGCALDO) & " " & HelpStringa(CodMAT.MAT_CASSONETTO) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YOUNGCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_FL_CASSON)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_FL_CASSON) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_FL_CASSON) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY0 <= 0 Then
                Testo = HelpStringa(MSG_YIELDFREDDO) & " " & HelpStringa(CodMAT.MAT_FL_CASSON) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .E <= 0 Then
                Testo = HelpStringa(MSG_YOUNGCALDO) & " " & HelpStringa(CodMAT.MAT_FL_CASSON) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YOUNGCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_PUSHRING)
            If .E <= 0 Then
                Testo = HelpStringa(MSG_YOUNGCALDO) & " " & HelpStringa(CodMAT.MAT_PUSHRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YOUNGCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .E0 <= 0 Then
                Testo = HelpStringa(MSG_YOUNGFREDDO) & " " & HelpStringa(CodMAT.MAT_PUSHRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YOUNGFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        Dim Ris As Boolean = True
        With objBre
            If .AltCasson = 0 Then
                FormApert.EP_txtCasson_5.SetError(FormApert._txtCasson_5, HelpStringa(1019))
                Ris = False
            Else
                FormApert.EP_txtCasson_5.SetError(FormApert._txtCasson_5, "")
            End If
            If .MaxDCasson = 0 Then
                Ris = False
            End If
            If .MinDCasson = 0 Then
                Ris = False
            End If
            If .ThkCasson = 0 Then
                Ris = False
            End If
            If .DIAnelCono = 0 Then
                Ris = False
            End If
            If .DOAnelCono < .DIAnelCono Then
                Ris = False
            End If
        End With
        Return Ris
    End Function
    Public Function CheckDatiCassa() As Boolean
        Dim Testo As String
        With objBre.Mater(CodMAT.MAT_CHANNEL)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_CHANNEL) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre
            If .IDChan <= 0 Then
                Exit Function
            End If
            If .G2out = 0 Then
                Exit Function
            End If
            If .mGskChan = 0 Or .YGskChan = 0 Then
                Exit Function
            End If
        End With
        CheckDatiCassa = True
    End Function

    Public Function CheckDatiVitiExt() As Boolean
        Dim Testo As String
        With objBre.Mater(CodMAT.MAT_EXTSCREWS)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(11) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(11) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(11) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_DIAFR)
            If .E <= 0 Then
                Testo = HelpStringa(MSG_YOUNGCALDO) & " " & HelpStringa(14) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YOUNGCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        If objBre.DNIntPushBar2 = 0 Or objBre.DPushBars = 0 Then Stop
        CheckDatiVitiExt = True
    End Function
    Public Function CheckDatiLR() As Boolean
        Dim Testo As String
        With objBre.Mater(CodMAT.MAT_LOCKRING)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_LOCKRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_LOCKRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(CodMAT.MAT_LOCKRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY0 <= 0 Then
                Testo = HelpStringa(MSG_YIELDFREDDO) & " " & HelpStringa(CodMAT.MAT_LOCKRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .Alfa <= 0 Then
                Testo = HelpStringa(MSG_ALFACALDO) & " " & HelpStringa(CodMAT.MAT_LOCKRING) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_ALFACALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_COVER)
            If .S <= 0 Then
                Testo = HelpStringa(MSG_AMMISSCALDO) & " " & HelpStringa(CodMAT.MAT_COVER) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .S0 <= 0 Then
                Testo = HelpStringa(MSG_AMMISSFREDDO) & " " & HelpStringa(CodMAT.MAT_COVER) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_AMMISSFREDDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .SY <= 0 Then
                Testo = HelpStringa(MSG_YIELDCALDO) & " " & HelpStringa(CodMAT.MAT_COVER) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YIELDCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        With objBre.Mater(CodMAT.MAT_CHANNEL)
            If .E <= 0 Then
                Testo = HelpStringa(MSG_YOUNGCALDO) & " " & HelpStringa(5) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_YOUNGCALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
            If .Alfa <= 0 Then
                Testo = HelpStringa(MSG_ALFACALDO) & " " & HelpStringa(5) & "|" & HelpStringa(MSG_FINE)
                MostraAiuto(MSG_ALFACALDO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly, Testo, Radix)
                Exit Function
            End If
        End With
        CheckDatiLR = True
    End Function
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As RoutBase1.ChiaviMess = RoutBase1.ChiaviMess.MessCritical + RoutBase1.ChiaviMess.MessOkOnly, _
    Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "", Optional ByVal Proportional As Boolean = False) As RoutBase1.ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = HelpStringa(id)
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "BreLock - Messaggi di errore"
                If Not Informa And RoutBase1.ChiaviMess.MessCritical Then Tit = "BreLock"
            Else
                Tit = mioTitolo
            End If
            Dim Topic As String = Monitor.HelpTopic(id)
            If Topic = "" Then
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa, Tit, RadiceHelp, Topic, Proportional:=Proportional)
            Else
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or RoutBase1.ChiaviMess.MessHelpButton, Tit, RadiceHelp, Topic, Proportional:=Proportional)
            End If
        Else
            MessageBox.Show("Errore sconosciuto")
        End If
    End Function
    Public Sub CalcDeltaT()
        Dim AlfaCh, AlfaLR As Single
        With objBre
            If .CalcDeltaT = 0 Then
                .DeltaT = 0
                Exit Sub
            End If
            objmat.Indmat = .Mater(CodMAT.MAT_CHANNEL).IndMat
            objmat.RecupMat(Monitor.Motore.Inizio.Archdir)
            AlfaCh = objmat.AlfaTer(1.8 * .TempTransCh + 32.0#) * 1.8
            objmat.Indmat = .Mater(CodMAT.MAT_LOCKRING).IndMat
            objmat.RecupMat(Monitor.Motore.Inizio.Archdir)
            AlfaLR = objmat.AlfaTer(1.8 * .TempTransLR + 32.0#) * 1.8
            .DeltaT = (AlfaCh * .TempTransCh - AlfaLR * .TempTransLR) * .DNLockR
        End With
    End Sub
    Public Sub BRE()
        Dim K8, C5 As Single
        With objBre
            'C
            'C     CALCOLO SPESSORE MANTELLO SECONDO UG 27.c.1
            'C
            If (.DesPresSS > 0.385 * .Mater(CodMAT.MAT_SHELL).S) Then
                K8 = (.Mater(CodMAT.MAT_SHELL).S + .DesPresSS) / (.Mater(CodMAT.MAT_SHELL).S - .DesPresSS)
                .ThkMinSh = (.IDShell / 2 + .CorrSh) * (Math.Sqrt(K8) - 1) + .CorrSh
            Else
                .ThkMinSh = .DesPresSS * (.IDShell / 2 + .CorrSh) / (.Mater(CodMAT.MAT_SHELL).S - 0.6 * .DesPresSS) + .CorrSh
            End If
            If Not .NonCalcolaFondo Then
                'C()
                'C     CALCOLO FONDO SFERICO IN ACCORDO A UG-32.F
                'C()
                If (.DesPresSS > 0.665 * .Mater(CodMAT.MAT_FONDO).S) Then
                    C5 = 2 * (.Mater(CodMAT.MAT_FONDO).S + .DesPresSS) / (2 * .Mater(CodMAT.MAT_FONDO).S - .DesPresSS)
                    .ThkMinHe = (.HemRadius + .CorrSh) * (C5 ^ (1 / 3) - 1) + .CorrSh
                Else
                    .ThkMinHe = .DesPresSS * (.HemRadius + .CorrSh) / (2 * .Mater(CodMAT.MAT_FONDO).S - 0.2 * .DesPresSS) + .CorrSh
                End If
            End If
        End With
    End Sub
    Friend Sub TUBESHEET()
        Dim VARNU, TCOR, E9, H9 As Single
        With objBre
            If (.iPasso = 1) Then
                VARNU = 1 - (0.907 / (.Passo / .TubeDout) ^ 2)
            Else
                VARNU = 1 - (0.785 / (.Passo / .TubeDout) ^ 2)
            End If
            'C     TEST SE LA CORR. LATO TUBI E' MAGGIORE DEL GROOVE
            TCOR = Math.Max(.CorrTSCh, .Cava)
            If (.TipoBL = TipiBL.BL_HL) Then GoTo 1350
            .ThkMinTS = ((1.25 * .G1eff) / 3) * Math.Sqrt(.DiffPres / (VARNU * .Mater(CodMAT.MAT_TS).S)) + TCOR + .CorrTSSh
            GoTo 1440
1350:       E9 = .ThkAdpCh / .IDChan
            If (E9 > 0.02) Then GoTo 1390
            H9 = 1.25
            GoTo 1430
1390:       If (E9 < 0.05) Then GoTo 1420
            H9 = 1
            GoTo 1430
1420:       H9 = (0.0425 / 0.03) - E9 * (0.25 / 0.03)
1430:       .ThkMinTS = (H9 * .IDChan / 3) * Math.Sqrt(.DesPresTS / (VARNU * .Mater(CodMAT.MAT_TS).S)) + TCOR + .CorrTSSh
1440:       If (.TipoBL = TipiBL.BL_HL) Then PUSHBARS()
        End With
    End Sub
    Friend Sub INTSCR()
        With objBre
            Try
                '     CALCOLO DEI CARICHI SUI TIRANTI INTERNI
                .Wdesign = (2 * .B1 * Math.PI * .G1eff * .m * .DiffPres + Math.PI * .G1eff ^ 2 * .DiffPres / 4) * .Ipres 'Design
                .Wseating = .B1 * Math.PI * .G1eff * .Y / PSI '!Seating
                .Wtest = 2 * .B1 * Math.PI * .G1eff * .m * .DiffPresHT + Math.PI * .G1eff ^ 2 * .DiffPresHT / 4 'HT
                InizIntScr3()
                If (.AreExtension > .AreBltScr) Then .AreBltScr = .AreExtension
                .AreqScrDesign = .Wdesign / .Mater(CodMAT.MAT_INTSCREWS).S   'Design se per viti BOXD=0 se per ring BOXD=plasticizz. viti
                .AreqScrSeating = .Wseating / .Mater(CodMAT.MAT_INTSCREWS).S0 'Seating
                .AReqScrTest = .Wtest / (0.67 * .Mater(CodMAT.MAT_INTSCREWS).SY0) 'HT
                .AReqScrTestExtension = .Wtest / .Mater(CodMAT.MAT_INTSCREWS).SY0 * .AreBltScr / .AreExtension
                .AreqScr = GlobalRoutines.Massimo(.AReqScrTest, .AreqScrDesign, _
                           .AreqScrSeating, .AReqScrTestExtension)
                Dim Testo As String = HelpStringa(9002) + vbCrLf
                Select Case .AreqScr
                    Case .AreqScrDesign : Testo &= HelpStringa(9003)
                    Case .AreqScrSeating : Testo &= HelpStringa(9004)
                    Case .AReqScrTest : Testo &= HelpStringa(9005)
                    Case .AReqScrTestExtension : Testo &= HelpStringa(9006)
                End Select
                FormApert.txtSizeScr.Text = Testo
                .NumScr = Int(.AreqScr / .AreBltScr) + 1
                Dim Resto As Integer = .NumScr Mod 4
                If Resto > 0 Then .NumScr += 4 - Resto
                Call CaricoProg()
            Catch ex As OverflowException
                .NumScr = 0
            Catch ex As Exception
                MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
            End Try
        End With
    End Sub
    Friend Sub CaricoProg()
        With objBre
            If (.Considera = 0) Then
                .WplasticBox = .NumScr * .AreExtension * .Mater(CodMAT.MAT_INTSCREWS).SY
            Else
                .WplasticBox = .NumScr * .AreExtension * .Mater(CodMAT.MAT_INTSCREWS).SY / 2   'W1
            End If
            .WdesignPl = Math.Max(.Wdesign, .WplasticBox)
            FormApert.txtViti(7).Text = GlobalRoutines.myStr(.WplasticBox / 1000000.0#, 5, 3, False)
        End With
    End Sub
    Friend Sub Anelli()
        Dim Y7 As Single
        Dim L5, L6, L7 As Single
        Dim Q3, Q4, Q5 As Single
        Dim U6, U7, U8 As Single
        Dim J1r As Single
        Call CaricoProg()
        Try
            With objBre
                .AactScr = .NumScr * .AreBltScr
                Y7 = 0.9 * .Mater(CodMAT.MAT_SPLITRING).SY0 'split ring
                '    CALCOLA LA RETTA D'AZIONE DEL CARICO SULLO SPLIT RING
                DmedSR = (.ODInnerRing + .IDSplitRing) / 2
                .WdesignPl = Math.Max(.Wdesign, .WplasticBox)
                .S1bearSR = 4 * .WdesignPl / (Math.PI * ((.ODInnerRing - 2 * .Corr) ^ 2 - .IDSplitRing ^ 2))
                .S2bearSR = 4 * .Wseating / (Math.PI * (.ODInnerRing ^ 2 - .IDSplitRing ^ 2))
                .SobearSR = 4 * .Wtest / (Math.PI * (.ODInnerRing ^ 2 - .IDSplitRing ^ 2))
                L5 = Math.Min(.Mater(CodMAT.MAT_SPLITRING).SY, .Mater(CodMAT.MAT_PUSHRING).SY)
                L6 = Math.Min(.Mater(CodMAT.MAT_SPLITRING).SY0, .Mater(CodMAT.MAT_PUSHRING).SY0)
                L7 = L6
                .Fascia = 0
                If (.S1bearSR > L5) Or (.S2bearSR > L6) Or (.SobearSR > L7) Then
                    Q3 = Math.Sqrt((4 * .WdesignPl / (Math.PI * L5)) + .IDSplitRing ^ 2) + 2 * .Corr
                    Q4 = Math.Sqrt((4 * .Wseating / (Math.PI * L6)) + .IDSplitRing ^ 2)
                    Q5 = Math.Sqrt((4 * .Wtest / (Math.PI * L7)) + .IDSplitRing ^ 2)
                    J1r = GlobalRoutines.Massimo(Q3, Q4, Q5)
                    .Fascia = (J1r - .IDSplitRing) / 2
                End If
                U6 = 0.6 * .Mater(CodMAT.MAT_SPLITRING).S
                U7 = 0.6 * .Mater(CodMAT.MAT_SPLITRING).S0
                '     LO SHEAR STRESS IN TEST E' 0.6*(0.67Sy)
                U8 = 0.6 * 0.67 * .Mater(CodMAT.MAT_SPLITRING).SY0
                .ThkReqSRdesign = .WdesignPl / (Math.PI * (DmedSR - .Corr) * U6)
                .ThkReqSRseating = .Wseating / (Math.PI * DmedSR * U7)
                .ThkReqSRtest = .Wtest / (Math.PI * DmedSR * U8)
                .ThkReqSplitRing = GlobalRoutines.Massimo(.ThkReqSRseating, .ThkReqSRtest, .ThkReqSRdesign + .Corr)
                '     INIZIO CALCOLO INTERNAL RING
                '     CALCOLA IL BRACCIO TRA DIAMETRO ESTERNO E IL CERCHIO SCREWS
                Dim E1, E2, M3A, M3B, M4A, M4B As Single
                E1 = (DmedSR - .BCIntScr) / 2
                M3A = .WdesignPl * (E1 - .Corr / 2)
                'C     CALCOLA IL BRACCIO TRA DIAMETRO INTERNO E IL CERCHIO SCREWS
                E2 = (.BCIntScr - .MDCompRing) / 2
                M3B = .WdesignPl * E2
                'C     SCEGLIE IL MOMENTO MAGGIORE TRA I DUE CALCOLATI
                M3 = Math.Max(M3A, M3B)
                M4A = .Wseating * E1
                M4B = .Wseating * E2
                'C     SCEGLIE IL MOMENTO MAGGIORE TRA I DUE CALCOLATI
                M4 = Math.Max(M4A, M4B)
                M5 = .Wtest * E1
                Dim U1, V1 As Single
                U1 = (.ODInnerRing - 2 * .Corr) / (.IDInnerRing + 2 * .Corr)
                Call S3290(U1, V1)
                'C     CALCOLA LO SPESSORE DELL'ANELLO DI SPINTA
                .ThkReqIRdesign = Math.Sqrt(V1 * M3 / ((.IDInnerRing + 2 * .Corr) * .Mater(CodMAT.MAT_PUSHRING).S))
                U1 = .ODInnerRing / .IDInnerRing
                Call S3290(U1, V1)
                .ThkReqIRseating = Math.Sqrt(V1 * M4 / (.IDInnerRing * .Mater(CodMAT.MAT_PUSHRING).S0))
                .ThkReqIRtest = Math.Sqrt(V1 * M5 / (.IDInnerRing * 0.9 * .Mater(CodMAT.MAT_PUSHRING).SY0))
                .ThkReqInnerRing = GlobalRoutines.Massimo(.ThkReqIRseating, .ThkReqIRtest, .ThkReqIRdesign + 2 * .Corr)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub S3290(ByVal U1 As Single, ByRef V1 As Single)
        'C     ROUTINE PER IL CALCOLO DEI COEEFICIENTI DELLA FLANGIA
        V1 = (1 / (U1 - 1)) * (0.66845 + 5.7169 * (U1 ^ 2 * Math.Log10(U1) / (U1 ^ 2 - 1)))
    End Sub
    Friend Sub CASSONETTO()
        With objBre
            .S1shearSR = .WdesignPl / (Math.PI * (DmedSR - .Corr) * (.ThkAdpSplitRing - .Corr))
            .S2shearSR = .Wseating / (Math.PI * DmedSR * .ThkAdpSplitRing)
            .SoshearSR = .Wtest / (Math.PI * DmedSR * .ThkAdpSplitRing)
            'C     CONTROLLO SULLE ROTAZIONI
            Call ROTAZF(M3, M4, M5, .IDInnerRing, .ODInnerRing, .ThkAdpInnerRing, .VerificaRotaz)
            FormApert.SetErrorRotaz()
            'C     FINE CALCOLO INTERNAL RING
            'C     CALCOLO VIROLA CONICA
            Call Virc(.VerificaCono)
            '     CALCOLA IL DIAMETRO MEDIO DEL BOX FLANGE
            Dim IDCID As Single = (.DOAnelCono + .DIAnelCono) / 2
            'C     CALCOLA IL PRIMO EVENTUALE BRACCIO TRA IL DIAMETRO MEDIO DEL
            'C     BOX FLANGE E IL DIAMETRO MEDIO MINIMO DEL CONO
            Dim BR1 As Single = (.MinDCasson - IDCID) / 2
            'C     CALCOLA IL SECONDO EVENTUALE BRACCIO TRA IL CERCHIO DEI TIRANTI
            'C     INTERNI E IL DIAMETRO MEDIO DEL BOX FLANGE
            Dim BR2 As Single = (.BCIntScr - IDCID) / 2
            'C     CALCOLA L'ANGOLO ALFA DEL CONO
            Dim ALFA As Single = Math.Atan(((.MaxDCasson - .MinDCasson) / 2) / .AltCasson)
            Dim TAGLIO1 As Single = .WdesignPl * Math.Tan(ALFA)
            Dim TAGLIO2 As Single = .Wseating * Math.Tan(ALFA)
            Dim TAGLIO3 As Single = .Wtest * Math.Tan(ALFA)
            Dim TTA As Single = objBre.lbThkMinFlangiaCasson
            Dim MCON1, MCON2, MCON3 As Single
            Dim MM1, MM1I, MM1S As Single
            Dim MM2, MM2I, MM2S As Single
            Dim MMTOTSR, MMTOTSRI, MMTOTSRS As Single
            Dim MMTOT, MMTOTI, MMTOTS As Single
            Dim U1, V1 As Single
3770:       '  CONTINUE
            'C     CALCOLO DEL MOMENTO AGGIUNTIVO
            '!      MCON1=TAGLIO1*(TTA-2.*.corrcono)/2.
            '!      MCON2=TAGLIO2*(TTA/2.)
            '!      MCON3=TAGLIO3*(TTA/2.)
            MCON1 = 0
            MCON2 = 0
            MCON3 = 0
            'C     CALCOLO DEI MOMENTI
            MM1 = -.WdesignPl * BR1
            MM1I = -.Wtest * BR1
            MM1S = -.Wseating * BR1
            MM2 = .WdesignPl * BR2
            MM2I = .Wtest * BR2
            MM2S = .Wseating * BR2
            'C.....CALCOLA IL MOMENTO IN DESIGN
            MMTOTSR = Math.Abs(MM1 + MM2 + MCON1)
            'C.....CALCOLA IL MOMENTO IN TEST
            MMTOTSRI = Math.Abs(MM1I + MM2I + MCON3)
            'C.....CALCOLA IL MOMENTO IN BOLTING UP
            MMTOTSRS = Math.Abs(MM1S + MM2S + MCON2)
            'C     CALCOLA IL BOX RING COME SE FOSSE UNA FLANGIA LIBERA
            MMTOT = MMTOTSR
            MMTOTI = MMTOTSRI
            MMTOTS = MMTOTSRS
            'C     CALCOLA V1 IN CONDIZIONI CORROSE
            U1 = (.DOAnelCono - 2 * .CorrCono) / (.DIAnelCono + 2 * .CorrCono)
            Call S3290(U1, V1)
            .ThkMinFCdesign = Math.Sqrt((V1 * MMTOT) / (.DIAnelCono * .Mater(CodMAT.MAT_CASSONETTO).S)) + 2 * .CorrCono
            'C     CALCOLA V1 IN CONDIZIONI NON CORROSE
            U1 = .DOAnelCono / .DIAnelCono
            Call S3290(U1, V1)
            .ThkMinFCtest = Math.Sqrt((V1 * MMTOTI) / (.DIAnelCono * .Mater(CodMAT.MAT_CASSONETTO).SY * 0.9))
            .ThkMinFCseating = Math.Sqrt((V1 * MMTOTS) / (.DIAnelCono * .Mater(CodMAT.MAT_CASSONETTO).S0))
            If (.ThkMinFCdesign < TTA And .ThkMinFCtest < TTA And .ThkMinFCseating < TTA) Then GoTo 4060
            '!      IF( .thkminfcdesign.GT.TTA .OR. .thkminfctest.GT.TTA .OR. .thkminfcseating.GT.TTA) THEN
            TTA = TTA + 1
            GoTo 3770
            'C     CONTROLLO DEL BEARING STRESS SULL'ANELLO DOVUTO AGLI
            'C     INTERNAL SCREWS IN DESIGN
4060:       '  CONTINUE
            .Sbearingdesign = .WdesignPl / (.NumScr * .AreExtension)
            .Sbearingseating = .Wseating / (.NumScr * .AreExtension)
            .Sbearingtest = .Wtest / (.NumScr * .AreExtension)
            .VerificaBearing = 0
            If (.Sbearingdesign > (.Mater(CodMAT.MAT_INSERTO).SY) * 1.00001) Then
                .VerificaBearing = .VerificaBearing Or 1
            End If
            If (.Sbearingseating > (.Mater(CodMAT.MAT_INSERTO).SY0) * 1.00001) Then
                .VerificaBearing = .VerificaBearing Or 2
            End If
            If (.Sbearingtest > (.Mater(CodMAT.MAT_INSERTO).SY0) * 1.00001) Then
                .VerificaBearing = .VerificaBearing Or 4
            End If
            'C     SCEGLIE LO SPESSORE MASSIMO TRA .corr TRE CALCOLATI
            .ThkMinFC = TTA
        End With
    End Sub
    Private Sub Virc(ByRef ICONT As Integer)
        '     CALCOLO DELL'AREA RESISTENTE MINIMA  DEL CONO 
        With objBre
            .AreaCono = (Math.PI * (.MinDCasson + .ThkCasson - .CorrCono) - .NoApCono * .DiamApCono) * (.ThkCasson - .CorrCono)
            'C     CALCOLO DELLO SFORZO IN DESIGN,BOLTING UP ,TEST
            .ComprCdesign = .WdesignPl / .AreaCono
            .ComprCseating = .Wseating / .AreaCono
            .ComprCtest = .Wtest / .AreaCono
            ICONT = 0
            If (.ComprCdesign > .Mater(CodMAT.MAT_CASSONETTO).S) Then
                ICONT = ICONT Or 1
            End If
            If (.ComprCseating > .Mater(CodMAT.MAT_CASSONETTO).S0) Then
                ICONT = ICONT Or 2
            End If
            If (.ComprCtest > 0.9 * .Mater(CodMAT.MAT_CASSONETTO).SY0) Then
                ICONT = ICONT Or 4
            End If
            'C     CALCOLO DELLO SFORZO IN BUCKLING IN DESIGN, BOLTING-UP,TEST
            If Not modMain.optCalcolaBuckling Then Exit Sub
            objmat.Indmat = .Mater(CodMAT.MAT_CASSONETTO).IndMat
            objmat.RecupMat(Monitor.Motore.Inizio.Archdir)
            '.EulerCtemp = .Mater(CodMat.MAT_CASSONETTO).E * (.ThkCasson - .CorrCono) / (Math.Sqrt(3 * (1 - 0.3 ^ 2)) * 0.5 * .MaxDCasson)
            Acorr = 0.125 / ((.MaxDCasson + .ThkCasson) / 2 / (.ThkCasson - .CorrCono))
            .EulerCtemp = objmat.BValor(Acorr, .DesTempTS, 0, LibMat.Codes.div1MPa, Chart, 0)
            '.EulerCroom = .Mater(CodMat.MAT_CASSONETTO).E0 * .ThkCasson / (Math.Sqrt(3 * (1 - 0.3 ^ 2)) * .MaxDCasson * 0.5)
            Anew = 0.125 / ((.MaxDCasson + .ThkCasson) / 2 / .ThkCasson)
            .EulerCroom = objmat.BValor(Anew, 20, 0, LibMat.Codes.div1MPa, Chart, 0)
            If (.ComprCdesign > .EulerCtemp) Then
                ICONT = ICONT Or 8
            End If
            If (.ComprCseating > .EulerCroom) Then
                ICONT = ICONT Or 16
            End If
            If (.ComprCtest > .EulerCroom) Then
                ICONT = ICONT Or 32
            End If
        End With
    End Sub
    Private Sub ROTAZF(ByVal M3 As Single, ByVal M4 As Single, ByVal M5 As Single, ByVal D1loc As Single, ByVal D2loc As Single, ByVal Tloc As Single, ByRef IC As Integer)
        'C     ROUTINE DI CALCOLO ROTAZIONE INTERNAL RING
        'C     TEORIA:BELLUZZI PUNTO 494 FORMULA 773 PAG. 520
        Dim X1l, X2l, X3l As Single
        Dim RAD As Single = 180 / Math.PI
        With objBre
            X1l = M3 / (Math.PI * 0.5 * (D1loc + D2loc))
            X2l = M4 / (Math.PI * 0.5 * (D1loc + D2loc))
            X3l = M5 / (Math.PI * 0.5 * (D1loc + D2loc))
            .RotDes = 12 * X1l * (D2loc / 2) / (.Mater(CodMAT.MAT_PUSHRING).E * Tloc ^ 3 * Math.Log10((D2loc / D1loc))) * RAD
            .RotBolt = 12 * X2l * (D2loc / 2) / (.Mater(CodMAT.MAT_PUSHRING).E0 * Tloc ^ 3 * Math.Log10((D2loc / D1loc))) * RAD
            .RotTest = 12 * X3l * (D2loc / 2) / (.Mater(CodMAT.MAT_PUSHRING).E0 * Tloc ^ 3 * Math.Log10((D2loc / D1loc))) * RAD
            IC = 0
            If (.RotDes > 1.5) Then
                IC = IC Or 1
            End If
            If (.RotBolt > 1.5) Then
                IC = IC Or 2
            End If
            If (.RotTest > 2) Then
                IC = IC Or 4
            End If
        End With
    End Sub
    Public Sub GSKCH()
        With objBre
            Dim VecchioG2Out As Single = .G2out
            .G2out = .IDChan + 2 * (.G2dente + .G2N + .G2AnInt) + .offG2out
            If VecchioG2Out <> .G2out Then
                .OffBCextScr = 0
            End If
            'C     CALCOLA L'AMPIEZZA DI GUARNIZIONE
            .Guarn2.Width(.G2N, .B2, .NubGskChan, .G2eff, .G2out, .Formula2)
            'C     SETTA IL DIAMETRO INTERNO DEL CHANNEL
            If (.TipoBL = TipiBL.BL_HL) Then
                .CavaSplitRing = 0
            Else
                .CavaSplitRing = (.ODSplitRing + 2 * .lbRadialGap) / 2 - .IDChan / 2
            End If
            .RadiusCh = .IDChan / 2 + .CavaSplitRing
            If (.DesPresTS > 0.385 * .Mater(CodMAT.MAT_CHANNEL).S) Then
                Dim K9 As Single = (.Mater(CodMAT.MAT_CHANNEL).S + .DesPresTS) / (.Mater(CodMAT.MAT_CHANNEL).S - .DesPresTS)
                .ThkMinCh = (.RadiusCh + .CorrCh) * (Math.Sqrt(K9) - 1) + Math.Max(.CorrCh, .CavaSplitRing)
            Else
                .ThkMinCh = .DesPresTS * (.RadiusCh + .CorrCh) / (.Mater(CodMAT.MAT_CHANNEL).S - 0.6 * .DesPresTS) + Math.Max(.CorrCh, .CavaSplitRing)
            End If
        End With
    End Sub
    Friend Function WdesignVitiInt() As Single
        With objBre
            Return Max(.Wdesign + .Wadd1, .WplasticBox)
        End With
    End Function
    Friend Sub PUSHBARS()
        With objBre
            'If (.TipoBL = 0) Then Stop : TUBESHEET() ' GoTo 1150
            '4620  CONTINUE
            If (.TipoBL = TipiBL.BL_HL) Then GoTo 5020
            'viti interne
            .LarghFlex1 = (2 * .Mater(CodMAT.MAT_DIAFR).E * .SpessDiaf ^ 3 * .SpostDiaf1 / (1 - POISS ^ 2) / .DesPresTS) ^ 0.25
            .Wadd1 = Math.PI / 4 * ((.DNExtScr + .LarghFlex1) ^ 2 - (.DNExtScr - .LarghFlex1) ^ 2) * .DesPresTS
            .Sbd1 = 2 * .DesPresTS * (.LarghFlex1 / .SpessDiaf) ^ 2
            .AreqScr2 = (WdesignVitiInt()) / .Mater(CodMAT.MAT_EXTSCREWS).S '!LOADDES / F3
            Dim NRIS As Single
            If ((.AreqScr2 / .AreBltScr2) > (.AreqScr2 / (Math.PI * .DNIntPushBar2 ^ 2 / 4))) Then
                NRIS = (.AreqScr2 / .AreBltScr2)
            Else
                NRIS = (.AreqScr2 / (Math.PI * .DNIntPushBar2 ^ 2 / 4))
            End If
            NRIS = Int(NRIS) + 1
            Dim Resto As Integer = NRIS Mod 4
            .NumScr2 = NRIS
            If Resto > 0 Then .NumScr2 += 4 - Resto
            'End If
5020:       '  CONTINUE
            .LarghFlex2 = (2 * .Mater(CodMAT.MAT_DIAFR).E * .SpessDiaf ^ 3 * .SpostDiaf2 / (1 - POISS ^ 2) / .DesPresTS) ^ 0.25
            .Wadd2 = Math.PI / 4 * (.G2eff ^ 2 - (.G2eff - .LarghFlex2) ^ 2) * .DesPresTS
            .Sbd2 = 2 * .DesPresTS * (.LarghFlex2 / .SpessDiaf) ^ 2
            .WdesignCh = 2 * .B2 * Math.PI * .G2eff * .mGskChan * .DesPresTS + .Wadd2
            .WtestCh = 2 * .B2 * Math.PI * .G2eff * .mGskChan * .P2idr + .Wadd2 * .P2idr / .DesPresTS
            .WseatingCh = .B2 * Math.PI * .G2eff * .YGskChan / PSI
            .AreaReqScrPushDesign = .WdesignCh / .Mater(CodMAT.MAT_EXTSCREWS).S 'F3
            .AreaReqScrPushRoom = Math.Max(.WseatingCh, .WtestCh) / .Mater(CodMAT.MAT_EXTSCREWS).S0 ' F4
            .AreaReqScrPush = Math.Max(.AreaReqScrPushDesign, .AreaReqScrPushRoom)
            If ((.AreaReqScrPush / .AreExtScr) > (.AreaReqScrPush / (Math.PI * .DPushBars ^ 2 / 4))) Then
                NRIS = (.AreaReqScrPush / .AreExtScr)
            Else
                NRIS = (.AreaReqScrPush / (Math.PI * .DPushBars ^ 2 / 4))
            End If
            NRIS = Int(NRIS) + 1
            Resto = NRIS Mod 4
            .NExtScr = NRIS
            If Resto > 0 Then .NExtScr += 4 - Resto
        End With
    End Sub
    Public Sub InizLR8()
        Dim IndR As Integer
        With objBre
            .ODExtComprRing = Min(.BCExtScr + .DNExtScr + 10, .G2out + 2 * .G2AnExt - 4)
            If .ODExtComprRing < .BCExtScr + .DNExtScr Then
                Dim NewBC As Single = CInt(.ODExtComprRing - .DNExtScr - 1.49)
                If NewBC - .DNExtScr > .IDExtComprRing Then
                    .OffBCextScr = .BCExtScr - NewBC
                    .BCExtScr = NewBC
                    Calcolato(7) = False
                    FormApert.GuardaIndietro(8, IndR)
                Else
                    .offG2out = .BCExtScr + NewBC + 2
                    .G2out += .offG2out
                    Calcolato(7) = False
                    Calcolato(6) = False
                    FormApert.GuardaIndietro(8, IndR)
                End If
                'MessageBox.Show("bisogna aumentare g2n o ridurre bcextscr")
            End If
            .DNLockR = CSng(CInt(.ODExtComprRing + 2 * (.lbRadialGap_ExtComprRing_Thread + .Filetto.Altezza) + 0.49))
            If (.TipoBL = TipiBL.BL_HH) Then
                .ODCover = .IDInnerRing - 50
            Else
                .ODCover = .IDExtComprRing - 50
                .Wdesign = 0
                .Wseating = 0
            End If
            'If (.IDLockR <= 0 Or .IDLockR > .ODCover - 60) Then
            If (.IDShell <= 1000) Then
                .IDLockR = .BCIntScr2 - 120
            Else
                .IDLockR = .BCIntScr2 - 150
            End If
            'End If
            If (.TipoBL = TipiBL.BL_HL) Then
                If (.ODCover <= .IDLockR + 60) Then .ODCover = .IDLockR + 60
            End If
            Select Case (.OptFiletto)
                Case (0) '!ORIGINALE Stub ACME 15/16in
                    .Filetto.Passo = (15 / 16) * INC
                    'C     ALTEZZA FILETTI IN PRESA CASSA & ANELLO
                    .Filetto.Altezza = 0.3 * .Filetto.Passo
                    'C     GIOCO TRA DIAM ESTERNO FILET. ANELLO E DIAM. INTERNO FILET. CASSA
                    .Filetto.GiocoDiam = 0.02 * INC
                    'C     DIAMETRO MAX FILETTATURA ANELLO
                    .Filetto.DMaxAn = .DNLockR - 0.0468 * INC 'table 1 ANSI B1.8 (0.05p)
                    'C     DIAMETRO MAX FILETTATURA CASSA
                    .Filetto.DMaxCas = (.DNLockR + .Filetto.GiocoDiam) + 0.0624 * INC
                    'C     DIAMETRO MEDIO DEI FILETTI IN PRESA SU CASSA & ANELLO
                    .Filetto.Dmed = (.DNLockR - .Filetto.Altezza)
                    'C     DIAMETRO MINIMO DEI FILETTI SULLA CASSA
                    .Filetto.DMinCas = (.DNLockR - 2 * .Filetto.Altezza) + 0.0468 * INC
                    'C     DIAMETRO DI NOCCIOLO SULL'ANELLO
                    .Filetto.DNocAn = (.DNLockR - 2 * .Filetto.Altezza - .Filetto.GiocoDiam) - 0.07150001 * INC
                    'C     MAX SPESSORE ALLA RADICE DEL FILETTO
                    .Filetto.RootThk = 0.5331 * INC
                    'C     BRACCIO TRA IL DIAM MEDIO E IL DIAMETRO DI NOCCIOLO ANELLO
                    .Filetto.Braccio = (.Filetto.Dmed - .Filetto.DNocAn) / 2
                    '      ANGOLO DI SPOGLIA
                    .Filetto.Spoglia = 14.5
                Case (1) '!Stub ACME variabile metrico
                    'C     ALTEZZA FILETTI IN PRESA CASSA & ANELLO
                    .Filetto.Altezza = 0.3 * .Filetto.Passo
                    'C     GIOCO NOMINALE TRA DIAM ESTERNO FILET. ANELLO E DIAM. INTERNO FILET. CASSA
                    .Filetto.GiocoDiam = CInt(0.5 * .DNLockR / 790 * 10) / 10
                    'C     Tolleranza sul diametro in micron
                    .Filetto.TollDiam = TOLLER(.Filetto.Precision, .Filetto.TollDiam)
                    'C     DIAMETRO MAX FILETTATURA ANELLO
                    .Filetto.DMaxAn = .DNLockR - .Filetto.TollDiam / 1000
                    'C     DIAMETRO MAX FILETTATURA CASSA
                    .Filetto.DMaxCas = (.DNLockR + .Filetto.GiocoDiam) + .Filetto.TollDiam / 1000
                    'C     DIAMETRO MEDIO DEI FILETTI IN PRESA SU CASSA & ANELLO
                    .Filetto.Dmed = (.DNLockR - .Filetto.Altezza)
                    'C     DIAMETRO MINIMO DEI FILETTI SULLA CASSA
                    .Filetto.DMinCas = (.DNLockR - 2 * .Filetto.Altezza) + .Filetto.TollDiam / 1000
                    'C     DIAMETRO DI NOCCIOLO SULL'ANELLO
                    .Filetto.DNocAn = (.DNLockR - 2 * .Filetto.Altezza - .Filetto.GiocoDiam) - .Filetto.TollDiam / 1000
                    'C     MAX SPESSORE ALLA RADICE DEL FILETTO
                    .Filetto.RootThk = (1 - 0.4224) * .Filetto.Passo
                    'C     BRACCIO TRA IL DIAM MEDIO E IL DIAMETRO DI NOCCIOLO ANELLO
                    .Filetto.Braccio = (.Filetto.Dmed - .Filetto.DNocAn) / 2
                    '      ANGOLO DI SPOGLIA
                    .Filetto.Spoglia = 14.5
                Case (2) '!ACME variabile metrico
                    'C     ALTEZZA FILETTI IN PRESA CASSA & ANELLO
                    .Filetto.Altezza = 0.5 * .Filetto.Passo
                    'C     GIOCO NOMINALE TRA DIAM ESTERNO FILET. ANELLO E DIAM. INTERNO FILET. CASSA
                    .Filetto.GiocoDiam = CInt(0.5 * .DNLockR / 790 * 10) / 10
                    'C     DIAMETRO MAX FILETTATURA ANELLO
                    .Filetto.TollDiam = TOLLER(.Filetto.Precision, .Filetto.TollDiam)
                    .Filetto.DMaxAn = .DNLockR - .Filetto.TollDiam / 1000
                    'C     DIAMETRO MAX FILETTATURA CASSA
                    .Filetto.DMaxCas = (.DNLockR + .Filetto.GiocoDiam) + .Filetto.TollDiam / 1000
                    'C     DIAMETRO MEDIO DEI FILETTI IN PRESA SU CASSA & ANELLO
                    .Filetto.Dmed = (.DNLockR - .Filetto.Altezza)
                    'C     DIAMETRO MINIMO DEI FILETTI SULLA CASSA
                    .Filetto.DMinCas = (.DNLockR - 2 * .Filetto.Altezza) + .Filetto.TollDiam / 1000
                    'C     DIAMETRO DI NOCCIOLO SULL'ANELLO
                    .Filetto.DNocAn = (.DNLockR - 2 * .Filetto.Altezza - .Filetto.GiocoDiam) - .Filetto.TollDiam / 1000
                    'C     MAX SPESSORE ALLA RADICE DEL FILETTO
                    .Filetto.RootThk = (1 - 0.3707) * .Filetto.Passo
                    'C     BRACCIO TRA IL DIAM MEDIO E IL DIAMETRO DI NOCCIOLO ANELLO
                    .Filetto.Braccio = (.Filetto.Dmed - .Filetto.DNocAn) / 2
                    '      ANGOLO DI SPOGLIA
                    .Filetto.Spoglia = 14.5
            End Select
        End With
    End Sub
    Private Function TOLLER(ByVal ITOLL As Integer, ByVal STD As Single) As Single
        Dim TOLLUNIT() As Single = {0, 1, 1, 1, 1, 7, 10, 16}
        If (ITOLL < 8) Then
            If objBre.DNLockR < 500 Then
                TOLLER = CInt(TOLLUNIT(ITOLL) * (0.45 * objBre.DNLockR ^ 0.33 + 0.01 * objBre.DNLockR) * 1000) / 1000
            Else
                TOLLER = CInt(TOLLUNIT(ITOLL) * (0.004 * objBre.DNLockR + 2.1) * 1000) / 1000
            End If
        Else
            TOLLER = STD
        End If
    End Function
    Friend Sub LOCKRING()
        With objBre
            .TotAreaScr2 = .NumScr2 * .AreBltScr2
            .TotAreaPushBar2 = .NumScr * Math.PI * .DNIntPushBar2 ^ 2 / 4
            .AreaAdpScrews = .NExtScr * .AreExtScr
            .AreaAdpPushBars = .NExtScr * Math.PI * .DPushBars ^ 2 / 4
            .B2max = Math.Sqrt((1 - .DesPresTS / Math.Min(.Mater(CodMAT.MAT_LOCKRING).SY, .Mater(CodMAT.MAT_COVER).SY))) * .ODCover
            If (.B2max < .IDLockR) Then
                .IDLockR = Int(.B2max)
            End If
            Dim V2 As Single
            Call S3290(.Filetto.DNocAn / .IDLockR, V2)
            'C     SPINTE DELLA PRESSIONE
            Dim O3 As Single = Math.PI * (.IDExtComprRing ^ 2 - .ODCover ^ 2) * .DesPresTS / 4
            Dim O4 As Single = Math.PI * .ODCover ^ 2 * .DesPresTS / 4
            'C     CALCOLO DEI BRACCI
            Dim D3 As Single = (.Filetto.Dmed - (.IDExtComprRing + .ODCover) / 2) / 2
            Dim D4 As Single = (.Filetto.Dmed - (.ODCover + .IDLockR) / 2) / 2
            Dim E2 As Single = (.Filetto.Dmed - .BCIntScr2) / 2
            Dim E3 As Single = (.Filetto.Dmed - .BCExtScr) / 2
            'C()    ' CALCOLO DEI MOMENTI
            Dim K2 As Single = .Wseating * E2
            Dim K3 As Single = .WseatingCh * E3
            Dim H2 As Single = .Wdesign * E2
            Dim H3 As Single = .WdesignCh * E3
            Dim N3 As Single = O3 * D3
            Dim N4 As Single = O4 * D4
            Dim M6 As Single = (H2 + H3 + N3 + N4)
            Dim M7 As Single = (K2 + K3)
            'C     CALCOLO DELLO SPESSORE .thkreqirdesign
            .ThkMinLRoperating = Math.Sqrt(V2 * M6 / (.IDLockR * .Mater(CodMAT.MAT_LOCKRING).S))
            .ThkMinLRroom = Math.Sqrt(V2 * M7 / (.IDLockR * .Mater(CodMAT.MAT_LOCKRING).S0))
            .ThkMinLR = Math.Max(.ThkMinLRoperating, .ThkMinLRroom) 'Min.Req.Lock Ring Thickness 
            If (.ThkAdpLR < CInt(.ThkMinLR + 1.49)) Then .ThkAdpLR = CInt(.ThkMinLR + 1.49)
            .NmaxFilettiPoss = Int(.ThkAdpLR / .Filetto.Passo)
            .BearStressLR = .DesPresTS * .ODCover ^ 2 / (.ODCover ^ 2 - .IDLockR ^ 2)
            'C     CALCOLA LA SPINTA TOTALE SULLA FILETTATURA
            .WdesignThr = 2 * .B2 * Math.PI * .G2eff * .mGskChan * .DesPresTS + PI * .G2eff ^ 2 * .DesPresTS / 4 + .WdesignPl
            .WtestThr = 2 * .B2 * Math.PI * .G2eff * .mGskChan * .P2idr + PI * .G2eff ^ 2 * .P2idr / 4
            .WseatingThr = .WseatingCh
            .DiamIntGola = CSng(CInt(.Filetto.DMaxCas + 2 * .lbProfCavaThreadedEnd + 0.49))
            .WaccidentThr = 2 * .B2 * Math.PI * .G2eff * .mGskChan * .DesPresTS + PI * .Filetto.Dmed ^ 2 * .DesPresTS / 4 + .WdesignPl
            ' INIZIALIZZAZIONI
            .ThrEndReqLength = .NmaxFilettiPoss * .Filetto.Passo
            If .ThrEndMinThk = 0 Then .ThrEndMinThk = 100
            .ODChanFilettato = CInt(.DiamIntGola + (2 * .ThrEndMinThk) + 1)
            Dim S3, S4, Pm, Pmb, dummy, VecchioSpessore As Single
            If DiamAugmDesign = 0 Then DiamAugmDesign = .Filetto.DMinCas
            If BraccioAugmDesign = 0 Then BraccioAugmDesign = .Filetto.Braccio
            If DiamAugmAccident = 0 Then DiamAugmAccident = .Filetto.DMinCas
            If BraccioAugmAccident = 0 Then BraccioAugmAccident = .Filetto.Braccio
            Do
                ' CALCOLO AUMENTI DIAMETRO CASSA FILETTATA
                'Call DESENG(.Filetto.DMaxCas, .WdesignThr, 0, .ThrEndReqLength, (.ODChanFilettato - .Filetto.DMaxCas) / 2, .Filetto.Dmed, D, E, H1, B, M0, .deltaRChanNormal)
                'Call DESENG(.Filetto.DMaxCas, .WaccidentThr, .DesPresTS, .ThrEndReqLength, (.ODChanFilettato - .Filetto.DMaxCas) / 2, .Filetto.Dmed, D, E, H1, B, M0, .deltaRChanAccident)
                'C     CALCOLA IL NUMERO MINIMO DI FILETTI A TAGLIO, A FLESSIONE & A BEARING
                '.deltaRChan = DESENG()
                Call FilettiRichiesti(BraccioAugmDesign, DiamAugmDesign, _
                                      BraccioAugmAccident, DiamAugmAccident, .NreqFiletti)
                CalcolaThread()
                .ThrEndReqLength = .NreqFiletti * .Filetto.Passo
                'C     SETTA LO SPESSORE DEL CHANNEL
                'If .ThrEndAdpLength = 0 Then .ThrEndAdpLength = .ThrEndReqLength 'ATTENZIONE: AGGIUNTO
                .ThrEndReqThkDesign = 25
6930:           .ThrEndReqThkDesign += 5
                'Call S7790(.Filetto.DMaxCas, .WdesignThr, 0, .ThrEndReqLength, .ThrEndReqThkDesign, _
                '           .Filetto.Dmed, D, E, H1, B, M0, S3, S4, Pm, Pmb)
                Call NuovoCalcolo(.Filetto.DMaxCas, .WdesignThr, 0, .ThrEndReqLength, _
                          .ThrEndReqThkDesign, .Filetto.Dmed, .NmaxFiletti, S3, S4, Pm, Pmb, .deltaRChanNormal)
                If (Pm > .Mater(CodMAT.MAT_LOCKRING).S) Then GoTo 6930
                If (Pmb > .Mater(CodMAT.MAT_LOCKRING).S * 1.5) Then GoTo 6930
                DiamAugmDesign = .Filetto.DMinCas + 2 * (.deltaRChanNormal + .DeltaT)
                BraccioAugmDesign = .Filetto.Braccio + (.deltaRChanNormal + .DeltaT) / 2
                .ThrEndReqThkAccident = 25
6931:           .ThrEndReqThkAccident += 5
                'Call S7790(.Filetto.DMaxCas, .WaccidentThr, .DesPresTS, .ThrEndReqLength, _
                '           .ThrEndReqThkAccident, .Filetto.Dmed, D, E, H1, B, M0, S3, S4, Pm, Pmb)
                Call NuovoCalcolo(.Filetto.DMaxCas, .WaccidentThr, .DesPresTS, .ThrEndReqLength, _
                           .ThrEndReqThkAccident, .Filetto.Dmed, .NmaxFiletti, S3, S4, Pm, Pmb, .deltaRChanAccident)
                If Pm > .AmmissAccident Then GoTo 6931
                If Pmb > .AmmissAccident * 1.5 Then GoTo 6931
                DiamAugmAccident = .Filetto.DMinCas + 2 * (.deltaRChanAccident + .DeltaT)
                BraccioAugmAccident = .Filetto.Braccio + (.deltaRChanAccident + .DeltaT) / 2
                .ThrEndReqThkSeating = 25
7010:           .ThrEndReqThkSeating += 5
                'Call S7790(.Filetto.DMaxCas, .WseatingThr, 0, .ThrEndReqLength, .ThrEndReqThkSeating, _
                '           .Filetto.Dmed, D, E, H1, B, M0, S3, S4, Pm, Pmb)
                Call NuovoCalcolo(.Filetto.DMaxCas, .WseatingThr, 0, .ThrEndReqLength, .ThrEndReqThkSeating, _
                           .Filetto.Dmed, .NmaxFiletti, S3, S4, Pm, Pmb, dummy)
                If (Pm > .Mater(CodMAT.MAT_LOCKRING).S0) Then GoTo 7010
                If (Pmb > .Mater(CodMAT.MAT_LOCKRING).S0) Then GoTo 7010
                .ThrEndMinThk = GlobalRoutines.Massimo(.ThrEndReqThkAccident, .ThrEndReqThkDesign, .ThrEndReqThkSeating)
                If VecchioSpessore = .ThrEndMinThk Then Exit Do
                VecchioSpessore = .ThrEndMinThk
            Loop
            '            If .ThrAdpMinThk < .ThrEndMinThk Then .ThrAdpMinThk = Int(.ThrEndMinThk + 0.49)
            .ThrAdpMinThk = .ThrEndMinThk
            LOCKRINGfinal()
        End With
    End Sub
    Private Sub CalcolaThread()
        With objBre
            .EngagedDesign = (.Filetto.DMaxAn - DiamAugmDesign) / 2
            .EngagedAccident = (.Filetto.DMaxAn - DiamAugmAccident) / 2
            .ThrBendingDesign = 6 * .WdesignThr * BraccioAugmDesign / (.NreqFiletti * Math.PI * .Filetto.DNocAn * .Filetto.RootThk ^ 2)
            .ThrBendingAccident = 6 * .WaccidentThr * BraccioAugmAccident / (.NreqFiletti * Math.PI * .Filetto.DNocAn * .Filetto.RootThk ^ 2)
            .ThrBendingSeating = 6 * .WseatingThr * .Filetto.Braccio / (.NreqFiletti * Math.PI * .Filetto.DNocAn * .Filetto.RootThk ^ 2)
            .ThrShearDesign = .WdesignThr / (.NreqFiletti * Math.PI * .Filetto.DNocAn * .Filetto.RootThk)
            .ThrShearAccident = .WaccidentThr / (.NreqFiletti * Math.PI * .Filetto.DNocAn * .Filetto.RootThk)
            .ThrShearSeating = .WseatingThr / (.NreqFiletti * Math.PI * .Filetto.DNocAn * .Filetto.RootThk)
            .ThrBearingDesign = 4 * .WdesignThr / (.NreqFiletti * Math.PI * (.Filetto.DMaxAn ^ 2 - DiamAugmDesign ^ 2))
            .ThrBearingAccident = 4 * .WaccidentThr / (.NreqFiletti * Math.PI * (.Filetto.DMaxAn ^ 2 - DiamAugmAccident ^ 2))
            .ThrBearingSeating = 4 * .WseatingThr / (.NreqFiletti * Math.PI * (.Filetto.DMaxAn ^ 2 - .Filetto.DMinCas ^ 2))
        End With
    End Sub
    Private Sub LOCKRINGfinal()
        ' Dim D, H1, B, M0
        Dim dummy As Single
        With objBre
            'C     CALCOLA IL DIAMETRO ESTERNO NELLA ZONA FILETTATA
            .ODChanFilettato = CInt(.DiamIntGola + 2 * .ThrAdpMinThk)
            'C     CALCOLA IL DIAMETRO ESTERNO NELLA ZONA LONTANA DALLA FILETTATURA
            .ODChanNonFilettato = CInt(.IDChan + .ThkAdpCh * 2 + 0.49)
            If .ODChanNonFilettato > .ODChanFilettato Then
                Dim Res As RoutBase1.ChiaviMess = MostraAiuto(1028, RoutBase1.ChiaviMess.MessYesNoCancel Or RoutBase1.ChiaviMess.MessHelpButton Or RoutBase1.ChiaviMess.MessQuestion)
                Select Case Res
                    Case RoutBase1.ChiaviMess.MessCancel
                        Exit Sub
                    Case RoutBase1.ChiaviMess.MessSi
                        .ODChanNonFilettato = CInt(.IDChan + .ThkMinCh * 2 + 0.49)
                End Select
            End If
            'C     CONTROLLA QUALE DIAMETRO E' IL MAGGIORE E RICALCOLA LO SPESSORE DEL CHANNEL
            If (.ODChanFilettato > .ODChanNonFilettato) Then
                .ODChanRequired = .ODChanFilettato
                .ThkAdpCh = (.ODChanRequired - .IDChan) * 0.5
            ElseIf .ODChanFilettato = .ODChanNonFilettato Then
            Else
                .ODChanRequired = .ODChanNonFilettato
                .ThkAdpCh = (.ODChanRequired - .IDChan) * 0.5
            End If
            'C     RICALCOLA LO SPESSORE DEL CHANNEL
            .ThrAdpMinThk = Int((.ODChanRequired - .Filetto.DMaxCas) / 2.0 + 0.49)
            'C     CALCOLA GLI SFORZI SULLA CASSA IN OPERATING
            'Call S7790(.Filetto.DMaxCas, .WdesignThr, 0, .ThrEndReqLength, .ThrAdpMinThk, .Filetto.Dmed, _
            '           D, E, H1, B, M0, .SChanLongMemb, .ThrEndLongStress, Pm, Pmb)
            Call NuovoCalcolo(.Filetto.DMaxCas, .WdesignThr, 0, .ThrEndReqLength, .ThrAdpMinThk, .Filetto.Dmed, _
                       .NmaxFiletti, .SChanLongMemb, .SChanLongBend, .ThrEndPm, .ThrEndLongStress, .deltaRChanNormal)
            ' .SChanLongBend = .ThrEndLongStress - .SChanLongMemb
            DiamAugmDesign = .Filetto.DMinCas + 2 * (.deltaRChanNormal + .DeltaT)
            BraccioAugmDesign = .Filetto.Braccio + (.deltaRChanNormal + .DeltaT) / 2
            'Call S7790(.Filetto.DMaxCas, .WseatingThr, 0, .ThrEndReqLength, .ThrAdpMinThk, .Filetto.Dmed, _
            '           D, E, H1, B, M0, .SChanLongMembSeating, .ThrEndLongStressSeating, Pm, Pmb)
            Call NuovoCalcolo(.Filetto.DMaxCas, .WseatingThr, 0, .ThrEndReqLength, .ThrAdpMinThk, .Filetto.Dmed, _
                       .NmaxFiletti, .SChanLongMembSeating, .SChanLongBendSeating, .ThrEndPm, .ThrEndLongStressSeating, dummy)
            '.SChanLongBendSeating = .ThrEndLongStressSeating - .SChanLongMembSeating
            'Call S7790(.Filetto.DMaxCas, .WaccidentThr, .DesPresTS, .ThrEndReqLength, .ThrAdpMinThk, _
            '           .Filetto.Dmed, D, E, H1, B, M0, .SChanLongMembAccident, .ThrEndLongStressAccident, .ThrEndPm, .ThrEndPmb)
            Call NuovoCalcolo(.Filetto.DMaxCas, .WaccidentThr, .DesPresTS, .ThrEndReqLength, .ThrAdpMinThk, _
                       .Filetto.Dmed, .NmaxFiletti, .SChanLongMembAccident, .SChanLongBendAccident, _
                       .ThrEndPm, .ThrEndLongStressAccident, .deltaRChanAccident)
            DiamAugmAccident = .Filetto.DMinCas + 2 * (.deltaRChanAccident + .DeltaT)
            BraccioAugmAccident = .Filetto.Braccio + (.deltaRChanAccident + .DeltaT) / 2
            CalcolaThread()
            Dim G7 As Single = 0.6 * .Mater(CodMAT.MAT_COVER).S
            Dim C7 As Single = 0.3
            .ThkMinCv = .ODCover * Math.Sqrt(C7 * .DesPresTS / .Mater(CodMAT.MAT_COVER).S)
            'C     CALCOLA LO SPESSORE MINIMO A TAGLIO
            Dim J7 As Single = .DesPresTS * .ODCover ^ 2 / (1.2 * .Mater(CodMAT.MAT_COVER).S * (.IDLockR + .ODCover))
            'C     CALCOLA LO SPESSORE MINIMO A FLESSIONE
            Dim K4 As Single = (.Mater(CodMAT.MAT_COVER).S * (.IDLockR + .ODCover) / (.DesPresTS * .ODCover ^ 2)) ^ 2
            Dim K5 As Single = 0.75
            Dim K6 As Single = 0.5625 * (.ODCover - .IDLockR) ^ 2
            Dim K7 As Single = Math.Sqrt((K5 + Math.Sqrt(K5 ^ 2 + 4 * K4 * K6)) / (2 * K4))
            Dim thkb As Single = Sqrt(6 / 4 * .DesPresTS / (1.5 * .Mater(CodMAT.MAT_COVER).S) * (.ODCover - .IDLockR) / 2 * .ODCover)
            .ExtCrwMinThk = Math.Max(J7, K7)

        End With
    End Sub
    Private Sub FilettiRichiesti(ByVal BraccioAugmDesign As Single, ByVal DiamAugmDesign As Single, _
                                 ByVal BraccioAugmAccident As Single, ByVal DiamAugmAccident As Single, ByRef n As Integer)
        With objBre
            If .SuperSafe Then .AmmissAccident = .Mater(CodMAT.MAT_LOCKRING).S Else .AmmissAccident = 0.9 * .Mater(CodMAT.MAT_LOCKRING).SY
            Dim NreqTaglioDesignFiletti As Single = .WdesignThr / (0.6 * .Mater(CodMAT.MAT_LOCKRING).S * PI * .Filetto.DNocAn * .Filetto.RootThk)
            Dim NreqTaglioAccidentFiletti As Single = .WaccidentThr / (0.6 * .AmmissAccident * PI * .Filetto.DNocAn * .Filetto.RootThk)
            Dim NreqTaglioTestFiletti As Single = .WtestThr / (0.6 * .Mater(CodMAT.MAT_LOCKRING).S0 * PI * .Filetto.DNocAn * .Filetto.RootThk)
            Dim NreqTaglioSeatingFiletti As Single = .WseatingThr / (0.6 * .Mater(CodMAT.MAT_LOCKRING).S0 * PI * .Filetto.DNocAn * .Filetto.RootThk)
            Dim NreqBendingDesignFiletti As Single = 6 * BraccioAugmDesign / .Filetto.RootThk ^ 2 * .WdesignThr / (.Mater(CodMAT.MAT_LOCKRING).S * PI * .Filetto.DNocAn)
            Dim NreqBendingAccidentFiletti As Single = 6 * BraccioAugmAccident / .Filetto.RootThk ^ 2 * .WaccidentThr / (.AmmissAccident * PI * .Filetto.DNocAn)
            Dim NreqBendingTestFiletti As Single = 6 * .Filetto.Braccio / .Filetto.RootThk ^ 2 * .WtestThr / (.Mater(CodMAT.MAT_LOCKRING).S0 * PI * .Filetto.DNocAn)
            Dim NreqBendingSeatingFiletti As Single = 6 * .Filetto.Braccio / .Filetto.RootThk ^ 2 * .WseatingThr / (.Mater(CodMAT.MAT_LOCKRING).S0 * PI * .Filetto.DNocAn)
            Dim NreqBearingDesignFiletti As Single = 4 * .WdesignThr / (.Mater(CodMAT.MAT_LOCKRING).SY * PI * (.Filetto.DMaxAn ^ 2 - DiamAugmDesign ^ 2))
            Dim NreqBearingAccidentFiletti As Single = 4 * .WaccidentThr / (.Mater(CodMAT.MAT_LOCKRING).SY * PI * (.Filetto.DMaxAn ^ 2 - DiamAugmAccident ^ 2))
            Dim NreqBearingTestFiletti As Single = 4 * .WtestThr / (.Mater(CodMAT.MAT_LOCKRING).SY0 * PI * (.Filetto.DMaxAn ^ 2 - .Filetto.DMinCas ^ 2))
            Dim NreqBearingSeatingFiletti As Single = 4 * .WseatingThr / (.Mater(CodMAT.MAT_LOCKRING).SY0 * Math.PI * (.Filetto.DMaxAn ^ 2 - .Filetto.DMinCas ^ 2))
            n = CInt(GlobalRoutines.Massimo( _
                                                       NreqBendingDesignFiletti, _
                                                       NreqBendingAccidentFiletti, _
                                                       NreqBendingTestFiletti, _
                                                       NreqBendingSeatingFiletti, _
                                                       NreqBearingDesignFiletti, _
                                                       NreqBearingAccidentFiletti, _
                                                       NreqBearingTestFiletti, _
                                                       NreqBearingSeatingFiletti, _
                                                       NreqTaglioDesignFiletti, _
                                                       NreqTaglioAccidentFiletti, _
                                                       NreqTaglioSeatingFiletti, _
                                                       NreqTaglioTestFiletti)) + 1
        End With
    End Sub

    Private Sub DESENG(ByVal DiamInt As Single, ByVal W0 As Single, ByVal p As Single, ByVal Lunghezza As Single, ByVal Spessore As Single, _
                      ByRef DmedFiletto As Single, ByRef DiamExt As Single, ByRef Braccio As Single, ByRef SpessoreInGola As Single, _
                      ByRef Beta As Single, ByRef M0 As Single, _
                      ByRef delta As Single)
        DiamExt = DiamInt + 2 * Spessore
        Braccio = ((DiamInt + DiamExt) / 2 - DmedFiletto) / 2
        SpessoreInGola = Spessore - objBre.lbProfCavaThreadedEnd
        Beta = Sqrt(Sqrt(3 * (1 - POISS ^ 2) / (DiamInt ^ 2 * Spessore ^ 2)))
        Dim x As Single = Beta * Lunghezza
        Dim D As Single = objBre.Mater(CodMAT.MAT_CHANNEL).E * Spessore ^ 3 / 12 / (1 - POISS ^ 2)
        delta = W0 * Braccio / (PI * (DiamExt + DiamInt) / 2) / 2 / Beta ^ 2 / D * Exp(-x) * Sin(x) / x
        If p > 0 Then
            Dim Y As Single = DiamExt / DiamInt
            Dim ScircM As Single = p * (1 + (DiamInt / (DiamInt + Spessore)) ^ 2) / (Y ^ 2 - 1)
            delta += DiamInt / 2 * ScircM / objBre.Mater(CodMAT.MAT_CHANNEL).E
        End If
    End Sub
    Private Function DESENGold() As Single
        Dim B, BETA, ALFA, RM, MODloc, SPESS, DIAM, MOM As Single
        'C------------------------------
        MODloc = objBre.Mater(CodMAT.MAT_CHANNEL).E * 1000000.0
        SPESS = objBre.ThkAdpCh / 1000
        DIAM = objBre.DNLockR / 1000
        B = MODloc * SPESS ^ 3 / 12 / (1 - POISS ^ 2)
        RM = (DIAM + SPESS) / 2
        BETA = MODloc * SPESS / RM ^ 2
        ALFA = (BETA / 4 / B) ^ 0.25
        MOM = objBre.WdesignThr * SPESS / 2 / (2 * Math.PI * RM)
        Dim DELTAM1 As Single = 2 * ALFA ^ 2 / BETA * MOM * 1000
        Dim DELTAM2 As Single = objBre.DesPresTS * RM / objBre.Mater(CodMAT.MAT_CHANNEL).E / SPESS * RM * 1000
        DESENGold = DELTAM1 + DELTAM2
    End Function
    Private Sub S7790(ByVal DiamInt As Single, ByVal W0 As Single, ByVal p As Single, ByVal Lunghezza As Single, ByVal Spessore As Single, _
                      ByRef DmedFiletto As Single, ByRef DiamExt As Single, ByRef Braccio As Single, ByRef SpessoreInGola As Single, _
                      ByRef Beta As Single, ByRef M0 As Single, _
                      ByRef SlongM As Single, ByRef SlongMB As Single, ByRef Pm As Single, ByRef Pmb As Single)
        '-----------------------------------------------
        DiamExt = DiamInt + 2 * Spessore
        Braccio = ((DiamInt + DiamExt) / 2 - DmedFiletto) / 2
        SpessoreInGola = Spessore - objBre.lbProfCavaThreadedEnd
        Beta = Sqrt(Sqrt(3 * (1 - POISS ^ 2) / (DiamInt ^ 2 * Spessore ^ 2)))
        Dim x As Single = Beta * Lunghezza
        M0 = W0 * Braccio / (PI * (DiamExt + DiamInt) / 2) * (1 - Exp(-x) * Cos(x)) / x
        SlongM = 4 * W0 / (PI * (DiamExt ^ 2 - objBre.DiamIntGola ^ 2))
        SlongMB = SlongM + 6 * M0 / SpessoreInGola ^ 2
        If p = 0 Then
            Pm = SlongM
            Pmb = SlongMB
        Else
            Dim Y As Single = DiamExt / objBre.DiamIntGola
            Dim ScircM As Single = p * (1 + (DiamInt / (objBre.DiamIntGola + SpessoreInGola)) ^ 2) / (Y ^ 2 - 1)
            Dim ScircMB As Single = p * (Y ^ 2 + 1) / (Y ^ 2 - 1)
            Dim SradM As Single = -p / 2
            Dim SradMB As Single = -p
            Pm = GlobalRoutines.Massimo(Abs(SlongM - ScircM), Abs(SlongM - SradM), Abs(ScircM - SradM))
            Pmb = GlobalRoutines.Massimo(Abs(SlongMB - ScircMB), Abs(SlongMB - SradMB), Abs(ScircMB - SradMB))
        End If
    End Sub
    Private Sub S7790old(ByRef DiamInt As Single, ByRef W0 As Single, ByRef Lunghezza As Single, ByRef Spessore As Single, _
                      ByRef DmedFiletto As Single, ByRef DiamExt As Single, ByRef E As Single, ByRef H1 As Single, _
                      ByRef M As Single, ByRef R As Single, ByRef B As Single, ByRef M0 As Single, _
                      ByRef S3 As Single, ByRef S4 As Single, ByRef S5 As Single)
        'DiamInt-----------------------------------------------
        DiamExt = DiamInt + Spessore
        E = (DiamInt + DiamExt - DmedFiletto) / 2
        H1 = Spessore - 4.5
        M = W0 * E
        R = M / (Math.PI * (DiamExt ^ 2 - DiamInt ^ 2))
        B = Math.Sqrt(Math.Sqrt(3 * (1 - POISS ^ 2) / (DiamInt ^ 2 * H1 ^ 2)))
        M0 = R * (DiamExt - DiamInt) / (1 + (B * Lunghezza / 2) + ((1 - POISS ^ 2) / (2 * B * DiamInt)) * (Lunghezza / H1) ^ 3 * Math.Log(DiamExt / DiamInt))
        S3 = 4 * W0 / (Math.PI * (DiamExt ^ 2 - (DiamInt + 4.5) ^ 2))
        S4 = 6 * M0 / H1 ^ 2
        S5 = S3 + S4
    End Sub
    Friend Sub FINALE()
        With objBre
            .ExtCrwShear = 0.5 * .DesPresTS * .ODCover ^ 2 / ((.IDLockR + .ODCover) * .ExtCrwAdpThk)
            .ExtCrwMembrane = 0.75 * .DesPresTS * (.ODCover - .IDLockR) * .ODCover ^ 2 / ((.IDLockR + .ODCover) * .ExtCrwAdpThk ^ 2)
            .ExtCrwSideal = Math.Sqrt(.ExtCrwMembrane ^ 2 + 3 * .ExtCrwShear ^ 2) 'Allowable Equivalent Stress
            .ExtCrwBearing = .DesPresTS * .ODCover ^ 2 / (.ODCover ^ 2 - .IDLockR ^ 2) 'Ext.Crown Bearing Stress
        End With
    End Sub
    Friend Function STAMPAS(ByVal FromASMEVIP As Boolean) As Boolean
        Dim Conto As Integer = 0
        Dim NumeriPagine As Boolean = True
        If FromASMEVIP Then
            NumeriPagine = False
            Conto = 1
        Else
            FileStampa = IO.Path.GetDirectoryName(nomefile) & "\" & IO.Path.GetFileNameWithoutExtension(nomefile) & "BRE.DOC"
            Monitor.Motore.Problem.Doc = IO.Path.GetFileNameWithoutExtension(nomefile)
1:          If Not Monitor.Motore.PrepRapp(FileStampa) Then Return False
        End If
        Monitor.Motore.Testata(NumeraPagine:=NumeriPagine)
        Select Case objBre.iStampa
            Case 1 : STP(FromASMEVIP)
            Case 2 : STPASM()
            Case 3
                Call STP(FromASMEVIP)
                Monitor.Motore.Problem.FileStream.Write("\page ")
                Monitor.Motore.Testata(NumeraPagine:=NumeriPagine)
                Call STPASM()
        End Select
        If Conto = 1 Then Return True
        Monitor.Motore.Problem.FineRapp()
        IO.File.Delete(FileStampa)
        Monitor.Motore.Problem.pagtot = Monitor.Motore.Problem.pag
7:      Conto = 1
        GoTo 1
    End Function
    Friend Sub STP(ByVal DaAsme As Boolean)
        Dim Formato As String
        Dim Chapter As Integer
        Dim p As RoutBase1.clsProblem = Monitor.Motore.Problem
        Try
            With objBre
                If (.TipoBL = TipiBL.BL_HL) Then
                    Formato = FormatStringa(3)
                Else
                    Formato = FormatStringa(1)
                End If
                p.Printa(String.Format(Formato, ""))
                Formato = FormatStringa(2)
                p.Printa(String.Format(Formato, "", _
                    .DesTempSS, _
                    .DesTempTS, _
                    Math.Max(.DesTempSS, .DesTempTS), _
                    .DesPresSS, .DesPresTS))
                If (.TipoBL = TipiBL.BL_HL) Then GoTo 8350
                Formato = FormatStringa(4)
                p.Printa(String.Format(Formato, "", _
                        .DiffPres, .EffDiff, .DiffPresHT, _
                        .Gasket, .G1out, .G1N, .Nubbin, _
                        .G1eff, .B1, .m, .Y / PSI))
8350:           Formato = FormatStringa(5)
                p.Printa(String.Format(Formato, "", _
                        .GskChan, .G2out, .G2N, _
                        .NubGskChan, .G2eff, .B2, .mGskChan, .YGskChan / PSI))
                Formato = FormatStringa(60)
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_DIAFR).Mat, .Mater(CodMAT.MAT_DIAFR).E, .SpessDiaf, .SpostDiaf1, _
                        .SpostDiaf2, .LarghFlex1, .LarghFlex2, _
                        .Wadd1, .Wadd2, .Sbd1, .Sbd2))
                Formato = FormatStringa(61)
                p.Printa(String.Format(Formato, "", _
                        Risposta(2 - .Ipres), Risposta(.Considera + 1), _
                        Risposta(2 + CInt(.SuperSafe))))
                If (.TipoBL = TipiBL.BL_HL) Then GoTo 8880
                Monitor.Motore.Testata(NumeraPagine:=Not DaAsme)
                If DaAsme Then GoTo 9131
                Formato = FormatStringa(6)  '1 - SHELL
                Chapter += 1
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_SHELL).Mat, .Mater(CodMAT.MAT_SHELL).S, _
                        .IDShell, .CorrSh, .ThkMinSh, .ThkAdpSh, Chapter))
                Formato = FormatStringa(7)  '2 - HEAD
                If Not .NonCalcolaFondo Then
                    Chapter += 1
                    p.Printa(String.Format(Formato, "", _
                            .Mater(CodMAT.MAT_FONDO).Mat, .Mater(CodMAT.MAT_FONDO).S, _
                            .HemRadius, .CorrSh, .ThkMinHe, .ThkAdpHe, Chapter))
                End If
8880:           Formato = FormatStringa(8)  '3 - Tubesheet
                Chapter += 1
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(10)
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_TS).Mat, .TubeDout, .Passo, .iPasso, _
                        .Mater(CodMAT.MAT_TS).S, .Mater(CodMAT.MAT_TS).S0, .CorrTSCh, .CorrTSSh, .Cava))
                If (.TipoBL = TipiBL.BL_HL) Then GoTo 9130
                Formato = FormatStringa(11)
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_TUBI).Mat, .Mater(CodMAT.MAT_TUBI).S, .Mater(CodMAT.MAT_TUBI).S0))
9130:           Formato = FormatStringa(12)
                p.Printa(String.Format(Formato, "", _
                        .ThkMinTS, .ThkAdpTS))
                If (.TipoBL = TipiBL.BL_HL) Then GoTo 10670
9131:           Formato = FormatStringa(13) '4 - internal screws
                Chapter += 1
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_INTSCREWS).Mat, .Mater(CodMAT.MAT_INTSCREWS).S, .Mater(CodMAT.MAT_INTSCREWS).S0, _
                        .Mater(CodMAT.MAT_INTSCREWS).SY, .Mater(CodMAT.MAT_INTSCREWS).SY0, _
                        .DNStr1, .DNIntScr, _
                        .BCIntScr, .AreBltScr, .AreExtension, _
                        .NumScr, .Wdesign, .Wseating, .Wtest, Chapter))
                Formato = FormatStringa(14)
                p.Printa(String.Format(Formato, "", _
                        .AreqScrDesign, .AreqScrSeating, .AReqScrTest, .AreqScr, _
                        .AactScr, .WplasticBox))
                Monitor.Motore.Testata(NumeraPagine:=Not DaAsme)
                Formato = FormatStringa(51) '5 internal ring & split rring
                Chapter += 1
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_SPLITRING).Mat, .Mater(CodMAT.MAT_SPLITRING).S, .Mater(CodMAT.MAT_SPLITRING).S0, _
                        .Mater(CodMAT.MAT_SPLITRING).SY, .Mater(CodMAT.MAT_SPLITRING).SY0, _
                        .Mater(CodMAT.MAT_PUSHRING).Mat, .Mater(CodMAT.MAT_PUSHRING).S, _
                        .Mater(CodMAT.MAT_PUSHRING).S0, Chapter))
                Formato = FormatStringa(15)
                p.Printa(String.Format(Formato, "", _
                        .Mater(CodMAT.MAT_PUSHRING).SY, .Mater(CodMAT.MAT_PUSHRING).SY0, 0.9 * .Mater(CodMAT.MAT_PUSHRING).SY, _
                        .IDSplitRing, .ODSplitRing, .IDInnerRing, .ODInnerRing))
                Formato = FormatStringa(44)
                p.Printa(String.Format(Formato, "", _
                        .ThkAdpSplitRing, .S1shearSR, 0.6 * .Mater(CodMAT.MAT_SPLITRING).S, _
                        .S2shearSR, 0.6 * .Mater(CodMAT.MAT_SPLITRING).S0, _
                        .SoshearSR, 0.6 * 0.67 * .Mater(CodMAT.MAT_SPLITRING).SY0, _
                        .S1shearSR, .Mater(CodMAT.MAT_SPLITRING).SY, .S2bearSR, _
                        .Mater(CodMAT.MAT_SPLITRING).SY0, Chapter))
                Formato = FormatStringa(45)
                p.Printa(String.Format(Formato, "", _
                      .SobearSR, .Mater(CodMAT.MAT_SPLITRING).SY0, _
                      .ThkReqIRdesign, .ThkReqIRseating, .ThkReqIRtest, _
                      .ThkReqInnerRing, .ThkAdpInnerRing, _
                      .S1bearSR, .Mater(CodMAT.MAT_PUSHRING).SY, _
                      .S2bearSR, .Mater(CodMAT.MAT_PUSHRING).SY0, _
                      .SobearSR, .Mater(CodMAT.MAT_PUSHRING).SY0))
                'perché SR?
                Monitor.Motore.Testata(NumeraPagine:=Not DaAsme)
                Formato = FormatStringa(49)
                p.Printa(String.Format(Formato, "", _
                      .Mater(CodMAT.MAT_FL_CASSON).Mat, .Mater(CodMAT.MAT_FL_CASSON).S, .Mater(CodMAT.MAT_FL_CASSON).S0, .Mater(CodMAT.MAT_FL_CASSON).SY, _
                      .DOAnelCono, .DIAnelCono, _
                      .ThkMinFCdesign, .ThkMinFCseating, .ThkMinFCtest, .ThkAdpFC, Chapter))
                Formato = FormatStringa(42)
                p.Printa(String.Format(Formato, "", _
                      .Mater(CodMAT.MAT_CASSONETTO).Mat, .Mater(CodMAT.MAT_CASSONETTO).E, .Mater(CodMAT.MAT_CASSONETTO).E0, _
                      .ThkCasson, .MaxDCasson, .MinDCasson, _
                      .MDLocCono, .Mater(CodMAT.MAT_CASSONETTO).S, .Mater(CodMAT.MAT_CASSONETTO).S0, _
                      .Mater(CodMAT.MAT_CASSONETTO).SY0, 0.9 * .Mater(CodMAT.MAT_CASSONETTO).SY0, _
                      .DiamApCono, CInt(.NoApCono), .AltCasson, Chapter))
                Formato = FormatStringa(43)
                p.Printa(String.Format(Formato, "", _
                      .AreaCono, .ComprCdesign, .ComprCseating, .ComprCtest))
                If modMain.optCalcolaBuckling Then
                    Formato = FormatStringa(62)
                    p.Printa(String.Format(Formato, "", _
                                          .EulerCtemp, .EulerCroom, Chart, Anew, Acorr))
                End If
                '  If (.BOXD <> 0 Or .BOXS <> 0 Or .BOXI <> 0) Then
                Formato = FormatStringa(50)
                'If (.Considera = 0) Then p.Printa(String.Format(Formato, "", _
                '    .WplasticBox, .WplasticBox, .WplasticBox))
                '!-----------6.- CHANNEL BARREL-------
10670:          If (.TipoBL <> TipiBL.BL_HL) Then Monitor.Motore.Testata(NumeraPagine:=Not DaAsme)
                If Not DaAsme Then
                    Formato = FormatStringa(46)
                    Chapter += 1
                    p.Printa(String.Format(Formato, "", Chapter))
                    Formato = FormatStringa(47)
                    p.Printa(String.Format(Formato, "", .Mater(CodMAT.MAT_CHANNEL).Mat, _
                          .Mater(CodMAT.MAT_CHANNEL).S, .RadiusCh, .CorrCh))
                    Formato = FormatStringa(48)
                    p.Printa(String.Format(Formato, "", .ThkMinCh, .ThkAdpCh))
                End If
                Chapter += 1
                Formato = FormatStringa(17)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(18)
                p.Printa(String.Format(Formato, "", _
                      .Mater(CodMAT.MAT_EXTSCREWS).Mat, .Mater(CodMAT.MAT_EXTSCREWS).S, _
                      .Mater(CodMAT.MAT_EXTSCREWS).S0, .IDExtComprRing))
                If (.TipoBL = TipiBL.BL_HL) Then GoTo 11690
                Formato = FormatStringa(19)
                p.Printa(String.Format(Formato, "", _
                .DNStr2, .DNBltScr2, _
                         .BCIntScr2, .AreBltScr2, .DNIntPushBar2, _
                         .NumScr2, WdesignVitiInt, .AreqScr2, _
                         .TotAreaScr2, .TotAreaPushBar2, Chapter))
11690:          Formato = FormatStringa(20)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(22)
                p.Printa(String.Format(Formato, "", _
                .DNStr3, .DNExtScr, _
                     .BCExtScr, .AreExtScr, .DPushBars, _
                     .NExtScr, .WdesignCh, .WseatingCh, _
                     .AreaReqScrPushDesign, .AreaReqScrPushRoom, _
                     .AreaReqScrPush, .AreaAdpScrews, .AreaAdpPushBars))
                Formato = FormatStringa(23)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(25)
                p.Printa(String.Format(Formato, "", _
                      .Mater(CodMAT.MAT_LOCKRING).Mat, .Mater(CodMAT.MAT_LOCKRING).S, .Mater(CodMAT.MAT_LOCKRING).S0, _
                      .Mater(CodMAT.MAT_LOCKRING).SY, .Mater(CodMAT.MAT_LOCKRING).SY0, .DNLockR))
                'C----------Geometria filetto
                Select Case .OptFiletto
                    Case 0
                        Formato = FormatStringa(21)
                    Case 1
                        Formato = FormatStringa(26)
                    Case 2
                        Formato = FormatStringa(27)
                End Select
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(28)
                p.Printa(String.Format(Formato, "", _
                      .Filetto.Passo, .Filetto.Altezza, _
                      .Filetto.RootThk, .Filetto.GiocoDiam, .Filetto.GiocoDiam, _
                      .Filetto.DMaxAn, .Filetto.DMaxCas, _
                      .Filetto.Dmed, .Filetto.DMinCas, .Filetto.DNocAn))
                'C--------------------------------
                Monitor.Motore.Testata(NumeraPagine:=Not DaAsme)
                Formato = FormatStringa(29)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(30)
                p.Printa(String.Format(Formato, "", _
                      .IDLockR, .ODCover, _
                      .ThkMinLRoperating, .ThkMinLRroom, _
                      .ThkMinLR, .ThkAdpLR, .BearStressLR, .Mater(CodMAT.MAT_LOCKRING).SY))
                Formato = FormatStringa(31)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(32)
                p.Printa(String.Format(Formato, "", _
                      .NmaxFiletti, .ThrShearDesign, 0.6 * .Mater(CodMAT.MAT_LOCKRING).S, _
                      .ThrBendingDesign, 0, .Mater(CodMAT.MAT_LOCKRING).S))
                Formato = FormatStringa(33)
                p.Printa(String.Format(Formato, "", _
                      .ThrBearingDesign, .Mater(CodMAT.MAT_LOCKRING).SY, _
                      .ThrShearSeating, 0.6 * .Mater(CodMAT.MAT_LOCKRING).S0, _
                      .ThrBendingSeating, 0, _
                      .Mater(CodMAT.MAT_LOCKRING).S0, .ThrBearingSeating, .Mater(CodMAT.MAT_LOCKRING).SY0))
                Formato = FormatStringa(34)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(35)
                p.Printa(String.Format(Formato, "", _
                .ThrEndReqLength, .ThrAdpMinThk, .ODChanRequired, _
                .SChanLongMemb, .Mater(CodMAT.MAT_LOCKRING).S, _
                .SChanLongBend, .ThrEndLongStress, 1.5 * .Mater(CodMAT.MAT_LOCKRING).S, _
                .SChanLongMembSeating, .Mater(CodMAT.MAT_LOCKRING).S0, _
                .SChanLongBendSeating, .ThrEndLongStressSeating, 1.5 * .Mater(CodMAT.MAT_LOCKRING).S0))
                If .SuperSafe Then Formato = FormatStringa(64) Else Formato = FormatStringa(63)
                p.Printa(String.Format(Formato, "", _
                .SChanLongMembAccident, .AmmissAccident, _
                .SChanLongBendAccident, .ThrEndLongStressAccident, 1.5 * .AmmissAccident))
                Monitor.Motore.Testata(NumeraPagine:=Not DaAsme)
                Formato = FormatStringa(52)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(53)
                p.Printa(String.Format(Formato, ""))
                Formato = FormatStringa(54)
                p.Printa(String.Format(Formato, "", .Filetto.TollDiam / 1000))
                Formato = FormatStringa(55)
                p.Printa(String.Format(Formato, ""))
                Formato = FormatStringa(56)
                p.Printa(String.Format(Formato, "", .deltaRChanNormal, .deltaRChanAccident))
                If (.DeltaT > 0) Then
                    Formato = FormatStringa(57)
                    p.Printa(String.Format(Formato, ""))
                    Formato = FormatStringa(58)
                    p.Printa(String.Format(Formato, "", .TempTransLR, .TempTransCh, .DeltaT))
                End If
                Formato = FormatStringa(59)
                p.Printa(String.Format(Formato, "", .EngagedDesign, .EngagedAccident))
                'C--------Channel flat cover--------- 
                Formato = FormatStringa(36)
                Chapter += 1
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(37)
                p.Printa(String.Format(Formato, "", .Mater(CodMAT.MAT_COVER).Mat, _
                                                    .Mater(CodMAT.MAT_COVER).S, _
                                                    .Mater(CodMAT.MAT_COVER).S0))
                Formato = FormatStringa(38)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(39)
                p.Printa(String.Format(Formato, "", _
                       .ThkMinCv, .ThkAdpCv))
                Formato = FormatStringa(40)
                p.Printa(String.Format(Formato, "", Chapter))
                Formato = FormatStringa(41)
                p.Printa(String.Format(Formato, "", _
                      .ExtCrwAdpThk, .ExtCrwShear, 0.6 * .Mater(CodMAT.MAT_COVER).S, _
                      .ExtCrwMembrane, .ExtCrwSideal, .Mater(CodMAT.MAT_COVER).S, _
                      .ExtCrwBearing, .Mater(CodMAT.MAT_COVER).S0))
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Friend Sub STPASM()

    End Sub
    Public Function FormatStringa(ByVal id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "stop" + GlobalRoutines.Str3Cifre(id)
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr '.Replace("|", vbCrLf)
    End Function
    Public Function HelpStringa(ByVal id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "str" + GlobalRoutines.Str5Cifre(id)
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr.Replace("|", vbCrLf)
    End Function
    Public Function Getlb(ByVal nome As String, ByVal ID As Single) As Single
        Dim Valore As Single
        With Monitor.Motore.Inizio
            Dim file As String = .Archdir + "\Brelb.ini"
            Dim colSection(1) As String
            Dim n As Integer = .ReadProfileSection(file, nome, colSection)
            If n = 1 Then
                Valore = GlobalRoutines.ValVir(colSection(0))
            Else
                Dim i As Integer
                For i = 0 To n - 1 Step 2
                    If ID < CSng(colSection(i)) Then Exit For
                Next
                Valore = GlobalRoutines.ValVir(colSection(i + 1))
            End If
            If Valore = 0 Then
                MostraAiuto(1026, , HelpStringa(1026) + " " + nome)
            End If
            Return Valore
        End With
    End Function
    Public Sub NuovoCalcolo(ByVal DiamInt As Single, ByVal W0 As Single, ByVal p As Single, ByVal Lunghezza As Single, ByVal Spessore As Single, _
                      ByVal DmedFiletto As Single, ByVal nDenti As Integer, _
                      ByRef SlongM As Single, ByRef SlongMB As Single, ByRef Pm As Single, _
                      ByRef Pmb As Single, ByRef SpostInCima As Single)
        Dim i As Integer
        Dim l As Single
        Dim F11, F12, F13, F14 As Single
        Dim det, det1, a11, a12, a13, a21, a22, a23 As Single
        Dim DiamExt As Single = DiamInt + 2 * Spessore
        Dim Braccio As Single = ((DiamInt + DiamExt) / 2 - DmedFiletto) / 2
        Dim SpessoreInGola As Single = Spessore - objBre.lbProfCavaThreadedEnd
        Dim Beta As Single = Sqrt(Sqrt(3 * (1 - POISS ^ 2) / (DiamInt ^ 2 * Spessore ^ 2)))
        Dim D As Single = objBre.Mater(CodMAT.MAT_CHANNEL).E * Spessore ^ 3 / 12 / (1 - POISS ^ 2)
        If nDenti = 0 Then nDenti = 10
        Dim Mm As Single = W0 * Braccio / (PI * (DiamExt + DiamInt) / 2) / nDenti
        Dim q, m1, m2 As Single ' iperstatiche normalizzate alla sezione del dente i
        Dim M0, MomInBasso As Single
        SpostInCima = 0
        MomInBasso = 0
        For i = 1 To nDenti
            l = i / nDenti * Lunghezza
            Call Funzioni4231(Beta * l, F11, F12, F13, F14)
            det = 2 * F11 * F13 - F12 ^ 2
            a11 = (F12 * F14 - 2 * F13 ^ 2) / det - 1 ' + 1
            a12 = -2 * (F11 * F12 + F13 * F14) / det
            a13 = -2 ' 2
            a21 = (F12 * F13 - F11 * F14) / det - 1
            a22 = (2 * F11 ^ 2 + F12 * F14) / det
            a23 = -1
            det1 = a11 * (a22 - a23) - a21 * (a12 - a13)
            q = (-a13 * (a22 - a23) + a23 * (a12 - a13)) / det1 * Mm / (2 * Beta ^ 2 * D)
            m1 = (-a11 * a23 + a21 * a13) / det1 * Mm / (2 * Beta ^ 2 * D)
            m2 = Mm / (2 * Beta ^ 2 * D) - m1
            Dim xBasso As Single = Beta * (Lunghezza - l)
            MomInBasso += m2 * (Exp(-xBasso) * (Cos(xBasso) + Sin(xBasso)))
            Dim t1 As Single = q + 2 * m2
            Dim w1 As Single = q + m2
            SpostInCima += -q * F11 - m1 * F12 + t1 * F13 + w1 * F14
        Next
        M0 = MomInBasso * 2 * Beta ^ 2 * D
        SlongM = 4 * W0 / (PI * (DiamExt ^ 2 - objBre.DiamIntGola ^ 2))
        SlongMB = SlongM + 6 * M0 / SpessoreInGola ^ 2
        If p = 0 Then
            Pm = SlongM
            Pmb = SlongMB
        Else
            Dim Y As Single = DiamExt / objBre.DiamIntGola
            Dim ScircM As Single = p * (1 + (DiamInt / (objBre.DiamIntGola + SpessoreInGola)) ^ 2) / (Y ^ 2 - 1)
            Dim ScircMB As Single = p * (Y ^ 2 + 1) / (Y ^ 2 - 1)
            Dim SradM As Single = -p / 2
            Dim SradMB As Single = -p
            Pm = GlobalRoutines.Massimo(Abs(SlongM - ScircM), Abs(SlongM - SradM), Abs(ScircM - SradM))
            Pmb = GlobalRoutines.Massimo(Abs(SlongMB - ScircMB), Abs(SlongMB - SradMB), Abs(ScircMB - SradMB))
            Y = DiamExt / DiamInt
            ScircM = p * (1 + (DiamInt / (DiamInt + Spessore)) ^ 2) / (Y ^ 2 - 1)
            SpostInCima += DiamInt / 2 * ScircM / objBre.Mater(CodMAT.MAT_CHANNEL).E
        End If
    End Sub
    Private Sub Funzioni4231(ByVal x As Single, ByRef F11 As Single, ByRef F12 As Single, ByRef F13 As Single, ByRef F14 As Single)
        F11 = (Cosh(x) * Sin(x) - Sinh(x) * Cos(x)) / 2
        F12 = Sinh(x) * Sin(x)
        F13 = (Cosh(x) * Sin(x) + Sinh(x) * Cos(x)) / 2
        F14 = Cosh(x) * Cos(x)
    End Sub
End Module
