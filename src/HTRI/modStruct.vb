Option Strict Off
Option Explicit On
Imports RoutBase1
Module modStruct
    Private Larg10, VLargh As Single
    Private Ntub1, Ntub2 As Short
    Private Largf As Single
    Private XLarge, XAria As Single
    Private Mecdata0, MecData1 As clsMecData
    Private BankR(99) As String
    Private Nfas(99) As Short
    Private NumNum(99) As Short
    Private FileFil(99) As String
    Private NomBankR(99) As String
    Private iBank(30, 99) As Short
    Private Nquire As Short
    Private Matdim As LibMat.MaterialeNew1
    Private Record As RecAPRn
    Private Mec As clsMecData
    Private Materiali(99) As String
    Private IndMateriali(99) As Short
    Private iRec As Short
    'UPGRADE_WARNING: È possibile che singoli elementi della matrice RecordD debbano essere inizializzati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"'
    'UPGRADE_ISSUE: oggetto LibMat.clsPipe non aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
    Private Pipe As LibMat.clsPipe
    Private RecordD(12) As RecAPRn
    'UPGRADE_ISSUE: oggetto LibMat.clsTira non aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
    Private Tira As LibMat.clsTira
    Private TirDN As String
    Private actComm As RoutBase1.clsComm
    Private FileAPR, FileDAT As String
    Private nSett, nPart As Short
    Private DiamGuar As Single
    'Private Flangia As Grafica.Flangia
    Private Rapp As Single
    Private AltBoc As Single
    Private Ntubi, NumFil As Short
    Private AltraCassa, NumFilA As Short
    Private SP As Single
    Private Pari, Dispari As Short
    Private LARG As Single
    Private NTUB As Short
    '====================================================================
    Private Denom, PosDis, Note, DIME As String
    Private MATE, DisDet, Qta As String
    Private iTipo As Short
    Private privateE As String
    Private DBoc As Single
    Private l2, l3 As Short
    Private Inter As String
    Private D As Single
    Private DBocStr, Tipo As String
    Private ASA As Short
    Private j As Short
    Private Lu1, Lu2 As Single
    Private S As Single
    Private iSch As String
    '====================================================================
    Sub Struttura()
        Dim Prev As String
        Dim Testo As String
        Dim iF3 As Short
        Dim i, j As Short
        Dim jobv As String
        Dim X As Integer
        Dim ifl, NC As Short
        Dim NonDim As Boolean
        Dim NewF, Nome As String
        ReDim Risp(65)
        ReDim Dom(65)
        If Asc(job.Contratto) < 33 Then If Not CarPre() Then Exit Sub
        job1 = job
        InitUPM()
        If Left(job.Comm.Ind(3).Data.Assieme, 1) <> "*" Then
            '      Testo = "Questo preventivo non risulta|"
            ' Testo = Testo + "essere stato compattato.     |"
            ' Testo = Testo + "Operazione rifiutata.        |"
            MostraAiuto(IDH_DB_NOCOMPATT)
            job = job1
            Exit Sub
        End If 'z
        If NumIt < 1 Then
            Testo = Monitor.Motore.Inizio.ConvertiCr(at1(13) & at1(14))
            '         Testo = "In questo preventivo non e'  |"
            '    Testo = Testo + "stato inserito ancora nessun |"
            '    Testo = Testo + "Item. Operazione impossibile!|"
            MsgBox(Testo, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            job = job1
            Exit Sub
        End If 'aa
        'For i = 1 To 99
        '   Line Input #3, Item$(i)
        '   If EOF(3) Then Exit For
        'Next
        'Close #3
        '------------------------------------------------------
        jobv = LTrim(RTrim(job.Contratto))
        DatFin()
        If jobv <> job.Contratto And Len(jobv) > 0 Then
            NewF = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(jobv) + CDbl("*.MEC"))
            NewF = Dir(NewF)
            Do
                If Len(NewF) > 0 Then
                    Nome = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + Right(NewF, 6)
                    FileCopy(Monitor.Motore.Inizio.Workdir + "\" + NewF, Nome)
                    NewF = Dir()
                Else
                    Exit Do
                End If 'bb
            Loop
        End If 'dd
        '-------------------------------------------------------
        If Len(Dir(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))) > 0 Then IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
jump:
        Testo = "I seguenti items non sono ancora stati dimensionati:" & vbCrLf
        For j = 1 To NumIt
            'Item$(j) = Adjust$(LTrim$(RTrim$(Item$(j))), 20)
            ItemnSt = Item(j)
            SETRDIT(ItemnSt, Nrdit)
            If Nrdit = 0 Then
                MsgBox("qualcosa non va")
                Exit Sub
            End If
            Nome = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
            If Left(Nome, 1) = " " Then Nome = Chr(48) & Right(Nome, 1)
            'NewF$ = Workdir + chr$(92) + job$ + Testo + ".MEC"   !!!!!!!!!!!!
            NewF = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + Nome + ".MEC"
            If Len(Dir(NewF)) = 0 Then
                Testo = Testo & Str(Nrdit \ 2) & ") " & Trim(Item(j)) & vbCrLf
                '   Testo = "L'item " + RTrim$(Item$(j)) + " non e'  |" + at1(33)
                '    Testo = Testo + "stato ancora dimensionato.  |"
                '    Testo = Testo + "Vuoi procedere comunque?    |"
                ' X = MsgBox(Monitor.Motore.Inizio.converticr(Testo), vbQuestion + vbYesNoCancel)
                NonDim = True
            Else
                FileOpen(33, NewF, OpenMode.Random, , , Len(Mecdata0))
                If LOF(33) < Len(Mecdata0) Then
                    FileClose(33)
                    IO.File.Delete(NewF)
                    NonDim = True
                    Testo = Testo & Str(Nrdit \ 2) & ") " & Trim(Item(j)) & vbCrLf
                Else
                    FileClose(33)
                End If
            End If
        Next j 'i
        If NonDim Then
            Testo = Testo & "Vuoi procedere comunque?"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X = MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "ISA")
            If X = MsgBoxResult.Cancel Or X = MsgBoxResult.No Then GoTo Fine
        End If
        job.Comm.Ind(1).Data.Assieme = "$" ' Chr$(36)
        job.Comm.Ind(2).Data.Assieme = "0" ' Chr$(48)
        'Put #1, 1, Lav(0)
        'ifl = FreeFile()
        'FileOpen(ifl, CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(RTrim(job.contratto)) + CDbl(".TE1")), OpenMode.Random, , , Len(Lav(0)))
        'FilePut(ifl, Lav(0), 1)
        'FileClose(ifl)
        CatStruct()
Fine:   job = job1
    End Sub
    Sub DatFin()
        Dim i As Short
        Dim Archiv(5) As Short
        Dim dAiu(5) As String
        Dim LungSt(5) As Short
        'Itemn.St = LTRIM$(job.Comm.Ind(1).Data.Assieme)
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))) > 0 Then IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        'SETRDIT Itemn, Nrdit
        GETFIN()
        FileOpen(3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        For i = 1 To 4
            Risp(i) = LineInput(3)
            If i = 1 And Len(LTrim(RTrim(Risp(i)))) = 0 Then
                Risp(i) = Left(job.Contratto, 4) 'sistemare con default
            End If
            LungSt(i) = Len(Risp(i))
        Next i
        FileClose(3)
        Dom(1) = "Commessa         :"
        Dom(2) = "Costruttore vent.:"
        Dom(3) = "Materiale pale   :"
        Dom(4) = "Materiale mozzo  :"
Rifa5:
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(4, "Dati finali", Dom, Risp, "", Archiv, dAiu) Then Exit Sub
        If Not Len(LTrim(RTrim(Risp(1)))) = 4 Then
            '     a$ = "Nome della commessa illegale.     |"
            'a$ = a$ + "(1..4 caratteri):ripetere      !  |"
            MostraAiuto(IDH_STR_NUMCOMM)
            Risp(1) = "xxxx" : LungSt(1) = 4
            GoTo Rifa5
        End If
        FileOpen(2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        For i = 1 To 4
            Risp(i) = Risp(i).PadRight(LungSt(i))
            PrintLine(2, Risp(i))
        Next
        FileClose(2)
        DATIFIN()
        job.Contratto = Risp(1)
    End Sub
    Public Sub CatStruct()
        Dim iff As Short
        Dim Fstr As String
        Dim OKStr As Boolean
        Dim Testo, File As String
        Dim junk As Integer
        Dim Nome, Riga As String
        Dim i As Short
        Dim Bank As String
        Dim i1, n As Short
        Dim n1 As Short
        Dim ItemLoc As String
        Dim X As Integer
        Dim itp As String
        Dim Ib, j As Short
        Dim ik, k As Short
        Dim comm As String
        Dim Help As String
        Dim Archiv(30) As Short
        Dim dAiu(30) As String
        Dim Tit As String
        Dim ikk As Short
        Dim Risp1(99) As String
        Dim dist, Fil As String
        Dim Scelta(30) As Boolean
        Dim v As RoutBase1.ValoriComm
        Dim Esito As Integer
        Matdim = New LibMat.MaterialeNew1
        InitFlangia()
        Pipe = New LibMat.clsPipe
        Tira = New LibMat.clsTira
        iff = FreeFile()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Fstr = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(RTrim(job.Contratto)) + CDbl(".STR"))
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Fstr)) > 0 Then
20:         FileOpen(iff, Fstr, OpenMode.Input)
            If LOF(iff) = 0 Then GoTo Nostr
            OKStr = True
        Else
Nostr:
            OKStr = False
            FileClose(iff)
            Testo = " Non sembra essere stato eseguito|"
            Testo = Testo & " il sommario. Vuoi continuare    |"
            Testo = Testo & " ugualmente?"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            junk = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
            If junk = MsgBoxResult.No Then GoTo Uscita
        End If
        If Not OKStr Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            File = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(RTrim(job.Contratto)) + CDbl("*.MEC"))
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            Nome = Dir(File)
            i = 0
            Do
                If Len(Nome) > 0 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Nome = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Nome))
30:                 FileOpen(33, Nome, OpenMode.Random, , , Len(Mecdata0))
                    Mecdata0.Initialize()
                    FileGet(33, Mecdata0, 1)
                    i = i + 1
                    Item(i) = Mecdata0.ITEMNO
                    BankR(i) = Mecdata0.BANCO
                    Nfas(i) = Mecdata0.NFASCI
                    FileFil(i) = Mecdata0.Mec
                    Testo = Right(Nome, 6)
                    NumNum(i) = Val(Left(Testo, 2))
                    '   Cust$ = Mecdata0.CUSTMR
                    FileClose(33)
                    'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    Nome = Dir()
                Else
                    Exit Do
                End If
            Loop
        Else
            i = 0
            Do
                If EOF(iff) Then Exit Do
                Riga = LineInput(iff)
                If Left(Riga, 1) = "B" Then
                    Bank = Mid(Riga, 7, 4)
                    i1 = Val(Bank)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If i1 > 0 Then Bank = GlobalRoutines.myStr(CSng(i1), 4, 0, True)
                ElseIf Left(Riga, 1) = " " Then
                ElseIf Left(Riga, 1) = "I" Then
                    n = InStr(Riga, "|")
                    Nrdit = Val(Mid(Riga, n + 1, 3))
                    n1 = InStr(Riga, ":")
                    ItemLoc = Mid(Riga, n1 + 1, n - n1 - 1)
                    Testo = GlobalRoutines.Str2Cifre(Nrdit)
                    File = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + Testo + ".MEC"
