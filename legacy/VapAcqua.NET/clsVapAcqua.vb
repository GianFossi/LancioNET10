Option Strict Off
Option Explicit On
Public Class clsVapAcqua
    Private AI1 As Single
    Private BETA As Single
    Private A0() As Single
    Private WA() As Single
    Private WB(,) As Single
    Public Stub As StubW2000.clsSW2000
    Public Stub9 As StubW9.clsSW9
    Public Pressione As Single
    Public FileStam As String
    Public Tmax, Tmin, Tincr As Single
    Private Tsat As Single
    Private Overloads Sub Testata(ByRef Doc As StubW2000.clsSW2000) 'Word.Document)
        Doc.VaiInizio("Programma")
        Doc.Testo(Monitor.Motore.About.ProgName & " " & Monitor.Motore.About.ProgVers)
        Doc.VaiInizio("Job")
        Doc.Testo(Monitor.Motore.Inizio.CommPulita(FileStam))
        Doc.VaiInizio("Pressione")
        Doc.Testo(Funzioni.myStr(Pressione, 3, 2, False))
        TSATP(Pressione, Tsat)
        Doc.VaiInizio("Tsat")
        Doc.Testo(Funzioni.myStr(Tsat, 3, 2, False))
    End Sub
    Private Overloads Sub Testata(ByRef Doc As StubW9.clsSW9) 'Word.Document)
        Doc.VaiInizio("Programma")
        Doc.Testo(Monitor.Motore.About.ProgName & " " & Monitor.Motore.About.ProgVers)
        Doc.VaiInizio("Job")
        Doc.Testo(Monitor.Motore.Inizio.CommPulita(FileStam))
        Doc.VaiInizio("Pressione")
        Doc.Testo(Funzioni.myStr(Pressione, 3, 2, False))
        TSATP(Pressione, Tsat)
        Doc.VaiInizio("Tsat")
        Doc.Testo(Funzioni.myStr(Tsat, 3, 2, False))
    End Sub
    Public Sub Calcola(ByRef T0 As Single, ByRef T1 As Single, ByRef dt As Single, ByRef p As Single, ByRef f As String, ByRef iErr As Short)
        Dim LogoFile As String
        Pressione = p
        Tmin = T0
        Tmax = T1
        Tincr = dt
        Pressione = p
        FileStam = f
        If Pressione <= 0 Then Warn(iErr) : Exit Sub
        If Tmin < 0 Then Warn(iErr) : Exit Sub
        If Tmax <= Tmin Then Warn(iErr) : Exit Sub
        If Tincr <= 0 Then Warn(iErr) : Exit Sub
        If Len(FileStam) = 0 Then Warn2(iErr) : Exit Sub
        LogoFile = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Stub9 = New StubW9.clsSW9
            Stub9.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPVAP.DOC", Monitor.Motore.Inizio.VersOffice)
            Stub9.sSaveAs(FileStam)
            Stub.IntestLogo(LogoFile)
            Testata(Stub9) 'Doc
        Else
            Stub = New StubW2000.clsSW2000
            Stub.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPVAP.DOC", Monitor.Motore.Inizio.VersOffice)
            Stub.sSaveAs(FileStam)
            Stub.IntestLogo(LogoFile)
            Testata(Stub) 'Doc
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        StampaCorpo()
        FinePagina()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Warn(ByRef iErr As Integer)
        iErr = 1
        MsgBox("L'intervallo di temperature per la redazione del rapporto non è definito correttamente", MsgBoxStyle.Critical)
    End Sub
    Private Sub Warn1(ByRef iErr As Integer)
        iErr = 1
        MsgBox("La pressione per la redazione del rapporto non è definita", MsgBoxStyle.Critical)
    End Sub
    Private Sub Warn2(ByRef iErr As Integer)
        iErr = 1
        MsgBox("Non è stato definito il nome del rapporto di stampa", MsgBoxStyle.Critical)
    End Sub
    Private Sub SubADRY(ByRef t As Single, ByRef P0 As Single, ByRef ADRY As Single, ByRef N As Short)
        Dim B01, B0, B02 As Single
        Dim B04, B03, B05 As Single
        Dim B11, B12 As Single
        Dim B22, B21, B23 As Single
        Dim B31, B32 As Single
        Dim B41, B42 As Single
        Dim B52, B51, B53 As Single
        Dim B61, B62 As Single
        Dim B71, B72 As Single
        Dim B81, B82 As Single
        Dim B91, B90, B92 As Single
        Dim B95, B93, B94, B96 As Single
        Dim BP81, BP61, Bp, BP71, BP82 As Single
        Dim TC1, VC1 As Double
        Dim PC1, R1 As Single
        Dim AL1, AL0, AL2 As Single
        Dim P1, AT, XAcq As Single
        Dim TETA As Double
        Dim BETAL, BETAPL As Single
        Dim D2, D1, D3 As Single
        Dim CO1, CO2 As Single
        Dim CO4, CO3, CO5 As Single
        Dim CO7, CO6, CO8 As Single
        Dim CO10, CO9, CO11 As Single
        Dim CO13, CO12, CO14 As Single
        Dim CO16, CO15, DEZBET As Single
        Dim DEZTET, SIG As Single
        Dim T01 As Double
        Dim T3, T2, T4 As Single
        Dim T6, T5, T7 As Single
        Dim T9, T8, T10 As Single
        Dim T12, T11, T13 As Single
        Dim ZETA2, EPS As Single
        Dim AD1, AD2 As Single
        Dim AD4, AD3, AD5 As Single
        Dim AD7, AD6, AD8 As Single
        Dim AD10, AD9, AD11 As Single
        Dim AD13, AD12, AD14 As Single
        Dim CHI As Single
