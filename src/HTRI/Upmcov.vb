Option Strict Off
Option Explicit On
Imports System.math
Module modCover
    Private Archiv(20) As Short
    Private dAiu(20) As String
    Private nFin, xguar As Short
    Private Diam, X As Single
    Private BoltArea, PressDes, TempDes, Corr As Single
    Private AmmTestata, AmmTestata0, AmmBull, AmmBull0 As Single
    Private TOLL, LarghGrad, LarghGuarn, SpessGuarn As Single
    Private BasicWidth, EffWidth As Single
    Private ThkTopBtm, ThkTopBtmD, ArmH, ArmI As Single
    Private NumSetti As Integer
    Private GkSpanCorto, WgUnitario As Single
    Private BoltSpan, passoBReqCold, passoBReqHot As Single
    Private AltzTestata, LarghTestata, DiamTubi, PassoTubi As Single
    Private GkSpanLungo, GkPerim As Single
    Private iCov(20) As Single
    Private CHK, CO As String
    Private nto As Short
    Private CK, Prog, Testo As String
    Private iRevision As Short
    Private Mat, MATL As String
    Private iUnit As Short
    Private Passag As Short
    Private w As Single
    Private passoBReqAPI As Single
    Private CoeffZ As Single, AB As Single, Am1 As Single, Am2 As Single
    Private Wm1 As Single, Wm2 As Single, Wdesign As Single, AmmCover As Single, AmmCover0 As Single
    Private ContribPressCover As Single, ContribMomCover As Single, ThkReqASMECover As Single, ThkReqASMECover0 As Single
    Private n1 As Integer, ii As Integer, iLingua As Integer
    Private h3 As Single, x2 As Single, Y As Single
    Private m1 As Single, m2 As Single, m3 As Single, EffSald As Single
    Private m4 As Single, MaxCorrToll As Single, SpMembEnds As Single, SpBendEnds As Single
    Private SpBendEnds0 As Single, u As Single, ThkReqCUSTOMCover0 As Single, ThkReqCUSTOMCover As Single
    Private SpMembTSNonFor As Single, SpBendTSForata0 As Single, EffLig As Single, SpMembTSForata As Single
    Private U1 As Single, M8 As Single, U2 As Single
    Private SpBendTSNonFor As Single, M5 As Single, SpBendTSMezzeria As Single
    Private SpBendTSPerifFori As Single, SpessCover As Single, SpessTS As Single, SpessEnds As Single
    Private SpessSetti As Single, Perim As Single, passoBAdopted As Single
    Private n As Short
    Private i As Short
    Private dist As Single
    Private Gia As Boolean
    Private nrec, ifl, yy As Short
    Private Rdum As String
    Private iRec As Short
    Private Cod As String
    '------------------------------
    Private Bull, BU As String
    Private NumBull As Short
    Private mGask, YGask As Single
    Private GUARN As String
    Private iDBull, C4, C5 As Short
    Private Stringa(13) As String
    Private LungSt(30) As Short
    Private Risp1(10) As String
    Private Function BULLONI() As Boolean
        Dim Tit, Help As String
        Dim i, j As Short
        Dim Testo As String
        Dim icod, iRec As Short
        Dim itp As String
        Dim Stringa1(2) As String
        BULLONI = False
775:    'LOCATE 10, 1
        Stringa(1) = Mid(at1(500 + 1), 22, 8)
        Stringa(2) = Mid(at1(500 + 1), 38, 8)
        Stringa(3) = Mid(at1(500 + 1), 54, 5)
        Tit = Mid(at1(500 + 1), 1, 17) : Help = "" ' at1(56)
        If C4 <= 0 Or C4 > 3 Then C4 = MecData(iCassa).Ricorda(1 - 1)
        If C4 <= 0 Or C4 > 3 Then C4 = 1
        '#C4 = Monitor.Motore.Quale(3, Tit$, Stringa(), Help$, C4)
        FaseDati = 12
        nFin = 1
        Apert.Enabled = False
        Monitor.Motore.QualeM(nFin, 3, Tit, Stringa, Help, C4)
        Monitor.Motore.InputForms(1 - 1).Top = 40
        Monitor.Motore.InputForms(1 - 1).Left = 40 'Apert.Frames(1).Width
        AltroMat()
        For i = 1 To 8 : Stringa(i) = at1(500 + 14 + i) : Next
        'Stringa(1) = "M16"
        'Stringa(2) = "M18"
        'Stringa(3) = "M20"
        'Stringa(4) = "M22"
        'Stringa(5) = "5/8''"
        'Stringa(6) = "1''"
        'Stringa(7) = "3/4''"
        'Stringa(8) = "Altro"
        Tit = at1(500 + 23) ' "Diametro bulloni"
        If iDBull <= 0 Or iDBull > 8 Then iDBull = MecData(iCassa).Ricorda(2 - 1)
        If iDBull <= 0 Or iDBull > 8 Then iDBull = 1
        '#D = Monitor.Motore.Quale(8, Tit$, Stringa(), Help$, D)
        nFin = nFin + 1
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.QualeM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.QualeM(nFin, 8, Tit, Stringa, Help, iDBull)
        '988 PRINT at1(500+6)'"Diam.Bull. : M16   (1)   M18 (2)   M20   (3)   M22   (4)"
        '990 PRINT at1(500+7); : INPUT D'"             5/8'' (5)   1'' (6)   3/4'' (7)   Altro (8) : Codice "; D
        '#992 If D < 1 Or D > 8 Then Close #33: Exit Function
        '#MecData.Ricorda(2) = D
        '#996 AreBull
        TipBull()
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop While Not Monitor.Motore.InputForms Is Nothing
        If C4 = 0 Then BULLONI = False : Exit Function
        ' INPUT "Numero Totale Bulloni "; NumBull
        '#Dom$(1) = at1(500+24) '"Numero Totale Bulloni "
        '#NumBull = MecData.BF(3)   '?????????????????????
        '#Risp$(1) = Globalroutines.mystr(CSng(NumBull), 4, 0, True)
        'LungSt(1) = Len(Risp$(1))
        '#Do
        '#If Not Monitor.Motore.InputDati(1, "Numero bulloni", Dom$(), Risp$(), "", Archiv(), dAiu()) Then Close #33: Exit Function
        '#NumBull = Val(Risp$(1))
        '#Loop While NumBull = 0
        '#MecData.BF(3) = NumBull
        j = 1
        For i = 8 To 13
            Testo = at1(500 + i).PadRight(65)
            Stringa(j) = Mid(Testo, 13, 21 - j \ 10)
            Stringa(j + 1) = Mid(Testo, 41, 21 - (j + 1) \ 10)
            j = j + 2
        Next
        Stringa(13) = at1(500 + 22) ' "Altro"
        Tit = at1(500 + 25) ' "Materiale guarnizione"
        If C5 <= 0 Or C5 > 13 Then C5 = MecData(iCassa).Ricorda(3 - 1)
        If C5 <= 0 Or C5 > 13 Then
            If AddDistinta > 0 Then icod = objDatBase.CVI(objDatBase.DatBase(2, 22, Nrdit \ 2, 1, itp, 0)) Else icod = 1
            If icod < 11 Then
                C5 = icod - 1
            ElseIf icod = 12 Then
                C5 = 10
            Else
                C5 = 13
            End If
        End If
        '#C5 = Monitor.Motore.Quale(13, Tit$, Stringa(), Help$, C5)
        FaseDati = 13
        nFin = 1
        Apert.Enabled = False
        Monitor.Motore.QualeM(nFin, 13, Tit, Stringa, Help, C5)
        Monitor.Motore.InputForms(1 - 1).Top = 40
        Monitor.Motore.InputForms(1 - 1).Left = 40 'Apert.Frames(1).Width
        '830 PRINT at1(500+8)'"Mat. Guarn: COMPR. ASBESTOS FIBER(1)    COPPER/BRASS JACK.ASB(2)"
        '835 PRINT at1(500+9)'"            STEEL JACK. ASBESTOS (3)    MONEL JACK. ASBESTOS (4)"
        '840 PRINT at1(500+10)'"            4-6%CR JACK. ASBESTOS(5)    INOX JACKETED ASBEST.(6)"
        '845 PRINT at1(500+11)'"            COPPER/ BRASS SOLID  (7)    SOLID IRON           (8)"
        '850 PRINT at1(500+12)'"            SOLID MONEL or 4-6%CR(9)    SOLID INOX          (10)"
        '855 PRINT at1(500+13); : INPUT C5'"            Altro materiale     (11)    Introdurre il codice    "; C5
        '#860 If C5 < 1 Or C5 > 13 Then Close #33: Exit Function
        '#MecData.Ricorda(3) = C5
        '865 IF C5 = 13 GOTO 872
        GuarnCar()
        Risp(1) = GUARN : Dom(1) = at1(500 + 46) ' "Tipo guarnizione"
        Risp(2) = GlobalRoutines.myStr(mGask, 4, 2, False) : Dom(2) = at1(500 + 47) ' "Coefficiente m"
        Risp(3) = GlobalRoutines.myStr(YGask, 4, 2, False) : Dom(3) = at1(500 + 48) '"Carico Y [kg/mm2]"
        nFin = nFin + 1
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(nFin, 3, "Dati guarnizione", Dom, Risp, "", Archiv, dAiu)
        If Not Passag Then xguar = MecData(iCassa).Ricorda(4 - 1)
        Stringa1(1) = at1(500 + 49) ' "Guarniz. confinata nel coperchio"
        Stringa1(2) = at1(500 + 50) ' "Guarniz. confinata tra cop./flangia"
        xguar = MecData(iCassa).Ricorda(4 - 1)
        If xguar < 1 Or xguar > 2 Then xguar = 1
        nFin = nFin + 1
        Help = RadiceHelp & "::/CoverThrou.htm#ConfGuar"
        Monitor.Motore.QualeM(nFin, 2, at1(500 + 51), Stringa1, Help, xguar)
        Help = ""
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop While Not Monitor.Motore.InputForms Is Nothing
        '872 INPUT "Materiale Guarnizione        "; GUARN$
        '875 INPUT "Coefficiente M               "; mGask
        '880 INPUT "Carico Unit. Guarn. Y kg/mm2 "; YGask
        BULLONI = OKDati
        FileClose(33)
        If Not OKDati Then Exit Function
