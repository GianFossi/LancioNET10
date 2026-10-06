Option Strict Off
Option Explicit On 
Imports RoutBase1
Module Branches
    Private Adispon, CorrShell As Single
    Private AdisponExt As Single '140506
    Public MNT, minUG45b As Single 'spessore del tronchetto standard al netto della tolleranza
    Private TX As Single '9-1-99
    Private c, a, TS1, b, d As Single
    Private ts2, TS21, TS22, TS3 As Single
    Private TN21, TSX, TN1, TN22 As Single
    Private TNX, TN3, TN2, TN4 As Single
    Private TN52, TN51, TN6 As Single
    Private TN5, TNY As Single
    Private TCX, TCNY As Single
    Private DIN, rtg, DNN, DON As Single
    Private OptimTX, BNoRinf As Boolean
    Private Alfa1, Alfa2 As Single
    Private beta, DCL, DTL As Single
    Private AllFOpe, AllFRoo As Single
    Private P0sav, DNSav As Single
    Private RNSav, TCNSav As Single
    Private Corros, fact As Single
    Private ang1, bet, tdd As Single
    Private iApp, iTipo As Short
    Private KZ As Single
    Private uu As String
    Private trh, rc, tcs, Trs, CosecB As Single
    Private ke, ky, LC As Single
    Private ang, t0hy, Rcon As Single
    Private DCLnet, SWR As Single
    Private LimNoz, Limit, Esito As Short
    Private Issue As ASMERES
    Private SavLS, SavTE As Single
    Private Posiz0(3) As String
    Private Posiz1(4) As String
    Private Posiz2(2) As String
    Private Posiz3(5) As String
    Private PosizC(2) As String
    Private iDisp As Short
    Function App17b(ByRef t As Single, ByRef tn As Single, ByRef Rshell As Single, ByRef Rm As Single, ByRef Rnoz As Single, ByRef Rnm As Single, ByRef tepad As Single, ByRef ae As Single, ByRef Sall As Single, ByRef nn As Short) As Boolean
        Dim LNozB, LSDisp, aepadB As Single
        Dim Largh, SpessFl, AltezTrans As Single
        Try
            If 2 * Rshell / inc <= 60 Then Exit Function
            If 2 * Rnoz / inc <= 40 Then Exit Function
            If 2 * Rnoz < 3.4 * System.Math.Sqrt(Rshell * t) Then Exit Function
            App17b = True
2000:       Alnoz = CSng(System.Math.Sqrt(Rnm * tn) + tepad)
            '==============================================
            '           If Nozzles(kLato, nn).Tipo = "LWN1" Then
            '             If Nozzles(kLato, nn).LX > 0 Then 'LX altezza dell'autorinforzo
            '2010         If Alnoz > Nozzles(kLato, nn).LX Then Alnoz = Nozzles(kLato, nn).LX
            '             End If
            '           End If
            '================================================
            If Nozzles(kLato, nn).LXdisp > 0 Then 'LXdisp altezza disponibile sotto flangia
                If Alnoz > Nozzles(kLato, nn).LXdisp Then Alnoz = Nozzles(kLato, nn).LXdisp
            End If
            Alshe = CSng(System.Math.Sqrt(Rm * t))
2020:       LSDisp = Nozzles(kLato, nn).LSDisp
            If LSDisp > 0 Then
                If Alshe > LSDisp - tn Then Alshe = LSDisp - tn
            End If
            If ae > Alshe Then ae = Alshe
2030:       Area = Alshe * t + tepad * ae + tn * (Alnoz + t)
            aepadB = ae
            '            If Nozzles(kLato, nn).Tipo = "LWN1" Then
            '              tn = (Nozzles(kLato, nn).DiOn - Nozzles(kLato, nn).DiIn) / 2
            '              aepadB = Nozzles(kLato, nn).HX - tn
            '              tepad = Nozzles(kLato, nn).LX
            '            End If
            LNozB = tepad + 16 * tn
            If LNozB < System.Math.Sqrt(Rnm * tn) + tepad Then LNozB = CSng(System.Math.Sqrt(Rnm * tn) + tepad)
            Select Case Left(Nozzles(kLato, nn).Tipo, 1)
                Case "W", "L"
                    If LNozB > Nozzles(kLato, nn).LXdisp Then 'anche flangia
                        If LNozB > Nozzles(kLato, nn).LXdisp + Nozzles(kLato, nn).Altezza Then
                            Caso17b = 2
                            AlnozB = Nozzles(kLato, nn).LXdisp + Nozzles(kLato, nn).Altezza
                        Else
                            Caso17b = 1
                            AlnozB = LNozB
                        End If
                    Else
                        AlnozB = LNozB
                        If AlnozB > Nozzles(kLato, nn).LXdisp Then AlnozB = Nozzles(kLato, nn).LXdisp
                        Caso17b = 0
                    End If
                Case Else
                    AlnozB = LNozB
                    If AlnozB > Nozzles(kLato, nn).LXdisp Then AlnozB = Nozzles(kLato, nn).LXdisp
                    Caso17b = 0
            End Select
            AlsheB = 16 * t
            If LSDisp > 0 Then
                If AlsheB > LSDisp - tn Then AlsheB = LSDisp - tn
            End If
            If aepadB > AlsheB Then aepadB = AlsheB
            If tepad > AlnozB Then tepad = AlnozB
            Amom = AlsheB * t * t / 2 + tepad * aepadB * (t + tepad / 2) + tn * (AlnozB + t) * (AlnozB + t) / 2
            AreaB = AlsheB * t + tepad * aepadB + tn * (Alnoz + t)
            If Nozzles(kLato, nn).Tipo = "LWN1" Then
                AltezTrans = CSng(aepadB * System.Math.Tan(Nozzles(kLato, nn).TransitionAngle * pi / 180))
                Amom = Amom + AltezTrans * aepadB / 2 * (t + tepad + AltezTrans / 3)
                AreaB = AreaB + AltezTrans * aepadB / 2
            End If
            SpessFl = 0
            If Caso17b > 0 And AlnozB > Nozzles(kLato, nn).LXdisp + Nozzles(kLato, nn).Altezza - Nozzles(kLato, nn).Spessore Then
                SpessFl = (AlnozB > Nozzles(kLato, nn).LXdisp + Nozzles(kLato, nn).Altezza - Nozzles(kLato, nn).Spessore)
                Largh = (Nozzles(kLato, nn).DiamExt - Nozzles(kLato, nn).DiOn) / 2
                Amom = Amom + ((AlnozB + t) ^ 2 - (Nozzles(kLato, nn).LXdisp + Nozzles(kLato, nn).Altezza - Nozzles(kLato, nn).Spessore) ^ 2 + t) / 2 * Largh
                AreaB = AreaB + (AlnozB - (Nozzles(kLato, nn).LXdisp + Nozzles(kLato, nn).Altezza - Nozzles(kLato, nn).Spessore)) * (Nozzles(kLato, nn).DiamExt - Nozzles(kLato, nn).DiOn) / 2
            End If
            aneu = Amom / AreaB
2040:       Aine = AlsheB * t * t * t / 12 + AlsheB * t * (aneu - t / 2) ^ 2
            Aine = Aine + aepadB * tepad ^ 3 / 12 + aepadB * tepad * (aneu - t - tepad / 2) ^ 2
            Aine = Aine + tn * (AlnozB + t) ^ 3 / 12 + tn * (AlnozB + t) * ((AlnozB + t) / 2 - aneu) ^ 2
            If Caso17b > 0 And SpessFl > 0 Then
                Aine = Aine + Largh * SpessFl ^ 3 / 12 + Largh * SpessFl * (AlnozB - SpessFl / 2 - aneu) ^ 2
            End If
            If Nozzles(kLato, nn).Tipo = "LWN1" Then
                Aine = Aine + AltezTrans ^ 3 * aepad / 36 + AltezTrans * aepad / 2 * (t + tepad + AltezTrans / 3 - aneu) ^ 2
            End If
2050:       Sm = P0 * (Rshell * (Rnoz + tn + Alshe) + Rnoz * (t + Alnoz)) / Area
            Amom = (Rnoz ^ 3 / 6 + Rshell * Rnoz * (aneu - t / 2)) * P0
            sb = Amom * aneu / Aine
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function

    Sub Aree(ByRef nn As Short, ByRef App17 As Short, ByRef Limits As Short, ByRef LimNoz As Short, ByRef Esito As Short, ByRef LSH As Single)
        Dim Testo As String
        Dim LSXX, LNSav As Single
        Dim AlfaSS1, AVP, AlfaSS2 As Single
        Dim H1, Alfa1, Alfa2, H2 As Single
        Dim Sommita, Rintercetta As Single
        Dim Altezza, Base As Single
        Dim BaseMinore, SovraFascia As Single
        Dim Alfa3, Alfa4 As Single
        Dim LunghRastrem, H3, H4, LatoTrapezio As Single
        Dim LN3, R3, R4, LNSav3 As Single
        Esito = True
        Try
            A3 = 0
            LimNoz = 0
            Select Case Config(0).SpecialRinf
                Case 0
                    A0 = DN * TRV * Ffact + 2 * TCN * TRV * Ffact * (1 - FR1)
                Case 1
                    A0 = DN * TCVSav * Ffact + 2 * TCN * TCVSav * Ffact * (1 - FR1)
            End Select
            If App17 Then A0 = A0 * 2 / 3
            A0Int = A0
            A0Ext = 0
            If Config(kLato).Vacuum And Not VerificandoPI Then
                Select Case Config(0).SpecialRinf
                    Case 0
                        A0Ext = (DN * SpxBExt * Ffact + 2 * TCN * SpxBExt * Ffact * (1 - FR1)) / 2
                    Case 1
                        A0Ext = (DN * TCVSav * Ffact + 2 * TCN * TCVSav * Ffact * (1 - FR1)) / 2
                End Select
                If App17 Then A0Ext = A0Ext * 2 / 3
                kNozzle = nn                               '140506
                If SpBocchExt = 0 Then Call trPressExt(0, 0, 0, SpBocchExt, True) '140506
                If SpBocchExt = 0 Then Esito = False : Exit Sub
            End If
            'limits of the reinforcement along the shell
            LS1 = (DN - Rn) : LS2 = TCV + TCN '!! aggiunto : +TCN
            If App17 Then LS1 = LS1 / 2
            If LS1 < LS2 Then LSXX = LS2 Else LSXX = LS1
            If LSXX < Ls Then Ls = LSXX : Limits = False Else Limits = True
            Select Case Config(0).SpecialRinf
                Case 0
                    a1 = 2 * Ls * (E1 * TCV - Ffact * TRV) - 2 * TCN * (E1 * TCV - Ffact * TRV) * (1 - FR1)
                Case 1
                    a1 = 2 * Ls * (E1 * TCV - Ffact * TCV) - 2 * TCN * (E1 * TCV - Ffact * TCV) * (1 - FR1)
            End Select
            If Config(kLato).Vacuum And Not VerificandoPI Then '140506
                Select Case Config(0).SpecialRinf
                    Case 0
                        a1ext = 2 * Ls * (E1 * TCV - Ffact * SpxBExt) - 2 * TCN * (E1 * TCV - Ffact * SpxBExt) * (1 - FR1)
                    Case 1
                        a1ext = 2 * Ls * (E1 * TCV - Ffact * TCV) - 2 * TCN * (E1 * TCV - Ffact * TCV) * (1 - FR1)
                End Select
            End If
            'If a1 < 0 Then Stop
            '--------------------------------------
            'GoSub Area2
            'limits of the reinforcement perpendicular to the vessel wall
            LN1 = 2.5 * TCV
RifLN:      LN2 = 2.5 * TCN + TE
            If TX > TCN And Nozzles(kLato, nn).Tipo = "LWN1" Then LN2 = 2.5 * TX + TE
            LN = LN1
            If LN > LN2 Then LN = LN2
            'LNSav = LN
            'If TE = 0 And AlfaS <> 0 Then
            'AlfaSS1 = GlobalRoutines.asin(DN / 2 / (LSH + TCV))
            'AlfaSS2 = GlobalRoutines.asin((DN / 2 + TRN) / (LSH + TCV))
            'LN = LN * System.Math.Cos(AlfaSS1)
            'If LN > LXdisp Then LN = LXdisp
            'LN = LN + (LSH + TCV) * (System.Math.Cos(AlfaSS1) - System.Math.Cos(AlfaSS2))
            'Else
            'If LN > LXdisp Then LN = LXdisp
            'LNSav = LN
            'End If
            If TE > LN Then TE = LN : LimNoz = 1 : GoTo RifLN
            a2 = 2 * LN * (TCN - TRN) * FR2
            If A0Ext > 0 Then '140506
                a2ext = 2 * LN * (TCN - SpBocchExt) * FR2
            End If                                             '140506
            'LN = LNSav
            'If TE = 0 And AlfaS <> 0 Then
            'Alfa1 = AlfaSS2
            'Alfa2 = GlobalRoutines.asin((DN / 2 + TCN) / (LSH + TCV))
            'H1 = 0 ' Rm * (COS(AlfaS) - COS(Alfa1))
            'H2 = (LSH + TCV) * (System.Math.Cos(Alfa1) - System.Math.Cos(Alfa2))
            'a2 = a2 + 2 * (H1 + H2) / 2 * (TCN - TRN) * FR2 - (LSH + TCV) ^ 2 * (Alfa2 - Alfa1 - System.Math.Sin(Alfa2 - Alfa1)) * FR2
            'Sommita = (LSH + TCV) * System.Math.Cos(AlfaSS1) + LXdisp
            'If LXdisp > LN Then a2 = a2 + 2 * (LXdisp - LN) * (TCN - TRN) * FR2
            'Rintercetta = 0
            'Rintercetta = System.Math.Sqrt((LSH + TCV + LN) ^ 2 - Sommita ^ 2)
            'Select Case Rintercetta
            '    Case Is < (LSH + TCV) * System.Math.Sin(Alfa1)
            'Alfa3 = GlobalRoutines.asin((DN / 2 + TRN) / (LSH + TCV + LN))
            'H3 = Sommita - (LSH + TCV + LN) * System.Math.Cos(Alfa3)
            'R3 = DN / 2 + TRN
            'Alfa4 = GlobalRoutines.asin((DN / 2 + TCN) / (LSH + TCV + LN))
            'H4 = Sommita - (LSH + TCV + LN) * System.Math.Cos(Alfa4)
            'R4 = DN / 2 + TCN
            '    Case Is > (LSH + TCV) * System.Math.Sin(Alfa2)
            'H3 = 0 : H4 = 0 'non fare niente
            '    Case Else
            'Alfa3 = GlobalRoutines.asin(Rintercetta / (LSH + TCV + LN))
            'H3 = 0 : R3 = Rintercetta
            'Alfa4 = GlobalRoutines.asin((DN / 2 + TCN) / (LSH + TCV + LN))
            'H4 = Sommita - (LSH + TCV + LN) * System.Math.Cos(Alfa4)
            'R4 = DN / 2 + TCN
            'End Select
            'If H3 > 0 Or H4 > 0 Then a2 = a2 - 2 * (H3 + H4) / 2 * (R4 - R3) * FR2 + (LSH + TCV + LN) ^ 2 * (Alfa4 - Alfa3 - System.Math.Sin(Alfa4 - Alfa3)) * FR2
            If Nozzles(kLato, nn).Tipo = "LWN3" Then
                a2 = a2 - 2 * Nozzles(kLato, nn).PadT * FR2
            End If
            'End If
            If NozzAdd(kLato, nn).Protusion > 0 Then
                'GoSub Area3-----------------------------------------------
                'limits of the reinforcement perpendicular to the vessel wall
                LN1 = 2.5 * TCV
                LN2 = 2.5 * TCN + TE
                LN3 = LN1
                If LN3 > LN2 Then LN3 = LN2
                'LNSav3 = LN3
                'If TE = 0 And AlfaS <> 0 Then
                'AlfaSS1 = GlobalRoutines.asin(DN / 2 / (LSH))
                'AlfaSS2 = GlobalRoutines.asin((DN / 2 + TRN - AN) / (LSH))
                'LN3 = LN3 * System.Math.Cos(AlfaSS1)
                'If LN3 > NozzAdd(kLato, nn).Protusion - AN Then LN3 = NozzAdd(kLato, nn).Protusion - AN
                'LN3 = LN3 + LSH * (System.Math.Cos(AlfaSS1) - System.Math.Cos(AlfaSS2))
                'Else
                If LN3 > NozzAdd(kLato, nn).Protusion - AN Then LN3 = NozzAdd(kLato, nn).Protusion - AN
                'LNSav3 = LN3
            End If
            A3 = 2 * LN3 * (TCN - AN) * FR2
            'LN3 = LNSav3
            'If TE = 0 And AlfaS <> 0 Then
            'Alfa1 = AlfaSS2
            'Alfa2 = GlobalRoutines.asin((DN / 2 + TCN) / (LSH))
            'H1 = 0 ' Rm * (COS(AlfaS) - COS(Alfa1))
            'H2 = LSH * (System.Math.Cos(Alfa1) - System.Math.Cos(Alfa2))
            'A3 = A3 - 2 * (H1 + H2) / 2 * (TCN - AN) * FR2 - (LSH) ^ 2 * (Alfa2 - Alfa1 - System.Math.Sin(Alfa2 - Alfa1)) * FR2
            'Sommita = (LSH) * System.Math.Cos(AlfaSS1) - NozzAdd(kLato, nn).Protusion + AN
            'If NozzAdd(kLato, nn).Protusion - AN > LN Then A3 = A3 + 2 * (NozzAdd(kLato, nn).Protusion - AN - LN) * (TCN - TRN) * FR2
            'Rintercetta = System.Math.Sqrt((LSH - LN3) ^ 2 - Sommita ^ 2)
            'Select Case Rintercetta
            '    Case Is > (LSH) * System.Math.Sin(Alfa2)
            'Alfa3 = GlobalRoutines.asin((DN / 2) / (LSH - LN))
            'H3 = Sommita - (LSH - LN) * System.Math.Cos(Alfa3)
            'R3 = DN / 2 + AN
            'Alfa4 = GlobalRoutines.asin((DN / 2 + TCN - AN) / (LSH - LN))
            'H4 = Sommita - (LSH - LN) * System.Math.Cos(Alfa4)
            'R4 = DN / 2 + TCN - AN
            '    Case Is < (LSH) * System.Math.Sin(Alfa1)
            'H3 = 0 : H4 = 0 'non fare niente
            '    Case Else
            'Alfa3 = GlobalRoutines.asin(Rintercetta / (LSH - LN))
            'H3 = 0 : R3 = Rintercetta
            'Alfa4 = GlobalRoutines.asin((DN / 2 + TCN - AN) / (LSH - LN))
            'H4 = Sommita - (LSH - LN) * System.Math.Cos(Alfa4)
            'R4 = DN / 2 + TCN - AN
            'End Select
            'If H3 < 0 Or H4 < 0 Then A3 = A3 + 2 * (H3 + H4) / 2 * (R4 - R3) * FR2 + (LSH + TCV + LN) ^ 2 * (Alfa4 - Alfa3 - System.Math.Sin(Alfa4 - Alfa3)) * FR2
            'End If
            'End If
            'corretto 9-1-99++++++++++++++
            If Nozzles(kLato, nn).Tipo.Trim = "WN1" Or Nozzles(kLato, nn).Tipo = "LWN1" Then
                Esito = ErroreLS()
                If Not Esito Then Exit Sub
                If (Ls - TCN) < ((Dp - DN - 2 * TCN) / 2) Then
                    AVP = 2 * (Ls - TCN) * TE * FR4
                Else
                    AVP = (Dp - DN - 2 * TCN) * TE * FR4 'UG-37.1
                End If
                A5 = AVP
                'messa in conto del taper negli autorinforzati=================
                XXX(3, 58) = 0
                If Nozzles(kLato, nn).Tipo = "LWN1" And XXX(1, 58) > 0 Then
                    SovraFascia = (XXX(1, 58) - TE)
                    If LN < XXX(1, 58) Then SovraFascia = LN - TE
                    If SovraFascia > 0 Then
                        Base = (Dp - DN - 2 * TCN) / 2
                        If Base > 0 Then
                            Altezza = Base * System.Math.Tan(Nozzles(kLato, nn).TransitionAngle * pi / 180)
                            BaseMinore = Base * (Altezza - SovraFascia) / Altezza
                            If BaseMinore < 0 Then BaseMinore = 0
                            If Altezza < SovraFascia Then SovraFascia = Altezza
                            XXX(3, 58) = (Base + BaseMinore) * SovraFascia * FR4
                            A5 = A5 + XXX(3, 58)
                        End If
                    End If
                End If
                '==============================================================
            ElseIf Nozzles(kLato, nn).Tipo = "LWN2" Then
                'qui Dp Ë stato depurato (in BranchesCal) della larghezza della rastremazione
                Esito = ErroreLS()
                If Not Esito Then Exit Sub
                If (Ls - TCN) < ((Dp - DN - 2 * TCN) / 2) Then
                    AVP = 2 * (Ls - TCN) * (TE - TCV) * FR2
                Else
                    AVP = (Dp - DN - 2 * TCN) * (TE - TCV - CorrShell) * FR2 'UG-37.1
                End If
                LunghRastrem = 3 * (TE - TCV - CorrShell)
                If LunghRastrem > 0 Then
                    If (Dp - DN) / 2 < Ls Then
                        If Dp / 2 + LunghRastrem - DN / 2 < Ls Then
                            LatoTrapezio = 0
                        Else
                            LatoTrapezio = (1 - (Ls + DN / 2 - Dp / 2) / LunghRastrem) * (TE - TCV - CorrShell)
                            LunghRastrem = Ls + DN / 2 - Dp / 2
                        End If
                        AVP = AVP + (LatoTrapezio + TE - TCV - CorrShell) * LunghRastrem
                    End If
                End If
                A5 = AVP
            Else
