Option Strict Off
Option Explicit On
Imports RoutBase1
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Module wrcbRut
    Private StrStr(4) As String
    Private WEndEffect, TEndEffect As Single
    Private Vc, AML, AMc, AMt, Vl As Single
    Private TVc, TMl, TMc, TMt, TVl As Single
    Private SR, SZ, SL, ST As Single
    Private SL1, RJ, SL2 As Single
    Private SQ1, SQ2 As Single
    Private Sm1, Sm2 As Single
    Private SP2, SP1, SP3 As Single
    Private SD2, SD1, SD3 As Single
    Private Stringa3(1) As String
    Private Structure Rec39
        Dim Valor() As Single
        Public Sub Initialize()
            ReDim Valor(39)
        End Sub
    End Structure
    Private Structure Rec17
        Dim Valor() As Single
        Public Sub Initialize()
            ReDim Valor(17)
        End Sub
    End Structure
    Sub CalcNozz()
        Try
            Call ComposW(WEndEffect, AMc, AML, AMt, Vc, Vl)
            Call ComposT(TEndEffect, TMc, TMl, TMt, TVc, TVl)
15050:      RJ = Geom(iB).R0 - Geom(iB).T0
15060:      E0 = Geom(iB).T0 - Geom(iB).CorrN
15070:      EX = Geom(iB).TX - Geom(iB).CorrN
15080:      DM0 = 2 * Geom(iB).R0 - E0
15090:      DMX = 2 * Geom(iB).RX - EX
15100:      WCM = System.Math.Sqrt(AMc * AMc + AML * AML)
15110:      WCV = System.Math.Sqrt(Vc * Vc + Vl * Vl)
15120:      TCM = System.Math.Sqrt(TMc * TMc + TMl * TMl)
15130:      TCV = System.Math.Sqrt(TVc * TVc + TVl * TVl)
15140:      If Geom(iB).Carichi(iC).DesPress > 0 Then GoTo 15200
15150:      ZPRA = Geom(iB).Carichi(iC).DesPress * Geom(iB).RX / EX
15160:      ZPRB = Geom(iB).Carichi(iC).DesPress * Geom(iB).R0 / E0
15170:      SPRA = Geom(iB).Carichi(iC).DesPress * Geom(iB).RX ^ 2 / (DMX * EX)
15180:      SPRB = Geom(iB).Carichi(iC).DesPress * Geom(iB).R0 ^ 2 / (DM0 * E0)
15190:      GoTo 15240
15200:      ZPRA = Geom(iB).Carichi(iC).DesPress * (Geom(iB).RX - EX) / EX
15210:      ZPRB = Geom(iB).Carichi(iC).DesPress * (Geom(iB).R0 - E0) / E0
15220:      SPRA = Geom(iB).Carichi(iC).DesPress * (Geom(iB).RX - EX) ^ 2 / (DMX * EX)
15230:      SPRB = Geom(iB).Carichi(iC).DesPress * (Geom(iB).R0 - E0) ^ 2 / (DM0 * E0)
15240:      RPRA = -0.5 * System.Math.Abs(Geom(iB).Carichi(iC).DesPress)
15250:      RPRB = -0.5 * System.Math.Abs(Geom(iB).Carichi(iC).DesPress)
15260:      SWFA = WEndEffect / (PI * DMX * EX)
15270:      SWFB = WEndEffect / (PI * DM0 * E0)
15280:      STFA = TEndEffect / (PI * DMX * EX)
15290:      STFB = TEndEffect / (PI * DM0 * E0)
15300:      SWMA = 4 * WCM / (PI * DMX ^ 2 * EX)
15310:      SWMB = 4 * WCM / (PI * DM0 ^ 2 * E0)
15320:      STMA = 4 * TCM / (PI * DMX ^ 2 * EX)
15330:      STMB = 4 * TCM / (PI * DM0 ^ 2 * E0)
15340:      TWTA = 2 * AMt / (PI * DMX ^ 2 * EX)
15350:      TWTB = 2 * AMt / (PI * DM0 ^ 2 * E0)
15360:      TTTA = 2 * TMt / (PI * DMX ^ 2 * EX)
15370:      TTTB = 2 * TMt / (PI * DM0 ^ 2 * E0)
15380:      TWVA = 1.885 * WCV / (PI * DMX * EX)
15390:      TWVB = 1.885 * WCV / (PI * DM0 * E0)
15400:      TTVA = 1.885 * TCV / (PI * DMX * EX)
15410:      TTVB = 1.885 * TCV / (PI * DM0 * E0)
15420:      SZ = ZPRA
15430:      SL = SPRA + SWFA
15440:      SR = RPRA
15450:      ST = TWTA + TWVA
15460:      Call Sub16000()
15470:      Result(ShellNoz, iC, iB).SMA = SI
15480:      SL = SPRA + SWFA + SWMA
15490:      Call Sub16000()
15500:      SL1 = SI
15510:      SL = SPRA + SWFA - SWMA
15520:      Call Sub16000()
15530:      SL2 = SI
15540:      If SL1 > SL2 Then Result(ShellNoz, iC, iB).SLA = SL1 Else Result(ShellNoz, iC, iB).SLA = SL2
15550:      SL = SPRA + SWFA + STFA + SWMA + STMA
15560:      ST = TWTA + TTTA + TWVA + TTVA
15570:      Call Sub16000()
15580:      SQ1 = SI
15590:      SL = SPRA + SWFA + STFA - SWMA - STMA
15600:      Call Sub16000()
15610:      SQ2 = SI
15620:      If SQ1 > SQ2 Then Result(ShellNoz, iC, iB).SQA = SQ1 Else Result(ShellNoz, iC, iB).SQA = SQ2
15630:      SZ = ZPRB
15640:      SR = RPRB
15650:      ST = TWTB + TWVB
15660:      SL = SPRB + SWFB + SWMB
15670:      Call Sub16000()
15680:      Sm1 = SI
15690:      SL = SPRB + SWFB - SWMB
15700:      Call Sub16000()
15710:      Sm2 = SI
15720:      If Sm1 > Sm2 Then Result(ShellNoz, iC, iB).SMB = Sm1 Else Result(ShellNoz, iC, iB).SMB = Sm2
15730:      Result(ShellNoz, iC, iB).SLB = Result(ShellNoz, iC, iB).SMB
15740:      SL = SPRB + SWFB + STFB + SWMB + STMB
15750:      ST = TWTB + TTTB + TWVB + TTVB
15760:      Call Sub16000()
15770:      SQ1 = SI
15780:      SL = SPRB + SWFB + STFB - SWMB - STMB
15790:      Call Sub16000()
15800:      SQ2 = SI
15810:      If SQ1 > SQ2 Then Result(ShellNoz, iC, iB).SQB = SQ1 Else Result(ShellNoz, iC, iB).SQB = SQ2
15820:      If Result(ShellNoz, iC, iB).SMA > Result(ShellNoz, iC, iB).SMB Then Result(ShellNoz, iC, iB).SMM = Result(ShellNoz, iC, iB).SMA Else Result(ShellNoz, iC, iB).SMM = Result(ShellNoz, iC, iB).SMB
15830:      If Result(ShellNoz, iC, iB).SLA > Result(ShellNoz, iC, iB).SLB Then Result(ShellNoz, iC, iB).SLM = Result(ShellNoz, iC, iB).SLA Else Result(ShellNoz, iC, iB).SLM = Result(ShellNoz, iC, iB).SLB
15840:      If Result(ShellNoz, iC, iB).SQA > Result(ShellNoz, iC, iB).SQB Then Result(ShellNoz, iC, iB).SQM = Result(ShellNoz, iC, iB).SQA Else Result(ShellNoz, iC, iB).SQM = Result(ShellNoz, iC, iB).SQB
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Sub16000()
        SP1 = 0.5 * (SZ + SL + System.Math.Sqrt((SZ - SL) ^ 2 + 4 * ST ^ 2))
        SP2 = 0.5 * (SZ + SL - System.Math.Sqrt((SZ - SL) ^ 2 + 4 * ST ^ 2))
        SP3 = SR
        SD1 = System.Math.Abs(SP1 - SP2)
        SD2 = System.Math.Abs(SP1 - SP3)
        SD3 = System.Math.Abs(SP2 - SP3)
        If SD1 > SD2 Then SI = SD1 Else SI = SD2
        If SD3 > SI Then SI = SD3
    End Sub
    Function CalcParam() As Boolean
        Dim RR, D0 As Single
        Dim a As String
        Dim K0 As Single
        Dim I0, J0 As Short
        Dim Q1, Q2 As Single
        Dim N1, N0, N2 As Short
        Dim y2, y0, y1, y3 As Single
        Static GiaContinua As Short
        Try
            RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
            If Config.WRC297 = 2 And Geom(iB).Forma = 0 Then CalcParam = True : Exit Function
            CalcParam = False
            a = ""
            GAMMA = (Geom(iB).RM / Geom(iB).T)
3410:       If Geom(iB).Forma > 0 Then GoTo 3440
3420:       BETA = 0.875 * RR / Geom(iB).RM
3430:       GoTo 4950
3440:       If Geom(iB).D1 < Geom(iB).D2 Then D0 = Geom(iB).D1 Else D0 = Geom(iB).D2
3450:       BETA1 = Geom(iB).D1 / (2 * Geom(iB).RM)
3460:       BETA2 = Geom(iB).D2 / (2 * Geom(iB).RM)
3500:       HHH = GAMMA
3510:       KKK = BETA1 / BETA2
3520:       V = 0 : SV(1) = 0 '??? non c'era (1)
3530:       W = 0 : SW = 0 '??? non c'era (1)
3540:       If KKK < 0.25 Then GoTo 3570
3550:       If KKK > 4.0! Then GoTo 3670
3560:       GoTo 3760
3570:       a = a & "|(á1/á2)=" & globalRoutines.myStr(KKK, 3, 3, False) & " < 0.25 ; Kc,Cc,KL,CL Coeff.NOT DEFINED   "
3650:       KKK = 0.25 : V = 1
3660:       GoTo 3760
3670:       a = a & "|(á1/á2)=" & globalRoutines.myStr(KKK, 3, 3, False) & " > 4.00 ; Kc,Cc,KL,CL Coeff.NOT DEFINED   "
3750:       KKK = 4.0! : V = 1
3760:       If HHH < 15.0! Then GoTo 3790
3770:       If HHH > 300.0! Then GoTo 3890
3780:       GoTo 3980
3790:       a = a & " mu=" & globalRoutines.myStr(HHH, 4, 2, False) & " <  15 ; Kc,Cc,KL,CL Coeff.NOT DEFINED   "
3870:       HHH = 15.0! : W = 1
3880:       GoTo 3980
3890:       a = a & " mu=" & globalRoutines.myStr(HHH, 4, 2, False) & " > 300 ; Kc,Cc,KL,CL Coeff.NOT DEFINED   "
3970:       HHH = 300.0! : W = 1
3980:       K0 = 1.0!
3990:       If KKK < 1.0! Then GoTo 4100
4000:       E1 = 0.91
4010:       E2 = 1.76
4020:       E5 = 1.68
4030:       E6 = 1.2
4040:       EEE = "K{\sub 1}"
4050:       KKK1 = 0.09000001
4060:       KKK2 = -0.76
4070:       K5 = -0.63
4080:       K6 = -0.2
4090:       GoTo 4190
4100:       E1 = 1.48
4110:       E2 = 0.88
4120:       E5 = 1.2
4130:       E6 = 1.25
4140:       EEE = "K{\sub 2}"
4150:       KKK1 = -0.48
4160:       KKK2 = 0.12
4170:       K5 = -0.2
4180:       K6 = -0.25
4190:       For I0 = 1 To 3
4200:           If KKK <= wrcM(4 * I0, 0) Then GoTo 4220
4210:       Next I0
4220:       Q2 = wrcM(4 * I0, 0)
4230:       Q1 = wrcM(4 * (I0 - 1), 0)
4240:       For J0 = 1 To 3
4250:           If HHH <= wrcM(4 * I0 + J0, 1) Then GoTo 4270
4260:       Next J0
4270:       For N0 = 0 To 4
4280:           wrcC(0, N0) = wrcM(4 * (I0 - 1) + (J0 - 1), N0 + 1)
4290:       Next N0
4300:       For N0 = 0 To 4
4310:           wrcC(1, N0) = wrcM(4 * (I0 - 1) + J0, N0 + 1)
4320:       Next N0
4330:       For N0 = 0 To 4
4340:           wrcC(2, N0) = wrcM(4 * I0 + (J0 - 1), N0 + 1)
4350:       Next N0
4360:       For N0 = 0 To 4
4370:           wrcC(3, N0) = wrcM(4 * I0 + J0, N0 + 1)
4380:       Next N0
4390:       For N0 = 1 To 4
4400:           N1 = wrcC(0, N0) + (wrcC(1, N0) - wrcC(0, N0)) * ((HHH - wrcC(0, 0)) / (wrcC(1, 0) - wrcC(0, 0)))
4410:           N2 = wrcC(2, N0) + (wrcC(3, N0) - wrcC(2, N0)) * ((HHH - wrcC(2, 0)) / (wrcC(3, 0) - wrcC(2, 0)))
4420:           wrcC(4, N0) = N1 + (N2 - N1) * ((KKK - Q1) / (Q2 - Q1))
4430:       Next N0
4440:       For I0 = 5 To 7
4450:           If (1 / KKK) <= wrcM(4 * I0, 0) Then GoTo 4470
4460:       Next I0
4470:       Q2 = wrcM(4 * I0, 0)
4480:       Q1 = wrcM(4 * (I0 - 1), 0)
4490:       For J0 = 1 To 3
4500:           If HHH <= wrcM(4 * I0 + J0, 1) Then GoTo 4520
4510:       Next J0
4520:       For N0 = 0 To 4
4530:           wrcL(0, N0) = wrcM(4 * (I0 - 1) + (J0 - 1), N0 + 1)
4540:       Next N0
4550:       For N0 = 0 To 4
4560:           wrcL(1, N0) = wrcM(4 * (I0 - 1) + J0, N0 + 1)
4570:       Next N0
4580:       For N0 = 0 To 4
4590:           wrcL(2, N0) = wrcM(4 * I0 + (J0 - 1), N0 + 1)
4600:       Next N0
4610:       For N0 = 0 To 4
4620:           wrcL(3, N0) = wrcM(4 * I0 + J0, N0 + 1)
4630:       Next N0
4640:       For N0 = 1 To 4
4650:           N1 = wrcL(0, N0) + (wrcL(1, N0) - wrcL(0, N0)) * ((HHH - wrcL(0, 0)) / (wrcL(1, 0) - wrcL(0, 0)))
4660:           N2 = wrcL(2, N0) + (wrcL(3, N0) - wrcL(2, N0)) * ((HHH - wrcL(2, 0)) / (wrcL(3, 0) - wrcL(2, 0)))
4670:           wrcL(4, N0) = N1 + (N2 - N1) * (((1 / KKK) - Q1) / (Q2 - Q1))
4680:       Next N0
4690:       KKK3 = wrcC(4, 1)
4700:       K7 = wrcC(4, 2)
4710:       C1 = wrcC(4, 3)
4720:       C3 = wrcC(4, 4)
4730:       K4 = wrcL(4, 1)
4740:       K8 = wrcL(4, 2)
4750:       C2 = wrcL(4, 3)
4760:       C4 = wrcL(4, 4)
4770:       If (BETA1 / BETA2) < 1.0! Then GoTo 4800
4780:       y0 = ((BETA1 / BETA2) - 1) / 3.0!
4790:       GoTo 4810
4800:       y0 = 4.0! * (1 - (BETA1 / BETA2)) / 3.0!
4810:       y1 = System.Math.Sqrt(BETA1 * BETA2)
4820:       y2 = (BETA2 * BETA1 ^ 2) ^ (1.0! / 3.0!)
4830:       y3 = (BETA1 * BETA2 ^ 2) ^ (1.0! / 3.0!)
4840:       bbb(0) = (1 - y0 * KKK1) * y1
4850:       bbb(1) = (1 - y0 * KKK2) * y1
4860:       bbb(2) = K0 * y2
4870:       bbb(3) = KKK3 * y2
4880:       bbb(4) = K0 * y3
4890:       bbb(5) = K4 * y3
4900:       bbb(6) = (1 - y0 * K5) * y1
4910:       bbb(7) = (1 - y0 * K6) * y1
4920:       bbb(8) = K7 * y2
4930:       bbb(9) = K8 * y3
4940:       GoTo 5500
4950:       bbb(0) = BETA
4960:       bbb(1) = BETA
4970:       bbb(2) = BETA
4980:       bbb(3) = BETA
4990:       bbb(4) = BETA
5000:       bbb(5) = BETA
5010:       bbb(6) = BETA
5020:       bbb(7) = BETA
5030:       bbb(8) = BETA
5040:       bbb(9) = BETA
5050:       C1 = 1
5060:       C2 = 1
5070:       C3 = 1
5080:       C4 = 1
5500:       GG = GAMMA
5510:       If GG < 5.0! Then GoTo 5540
5520:       If GG > 300.0! Then GoTo 5640
            CalcParam = True
