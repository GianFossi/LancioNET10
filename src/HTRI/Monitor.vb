Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public routines As RoutBase1.Routines
    Public Sub New()
        MyBase.New()
        Motore = New RoutBase1.clsMotore("HTRI")
        Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Motore)
    End Sub
    Protected Overrides Sub Finalize()
        '       Motore.Class_Terminate()
        '      Motore = Nothing
        MyBase.Finalize()
    End Sub
    Public Overloads Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Public Overloads Function HelpTopic(ByVal id As String) As String
        Dim Nome As String = id.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        Dim Nome1 As String
        Dim ifl, iErr As Integer
        If f.Length = 0 Then FineCarica()
        job.Contratto = IO.Path.GetFileNameWithoutExtension(f)
        If Monitor.Motore.Problem.Extension = ".PRV" Then
            Nome1 = Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".TE1"
            If IO.File.Exists(Nome1) Then
                Try
                    job.AggiungiCom(job.Contratto, True)
                    job.RetrieveCom(1, True) ' = Monitor.Motore.Retrievejob(job.Contratto, Nome1)
                Catch e As Exception
                    Stop
                    ' job.Salva()
                End Try
                job.Comm.SalvaCom("DATI", True) '              job.Salva(Monitor.Motore.Inizio.Gancio)
            End If
            ApriPRV(Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".PRV", actPRV, iErr)
        ElseIf Monitor.Motore.Problem.Extension = ".MEC" Then
            FileMec = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + ".MEC"
            ifl = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
            FileGet(ifl, MecData(0), 1)
            FileClose(ifl)
            With Motore.Problem
                .Author = MecData(0).ENGR
                .ClientPlant = MecData(0).CUSTMR
                .Doc = MecData(0).ICKNR
                .Item = MecData(0).ITEMNO
            End With
        End If
        FineCarica()
        '  Motore.Aggiorna()
    End Sub
    Private Sub Motore_CancelInput(ByRef f As Short) Handles Motore.CancelInput
        Dim i As Short
        For i = Motore.InputForms.Count To 1 Step -1
            Motore.InputForms(i - 1).close()
            Motore.InputForms.Remove(i - 1)
        Next
        Select Case FaseDati
            Case 8 : NotOKGenProp()
            Case 9 : FileClose(33)
            Case 12 : CancelBull()
            Case 13 : CancelGuar()
        End Select
        Motore.InputForms = Nothing
        Apert.Enabled = True
        FaseDati = -1
        OKDati = False
        AppActivate(Apert.Text)
    End Sub
    Private Sub Motore_ComboClick1(ByRef Index As Short) Handles Motore.ComboClick1
        Dim ifl As Short
        Dim Rig, Risp As String
        Dim ALt(4) As String
        Select Case FaseDati
            Case 3
                Select Case Index
                    Case 2 'Autom
                        Risp = UCase(Motore.InputForms(1 - 1).ComboFisso(Index - 1))
                        If Val(Motore.InputForms(1 - 1).prisposte(1)) = 1 Then
                            Motore.InputForms(1 - 1).prisposte(2) = "SI"
                            Exit Sub
                        End If
                        If Trim(Risp) = "SI" Then Ir = 1 Else Ir = 0
                        DefZone()
                End Select
            Case 1
                Select Case Index
                    Case 7
                        Select Case Trim(Motore.InputForms(1 - 1).prisposte(7)) 'Trim(Rispv.Rispv(ic(7, 1)).St)
                            Case "YES"
                                Contin = True
                                Prepara(4)
                            Case "NO"
                                Contin = False
                                If Motore.InputForms.Count = 4 Then
                                    '    Unload(Motore.InputForms(4))
                                    Motore.InputForms(4 - 1).close()
                                    Motore.InputForms.Remove(4 - 1)
                                    Motore.InputForms(3 - 1).Command1(0).Visible = True
                                    Motore.InputForms(3 - 1).Command1(1).Visible = True
                                End If
                        End Select
                End Select
            Case 5
                Select Case Index
                    Case 1 'click diatubo
                        Xtub(1) = Motore.InputForms(1 - 1).pComboListL(Index) + 1
                        AggiornaListaAlette(1)
                        CType(Motore.InputForms(1 - 1).Combolibero(7 + UpmHtr - 1), ComboBox).SelectedIndex = 0
                    Case 2, 3
                        AggiornaSpessore(1)
                    Case 5 'Mat
                        If Not UpmHtr Then
                            iMatS = Motore.InputForms(1 - 1).pComboList(5) + 2 ' iMat(Xalt)
                            ifl = FreeFile()
                            FileOpen(ifl, CStr(Motore.Inizio.Archdir + "\ARCH23.DAT"), OpenMode.Random, , OpenShare.Shared, 34)
                            FileGet(ifl, Rig, iMatS)
                            FileClose(ifl)
                            Motore.InputForms(1 - 1).prisposte(6) = Str(objDatBase.CVI(Right(Rig, 2)))
                        End If
                    Case 7 + UpmHtr 'alette
                        Xalett(1) = Motore.InputForms(1 - 1).pComboListL(Index) + 1
                        AggiornaListaPassi(1)
                        CType(Motore.InputForms(1 - 1).Combolibero(8 + UpmHtr - 1), ComboBox).SelectedIndex = 0
                    Case 8 + UpmHtr 'passo
                    Case 13 + UpmHtr 'turbol
                        Xturb(1) = CType(Motore.InputForms(1 - 1).ComboFisso(13 + UpmHtr - 1), ComboBox).SelectedIndex
                    Case 14 + UpmHtr 'giunto
                        xGiun(1) = CType(Motore.InputForms(1 - 1).ComboFisso(14 + UpmHtr - 1), ComboBox).SelectedIndex
                End Select
            Case 7
                NoteSiNo()
            Case 9 'Bocchhll
                Select Case Index
                    Case 1, 2
                        iMatS = CType(Motore.InputForms(1 - 1).ComboFisso(Index - 1), ComboBox).SelectedIndex
                        MinSpan(Index, iMatS, 1)
                        Motore.InputForms(1 - 1).HelpFile(Index - 1).Visible = iMatS <> 1
                End Select
            Case 14
                iCassa = CType(Motore.InputForms(1 - 1).ComboFisso(Index - 1), ComboBox).SelectedIndex + 1
                ifl = FreeFile()
                FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
                FileGet(ifl, MecData(iCassa), iCassa)
                FileClose(ifl)
        End Select
    End Sub
    Private Sub Motore_ComboClick2(ByRef Index As Short) Handles Motore.ComboClick2
        Dim ALt(4), Rig As String
        Dim ifl As Short
        Select Case FaseDati
            Case 5
                Select Case Index
                    Case 1 'tubo
                        Xtub(2) = Motore.InputForms(2 - 1).pComboListL(Index) + 1
                        AggiornaListaAlette(2)
                        Motore.InputForms(2 - 1).Combolibero(7 + UpmHtr - 1).ListIndex = 0
                    Case 2, 3
                        AggiornaSpessore(2)
                    Case 5 'Mat
                        If Not UpmHtr Then
                            iMatS = Motore.InputForms(2 - 1).pComboList(5) + 2 ' iMat(Xalt)
                            ifl = FreeFile()
                            FileOpen(ifl, CStr(Motore.Inizio.Archdir + "\ARCH23.DAT"), OpenMode.Random, , OpenShare.Shared, 34)
                            FileGet(ifl, Rig, iMatS)
                            FileClose(ifl)
                            Motore.InputForms(2 - 1).prisposte(6) = Str(objDatBase.CVI(Right(Rig, 2)))
                        End If
                    Case 7 + UpmHtr 'alette
                        Xalett(2) = Motore.InputForms(2 - 1).pComboListL(Index) + 1
                        AggiornaListaPassi(2)
                        Motore.InputForms(1 - 1).Combolibero(8 + UpmHtr - 1).ListIndex = 0
                    Case 8 + UpmHtr 'passo
                End Select
        End Select

    End Sub
    Private Sub Motore_dAiuClick(ByRef nFin As Short, ByRef Index As Short) Handles Motore.dAiuClick
        Select Case FaseDati
            Case 7
                Select Case nFin
                    Case 1
                        NoStacks(Index)
                End Select
            Case 9
                Select Case Index
                    Case 1, 2
                        iMatS = Motore.InputForms(1 - 1).ComboFisso(Index - 1).ListIndex
                        MinSpan(Index, iMatS, 0)
                End Select
            Case 10
                MatLamTest(Index)
        End Select
    End Sub

    Private Sub Motore_NuovoLav(ByRef f As String) Handles Motore.NuovoLav
        Select Case IO.Path.GetExtension(f)
            Case ".PRV"
                Stop
            Case ".MEC"
                FileMec = f
                With Motore.Problem
                    MecData(0).ENGR = .Author
                    MecData(0).CUSTMR = .ClientPlant
                    MecData(0).ICKNR = .Doc
                    MecData(0).ITEMNO = .Item
                End With
                Dim ifl As Integer = FreeFile()
                FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
                FilePut(ifl, MecData(0), 1)
                FileClose(ifl)
        End Select
    End Sub
    Public Sub Motore_OkInput(ByRef j As Short) Handles Motore.OkInput
        Dim i, k As Short
        Dim Testo As String
        Dim NewF As String
        Dim iF3, iF4 As Short
        Dim n As Short
        Dim NewF1, u As String
        Dim iF1, iVal, iF2 As Short
        Dim y As Short
        Dim Risp1(20) As String
        Dim NS As Single
        Dim SpAl As Single
        Dim i1, nFin As Short
        Dim jj, iOKPRO As Short
        Dim CambioBanco As Boolean
        Dim Valido As Boolean
        Select Case FaseDati
            Case 1
                For k = 1 To j
