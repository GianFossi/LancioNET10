Module modScritture
    Friend CompilTabGood As Boolean
    Friend FattoMAWP As Boolean
    Private Rear As Short
    Private nAvanz, iAvanz As Short
    Private Equipment(8) As Single
    Private Indkmax(8) As Short
    Private Indjmax(8) As Short
    Private InvNoz(8) As Boolean
    Private i, k, j, l As Integer
    Private MAWP(8) As Single
    Private kN, ll, i1 As Short
    Private kk, kkk As Short
    Private vMAWP As clsValoriMAWP
    Private Nuovo As Boolean
    Private Syo, Sya As Single
    Private matFlangia As Boolean
    Private Testo, Nome As String
    Private St As Short
    Private O As wn_PT
    Private Sya1, Syo1 As Single
    Public Overloads Sub TabReqRes(ByVal Documento As StubW2000.clsSW2000)
        Dim Nome As String
        Dim vMDMT As clsValoriMDMT
        Dim k As Short
        Dim i As Short
        Dim Testo As String
        If Config(1).NMWDT = 0 And Config(2).NMWDT = 0 Then
            If Not ContinuoAuto Then MessageBox.Show("Questa procedura non può essere eseguita in quanto non sono state specificate condizioni di progetto a bassa temperatura")
            Exit Sub
        End If
        CompilTabGood = False
        Nome = "\TabMDMT.doc"
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        With Documento
            If .VaiInizio("StartMDMT") = 0 Then
                MessageBox.Show("Le esenzioni dalle prove di resilienza per il documento attivo sono già state compilate")
                Exit Sub
            End If
            Try
                .sOpen(clsInizio.Archdir & Nome, True, 1)
            Catch e As Exception
                Testo = e.Message
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                mioApert.Enabled = True
                Warn(Testo)
                .Visible = True
            End Try
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella esenzioni", "AsmeVip")
            InterrompiMAWP = False
            mioApert.Enabled = False
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            .VaiInizio("Exemptions")
            .ASMEPI()
            .VaiInizio("StartMDMT")
            Monitor.Motore.Avanzamento = 10
            If InterrompiMAWP Then GoTo FineNoSuccess
            i = 1
            For Each vMDMT In colMDMT
                If i = 1 Then
                    .SubstitBookM("StartMDMT", vMDMT.Mark)
                Else
                    If vMDMT.Secondo Then
                        .Testo("2nd condition")
                    Else
                        .Testo(vMDMT.Mark)
                    End If
                End If
                .MuoviCella(1)
                .Testo(vMDMT.Rule)
                For k = 1 To 5
                    .MuoviCella(1)
                    If vMDMT.Exempt(k) Then
                        .Testo("Y")
                    Else
                        .Testo("N")
                    End If
                    .MuoviCella(1)
                    .Testo(vMDMT.Articl(k))
                Next k
                .InserisciRiga(1)
                .MuoviCaratt(-1)
                Monitor.Motore.Avanzamento = 10 + 90 * i / colMDMT.Count()
                If InterrompiMAWP Then GoTo FineNoSuccess
                i = i + 1
            Next vMDMT
            .MuoviCella(1)
            CompilTabGood = False
FineNoSuccess:
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Monitor.Motore.ProgrAmmazza()
            mioApert.Enabled = True
            If Not OptWordIn Then .Massimizza()
        End With
    End Sub
    Public Overloads Sub TabReqRes(ByVal Documento As StubW9.clsSW9)
        Dim Nome As String
        Dim vMDMT As clsValoriMDMT
        Dim k As Short
        Dim i As Short
        Dim Testo As String
        If Config(1).NMWDT = 0 And Config(2).NMWDT = 0 Then
            If Not ContinuoAuto Then MessageBox.Show("Questa procedura non può essere eseguita in quanto non sono state specificate condizioni di progetto a bassa temperatura")
            Exit Sub
        End If
        CompilTabGood = False
        Nome = "\TabMDMT.doc"
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        With Documento
            If .VaiInizio("StartMDMT") = 0 Then
                MessageBox.Show("Le esenzioni dalle prove di resilienza per il documento attivo sono già state compilate")
                Exit Sub
            End If
            Try
                .sOpen(clsInizio.Archdir & Nome, True, 1)
            Catch e As Exception
                Testo = e.Message
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                mioApert.Enabled = True
                Warn(Testo)
                .Visible = True
            End Try
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella esenzioni", "AsmeVip")
            InterrompiMAWP = False
            mioApert.Enabled = False
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            .VaiInizio("Exemptions")
            .ASMEPI()
            .VaiInizio("StartMDMT")
            Monitor.Motore.Avanzamento = 10
            If InterrompiMAWP Then GoTo FineNoSuccess
            i = 1
            For Each vMDMT In colMDMT
                If i = 1 Then
                    .SubstitBookM("StartMDMT", vMDMT.Mark)
                Else
                    If vMDMT.Secondo Then
                        .Testo("2nd condition")
                    Else
                        .Testo(vMDMT.Mark)
                    End If
                End If
                .MuoviCella(1)
                .Testo(vMDMT.Rule)
                For k = 1 To 5
                    .MuoviCella(1)
                    If vMDMT.Exempt(k) Then
                        .Testo("Y")
                    Else
                        .Testo("N")
                    End If
                    .MuoviCella(1)
                    .Testo(vMDMT.Articl(k))
                Next k
                .InserisciRiga(1)
                .MuoviCaratt(-1)
                Monitor.Motore.Avanzamento = 10 + 90 * i / colMDMT.Count()
                If InterrompiMAWP Then GoTo FineNoSuccess
                i = i + 1
            Next vMDMT
            .MuoviCella(1)
            CompilTabGood = False