150:            A5 = 0
            End If
            'corretto 9-1-99+++++++++++
            If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Then
                A41 = NozzAdd(kLato, nn).Leg41 ^ 2 * FR3
                A42 = NozzAdd(kLato, nn).Leg42 ^ 2 * FR4
                If Rn + Ls < Nozzles(kLato, nn).Padd / 2 + NozzAdd(kLato, nn).Leg42 Then A42 = 0
                A43 = NozzAdd(kLato, nn).Leg43 ^ 2 * FR2
                If NozzAdd(kLato, nn).UW16 = 23 Or NozzAdd(kLato, nn).Protusion = 0 Then A43 = 0
            Else
                A41 = NozzAdd(kLato, nn).Leg41 ^ 2 * FR2
                A42 = 0
                A43 = NozzAdd(kLato, nn).Leg41 ^ 2 * FR2
                If NozzAdd(kLato, nn).UW16 = 23 Or NozzAdd(kLato, nn).Protusion = 0 Then A43 = 0
            End If
        Catch e As Exception
            Testo = "I dati geometrici presentano qualche incongruenza. " + vbCrLf
            Testo = Testo + e.Message + vbCrLf + e.StackTrace
            MessageBox.Show(Testo, "AsmeVip - Calcolo Aperture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Esito = False
        End Try
    End Sub
    Private Function ErroreLS() As Boolean
        If Ls < TCN Then
            'Dim Testo As String = "        Errore:|"
            'Testo = Testo & "La lunghezza disponibile per il rinforzo lungo il |"
            'Testo = Testo & "mantello risulta inferiore allo spessore del boc- |"
            'Testo = Testo & "chello. Si ricorda che tale lunghezza va sempre   |"
            'Testo = Testo & "contata dal pelo interno dell'apertura."
            MostraAiuto(2105)
            Return False
        Else
            Return (True)
        End If
    End Function
    Function BranchesCal(ByRef LSH As Single, ByRef rc As Single, ByRef SSS As Single, ByRef dns As Single, ByRef TNS As Single, _
    ByRef Trs As Single, ByVal tcs As Single, ByRef KZ As Single, ByRef eh As Single, ByRef SWR As Single, ByRef nn As Short, _
    ByRef jmemb As Short, Optional ByRef ImpostoNoRinf As Boolean = False, Optional ByVal OnCover As Boolean = False) As Short
        Dim y, tsh, tch As Single
        Dim MK, MN As String
        Dim icount As Short
        Dim EN, ONn As Single
        Dim ii As Short
        Dim TNN As Single
        Dim DONY, ANYY, SNX, RONY As Single
        Dim RCN, RON, DINY, RCNY As Single
        Dim Testo As String = ""
        Dim T0N, T0 As Single
        Dim ZEH, ZSN, TRNY As Single
        Dim TMN, T0NY, TMNY As Single
        Dim xStr As String
        Dim Stringa(7) As String
        Dim junk As Short
        Dim RNY As Single
        Dim TEN As Single
        Dim TNNSAV, TNNY, TNNYSAV As Single
        Dim DTL, DCL, DCLY, DTLY As Single
        Dim LSDisp, CosecB, LSY As Single
        Dim i As Short
        Dim LNY As Single
        Dim iV, LARNO As Short
        Dim LSsav, TEsav As Single
        Dim LimNoz, Limits, Esito As Short
        Dim TEY, TXY, LXY, A0Y As Single
        Dim A2Y, A1Y, A5Y As Single
        Dim N5 As Short
        Dim Risult(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        Dim Sall, tepad As Single
        Dim iOK, iPath As Boolean
        Dim sign As String
        Dim pr, DPY, beta, pr0 As Single
        Dim MatGr As String = ""
        Dim jmemb1, No As Short
        Dim tcs1, Corr As Single
        Dim lContinuoAuto As Boolean
        Dim lTrs As Single
        Dim uu As String = ""
        Dim tfinto As Single
        Dim Tronch As New Involucro
        Tronch.Initialize()
        No = 0
        lContinuoAuto = ContinuoAuto
        BranchesCal = True
        nIndent = 3
        PrintlstRes("Calcolo di *** " & Trim(Nozzles(kLato, nn).Mark) & " ***")
        If swn < 0 Then jmemb1 = -jmemb Else jmemb1 = jmemb
        If Involucr(kLato, jInvolucr).OS = 0 Then CorrShell = Involucr(kLato, jInvolucr).cs * CondizioniCorrose Else CorrShell = Involucr(kLato, jInvolucr).OS '9-1-99
        If Left(Nozzles(kLato, nn).Mark, 1) = "-" Then Exit Function
        Try
            If div = 0 Or div = 2 Then AggiustaHydr(kLato, 0, nn, P0, VerificandoPI)
            SS = SSS
            '      sp = SS      'ammissibile pezza ATTENZIONE
            Select Case Nozzles(kLato, nn).Tipo.Trim
                Case "WN1"
                Case Else
                    Nozzles(kLato, nn).AllPad = 0
                    Nozzles(kLato, nn).AllPadPI = 0
            End Select
            If VerificandoPI Then
                SP = Nozzles(kLato, nn).AllPadPI
            Else
                SP = Nozzles(kLato, nn).AllPad
            End If
            If SP = 0 Then SP = SS
            y = 1
            trh = TNS 'spessore di calcolo shell con e=1
            tsh = Trs 'spessore di calcolo shell per bocchello
            tcs1 = Nozzles(kLato, nn).ShThkNozArea
            Corr = Involucr(kLato, jInvolucr).cs * CondizioniCorrose
            If Involucr(kLato, jInvolucr).OS > Corr Then Corr = Involucr(kLato, jInvolucr).OS
            tcs1 = tcs1 - Corr
            If tcs1 > tcs / 4 And tcs1 < tcs * 4 Then tcs = tcs1
            tch = tcs 'spessore shell al netto OVY/Corr
inizio:
            icount = 0
            MK = Nozzles(kLato, nn).Mark
            MN = Nozzles(kLato, nn).MATE
            rtg = Nozzles(kLato, nn).Rati
            DNN = Nozzles(kLato, nn).DiaN
            DIN = Nozzles(kLato, nn).DiIn
            DON = Nozzles(kLato, nn).DiOn
            If Nozzles(kLato, nn).Tipo = "Sola" Then GoTo Salta
            EN = Nozzles(kLato, nn).EffN
            ONn = Nozzles(kLato, nn).ONn
            CN = Nozzles(kLato, nn).CorrA * CondizioniCorrose
            SWR = Nozzles(kLato, nn).SWR : If SWR > 9 Then SWR = SWR - 10
            '----------------------------!!!!!!!!!!--------------------
            SWR = 0
            '----------------------------------------------------------
            MNT = 0
            If Not Nozzles(kLato, nn).Tipo = "SPC1" Then
                For ii = 1 To 30
                    If Nozzles(kLato, nn).DiOn < MMM(1, ii) * inc Then Exit For
                Next
                If ii > 1 Then ii = ii - 1
                MNT = MMM(3, ii) - Nozzles(kLato, nn).MNT / 100 * MMM(3, ii)
            End If
            TNN = (DON - DIN) / 2
            If Nozzles(kLato, nn).Tipo.Trim = "WN" Then TNN = Nozzles(kLato, nn).Spess
            XXX(1, 24) = TNN : XXX(1, 25) = TNNY
12830:      If ONn = 0 Then AN = CN Else AN = ONn
            ANYY = AN / inc
            DONY = DON / inc
            RON = DON / 2
            RONY = RON / inc
            DINY = DIN / inc
            RCN = DIN / 2 + AN
            RCNY = RCN / inc
            If SWR = 1 Or SWR = 11 Then RBra = RON Else RBra = RCN
            If Not VerificaAllN(nn, jmemb1, Sn) Then BranchesCal = False : Exit Function
            SNX = Sn * psi
            If Sn = 0 Then GoTo inizio
            '      If VerificandoPI Then
            '      Sn = Nozzles(kLato, nn).AllNPI
            '      Else
            '      Sn = Nozzles(kLato, nn).AllN
            '      End If
            '      If Sn = 0 Then
            '                  Testo = "   Non Ë stata specificata la tensione ammissibile.|"
            '          Testo = Testo + "Pregasi provvedere. "
            '               If messagebox.show(clsInizio.ConvertiCr(Testo), vbOKCancel) = vbCancel Then BranchesCal = False: Exit Function
            '               If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False: Exit Function
            '               GoTo inizio
            '      End If
            If Nozzles(kLato, nn).Tipo = "SPC1" Then TRN = 0 : T0N = 0 : GoTo 13980
            With Tronch
                .MATE = Nozzles(kLato, nn).MATE
                .Mark = Nozzles(kLato, nn).Mark
                .ms = 0
                .di = RBra * 2
                .St = Nozzles(kLato, nn).AllN
                .Shydr = Nozzles(kLato, nn).AllNPI
                .cs = Nozzles(kLato, nn).CorrA
                .OS = Nozzles(kLato, nn).ONn
                .ES = EN
            End With
            Call SuperCylThk(P0, td, T0, RBra, ZSN, ZEH, Sn, EN, uu, SWR, lTrs, Tronch, Config(kLato))
            If div = 1 Then
                Select Case Involucr(kLato, jInvolucr).Tipo
                    Case 0 : Cil(Involucr(kLato, jInvolucr), Config(kLato), P0, td, tfinto) ' per ripristinare i valori dell'involucro base
                    Case 1 : Fon(Involucr(kLato, jInvolucr), Config(kLato), P0, td, tfinto)
                    Case 2, 3 : Cono(Involucr(kLato, jInvolucr), Config(kLato), P0, td, tfinto)
                End Select
            End If
            If T0 = 0 Then
                ' ContinuoAuto = False
                nIndent = 6
                Testo = "Dati insufficienti: spessore di calcolo tronchetto nullo"
                PrintlstRes(Testo)
                MsgBox(Testo, MsgBoxStyle.Critical, "AsmeVip")
                BranchesCal = False : Exit Function
            End If
            TRN = lTrs : TRNY = TRN / inc
            T0N = T0 : T0NY = T0N / inc
            TMN = T0 + AN
            If TNN < TMN And (div = 0 Or div = 2) Then
                Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                Testo = Testo & "|  Lo spessore adottato (" & GlobalRoutines.myStr(TNN * kLength, 3, 2, False) & " " & UnitLength & ") Ë in-|"
                Testo = Testo & "feriore al minimo calcolato (" & GlobalRoutines.myStr(TMN * kLength, 3, 2, False) & " " & UnitLength & ").|"
                Testo = clsInizio.ConvertiCr(Testo)
                If MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then BranchesCal = False : Exit Function
                If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                GoTo inizio
            End If
            TMNY = TMN / inc
            '     PRINT " Minimum Code Design Thickness                  "; GD$; " ton =";
            If trh > 0 Then minUG45b = Math.Min(MNT, trh) Else minUG45b = MNT
            minUG45b = minUG45b + AN
            If minUG45b > TNN Then
                xStr = Nozzles(kLato, nn).Xacc
                If xStr <> "X" Then
                    Testo = "   Lo spessore adottato (" & GlobalRoutines.myStr(TNN * kLength, 3, 2, False) & " " & UnitLength & ") non" & vbCrLf
                    Testo = Testo & "rispetta UG-45(b), cioË:  " & GlobalRoutines.myStr(minUG45b * kLength, 3, 2, False) & " " & UnitLength & "." & vbCrLf
                    Testo = Testo & "   Cosa vuoi fare ?"
                    Stringa(1) = "Modificare i dati di input"
                    Stringa(2) = "Procedere ugualmente"
                    junk = Monitor.Motore.Quale(2, "Min.Nozzle Thk: " & RTrim(Nozzles(kLato, nn).Mark), Stringa, "", 1, Testo)
                    Select Case junk
                        Case 1
                            If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                            GoTo inizio
                            '     PRINT " Minimum Nozzle Neck Thickness                  "; GD$
                            '     PRINT " (Not Applicable for Access & Inpection Nozzles Only)  tmn =";
                        Case 2
                        Case Else : BranchesCal = False : Exit Function
                    End Select
                End If
            End If
13680:      If Left(Nozzles(kLato, nn).Tipo, 1) = "L" Then GoTo 13980
            TEN = TNN * (1 - Nozzles(kLato, nn).MNT / 100)
            If TEN < minUG45b Then
                xStr = Nozzles(kLato, nn).Xacc
                If xStr <> "X" Then
                    Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                    Testo = Testo & "|  Lo spessore adottato " & GlobalRoutines.myStr(TEN * kLength, 3, 2, False) & " " & UnitLength & " al net-|"
                    Testo = Testo & "to della tolleranza (" & GlobalRoutines.myStr(Nozzles(kLato, nn).MNT, 3, 2, False) & "%) Ë inferiore|"
                    Testo = Testo & "al requisito UG-45(b) (" & GlobalRoutines.myStr(minUG45b * kLength, 3, 2, False) & " " & UnitLength & ").|"
                    MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo aperture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                    GoTo inizio
                End If
            End If
13920:      If TEN < TMN Then
                Testo = "   Lo spessore adottato " & GlobalRoutines.myStr(TEN * kLength, 3, 2, False) & " " & UnitLength & " al net-|"
                Testo = Testo & "to della tolleranza (" & GlobalRoutines.myStr(Nozzles(kLato, nn).MNT, 3, 2, False) & "%) Ë inferiore|"
                Testo = Testo & "allo spessore di calcolo (" & GlobalRoutines.myStr(TMN * kLength, 3, 2, False) & " " & UnitLength & ").|"
                MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo aperture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                GoTo inizio
            End If
13980:      TNNY = TNN / inc : TNNSAV = TNN : TNNYSAV = TNNY
            XXX(1, 58) = 0
            '      IF rtg = 0 THEN GOTO 14160
            LXdisp = Nozzles(kLato, nn).LXdisp
            If Not ImpostoNoRinf And Not div = 1 Then
                ' GoSub CheckLXdisp----------------------------------------------
                junk = 0
                If LXdisp = 0 Then
                    Testo = " Non Ë stata definita l'altezza disponibile" & vbCrLf
                    Testo = Testo & "per l'area di rinforzo lungo il bocchello."
                    sign = Testo
                    Testo = Testo & "   Cosa vuoi fare?"
                    N5 = 2
                    Stringa(2) = "Non porre alcun limite supplementare al codice"
                    Stringa(1) = "Ritornare ai dati di input"
                    If Not ContinuoAuto Then
                        junk = Monitor.Motore.Quale(N5, "Altezza di rinforzo: " & RTrim(Nozzles(kLato, nn).Mark), Stringa, "", 1, Testo)
                    Else
                        junk = 2
                        PrintlstRes(sign)
                        sign = ""
                    End If
                    Select Case junk
                        Case 2 : LXdisp = 999
                        Case 1
                        Case Else : BranchesCal = False : Exit Function
                    End Select
                End If
            End If
            If junk = 1 Then GoTo Rifai
            If Nozzles(kLato, nn).Tipo = "LWN1" Then
                LX = Nozzles(kLato, nn).LX
                If Not div = 1 Then
                    ' GoSub CheckLX-----------------------------------------------------
                    junk = 0
                    If LX = 0 Then
                        Testo = " Non Ë stata definita l'altezza del ringrosso" & vbCrLf
                        Testo = Testo & "per il bocchello autorinforzante."
                        Testo = Testo & vbCrLf & "   Cosa vuoi fare?"
                        N5 = 2
                        Stringa(1) = "Ritornare ai dati di input"
                        Stringa(2) = "Abbandonare il calcolo"
                        junk = Monitor.Motore.Quale(N5, "Altezza di rinforzo: " & Trim(Nozzles(kLato, nn).Mark), Stringa, "", 1, Testo)
                        Select Case junk
                            Case 1
                            Case Else : BranchesCal = False : Exit Function
                        End Select
                    End If
                End If
                If junk = 1 Then GoTo Rifai
                TX = Nozzles(kLato, nn).HX
                If Not div = 1 Then
                    If TX < TNN Then TX = TNN : Nozzles(kLato, nn).HX = TX
                    If LX < (2.5 * TX) And OptUG40 Then 'caso della figura UW16 (e-1)
14120:                  TE = (TX - TNN) / System.Math.Tan(pi / 6)
                        XXX(1, 58) = TE
                        If TE > LX Then TE = LX
                    Else
                        TNN = TX
                        TE = 0
                        XXX(1, 58) = -1
                    End If
                End If
            Else
                '         TX = tnn
                TX = 0
            End If
            TCN = TNN - AN
            If TX = 0 Then TCX = TNN - AN Else TCX = TX - AN
            TCNY = TCN / inc
14160:      If Nozzles(kLato, nn).Tipo.Trim = "WN" Then
                Rn = DON / 2 - TCN 'PERCHÇ?
            Else
                Rn = DIN / 2 + AN
            End If
14200:      RNY = Rn / inc
            If div = 1 Then Exit Function
            '   ***************************************************
            '     PRINT " REINFORCEMENT of OPENINGS CONSIDERED SEPARATELY "
            '   ***************************************************
            If ImpostoNoRinf Then
                No = 2
                GoTo Salta
            ElseIf OnCover Then
                No = 3
                GoTo Salta
            End If
            LARNO = False
            Dim iErro As Short
            If Not OptimTX Then
                ' GoSub CalcLarno----------------------------------------
                If swn <= 0 Then
                    If dns = 0 Then GoTo 14660
                    If dns > 60 * inc Then GoTo 14610
                    If Nozzles(kLato, nn).Tipo.Trim = "WN" Then GoTo 14590
                    If DIN > 508 Or DIN > (dns / 2) Then iErro = 121 : LARNO = True
                    GoTo 14760
14590:              If DNN > 20 Or DNN > (dns / 2 / inc) Then iErro = 122 : LARNO = True
                    GoTo 14760
14610:              If Nozzles(kLato, nn).Tipo.Trim = "WN" Then GoTo 14640
                    If DIN > 1016 Or DIN > (dns / 3) Then iErro = 123 : LARNO = True
                    GoTo 14760
14640:              If DNN > 40 Or DNN > (dns / inc / 3) Then iErro = 124 : LARNO = True
                    GoTo 14760
14660:              If Config(kLato).di > 1524 Then GoTo 14720
                    If DIN > 508 Or DIN > (Config(kLato).di / 2) Then iErro = 125 : LARNO = True
14700:              If DNN > 20 Or DNN > (Config(kLato).di / 2) Then iErro = 126 : LARNO = True
                    GoTo 14760
14720:              If Nozzles(kLato, nn).Tipo.Trim = "WN" Then
14750:                  If DNN > 40 Or DNN * inc > (Config(kLato).di / 3) Then iErro = 127 : LARNO = True 'aggiunto * inc
                    Else
                        If DIN > 1016 Or DIN > (Config(kLato).di / 3) Then iErro = 128 : LARNO = True
                    End If
                End If
            End If
14760:      If LARNO Then Call Erro(iErro, "AsmeVip - " & Involucr(kLato, jInvolucr).Mark.Trim)
            If TNS > 9.52! Then GoTo 14830
            If DNN <= 3 And DNN > 0 Then
                Call NoRinf(nn)
                If BNoRinf Then No = 1 : GoTo Salta
            End If
14830:      If DNN <= 2 And DNN > 0 Then
                Call NoRinf(nn)
                If BNoRinf Then No = 1 : GoTo Salta
            End If
            DCL = Nozzles(kLato, nn).DCL
            DCLY = DCL / inc
            DTL = Nozzles(kLato, nn).DTL
            DTLY = DTL / inc
            i = AllGeom(nn, jmemb1, tch, tsh, trh, tcs, Trs, rc, LSH, CosecB)
            AlfaS = AlfaS / 2
            Nozzles(kLato, nn).Alfa = AlfaS
            If i = 1 Then GoTo inizio
            If i = 0 Then BranchesCal = False : Exit Function
            Call StrengF(nn)
            XXX(1, 62) = FR1 : XXX(2, 62) = FR2 : XXX(3, 62) = FR3 : XXX(4, 62) = FR4
            E1 = 1
            If Nozzles(kLato, nn).MUN = 1.0! Then E1 = Involucr(kLato, jInvolucr).ES
17199:      ' PRINT " Max.Shell Length Available for Reinforcement   "; GD$; " Ls  =";
            'INPUT LS
            Ls = 999
            LSDisp = Nozzles(kLato, nn).LSDisp
            If LSDisp > 0 Then Ls = LSDisp
            LSY = Ls / inc
            '     PRINT " Max.Nozzle Length Available for Reinforcement  "; GD$; " Ln  =";
            'INPUT LN
            LN = 999
            LNY = LN / inc
            If Nozzles(kLato, nn).Tipo.Trim = "WN1" Or Nozzles(kLato, nn).Tipo = "LWN2" Then
                '   PRINT " Reinforcing Pad Outside Diameter               "; GD$; " Dp  =";
                Dp = Nozzles(kLato, nn).Padd + System.Math.Abs(DN - DLN)
                '   PRINT " Reinforcing Pad Thickness o spessore scarpa    "; GD$; " te  =";
                TE = Nozzles(kLato, nn).PadT
                If Nozzles(kLato, nn).Tipo = "LWN2" Then
                    'Dp = (Dp - 2 * 3 * (TE - AN - TCV)) + Abs(DN - DLN) 'fig UG-40(f)
                    'corretto 9-1-99:
                    Dp = (Dp - 2 * 3 * (TE - TCV - CorrShell)) + System.Math.Abs(DN - DLN) 'fig UG-40(f)
                    If Dp - 2 * 3 * (TE - TCV - CorrShell) < DN + 2 * TCN Then
                        '9-1-99 ++++++++++++++
                        Testo = "        Errore:"
                        Testo = Testo & "Il diametro esterno della scarpa non Ë sufficiente|"
                        Testo = Testo & "per dare spazio alla rastremazione 3:1 prevista dal-|"
                        Testo = Testo & "la Fig UG-41(f)."
                        MessageBox.Show(clsInizio.ConvertiCr(Testo), "Bocchello " & Nozzles(kLato, nn).Mark.Trim, MessageBoxButtons.OK, MessageBoxIcon.Information)
145:                    BranchesCal = False
                        Exit Function
                        '++++++++++++++
                    End If
                    ' TE = TCV + AN corretto 9-1-99: da eliminare in quanto tenuto in conto in Aree
                End If
            ElseIf Nozzles(kLato, nn).Tipo = "LWN1" Then
                Dp = (DN + 2 * TCX) + System.Math.Abs(DN - DLN) '* CosecB       'controllare
            ElseIf Nozzles(kLato, nn).Tipo = "LWN3" Then
                TE = 0
            End If
            iV = 1 : If LARNO Then iV = 2
            '----------------------------------------------------
            LSsav = Ls
            TEsav = TE
            TCVSav = TCV
            For ii = 1 To iV
                Call Aree(nn, (ii = 2), Limits, LimNoz, Esito, LSH)
                If Not Esito Then BranchesCal = False : Exit Function
                XXX(ii, 53) = Ls : XXX(ii, 57) = Limits : XXX(ii, 59) = LimNoz
                Ls = LSsav
                TE = TEsav
14130:          TXY = TX / inc
                LXY = LX / inc
                TEY = TE / inc
                A0Y = A0 / inc / inc
                LSY = Ls / inc
                A1Y = a1 / inc / inc
                LNY = LN / inc
                A2Y = a2 / inc / inc
                A5Y = A5 / inc / inc
                Adispon = a1 + a2 + A3 + A5 + A41 + A42 + A43
                AdisponExt = a1ext + a2ext + A3 + A5 + A41 + A42 + A43
                If A0 <= Adispon And (A0Ext < AdisponExt Or A0Ext = 0) Then '140506
                    If Nozzles(kLato, nn).Tipo = "LWN1" Then Nozzles(kLato, nn).HX = TCX + AN
                    GoTo 18020
                End If
                If OptimTX Then
                    icount = icount + 1
                    If icount < 100 Then
                        Call NewSpess(nn) : GoTo 13680
                    Else
                        Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                        Testo = Testo & "|Non Ë stato possibile trovare una soluzione |adeguata. Provare ad aumentare l'altezza del-|l'autorinforzo"
                        MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo aperture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If junk = 0 Then BranchesCal = False : Exit Function
                        If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                        OptimTX = False
                        GoTo inizio
                    End If
                End If
                Select Case Decision(Testo, jmemb, nn, ii)
                    Case 1 : GoTo 17199
                    Case 2
                        If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                        GoTo inizio
                    Case 3 : junk = 0 : GoTo inizio
                    Case 4 : GoTo 18019
                    Case 5
                        Nozzles(kLato, nn).Tipo = "LWN1"
                        Call NewSpess(nn) : OptimTX = True
                        GoTo 13680
                    Case 0, 6 : BranchesCal = False : Exit Function
                End Select
                'IF A5 = 0 THEN GOTO 17199 'mettere pezza o aumentare de tronchetto
18019:          Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                Testo = Testo & "|La compensazione dell'apertura non Ë verificata.   |"
                lContinuoAuto = False
                GoTo 18021
                'DA VERIFICARE-------------------------------------------------------------
18020:          If ii = 2 Then
                    Testo = "Ulteriore verifica della compensazione|"
                    Testo = Testo & "secondo App.1.7(a) (regola dei 2/3)|"
                    Testo = Testo & "___________________________________||"
                Else
                    Testo = ""
                End If
                Testo = Testo & "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                Testo = Testo & "|La compensazione dell'apertura Ë verificata.   |"
18021:          TNN = TNNSAV : TNNY = TNNYSAV
                Str234(Testo)
                PrintlstRes(Testo)
                If (a1 < 0) Then
                    Testo = Testo & "|===================================="
                    Testo = Testo & "|Attenzione: A1 negativa. Controllare il dato di input"
                    Testo = Testo & "|relativo allo spessore locale del mantello."
                    Testo = Testo & "|===================================="
                End If
                Testo = Testo & "||Si approva? (Premere No per tornare all'input) |"
                If Not ContinuoAuto Then
                    Dim junkMsg As ChiaviMess = Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), ChiaviMess.MessQuestion Or ChiaviMess.MessYesNoCancel, _
                    "AsmeVip - Calcolo Aperture", , , True)
                    If junkMsg = ChiaviMess.MessCancel Then BranchesCal = False : Exit Function
                    If junkMsg = ChiaviMess.Messno Then GoTo Rifai
                End If
                '----------------------------------------------------------
                XXX(ii, 43) = A0 : XXX(ii, 44) = A0Y
                XXX(ii, 45) = a1 : XXX(ii, 46) = A1Y
                XXX(ii, 47) = a2 : XXX(ii, 48) = A2Y
                XXX(ii, 64) = A3
                XXX(ii, 49) = A5 : XXX(ii, 50) = A5Y
                XXX(ii, 51) = a1 + a2 + A3 + A5 + A41 + A42 + A43
                XXX(ii, 52) = XXX(ii, 51) / inc / inc
                XXX(ii, 54) = A41 : XXX(ii, 55) = A42 : XXX(ii, 56) = A43
            Next ii
            If LARNO Then
                If VerificandoPI Then
                    Sall = Nozzles(kLato, nn).AllNPI
                    If swn > -1 Then
                        If Involucr(kLato, jmemb).Shydr < Sall Then Sall = Involucr(kLato, jmemb).Shydr
                    Else
                        If Nozzles(kLato, -jmemb).AllNPI < Sall Then Sall = Nozzles(kLato, -jmemb).AllNPI
                    End If
                Else
                    Sall = Nozzles(kLato, nn).AllN
                    If swn > -1 Then
                        If Involucr(kLato, jmemb).St < Sall Then Sall = Involucr(kLato, jmemb).St
                    Else
                        If Nozzles(kLato, -jmemb).AllN < Sall Then Sall = Nozzles(kLato, -jmemb).AllN
                    End If
                End If
                TBra = tch
                tn = TNN - AN : If TX > tn Then tn = TX - AN
                Rnoz = DIN / 2 + AN : Rnm = Rnoz + tn / 2
                Rshell = dns / 2 + AN : Rm = Rshell + TBra / 2
                tepad = Nozzles(kLato, nn).PadT
                aepad = Nozzles(kLato, nn).Padd / 2 - Rnoz - tn : If aepad < 0 Then aepad = 0
                If Nozzles(kLato, nn).Tipo = "LWN1" Then
                    '  tn = (Nozzles(kLato, nn).DiOn - Nozzles(kLato, nn).DiIn) / 2
                    '  aepad = Nozzles(kLato, nn).HX - tn
                    '  tn = tn - AN
                    '  tepad = Nozzles(kLato, nn).LX
                    ' ' If tepad > 2.5 * tch Then tepad = 2.5 * tch
                End If
                If Rnoz / Rshell > 0.7 Then
                    LARNO = 2
                    Testo = " Verifica sforzi di membrana e di flessione|"
                    Testo = Testo & "secondo App. 1-7(b):|"
                    Testo = Testo & "Non applicabile in accordo a 1-7(b)(1)(c).|"
                    Testo = Testo & "Il rapporto diametro bocchello su diametro mantello|"
                    Testo = Testo & "supera 0.7. Si dovrebbe applicare U-2(g).|"
                    Testo = Testo & "Il calcolo continua."
                    MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf App17b(TBra, tn, Rshell, Rm, Rnoz, Rnm, tepad, aepad, Sall, nn) Then
                    Testo = " Verifica sforzi di membrana e di flessione|"
                    Testo = Testo & "secondo App. 1-7(b):|"
                    Testo = Testo & "  Sm    = " & GlobalRoutines.myStr(Sm * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & " S = " & GlobalRoutines.myStr(Sall * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    Testo = Testo & "|  Sm+Sb = " & GlobalRoutines.myStr((Sm + sb) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & " S = " & GlobalRoutines.myStr(1.5 * Sall * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    Dim vbMsg As ChiaviMess
                    If Sm <= Sall And Sm + sb <= 1.5 * Sall Then
                        Testo = Testo & "||    Sforzi accettabili"
                        vbMsg = ChiaviMess.MessInformation
                    Else
                        Testo = Testo & "||    Sforzi inaccettabili.|    Nota: L'azione pi˘ efficace Ë di aumentare l'altezza|dell'autorinforzo, se previsto."
                        vbMsg = ChiaviMess.MessCritical
                    End If
                    If Not ContinuoAuto Then
                        If Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), vbMsg Or ChiaviMess.MessOKCancel, _
                           "AsmeVip - Calcolo aperture", Proportional:=True) = ChiaviMess.MessCancel Then BranchesCal = False : Exit Function
                    End If
                Else
                    LARNO = 1
                    Testo = " Verifica sforzi di membrana e di flessione|"
                    Testo = Testo & "secondo App. 1-7(b):|"
                    Testo = Testo & "Non necessaria in accordo a 1-7(b)(1)"
                    If Not ContinuoAuto Then Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), ChiaviMess.MessInformation Or ChiaviMess.MessOkOnly, "AsmeVip - Calcolo aperture", Proportional:=True)
                End If
            End If
            Call PathsCal(nn)
            Testo = "" : iOK = True : iPath = False
            For i = 1 To 3
                If NozzAdd(kLato, nn).Paths(i - 1) > 0 Then
                    iPath = True
                    If NozzAdd(kLato, nn).Paths(i - 1) > NozzAdd(kLato, nn).Wcomp(i - 1) Then sign = ">" Else sign = "<" : iOK = False
                    Testo = Testo & "Strength of path" & i.ToString & "-" & LTrim(i.ToString) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Paths(i - 1) * kForce, 7, 0, False) & sign & GlobalRoutines.myStr(NozzAdd(kLato, nn).Wcomp(i - 1) * kForce, 7, 0, False) & " " & UnitForce & "|"
                End If
            Next
            If iPath Then
                If iOK Then
                    '       For i = 1 To 3
                    '         Testo = Testo + Right$(Stringa(i), Len(Stringa(i)) - 1) + "|"
                    '       Next
                    lContinuoAuto = ContinuoAuto
                    If Not lContinuoAuto Then MessageBox.Show(clsInizio.ConvertiCr(Testo))
                    'continuoauto
                Else
                    lContinuoAuto = False
                    Testo = Testo & "|La resistenza delle saldature Ë inadeguata.|"
                    MK = Testo
                    Testo = Testo & "   Cosa vuoi fare ?"
                    Stringa(1) = "Modificare i dati di input"
                    Stringa(2) = "Procedere ugualmente"
                    junk = Monitor.Motore.Quale(2, "AsmeVip - " & Trim(Nozzles(kLato, nn).Mark), Stringa, "", 1, Testo)
                    Select Case junk
                        Case 1
                            If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
                            GoTo inizio
                        Case 2
                            nIndent = 6
                            PrintlstRes(MK)
                            nIndent = 0
                        Case Else : BranchesCal = False : Exit Function
                    End Select
                End If
            End If
            '      Dp = Dp / CosecB
            DPY = Dp / inc
            TEY = TE / inc
