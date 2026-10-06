Option Strict Off
Option Explicit On
Imports system.math
Module modPropos
    Private nf(30, 6) As Short
	Private e(100) As Single
	Private EF(30, 4) As Single
	Private NU(30, 2) As Short
	Private EU(30, 10) As Single
	Private A(100) As Single
	Private AF(30, 4) As Single
	Private AU(30, 10) As Single
	Private C(99) As Single
	Private BB(35) As Single
	Private CC(70) As Single
	Private xxxD(30) As Single
    Private che(7) As String
	Private ch0(10) As String
	Private ch1(14) As String
    Private CH3(30, 3) As String
    Private CH4(30, 3) As String
    Private CH2(12) As String
    Private block As Autodesk.AutoCAD.Interop.Common.AcadBlock
    Private BlockRef As Autodesk.AutoCAD.Interop.Common.AcadBlockReference
	Private InLinea As Boolean
	Private inspoint(2) As Double
	Private PAS(7) As String
	Private a2, A0, a1, a3 As Single
	Private a4, A5 As Single
	Private A9, A7, A6, A8, A10 As Single
	Private A11, A12 As Single
	Private A20 As Single
	Private Lar(99) As Short
	Private Nstack(99) As Short
	Private ItemR(99) As String
	Private Nfasc(99) As Short
	Private NumItB(99) As Short
	Private Sizew(99) As Single
	Private SizeL(99) As Single
	Private IGapFasc(99) As Short
	Private NROWS(99) As Short
	Private Unita(99) As Single
	Private Nfans(99) As Short
	Private Dfans(99) As Single
	Private Itemfat(99) As Short
    Private Aster(99) As String
	Private Dom(30) As String
	Private Risp(30) As String
	Private iF2, iF1, Ialte As Short
    Private iPropDwg As Short
	Private Form, Cust As String
	Private Data, Plant, Check, Rev As String
	Private Quot As String
	Private IgapVent, Itm1Bank As Short
	Private MaxSizeBank, IgapLung, IHBundle As Short
	Private LargBundle As Single
	Private NoVisu, ItmsBank As Short
	Private Imvec, Imx, Nimx, Lun As Short
	Private junk1 As Integer
	Private nfass, iser, bocc, stem, kdx As String
	Private IndFor, iserStr As String
	Private Nheight As Short
	Private dAiu(20) As String
	Private Archiv(20) As Short
	Private iOK As Short
	Private iaddi As Short
	Private Nboou, Nboin, Ndisp As String
	Private Nric As Short
	Private UnMis As String
	Private pied, poll As Single
	Private pied1, poll1 As Single
	Private iF22 As Short
	Private Diavent As Single
	Private Trav As String
	Private NFanUnit As Short
	Private IndForz, SCALDX, SCALSX, Ifr As String
	Private Ila2, Ila1, Ila3 As String
	Private dist, Rici, IndCam As String
	Private Height As Single
	Private Steam As String
	Private FasUnit, NtotFansUnit As Short
	Private ifro2, ifrox, ifro As Single
	Private ILat As Short
	Private Ilat3, Ilat1, Ilat2, Ilat0 As Short
	Private Itip, Incl As Short
	Private Pitch, Fialet As Single
	Private iF3, iF4 As Short
    '==================================================================
    Private myStr As Object
    Private Riga, itp As String
    Private j, i, k As Short
    Private Help As String
    Private TotItems As Short
    Private File1 As String
    Private NumBank0, NumB0 As Short
    Private nfasfit, Ncod, Note As Short
    Private itemfit As String
    Private sizemax As Single
    Private Nscal1, Nitm1, Npas, Nscal2 As Short
    Private File2, File4, File3 As String
    Private Tit As String
    Private im As Short
    Private icountB, ii As Short
    Private Ris1(12) As Boolean
    '==============================================================
    '    Proposal NumB
	Sub PreparaPRO(ByRef iActBank As Short, ByRef Bank As String)
        For i = 1 To 99
            Unita(i) = 0
            Nfans(i) = 0
            Dfans(i) = 0
        Next i
		iOK = 1
        'File4$ = monitor.motore.inizio.workdir + "\" + LEFT$(job.contratto, 4) + ".MAP"
        'IF LEN(DIR$(File4$)) = 0 THEN
        '       Riga = "Eseguire la mappa !"
        '               junk = Alert(4, Riga, 4, 3, 10, 58, "OK", "", "")
        '       iOK = -1
        '       EXIT SUB
        'END IF
80:
        UnMis = objDatBase.DatBase(1, 6, 1, 1, itp, 0)
        pied1 = 305 : poll1 = 25.4
        pied = 1 : poll = 1 : If UnMis = "BR" Then pied = 305 : poll = 25.4
        Riga = GlobalRoutines.myStr(CSng(iActBank), 2, 0, True)
        If iActBank < 10 Then Riga = "0" & Right(Riga, 1)
        File2 = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Left(job.Contratto, 4)) + CDbl(Riga) + CDbl(".PRO"))
        junk1 = MsgBoxResult.No
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(File2)) > 0 Then
            '                       Riga = "Esiste un precedente file .PRO|"
            '                  Riga = Riga + "vuoi usarlo ?"
            '               junk1 = MsgBox(Riga, vbQuestion + vbYesNo)
            junk1 = MsgBoxResult.Yes
            '   If junk1 = vbYes Then
            FileCopy(File2, "SCRA" & RTrim(job.contratto))
            'Close
            io.file.delete(File2)
            iF22 = FreeFile
            FileOpen(iF22, "SCRA" & RTrim(job.contratto), OpenMode.Input)
            '   End If
        End If
90:     NumBank = iActBank
        iF2 = FreeFile
        FileOpen(iF2, File2, OpenMode.Output)
        iF3 = FreeFile()
        File3 = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Left(job.contratto, 4)) + CDbl(".SUM"))
        If Len(Dir(File3)) = 0 Then
            Riga = "Eseguire il sommario!"
            MsgBox(A)
            iOK = -1
            FileClose(iF2)
            Exit Sub
        End If
        FileOpen(iF3, File3, OpenMode.Input)
        Riga = LineInput(iF3)
        Riga = LineInput(iF3)
        If junk1 = MsgBoxResult.Yes Then
            If Not LeggiPRO(Riga) Then
                NoPRO()
            ElseIf Not LeggiPRO(Riga) Then
                NoPRO()
            ElseIf Len(Riga) < 102 Then
                NoPRO()
            Else
                NumBank0 = Val(Mid(Riga, 92, 3))
                NumB0 = Val(Mid(Riga, 98, 4))
                If NumBank0 <> NumBank Or NumB0 <> NumB Then NoPRO()
            End If
        End If
        TotItems = NumIt 'deve essere uguale a NumIt
        File1 = CStr(Monitor.Motore.Inizio.Archdir + "\TEMPLAT.PRO")
100:    iF1 = FreeFile()
        FileOpen(iF1, File1, OpenMode.Input)
        Risp(1) = "(1) " & Space(67)
        Risp(3) = "(2) " & Space(67)
        Risp(2) = Space(71)
        Risp(4) = Risp(2)
        If junk1 = MsgBoxResult.Yes Then
            For i = 1 To 4
                If Not LeggiPRO(Riga) Then
                    NoPRO()
                    Exit For
                End If
            Next
            If i < 5 Then
                For i = 1 To 4
                    If Not LeggiPRO(Riga) Then
                        NoPRO()
                        Exit For
                    End If
                    Risp(i) = Right(Riga, Len(Riga) - 1)
                Next
            End If
        End If
        For i = 1 To 4 : Dom(i) = "" : Next  ': LungSt(i) = Len(Risp$(i)): Next
        Tit = "Note Disegno di istallazione  Banco " & Str(NumBank)
        FaseDati = 8
        Apert.Enabled = False
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(1, 4, Tit, Dom, Risp, "", Archiv, dAiu)
        Monitor.Motore.InputForms(1 - 1).Top = 40
        Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
        If Not junk1 = MsgBoxResult.Yes Then
            LeggiSUM1()
        Else
            LeggiSum11()
        End If

102:    Itm1Bank = Disposiz.Nite(NumBank, 1) 'Itm1Bank + 1
        IgapVent = ReadLib(28, 1) '300
        IgapLung = 150
        MaxSizeBank = 60
        IHBundle = 260

        icountB = 1
        i = 0
        For ii = 1 To 30 : Itemfat(i) = 0 : Next ii
        LeggiPAS()
394:    Tit = "Accessori del Banco " & Str(NumBank)
        Dom(1) = "Pass. Testate in  :" : Risp(2) = PAS(1)
        Dom(2) = "Scale DX          :" : Risp(3) = SCALDX
        Dom(3) = "Scale SX          :" : Risp(4) = SCALSX
        Dom(4) = "Pass. Testate out :" : Risp(5) = PAS(2)
        Dom(5) = "Scale DX          :" : Risp(6) = SCALDX
        Dom(6) = "Scale SX          :" : Risp(7) = SCALSX
        Dom(7) = "Pass. Motori      :" : Risp(8) = PAS(3)
        Dom(8) = "Pass.Coll.Test.DX :" : Risp(9) = PAS(4)
        Dom(9) = "Pass.Coll.Test.SX :" : Risp(10) = PAS(5)
        Dom(10) = "Pass.Coll.Mot.DX  :" : Risp(11) = PAS(6)
        Dom(11) = "Pass.Coll.Mot.SX  :" : Risp(12) = PAS(7)
        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
        If junk1 = MsgBoxResult.Yes Then
            LeggiPAS1()
        End If
        For i = 1 To 11 : Ris1(i) = Risp(i + 1) = "SI" : Next
        Monitor.Motore.CheckQualeM(2, 11, Tit, Dom, Ris1, "")
        LargBundle = 0
        'ErrPrepara: Print "Errore in PreparaPRO"; Err; Erl: Stop
        '==========================================================================
        Tit = "Parametri Standard Banco " & Str(NumBank)
        Dom(1) = "Gap Dia. Ventilatori    :" : Risp(1) = Str(IgapVent)
400:    Dom(2) = "Extra  lunghezza fasci  :" : Risp(2) = Str(IgapLung)
        Dom(3) = "L. Banco senza pass. <  :" : Risp(3) = Str(MaxSizeBank) & "'"
        Dom(4) = "Extra frontale fascio   :" : Risp(4) = Str(LargBundle)
        Dom(5) = "Extra altezza fascio    :" : Risp(5) = Str(IHBundle)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
401:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDatiM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.InputDatiM(3, 5, Tit, Dom, Risp, "", Archiv, dAiu)
402:    Help = "Opzione Visualizz.Items"
        Dom(1) = "Visualizzazione dati"
        Ris1(1) = True
        'LungSt(1) = Len(Risp$(1))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.CheckQualeM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.CheckQualeM(4, 1, Help, Dom, Ris1, "")
        Exit Sub
    End Sub
    Private Sub LeggiPAS()
        Do
rileggi:
            Riga = LineInput(iF3)
            If EOF(iF3) Then Exit Do
            If Mid(Riga, 6, 9) = "|  ***** " Then icountB = icountB + 1 : GoTo rileggi
            If icountB > iActBank Then Exit Do
            If icountB < iActBank Then GoTo rileggi
            Ncod = Val(Mid(Riga, 4, 2))
            nfasfit = Val(Mid(Riga, 43, 3))
            If (nfasfit > 0 Or Ncod > 0) And Not Mid(Riga, 6, 9) = "|  ***** " Then
                itemfit = LTrim(RTrim(Mid(Riga, 8, 20)))
                If itemfit = "" Then
                    Nstack(i) = Nstack(i) + 1
                    GoTo 393
                End If
                i = i + 1
                Nstack(i) = 0
                Itemfat(i) = 2
                Note = InStr(Riga, "EM:")
                If Note = 0 Then Note = InStr(Riga, "LA:")
                If Note = 0 Then Note = InStr(Riga, "IL:")
                If Note <> 0 Then ItemR(i) = LTrim(RTrim(Mid(Riga, Note + 3, 20)))
                Item(i) = LTrim(RTrim(Mid(Riga, 8, 20)))
                NumItB(i) = Ncod
                If Disposiz.jcont(Disposiz.Nite(iActBank, i)) <> Ncod Then
                    MsgBox("E' necessario ripassare il Sommario", MsgBoxStyle.Critical)
                    FinePro()
                    Exit Sub
                End If
                If nfasfit = 0 Then
                    Riga = "L'item " & Item(i) & "|"
                    Riga = Riga & "non e' stato calcolato termicamente.|"
                    Riga = Riga & "Non è quindi possibile procedere.|"
                    Riga = Riga & "Si suggerisce di esaminare il sommario"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    MsgBox(Monitor.Motore.Inizio.ConvertiCr(Riga), MsgBoxStyle.Information)
                    iOK = 0 : FinePro() : Exit Sub
                End If
                Nfasc(i) = Val(Mid(Riga, 43, 3))
                Sizew(i) = Val(Mid(Riga, 48, 5))
                SizeL(i) = Val(Mid(Riga, 54, 2))
                NROWS(i) = Val(Mid(Riga, 57, 2))
                If Note = 0 Then
                    Unita(i) = Val(Mid(Riga, 62, 4))
                    Nfans(i) = Val(Mid(Riga, 104, 3))
                    Dfans(i) = Val(Mid(Riga, 109, 2))
                End If
            End If
