Imports System.math
Imports HTRI.Dati
Module vecchiFORTRAN
    Sub HTR10(ByRef M As Short, ByRef Stac() As Integer) ', ByRef Ialt As Alternative)
        Stop
    End Sub
    Sub HTR10A(ByRef Stac() As Integer)
        Stop
    End Sub
    Sub SETRDIT(ByRef Nome As String, ByRef n As Integer)
        Dim i As Integer
        For i = 1 To actPRV.Items.Count
            If Nome.Equals(CType(actPRV.Items(i), clsItem).Sigla) Then
                n = i
                actItem = CType(actPRV.Items(i), clsItem)
                Exit Sub
            End If
        Next
        Stop
    End Sub
    Sub GETBANK(ByRef Bank(,) As String)
        Bank(Nrdit, 1) = actItem.Banco
        Bank(Nrdit, 2) = actItem.Banco2
        Bank(Nrdit, 3) = actItem.Banco3
        Bank(Nrdit, 4) = actItem.Banco4
    End Sub
    Sub PUTBANK(ByRef Bank(,) As String)
        actItem.Banco = Bank(Nrdit, 1)
        actItem.Banco2 = Bank(Nrdit, 2)
        actItem.Banco3 = Bank(Nrdit, 3)
        actItem.Banco4 = Bank(Nrdit, 4)
    End Sub
    Sub NEWITM(ByVal Nome As String)
        Dim Item As New clsItem
        Item.Sigla = Nome
        actPRV.Items.Add(Item)
    End Sub
    Sub COPIA(ByVal NomeIn As String, ByVal NomeOut As String)
        Dim i, nIn, nOut As Integer
        Dim ItemIn, ItemOut As clsItem
        For i = 1 To actPRV.Items.Count
            If NomeIn.Equals(CType(actPRV.Items(i), clsItem).Sigla) Then
                nIn = i
                ItemIn = CType(actPRV.Items(i), clsItem)
                Exit For
            End If
        Next
        If nIn = 0 Then Stop
        For i = 1 To actPRV.Items.Count
            If NomeOut.Equals(CType(actPRV.Items(i), clsItem).Sigla) Then
                nOut = i
                ItemOut = CType(actPRV.Items(i), clsItem)
                Exit For
            End If
        Next
        If nOut = 0 Then
            ItemOut = New clsItem
            actPRV.Items.Add(ItemOut)
            nOut = actPRV.Items.Count
        End If
        ItemIn.Copia(ItemOut)
    End Sub
    Sub DSDS(ByVal n As Integer, ByVal Item As String, ByVal Unita As String)
        Stop
    End Sub
    Function SPLIT1(ByVal ipag As Integer, ByVal npag As Integer, ByVal Mecc As String, ByVal prevent As String) As Integer
        Stop
    End Function
    Function SPLIT2(ByVal ipag As Integer, ByVal npag As Integer, ByVal Mecc As String, ByVal prevent As String) As Integer
        Stop
    End Function
    Sub ALETT(ByVal T() As Single, ByVal IAL() As String, ByVal FV As Single, ByRef BAK() As Single, ByRef SRAT As Single)
        'CHARACTER*2 IAL(2)                                                HHT13700
        ' DIMENSION(T(4), BAK(2))
        'REAL*4 T,RN,SRAT,RATIO,CF,CCF
        Dim I, KN, KA, K3, K1, K2 As Integer
        'C *** t(4) kn fins/inch;t(1)o.d.;t(3) dia.fin t(2) passo                HHT14010
        If (Not IAL(2) = "ST" Or IAL(2) = "HE" Or IAL(2) = "") Then
            BAK(1) = 0
            BAK(2) = 0
            SRAT = 0
            Exit Sub
        End If
        For I = 1 To 6
            If (T(4) < Dati.FinInch(I)) Then KN = I
        Next
        If (T(4) > Dati.FinInch(1)) Then KN = 1
        KA = 0
        For I = 1 To 4
            If (IAL(1) = Dati.TipoFin(I)) Then KA = I
        Next
        If (T(1) > 0.99 And T(1) < 1.1) Then
            Call OdTubes1(T, KN, KA, K1, K2, K3, IAL)
        ElseIf (T(1) < 1.3) Then
            Call OdTubes125(T, KN, KA, K1, K2, K3)
        ElseIf (T(1) < 1.55) Then
            Call OdTubes15(T, KN, KA, K1, K2, K3, IAL)
        ElseIf (T(1) < 2.1) Then
            Call OdTubes2(T, KN, KA, K1, K2, K3)
        Else
            BAK(1) = 0
            BAK(2) = 0
            SRAT = 0
            Exit Sub
        End If
        If K1 = 0 Then
            BAK(1) = 0
            BAK(2) = 0
            SRAT = 0
            Exit Sub
        End If
        SRAT = Dati.RATIO(K3) * T(4) / 10
        If (SRAT = 0) Then SRAT = 1
        If (FV > 0) Then
            BAK(1) = Dati.CF(2, K1) * FV ^ Dati.CF(1, K1) * Dati.CCF(1, K2)
            BAK(2) = Dati.CF(4, K1) * FV ^ Dati.CF(3, K1) * Dati.CCF(2, K2)
        Else
            BAK(2) = Dati.CF(2, K1) * Dati.CCF(1, K2)
            BAK(1) = Dati.CF(1, K1)
            BAK(4) = Dati.CF(4, K1) * Dati.CCF(2, K2)
            BAK(3) = Dati.CF(3, K1)
        End If
    End Sub
    Private Sub OdTubes2(ByVal T() As Single, ByVal KN As Integer, ByVal KA As Integer, _
            ByRef k1 As Integer, ByRef k2 As Integer, ByRef k3 As Integer)
        '      C *** 2.0" OD TUBES ***********                                         HHT15980
        If (T(2) > 4.1 Or T(2) < 3.9) Then
            k1 = 0
        ElseIf (KN <> 2 Or KA <> 3) Then
            k1 = 0
        ElseIf (T(3) < 3.6 And T(3) > 3.4) Then
            k2 = 5
            k3 = 6
            k1 = 11
        ElseIf (T(3) < 3.3 And T(3) > 3.2) Then
            k2 = 5
            k3 = 7
            k1 = 12
        End If
    End Sub
    Private Sub OdTubes15(ByVal T() As Single, ByVal KN As Integer, ByVal KA As Integer, _
            ByRef k1 As Integer, ByRef k2 As Integer, ByRef k3 As Integer, ByRef IAL() As String)
        '       C *** 1.5" OD TUBES ************                                        HHT15300
        If (T(3) > 2.8 Or T(3) < 2.7) Then GoTo 395
        k3 = 5
        k1 = 8
        If (T(2) > 3.1 Or T(2) < 2.9) Then GoTo 350
        'GOTO (900,310,320,330,340,900),KN+1                              HHT15350
        Select Case KN + 1
            Case 1
                k1 = 0
            Case 2 '310  GO TO (900,900,312,314,900),KA                                    HHT15360
                Select Case KA
                    Case 1, 2 : k1 = 0
                    Case 3 : k2 = 34
                    Case 4 : k2 = 35
                    Case Else : k1 = 0
                End Select
            Case 3 '320  GO TO (900,322,324,326,328,900),KA+1                              HHT15410
                Select Case KA + 1
                    Case 1 : k1 = 0
                    Case 2 : k2 = 37
                    Case 3 : k2 = 5
                    Case 4 : k2 = 36
                    Case 5 : k2 = 38
                    Case Else : k1 = 0
                End Select
            Case 4 '330  GO TO (900,900,332,334,900),KA                                    HHT15500
                Select Case KA
                    Case 1, 2 : k1 = 0
                    Case 3 : k2 = 39
                    Case 4 : k2 = 40
                    Case Else : k1 = 0
                End Select
            Case 5 ' 340  GO TO (900,342,344,900),KA+1                                      HHT15550
                Select Case KA + 1
                    Case 1 : k1 = 0
                    Case 2 : k2 = 42
                    Case 3 : k2 = 41
                    Case Else : k1 = 0
                End Select
        End Select
350:    If (T(2) > 2.8 Or T(2) < 2.7) Then
            k1 = 0
            Exit Sub
        End If
        '   GO TO (900,360,370,380,390,900),KN+1                              HHT15610
        Select Case KN + 1
            Case 1 : k1 = 0
            Case 2 '360  GO TO (900,900,362,364,900),KA                                    HHT15620
                Select Case KA
                    Case 1, 2 : k1 = 0
                    Case 3 : k2 = 43
                    Case 4 : k2 = 44
                    Case Else : k1 = 0
                End Select
            Case 3 '370  GO TO (900,372,374,376,378,900),KA+1                              HHT15670
                Select Case KA + 1
                    Case 1 : k1 = 0
                    Case 2 : k2 = 47
                    Case 3 : k2 = 46
                    Case 4 : k2 = 45
                    Case 5 : k2 = 48
                    Case Else : k1 = 0
                End Select
            Case 4 ' 380  GO TO (900,900,382,384,900),KA                                    HHT15760
                Select Case KA
                    Case 1, 2 : k1 = 0
                    Case 3 : k2 = 49
                    Case 4 : k2 = 50
                    Case Else : k1 = 0
                End Select
            Case 5 ' 390  GO TO (900,392,394,900),KA+1                                      HHT15810
                Select Case KA + 1
                    Case 1 : k1 = 0
                    Case 2 : k2 = 52
                    Case 2 : k2 = 51
                    Case Else : k1 = 0
                End Select
            Case Else : k1 = 0
        End Select
395:    If (T(3) <> 0) Then k1 = 0 : Exit Sub
        k3 = 3
        k2 = 5
        T(4) = 0
        IAL(1) = ""
        If (T(2) > 2.1 Or T(2) < 1.9) Then GoTo 398
        k1 = 9
        Exit Sub
398:    If (T(2) > 2.6 Or T(2) < 2.4) Then k1 = 0 : Exit Sub
        k1 = 10
    End Sub
    Private Sub OdTubes125(ByVal T() As Single, ByVal KN As Integer, ByVal KA As Integer, _
            ByRef k1 As Integer, ByRef k2 As Integer, ByRef k3 As Integer)
        '        C *** 1.25" OD TUBES **********                                         HHT15030
        If (T(3) < 2.55 And T(3) > 2.45) Then
            k3 = 4
        ElseIf (T(2) < 2.8 And T(2) > 2.7) Then
            k1 = 7
            '      GO TO (900,210,220,230,240,900),KN+1                              HHT15080
            Select Case KN + 1
                Case 1 : k1 = 0
                Case 2
                    '210  GO TO (900,900,212,214,900),KA                                    HHT15090
                    Select Case KA
                        Case 1, 2 : k1 = 0
                        Case 3 : k2 = 27
                        Case 4 : k2 = 28
                        Case Else : k1 = 0
                    End Select
                Case 3
                    '220  GO TO (900,222,224,226,900),KA                                    HHT15140
                    Select Case KA
                        Case 1 : k1 = 0
                        Case 2 : k2 = 5
                        Case 3 : k2 = 29
                        Case 4 : k2 = 30
                        Case Else : k1 = 0
                    End Select
                Case 4
                    Select Case KA
                        '230  GO TO (900,900,232,234,900),KA                                    HHT15210
                        Case 1, 2 : k1 = 0
                        Case 3 : k2 = 31
                        Case 4 : k2 = 32
                        Case Else : k1 = 0
                    End Select
                Case 5
                    ' 240  GO TO (900,242,900),KA                                            HHT15260
                    Select Case KA
                        Case 2 : k2 = 33
                        Case Else : k1 = 0
                    End Select
            End Select
        Else
            k1 = 0
        End If
    End Sub
    Private Sub OdTubes1(ByRef T() As Single, ByVal KN As Integer, ByVal KA As Integer, _
            ByRef k1 As Integer, ByRef k2 As Integer, ByRef k3 As Integer, ByRef IAL() As String)
        'C *** 1.0" OD TUBES ***                                                 HHT14100
        If (T(3) > 2.26 Or T(3) < 2.24) Then GoTo 120
        k3 = 1
        k1 = 1
        If (T(2) < 2.6 And T(2) > 2.4) Then
            Select Case KN + 1
                'GO TO (900,30,40,50,60,900),KN+1                                  HHT14150
                Case 2
                    '30   GO TO (900,32,34,36,900),KA                                       HHT14160
                    Select Case KA
                        Case 2 : k2 = 2
                        Case 3 : k2 = 1
                        Case 4 : k2 = 3
                        Case Else : k1 = 0
                    End Select
                Case 3
                    ' 40   GO TO (900,42,44,46,48,900),KA+1                                  HHT14230
                    Select Case KA
                        Case 2 : k2 = 7
                        Case 3 : k2 = 5
                            If (IAL(2) = "HE") Then k2 = 6
                        Case 4 : k2 = 4
                        Case 5 : k2 = 8
                        Case Else : k1 = 0
                    End Select
                Case 3
                    ' 50   GO TO (900,900,52,54,900),KA                                      HHT14330
                    Select Case KA
                        Case 3 : k2 = 9
                        Case 4 : k2 = 10
                        Case Else : k1 = 0
                    End Select
                Case 4
                    ' 60   GO TO (900,62,64,900),KA+1                                        HHT14380
                    Select Case KA + 1
                        Case 2 : k2 = 13
                        Case 3 : k2 = 11
                            If (IAL(2) = "HE") Then k2 = 12
                        Case Else : k1 = 0
                    End Select
            End Select
        ElseIf (T(2) < 2.38 And T(2) > 2.37) Then
            Select Case KN + 1
                '      GO TO (900,80,90,100,110,900),KN+1                                HHT14450
                Case 2
                    '80   GO TO (900,82,84,86,900),KA                                       HHT14460
                    Select Case KA
                        Case 2 : k2 = 15
                        Case 3 : k2 = 14
                        Case 4 : k2 = 16
                        Case Else : k1 = 0
                    End Select
                Case 3
                    ' 90   GO TO (900,92,94,96,98,900),KA+1                                  HHT14530
                    Select Case KA + 1
                        Case 2 : k2 = 20
                        Case 3 : k2 = 18
                            If (IAL(2) = "HE") Then k2 = 19
                        Case 4 : k2 = 17
                        Case 5 : k2 = 21
                        Case Else : k1 = 0
                    End Select
                Case 4
                    ' 100  GO TO (900,900,102,104,900),KA                                    HHT14630
                    Select Case KA
                        Case 3 : k2 = 22
                        Case 4 : k2 = 23
                        Case Else : k1 = 0
                    End Select
                Case 5
                    ' 110  GO TO (900,112,114,900),KA+1                                      HHT14680
                    Select Case KA
                        Case 2 : k2 = 26
                        Case 3 : k2 = 24
                            If (IAL(2) = "HE") Then k2 = 25
                        Case Else : k1 = 0
                    End Select
            End Select
        End If
120:    If (T(3) > 1.63 Or T(3) < 1.62) Then GoTo 150
        k3 = 2
        If (KN <> 5 Or KA <> 2) Then k1 = 0 : Exit Sub
        k2 = 5
        If (T(2) > 2.1 Or T(2) < 1.99) Then GoTo 130
        k1 = 3
        Exit Sub
130:    If (T(2) > 1.88 Or T(2) < 1.87) Then k1 = 0 : Exit Sub
        k1 = 2
        Exit Sub