Salta:
            x(y, 1) = "UG-37" 'USStr$
            'X$(Y, 2) = nt$: X$(Y, 3) = MK$: X$(Y, 4) = MN$
            XXX(y, 1) = rtg : XXX(y, 2) = DNN
            XXX(y, 3) = DIN : XXX(y, 4) = DINY
            XXX(y, 5) = DON : XXX(y, 6) = DONY
            XXX(y, 7) = Sn : XXX(y, 8) = SNX
            XXX(y, 9) = EN
            XXX(y, 10) = AN : XXX(y, 11) = ANYY
            XXX(y, 12) = RCN : XXX(y, 13) = RCNY
            XXX(y, 14) = RON : XXX(y, 15) = RONY
            XXX(y, 16) = ZSN : XXX(y, 17) = ZSN
            XXX(y, 18) = T0N : XXX(y, 19) = T0NY
            XXX(y, 20) = TRN : XXX(y, 21) = TRNY
            XXX(y, 22) = TMN : XXX(y, 23) = TMNY
            '            XXX(y, 24) = TNN : XXX(y, 25) = TNNY
            XXX(y, 26) = TX : XXX(y, 27) = TXY
            XXX(y, 28) = LXdisp : XXX(y, 29) = LXdisp / inc
            XXX(y, 30) = DCL : XXX(y, 31) = DCLY
            XXX(y, 32) = DTL : XXX(y, 33) = DTLY
            XXX(y, 34) = beta
            XXX(y, 35) = Ls : XXX(y, 36) = LSY
            XXX(y, 37) = LN : XXX(y, 38) = LNY
            If LX < LN And Nozzles(kLato, nn).Tipo = "LWN1" Then XXX(y, 37) = LX : XXX(y, 38) = LX / inc
            XXX(y, 39) = Dp : XXX(y, 40) = DPY
            XXX(y, 41) = TE : XXX(y, 42) = TEY
            XXX(y, 63) = DN
            XXX(y, 64) = DCN
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then
                SuperRatings(pr, pr0, nn, MatGr)
            End If
18042:      Call BraPrint(nn, jmemb1, LARNO, pr, pr0, Sall, MatGr, No, LSH)
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Not VerificandoPI Then
                Call MinTemp(nn, jmemb1, RBra, SWR)
            End If
18043:      If Not Massone(kLato, nn) Then
                ' ContinuoAuto = False
                BranchesCal = False
            End If
            Exit Function
Rifai:
            If Not DatiNozzles(kLato, jmemb1, nn) Then BranchesCal = False : Exit Function
            junk = 0
            GoTo inizio
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub NewSpess(ByVal nn As Short)
        TS1 = (2 * DN * TRV * Ffact - (a2 + A5)) / (E1 * (DN - 2 * TCN * (1 - FR1)))
        a = 2 * E1
        b = 2 * (E1 * TCN * FR1 - TRV * Ffact)
        c = (a2 + A5) - (DN + 2 * TCN) * TRV * Ffact
        d = (b ^ 2 - 4 * a * c)
        If d < 0 Then Call Erro(13)
        TS21 = (-b + System.Math.Sqrt(d)) / (2 * a)
        TS22 = (-b - System.Math.Sqrt(d)) / (2 * a)
        If TS21 > 0 Then GoTo 17630
        If TS22 < 0 Then Call Erro(14)
        ts2 = TS22
        GoTo 17650
17630:  If TS22 > 0 Then Call Erro(15)
        ts2 = TS21
17650:  TS3 = ((DN + 2 * (Ls + TCN)) * TRV * Ffact - (a2 + A5)) / (2 * E1 * (Ls + TCN * FR1))
        If TS1 < ts2 Then TSX = TS1 Else TSX = ts2
        If TS3 > TSX Then TSX = TS3
        TN1 = ((DN * TRV * Ffact + 5 * TCV * TRN * FR2) - (a1 + A5)) / (5 * TCV * FR2 - 2 * TRV * Ffact * (1 - FR1))
        a = 5 * FR2
        b = ((2 * TE - 5 * TRN) * FR2 - 2 * TRV * Ffact * (1 - FR1))
        c = (a1 + A5) - (DN * TRV * Ffact + 2 * TRN * TE * FR2)
        d = (b ^ 2 - 4 * a * c)
        If d < 0 Then Call Erro(13)
        TN21 = (-b + System.Math.Sqrt(d)) / (2 * a)
        TN22 = (-b - System.Math.Sqrt(d)) / (2 * a)
        If TS21 > 0 Then GoTo 17800
        If TS22 < 0 Then Call Erro(14)
        ts2 = TS22
        GoTo 17820
17800:  If TS22 > 0 Then Call Erro(15)
        ts2 = TS21
17820:  TN3 = (2 * LN * TRN * FR2 + DN * TRV * Ffact - (a1 + A5)) / (2 * (LN * FR2 - TRV * Ffact * (1 - FR1)))
        If TN1 > TN2 Then TNX = TN1 Else TNX = TN2
        If TN3 > TNX Then TNX = TN3
        TN4 = ((DN + 2 * TCN) * TRV * Ffact + 5 * TCV * TRN * FR2 - (a1 + A5)) / (5 * TCV * FR2 + 2 * TRV * Ffact * FR1)
        a = 5 * FR2
        b = (2 * TE - 5 * TRN) * FR2 + 2 * TRV * Ffact * FR1
        c = (a1 + A5) - ((DN + 2 * TCN) * TRV * Ffact + 2 * TRN * TE * FR2)
        d = (b ^ 2 - 4 * a * c)
        If d < 0 Then Call Erro(13)
        TN51 = (-b + System.Math.Sqrt(d)) / (2 * a)
        TN52 = (-b - System.Math.Sqrt(d)) / (2 * a)
        If TS21 > 0 Then GoTo 17970
        If TS22 < 0 Then Call Erro(14)
        ts2 = TS22
        GoTo 17990
17970:  If TS22 > 0 Then Call Erro(15)
        ts2 = TS21
17990:  TN6 = (2 * LN * TRN * FR2 + (DN + 2 * TCN) * TRV * Ffact - (a1 + A5)) / (2 * (LN * FR2 + TRV * Ffact * FR1))
        If TN4 > TN5 Then TNY = TN4 Else TNY = TN5
        If TN6 > TNY Then TNY = TN6
        'Trs = tsx
        '      TX = INT(tny + cn + 1)
        TCX = TNY
        If TCX <= Nozzles(kLato, nn).HX - AN Then TCX = Nozzles(kLato, nn).HX + 1 - AN
        Nozzles(kLato, nn).HX = TCX + AN 'tnn
    End Sub
    Private Sub NoRinf(ByVal nn As Short)
        Dim Testo As String = "   Nozzle " & Trim(Nozzles(kLato, nn).Mark) & " Nom.Dia=" & Str(DNN) & " in." & vbCrLf
        Testo = Testo & " SINGLE OPENING NOT REQUIRING REINFORCEMENT " & vbCrLf
        If ContinuoAuto Then
            BNoRinf = Nozzles(kLato, nn).BNoRinf
            If Not BNoRinf Then Testo = Testo & "Calculated anyway, as per user command."
            PrintlstRes(Testo)
        Else
            Testo = Testo & "Do you require to calculate it anyway?"
            If MessageBox.Show(Testo, "AsmeVip - Calcolo aperture", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                BNoRinf = False
            Else
                BNoRinf = True
            End If
            Nozzles(kLato, nn).BNoRinf = BNoRinf
        End If
    End Sub
    Function GeomCon(ByRef nn As Short, ByRef jmemb As Short, ByRef tcs As Single, ByRef Rn As Single, ByRef CosecB As Single) As Short
        Dim Aspp, DCL, ang As Single
        Dim Rcon, DCLnet, T0 As Single
        Dim SWR, beta As Single
        Dim s As Single
        AlfaS = 0
        Fprel = 0.5
        GeomCon = True
        Circonf = False
        DCL = Nozzles(kLato, nn).DCL 'qui ha il senso di distanza punto intersez da piano grande
        If Involucr(kLato, jmemb).OS = 0 Then Aspp = Involucr(kLato, jmemb).cs * CondizioniCorrose Else Aspp = Involucr(kLato, jmemb).OS
40:     ang = Involucr(kLato, jmemb).R0 * pi / 180
        DCLnet = DCL - Involucr(kLato, jmemb).H0 * System.Math.Sin(ang)
        Rcon = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
        Rcon = Rcon - System.Math.Tan(ang) * DCLnet
        XXX(1, 60) = Rcon : XXX(1, 61) = ang * 180 / pi
        If VerificandoPI Then
            s = Involucr(kLato, jmemb).Shydr
        Else
            s = Involucr(kLato, jmemb).St
        End If
        Call SuperConThk(T0, Rcon, ang, 1.0!, s, SWR)
        TRV = T0
        UG37a = 2
        TCV = tcs
        DCN = 2 * Rn
        beta = 90 - Nozzles(kLato, nn).beta - Involucr(kLato, jmemb).R0 'inclinazione su perpendicolare a meridiano
        DLN = DCN / System.Math.Cos(beta * pi / 180)
        CosecB = DLN / DCN
        If Left(Nozzles(kLato, nn).Tipo, 1) = "L" Then Fprel = 0.5 Else Fprel = 1
        If DCN > DLN / Fprel Then
            DN = DCN
            Ffact = Fprel
            Circonf = True
        Else
            DN = DLN
            CosecB = 1
            Ffact = 1.0!
        End If
    End Function
    Function GeomCyl(ByRef nn As Short, ByRef jmemb As Short, ByRef tcs As Single, ByRef Trs As Single, _
    ByRef Rn As Single, ByRef rc As Single, ByRef CosecB As Single) As Short
        Dim beta, DCL, x As Single
        Dim Alfa1, Alfa2 As Single
        AlfaS = 0
        Fprel = 0.5
        GeomCyl = True
        Circonf = False
        DCL = Nozzles(kLato, nn).DCL
        TCV = tcs
        '      PRINT " A1   Square Nozzles on a Cylinder                       "
        '      PRINT "      (with intersecting centre lines)                   "
        '      PRINT
        '      PRINT " A2   Oblique Nozzles on a Cylinder                      "
        '      PRINT "      (with intersecting centre lines)                   "
        '      PRINT
        '      PRINT " A3   Nozzles on a Cylinder                              "
        '      PRINT "      (with centre lines crossing at right angles)       "
        CosecB = 1
        TRV = Trs
        beta = Nozzles(kLato, nn).beta
        DCN = 2 * Rn
        If DCL = 0 Then GoTo 16720
16640:  Rm = rc + TRV / 2
        Try
            x = (DCL + Rn) / Rm
            Alfa1 = pi / 2 - System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
            x = (DCL - Rn) / Rm
            Alfa2 = pi / 2 - System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
            AlfaS = Alfa2 - Alfa1
            DCN = 2 * Rm * System.Math.Sqrt((1 - System.Math.Cos(AlfaS)) / 2)
            CosecB = DCN / 2 / Rn
        Catch e As Exception
            If Not Createsto(nn, jmemb) Then
                Return 0
            Else
                GoTo 16640
            End If
        End Try
        GoTo 16760
16720:  If beta = 90 Then GoTo 16760
        If System.Math.Abs(beta) < 1 Then
            If Not Createsto(nn, jmemb) Then
                Return 0
            Else
                Return 1
            End If
        End If
        DLN = 2 * Rn / System.Math.Sin(beta * pi / 180)
        CosecB = DLN / 2 / Rn
        GoTo 16770
16760:  DLN = 2 * Rn
16770:  If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Then Fprel = 1 Else Fprel = 0.5
        If DCN > DLN / Fprel Then
            DN = DCN
            Ffact = Fprel
            Circonf = True
        Else
            DN = DLN
            Ffact = 1.0!
            CosecB = 1
        End If
    End Function
    Private Function Createsto(ByVal nn As Short, ByVal jmemb As Short) As Boolean
        Dim Testo As String = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
        Testo = Testo & "|  I dati relativi al posizionamento del bocchello |"
        Testo = Testo & "sono inconsistenti. Pregasi controllare."
        If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Return False
        Return DatiNozzles(kLato, jmemb, nn)
    End Function
    Function GeomFon(ByRef nn As Short, ByRef jmemb As Short, ByRef tch As Single, ByRef tsh As Single, _
    ByRef trh As Single, ByRef Rn As Single, ByRef LSH As Single, ByRef CosecB As Single) As Short
        Dim GAMMA2, GAMMA1, gamma As Single
        Dim THETA, x, BETAMAX As Single
        Dim DCLMAX, HC As Single
        Dim iDisp As Short
        Dim DTLMIN, R0 As Single
        Dim KC, L0, AH As Single
        Dim Testo As String
        GeomFon = True
        Circonf = False
        Fprel = 0
        AlfaS = 0
        RetrDisp(nn, iDisp)
        DCL = Nozzles(kLato, nn).DCL
        R0 = Involucr(kLato, jInvolucr).R0
        L0 = Involucr(kLato, jInvolucr).L0
        If Involucr(kLato, jInvolucr).OS = 0 Then AH = Involucr(kLato, jInvolucr).cs * CondizioniCorrose Else AH = Involucr(kLato, jInvolucr).OS
        DCN = 2 * Rn
        DLN = 2 * Rn
        TCV = tch
15140:  If DCL = 0 Then
            beta = Nozzles(kLato, nn).beta
        End If
        '      PRINT " B1   Radial Nozzles on the Dished Zone of a Formed Head "
        '      PRINT
        '      PRINT " B2   Nozzles on the Dished Zone of a Formed Head        "
        '      PRINT "      (with parallel centre lines)                       "
        '      PRINT
        '      PRINT " B3   Nozzles on the Dished Zone of a Formed Head        "
        '      PRINT "      (with perpendicular centre lines)                  "
        '      PRINT
        '      PRINT " Nozzle CL to Head CL Dist.   (ÎCL=0 for B1&B3) "; GD$; " ÎCL =";
        '      INPUT dcl

        '      PRINT " Nozzle CL to Head TL Dist.      (ÎTL=0 for B1&B2) "; GD$; " ÎTL =";
        '      INPUT dtl                                beta=0 per B2&B3
        DTL = Nozzles(kLato, nn).DTL
        TRV = tsh
        If TRV = 0 Then TRV = trh
        Rm = LSH + TRV / 2
15660:  If DCL <> 0 Then
            Call Sub15710(CosecB, Rn)
        ElseIf DTL <> 0 Then
            x = (DTL - Rn) / Rm
            Alfa1 = System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
            x = (DTL + Rn) / Rm
            Alfa2 = System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
            Call Sub15800(CosecB)
        Else
            Call Sub15710(CosecB, Rn)
            DN = 2 * Rn
            CosecB = 1
        End If
        If Involucr(kLato, jmemb).ms = 7 Then GoTo 16350
        If Involucr(kLato, jmemb).ms > 2 Then GoTo 16160
        GAMMA1 = DN / (LSH + tch) / 2
        GAMMA2 = (Rn + TCN + tch) / (LSH + tch)
        If GAMMA1 > GAMMA2 Then gamma = GAMMA1 Else gamma = GAMMA2
        x = 0.4 * Involucr(kLato, jInvolucr).di / (LSH + tch)
        THETA = System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
        BETAMAX = (THETA - gamma)
        If beta = 0 Then
            If DCL = 0 And DTL = 0 Then GoTo 16350 Else GoTo 16100
        End If
        If (beta * pi / 180) > BETAMAX Then GoTo 16300 Else GoTo 16350
16100:  If DCL = 0 Then GoTo 16130
        DCLMAX = (LSH + tch) * System.Math.Sin(BETAMAX)
        If DCL > DCLMAX Then GoTo 16300 Else GoTo 16350
16130:  HC = Involucr(kLato, jmemb).H0 + AH
        DTLMIN = System.Math.Sqrt((LSH + tch) ^ 2 - 0.16 * Config(kLato).di ^ 2) - (LSH - HC)
        DTLMIN = DTLMIN + (LSH + tch) * (System.Math.Cos(BETAMAX) - System.Math.Cos(THETA))
        If DTL < DTLMIN Then GoTo 16300 Else GoTo 16350
16160:  GAMMA1 = DN / (LSH + tch) / 2
        GAMMA2 = (Rn + TCN + tch) / (LSH + tch)
        If GAMMA1 > GAMMA2 Then gamma = GAMMA1 Else gamma = GAMMA2
        x = (0.5 * Config(kLato).di - R0) / (L0 - R0)
        THETA = System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
        'semiangolo apertura calotta
        BETAMAX = (THETA - gamma)
        'angolo massimo al quale puÚ stare il bocchello senza invadere il ginocchio
        Dim Res As DialogResult
        If BETAMAX < 0 Then
            Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
            Testo = Testo & "|  L'apertura Ë di dimensioni superiori a quelle della calotta sferica.|"
            Testo = Testo & "Cambiare i dati|"
            Res = MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo aperture", MessageBoxButtons.OKCancel)
            If Res = DialogResult.Cancel Then
                GeomFon = False : Exit Function
            Else
                If Not DatiNozzles(kLato, jmemb, nn) Then GeomFon = False : Exit Function
                GeomFon = 1 : Exit Function
            End If
        End If
        If iDisp = 1 Then GoTo 16350
        If beta = 0 Then GoTo 16240
        If (beta * pi / 180) > BETAMAX Then GoTo 16300 Else GoTo 16350
16240:  If DCL = 0 Then GoTo 16270
        DCLMAX = (LSH + tch) * System.Math.Sin(BETAMAX)
        If DCL > DCLMAX Then GoTo 16300 Else GoTo 16350
16270:  KC = R0 + AH
        DTLMIN = (KC + tch) * System.Math.Sqrt(1 - (0.5 * Config(kLato).di - R0) ^ 2 / (L0 - R0) ^ 2)
        'profondit‡ rispetto al colletto della transizione toro/calotta
        DTLMIN = DTLMIN + (LSH + tch) * (System.Math.Cos(BETAMAX) - System.Math.Cos(THETA))
        'profondit‡ rispetto al colletto della circonferenza massima di istallazione boccheello sul fondo
        If DTL >= DTLMIN Then GoTo 16350
16300:  'PRINT
        Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
        Testo = Testo & "|  L'apertura cade al di fuori della porzione sferica|"
        Testo = Testo & "del fondo. Cambiare i dati|"
        Res = MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo aperture", MessageBoxButtons.YesNoCancel)
        If Res = DialogResult.Cancel Then
            GeomFon = False : Exit Function
        ElseIf Res = DialogResult.Yes Then
            If Not DatiNozzles(kLato, jmemb, nn) Then GeomFon = False : Exit Function
            GeomFon = 1 : Exit Function
        End If
16350:  'TRV = trh TRV deve rimanere pari a tsh calcolato in SpessXbocch
        Ffact = 1
        Exit Function
    End Function
    Private Sub Sub15800(ByRef CosecB As Single)
        AlfaS = Alfa2 - Alfa1
        DN = 2 * Rm * System.Math.Sin(AlfaS / 2)
        DCN = DN
        CosecB = DN / 2 / Rn
    End Sub
    Private Sub Sub15710(ByRef CosecB As Single, ByVal Rn As Single)
        Dim x As Single = (DCL + Rn) / Rm
        Alfa1 = pi / 2 - System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
        x = (DCL - Rn) / Rm
        Alfa2 = pi / 2 - System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
        Call Sub15800(CosecB)
    End Sub
    Function GeomOid(ByRef nn As Short, ByRef jmemb As Short, ByRef tcs As Single, ByRef Rn As Single, _
                     ByRef CosecB As Single) As Short
        Dim Aspp, DCL, ang As Single
        Dim bet, ang1, DCLnet As Single
        Dim T0, Rcon As Single
        Dim beta, SWR, s As Single
        AlfaS = 0
        Fprel = 0.5
        GeomOid = True
        Circonf = False
        DCL = Nozzles(kLato, nn).DCL 'qui ha il senso di distanza punto intersez da piano grande
        If Involucr(kLato, jmemb).OS = 0 Then
            Aspp = Involucr(kLato, jmemb).cs * CondizioniCorrose
        Else
            Aspp = Involucr(kLato, jmemb).OS
        End If
        ang = Involucr(kLato, jmemb).R0 * pi / 180
        bet = Nozzles(kLato, nn).DTL : If bet > 180 Then bet = 360 - bet
        ang1 = System.Math.Atan(bet / 180 * System.Math.Tan(ang))
        'ridurre l'angolo in funzione di dtl
        DCLnet = DCL - Involucr(kLato, jmemb).H0 * System.Math.Sin(ang) 'H0 raggio ginocchio piccolo
        Rcon = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
        Rcon = Rcon - System.Math.Tan(ang) * DCLnet / 2
        XXX(1, 60) = Rcon : XXX(1, 61) = ang1 * 180 / pi
        If VerificandoPI Then
            s = Involucr(kLato, jmemb).Shydr
        Else
            s = Involucr(kLato, jmemb).St
        End If
        Call SuperConThk(T0, Rcon, ang1, 1.0!, s, SWR)
        TRV = T0
        UG37a = 2
        TCV = tcs
        DCN = 2 * Rn
        bet = Nozzles(kLato, nn).DTL : If bet > 180 Then bet = 360 - bet
        beta = 90 - Nozzles(kLato, nn).beta - Involucr(kLato, jmemb).R0 'inclinazione su perpendicolare a meridiano
        beta = 180 / pi * System.Math.Atan(bet / 180 * System.Math.Tan(beta * pi / 180))
        DLN = DCN / System.Math.Cos(beta * pi / 180)
        CosecB = DLN / DCN
        If Left(Nozzles(kLato, nn).Tipo, 1) = "L" Then Fprel = 0.5 Else Fprel = 1
        If DCN > DLN / Fprel Then
            DN = DCN
            Ffact = Fprel
            Circonf = True
        Else
            DN = DLN
            Ffact = 1.0!
            CosecB = 1
        End If
    End Function
    Sub StrengF(ByRef k As Short)
        FR1 = (Sn / SS)
        FR2 = (Sn / SS)
        FR4 = (SP / SS)
        If FR1 > 1 Then FR1 = 1
        If NozzAdd(kLato, k).TipAbutt > 2 Then FR1 = 1
        If FR2 > 1 Then FR2 = 1
        If FR4 > 1 Then FR4 = 1
        FR3 = FR2 : If FR4 < FR3 Then FR3 = FR4
    End Sub
    Sub BraMAWP(ByRef k As Short, ByRef jmemb As Short, ByRef pr As Single, ByRef pr0 As Single, ByRef LARNO As Short, ByRef No As Short, ByRef LSH As Single)
        Dim i, Ntot As Short
        Dim tepad As Single
        Dim iV, ii As Short
        Dim Sall As Single
        Dim Testo As String
        Dim nc, nex As Short
        Dim AH, p0Sav1, SS As Single
        Dim AllPadV, AllNV As Single
        Dim tsh, tch, trh As Single
        Dim s As Single
        Try
            If Config(0).CalcMAWP = 0 Then Exit Sub
            SavLS = Ls
            SavTE = TE
            If div = 1 Then
                ' If Not BranchesCal(1, rc, s, Involucr(kLato, jmemb).di, Involucr(kLato, jmemb).Spess, Trs, tcs, KZ, Nozzles(kLato, k).EffN, SWR, Int(k), jmemb) Then Exit Sub
                If Not BranchesCal(1, rc, s, Involucr(kLato, jmemb).di, TRV, Trs, tcs, KZ, Nozzles(kLato, k).EffN, SWR, Int(k), jmemb) Then Exit Sub '060706
                AllGeom(k, jmemb, tch, tsh, trh, tcs, Trs, rc, LSH, CosecB)
            End If
            AllNV = Nozzles(kLato, k).AllN
            AllPadV = Nozzles(kLato, k).AllPad
            If div = 1 Then
                CN = Nozzles(kLato, k).CorrA
                AH = Nozzles(kLato, k).CorrA
                If jmemb > 0 Then
                    TCV = Involucr(kLato, jmemb).Spess - CN
                Else
                    TCV = Nozzles(kLato, -jmemb).Spess - CN
                End If
            End If
            For i = 1 To 4 : Nozzles(kLato, k).MAWP(i - 1) = clsTrigon.Infinito : Next
            If Nozzles(kLato, k).Tipo = "Sola" Or No > 0 Then GoTo SalBra
            Ntot = 300
            If a1 + a2 + A3 + A5 + A41 + A42 + A43 < A0 Then Exit Sub
            If Matdim(Nozzles(kLato, k).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, k).indice).Agganciato Then
                Matdim(Nozzles(kLato, k).indice).SigmaAmm(CodiceStress, td, AllFRoo, AllFOpe)
                If AllFOpe * AllFRoo = 0 Then
                    AllFOpe = Nozzles(kLato, k).AllN
                    AllFRoo = Nozzles(kLato, k).AllN
                End If
            Else
                AllFOpe = Nozzles(kLato, k).AllN
                AllFRoo = Nozzles(kLato, k).AllN
            End If 'j
            P0sav = P0
            DNSav = DN
            RNSav = Rn
            TCNSav = TCN
            TCVSav = TCV
            iV = 1 : If LARNO And div = 0 Then iV = 2
            If Not ContinuoAuto Then Monitor.Motore.ProgrInizio("Calcolo MAWP apertura " & Nozzles(kLato, k).Mark.Trim, "AsmeVip", mioApert)
            For ii = 1 To iV
                iApp = (ii = 2)
                For i = 1 To 4
                    iMAWP = i
                    If A5 = 0 And div = 0 Then
                        P0 = P0sav
                        'SenzaPad -------------------------------------------------------
                        nc = 0 : nex = 2
                        Do
                            nc = nc + 1
                            p0Sav1 = P0
                            P0 = System.Math.Sqrt((a1 + a2 + A3 + A41 + A42 + A43) / A0) ^ (1.0! / nex) * P0
                            If nc Mod 20 = 0 Then nex = nex + 1