FineNoSuccess:
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Monitor.Motore.ProgrAmmazza()
            mioApert.Enabled = True
            If Not OptWordIn Then .Massimizza()
        End With
    End Sub
    Private Overloads Sub NozNoz(ByVal Documento As StubW2000.clsSW2000)
        With Documento
            .TastoTab() '.MuoviCella 1
            .Testo(Trim(Nozzles(kLato, kNozzle).Mark))
            .MuoviCella(1)
            .Testo(Trim(Nozzles(kLato, kNozzle).MATE))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Nozzles(kLato, kNozzle).AllN, 5, 2, False))
            .MuoviCella(1)
            If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
                Matdim(Nozzles(kLato, kNozzle).indice).Zitto = True
                Matdim(Nozzles(kLato, kNozzle).indice).SigmaAmm(CodiceStress, TempDes, Sya, Syo)
                Matdim(Nozzles(kLato, kNozzle).indice).Zitto = False
                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                .MuoviCella(1)
                If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
                    Matdim(Nozzles(kLato, kNozzle).indice).Zitto = True
                    Matdim(Nozzles(kLato, kNozzle).indice).YieldTemp(CodiceStress, TempDes, Sya1, Syo1)
                    Matdim(Nozzles(kLato, kNozzle).indice).Zitto = False
                Else
                    Syo1 = 0
                End If
                .Testo(GlobalRoutines.myStr(Syo1, 5, 2, False))
                matFlangia = False
                RegNozzle()
            Else
                Sya = 0
                GlobalRoutines.FormatS("non|")
                Testo = GlobalRoutines.FormatS(Helpstringa(IDH_MANCAINDMAT), Trim(Nozzles(kLato, kNozzle).Mark))
                MostraAiuto(IDH_MANCAINDMAT, , Testo)
            End If
        End With
        If Sya <> 0 Then
            If Nozzles(kLato, kNozzle).IndexF > 0 Then
                If Nozzles(kLato, kNozzle).IndexF <> Nozzles(kLato, kNozzle).indice Then
                    If Not Matdim(Nozzles(kLato, kNozzle).IndexF) Is Nothing And Nozzles(kLato, kNozzle).Rati > 0 Then
                        If Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat <> Matdim(Nozzles(kLato, kNozzle).indice).Indmat And Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat > 0 Then
                            With Documento
                                .TastoTab() '.MuoviCella 1
                                .Testo(Trim(Nozzles(kLato, kNozzle).Mark) & " (fl.)")
                                .MuoviCella(1)
                                .Testo(Trim(Matdim(Nozzles(kLato, kNozzle).IndexF).MatStr))
                                .MuoviCella(1)
                                .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
                                .MuoviCella(1)
                                Matdim(Nozzles(kLato, kNozzle).IndexF).SigmaAmm(CodiceStress, TempDes, Sya, Syo)
                                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                                .MuoviCella(1)
                                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                                .MuoviCella(1)
                                Matdim(Nozzles(kLato, kNozzle).IndexF).YieldTemp(CodiceStress, TempDes, Sya, Syo)
                                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                                matFlangia = True
                                RegNozzle()
                            End With
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Overloads Sub NozNoz(ByVal Documento As StubW9.clsSW9)
        With Documento
            .TastoTab() '.MuoviCella 1
            .Testo(Trim(Nozzles(kLato, kNozzle).Mark))
            .MuoviCella(1)
            .Testo(Trim(Nozzles(kLato, kNozzle).MATE))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Nozzles(kLato, kNozzle).AllN, 5, 2, False))
            .MuoviCella(1)
            If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
                Matdim(Nozzles(kLato, kNozzle).indice).Zitto = True
                Matdim(Nozzles(kLato, kNozzle).indice).SigmaAmm(CodiceStress, TempDes, Sya, Syo)
                Matdim(Nozzles(kLato, kNozzle).indice).Zitto = False
                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                .MuoviCella(1)
                If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
                    Matdim(Nozzles(kLato, kNozzle).indice).Zitto = True
                    Matdim(Nozzles(kLato, kNozzle).indice).YieldTemp(CodiceStress, TempDes, Sya1, Syo1)
                    Matdim(Nozzles(kLato, kNozzle).indice).Zitto = False
                Else
                    Syo1 = 0
                End If
                .Testo(GlobalRoutines.myStr(Syo1, 5, 2, False))
                matFlangia = False
                RegNozzle()
            Else
                Sya = 0
                GlobalRoutines.FormatS("non|")
                Testo = GlobalRoutines.FormatS(Helpstringa(IDH_MANCAINDMAT), Trim(Nozzles(kLato, kNozzle).Mark))
                MostraAiuto(IDH_MANCAINDMAT, , Testo)
            End If
        End With
        If Sya <> 0 Then
            If Nozzles(kLato, kNozzle).IndexF > 0 Then
                If Nozzles(kLato, kNozzle).IndexF <> Nozzles(kLato, kNozzle).indice Then
                    If Not Matdim(Nozzles(kLato, kNozzle).IndexF) Is Nothing And Nozzles(kLato, kNozzle).Rati > 0 Then
                        If Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat <> Matdim(Nozzles(kLato, kNozzle).indice).Indmat And Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat > 0 Then
                            With Documento
                                .TastoTab() '.MuoviCella 1
                                .Testo(Trim(Nozzles(kLato, kNozzle).Mark) & " (fl.)")
                                .MuoviCella(1)
                                .Testo(Trim(Matdim(Nozzles(kLato, kNozzle).IndexF).MatStr))
                                .MuoviCella(1)
                                .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
                                .MuoviCella(1)
                                Matdim(Nozzles(kLato, kNozzle).IndexF).SigmaAmm(CodiceStress, TempDes, Sya, Syo)
                                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                                .MuoviCella(1)
                                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                                .MuoviCella(1)
                                Matdim(Nozzles(kLato, kNozzle).IndexF).YieldTemp(CodiceStress, TempDes, Sya, Syo)
                                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                                matFlangia = True
                                RegNozzle()
                            End With
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Overloads Sub DatiNozMAWP(ByVal Documento As StubW2000.clsSW2000)
        For kN = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            Documento.TastoTab() '.MuoviCella 1
            Documento.Testo(Trim(Nozzles(k, kN).Mark))
            For l = 1 To 8 : MAWP(l) = 0 : Next
            Select Case kLato
                Case 1
                    For l = 1 To 4
                        ll = 1 + (l - 1) * 2
                        MAWP(ll) = Nozzles(kLato, kN).MAWP(l - 1)
                        If MAWP(ll) > 10000000000.0# Then MAWP(ll) = 0
                    Next
                Case 2
                    For l = 1 To 4
                        ll = l * 2
                        MAWP(ll) = Nozzles(kLato, kN).MAWP(l - 1)
                        If MAWP(ll) > 10000000000.0# Then MAWP(ll) = 0
                    Next
            End Select
            With Documento
                If UnLato Then St = 2 Else St = 1
                For ll = 1 To 8 Step St
                    .MuoviCella(1)
                    If MAWP(ll) > 0 Then
                        .Testo(GlobalRoutines.myStr(MAWP(ll), 5, 2, True))
                        'If Indkmax(ll) = k And Indjmax(ll) = kN And Not InvNoz(ll) Then
                        '   .ASMEsinistra
                        'End If
                        .ASMESinistra(Indkmax(ll) = k And Indjmax(ll) = kN And Not InvNoz(ll))
                    End If
                Next
            End With
        Next
    End Sub
    Private Overloads Sub DatiNozMAWP(ByVal Documento As StubW9.clsSW9)
        For kN = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            Documento.TastoTab() '.MuoviCella 1
            Documento.Testo(Trim(Nozzles(k, kN).Mark))
            For l = 1 To 8 : MAWP(l) = 0 : Next
            Select Case kLato
                Case 1
                    For l = 1 To 4
                        ll = 1 + (l - 1) * 2
                        MAWP(ll) = Nozzles(kLato, kN).MAWP(l - 1)
                        If MAWP(ll) > 10000000000.0# Then MAWP(ll) = 0
                    Next
                Case 2
                    For l = 1 To 4
                        ll = l * 2
                        MAWP(ll) = Nozzles(kLato, kN).MAWP(l - 1)
                        If MAWP(ll) > 10000000000.0# Then MAWP(ll) = 0
                    Next
            End Select
            With Documento
                If UnLato Then St = 2 Else St = 1
                For ll = 1 To 8 Step St
                    .MuoviCella(1)
                    If MAWP(ll) > 0 Then
                        .Testo(GlobalRoutines.myStr(MAWP(ll), 5, 2, True))
                        'If Indkmax(ll) = k And Indjmax(ll) = kN And Not InvNoz(ll) Then
                        '   .ASMEsinistra
                        'End If
                        .ASMESinistra(Indkmax(ll) = k And Indjmax(ll) = kN And Not InvNoz(ll))
                    End If
                Next
            End With
        Next
    End Sub
    Private Overloads Sub DatiNoz(ByVal Documento As StubW2000.clsSW2000)
        For kkk = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            kNozzle = kkk
            NozNoz(Documento)
            If Sya = 0 Then Exit Sub
            For kk = Nozzles(kLato, kkk).inizio To Nozzles(kLato, kkk).Fine
                kNozzle = kk
                NozNoz(Documento)
                If Sya = 0 Then Exit Sub
            Next
        Next
    End Sub
    Private Overloads Sub DatiNoz(ByVal Documento As StubW9.clsSW9)
        For kkk = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            kNozzle = kkk
            NozNoz(Documento)
            If Sya = 0 Then Exit Sub
            For kk = Nozzles(kLato, kkk).inizio To Nozzles(kLato, kkk).Fine
                kNozzle = kk
                NozNoz(Documento)
                If Sya = 0 Then Exit Sub
            Next
        Next
    End Sub
    Private Overloads Sub DatiInvMAWP(ByVal Documento As StubW2000.clsSW2000)
        For l = 1 To 8 : MAWP(l) = 0 : Next
        Select Case kLato
            Case 1
                For l = 1 To 4
                    ll = 1 + (l - 1) * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
            Case 2
                For l = 1 To 4
                    ll = l * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
            Case 3
                For l = 1 To 4
                    ll = l * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP2(l - 1)
                Next
                For l = 1 To 4
                    ll = 1 + (l - 1) * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
        End Select
        If kLato = 3 And Involucr(kLato, jInvolucr).Tipo = 6 Then
            O = objMemb(Involucr(kLato, jInvolucr).IndObject)
            If O.TipoPT = 1 Then Rear = O.Piastra.Rear
            If O.ProgDiffPr And Not Rear = 1 Then
                If UnLato Then St = 2 Else St = 1
                With Documento
                    For ll = 1 To 8 Step St
                        .MuoviCella(1)
                        .Testo("DP")
                    Next
                End With
            Else
                PrintTab(Documento)
            End If
        Else
            PrintTab(Documento)
        End If
    End Sub
    Private Overloads Sub DatiInvMAWP(ByVal Documento As StubW9.clsSW9)
        For l = 1 To 8 : MAWP(l) = 0 : Next
        Select Case kLato
            Case 1
                For l = 1 To 4
                    ll = 1 + (l - 1) * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
            Case 2
                For l = 1 To 4
                    ll = l * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
            Case 3
                For l = 1 To 4
                    ll = l * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP2(l - 1)
                Next
                For l = 1 To 4
                    ll = 1 + (l - 1) * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
        End Select
        If kLato = 3 And Involucr(kLato, jInvolucr).Tipo = 6 Then
            O = objMemb(Involucr(kLato, jInvolucr).IndObject)
            If O.TipoPT = 1 Then Rear = O.Piastra.Rear
            If O.ProgDiffPr And Not Rear = 1 Then
                If UnLato Then St = 2 Else St = 1
                With Documento
                    For ll = 1 To 8 Step St
                        .MuoviCella(1)
                        .Testo("DP")
                    Next
                End With
            Else
                PrintTab(Documento)
            End If
        Else
            PrintTab(Documento)
        End If
    End Sub
    Public Overloads Sub TabPI(ByVal Documento As StubW2000.clsSW2000)
        Dim i, k As Short
        Dim vMAWP As clsValoriMAWP
        Dim Testo, Nome As String
        Dim iAvanz As Short
        Dim iNota As Short
        CompilTabGood = False
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        If Documento.VaiInizio("StartPI") = 0 Then
            MessageBox.Show("I requisiti di prova idraulica per il documento attivo sono già stati compilati")
            Exit Sub
        End If
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella prova idraulica", "AsmeVip")
        On Error GoTo ErrAutom
        Select Case Config(0).MetodoPI
            Case 0
                If Not CalcolaPIb() Then GoTo FineNoSuccess
                If UnLato Then
                    Documento.sOpen(clsInizio.Archdir & "\TabPIb1.doc", True, 1)
                Else
                    Documento.sOpen(clsInizio.Archdir & "\TabPIb.doc", True, 1)
                End If
            Case 1
                If Not FattoMAWP Then
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    MostraAiuto(IDH_MANCATABMAWP)
                    GoTo FineNoSuccess
                End If
                If Not CalcolaPIc() Then GoTo FineNoSuccess
                If UnLato Then
                    Documento.sOpen(clsInizio.Archdir & "\TabPI1.doc", True, 1)
                Else
                    Documento.sOpen(clsInizio.Archdir & "\TabPI.doc", True, 1)
                End If
        End Select
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        mioApert.Enabled = False
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo FineNoSuccess
        With Documento
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            .VaiInizio("HydroTest")
            .ASMEPI()
            '================================
            .SubstitBookM("StartPI", CodiceCalc) ' "ASME  VIII div.1 1998 ed. 1998 ad."
            .SubstitBookM("Rapp", Format(RappPI, Form1_2))
            .SubstitBookM("RulePI", RulePI)
            Monitor.Motore.Avanzamento = 15
            '.Visible = True
            If InterrompiMAWP Then GoTo FineNoSuccess
            If Config(0).MetodoPI = 0 Then
                .MuoviCella(5)
                .MuoviLinea(2)
                'GoSub TabellaMAWPB--------------------------------------------
                With Documento 'Selection
                    For Each vMAWP In colMAWP
                        .InserisciRiga(1)
                        .MuoviCaratt(-1)
                        .Testo(Trim(vMAWP.Mark))
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS, 2, 3, False))
                        End If
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS * psi, 4, 1, False))
                        End If
                        .MuoviCella(1)
                        If Not UnLato Then
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS, 2, 3, False))
                            End If
                            .MuoviCella(1)
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS * psi, 4, 1, False))
                            End If
                        End If
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr((vMAWP.Sa), 4, 2, False))
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr((vMAWP.St), 4, 2, False))
                        .MuoviCella(1)
                        If vMAWP.St > 0 Then
                            .Testo(Format(vMAWP.Sa / vMAWP.St, "##.000"))
                        End If
                        .MuoviCella(1)
                        Monitor.Motore.Avanzamento = 15 + 70 * iAvanz / colMAWP.Count()
                        If InterrompiMAWP Then GoTo FineNoSuccess
                        iAvanz = iAvanz + 1
                    Next vMAWP
                    .MuoviLinea(10)
                End With
                'GoSub pHydrb--------------------------------------------------
                With Documento 'Selection
                    .VaiInizio("HydrTestPr")
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                    .MuoviCella(1)
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                    .MuoviCella(1)
                    If UnLato Then
                    Else
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                    End If
                    .MuoviCella(5)
                End With
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then GoTo FineNoSuccess
            Else
                .MuoviCella(3) ' era 3 sono all'inizio dei dati
                .MuoviLinea(1)
                'GoSub TabellaMAWPc-----------------------------------
                With Documento 'Selection
                    For Each vMAWP In colMAWP
                        .InserisciRiga(1)
                        .MuoviCaratt(-1)
                        .Testo(Trim(vMAWP.Mark))
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS, 2, 3, False))
                        End If
                        .MuoviCella(1)
                        .Testo("MPa")
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS * psi, 4, 1, False))
                        End If
                        .MuoviCella(1)
                        .Testo("psi")
                        .MuoviCella(1)
                        If Not UnLato Then
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS, 2, 3, False))
                            End If
                            .MuoviCella(1)
                            .Testo("MPa")
                            .MuoviCella(1)
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS * psi, 4, 1, False))
                            End If
                            .MuoviCella(1)
                            .Testo("psi")
                        End If
                        .MuoviCella(1)
                        Monitor.Motore.Avanzamento = 15 + 70 * iAvanz / colMAWP.Count()
                        If InterrompiMAWP Then GoTo FineNoSuccess
                        iAvanz = iAvanz + 1
                    Next vMAWP
                    .MuoviLinea(2)
                    .MuoviCella(1)
                End With
                'GoSub pHydrPI-----------------------------------------
                With Documento 'Selection
                    .VaiInizio("HydrTestPr")
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                    .MuoviCella(2)
                    If UnLato Then
                        .MuoviCella(1)
                    Else
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                        .MuoviCella(2)
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                        .MuoviCella(3)
                    End If
                End With
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then GoTo FineNoSuccess
            End If
            .MuoviLinea(1)
        End With
        'GoSub Nota1------------------------------------------------------------
        With Documento 'Selection
            iNota = 1
            If Config(0).HTTestVert > 0 Then
                .Testo("1) Position during hydrotest: VERTICAL")
            Else
                .Testo("1) Position during hydrotest: HORIZONTAL")
            End If
            If Config(0).CalcMAWP = 0 And Config(0).MetodoPI = 0 Then
                iNota = iNota + 1
                .MuoviLinea(1)
                .Testo(Str(iNota) & ") The MAWP's are assumed equal to the Design Pressures")
            End If
            If UnLato Then
                If System.Math.Abs(Config(1).pxTest - pHISS) > 1 Then
                    iNota = iNota + 1
                    .MuoviLinea(1)
                    .Testo(Str(iNota) & ") The calculated HT pressure is " & GlobalRoutines.FormatS("##.### MPa (####.# psi)", pHISS / psi, pHISS))
                End If
            Else
                If System.Math.Abs(Config(1).pxTest - pHISS) > 1 Or System.Math.Abs(Config(2).pxTest - pHITS) > 1 Then
                    iNota = iNota + 1
                    .MuoviLinea(1)
                    .Testo(Str(iNota) & ") The calculated HT pressures are " & GlobalRoutines.FormatS("##.### MPa (####.# psi) shell-side ", pHISS / psi, pHISS) & " and " & GlobalRoutines.FormatS("##.### MPa (####.# psi) tube-side ", pHITS / psi, pHITS))
                End If
            End If
        End With
        Monitor.Motore.Avanzamento = 95
        CompilTabGood = True
