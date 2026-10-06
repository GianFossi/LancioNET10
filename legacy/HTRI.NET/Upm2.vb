Option Strict Off
Option Explicit On
Module modUPM2
    Structure StructFila
        Dim NumFrazioni As Short
        <VBFixedArray(6)> Dim Frazione() As Single
        <VBFixedArray(6)> Dim completo() As Short '0:si 1:continua 2:fine
        <VBFixedArray(6)> Dim IngrVersoUsc() As Short
        <VBFixedArray(6)> Dim NumPasso() As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim Frazione(6)
            ReDim completo(6)
            ReDim IngrVersoUsc(6)
            ReDim NumPasso(6)
        End Sub
    End Structure
	Structure StructHeader
		Dim NumFile As Short
		'UPGRADE_WARNING: È possibile che singoli elementi della matrice Fila debbano essere inizializzati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"'
		<VBFixedArray(16)> Dim Fila() As StructFila
		Dim IngrTipo As Short
		<VBFixedArray(136)> Dim Padding() As Short
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim Fila(16)
			'UPGRADE_WARNING: Il limite inferiore della matrice Padding è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim Padding(136)
		End Sub
	End Structure
	Structure SettiFila
		Dim NumSettiV As Short
		<VBFixedArray(6)> Dim SettiV() As Single
		Dim NumSettiH As Short '-1 se intero
		<VBFixedArray(6)> Dim SettiH1() As Single
		<VBFixedArray(6)> Dim SettiH2() As Single
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim SettiV(6)
			ReDim SettiH1(6)
			ReDim SettiH2(6)
		End Sub
	End Structure
	Structure SettiHeader
		Dim NumFile As Short
		Dim LungTest As Short
		'UPGRADE_WARNING: È possibile che singoli elementi della matrice Fila debbano essere inizializzati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"'
		<VBFixedArray(16)> Dim Fila() As SettiFila
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim Fila(16)
		End Sub
	End Structure 'deve essere lungo 1500!!!!
	'COMMON SHARED /HS/ HeaderStruct() AS StructHeader, HeaderSetti()  AS SettiHeader, File() AS SINGLE
	Public Const TOLLERANZA As Double = 0.01
    Private NTUB(16) As Short
	Private Dtub(16) As Single
	Private SP(16) As Single
	Private dist(16) As Single
    Private Uom2job As RoutBase1.clsjob
    Private FF As String
    '=====================================================================
    Private nPassi As Short
    Private A, B As Single
    Private Archiv(16) As Short
    Private dAiu(16) As String
    Private itp As String
    Private i As Short
    Private Tit, u As String
    Private Risp1(16) As String
    Private Nfile As Short
    Private BWG1, File1, TOL1 As String
    Private BWG2, TOL2 As String
    Private Sp1 As Single
    Private Risp2(16) As String
    Private iflOu As Short
    Private Dia2, Dia1, Passo1, Sp2 As Single
    Private TotLen, Passo2, LibLen As Single
    Private Alfa, Sall, ModYoung As Single
    Private nfil1, ntip, nfil2 As Short
    Private k, iflIn, j As Short
    Private Riga As String
    Private nf, Splitta, k1 As Short
    Private jj, Esito As Short
    Private Pari, NtubTot, Dispari As Short
    Private Rapp As Single
    '=======================================================================
    Function LeggiTubi(ByRef File As String) As Integer
        Dim ifl As Short
        Dim Riga As String
        Dim i, j As Short
        ifl = FreeFile()
        FileOpen(ifl, File, OpenMode.Input)
        Do
            Riga = LineInput(ifl)
        Loop Until Left(Riga, 8) = "I   1  I"
        Dtub(1) = Val(Mid(Riga, 9, 8))
        NTUB(1) = Val(Mid(Riga, 54, 3))
        dist(1) = Val(Mid(Riga, 29, 9))
        i = 1
        Do
            i = i + 1
            Riga = LineInput(ifl)
            Dtub(i) = Val(Mid(Riga, 9, 8))
            NTUB(i) = Val(Mid(Riga, 54, 3))
            dist(i) = Val(Mid(Riga, 29, 9))
        Loop While Left(Riga, 1) = "I"
        i = i - 1
        LeggiTubi = i
        For j = 1 To i
            dist(j) = dist(i) - dist(j)
        Next
        For j = 1 To i \ 2
            GlobalRoutines.SWAP(Dtub(j), Dtub(i + 1 - j))
            GlobalRoutines.SWAP(NTUB(j), NTUB(i + 1 - j))
            GlobalRoutines.SWAP(dist(j), dist(i + 1 - j))
        Next
        FileClose(ifl)
    End Function

    Function WatchFileTT() As String
        Dim comm, f As String
        Dim jj As Short
        Dim k As Short
        Dim DirDir, Nome1 As String
        WatchFileTT = ""
        If Asc(Uom2job.contratto) < 33 Or Left(Uom2job.contratto, 1) = "$" Then Exit Function
        comm = objDatBase.Readreco(1, 46, 2)
        If Asc(comm) < 33 Then comm = LTrim(Uom2job.contratto)
        If Len(comm) <> 4 Then Exit Function
        Dim ContrFile = Monitor.Motore.Inizio.Workdir + "\" + comm + ".Uom2job"
        Dim ContrNome As String
        Uom2job = Monitor.Motore.Retrievejob(ContrNome, ContrFile)
        For jj = 1 To Uom2job.Njobs
            '           f = Monitor.Motore.Inizio.Workdir + "\" + RTrim(Uom2job.Arch(jj)) + ".TEM"
            Uom2job.RetrieveCom(jj)
            '            FileOpen(36, f, OpenMode.Random, , , Len(Lav(0)))
            '          If LOF(36) = 0 Then FileClose(36) : Exit Function
            '         FileGet(36, Lav(1), 1)
            'FileClose(36)
            For k = 1 To 30
                If RTrim(Uom2job.Comm.Ind(1).Data.Assieme) = RTrim(Uom2job.Comm.Ind.Item(k).Data.Assieme) Then GoTo Cont
            Next
        Next jj
        Exit Function
