Option Strict Off
Option Explicit On
Module modTestap
    Private MatLam, ItemStr, Item As String
	Private BocchL As Short
	Private MATL, Mat, MATB As String
    Private iRec As Long
	Private CO, CK, TIPT As String
	Private TIPTI As String
	Private ASME, MAWP As Boolean
	Private A(52) As Single
	Private B(18) As Single
	Private C(18) As Single
	Private f(18) As Single
	Private X(18) As Single
	Private R(18) As Single
	Private S(18) As Single
	Private D(19, 6) As Single
	Private M(45) As Single
	Private Z(16) As Single
    Private Stringa(13) As String
    Private Ricor(4) As Single
    '================================StamTes=========================
    Private AA, ifl, BB As Short
    Private Asin As Short
    Private jStr, uStr As String
    Private i As Short
    Private vStr, yStr As String
    Private AAStr, zStr, XgStr As String
    Private MMStr, GGStr As String
    Private n As Short
    Private j As Short
    Private xStr, wStr As String
    Private Zmag, Zmin, VV As String
    '=================================================================
    Private ya, xa, xb, yb As Single
    Private xScr, dx, dy, xScr0 As Single
    Private yScr, yScr0 As Single
    Private Sy, Sx, suppl As Single
    Private ymin, xmin, xmax, ymax As Single
    Private ScalLoc As Single
    Private ii As Short
    Private Testo As String
    Private yLiv, xdes As Single
    Private jj As Short
    Private yLiv1, Amax As Single
    Private xSin, Scal, YM, ySin As Single
    Private x1, YM1 As Single
    Private y1, XM, XM1, ytub As Single
    Private AltText1, AltText2 As Single
    Private jobStr As String
    '===================Testap========================
    Private AAsng, T As Single
    Private Help As String
    Private H, BBsng As Single
    Private Archiv(10) As Short
    Private dAiu(10) As String
    Private k As Short
    Private l As Single
    Private Itera, iCambio As Boolean
    Private SSin, CSin, ZSin As Single
    Private P0, P, p1 As Single
    Private Q, m1 As Single
    Private xx As Short
    Private Errt, Errp As Single
    Private iRis As Short
    Private Nome2 As String
    Private St As Single
    Private ik, xSinSng As Short
    '=================================================
    Private Sub Calcx(ByRef AA As Single, ByRef H As Single)
        Dim j As Short
        Dim HH, HHH As Single
        Dim i, n As Short
1860:   X(1) = C(1) / 2 - AA
1870:   For j = 2 To f(1)
            HH = H : If HH = 0 Then HH = MecData(0).Passo(j - 1)
1880:       X(j) = X(j - 1) - HH
1890:   Next j
1900:   j = j - 1
1910:   For i = 2 To A(20) + 1
1920:       For n = 1 To f(i)
1930:           j = j + 1
                HH = H : If HH = 0 Then HH = MecData(0).Passo(j - 1)
                If n = 1 Then HHH = 0.5 * HH Else HHH = HHH + HH
                '1940 x(j) = (C(i) + A(27)) / 2 - (N - .5) * HH
                X(j) = (C(i) + A(27)) / 2 - HHH
1950:       Next n
1960:   Next i
    End Sub

    Private Function EffLeg() As Single
        Dim D2, D1, T0 As Single
        Dim DE, TT1, ELTM As Single
        Dim B1, BO, XE As Single
        Dim RI, TT2, ELTB As Single
        Dim T2, C3 As Single
        'EffLeg=(A(42) - A(41)) / A(42)
        'On Local Error GoTo ErrEff
        D1 = 46 : D2 = 38 : T0 = 2
        If A(41) < 26 Then D1 = 36 : D2 = 29
        TT1 = A(21) - T0
3:      DE = (D1 * T0 + D2 * TT1) / A(21)
4:      ELTM = (A(42) - DE) / A(42)
        BO = A(42) - D1
        B1 = A(42) - D2
5:      XE = (BO * T0 * (T0 / 2.0! + TT1) + B1 * TT1 * TT1 / 2.0!) / (BO * T0 + B1 * TT1)
        TT2 = T2 - XE
        C3 = XE : If TT2 > C3 Then C3 = TT2
6:      RI = (BO * T0 ^ 3 + B1 * TT1 ^ 3) / 12.0! + BO * T0 * (T0 / 2.0! + TT1 - XE) ^ 2
7:      RI = RI + B1 * TT1 * (XE - TT1 / 2.0!) ^ 2
8:      DE = A(42) - 6.0! * RI / A(21) ^ 2 / C3
9:      ELTB = (A(42) - DE) / A(42)
        EffLeg = ELTB
        Exit Function
        'ErrEff: Print "Errore in EffLeg"; Err; Erl: End
    End Function
    Private Function FilCam() As Boolean
        Dim nIn As Short
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Dim i As Short
        FilCam = True
        nIn = 1
        Dom(1) = "Numero di file" : Risp(1) = Str(A(19))
        If A(20) > 0 Then
            nIn = 1 + A(20) + 1
            For i = 2 To A(20) + 2
                Dom(i) = "N° file camera" & Str(i - 1) : Risp(i) = Str(System.Math.Abs(MecData(0).Nfile(i - 1)))
            Next
        End If
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(nIn, "N° di file per camera", Dom, Risp, "", Archiv, dAiu) Then FilCam = False : Exit Function
        A(19) = Val(Risp(1))
        If A(20) > 0 Then
            For i = 2 To A(20) + 2
                MecData(0).Nfile(i - 1) = Val(Risp(i))
            Next
        End If
    End Function
    Public Function TestapMain() As Boolean
        Dim Ris As Boolean
        Dim Cod As String
        TestapMain = True
        'Nrdit = AddDistinta
        'TipoFas = IUNQ
        If Nrdit > 0 Then
            FileMec = Monitor.Motore.Inizio.Workdir + "\" + CDbl(RTrim(job.contratto)) + GlobalRoutines.Str2Cifre(Nrdit \ 2) + ".MEC"
        Else
            '???FileMec = Monitor.Motore.Inizio.Workdir + "\SALV00.MEC"
            '???job.contratto = "SALV"
        End If
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        iRec = iCassa
        If iRec = 0 Then
            iRec = 1 : nPag = 1
        Else
            nPag = nCasse(TipoFas)
        End If
        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FileGet(33, MecData(0), iRec)
        'iTest = AddLibrerie
        Ris = testap(iCassa, iTest)
        If Not Ris Then
            TestapMain = False
        Else
            Cod = "" : If iCassa > 0 Then Cod = "b" & Str(iCassa)
            Registra(NewFUPM, iCassa, Cod)
        End If
Fine:
        FilePut(33, MecData(0), iRec)
    End Function
    Private Function Decidi() As Boolean
        Dim i, n As Short
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Decidi = True
        Dom(1) = "Spessore Top&Bottom   "
        Dom(2) = "Spessore p. tubi/tappi"
        Dom(3) = "Spessore setti        "
        Dom(4) = "Speesore Ends         "
        For i = 1 To 4
            Dom(i) = Dom(i) & "(min." + GlobalRoutines.myStr(MecData(1).SP(i - 1), 4, 2, False) + "):"
            Risp(i) = GlobalRoutines.myStr(MecData(0).SP(i - 1), 4, 2, False)
        Next
        n = 4
        If A(20) = 0 Then
            Dom(3) = Dom(4) : Risp(3) = Risp(4)
            n = 3
        End If
        For i = 1 To n : Ricor(i) = Val(Risp(i)) : Next
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(n, "Scelta spessori", Dom, Risp, "", Archiv, dAiu) Then Decidi = False
    End Function

    Private Sub Risolvi()
        'On Local Error GoTo ErrRisolvi
        Dim CSin, k As Single
        Dim S As Short
        Dim Asin, xSin As Single
        Dim i, j As Short
3080:   CSin = A(18)
3090:   S = A(20)
3100:   M(34) = (A(21) - CSin) ^ 3 / 12
3110:   M(35) = (A(22) - CSin) ^ 3 / 12
3120:   k = A(10) / 2 + CSin
3130:   D(1, 1) = k / M(35) + (C(1) + 2 * CSin) / M(34) / 3
3140:   D(S + 2, 1) = (C(S + 1) + 2 * CSin) / M(34) / 3 + k / M(35)
3150:   D(1, 3) = A(13) * (k ^ 3 / M(35) + (C(1) / 2 + CSin) ^ 3 / M(34)) / 300
3160:   D(S + 2, 3) = A(13) * ((C(S + 1) / 2 + CSin) ^ 3 / M(34) + k ^ 3 / M(35)) / 300
3170:   D(1, 2) = (C(1) / 2 + CSin) / 3 / M(34)
3180:   For i = 2 To S + 1
3190:       D(i, 1) = (C(i - 1) + C(i) + 4 * CSin) / M(34) / 3
3200:       D(i, 2) = (C(i) / 2 + CSin) / 3 / M(34)
3210:       D(i, 3) = A(13) * ((C(i - 1) / 2 + CSin) ^ 3 + (C(i) / 2 + CSin) ^ 3) / 300 / M(34)
3220:   Next i
3230:   D(1, 4) = D(1, 1)
3240:   D(1, 5) = D(1, 3)
3250:   For i = 2 To S + 2
3260:       D(i, 4) = D(i, 1) - D(i - 1, 2) ^ 2 / D(i - 1, 4)
3270:       D(i, 5) = D(i, 3) - D(i - 1, 5) * D(i - 1, 2) / D(i - 1, 4)
3280:   Next i
3290:   M(S + 3) = 0
3300:   For i = S + 2 To 1 Step -1
3310:       M(i) = (D(i, 5) - D(i, 2) * M(i + 1)) / D(i, 4)
3320:   Next i
        '3360 IF A(23) <> 1 THEN 3400
        '3370 M(36) = 1'x
        '3380 M(37) = 1.5: M(38) = 1.5
        '3390 GOTO 3420
