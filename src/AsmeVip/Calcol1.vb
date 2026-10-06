Option Strict Off
Option Explicit On
Imports LibMat
Imports RoutBase1
Module Calcol1
    Private RaggioBocca(2), OffSetMax(2) As Single
    Private PiastradaTubi As wn_PT
	Private sidPmInt, sidPmExt As Single
	Private sidQInt, sidQExt As Single
	Private Salva(10) As Single
    Private Sloc(2) As Single
	Private RP, Rpp As Single
	Private ifl As Short
	Private Rtf As String
	Private Aspp, DLDL As Single
    Private StriSt(31) As String
	Private aLe, Ds, psig1, tms As Single ', psig2 As Single
	Private P0sav, Scyl, eff As Single
    Private deltac1, deltac, PSE1 As Single
	Private ArLExt(2) As Single
	Private AeLExt(2) As Single
	Private QlExt(2) As Single
    Private ang, s, tts, R As Single
	Private Arch(20) As Short
	Private dAiu(20) As String
	Private SpminCono(4) As Single
	Private SpminCili(4) As Single
	Private ATL(2) As Single
	Private BBB(2) As Single
	Private AAA(2) As Single
	Private Ips(2) As Single
	Private iP(2) As Single
	Private Rsav, SWR As Single
	Private t0c, E, t0s As Single
	Private TNSY, TCSY As Single
	Private TIR As String
    Private tgov, tgov1 As Single
    Private MWDTrule As String
    Private MWDTclause As String
    Private MWDTtemp, tgov2 As Single
    Private YieldMWDT As Single
    Private PNumber As String
    Private iGr As Short
    Private Cod, TIMA, Tipo As String
    Private n As Short
    Function ConShells(ByRef jmemb As Short, ByRef iBocc As Short) As Short
        Dim Testo As String
        Dim pHImax1 As Single
        Dim Raggio, alc As Single
        Dim uu As String = ""
        Dim t0th, t0hy As Single
        Dim TPR As Single
        Dim tcs As Single
        Dim i, k As Short
        Dim jRec, iyy As Short
        Dim tc As Single
        Dim ts, Ak, PSE As Single
        Dim AeL, delta, ArL As Single
        Dim t, Ql, tr As Single
        Dim Press, T0, akm As Single
        Dim Indmat As Short
        Dim NonVer As Boolean
        Dim vbMsg As MessageBoxButtons
        Dim ResMsg As DialogResult
        Dim lContinuoAuto As Boolean
        Dim nn As Short
        Dim aKZ As Single
        Dim Stringa(20) As String
        Dim Risult(20) As String
        Dim FileFor As Str50
        Dim valido As Boolean
        lContinuoAuto = ContinuoAuto
        jInvolucr = jmemb
        ConShells = False
        AggiustaHydr(kLato, jmemb, 0, P0, VerificandoPI)
        Select Case Involucr(kLato, jmemb).Tipo
            Case 2 : STStr = "Conical shells"
            Case 3 : STStr = "Oblique con.sh."
        End Select
        Try
            If div = 2 Then
                If Involucr(kLato, jmemb).R0 > 75 Then
                    Testo = " Cono con angolo" & Str(Involucr(kLato, jmemb).R0) & "> 75°|Vuoi procedere ugualmente? ||"
                    Testo = Testo & "Nota: EN-13445 Clause 7 non è applicabile"
                    If Not ContinuoAuto Then
                        If Not MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Tubi scambiatori", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Exit Function
                    Else
                        PrintlstRes(Testo)
                    End If
                End If
            Else
                If Involucr(kLato, jmemb).R0 > 30 Then
                    Testo = " Cono con angolo" & Str(Involucr(kLato, jmemb).R0) & "> 30°|Vuoi procedere ugualmente? ||"
                    Testo = Testo & "Nota: qualora la membratura sia priva di ginocchi|"
                    Testo = Testo & "è necessaria un'analisi speciale secondo 1-5(g)"
                    If Not ContinuoAuto Then
                        If Not MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Tubi scambiatori", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Exit Function
                    Else
                        PrintlstRes(Testo)
                    End If
                End If
            End If
            If Involucr(kLato, jmemb).di = 0 Or P0 = 0 Then Call Erro(16) : Exit Function
            If Involucr(kLato, jmemb).OS = 0 Then Aspp = Involucr(kLato, jmemb).cs * CondizioniCorrose Else Aspp = Involucr(kLato, jmemb).OS
InizioC1:
            swn = 0
15220:      SWR = 0
            TEMA = Config(kLato).DC Mod 3
            tts = 0
            If TEMA > 0 Then
                tts = MinPlateThk(Involucr(kLato, jmemb).di)
            End If
            If VerificandoPI Then
                s = Involucr(kLato, jmemb).Shydr
            Else
                s = Involucr(kLato, jmemb).St
            End If
            If s = 0 Then
                Testo = "   Non è stata specificata la tensione ammissibile.|"
                Testo = Testo & "Pregasi provvedere. "
                If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Coni", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then Exit Function
                If Not DatiProgCyl(kLato, jmemb) Then Exit Function
                GoTo InizioC1
            End If
40:         ang = Involucr(kLato, jmemb).R0 * pi / 180
            If ang = 0 Then
                MessageBox.Show("E'stato specificato per un cono un angolo al vertice nullo.", "AsmeVip - " & Trim(Involucr(kLato, jInvolucr).Mark))
                ConShells = False
                Exit Function
            End If
            R = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
            Rsav = R
            '     CALL ConThk(t0, R, ang, 1!, Involucr(kLato,jmemb).ST, uu$, SWR)non serve perch‚
            '     Trs = t0: trsy = Trs / INC                 bisogna conoscere la posizione
            '     quindi rimandato a Branches
            E = Involucr(kLato, jmemb).ES
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11
                    Call ConThk(t0c, R, ang, s, E, SWR)
                    If Involucr(kLato, jmemb).Tipo = 3 And InStr(uu, "G") Then uu = " UG-36(g)"
                    t0s = t0c
                    Raggio = Involucr(kLato, jmemb).H0
                    If Raggio > 0 Then
                        alc = Involucr(kLato, jmemb).di / 2 / System.Math.Cos(ang) + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
                        If VerificandoPI Then
                            s = Involucr(kLato, jmemb).Shydr
                        Else
                            s = Involucr(kLato, jmemb).St
                        End If
                        E = Involucr(kLato, jmemb).ES
                        Addition1(kLato, jmemb).akt(1 - 1) = alc / (Raggio + Aspp)
                        Call Toro6(s, E, Addition1(kLato, jmemb).akt(1 - 1), Addition1(kLato, jmemb).akm(1 - 1), alc, t0th, t0hy)
                        Addition1(kLato, jmemb).t0th(1 - 1) = t0th
                        If t0s < t0th Then t0s = t0th
                    End If
                    Raggio = Involucr(kLato, jmemb).L0
                    If Raggio > 0 Then
                        alc = Involucr(kLato, jmemb).dns / 2 + Aspp + Involucr(kLato, jmemb).L0 * (1 - System.Math.Cos(ang))
                        If VerificandoPI Then
                            s = Involucr(kLato, jmemb).Shydr
                        Else
                            s = Involucr(kLato, jmemb).St
                        End If
                        E = Involucr(kLato, jmemb).ES
                        Addition1(kLato, jmemb).akt(2 - 1) = alc / (Raggio + Aspp)
                        Call Toro6(s, E, Addition1(kLato, jmemb).akt(2 - 1), Addition1(kLato, jmemb).akm(2 - 1), alc, t0th, t0hy)
                        Addition1(kLato, jmemb).t0th(2 - 1) = t0th
                        If t0s < t0th Then t0s = t0th
                    End If
                Case 3, 4, 5
                    Call Cono(Involucr(kLato, jmemb), Config(kLato), P0, td, T0)
                    t0s = T0
                    t0c = t0s
                Case 6, 7, 8
                    Call EUConThk(t0s, R, ang, s, E, SWR)
                    t0c = t0s '060706
            End Select
            tms = t0s + Aspp
1550:       If VerificandoPI Then
                Stringa(1) = " Required Thickness in Hydraulic Test " & UnitLength & " to =" & GlobalRoutines.myStr(tms * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Else
                Stringa(1) = " Minimum Code Design Shell Thickness  " & UnitLength & " to =" & GlobalRoutines.myStr(tms * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            End If
            TPR = -Int(-tms)
            If TEMA > 0 Then
                Stringa(2) = " Minimum TEMA Nominal Shell Thickness " & UnitLength & " to'=" & GlobalRoutines.myStr(tts * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
                If tts > TPR Then TPR = -Int(-tts)
            Else
                Stringa(2) = ""
            End If
15590:      Stringa(3) = " Adopted Nominal Shell Thickness     " & UnitLength
            Risult(3) = GlobalRoutines.myStr(Involucr(kLato, jmemb).Spess * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Risult(1) = "" : Risult(2) = ""
            If Involucr(kLato, jmemb).Spess = 0 Then Risult(3) = GlobalRoutines.myStr(TPR * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            If Not lContinuoAuto Then
                If Not Monitor.Motore.InputDati(3, RTrim(Involucr(kLato, jmemb).Mark) & ", adopted thickness", Stringa, Risult, "", Arch, dAiu) Then Exit Function
            Else
            End If
            If Involucr(kLato, jmemb).Spess <> GlobalRoutines.ValVir(Risult(3)) / kLength Then AzzeraLocalThk()
            Involucr(kLato, jmemb).Spess = GlobalRoutines.ValVir(Risult(3)) / kLength ' -INT(-VAL(Risult$(3)))
            If Involucr(kLato, jmemb).Spess < tts Or Involucr(kLato, jmemb).Spess < tms Then
                Beep()
                lContinuoAuto = False
                GoTo 15590
            End If
            TNSY = Involucr(kLato, jmemb).Spess / inc
15760:      tcs = Involucr(kLato, jmemb).Spess - Aspp
            TCSY = tcs / inc
            '-----------------------------------------------
            If Involucr(kLato, jmemb).jmemb1 > 0 Then
                AdditCono(kLato, jmemb).Spess(0) = Involucr(kLato, Involucr(kLato, jmemb).jmemb1).Spess
            ElseIf Involucr(kLato, jmemb).jmemb1 = 0 Then
                If AddDistinta = 0 Then
                    If jmemb > 1 Then
                        If Involucr(kLato, jmemb - 1).Tipo = 0 Then
                            Involucr(kLato, jmemb).jmemb1 = jmemb - 1
                            AdditCono(kLato, jmemb).Spess(0) = Involucr(kLato, Involucr(kLato, jmemb).jmemb1).Spess
                        End If
                    End If
                Else
                    Involucr(kLato, jmemb).jmemb1 = Config(kLato).Ninvolucri + 1
                End If
            End If
            If Involucr(kLato, jmemb).jmemb2 > 0 Then
                AdditCono(kLato, jmemb).Spess(1) = Involucr(kLato, Involucr(kLato, jmemb).jmemb2).Spess
            ElseIf Involucr(kLato, jmemb).jmemb2 = 0 Then
                If AddDistinta = 0 Then
                    If jmemb < Config(kLato).Ninvolucri Then
                        If Involucr(kLato, jmemb + 1).Tipo = 0 Then
                            Involucr(kLato, jmemb).jmemb1 = jmemb + 1
                            AdditCono(kLato, jmemb).Spess(1) = Involucr(kLato, Involucr(kLato, jmemb).jmemb2).Spess
                        End If
                    End If
                Else
                    Involucr(kLato, jmemb).jmemb2 = Config(kLato).Ninvolucri + 2
                End If
            End If
            For i = 1 To 2
                If (i = 1 And Involucr(kLato, jmemb).jmemb1 = -1) Or (i = 2 And Involucr(kLato, jmemb).jmemb2 = -1) Then GoTo cont1
                If AdditCono(kLato, jmemb).matind(i - 1) <= 0 Then
                    AggMatCil(i, jmemb)
                    If i = 1 Then jRec = Involucr(kLato, Involucr(kLato, jmemb).jmemb1).indice(1 - 1) Else jRec = Involucr(kLato, Involucr(kLato, jmemb).jmemb2).indice(1 - 1)
                    'Matdim(indice).RecupMat clsInizio.Archdir
                End If
                If AdditCono(kLato, jmemb).eff(i - 1) = 0 Then AdditCono(kLato, jmemb).eff(i - 1) = Involucr(kLato, jmemb).ES
cont1:      Next i
            For iyy = 1 To 2
                If Not ((iyy = 1 And Involucr(kLato, jmemb).jmemb1 = -1) Or (iyy = 2 And Involucr(kLato, jmemb).jmemb2 = -1)) Then
                    If VerificandoPI Then
                        If AdditCono(kLato, jmemb).Shydr(iyy - 1) = 0 Then ConAmm(jmemb, iyy)
                        Sloc(iyy) = AdditCono(kLato, jmemb).Shydr(iyy - 1)
                    Else
                        If AdditCono(kLato, jmemb).St(iyy - 1) = 0 Or AdditCono(kLato, jmemb).S0(iyy - 1) = 0 Then ConAmm(jmemb, iyy)
                        Sloc(iyy) = AdditCono(kLato, jmemb).St(iyy - 1)
                    End If
                End If
            Next
            If div = 0 Then
Rifai:          tc = Involucr(kLato, jmemb).Spess - Aspp
                For i = 1 To 2 ' lato grande | lato piccolo
                    If (i = 1 And Involucr(kLato, jmemb).jmemb1 = -1) Or (i = 2 And Involucr(kLato, jmemb).jmemb2 = -1) Then GoTo Cont2
                    Ak = 1 : If AdditCono(kLato, jmemb).Rinf(i - 1) > 0 Then Ak = AdditCono(kLato, jmemb).k(i - 1)
                    If Ak < 1 Then Ak = 1
15790:              ts = AdditCono(kLato, jmemb).Spess(i - 1) - Aspp
                    If i = 1 Then R = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jmemb).dns / 2 + Aspp + Involucr(kLato, jmemb).L0 * (1 - System.Math.Cos(ang))
15800:              If Not ARinfCon(i, jmemb, PSE, delta, AeL, ArL, Ql, t, ts, tr, tc, s, Sloc(i), AdditCono(kLato, jmemb).E(i - 1), AdditCono(kLato, jmemb).eff(i - 1), ang, R, Ak) Then
                        DatiDoub(kLato, jmemb)
                        GoTo Rifai
                    End If
                    SpminCono(i) = tr
                    SpminCili(i) = t
                    AdditCono(kLato, jmemb).PSE(i - 1) = PSE
                    AdditCono(kLato, jmemb).delta(i - 1) = delta
                    AdditCono(kLato, jmemb).AeL(i - 1) = AeL
                    AdditCono(kLato, jmemb).ArL(i - 1) = ArL
                    '           AdditCono(jmemb).Ql(i) = Ql
100:                If i = 1 Then Raggio = Involucr(kLato, jmemb).H0 Else Raggio = Involucr(kLato, jmemb).L0
                    If delta * pi / 180 < ang Then
                        AdditCono(kLato, jmemb).Necess(i - 1) = -ArL + AeL + AdditCono(kLato, jmemb).Rinf(i - 1)
                        If Raggio > 0 And AdditCono(kLato, jmemb).Necess(i - 1) > 0 Then Call Nonec(i) 'raggio non necessario
                        If Raggio > 0 And AdditCono(kLato, jmemb).Necess(i - 1) < 0 Then Call Neces(i) 'raggio     necessario
                        If Raggio = 0 And AdditCono(kLato, jmemb).Necess(i - 1) < 0 Then
                            Testo = "E' necessario aggiungere un'area di" & vbCrLf
                            Testo = Testo & "rinforzo cono-cilindro (area attuale" & GlobalRoutines.myStr(AdditCono(kLato, jmemb).Rinf(i - 1) * kLength ^ 2, 3 + IncrVirgola, 4 - IncrVirgola, 0) & ")" & vbCrLf
                            Testo = Testo & "sul diametro"
                            If i = 1 Then Testo = Testo & " maggiore " Else Testo = Testo & " minore "
                            '       Stringa(3) = Stringa(3) + " di area"
                            Testo = Testo & "non minore di " & GlobalRoutines.myStr(-AdditCono(kLato, jmemb).Necess(i - 1) * kLength ^ 2, 3 + IncrVirgola, 4 - IncrVirgola, 0) & " " & UnitArea
                            Stringa(1) = "Area addizionale di rinforzo"
                            Risult(1) = GlobalRoutines.myStr(-AdditCono(kLato, jmemb).Necess(i - 1) * 1.001 * kLength ^ 2, 3 + IncrVirgola, 4 - IncrVirgola, 0)
                            If Not Monitor.Motore.InputDati(1, Trim(Involucr(kLato, jmemb).Mark) & ", rinforzo giunzioni", Stringa, Risult, RadiceHelp, Arch, dAiu, Testo, strIDH:=Monitor.HelpTopic(2106)) Then Exit Function
                            AdditCono(kLato, jmemb).Rinf(i - 1) = AdditCono(kLato, jmemb).Rinf(i - 1) + GlobalRoutines.ValVir(Risult(1)) / kLength ^ 2
                            GoTo Rifai
                        End If 'cosa vuoi fare?
                    Else
                        If Raggio > 0 Then Call Nonec(i) 'raggio non necessario
                    End If
Cont2:          Next i
            ElseIf div = 2 Then
                Do While Not EURinfCon(Aspp, ang, s, 0)
                    DatiDoub(kLato, jmemb)
                Loop
            End If
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then
                '--------------------------MAWP------------------
                E = Involucr(kLato, jmemb).ES
                Dim icount As Short
                For iMAWP = 1 To 4
                    icount = 0
                    Call T0andS(iMAWP, jmemb, T0, s)
                    If iMAWP < 3 Then R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS + Involucr(kLato, jmemb).cs * CondizioniCorrose - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
                    Call ConPres(Involucr(kLato, jmemb).MAWP(iMAWP - 1), T0, R, ang, s, E, SWR)
                    AdditCono(kLato, jmemb).Contr(iMAWP - 1) = 1
                    Raggio = Involucr(kLato, jmemb).H0
                    If Raggio > 0 And div < 2 Then
110:                    alc = Involucr(kLato, jmemb).di / 2 / System.Math.Cos(ang) + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang)) + Involucr(kLato, jmemb).OS
                        Raggio = Raggio + Involucr(kLato, jmemb).OS
                        If iMAWP > 2 Then alc = alc + Involucr(kLato, jmemb).cs * CondizioniCorrose : Raggio = Raggio + Involucr(kLato, jmemb).cs * CondizioniCorrose
120:                    Call Toro6INV(Press, s, E, alc / Raggio, akm, alc, T0, t0hy)
121:                    If Press < Involucr(kLato, jmemb).MAWP(iMAWP - 1) Then
                            Involucr(kLato, jmemb).MAWP(iMAWP - 1) = Press
                            AdditCono(kLato, jmemb).Contr(iMAWP - 1) = 2
                        End If
                    End If
                    If div < 2 Then
122:                    For k = 1 To 2
                            If (k = 1 And Involucr(kLato, jmemb).jmemb1 = -1) Or (k = 2 And Involucr(kLato, jmemb).jmemb2 = -1) Then GoTo Skippa
                            If (k = 1 And Involucr(kLato, jmemb).H0 > 0) Or (k = 2 And Involucr(kLato, jmemb).L0 > 0) Then GoTo Skippa
                            If iMAWP = 1 Or iMAWP = 3 Then
130:                            Scyl = AdditCono(kLato, jmemb).S0(k - 1)
                            Else
                                Scyl = AdditCono(kLato, jmemb).St(k - 1)
                            End If
                            If iMAWP < 3 Then
                                tc = Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).OS
                                ts = AdditCono(kLato, jmemb).Spess(k - 1) - Involucr(kLato, jmemb).OS
                                If k = 1 Then R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jmemb).dns / 2 + Involucr(kLato, jmemb).OS + Involucr(kLato, jmemb).L0 * (1 - System.Math.Cos(ang))
                            Else
                                tc = Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).cs * CondizioniCorrose
                                ts = AdditCono(kLato, jmemb).Spess(k - 1) - Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).cs * CondizioniCorrose