150:    If (T(3) <> 0) Then k1 = 0 : Exit Sub
        k3 = 3
        k2 = 5
        T(4) = 0
        IAL(1) = ""
        If (T(2) > 1.8 Or T(2) < 1.7) Then GoTo 160
        k1 = 4
        Exit Sub
160:    If (T(2) > 1.9 Or T(2) < 1.8) Then GoTo 170
        k1 = 5
        Exit Sub
170:    If (T(2) > 2.1 Or T(2) < 1.9) Then GoTo 180
        k1 = 6
        Exit Sub
180:    If (T(2) < 1.66 Or T(2) > 1.67) Then k1 = 0 : Exit Sub
        k1 = 13
    End Sub
    Public Function IEXIST(ByVal DTUB As Single, ByVal DAL As Single, ByVal PASSO As Single, _
                           ByVal FININCH As Single, ByVal TIPO As String, ByRef ABN() As Single) As Integer
        Dim I As Integer
        Dim T(4), AB(4), SRAT As Single
        Dim IAL(2) As String
        T(1) = DTUB
        T(2) = PASSO
        T(3) = DAL
        T(4) = FININCH
        IAL(1) = TIPO
        IAL(2) = ""
        Call ALETT(T, IAL, 0, AB, SRAT)
        IEXIST = 0
        If (SRAT > 0 Or AB(1) > 0 Or AB(2) > 0) Then IEXIST = 1
    End Function
    Public Sub HTR7C(ByVal DIFF As Single, ByVal SURFUS() As Single, ByVal SURFRQ() As Single)
        'C     CALCOLO TERMICO (CONTINUA)                                        HT700040
        '      COMMON/FINCOM/IBUF,IBUF1,IBUF2,IZZ(12),N1(27),N2(27),RM(2)
        '	INTEGER*2 IZZ,N1,N2
        '	REAL*4 RM
        '     CHARACTER*2 IBUF(17,2),IBUF1(17,2),IBUF2(17)
        '      INCLUDE() 'PRINCIP.FI'
        'C     FUNCTION ******
        'C     FSPGR(T)=1.00054+.66097489D-04*T-.18453961D-05*T**2
        'C    C   +.3066462655D-08*T**3-.280482582D-11*T**4
        'C****************************************************************
        Dim I, IB60I, J As Single
        Dim DIN, U1, CSM, CGR, DENH2O, DENSHC As Single
        '	REAL*4 FSPGR,RETLI,FRICTION
        Dim CF, YIN, YOU, XIN, XOU, RIT As Single
        For I = 1 To actAltern.NumZone
            If (KCALC(I) <> 2) Then GoTo 200
            IB60I = actAltern.TipoTubi(I)
            DIN = actAltern.DiaTubo(IB60I) - 2 * actAltern.SpessInch(IB60I)
            RZ(77, I) = RZ(65, I)
            RZ(78, I) = RZ(69, I)
            U1 = (1 - RZ(42, I) / RZ(43, I) / 62.344) ^ 1.5
            CSM = 2.75 * (1 + 2 / Math.Sqrt(RZ(79, I))) * U1
            CGR = (1 + 2 / RZ(79, I) ^ 0.35) * U1
            RZ(80, I) = CSM
            If (RZ(66, I) > 0.3) Then RZ(80, I) = (RZ(66, I) - 0.3) / 0.4 * CGR + _
                                      (0.7 - RZ(66, I)) / 0.4 * CSM
            If (RZ(66, I) > 0.7) Then RZ(80, I) = CGR
            If (RZ(78, I) < 4000) Then GoTo 25
            'C      RZ(125,I) = 0.0014+0.125 /RZ(78,I)**0.32
            RZ(125, I) = FRICTION(RZ(78, I), actAltern.codTurbolators(IB60I))
            RZ(113, I) = RZ(125, I) * RZ(68, I) ^ 2 * actAltern.LunghZona(I) / 193 / DIN
            '     C        /RZ(43,I)/62.344
            RZ(75, I) = 1 + RZ(80, I) / RZ(79, I) + 1 / RZ(79, I) ^ 2
            GoTo 251
25:         RZ(78, I) = RZ(60, I)
            'C      RZ(125,I)=0.0014+0.125/RZ(78,I)**0.32
            RZ(125, I) = FRICTION(RZ(78, I), actAltern.codTurbolators(IB60I))
            RZ(113, I) = RZ(125, I) * RZ(59, I) ^ 2 * actAltern.LunghZona(I) / 193 / DIN / RZ(42, I)
            RZ(75, I) = 1 + RZ(80, I) * RZ(79, I) + RZ(79, I) ^ 2
251:        RZ(81, I) = RZ(75, I) * RZ(113, I)
            DENH2O = FSPGR(RZ(5, I))
            DENSHC = RETLI(RZ(5, I), 24)
            Call DEAVG(RZ(4, I), RZ(2, I), DENH2O, DENSHC, RZ(114, I))
            RZ(114, I) = RZ(114, I) * 62.344
            DENH2O = FSPGR(actAltern.TempOut(I))
            DENSHC = RETLI(actAltern.TempOut(I), 24)
            Call DEAVG(RZ(10, I), RZ(8, I), DENH2O, DENSHC, RZ(115, I))
            RZ(115, I) = RZ(115, I) * 62.344
            CF = RETLI(RZ(5, I), 48)
            RZ(116, I) = RZ(37, I) * RZ(41, I) / 10.73 / CF / (460 + RZ(5, I))
            CF = RETLI(actAltern.TempOut(I), 48)
            RZ(117, I) = RZ(38, I) * RZ(41, I) / 10.73 / CF / (460 + actAltern.TempOut(I))
            YIN = RZ(31, I) / (RZ(35, I) + RZ(36, I))
            YOU = RZ(32, I) / (RZ(35, I) + RZ(36, I))
            XIN = 1 - YIN
            XOU = 1 - YOU
            Dati.RM(2) = XOU / RZ(115, I)
            If (RZ(32, I) > 0) Then Dati.RM(2) = Dati.RM(2) + YOU / RZ(117, I)
            Dati.RM(1) = YIN / RZ(116, I)
            If (RZ(33, I) > 0) Then Dati.RM(1) = Dati.RM(1) + XIN / RZ(114, I)
            RZ(120, I) = RZ(65, I) ^ 2 * (Dati.RM(2) - Dati.RM(1)) / 4633
            If (RZ(120, I) > 0) Then RZ(120, I) = 0
            RZ(82, I) = RZ(65, I) ^ 2 / RZ(44, I) * (RZ(57, I) / 26500 + RZ(58, I) / 16850)
            RIT = 0
            If (actAltern.NumTotPassi <> 1) Then RIT = (RZ(57, I) + RZ(58, I)) / 2 - 0.5
            If (RIT > 0.1) Then RZ(82, I) = RZ(82, I) + RZ(65, I) ^ 2 / RZ(44, I) / 13240 * RIT
            RZ(92, I) = RZ(81, I) + RZ(82, I) + RZ(120, I)
            actAltern.deltaPtot += RZ(92, I)
200:    Next I
        'C --- CALL HTRI8 ---
        IPRAM(11) = 0
        DIFF = actAltern.percdifftot ' DG(46)
        For J = 1 To actAltern.NumZone
            SURFUS(J) = RZ(Dati.N1(17), J)
            SURFRQ(J) = RZ(Dati.N2(17), J)
        Next
        Call TEMPPASS()
        'Call SCRIVI7(IPRAM(3))
    End Sub
    Private Sub TEMPPASS()
        Dim ALZ(12), TEMP(12), TOTLZ, ACTL, TEMPFIN, TIN As Single
        Dim JZ, I, IZ As Integer
        If (actAltern.NumTotPassi > 16) Then Exit Sub
        JZ = 0
        TOTLZ = 0
        ACTL = 0
        For I = 1 To actAltern.NumTotPassi
            IZ = 1
            ALZ(IZ) = 0
            If (I = 1) Then
                TEMP(IZ) = Dati.R(2)
            Else
                TEMP(IZ) = TEMPFIN
            End If
2:          IZ = IZ + 1
            JZ = JZ + 1
            TOTLZ = TOTLZ + actAltern.LunghZona(JZ)
            If (TOTLZ > actAltern.LunghezzaFascio * I Or JZ = actAltern.NumZone) Then
                ALZ(IZ) = actAltern.LunghezzaFascio * I - ACTL
                If (JZ = 1 And I = 1) Then
                    TIN = Dati.R(2)
                Else
                    TIN = TEMPFIN
                End If
                TEMPFIN = TIN + (actAltern.TempOut(JZ) - TIN) * ALZ(IZ) / (TOTLZ - ACTL)
                ACTL = ACTL + ALZ(IZ)
                TEMP(IZ) = TEMPFIN
                actAltern.Tmedia(I) = TMEDIA(IZ, ALZ, TEMP)
                TOTLZ = TOTLZ - actAltern.LunghZona(JZ)
                JZ = JZ - 1
            Else
                If (IZ = 2 And I > 1) Then
                    ALZ(IZ) = TOTLZ - actAltern.LunghezzaFascio * (I - 1)
                Else
                    ALZ(IZ) = actAltern.LunghZona(JZ)
                End If
                ACTL = ACTL + ALZ(IZ)
                TEMPFIN = actAltern.TempOut(JZ)
                TEMP(IZ) = TEMPFIN
                GoTo 2
            End If
        Next
        Return
    End Sub
    Private Function TMEDIA(ByVal N As Integer, ByVal ALUNG() As Single, ByVal TEMP() As Single) As Single
        Dim Risult As Single
        Dim I As Integer
        Dim TOTLEN, AL, FRICTION, REY As Single
        Risult = 0
        TOTLEN = 0
        For I = 2 To N
            Risult = Risult + (TEMP(I) + TEMP(I - 1)) / 2 * ALUNG(I)
            TOTLEN = TOTLEN + ALUNG(I)
        Next
        Risult = Risult / TOTLEN
        Return Risult
    End Function
    Private Sub DEAVG(ByVal W1 As Single, ByVal W2 As Single, ByVal D1 As Single, ByVal D2 As Single, ByRef DEA As Single)
        Dati.CH2O = 0
        If (W1 > 0 And D1 > 0) Then Dati.CH2O = W1 / D1
        Dati.CHCV = 0
        If (W2 > 0 And D2 > 0) Then Dati.CHCV = W2 / D2
        Dati.CHIN = Dati.CH2O + Dati.CHCV
        If (Dati.CHIN > 0) Then DEA = (W1 + W2) / Dati.CHIN
    End Sub
    Private Function FRICTION(ByVal REY As Single, ByVal KTURB As Short) As Single
        Dim AL As Single
        If (KTURB > 2) Then
            AL = Math.Log(REY)
            FRICTION = Math.Exp(TURB(3) + TURB(4) * AL + TURB(5) * AL * AL)
        Else
            FRICTION = 0.0014 + 0.125 * REY ^ (-0.32)
        End If
    End Function
    Private Function FSPGR(ByVal T As Single) As Single ' !Specific gravity
        FSPGR = Dati.ADAT(23) + Dati.ADAT(24) * T + Dati.ADAT(25) * T ^ 2 _
              + Dati.ADAT(26) * T ^ 3 + Dati.ADAT(27) * T ^ 4
    End Function
    Private Function RETLI(ByVal X As Single, ByVal I As Integer) As Single
        '        INCLUDE() 'CMN.FI'
        '       INCLUDE() 'CMN1.FI'
        '      INCLUDE() 'PRINCIP.FI'
        '     INCLUDE() 'CMN3.FI'
        Dim A, Bloc, T2, YY2, T1, YY1, Ris As Single
        Dim YY As Integer
        Dim II, IERR, J, NPUNTI As Integer
        Dim testo, NewF As String
        If (actAltern.Prinop > 0) Then GoTo 100
120:    If ((Dati.R(4 + I) - Dati.R(2 + I)) = 0) Then Return 0
        A = (Dati.R(3 + I) - Dati.R(1 + I)) / (Dati.R(4 + I) - Dati.R(2 + I))
        Bloc = Dati.R(1 + I) - A * Dati.R(2 + I)
        Return A * X + Bloc