FineNoSuccess:
        '================================
        CompilTabGood = True
        Monitor.Motore.ProgrAmmazza()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
        Exit Sub
ExAutom:
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        mioApert.Enabled = True
        Warn(Testo)
        Exit Sub
ErrAutom:
        Testo = Err.Description
        Resume ExAutom

    End Sub
    Public Overloads Sub TabPI(ByVal Documento As StubW9.clsSW9)
        Dim i, k As Short
        Dim vMAWP As clsValoriMAWP
        Dim Testo, Nome As String
        Dim iAvanz As Short
        Dim iNota As Short
        CompilTabGood = False
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        If Documento.VaiInizio("StartPI") = 0 Then
            MessageBox.Show("I requisiti di prova idraulica per il documento attivo sono già stati compilati")
            Exit Sub
        End If
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella prova idraulica", "AsmeVip")
        On Error GoTo ErrAutom
        Select Case Config(0).MetodoPI
            Case 0
                If Not CalcolaPIb() Then GoTo FineNoSuccess
                If UnLato Then
                    Documento.sOpen(clsInizio.Archdir & "\TabPIb1.doc", True, 1)
                Else
                    Documento.sOpen(clsInizio.Archdir & "\TabPIb.doc", True, 1)
                End If
            Case 1
                If Not FattoMAWP Then
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    MostraAiuto(IDH_MANCATABMAWP)
                    GoTo FineNoSuccess
                End If
                If Not CalcolaPIc() Then GoTo FineNoSuccess
                If UnLato Then
                    Documento.sOpen(clsInizio.Archdir & "\TabPI1.doc", True, 1)
                Else
                    Documento.sOpen(clsInizio.Archdir & "\TabPI.doc", True, 1)
                End If
        End Select
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        mioApert.Enabled = False
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo FineNoSuccess
        With Documento
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            .VaiInizio("HydroTest")
            .ASMEPI()
            '================================
            .SubstitBookM("StartPI", CodiceCalc) ' "ASME  VIII div.1 1998 ed. 1998 ad."
            .SubstitBookM("Rapp", Format(RappPI, Form1_2))
            .SubstitBookM("RulePI", RulePI)
            Monitor.Motore.Avanzamento = 15
            '.Visible = True
            If InterrompiMAWP Then GoTo FineNoSuccess
            If Config(0).MetodoPI = 0 Then
                .MuoviCella(5)
                .MuoviLinea(2)
                'GoSub TabellaMAWPB--------------------------------------------
                With Documento 'Selection
                    For Each vMAWP In colMAWP
                        .InserisciRiga(1)
                        .MuoviCaratt(-1)
                        .Testo(Trim(vMAWP.Mark))
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS, 2, 3, False))
                        End If
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS * psi, 4, 1, False))
                        End If
                        .MuoviCella(1)
                        If Not UnLato Then
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS, 2, 3, False))
                            End If
                            .MuoviCella(1)
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS * psi, 4, 1, False))
                            End If
                        End If
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr((vMAWP.Sa), 4, 2, False))
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr((vMAWP.St), 4, 2, False))
                        .MuoviCella(1)
                        If vMAWP.St > 0 Then
                            .Testo(Format(vMAWP.Sa / vMAWP.St, "##.000"))
                        End If
                        .MuoviCella(1)
                        Monitor.Motore.Avanzamento = 15 + 70 * iAvanz / colMAWP.Count()
                        If InterrompiMAWP Then GoTo FineNoSuccess
                        iAvanz = iAvanz + 1
                    Next vMAWP
                    .MuoviLinea(10)
                End With
                'GoSub pHydrb--------------------------------------------------
                With Documento 'Selection
                    .VaiInizio("HydrTestPr")
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                    .MuoviCella(1)
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                    .MuoviCella(1)
                    If UnLato Then
                    Else
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                    End If
                    .MuoviCella(5)
                End With
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then GoTo FineNoSuccess
            Else
                .MuoviCella(3) ' era 3 sono all'inizio dei dati
                .MuoviLinea(1)
                'GoSub TabellaMAWPc-----------------------------------
                With Documento 'Selection
                    For Each vMAWP In colMAWP
                        .InserisciRiga(1)
                        .MuoviCaratt(-1)
                        .Testo(Trim(vMAWP.Mark))
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS, 2, 3, False))
                        End If
                        .MuoviCella(1)
                        .Testo("MPa")
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS * psi, 4, 1, False))
                        End If
                        .MuoviCella(1)
                        .Testo("psi")
                        .MuoviCella(1)
                        If Not UnLato Then
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS, 2, 3, False))
                            End If
                            .MuoviCella(1)
                            .Testo("MPa")
                            .MuoviCella(1)
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS * psi, 4, 1, False))
                            End If
                            .MuoviCella(1)
                            .Testo("psi")
                        End If
                        .MuoviCella(1)
                        Monitor.Motore.Avanzamento = 15 + 70 * iAvanz / colMAWP.Count()
                        If InterrompiMAWP Then GoTo FineNoSuccess
                        iAvanz = iAvanz + 1
                    Next vMAWP
                    .MuoviLinea(2)
                    .MuoviCella(1)
                End With
                'GoSub pHydrPI-----------------------------------------
                With Documento 'Selection
                    .VaiInizio("HydrTestPr")
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                    .MuoviCella(2)
                    If UnLato Then
                        .MuoviCella(1)
                    Else
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                        .MuoviCella(2)
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                        .MuoviCella(3)
                    End If
                End With
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then GoTo FineNoSuccess
            End If
            .MuoviLinea(1)
        End With
        'GoSub Nota1------------------------------------------------------------
        With Documento 'Selection
            iNota = 1
            If Config(0).HTTestVert > 0 Then
                .Testo("1) Position during hydrotest: VERTICAL")
            Else
                .Testo("1) Position during hydrotest: HORIZONTAL")
            End If
            If Config(0).CalcMAWP = 0 And Config(0).MetodoPI = 0 Then
                iNota = iNota + 1
                .MuoviLinea(1)
                .Testo(Str(iNota) & ") The MAWP's are assumed equal to the Design Pressures")
            End If
            If UnLato Then
                If System.Math.Abs(Config(1).pxTest - pHISS) > 1 Then
                    iNota = iNota + 1
                    .MuoviLinea(1)
                    .Testo(Str(iNota) & ") The calculated HT pressure is " & GlobalRoutines.FormatS("##.### MPa (####.# psi)", pHISS / psi, pHISS))
                End If
            Else
                If System.Math.Abs(Config(1).pxTest - pHISS) > 1 Or System.Math.Abs(Config(2).pxTest - pHITS) > 1 Then
                    iNota = iNota + 1
                    .MuoviLinea(1)
                    .Testo(Str(iNota) & ") The calculated HT pressures are " & GlobalRoutines.FormatS("##.### MPa (####.# psi) shell-side ", pHISS / psi, pHISS) & " and " & GlobalRoutines.FormatS("##.### MPa (####.# psi) tube-side ", pHITS / psi, pHITS))
                End If
            End If
        End With
        Monitor.Motore.Avanzamento = 95
        CompilTabGood = True
FineNoSuccess:
        '================================
        CompilTabGood = True
        Monitor.Motore.ProgrAmmazza()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
        Exit Sub
ExAutom:
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        mioApert.Enabled = True
        Warn(Testo)
        Exit Sub
ErrAutom:
        Testo = Err.Description
        Resume ExAutom

    End Sub
    Private Overloads Sub PrintTab(ByVal Documento As StubW2000.clsSW2000)
        If UnLato Then St = 2 Else St = 1
        With Documento 'Selection
            For ll = 1 To 8 Step St
                .MuoviCella(1)
                If MAWP(ll) > 0 Then
                    .Testo(GlobalRoutines.myStr(MAWP(ll), 5, 2, True).Trim)
                    .ASMESinistra(Indkmax(ll) = k And Indjmax(ll) = jInvolucr And InvNoz(ll))
                End If
            Next
        End With
    End Sub
    Private Overloads Sub PrintTab(ByVal Documento As StubW9.clsSW9)
        If UnLato Then St = 2 Else St = 1
        With Documento 'Selection
            For ll = 1 To 8 Step St
                .MuoviCella(1)
                If MAWP(ll) > 0 Then
                    .Testo(GlobalRoutines.myStr(MAWP(ll), 5, 2, True).Trim)
                    .ASMESinistra(Indkmax(ll) = k And Indjmax(ll) = jInvolucr And InvNoz(ll))
                End If
            Next
        End With
    End Sub
    Public Overloads Sub TabMAWP(ByVal Documento As StubW2000.clsSW2000)
        CompilTabGood = False
        If UnLato Then
            Nome = "\TabMAWP31.doc"
        Else
            Nome = "\TabMAWP3.doc"
        End If
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        'verifica se è già stata compilata-----------
        If Documento.VaiInizio("EndMAWP") = 0 Then
            Documento.ASMEMAWP()
        End If
        '----------------------------
        On Error GoTo ErrAutom
        Documento.Visible = False
        Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        On Error GoTo 0
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella delle MAWP", "AsmeVip")
        InterrompiMAWP = False
        mioApert.Enabled = False
        Documento.VaiInizio("", 1)
        Documento.Copia(1)
        Documento.sClose(, 1)
        Documento.VaiInizio("HydroTest")
        Monitor.Motore.Avanzamento = 5
        If InterrompiMAWP Then GoTo FineNoSuccess
        Documento.ASMEMAWP1()
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo FineNoSuccess
        i1 = 1
        If Involucr(1, 1).Tipo = 8 Then
            If objMemb(Involucr(1, 1).IndObject).Piastra.IndiceDilat > -1 Then
                i1 = 2
            Else
                i1 = 1
            End If
        End If
        Documento.SubstitBookM("StartMAWP", Trim(Involucr(1, i1).Mark))
        kLato = 1 : jInvolucr = i1
        If Not CalcMax() Then GoTo FineNoSuccess
        Monitor.Motore.Avanzamento = 15
        If InterrompiMAWP Then GoTo FineNoSuccess
        FattoMAWP = True
        With Documento 'Selection
            DatiInvMAWP(Documento)
            For k = 1 To Config(0).NumeroLati
                For i = i1 To Config(k).Ninvolucri
                    nAvanz = nAvanz + 1
                Next
            Next
            For k = 1 To Config(0).NumeroLati
                For i = i1 To Config(k).Ninvolucri
                    iAvanz = iAvanz + 1
                    Monitor.Motore.Avanzamento = 15 + 85 * iAvanz / nAvanz
                    If InterrompiMAWP Then GoTo FineNoSuccess
                    If Involucr(k, i).Tipo = 9 Then GoTo Cont
                    If Involucr(k, i).Tipo = 8 Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb(Involucr(k, i).IndObject).Piastra. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If objMemb(Involucr(k, i).IndObject).Piastra.IndiceDilat > -1 Then
                            GoTo Cont
                        End If
                    End If
                    kLato = k
                    jInvolucr = i
                    If i > 1 Or k > 1 Then
                        .TastoTab() '.MuoviCella 1
                        .Testo(Trim(Involucr(k, i).Mark))
                        DatiInvMAWP(Documento)
                    End If
                    Select Case Involucr(kLato, jInvolucr).Tipo
                        Case 0 To 5
                            DatiNozMAWP(Documento)
                    End Select
