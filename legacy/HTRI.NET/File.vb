Option Strict Off
Option Explicit On
Imports system.math
Module modFile
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Record prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private Record As RecAPRn
    Private NumFile As Short
    Private LARG As Single
    Private Pari, Dispari As Short
    Private Rapp As Single
    Private VolOut, VolIn, Volume As Single
    Private AltBocIn, AltFlIn As Single
    Private AltBocOut, AltFlOut As Single
    Private Flangia As Grafica.Flangia
    Private Slivell As Single
    Private ASA, Tipo As Short
    Private DBoc As Single
    Private Stringa(10) As String
    Private Riga As String
    Private MontDwg, AssDwg As String
    Private iRec, Nrdit As Short
    Private NC As Short
    Private Item, Mec As String
    Private Nfas As Short
    Private NomeDAT As String
    Private DisDet, MaterCov As String
    Private MaterGua, Nota As String
    'Dim item$(99), Dom$(30), Nfas(99) As Integer, FileFil$(99), Risp$(30), Mec$(99)
    'Dim LungSt(30) As Integer
    Private Risp2(4, 14) As String
    Private Ntubi(16) As Short
    Private Specif(9) As String
    Private DisGua(4) As String
    Private DisCop(4) As String
    Private DisGuTesto(4) As String
    Private Quota(9) As Single
    Private Quota1(9) As Single
    Private Classe1(13) As Short
    Private Classe2(8) As Short
    Private Classe8(5) As Short
    Private myDataBase As dao.Database
    Private myWorkSpace As dao.Workspace
    Private MyFile As String
    '===================================Bocchelli4==================
    Private j, iC, jj, Cod As Short
    Private nBocc, jjj As Short
    Private DN As String
    Private Rat As String
    Private iPos, i As Short
    Private TipoStr, Rati, Sigla As String
    Private Tipo1, itp As String
    Private Dist1 As Single
    Private CodStr, CodMan As String
    Private nMan As Short
    Private MinCas, MaxCas, iCasPos As Short
    Private j1, iCas As Short
    '===============================CalcMtg======================================
    Private AriaAlt, Htelmin As Single
    Private ibA, ibB As Short
    Private iaB, iaA As Short
    Private Htel2, Htel1, Htel As Single
    Private Sporgin, SporgOut As Single
    Private BmAb As Single
    '================================Sezione14=================================
    Private Nsetti As Short
    Private Ngran, jc, Npicc As Short
    Private Posiz As Single
    Private Nfield As Short
    Private A As String
    Private Archiv(20) As Short
    Private dAiu(20) As String
    Private BltAre, DiamF As Single
    '============================TracciaTubi2===================
    Private ifl, Destra As Short
    Private Nff, n, iprov As Short
    Private YY1, YY2 As Single
    Private l, k As Short
    Private Senso As Short
    Private Nfv(2) As Short 'contatore integrale (camera per camera) su file esaminate
    '1 sinistra 2 destra
    Private Giafatto(4) As Short
    Private Add(4) As Single
    Private Add1(2) As Single
    '========================Capacity=================================
    Dim cAp As Single
    Dim indice As Short
    Dim Altz, Fact As Single
    ' =======================================================================
    ' Initialize
    ' =======================================================================
    'IUN = 11: IUNS = 12:
    Function Converti(ByRef jj As Short, ByRef i As Short) As Short
        Select Case MecData(1).Tipo
            Case 0
                If i = 1 Then Converti = 1 Else Converti = 3
            Case 1
                If jj = 1 Then Converti = 1 Else Converti = 3
            Case 2
                If jj = 1 Then
                    Converti = 2
                ElseIf jj = 2 Then
                    Converti = 1
                Else
                    Converti = 3
                End If
            Case 3
                If jj = 1 Then
                    Converti = 1
                ElseIf jj = 2 Then
                    Converti = 4
                Else
                    Converti = 3
                End If
            Case 4
                If jj = 1 Then
                    Converti = 2
                ElseIf jj = 2 Then
                    Converti = 1
                ElseIf jj = 3 Then
                    Converti = 4
                Else
                    Converti = 3
                End If
        End Select
    End Function
    Function Imposs(ByRef iCasPos As Short, ByRef j As Short, ByRef Tipo As Short) As Boolean
        Imposs = False
        Select Case Tipo
            Case 0, 1
            Case 2
                If iCasPos <= 2 Then
                    If j = 1 Then Imposs = True
                Else
                    If j = 2 Then Imposs = True
                End If
            Case 3
                If iCasPos <= 2 Then
                    If j = 2 Then Imposs = True
                Else
                    If j = 3 Then Imposs = True
                End If
            Case 4
                If iCasPos <= 2 Then
                    If j = 1 Or j = 3 Then Imposs = True
                Else
                    If j = 2 Or j = 4 Then Imposs = True
                End If
        End Select
    End Function
    Private Sub AdjASAf(ByRef ASA As Short, ByRef jj As Short)
        Dim X As Short
        If ASA = 0 Then
            Stringa(1) = " 150"
            Stringa(2) = " 300"
            Stringa(3) = " 400"
            Stringa(4) = " 600"
            Stringa(5) = " 900"
            Stringa(6) = "1500"
            Stringa(7) = "2500"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X = Monitor.Motore.Quale(7, "Rating bocchelli", Stringa, "", 1)
            ASA = Val(Stringa(X))
            Mid(MecData(jj).Rating, 6, 4) = Stringa(X)
            '           GET #34, 1, Mec
            '           Mec.Rating = MecData.Rating
            '           PUT #34, 1, Mec
        End If
    End Sub
    Sub Iniziali()
        Dim i As Short
        Dim NewAltIn, NewAltOut As Single
        Dim l As Short
        DBoc = MecData(1).DBocIn
        ASA = Val(Mid(MecData(1).Rating, 6, 4))
        Call AdjASAf(ASA, 1)
        Tipo = MecData(1).Bcgl(1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.K2 = AdjASA(ASA)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SetDiam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.SetDiam(DBoc)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.carica. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.carica(Monitor.Motore.Inizio.DiscoRam)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iRec = iRecConvert(Flangia.K1)
        Select Case Tipo
            Case 0 'WN
                AltBocIn = ReadLib(iRec, 1) 'Altezza tronchetto
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                AltFlIn = Flangia.Altezza + AltBocIn
            Case 1 'Sagom
                AltBocIn = 0
                If InStr(MecData(1).Rating, "RJ") > 0 Then l = 1 Else l = 0
                iRec = CercaRec(Str(ASA), Str(DBoc))
                AltFlIn = ReadLib(iRec + 10, 11 + l)
            Case 2 'LWN
                AltBocIn = 0
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                AltFlIn = Flangia.Altezza 'aFl!(5, k3)
        End Select
        DBoc = MecData(1).DBocOut
        Tipo = MecData(1).Bcgl(2)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.K2 = AdjASA(ASA)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SetDiam. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.SetDiam(DBoc)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.carica. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Flangia.carica(Monitor.Motore.Inizio.DiscoRam)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.k1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iRec = iRecConvert(Flangia.K1)
        Select Case Tipo
            Case 0 'WN
                AltBocOut = ReadLib(iRec, 1) 'Altezza tronchetto
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                AltFlOut = Flangia.Altezza + AltBocIn
            Case 1 'Sagom
                AltBocOut = 0
                If InStr(MecData(1).Rating, "RJ") > 0 Then l = 1 Else l = 0
                iRec = CercaRec(Str(ASA), Str(DBoc))
                AltFlIn = ReadLib(iRec + 10, 11 + l)
            Case 2 'LWN
                AltBocOut = 0
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.Altezza. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                AltFlOut = Flangia.Altezza 'aFl!(5, k3)
        End Select
        For i = 1 To 9 : Quota(i) = 0.0! : Next
        Slivell = Int(MecData(1).LUNGF * Slop())
        Call CalMtg(NewAltIn, NewAltOut)
        AltBocIn = AltBocIn + (NewAltIn - AltFlIn)
        AltBocOut = AltBocOut + (NewAltOut - AltFlOut)
        AltFlIn = NewAltIn
        AltFlOut = NewAltOut
        MecData(1).AltBocIn = AltBocIn
        MecData(1).AltBocOut = AltBocOut
        MecData(1).AltFlIn = AltFlIn
        MecData(1).AltFlOut = AltFlOut
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SpessTr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.DiamTr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto PI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        VolIn = PI * (Flangia.DiamTr - 2 * Flangia.SpessTr) ^ 2 / 4 * MecData(1).AltFlIn
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.SpessTr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Flangia.DiamTr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto PI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        VolOut = PI * (Flangia.DiamTr - 2 * Flangia.SpessTr) ^ 2 / 4 * MecData(1).AltFlOut
    End Sub

    Function QuantitaT() As String
        Select Case Record.Tipo
            Case 15 'rettangoli
                QuantitaT = GlobalRoutines.myStr(Record.Dati(2) * Record.Dati(3) * 0.000001, 3, 3, False)
            Case 10, 29, 27, 13
                QuantitaT = "  1.000"
            Case 2 ' tronchetti
                QuantitaT = GlobalRoutines.myStr(Record.Dati(1) * 1.2 / 1000.0!, 3, 3, False)
            Case Else
                QuantitaT = ""
        End Select
    End Function

    Sub SchMtg()
        Dim i As Short
        Assumi()
        PrintLine(34, GlobalRoutines.FormatS(Riga, Quota(1), Quota(8)))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, Quota(2), Quota(9))) 'Htel!
        For i = 3 To 7
            Riga = LineInput(35)
            PrintLine(34, GlobalRoutines.FormatS(Riga, Quota(i)))
        Next
        Assumi()
    End Sub
    Sub Sezione10()
        Assumi()
    End Sub
    Sub Sezione6()
        Dim X As Short
        Dim Dist1, Dist2 As Single
        Dim Lung1, Lung2 As Single
        Dim Alt1, Alt2 As Single
        Dim Larg1, Larg2 As Single
        Dim Sp1, Sp2 As Single
        Stringa(1) = "Una targa"
        Stringa(2) = "Due targhe"
        X = Monitor.Motore.Quale(2, "Quante targhe?", Stringa, "", 1)
        Assumi()
        Dist1 = 200 : Dist2 = -200
        Lung1 = 180 : Lung2 = 180
        Alt1 = 40 : Alt2 = 40 : Larg1 = 150 : Larg2 = 150
        Sp1 = 4 : Sp2 = 4
        PrintLine(34, GlobalRoutines.FormatS(Riga, 1, Dist1, 0, 0, 0, Lung1, Alt1, Larg1, Sp1))
        If X = 2 Then PrintLine(34, GlobalRoutines.FormatS(Riga, 1, Dist2, 0, 0, 0, Lung2, Alt2, Larg2, Sp2))
        If Not EOF(35) Then Assumi()
    End Sub

    Function Slop() As Single
        Dim Slope As Single
        Dim itp As String = ""
        Dim n As Short
        Dim n1 As Short
        Slope = objDatBase.DatBase(4, 16, NumIt, 1, itp, 1)
        If Len(LTrim(RTrim(Slope))) = 0 Then
            Slop = 0.0!
        ElseIf Asc(Slope) < 33 Then
            Slop = 0.0!
        ElseIf Left(LTrim(Slope), 1) = "N" Then
            Slop = 0.0!
        ElseIf Val(Slope) > 0 Then
            n = InStr(Slope, "/")
            n1 = InStr(Right(Slope, Len(Slope) - n), "/")
            If n1 = 0 Then
                Slop = Val(Slope) / 1000.0!
            Else
                Slop = CSng(Val(Slope)) / Val(Right(Slope, Len(Slope) - n)) / 12.0!
            End If
        Else
            Slop = 0.0!
        End If
    End Function
    Public Sub InitClasse()
        'Set Funzioni = Nothing
        InitFlangia()
        Classe1(0) = 13
        Classe1(1) = 5
        Classe1(2) = 6
        Classe1(3) = 7
        Classe1(4) = 9
        Classe1(5) = 11
        Classe1(6) = 14
        Classe1(7) = 20
        Classe1(8) = 40
        Classe1(9) = 60
        Classe1(10) = 80
        Classe1(11) = 100
        Classe1(12) = 150
        Classe2(0) = 8
        Classe2(1) = 3
        Classe2(2) = 4
        Classe2(3) = 5
        Classe2(4) = 7
        Classe2(5) = 12
        Classe2(6) = 29
        Classe2(7) = 49
        Classe8(0) = 5
        Classe8(1) = 14
        Classe8(2) = 32
        Classe8(3) = 40
        Classe8(4) = 63
    End Sub
    Public Sub EseguiFile()
        Dim Testo, Provv As String
        Dim X As Integer
        Dim ifa, ii As Short
        Dim Riga1 As String = ""
        Dim n As Short
        Dim DirDir, RigTesto As String
        InitClasse()
        If Not PreliminItem() Then Exit Sub
        ItemnSt = job.Comm.Ind(1).Data.Assieme
        SETRDIT(ItemnSt, Nrdit)
        FileMec = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto.Trim + GlobalRoutines.Str2Cifre(Nrdit \ 2) + ".MEC"