3400:   M(36) = 1.5 : M(37) = 1.5 'y collabor. pl.
3410:   M(38) = 1
3420:   M(39) = A(13) * (A(10) / 2 + CSin) / 100 / A(15)
3430:   M(15) = M(1)
3440:   If System.Math.Abs(M(15)) > System.Math.Abs(M(S + 2)) Then GoTo 3460
3450:   M(15) = M(S + 2)
        'Tubi/tappi saldatura
3460:   If Not ASME Then
            M(16) = M(36) * (M(39) / A(23) + System.Math.Sqrt(6 * System.Math.Abs(M(15)) / A(15) / A(23) / M(38))) + CSin
        Else
            M(16) = ThkASME(M(39) / A(23) * A(15), System.Math.Abs(M(15)) / A(23)) + CSin
        End If
3470:   M(17) = 0
3480:   For i = 1 To S + 1
3490:       k = C(i) / 2 + CSin
3500:       D(i, 6) = (M(i + 1) - M(i)) * 50 / A(13) / k
3510:       If System.Math.Abs(D(i, 6)) < k Then GoTo 3530
3520:       D(i, 6) = k * D(i, 6) / System.Math.Abs(D(i, 6))
3530:       Asin = (M(i) + M(i + 1) - (M(i + 1) - M(i)) * D(i, 6) / k + A(13) * (D(i, 6) ^ 2 - k ^ 2) / 100) / 2
3540:       If System.Math.Abs(Asin) < System.Math.Abs(M(17)) Then GoTo 3580
3550:       M(17) = Asin
3560:       M(18) = i
3570:       M(22) = D(i, 6)
3580:   Next i
        'Tubi/Tappi zona piena
        If Not ASME Then
            M(19) = M(39) + System.Math.Sqrt(6 * System.Math.Abs(M(17)) / M(37) / A(15)) + CSin
        Else
            M(19) = ThkASME(M(39) * A(15), System.Math.Abs(M(17))) + CSin
        End If
3600:   M(20) = 0 : xSin = 0
3610:   For i = 1 To S + 1
3620:       For j = 1 To f(i)
3630:           k = C(i) / 2 + CSin
3640:           xSin = xSin + 1
                Asin = Amom(i, X(xSin))
3670:           If System.Math.Abs(Asin) < System.Math.Abs(M(20)) Then GoTo 3700
3680:           M(20) = Asin
3690:           M(21) = xSin
3700:       Next j
3710:   Next i
        'Tubi tappi fori
        If Not ASME Then
3712:       M(23) = M(39) / M(33) + System.Math.Sqrt(6 * System.Math.Abs(M(20)) / M(37) / A(15) / M(33)) + CSin
        Else
3713:       M(23) = ThkASME(M(39) / M(33) * A(15), System.Math.Abs(M(20)) / M(33)) + CSin
        End If
3730:   M(40) = A(13) * (C(1) / 2 + CSin) / 100 / A(15)
        'T&B saldatura
        If Not ASME Then
            M(24) = M(36) * (M(40) / A(23) + System.Math.Sqrt(6 * System.Math.Abs(M(1)) / A(15) / M(38) / A(23))) + CSin
        Else
            M(24) = ThkASME(M(40) / A(23) * A(15), System.Math.Abs(M(1)) / A(23)) + CSin
        End If
3750:   M(25) = M(1) - A(13) * (A(10) / 2 + CSin) ^ 2 / 200
        'T&B centro
        If Not ASME Then
            M(26) = M(40) + System.Math.Sqrt(6 * System.Math.Abs(M(25)) / A(15) / M(37)) + CSin
        Else
            M(26) = ThkASME(M(40) * A(15), System.Math.Abs(M(25))) + CSin
        End If
3770:   M(30) = A(13) * (C(S + 1) / 2 + CSin) / 100 / A(15)
3780:   M(27) = M(S + 2) - A(13) * (A(10) / 2 + CSin) ^ 2 / 200
        'T&B saldatura
        If Not ASME Then
            M(28) = M(36) * (M(30) / A(23) + System.Math.Sqrt(6 * System.Math.Abs(M(S + 2)) / A(15) / A(23) / M(38))) + CSin
        Else
            M(28) = ThkASME(M(30) / A(23) * A(15), System.Math.Abs(M(S + 2)) / A(23)) + CSin
        End If
        'T&B centro
        If Not ASME Then
            M(29) = M(30) + System.Math.Sqrt(6 * System.Math.Abs(M(27)) / A(15) / M(37)) + CSin
        Else
            M(29) = ThkASME(M(30) * A(15), System.Math.Abs(M(27))) + CSin
        End If
        Exit Sub
        'ErrRisolvi: Print "Errore in Risolvi"; Err; Erl; M(33); M(37); a(15): End
    End Sub
    Private Function SetPassi() As Boolean
        Dim i As Short
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        SetPassi = True
        If A(19) - 1 < 1 Then Exit Function
        For i = 1 To A(19) - 1
            Dom(i) = "Passo fila" & Str(i) & "/" & Str(i + 1)
            Risp(i) = GlobalRoutines.myStr(MecData(0).Passo(i), 3, 2, False)
        Next
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Monitor.Motore.InputDati(A(19) - 1, "", Dom, Risp, "", Archiv, dAiu) Then SetPassi = False : Exit Function
        For i = 1 To A(19) - 1
            MecData(0).Passo(i) = Val(Risp(i))
        Next
    End Function
    Private Function Span(ByRef AA As Single, ByRef BB As Single, ByRef H As Single) As Boolean
        Dim iy As Boolean
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Dim ix As Integer
        Dim Nd As Short
        Dim Tit, Help As String
        Span = True
        Dom(1) = "Span Sommità  "
        Dom(2) = "Span Fondo    "
        AA = MecData(0).xx
        If AA < 10 Then
            AA = ReadLib(3, 1 + CShort(4 * (A(41) / 25.4 - 1.0!)))
            MecData(0).xx = AA
        End If
        If H > 0 Then
            Nd = 2
            If A(9) > 0 Then
                BB = A(9) - (A(19) - 1) * H - AA
            Else
                BB = AA
                A(9) = AA + BB + (A(19) - 1) * H
                MecData(0).HX3 = A(9)
            End If
        Else
            Nd = 1
        End If
        Risp(1) = GlobalRoutines.myStr(AA, 3, 2, False) ': LungSt(1) = -Len(Risp$(1))
        Risp(2) = GlobalRoutines.myStr(BB, 3, 2, False) ': LungSt(2) = -Len(Risp$(2))
        'If Nd = 1 Then LungSt(1) = -LungSt(1)
        '1470 INPUT "Span Sommita'  "; A
        '1480 B = A(9) - (A(19) - 1) * H - A
        '1490 PRINT "Span Fondo     "; B
        Tit = "Spans file estreme/T&B"
rifa1:  ' Help$ = "Clickare sui numeri|per aggiustamento automatico"
        'iHelp = TRUE: IF Nd = 1 THEN iHelp = FALSE
        'InputOpen 1, 2, Nd, Tit$, Dom$(), Risp$(), LungSt()
        'IF iHelp THEN
        '         junk = Alert(4, Help$, 4, 3, 10, 58, "OK", "", "")
        '         iHelp = FALSE
        'END IF
        'iy = InputDati(0, Nd, Tit$, Dom$(), Risp$(), LungSt())
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iy = Monitor.Motore.InputDati(Nd, Tit, Dom, Risp, "", Archiv, dAiu)
        If Not iy Then Span = False : Exit Function
        AA = Val(Risp(1)) : BB = Val(Risp(2))
        If H > 0 And System.Math.Abs(AA + BB + (A(19) - 1) * H - A(9)) > 0.1 Then
            Beep()
            Help = "Dati non compatibili:|Altezza interna=" & Str(A(9))
            Help = Help & "|Somma elementi=" & Str(AA + BB + (A(19) - 1) * H)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Help = Monitor.Motore.Inizio.ConvertiCr(Help)
            ix = MsgBox(Help, MsgBoxStyle.OKCancel + MsgBoxStyle.Information, "ISA")
            If ix = MsgBoxResult.Cancel Then Span = False : Exit Function
            GoTo rifa1
        End If
        MecData(0).xx = Val(Risp(1))
    End Function
    Private Sub StamTes()
        ifl = FreeFile()
        If MAWP = 0 Then
            FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        Else
            FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Append)
        End If
5010:   PrintLine(ifl, "1b" & Str(iRec))
        PrintLine(ifl, TAB(5), "* Program name: TESTAP  rev.2 (Date: Jun-04-1995) *")
5030:   'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ifl, TAB(5), CDbl("*** ") + Monitor.Motore.Inizio.Firma + CDbl(" ***") & Space(20) & "Page" & Str(iRec) & " of" & Str(nPag))
        '5040 PRINT #ifl, TAB(18); "======================================"
5060:   PrintLine(ifl)
        If Not ASME Then
            Print(ifl, TAB(7), "Foglio di verifica ISPESL/VSR", TAB(41))
        Else
            Print(ifl, TAB(7), "Analisi delle tensioni ASME  ", TAB(41))
        End If