890:    ' **************** SUBROUTINE ADRY
900:    B0 = 16.83599274 : B01 = 28.56067796 : B02 = -54.38923329
910:    B03 = 0.4330662834 : B04 = -0.6547711697 : B05 = 0.08565182058
920:    B11 = 0.06670375918 : B12 = 1.388983801
930:    B21 = 0.08390104328 : B22 = 0.02614670893 : B23 = -0.03373439453
940:    B31 = 0.4520918904 : B32 = 0.1069036614
950:    B41 = -0.5975336707 : B42 = -0.08847535804
960:    B51 = 0.5958051609 : B52 = -0.5159303373 : B53 = 0.2075021122
970:    B61 = 0.1190610271 : B62 = -0.09867174132
980:    B71 = 0.1683998803 : B72 = -0.05809438001
990:    B81 = 0.006552390126 : B82 = 0.0005710218649
1000:   B90 = 193.6587558 : B91 = -1388.522425 : B92 = 4126.607219 : B93 = -6508.211677
1010:   B94 = 5745.984054 : B95 = -2693.088365 : B96 = 523.5718623
1020:   Bp = 0.7633333333 : BP61 = 0.4006073948 : BP71 = 0.08636081627
1030:   BP81 = -0.8532322921 : BP82 = 0.3460208861
1040:   TC1 = 647.3 : PC1 = 22120000.0# : VC1 = 0.00317 : R1 = 461.51
1050:   AI1 = 4.260321148 : AL0 = 15.74373327
1060:   AL1 = -34.17061978 : AL2 = 19.31380707
1070:   AT = t + 273.15 : P1 = P0 * 100000.0# : TETA = AT / TC1 : BETA = P1 / PC1
        If P1 = 0 Then
            MsgBox("Non è stata definita la pressione del vapor d'acqua")
            Exit Sub
        End If