140:                            If k = 1 Then R = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jmemb).dns / 2 + Aspp + Involucr(kLato, jmemb).L0 * (1 - System.Math.Cos(ang))
                            End If
                            P0sav = P0
                            Do
                                eff = AdditCono(kLato, jmemb).eff(k - 1)
                                Ak = 1 : If AdditCono(kLato, jmemb).Rinf(k - 1) > 0 Then Ak = AdditCono(kLato, jmemb).k(k - 1)
                                If Ak < 1 Then Ak = 1
Rifp:                           If Not ARinfCon(k, jmemb, PSE, delta, AeL, ArL, Ql, t, ts, tr, tc, s, Scyl, AdditCono(kLato, jmemb).E(k - 1), eff, ang, R, Ak) Then Exit Function
                                'If AeL < 0 Then P0 = P0 * 0.9 : GoTo Rifp
150:                            AeL = AeL + AdditCono(kLato, jmemb).Rinf(k - 1)
                                If ArL = 0 Then P0 = P0 * 1000 : Exit Do
                                If System.Math.Abs(AeL - ArL) / ArL < 0.01 Then Exit Do
                                icount += 1
                                If icount > 20 Then Exit Do
                                If ArL <> 1 Then P0 = P0 * System.Math.Sqrt(System.Math.Sqrt(AeL / ArL))
                            Loop
160:                        If P0 < Involucr(kLato, jmemb).MAWP(iMAWP - 1) Then
                                Involucr(kLato, jmemb).MAWP(i - 1) = P0
                                AdditCono(kLato, jmemb).Contr(i - 1) = 2 + k
                            End If
                            P0 = P0sav
Skippa:                 Next k
                    Else
                        EUJunctPres(iMAWP, ang, Aspp)
                        pHImin = Pr10p2p3p3(valido)
                        R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
                        ConPres(pHImax1, Involucr(kLato, jmemb).Spess, R, ang, Involucr(kLato, jmemb).Shydr, E, SWR)
                        pHImax = clsTrigon.Infinito
                        EUJunctPres(-1, ang, 0)
                        If pHImax1 < pHImax Then pHImax = pHImax1
                        If Not lContinuoAuto Then
                            EUInformaPI(valido)
                        End If
                    End If
                Next iMAWP
                iMAWP = 0
            End If
            '------------------------------------------------
            SpxBExt = 0
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(kLato).Vacuum And Not VerificandoPI Then
                If ang > 60 Then
                    MessageBox.Show("ang > 60° in ConShells: che fare ?")
                ElseIf div = 2 Then
                    MessageBox.Show("Calcolo coni a pressione esterna secondo EuroNorm non programmato.")
                Else
                    TE = (Involucr(kLato, jmemb).Spess - Aspp) * System.Math.Cos(ang)
                    Call ConBuckPar(ang, DLDL, Ds, alc, aLe)
                    jRec = Involucr(kLato, jmemb).indice(1 - 1)
                    Asnell = Matdim(jRec).Avalor(DLDL / TE, aLe / DLDL)
                    Indmat = Matdim(jRec).Indmat
                    psig = System.Math.Abs(Matdim(jRec).BValor(Asnell, Textdes, Indmat, CodiceStress, Chart, 0))
                    psig1 = 4 / 3 * psig * TE / DLDL
                    If Not lContinuoAuto Then
                        If AlertPext(psig1) = DialogResult.Cancel Then GoTo 1550
                    End If
                    trPressExt(0, 0, 0, SpxBExt)
RifApp18:           If (Involucr(kLato, jmemb).H0 = 0 Or Involucr(kLato, jmemb).L0 = 0) And pext > 0 Then
                        tc = Involucr(kLato, jmemb).Spess - Aspp
                        For i = 1 To 2
                            If (i = 1 And Involucr(kLato, jmemb).jmemb1 = -1) Or (i = 2 And Involucr(kLato, jmemb).jmemb2 = -1) Then GoTo cont3
                            If i = 1 Then R = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jmemb).dns / 2 + Aspp + Involucr(kLato, jmemb).L0 * (1 - System.Math.Cos(ang))
                            ts = AdditCono(kLato, jmemb).Spess(i - 1) - Aspp
                            If ts > 0 Then
173:                            Call App18(jmemb, i, PSE, deltac, ArLExt(i), QlExt(i), AeLExt(i), t, ts, tr, tc, R, ATL(i), BBB(i), AAA(i), Ips(i), iP(i), AdditCono(kLato, jmemb).Stiff_Renamed(i))
                            End If
                            SpminCono(i + 2) = tr
                            SpminCili(i + 2) = t
                            If i = 1 Then deltac1 = deltac : PSE1 = PSE
cont3:                  Next
                        NonVer = False
                        Testo = ""
175:                    For i = 1 To 2
                            If (i = 1 And Involucr(kLato, jmemb).jmemb1 = -1) Or (i = 2 And Involucr(kLato, jmemb).jmemb2 = -1) Then GoTo Cont4
                            Testo = Testo & "La linea di supporto cono-cilindro|"
                            If iP(i) < Ips(i) Then
                                Testo = Testo & "NON "
                                NonVer = True
                            End If
                            Testo = Testo & " è verificata lato"
                            If i = 1 Then Testo = Testo & " grande|" Else Testo = Testo & " piccolo|"
                            Testo = Testo & "(Ip=" & Format(iP(i) * kLength ^ 4, "0.000E+00") & " " & UnitLength & _
                                         "4; Ips=" & Format(Ips(i) * kLength ^ 4, "0.000E+00") & " " & UnitLength & "4)|"