Cont:
        DirDir = Monitor.Motore.Inizio.Workdir + "\" + Uom2job.Comm.Arch
        Nome1 = DirDir & "\" & Uom2job.Comm.Ind.Item(k).Data.File & ".DAT"
        If Len(Dir(Nome1)) = 0 Then Exit Function
        WatchFileTT = Nome1
    End Function
    Function SplitCas(ByRef Mode As Short) As Boolean
        Prev = Uom2job.Contratto
        'Mode 0:chiamato da Config  1:stand alone  2:definitivo
        SplitCas = True
        iPag = 1 : nPag = 1
        'IF Mode = 2 THEN
        '   iPag = 2 + nCasse(TipoFas): nPag = 2 + nCasse(TipoFas)
        'END IF
10:     FF = Right(FileMec, 10) 'FileMEC???
        Select Case Mode
            Case 0
                'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(33, MecData(0), 1)
                nPassi = MecData(0).nPassi
            Case 1
                Risp(1) = " 0"
                Dom(1) = "Numero passi" ': LungSt(1) = 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Monitor.Motore.Chiamante = Monitor
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Not Monitor.Motore.InputDati(1, "", Dom, Risp, "", Archiv, dAiu) Then GoTo FinSplit
                nPassi = Val(Risp(1))
            Case 2
                FileClose(33)
                'Nomi$(1,1)????????
20:             FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
                'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(33, MecData(0), 1)
                nPassi = MecData(0).nPassi
        End Select
        If nPassi <= 1 Then GoTo FinSplit
        'UniM$ = ReadReco(1, 41, 1)
        A = 1.8 : B = 32.0!
        'IF UniN$ = "BR" THEN A! = 1!: B! = 0!
        '-----------------------------------------