393:    Loop
        sizemax = 0 : ItmsBank = i
        For j = 1 To i : sizemax = sizemax + Nfasc(j) * Sizew(j) : Next
        SCALSX = "NO" : If sizemax >= MaxSizeBank Then SCALSX = "SI"
        Nitm1 = NumItB(1) 'Itm1Bank)
        Npas = objDatBase.CVI(objDatBase.DatBase(2, 15, Nitm1, ActivAlt(Nitm1), itp, 0)) '-- cod. Passerele
        Passerel(Npas)
        If PAS(5) = "SI" Then SCALSX = "SI"
        Nscal1 = objDatBase.CVI(objDatBase.DatBase(2, 27, Nitm1, ActivAlt(Nitm1), itp, 0)) '-- cod. scale pioli
        Nscal2 = objDatBase.CVI(objDatBase.DatBase(2, 28, Nitm1, ActivAlt(Nitm1), itp, 0)) '-- cod. scale gradini
        SCALDX = "NO" : If Nscal1 = 2 Or Nscal2 = 2 Then SCALDX = "SI"
        If PAS(6) = "SI" Then SCALDX = "SI"
        If PAS(7) = "SI" Then SCALSX = "SI"
    End Sub
    Private Sub LeggiPAS1()
        For i = 1 To 4
            If Not LeggiPRO(Riga) Then
                NoPRO()
                Exit Sub
            End If
        Next
        Risp(1) = ""
        If Not LeggiPRO(Riga) Then
            NoPRO()
            Exit Sub
        End If
        Risp(2) = Mid(Riga, 45, 2) : Risp(3) = Mid(Riga, 69, 2) : Risp(4) = Mid(Riga, 72, 2)
        If Not LeggiPRO(Riga) Then
            NoPRO()
            Exit Sub
        End If
        Risp(5) = Mid(Riga, 45, 2) : Risp(6) = Mid(Riga, 69, 2) : Risp(7) = Mid(Riga, 72, 2)
        For i = 8 To 12
            If Not LeggiPRO(Riga) Then
                NoPRO()
                Exit Sub
            End If
            Risp(i) = Mid(Riga, 45, 2)
        Next
    End Sub
    Private Sub LeggiSUM11()
        If Not LeggiPRO(Riga) Then
            NoPRO()
            LeggiSUM1()
            Exit Sub
        End If
        Cust = RTrim(Right(Riga, Len(Riga) - 18))
        If Not LeggiPRO(Riga) Then
            NoPRO()
            LeggiSUM1()
            Exit Sub
        End If
        LeggiPRO(Riga)
        Plant = RTrim(Mid(Riga, 40, Len(Riga) - 39))
        If Not LeggiPRO(Riga) Then
            NoPRO()
            LeggiSUM1()
            Exit Sub
        End If
        Check = Mid(Riga, 22, 2)
        If Not LeggiPRO(Riga) Then
            NoPRO()
            LeggiSUM1()
            Exit Sub
        End If
        Data = Mid(Riga, 14, 10)
        If Not LeggiPRO(Riga) Then
            NoPRO()
            LeggiSUM1()
            Exit Sub
        End If
        Rev = Mid(Riga, 3, 2)
        If Not LeggiPRO(Riga) Then
            NoPRO()
            LeggiSUM1()
            Exit Sub
        End If
        Quot = Mid(Riga, 2, 4)
    End Sub
    Private Sub LeggiSUM1()
        i = 1
        Do
            Riga = LineInput(iF3)
            If Mid(Riga, 6, 4) = "FBM-" Then Data = Mid(Riga, 83, 10)
            If Mid(Riga, 6, 4) = "QUOT" Or Mid(Riga, 6, 5) = "NOTES" Then Exit Do
            i = i + 1
        Loop
        Quot = Mid(Riga, 17, 6) : Rev = Mid(Riga, 33, 20)
        Cust = Mid(Riga, 55, 20) : Plant = Mid(Riga, 95, 20)
        Check = objDatBase.DatBase(4, 1, 1, 1, itp, 0)
    End Sub
    Function ReadLib(ByRef i As Short, ByRef j As Short) As Single
        Dim ifl, ii As Short
        Dim Riga As String
        If j < 1 Or j > 15 Then
            ReadLib = -1
            Exit Function
        End If
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.Archdir + "\DATLIB.DAT", OpenMode.Input, , OpenShare.Shared)
        If i = 0 Then i = 1
        For ii = 1 To i
            Riga = LineInput(ifl)
        Next
        FileClose(ifl)
        Riga = Riga.Split(CChar("["))(0)
        Dim Valori As String() = Riga.Split(CChar(","))
        ReadLib = GlobalRoutines.ValVir(Valori(j - 1))
    End Function

    Function Skippa(ByRef iF1 As Short, ByRef iF2 As Short) As String
        Dim A As String
        Do
            A = LineInput(iF1)
            If Right(A, 1) = "F" Then Exit Do
            PrintLine(iF2, Mid(A, 1, 127))
            If EOF(iF1) Then Exit Function
        Loop
        Skippa = Mid(A, 1, 127)
    End Function

    Sub Proposal(ByRef NumBank As Short)
        Dim myStr As Object
        Dim iOK As Short
        Dim Bnum, Numa As String
        Dim File, FilFil As String
        Dim i, j As Short
        Dim FilePRI As String
        Dim ii, jj As Short
        Dim NCAMPI As Short
        Dim Testo As String
        Dim hfas As Single
        Dim hori2, hori1, vert1, vert2 As Single
        Dim hori2a, hori1a, vert1a, vert2a As Single
        Dim hori2b, hori1b, vert1b, vert2b As Single
        Dim Tipo As Short
        Dim Ftesta As String
        Dim ifl As Short
        Dim c2 As Single
        'NumBank banco di cui si esegue il proposal
1010:
RedoPRO:
        'PreparaPRO NumBank, iOK, Bnum
        'If iOK = 0 Then GoTo FinPRO Else If iOK = -1 Then Exit Sub
        Numa = Str(NumBank)
        If Len(Numa) > 2 Then Numa = Right(Numa, 2)
        If NumBank < 10 Then Numa = "0" & Right(Numa, 1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        File = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Left(job.contratto, 4)) + CDbl(Numa) + CDbl(".PRO"))
        iPropDwg = FreeFile
1020:
        FileOpen(iPropDwg, File, OpenMode.Input)
        FilFil = Left(job.contratto, 4) & Numa
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FilePRI = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(FilFil))
        For ii = 1 To 30
            For jj = 1 To 8
                If jj < 3 Then NU(ii, jj) = 0
                If jj < 5 Then AF(ii, jj) = 0.0! : EF(ii, jj) = 0.0!
                If jj < 7 Then nf(ii, jj) = 0
                AU(ii, jj) = 0.0! : EU(ii, jj) = 0.0!
            Next jj
        Next ii
        For ii = 1 To 100 : A(ii) = 0.0! : e(ii) = 0.0! : Next


        '     LETTURA SEZIONE 1
        Do
            If Not LeggiProp(Testo) Then NoProp() : Exit Sub
            If Mid(Testo, 39, 18) = "S E Z I O N E    1" Then Exit Do
        Loop
        If Not leggi(1) Then NoProp() : Exit Sub
        For i = 1 To 11 : LeggiProp(ch1(i)) : Next
        '     LETTURA SEZIONE 2
        If Not leggi(4) Then NoProp() : Exit Sub
        '     LeggiProp Testo: ch2(1) = MID$(Testo, 39)
        For i = 2 To 5 Step 3
            If Not LeggiProp(Testo) Then NoProp() : Exit Sub
            CH2(i) = Mid(Testo, 44, 2)
            CH2(i + 1) = Mid(Testo, 68, 2)
            CH2(i + 2) = Mid(Testo, 71, 2)
        Next  'a
        For i = 8 To 12
            If Not LeggiProp(Testo) Then NoProp() : Exit Sub
            CH2(i) = Mid(Testo, 44)
        Next  'b
        '     LeggiProp Testo
        '     e(1) = VAL(MID$(Testo, 41, 6))
        If Not leggi(8) Then NoProp() : Exit Sub
        '     LETTURA SEZIONE 3
        For i = 1 To 30
            If Not LeggiProp(Testo) Then NoProp() : Exit Sub
            CH3(i, 1) = Mid(Testo, 1, 18)
            If (Mid(CH3(i, 1), 1, 18) = "                  ") Then Exit For
            nf(i, 1) = Val(Mid(Testo, 20, 6))
            EF(i, 1) = Val(Mid(Testo, 27, 7)) 'lungh
            EF(i, 2) = Val(Mid(Testo, 36, 7)) 'largh
            EF(i, 3) = Val(Mid(Testo, 44, 7)) 'alt
            nf(i, 2) = Val(Mid(Testo, 54, 1))
            nf(i, 3) = Val(Mid(Testo, 55, 1))
            nf(i, 4) = Val(Mid(Testo, 56, 1))
            CH3(i, 2) = Mid(Testo, 60, 6)
            CH3(i, 3) = Mid(Testo, 67, 6)
            nf(i, 5) = Val(Mid(Testo, 74, 7))
            EF(i, 4) = Val(Mid(Testo, 88, 7)) 'dist fascio sx
            nf(i, 6) = Val(Mid(Testo, 96, 1))
            If Mid(Testo, 100, 1) = "*" Then EF(i, 4) = -EF(i, 4)
        Next  'c
        If Not leggi(8) Then NoProp() : Exit Sub
        '     LETTURA SEZIONE 4
        For i = 1 To 30
            If Not LeggiProp(Testo) Then NoProp() : Exit Sub
            NU(i, 1) = Val(Mid(Testo, 1, 5))
            If (NU(i, 1) = 0) Then Exit For
            EU(i, 10) = 1 : If UCase(Mid(Testo, 99, 2)) = "IN" Then EU(i, 10) = 2
            EU(i, 1) = Val(Mid(Testo, 8, 6)) 'interassi frontali 1
            EU(i, 2) = Val(Mid(Testo, 14, 6)) '                   2
            EU(i, 3) = Val(Mid(Testo, 20, 6)) '                   3
            CH4(i, 1) = Mid(Testo, 27, 7) 'Trave
            NU(i, 2) = Val(Mid(Testo, 37, 3))
            EU(i, 4) = Val(Mid(Testo, 43, 7))
            EU(i, 5) = Val(Mid(Testo, 52, 6)) 'interassi laterali 1
            EU(i, 6) = Val(Mid(Testo, 58, 6)) '                   2
            EU(i, 7) = Val(Mid(Testo, 64, 6)) '                   3
            CH4(i, 2) = Mid(Testo, 73, 12)
            EU(i, 8) = Val(Mid(Testo, 87, 7)) 'dist unita di sin
            EU(i, 9) = Val(Mid(Testo, 109, 7)) 'alt.col
            CH4(i, 3) = Mid(Testo, 120, 5)
        Next  'd
        If Not leggi(4) Then NoProp() : Exit Sub
        '     LETTURA SEZIONE 5
        For i = 2 To 21
            Input(iPropDwg, e(i))
        Next  'e
        '-----------------------------------------------------------------------
        '                          PARTE DI CALCOLO
        '-----------------------------------------------------------------------
Ripeti:
        NCAMPI = 0
        For i = 1 To 30
            For j = 1 To 3
                If (EU(i, j) <> 0.0!) Then NCAMPI = NCAMPI + NU(i, 1)
            Next  'h
        Next  'i
        '------------------  CALCOLO DIMENSIONI GEOMETRICHE   ------------------
        For i = 1 To 30
            For j = 1 To 3
                e(51) = e(51) + EU(i, j) * NU(i, 1)
            Next j
            e(51) = e(51) + EU(i, 8) 'lunghezza banco
            e(52) = MAX(e(52), EF(i, 1)) 'lunghezza fascio
            If e(1) < EU(i, 9) Then e(1) = EU(i, 9) 'altezza trave
            If hfas < EF(i, 3) Then hfas = EF(i, 3)
        Next i
        '---------------  CALCOLO SCALA DI RAPPRESENTAZIONE  -------------------
        IniziaRoutines()
        C(1) = 0 'ex 280!  380linea di base colonne
        c2 = e(1) 'ex 50 distanza verso il basso con pianta
        ' c(3) = 0  'ex 420  non usato
        '    hori1 = 10000 + e(51) + 1.5 * e(52)
        'caso con vista frontale sopra
        Monitor.routines.DoveDisegno.Font = New Font("MS Sans Serif", 8)
        For i = 1 To 2
            Do
                C(2) = c2
                hori2a = 1.1 * (e(51) + Monitor.routines.DoveDisegnog.MeasureString(New String("A", 25), Monitor.routines.DoveDisegno.Font).Width)
                hori1a = -hori2a / 11
                vert1a = (-1.5 * e(52) - C(2)) * 1.1
                vert2a = (2 * e(1) + C(2) + 2 * e(1)) * 1.1
                'caso con vista frontale in linea
                hori2b = (e(51) + C(2) + e(52) + e(1)) * 1.1
                hori1b = -hori2b / 11
                vert1b = -(1.5 * e(52) + C(2) + 10 * Monitor.routines.DoveDisegnog.MeasureString("A", Monitor.routines.DoveDisegno.Font).Height) * 1.1
                vert2b = (2 * e(1)) * 1.1
                If System.Math.Abs((vert2b - vert1b) / (hori2b - hori1b) - 21 / 27) < System.Math.Abs((vert2a - vert1a) / (hori2a - hori1a) - 21 / 27) Then
                    InLinea = True
                    vert1 = vert1b : vert2 = vert2b : hori1 = hori1b : hori2 = hori2b
                Else
                    InLinea = False
                    vert1 = vert1a : vert2 = vert2a : hori1 = hori1a : hori2 = hori2a
                End If
                If (vert2 - vert1) / (hori2 - hori1) < 21 / 27 Then
                    c2 = (hori2 - hori1) / 30
                Else
                    c2 = (vert2 - vert1) / 20
                End If
            Loop While System.Math.Abs(c2 - C(2)) > (hori2 - hori1) / 50
            ' If Monitor.routines.Dove Is Printer And Apert.cmdZoom.Value Then
            'Monitor.routines.Scala(Apert.xTop, Apert.xBot, Apert.yTop, Apert.yBot)
            'ElseIf Not Apert.cmdZoom.Value Then
            Monitor.routines.Scala(hori1, hori2, vert1, vert2)
            'End If
        Next
        For i = 1 To 100
            A(i) = e(i) ' * Scalb!
        Next i
        For i = 1 To 30
            For j = 1 To 4
                AF(i, j) = EF(i, j) ' * Scalb!
            Next
            For j = 1 To 9
                AU(i, j) = EU(i, j) '* Scalb!
            Next j
        Next i
        C(10) = (490.0! - A(51) - A(52))
        If (C(10) < 0.0!) Then C(10) = (514.0! - A(51)) / 2.0! 'ex 340
        If (C(10) < 0.0!) Then C(10) = 0.0!
        C(11) = C(10) + 30.0!
        '-----------------------------------------------------------------------
        '                        PARTE      GRAFICA
        '-----------------------------------------------------------------------
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\HTRI12.DAT"), OpenMode.Input)
        For j = 1 To 35 : Input(ifl, BB(j)) : Next
        For j = 1 To 70 : Input(ifl, CC(j)) : Next
        For j = 1 To 7 : Input(ifl, che(j)) : Next
        For j = 1 To 10 : Input(ifl, ch0(j)) : Next
        FileClose(ifl)
        Monitor.routines.HCOTE(3.5)
        Numa = GlobalRoutines.myStr(Val(Bnum), 2, 0, True)
        Call FORZAT(NCAMPI, Numa)
        Call Monitor.routines.refere(0.0!, C(1), 0.0!)
        Items(1) ' Scalb
        Call FORMA1(Numa) 'Scalb
        'Monitor.routines.ApriPri FilePRI$, ".PRP", 0, Tipo, Ftesta
        'Numa = Globalroutines.mystr(Val(Bnum$), 2, 0, True)
        'IF (ch2(1) = "FO") THEN CALL FORZAT(NCAMPI, Scalb!, NumBank, NumB, Numa$)
        'IF (ch2(1) = "IN") THEN CALL INDOTT(NCAMPI, Scalb!, NumBank, NumB, Numa$)
        'Call FORZAT(NCAMPI, NumBank, Numa)
        '---------------------    FINE PARTE GRAFICA     -----------------------
        '1395   Monitor.routines.refabs
        '      CALL refere(26, 26, 0)
        '1396   Monitor.routines.legpri Monitor.Motore.Inizio.archdir + "\FORMA2", ".PRI"
        '       Monitor.routines.ChiudiPRI
        '1398   Beep
        '      u$ = INPUT$(1)
        '      Screen 0, 0, 0: CLS
        FileClose(iPropDwg)
        '      DisplayH
        '      Drawing FilePRI$ + ".PRP", "PSP"