5100:   PrintLine(ifl, "No Ck ", TAB(49), CK, TAB(57), "Comm.  ", TAB(75 - Len(CO)), CO)
5101:   XgStr = DateString
5102:   GGStr = Mid(XgStr, 4, 2) : MMStr = Left(XgStr, 2) : AAStr = Right(XgStr, 4)
5110:   Print(ifl, TAB(41), "Foglio .. di ..", TAB(57), "Data", TAB(65))
5111:   PrintLine(ifl, GlobalRoutines.FormatS("\\-\\-\  \", GGStr, MMStr, AAStr))
5120:   PrintLine(ifl, TAB(7), "Testata a Tappi", TAB(41), "Eseg......", TAB(57), "Visto.....", TAB(67), "Rev.", TAB(72), A(8))
5130:   PrintLine(ifl)
        'Item = "????"
5140:   PrintLine(ifl, TAB(7), "Item", TAB(13), ItemStr, TAB(41), TIPT)
5150:   PrintLine(ifl)
5160:   Print(ifl, TAB(7), "Mat. Testata", TAB(37 - Len(Mat)), Mat, TAB(41), "Soll. Amm. F-1(kg/mm2)=", TAB(71))
5170:   PrintLine(ifl, GlobalRoutines.FormatS("##.#", A(15)))
5180:   Print(ifl, TAB(7), "Mat. Lamiere", TAB(37 - Len(MATL)), MATL, TAB(41), "Soll. Amm. F-2(kg/mm2)=", TAB(71))
5190:   PrintLine(ifl, GlobalRoutines.FormatS("##.#", A(16)))
5195:   If BocchL = 0 Then GoTo 5220
5200:   Print(ifl, TAB(7), "Mat. Bocchelli", TAB(37 - Len(MATB)), MATB, TAB(41), "Soll. Amm. F-3(kg/mm2)=", TAB(71))
5210:   PrintLine(ifl, GlobalRoutines.FormatS("##.#", A(17)))
5220:   PrintLine(ifl)
5225:   If MAWP = 1 Then GoTo 5243
5230:   Print(ifl, TAB(7), "Press. Prog.  (kg/cm2)=", TAB(32))
5240:   Print(ifl, GlobalRoutines.FormatS("###.#", A(13)))
5242:   GoTo 5245
5243:   Print(ifl, TAB(7), "Press. Max.   (kg/cm2)=", TAB(32))
5244:   Print(ifl, GlobalRoutines.FormatS("###.#", A(13)))
5245:   Print(ifl, TAB(41), "Temp. Prog.  (Gradi C)=", TAB(70))
5250:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", A(14)))
5260:   Print(ifl, TAB(7), "Sovrasp.  Corros. (mm)=", TAB(34))
5270:   Print(ifl, GlobalRoutines.FormatS("#.#", A(18)))
5275:   Print(ifl, TAB(41), "Numero File e Setti   =", TAB(70))
5280:   PrintLine(ifl, GlobalRoutines.FormatS("## ##", A(19), A(20)))
5290:   PrintLine(ifl)
5300:   Print(ifl, TAB(7), "Alt. Tot. Interna (mm)=", TAB(32))
5310:   Print(ifl, GlobalRoutines.FormatS("###.#", A(9)))
5320:   Print(ifl, TAB(41), "Largh. Interna    (mm)=", TAB(70))
5330:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", A(10)))
5340:   Print(ifl, TAB(7), "Sp. P. Tubi/Tappi (mm)=", TAB(32))
5350:   Print(ifl, GlobalRoutines.FormatS("###.#", A(21)))
5360:   Print(ifl, TAB(41), "Spess. P. Sup/Inf (mm)=", TAB(70))
5370:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", A(22)))
5380:   Print(ifl, TAB(7), "Sp. P. Terminali  (mm)=", TAB(32))
5390:   Print(ifl, GlobalRoutines.FormatS("###.#", A(30)))
5400:   Print(ifl, TAB(41), "Sp. Setti/Rinf.   (mm)=", TAB(70))
5410:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", A(27)))
5420:   Print(ifl, TAB(7), "Diametro Tubi     (mm)=", TAB(32))
5430:   Print(ifl, GlobalRoutines.FormatS("###.#", A(41)))
5440:   Print(ifl, TAB(41), "Passo Tubi        (mm)=", TAB(70))
5450:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", A(42)))
5452:   PrintLine(ifl)
5460:   Print(ifl, TAB(7), "Coefficiente Molt.   X=", TAB(32))
5470:   Print(ifl, GlobalRoutines.FormatS("###.#", M(36)))
5480:   Print(ifl, TAB(41), "Coeff. Coll. Plast.  Y=", TAB(70))
5490:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", M(37)))
5500:   Print(ifl, TAB(7), "Eff. Sald. Piastre Z-1=", TAB(32))
5510:   Print(ifl, GlobalRoutines.FormatS("##.##", A(23)))
5520:   Print(ifl, TAB(41), "Eff. Legamento     Z-L=", TAB(70))
5530:   PrintLine(ifl, GlobalRoutines.FormatS("##.##", M(33)))
5535:   If A(20) = 0 Then GoTo 5560
5540:   Print(ifl, TAB(7), "Eff. Sald. Setti   Z-2=", TAB(32))
5550:   Print(ifl, GlobalRoutines.FormatS("##.##", A(26)))
5560:   If A(17) = 0 Then PrintLine(ifl) : GoTo 5580
5562:   Print(ifl, TAB(41), "Eff. Sald. Bocch.  Z-3=", TAB(70))
5570:   PrintLine(ifl, GlobalRoutines.FormatS("##.##", A(47)))
5575:   PrintLine(ifl) : GoTo 5590
5580:   PrintLine(ifl)
5590:   Print(ifl, TAB(7), "Mom. Inerzia  JM (mm4)=", TAB(32))
5600:   Print(ifl, GlobalRoutines.FormatS("#####", M(34)))
5605:   Print(ifl, TAB(41), "Mom. Inerzia JN  (mm4)=", TAB(70))
5610:   PrintLine(ifl, GlobalRoutines.FormatS("#####", M(35)))
5615:   PrintLine(ifl)
5620:   If (A(20) + 1) > 6 Then GoTo 5650
5630:   AA = A(20) + 1
5640:   GoTo 5660
5650:   AA = 6
5660:   BB = 1
5670:   Sub5730()
5680:   If A(20) + 1 < 7 Then GoTo 5900
5690:   AA = A(20) + 1
5700:   BB = 7
5710:   Sub5730()
5720:   GoTo 5900
5900:   'IF A(4) = 0 GOTO 6230
5905:   PrintLine(ifl)
5910:   AA = 0
5920:   For i = 1 To A(20) + 1
5930:       Print(ifl, TAB(7), "Pos Fori Cam", TAB(19), i, TAB(22), "=", TAB(24))
5940:       If f(i) > 6 Then GoTo 5970
5950:       n = f(i)
5960:       GoTo 5980
5970:       n = 6
5980:       For j = 1 To n
5990:           AA = AA + 1
6000:           Print(ifl, GlobalRoutines.FormatS("####.#   ", X(AA)))
6010:       Next j
6020:       If f(i) < 7 Then GoTo 6100
6030:       AA = AA + 1
6035:       Print(ifl, TAB(25))
6040:       Print(ifl, GlobalRoutines.FormatS("####.#   ", X(AA)))
6050:       For n = 8 To f(i)
6060:           AA = AA + 1
6070:           Print(ifl, GlobalRoutines.FormatS("####.#   ", X(AA)))
6080:       Next n
6100:   Next i
        '6110 PRINT #ifl,
        '6120 PRINT #ifl, TAB(7); "Coeff. Eq.   1 ="; TAB(32);
        '6130 FOR i = 1 TO 3
        '6140 PRINT #ifl, USING "###.#### "; D(1, i);
        '6150 NEXT i
        '6160 FOR i = 2 TO A(20) + 1
        '6165 PRINT #ifl, TAB(7); "Coeff. Eq."; TAB(19); i; TAB(22); "="; TAB(23);
        '6170 PRINT #ifl, USING "###.#### "; D(i - 1, 2); D(i, 1); D(i, 2); D(i, 3)
        '6180 NEXT i
        '6190 PRINT #ifl, TAB(7); "Coeff. Eq."; TAB(19); A(20) + 2; TAB(22); "="; TAB(23);
        '6200 PRINT #ifl, USING "###.#### "; D(A(20) + 1, 2); D(A(20) + 2, 1);
        '6210 PRINT #ifl, USING "         ###.####"; D(A(20) + 2, 3)
        '6220 PRINT #ifl,
6230:   If A(20) + 2 > 5 Then GoTo 6260
6240:   AA = A(20) + 2
6250:   GoTo 6270
6260:   AA = 5
6270:   BB = 1
        Sub6410()
6290:   If A(20) + 2 < 6 Then GoTo 6520
6300:   If A(20) + 2 > 10 Then GoTo 6330
6310:   AA = A(20) + 2
6320:   GoTo 6340
6330:   AA = 10
6340:   BB = 6
        Sub6410()
6360:   If A(20) + 2 < 11 Then GoTo 6520
6370:   AA = A(20) + 2
6380:   BB = 11
        Sub6410()
6520:   PrintLine(ifl)
6530:   Print(ifl, TAB(7), "Mom. Camp.  (kg mm/mm)=", TAB(32))
6540:   Print(ifl, GlobalRoutines.FormatS("####.#", M(17)))
6550:   Print(ifl, TAB(48), "Campata =", TAB(59))
6560:   Print(ifl, GlobalRoutines.FormatS("##", M(18)))
6570:   Print(ifl, TAB(63), " - X = ", TAB(70))
6580:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", M(22)))
6590:   Print(ifl, TAB(7), "Mom. Forat. (kg mm/mm)=", TAB(32))
6600:   Print(ifl, GlobalRoutines.FormatS("####.#", M(20)))
6610:   Print(ifl, TAB(48), "Fila N.")
6620:   Print(ifl, TAB(63), "     = ", TAB(70))
6630:   PrintLine(ifl, GlobalRoutines.FormatS("###.#", M(21)))
6640:   Print(ifl, TAB(7), "Mom. M.P-S  (kg mm/mm)=", TAB(32))
6650:   Print(ifl, GlobalRoutines.FormatS("####.#", M(25)))
6660:   Print(ifl, TAB(48), "Mom. Mezz P-Inf")
6670:   Print(ifl, TAB(63), "     =", TAB(69))
6680:   PrintLine(ifl, GlobalRoutines.FormatS("####.#", M(27)))
6690:   PrintLine(ifl)
6700:   Print(ifl, TAB(7), "P. Tub/Tappi : 1=", TAB(32))
6702:   AA = M(39) / A(23)
6704:   BB = (M(16) - A(18)) / M(36) - AA
6705:   xStr = "*(" : yStr = "+" : wStr = ")+" : jStr = "=" : Zmin = "<" : Zmag = ">"
        If Not ASME Then
            If M(16) > A(21) Then zStr = Zmag Else zStr = Zmin
6710:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", M(36), xStr, AA, yStr, BB, wStr, A(18), jStr, M(16), zStr, A(21)))
6720:       Print(ifl, TAB(7), "               2=", TAB(32))
            If M(19) > A(21) Then zStr = Zmag Else zStr = Zmin
6730:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(39), yStr, M(19) - M(39) - A(18), wStr, A(18), jStr, M(19), zStr, A(21)))
6735:       AA = M(39) / M(33)
6740:       Print(ifl, TAB(7), "               3=", TAB(32))
            If M(23) > A(21) Then zStr = Zmag Else zStr = Zmin
