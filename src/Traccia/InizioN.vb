Option Strict On
Option Explicit On 
Imports VB = Microsoft.VisualBasic
Imports System.Math
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
Module Inizio
    Private hdeltao, xnw As Single
    Private deltaH, x1, hdelta As Single
    Private RiempitaMetà As Boolean
    Private yini, xy As Single
    Private ktotfit, ntotfit, ntufit As Short
    Private ntucl, iyi As Short
    Private Dpold As Single
    Private Yold As Single
    Private deltacint As Single
    Private i, Npassi As Short
    Private KNP As Short
    Private starty0 As Single
    Private VNP As Single
    Private KNQ As Short
    Private VNQ As Single
    Private PuntiD(,) As RoutBase1.clsVec2
    Private Fila(,) As Short
    Private Posizbu(,) As Short
    Private IndT1() As Short
    Private IndT2() As Short
    Private Accoppia(,) As Short
    Private NewInd() As Short
    Private NewDist() As Single
    Private DistCentro(,) As Single
    Private Anomal(,) As Single
    Private Settore(,) As Short
    Private IndiceCoppia() As Short
    Private OrdineFinale() As Short
    Private MarcaPausa() As Short
    Private PausaRX(,) As Boolean
    Private KCONT, SuperCont As Short
    Private iTubo, ntubi As Short
    Private j, k, nnn As Short
    Private x, y As Single
    Private iCod As Short
    Private iS1, ii, iS2 As Short
    Private counter As Short
    Private GapIntExt As Single
    Private EraZero As Boolean
    Private iCoppia As Short
    Private iTubo1, iTubo2 As Short
    Private iC, Candidato, iUnit As Short
    Private xtub, ytub As Single
    Private ifl2 As Short
    Private ifl1, iGia As Short
    Private FileSt As String
    Private Riga, doc As String
    Private Pagina, iRiga As Short
    Private StriSt(20) As String
    Private Fase, iPausa As Short
    Private Intest, iii As Short
    Private Revisione, LaData As String
    Private Alfa1, Anomal0, Alfa2 As Single
    Private DistMin, Dist As Single
    Private jmin As Short
    Private atu, VPA As Single
    Private alor1, anet1 As Single
    Private ktotu As Short
    Private ralibe As Single
    Private atfre, perfre As Single
    Private difs As Single
    Private ntui As Short
    Private akh, rbt As Single
    Private alord, bet, alibe As Single
    Private ntt, ICER As Short
    Private H As Single
    Private inh, ifh As Short
    Private jk As Short
    Private difs0 As Single
    Private tagl0, ak As Single
    Private antui As Single
    Private alord1, OPA As Single
    Private yj, hvi As Single
    Private toltu As Single
    Private Mtacsu, Mtacgiu As Short
    Private CERCH As Short
    Private RXMAX, RYMAX As Single
    Private Rinx1, Rinx2 As Single
    Private Riny1, Riny2 As Single
    Private pgd, pgm, pgs As Single
    Private sen, rdiaf, pgmm As Single
    Private catx, CATXx As Single
    Private PGDd, PGSs As Single
    Private XSU, XGIU As Single
    Private YSU, YGIU As Single
    Private UscitaSimmetrica As Boolean
    Sub Aggancia()
        Dim ifl, Risp As Short
        Dim Testo As String
        Dim Riga As String
        Dim iCMax As Short
        ReDim NewInd(DaTos(0).ktotal)
        ReDim NewDist(DaTos(0).ktotal)
        Dim Dir1 As New RoutBase1.clsVec2
        Dim Dir2 As New RoutBase1.clsVec2
        Dim Form2, Form1, icoo As String
        Dim iCoppia, iProfond As Short
        Dim iCoppiaV, iC As Short
        Dim Raggio As Single
        Dim iDat As Short
        Dim iTubo1, iTubo, iTubo2 As Short
        Dim Dist, Raggiol, Distl As Single
        Dim Ang1, Ang As Single
        Dim DAng As Single
        Dim indice, indcont As Short
        Dim iSorv As Short
        indcont = DaTos(iDat).ktotal
        If DaTos(1).ktotal > indcont Then indcont = DaTos(1).ktotal
        ReDim PuntiD(indcont, 1)
        ReDim Fila(indcont, 1)
        ReDim Posizbu(indcont, 1)
        ReDim IndT1(indcont)
        ReDim IndT2(indcont)
        indcont = 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Form1 = "###0  ###0.##  ###0.##  ###0.##  ###0.##"
        Form2 = " #0 #0 #0 #0 ###0 ###0"
        RiDim()
        Call CoorInMem()
        icoo = RTrim(gencommes) & ".COO" 'RTrim$(Datidir) + "\" + RTrim$(gencommes) + ".COO"
        If IO.File.Exists(icoo) Then
            'Recover:
            Testo = "Esiste il risultato di un calcolo precedente. Vuoi usarlo?"
            Risp = CShort(MsgBox(Testo, MsgBoxStyle.YesNo))
            If Risp = MsgBoxResult.Yes Then ' Return
                ifl = CShort(FreeFile())
                FileOpen(ifl, icoo, OpenMode.Input)
                Riga = LineInput(ifl)
                iCoppia = 0
                For iCoppia = 1 To DaTos(iDat).ktotal
                    Riga = LineInput(ifl)
                    Testo = prossimo(Riga)
                    Testo = prossimo(Riga)
                    '                    PuntiD(IndT1(iCoppia), 1).X = CShort(GlobalRoutines.ValVir(Testo)) ' GlobalRoutines.ValVir(Mid$(Riga, 7, 7))
                    'già fatto in CoorInMem. E poi è sbagliato
                    Testo = prossimo(Riga)
                    '                    PuntiD(IndT1(iCoppia), 1).y = CShort(GlobalRoutines.ValVir(Testo)) ' GlobalRoutines.ValVir(Mid$(Riga, 16, 7))
                    Testo = prossimo(Riga)
                    '                    PuntiD(IndT2(iCoppia), 0).X = CShort(GlobalRoutines.ValVir(Testo)) 'GlobalRoutines.ValVir(Mid$(Riga, 25, 7))
                    Testo = prossimo(Riga)
                    '                    PuntiD(IndT2(iCoppia), 0).y = CShort(GlobalRoutines.ValVir(Testo)) 'GlobalRoutines.ValVir(Mid$(Riga, 34, 7))
                    Testo = prossimo(Riga)
                    Testo = prossimo(Riga)
                    Testo = prossimo(Riga)
                    Testo = prossimo(Riga)
                    Testo = prossimo(Riga)
                    IndT1(iCoppia) = CShort(GlobalRoutines.ValVir(Testo)) 'GlobalRoutines.ValVir(Mid$(Riga, 54, 4))
                    Testo = prossimo(Riga)
                    IndT2(iCoppia) = CShort(GlobalRoutines.ValVir(Testo)) 'GlobalRoutines.ValVir(Mid$(Riga, 59, 4))
                Next
                FileClose(ifl)
                With MainForm
                    Dim ForeColor As Color = .p.Color
                    .p.Color = Color.OrangeRed
                    For iC = 1 To DaTos(iDat).ktotal
                        .g.DrawLine(.p, PuntiD(IndT1(iC), 1).X, PuntiD(IndT1(iC), 1).y, PuntiD(IndT2(iC), 0).X, PuntiD(IndT2(iC), 0).y)
                    Next
                    .Picture1.Refresh()
                    .p.Color = ForeColor
                    GoTo Esci
                End With
            End If
        End If
        MainForm.Break.Visible = True
        Fact = 2
584:    ReDim Accoppia(DaTos(iDat).ktotal, 1)
        ReDim IndT1(DaTos(iDat).ktotal)
        ReDim IndT2(DaTos(iDat).ktotal)
        ReDim NewInd(DaTos(iDat).ktotal)
        ReDim NewDist(DaTos(iDat).ktotal)
        iCoppia = 0 : iProfond = 0 'DaTos(iDat).Ntubi
        Do
            If iAgg = 0 Then GoTo FinePrematura
            iCoppia = CShort(iCoppia + 1)
Riprendi:   Raggio = -1 : iDat = 1 : iTubo1 = 0
            System.Windows.Forms.Application.DoEvents()
            If MainForm.Breckato Then GoTo FinePrematura
            For iTubo = 1 To DaTos(iDat).ktotal
                If Accoppia(iTubo, iDat) = 0 Then
                    Raggiol = CSng(System.Math.Sqrt(PuntiD(iTubo, iDat).X ^ 2 + PuntiD(iTubo, iDat).y ^ 2))
                    If Raggiol > Raggio Then
                        Raggio = Raggiol : iTubo1 = iTubo
                    End If
                End If
            Next
            If iTubo1 > 0 Then
810:            Accoppia(iTubo1, iDat) = iCoppia : IndT1(iCoppia) = iTubo1
                Dist = 1.0E+20 : iTubo2 = 0 : iDat = 0 : indice = 0
                If iCMax > 0 Then Testo = "Coppia massima" & Str(iCMax) & " " Else Testo = ""
                Testo = Testo & "Esamino la coppia" & Str(iCoppia)
                MainForm.StatusBar1.Panels(0).Text = Testo
                For iTubo = 1 To DaTos(iDat).ktotal
                    If Accoppia(iTubo, iDat) = 0 And iTubo <> iTubo1 Then
                        Distl = CSng(System.Math.Sqrt((PuntiD(iTubo, iDat).X - PuntiD(iTubo1, 1).X) ^ 2 + (PuntiD(iTubo, iDat).y - PuntiD(iTubo1, 1).y) ^ 2))
                        Raggio = CSng(System.Math.Sqrt(PuntiD(iTubo1, 1).X ^ 2 + PuntiD(iTubo1, 1).y ^ 2))
                        If System.Math.Abs(Raggio) < clsTrigon.TOLER Then
                            Ang = 0
                        Else
                            Dir1.X = PuntiD(iTubo1, 1).X / Raggio
                            Dir1.y = PuntiD(iTubo1, 1).y / Raggio
                            Ang = GlobalRoutines.arco(Dir1.X, Dir1.y)
                        End If
                        Dir2.X = (PuntiD(iTubo, iDat).X - PuntiD(iTubo1, 1).X) / Distl
                        Dir2.y = (PuntiD(iTubo, iDat).y - PuntiD(iTubo1, 1).y) / Distl
                        Ang1 = GlobalRoutines.arco(Dir2.X, Dir2.y)
                        DAng = System.Math.Abs(Ang1 - Ang) : If DAng > System.Math.PI Then DAng = CSng(2 * System.Math.PI - DAng)
                        Distl = CSng(Distl * (1 + Fact * DAng / 2 / System.Math.PI))
                        indice = CShort(indice + 1)
815:                    NewInd(indice) = iTubo : NewDist(indice) = Distl
                    End If
                Next
                If indice > 0 Then indcont = Ordina(NewDist, NewInd, indice, 0)
                'indcont = indice
                iTubo2 = NewInd(indcont)
                If iTubo2 > 0 Then
                    If iCMax > 0 Then Testo = "Coppia massima" & Str(iCMax) & " " Else Testo = ""
                    Testo = Testo & "Sorvolo la coppia" & Str(iCoppia)
                    MainForm.StatusBar1.Panels(0).Text = Testo
829:                iSorv = Sorvolo(iTubo1, iTubo2, iCoppia)
                    If iSorv <> 0 Then
                        'indcont = indcont - 1
                        indcont = Ordina(NewDist, NewInd, indice, 0)
                        If indcont = 0 Then
                            indcont = Ordina(NewDist, NewInd, indice, 1)
                            iTubo2 = NewInd(indcont)
                            GoTo 830
                        End If
831:                    iTubo2 = NewInd(indcont)
                        GoTo 829
                    End If
830:                If CBool(iSorv) Or Not CBool(VerifInters(PuntiD(iTubo2, 0), PuntiD(iTubo1, 1))) Then
                        '                                       esterno             interno
                        With MainForm
                            Dim ForeColor As Color = .p.Color
                            .p.Color = Color.Blue
                            .g.DrawEllipse(.p, PuntiD(IndT1(iCoppia), 1).X, PuntiD(IndT1(iCoppia), 1).y, (DaTos(iDat).dtubo / 2), (DaTos(iDat).dtubo / 2))
                            .g.DrawEllipse(.p, PuntiD(IndT1(iCoppia), 1).X, PuntiD(IndT1(iCoppia), 1).y, CSng(1.5 * (DaTos(iDat).dtubo / 2)), CSng(1.5 * (DaTos(iDat).dtubo / 2)))
                            iCMax = iCoppia
                            GlobalRoutines.FormatS("non|")
                            Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS(Helpstringa(IDH_ERR_TRAPPOLA), iCoppia))
                            'Testo = "Siamo intrappolati alla coppia" + Str(iCoppia) + "." + vbCrLf
                            'Testo = Testo + "Risponendo Si, il programma cercherà un'altra soluzione."
                            'Testo = Testo + "Rispondere Annulla, se si vuole riequilibrare manualmente" + vbCrLf
                            'Testo = Testo + "i fori attorno alla circorferenza. (Studiare prima la mappa" + vbCrLf
                            'Testo = Testo + "per individuare in quale settore i fori sono sbilanciati.)"
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            If MostraAiuto(IDH_ERR_TRAPPOLA, ChiaviMess.MessOKCancel Or ChiaviMess.MessInformation Or _
                                         ChiaviMess.MessHelpButton, Testo, "Traccia - Operazione di aggancio") = _
                                         ChiaviMess.MessCancel Then GoTo FinePrematura
                            .p.Color = .Picture1.BackColor
                            .g.DrawEllipse(.p, PuntiD(IndT1(iCoppia), 1).X, PuntiD(IndT1(iCoppia), 1).y, (DaTos(iDat).dtubo / 2), (DaTos(iDat).dtubo / 2))
                            .g.DrawEllipse(.p, PuntiD(IndT1(iCoppia), 1).X, PuntiD(IndT1(iCoppia), 1).y, CSng(1.75 * (DaTos(iDat).dtubo / 2)), CSng(1.75 * (DaTos(iDat).dtubo / 2)))
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                            .p.Color = forecolor
                            If iCMax > 0 Then Testo = "Coppia massima" & Str(iCMax) & " " Else Testo = ""
                            Testo = Testo & "Verifico la coppia" & Str(iCoppia)
                            .StatusBar1.Panels(0).Text = Testo
                            'MainForm.StatusBar1.CtlRefresh()
                        End With
                        iCoppiaV = iCoppia
                        If iProfond > 0 Then iCoppia = iProfond
                        Do
                            iCoppia = CShort(iCoppia - 1)
                            If iCoppia = 1 Then GoTo FinePrematura
840:                        If CBool(VerifInters(PuntiD(IndT2(iCoppia), 0), PuntiD(iTubo1, 1))) Then
                                If iCoppia < iProfond Or iProfond = 0 Then
                                    With MainForm
                                        Dim ForeColor As Color = .p.Color
                                        .p.Color = .Picture1.BackColor
                                        For iC = iCoppia To CShort(iCoppiaV - 1)
                                            .g.DrawLine(.p, PuntiD(IndT1(iC), 1).X, PuntiD(IndT1(iC), 1).y, PuntiD(IndT2(iC), 0).X, PuntiD(IndT2(iC), 0).y)
                                            '               interno                                            esterno
                                            Accoppia(IndT1(iC), 1) = 0 : IndT1(iC) = 0
                                            If iC > iCoppia Then Accoppia(IndT2(iC), 0) = 0 : IndT2(iC) = 0
                                        Next
                                        Accoppia(IndT1(iCoppiaV), 1) = 0 : IndT1(iCoppiaV) = 0
850:                                    Accoppia(iTubo1, 1) = iCoppia : IndT1(iCoppia) = iTubo1
                                        .p.Color = Color.OrangeRed
                                        .g.DrawLine(.p, PuntiD(IndT1(iCoppia), 1).X, PuntiD(IndT1(iCoppia), 1).y, PuntiD(IndT2(iCoppia), 0).X, PuntiD(IndT2(iCoppia), 0).y)
                                        'MainForm.Picture1.Refresh()
                                        iSorv = Sorvolo(iTubo1, IndT2(iCoppia), iCoppia)
                                        iProfond = iCoppia
                                        If iSorv = 0 Then
                                            iCoppia = CShort(iCoppia + 1)
                                            GoTo Riprendi
                                        End If
                                        .p.Color = ForeColor
                                    End With
                                End If
                            End If
                        Loop
                    End If
                    Accoppia(iTubo2, iDat) = iCoppia : IndT2(iCoppia) = iTubo2
                    With MainForm
                        Dim ForeColor As Color = .p.Color
                        .p.Color = Color.OrangeRed
                        .g.DrawLine(.p, PuntiD(iTubo1, 1).X, PuntiD(iTubo1, 1).y, PuntiD(iTubo2, 0).X, PuntiD(iTubo2, 0).y)
                        .Picture1.Refresh()
                        .p.Color = ForeColor
                    End With
                Else
                    If iCoppia <= DaTos(iDat).ktotal Then 'lavoro non finito
                        Fact = CSng(Fact - 0.25)
                        If Fact > -0.5 Then
                            Call SubTraccia(0)
                            Call datiout(0)
                            GoTo 584
                        Else
                            GoTo FinePrematura
                        End If
                    End If
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        ifl = CShort(FreeFile())
700:    FileOpen(ifl, icoo, OpenMode.Output)
        PrintLine(ifl, "Sigla    xi       yi       xe       ye   f.i bu f.e bu")
        For iCoppia = 1 To DaTos(iDat).ktotal
820:        Print(ifl, GlobalRoutines.FormatS(Form1, iCoppia, PuntiD(IndT1(iCoppia), 1).X, PuntiD(IndT1(iCoppia), 1).y, PuntiD(IndT2(iCoppia), 0).X, PuntiD(IndT2(iCoppia), 0).y))
            PrintLine(ifl, GlobalRoutines.FormatS(Form2, Fila(IndT1(iCoppia), 1), Posizbu(IndT1(iCoppia), 1), Fila(IndT2(iCoppia), 0), Posizbu(IndT2(iCoppia), 0), IndT1(iCoppia), IndT2(iCoppia)))
        Next
        Testo = "Operazione di aggiancio terminata con successo." & Str(iCoppia)
        MainForm.StatusBar1.Panels(0).Text = Testo
Esci:   FileClose(ifl)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        MainForm.Break.Visible = False
        Exit Sub
FinePrematura:
        iAgg = 0
        MainForm.Breckato = False
        MainForm.StatusBar1.Panels(0).Text = "Non è stato possibile trovare una soluzione"
        SubTraccia(0)
        GoTo Esci
    End Sub
    Sub Bilancio()
        Dim iDat As Short
        Dim Raggio As Single
        Dim jFila As Short
        Dim iTubo As Short
        Dim Raggiol As Single
        Dim ksect As Short
        Dim xtub, ytub As Single
        Dim Obiettivo, ktot As Short
        Dim ntubo, iT As Short
        Dim Text As String
        ntubo = 0
        Text = "Riordino delle coordinate fori" & vbCrLf
        Text = Text & "in corso "
        Monitor.Motore.ProgrInizio(Text)
        With MainForm
            .StatusBar1.Panels(0).Text = "Attendere, prego . . ."
            RiDim()
            DistInMem()
            For iDat = 0 To 1
                Monitor.Motore.Avanzamento = CSng((0.8 + (iDat + 1) / 2 * 0.1) * 100)
                ktot = DaTos(iDat).ktotal
                QualeCorona = CShort(iDat + 1)
                If DaTos(iDat).ntubi > 0 Then
                    Obiettivo = DaTos(iDat).ntubi
                Else
                    If iDat = 0 Then Obiettivo = DaTos(1).ktotal Else Obiettivo = DaTos(iDat).ktotal
                End If
                For iT = 1 To ktot - Obiettivo
                    Raggio = Raggiol
                    iTubo = Posizbu(iT, iDat)
                    jFila = Fila(iT, iDat)
                    ksect = Settore(iT, iDat)
                    xtub = PuntiD(iT, iDat).X
                    ytub = PuntiD(iT, iDat).y
                    ntubo = iT
                    If jFila > 0 And iTubo > 0 Then
                        DaTos(iDat).bu(jFila, iTubo) = CChar("0")
                        .g.FillEllipse(.b, xtub - DaTos(iDat).dtubo / 2, ytub - DaTos(iDat).dtubo / 2, _
                           DaTos(iDat).dtubo, DaTos(iDat).dtubo)
                        .Refresh()
                        DaTos(iDat).NumeroTubiSettore(ksect) = CShort(DaTos(iDat).NumeroTubiSettore(ksect) - 1)
                        DaTos(iDat).NumeroTubiFila(jFila) = CShort(DaTos(iDat).NumeroTubiFila(jFila) - 1)
                        DaTos(iDat).ktotal = CShort(DaTos(iDat).ktotal - 1)
                        If iDat = 1 And DaTos(1).cinter > 0 Then DistCentro(ntubo, iDat) = 1.0E+20 Else DistCentro(ntubo, iDat) = 0
                    End If
                Next iT
            Next iDat
        End With
        Monitor.Motore.Avanzamento = 101
        Monitor.Motore.ProgrAmmazza()
    End Sub

    Sub CalcolaTrac()
        Dim Testo As String
        Dim ktest, kwritf As Short
        Dim Disax As Single
        Dim NTUBX As Short
        Dim di00 As Single
        Dim FFI, DIMAX As Single
        Dim incr As Short
        Dim incr1, LAG As Short
        Dim DIOLD As Single
        Dim DiaframmiTight As Boolean
        Dim TuboPrimaFilaFuoriCentro As Boolean
        Dim keyy As Short
        Dim nofat As Short
        Dim otloold As Single
        Dim OTOLD As Single
        Dim KOLD As Short
        Dim nRES As Short
        Dim Log3, Log1, Log2 As Boolean
        iDat = CShort(QualeCorona - 1)
        Call InitItera(ktest, kwritf, NTUBX, di00)
        SuperCont = 0
1752:   Call ContItera(di00, NTUBX, Disax, FFI, DIMAX)
        SuperCont = CShort(SuperCont + 1)
20:     KCONT = 0 : incr1 = 0 : LAG = 0 : DIOLD = DaTos(iDat).di1
        DiaframmiTight = True
        TuboPrimaFilaFuoriCentro = Spostx()
22:     KCONT = CShort(KCONT + 1) : incr = incr1
        If KCONT > ktest Then
            Testo = at1(69) & ktest.ToString
            Monitor.Motore.Inizio.ConvertiCr(Testo)
            MsgBox(Testo, MsgBoxStyle.OKOnly)
            MainForm.StatusBar1.Panels(0).Text = ""
            Exit Sub
        End If
        If DaTos(iDat).OTL < 0 Then
            Testo = at1(210) & ktest.ToString
            Monitor.Motore.Inizio.ConvertiCr(Testo)
            MsgBox(Testo, MsgBoxStyle.OKOnly)
            MainForm.StatusBar1.Panels(0).Text = ""
            Exit Sub
        End If
        Call SuperDiadif(DiaframmiTight)
        Call SuperYinout(keyy)
40:     Call SuperCentro(KCONT)
        Call Sub58()
        '        TuboPrimaFilaFuoriCentro = Spostx   'aggiunto
60:     Call Sub60(TuboPrimaFilaFuoriCentro, Disax)
        'LINDE
        If Not DaTos(iDat).CurveInPianoVert Or DaTos(iDat).PassoFascio > 2 Then
            '  If kwrite Then
            '     Rownf
            '     Nhsym
            '  End If
            Call RSETTO()
            If starty = -9999 Then GoTo 40
        Else
            Call UTUBI()
            MainForm.StatusBar1.Panels(0).Text = "Iterazione" & Str(KCONT) & "; OTL " & GlobalRoutines.myStr(DaTos(iDat).OTL, 4, 1, 0)
            ' MainForm.StatusBar1.CtlRefresh()
            If FuoriReticolo Then
                FuoriReticolo = False : GoTo 1231
            End If
        End If
        If Not (kwrite = 0) Then Call Rownf()
        DaTos(iDat).ktotal = DaTos(iDat).ktotal + DaTos(iDat).Ntot
        dx = SpostXSettore(jsect)
        MainForm.StatusBar1.Panels(0).Text = "Iterazione" & Str(KCONT) & "; OTL " & GlobalRoutines.myStr(DaTos(iDat).OTL, 4, 1, 0) & "; n° fori" & Str(DaTos(iDat).ktotal)
        'MainForm.StatusBar1.CtlRefresh()
        If Indexx = 0 Then
            '          If DaTos(iDat).CurveInPianoVert = 1 Then jsect = DaTos(iDat).NumeroSettori
            If DaTos(iDat).CurveInPianoVert And DaTos(iDat).PassoFascio = 2 Then jsect = DaTos(iDat).NumeroSettori
            'LINDE
            If DaTos(iDat).CurveInPianoVert And DaTos(iDat).PassoFascio > 2 And jsect = DaTos(iDat).NumeroSettori - 2 Then jsect = DaTos(iDat).NumeroSettori
            If jsect = DaTos(iDat).NumeroSettori Then 'goto 80
Fine:           If DaTos(iDat).CurveInPianoVert And kwrite = 1 Then GoTo 105
                If kwrite = 1 Then GoTo 110
                If LAG = 1 Or keyy = 1 Then
                    GoTo 90
                End If
                If di00 <> 0 And DaTos(iDat).MassimizzaOTL Or NTUBX = 1 Then
                    incr1 = 0 : GoTo 90
                End If
                If nofat = 1 And DaTos(iDat).OTL = otloold Then
                    nofat = 0 : GoTo 90
                Else
                    If UscitaSimmetrica Then otloold = DaTos(iDat).OTL : nofat = 1
                End If
                incr1 = -1
                If (DaTos(iDat).di0 = 0) Or (Not TuboPrimaFilaFuoriCentro And DaTos(iDat).di1 > DIOLD) Then
                    DaTos(iDat).di1 = DaTos(iDat).di1 - FFI
                Else
                    DiaframmiTight = False : OTOLD = DaTos(iDat).OTL
                    KOLD = DaTos(iDat).ktotal : DaTos(iDat).OTL = DaTos(iDat).OTL - FFI
                End If
                If incr + incr1 = 0 Then LAG = 1
                GoTo 22
            Else '!!!!
                GoTo 70
            End If
        End If
1231:   If NTUBX = 1 Then
            DaTos(iDat).ntubi = CShort(DaTos(iDat).ntubi * 0.95 - 1) : Indexx = 0
            'era remmataLOCATE 25, 50: PRINT "ntubi: "; DaTos(iDat).ntubi;
            GoTo 1752
        End If
        incr1 = 1
        If DiaframmiTight Then DaTos(iDat).di1 = DaTos(iDat).di1 + FFI * Indexx
        If Not DiaframmiTight Then DaTos(iDat).OTL = DaTos(iDat).OTL + FFI * Indexx
        OTOLD = DaTos(iDat).OTL : KOLD = DaTos(iDat).ktotal : DIOLD = DaTos(iDat).di1
        If incr + incr1 = 0 Then LAG = 1
        If DaTos(iDat).di1 <= DIMAX Then
            GoTo 22
        End If
        DaTos(iDat).di1 = DaTos(iDat).di1 - FFI : DIOLD = DaTos(iDat).di1
        If Not DaTos(iDat).VaporBelt Or Not keyy = 1 Then
            nRES = DaTos(iDat).ntubi - DaTos(iDat).ktotal
            If Not DaTos(iDat).VaporBelt And (nRES > (DaTos(iDat).ntubi / 100) Or keyy = 1) Then
                DaTos(iDat).di0 = 0 : DIMAX = 10000
                GoTo 20
            End If
            keyy = 1
            TuboPrimaFilaFuoriCentro = Spostx()
            GoTo 40
        Else
            DaTos(iDat).di0 = 0 : DIMAX = 10000
            GoTo 20
        End If
        '-------------------------------------------------------------