Cont4:                  Next
                        If NonVer Or AdditCono(kLato, jmemb).Stiff_Renamed(1).Spess > 0 Or AdditCono(kLato, jmemb).Stiff_Renamed(2).Spess > 0 Then
                            Testo = Testo & "Vuoi introdurre o variare i rinforzi?"
                            vbMsg = MessageBoxButtons.YesNo
                        Else
                            vbMsg = MessageBoxButtons.OK
                        End If
                        If Not lContinuoAuto Then
                            If Len(Testo) > 0 Then ResMsg = MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", vbMsg)
                        End If
                        If (NonVer Or AdditCono(kLato, jmemb).Stiff_Renamed(1).Spess > 0 Or AdditCono(kLato, jmemb).Stiff_Renamed(2).Spess > 0) And ResMsg = DialogResult.Yes Then
                            lContinuoAuto = False
                            Call EditRinf(AdditCono(kLato, jmemb))
                            GoTo RifApp18
                        End If
                    End If
                End If
            End If
            '---------------STAMPA---------------------------
            ifl = FreeFile()
            FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME13.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 0 To 29 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11
                    ConShellPr(jmemb, s)
                    If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then Call StamMAWPcon(jmemb)
                Case 3, 4, 5
                    FileFor.Str_Renamed = RTrim(clsInizio.DiscoRam) & "ROTFLFOR.OUT"
                    Testa1(jmemb)
                    Call CONPRI(Involucr(kLato, jmemb), Config(kLato), FileFor)
                    Stamparo("", FileFor.Str_Renamed) 'clsInizio.DiscoRam + "ROTFLFOR.OUT"
                Case 6, 7, 8
                    Call EUConShellPr(ang, Aspp)
            End Select
            If Not VerificandoPI Then
                ConVacuumPr(jmemb, s)
                StrainTreat()
            End If
            swn = Involucr(kLato, jmemb).Tipo 'coni
            For nn = Involucr(kLato, jmemb).inizio To Involucr(kLato, jmemb).Fine
                SWR = Nozzles(kLato, nn).SWR : If SWR > 9 Then SWR = SWR - 10
                If iBocc = 0 Or nn = iBocc Then
                    'trs spessore di calcolo per bocchello calcolato in branches
                    'tcs spessore netto
                    Call PrepRapp(Template, "Apertura su cono", Nozzles(kLato, nn).Mark, FileSt, mioApert.lstRapp, 3)
                    Select Case Config(kLato).DC
                        Case 0, 1, 2, 9, 10, 11
                            '  If Not BranchesCal(0.0!, 0.0!, s, Involucr(kLato, jmemb).di, Involucr(kLato, jmemb).Spess, 0.0!, tcs, aKZ, Nozzles(kLato, nn).EffN, SWR, Int(nn), jmemb) Then Exit Function
                            If Not BranchesCal(0.0!, 0.0!, s, Involucr(kLato, jmemb).di, TRV, t0c, tcs, aKZ, Nozzles(kLato, nn).EffN, SWR, Int(nn), jmemb) Then Exit Function '060706
                        Case 3, 4, 5
                            MessageBox.Show("Bocchelli su coni per ASME2: lavori in corso")
                        Case 6 : MessageBox.Show("EuroNorm in ConShells3")
                    End Select
                End If
            Next nn
            ConShells = True
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
            ConShells = False
        End Try
    End Function
    Private Sub Neces(ByVal i As Short)
        Dim Testo As String = " Per vostra informazione, il raggio|di raccordo sul diametro"
        If i = 1 Then Testo = Testo & " maggiore" Else Testo = Testo & " minore"
        Testo = Testo & "|è effettivamente necessario."
        MessageBox.Show(clsInizio.ConvertiCr(Testo))
    End Sub
    Private Sub Nonec(ByVal i As Short)
        Dim Testo As String = " Per vostra informazione, il raggio|di raccordo sul diametro"
        If i = 1 Then Testo = Testo & " maggiore" Else Testo = Testo & " minore"
        Testo = Testo & "|non sarebbe stato necessario."
        MessageBox.Show(clsInizio.ConvertiCr(Testo))
    End Sub
    Public Sub ConAmm(ByRef jmemb As Short, ByRef iyy As Short)
        Dim AllFOpe, AllFRoo, AllFHyd As Single
        Dim indice, jSav As Short
        If AdditCono(kLato, jmemb).matind(iyy - 1) > -1 Then
            jSav = jInvolucr
            If iyy = 1 Then
                jInvolucr = Involucr(kLato, jmemb).jmemb1
            Else
                jInvolucr = Involucr(kLato, jmemb).jmemb2
            End If
            indice = Involucr(kLato, jInvolucr).indice(1 - 1)
            If VerificandoPI Then
                AllFHyd = Matdim(indice).Yield() * FractSyPI '/ mpa
            Else
                Matdim(indice).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
                'AllFRoo = AllFRoo '/ mpa
                'AllFOpe = AllFOpe '/ mpa
            End If
            jInvolucr = jSav
        End If 'n
        If VerificandoPI Then
            AdditCono(kLato, jmemb).Shydr(iyy - 1) = AllFHyd
        Else
            AdditCono(kLato, jmemb).St(iyy - 1) = AllFOpe
            AdditCono(kLato, jmemb).S0(iyy - 1) = AllFRoo
            If div = 2 Then AdditCono(kLato, jmemb).Shydr(iyy - 1) = Involucr(kLato, jInvolucr).Shydr
        End If
    End Sub
    Public Sub AggMatCil(ByRef i As Short, ByRef jmemb As Short)
        Dim indice As Short
        Dim NomeCil As String
        If i = 1 Then
            indice = Involucr(kLato, Involucr(kLato, jmemb).jmemb1).indice(1 - 1)
            NomeCil = Involucr(kLato, Involucr(kLato, jmemb).jmemb1).Mark
        Else
            indice = Involucr(kLato, Involucr(kLato, jmemb).jmemb2).indice(1 - 1)
            NomeCil = Involucr(kLato, Involucr(kLato, jmemb).jmemb2).Mark
        End If
        AdditCono(kLato, jmemb).matind(i - 1) = Matdim(indice).Indmat
        If Not Apparecchio Is Nothing Then
            CType(Apparecchio.Elementi(NomeCil).Genmem, Grafica.clsGenMem).Indmat1 = Matdim(indice).Indmat
        End If
        If i = 1 Then
            AdditCono(kLato, jmemb).MATE1 = Matdim(indice).MatStr
        ElseIf i = 2 Then
            AdditCono(kLato, jmemb).MATE2 = Matdim(indice).MatStr
        End If
        ConAmm(jmemb, i)
    End Sub
    Public Sub AggForm()
        Dim i, iyy As Short
        With frmConDoub.DefInstance
            For i = 1 To 2
                If AdditCono(kLato, jInvolucr).E(i - 1) = 0 Then AdditCono(kLato, jInvolucr).E(i - 1) = Involucr(kLato, jInvolucr).ES
                If i = 1 Then
                    .TextCil((i - 1) * 20).Text = AdditCono(kLato, jInvolucr).MATE1
                ElseIf i = 2 Then
                    .TextCil((i - 1) * 20).Text = AdditCono(kLato, jInvolucr).MATE2
                End If
                .TextCil((i - 1) * 20 + 1).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).Spess(i - 1) * kLength, 5, 3, False)
                .TextCil((i - 1) * 20 + 3).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).eff(i - 1), 5, 3, False)
                .TextCil((i - 1) * 20 + 4).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).E(i - 1), 5, 3, False)
                If VerificandoPI Then
                    .TextCil((i - 1) * 20 + 5).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).Shydr(i - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                Else
                    .TextCil((i - 1) * 20 + 5).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).S0(i - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    .TextCil((i - 1) * 20 + 6).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).St(i - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                End If
                .TextCil((i - 1) * 20 + 7).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).f(i - 1, 0) * kForce, 6, 3, False)
                .TextCil((i - 1) * 20 + 8).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).f(i - 1, 1) * kForce, 6, 3, False)
                If AdditCono(kLato, jInvolucr).k(i - 1) <= 0 Then AdditCono(kLato, jInvolucr).k(i - 1) = 1
                .TextCil((i - 1) * 20 + 9).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).k(i - 1), 6, 3, False)
                .TextCil((i - 1) * 20 + 10).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).Rinf(i - 1) * kLength * kLength, 8, 1, False)
            Next
            If Involucr(kLato, jInvolucr).jmemb1 > -1 Then ._TextCil_2.Text = GlobalRoutines.myStr(Involucr(kLato, Involucr(kLato, jInvolucr).jmemb1).L0 * kLength, 5, 1, False)
            If Involucr(kLato, jInvolucr).jmemb2 > -1 Then ._TextCil_22.Text = GlobalRoutines.myStr(Involucr(kLato, Involucr(kLato, jInvolucr).jmemb2).L0 * kLength, 5, 1, False)
            If Involucr(kLato, jInvolucr).jmemb1 > 0 Then
                For i = 1 To ._cmbCil_0.Items.Count - 1
                    If GlobalRoutines.ValVir(._List1_0.Items(i)) = Involucr(kLato, jInvolucr).jmemb1 Then
                        ._cmbCil_0.SelectedIndex = i
                        Exit For
                    End If
                Next
            Else
                ._cmbCil_0.SelectedIndex = 0 ' = Involucr(kLato,Involucr(kLato,jInvolucr).jmemb1).Mark
            End If
            If Involucr(kLato, jInvolucr).jmemb2 > 0 Then
                For i = 1 To ._cmbCil_20.Items.Count - 1
                    If GlobalRoutines.ValVir(._List1_20.Items(i)) = Involucr(kLato, jInvolucr).jmemb2 Then
                        ._cmbCil_20.SelectedIndex = i
                        Exit For
                    End If
                Next
            Else
                ._cmbCil_20.SelectedIndex = 0 ' = Involucr(kLato,Involucr(kLato,jInvolucr).jmemb1).Mark
            End If
            '  ._cmbCil_0.Visible = (Involucr(kLato,jInvolucr).jmemb1 = -1)
            '  ._cmbCil_20.Visible = (Involucr(kLato,jInvolucr).jmemb2 = -1)
            Try
                For iyy = 0 To 10
                    If Not .TextCil(iyy) Is Nothing Then .TextCil(iyy).Visible = Not (Involucr(kLato, jInvolucr).jmemb1 = -1)
                    If Not .cmdCil(iyy) Is Nothing Then .cmdCil(iyy).Visible = Not (Involucr(kLato, jInvolucr).jmemb1 = -1)
                Next
                For iyy = 20 To 30
                    If Not .TextCil(iyy) Is Nothing Then .TextCil(iyy).Visible = Not (Involucr(kLato, jInvolucr).jmemb2 = -1)
                    If Not .cmdCil(iyy) Is Nothing Then .cmdCil(iyy).Visible = Not (Involucr(kLato, jInvolucr).jmemb2 = -1)
                Next
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
        If AdditCono(kLato, jInvolucr).Stiff1.Spess > 0 Or AdditCono(kLato, jInvolucr).Stiff2.Spess > 0 Then
            Call EditRinf(AdditCono(kLato, jInvolucr))
        End If
    End Sub
    Sub App18(ByRef jmemb As Short, ByRef i As Short, ByRef PSE As Single, ByRef deltac As Single, ByRef ArL As Single, _
              ByRef Ql As Single, ByRef AeL As Single, ByRef t As Single, ByRef ts As Single, _
              ByRef tr As Single, ByRef tc As Single, ByRef RcollCon As Single, ByRef ATL As Single, _
              ByRef b As Single, ByRef a As Single, ByRef Ips As Single, ByRef iP As Single, _
              ByRef Stiff As Stiff)
        Dim Scyl, ang, Ecyl As Single
        Dim Ql0, Fcirc As Single
        Dim k As Short
        Dim l, ll, LC As Single
        Dim Ds, DLDL, aLe As Single
        Dim Fl As Single
        Dim jRec, matind As Short
        Dim Aval As Single
        Dim Chart As String = ""
        Dim Aval1, Areas, Areastiff As Single
        Dim TS1, Areac, Ipsh As Single
        Dim Ipco, Ipst As Single
        Dim m As Single
        Dim Testo As String = ""
        Try
            'Pext = 105
            If Involucr(kLato, jmemb).H0 = 0 And i = 1 Or Involucr(kLato, jmemb).L0 = 0 And i = 2 Then
                ang = Involucr(kLato, jmemb).R0
                Scyl = AdditCono(kLato, jmemb).St(i - 1)
                Ecyl = AdditCono(kLato, jmemb).E(i - 1)
                If Scyl = 0 Then
                    Testo = "L'ammissibile del cilindro collegato "
                    If i = 1 Then Testo = Testo & "large end" Else Testo = Testo & "small end"
                    Testo = Testo & " non è definito."
                    MessageBox.Show(Testo, "AsmeVip - App. 1.8", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
700:            If i = 1 Then
                    PSE = pext / (Scyl * Ecyl) 'Pext
                    Call Leggidelta(3, deltac, PSE)
                Else
                    deltac = 0
                End If
                If ang > deltac Then
                    ang = ang * pi / 180
710:                Call ConThkExt(tr, RcollCon, ang, i) : If tr = 0 Then Exit Sub
712:                Call ConThkExt(t, RcollCon, 0.0!, i) : If t = 0 Then Exit Sub
                    Ql0 = -pext * RcollCon / 2 ' / inc
                    Ql = 0 'Pext
                    For k = 1 To 2
                        Fcirc = AdditCono(kLato, jmemb).f(i - 1, k - 1) / pi / 2 / RcollCon ' * inc
                        If Fcirc > -Ql0 Then
                            MessageBox.Show("Problema U-2" & Str(Fcirc) & Str(Ql0))
                        End If
                        If Ql0 + Fcirc < Ql Then Ql = Ql0 + Fcirc Else Ql = Ql0
                    Next k
                    Ql = -Ql
                    If i = 1 Then
                        ArL = Ql * RcollCon * System.Math.Tan(ang) / Scyl / Ecyl * (1 - deltac * pi / 180 / ang / 4 * (pext * RcollCon - Ql) / Ql)   'Pext
                        AeL = 0.55 * System.Math.Sqrt(2 * RcollCon * ts) * (ts + tc / System.Math.Cos(ang))
                    Else
                        ArL = Ql * RcollCon * System.Math.Tan(ang) / Scyl / Ecyl ' * inc
                        AeL = 0.55 * System.Math.Sqrt(2 * RcollCon * ts) * ((ts - t) + (tc - tr) / System.Math.Cos(ang))
                    End If
                End If
                'qui parte 1.8(b) step 1
                If i = 1 Then ll = Involucr(kLato, Involucr(kLato, jmemb).jmemb1).L0 Else ll = Involucr(kLato, Involucr(kLato, jmemb).jmemb2).L0
750:            Call ConBuckPar(ang, DLDL, Ds, l, aLe)
                If Involucr(kLato, jmemb).Tipo = 2 Then
                    LC = System.Math.Sqrt(l * l + (DLDL - Ds) ^ 2 / 4)
                ElseIf Involucr(kLato, jmemb).Tipo = 3 Then
                    LC = l : ang = 0
                End If
                ATL = (ll * ts + LC * tc) / 2 + Stiff.Spess * System.Math.Abs(Stiff.Alt)
                If Involucr(kLato, jmemb).Tipo = 2 Then
                    If i = 1 Then
                        m = -DLDL * System.Math.Tan(ang) / 4 + ll / 2 + (DLDL * DLDL - Ds * Ds) / 6 / DLDL / System.Math.Tan(ang)
                        Fcirc = Math.Min(AdditCono(kLato, jmemb).f(i - 1, 1 - 1), AdditCono(kLato, jmemb).f(i - 1, 2 - 1)) / pi / 2 / RcollCon ' * inc
                        Fl = pext * m - Fcirc * Math.Tan(ang)
                        b = 0.75 * Fl * DLDL / ATL
                    Else
                        m = Ds * System.Math.Tan(ang) / 4 + ll / 2 + (DLDL * DLDL - Ds * Ds) / 12 / Ds / System.Math.Tan(ang)
                        Fcirc = Math.Min(AdditCono(kLato, jmemb).f(i - 1, 1 - 1), AdditCono(kLato, jmemb).f(i - 1, 2 - 1)) / pi / 2 / RcollCon ' * inc
                        Fl = pext * m - Fcirc * Math.Tan(ang)
                        b = 0.75 * Fl * Ds / ATL
                    End If
                Else
                    b = 0.75 * pext * RcollCon / ATL * (ll + LC) 'Pext
                End If
770:            jRec = Involucr(kLato, jmemb).indice(1 - 1)
                matind = Matdim(jRec).Indmat
                a = System.Math.Abs(Matdim(jRec).BValor(b, Textdes, matind, CodiceStress, Chart, 1))
                Ips = a * RcollCon ^ 2 * 4 / 10.9 * ATL
                Aval = 1.1 * System.Math.Sqrt(2 * (RcollCon + ts / 2) * ts)
                If Stiff.Spess = 0 Then
                    Areas = Aval / 2 * ts
                    Aval1 = Aval / 2
                    Areastiff = 0
                Else
790:                Areastiff = Stiff.Spess * System.Math.Abs(Stiff.Alt) + Stiff.SpessAla * Stiff.LungAla
                    Aval1 = Aval / 2 + Stiff.Dist
                    Areas = Aval1 * ts
                    If Areas - Stiff.Dist * ts > Areastiff Then
                        Areas = Areastiff + Stiff.Dist * ts
                        Aval1 = Areas / ts
                        Aval = Aval / 2 - Stiff.Dist + Aval1
                    End If
                End If
                If Aval1 > ll / 2 Then
                    Aval = Aval - (Aval1 - ll / 2)
                    Aval1 = ll / 2
                    Areas = Aval1 * ts
                End If
                Areac = (Aval - Aval1) * tc / System.Math.Cos(ang)
                If Areac < 0 Then Areac = 0
                Amom = Areas * ts / 2 + Areac * (tc / 2 / System.Math.Cos(ang) - (Aval - Aval1) / 2 * System.Math.Tan(ang))
                If Stiff.Alt > 0 Then TS1 = ts Else TS1 = 0
                Amom = Amom + (TS1 + Stiff.Alt / 2) * Stiff.Spess * System.Math.Abs(Stiff.Alt) + (TS1 + Stiff.Alt + Stiff.SpessAla / 2) * Stiff.SpessAla * Stiff.LungAla
                aneu = Amom / (Areas + Areac + Areastiff)
                Ipsh = Aval / 2 * ts * ts * ts / 12 + (aneu - ts / 2) ^ 2 * Areas
                If Areac = 0 Then
                    Ipco = 0
                Else
                    Ipco = (Aval - Aval1) ^ 3 / 12 * tc / System.Math.Cos(ang) * System.Math.Tan(ang) ^ 2 - _
                    (Aval - Aval1) ^ 2 / 8 * tc * tc / System.Math.Cos(ang) ^ 2 * System.Math.Tan(ang) + _
                    (Aval - Aval1) * tc * tc * tc / System.Math.Cos(ang) ^ 3 / 12
                    Ipco = Ipco + (aneu - (Aval - Aval1) / 2 * System.Math.Tan(ang) + tc / 2 / System.Math.Cos(ang)) ^ 2 * Areac
                End If
                Ipst = Stiff.Spess * System.Math.Abs(Stiff.Alt) ^ 3 / 12 + _
                       Stiff.SpessAla ^ 3 * Stiff.LungAla / 12 + _
                       Stiff.SpessAla * Stiff.LungAla * (Stiff.Alt / 2 + Stiff.SpessAla / 2) ^ 2 + _
                             (aneu - (TS1 + Stiff.Alt / 2)) ^ 2 * Areastiff
                iP = Ipsh + Ipco + Ipst
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Function ARinfCon(ByRef i As Short, ByRef jmemb As Short, ByRef PSE As Single, ByRef deltac As Single, _
                      ByRef AeL As Single, ByRef ArL As Single, ByRef Ql As Single, ByRef t As Single, _
                      ByRef ts As Single, ByRef tr As Single, ByRef tc As Single, ByRef Scon As Single, _
                      ByRef Scyl As Single, ByRef E As Single, ByRef Ecyl As Single, ByRef ang As Single, _
                      ByRef RcollCon As Single, ByRef Ak As Single) As Short
        Dim aKZ, Ql0 As Single
        Dim k As Short
        Dim Fcirc As Single
        Try
            If E = 0 Then E = 1
            If Ecyl = 0 Then Ecyl = 1
20:         PSE = P0 / (Scyl * Ecyl)
            Call Leggidelta(i, deltac, PSE)
            If deltac * pi / 180 < ang Then '------------------
                Call ConThk(tr, RcollCon, ang, Scon, E, 0)
60:             Call CylThk(P0, td, t, RcollCon, aKZ, Scyl, Ecyl, 0)
                If t = 0 Then Exit Function
                If i = 1 Then
62:                 AeL = (ts - t) * System.Math.Sqrt(RcollCon * ts) + (tc - tr) * System.Math.Sqrt(RcollCon * tc / System.Math.Cos(ang))
                Else
64:                 AeL = 0.78 * System.Math.Sqrt(RcollCon * ts) * ((ts - t) + (tc - tr) / System.Math.Cos(ang))
                End If
80:             Ql0 = P0 * RcollCon / 2 '/ inc
                Ql = Ql0
                For k = 1 To 2
                    Fcirc = AdditCono(kLato, jmemb).f(i - 1, k - 1) / pi / 2 / RcollCon '* inc
                    If -Fcirc > Ql0 Then
                        MessageBox.Show("Problema U-2" & Str(Fcirc) & Str(Ql0))
                    End If
                    If Ql0 + Fcirc > Ql Then Ql = Ql0 + Fcirc
                Next k
90:             ArL = Ak * Ql * RcollCon / Scyl / Ecyl * (1 - deltac * pi / 180 / ang) * System.Math.Tan(ang) '* inc
            Else 'delta>alfa
                ArL = 0
                AeL = 0
            End If
            ARinfCon = True
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function

    Function Belts(ByRef jmemb As Short, ByRef iBocc As Short) As Short
        Dim indice As Short
        Dim Aspp As Single
        Dim rcy, rc, R As Single
        Dim SWR, s As Single
        Dim Testo As String
        Dim E, T0 As Single
        Dim t0s, t0sy As Single
        Dim tms0, tms, tmsy As Single
        Dim TNS, Aj, tns0, TNSY As Single
        Dim Stringa(3) As String
        Dim Risult(3) As String
        Dim Arch(3) As Short
        Dim dAiu(3) As String
        Dim tpr0, aKZ, TPR As Single
        Dim ifl, i As Short
        Dim Rtf As String
        Dim StriSt(9) As String
        Dim lContinuoAuto As Boolean
        lContinuoAuto = ContinuoAuto
        Try
            Belts = False
            indice = Involucr(kLato, jmemb).indice(1 - 1)
            If Involucr(kLato, jmemb).di = 0 Or P0 = 0 Then Call Erro(16) : Exit Function
            Aspp = Involucr(kLato, jmemb).cs * CondizioniCorrose
            AggiustaHydr(kLato, jmemb, 0, P0, VerificandoPI)
InizioB:
220:        rc = Involucr(kLato, jmemb).di / 2 + Aspp
            rcy = rc / inc
            R = rc
            SWR = 0
290:        If VerificandoPI Then
                s = Involucr(kLato, jmemb).Shydr
            Else
                s = Involucr(kLato, jmemb).St
            End If
            If s = 0 Then
                Testo = "   Non è stata specificata la tensione ammissibile.|"
                Testo = Testo & "Pregasi provvedere. "
                If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip - Belts", MessageBoxButtons.OKCancel, MessageBoxIcon.None) = DialogResult.Cancel Then Exit Function
                If Not DatiProgCyl(kLato, jmemb) Then Exit Function
                GoTo InizioB
            End If
            E = Involucr(kLato, jmemb).ES
            Call CylThk(P0, td, T0, R, aKZ, s, E, SWR)
            If T0 = 0 Then Belts = False : Exit Function
            t0s = T0
            t0sy = t0s / inc
            tms = 2 * T0 + Aspp
            tms0 = 2 * T0
            tmsy = tms0 / inc
            Aj = (Involucr(kLato, jmemb).di - Involucr(kLato, jmemb).dns) / 2 + 2 * Aspp
295:        tns0 = 0.707 * Aj * System.Math.Sqrt(P0 / s) + Aspp
            TNS = tns0 + Aspp
            TNSY = tns0 / inc
            Stringa(1) = " Minimum Code Design Bar Thk (2*trj)  " & UnitLength & " trc=" & GlobalRoutines.myStr(tms * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Stringa(2) = "Minimum Code Design Bar Thk          " & UnitLength & " trc=" & GlobalRoutines.myStr(TNS * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Stringa(3) = " Adopted Nominal Bar   Thickness     " & UnitLength
590:        Risult(3) = GlobalRoutines.myStr(Involucr(kLato, jmemb).H0 * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Risult(1) = "" : Risult(2) = ""
            If Not lContinuoAuto Then
                If Not Monitor.Motore.InputDati(3, RTrim(Involucr(kLato, jmemb).Mark) & ", adopted thickness", Stringa, Risult, "", Arch, dAiu) Then Exit Function
            End If
            tpr0 = tms : If TNS > tpr0 Then tpr0 = TNS
            TPR = -Int(-tpr0)
            ' For i = 1 To 3: LungStr(i) = Len(Risult$(i)): Next
            ' If VisuInput(3, RTrim$(Involucr(kLato,jmemb).Mark) + ". Bars, adopted thickness", "", Stringa(), Risult$(), LungStr()) = -2 Then Exit Function
            Involucr(kLato, jmemb).H0 = GlobalRoutines.ValVir(Risult(3)) / kLength
            If Involucr(kLato, jmemb).H0 < TNS Or Involucr(kLato, jmemb).H0 < tms Then
                Beep()
                lContinuoAuto = False
                GoTo 590
            End If
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then
                '--------------------------MAWP------------------
                Call BelPres(jmemb)
                '------------------------------------------------
            End If
            Call Testa1(jmemb)
            USStr(0) = "Appendix 9" : STStr = "Belt type 1"
            Call TestaCylCon(Aspp, jmemb, s)
            ifl = FreeFile()
            Rtf = "\RTF"
            FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME23.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 9 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            With Monitor.Motore.Problem
                If Involucr(kLato, jmemb).OS = 0 Then
                    .Print(StriSt(1))  ' "Corroded Inside Radius of jacket     Rj  =";
                Else
                    .Print(StriSt(2))  '"Ins.Radius of jacket on Base Mat.    Rj  =";
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(3), rc, " [mm]", rcy, " [in]"))  '"######.## &   ######.## &"
                .Print(StriSt(4))  '"Corr. Jacket radial span              j  =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), Aj, " [mm]", Aj / inc, " [in]"))  '"######.## &   ######.## &"
                .Printa(StriSt(5))
                .Print(StriSt(6))  '"trc = 2 * trj                            =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), tms0, " [mm]", tmsy, " [in]"))  '"######.## &   ######.## &"
                .Print(StriSt(7))  '"trc = 0.707 j û(P/S)                     =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), tns0, " [mm]", TNSY, " [in]"))  '"######.## &   ######.## &"
                .Printa(StriSt(5))
                .Print(StriSt(8))  '"Minimum Design Bar Thickness             =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), tpr0, " [mm]", tpr0 / inc, " [in]"))  '"######.## &   ######.## &"
                .Print(StriSt(9))  '"Adopted Nominal Bar Thickness            =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), Involucr(kLato, jmemb).H0, " [mm]", Involucr(kLato, jmemb).H0 / inc, " [in]"))
            End With
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then
                Call StamMAWP(jmemb)
            End If
            Belts = True
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function

    Sub ConBuckPar(ByRef ang As Single, ByRef DLDL As Single, ByRef Ds As Single, ByRef alc As Single, ByRef aLe As Single)
        DLDL = Involucr(kLato, jInvolucr).di + 2 * Involucr(kLato, jInvolucr).Spess
        Ds = Involucr(kLato, jInvolucr).dns + 2 * Involucr(kLato, jInvolucr).Spess
        If Involucr(kLato, jInvolucr).Tipo = 2 Then
            alc = ((DLDL - Ds) / 2 - (Involucr(kLato, jInvolucr).H0 + Involucr(kLato, jInvolucr).L0) * (1 - System.Math.Cos(ang))) / System.Math.Tan(ang)
            aLe = alc / 2 * (1 + Ds / DLDL)
        Else
            alc = ((DLDL - Ds) - (Involucr(kLato, jInvolucr).H0 + Involucr(kLato, jInvolucr).L0) * (1 - System.Math.Cos(ang))) / System.Math.Tan(ang)
            aLe = alc / 2 * (1 + Ds / DLDL / 2)
        End If
    End Sub
    Sub EditRinf(ByRef a As AdditConN)
        Dim Stringa(10) As String
        Dim Risult(10) As String
        Dim Testo As String
        Stringa(1) = "Distanza da bordo cil. anello grande " & UnitLength
        Stringa(2) = "Spessore  anello grande " & UnitLength
        Stringa(3) = "Altezza   anello grande " & UnitLength
        Stringa(4) = "Spessore ala rinforzo grande " & UnitLength
        Stringa(5) = "Lunghezza ala rinforzo grande " & UnitLength
        Stringa(6) = "Distanza da bordo cil. an. piccolo   " & UnitLength
        Stringa(7) = "Spessore  anello piccolo " & UnitLength
        Stringa(8) = "Altezza   anello piccolo " & UnitLength
        Stringa(9) = "Spessore ala rinforzo piccolo " & UnitLength
        Stringa(10) = "Lunghezza ala rinforzo piccolo " & UnitLength
        Risult(1) = GlobalRoutines.myStr(a.Stiff1.Dist * kLength, 5, 2, 0)
        Risult(2) = GlobalRoutines.myStr(a.Stiff1.Spess * kLength, 5, 2, 0)
        Risult(3) = GlobalRoutines.myStr(a.Stiff1.Alt * kLength, 5, 2, 0)
        Risult(4) = GlobalRoutines.myStr(a.Stiff1.SpessAla * kLength, 5, 2, 0)
        Risult(5) = GlobalRoutines.myStr(a.Stiff1.LungAla * kLength, 5, 2, 0)
        Risult(6) = GlobalRoutines.myStr(a.Stiff2.Dist * kLength, 5, 2, 0)
        Risult(7) = GlobalRoutines.myStr(a.Stiff2.Spess * kLength, 5, 2, 0)
        Risult(8) = GlobalRoutines.myStr(a.Stiff2.Alt * kLength, 5, 2, 0)
        Risult(9) = GlobalRoutines.myStr(a.Stiff2.SpessAla * kLength, 5, 2, 0)
        Risult(10) = GlobalRoutines.myStr(a.Stiff2.LungAla * kLength, 5, 2, 0)
Rifa:   Monitor.Motore.InputDati(10, "Dati rinforzi", Stringa, Risult, "", Arch, dAiu)
        a.Stiff1.Dist = GlobalRoutines.ValVir(Risult(1)) / kLength
        a.Stiff1.Spess = GlobalRoutines.ValVir(Risult(2)) / kLength
        a.Stiff1.Alt = GlobalRoutines.ValVir(Risult(3)) / kLength
        a.Stiff1.SpessAla = GlobalRoutines.ValVir(Risult(4)) / kLength
        a.Stiff1.LungAla = GlobalRoutines.ValVir(Risult(5)) / kLength
        a.Stiff2.Dist = GlobalRoutines.ValVir(Risult(6)) / kLength
        a.Stiff2.Spess = GlobalRoutines.ValVir(Risult(7)) / kLength
        a.Stiff2.Alt = GlobalRoutines.ValVir(Risult(8)) / kLength
        a.Stiff2.SpessAla = GlobalRoutines.ValVir(Risult(9)) / kLength
        a.Stiff2.LungAla = GlobalRoutines.ValVir(Risult(10)) / kLength
        Dim i As Short
        For i = 1 To 2
            OffSetMax(i) = 0.25 * Math.Sqrt(RaggioBocca(i) * (AdditCono(kLato, jInvolucr).Spess(i - 1) - Aspp))
        Next
        If a.Stiff1.Dist > OffSetMax(1) Then
            Testo = "La distanza dell'anello di rinforzo dalla linea di giunzione|"
            Testo = Testo + "(estremità grande)|"
            Testo = Testo + GlobalRoutines.FormatS("è superiore al massimo ammissibile (####.## " & UnitLength & ")", OffSetMax(1) * kLength)
            Testo = Testo + ".|Vuoi correggere il dato?"
            If MsgBox(clsInizio.ConvertiCr(Testo), MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "AsmeVip, 1-8") = MsgBoxResult.Yes Then GoTo Rifa
        End If
        If a.Stiff2.Dist > OffSetMax(2) Then
            Testo = "La distanza dell'anello di rinforzo dalla linea di giunzione|"
            Testo = Testo + "(estremità piccola)|"
            Testo = Testo + GlobalRoutines.FormatS("è superiore al massimo ammissibile (####.## " & UnitLength & ")", OffSetMax(2) * kLength)
            Testo = Testo + ".|Vuoi correggere il dato?"
            If MsgBox(clsInizio.ConvertiCr(Testo), MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "AsmeVip, 1-8") = MsgBoxResult.Yes Then GoTo Rifa
        End If
        Dim nuovaarea1, nuovaarea2 As Single
        nuovaarea1 = Math.Max(a.Rinf(0), a.Stiff1.Spess * a.Stiff1.Alt + a.Stiff1.SpessAla * a.Stiff1.LungAla)
        nuovaarea2 = Math.Max(a.Rinf(1), a.Stiff2.Spess * a.Stiff2.Alt + a.Stiff2.SpessAla * a.Stiff2.LungAla)
        If Not (a.Rinf(0) = nuovaarea1 And a.Rinf(1) = nuovaarea2) Then
            Testo = "Le aree di rinforzo addizionali sono variate.|"
            Testo = Testo + "Sarà necessario ripassare il calcolo una|"
            Testo = Testo + "seconda volta dopo il suo completamento."
            MsgBox(clsInizio.ConvertiCr(Testo), MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "AsmeVip")
        End If
        a.Rinf(0) = nuovaarea1
        a.Rinf(1) = nuovaarea2
    End Sub
    Sub EsenzStress(ByRef nn As Short, ByRef jmemb As Short, ByRef R As Single, ByRef SWR As Single, ByRef iExempt As Short, ByRef Aspp As Single, ByRef i As Short, ByRef TempF As Single)
        Dim tr, Estar, aKZ As Single
        Dim akt, alc, aky As Single
        Dim ake, t0hy, akk, akm As Single
        Dim td1, Ratio, AllFRoo, AllFOpe As Single
        Dim CorrF, tboc, E As Single
        Dim O As wn_FTC
        Dim Spess As Single
        Dim tdMDMT(2), pdMDMT(2) As Single
        tdMDMT(1) = Config(kLato).tdxMDMT(0) '* 1.8 + 32
        tdMDMT(2) = Config(kLato).tdxMDMT(1) '* 1.8 + 32
        pdMDMT(1) = Config(kLato).pdxMDMT(0) '* psi
        pdMDMT(2) = Config(kLato).pdxMDMT(1) '* psi
        iExempt = True
        Select Case Involucr(kLato, jmemb).Tipo
            Case 8 'dilatatore solo
                Estar = 1 'provvisorio!!!!!!!!!!!!
                E = 1
                Ratio = 1
                If Ratio > 1 Then Ratio = 1
                Call CalcCorr(iExempt, i, Ratio, tdMDMT(i), CorrF, TempF)
            Case 6 'piastra
                O = CType(objMemb(Involucr(kLato, jmemb).IndObject), wn_PT).Piastra
                Select Case SWR
                    Case 1
                        P0 = O.Zp(1, 299 + i)
                        If O.Zp(1, 301 + i) > P0 Then P0 = O.Zp(1, 301 + i)
                        Spess = O.Zp(1, 34) / inc / 4
                    Case 2, 3 'lato shell
                        P0 = O.Zp(1, 299 + i)
                        Spess = O.Zp(1, 23) / inc
                    Case 4 'lato tubi
                        P0 = O.Zp(1, 301 + i)
                        Spess = O.Zp(1, 24) / inc
                End Select
                If R > 0 Then
                    Estar = 1 'provvisorio!!!!!!!!!!!!
                    E = 1
                    Matdim(Involucr(kLato, jmemb).indice(1 - 1)).SigmaAmm(1, 100, AllFRoo, AllFOpe)
                    AllFRoo = AllFRoo / mpa
                    tr = P0 * R / (AllFRoo * E - 0.6 * P0)
                    'calcolo tr
                    Ratio = tr * Estar / (Spess - Aspp) ' (Involucro(jmemb).Spess - Aspp)
                Else
                    Ratio = 0
                End If
                If Ratio > 1 Then Ratio = 1
                Call CalcCorr(iExempt, i, Ratio, (O.Zp(1, 271 + i)), CorrF, TempF)
            Case 5 'flange
                P0 = objMemb(Involucr(kLato, jmemb).IndObject).Zp(183 + i)
                If R > 0 Then
                    Estar = 1 'provvisorio!!!!!!!!!!!!
                    E = 1
                    Matdim(Involucr(kLato, jmemb).indice(1 - 1)).SigmaAmm(1, 100, AllFRoo, AllFOpe)
                    AllFRoo = AllFRoo / mpa
329:                tr = P0 * R / (AllFRoo * E - 0.6 * P0)
                    'calcolo tr
                    Ratio = tr * Estar / (objMemb(Involucr(kLato, jmemb).IndObject).Zp(7) - Aspp) ' (Involucro(jmemb).Spess - Aspp)
                Else
                    Ratio = 0
                End If
                Call CalcCorr(iExempt, i, Ratio, (objMemb(Involucr(kLato, jmemb).IndObject).Zp(181 + i)), CorrF, TempF)
            Case 7 'tubi
                P0 = Config(kLato).pdxMDMT(i - 1)
                td1 = Config(kLato).tdxMDMT(i - 1)
                Spess = Involucr(kLato, jInvolucr).Spess
                R = Involucr(kLato, jInvolucr).dns / 2
                Estar = 1 'provvisorio!!!!!!!!!!!!
                E = 1
                Matdim(Involucr(kLato, jmemb).indice(1 - 1)).SigmaAmm(1, 100, AllFRoo, AllFOpe)
                AllFRoo = AllFRoo / mpa
                tr = P0 * R / (AllFRoo * E - 0.6 * P0)
                'calcolo tr
                Ratio = tr * Estar / (Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).cs) ' (Involucro(jmemb).Spess - Aspp)
                Call CalcCorr(iExempt, i, Ratio, td1, CorrF, TempF)
            Case Else
400:            GlobalRoutines.SWAP(P0, pdMDMT(i))
                If nn = 0 Then
410:                Estar = Involucr(kLato, jmemb).ES : If Estar < 0.8 Then Estar = 0.8
                    Select Case Involucr(kLato, jmemb).Tipo
                        Case 0 : Call CylThk(P0, td, tr, R, aKZ, Involucr(kLato, jmemb).S0, Involucr(kLato, jmemb).ES, SWR)
                        Case 1
                            Select Case Involucr(kLato, jmemb).ms
                                Case 1 : alc = Involucr(kLato, jmemb).di + 2 * Aspp
                                Case 2 : alc = Involucr(kLato, jmemb).L0 + Aspp
                                Case 3, 4, 5
                                    alc = Involucr(kLato, jmemb).L0 + Aspp
                                    akt = Involucr(kLato, jmemb).L0 / Involucr(kLato, jmemb).R0
                                Case Else : alc = Involucr(kLato, jmemb).L0 + Aspp
                            End Select
420:                        Call HeadThk(jmemb, Involucr(kLato, jmemb).S0, Involucr(kLato, jmemb).ES, aky, alc, tr, t0hy, akk, ake, akm, akt)
                        Case 2, 3 : Call ConThk(tr, R, Involucr(kLato, jmemb).R0 * pi / 180, Involucr(kLato, jmemb).S0, Involucr(kLato, jmemb).ES, SWR)
                    End Select
                    Ratio = tr * Estar / (Involucr(kLato, jmemb).Spess - Aspp)
                Else
                    Estar = Nozzles(kLato, nn).EffN : If Estar < 0.8 Then Estar = 0.8
                    Matdim(Nozzles(kLato, nn).indice).SigmaAmm(1, TempDes, AllFRoo, AllFOpe)
                    AllFRoo = AllFRoo / mpa
                    Call CylThk(P0, td, tr, R, aKZ, AllFRoo, Nozzles(kLato, nn).EffN, SWR)
                    tboc = Nozzles(kLato, nn).Spess
                    If tboc = 0 Then tboc = (Nozzles(kLato, nn).DiOn - Nozzles(kLato, nn).DiIn) / 2
                    Ratio = tr * Estar / (tboc - Aspp)
                End If
                GlobalRoutines.SWAP(P0, pdMDMT(i))
                Call CalcCorr(iExempt, i, Ratio, tdMDMT(i), CorrF, TempF)
        End Select
    End Sub
    Sub Leggidelta(ByRef i As Short, ByRef deltac As Single, ByRef PSE As Single)
        Dim ifl As Short
        Dim Testo As String
        Dim Paramv, deltav As Single
        Dim Param, delta As Single
        ifl = FreeFile()
22:     FileOpen(ifl, RTrim(clsInizio.Archdir) & "\T15" & Chr(48 + i) & ".DAT", OpenMode.Input, , OpenShare.Shared)
        Testo = LineInput(ifl)
        Paramv = 0 : deltav = 0
        Do
            Input(ifl, Param)
            Input(ifl, delta)
            If Param = -1 Then deltac = 30 : Exit Do
            If Param > PSE Then
25:             deltac = deltav + (PSE - Paramv) / (Param - Paramv) * (delta - deltav)
                Exit Do
            End If
            Paramv = Param : deltav = delta
        Loop
        FileClose(ifl)
    End Sub
    Sub MinTemp(ByRef nn As Short, ByRef jmemb As Short, ByRef R As Single, ByRef SWR As Single)
        Dim i As Short
        Dim Aspp As Single
        If jmemb < 0 Or Config(kLato).NMWDT = 0 Then Exit Sub
        Dim tdMDMT(2), pdMDMT(2) As Single
        tdMDMT(1) = Config(kLato).tdxMDMT(0) ' * 1.8 + 32
        tdMDMT(2) = Config(kLato).tdxMDMT(1) ' * 1.8 + 32
        pdMDMT(1) = Config(kLato).pdxMDMT(0) '* psi
        pdMDMT(2) = Config(kLato).pdxMDMT(1) ' * psi
        Try
            If nn = 0 Then
300:            If Involucr(kLato, jmemb).OS = 0 Then Aspp = Involucr(kLato, jmemb).cs Else Aspp = Involucr(kLato, jmemb).OS
                tgov = Involucr(kLato, jmemb).Spess / inc
                '         IF tgov = 0 THEN tgov = (Nozzles(kLato,nn).DiOn - Nozzles(kLato,nn).DiIn) / 2 / INC
                MWDTrule = Involucr(kLato, jmemb).MWDTrule
                MWDTclause = Involucr(kLato, jmemb).MWDTclause
                MWDTtemp = Involucr(kLato, jmemb).MWDTtemp
                For i = 1 To Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Count
                    If Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.Codice = CodiceStress() Then
                        YieldMWDT = Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.Yield
                        PNumber = Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.PNumber
                        iGr = GlobalRoutines.ValVir(Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.Group)
                        Exit For
                    End If
                Next
                If Not NotApplicable(MWDTrule, StriSt) Then Call MinTempCalc(nn, jmemb, R, SWR, Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, " ", tdMDMT)
            Else
                If div = 0 Then
                    Select Case NozzAdd(kLato, nn).UW16
                        Case 1, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 19, 20, 21, 22, 26, 27, 33 'due pezzi
                            Weld1(jmemb, nn, tdMDMT)
                        Case 2, 14, 23, 25 'due pezzi
                            Weld1(jmemb, nn, tdMDMT)
                            Weld2(jmemb, nn, tdMDMT)
                        Case 3, 4, 24 'tre pezzi
                    End Select
                End If
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Weld2(ByVal jmemb As Short, ByVal nn As Short, ByVal tdMDMT() As Single)
        Dim i As Short
        Dim RR As Single
        MWDTrule = Involucr(kLato, jmemb).MWDTrule
        MWDTclause = Involucr(kLato, jmemb).MWDTclause
        MWDTtemp = Involucr(kLato, jmemb).MWDTtemp
        For i = 1 To Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Count
            If Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.Codice = CodiceStress() Then
                YieldMWDT = Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.Yield
                PNumber = Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.PNumber
                iGr = GlobalRoutines.ValVir(Matdim(Involucr(kLato, jmemb).indice(1 - 1)).Caract.Item(i).TextData.Group)
                Exit For
            End If
        Next
        If NotApplicable(MWDTrule, StriSt) Then Exit Sub
        Monitor.Motore.Problem.Printa(StriSt(4))  ' "Welds on reinforcing pad"
        If Involucr(kLato, jmemb).OS = 0 Then Aspp = Involucr(kLato, jmemb).cs Else Aspp = Involucr(kLato, jmemb).OS
        tgov = Nozzles(kLato, nn).Spess / inc
        If tgov = 0 Then tgov = (Nozzles(kLato, nn).DiOn - Nozzles(kLato, nn).DiIn) / 2 / inc
        tgov1 = Involucr(kLato, jmemb).Spess / inc
        If tgov1 < tgov Then tgov = tgov1
        tgov2 = Nozzles(kLato, nn).PadT
        If tgov2 < tgov Then tgov = tgov2
        RR = Involucr(kLato, jmemb).di / 2 'uhm uhm
        Call MinTempCalc(0, jmemb, RR, 1, Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, "1", tdMDMT)
    End Sub
    Private Sub Weld1(ByVal jmemb As Short, ByVal nn As Short, ByVal tdMDMT() As Single)
        Dim i As Short
        For i = 1 To Matdim(Nozzles(kLato, nn).indice).Caract.Count
            If Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.Codice = CodiceStress() Then
                MWDTrule = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.MWDTrule
                MWDTclause = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.MWDTclause
                MWDTtemp = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.MWDTtemp
                YieldMWDT = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.Yield
                PNumber = Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.PNumber
                iGr = GlobalRoutines.ValVir(Matdim(Nozzles(kLato, nn).indice).Caract.Item(i).TextData.Group)
                Exit For
            End If
        Next
        If NotApplicable(MWDTrule, StriSt) Then Exit Sub
        Monitor.Motore.Problem.Printa(StriSt(3))  ' "Weld nozzle/shell"
        If Nozzles(kLato, nn).ONn = 0 Then Aspp = Nozzles(kLato, nn).CorrA Else Aspp = Nozzles(kLato, nn).ONn
        tgov = Nozzles(kLato, nn).Spess / inc
        If tgov = 0 Then tgov = (Nozzles(kLato, nn).DiOn - Nozzles(kLato, nn).DiIn) / 2 / inc
        tgov1 = Involucr(kLato, jmemb).Spess / inc
        If tgov1 < tgov Then tgov = tgov1
        Call MinTempCalc(nn, jmemb, R, SWR, Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, "1", tdMDMT)
    End Sub
    Sub PrintConCyl(ByRef jmemb As Short, ByRef ang As Single, ByRef App As String, ByRef SpminCono() As Single, ByRef SpminCili() As Single)
        Dim StriSt(18) As String
        Dim i, iout1 As Short
        Dim Para As String = ""
        Dim Rtf As String = ""
        Dim Riga As String = ""
        Dim File As String = ""
        Dim ifl As Short
        Dim k, n As Short
        Rtf = "\RTF"
        iout1 = FreeFile()
        FileOpen(iout1, Trim(clsInizio.DiscoRam) & "SCRATCH", OpenMode.Output)
        ifl = FreeFile()
        Select Case Config(0).US
            Case 0 : File = "\ASME12.DAT"
            Case 1 : File = "\ASME12psi.DAT"
            Case 2 : File = "\ASME12BS.DAT"
        End Select
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & File, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        For i = 0 To 18
            StriSt(i) = LineInput(ifl)
            StriSt(i) = Left(StriSt(i), Len(StriSt(i)) - 1)
        Next
        FileClose(ifl)
        If App = "8" Then Para = "(b)" Else Para = "(c)"
        PrintLine(iout1, GlobalRoutines.FormatS(StriSt(1), App, Para)) '"               Junction at the large end (1-&\ \)                  "
        For i = 1 To 2
            If (i = 1 And Not Involucr(kLato, jmemb).jmemb1 = -1) Or (i = 2 And Not Involucr(kLato, jmemb).jmemb2 = -1) Then
                PrintLine(iout1, GlobalRoutines.FormatS(StriSt(2), AdditCono(kLato, jmemb).Spess(i - 1) * kLength, AdditCono(kLato, jmemb).St(i - 1) * kPress)) '" ######.##     [mm] | ######.#      [psi]|"
                PrintLine(iout1, GlobalRoutines.FormatS(StriSt(3), AdditCono(kLato, jmemb).f(i - 1, 0) * kForce, AdditCono(kLato, jmemb).f(i - 1, 1) * kForce)) '" ########.#    [lb] | ########.#     [lb]|"
                PrintLine(iout1, GlobalRoutines.FormatS(StriSt(4), AdditCono(kLato, jmemb).E(i - 1), AdditCono(kLato, jmemb).eff(i - 1))) '" #.##          [--] | #.##           [--]|"
                If AdditCono(kLato, jmemb).delta(i - 1) > 0 Then
                    PrintLine(iout1, GlobalRoutines.FormatS(StriSt(5), AdditCono(kLato, jmemb).PSE(i - 1), App, i, AdditCono(kLato, jmemb).delta(i - 1))) '" #.######      [--] | ##.##         [deg]|"
                End If
                If AdditCono(kLato, jmemb).Rinf(i - 1) > 0 Then
                    PrintLine(iout1, GlobalRoutines.FormatS(StriSt(16), AdditCono(kLato, jmemb).k(i - 1)))
                End If
                If AdditCono(kLato, jmemb).delta(i - 1) * pi / 180 < ang Or App = "8" Then '------------------
                    If App = "8" Then k = 2 Else k = 0
                    PrintLine(iout1, GlobalRoutines.FormatS(StriSt(6), SpminCono(i + k), SpminCili(i + k) * kLength)) '" #####.##      [mm] | #####.##       [mm]|"
                    PrintLine(iout1, GlobalRoutines.FormatS(StriSt(7), AdditCono(kLato, jmemb).ArL(i - 1), AdditCono(kLato, jmemb).ArL(i - 1) / inc / inc)) ' "######.## &   ######.## &"
                    PrintLine(iout1, GlobalRoutines.FormatS(StriSt(8), AdditCono(kLato, jmemb).AeL(i - 1), AdditCono(kLato, jmemb).AeL(i - 1) / inc / inc)) '"######.## &   ######.## &"
                    PrintLine(iout1, GlobalRoutines.FormatS(StriSt(9), AdditCono(kLato, jmemb).Rinf(i - 1), AdditCono(kLato, jmemb).Rinf(i - 1) / inc / inc)) '"######.## &   ######.## &"
                    If App = "8" Then
                        If AdditCono(kLato, jmemb).Necess(i - 1) > 0 Then
                            PrintLine(iout1, StriSt(18)) ' "--The design is acceptable --"
                        Else
                            PrintLine(iout1, StriSt(12)) '"-------- The design is NOT acceptable -----------"
                        End If
                    Else
                        If AdditCono(kLato, jmemb).Necess(i - 1) > 0 Then
                            PrintLine(iout1, StriSt(10)) ' "--The design is acceptable (knuckle not needed)--"
                        Else
                            If (i = 1 And Addition1(kLato, jmemb).RP > 0) Or (i = 2 And Addition1(kLato, jmemb).Rpp > 0) Then
                                PrintLine(iout1, StriSt(11)) ' "--- The design is acceptable (knuckle needed) ---"
                            Else
                                PrintLine(iout1, StriSt(12)) '"-------- The design is NOT acceptable -----------"
                            End If
                        End If
                    End If
                Else
                    PrintLine(iout1, StriSt(13)) ' "-- Neither knuckle nor reinforcement necessary --"
                End If
                If i = 2 Then Exit For
                PrintLine(iout1, StriSt(0))
                PrintLine(iout1, GlobalRoutines.FormatS(StriSt(14), App, Para)) '"               Junction at the small end (1-&\ \)                  "
            Else
                PrintLine(iout1, StriSt(17))
                If i = 2 Then Exit For
                PrintLine(iout1, StriSt(0))
                PrintLine(iout1, GlobalRoutines.FormatS(StriSt(14), App, Para)) '"               Junction at the small end (1-&\ \)                  "
            End If
        Next
        FileClose(iout1)
        FileOpen(iout1, clsInizio.DiscoRam & "SCRATCH", OpenMode.Input)
        Do
            If EOF(iout1) Then Exit Do
            Riga = LineInput(iout1)
            Do
                n = InStr(Riga, "õ")
                If n = 0 Then Exit Do
                If n > 1 Then Monitor.Motore.Problem.Printa(Left(Riga, n - 1))
                Monitor.Motore.Problem.Print(StriSt(15))
                Riga = Right(Riga, Len(Riga) - n)
            Loop
            Monitor.Motore.Problem.Printa(Riga)
        Loop
        FileClose(iout1)
        Kill(clsInizio.DiscoRam & "SCRATCH")
    End Sub

    Sub PrintRinf(ByRef jmemb As Short, ByRef ang As Single, ByRef ATL() As Single, ByRef BBB() As Single, ByRef AAA() As Single, ByRef Ips() As Single, ByRef iP() As Single)
        Dim ifl As Short
        Dim Rtf As String
        Dim i As Short
        ifl = FreeFile()
        Rtf = "\RTF"
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME25.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 23
            StriSt(i) = LineInput(ifl)
            StriSt(i) = Left(StriSt(i), Len(StriSt(i)) - 1)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(StriSt(1))
            .Printa(StriSt(2))  '"Check of the junction at the large end as a line of support"
            For i = 1 To 2
                If (i = 1 And Not Involucr(kLato, jmemb).jmemb1 = -1) Or (i = 2 And Not Involucr(kLato, jmemb).jmemb2 = -1) Then
                    If AdditCono(kLato, jmemb).Stiff_Renamed(i).Spess > 0 Then
                        .Print(StriSt(3))  '"Reinforcing ring provided ";
                        If AdditCono(kLato, jmemb).Stiff_Renamed(i).Alt > 0 Then .Printa(StriSt(4)) Else .Printa(StriSt(5)) '"inside the shell:"
                        .Printa(GlobalRoutines.FormatS(StriSt(6), AdditCono(kLato, jmemb).Stiff_Renamed(i).Dist, AdditCono(kLato, jmemb).Stiff_Renamed(i).Spess, System.Math.Abs(AdditCono(kLato, jmemb).Stiff_Renamed(i).Alt))) '"   Offset ####. mm, Thk. ####. mm, Height ####. mm."
                        If AdditCono(kLato, jmemb).Stiff_Renamed(i).Dist > OffSetMax(i) Then
                            .Printa(GlobalRoutines.FormatS(StriSt(22), OffSetMax(i)))
                        Else
                            .Printa(GlobalRoutines.FormatS(StriSt(23), OffSetMax(i)))
                        End If
                        If AdditCono(kLato, jmemb).Stiff_Renamed(i).SpessAla > 0 Then
                            .Printa(GlobalRoutines.FormatS(StriSt(21), AdditCono(kLato, jmemb).Stiff_Renamed(i).SpessAla, AdditCono(kLato, jmemb).Stiff_Renamed(i).LungAla))
                        End If
                    End If
                    If i = 1 Then
                        .Print(StriSt(7))  ' "Equivalent area large  junction, AT  =   ";
                    Else
                        .Print(StriSt(8))
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(9), ATL(i), ATL(i) / inc / inc))  '" ##.###^^^^   [mm2]   ##.###^^^^    [in2] "
                    If Involucr(kLato, jmemb).Tipo = 2 Then
                        .Print(StriSt(10))  ' "Factor B from Step 1  of 1-8(b) & (c)=   ";
                    Else
                        .Print(StriSt(11))  '"Factor B from Step 1  of UG-29(a)    =   ";
                    End If
                    .Printa(GlobalRoutines.FormatS(StriSt(12), BBB(i), BBB(i) * psi)) '" ######.##    [psi] "
                    .Print(StriSt(13))  ' "Factor A from Step 5                 =   ";
                    .Printa(GlobalRoutines.FormatS(StriSt(14), AAA(i)))  '" ##.###^^^^    [--] "
                    .Print(StriSt(15))  '"Required moment of inertia,      I's =   ";
                    .Printa(GlobalRoutines.FormatS(StriSt(16), Ips(i), Ips(i) / inc ^ 4))  '" ##.###^^^^   [mm4]   ##.###^^^^    [in4] "
                    .Print(StriSt(17))  '"Available moment of inertia,     I'  =   ";
                    .Printa(GlobalRoutines.FormatS(StriSt(16), iP(i), iP(i) / inc ^ 4))  '" ##.###^^^^   [mm4]   ##.###^^^^    [in4] "
                    .Printa(StriSt(1))
                    If iP(i) > Ips(i) Then
                        .Printa(StriSt(18))  '"--The design is acceptable"
                    Else
                        .Printa(StriSt(19))  '"--The design is NOT acceptable"
                    End If
                    .Printa(StriSt(1))
                    If i = 1 Then
                        .Printa("Check of the junction at the small end as a line of support")
                    End If
                Else
                    .Printa("\par NOT APPLICABLE: rigid junction")
                    .Printa(StriSt(1))
                    .Printa("Check of the junction at the small end as a line of support")
                End If
            Next
        End With
    End Sub

    Sub TestaCylCon(ByRef Aspp As Single, ByRef jmemb As Short, ByRef s As Single)
        Dim StriSt(12) As String
        Dim ifl As Short
        Dim ii As Short
        Dim Rtf As String
        ifl = FreeFile()
        Rtf = "\RTF"
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME31.DAT", OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        For ii = 1 To 12
            StriSt(ii) = LineInput(ifl)
            StriSt(ii) = Left(StriSt(ii), Len(StriSt(ii)) - 1)
        Next ii
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(GlobalRoutines.FormatS(StriSt(2), Involucr(kLato, jmemb).Mark))  ' "Identification: "
            .Printa(GlobalRoutines.FormatS(StriSt(3), USStr(0), STStr))
            .Printa(StriSt(4))  ' DL$; DL$; DL$
            .Printa(GlobalRoutines.FormatS(StriSt(5), Involucr(kLato, jmemb).MATE))  '"Material : "
            'PRINT #iout, "Design Stress Value                  S   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), s, s * psi))
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(kLato).NMWDT > 0 And Not VerificandoPI Then
                If InStr(Involucr(kLato, jmemb).MWDTrule, "UCS") Then
                    .Printa(GlobalRoutines.FormatS(StriSt(7), RTrim(Involucr(kLato, jmemb).MWDTrule), Involucr(kLato, jmemb).MWDTclause))  '"Low Temperature Operation. Rules: "
                Else
                    .Printa(GlobalRoutines.FormatS(StriSt(8), RTrim(Involucr(kLato, jmemb).MWDTrule)))
                End If
            End If
            .Printa(StriSt(1))
            'PRINT #iout, "Joint Efficiency                     E   =";
            .Printa(GlobalRoutines.FormatS(StriSt(10), Involucr(kLato, jmemb).ES, Involucr(kLato, jmemb).ES))
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 19680
            .Printa(GlobalRoutines.FormatS(StriSt(11), Aspp, Aspp / inc))
            Exit Sub