6750:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", 1, xStr, AA, yStr, M(23) - AA - A(18), wStr, A(18), jStr, M(23), zStr, A(21)))
        Else
            If M(16) > A(21) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(16) - A(18), wStr, A(18), jStr, M(16), zStr, A(21)))
            Print(ifl, TAB(7), "               2=", TAB(32))
            If M(19) > A(21) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(19) - A(18), wStr, A(18), jStr, M(19), zStr, A(21)))
            AA = M(39) / M(33)
            Print(ifl, TAB(7), "               3=", TAB(32))
            If M(23) > A(21) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(23) - A(18), wStr, A(18), jStr, M(23), zStr, A(21)))
        End If
6760:   PrintLine(ifl)
6770:   Print(ifl, TAB(7), "P. Sup/Inf mm: 1=", TAB(32))
6780:   AA = M(40) / A(23)
6790:   BB = (M(24) - A(18)) / M(36) - AA
        If Not ASME Then
            If M(24) > A(22) Then zStr = Zmag Else zStr = Zmin
6800:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", M(36), xStr, AA, yStr, BB, wStr, A(18), jStr, M(24), zStr, A(22)))
6810:       Print(ifl, TAB(7), "               2=", TAB(32))
            If M(26) > A(22) Then zStr = Zmag Else zStr = Zmin
6820:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(40), yStr, M(26) - M(40) - A(18), wStr, A(18), jStr, M(26), zStr, A(22)))
6825:       AA = M(30) / A(23)
6827:       BB = (M(28) - A(18)) / M(36) - AA
6830:       Print(ifl, TAB(7), "               3=", TAB(32))
            If M(28) > A(22) Then zStr = Zmag Else zStr = Zmin
6840:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", M(36), xStr, AA, yStr, BB, wStr, A(18), jStr, M(28), zStr, A(22)))
6850:       Print(ifl, TAB(7), "               4=", TAB(32))
            If M(29) > A(22) Then zStr = Zmag Else zStr = Zmin
6860:       PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \##.#\ \##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(30), yStr, M(29) - M(30) - A(18), wStr, A(18), jStr, M(29), zStr, A(22)))
        Else
            If M(24) > A(22) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(24) - A(18), wStr, A(18), jStr, M(24), zStr, A(22)))
            Print(ifl, TAB(7), "               2=", TAB(32))
            If M(26) > A(22) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(26) - A(18), wStr, A(18), jStr, M(26), zStr, A(22)))
            AA = M(30) / A(23)
            BB = (M(28) - A(18)) / M(36) - AA
            Print(ifl, TAB(7), "               3=", TAB(32))
            If M(28) > A(22) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(28) - A(18), wStr, A(18), jStr, M(28), zStr, A(22)))
            Print(ifl, TAB(7), "               4=", TAB(32))
            If M(29) > A(22) Then zStr = Zmag Else zStr = Zmin
            PrintLine(ifl, GlobalRoutines.FormatS("##.# \  \       ##.#\   \##.#\ \##.# \\##.#", 1, xStr, M(29) - A(18), wStr, A(18), jStr, M(29), zStr, A(22)))
        End If
6870:   PrintLine(ifl)
6880:   Print(ifl, TAB(7), "P.Terminali mm:1=", TAB(29))
6890:   Asin = (A(29) - A(18)) / A(32) * A(33) / A(36)
6895:   vStr = "*" : VV = "/"
        If A(29) > A(30) Then zStr = Zmag Else zStr = Zmin
6900:   PrintLine(ifl, GlobalRoutines.FormatS("#.###\\#.##\ \###.#\ \#.###\\#.#\ \##.# \\##.#", A(32), VV, A(33), vStr, A(36), vStr, Asin, yStr, A(18), jStr, A(29), zStr, A(30)))
6910:   PrintLine(ifl)
        '6915 IF A(20) = 0 GOTO 6900'Aggiunto
6920:   Print(ifl, TAB(7), "Setti       mm:")
6922:   Print(ifl, GlobalRoutines.FormatS("##", A(34)))
6923:   Print(ifl, "=", TAB(46))
        If A(24) > A(27) Then zStr = Zmag Else zStr = Zmin
6930:   PrintLine(ifl, GlobalRoutines.FormatS("##.#\ \#\ \##.#\ \##.# \\##.#", A(24) - 2 * A(18), yStr, 2, vStr, A(18), jStr, A(24), zStr, A(27)))
6940:   If A(28) = 0 Then GoTo 7050
6950:   Print(ifl, TAB(7), "Fori Rinf:")
        GoTo 7020
6960:   If A(28) = 55 Then GoTo 7020
6970:   If A(28) = 50 Then GoTo 7000
6980:   Print(ifl, TAB(17), "Asole (mm)=", TAB(31))
6990:   GoTo 7030
7000:   Print(ifl, TAB(17), "Tondi (mm)=", TAB(31))
7010:   GoTo 7030
7020:   Print(ifl, TAB(17), "Quadri(mm)=", TAB(31))
7030:   Print(ifl, GlobalRoutines.FormatS("##", A(28)))
7035:   Print(ifl, TAB(47), "Passo Min/Max =", TAB(62))
7037:   uStr = "/"
7040:   PrintLine(ifl, GlobalRoutines.FormatS("###.# \\###.#", A(25), uStr, A(44)))
7050:   Print(ifl, TAB(7), "Posizione           :")
7060:   For i = 1 To A(20)
7070:       Print(ifl, GlobalRoutines.FormatS("  ## ", i))
7080:   Next i
7090:   Print(ifl, TAB(7), "Setto(S)-Rinf.(R)   :")
7100:   For i = 1 To A(20)
7110:       If R(i) Then GoTo 7140
7120:       Print(ifl, "   R ")
7130:       GoTo 7150
7140:       Print(ifl, "   S ")
7150:   Next i
7160:   Print(ifl, TAB(7), "Sald P Ter. Si-No   :")
7170:   For i = 1 To A(20)
7180:       If S(i) Then GoTo 7210
7190:       Print(ifl, "   No")
7200:       GoTo 7220
7210:       Print(ifl, "   Si")
7220:   Next i
7230:   PrintLine(ifl)
7270:   If A(17) = 0 Then FileClose(ifl) : Exit Sub
7280:   If A(46) = 0 Then FileClose(ifl) : Exit Sub
7290:   Print(ifl, TAB(7), "Bocch. Sag. (in) ", TAB(25))
7300:   PrintLine(ifl, GlobalRoutines.FormatS("##\\#.##\ \#.##\ \##.#\ \#.##\ \##.#\ \##.#\ \##.#", A(45), jStr, D(13, 2), vStr, D(13, 6), vStr, M(31), vStr, System.Math.Sqrt(A(13) / 100 / A(17) / A(47)), yStr, A(18), jStr, M(32), zStr, A(48)))
7310:   If M(44) = 0 Then FileClose(ifl) : Exit Sub
7320:   Print(ifl, TAB(7), "Rinforzo    (mm) ", TAB(25))
7330:   PrintLine(ifl, GlobalRoutines.FormatS("##\ \                ##.#\ \#\ \##.#\ \##.#\ \##.#", M(44), jStr, M(45) - 2 * A(18), yStr, 2, vStr, A(18), jStr, M(45), zStr, A(49)))
        FileClose(ifl)