100:    testo = GlobalRoutines.Str2Cifre(Nrdit \ 2) + ActivAlt.ToString
        NewF = Monitor.Motore.Inizio.Workdir.Trim & "\" & job.Contratto.Substring(0, 4) & testo & ".RA2"
        FileOpen(100, NewF, OpenMode.Random, , , Len(Curva))
        FileGet(100, Curva, 1)
        II = 1
        Do '101 II=1,NPUNTI
            FileGet(100, Curva, II)
            If Curva.Temp < 0 Then Exit Do
            If EOF(100) Then Exit Do
            If (Curva.Temp < X) Then Exit Do
            II += 1
        Loop '101:            Continue Do
        If (II <= 1 And I > 3 And I <> 16) Then GoTo 120
        If (II = 1) Then
            II = 2
            FileGet(100, Curva, II)
        End If
        Select Case (I)
            Case (1)
                J = 4 '! ENTALPIA TOTALE
                YY2 = Curva.Entl
            Case (2)
                J = 3 '! TITOLO PONDERALE FASE AERIFORME
                YY2 = Curva.Xgas
            Case (3)
                J = 18 '! PESO MOLECOLARE GAS
                YY2 = Curva.MolG
            Case (4)
                J = 19 '!TITOLO PONDERALE ACQUA LIQUIDA
                YY2 = Curva.XAcq
            Case (5)
                J = 20 '!ENTALPIA ACQUA LIQUIDA
                YY2 = Curva.HAcq
            Case (6)
                J = 5 '!ENTALPIA GAS
                YY2 = Curva.Hliq
            Case (7)
                J = 6 '!ENTALPIA FASE LIQUIDA IDROCARBURICA
                YY2 = Curva.Hgas
            Case (16)
                J = 9 '!da qui in poi l'indice I è quello dell'array R(*)
                YY2 = Curva.Visl
            Case (20)
                J = 11
                YY2 = Curva.Conl
            Case (24)
                J = 15
                YY2 = Curva.Sgra
            Case (28)
                J = 13
                YY2 = Curva.Cliq
            Case (32)
                J = 14
                YY2 = Curva.DenV
            Case (36)
                J = 8
                YY2 = Curva.Visg
            Case (40)
                J = 10
                YY2 = Curva.Cong
            Case (44)
                J = 7
                YY2 = Curva.Cgas
            Case (48)
                J = 12
                YY2 = Curva.Cfac
            Case Else
                GoTo 120
        End Select
        T2 = Curva.Temp
        FileGet(100, Curva, II - 1)
        T1 = Curva.Temp
        Select Case (I)
            Case (1)
                J = 4 '! ENTALPIA TOTALE
                YY2 = Curva.Entl
            Case (2)
                J = 3 '! TITOLO PONDERALE FASE AERIFORME
                YY2 = Curva.Xgas
            Case (3)
                J = 18 '! PESO MOLECOLARE GAS
                YY2 = Curva.MolG
            Case (4)
                J = 19 '!TITOLO PONDERALE ACQUA LIQUIDA
                YY2 = Curva.XAcq
            Case (5)
                J = 20 '!ENTALPIA ACQUA LIQUIDA
                YY2 = Curva.HAcq
            Case (6)
                J = 5 '!ENTALPIA GAS
                YY2 = Curva.Hliq
            Case (7)
                J = 6 '!ENTALPIA FASE LIQUIDA IDROCARBURICA
                YY2 = Curva.Hgas
            Case (16)
                J = 9 '!da qui in poi l'indice I è quello dell'array R(*)
                YY2 = Curva.Visl
            Case (20)
                J = 11
                YY2 = Curva.Conl
            Case (24)
                J = 15
                YY2 = Curva.Sgra
            Case (28)
                J = 13
                YY2 = Curva.Cliq
            Case (32)
                J = 14
                YY2 = Curva.DenV
            Case (36)
                J = 8
                YY2 = Curva.Visg
            Case (40)
                J = 10
                YY2 = Curva.Cong
            Case (44)
                J = 7
                YY2 = Curva.Cgas
            Case (48)
                J = 12
                YY2 = Curva.Cfac
            Case Else
                GoTo 120
        End Select
        If ((T2 - T1) = 0) Then
            If (I > 3 And I <> 16) Then
                GoTo 120
            Else
                Return 0
            End If
        End If
        Ris = YY1 + (X - T1) / (T2 - T1) * (YY2 - YY1)
        '!           IF(J.EQ.15)RETLI=RETLI*1000.
        If (J <> 19 And J <> 3) Then
            If (Ris = 0 Or YY2 = 0 Or YY1 = 0) Then
                If (I = 16) Then
                    actAltern.Prinop = -actAltern.Prinop
                    Return 0
                End If
                If (I > 3 And I <> 16) Then GoTo 120
            End If
        End If
        Return Ris
    End Function
    Public Sub LOOPZ(ByVal FACT() As Single)
        '        ICONTR = 7
        '     OPEN(1,FILE='TEXT'//PREVENT,STATUS='NEW')
        Dim RISULT As Boolean
        Dim I As Integer
        Dim IBNEAR(12) As Integer
        If (actAltern.NumZone > 1) Then RISULT = AGGIUSTAZONEFISSE(FACT)
        If (Not RISULT) Then
            Dim Testo As String = "Attenzione: ci sono nei dati di ingresso, o si sono create durante" + vbCrLf
            Testo = Testo + "il processo iterativo di ricerca della soluzione, due zone" + vbCrLf
            Testo = Testo + "fisse contigue. Ciò può impedire il prosieguo del calcolo." + vbCrLf
            Testo = Testo + "Si suggerisce di aumentare il numero di zone."
            MessageBox.Show(Testo)
            Exit Sub
        End If
        TOTLEN = 0
        TUBMED = 0
        For I = 1 To actAltern.NumZone
            If (actAltern.codZona(I) \ 2 = 0) Then
                FACT(I) = FACT(I) / Dati.RZ(55, I)
            Else
                FACT(I) = actAltern.LunghZona(I) / actPRV.LunghPercorsoEff / Dati.RZ(55, I)
            End If
            TUBMED = TUBMED + FACT(I)
        Next
        Dim FISSO As Boolean = False
        For I = 1 To actAltern.NumZone - 1
            If (actAltern.codZona(I) \ 2 = 0) Then
                actAltern.LunghZona(I) = CInt((actPRV.LunghPercorsoEff * FACT(I) / TUBMED + 0.01) * 10) / 10
            Else
                FISSO = True
            End If
        Next I
        If (FISSO) Then
            Call RIAGGIUSTA()
            For I = 1 To actAltern.NumZone
                IBNEAR(I) = actAltern.codZona(I) And 1
            Next
            Call AUTOM2(IBNEAR)
        End If
        For I = 1 To actAltern.NumZone - 1
            TOTLEN = TOTLEN + actAltern.LunghZona(I)
        Next
        actAltern.LunghZona(actAltern.NumZone) = actPRV.LunghPercorsoEff - TOTLEN
        TOTLEN = actPRV.LunghPercorsoEff
        FACT(1) = 0
        RLC = CInt((actAltern.LunghezzaFascio + 0.01) * 10) / 10 * Dati.KEYP
        'C   KEYP: numero di passi con il primo tipo tubi
        If (actAltern.NumTipiTubi > 1) Then
            For I = 1 To actAltern.NumZone - 1
                Dim KEYFIX As Integer = actAltern.codZona(I) \ 2
                If (KEYFIX = KEYP) Then GoTo 83
            Next
            Call DEFAULT2TIPI(FACT, ICONTR)
        End If
83:     RKEYL = 0
        'C      DO 80 I=1,NBDITI(18)                                              HHT10400
        'C      RKEYL=RKEYL+DGZ(6,I)                                              HHT10410
        'c      NBDITI(60+I)=1                                                    HHT10420
        'c      IF (IPRAM(6) .GT. 0) NBDITI(60+I)=2                               HHT10430
        '       C(NBDITI(132 + I) = 1)
        'C      IF (IPRAM(6) .GT. 0) NBDITI(132+I)=2                  
        'C      IF (RKEYL .GT. (RLC-.01) .AND. RKEYL .LT. (RLC+.01))              HHT10440
        'C     C               IPRAM(6)=I                                         HHT10450
        'C80    CONTINUE
        IPRAM(6) = 0
        If (actAltern.NumZone > 1) Then
            For I = 1 To actAltern.NumZone
                RKEYL = RKEYL + actAltern.LunghZona(I)
                actAltern.TipoTubi(I) = 1
                If (IPRAM(6) > 0) Then
                    actAltern.TipoTubi(I) = 2
                Else
                    If (RKEYL > (RLC - 0.01)) Then
                        If (I > 1 And Math.Abs(RLC - RKEYL) / (RLC - RKEYL + actAltern.LunghZona(I - 1)) > 0.5) Then
                            IPRAM(6) = I - 1
                        Else
                            IPRAM(6) = I
                        End If
                    End If
                End If
            Next
        Else
            IPRAM(6) = 1
            actAltern.TipoTubi(1) = 1
        End If
        If (IPRAM(6) > 0) Then GoTo 90
        ' WRITE(1,2020)1
        'C      GO TO 900                     
        '       CLOSE(1)
        Exit Sub '      Return
90:     '    Continue Do
        If (actAltern.PassiOrizzontali <> "YE") Then GoTo 95
        actPRV.FrazPassoHor = 1 / actAltern.NumTotPassi
        GoTo 102
95:     actPRV.FrazPassoHor = 1
102:    NZ = 1
        LF1 = 0
        For I = 1 To actAltern.NumZone
            LZ(I) = CInt((actAltern.LunghZona(I) + 0.001) * 10)
            LF1 = LF1 + LZ(I)
        Next
        LF = CInt((actAltern.LunghezzaFascio + 0.001) * 10)
        LZ(actAltern.NumZone) += LF * actAltern.NumTotPassi - LF1
        Dati.RZ(54, NZ) = 0
        NPAS = 1
        LEN1 = 0
107:    LEN2 = LZ(NZ) - LEN1
108:    If (LEN2 > LF) Then GoTo 112
        GoTo 122
112:    Dati.RZ(54, NZ) = Dati.RZ(54, NZ) + _
            FSURF(actAltern.DiaTubo(actAltern.TipoTubi(NZ)), actAltern.LunghFascioEff, _
            actAltern.Nfile(NPAS), Dati.R(66 + actAltern.TipoTubi(NZ))) * actPRV.FrazPassoHor
        LEN2 = LEN2 - LF
        NPAS = NPAS + 1
        If (Npas < actAltern.NumTotPassi) Then GoTo 108
        'WRITE(1,2020)2
        'C      GO TO 900                                                    
        '           CLOSE(1)
        Exit Sub 'Return
122:    CLEN2 = LEN2
        CLEN2 = CLEN2 / 10
        Dati.RZ(54, NZ) += FSURF(actAltern.DiaTubo(actAltern.TipoTubi(NZ)), CLEN2, _
          actAltern.Nfile(NPAS), Dati.R(66 + actAltern.TipoTubi(NZ))) * actPRV.FrazPassoHor
        LEN1 = LF - LEN2
123:    If (LEN1 < 0) Then GoTo 132
        If (NZ < actAltern.NumZone) Then GoTo 125
        '    WRITE(1,2020)3
        'C      GO TO 900                                                  
        '               CLOSE(1)
        Exit Sub '              Return
125:    NZ = NZ + 1
        Dati.RZ(54, NZ) = 0
        If (LZ(NZ) > LEN1) Then GoTo 137
        Dati.RZ(54, NZ) += FSURF(actAltern.DiaTubo(actAltern.TipoTubi(NZ)), actAltern.LunghZona(NZ), _
            actAltern.Nfile(Npas), Dati.R(66 + actAltern.TipoTubi(NZ))) * actPRV.FrazPassoHor
        LEN1 = LEN1 - LZ(NZ)
        GoTo 123
137:    CLEN1 = LEN1
        CLEN1 = CLEN1 / 10
        Dati.RZ(54, NZ) += FSURF(actAltern.DiaTubo(actAltern.TipoTubi(NZ)), CLEN1, _
            actAltern.Nfile(NPAS), Dati.R(66 + actAltern.TipoTubi(NZ))) * actPRV.FrazPassoHor
        NPAS = NPAS + 1
        If (NPAS < actAltern.NumTotPassi) Then GoTo 107
        '    WRITE(1,2020)4
        '	WRITE(1,2021)NZ,FLOAT(LZ(NZ))/10.,FLOAT(LEN1)/10.
        '               CLOSE(1)
        Exit Sub '              Return
132:    If (NZ > actAltern.NumZone) Then GoTo 140
        LEN1 = 0
        NPAS = NPAS + 1
        NZ = NZ + 1
        Dati.RZ(54, NZ) = 0
        GoTo 107
140:    NPAS = 1
        CLEN1 = 0
        CLEN2 = 0
        actAltern.ChiaveCondens = 0
        For I = 1 To actAltern.NumZone
            If (KCALC(I) <> 0) Then actAltern.ChiaveCondens = 1
            Dati.RZ(55, I) = Dati.RZ(54, I) / 0.2618 / actAltern.DiaTubo(actAltern.TipoTubi(I)) _
                / actAltern.LunghZona(I)
            CLEN1 = CLEN2
            CLEN2 = CLEN1 + actAltern.LunghZona(I)
            NP1 = CInt(CLEN1 / actAltern.LunghezzaFascio + 0.001)
            CLXN1 = CLEN1 + 0.001
            A = CLXN1 Mod actAltern.LunghezzaFascio
            If (A > 0 Or (CLEN1 > 0 And A = 0)) Then NP1 = NP1 + 1
            NP2 = CInt(CLEN2 / actAltern.LunghezzaFascio + 0.001)
            CLXN2 = CLEN2 + 0.001
            A = CLXN2 Mod actAltern.LunghezzaFascio
            If (A > 0) Then NP2 = NP2 + 1
            Dati.RZ(56, I) = 0
            If (NP1 = 0) Then NP1 = 1
            If (NP2 = 0) Then NP2 = 1
            If (actAltern.PassiOrizzontali = "YE" Or actAltern.NumTotPassi = 1) Then GoTo 170
            If (NP1 <> NP2) Then GoTo 160
            Dati.RZ(56, I) = 1
            GoTo 170
160:        U1 = 0
            U2 = 0
            U3 = 0
            For I1 = NP1 To NP2
                If (I1 = NP1) Then GoTo 165
                If (I1 = NP2) Then GoTo 166
                If (actAltern.Nfile(I1) > 0.99) Then U1 = U1 + 1
                If (actAltern.Nfile(I1) < 0.99) Then U1 = U1 + actAltern.Nfile(I1)
                GoTo 180
165:            U2 = actAltern.Nfile(I1)
                If (U2 > 1) Then U2 = 1
                GoTo 180
166:            U3 = actAltern.Nfile(I1)
                If (U3 > 1) Then U3 = 1
180:        Next i1
            U4 = 0
            CLXN1 = CLEN1 + 0.001
            CLXN2 = CLEN2 + 0.001
            If (actAltern.LunghezzaFascio - (CLXN1 Mod actAltern.LunghezzaFascio) _
                    > 0.5 * actAltern.LunghezzaFascio) Then U4 = U4 + U2
            If (CLXN2 Mod actAltern.LunghezzaFascio) > (0.5 * actAltern.LunghezzaFascio) _
                Or ((CLXN2 Mod actAltern.LunghezzaFascio) = 0 _
                And (actAltern.LunghZona(I) > actAltern.LunghezzaFascio)) _
                    Then U4 = U4 + U3
            If (U4 > 0) Then GoTo 175
            If ((actAltern.LunghezzaFascio - (CLXN1 Mod actAltern.LunghezzaFascio) + (CLXN2 Mod actAltern.LunghezzaFascio)) _
                    > (0.5 * actAltern.LunghezzaFascio)) Then U4 = U2 + U3
            If (U4 > 1) Then U4 = 1
175:        Dati.RZ(56, I) = CInt(U1 + U4 + 0.001)
            If ((U1 + U4) - Dati.RZ(56, I) > 0.001) Then Dati.RZ(56, I) += 1
170:        If (Dati.RZ(56, I) < 1) Then Dati.RZ(56, I) = 1
            Dati.RZ(57, I) = 0
            Dati.RZ(58, I) = 0
            LEN3 = CInt((CLEN1 + 0.001) * 10)
            LEN2 = CInt((CLEN2 + 0.001) * 10)
            LF = CInt((actAltern.LunghezzaFascio + 0.001) * 10)
            If (LF > 0) Then
190:            M = LEN3 Mod LF
                If M > 0 Then GoTo 212 ' 195,195,212                                                HHT11570
195:            Dati.RZ(57, I) += 1
                Dati.RZ(58, I) += 1
212:            LEN3 = LEN3 + 1
                If (LEN3 > LEN2) Then GoTo 220
                GoTo 190
            Else
                Dim Testo As String = "Attenzione: la lunghezza del fascio" + vbCrLf
                Testo = Testo + "non è stata definita."
                MessageBox.Show(Testo)
            End If
220:        CLXN1 = CLEN1 + 0.001
            CLXN2 = CLEN2 + 0.001
            If (actAltern.LunghezzaFascio > 0) Then
                '!modifica LP------------------------------------------
                LEN3 = CInt((CLEN1 + 0.001) * 10)
                If (I <> 1 And LEN3 Mod LF = 0) Then Dati.RZ(58, I) -= 1
                If (I <> actAltern.NumZone And LEN2 Mod LF = 0) Then Dati.RZ(57, I) -= 1
                '!------------------------------------------------------
                'c      IF(I.NE.1.AND.(AMOD(CLXN1,DG(62)).EQ. 0.))  
                'c     C              RZ(58,I)=RZ(58,I)-1.                       
                'c      IF(I.NE.NumZone.AND.(AMOD(CLXN2,DG(62)).EQ.0.))
                'c     C              RZ(57,I)=RZ(57,I)-1.                     
            End If
        Next I
        'C --- CALL HTRI6 ---                                                    HHT11680
        IPRAM(11) = 0
        '               C(------------------HHT11700)