40:                 FileOpen(33, File, OpenMode.Random, , , Len(Mecdata0))
                    If LOF(33) = 0 Then
                        '       Testo = "L'item " + ItemLoc + " non e' stato  |"
                        '  Testo = Testo + "ancora dimensionato meccanicamente.|"
                        '  Testo = Testo + "Vuoi esaminare gli altri items?   |"
                        '  Testo = Monitor.Motore.Inizio.converticr(Testo)
                        '  X = MsgBox(Testo, vbQuestion + vbYesNo)
                        FileClose(33)
                        '  If X <> vbYes Then GoTo Uscita
                    Else
                        Mecdata0.Initialize()
                        FileGet(33, Mecdata0, 1)
                        i = i + 1
                        Item(i) = ItemLoc : Mecdata0.ITEMNO = ItemLoc
                        BankR(i) = Bank : Mecdata0.BANCO = Bank
                        FileFil(i) = RTrim(job.Contratto) & Testo & ".MEC"
                        'era Lav(0).job
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Nfas(i) = objDatBase.CVI(objDatBase.DatBase(4, 3, Nrdit, 1, itp, 0))
                        If Nfas(i) < 1 Then
                            Testo = " Attenzione . N. fasci dell'item |"
                            Testo = Testo & Item(i) & " pari a" & Str(Nfas(i)) & " |"
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                            MsgBox(Testo, MsgBoxStyle.Information)
                        End If
                        Mecdata0.NFASCI = Nfas(i)
                        Mecdata0.Mec = FileFil(i)
                        NumNum(i) = Nrdit
                        FilePut(33, Mecdata0, 1)
                        FileClose(33)
                    End If
                Else
                    Stop
                End If
            Loop
        End If
        FileClose(iff)
        Ib = 0
        If i > 1 Then
            'FOR j = 1 TO i - 1
            For j = 1 To i
                If Len(BankR(j)) > 0 Then
                    Ib = Ib + 1
                    NomBankR(Ib) = BankR(j)
                    ik = 1
                    iBank(Ib, ik) = j
                    For k = j + 1 To i
                        If LTrim(RTrim(BankR(k))) = LTrim(RTrim(BankR(j))) Then
                            BankR(k) = ""
                            ik = ik + 1
                            iBank(Ib, ik) = k
                        End If
                    Next
                End If
            Next
        ElseIf i = 1 Then
            Ib = 1 : NomBankR(Ib) = BankR(1) : iBank(1, 1) = 1
        Else
            Testo = "Operazione abbandonata per mancanza|"
            Testo = Testo & "di dati sufficienti. Ripassiamo UPM?.|"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            X = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
            If X = MsgBoxResult.Yes Then
                'Catena "UPM"
                Stop
            Else
                'Catena "HTRI"
                Stop
            End If
        End If
        '---------------------------------------------------------------
        job = New RoutBase1.clsjob(Monitor.Motore)
        comm = objDatBase.Readreco(1, 46, 2)
        Nome = Monitor.Motore.Inizio.Workdir + "\" + comm + ".JOB"
        Dim Contr As String
        Monitor.Motore.Retrievejob(Contr, Nome)
        Dim counter As Short
        counter = Ib
        For j = 1 To counter
            If Val(BankR(j)) = 0 Then
                Ib = j - 1
                Exit For
            End If
        Next
        For j = 1 To Ib
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.Str2Cifre(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = GlobalRoutines.Str2Cifre(j)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If j < job.Coll.Count Then 'Asc(jobs.Arch(j)) < 33 Then
                Risp(j) = comm & Testo
            Else
                i1 = Val(NomBankR(j))
                'If i1 > 0 And Val(job.Coll(j).Arch) = 0 Then
                Testo = Str(i1)
                If Len(Testo) > 2 Then Testo = Right(Testo, 2) Else Testo = "0" & Right(Testo, 1)
                Risp(j) = comm & Testo 'Left$(job.Coll(j).Arch, 4) + Testo
                'ElseIf Val(job.Coll(j).Arch) > 0 Then
                '  Risp$(j) = job.Coll(j).Arch
                'Else
                '  Risp$(j) = Str$(j)
                'End If
            End If
            Dom(j) = "Banco " & NomBankR(j)
            'LungSt(j) = Len(Risp$(j))
        Next
        Tit = "Composizione commesse"
        Help = "Inserire i numeri di commessa|"
        Help = Help & "corrispondenti ai banchi     |"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Help = Monitor.Motore.Inizio.ConvertiCr(Help)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(Ib, Tit, Dom, Risp, Help, Archiv, dAiu) Then GoTo Uscita
        '------------------------------------------------------------
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If job.Coll.Count < Ib Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            For j = job.Coll.Count + 1 To Ib
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.AggiungiCom. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                job.AggiungiCom(Risp(j))
            Next
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ElseIf job.Coll.Count > Ib Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            For j = Ib To job.Coll.Count + 1 Step -1
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                job.Coll.remove(j)
            Next
        End If
        'salvataggio dati generali===============================
        For j = 1 To Ib
            job.RetrieveCom(j)
            'job.comm.Arch = Risp$(j)
            job.Comm.Clie = objDatBase.Readreco(1, 5, 10)
            job.Comm.NBank = Val(NomBankR(j))
            job.Comm.SalvaCom()
            Risp(j) = job.Comm.Arch
            Scelta(j) = True
        Next
        '========================================================
        Testo = "Specificare le commesse di cui|"
        Testo = Testo & "si vuole generare la Distinta Base."
        Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
        If Ib > 1 Then
            If Not Monitor.Motore.CheckQuale(Ib, "Commesse da trattare", Risp, Scelta, Testo) Then GoTo Uscita
        Else
            Scelta(1) = True
        End If
        '   nome$ = Monitor.Motore.Inizio.workdir + "\" + job.Coll(j).Arch + ".TEM"
        '60 Open nome$ For Random As #33 Len = Len(Lav(0))
        '   If LOF(33) > 0 Then Get #33, 1, Lav(1)
        dist = CStr(Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch)
        '62 MkDir dist$
        '63 '  Lav(1).Prev = job.contratto
        '   Lav(1).Prev = comm$
        '   Lav(1).Arch = jobs.Arch(j)
        '   Lav(1).Clie = Readreco(1, 5, 10)
        '   Lav(1).NumAs = 1
        For j = 1 To Ib
            If Not Scelta(j) Then GoTo Vai
            job.RetrieveCom(j)
            For ik = 1 To 30
                If iBank(j, ik) = 0 Then
                    'Lav(1).File(ik) = " "
                    'Lav(1).Assieme(ik) = " "
                    'Lav(1).Qta(ik) = 0
                Else
                    If job.Comm.Ind.Count < ik Then
                        v = New RoutBase1.ValoriComm
                        job.Comm.Ind.Add(v)
                    End If
                    If Len(job.Comm.Ind(ik).Data.File) > 0 Then
                        If Asc(job.Comm.Ind(ik).Data.File) < 32 Then job.Comm.Ind(ik).Data.File = ""
                    End If
                    If Len(Trim(job.Comm.Ind(ik).Data.File)) <> 3 Then job.Comm.Ind(ik).Data.File = LTrim(Str(600 + ik)) 'Lav(1).File(ik) = LTrim$(Str$(600 + ik))
                    job.Comm.Ind(ik).Data.Assieme = Item(iBank(j, ik))
                    job.Comm.Ind(ik).Data.Qta = Nfas(iBank(j, ik))
                    'Lav(1).Qta(ik) = Nfas(iBank(j, ik))
                End If
            Next ik
66:         ikk = 0
            For ik = 1 To job.Comm.Ind.Count
                If job.Comm.Ind(ik).Data.Qta > 0 Then
                    ikk = ikk + 1
                    Dom(ikk) = job.Comm.Ind(ik).Data.Assieme '(ik)
                    Risp1(ikk) = job.Comm.Ind(ik).Data.File '(ik)
                End If
            Next ik
            Tit = "Disegni Co." + job.Comm.Arch
            Help = Monitor.Motore.Inizio.ConvertiCr("Fornire le ultime tre |cifre del disegno testata|")
            Monitor.Motore.Chiamante = Monitor
            If Not Monitor.Motore.InputDati(ikk, Tit, Dom, Risp1, Help, Archiv, dAiu) Then GoTo Uscita
            ikk = 0
            For ik = 1 To job.Comm.Ind.Count
                If job.Comm.Ind(ik).Data.Qta > 0 Then
                    ikk = ikk + 1
                    job.Comm.Ind(ik).Data.File = Risp1(ikk)
                    If Len(Risp1(ikk)) > 0 Then
                        actComm = job.Comm
                        Esito = makeAPR(ik, dist, RTrim(job.Comm.Ind(ik).Data.File), FileFil(iBank(j, ik)), NumNum(iBank(j, ik)), False) ' = 0 Then GoTo Uscita
                        If Esito = ChiaviMess.MessCancel Then Exit For
                    End If
                End If
            Next ik
            job.Comm.Asse = "Ho"
            job.Comm.CalcBaric = False
            job.Comm.LungM = 12000
            job.Comm.LargM = 2500
            job.Comm.SalvaCom()
Vai:
        Next j
Uscita:
        If Not job Is Nothing Then job.Salva()
        FileClose(33) : FileClose(iff)
    End Sub
    Sub CercaMat(ByRef Mater As String, ByRef iMat As Short, ByRef Classe As String, ByRef i1 As Short, ByRef i2 As Short, ByRef i3 As Short, ByRef i4 As Short, ByRef i5 As Short, ByRef i6 As Short, ByRef i7 As Short, ByRef i8 As Short, ByRef i9 As Short)
        Dim IndInd As Short
        Dim Testo As String ',ii As Integer
        Dim Clas As Short
        IndInd = Inquire(RTrim(Mater), iMat)
        If IndInd = 0 And iMat = 0 Then
            If Left(Mater, 1) = "*" Then
                Testo = "Scegliere il materiale per " & Classe
            Else
                Testo = "Il materiale selezionato per |"
                Testo = Testo & Classe & " e':" & Mater
                Testo = Testo & "|Operare conversione.         |"
            End If
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            Dim FormScelMat As New frmScelMat
            FormScelMat.Label1.Text = Testo
            If i1 > 0 Then
                Matdim.Classe = 1 'ii = ii + 1: Matdim.IndAdd ii, i1
            ElseIf i2 > 0 Then
                Matdim.Classe = 2 'ii = ii + 1: Matdim.IndAdd ii, i2
            ElseIf i3 > 0 Then
                Matdim.Classe = 3 'ii = ii + 1: Matdim.IndAdd ii, i3
            ElseIf i4 > 0 Then
                Matdim.Classe = 4 'ii = ii + 1: Matdim.IndAdd ii, i4
            ElseIf i5 > 0 Then
                Matdim.Classe = 5 'ii = ii + 1: Matdim.IndAdd ii, i5
            ElseIf i6 > 0 Then
                Matdim.Classe = 6 'ii = ii + 1: Matdim.IndAdd ii, i6
            ElseIf i7 > 0 Then
                Matdim.Classe = 7 'ii = ii + 1: Matdim.IndAdd ii, i7
            ElseIf i8 > 0 Then
                Matdim.Classe = 8 'ii = ii + 1: Matdim.IndAdd ii, i8
            ElseIf i9 > 0 Then
                Matdim.Classe = 9 'ii = ii + 1: Matdim.IndAdd ii, i9
            End If
            Matdim.Indmat = 0
            '    Matdim.Classe = 0
            FormScelMat.Matdim = Matdim
            FormScelMat.ShowDialog()
            FormScelMat.Dispose()
            Registra(RTrim(Mater))
        ElseIf IndInd = 0 Then
            Matdim.Indmat = iMat
            Matdim.RecupMat(Monitor.Motore.Inizio.Archdir)
        End If
        Mater = Matdim.MatStr
    End Sub
    Sub ContrSuccS(ByRef i As Short, ByRef Nfile As Short, ByRef NfilSopra As Short, ByRef H1 As Single, ByRef h2 As Single, ByRef Log1 As Boolean, ByRef Log2 As Boolean)
        Dim NVs, j2 As Short
        Dim Vs As Single
        'se Log1 e Log2 allora anche i setti verticali successivi sono attaccati a H1 e/o H2
        Log1 = False : Log2 = False
        If i < Nfile Then
            NVs = HeaderSetti(0).Fila(i + 1 + NfilSopra).NumSettiV
            For j2 = 1 To NVs
                Vs = HeaderSetti(0).Fila(i + NfilSopra + 1).SettiV(j2)
                If h2 = -1 Then
                    Log2 = False
                ElseIf System.Math.Abs(Vs - h2) < 2 Then
                    Log2 = True 'controlla chi comanda
                End If
                If H1 = -1 Then
                    Log1 = False
                ElseIf System.Math.Abs(Vs - H1) < 2 Then
                    Log1 = True 'controlla chi comanda
                End If
            Next
        End If
    End Sub
    Sub EndPlate(ByRef iTest As Short, ByRef iCassa As Short)
        Record.Dati(3) = Mecdata0.HX3 + ReadLib(25, 1)
        Record.Dati(5) = 0.0!
        Record.Denom = "PIAS.LAT." & UCase(Mecdata0.HEADER)
        Record.Note = "END PLATE"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iTest. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If iTest = 3 Or iTest = 4 Then
            Record.Dati(1) = Mecdata0.SP(1 - 1)
            Record.Dati(5) = Mecdata0.DF(5 - 1)
            Record.Dati(2) = Mecdata0.H + ReadLib(25, 2) + ReadLib(25, 1) / 2 + Mecdata0.Nasello
        Else
            Record.Dati(1) = Mecdata0.SP(4 - 1)
            Record.Dati(2) = Mecdata0.H + ReadLib(25, 1) + Mecdata0.Nasello
        End If
        Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
        Record.Qta = CInt("2 ")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iTest. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Mecdata0.Tipo = 0 And Not (iTest = 3 Or iTest = 4) Then Record.Qta = CInt(" 4")
    End Sub

    Sub Fermi()
        Dim Dime2, Dime1, Spess As Single
        Dim Tit, Help As String
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Dim Nfield As Short
        Dime1 = ReadLib(2, 1) 'Lunghezza
        Dime2 = ReadLib(2, 2) 'Larghezza
        Spess = ReadLib(2, 3)
        Tit = "Fermi Cassa"
        Help = "Help non disponibile"
        Dom(2) = "Spessore  "
        Risp(2) = GlobalRoutines.myStr(Spess, 3, 1, False)
        Dom(1) = "(Sp. setti:" & Str(Mecdata0.SP(3)) & ")" : Risp(1) = ""
        Dom(3) = "Larghezza  "
        Risp(3) = GlobalRoutines.myStr(Dime2, 3, 1, False)
        Dom(4) = "Lunghezza  "
        Risp(4) = GlobalRoutines.myStr(Dime1, 3, 1, False)
        Nfield = 4 ': For i = 1 To Nfield: LungSt(i) = Len(Risp$(i)): Next
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDati(Nfield, Tit, Dom, Risp, Help, Archiv, dAiu)
        Record.Dati(1) = Val(Risp(2))
        Record.Dati(2) = Val(Risp(3))
        Record.Dati(3) = Val(Risp(4))
        Call CercaMat(Mecdata0.MATUG, Mecdata0.iMATUG, "i fermi cassa", 1, 1, 0, 0, 0, 0, 0, 0, 0)
        Record.MATE = Matdim.MatStr
        Record.Indmat = Matdim.Indmat
        Record.PSP = Matdim.PSP
        Record.Tipo = 15
        Record.Denom = "FERMO CASSA"
        Record.Note = "HEADER STOP"
        Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
        Record.Qta = CInt(" 8")
    End Sub

    Sub FilSopraS(ByRef iSopra As Short, ByRef NfilSopra As Short)
        Dim i As Short
        If iSopra > 0 Then
            Mec.initialize()
            FileGet(34, Mec, iSopra)
            NfilSopra = 0
            For i = 1 To 16
                NfilSopra = NfilSopra + System.Math.Abs(Mec.Nfile(i))
            Next
        Else
            NfilSopra = 0
        End If
    End Sub

    Sub GuaTap(ByRef Nrdit As Short)
        Dim Mater, itp As String
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Mater = objDatBase.DatBase(2, 22, Nrdit, 1, itp, 1)
        Call CercaMat(Mater, 0, "guarnizioni dei tappi", 1, 1, 0, 0, 0, 0, 0, 0, 1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.MATE = Matdim.MatStr
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Indmat = Matdim.Indmat
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.PSP = Matdim.PSP
        Record.Tipo = 28
        Record.Denom = "GUARNIZIONE"
        Record.Note = "PLUG GASKET"
        Record.Dati(1) = 0.0!
        Record.Dati(2) = 0.0!
        Record.Dati(3) = 0.0!
        Record.DIME = ""
        Record.Qta = CInt(Str(Mecdata0.NTUB * 2))
    End Sub

    Sub InfSup(ByRef iTest As Short, ByRef iCassa As Short)
        Record.Denom = "P.INF-SUP " & UCase(Mecdata0.HEADER)
        Record.Note = "TOP-BOTTOM PLATE"
        Record.Dati(1) = Mecdata0.SP(1 - 1)
        Record.Dati(2) = Mecdata0.H
        If iTest = 3 Or iTest = 4 Then
            Record.Dati(2) = Mecdata0.H + ReadLib(25, 2) + Mecdata0.Nasello ' + ReadLib(25, 1) / 2
            Record.Dati(3) = Mecdata0.Largf
            Record.Dati(5) = Mecdata0.DF(5 - 1)
        Else
            Record.Dati(3) = Mecdata0.Largf
        End If
        Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
        Record.Qta = CInt(" 2")
        'IF Mecdata0.Tipo = 0 AND NOT (iTest = 3 OR iTest = 4) THEN Record.Qta = " 4"
        If Mecdata0.Tipo = 0 Then Record.Qta = CInt(" 4")
    End Sub

    Function Inquire(ByRef Matt As String, ByRef iMat As Short) As Short
        Dim i As Short
        For i = 1 To Nquire
            If Matt = Materiali(i) Then
                '   ifl = FreeFile
                '80 Open Monitor.Motore.inizio.archdir + "\material.new" For Random Shared As #ifl Len = Len(Matdim)
                '   Get #ifl, IndMateriali(i), Matdim
                '   Close #ifl
                '   Inquire = 1
                Matdim.Indmat = IndMateriali(i)
                Matdim.RecupMat(Monitor.Motore.Inizio.Archdir)
                iMat = Matdim.Indmat
                Exit Function
            End If
        Next
        Inquire = 0
    End Function

    Sub MaterCassa()
        Dim Testo As String
        '**************************************************************
        If Mecdata0.MATHOM = 2 Then
            Testo = "Materiali cassa disomogenei. |"
            Testo = Testo & "      LAVORI IN CORSO!       |"
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo))
        Else
            Call CercaMat(Mecdata0.MATUG, Mecdata0.iMATUG, "la cassa", 1, 1, 0, 0, 0, 0, 0, 0, 0)
            Record.MATE = Matdim.MatStr
            Record.Indmat = Matdim.Indmat
            Record.PSP = Matdim.PSP
            Record.Tipo = 15
        End If
    End Sub

    Function NumFile(ByRef iCassa As Short) As Short
        Dim iC, n As Short
        Dim Testo As String
        Dim i As Short
        If iCassa = 0 Then iC = 1 Else iC = iCassa
        mec.initialize()
        FileGet(34, Mec, iC)
        For i = 1 To Mec.NS + 1
            n = n + System.Math.Abs(Mec.Nfile(i))
        Next
        If n = 0 Then
            Testo = " Ci sono dei problemi con i dati |"
            Testo = Testo & " relativi al dimensionamento mec-|"
            Testo = Testo & " canico. Ripassare UPM."
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            MsgBox(Testo)
        End If
        NumFile = n
    End Function

    Sub Register(ByRef ik As Short)
        Record.Ind = Record.Ind + 1
        'Lav(1).Ind(ik) = Lav(1).Ind(ik) + 1
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(44, Record, Record.Ind)
    End Sub

    Private Sub Registra(ByRef Matt As String)
        Nquire = Nquire + 1
        If Nquire > 30 Then
            MsgBox("errore in STRUCT Registra")
            Stop
        End If
        Materiali(Nquire) = Matt
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        IndMateriali(Nquire) = Matdim.Indmat
    End Sub

    Sub StdBoc(ByRef DBoc As Single, ByRef iRec As Short, ByRef indice As Short)
        Dim iSch As String
        Select Case DBoc
            Case 6 : iRec = 5
            Case 8 : iRec = 6
            Case 10 : iRec = 7
            Case 12 : iRec = 8
            Case Else
                MsgBox("Valore DBoc non previsto:")
        End Select
        Pipe = New LibMat.clsPipe
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pipe.Diam = DBoc
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Schedula. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pipe.Schedula = iSch
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Spess. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pipe.Spess = ReadLib(iRec, 2)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Cerca. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pipe.Cerca(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
        'SearchPipe Pipe, iSch, CSng(DBoc), CSng(ReadLib(iRec, 2))
        If indice > 0 Then
            RecordD(indice).Dati(1) = ReadLib(iRec, 1) 'ALTEZZA
            RecordD(indice).Dati(2) = ReadLib(iRec, 2) 'DIAMETRO
            RecordD(indice).Dati(3) = ReadLib(iRec, 3) 'SPESSORE
            RecordD(indice).Dati(4) = 0 'iSch
        Else
            Record.Dati(1) = ReadLib(iRec, 1) 'ALTEZZA
            Record.Dati(2) = ReadLib(iRec, 2) 'DIAMETRO
            Record.Dati(3) = ReadLib(iRec, 3) 'SPESSORE
            Record.Dati(4) = 0 'iSch
        End If
    End Sub

    Sub SuppTeflon()
        Call CercaMat(Mecdata0.MATUG, Mecdata0.iMATUG, "i supp.TEFLON", 1, 1, 0, 0, 0, 0, 0, 0, 0)
        Record.MATE = Matdim.MatStr
        Record.Indmat = Matdim.Indmat
        Record.PSP = Matdim.PSP
        Record.Denom = "SUPPORTO TEFLON"
        Record.Note = "TEFLON SUPPORT"
        Record.Dati(1) = 8
        Record.Dati(2) = 80
        Record.Dati(3) = 140
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
        Record.Qta = CInt(" 4")
    End Sub

    Private Sub Tappi()
        Dim DOinch As Single
        Call CercaMat(Mecdata0.MATTAP, Mecdata0.iMATTAP, "i tappi", 0, 0, 0, 0, 0, 0, 1, 0, 0)
        DOinch = Mecdata0.DO_Renamed / 25.4
        If System.Math.Abs(DOinch - 1.0!) < 0.1 Then
            Record.DIME = "$ 1 1/8"
        ElseIf System.Math.Abs(DOinch - 1.25) < 0.1 Then
            Record.DIME = "$ 1 1/2"
        ElseIf System.Math.Abs(DOinch - 1.5) < 0.1 Then
            Record.DIME = "$ 1 1/2"
        End If
        Record.DIME = RTrim(Record.DIME) & Chr(34) & " 12UNF-2"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.MATE = Matdim.MatStr
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Indmat = Matdim.Indmat
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.PSP = Matdim.PSP
        Record.Tipo = 29
        Record.Denom = "TAPPO"
        Record.Note = "PLUG"
        Record.Qta = CInt(Str(Mecdata0.NTUB * 2))
    End Sub

    Sub Targa()
        Record.Tipo = 24
        Record.Denom = "TARGA"
        Record.Dati(1) = 0.0!
        Record.Dati(2) = 0.0!
        Record.Dati(3) = 0.0!
        Record.DIME = ""
        Record.Note = "NAMEPLATE"
        Record.Indmat = 0
        Record.MATE = ""
        Record.Qta = CInt(" 1")
    End Sub

    Sub TipizzS(ByRef iCassa As Short, ByRef iRec As Short, ByRef iSopra As Short)
        Select Case Mecdata0.Tipo
            Case 1
                iSopra = 0
                iRec = 4 + iCassa
            Case 2
                Select Case iCassa
                    Case 1
                        iSopra = 0
                        iRec = 5
                    Case 2
                        iSopra = 1
                        iRec = 5
                    Case 3
                        iSopra = 0
                        iRec = 6
                End Select
            Case 3
                Select Case iCassa
                    Case 1
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 0
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 5
                    Case 2
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 0
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 6
                    Case 3
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 2
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 6
                End Select
            Case 4
                Select Case iCassa
                    Case 1
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 0
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 5
                    Case 2
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 1
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 5
                    Case 3
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 0
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 6
                    Case 4
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iSopra. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iSopra = 3
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto iRec. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        iRec = 6
                End Select
        End Select
    End Sub

    Sub Tubi()
        Call CercaMat(Mecdata0.MATTUB, Mecdata0.iMATTUB, "i tubi", 0, 0, 0, 1, 0, 0, 0, 0, 0)
        Record.MATE = Matdim.MatStr
        Record.Indmat = Matdim.Indmat
        Record.PSP = Matdim.PSP
        Record.Tipo = 8
        Record.Denom = "TUBO ALETTATO"
        Record.Note = "FINNED TUBE"
        Record.Dati(1) = Mecdata0.DO_Renamed 'DE
        Record.Dati(2) = CShort(Mecdata0.LUNGF) 'Lunghezza
        Record.Dati(3) = Mecdata0.SPTUB 'spessore
        Record.Dati(4) = 1 '1=MW else AW
        If Mecdata0.SPTOL <> "MI" Then Record.Dati(4) = 0
        Record.Dati(5) = 0 '1=inox else no
        Record.Qta = CInt(Str(Mecdata0.NTUB))
        Record.DIME = "$" & Right(Str(Mecdata0.DO_Renamed), Len(Str(Mecdata0.DO_Renamed)) - 1) & " L=" & LTrim(Str(Int(Mecdata0.LUNGF)))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(Mecdata0.SPTUB, 1, 2, False). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.MATE = RTrim(Record.MATE) & "(" + GlobalRoutines.myStr(Mecdata0.SPTUB, 1, 2, False) + Mecdata0.SPTOL + ")"
        Record.Note = Record.Note & " BWG=" & Mecdata0.SPBWG
    End Sub

    Sub TubiTappi(ByRef iTest As Short)
        'On Local Error GoTo ErrTT
        Select Case iTest
            Case 2, 12 'plug
                Record.Dati(3) = Mecdata0.Largf
                Record.Qta = CInt(" 2")
                If Mecdata0.Tipo = 0 Then Record.Qta = CInt(" 4")
                Record.Denom = "P.TUB-TAP " & UCase(Mecdata0.HEADER)
2000:           Record.Note = "TUBE-PLUG SHEET"
            Case 3 ' cover plate(stud)
                Record.Dati(3) = Mecdata0.Largf
                Record.Qta = CInt(" 1")
                If Mecdata0.Tipo = 0 Then Record.Qta = CInt(" 2")
                Record.Denom = "PIAS.TUB." & UCase(Mecdata0.HEADER)
2010:           Record.Note = "TUBE-SHEET"
            Case 4 'cover plate(thrubolt)
                Record.Dati(3) = Mecdata0.Largf
                Record.Qta = CInt(" 1")
                If Mecdata0.Tipo = 0 Then Record.Qta = CInt(" 2")
                Record.Denom = "PIAS.TUB." & UCase(Mecdata0.HEADER)
2020:           Record.Note = "TUBE-SHEET"
            Case Else
                Record.Denom = "FINTO"
                Record.Qta = CInt(" 1")
        End Select
        Record.Dati(1) = Mecdata0.SP(2)
        Record.Dati(2) = Mecdata0.HX3 + 2.0! * Mecdata0.SP(1)
        'Record.Dati(3) = Mecdata0.LARGF - 2! * Mecdata0.Sp(3)
        Record.Dati(4) = 0.0!
        Record.Dati(5) = 0.0!
2030:
        Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
        Exit Sub
        'ErrTT: Print "Errore in TubiTappi"; Err; Erl: Stop
    End Sub
    Function AdjASA(ByRef ASA As Short) As Short
        Dim Stringa(7) As String
        Dim X As Short
        Stringa(1) = " 150"
        Stringa(2) = " 300"
        Stringa(3) = " 400"
        Stringa(4) = " 600"
        Stringa(5) = " 900"
        Stringa(6) = "1500"
        Stringa(7) = "2500"
        If ASA = 0 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X = Monitor.Motore.Quale(7, "Rating bocchelli", Stringa, "", 1)
            ASA = Val(Stringa(X))
            Mid(Mecdata0.Rating, 6, 4) = Stringa(X)
            Mec.initialize()
            FileGet(34, Mec, 1)
            Mec.Rating = Mecdata0.Rating
            FilePut(34, Mec, 1)
        Else
            For X = 1 To 7
                If Val(Stringa(X)) = ASA Then Exit For
            Next
        End If
        AdjASA = X
    End Function

    Function makeAPR(ByRef ik As Short, ByRef dist As String, ByRef AssDwg As String, ByRef FileMec As String, ByRef Nrdit As Short, ByRef Singolo As Boolean) As Integer
        Dim X As Integer
        Dim itp, Testo As String
        Dim NC As Short
        Dim tFlangia, armI As Single
        Dim Lung, NC1, l, j As Short
        Dim Mater As String
        Dim Nquant, i, k1 As Short
        Dim ii, k2, k3, iMat As Short
        'verificare calcolo pipe per tronchetti e valori flange
        'On Local Error GoTo Errmake
        makeAPR = -1
        If Not Singolo Then
            Testo = "Si sta per generare la Distinta Base |"
            Testo = Testo & "dell'item" + actComm.Ind(ik).Data.Assieme + "|"
            X = MostraAiuto(IDH_DB_MANCASTRUTTURA, ChiaviMess.MessInformation Or ChiaviMess.MessYesNoCancel, Testo)
            If X = ChiaviMess.MessCancel Or X = ChiaviMess.Messno Then
                makeAPR = X
                Exit Function
            End If
        End If
        iTest = objDatBase.CVI(objDatBase.DatBase(2, 9, Nrdit, 1, itp, 0))
        FileDAT = dist & "\" & AssDwg & ".DAT"
        If Len(Dir(FileDAT)) > 0 Then
            Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS(Helpstringa(IDH_DB_ESISTEFILE), RTrim(actComm.Ind(ik).Data.Assieme), Right(dist, 6) & Trim(Str(actComm.Ind(ik).Data.File))))
            '        Testo = "Esiste già il file testate/telai |per l'item "
            'Testo = Testo + RTrim$(actComm.Ind(ik).Assieme) + " (dis." + Right$(dist$, 6) + actComm.Ind(ik).File
            'Testo = Testo + ")|Vuoi utilizzarlo ?"
            X = MostraAiuto(IDH_DB_ESISTEFILE, ChiaviMess.MessYesNoCancel Or ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton, Testo)
            If X = ChiaviMess.MessCancel Then
                Exit Function
            ElseIf X = ChiaviMess.MessSi Then
                Call Apri(dist, AssDwg)
                makeAPR = makeAPR1(ik, dist, AssDwg, FileDAT, Nrdit)
                FileClose(44)
                Exit Function
            End If
        End If
        Call Apri(dist, AssDwg)
        FileOpen(34, Monitor.Motore.Inizio.Workdir + "\" + FileMec, OpenMode.Random, , , Len(Mecdata0))
        FileGet(34, Mecdata0, 1)
120:    MaterCassa()
        NC = nCasse(Mecdata0.Tipo)
        For iCassa = 1 To NC
            If iCassa > 1 Then
                FileClose(34)
130:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FileOpen(34, CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(FileMec)), OpenMode.Random, , , Len(Mecdata0))
                'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(34, Mecdata0, iCassa)
            End If
            If Not LarghCassa(iCassa, Nrdit) Then makeAPR = 0 : FileClose(44) : FileClose(34) : Exit Function