70:     If dx <> 0 Then
            jsect = CShort(jsect + 1)
            'LINDE
            If DaTos(iDat).PassoFascio > 2 And DaTos(iDat).CurveInPianoVert Then jsect = CShort(jsect + 1)
            'LINDE
            DaTos(iDat).NumeroTubiSettore(jsect) = DaTos(iDat).Ntot
            DaTos(iDat).ktotal = DaTos(iDat).ktotal + DaTos(iDat).Ntot
            MainForm.StatusBar1.Panels(0).Text = "Iterazione" & Str(KCONT) & "; OTL " & GlobalRoutines.myStr(DaTos(iDat).OTL, 4, 1, 0) & "; n° fori" & Str(DaTos(iDat).ktotal)
            If kwrite = 1 Then Call Nhsym()
            If jsect = DaTos(iDat).NumeroSettori Then
                'LINDE
                'If DaTos(iDat).PassoFascio > 2 And DaTos(iDat).CurveInPianoVert = 1 Then GoTo Fine
                If kwrite = 1 Then GoTo 110
                kwrite = 1 : GoTo 40
            End If
        End If
        nRES = DaTos(iDat).ntubi - DaTos(iDat).ktotal
        nteor = CShort((nRES + DaTos(iDat).NumeroSettori - jsect - 1) / (DaTos(iDat).NumeroSettori - jsect))
702:    If UscitaSimmetrica Then nteor = kteor
        jsect = CShort(jsect + 1)
        'LINDE
        If DaTos(iDat).PassoFascio > 2 And DaTos(iDat).CurveInPianoVert Then
            If jsect = DaTos(iDat).NumeroSettori Then
                If kwrite = 1 Then
                    jsect = CShort(jsect - 2)
                    Rownf()
                    jsect = CShort(jsect + 2)
                    Rownf()
                End If
                GoTo Fine
            End If
            jsect = CShort(jsect - 2)
            'LINDE
        Else
            starty = DaTos(iDat).y(Ni) + dy
        End If
        If DaTos(iDat).TipoPasso = clsTracciatura.TipiPasso._45 Then
            Call DELTA3()
            GoTo 60
        End If
        If DaTos(iDat).TipoPasso <> clsTracciatura.TipiPasso._90 Or DaTos(iDat).PassoFascio > clsTracciatura.PassiFascio._4par Then DeltaPasso = 0
        GoTo 60
        '-----------------------------------------------------------------
90:     If ZonaUscita > 1 Or (ZonaUscita = ControlloZonaUscita.Simmetria And (DaTos(iDat).OTL < OTOLD Or DaTos(iDat).OTL = OTOLD And DaTos(iDat).ktotal >= KOLD)) Then
            kwrite = 1
            GoTo 40
        End If
        If Not TuboPrimaFilaFuoriCentro Then
            Log1 = (keyy = 1)
            Log2 = Not DiaframmiTight And (DaTos(iDat).OTL < OTOLD Or DaTos(iDat).OTL = OTOLD And DaTos(iDat).ktotal >= KOLD)
            Log3 = DaTos(iDat).di1 < DIOLD Or DaTos(iDat).di1 = DIOLD And DaTos(iDat).ktotal >= KOLD
            If (Log1 Or Log2 Or Log3) And Not Spostx() Then
                kwrite = 1
                GoTo 40
            Else
                DaTos(iDat).di1 = DIOLD
                'If DaTos(iDat).MassimizzaOTL = 0 Then DaTos(iDat).OTL = OTOLD
                DaTos(iDat).OTL = OTOLD
                TuboPrimaFilaFuoriCentro = True
                kwrite = 1
                GoTo 40
            End If
        Else
            TuboPrimaFilaFuoriCentro = False
            KOLD = DaTos(iDat).ktotal
            OTOLD = DaTos(iDat).OTL : DIOLD = DaTos(iDat).di1 : incr1 = 0 : LAG = 0
            GoTo 22
        End If
        '-------------------------------------------------------
105:    Call Nhsym()
110:    If Sub110(kwritf) = 1 Then GoTo 60
        MainForm.StatusBar1.Panels(0).Text = ""
        'MainForm.StatusBar1.Style = MSComctlLib.SbarStyleConstants.sbrNormal
    End Sub

    Sub CalcSettor(ByRef Disax As Single)
        Dim i As Short
        With DaTos(iDat)
13:         If .PassoFascio <= 4 Then
                .NumeroSettori = CShort(.PassoFascio)
                NumeroSetti = CShort(.PassoFascio - 1)
                For i = 1 To .NumeroSettori
                    SpostXSettore(i) = 0
                    .dxv = 0
                Next
15:         ElseIf .PassoFascio Mod 2 = 1 Then
                .NumeroSettori = CShort(.PassoFascio - 1)
                NumeroSetti = CShort((.PassoFascio - 1) / 2)
                SpostXSettore(1) = 0
                If .TipoPasso = 4 And .TipoFascio <> 3 Then Disax = .PassoOrizzontale
                If .dt(39) <> 0 Then Disax = .dt(39) / 2 : .DistSuSettoVer = .dt(39)
                For i = 2 To CShort(.NumeroSettori - 1)
                    SpostXSettore(i) = Disax
                Next
                .dxv = Disax
                SpostXSettore(.NumeroSettori) = 0
            Else
                If .CurveInPianoVert And .PassoFascio = traccia.clsTracciatura.PassiFascio._4U Then
                    If .dt(39) <> 0 Then Disax = .dt(39) / 2 : .DistSuSettoVer = .dt(39)
                End If
17:             .NumeroSettori = CShort(.PassoFascio - 2)
                NumeroSetti = CShort(.PassoFascio / 2 - 2)
                If .TipoFascio = traccia.clsTracciatura.TipiFascio.Utube And Not .CurveInPianoVert Then
                    If .radiu = 0 Then
                        .radiu = Disax
                        .dt(21) = Disax
                        radvec = .radiu
                    End If
                    If .dt(39) <> 0 Then
                        .dt(21) = .dt(39) / 2
                        .radiu = .dt(21)
                        radvec = .radiu
                    Else
                        .dt(39) = 2 * .radiu
                        radvec = .radiu
                        .DistSuSettoVer = .dt(39)
                    End If
                    If .radiu <> Disax Then Call RinpCalc(Disax)
                End If
                For i = 1 To .NumeroSettori : SpostXSettore(i) = Disax : Next : .dxv = Disax
            End If
            kteor = CShort((.ntubi + .NumeroSettori - 1) / .NumeroSettori)
            EpariNumeroSetti = CShort(NumeroSetti Mod 2) = 0
            If NumeroSetti = 0 Then dy = 0
            jSettoreCritico = idelt(.PassoFascio)
        End With
    End Sub

    Sub ContItera(ByRef di00 As Single, ByRef NTUBX As Short, ByRef Disax As Single, ByRef FFI As Single, ByRef DIMAX As Single)
        Dim DD As Single
        Dim ARE1, OTL1 As Single
        If DaTos(iDat).di1 < di00 Then DaTos(iDat).di1 = di00
        Try
            If DaTos(iDat).di0 = 0 Then
                ARE1 = CSng(DaTos(iDat).PassoVerticale * DaTos(iDat).PassoOrizzontale * DaTos(iDat).ntubi + DaTos(iDat).cinter ^ 2 * System.Math.PI)
                OTL1 = CSng(System.Math.Sqrt(ARE1 * 4 / System.Math.PI))
                OTL1 = CSng(OTL1 + 0.5 * (DaTos(iDat).y0in + DaTos(iDat).y0out))
                DaTos(iDat).di1 = CSng(1.1 * OTL1)
                If DaTos(iDat).di1 < di00 Then
                    DaTos(iDat).di1 = di00 : DaTos(iDat).di0 = DaTos(iDat).di1
                End If
            End If
            If DaTos(iDat).ntubi = 0 Then
                DaTos(iDat).ntubi = CShort((DaTos(iDat).di1 ^ 2 - (2 * DaTos(iDat).cinter) ^ 2) * System.Math.PI / 4 / (DaTos(iDat).PassoVerticale * DaTos(iDat).PassoOrizzontale * 1.1))
                NTUBX = 1
            End If
            FFI = IncrementoDiametro
            If FFI = 0 Then
                FFI = 12.5
                If DaTos(iDat).di1 >= 1000 And DaTos(iDat).di1 < 2700 Then FFI = 25
                If DaTos(iDat).di1 >= 2700 Then FFI = 50
            End If
            If DaTos(iDat).di0 = 0 Then
                DD = 0
                If DaTos(iDat).di1 Mod FFI <> 0 Then DD = FFI
                DaTos(iDat).di1 = Int(DaTos(iDat).di1 / FFI) * FFI + DD
            End If
            If Not DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Utube Then
                'no tubi ad u
                Call NoTuadu(Disax)
            Else
                'tubi ad u------------------------
                Call Tubiadu(Disax)
            End If
            Call CalcSettor(Disax)
            DIMAX = 10000
            If Not (DaTos(iDat).di0 = 0) Then
                DIMAX = DaTos(iDat).di1 + 25
                If DaTos(iDat).di1 >= 800 Then DIMAX = DaTos(iDat).di1 + 50
                If DaTos(iDat).di1 >= 1600 Then DIMAX = DaTos(iDat).di1 + 75
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub CoorInMem(Optional ByRef iTubof As Integer = -1)
        Dim lociDat, iTubo As Short
        Dim j, k, nnn As Short
        Dim x, y As Single
        Dim iCod As Short
        Try
            For lociDat = 0 To 1
                QualeCorona = CShort(lociDat + 1)
                iTubo = 0
                For k = 1 To DaTos(lociDat).NumeroSettori
                    For j = DaTos(lociDat).FilaIniziale(k) To DaTos(lociDat).FilaFinale(k)
                        If j > 0 Then
                            For nnn = 1 To DaTos(lociDat).ici(j)
                                Call CoorXY(lociDat, j, nnn, x, y, iCod)
                                If iCod = 0 Then
                                    iTubo = CShort(iTubo + 1)
                                    PuntiD(iTubo, lociDat) = New clsVec2(x, y)
                                    DistCentro(iTubo, lociDat) = CSng(System.Math.Sqrt(x * x + y * y))
                                    If System.Math.Abs(DistCentro(iTubo, lociDat)) < clsTrigon.TOLER Then
                                        Anomal(iTubo, lociDat) = 0
                                    Else
                                        Anomal(iTubo, lociDat) = GlobalRoutines.arco(x / DistCentro(iTubo, lociDat), y / DistCentro(iTubo, lociDat))
                                    End If
                                    Fila(iTubo, lociDat) = j
                                    Posizbu(iTubo, lociDat) = nnn
                                    Settore(iTubo, lociDat) = k
                                End If
                            Next nnn
                        End If
                    Next j
                Next k
            Next lociDat
            QualeCorona = 1 : lociDat = 0
            If Not iTubof = -1 Then iTubof = iTubo
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub CalcOTL(ByVal lociDat As Short)
        Dim iTubo As Short
        Dim Dist, DistMax As Single
        Dim DistMin As Single
        Dim j, k, nnn As Short
        Dim x, y As Single
        Dim iCod As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        DistMin = 1.0E+20
        QualeCorona = CShort(lociDat + 1)
        iTubo = 0
        Try
            For k = 1 To DaTos(lociDat).NumeroSettori
                For j = DaTos(lociDat).FilaIniziale(k) To DaTos(lociDat).FilaFinale(k)
                    If j > 0 Then
                        For nnn = 1 To DaTos(lociDat).ici(j)
                            Call CoorXY(lociDat, j, nnn, x, y, iCod)
                            If iCod = 0 Then
                                iTubo = CShort(iTubo + 1)
                                Dist = CSng(System.Math.Sqrt(x * x + y * y))
                                If Dist > DistMax Then DistMax = Dist
                                If Dist < DistMin Then DistMin = Dist
                            End If
                        Next nnn
                    End If
                Next j
            Next k
            If DistMax > 0 Then DaTos(lociDat).OTL = 2 * (DistMax + (DaTos(lociDat).dtubo / 2))
            If DistMin < 1.0E+20 Then DaTos(lociDat).cinter = DistMin - (DaTos(lociDat).dtubo / 2) - 1
            If DaTos(lociDat).cinter < DaTos(lociDat).Passo Then DaTos(lociDat).cinter = 0
            If DaTos(lociDat).dt(34) = 0 Then DaTos(lociDat).cinter = 0
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        QualeCorona = 1 : lociDat = 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Sub DistInMem()
        Dim lociDat As Short
        Try
            For lociDat = 0 To 1
                QualeCorona = CShort(lociDat + 1)
                iTubo = 0
                For k = 1 To DaTos(lociDat).NumeroSettori
                    For j = DaTos(lociDat).FilaIniziale(k) To DaTos(lociDat).FilaFinale(k)
                        If j > 0 Then
                            For nnn = 1 To DaTos(lociDat).ici(j)
                                Call CoorXY(lociDat, j, nnn, x, y, iCod)
                                If iCod = 0 Then
                                    iTubo = CShort(iTubo + 1)
                                    PuntiD(iTubo, lociDat).X = x
                                    PuntiD(iTubo, lociDat).y = y
                                    DistCentro(iTubo, lociDat) = CSng(System.Math.Sqrt(x * x + y * y))
                                    Fila(iTubo, lociDat) = j
                                    Posizbu(iTubo, lociDat) = nnn
                                    Settore(iTubo, lociDat) = k
                                End If
                            Next nnn
                        End If
                    Next j
                Next k
                ntubi = iTubo
                For iTubo = 1 To CShort(ntubi - 1)
                    Monitor.Motore.Avanzamento = CSng((iTubo + ntubi * lociDat) / 2 / ntubi * 0.5 * 100)
                    For i = CShort(iTubo + 1) To ntubi
                        If iTubo <> i Then
                            If DistCentro(iTubo, lociDat) < DistCentro(i, lociDat) Then
                                Scambia(i, lociDat)
                            End If
                        End If
                    Next
                Next
                For iTubo = 1 To CShort(ntubi - 1)
                    Monitor.Motore.Avanzamento = CSng((0.5 + (iTubo + ntubi * lociDat) / 2 / ntubi) * 0.3 * 100)
                    For i = CShort(iTubo + 1) To ntubi
                        If System.Math.Abs(DistCentro(i, lociDat) - DistCentro(iTubo, lociDat)) < 0.1 Then
                        Else
                            If i > iTubo + 3 Then
                                counter = iTubo
                                For j = counter To CShort(i - 1)
                                    iS1 = iSector(PuntiD(j, lociDat))
                                    For k = CShort(j + 1) To i
                                        iS2 = iSector(PuntiD(k, lociDat))
                                        If iOkk(iS1, iS2) Then Exit For
                                    Next
                                    If k > j + 1 Then
                                        iTubo = k
                                        Scambia(CShort(j + 1), lociDat)
                                    End If
                                Next
                            End If
                            iTubo = i
                            Exit For
                        End If
                    Next
                Next
            Next lociDat
            QualeCorona = 1 : lociDat = 0
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Scambia(ByVal ii As Short, ByVal lociDat As Short)
        Try
            GlobalRoutines.SWAP(PuntiD(iTubo, lociDat).X, PuntiD(ii, lociDat).X)
            GlobalRoutines.SWAP(PuntiD(iTubo, lociDat).y, PuntiD(ii, lociDat).y)
            GlobalRoutines.SWAP(DistCentro(iTubo, lociDat), DistCentro(ii, lociDat))
            GlobalRoutines.SWAP(Fila(iTubo, lociDat), Fila(ii, lociDat))
            GlobalRoutines.SWAP(Posizbu(iTubo, lociDat), Posizbu(ii, lociDat))
            GlobalRoutines.SWAP(Settore(iTubo, lociDat), Settore(ii, lociDat))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub CoorXY(ByVal lociDat As Short, ByRef j As Short, ByRef nnn As Short, ByRef x As Single, ByRef y As Single, ByRef iCod As Short)
        '-----------------------------------------
        Dim yj, xx As Single
        Dim cod As String
        Dim i As Short
        If j = 0 Then iCod = 3 : Exit Sub
        If DaTos(lociDat).NumeroTubiFila(j) = 0 Then
            iCod = 1 : Exit Sub
        End If
        yj = DaTos(lociDat).y(j)
        xx = DaTos(lociDat).x(j) - DaTos(lociDat).PassoOrizzontale
        If nnn > DaTos(lociDat).ici(j) Then iCod = 2 : Exit Sub
        'If DaTos(lociDat).x(j) ^ 2 + yj * yj > ((DaTos(lociDat).Otl - DaTos(lociDat).dtubo) / 2) ^ 2 + 1 Then iCod = 2: Exit Sub
        For i = 1 To nnn
            cod = DaTos(lociDat).bu(j, i)
            Select Case cod
                Case "9" : xx = -xx - DaTos(lociDat).PassoOrizzontale
                Case Else : xx = xx + DaTos(lociDat).PassoOrizzontale
            End Select
        Next i
        cod = DaTos(lociDat).bu(j, nnn)
        Select Case cod
            Case "1"
                iCod = 0 : x = xx : y = yj
            Case Else : iCod = 9
        End Select
    End Sub

    Sub Fontana()
        EraZero = (DaTos(0).ntubi = 0)
        Call GenCorInt()
        DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse : DaTos(0).PassoFascio = traccia.clsTracciatura.PassiFascio._1
        DaTos(1).TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse : DaTos(1).PassoFascio = traccia.clsTracciatura.PassiFascio._1
        If DaTos(0).ntubi = 0 Then 'calcolo bloccato sui diametri
            Calc1()
        Else 'calcolo sui tubi: anche se sono dati
            ' diametri li ignoro (in un certo senso)
            If DaTos(1).di0 > 0 And DaTos(0).cori > 0 Then
                GapIntExt = (DaTos(0).cori - DaTos(1).di0) / 2
            ElseIf DaTos(1).coriext > 0 And DaTos(0).cori > 0 Then
                GapIntExt = (DaTos(0).cori - DaTos(1).coriext) / 2
            Else
                GapIntExt = DaTos(0).cinter - DaTos(0).coriext / 2 '100 'Provvisorio!!!!!!!!
            End If
            DaTos(1).di0 = 0 : DaTos(0).di0 = 0
            Calc2()
        End If
        DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana : DaTos(0).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
        DaTos(1).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana : DaTos(1).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
        If EraZero Then DaTos(0).ntubi = 0
    End Sub
    Private Sub Calc1()
        QualeCorona = 1
        Call CalcolaTrac() 'calcolo corona esterna
        QualeCorona = 2
        Call CalcolaTrac() 'calcolo corona interna
        DaTos(0).coriext = DaTos(1).di1
    End Sub
    Private Sub Calc2()
        QualeCorona = 2
        Call CalcolaTrac() 'calcolo corona interna
        DaTos(0).coriext = DaTos(1).di1
        DaTos(0).cori = DaTos(1).di1 + 2 * GapIntExt
        DaTos(0).cinter = DaTos(0).cori / 2
        QualeCorona = 1
        Call CalcolaTrac() 'calcolo corona esterna
    End Sub
    Sub GenCorInt()
        Dim i As Integer
        DaTos(1).cori = DaTos(0).coriint
        For i = 0 To 51
            DaTos(1).dt(i) = DaTos(0).dt(i)
        Next
        iDat = 1
        Call nuovi()
        iDat = 0
        DaTos(1).otimp = DaTos(0).coriext
        DaTos(1).Passo = DaTos(0).passoint 'adesso in 1 c'Š la corona interna
        DaTos(1).cinter = DaTos(0).coriint / 2
    End Sub
    Sub InitItera(ByRef ktest As Short, ByRef kwritf As Short, ByRef NTUBX As Short, ByRef di00 As Single)
        Dim j, m As Short
        Dim Text As String, tpasso As Single
        For j = 1 To 12 : DaTos(iDat).hsym(j) = 0 : Next
        kwrite = 0
        kdati = 1
        ktest = 500 : DaTos(iDat).XYBLOK = 0
        kwritf = 0
        starty = 0 : Epsil1 = 0 : Epsilo = 0
        LarghezzaCavaPerSetto = 13
        If DaTos(iDat).tcava > 0 Then LarghezzaCavaPerSetto = DaTos(iDat).tcava
        MargineVersoCava = 2
        If GiuntoSaldato Then MargineVersoCava = 5
        DaTos(iDat).VaporBelt = False
        DaTos(iDat).NumeroSettori = 0 : dy = 0
        NTUBX = 0
        xcsi = 0
        ypsi = 0
        ZonaUscita = ControlloZonaUscita.AltezzaData
        If DaTos(iDat).y0out < 6 And DaTos(iDat).y0out > 0.5 Then
            ZonaUscita = CType(DaTos(iDat).y0out, ControlloZonaUscita)
            DaTos(iDat).y0out = 0
        End If
        UscitaSimmetrica = (ZonaUscita = ControlloZonaUscita.Simmetria Or ZonaUscita = ControlloZonaUscita.SimmetriaTuboInAsse Or ZonaUscita = ControlloZonaUscita.SimmetriaTuboFuoriAsse)
        If DaTos(iDat).dtin = 0 And DaTos(iDat).dtout = 0 And DaTos(iDat).y0in = 0 And DaTos(iDat).y0out = 0 Then
            DaTos(iDat).VaporBelt = True
        Else
            If Not (DaTos(iDat).pdiaf = 0 Or DaTos(iDat).p1 = 0 Or DaTos(iDat).matub = 0 Or DaTos(iDat).dtin = 0) Then
                For m = 1 To 13
                    If Fix(DaTos(iDat).dtubo * 10) = Fix(Dtub0(m) * 10) Then
                        If DaTos(iDat).matub = 1 Then
                            tpasso = Tlmax1(m)
                        ElseIf DaTos(iDat).matub = 2 Then
                            tpasso = Tlmax2(m)
                        Else
                            DaTos(iDat).matub = 1
                            tpasso = Tlmax1(m)
                        End If
                        If Not ((DaTos(iDat).p1 > (DaTos(iDat).dtin + 50)) And (DaTos(iDat).p1 < (tpasso - DaTos(iDat).pdiaf))) Then
                            Text = "I passi diaframmi sono sospetti." & vbCrLf
                            Text = Text & GlobalRoutines.myStr(DaTos(iDat).p1, 5, 0, 0) & ">" & GlobalRoutines.myStr(DaTos(iDat).dtin + 50, 5, 0, 0) & vbCrLf
                            Text = Text & GlobalRoutines.myStr(DaTos(iDat).p1, 5, 0, 0) & "<" & GlobalRoutines.myStr(tpasso - DaTos(iDat).pdiaf, 5, 0, 0)
                            MsgBox(Text, MsgBoxStyle.OKOnly)
                            DaTos(iDat).VaporBelt = True
                        End If
                    End If
                Next
            End If
        End If
        DaTos(iDat).di1 = DaTos(iDat).di0 : di00 = DaTos(iDat).di0
        Call RPASSO()
        If DaTos(iDat).TipoPasso <> 4 Then
            PassoVdecimm = CShort(Floor(DaTos(iDat).PassoVerticale * 10))
        Else
            PassoVdecimm = CShort(Floor(5 * DaTos(iDat).PassoVerticale))
        End If
    End Sub

    Function inizio1() As Boolean
        Dim Esito As Boolean
        inizio1 = False
        If kdati < 0 Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MostraAiuto(-kdati)
            Exit Function
        End If
        If DaTos(iDat).ILFINAL = 0 Then
            If DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Fontana Then Call Fontana() Else Call CalcolaTrac()
        End If
        Esito = inizio2()
        inizio1 = Esito
    End Function
    Function inizio2() As Boolean
        inizio2 = True
        If Not (DaTos(iDat).ILFINAL = 0 And DaTos(iDat).Elimin = 1) Then Call datiout(0)
        If iAction > -1 Then
            If DaTos(iDat).CurveInPianoVert Then DaTos(iDat).NumeroTubiSettore(2) = DaTos(iDat).NumeroTubiSettore(1)
            kdati = 1
            Call SubTraccia(0)
            iAgg = 0
        End If
        iAction = 0
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
            If (DaTos(iDat).ntubi = 0 And DaTos(iDat).ktotal = DaTos(1).ktotal) Or (DaTos(iDat).ntubi > 0 And DaTos(iDat).ntubi = DaTos(iDat).ktotal And DaTos(iDat).ntubi = DaTos(1).ktotal) Then
                iAction = 2 'Aggancia/infilaggio
            ElseIf DaTos(iDat).ktotal < DaTos(iDat).ntubi Or DaTos(1).ktotal < DaTos(iDat).ntubi Then
                MsgBox("Il numero di fori nella corona interna" & vbCrLf & "e/o il numero di fori nella corona esterna" & vbCrLf & "è inferiore al numero di tubi richiesto", MsgBoxStyle.Critical)
                iAction = 9 'impossibile
            Else
                iAction = 1 'bilanciamento
            End If
        End If
        With MainForm
            Select Case iAction
                Case 0 : ._cmdTraccia_2.Text = "Mappa"
                    .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_MAPPA))
                Case 1 : ._cmdTraccia_2.Text = "Bilanc."
                    .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_BILANCIA))
                Case 2
                    If iAgg = 0 Then
                        ._cmdTraccia_2.Text = "Agganc."
                        .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_AGGANCIA))
                    ElseIf iAgg = 1 Then
                        ._cmdTraccia_2.Text = "Infil. "
                        .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_INFILA))
                    ElseIf iAgg = 2 Then
                        ._cmdTraccia_2.Text = "AutoCAD"
                        .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_AUTOCAD))
                    ElseIf iAgg = 3 Then
                        ._cmdTraccia_2.Text = "Seqnz."
                        .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_SEQUENZA))
                    ElseIf iAgg = 4 Then
                        iAgg = 0
                        ._cmdTraccia_2.Text = "Agganc."
                        .HelpProvider1.SetHelpKeyword(._cmdTraccia_2, HelpTopic(IDH_HID_AGGANCIA))
                    End If
                Case 9 ' Color 13: Print "da rifare "
                    'Color 15
            End Select
        End With
    End Function

    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As ChiaviMess = _
                        ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly, _
                        Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "") _
                        As ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(id)) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "Traccia - Messaggi di errore"
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
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "Traccia")
        End If
    End Function

    Sub Nhsym()
        Dim HJ As Short
        Dim i As Short
        'LINDE
        DaTos(iDat).hsym(jsect) = 1
        i = 1
        If DaTos(iDat).CurveInPianoVert And DaTos(iDat).PassoFascio > 2 Then
            i = 2
            If DaTos(iDat).CurveInPianoVert Then
                If jsect = DaTos(iDat).NumeroSettori Then
                    DaTos(iDat).NumeroTubiSettore(jsect - i) = DaTos(iDat).NumeroTubiSettore(jsect)
                Else
                    DaTos(iDat).NumeroTubiSettore(jsect) = DaTos(iDat).NumeroTubiSettore(jsect - i)
                End If
            End If
        End If
        DaTos(iDat).hsym(jsect - i) = 2
        For HJ = nstart To Ni
            DaTos(iDat).ntus(HJ) = DaTos(iDat).NumeroTubiFila(HJ)
        Next
    End Sub

    Sub NoTuadu(ByRef Disax As Single)
