Option Strict Off
Option Explicit On
Module modSetti
	Private iMat, iDisp, nmat As Short
    Private Materiale As LibMat.MaterialeNew1 = New LibMat.MaterialeNew1
	Private indice As Short
    '==========================BuildStructHeader==========================
    Private FileDum(16) As Single
    Private NumFile As Single
    Private i, j As Short
    Private Occupato As Single
    Private Continua As Boolean
    Private nf As Short
    Private Newfract As Single
    Private jj, iSpec, k, kk As Short
    Private kkk As Short
    '================================DisSetti================================
    Private AlungTest, PVERT, AaltzTest As Single
    Private Ingresso, iHeader As Short
    Private iSetti, iSettiH As Short
    Private Text As String
    Private xis, xfs, xii, xfi As Single
    Private yRif As Single
    Private j1 As Short
    '======================================================================
    Function iAccanto(ByRef iIniz As Short, ByRef iFine As Short) As Short
        Dim kSup, j, ii As Short
        iIniz = 1 : iFine = 16
        For j = 1 To MecData(0).NS + 1
            kSup = kSup + System.Math.Abs(MecData(0).Nfile(j))
        Next
        iFine = kSup
        ii = iSuperiore(iCassa)
        If ii > 0 Then
            FileGet(33, MecData(1), ii)
            For j = 1 To MecData(1).NS + 1
                kSup = kSup + System.Math.Abs(MecData(1).Nfile(j))
            Next
            iIniz = kSup + 1
        End If
        If TipoFas = 0 Then
            iAccanto = 0
        ElseIf TipoFas = 1 Then
            iAccanto = 1 : If iCassa = 1 Then iAccanto = 2
        ElseIf TipoFas = 2 Then
            If iCassa < 3 Then
                iAccanto = 3
            Else
                iAccanto = 12
            End If
        ElseIf TipoFas = 3 Then
            If iCassa > 1 Then
                iAccanto = 1
            Else
                iAccanto = 23
            End If
        Else
            If iCassa < 3 Then
                iAccanto = 12
            Else
                iAccanto = 24
            End If
        End If
    End Function

    Function iSuperiore(ByRef iCassa As Short) As Short
        If TipoFas < 2 Then
            iSuperiore = 0
        ElseIf TipoFas = 2 And iCassa = 2 Then
            iSuperiore = 1
        ElseIf TipoFas = 3 And iCassa = 3 Then
            iSuperiore = 2
        ElseIf TipoFas = 4 And (iCassa = 2 Or iCassa = 4) Then
            iSuperiore = iCassa - 1
        Else
            iSuperiore = 0
        End If
    End Function

    Sub SettiVuoti(ByRef iCassa As Integer)
        Dim iFine, iIniz, iAcc As Short
        Dim ii, i, j, kSup As Short
        Dim ifl, k As Short
        Dim H, HX3 As Single
        Dim Cambio As Boolean
        Dim Testo As String
        SETPUT(iCassa)
        ifl = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
        If TipoFas = 0 Then
            FilePut(ifl, MecData(0), 1)
            FileClose(ifl)
            Exit Sub
        End If
        'FileGet(33, MecData(0), iCassa)
        iAcc = iAccanto(iIniz, iFine)
        For i = 1 To nCasse(TipoFas)
            Cambio = False
            If i <> iCassa Then
                ii = iSuperiore(i) : kSup = 0
                If ii > 0 Then
                    '   FileGet(33, MecData(1), ii)
                    For j = 1 To MecData(ii).NS + 1
                        kSup = kSup + System.Math.Abs(MecData(ii).Nfile(j))
                    Next
                End If
                With MecData(i)
                    '    FileGet(33, MecData(1), i)
                    If i = iAcc Or i = (iAcc Mod 10) Or i = iAcc \ 10 Then
                        '  PRINT "Pacc"; iIniz; iFine; "i,iAcc;iCassa"; i; iAcc; iCassa
                        For j = iIniz To iFine
                            .Pacc(j - 1) = .Passo(j - 1)
                            '    PRINT j; MecData(1).Pacc(j);
                        Next j
                        '  PRINT : u$ = INPUT$(1)
                    End If
                    For j = 1 To 16
                        If .Passo(j - 1) < MecData(iCassa).Passo(j - 1) Then .Passo(j - 1) = MecData(iCassa).Passo(j - 1)
                    Next j
                    'MecData(1).HX3 = 0!
                    HX3 = 0
                    If .Nfile(1 - 1) > 0 Then
                        If .NS = 0 Then
                            H = 0
                            For k = 1 To System.Math.Abs(.Nfile(1 - 1)) - 1
                                H = H + .Passo(kSup + k - 1)
                            Next k
                            H = H + .xx + .VUOTO(1 - 1) / 2
                            H = H + .xx + .VUOTO(2 - 1) / 2
                            H = Int(2 * H) / 2.0#
                            kSup = kSup + System.Math.Abs(.Nfile(1))
                            If H > .HX5(1 - 1) And .HX5(1 - 1) > 0 Then Cambio = True : .HX5(1 - 1) = H
                            HX3 = .HX5(1 - 1)
                        Else
                            For j = 1 To .NS + 1
                                H = 0
                                Select Case j
                                    Case 1
                                        For k = 1 To System.Math.Abs(.Nfile(j - 1)) - 1
                                            H = H + .Passo(kSup + k - 1)
                                        Next k
                                        If System.Math.Abs(.Nfile(j - 1)) > 0 Then
                                            H = H + .Passo(kSup - 1 + System.Math.Abs(.Nfile(j - 1))) / 2
                                        End If
                                        H = H + .xx + .VUOTO(1 - 1) / 2
                                    Case .NS + 1
                                        For k = 2 To System.Math.Abs(.Nfile(j - 1))
                                            H = H + .Passo(kSup + k - 1)
                                        Next k
                                        H = H + .Passo(kSup + 1) / 2
                                        H = H + (.VUOTO(j - 1)) / 2 + .xx
                                    Case Else
                                        For k = 2 To System.Math.Abs(.Nfile(j - 1)) - 1
                                            H = H + .Passo(kSup + k - 1)
                                        Next k
                                        H = H + .Passo(kSup - 1 + System.Math.Abs(.Nfile(j))) / 2
                                        H = H + .Passo(kSup + 1 - 1) / 2
                                        H = H + (.VUOTO(j - 1 - 1) + .VUOTO(j - 1)) / 2
                                End Select
                                kSup = kSup + System.Math.Abs(.Nfile(j - 1))
                                H = Int(2 * H) / 2.0#
                                If H > .HX5(j - 1) And .HX5(j - 1) > 0 Then Cambio = True : .HX5(j - 1) = H
                                HX3 = HX3 + .HX5(j - 1)
                            Next j
                        End If
                        If HX3 > .HX3 Then Cambio = True : .HX3 = HX3
                    End If
                End With
                FilePut(ifl, MecData(i), i)
            End If
            If Cambio Then
                Testo = "Le altezze delle camere della cassa" & Str(i) & vbCrLf
                Testo = Testo & "sono state aumentate per congruenza" & vbCrLf
                Testo = Testo & "con la cassa opposta." & vbCrLf
                Testo = Testo & "Di conseguenza il calcolo meccanico" & vbCrLf
                Testo = Testo & "dovrà essere ripassato."
                MsgBox(Testo, MsgBoxStyle.Information, "ISA")
            End If
        Next i
        If iCassa = 0 Then FilePut(ifl, MecData(0), 1)
        FileClose(ifl)
    End Sub

    Function Assumi(ByRef i As Short, ByRef j As Short) As String
        Dim Riga, Cod As String
        Do
            Riga = LineInput(i)
            If Len(Riga) < 3 Or EOF(i) Then Assumi = "" : Exit Do
            Riga = RTrim(Riga)
            Cod = Right(Riga, 3)
            Riga = Left(Riga, Len(Riga) - 3)
            If Left(Cod, 1) = "A" Then
                PrintLine(j, Riga)
            Else
                Assumi = Riga
                Exit Do
            End If
        Loop
    End Function

    Function Cercaist(ByRef Ext As String) As Integer
        'Dim NewF As String, ist As Integer, ist1 As Integer
        '925 NewF$ = Monitor.Motore.Inizio.Workdir + "\SALV*." + Ext$
        '   NewF$ = Dir$(NewF$)
        '   If Len(NewF$) > 0 Then
        '   ist = Val(Mid$(NewF$, 5, 2))
        '   Do
        '     NewF$ = Dir$
        '     If Len(NewF$) = 0 Then Exit Do
        '     ist1 = Val(Mid$(NewF$, 5, 2))
        '     If ist1 > ist Then ist = ist1
        '   Loop
        '   If ist >= 99 Then
        '   NewF$ = Monitor.Motore.Inizio.Workdir + "\SALV*." + Ext$
        '   NewF$ = Dir$(NewF$)
        '      Do
        '         Kill Monitor.Motore.Inizio.Workdir + "\" + NewF$
        '         NewF$ = Dir$
        '         If Len(NewF$) = 0 Then Exit Do
        '      Loop
        '      ist = 0
        '   End If
        '   Else
        '   ist = 0
        '   End If
        'Cercaist = ist
    End Function
    Function Inq(ByRef Tit As String, Optional ByRef nFin As Short = 0, Optional ByRef Help As String = "") As Boolean
        Dim ifl, i As Short
        Dim f As String
        Dim ij, iF1 As Short
        Dim Archiv(20) As Short
        Dim dAiu(20) As String
        'On Local Error GoTo ErrInq
        Inq = True
        ifl = FreeFile