9999:   ' CLOSE(83)
        'CLOSE(1)
        'Call SCRIVI7(IPRAM(3))
    End Sub
    Public Sub UPTX2(ByVal ICHI As String, ByVal IREVI As String)
        '        C(----------------------------------------------------------------------UPT00030)
        'C --- SOMMARIO PREVENTIVO                                               UPT00040
        'C --- CHIAMA SUBR: CED5,IDAY                                            UPT00040
        '       C(----------------------------------------------------------------------UPT00050)
        ' INCLUDE() 'CMN.FI'
        'CHARACTER*20 ITEM20
        ' EQUIVALENCE(IBT(19), DR)
        'EQUIVALENCE(IBDIT, ITEM20)
        'INCLUDE() 'CMN1.FI'
        'INCLUDE() 'PRINCIP.FI'
        Dim I, J As Integer
        ' IALT
        Dim K1(5) As Integer
        'Dim NLST, NITE, NITB As Integer
        Dim LOUT, KEY, NRIT, NITAN, NTAL As Integer
        Dim IAL, NRAL, NRNOT, KEI1 As Integer
        Dim QUESTION As Boolean
        Dim DR As Single
        'Dim TOT As Single
        'Dim COEF As Single
        '50    FORMAT(128A2)
        'C--------------------------------------------------------------  
        QUOTATION = actPRV.NumerProt
        ' IF (LEN_TRIM(QUOTATION).EQ.0)
        '1 WRITE(QUOTATION,'(4A1)')(NF1(I),I=1,4)
        'INQUIRE(FILE='TEX1'//PREVENT,EXIST=QUESTION)
        '   If (QUESTION) Then
        '  OPEN(2,FILE='TEX1'//PREVENT,STATUS='OLD')
        ' CLOSE(2,STATUS='DELETE')
        'End If
        'OPEN(2,FILE='TEX1'//PREVENT,STATUS='NEW')
        'C --- PRIMO RECORD DEL FILE IN IB
        '       READ(7, REC = 1)(Ib(J), J = 1, 128)
        If (actPRV.NumerItm > 0 And actPRV.NumerItm < 100) Then GoTo 110
        'Write(2, 1135)(NF1(J), J = 1, 4)
        '1135  FORMAT (//,' >>> IL PREVENTIVO ',4A1,' NON HA ITEMS |',//)        UPT00480
        Exit Sub 'GoTo 390
110:    ICH = ICHI
        IREV = IREVI
        ICO1 = 1
        ICO2 = 1
        If (Not actPRV.UnitaMisu = "BR") Then ICO1 = 2
        If (actPRV.UnitaMisu = "SI") Then ICO2 = 2
        IPR = 0
        If (actPRV.Linguaggi = "IT") Then IPR = 1
        If (actPRV.Linguaggi = "FR") Then IPR = 2
        'C --- LETTURA FILE SUMRYF (UNIT 8)
        NRF = 1 + 2 * IPR
        'C!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ' OPEN (8,RECL=642,FORM='FORMATTED',ACCESS='DIRECT',MODE='READ',
        '1    FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\SUMRYF.DAT')
        'C AGGIUNTO 2
        '500   FORMAT(160A4)
        '       READ(8, FMT = 500, REC = NRF)(IFMT1(J), J = 1, 160)
        '      READ(8, FMT = 500, REC = NRF + 1)(IFMT2(J), J = 1, 160)
        IFMT1 = FormatStringa(10 + NRF)
        IFMT2 = FormatStringa(10 + NRF + 1)
        '     CLOSE(8)
        'C --- LETTURA FILE SUMRYF (UNIT 8)
        IPR = IPR + 1
        For I = 1 To NumIt 'IBI(43)                                                UPT00800
            NR = I * 2
            Dati.IALT(I) = 0
            '      OPEN(1,FILE='TEXT'//PREVENT,STATUS='OLD')
            'C --- DATI GENERALI ITEM IN IBDIT
            '        READ(7, REC = NR)(IBDIT(J), J = 1, 128)
            '        READ(7, REC = NR + 1)(IBT(J), J = 1, 128)
            KTOT = 0
            KOD = 0
            For I1 = 1 To 5
                K1(I1) = 0
                If actItem.ChiaveVali(I1) <> 1 Then GoTo 115 '(IBDITI(118 + 2 * I1) <> 1) Then GoTo 115
                K1(I1) = I1
                KOD = I1
                KTOT = KTOT + 1
115:        Next '      Continue Do
120:        '     Continue Do
            If (KTOT <> 1) Then GoTo 121
121:        Dati.IALT(I) = ActivAlt(Disposiz.jcont(I)) 'READ(1,51)
            '51:         Format(BN, I6)
122:        If (Dati.IALT(I) < 1 And Dati.IALT(I) > 5) Then GoTo 123
            Dati.NLST(I) = 2
            If (actItem.ChiaveVali(Dati.IALT(I)) <> 1) Then GoTo 100
            'C --- DATI ALTERNATIVA ITEM IN NIBDIT
            ' INRA = 117 + 2 * Dati.IALT(I)
            ' NRA = IBDITI(INRA)
            ' Call LEGGI7(NRA)
            actAltern = actItem.Alterns(Dati.IALT(I))
            'C ---
            If (actAltern.NumFasciStacked > 0) Then Dati.NLST(I) = actAltern.NumFasciStacked + 1
            GoTo 100
123:        '   WRITE(2,1190) Dati.IALT(I)                                   
            '1190  FORMAT(' >>> ALT.',I5,' INACCETTABILE |')                         UPT01110
            MessageBox.Show(" >>>ALT." + Dati.IALT(I).ToString + " INACCETABILE")
            GoTo 120
100:    Next I
        'C    ESCE CON Dati.IALT(I)
        '       C(---------------------N.BANCHI)
125:    '    Continue Do
        '  READ(1,*) NB
        NB = NumB
        If (NB < 1 Or NB > 30) Then Exit Sub 'GoTo 390
        'C-     ITEMS NEL BANCO -------------------------
        For I = 1 To 101
            Dati.NITE(I) = 0
        Next
        For I = 1 To NB
            Dati.NITB(I) = 0
            I1 = 1
            If (I > 1) Then I1 = Dati.NITB(I - 1) + 1
            If (I1 > 100) Then GoTo 150
135:        'Continue Do
            ' READ(1,*) (NITE(J),J=I1,100)
            For J = I1 To 100
                Dati.NITE(J) = Disposiz.jcont(NITEF(J))
            Next J
            For I1 = 1 To 101
                If (Dati.NITE(I1) <> 0) Then GoTo 139
                Dati.NITB(I) = I1 - 1
                Exit For 'GoTo 141
139:            If (Dati.NITE(I1) < actPRV.NumerItm) Then GoTo 140
                ' WRITE(2,1215) NITE(I1)                           
                '1215  FORMAT (' >>> ITEM POSIZ.',I4,' IMPOSSIBILE |')                   UPT01350
                MessageBox.Show(">>> ITEM POSIZ.")
                Dati.NITB(I) = 0
                Exit For
140:        Next I1
            '141:    Continue Do
            If (Dati.NITB(I) = 0) Then GoTo 135
150:    Next I
        'C ESCE CON NITB E NITE
        Call SCRSOM()
        '        Return
        '390:    CLOSE(2)
        '        Return
    End Sub
    Private Sub SCRSOM()
        Dim REALN As Single
        'C--------------------------------------------------------------
        '        !DEC$(OPTIONS / ALIGN = COMMONS = STANDARD)
        '      COMMON /CHX/ IPRAW(5),LOUT,DATE,ICAL,NAM1,IPRE,NWPRE,IRISQ,MISUNI
        '     1 ,KEY,NRIT,NITAN,NTAL,IAL,NRAL,NRNOT,KEI1,NFAN,ITEM1,QUOTATION
        '        DIMENSION(KEY(10), NRIT(100), NITAN(100), NTAL(100), IAL(5), UPT00110)
        '        C(NRAL(5, 100), NRNOT(5, 100), KEI1(5, 100))
        '      CHARACTER*1 DATE(10),ICAL,NFAN
        '      CHARACTER*2 IPRAW,NAM1(3),IPRE(4),NWPRE(3),IRISQ,MISUNI,ITEM1(10)                                UPT00080
        '      CHARACTER*8 QUOTATION
        '      CHARACTER*10 DATBIG
        '      INTEGER*2 IPRAWI(5)
        '      EQUIVALENCE (DATE,DATBIG),(IPRAW,IPRAWI)
        '        C(----------------------------------------------------------------------UPT00160)
        '      COMMON/CHX1/ICH,IREV,IFO1,IFO2,IFO3,IT1,IT2,ISEE,ISECT,IBAY,
        '     1            IFAN,MIS1,MIS2,ISTCO,ITEMDU,IBUF1,IBUF2,IFMT1,IFMT2,
        '2:      Ialt, K1, NITE, NITB, TOT, ITOT, NLST, N1, COEF, BANCO
        '      DIMENSION IALT(100),K1(5),NITE(101),NITB(30),TOT(7,2),ITOT(7,2),
        '        C(NLST(100), N1(4), COEF(2, 2))
        '      CHARACTER*2 ICH,IREV,IFO1(58),IFO2(58),IFO3(58),
        '     C            IT1(7,3),IT2(7,3),ISEE(7,3),ISECT(5,3),
        '     C            IBAY(5,3),IFAN(5,3),MIS1(2,2),MIS2(2),ISTCO(2,2,3),
        '        C(ITEMDU(10, 70), IBUF1(17), IBUF2(17))
        '      CHARACTER*4 IFMT1(160),IFMT2(160),BANCO(30)
        '      CHARACTER*20 FORMADU(70)
        '      INTEGER*2 IBUF1I(17),IBUF2I(17)
        '      EQUIVALENCE(IBUF1,IBUF1I),(IBUF2,IBUF2I)
        '        EQUIVALENCE(ITEMDU, FORMADU)
        '      COMMON/CHXLOC/NALT,ICO1,ICO2,IPR,NRF,KTOT,KOD,NL,
        '     1  INRA,NRA,NB,IA,IM,IG,KBEN,NROW,NRCD,IDG62,NGM,NUNI,NROS,
        '     2  N2,NTPAG,NR5,NR6,NWD,I1,DROP,KITE,ASP,NREAL,NPAG,NCALC,NR,
        '     2  MRESTO,W,KK,NTOIT,K2,I2,IDG43,IDG58,LUNG,IK,
        '3:      NR1, J1, IK1, FORMATO, PASSERELLE, SLOPE, FORZIND
        '      INTEGER*2 IA,IG,IM,NALT,ICO1,ICO2,IPR,NRF,KTOT,KOD,NL,INRA,NRA,NB
        '	INTEGER*2 KBEN,NROW,NRCD,IDG62,NGM,NUNI,NROS,N2,NTPAG,NR5,NR6,NWD
        '	INTEGER*2 I1,KITE,NREAL,NPAG,NCALC,NR,MRESTO,KK,NTOIT,K2,I2
        '	INTEGER*2 IDG43,IDG58,LUNG,IK,NR1,J1,IK1
        '     REAL*4 DROP,ASP,W
        '    CHARACTER*20 FORMATO
        '   CHARACTER*32 PASSERELLE
        '  CHARACTER*16 SLOPE
        ' CHARACTER*7 FORZIND
        '!DEC$ END OPTIONS
        '       C(----------------------------------------------------------------------UPT00100)
        '       INCLUDE() 'CMN.FI'
        '    CHARACTER*20 ITEM20
        '     EQUIVALENCE(IBT(19), DR)
        '    EQUIVALENCE(IBDIT, ITEM20)
        '   INCLUDE() 'CMN1.FI'
        'C-----------------------------------------------------------------------
        '       INCLUDE() 'PRINCIP.FI'
        Dim DR As Single
        'dim TOT as single
        Dim I, J, LOUT, IS_Renamed, NRIT, NITAN As Integer
        Dim NTAL, IAL, NRAL, NRNOT, KEI1, K1, KEY As Integer
        '       C(----------------------------------------------------------------------HHT02790)
        For I = 1 To NB
            '142   READ(1,143)BANCO(I)
            BANCO(I) = BankR(I)
        Next I
        '143:    Format(A4)
        '       CLOSE(1)
        Call NOPAG(NTPAG, Dati.NLST, Dati.NITB, NB, Dati.NITE, 1)
        ' Call GETDAT(IA, IM, IG)
        DatBig = Format(Now, "dd-MM-yy")
        'WRITE(DATBIG,'(I2,1H-,I2,1H-,I4)')IG,IM,IA
        KBEN = 0
        nPag = 1
        Dim File As String = "Tex1" & actPRV.NomeFile
        Dim sw As IO.StreamWriter = New IO.StreamWriter(File, False)
        sw.WriteLine(FormatStringa(2050))
        sw.WriteLine(String.Format(FormatStringa(2002), NB))
        sw.WriteLine(String.Format(IFMT1, DatBig, _
          ICH, nPag, NTPAG, QUOTATION, IREV, actPRV.NomeClien, actPRV.LuogoImpi, _
          MIS1(1, ICO1), MIS1(2, ICO1), MIS2(ICO2), MIS2(ICO2)))
        sw.WriteLine(String.Format(FormatStringa(2001), IFO1))
        sw.WriteLine(String.Format(FormatStringa(2001), IFO3))
        NL = 17
        '2001  FORMAT (5X,'|',11A2,'|',5A2,'|',9A2,'|',9A2,'|',4A2,'|',6A2,A1,  
        '1:      '|',9A2,'|',3A2,A1,'|')                                       
        '2002  FORMAT(5X,'TOTAL NUMBER OF BANKS:',I3)
        For I = 1 To 2
            For I1 = 1 To 7
                Dati.TOT(I1, I) = 0.01
            Next I1
175:    Next I
        'C --- SOMMARIO AIRCOOLERS ---
        For I = 1 To NB
            I1 = 1
            If (I > 1) Then I1 = NITB(I - 1) + 1
            'C --- LOOP BANCHI ---
            For I2 = I1 To NITB(I)
                'NR = NITE(I2) * 2
                'C --- DATI GENERALI ITEMS IN IBDIT
                actItem = actPRV.Items(NITE(I2))
                'READ(7, REC = NR)(IBDIT(J), J = 1, 128)
                'READ(7, REC = NR + 1)(IBT(J), J = 1, 128)
                PASSERELLE = rmHelpStrings.GetString("ARCH18_" + GlobalRoutines.Str2Cifre(actItem.codPasserelle))
                'OPEN(13,RECL=34,FORM='FORMATTED',ACCESS='DIRECT',MODE='READ',
                ' $      FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\ARCH18.DAT',
                ' $      STATUS='OLD')
                'c libr.arch18 per codice passerelle; codice IBDITI(53)
                ' READ(13,'(A32)',REC=IBDITI(53))PASSERELLE
                'CLOSE(13)
                'C ---
                If (I2 = 1) Then GoTo 180
                For J = 1 To I2 - 1
                    If (NITE(J) <> NITE(I2)) Then GoTo 210
                    If (KBEN = 0) Then GoTo 176
                    ' For IK = 1 To 10
                    '               IBDIT(IK) = ITEMDU(IK, I2)
                    '               Next IK
                    actItem.Sigla = ITEMDU(I2)
                    Exit For
