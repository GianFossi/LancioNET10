Option Strict Off
Option Explicit On 
Imports RoutBase1
Imports System.IO
Imports System.Windows.Forms.Application
Module mainWrcb
    Public Const IDH_ERR_BADSERIAL As Integer = 2022
    Public Const IDH_ERR_LCYLZERO As Integer = 3000
    Public Const IDH_ERR_CAPNONSCELTO As Integer = 3001
    '-----------------------------------------------------
    Public RadiceHelp As String
    Friend globalRoutines As RoutBase1.clsTrigon
    Public myAssembly As System.Reflection.Assembly
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public job As RoutBase1.clsjob
    Public NoRules As Boolean
    Public Interrompi As Boolean
    Public capitoli As Collection
    Public FileStPr As String
    Public Stub As StubW2000.clsSW2000
    Public Template As String
    Public Carta, Csv As String
    Public kk As Short
    Public Valor(6, 31) As Single
    Public DN(31) As String
    Public Factor(7) As Single
    Public Gia297() As Boolean
    Public Risp297 As Integer
    Public objWRCB As clsWrcb
    Public DatProg As RoutBase1.clsDatiDes.typDatiDes
    Public iB, iC As Short
    Public indice As Short
    Public SI As Single
    Public aggFinestra As Boolean
    Public DMX, EX, E0, DM0 As Single
    Public WCM, WCV, TCV, TCM As Single
    Public RPRA, SPRA, ZPRA, ZPRB, SPRB, RPRB As Single
    Public TWVA, TWTA, SWMA, SWFA, SWFB, SWMB, TWTB, TWVB As Single
    Public TTVA, TTTA, STMA, STFA, STFB, STMB, TTTB, TTVB As Single
    Public ifllib As Short
    Public RJ As Single
    Public S5, S3, S21, S11, S12, S22, S4, S6 As Single
    Public TTT2, Z6, Z4, Z22, Z12, Z11, Z21, Z3, Z5, TTT1, TTT3 As Single
    Public POC, PML, PMC, PMR, PIC As Single
    Public PMCbrut, PMLbrut As Single
    Public POR, POL, PIL, PIR As Single
    Public GG1, RHO1, U2, U0, U, U1, RHO, RHO2, GG2 As Single
    Public GAMMA, GG, BETA As Single
    Public SW As Short
    Public HHH, BETA1, BETA2, KKK As Single
    Public E5, E1, V, W, E2, E6 As Single
    Public EEE As String
    Public K5, KKK1, KKK2, K6 As Single
    Public K7, KKK3, K4, K8 As Single
    Public C3, C1, C2, C4 As Single
    Public Suffix As String
    'Public Result(1 To 2, 25, 6) As typResult, Resultv(1 To 2, 25, 6) As typResult
    Public Result(,,) As typResult
    Public Resultv(,,) As typResult
    Public ShellNoz As Short
    Public ModifiedData As Boolean
    Public RHO354, CTrsT, trsTr, dsD As Single
    Public dmean, TBocch, Tsh, RBocch As Single
    Public SopraSotto(4) As Short
    Public IntersLoc() As RoutBase1.clsVec3
    Public FileSt As String
    Public Apparecchio As Grafica.clsApparecchio
    Public Monitor As clsMonitor
    Public AddDistinta As Short
    Public Geom() As typGeom
    Public Config As wrcConfig
    Public wrcbB(16) As Single
    Public wrcC(4, 4) As Single
    Public wrcG(9) As Single
    Public wrcL(4, 4) As Single
    Public wrcM(31, 6) As Single
    Public wrcN(2, 15, 8) As Single
    Public wrcO(2, 24, 8) As Single
    Public aaa(9) As Single
    Public bbb(9) As Single
    Public wrcU(38) As Single
    Public SV(12) As Short
    Public KRead(12) As Single
    Public rrr(10) As Short
    Public HRead(12) As Single
    Public Matdim() As LibMat.MaterialeNew1
    '   Public StressLim(25, 4) As typStressLim, Fact() As Single, Factk() As Single
    Public StressLim(,) As typStressLim
    Public Fact() As Single
    Public Factk() As Single
    Public Const INC As Single = 25.4
    Public Const PI As Single = 3.14159265
    Public Const MPA As Single = 0.006894757
    Public Const PSI As Single = 145.0377439
    Public Const GRAV As Single = 9.80655
    Public Const NIUT As Single = 4.448222
    'Dim Stringa1$(12), Classedim(6) As Integer, SopraSotto(1 To 4) As Integer
    'Dim Stringa(25) As String, Risult$(25), LungStr(25) As Integer, Strin$(100)
    'Dim Rec2Buf(4) As RecAPR, DatProg As DatiDes
    Public RR, TT As Single
    Private Vc, AML, AMc, AMt, Vl As Single
    Private EndEffect As Single
    Private Y As Single
    Private UM, UI, UO As Single
    Private ZM, ZI, ZO As Single
    Private Res, iFirst As Boolean
    Private Factkv As Single
    Private i, nex As Short
    Private Factv As Single
    Private Factkn, Fcorr As Single
    Private Ind As Short
    Private Testo As String
    Private VerbosSav As Short
    Sub EsenzStress(ByRef nn As Short, ByRef jmemb As Short, ByRef R As Single, ByRef SWR As Single, ByRef iExempt As Short, ByRef Aspp As Single, ByRef i As Short, ByRef TempF As Single)
    End Sub
    Sub CalcStress()
        Try
            RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
            TT = Geom(iB).T0 : If Geom(iB).TX > TT Then TT = Geom(iB).TX
            Call Compos(EndEffect, AMc, AML, AMt, Vc, Vl)
            If Config.WRC297 >= 3 And Not (Geom(iB).ShellType = 1 And Config.WRC297 = 4 And Geom(iB).Buco = 1) Then
110:            Call Calc297()
            ElseIf Geom(iB).ShellType = 1 And Config.WRC297 = 4 And Geom(iB).Buco = 1 Then
                AMc = System.Math.Sqrt(AMc * AMc + AML * AML) : AML = 0
                S12 = KRead(4) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'Nè/(P/Rm)
                S11 = S12
                S22 = KRead(2) * (6 * EndEffect / Geom(iB).T ^ 2) 'Mè/P
                S21 = S22
                S3 = KRead(4) * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
                S4 = KRead(2) * 6 * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
                S5 = 0
                S6 = 0
                Z11 = KRead(3) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'Nx/(P/Rm)
                Z12 = Z11
                Z21 = KRead(1) * (6 * EndEffect / Geom(iB).T ^ 2) 'Mx/P
                Z22 = Z21
                Z3 = KRead(3) * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
                Z4 = KRead(1) * 6 * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
                S5 = 0
                S6 = 0
            ElseIf Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
120:            S11 = KRead(10) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'nt P
                S12 = S11
                S21 = KRead(7) * (6 * EndEffect / Geom(iB).T ^ 2) 'mt P
                S22 = S21
                S3 = KRead(11) * (AMc / (2 * RR * Geom(iB).T ^ 2))
                S4 = KRead(8) * 6 * (AMc / (2 * RR * Geom(iB).T ^ 2))
                S5 = KRead(12) * (AML / (2 * RR * Geom(iB).T ^ 2))
                S6 = KRead(9) * 6 * (AML / (2 * RR * Geom(iB).T ^ 2))
                Z11 = KRead(4) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'nr P
                Z12 = Z11
                Z22 = KRead(1) * (6 * EndEffect / Geom(iB).T ^ 2) 'mr P
                Z21 = Z22
                Z3 = KRead(5) * (AMc / (2 * RR * Geom(iB).T ^ 2))
                Z4 = KRead(2) * 6 * (AMc / (2 * RR * Geom(iB).T ^ 2))
                Z5 = KRead(6) * (AML / (2 * RR * Geom(iB).T ^ 2))
                Z6 = KRead(3) * 6 * (AML / (2 * RR * Geom(iB).T ^ 2))
            Else