5530:       GoTo FineCalc
5540:       a = a & " mu=" & globalRoutines.myStr(GG, 4, 2, False) & " <   5 , OUT of RANGE of APPLICABLE CURVES"
            'GG = 5!
            SW = 1
            CalcParam = True
5630:       GoTo FineCalc
5640:       a = a & " mu=" & globalRoutines.myStr(GG, 4, 2, False) & " > 300 , OUT of RANGE of APPLICABLE CURVES"
            'GG = 150!
            SW = 1
            CalcParam = True
FineCalc:
            If Len(a) > 0 And Not GiaContinua = iB Then
                GiaContinua = iB
                a = Trim(Geom(iB).Mark) & "|" & a & "| Il calcolo continua."
                'MsgBox Monitor.clsInizio.ConvertiCr(a), vbInformation
                PrintlstRes(Trim(a))
            End If 'a
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try

    End Function

    Function CalcParamS(ByRef i As Short) As Boolean
        Dim a As String
        Dim D0 As Single
        Static GiaContinua As Short
        If NoRules Then Exit Function
        NoRules = False
        RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
        TT = Geom(iB).T0 : If Geom(iB).TX > TT Then TT = Geom(iB).TX
        CalcParamS = False
        a = ""
        If Geom(iB).Forma > 0 Then GoTo 3451
        U = RR / System.Math.Sqrt(Geom(iB).RM * Geom(iB).T)
        If Geom(iB).Buco > 0 Then GoTo 9000 '!!!!!!!!!!!!!!!!
        GAMMA = Geom(iB).RN / (TT - Geom(iB).CorrN)
        GoTo 3491
3451:   D0 = Geom(iB).D1
        U = (Geom(iB).D1 / 2) / (0.875 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
        If Geom(iB).Buco > 0 Then GoTo 9000
        GAMMA = (Geom(iB).D1 / 2) / (0.875 * (TT - Geom(iB).CorrN))
3491:   RHO = Geom(iB).T / (TT - Geom(iB).CorrN)
7010:   SV(1) = 0
7020:   SW = 0
7030:   U0 = U
7040:   If U >= 0.05 Then GoTo 7150
7050:   a = a & "| U=" & globalRoutines.myStr(U, 3, 3, False) & " <.05 , OUT of RANGE of APPLICABLE CURVES"
7130:   U0 = 0.05 : SV(1) = 1
7140:   GoTo 7250
7150:   If U <= 2.2 Then GoTo 7250
7160:   a = a & "| U=" & globalRoutines.myStr(U, 3, 3, False) & " >2.2 , OUT of RANGE of APPLICABLE CURVES"
7240:   U0 = 2.2 : SV(1) = 1
7250:   GG = GAMMA
7260:   If GG > 5.0! Then GoTo 7510
7270:   If RHO >= 0.25 Then GoTo 7320
        '7300 PRINT " WARNING !!! : rho< 0.25 , OUT of RANGE of APPLICABLE CURVES "
        '7310 PRINT "Abort": END
7320:   If RHO <= 4.0! Then GoTo 7370
        '7330 CLS
        '7340 LOCATE 10
        '7350 PRINT " WARNING !!! : rho > 4.00 , OUT of RANGE of APPLICABLE CURVES "
        '7360 PRINT "Abort": END
7370:   If GG = 5.0! Then GoTo 7470
7380:   a = a & "| æ=" & globalRoutines.myStr(GG, 3, 3, False) & " <  5 , OUT of RANGE of APPLICABLE CURVES"
7460:   GG = 5.0! : SW = 1
7470:   GG1 = 5.0! : GG2 = 5.0!
7480:   If RHO < 1.0! Then rrr(1) = 1 : rrr(2) = 5 : rrr(3) = 1 : rrr(4) = 5 : GoTo 8000
7490:   If RHO < 2.0! Then rrr(1) = 5 : rrr(2) = 9 : rrr(3) = 5 : rrr(4) = 9 : GoTo 8010
7500:   rrr(1) = 9 : rrr(2) = 13 : rrr(3) = 9 : rrr(4) = 13 : GoTo 8020
7510:   If GG > 15.0! Then GoTo 7750
7520:   If RHO >= 1.0! Then GoTo 7570
        '7530 CLS
        '7540 LOCATE 10
        '7550 PRINT " WARNING !!! : rho < 1.00 , OUT of RANGE of APPLICABLE CURVES "
        '7560 PRINT "Abort": END
7570:   If GG = 15.0! Then GoTo 7640
7580:   GG1 = 5.0! : GG2 = 15.0!
7590:   If RHO <= 4.0! Then GoTo 7700
        '7600 CLS
        '7610 LOCATE 10
        '7620 PRINT " WARNING !!! : rho > 4.00 , OUT of RANGE of APPLICABLE CURVES "
        '7630 PRINT "Abort": END
7640:   GG1 = 15.0! : GG2 = 15.0!
7650:   If RHO <= 10.0! Then GoTo 7720
        '7660 CLS
        '7670 LOCATE 10
        '7680 PRINT " WARNING !!! : rho > 10.0 , OUT of RANGE of APPLICABLE CURVES "
        '7690 PRINT "Abort": END
7700:   If RHO < 2.0! Then rrr(1) = 5 : rrr(2) = 9 : rrr(3) = 17 : rrr(4) = 21 : GoTo 8010
7710:   rrr(1) = 9 : rrr(2) = 13 : rrr(3) = 21 : rrr(4) = 25 : GoTo 8020
7720:   If RHO < 2.0! Then rrr(1) = 17 : rrr(2) = 21 : rrr(3) = 17 : rrr(4) = 21 : GoTo 8010
7730:   If RHO < 4.0! Then rrr(1) = 21 : rrr(2) = 25 : rrr(3) = 21 : rrr(4) = 25 : GoTo 8020
7740:   rrr(1) = 25 : rrr(2) = 29 : rrr(3) = 25 : rrr(4) = 29 : GoTo 8030
7750:   If RHO >= 4.0! Then GoTo 7800
        '7760 CLS
        '7770 LOCATE 10
        '7780 PRINT " WARNING !!! : rho < 4.00 , OUT of RANGE of APPLICABLE CURVES "
        '7790 PRINT "Abort": END
7800:   If RHO <= 10.0! Then GoTo 7850
        '7810 CLS
        '7820 LOCATE 10
        '7830 PRINT " WARNING !!! : rho > 10.0 , OUT of RANGE of APPLICABLE CURVES "
        '7840 PRINT "Abort": END
7850:   If GG = 50.0! Then GoTo 7960
7860:   If GG < 50.0! Then GoTo 7980
7870:   a = a & "| æ=" & globalRoutines.myStr(GG, 4, 2, False) & " > 50 , OUT of RANGE of APPLICABLE CURVES"
7950:   GG = 50.0! : SW = 1
7960:   rrr(1) = 33 : rrr(2) = 37 : rrr(3) = 33 : rrr(4) = 37
7970:   GG1 = 50.0! : GG2 = 50.0! : GoTo 8030
7980:   rrr(1) = 25 : rrr(2) = 29 : rrr(3) = 33 : rrr(4) = 37
7990:   GG1 = 15.0! : GG2 = 50.0! : GoTo 8030
8000:   RHO1 = 0.25 : RHO2 = 1.0! : GoTo 8040
8010:   RHO1 = 1.0! : RHO2 = 2.0! : GoTo 8040
8020:   RHO1 = 2.0! : RHO2 = 4.0! : GoTo 8040
8030:   RHO1 = 4.0! : RHO2 = 10.0! : GoTo 8040
8040:   For i = 0 To 38
8050:       If wrcU(i) > U0 Or i = 38 Then GoTo 8070
8060:   Next i
8070:   U1 = wrcU(i - 1)
8080:   U2 = wrcU(i)
        CalcParamS = True
        If Len(a) > 0 And Not GiaContinua = iB Then
            GiaContinua = iB
            a = "Nozzle " & Trim(Geom(iB).Mark) & "|" & a & "| Il calcolo continua."
            'MsgBox Monitor.clsInizio.ConvertiCr(a), vbInformation
            PrintlstRes(Trim(a))
        End If 'c
        Exit Function
9000:   a = "Il tipo di calcolo richiesto è disponibile soltanto con le regole BS5500-AppG"
        MsgBox(a, MsgBoxStyle.Information)
        NoRules = True
        '9010 'Print " U = ro/û[Rm*T]                             = ";
        '9020 'Print USING; "##.####"; U
        '9030 'Print
        '9040 INPUT " Enter     (Nx*T)/P              from   Fig.SR-2    = "; KRead(7)
        '9050 INPUT " Enter     (Mx)/P                from   Fig.SR-2    = "; KRead(8)
        '9060 INPUT " Enter     (Nx*T*û[Rm*T])/M      from   Fig.SR-3    = "; KRead(3)
        '9070 INPUT " Enter     (Mx*û[Rm*T])/M        from   Fig.SR-3    = "; KRead(4)
        '9080 INPUT " Enter     (Ny*T)/P              from   Fig.SR-2    = "; KRead(1)
        '9090 INPUT " Enter     (My)/P                from   Fig.SR-2    = "; KRead(2)
        '9100 INPUT " Enter     (Ny*T*û[Rm*T])/M      from   Fig.SR-3    = "; KRead(9)
        '9110 INPUT " Enter     (My*û[Rm*T])/M        from   Fig.SR-3    = "; KRead(10)
    End Function

    Sub CalcSfe()
        Dim RR, EndEffect, Y As Single
        Dim Vc, AML, AMc, AMt, Vl As Single
        Dim UM, UI, UO As Single
        Dim ZM, ZI, ZO As Single
        Try
            Call Compos(EndEffect, AMc, AML, AMt, Vc, Vl)
            RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
10000:      S11 = KRead(7) * EndEffect / Geom(iB).T ^ 2
10010:      S12 = KRead(7) * EndEffect / Geom(iB).T ^ 2
10020:      S21 = KRead(8) * 6 * EndEffect / Geom(iB).T ^ 2
10030:      S22 = KRead(8) * 6 * EndEffect / Geom(iB).T ^ 2
10040:      S3 = KRead(3) * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10050:      S4 = KRead(4) * 6 * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10060:      S5 = KRead(3) * AML / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10070:      S6 = KRead(4) * 6 * AML / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10080:      Z11 = KRead(1) * EndEffect / Geom(iB).T ^ 2
10090:      Z12 = KRead(1) * EndEffect / Geom(iB).T ^ 2
10100:      Z21 = KRead(2) * 6 * EndEffect / Geom(iB).T ^ 2
10110:      Z22 = KRead(2) * 6 * EndEffect / Geom(iB).T ^ 2
10120:      Z3 = KRead(9) * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10130:      Z4 = KRead(10) * 6 * AMc / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10140:      Z5 = KRead(9) * AML / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
10150:      Z6 = KRead(10) * 6 * AML / (Geom(iB).T ^ 2 * System.Math.Sqrt(Geom(iB).RM * Geom(iB).T))
            '      END IF    'd       ?????
10160:      If Geom(iB).Forma > 0 Then GoTo 10210
10170:      TTT3 = Vl / (PI * RR * Geom(iB).T)
10180:      TTT2 = Vc / (PI * RR * Geom(iB).T)
10190:      TTT1 = AMt / (2 * PI * RR ^ 2 * Geom(iB).T)
10200:      GoTo 11000
10210:      TTT2 = 2 * Vc / (Geom(iB).D1 * Geom(iB).T)
10220:      TTT3 = 2 * Vl / (Geom(iB).D2 * Geom(iB).T)
10230:      TTT1 = 2 * AMt / (PI * Geom(iB).D1 * Geom(iB).D2 * Geom(iB).T)
11000:      Y = (Geom(iB).RO / Geom(iB).RI)
11010:      UI = 1
11020:      UM = (Geom(iB).RI / Geom(iB).R)
11030:      UO = (Geom(iB).RI / Geom(iB).RO)
11040:      ZI = (Geom(iB).RO / Geom(iB).RI)
11050:      ZM = (Geom(iB).RO / Geom(iB).R)
11060:      ZO = 1
11070:      If Geom(iB).Carichi(iC).DesPress > 0 Then
11080:          PIC = 0.5 * Geom(iB).Carichi(iC).DesPress * (ZI ^ 3 + 2) / (Y ^ 3 - 1)
11090:          PMC = 0.5 * Geom(iB).Carichi(iC).DesPress * (ZM ^ 3 + 2) / (Y ^ 3 - 1)
11100:          POC = 0.5 * Geom(iB).Carichi(iC).DesPress * (ZO ^ 3 + 2) / (Y ^ 3 - 1)
11110:          PIL = 0.5 * Geom(iB).Carichi(iC).DesPress * (ZI ^ 3 + 2) / (Y ^ 3 - 1)
11120:          PML = 0.5 * Geom(iB).Carichi(iC).DesPress * (ZM ^ 3 + 2) / (Y ^ 3 - 1)
11130:          POL = 0.5 * Geom(iB).Carichi(iC).DesPress * (ZO ^ 3 + 2) / (Y ^ 3 - 1)
11140:          PIR = Geom(iB).Carichi(iC).DesPress * (1 - ZI ^ 3) / (Y ^ 3 - 1)
11150:          PMR = Geom(iB).Carichi(iC).DesPress * (1 - ZM ^ 3) / (Y ^ 3 - 1)
11160:          POR = Geom(iB).Carichi(iC).DesPress * (1 - ZO ^ 3) / (Y ^ 3 - 1)
            Else
11180:          PIC = 0.5 * Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UI ^ 3 + 2) / (Y ^ 3 - 1))
11190:          PMC = 0.5 * Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UM ^ 3 + 2) / (Y ^ 3 - 1))
11200:          POC = 0.5 * Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UO ^ 3 + 2) / (Y ^ 3 - 1))
11210:          PIL = 0.5 * Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UI ^ 3 + 2) / (Y ^ 3 - 1))
11220:          PML = 0.5 * Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UM ^ 3 + 2) / (Y ^ 3 - 1))
11230:          POL = 0.5 * Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UO ^ 3 + 2) / (Y ^ 3 - 1))
11240:          PIR = -Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UI ^ 3 - 1) / (Y ^ 3 - 1))
11250:          PMR = -Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UM ^ 3 - 1) / (Y ^ 3 - 1))
11260:          POR = -Geom(iB).Carichi(iC).DesPress * Y ^ 3 * ((UO ^ 3 - 1) / (Y ^ 3 - 1))
            End If 'e
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub CalcwrcN()
        Dim i, iSeg, iP4 As Short
        Dim j, j1 As Short
        Dim SS2, SS0, SS1, SS3 As Single
        Dim SS, SC As Single
        If ((Config.WRC297 < 3 Or Config.ConvSumm = 1) And Geom(iB).ShellType = 0) Or Geom(iB).ShellType = 1 Then
            iSeg = 1 : If Config.WRC297 >= 3 Then iSeg = -1
            For i = 1 To 8
                iP4 = -CShort(i < 5)
                wrcN(ShellNoz, 1, i) = (-S11 * iP4 - S12 * (1 - iP4)) * iSeg
                wrcN(ShellNoz, 2, i) = -S21 * 2 * (i Mod 2 - 0.5) * iP4 - S22 * 2 * (i Mod 2 - 0.5) * (1 - iP4)
                wrcN(ShellNoz, 7, i) = (-Z11 * iP4 - Z12 * (1 - iP4)) * iSeg
                wrcN(ShellNoz, 8, i) = -Z21 * 2 * (i Mod 2 - 0.5) * iP4 - Z22 * 2 * (i Mod 2 - 0.5) * (1 - iP4)
                Call SigPress(i)
            Next
            If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                For i = 5 To 8
                    globalRoutines.SWAP(wrcO(ShellNoz, 7, i), wrcO(ShellNoz, 8, i))
                    globalRoutines.SWAP(wrcO(ShellNoz, 10, i), wrcO(ShellNoz, 11, i))
                Next
            End If 'h