908:    FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto & ".TXT", OpenMode.Input)
        i = 1
        Do
            Dom(i) = LineInput(ifl)
            Risp(i) = LineInput(ifl)
            If Len(Risp(i)) = 0 Then Risp(i) = Space(18)
            If Asc(Risp(i)) < 32 Then Risp(i) = Space(18)
            If Right(Risp(i), 1) = "." Then Risp(i) = Left(Risp(i), Len(Risp(i)) - 1)
            If Left(Risp(i), 1) = "*" Then
                Risp(i) = Right(Risp(i), Len(Risp(i)) - 1)
                Tipo(nFin, i) = True
            Else
                Tipo(nFin, i) = False
            End If
            If EOF(ifl) Then Exit Do
            i = i + 1
        Loop
        FileClose(ifl) : IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & job.Contratto & ".TXT")
        'For j = 1 To i: LungSt(j) = Len(Risp$(j)): Next
        ii = i : If Tit = "tubi" Then ii = i - 2
        If Len(Tit) = 0 Then GoTo NoW_Renamed
        If Tit = "Dati meccanici" Then 'Trim(at2(57))
            If iTest = 3 Or iTest = 4 Then iDisp = 1 Else iDisp = 0
            'If Len(Trim(FileMec)) > 0 Then
            ' f = FileMec
            'Else
            'f = CStr(Monitor.Motore.Inizio.Workdir + "\SALV00.MEC")
            'End If
            '            ifl = FreeFile
            '910:        FileOpen(ifl, f, OpenMode.Random, , , Len(MecData(0)))
            '           If iCassa = 0 Then
            'FileGet(ifl, MecData(0), 1)
            If MecData(iCassa).MATHOM = 2 Then nmat = 3 Else nmat = 1
            'Else
            '   FileGet(ifl, MecData(1), iCassa)
            '  If MecData(1).MATHOM = 2 Then nmat = 3 Else nmat = 1
            'End If
            'FileClose(ifl)
            For ij = 1 To nmat
                dAiu(5 + iDisp + ij - 1) = "*"
            Next
            If iTest < 3 Then
                iMat = 5 + iDisp + 2 * nmat + 1
                If iMat < i Then
                    If Not Left(LTrim(Dom(iMat)), 2) = "SI" Then iMat = 0
                Else
                    iMat = 0
                End If
            Else
                iMat = 0
            End If
            If iMat > 0 Then dAiu(iMat) = "*"
        ElseIf Tit = "Dati generali" Then  ' Trim(at2(52))dati gen. in modalità standalone
        ElseIf InStr(Tit, "Item") > 0 Then  'datiitem
            If nFin > 0 Then
                ifl = FreeFile()
                FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
                Archiv(ii) = 1000
                iF1 = FreeFile()
                FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1000.DAT", OpenMode.Output)
                PrintLine(iF1, "  25   0   0   0")
                Dim Tipoloc As Integer
                Select Case nCasseloc
                    Case 1 : Tipoloc = 0
                    Case 2 : Tipoloc = 1
                    Case 3 : Tipoloc = 2
                    Case 4 : Tipoloc = 4
                End Select
                For i = 1 To nCasseloc
                    FileGet(ifl, MecData(i), i)
                    If MecData(i).HEADER.Trim = "" Then
                        MecData(i).HEADER = TipC(Tipoloc, i)
                        FilePut(ifl, MecData(i), i)
                    End If
                    PrintLine(iF1, MecData(i).HEADER)
                Next
                FileClose(iF1, ifl)
            End If
        End If
        Monitor.Motore.Chiamante = Monitor
        If nFin = 0 Then
            If Not Monitor.Motore.InputDati(ii, Tit, Dom, Risp, Help, Archiv, dAiu) Then
                Inq = False : Exit Function
            End If
        Else
            Monitor.Motore.InputDatiM(nFin, ii, Tit, Dom, Risp, Help, Archiv, dAiu)
            If nFin = 1 Then
                Apert.Enabled = False
                Monitor.Motore.InputForms(1 - 1).Top = 40
                Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
            End If
            Exit Function
        End If
