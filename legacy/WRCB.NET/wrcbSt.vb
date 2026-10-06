Option Strict Off
Option Explicit On
Module wrcbSt
    Private aaa0, bbb0 As Single
    Private StriSt(20) As String
    Sub LocStre()
        Try
            Dim i, NRighe, j As Short
            Dim ifl, Nstep As Short
            Dim k As String
            Dim n(10) As String
            Dim Nfine(15) As String
            ifl = FreeFile()
21560:      FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR02.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 15 : Nfine(i) = LineInput(ifl) : Next
            For i = 1 To 6
                n(i) = LineInput(ifl)
                n(i) = Left(n(i), Len(n(i)) - 1)
            Next
21565:      If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                For i = 1 To 6
                    '           MID$(N$(i), 4, 1) = "é"
                    n(i) = LineInput(ifl)
                    n(i) = Left(n(i), Len(n(i)) - 1)
                Next
            Else
                For i = 1 To 6 : k = LineInput(ifl) : Next
            End If
21570:      For i = 0 To 4 : StriSt(i) = LineInput(ifl) : Next
            '      Nfine$(1) = "  (1)"
            '      Nfine$(2) = "  (7)"
            '      Nfine$(3) = "  (2)"
            '      Nfine$(4) = "  (8)"
            '      Nfine$(5) = "  (3)"
            '      Nfine$(6) = "  (9)"
            '      Nfine$(7) = " (12)"
            '      Nfine$(8) = " (18)"
            '      Nfine$(9) = " (13)"
            '      Nfine$(10) = " (19)"
            '      Nfine$(11) = " (14)"
            '      Nfine$(12) = " (20)"
            '      Nfine$(13) = " (23)"
            '      Nfine$(14) = " (24)"
            '      Nfine$(15) = " (25)"
            If Config.WRC297 < 4 And Geom(iB).ShellType = 1 Or Config.WRC297 < 3 Then
                For i = 1 To 15
                    Nfine(i) = "\par"
                Next
            End If
            '21560 N$(1) = " å(í)membrane [P]  "
            '21570 N$(2) = " å(í)bending  [P]  "
            '21580 N$(3) = " å(í)membrane [Mc] "
            '21590 N$(4) = " å(í)bending  [Mc] "
            '21600 N$(5) = " å(í)membrane [ML] "
            '21610 N$(6) = " å(í)bending  [ML] "
            '      k$ = "  4. LOCAL STRESSES DUE TO EXT.LOADS - STRESS COMPONENTS"
21580:      If Config.WRC297 >= 3 Then StriSt(1) = StriSt(1) & Space(22) & "(G/28)"
            StriSt(1) = StriSt(1) & "\par"
            If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Or Config.WRC297 >= 3 And Geom(iB).PadT > 0 Then
                If ShellNoz = 1 Then
                    Monitor.Motore.Problem.Printa(StriSt(2))  ' "      --- A. STRESSES IN THE SHELL AT THE NOZZLE"
                    Mid(StriSt(1), 4, 2) = "A."
                Else
                    If Config.WRC297 >= 3 Then
21585:                  Monitor.Motore.Problem.Printa(StriSt(3))  ' "      --- B. STRESSES IN THE SHELL AT PAD EDGE"
                    Else
                        Monitor.Motore.Problem.Printa(StriSt(4))  ' "      --- B. STRESSES IN THE NOZZLE AT THE SHELL"
                    End If
                    Mid(StriSt(1), 4, 2) = "B."
                End If
            End If
21620:      Monitor.Motore.Problem.Printa(Space(5) & StriSt(1))  ' k$
            Call Titolo(iB)
            NRighe = 6 : If Geom(iB).ShellType = 1 Then NRighe = 4
21670:      For i = 1 To NRighe
21680:          Monitor.Motore.Problem.Print(Space(2) & n(i))
21690:          For j = 1 To 8
21700:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.0", sConverti(wrcN(ShellNoz, i, j), 2)))
21710:          Next j
21720:          Monitor.Motore.Problem.Printa(Nfine(i))
21730:      Next i
            For i = 1 To 6
                n(i) = LineInput(ifl)
                n(i) = Left(n(i), Len(n(i)) - 1)
            Next
            '21750 N$(1) = " å(x)membrane [P]  "
            '21760 N$(2) = " å(x)bending  [P]  "
            '21770 N$(3) = " å(x)membrane [Mc] "
            '21780 N$(4) = " å(x)bending  [Mc] "
            '21790 N$(5) = " å(x)membrane [ML] "
            '21800 N$(6) = " å(x)bending  [ML] "
            If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                For i = 1 To 6
                    n(i) = LineInput(ifl)
                    n(i) = Left(n(i), Len(n(i)) - 1)
                Next
            Else
                For i = 1 To 6 : k = LineInput(ifl) : Next
            End If
            NRighe = 6 : If Geom(iB).ShellType = 1 Then NRighe = 4
21810:      For i = 1 To NRighe
21820:          Monitor.Motore.Problem.Print(Space(2) & n(i))
21830:          For j = 1 To 8
21840:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcN(ShellNoz, i + 6, j), 2)))
21850:          Next j
21860:          Monitor.Motore.Problem.Printa(Nfine(i + 6))
21870:      Next i
            If Geom(iB).ShellType = 0 Then
                Nstep = 1
                If Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                    For i = 1 To 3
                        n(i) = LineInput(ifl)
                        n(i) = Left(n(i), Len(n(i)) - 1)
                    Next
                    For i = 1 To 3 : k = LineInput(ifl) : Next
                    For i = 1 To 3 : k = LineInput(ifl) : Next
                Else
                    For i = 1 To 3 : k = LineInput(ifl) : Next
                    For i = 1 To 3
                        n(i) = LineInput(ifl)
                        n(i) = Left(n(i), Len(n(i)) - 1)
                    Next
                    For i = 1 To 3 : k = LineInput(ifl) : Next
                End If
            Else
                Nstep = 2
                For i = 1 To 3 : k = LineInput(ifl) : Next
                For i = 1 To 3 : k = LineInput(ifl) : Next
                For i = 1 To 3
                    n(i) = LineInput(ifl)
                    n(i) = Left(n(i), Len(n(i)) - 1)
                Next
            End If 'k
21920:      For i = 1 To 3 Step Nstep
21930:          Monitor.Motore.Problem.Print(Space(2) & n(i))
21940:          For j = 1 To 8
21950:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcN(ShellNoz, i + 12, j), 2)))
21960:          Next j
21970:          Monitor.Motore.Problem.Printa(Nfine(12 + i))
21980:      Next i
            Monitor.Motore.Problem.Printa(StriSt(0))
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'a

    Sub LocStre1()
        Try
            Dim O(4) As String
            Dim Ofine(4) As String
            Dim StriSt(18) As String
            Dim ifl As Short
            Dim i, j As Short
            Dim k As String
            Dim iElim As Boolean
            Dim NRow As Short
            Dim a As String
            ifl = FreeFile()
22050:      FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR03.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 3 : Ofine(i) = LineInput(ifl) : Next
            '      Ofine$(1) = "  (4)"
            '      Ofine$(2) = " (15)"
            '      Ofine$(3) = " (26)"
            If Config.WRC297 < 4 And Geom(iB).ShellType = 1 Or Config.WRC297 < 3 Then