FinPRO:
        '      NumBank = NumBank + 1
        '      If NumBank <= NumB Then GoTo 1010
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'Exit Sub '------------------>>>>>>> per ora
        'ErrProp: Print "Errore in Proposal"; Err; Erl: Stop
    End Sub
    Private Sub NoProp()
        Dim Riga As String
        Riga = "Il File 'Proposal' non è aggiornato o è corrotto." & vbCrLf
        Riga = Riga & "L'esecuzione del disegno viene abbandonata."
        MsgBox(Riga, MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
        FileClose(iPropDwg)
        Apert.cmdExit_Click(Nothing, New System.EventArgs())
    End Sub
    Function LeggiProp(ByRef A As String) As Boolean
        On Error GoTo ErrPRO
        A = LineInput(iPropDwg)
        A = Right(A, Len(A) - 1)
        LeggiProp = Not (EOF(iPropDwg) Or Left(A, 4) = "INTE")
        Exit Function
ErrPRO: LeggiProp = False
    End Function
    Function leggi(ByRef i As Short) As Boolean
        On Error GoTo ErrPRO
        Dim j As Short
        Dim A As String
        For j = 1 To i : A = LineInput(iPropDwg) : Next
        leggi = True
        Exit Function
ErrPRO: leggi = False
    End Function
    Public Sub IniziaRoutines()
        Dim i As Short
        If Monitor.routines Is Nothing Then
            Monitor.routines = New RoutBase1.Routines
        End If
        With Apert
            ' .Picture1.ScaleMode = vbTwips
            .Panel1.Top = 0
            .Panel1.Left = 0
            .Panel1.Width = .Width - 50 / 15
            .Panel1.Height = .StatusBar1.Top
            .Frame1.Top = 0
            .Frame1.Left = .Panel1.Width - .Frame1.Width - 200 / 15
            Monitor.routines.DoveDisegno = .Picture1
            Monitor.routines.DoveInizio = Monitor.Motore.Inizio
        End With
        Monitor.routines.Init200(Monitor.Motore.Inizio.Archdir)
        With Apert
            .Panel1.Visible = True
            .Panel1.BringToFront()
            If Not .cmdZoom.Checked Then Monitor.routines.DoveDisegnog.Clear(Color.White)
        End With
    End Sub
    Sub FORZAT(ByRef NCAMPI As Short, ByRef Numa As String)
        Static indmax, iTipo As Short
        Static X, y As Single
        Static NCAMPO As Short
        Static pxy0, pxy1 As Single ', nomeblock As String
        Static i As Short
        Static Quota, nome As String ', block As autocad.AcadBlock
        Static j As Short
        nome = ""
        '  On Local Error GoTo ErrForz
        Static P(4) As Single
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.routines.refabs()
        Call TrovIndmax(indmax)
        iTipo = EU(1, 10)
        If iTipo = 1 Then
            Call InizzFor(X, y, indmax)
            a2 = AU(indmax, 5) + AU(indmax, 6) + AU(indmax, 7)
        Else
            Call InizzInd(X, y, indmax)
            a2 = AF(indmax, 1) - 5 * A(19)
        End If
        FinPassTestS(X, y, a2, indmax)
        '-----------------------------------------------------------------------
        '                      COSTRUZIONE DEL BANCO
        '-----------------------------------------------------------------------
        NCAMPO = 1 : xxxD(0) = X
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pxy0 = Monitor.routines.poynt(X, 0.0!)
        For i = 1 To 30
            If (NU(i, 1) = 0) Then Exit For '-   CONDIZIONE DI FINE BANCO
            iTipo = EU(i, 10) 'tiraggio
            A(1) = EU(i, 9) '* Scalb  'altezza colonne
            If iTipo = 1 Then
                A0 = GlobalRoutines.Massimo(AU(i, 1), AU(i, 2), AU(i, 3))
            Else
                A0 = AU(i, 1) + AU(i, 2) + AU(i, 3)
            End If
310:        For j = 1 To NU(i, 1) '--------------   CICLO DI COSTRUZIONE SINGOLA UNITA
                With Monitor.routines
                    If .SwIUNpri = 3 Then
                        nome = "Alzato" & Trim(Str(i)) & "_" & Trim(Str(j))
                        block = ACADobj.Blocks.Add(inspoint, nome)
                        .InitAcad(block)
                    End If
                    If j = 1 Then X = X + AU(i, 8)
                    Call ActAltInd(i, j)
                    If A(1) > 0 Then 'altezza colonne
                        Call ColSx(X, i, j)
                        If iTipo = 1 Then
                            Call AlzatoFor(i, j, NCAMPO, NCAMPI, X)
                        Else
                            Call AlzatoInd(i, j, NCAMPO, NCAMPI, X)
                        End If
                        Call QuotaColonn(i, X, P, 1) ' Scalb)
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .SwIUNpri = 3 Then
                        BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nome, 1, 1, 1, 0)
                        ACADobj.Application.Update()
                        nome = "Pianta" & Trim(Str(i)) & "_" & Trim(Str(j))
                        block = ACADobj.Blocks.Add(inspoint, nome)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.InitAcad. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .InitAcad(block)
                    End If
                    If iTipo = 1 Then
                        Call PiantaFor(X, y, i)
                    Else
                        Call PiantaInd(X, y, i)
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .SwIUNpri = 3 Then
                        BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nome, 1, 1, 1, 0)
                        ACADobj.Application.Update()
                        nome = "Passer" & Trim(Str(i)) & "_" & Trim(Str(j))
                        block = ACADobj.Blocks.Add(inspoint, nome)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.InitAcad. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .InitAcad(block)
                    End If
                    Call PasserSup(X, y, i, j)
                    Call PasserInf(X, y, i, j)
400:                X = X + A0 '---------------   POSIZIONAMENTO PER L"UNITA SUCCESSIVA
                    NCAMPO = NCAMPO + 1
                End With
            Next j
            xxxD(i) = X
        Next i
        pxy1 = P(4)
        '-----------------------------------------------------------------------
        '                COSTRUZIONE DEL FUORI BANCO DESTRA
        '-----------------------------------------------------------------------
        '---------   COSTRUZIONE FINE PASSERELLA TESTATE LATO INGRESSO   -------
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .SwIUNpri = 3 Then
                BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nome, 1, 1, 1, 0)
                ACADobj.Application.Update()
                nome = "FinePasser"
                block = ACADobj.Blocks.Add(inspoint, nome)
                .InitAcad(block)
            End If
            FinPassTestD(X, y, a2, indmax)
            Quota = Trim(Str(System.Math.Abs(Int(.xcoord(pxy1) - .xcoord(pxy0)))))
            .ql1(pxy0, pxy1, 1, -2 * e(1) / 5, Quota) ' Scalb, ""
        End With
        '***********************************************************************
        '                   COSTRUZIONE DELLA VISTA LATERALE
        '***********************************************************************
        A(1) = EU(indmax, 9) '* Scalb  'altezza colonne
        iTipo = EU(indmax, 10) 'tiraggio
        Call ResetxyF(X, y, indmax)
        With Monitor.routines
            If .SwIUNpri = 3 Then
                BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nome, 1, 1, 1, 0)
                ACADobj.Application.Update()
                nome = "VistaLat"
                block = ACADobj.Blocks.Add(inspoint, nome)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.InitAcad. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .InitAcad(block)
            End If
        End With
        Call Fascio(X, y, indmax)
        If iTipo = 1 Then
            Call CamLatFor(X, y, indmax, 1) ' Scalb)
        Else
            Call CamLatInd(X, y, indmax, 1) ' Scalb)
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        P(1) = Monitor.routines.poynt(X, 0)
        If A(1) > 0 Then Call PassScal(X, y)
        If iTipo = 1 Then
            Call QuotAltFor(X, y, indmax, 1) ' Scalb)
        Else
            Call QuotAltInd(X, y, indmax, 1) ' Scalb)
        End If
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .SwIUNpri = 3 Then
                BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nome, 1, 1, 1, 0)
            End If
        End With
        'If Monitor.routines.SwIUNpri = 3 Then
        '      Nome = "Prova5"
        '      Set block = ACADobj.Blocks.Add(inspoint(), Nome)
        'End If
        'If Monitor.routines.SwIUNpri = 3 Then
        '      nomeblock = "Prova2"
        '      Set block = ACADobj.Blocks.Add(inspoint(), nomeblock)
        'End If
        '***********************************************************************
        '                   COSTRUZIONE   DEI   FASCI
        '***********************************************************************
        '521   Call FORMA1(iActBank, Numa$)   'Scalb
        '      Call Monitor.routines.refere(0!, c(1), 0!)
        '522   Items xxxD(), 1 ' Scalb
        '      If Monitor.routines.SwIUNpri = 3 Then
        '            ACADobj.ModelSpace.InsertBlock inspoint(), Nome, 1, 1, 0
        '      End If
        '      Exit Sub
        'ErrForz:
        '  PRINT "Errrore FORZAT"; ERR, ERL: u$ = INPUT$(1)
        '  Resume Next
    End Sub

    Sub InizzFor(ByRef X As Single, ByRef y As Single, ByRef indmax As Short)
        Dim a2lun As Single
        Dim i As Short
        a2lun = 594
250:    For i = 90 To 100 : A(i) = a2lun : Next  'ex 420
        X = C(11)
        y = -C(2) - (AF(indmax, 1) - AU(indmax, 5) - AU(indmax, 6) - AU(indmax, 7)) / 2.0!
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call Monitor.routines.refere(0.0!, C(1), 0.0!)
    End Sub

    'Sub Drawing(Nome2$, Ext$)
    'DefInt A-Z
    '        If ImmedStam Then
    '                Help$ = "Vuoi generare un file PostSricpt, da inviare subito|"
    '        Help$ = Help$ + "o in differita alla stampante, o vuoi generare un  |"
    '        Help$ = Help$ + "file DXF ?"
    '                 junk = Alert(4, Help$, 4, 3, 10, 58, "PS", "DXF", "")
    '                 If junk = 0 Then Exit Sub
    '        Else
    '           junk = 2
    '        End If
    '        Select Case junk
    '        Case 1
    '               Help$ = "Formato del disegno"
    '               junkP = Alert(4, Help$, 4, 3, 10, 58, "A4", "A3", "")
    '               If junkP = 0 Then Exit Sub
    '               Help$ = "Compilo il File PostScript.."
    '               iandle = Messaggio(1, Help$, 8, 8, 12, 50)
    '               If junkP <> 1 Then junkP = 3
    '               Priink Nome2$, junkP, Ext$
    '               WindowClose iandle
    '               StampaLin Nome2$, Ext$
    '        Case 2
    '               Help$ = "Compilo il File DXF..."
    '               iandle = Messaggio(1, Help$, 8, 8, 12, 50)
    '               Convers 1, 0, Nome2$, Nome1$
    '               WindowClose iandle
    '               a$ = "Il file DXF Š stato registrato sotto|il nome " + RTrim$(Nome1$)
    '             junk = Alert(4, a$, 4, 3, 16, 57, "OK", "", "")
    '        End Select
    'End Sub

    Function IntFront(ByRef im As Short, ByRef Nalt As Short, ByRef Pitch As Single, ByRef LargBundle As Single) As Object
        Dim ia1, ia2 As Short
        Dim itp As String
        Dim Lar As Single
        Dim lartelaio As Single
        '-------Soluzione Brumana ---------------------------------
        With objDatBase
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ia1 = .CVI(.DatBase(4, 49, im, Nalt, itp, 0))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ia2 = .CVI(.DatBase(4, 48, im, Nalt, itp, 0))
        End With
        a3 = Int(2.0! * ia1 / ia2) / 2.0!
        lartelaio = 10 * Int((Pitch * (a3 + 0.5) + 6.0!) / 10 + 1.0!)
        Lar = lartelaio + LargBundle
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto IntFront. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        IntFront = Lar
    End Function
    Sub AlzatoFor(ByRef i As Short, ByRef j As Short, ByRef NCAMPO As Short, ByRef NCAMPI As Short, ByRef X As Single)
        Dim radeg As Object
        Dim Alfa, y, a1 As Single
        '-----------------------------------------------------------------------
        '                      COSTRUZIONE DELL' ALZATO
        '-----------------------------------------------------------------------
        '-------------------   COSTRUZIONE ALZATO UNITA    ---------------------
        With Monitor.routines