19680:      .Printa(GlobalRoutines.FormatS(StriSt(12), Aspp, Aspp / inc))
        End With
    End Sub
    Sub BelPres(ByRef jmemb As Short)
        Dim i As Short
        Dim Pmax1 As Single
        Dim Aj, T0 As Single
        Dim s, E As Single
        Dim Pmax, R, aKZ As Single
        For i = 1 To 4
            iMAWP = i
            Select Case i
                Case 1 'nuovo e freddo
                    Aj = (Involucr(kLato, jmemb).di - Involucr(kLato, jmemb).dns) / 2
                    T0 = Involucr(kLato, jmemb).H0
                    s = Involucr(kLato, jmemb).S0
                    R = Involucr(kLato, jmemb).di / 2
                Case 2 'nuovo e caldo
                    Aj = (Involucr(kLato, jmemb).di - Involucr(kLato, jmemb).dns) / 2
                    T0 = Involucr(kLato, jmemb).H0
                    s = Involucr(kLato, jmemb).St
                    R = Involucr(kLato, jmemb).di / 2
                Case 3 'corroso e freddo
                    Aj = (Involucr(kLato, jmemb).di - Involucr(kLato, jmemb).dns) / 2 + 2 * Involucr(kLato, jmemb).cs
                    T0 = Involucr(kLato, jmemb).H0 - Involucr(kLato, jmemb).cs
                    s = Involucr(kLato, jmemb).S0
                    R = Involucr(kLato, jmemb).di / 2 - Involucr(kLato, jmemb).cs
                Case 4 'corroso e caldo
                    Aj = (Involucr(kLato, jmemb).di - Involucr(kLato, jmemb).dns) / 2 + 2 * Involucr(kLato, jmemb).cs
                    T0 = Involucr(kLato, jmemb).H0 - Involucr(kLato, jmemb).cs
                    s = Involucr(kLato, jmemb).St
                    R = Involucr(kLato, jmemb).di / 2 - Involucr(kLato, jmemb).cs
            End Select
            Pmax = (T0 / 0.707 / Aj) ^ 2 * s
            E = Involucr(kLato, jmemb).ES
            Call CylPres(Pmax1, T0 / 2, R, aKZ, s, E, 0)
            If Pmax1 < Pmax Then Pmax = Pmax1
            Involucr(kLato, jmemb).MAWP(i - 1) = Pmax
        Next
        iMAWP = 0
    End Sub
    Sub CheckCon(ByRef KL As Short, ByRef jmemb As Short)
        Dim Log2, Log1, Log3 As Boolean
        Dim Testo As String
        Log1 = (Involucr(KL, jmemb).jmemb1 = Involucr(KL, jmemb).jmemb2)
        Log2 = (Involucr(KL, jmemb).jmemb1 = jmemb)
        Log3 = (Involucr(KL, jmemb).jmemb2 = jmemb)
        If Log1 Or Log2 Or Log3 Then
            Testo = "I cilindri sulle estremità del cono " & Trim(Involucr(KL, jmemb).Mark)
            Testo = Testo & "|non sono stati definiti o sono stati definiti|in modo erroneo.|"
            Testo = Testo & "Si assumono quindi estremità rigide.   ||"
            Testo = Testo & "Sarà però possibile specificare in seguito|"
            Testo = Testo & "quali virole sono saldate al cono."
            MessageBox.Show(clsInizio.ConvertiCr(Testo))
            Involucr(KL, jmemb).jmemb1 = -1
            Involucr(KL, jmemb).jmemb2 = -1
        End If
        If Involucr(KL, jmemb).jmemb1 = 0 Then
            Testo = "Il cilindro sulla large end del cono " & Trim(Involucr(KL, jmemb).Mark)
            Testo = Testo & "|non è stato correttamente definito.|"
            Testo = Testo & "Si assume quindi estremità rigida.||   "
            Testo = Testo & "Sarà però possibile specificare in seguito|"
            Testo = Testo & "quale virola è saldata al cono."
            MessageBox.Show(clsInizio.ConvertiCr(Testo))
            Involucr(KL, jmemb).jmemb1 = -1
        End If
        If Involucr(KL, jmemb).jmemb2 = 0 Then
            Testo = "Il cilindro sulla small end del cono " & RTrim(Involucr(KL, jmemb).Mark)
            Testo = Testo & "|non è stato correttamente definito.|"
            Testo = Testo & "Si assume quindi estremità rigida.   ||"
            Testo = Testo & "Sarà però possibile specificare in seguito|"
            Testo = Testo & "quale virola è saldata al cono."
            MessageBox.Show(clsInizio.ConvertiCr(Testo))
            Involucr(KL, jmemb).jmemb2 = -1
        End If
    End Sub

    Sub ConPres(ByRef Press As Single, ByRef T0 As Single, ByRef R As Single, ByRef ang As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11
                ASME1(Press, ang, T0, R, s, E)
            Case 3, 4, 5
                ASME1(Press, ang, T0, R, s, E)  '(sarebbe 2)
            Case 6, 7, 8 'EuroNOrm
                EURO(Press, ang, T0, R, s, E)
        End Select
        Exit Sub
    End Sub
    Private Sub EURO(ByRef Press As Single, ByVal ang As Single, ByVal T0 As Single, ByVal R As Single, ByVal s As Single, ByVal E As Single)
        If SWR > 0 Then
            Rm = R - 0.5 * T0
        Else
            Rm = R + 0.5 * T0
        End If
        Press = T0 * s * E / Rm * System.Math.Cos(ang)
        USStr(1) = "(7.6-4)"
    End Sub
    Private Sub ASME1(ByRef Press As Single, ByVal ang As Single, ByVal T0 As Single, ByVal R As Single, ByVal s As Single, ByVal E As Single)
        If SWR > 0 Then
            USStr(1) = " 1-4 "
            Press = 2 * s * E * T0 * System.Math.Cos(ang) / (2 * R - 0.8 * T0 * System.Math.Cos(ang))
        Else
            USStr(1) = " UG-32(g) "
            Press = 2 * s * E * T0 * System.Math.Cos(ang) / (2 * R + 1.2 * T0 * System.Math.Cos(ang))
        End If
    End Sub
    Sub SuperConThk(ByRef T0 As Single, ByRef R As Single, ByRef ang As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        If div = 2 Then
            EUConThk(T0, R, ang, s, E, SWR)
        Else
            ConThk(T0, R, ang, s, E, SWR)
        End If
    End Sub

    Sub ConThk(ByRef T0 As Single, ByRef R As Single, ByRef ang As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        If SWR > 0 Then
            USStr(0) = " 1-4 "
            T0 = P0 * R / (s * E + 0.4 * P0) / System.Math.Cos(ang)
        Else
            USStr(0) = " UG-32(g) "
            T0 = P0 * R / (s * E - 0.6 * P0) / System.Math.Cos(ang)
        End If
    End Sub

    Sub ConThkExt(ByRef tr As Single, ByRef RcollCon As Single, ByRef ang As Single, ByRef i As Short)
        Dim jCyl As Short
        Dim AlunCyl As Single
        Dim Testo As String
        Dim Stringa(3) As String
        Dim Risult(3) As String
        Try
            If ang = 0 Then
                If i = 1 Then jCyl = Involucr(kLato, jInvolucr).jmemb1 Else jCyl = Involucr(kLato, jInvolucr).jmemb2
                AlunCyl = Involucr(kLato, jCyl).L0
                If AlunCyl = 0 Then
                    Testo = "Non è stata definita la lunghezza" & vbCrLf
                    Testo = Testo & "del cilindro "
                    If i = 1 Then Testo = Testo & "large end." Else Testo = Testo & "small end." & vbCrLf
                    Stringa(1) = "Pls enter value [mm]"
                    Risult(1) = GlobalRoutines.myStr(AlunCyl, 5, 2, False)
                    If Not Monitor.Motore.InputDati(1, "Giunzioni cono/cilindro", Stringa, Risult, "", Arch, dAiu, Testo) Then tr = 0 : Exit Sub
                    AlunCyl = GlobalRoutines.ValVir(Risult(1))
                    Involucr(kLato, jCyl).L0 = AlunCyl
                End If
                ang = -1
            End If
            trPressExt(ang, RcollCon, AlunCyl, tr)
            If ang < 0 Then ang = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Function GeomNoz(ByRef nn As Short, ByRef jmemb As Short, ByRef tcs As Single, ByRef Trs As Single, ByRef Rn As Single, ByRef rc As Single, ByRef CosecB As Single) As Short
        Dim TCV, DCL, beta As Single
        Dim Alfa1, x, Alfa2 As Single
        Dim Testo As String
        Try
            AlfaS = 0
            GeomNoz = True
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
            'PRINT " Nozzle CL to Shell CL Dist.  (ëCL=0 for A1&A2) "; GD$; " ëCL =";
            'IF indcl = 0 THEN INPUT #ifl, dcl, Testo: indcl = 1
96600:      'PRINT " Nozzle CL to Shell CL Angle      (á=90 for A1) "; GTesto; " á   =";
            'IF inbeta = 0 THEN INPUT #ifl, beta, Testo: inbeta = 1
            beta = Nozzles(kLato, nn).beta
            DCN = 2 * Rn
            If DCL = 0 Then GoTo 96720
96640:      Rm = rc + TRV / 2
            x = (DCL + Rn) / Rm
            Alfa1 = pi / 2 - System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
            x = (DCL - Rn) / Rm
            Alfa2 = pi / 2 - System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
            AlfaS = Alfa2 - Alfa1
            DCN = 2 * Rm * System.Math.Sqrt((1 - System.Math.Cos(AlfaS)) / 2)
            CosecB = DCN / 2 / Rn
96720:      If beta = 90 Then GoTo 96760
            If System.Math.Abs(beta) < 1 Then
                Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                Testo = Testo & "|  I dati relativi al posizionamento del bocchello |"
                Testo = Testo & "sono inconsistenti. Pregasi controllare."
                If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then GeomNoz = False : Exit Function
                If Not DatiNozzles(kLato, jmemb, nn) Then GeomNoz = False : Exit Function
                GeomNoz = 1 : Exit Function
            End If
            DLN = 2 * Rn / System.Math.Sin(beta * pi / 180)
            CosecB = DLN / 2 / Rn
            GoTo 96770
96760:      DLN = 2 * Rn
96770:      If Nozzles(kLato, nn).Padd * Nozzles(kLato, nn).PadT > 0 Then Fprel = 1 Else Fprel = 0.5
            If DCN > DLN / Fprel Then
                DN = DCN
                Ffact = Fprel
                Circonf = True
            Else
                DN = DLN
                Ffact = 1.0!
                CosecB = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function

    Sub StamMAWPcon(ByRef jmemb As Short)
        Dim StriSt(6) As String
        Dim ifl As Short
        Dim Rtf As String
        Dim Stringa1(4) As String
        Dim i As Short
        Stringa1(1) = " Cone"
        Stringa1(2) = " Knuckles"
        Stringa1(3) = " Junction at large end"
        Stringa1(4) = " Junction at small end"
        ifl = FreeFile()
        Rtf = "\RTF"
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME21.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(StriSt(1))
            .Printa(StriSt(2))  '"Calculation of the Maximum Allowable Working Pressures"
            .Printa(GlobalRoutines.FormatS(StriSt(3) & " &", Involucr(kLato, jmemb).MAWP(1 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(1 - 1) * psi, "[psi]", Stringa1(AdditCono(kLato, jmemb).Contr(0))))
            .Printa(GlobalRoutines.FormatS(StriSt(4) & " &", Involucr(kLato, jmemb).MAWP(2 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(2 - 1) * psi, "[psi]", Stringa1(AdditCono(kLato, jmemb).Contr(1))))
            .Printa(GlobalRoutines.FormatS(StriSt(5) & " &", Involucr(kLato, jmemb).MAWP(3 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(3 - 1) * psi, "[psi]", Stringa1(AdditCono(kLato, jmemb).Contr(2))))
            .Printa(GlobalRoutines.FormatS(StriSt(6) & " &", Involucr(kLato, jmemb).MAWP(4 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(4 - 1) * psi, "[psi]", Stringa1(AdditCono(kLato, jmemb).Contr(3))))
        End With
    End Sub

    Sub Testa2(ByRef Tipo As Short, ByRef jmemb As Short)
        Dim Gradf, Subd, GradC As String
        Dim StriSt(7) As String
        Dim ifl As Short
        Dim i As Short
        Dim Test As String = ""
        If jmemb > 0 Then
            Test = "#" & Involucr(kLato, jmemb).Suffix
            If Involucr(kLato, jmemb).Suffix.Trim.Length = 0 Then Test = New String(CChar(" "), 4)
        End If
        Call Monitor.Motore.Testata(Test)
        Subd = "\RTF" : Gradf = " [\'b0F]" : GradC = " [\'b0C]"
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Subd & "\ASME22.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 7 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(StriSt(1))
            .Printa(GlobalRoutines.FormatS(StriSt(2), CodiceCalc))  '"ASME 1992 Edition + Addenda '94")
            .Printa(StriSt(3))  ' DL$; DL$; DL$; DL$; DL$; DL$; DL$; DL$
            .Printa(StriSt(1))
            .Printa(GlobalRoutines.FormatS(StriSt(4), RTrim(xsStr), RTrim(xhStr)))
            .Print(StriSt(5))  '"External Design Pressure             P   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), 0.1, "[MPa]", 14.5, "[psi]"))                 '"######.## &   ######.## &"
19170:      .Print(StriSt(7))  '"Design Temperature                   é   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).tdx, GradC, td, Gradf))  '"######.## &   ######.## &"
            .Printa(StriSt(1))
        End With
    End Sub
    Public Sub DatiDoub(ByRef KL As Short, ByRef jmemb As Short)
        Dim i As Short
        AggForm()
        With frmConDoub.DefInstance
            .ShowDialog()
            For i = 1 To 2
                If (Not (Involucr(KL, jmemb).jmemb1 = -1) And i = 1) Or (Not (Involucr(KL, jmemb).jmemb2 = -1) And i = 2) Then
                    If i = 1 Then
                        AdditCono(KL, jmemb).MATE1 = .TextCil((i - 1) * 20).Text
                    ElseIf i = 2 Then
                        AdditCono(KL, jmemb).MATE2 = .TextCil((i - 1) * 20).Text
                    End If
                    AdditCono(KL, jmemb).Spess(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 1).Text) / kLength
                    If i = 1 Then If Involucr(KL, jmemb).jmemb1 > 0 Then Involucr(KL, Involucr(KL, jmemb).jmemb1).Spess = AdditCono(KL, jmemb).Spess(i - 1)
                    If i = 2 Then If Involucr(KL, jmemb).jmemb2 > 0 Then Involucr(KL, Involucr(KL, jmemb).jmemb2).Spess = AdditCono(KL, jmemb).Spess(i - 1)
                    AdditCono(KL, jmemb).eff(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 3).Text)
                    AdditCono(KL, jmemb).E(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 4).Text)
                    If VerificandoPI Then
                        AdditCono(KL, jmemb).Shydr(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 5).Text) / kPress
                    Else
                        AdditCono(KL, jmemb).S0(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 5).Text) / kPress
                        AdditCono(KL, jmemb).St(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 6).Text) / kPress
                    End If
                    AdditCono(KL, jmemb).f(i - 1, 0) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 7).Text) / kForce
                    AdditCono(KL, jmemb).f(i - 1, 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 8).Text) / kForce
                    AdditCono(KL, jmemb).k(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 9).Text)
                    AdditCono(KL, jmemb).Rinf(i - 1) = GlobalRoutines.ValVir(.TextCil((i - 1) * 20 + 10).Text) / kLength / kLength
                End If
            Next
            If Involucr(KL, jmemb).jmemb1 > 0 Then
                Involucr(KL, Involucr(KL, jmemb).jmemb1).L0 = GlobalRoutines.ValVir(._TextCil_2.Text) / kLength
                Involucr(KL, Involucr(KL, jmemb).jmemb1).Mark = ._cmbCil_0.Text
            End If
            If Involucr(KL, jmemb).jmemb2 > 0 Then
                Involucr(KL, Involucr(KL, jmemb).jmemb2).Mark = ._cmbCil_20.Text
                Involucr(KL, Involucr(KL, jmemb).jmemb2).L0 = GlobalRoutines.ValVir(._TextCil_22.Text) / kLength
            End If
            .Close()
            .Dispose()
        End With
    End Sub
    Public Sub ConVacuumPr(ByRef jmemb As Short, ByRef s As Single)
        Dim i, ifl As Short
        If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(kLato).Vacuum Then
            If Involucr(kLato, jmemb).H0 = 0 Or Involucr(kLato, jmemb).L0 = 0 Then
                Call Testa2(0, jmemb)
                USStr(2) = "UG-33(f)+1.8"
                Call TestaCylCon(Aspp, jmemb, s)
            End If
            ifl = FreeFile()
            FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME13.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 0 To 29 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            With Monitor.Motore.Problem
                .Printa(StriSt(0))
                .Printa(StriSt(18))  ' "Design under vacuum conditions"
                .Print(StriSt(28))
                .Printa(GlobalRoutines.FormatS(StriSt(3), Pextdes(), "[MPa]", Pextdes() * psi, "[psi]")) '"######.## &   ######.## &"
                .Print(StriSt(29))
                .Printa(GlobalRoutines.FormatS(StriSt(3), Textdes(), "[\'b0C ]", Textdes() * 1.8 + 32, "[\'b0F ]")) '"######.## &   ######.## &"
                .Print(StriSt(19))  '"Cone  effective thickness             te =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), TE, " [mm]", TE / inc, " [in]"))  '"######.## &   ######.## &"
                .Print(StriSt(20))  '"Cone  effective length                Le =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), aLe, " [mm]", aLe / inc, " [in]"))  '"######.## &   ######.## &"
                .Print(StriSt(21))  ' "Slenderness parameters DL/te, Le/DL      =";
                .Printa(GlobalRoutines.FormatS(StriSt(3), DLDL / TE, " [--]", aLe / DLDL, " [--]"))  '"######.## &   ######.## &"
                .Print(StriSt(22))  '"A-factor per Fig. G, II-D Subpart 3      =";
                .Printa(GlobalRoutines.FormatS(StriSt(25), Asnell, " [--]", Asnell, " [--]"))  '"#.###^^^^ &   #.###^^^^ &"
                .Print(StriSt(23) & Left(Chart, 21) & " =")  ' "B-factor per curve "
                .Printa(GlobalRoutines.FormatS(StriSt(3), psig, " [MPa]", psig * psi, " [psi]")) '"######.## &   ######.## &"
                .Print(StriSt(24))  '"Allowable external pressure              =";
                .Printa(GlobalRoutines.FormatS(StriSt(26), psig1, " [MPa]", psig1 * psi, " [psig]")) '"###.##### &   #####.## &"
                .Printa(StriSt(0))
            End With
            If Involucr(kLato, jmemb).H0 = 0 Or Involucr(kLato, jmemb).L0 = 0 Then
250:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AdditCono(kLato, Config().Ninvolucri + 1). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                AdditCono(kLato, Config(kLato).Ninvolucri + 1) = AdditCono(kLato, jmemb)
                AdditCono(kLato, jmemb).delta(0) = deltac1 : AdditCono(kLato, jmemb).delta(1) = 0
                AdditCono(kLato, jmemb).PSE(0) = PSE1
                For i = 1 To 2
                    AdditCono(kLato, jmemb).ArL(i - 1) = ArLExt(i)
                    AdditCono(kLato, jmemb).AeL(i - 1) = AeLExt(i)
                    AdditCono(kLato, jmemb).Necess(i - 1) = -ArLExt(i) + AeLExt(i) + AdditCono(kLato, jmemb).Rinf(i - 1)
                Next
                Call PrintConCyl(jmemb, ang, "8", SpminCono, SpminCili)
                Call PrintRinf(jmemb, ang, ATL, BBB, AAA, Ips, iP)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AdditCono(kLato, jmemb). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                AdditCono(kLato, jmemb) = AdditCono(kLato, Config(kLato).Ninvolucri + 1)
            End If
            '-------------------MDMT-----------------------------------
            If Config(kLato).NMWDT > 0 Then
                'xsStr = "Low Temperature": xhStr = ""
                Call Testa2(0, jmemb)
                USStr(2) = "UG-84"
                Call TestaCylCon(Aspp, jmemb, s)
                Call MinTemp(0, jmemb, Rsav, SWR)
            End If
            '----------------------------------------------------------
        End If

    End Sub

    Public Sub ConShellPr(ByRef jmemb As Short, ByRef s As Single)
        Dim i, ifl As Short
        Dim Ped As String