300:
        For i = 1 To nPassi
            If Mode = 0 Or Mode = 2 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Risp(i) = GlobalRoutines.myStr((objDatBase.CVS(objDatBase.DatBase(7, 24 + i, Nrdit \ 2, 1, itp, 0)) - B) / A, 3, 2, False)
            ElseIf Mode = 1 Then
                Risp(i) = "  0.00"
            End If
            Dom(i) = "T.media tubi passo" & Str(i)
            'LungSt(i) = Len(Risp$(i))
        Next
        '------------------------------------------
        Tit = "Temperature tubi"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(nPassi, Tit, Dom, Risp, "", Archiv, dAiu) Then GoTo FinSplit
        If Mode = 0 Then
            For i = 1 To nPassi
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.MKS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.PutBasCh. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                u = objDatBase.PutBasCh(7, 24 + i, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp(i)) * A + B), 0)
            Next
        End If
        '-------------------------------------------
400:    For i = 1 To nPassi
            If Mode = 0 Or Mode = 2 Then
                Risp1(i) = GlobalRoutines.myStr(objDatBase.CVS(objDatBase.DatBase(7, 1 + i, Nrdit \ 2, 1, itp, 0)), 3, 2, False)
                If System.Math.Abs(Val(Risp1(i)) - Int(Val(Risp1(i)))) > 0.05 Then
                    i = SPLIT2(iPag, nPag, FF, Prev)
                    GoTo NoPrevist
                End If
            ElseIf Mode = 1 Then
                Risp1(i) = "  0.00"
            End If
            Dom(i) = "N.file passo" & Str(i)
            'LungSt(i) = Len(Risp1$(i))
        Next
        Tit = "Numero file"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(nPassi, Tit, Dom, Risp1, "", Archiv, dAiu) Then GoTo FinSplit
410:
        If Mode = 0 Or Mode = 2 Then
            For i = 1 To nPassi
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.MKS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.PutBasCh. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                u = objDatBase.PutBasCh(7, 1 + i, Nrdit \ 2, 1, objDatBase.MKS(Val(Risp1(i))), 0)
            Next
        Else
            Nfile = 0
            For i = 1 To nPassi : Nfile = Nfile + Val(Risp1(i)) : Next
        End If
        '-------------------------------------------