11660:      wrcN(ShellNoz, 3, 1) = 0
11670:      wrcN(ShellNoz, 3, 2) = 0
11680:      wrcN(ShellNoz, 3, 3) = 0
11690:      wrcN(ShellNoz, 3, 4) = 0
11700:      wrcN(ShellNoz, 3, 5) = (-S3)
11710:      wrcN(ShellNoz, 3, 6) = (-S3)
11720:      wrcN(ShellNoz, 3, 7) = (S3)
11730:      wrcN(ShellNoz, 3, 8) = (S3)
11740:      wrcN(ShellNoz, 4, 1) = 0
11750:      wrcN(ShellNoz, 4, 2) = 0
11760:      wrcN(ShellNoz, 4, 3) = 0
11770:      wrcN(ShellNoz, 4, 4) = 0
11780:      wrcN(ShellNoz, 4, 5) = (-S4)
11790:      wrcN(ShellNoz, 4, 6) = (S4)
11800:      wrcN(ShellNoz, 4, 7) = (S4)
11810:      wrcN(ShellNoz, 4, 8) = (-S4)
11820:      wrcN(ShellNoz, 5, 1) = (-S5)
11830:      wrcN(ShellNoz, 5, 2) = (-S5)
11840:      wrcN(ShellNoz, 5, 3) = (S5)
11850:      wrcN(ShellNoz, 5, 4) = (S5)
11860:      wrcN(ShellNoz, 5, 5) = 0
11870:      wrcN(ShellNoz, 5, 6) = 0
11880:      wrcN(ShellNoz, 5, 7) = 0
11890:      wrcN(ShellNoz, 5, 8) = 0
11900:      wrcN(ShellNoz, 6, 1) = (-S6)
11910:      wrcN(ShellNoz, 6, 2) = (S6)
11920:      wrcN(ShellNoz, 6, 3) = (S6)
11930:      wrcN(ShellNoz, 6, 4) = (-S6)
11940:      wrcN(ShellNoz, 6, 5) = 0
11950:      wrcN(ShellNoz, 6, 6) = 0
11960:      wrcN(ShellNoz, 6, 7) = 0
11970:      wrcN(ShellNoz, 6, 8) = 0
12140:      wrcN(ShellNoz, 9, 1) = 0
12150:      wrcN(ShellNoz, 9, 2) = 0
12160:      wrcN(ShellNoz, 9, 3) = 0
12170:      wrcN(ShellNoz, 9, 4) = 0
12180:      wrcN(ShellNoz, 9, 5) = (-Z3)
12190:      wrcN(ShellNoz, 9, 6) = (-Z3)
12200:      wrcN(ShellNoz, 9, 7) = (Z3)
12210:      wrcN(ShellNoz, 9, 8) = (Z3)
12220:      wrcN(ShellNoz, 10, 1) = 0
12230:      wrcN(ShellNoz, 10, 2) = 0
12240:      wrcN(ShellNoz, 10, 3) = 0
12250:      wrcN(ShellNoz, 10, 4) = 0
12260:      wrcN(ShellNoz, 10, 5) = (-Z4)
12270:      wrcN(ShellNoz, 10, 6) = (Z4)
12280:      wrcN(ShellNoz, 10, 7) = (Z4)
12290:      wrcN(ShellNoz, 10, 8) = (-Z4)
12300:      wrcN(ShellNoz, 11, 1) = (-Z5)
12310:      wrcN(ShellNoz, 11, 2) = (-Z5)
12320:      wrcN(ShellNoz, 11, 3) = (Z5)
12330:      wrcN(ShellNoz, 11, 4) = (Z5)
12340:      wrcN(ShellNoz, 11, 5) = 0
12350:      wrcN(ShellNoz, 11, 6) = 0
12360:      wrcN(ShellNoz, 11, 7) = 0
12370:      wrcN(ShellNoz, 11, 8) = 0
12380:      wrcN(ShellNoz, 12, 1) = (-Z6)
12390:      wrcN(ShellNoz, 12, 2) = (Z6)
12400:      wrcN(ShellNoz, 12, 3) = (Z6)
12410:      wrcN(ShellNoz, 12, 4) = (-Z6)
12420:      wrcN(ShellNoz, 12, 5) = 0
12430:      wrcN(ShellNoz, 12, 6) = 0
12440:      wrcN(ShellNoz, 12, 7) = 0
12450:      wrcN(ShellNoz, 12, 8) = 0
12700:      wrcO(ShellNoz, 1, 1) = (-S11 * iSeg - S5)
12710:      wrcO(ShellNoz, 1, 2) = (-S11 * iSeg - S5)
12720:      wrcO(ShellNoz, 1, 3) = (-S11 * iSeg + S5)
12730:      wrcO(ShellNoz, 1, 4) = (-S11 * iSeg + S5)
12740:      wrcO(ShellNoz, 1, 5) = (-S12 * iSeg - S3)
12750:      wrcO(ShellNoz, 1, 6) = (-S12 * iSeg - S3)
12760:      wrcO(ShellNoz, 1, 7) = (-S12 * iSeg + S3)
12770:      wrcO(ShellNoz, 1, 8) = (-S12 * iSeg + S3)
12780:      wrcO(ShellNoz, 2, 1) = (-Z11 * iSeg - Z5)
12790:      wrcO(ShellNoz, 2, 2) = (-Z11 * iSeg - Z5)
12800:      wrcO(ShellNoz, 2, 3) = (-Z11 * iSeg + Z5)
12810:      wrcO(ShellNoz, 2, 4) = (-Z11 * iSeg + Z5)
12820:      wrcO(ShellNoz, 2, 5) = (-Z12 * iSeg - Z3)
12830:      wrcO(ShellNoz, 2, 6) = (-Z12 * iSeg - Z3)
12840:      wrcO(ShellNoz, 2, 7) = (-Z12 * iSeg + Z3)
12850:      wrcO(ShellNoz, 2, 8) = (-Z12 * iSeg + Z3)
12860:      wrcO(ShellNoz, 3, 1) = (TTT1 + TTT2)
12870:      wrcO(ShellNoz, 3, 2) = (TTT1 + TTT2)
12880:      wrcO(ShellNoz, 3, 3) = (TTT1 - TTT2)
12890:      wrcO(ShellNoz, 3, 4) = (TTT1 - TTT2)
12900:      wrcO(ShellNoz, 3, 5) = (TTT1 - TTT3)
12910:      wrcO(ShellNoz, 3, 6) = (TTT1 - TTT3)
12920:      wrcO(ShellNoz, 3, 7) = (TTT1 + TTT3)
12930:      wrcO(ShellNoz, 3, 8) = (TTT1 + TTT3)
12940:      wrcO(ShellNoz, 4, 1) = (-S11 * iSeg - S21 - S5 - S6)
12950:      wrcO(ShellNoz, 4, 2) = (-S11 * iSeg + S21 - S5 + S6)
12960:      wrcO(ShellNoz, 4, 3) = (-S11 * iSeg - S21 + S5 + S6)
12970:      wrcO(ShellNoz, 4, 4) = (-S11 * iSeg + S21 + S5 - S6)
12980:      wrcO(ShellNoz, 4, 5) = (-S12 * iSeg - S22 - S3 - S4)
12990:      wrcO(ShellNoz, 4, 6) = (-S12 * iSeg + S22 - S3 + S4)
13000:      wrcO(ShellNoz, 4, 7) = (-S12 * iSeg - S22 + S3 + S4)
13010:      wrcO(ShellNoz, 4, 8) = (-S12 * iSeg + S22 + S3 - S4)
13020:      wrcO(ShellNoz, 5, 1) = (-Z11 * iSeg - Z21 - Z5 - Z6)
13030:      wrcO(ShellNoz, 5, 2) = (-Z11 * iSeg + Z21 - Z5 + Z6)
13040:      wrcO(ShellNoz, 5, 3) = (-Z11 * iSeg - Z21 + Z5 + Z6)
13050:      wrcO(ShellNoz, 5, 4) = (-Z11 * iSeg + Z21 + Z5 - Z6)
13060:      wrcO(ShellNoz, 5, 5) = (-Z12 * iSeg - Z22 - Z3 - Z4)
13070:      wrcO(ShellNoz, 5, 6) = (-Z12 * iSeg + Z22 - Z3 + Z4)
13080:      wrcO(ShellNoz, 5, 7) = (-Z12 * iSeg - Z22 + Z3 + Z4)
13090:      wrcO(ShellNoz, 5, 8) = (-Z12 * iSeg + Z22 + Z3 - Z4)
13100:      wrcO(ShellNoz, 6, 1) = (TTT1 + TTT2)
13110:      wrcO(ShellNoz, 6, 2) = (TTT1 + TTT2)
13120:      wrcO(ShellNoz, 6, 3) = (TTT1 - TTT2)
13130:      wrcO(ShellNoz, 6, 4) = (TTT1 - TTT2)
13140:      wrcO(ShellNoz, 6, 5) = (TTT1 - TTT3)
13150:      wrcO(ShellNoz, 6, 6) = (TTT1 - TTT3)
13160:      wrcO(ShellNoz, 6, 7) = (TTT1 + TTT3)
13170:      wrcO(ShellNoz, 6, 8) = (TTT1 + TTT3)
12460:      wrcN(ShellNoz, 13, 1) = (TTT1)
12470:      wrcN(ShellNoz, 13, 2) = (TTT1)
12480:      wrcN(ShellNoz, 13, 3) = (TTT1)
12490:      wrcN(ShellNoz, 13, 4) = (TTT1)
12500:      wrcN(ShellNoz, 13, 5) = (TTT1)
12510:      wrcN(ShellNoz, 13, 6) = (TTT1)
12520:      wrcN(ShellNoz, 13, 7) = (TTT1)
12530:      wrcN(ShellNoz, 13, 8) = (TTT1)
12540:      wrcN(ShellNoz, 14, 1) = (TTT2)
12550:      wrcN(ShellNoz, 14, 2) = (TTT2)
12560:      wrcN(ShellNoz, 14, 3) = (-TTT2)
12570:      wrcN(ShellNoz, 14, 4) = (-TTT2)
12580:      wrcN(ShellNoz, 14, 5) = 0
12590:      wrcN(ShellNoz, 14, 6) = 0
12600:      wrcN(ShellNoz, 14, 7) = 0
12610:      wrcN(ShellNoz, 14, 8) = 0
12620:      wrcN(ShellNoz, 15, 1) = 0
12630:      wrcN(ShellNoz, 15, 2) = 0
12640:      wrcN(ShellNoz, 15, 3) = 0
12650:      wrcN(ShellNoz, 15, 4) = 0
12660:      wrcN(ShellNoz, 15, 5) = (-TTT3)
12670:      wrcN(ShellNoz, 15, 6) = (-TTT3)
12680:      wrcN(ShellNoz, 15, 7) = (TTT3)
12690:      wrcN(ShellNoz, 15, 8) = (TTT3)
        Else
            For i = 1 To 8
                j = 2 * (i Mod 2 - 0.5)
                j1 = j : If i = 3 Or i = 4 Or i = 7 Or i = 8 Then j1 = -j
                wrcN(ShellNoz, 1, i) = S11
                wrcN(ShellNoz, 2, i) = S21 * j
                wrcN(ShellNoz, 4, i) = S4 * j
                wrcN(ShellNoz, 6, i) = S6 * j1
                wrcN(ShellNoz, 7, i) = Z11
                wrcN(ShellNoz, 8, i) = Z21 * j
                wrcN(ShellNoz, 10, i) = Z4 * j
                wrcN(ShellNoz, 12, i) = Z6 * j1
                Call SigPress(i)
            Next
            For i = 1 To 4
                j = i - 2 : If j < 1 Then j = j + 8
                wrcN(ShellNoz, 3, i) = S3
                wrcN(ShellNoz, 5, j) = S5
                wrcN(ShellNoz, 9, i) = Z3
                wrcN(ShellNoz, 11, j) = Z5
            Next
            For i = 5 To 8
                wrcN(ShellNoz, 3, i) = -S3
                wrcN(ShellNoz, 5, i - 2) = -S5
                wrcN(ShellNoz, 9, i) = -Z3
                wrcN(ShellNoz, 11, i - 2) = -Z5
            Next
            For i = 1 To 8
                wrcO(ShellNoz, 1, i) = wrcN(ShellNoz, 1, i) + wrcN(ShellNoz, 3, i) + wrcN(ShellNoz, 5, i)
                wrcO(ShellNoz, 2, i) = wrcN(ShellNoz, 7, i) + wrcN(ShellNoz, 9, i) + wrcN(ShellNoz, 11, i)
                wrcO(ShellNoz, 3, i) = System.Math.Abs(TTT1) + System.Math.Abs(TTT2) + System.Math.Abs(TTT3)
                wrcO(ShellNoz, 4, i) = wrcO(ShellNoz, 1, i) + wrcN(ShellNoz, 2, i) + wrcN(ShellNoz, 4, i) + wrcN(ShellNoz, 6, i)
                wrcO(ShellNoz, 5, i) = wrcO(ShellNoz, 2, i) + wrcN(ShellNoz, 8, i) + wrcN(ShellNoz, 10, i) + wrcN(ShellNoz, 12, i)
                wrcO(ShellNoz, 6, i) = System.Math.Abs(TTT1) + System.Math.Abs(TTT2) + System.Math.Abs(TTT3)
            Next
            For i = 1 To 8
                wrcN(ShellNoz, 13, i) = TTT1
                wrcN(ShellNoz, 14, i) = TTT2
                wrcN(ShellNoz, 15, i) = TTT3
            Next
        End If 'i
        For i = 1 To 8