Rifa:                       Call CalcArea(i, k, jmemb, LSH)
                            'Questo serve per dare soluzioni cin aree non negative.
                            'Se lo si vuol fare bisogna fermare la ricerca anche se l'area disponible 
                            'Ë maggiore dell'area richiesta. Vedi successivo if
                            'If a1 < -0.0001 * A0 Or a2 < -0.0001 * A0 Then
                            '   nex = nex + 1
                            '   If (P0 - p0Sav1) / P0 > 0# Then
                            '      P0 = (P0 + p0Sav1) / 2
                            '   Else
                            '      P0 = P0 * 0.9 ^ (1! / nex)
                            '   End If
                            '   nc = nc + 1
                            '   If nc > Ntot Then Exit Do
                            '   GoTo Rifa
                            'End If
                            If System.Math.Abs(a1 + a2 + A3 + A41 + A42 + A43 - A0) < 0.0001 * A0 Or nc > Ntot Then Exit Do
                        Loop
                        If P0 < Nozzles(kLato, k).MAWP(i - 1) Then Nozzles(kLato, k).MAWP(i - 1) = P0
                    Else
                        P0 = P0sav
                        Call CalcArea(i, k, jmemb, LSH)
                        'ConPad --------------------------------------------------------
                        If Not A0 = 0 Then
1090:                       nc = 0 : nex = 2 : SpBocchExt = 0
                            Do
                                nc = nc + 1
                                p0Sav1 = P0
                                P0 = ((a1 + a2 + A3 + A41 + A42 + A43 + A5) / A0) ^ (1.0! / nex) * P0
Rifa1:                          Call CalcArea(i, k, jmemb, LSH)
                                If TRV > TCV Or a2 < 0 Then
                                    nex = nex + 1
                                    If (P0 - p0Sav1) / P0 < 0.001 And (P0 - p0Sav1) > 0 Then
                                        P0 = (P0 + p0Sav1) / 2
                                    Else
                                        If TRV < TCV Then
                                            P0 = P0 * 0.9 ^ (1.0! / nex)
                                        Else
                                            P0 = P0 * TCV / TRV
                                        End If
                                    End If
                                    nc = nc + 1
                                    If nc > Ntot Then Exit Do
                                    GoTo Rifa1
                                End If
                                If System.Math.Abs(a1 + a2 + A3 + A5 + A41 + A42 + A43 - A0) < 0.0001 * A0 Or nc > Ntot Or System.Math.Abs(TRV - TCV) / TCV < 0.001 Then Exit Do
                            Loop
                        End If
                        If P0 < Nozzles(kLato, k).MAWP(i - 1) Then Nozzles(kLato, k).MAWP(i - 1) = P0
                        If LARNO And ii = 1 And div = 0 Then
                            Sall = SS : If Sn < Sall Then Sall = Sn
                            Select Case i
                                Case 1, 2 : Corros = CN
                                Case 3, 4 : Corros = 0
                            End Select
                            tepad = Nozzles(kLato, k).PadT
                            If Nozzles(kLato, k).Tipo = "LWN1" Then
                                '  tn = (Nozzles(kLato, k).DiOn - Nozzles(kLato, k).DiIn) / 2
                                '  aepad = Nozzles(kLato, k).HX - tn
                                '  tn = tn - Corros
                                '  tepad = Nozzles(kLato, k).LX
                                '' If tepad > 2.5 * TBra Then tepad = 2.5 * TBra
                            End If
                            If LARNO = -1 Then
                                Call App17b(TBra + Corros, tn + Corros, Rshell - Corros, Rm - Corros / 2, Rnoz - Corros, Rnm - Corros / 2, tepad, aepad, Sall, k)
                                fact = Sm / Sall
                                If (Sm + sb) / Sall / 1.5 > fact Then fact = (Sm + sb) / Sall / 1.5
                                P0 = P0 / fact
                                If P0 < Nozzles(kLato, k).MAWP(i - 1) Then Nozzles(kLato, k).MAWP(i - 1) = P0 ': Nozzles(kLato,k).MAWPs(i) = p0
                            End If
                        End If
                    End If
                    If Not ContinuoAuto Then Monitor.Motore.Avanzamento = i * 25 / iV + 50 * (ii - 1)
                Next i
            Next ii
            If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
            iMAWP = 0
            Testo = "    Risultati del calcolo MAWP " & UnitPress & " per: " & Nozzles(kLato, k).Mark.Trim
            Testo = Testo & "|   Nuovo Freddo    Nuovo Caldo   Corr. Freddo    Corr. Caldo  |"
            For i = 1 To 4
                Testo = Testo & New String("-", 7) _
                     & GlobalRoutines.myStr(Nozzles(kLato, k).MAWP(i - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Next i
            Dim Errore1, Errore2 As Boolean
            If pr < 1.0E+20 Then
                Testo = Testo & "|B16.5: " & _
                       GlobalRoutines.myStr(pr0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & "       " _
                     & GlobalRoutines.myStr(pr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & "       " _
                     & GlobalRoutines.myStr(pr0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & "       " _
                     & GlobalRoutines.myStr(pr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                Errore1 = pr0 < Nozzles(kLato, k).MAWP(2) Or pr < Nozzles(kLato, k).MAWP(3)
                Errore2 = pr < P0sav
            End If
            If Not ContinuoAuto Then
                Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), Tit:="AsmeVip - Calcolo aperture", Proportional:=True)
                If Errore1 And Not Errore2 Then MostraAiuto(2103, ChiaviMess.MessInformation Or ChiaviMess.MessHelpButton Or ChiaviMess.MessOkOnly, , _
                                                  "AsmeVip - " & Nozzles(kLato, k).Mark.Trim)
                'il pressure rating Ë inferiore all'MAWP
                If Errore2 Then MostraAiuto(2104, ChiaviMess.MessCritical Or ChiaviMess.MessHelpButton Or ChiaviMess.MessOkOnly, , _
                                                  "AsmeVip - " & Nozzles(kLato, k).Mark.Trim)
                'il pressure rating Ë inferiore al design
            End If
            'continuoauto
            P0 = P0sav
            If div = 1 Then
                Nozzles(kLato, k).Pdes = P0sav
            End If
            Nozzles(kLato, k).AllN = AllNV
            Nozzles(kLato, k).AllPad = AllPadV
SalBra:
            For i = 1 To 4
                If i = 2 Or i = 4 Then
                    If Nozzles(kLato, k).MAWP(i - 1) > pr And pr > 0 Then Nozzles(kLato, k).MAWP(i - 1) = pr
                Else
                    If Nozzles(kLato, k).MAWP(i - 1) > pr0 And pr0 > 0 Then Nozzles(kLato, k).MAWP(i - 1) = pr0
                End If
            Next
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'a
    Private Sub CalcArea(ByVal i As Short, ByVal k As Short, ByVal jmemb As Short, ByVal LSH As Single)
        Select Case i
            Case 1 'nuovo e freddo
                If jmemb > 0 Then
2000:               If div = 0 Or div = 2 Then
                        AH = Involucr(kLato, jmemb).OS
                        If CN > AH Then AH = CN
                    End If
                    SS = Involucr(kLato, jmemb).S0
                Else
                    If div = 0 Or div = 2 Then
                        AH = Nozzles(kLato, -jmemb).ONn
                        If Nozzles(kLato, -jmemb).CorrA > AH Then AH = Nozzles(kLato, -jmemb).CorrA
                    End If
                    SS = Nozzles(kLato, -jmemb).AllN 'sbagliato : room
                End If
                Sn = AllFRoo
                SP = SS
                DN = DNSav - 2 * CN
                Rn = RNSav - CN
                TCN = TCNSav + CN
                TCV = TCVSav + AH
                If div = 1 Then Corros = 0
                tdd = 72
            Case 2 'nuovo e caldo
                If jmemb > 0 Then
                    SS = Involucr(kLato, jmemb).St
                Else
                    SS = Nozzles(kLato, -jmemb).AllN
                End If
                Sn = Nozzles(kLato, k).AllN
                SP = Nozzles(kLato, k).AllPad
                If SP = 0 Then SP = SS
                DN = DNSav - 2 * CN
                Rn = RNSav - CN
                TCN = TCNSav + CN
                TCV = TCVSav + AH
                If div = 1 Then Corros = 0
                tdd = td
            Case 3 'corroso e freddo
2020:           If AH = 0 Then AH = CN
                If jmemb > 0 Then
                    SS = Involucr(kLato, jmemb).S0
                Else
                    SS = Nozzles(kLato, -jmemb).AllN 'sbagliato
                End If
                Sn = AllFRoo
                SP = SS
                DN = DNSav
                Rn = RNSav
                TCN = TCNSav
                TCV = TCVSav
                If div = 1 Then Corros = CN
                tdd = 72
            Case 4 'corroso e caldo
                If jmemb > 0 Then
                    SS = Involucr(kLato, jmemb).St
                Else
                    SS = Nozzles(kLato, -jmemb).AllN
                End If
                Sn = Nozzles(kLato, k).AllN
                SP = Nozzles(kLato, k).AllPad
                If SP = 0 Then SP = SS
                DN = DNSav
                Rn = RNSav
                TCN = TCNSav
                TCV = TCVSav
                If div = 1 Then Corros = CN
                tdd = td
        End Select
        If div = 0 Or div = 2 Then Call StrengF(k)
        'calcola TRV sp. required shell
        If jmemb < 0 Then iTipo = -1 Else iTipo = Involucr(kLato, jmemb).Tipo
        Select Case iTipo
            Case -1 : Call SuperCylThk(P0, td, TRV, Nozzles(kLato, -jmemb).DiIn / 2, KZ, KZ, SS, 1.0!, uu, 0, Trs, Involucr(kLato, jInvolucr), Config(kLato), True)
            Case 0 : Call SuperCylThk(P0, td, TRV, Involucr(kLato, jmemb).di / 2, KZ, KZ, SS, 1.0!, uu, 0, Trs, Involucr(kLato, jmemb), Config(kLato), True)
            Case 1 : Call SpessXbocch(SS, ky, ke, LC, TRV, t0hy, jmemb, AH)
            Case 2
                ang = Involucr(kLato, jmemb).R0 * pi / 180
                DCL = Nozzles(kLato, k).DCL 'qui ha il senso di distanza punto intersez da piano grande
                DCLnet = DCL - Involucr(kLato, jmemb).H0 * System.Math.Sin(ang)
                Rcon = Involucr(kLato, jmemb).di / 2 - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
                Rcon = Rcon - System.Math.Tan(ang) * DCLnet
                If i > 2 Then Rcon = Rcon + CN
                Call SuperConThk(TRV, Rcon, ang, 1.0!, SS, SWR)
            Case 3
                ang = Involucr(kLato, jmemb).R0 * pi / 180
                DCL = Nozzles(kLato, k).DCL 'qui ha il senso di distanza punto intersez da piano grande
                bet = Nozzles(kLato, k).DTL : If bet > 180 Then bet = 360 - bet
                ang1 = System.Math.Atan(bet / 180 * System.Math.Tan(ang))
                'ridurre l'angolo in funzione di dtl
                DCLnet = DCL - Involucr(kLato, jmemb).H0 * System.Math.Sin(ang)
                Rcon = Involucr(kLato, jmemb).di / 2 - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
                Rcon = Rcon - System.Math.Tan(ang) * DCLnet / 2
                Call SuperConThk(TRV, Rcon, ang1, 1.0!, Involucr(kLato, jmemb).St, SWR)
        End Select
        'calcola TRN sp. required nozzle
        If div = 0 Or div = 2 Then
            SWR = Nozzles(kLato, k).SWR : If SWR > 9 Then SWR = SWR - 10
            Call CylThk(P0, td, TRN, RBra, KZ, Sn, 1.0!, SWR)
            Call Aree(k, iApp, Limit, LimNoz, Esito, LSH)
        Else
            '     Issue.SpCop = TRV
            '     Issue.CorrCop = Corros
            '     Issue.AllCop = SS
            '     Issue.SpCopA = 0
            '     Issue.Diam = 0
            Nozzles(kLato, k).Pdes = P0
            Nozzles(kLato, k).Tdes = tdd
            Nozzles(kLato, k).AllN = Sn
            Nozzles(kLato, k).AllPad = SP
            Select Case iTipo
                Case -1, 0, 2, 3
                    OP(Nozzles(kLato, k), NozzAdd(kLato, k), Issue)
                Case 1
                    Nozzles(kLato, k).FactVicini = 0.0#
                    OPSH(Nozzles(kLato, k), NozzAdd(kLato, k), Issue)
            End Select
            With Issue
                If .a * .Aa > 0 Then
                    If (.a1 + .a2 + .A2PROT + .A4 + .A3) / .a < (.AA1 + .a2 + .A2PROT + .A4 + .AA3) / .Aa Then
                        A0 = .a 'Nozzles(kLato, k).Risult
                        a1 = .a1
                        a2 = .a2
                        A3 = .A2PROT
                        A41 = .A4
                        A42 = 0 : A43 = 0
                        A5 = .A3
                    Else
                        A0 = .Aa
                        a1 = .AA1
                        a2 = .a2
                        A3 = .A2PROT
                        A41 = .A4
                        A42 = 0 : A43 = 0
                        A5 = .AA3
                    End If
                Else
                    A0 = 0
                End If
            End With
        End If
        '       XXX(2, 58) = (LN = LXdisp)
        Ls = SavLS
        TE = SavTE
    End Sub
    Sub BraPrint(ByRef nn As Short, ByRef jmemb As Short, ByRef LARNO As Short, ByRef pr As Single, ByRef pr0 As Single, ByRef Sall As Single, ByRef MatGr As String, ByRef No As Short, ByRef LSH As Single)
        Dim StriSt(149) As String
        Dim Rtf As String
22000:  Dim Stringa2(7) As String
        Dim Stringa8(5) As String
        Dim iy As Short
        Dim ifl, i As Short
        Dim Mat As String
        Dim iTipo As Short
        Dim k As String = ""
        Dim kk As String = ""
        Dim Ped1 As String = ""
        Dim Ped As String = ""
        Dim Ped2 As String = ""
        Dim MWDTrule As String = ""
        Dim MWDTclause As String = ""
        Dim ii, iV As Short
        Dim Bkmk, Figur As String
        Dim iSt, iFor, iFor1 As Short
        Dim iStExt As Integer '140506
        Dim Stri1, Stri93 As String
        Try
            ' BRANCH CONNECTIONS PRINTOUT SUBROUTINE
            ' **************************************
            ifl = FreeFile()
            FileOpen(ifl, RTrim(clsInizio.Archdir) & "\ASME14.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 5 : Posiz3(i) = LineInput(ifl) : Posiz3(i) = Left(Posiz3(i), Len(Posiz3(i)) - 1) : Next
            For i = 1 To 2 : Posiz2(i) = LineInput(ifl) : Posiz2(i) = Left(Posiz2(i), Len(Posiz2(i)) - 1) : Next
            For i = 1 To 3 : Posiz0(i) = LineInput(ifl) : Posiz0(i) = Left(Posiz0(i), Len(Posiz0(i)) - 1) : Next
            For i = 1 To 4 : Posiz1(i) = LineInput(ifl) : Posiz1(i) = Left(Posiz1(i), Len(Posiz1(i)) - 1) : Next
            For i = 1 To 7 : Stringa2(i) = LineInput(ifl) : Next
            For i = 1 To 5 : Stringa8(i) = LineInput(ifl) : Next
            FileClose(ifl)
            Stringa8(5) = "Set-in/on"
            If div = 1 Then
                Stringa2(4) = "LWN1:Forgiato autorinforzato"
                Stringa2(5) = "LWN2:Forgiato con scarpa"
                Stringa2(6) = "LWN3:Pad e/o sleeve"
            End If
            Posiz0(0) = "not defined" : Posiz1(0) = Posiz0(0)
            '  Stringa2$(1) = "LWN/WN/Slip-on"
            '  Stringa2$(2) = "LWN/WN/Slip-on + reinf. pad"
            '  Stringa2$(3) = "Long Welding Neck"
            '  Stringa2$(4) = "Selfreinforcing as per Fig.UG-40(d)(e)"
            '  Stringa2$(5) = "With integral pad as per Fig.UG-40(f)"
            PosizC(0) = Posiz1(0) : PosizC(1) = Posiz1(1) : PosizC(2) = Posiz1(4)
22010:      Call Monitor.Motore.Testata()
            ifl = FreeFile()
            Rtf = "\RTF"
            FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME27.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 149
                StriSt(i) = LineInput(ifl)
                StriSt(i) = Left(StriSt(i), Len(StriSt(i)) - 1)
            Next
            FileClose(ifl)
            iy = 1
            With Monitor.Motore.Problem
                .Printa(StriSt(1))
                .Printa(GlobalRoutines.FormatS(StriSt(2), x(iy, 1), x(iy, 2)))
                .Printa(StriSt(3))  'DL$; DL$; DL$
                ContBkmk = ContBkmk + 1
                Bkmk = "Bkmk" & Trim(Str(ContBkmk))
                If NozzAdd(kLato, nn).UW16 < 1 Then NozzAdd(kLato, nn).UW16 = 1
                Figur = frmNoz.DefInstance.TagListaImmagini(NozzAdd(kLato, nn).UW16)
                .Printa(GlobalRoutines.FormatS(StriSt(4), Bkmk, Figur, Bkmk, Trim(Nozzles(kLato, nn).Mark)))  '"Nozzle Identification Mark    : ";
                Select Case Nozzles(kLato, nn).Tipo.Trim
                    Case "WN" : iTipo = 1
                    Case "WN1" : iTipo = 2
                    Case "LWN" : iTipo = 3
                    Case "LWN1" : iTipo = 4
                    Case "LWN2" : iTipo = 5
                    Case "LWN3" : iTipo = 6
                End Select
                If iTipo > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(5), Stringa2(iTipo)))  '"Nozzle Kind                   : "
                End If
                If jmemb > 0 Then
                    Select Case Involucr(kLato, jmemb).Tipo
                        Case 0 : k = "on cylinder " & RTrim(Involucr(kLato, jmemb).Mark)
                        Case 1 : k = "on head " & RTrim(Involucr(kLato, jmemb).Mark)
                        Case 2 : k = "on cone " & RTrim(Involucr(kLato, jmemb).Mark)
                        Case 3 : k = "on conoid " & RTrim(Involucr(kLato, jmemb).Mark)
                        Case 4 : k = "on belt " & RTrim(Involucr(kLato, jmemb).Mark)
                        Case 5 : k = "on flat cover " & RTrim(Involucr(kLato, jmemb).Mark)
                    End Select
                    Call Disposiz(Involucr(kLato, jmemb).Tipo, nn, iDisp)
                    Call TestoDisposiz(jmemb, kk)
                Else
                    k = "on nozzle " & RTrim(Nozzles(kLato, -jmemb).Mark)
                    Call Disposiz(0, nn, iDisp)
                    Call TestoDisposiz(jmemb, kk)
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(6), k))  '"Disposition     "
                .Print(GlobalRoutines.FormatS(StriSt(7), RTrim(kk)))
                If jmemb > 0 Then iTipo = Involucr(kLato, jmemb).Tipo Else iTipo = 0
                Select Case iTipo
                    Case 0
                        Select Case iDisp
                            Case 1 : .Printa(StriSt(1))
                            Case 2 : .Printa(GlobalRoutines.FormatS(StriSt(8), Nozzles(kLato, nn).beta)) '" by ###.## degrees"
                            Case 3 : .Printa(GlobalRoutines.FormatS(StriSt(9), Nozzles(kLato, nn).DCL)) '". Offset: #####.## mm"
                            Case Else : .Printa(StriSt(1))
                        End Select
                    Case 1
                        Select Case iDisp
                            Case 4 : .Printa(GlobalRoutines.FormatS(StriSt(9), Nozzles(kLato, nn).DCL)) '". Offset: #####.## mm"
                            Case Else : .Printa(StriSt(1))
                        End Select
                    Case 3
                        .Printa(GlobalRoutines.FormatS(StriSt(99), Nozzles(kLato, nn).DCL))
                    Case Else : .Printa(StriSt(1))
                End Select
                .Printa(GlobalRoutines.FormatS(StriSt(10), Stringa8(NozzAdd(kLato, nn).TipAbutt)))  '"Shell attachment configuration: "
                kk = frmNoz.DefInstance.TagListaImmagini(NozzAdd(kLato, nn).UW16)
                .Printa(GlobalRoutines.FormatS(StriSt(11), kk))  ' "Weld details per Fig.UW16.1 Sketch "
                If div = 1 Then Exit Sub
                If NozzAdd(kLato, nn).Gola41 > 0 Then
                    kk = StriSt(12) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola41, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola41 / inc, 2, 3, False) & " [in]" '"     Min Code throat for weld 41   "
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                    kk = StriSt(14) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg41, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg41 / inc, 2, 3, False) & " [in]" ' "     Adopted leg     for weld 41   "
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                End If
                If NozzAdd(kLato, nn).Gola42 > 0 Then
                    kk = StriSt(15) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola42, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola42 / inc, 2, 3, False) & " [in]" ' "     Min Code throat for weld 42   "
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                    kk = StriSt(16) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg42, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg42 / inc, 2, 3, False) & " [in]" '"     Adopted leg     for weld 42   "
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                End If
                If NozzAdd(kLato, nn).Gola43 > 0 And NozzAdd(kLato, nn).UW16 <> 23 And NozzAdd(kLato, nn).UW16 <> 24 Then
                    kk = StriSt(17) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola43, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola43 / inc, 2, 3, False) & " [in]" '"     Min Code throat for weld 43   "
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                    kk = StriSt(18) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg43, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg43 / inc, 2, 3, False) & " [in]" '"     Adopted leg     for weld 43   "
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                End If
                If NozzAdd(kLato, nn).UW16 = 23 Or NozzAdd(kLato, nn).UW16 = 24 Then
                    kk = StriSt(19) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola43, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola43 / inc, 2, 3, False) & " [in]" '"     Min Code depth  for w.sh/nozz."
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                    kk = StriSt(20) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg43, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg43 / inc, 2, 3, False) & " [in]" '"     Adopted depth   for w.sh/nozz."
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                    kk = StriSt(21) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola43, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Gola43 / inc, 2, 3, False) & " [in]" '"     Min Code depth  for w.pad/nozz"
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                    kk = StriSt(22) & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg44, 3, 2, False) & " [mm] " & GlobalRoutines.myStr(NozzAdd(kLato, nn).Leg43 / inc, 2, 3, False) & " [in]" '"     Adopted depth   for w.pad/nozz"
                    .Printa(GlobalRoutines.FormatS(StriSt(13), kk))
                End If