170:    Call Testa1(jmemb)
        Call TestaCylCon(Aspp, jmemb, s)
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME13.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 31 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            For i = 1 To 2
                If i = 1 Then
180:                R = Involucr(kLato, jmemb).di / 2 + Aspp - Involucr(kLato, jmemb).H0 * (1 - System.Math.Cos(ang))
181:                If Involucr(kLato, jmemb).H0 = 0 Then RP = 0 Else RP = Involucr(kLato, jmemb).H0 + Aspp
                    Addition1(kLato, jmemb).RP = RP
                Else
182:                R = Involucr(kLato, jmemb).dns / 2 + Aspp + Involucr(kLato, jmemb).L0 * (1 - System.Math.Cos(ang))
183:                If Involucr(kLato, jmemb).L0 = 0 Then RP = 0 Else RP = Involucr(kLato, jmemb).L0
                    Rpp = RP
                    Addition1(kLato, jmemb).Rpp = Rpp
                End If
                If Involucr(kLato, jmemb).OS = 0 Then
186:                If i = 1 Then .Print(StriSt(1)) Else .Print(StriSt(2)) '"Corroded Inside Radius,  small end   Rg  ="; '"Corroded Inside Radius,  large end   Rg  ="
                    .Printa(GlobalRoutines.FormatS(StriSt(3), R, " [mm]", R / inc, " [in]"))  '"######.## &   ######.## &"
                    If i = 1 Then .Print(StriSt(4)) Else .Print(StriSt(5)) ' "Corroded Knuckle Radius, small end   rp  ="; '"Corroded Knuckle Radius, large end   rg  ="
                    If i = 1 Then .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).RP, " [mm]", Addition1(kLato, jmemb).RP / inc, " [in]")) Else .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).Rpp, " [mm]", Addition1(kLato, jmemb).Rpp / inc, " [in]")) '"######.## &   ######.## &"
                Else
                    If i = 1 Then .Print(StriSt(6)) Else .Print(StriSt(7)) ' "Ins.Radius on Base Mat., small end   R   ="; ' "Ins.Radius on Base Mat., large end   Rp  ="
                    .Printa(GlobalRoutines.FormatS(StriSt(3), R, " [mm]", R / inc, " [in]"))  '"######.## &   ######.## &"
                    If i = 1 Then .Print(StriSt(8)) Else .Print(StriSt(9)) ' "Knuckle Radius on Base M., small end  rp  ="; ' "Knuckle Radius on Base M., large end  rp  ="
                    If i = 1 Then .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).RP, " [mm]", Addition1(kLato, jmemb).RP / inc, " [in]")) Else .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).Rpp, " [mm]", Addition1(kLato, jmemb).Rpp / inc, " [in]")) '"######.## &   ######.## &"
                End If
            Next
            Select Case Involucr(kLato, jmemb).Tipo
                Case 2 : .Print(StriSt(10)) ' "Half-apex angle                      à   =";
                Case 3 : .Print(StriSt(11)) '"Half-apex angle of the equiv.cone    à   =";
            End Select