1080:   XAcq = System.Math.Exp(Bp * (1 - TETA))
1090:   BETAL = AL0 + AL1 * TETA + AL2 * TETA ^ 2
1100:   BETAPL = AL1 + 2 * AL2 * TETA
1110:   D1 = (1 + BP61 * XAcq ^ 14 * BETA ^ 4)
1120:   D2 = 1 + (BP71 * XAcq ^ 19 * BETA ^ 5)
1130:   D3 = 1 + (BP81 * XAcq ^ 54 + BP82 * XAcq ^ 27) * BETA ^ 6
1140:   If N = 1 Then GoTo 1530
1150:   CO1 = AI1 * System.Math.Log(BETA) - B0 * System.Math.Log(TETA) + B02 + 2 * B03 * TETA + 3 * B04 * TETA ^ 2 + 4 * B05 * TETA ^ 3
1160:   CO2 = BETA * (B11 * 13 * Bp * XAcq ^ 13 + B12 * 3 * Bp * XAcq ^ 3)
1170:   CO3 = BETA ^ 2 * (B21 * 18 * Bp * XAcq ^ 18 + B22 * 2 * Bp * XAcq ^ 2 + B23 * Bp * XAcq)
1180:   CO4 = BETA ^ 3 * (B31 * 18 * Bp * XAcq ^ 18 + B32 * 10 * Bp * XAcq ^ 10)
1190:   CO5 = BETA ^ 4 * (B41 * 25 * Bp * XAcq ^ 25 + B42 * 14 * Bp * XAcq ^ 14)
1200:   CO6 = BETA ^ 5 * (B51 * 32 * Bp * XAcq ^ 32 + B52 * 28 * Bp * XAcq ^ 28 + B53 * 24 * Bp * XAcq ^ 24)
1210:   CO7 = BETA ^ 4 * (B61 * 12 * Bp * XAcq ^ 12 + B62 * 11 * Bp * XAcq ^ 11)
1220:   CO8 = BETA ^ 4 * (BP61 * 14 * Bp * XAcq ^ 14 * BETA ^ 4) * (B61 * XAcq ^ 12 + B62 * XAcq ^ 11)
1230:   CO9 = BETA ^ 5 * (B71 * 24 * Bp * XAcq ^ 24 + B72 * 18 * Bp * XAcq ^ 18)
1240:   CO10 = BETA ^ 5 * (BP71 * 19 * Bp * XAcq ^ 19 * BETA ^ 5) * (B71 * XAcq ^ 24 + B72 * XAcq ^ 18)
1250:   CO11 = BETA ^ 6 * (B81 * 24 * Bp * XAcq ^ 24 + B82 * 14 * Bp * XAcq ^ 14)
1260:   CO12 = BETA ^ 12 * (BP81 * 54 * Bp * XAcq ^ 54 + BP82 * 27 * Bp * XAcq ^ 27) * (B81 * XAcq ^ 24 + B82 * XAcq ^ 14)
1270:   CO13 = -BETA ^ 11 * 10 * BETAL ^ 9 * BETAPL / (BETAL ^ 20)
1280:   CO14 = (B90 + B91 * XAcq + B92 * XAcq ^ 2 + B93 * XAcq ^ 3 + B94 * XAcq ^ 4 + B95 * XAcq ^ 5 + B96 * XAcq ^ 6)
1290:   CO15 = BETA ^ 11 / (BETAL ^ 10)
1300:   CO16 = -(B91 * Bp * XAcq + B92 * 2 * Bp * XAcq ^ 2 + B93 * 3 * Bp * XAcq ^ 3 + B94 * 4 * Bp * XAcq ^ 4 + B95 * 5 * Bp * XAcq ^ 5 + B96 * 6 * Bp * XAcq ^ 6)
1310:   DEZTET = CO1 + CO2 + CO3 + CO4 + CO5 + CO6 + ((CO7 * D1 - CO8) / (D1 ^ 2))
1320:   DEZTET = DEZTET + ((CO9 * D2 - CO10) / (D2 ^ 2))
1330:   DEZTET = DEZTET + ((CO11 * D3 - CO12) / (D3 ^ 2))
1340:   DEZTET = DEZTET + CO13 * CO14 + CO15 * CO16
1350:   SIG = -DEZTET
1360:   T01 = AI1 * TETA * System.Math.Log(BETA)
1370:   T2 = B0 * TETA * (1 - System.Math.Log(TETA))
1380:   T3 = B01 + B02 * TETA + B03 * TETA ^ 2 + B04 * TETA ^ 3 + B05 * TETA ^ 4
1390:   T4 = BETA * (B11 * XAcq ^ 13 + B12 * XAcq ^ 3)
1400:   T5 = BETA ^ 2 * (B21 * XAcq ^ 18 + B22 * XAcq ^ 2 + B23 * XAcq)
1410:   T6 = BETA ^ 3 * (B31 * XAcq ^ 18 + B32 * XAcq ^ 10)
1420:   T7 = BETA ^ 4 * (B41 * XAcq ^ 25 + B42 * XAcq ^ 14)
1430:   T8 = BETA ^ 5 * (B51 * XAcq ^ 32 + B52 * XAcq ^ 28 + B53 * XAcq ^ 24)
1440:   T9 = BETA ^ 4 * (B61 * XAcq ^ 12 + B62 * XAcq ^ 11) / (1 + BP61 * XAcq ^ 14 * BETA ^ 4)
1450:   T10 = BETA ^ 5 * (B71 * XAcq ^ 24 + B72 * XAcq ^ 18) / (1 + BP71 * XAcq ^ 19 * BETA ^ 5)
1460:   T11 = BETA ^ 6 * (B81 * XAcq ^ 24 + B82 * XAcq ^ 14) / (1 + BP81 * XAcq ^ 54 * BETA ^ 6 + BP82 * XAcq ^ 27 * BETA ^ 6)
1470:   T12 = BETA ^ 11 / (BETAL ^ 10)
1480:   T13 = B90 + B91 * XAcq + B92 * XAcq ^ 2 + B93 * XAcq ^ 3 + B94 * XAcq ^ 4 + B95 * XAcq ^ 5 + B96 * XAcq ^ 6
1490:   ZETA2 = T01 + T2 + T3 - T4 - T5 - T6 - T7 - T8 - T9 - T10 - T11 + T12 * T13
1500:   EPS = ZETA2 + SIG * TETA
1510:   ADRY = EPS * PC1 * VC1 / 1000.0#
1520:   Exit Sub
1530:   '
1540:   AD1 = AI1 * TETA / BETA
1550:   AD2 = B11 * XAcq ^ 13 + B12 * XAcq ^ 3
1560:   AD3 = BETA * 2 * (B21 * XAcq ^ 18 + B22 * XAcq ^ 2 + B23 * XAcq)
1570:   AD4 = BETA ^ 2 * 3 * (B31 * XAcq ^ 18 + B32 * XAcq ^ 10)
1580:   AD5 = BETA ^ 3 * 4 * (B41 * XAcq ^ 25 + B42 * XAcq ^ 14)
1590:   AD6 = BETA ^ 4 * 5 * (B51 * XAcq ^ 32 + B52 * XAcq ^ 28 + B53 * XAcq ^ 24)
1600:   AD7 = BETA ^ 3 * 4 * (B61 * XAcq ^ 12 + B62 * XAcq ^ 11)
1610:   AD8 = BETA ^ 4 * (4 * BP61 * XAcq ^ 14 * BETA ^ 3) * (B61 * XAcq ^ 12 + B62 * XAcq ^ 11)
1620:   AD9 = BETA ^ 4 * 5 * (B71 * XAcq ^ 24 + B72 * XAcq ^ 18)
1630:   AD10 = BETA ^ 5 * (5 * BETA ^ 4 * BP71 * XAcq ^ 19) * (B71 * XAcq ^ 24 + B72 * XAcq ^ 18)
1640:   AD11 = BETA ^ 5 * 6 * (B81 * XAcq ^ 24 + B82 * XAcq ^ 14)
1650:   AD12 = BETA ^ 6 * (BETA ^ 5 * 6 * (BP81 * XAcq ^ 54 + BP82 * XAcq ^ 27)) * (B81 * XAcq ^ 24 + B82 * XAcq ^ 14)
1660:   AD13 = BETA ^ 10 * 11 / (BETAL ^ 10)
1670:   AD14 = B90 + B91 * XAcq + B92 * XAcq ^ 2 + B93 * XAcq ^ 3 + B94 * XAcq ^ 4 + B95 * XAcq ^ 5 + B96 * XAcq ^ 6
1680:   DEZBET = AD1 - AD2 - AD3 - AD4 - AD5 - AD6
1690:   DEZBET = DEZBET - ((AD7 * D1 - AD8) / (D1 ^ 2))
1700:   DEZBET = DEZBET - ((AD9 * D2 - AD10) / (D2 ^ 2))
1710:   DEZBET = DEZBET - ((AD11 * D3 - AD12) / (D3 ^ 2))
1720:   CHI = DEZBET + AD13 * AD14
1730:   ADRY = CHI * VC1
        '1740 Return

    End Sub
    Public Sub SubHPTL(ByRef t As Single, ByRef p As Single, ByRef HPTL As Single)
        Dim ALIQ As Single
        ' ***************** SUBROUTINE HPTL
        Call SubALIQ(t, p, ALIQ, 2)
        HPTL = ALIQ
    End Sub
    Private Sub SubALIQ(ByRef t As Single, ByRef P0 As Single, ByRef ALIQ As Single, ByRef m As Short)
        Dim A1, A00, A2 As Single
        Dim A4, A3, A5 As Single
        Dim A7, A6, A8 As Single
        Dim A10, A9, A11 As Single
        Dim A13, A12, A14 As Single
        Dim A16, A15, A17 As Single
        Dim A19, A18, A20 As Single
        Dim A22, A21, AP1 As Single
        Dim AP3, AP2, AP4 As Single
        Dim AP6, AP5, AP7 As Single
        Dim AP9, AP8, AP10 As Single
        Dim AP11, AP12 As Single
        Dim TC1 As Double
        Dim PC1, AT As Single
        Dim VC1 As Double
        Dim BE, AP, TE, Yacq As Single
        Dim Z, W, DYT As Single
        Dim CF2, CF1, CF3 As Single
        Dim CF5, CF4, CF6 As Single
        Dim CF9, CF7, CF8, CF10 As Single
        Dim CF13, CF11, CF12, CF14 As Single
        Dim CF22, CF20, CF21, CF23 As Single
        Dim CF25, CF24, SIG As Single
        Dim CHI, ZT1, EPS As Single