881:    FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        'iRec = AddMembrat: If iRec = 0 Then iRec = 1
        iRec = iCassa : If iRec = 0 Then iRec = 1
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(33, MecData(iCassa), iRec)
        FileClose(33)
        Exit Function
    End Function

    Private Function Dati(ByRef Passag As Short, ByRef Tit As String) As Boolean
        Dim i, ifl As Short
        Dim File As String
        Dati = True
        File = Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto)
        If Not IO.File.Exists(File) Then
            MsgBox(File & " non trovato")
            Dati = False
            Exit Function
        End If
        ifl = FreeFile()
        FileOpen(ifl, File, OpenMode.Input)
        For i = 1 To 16
            Risp(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        For i = 8 To 16 : Risp1(i - 7) = Risp(i) : Next
        If Not BULLONI() Then Dati = False : Exit Function
        Risp(1) = BU
        Risp(2) = GlobalRoutines.myStr(BoltArea, 8, 3, False)
        Risp(3) = Space(3) & Str(NumBull)
        Risp(4) = GlobalRoutines.myStr(AmmBull, 8, 3, False)
        Risp(5) = GlobalRoutines.myStr(AmmBull0, 8, 3, False)
        Risp(6) = GlobalRoutines.myStr(YGask, 8, 3, False)
        Risp(7) = GlobalRoutines.myStr(mGask, 8, 3, False)
        FileClose(3)
        For i = 1 To 9
            Dom(i) = Helpstringa(1238 + i - 1)
        Next
        If InStr(Tit, "STUD") > 0 Then
            Dom(8) = Helpstringa(1247) '"Spess top/btm min   [mm]"
            Dom(9) = Helpstringa(1248) '"Spess top/btm max   [mm]"
        End If
        If xguar = 2 Then
            '    Dom(1) = at1(500 + 53) '"Altezza grad.cop."
            '    Risp1(1) = Str(System.Math.Abs(Val(Risp1(1))))
        End If
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(9, Tit, Dom, Risp1, "", Archiv, dAiu, CarFissi:=True) _
                                     Then Dati = False : Exit Function
230:    'If xguar = 2 Then Risp1(1) = Str(-Val(Risp1(1)))
        For i = 8 To 16 : Risp(i) = Risp1(i - 7) : Next
        '        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        ifl = FreeFile()
240:    FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        For i = 1 To 16
            If i = 1 Then
                PrintLine(ifl, Risp(1))
            Else
                PrintLine(ifl, GlobalRoutines.FormatS("#####.###", Val(Risp(i))))
            End If
        Next
        PrintLine(ifl, Bull.PadRight(18))
        PrintLine(ifl, GUARN.PadRight(18))
        FileClose(ifl)
    End Function
    Private Function Decision(ByRef i As Short, ByRef Tit As String) As Boolean
        FileOpen(3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        i = 1
        Do
            Dom(i) = LineInput(3) : Dom(i) = LTrim(Dom(i))
            Risp(i) = ""
            If Left(Dom(1), 2) = ">>" Then
                ' LungSt(i) = 0
            ElseIf Left(Dom(i), 1) = ">" Then
                Risp(i) = Mid(Dom(i), 38, 10)
                Dom(i) = Mid(Dom(i), 2, 37)
                '   LungSt(i) = Len(Risp(i))
            End If
            If EOF(3) Then Exit Do
            i = i + 1
        Loop
        FileClose(3)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        If Not (Left(Dom(1), 2) = ">>") Then
            i = i + 1
            Dom(i) = at1(500 + 54) '"       Vuoi iterare ? (S/N)"
            Risp(i) = "N"
            'LungSt(i) = 1
        End If
        Monitor.Motore.Chiamante = Monitor
        Decision = Monitor.Motore.InputDati(i, Tit, Dom, Risp, "", Archiv, dAiu, CarFissi:=True)
    End Function
    Private Function Robert(ByRef iCassa As Short) As Boolean
        Dim Y As Boolean
        Dim j, iCass As Short
        Dim Cod As String
        Dim iUnit As Short
        Dim Passag, nrec As Short
        Dim R As String
        Robert = True
        iUnit = UnitMisu()
        Passag = False
        Prev = job.Contratto
Rif:
        ROBFOR(iCassa, iUnit, 0, Prev)
        If iCassa = 0 Then
            FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
            FileGet(33, MecData(0), 1)
            FileClose(33)
        End If
        If Not Dati(Passag, "Casse thrubolt") Then Robert = False : Exit Function
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData))
        iCass = iCassa : If iCass = 0 Then iCass = 1
        FilePut(33, MecData(iCassa), iCass)
        FileClose(33)
        ROBFO1(iCassa, 0)
        Y = Decision(nrec, at1(500 + 55)) '"Casse cover (thru)"
        If Not Y Then Robert = False : Exit Function
        If Left(Dom(1), 2) = ">>" Then GoTo Rif
        FileOpen(3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        For j = 1 To nrec - 1
            'If LungSt(j) > 0 Then Print #3, GlobalRoutines.FormatS(at2(54), Val(Risp$(j)))
            If LungSt(j) > 0 Then PrintLine(3, GlobalRoutines.FormatS("#####.###", Val(Risp(j))))
        Next
        FileClose(3)
        R = UCase(Risp(nrec))
        If R = "S" Then
            iCass = -iCassa
            If iCass = 0 Then iCass = -1
        Else
            iCass = iCassa
        End If
        ROBFIN(iCass, nCasse(TipoFas))
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        iCass = iCassa : If iCass = 0 Then iCass = 1
        FileGet(33, MecData(iCassa), iCass)
        FileClose(33)
        NumBull = MecData(iCassa).BF(3 - 1)
        If iCass < 0 Then GoTo Rif
        Cod = "" : If iCassa > 0 Then Cod = "a" & Str(iCassa)
        Registra(NewFUPM, iCassa, Cod)
    End Function
    Public Function Lingua() As Short
        If Monitor.Motore.Problem.Extension = ".PRV" Then
            If MecData(iCassa).St21.Trim = "" Then MecData(iCassa).St21 = actPRV.Linguaggi
        End If
        Select Case MecData(iCassa).St21
            Case "IT" : Return 1
            Case "IN" : Return 2
            Case "FR" : Return 3
            Case Else
                MecData(iCassa).UNIMIS = "IN"
                Return 2
        End Select
    End Function
    Public Function UnitMisu() As Short
        If Monitor.Motore.Problem.Extension = ".PRV" Then
            If MecData(iCassa).UNIMIS.Trim = "" Then MecData(iCassa).UNIMIS = actPRV.UnitaMisu
        End If
        Select Case MecData(iCassa).UNIMIS
            Case "ME" : Return 1
            Case "BR" : Return 2
            Case "SI" : Return 3
            Case Else
                MecData(iCassa).UNIMIS = "SI"
                Return 1
        End Select
    End Function
    Public Function CoverMain(ByRef IUNL As Short) As Boolean
        Dim Testo As String
        Dim ifl As Short
        CoverMain = True
        If Nrdit > 0 Then
            Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
            FileMec = RTrim(Monitor.Motore.Inizio.Workdir) & "\" & RTrim(job.Contratto) & Testo & ".MEC"
        Else
            '???FileMec = RTrim$(Monitor.Motore.Inizio.Workdir) + "\SALV00.MEC"
            '???job.contratto = "SALV"
        End If
        ifl = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
        FileGet(ifl, MecData(iCassa), Max(Abs(iCassa), 1))
        'TipoFas = IUNQ
        Select Case IUNL
            Case 1
                FileClose(ifl)
                CoverMain = COVER(iCassa)
            Case 2
                FileClose(ifl)
                CoverMain = Robert(iCassa)
        End Select
    End Function
    Public Function PRVValido(ByRef Arch As String) As Boolean
        Dim NumIt, NumRec As Short
        With objDatBase
            .Arch = Arch
            NumIt = .CVI(.Readreco(1, 43, 1))
            NumRec = .CVI(.Readreco(1, 45, 1))
        End With
        PRVValido = (NumIt >= 0) And (NumIt <= 30) And NumRec >= 0 And NumRec <= 1 + (2 + 4 * 5 + 2) * NumIt
    End Function
    Private Function COVER(ByRef iCassa As Short) As Boolean
        Dim Testo As String
        Dim n As Short
        '?????????????????
        'Dim AddLibrerie, LungPRE As Short
        '???????????????????
        Dim Help As String
        Dim m11 As Single
        '222 INPUT "Commessa     "; CO$
        'INPUT "Progettista  "; PROG$
        COVER = True
        Prog = MecData(iCassa).ENGR
        '**************************************
        '210 INPUT "No Check     "; CK$
        CK = MecData(iCassa).ICKNR
        '230 INPUT "Item         "; Testo
        Testo = MecData(iCassa).ITEMNO
        '250 INPUT "Revisione    "; iRevision
        iRevision = Val(MecData(iCassa).IREV)
        '410 INPUT "Press. di Progetto kg/cm2 "; A1
        PressDes = MecData(iCassa).P
        '420 INPUT "Temp.  di Progetto      C "; B8
        TempDes = MecData(iCassa).T
        '430 INPUT "Corrosione             mm "; A2
        Corr = MecData(iCassa).CA
        'Materiale per testata
        If MecData(iCassa).MATHOM = 1 Then
            AmmTestata = MecData(iCassa).SUG : AmmCover = MecData(iCassa).SUG
            AmmTestata0 = MecData(iCassa).Ammiss0(3) : AmmCover0 = MecData(iCassa).Ammiss0(3)
            If AmmTestata0 = 0 Then Beep() : iCassa = -iCassa : Exit Function
            Mat = MecData(iCassa).MATUG
            MATL = MecData(iCassa).MATUG
        Else
            'PRINT "LAVORI IN CORSO! UPMCO1": u$ = INPUT$(1)'STOP
            AmmTestata = MecData(iCassa).Ammiss(1)
            AmmTestata0 = MecData(iCassa).Ammiss0(1)
            Mat = MecData(iCassa).MATSH
            'Materiale per coperchio
            AmmCover = MecData(iCassa).Ammiss(3)
            AmmCover0 = MecData(iCassa).Ammiss0(3)
            MATL = MecData(iCassa).MATEN
        End If
        'materiale per bulloni----------------------------------------
        AmmBull = MecData(iCassa).BF(4 - 1) ' at temp
        AmmBull0 = MecData(iCassa).BF(5 - 1) 'room
        Bull = MecData(iCassa).MATTAP
        n = InStr(Bull, "|")
        If n > 1 Then Bull = Left(Bull, n - 1)
        'Bulloni
        iUnit = UnitMisu()
        'If iCassa > 0 Then Ling = actPRV.Linguaggi Else Ling = "IT"
        'Select Case Ling
        '    Case "IT" : iLingua = 1
        '    Case "IN" : iLingua = 3
        '    Case Else : iLingua = 2
        'End Select
        iLingua = Lingua()
        '--------------------------------------------------------------
Rifac:
        Passag = False
        Prev = job.Contratto
        ROBFOR(iCassa, iUnit, 1, Prev)
        If Not Dati(Passag, "Casse cover STUD") Then COVER = False : Exit Function
        ROBFO1(iCassa, 1)
        TOLL = MecData(iCassa).TOLLAV
        '----------------------------------------------------
        'XX = 5
        '962 LOCATE XX, 1: INPUT "Largh Gradino mm"; L
        '964 LOCATE XX, 28: INPUT "Largh Guarniz mm"; L1
        '966 LOCATE XX, 56: INPUT "Spess Guarniz mm"; S: XX = XX + 2
        LarghGrad = Val(Risp$(8)) : LarghGuarn = Val(Risp$(9)) : SpessGuarn = 3.5
        '        If l = 0 Then Ll = l1 Else Ll = l
        Dim l2 As Single = (LarghGuarn + SpessGuarn) / 2
        Dim l3 As Single = (LarghGuarn + LarghGrad) / 4
        BasicWidth = l2 : If l3 < l2 Then BasicWidth = l3
        If BasicWidth < 6.3 Then
            EffWidth = BasicWidth
        Else
            EffWidth = 2.5 * BasicWidth ^ 0.5
        End If
1000:   ThkTopBtm = Val(Risp$(16)) 'INPUT "Spess. Top/Btm ass.(45) "; T1
        ThkTopBtmD = Val(Risp$(15))
        ArmH = Val(Risp$(12)) 'INPUT "Distanza H   mm "; H
        ArmI = Val(Risp$(13)) 'INPUT "Distanza I   mm "; F
1018:   'INPUT "Num. Partizioni "; N
        NumSetti = MecData(iCassa).NS
1020:   For i = 1 To NumSetti
            iCov(i) = 0
        Next i
        For i = 1 To NumSetti : iCov(i) = MecData(iCassa).HX5(i) : Next i
        dist = ThkTopBtm - ArmH - ArmI
        GkSpanCorto = MecData(iCassa).HX3 + 2 * dist
        WgUnitario = EffWidth * YGask
        BoltSpan = GkSpanCorto + 2 * ArmH
        Gia = False
        Select Case NumSetti
            Case 0
                w = WgUnitario
            Case 1
                w = WgUnitario * (1 + (NumSetti - (iCov(1) + ArmH) / BoltSpan) / 6)
            Case Else
1050:           X = NumSetti * (iCov(1) + ArmH + dist)
                For i = 2 To NumSetti
                    X = X + iCov(i) * (NumSetti + 1 - i)
                Next i
                If X / NumSetti > BoltSpan / 2 And Not Gia Then
                    For i = 1 To NumSetti : iCov(i) = MecData(iCassa).HX5(i) : Next i
                    Gia = True
                    GoTo 1050
                End If
                w = WgUnitario * (1 + (NumSetti - X / BoltSpan) / 6)
        End Select
        passoBReqCold = BoltArea * AmmBull0 / w
        passoBReqHot = BoltArea * AmmBull * 100 / PressDes / (GkSpanCorto / 2 + 2 * EffWidth * mGask)
        AltzTestata = MecData(iCassa).HX3
        LarghTestata = MecData(iCassa).H
        '1098 INPUT "Numero File         "; N1
        'n1 = MecData(icassa).NROWS
        n1 = 0
        For ii = 1 To NumSetti + 1 : n1 = n1 + MecData(iCassa).Nfile(ii - 1) : Next
        '1100 PRINT "Possibilita' di Foratura "
        '1110 PRINT "Altezza    47.6  47.6  47.6  52.2  55    63.5  63.5  63.5  66      "
        '1120 PRINT "Diam.Tubo  25.4  25.4  25.4  25.4  25.4  31.8  38.1  38.1  38.1  Altro"
        '1130 PRINT "Passo      42.33 47.6  50.8  60.3  63.5  69.9  69.9  73    76.2    "
        '1140 PRINT "Codice      1     2     3     4     5     6     7     8     9     10"
        '1160 INPUT "Scegliere il codice di foratura "; E
        '1170 IF E < 1 OR E > 10 GOTO 1100
        '1172 IF E = 10 GOTO 1300
        '1175 GOTO 1190
        '1180 LOCATE XX, 1
        '1185 GOTO 1100
        '1190 ON E GOTO 1200, 1210, 1220, 1230, 1240, 1250, 1260, 1270, 1280
        '1200 H3 = 47.6: D1 = 25.4: P4 = 42.33: GOTO 1330
        '1210 H3 = 47.6: D1 = 25.4: P4 = 47.6: GOTO 1330
        '1220 H3 = 47.6: D1 = 25.4: P4 = 50.8: GOTO 1330
        '1230 H3 = 52.2: D1 = 25.4: P4 = 60.3: GOTO 1330
        '1240 H3 = 55: D1 = 25.4: P4 = 63.5: GOTO 1330
        '1250 H3 = 63.5: D1 = 31.8: P4 = 69.9: GOTO 1330
        '1260 H3 = 63.5: D1 = 38.1: P4 = 69.9: GOTO 1330
        '1270 H3 = 63.5: D1 = 38.1: P4 = 73: GOTO 1330
        '1280 H3 = 66: D1 = 38.1: P4 = 76.2: GOTO 1330
        DiamTubi = MecData(iCassa).DO_Renamed : h3 = MecData(iCassa).TVERT : PassoTubi = MecData(iCassa).TSP
        '1420 INPUT "Foratura Simmetrica (no=0)      "; T
        '1430 IF T THEN 1450
        '1440 PRINT : INPUT "Distanza x mm "; X2
        x2 = Val(Risp$(14))
        '1455:   Y = (ArmI + (ThkTopBtm - Corr - ArmH - LarghGuarn) / 2) * (ThkTopBtm / 4 - Corr / 4 - ArmI / 2 + ArmH / 2 + LarghGuarn / 4)
        '1460:   m3 = PressDes / 100 * (2 * mGask * EffWidth * ArmH + GkSpanCorto / 2 * ArmI + Y)
        '1465:   m1 = PressDes / 200 * (LarghTestata + Corr) ^ 2 - m3
        '1470:   m2 = PressDes / 100 * (GkSpanCorto ^ 2 / 8 + GkSpanCorto / 2 * ArmH + 2 * mGask * EffWidth * ArmH)
        'Momento alla base del Top/Btm
        m11 = PressDes / 200 * (LarghTestata + Corr) ^ 2 'spinta pressione sul Top/Btm
        m1 = m11 + m12(0) + m13(0) + m14(0) + m15(0)
        EffSald = MecData(iCassa).EWC
        '1480 IF N=0 GOTO
1485:   If w > 2 * WgUnitario Then GoTo 1520
1490:   If w > 11 / 6 * WgUnitario Then GoTo 1530
1495:   If w > 10 / 6 * WgUnitario Then GoTo 1540
1500:   If w > 9 / 6 * WgUnitario Then GoTo 1550
1505:   If w > 8 / 6 * WgUnitario Then GoTo 1560
1510:   If w > 7 / 6 * WgUnitario Then GoTo 1570
1515:   If w >= WgUnitario Then GoTo 1580
1520:   'Debug.Print " MG,W,X1 = "; m4; w; WgUnitario: Stop
1525:   FileClose(33) : Exit Function
1530:   m4 = w * (ArmH + iCov(1) + iCov(2) + iCov(3) + iCov(4) + iCov(5) + iCov(6)) - WgUnitario * (iCov(1) + 7 / 6 * iCov(2) + 4 / 3 * iCov(3) + 3 / 2 * iCov(4) + 10 / 6 * iCov(5) + 11 / 6 * iCov(6))
1535:   GoTo 1600
1540:   m4 = w * (ArmH + iCov(1) + iCov(2) + iCov(3) + iCov(4) + iCov(5)) - WgUnitario * (iCov(1) + 7 / 6 * iCov(2) + 4 / 3 * iCov(3) + 3 / 2 * iCov(4) + 10 / 6 * iCov(5))
1545:   GoTo 1600
1550:   m4 = w * (ArmH + iCov(1) + iCov(2) + iCov(3) + iCov(4)) - WgUnitario * (iCov(1) + 7 / 6 * iCov(2) + 4 / 3 * iCov(3) + 3 / 2 * iCov(4))
1555:   GoTo 1600
1560:   m4 = w * (ArmH + iCov(1) + iCov(2) + iCov(3)) - WgUnitario * (iCov(1) + 7 / 6 * iCov(2) + 4 / 3 * iCov(3))
1565:   GoTo 1600
1570:   m4 = w * (ArmH + iCov(1) + iCov(2)) - WgUnitario * (iCov(1) + 7 / 6 * iCov(2))
1575:   GoTo 1600
1580:   m4 = w * (ArmH + iCov(1)) - WgUnitario * iCov(1)
1585:   GoTo 1600
1590:   m4 = w * ArmH
1600:   MaxCorrToll = TOLL : If Corr > TOLL Then MaxCorrToll = Corr
        SpMembEnds = PressDes * (AltzTestata + 2 * Corr) / 200 / AmmTestata / EffSald
        SpBendEnds = (6 * Abs(m1) / AmmTestata / 1.5) ^ 0.5
        SpBendEnds0 = (6 * w * ArmH / AmmTestata0 / 1.5 / EffSald) ^ 0.5
        u = 2 * mGask * EffWidth + GkSpanCorto / 2
        ThkReqCUSTOMCover0 = (6 * m4 / 1.5 / AmmCover0) ^ 0.5
        ThkReqCUSTOMCover = (6 * PressDes * (GkSpanCorto ^ 2 / 8 + u * ArmH) / 100 / 1.5 / AmmCover) ^ 0.5
        EffLig = (PassoTubi - DiamTubi) / PassoTubi
        SpBendTSForata0 = (6 * w * ArmH / AmmTestata0 / 1.5 / EffLig) ^ 0.5
        SpMembTSNonFor = PressDes * (LarghTestata + Corr) / 100 / AmmTestata
        SpMembTSForata = PressDes * (LarghTestata + Corr) / 100 / AmmTestata / EffLig
        SpBendTSNonFor = (6 * Abs(m1) / AmmTestata / 1.5) ^ 0.5
        U1 = PressDes * (AltzTestata + 2 * Corr) ^ 2 / 800
        M8 = Abs(m1 - U1)
        Dim Spost As Single
        Spost = (AltzTestata + ThkTopBtmD) / 2
        M8 = Abs(m11 + m12(Spost) + m13(Spost) + m14(Spost) + m15(Spost) + U1)
        U2 = PressDes * (x2 + Corr) * (AltzTestata + Corr - x2) / 200
        M5 = Abs(m1 - U2)
        Spost = ThkTopBtmD / 2 + x2
        M5 = Abs(m11 + m12(Spost) + m13(Spost) + m14(Spost) + m15(Spost) + U2)
        SpBendTSMezzeria = (6 * M8 / AmmTestata / EffLig / 1.5) ^ 0.5
        SpBendTSPerifFori = (6 * M5 / AmmTestata / 1.5 / EffLig) ^ 0.5
        GkSpanLungo = MecData(iCassa).Largf + LarghGuarn
        CoeffZ = 3.4 - 2.4 * GkSpanCorto / GkSpanLungo
        If CoeffZ > 2.5 Then CoeffZ = 2.5
        GkPerim = 2 * (GkSpanCorto + GkSpanLungo + 4 * ArmH)
        Wm1 = PressDes / 100 * (4 * EffWidth * mGask * (GkSpanCorto + GkSpanLungo) + GkSpanCorto * GkSpanLungo)
        Wm2 = 2 * EffWidth * YGask * (GkSpanCorto + GkSpanLungo)
        Am1 = Wm1 / AmmBull
        Am2 = Wm2 / AmmBull0
        '2300 INPUT "Numero Totale Bulloni "; a(10)
        AB = NumBull * BoltArea
        '-----------------------------------------------
        If AB < Am1 Or AB < Am2 Then
            Help$ = "AREA TOTALE BULLONERIA: " + GlobalRoutines.myStr(AB, 6, 0, False) + " mm2|"
            Help$ = Help$ + "AREE RICHIESTE: " + GlobalRoutines.myStr(Am1, 6, 0, False) + "," + GlobalRoutines.myStr(Am2, 6, 0, False) + "|"
            Help$ = Help$ + "   Cambia i dati!"
            Help = Monitor.Motore.Inizio.ConvertiCr(Help)
            If Not MsgBox(Help$, vbOKCancel + vbInformation, "ISA") = vbCancel Then GoTo Rifac
            FileClose(33) : Exit Function
        End If
        '-----------------------------------------
        Wdesign = (AB + Am2) * AmmBull0 / 2 : If Am1 > Am2 Then Wdesign = (AB + Am1) * AmmBull0 / 2
        ContribPressCover = CoeffZ * 0.3 * PressDes / (100 * AmmCover)
        ContribMomCover = 6 * Wm1 * ArmH / (AmmCover * GkPerim * GkSpanCorto ^ 2)
        ThkReqASMECover = GkSpanCorto * Sqrt(ContribPressCover + ContribMomCover)
        ThkReqASMECover0 = GkSpanCorto * Sqrt(6 * Wdesign * ArmH / (AmmCover0 * GkPerim * GkSpanCorto ^ 2))
        Dim SpessCover1 As Single = GlobalRoutines.Massimo(ThkReqCUSTOMCover0 + TOLL, ThkReqCUSTOMCover + MaxCorrToll, ThkReqASMECover + TOLL, ThkReqASMECover0 + MaxCorrToll)
        Dim SpessTS1 As Single = GlobalRoutines.Massimo(SpBendTSForata0 + Corr, SpBendTSNonFor + SpMembTSNonFor + Corr, SpBendTSMezzeria + SpMembTSForata + Corr, SpBendTSPerifFori + SpMembTSForata + Corr)
        Dim SpessEnds1 As Single = GlobalRoutines.Massimo(SpBendEnds0 + Corr, SpBendEnds + SpMembEnds + Corr)
        Dim SpessSetti1 As Single = ReadLib(23, 1) '+ 2 * Corr
        SpessEnds = MecData(iCassa).SP(1 - 1)
        SpessCover = MecData(iCassa).SP(4 - 1)
        SpessTS = MecData(iCassa).SP(2 - 1)
        SpessSetti = MecData(iCassa).SP(3 - 1)
        Perim = 2 * (GkSpanCorto + GkSpanLungo)
        passoBAdopted = Perim / NumBull
        passoBReqAPI = 2 * Diam + 6 * Max(SpessCover, SpessCover1) / (mGask + 0.5)
        Dim Passoreq As Single = GlobalRoutines.Minimo(passoBReqCold, passoBReqHot, passoBReqAPI)
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        Print(ifl, at1(500 + 57) & Space(1)) '"Spessore Coperchio mm ";
        PrintLine(ifl, GlobalRoutines.FormatS(at1(500 + 58), ThkReqCUSTOMCover0 + TOLL, ThkReqCUSTOMCover + MaxCorrToll, ThkReqASMECover, ThkReqASMECover0, Space(1)))
        PrintLine(ifl)
        PrintLine(ifl, at1(500 + 59) & Space(1)) '"Spess. Piastra Tub mm ";
        PrintLine(ifl, GlobalRoutines.FormatS(at1(500 + 58), SpBendTSForata0 + Corr, SpBendTSNonFor + SpMembTSNonFor + Corr, SpBendTSMezzeria + SpMembTSForata + Corr, SpBendTSPerifFori + SpMembTSForata + Corr, Space(1)))
        PrintLine(ifl)
        Print(ifl, at1(500 + 60) & Space(1)) '"Spess. Top,Btm,End = ";
        PrintLine(ifl, GlobalRoutines.FormatS(at1(500 + 61), SpBendEnds0 + Corr, SpBendEnds + SpMembEnds + Corr, Space(1)))
        PrintLine(ifl)
        PrintLine(ifl, at1(500 + 62) & Space(1)) '"Passi Bull. (Freddo)  (Caldo)  (API 661) "
        PrintLine(ifl, GlobalRoutines.FormatS(at1(500 + 63), Chr(32), passoBReqCold, passoBReqHot, passoBReqAPI))
        PrintLine(ifl)
        Testo = GlobalRoutines.myStr(SpessTS1, 7, 2, False) & GlobalRoutines.myStr(SpessTS, 7, 2, False)
        PrintLine(ifl, at1(500 + 64) & Testo) '"> SPESSORE PIASTRA TUBIERA"
        Testo = GlobalRoutines.myStr(SpessCover1, 7, 2, False) & GlobalRoutines.myStr(SpessCover, 7, 2, False)
        PrintLine(ifl, at1(500 + 65) & Space(10) & Testo) '"> SPESSORE COVER          "
        Testo = GlobalRoutines.myStr(SpessEnds1, 7, 2, False) & GlobalRoutines.myStr(SpessEnds, 7, 2, False)
        PrintLine(ifl, at1(500 + 66) & Space(11) & Testo) '"> SPESSORE ENDS           "
        Testo = GlobalRoutines.myStr(SpessSetti1, 7, 2, False) & GlobalRoutines.myStr(SpessSetti, 7, 2, False)
        PrintLine(ifl, at1(500 + 67) & Space(10) & Testo) '"> SPESSORE SETTI          "
        Testo = GlobalRoutines.myStr(Passoreq, 7, 2, False) & GlobalRoutines.myStr(passoBAdopted, 7, 2, False)
        PrintLine(ifl, at1(500 + 68) & Space(11) & Testo) '"> PASSO BULLONI           "
        FileClose(ifl)
2642:   yy = Decision(nrec, at1(500 + 56)) ' "Casse cover (stud)"
        If yy = 0 Then Return False
        SpessTS = Val(Risp$(nrec - 5))
        SpessCover = Val(Risp$(nrec - 4))
        SpessEnds = Val(Risp$(nrec - 3))
        SpessSetti = Val(Risp$(nrec - 2))
        passoBAdopted = Val(Risp$(nrec - 1))
        Rdum = UCase(Risp(nrec))
2644:   NumBull = Perim / passoBAdopted
        If iDBull = 8 Then Stop 'dovrebbe essere impossibile
        MecData(iCassa).MATGUAR = GUARN
        MecData(iCassa).MATTAP = Bull & "|" & BU ' Maeriale | Diametro
        MecData(iCassa).HE = passoBAdopted 'Passo bulloni
        MecData(iCassa).SP(1 - 1) = SpessEnds
        MecData(iCassa).SP(4 - 1) = SpessCover
        MecData(iCassa).SP(2 - 1) = SpessTS
        MecData(iCassa).SP(3 - 1) = SpessSetti
        MecData(iCassa).BF(3 - 1) = NumBull
        MecData(iCassa).TK(3 - 1) = x2
        MecData(iCassa).TK(4 - 1) = ThkTopBtmD
        MecData(iCassa).TK(5 - 1) = ThkTopBtm
        iRec = iCassa : If iRec = 0 Then iRec = 1
        FileClose(33)
        FileOpen(33, FileMec, OpenMode.Random, , , Len(MecData(0)))
        FilePut(33, MecData(iCassa), iRec)
        FileClose(33)
        If Risp(nrec) = "S" Then GoTo Rifac
        'If iCassa <= 1 Then
        'If iLingua = 2 Then AddLibrerie = 2 * AddLibrerie 'N. pag
        ' LungPRE = iLingua '??????????????
        'Else '??????????????
        'iLingua = LungPRE '?????????????
        'End If '????????????????
        'npa = iRec
        'If iLingua = 2 Then npa = 2 * npa - 1
        nto = nCasse(TipoFas) ': If iLingua = 2 Then nto = nto * 2
5000:   ' INIZIO STAMPA
        ' If iCassa <= 1 Then
        'If Len(Dir(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))) > 0 Then IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        'FileOpen(33, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        'Else
        'FileOpen(33, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Append)
        'End If
2700:   If iLingua = 1 Then
            ifl = FreeFile()
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\TESTIC1n.TXT", OpenMode.Input, , OpenShare.Shared)
            Call Stampa(ifl)
        ElseIf iLingua = 2 Then
            ' INIZIO STAMPA INGLESE
            MsgBox("Lingua inglese non ancora implementata")
            'FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\IT\TESTIC2.TXT", OpenMode.Input, , OpenShare.Shared)
            'Call Stampa(ifl)
        End If
        FileClose(33) : FileClose(ifl)
        'Cod = "" : If iCassa > 0 Then Cod = "a" & Str(iCassa)
        'Registra(NewFUPM, iCassa, "a")
    End Function
    Private Function m12(ByVal Spost As Single) As Single
        m12 = -PressDes / 100 * (ThkTopBtm - ArmH - ArmI - Corr) * ( _
              (ThkTopBtm - Corr + ArmH + ArmI - ThkTopBtmD) / 2 - Spost) 'spinta pressione sotto guarnizione
    End Function
    Private Function m13(ByVal Spost As Single) As Single
        m13 = -PressDes / 100 * (ArmI + ArmH - ThkTopBtmD / 2 - Spost) * 2 * mGask * EffWidth 'spinta guarnizione
    End Function
    Private Function m14(ByVal Spost As Single) As Single
        m14 = PressDes / 100 * (ArmI - ThkTopBtmD / 2 - Spost) * (GkSpanCorto / 2 + 2 * mGask * EffWidth) ' Tiro bulloni
    End Function
    Private Function m15(ByVal Spost As Single) As Single
        m15 = PressDes / 100 * (ThkTopBtm - ThkTopBtmD) * ((ThkTopBtm + ThkTopBtmD - 2 * Corr) / 2 - ThkTopBtmD / 2 - Spost)
    End Function
    Sub Stampa(ByRef ifl As Short)
        Dim FileStam As String = Monitor.Motore.Inizio.DiscoTem & job.Contratto & "Stampa"
        If iCassa <= 1 Then
            Monitor.Motore.PrepRapp(FileStam)
            LegacyReportCompatibility.SetTotalPages(Monitor.Motore, nto)
        End If
        LegacyReportCompatibility.Testata(Monitor.Motore, True)
        With Monitor.Motore.Problem
            Dim Riga, Rig1 As String
            '   Riga = LineInput(ifl) : .printa( Riga) ' "* Program name: STUD    rev.1 (Date: Aug-18-1995) *"
            '   Rig1 = Monitor.Motore.Inizio.Firma()
            '5030:       Riga = LineInput(ifl) : .printa( GlobalRoutines.FormatS(Riga, Rig1)) '"*** F B M - HUDSON ITALIANA S.p.A. ***"
            '5040:       Riga = LineInput(ifl) : .printa( Riga) '"======================================"
            '5060:       PrintLine(33)
            CHK = Monitor.Motore.Problem.Doc
            CO = Trim(job.Contratto)
            If Len(CHK) = 0 Then CHK = Space(10)
5080:       Riga = LineInput(ifl)
            .Printa(GlobalRoutines.FormatS(Riga, CHK, CO))
            Riga = LineInput(ifl) ' .Printa(GlobalRoutines.FormatS(Riga, npa, nto + 1, DateString))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Prog, iRevision))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, MecData(iCassa).ITEMNO, MecData(iCassa).HEADER))
5160:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Mat, AmmTestata0, AmmTestata))
5180:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, MATL, AmmCover0, AmmCover))
5200:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Bull, AmmBull0, AmmBull))
5212:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, GUARN, YGask))
5218:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, mGask))
5230:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, PressDes, TempDes))
5260:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Corr, TOLL, n1, NumSetti))
5300:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, EffSald, AltzTestata))
5340:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, EffLig, LarghTestata))
5380:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, GkSpanLungo))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, GkSpanCorto))
5420:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, DiamTubi, ArmH))
5460:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, PassoTubi, ArmI))
            If LarghGrad > 0 Then