13660:      wrcO(ShellNoz, 13, i) = wrcO(ShellNoz, 1, i) + wrcO(ShellNoz, 7, i)
13740:      wrcO(ShellNoz, 14, i) = wrcO(ShellNoz, 2, i) + wrcO(ShellNoz, 8, i)
13820:      wrcO(ShellNoz, 15, i) = wrcO(ShellNoz, 9, i)
13900:      wrcO(ShellNoz, 16, i) = wrcO(ShellNoz, 3, i)
13980:      wrcO(ShellNoz, 17, i) = wrcO(ShellNoz, 4, i) + wrcO(ShellNoz, 10, i)
14060:      wrcO(ShellNoz, 18, i) = wrcO(ShellNoz, 5, i) + wrcO(ShellNoz, 11, i)
14140:      wrcO(ShellNoz, 19, i) = wrcO(ShellNoz, 12, i)
14220:      wrcO(ShellNoz, 20, i) = wrcO(ShellNoz, 6, i)
        Next
14300:  For i = 0 To 1
14310:      For j = 1 To 8
                SS0 = 0 : SS = 0
                On Error Resume Next
14320:          SS0 = System.Math.Sqrt((wrcO(ShellNoz, 13 + 4 * i, j) - wrcO(ShellNoz, 14 + 4 * i, j)) ^ 2 + 4 * wrcO(ShellNoz, 16 + 4 * i, j) ^ 2)
14330:          SS1 = System.Math.Abs(0.5 * (wrcO(ShellNoz, 13 + 4 * i, j) + wrcO(ShellNoz, 14 + 4 * i, j) + SS0) - wrcO(ShellNoz, 15 + 4 * i, j))
14340:          SS2 = System.Math.Abs(0.5 * (wrcO(ShellNoz, 13 + 4 * i, j) + wrcO(ShellNoz, 14 + 4 * i, j) - SS0) - wrcO(ShellNoz, 15 + 4 * i, j))
14350:          SS3 = System.Math.Abs(SS0 - wrcO(ShellNoz, 15 + 4 * i, j))
14360:          If SS1 > SS2 Then SS = SS1 Else SS = SS2
14370:          If SS3 > SS Then SS = SS3
14380:          wrcO(ShellNoz, 21 + i, j) = SS
14390:      Next j
14400:  Next i
14410:  If Config.UnitSis < 2 Then GoTo 14520
14420:  For i = 1 To 15
14430:      For j = 1 To 8
14440:          wrcN(ShellNoz, i, j) = 0.001 * wrcN(ShellNoz, i, j)
14450:      Next j
14460:  Next i
14470:  For i = 1 To 22
14480:      For j = 1 To 8
14490:          wrcO(ShellNoz, i, j) = 0.001 * wrcO(ShellNoz, i, j)
14500:      Next j
14510:  Next i
14520:  SC = 0
14530:  Result(ShellNoz, iC, iB).SP = 0
14540:  Result(ShellNoz, iC, iB).Sq = 0
14550:  For i = 1 To 3
14560:      For j = 1 To 8
14570:          If wrcO(ShellNoz, i + 12, j) > 0 Then GoTo 14600
14580:          If wrcO(ShellNoz, i + 12, j) > SC Then GoTo 14600
14590:          SC = wrcO(ShellNoz, i + 12, j)
14600:      Next j
14610:  Next i
14620:  For i = 1 To 3
14630:      For j = 1 To 8
14640:          If wrcO(ShellNoz, i + 16, j) > 0 Then GoTo 14670
14650:          If wrcO(ShellNoz, i + 16, j) > SC Then GoTo 14670
14660:          SC = wrcO(ShellNoz, i + 16, j)
14670:      Next j
14680:  Next i
14690:  For j = 1 To 8
14700:      If wrcO(ShellNoz, 21, j) > Result(ShellNoz, iC, iB).SP Then Result(ShellNoz, iC, iB).SP = wrcO(ShellNoz, 21, j)
14710:  Next j
14720:  For j = 1 To 8
14730:      If wrcO(ShellNoz, 22, j) > Result(ShellNoz, iC, iB).Sq Then Result(ShellNoz, iC, iB).Sq = wrcO(ShellNoz, 22, j)
14740:  Next j
        For j = 1 To 8
            wrcO(ShellNoz, 23, j) = 0
            wrcO(ShellNoz, 24, j) = 0
            If wrcO(ShellNoz, 1, j) < 0 Then wrcO(ShellNoz, 23, j) = wrcO(ShellNoz, 4, j) Else wrcO(ShellNoz, 23, j) = 0
            If wrcO(ShellNoz, 2, j) < 0 Then wrcO(ShellNoz, 24, j) = wrcO(ShellNoz, 5, j) Else wrcO(ShellNoz, 24, j) = 0
        Next
        Result(ShellNoz, iC, iB).Bu = 0
        For j = 1 To 8
            If System.Math.Abs(wrcO(ShellNoz, 23, j)) > Result(ShellNoz, iC, iB).Bu And wrcO(ShellNoz, 23, j) < 0 Then Result(ShellNoz, iC, iB).Bu = System.Math.Abs(wrcO(ShellNoz, 23, j))
            If System.Math.Abs(wrcO(ShellNoz, 24, j)) > Result(ShellNoz, iC, iB).Bu And wrcO(ShellNoz, 24, j) < 0 Then Result(ShellNoz, iC, iB).Bu = System.Math.Abs(wrcO(ShellNoz, 24, j))
        Next
        Exit Sub
    End Sub
    Private Sub SigPress(ByVal i As Short)
        wrcO(ShellNoz, 7, i) = PMC
        wrcO(ShellNoz, 8, i) = PML
        wrcO(ShellNoz, 9, i) = PMR
        wrcO(ShellNoz, 10, i) = POC * (i Mod 2) + PIC * (1 - i Mod 2)
        wrcO(ShellNoz, 11, i) = POL * (i Mod 2) + PIL * (1 - i Mod 2)
        wrcO(ShellNoz, 12, i) = POR * (i Mod 2) + PIR * (1 - i Mod 2)
        If Config.WRC297 > 2 And Not (Geom(iB).ShellType = 1) Then
            wrcO(ShellNoz, 7, i) = PMCbrut
            wrcO(ShellNoz, 8, i) = PMLbrut
            wrcO(ShellNoz, 9, i) = 0
            wrcO(ShellNoz, 10, i) = PMC 'wrcO(ShellNoz, 7, i)
            wrcO(ShellNoz, 11, i) = PML 'wrcO(ShellNoz, 8, i)
            wrcO(ShellNoz, 12, i) = 0
        End If 'g
    End Sub
    Sub LeggiSfe(ByRef i As Short) 'qualcosa di strano
        Try
            Dim Rec As New Rec39
            Rec.Initialize()
            Dim j, k As Short
            Dim V(32, 2) As Single
            Dim W(32) As Single
            Dim X(16) As Single
            Dim Y(10) As Single
            Dim VAL1, VAL2 As Single
            ifllib = FreeFile()
8090:       FileOpen(ifllib, RTrim(Monitor.clsInizio.Archdir) & "\WR\BIJSFERA.DAT", OpenMode.Random, , OpenShare.Shared, 156)
            '8100 FIELD #ifllib, 156 AS Campo$
8110:       For k = 1 To 4
8120:           For j = 1 To 4
8130:               'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
                    FileGet(ifllib, Rec, rrr(k) + j - 1)
                    '8140 s$ = Mid$(Campo$, (4 * (i - 1) + 1), 4)
8150:               V(k + 4 * (j - 1), 1) = Rec.Valor(i) ' CVSMBF(s$)
                    '8160 s$ = Mid$(Campo$, (4 * i + 1), 4)
8170:               V(k + 4 * (j - 1), 2) = Rec.Valor(i + 1) 'CVSMBF(s$)
8180:           Next j
8190:       Next k
8200:       For k = 1 To 4
8210:           For j = 1 To 4
8220:               'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
                    FileGet(ifllib, Rec, rrr(k) + j + 39)
                    '8230 's$ = Mid$(Campo$, (4 * (i - 1) + 1), 4)
8240:               V(k + 4 * (j - 1) + 16, 1) = Rec.Valor(i) 'CVSMBF(s$)
                    '8250 s$ = Mid$(Campo$, (4 * i + 1), 4)
8260:               V(k + 4 * (j - 1) + 16, 2) = Rec.Valor(i + 1) 'CVSMBF(s$)
8270:           Next j
8280:       Next k
8290:       FileClose(ifllib)
8300:       For i = 1 To 8
8310:           For j = 1 To 4
8320:               VAL1 = V(4 * (i - 1) + j, 1)
8330:               VAL2 = V(4 * (i - 1) + j, 2)
                    '   CORRETTA INTERPOLAZIONE BILOGARITMICA
                    '8340 W(4 * (i - 1) + j) = EXP(LOG(VAL1) + LOG(VAL2 / VAL1) * (u - U1) / (U2 - U1))
                    W(4 * (i - 1) + j) = System.Math.Exp(System.Math.Log(VAL1) + System.Math.Log(VAL2 / VAL1) * System.Math.Log(U / U1) / System.Math.Log(U2 / U1))
8350:           Next j
8360:       Next i
8370:       For i = 1 To 8
8380:           For j = 1 To 2
8390:               VAL1 = W(4 * (i - 1) + 2 * j - 1)
8400:               VAL2 = W(4 * (i - 1) + 2 * j)
8410:               X(2 * (i - 1) + j) = VAL1 + (VAL2 - VAL1) * (RHO - RHO1) / (RHO2 - RHO1)
                    ' COLOR 14, 1
8420:           Next j
8430:       Next i
8440:       For i = 1 To 8
8450:           VAL1 = X(2 * i - 1)
8460:           VAL2 = X(2 * i)
8470:           If GG1 = GG2 Then Y(i) = VAL1 : GoTo 8490
8480:           Y(i) = VAL1 + (VAL2 - VAL1) * (GG - GG1) / (GG2 - GG1)
8490:       Next i
8500:       KRead(7) = Y(1) 'K1X = Y(1)
8510:       KRead(8) = Y(2) 'K2X = Y(2)
8520:       KRead(1) = Y(3) 'K1Y = Y(3)
8530:       KRead(2) = Y(4) 'K2Y = Y(4)
8540:       KRead(3) = Y(5) 'K3X = Y(5)
8550:       KRead(4) = Y(6) 'K4X = Y(6)
            KRead(5) = KRead(3)
            KRead(6) = KRead(4)
8560:       KRead(9) = Y(7) 'K3Y = Y(7)
8570:       KRead(10) = Y(8) 'K4Y = Y(8)
            KRead(11) = KRead(9)
            KRead(12) = KRead(10)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub LegWRC(ByRef BB As Single, ByRef P0S As Short, ByRef Fig As String, ByRef BBout As Single, ByRef SVLoc As Short, ByRef Valor As Single, ByRef a As String)
        Try
            Dim Rec As New Rec17
            Rec.Initialize()
            Dim i, j As Short
            Dim BET1, BET2 As Single
            Dim GAM1, GAM2 As Single
            Dim VAL3, VAL1, VAL2, VAL4 As Single
            Dim VALG1, VALG2 As Single
            Dim LINE3, LINE1, LINE2, LINE4 As Short
            a = ""
            BBout = BB
17000:      SVLoc = 0
17010:      If BB < 0.03 Then GoTo 17040
17020:      If BB > 0.51 Then GoTo 17150
17030:      GoTo 17250
17040:      a = a & "|á=" & globalRoutines.myStr(BB, 3, 3, False) & " < 0.03 , OUT of RANGE of CURVES in FIG." & Fig
17130:      BBout = 0.03 : SVLoc = 1
17140:      GoTo 17250
17150:      a = a & "|á=" & globalRoutines.myStr(BB, 3, 3, False) & " > 0.51 ; OUT of RANGE of CURVES in FIG." & Fig
17240:      BBout = 0.51 : SVLoc = 1
17250:      For i = 0 To 16
17260:          If wrcbB(i) > BBout Or i = 16 Then Exit For
17270:      Next i
            BET1 = wrcbB(i - 1)
17290:      BET2 = wrcbB(i)
17300:      For j = 0 To 9
17310:          If wrcG(j) > GG Or j = 9 Then GoTo 17330
17320:      Next j
17330:      If j = 0 Then j = 1
            GAM1 = wrcG(j - 1)
17340:      GAM2 = wrcG(j)
17350:      LINE1 = 17 * (j - 1) + i + 2
17360:      LINE2 = 17 * (j - 1) + (i + 1) + 2
17370:      LINE3 = 17 * j + i + 2
17380:      LINE4 = 17 * j + (i + 1) + 2
17390:      'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            FileGet(ifllib, Rec, LINE1)
            '17400 s$ = Mid$(Campo$, ((P0S - 1) * 4 + 1), 4)
17410:      VAL1 = Rec.Valor(P0S) 'CVSMBF(s$)
17420:      'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            FileGet(ifllib, Rec, LINE2)
            '17430 s$ = Mid$(Campo$, ((P0S - 1) * 4 + 1), 4)
17440:      VAL2 = Rec.Valor(P0S) 'CVSMBF(s$)
17450:      'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            FileGet(ifllib, Rec, LINE3)
            '17460 s$ = Mid$(Campo$, ((P0S - 1) * 4 + 1), 4)
17470:      VAL3 = Rec.Valor(P0S) 'CVSMBF(s$)
17480:      'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            FileGet(ifllib, Rec, LINE4)
            '17490 s$ = Mid$(Campo$, ((P0S - 1) * 4 + 1), 4)