1860:   ' ***************** SUBROUTINE ALIQ
1870:   A00 = 6824.687741 : A1 = -542.2063673 : A2 = -20966.66205
1880:   A3 = 39412.86787 : A4 = -67332.77739 : A5 = 99023.81028
1890:   A6 = -109391.1774 : A7 = 85908.41667 : A8 = -45111.68742
1900:   A9 = 14181.38926 : A10 = -2017.271113 : A11 = 7.982692717
1910:   A12 = -0.02616571843 : A13 = 0.00152241179 : A14 = 0.02284279054
1920:   A15 = 242.1647003 : A16 = 0.0000000001269716088 : A17 = 0.0000002074838328
1930:   A18 = 0.0000000217402035 : A19 = 0.000000001105710498 : A20 = 12.93441934
1940:   A21 = 0.00001308119072 : A22 = 0.00000000000006047626338 : AP1 = 0.8438375405
1950:   AP2 = 0.0005362162162 : AP3 = 1.72 : AP4 = 0.07342278489
1960:   AP5 = 0.0497585887 : AP6 = 0.65371543 : AP7 = 0.00000115
1970:   AP8 = 0.000015108 : AP9 = 0.14188 : AP10 = 7.002753165
1980:   AP11 = 0.0002995284926 : AP12 = 0.204
1990:   TC1 = 647.3 : PC1 = 22120000.0# : VC1 = 0.00317 : AT = t + 273.15 : AP = P0 * 100000.0#
2000:   TE = AT / TC1 : BE = AP / PC1 : Yacq = 1 - AP1 * TE ^ 2 - AP2 * TE ^ (-6)
2010:   W = System.Math.Abs(AP3 * Yacq ^ 2 - 2 * AP4 * TE + 2 * AP5 * BE)
2020:   Z = Yacq + System.Math.Sqrt(W) : DYT = -2 * AP1 * TE + 6 * AP2 * TE ^ (-7)
2030:   If m = 1 Then GoTo 2070
2040:   CF1 = A00 * TE * (1 - System.Math.Log(TE))
2050:   CF2 = A1 + A2 * TE + A3 * TE ^ 2 + A4 * TE ^ 3 + A5 * TE ^ 4 + A6 * TE ^ 5 + A7 * TE ^ 6 + A8 * TE ^ 7 + A9 * TE ^ 8 + A10 * TE ^ 9
2060:   CF3 = A11 * (17 * Z / 29 - 17 * Yacq / 12) * Z ^ (12 / 17)
2070:   CF4 = A12 + A13 * TE + A14 * TE ^ 2 + A15 * (AP6 - TE) ^ 10 + A16 / (AP7 + TE ^ 19)
2080:   CF5 = 1 / (AP8 + TE ^ 11)
2090:   CF7 = A20 * TE ^ 18 * (AP9 + TE ^ 2)
2100:   If m = 1 Then GoTo 2170
2110:   CF8 = (AP10 + BE) ^ (-3) + AP11 * BE
2120:   CF6 = A17 * BE + A18 * BE ^ 2 + A19 * BE ^ 3
2130:   CF9 = A21 * (AP12 - TE) * BE ^ 3
2140:   CF10 = A22 * TE ^ (-20) * BE ^ 4
2150:   ZT1 = CF1 + CF2 + CF3 + BE * CF4 - CF5 * CF6 - CF7 * CF8 + CF9 + CF10
2160:   GoTo 2250
2170:   CF11 = A11 * AP5 * Z ^ (-5 / 17)
2180:   CF12 = A17 + BE * (2 * A18 + 3 * BE * A19)
2190:   CF13 = AP11 - 3 * (AP10 + BE) ^ (-4)
2200:   CF14 = BE ^ 2 * (3 * A21 * (AP12 - TE) + 4 * A22 * BE * TE ^ (-20))
2210:   CHI = CF11 + CF4 - CF5 * CF12 - CF7 * CF13 + CF14
2220:   ALIQ = CHI * VC1
2230:   Exit Sub
2240:   '
2250:   CF20 = A2 + 2 * A3 * TE + 3 * A4 * TE ^ 2 + 4 * A5 * TE ^ 3 + 5 * A6 * TE ^ 4 + 6 * A7 * TE ^ 5 + 7 * A8 * TE ^ 6 + 8 * A9 * TE ^ 7 + 9 * A10 * TE ^ 8
2260:   CF21 = A11 * Z ^ (-5 / 17) * ((5 * Z / 12 - (AP3 - 1) * Yacq) * DYT + AP4)
2270:   CF22 = A13 + 2 * A14 * TE - 10 * A15 * (AP6 - TE) ^ 9 - 19 * A16 * TE ^ 18 * (AP7 + TE ^ 19) ^ (-2)
2280:   CF23 = 11 * CF5 ^ 2 * TE ^ 10 * (A17 * BE + A18 * BE ^ 2 + A19 * BE ^ 3)
2290:   CF24 = 2 * A20 * TE ^ 17 * (9 * AP9 + 10 * TE ^ 2)
2300:   CF25 = (A21 + 20 * A22 * BE * TE ^ (-21)) * BE ^ 3
2310:   SIG = A00 * System.Math.Log(TE) - CF20 + CF21 - BE * CF22 - CF23 + CF8 * CF24 + CF25
2320:   EPS = ZT1 + SIG * TE
2330:   ALIQ = EPS * PC1 * VC1 / 1000.0#
2340:   'Return
    End Sub
    Public Sub SubVPTS(ByRef t As Single, ByRef p As Single, ByRef VPTS As Single)
        Dim ADRY As Single
        ' ***************** SUBROUTINE VPTS
        Call SubADRY(t, p, ADRY, 1) 'GoSub 890    'CALL SUBROUTINE ADRY
        VPTS = ADRY
    End Sub
    Public Sub SubVPTL(ByRef t As Single, ByRef p As Single, ByRef VPTL As Single)
        Dim ALIQ As Single
        ' ***************** SUBROUTINE VPTL
        Call SubALIQ(t, p, ALIQ, 1) ' GoSub 1860   'CALL SUBROUTINE ALIQ
        VPTL = ALIQ
    End Sub
    Public Sub TSATP(ByRef PH2O As Single, ByRef TH2O As Single)
        Dim p, AK, DEP As Single
        Dim i, j As Short
        Dim D00 As Single
        Dim ij As Short
        Dim t As Single