22052:          For i = 1 To 3
                    Ofine(i) = ""
                    Ofine(i) = "\par" ' StriSt$(0)
                Next
            End If
            For i = 1 To 2
                O(i) = LineInput(ifl)
22054:          O(i) = Left(O(i), Len(O(i)) - 1)
            Next
            '      O$(1) = "    å(í)              "
            '22050 O$(2) = "    å(x)              "
            If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                '          MID$(O$(1), 7, 1) = "é"
                '          MID$(O$(2), 7, 1) = "r"
22056:          For i = 1 To 2
                    O(i) = LineInput(ifl)
                    O(i) = Left(O(i), Len(O(i)) - 1)
                Next
            Else
                For i = 1 To 2 : k = LineInput(ifl) : Next
            End If
            O(3) = LineInput(ifl)
            O(3) = Left(O(3), Len(O(3)) - 1)
            '22060 O$(3) = "    çàu               "
            For i = 0 To 18 : StriSt(i) = LineInput(ifl) : Next
22070:      If Geom(iB).Buco > 0 Or Geom(iB).Forma > 0 Then
22080:          Monitor.Motore.Problem.Print(Space(16) & "Att.nt Mark:" & Geom(iB).Mark)
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), Geom(iB).Carichi(iC).CaseDescription))  'TAB(61); "Load Case  :"
            End If
            k = StriSt(2) '"       5. LOCAL STRESSES DUE TO EXT.LOADS - PRIMARY MEMBRANE"
            Call CasoCarico(k)
22090:      Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB)
22160:      For i = 1 To 3
22170:          Monitor.Motore.Problem.Print(Space(2) & O(i))
22180:          For j = 1 To 8
22190:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i, j), 2)))
22200:          Next j
22210:          Monitor.Motore.Problem.Printa(Ofine(i))
22220:      Next i
22230:      Monitor.Motore.Problem.Printa(StriSt(0))
            For i = 1 To 3 : Ofine(i) = LineInput(ifl) : Next
            '      Ofine$(1) = "(10+4)"
            '      Ofine$(2) = "(21+15)"
            '      Ofine$(3) = " (26) "
            If Config.WRC297 < 4 And Geom(iB).ShellType = 1 Or Config.WRC297 < 3 Then
                For i = 1 To 3 : Ofine(i) = StriSt(0) : Next
            End If
            k = StriSt(3) ' "       6. LOCAL STRESSES DUE TO EXT.LOADS - PRIMARY + SECONDARY "
            Call CasoCarico(k)
22240:      Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB)
22290:      For i = 1 To 3
22300:          Monitor.Motore.Problem.Print(Space(2) & O(i))
22310:          For j = 1 To 8
22320:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 3, j), 2)))
22330:          Next j
22340:          Monitor.Motore.Problem.Printa(Ofine(i))
22350:      Next i
22360:      Monitor.Motore.Problem.Printa(StriSt(0))
22370:      If Geom(iB).Forma = 0 Then GoTo 22410
22380:      Monitor.Motore.Problem.Printa(StriSt(18))  'CHR$(12)
22390:      Call Testata(iB, iC)
22400:      Monitor.Motore.Problem.Printa(StriSt(0))
22410:      For i = 1 To 4
                O(i) = LineInput(ifl)
                O(i) = Left(O(i), Len(O(i)) - 1)
            Next
            '22410 O$(1) = "    å(í)              "
            '22420 O$(2) = "    å(x)              "
            '22430 O$(3) = "    å(r) radial-shell "
            If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                For i = 1 To 4
                    O(i) = LineInput(ifl)
                    O(i) = Left(O(i), Len(O(i)) - 1)
                Next
                '          MID$(O$(1), 7, 1) = "é"
                '          MID$(O$(2), 7, 1) = "r"
                '          MID$(O$(3), 7, 1) = "z"
            Else
                For i = 1 To 4 : k = LineInput(ifl) : Next
            End If
22440:      If Geom(iB).Carichi(iC).DesPress < 0 Then
22450:          k = StriSt(4) '"  7. LOCAL STRESSES DUE TO EXT.PRESSURE - PRIMARY MEMBRANE "
            Else
                k = StriSt(5) '"  7. LOCAL STRESSES DUE TO INT.PRESSURE - PRIMARY MEMBRANE "
            End If
            For i = 1 To 2 : Ofine(i) = LineInput(ifl) : Next
            '      Ofine$(1) = "  (5)"
            '      Ofine$(2) = " (16)"
            iElim = True
            If Config.WRC297 < 4 And Geom(iB).ShellType = 1 Or Config.WRC297 < 3 Then
                For i = 1 To 2 : Ofine(i) = StriSt(0) : Next
                iElim = False
            End If
            Call CasoCarico(k)
            Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB) : NRow = 3 : If iElim Then NRow = 2
22520:      For i = 1 To NRow
22530:          Monitor.Motore.Problem.Print(Space(2) & O(i))
22540:          For j = 1 To 8
22550:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 6, j), 2)))
22560:          Next j
22570:          Monitor.Motore.Problem.Printa(Ofine(i))
22580:      Next i
22590:      Monitor.Motore.Problem.Printa(StriSt(0))
22600:      If Geom(iB).Carichi(iC).DesPress < 0 Then
22610:          k = StriSt(6) ' "  8. LOCAL STRESSES DUE TO EXT.PRESSURE - PRIMARY + SECONDARY"
            Else
                k = StriSt(7) ' "  8. LOCAL STRESSES DUE TO INT.PRESSURE - PRIMARY + SECONDARY"
            End If
            Call CasoCarico(k)
            Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB)
22680:      For i = 1 To NRow
22690:          Monitor.Motore.Problem.Print(Space(2) & O(i))
22700:          For j = 1 To 8
22710:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 9, j), 2)))
22720:          Next j
22730:          Monitor.Motore.Problem.Printa(Ofine(i))
22740:      Next i
22750:      Monitor.Motore.Problem.Printa(StriSt(0))
            Call Testata(iB, iC)
            For i = 1 To 2 : Ofine(i) = LineInput(ifl) : Next
            'Ofine$(1) = "  (6)"
            'Ofine$(2) = " (17)"
            If Not iElim Then
                For i = 1 To 4 : Ofine(i) = StriSt(0) : Next
            End If
            '22760 O$(1) = "    å(í)              "
            '22770 O$(2) = "    å(x)              "
            '      O$(3) = "    å(r) radial-shell "
            '      IF Geom(iB).Shell = 0 AND Config.WRC297 = 2 AND Geom(iB).Forma = 0 THEN
            '           MID$(O$(1), 7, 1) = "é"
            '           MID$(O$(2), 7, 1) = "r"
            '           MID$(O$(3), 7, 1) = "z"
            '      END IF
            '22790 O$(4) = "    çàu               "
22800:      If Geom(iB).Carichi(iC).DesPress < 0 Then
22810:          k = StriSt(8) '"       9. COMBINED STRESSES DUE TO EXT.LOADS + EXT.PRESSURE - PRIMARY MEMBRANE"
            Else
                k = StriSt(9) '"       9. COMBINED STRESSES DUE TO EXT.LOADS + INT.PRESSURE - PRIMARY MEMBRANE"
            End If
            If Config.WRC297 >= 3 Then k = k & Space(4) & "(G/28)" & StriSt(0) Else k = k & StriSt(0)
            Call CasoCarico(k)
            Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB)
            NRow = 4 : If iElim Then NRow = 2