17500:      VAL4 = Rec.Valor(P0S) 'CVSMBF(s$)
17510:      VALG1 = System.Math.Exp(System.Math.Log(VAL1) + System.Math.Log(VAL2 / VAL1) * (BBout - BET1) / (BET2 - BET1))
17520:      VALG2 = System.Math.Exp(System.Math.Log(VAL3) + System.Math.Log(VAL4 / VAL3) * (BBout - BET1) / (BET2 - BET1))
            '17530 VALOR = VALG1 + (VALG2 - VALG1) * (GG - GAM1) / (GAM2 - GAM1)
            '17530 VALOR = EXP(LOG(VALG1) + LOG(VALG2 / VALG1) * (GG - GAM1) / (GAM2 - GAM1))
            Valor = globalRoutines.InterLogar(GG, GAM1, GAM2, VALG1, VALG2)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub LegWRC7(ByRef dsut As Single, ByRef Alam As Single, ByRef Tsut As Single, ByRef iRead As Short)
        Dim i1, i2 As Short
        Dim ds1, ds2 As Single
        Dim stri1, stri2 As String
        Dim xxx1, Para1, Para2, xxx2 As Single
        Dim xFig1, xFig2 As Single
        Dim FileFig As String
        Try
            Select Case iRead
                Case 1 'mr  P
                    If dsut < 20 Then
10:                     i1 = 3 : i2 = 4 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 4 : i2 = 5 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 5 : i2 = 6 : ds1 = 30 : ds2 = 50
                    Else 'q
                        i1 = 6 : i2 = 7 : ds1 = 50 : ds2 = 100
                    End If 't
                Case 2 'mr Mc
                    If dsut < 20 Then
20:                     i1 = 23 : i2 = 24 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 30 Then
                        i1 = 23 : i2 = 24 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 24 : i2 = 25 : ds1 = 30 : ds2 = 50
                    Else 'r
                        i1 = 25 : i2 = 26 : ds1 = 50 : ds2 = 100
                    End If 'q
                Case 3 ' mr ML
                    If dsut < 20 Then
30:                     i1 = 41 : i2 = 42 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 30 Then
                        i1 = 41 : i2 = 42 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 42 : i2 = 43 : ds1 = 30 : ds2 = 50
                    Else 's
                        i1 = 43 : i2 = 44 : ds1 = 50 : ds2 = 100
                    End If 'v
                Case 4 'nr  P
                    If dsut < 20 Then
40:                     i1 = 8 : i2 = 9 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 9 : i2 = 10 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 10 : i2 = 11 : ds1 = 30 : ds2 = 50
                    Else 't
                        i1 = 11 : i2 = 12 : ds1 = 50 : ds2 = 100
                    End If 'w
                Case 5 'nr Mc
                    If dsut < 20 Then
50:                     i1 = 27 : i2 = 28 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 28 : i2 = 29 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 29 : i2 = 30 : ds1 = 30 : ds2 = 50
                    Else '1
                        i1 = 30 : i2 = 31 : ds1 = 50 : ds2 = 100
                    End If 'u
                Case 6 ' nr ML
                    If dsut < 20 Then
60:                     i1 = 45 : i2 = 46 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 46 : i2 = 47 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 47 : i2 = 48 : ds1 = 30 : ds2 = 50
                    Else '2
                        i1 = 48 : i2 = 49 : ds1 = 50 : ds2 = 100
                    End If 'v
                Case 7 'mt  P
                    If dsut < 20 Then
70:                     i1 = 13 : i2 = 14 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 14 : i2 = 15 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 15 : i2 = 16 : ds1 = 30 : ds2 = 50
                    Else '3
                        i1 = 16 : i2 = 17 : ds1 = 50 : ds2 = 100
                    End If 'x
                Case 8 'mt Mc
                    If dsut < 20 Then
80:                     i1 = 32 : i2 = 33 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 30 Then
                        i1 = 32 : i2 = 33 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 33 : i2 = 34 : ds1 = 30 : ds2 = 50
                    Else
                        i1 = 34 : i2 = 35 : ds1 = 50 : ds2 = 100
                    End If 'y
                Case 9 ' mt ML
                    If dsut < 20 Then
90:                     i1 = 50 : i2 = 51 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 30 Then
                        i1 = 50 : i2 = 51 : ds1 = 10 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 51 : i2 = 52 : ds1 = 30 : ds2 = 50
                    Else
                        i1 = 52 : i2 = 53 : ds1 = 50 : ds2 = 100
                    End If 'z
                Case 10 'nt  P
                    If dsut < 20 Then
94:                     i1 = 18 : i2 = 19 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 19 : i2 = 20 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 20 : i2 = 21 : ds1 = 30 : ds2 = 50
                    Else
                        i1 = 21 : i2 = 22 : ds1 = 50 : ds2 = 100
                    End If 'aa
                Case 11 'nt Mc
                    If dsut < 20 Then
96:                     i1 = 36 : i2 = 37 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 37 : i2 = 38 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 38 : i2 = 39 : ds1 = 30 : ds2 = 50
                    Else
                        i1 = 39 : i2 = 40 : ds1 = 50 : ds2 = 100
                    End If 'bb
                Case 12 ' nt ML
                    If dsut < 20 Then
98:                     i1 = 54 : i2 = 55 : ds1 = 10 : ds2 = 20
                    ElseIf dsut < 30 Then
                        i1 = 55 : i2 = 56 : ds1 = 20 : ds2 = 30
                    ElseIf dsut < 50 Then
                        i1 = 56 : i2 = 57 : ds1 = 30 : ds2 = 50
                    Else
                        i1 = 57 : i2 = 58 : ds1 = 50 : ds2 = 100
                    End If 'cc
            End Select
            stri1 = Str(i1) : If Len(stri1) > 2 Then stri1 = Right(stri1, 2) Else Mid(stri1, 1, 1) = "0"
            stri2 = Str(i2) : If Len(stri2) > 2 Then stri2 = Right(stri2, 2) Else Mid(stri2, 1, 1) = "0"
            FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\FIG" & stri1 & ".DAT"
100:        Call globalRoutines.LegFig(FileFig, Tsut, Alam, Para1, Para2, xxx1, xxx2, 1)
            '102 xFig1 = InterLogar(Tsut, Para1, Para2, xxx1, xxx2)
102:        xFig1 = System.Math.Exp(System.Math.Log(xxx1) + System.Math.Log(xxx2 / xxx1) * (Tsut - Para1) / (Para2 - Para1))
            FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\FIG" & stri2 & ".DAT"
110:        Call globalRoutines.LegFig(FileFig, Tsut, Alam, Para1, Para2, xxx1, xxx2, 1)
            '   xFig2 = InterLogar(Tsut, Para1, Para2, xxx1, xxx2)
            xFig2 = System.Math.Exp(System.Math.Log(xxx1) + System.Math.Log(xxx2 / xxx1) * (Tsut - Para1) / (Para2 - Para1))
120:        KRead(iRead) = globalRoutines.InterLogar(dsut, ds1, ds2, xFig1, xFig2)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub Risultante()
        Try
            Dim DirY As New RoutBase1.clsVec3
            Dim DirX As New RoutBase1.clsVec3
            Dim DirZ As New RoutBase1.clsVec3
            Dim ResM1 As New RoutBase1.clsVec3
            Dim ResF1 As New RoutBase1.clsVec3
            Dim ResF2 As New RoutBase1.clsVec3
            Dim MaxRes As New RoutBase1.clsVec3
            Dim MaxMom As New RoutBase1.clsVec3
            Dim i, k As Short
            DirX.X = 1 : DirY.y = 1 : DirZ.Z = 1
            Dim Bocchelli As OggList = New OggList(0)
            'da costruire la lista bocchelli dall'apparecchio
            For i = 1 To Config.NBocch
                '                FileGet(IUNA, Record(i), Geom(i).Ind)
            Next i
            'FOR iP = -1 TO 1 STEP 2
            'FOR iMc = -1 TO 1 STEP 2
            'FOR iMl = -1 TO 1 STEP 2
            'FOR iMt = -1 TO 1 STEP 2
            'FOR iVc = -1 TO 1 STEP 2
            'FOR iVl = -1 TO 1 STEP 2
            For k = 1 To 1 '-------------------------Config.Casi
                ResF1.X = 0 : ResF1.y = 0 : ResF1.Z = 0
                ResM1.X = 0 : ResM1.y = 0 : ResM1.Z = 0
                For i = 1 To Config.NBocch
900:                ResF2.X = 0 : ResF2.y = 0 : ResF2.Z = 0
                    '                    iP = System.Math.Sign(Record(i).posspa.CosDiritta.X)
                    '                    If System.Math.Abs(Record(i).posspa.CosDiritta.X) < globalRoutines.TOLER Then iP = System.Math.Sign(Record(i).posspa.CosDiritta.y)
                    '                    If System.Math.Abs(Record(i).posspa.CosDiritta.y) < globalRoutines.TOLER Then iP = System.Math.Sign(Record(i).posspa.CosDiritta.Z)
                    '                    iVc = System.Math.Sign(Record(i).posspa.CosTraversa.X)
                    '                    If System.Math.Abs(Record(i).posspa.CosTraversa.X) < globalRoutines.TOLER Then iVc = System.Math.Sign(Record(i).posspa.CosTraversa.y)
                    '                    If System.Math.Abs(Record(i).posspa.CosTraversa.y) < globalRoutines.TOLER Then iVc = System.Math.Sign(Record(i).posspa.CosTraversa.Z)
                    '                    iVl = System.Math.Sign(Record(i).posspa.CosTerza.X)
                    '                    If System.Math.Abs(Record(i).posspa.CosTerza.X) < globalRoutines.TOLER Then iVl = System.Math.Sign(Record(i).posspa.CosTerza.y)
                    '                    If System.Math.Abs(Record(i).posspa.CosTerza.y) < globalRoutines.TOLER Then iVl = System.Math.Sign(Record(i).posspa.CosTerza.Z)
                    '                    iMt = System.Math.Sign(Record(i).posspa.CosDiritta.y)
                    '                    If System.Math.Abs(Record(i).posspa.CosDiritta.y) < globalRoutines.TOLER Then iMt = System.Math.Sign(Record(i).posspa.CosDiritta.X)
                    '                    If System.Math.Abs(Record(i).posspa.CosDiritta.X) < globalRoutines.TOLER Then iMt = System.Math.Sign(Record(i).posspa.CosDiritta.Z)
                    '                    iMc = System.Math.Sign(Record(i).posspa.CosTraversa.y)
                    '                    If System.Math.Abs(Record(i).posspa.CosTraversa.y) < globalRoutines.TOLER Then iMt = System.Math.Sign(Record(i).posspa.CosTraversa.X)
                    '                    If System.Math.Abs(Record(i).posspa.CosTraversa.X) < globalRoutines.TOLER Then iMt = System.Math.Sign(Record(i).posspa.CosTraversa.Z)
                    '                    iMl = System.Math.Sign(Record(i).posspa.CosTerza.y)
                    '                    If System.Math.Abs(Record(i).posspa.CosTerza.y) < globalRoutines.TOLER Then iMl = System.Math.Sign(Record(i).posspa.CosTerza.X)
                    '                    If System.Math.Abs(Record(i).posspa.CosTerza.X) < globalRoutines.TOLER Then iMl = System.Math.Sign(Record(i).posspa.CosTerza.Z)
                    '                    ResF2.X = ResF2.X + Geom(i).Carichi(k).Load(1, 2) * iP * Record(i).posspa.CosDiritta.X
                    '                    ResF2.X = ResF2.X + Geom(i).Carichi(k).Load(5, 2) * iVc * Record(i).posspa.CosTraversa.X
                    '                    ResF2.X = ResF2.X + Geom(i).Carichi(k).Load(6, 2) * iVl * Record(i).posspa.CosTerza.X
                    '                    ResF2.y = ResF2.y + Geom(i).Carichi(k).Load(1, 2) * iP * Record(i).posspa.CosDiritta.y
                    '                    ResF2.y = ResF2.y + Geom(i).Carichi(k).Load(5, 2) * iVc * Record(i).posspa.CosTraversa.y
                    '                    ResF2.y = ResF2.y + Geom(i).Carichi(k).Load(6, 2) * iVl * Record(i).posspa.CosTerza.y
                    '                    ResF2.Z = ResF2.Z + Geom(i).Carichi(k).Load(1, 2) * iP * Record(i).posspa.CosDiritta.Z
                    '                    ResF2.Z = ResF2.Z + Geom(i).Carichi(k).Load(5, 2) * iVc * Record(i).posspa.CosTraversa.Z
                    '                    ResF2.Z = ResF2.Z + Geom(i).Carichi(k).Load(6, 2) * iVl * Record(i).posspa.CosTerza.Z
                    '910:                ResM1.X = ResM1.X + Geom(i).Carichi(k).Load(4, 2) * iMt * Record(i).posspa.CosDiritta.X
                    '                    ResM1.X = ResM1.X + Geom(i).Carichi(k).Load(2, 2) * iMc * Record(i).posspa.CosTraversa.X
                    '                    ResM1.X = ResM1.X + Geom(i).Carichi(k).Load(3, 2) * iMl * Record(i).posspa.CosTerza.X
                    '                    ResM1.y = ResM1.y + Geom(i).Carichi(k).Load(4, 2) * iMt * Record(i).posspa.CosDiritta.y
                    '                    ResM1.y = ResM1.y + Geom(i).Carichi(k).Load(2, 2) * iMc * Record(i).posspa.CosTraversa.y
                    '                    ResM1.y = ResM1.y + Geom(i).Carichi(k).Load(3, 2) * iMl * Record(i).posspa.CosTerza.y
                    '                    ResM1.Z = ResM1.Z + Geom(i).Carichi(k).Load(4, 2) * iMt * Record(i).posspa.CosDiritta.Z
                    '                    ResM1.Z = ResM1.Z + Geom(i).Carichi(k).Load(2, 2) * iMc * Record(i).posspa.CosTraversa.Z
                    '                    ResM1.Z = ResM1.Z + Geom(i).Carichi(k).Load(3, 2) * iMl * Record(i).posspa.CosTerza.Z
                    '920:                Polo.X = Record(i).posspa.Origine.X - job.Comm.Baric.X
                    ''                    Polo.y = Record(i).posspa.Origine.y - job.Comm.Baric.y
                    '                   Polo.Z = Record(i).posspa.Origine.Z - job.Comm.Baric.Z
                    '25:                'ProdVect Polo, ResF2, ResM2
                    '926:                ResM1.X = ResM1.X + ResM2.X
                    '                    ResM1.y = ResM1.y + ResM2.y
                    '                    ResM1.Z = ResM1.Z + ResM2.Z
                    '                    ResF1.X = ResF1.X + ResF2.X
                    '                    ResF1.y = ResF1.y + ResF2.y
                    '                    ResF1.Z = ResF1.Z + ResF2.Z
                Next i
                ' IF Lav(0).Asse = "V" THEN
                '    Rocking = SQR(ResM1.X ^ 2 + ResM1.Y ^ 2)
                '    IF Rocking > RockV THEN RockV = Rocking
                '    Horiz = SQR(ResF1.X ^ 2 + ResF1.Y ^ 2)
                '    IF Horiz > HorV THEN HorV = Horiz
                ' ELSEIF Lav(0).Asse = "H" THEN