330:        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 - A(7) / 2, 0, X + A0 + A(7) / 2, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 - A(3) / 2, 0, X + A0 - A(3) / 2, A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 - A(3) / 2, A(1), X + A0 + A(3) / 2, A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 + A(3) / 2, 0, X + A0 + A(3) / 2, A(1))
            If Left(CH4(i, 3), 1) = "P" Then
                Call Camera(i, X)
            ElseIf Left(CH4(i, 3), 1) = "T" Then
                Call Transition(i, X)
            End If
            '-------------   CASO DI CAMPATA COMUNQUE CON CONTROVENTO   ------------
            If (AU(i, 8) <> 0) Then GoTo 350
            '----  SCELTA SE LA CAMPATA E" CONTROVENTATA NEL CASO NCAMPI PARI  -----
340:        If (NCAMPI \ 2 = NCAMPI / 2) Then
                If (NCAMPO < NCAMPI \ 2 And NCAMPO \ 2 <> NCAMPO / 2 Or NCAMPO = NCAMPI \ 2) Then GoTo 350
                If (NCAMPO > NCAMPI \ 2 And NCAMPO \ 2 = NCAMPO / 2) Then GoTo 350
                Exit Sub
            End If
            '----  SCELTA SE LA CAMPATA E" CONTROVENTATA NEL CASO NCAMPI DISPARI ---
            If (NCAMPI \ 2 <> NCAMPI / 2 And NCAMPO \ 2 <> NCAMPO / 2) Then GoTo 350
            Exit Sub
            '-------------------    COSTRUZIONE DEI CONTOVENTI    ------------------
350:        y = A(1) - A(4)
            If Left(CH4(i, 3), 1) = "T" Then y = A(1) - A(5) - A(6) - 5 * A(3) / 2
            Alfa = 30
            If (e(1) - e(4) < e(13)) Then Alfa = 45.0!
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto radeg. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            a1 = y * System.Math.Tan(Alfa * radeg)
            If (a1 > A0 / 2) Then a1 = A0
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            'controventi
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + a1, y, X + A(3) / 2, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 - a1, y, X + A0 - A(3) / 2, 0)
        End With
    End Sub

    Sub Camera(ByRef i As Short, ByRef X As Single)
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, A(1), X + A0 - A(3) / 2.0!, A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, A(1) - A(4), X + A0 - A(3) / 2.0!, A(1) - A(4))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 / 2.0! - AU(i, 4) / 2.0!, A(1) - A(4), X + A0 / 2.0! - AU(i, 4) / 2.0!, A(1) - A(4) - A(6))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 / 2.0! + AU(i, 4) / 2.0!, A(1) - A(4), X + A0 / 2.0! + AU(i, 4) / 2.0!, A(1) - A(4) - A(6))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A0 / 2.0! - AU(i, 4) / 2.0! - 0.5, A(1) - A(4) - A(6), X + A0 / 2.0! + AU(i, 4) / 2.0! + 0.5, A(1) - A(4) - A(6))
        End With
    End Sub

    Sub CamLatFor(ByRef X As Single, ByRef y As Single, ByRef indmax As Object, ByRef Scalb As Single)
        Dim n As Short
        Dim xa, p1, xb As Single
        Dim Quota As String
        Dim NumLuci As Short
        Dim p2, pxy0, pxy1 As Single
470:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        A5 = AU(indmax, 5) + AU(indmax, 6) + AU(indmax, 7)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        A6 = A5 / NU(indmax, 2)
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            For n = 1 To NU(indmax, 2)
473:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + (n - 0.5) * A6 - AU(indmax, 4) / 2.0!, y + A(1) - A(4), X + (n - 0.5) * A6 - AU(indmax, 4) / 2.0!, y + A(1) - A(4) - A(6))
474:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + (n - 0.5) * A6 + AU(indmax, 4) / 2.0!, y + A(1) - A(4), X + (n - 0.5) * A6 + AU(indmax, 4) / 2.0!, y + A(1) - A(4) - A(6))
475:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + (n - 0.5) * A6 - AU(indmax, 4) / 2.0! - 1.0!, y + A(1) - A(4) - A(6), X + (n - 0.5) * A6 + AU(indmax, 4) / 2.0! + 1.0!, y + A(1) - A(4) - A(6))
            Next
            NumLuci = 0 : For n = 5 To 7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If AU(indmax, n) > 0.0! Then NumLuci = NumLuci + 1
            Next
            For n = 1 To NumLuci
472:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + (n - 1) * A5 / NumLuci + A(3) / 2, y + A(1) - A(4), X + n * A5 / NumLuci - A(3) / 2, y + A(1) - A(4))
            Next
            '-----------------    COSTRUZIONE DELLE COLONNE    ---------------------
            '     COSTRUZIONE DEL PRIMO CONTROVENTO
            If A(1) > 0 Then
480:            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X, y, X + (A(1) - A(4)) * 0.7, y + A(1) - A(4))
                For n = 5 To 7
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If (AU(indmax, n) = 0.0!) Then GoTo 32
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    p1 = .poynt(X, y) : If n = 5 Then pxy0 = p1 : xa = X
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto indmax. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    X = X + AU(indmax, n)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    p2 = .poynt(X, y) : pxy1 = p2 : xb = X
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X - A(3) / 2.0!, y, X - A(3) / 2.0!, y + A(1))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + A(3) / 2.0!, y, X + A(3) / 2.0!, y + A(1))
                    .segm(X - A(7) / 2.0!, y, X + A(7) / 2.0!, y)
                    '     QUOTATURA INTERASSE COLONNE
                    Quota = Trim(Str(Int(AU(indmax, n))))
                    If NumLuci > 1 Then
                        Call .ql1(p1, p2, 1, -e(1) / 5, Quota) ' Scalb, )
                    End If
32:             Next
                Quota = Trim(Str(Int(System.Math.Abs(xb - xa))))
                Call .ql1(pxy0, pxy1, 1, -2 * e(1) / 5, Quota) ' Scalb, "")
                '     COSTRUZIONE DEL SECONDO CONTROVENTO
                .segm(X, y, X - (A(1) - A(4)) * 0.7, y + A(1) - A(4))
            End If
        End With
    End Sub
    Sub FinPassTestD(ByRef X As Single, ByRef y As Single, ByRef a2 As Single, ByRef indmax As Short)
        Dim AR1, AR2 As Single
        If (e(1) < 2800.0!) Then
            A(17) = e(1) '* Scalb
        Else
            A(17) = 2700 '* Scalb
        End If
        With Monitor.routines
            If A(1) > 0 Then
                If (CH2(10) = "NO") Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If (CH2(2) = "SI") Then .segm(X, y + A(14), X, y + A(14) + A(8))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If (CH2(5) = "SI") Then .segm(X, y - a2 - A(14), X, y - a2 - A(14) - A(8))
                End If
                '      IF (ch2(3) = "SI") THEN AR1 = arc(x + a(8) * .6, y + a(14) + a(8) * .5, x + a(8) * .2, y + a(14) + a(8) * .75, -296!)
                '      IF (ch2(6) = "SI") THEN AR1 = arc(x + a(8) * .6, y - A2 - a(14) - a(8) * .5, x + a(8) * .2009766, y - A2 - a(14) - a(8) * .25, -296!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If (CH2(3) = "SI") Then AR1 = .arc(X + A(8) * 0.6, y + A(14) + A(8) * 0.5, X + A(8) * 0.2, y + A(14) + A(8) * 0.25, 296.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If (CH2(6) = "SI") Then AR1 = .arc(X + A(8) * 0.6, y - a2 - A(14) - A(8) * 0.5, X + A(8) * 0.2009766, y - a2 - A(14) - A(8) * 0.75, 296.0!)
420:            If (CH2(11) = "SI") Then
412:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 1.3 * A(8), y + A(14) + A(8), X + 1.3 * A(8), y - a2 - A(14) - A(8))
422:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 1.3 * A(8), y + A(14) + A(8), X + 1.3 * A(8) - 1.0!, y + A(14) + A(8))
423:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 1.3 * A(8), y - a2 - A(14) - A(8), X + 1.3 * A(8) - 1, y - a2 - A(14) - A(8))
424:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 0.3 * A(8), y + A(14), X + 0.3 * A(8), y - a2 - A(14))
425:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 1.3 * A(8), A(1) - A(4) - A(17), X + 0.3 * A(8), A(1) - A(4) - A(17))
426:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 1.3 * A(8), A(1) - A(4) - A(17) + 1, X + 0.3 * A(8), A(1) - A(4) - A(17) + 1)
427:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 1.3 * A(8), A(1) - A(4) - A(17), X + 1.3 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8))
428:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + 0.3 * A(8), A(1) - A(4) - A(17), X + 0.3 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8))
                End If
            End If
        End With
    End Sub

    Sub FinPassTestS(ByRef X As Single, ByRef y As Single, ByRef a2 As Single, ByRef indmax As Short)
        Static AR1, AR2 As Single
        Static nome As String ', block As AutoCAD.AcadBlock
        'Dim inspoint(2) As Double ', BlockRef As AutoCAD.AcadBlockReference
        '---------   COSTRUZIONE FINE PASSERELLA TESTATE -----------------------
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .SwIUNpri = 3 Then
                nome = "FinPassTestS"
                block = ACADobj.Blocks.Add(inspoint, nome)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.InitAcad. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .InitAcad(block)
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            If (CH2(10) = "NO") Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If (CH2(2) = "SI") Then .segm(X, y + A(14), X, y + A(14) + A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If (CH2(5) = "SI") Then .segm(X, y - a2 - A(14), X, y - a2 - A(14) - A(8))
            End If
270:        If (CH2(4) = "SI") Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                AR1 = .arc(X - A(8) * 0.6, y + A(14) + A(8) * 0.5, X - A(8) * 0.2, y + A(14) + A(8) * 0.75, 296.0!)
            End If
            If (CH2(7) = "SI") Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                AR1 = .arc(X - A(8) * 0.6, y - a2 - A(14) - A(8) * 0.5, X - A(8) * 0.2, y - a2 - A(14) - A(8) * 0.25, 296.0!)
            End If
280:        If (CH2(12) = "SI") Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 1.3 * A(8), y + A(14) + A(8), X - 1.3 * A(8), y - a2 - A(14) - A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 1.3 * A(8), y + A(14) + A(8), X - 1.3 * A(8) + 1.0!, y + A(14) + A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 1.3 * A(8), y - a2 - A(14) - A(8), X - 1.3 * A(8) + 1, y - a2 - A(14) - A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 0.3 * A(8), y + A(14), X - 0.3 * A(8), y - a2 - A(14))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 1.3 * A(8), A(1) - A(4) - A(17), X - 0.3 * A(8), A(1) - A(4) - A(17))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 1.3 * A(8), A(1) - A(4) - A(17) + 1, X - 0.3 * A(8), A(1) - A(4) - A(17) + 1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 1.3 * A(8), A(1) - A(4) - A(17), X - 1.3 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - 0.3 * A(8), A(1) - A(4) - A(17), X - 0.3 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8))
            End If
290:        If (CH2(8) = "SI") Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A(3) / 2.0!, A(1) - A(4) - A(17) + 1.3 * A(8), X + A(3) / 2.0! + 4.5 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A(3) / 2.0!, A(1) - A(4) - A(17) + 0.8 * A(8), X + A(3) / 2.0! + 4.7 * A(8), A(1) - A(4) - A(17) + 0.8 * A(8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A(3) / 2.0!, A(1) - A(4) - A(17) + 1.0!, X + A(3) / 2.0! + 4.9 * A(8), A(1) - A(4) - A(17) + 1.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A(3) / 2.0!, A(1) - A(4) - A(17), X + A(3) / 2.0! + 4.9 * A(8), A(1) - A(4) - A(17))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + 1.2 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8), X + 1.2 * A(8), A(1) - A(4) - A(17) + 1.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + 2.4 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8), X + 2.4 * A(8), A(1) - A(4) - A(17) + 1.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + 3.6 * A(8), A(1) - A(4) - A(17) + 1.3 * A(8), X + 3.6 * A(8), A(1) - A(4) - A(17) + 1.0!)
            End If
300:        X = X - AU(indmax, 8)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .SwIUNpri = 3 Then
                BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nome, 1, 1, 1, 0)
                ACADobj.Application.Update()
            End If
        End With
    End Sub


    Sub Items(ByRef Scalb As Single)
        'Dim inspoint(2) As Double
        Static X, y As Single
        Static i, iunita, l As Short
        Static xaa, ltot, xbb As Single
        Static j As Short
        Static p1, xab, yab, ArckO As Single
        Static NVOLTE, M As Short
        Static ere As Single
        Static nome As String
        Static n As Short
        Static xt, alung, yps As Single
        Static iyi As Short
        Static factor As Single
        Static nomeblock As String
        iyi = 0
        nomeblock = ""
        'On Local Error GoTo ErrItems
        'If Monitor.routines.SwIUNpri = 3 Then
        '      nomeblock = "Prova"
        '      Set block = ACADobj.Blocks.Add(inspoint(), nomeblock)
        'End If
        X = C(11)
        iunita = 0
        A(1) = 0