22880:      For i = 1 To NRow
22890:          Monitor.Motore.Problem.Print(Space(2) & O(i))
22900:          For j = 1 To 8
22910:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 12, j), 2)))
22920:          Next j
22930:          Monitor.Motore.Problem.Printa(Ofine(i))
22940:      Next i
22950:      Monitor.Motore.Problem.Printa(StriSt(0))
22960:      If Geom(iB).Carichi(iC).DesPress < 0 Then
22970:          k = StriSt(10) '" 10. COMBINED STRESSES DUE TO EXT.LOADS + EXT.PRESSURE - PRIMARY + SECONDARY"
            Else
                k = StriSt(11) '" 10. COMBINED STRESSES DUE TO EXT.LOADS + INT.PRESSURE - PRIMARY + SECONDARY"
            End If
            For i = 1 To 2 : Ofine(i) = LineInput(ifl) : Next
            '      Ofine$(1) = " (11)"
            '      Ofine$(2) = " (22)"
            If Not iElim Then
                For i = 1 To 4 : Ofine(i) = StriSt(0) : Next
            End If
            Call CasoCarico(k)
            Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB)
23040:      For i = 1 To NRow
23050:          Monitor.Motore.Problem.Print(Space(2) & O(i))
23060:          For j = 1 To 8
23070:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 16, j), 2)))
23080:          Next j
23090:          Monitor.Motore.Problem.Printa(Ofine(i))
23100:      Next i
23110:      Monitor.Motore.Problem.Printa(StriSt(0))
            For i = 1 To 2
                O(i) = LineInput(ifl)
                O(i) = Left(O(i), Len(O(i)) - 1)
            Next
            '23120 O$(1) = "        (Primary)     "
            '23130 O$(2) = "   (Primary+Secondary)"
23150:      If Geom(iB).Carichi(iC).DesPress < 0 Then
23140:          k = StriSt(12) ' " 11. FINAL COMBINED STRESS INTENSITIES - EXT.LOADS + EXT.PRESSURE"
            Else
                k = StriSt(13) '" 11. FINAL COMBINED STRESS INTENSITIES - EXT.LOADS + INT.PRESSURE"
            End If
            Call CasoCarico(k)
            Monitor.Motore.Problem.Printa(Space(5) & k)
            Call Titolo(iB)
            Ofine(1) = LineInput(ifl)
            Ofine(2) = LineInput(ifl)
            '     Ofine$(1) = "(32/33/34)"
            '     Ofine$(2) = "(27/28/29)"
            If Not iElim Then
                Ofine(1) = StriSt(0) : Ofine(2) = StriSt(0)
            End If
23220:      For i = 1 To 2
23230:          Monitor.Motore.Problem.Print(O(i))
23240:          For j = 1 To 8
23250:              Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 20, j), 2)))
23260:          Next j
23270:          Monitor.Motore.Problem.Printa(Ofine(i))
23280:      Next i
            If iElim Then
                k = StriSt(14) ' " 12. LOCAL COMPRESSIVE STRESSES DUE TO EXT. LOADS"
                For i = 1 To 2
                    O(i) = LineInput(ifl)
                    O(i) = Left(O(i), Len(O(i)) - 1)
                Next
                '          O$(1) = "    å(í)              "
                '          O$(2) = "    å(x)              "
                '          Ofine$(1) = " (30)"
                '          Ofine$(2) = " (31)"
                Ofine(1) = LineInput(ifl)
                Ofine(2) = LineInput(ifl)
                Call CasoCarico(k)
                Monitor.Motore.Problem.Printa(StriSt(0))
                Monitor.Motore.Problem.Printa(Space(5) & k)
                Call Titolo(iB)
                For i = 1 To 2
                    Monitor.Motore.Problem.Print(Space(2) & O(i))
                    For j = 1 To 8
                        Monitor.Motore.Problem.Print(globalRoutines.FormatS("#####.#", sConverti(wrcO(ShellNoz, i + 22, j), 2)))
                    Next j
                    Monitor.Motore.Problem.Printa(Ofine(i))
                Next i
            End If
23290:      Monitor.Motore.Problem.Printa(StriSt(0))
23300:      Monitor.Motore.Problem.Print(StriSt(15))  ' "     (Primary)            Max.SI = ";
23310:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(" ####.##", sConverti(Result(ShellNoz, iC, iB).SP, 2)))
            a = " < " : If Result(ShellNoz, iC, iB).SP > StressLim(iC, iB).ASL(ShellNoz) Then a = " > "
23320:      Monitor.Motore.Problem.Print(a)
23330:      Monitor.Motore.Problem.Print(globalRoutines.FormatS("####.##", sConverti(StressLim(iC, iB).ASL(ShellNoz), 2)))
23340:      Monitor.Motore.Problem.Printa(" " & Config.Unit(6) & StriSt(0))
23350:      Monitor.Motore.Problem.Print(StriSt(16))  'TAB(5); "(Primary+Secondary)       Max.SI = ";
23360:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(" ####.##", sConverti(Result(ShellNoz, iC, iB).Sq, 2)))
            a = " < "
            If Result(ShellNoz, iC, iB).Sq > StressLim(iC, iB).ASQ(ShellNoz) Then a = " > "
23370:      Monitor.Motore.Problem.Print(a)
23380:      Monitor.Motore.Problem.Print(globalRoutines.FormatS("####.##", sConverti(StressLim(iC, iB).ASQ(ShellNoz), 2)))
23390:      Monitor.Motore.Problem.Printa(" " & Config.Unit(6) & StriSt(0))
            If Config.WRC297 > 2 Then
                Monitor.Motore.Problem.Print(StriSt(17))  ' TAB(5); "(Compressive Stress)      Max.   = ";
                Monitor.Motore.Problem.Print(globalRoutines.FormatS("####.##", sConverti(Result(ShellNoz, iC, iB).Bu, 2)))
                a = " < " : If Result(ShellNoz, iC, iB).Bu > Geom(iB).Carichi(iC).YieldNoz * Geom(iB).Carichi(1).fBuc Then a = " > "
                Monitor.Motore.Problem.Print(a)
                Monitor.Motore.Problem.Print(globalRoutines.FormatS("####.##", sConverti(Geom(iB).Carichi(iC).YieldNoz * Geom(iB).Carichi(1).fBuc, 2)))
                Monitor.Motore.Problem.Printa(" " & Config.Unit(6) & StriSt(0))
            End If
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'b
    Private Sub CasoCarico(ByVal k As String)
        If Not (Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0 Or Config.WRC297 >= 3 And Geom(iB).PadT > 0) Then Exit Sub
        If ShellNoz = 1 Then
            Mid(k, 4, 2) = "A."
        Else
            Mid(k, 4, 2) = "B."
        End If
    End Sub
    Public Function Stampa() As Boolean
        Dim ShellSav As Short
        Try
            FileSt = Apert.DefInstance.Text1.Text
            If iC = 1 Then
                If Not PrepRapp(Template, "Bocchello (WRCB)", "Nozzle " & Trim(Geom(iB).Mark), FileSt, Apert.DefInstance.lstRapp) Then Exit Function
            End If
            Stampa = True