Cont:           Next
            Next
            .TastoTab()
            .Testo("Equipment")
            'GoSub PrintTabF---------------------------------------------------
            With Documento
                If UnLato Then St = 2 Else St = 1
                For ll = 1 To 8 Step St
                    .MuoviCella(1)
                    .Testo(GlobalRoutines.myStr(Equipment(ll), 5, 2, True))
                    .ASMESinistra(True)
                Next
            End With
            .BMAdd("EndMAWP")
        End With
        CompilTabGood = True
FineNoSuccess:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
        Exit Sub
ExAutom:
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        mioApert.Enabled = True
        Warn(Testo)
        '  On Error Resume Next
        Documento.Visible = True
        Exit Sub
ErrAutom:
        Testo = Err.Description
        Resume ExAutom

    End Sub
    Public Overloads Sub TabMAWP(ByVal Documento As StubW9.clsSW9)
        CompilTabGood = False
        If UnLato Then
            Nome = "\TabMAWP31.doc"
        Else
            Nome = "\TabMAWP3.doc"
        End If
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        'verifica se è già stata compilata-----------
        If Documento.VaiInizio("EndMAWP") = 0 Then
            Documento.ASMEMAWP()
        End If
        '----------------------------
        On Error GoTo ErrAutom
        Documento.Visible = False
        Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        On Error GoTo 0
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella delle MAWP", "AsmeVip")
        InterrompiMAWP = False
        mioApert.Enabled = False
        Documento.VaiInizio("", 1)
        Documento.Copia(1)
        Documento.sClose(, 1)
        Documento.VaiInizio("HydroTest")
        Monitor.Motore.Avanzamento = 5
        If InterrompiMAWP Then GoTo FineNoSuccess
        Documento.ASMEMAWP1()
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo FineNoSuccess
        i1 = 1
        If Involucr(1, 1).Tipo = 8 Then
            If objMemb(Involucr(1, 1).IndObject).Piastra.IndiceDilat > -1 Then
                i1 = 2
            Else
                i1 = 1
            End If
        End If
        Documento.SubstitBookM("StartMAWP", Trim(Involucr(1, i1).Mark))
        kLato = 1 : jInvolucr = i1
        If Not CalcMax() Then GoTo FineNoSuccess
        Monitor.Motore.Avanzamento = 15
        If InterrompiMAWP Then GoTo FineNoSuccess
        FattoMAWP = True
        With Documento 'Selection
            DatiInvMAWP(Documento)
            For k = 1 To Config(0).NumeroLati
                For i = i1 To Config(k).Ninvolucri
                    nAvanz = nAvanz + 1
                Next
            Next
            For k = 1 To Config(0).NumeroLati
                For i = i1 To Config(k).Ninvolucri
                    iAvanz = iAvanz + 1
                    Monitor.Motore.Avanzamento = 15 + 85 * iAvanz / nAvanz
                    If InterrompiMAWP Then GoTo FineNoSuccess
                    If Involucr(k, i).Tipo = 9 Then GoTo Cont
                    If Involucr(k, i).Tipo = 8 Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb(Involucr(k, i).IndObject).Piastra. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If objMemb(Involucr(k, i).IndObject).Piastra.IndiceDilat > -1 Then
                            GoTo Cont
                        End If
                    End If
                    kLato = k
                    jInvolucr = i
                    If i > 1 Or k > 1 Then
                        .TastoTab() '.MuoviCella 1
                        .Testo(Trim(Involucr(k, i).Mark))
                        DatiInvMAWP(Documento)
                    End If
                    Select Case Involucr(kLato, jInvolucr).Tipo
                        Case 0 To 5
                            DatiNozMAWP(Documento)
                    End Select
Cont:           Next
            Next
            .TastoTab()
            .Testo("Equipment")
            'GoSub PrintTabF---------------------------------------------------
            With Documento
                If UnLato Then St = 2 Else St = 1
                For ll = 1 To 8 Step St
                    .MuoviCella(1)
                    .Testo(GlobalRoutines.myStr(Equipment(ll), 5, 2, True))
                    .ASMESinistra(True)
                Next
            End With
            .BMAdd("EndMAWP")
        End With
        CompilTabGood = True
FineNoSuccess:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
        Exit Sub
ExAutom:
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        mioApert.Enabled = True
        Warn(Testo)
        '  On Error Resume Next
        Documento.Visible = True
        Exit Sub
ErrAutom:
        Testo = Err.Description
        Resume ExAutom

    End Sub
    Private Overloads Sub DatiInv(ByVal Documento As StubW2000.clsSW2000)
        With Documento
            .MuoviCella(1)
            .Testo(Trim(Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).MatStr))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St, 5, 2, False))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0, 5, 2, False))
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Zitto = True
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).YieldTemp(CodiceStress, TempDes, Sya, Syo)
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Zitto = False
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
            If Nuovo Then
                vMAWP = New clsValoriMAWP
            Else
                vMAWP = CercavMAWP(kLato, jInvolucr, True)
                If vMAWP Is Nothing Then
                    Nuovo = True
                    vMAWP = New clsValoriMAWP
                End If
            End If
            With vMAWP
                .St = Involucr(kLato, jInvolucr).St
                .Sa = Involucr(kLato, jInvolucr).S0
                .Inv = True
                .k = kLato
                .i = jInvolucr
                .Mark = Trim(Involucr(.k, .i).Mark)
            End With
            If Nuovo Then colMAWP.Add(vMAWP)
        End With
    End Sub
    Private Overloads Sub DatiInv(ByVal Documento As StubW9.clsSW9)
        With Documento
            .MuoviCella(1)
            .Testo(Trim(Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).MatStr))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St, 5, 2, False))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0, 5, 2, False))
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Zitto = True
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).YieldTemp(CodiceStress, TempDes, Sya, Syo)
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Zitto = False
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
            If Nuovo Then
                vMAWP = New clsValoriMAWP
            Else
                vMAWP = CercavMAWP(kLato, jInvolucr, True)
                If vMAWP Is Nothing Then
                    Nuovo = True
                    vMAWP = New clsValoriMAWP
                End If
            End If
            With vMAWP
                .St = Involucr(kLato, jInvolucr).St
                .Sa = Involucr(kLato, jInvolucr).S0
                .Inv = True
                .k = kLato
                .i = jInvolucr
                .Mark = Trim(Involucr(.k, .i).Mark)
            End With
            If Nuovo Then colMAWP.Add(vMAWP)
        End With
    End Sub
    Private Sub Bolt1()
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            With Documento9
                .TastoTab() '.MuoviCella 1
                .Testo(Trim(Involucr(kLato, jInvolucr).Mark) & " (Bolts)")
                .MuoviCella(1)
                .Testo(Trim(Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).MatStr))
                .MuoviCella(1)
                .Testo(GlobalRoutines.myStr((TempDes() - 32) / 1.8, 4, 0, True))
                .MuoviCella(1)
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Zitto = True
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).SigmaAmm(CodiceStress(FlanBulDiv1), TempDes, Sya, Syo)
                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                .MuoviCella(1)
                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                .MuoviCella(1)
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).YieldTemp(CodiceStress(FlanBulDiv1), TempDes, Sya1, Syo1)
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Zitto = False
                .Testo(GlobalRoutines.myStr(Syo1, 6, 2, False))
            End With
        Else
            With Documento
                .TastoTab() '.MuoviCella 1
                .Testo(Trim(Involucr(kLato, jInvolucr).Mark) & " (Bolts)")
                .MuoviCella(1)
                .Testo(Trim(Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).MatStr))
                .MuoviCella(1)
                .Testo(GlobalRoutines.myStr((TempDes() - 32) / 1.8, 4, 0, True))
                .MuoviCella(1)
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Zitto = True
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).SigmaAmm(CodiceStress(FlanBulDiv1), TempDes, Sya, Syo)
                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                .MuoviCella(1)
                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                .MuoviCella(1)
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).YieldTemp(CodiceStress(FlanBulDiv1), TempDes, Sya1, Syo1)
                Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Zitto = False
                .Testo(GlobalRoutines.myStr(Syo1, 6, 2, False))
            End With
        End If
        If Nuovo Then
            vMAWP = New clsValoriMAWP
        Else
            vMAWP = CercavMAWP(kLato, jInvolucr, True)
            If vMAWP Is Nothing Then
                Nuovo = True
                vMAWP = New clsValoriMAWP
            End If
        End If
        With vMAWP
            .St = Syo
            .Sa = Sya
            .Inv = True
            .k = kLato
            .i = jInvolucr
            .Bolt = True
            .Mark = Trim(Involucr(.k, .i).Mark) & " (Bolts)"
        End With
        If Nuovo Then colMAWP.Add(vMAWP)
    End Sub
    Public Sub VisualCap()
        Dim cap1 As String
        Dim i As Short
        Dim cap2 As String = ""
        Dim l As ListViewItem
        If mioApert.lstRapp.SelectedItems.Count = 0 Then
            GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
            MostraAiuto(2150)
        Else
            Try
                l = mioApert.lstRapp.SelectedItems(0)
                If l Is Nothing Then Exit Sub
                cap1 = TogliBlank((l.SubItems(0).Text))
                If Monitor.Motore.Inizio.VersOffice < 11 Then
                    With Documento9
                        .VaiInizio(cap1)
                        i = l.Index
                        If i < mioApert.lstRapp.Items.Count - 1 Then
                            cap2 = TogliBlank((mioApert.lstRapp.Items(i + 1).SubItems(0).Text))
                            .VaiInizio(cap2, 1)
                        Else
                            .VaiInizio("\EndOfDoc", 1)
                        End If
                        .ASMECap(clsInizio.Archdir, clsInizio.DiscoTem, cap1, cap2)
                        If Not OptWordIn Then .Massimizza()
                    End With
                Else
                    With Documento
                        .VaiInizio(cap1)
                        i = l.Index
                        If i < mioApert.lstRapp.Items.Count - 1 Then
                            cap2 = TogliBlank((mioApert.lstRapp.Items(i + 1).SubItems(0).Text))
                            .VaiInizio(cap2, 1)
                        Else
                            .VaiInizio("\EndOfDoc", 1)
                        End If
                        .ASMECap(clsInizio.Archdir, clsInizio.DiscoTem, cap1, cap2)
                        If Not OptWordIn Then .Massimizza()
                    End With
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End If
    End Sub
    Public Overloads Sub TabMat(ByVal Documento As StubW2000.clsSW2000)
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        If colMAWP Is Nothing Then Nuovo = True : colMAWP = New Collection Else Nuovo = False
        Try
            CompilTabGood = False
            If Documento.VaiInizio("StartMat") = 0 Then
                Testo = "La tabella materiali per il documento attivo" & vbCrLf
                Testo = Testo & "è già stata, almeno parzialmente, compilata." & vbCrLf
                Testo = Testo & "Volete ricompilarla comunque?" & vbCrLf
                Testo = Testo & "(N.B.: La nuova redazione si aggiungerà alla vecchia" & vbCrLf
                Testo = Testo & "redazione, senza sostituzione delle parti obsolete)."
                If MessageBox.Show(mioApert, Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella materiali", "AsmeVip")
            InterrompiMAWP = False
            mioApert.Enabled = False
            Documento.sOpen(clsInizio.Archdir & "\TabMat.doc", True, 1)
            Documento.VaiInizio("", 1)
            Documento.Copia(1)
            Documento.sClose(, 1)
            Monitor.Motore.Avanzamento = 10
            If InterrompiMAWP Then GoTo Fine
            Documento.VaiInizio("Materials")
            Documento.ASMEPI()
            Documento.SubstitBookM("StartMat", Trim(Involucr(1, 1).Mark))
            kLato = 1 : jInvolucr = 1
            For k = 1 To Config(0).NumeroLati
                For i = 1 To Config(k).Ninvolucri
                    nAvanz = nAvanz + 1
                Next
            Next
            With Documento
                DatiInv(Documento)
                For k = 1 To Config(0).NumeroLati
                    For i = 1 To Config(k).Ninvolucri
                        iAvanz = iAvanz + 1
                        Monitor.Motore.Avanzamento = 10 + 90 * iAvanz / nAvanz
                        If InterrompiMAWP Then GoTo Fine
                        kLato = k
                        jInvolucr = i
                        If i > 1 Or k > 1 Then
                            .TastoTab() '.MuoviCella 1
                            .Testo(Trim(Involucr(k, i).Mark))
                            DatiInv(Documento)
                        End If
                        Select Case Involucr(kLato, jInvolucr).Tipo
                            Case 0 To 4
                                DatiNoz(Documento)
                                If Sya = 0 Then GoTo Fine
                            Case 5 'fucinati
                                DatiNoz(Documento)
                                If Sya = 0 Then GoTo Fine
                                Dim O_flan As wn_flan
                                O_flan = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                If Not (O_flan.Mem.LOOSE = 5 Or O_flan.Mem.LOOSE = 6) Then
                                    Bolt1()
                                End If
                            Case 6 'PT
                                O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                If Involucr(kLato, jInvolucr).indice(2 - 1) > 0 Then
                                    If Not Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)) Is Nothing Then
                                        Bolt1()
                                    End If
                                End If
                        End Select
                    Next
                Next
                Documento.BMAdd("EndMat")
            End With
            CompilTabGood = True
        Catch e As Exception
            Warn(e.Message)
        End Try