2050:               For i = 1 To Dati.iC1(13, k)
                        Rispv.Rispv(Dati.iC1(i, k)).St = Motore.InputForms(k - 1).prisposte(i)
                    Next i
                    Select Case k
                        Case 1
                            NumBank = Val(Rispv.Rispv(Dati.iC1(1, 1)).St)
                            If Nrdit \ 2 <= NumIt Then
                                'CambioBanco = NumBank <> Val(Bank(Nrdit \ 2).St(1))
                                CambioBanco = Trim(Rispv.Rispv(Dati.iC1(1, 1)).St) <> Trim(Bank(Nrdit \ 2, 1))
                            End If
                            If NumBank = 0 Then
                                If Asc(Rispv.Rispv(Dati.iC1(1, 1)).St) > 32 Then
                                    '           a$ = "L'identificativo del banco deve |"
                                    '      a$ = a$ + "essere numerico. Assumo <blank> |"
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    MsgBox(Motore.Inizio.ConvertiCr(at1(75)), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                                    Rispv.Rispv(Dati.iC1(1, 1)).St = Space(4)
                                Else
                                    Testo = Trim(Str(NumBank))
                                    If Len(Testo) = 1 Then Testo = "0" & Testo
                                    Rispv.Rispv(Dati.iC1(1, 1)).St = "  " & Testo
                                End If
                            End If
                            'Rispv.Rispv(iC(1, 1)).St = Adjust(Str(NumBank), -4)
                            Rispv.Rispv(Dati.iC1(7, 1)).St = UCase(Rispv.Rispv(Dati.iC1(7, 1)).St)
                            Select Case Trim(Rispv.Rispv(Dati.iC1(7, 1)).St)
                                Case "YES"
                                    Contin = True
                                Case "NO"
                                    Contin = False
                                Case Else
                                    'a$ = RTRIM$(at1(12))
                                    '         a$ = "Il valore per 'SERPENTINO VAPORE' puo'|"
                                    '    a$ = a$ + "essere solo SI o NO.                  |"
                                    ' MsgBox Motore.inizio.ConvertiCr(at1(12)), vbExclamation + vbOKOnly
                                    ''        GoTo Rifai1
                            End Select
                            If Len(LTrim(RTrim(Rispv.Rispv(Dati.iC1(1, 1)).St))) = 0 Then Rispv.Rispv(Dati.iC1(1, 1)).St = "   1"
                    End Select
                Next
                LOOPDOM(0, 0, Rispv)
                If CambioBanco Then
                    CheckGruppo((Rispv.Rispv(Dati.iC1(1, 1)).St))
                    Sommari(Valido)
                End If
                If Nrdit \ 2 > NumIt Then Sommari(Valido) ': CambioBanco = True
                Ritorna()
                If CambioBanco Then
                    FillTree(1)
                    SalvaNITE()
                End If
            Case 2
                For jj = 1 To Motore.InputForms(2 - 1).pNinput
                    iVal = iVal + 1
                    Valor(LungStt(iVal)) = Val(Motore.InputForms(2 - 1).prisposte(jj)) ' Val(Risp(jj))
                Next
                For jj = 1 To Motore.InputForms(3 - 1).pNinput * 2
                    iVal = iVal + 1
                    If LungStt(iVal) > 0 Then
                        Valor(LungStt(iVal)) = Val(Motore.InputForms(3 - 1).prisposte(jj)) ' Val(Risp(jj))
                    End If
                Next
                For jj = 1 To 64
                    objDatiFun.Buffer(jj).St = Valor(jj).ToString.PadLeft(25)
                Next jj
                HTRI11(objDatiFun)
                'Next macr
                DISPDAT()
                If ModeFun = 0 Then
                    Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
                    NewF = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".FUN"
                    If Len(Dir(NewF)) > 0 Then IO.File.Delete(NewF)
                    iF3 = FreeFile()
                    FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
                    iF4 = FreeFile()
                    FileOpen(iF4, NewF, OpenMode.Append)
                    Do
                        Testo = LineInput(iF3)
                        PrintLine(iF4, Testo)
                        If EOF(iF3) Then Exit Do
                    Loop
                    FileClose(iF3) : FileClose(iF4)
                    Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
                End If
                Ritorna()
                n = Val(job.Comm.Ind(2).Data.Assieme)
                If n > 0 Then
                    SETALT(n)
                    'altern 0
                    NonMostrareAlt = False
                    altern(ModeAltern)
                    If Val(job.Comm.Ind(2).Data.Assieme) = 0 Then
                        Ritorna()
                        Exit Sub
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
                    If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
                    NewF1 = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".CAL"
                    If Len(Dir(NewF1)) > 0 Then IO.File.Delete(NewF1)
                    NewF1 = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".VEN"
                    If Len(Dir(NewF1)) > 0 Then IO.File.Delete(NewF1)
                    u = objDatBase.PutBasCh(2, 56 + 2 * n, Nrdit \ 2, 1, objDatBase.MKI(0), 0)
                End If
            Case 3
                With ProblWLD
                    For jj = 1 To .NZONE - 1
                        If Ir = 0 Then
                            .Tzone(jj) = Val(Motore.InputForms(2 - 1).prisposte(.NZONE + jj + 1))
                        Else
                            .Tzone(jj) = Val(Motore.InputForms(2 - 1).prisposte(jj))
                        End If
                    Next
                    .Tzone(.NZONE + 1) = RDUT.TOut
                    .Tzone(0) = RDUT.Tin
                End With
                For i = 1 To ProblWLD.NZONE
                    If Motore.InputForms.Count >= 3 Then
                        If Motore.InputForms(3 - 1).pRisult(i) Then
                            Ib.Ialt(i) = 1
                            ProblWLD.TipZone(i) = "C"
                        Else
                            Ib.Ialt(i) = 0
                            ProblWLD.TipZone(i) = "N"
                        End If
                    Else
                        Ib.Ialt(i) = 0
                        ProblWLD.TipZone(i) = "N"
                    End If
                Next
                SalvaZON2()
                HTRI21()
                SaveZone()
                Ritorna()
                ISAWald()
                Check()
                If NuovaAlt Then
                    Sommari(Valido)
                    FillTree(1)
                    SalvaNITE()
                End If
            Case 4
                For jj = 1 To 3
                    For y = 1 To Motore.InputForms(jj - 1).pNinput
                        Risp1(y) = Motore.InputForms(jj - 1).prisposte(y)
                    Next
                    Select Case jj
                        Case 1
509:                        For y = 3 To 6 : Risp1(y) = UCase(Risp1(y)) : Next y
                            NS = Val(Risp1(1))
                            If NS < 0.1 Then
                                Testo = "N° di sezioni errato."
                                '      Testo = at1(77)
                                MsgBox(Testo, MsgBoxStyle.Critical, "ISA")
                                '      GoTo RIFA2
                                OKDati = False
                                Ritorna()
                                Exit Sub
                            End If
                            Risp(3) = Risp1(1)
                            Risp(2) = Risp1(2) & Left(Risp1(3), 1) & Left(Risp1(4), 1) & Left(Risp1(5), 1) & Left(Risp1(6), 1)
510:                    Case 2
                            If Val(Risp1(7)) = 0 Then
                                Testo = "N° di passaggi non definito."
                                '      Testo = at1(79)
                                MsgBox(Testo, MsgBoxStyle.Critical)
                                '  GoTo RIFA2
                                OKDati = False
                                Ritorna()
                                Exit Sub
                            End If
                            Npass = Val(Risp1(7))
                            Risp1(8) = UCase(Risp1(8))
511:                    Case 3
                            Risp1(4) = Left(Risp1(4), 2)
                            Risp1(8) = Left(Risp1(8), 1)
                    End Select
                    If jj > 1 Then
                        For y = 1 To Dati.iC1(13, jj) '(13, jj)
                            Risp(Dati.iC1(y, jj)) = Risp1(y) '(y, jj)) = Risp1(y)
                        Next
                    End If
                Next
                Ntipi = Val(Risp(14)) 'tipi di tubo
                If j >= 4 Then Risp(1) = LTrim(UCase(Motore.InputForms(4 - 1).prisposte(1)))
                iF2 = FreeFile()
                FileOpen(iF2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
                For i = 1 To 27
                    PrintLine(iF2, Risp(i).PadRight(30))
                Next
                FileClose(iF2)
                HTRI41()
                Ritorna()
            Case 5
                SalvaTEX1()
                'Fortran deve qui leggere da TEX1  e scrive su TEXT le file per zona
                'va in errore
                HTRI42()
                'If Npass > 1 Then
                iF3 = FreeFile()
                nFin = Motore.InputForms.Count
                FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
                For jj = 1 To Npass '- 1
                    PrintLine(iF3, Motore.InputForms(nFin - 1).prisposte(jj).padleft(12))
                Next jj
                FileClose(iF3)
                On Error Resume Next
                iOKPRO = 0
                HTRI43(iOKPRO)
                On Error GoTo 0
                FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
                If LOF(iF3) > 0 Then
                    Testo = ""
                    Do
                        u = LineInput(iF3)
                        Testo = Testo & u & vbCrLf
                    Loop Until EOF(iF3)
                    MsgBox(Testo, MsgBoxStyle.Critical)
                    OKDati = False
                    FileClose(iF3)
                    Ritorna()
                    Exit Sub
                    'x = Alert(2, Testo, 6, 11, 13, 66, at1(87), Space$(0), Space$(0))
                Else
                    OKDati = True
                End If
                FileClose(iF3)
                If iOKPRO > 0 Then OKDati = False
                'End If
                On Error Resume Next
                IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
                On Error GoTo 0
                n = Val(job.Comm.Ind(2).Data.Assieme) 'iVec
                Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
                NewF1 = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".CAL"
                IO.File.Delete(NewF1)
                NewF1 = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".VEN"
                IO.File.Delete(NewF1)
                '   CLOSPREV()
                u = objDatBase.PutBasCh(2, 56 + 2 * n, Nrdit \ 2, 1, objDatBase.MKI(0), 0)
                '   Apri(Trim(job.contratto))
                Ritorna()
            Case 6 'DataSheets
                CollectDS()
                Ritorna()
            Case 7 'OpFin
                If Motore.InputForms.Count = 1 Then
                    OkOpFin1()
                    objVentil.Riscrivi(NewF, Nrdit, Left(job.Contratto, 4))
                Else
                    OkOpFin2()
                End If
                Ritorna()
            Case 8 'Proposal
                OkGenProp(iOKPRO)
                Apert.Enabled = True
            Case 9 'Bocchll
                BocchllOut()
                Ritorna()
            Case 10 'mattestate
                DatiCassaOut()
                Ritorna()
            Case 11
                LarghCassa2()
                Ritorna()
            Case 12
                OkBull()
                Ritorna()
            Case 13
                OkGuar()
                Ritorna()
            Case 14
                For i = 1 To Monitor.Motore.InputForms(1 - 1).pNinput
                    Risp(i) = Monitor.Motore.InputForms(1 - 1).prisposte(i)
                Next
                Ritorna()
        End Select
        OKDati = True
    End Sub
    Private Sub Motore_OptClick(ByRef f As Short, ByRef i As Short) Handles Motore.OptClick
        Dim iQ, iQv As Short
        Dim itp As String
        Dim Testo, NewF As String
        Dim n, ifl As Short
        Dim Help, u As String
        Select Case FaseDati
            Case 2
                iQ = i
                n = Val(job.Comm.Ind(2).Data.Assieme)
                If iQ > 1 And n = 0 Then
                    MostraAiuto(IDH_PROC_ERRNOALT)
                    Monitor.Motore.InputForms(1 - 1).Option1(0).Value = True
                    Exit Sub
                End If
                iQv = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrdit \ 2, n, itp, 0)) + 1
                '0 ISA 1 manuale 2 automatica
                '                CLOSPREV()
                u = objDatBase.PutBasCh(4, 74, Nrdit \ 2, n, objDatBase.MKI(iQ - 1), 0)
                '              Apri(Trim(job.contratto))
            Case 12 : BullOpt(f, i)
            Case 13 : GuarOpt(f, i)
        End Select
        Exit Sub
    End Sub
    Private Sub Motore_Rifiuto() Handles Motore.Rifiuto
        ChiPre()
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        Dim ifl, iErr As Short
        Try
            If Monitor.Motore.Problem.Extension = ".PRV" Then
                job.Contratto = IO.Path.GetFileNameWithoutExtension(f)
            Else
                ifl = FreeFile()
                FileMec = f
                FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
                FileGet(ifl, MecData(0), 1)
                With Motore.Problem
                    MecData(0).ENGR = .Author
                    MecData(0).CUSTMR = .ClientPlant
                    MecData(0).ICKNR = .Doc
                    MecData(0).ITEMNO = .Item
                End With
                FilePut(ifl, MecData(0), 1)
                FileClose(ifl)
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Private Sub Motore_SondaFile(ByVal f As String) Handles Motore.SondaFile
        Dim ifl As Integer
        job.Contratto = IO.Path.GetFileNameWithoutExtension(f)
        If Monitor.Motore.Problem.Extension = ".PRV" Then
        ElseIf Monitor.Motore.Problem.Extension = ".MEC" Then
            FileMec = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + ".MEC"
            ifl = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
            FileGet(ifl, MecData(0), 1)
            FileClose(ifl)
            Motore.Problem.ClientPlant = MecData(0).CUSTMR
            Motore.Problem.Doc = MecData(0).ICKNR
            Motore.Problem.Item = MecData(0).ITEMNO
            Motore.Problem.Author = MecData(0).ENGR
        End If
    End Sub
    Private Sub Motore_TestoCambia1(ByRef Index As Short) Handles Motore.TestoCambia1
        Dim Nzz As Short
        Select Case FaseDati
            Case 3
                Select Case Index
                    Case 1 'n° di zone
                        Nzz = Val(Motore.InputForms(1 - 1).prisposte(Index))
                        If Nzz < 1 Then Exit Sub
                        If Nzz > 12 Then
                            MsgBox("Il numero di zone è compreso tra 1 e 12", MsgBoxStyle.Critical)
                            Motore.InputForms(1 - 1).prisposte(Index) = Str(ProblWLD.NZONE)
                            Exit Sub
                        End If
                        If Nzz = 1 Then
                            If UCase(Motore.InputForms(1 - 1).prisposte(2)) <> "SI" Then
                                Motore.InputForms(1 - 1).ComboFisso(1).ListIndex = 0
                                Motore.InputForms(1 - 1).ComboFisso(1).Enabled = False
                            Else
                                Motore.InputForms(1 - 1).ComboFisso(1).Enabled = True
                            End If
                        End If
                        Apert._Frames_4.Visible = Nzz > 1
                        ProblWLD.NZONE = Nzz
                End Select
                DefZone()
            Case 10
                Select Case Index
                    Case 9 'numero setti
                        If Monitor.Motore.Problem.Extension = ".MEC" Then
                            Dim Ns As Integer = Val(Motore.InputForms(1 - 1).prisposte(Index))
                            If Ns = 0 Or Ns = MecData(iCassa).NS Then Exit Sub
                            MecData(iCassa).NS = Ns
                            SETGET(iCassa, 0)
                            Dim Tit As String = "Camere" ' at2(25)  '
                            'FaseDati = 10
                            Dim Help As String = RadiceHelp & "::/Testpe.htm#Camere"
                            Motore.InputForms(1).Hide()
                            Motore.InputForms(1).Close()
                            Motore.InputForms.Remove(1)
                            If Not Inq(Tit, 2, Help) Then Exit Sub
                        End If
                End Select
            Case 11
                LarghCassa1()
        End Select
    End Sub
    Private Sub Motore_TestoCambia2(ByRef Index As Short) Handles Motore.TestoCambia2
        Dim vVal, nVal As Single
        Select Case FaseDati
            Case 2
                Select Case Index
                    Case 4, 5, 6, 7
                        nVal = Val(Motore.InputForms(2 - 1).prisposte(Index))
                        vVal = Valor(LungStt(Index))
                        Valor(LungStt(Index)) = nVal
                        If nVal = 0 And vVal <> 0 Or nVal <> 0 And vVal = 0 Then
                            Motore.InputForms(3 - 1).close()
                            Motore.InputForms.Remove(3 - 1)
                            SottoDatiFun(1)
                            AppActivate(Motore.InputForms(2 - 1).Caption)
                        End If
                End Select
            Case 3
        End Select
    End Sub
    Public Sub Ritorna()
        Dim i As Short
        If Not Monitor.Motore.InputForms Is Nothing Then
            For i = Motore.InputForms.Count To 1 Step -1
                Motore.InputForms(i - 1).close()
                Motore.InputForms.Remove(i - 1)
            Next
            Motore.InputForms = Nothing
        End If
        Apert.Enabled = True
        FaseDati = 0
        AppActivate(Apert.Text)
    End Sub
End Class