18530:      If Config.Analisi = 2 Then GoTo 23500
18532:      Call Testata(iB, iC)
18534:      Call StampData(iB, iC)
            Monitor.Motore.Problem.Printa("       3. GEOMETRIC PARAMETERS\par")
            If Geom(iB).ShellType = 0 Then
                If Config.WRC297 >= 3 Then
                    Call StGeomCilG(iB)
                ElseIf Config.WRC297 = 2 And Geom(iB).Forma = 0 Then
                    Call StGeomCil1(iB)
                Else
19640:              If Geom(iB).Forma = 0 Then GoTo 20230
                    Call StGeomCil0(iB)
20220:              Call Testata(iB, iC)
20230:              Call StGeomCil(iB)
                End If
            Else
                If Config.WRC297 < 4 Then
20232:              Call StGeomSfe(iB)
                Else
                    If Geom(iB).Buco = 0 Then Call StGeomSfeG(iB) Else Call StGeomRigG(iB)
                End If
            End If 'j
            If Config.WRC297 = 4 And Geom(iB).ShellType = 1 And Geom(iB).Buco = 0 Then
23234:          Call StSfeG(iB, iC)
            Else
20236:          Call Testata(iB, iC)
                ShellSav = ShellNoz
                If Config.WRC297 < 3 Then ShellNoz = 1
20238:          Call LocStre()
22040:          Call LocStre1()
                ShellNoz = ShellSav
            End If
            If Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Buco = 0 And Geom(iB).Forma = 0 Then
                Call Testata(iB, iC)
                ShellSav = ShellNoz
                ShellNoz = 2
22060:          Call LocStre()
                Call LocStre1()
                ShellNoz = ShellSav
            End If
23410:      If Config.Analisi = 0 Then Exit Function
            ShellSav = ShellNoz
            ShellNoz = 1
23500:      Call Testata(-iB, iC)
23501:      Call StampaNoz(iB, iC)
            ShellNoz = ShellSav
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function 'c

    Sub StampaNoz(ByRef iB As Short, ByRef iC As Short)
        Dim ifl, i As Short
        Dim WVc, WMl, WP, WMc, WMt, WVl As Single
        Dim TVc, TMl, TP, TMc, TMt, TVl As Single
        Try
            Dim StriSt(76) As String
            ifl = FreeFile()
            FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR04.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 0 To 76
                StriSt(i) = LineInput(ifl)
                StriSt(i) = RTrim(StriSt(i))
                If Right(StriSt(i), 1) = "." Then StriSt(i) = Left(StriSt(i), Len(StriSt(i)) - 1)
            Next
            FileClose(ifl)
            'Monitor.Motore.Problem.Print(StriSt$(3)) '; '" N O Z Z L E  P I P I N G  T R A N S I T I O N ";
23520:      Monitor.Motore.Problem.Printa(StriSt(4) & Geom(iB).NozzMat & StriSt(0) & StriSt(0))  '"   Nozzle Mat.:"
            'Monitor.Motore.Problem.Printa(New String(CChar(" "), 47) & StriSt$(5) & Geom(iB).Mark & StriSt$(0)) '"   Nozzle Mark:"
            'Monitor.Motore.Problem.Printa(New String(CChar(" "), 47) & StriSt$(6) & Geom(iB).Size & StriSt$(0)) '"   Nozzle Size:"
            'Monitor.Motore.Problem.Printa(StriSt$(7) & Geom(iB).Carichi(iC).CaseDescription & StriSt$(0) & StriSt$(0)) '"   Load Case  :"
23570:      Monitor.Motore.Problem.Printa(StriSt(8))  '"  1. DESIGN CONDITIONS ";StriSt$(0)
23580:      Monitor.Motore.Problem.Print(StriSt(9) & Config.Unit(5) & StriSt(10) & Space(1))  ' "po           = ";
23590:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(Geom(iB).Carichi(iC).DesPress, 2)))
23600:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(11) & Config.Unit(7) & StriSt(12) & Space(1))
23610:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(Geom(iB).Carichi(iC).DesTemp, 1)))
23620:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(13) & Config.Unit(5) & StriSt(14) & Space(1))  '"Sn           = ";
23630:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(Geom(iB).Carichi(iC).AllowNoz, 2)))
23640:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(15) & Config.Unit(4) & StriSt(16) & Space(1))  '"k            = ";
23650:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), Geom(iB).kS)) : Monitor.Motore.Problem.Printa(StriSt(0))
            Call ComposW(WP, WMc, WMl, WMt, WVc, WVl)
            Call ComposT(TP, TMc, TMl, TMt, TVc, TVl)
23660:      Monitor.Motore.Problem.Printa(StriSt(0))
23670:      Monitor.Motore.Problem.Printa(StriSt(17) & Space(31) & StriSt(18) & StriSt(0))  '"    External Loads ";
23690:      Monitor.Motore.Problem.Print(StriSt(19) & Config.Unit(3) & StriSt(20) & Space(1))  ' "P            = ";
23700:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WP, 3)))
23710:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TP, 3)))
23720:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(21) & Config.Unit(2) & StriSt(22) & Space(1))  ' "Mc           = ";
23730:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WMc, 4)))
23740:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TMc, 4)))
23750:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(23) & Config.Unit(2) & StriSt(24) & Space(1))  ' "ML           = ";
23760:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WMl, 4)))
23770:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TMl, 4)))
23780:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(25) & Config.Unit(2) & StriSt(26) & Space(1))  ' "MT           = ";
23790:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WMt, 4)))
23800:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TMt, 4)))
23810:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(27) & Config.Unit(3) & StriSt(28) & Space(1))  ' "Vc           = ";
23820:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WVc, 3)))
23830:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TVc, 3)))
23840:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(29) & Config.Unit(3) & StriSt(30) & Space(1))  ' "VL           = ";
23850:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WVl, 3)))
23860:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TVl, 3)))
23870:      Monitor.Motore.Problem.Printa(StriSt(0) & StriSt(0))
23880:      Monitor.Motore.Problem.Print(StriSt(31) & Config.Unit(3) & StriSt(22) & Space(1))  ' "P            = ";
23890:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WP, 3)))
23900:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TP, 3)))
            Monitor.Motore.Problem.Print(StriSt(0) & StriSt(32) & Config.Unit(3) & StriSt(33) & Space(1))  ' "P            = ";
23920:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WCV, 3)))
23930:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TCV, 3)))
            Monitor.Motore.Problem.Print(StriSt(0) & StriSt(34) & Config.Unit(2) & StriSt(35) & Space(1))  ' "P            = ";
23950:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WCM, 4)))
23960:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TCM, 4)))
            Monitor.Motore.Problem.Print(StriSt(0) & StriSt(36) & Config.Unit(2) & StriSt(37) & Space(1))  ' "P            = ";