530:    For i = 1 To 30
            iunita = iunita + 1
            If (nf(i, 1) = 0) Then Exit For
            ltot = nf(i, 1) * AF(i, 2) + nf(i, 1) * System.Math.Abs(AF(i, 4))
            'IF xxxD(i) - xxxD(i - 1) - au(iunita, 8) > 1.5 * ltot THEN
            If AF(i, 4) < 0 And AF(i + 1, 4) < 0 Then
                For l = 30 - i To 1 Step -1
                    xxxD(i + l) = xxxD(i + l - 1)
                Next
                xxxD(i) = xxxD(i - 1) + ltot
                iunita = iunita - 1
            End If
            '------------------CONDIZIONE DI SALTO UNITA
            With Monitor.routines
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(0.0!, -A(1), 0.0!)
                If iunita > 0 Then
                    A(1) = EU(iunita, 9) * Scalb
                Else
                    A(1) = EU(1, 9) * Scalb
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(0.0!, A(1), 0.0!)
                '---------------   COSTRUZIONE DELLA SIGLA DELL'ITEM   -----------------
                'If i = 1 Then '.segm xxxD(0), 20!, xxxD(0), 35!
531:            '.segm xxxD(i), 20!, xxxD(i), 35!
                xaa = xxxD(i - 1) + A(2) + A(9) ': xbb = xxxD(i)
                iyi = iyi + 1
                xbb = xaa + AF(iyi, 2) - A(2) - A(9)
                nome = Trim(CH3(iyi, 1))
                With Monitor.routines.DoveDisegno
                    .Font = New Font("MS Sans Serif", 8)
                    alung = Monitor.routines.DoveDisegnog.MeasureString(nome, .Font).Width
                    If alung > System.Math.Abs(xbb - xaa) Then
                        factor = System.Math.Abs(xbb - xaa) / alung
                        .Font = New Font("Small Fonts", 8 * factor)
                        alung = Monitor.routines.DoveDisegnog.MeasureString(nome, .Font).Width
                    End If
                    xt = xaa + System.Math.Abs(xaa - xbb) / 2 - alung / 2
                    Call Monitor.routines.ECRIR(nome)
                    yps = -Monitor.routines.DoveDisegnog.MeasureString(nome, .Font).Height '* 1.1 '(iyi Mod 2) * 5 + 25
                End With
                Monitor.routines.texte0(xt, yps, 0.0!, 2.5, 0.2)
            End With
            '-------------------------------------------------------------
            For j = 1 To nf(i, 1)
                y = 0.0!
                '------------------  DISTANZA DAL FASCIO DI SX    ----------------------
                If j = 1 Then
                    X = xxxD(i - 1) + (xxxD(i) - xxxD(i - 1) - ltot - AU(iunita, 8) + System.Math.Abs(AF(i, 4))) / 2
                    X = X + AU(iunita, 8)
                Else
                    X = X + System.Math.Abs(AF(i, 4))
                End If
                '-----------------   COSTRUZIONE  DELLO  STEAM COIL  -------------------
                With Monitor.routines
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .SwIUNpri = 3 Then
                        If Len(nomeblock) > 0 Then BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nomeblock, 1, 1, 1, 0)
                        nomeblock = "Fascio" & Trim(Str(i)) & "_" & Trim(Str(j))
                        block = ACADobj.Blocks.Add(inspoint, nomeblock)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.InitAcad. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .InitAcad(block)
                    End If
550:                If (InStr(Mid(CH3(i, 3), 1, 6), "SI") > 0) Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.2)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + A(2) + A(9), 0.0!, X + A(2) + A(9), A(12))
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + AF(i, 2) - A(2) - A(9), 0.0!, X + AF(i, 2) - A(2) - A(9), A(12))
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + A(2), A(12), X + AF(i, 2) - A(2), A(12))
                        y = A(12)
                    End If
                    '-----------------   COSTRUZIONE  DEL FASCIO    ------------------------
555:                For NVOLTE = 1 To Max(1, nf(i, 5))
                        Call .ctrait(0, 0.4)
                        .segm(X + A(2), y, X + A(2), y + AF(i, 3))
                        .segm(X + A(2), y + AF(i, 3), X + AF(i, 2) - A(2), y + AF(i, 3))
                        .segm(X + AF(i, 2) - A(2), y + AF(i, 3), X + AF(i, 2) - A(2), y)
559:                    y = y + AF(i, 3)
                    Next
                    '-----------------   COSTRUZIONE  DELLA SERRANDA  ----------------------
560:                If (InStr(Mid(CH3(i, 2), 1, 6), "SI") > 0) Then
                        Call .ctrait(0, 0.2)
                        .segm(X + A(2) + A(10), y, X + A(2) + A(10), y + A(11))
                        .segm(X + A(2) + A(10), y + A(11), X + AF(i, 2) - A(2) - A(10), y + A(11))
                        .segm(X + AF(i, 2) - A(2) - A(10), y + A(11), X + AF(i, 2) - A(2) - A(10), y)
                    End If
                    '-------------    COSTRUZIONE DEL FASCIO IN PIANTA    ------------------
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .SwIUNpri = 3 Then
                        BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nomeblock, 1, 1, 1, 0)
                        ACADobj.Application.Update()
                        nomeblock = "FascioP" & Trim(Str(i)) & "_" & Trim(Str(j))
                        block = ACADobj.Blocks.Add(inspoint, nomeblock)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.InitAcad. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .InitAcad(block)
                    End If
                    y = -A(1) - C(2)
565:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(0, 0.2)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + A(2), y, X + AF(i, 2) - A(2), y)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + AF(i, 2) - A(2), y, X + AF(i, 2) - A(2), y - AF(i, 1))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + AF(i, 2) - A(2), y - AF(i, 1), X + A(2), y - AF(i, 1))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + A(2), y - AF(i, 1), X + A(2), y)
                    '---------   COSTRUZIONE DEI BOCCHELLI IN PIANTA LATO INGRESSO   -------
570:                If (nf(i, 2) <> 0) Then
                        a3 = AF(i, 2) / (nf(i, 2) * 2)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.2)
                        For M = 1 To nf(i, 2)
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            p1 = .poynt(X + a3 + (M - 1) * 2 * a3, y - A(19))
                            xab = X + a3 + (M - 1) * 2 * a3
                            yab = y - A(19)
                            ere = A(15) / 2
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            ArckO = .cerc(xab, yab, ere)
575:                        For n = 90 To 360 Step 90
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                .seg2(p1, A(15), n * 1.0!)
                            Next
                        Next
                    End If
                    '---------   COSTRUZIONE DEI BOCCHELLI IN PIANTA LATO USCITA   ---------
580:                If (nf(i, 4) \ 2 <> nf(i, 4) / 2.0!) Then
                        a3 = AF(i, 2) / (nf(i, 3) * 2)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.2)
                        'DO 110 M = 1,NF(I,3)
                        For M = 1 To nf(i, 3)
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            p1 = .poynt(X + a3 + (M - 1) * 2 * a3, y - AF(i, 1) + A(19))
                            'DO 120 N = 90,360,90
                            For n = 90 To 360 Step 90
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                .seg2(p1, A(15), n * 1.0!)
                                '120   CONTINUE
                            Next n
                            '110   CONTINUE
                        Next M
                    End If
                End With
                '---------------   POSIZIONAMENTO PER FASCIO SUCCESSIVO   --------------
590:            X = X + AF(i, 2)
            Next j
        Next i
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.SwIUNpri. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Monitor.routines.SwIUNpri = 3 Then
            BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint, nomeblock, 1, 1, 1, 0)
            ACADobj.Application.Update()
        End If
        Exit Sub
    End Sub

    Sub PiantaFor(ByRef X As Single, ByRef y As Single, ByRef i As Short)
        Dim A222, arc1 As Single
        Dim M As Short
        With Monitor.routines
370:        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(1.0!, 0.1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X, y, X + A0, y)
            A222 = (AU(i, 5) + AU(i, 6) + AU(i, 7)) / NU(i, 2)
            For M = 1 To NU(i, 2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X, y - A222 * M, X + A0, y - A222 * M)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A0, y - A222 * (M - 1), X + A0, y - A222 * M)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If M = 1 Then .segm(X, y - A222 * (M - 1), X, y - A222 * M)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                arc1 = .cerc(X + A0 / 2.0!, y - A222 * (M - 0.5), AU(i, 4) / 2.0!)
            Next
        End With
    End Sub

    'Sub Prova()
    'AddDistinta = 1
    'CLS:  Screen 0
    'Catena "HTRI"
    'End Sub

    Sub QuotaColonn(ByRef i As Short, ByRef X As Single, ByRef P() As Single, ByRef Scalb As Single)
        '-------------------   QUOTATURA INTERASSE COLONNE   -------------------
        Dim M As Short
        Dim Quota As String
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            P(1) = .poynt(X, 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            P(2) = .poynt(X + AU(i, 1), 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            P(3) = .poynt(X + AU(i, 1) + AU(i, 2), 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            P(4) = .poynt(X + AU(i, 1) + AU(i, 2) + AU(i, 3), 0.0!)
            For M = 1 To 3
                If (.xcoord(P(M)) = .xcoord(P(M + 1))) Then GoTo 466
                Quota = Trim(Str(Int(.xcoord(P(M + 1)) - .xcoord(P(M)))))
                Call .ql1(P(M), P(M + 1), 1, -e(1) / 5, Quota)
466:        Next
        End With
    End Sub

    Sub QuotAltFor(ByRef X As Single, ByRef y As Single, ByRef indmax As Short, ByRef Scalb As Single)
        Dim p1, A7, p2 As Single
        Dim P3, p4 As Single
        With Monitor.routines
            '------------------   QUOTATURA ALTEZZA COL.,PANNELLI   ----------------
510:        If (CH2(5) = "SI") Then
                A7 = A(8) + A(14)
            Else
                A7 = 2.0!
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p1 = .poynt(X + A7, y + A(1))
            p2 = .poynt(X + A7, y + A(1) - A(4))
            P3 = .poynt(X + A7, y + A(1) - A(4) - A(6))
            p4 = .poynt(X + A7, y)
            Call .ql1(p1, p2, 2, 2 * e(1) / 5, Trim(Str(Int(A(4)))))
            Call .ql1(p2, P3, 2, e(1) / 5, Trim(Str(Int(A(6)))))
            Call .ql1(p1, p4, 2, 3 * e(1) / 5, Trim(Str(Int(A(1)))))
        End With
    End Sub
    Sub ResetxyF(ByRef X As Object, ByRef y As Object, ByRef indmax As Object)
        '430   If (X + af(indmax, 1) + 75! < 614!) Then 'ex 440
        '            c(15) = (597.9063 - X - 50! - af(indmax, 1)) / 2! 'ex 440 614
        '            X = X + c(15) + 30!
        '            Y = 0!
        '      Else
        '            X = 80.39063
        '            Y = a(1) - c(1) + 60!
        '      End If
        If InLinea Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto X. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X = e(51) + C(2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y = 0
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto X. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X = 0
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y = 2 * A(1) + C(2)
        End If
    End Sub

    Sub Transition(ByRef i As Short, ByRef X As Single)
        Dim y As Single
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, A(1), X + A0 - A(3) / 2.0!, A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, A(1) - A(3), X + A0 - A(3) / 2.0!, A(1) - A(3))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(X + A0 / 2.0!, A(1) - A(3), 180.0!)
            Call Cappa(i, X)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-X - A0 / 2.0!, -A(1) + A(3), -180.0!)
            y = A(1) - A(5) - A(6) - 3 * A(3) / 2.0!
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, y, X + A0 - A(3) / 2.0!, y)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, y - A(3), X + A0 - A(3) / 2.0!, y - A(3))
        End With
    End Sub
    Sub ActAltInd(ByRef i As Short, ByRef j As Short)
        Static xmin, xmax As Single '???????????????
        Dim l, M As Short
        Dim xrif, H1 As Single
        If i = 1 And j = 1 Then
            xmin = 0.0!
            xmax = 0.0!
        End If
        xmin = xmax
        xmax = xmin + A0 + AU(i, 8)
        xrif = 0.0!
        A9 = 0.0!
        A10 = 0.0!
        For l = 1 To 30
            For M = 1 To nf(l, 1)
                xrif = xrif + AF(l, 2)
                If (xrif > xmax) Then Exit Sub
                If (xrif >= xmin) Then
                    H1 = AF(l, 3) * Max(1, nf(l, 5))
                    If (InStr(Mid(CH3(l, 2), 1, 6), "SI") > 0) Then H1 = H1 + A(11)
                    If (InStr(Mid(CH3(l, 3), 1, 6), "SI") > 0) Then H1 = H1 + A(12)
                    A9 = Max(A9, H1)
                    A10 = Max(A10, AF(l, 1))
                End If
            Next
        Next
    End Sub

    Function AltColo(ByRef H As String, ByRef Ncod As Object) As Object
        If H = "F" Then
            Select Case Ncod
                Case 3, 5, 6
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AltColo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltColo = 4160
                Case 4
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AltColo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltColo = 4350
                Case Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AltColo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltColo = 0
            End Select
        Else
            Select Case Ncod
                Case 3, 5, 6
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AltColo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltColo = 2550
                Case 4
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AltColo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltColo = 2730
                Case Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AltColo. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    AltColo = 0
            End Select
        End If
    End Function

    Sub AlzatoInd(ByRef i As Short, ByRef j As Short, ByRef NCAMPO As Short, ByRef NCAMPI As Short, ByRef X As Single)
        Dim radeg As Object
        Dim Alfa As Single
        Dim n As Short
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, A(1), X + A0 - A(3) / 2.0!, A(1))
            For n = 1 To 3
                A5 = 0
                If (AU(i, n) = 0.0!) Then GoTo 39
                A5 = A5 + AU(i, n)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If (A20 <> 0.0!) Then .segm(X + A(3) / 2.0!, A(1) - A20, X + A5 - A(3) / 2.0!, A(1) - A20)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A5 - A(7) / 2.0!, 0.0!, X + A5 + A(7) / 2.0!, 0.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A5 - A(3) / 2.0!, 0.0!, X + A5 - A(3) / 2.0!, A(1))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A5 - A(3) / 2.0!, A(1), X + A5 + A(3) / 2.0!, A(1))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A5 + A(3) / 2.0!, 0.0!, X + A5 + A(3) / 2.0!, A(1))
                '-------------   CASO DI CAMPATA COMUNQUE CON CONTROVENTO   ------------
                If (AU(i, 8) <> 0.0!) Then GoTo 40
                '----  SCELTA SE LA CAMPATA E' CONTROVENTATA NEL CASO NCAMPI PARI  -----
                If (NCAMPI \ 2 = NCAMPI / 2.0!) Then
                    If (NCAMPO < NCAMPI \ 2 And NCAMPO \ 2 <> NCAMPO / 2.0! Or NCAMPO = NCAMPI \ 2) Then GoTo 40
                    If (NCAMPO > NCAMPI \ 2 And NCAMPO \ 2 = NCAMPO / 2.0!) Then GoTo 40
                    GoTo 455
                End If
                '----  SCELTA SE LA CAMPATA E' CONTROVENTATA NEL CASO NCAMPI DISPARI ---
                If (NCAMPI \ 2 <> NCAMPI / 2.0! And NCAMPO \ 2 <> NCAMPO / 2.0!) Then GoTo 40
                GoTo 455
                '-------------------    COSTRUZIONE DEI CONTOVENTI    ------------------