176:                LUNG = ITEMDU(I2).Trim.Length 'ITEM20
                    If (LUNG > 17) Then LUNG = 17
                    ' WRITE(FORMATO,1220)LUNG/2
                    FORMATO = String.Format(FormatStringa(1220), LUNG / 2)
                    '1220  FORMAT('(',I2,'A2,1H/,I2)')
                    '  For IK = 1 To 10
                    '                ITEMDU(IK, I2) = IBDIT(IK)
                    '     Next IK
                    ITEMDU(I2) = actItem.Sigla
                    'For IK1 = 1 To LUNG / 2
                    'FORMADU(I2) += String.Format(FORMATO, IBDIT(IK1)) '????????????
                    'Next
                    ' WRITE(FORMADU(I2),FORMATO)(IBDIT(IK1),IK1=1,LUNG/2),I2
                    '                   For IK = 1 To 10
                    '                    IBDIT(IK) = ITEMDU(IK, I2)
                    ' Next IK
                    actItem.Sigla = ITEMDU(I2)
                    Exit For
210:            Next J
180:            NALT = Dati.IALT(NITE(I2))
                If actItem.ChiaveVali(NALT) = 1 Then GoTo 220
                sw.WriteLine(String.Format(FormatStringa(2010), NITE(I2), actItem.Sigla))
                If (I2 <> NITB(I)) Then sw.WriteLine(IFO2, "\par ")
                If (I2 = NITB(I)) Then sw.WriteLine(IFO1, "\par")
                '2010  FORMAT (3X,I2,'| ',10A2,' |',10X,'|',18X,'|',18X,'|',
                '    1       8X,'|',13X,'|',18X,'|',7X,'|')                             UPT01840
                NL = NL + 2
                GoTo 185
220:            ' NR = IBDITI(117 + 2 * NALT)
                'C --- DATI ALTERNATIVA ITEM IN NIBDIT
                'Call LEGGI7(NR)
                actAltern = actItem.Alterns(NALT)
                ' IF(NIBDIT(2)(2:2).EQ.'F') THEN
                If actAltern.TipoUnita.Substring(1, 1) = "F" Then
                    FORZIND = "FORCED"
                Else
                    FORZIND = "INDUCED"
                End If
                '                   C(PASSO = DT(2, 1))
                '                   C(NPASSI = NBDITI(7))
                '                   C(NROW)
                '                  C(NBOCHIN = NBDITI(8))
                '                  C(NBOCHOUT = NBDITI(9))
                '                  C(FIBOCHIN = DG(60))
                '                  C(FIBOCHOUT = DG(59))
                'C CODICE SLOPE NBDITI(20)
                'C ---
                actAltern.HPmotor = CInt(actAltern.HPmotor * COEF(2, ICO2) * 10 + 0.5) / 10
                actAltern.HPFan = CInt(actAltern.HPFan * COEF(2, ICO2) * 10 + 0.5) / 10
                actAltern.SupLisciaTot = CInt(actAltern.SupLisciaTot * COEF(1, ICO1) * 10 + 0.5) / 10
                NROW = actAltern.NumFile(1) + actAltern.NumFile(2)
                NROS = NROW
                If (actAltern.NumFasciStacked > 1) Then NROS = actAltern.NumRowsTopB
                If (NROS = 0) Then NROS = actAltern.NumFile(1)
                W = 1 / actAltern.NumUnit * actAltern.NumFasciParall
                W = W * actAltern.LarghezzaFascio
                W = CInt(W * 2 + 0.5) / 2
                If (actAltern.codAsterisco <> "* " Or actAltern.switchFasciAccoppiati = 1) Then GoTo 230
                W = actAltern.WidthMFVC
                NROW = actAltern.NumFileUnitaAccopp
                If (actAltern.SwitchScriviVent = 1) Then GoTo 230
                NRCD = actPRV.NumerItm ' NBDITI(43)
                'READ(7, REC = NRCD)(ITEM1(J), J = 1, 10)
                'REALN = LunghFascio
                IDG62 = Int(REALN)
                sw.WriteLine(String.Format(FormatStringa(2020), NITE(I2), actItem.Sigla, _
                               actAltern.SupLisciaTot, actAltern.NumFasciParall, _
                               actAltern.LarghezzaFascio, _
                               IDG62, NROS, ISEE(IPR), actPRV.Items(NRCD).sigla))
                '      sw.WRITEline(string.format(formatstringa(2020), NITE(I2),(IBDIT(J),J=1,10),_
                'SupLisciaTot, NumFasciParall, LarghFascio, _
                'IDG62,NROS,(ISEE(J,IPR),J=1,7),(ITEM1(J),J=1,10)))
                Dati.N1(1) = actAltern.NumFasciStacked
                If (Dati.N1(1) = 2 And NROS = actAltern.NumFile(1)) Then
                    Dati.N1(3) = actAltern.NumFile(2)
                Else
                    Dati.N1(2) = actAltern.NumRowsTopB
                    Dati.N1(3) = actAltern.NumRowsMediumB
                    Dati.N1(4) = actAltern.NumRowsBottomB
                End If
                N2CHXLOC = actAltern.NumFasciParall
                Call STAKD(Dati.N1, N2CHXLOC, actAltern.LarghezzaFascio, actAltern.LunghezzaFascio, _
                           TOT(2, 1), TOT(2, 2), sw)
                If (I2 <> NITB(I)) Then sw.WriteLine(String.Format(FormatStringa(2001), IFO2)) ' (IFO2(J),J=1,58)     
                If (I2 = NITB(I)) Then sw.WriteLine(String.Format(FormatStringa(2001), IFO1))
                NL = NL + NLST(NITE(I2))
                For J = 1 To 2
                    TOT(1, J) = TOT(1, J) + actAltern.SupLisciaTot
                    TOT(2, J) = TOT(2, J) + actAltern.NumFasciParall
                    REALN = TOT(2, J)
                    ITOT(2, J) = Int(REALN)
                Next
                GoTo 185
230:            REALN = actAltern.NumUnit + 0.01
                NUNI = Int(REALN)
                '                C(RNUNI = DG(64) + 0.01)
                If (actAltern.codAsterisco = "* ") Then
                    If (actAltern.switchFasciAccoppiati = 1 And _
                       (actAltern.NumUnit Mod 1) = 0) Then NUNI = NUNI - 1
                End If
                'C --- SOSTITUISCE CED3
                'C231   NFAN=NIBDIT(2)(1:1)
                'C(NGM = ICHAR(NFAN) - 240)
                NGM = CInt(actAltern.TipoUnita.Substring(0, 1))
                '231   READ(NIBDIT(2),'(I1,1X)')NGM
                'C!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                'C --- SOSTITUISCE CED3
                If (NGM > 7) Then NGM = 0
                actAltern.NtotVentilatori = NUNI * NGM
                actAltern.HPfan = actAltern.HPfan * actAltern.NtotVentilatori
                REALN = actAltern.NtotVentilatori
                IDG43 = Int(REALN)
                REALN = actAltern.DiaVent
                IDG58 = Int(REALN)
                REALN = actAltern.LunghezzaFascio
                IDG62 = Int(REALN)
                sw.WriteLine(String.Format(FormatStringa(2030), NITE(I2), actItem.Sigla, _
                             actAltern.SupLisciaTot, _
                             actAltern.NumFasciParall, actAltern.LarghezzaFascio, _
                             IDG62, NROS, actAltern.NumUnit, W, IDG62, NROW, actAltern.HPfan, _
                             IDG43, actAltern.HPmotor, IDG43, IDG58, actAltern.NumPale, _
                             actAltern.TipoPale, actAltern.PerCentoAV))
                N1(1) = actAltern.NumFasciStacked
                If (N1(1) = 2 And NROS = actAltern.NumFile(1)) Then
                    N1(3) = actAltern.NumFile(2)
                Else
                    N1(2) = actAltern.NumRowsTopB
                    N1(3) = actAltern.NumRowsMediumB
                    N1(4) = actAltern.NumRowsBottomB
                End If
                N2CHXLOC = actAltern.NumFasciParall
                Call STAKD(N1, N2CHXLOC, actAltern.LarghezzaFascio, _
                           actAltern.LunghezzaFascio, TOT(2, 1), TOT(2, 2), sw)
                If (I2 <> NITB(I)) Then sw.WriteLine(String.Format(FormatStringa(2001), IFO2)) ' (IFO2(J),J=1,58)     
                If (I2 = NITB(I)) Then sw.WriteLine(String.Format(FormatStringa(2001), IFO1))
                NL = NL + NLST(NITE(I2))
                'C --- TOTALI ---
                For J = 1 To 2
                    TOT(1, J) = TOT(1, J) + actAltern.SupLisciaTot
                    TOT(2, J) = TOT(2, J) + actAltern.NumFasciParall
                    TOT(3, J) = TOT(3, J) + actAltern.NumUnit
                    TOT(4, J) = TOT(4, J) + actAltern.HPfan
                    TOT(5, J) = TOT(5, J) + actAltern.NtotVentilatori
                    TOT(6, J) = TOT(6, J) + actAltern.HPmotor * actAltern.NtotVentilatori
                    TOT(7, J) = TOT(7, J) + actAltern.NtotVentilatori
                Next J
                For J = 1 To 2
                    For J1 = 1 To 7
                        REALN = TOT(J1, J)
                        ITOT(J1, J) = Int(REALN)
                    Next J1
                Next J
                'C ---
185:            If (NL < 58 Or I2 = NITB(I)) Then GoTo 190
                sw.WriteLine(FormatStringa(2050))
                '2050  FORMAT (1H1)                                                     
                nPag = nPag + 1
                sw.WriteLine(String.Format(IFMT1, DatBig, ICH, nPag, NTPAG, QUOTATION, _
                           IREV, actPRV.NomeClien, actPRV.LuogoImpi, _
                           MIS1(1, ICO1), MIS1(2, ICO1), MIS2(ICO2), MIS2(ICO2)))
                sw.WriteLine(String.Format(FormatStringa(2001), IFO1))
                sw.WriteLine(String.Format(FormatStringa(2001), IFO3))
                NL = 15
190:        Next
            sw.WriteLine(String.Format(FormatStringa(2060), IT1(IPR), TOT(1, 1), ITOT(2, 1), _
                ISECT(IPR), ITOT(3, 1), IBAY(IPR), TOT(4, 1), ITOT(5, 1), _
                TOT(6, 1), ITOT(7, 1), IFAN(IPR)))
            'C      WRITE(2,2061)FORZIND,PASSERELLE
            sw.WriteLine(String.Format(FormatStringa(2061), I, BANCO(I)))
            sw.WriteLine("\par      " & New String("=", 132))
            If (I = NB Or NL >= 55) Then GoTo 192
            sw.WriteLine(IFO2, "\par ")
            NL = NL + 4
192:        For J = 1 To 7
                TOT(J, 1) = 0.01
                If (I = NB And NL < 61) Then GoTo 200
            Next J
            If (NL < 55) Then GoTo 200
            sw.WriteLine(FormatStringa(2050))
            nPag = nPag + 1
            sw.WriteLine(String.Format(IFMT1, DatBig, ICH, nPag, NTPAG, QUOTATION, _
                       IREV, actPRV.NomeClien, actPRV.LuogoImpi, _
                       MIS1(1, ICO1), MIS1(2, ICO1), MIS2(ICO2), MIS2(ICO2)))
            sw.WriteLine(String.Format(FormatStringa(2001), IFO1))
            sw.WriteLine(String.Format(FormatStringa(2001), IFO3))
            NL = 15
200:    Next I
        sw.WriteLine(String.Format(FormatStringa(2001), IFO1))
        sw.WriteLine(String.Format(FormatStringa(2060), IT2(IPR), TOT(1, 2), ITOT(2, 2), _
            ISECT(IPR), ITOT(3, 2), IBAY(IPR), TOT(4, 2), ITOT(5, 2), _
            TOT(6, 2), ITOT(7, 2), IFAN(IPR)))
        sw.WriteLine("\par      " & New String("=", 132))
        'C --- SOMMARIO CONTROLLI ---
        sw.WriteLine(FormatStringa(2050))
        Call NOPAG(NTPAG, NLST, NITB, NB, NITE, 0)
        nPag = 1
        sw.WriteLine(String.Format(IFMT2, DatBig, ICH, nPag, NTPAG, QUOTATION, _
                   IREV, actPRV.NomeClien, actPRV.LuogoImpi))
        sw.WriteLine(String.Format(FormatStringa(3001), IFO1))
        sw.WriteLine(String.Format(FormatStringa(3001), IFO3))
        NL = 15
        For I = 1 To NB
            I1 = 1
            If (I > 1) Then I1 = NITB(I - 1) + 1
            For I2 = I1 To NITB(I)
                ' NR = NITE(I2) * 2
                'C --- DATI GENERALI ITEM IN IBDIT                                 
                actItem = actPRV.Items(NITE(I2))
                ' READ(7, REC = NR)(IBDIT(J), J = 1, 128)
                'READ(7, REC = NR + 1)(IBT(J), J = 1, 128)
                '                C(-----------aggiunta)
                NALT = Dati.IALT(NITE(I2))
                'NR1 = IBDITI(117 + 2 * NALT)
                'C --- DATI ALTERNATIVA ITEM IN NIBDIT
                'Call LEGGI7(NR1)
                actAltern = actItem.Alterns(NALT)
                NROW = actAltern.NumFile(1) + actAltern.NumFile(2)
                '                 C(----------aggiunta)
                If (I2 = 1) Then GoTo 680
                For J = 1 To I2 - 1
                    If (NITE(J) <> NITE(I2)) Then GoTo 710
                    'For IK = 1 To 10
                    'IBDIT(IK) = ITEMDU(IK, I2)
                    'Next IK
                    actItem.Sigla = ITEMDU(I2)
                    Exit For
710:            Next J
680:            actItem.Automatico = 0 '"  " 'IBDIT(115)='  '                                             
                '    IF (IBDIT(114) .EQ. 'YE') IBDIT(115)='S '           
                If (actItem.SteamCoil = "YE") Then actItem.SteamCoil = "S "
                KOD = (IPR - 1) * 20 + 22
                NR5 = actItem.codPersiane 'IBDITI(58)
                Call CED5(KOD, NR5, LOUT, IBUF1, NWD)
                KOD = (IPR - 1) * 20 + 21
                NR6 = actItem.codRicircolo 'IBDITI(57)
                Call CED5(KOD, NR6, LOUT, IBUF2, NWD)
                IS_Renamed = 1
                Dim CodSlope As Integer = 2 ' ATTENZIONE
                If (actItem.SteamCoil = "NO" Or actItem.SteamCoil = "  ") Then IS_Renamed = 2
                'OPEN(13,RECL=18,FORM='FORMATTED',ACCESS='DIRECT',MODE='READ',
                '$      FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\ARCH25.DAT',STATUS='OLD')
                '3032 READ(13,'(A16)',REC=CodSlope,ERR=3031)SLOPE
                '              GoTo 3033
                '3031:           CodSlope = 2
                '               GoTo 3032
                '3033:           CLOSE(13)
                SLOPE = rmHelpStrings.GetString("ARCH25_" + GlobalRoutines.Str2Cifre(CodSlope))
                'sw.WriteLine(String.Format(FormatStringa(3030), actItem.Sigla, IBUF1, _
                '            ISTCO(IS_Renamed, IPR), IBUF2, DT(2, 1), actAltern.NumTotPassi, _
                '           NROW, actAltern.NbocIn, actAltern.DBocchIn, actAltern.NBocOut, _
                '           actAltern.DbocchOut, SLOPE))
                sw.WriteLine(String.Format(FormatStringa(3030), actItem.Sigla, IBUF1, _
                          ISTCO(IS_Renamed, IPR), IBUF2, actAltern.Passo(1), actAltern.NumTotPassi, _
                         NROW, actAltern.NbocIn, actAltern.DBocchIn, actAltern.NBocOut, _
                         actAltern.DbocchOut, SLOPE))
                sw.WriteLine(String.Format(FormatStringa(3001), IFO2))
                NL = NL + 2
                If (NL < 58) Then GoTo 690
                sw.WriteLine(FormatStringa(2050))
                nPag = nPag + 1
                sw.WriteLine(String.Format(IFMT2, DatBig, ICH, nPag, NTPAG, QUOTATION, _
                           IREV, actPRV.NomeClien, actPRV.LuogoImpi))
                sw.WriteLine(String.Format(FormatStringa(3001), IFO1))
                sw.WriteLine(String.Format(FormatStringa(3001), IFO3))
                NL = 15