405:    FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(1)))
        FileGet(33, MecData(1), 1)
        FileClose(33)
        NC = nCasse(MecData(1).Tipo)
        Item = MecData(1).ITEMNO
        Mec = Monitor.Motore.Inizio.CommPulita(FileMec)
        Nfas = 0
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(1)))
        NC = nCasse(MecData(1).Tipo)
        For ii = 2 To NC
            FileGet(33, MecData(ii), ii)
        Next
        FileClose(33)
        AssDwg = job.Comm.Arch + job.Comm.Ind.Item(job.Comm.indice).Data.File
        MontDwg = AssDwg
        Mid(MontDwg, 7, 1) = "7"
        DirDir = CStr(Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch)
        NomeDAT = DirDir & "\" & job.Comm.Ind.Item(job.Comm.indice).Data.File & ".DAT"
        If IO.File.Exists(NomeDAT) Then
            Testo = "E' già stato generato il file|"
            Testo = Testo & "testate/telai per la commessa " & job.Comm.Arch & ",|"
            Testo = Testo & "dis. " & job.Comm.Ind.Item(job.Comm.indice).Data.File & ". Vuoi editarlo (Si),|"
            Testo = Testo & "rigenerarlo (No)"
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            X = MsgBox(Testo, MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "ISA")
            If X = MsgBoxResult.No Then
                IO.File.Delete(NomeDAT)
            ElseIf X = MsgBoxResult.Yes Then
                GoTo Riedit
            ElseIf X = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        Provv = CStr(Monitor.Motore.Inizio.DiscoRam + "PROVV")
        IO.File.Delete(Provv)
437:    FileOpen(34, Provv, OpenMode.Output)
        ifa = 0
Sez1Sez6:
        Select Case MecData(1).Lingua
            Case "IT", "IN"
                FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL01I.DAT"), OpenMode.Input, , OpenShare.Shared)
            Case "FR"
                FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL01F.DAT"), OpenMode.Input, , OpenShare.Shared)
            Case Else
                Testo = "Non e' stata definita in modo |"
                Testo = Testo & "valido la lingua del Cliente. |"
                Testo = Testo & "Sara' assunto l'inglese.      |"
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                MecData(1).Lingua = "IN"
                FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(1)))
                FilePut(33, MecData(1), 1)
                FileClose(33)
                FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL01I.DAT"), OpenMode.Input, , OpenShare.Shared)
        End Select
        GlobalRoutines.FormatS("non|")
        If Sezione1() = 1 Then FileClose(34) : FileClose(35) : Exit Sub
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL02.DAT"), OpenMode.Input, , OpenShare.Shared)
        TracciaTubi2()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL03.DAT"), OpenMode.Input, , OpenShare.Shared)
        If Sezione3() = 1 Then FileClose(34) : FileClose(35) : Exit Sub
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL04.DAT"), OpenMode.Input, , OpenShare.Shared)
        Bocchelli4()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL05.DAT"), OpenMode.Input, , OpenShare.Shared)
        Sezione5()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL06.DAT"), OpenMode.Input, , OpenShare.Shared)
        Sezione6()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL07.DAT"), OpenMode.Input, , OpenShare.Shared)
        If Not MPL(ifa, Riga1) Then Exit Sub
        FileClose(35)
Sez8Sez14:
        Select Case MecData(1).Lingua
            Case "IT", "IN"
                FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL08I.DAT"), OpenMode.Input, , OpenShare.Shared)
            Case "FR"
                FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL08F.DAT"), OpenMode.Input, , OpenShare.Shared)
        End Select
        If DatiGen8() = 1 Then FileClose(34) : FileClose(35) : Exit Sub
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL09.DAT"), OpenMode.Input, , OpenShare.Shared)
        SchMtg()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL10.DAT"), OpenMode.Input, , OpenShare.Shared)
        Sezione10()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL11.DAT"), OpenMode.Input, , OpenShare.Shared)
        Sezione11()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL12.DAT"), OpenMode.Input, , OpenShare.Shared)
        Sezione12()
        FileClose(35)
        FileOpen(35, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPL14.DAT"), OpenMode.Input, , OpenShare.Shared)
        Sezione14()
        FileClose(35)
        FileClose(34)
        FileClose(33)
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(1)))
        For ii = 1 To NC
            FilePut(33, MecData(ii), ii)
        Next
        FileClose(33)
        FileOpen(34, Provv, OpenMode.Input)
        FileOpen(35, NomeDAT, OpenMode.Output)
        Do
            RigTesto = LineInput(34)
            If EOF(34) Then Exit Do
            Do
                n = InStr(RigTesto, "|")
                If n = 0 Then Exit Do
                Mid(RigTesto, n, 1) = "!"
            Loop
            PrintLine(35, RigTesto)
        Loop
        FileClose(34) : FileClose(35)
        IO.File.Delete(Provv)
Riedit:
        Shell("NotePAD " & NomeDAT, AppWinStyle.NormalFocus)
        '         Testo = "Vuoi eseguire il disegno?    |"
        '    X = Alert(4, Testo, 9, 10, 14, 70, "SI", "NO", "")
        '    If X = 1 Then
        '       AddDistinta = 1
        '       Put #1, 2, Lav(1)
        '       ifile = FreeFile
        '427       Open DiscoTem + "RICO" + RTrim$(job.contratto) For Output As #ifile
        '       Print #ifile, i
        '       Print #ifile, j
        '       Print #ifile, k
        '       For jj = 1 To i: Print #ifile, Nfas(jj): Next
        '       Close #ifile
        '       Catena "SCANTL"
        '    Else
        '       AddDistinta = 0
        '    End If
        ' End If
        Exit Sub
        ' ===========================================================================
        ' If a menu event occured, call the proper demo, or if Exit, set demoFinished
        ' ===========================================================================
        '$INCLUDE: 'Trucco2.bas'
        'SubDir:
        '               Testo = "Non trovati i dati relativi  |"
        '         Testo = Testo + "alla commessa " + job.contratto + "!|"
        '         Testo = Testo + "Rilanciare 'Struttura Commessa'|"
        '  If Err = 64 And Erl = 404 Then
        '               junk = Alert(4, Testo, 4, 3, 11, 48, "OK", "", "")
        '               Resume Uscita
        '  ElseIf Err = 76 Then
        '               junk = Alert(4, Testo, 4, 3, 11, 48, "OK", "", "")
        '     ChDir ActDir$
        '     Resume Cont1
        '  Else
        '         Testo = "Errore " + Str$(Err) + " in FILE, linea" + Str$(Erl)
        '         X = Alert(4, Testo, 9, 10, 14, 70, "OK", "", "")
        '         Resume Uscita
        '  End If
    End Sub
    Sub Bocchelli4()
        Call Iniziali()
        '--------------------------------------------------------------------
        Assumi()
        iC = 0
        For jj = 1 To NC
            ASA = Val(Mid(MecData(jj).Rating, 6, 4))
            Call AdjASAf(ASA, jj)
            Rat = MecData(jj).Rating
            If Left(Rat, 4) = "ANSI" Then
                Rat = Right(Rat, Len(Rat) - 5)
                iPos = InStr(Rat, " ")
                Rati = Str(Val(Rat)) '+ "."
                Rat = Right(Rat, Len(Rat) - iPos)
                iPos = InStr(Rat, " ")
                Rat = RTrim(Right(Rat, Len(Rat) - iPos))
                If Not Rat = "RF" Then Rat = "RJ"
                TipoStr = "WN" & RTrim(Rat) '+ "."
            Else
                TipoStr = "SE  "
                Rati = Str(Val(Mid(MecData(jj).Rating, 6, 4)))
            End If
            Sigla = "T1"
            If MecData(jj).Bcgl(1) = 2 Then
                TipoStr = "L" & TipoStr
            ElseIf MecData(jj).Bcgl(1) = 1 Then
                TipoStr = "S" & TipoStr
            End If
            For j = 1 To MecData(jj).nBocIn
                Cod = 1 : nBocc = MecData(jj).nBocIn
                Call Install()
                iC = iC + 1
                jjj = Converti(jj, 1)
                DN = Str(MecData(jj).DBocIn) & Chr(34)
                Tipo1 = Space(7 - Len(TipoStr)) & TipoStr
                PrintLine(34, GlobalRoutines.FormatS(Riga, Sigla, DN.PadLeft(8), Tipo1, Rati.PadLeft(6), CSng(jjj), 4, Dist1, MecData(1).AltFlIn, Cod, 0.0!))
            Next j 'a
            Sigla = "T2"
            If Left(TipoStr, 1) = "L" Or Left(TipoStr, 1) = "S" Then TipoStr = Right(TipoStr, Len(TipoStr) - 1)
            If MecData(jj).Bcgl(2) = 2 Then
                TipoStr = "L" & TipoStr
            ElseIf MecData(jj).Bcgl(2) = 1 Then
                TipoStr = "S" & TipoStr
            End If
            For j = 1 To MecData(jj).nBocOut
                Cod = 1 : nBocc = MecData(jj).nBocOut
                Call Install()
                iC = iC + 1
                jjj = Converti(jj, 2)
                DN = Str(MecData(jj).DBocOut) & Chr(34)
                Tipo1 = Space(7 - Len(TipoStr)) & TipoStr
                PrintLine(34, GlobalRoutines.FormatS(Riga, Sigla, DN.PadLeft(8), Tipo1, Rati.PadLeft(6), CSng(jjj), 1, Dist1, MecData(1).AltFlOut, Cod, 0))
            Next j 'b
        Next jj
        Dim counter As Short
        For i = 1 To 4 '1:VENT,2:DRAIN,3:TEMP.,4:PRESS
            CodMan = objDatBase.DatBase(2, 66 + i, Nrdit \ 2, 1, itp, 0)
            nMan = Val(Left(CodMan, 1))
            CodStr = Right(CodMan, 1)
            If nMan > 0 Then
                If Val(CodStr) > 0 Then
                    DN = "MANIC. " & CodStr
                    Rati = "6000"
                Else
                    Select Case CodStr
                        Case "A" : DN = " 1.5" & Chr(34)
                    End Select
                End If
                Sigla = "T" & Right(Str(i + 2), 1)
                TipoStr = "LWNRF"
                MaxCas = nCasse(MecData(1).Tipo)
                MinCas = 1
                For j = 1 To nMan
                    Select Case i
                        Case 1 'VENT
                            iCasPos = 4
                            If MecData(1).Tipo = 0 Then
                                jjj = 2
                            Else
                                counter = MaxCas
                                For j1 = counter To 1 Step -1
                                    If Not Imposs(iCasPos, j1, MecData(1).Tipo) Then
                                        jjj = j1
                                        If nMan < 3 Or j = 2 Then MaxCas = j1 - 1
                                        Exit For
                                    End If
                                Next
                            End If
                            iCas = CSng(Converti(jjj, jjj))
                            If MecData(jjj).nBocIn = 0 And (j Mod 2) = 1 Then Cod = 1 Else Cod = 0
                        Case 2 'DRAIN
                            iCasPos = 1
                            If MecData(1).Tipo = 0 Then
                                jjj = 1
                            Else
                                counter = MinCas
                                For j1 = counter To nCasse(MecData(1).Tipo)
                                    If Not Imposs(iCasPos, j1, MecData(1).Tipo) Then
                                        jjj = j1
                                        If nMan < 3 Or j = 2 Then MinCas = j1 + 1
                                        Exit For
                                    End If
                                Next
                            End If
                            iCas = CSng(Converti(jjj, jjj))
                            If MecData(jjj).nBocOut = 0 And (j Mod 2) = 1 Then Cod = 1 Else Cod = 0
                        Case 3 'Temp. ????????????????????
                            Cod = 0
                        Case 4 'Press ?????????????????????
                            Cod = 0
                    End Select
                    If nMan < 3 Then
                        Dist1 = 0.0!
                    Else
                        Dist1 = Int(MecData(jjj).Largf * 1.2 / 30.0!) * 10
                        If (j Mod 2) = 0 Then Dist1 = -Dist1
                    End If
                    Tipo1 = Space(7 - Len(TipoStr)) & TipoStr
                    PrintLine(34, GlobalRoutines.FormatS(Riga, Sigla, DN.PadLeft(8), Tipo1, Rati.PadLeft(6), iCas, CSng(iCasPos), Dist1, 0, Cod, 0))
                Next
            End If
        Next
        If Not EOF(35) Then Assumi()
        Exit Sub
    End Sub
    Private Sub Install()
        Select Case nBocc
            Case 2
                Dist1 = MecData(jj).Largf \ 4
                If j = 2 Then Dist1 = -Dist1 : Cod = 0
            Case 1
                Dist1 = 0.0!
            Case 3
                Dist1 = MecData(jj).Largf \ 3
                If j = 2 Then Dist1 = 0.0! : Cod = 0
                If j = 3 Then Dist1 = -Dist1 : Cod = 0
            Case 4
                Dist1 = MecData(jj).Largf \ 8
                If j = 1 Then Dist1 = 3 * Dist1
                If j = 2 Then Cod = 0
                If j = 3 Then Dist1 = -Dist1 : Cod = 0
                If j = 4 Then Dist1 = -3 * Dist1 : Cod = 0
        End Select
    End Sub
    Sub CalMtg(ByRef NewAltIn As Single, ByRef NewAltOut As Single)
        If NewAltIn = 0.0! Then NewAltIn = AltFlIn
        If NewAltOut = 0.0! Then NewAltOut = AltFlOut
        If Quota(8) = 0.0! Then Quota(8) = MecData(1).LarghIntTel 'interno telaio
        If Quota(1) = 0.0! Then
            If MecData(1).TipTest = 3 Or MecData(1).TipTest = 4 Then
                Quota(1) = CShort(MecData(1).LUNGF) + 100 - 2 * ReadLib(3, 4)
                'provvisorio!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Else
                Quota(1) = CShort(MecData(1).LUNGF) + (MecData(1).H + MecData(NC).H) / 2 - 2 * ReadLib(3, 4)
            End If
        End If
        If Quota(3) = 0.0! Then Quota(3) = ReadLib(1, 3) 'aria min.cassa/basso te
        Quota(2) = Quota(3) + Slivell
        AriaAlt = ReadLib(1, 4) 'aria min.cassa/alto tel
        Htelmin = ReadLib(1, 5) 'alt.min tel,
        Select Case MecData(1).Tipo
            Case 0 'due casse uguali
                ibB = 1 : ibA = 1 : iaB = 1 : iaA = 1
                Htel1 = Quota(3) + MecData(1).HX3 + 2.0! * MecData(1).SP(1) + AriaAlt
                Htel2 = Quota(2) + MecData(1).HX3 + 2.0! * MecData(1).SP(1) + AriaAlt
            Case 1 'due casse diverse
                ibB = 2 : ibA = 1 : iaB = 2 : iaA = 2
                CalcTel()
            Case 2 'cassa A split
                ibB = 3 : ibA = 2 : iaB = 3 : iaA = 1
                CalcTel()
                Htel2 = Htel2 + MecData(1).VuotA + MecData(iaA).HX3 + 2 * MecData(iaA).SP(1)
            Case 3 'cassa B split
                ibB = 3 : ibA = 1 : iaB = 2 : iaA = 1
                CalcTel()
                Htel1 = Htel1 + MecData(1).VuotB + MecData(iaB).HX3 + 2 * MecData(iaB).SP(1)
            Case 4 '2 casse split
                ibB = 4 : ibA = 2 : iaB = 3 : iaA = 1
                CalcTel()
                Htel2 = Htel2 + MecData(1).VuotA + MecData(iaA).HX3 + 2 * MecData(iaA).SP(1)
                Htel1 = Htel1 + MecData(1).VuotB + MecData(iaB).HX3 + 2 * MecData(iaB).SP(1)
        End Select
        If Htel2 > Htel1 Then Htel = Htel2 Else Htel = Htel1
        If Htel < Htelmin Then
            Htel = Htelmin
        Else
            Htel = 10 * Int(Htel / 10.0!) + 10.0!
        End If
        Sporgin = Htel2 + NewAltIn - AriaAlt
        Quota(9) = Htel
        Quota(4) = Sporgin 'Quota A1
        Quota(5) = 0.0! 'Quota A2
        Quota(6) = 0.0! 'Quota A3
        Quota(7) = 0.0! 'Quota A4
        SporgOut = -Quota(3) + NewAltOut
        If MecData(1).Tipo = 0 Then
            Quota(7) = SporgOut
        Else
            If MecData(ibA).nBocOut = 0 Then
                Quota(7) = SporgOut
            Else
                Quota(5) = SporgOut
            End If
        End If
        Dom(1) = "Sporgenza bocch.ingr./filo tel.=" & Str(Sporgin)
        Dom(2) = "Sporgenza bocch.ingr./filo tel.=" & Str(SporgOut)
        Risp(1) = ""
        Risp(2) = ""
        Dom(3) = "Aria min.casse/basso telaio"
        Risp(3) = GlobalRoutines.myStr(Quota(3), 4, 1, False)
        Dom(4) = "Altezza bocchello d'ingresso"
        Risp(4) = GlobalRoutines.myStr(NewAltIn, 4, 1, False)
        Dom(5) = "Altezza bocchello d'uscita"
        Risp(5) = GlobalRoutines.myStr(NewAltOut, 4, 1, False)
        Dom(6) = "Slivellamento totale    "
        Risp(6) = GlobalRoutines.myStr(Slivell, 4, 1, False)
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(6, "Schema montaggio", Dom, Risp, "", Archiv, dAiu) Then Exit Sub
        If System.Math.Abs(Val(Risp(3)) - Quota(3)) < 1 And System.Math.Abs(Val(Risp(4)) - NewAltIn) < 1 And System.Math.Abs(Val(Risp(5)) - NewAltOut) < 1 And System.Math.Abs(Val(Risp(6)) - Slivell) < 1 Then Exit Sub
        Quota(3) = Val(Risp(3)) : NewAltIn = Val(Risp(4)) : NewAltOut = Val(Risp(5))
        Slivell = Val(Risp(6))
        Call CalMtg(NewAltIn, NewAltOut)
        Exit Sub
    End Sub
    Private Sub CalcTel()