23980:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), sConverti(WMt, 4)))
23990:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), sConverti(TMt, 4)))
24000:      Monitor.Motore.Problem.Printa(StriSt(0) & StriSt(0))
24010:      Monitor.Motore.Problem.Printa(StriSt(38) & StriSt(0))  '"  2. GEOMETRY "
24020:      Monitor.Motore.Problem.Print(StriSt(39) & Config.Unit(1) & StriSt(40) & Space(1))  ' "ri = ";
24030:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), RJ))
24040:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(41) & Config.Unit(1) & StriSt(42) & Space(1))  ' "t  = ";
24050:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Geom(iB).T0))
24060:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(43) & Config.Unit(1) & StriSt(44) & Space(1))  ' "t1 = ";
24070:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Geom(iB).TX))
            Monitor.Motore.Problem.Print(StriSt(0) & StriSt(45) & Config.Unit(1) & StriSt(46) & Space(1))  ' "h  = ";
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Geom(iB).Sporg))
24080:      Monitor.Motore.Problem.Print(StriSt(0) & StriSt(47) & Config.Unit(1) & StriSt(48) & Space(1))  ' "c  = ";
24090:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Geom(iB).Corr))
            Monitor.Motore.Problem.Print(StriSt(0) & StriSt(74) & Config.Unit(1) & StriSt(75) & Space(1))  ' "c  = ";
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Geom(iB).CorrN))
24100:      Monitor.Motore.Problem.Printa(StriSt(0) & StriSt(0))
24110:      Monitor.Motore.Problem.Printa(StriSt(49))  '"  3. STRESS COMPONENTS ";
24120:      Monitor.Motore.Problem.Printa(StriSt(50))  'TAB(59); "** SECTIONS **"
24130:      Monitor.Motore.Problem.Printa(StriSt(51))  'TAB(59); " A-A "; TAB(68); " B-B "
24140:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(52), Config.Unit(1), EX, E0))
24170:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(53), Config.Unit(1), DMX, DM0))
24200:      Monitor.Motore.Problem.Printa(StriSt(0))
24210:      Monitor.Motore.Problem.Printa(StriSt(54))  '"    Pressure Loads "
24220:      If Geom(iB).Carichi(iC).DesPress < 0 Then GoTo 24330
24230:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(55), Config.Unit(5), sConverti(ZPRA, 2), sConverti(ZPRB, 2)))
24260:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(56), Config.Unit(5), sConverti(SPRA, 2), sConverti(SPRB, 2)))
24290:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(57), Config.Unit(5), sConverti(RPRA, 2), sConverti(RPRB, 2)))
24320:      GoTo 24430
24330:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(58), Config.Unit(5), sConverti(ZPRA, 2), sConverti(ZPRB, 2)))
24360:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(59), Config.Unit(5), sConverti(SPRA, 2), sConverti(SPRB, 2)))
24390:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(60), Config.Unit(5), sConverti(RPRA, 2), sConverti(RPRB, 2)))
24430:      Monitor.Motore.Problem.Printa(StriSt(61))  '"    Dead Loads "
24440:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(62), Config.Unit(5), sConverti(SWFA, 2), sConverti(SWFB, 2)))
24470:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(63), Config.Unit(5), sConverti(SWMA, 2), sConverti(SWMB, 2)))
24500:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(64), Config.Unit(5), sConverti(TWTA, 2), sConverti(TWTB, 2)))
24530:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(65), Config.Unit(5), sConverti(TWVA, 2), sConverti(TWVB, 2)))
24570:      Monitor.Motore.Problem.Printa(StriSt(66))  '"    Thermal Loads "
24580:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(62), Config.Unit(5), sConverti(STFA, 2), sConverti(STFB, 2)))
24610:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(63), Config.Unit(5), sConverti(STMA, 2), sConverti(STMB, 2)))
24640:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(64), Config.Unit(5), sConverti(TTTA, 2), sConverti(TTTB, 2)))
24670:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(65), Config.Unit(5), sConverti(TTVA, 2), sConverti(TTVB, 2)))
24710:      Monitor.Motore.Problem.Printa(StriSt(67))  '"  4. STRESS INTENSITIES "
24720:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(68), Config.Unit(5), sConverti(Result(ShellNoz, iC, iB).SMA, 2), sConverti(Result(ShellNoz, iC, iB).SMB, 2)))
24750:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(69), Config.Unit(5), sConverti(Result(ShellNoz, iC, iB).SLA, 2), sConverti(Result(ShellNoz, iC, iB).SLB, 2)))
24780:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(70), Config.Unit(5), sConverti(Result(ShellNoz, iC, iB).SQA, 2), sConverti(Result(ShellNoz, iC, iB).SQB, 2)))
24810:      Monitor.Motore.Problem.Printa(StriSt(0))
24820:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(71), sConverti(Result(ShellNoz, iC, iB).SMM, 2), sConverti(StressLim(iC, iB).ANM, 2), Config.Unit(5)))
24870:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(72), sConverti(Result(ShellNoz, iC, iB).SLM, 2), sConverti(StressLim(iC, iB).ANL, 2), Config.Unit(5)))
24920:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(73), sConverti(Result(ShellNoz, iC, iB).SQM, 2), sConverti(StressLim(iC, iB).ANQ, 2), Config.Unit(5)))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'd
    Sub StampData(ByRef iB As Short, ByRef iC As Short)
        Dim ifl, i As Short
        Dim RR As Single
        Dim OK As String
        Dim TotVc, TotMl, TotP, TotMc, TotMt, TotVl As Single
        Dim TotVc1, TotMl1, TotP1, TotMc1, TotMt1, TotVl1 As Single
        Try
100:        Dim Stringa5(1) As String
            Dim Stringa6(1) As String
            Dim Stringa7(1) As String
            Dim Stringa8(1) As String
            Dim StriSt(42) As String
            ifl = FreeFile()
200:        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR05.WRC", OpenMode.Input, , OpenShare.Shared)
201:        For i = 0 To 42 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            Stringa5(0) = "CYLINDRICAL or ASSIMILATED"
            Stringa5(1) = "SPHERICAL or ASSIMILATED"
            Stringa6(0) = "ROUND   "
            Stringa6(1) = "RECTANG."
            Stringa7(0) = "HOLLOW  "
            Stringa7(1) = "RIGID   "
            Stringa8(1) = "REINFORCED"
            Stringa8(0) = "NOT REINF."
220:        RR = Geom(iB).R0 : If Geom(iB).RX > RR Then RR = Geom(iB).RX
            Monitor.Motore.Problem.Printa(StriSt(0))
19150:      Monitor.Motore.Problem.Printa(StriSt(1))  ' "  1. DESIGN CONDITIONS                      "
19160:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Config.Unit(5), sConverti(Geom(iB).Carichi(iC).DesPress, 2)))
            Call Compos(TotP, TotMc, TotMl, TotMt, TotVc, TotVl)
            Call Compos1(TotP1, TotMc1, TotMl1, TotMt1, TotVc1, TotVl1)
19180:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(3), Config.Unit(3), sConverti(TotP1, 3), sConverti(TotP, 3)))
            If Geom(iB).ShellType = 0 Then
19200:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(4), Config.Unit(2), sConverti(TotMc1, 4), sConverti(TotMc, 4)))
            Else
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(5), Config.Unit(2), sConverti(TotMc1, 4), sConverti(TotMc, 4)))
            End If 'e
            If Geom(iB).ShellType = 0 Then
19220:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(6), Config.Unit(2), sConverti(TotMl1, 4), sConverti(TotMl, 4)))
            End If 'f