7340:   Exit Sub
7350:   Print(ifl, TAB(7), "Tronchetto  (in) ", TAB(25))
7360:   PrintLine(ifl, GlobalRoutines.FormatS("##\ \         ###.#\ \##.####\ \##.#\ \##.#\ \##.#", A(45), jStr, M(31), vStr, (M(32) - A(18)) / M(31), yStr, A(18), jStr, M(32), zStr, A(48)))
        FileClose(ifl)
    End Sub
    Private Sub Sub6410()
6410:   Print(ifl, TAB(7), "Posizione     ", TAB(32))
6420:   For i = BB To AA
6430:       Print(ifl, GlobalRoutines.FormatS("      ## ", i))
6440:   Next i
6450:   Print(ifl, TAB(7), "Mom. Caratt.(kg mm/mm)=", TAB(32))
6460:   For i = BB To AA
6470:       Print(ifl, GlobalRoutines.FormatS(" #####.# ", M(i)))
6480:   Next i
6490:   PrintLine(ifl)
    End Sub
    Private Sub Sub5730()
5730:   Print(ifl, TAB(7), "Camera N.      =", TAB(29))
5740:   For i = BB To AA
5750:       Print(ifl, GlobalRoutines.FormatS("##       ", i))
5760:   Next i
5770:   Print(ifl, TAB(7), "File/Camera    =", TAB(29))
5780:   For i = BB To AA
5790:       Print(ifl, GlobalRoutines.FormatS("##       ", f(i)))
5800:   Next i
5810:   Print(ifl, TAB(7), "Alt Int Cam(mm)=", TAB(25))
5820:   For i = BB To AA
5830:       Print(ifl, GlobalRoutines.FormatS("###.#    ", C(i)))
5840:   Next i
5850:   PrintLine(ifl)
    End Sub
    Private Function ABot(ByRef X As Single) As Single
        ABot = M(A(20) + 2) + A(13) * (X * X - A(10) * A(10) / 4) / 200
    End Function
    Private Function Amom(ByRef i As Short, ByRef X As Single) As Single
        Dim AA As Single
        AA = (M(i) + M(i + 1)) / 2 + (M(i) - M(i + 1)) * X / C(i)
        AA = AA + A(13) * (X * X - C(i) * C(i) / 4) / 200
        Amom = AA
    End Function
    Private Function ATop(ByRef X As Single) As Single
        ATop = M(1) + A(13) * (X * X - A(10) * A(10) / 4) / 200
    End Function
    Private Sub Grafic(ByRef iRis As Short, ByRef iCassa As Short, ByRef Nome2 As String)
        'M(i),i=1 to A(20)+1:momenti
        'C(i),i=1 to A(20):altezze interne camere
        'A(10),larghezza interna A(9) altezza interna
        'A(21) thk TS A(22) thk T&B   A(27) thk setti  A(41) Dia tubi
        'F(i) numero file per camera
        'X(j),j=1 to tutte le file; posizione fila rispetto a mezzeria camera
        'On Local Error GoTo ErrGrafic
        ya = -(A(10) / 2 + A(22)) * 1.2 : yb = A(9) - ya : xa = -A(10) * 0.8 : xb = xa + 640 / 480 * (yb - ya)
        IniziaRoutines()
        With Monitor.routines
            .Scala(xa, xb, ya, yb)
            Call .refabs()
            DrawSect()
            ScalMom()
            DrawMTop()
            DrawMSid()
            DrawMBot()
            Testi()
        End With
        Exit Sub
    End Sub
    Private Sub DrawTubi()
        With Monitor.routines
            For j = 1 To f(ii)
160:            ytub = yLiv + C(ii) / 2 + X(jj)
                jj = jj + 1
                .tratto(xdes, ytub + A(41) / 2, xdes + A(21), ytub + A(41) / 2, 0.2, 0)
                .tratto(xdes, ytub - A(41) / 2, xdes + A(21), ytub - A(41) / 2, 0.2, 0)
                .tratto(xdes - A(41), ytub, xdes + A(21) + A(41), ytub, 0.1, 4) ' &HFF00
            Next
        End With
    End Sub
    Private Sub Testi()
        AltText1 = 4 ' * (yb - ya) / dy
        AltText2 = 2 * AltText1
        If A(52) = 0.0! Then A(52) = MecData(1).SP(1 - 1)
        Testo = "Spessore ass. P.Top&Bot:" + GlobalRoutines.myStr(A(52), 3, 2, False) + "; minimo  :" + GlobalRoutines.myStr(MecData(1).SP(1 - 1), 3, 2, False)
        xSin = 1.2 * A(10) : ySin = A(9)
        With Monitor.routines
            Call .ECRIR(Testo)
            Call .texte0(xSin, ySin, 0.0!, AltText1, 0.6)
            If A(51) = 0.0! Then A(51) = MecData(1).SP(2 - 1)
            Testo = "Spessore ass. P.tub/tap:" + GlobalRoutines.myStr(A(51), 3, 2, False) + "; minimo  :" + GlobalRoutines.myStr(MecData(1).SP(2 - 1), 3, 2, False)
            xSin = 1.2 * A(10) : ySin = ySin - 20
            Call .ECRIR(Testo)
            Call .texte0(xSin, ySin, 0.0!, AltText1, 0.6)
            If A(20) > 0 Then
                Testo = "Spessore assunto Setti :" + GlobalRoutines.myStr(A(27), 3, 2, False) + ";calcolato:" + GlobalRoutines.myStr(A(24), 3, 2, False)
                xSin = 1.2 * A(10) : ySin = ySin - 20
                Call .ECRIR(Testo)
                Call .texte0(xSin, ySin, 0.0!, AltText1, 0.6)
            End If
            Testo = "Spessore assunto Ends  :" + GlobalRoutines.myStr(A(30), 3, 2, False) + ";calcolato:" + GlobalRoutines.myStr(A(29), 3, 2, False)
            xSin = 1.2 * A(10) : ySin = ySin - 20
            Call .ECRIR(Testo)
            Call .texte0(xSin, ySin, 0.0!, AltText1, 0.6)
            jobStr = MecData(0).JOBNUM
            If AddDistinta > 0 Then comm = objDatBase.Readreco(1, 46, 2) Else comm = job.contratto '"SALV"
            If Len(LTrim(RTrim(comm))) > 0 And Asc(comm) > 32 Then jobStr = comm
            Testo = "CO. " & RTrim(jobStr) & " Item " & RTrim(ItemStr) & " / " & TIPT
            xSin = 1.5 * A(10) : ySin = 0
            Call .ECRIR(Testo)
            xSin = 1.2 * A(10) : ySin = -0.5 * A(10)
            Call .texte0(xSin, ySin, 0.0!, AltText2, 0.6)
        End With
    End Sub
    Private Sub DrawMsid()
        yLiv = A(9) - C(1) / 2
        With Monitor.routines
            For j = 1 To A(20) + 1
                For i = -5 To 4
150:                ySin = CSng(i) * C(j) / 10
                    XM = Amom(j, ySin) * Scal
                    y1 = CSng(i + 1) * C(j) / 10
                    XM1 = Amom(j, y1) * Scal
                    .tratto(xdes + A(21) + XM, yLiv + ySin, xdes + A(21) + XM1, yLiv + y1, 0.1, 0)
                    If i = -5 Then .tratto(xdes + A(21) + XM, yLiv + ySin, xdes + A(21), yLiv + ySin, 0.1, 2) '&H3333
                    .tratto(xdes + A(21) + XM1, yLiv + y1, xdes + A(21), yLiv + y1, 0.1, 2) ' &H3333
                Next
                yLiv = yLiv - C(j) / 2 - A(27) - C(j + 1) / 2
            Next
        End With
    End Sub
    Private Sub Trtr()
        With Monitor.routines
            .tratto(0, yLiv, xdes, yLiv, 0.1, 0)
            yLiv1 = yLiv : yLiv = yLiv - C(1)
            .tratto(xdes, yLiv1, xdes, yLiv, 0.1, 0)
        End With
    End Sub
    Private Sub DrawMBot()
        With Monitor.routines
            For i = 0 To 9
140:            xSin = CSng(i) * xdes / 10
                YM = ABot(xSin) * Scal
                x1 = CSng(i + 1) * xdes / 10
                YM1 = ABot(x1) * Scal
                .tratto(xSin, -A(22) - YM, x1, -A(22) - YM1, 0.1, 0)
                If i = 0 Then .tratto(xSin, -A(22) - YM, xSin, -A(22), 0.1, 2) '&H3333
                .tratto(x1, -A(22) - YM1, x1, -A(22), 0.1, 2) '&H3333
            Next
        End With
    End Sub
    Private Sub DrawMTop()
        With Monitor.routines
            For i = 0 To 9
130:            xSin = CSng(i) * xdes / 10
                YM = ATop(xSin) * Scal
                x1 = CSng(i + 1) * xdes / 10
                YM1 = ATop(x1) * Scal
                .tratto(xSin, A(9) + A(22) + YM, x1, A(9) + A(22) + YM1, 0.1, 0)
                If i = 0 Then .tratto(xSin, A(9) + A(22) + YM, xSin, A(9) + A(22), 0.1, 2) ' &H3333
                .tratto(x1, A(9) + A(22) + YM1, x1, A(9) + A(22), 0.1, 2) '&H3333
            Next
        End With
    End Sub

    Private Sub ScalMom()
        Amax = 0
        For i = 1 To A(20) + 2
            If System.Math.Abs(M(i)) > Amax Then Amax = System.Math.Abs(M(i))
        Next
        If System.Math.Abs(ATop(0.0!)) > Amax Then Amax = System.Math.Abs(ATop(0.0!))
        If System.Math.Abs(ABot(0.0!)) > Amax Then Amax = System.Math.Abs(ABot(0.0!))
        For i = 1 To A(20)
            If System.Math.Abs(Amom(i, 0.0!)) > Amax Then Amax = System.Math.Abs(Amom(i, 0.0!))
        Next
        Scal = xdes / Amax
    End Sub
    Private Sub DrawSect()
