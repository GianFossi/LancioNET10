Option Strict Off
Option Explicit On
Module OperFin
	Private Num(14) As Short
	Private NROWS, nRowsN As Short
	Private Risp(20) As String
	Private Dom(20) As String
	Private Archiv(20) As Short
	Private X As Short
    'Private Stac As Alternative
    Private Stac(5) As Integer
	Private nStac, icdum As Short
	Private nAst, nAst1, iC As Short
	Private LungSt(20) As Short
	Sub OpFin()
        On Error GoTo ErrOpFin
		Dim Riga As String
        Dim x1, code, n As Short
		Dim i As Short
		Dim Tit As String
		Dim dAiu(20) As String
		Dim iF3 As Short
        IO.File.Delete("TEGE" & job.Contratto.Trim)
        IO.File.Delete("TENB" & job.Contratto.Trim)
Rifai2:
        IO.File.Delete(at1(22) & job.Contratto.Trim)
        HTR10(NROWS, Stac)
        iF3 = FreeFile
1410:   FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        iC = 0 : icdum = 0
        Do
            Riga = LineInput(iF3)
            iC = iC + 1
            If Left(Riga, 1) = ">" Then
                Dom(iC) = Riga
                Risp(iC) = Space(0)
                icdum = iC
            Else
                Dom(iC) = Mid(Riga, 7, 24)
                code = Val(Mid(Riga, 31, 2))
                Archiv(iC) = Val(Mid(Riga, 35, 2))
                x1 = Val(Mid(Riga, 39, 2))
                If x1 > 0 Then X = x1 - 1
                If code <> 8 Then Archiv(iC) = 0
                n = Val(Mid(Riga, 41, 2))
                Riga = Riga & Space(n)
                Risp(iC) = Mid(Riga, 43, n)
                If Archiv(iC) > 0 Then
                    If x1 = 0 Then X = 1
                    If X = 1 Then Risp(iC) = "NO".PadRight(n)
                End If
                Num(iC) = Val(Left(Riga, 4))
                If iC - icdum = 4 Or iC - icdum = 5 Then Archiv(iC) = 29
            End If
            If EOF(iF3) Then Exit Do
        Loop
        FileClose(iF3)
        For i = 1 To iC
            If Num(i) = 28 Then dAiu(i) = "*"
        Next
        For i = 1 To iC : LungSt(i) = -Len(Risp(i)) : Next i
        For i = 7 To 9 : LungSt(i + icdum) = -LungSt(i + icdum) : Next
        For i = 1 To icdum + 1 : LungSt(i) = -LungSt(i) : Next
        If Len(LTrim(RTrim(Risp(4 + icdum)))) = 0 Then Risp(4 + icdum) = "NO"
        If Len(LTrim(RTrim(Risp(5 + icdum)))) = 0 Then Risp(5 + icdum) = "NO"
        Kill(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        nAst = InStr(Risp(icdum + 3), "*")
        Tit = "Dati finali" 'at1(45) ' "Dati finali"
        FaseDati = 7
        Apert.Enabled = False
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(1, iC, Tit, Dom, Risp, "", Archiv, dAiu)
        Monitor.Motore.InputForms(1 - 1).Top = 40
        Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
        OkOpFin1()
        'Do
        'Select Case y
        '    Case -3
        '       '        Help$ = "Help non disponibile"
        '               junk = Alert(4, at1(23), 4, 3, 10, 58, at1(34), Space$(0), Space$(0))
        '    Case -2
        '               WindowClose 2:  Exit Sub
        '    Case -1
        '               WindowClose 2: Exit Do
        '    Case Else
        '            If Archiv(y) > 0 Then
        '                Risp$(y) = Adjust(ReadArch$(Archiv(y), x), Abs(LungSt(y)))
        '             ElseIf Num(y) = 28 Then ' (No. stacks)
        '                 NoStacks
        '       Else
        '               Help$ = at1(23) ' "Help non disponibile"
        '               junk = Alert(4, Help$, 4, 3, 10, 58, at1(34), Space$(0), Space$(0))
        '       End If
        'End Select
        'y = InputDati(0, ic, Tit$, Dom$(), Risp$(), LungSt())
        'Loop
        Exit Sub
ErrOpFin:
        If Err.Number = 53 Then Resume Next
        Debug.Print("Errore in OpFin" & Err.Number & Erl()) : Stop
        Resume
    End Sub


    Public Sub NoStacks(ByRef y As Short)
        Dim Dom1(5) As String
        Dim Risp1(5) As String
        Dim Archiv(5) As Short
        Dim dAiu(5) As String
        Dim Tit As String
        Dim y1 As Boolean
        Dim j As Short
        Dim Help As String
        If Num(y) = 28 Then
            With Monitor.Motore.InputForms(1 - 1)
                Risp1(2) = Str(Val(.prisposte(y)))
                Risp1(1) = Space(0)
                Dom1(2) = Dom(y)
                Dom1(1) = "N° file totali:" & Str(NROWS) '"N. file totali:"
                For j = 1 To 3
                    Dom1(j + 2) = "Sezione n°" & Str(j) ' "Sezione nø"
                    Risp1(j + 2) = Str(Stac(j))
                Next j
                ' For j = 1 To 5: Lung(j) = Len(Risp1$(j)): Next j
                Tit = "Sezione stack" 'at1(30) '
                Help = Monitor.Motore.Inizio.ConvertiCr("Fornire il numero di file    |per stack, partendo da sopra.|")
rifa1:
                Monitor.Motore.Chiamante = Monitor
                y1 = Monitor.Motore.InputDati(5, Tit, Dom1, Risp1, Help, Archiv, dAiu)
                '                   Do
                '                   Select Case y1
                '                      Case -3
                '                        Help$ = at1(31) ' "Fornire il numero di file    |"
                '         '       Help$ = Help$ + "per stack, partendo da sopra.|"
                '               junk = Alert(4, Help$, 4, 3, 10, 58, at1(34), Space$(0), Space$(0))
                '                      Case -2
                '               WindowClose 3:  Exit Do
                '                      Case -1
                '               WindowClose 3: Exit Do
                '                      Case Else
                '                   End Select
                '                   y1 = InputDati(0, 5, Tit$, Dom1$(), Risp1$(), Lung())
                '                   Loop
                nStac = 0 : nRowsN = 0
                For j = 1 To 3
                    Stac(j) = Val(Risp1(j + 2))
                    If Stac(j) > 0 Then nStac = nStac + 1
                    nRowsN = nRowsN + Stac(j)
                Next j
                .prisposte(y) = Risp1(2)
                If nStac > 0 And (NROWS <> nRowsN Or nStac <> Val(Risp(y))) Then
                    Help = Monitor.Motore.Inizio.ConvertiCr(at1(32)) ' "Dati forniti in modo   |"
                    '    Help$ = Help$ + "inammissibile!         |"
                    MsgBox(Help, MsgBoxStyle.Critical)
                    GoTo rifa1
                End If
            End With
        End If
    End Sub

    Public Sub OkOpFin2()
        Dim iF3, i, j As Short
        Dim Tit, NewF As String
        Dim y As Boolean
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Dim Testo As String
        Dim iFin As Short
        iFin = 1
        If Left(Monitor.Motore.InputForms(1 - 1).ComboFisso(3 + icdum).Text, 2) = "YE" Then
            iF3 = FreeFile()
            FileOpen(iF3, "TEGE" & RTrim(job.Contratto), OpenMode.Output)
            iFin = iFin + 1
            For j = 1 To 4
                PrintLine(iF3, CStr(Monitor.Motore.InputForms(iFin - 1).prisposte(j)).PadRight(64))
            Next j
            FileClose(iF3)
        End If
        If Left(Monitor.Motore.InputForms(1 - 1).ComboFisso(4 + icdum).Text, 2) = "YE" Then
            iF3 = FreeFile()
            FileOpen(iF3, "TENB" & job.Contratto.Trim, OpenMode.Output)
            iFin = iFin + 1
            For j = 1 To 4
                PrintLine(iF3, CStr(Monitor.Motore.InputForms(iFin - 1).prisposte(j)).PadRight(64))
            Next j
            FileClose(iF3)
        End If
        HTR10B()
Uscita:
        '  Testo = Globalroutines.mystr(CSng(Nrdit \ 2), 2, 0, True)
        '  If Left$(Testo, 1) = Space$(1) Then Testo = Chr$(48) + Right$(Testo, 1)
        'NewF = Monitor.Motore.Inizio.Workdir + Chr$(92) + Left$(job.contratto, 4) + Testo + ".VEN"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objVentil.Riscrivi. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objVentil.Riscrivi(NewF, Nrdit, Left(job.contratto, 4))
    End Sub
    Public Sub OkOpFin1()
        Dim iF3, i, j As Short
        Dim Tit, NewF As String
        Dim y As Boolean
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Dim Testo As String
        Dim iFin As Short
        iF3 = FreeFile
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        With Monitor.Motore.InputForms(1 - 1)
            For i = 1 To iC
                Risp(i) = .prisposte(i)
            Next
            nAst1 = InStr(Risp(icdum + 3), "*")
            If nAst <> nAst1 Then
                Stop
                If nAst1 = 0 Then Risp(icdum + 3) = RTrim(Risp(icdum + 3)) & "*"
                If nAst = 0 Then Mid(Risp(icdum + 3), nAst1, 1) = Space(1)
            End If
            For i = icdum + 1 To iC
                If Len(Risp(i)) > 0 Then
                    If Archiv(i) > 0 And Not (i = 4 Or i = 5) Then
                        If X = 0 Then
                            '       a$ = "Dati non corretti!       |"
                            '  a$ = a$ + " Usare il mouse          |"
                            MsgBox(at1(33))
                            Stop
                            '    GoTo Rifai2
                        End If
                        Risp(i) = Str(X + 1)
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Adjust(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Risp(i) = Risp(i).PadRight(System.Math.Abs(LungSt(i)))
                    PrintLine(iF3, Risp(i))
                End If
            Next i
            FileClose(iF3)
        End With
        HTR10A(Stac)
        iFin = 1
        If IO.File.Exists("TEGE" & job.Contratto.Trim) Then
            FileOpen(iF3, "TEGE" & job.Contratto.Trim, OpenMode.Input)
            For j = 1 To 4
                Risp(j) = LineInput(iF3)
                Dom(j) = Space(0)
                LungSt(j) = Len(Risp(j))
            Next j
            FileClose(iF3)
            Kill("TEGE" & RTrim(job.Contratto))
            Tit = "Note Generali" ' at1(48) ' "Note"
            iFin = iFin + 1
            Monitor.Motore.Chiamante = Monitor
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDatiM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.InputDatiM(iFin, 4, Tit, Dom, Risp, at1(23), Archiv, dAiu)
        End If
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir("TENB" & RTrim(job.contratto))) > 0 Then
            FileOpen(iF3, "TENB" & RTrim(job.contratto), OpenMode.Input)
            For j = 1 To 4
                Risp(j) = LineInput(iF3)
                Dom(j) = Space(0)
                LungSt(j) = Len(Risp(j))
            Next j
            FileClose(iF3)
            Kill("TENB" & RTrim(job.contratto))
            Tit = "Note Bocchelli" ' at1(48) ' "Note"
            iFin = iFin + 1
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.Chiamante = Monitor
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDatiM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.InputDatiM(iFin, 4, Tit, Dom, Risp, at1(23), Archiv, dAiu)
        End If
    End Sub
	Public Sub NoteSiNo()
		Dim NoteSI, BoccSi As String
		Dim i As Short
		With Monitor.Motore
			For i = .InputForms.Count To 2 Step -1
                .InputForms(i - 1).close()
                .InputForms.Remove(i - 1)
                .InputForms(i - 1 - 1).Command1(0).Visible = True
                .InputForms(i - 1 - 1).Command1(1).Visible = True
            Next
		End With
		OkOpFin1()
	End Sub
End Module