40:
                Alfa = 35.0!
                If (e(1) < e(13)) Then Alfa = 45.0!
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto radeg. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                a1 = (A(1) - A20) * System.Math.Tan(Alfa * radeg)
                If (a1 > A5 / 2.0! Or Mid(CH4(i, 1), 1, 7) = "       ") Then a1 = A5 - A(3) / 2.0!
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + a1, A(1) - A20, X + A(3) / 2.0!, 0.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A5 - a1, A(1) - A20, X + A5 - A(3) / 2.0!, 0.0!)
455:            X = X + A5
                '                  NCAMPO = NCAMPO + 1
39:         Next
            X = X - AU(i, 1) - AU(i, 2) - AU(i, 3)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(X + A0 / 2.0!, A(1) + A9, 0.0!)
            Call Cappa(i, X)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-X - A0 / 2.0!, -A(1) - A9, 0.0!)
        End With
    End Sub
    Sub CamLatInd(ByRef X As Single, ByRef y As Single, ByRef indmax As Short, ByRef Scalb As Single)
        Dim n As Short
        Dim p1, p2 As Single
        With Monitor.routines
            A6 = (AF(indmax, 1) - 5 * A(19)) / NU(indmax, 2)
            A7 = (A6 - AU(indmax, 4)) / 2.0! - A(21)
            A8 = X - a4 + 2.5 * A(19)
            If (A7 <= A(5) / 2.0!) Then A7 = 0.0!
            For n = 1 To NU(indmax, 2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 + (n - 0.5) * A6 - AU(indmax, 4) / 2.0!, y + A(1) + AF(indmax, 3) + A(5), A8 + (n - 0.5) * A6 - AU(indmax, 4) / 2.0!, y + A(1) + AF(indmax, 3) + A(5) + A(6))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 + (n - 0.5) * A6 + AU(indmax, 4) / 2.0!, y + A(1) + AF(indmax, 3) + A(5), A8 + (n - 0.5) * A6 + AU(indmax, 4) / 2.0!, y + A(1) + AF(indmax, 3) + A(5) + A(6))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 + (n - 0.5) * A6 - AU(indmax, 4) / 2.0! - 1.0!, y + A(1) + AF(indmax, 3) + A(5) + A(6), A8 + (n - 0.5) * A6 + AU(indmax, 4) / 2.0! + 1.0!, y + A(1) + AF(indmax, 3) + A(5) + A(6))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 + (n - 1) * A6, y + A(1) + AF(indmax, 3), A8 + (n - 1) * A6 + A7, y + A(1) + AF(indmax, 3) + A(5))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 + (n - 1) * A6 + A7, y + A(1) + AF(indmax, 3) + A(5), A8 + n * A6 - A7, y + A(1) + AF(indmax, 3) + A(5))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 + n * A6, y + A(1) + AF(indmax, 3), A8 + n * A6 - A7, y + A(1) + AF(indmax, 3) + A(5))
            Next
            '-----------------    COSTRUZIONE DELLE COLONNE    ---------------------
            A5 = AU(indmax, 5) + AU(indmax, 6) + AU(indmax, 7)
            '     COSTRUZIONE DEI CONTROVENTI
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X, y, X + A(1) * 0.7, y + A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A5, y, X + A5 - A(1) * 0.7, y + A(1))
            For n = 5 To 7
                If (AU(indmax, n) = 0.0!) Then GoTo 322
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p1 = .poynt(X, y)
                X = X + AU(indmax, n)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p2 = .poynt(X, y)
                .segm(X - A(3) / 2.0!, y, X - A(3) / 2.0!, y + A(1))
                .segm(X + A(3) / 2.0!, y, X + A(3) / 2.0!, y + A(1))
                .segm(X - A(7) / 2.0!, y, X + A(7) / 2.0!, y)
                '     QUOTATURA INTERASSE COLONNE
                Call .ql1(p1, p2, 1, -e(1) / 5, Trim(Str(Int(AU(indmax, n)))))
322:        Next
        End With
    End Sub

    Sub Cappa(ByRef i As Short, ByRef X As Single)
        Dim l As Short
        A7 = Max(AU(i, 4) / 2.0! + A(21), A0 / 2 - A(2))
        A8 = AU(i, 4) / 2.0! + A(21)
        If (A7 - A8 <= A(5) / 2.0!) Then
            A7 = A0 / 2.0!
            A8 = A7
        End If
        'disegno della cappa
        With Monitor.routines
            For l = -1 To 1 Step 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A7 * l, 0.0!, A8 * l, A(5))
                '                 obliquo
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(A8 * l, A(5), 0.0!, A(5))
                '                 piano anello
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(AU(i, 4) / 2.0! * l, A(5), AU(i, 4) / 2.0! * l, A(5) + A(6))
                '                 alzato anello
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm((AU(i, 4) / 2.0! + 1.0!) * l, A(5) + A(6), 0.0!, A(5) + A(6))
                '                 piano anello
            Next
        End With
    End Sub

    Sub ColSx(ByRef X As Single, ByRef i As Short, ByRef j As Short)
        With Monitor.routines
320:        If (i = 1 And j = 1 Or AU(i, 8) <> 0.0!) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - A(3) / 2.0!, 0.0!, X - A(3) / 2.0!, A(1))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - A(3) / 2.0!, A(1), X + A(3) / 2.0!, A(1))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A(3) / 2.0!, 0.0!, X + A(3) / 2.0!, A(1))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X - A(7) / 2.0!, 0.0!, X + A(7) / 2.0!, 0.0!)
            End If
        End With
    End Sub

    Sub Fascio(ByRef X As Single, ByRef y As Single, ByRef indmax As Short)
        Dim Z As Single
        With Monitor.routines
440:        a4 = (AF(indmax, 1) - AU(indmax, 5) - AU(indmax, 6) - AU(indmax, 7)) / 2.0!
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X - a4, y + A(1), X + AF(indmax, 1) - a4, y + A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X - a4, y + A(1) + AF(indmax, 3), X + AF(indmax, 1) - a4, y + A(1) + AF(indmax, 3))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X - a4, y + A(1), X - a4, y + A(1) + AF(indmax, 3))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + AF(indmax, 1) - a4, y + A(1), X + AF(indmax, 1) - a4, y + A(1) + AF(indmax, 3))
            '---------------    COSTRUZIONE DELLA PRIMA COLONNA  -------------------
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X - A(3) / 2.0!, y, X - A(3) / 2.0!, y + A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X + A(3) / 2.0!, y, X + A(3) / 2.0!, y + A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X - A(7) / 2.0!, y, X + A(7) / 2.0!, y)
            '------------  COSTRUZIONE PASSERELLE TESTATE LATO INGRESSO  -----------
            If A(1) > 0 Then
450:            If (CH2(2) = "SI") Then
                    .segm(X - A(3) / 2.0!, y + A(1) - A(16) - A(18), X - A(14) - A(8), y + A(1) - A(16) - A(18))
                    .segm(X - A(8) - A(14) + 1.0!, y + A(1) - A(16) - A(18), X - A(3) / 2.0!, Max(y, y + A(1) - A(16) - A(18) - A(8) - A(14) + 1.0!))
                    .segm(X - A(14), y + A(1) - A(16), X - A(14) - A(8), y + A(1) - A(16))
                    .segm(X - A(14) - A(8), y + A(1) - A(16) - A(18), X - A(14) - A(8), y + A(1) + 1.0!)
                    .segm(X - A(14), y + A(1) - A(16) - A(18), X - A(14), y + A(1) - 1.0!)
                End If
                '---------------------  COSTRUZIONE DELLE SCALE      -------------------
460:            If (CH2(4) = "SI") Then
                    .segm(X - A(14) - A(8) * 0.75, y, X - A(14) - A(8) * 0.75, y + A(1) - 1.8 * A(16))
                    .segm(X - A(14) - A(8) * 0.25, y, X - A(14) - A(8) * 0.25, y + A(1) - 2.0! * A(16))
                    Z = y + 0.2 * A(8)
102:                If (Z < y + A(1) - 2.0! * A(16)) Then
                        .segm(X - A(14) - 0.75 * A(8), Z, X - A(14) - 0.25 * A(8), Z)
                        Z = Z + 0.3 * A(8)
                        GoTo 102
                    End If
                End If
            End If
        End With
    End Sub

    Sub FORMA1(ByRef Numa As String)
        Static Adjust As Object
        'On Local Error GoTo ErrFor
        '      CALL refere(0!, -c(1) + a(1), 0!)
        Static Scalb As Single
        Static i, ie As Short
        Static factor, xt, yt, yt0 As Single
        Static HeightC As Single
        Scalb = 1
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call Monitor.routines.refere(0.0!, -C(1), 0.0!)
202:    Mid(che(7), 1, 3) = " 1:"
        ch1(8) = Mid(ch1(8), 11)
        ch1(9) = Mid(ch1(9), 11)
203:    Mid(che(7), 4, 4) = Str(Int(1 / Scalb + 0.2))
302:    Mid(che(7), 8, 50) = Space(50)
        '      IF (ICODE = 1) THEN
303:    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Adjust(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ch1(11) = Adjust(ch1(11), 4) + "/" + Numa
304:    ch1(12) = "1ST ISSUE"
305:    ch1(13) = Str(iActBank)
205:    ch1(14) = Str(NumB)
        '      END IF
        For i = 6 To 35 Step 5
            If (i = 21) Then GoTo 201
            ie = (i + 4) / 5
206:        If Len(LTrim(Mid(che(ie), 1, 25))) = 0 Then GoTo 201
            Call Monitor.routines.ECRIR(che(ie))
            With Monitor.routines.DoveDisegno
                .Font = New Font("MS Sans Serif", 8)
                factor = .Width / 700
                xt = .Left + BB(i) * factor
                yt = .Top + .Height + BB(i + 1) * factor
            End With
            Monitor.routines.texte0(xt, yt, BB(i + 2), BB(i + 3), BB(i + 4))
201:    Next
208:    For i = 1 To 70 Step 5
209:        ie = (i + 4) / 5
210:        If Len(LTrim(Mid(ch1(ie), 4, 25))) = 0 Then GoTo 301
            Call Monitor.routines.ECRIR(ch1(ie))
            With Monitor.routines.DoveDisegno
                If ie = 1 Or ie > 4 Then
                    .Font = New Font("MS Sans Serif", 8)
                End If
                factor = .Width / 700
                xt = CC(i) * factor
                yt = .Top + .Height + CC(i + 1) * factor
                If ie = 1 Then
                    yt0 = .Top + .Height + CC(i + 6) * factor
                    HeightC = System.Math.Abs(Monitor.routines.DoveDisegnog.MeasureString("A", .Font).Height)
                    If System.Math.Abs(yt - yt0) < HeightC And System.Math.Abs(yt - yt0) > 0 Then
                        .Font = New Font("Small Fonts", 8 * System.Math.Abs(yt - yt0) / HeightC)
                    End If
                End If
            End With
            Monitor.routines.texte0(xt, yt, CC(i + 2), CC(i + 3), CC(i + 4))
301:    Next
        Call Monitor.routines.refabs()
        Exit Sub
    End Sub
    Sub InizzInd(ByRef X As Single, ByRef y As Single, ByRef indmax As Short)
        Dim a2lun As Single
        Dim i As Short
        a2lun = 594
        For i = 90 To 100 : A(i) = a2lun : Next  'ex 420
        X = C(11)
        y = -C(2) - 2.5 * A(19)
        '       CALL refere(0!, c(1) - a(1), 0!)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call Monitor.routines.refere(0.0!, C(1), 0.0!)
        '      CALL refere(0!, c(1) - au(indmax, 9), 0!)
    End Sub

    Function Islop(ByRef Incl As Short, ByRef Lungh As Short) As Short
        Dim pied1 As Single
        pied1 = 305
        Select Case Incl
            Case Is < 3, Is > 12 : Islop = 0
            Case 3 : Islop = CSng(Lungh) * 5 / 1000
            Case 4 : Islop = CSng(Lungh) * 10 / 1000
            Case 5 : Islop = CSng(Lungh) * 20 / 1000
            Case 6 : Islop = CSng(Lungh) * 40 / 1000
            Case 7 : Islop = CSng(Lungh) * 3.175 / pied1
            Case 8 : Islop = CSng(Lungh) * 6.35 / pied1
            Case 9 : Islop = CSng(Lungh) * 12.7 / pied1
            Case 11 : Islop = CSng(Lungh) * 1.5875 / pied1
            Case 12 : Islop = CSng(Lungh) * 5.08 / pied1
            Case Else : Islop = -99
        End Select
        Exit Function
    End Function
    Sub PasserInf(ByRef X As Single, ByRef y As Single, ByRef i As Short, ByRef j As Short)
        With Monitor.routines
            '----------   COSTRUZIONE DELLE PASSERELLE TESTATE LATO USCITA   -------
390:        If (CH2(5) = "SI" And A(1) > 0) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.2)
                If (i = 1 And j = 1) Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y - a2 - A(14), X + A0, y - a2 - A(14))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y - a2 - A(14) - A(8), X + A0, y - a2 - A(14) - A(8))
                Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X - AU(i, 8), y - a2 - A(14), X + A0, y - a2 - A(14))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X - AU(i, 8), y - a2 - A(14) - A(8), X + A0, y - a2 - A(14) - A(8))
                End If
            End If
        End With
    End Sub
    Sub PasserSup(ByRef X As Single, ByRef y As Single, ByRef i As Short, ByRef j As Short)
        '----------   COSTRUZIONE DELLE PASSERELLE TESTATE LATO INGRESSO   -----
        With Monitor.routines