DrawSect:
        With Monitor.routines
            .tratto(0, -A(9) / 5, 0, 1.2 * A(9), 0.1, 2) '&H3333'asse     2
            .tratto(0, -A(22), A(10) / 2 + A(21), -A(22), 0.2, 0)
            .tratto(A(10) / 2 + A(21), -A(22), A(10) / 2 + A(21), A(9) + A(22), 0.2, 0)
            .tratto(A(10) / 2 + A(21), A(9) + A(22), 0, A(9) + A(22), 0.2, 0)
            yLiv = A(9) : xdes = A(10) / 2 : jj = 1
            If A(20) = 0 Then
                Trtr()
122:            ii = 1
                DrawTubi()
            Else
                For i = 1 To A(20)
                    If i = 1 Then Trtr()
                    ii = i
                    DrawTubi()
                    .tratto(0, yLiv, xdes, yLiv, 0.2, 0)
                    yLiv = yLiv - A(27)
                    .tratto(0, yLiv, xdes, yLiv, 0.2, 0)
                    yLiv1 = yLiv : yLiv = yLiv - C(i + 1)
                    .tratto(xdes, yLiv1, xdes, yLiv, 0.2, 0)
                    If i = A(20) Then
                        ii = i + 1
                        DrawTubi()
                    End If
                Next
            End If
            .tratto(xdes, yLiv, 0, yLiv, 0.2, 0)
        End With
    End Sub
    Private Function testap(ByRef iCassa As Short, ByRef iTest As Short) As Boolean
1:      testap = True
        A(4) = 1
        Stringa(1) = "VSR     "
        Stringa(2) = "ASME     "
        AAsng = Monitor.Motore.Quale(2, "Analisi delle tensioni", Stringa, "", 1)
        If AAsng = 2 Then ASME = True Else ASME = False
        CK = MecData(0).ICKNR
        CO = MecData(0).JOBNUM
        ItemStr = MecData(0).ITEMNO
        A(8) = Val(MecData(0).IREV)
        TIPTI = MecData(0).HEADER
        TIPT = TIPTI
        '290 INPUT "Sezione Cassa"; A(12)
        A(13) = MecData(0).P
        A(14) = MecData(0).T
        T = A(14)
        Mat = MecData(0).MATUG
        '496 IF BOCH = 1 GOTO 4120
        'A(1) = A(15)
        A(15) = MecData(0).SUG
        MATL = Mat
        'A(2) = A(16)
        A(16) = A(15)
        A(18) = MecData(0).CA
        A(20) = MecData(0).NS
        A(19) = 0
        For i = 1 To A(20) + 1 : A(19) = A(19) + System.Math.Abs(MecData(0).Nfile(i - 1)) : Next
        If A(19) = 0 Or LungSel = 0 Then If Not FilCam() Then testap = False : Exit Function
        If A(20) > 16 Then
            Debug.Print("Errore 1 in Testap")
            Stop
        End If
        If A(20) = 0 Then
            f(1) = A(19)
        Else
RifiL:
            AAsng = 0
            For i = 1 To A(20) + 1
                f(i) = System.Math.Abs(MecData(0).Nfile(i - 1))
                AAsng = AAsng + f(i)
                If MecData(0).Nfile(i - 1) < 0 Then R(i) = 0 Else R(i) = 1
            Next i
            If AAsng <> A(19) Then
                Beep()
                Help = "ATTENZIONE!!!|Somma file parziali =" & AAsng.ToString & "|File totali =" & Str(A(19))
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(Help))
                If Not FilCam() Then testap = False : Exit Function
                GoTo RifiL
            End If
        End If
        A(9) = MecData(0).HX3
        A(10) = MecData(0).H
        H = MecData(0).PVERT
        A(41) = MecData(0).DO_Renamed
        A(42) = MecData(0).TSP
        If A(20) = 0 Then
            A(26) = 0 : A(27) = 0 : A(28) = 0
        Else
            A(27) = MecData(0).SP(3 - 1) 'sp. setti?
            If A(27) = 0 Then A(27) = 12
            A(26) = MecData(0).EWPS
        End If
        AAsng = 2
        If LungSel = 0 Then
            Stringa(1) = "Costante"
            Stringa(2) = "Variabile"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            AAsng = Monitor.Motore.Quale(2, "Distanza tra le file", Stringa, "", 1)
        End If
        If AAsng = 2 Then GoTo 1510
        If Not Span(AAsng, BBsng, H) Then testap = False : Exit Function
        GoTo 1780
1510:   AAsng = A(20) * A(27)
        For i = 1 To A(20) + 1
            If MecData(0).HX5(i) > 0 Then
                C(i) = MecData(0).HX5(i)
            Else
                C(i) = (f(i) + 1) * H
            End If
            C(i) = C(i) - MecData(0).SP(3 - 1)
            If i = 1 Or i = A(20) + 1 Then C(i) = C(i) + MecData(0).SP(3 - 1) / 2
            AAsng = AAsng + C(i)
            Risp(i) = GlobalRoutines.myStr(C(i), 3, 2, False)
            Dom(i) = "Cam." & Str(i) ': LungSt(i) = Len(Risp$(i))
        Next i
        If LungSel = 0 Then
RifaiC:
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.Chiamante = Monitor
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Not Monitor.Motore.InputDati(A(20) + 1, "Camere al netto setti", Dom, Risp, "", Archiv, dAiu) Then testap = False : Exit Function
            AAsng = A(20) * A(27)
            For i = 1 To A(20) + 1
                C(i) = Val(Risp(i))
                AAsng = AAsng + C(i)
                MecData(0).HX5(i) = C(i) + MecData(0).SP(3 - 1)
                If i = 1 Or i = A(20) + 1 Then MecData(0).HX5(i) = MecData(0).HX5(i) - MecData(0).SP(3 - 1) / 2
            Next
        End If
        If System.Math.Abs(AAsng - A(9)) > 1.0! Then
            Beep()
            Help = "ATTENZIONE!!!|Somma campate + setti=" & AAsng.ToString & "|Altezza totale nota=" & Str(A(9))
            Help = Help & "|Vuoi cambiare l'altezza delle camere ?"
            i = MsgBox(Help, MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "ISA")
            If i = MsgBoxResult.Cancel Then testap = False : Exit Function
            If i = MsgBoxResult.Yes Then GoTo RifaiC Else A(9) = AAsng : MecData(0).HX3 = AAsng
        Else
            A(9) = AAsng : MecData(0).HX3 = AAsng
            '   FOR i = 1 TO A(20) + 1
            '     MecData(0).HX5(i) = C(i) + MecData(0).Sp(3)
            '     IF i = 1 OR i = A(20) + 1 THEN MecData(0).HX5(i) = MecData(0).HX5(i) - MecData(0).Sp(3) / 2
            '   NEXT
        End If
        AAsng = 0
        If Not SetPassi() Then testap = False : Exit Function
        If Not Span(AAsng, BBsng, 0.0!) Then testap = False : Exit Function
        Call Calcx(AAsng, 0.0!)
        GoTo 1970
1780:   If A(20) = 0 Then C(1) = A(9) : GoTo Cal
1810:   C(1) = AAsng + (f(1) - 0.5) * H - A(27) / 2
1820:   For i = 2 To A(20)
1830:       C(i) = f(i) * H - A(27)
1840:   Next i
1850:   C(A(20) + 1) = BBsng + (f(A(20) + 1) - 0.5) * H - A(27) / 2
Cal:    Call Calcx(AAsng, H)
        For i = 1 To A(20) + 1
            MecData(0).HX5(i) = C(i) + MecData(0).SP(3 - 1)
            If i = 1 Or i = A(20) + 1 Then MecData(0).HX5(i) = MecData(0).HX5(i) - MecData(0).SP(3 - 1) / 2
        Next
1970:   If A(20) = 0 Then GoTo 2660
1980:   A(40) = 0 : A(43) = 0 : AAsng = 0
1990:   For i = 1 To A(20)
2000:       m1 = C(i) + C(i + 1) + 4 * A(18)
2010:       If R(i) Then GoTo 2080
2020:       AAsng = 1
2030:       BBsng = f(i)
2040:       If BBsng > f(i + 1) Then GoTo 2060
2050:       BBsng = f(i + 1)
2060:       If m1 < A(43) Then GoTo 2080
2070:       A(43) = m1
2080:       If m1 < A(40) Then GoTo 2110
2090:       A(40) = m1
2100:       A(34) = i
2110:   Next i
2120:   A(24) = A(13) * A(40) / 200 / A(16) / A(26) + 2 * A(18)
        '2130 IF A(24) < A(27) THEN 2170
        '------------------------------------
        If A(24) > A(27) Then A(27) = A(24)
        GoTo 2210
        '-----------------------------------
        '2140 Print: Print "Spessore Setto Assunto  mm "; A(27); "  Calcolato mm "; A(24)
        '2150 INPUT "Premere Enter per continuare "; xx
2160:   Stop 'GOTO 1360
        '2170 Print: Print "Spessore Setto Assunto  mm "; A(27); "  Calcolato mm "; A(24)
        '2180 INPUT "Tutto OK (no=9)  "; xx
