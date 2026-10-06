Option Strict Off
Option Explicit On
Module wrcbBSG
    Friend Function AppGLeg() As Boolean
        Dim i As Short
        Dim BETA2Sav As Single
        Dim KKKSav, GAMMASav As Single
        Dim BETA1Sav, HHHSav As Single
        Dim Res, BETASav, Res1 As Single
        Dim k As Short
        Dim D As Single
        AppGLeg = True
        For i = 1 To 4
            Call LegMcMf(i, -4)
        Next
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        BETA2Sav = BETA2
        BETA2 = BETA2 / 3
        KKKSav = KKK
        KKK = BETA2 / BETA1
        For i = 1 To 4
            Call LegMc(i)
        Next
        BETA2 = BETA2Sav
        KKK = KKKSav
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        GAMMASav = GAMMA
        BETA1Sav = BETA1
        BETASav = BETA
        KKKSav = KKK
        HHHSav = HHH
        BETA1 = BETA1 / 3
        BETA = BETA / 9
        KKK = BETA2 / BETA1
        HHH = 2 * BETA1 / GAMMA
        If Geom(iB).CylL <= 0 Then
            MostraAiuto(IDH_ERR_LCYLZERO)
            Return False
        End If
        For i = 1 To 4
            Res = 0
            For k = -1 To 1 Step 2 'G.2.3.3(a)
                D = Geom(iB).Cyld + k * BETA1
                GAMMA = Geom(iB).CylL - 4 * D ^ 2 / Geom(iB).CylL 'Le G.2.2.1.1
                Call LegMf(i)
                If System.Math.Abs(KRead(i + 8)) > System.Math.Abs(Res) Then
                    Res = KRead(i + 8) : Res1 = HRead(i + 8)
                    SopraSotto(i) = k
                End If
            Next
            KRead(i + 8) = Res : HRead(i + 8) = Res1
        Next
        GAMMA = GAMMASav
        BETA1 = BETA1Sav
        BETA = BETASav
        KKK = KKKSav
        HHH = HHHSav
    End Function
    Function AppGParam() As Boolean
        Try
            AppGParam = False
4000:       GAMMA = Geom(iB).CylL - 4 * Geom(iB).Cyld ^ 2 / Geom(iB).CylL 'Le G.2.2.1.1
            If Geom(iB).Forma = 0 Then
                RBocch = Geom(iB).R0 : If Geom(iB).RX > RBocch Then RBocch = Geom(iB).RX
                TBocch = Geom(iB).T0 - Geom(iB).CorrN : If Geom(iB).TX - Geom(iB).CorrN > TBocch Then TBocch = Geom(iB).TX - Geom(iB).CorrN
                If ShellNoz = 2 Then
                    RBocch = Geom(iB).Padd / 2
                    TBocch = 0
                Else
                    RBocch = RBocch - 0.5 * TBocch
                End If
                Tsh = Geom(iB).ShellT - Geom(iB).Corr
                If Geom(iB).Rinforzo And ShellNoz = 1 Then Tsh = Tsh + Geom(iB).PadT
4100:           trsTr = TBocch / Tsh
4101:           dmean = Geom(iB).di + Geom(iB).ShellT + Geom(iB).Corr
4102:           dsD = 2 * RBocch / dmean
4103:           RHO354 = dsD * System.Math.Sqrt(dmean / 2 / Tsh)
4104:           BETA1 = 0.85 * RBocch 'Cx
                BETA2 = BETA1 'asin(.85 * RBocch / Geom(iB).RO) * Geom(iB).RO         'Cf
            Else '11
                dmean = Geom(iB).di + Geom(iB).ShellT + Geom(iB).Corr
                If ShellNoz = 2 Then
                    BETA1 = Geom(iB).D2Rinf / 2 'Cx
                    BETA2 = Geom(iB).D1Rinf / 2 'Cf
                Else
                    BETA1 = Geom(iB).D2 / 2 'Cx
                    BETA2 = Geom(iB).D1 / 2 'Cf
                End If
            End If