103:    If DaTos(iDat).dt(38) <> 0 Then
            dy = DaTos(iDat).dt(38)
            DaTos(iDat).DistSuSettoHor = dy
            DistSuSettoHorvec = DaTos(iDat).DistSuSettoHor
            Exit Sub ' GOTO 13
        End If
        Disax = DaTos(iDat).PassoOrizzontale / 2
        If DaTos(iDat).TipoPasso <> 3 Then
            Disax = CSng(Int(2 * ((DaTos(iDat).dtubo + LarghezzaCavaPerSetto) / 2 + MargineVersoCava) + 0.5) / 2)
        End If
        dy = 2 * Disax
    End Sub
    Function Ordina(ByRef NewDist() As Single, ByRef NewInd() As Short, ByRef indice As Short, ByRef Mode As Short) As Short
        Dim ii As Short
        Dim Distl As Single
        Dim Ind As Short
        If Mode = 1 Then
            For ii = 1 To indice
                If NewDist(ii) < 0 Then NewDist(ii) = -NewDist(ii)
            Next
        End If
        Distl = 1.0E+20
        For ii = 1 To indice
            If NewDist(ii) > 0 And NewDist(ii) < Distl Then
                Distl = NewDist(ii)
                Ind = ii
            End If
        Next
        NewDist(Ind) = -NewDist(Ind)
        Ordina = Ind
    End Function
    Sub RinpCalc(ByRef Disax As Single)
        'LOCATE 2, 3: Beep: Print "R inp.<>R calc.  1 usa R inp.                   "
        'iu$ = INPUT$(1)
        'If iu$ = "1" Then
        Disax = DaTos(iDat).radiu
        DaTos(iDat).dt(21) = DaTos(iDat).radiu
        DaTos(iDat).dt(39) = DaTos(iDat).radiu * 2
        radvec = DaTos(iDat).radiu
        DaTos(iDat).DistSuSettoVer = DaTos(iDat).dt(39)
        'Else
        DaTos(iDat).radiu = Disax : DaTos(iDat).dt(21) = DaTos(iDat).radiu : DaTos(iDat).dt(39) = 2 * DaTos(iDat).radiu
        radvec = DaTos(iDat).radiu : DaTos(iDat).DistSuSettoVer = DaTos(iDat).dt(39)
        'End If
    End Sub

    Sub Rownf()
        Dim Nfile As Short
        Nfile = CShort(Ni - nstart + 1)
        DaTos(iDat).kymax = Ni
        DaTos(iDat).FilaIniziale(jsect) = nstart
        DaTos(iDat).FilaFinale(jsect) = Ni
        DaTos(iDat).NumeroTubiSettore(jsect) = DaTos(iDat).Ntot
        DaTos(iDat).icontr(jsect) = Nfile
    End Sub

    Function Sorvolo(ByRef iActTubo1 As Short, ByRef iActTubo2 As Short, ByRef iCoppia As Short) As Short
        Dim Dist As Single
        Dim lociDat, iTubo As Short
        Dim Dist1, Proiez As Single
        Dim P0 As RoutBase1.clsVec2
        Dim p1 As RoutBase1.clsVec2
        Dim Retta As RoutBase1.clsLinea2
        Dim Punto As RoutBase1.clsVec2
        P0 = New RoutBase1.clsVec2
        p1 = New RoutBase1.clsVec2
        Punto = New RoutBase1.clsVec2
        Retta = New RoutBase1.clsLinea2
        Retta.P0 = P0
        Retta.p1 = p1
        P0.X = PuntiD(iActTubo1, 1).X
        P0.y = PuntiD(iActTubo1, 1).y
        p1.X = PuntiD(iActTubo2, 0).X
        p1.y = PuntiD(iActTubo2, 0).y
        Dist = CSng(System.Math.Sqrt((Retta.p1.X - Retta.P0.X) ^ 2 + (Retta.p1.y - Retta.P0.y) ^ 2))
        Retta.CalcolaDir()
        'controlla che la coppia iCoppia (coppia attuale da montare) non sorvoli buchi vuoti
        Sorvolo = 0
        For lociDat = 0 To 1
            For iTubo = 1 To DaTos(lociDat).ktotal
                If Accoppia(iTubo, lociDat) = 0 And ((iTubo <> iActTubo1 And lociDat = 1) Or (iTubo <> iActTubo2 And lociDat = 0)) Then
                    Punto.X = PuntiD(iTubo, lociDat).X
                    Punto.y = PuntiD(iTubo, lociDat).y
                    Proiez = Retta.Proiez(Punto) '(PuntiD(iTubo, lociDat).X - Retta.P0.X) * Direz.X + (PuntiD(iTubo, lociDat).Y - Retta.P0.Y) * Direz.Y
                    If Proiez > 0 And Proiez < Dist Then
                        Dist1 = Retta.DistPunLinea(Punto)
                        If Dist1 < (DaTos(lociDat).dtubo / 2) * 2 - DaTos(lociDat).Interf Then
                            Sorvolo = CShort(True) : Exit Function
                        End If
                    End If
                End If
            Next
        Next
    End Function
    Function SorvoloRX(ByRef iActTubo1 As Short, ByRef iActTubo2 As Short, _
                       ByRef iActCoppia As Short, ByVal lociDat As Short) As Short
        Dim Retta As New RoutBase1.clsLinea2
        Dim ActRetta As New RoutBase1.clsLinea2
        Dim iTubo1, iCoppia, iTubo2 As Short
        Dim Locale As Boolean
        Dim Proiez, Dist As Single
        Dim Punto1 As New RoutBase1.clsVec2
        Dim Punto2 As New RoutBase1.clsVec2
        Dim Punto3 As New RoutBase1.clsVec2
        Dim Punto4 As New RoutBase1.clsVec2
        Punto1.X = PuntiD(iActTubo1, 1).X
        Punto1.y = PuntiD(iActTubo1, 1).y
        Punto2.X = PuntiD(iActTubo2, 0).X
        Punto2.y = PuntiD(iActTubo2, 0).y
        ActRetta.P0 = Punto1
        ActRetta.p1 = Punto2
        ActRetta.CalcolaDir()
        SorvoloRX = 0
        For iCoppia = 1 To CShort(iActCoppia - 1)
            iTubo1 = IndT1(iCoppia)
            iTubo2 = IndT2(iCoppia)
            If Accoppia(iTubo1, 1) > 0 And PausaRX(iTubo1, 1) Then
                Punto3.X = PuntiD(iTubo1, 1).X
                Punto3.y = PuntiD(iTubo1, 1).y
                Punto4.X = PuntiD(iTubo2, 0).X
                Punto4.y = PuntiD(iTubo2, 0).y
                Retta.P0 = Punto3
                Retta.p1 = Punto4
                Retta.CalcolaDir()
                Select Case ActRetta.Interno(Retta)
                    Case 0, 1 'parallele
                        Locale = True
                        Dist = ActRetta.P0.DistPunPun((ActRetta.p1))
                        Proiez = ActRetta.Proiez((Retta.P0))
                        If Proiez >= 0 And Proiez <= Dist Then
                            Locale = Locale And ActRetta.DistPunLinea((Retta.P0)) > DaTos(lociDat).dtubo - DaTos(iDat).Interf
                        End If
                        Proiez = ActRetta.Proiez((Retta.p1))
                        If Proiez >= 0 And Proiez <= Dist Then
                            Locale = Locale And ActRetta.DistPunLinea((Retta.p1)) > DaTos(lociDat).dtubo - DaTos(iDat).Interf
                        End If
                        SorvoloRX = CShort(Not Locale)
                        If Not Locale Then
                            Exit Function
                        End If
                    Case -1 'intersez interna
                        SorvoloRX = CShort(True)
                        Exit Function
                End Select
            End If
        Next
        Exit Function
    End Function

    Function Spostx() As Boolean
        Dim KNQ, indp As Integer
        If (ZonaUscita Mod 2) = 0 And ZonaUscita <> ControlloZonaUscita.AltezzaData Then indp = 0 Else indp = 1
        If FilaMezzeria = ControlloFilaMezzeria.FilaCentrataTuboCentrato Or FilaMezzeria = ControlloFilaMezzeria.FilaCentrataTuboFuori Then
            KNQ = CShort(Int(-starty / DaTos(iDat).PassoVerticale)) Mod 2
            If FilaMezzeria = ControlloFilaMezzeria.FilaCentrataTuboCentrato Then indp = KNQ Else indp = 1 - KNQ
        End If
        Spostx = CBool(indp)
    End Function

    Function Sub110(ByRef kwritf As Short) As Short
        Dim ymax1, ymax As Single
        Dim KPR As Short
        With DaTos(iDat)
            If ZonaUscita Mod 2 = 1 Then
                kwritf = CShort(kwritf + 1)
                Select Case .PassoFascio
                    Case traccia.clsTracciatura.PassiFascio._1
                        ymax1 = (.icontr(1) - 1) * .PassoVerticale / 2
                    Case traccia.clsTracciatura.PassiFascio._2U, traccia.clsTracciatura.PassiFascio._4U
                        ymax1 = CSng((.icontr(1) - 1) * .PassoVerticale + 0.5 * dy)
                    Case traccia.clsTracciatura.PassiFascio._3, traccia.clsTracciatura.PassiFascio._4croce
                        ymax1 = CSng(((.icontr(1) - 1) + (.icontr(2) - 1) / 2) * .PassoVerticale + dy)
                    Case traccia.clsTracciatura.PassiFascio._4par, traccia.clsTracciatura.PassiFascio._6
                        ymax1 = CSng(((.icontr(1) - 1) + (.icontr(2) - 1)) * .PassoVerticale + 1.5 * dy)
                    Case traccia.clsTracciatura.PassiFascio._6U
                        ymax1 = CSng(((.icontr(1) - 1) + (.icontr(3) - 1) / 2) * .PassoVerticale + dy)
                    Case traccia.clsTracciatura.PassiFascio._8
                        ymax1 = CSng(((.icontr(1) - 1) + .icontr(2) - 1 + (.icontr(4) - 1) / 2) * .PassoVerticale + 2 * dy)
                    Case traccia.clsTracciatura.PassiFascio._8U
                        ymax1 = CSng(((.icontr(1) - 1) + (.icontr(3) - 1)) * .PassoVerticale + 1.5 * dy)
                    Case traccia.clsTracciatura.PassiFascio._10
                        ymax1 = CSng(((.icontr(1) - 1) + .icontr(2) - 1 + (.icontr(4) - 1)) * .PassoVerticale + 2.5 * dy)
                    Case Else
                End Select
                starty = -ymax1
                If ymax1 + 10 > ymax And ymax1 - 10 < ymax And kwritf < 3 Then
                    ymax = ymax1
                    Call Sub58()
                    Sub110 = 1
                End If
            End If
            If .TipoFascio = 3 And .PassoFascio = 2 Then
                .ktotal = CShort(.ktotal / 2)
            ElseIf .CurveInPianoVert And .PassoFascio = 6 Then
                .ktotal = CShort(.ktotal * 2)
            End If
            For KPR = 1 To .kymax
                If .y(KPR) > 0.1 Then
                    .Primafi = .y(KPR - 1)
                    .hin = CShort(.di1 / 2 - .y(Ni) - .dtubo / 2 - Epsilo)
                    If .EsistePiatto Then .hin = CShort(.hin + 9)
                    If .CurveInPianoVert Then .hin = .Hout
                    Exit For
                End If
            Next
        End With
    End Function
    Sub Sub58()
        DeltaPasso = 0 : nteor = kteor
        DaTos(iDat).ktotal = 0 : jsect = 1 : Ni = 0
        DaTos(iDat).Hout = CShort(DaTos(iDat).di1 / 2 - System.Math.Abs(starty) - DaTos(iDat).dtubo / 2 - Epsil1)
    End Sub
    Sub Sub60(ByRef TuboPrimaFilaFuoriCentro As Boolean, ByRef Disax As Single)
        dx = SpostXSettore(jsect)
        Indexx = 0
        nstart = CShort(Ni + 1)
        If TuboPrimaFilaFuoriCentro And jsect = 1 And dx = 0 Then DeltaPasso = DaTos(iDat).PassoOrizzontale / 2
        If Not (DaTos(iDat).PassoFascio < 2 Or ZonaUscita < 1 Or ZonaUscita > 3) Then
            If DaTos(iDat).TipoPasso < 3 And starty > 0 Then
                DeltaPasso = delp(imi0, 1)
                idelp = CShort(delp(imi0, 2))
                imi0 = CShort(imi0 - 1)
                Exit Sub
            End If
        End If
        If DaTos(iDat).TipoPasso = 4 And DaTos(iDat).PassoFascio > 4 And dx = 0 Then DeltaPasso = Disax
    End Sub

    Sub SuperCentro(ByRef KCONT As Short)
        If KCONT = 1 Then Call Tagl()
        Call CENTRO()
        Call Tagl()
    End Sub

    Sub SuperDiadif(ByRef DiaframmiTight As Boolean)
        If DiaframmiTight Then
23:         Call Tracciatura.diadiffe()
30:         DaTos(iDat).OTL = DaTos(iDat).di1 - GiocoDiaframmi
            If DaTos(iDat).MassimizzaOTL Then DaTos(iDat).otimp = DaTos(iDat).OTL
            'DaTos(iDat).otimp = 0
        Else
            GiocoDiaframmi = DaTos(iDat).di1 - DaTos(iDat).OTL
        End If
        DaTos(iDat).yin = 0 : DaTos(iDat).yout = 0
    End Sub

    Sub SuperYinout(ByRef keyy As Short)
        If DaTos(iDat).VaporBelt Then Exit Sub
        If QualeCorona = 2 Then Exit Sub
        DaTos(iDat).yin = DaTos(iDat).y0in : DaTos(iDat).yout = DaTos(iDat).y0out
        If DaTos(iDat).yin = 0 Or DaTos(iDat).yout = 0 Then GoTo 33
        If Not (DaTos(iDat).CurveInPianoVert And DaTos(iDat).yin <> DaTos(iDat).yout Or UscitaSimmetrica) Then GoTo 33
        If DaTos(iDat).yout > DaTos(iDat).yin Then DaTos(iDat).yin = DaTos(iDat).yout
        DaTos(iDat).yout = DaTos(iDat).yin : Exit Sub
33:     Call YINOUT()
        If Not (DaTos(iDat).CurveInPianoVert And DaTos(iDat).yin <> DaTos(iDat).yout Or UscitaSimmetrica) Then Exit Sub
        If DaTos(iDat).yout > DaTos(iDat).yin Then DaTos(iDat).yin = DaTos(iDat).yout
        DaTos(iDat).yout = DaTos(iDat).yin
        kwrite = 0 : keyy = 0
    End Sub

    Sub Tagl()
        If DaTos(iDat).dt(30) <> 0 Then DaTos(iDat).Tagl = (DaTos(iDat).di1 / 2) * (1 - System.Math.Abs(DaTos(iDat).dt(30)) / 50)
        If DaTos(iDat).dt(32) = 1 Then DaTos(iDat).XYBLOK = DaTos(iDat).Tagl - DaTos(iDat).dtubo / 2
    End Sub

    Sub Tubiadu(ByRef Disax As Single)
        Dim Disax3 As Single
        If DaTos(iDat).dt(21) <> 0 Then
            DaTos(iDat).radiu = DaTos(iDat).dt(21)
            Disax3 = DaTos(iDat).radiu
        Else
            Disax3 = CSng(1.5 * DaTos(iDat).dtubo) 'Int(2 * (1.5 * DaTos(iDat).dtubo) + 0.5) / 2 'min r curv
        End If
        Disax = CSng(Int(2 * ((DaTos(iDat).dtubo + LarghezzaCavaPerSetto) / 2 + MargineVersoCava) + 0.5) / 2)
        'If DaTos(iDat).TipoPasso = 3 Then Disax = Datos(iDat).PassoOrizzontale
        'LINDE
        If Not (DaTos(iDat).PassoFascio = clsTracciatura.PassiFascio._2U Or _
               (DaTos(iDat).PassoFascio = clsTracciatura.PassiFascio._4U And _
                DaTos(iDat).CurveInPianoVert)) Then GoTo 101
        If Disax > Disax3 Then Disax3 = Disax
        If Disax3 < DaTos(iDat).radiu Then Disax3 = DaTos(iDat).radiu
        If DaTos(iDat).TipoPasso <> clsTracciatura.TipiPasso._45 Then
            'Disax = Disax3 '??????
            'LINDE remmato
        Else
            If DaTos(iDat).FilaCentraleStorta Then
                Disax3 = CSng(System.Math.Sqrt(Disax3 * Disax3 - DaTos(iDat).PassoOrizzontale * DaTos(iDat).PassoOrizzontale / 4))
            End If
        End If
        If DaTos(iDat).radiu = 0 Then
            DaTos(iDat).radiu = Disax3
            DaTos(iDat).dt(21) = Disax3
            radvec = DaTos(iDat).radiu
        End If
        If DaTos(iDat).dt(38) > DaTos(iDat).dt(21) * 2 Then 'dist tra tubi e setto orizz
            DaTos(iDat).dt(21) = DaTos(iDat).dt(38) / 2
            Disax3 = DaTos(iDat).dt(21)
            If Not DaTos(iDat).FilaCentraleStorta Then
                DaTos(iDat).radiu = DaTos(iDat).dt(21)
            Else
                DaTos(iDat).radiu = CSng(System.Math.Sqrt(DaTos(iDat).dt(21) ^ 2 + (DaTos(iDat).PassoOrizzontale / 2) ^ 2))
            End If
            radvec = DaTos(iDat).radiu
        Else
            If Not DaTos(iDat).FilaCentraleStorta Then
                DaTos(iDat).dt(38) = 2 * DaTos(iDat).radiu
            Else
                DaTos(iDat).dt(38) = CSng(2 * System.Math.Sqrt(DaTos(iDat).radiu ^ 2 - (DaTos(iDat).PassoOrizzontale / 2) ^ 2))
            End If
            DaTos(iDat).DistSuSettoHor = DaTos(iDat).dt(38)
            DistSuSettoHorvec = DaTos(iDat).dt(38)
        End If
        dy = 2 * Disax3
        '           Disax = Int(2 * ((DaTos(iDat).dtubo + LarghezzaCavaPerSetto) / 2 + MargineVersoCava) + 0.5) / 2
        Exit Sub 'GOTO 13