NoW_Renamed: RegistraInq(ii, nFin)
    End Function
    Function MatTesLam(ByRef St As Single, ByRef T As Single, ByRef iC As Short, ByRef ij As Short, ByRef k As Short, ByRef oldMat As String) As String
        Dim i, ifl, j As Short
        Dim Tit As String
        Dim Stringa(17) As String
        Dim Help, A As String
        Dim Archiv(17) As Short
        Dim dAiu(17) As String
        Dim ii As Short
        If Apert._Option1_0.Checked Then
            ifl = FreeFile()
            FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM003.DAT"), OpenMode.Input, , OpenShare.Shared)
            Stringa(17) = LineInput(ifl)
            For i = 1 To 4
                For j = 1 To 4
                    Stringa((i - 1) * 4 + j) = Mid(Helpstringa(1149 - 1 + i), (j - 1) * 20 + 1, 20)
                Next j
            Next i
            'Stringa(17) = " Altro Materiale"
            'k = Monitor.Motore.Quale(17, Tit$, Stringa(), Help$, 1)
            For i = 1 To 16
                If Trim(Stringa(i)) = oldMat Then GoTo Cont
            Next
            i = 1
Cont:       Tit = "Libreria materiali ISA"
            k = Monitor.Motore.Quale(16, Tit, Stringa, Help, i)
            If k = 0 Then MatTesLam = "" : FileClose(ifl) : Exit Function
            Dim Dom1(2) As String
            Dim Risp1(2) As String
            Dim LungSt1(2) As Short
            If k < 17 And T <= 300 Then
                MatTesLam = Stringa(k)
                Stringa(1) = LineInput(ifl)
                Stringa(2) = LineInput(ifl)
                'Stringa(1) = "Ammissibili ISPESL"
                'Stringa(2) = "Ammissibili ASME"
                iC = Monitor.Motore.Quale(2, Left(Stringa(1), 12), Stringa, "", iC) '"Ammissibili"
                St = Stress(T, iC, k)
            Else
                'Dom1$(1) = "Mat. Testate        "
                Dom1(1) = LineInput(ifl)
                Select Case ij
                    Case 0
                        '   Dom1$(2) = "Soll. ammiss. [kg/mm2]"
                        Dom1(2) = LineInput(ifl)
                        A = LineInput(ifl)
                        A = LineInput(ifl)
                    Case 15
                        '   Dom1$(2) = "Soll. amm. Testate  "
                        Dom1(2) = LineInput(ifl)
                        Dom1(2) = LineInput(ifl)
                        A = LineInput(ifl)
                    Case 16
                        '   Dom1$(2) = "Soll. amm. lamiere  "
                        Dom1(2) = LineInput(ifl)
                        Dom1(2) = LineInput(ifl)
                        Dom1(2) = LineInput(ifl)
                End Select
                If k = 17 Then
                    Risp1(1) = Space(18)
                    '  Tit$ = "Nuovo materiale"
                    Tit = LineInput(ifl)
                    A = LineInput(ifl)
                Else
                    Risp1(1) = Stringa(k)
                    '  Tit$ = "Ammissibile (T>300)"
                    Tit = LineInput(ifl)
                    Tit = LineInput(ifl)
                End If
                Risp1(2) = GlobalRoutines.myStr(0.0!, 15, 2, False)
                For ii = 1 To 2 : LungSt1(ii) = Len(Risp1(ii)) : Next
                Monitor.Motore.Chiamante = Monitor
                Monitor.Motore.InputDati(2, Tit, Dom1, Risp1, "", Archiv, dAiu)
                MatTesLam = Risp1(1)
                St = Val(Risp1(2))
            End If
            FileClose(ifl)
        Else
Lancio:
            Materiale = New LibMat.MaterialeNew1
            If indice > 0 Then
                Materiale.Indmat = indice
                Materiale.RecupMat(Monitor.Motore.Inizio.Archdir)
            End If
            Materiale.Agganciato = True
            Materiale.Scelta(Materiale.Classe, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
            indice = Materiale.Indmat
            St = Stress(T, iC, k)
            MatTesLam = Materiale.MatStr
        End If
    End Function
    Sub Registra(ByRef NewF As String, ByRef iCassa As Integer, ByRef Cod As String)
        Dim i4, ist, i3 As Short
        Dim A As String
        Dim Riga As String
        Dim GoOn As Boolean
        On Error GoTo ErrRegis
        If iCassa = 0 Then
            'ist = Cercaist("VER") + 1
            'A$ = Globalroutines.Str2Cifre(ist) ', 2, 0, True)
            'If Left$(A$, 1) = Chr$(32) Then A$ = Chr$(48) + Right$(A$, 1)
            'NewF$ = Monitor.Motore.Inizio.Workdir + "\SALV" + A$ + ".VER"
            NewF = Left(FileMec, Len(FileMec) - 3) & "VER"
            i4 = FreeFile()
919:        FileOpen(i4, NewF, OpenMode.Output)
        Else