380:        If (CH2(2) = "SI" And A(1) > 0) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.2)
                If (i = 1 And j = 1) Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y + A(14), X + A0, y + A(14))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y + A(14) + A(8), X + A0, y + A(14) + A(8))
                Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X - AU(i, 8), y + A(14), X + A0, y + A(14))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X - AU(i, 8), y + A(14) + A(8), X + A0, y + A(14) + A(8))
                End If
            End If
        End With
    End Sub

    Sub PassScal(ByRef X As Single, ByRef y As Single)
        Dim Z As Single
        With Monitor.routines
            '------------  COSTRUZIONE PASSERELLE TESTATE LATO USCITA  -------------
490:        If (CH2(5) = "SI") Then
                .segm(X + A(3) / 2.0!, y + A(1) - A(16) - A(18), X + A(14) + A(8), y + A(1) - A(16) - A(18))
                .segm(X + A(8) + A(14) - 1.0!, y + A(1) - A(16) - A(18), X + A(3) / 2.0!, Max(y, y + A(1) - A(16) - A(18) - A(8) - A(14) + 1.0!))
                .segm(X + A(14), y + A(1) - A(16), X + A(14) + A(8), y + A(1) - A(16))
                .segm(X + A(14) + A(8), y + A(1) - A(16) - A(18), X + A(14) + A(8), y + A(1) + 1.0!)
                .segm(X + A(14), y + A(1) - A(16) - A(18), X + A(14), y + A(1) - 1.0!)
            End If
            '---------------------  COSTRUZIONE DELLE SCALE      -------------------
500:        If (CH2(7) = "SI") Then
                .segm(X + A(14) + A(8) * 0.75, y, X + A(14) + A(8) * 0.75, y + A(1) - 1.8 * A(16))
                .segm(X + A(14) + A(8) * 0.25, y, X + A(14) + A(8) * 0.25, y + A(1) - 2.0! * A(16))
                Z = y + 0.2 * A(8)
103:            If (Z < y + A(1) - 2.0! * A(16)) Then
                    .segm(X + A(14) + 0.75 * A(8), Z, X + A(14) + 0.25 * A(8), Z)
                    Z = Z + 0.3 * A(8)
                    GoTo 103
                End If
            End If
        End With
    End Sub
    Sub PiantaInd(ByRef X As Single, ByRef y As Single, ByRef i As Short)
        Dim A222, arc1 As Single
        Dim M As Short
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .segm(X, y, X + A0, y)
            A222 = (A10 - 5 * A(19)) / NU(i, 2)
            A11 = (A222 - AU(i, 4) - 2 * A(21)) / 2.0!
            If (A11 < A(5) / 2.0!) Then A11 = 0.0!
            A12 = A0 / 2.0! - A8
            If (A8 = A7) Then A12 = 0.0!
            For M = 1 To NU(i, 2)
                If (M <> NU(i, 2) And A11 = 0.0!) Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(1.0!, 0.1)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y - A222 * M, X + A0, y - A222 * M)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(0, 0.2)
                Else
                    If (M <> NU(i, 2) And A11 = 0.0! And A12 = 0.0!) Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(1.0!, 0.1)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X, y - A222 * M, X + A0, y - A222 * M)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.2)
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X, y - A222 * M, X + A0, y - A222 * M)
                    End If
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .segm(X + A0, y - A222 * (M - 1), X + A0, y - A222 * M)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If (i = 1 Or AU(i, 8) <> 0.0!) Then .segm(X, y - A222 * (M - 1), X, y - A222 * M)
                If (A11 <> 0.0! Or A12 <> 0.0!) Then
                    If (A11 <> 0.0!) Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + A12, y - A222 * (M - 1) - A11, X + A0 - A12, y - A222 * (M - 1) - A11)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + A12, y - A222 * M + A11, X + A0 - A12, y - A222 * M + A11)
                    End If
                    If (A12 <> 0.0!) Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + A12, y - A222 * (M - 1) - A11, X + A12, y - A222 * M + A11)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .segm(X + A0 - A12, y - A222 * (M - 1) - A11, X + A0 - A12, y - A222 * M + A11)
                    End If
                End If
                If (A11 <> 0.0! And A12 <> 0.0!) Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y - A222 * (M - 1), X + A12, y - A222 * (M - 1) - A11)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X, y - A222 * M, X + A12, y - A222 * M + A11)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + A0, y - A222 * (M - 1), X + A0 - A12, y - A222 * (M - 1) - A11)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .segm(X + A0, y - A222 * M, X + A0 - A12, y - A222 * M + A11)
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                arc1 = .cerc(X + A0 / 2.0!, y - A222 * (M - 0.5), AU(i, 4) / 2.0!)
            Next
        End With
    End Sub

    Sub QuotAltInd(ByRef X As Single, ByRef y As Single, ByRef indmax As Short, ByRef Scalb As Single)
        Dim P3, p1, p2, p4 As Single
        Dim p5 As Single
        With Monitor.routines
            '------------------   QUOTATURA ALTEZZA COL.,PANNELLI   ----------------
            If (CH2(5) = "SI") Then
                A7 = A(8) + A(14)
            Else
                A7 = 2.0!
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p1 = .poynt(X + A7, y + A(1))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p2 = .poynt(X + A7, y + A(1) + AF(indmax, 3))
            P3 = .poynt(X + A7, y + A(1) + AF(indmax, 3) + A(5))
            p4 = .poynt(X + A7, y)
            p5 = .poynt(X + A7, y + A(1) + AF(indmax, 3) + A(5) + A(6))
            Call .ql1(p5, P3, 2, e(1), Trim(Str(Int(A(6))))) 'Scalb
            Call .ql1(P3, p2, 2, e(1), Trim(Str(Int(A(5)))))
            Call .ql1(p1, p4, 2, e(1), Trim(Str(Int(A(1)))))
        End With
    End Sub
    Function TipTesta(ByRef Ncod As Short) As Short
        Select Case Ncod
            Case Is < 2, Is > 11 : TipTesta = 0
            Case 2 : TipTesta = 110
            Case Else : TipTesta = 210
        End Select
    End Function

    Sub TrovIndmax(ByRef indmax As Short)
        Dim lmax, j As Short
        lmax = 0
        For j = 1 To 30
            If AF(j, 1) > lmax And NU(j, 2) > 0 Then lmax = AF(j, 1) : indmax = j
        Next
    End Sub
    Sub Passerel(ByRef ni As Short)
        Dim j As Short
        Select Case ni
            Case Is < 3, Is > 6 : For j = 1 To 7 : PAS(j) = "NO" : Next
            Case 3 : PAS(1) = "SI" : PAS(2) = "SI" : For j = 3 To 7 : PAS(j) = "NO" : Next
            Case 4 : PAS(1) = "SI" : For j = 2 To 7 : PAS(j) = "NO" : Next
            Case 5 : For j = 1 To 7 : PAS(j) = "SI" : Next : PAS(4) = "NO" : PAS(5) = "NO"
            Case 6 : For j = 1 To 7 : PAS(j) = "NO" : Next : PAS(3) = "SI" : PAS(6) = "SI" : PAS(7) = "SI"
        End Select
    End Sub
    Function IntLatCol(ByRef ElleTub As Single) As Short
        'supposto che dia ventilatori sempre in piedi' ??????
        Select Case ElleTub
            Case Is <= 6 : IntLatCol = 1500
            Case 6.01 To 8 : IntLatCol = 2150
            Case 8.01 To 9 : IntLatCol = 2450
            Case 9.01 To 10 : IntLatCol = 2750
            Case 10.01 To 12 : IntLatCol = 3350
            Case 12.01 To 15 : IntLatCol = 4300
            Case 15.01 To 16 : IntLatCol = 4500
            Case 16.01 To 18 : IntLatCol = 5100
            Case 18.01 To 20 : IntLatCol = 5700
            Case 20.01 To 22 : IntLatCol = 6300
            Case 22.01 To 24 : IntLatCol = 6900
            Case 24.01 To 26 : IntLatCol = 7500
            Case 26.01 To 28 : IntLatCol = 8200
            Case 28.01 To 30 : IntLatCol = 8800
            Case 30.01 To 32 : IntLatCol = 9400
            Case 32.01 To 32.8 : IntLatCol = 9700
            Case 32.81 To 34 : IntLatCol = 10000
            Case 34.01 To 36 : IntLatCol = 10600
            Case 36.01 To 38 : IntLatCol = 11200
            Case 38.01 To 40 : IntLatCol = 11900
            Case 40.01 To 48 : IntLatCol = 14200
            Case Else : IntLatCol = 0
        End Select
    End Function
    Public Sub OkGenProp(ByRef iOKPRO As Short)
        ifrox = 0
        Form = Skippa(iF1, iF2)
        PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), NumBank, NumB))
        Form = Skippa(iF1, iF2)
        For i = 1 To 4
            PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Monitor.Motore.InputForms(1 - 1).prisposte(i))) : Next
        '------------------------------- OUT SEZIONE 1 ------------------------------
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Cust))
        Form = LineInput(iF1) : PrintLine(iF2, Mid(Form, 1, 127))
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Plant))
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Check))
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Data))
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Rev))
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Quot))
        Form = Skippa(iF1, iF2)
        'Unita' : uno o piu' items (Forzate/Indotte possibili sullo stesso banco)
        'Banco : Una o piu' unita' ( Un disegno proposal )
        'Item1Bank : primo item  del banco trattato
        '------------------------------- OUT SEZIONE 2 ------------------------------
        Risp(1) = ""
        For i = 1 To 11
            If Monitor.Motore.InputForms(2 - 1).Check1(i - 1) = 1 Then Risp(i + 1) = "SI" Else Risp(i + 1) = "NO"
        Next
395:    PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), UCase(Risp(2)), UCase(Risp(3)), UCase(Risp(4))))
        Form = LineInput(iF1) : PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), UCase(Risp(5)), UCase(Risp(6)), UCase(Risp(7))))
396:    For j = 1 To 5
            Form = LineInput(iF1)
            PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Risp(j + 7)))
        Next j
397:    Form = Skippa(iF1, iF2)
        If Monitor.Motore.InputForms.Count > 2 Then
            With Monitor.Motore.InputForms(3 - 1)
                IgapVent = Val(.prisposte(1))
                IgapLung = Val(.prisposte(2))
                MaxSizeBank = Val(.prisposte(3))
                LargBundle = Val(.prisposte(4))
                IHBundle = Val(.prisposte(5))
            End With
            If Monitor.Motore.InputForms(4 - 1).Check1(0) = 1 Then
                NoVisu = 1
            Else
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                NoVisu = 0
            End If
        End If
        With Monitor.Motore
            If Not .InputForms Is Nothing Then
                For i = .InputForms.Count To 1 Step -1
                    .InputForms(i - 1).close()
                    .InputForms.Remove(i - 1)
                Next
                .InputForms = Nothing
            End If
        End With
        '==================================================================
        Itm1Bank = 1
        For im = 1 To ItmsBank
            If Itemfat(im) = 1 Then GoTo 492
adds:       Imx = im + Itm1Bank - 1
            Nimx = NumItB(Imx)
            Itip = objDatBase.CVI(objDatBase.DatBase(2, 9, Nimx, ActivAlt(Nimx), itp, 0)) '-- cod. tipo testata
            IGapFasc(im) = TipTesta(Itip)
            Pitch = poll1 * objDatBase.CVS(objDatBase.DatBase(5, 2, Nimx, ActivAlt(Nimx), itp, 0)) '-- passo tubi
            Fialet = poll1 * objDatBase.CVS(objDatBase.DatBase(5, 3, Nimx, ActivAlt(Nimx), itp, 0)) '-- dia. alette
            If Fialet = 0 Then
                Fialet = poll1 * objDatBase.CVS(objDatBase.DatBase(5, 1, Nimx, ActivAlt(Nimx), itp, 0)) '-- dia. tubo
            End If
            Itip = objDatBase.CVI(objDatBase.DatBase(2, 9, Nimx, ActivAlt(Nimx), itp, 0)) '-- cod. tipo testata
            Lar(im) = IntFront(Nimx, ActivAlt(Nimx), Pitch, LargBundle)
            Aster(im) = LTrim(RTrim(objDatBase.DatBase(4, 19, Nimx, ActivAlt(Nimx), itp, 0)))
            kdx = Str(IGapFasc(im))
            kdx = kdx.PadLeft(4)
            Lun = SizeL(im) * pied1 + IgapLung 'supposto sempre in piedi
            Incl = objDatBase.CVI(objDatBase.DatBase(4, 16, Nimx, ActivAlt(Nimx), itp, 0)) '-- cod. slope