CalcTel:
        BmAb = Quota1(Converti(ibB, ibB)) - Quota1(Converti(ibA, ibA)) + MecData(ibB).SP(1) - MecData(ibA).SP(1) + MecData(1).LUNGF * Slop()
        'positivo se cassa B pi— bassa di A
        '      BmAa! = MecData(iaB).HX5(1) - MecData(iaA).HX5(1) + MecData(iaB).Sp(1) - MecData(iaA).Sp(1)
        'positivo se cassa B pi— alta  di A
        If BmAb > 0.0! Then Quota(2) = Quota(2) + BmAb
        If BmAb < 0.0! Then Quota(3) = Quota(3) - BmAb
        Htel1 = Quota(3) + MecData(ibB).HX3 + 2.0! * MecData(ibB).SP(1) + AriaAlt
        Htel2 = Quota(2) + MecData(ibA).HX3 + 2.0! * MecData(ibA).SP(1) + AriaAlt
    End Sub
    Function DatiGen8() As Short
        Dim ifl, i, j As Short
        Dim itp As String = ""
        Dim UniPres, UniTemp, UniLeng As String
        Dim f As String
        Dim Archiv(16) As Short
        Dim dAiu(16) As String
        Dim Alum, Codal As String
        Dim Nff As Single
        Dim Fluid As String
        Dim Press, PDes As Single
        Dim FullVac, MinTest As String
        Dim MinTemp As Single
        Dim Temp, TestPress, TDes As Single
        Dim NfilA, cAp, Numero As Short
        Dim jj As Short
        Dim StressRel As String = ""
        Dim WeldExam As String = ""
        DatiGen8 = 0
        'Sezione 8
        Assumi()
        For i = 1 To 3
            If objDatBase.CVI(objDatBase.DatBase(4, 51, Nrdit \ 2, 1, itp, 0)) = 3 Then PrintLine(34, Riga)
            Assumi()
        Next
        '---------------------------Specifiche--------------------
        UniTemp = Mid(Misur(actPRV.UnitaMisu, 1), 3, 2)
        UniPres = UCase(Mid(Misur(actPRV.UnitaMisu, 2), 3, Len(Misur(actPRV.UnitaMisu, 2)) - 1 - 2))
        UniLeng = UCase(Mid(Misur(actPRV.UnitaMisu, 3), 3, 2))
        ifl = FreeFile()
        f = Monitor.Motore.Inizio.Workdir + Trim(job.Contratto) + ".SPC"
428:    FileOpen(ifl, f, OpenMode.Random, , OpenShare.Shared, Len(Specif(1)))
        If LOF(ifl) > 0 Then
            For i = 1 To 8
                FileGet(ifl, Specif(i), i) : Next
        Else
            For i = 1 To 9 : Specif(i) = Space(71) : Next
            Specif(2) = objDatBase.DatBase(2, 21, Nrdit \ 2, 1, itp, 1)
            Specif(8) = objDatBase.DatBase(2, 14, Nrdit \ 2, 1, itp, 1)
        End If
        Specif(9) = objDatBase.DatBase(4, 51, Nrdit \ 2, 1, itp, 1).PadRight(71)
        For i = 1 To 16 : Dom(i) = "       (Cont...)" : Next
        Dom(1) = "Materiali"
        Dom(3) = "Codice progetto"
        Dom(5) = "Specifiche"
        Dom(9) = "Codice di costruzione"
        Dom(11) = "Finitura"
        Dom(15) = "Collaudo"
        For i = 1 To 8
            j = (i - 1) * 2 + 1
            Risp(j) = Left(Specif(i), 35) : Risp(j + 1) = Right(Specif(i), 36)
            '    LungSt(j) = Len(Risp$(j)): LungSt(j + 1) = Len(Risp$(j + 1))
        Next
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(16, "Note generali", Dom, Risp, "", Archiv, dAiu) Then DatiGen8 = 1 : FileClose(ifl) : Exit Function
        For i = 1 To 8
            j = (i - 1) * 2 + 1
            Specif(i) = Risp(j) & Risp(j + 1)
            FilePut(ifl, Specif(i), i)
        Next
        FileClose(ifl)
        PrintLine(34, GlobalRoutines.FormatS(Riga, Specif(1)))
        For j = 2 To 8
            Riga = LineInput(35)
            PrintLine(34, GlobalRoutines.FormatS(Riga, Specif(j)))
        Next j
        Assumi()
        PrintLine(34, GlobalRoutines.FormatS(Riga, Specif(9)))
        Assumi()
        '---------------------------Tubi----------------------