9500:           S11 = KRead(7) * (EndEffect / (Geom(iB).RM * Geom(iB).T)) 'Nx/(P/Rm)
9510:           S12 = KRead(1) * (EndEffect / (Geom(iB).RM * Geom(iB).T)) 'Nè/(P/Rm)
9520:           S21 = KRead(8) * (6 * EndEffect / Geom(iB).T ^ 2) 'Mx/P
9530:           S22 = KRead(2) * (6 * EndEffect / Geom(iB).T ^ 2) 'Mè/P
9540:           S3 = KRead(3) * (AMc / (Geom(iB).RM ^ 2 * aaa(2) * Geom(iB).T)) * C1
9550:           S4 = KRead(4) * (6 * AMc / (Geom(iB).RM * aaa(3) * Geom(iB).T ^ 2))
9560:           S5 = KRead(5) * (AML / (Geom(iB).RM ^ 2 * aaa(4) * Geom(iB).T)) * C2
9570:           S6 = KRead(6) * (6 * AML / (Geom(iB).RM * aaa(5) * Geom(iB).T ^ 2))
9580:           Z11 = KRead(1) * (EndEffect / (Geom(iB).RM * Geom(iB).T))
9590:           Z12 = KRead(7) * (EndEffect / (Geom(iB).RM * Geom(iB).T))
9600:           Z21 = KRead(2) * (6 * EndEffect / Geom(iB).T ^ 2)
9610:           Z22 = KRead(8) * (6 * EndEffect / Geom(iB).T ^ 2)
9620:           Z3 = KRead(9) * (AMc / (Geom(iB).RM ^ 2 * aaa(2) * Geom(iB).T)) * C3
9630:           Z4 = KRead(10) * (6 * AMc / (Geom(iB).RM * aaa(8) * Geom(iB).T ^ 2))
9640:           Z5 = KRead(11) * (AML / (Geom(iB).RM ^ 2 * aaa(4) * Geom(iB).T)) * C4
9650:           Z6 = KRead(12) * (6 * AML / (Geom(iB).RM * aaa(9) * Geom(iB).T ^ 2))
            End If '.
9660:       If Geom(iB).Forma > 0 Then GoTo 9710
9670:       TTT1 = AMt / (2 * PI * RR ^ 2 * Geom(iB).T)
9680:       TTT2 = Vc / (PI * RR * Geom(iB).T)
9690:       TTT3 = Vl / (PI * RR * Geom(iB).T)
9700:       GoTo 10500
9710:       TTT1 = 2 * AMt / (PI * Geom(iB).D1 * Geom(iB).D2 * Geom(iB).T)
9720:       TTT2 = 2 * Vc / (Geom(iB).D1 * Geom(iB).T)
9730:       TTT3 = 2 * Vl / (Geom(iB).D2 * Geom(iB).T)
10500:      Y = (Geom(iB).RO / Geom(iB).RI)
10510:      UI = 1
10520:      UM = (Geom(iB).RI / Geom(iB).R)
10530:      UO = (Geom(iB).RI / Geom(iB).RO)
10540:      ZI = (Geom(iB).RO / Geom(iB).RI)
10550:      ZM = (Geom(iB).RO / Geom(iB).R)
10560:      ZO = 1
10570:      If Geom(iB).Carichi(iC).DesPress > 0 Then
10580:          PIC = Geom(iB).Carichi(iC).DesPress * (1 + ZI ^ 2) / (Y ^ 2 - 1)
10590:          PMC = Geom(iB).Carichi(iC).DesPress * (1 + ZM ^ 2) / (Y ^ 2 - 1)
10600:          POC = Geom(iB).Carichi(iC).DesPress * (1 + ZO ^ 2) / (Y ^ 2 - 1)
10610:          PIL = Geom(iB).Carichi(iC).DesPress / (Y ^ 2 - 1)
10620:          PML = Geom(iB).Carichi(iC).DesPress / (Y ^ 2 - 1)
10630:          POL = Geom(iB).Carichi(iC).DesPress / (Y ^ 2 - 1)
10640:          PIR = Geom(iB).Carichi(iC).DesPress * (1 - ZI ^ 2) / (Y ^ 2 - 1)
10650:          PMR = Geom(iB).Carichi(iC).DesPress * (1 - ZM ^ 2) / (Y ^ 2 - 1)
10660:          POR = Geom(iB).Carichi(iC).DesPress * (1 - ZO ^ 2) / (Y ^ 2 - 1)
            Else
10680:          PIC = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 + UI ^ 2) / (Y ^ 2 - 1))
10690:          PMC = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 + UM ^ 2) / (Y ^ 2 - 1))
10700:          POC = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 + UO ^ 2) / (Y ^ 2 - 1))
10710:          PIL = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * (1 / (Y ^ 2 - 1))
10720:          PML = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * (1 / (Y ^ 2 - 1))
10730:          POL = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * (1 / (Y ^ 2 - 1))
10740:          PIR = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 - UI ^ 2) / (Y ^ 2 - 1))
10750:          PMR = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 - UM ^ 2) / (Y ^ 2 - 1))
10760:          POR = Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 - UO ^ 2) / (Y ^ 2 - 1))
            End If '-
            If Config.WRC297 > 2 And Not (Geom(iB).ShellType = 1 And Config.WRC297 = 4 And Geom(iB).Buco = 1) Then Call CC19(iB, iC)
            '  non può mai essere .Shell=1 perché di qui si passa solo con i cilindri
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub CalcStress2()
        Dim AreaA, AreaS As Single
        Dim RI, RO As Single
        Try
            RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
            TT = Geom(iB).T0 : If Geom(iB).TX > TT Then TT = Geom(iB).TX
            AreaA = PI * (RR ^ 2 - (RR - TT + Geom(iB).CorrN) ^ 2)
            AreaS = PI * (RR ^ 4 - (RR - TT + Geom(iB).CorrN) ^ 4) / 4 / RR
            Call Compos(EndEffect, AMc, AML, AMt, Vc, Vl)
            S11 = KRead(10) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'nt P
            S12 = S11
            S21 = 0
            S22 = S21
            S3 = KRead(11) * (AMc / (2 * RR * Geom(iB).T ^ 2))
            S4 = 0
            S5 = KRead(12) * (AMc / (2 * RR * Geom(iB).T ^ 2))
            S6 = 0
            Z11 = EndEffect / AreaA
            Z12 = Z11
            Z22 = (6 * KRead(1) - 3 * KRead(4)) * EndEffect / (TT - Geom(iB).CorrN) ^ 2 'mr P
            Z21 = Z22
            Z3 = AMc / AreaS
            Z4 = (6 * KRead(2) - 3 * KRead(5)) * AMc / (TT - Geom(iB).CorrN) ^ 2 / 2 / RR
            Z5 = AML / AreaS
            Z6 = (6 * KRead(4) - 3 * KRead(6)) * AML / (TT - Geom(iB).CorrN) ^ 2 / 2 / RR
            TTT1 = AMt / (2 * PI * RR ^ 2 * (TT - Geom(iB).CorrN))
            TTT2 = Vc / (PI * RR * (TT - Geom(iB).CorrN))
            TTT3 = Vl / (PI * RR * (TT - Geom(iB).CorrN))
            RO = RR
            RI = RO - TT + Geom(iB).CorrN
            RBocch = (RO + RI) / 2
            Y = RO / RI
            UI = 1
            UM = RI / RBocch
            UO = RI / RO
            ZI = RO / RI
            ZM = RO / RBocch
            ZO = 1
            If Geom(iB).Carichi(iC).DesPress < 0 Then GoTo 10681
            PIC = CSng(Geom(iB).Carichi(iC).DesPress * (1 + ZI ^ 2) / (Y ^ 2 - 1))
            PMC = CSng(Geom(iB).Carichi(iC).DesPress * (1 + ZM ^ 2) / (Y ^ 2 - 1))
            POC = CSng(Geom(iB).Carichi(iC).DesPress * (1 + ZO ^ 2) / (Y ^ 2 - 1))
            PIL = CSng(Geom(iB).Carichi(iC).DesPress / (Y ^ 2 - 1))
            PML = CSng(Geom(iB).Carichi(iC).DesPress / (Y ^ 2 - 1))
            POL = CSng(Geom(iB).Carichi(iC).DesPress / (Y ^ 2 - 1))
            PIR = CSng(Geom(iB).Carichi(iC).DesPress * (1 - ZI ^ 2) / (Y ^ 2 - 1))
            PMR = CSng(Geom(iB).Carichi(iC).DesPress * (1 - ZM ^ 2) / (Y ^ 2 - 1))
            POR = CSng(Geom(iB).Carichi(iC).DesPress * (1 - ZO ^ 2) / (Y ^ 2 - 1))
            Exit Sub