22020:          If Nozzles(kLato, nn).Tipo <> "Sola" Then
                    .Printa(GlobalRoutines.FormatS(StriSt(23), Matdim(Nozzles(kLato, nn).indice).MatStr))  '"Nozzle Material Specification : "
                    If Not RTrim(Config(kLato).lkStr) = "MAWP" And Not VerificandoPI Then
                        For i = 1 To Matdim(Nozzles(kLato, nn).indice).Caract.Count
                            If Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.Codice = CodiceStress() Then
                                MWDTrule = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.MWDTrule
                                MWDTclause = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.MWDTclause
                                Exit For
                            End If
                        Next
                        If InStr(MWDTrule, "UCS") Then
                            .Printa(GlobalRoutines.FormatS(StriSt(24), RTrim(MWDTrule), MWDTclause))
                        Else
                            .Printa(GlobalRoutines.FormatS(StriSt(25), RTrim(MWDTrule)))
                        End If
                    End If
                End If
                If InStr(Nozzles(kLato, nn).Tipo, "WN") > 0 And Nozzles(kLato, nn).Rati > 0 Or Nozzles(kLato, nn).Tipo = "Sola" Then
                    Mat = "unknown"
                    If Nozzles(kLato, nn).IndexF > 0 Then
                        If Not Matdim(Nozzles(kLato, nn).IndexF) Is Nothing Then Mat = Matdim(Nozzles(kLato, nn).IndexF).MatStr
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(27), Mat))  '"Flange Material Specification : "
                End If
                If Nozzles(kLato, nn).indiceF = 1 And Nozzles(kLato, nn).Rati > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(28), MatGr))  '"Material Group per ANSI B16.5 : "
                ElseIf Nozzles(kLato, nn).Rati = 0 Then
                Else
                    .Printa(StriSt(29))  ' "Note: Flange to be verified per ASME VIII-div.1 App.2"
                End If
                .Printa(StriSt(1))
                If XXX(iy, 1) > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(30), XXX(iy, 1)))
                Else
                    .Printa(StriSt(105))
                End If
                .Printa(StriSt(1))
                If XXX(iy, 2) > 0 And XXX(iy, 1) >= 0 Then
22130:              .Printa(GlobalRoutines.FormatS(StriSt(31), XXX(iy, 2)))
                Else
                    .Printa(StriSt(106))
                End If
                If XXX(iy, 3) = 0 Then GoTo 22190
                .Printa(GlobalRoutines.FormatS(StriSt(32), XXX(iy, 3), XXX(iy, 4)))
                If XXX(iy, 1) = 0 Then GoTo 22210
22190:          .Printa(GlobalRoutines.FormatS(StriSt(33), XXX(iy, 5), XXX(iy, 6)))
                If NozzAdd(kLato, nn).Protusion > 0 Then .Printa(GlobalRoutines.FormatS(StriSt(111), NozzAdd(kLato, nn).Protusion, NozzAdd(kLato, nn).Protusion / inc))
22210:          .Printa(StriSt(1))
                If Nozzles(kLato, nn).Tipo.Trim = "SO" Then
                    Stri1 = StriSt(1) : Stri93 = StriSt(93)
                    GoTo Salta1
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(34), XXX(iy, 7), XXX(iy, 8)))
                .Printa(StriSt(1))
                .Printa(GlobalRoutines.FormatS(StriSt(35), XXX(iy, 9), XXX(iy, 9)))
                If Not Nozzles(kLato, nn).Tipo = "SPC1" Then
                    If Nozzles(kLato, nn).ONn = 0 Then 'GOTO 22300
22300:                  .Printa(GlobalRoutines.FormatS(StriSt(37), XXX(iy, 10), XXX(iy, 11)))
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(36), XXX(iy, 10), XXX(iy, 11)))
                    End If
                End If
22310:          If XXX(iy, 1) = 0 And XXX(iy, 3) = 0 Then GoTo 22390
                If Nozzles(kLato, nn).ONn = 0 Then GoTo 22360
                .Printa(GlobalRoutines.FormatS(StriSt(38), XXX(iy, 12), XXX(iy, 13)))
                GoTo 22410
22360:          .Printa(GlobalRoutines.FormatS(StriSt(39), XXX(iy, 12), XXX(iy, 13)))
22390:          .Printa(GlobalRoutines.FormatS(StriSt(40), XXX(iy, 14), XXX(iy, 15)))
22410:          .Printa(StriSt(1))
                If Not Nozzles(kLato, nn).Tipo = "SPC1" Then
                    '---------da riaggiustare -----------------------------------
                    '         IF p0 > (.385 * XXX(iy, 8) * XXX(iy, 9)) THEN GOTO 22490
                    '---------------------------------------!!!!!!!!!!!----------
                    'IF Nozzles(kLato,nn).SWR = 1 OR Nozzles(kLato,nn).SWR = 11 THEN ' GOTO 22460
22460:              '   PRINT #iout, USING StriSt$(42); XXX(iy, 18); XXX(iy, 19)
                    'ELSE
                    .Printa(GlobalRoutines.FormatS(StriSt(41), XXX(iy, 18), XXX(iy, 19)))
                    'END IF
                    GoTo 22560
22490:              .Printa(GlobalRoutines.FormatS(StriSt(43), XXX(iy, 17), XXX(iy, 17)))
                    '        IF XXX(iy, 1) = 0 AND XXX(iy, 3) = 0 THEN GOTO 22540
                    If Nozzles(kLato, nn).SWR = 1 Or Nozzles(kLato, nn).SWR = 11 Then ' GOTO 22460
22540:                  .Printa(GlobalRoutines.FormatS(StriSt(45), XXX(iy, 18), XXX(iy, 19)))
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(44), XXX(iy, 18), XXX(iy, 19)))
                    End If 'GOTO 22560
22560:              If P0 > (0.385 * XXX(iy, 8)) Then GoTo 22640
                    '        IF XXX(iy, 1) = 0 AND XXX(iy, 3) = 0 THEN GOTO 22610
                    If Nozzles(kLato, nn).SWR = 1 Or Nozzles(kLato, nn).SWR = 11 Then ' GOTO 22460
22610:                  .Printa(GlobalRoutines.FormatS(StriSt(47), XXX(iy, 20), XXX(iy, 21)))
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(46), XXX(iy, 20), XXX(iy, 21)))
                    End If
                    GoTo 22710
22640:              .Printa(GlobalRoutines.FormatS(StriSt(48), XXX(iy, 16), XXX(iy, 16)))
                    '        IF XXX(iy, 1) = 0 AND XXX(iy, 3) = 0 THEN GOTO 22690
                    If Nozzles(kLato, nn).SWR = 1 Or Nozzles(kLato, nn).SWR = 11 Then ' GOTO 22460
22690:                  .Printa(GlobalRoutines.FormatS(StriSt(50), XXX(iy, 20), XXX(iy, 21)))
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(49), XXX(iy, 20), XXX(iy, 21)))
                    End If 'GOTO 22710
22710:              If A0Ext > 0 Then '140506
                        .Printa(GlobalRoutines.FormatS(StriSt$(139), SpBocchExt, SpBocchExt / inc))
                    End If
                    .Printa(StriSt(1))
                    If trh > 0 Then
                        Select Case swn
                            Case 0, 2, 3
                                .Printa(GlobalRoutines.FormatS(StriSt(145), trh + Nozzles(kLato, nn).CorrA, (trh + Nozzles(kLato, nn).CorrA) / inc))
                            Case 1
                                .Printa(GlobalRoutines.FormatS(StriSt(145), trh + Nozzles(kLato, nn).CorrA, (trh + Nozzles(kLato, nn).CorrA) / inc))
                            Case -1
                        End Select
                    End If
                    If Nozzles(kLato, nn).MNT > 0 Then
                        .Printa(GlobalRoutines.FormatS(StriSt(149), Nozzles(kLato, nn).MNT))
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(51), MNT + Nozzles(kLato, nn).CorrA, (MNT + Nozzles(kLato, nn).CorrA) / inc))
                    .Printa(GlobalRoutines.FormatS(StriSt(146), minUG45b, minUG45b / inc))
                    .Printa(GlobalRoutines.FormatS(StriSt(52), XXX(iy, 22), XXX(iy, 23)))
                    .Printa(GlobalRoutines.FormatS(StriSt(53), XXX(iy, 24), XXX(iy, 25)))
                End If
                If No = 1 Then
                    .Printa(StriSt(1))
                    .Printa(StriSt(54))  '"Single opening not requiring reinforcement per UG-36(c)(3)"
                    .Printa(StriSt(1))
                    Stri1 = StriSt(1) : Stri93 = StriSt(93)
                    GoTo Salta1
                ElseIf No = 2 Then
                    .Printa(StriSt(1))
                    .Printa(StriSt(137))  '"Single opening not requiring reinforcement per UG-36(c)(3)"
                    .Printa(StriSt(1))
                    Stri1 = StriSt(1) : Stri93 = StriSt(93)
                    GoTo Salta1
                End If
                If Nozzles(kLato, nn).Tipo = "LWN1" Then
                    .Printa(GlobalRoutines.FormatS(StriSt(55), XXX(iy, 26), XXX(iy, 27)))
                    .Printa(GlobalRoutines.FormatS(StriSt(56), Nozzles(kLato, nn).LX, Nozzles(kLato, nn).LX / inc))
                    If XXX(1, 58) = -1 Then
                        .Printa(GlobalRoutines.FormatS(StriSt(58), XXX(iy, 37), XXX(iy, 38)))  '(e-2) Ln
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(57), XXX(iy, 41), XXX(iy, 42)))  '(e-1) te
                        'Print #iout, FormatS(StriSt$(57), XXX(iy, 58), XXX(iy, 58) / inc) '(e-1) te
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(127), Nozzles(kLato, nn).TransitionAngle))
                Else
                    .Printa(StriSt(1))
                    .Printa(StriSt(1))
                End If
                If No = 3 Then
                    .Printa(StriSt(1))
                    .Printa(StriSt(148))  '"For reinforcement calculations please refer to the following sheets"
                    .Printa(StriSt(1))
                    Stri1 = StriSt(1) : Stri93 = StriSt(93)
                    GoTo Salta1
                End If
                Select Case iTipo
                    Case 2, 3
                        .Printa(GlobalRoutines.FormatS(StriSt(100), XXX(1, 60), XXX(1, 60) / inc))
                        .Printa(GlobalRoutines.FormatS(StriSt(101), XXX(1, 61)))
                End Select
                .Printa(GlobalRoutines.FormatS(StriSt(116), TCV, TCV / inc))
                If UG37a > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(130), Trim(Str(UG37a)), TCV, TCV / inc))
                Else
                    .Printa(GlobalRoutines.FormatS(StriSt(59), TRV, TRV / inc))
                End If
                If A0Ext > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(138), SpxBExt, SpxBExt / inc))
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(60), XXX(iy, 35), XXX(iy, 36)))
                .Printa(GlobalRoutines.FormatS(StriSt(61), XXX(iy, 53), XXX(iy, 53) / inc))
                .Printa(GlobalRoutines.FormatS(StriSt(62), XXX(iy, 28), XXX(iy, 29)))
                ii = 63 : If AlfaS <> 0 Then ii = 107
                .Printa(GlobalRoutines.FormatS(StriSt(ii), XXX(iy, 37), XXX(iy, 38)))
                If Nozzles(kLato, nn).Tipo.Trim = "WN1" Then
                    If XXX(iy, 39) = Nozzles(kLato, nn).Padd Then
                        .Printa(GlobalRoutines.FormatS(StriSt(64), XXX(iy, 39), XXX(iy, 40)))
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(64), Nozzles(kLato, nn).Padd, Nozzles(kLato, nn).Padd / inc))
                        .Printa(GlobalRoutines.FormatS(StriSt(103), XXX(iy, 39), XXX(iy, 40)))
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(65), XXX(iy, 41), XXX(iy, 42)))
                    .Printa(GlobalRoutines.FormatS(StriSt(97), Nozzles(kLato, nn).AllPad * mpa, Nozzles(kLato, nn).AllPad))
                ElseIf Nozzles(kLato, nn).Tipo = "LWN2" Then
                    .Printa(GlobalRoutines.FormatS(StriSt(114), Nozzles(kLato, nn).Padd, Nozzles(kLato, nn).Padd / inc))
                    .Printa(GlobalRoutines.FormatS(StriSt(115), Nozzles(kLato, nn).PadT, Nozzles(kLato, nn).PadT / inc))
                ElseIf Nozzles(kLato, nn).Tipo = "LWN1" Then
                    .Printa(GlobalRoutines.FormatS(StriSt(66), XXX(iy, 3) + 2 * XXX(iy, 26), XXX(iy, 4) + 2 * XXX(iy, 27)))
                ElseIf Nozzles(kLato, nn).Tipo = "LWN3" And Nozzles(kLato, nn).PadT > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(108), Nozzles(kLato, nn).PadT, Nozzles(kLato, nn).PadT / inc / inc))
                Else
                    .Printa(StriSt(1))
                End If
                '-----------------------------------------------------------------------
                If AlfaS > 0 And Fprel > 0 Then
                    .Printa(GlobalRoutines.FormatS(StriSt(131), Fprel))
                    .Printa(GlobalRoutines.FormatS(StriSt(132), AlfaS * 180 / pi))
                    .Printa(GlobalRoutines.FormatS(StriSt(133), XXX(iy, 64), XXX(iy, 64) / inc))
                    If Circonf Then .Printa(StriSt(134)) Else .Printa(StriSt(135))
                End If
                '-------------------------------------------------------------
                .Printa(GlobalRoutines.FormatS(StriSt(104), XXX(iy, 63), XXX(iy, 63) / inc))
                iV = 1 : If LARNO Then iV = 2
                For ii = 1 To iV
                    If ii = 2 Then
                        .Printa(StriSt(1))
                        .Printa(StriSt(67))  '"Appendix 1-7(a) (Large Openings) Calculation"
                    End If
                    iFor = 68 : iFor1 = 112
                    If ii = 2 Then
                        iFor = 95 : iFor1 = 113
                    Else
                        If Ffact < 1 Then .Printa(GlobalRoutines.FormatS(StriSt(94), Ffact, Ffact))
                        For i = 1 To 4
                            If XXX(i, 62) < 1 Then .Printa(GlobalRoutines.FormatS(StriSt(102), i, XXX(i, 62), XXX(i, 62)))
                        Next
                        If E1 < 1 Then .Printa(GlobalRoutines.FormatS(StriSt(147), E1))
                    End If
                    '9-1-99+++++++++++++
                    If XXX(1, 58) = -1 Then Ped = "SR" Else Ped = "n"
                    Select Case Config(0).SpecialRinf
                        Case 0 : Ped2 = "r"
                        Case 1 : Ped2 = "" : iFor1 = iFor1 + 5
                            .Printa(StriSt(119))
                            .Printa(StriSt(120))
                    End Select
                    'WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                    .Printa(GlobalRoutines.FormatS(StriSt(iFor), Ped2, Ped, Ped2, XXX(ii, 43), XXX(ii, 44)))
                    '9-1-99+++++++++++++
                    '     IF AVS < ALS THEN GOTO 22930    ???????
                    'if selfreinforced and (e-2) then Ped$="SR" else Ped$="n"
                    If XXX(ii, 57) = 0 Then 'limitato dal disponibile
                        If LS1 < LS2 Then iSt = 69 : Ped1 = Ped : iStExt = 140 Else iSt = 70 : Ped1 = "" : iStExt = 141
                    Else
                        iSt = 98 : Ped1 = "" : iStExt = 140
                    End If
                    If iSt = 69 Then
                        .Printa(GlobalRoutines.FormatS(StriSt(iSt), Ped, Ped2, Ped1, Ped2, XXX(ii, 45), XXX(ii, 46)))
                    Else
                        .Printa(GlobalRoutines.FormatS(StriSt(iSt), Ped2, Ped, Ped1, Ped2, XXX(ii, 45), XXX(ii, 46)))
                    End If
                    'PrintA2-----------------------------------------------------
                    If Nozzles(kLato, nn).Tipo = "LWN1" And XXX(1, 58) = -1 Then Ped = "SR" Else Ped = "n"
                    'If AlfaS <> 0 Then
                    '.Printa(GlobalRoutines.FormatS(StriSt(109), "2", XXX(ii, 47), XXX(ii, 48)))
                    'ElseIf XXX(2, 58) Then
                    '    Ped1 = Ped
                    '    .Printa(GlobalRoutines.FormatS(StriSt(142), Ped, Ped1, XXX(ii, 47), XXX(ii, 48)))
                    'Else
                    If LN1 > LN2 Then
                        If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Or XXX(1, 58) > 0 Then iSt = 143 : Ped1 = "n" Else iSt = 144 : Ped1 = Ped
                    Else
                        iSt = 144 : Ped1 = ""
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(iSt), Ped, Ped1, XXX(ii, 47), XXX(ii, 48)))
                    'End If
                    'PrintA3---------------------------------------------------------
                    If Not NozzAdd(kLato, nn).Protusion = 0 Then
                        If AlfaS <> 0 Then
                            .Printa(GlobalRoutines.FormatS(StriSt(109), "3", XXX(ii, 64), XXX(ii, 64) / inc / inc))
                        Else
                            .Printa(GlobalRoutines.FormatS(StriSt(110), XXX(ii, 64), XXX(ii, 64) / inc / inc))
                        End If
                    End If
                    If XXX(ii, 54) > 0 Then
                        If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Then
                            .Printa(GlobalRoutines.FormatS(StriSt(73), XXX(ii, 54), XXX(ii, 54) / inc / inc))
                        Else
                            .Printa(GlobalRoutines.FormatS(StriSt(74), XXX(ii, 54), XXX(ii, 54) / inc / inc))
                        End If
                    End If
                    If XXX(ii, 55) > 0 Then
                        .Printa(GlobalRoutines.FormatS(StriSt(75), XXX(ii, 55), XXX(ii, 55) / inc / inc))
                    End If
                    If XXX(ii, 56) > 0 Then
                        .Printa(GlobalRoutines.FormatS(StriSt(76), XXX(ii, 56), XXX(ii, 56) / inc / inc))
                    End If
                    If XXX(1, 59) = 1 Then Ped = "L" : Ped1 = "n" Else Ped = "t" : Ped1 = "e"
                    If (XXX(ii, 53) - XXX(ii, 24) + XXX(ii, 10)) < ((XXX(ii, 39) - DN - 2 * (XXX(ii, 24) - XXX(ii, 10))) / 2) Then
                        If XXX(ii, 49) > 0 Then .Printa(GlobalRoutines.FormatS(StriSt(77), Ped, Ped1, XXX(ii, 49), XXX(ii, 50)))
                    Else
                        k = ""
                        If Nozzles(kLato, nn).Tipo = "LWN2" Then k = " (less taper, if appl.)" '9-1-99
                        If Nozzles(kLato, nn).Tipo = "LWN1" And XXX(3, 58) > 0 Then
                            k = GlobalRoutines.FormatS("+(taper=######.## mm{_\super 2})", XXX(3, 58))
                        End If
                        If XXX(ii, 49) > 0 Then .Printa(GlobalRoutines.FormatS(StriSt(78), Ped, Ped1, k, XXX(ii, 49), XXX(ii, 50)))
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(79), XXX(ii, 51), XXX(ii, 52)))
                    .Printa(StriSt(1))
                    'WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                    'WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                    If A0Ext > 0 Then
                        .Printa(GlobalRoutines.FormatS(StriSt(iFor1), Ped, A0Ext, A0Ext / inc / inc))
                        If iSt = 69 Then
                            .Printa(GlobalRoutines.FormatS(StriSt(iSt), Ped, Ped2, Ped1, Ped2, a1ext, a1ext / inc ^ 2))
                        Else
                            .Printa(GlobalRoutines.FormatS(StriSt(iSt), Ped2, Ped, Ped1, Ped2, a1ext, a1ext / inc ^ 2))
                        End If
                        'PrintA2-----------------------------------------------------
                        If Nozzles(kLato, nn).Tipo = "LWN1" And XXX(1, 58) = -1 Then Ped = "SR" Else Ped = "n"
                        'If AlfaS <> 0 Then
                        '.Printa(GlobalRoutines.FormatS(StriSt(109), "2", a2ext, a2ext / inc ^ 2))
                        'ElseIf XXX(2, 58) Then
                        '   Ped1 = Ped
                        '  .Printa(GlobalRoutines.FormatS(StriSt(72), Ped, Ped1, a2ext, a2ext / inc ^ 2))
                        'Else
                        If LN1 > LN2 Then
                            If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Or XXX(1, 58) > 0 Then iSt = 71 : Ped1 = "n" Else iSt = 96 : Ped1 = Ped
                        Else
                            iSt = 96 : Ped1 = ""
                        End If
                        .Printa(GlobalRoutines.FormatS(StriSt(iSt), Ped, Ped1, a2ext, a2ext / inc ^ 2))
                        'End If
                        'PrintA3---------------------------------------------------------
                        If Not NozzAdd(kLato, nn).Protusion = 0 Then
                            ' If AlfaS <> 0 Then
                            '     .Printa(GlobalRoutines.FormatS(StriSt(109), "3", XXX(ii, 64), XXX(ii, 64) / inc / inc))
                            ' Else
                            .Printa(GlobalRoutines.FormatS(StriSt(110), XXX(ii, 64), XXX(ii, 64) / inc / inc))
                            '  End If
                        End If
                        If XXX(ii, 54) > 0 Then
                            If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Then
                                .Printa(GlobalRoutines.FormatS(StriSt(73), XXX(ii, 54), XXX(ii, 54) / inc / inc))
                            Else
                                .Printa(GlobalRoutines.FormatS(StriSt(74), XXX(ii, 54), XXX(ii, 54) / inc / inc))
                            End If
                        End If
                        If XXX(ii, 55) > 0 Then
                            .Printa(GlobalRoutines.FormatS(StriSt(75), XXX(ii, 55), XXX(ii, 55) / inc / inc))
                        End If
                        If XXX(ii, 56) > 0 Then
                            .Printa(GlobalRoutines.FormatS(StriSt(76), XXX(ii, 56), XXX(ii, 56) / inc / inc))
                        End If
                        If XXX(1, 59) = 1 Then Ped = "L" : Ped1 = "n" Else Ped = "t" : Ped1 = "e"
                        If (XXX(ii, 53) - XXX(ii, 24) + XXX(ii, 10)) < ((XXX(ii, 39) - DN - 2 * (XXX(ii, 24) - XXX(ii, 10))) / 2) Then
                            If XXX(ii, 49) > 0 Then .Printa(GlobalRoutines.FormatS(StriSt(77), Ped, Ped1, XXX(ii, 49), XXX(ii, 50)))
                        Else
                            k = ""
                            If Nozzles(kLato, nn).Tipo = "LWN2" Then k = " (less taper, if appl.)" '9-1-99
                            If Nozzles(kLato, nn).Tipo = "LWN1" And XXX(3, 58) > 0 Then
                                k = GlobalRoutines.FormatS("+(taper=######.## mm{_\super 2})", XXX(3, 58))
                            End If
                            If XXX(ii, 49) > 0 Then .Printa(GlobalRoutines.FormatS(StriSt(78), Ped, Ped1, k, XXX(ii, 49), XXX(ii, 50)))
                        End If
                        .Printa(GlobalRoutines.FormatS(StriSt(79), AdisponExt, AdisponExt / inc ^ 2))
                        .Printa(StriSt(1))
                    End If
                    'WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                    If A0 <= Adispon And (A0Ext < AdisponExt Or A0Ext = 0) Then
                        .Printa(StriSt(80))  '"         The opening is adequately compensated."
                    Else
                        .Printa(StriSt(81))  '"         The opening is not adequately compensated."
                    End If
                    If ii = 1 Then
                        Call Monitor.Motore.Testata()
                        .Printa(StriSt(1))
                        .Printa(StriSt(3))  'DL$; DL$; DL$
                        .Printa(GlobalRoutines.FormatS(StriSt(136), Trim(Nozzles(kLato, nn).Mark)))  '"Nozzle Identification Mark    : ";
                    End If
                Next ii
                .Printa(StriSt(1))
                If LARNO = -1 Then
                    .Printa(StriSt(82))  '"Appendix 1-7(b) (Large Openings) Calculation"
                    .Printa(StriSt(121))
                    .Printa(GlobalRoutines.FormatS(StriSt(83), TBra, tn, Rnoz, Rnm, Rshell, Rm))  '"t =####.# tn=####.# Rn=####.# Rnm=####.# R=####.# Rm=####.#           [mm] "
                    .Printa(GlobalRoutines.FormatS(StriSt(84), Nozzles(kLato, nn).PadT, aepad, Area))  '"te=####.# Le=####.# a =####.# [mm] As=##.###^^^^ [mm˝] I=##.###^^^^ [mm^4] "
                    .Printa(GlobalRoutines.FormatS(StriSt(85), Alshe))  '"Available length along the shell :         ####.# [mm]  "
                    .Printa(GlobalRoutines.FormatS(StriSt(86), Alnoz))  '"Available length along the nozzle:         ####.# [mm]  "
                    .Printa(GlobalRoutines.FormatS(StriSt(87), Sm, Sm * psi))
                    .Printa(GlobalRoutines.FormatS(StriSt(89), Sall, Sall * psi))
                    .Printa(StriSt(122))
                    .Printa(GlobalRoutines.FormatS(StriSt(123), Nozzles(kLato, nn).PadT + 16 * tn, 16 * TBra, aneu, AreaB, Aine))
                    Select Case Left(Nozzles(kLato, nn).Tipo, 1)
                        Case "W", "L"
                            .Printa(StriSt(124 + Caso17b))
                        Case Else
                    End Select
                    .Printa(GlobalRoutines.FormatS(StriSt(85), AlsheB))  '"Available length along the shell :         ####.# [mm]  "
                    .Printa(GlobalRoutines.FormatS(StriSt(86), AlnozB))  '"Available length along the nozzle:         ####.# [mm]  "
                    .Printa(GlobalRoutines.FormatS(StriSt(88), (Sm + sb), (Sm + sb) * psi))
                    .Printa(GlobalRoutines.FormatS(StriSt(90), 1.5 * Sall, 1.5 * Sall * psi))
                    .Printa(StriSt(1))
                    If Sm <= Sall And Sm + sb <= 1.5 * Sall Then
                        .Printa(StriSt(91))  '"         Acceptable stresses.     "
                    Else
                        .Printa(StriSt(92))  '"         Stresses not acceptable. "
                    End If
                ElseIf LARNO = 1 Then
                    .Printa(StriSt(82))  '"Appendix 1-7(b) (Large Openings) Calculation"
                    .Printa(StriSt(128))
                ElseIf LARNO = 2 Then
                    .Printa(StriSt(82))  '"Appendix 1-7(b) (Large Openings) Calculation"
                    .Printa(StriSt(129))
                End If
                Stri1 = StriSt(1) : Stri93 = StriSt(93)
                Call PathsPri(nn)
                '------------------------------------------------------------------------------