190:        .Printa(GlobalRoutines.FormatS("######.## &", Involucr(kLato, jmemb).R0, " [deg]"))
            .Print(StriSt(12))  '"to =PRg/((SE-0.6P)*cos(à))               =";
            .Printa(GlobalRoutines.FormatS(StriSt(3), t0c, " [mm]", t0c / inc, " [in]"))  '"######.## &   ######.## &"
            For i = 1 To 2
                If Addition1(kLato, jmemb).RP > 0 And i = 1 Or Addition1(kLato, jmemb).Rpp > 0 And i = 2 Then
                    If i = 1 Then Ped = "g" Else Ped = "p"
191:                .Print(GlobalRoutines.FormatS(StriSt(13), Ped, Ped))  '"Ratio Crown to Knuckle R. 2Rg/(rg*cos(à))=";
                    .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).akt(i - 1), "  [-]", Addition1(kLato, jmemb).akt(i - 1), "  [-]"))  '"######.## &   ######.## &"
                    .Print(StriSt(14))  '"Factor from Table 1-4.2              M   =";
                    .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).akm(i - 1), "  [-]", Addition1(kLato, jmemb).akm(i - 1), "  [-]"))  '"######.## &   ######.## &"
                    .Print(StriSt(15))  ' "to'=PLM/(2SE-0.2P)                       =";
                    .Printa(GlobalRoutines.FormatS(StriSt(3), Addition1(kLato, jmemb).t0th(i - 1), " [mm]", Addition1(kLato, jmemb).t0th(i - 1) / inc, " [in]"))  '"######.## &   ######.## &"
                End If
            Next
192:        .Print(StriSt(16))  ' "Minimum Design Thickness                 =";
            .Printa(GlobalRoutines.FormatS(StriSt(3), tms, " [mm]", tms / inc, " [in]"))  '"######.## &   ######.## &"
            If Config(kLato).Vacuum And Not VerificandoPI Then
                .Print(StriSt(30))
                .Printa(GlobalRoutines.FormatS(StriSt(3), SpxBExt, " [mm]", SpxBExt / inc, " [in]"))
            End If
            .Print(StriSt(31)) '"Minimum Thickness to UG-16(b)      ="; '140506
            .Printa(GlobalRoutines.FormatS(StriSt(3), 1.5, " [mm]", 1 / 16, " [in]"))  '140506
            .Print(StriSt(17))  '"Adopted Nominal Thickness             tc =";
            .Printa(GlobalRoutines.FormatS(StriSt(3), Involucr(kLato, jmemb).Spess, " [mm]", TNSY, " [in]"))  '"######.## &   ######.## &"
            .Printa(StriSt(0))
        End With
        Call PrintConCyl(jmemb, ang, "5", SpminCono, SpminCili)
    End Sub
    Sub MAWPtubi(ByRef i As Short)
        Dim Corr, t, thk As Single
        Dim Sfa, Sfo, s As Single
        Dim Chart As String = ""
        Dim codice As Short
        With Involucr(kLato, jInvolucr)
            Select Case i
                Case 1, 3 : t = 20
                Case 2, 4 : t = .Destemp
            End Select
            codice = CodiceStress()
            If .St = 0 Then
                Matdim(.indice(1 - 1)).SigmaAmm(codice, t, Sfa, Sfo)
            End If
            If i = 1 Or i = 2 Then Corr = 0 Else Corr = .cs
            If i = 1 Or i = 3 Then s = .S0 Else s = .St
            thk = .TubeMinT - Corr
            ' If .R0 > 0 Then
            '   Thk = Thk * (1 - .dns / 4 / .R0) + Corr
            ' End If
            Select Case CType(CodiceStress(), Codes)
                Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                    .MAWP2(i - 1) = thk * s * .ES / (.dns / 2 - 0.4 * thk)
                Case Codes.EU
                    .MAWP2(i - 1) = thk * s * .ES / ((.dns - thk) / 2)
            End Select
            psig2 = 0
            PressExtCil(.dns, thk, .L0, t, .indice(1 - 1), psig, psig1, psig2, Chart)
            .MAWP(i - 1) = psig1
            If psig2 > 0 And psig2 < psig1 Then .MAWP(i - 1) = psig2
        End With
    End Sub
    Function CalcTubi() As Short
        Dim Testo As String = ""
        Dim Chart As String = ""
        Dim thk As Single
        Dim savjInv, i, savkL As Short
        Dim iPT, Ris
        Dim codice As Short
        Dim O As wn_Tub
        Dim sid2, sid1, Testo1 As String
        Dim lContinuoAuto As Boolean
        Static iTipo As Short
        Dim f As frmRis = New frmRis
        lContinuoAuto = ContinuoAuto
        codice = CodiceStress()
        iTipo = iTipo + 1
        CalcTubi = True
        Try
            With Involucr(kLato, jInvolucr)
                ' spessore t
                If .TubeMinT = 0 Then .TubeMinT = .Spess
                P0 = .PressInt
                If .ES < 0.6 Then .ES = 1
                Select Case CType(codice, Codes)
                    Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                        .TubeAdopt = P0 * .dns / 2 / (.St * .ES + 0.4 * P0) + .cs * CondizioniCorrose
                    Case Codes.EU
                        .TubeAdopt = P0 * .dns / 2 / (.St * .ES + P0) + .cs * CondizioniCorrose
                        If .TubeAdopt / .dns > 0.16 Then
                            MessageBox.Show("Regola 7.4.1 non soddisfatta")
                        End If
                End Select
                If .PressExt > 0 Then
                    If .L0 = 0 Then
                        MessageBox.Show("Non è stata fornita la lunghezza dei tubi" & vbCrLf & "per il calcolo a pressione esterna")
                        Exit Function
                    End If
                    td = TempDes()
                    psig2 = 0
                    thk = .TubeMinT - .cs * CondizioniCorrose
                    ' If .R0 > 0 Then
                    '     Thk = Thk * (1 - .dns / 4 / .R0)
                    ' End If
                    PressExtCil(.dns, thk, .L0, td, .indice(1 - 1), psig, psig1, psig2, Chart)
                    If psig < 0 Then lContinuoAuto = False
                    TIR = Chart
                End If
                If .R0 > 0 Then
                    tms = (.TubeAdopt - .cs * CondizioniCorrose) * (1 + .dns / 4 / .R0) + .cs * CondizioniCorrose
                Else
                    tms = 0
                End If
                If .ms < 2 Then
                    O = objMemb(.IndObject)
                    If Not O.Calcolato Then O.Calcola()
                End If
                f.TabStrip1.Visible = False
                f.Picture2.Visible = False
                f._Label1_0.Visible = False
                f._Label1_1.Visible = False
                f._Text1_0.Visible = False
                f._Text1_1.Visible = False
                f.cmdDilat.Visible = False
                f.cmdFattUs.Visible = False
                f._Command3_0.Visible = False
                f._Command3_1.Visible = False
                f.Picture1.Visible = True
                f.Picture1.BringToFront()
                ifl = FreeFile()
                Dim Templ As String = ""
                Select Case CType(codice, Codes)
                    Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                        Select Case Config(0).US
                            Case 0 : Templ = "\WN5\PAG5SI.FTC"
                            Case 1 : Templ = "\WN5\PAG5.FTC"
                            Case 2 : Templ = "\WN5\PAG5BS.FTC"
                        End Select
                        FileOpen(ifl, Monitor.Motore.Inizio.Archdir & Templ, OpenMode.Input, , OpenShare.Shared)
                    Case Codes.EU : FileOpen(ifl, Monitor.Motore.Inizio.Archdir & "\WN5\PAG5EN.FTC", OpenMode.Input, , OpenShare.Shared)
                End Select
                f.mygraphics.Clear(Color.White)
                Testo = LineInput(ifl)
                If .jmemb1 > 1 Then Testo = Trim(Testo) & " TIPO" & Str(iTipo)
                f.TracciaTesto(Testo)
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                GlobalRoutines.FormatS("|")
                Select Case CType(codice, Codes)
                    Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                        Testo = LineInput(ifl)
                        f.TracciaTesto(GlobalRoutines.FormatS(Testo, .dns * kLength, Asnell))
                    Case Codes.EU
                        Testo = LineInput(ifl)
                        f.TracciaTesto(GlobalRoutines.FormatS(Testo, .dns, Pm))
                End Select
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, .TubeMinT * kLength, psig * psi))
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, .Spess * kLength))
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, .St * kPress))
                sid1 = New String(" ", 25) : sid2 = New String(" ", 25)
                Select Case CType(codice, Codes)
                    Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                        Call SigmaIdTubi()
                        Select Case CType(codice, Codes)
                            Case Codes.div2psi
                                If sidPmInt > 0 Then sid1 = "s.id.int=" & GlobalRoutines.myStr(sidPmInt, 6, 0, False) & " psi"
                                If sidPmExt > 0 Then sid2 = "s.id.int=" & GlobalRoutines.myStr(sidPmExt, 6, 0, False) & " psi"
                            Case Codes.div2MPa
                                If sidPmInt > 0 Then sid1 = "s.id.int=" & GlobalRoutines.myStr(sidPmInt, 4, 2, False) & " MPa"
                                If sidPmExt > 0 Then sid2 = "s.id.int=" & GlobalRoutines.myStr(sidPmExt, 4, 2, False) & " MPa"
                            Case Codes.EU
                                Stop
                        End Select
                End Select
                If psig2 = 0 Then
                    Testo = LineInput(ifl)
                    f.TracciaTesto(GlobalRoutines.FormatS(Testo, sid1, psig1 * kPress))
                    Testo = LineInput(ifl) : Testo1 = GlobalRoutines.FormatS(Testo, sid2)
                    i = InStr(Testo1, "Pa1")
                    If i > 0 Then
                        Mid(Testo1, i, 22) = New String(" ", 22)
                    End If
                    f.TracciaTesto(Testo1)
                    Testo = LineInput(ifl)
                Else
                    Testo = LineInput(ifl)
                    Testo = LineInput(ifl)
                    f.TracciaTesto(GlobalRoutines.FormatS(Testo, sid1, psig1 * kPress))
                    Testo = LineInput(ifl)
                    f.TracciaTesto(GlobalRoutines.FormatS(Testo, sid2, psig2 * kPress))
                End If
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, .R0 * kLength))
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, .TubeAdopt * kLength))
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, .PressInt * kPress))
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                P0 = .PressExt
                If Not PiastradaTubi Is Nothing Then
                    If Problem(PiastradaTubi.IndProbl).PDIFF = 0 Then
                        P0 = PiastradaTubi.DiffPress
                        If P0 = 0 Then
                            P0 = System.Math.Abs(PiastradaTubi.PDesChan - PiastradaTubi.PDesShel)
                        End If
                    End If
                End If
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, P0 * kPress))
                Testo = LineInput(ifl)
                f.TracciaTesto(GlobalRoutines.FormatS(Testo, tms * kLength))
                Testo = LineInput(ifl)
                f.TracciaTesto(Testo)
                FileClose(ifl)
                If Config(0).CalcMAWP And psig > 0 And Not VerificandoPI Then
                    SalvaTubi(1)
                    For iMAWP = 1 To 4
                        MAWPtubi(iMAWP)
                    Next
                    iMAWP = 0
                    Testo = "                Risultati del calcolo MAWP " & UnitPress & "|"
                    Testo = Testo & "                ================================|"
                    Testo = Testo & "     Nuovo Freddo    Nuovo Caldo     Corr. Freddo    Corr. Caldo  |"
                    iPT = 0
                    For i = 1 To Config(3).Ninvolucri
                        If Involucr(3, i).Tipo = 6 Then iPT = i : Exit For
                    Next
                    If iPT > 0 Then PiastradaTubi = objMemb(Involucr(3, iPT).IndObject)
                    Testo = Testo & "     Mant.   Tubi    Mant.   Tubi    Mant.   Tubi    Mant.   Tubi |   "
                    If Not PiastradaTubi Is Nothing Then
                        If Problem(PiastradaTubi.IndProbl).PDIFF = 0 Then
                            Testo = Testo & "     Differenziale   Differenziale   Differenziale   Differenziale|   "
                        End If
                    End If
                    For i = 1 To 4
                        Testo = Testo & GlobalRoutines.myStr(.MAWP(i - 1) * kPress, 5 - IncrVirgola, 1 + IncrVirgola, 0) & " " & GlobalRoutines.myStr(.MAWP2(i - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    Next i
                    Testo = Testo & "|"
                    f.TracciaTesto(Monitor.Motore.Inizio.ConvertiCr(Testo))
                    SalvaTubi(2)
                End If
            End With
            If Not ContinuoAuto Then
                f.ShowDialog()
            Else
                f.Command1_Click(f.Command1, New System.EventArgs)
                'continuoauto
            End If
            If f.Risposta = "Annulla" Then
                f.Dispose()
                CalcTubi = False
                Exit Function
            End If
            f.Dispose()
            StampaTubi()
            Ris = True
            If kLato = 3 And Involucr(kLato, jInvolucr).jmemb1 > 1 Then
                savjInv = jInvolucr
                savkL = kLato
                kLato = 4
                For i = 2 To Involucr(savkL, savjInv).jmemb1
                    jInvolucr = Involucr(savkL, savjInv).IndAccopp(i - 1)
                    Ris = CalcTubi()
                    If Not Ris Then
                        CalcTubi = False
                        Exit For
                    End If
                Next
                jInvolucr = savjInv
                kLato = savkL
            End If
            CalcTubi = Ris
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        'ErrCalcT:
        '        If Err.Number = 6 Or Err.Number = 11 Then
        '        Testo = Trim(Involucr(kLato, jInvolucr).Mark) & ".|"
        '        Testo = Testo & " Mancano probabilmente dei dati|essenziali nell'input."
        '        messagebox.show(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Critical)
        '        Resume ExCalcT
        '        Else
        '            Testo = Trim(Involucr(kLato, jInvolucr).Mark) & ".|"
        '            Testo = Testo & "Errore imprevisto: " & Err.Description
        '            Testo = Testo & "|durante il calcolo o la stampa dei tubi scambiatori."
        '            messagebox.show(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Critical)
        '            Resume ExCalcT
        '        End If
    End Function
    Sub StampaTubi()
        Dim ifl1 As Short
        Dim thk, s As Single
        Dim codice As Short
        Dim strGruppo As String = ""
        Dim Elemento As String
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Involucr(kLato, jInvolucr)
            Elemento = .Mark
            If Not PrepRapp(Template, "Tubi di scambio", Elemento, FileSt, mioApert.lstRapp) Then Exit Sub
            Testatubi()
            codice = CodiceStress()
            If codice = CInt(Codes.EU) Then
                Matdim(.indice(1 - 1)).SigmaTheta(codice, , strGruppo)
                Cod = "(allowed values from: " & strGruppo & ")"
            End If
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Matdim(.indice(1 - 1)).MatStr, Cod))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .dns, .dns / inc)) 'out dia
            If .xs = 2 Then Tipo = "AW" Else If .xs = 1 Then Tipo = "MW" Else Tipo = "  "
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Spess, Tipo, .Spess / inc)) 'nom thk
            Call Assumi(ifl, TIMA)
10750:      If .xs = 2 Then prob.Printa(GlobalRoutines.FormatS(TIMA, .TubeMinT, .TubeMinT / inc, .H0)) 'min thk,toll
            P0 = .PressInt
10751:      Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, P0, P0 * psi)) 'press i
            Select Case CType(codice, Codes)
                Case Codes.EU
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Dati(4 - 4), .Dati(5 - 4))) 'press i
                Case Codes.div2MPa, Codes.div2psi
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Dati(4 - 4), .Dati(5 - 4))) 'press i
                Case Else
                    Call Assumi(ifl, TIMA, True)
            End Select
            P0 = .PressExt
            If Not PiastradaTubi Is Nothing Then
                If Problem(PiastradaTubi.IndProbl).PDIFF = 0 Then
                    P0 = PiastradaTubi.DiffPress
                    If P0 = 0 Then
                        P0 = System.Math.Abs(PiastradaTubi.PDesChan - PiastradaTubi.PDesShel)
                    End If
                End If
            End If
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, P0, P0 * psi)) 'press e
            Select Case CType(codice, Codes)
                Case Codes.EU
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Dati(6 - 4), .Dati(7 - 4))) 'press i
                Case Codes.div2MPa, Codes.div2psi
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Dati(6 - 4), .Dati(7 - 4))) 'press i
                Case Else
                    Call Assumi(ifl, TIMA, True)
            End Select
            td = TempDes()
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, td, td * 1.8 + 32)) 'des temp
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .cs, .cs / inc)) 'corr. allow.
            s = .St
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, s, s * psi)) 'allow
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .L0, .L0 / inc)) 'lungh
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .R0, .R0 / inc)) 'bend r
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .ES)) 'eff
10770:      Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .TubeAdopt, .TubeAdopt / inc)) 't1 req
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Spess, .Spess / inc)) 't adopt
            Call Assumi(ifl, TIMA)
            If .TubeMinT < .TubeAdopt Then Call NoCheck()
            prob.Printa(GlobalRoutines.FormatS(TIMA, .TubeMinT, .TubeAdopt))
            thk = .TubeMinT - .cs * CondizioniCorrose
            ' If .R0 > 0 Then
            '     Thk = Thk * (1 - .dns / 4 / .R0)
            ' End If
            Select Case CType(CodiceStress(), Codes)
                Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .dns / thk)) 'A
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .L0 / .dns)) 'B
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Asnell)) 'A
                    Call Assumi(ifl, TIMA)
                    If Len(TIR) > 0 Then prob.Printa(GlobalRoutines.FormatS(TIMA, Right(TIR, Len(TIR) - 4), psig)) 'B
                    ifl1 = FreeFile()
                    If psig2 = 0 Then
                        FileOpen(ifl1, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBIAS1.FTC", OpenMode.Input, , OpenShare.Shared)
                        Call Assumi(ifl1, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, psig1))
                    Else
                        FileOpen(ifl1, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBIAS2.FTC", OpenMode.Input, , OpenShare.Shared)
                        Call Assumi(ifl1, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, psig1))
                        Call Assumi(ifl1, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, psig2))
                        Call Assumi(ifl1, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, S10))
                        If psig1 > psig2 Then psig1 = psig2
                    End If
                    FileClose(ifl1)
                Case Codes.EU
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Stheta)) 'A
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, psig)) 'A
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Asnell, Nmin)) 'A
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Pm)) 'A
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, PrPy))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, psig1))
            End Select
            Call Assumi(ifl, TIMA)
            If psig1 < P0 Then Call NoCheck()
            prob.Printa(GlobalRoutines.FormatS(TIMA, psig1, P0))
            Select Case CType(codice, Codes)
                Case Codes.div2MPa, Codes.div2psi, Codes.EU
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, sidPmInt, .St, sidQInt, 1.5 * .St))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, sidPmExt, .St, sidQExt, 1.5 * .St))
                Case Else
                    Call Assumi(ifl, TIMA, True, True)
                    prob.Printa(TIMA)
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True, True)
            End Select
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, tms, tms / inc))
            Call Assumi(ifl, TIMA)
            If .TubeMinT < tms Then Call NoCheck()
            prob.Printa(GlobalRoutines.FormatS(TIMA, .TubeMinT, tms))
            Call Assumi(ifl, TIMA)
            If .MAWP(1 - 1) > 0 Then
                prob.Printa(GlobalRoutines.FormatS(TIMA, " "))
                'lato shell
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .MAWP(1 - 1), .MAWP(2 - 1), .MAWP(3 - 1), .MAWP(4 - 1)))
                'lato tubi
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .MAWP2(1 - 1), .MAWP2(2 - 1), .MAWP2(3 - 1), .MAWP2(4 - 1)))
                Call Assumi(ifl, TIMA)
            End If
            FileClose(ifl)
            Call MinTempTubi()
            Call StamUW20()
        End With
        Exit Sub
    End Sub
    Private Sub NoCheck()
        n = InStr(TIMA, ">")
        Mid(TIMA, n, 1) = "<"
        n = InStr(TIMA, "CHECK")
        Mid(TIMA, n - 3, 2) = "NO"
    End Sub
    Private Sub Testatubi()
        Dim Data As String = ""
        Dim TIMA As String = ""
        Dim Data1 As String = ""
        ifl = FreeFile()
        Select Case CType(CodiceStress(), Codes)
            Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBIASM.FTC", OpenMode.Input, , OpenShare.Shared)
            Case Codes.EU
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBIEUR.FTC", OpenMode.Input, , OpenShare.Shared)
        End Select
        With Monitor.Motore.Problem