101:    dy = Disax
        If DaTos(iDat).TipoPasso <> 3 Then
            dy = 2 * Disax
            If DaTos(iDat).dt(38) <> 0 Then
                dy = DaTos(iDat).dt(38)
                DaTos(iDat).DistSuSettoHor = dy
                DistSuSettoHorvec = DaTos(iDat).DistSuSettoHor
            End If
            Disax = Disax3
        Else
            If dy < ((DaTos(iDat).dtubo + LarghezzaCavaPerSetto) / 2 + MargineVersoCava) Then dy = 3 * DaTos(iDat).PassoVerticale
            If DaTos(iDat).dt(38) <> 0 Then
                dy = DaTos(iDat).dt(38)
                DaTos(iDat).DistSuSettoHor = dy
                DistSuSettoHorvec = DaTos(iDat).DistSuSettoHor
            End If
        End If 'GOTO 13
        'GOTO 13
    End Sub

    Function VerifInters(ByRef p1 As RoutBase1.clsVec2, ByRef p2 As RoutBase1.clsVec2) As Short
        Dim Vect1 As New RoutBase1.clsVec2
        Dim Vect2 As New RoutBase1.clsVec2
        Dim Prod1, Prod2 As Single
        Dim CentroC As RoutBase1.clsVec2
        Dim clP1 As RoutBase1.clsVec2
        Dim clP2 As RoutBase1.clsVec2
        Dim Retta As RoutBase1.clsLinea2
        Dim Punti As RoutBase1.clsPunti
        Dim iCheck, j As Short
        Dim n1, n2 As Short
        If DaTos(1).cinter < (DaTos(iDat).dtubo / 2) Then VerifInters = CShort(True) : Exit Function
        'verifica sormonto con tubo centrale------------------------------
        CentroC = New RoutBase1.clsVec2 : CentroC.X = 0 : CentroC.y = 0
        clP1 = New RoutBase1.clsVec2 : clP1.X = p1.X : clP1.y = p1.y
        clP2 = New RoutBase1.clsVec2 : clP2.X = p2.X : clP2.y = p2.y
        Retta = New RoutBase1.clsLinea2
        Retta.P0 = clP1 : Retta.p1 = clP2
        Retta.CalcolaDir()
        Punti = New RoutBase1.clsPunti
        Punti.Inizia(4)
        Retta.InterRettCerch((DaTos(iDat).dtubo / 2), CentroC, DaTos(1).cinter, Punti, n1, n2)
        iCheck = CShort(True)
        For j = 1 To 4
            If n1 > 0 And j < 3 Or n2 > 0 And j > 2 Then
                Vect1.X = Punti.Punti.Item(j).TextData.X - p1.X
                Vect1.y = Punti.Punti.Item(j).TextData.y - p1.y
                Vect2.X = Punti.Punti.Item(j).TextData.X - p2.X
                Vect2.y = Punti.Punti.Item(j).TextData.y - p2.y
                Prod1 = Vect1.X * Retta.Direz.X + Vect1.y * Retta.Direz.y
                Prod2 = Vect2.X * Retta.Direz.X + Vect2.y * Retta.Direz.y
                If Prod1 * Prod2 < 0 Then iCheck = 0
            End If
        Next
        VerifInters = iCheck
    End Function
    Sub datiout(ByRef Mode As Short)
        'Mode=1 da calc4sp
        Dim j, k As Short
        Dim x, y, h As Single
        CalcOTL(0)
        If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then CalcOTL(1)
        Try
            With MainForm
                Dim g As Graphics = gRisult
                Dim f As Font = New Drawing.Font("Courier New", 8, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
                .pctRisult.Visible = True
                .panRisult.Visible = True
                g.Clear(Color.Wheat)
                x = 0 : y = 0
                g.DrawString(GlobalRoutines.FormatS(at1(159), DaTos(0).di1), f, .b, x, y)
                h = g.MeasureString("A", f).Height
                y = y + h
                g.DrawString(GlobalRoutines.FormatS(at1(160), DaTos(0).OTL), f, .b, x, y)
                y = y + h
                If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
                    '                g.DrawString(GlobalRoutines.FormatS(at1(161), DaTos(1).di1), f, .b, x, y)
                    '               y = y + h
                    g.DrawString(GlobalRoutines.FormatS(at1(162), DaTos(1).OTL), f, .b, x, y)
                    y = y + h
                End If
                If DaTos(0).cinter > 0 Then
                    g.DrawString(GlobalRoutines.FormatS(at1(163), DaTos(0).cinter * 2), f, .b, x, y)
                    y = y + h
                End If
                If UBound(DaTos) = 1 Then
                    If DaTos(1).cinter > 0 Then
                        g.DrawString(GlobalRoutines.FormatS(at1(164), DaTos(1).cinter * 2), f, .b, x, y)
                        y = y + h
                    End If
                End If
                If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
                    g.DrawString(GlobalRoutines.FormatS(at1(165), DaTos(0).ntubi), f, .b, x, y)
                    y = y + h
                Else
                    g.DrawString(GlobalRoutines.FormatS(at1(165), DaTos(0).ktotal), f, .b, x, y)
                    y = y + h
                End If
                If DaTos(0).VaporBelt Then
                    g.DrawString(at1(211), f, .b, x, y) '"* APPARECCHIO"
                    y = y + h
                    g.DrawString(at1(212), f, .b, x, y) '"  CON BELT *"
                    y = y + h
                Else
                    g.DrawString(GlobalRoutines.FormatS(at1(166).Substring(0, 13), DaTos(0).hin), f, .b, x, y) 'H RINL
                    y = y + h
                    g.DrawString(GlobalRoutines.FormatS(at1(167).Substring(0, 13), DaTos(0).Hout), f, .b, x, y) 'H ROUT
                    y = y + h
                End If
                g.DrawString(GlobalRoutines.FormatS(at1(168), DaTos(0).DistSuSettoHor), f, .b, x, y)
                y = y + h
                g.DrawString(GlobalRoutines.FormatS(at1(169), DaTos(0).DistSuSettoVer), f, .b, x, y)
                y = y + h
                g.DrawString(GlobalRoutines.FormatS(at1(170), DaTos(0).Primafi), f, .b, x, y)
                y = y + h
                g.DrawString(GlobalRoutines.FormatS(at1(171), DaTos(0).y(1)), f, .b, x, y)
                y = y + h
                If DaTos(0).PassoFascio = traccia.clsTracciatura.PassiFascio._1 Then Exit Sub
                k = 0
                For j = DaTos(0).NumeroSettori To 1 Step -1
                    If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
                        g.DrawString(GlobalRoutines.FormatS(at1(172), DaTos(0).NumeroTubiSettore(j)), f, .b, x, y)
                        y = y + h
                        g.DrawString(GlobalRoutines.FormatS(at1(173), DaTos(1).NumeroTubiSettore(j)), f, .b, x, y)
                        y = y + h
                    ElseIf (DaTos(0).hsym(j) <> 1 Or DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube) _
                    And Not (DaTos(0).PassoFascio > 2 And DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube) Then
                        If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube Then
                            g.DrawString(GlobalRoutines.FormatS(at1(174), DaTos(0).NumeroTubiSettore(j - 1)), f, .b, x, y)
                            j = CShort(j - 1)
                            g.DrawString(" U", f, .b, x, y)
                            y = y + h
                        Else
                            g.DrawString(GlobalRoutines.FormatS(at1(174), DaTos(0).NumeroTubiSettore(j)), f, .b, x, y)
                            y = y + h
                        End If
                    Else
                        g.DrawString(GlobalRoutines.FormatS(at1(175), DaTos(0).NumeroTubiSettore(j - 1), DaTos(0).NumeroTubiSettore(j)), f, .b, x, y)
                        y = y + h
                        If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube Then
                            g.DrawString(" U", f, .b, x, y)
                            y = y + h
                            'Else
                            ' g.DrawString()
                            'y = y + h
                        End If
                        j = CShort(j - 1)
                    End If
                    k = CShort(k + 1)
                Next j
                If Mode = 1 Then
                    g.DrawString(GlobalRoutines.FormatS(at1(176), Tracciatura.Perim), f, .b, x, y)
                    y = y + h
                    g.DrawString(GlobalRoutines.FormatS(at1(177), Tracciatura.Area), f, .b, x, y)
                    y = y + h
                    g.DrawString(GlobalRoutines.FormatS(at1(178), Tracciatura.Diaml), f, .b, x, y)
                    y = y + h
                End If
                f.Dispose()
                .pctRisult.Refresh()
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function iSector(ByRef p As RoutBase1.clsVec2) As Short
        Select Case p.X
            Case Is < 0
                Select Case p.y
                    Case Is < 0 : iSector = 1
                    Case Is > 0 : iSector = 2
                End Select
            Case Is > 0
                Select Case p.y
                    Case Is < 0 : iSector = 4
                    Case Is > 0 : iSector = 3
                End Select
        End Select
    End Function
    Private Function iOkk(ByRef i1 As Short, ByRef i2 As Short) As Boolean
        If i1 = 4 Then
            iOkk = i2 < 2
        Else
            iOkk = (i2 = i1 + 1)
        End If
    End Function
    Public Sub Riordino(ByVal lociDat As Short)
        ReDim IndiceCoppia(DaTos(lociDat).ktotal)
        ReDim OrdineFinale(DaTos(lociDat).ktotal)
        ReDim PausaRX(DaTos(lociDat).ktotal, 1)
        ReDim MarcaPausa(DaTos(lociDat).ktotal)
        ReDim Accoppia(DaTos(lociDat).ktotal, 1)
        'provvisorio
        If DaTos(lociDat).Anomal0 > 360 Or DaTos(lociDat).Anomal0 < -360 Then DaTos(lociDat).Anomal0 = 0
        Anomal0 = CSng((360 - (DaTos(lociDat).Anomal0 + DaTos(lociDat).Varco / 2)) * System.Math.PI / 180)
        '----------------
        doc = Monitor.Motore.Inizio.CommPulita(Trim(gencommes)) & "-TU-01"
        ntubi = DaTos(lociDat).ktotal
        Revisione = "00"
        Pagina = 1
        ifl1 = CShort(FreeFile())
        FileOpen(ifl1, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\TUBUSE.RTF", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 20 : StriSt(i) = LineInput(ifl1) : Next
        FileSt = gencommes.Trim & ".SEQ" 'RTrim$(Datidir) + "\" + RTrim$(gencommes)
        FileClose(ifl1)
        RiordB2()
        If Len(Dir(FileSt)) > 0 Then
            If MsgBox("Esiste già una specifica di sequenza. Vuoi usarla?", VB.MsgBoxStyle.YesNo Or VB.MsgBoxStyle.Question) = MsgBoxResult.Yes Then GoTo Fine
        End If
        CoorInMem()
        For iCoppia = 1 To ntubi
            IndiceCoppia(iCoppia) = iCoppia
        Next
        For iCoppia = 1 To CShort(ntubi - 1)
            For i = CShort(iCoppia + 1) To ntubi
                '   If i <> iCoppia Then
                iTubo = IndT1(IndiceCoppia(iCoppia))
                j = IndT2(IndiceCoppia(iCoppia))
                ii = IndT1(IndiceCoppia(i))
                iii = IndT2(IndiceCoppia(i))
                Alfa1 = Anomal(iTubo, 1) + Anomal0
                '                     Alfa1 = Anomal(j, 0) + Anomal0
                If Alfa1 > 2 * System.Math.PI Then Alfa1 = CSng(Alfa1 - 2 * System.Math.PI)
                If Alfa1 < 0 Then Alfa1 = CSng(Alfa1 + 2 * System.Math.PI)
                Alfa2 = Anomal(ii, 1) + Anomal0
                If Alfa2 < 0 Then Alfa2 = CSng(Alfa2 + 2 * System.Math.PI)
                '                     Alfa2 = Anomal(iii, 0) + Anomal0
                If Alfa2 > 2 * System.Math.PI Then Alfa2 = CSng(Alfa2 - 2 * System.Math.PI) '1 centro 0 periferia
                '------------------------------------------------------
                If Alfa1 > Alfa2 + 0.01 Then
                    GlobalRoutines.SWAP(IndiceCoppia(iCoppia), IndiceCoppia(i))
                ElseIf System.Math.Abs(Alfa1 - Alfa2) < 0.01 Then
                    If DistCentro(iTubo, 1) < DistCentro(ii, 1) Then
                        GlobalRoutines.SWAP(IndiceCoppia(iCoppia), IndiceCoppia(i))
                    End If
                End If
                '-----------------------------------------------------
                '                If Abs(Alfa1 - Alfa2) < 90 * PI / 180 Then
                '                 If DistCentro(iTubo, 1) < DistCentro(ii, 1) Then
                '                    SWAP IndiceCoppia(iCoppia), IndiceCoppia(i)
                '                 End If
                '                ElseIf Alfa1 > Alfa2 + 0.01 Then
                '                 SWAP IndiceCoppia(iCoppia), IndiceCoppia(i)
                '                End If
                '  End If
            Next
        Next
        SubTraccia(0)
        '        MainForm.Picture1.FillStyle = vbFSSolid
        iC = 0
        For Fase = 1 To 2
            If Fase = 1 And DaTos(lociDat).Varco = 360 Then GoTo Skip
Rif:        For iCoppia = 1 To ntubi
                Candidato = IndiceCoppia(iCoppia)
                iTubo1 = IndT1(Candidato)
                iTubo2 = IndT2(Candidato)
                If Accoppia(iTubo1, 1) = 0 Then
                    If Sorvolo(iTubo1, iTubo2, Candidato) <> 0 Then
                        'Stop
                    Else
                        If Anteriore(iTubo1, iTubo2, Candidato, lociDat) Then
                            Alfa1 = CSng(2 * System.Math.PI - Anomal0)
                            Alfa2 = CSng(2 * System.Math.PI - Anomal0 - DaTos(lociDat).Varco * System.Math.PI / 180)
                            'If Alfa2 > 2 * PI Then Alfa2 = Alfa2 - 2 * PI
                            If Not (Fase = 1 And Anomal(iTubo1, 1) > Alfa2 And Anomal(iTubo1, 1) < Alfa1) Then
                                If Fase = 2 Or Fase = 1 And SorvoloRX(iTubo1, iTubo2, Candidato, lociDat) = 0 Then
                                    '-----------------------------------------------------------------
                                    If Fase = 2 And False Then
                                        DistMin = 1.0E+20
                                        jmin = 0
                                        For j = 1 To ntubi
                                            Candidato = IndiceCoppia(j)
                                            iTubo1 = IndT1(Candidato)
                                            iTubo2 = IndT2(Candidato)
                                            If Accoppia(iTubo1, 1) = 0 Then
                                                If Sorvolo(iTubo1, iTubo2, Candidato) = 0 Then
                                                    If Anteriore(iTubo1, iTubo2, Candidato, lociDat) Then
                                                        Dist = DistCentro(iTubo1, 1)
                                                        If Dist < DistMin Then
                                                            DistMin = Dist
                                                            jmin = j
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next
                                        If iCoppia <> jmin And jmin > 0 Then
                                            Candidato = IndiceCoppia(jmin)
                                            iTubo1 = IndT1(Candidato)
                                            iTubo2 = IndT2(Candidato)
                                            GlobalRoutines.SWAP(IndiceCoppia(iCoppia), IndiceCoppia(jmin))
                                            iCoppia = 0
                                        Else
                                            Candidato = IndiceCoppia(iCoppia)
                                            iTubo1 = IndT1(Candidato)
                                            iTubo2 = IndT2(Candidato)
                                        End If
                                    End If
                                    '----------------------------------------------------------------------
                                    iC = CShort(iC + 1) : OrdineFinale(iC) = Candidato
                                    Accoppia(iTubo1, 1) = Candidato
                                    Accoppia(iTubo2, 0) = Candidato
                                    PausaRX(iTubo1, 1) = True
                                    PausaRX(iTubo2, 0) = True
                                    If Fase = 2 Then
                                        If CBool(SorvoloRX(iTubo1, iTubo2, Candidato, lociDat)) Then
                                            For iii = 1 To ntubi
                                                If Not iii = iTubo1 Then PausaRX(iii, 1) = False
                                                If Not iii = iTubo2 Then PausaRX(iii, 0) = False
                                            Next
                                            MarcaPausa(Candidato) = 1
                                        End If
                                    End If
                                    With MainForm
                                        xtub = PuntiD(iTubo1, 1).X : ytub = PuntiD(iTubo1, 1).y
                                        .g.DrawEllipse(.p, xtub, ytub, 2 * (DaTos(lociDat).dtubo / 2), 2 * (DaTos(lociDat).dtubo / 2))
                                        xtub = PuntiD(iTubo2, 0).X : ytub = PuntiD(iTubo2, 0).y
                                        .g.DrawEllipse(.p, xtub, ytub, 2 * (DaTos(lociDat).dtubo / 2), 2 * (DaTos(lociDat).dtubo / 2))
                                        'MainForm.Refresh()
                                    End With
                                    If Fase = 2 Then iCoppia = 0 '??????????????????????????
                                End If
                            End If
                        Else
                            'Stop
                        End If
                    End If
                End If
            Next
            If Fase = 1 Then
                For iTubo1 = 1 To ntubi
                    If PausaRX(iTubo1, 1) Then
                        For iTubo2 = 1 To ntubi
                            PausaRX(iTubo2, 1) = False
                            PausaRX(iTubo2, 0) = False
                        Next
                        MarcaPausa(OrdineFinale(iC)) = 1
                        GoTo Rif
                    End If
                Next
            End If
Skip:   Next
        Monitor.Motore.PrepRapp(FileSt)
        TestaVec()
        Try
            For iCoppia = 1 To ntubi
                Candidato = OrdineFinale(iCoppia)
                Franco.recB2 = CType(Franco.Manici.nRB2.ItemAt(Candidato), typrecB2)
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(19), iCoppia, Candidato, Franco.recB2.Raggio, Franco.recB2.Altezza, Franco.recB2.posizione))
                iRiga = CShort(iRiga + 1)
                If MarcaPausa(Candidato) = 1 Then
                    iRiga = CShort(iRiga + 1)
                    iPausa = CShort(iPausa + 1)
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(20), iPausa))
                End If
                If iRiga >= 70 Then
                    Pagina = CShort(Pagina + 1)
                    Monitor.Motore.Problem.Printa("{\par \page }")
                    TestaVec()
                End If
            Next
            Monitor.Motore.Problem.Printa("}")
            ' FileClose(iUnit)
            Monitor.Motore.Problem.FineRapp()
            FileClose(ifl1)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
Fine:   Try
            Monitor.Motore.Inizio.SuperStampa(FileSt, StubWord)
        Catch e As Exception
            Riga = "Autorizzazione negata ad aprire in scrittura" & vbCrLf
            Riga = Riga & "il file di stampa " & FileSt & "." & vbCrLf
            Riga = Riga & "Controllare se è occupato da Winword"
            Err.Clear()
            If MsgBox(Riga, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then GoTo Fine
        End Try
    End Sub
    Private Sub RiordB2()
        Try
            Dim FileRB2 As String = gencommes.Trim & ".RB2"
            Dim fs As New FileStream(FileRB2, FileMode.Open)
            Dim bf As New BinaryFormatter
            Dim j As Short
            Franco.Manici.nRB2 = CType(bf.Deserialize(fs), OggList)
            fs.Close()
            For iii = 1 To ntubi
                ii = CShort(CType(Franco.Manici.nRB2.ItemAt(iii), typrecB2).Sigla)
                If ii <> iii Then
                    For j = CShort(iii + 1) To ntubi
                        If CShort(CType(Franco.Manici.nRB2.ItemAt(j), typrecB2).Sigla) = iii Then Exit For
                    Next
                    If j > ntubi Then
                        MsgBox("Errore impossibile in RiordB2")
                        Exit For
                    Else
                        GlobalRoutines.SWAP(Franco.Manici.nRB2.ItemAt(iii), Franco.Manici.nRB2.ItemAt(j))
                        ' iii = CShort(iii - 1)
                    End If
                End If
            Next
            File.Delete(FileRB2)
            fs = New FileStream(gencommes.Trim & ".RB2", FileMode.Create)
            bf.Serialize(fs, Franco.Manici.nRB2)
            fs.Close()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub TestaVec() '**************************
        If Not Intest = 0 Then
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(1), Monitor.Motore.Inizio.Firma))
            Monitor.Motore.Problem.Printa(StriSt(2))  ' "                      =========================="
        Else
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(3), Monitor.Motore.Inizio.Firma, doc, Revisione))  '"1\  \                 FBM-HUDSON ITALIANA S.p.A.                 DOC.nø \          \"
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(4), Str(Pagina)))  '"                      ==========================                    sheet.nø ......."
        End If
        If Pagina = 1 Then
            Monitor.Motore.Problem.Printa(StriSt(5))
            LaData = CStr(Today)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(6), Monitor.Motore.Inizio.CommPulita(Trim(gencommes)), LaData))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(7), Monitor.Motore.Inizio.CommPulita(Trim(gencommes)) & "-TU-00"))
            Monitor.Motore.Problem.Printa(StriSt(8))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(9), DaTos(iDat).Interf))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(10), DaTos(iDat).GapCurve))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(11), DaTos(iDat).Varco))
            For i = 12 To 17
                Monitor.Motore.Problem.Printa(StriSt(i))
            Next
            iRiga = 30
        Else
            iRiga = 10
        End If
        Monitor.Motore.Problem.Printa(StriSt(18))
    End Sub
    Private Function Anteriore(ByRef iActTubo1 As Short, ByRef iActTubo2 As Short, _
                               ByRef iActCoppia As Short, ByVal lociDat As Short) As Boolean
        Dim Retta As New RoutBase1.clsLinea2
        Dim ActRetta As New RoutBase1.clsLinea2
        Dim iTubo1, iCoppia, iTubo2 As Short
        Dim Locale As Boolean
        Dim Proiez, Dist As Single
        Dim Punto1 As New RoutBase1.clsVec2
        Dim Punto2 As New RoutBase1.clsVec2
        Dim Punto3 As New RoutBase1.clsVec2
        Dim Punto4 As New RoutBase1.clsVec2
        Punto1.X = PuntiD(iActTubo1, 1).X
        Punto1.y = PuntiD(iActTubo1, 1).y
        Punto2.X = PuntiD(iActTubo2, 0).X
        Punto2.y = PuntiD(iActTubo2, 0).y
        ActRetta.P0 = Punto1
        ActRetta.p1 = Punto2
        ActRetta.CalcolaDir()
        Anteriore = True
        For iCoppia = 1 To CShort(iActCoppia - 1)
            iTubo1 = IndT1(iCoppia)
            iTubo2 = IndT2(iCoppia)
            If Accoppia(iTubo1, 1) = 0 Then
                Punto3.X = PuntiD(iTubo1, 1).X
                Punto3.y = PuntiD(iTubo1, 1).y
                Punto4.X = PuntiD(iTubo2, 0).X
                Punto4.y = PuntiD(iTubo2, 0).y
                Retta.P0 = Punto3
                Retta.p1 = Punto4
                Retta.CalcolaDir()
                Select Case ActRetta.Interno(Retta)
                    Case 0, 1 'parallele
                        Locale = True
                        Dist = ActRetta.P0.DistPunPun((ActRetta.p1))
                        Proiez = ActRetta.Proiez((Retta.P0))
                        If Proiez >= 0 And Proiez <= Dist Then
                            Locale = Locale And ActRetta.DistPunLinea((Retta.P0)) > DaTos(lociDat).dtubo - DaTos(lociDat).Interf
                        End If
                        Proiez = ActRetta.Proiez((Retta.p1))
                        If Proiez >= 0 And Proiez <= Dist Then
                            Locale = Locale And ActRetta.DistPunLinea((Retta.p1)) > DaTos(lociDat).dtubo - DaTos(lociDat).Interf
                        End If
                        Anteriore = Locale
                        If Not Locale Then
                            Exit Function
                        End If
                    Case -1 'intersez interna
                        Anteriore = False
                        Exit Function
                End Select
            End If
        Next
        Exit Function
    End Function

    Private Sub RiDim()
        Dim i As Short, j As Short
        Static ntubo As Short
        Dim n As Short = Math.Max(DaTos(0).ktotal, DaTos(1).ktotal)
        If n = ntubo Then Exit Sub
        ntubo = n
        ReDim DistCentro(ntubo, 1)
        ReDim Anomal(ntubo, 1)
        ReDim Fila(ntubo, 1)
        ReDim Posizbu(ntubo, 1)
        ReDim PuntiD(ntubo, 1)
        ReDim Settore(ntubo, 1)
        For i = 1 To ntubo
            For j = 0 To 1
                PuntiD(i, j) = New clsVec2(0, 0)
            Next
        Next
    End Sub
    Function otielle(ByRef xpu As Single, ByRef ypu As Single, ByRef otvec As Single, ByRef dtu As Single) As Single
        Dim otnuo As Single
        otnuo = CSng(2 * System.Math.Sqrt(xpu * xpu + ypu * ypu) + dtu)
        otielle = otvec
        If otnuo > otvec Then otielle = otnuo
    End Function

    Sub CENTRO()
        OTC = DaTos(iDat).OTL - DaTos(iDat).dtubo
        starty0 = starty
        If UscitaSimmetrica And starty0 = -9999 And Indexx = 0 Then
            KNP = CShort(KNP - 1)
            If Not EpariNumeroSetti And KNP Mod 2 <> 0 Then KNP = CShort(KNP - 1)
            If NumeroSetti = 0 And KNP Mod 2 <> 0 Then KNP = CShort(KNP - 1)
            starty = -(dy * NumeroSetti + KNP * DaTos(iDat).PassoVerticale) / 2
            ymaxd = -starty : Exit Sub
        End If
        ymaxd = Int(2 * (OTC / 2 - DaTos(iDat).yin) + OTC / 200) / 2
        If ymaxd > (OTC / 2) Then ymaxd = OTC / 2
        VNP = (OTC - DaTos(iDat).yin - DaTos(iDat).yout - dy * NumeroSetti) / DaTos(iDat).PassoVerticale
        KNP = CShort(Int(VNP))
        starty = -OTC / 2 + DaTos(iDat).yout + (VNP - KNP) * DaTos(iDat).PassoVerticale / 2
        If Not FilaMezzeria = ControlloFilaMezzeria.NessunControllo Then
            KNQ = CShort(-starty * 2 / DaTos(iDat).PassoVerticale)
            Select Case FilaMezzeria
                Case ControlloFilaMezzeria.FilaCentrataTuboCentrato, ControlloFilaMezzeria.FilaCentrataTuboFuori
                    If (KNQ Mod 2) = 1 Then KNQ = CShort(KNQ - 1)
                Case ControlloFilaMezzeria.FilaFuori
                    If (KNQ Mod 2) = 0 Then KNQ = CShort(KNQ - 1)
            End Select
            starty = -KNQ * DaTos(iDat).PassoVerticale / 2
        End If
        If DaTos(iDat).dt(32) = 1 And DaTos(iDat).dt(31) = 0 Then
            '???tipo diafr. single senza piatto d'urto
            If starty < -DaTos(iDat).XYBLOK Then
                VNP = (DaTos(iDat).XYBLOK - dy * NumeroSetti / 2) / DaTos(iDat).PassoVerticale : KNP = CShort(Int(VNP))
                starty = -DaTos(iDat).XYBLOK + (VNP - KNP) * DaTos(iDat).PassoVerticale : ymaxd = DaTos(iDat).XYBLOK
            End If
        End If
        'simmetrico--------------
        If UscitaSimmetrica Then
            If Not EpariNumeroSetti And KNP Mod 2 <> 0 Then KNP = CShort(KNP - 1)
            If NumeroSetti = 0 And KNP Mod 2 <> 0 Then KNP = CShort(KNP - 1)
            starty = -(dy * NumeroSetti + KNP * DaTos(iDat).PassoVerticale) / 2
            ymaxd = -starty : Exit Sub
        End If
        '       VNQ = (OTC / 2 - DaTos(iDat).yout) / Datos(iDat).PassoVerticale: KNQ = INT(VNQ)
        '       IF DaTos(iDat).TipoPasso <= 2 AND DaTos(iDat).PassoFascio = 1 OR DaTos(iDat).TipoPasso = 3 THEN
        '!!!!!!!    starty =  - KNQ * Datos(iDat).PassoVerticale
        '           PRINT "intero1"; starty / Datos(iDat).PassoVerticale; -OTC / 2; DaTos(iDat).yout; VNQ; KNQ
        '       END IF
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube Then
            VNQ = (OTC / 2 - DaTos(iDat).yout - dy / 2) / DaTos(iDat).PassoVerticale
            KNQ = CShort(Int(VNQ))
            If DaTos(iDat).PassoFascio = traccia.clsTracciatura.PassiFascio._2U Then
                starty = -OTC / 2 + DaTos(iDat).yout + (VNQ - KNQ) * DaTos(iDat).PassoVerticale
            End If
        End If
        '       IF DaTos(iDat).TipoPasso = 4 AND DaTos(iDat).PassoFascio = 1 AND DaTos(iDat).TipoFascio < 3 THEN
        '          RIF = .5: OT2 = OTC / 2 - DaTos(iDat).yout: ZEN = OT2 / Datos(iDat).PassoVerticale
        '          KZEN = INT(ZEN): RIF1 = ZEN - KZEN
        '          starty = (-KZEN - RIF) * Datos(iDat).PassoVerticale
        '          PRINT "intero5"; starty / Datos(iDat).PassoVerticale; -OT2; RIF1; RIF
        '          IF RIF1 < RIF THEN starty = -KZEN * Datos(iDat).PassoVerticale
        '       END IF
        If System.Math.Abs(starty) > (OTC / 2) Then starty = -OTC / 2
    End Sub

    Public Function Dati(Optional ByRef Breve As Boolean = False) As Boolean
        Dim ivec, i As Short
        Call nuovi()
        If Breve Then Exit Function
        Call CheckDati()
        kdati = 1
        Dati = True
        If DaTos(iDat).di0 > divec + 10 Or DaTos(iDat).di0 < divec - 5 Then ivec = 1 : GoTo 297
        If dtivec <> DaTos(iDat).dtin Or dtovec <> DaTos(iDat).dtout Then ivec = 2 : GoTo 297
        If roivec <> DaTos(iDat).roin Or winvec <> DaTos(iDat).win Then ivec = 3 : GoTo 297
        If roovec <> DaTos(iDat).roout Or wouvec <> DaTos(iDat).wout Then ivec = 4 : GoTo 297
        If y0ivec <> DaTos(iDat).y0in Or y0ovec <> DaTos(iDat).y0out Then ivec = 5 : GoTo 297
        If ntuvec <> DaTos(iDat).ntubi Then ivec = 6 : GoTo 297
        If jpvec <> DaTos(iDat).TipoPasso Or jtvec <> DaTos(iDat).PassoFascio Or jshvec <> DaTos(iDat).TipoFascio Then ivec = 7 : GoTo 297
        If dtubvec <> DaTos(iDat).dtubo Or pasvec <> DaTos(iDat).Passo Then ivec = 8 : GoTo 297
        If pdiavec <> DaTos(iDat).pdiaf Or p1vec <> DaTos(iDat).p1 Or matuvec <> DaTos(iDat).matub Then ivec = 9 : GoTo 297
        If jsvec <> GiuntoSaldato Or radvec <> DaTos(iDat).radiu Then ivec = 10 : GoTo 297
        If jinvec <> IncrementoDiametro Or tcavec <> DaTos(iDat).tcava Then ivec = 11 : GoTo 297
        If DaTos(iDat).DistSuSettoHor <> DistSuSettoHorvec Then ivec = 13 : GoTo 297
        If DaTos(iDat).DistSuSettoVer <> DistSuSettoVervec Then ivec = 14 : GoTo 297
        If DaTos(iDat).MassimizzaOTL <> MassimizzaOTLvec Then ivec = 15 : GoTo 297
        'If DaTos(iDat).cori <> DaTos(iDat).dt(34) And (DaTos(iDat).cori > 1 Or DaTos(iDat).dt(34) > 1) Then ivec = 16: GoTo 297
        'If DaTos(iDat).Ips2 <> DaTos(iDat).Ips2vec Then ivec = 16: GoTo 297
        'LINDE
        If DaTos(iDat).FilaCentraleStorta <> Ips2vec Then ivec = 16 : GoTo 297
        If DaTos(iDat).Passi4CurveVert <> jt6iutuvec Then ivec = 17 : GoTo 297
        If DaTos(iDat).dt(34) <> dt34vec Then ivec = 18 : GoTo 297
        If DaTos(iDat).TipoFascio = 4 Then
            If DaTos(iDat).dt(44) <> dt44vec Then ivec = 19 : GoTo 297
            If DaTos(iDat).dt(42) <> dt42vec Then ivec = 20 : GoTo 297
        End If
        If Not FilaMezzeriavec = FilaMezzeria Then ivec = 21 : GoTo 297
298:    GoTo 606
297:    If DaTos(iDat).ILFINAL = 1 Then
            Dim Testo As String = GlobalRoutines.FormatS(Helpstringa(IDH_ATT_ELIMINADATIFINALI), at1(181 + ivec))
            Dim Res As ChiaviMess = MostraAiuto(IDH_ATT_ELIMINADATIFINALI, _
             ChiaviMess.MessHelpButton Or ChiaviMess.MessQuestion Or ChiaviMess.MessYesNoCancel, _
             Testo, "Traccia")
            If Res = ChiaviMess.MessCancel Then Dati = False : Exit Function
            If Res = ChiaviMess.MessSi Then
                SaveAll()
                Elimina() 'DaTos(iDat).ILFINAL = 0
            End If
        End If
606:    For i = 0 To 2 : If DaTos(iDat).matub = i Then GoTo 107
        Next
        kdati = -IDH_ERR_MATTUBI : GoTo 99
107:    For i = 1 To 4 : If DaTos(iDat).TipoPasso = i Then GoTo 141
        Next
        kdati = -IDH_ERR_TIPOPASSO : GoTo 99
141:    For i = 1 To 20 : If DaTos(iDat).PassoFascio = i Then GoTo 161
        Next
        kdati = -IDH_ERR_NUMPASSI : GoTo 99
161:    For i = 1 To 4 : If DaTos(iDat).TipoFascio = i Then GoTo 229
        Next
        kdati = -IDH_ERR_TIPOFASCIO : GoTo 99