131:
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(34, Mecdata0, iCassa)
            TubiTappi(iTest)
            Record.PosDis = 1 + 30 * (iCassa - 1)
            Register(ik)
            '--------------------------------------------------------------------
140:        InfSup(iTest, iCassa)
            Record.PosDis = 2 + 30 * (iCassa - 1)
            Register(ik)
            '--------------------------------------------------------------------
150:        EndPlate(iTest, iCassa)
            Record.PosDis = 3 + 30 * (iCassa - 1)
            Register(ik)
            '------------------------------------------------------------
            If Mecdata0.NS > 0 Then
160:            SETTO(iTest, iCassa, ik)
                Record.PosDis = 11 + 30 * (iCassa - 1)
                If nSett > 0 Then Register(ik)
                nSett = -1
170:            SETTO(iTest, iCassa, ik)
                Record.PosDis = 16 + 30 * (iCassa - 1)
                If nPart > 0 Then Register(ik)
                nSett = 0
            End If
            '------------------------------------------------------------
            Select Case iTest
                Case 3 'cover plate (stud)
                    Record.Dati(1) = Mecdata0.SP(4 - 1)
                    Record.Dati(2) = Mecdata0.Largf
                    Record.Dati(3) = Mecdata0.HX3 + Mecdata0.SP(1 - 1) * 2 '?????
                    Record.Dati(4) = Mecdata0.DF(5 - 1) 'toll.lav
                Case 4 'cover plate (thrubolt)
                    tFlangia = Mecdata0.TK(4)
                    armI = Mecdata0.TK(2)
                    Record.Dati(1) = Mecdata0.SP(4 - 1)
                    Record.Dati(2) = Mecdata0.Largf + armI * 4
                    Record.Dati(3) = Mecdata0.HX3 + Mecdata0.SP(1 - 1) * 2 + armI * 4 '?????
                Case Else
                    GoTo Salto
            End Select
            Record.Qta = CInt(" 1")
            If Mecdata0.Tipo = 0 Then Record.Qta = CInt(" 2")
            Record.Denom = "COPERCHIO " & UCase(Mecdata0.HEADER)
            Record.Note = "COVER" & Str(iCassa)
            Record.PosDis = 4 + 30 * (iCassa - 1)
            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
            Record.Qta = CInt("1 ")
            If Mecdata0.Tipo = 0 Then Record.Qta = CInt(" 2")