430:    PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).DO_Renamed, MecData(1).SPTUB, MecData(1).SPTOL, CShort(MecData(1).LUNGF)))
        Riga = LineInput(35)
        Codal = objDatBase.DatBase(4, 58, Nrdit \ 2, 1, itp, 0)
        If Codal = "EM" Then
            Alum = "1050-TEMP-0 UNI 4507"
        ElseIf Codal = "EX" Then
            Alum = "1050 A-F Uni 4507"
        Else
            Alum = ""
        End If
        PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).MATTUB, Alum))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).DALETT, MecData(1).ALINCH, MecData(1).TIPAL))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, NumFile, MecData(1).TSP))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).NTUB, MecData(1).PVERT))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).nPassi))
        Riga = LineInput(35)
        PrintLine(34, Riga)
        Riga = LineInput(35)
        '--------------tubi per passo-------------------------
        If Not MecData(1).PassFraz Then
            NfilA = 1
            For j = 1 To 8
                If j <= MecData(1).nPassi Then
                    Nff = objDatBase.CVS(objDatBase.DatBase(7, j + 1, Nrdit \ 2, 1, itp, 0))
                    Numero = 0
                    For jj = NfilA To NfilA + Int(Nff) - 1 : Numero = Numero + Ntubi(NumFile + 1 - jj) : Next
                    Print(34, GlobalRoutines.FormatS(Riga, j, Numero), TAB)
                    NfilA = NfilA + Int(Nff)
                Else
                    Print(34, GlobalRoutines.FormatS(Riga, j, 0), TAB)
                End If
                If j = 4 Or j = 8 Or j = 12 Or j = 16 Then PrintLine(34)
            Next j
        Else
            For j = 1 To 8
                If j <= MecData(1).nPassi Then
                    Nff = objDatBase.CVS(objDatBase.DatBase(7, j + 1, Nrdit \ 2, 1, itp, 0))
                    Print(34, GlobalRoutines.FormatS(Riga, j, CShort(Nff * MecData(1).NTUB)), TAB)
                Else
                    Print(34, GlobalRoutines.FormatS(Riga, j, 0), TAB)
                End If
                If j = 4 Or j = 8 Or j = 12 Or j = 16 Then PrintLine(34)
            Next j
        End If
        '--------------------------Condizioni di progetto
        Assumi()
        PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).SRVICE))
        Riga = LineInput(35)
        Fluid = objDatBase.DatBase(2, 4, Nrdit \ 2, 1, itp, 0)
        PrintLine(34, GlobalRoutines.FormatS(Riga, Fluid))
        Riga = LineInput(35)
        Press = objDatBase.CVS(objDatBase.DatBase(3, 9, Nrdit \ 2, 1, itp, 0)) 'Press!
        PrintLine(34, GlobalRoutines.FormatS(Riga, UniPres, Press))
        Riga = LineInput(35)
        PDes = objDatBase.CVS(objDatBase.DatBase(3, 25, Nrdit \ 2, 1, itp, 0))
        FullVac = New String(Chr(32), 18) 'FULL VAC. AT 160@C
        PrintLine(34, GlobalRoutines.FormatS(Riga, UniPres, PDes, FullVac))
        Riga = LineInput(35)
        MinTest = New String(Chr(32), 18) 'MIN.TEST TEMP.16@C
        TestPress = objDatBase.CVS(objDatBase.DatBase(3, 26, Nrdit \ 2, 1, itp, 0))
        PrintLine(34, GlobalRoutines.FormatS(Riga, UniPres, TestPress, MinTest))
        Riga = LineInput(35)
        Temp = objDatBase.CVS(objDatBase.DatBase(3, 2, Nrdit \ 2, 1, itp, 0))
        PrintLine(34, GlobalRoutines.FormatS(Riga, UniTemp, Temp))
        Riga = LineInput(35)
        TDes = objDatBase.CVS(objDatBase.DatBase(3, 24, Nrdit \ 2, 1, itp, 0))
        MinTemp = objDatBase.CVS(objDatBase.DatBase(3, 23, Nrdit \ 2, 1, itp, 0))
        PrintLine(34, GlobalRoutines.FormatS(Riga, UniTemp, MinTemp, TDes))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, UniLeng, MecData(1).CA))
        Riga = LineInput(35)
        cAp = Int(Capacity)
        PrintLine(34, GlobalRoutines.FormatS(Riga, cAp))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, StressRel))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, WeldExam))
        Riga = LineInput(35)
        PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).EWC, MecData(1).EWPS))
        Assumi()
    End Function
    Function MPL(ByRef ifa As Short, ByRef Riga1 As String) As Boolean
        Dim n1, j, n, n2 As Short
        Dim i, ik, l As Short
        Dim nome As String
        Dim Data1, Data2 As Date
        Dim ii As Short
        Dim DIME, QtaStr, MATE As String
        Dim Lung2, Lung1, Spess As Single
        Dim QuaTec As String = ""
        Dim CodTec As String = ""
        Dim Translat As String = ""
        Dim Testo As String
        Dim Answer As RoutBase1.ChiaviMess
        myWorkSpace = DAODBEngine.Workspaces(0)
        MyFile = CStr(Monitor.Motore.Inizio.Archdir + "\Materiali.mdb")
        myDataBase = myWorkSpace.OpenDatabase(MyFile, False, True)
        If ifa = 0 Then
            For j = 1 To 4
                n = Val(Right(AssDwg, 3)) - 600
                n1 = 650 + 8 * (n - 1) + j
                n2 = n1 + 4
                DisCop(j) = Left(AssDwg, 6) & LTrim(Str(n1))
                DisGuTesto(j) = Left(AssDwg, 6) & LTrim(Str(n2))
            Next j
        End If
        '----------------------------------------------------------
        MPL = True
        If ifa = 0 Then Assumi()
        For ik = 1 To job.Comm.Ind.Count
            If job.Comm.Ind.Item(ik).Data.Assieme = Item Then
                nome = Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch + "\" + job.Comm.Ind.Item(ik).Data.File + ".APR"
                If Len(Dir(nome)) = 0 Then GoTo Salto
                Data1 = FileDateTime(nome)
                Data2 = FileDateTime(FileMec)
                If Data2 > Data1 Then
                    Testo = GlobalRoutines.FormatS(Helpstringa(IDH_DB_SEQUENZA), Item)
                    Answer = MostraAiuto(IDH_DB_SEQUENZA, RoutBase1.ChiaviMess.MessYesNo Or _
                                                          RoutBase1.ChiaviMess.MessQuestion Or _
                                                          RoutBase1.ChiaviMess.MessHelpButton, Testo)
                    '                  Testo = "I dati da elaborare per la generazione  |"
                    '          Testo = Testo + "del file testate/telai e dello scantling|"
                    '          Testo = Testo + "per l'Item " + Item + " rischiano di non|"
                    '          Testo = Testo + "essere aggiornati. Si consiglia di lan-|"
                    '          Testo = Testo + "ciare la 'Struttura Commessa'          |"
                    '          Testo = Testo + "Vuoi procedere comunque con il file?   |"
                    'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    If Not Answer = RoutBase1.ChiaviMess.MessSi Then Return False
                End If
429:            FileOpen(44, nome, OpenMode.Random, , OpenShare.Shared, Len(Record))
                If LOF(44) = 0 Then FileClose(44) : GoTo Salto
                '-------------------------------
                i = 2
                DisDet = ""
                Do
                    FileGet(44, Record, i)
                    If EOF(44) Then Exit Do
                    If ifa = 0 Then
                        QtaStr = GlobalRoutines.myStr(CSng(Val(CStr(Record.Qta))), 5, 0, True)
                        If Record.Tipo = 15 Then
                            DIME = Right(Record.DIME, Len(Record.DIME) - 4)
                            Lung1 = Val(DIME) : DIME = Right(DIME, Len(DIME) - InStr(DIME, "x"))
                            Lung2 = Val(DIME) : ii = InStr(DIME, "x") : If ii = 0 Then ii = InStr(DIME, "p")
                            DIME = Right(DIME, Len(DIME) - ii)
                            Spess = Val(DIME)
                            DIME = "THK." & Right(Str(Spess), Len(Str(Spess)) - 1) & Str(Lung1) & " X" & Str(Lung2)
                            If MecData(1).TipTest = 3 Or MecData(1).TipTest = 4 Then
                                If Record.Note = "TOP-BOTTOM PLATE" Or Record.Note = "END PLATE" Or Record.Note = "STAY" Or Record.Note = "PARTITION" Then DIME = DIME & "(*)"
                                '      IF (ipos = 2 OR ipos = 3 OR ipos = 11) AND Record.PosDis < 72 THEN DIME$ = DIME$ + "(*)"
                            End If
                        Else
                            DIME = Record.DIME
                        End If
                        MATE = RTrim(Record.MATE)
                        l = InStr(MATE, "(")
                        If l > 0 Then
                            DisDet = Right(MATE, Len(MATE) - l + 1)
                            MATE = Left(MATE, l - 1)
                        End If
                        '------------------------------------------------------
                        If MecData(1).TipTest = 3 Or MecData(1).TipTest = 4 Then
                            If Record.PosDis = 4 Then MaterCov = MATE
                            If Left(Record.Note, 5) = "COVER" And Not Mid(Record.Note, 7, 1) = "F" Then
                                iCassa = Val(Mid(Record.Note, 6, 2))
                                DisDet = DisCop(Converti(iCassa, iCassa))
                            ElseIf Left(Record.Note, 12) = "COVER GASKET" Then
                                iCassa = Val(Mid(Record.Note, 13, 2))
                                DisDet = DisGuTesto(Converti(iCassa, iCassa))
                            End If
                        End If
                        '------------------------------------------------------
                        CodTec = CodiceT(DisDet, Record)
                        QuaTec = QuantitaT()
                        PrintLine(34, GlobalRoutines.FormatS(Riga, GlobalRoutines.myStr(CSng(Record.PosDis), 3, 0, True), _
                                   Record.Denom, Record.Note, DisDet, MATE, QtaStr, DIME, CodTec, QuaTec, Record.Tipo))
                        DisDet = ""
                    Else
                        DisDet = Mid(Riga1, 53, 11)
                        CodTec = CodiceT(DisDet, Record)
                        QuaTec = QuantitaT()
                        Mid(Riga1, 119, 17) = CodTec
                        Mid(Riga1, 139, 7) = QuaTec
                        PrintLine(34, Riga1)
                        Riga1 = LineInput(ifa)
                    End If
                    i = i + 1
                Loop
                FileClose(44)
                If ifa = 0 Then
                    For j = i - 1 To 30
                        PrintLine(34, GlobalRoutines.FormatS(Riga, "  0", "VUOTO", Translat, "", "", "", "", "", ""))
                    Next
                    If Not EOF(35) Then Assumi()
                End If
                myDataBase.Close()
                Exit Function
            End If