229:    If DaTos(iDat).di0 > 10000 Then kdati = -IDH_ERR_DIAMGRANDE : GoTo 99
        If DaTos(iDat).dtin > 5000 Or DaTos(iDat).dtout > 5000 Then kdati = -IDH_ERR_DIAMBOC1 : GoTo 99
        If DaTos(iDat).di0 <> 0 And DaTos(iDat).dtin > DaTos(iDat).di0 Or DaTos(iDat).di0 <> 0 And DaTos(iDat).dtout > DaTos(iDat).di0 Then kdati = -IDH_ERR_DIAMBOC2 : GoTo 99
        If DaTos(iDat).roin <> 0 And DaTos(iDat).win = 0 Then kdati = -IDH_ERR_DENS1noPORT : GoTo 99
        If DaTos(iDat).roin <> 0 And DaTos(iDat).dtin = 0 Then kdati = -IDH_ERR_DENS1noDIAM : GoTo 99
        If DaTos(iDat).roout <> 0 And DaTos(iDat).wout = 0 Then kdati = -IDH_ERR_DENS2noPORT : GoTo 99
        If DaTos(iDat).roout <> 0 And DaTos(iDat).dtout = 0 Then kdati = -IDH_ERR_DENS2noDIAM : GoTo 99
        If DaTos(iDat).ntubi = 0 And DaTos(iDat).di0 = 0 Then kdati = -IDH_ERR_noDIAMnoTUBI : GoTo 99
        If DaTos(iDat).TipoFascio = 4 And DaTos(iDat).ntubi = 0 And DaTos(iDat).coriext = 0 Then kdati = -IDH_ERR_FONTCORONA : GoTo 99
        If DaTos(iDat).dtubo < 1 Then kdati = -IDH_ERR_DIAMTUBISBAGL : GoTo 99
        If DaTos(iDat).Passo <= DaTos(iDat).dtubo Then kdati = -IDH_ERR_PASSOSBAGL : GoTo 99
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
            If DaTos(iDat).PassoFascio <> traccia.clsTracciatura.PassiFascio._2U Then kdati = -IDH_ERR_NUMPASSInoFONT : GoTo 99
            If DaTos(iDat).dt(34) <= DaTos(iDat).dt(44) Then kdati = -IDH_ERR_CORINTCOREXT : GoTo 99
        End If
        If Not DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Utube Then Exit Function
        If DaTos(iDat).PassoFascio = 2 Or DaTos(iDat).PassoFascio = 6 Or DaTos(iDat).PassoFascio = 8 Or DaTos(iDat).PassoFascio = 10 Then Exit Function
        kdati = -IDH_ERR_PASSOnoU
99:     DaTos(iDat).ILFINAL = 0
    End Function

    Sub DELTA3()
        starty = DaTos(iDat).y(Ni) + 2 * DaTos(iDat).PassoVerticale
        If DaTos(iDat).PassoFascio > 4 Then
            If DaTos(iDat).PassoFascio Mod 2 = 0 Then
                If dy <= (2 * DaTos(iDat).PassoVerticale) Then Exit Sub
                starty = DaTos(iDat).y(Ni) + 3 * DaTos(iDat).PassoVerticale
            Else
                If dy > (2 * DaTos(iDat).PassoVerticale) Then
                    starty = DaTos(iDat).y(Ni) + 3 * DaTos(iDat).PassoVerticale
                    If jsect = 2 Or jsect = DaTos(iDat).NumeroSettori Then Exit Sub
                End If
                If Not (jsect = 2 Or jsect = DaTos(iDat).NumeroSettori) Then Exit Sub
            End If
        Else
            If dy <= (2 * DaTos(iDat).PassoVerticale) Then Exit Sub
            starty = DaTos(iDat).y(Ni) + 3 * DaTos(iDat).PassoVerticale
        End If
        If DeltaPasso > 0 Then
            DeltaPasso = 0
        Else
            DeltaPasso = DaTos(iDat).PassoOrizzontale / 2
        End If
    End Sub
    Sub nuitielle()
        Dim raimp As Single
        Dim k, j As Short
        Dim ism As Short
        Dim xx, potenu As Single
        Dim i, Icif As Short
        Dim Titu As String = " "
        Dim icifa, signu, mdx, iii As Short
        raimp = DaTos(iDat).cinter + DaTos(iDat).dtubo / 2
        For k = 1 To DaTos(iDat).NumeroSettori
            ism = 0
            For j = DaTos(iDat).FilaIniziale(k) To DaTos(iDat).FilaFinale(k)
                iii = 0
1555:           If DaTos(iDat).NumeroTubiFila(j) = 0 And j < DaTos(iDat).kymax And (DaTos(iDat).y(j) - DaTos(iDat).yout - (DaTos(iDat).dtubo / 2) < -DaTos(iDat).di1 / 2 Or DaTos(iDat).y(j) + DaTos(iDat).yin + (DaTos(iDat).dtubo / 2) > DaTos(iDat).di1 / 2) Then j = CShort(j + 1) : GoTo 1555
                If j = DaTos(iDat).kymax And DaTos(iDat).NumeroTubiFila(j) = 0 Then GoTo 1159
                If j = 0 Then Exit Sub
                xx = DaTos(iDat).x(j) : Icif = DaTos(iDat).ici(j)
                If Icif Mod 2 = 1 And (DaTos(iDat).hsym(k) <> 2 Or DaTos(iDat).PassoFascio = 2) Then Icif = CShort(Icif + 1)
                If Icif Mod 2 = 1 Then Icif = CShort(Icif - 1)
                Icif = CShort(Icif / 2)
                If DaTos(iDat).hsym(k) = 2 Then ism = 1
                For i = 1 To Icif
                    potenu = CSng(System.Math.Sqrt(DaTos(iDat).y(j) ^ 2 + xx ^ 2))
                    If potenu >= raimp And potenu <= (DaTos(iDat).OTL - DaTos(iDat).dtubo) / 2 And DaTos(iDat).bu(j, i) = "0" Then Titu = "1" : signu = 1
                    If potenu < raimp And DaTos(iDat).bu(j, i) = "1" Then
1103:                   Titu = "0" : signu = -1
                    End If
                    If Not signu = 0 Then
1104:                   mdx = CShort(DaTos(iDat).ici(j) - i + 1)
                        DaTos(iDat).bu(j, i) = CChar(Titu)
                        DaTos(iDat).ktotal = DaTos(iDat).ktotal + signu
                        DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + signu
                        DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + signu
                        If System.Math.Abs(xx) > System.Math.Abs(DaTos(iDat).xs(j)) And signu = 1 Then DaTos(iDat).xs(j) = xx
                        If signu = -1 Then DaTos(iDat).xs(j) = xx + DaTos(iDat).PassoOrizzontale
                        If xx + 1 > 0 And xx - 1 < 0 Then GoTo 1117
                        If signu = -1 Then DaTos(iDat).xf(j) = -xx - DaTos(iDat).PassoOrizzontale
3104:                   If Not (j = DaTos(iDat).kymax And DaTos(iDat).FilaCentraleStorta And iii = -1) And DaTos(iDat).bu(j, mdx) <> Titu Then
                            DaTos(iDat).bu(j, mdx) = CChar(Titu)
                            If System.Math.Abs(xx) > System.Math.Abs(DaTos(iDat).xf(j)) And signu = 1 Then DaTos(iDat).xf(j) = -xx
                            If ism <> 1 Then
                                DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + signu
                                DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + signu
                                GoTo 1111
                            End If
                            If DaTos(iDat).PassoFascio <> 2 Then
                                DaTos(iDat).ntus(j) = DaTos(iDat).ntus(j) + signu
                                DaTos(iDat).NumeroTubiSettore(k + 1) = DaTos(iDat).NumeroTubiSettore(k + 1) + signu
                                GoTo 1111
                            End If
                            DaTos(iDat).ntus(j) = CShort(DaTos(iDat).ntus(j) + 2 * signu)
                            DaTos(iDat).NumeroTubiSettore(k + 1) = CShort(DaTos(iDat).NumeroTubiSettore(k + 1) + 2 * signu)
                            DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + signu
                            DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + signu
                        Else
                            If iii = -1 Then iii = -2
                            GoTo 1109
                        End If
                    End If
                    GoTo 1111
1117:               If DaTos(iDat).CurveInPianoVert Then
                        DaTos(iDat).ntus(j) = DaTos(iDat).ntus(j) + signu
                        DaTos(iDat).NumeroTubiSettore(k + 1) = DaTos(iDat).NumeroTubiSettore(k + 1) + signu
                    End If
                    GoTo 1109
1111:               If DaTos(iDat).TipoFascio = 3 And DaTos(iDat).PassoFascio <> 2 Then GoTo 1109
                    DaTos(iDat).ktotal = DaTos(iDat).ktotal + signu
1109:               xx = xx + DaTos(iDat).PassoOrizzontale : icifa = 0
                Next i
1159:       Next j
            If DaTos(iDat).hsym(k) = 2 Then k = CShort(k + 1)
        Next k
    End Sub

    Sub nuotielle()
        'On Local Error GoTo Errnuo
        Dim raimp As Single
        Dim k, j As Short
        Dim ism As Short
        Dim xx, potenu As Single
        Dim i, Icif, ii As Short
        Dim Titu As String
        Dim icifa, signu, mdx, iii As Short
        DaTos(iDat).OTL = DaTos(iDat).otimp
        'DaTos(iDat).frs = DaTos(iDat).frs + Rnd / 10000 + 0.00001
        raimp = (DaTos(iDat).otimp - DaTos(iDat).dtubo) / 2
        For k = 1 To DaTos(iDat).NumeroSettori
            ism = 0
            For j = DaTos(iDat).FilaIniziale(k) To DaTos(iDat).FilaFinale(k)
                iii = 0
1555:           If DaTos(iDat).NumeroTubiFila(j) = 0 And j < DaTos(iDat).kymax And (DaTos(iDat).y(j) - DaTos(iDat).yout - (DaTos(iDat).dtubo / 2) < -DaTos(iDat).di1 / 2 Or DaTos(iDat).y(j) + DaTos(iDat).yin + (DaTos(iDat).dtubo / 2) > DaTos(iDat).di1 / 2) Then j = CShort(j + 1) : GoTo 1555
                'If j = DaTos(iDat).kymax Then Stop
                If j = DaTos(iDat).kymax And DaTos(iDat).NumeroTubiFila(j) = 0 Then GoTo 1159
                If j = 0 Then Exit Sub
                xx = DaTos(iDat).x(j) : Icif = DaTos(iDat).ici(j)
                If Icif Mod 2 = 1 And (DaTos(iDat).hsym(k) <> 2 Or DaTos(iDat).PassoFascio = 2) Then Icif = CShort(Icif + 1)
                If Icif Mod 2 = 1 Then Icif = CShort(Icif - 1)
                Icif = CShort(Icif / 2)
                If DaTos(iDat).hsym(k) = 2 Then ism = 1
                For i = 1 To Icif
                    potenu = CSng(System.Math.Sqrt(DaTos(iDat).y(j) ^ 2 + xx ^ 2))
                    If potenu >= raimp And DaTos(iDat).bu(j, i) = "0" Or DaTos(iDat).bu(j, i) = "2" Then
                        If DaTos(iDat).FilaCentraleStorta And j = DaTos(iDat).kymax Then
                            mdx = CShort(DaTos(iDat).ici(j) - i + 1)
                            If DaTos(iDat).bu(j, mdx) = "1" Then
                                DaTos(iDat).bu(j, mdx) = CChar("0")
                                DaTos(iDat).ktotal = CShort(DaTos(iDat).ktotal - 1)
                                DaTos(iDat).NumeroTubiSettore(k) = CShort(DaTos(iDat).NumeroTubiSettore(k) - 1)
                                DaTos(iDat).NumeroTubiFila(j) = CShort(DaTos(iDat).NumeroTubiFila(j) - 1)
                                DaTos(iDat).xf(j) = -xx - DaTos(iDat).PassoOrizzontale
                            End If
                        End If
                        GoTo 1109
                    End If
                    Titu = "1" : signu = 1
                    'aggiunta 05/11/98
                    If j = DaTos(iDat).kymax And DaTos(iDat).FilaCentraleStorta Then
                        If i = 1 Then
                            'iii = -1
                            GoTo 3103
                        Else
                            For ii = CShort(i - 1) To 1 Step -1
                                If DaTos(iDat).bu(j, ii) = "1" Then Exit For
                                If DaTos(iDat).bu(j, ii) = "9" Then Exit For
                            Next
                            If ii > 0 Then
                                If iii = -2 Then GoTo 3103
                                If Not DaTos(iDat).bu(j, ii) = "1" Then iii = -1 : GoTo 1103
                            ElseIf ii = 0 And iii > -1 Then
3103:                           If potenu < raimp Then
                                    If DaTos(iDat).bu(j, i) = "1" Then
                                        mdx = CShort(DaTos(iDat).ici(j) - i + 1)
                                        'iii = -2
                                        If DaTos(iDat).bu(j, mdx) = "0" Then GoTo 3104
                                        If iii = 0 Then
                                            iii = -1
                                            GoTo 1103
                                        End If
                                    Else
                                        If iii = 0 Then iii = -1
                                        GoTo 1104
                                    End If
                                End If
                            End If
                        End If
                    End If
                    ' If DaTos(iDat).Ips2 = 1 And j = DaTos(iDat).kymax Then
                    If potenu <= raimp And DaTos(iDat).bu(j, i) = "0" Then GoTo 1104
                    If potenu <= raimp Then GoTo 1159
1103:               Titu = "0" : signu = -1
1104:               mdx = CShort(DaTos(iDat).ici(j) - i + 1)
                    DaTos(iDat).bu(j, i) = CChar(Titu)
                    DaTos(iDat).ktotal = DaTos(iDat).ktotal + signu
                    DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + signu
                    DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + signu
                    If System.Math.Abs(xx) > System.Math.Abs(DaTos(iDat).xs(j)) And signu = 1 Then DaTos(iDat).xs(j) = xx
                    If signu = -1 Then DaTos(iDat).xs(j) = xx + DaTos(iDat).PassoOrizzontale
                    If xx + 1 > 0 And xx - 1 < 0 Then GoTo 1117
                    If signu = -1 Then DaTos(iDat).xf(j) = -xx - DaTos(iDat).PassoOrizzontale
3104:               If Not (j = DaTos(iDat).kymax And DaTos(iDat).FilaCentraleStorta And iii = -1) And DaTos(iDat).bu(j, mdx) <> Titu Then
                        DaTos(iDat).bu(j, mdx) = CChar(Titu)
                        If System.Math.Abs(xx) > System.Math.Abs(DaTos(iDat).xf(j)) And signu = 1 Then DaTos(iDat).xf(j) = -xx
                        If ism <> 1 Then
                            DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + signu
                            DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + signu
                            GoTo 1111
                        End If
                        If DaTos(iDat).PassoFascio <> 2 Then
                            DaTos(iDat).ntus(j) = DaTos(iDat).ntus(j) + signu
                            DaTos(iDat).NumeroTubiSettore(k + 1) = DaTos(iDat).NumeroTubiSettore(k + 1) + signu
                            GoTo 1111
                        End If
                        DaTos(iDat).ntus(j) = CShort(DaTos(iDat).ntus(j) + 2 * signu)
                        DaTos(iDat).NumeroTubiSettore(k + 1) = CShort(DaTos(iDat).NumeroTubiSettore(k + 1) + 2 * signu)
                        DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + signu
                        DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + signu
                    Else
                        If iii = -1 Then iii = -2
                        GoTo 1109
                    End If
                    GoTo 1111
1117:               If DaTos(iDat).CurveInPianoVert Then
                        DaTos(iDat).ntus(j) = DaTos(iDat).ntus(j) + signu
                        DaTos(iDat).NumeroTubiSettore(k + 1) = DaTos(iDat).NumeroTubiSettore(k + 1) + signu
                    End If
                    GoTo 1109
1111:               If DaTos(iDat).TipoFascio = 3 And DaTos(iDat).PassoFascio <> 2 Then GoTo 1109
                    DaTos(iDat).ktotal = DaTos(iDat).ktotal + signu
1109:               xx = xx + DaTos(iDat).PassoOrizzontale : icifa = 0
                Next i
1159:       Next j
            If DaTos(iDat).hsym(k) = 2 Then k = CShort(k + 1)
        Next k
    End Sub
    Sub nuovi()
        Try
            DaTos(iDat).di0 = DaTos(iDat).dt(2) : DaTos(iDat).dtin = DaTos(iDat).dt(3)
            DaTos(iDat).dtout = DaTos(iDat).dt(4)
            DaTos(iDat).roin = DaTos(iDat).dt(5) : DaTos(iDat).win = DaTos(iDat).dt(6)
            DaTos(iDat).roout = DaTos(iDat).dt(7) : DaTos(iDat).wout = DaTos(iDat).dt(8)
            DaTos(iDat).y0in = DaTos(iDat).dt(9) : DaTos(iDat).y0out = DaTos(iDat).dt(10)
            DaTos(iDat).ntubi = CShort(DaTos(iDat).dt(11))
            DaTos(iDat).TipoPasso = CType(DaTos(iDat).dt(12), traccia.clsTracciatura.TipiPasso)
            DaTos(iDat).PassoFascio = CType(DaTos(iDat).dt(13), traccia.clsTracciatura.PassiFascio)
            DaTos(iDat).TipoFascio = CType(CShort(DaTos(iDat).dt(14)), traccia.clsTracciatura.TipiFascio)
            DaTos(iDat).dtubo = DaTos(iDat).dt(15)
            DaTos(iDat).Passo = DaTos(iDat).dt(16)
            DaTos(iDat).pdiaf = DaTos(iDat).dt(17)
            DaTos(iDat).p1 = DaTos(iDat).dt(18)
            DaTos(iDat).matub = CShort(DaTos(iDat).dt(19))
            DaTos(iDat).radiu = DaTos(iDat).dt(21)
            IncrementoDiametro = CShort(DaTos(iDat).dt(22)) 'incremento diametro durante iterazione
            DaTos(iDat).tcava = DaTos(iDat).dt(23)
            DaTos(iDat).Spmm = DaTos(iDat).dt(24)
            DaTos(iDat).Spbwg = DaTos(iDat).dt(25)
            DaTos(iDat).Tublu = DaTos(iDat).dt(26)
            DaTos(iDat).TipoTolleranza = DaTos(iDat).dt(27)
            DaTos(iDat).TipoGiunto = CShort(DaTos(iDat).dt(28))
            DaTos(iDat).EsistePiatto = (DaTos(iDat).dt(33) = 1)
            DaTos(iDat).MassimizzaOTL = (DaTos(iDat).dt(40) > 0)
            DaTos(iDat).Interf = DaTos(iDat).dt(47)
            DaTos(iDat).GapCurve = DaTos(iDat).dt(48)
            DaTos(iDat).Varco = DaTos(iDat).dt(49)
            DaTos(iDat).Anomal0 = CShort(DaTos(iDat).dt(50))
            Select Case DaTos(iDat).TipoGiunto
                Case 1 'sald+mand
                    GiuntoSaldato = True
                Case 2 'sald+mand legg
                    GiuntoSaldato = True
                Case 3 'mandrinato
                    GiuntoSaldato = False
            End Select
            DaTos(iDat).cinter = DaTos(iDat).dt(34) / 2
            '        On Error GoTo ErrNuovi
            If DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Fontana Then
                DaTos(1).cinter = DaTos(1).dt(34) / 2
            End If
            DaTos(iDat).ISEAL = CShort(DaTos(iDat).dt(35)) : DaTos(iDat).Nrod = CShort(DaTos(iDat).dt(36))
            If DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Utube Then DaTos(iDat).ntubi = CShort(DaTos(iDat).ntubi * 2)
            If DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Fontana And iDat = 0 Then
                DaTos(iDat).coriext = DaTos(iDat).dt(44)
                DaTos(iDat).coriint = DaTos(iDat).dt(42)
                DaTos(iDat).passoint = DaTos(iDat).dt(43)
                If DaTos(iDat).passoint = 0 Then DaTos(iDat).passoint = DaTos(iDat).Passo : DaTos(iDat).passoint = DaTos(iDat).dt(43)
                DaTos(1).dtubo = DaTos(iDat).dtubo
            End If
            FilaMezzeria = CType(DaTos(iDat).dt(45), ControlloFilaMezzeria)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub RPASSO()
        If DaTos(iDat).TipoPasso < 4 Then GoTo 53
        DaTos(iDat).PassoVerticale = DaTos(iDat).Passo : DaTos(iDat).PassoOrizzontale = DaTos(iDat).Passo : Exit Sub
53:     If DaTos(iDat).TipoPasso < 3 Then GoTo 611
        DaTos(iDat).PassoOrizzontale = CSng(DaTos(iDat).Passo * System.Math.Sqrt(2)) : DaTos(iDat).PassoVerticale = DaTos(iDat).PassoOrizzontale / 2 : Exit Sub
611:    If DaTos(iDat).TipoPasso = 2 Then GoTo 207
        DaTos(iDat).PassoOrizzontale = DaTos(iDat).Passo : DaTos(iDat).PassoVerticale = CSng(System.Math.Sqrt(DaTos(iDat).Passo ^ 2 - (DaTos(iDat).Passo / 2) ^ 2)) : Exit Sub
207:    DaTos(iDat).PassoVerticale = DaTos(iDat).Passo / 2 : DaTos(iDat).PassoOrizzontale = CSng(System.Math.Sqrt(DaTos(iDat).Passo ^ 2 - (DaTos(iDat).Passo / 2) ^ 2) * 2)
    End Sub
    Private Sub Aumentadiametro()
        Indexx = 1
        Ni = CShort(Ni - 1)
    End Sub
    Private Sub Diminuiscidiametro()
        Indexx = -1
        Ni = CShort(Ni - 1)
    End Sub
    Sub RSETTO()
        With DaTos(iDat)
            Try
                OTC = .OTL - .dtubo
                If jsect = 1 Then RiempitaMetà = False : imi0 = 0 : yini = 0
                If jsect = jSettoreCritico Then yini = -starty
                hdeltao = -nteor : Ni = CShort(Ni + 1) : .y(Ni) = starty
                If .y(Ni) < 0 Then idelp = 0
                If .y(Ni) > ymaxd - 0.01 Then Diminuiscidiametro() : Exit Sub
                .Ntot = 0
                If ((OTC / 2) ^ 2) < (.y(Ni) ^ 2) Then
                    Aumentadiametro()
                Else
                    Do
                        x1 = CSng(System.Math.Sqrt((OTC / 2) ^ 2 - .y(Ni) ^ 2))
                        If .dt(32) = 1 And .dt(31) = 90 And x1 > .XYBLOK Then x1 = .XYBLOK
                        deltaH = x1 - dx - DeltaPasso
                        If .cinter > 1 And System.Math.Abs(.y(Ni)) < .cinter + (.dtubo / 2) Then
                            deltacint = CSng(System.Math.Sqrt((.cinter + (.dtubo / 2)) ^ 2 - .y(Ni) ^ 2))
                            i = 0
                            Do
                                i = CShort(i + 1)
                                If DeltaPasso + i * .PassoOrizzontale > deltacint Then
                                    deltacint = DeltaPasso + i * .PassoOrizzontale
                                    Exit Do
                                End If
                            Loop
                            deltaH = x1 - deltacint
                        Else
                            deltacint = 0
                        End If
                        Npassi = CShort(Floor(deltaH / .PassoOrizzontale))
                        If kwrite = 1 Then
                            .x(Ni) = -((dx + DeltaPasso) * (-CShort(deltacint = 0)) + .PassoOrizzontale * Npassi + deltacint)
                        End If
                        .NumeroTubiFila(Ni) = CShort(Npassi + 1)
                        If dx = 0 Then
                            .NumeroTubiFila(Ni) = CShort(Npassi * 2 + 1)
                            If DeltaPasso <> 0 Or deltacint > 0 Then .NumeroTubiFila(Ni) = CShort((Npassi + 1) * 2)
                            If deltacint = 0 And .TipoPasso = 4 And .TipoFascio <> 3 And .PassoFascio > 4 And (jsect = 1 Or jsect = .NumeroSettori) Then
                                If .PassoFascio Mod 2 = 1 And .NumeroTubiFila(Ni) Mod 2 = 0 Then .NumeroTubiFila(Ni) = CShort(.NumeroTubiFila(Ni) + 1)
                            End If
                            If Not deltacint > 0 Then
                                If kwrite = 1 Then
                                    xnw = -.PassoOrizzontale * (.NumeroTubiFila(Ni) - 1) / 2
                                    If xnw <> .x(Ni) Then
                                        '               PRINT "xnw"; xnw; .x(Ni): u$ = INPUT$(1)
                                        .x(Ni) = xnw
                                    End If
                                End If
                            End If
                        End If
                        .Ntot = .Ntot + .NumeroTubiFila(Ni)
                        hdelta = .Ntot - nteor
                        If RiempitaMetà Then GoTo 1452
                        If (SpostXSettore(jsect) <> 0) Then
                            ntotfit = CShort(2 * .Ntot)
                        Else
                            ntotfit = .Ntot
                        End If
                        ktotfit = .ktotal + ntotfit
                        If jsect = 1 And UscitaSimmetrica And .Ntot < kteor And .PassoFascio <> 1 Then GoTo 1452
                        If ktotfit < CShort(.ntubi / 2) And .y(Ni) < 0 Then GoTo 1452
                        If (SpostXSettore(jsect) <> 0) Then
                            ntucl = CShort(2 * .NumeroTubiFila(Ni))
                        Else
                            ntucl = .NumeroTubiFila(Ni)
                        End If
                        If UscitaSimmetrica And Not RiempitaMetà And .y(Ni) < 100 Then
                            iyi = CShort(Int(-.y(Ni) * 10))
                            ntufit = CShort(.ntubi / 2 - ntucl / 2)
                            If ktotfit >= CShort(.ntubi / 2) Then
                                If jsect > jSettoreCritico Then Aumentadiametro() : Exit Sub
                                If iyi < -3 Then
                                    If UscitaSimmetrica Then
                                        ' se non hai riempito lo spazio diaponibile alla partenza devi diminuire il diametro
                                        If (OTC - .yin - .yout) / 2 + starty > .PassoVerticale Then Exit Sub
                                    End If
                                    Aumentadiametro() : Exit Sub
                                End If
                                If jsect < jSettoreCritico Then
                                    starty = -9999 : Exit Sub
                                End If
                                If Not EpariNumeroSetti Then
                                    If iyi + 3 > Int(10 * dy / 2) And iyi - 3 < Int(10 * dy / 2) Then
                                        RiempitaMetà = True
                                        sub997()
                                        Exit Sub
                                    End If
                                    If ktotfit > 1.1 * .ntubi / 2 And .MassimizzaOTL Then
                                        starty = -9999 : Exit Sub
                                    End If
                                    If ktotfit > 1.15 * .ntubi / 2 Then
                                        Registra()
                                        jsect = .NumeroSettori
                                        Sub3003()
                                        Exit Sub
                                    End If
                                    starty = -9999
                                    Exit Sub
                                    'XXXXXXXXXXXX IRRAGGIUNGIBILE
                                    If .y(Ni) < -dy - 5 Then
                                        Registra()
                                        jsect = .NumeroSettori
                                        Sub3003()
                                        Exit Sub
                                    End If
                                    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                End If
                                If EpariNumeroSetti Then
                                    If Math.Abs(iyi - PassoVdecimm) < 3 Then RiempitaMetà = True : GoTo 1661
                                    If Math.Abs(iyi - PassoVdecimm / 2) < 3 Then RiempitaMetà = True : GoTo 1661
                                    If ktotfit - ntucl >= ntufit Then
                                        If iyi + 3 > 0 Then If iyi - 3 < 0 Then RiempitaMetà = True : GoTo 1661
                                    End If
                                    If ktotfit - ntucl > 1.1 * ntufit Then
                                        Registra()
                                        jsect = .NumeroSettori
                                        Sub3003()
                                        Exit Sub
                                    End If
                                    starty = -9999
                                    Exit Sub
                                    'XXXXXXXXXXX IRRAGGIUNGIBILE
                                    If .y(Ni) < -dy - 5 Then
                                        Registra()
                                        jsect = .NumeroSettori
                                        Sub3003()
                                        Exit Sub
                                    End If
                                    starty = -9999
                                    Exit Sub
                                    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                End If
                            End If
                        End If