5500:           Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, LarghGrad))
                Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, ThkTopBtm, ThkTopBtmD))
5510:           Riga = LineInput(ifl)
            Else
                Riga = LineInput(ifl)
                Riga = LineInput(ifl) : .Printa(Riga)
            End If
5520:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, BU, LarghGuarn))
5562:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, BoltArea, SpessGuarn))
5580:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, NumBull, EffWidth))
5600:       Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, CoeffZ, 0.3))
            Riga = LineInput(ifl)
            Rig1 = LineInput(ifl)
5630:       n = MecData(iCassa).NS
            If n = 0 Then GoTo 5720
5640:       .Printa(GlobalRoutines.FormatS(Left(Riga, 21), 1))
5650:       For i = 2 To n : .Printa(GlobalRoutines.FormatS(Mid(Riga, 15, 7), i)) : Next i
            .Printa("\par ")
            .Printa(GlobalRoutines.FormatS(Left(Rig1, 21), iCov(1)))
            For i = 2 To n : .Printa(GlobalRoutines.FormatS(Mid(Rig1, 15, 7), iCov(i))) : Next i
5720:       .Printa("\par \par ")
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Wm1, Wdesign))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Wm2, GkPerim))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Am1, w))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, Am2, M8))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, AB, m1))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, m4, M5))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, passoBReqCold, passoBReqHot, passoBReqAPI, passoBAdopted))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, SpBendTSForata0, Corr, SpBendTSForata0 + Corr, SpessTS))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, SpBendTSNonFor, SpMembTSNonFor, Corr, SpBendTSNonFor + SpMembTSNonFor + Corr, SpessTS))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, SpBendTSMezzeria, SpMembTSForata, Corr, SpBendTSMezzeria + SpMembTSForata + Corr, SpessTS))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, SpBendTSPerifFori, SpMembTSForata, Corr, SpBendTSPerifFori + SpMembTSForata + Corr, SpessTS))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, SpBendEnds0, Corr, SpBendEnds0 + Corr, ThkTopBtmD))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, SpBendEnds, SpMembEnds, Corr, SpBendEnds + SpMembEnds + Corr, ThkTopBtmD))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, ThkReqCUSTOMCover0, TOLL, ThkReqCUSTOMCover0 + TOLL, SpessCover))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, ThkReqCUSTOMCover, MaxCorrToll, ThkReqCUSTOMCover + MaxCorrToll, SpessCover))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, ThkReqASMECover, MaxCorrToll, ThkReqASMECover + MaxCorrToll, SpessCover))
            Riga = LineInput(ifl) : .Printa(GlobalRoutines.FormatS(Riga, ThkReqASMECover0 - MaxCorrToll, MaxCorrToll, ThkReqASMECover0, SpessCover))
            Riga = LineInput(ifl)
            If n = 0 Then GoTo 6220