420:
        If Mode = 0 Or Mode = 2 Then
            File1 = WatchFileTT()
            If Len(File1) > 0 Then
                Nfile = LeggiTubi(File1)
                BWG1 = objDatBase.DatBase(4, 54, Nrdit \ 2, 1, itp, 0)
                TOL1 = objDatBase.DatBase(4, 55, Nrdit \ 2, 1, itp, 0)
                SpsBWG = BWG1 : SpsTol = TOL1
                Sp1 = 25.4 * objBWG.SpBWG(SpsBWG, SpsTol)
                For i = 1 To Nfile : SP(i) = Sp1 : Next  'Provvisorio
                GoTo Jumpa
            Else
                '              Riga = "Non e' stato ancora generato il|"
                '       Riga = Riga + "testate/telai. Alcuni dati sono|"
                '       Riga = Riga + "quindi da fornire a mano       |"
                '           MsgBox Monitor.Motore.Inizio.ConvertiCr(at2(139)), vbInformation + vbOKOnly, "ISA" ', 4, 3, 11, 48, "OK", "", "")
                MostraAiuto(IDH_UPM_NOFILETT)
                Nfile = 0
                For i = 1 To nPassi : Nfile = Nfile + Val(Risp1(i)) : Next
                DatiSupp(Mode)
            End If
        Else
            DatiSupp(Mode)
        End If
        If Mode = 0 Or Mode = 2 Then Call Recover()
        '--------------------------------
        'Dom$(1) = "N. di tipi di tubi (max 2)"
        'Dom$(2) = "N. file con 1. tipo"
        'Dom$(3) = "N. file con 2. tipo"
        'Dom$(4) = "Diam. 1. tipo [mm]"
        'Dom$(5) = "Diam. 2. tipo [mm]"
        'Dom$(6) = "Spess. 1. tipo [mm]"
        'Dom$(7) = "Spess. 2. tipo [mm]"
        'Dom$(8) = "Passo vert. 1. tipo [mm]"
        'Dom$(9) = "Passo vert. 2. tipo [mm]"
        Tit = "Geometria tubi"
        For i = 1 To 9 : Dom(i) = Helpstringa(1140 - 1 + i) : Next
        If Mode = 1 Then
            Risp2(1) = "  1" : Risp2(2) = " " & Str(Nfile) : Risp2(3) = "  0"
            For i = 4 To 9 : Risp2(i) = "   0.   " : Next
        Else
            Risp2(1) = Str(ntip)
            Risp2(2) = Str(nfil1) : Risp2(3) = Str(nfil2)
            Risp2(4) = GlobalRoutines.myStr(Dia1, 3, 3, False)
            Risp2(5) = GlobalRoutines.myStr(Dia2, 3, 3, False)
            Risp2(6) = GlobalRoutines.myStr(Sp1, 3, 3, False)
            Risp2(7) = GlobalRoutines.myStr(Sp2, 3, 3, False)
            Risp2(8) = GlobalRoutines.myStr(Passo1, 3, 3, False)
            Risp2(9) = GlobalRoutines.myStr(Passo2, 3, 3, False)
        End If
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(9, Tit, Dom, Risp2, "", Archiv, dAiu) Then GoTo FinSplit
        ntip = Val(Risp2(1)) : nfil1 = Val(Risp2(2)) : nfil2 = Val(Risp2(3))
        Dia1 = Val(Risp2(4)) : Dia2 = Val(Risp2(5))
        Sp1 = Val(Risp2(6)) : Sp2 = Val(Risp2(7))
        Passo1 = Val(Risp2(8)) : Passo2 = Val(Risp2(9))
        dist(1) = 0.0!
        For i = 2 To nfil1 : dist(i) = dist(i - 1) + Passo1 : Next
        If nfil2 > 0 Then
            dist(nfil1 + 1) = dist(nfil1) + (Passo1 + Passo2) / 2.0!
            For i = nfil1 + 2 To nfil1 + nfil2 : dist(i) = dist(i - 1) + Passo2 : Next
        End If
        For i = 1 To nfil1 : Dtub(i) = Dia1 : SP(i) = Sp1 : Next
        If ntip = 2 Then
            For i = nfil1 + 1 To nfil1 + nfil2 : Dtub(i) = Dia2 : SP(i) = Sp2 : Next
        End If
Jumpa:
        'fornire TotLen! Sp Alfa Young !!!!!!!!!!!!!!!!
450:
        Dom(1) = "Lunghezza tubi   [mm]"
        Dom(2) = "Lunghezza libera [mm]"
        Dom(3) = "Coeff. dil term. [10^5mm/mm°C]"
        Dom(4) = "Modulo di Young      [Kg/mm2]"
        Dom(5) = "Ammissibile mat.tubi [Kg/mm2]"
        If Mode <> 1 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Risp2(1) = GlobalRoutines.myStr(304.8 * objDatBase.CVS(objDatBase.DatBase(7, 20, Nrdit \ 2, 1, itp, 0)), 8, 1, False)
        Else
            Risp2(1) = "   10000.0"
        End If
        If Mode = 2 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Risp2(5) = GlobalRoutines.myStr(MecData(0).Ammiss(4), 5, 3, False)
        Else
            Risp2(5) = "   12.000"
        End If
        Risp2(2) = "    1614.0"
        Risp2(3) = " 1.80 "
        Risp2(4) = " 22100 "
        Tit = "Dati sui tubi"
        'For i = 1 To 5: LungSt(i) = Len(Risp2$(i)): Next