19240:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(7), Config.Unit(2), sConverti(TotMt1, 4), sConverti(TotMt, 4)))
            If Geom(iB).ShellType = 0 Then
19260:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(8), Config.Unit(3), sConverti(TotVc1, 3), sConverti(TotVc, 3)))
            Else
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(9), Config.Unit(3), sConverti(TotVc1, 3), sConverti(TotVc, 3)))
            End If 'g
            If Geom(iB).ShellType = 0 Then
19280:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(10), Config.Unit(3), sConverti(TotVl1, 3), sConverti(TotVl, 3)))
            End If 'h
19300:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(11), Config.Unit(7), sConverti(Geom(iB).Carichi(iC).DesTemp, 1)))
19320:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(12), Config.Unit(5), sConverti(Geom(iB).Carichi(iC).AllowShe, 2)))
            If Config.WRC297 < 3 Then
19340:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(13), Config.Unit(4), Geom(iB).kS))
            Else
                If Config.Ammiss = 1 Then Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(14), Config.Unit(5), sConverti(Geom(iB).Carichi(iC).AllowSheBr, 2)))
            End If
19360:      Monitor.Motore.Problem.Printa(StriSt(0))
            If Config.Reduced = 1 Then
                Monitor.Motore.Problem.Printa(StriSt(15))  'TAB(5); "    (Note: Above moments have been reduced to the shell junction)"
                Monitor.Motore.Problem.Printa(StriSt(0))
            End If
19370:      Monitor.Motore.Problem.Printa(StriSt(16))  'TAB(5); "  2. GEOMETRY                               "
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(17), Stringa5(Geom(iB).ShellType)))
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(18), Stringa6(Geom(iB).Forma), Stringa7(Geom(iB).Buco), Stringa8(System.Math.Abs(Geom(iB).Rinforzo))))
19380:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(19), Config.Unit(1), Geom(iB).ShellT))
            If Geom(iB).ShellType = 1 Then
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(20), Config.Unit(1), Geom(iB).RC))
            Else
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(21), Config.Unit(1), Geom(iB).di))
            End If
            If Geom(iB).Rinforzo Then
19400:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(22), Config.Unit(1), Geom(iB).PadT))
                If Geom(iB).Forma = 0 Then
                    Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(23), Config.Unit(1), Geom(iB).Padd))
                    If Geom(iB).ShellType = 0 Or Geom(iB).Buco = 1 Or Config.WRC297 < 3 Then
                        Monitor.Motore.Problem.Printa(StriSt(0))
                    Else
                        If Geom(iB).BS35434 Then OK = " OK" Else OK = " not OK"
                        Monitor.Motore.Problem.Printa("  Cl.3.5.4.3.4(b)   :" & OK & StriSt(0))
                    End If
                Else
                    Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(24), Config.Unit(1), Geom(iB).D1Rinf))
                    Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(25), Config.Unit(1), Geom(iB).D2Rinf))
                End If
            End If
19420:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(26), Config.Unit(1), Geom(iB).Corr))
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(41), Config.Unit(1), Geom(iB).CorrN))
19440:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(27), Config.Unit(1), Geom(iB).T))
19460:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(28), Config.Unit(1), Geom(iB).RM))
19480:      If Geom(iB).Forma > 0 Then GoTo 19550
19490:      If Config.Analisi = 0 Then GoTo 19520
19500:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(29), Config.Unit(1), RR))
19510:      GoTo 19531
19520:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(30), Config.Unit(1), RR))
19531:      If Config.WRC297 > 2 And Geom(iB).ShellType = 0 Then
                If G20(Geom(iB).di / 2, Geom(iB).ShellT, RR - Geom(iB).T / 2) Then OK = " OK" Else OK = " not OK"
                Monitor.Motore.Problem.Printa("  Cl.G.2.2,Fig.G2(0):" & OK & StriSt(0))
            Else
                Monitor.Motore.Problem.Printa(StriSt(0))
            End If
            GoTo 19590
19550:      If Geom(iB).ShellType = 0 Then
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(31), Config.Unit(1), Geom(iB).D1))
19570:          Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(32), Config.Unit(1), Geom(iB).D2))
            Else
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(33), Config.Unit(1), Geom(iB).D1))
            End If 'i
19590:      If Geom(iB).Buco = 0 Then
                If Geom(iB).TX <= Geom(iB).T0 Then
19600:              Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(34), Config.Unit(1), Geom(iB).T0))
                Else
                    Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(35), Config.Unit(1), Geom(iB).TX))
                    Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(36), Config.Unit(1), Geom(iB).T0))
                End If
            End If
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(37), Config.Unit(1), Geom(iB).Sporg))
            If Config.WRC297 > 2 And Geom(iB).ShellType = 0 Then
                Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(38), Config.Unit(1), Geom(iB).CylL))
                If Geom(iB).CylL > Geom(iB).di / 2 Then OK = " OK" Else OK = " not OK"
                Monitor.Motore.Problem.Printa("  Cl.G.2.2, L>r     :" & OK & StriSt(0))
                Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(39), Config.Unit(1), Geom(iB).Cyld))
                If Geom(iB).CylL / 2 > Geom(iB).Cyld + Geom(iB).di / 4 + RR Then OK = " OK" Else OK = " not OK"
                Monitor.Motore.Problem.Printa("  Cl.G.2.2, end dist:" & OK & StriSt(0))
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'e

    Sub StGeomCil(ByRef iB As Short)
        Dim ifl, i As Short
        Dim iSt1, ik, iSt2 As Short
        Try
            Dim StriSt(27) As String
            ifl = FreeFile()
20240:      FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR06.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 0 To 27 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), GAMMA))
20250:      If SW = 0 Then GoTo 20300
20260:      Monitor.Motore.Problem.Printa(" (extrapolation performed)" & StriSt(0))
20290:      If Geom(iB).Forma > 0 Then GoTo 20340 Else GoTo 20320
20300:      Monitor.Motore.Problem.Printa(StriSt(0))  '""
20310:      If Geom(iB).Forma > 0 Then GoTo 20340
20320:      Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(2), BETA))
20340:      Monitor.Motore.Problem.Printa(StriSt(0))
            For ik = 1 To 12
                iSt1 = (ik - 1) * 2 + 3 : iSt2 = iSt1 + 1
                Select Case ik
                    Case 9 : aaa0 = aaa(2) : bbb0 = bbb(2)
                    Case 10 : aaa0 = aaa(8) : bbb0 = bbb(8)
                    Case 11 : aaa0 = aaa(4) : bbb0 = bbb(4)
                    Case 12 : aaa0 = aaa(9) : bbb0 = bbb(9)
                    Case Else : aaa0 = aaa(ik - 1) : bbb0 = bbb(ik - 1)
                End Select
                Call PrRig(ik, iSt1, iSt2)
            Next
21550:      Monitor.Motore.Problem.Printa(StriSt(0))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'f
    Private Sub PrRig(ByVal ik As Short, ByVal iSt1 As Short, ByVal iSt2 As Short)