10681:      PIC = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 + UI ^ 2) / (Y ^ 2 - 1)))
            PMC = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 + UM ^ 2) / (Y ^ 2 - 1)))
            POC = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 + UO ^ 2) / (Y ^ 2 - 1)))
            PIL = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * (1 / (Y ^ 2 - 1)))
            PML = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * (1 / (Y ^ 2 - 1)))
            POL = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * (1 / (Y ^ 2 - 1)))
            PIR = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 - UI ^ 2) / (Y ^ 2 - 1)))
            PMR = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 - UM ^ 2) / (Y ^ 2 - 1)))
            POR = CSng(Geom(iB).Carichi(iC).DesPress * Y ^ 2 * ((1 - UO ^ 2) / (Y ^ 2 - 1)))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub CC19(ByRef iB As Short, ByRef iC As Short)
        Dim c, y1 As Single
        Dim icount As Short
        Dim Para1, Para2 As Single
        Dim xxx2, xxx1, CTrsT2 As Single
        Dim CTrsT1 As Single
        Dim FileFig As String
        Try
            If ShellNoz = 1 And Geom(iB).Buco = 0 Then
2000:           If dsD > 0.2 Then 'fig.3.5.4(4)
                    Y = TBocch / 2 / RBocch * System.Math.Sqrt(2 * dmean / Tsh)
                    If Y > 1.4 Then
                        c = 1.0!
                    Else
2010:                   c = 2 : icount = 0
                        Do
                            icount = icount + 1
                            y1 = Y354(c)
                            c = c + (Y - y1) / Y354D(c)
2020:                       If c < 1 Then c = 1
                            If System.Math.Abs(Y - y1) < 0.001 Then Exit Do
                            If icount > 500 Then
                                MsgBox("loop in CC19")
                            End If '1
                        Loop
                    End If '2
                    CTrsT = c
                End If '3
2030:           If dsD < 0.3 Then
                    FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BS354.DAT"
2040:               Call globalRoutines.LegFig(FileFig, RHO354, trsTr, Para1, Para2, xxx1, xxx2, 3)
                    CTrsT2 = xxx1 + (xxx2 - xxx1) * (RHO354 - Para1) / (Para2 - Para1)
                End If '4
                If dsD < 0.2 Then
                    CTrsT = CTrsT2
                ElseIf dsD > 0.3 Then
                Else
2050:               CTrsT1 = CTrsT
                    CTrsT = CTrsT1 + 10 * (dsD - 0.2) * (CTrsT2 - CTrsT1)
                End If '5
                If CTrsT < 1 Then CTrsT = 1
                PMC = 2.25 / 1.1 * CTrsT * Geom(iB).Carichi(iC).DesPress * dmean / 2 / Tsh
                PML = PMC
2060:           PMR = 0
                PMCbrut = PMC / 2.25 * 1.1 / CTrsT
                PMLbrut = PMCbrut / 2
            Else
2070:           PMC = Geom(iB).Carichi(iC).DesPress * dmean / 2 / (Geom(iB).T - Geom(iB).Corr)
                PML = PMC / 2
                PMR = 0
                PMCbrut = PMC
                PMLbrut = PML
            End If '7
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub ConfigString()
1450:   If Config.UnitSis = 0 Then
1460:       Config.Unit(1) = "[mm]    "
1470:       Config.Unit(2) = "[N*mm]  "
1480:       Config.Unit(3) = "[N]     "
1490:       Config.Unit(4) = "[-]     "
1500:       Config.Unit(5) = "[MPa]   "
1510:       Config.Unit(6) = "[MPa]   "
1520:       Config.Unit(7) = "[{\super 0}C]    "
            Config.Unit(0) = "[°C]"
1540:   ElseIf Config.UnitSis = 1 Then
1550:       Config.Unit(1) = "[mm]    "
1560:       Config.Unit(2) = "[Kg*mm] "
1570:       Config.Unit(3) = "[Kg]    "
1580:       Config.Unit(4) = "[-]     "
1590:       Config.Unit(5) = "[Kg/mm{\super 2}]" ': IF TipoStam = 3 THEN Config.Unit(5) = "[Kg/mm{\super 2}]"
1600:       Config.Unit(6) = Config.Unit(5)
1610:       Config.Unit(7) = "[{\super 0}C]    "
            Config.Unit(0) = "[°C]"
1620:   Else
1630:       Config.Unit(1) = "[mm]    "
1640:       Config.Unit(2) = "[lb*in] "
1650:       Config.Unit(3) = "[lb]    "
1660:       Config.Unit(4) = "[-]     "
1670:       Config.Unit(5) = "[psi]   "
1680:       Config.Unit(6) = "[ksi]   "
1690:       Config.Unit(7) = "[{\super 0}F]    "
            Config.Unit(0) = "[°F]"
        End If '9
    End Sub
    Function Esegui(ByVal iBocch As Short) As Boolean
        Try
            Esegui = True
3611:       If iBocch = 0 Then If Not StamSumm() Then Exit Function
            ShellNoz = 1
            VerbosSav = Config.Verbose
            Config.Verbose = 0
            For iB = 1 To Config.NBocch
                Fact(iB) = 0 : Factk(iB) = 1
                If Not Geom(iB).Incluso = 0 Then
                    If Not GeomCalc() Then Esegui = False : Exit Function
                End If
            Next iB
            Config.Verbose = VerbosSav
            For iB = 1 To Config.NBocch
                If Not Geom(iB).Incluso = 0 Then
                    Call CalcolaParametri()
                    If Res And Config.WRC297 > 2 And Geom(iB).ShellType = 0 Then Call Prossimi()
                    NoRules = False
                End If
            Next iB
            If iBocch = 0 Then
                For iB = 1 To Config.NBocch
                    ShellNoz = 1
                    If Not (Geom(iB).Incluso = 0) Then
                        Call HyperCalcola()
                        NoRules = False
                    End If
                Next iB
            Else
                iB = iBocch
                ShellNoz = 1
                Call HyperCalcola()
            End If
            iB = iBocch
1651:       If iBocch = 0 Then Call StamSummF()
            '1652 IF AddDistinta > 0 THEN    CALL Risultante
            iB = iBocch
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Function SuperCalcola() As Boolean
Rig:    If Not GeomCalc() Then Return False
        CalcolaParametri()
        If Res Then If Not Calcola() Then Return False
1653:   If Res And Config.WRC297 >= 3 And ShellNoz = 1 And Geom(iB).Rinforzo <> 0 And Geom(iB).ShellType = 0 Then ShellNoz = 2 : GoTo Rig
        Return True
    End Function
    Private Sub HyperCalcola()
        iFirst = True
        Factkv = Factk(iB)
        Call SuperCalcola()