460:
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(5, Tit, Dom, Risp2, "", Archiv, dAiu) Then GoTo FinSplit
        TotLen = Val(Risp2(1)) : Alfa = Val(Risp2(3))
        ModYoung = Val(Risp2(4))
        LibLen = Val(Risp2(2))
        Sall = Val(Risp2(5))
        If Mode = 2 Then
            If TipoFas > 1 Then
                For i = 1 To nCasse(TipoFas)
                    'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FileGet(33, MecData(i), i)
                Next
            End If
        End If
        iflOu = FreeFile()
470:    FileOpen(iflOu, "TEX1" & RTrim(Uom2job.contratto), OpenMode.Output)
        iflIn = FreeFile()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileOpen(iflIn, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPLSPL.DAT"), OpenMode.Input, , OpenShare.Shared)
        Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, TotLen, LibLen, Sall))
        k = 0
        For i = 1 To nPassi
            For j = 1 To Val(Risp1(i))
                k = k + 1
                Splitta = 0
                If Mode = 2 Then
                    Select Case TipoFas
                        Case 0, 1 : Splitta = 0
                        Case 2
                            nf = 0
                            For k1 = 1 To MecData(1).NS + 1
                                nf = nf + System.Math.Abs(MecData(1).Nfile(k1))
                                If nf = k Then Splitta = 1 : Exit For
                            Next
                        Case 3
                            nf = 0
                            For k1 = 1 To MecData(2).NS + 1
                                nf = nf + System.Math.Abs(MecData(2).Nfile(k1))
                                If nf = k Then Splitta = 1 : Exit For
                            Next
                        Case 4
                            nf = 0
                            For k1 = 1 To MecData(1).NS + 1
                                nf = nf + System.Math.Abs(MecData(1).Nfile(k1))
                                If nf = k Then Splitta = 1 : Exit For
                            Next
                            nf = 0
                            For k1 = 1 To MecData(3).NS + 1
                                nf = nf + System.Math.Abs(MecData(3).Nfile(k1))
                                If nf = k Then Splitta = 1 : Exit For
                            Next
                    End Select
                End If
480:
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, k, Splitta))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, NTUB(k)))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, Val(Risp(i))))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, Dtub(k)))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, SP(k)))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, Alfa / 100000.0!))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, ModYoung))
                Riga = Assumi(iflIn, iflOu) : PrintLine(iflOu, GlobalRoutines.FormatS(Riga, dist(k)))
                Riga = Assumi(iflIn, iflOu)
                Splitta = 0
                FileClose(iflIn)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FileOpen(iflIn, CStr(Monitor.Motore.Inizio.Archdir + "\TEMPLSPL.DAT"), OpenMode.Input, , OpenShare.Shared)
                For jj = 1 To 7 : Riga = LineInput(iflIn) : Next
            Next j
        Next i
        FileClose(iflIn) : FileClose(iflOu)