912:        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.Str2Cifre(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            A = GlobalRoutines.Str2Cifre(Nrdit \ 2) ', 2, 0, True)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewF = CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(Left(job.Contratto, 4)) + CDbl(A) + CDbl(".VER"))
            i4 = FreeFile()
914:        FileOpen(i4, NewF, OpenMode.Append)
        End If
        If LOF(i4) > 0 And Len(Cod) > 0 Then
            FileClose(i4)
2915:       FileOpen(i4, NewF, OpenMode.Input)
            i3 = FreeFile()
2916:       FileOpen(i3, "TEX1" & RTrim(job.Contratto), OpenMode.Output)
            Do
2917:           Riga = LineInput(i4)
                If Len(Riga) < 5 Then Riga = Riga.PadRight(5)
                If Left(Riga, 1) = "1" And Mid(Riga, 2, Len(Cod)) = Cod Then Exit Do
                PrintLine(i3, Riga)
                If EOF(i4) Then Exit Do
            Loop
            FileClose(i3)
2918:       FileOpen(i3, "TEX2" & RTrim(job.Contratto), OpenMode.Output)
            GoOn = False
            Do
                If EOF(i4) Then Exit Do
2919:           Riga = LineInput(i4)
                If Left(Riga, 1) = "1" Then GoOn = True
                If GoOn Then PrintLine(i3, Riga)
                If EOF(i4) Then Exit Do
            Loop
            FileClose(i3) : FileClose(i4)
2920:       FileOpen(i4, NewF, OpenMode.Output)
2921:       FileOpen(i3, "TEX1" & RTrim(job.Contratto), OpenMode.Input)
            Do
                If EOF(i3) Then Exit Do
                Riga = LineInput(i3)
                PrintLine(i4, Riga)
            Loop
            FileClose(i3)
        End If
        i3 = FreeFile()
915:    FileOpen(i3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        Do
            If EOF(i3) Then Exit Do
            Riga = LineInput(i3)
            PrintLine(i4, Riga)
        Loop
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Cod) = 1 And Len(Dir("TEX2" & RTrim(job.Contratto))) > 0 Then
            FileClose(i3)
2922:       FileOpen(i3, "TEX2" & RTrim(job.Contratto), OpenMode.Input)
            Do
                If EOF(i3) Then Exit Do
2923:           Riga = LineInput(i3)
                PrintLine(i4, Riga)
            Loop
        End If
        FileClose(i3) : FileClose(i4)
        On Error Resume Next
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        On Error GoTo 0
FinReg: Exit Sub
ErrRegis:
        If Err.Number = 52 And Erl() = 914 Then
            A = "Si hanno dei problemi nell'identificare|"
            A = A & "il file del rapporto di calcolo:|" & NewF
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(A))
            Resume FinReg
        End If
        Debug.Print("Err Registra" & Err.Number & Erl() & NewF) : Stop
        Resume
    End Sub
    Function Stress(ByRef T As Single, ByRef iC As Short, ByRef k As Short) As Single
        Dim Sfa, stressb, Sfo As Single
        Dim Codice As Short
        If Apert._Option1_1.Checked Then
            Codice = 1
            Materiale.SigmaAmm(Codice, T * 1.8 + 32, Sfa, Sfo)
            Stress = Sfo / 9.8065
        Else
            If iC = 1 Then
                ' SOLL.AMM MAT ANCC
                Select Case k
                    Case Is < 0
                        Error (5)
                    Case 1
                        Stress = 19.093 - 0.11975 * T + 0.00092583 * T ^ 2 - 0.0000031444 * T ^ 3 + 0.0000000036667 * T ^ 4
                    Case 2
                        Stress = 19.093 - 0.11975 * T + 0.00092583 * T ^ 2 - 0.0000031444 * T ^ 3 + 0.0000000036667 * T ^ 4
                    Case 3
                        Stress = 22.107 - 0.13325 * T + 0.0010542 * T ^ 2 - 0.0000036556 * T ^ 3 + 0.0000000043333 * T ^ 4
                    Case 4
                        Stress = 22.107 - 0.13325 * T + 0.0010542 * T ^ 2 - 0.0000036556 * T ^ 3 + 0.0000000043333 * T ^ 4
                    Case 5
                        Stress = 17.995 - 0.041188 * T + 0.00025083 * T ^ 2 - 0.0000011963 * T ^ 3 + 0.0000000016667 * T ^ 4
                    Case 6
                        If T < 200 Then
                            Stress = 14
                        Else
                            Stress = -12.4 + 0.34667 * T - 0.00142 * T ^ 2 + 0.0000017333 * T ^ 4
                        End If
                    Case 7
                        Stress = 15.831 - 0.069193 * T + 0.0003425 * T ^ 2 - 0.00000093704 * T ^ 3 + 0.000000001 * T ^ 4
                    Case 8
                        Stress = 15.831 - 0.069193 * T + 0.0003425 * T ^ 2 - 0.00000093704 * T ^ 3 + 0.000000001 * T ^ 4
                    Case 9
                        Stress = 12.538 - 0.03278 * T + 0.00007 * T ^ 2 - 0.000000059261 * T ^ 3 + 0.0000000000000019529 * T ^ 4
                    Case 10
                        Stress = 12.538 - 0.03278 * T + 0.00007 * T ^ 2 - 0.000000059261 * T ^ 3 + 0.0000000000000019529 * T ^ 4
                    Case 11
                        Stress = 14.738 - 0.03478 * T + 0.00007 * T ^ 2 - 0.000000059261 * T ^ 3 + 0.0000000000000013703 * T ^ 4
                    Case 12
                        Stress = 13.469 - 0.05247 * T + 0.00019417 * T ^ 2 - 0.0000003963 * T ^ 3 + 0.00000000033333 * T ^ 4
                    Case 13
                        Stress = 13.469 - 0.0064736 * T - 0.0001825 * T ^ 2 + 0.0000008037 * T ^ 3 - 0.000000001 * T ^ 4
                    Case 14
                        Stress = 20.245 - 0.11653 * T + 0.00090583 * T ^ 2 - 0.0000031148 * T ^ 3 + 0.0000000036667 * T ^ 4
                    Case 15
                        If T < 200 Then
                            Stress = 12.6
                        Else
                            Stress = -17.2 + 0.38233 * T - 0.00154 * T ^ 2 + 0.0000018667 * T ^ 3
                        End If
                    Case 16
                        If T < 200 Then
                            Stress = 12.6
                        Else
                            Stress = -17.2 + 0.38233 * T - 0.00154 * T ^ 2 + 0.0000018667 * T ^ 3
                        End If
                End Select
            Else
                ' SOLL AMM SECONDO ASME
                Select Case k
                    Case Is < 0
                        Error (5)
                    Case 1
                        Stress = 10.5
                    Case 2
                        Stress = 12.3
                    Case 3
                        Stress = 12.3
                    Case 4
                        Stress = 12.3
                    Case 5
                        Stress = 8.399999
                    Case 6
                        Stress = 10.25
                    Case 7
                        Stress = 15.6 - 0.072167 * T + 0.00031833 * T ^ 2 - 0.00000073333 * T ^ 3 + 0.00000000066667 * T ^ 4
                    Case 8
                        Stress = 15.6 - 0.072167 * T + 0.00031833 * T ^ 2 - 0.00000073333 * T ^ 3 + 0.00000000066667 * T ^ 4
                    Case 9
                        Stress = 11.812 - 0.02733 * T + 0.0000058338 * T ^ 2 + 0.0000002037 * T ^ 3 - 0.00000000033333 * T ^ 4
                    Case 10
                        Stress = 11.812 - 0.02733 * T + 0.0000058338 * T ^ 2 + 0.0000002037 * T ^ 3 - 0.00000000033333 * T ^ 4
                    Case 11
                        Stress = 11.598 + 0.024344 * T - 0.00040083 * T ^ 2 + 0.0000014481 * T ^ 3 - 0.0000000016667 * T ^ 4
                    Case 12
                        Stress = 12.1595 - 0.032542 * T + 0.000025834 * T ^ 2 + 0.00000017407 * T ^ 3 - 0.00000000033333 * T ^ 4
                    Case 13
                        Stress = 17.005 - 0.08841 * T + 0.00037833 * T ^ 2 - 0.00000080741 * T ^ 3 + 0.00000000066667 * T ^ 4
                    Case 14
                        Stress = 10.5
                    Case 15
                        Stress = 8.75
                    Case 16
                        Stress = 8.75
                End Select
            End If
        End If
    End Function
    Function CercaMec() As String
        Dim com, Cerca As String
        Dim ifl As Short
        com = GlobalRoutines.Str2Cifre(Nrdit \ 2)
        Cerca = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + com + ".MEC"
        If Len(Dir(Cerca)) > 0 Then
            ifl = FreeFile()
            FileOpen(ifl, Cerca, OpenMode.Random, , , Len(MecData(0)))
            If LOF(ifl) = 0 Then
                FileClose(ifl)
                IO.File.Delete(Cerca)
            Else
                FileClose(ifl)
            End If
        End If
        CercaMec = Cerca
    End Function
    Sub ENuovo()
        ItemnSt = job.Comm.Ind(1).Data.Assieme.Trim
        SETRDIT(ItemnSt, Nrdit)
        FileMec = CercaMec
        VUOTO = False
        If IO.File.Exists(FileMec) Then
            FileClose(33)