1656:   For i = 1 To 2 : For iC = 1 To 6
                Resultv(i, iC, iB) = Result(i, iC, iB) : Next
        Next i
        If NoRules Then Return
        iFirst = False
        Factv = Fact(iB)
        Factk(iB) = 1 / Fact(iB)
        Fact(iB) = 0
        Call SuperCalcola()
        nex = 1
        Do
            If (Factv - 1) * (Fact(iB) - 1) < 0 Then
                Factkn = (Factkv + Factk(iB)) / 2
            Else
                If Fact(iB) <> Factv Then
                    Fcorr = (Factk(iB) - Factkv) / (Fact(iB) - Factv) * (Factv - 1)
                Else
                    Exit Do
                End If
                If Fcorr > Factkv Then Fcorr = Factv / 2
                Factkn = Factkv - Fcorr
            End If
            Factkv = Factk(iB) : Factk(iB) = Factkn : Factv = Fact(iB)
            Fact(iB) = 0
            Call SuperCalcola()
            nex = nex + 1
        Loop While System.Math.Abs(Fact(iB) - 1) > 0.01 And nex < 50
    End Sub
    Private Function Calcola() As Boolean
        Calcola = True
        If Geom(iB).Casi = 0 Then
            MessageBox.Show("Il bocchello " & Geom(iB).Mark.Trim & " non ha casi di carico", "WRCB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        For iC = 1 To Geom(iB).Casi
            If iFirst Then Call SubStressLim()
3380:       If Config.Analisi = 2 Then GoTo 15010
3401:       If Geom(iB).ShellType = 0 Then 'cilindri
3411:           If iC = 1 Then If Not SuperLeg() Then Return False
3412:           Call CalcStress()
3416:           Call CalcwrcN()
                If Config.WRC297 = 2 And Geom(iB).Buco = 0 And Geom(iB).Forma = 0 Then
                    ShellNoz = 2
3417:               Call CalcStress2()
3418:               Call CalcwrcN()
                    ShellNoz = 1
                End If 'r
            ElseIf Config.WRC297 < 4 Then  'sfere WRC
3413:           If iC = 1 Then Call LeggiSfe(Ind)
3414:           Call CalcSfe()
                Call CalcwrcN()
            Else 'sfere AppG
                If Geom(iB).Buco = 0 Then
                    If iC = 1 Then Call AppGSfe()
                    Call StressSfeG()
                Else
                    If iC = 1 Then Call AppGSfeR()
                    Call CalcStress()
                    Call CalcwrcN()
                End If
            End If 't
15000:      If Config.Analisi = 0 Then GoTo 18000
            If Config.WRC297 >= 3 And ShellNoz = 2 Then GoTo 18000
            ShellNoz = 1
15010:      Call CalcNozz()
18000:      If iFirst Then If Not Stampa() Then Exit Function
18010:      Call PrintVideo(iFirst)
24980:  Next iC
    End Function
    Private Sub CalcolaParametri()
        If Config.WRC297 = 4 Then
            Select Case Geom(iB).ShellType
                Case 0 : Res = AppGParam()
                Case 1 : Res = AppGParamS()
            End Select
        ElseIf Config.WRC297 = 3 Then
            Select Case Geom(iB).ShellType
                Case 0 : Res = AppGParam()
                Case 1 : Res = CalcParamS(Ind)
            End Select
        Else
            Select Case Geom(iB).ShellType
                Case 0 : Res = CalcParam()
                Case 1 : Res = CalcParamS(Ind)
            End Select
        End If 'b
        If Not Res And Not NoRules Then
            Testo = " Ci sono probabilmente degli errori | nei dati per "
            Testo = Testo & Trim(Geom(iB).Mark) & "," & vbCrLf
            Testo = Testo & "oppure il calcolo non può essere|eseguito per altre ragioni."
            MsgBox(Monitor.clsInizio.ConvertiCr(Testo), MsgBoxStyle.Critical + MsgBoxStyle.OKOnly)
        End If 'c
    End Sub
    Function G20(ByRef Raggio As Single, ByRef Spess As Single, ByRef RBocch As Single) As Boolean
        Dim gam, Cr As Single
        gam = Raggio / Spess
        Cr = 0.85 * RBocch / 2 / Raggio
        G20 = False
        If gam < 55 Then
            Y = 1
        ElseIf gam < 67 Then
            Y = 0.25 - (gam - 55) / (67 - 55) * (0.25 - 0.2)
        ElseIf gam < 100 Then
            Y = 0.2 - (gam - 67) / (100 - 67) * (0.2 - 0.15)
        ElseIf gam < 140 Then
            Y = 0.15 - (gam - 100) / (140 - 100) * (0.15 - 0.125)
        Else
            Y = 0.125 - (gam - 140) / (300 - 140) * (0.125 - 0.1)
        End If
        If Cr < Y Then G20 = True
    End Function

    Function GeomCalc() As Boolean
        Dim a As String
        Dim Log1 As Boolean
Rif:    Log1 = Geom(iB).di <= 0 And Geom(iB).RC <= 0
        Log1 = Log1 Or Geom(iB).ShellT <= 0
        Log1 = Log1 Or Geom(iB).R0 <= 0 And Geom(iB).Forma = 0
        Log1 = Log1 Or (Geom(iB).D1 <= 0 Or Geom(iB).D2 <= 0) And (Geom(iB).Forma = 1)
        If Log1 Then
            a = " Ci sono probabilmente degli errori | nei dati "
            a = a & "|per il bocchello " & Geom(iB).Mark
            MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Critical)
            If Not SubGeom() Then GeomCalc = False : Exit Function
            GoTo Rif
        End If
        GeomCalc = True
        RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
        TT = Geom(iB).T0 : If Geom(iB).TX > TT Then TT = Geom(iB).TX
3170:   Geom(iB).T = (Geom(iB).ShellT - Geom(iB).Corr) + Geom(iB).PadT
        If Config.WRC297 = 2 And Geom(iB).Rinforzo <> 0 And Geom(iB).ShellType = 0 And Geom(iB).Forma = 0 Then
            If Geom(iB).Padd / 2 - RR < 1.65 * System.Math.Sqrt(Geom(iB).T * Geom(iB).RI) Then
                If Not Gia297(iB) And Config.Verbose > 0 Then
                    a = "La larghezza del pad (" & globalRoutines.myStr(Geom(iB).Padd / 2 - RR, 4, 1, 0) & "mm) è inferiore|"
                    a = a & "a 1.65Sqr(r.t), cioè " & globalRoutines.myStr(CSng(1.65 * System.Math.Sqrt(Geom(iB).T * Geom(iB).RI)), 4, 1, 0) & ".|"
                    a = a & "Il bollettino 297 non darebbe quindi credito allo|"
                    a = a & "spessore del pad.|"
                    PrintlstRes(a)
                    a = a & "   Vuoi comunque tenerne conto ?"
                    Risp297 = MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Trim(Geom(iB).Mark))
                    Gia297(iB) = True
                    If Risp297 = MsgBoxResult.No Then
                        PrintlstRes("Non se ne tiene conto.||")
                        Geom(iB).T = (Geom(iB).ShellT - Geom(iB).Corr)
                    Else
                        PrintlstRes("Se ne tiene comunque conto.||")
                    End If
                End If
            End If
        End If
        If ShellNoz = 2 And Config.WRC297 >= 3 Then Geom(iB).T = (Geom(iB).ShellT - Geom(iB).Corr)
3180:   Geom(iB).RI = Geom(iB).di / 2 + Geom(iB).Corr
        If Geom(iB).ShellType = 1 Then
            Geom(iB).RI = Geom(iB).RC + Geom(iB).Corr
        End If 'y