Salto:
        Next
        Testo = "Non trovato l'item " & Item & "|"
        Testo = Testo & "nella commessa " & job.Comm.Arch & "!|"
        Testo = Testo & "Rilanciare 'Struttura Commessa'|"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
        MsgBox(Testo, MsgBoxStyle.Information)
        myDataBase.Close()
        Exit Function
    End Function
    Sub QuotaReale(ByRef v As Single, ByRef Q As Single, ByRef i As Short, ByRef NfilSopra As Short, ByRef Nfile As Short, ByRef iCassa As Short)
        Dim NTUB, TubiPrima As Short
        Dim Ntub0 As Single
        Dim OffSet As Single
        Dim Log1 As Boolean
        If ((Nfile - i - NfilSopra) Mod 2) = 1 Then NTUB = Int(Rapp) + Dispari Else NTUB = Int(Rapp) + Pari
        Ntub0 = Int(Rapp)
        If NTUB = Int(Ntub0) Then Ntub0 = Ntub0 + 0.5 Else Ntub0 = Ntub0 + 1.0!
        TubiPrima = CShort(CSng(v) / HeaderSetti(0).LungTest * NTUB)
        OffSet = (LARG - (Ntub0 - 1) * MecData(1).TSP) / 2.0!
        Log1 = (System.Math.Abs((Nfile - i - NfilSopra) Mod 2) = 1)
        'IF iCassa > 2 AND (Dispari + Pari) = 0 THEN Log1 = NOT Log1
        If Log1 Then OffSet = OffSet + 0.5 * MecData(1).TSP
        Q = CShort(OffSet + (TubiPrima - 0.5) * MecData(1).TSP)
    End Sub

    Function Sezione1() As Short
        Dim itp As String = ""
        Dim Archiv(20) As Short
        Dim dAiu(20) As String
        Dim j, Nfield As Short
        Dim A As String
        Sezione1 = 0
        Dom(1) = "Cliente" : Risp(1) = UCase(MecData(1).CUSTMR)
        Dom(2) = "N° d'Ordine"
        Risp(2) = objDatBase.DatBase(1, 5, 1, 1, itp, 0)
        Dom(3) = "Localita'" : Risp(3) = UCase(MecData(1).PLTLOC)
        Dom(4) = "Item" : Risp(4) = UCase(MecData(1).ITEMNO)
        Dom(5) = "N° di Fabbrica" : Risp(5) = New String(" ", 11)
        Dom(6) = "N° di fasci"
        Risp(6) = GlobalRoutines.myStr(CSng(MecData(1).NFASCI), 3, 0, True)
        Dom(7) = "Disegnato da" : Risp(7) = New String(" ", 12)
        Dom(8) = "Verificato da" : Risp(8) = New String(" ", 12)
        Dom(9) = "Contratto n°" : Risp(9) = comm
        Dom(10) = "Dis. montaggio" : Risp(10) = MontDwg
        Dom(11) = "Dis. testate  " : Risp(11) = AssDwg
        Dom(12) = "Indice revisione" : Risp(12) = "00"
        Dom(13) = "Tipo testata" : Risp(13) = Str(MecData(1).TipTest)
        Nfield = 13 ': For j = 1 To Nfield: LungSt(j) = Len(Risp$(j)): Next
        A = "Sezione 1"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(Nfield, A, Dom, Risp, "", Archiv, dAiu) Then Sezione1 = 1 : Exit Function
        For j = 1 To Nfield : Risp(j) = UCase(Risp(j)) : Next
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(1), Val(Risp(13))))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(2)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(3)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(4), Risp(5), Val(Risp(6))))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(7)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(8)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(9)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(10)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(11)))
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Risp(12)))
        If Not EOF(35) Then Assumi()
        Exit Function
    End Function

    Sub Sezione11()
        Assumi()
    End Sub

    Sub Sezione12()
        Assumi()
    End Sub

    Sub Sezione14()
        If MecData(1).TipTest < 3 Then
            For i = 1 To 6 : Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, 0.0!, 0.0!, 0.0!, 0.0!)) : Next
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, "", "", "", ""))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, "", "", "", ""))
            For i = 1 To 6 : Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, 0.0!)) : Next
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, ""))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, ""))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, 0.0!)) 'spess.guarniz
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, 0.0!, 0.0!, 0.0!, 0.0!))
            Call Assumi()
        Else
            Call Fines()
            Nsetti = 0
            For jj = 1 To NC
                If MecData(jj).NS > Nsetti Then Nsetti = MecData(jj).NS
            Next
            For jj = 1 To NC
                jc = Converti(jj, jj)
                Ngran = Int(MecData(jj).Largf / MecData(jj).HE)
                Npicc = Int((MecData(jj).HX3 + 2.0! * MecData(jj).SP(1)) / MecData(jj).HE)
                Dom(1) = "Spessore coperchio "
                Risp(1) = GlobalRoutines.myStr(MecData(jj).SP(4), 4, 0, False)
                Dom(3) = "Passo bulloni"
                Risp(3) = GlobalRoutines.myStr(MecData(jj).HE, 4, 0, False)
                Dom(2) = "N° passi orizzontali"
                Risp(2) = GlobalRoutines.myStr(CSng(Ngran), 3, 2, True)
                Dom(4) = "N° passi verticali"
                Risp(4) = GlobalRoutines.myStr(CSng(Npicc), 3, 2, True)
                Dom(5) = "Spessore flangia"
                Risp(5) = GlobalRoutines.myStr(MecData(jj).TK(4), 4, 0, False)
                Posiz = MecData(jj).SP(1) + Quota(4) - Quota(5)
                Nfield = 5
                For i = 1 To MecData(jj).NS
                    Posiz = Posiz + MecData(jj).HX5(MecData(jj).NS + 2 - i)
                    Dom(5 + i) = "Span" & Str(i) & ".setto"
                    Risp(5 + i) = GlobalRoutines.myStr(Posiz, 3, 2, False)
                    Nfield = Nfield + 1
                Next
                'For j = 1 To Nfield: LungSt(j) = Len(Risp$(j)): Next
                A = MecData(jj).HEADER
                Monitor.Motore.Chiamante = Monitor
                If Not Monitor.Motore.InputDati(Nfield, A, Dom, Risp, "", Archiv, dAiu) Then Exit Sub
                For j = Nfield + 1 To 5 + Nsetti : Risp(j) = "" : Next
                For j = 1 To 5 + Nsetti
                    Select Case MecData(1).Tipo
                        Case 0
                            Risp2(1, j) = Risp(j)
                            Risp2(2, j) = ""
                            Risp2(3, j) = Risp(j)
                            Risp2(4, j) = ""
                        Case 1
                            Select Case jj
                                Case 1
                                    Risp2(jj, j) = Risp(j)
                                Case 2
                                    Risp2(1 + jj, j) = Risp(j)
                                    Risp2(jj, j) = ""
                                    Risp2(2 + jj, j) = ""
                            End Select
                        Case 2
                            Select Case jj
                                Case 1 : Risp2(2, j) = Risp(j)
                                Case 2 : Risp2(1, j) = Risp(j)
                                Case 3 : Risp2(3, j) = Risp(j)
                                Case 4 : Risp2(4, j) = ""
                            End Select
                        Case 3
                            Select Case jj
                                Case 1 : Risp2(1, j) = Risp(j)
                                Case 2 : Risp2(4, j) = Risp(j)
                                Case 3 : Risp2(3, j) = Risp(j)
                                Case 4 : Risp2(2, j) = ""
                            End Select
                        Case 4
                            Select Case jj
                                Case 1 : Risp2(2, j) = Risp(j)
                                Case 2 : Risp2(1, j) = Risp(j)
                                Case 3 : Risp2(4, j) = Risp(j)
                                Case 4 : Risp2(3, j) = Risp(j)
                            End Select
                    End Select
                Next j 'c
            Next jj
            For j = 1 To 4
                Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Val(Risp2(1, j)), Val(Risp2(2, j)), Val(Risp2(3, j)), Val(Risp2(4, j))))
            Next
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Val(Risp2(1, 3)), Val(Risp2(2, 3)), Val(Risp2(3, 3)), Val(Risp2(4, 3))))
            Call Assumi()
            For j = 6 To 5 + Nsetti
                PrintLine(34, GlobalRoutines.FormatS(Riga, j - 5, Val(Risp2(1, j)), Val(Risp2(2, j)), Val(Risp2(3, j)), Val(Risp2(4, j))))
            Next
            PrintLine(34, GlobalRoutines.FormatS(Riga, 0, 0.0!, 0.0!, 0.0!, 0.0!))
            For j = 1 To 4
                If Val(Risp2(j, 1)) = 0 Then
                    DisCop(j) = Space(9)
                    DisGua(j) = Space(9)
                End If
            Next j 'd
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, DisCop(1), DisCop(2), DisCop(3), DisCop(4)))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, DisGua(1), DisGua(2), DisGua(3), DisGua(4)))
            For j = 1 To 6
                Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Quota(j)))
            Next
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, MaterCov))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, MaterGua))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, 3.0!)) 'spess.guarniz  ARIA COPERCHIO
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, 5.0!)) 'spess.guarniz  ARIA COPERCHIO
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, MecData(1).Nasello))
            Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Val(Risp2(1, 5)), Val(Risp2(2, 5)), Val(Risp2(3, 5)), Val(Risp2(4, 5))))
            Call Assumi()
        End If
        Exit Sub
    End Sub
    Private Sub Fines()
        BltAre = MecData(1).BF(2 - 1)
        DiamF = CShort(System.Math.Sqrt(4.0! / PI * BltAre) + 8)
        Nfield = 6
        Dom(1) = "Diametro fori"
        Risp(1) = GlobalRoutines.myStr(DiamF, 4, 0, False)
        Dom(2) = "Profondità cava"
        Risp(2) = GlobalRoutines.myStr(MecData(1).DF(5 - 1), 4, 0, False)
        Dom(3) = "Spessore orecchie"
        Risp(3) = GlobalRoutines.myStr(12.0!, 3, 2, True)
        Dom(4) = "Q.est.cas/cop"
        Risp(4) = GlobalRoutines.myStr(2 * MecData(1).TK(2 - 1), 3, 2, False)
        Dom(5) = "Q.asse c/cop"
        Risp(5) = GlobalRoutines.myStr(MecData(1).TK(1 - 1) + MecData(1).TK(2 - 1), 3, 2, False)
        Dom(6) = "Q.asse f/cop"
        Risp(6) = GlobalRoutines.myStr(MecData(1).TK(2 - 1), 3, 2, False)
        A = "" ': For j = 1 To Nfield: LungSt(j) = Len(Risp$(j)): Next
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(Nfield, A, Dom, Risp, "", Archiv, dAiu) Then Exit Sub
        For j = 1 To Nfield
            Quota(j) = Val(Risp(j))
        Next
    End Sub
    Function Sezione3() As Short
        Dim jc, jj, NS1 As Short
        Dim Q, Q1 As Single
        Dim n2 As Short
        Dim Nfield, j As Short
        Dim A As String
        Dim Archiv(20) As Short
        Dim dAiu(20) As String
        'ReDim Quota(1 To 4) As Single, Quota1(1 To 4) As Single

        Sezione3 = 0
        For jj = 1 To NC
            jc = Converti(jj, jj)
            NS1 = MecData(jj).NS + 1
            Q1 = MecData(jj).XXcorr
            Q = MecData(jj).xx
            If Q1 < Q Then Q1 = Q
            Quota(jc) = Q
            Quota1(jc) = Q1
            n2 = 2 : If MecData(1).TipTest = 3 Or MecData(1).TipTest = 4 Then n2 = 1
            Dom(1) = "Lunghezza cassa"
            Risp(1) = GlobalRoutines.myStr(CSng(MecData(jj).Largf), 4, 0, True)
            Dom(2) = "Larghezza esterna cassa"
            Risp(2) = GlobalRoutines.myStr(CSng(MecData(jj).H + n2 * MecData(jj).SP(2 - 1)), 4, 0, True)
            Dom(3) = "Altezza esterna cassa"
            Risp(3) = GlobalRoutines.myStr(CSng(MecData(jj).HX3 + 2.0! * MecData(jj).SP(1 - 1)), 3, 2, False)
            Dom(4) = "Sp. p.tubiera"
            Risp(4) = GlobalRoutines.myStr(CSng(MecData(jj).SP(2 - 1)), 3, 2, False)
            Dom(5) = "Sp. p.tub/tappi"
            Risp(5) = GlobalRoutines.myStr(CSng(MecData(jj).SP(1 - 1)), 3, 2, False)
            Dom(6) = "Sp. ends   "
            Risp(6) = GlobalRoutines.myStr(CSng(MecData(jj).SP(4 - 1)), 3, 2, False)
            If MecData(1).TipTest = 3 Or MecData(1).TipTest = 4 Then Risp(6) = Risp(5)
            Nfield = 6 ': For j = 1 To Nfield: LungSt(j) = Len(Risp$(j)): Next
            A = MecData(jj).HEADER
            Monitor.Motore.Chiamante = Monitor
            If Not Monitor.Motore.InputDati(Nfield, A, Dom, Risp, "", Archiv, dAiu) Then Sezione3 = 1 : Exit Function
            For j = 1 To Nfield
                Select Case MecData(1).Tipo
                    Case 0
                        Risp2(1, j) = Risp(j)
                        Risp2(2, j) = ""
                        Risp2(3, j) = Risp(j)
                        Risp2(4, j) = ""
                    Case 1
                        Select Case jj
                            Case 1
                                Risp2(jj, j) = Risp(j)
                            Case 2
                                Risp2(1 + jj, j) = Risp(j)
                                Risp2(jj, j) = ""
                                Risp2(2 + jj, j) = ""
                        End Select
                    Case 2
                        Select Case jj
                            Case 1 : Risp2(2, j) = Risp(j)
                            Case 2 : Risp2(1, j) = Risp(j)
                            Case 3 : Risp2(3, j) = Risp(j)
                            Case 4 : Risp2(4, j) = ""
                        End Select
                    Case 3
                        Select Case jj
                            Case 1 : Risp2(1, j) = Risp(j)
                            Case 2 : Risp2(4, j) = Risp(j)
                            Case 3 : Risp2(3, j) = Risp(j)
                            Case 4 : Risp2(2, j) = ""
                        End Select
                    Case 4
                        Select Case jj
                            Case 1 : Risp2(2, j) = Risp(j)
                            Case 2 : Risp2(1, j) = Risp(j)
                            Case 3 : Risp2(4, j) = Risp(j)
                            Case 4 : Risp2(3, j) = Risp(j)
                        End Select
                End Select
            Next j 'e
        Next jj
        For j = 1 To Nfield
            If j <> 3 Then
                Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Val(Risp2(1, j)), Val(Risp2(2, j)), Val(Risp2(3, j)), Val(Risp2(4, j))))
            Else
                Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Val(Risp2(1, j)), Quota1(1), Val(Risp2(2, j)), Quota1(2), Val(Risp2(3, j)), Quota1(3), Val(Risp2(4, j)), Quota1(4)))
            End If
        Next
        Call Assumi() : PrintLine(34, GlobalRoutines.FormatS(Riga, Quota1(1), Quota1(2), Quota1(3), Quota1(4)))
        If Not EOF(35) Then Assumi()
    End Function

    Sub Sezione5()
        Dim imax, jj As Short
        Dim Q1, Q As Single
        Dim ii, j As Short
        Dim Nrtot, Nr As Single
        Dim QuotaLoc As Single
        Dim itp As String = ""
        Dim A As String
        Dim NumFor, jjj As Short
        Assumi()
        If MecData(1).PassFraz Then Call Sezione5a() : Exit Sub
        If MecData(1).HorPas <> "SI" And MecData(1).HorPas <> "  " Then
            imax = 1 : If NC = 1 Then imax = 2
            For jj = 1 To NC
                Q1 = MecData(jj).XXcorr
                Q = MecData(jj).xx
                If Q1 < Q Then Q1 = Q
                If MecData(jj).PassoRinf = 0.0! Then MecData(jj).PassoRinf = ReadLib(26, 2)
                For ii = 1 To imax
                    If MecData(jj).NS = 0 Then GoTo Cont5
                    Nrtot = 0
                    For j = 1 To MecData(jj).NS + 1
                        Nrtot = Nrtot + System.Math.Abs(MecData(jj).Nfile(j))
                    Next j 'f
                    Nr = 0 : QuotaLoc = 0
                    For j = 1 To MecData(jj).NS
                        Nr = Nr + System.Math.Abs(MecData(jj).Nfile(j))
                        QuotaLoc = QuotaLoc + MecData(jj).HX5(j)
                        iTest = objDatBase.CVI(objDatBase.DatBase(2, 9, Nrdit \ 2, 1, itp, 0))
                        Nota = "SETTO n."
                        If iTest = 2 Then
                            LARG = MecData(jj).Largf - 2 * MecData(jj).SP(4 - 1)
                            If MecData(jj).Nfile(j) < 0 Then LARG = LARG - 2 * ReadLib(1, 6) : Nota = "RINF. n."
                        ElseIf iTest = 3 Or iTest = 4 Then
                            LARG = MecData(jj).Largf - 2 * MecData(jj).SP(1 - 1)
                        End If
                        PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(Converti(jj, ii)), 0.0!, Nrtot - Nr, 0.0!, -LARG / 2.0!, LARG / 2.0!, MecData(jj).SP(3 - 1), 1.0!, Nota & Str(j), MecData(jj).HX3 - QuotaLoc - Q1))
                        If (MecData(jj).Nfile(j) < 0) Then
                            NumFor = Int(LARG / MecData(jj).PassoRinf)
                            If NumFor Mod 2 = 0 Then
                                QuotaLoc = -(NumFor / 2 - 0.5) * MecData(jj).PassoRinf
                            Else
                                QuotaLoc = -(NumFor \ 2) * MecData(jj).PassoRinf
                            End If
                            For jjj = 1 To NumFor
                                PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(Converti(jj, ii)), 0.0!, Nrtot - Nr, 0.0!, QuotaLoc - MecData(jj).BucoRinf / 2.0!, QuotaLoc + MecData(jj).BucoRinf / 2.0!, MecData(jj).SP(3 - 1) / 2.0!, 0.0!, "FORO  ", MecData(jj).HX3 - QuotaLoc - Q1))
                                QuotaLoc = QuotaLoc + MecData(jj).PassoRinf
                            Next jjj
                        Else
                            PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(Converti(jj, ii)), 0.0!, Nrtot - Nr, 0.0!, -LARG / 2.0! + 300.0! - 7.0!, -LARG / 2.0! + 300.0! + 7.0!, MecData(jj).SP(3 - 1) / 2, 0.0!, "XFIATO n." & Str(j), MecData(jj).HX3 - QuotaLoc - Q1))
                            PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(Converti(jj, ii)), 0.0!, Nrtot - Nr, 0.0!, LARG / 2.0! - 300.0! - 7.0!, LARG / 2.0! - 300.0! + 7.0!, MecData(jj).SP(3 - 1) / 2, 0.0!, "XFIATO n." & Str(j), MecData(jj).HX3 - QuotaLoc - Q1))
                            PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(Converti(jj, ii)), 0.0!, Nrtot - Nr, 0.0!, -7.0!, 7.0!, MecData(jj).SP(3 - 1) / 2, 0.0!, "XFIATO n." & Str(j), MecData(jj).HX3 - QuotaLoc - Q1))
                        End If
                    Next j 'g