407:        Ialte = Islop(Incl, Lun)
408:        Ialte = Ialte + (NROWS(im) - 1) * Pitch * System.Math.Cos(3.141592 / 6) + Fialet + IHBundle
            Ialte = 10 * Int(Ialte / 10 + 1)
            Nboin = Str(objDatBase.CVI(objDatBase.DatBase(4, 6, Nimx, ActivAlt(Nimx), itp, 0)))
            Nboou = Str(objDatBase.CVI(objDatBase.DatBase(4, 7, Nimx, ActivAlt(Nimx), itp, 0)))
            Ndisp = Str(2 - objDatBase.CVI(objDatBase.DatBase(4, 5, Nimx, ActivAlt(Nimx), itp, 0)) Mod 2)
            bocc = Right(Nboin, 1) & Right(Nboou, 1) & Right(Ndisp, 1)
            iser = objDatBase.CVI(objDatBase.DatBase(2, 20, Nimx, ActivAlt(Nimx), itp, 0)) '-- cod. persiane-serrande
            iserStr = "NO" : If CDbl(iser) > 2 And CDbl(iser) < 9 Then iserStr = "SI"
            Steam = objDatBase.DatBase(2, 54, Nimx, ActivAlt(Nimx), itp, 0) '-- cod. steam coil YE NO
            stem = "NO" : If Steam = "YE" Then stem = "SI"
            nfass = "  "
            If Nstack(im) <> 0 Then
                nfass = Str(Nstack(im) + 1)
                nfass = nfass.PadLeft(3)
            End If
            For i = 1 To 11
                Archiv(i) = 0
            Next
            '------------------------------- OUT SEZIONE 3 ------------------------------
413:        Tit = "Dati items; Banco " & Str(NumBank)
            Dom(1) = "Item              :" : Risp(1) = Item(im)
            Dom(2) = "Numero fasci      :" : Risp(2) = Str(Nfasc(im))
            Dom(3) = "Lunghezza         :" : Risp(3) = Str(Lun)
            Dom(4) = "Larghezza         :" : Risp(4) = Str(Lar(im))
            Dom(5) = "Altezza           :" : Risp(5) = Str(Ialte)
            Dom(6) = "Codice Bocchelli  :" : Risp(6) = bocc
            Dom(7) = "Serrande          :" : Risp(7) = iserStr
            Archiv(7) = 49 : Archiv(8) = 49 : Archiv(11) = 49
            Dom(8) = "Steam Coils       :" : Risp(8) = stem
            Dom(9) = "N. Fasci sovrapp. :" : Risp(9) = nfass
            Dom(10) = "Dist. Fascio/SX   :" : Risp(10) = kdx
            Dom(11) = "Fascio sotto MFVC :"
            If Aster(im) = "*" Then
                Risp(11) = "SI"
            Else
                Risp(11) = "NO"
            End If
            If junk1 = MsgBoxResult.Yes Then Call LeggiItm1()
            If NoVisu = 1 Then If Not Monitor.Motore.InputDati(11, Tit, Dom, Risp, "", Archiv, dAiu) Then NoVisu = 0
            If Risp(11) = "SI" Then Risp(11) = "*" Else Risp(11) = " "
            PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 127), Risp(1), Val(Risp(2)), Val(Risp(3)), Val(Risp(4)), Val(Risp(5)), Risp(6), Risp(7), Risp(8), Risp(9), Val(Risp(10)), Risp(11)))
            Lar(im) = Val(Risp(4))
            IGapFasc(im) = Val(Risp(10))
            If iaddi = 1 Then iaddi = 0 : im = Imvec : GoTo 492
            For j = 1 To ItmsBank
                If Item(im) = ItemR(j) And Itemfat(j) = 2 Then
                    Imvec = im : im = j
                    Itemfat(j) = 1 : iaddi = 1
                    '                        PRINT "adds": u$ = INPUT$(1)  ??????????????????
                    GoTo adds
                End If
            Next  'aa

492:    Next  'bb

        Form = Skippa(iF1, iF2)
        For im = 1 To ItmsBank
            Imx = im + Itm1Bank - 1
            Nimx = NumItB(Imx)
            If Itemfat(im) = 0 Then GoTo 399
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVS. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Diavent = objDatBase.CVS(objDatBase.DatBase(7, 1, Nimx, ActivAlt(Nimx), itp, 0)) * pied1 'supposto sempre in piedi
            'DiaVent = Dfans(Im) * pied1
            If Unita(im) > 0 Then
                Call LeggiUnita()
                '------------------------------- OUT SEZIONE 4 ------------------------------
                For i = 1 To 13
                    Archiv(i) = 0
                Next
                Tit = "Dati Unità n°" & Str(im) & "; Banco n°" & Str(NumBank)
                Dom(1) = "Tiraggio          :" : Risp(1) = IndForz
                Dom(2) = "Numero unita'     :" : Risp(2) = Str(Unita(im))
                Dom(3) = "Int.frontale col. :" : Risp(3) = Ifr
                Dom(4) = "Trave             :"
                Risp(4) = Trav.PadRight(4)
                Dom(5) = "Num. ventilatori  :" : Risp(5) = Str(NFanUnit)
                Dom(6) = "Dia. ventilatori  :" : Risp(6) = Str(Diavent)
                Dom(7) = "Int. lat. colonne :"
                Risp(7) = Ila1.PadLeft(4)
                Dom(8) = "Int. lat. colonne :"
                Risp(8) = Ila2.PadLeft(4)
                Dom(9) = "Int. lat. colonne :"
                Risp(9) = Ila3.PadLeft(4)
                Dom(10) = "Ricircolo         :"
                Risp(10) = Rici.PadRight(4)
                Dom(11) = "Dist. unita' SX   :"
                Risp(11) = dist.PadLeft(6)
                Dom(12) = "Altezza. Colonne  :"
                Risp(12) = Height.ToString.PadRight(8)
                Dom(13) = "Camere d'aria     :" : Risp(13) = IndCam
                If junk1 = MsgBoxResult.Yes Then Call LeggiUnita1()
                If NoVisu = 1 Then If Not Monitor.Motore.InputDati(13, Tit, Dom, Risp, "", Archiv, dAiu) Then NoVisu = 0
                PrintLine(iF2, GlobalRoutines.FormatS(Mid(Form, 1, 125), Val(Risp(2)), Risp(3), Risp(4), Val(Risp(5)), Val(Risp(6)), Risp(7), Risp(8), Risp(9), Risp(10), Val(Risp(11)), Risp(1), Val(Risp(12)), Risp(13).PadRight(5)))
            End If
399:    Next  'cc
        Form = Skippa(iF1, iF2)
        '------------------------------- OUT SEZIONE 5 ------------------------------
        PrintLine(iF2, Form)
        PrintLine(iF2, "") : PrintLine(iF2, "") : PrintLine(iF2, Chr(12))
        FinePro()
        iOKPRO = iOK
    End Sub
    Private Sub LeggiUnita1()
        If im = 1 Then
            For j = 1 To 9
                If Not LeggiPRO(Riga) Then
                    NoPRO()
                    Exit Sub
                End If
            Next
        End If
        If Not LeggiPRO(Riga) Then
            NoPRO()
            Exit Sub
        End If
        If Len(Riga) < 125 Then
            NoPRO()
            Exit Sub
        End If
        Risp(2) = RTrim(Mid(Riga, 3, 2))
        If Val(Risp(2)) = 0 Then
            NoPRO() : Risp(2) = "1"
            Exit Sub
        End If
        Risp(4) = Mid(Riga, 29, 5)
        Risp(5) = Str(Val(Mid(Riga, 36, 4)))
        Risp(6) = Str(Val(Mid(Riga, 42, 10)))
        Risp(7) = GlobalRoutines.myStr(Int(Val(Mid(Riga, 54, 4))), 4, 0, True)
        Risp(8) = GlobalRoutines.myStr(Int(Val(Mid(Riga, 59, 4))), 4, 0, True)
        Risp(9) = GlobalRoutines.myStr(Int(Val(Mid(Riga, 66, 4))), 4, 0, True)
        Risp(10) = Mid(Riga, 77, 2)
        Risp(11) = GlobalRoutines.myStr(Int(Val(Mid(Riga, 88, 8))), 6, 0, True)
        Risp(1) = Mid(Riga, 100, 8)
        Risp(12) = GlobalRoutines.myStr(Int(Val(Mid(Riga, 111, 8))), 6, 0, True)
        Risp(13) = Mid(Riga, 121, 5)
    End Sub
    Private Sub LeggiUnita()
        FasUnit = Nfasc(im) / Unita(im)
        NtotFansUnit = Nfans(im) / Unita(im) : NFanUnit = NtotFansUnit
        ifrox = (Lar(im) + IGapFasc(im)) * FasUnit
        For j = 1 To ItmsBank
            If Item(im) = ItemR(j) And Itemfat(j) > 0 Then
                ifrox = (Lar(j) + IGapFasc(j)) * Nfasc(j) + ifrox
                Itemfat(j) = 0
            End If
        Next
        ifro2 = 10 * (Int(Diavent + IgapVent) / 10 + 1)
        ifro = ifrox : If ifro2 > ifro Then ifro = ifro2
        Ifr = Str(ifro)
        Ifr = Ifr.PadLeft(5)
        ILat = IntLatCol(SizeL(im)) : Ilat2 = ILat : If ILat = 0 Then Stop
        Ilat1 = 0 : Ilat3 = 0
        If NFanUnit <> 1 Then
            If NFanUnit = 2 Then
                Ilat0 = ILat \ NFanUnit : Ilat1 = Ilat0
                Ilat2 = ILat - Ilat1
            End If
            If NFanUnit >= 3 Then
                Ilat0 = ILat \ 3 : Ilat1 = Ilat0
                Ilat2 = Ilat0 : Ilat3 = ILat - Ilat1
            End If
        End If
        Ila1 = "" : Ila3 = ""
        If Ilat1 <> 0 Then Ila1 = LTrim(Str(Ilat1))
        If Ilat3 <> 0 Then Ila3 = LTrim(Str(Ilat1))
        Ila2 = LTrim(Str(Ilat2))
        Nric = objDatBase.CVI(objDatBase.DatBase(2, 19, Nimx, ActivAlt(Nimx), itp, 0))
        Rici = "" : If Nric > 2 And Nric < 11 Then Rici = "SI"
        Trav = "" : dist = ""
        'errore   forzato/indotto di banco invece che di unita
        IndFor = Mid(objDatBase.DatBase(4, 2, Nimx, ActivAlt(Nimx), itp, 0), 2, 1) '-- Tipo Unita'
        IndCam = Mid(objDatBase.DatBase(4, 2, Nimx, ActivAlt(Nimx), itp, 0), 3, 1)
        If IndCam = "S" Then IndCam = "TRANS" Else IndCam = "PANN."
        If IndFor = "F" Then IndForz = "FORZATO" Else IndForz = "INDOTTO"
        Nheight = objDatBase.CVI(objDatBase.DatBase(2, 5, Nimx, ActivAlt(Nimx), itp, 0)) '-- cod. montaggio
        Height = AltColo(IndFor, Nheight)
    End Sub
    Private Sub LeggiItm1()
        If im = 1 Then
            For j = 1 To 8
                If Not LeggiPRO(Riga) Then
                    NoPRO()
                    Exit Sub
                End If
            Next
        End If
        If Not LeggiPRO(Riga) Then
            NoPRO()
            Exit Sub
        End If
        If Len(Riga) < 101 Then
            NoPRO()
            Exit Sub
        End If
        Risp(1) = RTrim(Mid(Riga, 2, 18))
        Risp(2) = Str(Val(Mid(Riga, 21, 4)))
        Risp(3) = Str(Val(Mid(Riga, 28, 8)))
        Risp(4) = Str(Val(Mid(Riga, 37, 8)))
        Risp(5) = Str(Val(Mid(Riga, 45, 8)))
        Risp(6) = Mid(Riga, 55, 3)
        Risp(7) = Mid(Riga, 63, 2)
        Risp(8) = Mid(Riga, 70, 2)
        Risp(9) = Mid(Riga, 77, 3)
        Risp(10) = Str(Val(Mid(Riga, 88, 8)))
        Risp(11) = Mid(Riga, 101, 1)
    End Sub
    Public Sub FinePro()
        Dim i As Short
        If iOK = 0 Then PrintLine(iF2, "INTERROTTO dall'UTENTE")
        FileClose(iF2) : FileClose(iF3) : FileClose(iF4)
        If junk1 = MsgBoxResult.Yes Then
            FileClose(iF22) : io.file.delete("SCRA" & RTrim(job.contratto))
        End If
        FileClose(iF1)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If Not Monitor.Motore.InputForms Is Nothing Then
            For i = Monitor.Motore.InputForms.Count To 1 Step -1
                Monitor.Motore.InputForms(i - 1).close()
                Monitor.Motore.InputForms.Remove(i - 1)
            Next
            Monitor.Motore.InputForms = Nothing
        End If
        Apert.Enabled = True
    End Sub
    Public Function LeggiPRO(ByRef Riga As String) As Boolean
        On Error GoTo ErrPRO
        Riga = LineInput(iF22)
        LeggiPRO = Not (EOF(iF22) Or Left(Riga, 4) = "INTE")
        Exit Function
ErrPRO: LeggiPRO = False
    End Function

    Public Sub NotOKGenProp()
        iOK = 0
        FinePro()
    End Sub

    Public Sub NoPRO()
        Dim Riga As String
        Riga = "Il File 'Proposal' non è aggiornato o è corrotto." & vbCrLf
        Riga = Riga & "Esso verrà quindi ricostruito."
        MsgBox(Riga, MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
        junk1 = MsgBoxResult.No
        FileClose(iF22) : io.file.delete("SCRA" & RTrim(job.contratto))
    End Sub
End Module