Salta1:
                .Printa(Stri1)
                If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP And Not VerificandoPI Then
23111:              If pr < 10000000000.0# Then .Print(GlobalRoutines.FormatS(Stri93, pr, pr * psi)) '"Maximum allowable pressure per ANSI B16.5=######.## &   ######.## &"
23112:              Call BraMAWP(nn, jmemb, pr, pr0, LARNO, No, LSH)
                    Call MAWPpri(nn)
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'b
    Private Sub TestoDisposiz(ByVal jmemb As Short, ByRef kk As String)
        Dim Tipo As Short
        If jmemb > 0 Then Tipo = Involucr(kLato, jmemb).Tipo Else Tipo = 0
        Select Case Tipo
            Case 0 : kk = Posiz0(iDisp)
            Case 1 : kk = Posiz1(iDisp)
            Case 2 : kk = Posiz2(iDisp)
            Case 3 : kk = Posiz3(iDisp)
            Case 5
                Select Case CType(objMemb(Involucr(kLato, jmemb).IndObject), wn_flan).Mem.LOOSE
                    Case 4 'coperchio piano
                        kk = PosizC(iDisp)
                    Case 5, 6 'flat head with large opening
                        kk = "not applicable"
                    Case 7 'reverse flange
                        kk = Posiz1(iDisp)
                    Case Else 'flangioni loose e no
                        kk = Posiz1(iDisp)
                End Select
        End Select
    End Sub
    Sub MAWPpri(ByRef nn As Short)
        Dim StriSt(6) As String
        Dim ifl As Short
        Dim Rtf As String
        Dim i As Short
        If Config(0).CalcMAWP = 0 Then Exit Sub
        ifl = FreeFile()
        Rtf = "\RTF"
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME28.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6
            StriSt(i) = LineInput(ifl)
            StriSt(i) = Left(StriSt(i), Len(StriSt(i)) - 1)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(StriSt(1))
            .Printa(StriSt(2))  ' "Calculation of the Maximum Allowable Working Pressures"
            .Printa(StriSt(1))
            .Printa(GlobalRoutines.FormatS(StriSt(3), Nozzles(kLato, nn).MAWP(1 - 1), Nozzles(kLato, nn).MAWP(1 - 1) * psi))
            .Printa(GlobalRoutines.FormatS(StriSt(4), Nozzles(kLato, nn).MAWP(2 - 1), Nozzles(kLato, nn).MAWP(2 - 1) * psi))
            .Printa(GlobalRoutines.FormatS(StriSt(5), Nozzles(kLato, nn).MAWP(3 - 1), Nozzles(kLato, nn).MAWP(3 - 1) * psi))
            .Printa(GlobalRoutines.FormatS(StriSt(6), Nozzles(kLato, nn).MAWP(4 - 1), Nozzles(kLato, nn).MAWP(4 - 1) * psi))
        End With
    End Sub 'c
    Sub PathsCal(ByRef k As Short)
        Dim i As Short
        Dim s1, S2 As Single
        Dim ifl, ii As Short
        For i = 1 To 3
            NozzAdd(kLato, k).Paths(i - 1) = 0
        Next
        Select Case NozzAdd(kLato, k).UW16
            Case 1, 5, 6, 7, 8, 9, 10, 11, 12, 13
                Exit Sub
            Case Is > 27
                Exit Sub
        End Select
        NozzAdd(kLato, k).W = (A0 - a1) * SS
        If NozzAdd(kLato, k).TipAbutt < 3 Then
            NozzAdd(kLato, k).W = (A0 - a1 + 2 * TCN * FR1 * (E1 * TCV - Ffact * TRV)) * SS
            NozzAdd(kLato, k).W22 = (a2 + A3 + A41 + A43 + 2 * TCN * TCV * FR1) * SS
            NozzAdd(kLato, k).W33 = (a2 + A3 + A5 + A41 + A42 + A43 + 2 * TCN * TCV * FR1) * SS
        Else
            NozzAdd(kLato, k).W = (A0 - a1) * SS
            NozzAdd(kLato, k).W22 = (a2 + A41) * SS
            NozzAdd(kLato, k).W33 = 0
        End If
        Select Case NozzAdd(kLato, k).UW16
            Case 19, 20, 21, 22
                NozzAdd(kLato, k).W22 = 0
                NozzAdd(kLato, k).W33 = 0
        End Select
        If NozzAdd(kLato, k).W <= 0 Then
            For i = 1 To 3 : NozzAdd(kLato, k).Paths(i - 1) = 0 : Next
            Exit Sub
        End If
        NozzAdd(kLato, k).W11 = (a2 + A5 + A41 + A42) * SS
        NozzAdd(kLato, k).Wcomp(0) = NozzAdd(kLato, k).W11
        If NozzAdd(kLato, k).W < NozzAdd(kLato, k).Wcomp(0) Then NozzAdd(kLato, k).Wcomp(0) = NozzAdd(kLato, k).W
        NozzAdd(kLato, k).Wcomp(1) = NozzAdd(kLato, k).W22
        If NozzAdd(kLato, k).W < NozzAdd(kLato, k).Wcomp(1) Then NozzAdd(kLato, k).Wcomp(1) = NozzAdd(kLato, k).W
        NozzAdd(kLato, k).Wcomp(2) = NozzAdd(kLato, k).W33
        If NozzAdd(kLato, k).W < NozzAdd(kLato, k).Wcomp(2) Then NozzAdd(kLato, k).Wcomp(2) = NozzAdd(kLato, k).W
        s1 = SS : If SP < SS Then s1 = SP
        S2 = SS : If Sn < SS Then S2 = Sn
        NozzAdd(kLato, k).Fillets = 0.49 * s1
        NozzAdd(kLato, k).GrooTen = 0.74 * S2
        NozzAdd(kLato, k).GrooShe = 0.6 * S2
        NozzAdd(kLato, k).NozzShe = 0.7 * Sn
        For i = 0 To 7 : NozzAdd(kLato, k).Str_Renamed(i) = 0 : Next
        Select Case NozzAdd(kLato, k).UW16
            Case 2, 4, 25 '(a-1)
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                'external inner fillet
                NozzAdd(kLato, k).Str_Renamed(2) = pi / 4 * (Nozzles(kLato, k).DiOn + Nozzles(kLato, k).DiIn) * TCN * NozzAdd(kLato, k).NozzShe
                'nozzle wall in shear
                NozzAdd(kLato, k).Str_Renamed(3) = pi / 2 * Nozzles(kLato, k).Padd * NozzAdd(kLato, k).Leg42 * NozzAdd(kLato, k).Fillets
                'external outer fillet
                NozzAdd(kLato, k).Str_Renamed(4) = pi / 4 * (Nozzles(kLato, k).DiOn + Nozzles(kLato, k).DiIn) * TCN * NozzAdd(kLato, k).GrooShe
                'groove in shear
            Case 14 '(h)
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                NozzAdd(kLato, k).Str_Renamed(3) = pi / 2 * Nozzles(kLato, k).Padd * NozzAdd(kLato, k).Leg42 * NozzAdd(kLato, k).Fillets
                NozzAdd(kLato, k).Str_Renamed(5) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).Fillets
                NozzAdd(kLato, k).Str_Renamed(7) = pi / 2 * Nozzles(kLato, k).DiOn * TCV * NozzAdd(kLato, k).GrooTen
                'groove in tension
            Case 15, 16, 17, 18
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                'external inner fillet
                NozzAdd(kLato, k).Str_Renamed(5) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).Fillets
                'internal inner fillet
                NozzAdd(kLato, k).Str_Renamed(2) = pi / 4 * (Nozzles(kLato, k).DiOn + Nozzles(kLato, k).DiIn) * TCN * NozzAdd(kLato, k).NozzShe
                'nozzle wall in shear
            Case 19
                NozzAdd(kLato, k).GrooTen = 0 : NozzAdd(kLato, k).NozzShe = 0 : NozzAdd(kLato, k).GrooShe = 0
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Dp * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                'external inner fillet
                NozzAdd(kLato, k).Str_Renamed(5) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).Fillets
                'internal inner fillet     ????????????
            Case 20, 21
                NozzAdd(kLato, k).GrooTen = 0 : NozzAdd(kLato, k).NozzShe = 0
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Dp * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                'external inner fillet
                NozzAdd(kLato, k).Str_Renamed(4) = pi / 4 * Nozzles(kLato, k).DiIn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).GrooShe
                'groove in shear ??????????????????????
            Case 22
                NozzAdd(kLato, k).GrooTen = 0 : NozzAdd(kLato, k).NozzShe = 0 : NozzAdd(kLato, k).GrooShe = 0
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Dp * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                'external inner fillet
                NozzAdd(kLato, k).Str_Renamed(5) = pi / 2 * Nozzles(kLato, k).DiIn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).Fillets
                'internal inner fillet     ????????????
            Case 23, 24
                NozzAdd(kLato, k).Str_Renamed(1) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg41 * NozzAdd(kLato, k).Fillets
                'external inner fillet
                NozzAdd(kLato, k).Str_Renamed(2) = pi / 4 * (Nozzles(kLato, k).DiOn + Nozzles(kLato, k).DiIn) * TCN * NozzAdd(kLato, k).NozzShe
                'nozzle wall in shear
                NozzAdd(kLato, k).Str_Renamed(3) = pi / 2 * Nozzles(kLato, k).Padd * NozzAdd(kLato, k).Leg42 * NozzAdd(kLato, k).Fillets
                'external outer fillet
                NozzAdd(kLato, k).Str_Renamed(7) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).GrooTen
                'groove in tension shell/nozzle
                NozzAdd(kLato, k).Str_Renamed(8) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg44 * NozzAdd(kLato, k).GrooTen
                'groove in tension pad  /nozzle
            Case 26, 27 : MessageBox.Show("LAVORI IN CORSO")
        End Select
        Select Case NozzAdd(kLato, k).UW16
            Case 3, 4
                NozzAdd(kLato, k).Str_Renamed(5) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).Fillets
                'internal inner fillet
                NozzAdd(kLato, k).Str_Renamed(6) = pi / 2 * Nozzles(kLato, k).Padd * NozzAdd(kLato, k).Leg43 * NozzAdd(kLato, k).Fillets
                'internal outer fillet
            Case 18
                NozzAdd(kLato, k).Str_Renamed(4) = pi / 2 * Nozzles(kLato, k).DiOn * NozzAdd(kLato, k).Leg42 * NozzAdd(kLato, k).GrooShe
                'groove in shear
        End Select
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & "\ASME17.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To NozzAdd(kLato, k).UW16
            Input(ifl, NozzAdd(kLato, k).i(0)) '(0, 0))
            Input(ifl, NozzAdd(kLato, k).i(1)) '(0, 1))
            Input(ifl, NozzAdd(kLato, k).i(2)) 'i(0, 2))
            Input(ifl, NozzAdd(kLato, k).i(3)) '(1, 0))
            Input(ifl, NozzAdd(kLato, k).i(4)) '(1, 1))
            Input(ifl, NozzAdd(kLato, k).i(5)) 'i(1, 2))
            Input(ifl, NozzAdd(kLato, k).i(6)) '(2, 0))
            Input(ifl, NozzAdd(kLato, k).i(7)) '(2, 1))
            Input(ifl, NozzAdd(kLato, k).i(8)) '(2, 2))
        Next
        FileClose(ifl)
        For i = 1 To 3
            For ii = 1 To 3
                NozzAdd(kLato, k).Paths(i - 1) = NozzAdd(kLato, k).Paths(i - 1) + NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + ii - 1))
            Next
        Next
    End Sub 'e
    Sub PathsPri(ByRef k As Short)
        Dim StriSt(34) As String
        Dim ifl As Short
        Dim Rtf As String
        Dim i, ii As Short
        Dim Ped As String
        Dim iOK As Boolean
        Dim sign As String
        ifl = FreeFile()
        Rtf = "\RTF"
        Try
            FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME29.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 34
                StriSt(i) = LineInput(ifl)
                ii = StriSt(i).Length
                If ii > 0 Then StriSt(i) = StriSt(i).Substring(0, ii - 1)
            Next
            FileClose(ifl)
            With Monitor.Motore.Problem
                Select Case NozzAdd(kLato, k).UW16
                    Case 1, 5, 6, 7, 8, 9, 10, 11, 12, 13
                        .Printa(StriSt(2))  '"Opening exempted from strength calculations of welds per UW15(b)(1)"
                        .Printa(StriSt(1))
                        Exit Sub
                    Case Is > 27 'UHT18.1 or UHT18.2
                        .Printa(StriSt(2))  '"Opening exempted from strength calculations of welds per UW15(b)(1)"
                        .Printa(StriSt(1))
                        Exit Sub
                End Select
                If NozzAdd(kLato, k).W <= 0 Then
                    .Printa(StriSt(3))
                    .Printa(StriSt(33))
                    .Printa(StriSt(34))
                    Exit Sub
                End If
                .Printa(StriSt(3))  ' "Loads to be carried by welds per UG-41(b)"
                If NozzAdd(kLato, k).TipAbutt < 3 Then
                    .Print(StriSt(4))  '"    W = (A-A1+2tn.fr1(E1t-F.tr)).Sv     =";
                Else
                    .Print(StriSt(5))  '"    W = (A-A1).Sv                       =";
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).W, NozzAdd(kLato, k).W / NIUT))
                .Printa(StriSt(7))  '"    W11 = (A2+A5+A41+A42).Sv            =";
                .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).W11, NozzAdd(kLato, k).W11 / NIUT))
                If NozzAdd(kLato, k).TipAbutt < 3 Then
                    If NozzAdd(kLato, k).W22 > 0 Then
                        .Print(StriSt(8))  '"    W22 = (A2+A3+A41+A43+2tn.t.fr1)).Sv =";
                        .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).W22, NozzAdd(kLato, k).W22 / NIUT))
                    End If
                    If NozzAdd(kLato, k).W33 > 0 Then
                        .Print(StriSt(9))  '"    W33 = (see Fig.UG-41.1(a) )         =";
                        .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).W33, NozzAdd(kLato, k).W33 / NIUT))
                    End If
                Else
                    If NozzAdd(kLato, k).W22 > 0 Then
                        .Print(StriSt(10))  '"    W22 = (A2+A41).Sv                   =";
                        .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).W22, NozzAdd(kLato, k).W22 / NIUT))
                    End If
                End If
                For ii = 1 To 3
                    If NozzAdd(kLato, k).Wcomp(ii - 1) > 0 Then
                        Ped = ii.ToString & ii.ToString
                        .Printa(GlobalRoutines.FormatS(StriSt(11), Ped))  '"    Reference weld load, Wref           =";
                        .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).Wcomp(ii - 1), NozzAdd(kLato, k).Wcomp(ii - 1) / NIUT))
                    End If
                Next
                .Printa(StriSt(1))
                .Printa(StriSt(12))  '"Unit stresses per UW-15(b) and UG-45(c)  "
                If NozzAdd(kLato, k).Fillets Then
                    .Print(StriSt(13))  '"    Sfs (fillet welds in shear)         =";
                    .Printa(GlobalRoutines.FormatS(StriSt(14), NozzAdd(kLato, k).Fillets, NozzAdd(kLato, k).Fillets * psi))
                End If
                If NozzAdd(kLato, k).GrooTen Then
                    .Print(StriSt(15))  '"    Sgt (groove welds in tension)       =";
                    .Printa(GlobalRoutines.FormatS(StriSt(14), NozzAdd(kLato, k).GrooTen, NozzAdd(kLato, k).GrooTen * psi))
                End If
                If NozzAdd(kLato, k).GrooShe Then
                    .Print(StriSt(16))  '"    Sgs (groove welds in shear)         =";
                    .Printa(GlobalRoutines.FormatS(StriSt(14), NozzAdd(kLato, k).GrooShe, NozzAdd(kLato, k).GrooShe * psi))
                End If
                If NozzAdd(kLato, k).NozzShe Then
                    .Print(StriSt(17))  '"    Snw (nozzle wall in shear)          =";
                    .Printa(GlobalRoutines.FormatS(StriSt(14), NozzAdd(kLato, k).NozzShe, NozzAdd(kLato, k).NozzShe * psi))
                End If
                .Printa(StriSt(1))
                .Printa(StriSt(18))  '"Strength of Connection Elements "
                For i = 1 To 8
                    If NozzAdd(kLato, k).Str_Renamed(i) > 0 Then
                        Select Case i
                            Case 1, 2, 3, 4, 5, 6 : .Print(StriSt(18 + i))
                            Case 7
                                If NozzAdd(kLato, k).UW16 = 23 Or NozzAdd(kLato, k).UW16 = 24 Then
                                    .Print(StriSt(25))  '"    groove in tension (nozzle/shell)    =";
                                Else
                                    .Print(StriSt(26))  '"    groove in tension                   =";
                                End If
                            Case 8 : .Print(StriSt(27)) '"    groove in tension (nozzle/pad)      =";
                        End Select
                        .Printa(GlobalRoutines.FormatS(StriSt(6), NozzAdd(kLato, k).Str_Renamed(i), NozzAdd(kLato, k).Str_Renamed(i) / NIUT))
                    End If
                Next
                '*****************
                .Printa(StriSt(1))
                .Printa(StriSt(28))  '"Check of Strength Paths "
                iOK = True
                For i = 1 To 3
                    If NozzAdd(kLato, k).Paths(i - 1) > 0 Then
                        If NozzAdd(kLato, k).Paths(i - 1) > NozzAdd(kLato, k).Wcomp(i - 1) Then sign = ">" Else iOK = False : sign = "<"
                        .Printa(GlobalRoutines.FormatS(StriSt(29), _
                        i, i, _
                        NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + 1 - 1)), _
                        NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + 2 - 1)), _
                        NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + 3 - 1)), _
                        NozzAdd(kLato, k).Paths(i - 1), sign, NozzAdd(kLato, k).Wcomp(i - 1))) '"     Path #-#:####### +####### +####### =######## [lb] & ######  [lb]"
                    End If
                Next
                .Printa(StriSt(1))
                .Printa(StriSt(28))  '"Check of Strength Paths "
                iOK = True
                For i = 1 To 3
                    If NozzAdd(kLato, k).Paths(i - 1) > 0 Then
                        If NozzAdd(kLato, k).Paths(i - 1) > NozzAdd(kLato, k).Wcomp(i - 1) Then sign = ">" Else iOK = False : sign = "<"
                        .Printa(GlobalRoutines.FormatS(StriSt(32), _
                        i, i, _
                        NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + 1 - 1)) / NIUT, _
                        NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + 2 - 1)) / NIUT, _
                        NozzAdd(kLato, k).Str_Renamed(NozzAdd(kLato, k).i((i - 1) * 3 + 3 - 1)) / NIUT, _
                        NozzAdd(kLato, k).Paths(i - 1) / NIUT, sign, NozzAdd(kLato, k).Wcomp(i - 1) / NIUT)) '"     Path #-#:####### +####### +####### =######## [lb] & ######  [lb]"
                    End If
                Next
                '********************
                If iOK Then
                    .Printa(StriSt(30))  '"          The strength of the welds is satisfactory"
                Else
                    .Printa(StriSt(31))  '"          The strength of the welds is not satisfactory"
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'f
    Sub Disposiz(ByRef j As Short, ByRef k As Short, ByRef iDisp As Short)
        Dim O As wn_flan
        Select Case j
            Case 0, 4 'su cilindro
                If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).beta = 90 Then 'standard (radiale)
                    iDisp = 1
                ElseIf Nozzles(kLato, k).DCL = 0 Then  'inclinato longitudinalmente
                    iDisp = 2
                ElseIf Nozzles(kLato, k).DCL > 0 Then  'inclinato circonferenzialmente
                    iDisp = 3
                End If 'd
            Case 1 'su fondo
                Call Fondo(k, iDisp)
            Case 2 'su cono
                If Nozzles(kLato, k).beta = 90 Then
                    iDisp = 1
                ElseIf System.Math.Abs(Nozzles(kLato, k).beta - 90 + Involucr(kLato, Nozzles(kLato, k).InvolucroSU).R0) < 1 Then
                    iDisp = 2
                End If
            Case 3 'su conoide
                If Nozzles(kLato, k).DTL = 0 Then 'sotto
                    iDisp = 3
                ElseIf Nozzles(kLato, k).DTL = 180 Then  'sopra
                    If Nozzles(kLato, k).beta = 90 Then
                        iDisp = 1
                    Else
                        iDisp = 2
                    End If
                ElseIf Nozzles(kLato, k).DTL = 90 Or Nozzles(kLato, k).DTL = 270 Then  'di fianco
                    If Nozzles(kLato, k).beta = 90 Then
                        iDisp = 4
                    Else
                        iDisp = 5
                    End If
                End If
                '           IF Nozzles(kLato,k).beta = 90 THEN
                '              iDisp = 1
                '           ELSEIF ABS(Nozzles(kLato,k).beta - 90 + Involucr(Nozzles(kLato,k).InvolucroSU).R0) < 1 THEN
                '              iDisp = 2
                '           END IF
            Case 5 'Grande Fucinato
                Try
                    O = objMemb(Involucr(kLato, Nozzles(kLato, k).InvolucroSU).IndObject)
                    Select Case O.Mem.LOOSE
                        Case 4 'coperchio piano
                            If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).DTL = 0 And SistCoorCop = 1 Or Nozzles(kLato, k).DTL = 0 And SistCoorCop = 0 Then 'assiale centrato
                                iDisp = 1
                            Else
                                iDisp = 2
                            End If
                        Case 5, 6 'flat head with large opening
                            Exit Sub
                        Case 7 'reverse flange
                        Case Else 'flangioni loose e no
                            Call Fondo(k, iDisp)
                    End Select
                Catch e As Exception
                    MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
                End Try
        End Select
    End Sub
    Private Sub Fondo(ByVal k As Short, ByRef iDisp As Short)
        If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).DTL = 0 And Nozzles(kLato, k).beta = 0 Then 'assiale centrato
            iDisp = 1
        ElseIf Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).DTL = 0 Then  'radiale rispetto al fondo
            iDisp = 2
        ElseIf Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).beta = 0 Then  'radiale rispetto al cilindro
            iDisp = 3
        ElseIf Nozzles(kLato, k).DTL = 0 And Nozzles(kLato, k).beta = 0 Then  'assiale decentrato
            iDisp = 4
        End If 'e
    End Sub
    Sub ListSk(ByRef Sketch() As String, ByRef isk() As Short, ByRef k As Short)
        Dim i, j As Short
        Dim kk, Nimages As Short
        With frmNoz.DefInstance
            Nimages = .ListaImmagini.Images.Count - 1
            For i = 1 To Nimages
                Sketch(i) = .TagListaImmagini(i)
            Next
        End With
        Select Case div
            Case 0
                For i = 28 To 32 : Sketch(i) = "" : Next
                Select Case Nozzles(kLato, k).Tipo.Trim
                    Case "LWN3"
                        For i = 1 To 27 : Sketch(i) = "" : Next
                        Sketch(33) = ""
                        Sketch(34) = ""
                        Sketch(35) = ""
                        Sketch(37) = ""
                    Case "LWN1", "SPC1"
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1
                                For i = 1 To 12 : Sketch(i) = "" : Next
                                For i = 14 To 27 : Sketch(i) = "" : Next
                                Sketch(37) = ""
                            Case 3 'set-on groove
                                For i = 1 To 20 : Sketch(i) = "" : Next
                                For i = 21 To 27 : Sketch(i) = "" : Next
                            Case 4 'set-on fillet
                                For i = 1 To 19 : Sketch(i) = "" : Next
                                For i = 22 To 27 : Sketch(i) = "" : Next
                                Sketch(37) = ""
                        End Select
                        Sketch(35) = ""
                        Sketch(36) = ""
                    Case "LWN2"
                        For i = 1 To 8 : Sketch(i) = "" : Next
                        For i = 13 To 27 : Sketch(i) = "" : Next
                        Sketch(35) = ""
                        Sketch(36) = ""
                        Sketch(37) = ""
                    Case "WN1"
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove
                                For i = 1 To 22 : Sketch(i) = "" : Next
                                For i = 25 To 27 : Sketch(i) = "" : Next
                            Case 2
                                For i = 1 To 12 : Sketch(i) = "" : Next
                                For i = 14 To 24 : Sketch(i) = "" : Next
                                For i = 26 To 27 : Sketch(i) = "" : Next
                            Case 3
                                Sketch(1) = "" : Sketch(3) = ""
                                For i = 5 To 27 : Sketch(i) = "" : Next
                            Case Else
                                For i = 1 To 27 : Sketch(i) = "" : Next
                        End Select
                        Sketch(35) = ""
                        Sketch(36) = ""
                        Sketch(37) = ""
                    Case "WN", "LWN"
                        For i = 9 To 13 : Sketch(i) = "" : Next
                        Sketch(35) = ""
                        Sketch(36) = ""
                        Sketch(37) = ""
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove    6,7,8,14
                                For i = 1 To 5 : Sketch(i) = "" : Next
                                For i = 14 To 27 : Sketch(i) = "" : Next
                            Case 2 'set-in fillet
                                For i = 1 To 14 : Sketch(i) = "" : Next
                                For i = 19 To 34 : Sketch(i) = "" : Next
                            Case 3 'set-on groove
                                For i = 2 To 27 : Sketch(i) = "" : Next
                            Case 4 'set-on fillet
                                For i = 1 To 18 : Sketch(i) = "" : Next
                                For i = 23 To 34 : Sketch(i) = "" : Next
                            Case 5
                                For i = 1 To 25 : Sketch(i) = "" : Next
                        End Select
                    Case "OPEN"
                        For i = 1 To 34 : Sketch(i) = "" : Next
                        Sketch(36) = ""
                        Sketch(37) = ""
                End Select
            Case 1
                Select Case Nozzles(kLato, k).Tipo.Trim
                    Case "LWN3"
                        For i = 1 To 16 : Sketch(i) = "" : Next
                        For i = 19 To 27 : Sketch(i) = "" : Next
                        Sketch(31) = ""
                        Sketch(32) = ""
                        Sketch(33) = ""
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove
                                Sketch(17) = ""
                                For i = 28 To 30 : Sketch(i) = "" : Next
                            Case 2 'set-in fillet
                                For i = 17 To 18 : Sketch(i) = "" : Next
                            Case 4 'set-on fillet
                                Sketch(18) = ""
                                For i = 28 To 30 : Sketch(i) = "" : Next
                        End Select
                    Case "SPC1"
                    Case "LWN1"
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove
                                For i = 1 To 12 : Sketch(i) = "" : Next
                                For i = 14 To 31 : Sketch(i) = "" : Next
                                Sketch(33) = ""
                            Case 3 'set-on groove
                                For i = 1 To 32 : Sketch(i) = "" : Next
                        End Select
                    Case "LWN2"
                        For i = 5 To 18 : Sketch(i) = "" : Next
                        For i = 26 To 33 : Sketch(i) = "" : Next
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1
                                For i = 24 To 25 : Sketch(i) = "" : Next
                            Case 3 'set-on groove
                                For i = 1 To 4 : Sketch(i) = "" : Next
                                For i = 19 To 23 : Sketch(i) = "" : Next
                        End Select
                    Case "WN1"
                        For i = 1 To 13 : Sketch(i) = "" : Next
                        For i = 17 To 33 : Sketch(i) = "" : Next
                    Case "WN", "LWN"
                        For i = 1 To 4 : Sketch(i) = "" : Next
                        For i = 13 To 25 : Sketch(i) = "" : Next
                        For i = 28 To 33 : Sketch(i) = "" : Next
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove    6,7,8,14
                                For i = 5 To 6 : Sketch(i) = "" : Next
                                For i = 12 To 12 : Sketch(i) = "" : Next
                                For i = 26 To 27 : Sketch(i) = "" : Next
                            Case 3 'set-on groove
                                For i = 7 To 11 : Sketch(i) = "" : Next
                                For i = 26 To 27 : Sketch(i) = "" : Next
                            Case 5
                                For i = 1 To 25 : Sketch(i) = "" : Next
                        End Select
                    Case "OPEN"
                        For i = 1 To 30 : Sketch(i) = "" : Next
                        Sketch(32) = ""
                        Sketch(33) = ""
                End Select
            Case 2 'EuroNOrm
                Select Case Nozzles(kLato, k).Tipo
                    Case "LWN3"
                        For i = 1 To 4 : Sketch(i) = "" : Next
                        For i = 7 To Nimages : Sketch(i) = "" : Next
                    Case "LWN1", "SPC1"
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove
                                For i = 1 To 8 : Sketch(i) = "" : Next
                                For i = 10 To Nimages : Sketch(i) = "" : Next
                            Case 3 'set-on groove
                                For i = 1 To 8 : Sketch(i) = "" : Next
                                For i = 10 To Nimages : Sketch(i) = "" : Next
                                'in realt‡ l'immagine 9 Ë per setin
                            Case 4 'set-on fillet
                                For i = 1 To 8 : Sketch(i) = "" : Next
                                For i = 10 To Nimages : Sketch(i) = "" : Next
                            Case Else
                                For i = 1 To Nimages : Sketch(i) = "" : Next
                                ' Case 4 'set-on fillet
                                '    For i = 1 To 19: Sketch$(i) = "": Next
                                '    For i = 22 To 27: Sketch$(i) = "": Next
                                '    Sketch(37) = ""
                        End Select
                    Case "LWN2"
                        For i = 1 To Nimages : Sketch(i) = "" : Next
                    Case "WN1"
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove
                                For i = 1 To 9 : Sketch(i) = "" : Next
                                For i = 11 To Nimages : Sketch(i) = "" : Next
                            Case 3 'set-on groove
                                For i = 1 To 9 : Sketch(i) = "" : Next
                                For i = 11 To Nimages : Sketch(i) = "" : Next
                            Case Else
                                For i = 1 To Nimages : Sketch(i) = "" : Next
                        End Select
                    Case "WN", "LWN"
                        Select Case NozzAdd(kLato, k).TipAbutt
                            Case 1 'set-in groove
                                For i = 1 To 7 : Sketch(i) = "" : Next
                                For i = 9 To Nimages : Sketch(i) = "" : Next
                            Case 2 'set-in fillet
                                For i = 1 To 7 : Sketch(i) = "" : Next
                                For i = 9 To Nimages : Sketch(i) = "" : Next
                            Case 3 'set-on groove
                                For i = 1 To 6 : Sketch(i) = "" : Next
                                For i = 8 To Nimages : Sketch(i) = "" : Next
                            Case 4 'set-on fillet
                                For i = 1 To 6 : Sketch(i) = "" : Next
                                For i = 8 To Nimages : Sketch(i) = "" : Next
                            Case 5
                                For i = 1 To 6 : Sketch(i) = "" : Next
                                For i = 8 To Nimages : Sketch(i) = "" : Next
                        End Select
                    Case "OPEN"
                        For i = 5 To Nimages : Sketch(i) = "" : Next
                End Select
        End Select
        j = 0
        For i = 1 To Nimages
            If Sketch(i) = "" Then
                For kk = i + 1 To Nimages
                    If Not Sketch(kk) = "" Then
                        GlobalRoutines.SWAP(Sketch(i), Sketch(kk))
                        j = j + 1
                        isk(j) = kk
                        Exit For
                    End If
                Next  'a
            Else
                j = j + 1
                isk(j) = i
            End If
        Next  'b
        For i = j + 1 To Nimages : isk(i) = 0 : Next
    End Sub
    Sub Ratings(ByRef Pmax As Single, ByVal Pdes As Single, ByVal Tdes As Single, _
                ByVal Rati As Short, ByRef MatGr As String, _
                ByVal k As Short, ByVal n As Short, ByVal mode As Object)
        Try
            '   Stringa4$(1) = "Stub end"
            '   Stringa4$(2) = " 150"
            '   Stringa4$(3) = " 300"
            '   Stringa4$(4) = " 400"
            '   Stringa4$(5) = " 600"
            '   Stringa4$(6) = " 900"
            '   Stringa4$(7) = "1500"
            '   Stringa4$(8) = "2500"
            If Matdim(Nozzles(k, n).IndexF) Is Nothing Then MatdimScelta(Nozzles(k, n).IndexF, 7, k, , n)
            Dim Mat As LibMat.MaterialeNew1 = Matdim(Nozzles(k, n).IndexF)
            If Rati > 0 And Tdes > 0 Then Pmax = Mat.LegRat(Tdes, Rati, MatGr)
            If mode = 0 Then Exit Sub
            Dim FormRat As frmRat = New frmRat
            With FormRat
                .k = k : .n = n
                .Pdes = Pdes 'Pdes
                .Tdes = Tdes 'Tdes
                .Rati = Rati
            End With
            If Not ContinuoAuto Then
                FormRat.ShowDialog()
            Else
                FormRat.frmRat_Activated(FormRat, New System.EventArgs)
                FormRat.Command1_Click(FormRat.Command1, New System.EventArgs)
                'continuoauto
            End If
            Pmax = FormRat.PrRat
            MatGr = FormRat.MatGr
            FormRat.Dispose()
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub ThWeldMin(ByRef k As Short)
        Dim tmin1, tc, tmin, tmin2 As Single
        Dim Spess As Single
        Dim Log1, Log2 As Boolean
        NozzAdd(kLato, k).Gola41 = 0 'outward nozzle   min code
        NozzAdd(kLato, k).Gola42 = 0 'pad              min code
        NozzAdd(kLato, k).Gola43 = 0 'inward nozzle   min code
        'Calctc------------------------------------------
        tmin = Nozzles(kLato, k).Spess
        If tmin = 0 Then tmin = (Nozzles(kLato, k).DiOn - Nozzles(kLato, k).DiIn) / 2
        If Nozzles(kLato, k).InvolucroSU > -1 Then
            tmin1 = Involucr(kLato, Nozzles(kLato, k).InvolucroSU).Spess
        Else
            tmin1 = Nozzles(kLato, -Nozzles(kLato, k).InvolucroSU).Spess
        End If
        Spess = tmin1
        Log1 = div = 1 And (NozzAdd(kLato, k).UW16 = 17 Or NozzAdd(kLato, k).UW16 = 18)
        Log2 = div = 1 And NozzAdd(kLato, k).UW16 = 18
        If tmin1 < tmin And tmin1 > 0 Or Log1 Then tmin = tmin1
        tmin2 = Nozzles(kLato, k).PadT
        If Log2 Then tmin2 = tmin2 - Nozzles(kLato, k).Spess
        If tmin2 > 0 And tmin2 < tmin Then tmin = tmin2
        If tmin2 < tmin1 Then tmin1 = tmin2
        If div = 1 And (NozzAdd(kLato, k).UW16 = 28 Or NozzAdd(kLato, k).UW16 = 29) Then
            tc = 1.25 * tmin 'Fig. AD-621.1 (c-1) (c-2)
        ElseIf div = 1 And NozzAdd(kLato, k).UW16 = 30 Then
            tc = 1.25 * tmin * 1.414
        ElseIf Log1 Then
            tc = 0.7 * tmin
        Else
            If 0.75 * inc < tmin Or tmin = 0 Then tmin = 0.75 * inc
            tc = 0.7 * tmin
            If 0.25 * inc < tc Then tc = 0.25 * inc
        End If
        If div = 0 Or div = 2 Then
            Select Case NozzAdd(kLato, k).UW16
                Case 1, 5, 6, 7, 8, 13, 26, 27, 29
                    NozzAdd(kLato, k).Gola41 = tc
                Case 2
                    NozzAdd(kLato, k).Gola41 = tc
                    NozzAdd(kLato, k).Gola42 = tmin / 2
                Case 3, 4
                    NozzAdd(kLato, k).Gola41 = tc
                    NozzAdd(kLato, k).Gola42 = tmin / 2
                    NozzAdd(kLato, k).Gola43 = tmin / 2
                Case 9, 10, 11, 12
                Case 14
                    NozzAdd(kLato, k).Gola41 = 0.7 * tmin
                    NozzAdd(kLato, k).Gola42 = tmin / 2
                    NozzAdd(kLato, k).Gola43 = tc
                Case 15, 16, 17
                    NozzAdd(kLato, k).Gola41 = tc
                    NozzAdd(kLato, k).Gola43 = tc
                    If tc < 1.25 * tmin / 2 Then
                        NozzAdd(kLato, k).Gola41 = 1.25 * tmin / 2
                        NozzAdd(kLato, k).Gola43 = 1.25 * tmin / 2
                    End If
                Case 18
                    NozzAdd(kLato, k).Gola41 = tc
                    NozzAdd(kLato, k).Gola42 = tc
                    NozzAdd(kLato, k).Gola43 = tc
                    If tc < 1.25 * tmin / 2 Then
                        NozzAdd(kLato, k).Gola41 = 1.25 * tmin / 2
                        NozzAdd(kLato, k).Gola42 = 1.25 * tmin / 2
                    End If
                Case 19, 20, 21, 22
                    NozzAdd(kLato, k).Gola41 = 0.5 * tmin
                    NozzAdd(kLato, k).Gola43 = 0.7 * tmin
                Case 23, 24, 25
                    NozzAdd(kLato, k).Gola41 = tc
                    NozzAdd(kLato, k).Gola42 = tmin / 2
                    NozzAdd(kLato, k).Gola43 = 0.7 * tmin
            End Select
        Else
            Select Case NozzAdd(kLato, k).UW16
                Case 1, 2, 3, 4, 19 To 27, 31
                Case 5 To 13, 32, 33
                    NozzAdd(kLato, k).Gola41 = tc
                Case 14, 15, 16
                    NozzAdd(kLato, k).Gola41 = tc
                    NozzAdd(kLato, k).Gola42 = 0.6 * tmin1
                Case 17, 18
                    NozzAdd(kLato, k).Gola41 = tc
                Case 28, 29, 30
                    NozzAdd(kLato, k).Gola42 = tc
            End Select
        End If
        Exit Sub
    End Sub
    Sub WeldDet(ByRef k As Short, ByRef mode As Short)
        Dim i As Short
        Dim Rad2 As Single
        Dim NfieldW, jj As Short
        Dim Gola42, Gola41, Gola43 As String
        Dim Rad1 As Single
        Dim Archiv(19) As Short
        Dim dAiu(19) As String