940:            If System.Math.Abs(ResF1.X) > MaxRes.X Then MaxRes.X = ResF1.X
                If System.Math.Abs(ResF1.y) > MaxRes.y Then MaxRes.y = ResF1.y
                If System.Math.Abs(ResF1.Z) > MaxRes.Z Then MaxRes.Z = ResF1.Z
                If System.Math.Abs(ResM1.X) > MaxMom.X Then MaxMom.X = ResM1.X
                If System.Math.Abs(ResM1.y) > MaxMom.y Then MaxMom.y = ResM1.y
                If System.Math.Abs(ResM1.Z) > MaxMom.Z Then MaxMom.Z = ResM1.Z
                ' END IF    'dd
            Next k
            'NEXT iVl
            'NEXT iVc
            'NEXT iMt
            'NEXT iMl
            'NEXT iMc
            'NEXT iP
            'CALL Testa1(0)
            'PRINT #iout,
            '950   PRINT #iout, "                                      X            Y            Z"
            'PRINT #iout, USING "Center of gravity (wide equip.):  ######.##    ######.##    ######.##  "; Lav(0).Baric.X; Lav(0).Baric.Y; Lav(0).Baric.Z
            'PRINT #iout, USING "Forces   (worst combination)   :  ##.##^^^^    ##.##^^^^    ##.##^^^^  "; ResF1.X; ResF1.Y; ResF1.Z
            'PRINT #iout, USING "Moments  (worst combination)   :  ##.##^^^^    ##.##^^^^    ##.##^^^^  "; ResM1.X; ResM1.Y; ResM1.Z
            'PRINT #iout,
            '  IF Lav(0).Asse = "V" THEN
            'PRINT #iout, "(Note: the Z-axis is vert-up. and parallel to the axis of the equipment)"
            '  ELSE
            'PRINT #iout, "(Note: the Z-axis is vert-up. The Y-axis is // to the axis of the equip.)"
            '  END IF    
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try

    End Sub
    Friend Function SuperLeg() As Boolean
        Dim a As String
        SuperLeg = True
        Static GiaContinua As Short
        Try
            If Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                Call SuperLeg7()
                Exit Function
            End If 'ff
            If Config.WRC297 >= 3 Then
                If Not AppGLeg() Then Return False
                'For i = 1 To 12
                'Next
                Exit Function
            End If 'gg
            ifllib = FreeFile()
            FileOpen(ifllib, RTrim(Monitor.clsInizio.Archdir) & "\WR\BIJLAARD.DAT", OpenMode.Random, , OpenShare.Shared, 68)
            '5740 FIELD #ifllib, 68 AS Campo$
            a = ""
5750:       Call LegWRC(bbb(3), 1, "1A  ", aaa(3), SV(4), KRead(4), a)
5760:       Call LegWRC(bbb(8), 2, "2A  ", aaa(8), SV(10), KRead(10), a)
5770:       Call LegWRC(bbb(2), 3, "3A  ", aaa(2), SV(3), KRead(3), a)
5780:       Call LegWRC(bbb(2), 4, "4A  ", aaa(2), SV(9), KRead(9), a)
5790:       Call LegWRC(bbb(5), 5, "1B-1", aaa(5), SV(6), KRead(6), a)
5800:       Call LegWRC(bbb(9), 6, "2B-1", aaa(9), SV(12), KRead(12), a)
5810:       Call LegWRC(bbb(4), 7, "3B  ", aaa(4), SV(5), KRead(5), a)
5820:       Call LegWRC(bbb(4), 8, "4B  ", aaa(4), SV(11), KRead(11), a)
5830:       Call LegWRC(bbb(1), 9, "1C-1", aaa(1), SV(2), KRead(2), a)
5840:       Call LegWRC(bbb(7), 10, "2C-1", aaa(7), SV(8), KRead(8), a)
5850:       Call LegWRC(bbb(0), 11, "3C  ", aaa(0), SV(1), KRead(1), a)
5860:       Call LegWRC(bbb(6), 12, "4C  ", aaa(6), SV(7), KRead(7), a)
6590:       FileClose(ifllib)
            If Len(a) > 0 And Not GiaContinua = iB Then
                GiaContinua = iB
                a = Trim(Geom(iB).Mark) & "|" & a & "| Il calcolo continua."
                'MsgBox Monitor.clsInizio.ConvertiCr(a), vbInformation
                PrintlstRes(Trim(a))
            End If 'hh
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Sub SuperLeg7()
        Dim dsut, Alam As Single
        Dim Tsut As Single
        Dim i As Short
        Try
            RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
            TT = Geom(iB).T0 : If Geom(iB).TX > TT Then TT = Geom(iB).TX
1:          dsut = 2 * RR / (TT - Geom(iB).CorrN)
            GAMMA = dsut
2:          Alam = RR / Geom(iB).RM * System.Math.Sqrt(2 * Geom(iB).RM / Geom(iB).T)
            GG = Alam
            If Geom(iB).Buco > 0 Then
                Tsut = 0
            Else '10
3:              Tsut = Geom(iB).T / (TT - Geom(iB).CorrN)
            End If 'ii
            U = Tsut
            For i = 1 To 12
4:              Call LegWRC7(dsut, Alam, Tsut, i)
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub AggiornaApert()
        Dim Testo As String
        Testo = "nessuno"
        Try
            With Apert.DefInstance
                .StatusBar1.Panels(0).Text = "Area di lavoro: " & RTrim(Monitor.Motore.Inizio.Workdir)
                If Config.NBocch > 0 Then
                    Testo = objWRCB.commessa
                    .mnuSalva.Enabled = True
                    .mnuDati.Enabled = True
                    .cmdDati.Enabled = True
                    .cmdCalc.Enabled = True
                    .cmdEscludi.Enabled = True
                ElseIf Config.NBocch = 0 Then
                    .mnuSalva.Enabled = False
                    .mnuDati.Enabled = True
                    .cmdDati.Enabled = False
                    .cmdCalc.Enabled = False
                    .cmdEscludi.Enabled = False
                End If
                Testo = " File corrente = " & Testo
                .StatusBar1.Panels(1).Text = Testo
                If Config.Item.Trim = "" Then Config.Item = "(nessuno)"
                Testo = " Item = " & Config.Item
                .StatusBar1.Panels(2).Text = Testo
            End With
            AggAlbero()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub ApriScrivi()
        Try
            Dim Stringa(1) As String
            Dim Risult(1) As String
            Dim Archiv(1) As Short
            Dim dAiu(1) As String
            If AddDistinta > 0 Then
                If objWRCB.commessa.Length > 0 Then
                    Call SalvaW()
                Else
                    MsgBox("Errore impossibile in ApriScrivi")
                End If '2
            Else
                If objWRCB.commessa.Length = 0 Then ApriScriviCome()
                Call SalvaW()
            End If '4
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub ApriScriviCome()
        With Apert.DefInstance.SaveFileDialog1
            .Filter = "Carichi sui bocchelli (*.WRC)|*.WRC"
            .FileName = objWRCB.commessa
            .InitialDirectory = Monitor.clsInizio.Datidir
            .ShowDialog()
            objWRCB.commessa = .FileName
        End With
        Call SalvaW()
    End Sub
    Sub ChiudeFile()
        Dim a As String
        If objWRCB.commessa.Length = 0 Then Exit Sub
        If ModifiedData Then
            a = " Vuoi salvare le modifiche al|lavoro corrente conseguenti|alle verifiche effettuate"
            If MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then ApriScrivi()
        End If '6
        ModifiedData = False
        objWRCB.commessa = ""
        With Apert.DefInstance
            .Text1.Text = ""
            ._Frames_1.Visible = False
            ._Frames_0.Visible = False
            ._Frames_2.Visible = False
            .PictureBox1.Visible = True
        End With
    End Sub
    Sub Compos(ByRef EndEffect As Single, ByRef AMc As Single, ByRef AML As Single, ByRef AMt As Single, ByRef Vc As Single, ByRef Vl As Single)
        ' If Config.EndEffect Then
        ' EndEffect = Geom(iB).Carichi(iC).Load(0) + Geom(iB).Carichi(iC).Load(1) * Factk(iB)
        ' Else
        ' EndEffect = Geom(iB).Carichi(iC).Load(1) * Factk(iB)
        ' End If
        '  Vc = Abs(Geom(iB).Carichi(iC).Load(5)) * Factk(iB)
        '  Vl = Abs(Geom(iB).Carichi(iC).Load(6)) * Factk(iB)
        ' AMc = Abs(Geom(iB).Carichi(iC).Load(2)) * Factk(iB) + Geom(iB).Sporg * Vl * Config.Reduced
        ' AMl = Abs(Geom(iB).Carichi(iC).Load(3)) * Factk(iB) + Geom(iB).Sporg * Vc * Config.Reduced
        ' AMt = Abs(Geom(iB).Carichi(iC).Load(4)) * Factk(iB)
        EndEffect = Geom(iB).Carichi(iC).Load(1, 2) * Factk(iB)
        Vc = Geom(iB).Carichi(iC).Load(5, 2) * Factk(iB)
        Vl = Geom(iB).Carichi(iC).Load(6, 2) * Factk(iB)
        AMc = Geom(iB).Carichi(iC).Load(2, 2) * Factk(iB)
        AML = Geom(iB).Carichi(iC).Load(3, 2) * Factk(iB)
        AMt = Geom(iB).Carichi(iC).Load(4, 2) * Factk(iB)
    End Sub
    Sub Compos1(ByRef EndEffect As Single, ByRef AMc As Single, ByRef AML As Single, ByRef AMt As Single, ByRef Vc As Single, ByRef Vl As Single)
        EndEffect = Geom(iB).Carichi(iC).Load(1, 1)
        Vc = Geom(iB).Carichi(iC).Load(5, 1)
        Vl = Geom(iB).Carichi(iC).Load(6, 1)
        AMc = Geom(iB).Carichi(iC).Load(2, 1)
        AML = Geom(iB).Carichi(iC).Load(3, 1)
        AMt = Geom(iB).Carichi(iC).Load(4, 1)
    End Sub

    Sub ComposT(ByRef EndEffect As Single, ByRef AMc As Single, ByRef AML As Single, ByRef AMt As Single, ByRef Vc As Single, ByRef Vl As Single)
        ' EndEffect = Geom(iB).Carichi(iC).TLoad(1)
        '  Vc = Geom(iB).Carichi(iC).TLoad(5)
        '  Vl = Geom(iB).Carichi(iC).TLoad(6)
        ' AMc = Geom(iB).Carichi(iC).TLoad(2) + Geom(iB).Sporg * Vl * Config.Reduced
        ' AMl = Geom(iB).Carichi(iC).TLoad(3) + Geom(iB).Sporg * Vc * Config.Reduced
        ' AMt = Geom(iB).Carichi(iC).TLoad(4)
        EndEffect = Geom(iB).Carichi(iC).TLoad(1, 2)
        Vc = Geom(iB).Carichi(iC).TLoad(5, 2)
        Vl = Geom(iB).Carichi(iC).TLoad(6, 2)
        AMc = Geom(iB).Carichi(iC).TLoad(2, 2)
        AML = Geom(iB).Carichi(iC).TLoad(3, 2)
        AMt = Geom(iB).Carichi(iC).TLoad(4, 2)
    End Sub

    Sub ComposW(ByRef EndEffect As Single, ByRef AMc As Single, ByRef AML As Single, ByRef AMt As Single, ByRef Vc As Single, ByRef Vl As Single)
        'EndEffect = Geom(iB).Carichi(iC).WLoad(1)
        ' Vc = Geom(iB).Carichi(iC).WLoad(5)
        ' Vl = Geom(iB).Carichi(iC).WLoad(6)
        'AMc = Geom(iB).Carichi(iC).WLoad(2) + Geom(iB).Sporg * Vl * Config.Reduced
        'AMl = Geom(iB).Carichi(iC).WLoad(3) + Geom(iB).Sporg * Vc * Config.Reduced
        'AMt = Geom(iB).Carichi(iC).WLoad(4)
        EndEffect = Geom(iB).Carichi(iC).WLoad(1, 2)
        Vc = Geom(iB).Carichi(iC).WLoad(5, 2)
        Vl = Geom(iB).Carichi(iC).WLoad(6, 2)
        AMc = Geom(iB).Carichi(iC).WLoad(2, 2)
        AML = Geom(iB).Carichi(iC).WLoad(3, 2)
        AMt = Geom(iB).Carichi(iC).WLoad(4, 2)
    End Sub
    Sub DeterminLato()
        Try
            Dim Stringa2(2) As String
            Dim Stringa(50) As String
            Dim Ris(50) As Short
            Stringa2(1) = "Lato tubi    "
            Stringa2(2) = "Lato mantello"
            For iB = 1 To Config.NBocch
3010:           Stringa(iB) = globalRoutines.Adjust(Geom(iB).Mark, 15)
                If Geom(iB).Lato < 1 Or Geom(iB).Lato > 2 Then Geom(iB).Lato = 1
                Ris(iB) = Geom(iB).Lato
            Next
            'iy = Monitor.Motore.PluriScelta(Config.NBocch, Stringa(), 2, Ris(), "Assegnazione lato apparecchio")
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub Escludi()
        Dim Risult(50) As String
        Dim i As Short
        Dim Incl(50) As Boolean
        If Config.NBocch = 0 Then Exit Sub
        Stringa3(0) = "on cylin. "
        Stringa3(1) = "on sphere "
        Try
10:         For i = 1 To Config.NBocch
                If Len(Trim(Geom(i).Mark)) = 0 Then Geom(i).Mark = "N" & Trim(Str(i))
                If Geom(i).ShellType < 0 Or Geom(i).ShellType > 1 Then Geom(i).ShellType = 0
11:             Risult(i) = Geom(i).Mark.PadRight(10) & Stringa3(Geom(i).ShellType).PadRight(20) _
                      & Geom(i).Size.PadRight(15)
                Incl(i) = Geom(i).Incluso = 1
            Next
14:         i = Monitor.Motore.CheckQuale(Config.NBocch, "Inclusi nel calcolo", Risult, Incl, "")
            For i = 1 To Config.NBocch
17:             Geom(i).Incluso = -CShort(Incl(i))
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Function ExtLoads(ByRef Chart As Short, ByRef File As String) As String
        Dim ifl, i As Short
        Dim Spiega As String = ""
        ifl = FreeFile()
        Try
100:        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\INDIR.DAT", OpenMode.Input, , OpenShare.Shared)
            If Chart = 0 Then Chart = 1
            Dim counter As Short
            counter = Chart
            For i = 1 To counter
110:            Input(ifl, Spiega)
                Input(ifl, File)
                If EOF(ifl) Or Len(Spiega) = 0 Then
                    FileClose(ifl)
120:                FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\INDIR.DAT", OpenMode.Input, , OpenShare.Shared)
                    Input(ifl, Spiega)
                    Input(ifl, File)
                    Spiega = "." & Spiega
                    Chart = 1 : Exit For
                End If
            Next
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Return Spiega
    End Function
    Sub Library()
        Dim iConfSave As Short
        Try
            iConfSave = Config.UnitSis
            Config.UnitSis = 0
            Call ConfigString()
            frmLib.DefInstance.ShowDialog()
            Config.UnitSis = iConfSave
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub PrintVideo(ByRef iFirst As Boolean)
        Dim a As String
        Dim Lung As Short
        Dim iShellNoz As Short
        Dim Slim As Single
        Dim FactLoc As Single
        Dim MinMag As String
        Dim ShellSav As Short
        Try
            a = "" : Lung = 13