20350:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(iSt1), bbb0))
20370:  If SV(ik) = 1 Then GoTo 20400
20380:  Monitor.Motore.Problem.Print(Space(16))  '"                ";
20390:  GoTo 20430
20400:  Monitor.Motore.Problem.Print(" (used ")
20410:  Monitor.Motore.Problem.Print(globalRoutines.FormatS("###.###", aaa0))
20420:  Monitor.Motore.Problem.Print(") ")
20430:  Monitor.Motore.Problem.Print(StriSt(iSt2))  ' "=> FIG.3C   => Nè/(P/Rm)    =";
20440:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS("###.### &", KRead(ik), StriSt(0)))
    End Sub
    Sub StGeomCil0(ByRef iB As Short)
        Dim StriSt(19) As String
        Dim ifl, i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR07.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 19 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
19650:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), GAMMA))
19670:  If W = 0 Then GoTo 19720
19680:  Monitor.Motore.Problem.Print(" (used")
19690:  Monitor.Motore.Problem.Print(globalRoutines.FormatS("###.###", HHH))
19700:  Monitor.Motore.Problem.Printa(StriSt(2))  ' " to determine Kc,Cc,KL,CL Coeff.)";StriSt$(0)
19710:  GoTo 19740
19720:  Monitor.Motore.Problem.Printa(StriSt(0))  '""
19730:  Monitor.Motore.Problem.Printa(StriSt(0))
19740:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(3), BETA1))
19760:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(4), BETA2) & StriSt(0))
19780:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(5), BETA1 / BETA2))
19800:  If V = 0 Then GoTo 19850
19810:  Monitor.Motore.Problem.Print(" (used")
19820:  Monitor.Motore.Problem.Print(globalRoutines.FormatS("###.###", KKK))
19830:  Monitor.Motore.Problem.Printa(StriSt(2) & StriSt(0))  ' " to determine Kc,Cc,KL,CL Coeff.)";StriSt$(0)
19840:  GoTo 19860
19850:  Monitor.Motore.Problem.Printa(StriSt(0))  '""
19860:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(6), BETA2 / BETA1))
19880:  If V = 0 Then GoTo 19930
19890:  Monitor.Motore.Problem.Print(" (used")
19900:  Monitor.Motore.Problem.Print(globalRoutines.FormatS("###.###", 1 / KKK))  'ERRORE
19910:  Monitor.Motore.Problem.Printa(StriSt(2) & StriSt(0))  '" to determine Kc,Cc,KL,CL Coeff.)"
19920:  GoTo 19940
19930:  Monitor.Motore.Problem.Printa(StriSt(0))  '""
19940:  Monitor.Motore.Problem.Printa(StriSt(0))
19950:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(7), EEE, E1))
19970:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(8), EEE, E5))
        Monitor.Motore.Problem.Printa(StriSt(0))
19990:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(9), EEE, E2))
20010:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(10), EEE, E6))
20030:  Monitor.Motore.Problem.Printa(StriSt(0))
20040:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(11), KKK3))
20060:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(12), K7))
        Monitor.Motore.Problem.Printa(StriSt(0))
20080:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(13), C1))
20100:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(14), C3))
20120:  Monitor.Motore.Problem.Printa(StriSt(0))
20130:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(15), K4))
20150:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(16), K8))
        Monitor.Motore.Problem.Printa(StriSt(0))
20170:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(17), C2))
20190:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(18), C4))
20210:  Monitor.Motore.Problem.Printa(StriSt(0))
    End Sub 'g

    Sub StGeomCil1(ByRef iB As Short)
        Dim StriSt(4) As String
        Dim Stringa2(12) As String
        Dim ifl As Short
        Dim i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR08.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 12 : Stringa2(i) = LineInput(ifl) : Next
        For i = 0 To 4 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        '     Stringa2$(1) = " Mr/P       = ": Stringa2$(2) = " Mr(d/Mc)   = ": Stringa2$(3) = " Mr(d/Ml)   = "
        '     Stringa2$(4) = " Nr(T/P)    = ": Stringa2$(5) = " Nr(Tùd/Mc) = ": Stringa2$(6) = " Nr(Tùd/Ml) = "
        '     Stringa2$(7) = " Mé/P       = ": Stringa2$(8) = " Mé(d/Mc)   = ": Stringa2$(9) = " Mé(d/Ml)   = "
        '     Stringa2$(10) = " Né(T/P)    = ": Stringa2$(11) = " Né(Tùd/Mc) = ": Stringa2$(12) = " Né(Tùd/Ml) = "
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), GAMMA))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), GG))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(3), U))
        Monitor.Motore.Problem.Printa(StriSt(0))
        For i = 1 To 12
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(4), Stringa2(i), KRead(i)))
        Next
    End Sub 'h

    Sub StGeomCilG(ByRef iB As Short)
        Dim StriSt(12) As String
        Dim Stringa2(24) As String
        Dim ifl As Short
        Dim i As Short
        Dim c As String = ""
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR09.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 24 : Stringa2(i) = LineInput(ifl) : Next
        For i = 0 To 12 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        '      Stringa2$(1) = " Mí/W             = ": Stringa2$(2) = " Mx/W             = ": Stringa2$(3) = " Ní(t/W)          = ": Stringa2$(4) = " Nx(t/W)          = "
        '      Stringa2$(5) = " Mí/(1,5Mc/2Cí)   = ": Stringa2$(6) = " Mx/(1,5Mc/2Cí)   = ": Stringa2$(7) = " Ní(t/(1,5Mc/2Cí))= ": Stringa2$(8) = " Nx(t/(1,5Mc/2Cí))= "
        '      Stringa2$(9) = " Mí/(1,5Ml/2Cx)   = ": Stringa2$(10) = " Mx/(1,5Ml/2Cx)   = ": Stringa2$(11) = " Ní(t/(1,5Ml/2Cx))= ": Stringa2$(12) = " Nx(t/(1,5Ml/2Cx))= "
        '      Stringa2$(13) = "                  = ": Stringa2$(14) = "                  = ": Stringa2$(15) = "                  = ": Stringa2$(16) = "                  = "
        '      Stringa2$(17) = "  Mí2/........    = ": Stringa2$(18) = "  Mx2/........    = ": Stringa2$(19) = "  Ní2.........    = ": Stringa2$(20) = "  Nx2.........    = "
        '      Stringa2$(21) = "  Mí2/........    = ": Stringa2$(22) = "  Mx2/........    = ": Stringa2$(23) = "  Ní2.........    = ": Stringa2$(24) = "  Nx2.........    = "
        If Config.UnitSis = 2 Then
            Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), BETA1, BETA2))
        Else
            Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(2), BETA1, BETA2))
        End If
        If ShellNoz = 1 Then
            Monitor.Motore.Problem.Printa(" (0.85 the mean nozzle radius)" & StriSt(0))
        Else
            Monitor.Motore.Problem.Printa(" (0.85 the pad radius)" & StriSt(0))
        End If
        If Config.UnitSis = 2 Then
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(3), BETA, GAMMA))
        Else
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(4), BETA, GAMMA))
        End If
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(5), HHH, KKK))
        If ShellNoz = 1 Then
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(6), RHO354, dsD, trsTr))
        End If
        Monitor.Motore.Problem.Printa(StriSt(7))  ' "Results obtained from fig G.2(5) to (16):"
        For i = 1 To 4 : Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(8), Stringa2(i), KRead(i))) : Next
        For i = 5 To 8
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(9), Stringa2(i), KRead(i), Stringa2(i + 12), HRead(i)))
        Next
        For i = 9 To 12
            If Geom(iB).Cyld = 0 Then SopraSotto(i - 8) = 0
            Select Case SopraSotto(i - 8)
                Case -1 : c = "-"
                Case 1 : c = "+"
                Case 0 : c = "0"
            End Select
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(10), Stringa2(i), KRead(i), Stringa2(i + 12), HRead(i), c))
        Next
        If ShellNoz = 1 Then
            Monitor.Motore.Problem.Printa(StriSt(11))  'TAB(9); "Results obtained from fig 3.5.4(3) & (4):"
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(12), CTrsT))
        End If
    End Sub 'i

    Sub StGeomRigG(ByRef iB As Short)
        Dim StriSt(3) As String
        Dim Stringa2(4) As String
        Dim ifl As Short
        Dim i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR10.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 4 : Stringa2(i) = LineInput(ifl) : Next
        For i = 0 To 3 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        '     Stringa2$(2) = " Mí/W             = "
        '     Stringa2$(1) = " Mx/W             = "
        '     Stringa2$(4) = " Ní(t/W)          = "
        '     Stringa2$(3) = " Nx(t/W)          = "
        Monitor.Motore.Problem.Printa(StriSt(0))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), GAMMA))
        Monitor.Motore.Problem.Printa(StriSt(0))
        Monitor.Motore.Problem.Printa(StriSt(2))  '; "Results obtained from fig G.2(25):"
        For i = 1 To 4
            Monitor.Motore.Problem.Print(Stringa2(i))
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(3), KRead(i)))
        Next
    End Sub

    Sub StGeomSfe(ByRef iB As Short)
        Dim StriSt(21) As String
        Dim ifl, i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR11.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 21 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