180:        Register(ik)
            Record.Dati(4) = 0.0!
            If iTest = 4 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Record.Qta = GlobalRoutines.myStr(2.0! * Val(CStr(Record.Qta)), 3, 0, True)
                Record.Denom = "FL.COP." & UCase(Mecdata0.HEADER)
                Record.Note = "COVER FLANGE"
                Record.PosDis = 25 + 30 * (iCassa - 1)
                Record.Dati(1) = tFlangia
                Record.Dati(2) = 2.0! * armI
                Record.Dati(3) = Mecdata0.Largf
                Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
190:            Register(ik)
                Record.PosDis = 26 + 30 * (iCassa - 1)
                Record.Dati(3) = Mecdata0.HX3 + Mecdata0.SP(1) * 2 + 4 * armI
                Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
200:            Register(ik)
            End If
Salto:
        Next iCassa
        '----------------------------------------------------
        If Mecdata0.TipTest = 3 Or Mecdata0.TipTest = 4 Then
            For iCassa = 1 To NC
                'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(34, Mecdata0, iCassa)
                Call CercaMat(Mecdata0.MATEN, Mecdata0.iMATEN, "le guarnizioni dei coperchi", 0, 0, 0, 0, 0, 0, 0, 0, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Record.MATE = Matdim.MatStr
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Record.Indmat = Matdim.Indmat
                Record.Denom = "GUARN." & UCase(Mecdata0.HEADER)
                Record.Note = "COVER GASKET" & Str(iCassa)
                Record.DIME = ""
                Record.PosDis = 114 + iCassa
                Record.Qta = CInt(" 1")
                Record.Tipo = 30
                Register(ik)
            Next iCassa
            '---------------------------------------------------
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(34, Mecdata0, 1)
            NC1 = NC : If NC1 < 2 Then NC1 = 2
            Record.Denom = "ORECCHIA DI S."
            Record.Note = "LIFTING LUG"
            Record.PosDis = 118
            Record.Qta = CInt(Str(2 * NC1))
            Call CercaMat(Mecdata0.MATUG, Mecdata0.iMATUG, "le orecchie", 1, 1, 0, 0, 0, 0, 0, 0, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.MATE = Matdim.MatStr
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Indmat = Matdim.Indmat
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.PSP = Matdim.PSP
            Record.Tipo = 15
            Record.Dati(1) = 12 : Record.Dati(2) = 150 : Record.Dati(3) = 120
            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
            Register(ik)
            '----------------------------------------------------------------------
            Call CercaMat("*(Matdim.tir)", 0, "i tiranti", 0, 0, 0, 0, 0, 0, 0, 1, 0)
            Record.Denom = "TIR.INT.FIL."
            Record.Note = "BOLT"
            Record.Tipo = 13
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            l = InStr(Matdim.MatStr, "-")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If l > 1 Then
                Record.MATE = Left(Matdim.MatStr, l - 1)
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Record.MATE = Matdim.MatStr
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.Scelta. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Tira.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
            'SearchTira Tira, Mecdata0.MATTP, 2 'tiranti ANSI
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Lung = Int((Mecdata0.SP(4) + Mecdata0.TK(4) + 1.5 * Val(Tira.Diam) + 3.0!) / 5 + 1) * 5
            Record.Dati(1) = Lung
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Dati(2) = Val(Tira.Diam)
            Record.Dati(3) = 0 'numero di dadi
            Record.Dati(4) = 0 'diam.installazione
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Dati(5) = Val(Tira.Diam)
            Record.Dati(6) = 2
            Record.Dati(7) = 1
            Record.Dati(9) = 0 'siamo sul tirante
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.DN. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.DIME = RTrim(Tira.DN) & " L=" & LTrim(Str(Lung))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Indmat = Matdim.Indmat
            Record.PosDis = 112
            Record.Qta = CInt(Str(Mecdata0.BF(3 - 1)))
            Register(ik)
            For j = 1 To 7 : Record.Dati(j) = 0 : Next
            '--------------------------------------------------------------------
            Call CercaMat("*(Matdim.ton)", 0, "i tondi", 0, 0, 1, 0, 0, 0, 0, 0, 0)
            Record.Denom = "VITE D'ESTR."
            Record.Note = "JACK SCREW"
            Record.PosDis = 110
            Record.DIME = "3/8'' 16UNC-2A"
            Lung = (Int((1.2 * Mecdata0.SP(4)) / 10) + 1) * 10
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Indmat = Matdim.Indmat
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.MATE = RTrim(Matdim.MatStr) & " (L=" & LTrim(Str(Lung)) & ")"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Indmat = Matdim.Indmat
            Record.Tipo = 23
            Record.Qta = CInt(Str(2 * NC1))
            Register(ik)
            '--------------------------------------------------------
            Record.Denom = "SPINA CILI. "
            Record.Note = "DOWEL"
            Record.PosDis = 109
            Lung = (Int((Mecdata0.TK(4) + 0.5 * Mecdata0.SP(4)) / 10) + 1) * 10
            Record.DIME = "$10x" & LTrim(Str(Lung)) & " UNI 1707"
            Record.Qta = CInt(Str(2 * NC1))
            Record.Dati(1) = 10 : Record.Dati(2) = Lung
            Register(ik)
            '----------------------------------------------------
            Call CercaMat("*(Matdim.dad)", 0, "i dadi", 0, 0, 0, 0, 0, 0, 0, 1, 0)
            Record.Denom = "DADO ESAG."
            Record.Note = "HEX.NUT"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            l = InStr(Matdim.MatStr, "-")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If l > 1 Then
                Record.MATE = Right(Matdim.MatStr, Len(Matdim.MatStr) - l - 1)
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Record.MATE = Matdim.MatStr
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.DN. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.DIME = Tira.DN
            Record.PosDis = 113
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Indmat = Matdim.Indmat
            Record.Tipo = 13
            Record.Dati(6) = 2
            Record.Dati(7) = 1
            Record.Dati(9) = 1 'siamo sul dado
            Record.Qta = CInt(Str(2 * Mecdata0.BF(3 - 1)))
            Register(ik)
            '----------------------------------------------------------------
        End If
        '----------------------------------------------------
        If Mecdata0.Tipo > 1 And (iTest < 3 Or iTest > 4) Then
            Call CercaMat("*dist.(" & LTrim(RTrim(Mecdata0.MATUG)) & ")", 0, "i distanziali", 1, 1, 0, 0, 0, 0, 0, 0, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.MATE = Matdim.MatStr
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Indmat = Matdim.Indmat
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.PSP = Matdim.PSP
            Record.Tipo = 15
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(34, Mecdata0, 1)
            Record.Dati(3) = 150 : Record.Dati(2) = 100.0! : Record.Dati(1) = 12.0!
            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
            Record.Qta = CInt(" 2")
            If Mecdata0.VuotA > 0.0! Then
                If Mecdata0.VuotA = ReadLib(27, 1) Then
                    Record.Denom = "DISTANZ. A"
                    Record.Note = "SPACER A"
                    Record.PosDis = 119
                Else
                End If
                Register(ik)
            End If
            If Mecdata0.VuotB > 0.0! Then
                If Mecdata0.VuotB = ReadLib(27, 1) Then
                    Record.Denom = "DISTANZ. B"
                    Record.Note = "SPACER B"
                    Record.PosDis = 120
                Else
                End If
                Register(ik)
            End If
        End If
        FileClose(34)
        '--------------------------------------------------------------------
210:    Fermi()
        Record.PosDis = 7
        Register(ik)
        '--------------------------------------------------------------------
220:    SuppTeflon()
        Record.PosDis = 8
        Register(ik)
        '**********************************************************************
        If iTest = 2 Then
230:        GuaTap(Nrdit)
            Record.PosDis = 4
            Register(ik)
            Tappi()
            Record.PosDis = 5
            If NC < 2 Then
                Register(ik)
            Else
                Record.Denom = "TAPPO CAS.INGR."
                Record.Note = "PLUG INL.HDR."
                Record.Qta = CInt(Str(Val(CStr(Record.Qta)) / 2))
                Register(ik)
                Record.Denom = "TAPPO CAS.USC. "
                Record.Note = "PLUG OUT.HDR."
                Record.PosDis = 5 + 30
                Register(ik)
            End If
        End If
250:    Tubi()
        Record.PosDis = 6
        Register(ik)
        '--------------------------------------------------------------------
260:    Targa()
        Record.PosDis = 9
        Register(ik)
        '------------------------------------------------------------------
        Record.Denom = "PORTATARGA"
        Record.Note = "NAMEPLATE SUPPORT"
        Record.PosDis = 10
        Record.Qta = CInt(" 1")
        Register(ik)
        '------------------------------------------
262:    If iTest = 2 Then
            Mater = Mecdata0.MATTAP
            iMat = Mecdata0.iMATTAP
        Else
            iMat = 0
            Mater = "*fuc.(" & LTrim(RTrim(Mecdata0.MATUG)) & ")"
        End If
        Record.Tipo = 10
        Record.Dati(1) = 5
263:    Call CercaMat(Mater, iMat, "i fucinati", 0, 0, 0, 0, 0, 0, 1, 0, 0)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.MATE = Matdim.MatStr
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.PSP = Matdim.PSP
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Indmat = Matdim.Indmat
        FileClose(34)
265:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileOpen(34, CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(FileMec)), OpenMode.Random, , , Len(Mecdata0))
        For iCassa = 1 To NC
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(34, Mecdata0, iCassa)
            If Mecdata0.nBocIn = 0 Or Mecdata0.DBocIn = 0.0! Then GoTo Salt1
267:        Call Flange(1)
            Record.PosDis = 13
266:        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(34, Mecdata0, iCassa)
270:        If Left(Mecdata0.Rating, 4) = "ANSI" Then Register(ik)
Salt1:
            If Mecdata0.nBocOut = 0 Or Mecdata0.DBocOut = 0 Then GoTo ContBoc
            Call Flange(2)
            Record.Qta = CInt(Str(Mecdata0.nBocOut))
            Record.PosDis = 15
271:        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(34, Mecdata0, iCassa)
272:        If Left(Mecdata0.Rating, 4) = "ANSI" Then Register(ik)
ContBoc:
        Next iCassa
        '-----------------------------------------
        For i = 1 To 4
            Call MANIC(i, j, Nrdit, Nquant, Mater)
            If Nquant > 0 Then
                Record.PosDis = 16 + i
243:            Register(ik)
            End If
            '-----------------------------------------
            If j = 0 Then
                If Nquant > 0 Then
                    Record.Dati(1) = 6 'Flangia non riportata
                    Record.Dati(2) = k1
                    Record.Dati(3) = k2
                    Record.Dati(4) = 5 'flangia cieca
                    Record.Dati(10) = 7 'flangia cieca
                    Record.Dati(7) = 1 'la flangia accoppiata Š cieca
                    Record.Denom = "FLANGIA CIECA"
                    Record.Note = "BLIND FLANGE"
                    l = InStr(Record.DIME, "?")
                    If l > 1 Then Record.DIME = Left(Record.DIME, l - 1)
                    l = InStr(Record.MATE, "(")
                    If l > 1 Then Record.MATE = Left(Record.MATE, l - 1)
                End If
            Else
                Select Case i
                    Case 1 : Record.Denom = "TAPPO SFIATO"
                        Record.Note = "VENT PLUG"
                    Case 2 : Record.Denom = "PRESA DI DRENAGGIO"
                        Record.Note = "DRAIN PLUG"
                    Case 3 : Record.Denom = "TAPPO PT"
                        Record.Note = "TEMP.CONNEC.PLUG"
                    Case 4 : Record.Denom = "TAPPO PP"
                        Record.Note = "PRESS.CONNEC.PLUG"
                End Select
            End If 'd
            If Nquant > 0 Then
                Record.PosDis = 120 + 4 * i
                Record.Tipo = 10
                Register(ik)
                For ii = 1 To 10 : Record.Dati(ii) = 0 : Next
            End If
245:        If j = 0 Then
                If Nquant > 0 Then
                    Call CercaMat("*SpW(" & LTrim(RTrim(Mecdata0.MATUG)) & ")", 0, "le guarn.bocch.", 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Indmat = Matdim.Indmat
                    Record.Denom = "GUARNIZIONE"
                    Record.Note = "GASKET"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.MATE = CStr(CDbl("SPIRAL WOUND(") + Matdim.MatStr + CDbl(")"))
                    Record.DIME = "$e" & Str(DiamGuar) 'Str$(aFl!(3, k3))
                    Record.Tipo = 28
                    Record.Qta = CInt(Str(Nquant))
                    Record.PosDis = 121 + 4 * i
                    Register(ik)
                    '----------------------------------------------------
                    Call CercaMat("*(Matdim.tir)", 0, "i tiranti", 0, 0, 0, 0, 0, 0, 0, 1, 0)
                    Record.Denom = "TIR.INT.FIL."
                    Record.Note = "BOLT"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    l = InStr(Matdim.MatStr, "-")
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If l > 1 Then
                        Record.MATE = Left(Matdim.MatStr, l - 1)
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Record.MATE = Matdim.MatStr
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Indmat = Matdim.Indmat
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.DN. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Tira.DN = TirDN 'NULLO
                    ' On Error Resume Next
                    Tira.Cerca(Monitor.Motore.Inizio.Archdir)
                    'On Error GoTo 0
                    'SearchTira Tira, TIRFl$(k3), 2 'tiranti ANSI
                    'Lung = Int((2 * (aFl!(5, 2) + aFl!(4, k3)) + 1.5 * Val(Tira.Diam) + 3!) / 5 + 1) * 5
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.DN. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.DIME = CStr(Tira.DN + " L." + CDbl(Str(Lung)))
                    Record.PosDis = 122 + 4 * i
                    Record.Qta = CInt(Str(4 * Nquant))
                    Record.Tipo = 13
                    Register(ik)
                    Call CercaMat("*(Matdim.dad)", 0, "i dadi", 0, 0, 0, 0, 0, 0, 0, 1, 0)
                    Record.Denom = "DADO ESAG."
                    Record.Note = "HEX.NUT"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    l = InStr(Matdim.MatStr, "-")
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If l > 1 Then
                        Record.MATE = Right(Matdim.MatStr, Len(Matdim.MatStr) - l - 1)
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Record.MATE = Matdim.MatStr
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Indmat = Matdim.Indmat
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tira.DN. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.DIME = Tira.DN
                    Record.PosDis = 123 + 4 * i
                    Record.Qta = CInt(Str(8 * Nquant))
                    Register(ik)
                End If 'a
            End If
        Next i
        '**********************************************************************
        If Mecdata0.Bcgl(1) < 2 Or Mecdata0.Bcgl(2) < 2 Then
            Call CercaMat("*tr.(" & LTrim(RTrim(Mecdata0.MATUG)) & ")", 0, "i tronchetti", 1, 1, 0, 0, 0, 1, 1, 0, 0)
            For i = 1 To 2
                If Mecdata0.Bcgl(i) < 2 Then
                    RecordD(i).Ind = Record.Ind
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record = RecordD(i)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Indmat = Matdim.Indmat
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.MATE = Matdim.MatStr
                    Record.Tipo = 2
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.PSP = Matdim.PSP
                    Record.PosDis = 12 + 2 * (i - 1)
                    Register(ik)
                End If
            Next
        End If
        '-------------------------------------------------------------------
        FileClose(34)
        FileClose(44)
        Exit Function
    End Function
    Private Sub Apri(ByVal dist As String, ByVal AssDwg As String)
        FileAPR = dist & "\" & AssDwg & ".APR"
        IO.File.Delete(FileAPR)
        FileOpen(44, FileAPR, OpenMode.Random, , , Len(Record))
        Record.Denom = "Orig./Asse apparecchio"
        Record.Ind = 1
        Record.Tipo = 0
        Record.PosDis = 0
        Record.Indmat = 0
        Record.posspa.SuChi = -1
        Record.MATE = " "
        Record.Qta = 0 ' " "
        Record.MF = " -- "
        FilePut(44, Record, 1)
        Record.posspa.SuChi = 1
    End Sub
    Function makeAPR1(ByRef ik As Short, ByRef dist As String, ByRef AssDwg As String, ByRef FileDAT As String, ByRef Nrdit As Short) As Boolean
        Dim Esito As Boolean
        Dim ifl As Short
        Dim r As String
        Dim l, ifl1, l1 As Short
        Esito = False
        makeAPR1 = Esito
        ifl = FreeFile()
        FileOpen(ifl, FileDAT, OpenMode.Input)
        ifl1 = FreeFile()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileOpen(ifl1, CStr(Monitor.Motore.Inizio.DiscoRam + "SCRA" + CDbl(RTrim(job.Contratto))), OpenMode.Output)
        Do
            r = LineInput(ifl)
            If EOF(ifl) Then FileClose(ifl) : Exit Function
            If Left(r, 1) = "$" Then
                Esito = True
                PrintLine(ifl1, r)
            ElseIf Esito Then
                FileClose(ifl) : FileClose(ifl1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FileOpen(ifl1, CStr(Monitor.Motore.Inizio.DiscoRam + "SCRA" + CDbl(RTrim(job.Contratto))), OpenMode.Input)
                Do
                    r = LineInput(ifl1)
                    l = InStr(r, "!")
                    Debug.Print(r)
                    PosDis = Mid(r, 2, l - 2)
                    l1 = InStr(l + 1, r, "!")
                    Denom = LTrim(Mid(r, l + 1, l1 - l - 2))
                    l = l1
                    l1 = InStr(l + 1, r, "!")
                    Note = LTrim(Mid(r, l + 1, l1 - l - 2))
                    l = l1
                    l1 = InStr(l + 1, r, "!")
                    DisDet = LTrim(Mid(r, l + 1, l1 - l - 2))
                    l = l1
                    l1 = InStr(l + 1, r, "!")
                    MATE = LTrim(Mid(r, l + 1, l1 - l - 2))
                    l = l1
                    l1 = InStr(l + 1, r, "!")
                    Qta = Mid(r, l + 1, l1 - l - 2)
                    l = l1
                    l1 = InStr(l + 1, r, "!")
                    DIME = LTrim(Mid(r, l + 1, l1 - l - 2))
                    l = l1
                    iTipo = Val(Mid(r, Len(r) - 3, 2))
                    '       PRINT PosDis$; Denom$; NOTE$; DisDet$; MATE$; Qta$; DIME$; iTipo: u$ = INPUT$(1)
                    Record.PosDis = Val(PosDis)
                    Record.Denom = Denom
                    Record.DIME = DIME
                    Record.Note = Note
                    Record.Qta = Val(Qta)
                    Record.Tipo = iTipo
                    Record.MF = " -- "
                    Select Case iTipo
                        Case 2 'tronchetti
301:                        If Left(Denom, 2) = "BO" Then
                                If Left(DIME, 1) = "$" Then
                                    Tronci()
                                Else
                                    DBoc = Val(DIME)
                                    Call StdBoc(DBoc, iRec, 0)
                                End If
                            Else
                                Tronci()
                                'caso tronchetti
                            End If
                            Call CercaMat(MATE, 0, "i tronchetti", 1, 1, 0, 0, 0, 1, 1, 0, 0)
                        Case 8 'tubi
302:                        FileOpen(ifl, FileDAT, OpenMode.Input)
                            Do
                                r = LineInput(ifl)
                                If EOF(ifl) Then Exit Do
                                If Mid(r, 3, 5) = "DIMEN" Then
                                    l = InStr(r, "!")
                                    l1 = InStr(l + 1, r, "!")
                                    l2 = InStr(l1 + 1, r, "!")
                                    l3 = InStr(l2 + 1, r, "!")
                                    Inter = Mid(r, l2 + 1, l3 - l2 - 2)
                                    D = Val(Mid(Inter, 5, 5))
                                    l = InStr(r, "X")
                                    SP = Val(Mid(r, l + 1, 6))
                                    l = InStr(r, "MIN")
                                    If l > 0 Then Record.Dati(4) = 1 Else Record.Dati(4) = 0
                                    l = InStr(r, "LG")
                                    Record.Dati(2) = Val(Mid(r, l + 3, 5))
                                    Record.Dati(3) = SP
                                    Record.Dati(1) = D
                                    Call CercaMat(MATE, 0, "i tubi", 0, 0, 0, 1, 0, 0, 0, 0, 0)
                                    Exit Do
                                End If
                            Loop
                            FileClose(ifl)
                        Case 10 'flange
303:                        l = InStr(DIME, Chr(34))
                            If l > 0 Then
                                DBocStr = Left(DIME, l - 1)
                                DBoc = GlobalRoutines.ConvPoll(DBocStr)
                                l = InStr(DIME, "??")
                                If l > 4 Then
                                    ASA = Val(Mid(DIME, l - 4, 4))
                                    If ASA = 0 Then ASA = Val(Mid(DIME, l - 3, 3))
                                    Flangia.K2 = AdjASA(ASA)
                                    Tipo = LTrim(Right(DIME, Len(DIME) - l - 1))
                                    Record.Dati(10) = 0
                                    Select Case Left(Tipo, 1)
                                        Case "W" : Tipo = CStr(1) 'welding neck
                                            Flangia.K3 = 1
                                        Case "L" : Tipo = CStr(2) 'LWN
                                            Flangia.K3 = 4
                                        Case "B" : Tipo = CStr(1) 'blind
                                            Flangia.K3 = 5
                                            Record.Dati(10) = 7 'flangia cieca
                                            Record.Dati(7) = 1 'la flangia accoppiata Š cieca
                                    End Select
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SetDiam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    Flangia.SetDiam(DBoc)
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Scelta. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    Flangia.Scelta(Monitor.Motore.Inizio.DiscoRam)
                                    'Flangia.k1 = 1
                                    'Flangia.Scelta
                                    'InqFlan DBoc!, Asa, Tipo, iRec
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k3. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    If Record.Dati(10) = 7 Then Flangia.K3 = 5
                                    Record.Dati(1) = 6 'Flangia non riportata
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    Record.Dati(2) = Flangia.K1
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    Record.Dati(3) = Flangia.K2
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k3. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    Record.Dati(4) = Flangia.K3
                                End If
                            End If
                            Call CercaMat(MATE, 0, "i fucinati", 0, 0, 0, 0, 0, 0, 1, 0, 0)
                        Case 13 'bulloneria
                            Record.Dati(6) = 2
                            Record.Dati(7) = 1
                            If Left(LTrim(Denom), 1) = "D" Then
                                Record.Dati(9) = 1
                            Else
                                DIME = RTrim(DIME)
                                For j = Len(DIME) To 1 Step -1
                                    If Asc(Mid(DIME, j, 1)) < 48 Or Asc(Mid(DIME, j, 1)) > 57 Then Exit For
                                Next
                                Record.Dati(1) = Val(Right(DIME, Len(DIME) - j))
                                Record.Dati(9) = 0
                            End If
304:                        Call CercaMat(MATE, 0, "bulloneria", 0, 0, 0, 0, 0, 0, 0, 1, 0)
                        Case 15 'rettangoli
305:                        l = InStr(DIME, ".")
                            DIME = Right(DIME, Len(DIME) - l)
                            l = InStr(DIME, " ")
                            SP = Val(Left(DIME, l))
                            DIME = Right(DIME, Len(DIME) - l)
                            l = InStr(DIME, "X")
                            If l = 0 Then l = InStr(DIME, "x")
                            Lu1 = Val(Left(DIME, l - 1))
                            Lu2 = Val(Right(DIME, Len(DIME) - l))
                            Record.Dati(1) = SP
                            Record.Dati(2) = Lu1
                            Record.Dati(3) = Lu2
                            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
                            Call CercaMat(MATE, 0, "le lamiere", 1, 1, 0, 0, 0, 0, 0, 0, 0)
                        Case 24 'varie
306:                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Matdim.Indmat = 0
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Matdim.MatStr = ""
                        Case 23 'tondi
307:                        Call CercaMat(MATE, 0, "i tondi", 0, 0, 1, 0, 0, 0, 0, 0, 0)
                        Case 28 'guarnizioni
308:                        Call CercaMat(MATE, 0, "le guarnizioni", 1, 1, 0, 0, 0, 0, 0, 0, 0)
                        Case 29 'tappi
309:                        Call CercaMat(MATE, 0, "i tappi", 0, 0, 0, 0, 0, 0, 1, 0, 0)
                        Case 30 'nessun grezzo
310:                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Matdim.Indmat = 0
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Matdim.MatStr = ""
                    End Select
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.MATE = Matdim.MatStr
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Indmat = Matdim.Indmat
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.PSP = Matdim.PSP
                    Register(ik)
                    If EOF(ifl1) Then Exit Do
                Loop
                FileClose(ifl1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                IO.File.Delete(CStr(Monitor.Motore.Inizio.DiscoRam + "SCRA" + CDbl(RTrim(job.Contratto))))
                makeAPR1 = Esito
                Exit Function
            End If
        Loop
        FileClose(ifl1)
        makeAPR1 = False
        Exit Function
    End Function
    Private Sub Tronci()
        Dim l, l1 As Integer
        l = InStr(DIME, "X")
        If l = 0 Then l = InStr(DIME, "x")
        l1 = l + 1
        If l = 0 Then l = InStr(DIME, "T") : l1 = l + 4
        D = Val(Mid(DIME, 2, l - 2))
        S = Val(Mid(DIME, l1, Len(DIME) - l1))
        Pipe.Diam = D
        Pipe.Spess = S
        Pipe.Cerca(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
        If Left(Denom, 2) = "BO" Then
            Call StdBoc(Val(Pipe.DN), iRec, 0)
        Else
            l = InStr(Pipe.DN, "in")
            If l > 1 Then
                DBoc = GlobalRoutines.ConvPoll(Left(Pipe.DN, l - 1))
            End If
            '  Call FlanA(DBoc!, 1, iRec)
            If iRec > 0 Then Record.Dati(1) = ReadLib(iRec, 1) 'ALTEZZA
        End If
        Record.Dati(2) = D
        Record.Dati(3) = S
    End Sub
    Sub Schedula(ByRef indice As Short)
        Dim DBoc As Single
        Dim DN As String
        Dim DTrext, Spess As Single
        Dim iSch As String
        Dim Help As String
        Dim X As Integer
        'On Local Error GoTo ErrSched
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto RecordD(indice). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        RecordD(indice) = Record
        If indice = 1 Then DBoc = Mecdata0.DBocIn Else DBoc = Mecdata0.DBocOut
        If Mecdata0.Bcgl(indice) = 1 Then
            RecordD(indice).Denom = "BOCCAGLIO T" & LTrim(Str(indice))
1195:       Call StdBoc(DBoc, iRec, indice)
            RecordD(indice).Note = ""
        Else
            RecordD(indice).Denom = "TRONCHETTO T" & LTrim(Str(indice))
            If indice = 1 Then
1200:           DTrext = Mecdata0.DInmm
                Spess = Mecdata0.SpInmm
                DN = Str(Mecdata0.DBocIn) & " in."
            Else
                DTrext = Mecdata0.DOutmm
                Spess = Mecdata0.SpOutmm
                DN = Str(Mecdata0.DBocOut) & " in."
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Pipe.Diam = DTrext
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Spess. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Pipe.Spess = Spess
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.DN. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Pipe.DN = Trim(Str(Mecdata0.DBocIn))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Cerca. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Pipe.Cerca(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DTrext = Pipe.Diam
            Help = "Schedula proposta per il bocchello| di "
            If indice = 1 Then Help = Help & "ingresso "
            If indice = 2 Then Help = Help & "uscita "
            Help = Help & Trim(RecordD(indice).Denom) & DN & ": |"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Spess. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(Pipe.Spess, 3, 2, False). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Schedula. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Help = CDbl(Help & "Sch ") + Pipe.Schedula + CDbl("; Dext") + CDbl(Str(DTrext)) + CDbl("; spessore ") + GlobalRoutines.myStr(Pipe.Spess, 3, 2, False)
            Help = Help & "| Accetti?"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Help = Monitor.Motore.Inizio.ConvertiCr(Help)
            X = MsgBox(Help, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
            If X = MsgBoxResult.No Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Scelta. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Pipe.Scelta("", "")
            End If
            RecordD(indice).Dati(1) = AltBoc 'Altezza tronchetto
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Diam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            RecordD(indice).Dati(2) = Val(Pipe.Diam)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Pipe.Spess. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            RecordD(indice).Dati(3) = Val(Pipe.Spess)
            RecordD(indice).Dati(4) = 0 'iSch
        End If
        RecordD(indice).Note = "NOZZLE T" & LTrim(Str(indice))
        RecordD(indice).Dati(5) = 1 'tubo a schedula
        RecordD(indice).DIME = "TR.$" & LTrim(Str(RecordD(indice).Dati(2))) & "x" & LTrim(Str(RecordD(indice).Dati(3))) & " L=" & LTrim(Str(RecordD(indice).Dati(1)))
        If indice = 1 Then RecordD(indice).Qta = CInt(Str(Mecdata0.nBocIn)) Else RecordD(indice).Qta = CInt(Str(Mecdata0.nBocOut))
        Exit Sub
        'ErrSched: Print "Errore in Schedula"; Err; Erl: Stop
StdBoc:
    End Sub
    Sub Flange(ByRef indice As Short)
        Dim di As Single
        'On Local Error GoTo ErrFlange
300:    Call SpessTr(indice)
310:    Call Schedula(indice)
320:    di = RecordD(indice).Dati(2) - 2 * RecordD(indice).Dati(3)
330:    'Record.DIME = EFl$(k3) + " " + RTrim$(CFl$(k1)) + "''" + DFl$(k2) + "??DI." + LTrim$(Str$(di!))
340:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.MATE = RTrim(Matdim.MatStr) & " (DI=" & LTrim(GlobalRoutines.myStr(di, 3, 2, False)) & ")"
        Record.Dati(1) = 6 'Flangia non riportata
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Dati(2) = Flangia.K1 'Flangia non riportata
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Dati(3) = Flangia.K2
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k3. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Dati(4) = Flangia.K3
        Record.Dati(10) = 0 'flangia
        Record.Denom = "FLANGIA T" & LTrim(Str(indice))
        Record.Note = "FLANGE T" & LTrim(Str(indice))
        If indice = 1 Then Record.Qta = CInt(Str(Mecdata0.nBocIn)) Else Record.Qta = CInt(Str(Mecdata0.nBocOut))
        Record.Tipo = 10
        Exit Sub
        'ErrFlange: Print "Errore in STRUCT/Flange"; Err; Erl: End
    End Sub

    Function LarghCassa(ByRef iCassa As Short, ByRef Nrdit As Short) As Boolean
        Dim nt, jjj As Short
        Dim Nfield, j As Short
        Dim Testo As String
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        'On Local Error GoTo ErrLargh
        LarghCassa = True
        XLarge = ReadLib(1, 1)
        XAria = ReadLib(1, 2)
        Ntubi = 0
        NumFil = NumFile(iCassa)
        If NumFil = 0 Then
            Testo = "Impossibile continuare.|Il numero di file risulta 0."
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            LarghCassa = False : Exit Function
        End If
        Select Case Mecdata0.Tipo
            Case 0, 1 : Ntubi = Mecdata0.NTUB
                '1000           Mec = Mecdata0
                '               NumFil = NumFile
            Case 2
                '          GET #34, 3, MecData1
                '          Mec = MecData1
                '          NumFil = NumFile
                If iCassa = 3 Then
                    Ntubi = Mecdata0.NTUB
                Else
                    AltraCassa = 1 : If iCassa = 1 Then AltraCassa = 2
1010:               MecData1.Initialize()
                    FileGet(34, MecData1, AltraCassa)
                    NumFilA = NumFile(AltraCassa)
                    If NumFilA = 0 Then LarghCassa = False : Exit Function
                End If
            Case 3
                '         GET #34, 1, MecData1
                '          Mec = MecData1
                '          NumFil = NumFile
                If iCassa = 1 Then
                    Ntubi = Mecdata0.NTUB
                Else
1020:               AltraCassa = 2 : If iCassa = 2 Then AltraCassa = 3
                    MecData1.Initialize()
                    FileGet(34, MecData1, AltraCassa)
                    NumFilA = NumFile(AltraCassa)
                End If
            Case 4
1030:           '     GET #34, 1, MecData1
                '          Mec = MecData1
                '          NumFil = NumFile
                '          GET #34, 2, MecData1
                '          Mec = MecData1
                '          NumFil = NumFil + NumFile
                If iCassa < 3 Then
                    AltraCassa = 1 : If iCassa = 1 Then AltraCassa = 2
                Else
                    AltraCassa = 3 : If iCassa = 3 Then AltraCassa = 4
                End If
1040:           MecData1.Initialize()
                FileGet(34, MecData1, AltraCassa)
1041:           NumFilA = NumFile(AltraCassa)
        End Select
1042:   Rapp = CSng(Mecdata0.NTUB) / (NumFil + NumFilA)
        If (Rapp - Int(Rapp) < 0.05) Then
            Pari = 0 : Dispari = 0
        Else
            Pari = 0 : Dispari = 1
        End If
        If ((NumFil + NumFilA) Mod 2) = 1 Then GlobalRoutines.SWAP(Pari, Dispari)
        If Ntubi = 0 Then
            If Mecdata0.NsPad > 0 And MecData1.NsPad > 0 Then
                Ntubi = Mecdata0.NsPad
            Else
                If Pari = 0 And Dispari = 0 Then
1045:               Mecdata0.NsPad = CShort(NumFil / (NumFil + NumFilA) * Mecdata0.NTUB)
                    MecData1.NsPad = Mecdata0.NTUB - Mecdata0.NsPad
                Else
                    nt = 0
                    For jjj = 1 To NumFil
                        nt = nt + Int(Rapp)
                        If jjj Mod 2 = 1 Then nt = nt + Dispari Else nt = nt + Pari
                    Next
                    Mecdata0.NsPad = nt
                    MecData1.NsPad = Mecdata0.NTUB - Mecdata0.NsPad
                End If
                '     MecData1 = Mecdata0
                FilePut(34, MecData1, AltraCassa)
                '     PUT #34, iCassa, Mecdata0
                Mec = MecData1
1050:           Ntubi = Mecdata0.NsPad
            End If
        End If
        Dom(1) = "N° totale tubi"
        Risp(1) = GlobalRoutines.myStr(CSng(Ntubi), 4, 0, True)
        Dom(2) = "N° file"
        Risp(2) = GlobalRoutines.myStr(CSng(NumFil), 4, 0, True)
        Dom(3) = "Diametro tubi"
        Risp(3) = GlobalRoutines.myStr(CSng(Mecdata0.DO_Renamed), 3, 2, False)
        Dom(4) = "Passo orizzontale"
        Risp(4) = GlobalRoutines.myStr(CSng(Mecdata0.TSP), 3, 2, False)
        Dom(5) = "Passo verticale"
        Risp(5) = GlobalRoutines.myStr(CSng(Mecdata0.TVERT), 3, 2, False)
        Dom(6) = "Extra larghezza"
        Risp(6) = GlobalRoutines.myStr(XLarge, 4, 1, False)
        Nfield = 6 ': For j = 1 To Nfield: LungSt(j) = Len(Risp$(j)): Next
        Testo = "Dati per dimensioni " & Mecdata0.HEADER
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(1, Nfield, Testo, Dom, Risp, "", Archiv, dAiu)
        FaseDati = 11
        Apert.Enabled = False
        Monitor.Motore.InputForms(1 - 1).Top = 600 / 15
        Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
        LarghCassa1()
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Monitor.Motore.InputForms Is Nothing
        If FaseDati = -1 Then
            LarghCassa = False
            FaseDati = 0
        End If
    End Function
    Sub MANIC(ByRef i As Short, ByRef j As Short, ByRef Nrdit As Short, ByRef Nquant As Short, ByRef Mater As String)
        Dim CodMan, itp As String
        Dim ASA As Short
        Dim Tipo As Short
        Dim DB As Single
        Dim C, DBocmm, Spessmm As Single
        Dim AltFl, di As Single
240:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        CodMan = objDatBase.DatBase(2, 66 + i, Nrdit, 1, itp, 0)
        Nquant = Val(Left(CodMan, 1))
        If Nquant > 0 Then
            Record.Qta = CInt(Str(Nquant))
            j = Val(Right(CodMan, 1))
            Select Case j
                Case 0
241:                ASA = Val(Mid(Mecdata0.Rating, 6, 4))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Flangia.K2 = AdjASA(ASA)
                    Tipo = 2
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k3. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Flangia.K3 = 4
                    Select Case Right(CodMan, 1)
                        Case "A" : DB = 1.5
                    End Select
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SetDiam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Flangia.SetDiam(DB)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.carica. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Flangia.carica(Monitor.Motore.Inizio.DiscoRam)
                    ' InqFlan DB!, Asa, Tipo, iRec
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    iRec = iRecConvert(Flangia.K1)
                    AltBoc = ReadLib(iRec, 1) 'Altezza tronchetto
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltFl = Flangia.Altezza ' aFl!(5, k3)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.DiamExt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    DBocmm = Flangia.Diamext ' 0 ' aFl!(7, k3)
                    C = Mecdata0.CA
242:                Call StdTR(DB, C, Spessmm)
                    di = DBocmm - 2 * Spessmm
                    'Record.DIME = EFl$(k3) + " " + RTrim$(CFl$(k1)) + "''" + DFl$(k2) + "??DI." + RTrim$(Str$(di!))
                    Call CercaMat(Mater, 0, "i fucinati", 0, 0, 0, 0, 0, 0, 1, 0, 0)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.PSP. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.PSP = Matdim.PSP
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.Indmat. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Indmat = Matdim.Indmat
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Matdim.matstr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.MATE = RTrim(Matdim.MatStr) & " (DI=" & LTrim(GlobalRoutines.myStr(di, 3, 2, False)) & ")"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Dati(2) = Flangia.K1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Dati(3) = Flangia.K2
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k3. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Record.Dati(4) = Flangia.K3
                    Record.Tipo = 10
                Case 4 : Record.DIME = "1/2" & Chr(34) & "6000LBS    B2.1"
                Case 5 : Record.DIME = "3/4" & Chr(34) & "6000LBS    B2.1"
                Case 6 : Record.DIME = "1" & Chr(34) & "6000LBS ANSI B2.1"
                Case 7 : Record.DIME = "1,25" & "6000LBS    B2.1"
                Case 8 : Record.DIME = "1,5" & Chr(34) & "6000LBS    B2.1"
            End Select
            If Record.Tipo <> 10 Then Record.Tipo = 27
            Select Case i
                Case 1 : Record.Denom = "PRESA DI SFIATO"
                    Record.Note = "VENT CONNECTION"
                Case 2 : Record.Denom = "PRESA DI DRENAGGIO"
                    Record.Note = "DRAIN CONNECTION"
                Case 3 : Record.Denom = "PRESA DI TEMPERATURA"
                    Record.Note = "TEMPERATURE CONNEC."
                Case 4 : Record.Denom = "PRESA DI PRESSIONE"
                    Record.Note = "PRESSURE CONNEC."
            End Select
            Record.Qta = CInt(Left(CodMan, 1))
        End If
    End Sub

    Sub QuotaRealeS(ByRef v As Single, ByRef Q As Single, ByRef i As Short, ByRef NfilSopra As Short, ByRef Nfile As Short, ByRef iCassa As Short)
        Dim Ntub0 As Single
        Dim TubiPrima As Short
        Dim OffSet As Single
        Dim Log1 As Boolean
        If ((Nfile - i - NfilSopra) Mod 2) = 1 Then NTUB = Int(Rapp) + Dispari Else NTUB = Int(Rapp) + Pari
        Ntub0 = Int(Rapp)
        If NTUB = Int(Ntub0) Then Ntub0 = Ntub0 + 0.5 Else Ntub0 = Ntub0 + 1.0!
        TubiPrima = CShort(CSng(v) / HeaderSetti(0).LungTest * NTUB)
        OffSet = (LARG - (Ntub0 - 1) * Mecdata0.TSP) / 2.0!
        Log1 = (System.Math.Abs((Nfile - i - NfilSopra) Mod 2) = 1)
        'IF iCassa > 2 AND (Dispari + Pari) = 0 THEN Log1 = NOT Log1
        If Log1 Then OffSet = OffSet + 0.5 * Mecdata0.TSP
        Q = CShort(OffSet + (TubiPrima - 0.5) * Mecdata0.TSP)
    End Sub

    Sub SettiH(ByRef NfilSopra As Short, ByRef iCassa As Short, ByRef ik As Short, ByRef iTest As Short)
        Dim Lunghez(20) As Single
        Dim Nlung(20) As Short
        Dim Nlung1(20) As Short
        Dim Nfile, i, iSettC As Short
        Dim NV, j, NH As Short
        Dim V1 As Single
        Dim h2, H1, Q1 As Single
        Dim k As Short
        Dim TubiPrima, j1 As Short
        Dim V2 As Single
        Dim Q2, Q1s As Single
        Dim Log1, Log2 As Boolean
        Dim Q2s As Single
        Dim iLung As Short
        If iTest = 2 Then
            LARG = Mecdata0.Largf - 2 * Mecdata0.SP(4)
        ElseIf iTest = 3 Or iTest = 4 Then
            LARG = Mecdata0.Largf - 2 * Mecdata0.SP(1)
        End If
        SP = Mecdata0.SP(3)
        Nfile = 0
        For i = 1 To 16
            Nfile = Nfile + System.Math.Abs(Mecdata0.Nfile(i))
        Next
        iSettC = 1
        For i = 1 To Nfile
            If ((Nfile - i - NfilSopra) Mod 2) = 1 Then NTUB = Int(Rapp) + Dispari Else NTUB = Int(Rapp) + Pari
            NV = HeaderSetti(0).Fila(i + NfilSopra).NumSettiV
            For j = 1 To NV
                V1 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j)
                TubiPrima = CShort(CSng(V1) / HeaderSetti(0).LungTest * NTUB)
                NH = HeaderSetti(0).Fila(i - 1 + NfilSopra).NumSettiH
                If i > 1 Then
                    For k = 1 To NH
                        H1 = HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH1(k)
                        h2 = HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH2(k)
                        If System.Math.Abs(H1 - V1) < 2 Then
                            Call QuotaRealeS(V1, Q1, i, NfilSopra, Nfile, iCassa)
                            If System.Math.Abs(h2 - HeaderSetti(0).LungTest) > 2 Then
                                For j1 = j + 1 To NV
                                    V2 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j1)
                                    If System.Math.Abs(V2 - h2) < 2 Then
                                        '--------    trovato  controlla anche setto verticale success
                                        Call QuotaRealeS(V2, Q2, i, NfilSopra, Nfile, iCassa)
                                        Lunghez(iSettC) = Q2 - Q1 + 2 * SP
                                        iSettC = iSettC + 1
                                        Exit For
                                    End If
                                Next j1
                                'stop
                            Else
                                '---trovato: controlla successivo
                                Lunghez(iSettC) = LARG - Q1 + SP
                                iSettC = iSettC + 1
                            End If
                            HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH1(k) = -10
                            HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH2(k) = -10
                        ElseIf System.Math.Abs(h2 - V1) < 2 Then
                            Call QuotaRealeS(V1, Q2, i, NfilSopra, Nfile, iCassa)
                            If System.Math.Abs(H1) > 2 Then
                                For j1 = 1 To j - 1
                                    V2 = HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiV(j1)
                                    If System.Math.Abs(V2 - H1) < 2 Then
                                        '--------    trovato  controlla anche setto verticale success
                                        Call QuotaRealeS(V2, Q1, i, NfilSopra, Nfile, iCassa)
                                        Lunghez(iSettC) = Q2 - Q1 + 2 * SP
                                        iSettC = iSettC + 1
                                        'calcola vertici e stora
                                        Exit For
                                    End If
                                Next j1
                                'stop
                            Else
                                '---trovato: controlla successivo
                                Lunghez(iSettC) = Q2 + SP
                                iSettC = iSettC + 1
                            End If
                            HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH1(k) = -10
                            HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH2(k) = -10
                        End If
                    Next k
                End If
                NH = HeaderSetti(0).Fila(i + NfilSopra).NumSettiH
                For k = 1 To NH
                    H1 = HeaderSetti(0).Fila(i + NfilSopra).SettiH1(k)
                    h2 = HeaderSetti(0).Fila(i + NfilSopra).SettiH2(k)
                    If System.Math.Abs(H1 - V1) < 2 Then
                        Call QuotaRealeS(V1, Q1, i, NfilSopra, Nfile, iCassa)
                        If System.Math.Abs(h2 - HeaderSetti(0).LungTest) > 2 Then
                            For j1 = j + 1 To NV
                                V2 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j1)
                                If System.Math.Abs(V2 - h2) < 2 Then
                                    '--------    trovato  controlla anche setto verticale success
                                    Call ContrSuccS(i, Nfile, NfilSopra, H1, h2, Log1, Log2)
                                    Call QuotaRealeS(V2, Q2, i, NfilSopra, Nfile, iCassa)
                                    If Log1 Then
                                        Call QuotaRealeS(H1, Q1s, i + 1, NfilSopra, Nfile, iCassa)
                                        If Q1s < Q1 Then Q1 = Q1s
                                    End If
                                    If Log2 Then
                                        Call QuotaRealeS(h2, Q2s, i + 1, NfilSopra, Nfile, iCassa)
                                        If Q2s > Q2 Then Q2 = Q2s
                                    End If
                                    Lunghez(iSettC) = Q2 - Q1 + SP
                                    iSettC = iSettC + 1
                                    'calcola vertici e stora
                                    Exit For
                                End If
                            Next j1
                            'stop
                        Else
                            '---trovato: controlla successivo
                            Call ContrSuccS(i, Nfile, NfilSopra, H1, -1, Log1, Log2)
                            If Log1 Then
                                Call QuotaRealeS(H1, Q1s, i + 1, NfilSopra, Nfile, iCassa)
                                If Q1s < Q1 Then Q1 = Q1s
                            End If
                            Lunghez(iSettC) = LARG - Q1 + SP
                            iSettC = iSettC + 1
                        End If
                        HeaderSetti(0).Fila(i + NfilSopra).SettiH1(k) = -10
                        HeaderSetti(0).Fila(i + NfilSopra).SettiH2(k) = -10
                    ElseIf System.Math.Abs(h2 - V1) < 2 Then
                        Call QuotaRealeS(V1, Q2, i, NfilSopra, Nfile, iCassa)
                        If System.Math.Abs(H1) > 2 Then
                            For j1 = 1 To j - 1
                                V2 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j1)
                                If System.Math.Abs(V2 - H1) < 2 Then
                                    '--------    trovato  controlla anche setto verticale success
                                    Call ContrSuccS(i, Nfile, NfilSopra, H1, h2, Log1, Log2)
                                    Call QuotaRealeS(V2, Q1, i, NfilSopra, Nfile, iCassa)
                                    If Log1 Then
                                        Call QuotaRealeS(H1, Q1s, i + 1, NfilSopra, Nfile, iCassa)
                                        If Q1s < Q1 Then Q1 = Q1s
                                    End If
                                    If Log2 Then
                                        Call QuotaRealeS(h2, Q2s, i + 1, NfilSopra, Nfile, iCassa)
                                        If Q2s > Q2 Then Q2 = Q2s
                                    End If
                                    Lunghez(iSettC) = Q2 - Q1 + SP
                                    iSettC = iSettC + 1
                                    'calcola vertici e stora
                                    Exit For
                                End If
                            Next j1
                            'stop
                        Else
                            '---trovato: controlla successivo
                            Call ContrSuccS(i, Nfile, NfilSopra, -1, h2, Log1, Log2)
                            If Log2 Then
                                Call QuotaRealeS(h2, Q2s, i + 1, NfilSopra, Nfile, iCassa)
                                If Q2s > Q2 Then Q2 = Q2s
                            End If
                            Lunghez(iSettC) = Q2 + SP
                            iSettC = iSettC + 1
                        End If
                        HeaderSetti(0).Fila(i + NfilSopra).SettiH1(k) = -10
                        HeaderSetti(0).Fila(i + NfilSopra).SettiH2(k) = -10
                    End If
                Next k
            Next j 'h
            iLung = iSettC - 1
        Next i
        For i = 1 To iLung : Nlung(i) = 1 : Next
        i = 1
        Do
            k = i + 1
            Do
                If Lunghez(i) = Lunghez(k) Then
                    Nlung(i) = Nlung(i) + 1
                    iLung = iLung - 1
                    For j = k To iLung : Lunghez(j) = Lunghez(j + 1) : Next
                End If
                k = k + 1
            Loop While k <= iLung
            i = i + 1
        Loop While i <= iLung - 1
        For i = 1 To iLung
            Record.Dati(3) = Lunghez(i)
            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
            Record.Qta = GlobalRoutines.myStr(CSng(Nlung(i)), 3, 0, True)
            Record.Denom = "S.CORTO" & UCase(Mecdata0.HEADER)
            Record.Note = "SHORT.PART."
            Record.PosDis = 28 + i + 30 * (iCassa - 1)
            Register(ik)
            RecordD(0).Ind = Record.Ind
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record = RecordD(0)
        Next
        Exit Sub
    End Sub

    Sub SettiV(ByRef NfilSopra As Short, ByRef iCassa As Short, ByRef ik As Short, ByRef Mode As Short)
        Dim i0, Nfile, i, ist As Short
        Dim i1, NumSettiV As Short
        'Mode 1 in mezzo,2alle estremit…
        Nfile = 0
        For i = 1 To 16
            Nfile = Nfile + System.Math.Abs(Mecdata0.Nfile(i))
        Next
        If Mode = 1 Then i0 = 2 : i1 = Nfile - 1 : ist = 1
        If Mode = 2 Then i0 = 1 : i1 = Nfile : ist = i1 - i0
        NumSettiV = 0
        For i = i0 To i1 Step ist
            NumSettiV = NumSettiV + HeaderSetti(0).Fila(i + NfilSopra).NumSettiV
        Next
        If NumSettiV > 0 Then
            RecordD(0) = Record
            If Mode = 1 Then
                Record.Dati(3) = Mecdata0.PVERT - Mecdata0.SP(3)
            Else
                Record.Dati(3) = (Mecdata0.PVERT - Mecdata0.SP(3)) / 2 + Mecdata0.XXcorr 'Provvisorio
            End If
            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
            Record.Qta = GlobalRoutines.myStr(CSng(NumSettiV), 3, 0, True)
            Record.Denom = "S.VERT." & UCase(Mecdata0.HEADER)
            Record.Note = "VERT.PART."
            Record.PosDis = 26 + Mode + 30 * (iCassa - 1)
            Register(ik)
            RecordD(0).Ind = Record.Ind
            Record = RecordD(0)
        End If
    End Sub

    Sub SETTO(ByRef iTest As Short, ByRef iCassa As Short, ByRef ik As Short)
        Dim iSopra, NfilSopra As Short
        Dim j As Short
        If nSett = -1 Then
            Record.Denom = "RINF." & UCase(Mecdata0.HEADER)
            Record.Note = "STAY"
            Record.Dati(3) = Record.Dati(3) - ReadLib(1, 6) * 2
            Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Record.Qta = GlobalRoutines.myStr(CSng(nPart), 3, 0, True)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Mecdata0.Tipo = 0 Then Record.Qta = GlobalRoutines.myStr(CSng(nPart * 2), 3, 0, True)
            Exit Sub
        End If
        nSett = 0
        nPart = 0
        Record.Dati(5) = 0.0!
        Record.Denom = "SETTO " & UCase(Mecdata0.HEADER)
        Record.Note = "PARTITION"
        Record.Dati(1) = Mecdata0.SP(3)
        Record.Dati(2) = Mecdata0.H
        If iTest = 3 Or iTest = 4 Then Record.Dati(2) = Mecdata0.H + ReadLib(25, 2) + Mecdata0.Nasello
        If iTest = 2 Then
            Record.Dati(3) = Mecdata0.Largf - 2 * Mecdata0.SP(4)
        ElseIf iTest = 3 Or iTest = 4 Then
            Record.Dati(3) = Mecdata0.Largf - 2 * Mecdata0.SP(1)
        End If
        Record.DIME = "LAM." & Str(Int(Record.Dati(3))) & " x" & Str(Int(Record.Dati(2))) & " Sp" & Str(Int(Record.Dati(1)))
        If Mecdata0.PassFraz Then
            Call TipizzS(iCassa, iRec, iSopra)
            Call FilSopraS(iSopra, NfilSopra)
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(34, HeaderSetti(0), iRec)
            Call SettiV(NfilSopra, iCassa, ik, 1)
            Call SettiV(NfilSopra, iCassa, ik, 2)
            Call SettiH(NfilSopra, iCassa, ik, iTest)
            '     PUT #34, iRec, HeaderSetti(0)
        End If
        If Not Mecdata0.PassFraz Then
            For j = 1 To Mecdata0.NS
                If Mecdata0.Nfile(j) < 0 Then
                    nPart = nPart + 1
                Else
                    nSett = nSett + 1
                End If
            Next j
        Else
            For j = 1 To NumFile(iCassa)
                If HeaderSetti(0).Fila(j + NfilSopra).NumSettiH = 1 And HeaderSetti(0).Fila(j + NfilSopra).SettiH1(1) < 2 And HeaderSetti(0).Fila(j + NfilSopra).SettiH2(1) > HeaderSetti(0).LungTest - 2 Then
                    nSett = nSett + 1
                End If
            Next j
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Record.Qta = GlobalRoutines.myStr(CSng(nSett), 3, 0, True)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Mecdata0.Tipo = 0 Then Record.Qta = GlobalRoutines.myStr(CSng(nSett * 2), 3, 0, True)
    End Sub

    Sub SpessTr(ByRef indice As Short)
        Dim DBoc As Single
        Dim ASA, Tipo As Short
        Dim C, DB As Single
        Dim AltFlIn, Spess, AltFlOut As Single
        'On Local Error GoTo ErrSpessTr
400:    If indice = 1 Then DBoc = Mecdata0.DBocIn Else DBoc = Mecdata0.DBocOut
410:    ASA = Val(Mid(Mecdata0.Rating, 6, 4))
420:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.K2 = AdjASA(ASA)
        Tipo = Mecdata0.Bcgl(indice)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.carica. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.carica(Monitor.Motore.Inizio.DiscoRam)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SetDiam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.SetDiam(DBoc)
264:    'InqFlan DBoc!, Asa, Tipo, iRec
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        AltFlIn = Flangia.Altezza
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        AltFlOut = Flangia.Altezza
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iRec = iRecConvert(Flangia.K1)
        AltBoc = ReadLib(iRec, 1) 'Altezza tronchetto
430:    'If Mecdata0.DInmm = 0! And indice = 1 Then Mecdata0.DInmm = aFl!(7, k3)
        'If Mecdata0.DOutmm = 0! And indice = 2 Then Mecdata0.DOutmm = aFl!(7, k3)
        If Mecdata0.SpInmm = 0.0! And indice = 1 Then
            DB = Mecdata0.DBocIn
            C = Mecdata0.CA
440:        Call StdTR(DB, C, Spess)
            Mecdata0.SpInmm = Spess
        End If
        If Mecdata0.SpOutmm = 0.0! And indice = 2 Then
            DB = Mecdata0.DBocOut
            C = Mecdata0.CA
450:        Call StdTR(DB, C, Spess)
            Mecdata0.SpOutmm = Spess
        End If
        Exit Sub
        'ErrSpessTr: Print "Errore in STRUCT/Flange"; Err; Erl: End
    End Sub

    Sub StdTR(ByRef DB As Single, ByRef C As Single, ByRef Spess As Single)
        Dim iPos As Short
        'On Local Error GoTo ErrStdTR
        Select Case DB
            Case 0.75 : iRec = 30
            Case 1.0! : iRec = 31
            Case 1.5 : iRec = 32
            Case 2.0! : iRec = 33
            Case 3.0! : iRec = 34
            Case 4.0! : iRec = 35
            Case 6.0! : iRec = 36
            Case 8.0! : iRec = 37
            Case 10.0! : iRec = 38
            Case 12.0! : iRec = 39
        End Select
        If C >= 4.8 Then
            iPos = 3
        ElseIf C >= 0.0! Then
            iPos = 2
        Else
            iPos = 1
        End If
1100:   Spess = ReadLib(iRec, iPos)
        Exit Sub
        'ErrStdTR: Print "Errore in StdTR"; Err; Erl: Stop
    End Sub
    Public Function iRecConvert(ByRef j As Short) As Short
        Dim iRec As Short
        Select Case j
            Case 2 : iRec = 9
            Case 3 : iRec = 10
            Case 5 : iRec = 11
            Case 6 : iRec = 12
            Case 7 : iRec = 13
            Case 8 : iRec = 14
            Case 9 : iRec = 15
            Case 10 : iRec = 16
            Case 11 : iRec = 17
            Case 12 : iRec = 18
            Case 13 : iRec = 19
            Case 14 : iRec = 20
            Case 15 : iRec = 21
            Case Else : iRec = 0
        End Select
        iRecConvert = iRec
    End Function

    Public Sub StruttItem()
        Dim Valido As Boolean
        Dim fMEC, Nome As String
        Dim j, Esito As Short
        Dim dist As String
        If Left(job.Comm.Ind(3).Data.Assieme, 1) <> "*" Then
            MostraAiuto(IDH_DB_NOCOMPATT)
            Exit Sub
        End If 'z
        comm = objDatBase.Readreco(1, 46, 2)
        If Len(Trim(comm)) > 0 Then
            Valido = Asc(comm) > 32
        Else
            Valido = False
        End If
        If Not Valido Then
            MostraAiuto(IDH_DB_NOCOMMESSA)
            Exit Sub
        End If
        Nome = Monitor.Motore.Inizio.Workdir + "\" + comm + ".JOB"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Nome)) = 0 Then
            MostraAiuto(IDH_DB_NOCOMMESSA)
            Exit Sub
        End If
        InitUPM()
        Matdim = New LibMat.MaterialeNew1
        InitFlangia()
        Pipe = New LibMat.clsPipe
        Tira = New LibMat.clsTira
        job = New RoutBase1.clsjob(Monitor.Motore)
        Dim ContrFile As String
        Monitor.Motore.Retrievejob(Nome, ContrFile)
        For j = 1 To job.Coll.Count
            job.RetrieveCom(j)
            If job.Comm.NBank = iActBank Then GoTo OKComm
        Next
        MostraAiuto(IDH_DB_NOSOTTOCO)
        Exit Sub
OKComm:
        For j = 1 To job.Comm.Ind.Count
            If Trim(job.Comm.Ind(1).Data.Assieme) = Trim(job.Comm.Ind(j).Data.Assieme) Then GoTo OKItem
        Next
        MostraAiuto(IDH_DB_MANCADBITEM)
        Exit Sub
OKItem:
        actComm = job.Comm
        dist = Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch
        fMEC = job.Contratto + GlobalRoutines.Str2Cifre(Nrdit \ 2) + ".MEC"
        If Len(Dir(Monitor.Motore.Inizio.Workdir + "\" + fMEC)) = 0 Then
            MostraAiuto(IDH_DB_NOCALCOLITEM)
            Exit Sub
        End If
        Esito = makeAPR(j, dist, Trim(job.Comm.Ind(j).Data.File), fMEC, iActBank, True) ' = 0 Then GoTo Uscita
    End Sub

    Public Sub LarghCassa1()
        Dim Testo As String
        Dim Archiv(4) As Short
        Dim dAiu(4) As String
        If Monitor.Motore.InputForms.Count = 2 Then
            Monitor.Motore.InputForms(2 - 1).close()
            Monitor.Motore.InputForms.Remove(2 - 1)
        End If
        With CObj(Monitor.Motore.InputForms(1 - 1))
            Mecdata0.NsPad = Val(.prisposte(1))
            NumFil = Val(.prisposte(2))
            Mecdata0.DO_Renamed = Val(.prisposte(3))
            Mecdata0.TSP = Val(.prisposte(4))
            Mecdata0.TVERT = Val(.prisposte(5))
            XLarge = Val(.prisposte(6))
            Rapp = CSng(Val(.prisposte(1))) / NumFil
        End With
        If System.Math.Abs(CInt((Rapp - Int(Rapp)) < 0.05)) Then
            Pari = 0 : Dispari = 0
        Else
            Pari = 0 : Dispari = 1
        End If
        If ((NumFil + NumFilA) Mod 2) = 1 Then GlobalRoutines.SWAP(Pari, Dispari)
        Ntub1 = Int(Rapp) + Dispari
        Ntub2 = Int(Rapp) + Pari
        If Ntub1 < Ntub2 Then Ntub1 = Ntub2
        If Ntub1 = Ntub2 Then
            Largf = Mecdata0.TSP * (CSng(Ntub1) + 0.5) + XAria
        Else
            Largf = Mecdata0.TSP * CSng(Ntub1) + XAria
        End If
        Larg10 = 10 * Int(Largf / 10.0!)
        If Largf - Larg10 < 1 Then Largf = Larg10 Else Largf = Larg10 + 10
        VLargh = Largf
        Largf = Largf + XLarge
        'VLargh! = CVS(DatBase(7, 21, Nrdit, 1, itp$, 0)) * 301.4
        Dom(1) = "Larghezza interna telaio "
        Risp(1) = GlobalRoutines.myStr(VLargh, 5, 1, False)
        Dom(2) = "Lunghezza interna cassa"
        Risp(2) = GlobalRoutines.myStr(Largf, 5, 1, False)
        Dom(3) = "Altezza interna cassa "
        Risp(3) = GlobalRoutines.myStr(Mecdata0.HX3, 5, 1, False)
        Dom(4) = "Larghezza interna cassa"
        Risp(4) = GlobalRoutines.myStr(Mecdata0.H, 5, 1, False)
        Testo = "Dimensioni " & Mecdata0.HEADER
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(2, 4, Testo, Dom, Risp, "", Archiv, dAiu)
    End Sub

    Public Sub LarghCassa2()
        With CObj(Monitor.Motore.InputForms(2 - 1))
            Mecdata0.LarghIntTel = Val(.prisposte(1))
            Mecdata0.Largf = Val(.prisposte(2))
            Mecdata0.HX3 = Val(.prisposte(3))
            Mecdata0.H = Val(.prisposte(4))
        End With
    End Sub
End Module