Cont5:
                Next ii
            Next jj
        Else
            A = "Passaggi orizzontali e setti  |"
            A = A & "verticali: non ancora previsti|"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(A))
        End If
Fine5:
        If Not EOF(35) Then Assumi()
    End Sub

    Sub Sezione5a()
        Dim Larg1(20) As Single
        Dim Larg2(20) As Single
        Dim indice(20) As Short
        Dim iSopra, jj, NfilSopra As Short
        Dim SP As Single
        Dim Nfile, ifl, i As Short
        Dim j, NH, NTUB, NV As Short
        Dim h2, H1, Larg1Loc As Single
        Dim Larg2Loc, V1 As Single
        Dim iSettC As Short
        Dim TubiPrima, k As Short
        Dim Q1 As Single
        Dim j1 As Short
        Dim V2, Q2 As Single
        Dim itp As String = ""
        Dim Log1, Log2 As Boolean
        Dim Q1s, Q2s As Single
        Dim Ll As Single
        Dim kk As Short
        For jj = 1 To NC
            Call Tipizz(jj, iRec, iSopra)
            Call FilSopra(iSopra, NfilSopra)
            iCassa = Converti(jj, 1)
            SP = MecData(jj).SP(3 - 1)
            ifl = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, Len(MecData(1)))
            FileGet(ifl, HeaderSetti(0), iRec)
            FileClose(ifl)
            iTest = objDatBase.CVI(objDatBase.DatBase(2, 9, Nrdit \ 1, 1, itp, 0))
            Nota = "SETTO n."
            If iTest = 2 Then
                LARG = MecData(jj).Largf - 2 * MecData(jj).SP(4 - 1)
            ElseIf iTest = 3 Or iTest = 4 Then
                LARG = MecData(jj).Largf - 2 * MecData(jj).SP(1 - 1)
            End If
            Nfile = 0
            For i = 1 To 16
                Nfile = Nfile + System.Math.Abs(MecData(jj).Nfile(i))
            Next
            For i = 1 To Nfile
                NH = HeaderSetti(0).Fila(i + NfilSopra).NumSettiH
                If ((Nfile - i - NfilSopra) Mod 2) = 1 Then NTUB = Int(Rapp) + Dispari Else NTUB = Int(Rapp) + Pari
                '          Ntub0! = INT(Rapp!)
                '          IF ntub = INT(Ntub0!) THEN Ntub0! = Ntub0! + .5
                For j = 1 To NH
                    H1 = HeaderSetti(0).Fila(i + NfilSopra).SettiH1(j)
                    h2 = HeaderSetti(0).Fila(i + NfilSopra).SettiH2(j)
                    '          TubiPrima = CINT(CSNG(H1) / HeaderSetti(0).LungTest * ntub)
                    Larg1Loc = CShort(-LARG / 2)
                    Larg2Loc = -Larg1Loc
                    If System.Math.Abs(H1) < 2 And System.Math.Abs(h2 - HeaderSetti(0).LungTest) < 2 And i < Nfile Then
                        If iCassa > 2 Then Larg1Loc = -Larg1Loc : Larg2Loc = -Larg2Loc
                        PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(iCassa), 0.0!, CSng(Nfile - i), 0.0!, Larg1Loc, Larg2Loc, SP, 1.0!, Nota, 0))
                        Ll = LARG / 2.0! - 300.0!
                        For kk = -1 To 1
                            PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(iCassa), 0.0!, CSng(Nfile - i), 0.0!, Ll * kk - 7.0!, Ll * kk + 7.0!, SP / 2, 0.0!, "XFIATO ", 0))
                        Next kk
                    End If
                Next j