18010:      If Config.Analisi = 2 Then GoTo 18170
            iShellNoz = ShellNoz : If Config.WRC297 = 2 And Geom(iB).ShellType = 0 Then iShellNoz = 1
18020:      a = "SHELL ANALYSIS for  " & Trim(Geom(iB).Mark)
            If Geom(iB).Rinforzo Then
                If ShellNoz = 1 Then
                    a = a & " at the nozzle"
                Else
                    a = a & " at the pad edge"
                End If
            End If
            a = a & "| Load Case: " & Geom(iB).Carichi(iC).CaseDescription & "|"
18050:      If Not (Config.WRC297 = 4 And Geom(iB).ShellType = 1 And Geom(iB).Buco = 0) Then
                If StressLim(iC, iB).ASL(ShellNoz) > 0 Then FactLoc = Result(iShellNoz, iC, iB).SP / StressLim(iC, iB).ASL(ShellNoz) Else FactLoc = 0
                If FactLoc > Fact(iB) Then Fact(iB) = FactLoc
                MinMag = " < " : If Result(iShellNoz, iC, iB).SP > StressLim(iC, iB).ASL(ShellNoz) Then MinMag = " > "
                a = a & "     (Primary)  Max.SI = " & globalRoutines.myStr(Result(iShellNoz, iC, iB).SP, 5, 2, False) & MinMag & globalRoutines.myStr(StressLim(iC, iB).ASL(ShellNoz), 5, 2, False) & Config.Unit(6) & "|"
            End If
            If StressLim(iC, iB).ASQ(ShellNoz) > 0 Then FactLoc = Result(iShellNoz, iC, iB).Sq / StressLim(iC, iB).ASQ(ShellNoz) Else FactLoc = 0
            If FactLoc > Fact(iB) Then Fact(iB) = FactLoc
            MinMag = " < " : If Result(iShellNoz, iC, iB).Sq > StressLim(iC, iB).ASQ(ShellNoz) Then MinMag = " > "
18060:      a = a & "(Prim.+Second.) Max.SI = " & globalRoutines.myStr(Result(iShellNoz, iC, iB).Sq, 5, 2, False) & MinMag & globalRoutines.myStr(StressLim(iC, iB).ASQ(ShellNoz), 5, 2, False) & Config.Unit(6) & "|"
            If (Config.WRC297 > 2 And Geom(iB).ShellType <> 1) Or (Geom(iB).ShellType = 1 And Geom(iB).Buco = 1 And Config.WRC297 = 4) Then
                Slim = Geom(iB).Carichi(iC).YieldNoz * Geom(iB).Carichi(1).fBuc
                If Slim > 0 Then FactLoc = Result(iShellNoz, iC, iB).Bu / Slim Else FactLoc = 0
                If FactLoc > Fact(iB) Then Fact(iB) = FactLoc
                MinMag = " < " : If Result(iShellNoz, iC, iB).Bu > Slim Then MinMag = " > "
                a = a & "(Compr.Stress ) Max.SI = " & globalRoutines.myStr(Result(iShellNoz, iC, iB).Bu, 5, 2, False) & MinMag & globalRoutines.myStr(Slim, 6, 2, False) & Config.Unit(6) & "|"
            End If
            If Config.WRC297 = 2 And Geom(iB).ShellType = 0 Then
                iShellNoz = 2
18070:          a = a & "NOZZLE ANALYSIS for " & RTrim(Geom(iB).Mark) & "|"
                a = a & " Load Case: " & Geom(iB).Carichi(iC).CaseDescription & "|"
                If StressLim(iC, iB).ANL > 0 Then FactLoc = Result(iShellNoz, iC, iB).SP / StressLim(iC, iB).ANL Else FactLoc = 0
                If FactLoc > Fact(iB) Then Fact(iB) = FactLoc
                MinMag = " < " : If Result(iShellNoz, iC, iB).SP > StressLim(iC, iB).ANL Then MinMag = " > "
                a = a & "     (Primary)  Max.SI = " & globalRoutines.myStr(Result(iShellNoz, iC, iB).SP, 5, 2, False) & MinMag & globalRoutines.myStr(StressLim(iC, iB).ANL, 5, 2, False) & Config.Unit(6) & "|"
                If StressLim(iC, iB).ANQ > 0 Then FactLoc = Result(iShellNoz, iC, iB).Sq / StressLim(iC, iB).ANQ Else FactLoc = 0
                If FactLoc > Fact(iB) Then Fact(iB) = FactLoc
                MinMag = " < " : If Result(iShellNoz, iC, iB).Sq > StressLim(iC, iB).ANQ Then MinMag = " > "
                a = a & "(Prim.+Second.) Max.SI = " & globalRoutines.myStr(Result(iShellNoz, iC, iB).Sq, 5, 2, False) & MinMag & globalRoutines.myStr(StressLim(iC, iB).ANQ, 5, 2, False) & Config.Unit(6) & "|"
            End If
18150:      If Config.Analisi > 0 Then
                ShellSav = ShellNoz
                ShellNoz = 1 : Lung = 23
18170:          a = a & "|NOZZLE ANALYSIS|"
18200:          a = a & Space(59) & "** SECTIONS **|"
18210:          a = a & Space(59) & " A-A      B-B |"
18220:          a = a & "    General Primary Membrane           Pm      " & Config.Unit(5) & globalRoutines.myStr(Result(ShellNoz, iC, iB).SMA, 6, 2, False) & globalRoutines.myStr(Result(ShellNoz, iC, iB).SMB, 6, 2, False)
18250:          a = a & "|    Primary Membrane+Primary Bending   Pl+Pb   " & Config.Unit(5) & globalRoutines.myStr(Result(ShellNoz, iC, iB).SLA, 6, 2, False) & globalRoutines.myStr(Result(ShellNoz, iC, iB).SLB, 6, 2, False)
18280:          a = a & "|    Primary+Secondary                  Pl+Pb+Q " & Config.Unit(5) & globalRoutines.myStr(Result(ShellNoz, iC, iB).SQA, 6, 2, False) & globalRoutines.myStr(Result(ShellNoz, iC, iB).SQB, 6, 2, False)
18320:          a = a & "|            Max. Pm      = " & globalRoutines.myStr(Result(ShellNoz, iC, iB).SMM, 6, 2, False) & " < 1.0*k*Sn =" & globalRoutines.myStr(StressLim(iC, iB).ANM, 6, 2, False) & " " & Config.Unit(5)
18370:          a = a & "|            Max. Pl+Pb   = " & globalRoutines.myStr(Result(ShellNoz, iC, iB).SLM, 6, 2, False) & " < 1.5*k*Sn =" & globalRoutines.myStr(StressLim(iC, iB).ANL, 6, 2, False) & " " & Config.Unit(5)
18420:          a = a & "|            Max. Pl+Pb+Q = " & globalRoutines.myStr(Result(ShellNoz, iC, iB).SQM, 6, 2, False) & " < 3.0*k*Sn =" & globalRoutines.myStr(StressLim(iC, iB).ANQ, 6, 2, False) & " " & Config.Unit(5)
                ShellNoz = ShellSav
            End If
            If iFirst Then
                'MsgBox Monitor.clsInizio.ConvertiCr(a), vbInformation
                PrintlstRes(Trim(a))
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub SalvaW()
        Dim j As Short
        Try
            Config.Versione = 2
            Dim fs As New FileStream(objWRCB.commessa, FileMode.OpenOrCreate)
            Dim bf As New BinaryFormatter
            bf.Serialize(fs, Config)
            For j = 1 To Config.NBocch
                bf.Serialize(fs, Geom(j))
                bf.Serialize(fs, StressLim(1, j))
            Next
            For j = 1 To 2 * Config.NBocch
                bf.Serialize(fs, Matdim(j).Indmat) 'non compatibile
            Next
            bf.Serialize(fs, job)
            fs.Close()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Function ScegliCarta(ByRef Carta As String, ByRef Mode As Integer) As Short
        Dim k, k1 As Short
        Dim Stringa(20) As String
        Dim kScegli As Short
        Try
            k = 1
            Do
                k1 = k
200:            Stringa(k) = ExtLoads(k1, Csv)
                If k1 = 0 Or Left(Stringa(k), 1) = "." Then Exit Do
                k = k + 1
            Loop
            If Mode = 0 Then
                k = k - 1
            Else
                Stringa(k) = "Nuova Libreria"
            End If
            kScegli = Monitor.Motore.Quale(k, "Definizione carichi", Stringa, "", Config.Chart)
            If Mode = 1 And kScegli = k Then
                kScegli = -kScegli
            Else
                Config.Chart = kScegli
                Carta = ExtLoads(kScegli, Csv)
            End If
            ScegliCarta = kScegli
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Sub Seleziona(ByRef Tit As String)
        Dim i As Short
        Dim Risult(50) As String
        For i = 1 To Config.NBocch
            If Geom(i).Incluso = 1 Then
                Risult(i) = globalRoutines.Adjust(Geom(i).Mark, 20)
            Else
                Risult(i) = "---(escluso)---"
            End If
        Next
        iB = Monitor.Motore.Quale(Config.NBocch, Tit, Risult, "", iB)
        If iB < 1 Then iB = 0
        If Geom(iB).Incluso = 0 Then iB = 0
    End Sub
    Sub SetupMenuFl()
        'MenuSet 1, 0, 1, "Files", 1
        'MenuSet 1, 1, 1, "Apri", 1
        'MenuSet 1, 2, 1, "Salva", 1
        'MenuSet 1, 3, 1, "Chiudi", 1
        'MenuSet 1, 4, 1, "Esci", 1'

        'MenuSet 2, 0, 1, "Esecuzione", 1
        'MenuSet 2, 1, 1, "Tutti i Dati", 1
        'MenuSet 2, 2, 1, "Dati Generali", 1
        'MenuSet 2, 3, 1, "Geometria (tutti)", 1
        'MenuSet 2, 4, 1, "Geometria (uno) ", 2
        'MenuSet 2, 5, 1, "Materiali e ammissibili", 1
        'MenuSet 2, 6, 1, "Dati di Carico (tutti)", 1
        'MenuSet 2, 7, 1, "Dati di Carico (uno)", 17
        'MenuSet 2, 8, 1, "Calcolo (tutti)", 1
        'MenuSet 2, 9, 1, "Calcolo (uno  )", 2
        'MenuSet 2, 10, 1, "Elimina bocchello", 2
        'MenuSet 2, 11, 1, "Stampa", 1

        'MenuSet 3, 0, 1, "Opzioni       ", 1
        'MenuSet 3, 1, 1, "Libreria carichi", 1
    End Sub
    Public Function StamSumm() As Boolean
        Dim Stringa4(1) As String
        Dim Stringa3(3) As String
        Dim Stringa5(4) As String
        Dim Stringa6(7) As String
        Dim Stringa8(2) As String
        Dim Stringa10(2) As String
        Dim ifl, i As Short
        Dim Riga As String
        Dim NPS, Mark, Asa As String
        Dim PadT, Padd, Calc As String
        Dim Par As String
        Stringa10(1) = "ASME VIII"
        Stringa10(2) = "BS5500   "
        Stringa3(1) = "International : [mm],[N] ,[{\super 0}C]"
        Stringa3(2) = "Technical     : [mm],[Kg],[{\super 0}C]"
        Stringa3(3) = "Imperial      : [in],[lb],[{\super 0}F]"
        Stringa5(1) = "WRCB 107"
        Stringa5(2) = "WRCB 107 for spheres; WRCB 297 for cylindrical shells"
        Stringa5(3) = "WRCB 107 for spheres; BS5500 App.G for cylindrical shells"
        Stringa5(4) = "BS5500 App.G"
        Stringa8(1) = "WRCB 107"
        Stringa8(2) = Stringa5(4)
        Stringa4(0) = " NO" : Stringa4(1) = "YES"
        Stringa6(0) = Space(4)
        Stringa6(1) = " 150"
        Stringa6(2) = " 300"
        Stringa6(3) = " 400"
        Stringa6(4) = " 600"
        Stringa6(5) = " 900"
        Stringa6(6) = "1500"
        Stringa6(7) = "2500"
        If Template = "HeadNotNoz" Then
            Monitor.Motore.Problem.ChiudiRapp() '  iout = 0 '???????????????????????
            FileSt = Monitor.clsInizio.DiscoTem & "StamSumm"
        Else
            FileSt = Apert.DefInstance.Text1.Text
        End If
        If Not PrepRapp("HEADER", "Nozzle Summary", "Apparecchio", FileSt, Apert.DefInstance.lstRapp) Then Exit Function
        StamSumm = True
        Call Testa1(0)
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STAM.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6
            Riga = LineInput(ifl)
            Monitor.Motore.Problem.Printa(New String(" ", 5) & Riga)
        Next
        Riga = LineInput(ifl)
        FileClose(ifl)
        For iB = 1 To Config.NBocch
            Mark = globalRoutines.Adjust(Geom(iB).Mark, 15)
            NPS = globalRoutines.myStr(Geom(iB).DiaN, 2, 1, False)
            If Geom(iB).Asa < 0 Or Geom(iB).Asa > 7 Then Geom(iB).Asa = 0
            Asa = Stringa6(Geom(iB).Asa)
            If Geom(iB).Padd = 0 Then
                Padd = Space(8) : PadT = Space(8)
            Else
                Padd = globalRoutines.myStr(Geom(iB).Padd, 5, 2, False)
                PadT = globalRoutines.myStr(Geom(iB).PadT, 5, 2, False)
            End If
            If Geom(iB).Incluso < 0 Or Geom(iB).Incluso > 1 Then Geom(iB).Incluso = 0
            Calc = Stringa4(Geom(iB).Incluso)
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(Riga, iB, Mark, NPS, Asa, Padd, PadT, Calc))
        Next
        Par = "\par"
        Monitor.Motore.Problem.Printa(Par)
        Monitor.Motore.Problem.Printa(Space(10) & "Measurement system      :" & Stringa3(Config.UnitSis + 1) & Par)
        Monitor.Motore.Problem.Printa(Space(10) & "Method for the analysis :" & Stringa5(Config.WRC297) & Par)
        Monitor.Motore.Problem.Printa(Space(10) & "Summation convention    :" & Stringa8(Config.ConvSumm) & Par)
        Monitor.Motore.Problem.Printa(Space(10) & "Shear reduced to foot   :" & Stringa4(Config.Reduced) & Par)
        If Config.EndEffect Then i = 1 Else i = 0
        Monitor.Motore.Problem.Printa(Space(10) & "Autom. press. end-effect:" & Stringa4(i) & Par)
        If Config.WRC297 > 2 Then
            Monitor.Motore.Problem.Printa(Space(10) & "Stress limits           :" & Stringa10(Config.Ammiss + 1) & Par)
        End If
        Carta = ExtLoads(Config.Chart, Csv)
        Monitor.Motore.Problem.Printa(Space(10) & "External loads          :" & Carta & Par)
        Monitor.Motore.Problem.Printa(Par)
        If Config.Chart > 1 Then
            LeggiSt()
            StamLib()
            Monitor.Motore.Problem.Printa(Par)
        End If
        Monitor.Motore.Problem.Printa(Space(10) & "Note: see the stress summary at the end of the document" & Par)
        Monitor.Motore.Problem.Printa(Space(10) & "Note: see explanatory remarks at the end of the document" & Par)
        If Template = "HeadNotNoz" Then
            Monitor.Motore.Problem.FineRapp()
        End If
    End Function
    Sub StamSummF()
        Dim i, ifl As Short
        Dim FileN As String = ""
        Dim NPS, Mark, Factt As String
        Dim Sm5, Sm1, Sm2, Sm6 As String
        Dim Sm4, Sm3, Sm7 As String
        Dim Log1, Log2 As Boolean
        Dim iSt As Short
        Dim iD As Short
        Dim Riga As String
        Try
            Dim Stringa3(7) As String
            If Template = "HeadNotNoz" Then
                Monitor.Motore.Problem.FineRapp()
                FileStPr = FileSt
                FileSt = Monitor.clsInizio.DiscoTem & "StamStress"
            Else
                FileSt = Apert.DefInstance.Text1.Text
            End If
            Call PrepRapp("HEADER", "Stress Summary", "Apparecchio", FileSt, Apert.DefInstance.lstRapp)