4110:       BETA = 64 * Geom(iB).RM / Geom(iB).T * (BETA1 / Geom(iB).RM) ^ 2
            HHH = 2 * BETA1 / GAMMA '2Cx/L
            KKK = BETA2 / BETA1 '2Cf/2Cx
            AppGParam = True
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function

    Function AppGParamS() As Boolean
        Try
            AppGParamS = True
            If ShellNoz = 2 And Geom(iB).Buco = 0 Then Exit Function
            If Geom(iB).Buco = 0 Then
                RBocch = Geom(iB).R0 : If Geom(iB).RX > RBocch Then RBocch = Geom(iB).RX
                TBocch = Geom(iB).T0 - Geom(iB).CorrN : If Geom(iB).TX - Geom(iB).CorrN > TBocch Then TBocch = Geom(iB).TX - Geom(iB).CorrN
                RBocch = RBocch - 0.5 * TBocch
                Tsh = Geom(iB).ShellT - Geom(iB).Corr
                If Geom(iB).Rinforzo Then Tsh = Tsh + Geom(iB).PadT
                trsTr = TBocch / Tsh
                GAMMA = RBocch / Geom(iB).RM * System.Math.Sqrt(Geom(iB).RM / Tsh)
                dsD = Geom(iB).RM / Tsh
            Else
                If Geom(iB).Forma = 0 Then
                    If ShellNoz = 1 Then
                        RBocch = Geom(iB).R0 : If Geom(iB).RX > RBocch Then RBocch = Geom(iB).RX
                    Else
                        RBocch = Geom(iB).Padd
                    End If
                Else
                    If ShellNoz = 1 Then
                        RBocch = System.Math.Sqrt(Geom(iB).D1 * Geom(iB).D2) / 2
                    Else
                        RBocch = System.Math.Sqrt(Geom(iB).D1Rinf * Geom(iB).D2Rinf) / 2
                    End If
                End If
                GAMMA = RBocch * 1.82 / System.Math.Sqrt(Geom(iB).RM * Geom(iB).T) 'u
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Sub AppGSfe()
        Dim Para1, Para2 As Single
        Dim xxx1, xxx2 As Single
        Dim xFig1, xFig2 As Single
        Dim FileFig As String
        Dim i1, i2 As Short
        Dim dsD1, dsD2 As Single
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS29.DAT"
        Call globalRoutines.LegFig(FileFig, trsTr, GAMMA, Para1, Para2, xxx1, xxx2, 2)
        xFig1 = xxx1 + (xxx2 - xxx1) * (trsTr - Para1) / (Para2 - Para1)
        KRead(1) = xFig1 'SCF per pressione
        If dsD < 90 Then
            i1 = 1 : i2 = 2 : dsD1 = 30 : dsD2 = 90
        Else
            i1 = 2 : i2 = 3 : dsD1 = 90 : dsD2 = 150
        End If
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS31" & Chr(64 + i1) & ".DAT"
        Call globalRoutines.LegFig(FileFig, trsTr, GAMMA, Para1, Para2, xxx1, xxx2, 2)
        If Para2 = 1 Then
            KRead(2) = xxx2
        Else
            xFig1 = xxx1 + (xxx2 - xxx1) * (trsTr - Para1) / (Para2 - Para1)
            FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS31" & Chr(64 + i2) & ".DAT"
            Call globalRoutines.LegFig(FileFig, trsTr, GAMMA, Para1, Para2, xxx1, xxx2, 2)
            xFig2 = xxx1 + (xxx2 - xxx1) * (trsTr - Para1) / (Para2 - Para1)
            KRead(2) = xFig1 + (xFig2 - xFig1) * (dsD - dsD1) / (dsD2 - dsD1) 'carico assiale
        End If
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS33" & Chr(64 + i1) & ".DAT"
        Call globalRoutines.LegFig(FileFig, trsTr, GAMMA, Para1, Para2, xxx1, xxx2, 2)
        If Para2 = 1 Then
            KRead(3) = xxx2
        Else
            xFig1 = xxx1 + (xxx2 - xxx1) * (trsTr - Para1) / (Para2 - Para1)
            FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS33" & Chr(64 + i2) & ".DAT"
            Call globalRoutines.LegFig(FileFig, trsTr, GAMMA, Para1, Para2, xxx1, xxx2, 2)
            xFig2 = xxx1 + (xxx2 - xxx1) * (trsTr - Para1) / (Para2 - Para1)
            KRead(3) = xFig1 + (xFig2 - xFig1) * (dsD - dsD1) / (dsD2 - dsD1) 'momento
        End If
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS35.DAT"
        Call globalRoutines.LegFig(FileFig, trsTr, GAMMA, Para1, Para2, xxx1, xxx2, 2)
        xFig1 = xxx1 + (xxx2 - xxx1) * (trsTr - Para1) / (Para2 - Para1)
        KRead(4) = xFig1 'taglio
    End Sub
    Sub AppGSfeR()
        KRead(1) = Interp1(RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS25AA.DAT", GAMMA) 'Mx
        KRead(2) = Interp1(RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS25BB.DAT", GAMMA) 'Mf
        KRead(3) = Interp1(RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS25CC.DAT", GAMMA) 'Nx
        KRead(4) = Interp1(RTrim(Monitor.clsInizio.Archdir) & "\WR\BSS25DD.DAT", GAMMA) 'Nf
    End Sub

    Sub Calc297()
        Dim EndEffect As Single
        Dim Vc, AML, AMc, AMt, Vl As Single
        Try
            Call Compos(EndEffect, AMc, AML, AMt, Vc, Vl)
200:        S11 = KRead(3) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'nt P
            S12 = S11
            S21 = KRead(1) * (6 * EndEffect / Geom(iB).T ^ 2) 'mt P
            S22 = S21
210:        S3 = KRead(7) * 1.5 * AMc / (2 * BETA2 * Geom(iB).T ^ 2)
            S4 = KRead(5) * 6 * 1.5 * AMc / (2 * BETA2 * Geom(iB).T ^ 2)
            S5 = KRead(11) * 1.5 * AML / (2 * BETA1 * Geom(iB).T ^ 2)
            S6 = KRead(9) * 6 * 1.5 * AML / (2 * BETA1 * Geom(iB).T ^ 2)
220:        Z11 = KRead(4) * (EndEffect / (Geom(iB).T * Geom(iB).T)) 'nt P
            Z12 = Z11
            Z21 = KRead(2) * (6 * EndEffect / Geom(iB).T ^ 2) 'mt P
            Z22 = Z21
230:        Z3 = KRead(8) * 1.5 * AMc / (2 * BETA2 * Geom(iB).T ^ 2)
            Z4 = KRead(6) * 6 * 1.5 * AMc / (2 * BETA2 * Geom(iB).T ^ 2)
            Z5 = KRead(12) * 1.5 * AML / (2 * BETA1 * Geom(iB).T ^ 2)
            Z6 = KRead(10) * 6 * 1.5 * AML / (2 * BETA1 * Geom(iB).T ^ 2)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Function Interp1(ByRef F As String, ByRef Para As Single) As Single
        Dim ifl As Short
        Dim Riga As String
        Dim Para1, Valo1 As Single
        Dim Para2, Valo2 As Single
        Dim R As String
        ifl = FreeFile()
        FileOpen(ifl, F, OpenMode.Input, , OpenShare.Shared)
        Riga = LineInput(ifl)
        Riga = LineInput(ifl)
        Para1 = GlobaLroutines.ValVir(Left(Riga, 9))
        Valo1 = GlobaLroutines.ValVir(Right(Riga, 5))
        Do
            Riga = LineInput(ifl)
            If Left(Riga, 1) = "f" Then Exit Do
            R = globalRoutines.Adjust(Riga, 14)
            Para2 = GlobaLroutines.ValVir(Left(Riga, 9))
            Valo2 = GlobaLroutines.ValVir(Right(Riga, 5))
            If Para2 > Para Then Exit Do
            Para1 = Para2 : Valo1 = Valo2
        Loop
        FileClose(ifl)
        Interp1 = Valo1 + (Valo2 - Valo1) / (Para2 - Para1) * (Para - Para1)
    End Function

    Function LeggiInv(ByRef Kr As Single, ByRef i1 As String, ByRef i2 As String, ByRef ifl As Short, ByRef h1 As Single, ByRef h2 As Single) As Single
        Dim Para1, Para2 As Single
        Dim xxx1, xxx2 As Single
        Dim xFig2, xFig1, Ris As Single
        Dim FileFig As String
        'procedura G.2.3.3(3)
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSGA" & i1 & ".DAT"
        Call globalRoutines.LegFigInv(FileFig, HHH, Kr, Para1, Para2, xxx1, xxx2)
        xFig1 = xxx1 + (xxx2 - xxx1) * (HHH - Para1) / (Para2 - Para1)
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSGA" & i2 & ".DAT"
        Call globalRoutines.LegFigInv(FileFig, HHH, Kr, Para1, Para2, xxx1, xxx2)
        xFig2 = xxx1 + (xxx2 - xxx1) * (HHH - Para1) / (Para2 - Para1)
        'LeggiInv = InterLogar(HHH, h1, h2, xFig1, xFig2)
        Ris = xFig1 + (xFig2 - xFig1) * System.Math.Log(BETA / h1) / System.Math.Log(h2 / h1)
        LeggiInv = Ris
    End Function
    Sub LegMc(ByRef iRead As Short)
        Dim i1 As Short
        Dim h1, h2 As Single
        Dim i2 As Short
        Dim FileFig As String
        Dim stri1, stri2 As String
        Dim ifl As Short
        Dim Z, FI1 As Single
        Dim Para1, Para2 As Single
        Dim xxx1, xxx2 As Single
        Dim xFig1, xFig2 As Single
        Call LegMcMf(iRead, 0)
        If Neglect1(4.0!, BETA, HHH) Then HRead(iRead + 4) = 0 : Exit Sub 'PROVVISORIO : Š 4!
        If BETA < 0.4 Then
            i1 = 1 : h1 = 0.4 : h2 = 10
        ElseIf BETA < 10 Then
            i1 = 1 : h1 = 0.4 : h2 = 10
        ElseIf BETA < 200 Then
            i1 = 2 : h1 = 10 : h2 = 200
        Else 'n
            i1 = 3 : h1 = 200 : h2 = 3200
        End If
        i1 = i1 + (iRead - 1) * 4 : i2 = i1 + 1
        stri1 = Str(i1) : If Len(stri1) > 2 Then stri1 = Right(stri1, 2) Else Mid(stri1, 1, 1) = "0"
        stri2 = Str(i2) : If Len(stri2) > 2 Then stri2 = Right(stri2, 2) Else Mid(stri2, 1, 1) = "0"
        ifl = FreeFile()
        Z = LeggiInv(KRead(iRead + 4), stri1, stri2, ifl, h1, h2)
        FI1 = 4 * BETA2 / BETA1 + Z
        '--------------------------------------------------------------------
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSGA" & stri1 & ".DAT"
        Call globalRoutines.LegFig(FileFig, HHH, FI1, Para1, Para2, xxx1, xxx2, 3)
        xFig1 = xxx1 + (xxx2 - xxx1) * (HHH - Para1) / (Para2 - Para1)
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSGA" & stri2 & ".DAT"
        Call globalRoutines.LegFig(FileFig, HHH, FI1, Para1, Para2, xxx1, xxx2, 3)
        xFig2 = xxx1 + (xxx2 - xxx1) * (HHH - Para1) / (Para2 - Para1)
        'KRead(iRead + 4) = KRead(iRead + 4) - InterLogar(BETA, h1, h2, xFig1, xFig2)
        '    HRead(iRead + 4) = xFig1 + (xFig2 - xFig1) * (BETA - h1) / (h2 - h1)
        HRead(iRead + 4) = xFig1 + (xFig2 - xFig1) * System.Math.Log(BETA / h1) / System.Math.Log(h2 / h1)
        KRead(iRead + 4) = KRead(iRead + 4) - HRead(iRead + 4)
        '---------------------------------------------------------------------------
    End Sub

    Sub LegMcMf(ByRef iRead As Short, ByRef iOff As Short)
        Dim i1, i2 As Short
        Dim stri1, stri2 As String
        Dim h1, h2 As Single
        Dim ifl As Short
        Dim FileFig As String
        Dim Para1, Para2 As Single
        Dim xxx1, xxx2 As Single
        Dim xFig1, xFig2 As Single
        If HHH < 0.01 Then
            i1 = 1 : h1 = 0.01 : h2 = 0.05
        ElseIf HHH < 0.05 Then
            i1 = 1 : h1 = 0.01 : h2 = 0.05
        ElseIf HHH < 0.2 Then
            i1 = 2 : h1 = 0.05 : h2 = 0.2
        Else 'o
            i1 = 3 : h1 = 0.2 : h2 = 0.4
        End If
        i1 = i1 + (iRead - 1) * 4 : i2 = i1 + 1
        stri1 = Str(i1) : If Len(stri1) > 2 Then stri1 = Right(stri1, 2) Else Mid(stri1, 1, 1) = "0"
        stri2 = Str(i2) : If Len(stri2) > 2 Then stri2 = Right(stri2, 2) Else Mid(stri2, 1, 1) = "0"
        ifl = FreeFile()
        '-------------------------------------------------------------------
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSG" & stri1 & ".DAT"
        Call globalRoutines.LegFig(FileFig, KKK, BETA, Para1, Para2, xxx1, xxx2, 2)
        xFig1 = xxx1 + (xxx2 - xxx1) * (KKK - Para1) / (Para2 - Para1)
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSG" & stri2 & ".DAT"
        Call globalRoutines.LegFig(FileFig, KKK, BETA, Para1, Para2, xxx1, xxx2, 2)
        xFig2 = xxx1 + (xxx2 - xxx1) * (KKK - Para1) / (Para2 - Para1)
        'KRead(iRead + 4 + iOff) = InterLogar(HHH, h1, h2, xFig1, xFig2)
        KRead(iRead + 4 + iOff) = xFig1 + (xFig2 - xFig1) * (HHH - h1) / (h2 - h1)
        '--------------------------------------------------------------------
    End Sub

    Sub LegMf(ByRef iRead As Short)
        Dim i1, i2 As Short
        Dim stri1, stri2 As String
        Dim h1, h2 As Single
        Dim FileFig As String
        Dim Para1, Para2 As Single
        Dim xxx1, xxx2 As Single
        Dim xFig1, xFig2 As Single
        Dim RSav, Z, KKKSav As Single
        Call LegMcMf(iRead, 4)
        If Neglect2(4.0!, BETA, HHH) Then Exit Sub
        If BETA < 0.4 Then
            i1 = 1 : h1 = 0.4 : h2 = 10
        ElseIf BETA < 10 Then
            i1 = 1 : h1 = 0.4 : h2 = 10
        ElseIf BETA < 200 Then
            i1 = 2 : h1 = 10 : h2 = 200
        Else 'p
            i1 = 3 : h1 = 200 : h2 = 3200
        End If
        i1 = i1 + (iRead - 1) * 4 : i2 = i1 + 1
        stri1 = Str(i1) : If Len(stri1) > 2 Then stri1 = Right(stri1, 2) Else Mid(stri1, 1, 1) = "0"
        stri2 = Str(i2) : If Len(stri2) > 2 Then stri2 = Right(stri2, 2) Else Mid(stri2, 1, 1) = "0"
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSGB" & stri1 & ".DAT"
        Call globalRoutines.LegFig(FileFig, HHH, 5.0!, Para1, Para2, xxx1, xxx2, 3)
        xFig1 = xxx1 + (xxx2 - xxx1) * (HHH - Para1) / (Para2 - Para1)
        FileFig = RTrim(Monitor.clsInizio.Archdir) & "\WR\BSGB" & stri2 & ".DAT"
        Call globalRoutines.LegFig(FileFig, HHH, 5.0!, Para1, Para2, xxx1, xxx2, 3)
        xFig2 = xxx1 + (xxx2 - xxx1) * (HHH - Para1) / (Para2 - Para1)
        'Z = InterLogar(BETA, h1, h2, xFig1, xFig2)
        '    Z = xFig1 + (xFig2 - xFig1) * (BETA - h1) / (h2 - h1)
        Z = xFig1 + (xFig2 - xFig1) * System.Math.Log(BETA / h1) / System.Math.Log(h2 / h1)
        RSav = KRead(iRead + 8)
        KKKSav = KKK
        KKK = 0
        Call LegMcMf(iRead, 4)
        Z = Z * RSav / KRead(iRead + 8)
        HRead(iRead + 8) = Z
        KRead(iRead + 8) = RSav - HRead(iRead + 8)
        KKK = KKKSav
    End Sub

    Function Neglect1(ByRef Rapp As Object, ByRef P64 As Object, ByRef CxL As Object) As Boolean
        Dim iRis As Boolean
        Dim Fact, aK3 As Single
        Dim aK1, aK2 As Single
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If P64 > 200 Then
            iRis = True
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ElseIf P64 > 10 Then
            iRis = False
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Fact = System.Math.Log(P64 / 200) / System.Math.Log(10 / 200)
            If CxL >= 0.2 Then
                aK3 = 0 + 1.5 * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            ElseIf CxL > 0.05 Then
                aK1 = 0 + 1.5 * Fact
                aK2 = 0 + 2.5 * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.2) / (0.05 - 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            Else '5
                aK1 = 0 + 2.5 * Fact
                aK2 = 0 + 3.0! * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.05) / (0.01 - 0.05)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            End If
        Else '4
            iRis = False
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Fact = System.Math.Log(P64 / 10) / System.Math.Log(0.4 / 10)
            If CxL >= 0.2 Then
                aK1 = 1.5
                aK2 = 1.5 + (3 - 1.5) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.4) / (0.2 - 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            ElseIf CxL > 0.05 Then
                aK1 = 1.5 + (3 - 1.5) * Fact
                aK2 = 2.5 + (6 - 2.5) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.2) / (0.05 - 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            Else '5
                aK1 = 2.5 + (6 - 2.5) * Fact
                aK2 = 3.0! + (8 - 3.0!) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.05) / (0.01 - 0.05)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            End If
        End If
        Neglect1 = iRis
    End Function

    Function Neglect2(ByRef Rapp As Object, ByRef P64 As Object, ByRef CxL As Object) As Boolean
        Dim iRis As Boolean
        Dim aK1, Fact As Single
        Dim aK2, aK3 As Single
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If P64 > 3200 Then
            aK1 = 2.5
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If aK1 < Rapp Then iRis = True
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ElseIf P64 > 200 Then
            iRis = False
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Fact = System.Math.Log(P64 / 3200) / System.Math.Log(200 / 3200)
            If CxL >= 0.2 Then
                aK1 = 2.5 + (1.75 - 2.5) * Fact
                aK2 = 2.5
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.4) / (0.2 - 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            ElseIf CxL > 0.05 Then
                aK1 = 2.5
                aK2 = 2.5 + (4 - 2.5) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.2) / (0.05 - 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            Else
                aK1 = 2.5 + (4 - 2.5) * Fact
                aK2 = 2.5 + (5 - 2.5) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.05) / (0.01 - 0.05)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ElseIf P64 > 10 Then
            iRis = False
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Fact = System.Math.Log(P64 / 200) / System.Math.Log(10 / 200)
            If CxL >= 0.2 Then
                aK1 = 1.75 + (2 - 1.75) * Fact
                aK2 = 2.5 + (3 - 2.5) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.4) / (0.2 - 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            ElseIf CxL > 0.05 Then
                aK1 = 2.5 + (3 - 2.5) * Fact
                aK2 = 4 + (8 - 4) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.2) / (0.05 - 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            Else
                aK1 = 4 + (8 - 4) * Fact
                aK2 = 5 + (8 - 5) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.05) / (0.01 - 0.05)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            End If
        Else '7
            iRis = False
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto P64. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Fact = System.Math.Log(P64 / 10) / System.Math.Log(0.4 / 10)
            If CxL > 0.4 Then
                aK1 = 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK1 < Rapp Then iRis = True
            ElseIf CxL >= 0.2 Then
                aK1 = 2
                aK2 = 3 + (4 - 3) * Fact
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.4) / (0.2 - 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            ElseIf CxL >= 0.05 Then
                aK1 = 3 + (4 - 3) * Fact
                aK2 = 8
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CxL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                aK3 = aK1 + (aK2 - aK1) * (CxL - 0.2) / (0.05 - 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            Else '8
                aK3 = 8
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rapp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If aK3 < Rapp Then iRis = True
            End If
        End If
        Neglect2 = iRis
    End Function

    Sub Prossimi()
        Dim i, iprox As Short
        Dim RBocchx, GAMMAx, TBocchx As Single
        Dim BETA1x, BETA2x As Single
        Dim CxL, BETAx As Single
        Dim Rapp As Single
        Dim iRes As Boolean
        Try
            If AddDistinta > 0 Then
                For i = 1 To 4
                    iprox = Geom(iB).iB(i)
                    If iprox > 0 Then
                        If Geom(iprox).Incluso = 0 Then
4200:                       Geom(iB).iB(i) = -iprox 'trascurabile W
                            Geom(iB).Dist(i) = -Geom(iB).Dist(i) 'trascurabile M
                        Else
4210:                       GAMMAx = Geom(iprox).CylL - 4 * Geom(iprox).Cyld ^ 2 / Geom(iprox).CylL 'Le G.2.2.1.1
                            If Geom(iprox).Forma = 0 Then
                                RBocchx = Geom(iprox).R0 : If Geom(iprox).RX > RBocchx Then RBocchx = Geom(iprox).RX
                                TBocchx = Geom(iprox).T0 - Geom(iprox).CorrN : If Geom(iprox).TX - Geom(iprox).CorrN > TBocchx Then TBocchx = Geom(iprox).TX - Geom(iprox).CorrN
                                If Geom(iprox).Rinforzo < 0 Then
                                    RBocchx = Geom(iprox).Padd / 2
                                    TBocchx = 0
                                Else
4220:                               RBocchx = RBocchx - 0.5 * TBocchx
                                End If
                                BETA1x = 0.85 * RBocchx 'Cx
                                BETA2x = BETA1x
                            Else '11
4230:                           BETA1x = Geom(iprox).D2 / 2 'Cx
                                BETA2x = Geom(iprox).D1 / 2 'Cf
                            End If
4232:                       CxL = 2 * BETA1x / GAMMAx
                            BETAx = 64 * Geom(iprox).RM / Geom(iprox).T * (BETA1x / Geom(iprox).RM) ^ 2
                            If i = 1 Or i = 3 Then
4240:                           Rapp = Geom(iB).Dist(i) / BETA1x
                                iRes = Neglect1(Rapp, BETAx, CxL)
                                If iRes Then Geom(iB).iB(i) = -iprox
                                CxL = CxL / 3
                                BETA1x = BETA1x / 3
                                BETAx = 64 * Geom(iprox).RM / Geom(iprox).T * (BETA1x / Geom(iprox).RM) ^ 2
4250:                           Rapp = (Geom(iB).Dist(i) - BETA1x) / BETA1x
                                iRes = Neglect1(Rapp, BETAx, CxL)
                                If iRes Then Geom(iB).Dist(i) = -Geom(iB).Dist(i)
                            Else
                                Rapp = Geom(iB).Dist(i) / BETA2x
                                iRes = Neglect2(Rapp, BETAx, CxL)
                                If iRes Then Geom(iB).iB(i) = -iprox
4260:                           BETA2x = BETA2x / 3
                                Rapp = (Geom(iB).Dist(i) - BETA2x) / BETA2x
                                iRes = Neglect2(Rapp, BETAx, CxL)
                                If iRes Then Geom(iB).Dist(i) = -Geom(iB).Dist(i)
                            End If
                        End If
                    End If
4270:           Next
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub StressSfeG()
        Dim EndEffect As Single
        Dim Vc, AML, AMc, AMt, Vl As Single
        Call Compos(EndEffect, AMc, AML, AMt, Vc, Vl)
        KRead(5) = KRead(1) * System.Math.Abs(Geom(iB).Carichi(iC).DesPress) * dsD / 2
        KRead(6) = KRead(2) * System.Math.Abs(EndEffect) / 2 / PI / Tsh / RBocch * System.Math.Sqrt(dsD)
        KRead(7) = KRead(3) * System.Math.Sqrt(AMc * AMc + AML * AML) / PI / Tsh / RBocch ^ 2 * System.Math.Sqrt(dsD)
        KRead(8) = KRead(4) * System.Math.Sqrt(Vc * Vc + Vl * Vl) / 2 / PI / Tsh / RBocch
        Result(ShellNoz, iC, iB).Sq = KRead(5) + KRead(6) + KRead(7) + KRead(8)
        Result(ShellNoz, iC, iB).SP = 0
    End Sub
End Module