903:        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
            If LOF(33) = 0 Then
                FileClose(33)
                Kill(FileMec)
                VUOTO = True
            Else
                FileGet(33, MecData(0), 1)
                If MecData(0).nPassi = 0 Then VUOTO = True Else VUOTO = False
                FileClose(33)
            End If
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        ElseIf Len(Dir(FileMec)) = 0 Then
            VUOTO = True
        End If
        FileClose(33)
    End Sub

    'Sub NuoPreU()
    'ChiPreU
    ''CLOSPREV
    'AddDistinta = 301
    'Catena "HTRI"
    'End Sub

    Sub AzzeraStruct()
        Dim j, k As Short
        HeaderStruct(0).NumFile = 0
        For j = 1 To 16
            HeaderStruct(0).Fila(j).NumFrazioni = 0
            For k = 1 To 6 : HeaderStruct(0).Fila(j).Frazione(k) = 0 : Next
        Next
    End Sub
    Function BuildStructHeader(ByRef Npass1 As Short, ByRef Npass2 As Short, ByRef IngrTipo As Short, ByRef File() As Single, ByRef NfileSup As Short) As Short
        Call AzzeraStruct()
        NumFile = 0
        For i = 1 To 16
            If i >= Npass1 And i <= Npass2 Then
                FileDum(i - Npass1 + 1) = File(i)
                NumFile = NumFile + File(i)
            End If
        Next
        If Not GiustoIntero(NumFile) Then BuildStructHeader = -1 : Exit Function
        HeaderStruct(0).NumFile = CShort(NumFile)
        Npass = Npass2 - Npass1 + 1
        i = 1
        For j = 1 To Npass
            Do Until System.Math.Abs(FileDum(j)) < TOLLERANZA
                Occupato = 0
                For jj = 1 To HeaderStruct(0).Fila(i).NumFrazioni
                    Occupato = Occupato + HeaderStruct(0).Fila(i).Frazione(jj)
                Next jj
                If FileDum(j) > 1 - TOLLERANZA And Occupato < TOLLERANZA Then
                    FileDum(j) = FileDum(j) - 1
                    HeaderStruct(0).Fila(i).NumFrazioni = 1
                    HeaderStruct(0).Fila(i).Frazione(1) = 1
                    If Int(FileDum(j)) = 0 Then
                        If Continua Then
                            HeaderStruct(0).Fila(i).completo(1) = 2
                        Else
                            HeaderStruct(0).Fila(i).completo(1) = 0
                        End If
                        Continua = False
                    Else
                        HeaderStruct(0).Fila(i).completo(1) = 1
                        Continua = True
                    End If
                    HeaderStruct(0).Fila(i).IngrVersoUsc(1) = ((j Mod 2) = 1) ' ABS(Ingresso))
                    HeaderStruct(0).Fila(i).NumPasso(1) = j
                    i = i + 1
                ElseIf HeaderStruct(0).Fila(i).NumFrazioni > 6 Then
                    BuildStructHeader = -2 : Exit Function
                Else
                    nf = HeaderStruct(0).Fila(i).NumFrazioni + 1
                    If Occupato + FileDum(j) > 1 - TOLLERANZA Then
                        Newfract = 1 - Occupato
                        HeaderStruct(0).Fila(i).completo(nf) = 1
                        Continua = True
                        Call Aggiorna()
                        i = i + 1
                    Else
                        Newfract = FileDum(j)
                        If Continua Then
                            HeaderStruct(0).Fila(i).completo(nf) = 2
                        Else
                            HeaderStruct(0).Fila(i).completo(nf) = 0
                        End If
                        Continua = False
                        Call Aggiorna()
                    End If
                    If System.Math.Abs(Occupato - 1) < TOLLERANZA Then
                        i = i + 1
                    End If
                End If
            Loop
        Next
        If HeaderStruct(0).NumFile <> i - 1 Then BuildStructHeader = -3
        If IngrTipo <= 2 Then
            iSpec = 0 : If IngrTipo = 2 Then iSpec = 1
            For k = 2 - (NfileSup Mod 2) - iSpec To i - 1 Step 2
                Call Rovescia()
            Next k
        Else
            iSpec = 0 : If IngrTipo = 4 Then iSpec = 1 '3 laterale
            For k = 2 - (NfileSup Mod 2) - iSpec To i - 1 Step 2
                Call Rovescia()
                Call Splitta()
            Next k
            For k = 2 - (NfileSup Mod 2) - (1 - iSpec) To i - 1 Step 2
                Call Splitta()
            Next k
        End If
        Exit Function
    End Function
    Private Sub Splitta()
        For kk = 1 To HeaderStruct(0).Fila(k).NumFrazioni - 1
            HeaderStruct(0).Fila(k).Frazione(kk) = HeaderStruct(0).Fila(k).Frazione(kk) / 2
            kkk = 2 * (HeaderStruct(0).Fila(k).NumFrazioni - 1) + 1 - (kk - 1)
            HeaderStruct(0).Fila(k).Frazione(kkk) = HeaderStruct(0).Fila(k).Frazione(kk)
            HeaderStruct(0).Fila(k).completo(kkk) = HeaderStruct(0).Fila(k).completo(kk)
            HeaderStruct(0).Fila(k).IngrVersoUsc(kkk) = HeaderStruct(0).Fila(k).IngrVersoUsc(kk)
            HeaderStruct(0).Fila(k).NumPasso(kkk) = HeaderStruct(0).Fila(k).NumPasso(kk)
        Next kk
        HeaderStruct(0).Fila(k).NumFrazioni = 2 * (HeaderStruct(0).Fila(k).NumFrazioni - 1) + 1
    End Sub
    Private Sub Rovescia()
        For kk = 1 To (HeaderStruct(0).Fila(k).NumFrazioni + 1) \ 2
            GlobalRoutines.SWAP(HeaderStruct(0).Fila(k).Frazione(kk), HeaderStruct(0).Fila(k).Frazione(HeaderStruct(0).Fila(k).NumFrazioni - kk + 1))
            GlobalRoutines.SWAP(HeaderStruct(0).Fila(k).completo(kk), HeaderStruct(0).Fila(k).completo(HeaderStruct(0).Fila(k).NumFrazioni - kk + 1))
            GlobalRoutines.SWAP(HeaderStruct(0).Fila(k).IngrVersoUsc(kk), HeaderStruct(0).Fila(k).IngrVersoUsc(HeaderStruct(0).Fila(k).NumFrazioni - kk + 1))
            GlobalRoutines.SWAP(HeaderStruct(0).Fila(k).NumPasso(kk), HeaderStruct(0).Fila(k).NumPasso(HeaderStruct(0).Fila(k).NumFrazioni - kk + 1))
        Next kk
    End Sub
    Private Sub Aggiorna()
        FileDum(j) = FileDum(j) - Newfract
        HeaderStruct(0).Fila(i).Frazione(nf) = Newfract
        HeaderStruct(0).Fila(i).NumFrazioni = nf
        HeaderStruct(0).Fila(i).IngrVersoUsc(nf) = ((j Mod 2) = 1) ' ABS(Ingresso))
        HeaderStruct(0).Fila(i).NumPasso(nf) = j
    End Sub
    Sub Condensa()
        Dim j, i, k As Short
        Dim kk As Short
        For i = 1 To 2
            For j = 1 To HeaderSetti(i).NumFile
                For k = HeaderSetti(i).Fila(j).NumSettiH - 1 To 1 Step -1
                    If System.Math.Abs(HeaderSetti(i).Fila(j).SettiH2(k) - HeaderSetti(i).Fila(j).SettiH1(k + 1)) < 1 Then
                        HeaderSetti(i).Fila(j).SettiH2(k) = HeaderSetti(i).Fila(j).SettiH2(k + 1)
                        For kk = k + 1 To HeaderSetti(i).Fila(j).NumSettiH - 1
                            HeaderSetti(i).Fila(j).SettiH1(kk) = HeaderSetti(i).Fila(j).SettiH1(kk + 1)
                            HeaderSetti(i).Fila(j).SettiH2(kk) = HeaderSetti(i).Fila(j).SettiH2(kk + 1)
                        Next
                        HeaderSetti(i).Fila(j).NumSettiH = HeaderSetti(i).Fila(j).NumSettiH - 1
                    End If
                Next k
            Next j
        Next i
    End Sub
    Sub DisSetti(ByRef iMenu As Short)
        'On Local Error GoTo ErrDisS
        PVERT = 60
        AlungTest = 2000
        AaltzTest = PVERT * HeaderStruct(0).NumFile
        videoR(-AlungTest / 5, 1.2 * AlungTest, -AaltzTest, 5 * AaltzTest, "----REDOEXITHELP")
        Ingresso = True : yRif = 2 * AaltzTest
        iHeader = 1
        Call DrawTest()
        Ingresso = False : yRif = 0
        iHeader = 2
        Call DrawTest()
        Exit Sub