10710:      Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, clsInizio.Firma))
10720:      Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, CodiceCalc))
10730:      Call Assumi(ifl, TIMA)
            .Printa(GlobalRoutines.FormatS(TIMA, Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers))
            Data = DateString
            Data1 = Data
            Mid(Data1, 1, 2) = Mid(Data, 4, 2)
            Mid(Data1, 4, 2) = Mid(Data, 1, 2)
10740:      Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, job.Comm.Arch, _
               job.Comm.Ind.Item(job.Comm.NumAs).Data.Assieme, job.Comm.Comp, Data1))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, job.Comm.Clie))
        End With
    End Sub
    Private Sub MinTempTubi()
        Dim i, iMat As Short
        Dim tgov As Single
        Dim Aspp, R As Single
        Dim jmemb As Short
        Dim cc As Short
        Dim MWDTrule As String = ""
        Dim MWDTclause As String = ""
        Dim MWDTtemp As Single
        Dim YieldMWDT As Single
        Dim PNumber As String = ""
        Dim iGr As Short
        Dim Temper(2) As Single
        '2 tubi
        If Config(0).NMWDT = 0 Then Exit Sub
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        prob.Printa("\page ")
        Testatubi()
        With Involucr(kLato, jInvolucr)
            iMat = .indice(1 - 1)
            If .ms > 3 Then jmemb = -1
            tgov = .Spess / inc : R = .dns / 2 / inc - tgov
            Aspp = .cs / inc
            cc = 0
            For i = 1 To Matdim(iMat).Caract.Count
                If Matdim(iMat).Caract.Item(i).TextData.Codice = CodiceStress() Then cc = i : Exit For
            Next
            If cc > 0 Then
                MWDTrule = Matdim(iMat).Caract.Item(cc).TextData.MWDTrule
                MWDTclause = Matdim(iMat).Caract.Item(cc).TextData.MWDTclause
                MWDTtemp = Matdim(iMat).Caract.Item(cc).TextData.MWDTtemp
                YieldMWDT = Matdim(iMat).Caract.Item(cc).TextData.Yield
                PNumber = Matdim(iMat).Caract.Item(cc).TextData.PNumber
                iGr = GlobalRoutines.ValVir(Matdim(iMat).Caract.Item(cc).TextData.Group)
            End If
            If NotApplicable(MWDTrule, StriSt) Then Exit Sub
            If InStr(MWDTrule, "UCS") Then
319:            prob.Printa(GlobalRoutines.FormatS(StriSt(5), RTrim(MWDTrule), MWDTclause))  '"Low Temperature Operation. Rules: "
            ElseIf InStr(MWDTrule, "UHA") Or InStr(MWDTrule, "UNF") Then
                prob.Printa(GlobalRoutines.FormatS(StriSt(6), RTrim(MWDTrule)))  '"xxxxxxxxxxxx"
            Else
                prob.Printa(StriSt(7))
            End If
            Temper(1) = Config(0).tdxMDMT(0) : Temper(2) = Config(0).tdxMDMT(1)
            '      Call MinTempCalc(2, (jInvolucr), R, (jmemb), Aspp, MWDTrule$, MWDTclause$, MWDTtemp!, tgov, YieldMWDT, PNumber$, iGr, " ", Temper())
            Call MinTempCalc(0, (jInvolucr), R, (jmemb), Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, " ", Temper)
        End With
        'Print #iout, "\page "
    End Sub
    Public Sub Assumi(ByRef ifl As Short, ByRef TIMA As String, Optional ByRef Skippa As Boolean = False, Optional ByRef Singolo As Boolean = False)
        Dim Cod As String
        Do
            If EOF(ifl) Then Exit Do
            TIMA = LineInput(ifl)
            If Len(RTrim(LTrim(TIMA))) = 0 Then Exit Do
            TIMA = RTrim(TIMA)
            Cod = Right(TIMA, 3)
            If Left(Cod, 1) = "F" Then
                TIMA = Left(TIMA, Len(TIMA) - 3)
                Exit Do
            ElseIf Left(Cod, 1) = "A" Then
                TIMA = Left(TIMA, Len(TIMA) - 3)
            End If
            If Not Skippa Then Monitor.Motore.Problem.Printa(TIMA)
            If Singolo Then Exit Do
        Loop
    End Sub
    Public Sub trPressExt(ByRef ang As Single, ByRef RcollCon As Single, ByRef AlunCyl As Single, ByRef tr As Single, Optional ByVal IsNozzle As Boolean = False)
        Dim ic, jRec, id As Short
        Dim Ds, DLDL, alc As Single
        Dim Indmat As Short
        Dim aLe As Single
        Dim psig, psig0, psig1, Asnell, Ro As Single
        Try
            If IsNozzle Then                          '140506
                jRec = Nozzles(kLato, kNozzle).indice     '140506
                tr = Nozzles(kLato, kNozzle).Spess        '140506
            Else                                      '140506
                jRec = Involucr(kLato, jInvolucr).indice(1 - 1)
                tr = Involucr(kLato, jInvolucr).Spess
            End If                                    '140506
            Indmat = Matdim(jRec).Indmat
            ic = 0 : id = 1 : pext = Pextdes()
800:        Do
                If ang > 0 Then
                    Call ConBuckPar(ang, DLDL, Ds, alc, aLe)
                    RaggioBocca(1) = DLDL / 2
                    RaggioBocca(2) = Ds / 2
                ElseIf ang < 0 Then
                    DLDL = 2 * RcollCon + tr 'diametro medio cil
                    aLe = AlunCyl 'lunghezza libera cil
                Else
                    If IsNozzle Then                          '140506
                        DLDL = Nozzles(kLato, kNozzle).DiIn + tr
                        aLe = Nozzles(kLato, kNozzle).LXdisp
                    Else                                      '140506
                        Select Case Involucr(kLato, jInvolucr).Tipo
                            Case 0 : DLDL = Involucr(kLato, jInvolucr).di + tr
                                aLe = Involucr(kLato, jInvolucr).L0 / (Involucr(kLato, jInvolucr).SottoTipo + 1)
                            Case 1 : HeadsBuckPar(Ro, tr)
                            Case 2, 3 : ConBuckPar(Involucr(kLato, jInvolucr).R0 * pi / 180, DLDL, Ds, alc, aLe)
                        End Select
                    End If
                End If
810:            ic = ic + 1
                If Not ang = 0 Then
                    Asnell = Matdim(jRec).Avalor(DLDL / tr, aLe / DLDL)
                Else
                    If Involucr(kLato, jInvolucr).Tipo = 1 Then
                        Asnell = 0.125 / Ro * tr
                    Else
                        If Not CType(CodiceStress(), Codes) = Codes.EU Then
                            Asnell = Matdim(jRec).Avalor(DLDL / tr, aLe / DLDL)
                        End If
                    End If
                End If
                If Not CType(CodiceStress(), Codes) = Codes.EU Then
                    If Asnell = -1 Then Asnell = 0.00001 : id = id + 1
                    If Asnell = -3 Then
                        psig = 5000 / psi
                    Else
830:                    psig = System.Math.Abs(Matdim(jRec).BValor(Asnell, Textdes, Indmat, CodiceStress, Chart, 0))
                    End If
                    If psig = 0 Then tr = 0 : Exit Sub
                End If
                If Not ang = 0 Then
                    psig1 = 4 / 3 * psig * tr / DLDL
                Else
                    If Involucr(kLato, jInvolucr).Tipo = 1 Then
                        psig1 = psig * tr / Ro
                    Else
                        If Not CType(CodiceStress(), Codes) = Codes.EU Then
                            psig1 = 4 / 3 * psig * tr / DLDL
                        Else
                            PressExtCil(DLDL, tr, Involucr(kLato, jInvolucr).L0, Textdes, jRec, psig, psig1, psig2, Chart)
                        End If
                    End If
                End If
                If psig1 = 0 Then Exit Do
                If System.Math.Abs((psig1 - pext) / pext) < clsTrigon.TOLER Or ic > 50 Then Exit Do 'Pext
                If ic > 1 And (psig1 - pext) * (psig0 - pext) < 0 Then id = id + 1 'Pext
                tr = (pext / psig1) ^ (1.0! / id) * tr 'Pext
                psig0 = psig1
            Loop
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function NotApplicable(ByRef Rule As String, ByRef StriSt() As String) As Boolean
        Dim ifl, i As Short
        NotApplicable = False
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME26.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 8
            StriSt(i) = LineInput(ifl)
            StriSt(i) = Left(StriSt(i), Len(StriSt(i)) - 1)
        Next
        FileClose(ifl)
        Select Case Left(Rule, 3)
            Case "UHA", "UCS", "UNF", "UHT", "AHA", "ACS", "ANF", "AQT"
            Case Else
                If PrimaVoltaMWDT Then
                    Monitor.Motore.Problem.Printa(StriSt(1))
                    Monitor.Motore.Problem.Printa(StriSt(8))  ' "Design in low temperature conditions (UCS-66)"
                Else
                    PrimaVoltaMWDT = False
                End If
                NotApplicable = True
                Exit Function
        End Select
        If PrimaVoltaMWDT Then
            Monitor.Motore.Problem.Printa(StriSt(1))
            Monitor.Motore.Problem.Printa(StriSt(2))  ' "Design in low temperature conditions (UCS-66)"
        Else
            PrimaVoltaMWDT = False
        End If
        '---------------------------
        ''       MWDTrule = "not defined"
        ''      Print #iout, FormatS(StriSt$(5), RTrim$(MWDTrule$), MWDTclause)             '"Low Temperature Operation. Rules: "
        ''      Exit Function
    End Function
    Private Sub StamUW20()
        Dim i, ifl As Short
        Dim File As String
        Dim Testo As String
        Dim O As wn_Tub
        Dim Car As Single
        Dim Con As Single
        Dim Norm1 As String = ""
        Dim TIMA As String = ""
        Dim Norm2 As String = ""
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Involucr(kLato, jInvolucr)
            O = objMemb(.IndObject)
            If .ms > 2 Then Exit Sub
            prob.Printa("\page ")
            i = Int(Involucr(kLato, jInvolucr).di)
            If i < 1 Or i > 4 Then
                i = 1
                Involucr(kLato, jInvolucr).di = 1
            End If
            If UltimoAggiornamento < 3 Then
                Norm1 = "UW-20"
                Select Case i
                    Case 1 : Norm2 = "UW-20(e)(1)"
                    Case 2 : Norm2 = "UW-20(e)(2)"
                    Case 3 : Norm2 = "UW-20(e)(3)"
                    Case 4 : Norm2 = "UW-20(e)(4)"
                End Select
            ElseIf UltimoAggiornamento < 4 Then
                Norm1 = "UHX-15.1"
                Select Case i
                    Case 1 : Norm2 = "UHX-15.6(a)"
                    Case 2 : Norm2 = "UHX-15.6(b)"
                    Case 3 : Norm2 = "UHX-15.6(c)"
                    Case 4 : Norm2 = "UHX-15.6(d)"
                End Select
            Else
                Norm1 = "UW-20"
                Select Case i
                    Case 1 : Norm2 = "UW-20.6(a)"
                    Case 2 : Norm2 = "UW-20.6(b)"
                    Case 3 : Norm2 = "UW-20.6(c)"
                    Case 4 : Norm2 = "UW-20.6(d)"
                End Select
            End If
            File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBIAS" & Trim(Str(i + 2)) & ".FTC"
            ifl = FreeFile()
            FileOpen(ifl, File, OpenMode.Input, , OpenShare.Shared)
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, clsInizio.Firma))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, CodiceCalc))
            Select Case CType(CodiceStress(), Codes)
                Case Codes.div1psi, Codes.div1MPa
                Case Else
                    prob.Printa("\par " & New String(" ", 30) & "{\b (FOR INFORMATION ONLY)}")
            End Select
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Norm1))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Norm1))
            If .Dati1 = 1.0# Then Testo = "FULL STRENGTH" Else Testo = "PARTIAL STRENGTH"
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Testo))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .Dati1))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .UW20Sa * mpa, .UW20Sa))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, .UW20St * mpa, .UW20St))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Sw * mpa, O.UW20Sw))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20fw))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Ftstrength, O.UW20Ftstrength / NIUT))
            If i = 4 Then
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20ag, O.UW20ag / inc))
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Fgstrength, O.UW20Fgstrength / NIUT))
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Ffratio))
            End If
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20ar, O.UW20ar / inc))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Norm2))
            Select Case i
                Case 1
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20af, O.UW20af / inc))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Ffstrength, O.UW20Ffstrength / NIUT))
                    Car = O.UW20Ffstrength
                Case 2
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20ag, O.UW20ag / inc))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Fgstrength, O.UW20Fgstrength / NIUT))
                    Car = O.UW20Fgstrength
                Case 3
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20af, O.UW20af / inc))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20ag, O.UW20ag / inc))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Ffstrength, O.UW20Ffstrength / NIUT))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Fgstrength, O.UW20Fgstrength / NIUT))
                    Car = O.UW20Ffstrength + O.UW20Fgstrength
                Case 4
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20af, O.UW20af / inc))
                    Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, O.UW20Ffstrength, O.UW20Ffstrength / NIUT))
                    Car = O.UW20Ffstrength + O.UW20Fgstrength
            End Select
            Con = .Dati1 * O.UW20Ftstrength
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Car))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Con))
            Call Assumi(ifl, TIMA)
        End With
        FileClose(ifl)
    End Sub

    Private Sub SalvaTubi(ByRef m As Short)
        If m = 1 Then
            Salva(0) = Stheta
            Salva(1) = psig
            Salva(2) = Asnell
            Salva(3) = Nmin
            Salva(4) = Pm
            Salva(5) = PrPy
            Salva(6) = psig1
        Else
            Stheta = Salva(0)
            psig = Salva(1)
            Asnell = Salva(2)
            Nmin = Salva(3)
            Pm = Salva(4)
            PrPy = Salva(5)
            psig1 = Salva(6)
        End If
    End Sub
    Private Sub SigmaIdTubi()
        Dim sint, sext As Single
        Dim rint, rext As Single
        With Involucr(kLato, jInvolucr)
            sint = .PressInt * (.dns - 2 * .Spess) / 2 / .Spess
            sext = -.PressExt * .dns / 2 / .Spess
            rint = -.PressInt / 2
            rext = -.PressExt / 2
            sidPmInt = 0 : sidPmExt = 0 : sidQInt = 0 : sidQExt = 0
            If .Dati(4 - 4) > 0 Then
                sidPmInt = System.Math.Abs(sint - .Dati(4 - 4))
                If System.Math.Abs(rint - .Dati(4 - 4)) > sidPmInt Then sidPmInt = System.Math.Abs(rint - .Dati(4 - 4))
                If System.Math.Abs(rint - sint) > sidPmInt Then sidPmInt = System.Math.Abs(rint - sint)
            End If
            If .Dati(6 - 4) > 0 Then
                sidPmExt = System.Math.Abs(sext - .Dati(6 - 4))
                If System.Math.Abs(rext - .Dati(6 - 4)) > sidPmExt Then sidPmExt = System.Math.Abs(rext - .Dati(6 - 4))
                If System.Math.Abs(rext - sext) > sidPmExt Then sidPmExt = System.Math.Abs(rext - sext)
            End If
            If .Dati(5 - 4) > 0 Then
                sidQInt = System.Math.Abs(sint - .Dati(5 - 4))
                If System.Math.Abs(rint - .Dati(5 - 4)) > sidQInt Then sidQInt = System.Math.Abs(rint - .Dati(5 - 4))
                If System.Math.Abs(rint - sint) > sidQInt Then sidQInt = System.Math.Abs(rint - sint)
            End If
            If .Dati(7 - 4) > 0 Then
                sidQExt = System.Math.Abs(sext - .Dati(7 - 4))
                If System.Math.Abs(rext - .Dati(7 - 4)) > sidQExt Then sidQExt = System.Math.Abs(rext - .Dati(7 - 4))
                If System.Math.Abs(rext - sext) > sidQExt Then sidQExt = System.Math.Abs(rext - sext)
            End If
        End With
    End Sub
End Module