2190:   If xx = 9 Then Stop 'GOTO 1360
2200:   If AAsng Then GoTo 2320
2210:   A(28) = 0
2220:   GoTo 2430
2320:   A(28) = MecData(0).BucoRinf
2330:   AAsng = 2939
2340:   A(25) = A(28) / (1 - A(26) * A(13) * A(43) / (200 * A(26) * A(16) * (A(27)) - 2 * A(18)))
        '                         eff.                                            SpSet
        '2350 INPUT "Spessore Tubi  mm "; N
        '2360 Print
2370:   Stop 'INPUT "No File Interessate "; A(30)
2372:   If A(30) = 0 Or A(30) > A(19) Then GoTo 2370
2380:   A(44) = AAsng * A(42) * 4 / A(30) / 3.1415 / (A(41) - 2 * n) ^ 2
        '2390 Print
        '2400 Print "Passo Fori : Min "; A(25); "  Max "; A(44)
        '2410 INPUT "Tutto OK  (no=9) "; xx
2420:   If xx = 9 Then Debug.Print("GOTO 2230") : Stop
2430:   AAsng = 1
2440:   For i = 1 To A(20)
            Dom(i) = "Setto" & Str(i) & " saldato all'End"
            If MecData(0).Saldatura(i - 1) = 1 Then Risp(i) = "SI" Else Risp(i) = "NO"
        Next
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(CShort(A(20)), "Saldature terminali", Dom, Risp, "", Archiv, dAiu) Then testap = False : Exit Function
        For i = 1 To A(20)
            If UCase(Left(LTrim(Risp(i)), 1)) = "S" Then
                S(i) = 1 : MecData(0).Saldatura(i - 1) = 1
            Else
                S(i) = 0 : MecData(0).Saldatura(i - 1) = 0
            End If
2480:       AAsng = AAsng + S(i)
2490:   Next i
2530:   k = 1 : A(36) = 1
2540:   For i = 1 To AAsng
2550:       B(i) = C(k) + 2 * A(18)
2560:       For j = k To A(20)
2570:           k = k + 1
2580:           If S(j) = 1 Then GoTo 2610
2590:           B(i) = B(i) + C(k) + A(27)
2600:       Next j
2610:       If B(i) < A(36) Then GoTo 2640
2620:       A(36) = B(i)
2630:       A(35) = i
2640:   Next i
2650:   GoTo 2680
2660:   A(36) = A(9) + 2 * A(18)
        MecData(0).HE = A(36) - 2 * A(18)
2670:   A(35) = 1
2680:   l = A(36) / (A(10) + 2 * A(18))
2690:   If l >= 1 Then
2700:       l = 1 / l
2710:       A(36) = A(10) + 2 * A(18)
        End If
2800:   If l >= 0.45 Then
            '2810 A(32) = -8.489199 * L ^ 6 + 35.7175 * L ^ 5 - 60.31787 * L ^ 4 + 52.51587 * L ^ 3 - 25.39437 * L ^ 2 + 6.498529 * L + 2.446461E-02
            A(32) = 0.5879 * (l - 0.45) ^ 3 - 0.8262 * (l - 0.45) ^ 2 + 0.707 'VSR.1.L.5.1
        Else
            A(32) = 0.707
        End If
        A(33) = MecData(0).e
        A(23) = MecData(0).EWC 'Efficienza Saldatura
        AggiorSp()
Rifai:
        A(29) = A(32) / A(33) * A(36) * System.Math.Sqrt(A(13) / 100 / A(16)) + A(18)
        M(33) = EffLeg()
        Call Risolvi()
        MecData(1).SP(2 - 1) = M(16)
        If M(19) > MecData(1).SP(2 - 1) Then MecData(1).SP(2 - 1) = M(19)
        If M(23) > MecData(1).SP(2 - 1) Then MecData(1).SP(2 - 1) = M(23)
        MecData(1).SP(1 - 1) = M(24)
        If M(26) > MecData(1).SP(1 - 1) Then MecData(1).SP(1 - 1) = M(26)
        If M(28) > MecData(1).SP(1 - 1) Then MecData(1).SP(1 - 1) = M(28)
        If M(29) > MecData(1).SP(1 - 1) Then MecData(1).SP(1 - 1) = M(29)
        MecData(1).SP(3 - 1) = A(24)
        MecData(1).SP(4 - 1) = A(29)
        For i = 1 To 4
            If MecData(0).SP(i - 1) = 0 Then MecData(0).SP(i - 1) = MecData(1).SP(i - 1)
        Next
        MecData(0).NS = A(20)
        If Itera Then
            Itera = CShort(Itera) + 1 : If Not Itera Then Itera = CShort(Itera) + 1
            Errt = MecData(1).SP(2 - 1) - A(21)
            Errp = MecData(1).SP(1 - 1) - A(22)
            If (System.Math.Abs(Errt) > 0.1 Or System.Math.Abs(Errp) > 0.1) And Itera < 25 Then
                A(21) = A(21) + 0.75 * Errt
                A(22) = A(22) + 0.75 * Errp
                GoTo Rifai
            End If
        End If
        AAsng = 0