480:    ' **************** SUBROUTINE TSATP
550:    AK = 142.23 : i = 9 : p = PH2O
560:    If p <= 31.5 Then GoTo 580
570:    AK = 14.223 : i = 18
580:    DEP = System.Math.Log(AK * p) : D00 = A0(i)
590:    For j = 1 To 8
600:        ij = i - j
610:        D00 = D00 * DEP + A0(ij)
620:    Next j
630:    D00 = D00 - 32 : t = D00 / 1.8 : TH2O = t
    End Sub
    Public Sub SubPSATT(ByRef Psat As Single, ByRef t As Single)
        Dim C2, C1acq, C3 As Single
        Dim C6, C4, C5, C7 As Single
        Dim C8, C9 As Single
        Dim TC1, TETA As Double
        Dim PC1, AT As Single
        Dim TT As Double
        Dim DE2, DE1, AN1 As Single
        Dim DE3 As Single
        Dim BETAK, Ps As Single
730:    ' **************** SUBROUTINE PSATT
740:    C1acq = -7.691234564 : C2 = -26.08023696 : C3 = -168.1706546 : C4 = 64.23285504
750:    C5 = -118.9646225 : C6 = 4.16711732 : C7 = 20.975067 : C8 = 1000000000.0# : C9 = 6.0#
760:    TC1 = 647.3 : PC1 = 22120000.0# : AT = t + 273.15 : TETA = AT / TC1 : TT = 1 - TETA
770:    DE1 = TETA * (1 + C6 * TT + C7 * TT ^ 2)
780:    DE2 = C8 * TT ^ 2 + C9
        DE3 = C4 + TT * C5