3190:   Geom(iB).R = Geom(iB).RI + Geom(iB).T / 2
3200:   Geom(iB).RO = Geom(iB).RI + Geom(iB).T
3210:   Geom(iB).RM = Geom(iB).RI + Geom(iB).T / 2
3220:   If Geom(iB).Buco = 0 And Geom(iB).Forma = 0 Then Geom(iB).RN = RR - (TT - Geom(iB).CorrN) / 2
    End Function
    Function SubCarichi() As Boolean
        SubCarichi = True
        RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
        TT = Geom(iB).T0 : If Geom(iB).TX > TT Then TT = Geom(iB).TX
        If Geom(iB).Incluso = 0 Then Exit Function
        With frmCar.DefInstance
            For iC = 1 To Geom(iB).Casi
                If iC > 1 Then
                    .TabStrip2.TabPages.Add(New TabPage("Cond." & Str(iC)))
                Else
                    .TabStrip2.TabPages(iC - 1).Text = "Cond." & Str(iC)
                End If
            Next
            .TabStrip2.SelectedTab = .TabStrip2.TabPages(0)
            iC = 1
            .Aggiorna()
            .ShowDialog()
            SubCarichi = .OK
        End With
        frmCar.DefInstance.Close()
        frmCar.DefInstance.Dispose()
    End Function
    Sub SubConfig()
        Try        ' Geom(iB).kS = GlobaLroutines.ValVir(Risult$(Compr(6)))
            'Config.UnitSis = 0 '-----------------------------------------------
            If Config.Ammiss < 0 Or Config.Ammiss > 1 Then Config.Ammiss = 0
1310:       If Config.WRC297 < 1 Or Config.WRC297 > 4 Then Config.WRC297 = 1
            If Config.ConvSumm < 1 Or Config.ConvSumm > 2 Then Config.ConvSumm = 1
            If job.Comm.NumAs = 0 Then job.Comm.NumAs = 1
            frmGen.DefInstance.ShowDialog()
            If Not frmGen.DefInstance.OK Then
                frmGen.DefInstance.Dispose()
                Exit Sub
            End If
            frmGen.DefInstance.Dispose()
1449:       objWRCB.Ridimens()
            Call ConfigString()
1451:       Call Escludi()
            AggAlbero()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub SubStressLim()
        Dim i As Short
        Dim Log1 As Boolean
        If Geom(iB).kS = 0 Then Geom(iB).kS = 1
3000:   If Config.UnitSis = 2 Then
3040:       StressLim(iC, iB).ASL(2) = CSng(0.0015 * Geom(iB).kS * Geom(iB).Carichi(iC).AllowShe)
3050:       StressLim(iC, iB).ASQ(2) = CSng(0.003 * Geom(iB).kS * Geom(iB).Carichi(iC).AllowShe)
        Else
3010:       StressLim(iC, iB).ASL(2) = 1.5 * Geom(iB).kS * Geom(iB).Carichi(iC).AllowShe
3020:       StressLim(iC, iB).ASQ(2) = 3 * Geom(iB).kS * Geom(iB).Carichi(iC).AllowShe
        End If
        StressLim(iC, iB).ASL(1) = StressLim(iC, iB).ASL(2)
        StressLim(iC, iB).ASQ(1) = StressLim(iC, iB).ASQ(2)
        If Config.WRC297 > 2 And Config.Ammiss = 1 Then
            StressLim(iC, iB).ASQ(1) = 2.25 * Geom(iB).Carichi(iC).AllowSheBr
            StressLim(iC, iB).ASQ(2) = 2.0! * Geom(iB).Carichi(iC).AllowSheBr
            '        IF DatProg.CodiceM > 1 THEN
            StressLim(iC, iB).ASL(1) = 1.5 * Geom(iB).Carichi(iC).AllowSheBr
            StressLim(iC, iB).ASL(2) = 1.2 * Geom(iB).Carichi(iC).AllowSheBr
            '        END IF
        End If
        Log1 = Geom(iB).ShellType = 0 And Config.WRC297 = 2 'siamo su cilindro con regola 297
3060:   If Config.Analisi = 0 And Not Log1 Then Exit Sub
3070:   StressLim(iC, iB).ANM = Geom(iB).kS * Geom(iB).Carichi(iC).AllowNoz
3080:   StressLim(iC, iB).ANL = 1.5 * Geom(iB).kS * Geom(iB).Carichi(iC).AllowNoz
3090:   StressLim(iC, iB).ANQ = 3 * Geom(iB).kS * Geom(iB).Carichi(iC).AllowNoz
        If Config.Analisi = 0 Then Exit Sub
        For i = 1 To 6
3100:       Geom(iB).Carichi(iC).Load(i, 2) = Geom(iB).Carichi(iC).WLoad(i, 2) + Geom(iB).Carichi(iC).TLoad(i, 2)
        Next
    End Sub
    Sub Testa1(ByRef iB1 As Short)
        Dim StriSt(13) As String
        Dim ifl As Short
        Dim i As Short
        iB = System.Math.Abs(iB1)
        Monitor.Motore.Testata()
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR01.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 13 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        If iB1 > -1 Then
            If Config.WRC297 > 2 Then
                Monitor.Motore.Problem.Printa(StriSt(3))  ' "              BS5500, App. G, 1994 Edition + Issue 3, Jan 1996"
            Else
                Monitor.Motore.Problem.Printa(StriSt(4))  '"              WRC Bulletins 107, March 1979 / 297 August 1984"
            End If
        Else
            Monitor.Motore.Problem.Printa(StriSt(12))
        End If
        If Config.Docu.Trim.Length = 0 And Not Monitor.Motore.Inizio.LavoriSciolti Then Config.Docu = job.Comm.Arch.Trim & job.Comm.Ind.Item(job.Comm.NumAs).Data.File.Trim
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(7), job.Contratto, job.Comm.Item, Config.Docu)) '             FBM Job Nø \  \  Item \        \  Dwg Nø \        \"
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(8), job.Comm.Clie, job.Comm.Comp))  '"              Customer   \                   \  Designer \      \"
        Monitor.Motore.Problem.Printa(StriSt(9))  '"              ---------------------------------------------------"
        Monitor.Motore.Problem.Printa(StriSt(0))
    End Sub 'k
    Sub Titoli(ByRef Stringa() As String)
1810:   Stringa(3) = "Radial Load                " & Config.Unit(3) & " P   = "
1830:   Stringa(4) = "Bending Moment (Circ.Dir.) " & Config.Unit(2) & " Mc  = "
        Stringa(5) = "Bending Moment (Long.Dir.) " & Config.Unit(2) & " Ml  = "
        Stringa(6) = "Torsional Moment           " & Config.Unit(2) & " Mt  = "
        Stringa(7) = "Shear Load    (Circ.Dir.)  " & Config.Unit(3) & " Vc  = "
        Stringa(8) = "Shear Load    (Long.Dir.)  " & Config.Unit(3) & " Vl  = "
    End Sub

    Function Y354(ByRef c As Single) As Single
        Dim Sq As Single
        Sq = System.Math.Sqrt(16 * c * c - 12.8 * c + 0.64)
        Y354 = 64 / (4 * c + 0.8 + Sq) ^ 2
    End Function

    Function Y354D(ByRef c As Single) As Single
        Dim Sq As Single
        Sq = System.Math.Sqrt(16 * c * c - 12.8 * c + 0.64)
        Y354D = -128 * (4 + (32 * c - 12.8) / 2 / Sq) / (4 * c + 0.8 + Sq) ^ 3
    End Function
    Sub InitWRCB()
        Dim i, ifl, j As Short
        Try
            Monitor.Motore.Problem.Extension = ".WRC"
            Monitor.Motore.Problem.TipoFile = "Carichi sui bocchelli "
            Monitor.Motore.About.ProgName = "*  WRCB * Local Stresses on Shells at nozzles*"
            Monitor.Motore.About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
            Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
            Monitor.Motore.About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
            Monitor.Motore.About.ProgDesc = "LOCAL STRESSES in CYLINDRICAL and SPHERICAL SHELLS at ATTACHMENTS"
            Monitor.Motore.About.Company = "Copyright (c) 2005 SSAP"
            Monitor.Motore.About.Code = CodiceCalc()
            ifl = FreeFile()
            FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\WRCBDATA.DAT", OpenMode.Input, , OpenShare.Shared)