1452:                   If Not (jsect = .NumeroSettori Or dx <> 0 And jsect = (.NumeroSettori - 1)) Then
                            If Not (RiempitaMetà And idelp > Ni - nstart + 1) Then
                                If RiempitaMetà And yini + 1 > .y(Ni) And yini - 1 < .y(Ni) Then
                                    sub997()
                                    Exit Sub
                                End If
                                If Not (RiempitaMetà And yini - 1 > .y(Ni) Or hdelta < 0) Then
                                    If (RiempitaMetà Or UscitaSimmetrica Or jsect > 1 Or .Ntot <= nteor) _
                                    And hdelta > System.Math.Abs(hdeltao) Then
                                        .Ntot = .Ntot - .NumeroTubiFila(Ni)
                                        Sub3003()
                                        Exit Sub
                                    End If
                                    sub997()
                                    Exit Sub
                                End If
                            End If
                        End If
1661:                   Dpold = DeltaPasso
                        If Not .TipoPasso = clsTracciatura.TipiPasso._90 Then
                            xy = .PassoOrizzontale / 2
                            If DeltaPasso <> 0 Then xy = 0
                            DeltaPasso = xy
                        End If
                        Yold = .y(Ni) : Ni = CShort(Ni + 1)
                        .y(Ni) = Yold + .PassoVerticale
                        hdeltao = hdelta
                    Loop While (.y(Ni) - ymaxd) <= 0.01
                    If (jsect = .NumeroSettori Or dx <> 0 And jsect = (.NumeroSettori - 1)) _
                        And Not (hdelta >= 0 Or ktotfit > .ntubi) Then
                        Indexx = 1
                    End If
                    Sub3003()
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Private Sub Sub3003()
        If Not (DaTos(iDat).CurveInPianoVert And DaTos(iDat).PassoFascio > 2 And kwrite = 1) Then Ni = CShort(Ni - 1)
        If DaTos(iDat).y(Ni) < 0 Then
            imi0 = CShort(imi0 + 1)
            delp(imi0, 1) = Dpold
            delp(imi0, 2) = Ni - nstart + 1
        End If
        hdelta = hdeltao : DeltaPasso = Dpold
        If Not (DaTos(iDat).TipoPasso <> 4 Or dx <> 0) Then dx = DeltaPasso
    End Sub
    Private Sub sub997()
        If DaTos(iDat).y(Ni) < 0 Then
            imi0 = CShort(imi0 + 1)
            delp(imi0, 1) = DeltaPasso
            delp(imi0, 2) = Ni - nstart + 1
        End If
        If Not (DaTos(iDat).TipoPasso <> 4 Or dx <> 0) Then dx = DeltaPasso
    End Sub
    Private Sub Registra()
        If DaTos(iDat).CurveInPianoVert And DaTos(iDat).PassoFascio > 2 And kwrite = 1 Then
            DaTos(iDat).Ntot = DaTos(iDat).Ntot - DaTos(iDat).NumeroTubiFila(Ni)
            Ni = CShort(Ni - 1)
            Rownf()
            If jsect = 1 Then
                jsect = 3
                Nhsym()
                jsect = 1
            End If
        End If
    End Sub
    '    Sub SAVALL(ByRef icome As String, ByRef icomes As String)
    '        Dim ifl, LungSave As Short
    '        Dim i, iVol As Short
    '        ifl = FreeFile()
    '        FileOpen(ifl, icome, OpenMode.Output)
    '3420:   PrintLine(ifl, icomes & Space(9) & "end")
    '        If DaTos(iDat).TipoFascio = 4 Then iVol = 2 Else iVol = 1
    '        LungSave = QualeCorona
    '        For i = 1 To iVol
    '            QualeCorona = i
    '            Call Scrivi(i - 1, ifl)
    '        Next
    '        QualeCorona = LungSave
    '        FileClose(ifl) : FileClose(Tracciatura.File5) : Tracciatura.File5 = 0
    '        DaTos(iDat).ILFINAL = 1 : DaTos(iDat).Elimin = 0 'novità (era FINAL=1 elimin=0)
    '        If DaTos(iDat).TipoFascio = 4 Then DaTos(1).ILFINAL = 1 : DaTos(1).Elimin = 0
    '    End Sub

    '    Sub Scrivi(ByRef Ind As Short, ByRef ifl As Short)
    '        Dim fatto, j, k As Short
    '        Dim Form As String
    '        WriteLine(ifl, DaTos(Ind).dt(3), DaTos(Ind).dt(4), DaTos(Ind).dt(12), DaTos(Ind).dt(13), DaTos(Ind).dt(14), DaTos(Ind).dt(15), DaTos(Ind).dt(16), DaTos(Ind).dt(21), DaTos(Ind).dt(23), DaTos(Ind).dt(24), DaTos(Ind).dt(25), DaTos(Ind).dt(26), DaTos(Ind).dt(27), DaTos(Ind).dt(28), DaTos(Ind).dt(29), DaTos(Ind).dt(34), DaTos(Ind).dt(37))
    '        WriteLine(ifl, DaTos(Ind).icin, DaTos(Ind).OTL, DaTos(Ind).kymax, DaTos(Ind).NumeroSettori, DaTos(Ind).ISEAL, DaTos(Ind).ktotal, DaTos(Ind).Nrod, DaTos(Ind).ntira, DaTos(Ind).di1, DaTos(Ind).dxv, DaTos(Ind).dy, DaTos(Ind).xmind, DaTos(Ind).Datos(iDat).PassoOrizzontale, DaTos(Ind).OTL, DaTos(Ind).Datos(iDat).PassoVerticale, DaTos(Ind).CurveInPianoVert, DaTos(Ind).delcl, DaTos(Ind).hin, DaTos(Ind).Hout, DaTos(Ind).Primafi) ';????
    '        For j = 1 To DaTos(Ind).NumeroSettori
    '            Print(ifl, DaTos(Ind).FilaIniziale(j) & Chr(44) & DaTos(Ind).FilaFinale(j) & Chr(44) & DaTos(Ind).hsym(j) & Chr(44)) : Next
    '        PrintLine(ifl, "FilaIniziale,FilaFinale,HSYM")
    '        For j = 1 To DaTos(Ind).NumeroSettori
    '            Print(ifl, DaTos(Ind).isett(j) & Chr(44) & DaTos(Ind).icontr(j) & Chr(44)) : Next : PrintLine(ifl, "ISETT,ICONTR")
    '        For j = 1 To DaTos(Ind).kymax
    '            fatto = 0
    '            WriteLine(ifl, DaTos(Ind).y(j), DaTos(Ind).x(j), DaTos(Ind).xs(j), DaTos(Ind).xf(j))
    '            Print(ifl, DaTos(Ind).ntub(j) & Chr(44) & DaTos(Ind).ntus(j) & Chr(44)) : If j Mod 4 = 0 Then PrintLine(ifl, "y,x,ntu,ntus") : fatto = 1
    '        Next
    '        If fatto = 0 Then PrintLine(ifl, "x,y,ntub,ntus")
    '        For j = 1 To 5 : WriteLine(ifl, DaTos(Ind).URTY(j)) : Next : PrintLine(ifl, "URTY")
    '        For j = 1 To 10 : WriteLine(ifl, DaTos(Ind).tagli(j)) : Next : PrintLine(ifl, "TAGLI")
    '        For k = 1 To DaTos(Ind).ISEAL
    '            For j = 1 To 10 : WriteLine(ifl, DaTos(Ind).seal(j, k)) : Next : PrintLine(ifl, "SEAL")
    '        Next
    '        For k = 1 To DaTos(Ind).ntira
    '            For j = 1 To 3 : WriteLine(ifl, DaTos(Ind).td(j, k)) : Next : PrintLine(ifl, "TIRANTI")
    '        Next
    '        For k = 1 To DaTos(Ind).Nrod
    '            For j = 1 To 4 : WriteLine(ifl, DaTos(Ind).runn(j, k)) : Next : PrintLine(ifl, "runn") : Next
    '        apri5()
    '        For j = 1 To DaTos(Ind).kymax
    '            FileGet(Tracciatura.File5, DaTos(Ind).bu, j)
    '            PrintLine(ifl, GlobalRoutines.FormatS("####.##", DaTos(Ind).bu.ici) & DaTos(Ind).bu.bu)
    '        Next
    '        For j = 1 To 100 : Print(ifl, DaTos(Ind).ntx(j) & Chr(44)) : Next : PrintLine(ifl, "ntx")
    '        WriteLine(ifl, DaTos(Ind).itro) '; ","
    '    End Sub

    Sub UTUBI()
        Dim Yold As Single
        Dim locNi, Npassi As Short
        Dim x1 As Single
        Dim hdelta, xy As Single
        Yold = 0 : DaTos(iDat).Ntot = 0 : ymaxd = -dy / 2
        OTC = DaTos(iDat).OTL - DaTos(iDat).dtubo
        For locNi = 1 To 250
            Ni = locNi
            DaTos(iDat).y(Ni) = Yold + DaTos(iDat).PassoVerticale
            If Ni = 1 Then DaTos(iDat).y(Ni) = starty
            If (DaTos(iDat).y(Ni) - ymaxd) > 0.1 And Ni = 1 Then FuoriReticolo = True : Exit Sub
            If (DaTos(iDat).y(Ni) - ymaxd) > 0.1 Then GoTo 1019
            Yold = DaTos(iDat).y(Ni) : x1 = CSng(System.Math.Sqrt((OTC / 2) ^ 2 - System.Math.Abs(DaTos(iDat).y(Ni)) ^ 2))
            If DaTos(iDat).dt(32) = 1 And DaTos(iDat).dt(31) = 90 And x1 > DaTos(iDat).XYBLOK Then x1 = DaTos(iDat).XYBLOK
            Npassi = CShort(Int((x1 - DeltaPasso) / DaTos(iDat).PassoOrizzontale))
            DaTos(iDat).NumeroTubiFila(Ni) = CShort(Npassi * 2 + 1)
            If DeltaPasso <> 0 Then DaTos(iDat).NumeroTubiFila(Ni) = CShort((Npassi + 1) * 2)
            If kwrite = 1 Then DaTos(iDat).x(Ni) = -(dx + DeltaPasso + DaTos(iDat).PassoOrizzontale * Npassi)
            DaTos(iDat).Ntot = DaTos(iDat).Ntot + DaTos(iDat).NumeroTubiFila(Ni) : hdelta = DaTos(iDat).Ntot - kteor
            If DaTos(iDat).TipoPasso = 4 Then GoTo 1009
            xy = DaTos(iDat).PassoOrizzontale / 2 : If DeltaPasso <> 0 Then xy = 0
            DeltaPasso = xy
1009:   Next
1019:   If hdelta < 0 Then Indexx = 1
        DaTos(iDat).ktotal = DaTos(iDat).Ntot
        Ni = CShort(Ni - 1)
        DaTos(iDat).kymax = Ni
    End Sub
    Sub inverti(ByVal iDat As Integer)
        If DaTos(iDat).EsistePiatto Then DaTos(iDat).dt(33) = 1 Else DaTos(iDat).dt(33) = 0
        DaTos(iDat).dt(13) = DaTos(iDat).PassoFascio
    End Sub
    Sub vecchi()
        'DaTos(iDat).ILFINAL = 0
        dt34vec = DaTos(iDat).dt(34)
        dt42vec = DaTos(iDat).dt(42)
        dt44vec = DaTos(iDat).dt(44)
        jt6iutuvec = DaTos(iDat).Passi4CurveVert
        Ips2vec = DaTos(iDat).FilaCentraleStorta
        divec = DaTos(iDat).di0
        dtivec = DaTos(iDat).dtin
        dtovec = DaTos(iDat).dtout
        roivec = DaTos(iDat).roin
        winvec = DaTos(iDat).win
        roovec = DaTos(iDat).roout
        wouvec = DaTos(iDat).wout
        y0ivec = DaTos(iDat).y0in
        y0ovec = DaTos(iDat).y0out
        ntuvec = DaTos(iDat).ntubi
        jpvec = DaTos(iDat).TipoPasso
        jtvec = DaTos(iDat).PassoFascio
        jshvec = DaTos(iDat).TipoFascio
        dtubvec = DaTos(iDat).dtubo
        pasvec = DaTos(iDat).Passo
        pdiavec = DaTos(iDat).pdiaf
        p1vec = DaTos(iDat).p1
        matuvec = DaTos(iDat).matub
        radvec = DaTos(iDat).radiu
        jsvec = GiuntoSaldato
        jinvec = IncrementoDiametro
        tcavec = DaTos(iDat).tcava
        DistSuSettoHorvec = DaTos(iDat).DistSuSettoHor
        DistSuSettoVervec = DaTos(iDat).DistSuSettoVer
        MassimizzaOTLvec = DaTos(iDat).MassimizzaOTL
        corivec = DaTos(iDat).cori
        FilaMezzeriavec = FilaMezzeria
    End Sub
    Sub YINOUT()
        Dim ACCAI, ATRIN As Single
        Dim ACCAO, ATROUT As Single
        Dim CHECK, ROV2IN, ROV2OU, Check1 As Single
        Dim ACYLIN, ACYLOU As Single
        If DaTos(iDat).di1 > DaTos(iDat).dtin Then Epsilo = CSng(DaTos(iDat).di1 / 4 - System.Math.Sqrt(DaTos(iDat).di1 ^ 2 - DaTos(iDat).dtin ^ 2) / 4)
        If DaTos(iDat).di1 > DaTos(iDat).dtout Then Epsil1 = CSng(DaTos(iDat).di1 / 4 - System.Math.Sqrt(DaTos(iDat).di1 ^ 2 - DaTos(iDat).dtout ^ 2) / 4)
        If DaTos(iDat).yin <> 0 Then GoTo YI7
        If DaTos(iDat).dtin <> 0 Then GoTo YI4
        DaTos(iDat).yin = 0
        GoTo YI7
YI4:    If DaTos(iDat).roin > 0 And DaTos(iDat).win > 0 Then GoTo YI5
        ACCAI = DaTos(iDat).dtin / 4
        DaTos(iDat).yin = Int(2 * (Epsilo + ACCAI + 9 - GiocoDiaframmi / 2)) / 2
        GoTo YI7
YI5:    ATRIN = CSng(DaTos(iDat).dtin ^ 2 * System.Math.PI / 4 / 1000000)
        ROV2IN = CSng(DaTos(iDat).roin * 0.672 * (DaTos(iDat).win / (DaTos(iDat).roin * ATRIN * 3600)) ^ 2)
        CHECK = 3000
        If ROV2IN < CHECK Then CHECK = ROV2IN
        ACYLIN = CSng(DaTos(iDat).win / (System.Math.Sqrt(CHECK / (DaTos(iDat).roin * 0.672)) * DaTos(iDat).roin * 3600) * 1000000)
        ACCAI = CSng(ACYLIN / (DaTos(iDat).dtin * System.Math.PI))
        DaTos(iDat).yin = Int(2 * (Epsilo + ACCAI + 9 - GiocoDiaframmi / 2)) / 2
YI7:    If DaTos(iDat).yout <> 0 Then GoTo YI10
        If DaTos(iDat).dtout <> 0 Then GoTo YI8
        DaTos(iDat).yout = 0
        GoTo YI10
YI8:    If DaTos(iDat).roout > 0 And DaTos(iDat).wout > 0 Then GoTo YI9
        ACCAO = DaTos(iDat).dtout / 6
        DaTos(iDat).yout = Int(2 * (Epsil1 + ACCAO - GiocoDiaframmi / 2)) / 2
        GoTo YI10
YI9:    ATROUT = CSng(DaTos(iDat).dtout ^ 2 * System.Math.PI / 4 / 1000000)
        ROV2OU = CSng(DaTos(iDat).roout * 0.672 * (DaTos(iDat).wout / (DaTos(iDat).roout * ATROUT * 3600)) ^ 2)
        Check1 = 3000
        If ROV2OU < Check1 Then Check1 = ROV2OU
        ACYLOU = CSng(DaTos(iDat).wout / (System.Math.Sqrt(Check1 / (DaTos(iDat).roout * 0.672)) * DaTos(iDat).roout * 3600) * 1000000)
        ACCAO = CSng(ACYLOU / (DaTos(iDat).dtout * System.Math.PI))
        DaTos(iDat).yout = Int(2 * (Epsil1 + ACCAO - GiocoDiaframmi / 2)) / 2