ErrDisS:
        Debug.Print("Err DisSetti" & Err.Number & Erl() & xis & xfs & xii & xfi) : Stop
    End Sub
    Private Sub DrawTest()
DrawTest:
        HeaderSetti(iHeader).NumFile = HeaderStruct(0).NumFile
        HeaderSetti(iHeader).LungTest = AlungTest
        'Line (0, yRif + 0)-(AlungTest, yRif + AaltzTest), 0, B
        If Ingresso Then Text = "Testata di Ingresso" Else Text = "Testata di Uscita"
        'Length = OutGText(0!, yRif - 10!, Text$)
        For i = 1 To HeaderStruct(0).NumFile
            xis = 0 : xii = 0 : j1 = 1 : iSetti = 0 : iSettiH = 0
            For j = 1 To HeaderStruct(0).Fila(i).NumFrazioni
10:             xfs = xis + HeaderStruct(0).Fila(i).Frazione(j) * AlungTest
12:             If Parete(i, j, i, j + 1, Ingresso) Then iCode = &HFFFFS Else iCode = &H3333S
                If (iCode = &HFFFFS Or iCode = &H3333S) And j < HeaderStruct(0).Fila(i).NumFrazioni Then
                    'LINE (xfs, yrif + AaltzTest - (i - 1) * PVERT)-(xfs, yrif + AaltzTest - i * PVERT), 0, , iCode
                    If iCode = &HFFFFS Then iSetti = iSetti + 1 : HeaderSetti(iHeader).Fila(i).SettiV(iSetti) = xfs
                End If
                If i = HeaderStruct(0).NumFile Then GoTo ContDis
                Do While j1 <= HeaderStruct(0).Fila(i + 1).NumFrazioni
                    xfi = xii + HeaderStruct(0).Fila(i + 1).Frazione(j1) * AlungTest
                    If xfi >= xfs Then Exit Do
                    If xfi > xis Then
14:                     If Parete(i, j, i + 1, j1, Ingresso) Then iCode = &HFFFFS Else iCode = &H3333S
                        If xii < xis Then xii = xis
15:                     If HeaderStruct(0).Fila(i).NumPasso(j) <> HeaderStruct(0).Fila(i + 1).NumPasso(j1) And System.Math.Abs(xii - xfi) > 1.0! Then
                            'LINE (xii, yrif + AaltzTest - i * PVERT)-(xfi, yrif + AaltzTest - i * PVERT), 0, , iCode
                            If iCode = &HFFFFS Then
                                iSettiH = iSettiH + 1
                                HeaderSetti(iHeader).Fila(i).SettiH1(iSettiH) = xii
                                HeaderSetti(iHeader).Fila(i).SettiH2(iSettiH) = xfi
                            End If
                        End If
                        xis = xfi
                        If xfi = xfs Then Exit Do
                    End If
                    j1 = j1 + 1
                    xii = xfi
                Loop
                If xfs > xis Then
                    If Parete(i, j, i + 1, j1, Ingresso) Then iCode = &HFFFFS Else iCode = &H3333S