Vert:           NV = HeaderSetti(0).Fila(i + NfilSopra).NumSettiV
                iSettC = 1
                For j = 1 To NV
                    V1 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j)
                    TubiPrima = CShort(CSng(V1) / HeaderSetti(0).LungTest * NTUB)
                    NH = HeaderSetti(0).Fila(i - 1 + NfilSopra).NumSettiH
                    If i > 1 Then
                        For k = 1 To NH
                            H1 = HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH1(k)
                            h2 = HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH2(k)
                            If System.Math.Abs(H1 - V1) < 2 Then
                                Call QuotaReale(V1, Q1, i, NfilSopra, Nfile, iCassa)
                                If System.Math.Abs(h2 - HeaderSetti(0).LungTest) > 2 Then
                                    For j1 = j + 1 To NV
                                        V2 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j1)
                                        If System.Math.Abs(V2 - h2) < 2 Then
                                            '--------    trovato  controlla anche setto verticale success
                                            Call QuotaReale(V2, Q2, i, NfilSopra, Nfile, iCassa)
                                            Larg1(iSettC) = -LARG / 2 + Q1 - SP
                                            Larg2(iSettC) = -LARG / 2 + Q2 + SP
                                            indice(iSettC) = i - 1
                                            iSettC = iSettC + 1
                                            Exit For
                                        End If
                                    Next j1
                                    'impossibile
                                Else
                                    '---trovato: controlla successivo
                                    Larg2(iSettC) = LARG / 2
                                    Larg1(iSettC) = -LARG / 2 + Q1 - SP
                                    indice(iSettC) = i - 1
                                    iSettC = iSettC + 1
                                End If
                                HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH1(k) = -10
                                HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiH2(k) = -10
                            ElseIf System.Math.Abs(h2 - V1) < 2 Then
                                Call QuotaReale(V1, Q2, i, NfilSopra, Nfile, iCassa)
                                If System.Math.Abs(H1) > 2 Then
                                    For j1 = 1 To j - 1
                                        V2 = HeaderSetti(0).Fila(i - 1 + NfilSopra).SettiV(j1)
                                        If System.Math.Abs(V2 - H1) < 2 Then
                                            '--------    trovato  controlla anche setto verticale success
                                            Call QuotaReale(V2, Q1, i, NfilSopra, Nfile, iCassa)
                                            Larg1(iSettC) = -LARG / 2 + Q1 - SP
                                            Larg2(iSettC) = -LARG / 2 + Q2 + SP
                                            indice(iSettC) = i - 1
                                            iSettC = iSettC + 1
                                            'calcola vertici e stora
                                            Exit For
                                        End If
                                    Next j1
                                    'impossibile
                                Else
                                    '---trovato: controlla successivo
                                    Larg1(iSettC) = -LARG / 2
                                    Larg2(iSettC) = -LARG / 2 + Q2 + SP
                                    indice(iSettC) = i - 1
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
                            Call QuotaReale(V1, Q1, i, NfilSopra, Nfile, iCassa)
                            If System.Math.Abs(h2 - HeaderSetti(0).LungTest) > 2 Then
                                For j1 = j + 1 To NV
                                    V2 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j1)
                                    If System.Math.Abs(V2 - h2) < 2 Then
                                        '--------    trovato  controlla anche setto verticale success
                                        Call ContrSucc(i, Nfile, NfilSopra, H1, h2, Log1, Log2)
                                        Call QuotaReale(V2, Q2, i, NfilSopra, Nfile, iCassa)
                                        If Log1 Then
                                            Call QuotaReale(H1, Q1s, i + 1, NfilSopra, Nfile, iCassa)
                                            If Q1s < Q1 Then Q1 = Q1s
                                        End If
                                        If Log2 Then
                                            Call QuotaReale(h2, Q2s, i + 1, NfilSopra, Nfile, iCassa)
                                            If Q2s > Q2 Then Q2 = Q2s
                                        End If
                                        Larg1(iSettC) = -LARG / 2 + Q1 - SP
                                        Larg2(iSettC) = -LARG / 2 + Q2 + SP
                                        indice(iSettC) = i
                                        iSettC = iSettC + 1
                                        'calcola vertici e stora
                                        Exit For
                                    End If
                                Next j1
                                'impossibile
                            Else
                                '---trovato: controlla successivo
                                Larg2(iSettC) = LARG / 2
                                Call ContrSucc(i, Nfile, NfilSopra, H1, -1, Log1, Log2)
                                If Log1 Then
                                    Call QuotaReale(H1, Q1s, i + 1, NfilSopra, Nfile, iCassa)
                                    If Q1s < Q1 Then Q1 = Q1s
                                End If
                                Larg1(iSettC) = -LARG / 2 + Q1 - SP
                                indice(iSettC) = i
                                iSettC = iSettC + 1
                            End If
                            HeaderSetti(0).Fila(i + NfilSopra).SettiH1(k) = -10
                            HeaderSetti(0).Fila(i + NfilSopra).SettiH2(k) = -10
                        ElseIf System.Math.Abs(h2 - V1) < 2 Then
                            Call QuotaReale(V1, Q2, i, NfilSopra, Nfile, iCassa)
                            If System.Math.Abs(H1) > 2 Then
                                For j1 = 1 To j - 1
                                    V2 = HeaderSetti(0).Fila(i + NfilSopra).SettiV(j1)
                                    If System.Math.Abs(V2 - H1) < 2 Then
                                        '--------    trovato  controlla anche setto verticale success
                                        Call ContrSucc(i, Nfile, NfilSopra, H1, h2, Log1, Log2)
                                        Call QuotaReale(V2, Q1, i, NfilSopra, Nfile, iCassa)
                                        If Log1 Then
                                            Call QuotaReale(H1, Q1s, i + 1, NfilSopra, Nfile, iCassa)
                                            If Q1s < Q1 Then Q1 = Q1s
                                        End If
                                        If Log2 Then
                                            Call QuotaReale(h2, Q2s, i + 1, NfilSopra, Nfile, iCassa)
                                            If Q2s > Q2 Then Q2 = Q2s
                                        End If
                                        Larg1(iSettC) = -LARG / 2 + Q1 - SP
                                        Larg2(iSettC) = -LARG / 2 + Q2 + SP
                                        indice(iSettC) = i
                                        iSettC = iSettC + 1
                                        'calcola vertici e stora
                                        Exit For
                                    End If
                                Next j1
                                'impossibile
                            Else
                                '---trovato: controlla successivo
                                Larg1(iSettC) = -LARG / 2
                                Call ContrSucc(i, Nfile, NfilSopra, -1, h2, Log1, Log2)
                                If Log2 Then
                                    Call QuotaReale(h2, Q2s, i + 1, NfilSopra, Nfile, iCassa)
                                    If Q2s > Q2 Then Q2 = Q2s
                                End If
                                Larg2(iSettC) = -LARG / 2 + Q2 + SP
                                indice(iSettC) = i
                                iSettC = iSettC + 1
                            End If
                            HeaderSetti(0).Fila(i + NfilSopra).SettiH1(k) = -10
                            HeaderSetti(0).Fila(i + NfilSopra).SettiH2(k) = -10
                        End If
                    Next k
                    PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(iCassa), 1.0!, CSng(TubiPrima), CSng(Nfile + 1 - i), 0.0!, 0.0!, SP, 1.0!, "", 0))
                Next j 'h
                iSettC = iSettC - 1
                For j1 = 1 To iSettC
                    If iCassa > 2 Then
                        Larg1(j1) = -Larg1(j1) : Larg2(j1) = -Larg2(j1)
                        GlobalRoutines.SWAP(Larg1(j1), Larg2(j1))
                    End If
                    PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(iCassa), 0.0!, CSng(Nfile - indice(j1)), 0.0!, Larg1(j1), Larg2(j1), SP, 1.0!, Nota, 0))
                    Ll = LARG / 2.0! - 300.0!
                    For kk = -1 To 1
                        If Ll * kk > Larg1(j1) + 50.0! And Ll * kk < Larg2(j1) - 50.0! Then PrintLine(34, GlobalRoutines.FormatS(Riga, CSng(iCassa), 0.0!, CSng(Nfile - indice(j1)), 0.0!, Ll * kk - 7.0!, Ll * kk + 7.0!, SP / 2, 0.0!, "XFIATO ", 0))
                    Next kk
                Next j1
            Next i
        Next jj
    End Sub

    Sub Tipizz(ByRef iCassa As Short, ByRef iRec As Short, ByRef iSopra As Short)
        Select Case MecData(1).Tipo
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
                        iSopra = 0
                        iRec = 5
                    Case 2
                        iSopra = 0
                        iRec = 6
                    Case 3
                        iSopra = 2
                        iRec = 6
                End Select
            Case 4
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
                    Case 4
                        iSopra = 3
                        iRec = 6
                End Select
        End Select
    End Sub
    Sub TracciaTubi2()
        Select Case MecData(1).Tipo
            Case 0, 1 : NumFile = MecData(1).NROWS : Destra = 1
            Case 3 : NumFile = MecData(1).NROWS : Destra = 2
            Case 2 : NumFile = MecData(3).NROWS : Destra = 3
            Case 4 : NumFile = MecData(1).NROWS + MecData(2).NROWS : Destra = 3
        End Select
        Dim x1(NumFile) As Single
        Dim y1(NumFile) As Single
        Dim y2(NumFile) As Single
        Dim SensoStr(NumFile) As Single
        ifl = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, Len(MecData(1)))
        FileGet(ifl, HeaderStruct(0), 7)
        FileClose(ifl)
        If MecData(1).Tipo > 0 Then
            For j = 1 To HeaderStruct(0).NumFile
                n = HeaderStruct(0).Fila(j).NumFrazioni
                If n = 1 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SensoStr(HeaderStruct().NumFile + 1 - j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If HeaderStruct(0).Fila(j).IngrVersoUsc(1) Then
                        SensoStr(HeaderStruct(0).NumFile + 1 - j) = "D"
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SensoStr(HeaderStruct().NumFile + 1 - j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SensoStr(HeaderStruct(0).NumFile + 1 - j) = "S"
                    End If
                Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SensoStr(HeaderStruct().NumFile + 1 - j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SensoStr(HeaderStruct(0).NumFile + 1 - j) = "A"
                End If
            Next
        Else
            For j = 1 To NumFile
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SensoStr(j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SensoStr(j) = "D" : Next
        End If
        'Senso = 1
        Rapp = CSng(MecData(1).NTUB) / NumFile
        If (Rapp - Int(Rapp) < 0.05) Then
            Pari = 0 : Dispari = 0
        Else
            Pari = 0 : Dispari = 1
        End If
        If (NumFile Mod 2) = 1 Then GlobalRoutines.SWAP(Pari, Dispari)
        Assumi()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y1(0). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        y1(0) = -MecData(1).PVERT
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y2(0). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        y2(0) = -MecData(1).PVERT
        Nff = 0 'contatore integrale su file esaminate
        '--------------------------------------------------------------------
        For j = 1 To NumFile Step 2 'j cresce dal basso verso l'alto (davvero)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y1(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y1(j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y1(j) = y1(j - 1) + MecData(1).PVERT
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y2(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y2(j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y2(j) = y2(j - 1) + MecData(1).PVERT
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y1(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y1(j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y1(j) = y1(j) + Add1(1) + Add1(2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y2(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y2(j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y2(j) = y2(j) + Add1(2) + Add1(1)
            Ntubi(j) = Int(Rapp) + Dispari
            If Dispari >= Pari Then
                x1(j) = 0.0!
            Else
                x1(j) = MecData(1).TSP / 2
            End If
            iprov = 0
            CalcAdd()
            If j + 1 <= NumFile Then
                y1(j + 1) = y1(j) + MecData(1).PVERT
                y2(j + 1) = y2(j) + MecData(1).PVERT
                y1(j + 1) = y1(j + 1) + Add1(1) + Add1(2)
                y2(j + 1) = y2(j + 1) + Add1(2) + Add1(1)
                Ntubi(j + 1) = Int(Rapp) + Pari
                If Dispari >= Pari Then
                    x1(j + 1) = MecData(1).TSP / 2
                Else
                    x1(j + 1) = 0.0!
                End If
                iprov = 1
                CalcAdd()
            End If
        Next
        YY1 = 0.0! : YY2 = 0.0!
        For j = NumFile To 1 Step -1
            jj = NumFile + 1 - j
            If y1(jj) < YY1 Then
                For jjj = jj + 1 To NumFile
                    y1(jjj) = y1(jjj) + y1(jj) - YY1 : Next
                y1(jj) = YY1
            End If
            If y2(jj) < YY2 Then
                For jjj = jj + 1 To NumFile
                    y2(jjj) = y2(jjj) + y2(jj) - YY2 : Next
                y2(jj) = YY2
            End If
            PrintLine(34, GlobalRoutines.FormatS(Riga, jj, MecData(1).DO_Renamed, x1(jj), YY1, YY2, Ntubi(jj), MecData(1).TSP, 0, 0.0!, 0, 0.0!, SensoStr(jj)))
            If j = 1 Then Exit For
            YY1 = YY1 + MecData(1).Passo(j - 1) 'provvisorio
            YY2 = YY2 + MecData(Destra).Passo(j - 1) 'provvisorio
            If y1(jj + 1) > YY1 Then YY1 = y1(jj + 1)
            If y2(jj + 1) > YY2 Then YY2 = y2(jj + 1)
            If System.Math.Abs(YY1 - Int(YY1)) < 0.01 Then YY1 = Int(YY1)
            If System.Math.Abs(YY2 - Int(YY2)) < 0.01 Then YY2 = Int(YY2)
        Next
        If Not EOF(35) Then Assumi()
    End Sub
    Private Sub Fai()
        jj = MecData(k).NS + 1 - Giafatto(k)
        If jj = 0 Then
            Add(k) = 0
        ElseIf (System.Math.Abs(MecData(k).Nfile(jj)) + Nfv(l) = Nff) Then
            Giafatto(k) = Giafatto(k) + 1
            If jj > 1 Then
                Add(k) = MecData(k).VUOTO(jj - 1) / 2
            Else
                Add(k) = 0.0!
            End If
            If jj > 1 Then
                If MecData(k).Nfile(jj - 1) > 0 Then Senso = -Senso
            End If
            '     PRINT "k", k, Senso, jj, Giafatto(k), L: u$ = INPUT$(1)
            Nfv(l) = Nff
        ElseIf Nfv(l) = Nff And Giafatto(k) = 0 Then
            Add(k) = MecData(k).VUOTO(jj) / 2
        Else
            Add(k) = 0.0!
        End If
    End Sub
    Private Sub CalcAdd()
        Nff = Nff + 1 ' jj e' il contatore delle camere
        'sinistra--------------------------------
        l = 1
        If MecData(1).Tipo = 2 Or MecData(1).Tipo = 4 Then
            k = 2
            Call Fai()
            If Giafatto(2) = MecData(2).NS + 1 Then
                Senso = -Senso : k = 1
                Call Fai()
            End If
        Else
            k = 1
            Call Fai()
        End If
        Add1(1) = Max(Add(1), Add(2))
        'destra ---------------------------------
        l = 2
        Select Case MecData(1).Tipo
            Case 0 : Add1(2) = 0.0!
            Case 1 : k = 2
                Call Fai() : Add1(2) = Add(k)
            Case 2 : k = 3
                Call Fai() : Add1(2) = Add(k)
            Case 3 : k = 3
                Call Fai()
                If Giafatto(3) = MecData(3).NS + 1 Then
                    k = 2 : Senso = -Senso
                    Call Fai()
                End If
                Add1(2) = Max(Add(3), Add(2))
            Case 4 : k = 4
                Call Fai()
                If Giafatto(4) = MecData(4).NS + 1 Then
                    k = 3 : Senso = -Senso
                    Call Fai()
                End If
                Add1(2) = Max(Add(3), Add(4))
        End Select
    End Sub
    Sub FilSopra(ByRef iSopra As Short, ByRef NfilSopra As Short)
        Dim i As Short
        If iSopra > 0 Then
            NfilSopra = 0
            For i = 1 To 16
                NfilSopra = NfilSopra + System.Math.Abs(MecData(iSopra).Nfile(i))
            Next
        Else
            NfilSopra = 0
        End If
    End Sub
    Sub ContrSucc(ByRef i As Short, ByRef Nfile As Short, ByRef NfilSopra As Short, ByRef H1 As Single, ByRef h2 As Single, ByRef Log1 As Boolean, ByRef Log2 As Boolean)
        Dim j2, NVs As Short
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
    Private Sub Assumi()
        Dim Cod As String
        Do
            Riga = LineInput(35)
            Riga = RTrim(Riga)
            If Len(Riga) > 3 Then
                Cod = Right(Riga, 3)
                'Riga$ = LEFT$(Riga$, LEN(Riga$) - 3)
            Else
                Cod = "N"
                Riga = New String(" ", 121) & Cod
            End If
            If Right(Cod, 1) = "A" Then PrintLine(34, Riga) Else Exit Do
            If EOF(35) Then Exit Do
        Loop
    End Sub
    Function Capacity() As Single
        cAp = MecData(1).NTUB * PI * (MecData(1).DO_Renamed - 2 * MecData(1).SPTUB) ^ 2 / 4 * MecData(1).LUNGF
        If MecData(1).Tipo = 0 Then
            indice = 1
            Calcola()
            cAp = cAp + 2.0! * Volume
        Else
            For indice = 1 To nCasse(MecData(1).Tipo)
                Calcola()
                cAp = cAp + Volume
            Next
        End If
        For i = 1 To nCasse(MecData(1).Tipo)
            cAp = cAp + MecData(i).nBocIn * VolIn
            cAp = cAp + MecData(i).nBocOut * VolOut
        Next
        cAp = cAp / 1000000.0!
        Capacity = cAp
    End Function
    Private Sub Calcola()
        Altz = MecData(1).HX3
        If MecData(1).NS > 0 Then
            For i = 1 To MecData(1).NS
                If MecData(1).Nfile(i) > 0 Then
                    Fact = 1.0!
                Else
                    Fact = MecData(1).BucoRinf ^ 2 * MecData(1).Largf / MecData(1).PassoRinf / (MecData(1).H * MecData(1).Largf)
                End If
                Altz = Altz - Fact * MecData(1).SP(3)
            Next
        End If
        Volume = MecData(1).H * Altz * (MecData(1).Largf - 2 * MecData(1).SP(4))
    End Sub
    Function CodiceT(ByRef DisDet As String, ByRef Record As RecAPRn) As String
        Dim ifl, iPoss As Short
        Dim D1 As String = ""
        Dim V2 As String = ""
        Dim D2 As String = ""
        Dim D3 As String = ""
        Dim D4 As String = ""
        Dim V3 As String = ""
        Dim V4 As String = ""
        Dim ASA, DN, Prep As String
        Dim Dint As Single
        Dim CercaDint, CercaLung As Boolean
        Dim Mat As LibMat.MaterialeNew1 = New LibMat.MaterialeNew1
        Dim j, ia, i As Short
        Dim Lung As Single
        Dim Cerca, Descr1 As String
        Dim l As Short
        Dim X As Short
        Dim Tabella As dao.Recordset
        If Not Apert.mnuAttivaCodici.Checked Then
            CodiceT = "UNKNOWN"
            Exit Function
        End If
        ifl = FreeFile()
        If Record.Indmat > 0 Then
            Mat.Indmat = Record.Indmat
            Mat.RecupMat(Monitor.Motore.Inizio.Archdir)
        End If
        Select Case Record.Tipo
            Case 15 'rettangoli
                Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='LA' AND CT='00' AND Mat='" & Trim(Mat.CMT) & "' AND Val(Valor1)=" & Str(Record.Dati(1)))
                If Tabella.RecordCount > 0 Then
                    CodiceT = Tabella.Fields("Codice").Value
                Else
                    CodiceT = "UNKNOWN"
                End If
            Case 2 'tronchetti
                Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='TR' AND CT='00' AND Mat='" & Trim(Mat.CMT) & "'")
                Tabella.Filter = "Abs(" & Str(Record.Dati(2)) & "-Val(Valor1)) < 1 And Abs(" & Str(Record.Dati(3)) & "-Val(Valor2))<0.2"
                Tabella = Tabella.OpenRecordset
                If Tabella.RecordCount > 0 Then
                    CodiceT = Tabella.Fields("Codice").Value
                Else
                    CodiceT = "UNKNOWN"
                End If
            Case 10 'flange
                Dim Poss(21) As String
                Dim CodCod(21) As String
                iPoss = 0
                Flangia.carica(Monitor.Motore.Inizio.DiscoRam)
                Flangia.K1 = Record.Dati(2)
                Flangia.K2 = Record.Dati(3)
                Flangia.K3 = Record.Dati(4)
                Flangia.leggi(Flangia.K1, Flangia.K2, 1, 0, Flangia.K3, False, Monitor.Motore.Inizio.DiscoRam)
                DN = Flangia.strDiam
                ASA = Flangia.strRati
                Prep = Right(RTrim(Record.DIME), 2)
                DisDet = LTrim(DisDet)
                If Left(DisDet, 4) = "BORE" Then
                    Dint = Val(Right(DisDet, Len(DisDet) - 4))
                Else
                    Dint = 0
                End If
                If Not (Prep = "RJ" Or Prep = "RF") Then Prep = "RF"
                If Record.Dati(10) = 7 Then Flangia.K3 = 5
                Select Case Flangia.K3
                    Case 1 'Open Monitor.Motore.Inizio.Archdir + "\FLAW.COD" For Input Shared As #ifl
                        Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='FL' AND CT='AW' AND Mat='" & Trim(Mat.CMT) & "' AND Valor1='" & ASA & "'")
                    Case 4
                        If Prep = "RJ" Then
                            Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='FL' AND CT='LR' AND Mat='" & Trim(Mat.CMT) & "' AND Valor1='" & ASA & "'")
                        Else
                            Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='FL' AND CT='AL' AND Mat='" & Trim(Mat.CMT) & "' AND Valor1='" & ASA & "'")
                        End If
                    Case 5 'Open Monitor.Motore.Inizio.Archdir + "\FLAB.COD" For Input Shared As #ifl
                        Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='FL' AND CT='AB' AND Mat='" & Trim(Mat.CMT) & "' AND Valor1='" & ASA & "'")
                End Select
                CercaDint = False : CercaLung = False
                If Tabella.RecordCount > 0 Then
                    V2 = Trim(Tabella.Fields("Valor2").Value)
                    ia = Asc(Right(V2, 1))
                    If ia < 48 Or ia > 57 Then V2 = Left(V2, Len(V2) - 1)
                    For j = 1 To Len(V2)
                        ia = Asc(Mid(V2, j, 1))
                        If ia < 47 Or ia > 57 Then Mid(V2, j, 1) = " "
                    Next
                    If DN = V2 Then
                        If Flangia.K3 = 4 Or Prep = Left(Trim(Tabella.Fields("Valor4").Value), 2) Then
                            CercaDint = True
                            If Flangia.K3 = 5 Or System.Math.Abs(Dint - Val(Tabella.Fields("Valor3").Value)) < 1 Or Dint = 0 Then
                                CercaLung = True
                                If (Flangia.K3 <> 4 Or System.Math.Abs(Lung - Val(Tabella.Fields("Valor4").Value)) < 1000) And iPoss < 20 Then
                                    iPoss = iPoss + 1
                                    Poss(iPoss) = Tabella.Fields("Codice").Value + Chr(32) + CStr(Tabella.Fields("Descrizione")).PadRight(20) + Chr(32)
                                    Poss(iPoss) = Poss(iPoss) + D1.PadRight(6) + CStr(Tabella.Fields("Valor1")).PadRight(5)
                                    If Len(RTrim(D2)) > 0 Then Poss(iPoss) = Poss(iPoss) + D2.PadRight(6) + V2.PadRight(5)
                                    If Len(RTrim(D3)) > 0 Then Poss(iPoss) = Poss(iPoss) + D3.PadRight(6) + V3.PadRight(5)
                                    If Len(RTrim(D4)) > 0 Then Poss(iPoss) = Poss(iPoss) + D4.PadRight(6) + V4.PadRight(5)
                                    CodCod(iPoss) = Tabella.Fields("Codice").Value
                                End If
                            End If
                        End If
                    End If
                Else
                End If
                If Flangia.K3 = 4 Then
                    Tabella = myDataBase.OpenRecordset("SELECT * FROM CODMAT WHERE Categoria='FL' AND CT='*' AND Mat='" & Trim(Mat.CMT) & "'")
                    If Not Tabella.NoMatch Then
                        Do Until Tabella.EOF
                            Cerca = DN & Chr(34) & ASA
                            Lung = Len(Tabella.Fields("Descrizione").Value) - Len(Cerca)
                            For i = 1 To Lung
                                Descr1 = Mid(Tabella.Fields("Descrizione").Value, i, Len(Cerca))
                                l = InStr(Descr1, ".")
                                If l > 0 Then Mid(Descr1, l, 1) = Chr(32)
                                If Descr1 = Cerca Then
                                    If iPoss < 20 Then
                                        iPoss = iPoss + 1
                                        Poss(iPoss) = Tabella.Fields("Codice").Value + Chr(32) + CStr(Tabella.Fields("Descrizione")).PadRight(40) + Chr(32)
                                        CodCod(iPoss) = Tabella.Fields("Codice").Value
                                    End If
                                End If
                            Next
                            Tabella.MoveNext()
                        Loop
                    End If
                End If
                If iPoss = 0 Then
                    If CercaDint Then CodiceT = "DIAMINT" Else CodiceT = "UNKNOWN"
                ElseIf iPoss = 1 Then
                    CodiceT = Tabella.Fields("Codice").Value
                Else
                    iPoss = iPoss + 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Poss$(iPoss). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Poss(iPoss) = "Nessuno fra questi"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    X = Monitor.Motore.Quale(iPoss, RTrim(Record.Denom) & "(" & RTrim(Record.DIME) & ")", Poss, "", 1) ' 75,, True)
                    If X = iPoss Or X = 0 Then
                        CodiceT = "UNKNOWN"
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CodCod$(X). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CodiceT = CodCod(X)
                    End If
                End If
            Case 13 'bulloneria
                MsgBox("CodiceT: Lavori in corso")
                ''      If Record.Dati(9) = 1 Then
                ''        Open Monitor.Motore.Inizio.Archdir + "\DAS0.COD" For Input Shared As #ifl
                ''        Bull = False
                ''      Else
                ''        Open Monitor.Motore.Inizio.Archdir + "\TIS0.COD" For Input Shared As #ifl
                ''        Bull = True
                ''      End If
                ''        DIME$ = Record.DIME
                ''        l = InStr(DIME$, Chr$(34))
                ''        If l = 0 Then
                ''           l = InStr(DIME$, "in")
                ''           If l = 0 Then
                ''             Debug.Print "Errore1 tiranti in CodiceT"; DIME$: Stop
                ''              DN$ = "?? "
                ''           End If
                ''        Else
                ''           DN$ = Left$(DIME$, l - 1)
                ''        End If
                ''        Lung = Record.Dati(1)
                ''        l = InStr(DIME$, "UN")
                ''        If l = 0 Then
                ''           Pass$ = "??"
                ''        Else
                ''           Pass$ = LTrim$(RTrim$(Mid$(DIME$, l - 2, 4)))
                ''        End If
                ''        Do
                ''65         Input #ifl, Cod$, CAT$, CT$, Matt$, D1$, V1$, D2$, V2$, D3$, V3$, D4$, V4$, Descr$, UM$, Classe$
                ''           If Left$(Cod$, 1) <> "M" Then Debug.Print Cod$, CAT$, CT$, Matt$: Stop
                ''           'PROVVISORIO
                ''           If Matt$ = "Q02" And Bull Or Matt$ = "Q14" And Not Bull Then
                ''66            V1$ = RTrim$(LTrim$(V1$))
                ''              If Len(V1$) = 0 Then V1$ = "0"
                ''              ia = Asc(Right$(V1$, 1))
                ''67            If ia < 48 Or ia > 57 Then V1$ = Left$(V1$, Len(V1$) - 1)
                ''              For j = 1 To Len(V1$)
                ''68              ia = Asc(Mid$(V1$, j, 1))
                ''                If ia < 47 Or ia > 57 Then Mid$(V1$, j, 1) = " "
                ''              Next
                '''              IF u$ = "e" THEN END
                ''69            If DN$ = V1$ And Pass$ = LTrim$(RTrim$(V2$)) Then
                ''                 PRINT Bull; V3$; V4$; Lung
                ''70               If Bull And Len(LTrim$(RTrim$(V4$))) = 0 And Abs(Val(V3$) - Lung) <= 4 Then
                ''                 CodiceT = Cod$
                ''                 Exit Do
                ''                 End If
                ''71               If Not Bull And Len(LTrim$(RTrim$(V3$))) = 0 Then
                ''                 CodiceT = Cod$
                ''                 Exit Do
                ''                 End If
                ''              End If
                ''           End If
                ''           If EOF(ifl) Then
                ''              CodiceT = "UNKNOWN"
                ''              Exit Do
                ''           End If
                ''        Loop
                ''        Close #ifl
            Case Else
                CodiceT = ""
        End Select
        If Not Tabella Is Nothing Then Tabella.Close()
        Exit Function
        'ErrCodice:
        '  If Err = 52 And Erl = 62 Then Resume 621
        '  Print "Errore in CodiceT"; Err; Erl: Stop
    End Function
    Public Sub InitFlangia()
        If Not Funzioni Is Nothing Then Exit Sub
        Funzioni = New Grafica.LibGra
        If Monitor.routines Is Nothing Then Monitor.routines = New RoutBase1.Routines
        Funzioni.DoveRoutines = Monitor.routines
        Funzioni.DoveMotore = Monitor.Motore
        Flangia = New Grafica.Flangia
    End Sub
    Public Sub FineFlangia()
        If Funzioni Is Nothing Then Exit Sub
        'Flangia.Class_Terminate()
        Flangia = Nothing
        'Funzioni.Class_Terminate()
        Funzioni = Nothing
    End Sub
End Module