690:        Next I2
            sw.WriteLine(String.Format(FormatStringa(2061), I, BANCO(I)))
            If (I <> NB) Then sw.WriteLine(String.Format(FormatStringa(3001), IFO2))
            NL = NL + 3
            If (I = NB) Then GoTo 700
            If (NL < 55) Then GoTo 700
            sw.WriteLine(FormatStringa(2050))
            nPag = nPag + 1
            sw.WriteLine(String.Format(IFMT2, DatBig, ICH, nPag, NTPAG, QUOTATION, _
                       IREV, actPRV.NomeClien, actPRV.LuogoImpi))
            sw.WriteLine(String.Format(FormatStringa(3001), IFO1))
            sw.WriteLine(String.Format(FormatStringa(3001), IFO3))
            NL = 15
700:    Next I
        '390:    Continue Do
        '391:    Continue Do
        '300:    CLOSE(2)
        '  Return
        ' C(Write(L, 1230))
        '1230 FORMAT (/,' *** UPTX (SOMMARIO) TERMINATO ***')     
        ' 2020 FORMAT (3X,I2,'| ',10A2,' |',F9.1,' | (',I3,')',
        '     1       F6.2,'-',2I2,' | ',7A2,1X,                               
        '     1       10A2,5X,'|',18X,'|',7X,'|')                              
        '2030 FORMAT (3X,I2,'| ',10A2,' |',F9.1,' | (',I3,')',
        '    1       F6.2,'-',2I2,' | (',F4.1,')',                              UPT02310
        '    1       F5.1,'-',2I2,' |',F7.1,' | (',I3,')',F6.1,                 UPT02320
        '1:                                                          ' | (',I3,')',I3,'-',I2,'/',                               UPT02320
        '    2       2A2,' |',I6,' |')                                          UPT02330
        'c2061  FORMAT(5X,'NOTES. KIND OF DRAFT: ',A7,'; WALKWAYS: ',A32'.')
        '2061 FORMAT(5X,'NOTES: BANK POS.:',I2,';BANK ID.:',A4/)
        '2060 FORMAT (5X,'|  *****',7A2,' |',F9.1,' | (',I3,') ',            
        '   1     5A2,' | (',I4,') ',5A2,                                    
        '     '|',F7.1,' | (',I3,')',F6.1,' | (',I3,') ',5A2,' |',7X,'|',  
        ' 2     /,5X,123('='))
        '3001 FORMAT (5X,'|',11A2,'|',8A2,'|',4A2,'|',10A2,'|',7A2,'|',3(5A2,'=|'))
        '3002 FORMAT (5X,'|',11A2,'|',8A2,'|',4A2,'|',10A2,'|',7A2,'|',3(5A2,' |'))
        '3003 FORMAT (5X,'|',11A2,'|',8A2,'|',4A2,'|',10A2,'|',7A2,'|',3(5A2,'-|'))
        '3030 FORMAT (5X,'| ',10A2,' |  ',6A2,'  |  ',
        '    1 2A2,'  |  ',8A2,'  |',F6.2,I3,I3,'  |',
        '    $ 2(I2,F7.2,'  |'),2X,A8' |')
    End Sub
    ' C(--------------------------------------------------------------UPT03590)
    Sub NOPAG(ByRef NTPAGS As Integer, ByVal NLSTS() As Integer, ByVal NITBS() As Integer, _
              ByVal NBS As Integer, ByVal NITES() As Integer, ByVal K As Integer)
        'INTEGER*2 NLSTS(100),NITBS(30),NITES(100)
        Dim NL, I, I1, I2 As Integer
        NTPAGS = 1
        ' c(NL = 15)
        NL = 17
        For I = 1 To NBS
            '     C(aggiunta)
            NL = NL + 1
            I1 = 1
            If (I > 1) Then I1 = NITBS(I - 1) + 1
            For I2 = I1 To NITBS(I)
                If (K = 0) Then NL = NL + 2
                If (K = 1) Then NL = NL + NLSTS(NITES(I2))
                If (NL < 58 Or I2 = NITBS(I)) Then GoTo 170
                NTPAGS = NTPAGS + 1
                NL = 15
170:        Next I2
            If (K = 0) Then NL = NL + 3
            If (K = 1) Then NL = NL + 4
            If (I = NBS And NL < 61) Then GoTo 160
            If (NL < 55) Then GoTo 160
            NL = 15
            NTPAGS = NTPAGS + 1
160:    Next I
        'c(CLOSE(2))
    End Sub
    Sub STAKD(ByVal N1() As Integer, ByVal N2 As Integer, ByVal R1 As Single, _
              ByVal R2 As Single, ByVal R3 As Single, ByVal R4 As Single, _
              ByVal sw As IO.StreamWriter)
        Dim J, IR2 As Integer
        Dim REALN As Single
        If (N1(1) < 2) Then Exit Sub
        REALN = R2
        IR2 = Int(REALN)
        For J = 1 To N1(1) - 1
            sw.WriteLine(String.Format(FormatStringa(2500), N2, R1, IR2, N1(J + 2)))
            R3 = R3 + N2
            R4 = R4 + N2
        Next
        '2500  FORMAT (5X,'|',22X,'|',10X,'| (',I3,')',F6.2,'-',2I2,' |',  
        '    1        18X,'|',8X,'|',13X,'|',18X,'|',7X,'|')              
    End Sub
    Private Function AGGIUSTAZONEFISSE(ByVal FACT() As Single) As Boolean
        '        INCLUDE() 'CMN.FI'
        '        INCLUDE() 'CMN1.FI'
        '        INCLUDE() 'PRINCIP.FI'
        'C----------------------------------------------------------
        'Type(SING12)
        'REAL(S(12))
        ' END TYPE
        '  Type(SING12) : FACT()
        Dim TUBMED As Single
        'C----------------------------------------------------------
        Dim I, KEYFIX, K As Integer
        '	INTEGER*4 x
        '	CHARACTER*120 DOMANDA
        Dim RISULT As Boolean
        Dim KEYACT, KEYDOPO, KEYPRIMA, NUOVAL, LLIBERA, DUMPING As Single
        Dim NUOVATEMP As Single
        'REAL*4,ALLOCATABLE::LUNGINTEGR(:)
        Dim LUNGINTEGR() As Single
        'C----------------------------------------------------------
        DUMPING = 0.5
        AGGIUSTAZONEFISSE = True
        TUBMED = 0
        For I = 1 To actAltern.NumZone
            TUBMED = TUBMED + FACT(I)
        Next
        ReDim LUNGINTEGR(actAltern.NumZone)
        LUNGINTEGR(0) = 0
10:     For I = 1 To actAltern.NumZone
            LUNGINTEGR(I) = 0
            For K = 1 To I
                LUNGINTEGR(I) = LUNGINTEGR(I) + actAltern.LunghFascioEff * FACT(I) / TUBMED '!DGZ(6,K)
            Next
        Next
        For I = 1 To actAltern.NumZone - 1
            LLIBERA = actAltern.LunghFascioEff * FACT(I) / TUBMED
            KEYFIX = CInt(actAltern.codZona(I) / 2)
            If (KEYFIX > 0) Then
                KEYACT = LUNGINTEGR(I) / actAltern.LunghezzaFascio
                KEYDOPO = LUNGINTEGR(I + 1) / actAltern.LunghezzaFascio
                If (I = 1) Then
                    KEYPRIMA = 0
                Else
                    KEYPRIMA = LUNGINTEGR(I - 1) / actAltern.LunghezzaFascio
                End If
                If (KEYFIX > KEYPRIMA And KEYFIX < KEYDOPO) Then
                    NUOVAL = CInt((actAltern.LunghezzaFascio + 0.01) * 10) / 10 * KEYFIX - LUNGINTEGR(I - 1)
                    If (I = 1) Then
                        NUOVATEMP = actPRV.TempINr + (actAltern.TempOut(I) - actPRV.TempINr) * NUOVAL / LLIBERA
                    Else
                        NUOVATEMP = actAltern.TempOut(I - 1) + _
                                    (actAltern.TempOut(I) - actAltern.TempOut(I - 1)) * _
                                    NUOVAL / LLIBERA
                    End If
                    actAltern.TempOut(I) = actAltern.TempOut(I) + _
                                           (NUOVATEMP - actAltern.TempOut(I)) * DUMPING
                    actAltern.LunghZona(I + 1) = actAltern.LunghZona(I + 1) - _
                                                  (NUOVAL - actAltern.LunghZona(I))
                    actAltern.LunghZona(I) = NUOVAL
                ElseIf (KEYFIX <= KEYPRIMA) Then
                    RISULT = SWAPZONE(I, I - 1) '!trasporto marca fissa da I a I-1
                    If (Not RISULT) Then
                        AGGIUSTAZONEFISSE = False
                        Return False
                    End If
                    GoTo 10
                ElseIf (KEYFIX >= KEYDOPO) Then
                    RISULT = SWAPZONE(I, I + 1) '!trasporto marca fissa da I a I+1
                    If (Not RISULT) Then
                        AGGIUSTAZONEFISSE = False
                        Return False
                    End If
                    GoTo 10
                End If
            End If