790:    AN1 = TT * (C1acq + TT * (C2 + TT * (C3 + TT * DE3)))
800:    BETAK = System.Math.Exp(AN1 / DE1 - TT / DE2)
810:    Ps = BETAK * PC1 : Psat = Ps / 100000.0#
    End Sub
    Public Sub SubHPTS(ByRef t As Single, ByRef P0 As Single, ByRef HPTS As Single)
        Dim ADRY As Single
        ' **************** SUBROUTINE HPTS entalpia vapore(T,P)
        Call SubADRY(t, P0, ADRY, 2) 'gosub 890 CALL SUBROUTINE ADRY
        HPTS = ADRY
    End Sub
    Public Sub SubHTV(ByRef t As Single, ByRef HTV As Single)
        'entalpia del vapore saturo
        Dim P0, HPTS As Single
        ' **************** SUBROUTINE HTV
        Call SubPSATT(P0, t) 'GoSub 730     'CALL SUBROUTINE PSATT
        Call SubHPTS(t, P0, HPTS) 'GoSub 840     'CALL SUBROUTINE HPTS
        HTV = HPTS
    End Sub
    Public Sub SubHTL(ByRef t As Single, ByRef HTL As Single)
        'entalpia liquido saturo
        Dim HPTL, P0 As Single
        ' ***************** SUBROUTINE HTL
        Call SubPSATT(P0, t) 'GoSub 730     'CALL SUBROUTINE PSATT
        Call SubHPTL(t, P0, HPTL) '1810     'CALL SUBROUTINE HPTL
        HTL = HPTL
    End Sub
    Public Sub SubVTV(ByRef t As Single, ByRef VTV As Single)
        Dim VPTS, p As Single
        ' ***************** SUBROUTINE VTV
        Call SubPSATT(p, t) 'GoSub 730     'CALL SUBROUTINE PSATT
        Call SubVPTS(t, p, VPTS) 'GoSub 2410     'CALL SUBROUTINE VPTS
        VTV = VPTS
    End Sub
    Public Sub SubVTL(ByRef t As Single, ByRef VTL As Single)
        Dim VPTL, p As Single
        ' ***************** SUBROUTINE VTL
        Call SubPSATT(p, t) 'GoSub 730     'CALL SUBROUTINE PSATT
        Call SubVPTL(t, p, VPTL) 'GoSub 2510    'CALL SUBROUTINE VPTL
        VTL = VPTL
    End Sub
    Public Sub SubETVG(ByRef t As Single, ByRef V As Single, ByRef ETVG As Single)
        Dim V1, T01, T2 As Single
        Dim T3, V3, S1 As Single
        Dim i, j As Short
        Dim ES, S2 As Single
        ' ***************** SUBROUTINE ETVG