YI10:   If DaTos(iDat).yin < 0 Then DaTos(iDat).yin = 0
        If DaTos(iDat).yout < 0 Then DaTos(iDat).yout = 0
    End Sub
    Public Sub CheckDati()
        Dim Testo As String
        Static Gia As Boolean
        If Not iPagina = 2 Then Exit Sub
        If Not Gia Then
            Gia = True
            If DaTos(iDat).dt(21) > 0 And DaTos(iDat).dt(21) < 1.5 * DaTos(iDat).dt(15) And DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube Then
                Testo = "Il raggio di curvatura minimo dei tubi ad U (" & Str(DaTos(iDat).dt(21)) & ")" & vbCrLf
                Testo = Testo & "risulta inferiore al minimo TEMA (" & Str(1.5 * DaTos(iDat).dt(15)) & ")." & vbCrLf
                Testo = Testo & "Vuoi procedere comunque ?"
                If MsgBox(Testo, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    DaTos(iDat).dt(21) = CSng(1.5 * DaTos(iDat).dt(15))
                    Testo = "Il raggio di curvatura minimo dei tubi ad U" & vbCrLf
                    Testo = Testo & "è stato assunto pari al minimo TEMA (" & Str(DaTos(iDat).dt(21)) & ")."
                    MsgBox(Testo, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly)
                End If
            End If
        End If
    End Sub
    Public Function difdia(ByRef di1 As Single) As Single
        If (di1 < 432.0!) Then difdia = 3.0!
        If (di1 >= 433.0! And di1 < 457.0!) Then difdia = 3.0!
        If (di1 >= 457.0! And di1 < 991.0!) Then difdia = 5.0!
        If (di1 >= 991.0! And di1 < 1016.0!) Then difdia = 5
        If (di1 >= 1016.0! And di1 < 1372.0!) Then difdia = 6.0!
        If (di1 >= 1372.0! And di1 < 1397.0!) Then difdia = 6.0!
        If (di1 >= 1397.0! And di1 < 1524.0!) Then difdia = 8.0!
        If (di1 >= 1524.0! And di1 < 1550.0!) Then difdia = 8.0!
        If (di1 >= 1550.0! And di1 < 1778.0!) Then difdia = 8.0!
        If (di1 >= 1778.0! And di1 < 2159.0!) Then difdia = 10.0!
        If (di1 >= 2159.0! And di1 < 2540.0!) Then difdia = 11.0!
        If (di1 > 2540.0!) Then difdia = 13.0!
    End Function
    Function msgg(ByRef idt As Short) As String
        'ultima revisione in data 11/1/1992
        Dim Text As String = "" ', ifl As Integer
        'msgg = 0
        Select Case idt
            Case 1
                '        text$ = " File dati. (8 chr massimi "
                'text$ = text$ + " senza caratteri speciali)|"
                'text$ = text$ + " (Per input da file : F3   "
                'text$ = text$ + " ed inserire solo il nome |"
                'text$ = text$ + " file.)                    "
                Text = at1(2)
            Case 2
                '        text$ = " Inserire 0 se sconosciuto."
                'text$ = text$ + " Inserendo un valore viene|"
                'text$ = text$ + " utilizzato l'otl  max/min "
                'text$ = text$ + " (vedi OT).               |"
                'text$ = text$ + " L'ottimizzazione richiede "
                'text$ = text$ + " un tempo minore, purche il|"
                'text$ = text$ + " diametro  sia sufficiente "
                'text$ = text$ + " a  contenere  i tubi dati.|"
                Text = at1(3)
            Case 3
                '        text$ = " Inserendo il diametro del "
                'text$ = text$ + " bocchello d'ingresso viene|"
                'text$ = text$ + " tenuta una distanza pari a"
                'text$ = text$ + " d/4 tra la mezzeria  arco |"
                'text$ = text$ + " ed eventuale piatto d'urto"
                Text = at1(4)
            Case 4
                '        text$ = " Inserendo il diametro del "
                'text$ = text$ + " bocchello d' uscita viene|"
                'text$ = text$ + " tenuta una distanza  pari "
                'text$ = text$ + " a  d/6  tra  la  mezzeria|"
                'text$ = text$ + " arco e de prima fila tubi."
                Text = at1(5)
            Case 5
                '        text$ = " Inserendo il valore verra'"
                'text$ = text$ + " tenuta una  distanza, tra|"
                'text$ = text$ + " la mezzeria  dell'arco ed "
                'text$ = text$ + " eventuale  piatto  d'urto,|"
                'text$ = text$ + " tale che RoVý<=RoVýbocch. "
                'text$ = text$ + " comunque inferiore a 4000|"
                'text$ = text$ + "    (OMETTERE SE PI=0)     "
                Text = at1(6)
            Case 6
                '        text$ = " Inserendo il valore verra'"
                'text$ = text$ + " tenuta una  distanza, tra|"
                'text$ = text$ + " la mezzeria  dell'arco ed "
                'text$ = text$ + " eventuale  piatto  d'urto,|"
                'text$ = text$ + " tale che RoVý<=RoVýbocch. "
                'text$ = text$ + " comunque inferiore a 4000|"
                'text$ = text$ + "    (OMETTERE SE RI=0)     "
                Text = at1(7)
            Case 7
                '        text$ = " Inserendo il valore verra'"
                'text$ = text$ + " tenuta una  distanza, tra|"
                'text$ = text$ + " la   mezzeria   dell'arco "
                'text$ = text$ + " e il de della prima  fila|"
                'text$ = text$ + " tubi, tale che            "
                'text$ = text$ + "   RoVý<=RoVý(bocchello)  |"
                'text$ = text$ + "   (OMETTERE SE PO=0)      "
                Text = at1(8)
            Case 8
                '        text$ = " Inserendo il valore verra'"
                'text$ = text$ + " tenuta una  distanza, tra|"
                'text$ = text$ + " la   mezzeria   dell'arco "
                'text$ = text$ + " e il de della prima  fila|"
                'text$ = text$ + " tubi, tale che            "
                'text$ = text$ + "   RoVý<=RoVý(bocchello)  |"
                'text$ = text$ + "   (OMETTERE SE RO=0)      "
                Text = at1(9)
            Case 9
                '        text$ = " Inserendo il valore verra'"
                'text$ = text$ + " tenuta una  distanza, tra|"
                'text$ = text$ + " la mezzeria  dell'arco ed "
                'text$ = text$ + " eventuale  piatto  d'urto,|"
                'text$ = text$ + " pari a tale valore.       "
                'text$ = text$ + "(Non tiene conto din di/4)|"
                Text = at1(10)
            Case 10
                '        text$ = " Inserendo il valore verra' tenuta una  distanza, tra|"
                'text$ = text$ + " la   mezzeria   dell'arco e il de della prima  fila |"
                'text$ = text$ + " pari a tale valore.      (Non tiene conto di dout/6)|"
                'text$ = text$ + "                                                     |"
                'text$ = text$ + " Inserendo  un valore codificato (vedi oltre) si con-|"
                'text$ = text$ + " trolla la disposizione dei tubi.                    |"
                Text = at1(11)
                '               MsgBox Text, vbOK
                'Stringa(1) = " Simmetria orizzontale"
                'Stringa(2) = " Simm.orizz. con tubo su asse vert."
                'Stringa(3) = " Simm.orizz. con tubo fuori asse"
                'Stringa(4) = " Ottimizzaz. con tubo su asse vert."
                'Stringa(5) = " Ottimizzaz. con tubo fuori asse"
                'Stringa(1) = at1(70)
                'For i = 2 To 6: Stringa(i) = at1(11 + i - 1): Next
                'msgg = Quale(6, at1(17), Stringa(), at1(18), Int(dat13) + 1) - 1
                'Exit Function
            Case 11
                '        text$ = " Non inserendo alcun valore"
                'text$ = text$ + " verranno allocati i tubi |"
                'text$ = text$ + " in funzione del Di dato. |"
                Text = at1(19)
            Case 12
                'Stringa(1) = " triangolare a base orizzontale"
                'Stringa(2) = " triangolare a base verticale  "
                'Stringa(3) = " quadro ruotato         "
                'Stringa(4) = " quadro                 "
                'For i = 1 To 4: Stringa(i) = at1(19 + i): Next
                'msgg = Quale(4, at1(24), Stringa(), at1(18), Int(dat13))
                Text = at1(179)
                'Exit Function
            Case 13
                'DIM Stringa(1 TO 11) AS STRING * 31
                'Stringa(1) = "  1 passo (no tubi ad U) "
                'Stringa(2) = "  2 passi   "
                'Stringa(3) = "  3 passi (no tubi ad U) "
                'Stringa(4) = "  4 passi (no tubi ad U) "
                'Stringa(5) = "  4 passi (no tubi ad U) "
                'Stringa(6) = "  4 passi   "
                'Stringa(7) = "  6 passi (no tubi ad U) "
                'Stringa(8) = "  6 passi   "
                'Stringa(9) = "  8 passi (no tubi ad U) "
                'Stringa(10) = "  8 passi   "
                'Stringa(11) = " 10 passi (no tubi ad U)"
                'For i = 1 To 11: Stringa(i) = at1(24 + i): Next
                'msgg = Quale(11, at1(36), Stringa(), at1(18), Int(dat13))
                Text = at1(179)
                'Exit Function
            Case 14 'tipo di fascio
                'For i = 1 To 3: Stringa(i) = at1(85 + i): Next
                'Stringa(4) = at1(91)
                'msgg = Quale(4, "", Stringa(), at1(18), Int(dat13))
                Text = at1(179)
                'Exit Function
            Case 15, 16
                Text = at1(179)
            Case 17
                '        text$ = " Serve esclusivamente  per "
                'text$ = text$ + " la  verifica  del  piatto|"
                'text$ = text$ + " d'urto.                   "
                'text$ = text$ + "  (vedi anche P1 e FE)    |"
                Text = at1(37)
            Case 18
                '        text$ = " Serve esclusivamente  per "
                'text$ = text$ + " la  verifica  del  piatto|"
                'text$ = text$ + " d'urto.                   "
                'text$ = text$ + "  (vedi anche PD e FE)    |"
                Text = at1(38)
            Case 19
                Text = at1(39)
                '               MsgBox Text, vbOK
                'For i = 1 To 2: Stringa(i) = at1(70 + i): Next
                'msgg = Quale(2, "", Stringa(), at1(18), Int(dat13))
                'Exit Function
            Case 20
                '        text$ = " Con  tubi mandrinati mantiene "
                'text$ = text$ + "     2 mm tra tubo e cava.    |"
                'text$ = text$ + " Con  opzione  1  mantiene "
                'text$ = text$ + " 5 mm tra tubo e cava.    |"
                Text = at1(40)
                '               MsgBox Text, vbOK
                'For i = 1 To 2: Stringa(i) = at1(76 + i): Next
                'msgg = Quale(2, "", Stringa(), at1(18), Int(dat13) + 1) - 1
                'Exit Function
            Case 21
                '        text$ = " Inserendo  0  assume  un  "
                'text$ = text$ + " raggio  pari a 2 volte il|"
                'text$ = text$ + " diametro del tubo.        "
                Text = at1(41)
            Case 22
                '        text$ = " Inserendo 0 esegue iteraz."
                'text$ = text$ + " con valori di delta-OTL  |"
                'text$ = text$ + " pari a 12.5/25/50 mm      "
                'text$ = text$ + " Inserendo un valore assume|"
                'text$ = text$ + " tale valore come delta-OTL"
                Text = at1(42)
            Case 23
                '        text$ = " Inserendo  0  assume  una "
                'text$ = text$ + " larghezza  cava  di 13 mm|"
                Text = at1(43)
            Case 24, 25, 26
                Text = at1(179)
            Case 27
                'For i = 1 To 2: Stringa(i) = at1(83 + i): Next
                'msgg = Quale(2, "", Stringa(), at1(18), Int(dat13))
                Text = at1(179)
                'Exit Function
            Case 28
                'Text = at1(39)
                Text = at1(40)
                '               MsgBox Text, vbOK
                'For i = 1 To 3: Stringa(i) = at1(78 + i): Next
                'msgg = Quale(3, "", Stringa(), at1(18), Int(dat13))
                'Exit Function
            Case 29, 30
                Text = at1(179)
            Case 31
                'For i = 1 To 2: Stringa(i) = at1(81 + i): Next
                'msgg = Quale(2, at1(49), Stringa(), at1(18), Int(dat13) + 1) - 1
                Text = at1(179)
                'Exit Function
            Case 32
                'Stringa(1) = " Single"
                'Stringa(2) = " NTW "
                'Stringa(3) = " Double segmental"
                'Stringa(4) = " Triple segmental"
                'Stringa(5) = " Anulari"
                'ifl = FreeFile
                'Open RTrim$(Monitor.Motore.Inizio.Archdir) + "\DIAF01.DAT" For Input Shared As #ifl
                'For i = 1 To 6: Line Input #ifl, Stringa(i): Next
                'Close #ifl
                'FOR i = 1 TO 5: Stringa(i) = at1(43 + i): NEXT
                'msgg = Quale(6, at1(49), Stringa(), at1(18), Int(dat13) + 1) - 1
                Text = at1(179)
                'Exit Function
            Case 33
                'For i = 1 To 2: Stringa(i) = at1(88 + i): Next
                'msgg = Quale(5, "", Stringa(), at1(18), Int(dat13) + 1) - 1
                Text = at1(179)
                'Exit Function
                '' 'Case 34:
                '' ''        text$ = " Inserendo 1 visualizza    "
                '' ''text$ = text$ + " solo  il profilo  settori|"
                '' ''text$ = text$ + " con archi.                "
                '' 'Text = at1(50)
            Case 34, 35, 36
                Text = at1(179)
            Case 37 'tacche
                'For i = 1 To 4: Stringa(i) = at1(72 + i): Next
                'msgg = Quale(4, "", Stringa(), at1(18), Int(dat13) + 1) - 1
                Text = at1(179)
            Case 38, 39
                'Text = "Fornire la distanza minima da rispettare| tra gli assi delle file a cavallo dei setti."
                'Text = Text & "|Se non fornito il programma calcola una| distanza standard"
                'Text = Text + "|Se non fornito il programma calcola una distanza standard"
                Text = at1(100)
            Case 40
                'Text = "L'OTL massimo è quello determinato dal |diametro del mantello. L'OTL minimo è determinato"
                'Text = Text & "|dal numero di tubi richiesti, ove questi|non riempiano il mantello."
                Text = at1(101)
            Case 41, 42, 43, 44
                Text = at1(179)
            Case 45 'controllo mezzeria
                'For i = 1 To 4: Stringa(i) = at1(43 + i): Next
                'msgg = Quale(4, "", Stringa(), at1(18), Int(dat13) + 1) - 1
                'Exit Function
            Case 46
                'Text = "Se selezionato, la fila di forcelle a raggio più stretto"
                'Text = Text & "|sarà posizionata diagonalmente"
                Text = at1(102)
            Case 47
                Text = at1(103) ' "Questo valore sarà normalmente zero.| Tuttavia 1 mm può essere accettabile"
            Case 48
                Text = at1(104) ' "Si consiglia un valore pari, o di poco inferiore| alla differenza passo-diametro"
            Case 49
                'Text = "Per fasci non IBW inserire 360°. |Altrimenti inserire l'ampiezza dell'angolo|"
                'Text = Text & "lasciato vuoto durante la prima fase.|(Normalmente tra 90 e 180°"
                Text = at1(105)
            Case 50
                Text = at1(106) ' "Per fasci IBW inserire l'anomalia media (da 0° a 360°) del settore|dall'ampiezza definita al punto precedente."
            Case Else
                '        text$ = "||Help non disponibile|"
                Text = at1(51)
        End Select
        msgg = Text
        '               MsgBox Text, vbOK
    End Function
    Sub DiaTir()
        Dim ntir, i As Short
        ntir = 4
        If DaTos(iDat).di1 > 381 Then ntir = 6
        If DaTos(iDat).di1 > 838 Then ntir = 8
        If DaTos(iDat).di1 > 1219 Then ntir = 10
        If DaTos(iDat).ntira < ntir Then
            For i = CShort(DaTos(iDat).ntira + 1) To ntir
                DaTos(iDat).td(1, i) = 0
                DaTos(iDat).td(2, i) = 0
                DaTos(iDat).td(3, i) = 0
            Next
            DaTos(iDat).ntira = ntir
        End If
        DaTos(iDat).Didia = CSng(DaTos(iDat).di1 - 2.5) 'up to 13
        If DaTos(iDat).di1 > 330 Then DaTos(iDat).Didia = CSng(DaTos(iDat).di1 - 3.2) 'up to 17
        If DaTos(iDat).di1 > 432 Then DaTos(iDat).Didia = CSng(DaTos(iDat).di1 - 3.8) 'up to 23
        If DaTos(iDat).di1 > 584 Then DaTos(iDat).Didia = CSng(DaTos(iDat).di1 - 4.5) 'up to 39
        If DaTos(iDat).di1 > 991 Then DaTos(iDat).Didia = CSng(DaTos(iDat).di1 - 5.7) 'up to 54
        If DaTos(iDat).di1 > 1372 Then DaTos(iDat).Didia = CSng(DaTos(iDat).di1 - 7.5) 'up to 60
        If DaTos(iDat).di1 > 1524 Then DaTos(iDat).Didia = DaTos(iDat).di1 - 9
    End Sub

    Sub DisRod(ByRef CERCH As Short)
        Dim j As Short, Colore As Color
        With Monitor.Routines
            Colore = .PennaFill.Color
            .PennaFill.Color = Color.Red
            For j = 1 To DaTos(iDat).Nrod
                If DaTos(iDat).runn(1, j) <> 0 Or DaTos(iDat).runn(2, j) <> 0 Then
                    If CERCH = 1 Then
                        Monitor.Routines.cerc(DaTos(iDat).runn(1, j), DaTos(iDat).runn(2, j) + 1 * System.Math.Sign(DaTos(iDat).runn(2, j)), CSng(0.5 * DaTos(iDat).runn(4, j)), True)
                    Else
                        Monitor.Routines.cerc(DaTos(iDat).runn(1, j), DaTos(iDat).runn(2, j) + 1 * System.Math.Sign(DaTos(iDat).runn(2, j)), CSng(0.05 * DaTos(iDat).runn(4, j)), True)
                    End If
                End If
            Next j
            .PennaFill.Color = Colore
        End With
    End Sub

    Sub DisTagl(ByRef jtod As Short)
        Dim j As Short
        For j = 1 To jtod
            AggiustaTaglio(j)
            DisTaglio(j)
        Next j
    End Sub

    Sub DisTaglSupp()
        Select Case DaTos(iDat).tagli(10) 'tagli supporti
            Case 1 'normale
                Monitor.Routines.tratto(DaTos(iDat).tagli(5), DaTos(iDat).tagli(6), DaTos(iDat).tagli(7), DaTos(iDat).tagli(6), 0.1, 3)
                Monitor.Routines.tratto(DaTos(iDat).tagli(7), DaTos(iDat).tagli(6), DaTos(iDat).tagli(7), DaTos(iDat).tagli(8), 0.1, 3)
                Monitor.Routines.tratto(DaTos(iDat).tagli(7), DaTos(iDat).tagli(8), DaTos(iDat).tagli(5), DaTos(iDat).tagli(8), 0.1, 3)
                Monitor.Routines.tratto(DaTos(iDat).tagli(5), DaTos(iDat).tagli(8), DaTos(iDat).tagli(5), DaTos(iDat).tagli(6), 0.1, 3)
            Case 2 '45 gradi
                Monitor.Routines.tratto(DaTos(iDat).tagli(5), 0, 0, DaTos(iDat).tagli(5), 0.1, 3)
                Monitor.Routines.tratto(0, DaTos(iDat).tagli(5), -DaTos(iDat).tagli(5), 0, 0.1, 3)
                Monitor.Routines.tratto(-DaTos(iDat).tagli(5), 0, 0, -DaTos(iDat).tagli(5), 0.1, 3)
                Monitor.Routines.tratto(0, -DaTos(iDat).tagli(5), DaTos(iDat).tagli(5), 0, 0.1, 3)
        End Select
    End Sub

    Sub DisTubi(ByRef CERCH As Short)
        Dim kfin, isym, intp As Short
        Dim k, j As Short
        Dim yj, xfxi As Single
        Dim xx As Single
        Dim IPRI As Short
        Dim notl As Short
        Dim xinx As Single
        Dim ifati, i As Short
        Dim iqp As Short
        Dim xpo As Single
        Dim idista As Short
        Dim xxi As Single
        Dim lApri, isz As Short
        Dim xtub, xin, ytub As Single
        Dim isek As Short
        Dim jjj, hhh, kkk As Short
        ReDim NumForcellePerFila(NumFileMax)
        '-----------------disegno dei tubi-----------------------
        iDat = CShort(QualeCorona - 1)
        isym = 1 : kfin = 0 : intp = 1
        NumFileU = 0 : notl = 0
        If DaTos(iDat).TipoPasso <> clsTracciatura.TipiPasso._90 Then intp = 2
        For k = 1 To DaTos(iDat).NumeroSettori
            For j = DaTos(iDat).FilaIniziale(k) To DaTos(iDat).FilaFinale(k)
                yj = DaTos(iDat).y(j)
1555:           If DaTos(iDat).NumeroTubiFila(j) = 0 And j < DaTos(iDat).kymax Then j = CShort(j + 1) : GoTo 1555
                If j = DaTos(iDat).kymax And DaTos(iDat).NumeroTubiFila(j) = 0 Then GoTo 7960
                yj = DaTos(iDat).y(j)
                xfxi = DaTos(iDat).xf(j) : xinx = DaTos(iDat).xs(j)
                '           If DaTos(iDat).TipoFascio = 3 And DaTos(iDat).PassoFascio <> 2 Then kfin = -2
                'LINDE
                If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube And Not DaTos(iDat).CurveInPianoVert Then kfin = -2
                If isym = -1 And DaTos(iDat).CurveInPianoVert Then
                    kfin = CShort(kfin + 1) : NumForcellePerFila(kfin) = DaTos(iDat).NumeroTubiFila(j)
                    NumFileU = CShort(NumFileU + 1)
                    yj = -DaTos(iDat).y(j) ' + 2 * DaTos(iDat).delcl
                End If
jpiu:           If yj + (DaTos(iDat).dtubo / 2) < -YSC1 Or yj - (DaTos(iDat).dtubo / 2) > YSC2 Then
                    notl = 1 : xfxi = DaTos(iDat).xf(j) : xinx = DaTos(iDat).xs(j) : j = CShort(j + 1) : IPRI = 1
                    yj = DaTos(iDat).y(j)
                    If isym = -1 And DaTos(iDat).CurveInPianoVert Then yj = -DaTos(iDat).y(j) '+ 2 * DaTos(iDat).delcl
                    If j < DaTos(iDat).kymax Then GoTo jpiu Else GoTo 7960
                End If
                xx = DaTos(iDat).x(j) : ifati = 0
                IPRI = 0
                For i = 1 To DaTos(iDat).ici(j)
                    If xx + (DaTos(iDat).dtubo / 2) < -XSC1 And DaTos(iDat).hsym(k) <> 2 Then
                        xinx = DaTos(iDat).xs(j) ': IPRI = 1         ???????????
                        notl = 1 : iqp = CShort(Int((-xx - XSC1) / DaTos(iDat).PassoOrizzontale))
                        i = CShort(1 + iqp) : xx = xx + DaTos(iDat).PassoOrizzontale * iqp
                    End If
                    If xx - (DaTos(iDat).dtubo / 2) > XSC2 Then notl = 1 : xfxi = DaTos(iDat).xf(j) : GoTo 7960
                    isz = 0
                    FuoriReticolo = False
                    If DaTos(iDat).FilaCentraleStorta Then
                        qualy(xx, yj, xtub, ytub, isek, hhh, jjj, kkk)
                        If System.Math.Abs(yj + DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER Then isz = 1
                        If i > 1 Then
                            If System.Math.Abs(yj + DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER And DaTos(iDat).bu(j, i) = "1" And DaTos(iDat).bu(j, i + 1) = "9" Then
                                DaTos(iDat).bu(j, i) = CChar("0")
                            End If
                        End If
                        If i > 1 Then
                            If System.Math.Abs(yj - DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER And DaTos(iDat).bu(j, i) = "1" And DaTos(iDat).bu(j, i - 1) = "9" Then
                                DaTos(iDat).bu(j, i) = CChar("0")
                            End If
                        End If
                    End If
                    If DaTos(iDat).bu(j, i + isz) = "0" And DaTos(iDat).cinter > 1 Then
                        ' If UBound(DaTos) = 0 Then PSet (xx, yj)
                        GoTo 7110
                    End If
                    If DaTos(iDat).bu(j, i + isz) = "0" Then
                        GoTo 7110
                    End If
                    If FuoriReticolo Then
                        GoTo 7110
                    End If
7105:               If DaTos(iDat).bu(j, i + isz) = "1" Then
                        xpo = xx
                        IPRI = CShort(IPRI + 1) : idista = 0 : xxi = xx
                        If IPRI = 1 Then xin = xx : DaTos(iDat).xs(j) = xx : GoTo 4499
                        If Not DisegnaSoloPerif Then GoTo 4499
                        If xx = DaTos(iDat).xf(j) Or xx = DaTos(iDat).xs(j) Or i = DaTos(iDat).ici(j) Then GoTo 4499
                        If DaTos(iDat).bu(j, i + 1) = "9" Then GoTo 4499
                        If i > 1 Then If DaTos(iDat).bu(j, i - 1) = "9" Then GoTo 4499
                        If j = DaTos(iDat).FilaIniziale(k) Or j = DaTos(iDat).FilaFinale(k) Or (lApri = 0 And DaTos(iDat).NumeroTubiFila(j - 1) = 0) Then GoTo 4499
                        If j < DaTos(iDat).kymax And DaTos(iDat).NumeroTubiFila(j + 1) = 0 Then GoTo 4499
                        If DaTos(iDat).CurveInPianoVert Then
                            If j > 1 And DaTos(iDat).NumeroTubiFila(j - 1) = 0 Then GoTo 4499
                            If xx < 0 And System.Math.Abs(xx) - System.Math.Abs(xinx) > -0.1 Then GoTo 4499
                            If xx > 0 Then If xx - xfxi > -0.1 Then GoTo 4499
                        End If
                        If xx < 0 And yj < 0 Then If System.Math.Abs(xx) - System.Math.Abs(DaTos(iDat).xs(j - 1)) > -0.1 Then GoTo 4499
                        If xx < 0 And yj > 0 Then If System.Math.Abs(xx) - System.Math.Abs(DaTos(iDat).xs(j + 1)) > -0.1 Then GoTo 4499
                        If xx > 0 And yj < 0 Then If xx - DaTos(iDat).xf(j - 1) > -0.1 Then GoTo 4499
                        If xx > 0 And yj > 0 Then If xx - DaTos(iDat).xf(j + 1) > -0.1 Then GoTo 4499
                        If i < DaTos(iDat).ici(j) - 2 And DaTos(iDat).bu(j, i + 1) = "0" And DaTos(iDat).bu(j, i + 2) = "0" Then GoTo 4499
                        ' If Tracciatura.Modo < 103 Then PSet (xx, yj)
                        If DisegnaSoloPerif Then GoTo 7101
4499:                   If xx > 1 And kfin = -2 And DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube And Not DaTos(iDat).CurveInPianoVert And xx - 1 > DaTos(iDat).dxv Then kfin = 0 : GoTo 6751
                        If xx > 1 And kfin = -2 And DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube And Not DaTos(iDat).CurveInPianoVert And xx - 1 < DaTos(iDat).dxv Then kfin = -1 : If DaTos(iDat).TipoPasso = 4 Then kfin = 0
6751:                   If xx > 1 And DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube And Not DaTos(iDat).CurveInPianoVert Then
                            kfin = kfin + intp
                            NumForcellePerFila(kfin) = CShort(NumForcellePerFila(kfin) + 1)
                            If NumFileU < kfin Then NumFileU = kfin
                        End If
                        If CERCH = 1 Then
                            Monitor.Routines.cerc(xx, yj, (DaTos(iDat).dtubo / 2))
                        ElseIf CERCH = 0 Then
                            MainForm.g.DrawEllipse(MainForm.p, xx - 1, yj - 1, 2, 2)
                        End If
                    End If
                    If DaTos(iDat).bu(j, i) = "2" Then
                        If xx > 1 Then kfin = kfin + intp
                        idista = 1 : GoTo 7110
                        '                 PRODUCE UN ERRORE (almeno per tubi a U due passi)!!!!!!!!!!!!!!!!!!!!!!!!!
                    End If
7101:               If IPRI <> 1 Then GoTo 7110
                    If notl = 0 Then
                        DaTos(iDat).otvec = otielle(xpo, yj, DaTos(iDat).otvec, DaTos(iDat).dtubo)
                    End If
7110:               If DaTos(iDat).bu(j, i + 1) = "9" Then
                        xx = -xx : i = CShort(i + 1) : GoTo 7210
                    End If
                    xx = xx + DaTos(iDat).PassoOrizzontale
7210:           Next i
                If notl <> 1 Then xfxi = xxi : xinx = xin
                If notl = 0 And idista = 0 Then
                    DaTos(iDat).otvec = otielle(xpo, yj, DaTos(iDat).otvec, DaTos(iDat).dtubo)
                End If
7124:           DaTos(iDat).xf(j) = xpo : xpo = 0 : idista = 0
7960:           lApri = 1
            Next j
            If DaTos(iDat).hsym(k) = 2 Then
                If Not DaTos(iDat).CurveInPianoVert Then k = CShort(k + 1) : GoTo 8230
                If isym = 1 Then
                    isym = -1 : k = CShort(k - 1)
                Else
                    'LINDE
                    '' '   If Not DaTos(iDat).CurveInPianoVert = 1 And DaTos(iDat).PassoFascio > 2 Then
                    GoTo 8360
                    '' '   Else
                    '' '      isym = 1
                    '' '   End If
                End If
            End If
8230:       lApri = 0
        Next k
8360:   If notl = 1 Then DaTos(iDat).otvec = DaTos(iDat).OTL
    End Sub

    Sub DisUrto()
        Dim YURT0, YURT1 As Single
        Dim XURT, XCON As Single
        If Not DaTos(iDat).EsistePiatto Then Exit Sub
        If DaTos(iDat).URTY(1) = 0 Then
            If DaTos(iDat).CurveInPianoVert Then YURT0 = (-DaTos(iDat).y(1) + (DaTos(iDat).dtubo / 2) + 3) : GoTo ava
            YURT0 = (DaTos(iDat).y(DaTos(iDat).kymax) + (DaTos(iDat).dtubo / 2) + 3)
        Else
            YURT0 = DaTos(iDat).URTY(1)
        End If
ava:
        '-------------------------------------------------
        If YURT0 > DaTos(iDat).di1 / 2 Then
            If YURT0 = DaTos(iDat).URTY(1) Then
                YURT0 = CSng(0.8 * DaTos(iDat).di1 / 2)
                DaTos(iDat).URTY(1) = YURT0
            Else
                YURT0 = CSng(0.8 * DaTos(iDat).di1 / 2)
            End If
        End If
        '------------------------------------------------
        If DaTos(iDat).URTY(3) = 0 Then DaTos(iDat).URTY(3) = 10
        YURT1 = YURT0 + DaTos(iDat).URTY(3)
        If DaTos(iDat).URTY(2) <> 0 Then
            XURT = DaTos(iDat).URTY(2) / 2
        Else
            XURT = CSng(DaTos(iDat).hin * System.Math.Tan(System.Math.PI / 6) + DaTos(iDat).dt(3) / 2)
            If XURT = 0 Then XURT = 100
            DaTos(iDat).URTY(2) = XURT
        End If
        XCON = CSng(System.Math.Sqrt(DaTos(iDat).di1 / 2 * DaTos(iDat).di1 / 2 - YURT0 * YURT0))
        If XURT + 25 > XCON Then XURT = XCON - 25
        Monitor.Routines.trattoBF(-XURT, YURT1, XURT, YURT0, 0.2, 0)
        DaTos(iDat).URTY(1) = YURT0
        DaTos(iDat).URTY(2) = 2 * XURT
        DaTos(iDat).URTY(4) = DaTos(iDat).URTY(2)
    End Sub
    Sub Generabu()
        Dim j, k, l As Short
        Dim xx As Single
        Dim Mezzipassi, ifati As Short
        Dim yj As Single
        Dim i As Short
        Dim potenu, xto As Single
        Dim NTUTOG, NTUTOG1 As Short
        Dim JH As Short
        iDat = CShort(QualeCorona - 1)
        xmind = 0
        With DaTos(iDat)
            For k = 1 To .NumeroSettori
                For j = .FilaIniziale(k) To .FilaFinale(k)
                    If .NumeroTubiFila(j) < 1 And j <= .kymax Then GoTo 1250
                    xx = .x(j) : .xf(j) = -.x(j)
                    .xs(j) = xx
                    If xx < xmind Then xmind = xx
                    .ici(j) = .NumeroTubiFila(j)
                    If .cinter > 1 Then
                        Mezzipassi = CShort((System.Math.Abs(xx) - SpostXSettore(k)) / .PassoOrizzontale * 2)
                        .ici(j) = CShort(2 * ((Mezzipassi + 1) \ 2) + 1 - (Mezzipassi Mod 2))
                        If .hsym(2) = 2 And Not .CurveInPianoVert Then
                            .ici(j) = CShort(.ici(j) \ 2)
                            For l = 1 To .NumeroTubiFila(j) : .bu(j, l) = CChar("1") : Next
                            For l = CShort(.NumeroTubiFila(j) + 1) To .ici(j) : .bu(j, l) = CChar("0") : Next
                        Else
                            If .ici(j) < .NumeroTubiFila(j) Then .ici(j) = .NumeroTubiFila(j)
                            If .ici(j) = .NumeroTubiFila(j) Then
                                For l = 1 To .NumeroTubiFila(j) : .bu(j, l) = CChar("1") : Next
                            Else
                                For l = 1 To CShort(.NumeroTubiFila(j) \ 2) : .bu(j, l) = CChar("1") : Next
                                For l = CShort(.NumeroTubiFila(j) \ 2 + 1) To CShort(.ici(j) - .NumeroTubiFila(j) \ 2)
                                    .bu(j, l) = CChar("0")
                                Next
                                For l = CShort(.ici(j) - .NumeroTubiFila(j) \ 2 + 1) To .ici(j)
                                    .bu(j, l) = CChar("1")
                                Next
                            End If
                        End If
                    Else
                        For l = 1 To .ici(j) : .bu(j, l) = CChar("1") : Next
                    End If
                    If .CurveInPianoVert And .PassoFascio = 6 Then
                        .bu(j, .ici(j) + 1) = CChar("9")
                        For l = CShort(.ici(j) + 2) To CShort(2 * .ici(j) + 1)
                            .bu(j, l) = .bu(j, l - (.ici(j) + 1))
                        Next
                        .ici(j) = CShort(2 * .ici(j) + 1)
                        .NumeroTubiSettore(k + 1) = .NumeroTubiSettore(k)
                    Else
                        If .hsym(k) = 2 Then
                            If Not .CurveInPianoVert Then
                                .bu(j, .ici(j) + 1) = CChar("9")
                                For l = CShort(.ici(j) + 2) To CShort(2 * .ici(j) + 1)
                                    .bu(j, l) = .bu(j, l - (.ici(j) + 1))
                                Next
                                .ici(j) = CShort(2 * .ici(j) + 1)
                            End If
                            .NumeroTubiSettore(k + 1) = .NumeroTubiSettore(k)
                        End If
                    End If
                    ifati = 0 : yj = .y(j)
1906:               .otvec = otielle(.x(j), yj, .otvec, .dtubo)
                    xx = xx - .PassoOrizzontale
                    For i = 1 To .ici(j)
                        xx = xx + .PassoOrizzontale
1907:                   If .bu(j, i + 1) = "9" Then xx = -xx : i = CShort(i + 1) : GoTo 1000
                        If .cinter < 1 Or ifati = 1 Then GoTo 1000
                        potenu = CSng(System.Math.Sqrt(yj ^ 2 + xx ^ 2))
                        If potenu - (.dtubo / 2) < .cinter Then
1908:                       xto = -xx : NTUTOG = CShort(Int(1 + 2 * xto / .PassoOrizzontale))
                            ifati = 1 : NTUTOG1 = 0
                            For JH = i To CShort(i + NTUTOG - 1)
1909:                           If .bu(j, JH) = "9" Then GoTo nexti
                                If .bu(j, JH) = "1" Then
                                    NTUTOG1 = CShort(NTUTOG1 + 1)
                                End If
                                .bu(j, JH) = CChar("0")
nexti:                      Next JH
                            .NumeroTubiFila(j) = .NumeroTubiFila(j) - NTUTOG1
                            .NumeroTubiSettore(k) = .NumeroTubiSettore(k) - NTUTOG1
                            .ktotal = .ktotal - NTUTOG1
                            xx = xto + .PassoOrizzontale
                            i = i + NTUTOG
                        End If
1000:               Next i
1250:           Next j
                If .hsym(k) = 2 Then k = CShort(k + 1)
            Next k
            .otlmax = .otvec
        End With
    End Sub
    Sub inpiDIA()
200:    If DaTos(iDat).dt(30) <> 0 And DaTos(iDat).dt(32) < 5 Then
            If DaTos(iDat).dt(32) <> 1 Then DaTos(iDat).Tagl = DaTos(iDat).di1 / 2 * (1 - System.Math.Abs(DaTos(iDat).dt(30)) / 50)
            If DaTos(iDat).dt(30) < 0 Then Call PercArea() 'percentuale su area
1876:       Select Case DaTos(iDat).dt(32)
                Case 0, 1, 5 : Call DisTagl(2) 'single/ NTW /support
                Case 2 : Call DisTagl(4) 'Double segmental
                Case Else ' PRINT "Tipo diaframmi"; DaTos(iDat).dt(32); "Da fare": u$ = INPUT$(1)
            End Select
            Call DisTaglSupp()
        End If
        Call DisUrto()
    End Sub

    Sub PercArea()
        toltu = CSng(DaTos(iDat).dtubo * 0.3)
        VPA = DaTos(iDat).PassoVerticale / 2
        atu = CSng(DaTos(iDat).dtubo ^ 2 * System.Math.PI / 4)
        alor1 = DaTos(iDat).PassoOrizzontale * DaTos(iDat).PassoVerticale
        anet1 = alor1 - atu : ralibe = anet1 / alor1
        If DaTos(iDat).dt(31) = 0 Then tglareah()
        If DaTos(iDat).dt(31) = 90 Then tglareav()
        ktotu = DaTos(iDat).ktotal
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube Then ktotu = CShort(DaTos(iDat).ktotal * 2)
        atfre = CSng(System.Math.PI / 4 * (DaTos(iDat).di1 ^ 2 - ktotu * DaTos(iDat).dtubo ^ 2))
        perfre = atfre * System.Math.Abs(DaTos(iDat).dt(30)) / 100
        difs = 0 : ntui = 0 : akh = 0
220:    rbt = DaTos(iDat).Tagl / DaTos(iDat).di1 / 2
        bet = GlobalRoutines.acos(rbt)
        alord = CSng(bet * (DaTos(iDat).di1 / 2) ^ 2 - System.Math.Sin(bet) * (DaTos(iDat).di1 / 2) * DaTos(iDat).Tagl)
        If DaTos(iDat).dt(31) = 90 Then GoTo verti
        ntui = 0 : ntt = 0 : ICER = 1
        If akh = 0 Then ntt = CShort(Int(0.5 * (DaTos(iDat).NumeroTubiFila(CInt(H)) + DaTos(iDat).ntus(CInt(H)))))
        inh = CShort(H) : ifh = DaTos(iDat).kymax
        If DaTos(iDat).CurveInPianoVert Then inh = 1 : ifh = CShort(H) : ICER = 0
        For jk = inh To ifh : ntui = ntui + DaTos(iDat).NumeroTubiFila(jk) + DaTos(iDat).ntus(jk) * ICER : Next jk
        ntui = ntui - ntt
230:    alibe = alord - ntui * atu
        If alibe <> perfre Then
            difs0 = perfre - alibe
            If System.Math.Sign(difs0) + System.Math.Sign(difs) = 0 Then GoTo 4578
            tagl0 = DaTos(iDat).Tagl : difs = difs0
            ak = 0.5 : If DaTos(iDat).CurveInPianoVert Then ak = -0.5
            akh = akh - ak * System.Math.Sign(difs) : H = CSng(Fix(H + akh + 0.5))
            If System.Math.Abs(akh) >= 1 Then akh = 0
            DaTos(iDat).Tagl = DaTos(iDat).Tagl - VPA * System.Math.Sign(difs)
            GoTo 220
        End If
4578:   If System.Math.Abs(difs0) > System.Math.Abs(difs) Then DaTos(iDat).Tagl = tagl0
        If DaTos(iDat).Tagl < 0 Then DaTos(iDat).Tagl = -DaTos(iDat).Tagl
        Exit Sub
verti:  antui = 0
        For j = 1 To DaTos(iDat).kymax
            If DaTos(iDat).NumeroTubiFila(j) = 0 Or DaTos(iDat).Tagl > DaTos(iDat).xf(j) Then GoTo 4021
            antui = antui + 1 + (DaTos(iDat).xf(j) - DaTos(iDat).Tagl) / DaTos(iDat).PassoOrizzontale
4021:   Next j
        If DaTos(iDat).CurveInPianoVert Then antui = 2 * antui
        alord1 = atu * antui
        alibe = alord - alord1
        If alibe <> perfre Then
            difs0 = perfre - alibe
            If System.Math.Sign(difs0) + System.Math.Sign(difs) = 0 Then GoTo 4577
            tagl0 = DaTos(iDat).Tagl : difs = difs0
            DaTos(iDat).Tagl = DaTos(iDat).Tagl - OPA * System.Math.Sign(difs)
            GoTo 220
        End If
4577:   If System.Math.Abs(difs0) > System.Math.Abs(difs) Then DaTos(iDat).Tagl = tagl0
    End Sub
    Private Sub tglareah()
        For H = DaTos(iDat).kymax To 1 Step -1
            yj = System.Math.Abs(DaTos(iDat).y(CInt(H)))
            If yj < DaTos(iDat).Tagl + DaTos(iDat).dtubo And yj > DaTos(iDat).Tagl - DaTos(iDat).dtubo Then
                DaTos(iDat).Tagl = yj
                Exit Sub
            End If
        Next H
        Beep()
    End Sub
    Private Sub tglareav()
        OPA = DaTos(iDat).PassoOrizzontale / 2 ': IF DaTos(iDat).TipoPasso = 4 THEN opa = Datos(iDat).PassoOrizzontale
        For hvi = xmind To 1 Step OPA
            If System.Math.Abs(hvi) < DaTos(iDat).Tagl + toltu Or DaTos(iDat).Tagl - toltu > System.Math.Abs(hvi) Then
                DaTos(iDat).Tagl = System.Math.Abs(hvi)
                Exit Sub
            End If
        Next hvi
        Beep()
    End Sub

    Sub SEALING()
        Dim isk As Short
        Dim SEA2 As String
        Dim PX(4) As Single
        Dim PY(4) As Single
        '7=alfa  10=-1 alfa -2 0 -3 90 -4 180 -5 270 se non definito (definito:alfa)
        For isk = 1 To DaTos(iDat).ISEAL
            If DaTos(iDat).seal(10, isk) = 0 Then GoTo 1986
            SEA2 = CStr(DaTos(iDat).seal(3, isk) / 2) 'spessore
            If DaTos(iDat).seal(4, isk) = 0 Then DaTos(iDat).seal(4, isk) = DaTos(iDat).Passo - DaTos(iDat).dtubo
            Select Case DaTos(iDat).seal(10, isk)
                Case -6
                    SecPun(isk)
                    PXPY(PX, PY, isk)
                Case -1
                    CalcDir(isk)
                    SecPun(isk)
                    PXPY(PX, PY, isk)
                Case -2, -3, -4, -5
                    DaTos(iDat).seal(7, isk) = CSng((-DaTos(iDat).seal(10, isk) + 2) * System.Math.PI / 2)
                    SecPun(isk)
                    PXPY(PX, PY, isk)
            End Select
            DisegnoSS(PX, PY, isk, 0)
1986:   Next isk
    End Sub
    Public Sub DisegnoSS(ByRef PX() As Single, ByRef PY() As Single, ByRef isk As Short, ByRef Mode As Short)
        Dim Ry1, Rx1, Rx2, Ry2 As Single
        Dim i As Short
        Dim Tag As String
        Dim gpix As Graphics
        Dim twWidth, twLeft, twTop, twHeight As Single
        Dim pixW, pixH, pixM As Integer
        'Mode 0 disegno normale,1 ddisegno in movimento
        Dim points1(1) As PointF
        Try
            With MainForm
                points1(0) = New PointF(Min4(PX), Min4(PY))
                points1(1) = New PointF(Max4(PX), Max4(PY))
                .g.Transform.TransformPoints(points1)
                Rx1 = points1(0).X
                Rx2 = points1(1).X
                Ry1 = points1(1).Y
                Ry2 = points1(0).Y
                pixW = CInt(Rx2 - Rx1)
                pixH = CInt(Ry2 - Ry1)
                pixM = pixW : If pixH > pixM Then pixM = pixH
                If isk > .Pix.Count - 1 Then
                    .Pix.Load(isk)
                    .Pix(isk).Width = 5 * pixM
                    .Pix(isk).Height = 5 * pixM
                    Dim bmp As Bitmap = New Bitmap(.Pix(isk).ClientRectangle.Width, .Pix(isk).ClientRectangle.Height)
                    .Pix(isk).Image = bmp
                Else
                    If Mode = 1 Then
                        Try
                            Tag = GetTag(CStr(.Pix(isk).Tag))
                            Dim delimiter As Char() = {CChar("|")}
                            Dim s As String() = Tag.Split(delimiter)
                            twTop = CSng(s(0))
                            twLeft = CSng(s(1))
                            twHeight = CSng(s(2))
                            twWidth = CSng(s(3))
                            Dim m As Matrix = .g.Transform
                            .g.Transform = New Matrix
                            .g.DrawImage(.Pix(isk).Image, twLeft, twTop, New RectangleF(0, 0, twWidth, twHeight), GraphicsUnit.Pixel)
                            .g.Transform = m
                            .Picture1.Refresh()
                        Catch e As Exception
                            MsgBox(e.Message + vbCrLf + e.StackTrace)
                        End Try
                    End If
                End If
                twHeight = (Ry2 - Ry1)
                twWidth = (Rx2 - Rx1)
                twTop = Ry1
                twLeft = Rx1
                If twHeight < 0 Then twHeight = -twHeight : twTop = twTop - twHeight
                If twWidth < 0 Then twWidth = -twWidth : twLeft = twLeft - twWidth
                twTop = CShort(twTop) - 1 : twLeft = CShort(twLeft) - 1
                twHeight = CShort(twHeight) + 2 : twWidth = CShort(twWidth) + 2
                If twTop < 0 Then twTop = 0
                If twLeft < 0 Then twLeft = 0
                If twTop + twHeight > .Picture1.ClientRectangle.Height Then twHeight = .Picture1.ClientRectangle.Height - twTop
                If twLeft + twWidth > .Picture1.ClientRectangle.Width Then twWidth = .Picture1.ClientRectangle.Width - twWidth
                .Pix(isk).Tag = SetTag(CStr(.Pix(isk).Tag), twTop.ToString & "|" & twLeft.ToString & "|" & twHeight.ToString & "|" & twWidth.ToString)
                gpix = Graphics.FromImage(.Pix(isk).Image)
                gpix.DrawImage(Monitor.Routines.DoveBitmap, 0, 0, New RectangleF(twLeft, twTop, twWidth, twHeight), GraphicsUnit.Pixel)
                gpix.Dispose()
                If Mode = 0 Then
                    Monitor.Routines.tratto(PX(1), PY(1), PX(2), PY(2), 0.3, 0)
                    Monitor.Routines.tratto(PX(2), PY(2), PX(3), PY(3), 0.3, 0)
                    Monitor.Routines.tratto(PX(3), PY(3), PX(4), PY(4), 0.3, 0)
                    Monitor.Routines.tratto(PX(4), PY(4), PX(1), PY(1), 0.3, 0)
                Else
                    .p.DashStyle = Drawing2D.DashStyle.Solid '    frmTracciat.Picture1.DrawStyle = vbSolid
                    Dim points(4) As PointF
                    For i = 0 To 3
                        points(i).X = PX(i + 1)
                        points(i).Y = PY(i + 1)
                    Next
                    points(4).X = PX(1)
                    points(4).Y = PY(1)
                    .p.Color = Color.Red
                    .g.DrawPolygon(.p, points)
                    .p.Color = Color.Black
                End If
                .Picture1.Refresh()
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub CalcDir(ByRef isk As Short)
        Dim Diry, Dirx, Raggio As Single
        Raggio = CSng(System.Math.Sqrt(DaTos(iDat).seal(1, isk) ^ 2 + DaTos(iDat).seal(2, isk) ^ 2))
        If Raggio = 0 Then Exit Sub
        Dirx = DaTos(iDat).seal(1, isk) / Raggio
        Diry = DaTos(iDat).seal(2, isk) / Raggio
        DaTos(iDat).seal(7, isk) = GlobalRoutines.arco(Dirx, Diry)
    End Sub

    Public Sub PXPY(ByRef PX() As Single, ByRef PY() As Single, ByRef isk As Short)
        Dim catx, SEA2, caty As Single
        SEA2 = DaTos(iDat).seal(3, isk) / 2
        catx = CSng(SEA2 * System.Math.Sin(DaTos(iDat).seal(7, isk)))
        caty = CSng(SEA2 * System.Math.Cos(DaTos(iDat).seal(7, isk)))
        PX(1) = DaTos(iDat).seal(1, isk) + catx : PX(2) = PX(1) - 2 * catx
        PX(3) = DaTos(iDat).seal(8, isk) - catx : PX(4) = PX(3) + 2 * catx
        PY(1) = DaTos(iDat).seal(2, isk) - caty : PY(2) = PY(1) + 2 * caty 'get/line
        PY(3) = DaTos(iDat).seal(9, isk) + caty : PY(4) = PY(3) - 2 * caty

    End Sub

    Sub SubTraccia(ByRef Mode As Short)
        Dim idi0 As Single, Testo As String
        kdati = 1
        If DaTos(iDat).dt(37) = 1 Then Mtacsu = 1
        If DaTos(iDat).dt(37) = 2 Then Mtacgiu = 1
        If DaTos(iDat).dt(37) = 3 Then Mtacgiu = 1 : Mtacsu = 1
        DaTos(iDat).otvec = 0 : If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then DaTos(1).otvec = 0
        Call DiaTir()
        QualeCorona = 1
        If DaTos(iDat).ILFINAL = 0 Then
            If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
                DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse : DaTos(iDat).PassoFascio = traccia.clsTracciatura.PassiFascio._1
                QualeCorona = 1
                Call Generabu()
                DaTos(1).otvec = 0 : DaTos(1).TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse
                DaTos(1).PassoFascio = traccia.clsTracciatura.PassiFascio._1
                QualeCorona = 2
                Call Generabu()
                DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana : DaTos(0).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
                DaTos(1).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana : DaTos(1).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
                QualeCorona = 1 : iDat = 0
            Else
                Call Generabu()
            End If
        End If
        xcsi = 0 : ypsi = 0
        '---------------------------------------------------------------
        CERCH = -1
        SuperDisTubi()
        '----------------------------------------------------------------
        If (DaTos(iDat).dtubo / 2) < 1 Then CERCH = 0 Else CERCH = 1
        DaTos(iDat).OTL = DaTos(iDat).otvec
        If DaTos(iDat).otvec > DaTos(iDat).di1 - 10 Then
            Dim EraZero As Boolean = DaTos(iDat).di1 = 0
            Call Tracciatura.diadiffe()
            DaTos(iDat).di1 = CSng(Int(DaTos(iDat).otvec + GiocoDiaframmi + 0.51))
            Call DiaTir()
            'Testo = "Il diametro interno era inferiore a" + (DaTos(iDat).otvec + 10).ToString + "." + vbCrLf + "Accettare la proposta o inserire un valore maggiore"
            If Not EraZero Then
                Testo = Format(DaTos(iDat).otvec + 10, at1(180))
                idi0 = CSng(GlobalRoutines.ValVir(InputBox(Testo, "", DaTos(iDat).di1.ToString)))
                DaTos(iDat).di1 = idi0
            End If
        End If
        If Mode = 0 Then Call scalavi()
        RYMAX = CSng(DaTos(iDat).di1 / 2 * 1.3) : RXMAX = CSng(DaTos(iDat).di1 / 2 * 1.15)
        Rinx1 = 0 : Rinx2 = 0 : Riny1 = 0 : Riny2 = 0
        If CERCH = 0 Then
            Rinx1 = DaTos(iDat).di1 / 2 : Rinx2 = -DaTos(iDat).di1 / 2
            Riny1 = DaTos(iDat).di1 / 2 : Riny2 = -DaTos(iDat).di1 / 2
        End If
        pgm = 0 : pgd = 2 * System.Math.PI : pgs = pgd : rdiaf = DaTos(iDat).Didia / 2
        If Mtacsu = 1 Or Mtacgiu = 1 Then
            sen = CSng(11.2 / rdiaf)
            pgm = CSng(System.Math.Asin(sen))
            sen = 10 / rdiaf
            System.Math.Asin(sen)
            catx = CSng(rdiaf * System.Math.Cos(pgm))
            CATXx = CSng(rdiaf * System.Math.Cos(pgmm))
        End If
        MainForm.rutdis = 1
    End Sub
    Public Sub SuperDisTubi()
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
            DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse
            DaTos(iDat).PassoFascio = traccia.clsTracciatura.PassiFascio._1
            QualeCorona = 1
            Call DisTubi(CERCH)
            DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse : DaTos(iDat).PassoFascio = traccia.clsTracciatura.PassiFascio._1
            QualeCorona = 2
            Call DisTubi(CERCH)
            DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana : DaTos(0).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
            DaTos(1).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana : DaTos(1).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
            QualeCorona = 1 : iDat = 0
        Else
            Call DisTubi(CERCH)
        End If

    End Sub
    Public Sub Distraccia(Optional ByVal notClear As Boolean = False)
        Dim nDati As Short = 0
        Dim lociDat As Short
        If MainForm.g Is Nothing Then Exit Sub
        Monitor.Routines.ctrait(0, 0.1)
        If Not notClear Then MainForm.g.Clear(Color.White)
        Call DisRod(CERCH)
        SuperDisTubi()
        Monitor.Routines.tratto(RXMAX, 0, Rinx1, 0, 0.1, 3)
        Monitor.Routines.tratto(-RXMAX, 0, Rinx2, 0, 0.1, 3)
        Monitor.Routines.tratto(0, RYMAX, 0, Riny1, 0.1, 3)
        Monitor.Routines.tratto(0, -RYMAX, 0, Riny2, 0.1, 3)
        Monitor.Routines.ctrait(0, 0.1)
        If Mtacsu = 1 Then
            pgd = pgd - pgm : pgs = pgs + pgm
            PGDd = CSng(2 * System.Math.PI - pgmm) : PGSs = CSng(2 * System.Math.PI + pgmm)
            Monitor.Routines.tratto(-10, catx, 0, rdiaf - 15, 0.1, 0)
            Monitor.Routines.tratto(0, rdiaf - 15, 10, catx, 0.1, 0)
        End If
        Monitor.Routines.arc(0, 0, rdiaf, 0, CSng(pgd * 180 / System.Math.PI))
        If 2 * System.Math.PI - pgs > 0.001 Then Monitor.Routines.arc(0, 0, _
        CSng(rdiaf * System.Math.Cos(pgs)), CSng(rdiaf * System.Math.Sin(pgs)), _
        CSng((2 * System.Math.PI - pgs) * 180 / System.Math.PI))
        pgd = 1.5 * System.Math.PI : pgs = pgd
        If Mtacgiu = 1 Then
            Monitor.Routines.tratto(-10, -catx, 0, -rdiaf + 15, 0.1, 0)
            Monitor.Routines.tratto(0, -rdiaf + 15, -10, -catx, 0.1, 0)
            pgs = pgs - pgm : pgd = pgd + pgm
            Monitor.Routines.arc(0, 0, -rdiaf, 0, CSng((pgs - System.Math.PI) * 180 / System.Math.PI)) '8366
            PGSs = CSng(1.5 * System.Math.PI - pgmm) : PGDd = CSng(1.5 * System.Math.PI + pgmm)
        End If
        Monitor.Routines.arc(0, 0, CSng(rdiaf * System.Math.Cos(System.Math.PI)), _
        CSng(rdiaf * System.Math.Sin(System.Math.PI)), CSng((pgs - System.Math.PI) * 180 / System.Math.PI))
        Monitor.Routines.arc(0, 0, CSng(rdiaf * System.Math.Cos(pgd)), _
        CSng(rdiaf * System.Math.Sin(pgd)), CSng((2 * System.Math.PI - pgd) * 180 / System.Math.PI))
        Monitor.Routines.cerc(0, 0, DaTos(0).di1 / 2)
        If DaTos(0).cinter > 1 Then Monitor.Routines.cerc(0, 0, DaTos(0).cinter) ': 'CALL cerchio(0, 0, DaTos(0).cinter)
        If DaTos(0).otvec <> 0 Then GlobalRoutines.SWAP(DaTos(0).OTL, DaTos(0).otvec)
        Monitor.Routines.cerc(0, 0, DaTos(0).OTL / 2)
        If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
            nDati = 1
            If DaTos(1).cinter > 1 Then Monitor.Routines.cerc(0, 0, DaTos(1).cinter)
            If DaTos(1).otvec <> 0 Then GlobalRoutines.SWAP(DaTos(1).OTL, DaTos(1).otvec)
            Monitor.Routines.cerc(0, 0, DaTos(1).OTL / 2)
        End If
        '-----------------disegno diaframmi
        Call inpiDIA()
        '---------disegno bocchelli
        XSU = DaTos(0).dt(3) / 2 : XGIU = DaTos(0).dt(4) / 2 'raggi bocchelli
        YSU = CSng(System.Math.Sqrt((DaTos(0).di1 / 2) ^ 2 - XSU ^ 2))
        YGIU = CSng(System.Math.Sqrt((DaTos(0).di1 / 2) ^ 2 - XGIU ^ 2))
        With Monitor.Routines
            If XSU > 0 Then
                .tratto(-XSU, YSU, -XSU, (DaTos(0).di1 / 2 + 20), 0.1, 0)
                .tratto(-XSU, (DaTos(0).di1 / 2 + 20), XSU, (DaTos(0).di1 / 2 + 20), 0.1, 3)
                .tratto(XSU, (DaTos(0).di1 / 2 + 20), XSU, YSU, 0.1, 0)
            End If
            If XGIU > 0 Then
                .tratto(-XGIU, -YGIU, -XGIU, (-DaTos(0).di1 / 2 - 20), 0.1, 0)
                .tratto(-XGIU, (-DaTos(0).di1 / 2 - 20), XGIU, (-DaTos(0).di1 / 2 - 20), 0.1, 3)
                .tratto(XGIU, (-DaTos(0).di1 / 2 - 20), XGIU, -YGIU, 0.1, 3)
            End If
            .ctrait(0, 0.1)
        End With
        With MainForm
            .p.DashStyle = Drawing2D.DashStyle.Solid
            '---------------disegno sealing strips
            Call SEALING()
            '---------------disegno tiranti
            For lociDat = 0 To nDati
                For j = 1 To DaTos(lociDat).ntira
                    Try
                        If DaTos(lociDat).td(1, j) = 0 And DaTos(lociDat).td(2, j) = 0 Then GoTo 7901
                        If DaTos(lociDat).td(3, j) = 0 Then DaTos(lociDat).td(3, j) = CSng(Int(DaTos(lociDat).dtubo / 2.5))
                        If CERCH = 1 Then
                            .g.DrawArc(.p, DaTos(lociDat).td(1, j) - DaTos(lociDat).dtubo / 2, DaTos(lociDat).td(2, j) - DaTos(lociDat).dtubo / 2, DaTos(lociDat).dtubo, DaTos(lociDat).dtubo, 0, 360)
                            .g.DrawArc(.p, DaTos(lociDat).td(1, j) - DaTos(lociDat).td(3, j) / 2, DaTos(lociDat).td(2, j) - DaTos(lociDat).td(3, j) / 2, DaTos(lociDat).td(3, j), DaTos(lociDat).td(3, j), 0, 360)
                            GoTo 7901
                        End If
                        .g.DrawArc(.p, DaTos(lociDat).td(1, j) - DaTos(lociDat).dtubo / 10, DaTos(lociDat).td(2, j) - DaTos(lociDat).dtubo / 10, DaTos(lociDat).dtubo / 5, DaTos(lociDat).dtubo / 5, 0, 360)
                    Catch e As Exception
                        MsgBox(e.Message + vbCrLf + e.StackTrace)
                    End Try
                    ' MainForm.Picture1.PSet(DaTos(iDat).td(1, j), DaTos(iDat).td(2, j))
7901:           Next j
            Next
        End With
        MainForm.Picture1.Refresh()
    End Sub
    Public Function Max4(ByRef PX() As Single) As Single
        Dim i As Short
        Dim MAX As Single
        MAX = -10000000000.0#
        For i = 1 To 4
            If PX(i) > MAX Then MAX = PX(i)
        Next
        Max4 = MAX
    End Function
    Public Function Min4(ByRef PX() As Single) As Single
        Dim i As Short
        Dim Min As Single
        Min = 10000000000.0#
        For i = 1 To 4
            If PX(i) < Min Then Min = PX(i)
        Next
        Min4 = Min
    End Function

    Public Sub SecPun(ByRef isk As Short)
        DaTos(iDat).seal(8, isk) = CSng(DaTos(iDat).seal(1, isk) + DaTos(iDat).seal(5, isk) * System.Math.Cos(DaTos(iDat).seal(7, isk)))
        DaTos(iDat).seal(9, isk) = CSng(DaTos(iDat).seal(2, isk) + DaTos(iDat).seal(5, isk) * System.Math.Sin(DaTos(iDat).seal(7, isk)))
    End Sub

    Public Sub DisTaglio(ByRef j As Short)
        Dim Arg, PXX As Single
        Arg = (DaTos(iDat).Didia / 2) * (DaTos(iDat).Didia / 2) - DaTos(iDat).tagli(j) * DaTos(iDat).tagli(j)
        If Arg > 0 Then PXX = CSng(System.Math.Sqrt(Arg)) Else PXX = 0
        Select Case DaTos(iDat).dt(31) 'angolo taglio
            Case 0
                Monitor.Routines.tratto(-PXX, DaTos(iDat).tagli(j), PXX, DaTos(iDat).tagli(j), 0, 3)
            Case 90
                Monitor.Routines.tratto(DaTos(iDat).tagli(j), PXX, DaTos(iDat).tagli(j), -PXX, 0, 3)
        End Select
    End Sub

    Public Sub AggiustaTaglio(ByRef j As Short)
        Dim ILSEGNO As Short
        If DaTos(iDat).tagli(j) = 0 Then ' GoTo 1852
            ILSEGNO = 1 : If j Mod 2 = 0 Then ILSEGNO = -1
            If j > 2 Then DaTos(iDat).tagli(j) = (DaTos(iDat).di1 / 2 - DaTos(iDat).Tagl) * ILSEGNO
            If j < 3 Then DaTos(iDat).tagli(j) = DaTos(iDat).Tagl * ILSEGNO
        End If
        Select Case DaTos(iDat).dt(31) 'angolo taglio
            Case 0 : DaTos(iDat).tagli(9) = 1
            Case 90 : DaTos(iDat).tagli(9) = 2
        End Select
    End Sub
    Sub DisTEMA(ByRef icount As Short)
        If icount = 0 Then Exit Sub
        Monitor.Routines.ctrait(3, 0.5)
        Tracciatura.P0.SpezzGraf(1, icount, (Monitor.Routines))
        Tracciatura.p1.SpezzGraf(1, icount, (Monitor.Routines))
        Monitor.Routines.ctrait(0, 0.7)
        Monitor.Routines.cerc(0, 0, Tracciatura.Diaml / 2)
        MainForm.Picture1.Refresh()
    End Sub
    Public Function AssenteVicino(ByVal xx As Single, ByVal j As Short, ByVal lociDat As Short) As Boolean
        Dim i As Short
        Dim xv As Single
        Dim found As Boolean
        xv = DaTos(lociDat).x(j)
        For i = 1 To DaTos(lociDat).ici(j)
            If System.Math.Abs(xx - xv) < DaTos(lociDat).PassoOrizzontale Then
                If DaTos(lociDat).bu(j, i) = "1" Then
                    found = True
                Else
                    AssenteVicino = True
                    Exit Function
                End If
            Else
                If found Then Exit Function
            End If
            If DaTos(lociDat).bu(j, i + 1) <> "9" Then
                xv = xv + DaTos(lociDat).PassoOrizzontale
            Else
                i = CShort(i + 1)
                xv = -xv
            End If
        Next
    End Function
End Module