16:                 If HeaderStruct(0).Fila(i).NumPasso(j) <> HeaderStruct(0).Fila(i + 1).NumPasso(j1) And System.Math.Abs(xis - xfs) > 1.0! Then
                        'LINE (xis, yrif + AaltzTest - i * PVERT)-(xfs, yrif + AaltzTest - i * PVERT), 0, , iCode
                        If iCode = &HFFFFS Then
                            iSettiH = iSettiH + 1
                            HeaderSetti(iHeader).Fila(i).SettiH1(iSettiH) = xis
                            HeaderSetti(iHeader).Fila(i).SettiH2(iSettiH) = xfs
                        End If
                    End If
                End If
ContDis:
                xis = xfs
            Next j
            HeaderSetti(iHeader).Fila(i).NumSettiV = iSetti
            HeaderSetti(iHeader).Fila(i).NumSettiH = iSettiH
            If iSettiH = 1 Then
                If System.Math.Abs(HeaderSetti(iHeader).Fila(i).SettiH1(1)) < 1 And System.Math.Abs(HeaderSetti(iHeader).Fila(i).SettiH2(1) - AlungTest) < 1 Then iSettiH = -1
            End If
        Next i
    End Sub
    Sub videoR(ByRef x0 As Single, ByRef x1 As Single, ByRef y0 As Single, ByRef y1 As Single, ByRef menu As String)
        'Screen 12
        'WIDTH , 60
        'Xscr0 = 1: Yscr0 = 32: Xscr = 638: Yscr = 478
        'dX = Xscr - Xscr0: dY = Yscr - Yscr0
        'If (x1 - x0) / (y1 - y0) > dX / dY Then
        '  suppl = (x1 - x0) * dY / dX - (y1 - y0)
        '  y0 = y0 - suppl / 2: y1 = y1 + suppl / 2
        'Else
        '  suppl = (y1 - y0) * dX / dY - (x1 - x0)
        '  x0 = x0 - suppl / 2: x1 = x1 + suppl / 2
        'End If
        'xmin = x0: xmax = x1: ymin = y0: ymax = y1
        'Call ResetScreenR(15, 0)
        'GTextWindow xmin, ymin, xmax, ymax, False
        'LOCATE 1, 40: Print Mid$(menu, 1, 4); '"ZOOM";
        'LOCATE 1, 45: Print Mid$(menu, 5, 4); '"STAM";
        'LOCATE 1, 50: Print Mid$(menu, 9, 4); '"EXIT";
        'LOCATE 1, 55: Print Mid$(menu, 13, 4); '"HELP";
    End Sub

    Function GiustoIntero(ByRef X As Single) As Short
        GiustoIntero = False
        If System.Math.Abs(CShort(X) - X) < TOLLERANZA Then GiustoIntero = True
    End Function
    Sub Minimo(ByRef iHS As Short, ByRef Sezione As Single, ByRef NewSezione As Single)
        Dim SV As Single
        Dim i, j As Short
        SV = 0
        If SV > Sezione And SV < NewSezione Then
            NewSezione = SV
        End If
        For i = 1 To HeaderSetti(iHS).NumFile
            For j = 1 To HeaderSetti(iHS).Fila(i).NumSettiV
                SV = HeaderSetti(iHS).Fila(i).SettiV(j)
                If SV > Sezione And SV < NewSezione Then
                    NewSezione = SV
                End If
            Next j
        Next i
        SV = HeaderSetti(iHS).LungTest
        If SV > Sezione And SV < NewSezione Then
            NewSezione = SV
        End If
    End Sub

    Sub NumSet(ByRef nseta() As Short, ByRef NfilA(,) As Short, ByRef Sezione() As Single)
        Dim j, i, NumFil, k As Short
        For i = 1 To 2
            NumFil = 0
            For j = 1 To HeaderSetti(i).NumFile
                NumFil = NumFil + 1
                For k = 1 To HeaderSetti(i).Fila(j).NumSettiH
                    If HeaderSetti(i).Fila(j).SettiH1(k) < Sezione(i) And HeaderSetti(i).Fila(j).SettiH2(k) > Sezione(i) Then
                        nseta(i) = nseta(i) + 1
                        NfilA(nseta(i), i) = NumFil
                        NumFil = 0
                        '            IF i = 2 THEN PRINT "j,k,Sez"; j; k; Sezione(i); HeaderSetti(i).Fila(j).SettiH1(k); HeaderSetti(i).Fila(j).SettiH2(k)
                        If Not (HeaderSetti(i).Fila(j).SettiH1(k) = 0 And HeaderSetti(i).Fila(j).SettiH2(k) = HeaderSetti(i).LungTest) Then NfilA(nseta(i), i) = -NfilA(nseta(i), i)
                        Exit For
                    End If
                Next k
            Next j
            NfilA(nseta(i) + 1, i) = NumFil
        Next i
    End Sub

    Function Parete(ByRef i1 As Short, ByRef j1 As Short, ByRef i2 As Short, ByRef j2 As Short, ByRef Ingresso As Short) As Boolean
        Dim Pare As Boolean
        On Error GoTo ErrParete
100:    If i1 = i2 And j1 = HeaderStruct(0).Fila(i1).NumFrazioni Then Parete = False : Exit Function
110:    If System.Math.Abs(HeaderStruct(0).Fila(i1).NumPasso(j1) - HeaderStruct(0).Fila(i2).NumPasso(j2)) = 1 Then
120:        If HeaderStruct(0).Fila(i1).NumPasso(j1) > HeaderStruct(0).Fila(i2).NumPasso(j2) Then
130:            Pare = Not (HeaderStruct(0).Fila(i1).IngrVersoUsc(j1) And Not HeaderStruct(0).Fila(i2).IngrVersoUsc(j2))
                If Not Ingresso Then Pare = Not Pare
            Else
140:            Pare = Not (Not HeaderStruct(0).Fila(i1).IngrVersoUsc(j1) And HeaderStruct(0).Fila(i2).IngrVersoUsc(j2))
                If Not Ingresso Then Pare = Not Pare
            End If
        Else
            Pare = True
        End If
        Parete = Pare
        Exit Function