2680:   T01 = 647.27 : V1 = 0.003147 : T2 = t + 273.15
        V3 = V1 / V : T3 = T01 / T2 : S1 = 0.0#
2690:   For i = 1 To 4
2700:       S1 = S1 + WA(i) * T3 ^ (i - 1)
2710:   Next i
2720:   ES = (1 / T3) ^ 0.5 / S1
2730:   ES = ES * 0.000001
2740:   S2 = 0.0#
2750:   For i = 1 To 6
2760:       For j = 1 To 5
2770:           S2 = S2 + WB(i, j) * (T3 - 1) ^ (i - 1) * (V3 - 1) ^ (j - 1)
2780:       Next j
2790:   Next i
2800:   ETVG = ES * System.Math.Exp(V3 * S2)
    End Sub
    Public Sub SubETV(ByRef t As Single, ByRef ETV As Single)
        Dim EPTS, V As Single
        ' ***************** SUBROUTINE ETV
        Call SubVTV(t, V) 'GoSub 2360
2570:   Call SubEPTS(t, V, EPTS) 'GoSub 2610     'CALL SUBROUTINE EPTS
2580:   ETV = EPTS
    End Sub
    Public Sub SubEPTL(ByRef t As Single, ByRef VPTL As Single, ByRef EPTL As Single)
        Dim ETVG As Single
        ' ***************** SUBROUTINE EPTL
        Call SubETVG(t, VPTL, ETVG) 'GoSub 2660  'CALL SUBROUTINE ETVG
        EPTL = ETVG
    End Sub
    Public Sub SubETL(ByRef t As Single, ByRef ETL As Single)
        Dim EPTL, V As Single
2830:   ' ***************** SUBROUTINE ETL
        Call SubVTL(t, V) 'GoSub 2360
2840:   Call SubEPTL(t, V, EPTL) 'GoSub 2880      'CALL SUBROUTINE EPTL
2850:   ETL = EPTL
    End Sub
    Public Sub SubEPTS(ByRef t As Single, ByRef V As Single, ByRef EPTS As Single)
        Dim ETVG As Single
2610:   ' ***************** SUBROUTINE EPTS
2620:   Call SubETVG(t, V, ETVG) 'GoSub 2660      'CALL SUBROUTINE ETVG
2630:   EPTS = ETVG
    End Sub
    Public Sub Inizia()
170:    ReDim WA(4)
        ReDim WB(6, 5)
        ReDim A0(18)
        Dim ifl As Integer
        Dim i, j As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\ACQPND.PND", OpenMode.Input)
180:    For i = 1 To 4 : Input(ifl, WA(i)) : Next
240:    For j = 1 To 5 : For i = 1 To 6 : Input(ifl, WB(i, j)) : Next
        Next j