Fine:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
    End Sub
    Public Overloads Sub TabMat(ByVal Documento As StubW9.clsSW9)
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        If colMAWP Is Nothing Then Nuovo = True : colMAWP = New Collection Else Nuovo = False
        Try
            CompilTabGood = False
            If Documento.VaiInizio("StartMat") = 0 Then
                Testo = "La tabella materiali per il documento attivo" & vbCrLf
                Testo = Testo & "è già stata, almeno parzialmente, compilata." & vbCrLf
                Testo = Testo & "Volete ricompilarla comunque?" & vbCrLf
                Testo = Testo & "(N.B.: La nuova redazione si aggiungerà alla vecchia" & vbCrLf
                Testo = Testo & "redazione, senza sostituzione delle parti obsolete)."
                If MessageBox.Show(mioApert, Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella materiali", "AsmeVip")
            InterrompiMAWP = False
            mioApert.Enabled = False
            Documento.sOpen(clsInizio.Archdir & "\TabMat.doc", True, 1)
            Documento.VaiInizio("", 1)
            Documento.Copia(1)
            Documento.sClose(, 1)
            Monitor.Motore.Avanzamento = 10
            If InterrompiMAWP Then GoTo Fine
            Documento.VaiInizio("Materials")
            Documento.ASMEPI()
            Documento.SubstitBookM("StartMat", Trim(Involucr(1, 1).Mark))
            kLato = 1 : jInvolucr = 1
            For k = 1 To Config(0).NumeroLati
                For i = 1 To Config(k).Ninvolucri
                    nAvanz = nAvanz + 1
                Next
            Next
            With Documento
                DatiInv(Documento)
                For k = 1 To Config(0).NumeroLati
                    For i = 1 To Config(k).Ninvolucri
                        iAvanz = iAvanz + 1
                        Monitor.Motore.Avanzamento = 10 + 90 * iAvanz / nAvanz
                        If InterrompiMAWP Then GoTo Fine
                        kLato = k
                        jInvolucr = i
                        If i > 1 Or k > 1 Then
                            .TastoTab() '.MuoviCella 1
                            .Testo(Trim(Involucr(k, i).Mark))
                            DatiInv(Documento)
                        End If
                        Select Case Involucr(kLato, jInvolucr).Tipo
                            Case 0 To 4
                                DatiNoz(Documento)
                                If Sya = 0 Then GoTo Fine
                            Case 5 'fucinati
                                DatiNoz(Documento)
                                If Sya = 0 Then GoTo Fine
                                Dim O_flan As wn_flan
                                O_flan = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                If Not (O_flan.Mem.LOOSE = 5 Or O_flan.Mem.LOOSE = 6) Then
                                    Bolt1()
                                End If
                            Case 6 'PT
                                O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                If Involucr(kLato, jInvolucr).indice(2 - 1) > 0 Then
                                    If Not Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)) Is Nothing Then
                                        Bolt1()
                                    End If
                                End If
                        End Select
                    Next
                Next
                Documento.BMAdd("EndMat")
            End With
            CompilTabGood = True
        Catch e As Exception
            Warn(e.Message)
        End Try
Fine:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
    End Sub
    Sub CloseioutS(ByRef lstRapp As ListView, Optional ByRef anche As Boolean = False)
        Try
            Monitor.Motore.Problem.ChiudiRapp()
            If Not lstRapp Is Nothing Then lstRapp.Items.Clear()
            If Not mioApert Is Nothing Then
                If Not div = 2 Then mioApert.Check1.Enabled = True
                mioApert.Text1.Enabled = True
            End If
            If Monitor.Motore.Inizio.VersOffice < 11 Then
                If Not Documento9 Is Nothing Then
                    If OptWordIn Then
                        mioApert.objWinWordcontrol.CloseControl()
                    Else
                        Documento9.sClose(1) 'wdSaveChanges
                        If mioApert.Check1.CheckState = 1 Then
                            Documento9.sCloseAll(2)
                        End If
                        If anche Then Documento9.sQuit()
                    End If
                    Documento9 = Nothing
                End If
            Else
                If Not Documento Is Nothing Then
                    If OptWordIn Then
                        mioApert.objWinWordcontrol.CloseControl()
                    Else
                        Documento.sClose(1) 'wdSaveChanges
                        If mioApert.Check1.CheckState = 1 Then
                            Documento.sCloseAll(2)
                        End If
                        If anche Then Documento.sQuit()
                    End If
                    Documento = Nothing
                End If
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Overloads Function Visualizza(ByVal Dcumento As StubW2000.clsSW2000) As Boolean
        Dim Testo, LogoFile As String
        Dim BookM, Comm, Figur As String
        Dim i As Short
        Dim FigurName, indirFile As String
        Visualizza = True
        If clsInizio.LavoriSciolti Then
            Comm = clsInizio.CommPulita(icome)
        Else
            Comm = ASMEjob.Comm.Arch
        End If
        If Not IO.File.Exists(FileSt) Then
            Testo = " Bisogna prima (ri)eseguire il calcolo |"
            MessageBox.Show(inizio.ConvertiCr(Testo), "Compilazione tabelle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Visualizza = False
            Exit Function
        End If
        Monitor.Motore.Problem.FineRapp()
        capitoli = New Collection
        InterrompiMAWP = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto", "AsmeVip")
        Documento = New StubW2000.clsSW2000
        mioApert.objWinWordcontrol.Enabled = OptWordIn
        If Documento.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice, True, mioApert.objWinWordcontrol) > 0 Then
            Monitor.Motore.ProgrAmmazza()
            Return False
        End If
        If Not mioApert Is Nothing Then mioApert.Enabled = False
        Try
            Monitor.Motore.Avanzamento = 25
            If InterrompiMAWP Then GoTo ExitSub
            If Not mioApert Is Nothing Then
                If mioApert.Check1.CheckState = 1 Then
                    LogoFile = clsInizio.Archdir & gstrSEP_DIR & clsInizio.ReadIniFile("", "Azienda", "Logo")
                    indirFile = clsInizio.Archdir & gstrSEP_DIR & clsInizio.ReadIniFile("", "Azienda", "Indirizzo")
                    If Len(indirFile) > 0 Then
                        If Not IO.File.Exists(indirFile) Then indirFile = ""
                    End If
                    If Len(LogoFile) > 0 Then
                        If IO.File.Exists(LogoFile) Then
                            If Not Documento.Shapes7(LogoFile, indirFile) Then GoTo ExitSub
                        End If
                    End If
                    With Documento
                        If .SubstitBookM("OrdineCliente", "?") > 0 Then 'Config(0).Item
                            GoTo ExitSub
                        End If
                        .SubstitBookM("NomeDitta", clsInizio.Firma)
                        .SubstitBookM("Cliente", "??")
                        .SubstitBookM("Progetto", "???")
                        .SubstitBookM("Codice", "CCC")
                        .SubstitBookM("Impianto", "Imp")
                        .SubstitBookM("Apparecchio", "App")
                        .SubstitBookM("Item", Config(0).Item)
                        .SubstitBookM("Titolo", "Code Calculations")
                        .SubstitBookM("NoForn", Comm)
                        .SubstitBookM("NoClie", "567")
                        .SubstitBookM("Scopo", "For approval")
                        clsInizio.Immatricolazione(Documento, Comm, "SC001")
                        If OptUG22 Then
                            '                    .VaiInizio("OtherLoadings", Del:=True)
                            .SubstitBookM("OtherLoadings", "", True)
                            .sOpen(clsInizio.Archdir & "\OtherLoadings", True, 1)
                            .VaiInizio("", 1)
                            .Copia(1)
                            .sClose(, 1)
                            .sPaste()
                        End If
                    End With
                End If
            End If
            Monitor.Motore.Avanzamento = 50
            If InterrompiMAWP Then GoTo ExitSub
            If Not mioApert Is Nothing Then mioApert.Enabled = True
            With Documento
                If div < 2 Then
                    For i = 1 To .sBookMarksCount
                        BookM = .sBookMarksName(i)
                        If Left(BookM, 4) = "Bkmk" Then
                            '             Documento.sShowAll True
                            .VediTestoNascosto()
                            .VaiInizio(BookM, , True)  ' False
                            Figur = .GetTesto
                            .NascondiTestoNascosto()
                            FigurName = Monitor.Motore.Inizio.DiscoTem & Figur
                            frmNoz.DefInstance.TagImages(Figur).Save(FigurName)
                            .ssAddPicture(FigurName)
                            Kill(FigurName)
                        ElseIf Left(BookM, 4) = "bkml" Then
                            .VediTestoNascosto()
                            .VaiInizio(BookM, , False)
                            Figur = .GetTesto
                            .NascondiTestoNascosto()
                            FigurName = Monitor.Motore.Inizio.DiscoTem & Figur
                            frmStiff.DefInstance.TagImages(Figur).Save(FigurName)
                            .ssAddPicture(FigurName)
                            Kill(FigurName)
                        End If
                        Monitor.Motore.Avanzamento = 50 + i * 50 / .sBookMarksCount
                        If InterrompiMAWP Then GoTo ExitSub
                    Next
                End If
                If Config(0).VerifPI = 1 Then
                    If .VaiInizio("VerifichePI") = 0 Then
                        .ApplicaStile("Titolo 1")
                    End If
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            Monitor.Motore.ProgrAmmazza() '  Screen.MousePointer = vbDefault
            CloseioutS(mioApert.lstRapp, True)
            If Not mioApert Is Nothing Then mioApert.Enabled = True
            Exit Function
        End Try