3910:   A(17) = 0
3920:   GoTo 5000
5000:   ' INIZIO STAMPA
        Apert.Enabled = False
        Call Grafic(iRis, iCassa, Nome2)
        Apert.Enabled = True
        If iRis = 1 Then GoTo 1
        If Not Decidi() Then testap = False : Exit Function
        iCambio = False
        n = 4 : If A(20) = 0 Then n = 3
        For i = 1 To n
            If System.Math.Abs(Ricor(i) - Val(Risp(i))) > 0.01 Then iCambio = True
            j = i : If i = 3 And n = 3 Then j = 4
            MecData(0).SP(j - 1) = Val(Risp(i))
        Next
        If iCambio Then
            AggiorSp()
            GoTo Rifai
        End If
        '5255 Drawing Nome2$ + ".PRR", "PSR"
        Call StamTes()
        Help = "Vuoi eseguire il |calcolo della MAWP ?"
        AAsng = MsgBox(Help, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ISA")
7430:   If AAsng = MsgBoxResult.No Then Exit Function
        Dom(1) = "Corrosione             mm      "
        Dom(2) = "Temp. esercizio        °C      "
        Dom(3) = "Press. Max (RtngFlange) kg/mm2 "
        Risp(1) = GlobalRoutines.myStr(A(18), 3, 2, False)
        Risp(2) = GlobalRoutines.myStr(A(14), 4, 2, False)
        Risp(3) = Mid(MecData(0).Rating, 6, 4)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(3, "Condizioni per MAWP", Dom, Risp, "", Archiv, dAiu) Then testap = False : Exit Function
        A(18) = Val(Risp(1))
        AAsng = Val(Risp(2))
        A(50) = Val(Risp(3))
        '     INPUT "Corrosione              mm     "; A(18)
        '     INPUT "Temp. Progetto          øC     "; A
        '     INPUT "Press. Max (RtngFlange) kg/mm2 "; A(50)
7500:   If AAsng = A(14) Then
            Sub9000() 'GOTO 7530
        Else
7510:       A(14) = AAsng
7520:       Sub8000()
        End If
        Call StamTes()
        Exit Function
    End Function
    Private Sub Sub8000()
8000:   ' mawp  cambio temperatura
8010:   T = A(14)
        MatLam = MatTesLam(St, CSng(T), 1, 0, ik, "")
        A(15) = St
        A(16) = A(15)
8210:   If A(4) = 0 Or T <> 25 Then Sub9000()
8220:   For i = 1 To AAsng
8230:       If Z(i) > 16 Then GoTo 8250
8240:       A(14 + i) = A(14 + i) * 15 / 11
8250:   Next i
        Sub9000()
    End Sub
    Private Sub Sub9000()
9000:   ' mawp
9010:   CSin = A(18)
9020:   SSin = A(20)
9030:   If SSin = 0 Then GoTo 9350
9040:   A(40) = 0 : A(43) = 0 : AAsng = 0
9050:   For i = 1 To SSin
9060:       m1 = C(i) + C(i + 1) + 4 * CSin
9070:       If R(i) Then GoTo 9140
9080:       AAsng = 1
9090:       BBsng = f(i)
9100:       If BBsng > f(i + 1) Then GoTo 9120
9110:       BBsng = f(i + 1)
9120:       If m1 < A(43) Then GoTo 9140
9130:       A(43) = m1
9140:       If m1 < A(40) Then GoTo 9170
9150:       A(40) = m1
9160:       A(34) = i
9170:   Next i
9180:   AAsng = 1
9190:   For i = 1 To SSin
9200:       AAsng = AAsng + S(i)
9210:   Next i
9220:   k = 1 : A(36) = 1
9230:   For i = 1 To AAsng
9240:       B(i) = C(k) + 2 * CSin
9250:       For j = k To SSin
9260:           k = k + 1
9270:           If S(j) = 1 Then GoTo 9300
9280:           B(i) = B(i) + C(k) + A(27)
9290:       Next j
9300:       If B(i) < A(36) Then GoTo 9330
9310:       A(36) = B(i)
9320:       A(35) = i
9330:   Next i
9340:   GoTo 9370
9350:   A(36) = A(9) + 2 * CSin
9360:   A(35) = 1
9370:   l = A(36) / (A(10) + 2 * CSin)
9380:   If l < 1 Then GoTo 9410
9390:   l = 1 / l
9400:   A(36) = A(10) + 2 * CSin
9410:   If A(4) Then GoTo 9480
9420:   A(32) = 0.57446
9430:   ZSin = 3.4 - 2.4 * l
9440:   If ZSin < 2.5 Then GoTo 9460
9450:   ZSin = 2.5
9460:   A(33) = System.Math.Sqrt(ZSin)
9470:   GoTo 9540
9480:   A(33) = 1
9490:   If l < 0.45 Then GoTo 9530
9500:   A(32) = -8.489199 * l ^ 6 + 35.7175 * l ^ 5 - 60.31787 * l ^ 4 + 52.51587 * l ^ 3 - 25.39437 * l ^ 2
9510:   A(32) = A(32) + 6.498529 * l + 0.02446461
9520:   GoTo 9540
9530:   A(32) = 0.707
9540:   M(34) = (A(21) - CSin) ^ 3 / 12
9550:   M(35) = (A(22) - CSin) ^ 3 / 12
9560:   k = A(10) / 2 + CSin
9570:   D(1, 1) = k / M(35) + (C(1) + 2 * CSin) / M(34) / 3 : D(1, 4) = D(1, 1)
9580:   D(SSin + 2, 1) = (C(SSin + 1) + 2 * CSin) / M(34) / 3 + k / M(35)
9590:   D(1, 2) = (C(1) / 2 + CSin) / 3 / M(34)
9600:   For i = 2 To SSin + 1
9610:       D(i, 1) = (C(i - 1) + C(i) + 4 * CSin) / M(34) / 3
9620:       D(i, 2) = (C(i) / 2 + CSin) / 3 / M(34)
9630:   Next i
9640:   p1 = 0
9650:   P = A(13)
9660:   P0 = 10
9670:   Sub9688()
9672:   P = P - 9
9674:   P0 = 1
9676:   Sub9688()
9678:   P = P - 0.9
9680:   P0 = 0.1
9682:   Sub9688()
9684:   P = P - 0.1
9686:   p1 = 1
        Sub9688()
    End Sub
    Private Sub Sub9688()
9688:   For P = P To A(50) Step P0
9690:       D(1, 3) = P * (k ^ 3 / M(35) + (C(1) / 2 + CSin) ^ 3 / M(34)) / 300 : D(1, 5) = D(1, 3)
9692:       D(SSin + 2, 3) = P * ((C(SSin + 1) / 2 + CSin) ^ 3 / M(34) + k ^ 3 / M(35)) / 300
9694:       For i = 2 To SSin + 1
9696:           D(i, 3) = P * ((C(i - 1) / 2 + CSin) ^ 3 + (C(i) / 2 + CSin) ^ 3) / 300 / M(34)
9698:       Next i
9700:       For i = 2 To SSin + 2
9702:           D(i, 4) = D(i, 1) - D(i - 1, 2) ^ 2 / D(i - 1, 4)
9704:           D(i, 5) = D(i, 3) - D(i - 1, 5) * D(i - 1, 2) / D(i - 1, 4)
9706:       Next i
9708:       M(SSin + 3) = 0
9710:       For i = SSin + 2 To 1 Step -1
9712:           M(i) = (D(i, 5) - D(i, 2) * M(i + 1)) / D(i, 4)
9714:       Next i
9716:       M(39) = P * (A(10) / 2 + CSin) / 100 / A(15)
9718:       M(15) = M(1)
9720:       If System.Math.Abs(M(15)) > System.Math.Abs(M(SSin + 2)) Then GoTo 9724
9722:       M(15) = M(SSin + 2)
9724:       M(16) = M(36) * (M(39) / A(23) + System.Math.Sqrt(6 * System.Math.Abs(M(15)) / A(15) / A(23) / M(38))) + CSin
9728:       If M(16) < A(21) Then GoTo 9732
9730:       GoTo 9900
9732:       M(17) = 0
9734:       For i = 1 To SSin + 1
9736:           Q = C(i) / 2 + CSin
9738:           D(i, 6) = (M(i + 1) - M(i)) * 50 / P / Q
9740:           If System.Math.Abs(D(i, 6)) < Q Then GoTo 9744
9742:           D(i, 6) = Q * D(i, 6) / System.Math.Abs(D(i, 6))
9744:           AAsng = (M(i) + M(i + 1) - (M(i + 1) - M(i)) * D(i, 6) / Q + P * (D(i, 6) ^ 2 - Q ^ 2) / 100) / 2
9746:           If System.Math.Abs(AAsng) < System.Math.Abs(M(17)) Then GoTo 9754
9748:           M(17) = AAsng
9750:           M(18) = i
9752:           M(22) = D(i, 6)
9754:       Next i
9756:       M(19) = M(39) + System.Math.Sqrt(6 * System.Math.Abs(M(17)) / M(37) / A(15)) + CSin
9758:       If M(19) < A(21) Then GoTo 9762
9760:       GoTo 9900
9762:       M(20) = 0 : xSinSng = 0
9764:       For i = 1 To SSin + 1
9766:           For j = 1 To f(i)
9768:               Q = C(i) / 2 + CSin
9770:               xSinSng = xSinSng + 1
9772:               AAsng = (M(i) + M(i + 1) - (M(i + 1) - M(i)) * X(xSinSng) / Q + P * (X(xSinSng) ^ 2 - Q ^ 2) / 100) / 2
9774:               If System.Math.Abs(AAsng) < System.Math.Abs(M(20)) Then GoTo 9780
9776:               M(20) = AAsng
9778:               M(21) = xSinSng
9780:           Next j
9782:       Next i
9784:       M(23) = M(39) / M(33) + System.Math.Sqrt(6 * System.Math.Abs(M(20)) / M(37) / A(15) / M(33)) + CSin
9786:       If M(23) < A(21) Then GoTo 9790
9788:       GoTo 9900
9790:       M(40) = P * (C(1) / 2 + CSin) / 100 / A(15)
9792:       M(24) = M(36) * (M(40) / A(23) + System.Math.Sqrt(6 * System.Math.Abs(M(1)) / A(15) / M(38) / A(23))) + CSin
9794:       If M(24) < A(22) Then GoTo 9798
9796:       GoTo 9900
9798:       M(25) = M(1) - P * (A(10) / 2 + CSin) ^ 2 / 200
9800:       M(26) = M(40) + System.Math.Sqrt(6 * System.Math.Abs(M(25)) / A(15) / M(37)) + CSin
9802:       If M(26) < A(22) Then GoTo 9806
9804:       GoTo 9900
9806:       M(30) = P * (C(SSin + 1) / 2 + CSin) / 100 / A(15)
9808:       M(27) = M(SSin + 2) - P * (A(10) / 2 + CSin) ^ 2 / 200
9810:       M(28) = M(36) * (M(30) / A(23) + System.Math.Sqrt(6 * System.Math.Abs(M(SSin + 2)) / A(15) / A(23) / M(38))) + CSin
9812:       If M(28) < A(22) Then GoTo 9816
9814:       GoTo 9900
9816:       M(29) = M(30) + System.Math.Sqrt(6 * System.Math.Abs(M(27)) / A(15) / M(37)) + CSin
9818:       If M(29) < A(22) Then GoTo 9822
9820:       GoTo 9900
9822:       If SSin = 0 Then GoTo 9832
9824:       A(24) = P * A(40) / 200 / A(16) / A(26) + 2 * CSin
9826:       If A(24) < A(27) Then GoTo 9830
9828:       GoTo 9900
9830:       A(25) = A(28) / (1 - A(26) * P * A(43) / 200 / A(26) / A(16) / (A(27) - 2 * CSin))
9832:       A(29) = A(32) * A(33) * A(36) * System.Math.Sqrt(P / 100 / A(16)) + CSin
9834:       If A(29) < A(30) Then GoTo 9838
9836:       GoTo 9900
9838:       If A(17) = 0 Then GoTo 9858
9840:       If A(46) Then GoTo 9846
9842:       M(32) = P * M(31) / (200 * A(17) * A(47) + M(41) * P) + CSin
9844:       GoTo 9848
9846:       M(32) = M(41) * (D(13, 2) * D(13, 6) * M(31) * System.Math.Sqrt(P / 100 / A(17)) + CSin)
9848:       If M(32) < A(48) Then GoTo 9852
9850:       GoTo 9900
9852:       If M(44) = 0 Then GoTo 9858
9854:       M(45) = P * M(31) / 100 / A(16) / 0.65 + 2 * CSin
9856:       If M(45) > A(49) Then GoTo 9900
9858:       If p1 Then
9910:           A(13) = P
9915:           MAWP = 1
9920:           Exit Sub
            End If
9860:   Next P
9900:
    End Sub
    Private Sub AggiorSp()
        A(21) = MecData(0).SP(2 - 1)
        A(22) = MecData(0).SP(1 - 1)
        A(27) = MecData(0).SP(3 - 1) 'sp. setti?
        A(30) = MecData(0).SP(4 - 1)
        If A(27) = 0 Then A(27) = 12
        A(51) = A(21) : A(52) = A(22)
        If A(21) = 0 Or A(22) = 0 Then
            A(21) = 25 : A(22) = 25 : Itera = True
        Else
            Itera = False
        End If
    End Sub
    Private Function ThkASME(ByRef n As Single, ByRef M As Single) As Single
        Dim det, S As Single
        det = System.Math.Sqrt(n * n + 4 * 1.5 * 6 * A(15) * M)
        S = (n + det) / 2 / 1.5 / A(15)
        If n / A(15) > S Then S = n / A(15)
        ThkASME = S
    End Function
End Module