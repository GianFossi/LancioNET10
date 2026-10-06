Option Strict Off
Option Explicit On
Module EuroNorm
	Public RappMax(3) As Single
	Private ey, ES, Eb As Single
	Private betaH, s, t, beta As Single
	Private rho, gamma As Single
	Private Const Tolleranza As Single = 0.001
	Private Const MaxIter As Short = 20
    Private i As Short
    Private Raggio, ej As Single
    Private tc(2) As Single
    Private ts(2) As Single
    Private E1, E2 As Single
    Private OKg As Boolean
    Private R(2) As Single
    Private Testo As String
    Private seed1, seedj As Single
    Private OKp As Boolean
    Private junk As Short
    Private Stringa(3) As String
    Public Sub EuroCylThk(ByRef P0 As Single, ByRef td As Single, ByRef T0 As Single, ByRef R As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        On Error GoTo ErrThk
        If E = 0 Then E = 1
        If SWR > 0 Then
            USStr(0) = "(7.4-2)"
            T0 = P0 * R / (s * E + P0)
            '  Ri = R - T0
        Else
            USStr(0) = "(7.4-1)"
            T0 = P0 * R / (s * E - P0)
            '  Ri = R
        End If
        Exit Sub
ErrThk: messagebox.show("EuroCylThk " & Err.Description & Str(Erl()))
    End Sub
    Public Sub TestGroupCombo(ByRef cB As System.Windows.Forms.ComboBox, ByRef lb1 As System.Windows.Forms.Label, ByRef lb2 As System.Windows.Forms.Label)
        cB.Items.Clear()
        cB.Items.Add(HelpStringa(EU_TESTINGGROUP1)) '"Testing Group 1 (z=1.00)"
        cB.Items.Add(HelpStringa(EU_TESTINGGROUP2)) '"Testing Group 2 (z=1.00)"
        cB.Items.Add(HelpStringa(EU_TESTINGGROUP3)) '"Testing Group 3 (z=0.85)"
        cB.Items.Add(HelpStringa(EU_TESTINGGROUP4)) '"Testing Group 4 (z=0.70)"
        cB.Items.Add(HelpStringa(EU_TESTINGGROUP5)) '"Unwelded part   (z=1.00)"
        With Involucr(kLato, jInvolucr)
            If .EUTestGroup < 0 Or .EUTestGroup > 4 Then .EUTestGroup = 0 : .ES = 1
            cB.SelectedIndex = .EUTestGroup
        End With
        cB.Visible = True
        lb1.Text = "Design stress in testing cond."
        lb2.Text = "Design stress in normal cond."
    End Sub
    Public Sub AggTestGroup(ByRef i As Short)
        With Involucr(kLato, jInvolucr)
            .EUTestGroup = i
            Select Case i
                Case 2 : .ES = 0.85
                Case 3 : .ES = 0.7
                Case Else : .ES = 1
            End Select
        End With
    End Sub
    Public Function Pr10p2p3p3(ByRef valido As Boolean) As Single
        Dim Pd, pHT, rapp As Single
        Dim pHT1 As Single
        Pd = PressDes() '/ psi
        pHT = 1.43 * Pd
        If RappMax(kLato) = 0 Then
            valido = False
            rapp = Involucr(kLato, jInvolucr).S0 / Involucr(kLato, jInvolucr).St
        Else
            valido = True
            rapp = RappMax(kLato)
        End If
        pHT1 = 1.25 * Pd * rapp
        If pHT1 > pHT Then pHT = pHT1
        Pr10p2p3p3 = pHT
    End Function
    Public Sub CalcRappMax()
        Dim k As Short
        Dim vMAWP As clsValoriMAWP
        RappMax(k) = 0
        If colMAWP Is Nothing Then
            'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MostraAiuto(IDH_MANCATABMAT)
            Exit Sub
        End If
        For k = 1 To Config(0).NumeroLati
            For Each vMAWP In colMAWP
                If vMAWP.k = k Then
                    If vMAWP.Sa / vMAWP.St > RappMax(k) Then RappMax(k) = vMAWP.Sa / vMAWP.St
                End If
            Next vMAWP
        Next
    End Sub
    Public Sub EUCylShellPr()
        Dim Elemento As String
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        Elemento = Trim(Involucr(kLato, jInvolucr).Mark)
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del" & vbCrLf & " rapporto sul guscio cilindrico " & Trim(Involucr(kLato, jInvolucr).Mark), "AsmeVip")
        InterrompiMAWP = False
        mioApert.Enabled = False
        With Documento
            Try
                .sOpen(clsInizio.Archdir & "\EUcylint.doc", True, 1)
                .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
                .VaiInizio("", 1)
                '------------------------------------------------------------------------
                EUCylConIntest()
                '------------------------------------------------------------------------
                If Involucr(kLato, jInvolucr).ms < 2 Then
                    If Involucr(kLato, jInvolucr).OS > 0 Then
                        .SubstitBookM("BaseDiam", Format(2 * rc, FormTemp), True, 1)
                        .EliminaRiga("CorrDiam", 1)
                    Else
                        .SubstitBookM("CorrDiam", Format(2 * rc, FormTemp), True, 1)
                        .EliminaRiga("BaseDiam", 1)
                    End If
                    .EliminaRiga("OutsDiam", 1)
                Else
                    .SubstitBookM("OutsDiam", Format(2 * Ro, FormTemp), True, 1)
                    .EliminaRiga("CorrDiam", 1)
                    .EliminaRiga("BaseDiam", 1)
                End If
                Monitor.Motore.Avanzamento = 60
                Application.DoEvents()
                EUadopted()
                Monitor.Motore.Avanzamento = 70
                Application.DoEvents()
                EUMAWPPr()
                '--------------------------------------------------------------
                .VaiInizio("", 1)
                .Copia(1)
                .sClose(, 1)
                Monitor.Motore.Avanzamento = 90
                Application.DoEvents()
                If InterrompiMAWP Then GoTo Fine
                .VaiInizio("\EndOfDoc")
                .NewCap(Elemento, False) ' da vedere se è la prima volta
                Monitor.Motore.ProgrAmmazza()
            Catch e As Exception
                MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            End Try
Fine:       .Visible = True
        End With
        mioApert.Enabled = True
    End Sub
    Public Sub EUConShellPr(ByRef ang As Single, ByRef Aspp As Single)
        Dim Testo, Testo1 As String
        Dim R As Single
        Dim Elemento As String
        Dim RP, esuDe, Rpp As Single
        Dim i1, i, i2 As Short
        Dim tc2, sp1, sp2, ts2 As Single
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        Elemento = Trim(Involucr(kLato, jInvolucr).Mark)
        On Error GoTo ErrEU
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.Visible. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto sul guscio conico " & Trim(Involucr(kLato, jInvolucr).Mark), "AsmeVip")
        InterrompiMAWP = False
        mioApert.Enabled = False
        With Documento
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.sOpen. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .sOpen(clsInizio.Archdir & "\EUconint.doc", True, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.sSaveAs. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.VaiInizio. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .VaiInizio("", 1)
            '--------------------------------------------------------------
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("STStr", STStr, True, 1)
            EUCylConIntest()
            '------------------------------------------------------------------------
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("InsDiamg", Format(Involucr(kLato, jInvolucr).di, Fors), True, 1)
            If Involucr(kLato, jInvolucr).H0 > 0 Then
                Testo = Format(Involucr(kLato, jInvolucr).H0, Fors)
            Else
                Testo = "N.A."
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("KnuRadg", Testo, True, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("InsDiamp", Format(Involucr(kLato, jInvolucr).dns, Fors), True, 1)
            If Involucr(kLato, jInvolucr).L0 > 0 Then
                Testo = Format(Involucr(kLato, jInvolucr).L0, Fors)
            Else
                Testo = "N.A."
            End If
            .SubstitBookM("KnuRadp", Testo, True, 1)
            Select Case Involucr(kLato, jInvolucr).Tipo
                Case 2 : Testo = ""
                    .EliminaRiga("CHECK12", 1)
                Case 3 : Testo = "of the equiv.cone"
                    .SubstitBookM("CHECK12", "CHECK", True, 1)
            End Select
            .SubstitBookM("aggiunta", Testo, True, 1)
            .SubstitBookM("alfa", Format(Involucr(kLato, jInvolucr).R0, Fors), True, 1)
            .SubstitBookM("Length", Format(Involucr(kLato, jInvolucr).Dati1, Fors), True, 1)
            .SubstitBookM("CHECK1", "CHECK", True, 1)
            .SubstitBookM("esuDe", Format(esuDe, Form1_2), True, 1)
            esuDe = Involucr(kLato, jInvolucr).Spess * System.Math.Cos(ang) / (2 * Involucr(kLato, jInvolucr).Spess + Involucr(kLato, jInvolucr).di)
            .SubstitBookM("CHECK11", "CHECK", True, 1)
            R = Involucr(kLato, jInvolucr).di / 2 + Aspp - Involucr(kLato, jInvolucr).H0 * (1 - System.Math.Cos(ang))
            If Involucr(kLato, jInvolucr).OS = 0 Then
                Testo1 = "on base mat'l"
            Else
                Testo1 = "corroded"
            End If
            .SubstitBookM("corroded", Testo1, True, 1)
            .SubstitBookM("CorrDiam", Format(2 * R, Fors), True, 1)
            .SubstitBookM("Equation", USStr(0), True, 1)
            .SubstitBookM("MinDesign", Format(t0s, Fors), True, 1)
            If TEMA > 0 Then
                .SubstitBookM("MinTEMA", Format(tts, Fors), True, 1)
            Else
                .EliminaRiga("MinTEMA", 1)
            End If
            .SubstitBookM("CHECK2", "CHECK")
            If Involucr(kLato, jInvolucr).H0 = 0 Then RP = 0 Else RP = Involucr(kLato, jInvolucr).H0 + Aspp
            Addition1(kLato, jInvolucr).RP = RP
            If Involucr(kLato, jInvolucr).L0 = 0 Then Rpp = 0 Else Rpp = Involucr(kLato, jInvolucr).L0
            Addition1(kLato, jInvolucr).Rpp = Rpp
            Monitor.Motore.Avanzamento = 70
            '----------------rinforzo giunzioni
            i1 = Involucr(kLato, jInvolucr).jmemb1
            If i1 > 0 Then
                sp1 = Involucr(kLato, i1).Spess
                .SubstitBookM("Dcg", Format(Involucr(kLato, jInvolucr).di + sp1, Fors), True, 1)
                .SubstitBookM("l1g", Format(AdditCono(kLato, jInvolucr).l(0, 0) / 1.4, Fors), True, 1)
                .SubstitBookM("l2g", Format(AdditCono(kLato, jInvolucr).l(0, 1) / 1.4, Fors), True, 1)
                .EliminaRiga("Large", 1)
                If Involucr(kLato, jInvolucr).L0 > 0 Then
                    .EliminaRighe("Par7p6p6", "l1min", 1)
                    .SubstitBookM("Dcg1", Format(Involucr(kLato, jInvolucr).di + sp1, Fors), True, 1)
                    .SubstitBookM("beta", Format(beta, Fors), True, 1)
                    .SubstitBookM("assumed", Format(AdditCono(kLato, jInvolucr).E1(1), Fors), True, 1)
                    .SubstitBookM("ejg", Format(AdditCono(kLato, jInvolucr).E1(1), Fors), True, 1)
                    If AdditCono(kLato, jInvolucr).l(1, 1) > 0 Or AdditCono(kLato, jInvolucr).l(0, 1) > 0 Then
                        .SubstitBookM("l2min", Format(AdditCono(kLato, jInvolucr).l(0, 1), Fors), True, 1)
                        .SubstitBookM("l1min", Format(AdditCono(kLato, jInvolucr).l(0, 0), Fors), True, 1)
                        .SubstitBookM("Spessr1", Format(AdditCono(kLato, jInvolucr).E1(0), Fors), True, 1)
                    Else
                        .EliminaRiga("l2min", 1)
                        .EliminaRiga("Spessr1", 1)
                    End If
                Else
                    .EliminaRighe("Par7p6p7", "l1min2", 1)
                    .SubstitBookM("Dcg2", Format(Involucr(kLato, jInvolucr).di + sp1, Fors), True, 1)
                    .SubstitBookM("beta2", Format(beta, Fors), True, 1)
                    .SubstitBookM("assume1", Format(AdditCono(kLato, jInvolucr).E1(1), Fors), True, 1)
                    .SubstitBookM("rho", Format(rho, Fors), True, 1)
                    .SubstitBookM("gamma", Format(gamma, Fors), True, 1)
                    .SubstitBookM("ejg2", Format(AdditCono(kLato, jInvolucr).E1(1), Fors), True, 1)
                    If AdditCono(kLato, jInvolucr).l(1, 1) > 0 Or AdditCono(kLato, jInvolucr).l(0, 1) > 0 Then
                        .SubstitBookM("l2min2", Format(AdditCono(kLato, jInvolucr).l(0, 1), Fors), True, 1)
                        .SubstitBookM("l1min2", Format(AdditCono(kLato, jInvolucr).l(0, 0), Fors), True, 1)
                        .SubstitBookM("Spessr2", Format(AdditCono(kLato, jInvolucr).E1(0), Fors), True, 1)
                    Else
                        .EliminaRiga("l2min2", 1)
                        .EliminaRiga("Spessr2", 1)
                    End If
                End If
            Else
                .EliminaRiga("Dcg", 1)
                .EliminaRiga("l1g", 1)
                .EliminaRiga("l2g", 1)
                .EliminaRighe("Par7p6p6", "l1min2", 1)
            End If
            i2 = Involucr(kLato, jInvolucr).jmemb2
            If i2 > 0 Then
                sp2 = Involucr(kLato, i2).Spess
                .SubstitBookM("Dcp", Format(Involucr(kLato, jInvolucr).dns + sp2, Fors), True, 1)
                .SubstitBookM("l1p", Format(AdditCono(kLato, jInvolucr).l(1, 0), Fors), True, 1)
                .SubstitBookM("l2p", Format(AdditCono(kLato, jInvolucr).l(1, 1), Fors), True, 1)
                .EliminaRiga("Small", 1)
                .SubstitBookM("Dcp1", Format(Involucr(kLato, jInvolucr).dns + sp2, Fors), True, 1)
                .SubstitBookM("e1", Format(AdditCono(kLato, jInvolucr).Spess(1), Fors), True, 1)
                .SubstitBookM("esse", Format(s, Fors), True, 1)
                If s < 1 Then Testo = "(7.6-23)" Else Testo = "(7.6-24)"
                .SubstitBookM("t", Format(t, Fors), True, 1)
                .SubstitBookM("equatt", Testo, True, 1)
                .SubstitBookM("betaH", Format(betaH, Fors), True, 1)
                tc2 = Involucr(kLato, i2).Spess
                If AdditCono(kLato, jInvolucr).l(1, 0) > 0 Then
                    tc2 = AdditCono(kLato, jInvolucr).Sploc(1, 0)
                    ts2 = AdditCono(kLato, jInvolucr).Sploc(1, 1)
                    .SubstitBookM("Spesse1", Format(tc2, Fors), True, 1)
                    .SubstitBookM("Spesse2", Format(ts2, Fors), True, 1)
                    .SubstitBookM("l2min3", Format(AdditCono(kLato, jInvolucr).l(1, 1), Fors), True, 1)
                    .SubstitBookM("l1min3", Format(AdditCono(kLato, jInvolucr).l(1, 0), Fors), True, 1)
                Else
                    .EliminaRiga("Spesse1", 1)
                    .EliminaRiga("Spesse2", 1)
                    .EliminaRiga("l1min3", 1)
                End If
            Else
                .EliminaRiga("Dcp", 1)
                .EliminaRiga("l1p", 1)
                .EliminaRiga("l2p", 1)
                .EliminaRighe("Par7p6p8", "l1min3", 1)
            End If
            EUMAWPPr()
            '--------------------------------------------------------------
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            Monitor.Motore.Avanzamento = 90
            If InterrompiMAWP Then GoTo Fine
            .VaiInizio("\EndOfDoc")
            .NewCap(Elemento, False) ' da vedere se è la prima volta
            Monitor.Motore.ProgrAmmazza()
            .Visible = True
        End With
        mioApert.Enabled = True
        Exit Sub
Fine:
        Exit Sub
ErrEU:
        'Stop
        'Resume
    End Sub
    Sub EUConThk(ByRef T0 As Single, ByRef R As Single, ByRef ang As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        If SWR > 0 Then
            USStr(0) = "(7.6-3)"
            T0 = P0 * R / (s * E + 0.5 * P0) / System.Math.Cos(ang)
        Else
            USStr(0) = "(7.6-2)"
            T0 = P0 * R / (s * E - 0.5 * P0) / System.Math.Cos(ang)
        End If
    End Sub
    Public Function EURinfCon(ByRef Aspp As Single, ByRef ang As Single, ByRef f As Single, ByRef iMAWP As Short) As Boolean
        If iMAWP = 0 Then
            E1 = AdditCono(kLato, jInvolucr).E1(0)
            ej = AdditCono(kLato, jInvolucr).E1(1)
        Else
            E1 = AdditCono(kLato, jInvolucr).EM(0)
            ej = AdditCono(kLato, jInvolucr).EM(1)
        End If
        For i = 1 To 2 ' lato grande | lato piccolo
            tc(i) = Involucr(kLato, jInvolucr).Spess - Aspp
            If AdditCono(kLato, jInvolucr).l(i - 1, 1) > 0 Then tc(i) = AdditCono(kLato, jInvolucr).Sploc(i - 1, 1) - Aspp
            ts(i) = AdditCono(kLato, jInvolucr).Spess(i) - Aspp
            If AdditCono(kLato, jInvolucr).l(i - 1, 0) > 0 Then ts(i) = AdditCono(kLato, jInvolucr).Sploc(i - 1, 0) - Aspp
            seed1 = E1 : If seed1 <= 0 Then seed1 = ts(i)
            seedj = ej : If seedj <= 0 Then seedj = ts(i)
            If i = 1 Then
                If Involucr(kLato, jInvolucr).jmemb1 > 0 Then
                    Raggio = Involucr(kLato, jInvolucr).H0
                    R(i) = Involucr(kLato, jInvolucr).di / 2 + (tc(i) + Aspp) / 2 - Raggio * (1 - System.Math.Cos(ang)) - AdditCono(kLato, jInvolucr).l(0, 1) * System.Math.Sin(ang) / 2 / 1.4
                    If Raggio = 0 Then
                        ej = Par7p6p6p2(2 * R(i), ang, f, seedj)
                    Else
                        ej = Par7p6p7p2(2 * R(i), ang, f, seedj, Raggio)
                    End If
                    OKg = ej > ts(i) And ej > tc(i)
                End If
            Else
                If Involucr(kLato, jInvolucr).jmemb2 > 0 Then
                    Raggio = Involucr(kLato, jInvolucr).L0
                    R(i) = Involucr(kLato, jInvolucr).dns / 2 + (tc(i) + Aspp) / 2 + Raggio * (1 - System.Math.Cos(ang))
                    s = tc(i) / ts(i)
                    'ATTENZIONE
                    E1 = Par7p6p8p2(2 * R(i), ang, f, seed1, Involucr(kLato, jInvolucr).ES, s)
                    E2 = s * E1
                    OKp = E1 > ts(i) And E2 > tc(i)
                End If
            End If
        Next i
        If iMAWP = 0 Then
            AdditCono(kLato, jInvolucr).E1(0) = E1
            AdditCono(kLato, jInvolucr).E1(1) = ej
        Else
            AdditCono(kLato, jInvolucr).EM(0) = E1
            AdditCono(kLato, jInvolucr).EM(1) = ej
            Exit Function
        End If
        If OKg And OKp Then
            With AdditCono(kLato, jInvolucr)
                If .l(0, 0) = 0 And .l(0, 1) = 0 And .l(1, 0) = 0 And .l(1, 1) = 0 Then Exit Function
            End With
            NonUniforme(Aspp)
            Exit Function
        End If
        Testo = "Giunzione lato grande : spessore minimo del cilindro = " & Format(ej, Fors) & " mm; "
        If ej > ts(1) Then
            Testo = Testo & "OK" & vbCrLf
        Else
            Testo = Testo & vbCrLf & "    lo spessore netto assunto " & Format(ts(1), Fors) & " mm del cilindro è insufficiente." & vbCrLf
        End If
        Testo = CStr(Testo = "Giunzione lato grande : spessore minimo del cono     = " & Format(ej, Fors) & " mm; ")
        If ej > tc(1) Then
            Testo = Testo & "OK" & vbCrLf
        Else
            Testo = Testo & vbCrLf & "    lo spessore netto assunto " & Format(tc(1), Fors) & " mm del cono è insufficiente." & vbCrLf
        End If
        Testo = CStr(Testo = "Giunzione lato piccolo: spessore minimo del cilindro = " & Format(E1, Fors) & " mm; ")
        If E1 > ts(2) Then
            Testo = Testo & "OK" & vbCrLf
        Else
            Testo = Testo & vbCrLf & "    lo spessore netto assunto " & Format(ts(2), Fors) & " mm del cilindro è insufficiente." & vbCrLf
        End If
        Testo = CStr(Testo = "Giunzione lato piccolo: spessore minimo del cono     = " & Format(E2, Fors) & " mm; ")
        If E2 > tc(2) Then
            Testo = Testo & "OK" & vbCrLf
        Else
            Testo = Testo & vbCrLf & "    lo spessore netto assunto " & Format(tc(2), Fors) & " mm del cono è insufficiente." & vbCrLf
        End If
        Testo = Testo & vbCrLf & "Cosa vuoi fare?"
        Stringa(1) = "Confermare gli spessori assunti"
        Stringa(2) = "Aumentare automaticamente gli spessori del cono e dei cilindri"
        Stringa(3) = "Rinforzare solo una lunghezza minima contigua alla giunzione"
        junk = Monitor.Motore.Quale(3, "Reinforcement of junctions", Stringa, "", 1, Testo)
        Select Case junk
            Case 1
            Case 2
                Uniforme(Aspp)
            Case 3
                With AdditCono(kLato, jInvolucr)
                    If ej > ts(1) Then
                        .l(0, 0) = -Int(-1.4 * System.Math.Sqrt(2 * R(1) * ej))
                        .Sploc(0, 0) = -Int(-ej - Aspp)
                    End If
                    If ej > tc(1) Then
                        .l(0, 1) = -Int(-1.4 * System.Math.Sqrt(2 * R(1) * ej / System.Math.Cos(ang)))
                        .Sploc(0, 1) = -Int(-ej - Aspp)
                    End If
                    If E1 > ts(2) Then
                        .l(1, 0) = -Int(-System.Math.Sqrt(2 * R(2) * E1))
                        .Sploc(1, 0) = -Int(-E1 - Aspp)
                    End If
                    If E2 > tc(2) Then
                        .l(1, 1) = -Int(-System.Math.Sqrt(2 * R(2) * E2))
                        .Sploc(1, 1) = -Int(-E2 - Aspp)
                    End If
                End With
                NonUniforme(Aspp)
        End Select
        Exit Function
    End Function
    Private Sub Uniforme(ByVal Aspp As Single)
        AdditCono(kLato, jInvolucr).l(0, 0) = 0
        AdditCono(kLato, jInvolucr).l(0, 1) = 0
        AdditCono(kLato, jInvolucr).l(1, 0) = 0
        AdditCono(kLato, jInvolucr).l(1, 1) = 0
        If ej > ts(1) Then
            Involucr(kLato, Involucr(kLato, jInvolucr).jmemb1).Spess = -Int(-ej - Aspp)
        End If
        If ej > tc(1) Then
            Involucr(kLato, jInvolucr).Spess = -Int(-ej - Aspp)
        End If
        If E1 > ts(2) Then
            Involucr(kLato, Involucr(kLato, jInvolucr).jmemb2).Spess = -Int(-E1 - Aspp)
        End If
        If E2 > tc(2) Then
            Involucr(kLato, jInvolucr).Spess = -Int(-E2 - Aspp)
        End If
    End Sub
    Private Sub NonUniforme(ByVal Aspp As Single)
        With AdditCono(kLato, jInvolucr)
            Testo = "Cono di spessore base " & Format(Involucr(kLato, jInvolucr).Spess, Fors) & " mm" & vbCrLf
            If .l(0, 1) > 0 Then
                Testo = Testo & "   Lunghezza rinforzo lato grande :" & Format(.l(0, 1), Fors) & ", sp.:" & Format(.Sploc(0, 1), Fors) & vbCrLf
            Else
                Testo = Testo & "   Nessun rinforzo lato grande" & vbCrLf
            End If
            If .l(1, 1) > 0 Then
                Testo = Testo & "   Lunghezza rinforzo lato piccolo:" & Format(.l(1, 1), Fors) & ", sp.:" & Format(.Sploc(1, 1), Fors) & vbCrLf
            Else
                Testo = Testo & "   Nessun rinforzo lato piccolo" & vbCrLf
            End If
            Testo = Testo & "Cilindro lato grande  di spessore base " & Format(Involucr(kLato, Involucr(kLato, jInvolucr).jmemb1).Spess, Fors) & " mm" & vbCrLf
            If .l(0, 0) > 0 Then
                Testo = Testo & "   Lunghezza rinforzo             :" & Format(.l(0, 0), Fors) & ", sp.:" & Format(.Sploc(0, 0), Fors) & vbCrLf
            Else
                Testo = Testo & "   Nessun rinforzo"
            End If
            Testo = Testo & "Cilindro lato piccolo di spessore base " & Format(Involucr(kLato, Involucr(kLato, jInvolucr).jmemb2).Spess, Fors) & " mm" & vbCrLf
            If .l(0, 1) > 0 Then
                Testo = Testo & "   Lunghezza rinforzo             :" & Format(.l(0, 1), Fors) & ", sp.:" & Format(.Sploc(0, 1), Fors)
            Else
                Testo = Testo & "   Nessun rinforzo"
            End If
        End With
        Testo = Testo & vbCrLf & "Cosa vuoi fare?"
        Stringa(1) = "Confermare le scelte effettuate"
        Stringa(2) = "Eliminare i rinforzi e aumentare automaticamente gli spessori"
        junk = Monitor.Motore.Quale(2, "Reinforcement of junctions", Stringa, "", 1, Testo)
        Select Case junk
            Case 1
            Case 2
                Uniforme(Aspp)
        End Select

    End Sub
    Private Function Par7p6p6p2(ByRef DC As Single, ByRef ang As Single, ByRef f As Single, ByRef ts As Single) As Single
        Dim ejv, ej, Errore As Single
        Dim i As Short
        ejv = ts
        Do
            beta = System.Math.Sqrt(DC / ejv) / 3 * System.Math.Tan(ang) / (1 + 1 / System.Math.Sqrt(System.Math.Cos(ang))) - 0.15
            If beta < 0 Then beta = 0
            ej = P0 / 2 / f * DC * beta
            Errore = 2 * System.Math.Abs((ejv - ej) / (ejv + ej))
            i = i + 1
            ejv = ej
        Loop Until Errore < Tolleranza And i < MaxIter
        Par7p6p6p2 = ej
    End Function
    Private Function Par7p6p7p2(ByRef DC As Single, ByRef ang As Single, ByRef f As Single, ByRef ts As Single, ByRef R As Single) As Single
        Dim ejv, ej, Errore As Single
        Dim i As Short
        ejv = ts
        Do
            beta = System.Math.Sqrt(DC / ejv) / 3 * System.Math.Tan(ang) / (1 + 1 / System.Math.Sqrt(System.Math.Cos(ang))) - 0.15
            If beta < 0 Then beta = 0
            rho = 0.028 * R / System.Math.Sqrt(DC * ejv) * ang / (1 + 1 / System.Math.Sqrt(System.Math.Cos(ang)))
            gamma = 1 + rho / 1.2 / (1 + 0.2 / rho)
            ej = P0 / 2 / f * DC * beta / gamma
            Errore = 2 * System.Math.Abs((ejv - ej) / (ejv + ej))
            i = i + 1
            ejv = ej
        Loop Until Errore < Tolleranza And i < MaxIter
        Par7p6p7p2 = ej
    End Function
    Public Function Par7p6p8p2(ByRef DC As Single, ByRef ang As Single, ByRef f As Single, ByRef ts As Single, ByRef Z As Single, ByRef s As Single) As Single
        Dim E1, e1v As Single
        Dim i As Short
        Dim Errore As Single
        If s < 1 Then
            t = s * System.Math.Sqrt(s / System.Math.Cos(ang)) + System.Math.Sqrt((1 + s ^ 2) / 2)
        Else
            t = 1 + System.Math.Sqrt(s * (1 + s ^ 2) / 2 / System.Math.Cos(ang))
        End If
        e1v = ts
        Do
            betaH = 0.4 * System.Math.Sqrt(DC / e1v) * System.Math.Tan(ang) / t + 0.5
            E1 = P0 / (2 * f * Z) * DC * betaH
            Errore = 2 * System.Math.Abs((e1v - E1) / (e1v + E1))
            i = i + 1
            e1v = E1
        Loop Until Errore < Tolleranza And i < MaxIter
        Par7p6p8p2 = E1
    End Function
    Public Sub EUJunctPres(ByRef iMAWP As Short, ByRef ang As Single, ByRef Aspp As Single)
        Dim k As Short
        Dim ts, P0sav, tc As Single
        Dim Scyl, emin, tJunct, R As Single
        Dim i As Short
122:    For k = 1 To 2
            If (k = 1 And Involucr(kLato, jInvolucr).jmemb1 = -1) Or (k = 2 And Involucr(kLato, jInvolucr).jmemb2 = -1) Then GoTo Skippa
            If iMAWP = 1 Or iMAWP = 3 Then
130:            Scyl = AdditCono(kLato, jInvolucr).S0(k - 1)
            ElseIf iMAWP = -1 Then
                Scyl = AdditCono(kLato, jInvolucr).Shydr(k - 1)
            Else
                Scyl = AdditCono(kLato, jInvolucr).St(k - 1)
            End If
            If iMAWP < 3 Then
                tc = Involucr(kLato, jInvolucr).Spess - Involucr(kLato, jInvolucr).OS
                ts = AdditCono(kLato, jInvolucr).Spess(k - 1) - Involucr(kLato, jInvolucr).OS
                If k = 1 Then R = Involucr(kLato, jInvolucr).di / 2 + Involucr(kLato, jInvolucr).OS - Involucr(kLato, jInvolucr).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jInvolucr).dns / 2 + Involucr(kLato, jInvolucr).OS + Involucr(kLato, jInvolucr).L0 * (1 - System.Math.Cos(ang))
            Else
                tc = Involucr(kLato, jInvolucr).Spess - Involucr(kLato, jInvolucr).OS - Involucr(kLato, jInvolucr).cs * CondizioniCorrose
                ts = AdditCono(kLato, jInvolucr).Spess(k - 1) - Involucr(kLato, jInvolucr).OS - Involucr(kLato, jInvolucr).cs * CondizioniCorrose
140:            If k = 1 Then R = Involucr(kLato, jInvolucr).di / 2 + Aspp - Involucr(kLato, jInvolucr).H0 * (1 - System.Math.Cos(ang)) Else R = Involucr(kLato, jInvolucr).dns / 2 + Aspp + Involucr(kLato, jInvolucr).L0 * (1 - System.Math.Cos(ang))
            End If
            tJunct = tc : If ts > tc Then tJunct = ts
            P0sav = P0
            Do
                '             eff = AdditCono(kLato, jInvolucr).eff(k)
                EURinfCon(Aspp, ang, Scyl, iMAWP)
                emin = AdditCono(kLato, jInvolucr).E1(k - 1)
                If System.Math.Abs(emin - tJunct) / emin < Tolleranza Then Exit Do
                i = i + 1
                If i > MaxIter Then Exit Do
                P0 = P0 * tJunct / emin
            Loop
            If iMAWP > 0 Then
160:            If P0 < Involucr(kLato, jInvolucr).MAWP(iMAWP - 1) Then
                    Involucr(kLato, jInvolucr).MAWP(iMAWP - 1) = P0
                    AdditCono(kLato, jInvolucr).Contr(iMAWP - 1) = 2 + k
                End If
            Else
165:            If P0 < pHImax Then
                    pHImax = P0
                    '      AdditCono(kLato, jInvolucr).Contr(iMAWP) = 2 + k
                End If
            End If
            P0 = P0sav
Skippa: Next k

    End Sub

    Public Sub EUInformaPI(ByRef valido As Boolean)
        Dim Testo As String
        If Config(kLato).pxTest < pHImin Then Config(kLato).pxTest = pHImin
        Testo = "Minimum test pressure (10.3.3.2):" & Format(pHImin, FormMpa) & " MPa" & vbCrLf
        Testo = Testo & "Max allowable test pressure:     " & Format(pHImax, FormMpa) & " MPa" & vbCrLf
        Testo = Testo & "Adopted test pressure:           " & Format(Config(kLato).pxTest, FormMpa) & " MPa" & vbCrLf
        If Not valido Then Testo = Testo & vbCrLf & "(il primo valore potrebbe essere inesatto)"
        MessageBox.Show(Testo, "Hydraulic test")

    End Sub

    Public Sub EUCylConIntest()
        Dim pHydr As Single
        Dim Testo As String
        With Documento
            .SubstitBookM("Azienda", clsInizio.Firma, True, 1)
            .SubstitBookM("ProgName", Monitor.Motore.About.ProgName, True, 1)
            .SubstitBookM("PgVe", Monitor.Motore.About.ProgVers, True, 1)
            .SubstitBookM("PgDate", Monitor.Motore.About.ProgDate, True, 1)
            .SubstitBookM("ConstrCode", CodiceCalc, True, 1)
            Monitor.Motore.Avanzamento = 10
            .SubstitBookM("LoadCase", "Design", True, 1)
            .SubstitBookM("DesPress", Format(PressDes() / psi, FormMpa), True, 1)
            .SubstitBookM("DistTop", Format(Involucr(kLato, jInvolucr).HydrDepth, Fors), True, 1)
            .SubstitBookM("RelDens", Format(Involucr(kLato, jInvolucr).DensFluido, FormMpa), True, 1)
            AggiustaHydr(kLato, jInvolucr, 0, pHydr, VerificandoPI)
            .SubstitBookM("PressDet", Format(pHydr / psi, FormMpa), True, 1)
            Monitor.Motore.Avanzamento = 20
            If Config(kLato).ms >= 2 Then
                .SubstitBookM("NomSize", Format(Config(kLato).dns, Fors), True, 1)
                .SubstitBookM("OutDiam", Format(Config(kLato).dogg, Fors), True, 1)
                .EliminaRiga("InsDiam", 1)
            Else
                .SubstitBookM("InsDiam", Format(Config(kLato).di, Fors), True, 1)
                .EliminaRiga("NomSize", 1)
                .EliminaRiga("OutDiam", 1)
            End If
            .SubstitBookM("TempCalc", Format((TempDes() - 32) / 1.8, Fors), True, 1)
            Monitor.Motore.Avanzamento = 30
            Select Case Config(kLato).NMWDT
                Case 0
                    .EliminaRiga("MDMT", 1)
                    .EliminaRiga("pMDMT", 1)
                    .EliminaRiga("MDMT2", 1)
                    .EliminaRiga("pMDMT2", 1)
                Case 1
                    .SubstitBookM("MDMT", Format(Config(kLato).tdxMDMT(0), Fors), True, 1)
                    .SubstitBookM("pMDMT", Format(Config(kLato).pdxMDMT(0), FormMpa), True, 1)
                    .EliminaRiga("MDMT2", 1)
                    .EliminaRiga("pMDMT2", 1)
                Case 2
                    .SubstitBookM("MDMT", Format(Config(kLato).tdxMDMT(0), Fors), True, 1)
                    .SubstitBookM("pMDMT", Format(Config(kLato).pdxMDMT(0), FormMpa), True, 1)
                    .SubstitBookM("MDMT2", Format(Config(kLato).tdxMDMT(1), Fors), True, 1)
                    .SubstitBookM("pMDMT2", Format(Config(kLato).pdxMDMT(1), FormMpa), True, 1)
            End Select
            Monitor.Motore.Avanzamento = 40
            .SubstitBookM("Identif", Involucr(kLato, jInvolucr).Mark, True, 1)
            .SubstitBookM("TestingGroup", Helpstringa(EU_TESTINGGROUP1 + Involucr(kLato, jInvolucr).EUTestGroup), True, 1)
            .SubstitBookM("Material", Involucr(kLato, jInvolucr).MATE, True, 1)
            Testo = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).EUMatGroup
            .SubstitBookM("MatGroup", Testo, True, 1)
            .SubstitBookM("AllowDes", Format(Involucr(kLato, jInvolucr).St, FormMpa), True, 1)
            .SubstitBookM("AllowHI", Format(Involucr(kLato, jInvolucr).Shydr, FormMpa), True, 1)
            If Involucr(kLato, jInvolucr).Tipo = 1 Then
                If Involucr(kLato, jInvolucr).ms < 7 Then
                    .SubstitBookM("Allowfb", Format(Involucr(kLato, jInvolucr).Dati(4 - 4), FormMpa), True, 1)
                    If Left(Testo, 1) = "8" Then
                        If Involucr(kLato, jInvolucr).Dati(5 - 4) = 1 Then
                            .SubstitBookM("method", "cold worked", True, 1)
                        Else
                            .SubstitBookM("method", "hot worked", True, 1)
                        End If
                    Else
                        .EliminaRiga("method", 1)
                    End If
                Else
                    .EliminaRiga("Allowfb", 1)
                    .EliminaRiga("method", 1)
                End If
            End If
            .SubstitBookM("JointEff", Format(Involucr(kLato, jInvolucr).ES, Form1_2), True, 1)
            .SubstitBookM("Corrosion", Format(Involucr(kLato, jInvolucr).cs, Form1_2), True, 1)
            Monitor.Motore.Avanzamento = 50
        End With
    End Sub
    Public Sub EUCylVacuumPr()
        mioApert.Enabled = False
        With Documento
            Try
                .Visible = False
                .sOpen(clsInizio.Archdir & "\EUcylVacuum.doc", True, 1)
                .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
                .VaiInizio("", 1)
                '---------------------------------
                '---------------------------------
                .VaiInizio("", 1)
                .Copia(1)
                .sClose(, 1)
                .VaiInizio("\EndOfDoc")
                .sPaste1()
            Catch e As Exception
                MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            End Try
            .Visible = True
        End With
        mioApert.Enabled = True
    End Sub
    Public Sub EUMAWPPr()
        With Documento
            .SubstitBookM("MAWP1", Format(Involucr(kLato, jInvolucr).MAWP(1 - 1), FormMpa), True, 1)
            .SubstitBookM("MAWP2", Format(Involucr(kLato, jInvolucr).MAWP(2 - 1), FormMpa), True, 1)
            .SubstitBookM("MAWP3", Format(Involucr(kLato, jInvolucr).MAWP(3 - 1), FormMpa), True, 1)
            .SubstitBookM("MAWP4", Format(Involucr(kLato, jInvolucr).MAWP(4 - 1), FormMpa), True, 1)
            .SubstitBookM("pPImin", Format(pHImin, FormMpa), True, 1)
            .SubstitBookM("pPImax", Format(pHImax, FormMpa), True, 1)
            .SubstitBookM("PIpress", Format(Config(kLato).pxExt, FormMpa), True, 1)
            .SubstitBookM("CHECK3", "CHECK", True, 1)
            Monitor.Motore.Avanzamento = 80
        End With
    End Sub
    Public Sub EUHeadThk(ByRef s As Single, ByRef fb As Single, ByRef Z As Single, ByRef LC As Single, ByRef E As Single, ByRef kt As Single)
        Select Case Involucr(kLato, jInvolucr).ms
            Case 7, 8 : Call EUSfera(s, Z, LC, E)
            Case 3, 4, 5, 6 : Call EUToro(s, fb, Z, kt, LC, E)
            Case 1, 2 : Call EUEllitt(s, fb, Z, E)
        End Select
    End Sub
    Sub EUSfera(ByRef SH As Single, ByRef E As Single, ByRef LC As Single, ByRef t0h As Single)
        Select Case Involucr(kLato, jInvolucr).ms
            Case 8
                uh = "12.5.1"
                t0h = 5 / 6 * P0 * LC / SH
            Case Else
                uh = "7.4.3"
                t0h = P0 * LC / (2 * SH * E - 0.5 * P0)
        End Select
        USStr(0) = uh
    End Sub
    Sub EUHeadPress(ByRef Press As Single, ByRef SH As Single, ByRef fb As Single, ByRef E As Single, ByRef LC As Single, ByRef t0h As Single, ByRef kt As Single)
        Select Case Involucr(kLato, jInvolucr).ms
            Case 7, 8 : Call EUSferaINV(Press, SH, E, LC, t0h)
            Case 3, 4, 5, 6 : Press = EUToroINV(SH, fb, E, kt, LC, t0h)
            Case 1, 2 : Press = EUEllittINV(SH, fb, E, t0h)
        End Select
    End Sub
    Sub EUSferaINV(ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef LC As Single, ByRef t0h As Single)
        If Involucr(kLato, jInvolucr).Tipo < 8 Then
            Press = 2 * SH * E * t0h / (LC - 0.5 * t0h)
        Else
            Press = 6 / 5 * t0h * SH / LC
            'Stop
        End If
    End Sub
    Public Sub EUToro(ByRef f As Single, ByRef fb As Single, ByRef Z As Single, ByRef kt As Single, ByRef Rgran As Single, ByRef E As Single)
        Dim ey, ES, Eb As Single
        Dim di, Rpicc As Single
        Dim eass, beta, Errore As Single
        Dim ic As Short
        Dim efin As Single
        di = Involucr(kLato, jInvolucr).di + 2 * AH
        Rpicc = Rgran / kt
        ES = P0 * Rgran / (2 * f * Z - 0.5 * P0)
        eass = Involucr(kLato, jInvolucr).Spess
        If eass = 0 Then eass = ES
        Do
            beta = fbeta(Rgran, Rpicc, di, eass)
            ey = beta * P0 * (0.75 * Rgran + 0.2 * di) / f
            Errore = System.Math.Abs(eass - ey) / eass
            If Errore < Tolleranza Then Exit Do
            If ic > MaxIter Then Exit Do
            ic = ic + 1
            eass = ey
        Loop
        Eb = (0.75 * Rgran + 0.2 * di) * (P0 / 111 / psi / fb * (di / Rpicc) ^ 0.825) ^ (1 / 1.5)
        efin = ES
        If ey > efin Then efin = ey
        If Eb > efin Then efin = Eb
        E = efin
    End Sub
    Public Function fbeta(ByRef RG As Single, ByRef RP As Single, ByRef di As Single, ByRef E As Single) As Single
        Dim x, y, n, Z As Single
        Dim b01, b006, b02 As Single
        y = E / RG : If y > 0.04 Then y = 0.04
        Z = System.Math.Log10(1 / y)
        x = RP / di
        n = 1.006 - 1.0# / (6.2 + (90 * y) ^ 4)
        b01 = n * (-0.1833 * Z ^ 3 + 1.0383 * Z ^ 2 - 1.2943 * Z + 0.837)
        If x >= 0.06 And x < 0.1 Then
            b006 = n * (-0.3635 * Z ^ 3 + 2.2124 * Z ^ 2 - 3.2937 * Z + 1.8873)
            fbeta = 25 * ((0.1 - x) * b006 + (x - 0.06) * b01)
        ElseIf x >= 0.1 And x <= 0.2 Then
            b02 = 0.95 * (0.56 - 1.94 * y - 82.5 * y * y)
            If b02 > 0.5 Then b02 = 0.05
            fbeta = 10 * ((0.2 - x) * b01 + (x - 0.1) * b02)
        Else
        End If
    End Function
    Public Function EUToroINV(ByRef f As Single, ByRef fb As Single, ByRef Z As Single, ByRef kt As Single, ByRef Rgran As Single, ByRef T0 As Single) As Single
        Dim Rpicc, di, Presss As Single
        Dim Pressb, Pressf, Pressy As Single
        di = Involucr(kLato, jInvolucr).di + 2 * AH
        Rpicc = Rgran / kt
        Presss = 2 * f * Z * T0 / (Rgran + 0.5 * T0)
        Pressy = f * T0 / fbeta(Rgran, Rpicc, di, T0) / (0.75 * Rgran + 0.2 * di)
        Pressb = 111 * fb * (T0 / (0.75 * Rgran + 0.2 * di)) ^ 1.5 * (Rpicc / di) ^ 0.825
        Pressf = Presss
        If Pressy < Pressf Then Pressf = Pressy
        If Pressb < Pressf Then Pressf = Pressb
        EUToroINV = Pressf
    End Function
    Public Sub EUEllitt(ByRef SH As Single, ByRef fb As Single, ByRef E As Single, ByRef t0h As Single)
        Dim H, di, k As Single
        Dim Rgran, kt As Single
        di = Involucr(kLato, jInvolucr).di + 2 * AH
        H = Involucr(kLato, jInvolucr).H0 + AH
        k = di / 2 / H
        Rgran = di * (0.44 * k + 0.02)
        kt = (0.44 * k + 0.02) / (0.5 / k - 0.08)
        EUToro(SH, fb, E, kt, Rgran, t0h)
    End Sub
    Public Function EUEllittINV(ByRef f As Single, ByRef fb As Single, ByRef Z As Single, ByRef T0 As Single) As Single
        Dim H, di, k As Single
        Dim Rgran, kt As Single
        di = Involucr(kLato, jInvolucr).di + 2 * AH
        H = Involucr(kLato, jInvolucr).H0 + AH
        k = di / 2 / H
        Rgran = di * (0.44 * k + 0.02)
        kt = (0.44 * k + 0.02) / (0.5 / k - 0.08)
        EUEllittINV = EUToroINV(f, fb, Z, kt, Rgran, T0)
    End Function

    Public Function EUfb(ByRef td As Single) As Single
        Dim m As LibMat.MaterialeNew1
        Dim fb As Single
        Dim Sfa, Sfo As Single
        m = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1))
        m.YieldTemp(8, td, Sfa, Sfo)
        fb = Sfo / 1.5
        If Left(m.EUMatGroup, 1) = "8" And Involucr(kLato, jInvolucr).Dati(5 - 4) = 1 Then fb = fb * 1.6
        EUfb = fb
    End Function
    Public Sub EUHeadsPr(ByRef Aspp As Single)
        Dim corroded, equiv As String
        Dim Elemento As String
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        Elemento = Trim(Involucr(kLato, jInvolucr).Mark)
        Try
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto sul guscio conico " & Trim(Involucr(kLato, jInvolucr).Mark), "AsmeVip")
            InterrompiMAWP = False
            mioApert.Enabled = False
            With Documento
                .sOpen(clsInizio.Archdir & "\EUsfeint.doc", True, 1)
                .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
                .VaiInizio("", 1)
                '--------------------------------------------------------------
                .SubstitBookM("STStr", HTStr, True, 1)
                EUCylConIntest()
                '------------------------------------------------------------------------
                .SubstitBookM("Outsdiam", Format(Involucr(kLato, jInvolucr).di, Fors), True, 1)
                If Involucr(kLato, jInvolucr).OS = 0 Then corroded = "corroded condition" Else corroded = "on base material"
                .SubstitBookM("corroded", corroded, True, 1)
                .SubstitBookM("Depth", Format(Involucr(kLato, jInvolucr).H0, Fors), True, 1)
                .SubstitBookM("corrode3", corroded, True, 1)
                If Involucr(kLato, jInvolucr).ms < 3 Then
                    .SubstitBookM("Term11", Format(Involucr(kLato, jInvolucr).di / Involucr(kLato, jInvolucr).H0, Form1_2), True, 1)
                    .SubstitBookM("CHECK21", "CHECK", True, 1)
                    equiv = "Equivalent"
                Else
                    .EliminaRighe("Par7p5p4", "CHECK21", 1)
                    equiv = ""
                End If
                .SubstitBookM("Equiv1", equiv, True, 1)
                .SubstitBookM("Equiv2", equiv, True, 1)
                .SubstitBookM("corrode1", corroded, True, 1)
                .SubstitBookM("corrode2", corroded, True, 1)
                .SubstitBookM("CrowRad", Format(Involucr(kLato, jInvolucr).L0, Fors), True, 1)
                .SubstitBookM("KnucRad", Format(Involucr(kLato, jInvolucr).R0, Fors), True, 1)
                Monitor.Motore.Avanzamento = 60
                If Involucr(kLato, jInvolucr).ms < 7 Then
                    EUadopted()
                    .EliminaRighe("Par7p5p3p1", "CHECK15")
                    .EliminaRighe("Par7p5p3p2", "Adopted1")
                    .SubstitBookM("Term1", Format(Involucr(kLato, jInvolucr).di * 0.06, Fors), True, 1)
                    .SubstitBookM("Term2", Format(Involucr(kLato, jInvolucr).di * 0.2, Fors), True, 1)
                    .SubstitBookM("CHECK11", "CHECK", True, 1)
                    .SubstitBookM("Term3", Format(Involucr(kLato, jInvolucr).R0, Fors), True, 1)
                    .SubstitBookM("Term4", Format(Involucr(kLato, jInvolucr).Spess * 2, Fors), True, 1)
                    .SubstitBookM("CHECK12", "CHECK", True, 1)
                    .SubstitBookM("Term5", Format(Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
                    .SubstitBookM("Term6", Format((Involucr(kLato, jInvolucr).di + 2 * Involucr(kLato, jInvolucr).Spess) * 0.06, Fors), True, 1)
                    .SubstitBookM("CHECK13", "CHECK", True, 1)
                    .SubstitBookM("Term7", Format(Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
                    .SubstitBookM("Term8", Format((Involucr(kLato, jInvolucr).di + 2 * Involucr(kLato, jInvolucr).Spess) * 0.001, Fors), True, 1)
                    .SubstitBookM("CHECK14", "CHECK", True, 1)
                    .SubstitBookM("Term9", Format(Involucr(kLato, jInvolucr).L0, Fors), True, 1)
                    .SubstitBookM("Term10", Format(Involucr(kLato, jInvolucr).di + 2 * Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
                    .SubstitBookM("CHECK15", "CHECK", True, 1)
                    .SubstitBookM("es", Format(ES, Fors), True, 1)
                    .SubstitBookM("ey", Format(ey, Fors), True, 1)
                    .SubstitBookM("eb", Format(Eb, Fors), True, 1)
                    If TEMA > 0 Then
                        .SubstitBookM("MinTEMA1", Format(tts, Fors), True, 1)
                    Else
                        .EliminaRiga("MinTEMA1", 1)
                    End If
                    .SubstitBookM("Adopted1", Format(Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
                Else
                    .EliminaRiga("esuDe", 1)
                    .EliminaRighe("Par7p4p2", "Adopted", 1)
                End If
                Monitor.Motore.Avanzamento = 70
                EUMAWPPr()
                '--------------------------------------------------------------
                .VaiInizio("", 1)
                .Copia(1)
                .sClose(, 1)
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then Exit Sub
                .VaiInizio("\EndOfDoc")
                .NewCap(Elemento, False) ' da vedere se è la prima volta
                Monitor.Motore.ProgrAmmazza()
                .Visible = True
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        mioApert.Enabled = True
    End Sub
    Public Sub EUadopted()
        Dim esuDe As Single
        Dim Testo As String
        With Documento
            esuDe = Involucr(kLato, jInvolucr).Spess / (2 * Involucr(kLato, jInvolucr).Spess + Involucr(kLato, jInvolucr).di)
            If esuDe <= 0.16 Then Testo = "CHECK" Else Testo = "NO CHECK"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("esuDe", Format(esuDe, Form1_2), True, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("CHECK1", Testo, True, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("Equation", USStr(0), True, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("MinDesign", Format(t0s, Fors), True, 1)
            If TEMA > 0 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                .SubstitBookM("MinTEMA", Format(tts, Fors), True, 1)
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.EliminaRiga. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                .EliminaRiga("MinTEMA", 1)
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("Adopted", Format(Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Documento.substitbookm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .SubstitBookM("CHECK2", "CHECK", True, 1)
        End With
    End Sub
End Module