ExitSub:
        Monitor.Motore.ProgrAmmazza() 'Screen.MousePointer = vbDefault
        Documento.sShowAll(False)
    End Function
    Public Overloads Function Visualizza(ByVal Documento As StubW9.clsSW9) As Boolean
        Dim Testo, LogoFile As String
        Dim BookM, Comm, Figur As String
        Dim i As Short
        Dim FigurName, indirFile As String
        Visualizza = True
        If clsInizio.LavoriSciolti Then
            Comm = clsInizio.CommPulita(icome)
        Else
            Comm = ASMEjob.Comm.Arch
        End If
        If Not IO.File.Exists(FileSt) Then
            Testo = " Bisogna prima (ri)eseguire il calcolo |"
            MessageBox.Show(inizio.ConvertiCr(Testo), "Compilazione tabelle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Visualizza = False
            Exit Function
        End If
        Monitor.Motore.Problem.FineRapp()
        capitoli = New Collection
        InterrompiMAWP = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto", "AsmeVip")
        Documento = Nothing
        Documento = New StubW9.clsSW9
        If Documento.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice, True) > 0 Then
            Monitor.Motore.ProgrAmmazza()
            Return False
        End If
        If Not mioApert Is Nothing Then mioApert.Enabled = False
        Try
            Monitor.Motore.Avanzamento = 25
            If InterrompiMAWP Then GoTo ExitSub
            If Not mioApert Is Nothing Then
                If mioApert.Check1.CheckState = 1 Then
                    LogoFile = clsInizio.Archdir & gstrSEP_DIR & clsInizio.ReadIniFile("", "Azienda", "Logo")
                    indirFile = clsInizio.Archdir & gstrSEP_DIR & clsInizio.ReadIniFile("", "Azienda", "Indirizzo")
                    If Len(indirFile) > 0 Then
                        If Not IO.File.Exists(indirFile) Then indirFile = ""
                    End If
                    If Len(LogoFile) > 0 Then
                        If IO.File.Exists(LogoFile) Then
                            If Not Documento.Shapes7(LogoFile, indirFile) Then GoTo ExitSub
                        End If
                    End If
                    With Documento
                        If .SubstitBookM("OrdineCliente", "?") > 0 Then 'Config(0).Item
                            GoTo ExitSub
                        End If
                        .SubstitBookM("NomeDitta", clsInizio.Firma)
                        .SubstitBookM("Cliente", "??")
                        .SubstitBookM("Progetto", "???")
                        .SubstitBookM("Codice", "CCC")
                        .SubstitBookM("Impianto", "Imp")
                        .SubstitBookM("Apparecchio", "App")
                        .SubstitBookM("Item", Config(0).Item)
                        .SubstitBookM("Titolo", "Code Calculations")
                        .SubstitBookM("NoForn", Comm)
                        .SubstitBookM("NoClie", "567")
                        .SubstitBookM("Scopo", "For approval")
                        clsInizio.Immatricolazione(Documento, Comm, "SC001")
                        If OptUG22 Then
                            '                    .VaiInizio("OtherLoadings", Del:=True)
                            .SubstitBookM("OtherLoadings", "", True)
                            .sOpen(clsInizio.Archdir & "\OtherLoadings", True, 1)
                            .VaiInizio("", 1)
                            .Copia(1)
                            .sClose(, 1)
                            .sPaste()
                        End If
                    End With
                End If
            End If
            Monitor.Motore.Avanzamento = 50
            If InterrompiMAWP Then GoTo ExitSub
            If Not mioApert Is Nothing Then mioApert.Enabled = True
            With Documento
                If div < 2 Then
                    For i = 1 To .sBookMarksCount
                        BookM = .sBookMarksName(i)
                        If Left(BookM, 4) = "Bkmk" Then
                            '             Documento.sShowAll True
                            .VediTestoNascosto()
                            .VaiInizio(BookM, , True)  ' False
                            Figur = .GetTesto
                            .NascondiTestoNascosto()
                            FigurName = Monitor.Motore.Inizio.DiscoTem & Figur
                            frmNoz.DefInstance.TagImages(Figur).Save(FigurName)
                            .ssAddPicture(FigurName)
                            Kill(FigurName)
                        ElseIf Left(BookM, 4) = "bkml" Then
                            .VediTestoNascosto()
                            .VaiInizio(BookM, , False)
                            Figur = .GetTesto
                            .NascondiTestoNascosto()
                            FigurName = Monitor.Motore.Inizio.DiscoTem & Figur
                            frmStiff.DefInstance.TagImages(Figur).Save(FigurName)
                            .ssAddPicture(FigurName)
                            Kill(FigurName)
                        End If
                        Monitor.Motore.Avanzamento = 50 + i * 50 / .sBookMarksCount
                        If InterrompiMAWP Then GoTo ExitSub
                    Next
                End If
                If Config(0).VerifPI = 1 Then
                    If .VaiInizio("VerifichePI") = 0 Then
                        .ApplicaStile("Titolo 1")
                    End If
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            Monitor.Motore.ProgrAmmazza() '  Screen.MousePointer = vbDefault
            CloseioutS(mioApert.lstRapp, True)
            If Not mioApert Is Nothing Then mioApert.Enabled = True
            Exit Function
        End Try
ExitSub:
        Monitor.Motore.ProgrAmmazza() 'Screen.MousePointer = vbDefault
        Documento.sShowAll(False)
    End Function
    Public Overloads Sub EUCylShellPr(ByVal Documento As StubW2000.clsSW2000)
        Dim Elemento As String
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
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
                EUadopted(Documento)
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
    Public Overloads Sub EUCylShellPr(ByVal Documento As StubW9.clsSW9)
        Dim Elemento As String
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
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
                EUadopted(Documento)
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
    Public Overloads Sub EUConShellPr(ByRef ang As Single, ByRef Aspp As Single, ByVal Documento As StubW2000.clsSW2000)
        Dim Testo, Testo1 As String
        Dim R As Single
        Dim Elemento As String
        Dim RP, esuDe, Rpp As Single
        Dim i1, i, i2 As Short
        Dim tc2, sp1, sp2, ts2 As Single
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        Elemento = Trim(Involucr(kLato, jInvolucr).Mark)
        On Error GoTo ErrEU
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto sul guscio conico " & Trim(Involucr(kLato, jInvolucr).Mark), "AsmeVip")
        InterrompiMAWP = False
        mioApert.Enabled = False
        With Documento
            .sOpen(clsInizio.Archdir & "\EUconint.doc", True, 1)
            .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
            .VaiInizio("", 1)
            '--------------------------------------------------------------
            .SubstitBookM("STStr", STStr, True, 1)
            EUCylConIntest()
            '------------------------------------------------------------------------
            .SubstitBookM("InsDiamg", Format(Involucr(kLato, jInvolucr).di, Fors), True, 1)
            If Involucr(kLato, jInvolucr).H0 > 0 Then
                Testo = Format(Involucr(kLato, jInvolucr).H0, Fors)
            Else
                Testo = "N.A."
            End If
            .SubstitBookM("KnuRadg", Testo, True, 1)
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
                .SubstitBookM("esse", Format(sEuro, Fors), True, 1)
                If sEuro < 1 Then Testo = "(7.6-23)" Else Testo = "(7.6-24)"
                .SubstitBookM("t", Format(tEuro, Fors), True, 1)
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
    Public Overloads Sub EUConShellPr(ByRef ang As Single, ByRef Aspp As Single, ByVal Documento As StubW9.clsSW9)
        Dim Testo, Testo1 As String
        Dim R As Single
        Dim Elemento As String
        Dim RP, esuDe, Rpp As Single
        Dim i1, i, i2 As Short
        Dim tc2, sp1, sp2, ts2 As Single
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        Elemento = Trim(Involucr(kLato, jInvolucr).Mark)
        On Error GoTo ErrEU
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto sul guscio conico " & Trim(Involucr(kLato, jInvolucr).Mark), "AsmeVip")
        InterrompiMAWP = False
        mioApert.Enabled = False
        With Documento
            .sOpen(clsInizio.Archdir & "\EUconint.doc", True, 1)
            .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
            .VaiInizio("", 1)
            '--------------------------------------------------------------
            .SubstitBookM("STStr", STStr, True, 1)
            EUCylConIntest()
            '------------------------------------------------------------------------
            .SubstitBookM("InsDiamg", Format(Involucr(kLato, jInvolucr).di, Fors), True, 1)
            If Involucr(kLato, jInvolucr).H0 > 0 Then
                Testo = Format(Involucr(kLato, jInvolucr).H0, Fors)
            Else
                Testo = "N.A."
            End If
            .SubstitBookM("KnuRadg", Testo, True, 1)
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
                .SubstitBookM("esse", Format(sEuro, Fors), True, 1)
                If sEuro < 1 Then Testo = "(7.6-23)" Else Testo = "(7.6-24)"
                .SubstitBookM("t", Format(tEuro, Fors), True, 1)
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
    Public Overloads Sub TabDesign(ByVal Documento As StubW2000.clsSW2000)
        Dim Testo, Nome As String
        CompilTabGood = False
        If UnLato Then
            Nome = "\TabDesign1.doc"
        Else
            Nome = "\TabDesign.doc"
        End If
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        If Documento.VaiInizio("StartDesign") = 0 Then
            MessageBox.Show("La tabella dei dati di progetto per il documento attivo è già stata compilata")
            Exit Sub
        End If
        Try
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella dati di progetto", "AsmeVip")
            InterrompiMAWP = False
            Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        Catch e As Exception
            Testo = e.Message
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            mioApert.Enabled = True
            Warn(Testo)
            Exit Sub
        End Try
        mioApert.Enabled = False
        Documento.VaiInizio("", 1)
        Documento.Copia(1)
        Documento.sClose(, 1)
        If Not CalcMax() Then GoTo Fine
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo Fine
        Documento.VaiInizio("DesignData")
        Documento.sPaste()
        Documento.VaiInizio("StartDesign")
        Documento.SubstitBookM("StartDesign", CodiceCalc) '"ASME  VIII div.1 1998 ed. 1998 ad."
        Monitor.Motore.Avanzamento = 20
        If InterrompiMAWP Then GoTo Fine
        With Documento
            .MuoviCella(1)
            If Not UnLato Then .Testo(CodiceCalc) '"ASME  VIII div.1 1998 ed. 1998 ad."
            .MuoviCella(1)
            If UnLato Then
                .Testo("TEMA")
            Else
                .Testo("TEMA 'RCB'")
            End If
            Monitor.Motore.Avanzamento = 30
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(1)
            If UnLato Then
                .Testo("N.A.")
            Else
                .Testo("EDITION 1998 + 1994 errata")
            End If
            Monitor.Motore.Avanzamento = 40
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(2)
            If UnLato Then
                .Testo("N.A.")
            Else
                .Testo("???")
            End If
            Monitor.Motore.Avanzamento = 50
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(2)
            .Testo("Size ?")
            .MuoviCella(5)
            'GoSub DesignP ------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).p0x, 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).p0x * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).p0x, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).p0x * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 60
            If InterrompiMAWP Then GoTo Fine
            'GoSub pHydrDes----------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub DesignT----------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).tdx, 4, 1, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).tdx * 1.8 + 32, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdx, 4, 1, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdx * 1.8 + 32, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 70
            If InterrompiMAWP Then GoTo Fine
            'GoSub Corr--------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).Corr, 4, 1, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).Corr / inc, 2, 3, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).Corr, 4, 1, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).Corr / inc, 2, 3, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub MWDT----------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).tdxMDMT(0), 4, 2, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 80
            If InterrompiMAWP Then GoTo Fine
            'GoSub MAWP--------------------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Equipment(7), 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Equipment(7) * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Equipment(8), 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Equipment(8) * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub Dp---------------------------------------------------
            With Documento
                .Testo("--")
                .MuoviCella(2)
                .Testo("--")
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo("--")
                    .MuoviCella(2)
                    .Testo("--")
                    .MuoviCella(3)
                End If
            End With
            If UnLato Then
                .MuoviCella(6)
            Else
                .MuoviCella(9)
            End If
            Monitor.Motore.Avanzamento = 90
            If InterrompiMAWP Then GoTo Fine
            'GoSub Vacuum-----------------------------------------------------
            With Documento
                .Testo("YES")
                .MuoviCella(1)
                If UnLato Then
                    .Testo("")
                Else
                    .Testo("YES")
                End If
                .MuoviCella(2)
            End With
            'GoSub eff----------------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).Efficienza, 2, 2, False))
                .MuoviCella(1)
                If Not UnLato Then .Testo(GlobalRoutines.myStr(Config(2).Efficienza, 2, 2, False))
                .MuoviCella(2)
            End With
            'GoSub Stamp-----------------------------------------------------
            With Documento
                .Testo("YES")
                If UnLato Then
                    .MuoviLinea(13)
                Else
                    .MuoviLinea(12)
                End If
            End With
            Documento.BMAdd("EndDesign")
            Monitor.Motore.Avanzamento = 100
        End With
        CompilTabGood = True