490:    Esito = SPLIT1(iPag, nPag, FF, Prev) '0=OK;1=no
NoPrevist:
        Tit = Monitor.Motore.Inizio.DiscoTem & RTrim(Uom2job.Contratto)
        '    Call Deallocat1
        '492 EditoreF 2, Tit$, "Sforzi termici"
        Shell("NotePad " & Tit, AppWinStyle.NormalFocus)
        '    Call Allocat1
        Select Case Mode
            Case 1 'stand alone
                Registra(NewFUPM, 0, "")
            Case 0 'primo giro
                If Esito = 1 Then
                    Riga = " Si raccomanda lo splittaggio |"
                    Riga = Riga & "di qualche cassa in quanto le |"
                    Riga = Riga & "dilatazioni differenziali sono|"
                    Riga = Riga & "eccessive"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    MsgBox(Monitor.Motore.Inizio.ConvertiCr(Riga))
                End If
            Case 2 'finale
                NewFUPM = Left(FileUPM, Len(FileUPM) - 3) & "VER"
                Registra(NewFUPM, nCasse(TipoFas) + 2, "s")
        End Select
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Monitor.Motore.Inizio.DiscoTem & RTrim(Uom2job.Contratto))) > 0 Then IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(Uom2job.Contratto))
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir("TEX1" & RTrim(Uom2job.contratto))) > 0 Then IO.File.Delete("TEX1" & RTrim(Uom2job.contratto))
FinSplit:
        If Mode = 2 Then FileClose(33)
        Exit Function
    End Function
    Private Sub Recover()
        ntip = objDatBase.CVI(objDatBase.DatBase(4, 8, Nrdit \ 2, 1, itp, 0))
        nfil1 = objDatBase.CVI(objDatBase.DatBase(4, 48, Nrdit \ 2, 1, itp, 0))
        BWG1 = objDatBase.DatBase(4, 54, Nrdit \ 2, 1, itp, 0)
        TOL1 = objDatBase.DatBase(4, 55, Nrdit \ 2, 1, itp, 0)
        SpsBWG = BWG1 : SpsTol = TOL1
        Sp1 = 25.4 * objBWG.SpBWG(SpsBWG, SpsTol)
        Dia1 = 25.4 * objDatBase.CVS(objDatBase.DatBase(5, 1, Nrdit \ 2, 1, itp, 0))
        Passo1 = 25.4 * 3.0! ^ 0.5 / 2.0! * objDatBase.CVS(objDatBase.DatBase(5, 2, Nrdit \ 2, 1, itp, 0))
        If ntip = 2 Then
            nfil2 = objDatBase.CVI(objDatBase.DatBase(4, 52, Nrdit \ 2, 1, itp, 0))
            BWG2 = objDatBase.DatBase(4, 61, Nrdit \ 2, 1, itp, 0)
            TOL2 = objDatBase.DatBase(4, 62, Nrdit \ 2, 1, itp, 0)
            SpsBWG = BWG2 : SpsTol = TOL2
            Sp2 = 25.4 * objBWG.SpBWG(SpsBWG, SpsTol)
            Dia2 = 25.4 * objDatBase.CVS(objDatBase.DatBase(5, 7, Nrdit \ 2, 1, itp, 0))
            Passo2 = 25.4 * 3.0! ^ 0.5 / 2.0! * objDatBase.CVS(objDatBase.DatBase(5, 8, Nrdit \ 2, 1, itp, 0))
        Else
            Sp2 = 0.0! : Dia2 = 0.0! : Passo2 = 0.0!
        End If
    End Sub
    Private Sub DatiSupp(ByVal Mode As Short)
        If Mode <> 1 Then
            NtubTot = objDatBase.CVS(objDatBase.DatBase(5, 5, Nrdit \ 2, 1, itp, 0)) + objDatBase.CVS(objDatBase.DatBase(5, 11, Nrdit \ 2, 1, itp, 0))
            Rapp = CSng(NtubTot) / Nfile
            If (Rapp - Int(Rapp) < 0.05) Then
                Pari = 0 : Dispari = 0
            Else
                Pari = 0 : Dispari = 1
            End If
            If (Nfile Mod 2) = 1 Then GlobalRoutines.SWAP(Pari, Dispari)
            For j = 1 To Nfile Step 2
                NTUB(j) = Int(Rapp) + Dispari
                NTUB(j + 1) = Int(Rapp) + Pari
            Next
        End If
        For i = 1 To Nfile
            Risp2(i) = Str(NTUB(i))
            Dom(i) = "N.tubi/fila" & Str(i)
        Next
        Tit = "Numero tubi"
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(Nfile, Tit, Dom, Risp2, "", Archiv, dAiu) Then Exit Sub
        For i = 1 To Nfile : NTUB(i) = Val(Risp2(i)) : Next
    End Sub
    Public Sub InitUPM2(ByRef AddDistinta As Short, ByRef File As String)
        Dim i, j As Short
        Dim Logi1 As Short
        Call InitStringUPM()
        '---------------------------------------------------------
        If AddDistinta = 303 Then
            Logi1 = SplitCas(1)
        ElseIf AddDistinta = 304 Then
            Logi1 = SplitCas(2)
        ElseIf AddDistinta = 305 Then
            Logi1 = SplitCas(0)
        End If
    End Sub
End Module