Rig:    Dim Domand(10) As String
        Dim Rispost(10) As String
        Dim Sketch(40) As String
        Dim isk(40) As Short
        Dim locEsp(9) As Short
        Dim locCom(6) As Short
        locEsp(2) = -1 : locEsp(1) = -2 : locEsp(0) = -3
        Call ThWeldMin(k)
        If div = 0 Or div = 2 Then
            Select Case NozzAdd(kLato, k).UW16
                Case 20, 21, 23, 24, 16, 18
                    Rad2 = 1
                Case Else
                    Rad2 = 1.414
            End Select
            Rad1 = 1.414
        Else
            Select Case NozzAdd(kLato, k).UW16
                Case 28 To 30
                    Rad1 = 1
                Case Else
                    Rad1 = 1.414
            End Select
            Rad2 = 1
        End If
        Gola41 = GlobalRoutines.myStr(NozzAdd(kLato, k).Gola41 * 1.414 * kLength, 3, 2, False)
        Gola42 = GlobalRoutines.myStr(NozzAdd(kLato, k).Gola42 * Rad1 * kLength, 3, 2, False)
        Gola43 = GlobalRoutines.myStr(NozzAdd(kLato, k).Gola43 * Rad2 * kLength, 3, 2, False)
        Domand(1) = "Lato sald. esterno bocch (min." & Gola41 & ") " & UnitLength
        Domand(2) = "Lato saldatura pad       (min." & Gola42 & ") " & UnitLength
        NfieldW = 2
        If div = 0 Or div = 2 Then
            Select Case NozzAdd(kLato, k).UW16
                Case 28
                    Exit Sub
                    '    NfieldW = 2
                Case 23, 24
                    Domand(3) = "Alt.sald.shell/bocchello (min." & Gola43 & ") " & UnitLength
                    Domand(4) = "Alt.sald. pad /bocchello (min." & Gola43 & ") " & UnitLength
                    NfieldW = 4
                Case 20, 21
                    Domand(3) = "Alt.sald.shell/bocchello (min." & Gola43 & ") " & UnitLength
                    NfieldW = 3
                Case 19, 22
                    Domand(3) = "Lato saldatura interna   (min." & Gola43 & ") " & UnitLength
                    NfieldW = 3
                Case 3, 4
                    Domand(3) = "Lato sald. pad interno   (min." & Gola43 & ") " & UnitLength
                    NfieldW = 3
                Case Else
                    Domand(3) = "Lato sald. interno bocch (min." & Gola43 & ") " & UnitLength
                    NfieldW = 3
            End Select
            '??????????????????????????????????????????????????
            '            NozzAdd(kLato, k).Leg41 = 0
            '           NozzAdd(kLato, k).Leg42 = 0
            '          NozzAdd(kLato, k).Leg43 = 0
            '???????????????????????????????????????????????????
            If NozzAdd(kLato, k).Leg41 < GlobalRoutines.ValVir(Gola41) Then
                Rispost(1) = Gola41 & "  "
            Else
                Rispost(1) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg41 * kLength, 3, 2, False)
            End If
            If NozzAdd(kLato, k).Leg42 < GlobalRoutines.ValVir(Gola42) Then
                Rispost(2) = Gola42 & "  "
            Else
                Rispost(2) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg42 * kLength, 3, 2, False)
            End If
            If NozzAdd(kLato, k).Leg43 < GlobalRoutines.ValVir(Gola43) Then
                Rispost(3) = Gola43 & "  "
            Else
                Rispost(3) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg43 * kLength, 3, 2, False)
            End If
            If NozzAdd(kLato, k).UW16 = 23 Or NozzAdd(kLato, k).UW16 = 24 Then
                If NozzAdd(kLato, k).Leg44 < GlobalRoutines.ValVir(Gola43) Then
                    Rispost(4) = Gola43 & "  "
                Else
                    Rispost(4) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg44 * kLength, 3, 2, False)
                End If
            End If
            If NozzAdd(kLato, k).TipAbutt > 2 Then Domand(2) = "-"
        Else
            NfieldW = 2
            Select Case NozzAdd(kLato, k).UW16
                Case 1, 2, 3, 4, 19 To 27, 31
                    Exit Sub
                Case 5 To 13
                    Domand(2) = "-"
                Case 14, 15, 16
                Case 17, 18
                    Domand(2) = "-"
                Case 28, 29, 30
                    Domand(1) = "Alt. sald. sleeve (tw, min." & Gola41 & " " & UnitLength
            End Select
            If NozzAdd(kLato, k).Leg41 < GlobalRoutines.ValVir(Gola41) Then
                Rispost(1) = Gola41 & "  "
            Else
                Rispost(1) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg41 * kLength, 3, 2, False)
            End If
            If NozzAdd(kLato, k).Leg42 < GlobalRoutines.ValVir(Gola42) Then
                Rispost(2) = Gola42 & "  "
            Else
                Rispost(2) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg42 * kLength, 3, 2, False)
            End If
            If NozzAdd(kLato, k).Leg43 < GlobalRoutines.ValVir(Gola43) Then
                Rispost(3) = Gola43 & "  "
            Else
                Rispost(3) = GlobalRoutines.myStr(NozzAdd(kLato, k).Leg43 * kLength, 3, 2, False)
            End If
        End If
        For i = 1 To 4
            If GlobalRoutines.ValVir(Rispost(i)) < 2 * kLength Then Domand(i) = "-"
        Next
        jj = 0
        For i = 1 To NfieldW
            If (Domand(i)) = Chr(45) Then
                locCom(i) = 0
            Else
                jj = jj + 1
                locCom(i) = jj
                locEsp(jj + 3) = i
            End If 'f
        Next i
        NfieldW = jj
        For i = 1 To NfieldW
            Domand(i) = Domand(locEsp(i + 3))
            Rispost(i) = Rispost(locEsp(i + 3))
        Next i
        If mode = 0 Then
            If NfieldW > 0 Then
                Monitor.Motore.InputDati(NfieldW, "Weld details", Domand, Rispost, "", Archiv, dAiu)
            Else
                MessageBox.Show("No details", "AsmeVip")
            End If
        End If
        If locCom(1) = 0 Then
            NozzAdd(kLato, k).Leg41 = 0
        Else
            If (mode = 0 Or NozzAdd(kLato, k).Leg41 = 0) Then NozzAdd(kLato, k).Leg41 = GlobalRoutines.ValVir(Rispost(locCom(1))) / kLength
        End If 'Else NozzAdd(kLato, k).Leg41 = 0
        If locCom(2) = 0 Then
            NozzAdd(kLato, k).Leg42 = 0
        Else
            If (mode = 0 Or NozzAdd(kLato, k).Leg42 = 0) Then NozzAdd(kLato, k).Leg42 = GlobalRoutines.ValVir(Rispost(locCom(2))) / kLength
        End If 'Else NozzAdd(kLato, k).Leg42 = 0
        If locCom(3) = 0 Then
            NozzAdd(kLato, k).Leg43 = 0
        Else
            If (mode = 0 Or NozzAdd(kLato, k).Leg43 = 0) Then NozzAdd(kLato, k).Leg43 = GlobalRoutines.ValVir(Rispost(locCom(3))) / kLength
        End If 'Else NozzAdd(kLato, k).Leg43 = 0
        If locCom(4) = 0 Then
            NozzAdd(kLato, k).Leg44 = 0
        Else
            If (mode = 0 Or NozzAdd(kLato, k).Leg44 = 0) Then NozzAdd(kLato, k).Leg44 = GlobalRoutines.ValVir(Rispost(locCom(4))) / kLength
        End If 'Else NozzAdd(kLato, k).Leg44 = 0
    End Sub
    Public Sub Str234(ByRef Testo As String)
        If A0Ext = 0 Then
            Testo = Testo & " Area richiesta: " & GlobalRoutines.myStr(A0 * kLength ^ 2, 5, 2, False) & " " & UnitArea & "|"
        Else
            Testo = Testo & " Area richiesta (p int.): " & GlobalRoutines.myStr(A0 * kLength ^ 2, 5, 2, False) & " " & UnitArea & "|"
            If Not VerificandoPI Then Testo = Testo & " Area richiesta (p est.): " & GlobalRoutines.myStr(A0Ext * kLength ^ 2, 5, 2, False) & " " & UnitArea & "|"
        End If
        Testo = Testo & " Area effettiva: " & GlobalRoutines.myStr((a1 + a2 + A3 + A5 + A41 + A42 + A43) * kLength ^ 2, 5, 2, False) & " " & UnitArea & "|"
        If Not VerificandoPI And A0Ext > 0 Then           '140506
            Testo = Testo & " Area disp (p est.): " + GlobalRoutines.myStr((a1ext + a2ext + A3 + A5 + A41 + A42 + A43) * kLength ^ 2, 5, 2, False) & UnitArea & "|" '140506
        End If
        Testo = Testo & "(A1= " & GlobalRoutines.myStr(a1 * kLength ^ 2, 5, 2, False) & ";A2= " & _
                                  GlobalRoutines.myStr(a2 * kLength ^ 2, 5, 2, False) & ";A5= " & _
                                  GlobalRoutines.myStr(A5 * kLength ^ 2, 5, 2, False) & ")" & "|"
        Testo = Testo & "(A41=" & GlobalRoutines.myStr(A41 * kLength ^ 2, 5, 2, False) & ";A42=" & _
                                  GlobalRoutines.myStr(A42 * kLength ^ 2, 5, 2, False) & ";A43=" & _
                                  GlobalRoutines.myStr(A43 * kLength ^ 2, 5, 2, False) & ")" & "|"
        If A3 > 0 Then Testo = Testo & "(A3=" & GlobalRoutines.myStr(A3 * kLength ^ 2, 5, 2, False) & ")" & "|"
    End Sub
    Public Function Decision(ByRef Testo As String, ByRef jmemb As Short, ByRef nn As Short, ByRef ii As Short) As Short
        Dim Stringa(7) As String
        Dim junk As Short
        Dim Risult(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        Testo = "La compensazione dell'apertura Ë insufficiente." & vbCrLf
        If A0Ext > A0Int And div = 0 Or A0Ext > A0 And div = 1 Then
            Testo = Testo & "Il caso dimensionante Ë la pressione esterna." & vbCrLf
        End If
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11
                If ii = 2 Then Testo = "I requisiti App 1-7 non sono soddisfatti." & vbCrLf
            Case 3, 4, 5
                Select Case ii
                    Case 1 : Testo = Testo & vbCrLf & "I requisiti AD-540.1(a) (verifica del 100%)" & vbCrLf & " non sono soddisfatti." & vbCrLf
                    Case 2 : Testo = Testo & vbCrLf & "I requisiti AD-540.1(b) (verifica dei 2/3)" & vbCrLf & " non sono soddisfatti." & vbCrLf
                End Select
        End Select
        Str234(Testo)
        Testo = Testo & "   Cosa vuoi fare ?"
        Select Case Nozzles(kLato, nn).Tipo.Trim
            Case "WN", "WN1"
                Stringa(1) = "Introdurre un rinforzo o variarne le dimensioni"
                Stringa(2) = "Cambiare lo spessore del tronchetto"
                Stringa(3) = "Ritornare all'input "
                Stringa(4) = "Procedere ugualmente"
                junk = Monitor.Motore.Quale(4, "Rinforzo  WN: " & RTrim(Nozzles(kLato, nn).Mark), Stringa, "", 1, Testo)
                Select Case junk
                    Case 0
                        Decision = 6 : Exit Function
                    Case 1
                        Nozzles(kLato, nn).Tipo = "WN1"
                        Risult(1) = GlobalRoutines.myStr(Nozzles(kLato, nn).Padd * kLength, 4, 2, False)
                        Risult(2) = GlobalRoutines.myStr(Nozzles(kLato, nn).PadT * kLength, 4, 2, False)
                        Stringa(1) = "Pad diameter" & UnitLength
                        Stringa(2) = "Pad thickness" & UnitLength
                        If Not Monitor.Motore.InputDati(2, "Reinforcing Pad", Stringa, Risult, "", Arch, dAiu) Then
                            Decision = 6 : Exit Function
                        End If
                        Nozzles(kLato, nn).Padd = GlobalRoutines.ValVir(Risult(1)) / kLength
                        Nozzles(kLato, nn).PadT = GlobalRoutines.ValVir(Risult(2)) / kLength
                        Decision = 1 '
                    Case 2
                        If Not DatiNozzles(kLato, jmemb, nn) Then
                            Decision = 6 : Exit Function
                        End If
                        Decision = 2 'GoTo Inizio '
                    Case 3
                        Decision = 3 '
                        If Not DatiNozzles(kLato, jmemb, nn) Then
                            Decision = 6 : Exit Function
                        End If
                    Case 4
                        Decision = 4 'GoTo 18019 '
                End Select
            Case "LWN", "LWN1"
                Stringa(1) = "Introdurre o variare lo sp.autorinforzo"
                Stringa(2) = "Ritornare all'input dei dati"
                Stringa(3) = "Procedere ugualmente"
                junk = Monitor.Motore.Quale(3, "Rinforzo LWN: " & RTrim(Nozzles(kLato, nn).Mark), Stringa, "", 1, Testo)
                Select Case junk
                    Case 0
                        Decision = 6 : Exit Function
                    Case 1
                        Decision = 5
                        If Not DatiNozzles(kLato, jmemb, nn) Then
                            Decision = 6 : Exit Function
                        End If
                    Case 2
                        Decision = 3
                        If Not DatiNozzles(kLato, jmemb, nn) Then
                            Decision = 6 : Exit Function
                        End If
                    Case 3
                        Decision = 4
                End Select
            Case "LWN2", "LWN3"
                Stringa(1) = "Ritornare all'input dati bocchello   "
                Stringa(2) = "Ritornare all'input generale dei dati"
                Stringa(3) = "Procedere ugualmente"
                junk = Monitor.Motore.Quale(3, "Rinforzo scarpa: " & Nozzles(kLato, nn).Mark.Trim, Stringa, "", 1, Testo)
                Select Case junk
                    Case 1
                        Decision = 3
                        If Not DatiNozzles(kLato, jmemb, nn) Then
                            Decision = 6 : Exit Function
                        End If
                    Case 3
                        Decision = 4
                    Case Else
                        Decision = 6
                End Select
            Case Else
                Stringa(1) = "Ritornare all'input dati bocchello   "
                Stringa(2) = "Ritornare all'input generale dei dati"
                Stringa(3) = "Procedere ugualmente"
                junk = Monitor.Motore.Quale(3, "Aperture tipo " & Nozzles(kLato, nn).Tipo.Trim & ": " & Nozzles(kLato, nn).Mark.Trim, Stringa, "", 1, Testo)
                Select Case junk
                    Case 1
                        Decision = 3
                        If Not DatiNozzles(kLato, jmemb, nn) Then
                            Decision = 6 : Exit Function
                        End If
                    Case 3
                        Decision = 4
                    Case Else
                        Decision = 6
                End Select
        End Select
    End Function
    Public Function Massone(ByRef KL As Short, ByRef nn As Short) As Boolean
        Dim NomeStandard As String
        Dim Res As Integer
        Dim Testo As String = ""
        Dim Tit As String = ""
        Dim Flags As Integer
        Flangia = New Grafica.Flangia
        Flangia.DoveMotore = Monitor.Motore
        Massone = True
        With Nozzles(KL, nn)
            If .FlanNonStd = 0 Then
                If .Tipo = "Sola" Then GoTo ExSub
                If .indiceF = 1 And Not Left(.Tipo, 1) = "L" Then GoTo ExSub
                If .Rati = 0 Then GoTo ExSub
            End If
            GlobalRoutines.FormatS("non|")
            Tit = "Bocchello " & .Mark
            If Not .indiceF = 1 Then
                NomeStandard = Flangia.NomeTabella(Nozzles(KL, nn).indiceF)
                Testo = GlobalRoutines.FormatS(Helpstringa(IDH_ST_NOANSIB165), NomeStandard)
            ElseIf Left(.Tipo, 1) = "L" Then
                Testo = Helpstringa(IDH_ST_NOWELDINGNECK)
            End If
            If Not ContinuoAuto Then
                Flags = RoutBase1.ChiaviMess.MessQuestion + RoutBase1.ChiaviMess.MessYesNo
                If .FlanNonStd = 0 Then Flags = Flags + RoutBase1.ChiaviMess.MessDef2
                Res = MostraAiuto(IDH_XR_APFLANGIA, Flags, Testo, Tit)
            Else
                If .FlanNonStd = 1 Then Res = RoutBase1.ChiaviMess.MessSi Else Res = RoutBase1.ChiaviMess.Messno
            End If
            If Res = RoutBase1.ChiaviMess.Messno Then
                .FlanNonStd = 0
                GoTo ExSub
            Else
                .FlanNonStd = 1
            End If
            If .IndObject = 0 Then
                .IndObject = NuovoIndObj()
                objMemb(.IndObject) = New wn_flan
            End If
        End With
        kLato = KL
        kNozzle = nn
        Dim jSave As Short = jInvolucr
        jInvolucr = 0
        With CType(objMemb(Nozzles(KL, nn).IndObject), wn_flan)
            If .Mp(3) = 0 Then
                .TipCalc = 1
                If Left(Nozzles(KL, nn).Tipo, 1) = "L" Then
                    Flangia.K3 = 4
                Else
                    Flangia.K3 = 1
                End If
                Flangia.Facing = 1
                If Nozzles(KL, nn).indiceF = 0 Then Nozzles(KL, nn).indiceF = 1
                Flangia.TabFlan = Nozzles(KL, nn).indiceF
                Flangia.carica((clsInizio.DiscoRam))
                Flangia.SetDiam(Nozzles(KL, nn).DiaN)
                Flangia.SetRating(Nozzles(KL, nn).Rati)
                If Not Flangia.Leggi(Visual:=False) Then
                    If ContinuoAuto Then
                        ContinuoAuto = False
                        Monitor.Motore.ProgrAmmazza()
                        Testo = GlobalRoutines.FormatS(Helpstringa(1154), Nozzles(KL, nn).DiaN.ToString, Nozzles(KL, nn).Rati.ToString) ' "Non sono stati trovati nella libreria delle flange|i dati dimensionali relativi al diametro &|e al rating &. Di conseguenza il calcolo secondo|App.2 non verr‡ effettuato."
                        MostraAiuto(1154, , Testo)
                        Massone = False
                        Exit Function
                    Else
                        Testo = GlobalRoutines.FormatS(Helpstringa(1155), Nozzles(KL, nn).DiaN.ToString, Nozzles(KL, nn).Rati.ToString) ' "Non sono stati trovati nella libreria delle flange|i dati dimensionali relativi al diametro &|e al rating &. Di conseguenza il calcolo secondo|App.2 non verr‡ effettuato."
                        MostraAiuto(1155, , Testo)
                    End If
                End If
                .Mem.LOOSE = 0
                .Mem.File = ".wnf"
                .Mp(3) = Flangia.Diamext
                .Zp(3) = .Mp(3) / inc
                .Mp(4) = Flangia.BC
                .Zp(4) = .Mp(4) / inc
                .Mp(6) = Flangia.Diamint
                .Zp(6) = .Mp(6) / inc
                .Mp(7) = (Flangia.DiamTr - Flangia.Diamint) / 2
                .Zp(7) = .Mp(7) / inc
                .Mp(8) = (Flangia.x - Flangia.Diamint) / 2
                If .Mp(8) < .Mp(7) Then .Mp(8) = .Mp(7)
                .Zp(8) = .Mp(8) / inc
                .Mp(9) = Flangia.Spessore
                .Zp(9) = .Mp(9) / inc
                If Left(Nozzles(KL, nn).Tipo, 1) = "L" Then
                    .Mp(10) = 1.5 * .Mp(7)
                Else
                    .Mp(10) = Flangia.Altezza - Flangia.Spessore - Flangia.SpessGrad
                End If
                .Zp(10) = .Mp(10) / inc
                .Mp(11) = Nozzles(KL, nn).CorrA
                If Nozzles(KL, nn).ONn > Nozzles(KL, nn).CorrA Then .Mp(11) = Nozzles(KL, nn).ONn '140306
                .Zp(11) = .Mp(11) / inc
                .Mem.TIR = Flangia.DiaBolts
                .Mp(14) = 0 '140306
                .Mp(13) = Flangia.NumBolts
                .Zp(13) = Flangia.NumBolts
                .RichiaTir()
            End If
            Dim formTabSave As frmTab = formTab
            formTab = New frmTab
Rif:        If Not ContinuoAuto Then
                formTab.ShowDialog()
            Else
                formTab.SetPagina(1)
                formTab.cmdCliccato = False
                formTab.cmdCalc_Click(Nothing, New EventArgs)
                If .qbflan = 5 Then
                    Massone = False
                    ContinuoAuto = False
                    Monitor.Motore.ProgrAmmazza()
                    GoTo Rif
                End If
                formTab.cmdOk_Click(Nothing, New EventArgs)
            End If
            formTab.Close()
            formTab.Dispose()
            jInvolucr = jSave
            formTab = formTabSave
            If .qbflan = -99 Then Massone = False
        End With
ExSub:
        Flangia = Nothing
    End Function
    Public Sub SuperRatings(ByRef pr As Single, ByRef pr0 As Single, ByRef nn As Short, ByRef MatGr As String)
        If Nozzles(kLato, nn).indiceF = 0 Then Nozzles(kLato, nn).indiceF = 1
        If Nozzles(kLato, nn).indiceF = 1 And Nozzles(kLato, nn).Rati > 0 Then
            If Nozzles(kLato, nn).IndexF < 1 Then Nozzles(kLato, nn).IndexF = NuovoIndice()
            If Matdim(Nozzles(kLato, nn).IndexF) Is Nothing Then
                Matdim(Nozzles(kLato, nn).IndexF) = New LibMat.MaterialeNew1
                'If Nozzles(kLato, nn).RecIndF > 0 Then
                'Matdim(Nozzles(kLato, nn).IndexF).Indmat = Nozzles(kLato, nn).RecIndF
                'Matdim(Nozzles(kLato, nn).IndexF).RecupMat(clsInizio.Archdir)
                'Else
                'Matdim(Nozzles(kLato, nn).IndexF) = Matdim(Nozzles(kLato, nn).indice)
                'End If
            End If
            kNozzle = nn
            Call Ratings(pr, P0, TempDes, Nozzles(kLato, nn).Rati, MatGr, kLato, nn, 1)
            Nozzles(kLato, nn).RecIndF = Matdim(Nozzles(kLato, nn).IndexF).Indmat
            Call Ratings(pr0, P0, 32, Nozzles(kLato, nn).Rati, MatGr, kLato, nn, 0)
        Else
            pr = 1.0E+20 : pr0 = 1.0E+20
        End If
    End Sub

    Public Function AllGeom(ByRef nn As Short, ByRef jmemb1 As Short, ByRef tch As Single, _
                            ByRef tsh As Single, ByRef trh As Single, ByRef tcs As Single, _
                            ByRef Trs As Single, ByRef rc As Single, ByRef LSH As Single, _
                            ByRef CosecB As Single) As Short
        Dim i As Short
        If swn = 1 Then 'fondi
            i = GeomFon(nn, jmemb1, tch, tsh, trh, Rn, LSH, CosecB)
            '                                 l    l    l    g   p     l
        ElseIf swn = 0 Then
            i = GeomCyl(nn, jmemb1, tcs, Trs, Rn, rc, CosecB)
            '                                 p    p    g   p    l
        ElseIf swn = 2 Then
            i = GeomCon(nn, jmemb1, tcs, Rn, CosecB)
            '                                 p   g     l
        ElseIf swn = 3 Then
            i = GeomOid(nn, jmemb1, tcs, Rn, CosecB)
        ElseIf swn = -1 Then  'Bocchelli
            i = GeomNoz(nn, jmemb1, tcs, Trs, Rn, rc, CosecB)
        End If
        AllGeom = i
    End Function

    Public Function VerificaAllN(ByRef nn As Short, ByRef jmemb1 As Short, ByRef Sn As Single) As Boolean
        Dim Testo As String
        VerificaAllN = True
        If VerificandoPI Then
            Sn = Nozzles(kLato, nn).AllNPI
        Else
            Sn = Nozzles(kLato, nn).AllN
        End If
        If Sn = 0 Then
            Testo = "   Non Ë stata specificata la tensione ammissibile per il bocchello " & Trim(Nozzles(kLato, nn).Mark)
            If VerificandoPI Then
                Testo = Testo & "|nelle condizioni di Prova idraulica."
            Else
                Testo = Testo & "|nelle condizioni di Progetto."
            End If
            If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo aperture", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then VerificaAllN = False : Exit Function
            If Not DatiNozzles(kLato, jmemb1, nn) Then VerificaAllN = False : Exit Function
        End If
        If VerificandoPI Then
            Sn = Nozzles(kLato, nn).AllNPI
        Else
            Sn = Nozzles(kLato, nn).AllN
        End If
    End Function
End Module