Fine:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()

    End Sub
    Public Overloads Sub TabDesign(ByVal Documento As StubW9.clsSW9)
        Dim Testo, Nome As String
        CompilTabGood = False
        If UnLato Then
            Nome = "\TabDesign1.doc"
        Else
            Nome = "\TabDesign.doc"
        End If
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
        If Documento.VaiInizio("StartDesign") = 0 Then
            MessageBox.Show("La tabella dei dati di progetto per il documento attivo è già stata compilata")
            Exit Sub
        End If
        Try
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella dati di progetto", "AsmeVip")
            InterrompiMAWP = False
            Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        Catch e As Exception
            Testo = e.Message
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            mioApert.Enabled = True
            Warn(Testo)
            Exit Sub
        End Try
        mioApert.Enabled = False
        Documento.VaiInizio("", 1)
        Documento.Copia(1)
        Documento.sClose(, 1)
        If Not CalcMax() Then GoTo Fine
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo Fine
        Documento.VaiInizio("DesignData")
        Documento.sPaste()
        Documento.VaiInizio("StartDesign")
        Documento.SubstitBookM("StartDesign", CodiceCalc) '"ASME  VIII div.1 1998 ed. 1998 ad."
        Monitor.Motore.Avanzamento = 20
        If InterrompiMAWP Then GoTo Fine
        With Documento
            .MuoviCella(1)
            If Not UnLato Then .Testo(CodiceCalc) '"ASME  VIII div.1 1998 ed. 1998 ad."
            .MuoviCella(1)
            If UnLato Then
                .Testo("TEMA")
            Else
                .Testo("TEMA 'RCB'")
            End If
            Monitor.Motore.Avanzamento = 30
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(1)
            If UnLato Then
                .Testo("N.A.")
            Else
                .Testo("EDITION 1998 + 1994 errata")
            End If
            Monitor.Motore.Avanzamento = 40
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(2)
            If UnLato Then
                .Testo("N.A.")
            Else
                .Testo("???")
            End If
            Monitor.Motore.Avanzamento = 50
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(2)
            .Testo("Size ?")
            .MuoviCella(5)
            'GoSub DesignP ------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).p0x, 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).p0x * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).p0x, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).p0x * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 60
            If InterrompiMAWP Then GoTo Fine
            'GoSub pHydrDes----------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub DesignT----------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).tdx, 4, 1, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).tdx * 1.8 + 32, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdx, 4, 1, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdx * 1.8 + 32, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 70
            If InterrompiMAWP Then GoTo Fine
            'GoSub Corr--------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).Corr, 4, 1, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).Corr / inc, 2, 3, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).Corr, 4, 1, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).Corr / inc, 2, 3, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub MWDT----------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).tdxMDMT(0), 4, 2, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 80
            If InterrompiMAWP Then GoTo Fine
            'GoSub MAWP--------------------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Equipment(7), 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Equipment(7) * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Equipment(8), 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Equipment(8) * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub Dp---------------------------------------------------
            With Documento
                .Testo("--")
                .MuoviCella(2)
                .Testo("--")
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo("--")
                    .MuoviCella(2)
                    .Testo("--")
                    .MuoviCella(3)
                End If
            End With
            If UnLato Then
                .MuoviCella(6)
            Else
                .MuoviCella(9)
            End If
            Monitor.Motore.Avanzamento = 90
            If InterrompiMAWP Then GoTo Fine
            'GoSub Vacuum-----------------------------------------------------
            With Documento
                .Testo("YES")
                .MuoviCella(1)
                If UnLato Then
                    .Testo("")
                Else
                    .Testo("YES")
                End If
                .MuoviCella(2)
            End With
            'GoSub eff----------------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).Efficienza, 2, 2, False))
                .MuoviCella(1)
                If Not UnLato Then .Testo(GlobalRoutines.myStr(Config(2).Efficienza, 2, 2, False))
                .MuoviCella(2)
            End With
            'GoSub Stamp-----------------------------------------------------
            With Documento
                .Testo("YES")
                If UnLato Then
                    .MuoviLinea(13)
                Else
                    .MuoviLinea(12)
                End If
            End With
            Documento.BMAdd("EndDesign")
            Monitor.Motore.Avanzamento = 100
        End With
        CompilTabGood = True