400:        Call Testa1(0)
            ifl = FreeFile()
410:        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STAMS.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 4
                Stringa3(0) = LineInput(ifl)
                Monitor.Motore.Problem.Printa(Stringa3(0))
            Next
420:        For i = 1 To 7
                Stringa3(i) = LineInput(ifl)
            Next
            FileClose(ifl)
            If Config.WRC297 > 2 Then Stringa3(1) = Stringa3(5)
            For iB = 1 To Config.NBocch
430:            If Geom(iB).Incluso = 0 Then GoTo ContStam
                Mark = globalRoutines.Adjust(Geom(iB).Mark, 15)
                NPS = globalRoutines.myStr(Geom(iB).DiaN, 2, 1, False)
                Factt = "  {\b k}  "
                Monitor.Motore.Problem.Printa(Stringa3(0))
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(Stringa3(1), iB, Factt))
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(Stringa3(2), Mark, NPS, Config.Unit(5), Config.Unit(5), Config.Unit(5), Config.Unit(5), Config.Unit(5), Config.Unit(5)))
                For iC = 1 To Geom(iB).Casi
440:                Sm1 = globalRoutines.myStr(sConverti(Resultv(1, iC, iB).SP, 2), 5, 2, False)
                    Sm2 = globalRoutines.myStr(sConverti(Resultv(1, iC, iB).Sq, 2), 5, 2, False)
                    Sm5 = globalRoutines.myStr(sConverti(StressLim(iC, iB).ASL(1), 2), 5, 2, False)
                    Sm6 = globalRoutines.myStr(sConverti(StressLim(iC, iB).ASQ(1), 2), 5, 2, False)
                    If Config.WRC297 = 2 And Geom(iB).ShellType = 0 Then
450:                    Sm3 = globalRoutines.myStr(sConverti(Resultv(2, iC, iB).SP, 2), 5, 2, False)
                        Sm4 = globalRoutines.myStr(sConverti(Resultv(2, iC, iB).Sq, 2), 5, 2, False)
                    ElseIf Config.WRC297 = 3 Or (Config.WRC297 = 4 And Geom(iB).ShellType = 0) Then
                        Sm3 = globalRoutines.myStr(sConverti(Resultv(1, iC, iB).Bu, 2), 5, 2, False)
                        Sm4 = globalRoutines.myStr(sConverti(Geom(iB).Carichi(1).YieldNoz, 2) * Geom(iB).Carichi(1).fBuc, 5, 2, False)
                    Else
                        Sm3 = "       ---" : Sm4 = Sm3
                    End If
                    If Config.WRC297 = 4 And Geom(iB).ShellType = 1 Then
                        Sm1 = "       ---" : Sm5 = Sm1
                    End If
                    If iC > 1 Then
                        Sm7 = ""
                    Else
                        If Factk(iB) < 10 Then
                            Sm7 = globalRoutines.myStr(Factk(iB), 2, 3, False)
                        ElseIf Factk(iB) < 100 Then
                            Sm7 = globalRoutines.myStr(Factk(iB), 3, 2, False)
                        ElseIf Factk(iB) < 1000 Then
                            Sm7 = globalRoutines.myStr(Factk(iB), 4, 1, False)
                        Else
                            Sm7 = ">1000"
                        End If
                        Sm7 = "{\b " & Sm7 & "}"
                    End If
460:                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(Stringa3(3), iC, Sm1, Sm2, Sm3, Sm4, Sm5, Sm6, Sm7))
                    Log1 = Config.WRC297 > 2 And Geom(iB).ShellType = 0 And Geom(iB).Padd > 0
                    Log2 = False 'Config.WRC297 = 2 And Geom(iB).Shell = 0
                    If Log1 Or Log2 Then
                        If Log1 Then iSt = 4 Else iSt = 7
                        Sm1 = globalRoutines.myStr(sConverti(Resultv(2, iC, iB).SP, 2), 5, 2, False)
                        Sm2 = globalRoutines.myStr(sConverti(Resultv(2, iC, iB).Sq, 2), 5, 2, False)
                        Sm3 = globalRoutines.myStr(sConverti(Resultv(2, iC, iB).Bu, 2), 5, 2, False)
                        Sm4 = globalRoutines.myStr(sConverti(Geom(iB).Carichi(1).YieldNoz, 2) * Geom(iB).Carichi(1).fBuc, 5, 2, False)
                        Sm5 = globalRoutines.myStr(sConverti(StressLim(iC, iB).ASL(2), 2), 5, 2, False)
                        Sm6 = globalRoutines.myStr(sConverti(StressLim(iC, iB).ASQ(2), 2), 5, 2, False)
470:                    Monitor.Motore.Problem.Printa(globalRoutines.FormatS(Stringa3(iSt), Sm1, Sm2, Sm3, Sm4, Sm5, Sm6))
                    End If
                Next
                If Config.WRC297 > 2 And Geom(iB).ShellType = 0 Then
                    For iD = 1 To 4
                        If Geom(iB).iB(iD) <> 0 Then
                            Call Printx() : Exit For
                        End If
                    Next
                End If
ContStam:   Next
            If Template = "HeadNotNoz" Then
                Monitor.Motore.Problem.FineRapp()
            End If
            If Config.Note Then
                If Template = "HeadNotNoz" Then
                    FileSt = Monitor.clsInizio.DiscoTem & "StamNote"
                    Call PrepRapp("HEADER", "Explanatory Notes", "Apparecchio", FileSt, Apert.DefInstance.lstRapp)
                End If
480:            Call Testa1(0)
                ifl = FreeFile()
                Select Case Config.WRC297
                    Case 1 : FileN = "\RTF\STAMB.WRC" 'WRC107
                    Case 2 : FileN = "\RTF\STAMC.WRC" 'WRC107/WRC297
                    Case 3 : FileN = "\RTF\STAMD.WRC" 'WRC107/App.G
                    Case 4 : FileN = "\RTF\STAMA.WRC" 'App G
                End Select
490:            FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & FileN, OpenMode.Input, , OpenShare.Shared)
                Do
                    If EOF(ifl) Then Exit Do
                    Riga = LineInput(ifl)
500:                Monitor.Motore.Problem.Printa(Riga)
                Loop
                FileClose(ifl)
                If Template = "HeadNotNoz" Then
                    Monitor.Motore.Problem.FineRapp()
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Printx()
        Dim iE As Short
        For iE = 1 To 4
            StrStr(iE) = Space(11)
            If Geom(iB).iB(iE) <> 0 Then
510:            Mid(StrStr(iE), 1, 2) = globalRoutines.myStr(System.Math.Abs(Geom(iB).iB(iE)), 2, 0, True)
                Mid(StrStr(iE), 4, 2) = "NO"
                Mid(StrStr(iE), 8, 2) = "NO"
                If Geom(iB).iB(iE) > 0 Then Mid(StrStr(iE), 4, 3) = "YES"
                If Geom(iB).Dist(iE) > 0 Then Mid(StrStr(iE), 8, 3) = "YES"
            End If
        Next
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(Stringa3(6), StrStr(1), StrStr(2), StrStr(3), StrStr(4)))
    End Sub
    Sub SubTensAmm(ByRef Temp As Single, ByRef AllFOpe As Single, ByRef indice As Short)
        Dim td, AllFRoo As Single
        Dim Testo As String
        Try
            If Matdim(indice).Indmat > 0 Then
                Select Case Config.DC
                    Case 0, 1
                        If Config.UnitSis < 2 Then 'centigradi
                            td = Temp * 1.8 + 32
                        Else
                            td = Temp
                        End If 'l
                        Matdim(indice).SigmaAmm(-6, td, AllFRoo, AllFOpe) '6 ASME-VIII div.2
                        If Config.Verbose > 0 And AllFOpe = 0 Then
                            Testo = "Non è stato possibile calcolare il valore della tensione ammissibile" & vbCrLf
                            Testo = Testo & "per il materiale " & Trim(Matdim(indice).MatStr) & "." & vbCrLf
                            Testo = Testo & "Una delle cause può essere la mancanza di dati per ASME-VIII-div.2."
                            MsgBox(Testo, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "WRCB")
                        End If
                    Case Else
                        If Config.UnitSis = 2 Then 'farenheit
                            td = Temp
                        Else
                            td = (Temp - 32) / 1.8
                        End If 'l
                        Matdim(indice).SigmaAmm(Monitor.Motore.Inizio.CodiceStress(Config.DC) _
                        , td, AllFRoo, AllFOpe)
                End Select
                Select Case Config.UnitSis
                    Case 0 'Si
                    Case 1 'Tecnico
                        AllFRoo = AllFRoo / GRAV : AllFOpe = AllFOpe / GRAV
                    Case 2 'British
                        AllFRoo = AllFRoo / MPA : AllFOpe = AllFOpe / MPA
                End Select
            End If 'm
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub TrasfCar(ByRef Mode As Short)
        If Geom(iB).Incluso = 0 Then Exit Sub
        Dim Factor(7) As Single
        Dim Carta As String = ""
        Dim Csv As String = ""
        Dim Size As Single
        Dim ifl As Short
        Dim Riga As String = ""
        Dim DN As String = ""
        Dim j, i As Short
        Dim a As String
        Dim junk As Integer
        Dim Mc, Vc, Fa, Vl, Ml, Mt As Single
        Dim Fact As Single
        If Config.Chart < 2 Then Exit Sub
        For j = 1 To 6
            If Geom(iB).Carichi(iC).Load(j, 1) <> 0 Then
                If Config.Verbose > 0 And Mode = 0 Then
                    a = "Vuoi veramente sostituire i carichi|"
                    a = a & "già imputati con i carichi standard?"
                    junk = MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                ElseIf Mode = 0 Then
                    junk = MsgBoxResult.Yes
                Else
                    junk = MsgBoxResult.Cancel
                End If
                If junk = MsgBoxResult.Yes Then Exit For Else Exit Sub
            End If
        Next
        Carta = ExtLoads(Config.Chart, Csv)
        Size = Geom(iB).DiaN
        If Size <= 0 Then
            a = RTrim(Geom(iB).Mark) : If Len(a) = 0 Then a = "(SENZA NOME)"
            If Geom(iB).Buco = 1 Then
                a = "L'apertura " & a & vbCrLf
                a = a & "è di tipo rigido, e quindi i carichi" & vbCrLf
                a = a & "devono essere assegnati manualmente"
                MsgBox(a, MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
            Else
                a = " Diametro nominale non defini-|to per " & a
                MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Critical + MsgBoxStyle.OKOnly)
            End If
            Exit Sub
        End If
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\" & Csv, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        Riga = LineInput(ifl)
        Riga = LineInput(ifl)
        Do
            Input(ifl, DN)
            Input(ifl, Fa)
            Input(ifl, Vl)
            Input(ifl, Vc)
            Input(ifl, Ml)
            Input(ifl, Mc)
            Input(ifl, Mt)
            If globalRoutines.ValVir(DN) >= Size Or globalRoutines.ValVir(DN) = 0 Then Exit Do
            If EOF(ifl) Then MsgBox("Errore imp.1in TrasfCar")
        Loop
        Do
            Riga = LineInput(ifl)
            If Left(Riga, 6) = "Bvalue" Then
                For i = 1 To 7
                    Riga = Right(Riga, Len(Riga) - InStr(Riga, ","))
                    Factor(i) = globalRoutines.ValVir(Riga)
                    'Factor(i) = GlobaLroutines.ValVir(Mid$(Riga$, 8 + (i - 1) * 7, 5))
                Next
                '     Input #ifl, Testo, Factor(1), Factor(2), Factor(3), Factor(4), Factor(5), Factor(6) ', Factor(7)
                Exit Do
            End If 'n
            If EOF(ifl) Then MsgBox("Errore imp.2in TrasfCar")
        Loop
        FileClose(ifl)
        Fact = Factor(Geom(iB).Asa)
        If Geom(iB).Asa = 0 Then
            If Config.Verbose > 0 Then
                a = "Poiché il rating ASA non è stato definito|"
                a = a & "non è possibile determinare i carichi stan-|"
                a = a & "dard. Tuttavia si possono sempre inserire |"
                a = a & "i dati manualmente.                       |"
                MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Information)
            End If
            Exit Sub
        End If
        Geom(iB).Carichi(iC).Load(1, 1) = -Fa * Fact
        If Mode = 1 And iC = 2 Then Geom(iB).Carichi(iC).Load(1, 1) = -Geom(iB).Carichi(iC).Load(1, 1)
        Geom(iB).Carichi(iC).Load(2, 1) = Mc * Fact
        Geom(iB).Carichi(iC).Load(3, 1) = Ml * Fact
        Geom(iB).Carichi(iC).Load(4, 1) = Mt * Fact
        Geom(iB).Carichi(iC).Load(5, 1) = Vc * Fact
        Geom(iB).Carichi(iC).Load(6, 1) = Vl * Fact
        If Geom(iB).ShellType = 1 Then 'sfera
            Geom(iB).Carichi(iC).Load(2, 1) = System.Math.Sqrt(Mc ^ 2 + Ml ^ 2) * Fact
            Geom(iB).Carichi(iC).Load(3, 1) = 0
            Geom(iB).Carichi(iC).Load(5, 1) = System.Math.Sqrt(Vc ^ 2 + Vl ^ 2) * Fact
            Geom(iB).Carichi(iC).Load(6, 1) = 0
        End If
        If Config.Analisi <> 0 Then
            For i = 1 To 6
                Geom(iB).Carichi(iC).WLoad(i, 1) = Geom(iB).Carichi(iC).Load(i, 1)
            Next
        End If
    End Sub
End Module