550:        For i = 0 To 31
560:            For j = 0 To 6
570:                Input(ifl, wrcM(i, j))
580:            Next j
590:        Next i
600:        For i = 0 To 16
610:            Input(ifl, wrcbB(i))
620:        Next i
630:        For i = 0 To 9
640:            Input(ifl, wrcG(i))
650:        Next i
            For i = 0 To 38
                Input(ifl, wrcU(i))
            Next i
            FileClose(ifl)
            Config.initialize()
            ReDim Geom(0)
            Geom(0).Initialize(True)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function AggiornaAllow() As Boolean
        If Geom(iB).Incluso = 0 Then Exit Function
        With frmAmm.DefInstance
            For iC = 1 To Geom(iB).Casi
                If Geom(iB).Carichi(iC).YieldNoz = 0 Then CalcYield()
                If Geom(iB).Carichi(iC).UTSNoz = 0 Then CalcUTS()
                If Geom(iB).Carichi(iC).fBuc = 0 Then Geom(iB).Carichi(iC).fBuc = 0.9
                If Geom(iB).Carichi(iC).fYield = 0 Then
                    If Matdim(2 * iB - 1).Classe < 2 Then Geom(iB).Carichi(iC).fYield = 1.5 Else Geom(iB).Carichi(iC).fYield = 1.35
                End If 'k
                If Geom(iB).Carichi(iC).fUTS = 0 Then
                    If Matdim(2 * iB - 1).Classe < 2 Then Geom(iB).Carichi(iC).fUTS = 2.35 Else Geom(iB).Carichi(iC).fUTS = 2.5
                End If 'l
                If Geom(iB).Carichi(iC).YieldNoz > 0 And Geom(iB).Carichi(iC).UTSNoz > 0 And Geom(iB).Carichi(iC).fYield > 0 And Geom(iB).Carichi(iC).fUTS > 0 Then
                    CalcfBS()
                End If '•
                If iC > 1 Then
                    Geom(iB).Carichi(iC).fBuc = Geom(iB).Carichi(1).fBuc
                    Geom(iB).Carichi(iC).fYield = Geom(iB).Carichi(1).fYield
                    Geom(iB).Carichi(iC).fUTS = Geom(iB).Carichi(1).fUTS
                End If
                If iC > 1 Then
                    .TabStrip1.TabPages.Add(New TabPage("Cond." & Str(iC)))
                Else
                    .TabStrip1.TabPages(iC - 1).Text = "Cond." & Str(iC)
                End If
            Next
            .AggiornaLbl()
            .TabStrip1.SelectedTab = .TabStrip1.TabPages(0)
            iC = 1
            .AggiornaTesti()
            .ShowDialog()
            AggiornaAllow = .OK
        End With
        frmAmm.DefInstance.Dispose()
    End Function

    Public Sub TensAmm(ByRef i As Short)
        Dim Temp, AllFOpe As Single
        Try
            Temp = Geom(iB).Carichi(iC).DesTemp
            'indice = 2 * iB - 1
            Call SubTensAmm(Temp, AllFOpe, indice)
            frmAmm.DefInstance.Text1(i).Text = globalRoutines.myStr(AllFOpe, 6, 2, False)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Sub CalcfBS()
        Dim UTS As Single
        Geom(iB).Carichi(iC).AllowSheBr = Geom(iB).Carichi(iC).YieldNoz / Geom(iB).Carichi(1).fYield
        UTS = Geom(iB).Carichi(iC).UTSNoz / Geom(iB).Carichi(1).fUTS
        If UTS < Geom(iB).Carichi(iC).AllowSheBr Then Geom(iB).Carichi(iC).AllowSheBr = UTS
    End Sub

    Public Sub CalcUTS()
        Dim indice As Short
        Dim UTS As Single
        indice = 2 * iB - 1
        UTS = Matdim(indice).UltStrength(0)
        Select Case Config.UnitSis
            Case 0 'Si
            Case 1 'Tecnico
                UTS = UTS / GRAV
            Case 2 'British
                UTS = UTS / MPA
        End Select
        Geom(iB).Carichi(iC).UTSNoz = UTS
    End Sub
    Public Sub CalcYield()
        Dim indice As Short
        Dim Temp, td As Single
        Dim Syo, Sya As Single
        indice = 2 * iB - 1
        'Temp = GlobaLroutines.ValVir(EditFieldInquire(1))
        If Temp = 0 Then Temp = Geom(iB).Carichi(iC).DesTemp
        If Config.UnitSis < 2 Then 'centigradi
            td = Temp * 1.8 + 32
        Else
            td = Temp
        End If 'l
        If Matdim(indice) Is Nothing Then
            Matdim(indice) = New LibMat.MaterialeNew1
        End If
        If Matdim(indice).Indmat > 0 Then Matdim(indice).YieldTemp(-6, td, Sya, Syo)
        Select Case Config.UnitSis
            Case 0 'Si
            Case 1 'Tecnico
                Sya = Sya / GRAV : Syo = Syo / GRAV
            Case 2 'British
                Sya = Sya / MPA : Syo = Syo / MPA
        End Select
        frmAmm.DefInstance._Text1_6.Text = globalRoutines.myStr(Syo, 6, 2, False)
    End Sub
    Public Function PrepRapp(ByRef Templ As String, ByRef Tipo As String, ByRef Elemento As String, ByRef FileSt As String, ByRef lstRapp As ListView) As Boolean
        Apert.DefInstance.Check1.Enabled = False
        Apert.DefInstance.Text1.Enabled = False
        PrepRapp = Monitor.Motore.PrepRapp(FileSt, Templ, Tipo, Elemento, lstRapp)
    End Function
    Sub CloseioutS(ByRef lstRapp As ListView)
        Monitor.Motore.Problem.ChiudiRapp()
        lstRapp.Items.Clear()
        Apert.DefInstance.Check1.Enabled = True
        Apert.DefInstance.Text1.Enabled = True
        If Not Stub Is Nothing Then
            Stub.sClose(1) ' wdSaveChanges
            If Apert.DefInstance.Check1.CheckState = 1 Then
                Stub.sCloseAll(2)
            End If
            Stub.Minimizza()
            Stub = Nothing
        End If
    End Sub
    Public Sub VisualCap()
        Dim cap1 As String
        Dim i As Short
        Dim cap2 As String = ""
        Dim l As ListViewItem
        With Apert.DefInstance
            If .lstRapp.SelectedItems.Count = 0 Then
                MostraAiuto(IDH_ERR_CAPNONSCELTO)
                Exit Sub
            Else
                l = .lstRapp.SelectedItems(0)
            End If
        End With
        If l Is Nothing Then Exit Sub
        cap1 = globalRoutines.TogliBlank(l.SubItems(0).Text)
        Try
            Stub.VaiInizio(cap1, , True)
            i = l.Index
            If i < Apert.DefInstance.lstRapp.Items.Count - 1 Then
                cap2 = globalRoutines.TogliBlank(Apert.DefInstance.lstRapp.Items(i).SubItems(0).Text)
                Stub.VaiInizio(cap2, 1)
            Else
                Stub.VaiInizio("\EndOfDoc", 1)
            End If
            Stub.ASMECap(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem, cap1, cap2)
            Stub.Massimizza()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function Visualizza() As Boolean
        Dim FileN As String
        Dim Comm As String = ""
        Visualizza = True
        Try
            If Monitor.clsInizio.LavoriSciolti Then
                Comm = globalRoutines.Adjust(Monitor.clsInizio.CommPulita(objWRCB.commessa), 6)
            Else
                'Comm = job.Comm.Arch
            End If
            If Template = "HeadNotNoz" Then
                If Not IO.File.Exists(FileStPr) Then
                    FileN = " Bisogna prima (ri)eseguire il calcolo.| Nel caso di rapporto con intestazione|bisogna cliccare sul menu 'Calcola tutto'"
                    MsgBox(Monitor.clsInizio.ConvertiCr(FileN), MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
                    Return False
                End If
                FileSt = FileStPr
            Else
                If Monitor.Motore.Problem.FileStream Is Nothing Then 'Len(RTrim$(FileStPr)) = 0 Or Len(Dir$(FileStPr)) = 0 Then
                    FileN = " Bisogna prima (ri)eseguire il calcolo |"
                    MsgBox(Monitor.clsInizio.ConvertiCr(FileN), MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
                    Return False
                End If
                Monitor.Motore.Problem.FineRapp()
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Exit Function
        End Try
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto di calcolo", "BSDD")
        Apert.DefInstance.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DoEvents()
        Interrompi = False
        Apert.DefInstance.Enabled = False
        capitoli = New Collection
        Try
            Monitor.Motore.Avanzamento = 10
            DoEvents()
            If Interrompi Then GoTo ExitSub
            Monitor.clsInizio.SuperStampa(FileSt, Stub)
            If Apert.DefInstance.Check1.CheckState = 1 Then
                Monitor.Motore.Avanzamento = 20
                DoEvents()
                If Interrompi Then GoTo ExitSub
                Dim LogoFile As String = Monitor.Motore.Inizio.Archdir + "\" + Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
                Dim indirFile As String = Monitor.Motore.Inizio.Archdir + "\" + Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Indirizzo")
                If indirFile.Length > 0 Then
                    If Not File.Exists(indirFile) Then indirFile = ""
                End If
                If LogoFile.Length > 0 Then
                    If File.Exists(LogoFile) Then
                        If Not Stub.Shapes7(LogoFile, indirFile) Then GoTo ExitSub
                    End If
                End If
                Monitor.Motore.Avanzamento = 30
                DoEvents()
                If Interrompi Then GoTo ExitSub
                With Stub
                    .SubstitBookM("Fornitore", Monitor.Motore.Inizio.Firma) 'Config(0).Item
                    .SubstitBookM("OrdineCliente", "?") 'Config(0).Item
                    .SubstitBookM("Cliente", job.Comm.Clie)
                    .SubstitBookM("Progetto", "???")
                    .SubstitBookM("Codice", "CCC")
                    .SubstitBookM("Impianto", job.Comm.Impianto)
                    .SubstitBookM("Apparecchio", "App")
                    .SubstitBookM("Item", job.Comm.Item)
                    .SubstitBookM("Titolo", "Nozzle Loads Calculations")
                    .SubstitBookM("NoForn", Comm & "SL001 Rev.0")
                    .SubstitBookM("NoClie", "??")
                    .SubstitBookM("Scopo", "For approval")
                    Monitor.Motore.Inizio.Immatricolazione(Stub, Comm, "SL001")
                    Monitor.Motore.Avanzamento = 40
                    If Interrompi Then GoTo ExitSub
                    .sOpen(Monitor.clsInizio.DiscoTem & "StamSumm", True, 1)
                    .VaiInizio(, 1)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("NozzleSummary")
                    .sPaste()
                    Monitor.Motore.Avanzamento = 50
                    DoEvents()
                    If Interrompi Then GoTo ExitSub
                    .sOpen(Monitor.clsInizio.DiscoTem & "StamStress", True, 1)
                    .VaiInizio(, 1)
                    .Copia(1)
                    .sClose(, 1)
                    Monitor.Motore.Avanzamento = 60
                    DoEvents()
                    If Interrompi Then GoTo ExitSub
                    .VaiInizio("\EndOfDoc")
                    .sTypeParagraph()
                    .sInsertBreak()
                    .VaiInizio("\EndOfDoc")
                    .sStile("Titolo 1")
                    .sTypeText("Nozzles Stress summary", True)
                    .sTypeParagraph()
                    .sPaste()
                    Monitor.Motore.Avanzamento = 75
                    DoEvents()
                    If Interrompi Then GoTo ExitSub
                    .sOpen(Monitor.clsInizio.DiscoTem & "StamNote", True, 1)
                    .VaiInizio(, 1)
                    .Copia(1)
                    .sClose(, 1)
                    Monitor.Motore.Avanzamento = 90
                    DoEvents()
                    If Interrompi Then GoTo ExitSub
                    .VaiInizio("\EndOfDoc")
                    .sTypeParagraph()
                    .sInsertBreak()
                    .VaiInizio("\EndOfDoc")
                    .sStile("Titolo 1")
                    .sTypeText("Explanatory Notes", True)
                    .sTypeParagraph()
                    .sPaste()
                    Monitor.Motore.Avanzamento = 100
                    DoEvents()
                End With
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
ExitSub: Monitor.Motore.ProgrAmmazza()
        Apert.DefInstance.Enabled = True
        If Interrompi Then Visualizza = False
        If Not Stub Is Nothing Then Stub.Massimizza()
Fine1:  Apert.DefInstance.Cursor = System.Windows.Forms.Cursors.Default
    End Function
    Public Function CodiceCalc() As String
        '  Select Case Config(kLato).DC
        '     Case 0, 1, 2
        CodiceCalc = " ASME VIII Div.1 1995 Ed.+1997 Add."
        '     Case 3, 4, 5
        '         CodiceCalc = " ASME VIII Div.2 1995 Ed.+1997 Add."
        '  End Select
    End Function
    Function SubGeom() As Boolean
        SubGeom = False
        If Geom(iB).Casi <= 0 Or Geom(iB).Casi > 4 Then Geom(iB).Casi = Config.Casi
        If Geom(iB).Incluso = 0 Then
            MsgBox("Questa apertura non è inclusa nel calcolo", MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
            Exit Function
        End If
        If Config.Analisi = 0 Then
            If Geom(iB).RX > Geom(iB).R0 Then Geom(iB).R0 = Geom(iB).RX : Geom(iB).T0 = Geom(iB).TX
        Else
            If Geom(iB).RX = 0 Then Geom(iB).RX = Geom(iB).R0 : Geom(iB).TX = Geom(iB).T0
        End If '+
        If Geom(iB).Padd * Geom(iB).PadT > 0 Then Geom(iB).Rinforzo = True
        If Geom(iB).Asa < 0 Or Geom(iB).Asa > 7 Then Geom(iB).Asa = 0
        If Geom(iB).ShellType < 0 Or Geom(iB).ShellType > 1 Then Geom(iB).ShellType = 0
        If Geom(iB).Buco < 0 Or Geom(iB).Buco > 1 Then Geom(iB).Buco = 0
        If Geom(iB).Forma < 0 Or Geom(iB).Forma > 1 Then Geom(iB).Forma = 0
        If Geom(iB).Rinforzo < -1 Or Geom(iB).Rinforzo > 0 Then Geom(iB).Rinforzo = 0
        If Geom(iB).Buco = 0 And Geom(iB).Forma = 1 Then
            MsgBox(Monitor.Motore.Inizio.ConvertiCr("La combinazione 'forma rettangolare'| con 'attacco forato' non è ammessa"), MsgBoxStyle.Information)
            Geom(iB).Forma = 0
        End If
        frmGeom.DefInstance.ShowDialog()
        SubGeom = frmGeom.DefInstance.OK
        frmGeom.DefInstance.Close()
        frmGeom.DefInstance.Dispose()
        AggAlbero()
    End Function
    Public Sub AggAlbero()
        Dim i, Index As Short
        Try
            With Apert.DefInstance
                Index = -1
                If .lstNoz.SelectedItems.Count = 1 Then Index = _
                .lstNoz.SelectedItems(0).Index
                .lstNoz.Items.Clear()
                For i = 1 To Config.NBocch
                    Dim l As ListViewItem = .lstNoz.Items.Add(Trim(Geom(i).Mark))
                    If Geom(i).ShellType = 0 Then
                        l.SubItems.Add("on cylinder")
                    Else
                        l.SubItems.Add("on sphere")
                    End If
                Next
                If Index > .lstNoz.Items.Count - 1 Then Index = .lstNoz.Items.Count - 1
                If Index > -1 Then .lstNoz.Items(Index).Selected = True
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub StamLib()
        Dim StriSt(7) As String
        Dim ifl, i As Short
        If Not PrepRapp("HEADER", "Carichi standard", Carta, FileSt, Apert.DefInstance.lstRapp) Then Exit Sub
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\StLib.WRC", OpenMode.Input)
        For i = 1 To 7
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), Carta))
        Monitor.Motore.Problem.Printa(StriSt(2))
        Monitor.Motore.Problem.Printa(StriSt(3))
        For i = 1 To kk
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(4), globalRoutines.ValVir(DN(i)), Valor(1, i), Valor(6, i), Valor(5, i), Valor(3, i), Valor(2, i), Valor(4, i)))
        Next
        Monitor.Motore.Problem.Printa(StriSt(5))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(6), 150, 300, 400, 600, 900, 1500, 2500))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(7), Factor(1), Factor(2), Factor(3), Factor(4), Factor(5), Factor(6), Factor(7)))
    End Sub

    Public Sub StamTutteLib()
        Dim ik As Short
        If Not PrepRapp("HEADER", "Carichi standard", "Catalogo librerie", FileSt, Apert.DefInstance.lstRapp) Then Exit Sub
        ik = 1
        Testa1(0)
        Do
            ik = ik + 1
            Carta = ExtLoads(ik, Csv)
            If ik = 0 Or Left(Carta, 1) = "." Then Exit Do
            LeggiSt()
            StamLib()
            If ((ik - 1) Mod 2) = 0 Then Testa1(0)
        Loop
    End Sub
    Public Sub LeggiSt()
        Dim i, ifl, n As Short
        Dim Riga As String
        ifl = FreeFile()