Fine:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        mioApert.Enabled = True
        If Not OptWordIn Then Documento.Massimizza()

    End Sub
    Public Overloads Sub EUHeadsPr(ByRef Aspp As Single, ByVal Documento As StubW2000.clsSW2000)
        Dim corroded, equiv As String
        Dim Elemento As String
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
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
                    EUadopted(Documento)
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
                    .SubstitBookM("es", Format(esEuro, Fors), True, 1)
                    .SubstitBookM("ey", Format(eyEuro, Fors), True, 1)
                    .SubstitBookM("eb", Format(EbEuro, Fors), True, 1)
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
    Public Overloads Sub EUHeadsPr(ByRef Aspp As Single, ByVal Documento As StubW9.clsSW9)
        Dim corroded, equiv As String
        Dim Elemento As String
        If Documento Is Nothing Then If Not Visualizza(Documento) Then Exit Sub
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
                    EUadopted(Documento)
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
                    .SubstitBookM("es", Format(esEuro, Fors), True, 1)
                    .SubstitBookM("ey", Format(eyEuro, Fors), True, 1)
                    .SubstitBookM("eb", Format(EbEuro, Fors), True, 1)
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
    Private Overloads Sub EUadopted(ByVal Documento As StubW2000.clsSW2000)
        Dim esuDe As Single
        Dim Testo As String
        With Documento
            esuDe = Involucr(kLato, jInvolucr).Spess / (2 * Involucr(kLato, jInvolucr).Spess + Involucr(kLato, jInvolucr).di)
            If esuDe <= 0.16 Then Testo = "CHECK" Else Testo = "NO CHECK"
            .SubstitBookM("esuDe", Format(esuDe, Form1_2), True, 1)
            .SubstitBookM("CHECK1", Testo, True, 1)
            .SubstitBookM("Equation", USStr(0), True, 1)
            .SubstitBookM("MinDesign", Format(t0s, Fors), True, 1)
            If TEMA > 0 Then
                .SubstitBookM("MinTEMA", Format(tts, Fors), True, 1)
            Else
                .EliminaRiga("MinTEMA", 1)
            End If
            .SubstitBookM("Adopted", Format(Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
            .SubstitBookM("CHECK2", "CHECK", True, 1)
        End With
    End Sub
    Private Overloads Sub EUadopted(ByVal Documento As StubW9.clsSW9)
        Dim esuDe As Single
        Dim Testo As String
        With Documento
            esuDe = Involucr(kLato, jInvolucr).Spess / (2 * Involucr(kLato, jInvolucr).Spess + Involucr(kLato, jInvolucr).di)
            If esuDe <= 0.16 Then Testo = "CHECK" Else Testo = "NO CHECK"
            .SubstitBookM("esuDe", Format(esuDe, Form1_2), True, 1)
            .SubstitBookM("CHECK1", Testo, True, 1)
            .SubstitBookM("Equation", USStr(0), True, 1)
            .SubstitBookM("MinDesign", Format(t0s, Fors), True, 1)
            If TEMA > 0 Then
                .SubstitBookM("MinTEMA", Format(tts, Fors), True, 1)
            Else
                .EliminaRiga("MinTEMA", 1)
            End If
            .SubstitBookM("Adopted", Format(Involucr(kLato, jInvolucr).Spess, Fors), True, 1)
            .SubstitBookM("CHECK2", "CHECK", True, 1)
        End With
    End Sub
    Public Sub EUCylConIntest()
        Dim pHydr As Single
        Dim Testo As String
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            With Documento9
                .SubstitBookM("Azienda", clsInizio.Firma, True, 1)
                .SubstitBookM("ProgName", Monitor.Motore.About.ProgName, True, 1)
                .SubstitBookM("PgVe", Monitor.Motore.About.ProgVers, True, 1)
                .SubstitBookM("PgDate", Monitor.Motore.About.ProgDate, True, 1)
                .SubstitBookM("ConstrCode", CodiceCalc, True, 1)
                Monitor.Motore.Avanzamento = 10
                .SubstitBookM("LoadCase", "Design", True, 1)
                .SubstitBookM("DesPress", Format(PressDes(), FormMpa), True, 1)
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
                .SubstitBookM("TempCalc", Format(TempDes(), Fors), True, 1)
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
        Else
            With Documento
                .SubstitBookM("Azienda", clsInizio.Firma, True, 1)
                .SubstitBookM("ProgName", Monitor.Motore.About.ProgName, True, 1)
                .SubstitBookM("PgVe", Monitor.Motore.About.ProgVers, True, 1)
                .SubstitBookM("PgDate", Monitor.Motore.About.ProgDate, True, 1)
                .SubstitBookM("ConstrCode", CodiceCalc, True, 1)
                Monitor.Motore.Avanzamento = 10
                .SubstitBookM("LoadCase", "Design", True, 1)
                .SubstitBookM("DesPress", Format(PressDes(), FormMpa), True, 1)
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
                .SubstitBookM("TempCalc", Format(TempDes(), Fors), True, 1)
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
        End If
    End Sub
    Public Sub EUCylVacuumPr()
        mioApert.Enabled = False
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            With Documento9
                Try
                    .Visible = False
                    .sOpen(clsInizio.Archdir & "\EUcylVacuum.doc", True, 1)
                    .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
                    .VaiInizio("", 1)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("\EndOfDoc")
                    .sPaste1()
                    '---------------------------------
                    .SubstitBookM("DesPress", Format(Pextdes, FormMpa), True)
                    .SubstitBookM("DesTemp", Format(TempDes, Fors), True)
                    .SubstitBookM("Length", Format(Ls, Fors), True)
                    .SubstitBookM("ElLimit", Format(Stheta, FormMpa), True)
                    .SubstitBookM("Py", Format(psig, FormMpa), True)
                    .SubstitBookM("Z", Format(epsZ, Form1_5), True)
                    .SubstitBookM("ncyl", Nmin.ToString, True)
                    .SubstitBookM("eps", Format(Asnell, FormExp))
                    .SubstitBookM("Pm", Format(Pm, FormMpa), True)
                    .SubstitBookM("PmsPy", GlobalRoutines.myStr(Pm / psig, 2, 4, 0), True)
                    .SubstitBookM("PrsPy", GlobalRoutines.myStr(PrPy, 2, 4, 0), True)
                    .SubstitBookM("Prs15", Format(psig1, FormMpa), True)
                    '---------------------------------
                Catch e As Exception
                    MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
                End Try
                .Visible = True
            End With
        Else
            With Documento
                Try
                    .Visible = False
                    .sOpen(clsInizio.Archdir & "\EUcylVacuum.doc", True, 1)
                    .sSaveAs(clsInizio.DiscoTem & "\Temp.doc", 1)
                    .VaiInizio("", 1)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("\EndOfDoc")
                    .sPaste1()
                    '---------------------------------
                    .SubstitBookM("DesPress", Format(Pextdes, FormMpa), True)
                    .SubstitBookM("DesTemp", Format(TempDes, Fors), True)
                    .SubstitBookM("Length", Format(Ls, Fors), True)
                    .SubstitBookM("ElLimit", Format(Stheta, FormMpa), True)
                    .SubstitBookM("Py", Format(psig, FormMpa), True)
                    .SubstitBookM("Z", Format(epsZ, Form1_5), True)
                    .SubstitBookM("ncyl", Nmin.ToString, True)
                    .SubstitBookM("eps", Format(Asnell, FormExp))
                    .SubstitBookM("Pm", Format(Pm, FormMpa), True)
                    .SubstitBookM("PmsPy", GlobalRoutines.myStr(Pm / psig, 2, 4, 0), True)
                    .SubstitBookM("PrsPy", GlobalRoutines.myStr(PrPy, 2, 4, 0), True)
                    .SubstitBookM("Prs15", Format(psig1, FormMpa), True)
                    '---------------------------------
                Catch e As Exception
                    MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
                End Try
                .Visible = True
            End With
        End If
        mioApert.Enabled = True
    End Sub
    Public Sub EUMAWPPr()
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            With Documento9
                .SubstitBookM("MAWP1", Format(Involucr(kLato, jInvolucr).MAWP(1 - 1), FormMpa), True, 1)
                .SubstitBookM("MAWP2", Format(Involucr(kLato, jInvolucr).MAWP(2 - 1), FormMpa), True, 1)
                .SubstitBookM("MAWP3", Format(Involucr(kLato, jInvolucr).MAWP(3 - 1), FormMpa), True, 1)
                .SubstitBookM("MAWP4", Format(Involucr(kLato, jInvolucr).MAWP(4 - 1), FormMpa), True, 1)
                .SubstitBookM("pPImin", Format(pHImin, FormMpa), True, 1)
                .SubstitBookM("pPImax", Format(pHImax, FormMpa), True, 1)
                .SubstitBookM("PIpress", Format(Config(kLato).pxExt, FormMpa), True, 1)
                .SubstitBookM("CHECK3", "CHECK", True, 1)
            End With
        Else
            With Documento
                .SubstitBookM("MAWP1", Format(Involucr(kLato, jInvolucr).MAWP(1 - 1), FormMpa), True, 1)
                .SubstitBookM("MAWP2", Format(Involucr(kLato, jInvolucr).MAWP(2 - 1), FormMpa), True, 1)
                .SubstitBookM("MAWP3", Format(Involucr(kLato, jInvolucr).MAWP(3 - 1), FormMpa), True, 1)
                .SubstitBookM("MAWP4", Format(Involucr(kLato, jInvolucr).MAWP(4 - 1), FormMpa), True, 1)
                .SubstitBookM("pPImin", Format(pHImin, FormMpa), True, 1)
                .SubstitBookM("pPImax", Format(pHImax, FormMpa), True, 1)
                .SubstitBookM("PIpress", Format(Config(kLato).pxExt, FormMpa), True, 1)
                .SubstitBookM("CHECK3", "CHECK", True, 1)
            End With
        End If
        Monitor.Motore.Avanzamento = 80
    End Sub
    Private Sub Warn(ByRef Errore As String)
        Dim Testo As String
        'UPGRADE_NOTE: È possibile che l'oggetto Documento non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Documento = Nothing
        Testo = "Si è prodotto l'errore " & Errore & vbCrLf
        Testo = Testo & "E' possibile che non sia stato trovato" & vbCrLf
        Testo = Testo & "il rapporto di calcolo, o l'applicazione" & vbCrLf
        Testo = Testo & "WinWord che lo gestisce." & vbCrLf
        Testo = Testo & "E' possibile che WinWord sia stato chiuso dall'utente." & vbCrLf
        Testo = Testo & "Probabilmente è necessario ricompilare il rapporto."
        MessageBox.Show(mioApert, Testo)
    End Sub
    Private Sub MaxInv()
        If Involucr(k, i).MAWP(j - 1) < Equipment(l) Then
            Equipment(l) = Involucr(k, i).MAWP(j - 1)
            Indkmax(l) = k
            Indjmax(l) = i
            InvNoz(l) = True
        End If
    End Sub
    Public Function CalcMax() As Boolean
        'calcolo delle MAWP di apparecchio dalle MAWP di membratura
        Dim O As Object
        Dim vMAWP As clsValoriMAWP
        Dim Nuovo As Boolean
        If Config(0).CalcMAWP = 0 Then Exit Function
        If colMAWP Is Nothing Then
            If Config(0).MetodoPI = 0 Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                MostraAiuto(IDH_MANCATABMAT)
                Exit Function
            End If
            colMAWP = New Collection
            Nuovo = True
        Else
            Nuovo = False
        End If
        CalcMax = True
        For l = 1 To 8 : Equipment(l) = 10000000000.0# : Next
        For k = 1 To Config(0).NumeroLati
            For i = 1 To Config(k).Ninvolucri
                If Involucr(k, i).Tipo = 9 Then GoTo Cont
                If Involucr(k, i).Tipo = 8 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb(Involucr(k, i).IndObject).Piastra. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If objMemb(Involucr(k, i).IndObject).Piastra.IndiceDilat > -1 Then
                        GoTo Cont
                    End If
                End If
                Select Case k
                    Case 1
                        For j = 1 To 4
                            l = 1 + (j - 1) * 2
                            MaxInv()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, True)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPSS = Involucr(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = True
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Involucr(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                    Case 2
                        For j = 1 To 4
                            l = j * 2
                            MaxInv()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, True)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPTS = Involucr(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = True
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Involucr(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                    Case 3
                        Select Case Involucr(k, i).Tipo
                            Case 6 'PT
                                O = objMemb(Involucr(k, i).IndObject)
                                If CType(O, wn_PT).TipoPT = 1 Then 'UTEMA
                                    If Not CType(O, wn_PT).ProgDiffPr Then Doppio()
                                Else
                                    If CType(CType(O, wn_PT).Piastra, wn_FTC).Rear = 1 Or Not CType(O, wn_PT).ProgDiffPr Then Doppio()
                                End If
                            Case Else
                                Doppio()
                        End Select
                End Select
Cont:       Next
            For i = 1 To NumBocch(k) + NumBocch2(k) 'Involucr(k, Config(k).Ninvolucri).Fine
                Select Case k
                    Case 1
                        For j = 1 To 4
                            l = 1 + (j - 1) * 2
                            MaxInvN()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, False)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPSS = Nozzles(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = False
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Nozzles(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                    Case 2
                        For j = 1 To 4
                            l = j * 2
                            MaxInvN()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, False)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPTS = Nozzles(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = False
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Nozzles(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                End Select
            Next
        Next
        Exit Function
    End Function
    Private Sub MaxInvN()
        If Nozzles(k, i).MAWP(j - 1) < Equipment(l) Then
            Equipment(l) = Nozzles(k, i).MAWP(j - 1)
            Indkmax(l) = k
            Indjmax(l) = i
            InvNoz(l) = False
        End If
    End Sub
    Private Sub Doppio()
        For j = 1 To 4
            l = j * 2
            If Involucr(k, i).MAWP2(j - 1) < Equipment(l) Then
                Equipment(l) = Involucr(k, i).MAWP2(j - 1)
                Indkmax(l) = k
                Indjmax(l) = i
                InvNoz(l) = True
            End If
            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                If Nuovo Then
                    vMAWP = New clsValoriMAWP
                Else
                    vMAWP = CercavMAWP(k, i, True)
                End If
                If Not vMAWP Is Nothing Then
                    With vMAWP
                        .MAWPTS = Involucr(k, i).MAWP2(j - 1)
                        If Nuovo Then
                            .Inv = True
                            .k = k
                            .i = i
                            .Mark = Trim(Involucr(k, i).Mark)
                        Else
                            TransferMAWP(vMAWP)
                        End If
                    End With
                    If Nuovo Then colMAWP.Add(vMAWP)
                End If
            End If
        Next
        For j = 1 To 4
            l = 1 + (j - 1) * 2
            MaxInv()
            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                With vMAWP
                    .MAWPSS = Involucr(k, i).MAWP(j - 1)
                    If Nuovo Then
                        .Inv = True
                        .k = k
                        .i = i
                        .Mark = Trim(Involucr(k, i).Mark)
                    Else
                        TransferMAWP(vMAWP)
                    End If
                End With
            End If
        Next
    End Sub
    Private Sub RegNozzle()
        If Nuovo Then
            vMAWP = New clsValoriMAWP
        Else
            vMAWP = CercavMAWP(kLato, kNozzle, False, , matFlangia)
            If vMAWP Is Nothing Then
                Nuovo = True
                vMAWP = New clsValoriMAWP
            End If
        End If
        With vMAWP
            .St = Syo
            .Sa = Sya
            .Inv = False
            .k = kLato
            .i = kNozzle
            .Mark = Trim(Nozzles(.k, .i).Mark)
            .Flangia = matFlangia
            If matFlangia Then
                .Mark = .Mark & " (fl.)"
            Else
                .Mark = .Mark & " (tr.)"
            End If
        End With
        If Nuovo Then colMAWP.Add(vMAWP)
    End Sub
End Module