ErrParete:
        Debug.Print("Err Parete" & Err.Number & Erl() & i1 & j1 & i2 & j2) : Stop
    End Function

    Function PasFrct(ByRef Npass As Short, ByRef Mode As Short) As Short
        Dim ifl, i As Short
        Dim Tit As String
        Dim Stringa(4) As String
        Dim IngrTipo As Short
        Dim Esito1, iMenu As Short
        'Mode=1 visualizza; Mode=2 calcola solo
        ifl = FreeFile
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\UPM004.DAT"), OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 4 : Stringa(i) = LineInput(ifl) : Next
        Tit = LineInput(ifl)
        FileClose(ifl)
Redo:
        If Mode = 1 Then
            'Stringa(1) = "Ingresso a sinistra"
            'Stringa(2) = "Ingresso a destra"
            'Stringa(3) = "Ingresso simm. laterale"
            'Stringa(4) = "Ingresso centrale"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            IngrTipo = Monitor.Motore.Quale(4, Tit, Stringa, "", HeaderStruct(0).IngrTipo) 'Tipo di ingresso
            HeaderStruct(0).IngrTipo = IngrTipo
        End If
        Esito1 = BuildStructHeader(1, Npass, IngrTipo, File, 0)
        If Mode = 1 Then
            Call DisSetti(iMenu)
            If iMenu = 2 Then GoTo Redo
            Dom(1) = ""
        End If
        Call Condensa()
        FilePut(33, HeaderSetti(1), 5)
        FilePut(33, HeaderSetti(2), 6)
        FilePut(33, HeaderStruct(0), 7)
        PasFrct = Esito1
    End Function

    Sub PiuPiccola(ByRef iHS As Short, ByRef Sezione As Single, ByRef NewSezione As Single)
        Dim New1 As Single
        NewSezione = HeaderSetti(iHS).LungTest * 2
        Call Minimo(iHS, Sezione, NewSezione)
        If NewSezione = HeaderSetti(iHS).LungTest Then Exit Sub
        New1 = NewSezione
        NewSezione = HeaderSetti(iHS).LungTest * 2
        Call Minimo(iHS, New1, NewSezione)
        NewSezione = (NewSezione + New1) \ 2
    End Sub

    Sub PossibiliSezioni(ByRef Sezione() As Single)
        Dim Rispv(2) As String
        Dim i, nSezioni As Short
        Dim NewSezione As Single
        Dim ii, Scelta As Short
        Dim Sezioni(10) As Single
        Dim Stringa(4) As String
        Dim Tit As String
        Rispv(1) = "lato ingresso"
        Rispv(2) = "opposta/e ingresso"
        For i = 1 To 2
            Sezione(i) = -1 : nSezioni = 0
            Do
                Call PiuPiccola(i, Sezione(i), NewSezione)
                If NewSezione = HeaderSetti(i).LungTest Then Exit Do
                nSezioni = nSezioni + 1
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Sezioni(nSezioni). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Sezioni(nSezioni) = NewSezione
                Sezione(i) = NewSezione
            Loop
            If nSezioni > 1 Then
                For ii = 1 To nSezioni
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Sezioni(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Stringa(ii) = "Sezione n." & Str(ii) & ":" & Str(Int(Sezioni(ii) * 100.0! / HeaderSetti(i).LungTest)) & "%"
                Next ii
                If i = 1 Then Tit = " A" Else Tit = " B"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Scelta = Monitor.Motore.Quale(nSezioni, "Cassa/e " & Rispv(i), Stringa, "", 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Sezioni(Scelta). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Sezione(i) = Sezioni(Scelta)
            End If
        Next i
    End Sub
    Public Sub RegistraInq(ByRef i As Short, Optional ByRef nFin As Short = 0)
        Dim ifl, j As Short
        ifl = FreeFile
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto & ".TXT", OpenMode.Output)
        For j = 1 To i
            'If Tipo(nFin, j) Then Risp(j) = GlobalRoutines.myStr(Val(Risp(j)), 8, 4, False)
            PrintLine(ifl, Risp(j))
        Next j
        FileClose(ifl)
    End Sub

    Public Sub DatiCassaOut()
        Dim i, n As Short
        n = Monitor.Motore.InputForms(1 - 1).pNinput
        For i = 1 To n
            Risp(i) = Monitor.Motore.InputForms(1 - 1).prisposte(i)
        Next
        RegistraInq(n, 1)
        UPMPLT(iCassa)
        n = Monitor.Motore.InputForms(2 - 1).pNinput
        For i = 1 To n
            Risp(i) = Monitor.Motore.InputForms(2 - 1).prisposte(i)
        Next
        RegistraInq(n, 2)
        Call SettiVuoti(iCassa)
    End Sub

    Public Sub MatLamTest(ByRef Y As Short)
        Dim iC, k As Short
        Dim Matt As String
        Dim S As Single
        Dim yAll As Short
        If (Y >= 5 + iDisp And Y <= 5 + iDisp + nmat) Or Y = iMat Then
            If iCode = 3 Then iC = 1 Else iC = 2
            Matt = Monitor.Motore.InputForms(1 - 1).prisposte(Y)
            If Y = iMat Then
                indice = MecData(0).iMATSE
            ElseIf nmat = 1 Then
                indice = MecData(0).iMATUG
            Else
                Select Case Y - 4 + iDisp
                    Case 1 : indice = MecData(0).iMATSH
                    Case 2 : indice = MecData(0).iMATTP
                    Case 3 : indice = MecData(0).iMATEN
                End Select
            End If
            Matt = MatTesLam(S, MecData(iCassa).T, iC, 0, k, Matt)
            If Len(Matt) > 0 Then
                Monitor.Motore.InputForms(1 - 1).prisposte(Y) = Matt
                yAll = Y + nmat : If Y = iMat Then yAll = Y + 1
                Monitor.Motore.InputForms(1 - 1).prisposte(yAll) = GlobalRoutines.myStr(S, 4, 3, False)
                If iDisp = 1 Then
                    Monitor.Motore.InputForms(1 - 1).prisposte(Y + 2 * nmat) = GlobalRoutines.myStr(Stress(20.0!, iC, k), 4, 3, False)
                End If
            End If
            If Apert._Option1_1.Checked Then
                If Y = iMat Then
                    MecData(0).iMATSE = indice
                ElseIf nmat = 1 Then
                    MecData(0).iMATUG = indice
                Else
                    Select Case Y - 4 + iDisp
                        Case 1 : MecData(0).iMATSH = indice
                        Case 2 : MecData(0).iMATTP = indice
                        Case 3 : MecData(0).iMATEN = indice
                    End Select
                End If
                FileClose(33)
                FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
                iC = iCassa : If iC = 0 Then iC = 1
                FilePut(33, MecData(0), iC)
                FileClose(33)
            End If
        End If
    End Sub
End Module