500:    For i = 1 To 18 : Input(ifl, A0(i)) : Next i
        FileClose(ifl)
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
    End Sub
    Public Function CondI(ByRef t As Single, ByRef p As Single) As Single
        Dim A(4) As Double
        Dim B(3) As Double
        Dim C(3) As Double
        Dim Tr, Tc, PC, Pr As Single
        Dim Psat, Cond, Ps As Single
        Dim i As Short
        Dim Cond1 As Single
        A(0) = -0.92247 : A(1) = 6.728934102 : A(2) = -10.11230521
        A(3) = 6.996953832 : A(4) = -2.31606251
        B(0) = -0.20954276 : B(1) = 1.320227345 : B(2) = -2.485904388 : B(3) = 1.517081933
        C(0) = 0.08104183147 : C(1) = -0.4513858027 : C(2) = 0.8057261332 : C(3) = -0.4668315566
        Tc = 647.3 : PC = 221.2
        Tr = (t + 273.15) / Tc : Pr = p / PC
        For i = 0 To 4
            Cond = Cond + A(i) * Tr ^ i
        Next
        SubPSATT(Psat, t)
        Ps = Psat / PC
        For i = 0 To 3
            Cond1 = Cond1 + B(i) * Tr ^ i
        Next
        Cond = Cond + Cond1 * (Pr - Ps)
        Cond1 = 0
        For i = 0 To 3
            Cond1 = Cond1 + C(i) * Tr ^ i
        Next
        Cond = Cond + Cond1 * (Pr - Ps) ^ 2
        CondI = Cond
    End Function

    Public Function Cond67(ByRef t As Single, ByRef p As Single) As Single
        Dim lambda1, lambda As Single
        Dim rhogcm As Single
        lambda1 = 17.6 + 0.0587 * t + 0.000104 * t * t - 0.0000000451 * t * t * t
        SubVPTS(t, p, rhogcm)
        rhogcm = 1 / rhogcm / 1000
        lambda = lambda1 + (103.51 - 0.4198 * t - 0.00002771 * t * t) * rhogcm
        If t > 0 Then lambda = lambda + 214820000000000.0# / t ^ 4.2 * rhogcm ^ 2
        Cond67 = lambda / 1000
    End Function

    Public Sub Mostra()
        myForm = New frmApert
        myForm.obj = Me
        myForm.ShowDialog()
        myForm.Dispose()
    End Sub
    Public Sub SubKPTS(ByRef t As Single, ByRef p As Single, ByRef k As Single)
        Dim Psat As Single
        SubPSATT(Psat, t)
        If Psat > p Then
            k = Cond67(t, p)
        Else
            k = CondI(t, p)
        End If
    End Sub
    Public Function Conduc(ByRef t As Single, ByRef p As Single) As Single
        Conduc = Cond67(t, p)
    End Function
    Public Function Dens(ByRef t As Single, ByRef p As Single) As Single
        'densità del vapore
        Dim V As Single
        Call SubADRY(t, p, V, 1)
        Dens = 1 / V
    End Function
    Public Function Visco(ByRef t As Single, ByRef p As Single) As Single
        'Viscosità del vapore
        Dim V, E As Single
        Call SubADRY(t, p, V, 1)
        Call SubEPTS(t, V, E)
        Visco = E
    End Function
    Public Function Cp(ByRef t As Single, ByRef p As Single) As Single
        'calore specifico del vapore
        Dim H, h1 As Single
        SubHPTS(t, p, H)
        SubHPTS(t + 1, p, h1)
        Cp = (h1 - H) * 1000
    End Function
    Public Function CpL(ByRef t As Single, ByRef p As Single) As Single
        'calore specifico del vapore
        Dim H, h1 As Single
        SubHPTL(t, p, H)
        SubHPTL(t + 1, p, h1)
        CpL = (h1 - H) * 1000
    End Function
    Private Sub StampaCorpo()
        Dim t As Single
        Dim C, H As String
        Dim V, rho, k As String
        Dim Ent As Single ', R As Word.Range
        'Set R = Doc.GoTo(wdGoToBookmark, , , "Tab3")
        'R.Select
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Stub.VaiInizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Stub.VaiInizio("Tab3")
        With Stub 'Selection
            '.MoveDown , 2
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Stub.MuoviLinea. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .MuoviLinea(2)
            '.MoveLeft wdCell
            '.MuoviCella -1
            For t = Tmin To Tmax Step Tincr
                '.MoveRight wdCell
                '  .MuoviCella 1
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Stub.Testo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .Testo(Funzioni.myStr(t, 3, 2, False))
                If t <= Tsat Then
                    C = "--"
                    H = "--"
                    rho = "--"
                    V = "--"
                    k = "--"
                Else
                    C = Funzioni.myStr(Cp(t, Pressione), 5, 2, False)
                    SubHPTS(t, Pressione, Ent)
                    H = Funzioni.myStr(Ent, 5, 2, False)
                    rho = Funzioni.myStr(Dens(t, Pressione), 2, 6, False)
                    V = Funzioni.myStr(Visco(t, Pressione), 2, 7, False)
                    k = Funzioni.myStr(Conduc(t, Pressione), 2, 5, False)
                End If
                .MuoviCella(3)
                .Testo(C)
                .MuoviCella(1)
                .Testo(k)
                .MuoviCella(1)
                .Testo(V)
                .MuoviCella(1)
                .Testo(H)
                .MuoviCella(1)
                .Testo(rho)
                .LibMatDestra()
            Next
        End With
    End Sub
    Private Sub FinePagina()
        Stub.VaiInizio("Autore")
        With Stub 'Selection
            .Testo(Monitor.Motore.Problem.Author)
            .MuoviLinea(1)
            .MuoviParola(1)
            .MuoviLinea(1)
            .Testo(Today)
        End With
    End Sub
    Public Function SurfTens(ByRef t As Single) As Single
        Dim Zero, Tc As Single
        Dim Bp, Bg, mi As Single
        Dim Tparam As Single
        Bg = 0.2358 : Bp = -0.625 : mi = 1.256
        Zero = 273.15
        Tc = 647.16
        Tparam = (Tc - Zero - t) / Tc
        SurfTens = Bg * Tparam ^ mi * (1 + Bp * Tparam)
    End Function
    Protected Overrides Sub Finalize()
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Monitor = Nothing
        MyBase.Finalize()
    End Sub
End Class