1:      Next
        Return True
    End Function
    Private Sub RIAGGIUSTA()
        '        INCLUDE() 'CMN.FI'
        'INCLUDE() 'CMN1.FI'
        'INCLUDE() 'PRINCIP.FI'
        'C----------------------------------------------------------
        Dim I, K, J As Integer
        Dim DELTA, LUNGINTEGR() As Single
        '	REAL*4,ALLOCATABLE::LUNGINTEGR(:)
        'C----------------------------------------------------------
        '	ALLOCATE(LUNGINTEGR(0:NumZone))
        ReDim LUNGINTEGR(actAltern.NumZone)
        LUNGINTEGR(0) = 0
        For I = 1 To actAltern.NumZone
            LUNGINTEGR(I) = 0
            For K = 1 To I
                LUNGINTEGR(I) = LUNGINTEGR(I) + actAltern.LunghZona(K)
            Next
        Next
        For I = 1 To actAltern.NumZone - 1
            J = actAltern.codZona(I) \ 2 ' Int(DGZ(8, I) / 2)
            If (J > 0) Then
                DELTA = CInt((LUNGINTEGR(I) - J * actAltern.LarghezzaFascio) * 10) / 10
                If (ABS(DELTA) > 0.05) Then
                    Select Case (I)
                        Case (1)
                            actAltern.LunghZona(1) -= DELTA '  DGZ(6, 1) = DGZ(6, 1) - DELTA
                            actAltern.LunghZona(2) += DELTA 'DGZ(6, 2) = DGZ(6, 2) + DELTA
                        Case Else
                            actAltern.LunghZona(I - 1) -= DELTA 'DGZ(6, I - 1) = DGZ(6, I - 1) - DELTA
                            actAltern.LunghZona(I + 1) += DELTA 'DGZ(6, I + 1) = DGZ(6, I + 1) + DELTA
                    End Select
                End If
            End If
        Next
    End Sub
    Private Sub DEFAULT2TIPI(ByVal FACT() As Single, ByVal ICONTR As Integer)
        'INCLUDE() 'CMN.FI'
        'INCLUDE() 'CMN1.FI'
        'INCLUDE() 'PRINCIP.FI'
        'TYPE(SING12)
        'REAL(S(12))
        'END TYPE
        ' TYPE(SING12) : FACT()
        'C(----------------------------------------------------------------------HHT08510)
        '      COMMON/FARFAR/IBDO,NP1,NP2,LEN1,LEN2,LEN3,LF,NR,NT,NZ,NPAS,
        '     1 KEYPDM,I1,M1,M2,RKEYL,U2,U3,U4,CLEN1,CLEN2,TOTLEN,RL,RLC,RO,
        '2:      RP, CLXN1, CLXN2, ROW, ROWT1, DELTAS, DELTAD, M, LZZ(3), KEYP
        '      INTEGER*2 IBDOI(16),OK,iOKPRO,NT,I1,NR,M1,M2,KEYP,LZZ'
        '	INTEGER*2 NZ,LF1,LF,NPAS,LEN1,LEN2,NP1,NP2,LEN3,M,KEYPDM
        '      CHARACTER*2 IBDO(16)
        '	REAL*4 ROW,RP,U1,U2,U3,ROWT1,TUBMED,RLC,RL,RO,TOTLEN
        '	REAL*4 RKEYL,DELTAS,DELTAD,CLEN1,CLEN2,CLXN1,CLXN2,A,U4
        '       EQUIVALENCE(IBDO, IBDOI)
        'C-------------------------------------------------------------------
        Dim I As Integer
        RKEYL = 0
        DELTAS = 0
        DELTAD = 0
        For I = 1 To actAltern.NumZone
            If (RKEYL <= RLC And (RKEYL + actAltern.LunghZona(I)) > RLC + 0.05) Then
                DELTAD = RKEYL + actAltern.LunghZona(I) - RLC
                DELTAS = RLC - RKEYL
                If (DELTAS < 0.1 Or DELTAD < 0.1) Then Exit Sub ' RETURN !GOTO83
                If (I = 1) Then
                    If actAltern.TempOut(I) = actPRV.TempINr - (actPRV.TempINr - actAltern.TempOut(I)) * DELTAS / actAltern.LunghZona(I) Then
                        actAltern.LunghZona(I) -= DELTAD 'DGZ(6, I) = DGZ(6, I) - DELTAD
                        actAltern.LunghZona(I + 1) += DELTAD 'DGZ(6, I + 1) = DGZ(6, I + 1) + DELTAD
                    ElseIf (I = actAltern.NumZone) Then
                        actAltern.LunghZona(I - 1) -= (actAltern.LunghZona(I - 1) - R(3)) * DELTAS / actAltern.LunghZona(I)
                        actAltern.LunghZona(I) -= DELTAS ' DGZ(6, I) - DELTAS
                        actAltern.LunghZona(I - 1) += DELTAS ' = DGZ(6, I - 1) + DELTAS
                    ElseIf (DELTAD > DELTAS) Then
                        actAltern.TempOut(I - 1) -= (actAltern.TempOut(I - 1) - actAltern.TempOut(I)) * _
                                                    (actAltern.LunghZona(I) - DELTAS) / actAltern.LunghZona(I)
                        actAltern.LunghZona(I) -= DELTAS ' = DGZ(6, I) - DELTAS
                        actAltern.LunghZona(I - 1) += DELTAS ' = DGZ(6, I - 1) + DELTAS
                    Else
                        actAltern.TempOut(I) -= (actAltern.TempOut(I - 1) - actAltern.TempOut(I)) * _
                                            (actAltern.LunghZona(I) - DELTAD) / actAltern.LunghZona(I)
                        actAltern.LunghZona(I) -= DELTAD = actAltern.LunghZona(I) - DELTAD
                        actAltern.LunghZona(I + 1) += DELTAD ' = DGZ(6, I + 1) + DELTAD
                    End If
                    If (actAltern.Autom = "SI") Then
                        Call AUTOM1(OK)
                    Else
                        Dim Testo As String = " Ci sono dei confini di zona fissi, ma il"
                        Testo = Testo + "calcolo delle zone non è di tipo automatico."
                        Testo = Testo + "Vuoi passare in automatico?"
                        Dim Titolo As String = "???"
                        Dim Res As DialogResult = MessageBox.Show(Testo, Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If (Res = DialogResult.Yes) Then
                            actAltern.Autom = "SI"
                            Call AUTOM1(OK)
                        End If
                    End If
                    If (actAltern.Autom = "SI" And ICONTR = 7) Then
                        FACT(1) = DELTAS
                        If (DELTAD < DELTAS) Then FACT(1) = DELTAD
                    End If
                    Exit Sub '!GOTO 83
                End If
81:             RKEYL += actAltern.LunghZona(I) '= RKEYL + DGZ(6, I)
            End If
        Next
    End Sub
    Private Function FSURF(ByVal D As Single, ByVal RL As Single, ByVal RO As Single, ByVal TU As Single) As Single
        '	REAL*4 D,RL,RO,TU
        FSURF = 0.2618 * D * RL * RO * TU
    End Function
    Sub AUTOM2(ByVal IBNEAR() As Integer)
        'c	CALL HTRI3(0,IERR)
        Dim I As Integer
        Call BILZON(1, 0)
        For I = 1 To actAltern.NumZone
591:        actAltern.codZona(I) = CSng(BITSETTA(CInt(actAltern.codZona(I)), IBNEAR(I), 0))
        Next
        Call AUTOM1(0)
    End Sub
    Sub AUTOM1(ByVal OK As Integer)
        '   INCLUDE() 'CMN.FI'
        '   INCLUDE() 'CMN1.FI'
        '   INCLUDE() 'PRINCIP.FI'
        'C----- INSRIMENTO DATI ZONE ALTERNATIVA ------------------------------- HHT02640
        '      INTEGER*2 IBNEAR(12)
        'C-----------------------------------------------------------
        '      COMMON/PRINCIQ/COEFF(21),IZ(12),IPC(61),STAM(6,12)
        '!DEC$ ATTRIBUTES DLLIMPORT::/PRINCIQ/
        '      INTEGER*2 IPC,IZ
        '        C(----------------------------------------------------------------------HHT02870)
        '      COMMON/FARFAR/NRD,KEY,KTEST,KSCOIL,KSERP,IPOS,
        '     1 KPERS,ICONTR,LIM,NZC,NREC,MODIF,NCOEFF,IRIAU,NALTOL,IDUM,
        Dim LIM, NZC As Integer
        '     2 DUTY,DUTYC,CHCL,CH2O,CHCV,CHIN,CONHC,CONHO,CONDST,CONDHC,
        '     3 TAV,T,X,DUM1,DUM2,DUM3,XIN,XOUT,XLOCIN,XLOCOUT,
        '4:      HIN, HOUT, HLOCIN, HLOCOUT, CONDMWIN, PADD1(7), NALT, LPAD(3)
        '      COMMON/HTRDU4/BNEAR
        Dim BNEAR(12) As Single
        Dim IBUF(12) As String
        '      INTEGER*2 NRD,KEY,KTEST,KSCOIL,KSERP,IDUM,NALT,LPAD
        '      INTEGER*2 KPERS,ICONTR,LIM,NZC,NREC
        '      INTEGER*2 MODIF,NCOEFF,IPOS,NALTOL,ICNEAR,I
        '	INTEGER*2 BITSETTA,IERR
        '	INTEGER*4 xMESS
        '     CHARACTER*2 IRIAU
        '    REAL*4 DUTY,DUTYC,CHCL,CH2O,CHCV,T,X,DUM1,DUM2,DUM3
        '   REAL*4 CHIN,CONHC,CONHO,CONDST,CONDHC,TAV,BNEAR(12),Y,YV
        'REAL*4 HIN,HOUT,XIN,XOUT,RETLI,FCH2O
        Dim HLOCIN, HLOCOUT, XLOCIN, XLOCOUT, XVLOCIN, XVLOCOUT, X, Y, YV As Single
        Dim CONDMWIN As Single
        ',CONDMWIN,COEFF,STAM,PADD1
        'REAL*4 XVLOCIN,XVLOCOUT,XVIN,XVOUT,DUMMY(4)
        '!DEC$ END OPTIONS
        'C----------------------------------------------------------------------
        'READ(7, REC = NRDIN + 1)(NIBDITs(I), I = 129, 256)!IB1()
        '!?????????????????
        '        GoTo 592
        '        ENTRY(AUTOM2(IBNEAR))
        'c	CALL HTRI3(0,IERR)
        '        Call BILZON(1, 0)
        '      DO 591 I=1,NumZone                                     
        '591:    DGZ(8, I) = FLOAT(BITSETTA(Int(DGZ(8, I)), IBNEAR(I), 0))
        '592:    Continue Do
        Dati.RZ(5, 1) = actPRV.TempINr '!R(2)
        NZC = 0
        LIM = 0
        If (actItem.VapHCIn + actItem.NonCondIn + actItem.SteamIn > 0) Then LIM = actAltern.NumZone
        DUTY = 0
        If (actAltern.Prinop > 0.0) Then
            HIn = RETLI(actPRV.TempINr, 1)
            HOUT = RETLI(actPRV.TempOUTr, 1)
            '!titolo ponderale fase aeriforme (RIFERITO ALLA PORTATA NETTA DALL'ACQUA LIQUIDA)
            XIN = RETLI(actPRV.TempINr, 2)
            XOUT = RETLI(actPRV.TempOUTr, 2)
            '!titolo ponderale H2O fase lquida (RIFERITO ALLA PORTATA TOTALE)
            XVIN = RETLI(actPRV.TempINr, 4) '!1.-XIN-RETLI(R(2),0.,4)
            XVOUT = RETLI(actPRV.TempOUTr, 4) '!1.-XOUT-RETLI(R(3),0.,4)
        End If
        Dim I As Integer
        For I = 1 To actAltern.NumZone
            BNEAR(I) = CSng(CInt(actAltern.codZona(I) And 1))
            '!se non è la prima la temp in è la temp out della zona precedente
            If (I <> 1) Then Dati.RZ(5, I) = actAltern.TempOut(I - 1)
            IBUF(I) = "NO"
            '!non esiste condensazione nell'apparecchio
            If (actItem.CondenHC + actItem.CondSteam = 0) Then GoTo 510
            If (BNEAR(I) = 1) Then IBUF(I) = "SI"
            If (IBUF(I) <> "SI") Then GoTo 510
            '!numero di zone condensanti
            NZC = NZC + 1
            '!indece massimo condensazione
            LIM = I
510:    Next I
        For I = 1 To actAltern.NumZone
            '!se è condensante o si lavora con la curva di raffreddamento 
            If (IBUF(I) = "SI" Or actAltern.Prinop > 0) Then GoTo 550
            TAV = (Dati.RZ(5, I) + actAltern.TempOut(I)) / 2
            CHCL = RETLI(TAV, 28)
            CH2O = FCH2O(TAV)
            CHCV = RETLI(TAV, 44)
            CHIN = RETLI(TAV, 32)
            CONHC = 0
            CONHO = 0
            actAltern.MWHCOut(I) = actPRV.MWVapHCin
            '(DGZ(3, I) = MWVapHCout)
            If (I < LIM) Then GoTo 520
            CONHC = actPRV.CondenHCr
            CONHO = actPRV.CondSteamr
            actAltern.MWHCOut(I) = actPRV.MWVapHCout
520:        actAltern.DutyZone(I) = (Dati.RZ(5, I) - actAltern.TempOut(I)) * ((CONHO + R(8)) * CH2O + (CONHC + _
               R(4)) * CHCL + (R(5) - CONHC) * CHCV + R(6) * CHIN + _
               (R(7) - CONHO) * 0.45)
            DUTY = DUTY + actAltern.DutyZone(I)
            actAltern.CondHC(I) = 0
            actAltern.CondST(I) = 0
550:    Next I
        DUTYC = R(1) - DUTY
        For I = 1 To actAltern.NumZone
            If (IBUF(I) <> "SI" And actAltern.Prinop = 0) Then GoTo 560
            If (actAltern.Prinop = 0) Then
                X = (RZ(5, I) - actAltern.TempOut(I)) / (RZ(5, LIM - NZC + 1) - actAltern.TempOut(LIM))
                Y = X
                YV = X
            Else
                HLOCIN = RETLI(RZ(5, I), 1)
                HLOCOUT = RETLI(actAltern.TempOut(I), 1)
                '!titolo ponderale fase aeriforme
                XLOCIN = RETLI(RZ(5, I), 2)
                XLOCOUT = RETLI(actAltern.TempOut(I), 2)
                XVLOCIN = RETLI(RZ(5, I), 4) '!1.-XLOCIN-RETLI(RZ(5,I),0.,4)
                XVLOCOUT = RETLI(actAltern.TempOut(I), 4) '!1.-XLOCOUT-RETLI(DGZ(2,I),0.,4)
                '!calore scambiato nella zona rapportato al duty
                X = (HLOCIN - HLOCOUT) / (HIn - HOUT)
                '!frazione condensati HC di zona rapportati alla frazione apparecchio
                If (XIN - XOUT = 0) Then
                    Y = 0
                Else
                    Y = (XLOCIN - XLOCOUT) / (XIN - XOUT)
                End If
                '!frazione condensati H2O di zona rapportati alla frazione apparecchio
                If (XVIN - XVOUT = 0) Then
                    YV = 0
                Else
                    YV = (XVLOCIN - XVLOCOUT) / (XVIN - XVOUT)
                End If
                DUTYC = R(1)
            End If
            actAltern.DutyZone(I) = DUTYC * X
            DUTY = DUTY + actAltern.DutyZone(I)
            If (actAltern.Prinop > 0) Then
                '!peso molecolare gas out
                actAltern.MWHCOut(I) = RETLI(actAltern.TempOut(I), 3)
            Else
                If (I >= (LIM - NZC + 1) And I <= LIM) Then ' !GO TO 570
570:                If (I = 1) Then
                        CONDMWIN = actPRV.MWVapHCin
                    Else
                        CONDMWIN = actAltern.MWHCOut(I - 1)
                    End If
                    actAltern.MWHCOut(I) = CONDMWIN - (actPRV.MWVapHCin - actPRV.MWVapHCout) * X
                Else
                    actAltern.MWHCOut(I) = actPRV.MWVapHCin
                    '  C(DGZ(3, I) = MWVapHCout)
                End If
            End If
            '            !condensato(HC)
            actAltern.CondHC(I) = actPRV.CondenHCr * Y
            '           !condensato(acqua)
            actAltern.CondST(I) = actPRV.CondSteamr * YV
560:    Next I
        If (NZC > 0) Then Exit Sub 'RETURN
        If (DUTY > 0) Then
            X = R(1) / DUTY
        Else
            X = 0
        End If
        For I = 1 To actAltern.NumZone
590:        actAltern.DutyZone(I) = actAltern.DutyZone(I) * X
        Next
    End Sub
    Private Function BITSETTA(ByVal BERSAGLIO As Integer, ByVal I As Integer, ByVal POS As Integer) As Integer
        'INTEGER*2 BERSAGLIO,I,POS
        If (I = 0) Then
            '         BITSETTA = IBCLR(BERSAGLIO, POS)
            BITSETTA = BERSAGLIO And Not 2 ^ (POS - 1)
        Else
            '        BITSETTA = IBSET(BERSAGLIO, POS)
            BITSETTA = BERSAGLIO Or 2 ^ (POS - 1)
        End If
    End Function
    Sub CED5(ByVal KOD As Integer, ByVal NRC As Integer, ByVal L As Integer, ByRef IBUF As String, ByVal NWD As Integer)
        '  INCLUDE() 'CMN1.FI'
        'COMMON/CED5C/IC1,IB,IBA,ICON,ARCH5,NS
        'CHARACTER*1 IC1
        'CHARACTER*2 IB,IBUF,IBA,ICON,IBUFA
        'CHARACTER*60 ARCH5
        'CHARACTER*11 ARCH6
        'CHARACTER*120 DOMANDA
        'INTEGER*4 x
        'INTEGER*2 IBI,IBUFI,IBAI                                          HHT12480
        '  DIMENSION(NS(4), IC1(4), IB(16), IBI(16), IBA(16), IBAI(16), IBUF(17), HHT12490)
        ' 1          IBUFI(17),IBUFA(17)                                     HHT12500
        ' EQUIVALENCE (IBI,IB)                                              HHT12510
        ' EQUIVALENCE (IBAI,IBA)                                            HHT12520
        ' EQUIVALENCE (IBUFA,IBUFI)                                         HHT12530
        '   EQUIVALENCE(IBUFA(1), IC1(1))
        Dim K1, K2, J, IERR, IFORM, I, NRT, NWR, LR, IC, NR As Integer
        Dim IC2, KR, NS As Integer
        K1 = KOD / 1000
        K2 = KOD - 1000 * K1
        '      DO 7000 J=1,80
        '7000  BLANK(J:J)=' '
        Dim ARCH5 As String = "ARCH" & GlobalRoutines.Str2Cifre(K2) & "_"
        Dim IBA, COMLIN As String
        Dim ICON As Boolean
        'WRITE(ARCH6,'(5H\ARCH,I2,4H.DAT)')K2
        '     ARCH5=ARCHD(1:LEN_TRIM(ARCHD))//ARCH6
        '	ARCH5=ARCH5(1:LEN_TRIM(ARCH5))
        '     OPEN(K2,FILE=ARCH5,STATUS='OLD',MODE='READ',ERR=901,IOSTAT=IERR)
        '    REWIND(K2)                                                        HHT12600
        '   ASSIGN 400 TO IFORM                                               HHT12610
        '  IF (K2.EQ.28.OR.K2.EQ.48.OR.K2.EQ.68.OR.K2.EQ.29.OR.K2.EQ.49.     HHT12620
        '1    OR.K2.EQ.69) ASSIGN 200 TO IFORM                              HHT12630
        ' READ(K2,IFORM) (IBAI(I),I=1,4)                                    HHT12640
        '200  FORMAT(4I2)                                                       HHT12650
        '400  FORMAT(4I4)                                                       HHT12660
        '    CLOSE(K2)                                                         HHT12670
        '     C(HHT12680)
        ' NWD=IBAI(1)                                                       HHT12690
        ' IBUFI(17)=NWD                                                     HHT12700
        ' NRT=IBAI(2)                                                       HHT12710
        ' NWR=IBAI(4)                                                       HHT12720
        ' LR=NWR*2+2                                                          HHT12730
        '   C(HHT12740)
        If (K1 = 0) Then GoTo 10
        'C 20   WRITE(L,1400)                                                     HHT12770
        'C 1400 FORMAT(' (DESCRIZIONE O CODICE)')
        'C++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' 20 OPEN(K2,RECL=LR,FORM='FORMATTED',ACCESS='DIRECT',MODE='READ'
        '  $       ,FILE=ARCH5,STATUS='OLD',ERR=902,IOSTAT=IERR)
        'READ(K2,1000,REC=1,ERR=903,IOSTAT=IERR) (IBA(J),J=1,NWD)                              HHT13040
        ' IBA = rmHelpStrings.GetString(ARCH5 & GlobalRoutines.Str2Cifre(K2))
        If (L = 1 Or L = 3 Or L = 5) Then
            IC = 1
            COMLIN = New String(" ", 80)
            NR = 0
            Do
                NR += 1
                'WRITE(NUM,'(I4,1H))')NR
                '!      READ(K2,FMT=1000,REC=NR,END=6111) (IBA(J),J=1,NWD)
                'READ(K2, FMT = 1000, REC = NR, Err() = 904, IOSTAT = IERR)(IBA(J), J = 1, NWD)
                IBA = rmHelpStrings.GetString(ARCH5 & GlobalRoutines.Str2Cifre(NR))
                If (IBA.StartsWith("X")) Then Exit Do
                IC2 = IC + 5 + 2 * NWD - 1
                If (IC2 < 79) Then
                    ' DO 6112 J=1,NWD
                    '6112    COMLIN(IC+4+2*(J-1)+1:IC+4+2*J)=IBA(J)
                    COMLIN = GlobalRoutines.Str3Cifre(NR) + IBA
                    IC = IC2 + 1
                Else
                    'WRITE(1,6114)COMLIN
                    COMLIN = New String(" ", 80)
                    IC = 1
                    IC2 = IC + 5 + 2 * NWD - 1
                    '        DO 6113 J=1,NWD
                    '6113    COMLIN(IC+4+2*(J-1)+1:IC+4+2*J)=IBA(J)
                    COMLIN = GlobalRoutines.Str4Cifre(NR) + IBA
                    IC = IC2 + 1
                End If
            Loop
            '           CLOSE(K2)
            '     IF(IC.GT.1) WRITE(1,6114)COMLIN
            '    WRITE(1,'('' CODICE:''I5)')NRC
            '6114  FORMAT(1X,A79)
        Else
            'C++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            '     DO 25 J=1,16                                                      HHT12790
            '25   IBUF(J)='  '                                                      HHT12800
            '           READ(1, 1000, Err() = 905, IOSTAT = IERR)(IBUF(J), J = 1, NWD)
            '1000 FORMAT(16A2)                                                      HHT12820
            '     DO 26 J=1,16                                                      HHT12830
            '26   IBUFA(J)=IBUF(J)                                                  HHT12840
            '     ICON='NO'
            '     READ(IBUFA(1),'(I2)',ERR=5)NRC
            '     ICON='YE'
            '          GOTO10()
            '         C(HHT13000)