59660:  If Geom(iB).Forma > 0 Then GoTo 59690
59670:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(1), U))
59680:  GoTo 59710
59690:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(2), U))  ' "    U = c1/(0.875û[Rm*T]) = ";
59710:  If SV(1) = 0 Then GoTo 59750
        Monitor.Motore.Problem.Printa(" (extrapolation performed)" & StriSt(0))
59750:  Monitor.Motore.Problem.Printa(StriSt(0))  '""
59760:  If Geom(iB).Buco > 0 Then GoTo 60070
59770:  If Geom(iB).Forma > 0 Then GoTo 59800
59780:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(3), GAMMA))  ' "    ç = (rm/t)            = ";
59790:  GoTo 59820
59800:  Monitor.Motore.Problem.Print(globalRoutines.FormatS(StriSt(4), GAMMA))  '"    ç = c1/0.875t         = ";
59820:  If SW = 0 Then GoTo 59860
59830:  Monitor.Motore.Problem.Print(" (used ")
59840:  Monitor.Motore.Problem.Print(globalRoutines.FormatS("##.####", GG))
59850:  Monitor.Motore.Problem.Print(" to enter curves)")
59860:  Monitor.Motore.Problem.Printa(StriSt(0))
59870:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(5), RHO))  '"    p = (T/t)             = ";
59880:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS("##.####", RHO))
59890:  Monitor.Motore.Problem.Printa(StriSt(0))
59900:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(6), KRead(7)))
59920:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(7), KRead(8)))
59940:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(8), KRead(3)))
59960:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(9), KRead(4)))
59980:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(10), KRead(1)))
60000:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(11), KRead(2)))
60020:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(12), KRead(9)))
60040:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(13), KRead(10)))
60060:  GoTo 60240
60070:  Monitor.Motore.Problem.Printa(StriSt(0))
60080:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(14), KRead(7)))
60100:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(15), KRead(8)))
60120:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(16), KRead(3)))
60140:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(17), KRead(4)))
60160:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(18), KRead(1)))
60180:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(19), KRead(2)))
60200:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(20), KRead(7)))
60220:  Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(21), KRead(10)))
60240:  Monitor.Motore.Problem.Printa(StriSt(0))
    End Sub 'j

    Sub StGeomSfeG(ByRef iB As Short)
        Dim StriSt(4) As String
        Dim ifl, i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR12.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 4 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), dsD, trsTr))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), GAMMA))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(3), KRead(1), KRead(2)))
        Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(4), KRead(3), KRead(4)))
    End Sub

    Sub StSfeG(ByRef iB As Short, ByRef iC As Short)
        Try
            Dim StriSt(2) As String
            Dim n(4) As String
            Dim ifl As Short
            Dim i As Short
            Dim k, a As String
            ifl = FreeFile()
            FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR13.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 4 : n(i) = LineInput(ifl) : Next
            k = LineInput(ifl)
            For i = 0 To 2 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            '     N$(1) = "    å bending [press.] "
            '     N$(2) = "    å bending      [P] "
            '     N$(3) = "    å bending      [M] "
            '     N$(4) = "    å bending      [V] "
            '     k$ = "  4. STRESS INTENSITIES"
            Monitor.Motore.Problem.Printa(New String(" ", 5) & k)
            For i = 1 To 4 Step 2
                Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), n(i), KRead(i + 4), n(i + 1), KRead(i + 4 + 1)))
            Next
            a = "<" : If Result(ShellNoz, iC, iB).Sq > StressLim(iC, iB).ASQ(ShellNoz) Then a = ">"
            Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), sConverti(Result(ShellNoz, iC, iB).Sq, 5), a, sConverti(StressLim(iC, iB).ASQ(ShellNoz), 5), Config.Unit(6)))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub Testata(ByRef iB1 As Short, ByRef iC As Short)
        Try
            Dim ifl, i As Short
            Call Testa1(iB1)
19001:      Dim StriSt(2) As String
            iB = System.Math.Abs(iB1)
            ifl = FreeFile()
            FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR14.WRC", OpenMode.Input, , OpenShare.Shared)
            For i = 0 To 2 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
19020:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(1), Geom(iB).ShellMat, Geom(iB).Mark))
19050:      Monitor.Motore.Problem.Printa(globalRoutines.FormatS(StriSt(2), Geom(iB).Carichi(iC).CaseDescription, Geom(iB).Size))
19110:      Monitor.Motore.Problem.Printa(StriSt(0))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'l

    Sub Titolo(ByRef iB As Short)
        Dim StriSt(3) As String
        Dim ifl, i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\RTF\STWR15.WRC", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 3 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        If (Geom(iB).ShellType = 0 And Config.WRC297 = 2 And Geom(iB).Forma = 0) Or (Geom(iB).ShellType = 1 And Config.WRC297 = 4 And Geom(iB).Buco = 1) Then
            Monitor.Motore.Problem.Printa(StriSt(1))  ' "  0øo    0øi  180øo  180øi   90øo   90øi  270øo  270øi"
        ElseIf Config.WRC297 >= 3 And Config.ConvSumm = 2 Then
            Monitor.Motore.Problem.Printa(StriSt(2))  ' "  Q1out  Q1in   Q2out  Q2in   Q3out  Q3in   Q4out  Q4in"
        Else
21650:      Monitor.Motore.Problem.Printa(StriSt(3))  ' TAB(29); "Au"; TAB(36); "AL"; TAB(43); "Bu"; TAB(50); "BL";
        End If
    End Sub 'm
End Module