6200:       .Printa(GlobalRoutines.FormatS(Riga, SpessSetti))
6220:       .Printa("\par \par ")
            If iCassa = nCasse(TipoFas) Or TipoFas = 0 Then
                .Printa("\page ")
                .copia(Monitor.Motore.Inizio.Archdir + "\Explanatory.rtf")
                .FineRapp()
                Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto", "AsmeVip")
                Application.DoEvents()
                Dim Documento As StubW2000.clsSW2000 = New StubW2000.clsSW2000
                Documento.SuperStampa(FileStam, Monitor.Motore.Inizio.VersOffice, True)
                Monitor.Motore.ProgrAmmazza()
                Documento.Visible = True
                Dim NewFile As String = IO.Path.GetFullPath(FileMec) + "/" + IO.Path.GetFileNameWithoutExtension(FileMec) + ".DOC"
                Dim Ris As System.Windows.Forms.DialogResult
                Do
                    Ris = DialogResult.OK
                    Try
                        Documento.sSaveAs(NewFile)
                    Catch ex As Exception
                        Testo = "Accesso negato al file " & NewFile & "." & vbCrLf
                        Testo = Testo & " Verificare se esso è in uso presso Winword" & vbCrLf
                        Testo = Testo & " ed eventualmente chiuderlo." & vbCrLf
                        Testo = Testo & "(" & ex.Message & ")"
                        Ris = MessageBox.Show(Testo, "ISA - Messaggi d'errore", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
                    End Try
                Loop While Ris = DialogResult.Retry
            End If
        End With
    End Sub
    Public Sub AltroMat()
        Dim i As Short
        AmmissBull()
        Risp(1) = Bull
        Risp(2) = GlobalRoutines.myStr(AmmBull, 4, 2, False)
        Risp(3) = GlobalRoutines.myStr(AmmBull0, 4, 2, False)
        For i = 1 To 3
            Dom(i) = at1(500 + 2 + i)
            '   LungSt(i) = Len(Risp$(i))
        Next
        nFin = nFin + 1
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(nFin, 3, "Ammissibili bulloni", Dom, Risp, "", Archiv, dAiu)
        With CObj(Monitor.Motore.InputForms(2 - 1))
            .Text1(0).Enabled = C4 > 2
            .Text1(1).Enabled = C4 > 2
            .Text1(2).Enabled = C4 > 2
            .prisposte(1) = Bull
            .prisposte(2) = GlobalRoutines.myStr(AmmBull, 4, 2, False)
            .prisposte(3) = GlobalRoutines.myStr(AmmBull0, 4, 2, False)
        End With
    End Sub
    Private Sub AmmissBull()
        ' SOLLECITAZIONI AMMMISSIBILI BULLONI
        Dim n As Short
        If MecData(iCassa).T > 343 Then
            AmmBull0 = 0 : AmmBull = 0
        Else
            Select Case C4
                Case 1
                    AmmBull0 = 17.5768
                    AmmBull = 17.5768
                    Bull = "A-193 B7"
                Case 2
                    AmmBull0 = 17.5768
                    AmmBull = 17.5768
                    Bull = "A-320 L7"
                Case Else
                    AmmBull0 = MecData(iCassa).BF(5 - 1)
                    AmmBull = MecData(iCassa).BF(4 - 1)
                    Bull = MecData(iCassa).MATTAP
                    n = InStr(Bull, "|")
                    If n > 1 Then Bull = Left(Bull, n - 1)
            End Select
        End If
        MecData(iCassa).BF(4 - 1) = AmmBull ' at temp
        MecData(iCassa).BF(5 - 1) = AmmBull0 'room
        MecData(iCassa).MATTAP = Bull
    End Sub

    Private Sub AreBull()
        ' AREE NOCCIOLO BULLONI
        'ON D GOTO 12420, 12430, 12440, 12450, 12460, 12470, 12480
        If iDBull > 0 And iDBull < 8 Then
            BU = RTrim(Left(at1(500 + 25 + iDBull), 10))
            BoltArea = Val(Mid(at1(500 + 25 + iDBull), 11, 10))
            Diam = Val(Mid(at1(500 + 25 + iDBull), 21, 10))
            '12420 S1 = 141: Diam! = 16: BU$ = at1(500+26): GOTO 12500' "M 16"
            '12430 S1 = 171: Diam! = 18: BU$ = at1(500+27): GOTO 12500'"M 18"
            '12440 S1 = 220: Diam! = 20: BU$ = at1(500+28): GOTO 12500' "M 20"
            '12450 S1 = 276: Diam! = 22: BU$ = at1(500+29): GOTO 12500'"M 22"
            '12460 S1 = 131: Diam! = 15.875: BU$ = at1(500+30): GOTO 12500'"Inch 5/8"
            '12470 S1 = 357: Diam! = 25.4: BU$ = at1(500+31): GOTO 12500'"Inch 1"
            '12480 S1 = 196: Diam! = 19.05: BU$ = at1(500+32)' "Inch 3/4"
        Else
            BU = MecData(iCassa).MATTP
            BoltArea = MecData(iCassa).BF(2 - 1)
            Diam = 0
        End If
    End Sub
    Private Sub GuarnCar()
        ' CARICHI GUARNIZIONI STANDARD
        ' ON C5 GOTO 12210, 12215, 12220, 12225, 12230, 12235, 12240, 12245, 12250, 12255, 12256, 12257
        '12210 mGask = 2: YGask = 1.12: GOTO 12300 ': GUARN$ = "COMPR. ASBESTOS FIBER": GOTO 12300
        '12215 mGask = 3.5: YGask = 4.57: GOTO 12300 ': GUARN$ = "COPPER/BRASS JACK.ASB": GOTO 12300
        '12220 mGask = 3.75: YGask = 5.34: GOTO 12300 ': GUARN$ = "STEEL JACK. ASBESTOS": GOTO 12300
        '12225 mGask = 3.5: YGask = 5.62: GOTO 12300 ': GUARN$ = "MONEL JACK. ASBESTOS": GOTO 12300
        '12230 mGask = 3.75: YGask = 6.33: GOTO 12300 ': GUARN$ = "4-6%CR JACK. ASBESTOS": GOTO 12300
        '12235 mGask = 3.75: YGask = 6.33: GOTO 12300 ': GUARN$ = "INOX JACKETED ASBEST.": GOTO 12300
        '12240 mGask = 4.75: YGask = 9.140001: GOTO 12300 ': GUARN$ = "COPPER BRASS SOLID": GOTO 12300
        '12245 mGask = 5.5: YGask = 12.65: GOTO 12300 ': GUARN$ = "SOLID IRON": GOTO 12300
        '12250 mGask = 6: YGask = 15.33: GOTO 12300 ': GUARN$ = "SOLID MONEL or 4-6%": GOTO 12300
        '12255 mGask = 6.5: YGask = 18.28: GOTO 12300 ': GUARN$ = "SOLID INOX"
        '12256 mGask = 2!: YGask = 1.7581: GOTO 12300   ': GUARN$ = "MET.REINF.EXP.GRAPH."
        '12257 mGask = 2.25: YGask = 1.75: GOTO 12300 ': GUARN$ = "CAF"
        If C5 < 13 And C5 > 0 Then
            GUARN = Stringa(C5)
            mGask = Val(Left(at1(500 + 32 + C5), 6))
            YGask = Val(Mid(at1(500 + 32 + C5), 7, 8))
        Else
            GUARN = MecData(iCassa).MATGUAR
            YGask = MecData(iCassa).DF(1 - 1)
            mGask = MecData(iCassa).DF(2 - 1)

        End If
    End Sub
    Public Sub BullOpt(ByRef f As Short, ByRef i As Short)
        Select Case f
            Case 1 'selezione mat bull
                C4 = i
                MecData(iCassa).Ricorda(1 - 1) = C4
                AmmissBull()
                With CObj(Monitor.Motore.InputForms(2 - 1))
                    .Text1(0).Enabled = C4 > 2
                    .Text1(1).Enabled = C4 > 2
                    .Text1(2).Enabled = C4 > 2
                End With
            Case 3 'DN bullone
                iDBull = i
                MecData(iCassa).Ricorda(2 - 1) = iDBull
                AreBull()
                With CObj(Monitor.Motore.InputForms(4 - 1))
                    .prisposte(1) = BU
                    .prisposte(2) = GlobalRoutines.myStr(BoltArea, 6, 2, False)
                    .Text1(0).Enabled = iDBull > 7
                    .Text1(1).Enabled = iDBull > 7
                End With
        End Select
    End Sub
    Public Sub CancelBull()
        C4 = 0
        FileClose(33)
        MecData(iCassa).Ricorda(1 - 1) = C4
    End Sub
    Public Sub CancelGuar()
        C5 = 0
        FileClose(33)
        MecData(iCassa).Ricorda(3 - 1) = C5
    End Sub

    Public Sub OkBull()
        With CObj(Monitor.Motore.InputForms(2 - 1))
            Bull = .prisposte(1)
            AmmBull = Val(.prisposte(2))
            AmmBull0 = Val(.prisposte(3))
            MecData(iCassa).BF(4 - 1) = AmmBull
            MecData(iCassa).BF(5 - 1) = AmmBull0
            MecData(iCassa).MATTAP = Bull
        End With
        With CObj(Monitor.Motore.InputForms(4 - 1))
            BU = .prisposte(1)
            BoltArea = Val(.prisposte(2))
            MecData(iCassa).MATTP = BU
            MecData(iCassa).BF(2 - 1) = BoltArea
            NumBull = Val(.prisposte(3))
            MecData(iCassa).BF(3 - 1) = NumBull
        End With
    End Sub
    Public Sub OkGuar()
        With CObj(Monitor.Motore.InputForms(2 - 1))
            GUARN = .prisposte(1)
            mGask = Val(.prisposte(2))
            YGask = Val(.prisposte(3))
            MecData(iCassa).MATGUAR = GUARN
            MecData(iCassa).DF(1 - 1) = YGask
            MecData(iCassa).DF(2 - 1) = mGask
        End With
    End Sub
    Private Sub TipBull()
        AreBull()
        Dom(1) = at1(500 + 44) '"Tipo Bullone      "
        Risp(1) = BU
        Dom(2) = at1(500 + 45) ' "Area Nocciolo mm2 "
        Risp(2) = GlobalRoutines.myStr(BoltArea, 6, 2, False)
        Dom(3) = at1(500 + 24) '"Numero Totale Bulloni "
        NumBull = MecData(iCassa).BF(3 - 1) '?????????????????????
        Risp(3) = GlobalRoutines.myStr(CSng(NumBull), 4, 0, True)
        'LungSt(1) = Len(Risp$(1)): LungSt(2) = Len(Risp$(2))
        '#If Not Monitor.Motore.InputDati(2, "Geometria bulloni", Dom$(), Risp$(), "", Archiv(), dAiu()) Then Close #33: Exit Function
        nFin = nFin + 1
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(nFin, 3, "Geometria bulloni", Dom, Risp, "", Archiv, dAiu)
        With CObj(Monitor.Motore.InputForms(4 - 1))
            .Text1(0).Enabled = iDBull > 7
            .Text1(1).Enabled = iDBull > 7
        End With
        '#BU$ = Risp$(1)
        '#S1 = Val(Risp$(2))
    End Sub

    Public Sub GuarOpt(ByRef f As Short, ByRef i As Short)
        Select Case f
            Case 1
                C5 = i
                MecData(iCassa).Ricorda(3 - 1) = C5
                GuarnCar()
                With CObj(Monitor.Motore.InputForms(2 - 1))
                    .prisposte(1) = GUARN
                    .prisposte(2) = GlobalRoutines.myStr(mGask, 2, 2, False)
                    .prisposte(3) = GlobalRoutines.myStr(YGask, 3, 2, False)
                    .Text1(0).Enabled = C5 = 13
                    .Text1(1).Enabled = C5 = 13
                    .Text1(2).Enabled = C5 = 13
                End With
            Case 3
                xguar = i
                MecData(iCassa).Ricorda(4 - 1) = xguar
                Passag = True
        End Select
    End Sub
End Module