5:          NRC = 0
            For I = 2 To NRT
                '  READ(K2, 1000, REC = I)(IBA(J), J = 1, NWD)
                IBA = rmHelpStrings.GetString(ARCH5 + GlobalRoutines.Str4Cifre(I))
                ICON = "YE"
                '  DO 110 J=1,NWD                                             
                '110  IF(IBUF(J).NE.IBA(J)) ICON='NO'      
                If IBUF <> IBA Then ICON = "NO"
                If (Not ICON = "NO") Then Exit For
            Next I
120:        If (ICON = "YE") Then NRC = I
            If (ICON = "YE") Then GoTo 900
            'Write(1, 2000)(IBUF(J), J = 1, 16)
            '2000 FORMAT(' DESCRIZIONE "',16A2,'" NON PREVISTA ')
            'C      GO TO 20                                                  
            GoTo 900
            '           C()
10:         If (NRC > 1 And NRC <= NRT) Then GoTo 30
            If (K1 <> 0) Then GoTo 900
            ' DO 50 I=1,NWD                                              
            IBUF = New String("  ", NWD)
            '  IBUFA = New String("  ", NWD)
            '50:         Continue Do
            GoTo 900
            '15:         Continue Do
            'c     WRITE(6,2100)NRC                                                 
            '2100 FORMAT(' CODICE ',I4,' NON PREVISTO(CED5) ')
            'C      GO TO 20                                                         
            '           GOTO900()
30:         '  OPEN(K2,RECL=LR,FORM='FORMATTED',ACCESS='DIRECT',MODE='READ'
            '$     ,FILE=ARCH5,STATUS='OLD')
            '      READ(K2, 1000, REC = 1)(IBUF(J), J = 1, NWR)
            'READ(K2, 1000, REC = NRC)(IBUF(J), J = 1, NWR)
            IBUF = rmHelpStrings.GetString(ARCH5 + GlobalRoutines.Str2Cifre(NRC))
            '      DO 35 J=1,NWR                                                   
            '35:         IBUFA(J) = IBUF(J)
            '      IF(IBUF(1).EQ.'X '.AND.K1.EQ.1) GO TO 15 
        End If
        ' IBUFA = IBUF
        '900:                                                CLOSE(K2)
        '                                                    Return
        ' 901  WRITE(DOMANDA,921)IERR,CHAR(13),CHAR(10),ARCH5,CHAR(0)
        '      x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	       MB_ICONSTOP,LANG_ITALIAN)
        '                                                    Return
        ' 902  WRITE(DOMANDA,922)IERR,CHAR(13),CHAR(10),ARCH5,CHAR(0)
        '      x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	       MB_ICONSTOP,LANG_ITALIAN)
        '                                                    Return
        ' 903  WRITE(DOMANDA,923)IERR,1,CHAR(13),CHAR(10),ARCH5,CHAR(0)
        '      x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	       MB_ICONSTOP,LANG_ITALIAN)
        '                                                    Return
        ' 904  WRITE(DOMANDA,923)IERR,KR,CHAR(13),CHAR(10),ARCH5,CHAR(0)
        '      x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	       MB_ICONSTOP,LANG_ITALIAN)
        '                                                    Return
        ' 905  WRITE(DOMANDA,925)IERR,CHAR(0)
        '      x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	       MB_ICONSTOP,LANG_ITALIAN)
        '                                                    Return
        ' 921  FORMAT('Errore n°',I5,' alla prima apertura della libreria ',2A1,
        '     xA40,A1)	
        ' 922  FORMAT('Errore n°',I5,' alla seconda apertura della libreria ',2A1
        '     x,A40,A1)	
        ' 923  FORMAT('Errore n°',I5,' alla lettura del record ',I3,2A1,
        '                                                    X() ' della libreria ',A40,A1)	
        '925  FORMAT('Errore n°',I5,' alla lettura di un record del file di scam 
        '    xbio.',A1)	
900:
    End Sub
    Function SWAPZONE(ByVal I As Integer, ByVal J As Integer) As Boolean
        'C la fissicità della zona I deve essere roportata sulla zona J
        'C la zona J è la seguente o la precedente della zon I
        Dim DATIZONA As Single
        'C----------------------------------------------------------
        '        INCLUDE() 'PRINCIP.FI'
        'C----------------------------------------------------------
        Dim K1, K2, KCOND1, KCOND2 As Integer
        'C-----------------------------------------------------------
        'c	DO 1 K=1,8
        '        c(DATIZONA = DGZ(K, I))
        '        c(DGZ(K, I) = DGZ(K, J))
        '        c1(DGZ(K, J) = DATIZONA)
        K1 = actAltern.codZona(I) \ 2 '!n° passi fissi per la zona I
        KCOND1 = (CInt(actAltern.codZona(I)) And 1)
        K2 = actAltern.codZona(J) \ 2 '!n° passi fissi per la zona J
        KCOND2 = (CInt(actAltern.codZona(J)) And 1)
        If (K2 > 0) Then
            'C ci sono due zone fisse e confinanti
            Return False
        End If
        actAltern.codZona(I) = CSng(KCOND1)
        actAltern.codZona(J) = CSng(KCOND2 + 2 * K1)
        Return True
    End Function
    Sub BILZON(ByVal ICT1 As Integer, ByVal ICTR As Integer)
        '        INCLUDE() 'CMN.FI'
        '        INCLUDE() 'CMN1.FI'
        '        INCLUDE() 'PRINCIP.FI'
        '	INTEGER xMESS
        '	CHARACTER*240 DOMANDA
        'C-----------------------------------------------------------
        '      COMMON/PRINCIQ/COEFF(21),IZ(12),IPC(61),STAM(6,12)
        Dim IZ, I, J, I1 As Integer
        Dim TEMP, LETTO As Single
        '        C(----------------------------------------------------------------------HHT02870)
        '      COMMON/FARFAR/NRD,KEY,KTEST,KSCOIL,KSERP,IPOS,
        '     1 KPERS,ICONTR,LIM,NZC,NREC,MODIF,NCOEFF,IRIAU,NALTOL,IDUM,
        '     2 DUTY,DUTYC,CHCL,CH2O,CHCV,CHIN,CONHC,CONHO,CONDST,CONDHC,
        '3:      TAV, T, X, DUM1, DUM2, DUM3, PADD1(16), NALT, LPAD(3)
        '      INTEGER*2 NRD,KEY,KTEST,KSCOIL,KSERP,IDUM
        '      INTEGER*2 KPERS,ICONTR,LIM,NZC,NREC,NALT,LPAD
        '      INTEGER*2 MODIF,NCOEFF,IPOS,NALTOL,ICNEAR
        '      CHARACTER*2 IRIAU
        '      REAL*4 DUTY,DUTYC,CHCL,CH2O,CHCV,T,X,DUM1,DUM2,DUM3
        '      REAL*4 CHIN,CONHC,CONHO,CONDST,CONDHC,TAV,COEFF,TEMP
        '	REAL*4 STAM,PADD1,LETTO
        'C----------------------------------------------------------------------
        'c      DIMENSION RDIT(64)
        '       c(EQUIVALENCE(IB1, RDIT))
        'C---------------------------------------------------------------------
        '!230   READ(7,REC=(NRDIN+1)) (NIBDITs(J),J=129,256)
240:    DUTY = 0
        CONDST = 0
        CONDHC = 0
        'C LOOP SULLE ZONE-----------------------------------------------
        For I = 1 To actAltern.NumZone
            If (actItem.Automatico = "SI") Then GoTo 244
            If (I = actAltern.NumZone) Then
                actAltern.DutyZone(I) = (actItem.RDIT(1) - DUTY) * COEFF(NCOEFF, 1)
            Else
                If (ICT1 <> 1) Then
                    If (ICTR = 1) Then
                        'WRITE(1,1070) I,(IBUNI(J,1),J=1,6),DGZ(1,I)/COEFF(1)
                    Else
                        'READ(1,52) LETTO
                        If (Not LETTO = -1111) Then
                            'DGZ(1, I) = LETTO
                            'DGZ(1, I) = DGZ(1, I) * COEFF(1)
                        End If
                    End If
                End If
                DUTY = DUTY + actAltern.DutyZone(I) / COEFF(NCOEFF, 1)
            End If
244:        If (I = actAltern.NumZone) Then
245:            actAltern.TempOut(I) = actItem.RDIT(3) * COEFF(NCOEFF, 2)
                If (IPRAM(4) <> 2) Then actAltern.TempOut(I) += 32
            Else
                If (ICT1 <> 1) Then
                    If (ICTR = 1) Then
                        TEMP = actAltern.TempOut(I)
                        If (IPRAM(4) <> 2) Then TEMP = TEMP - 32
                        TEMP = TEMP / COEFF(NCOEFF, 2)
                        'WRITE(1,1080) I,(IBUNI(J,2),J=1,6),TEMP
                    Else
                        'READ(1,52) LETTO
                        If (Not LETTO = -1111) Then
                            actAltern.TempOut(I) = LETTO
                            actAltern.TempOut(I) *= COEFF(NCOEFF, 2)
                            If (IPRAM(4) <> 2) Then actAltern.TempOut(I) += 32
                        End If
                    End If
                End If
            End If
            If (actItem.Automatico = "SI") Then GoTo 250
            If (actItem.RDIT(5) = 0) Then GoTo 270
            If (I = actAltern.NumZone) Then
                actAltern.MWHCOut(I) = actItem.RDIT(15)
                actAltern.CondHC(I) = (actItem.RDIT(59) - CONDHC) * COEFF(NCOEFF, 3)
                If (actAltern.CondHC(I) < 1 And actAltern.CondHC(I) > -1) Then actAltern.CondHC(I) = 0
                GoTo 270
            End If
            If (ICT1 <> 1) Then
                If (ICTR = 1) Then
                    'WRITE(1,1090) I,DGZ(3,I)
                Else
                    'READ(1,52) LETTO
                    If (Not LETTO = -1111) Then
                        actAltern.MWHCOut(I) = LETTO
                    End If
                End If
            End If
            If (actItem.RDIT(59) = 0) Then GoTo 270
            If (ICT1 <> 1) Then
                If (ICTR = 1) Then
                    'WRITE(1,1100) I,(IBUNI(J,3),J=1,6),DGZ(4,I)/COEFF(3)
                Else
                    'READ(1,52) LETTO
                    If (Not LETTO = -1111) Then
                        actAltern.CondHC(I) = LETTO
                        actAltern.CondHC(I) *= COEFF(NCOEFF, 3)
                    End If
                End If
            End If
            CONDHC += actAltern.CondHC(I) / COEFF(NCOEFF, 3)
270:        If (actItem.RDIT(60) = 0) Then GoTo 250
            If (I = actAltern.NumZone) Then
275:            actAltern.CondST(I) = (actItem.RDIT(60) - CONDST) * COEFF(NCOEFF, 3)
                If (actAltern.CondST(I) < 1 And actAltern.CondST(I) > -1) Then actAltern.CondST(I) = 0
            Else
                If (ICT1 <> 10) Then
                    If (ICTR = 1) Then
                        'WRITE(1,1110) I,(IBUNI(J,3),J=1,6),DGZ(5,I)/COEFF(3)
                    Else
                        'READ(1,52) LETTO
                        If (Not LETTO = -1111) Then
                            actAltern.CondST(I) = LETTO
                            actAltern.CondST(I) *= COEFF(NCOEFF, 3)
                        End If
                    End If
                End If
                CONDST += actAltern.CondST(I) / COEFF(NCOEFF, 3)
            End If
250:    Next I
        'C*****************************************************************
        For I = 1 To 61
            I1 = I
            If (I = 57) Then I1 = 62
            If (I = 58) Then I1 = 63
            If (I = 56) Then I1 = 64
            R(I) = actItem.RDIT(I1) * COEFF(NCOEFF, IPC(I))
            If (IPC(I) = 2 And IPRAM(4) <> 2) Then R(I) = R(I) + 32
        Next
        actPRV.PressAbs += 14.7
        '        Return
        '1090  FORMAT('ZONA-',I2,': PESO MOL.VAP.IDROC.OUT 'E12.5)
        '1100  FORMAT('ZONA-',I2,': COND. IDROC. [',6A2,']'E12.5)
        '1110  FORMAT('ZONA-',I2,': COND. ACQUA  [',6A2,']'E12.5)
        '1070  FORMAT('ZONA-',I2,': CALORE SCAMBIATO [',6A2,']'E12.5)
        '1080  FORMAT('ZONA-',I2,': TEMP. FLUIDO OUT [',6A2,']'E12.5)
        '52    FORMAT (F25.0)
    End Sub
End Module