300:    FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\" & Csv, OpenMode.Input, , OpenShare.Shared)
        Riga = LineInput(ifl)
        Riga = LineInput(ifl)
        kk = 0
        Do
            kk = kk + 1
310:        Input(ifl, DN(kk))
            Input(ifl, Valor(1, kk))
            Input(ifl, Valor(6, kk))
            Input(ifl, Valor(5, kk))
            Input(ifl, Valor(3, kk))
            Input(ifl, Valor(2, kk))
            Input(ifl, Valor(4, kk))
            If globalRoutines.ValVir(DN(kk)) = 0 Then Exit Do
        Loop
        kk = kk - 1
        Do
320:        Riga = LineInput(ifl)
            If Left(Riga, 6) = "Bvalue" Then
                Riga = Right(Riga, Len(Riga) - 7)
                For i = 1 To 7
                    Factor(i) = globalRoutines.ValVir(Riga)
                    n = InStr(Riga, ",")
                    If n > 0 Then Riga = Right(Riga, Len(Riga) - n)
                Next
                Exit Do
            End If 'n
            If EOF(ifl) Then MsgBox("Errore imp.2in TrasfCar")
        Loop
        FileClose(ifl)
    End Sub
    Public Sub PrintlstRes(ByRef a2 As String)
        Dim a1, a As String
        Dim n As Short
        Dim l As ListViewItem
        a = a2
        Do
            n = InStr(a, "|")
            If n = 0 Then Exit Do
            a1 = Left(a, n - 1)
            Apert.DefInstance.lstRes.Items.Add(a1)
            a = Right(a, Len(a) - n)
        Loop
        l = Apert.DefInstance.lstRes.Items.Add(a)
        l.EnsureVisible()
    End Sub
    Public Sub TitoloDoc()
        Dim documenti As New Collection
        Dim MaxRev As String
        Dim Testo, Rev As String
        Dim n As Integer
        If Monitor.Motore.Inizio.LavoriSciolti Then
            Apert.DefInstance.Text1.Text = IO.Path.GetDirectoryName(objWRCB.commessa) & "\" & IO.Path.GetFileNameWithoutExtension(objWRCB.commessa) & ".WRS"
        Else
            Apert.DefInstance.Text1.Text = IO.Path.GetDirectoryName(objWRCB.commessa) & "\" & IO.Path.GetFileNameWithoutExtension(objWRCB.commessa) & "SL001R0.DOC"
            If Len(Dir(Apert.DefInstance.Text1.Text)) > 0 Then
                Dim di As New DirectoryInfo(IO.Path.GetDirectoryName(objWRCB.commessa))
                Dim fi() As FileInfo = di.GetFiles(Path.GetFileNameWithoutExtension(objWRCB.commessa) & "SL001R*.DOC")
                n = UBound(fi)
                MaxRev = "0"
                For i = 0 To n
                    Testo = fi(i).Name
                    Testo = Right(Testo, 5)
                    Rev = Left(Testo, 1)
                    If globalRoutines.ValVir(Rev) > globalRoutines.ValVir(MaxRev) Then MaxRev = Rev
                    documenti.Add(Testo, Rev)
                Next
                Testo = Monitor.Motore.Inizio.CommPulita(documenti.Item(MaxRev))
                Testo = Left(Testo, Len(Testo) - 6)
                Testo = "Il rapporto di calcolo " & Testo & vbCrLf
                Testo = Testo & "esiste già alla Rev. " & MaxRev & "." & vbCrLf
                Testo = Testo & "Vuoi sovrascriverlo (Si) o vuoi passare (No)" & vbCrLf
                Testo = Testo & "alla revisione successiva ?"
                If MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto documenti(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Testo = documenti.Item(MaxRev)
                    MaxRev = Trim(Str(Val(MaxRev) + 1))
                    Mid(Testo, Len(Testo) - 4, 1) = MaxRev
                    Apert.DefInstance.Text1.Text = Testo
                Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto documenti(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Apert.DefInstance.Text1.Text = documenti.Item(MaxRev)
                End If
            End If
        End If
    End Sub

    Public Function Converti(ByRef a As Single, ByRef codice As Short) As Single
        Select Case Config.UnitSis
            Case 0
                Converti = a
            Case 1 'da tecnico a Si
                Select Case codice
                    Case 1 'temperatura
                        Converti = a
                    Case 2 'pressione
                        Converti = a * GRAV
                    Case 3 'pressione
                        Converti = a * GRAV
                    Case 4 'pressione
                        Converti = a * GRAV
                    Case 5 'pressione
                        Converti = a * GRAV
                End Select
            Case 2 'da british a si
                Select Case codice
                    Case 1 'temperatura
                        Converti = (a - 32) / 1.8
                    Case 2 'pressione
                        Converti = a / PSI
                    Case 3
                        Converti = a * NIUT
                    Case 4
                        Converti = a * NIUT * INC
                    Case 5 'pressione
                        Converti = a / PSI * 1000
                End Select
        End Select
    End Function
    Public Function sConverti(ByRef a As Single, ByRef codice As Short) As Single
        Select Case Config.UnitSis
            Case 0
                sConverti = a
            Case 1 'da tecnico a Si
                Select Case codice
                    Case 1 'temperatura
                        sConverti = a
                    Case 2 'pressione
                        sConverti = a / GRAV
                    Case 3 'forze
                        sConverti = a / GRAV
                    Case 4 'momenti
                        sConverti = a / GRAV
                    Case 5 'momenti
                        sConverti = a / GRAV
                End Select
            Case 2 'da british a si
                Select Case codice
                    Case 1 'temperatura
                        sConverti = a * 1.8 + 32
                    Case 2 'pressione
                        sConverti = a * PSI
                    Case 3
                        sConverti = a / NIUT
                    Case 4
                        sConverti = a / NIUT / INC
                    Case 5 'pressione
                        sConverti = a * PSI / 1000
                End Select
        End Select

    End Function
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Helpstringa = rmHelpStrings.GetString(Nome).Replace("|", vbCrLf)
    End Function
    Public Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As ChiaviMess = _
                        ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly, _
                        Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "") _
                        As ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(id))
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "WRCB - Messaggi di errore"
                If Not CBool(Informa And ChiaviMess.MessCritical) Then Tit = "Traccia"
            Else
                Tit = mioTitolo
            End If
            Dim Topic As String = HelpTopic(id)
            If Topic = "" Then
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa, Tit, RadiceHelp, Topic)
            Else
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or ChiaviMess.MessHelpButton, Tit, RadiceHelp, Topic)
            End If
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "WRCB")
        End If
    End Function
End Module