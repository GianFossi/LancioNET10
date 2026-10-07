Option Strict Off
Option Explicit On
Imports System.Math
Module modCurva
    Public Tipo As String
    Public Item, Prev, File As String
    Public corda As Single
    Public ITOTAL, Npal, UNITA As Short
    Public Tippal As String
    Public TOut, Angle, Diam As Single
    Public Dens, StatP As Single
    Public idPala As Integer
    Public Tin, Altit, ACFM As Single
    Public z1, RPM As Short
    Public pr As Short
    Public Profil(20) As String
    Public H, D As Single
    Public kImboc, ipr, TipoGap As Short
    Public iDraft, iLingua As Short
    '-------------------------------------------------------------
    Private Xstr, X1 As String
    Private S8 As Single
    Private S9, Q3, PTOTALE As Single
    Private X5, X4, Y4, X6 As Single
    Private Y8, XXXX As Single
    Private PMAX0, PDIN, Re As Single
    Private i8 As Short
    Private X9, Y9 As Single
    Private AY, AX, AZ As Single
    Private BJ, AJ, AW As Single
    Private PD, AQ, k, RecPerd As Single
    Private AR, Q7 As Single
    Private Dom(20) As String
    Private Risp(20) As String
    Private Girante As String
    Private X8 As Single
    Private Draft As String
    Private Nrdit As Short
    Private SCFM, ACFMv As Single
    Private TipSpeed, StatPV As Single
    Private FaceVel, Diamv As Single
    Private Unit As New String(" ", 2)
    Private Lingua As New String(" ", 2)
    Private Effic As Single
    Private GapStr As String
    Private Tinv, Toutv As Single
    Private ImbocStr As String
    Private Hdiv As Single
    Private StrUnit(5) As String
    Private AriaTest(2) As String
    Private Imboc(4) As String
    Private Gap(2) As String
    Private Tirag(1) As String
    Private Elevation As Short
    Private r, kW, p As Single
    Private Q, FANEF As Single
    Private iF1 As Short
    Private V3, Recup As Single
    Private Archiv(12) As Short
    Private dAiu(12) As String
    Private AA(13) As Single
    Private BB(13) As Single
    Private CC(13) As Single
    Private dD(13) As Single
    Private EE(13) As Single
    Private FF(13) As Single
    Private AB(13, 2) As Single
    Private AC(13, 2) As Single
    Private UNPOT, UNPS, UNVOL, UNPD As Single
    '====================================================
    Private x(10) As Short
    Private y(10) As Short
    '============================Parabole=================
    Private jj As Short
    Private i As Short
    Private alf, G1 As Single
    Private ZY, ZJ, ZW, ZX As Single
    Private f, WW, H3 As Single
    Private G As Short
    Private G5 As Short
    Private HH As Single
    Private ZZ, ZV As Single
    Private F1 As Short
    Private xParab(6) As Single
    Private yParab(6) As Single
    Private W(6) As Single
    Private j(6) As Single
    Private A(3) As Single
    Private b(3) As Single
    Private C(3) As Single
    Private e(3) As Single
    Private abc(3) As Single
    Private H1, H2 As Single
    '=======================================Plottaggio=================
    Private KLOOP As Short
    Private Sc, PMAX As Single
    Private C1, C2, CS As Single
    Private ik As Short
    Private K7, iC As Short
    Private F5, F8, X7 As Single
    Private K5 As Short
    Private Q1, Q2 As Single
    Private TI, SI, Alfa As Single
    Private Y6, Z8, Y7, Y5 As Single
    Private M8, VP, M7, L6 As Single
    Private PDIN2, PDIN1, L7 As Single
    Private R8, L8 As Single
    Private STEPWL As Short
    Private R9, MinEta As Single
    Private Pmin1, eff, Pmax1 As Single
    Private Eff2, Eff1, P3 As Single
    Private dedq, dedp, den As Single
    Private cosq, cosp As Single
    Private pl, ds, den1, ql As Single
    '===================================================
    Function Modulo() As Boolean
        Dim j8, i8, i9, j9 As Short
        Dim Z, x, y, U As Single
        Dim z1 As Single
        Dim X1 As String
        'Disegna le due griglie
        Modulo = True
        If Len(FilePRI) = 0 Then Modulo = False : Exit Function
        File = FilePRI
        Call PrModulo(File)
        'Print #ipr, "M50,1800": Print #ipr, "Q1": Print #ipr, "S3": Print #ipr, "P" + at1(8 + ITOTAL * 5) ' "PStatic"
        'Print #ipr, "M50,1880": Print #ipr, "S3": Print #ipr, "P" + at1(9 + ITOTAL * 5) ' "PPressure"
        PrintLine(ipr, "M130,1800") : PrintLine(ipr, "Q1") : PrintLine(ipr, "S3") : PrintLine(ipr, "P" & at1(8 + ITOTAL * 5)) ' "PStatic"
        PrintLine(ipr, "M210,1800") : PrintLine(ipr, "S3") : PrintLine(ipr, "P" & at1(9 + ITOTAL * 5)) ' "PPressure"
        PrintLine(ipr, "Q0")
        PrintLine(ipr, "M700,850") : PrintLine(ipr, "S3") : PrintLine(ipr, "P" & at1(10)) ' "PAir Volume "
        'Print #ipr, "M50,450": Print #ipr, "S3": Print #ipr, "Q1": Print #ipr, "P" + "Absorbed" 'at1(11) ' "PAbs."
        '    Print #ipr, "M50,520": Print #ipr, "S3": Print #ipr, "P" + at1(12) ' "PPower "
        PrintLine(ipr, "M130,450") : PrintLine(ipr, "S3") : PrintLine(ipr, "Q1") : PrintLine(ipr, "P" & "Absorbed") 'at1(11) ' "PAbs."
        PrintLine(ipr, "M210,450") : PrintLine(ipr, "S3") : PrintLine(ipr, "P" & at1(12)) ' "PPower "
        PrintLine(ipr, "Q0")
        U = 0
        i9 = 1550 : j9 = 2200 : Z = 800 : z1 = 1000
        For i8 = 350 To i9 Step 100
            Z = 800 : z1 = 1000
            x = i8 : y = 100 : If Int(U / 2) - U / 2 < 0 Then y = j9
            If Int(U / 2) - U / 2 < 0 Then GoTo 1635
            GoTo 1640
1635:       Z = 1000 : z1 = 800
1640:       X1 = "M" & Str(Int(x)) & "," & Str(Int(y)) ': GoTo 65090
            PrintLine(ipr, X1)
            X1 = "H"
            PrintLine(ipr, X1)
            y = j9 : If Int(U / 2) - U / 2 < 0 Then y = 100
            X1 = "D" & Str(Int(x)) & "," & Str(Int(Z))
            PrintLine(ipr, X1)
            X1 = "M" & Str(Int(x)) & "," & Str(Int(z1))
            PrintLine(ipr, X1)
            X1 = "D" & Str(Int(x)) & "," & Str(Int(y))
            PrintLine(ipr, X1)
            X1 = "M" & Str(Int(x)) & "," & Str(Int(y))
            PrintLine(ipr, X1)
            X1 = "H"
            PrintLine(ipr, X1)
            U = U + 1
        Next i8
        U = 1
        For j8 = j9 To 100 Step -100
            y = j8 : x = 350 : If Int(U / 2) - U / 2 < 0 Then x = i9
            X1 = "M" & Str(Int(x)) & "," & Str(Int(y)) ': GoTo 65090
            PrintLine(ipr, X1)
            X1 = "H"
            PrintLine(ipr, X1)
            x = i9 : If Int(U / 2) - U / 2 < 0 Then x = 350
            If Not U = 14 Then
                X1 = "D" & Str(Int(x)) & "," & Str(Int(y)) ': GoTo 65090
                PrintLine(ipr, X1)
            End If
            U = U + 1
        Next j8
        X1 = "H"
        PrintLine(ipr, X1)
        FileClose(ipr)
    End Function
    Sub PrModulo(ByRef File As String)
        ' On Local Error GoTo ErrPM
        If Len(File) = 0 Then Exit Sub
        ipr = FreeFile()
        ' PRINT "|"; File$; "|": u$ = INPUT$(1)
10:     FileOpen(ipr, File, OpenMode.Output)
12:     PrintLine(ipr, "M230,2550") : PrintLine(ipr, "S4") ': Print #ipr, "PFBM-"
        SetSpess(4)
        PrintLine(ipr, "M0,0")
        PrintLine(ipr, "D0,2600,1700,2600,1700,0,0,0")
        SetSpess(1)
        'Print #ipr, "M40,2480": Print #ipr, "S4": Print #ipr, "PHUDSON ITALIANA"
        'Print #ipr, "M50,2430": Print #ipr, "S3": Print #ipr, "PTerno d'Isola, Italy"
        PrintLine(ipr, "M650,2540") : PrintLine(ipr, "S3") : PrintLine(ipr, "P" & at1(1)) ' "PTYPE"
        PrintLine(ipr, "S3") : PrintLine(ipr, "M1160,2540") : PrintLine(ipr, "P" & at1(50)) ' "PProfile Type "
        PrintLine(ipr, "M650,2485") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(2)) ' "PDIAM."
        PrintLine(ipr, "M1050,2485") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(3)) ' "PR.P.M."
        PrintLine(ipr, "M1300,2485") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(4)) ' "PDensity "
        PrintLine(ipr, "M650,2430") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(5)) ' "PBl.Numb."
        PrintLine(ipr, "M1050,2430") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(6)) ' "PTemp. "
        PrintLine(ipr, "M1300,2430") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(7)) ' "PAltit."
        PrintLine(ipr, "M1700,2400") : PrintLine(ipr, "D600,2400,600,2600") : PrintLine(ipr, "M600,2400")
99:     PrintLine(ipr, "D0,2400")
        Exit Sub
        'ErrPM: Print "Err PrModulo"; Err; Erl: End
    End Sub
    Public Sub Iniziaroutines()
        If Monitor.Routines Is Nothing Then
            Monitor.Routines = New RoutBase1.Routines
        End If
        With finCurva
            Monitor.Routines.DoveDisegno = .Picture1
            Monitor.Routines.DoveDisegnog.Clear(Color.White)
            Monitor.Routines.DoveInizio = Monitor.Motore.Inizio
        End With
        Monitor.Routines.Init200(Monitor.Motore.Inizio.Archdir)
        With finCurva
            .Picture1.Visible = True
            .Picture1.BringToFront()
            '   If Not .cmdZoom.Value Then .Picture1.Cls
        End With
    End Sub

    Function Fancur() As Boolean
        Fancur = True
        Dim i As Short
        '   TT = 0
        '   If AddDistinta = 0 Then
        '   Cls
        '   Print: Print
        '   Print "                           FBM-HUDSON ITALIANA "
        '   Print: Print: Print: Print: Print
        '   Print "                     DIAGRAMMA VENTILATORI ASSIALI "
        '   Print "                            Edizione Inglese"
        '   Print: Print
        '   Print "                             Data 15-10-93"
        '   Print "                             Rev. -- 2 --"
        '   Print: Print: Print: Print: Print
        '   Rem dati generali
        '   INPUT "Per continuare premere Enter "; ENTER
        '   Cls
        '   End If
        '   GOTO 85
        '85 REM dati aeraulici:tt=0
        If daISA Or UNITA < 1 Or UNITA > 5 Then
            If Unit = "" Then Unit = "SI"
            If Asc(Unit) < 32 Then Unit = "SI"
            If Not secondo Then
                Select Case Unit
                    Case "SI" : UNITA = 2
                    Case "ME" : UNITA = 1
                    Case "BR" : UNITA = 5
                    Case Else : UNITA = 1
                End Select
            End If
        End If
        iF1 = FreeFile()
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1000.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        For i = 1 To 5
            PrintLine(iF1, GlobalRoutines.Adjust(StrUnit(i), 25))
            Archiv(i) = 0
        Next
        FileClose(iF1)
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1001.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        For i = 1 To 2
            PrintLine(iF1, GlobalRoutines.Adjust(AriaTest(i), 25))
        Next
        FileClose(iF1)
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1003.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        For i = 1 To 3
            PrintLine(iF1, GlobalRoutines.Adjust(Lin(i), 25))
        Next
        FileClose(iF1)
        Archiv(3) = 1000
        Archiv(4) = 1001
        Archiv(6) = 49
        Archiv(7) = 49
        Archiv(8) = 1003
        If Len(Prev) = 0 And daISA Then Prev = " "
        If Len(Item) = 0 Then Item = " "
        If iLingua = 0 Then iLingua = 1
        Dom(1) = "Progetto o commessa" : Risp(1) = Prev ':      LungSt(1) = 4
        Dom(2) = "Item" : Risp(2) = Item ':      LungSt(2) = 20
        Dom(3) = "Unità di misura" : Risp(3) = StrUnit(UNITA) ': LungSt(3) = 11
        Dom(4) = "Temp. o dens.aria?" : Risp(4) = AriaTest(z1 + 1) ': LungSt(4) = 5
        Dom(6) = "Punto di Funz.?" : If PFUN = 1 Then Risp(6) = "SI" Else Risp(6) = "NO" ':       LungSt(6) = 2
        Dom(5) = "Altitudine [m]" : Risp(5) = GlobalRoutines.myStr(Altit, 4, 1, False) ': LungSt(5) = 6
        Dom(7) = "Rendimenti?" : If PEFF = 1 Then Risp(7) = "SI" Else Risp(7) = "NO" ':       LungSt(7) = 2
        Dom(8) = "Lingua" : Risp(8) = Lin(iLingua)
        FaseDati = 1
        Monitor.Motore.InputDatiM(1, 8, "Dati generali", Dom, Risp, "", Archiv, dAiu)
        With Monitor.Motore.inputforms.Item(1)
            .Top = finCurva.Top + finCurva.Picture1.Top
            .Left = finCurva.Left + finCurva.Picture1.Left
            '  .pEnaList(3) = False
            '  .pEnaList(4) = False
            '  .pEnaRisp(5) = False
        End With
        DueFin()
        finCurva.Enabled = False
        ModifiedData = True
    End Function

    Sub GetDatiFH()
        Dim Riga As String
        ' On Local Error GoTo ErrGD
50:     FileOpen(10, RadTextv & RTrim(Lav(0).Arch), OpenMode.Input)
60:     Riga = LineInput(10)
        '   Prev$ = LTRIM$(RTRIM$(LEFT$(Riga$, 8)))
        '   Item$ = MID$(Riga$, 10, 20)
        Input(10, Nrdit)
        '   a$ = myStr(CSNG(Nrdit \ 2), 2, 0, TRUE)
        '   IF LEFT$(a$, 1) = " " THEN a$ = "0" + RIGHT$(a$, 1)
        '   File$ = Prev$ + a$
        Riga = LineInput(10)
        Draft = Left(Riga, 2)
        Unit = Mid(Riga, 3, 2) : Lingua = Mid(Riga, 5, 2)
        Tippal = LineInput(10)
        Riga = LineInput(10)
        RPM = Val(Left(Riga, 5)) : Npal = Val(Right(Riga, 5))
        Input(10, SCFM)
        Input(10, ACFMv)
        Input(10, TipSpeed)
        Input(10, kW)
        Input(10, StatPV)
        Input(10, Angle)
        Input(10, Toutv)
        Input(10, Diamv)
        Input(10, FaceVel)
        Input(10, Tinv)
        Input(10, Altit)
        Input(10, Effic)
        FileClose(10)
        iLingua = 1
        Select Case Lingua
            Case Is = "IT" : iLingua = 1
            Case Is = "FR" : iLingua = 2
            Case Is = "IN" : iLingua = 3
        End Select
        Exit Sub
        'ErrGD: Print "Err GetDatiFH"; Err; Erl; RTrim$(Lav(0).Arch): End
    End Sub

    Sub GetDatiSH()
        Dim i As Short
        Dim Riga As String = ""
        'On Local Error GoTo ErrGDS
        iLingua = 3
10:     FileOpen(10, RadTextv & RTrim(Lav(0).Arch), OpenMode.Input)
        For i = 1 To 13 : Riga = LineInput(10) : Next
        Girante = Mid(Riga, 36, 4)
        Riga = LineInput(10)
        Diam = Val(Mid(Riga, 36, 4)) : ImbocStr = Mid(Riga, 70, 7)
        Riga = LineInput(10)
        Npal = Val(Mid(Riga, 36, 4))
        Tippal = Girante
        Riga = LineInput(10)
        Riga = LineInput(10)
20:     RPM = Val(Mid(Riga, 34, 6))
        Riga = LineInput(10)
        Riga = LineInput(10)
        Riga = LineInput(10)
        Riga = LineInput(10)
        Dens = Val(Mid(Riga, 34, 6)) : Hdiv = Val(Mid(Riga, 70, 7))
        Riga = LineInput(10)
        Tin = Val(Mid(Riga, 34, 6))
        Riga = LineInput(10)
        GapStr = Mid(Riga, 72, 5)
        Altit = 0 '?????????????
        'Girante$,TipPal$,Diam,Rpm,Dens,Npal,Tin,Altit,Imboc$,Gap$,Hdiv
        FileClose(10)
        Exit Sub
        'ErrGDS: Print "err GetDatiSH"; Err; Erl: End
    End Sub
    Sub GetStandFH()
        Dim i, ifl, ii As Short
        ReDim at1(55)
        Base = Monitor.Motore.Inizio.Archdir
        GetLingua()
        ifl = FreeFile()
        FileOpen(ifl, Base & "\FANCUR.TXT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 5 : Input(ifl, StrUnit(i)) : Next
        Input(ifl, AriaTest(1))
        Input(ifl, AriaTest(2))
        For i = 1 To 4 : Input(ifl, Imboc(i)) : Next
        Input(ifl, Gap(1))
        Input(ifl, Gap(2))
        Tirag(0) = "Forzato" : Tirag(1) = "Indotto"
        If nuovePar Then
            tabella.MoveFirst()
            i = 0
            Do Until tabella.EOF
                i = i + 1
                nprofil = i
                Profil(i) = Trim(tabella.Fields("Sigla").Value) & " - " & Trim(tabella.Fields("Descrizione").Value)
                tabella.MoveNext()
            Loop
        Else
            nprofil = 4
            For i = 1 To nprofil : Input(ifl, Profil(i)) : Next
        End If
        FileClose(ifl)
        Sigla = Dati.Sigla
        ii = InStr(Profil(pr), "-")
        If ii > 0 Then
            Sigla = Trim(Left(Profil(pr), ii - 2))
            Dati.Sigla = Sigla
        End If
    End Sub

    Sub HpglHp(ByRef Fin As String, ByRef Fout As String)
        'On Local Error GoTo ErrHpgl
        Dim iOu, iIn, j As Short
        Dim Riga As String
        Dim jj As Short
        Dim xabs, yabs As Single
        Dim Out As String = ""
        Dim nv As Short
        Dim Sizx, Sizy As Single
        Dim s As String
        Dim A As Single
        Call PrModulo(Fout)
        Call PrintDat(ipr)
        FileClose(ipr)
        iIn = FreeFile()
        FileOpen(iIn, Fin, OpenMode.Input)
        iOu = FreeFile()
        FileOpen(iOu, Fout, OpenMode.Append)
500:
        Do
            Riga = LineInput(iIn)
            Riga = LTrim(Riga)
            Select Case Left(Riga, 2)
                Case "IN" 'inizializzazione
                Case "IM" '???????????
                Case "IP" 'assoluti plotter
                Case "SC" 'relativi disegno
                Case "SP" 'seleziona penna
                    Stringi(Riga)
                    PrintLine(iOu, "J" & Riga)
                Case "LT" 'tipo linea
                Case "PA" 'plot absolute
                    Stringi(Riga)
                    PenUpDown(Riga, Out)
                    Stringi(Riga)
                    Estrai(Riga)
                    xabs = x(j) : yabs = y(j)
                    For jj = 0 To j
                        If jj > 0 Then Out = Out & ","
                        Out = Out & Str(y(jj) - 350) & "," & Str(2300 - x(jj))
                    Next
                    PrintLine(iOu, Out)
                Case "PR"
                    Stringi(Riga)
                    PenUpDown(Riga, Out)
                    Stringi(Riga)
                    Estrai(Riga)
                    If Not (x(0) = 2000 And y(0) = 0 And x(1) = 0 And y(1) = 0) Then
                        For jj = 0 To j
                            xabs = xabs + x(jj) : yabs = yabs + y(jj)
                            x(jj) = xabs : y(jj) = yabs
                            If jj > 0 Then Out = Out & ","
                            Out = Out & Str(y(jj) - 350) & "," & Str(2300 - x(jj))
                        Next
                        PrintLine(iOu, Out)
                    End If
                Case "SI" 'absolute character size
530:                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
                    Stringi(Riga)
                    nv = InStr(Riga, ",")
                    Sizx = Val(Riga)
                    Sizy = Val(Right(Riga, Len(Riga) - nv))
                    s = Str(10 * Sizy)
                    PrintLine(iOu, "S" & s)
                Case "DI" 'direction
540:                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
                    Stringi(Riga)
                    nv = InStr(Riga, ",")
                    A = Val(Left(Riga, nv - 1))
                    If System.Math.Abs(A) < 0.01 Then
                        PrintLine(iOu, "Q0")
                    Else
                        PrintLine(iOu, "Q1")
                    End If
                Case "LB"
550:                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
                    Stringi(Riga)
                    Riga = Left(Riga, Len(Riga) - 1)
                    PrintLine(iOu, "P" & Riga)
                    yabs = yabs + 100 * 1.5 * Sizx * Len(Riga)
            End Select
            If EOF(iIn) Then Exit Do
        Loop
        FileClose(iIn) : FileClose(iOu)
        Exit Sub
        'ErrHpgl: Print "Errore in HpglPl"; Err; Erl: End
    End Sub
    Private Sub Estrai(ByRef Riga As String)
        Dim j As Integer = 0
        Dim nv As Integer
        Do
            nv = InStr(Riga, ",")
            x(j) = Val(Left(Riga, nv - 1))
            Riga = Right(Riga, Len(Riga) - nv)
            y(j) = Val(Riga)
            nv = InStr(Riga, ",")
            If nv = 0 Then Exit Do
            Riga = Right(Riga, Len(Riga) - nv)
            j = j + 1
        Loop
    End Sub
    Private Sub Stringi(ByRef Riga As String)
        Riga = Right(Riga, Len(Riga) - 2)
        If Left(Riga, 1) = "," Or Left(Riga, 1) = ";" Then Mid(Riga, 1, 1) = Chr(32)
        Riga = LTrim(Riga)
    End Sub
    Private Sub PenUpDown(ByVal Riga As String, ByRef Out As String)
        Select Case Left(Riga, 2)
            Case "PU" : Out = "M" 'pen up
            Case "PD" : Out = "D" 'pen down
        End Select
    End Sub
    Sub PrintDat(ByRef ipr As Object)
        Dim Prof As String
        Dim n As Short
        n = InStr(Tippal, "-")
        If n > 0 Then Prof = Left(Tippal, n - 1) Else Prof = Trim(Tippal)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M800,2540") : SetSpess(1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "S3")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Girante)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "S3")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M1560,2540")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Prof) 'profile type
        SetSpess(2)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M830,2485")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "S2")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(Diam))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M1180,2485")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(RPM))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M1600,2485")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(Dens))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M830,2430")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(Npal))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M1185,2430")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(Tin))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M1500,2430")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(Altit))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M120,2360")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & ImbocStr)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M120,2290")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & GapStr)
        If Hdiv = 0 Then Exit Sub
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M270,2290")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & "altezza div.")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "M570,2290")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ipr. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        PrintLine(ipr, "P" & Str(Hdiv))
        SetSpess(1)
    End Sub
    Public Function LeggiDati() As Boolean
        Dim Help As String
        LeggiDati = True
        If Tipo = "FH" Then
            Call GetDatiFH()
        ElseIf Tipo = "SH" Then
            Call GetDatiSH()
        Else
            Help = "Funzione non disponibile      |"
            Help = Help & "per questo tipo di ventilatore|"
            MsgBox(Help, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ISA")
            LeggiDati = False
        End If
    End Function

    Public Sub OKFin1()
        Dim i As Short
        For i = 1 To 8
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inputforms().prisposte. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Risp(i) = Trim(DirectCast(Monitor.Motore.inputforms.Item(1), RoutBase1.frmInput).prisposte(i))
        Next
        'secondo
        Prev = Risp(1)
        Item = Risp(2)
        For i = 1 To 5
            If Trim(StrUnit(i)) = Trim(Risp(3)) Then UNITA = i : Exit For
        Next
        If Trim(Risp(4)) = AriaTest(1) Then z1 = 0 Else z1 = 1
        Elevation = Val(Risp(5))
        If Trim(Risp(6)) = "SI" Then PFUN = 1 Else PFUN = 0
        If Trim(Risp(7)) = "SI" Then PEFF = 1 Else PEFF = 0
        For i = 1 To 3
            If Trim(Lin(i)) = Trim(Risp(8)) Then iLingua = i : Exit For
        Next
        Select Case UNITA
            Case 1 '"m3/s--mmH2O",
                ACFM = ACFMv * 0.3048 ^ 3 / 60
                StatP = StatPV * Inch
                Diam = Diamv * Foot
                Tin = (Tinv - 32.0!) / 1.8
                TOut = (Toutv - 32.0!) / 1.8
            Case 2 ' "m3/s--Pa   ",
                ACFM = ACFMv * 0.3048 ^ 3 / 60
                StatP = StatPV * Inch * Grav ' / 10330! * 98500!
                Diam = Diamv * Foot
                Tin = (Tinv - 32.0!) / 1.8
                TOut = (Toutv - 32.0!) / 1.8
            Case 3 '"m3/h--mmH2O",
                ACFM = ACFMv * 0.3048 ^ 3 / 60 * 3600.0!
                StatP = StatPV * Inch
                Diam = Diamv * Foot
                Tin = (Tinv - 32.0!) / 1.8
                TOut = (Toutv - 32.0!) / 1.8
            Case 4 '"m3/h--Pa   ",
                ACFM = ACFMv * 0.3048 ^ 3 / 60 * 3600.0!
                StatP = StatPV * Inch * Grav ' / 10330! * 98500!
                Diam = Diamv * Foot
                Tin = (Tinv - 32.0!) / 1.8
                TOut = (Toutv - 32.0!) / 1.8
            Case 5 '"acfm--inH2O"
                Diam = Diamv * Foot
        End Select
        GetLingua()
    End Sub

    Public Function OKFin2(Optional ByRef nonscri As Boolean = False) As Boolean
        Dim i As Short
        For i = 1 To 8
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inputforms().prisposte. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Risp(i) = Trim(DirectCast(Monitor.Motore.inputforms.Item(2), RoutBase1.frmInput).prisposte(i))
        Next
        OKFin2 = True
        Girante = Risp(1) 'modello girante
        D = Val(Risp(2)) 'Diametro dirante
        'If UNITA = 5 Then D = D * 304.8
        kW = Val(Risp(3)) 'Potenza assorbita
        r = Val(Risp(4)) 'RPM
        Q = Val(Risp(5)) 'Portata
        If UNITA > 2 Then Q = Q / 1000.0!
        p = Val(Risp(6)) 'Press.statica
        FANEF = Val(Risp(7)) 'Rendim.totale
        If z1 = 0 Then
            Tin = Val(Risp(8)) 'Temp./densita'
            If UNITA = 5 Then Tin = (Tin - 32) / 1.8
        Else
            Dens = Val(Risp(8)) 'Temp./densita'
            If UNITA = 5 Then Dens = Dens * LbFt3 ' 16.0329
        End If
        '---------------------------------------------------------------
        If daISA Then
            If kImboc < 1 Then kImboc = 2
            If TipoGap < 1 Then TipoGap = 1
            If pr < 1 Then pr = 2
            If iDraft < 0 Or iDraft > 1 Then iDraft = 0
        End If
        If z1 = 1 Then
            If Dens = 0 And Not nonscri Then
                MsgBox("Non è stata fornita la densità dell'aria", MsgBoxStyle.Critical)
                OKFin2 = False
            End If
        End If
    End Function
    Public Sub OKFin3()
        Dim i As Short
        Dim yStr As String = ""
        For i = 1 To 6
            Risp(i) = Trim(DirectCast(Monitor.Motore.InputForms.Item(3), RoutBase1.frmInput).prisposte(i))
        Next
        For i = 0 To 1
            If Trim(Tirag(i)) = Trim(Risp(1)) Then
                iDraft = i
                Exit For
            End If
        Next
        For i = 1 To 4
            If UCase(Left(Imboc(i), 2)) = UCase(Left(Risp(2), 2)) Then
                kImboc = i
                Exit For
            End If
        Next
        For i = 1 To 2
            If Trim(Gap(i)) = Trim(Risp(4)) Then
                TipoGap = i
                Exit For
            End If
        Next
        Tippal = Trim(Risp(5))
        SelezPala()
        ImbocStr = Imboc(kImboc)
        V3 = Val(Risp(3))
        GapStr = Gap(TipoGap)
        Npal = Val(Risp(6))
        yStr = "P" & yStr
        Diam = D
        'HPow = kW
        On Error Resume Next
        RPM = r
        On Error GoTo 0
        ACFM = Q
        If UNITA > 2 Then ACFM = ACFM * 1000
        StatP = p
        Effic = FANEF
        Altit = Elevation
        '     Dens = DensAria
        Hdiv = V3
    End Sub

    Public Function GeneraPRI() As Boolean
        Dim Result As Short
        GeneraPRI = True
        ' selezione manuale
        FileOpen(ipr, FilePRI, OpenMode.Append)
        If D = 0 Then
            MsgBox("non è stato definito il diametro della girante", MsgBoxStyle.Critical)
            GeneraPRI = False
            FileClose(ipr)
            Exit Function
        End If
        If Npal = 0 Then
            MsgBox("non è stato definito il numero di pale", MsgBoxStyle.Critical)
            GeneraPRI = False
            FileClose(ipr)
            Exit Function
        End If
        SelezPala()
        H = corda * Npal / D
        ' SetSpess 2
        Call StampUn()
        'Calcolo della pressione dinamica e dei parametri geometrici"
        AR = PI * (D / 1000) ^ 2 / 4
        '    AQ = PI * (1.524) ^ 2 / 4
        AQ = PI * (d1524 / 1000) ^ 2 / 4
        If z1 = 1 Then
            k = Dens / 1.2
        Else
            k = (294 / (Tin + 273)) * ((294 - 0.00659 * Elevation) / 294) ^ 5.256
            If UNITA = 5 Then
                Dens = Int(75 * k + 0.5) / 1000
            Else
                Dens = Int(120 * k + 0.5) / 100
            End If
        End If
        ' press. dinamica corretta
        ' PD = PD * K
        ' correzione per imbocco
        Select Case kImboc ' GoTo 670, 680, 690, 700
            Case 1 : RecPerd = -0.1 '* PD ': GoTo 1500
            Case 2 : RecPerd = 0 ': GoTo 1500
            Case 3 : RecPerd = 0.12 '* PD ': GoTo 1500
            Case 4 : RecPerd = 0.22 '* PD
        End Select
        Call PrintDat(ipr)
        '3000 Rem selezione della solidita'
        If nuovePar Then
            Cambiato = True
            If Cambiato Then StubParabole()
            Cambiato = False
            If MaxAngles = 0 Then
                MsgBox("Ventilatore inadatto alle condizioni di progetto specificate")
                GeneraPRI = False
                FileClose(ipr)
                Exit Function
            End If
        Else
            Result = Parabole()
            Select Case Result
                Case 15000
                    'GoTo 15000
                Case Else
                    Stop
            End Select
        End If
        Plottaggio()
15000:  X1 = "M" & Str(0) & "," & Str(0)
        PrintLine(ipr, X1)
        If PFUN = 1 Then PuntoFunz() 'GoSub 24000
        FileClose(ipr)
        Exit Function
        'irraggiungibile      X4 = X9: Y4 = Y9
        '25000 REM unita' inglesi
        '      LOCATE 6, 45
        '      INPUT "Portata    acfm         "; Q: Q = Q / 1000
        '      LOCATE 7, 45
        '      INPUT "Pressione Stat. in.H2O  "; P
        '      LOCATE 8, 45
        '      INPUT "Rendimento Totale       "; FANEF
        '      LOCATE 9, 45
        '      INPUT "Potenza assorbita  hp   "; KW
        '      LOCATE 10, 45
        '      INPUT "N. Item                 "; BH$
        '      LOCATE 8, 1: GOTO 25045
        '25041 PRINT
        '25045 INPUT "Diametro Girante  ft           "; DBR: D = DBR * 304.8: y1$ = "P" + STR$(DBR)
        '     GOTO 143
        '     PRINT
        '     IF U1 = 1 GOTO 25077
        '25075 INPUT "Densita' (1) o Temperatura (0)"; Z1
        '      LOCATE 12, 1
        '25077 IF Z1 = 1 GOTO 25130
        '      INPUT "Temperatura F                  "; TBR: T = TBR / 1.8 - 17.78
        '      Y3$ = "P" + STR$(TBR)
        '      LOCATE 12, 45
        '      INPUT "Altitudine ft           "; SBR: S = SBR * .3048
        '      Y4$ = "P" + STR$(SBR)
        '      PRINT
        '      GOTO 295
        '25130 INPUT "Densita' lb/ft3                "; UBR: U = UBR * 16.0329
        '      Y5$ = "P" + STR$(UBR)
        '      PRINT
        '      GOTO 295
    End Function
    Private Sub StampUn()
        PrintLine(ipr, "M1470,2485") : PrintLine(ipr, "S2") : PrintLine(ipr, "P" & at1(15 + (UNITA - 1) * 7)) '"Pkg/m3"
        PrintLine(ipr, "M760,2485") : PrintLine(ipr, "P" & at1(16 + (UNITA - 1) * 7)) ' "Pmm"
        PrintLine(ipr, "M1170,2430") : PrintLine(ipr, "P" & at1(17 + (UNITA - 1) * 7)) ' "PC"
        PrintLine(ipr, "M1450,2430") : PrintLine(ipr, "P" & at1(18 + (UNITA - 1) * 7)) ' "Pm"
        PrintLine(ipr, "M130,2070") : PrintLine(ipr, "Q1") : PrintLine(ipr, "P" & at1(19 + (UNITA - 1) * 7)) ' "PmmH2O"
        PrintLine(ipr, "M130,800") : PrintLine(ipr, "P" & at1(20 + (UNITA - 1) * 7)) ' "Pkw"
        PrintLine(ipr, "M1050,850") : PrintLine(ipr, "Q0") : PrintLine(ipr, "P" & at1(21 + (UNITA - 1) * 7)) ' "PM3/S"
    End Sub
    Public Sub DueFin()
        Dim i As Short
        If Not secondo And daISA Then OKFin1()
        Dom(1) = "Modello di girante" : Risp(1) = "FH" ':  LungSt(1) = 5
        'If UNITA = 5 Then
        'Dom$(2) = "Diametro Girante [ft]"
        'Else
        Dom(2) = "Diametro Girante [mm]"
        'End If
        Risp(2) = GlobalRoutines.myStr(Diam, 5, 1, False) ': LungSt(2) = 8
        Dom(3) = "Potenza Assorbita [kW]" : Risp(3) = GlobalRoutines.myStr(kW, 5, 1, False)
        Dom(4) = "R.P.M." : Risp(4) = GlobalRoutines.myStr(CSng(RPM), 4, 0, True)
        Dom(5) = "Portata " & Left(StrUnit(UNITA), 4) : Risp(5) = GlobalRoutines.myStr(ACFM, 6, 1, False)
        Dom(6) = "Press.stat. " & Right(StrUnit(UNITA), 5) : Risp(6) = GlobalRoutines.myStr(StatP, 6, 1, False)
        Dom(7) = "Rendim.totale %" : Risp(7) = GlobalRoutines.myStr(Effic, 3, 3, False)
        If z1 = 0 Then 'temp.
            Dom(8) = "Temp. aria"
            If UNITA < 5 Then Dom(8) = Dom(8) & " [°C]" Else Dom(8) = Dom(8) & " [°F]"
            Risp(8) = GlobalRoutines.myStr(Tin, 3, 1, False)
        Else
            Dom(8) = "Dens. aria"
            If UNITA < 5 Then Dom(8) = Dom(8) & " [kg/m3]" Else Dom(8) = Dom(8) & " [lb/ft3]"
            Risp(8) = GlobalRoutines.myStr(0.0!, 3, 1, False)
        End If
        For i = 1 To 8 : Archiv(i) = 0 : Next
        Monitor.Motore.InputDatiM(2, 8, "Dati di funzionamento", Dom, Risp, "", Archiv, dAiu)
        With Monitor.Motore.inputforms.Item(2)
            '   .pEnaRisp(1) = False
            '   .pEnaRisp(2) = False
            '   .pEnaRisp(4) = False
            '   .pEnaRisp(5) = False
            '   .pEnaRisp(3) = False
            '   .pEnaRisp(6) = False
            '   .pEnaRisp(7) = False
            '   .pEnaRisp(8) = False
        End With
        If Not secondo Then OKFin2(True)
        Dom(1) = "Tiraggio" : Risp(1) = Tirag(iDraft)
        Dom(2) = "Tipo di imbocco" : Risp(2) = Imboc(kImboc)
        Dom(3) = "Alt. divergente [m]" : Risp(3) = GlobalRoutines.myStr(Hdiv, 5, 1, False)
        Dom(4) = "Tipo gap" : Risp(4) = Gap(TipoGap)
        Dom(5) = "Tipo profilo" : Risp(5) = Profil(pr)
        Dom(6) = "Numero pale" : Risp(6) = GlobalRoutines.myStr(CSng(Npal), 2, 0, True)
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1003.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        For i = 0 To 1
            PrintLine(iF1, GlobalRoutines.Adjust(Tirag(i), 25))
        Next
        FileClose(iF1)
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1001.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        For i = 1 To 2
            PrintLine(iF1, GlobalRoutines.Adjust(Gap(i), 25))
        Next
        FileClose(iF1)
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1002.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        If nuovePar Then
            i = 1
            Do While Len(Trim(Profil(i))) > 0
                PrintLine(iF1, GlobalRoutines.Adjust(Profil(i), 25))
                i = i + 1
            Loop
        Else
            For i = 1 To 3
                PrintLine(iF1, GlobalRoutines.Adjust(Profil(i), 25))
            Next
        End If
        FileClose(iF1)
        Archiv(1) = 1003
        Archiv(2) = 43
        Archiv(4) = 1001
        Archiv(5) = 1002
        Monitor.Motore.InputDatiM(3, 6, "Dati geometrici", Dom, Risp, "", Archiv, dAiu)
        With Monitor.Motore.inputforms.Item(3)
            '   .pEnaList(1) = False
            '   .pEnaList(2) = False
            '   .pEnaList(4) = False
            '   .pEnaList(5) = False
            '   .pEnaRisp(3) = False
            '   .pEnaRisp(6) = False
        End With
    End Sub

    Public Function CorrezAng(ByRef D As Single) As Single
        Dim Q3 As Single
        '27000 Rem subroutine correzione angolo
        Select Case idPala
            Case 1
                If D < 2100 Then Q3 = 4
                If (D >= 2100) And (D < 3000) Then Q3 = 3
                If (D >= 3000) And (D < 3900) Then Q3 = 2
                If (D >= 3900) And (D < 4800) Then Q3 = 1
                If D >= 4800 Then Q3 = 0
                '      Return
                CorrezAng = Q3
        End Select
    End Function

    Private Function Parabole() As Short
        MaxAngles = 7
        If H < 0.177 Then GoTo 3200
        '     If Z4 = 1 Then GoTo 3110
        If H < 0.354 Then GoTo 3200
        '     If Z4 = 1 Then GoTo 3110
        If H < 0.531 Then GoTo 3400
        '     If Z4 = 1 Then GoTo 3110
        If H < 0.709 Then GoTo 3600
        '     If Z4 = 1 Then GoTo 3110
        If H < 1.063 Then GoTo 3800
        '     If Z4 = 1 Then GoTo 3110
        If H < 1.417 Then GoTo 4000
        '     If Z4 = 1 Then GoTo 3110
        If H < 1.7 Then GoTo 4200
        '     If Z4 = 1 Then GoTo 3110
        If H > 1.7 Then GoTo 4400
        '     If Z4 = 1 Then GoTo 3110
        '     RETURN
        '3110 Stop
3200:   ' solidita'.3
        H1 = 0.3 : G1 = 1
        If H < 0.3 Then GoTo 3215
        GoTo 3220
3215:   jj = 1 : H2 = 0.305
3220:   i = 1
3230:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 3235
            Case 2
                GoTo 3255
            Case 3
                GoTo 3275
            Case 4
                GoTo 3295
            Case 5
                GoTo 3315
            Case 6
                GoTo 3335
            Case 7
                GoTo 3355
        End Select
3235:   xParab(1) = 7.4 : xParab(2) = 10 : xParab(3) = 1 : xParab(4) = 16.7 : xParab(5) = 12 : xParab(6) = 2
        yParab(1) = 9.2 : yParab(2) = 66 : yParab(3) = 1 : yParab(4) = 30 : yParab(5) = 12 : yParab(6) = 65
        If jj = 1 Then GoTo 3240
        ZZ = 1
        GoTo 3400
3240:   Sub7000()
3241:   i = i + 1 : GoTo 3230
3255:   xParab(1) = 10.9 : xParab(2) = 10 : xParab(3) = 3.2 : xParab(4) = 18.3 : xParab(5) = 15.8 : xParab(6) = 2
        yParab(1) = 11.7 : yParab(2) = 71 : yParab(3) = 3.1 : yParab(4) = 38 : yParab(5) = 15 : yParab(6) = 68
        If jj = 1 Then GoTo 3260
        GoTo 3400
3260:   Sub7000()
3261:   i = i + 1 : GoTo 3230
3275:   xParab(1) = 14.6 : xParab(2) = 10 : xParab(3) = 6 : xParab(4) = 19.2 : xParab(5) = 19.4 : xParab(6) = 2
        yParab(1) = 14.2 : yParab(2) = 74 : yParab(3) = 6 : yParab(4) = 45 : yParab(5) = 19 : yParab(6) = 68
        If jj = 1 Then GoTo 3280
        GoTo 3400
3280:   Sub7000()
3281:   i = i + 1 : GoTo 3230
3295:   xParab(1) = 18.1 : xParab(2) = 10 : xParab(3) = 9 : xParab(4) = 19.6 : xParab(5) = 22.8 : xParab(6) = 2
        yParab(1) = 18.5 : yParab(2) = 76 : yParab(3) = 9 : yParab(4) = 55 : yParab(5) = 23 : yParab(6) = 70
        If jj = 1 Then GoTo 3300
        GoTo 3400
3300:   Sub7000()
3301:   i = i + 1 : GoTo 3230
3315:   xParab(1) = 21.6 : xParab(2) = 10 : xParab(3) = 14.4 : xParab(4) = 18.7 : xParab(5) = 26 : xParab(6) = 2
        yParab(1) = 21.5 : yParab(2) = 75 : yParab(3) = 14.5 : yParab(4) = 60.5 : yParab(5) = 26 : yParab(6) = 70
        If jj = 1 Then GoTo 3320
        GoTo 3400
3320:   Sub7000()
3321:   i = i + 1 : GoTo 3230
3335:   xParab(1) = 24.5 : xParab(2) = 10 : xParab(3) = 20 : xParab(4) = 16.6 : xParab(5) = 28.6 : xParab(6) = 2
        yParab(1) = 26 : yParab(2) = 70.5 : yParab(3) = 20 : yParab(4) = 62.5 : yParab(5) = 28.65 : yParab(6) = 67.3
        If jj = 1 Then GoTo 3340
        GoTo 3400
3340:   Sub7000()
3341:   i = i + 1 : GoTo 3230
3355:   xParab(1) = 26 : xParab(2) = 10 : xParab(3) = 22.8 : xParab(4) = 15 : xParab(5) = 30 : xParab(6) = 2
        yParab(1) = 26.9 : yParab(2) = 65 : yParab(3) = 22.8 : yParab(4) = 60 : yParab(5) = 30 : yParab(6) = 64
        If jj = 1 Then GoTo 3360
        GoTo 3400
3360:   Sub7000()
3380:   ZZ = 0 : jj = 0
        GoTo 15000
3400:   If ZZ = 1 Then GoTo 3420
        H1 = 0.354 : G1 = 1
        ' solidita' .354
        i = 1
        GoTo 3430
3420:   For F1 = 1 To 6
            W(F1) = xParab(F1)
            j(F1) = yParab(F1)
        Next F1
        H2 = 0.354
3430:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 3435
            Case 2
                GoTo 3455
            Case 3
                GoTo 3475
            Case 4
                GoTo 3495
            Case 5
                GoTo 3515
            Case 6
                GoTo 3535
            Case 7
                GoTo 3555
        End Select
3435:   xParab(1) = 8 : xParab(2) = 12 : xParab(3) = 1 : xParab(4) = 19.1 : xParab(5) = 13 : xParab(6) = 2
        yParab(1) = 8.5 : yParab(2) = 66 : yParab(3) = 1 : yParab(4) = 35 : yParab(5) = 13.6 : yParab(6) = 61
        If ZZ = 1 Then GoTo 3440
        ZJ = 1
        GoTo 3600
3440:   Sub7000()
        GoTo 3241
3442:   i = i + 1 : GoTo 3430
3455:   xParab(1) = 11.8 : xParab(2) = 12 : xParab(3) = 3.2 : xParab(4) = 20.8 : xParab(5) = 17 : xParab(6) = 2
        yParab(1) = 12.5 : yParab(2) = 71.3 : yParab(3) = 9.5 : yParab(4) = 68 : yParab(5) = 15 : yParab(6) = 68
        If ZZ = 1 Then GoTo 3460
        GoTo 3600
3460:   Sub7000()
        GoTo 3261
3462:   i = i + 1 : GoTo 3430
3475:   xParab(1) = 15.5 : xParab(2) = 12 : xParab(3) = 6 : xParab(4) = 21.9 : xParab(5) = 20.8 : xParab(6) = 2
        yParab(1) = 15.1 : yParab(2) = 74.1 : yParab(3) = 6 : yParab(4) = 45 : yParab(5) = 20.8 : yParab(6) = 68
        If ZZ = 1 Then GoTo 3480
        GoTo 3600
3480:   Sub7000()
        GoTo 3281
3482:   i = i + 1 : GoTo 3430
3495:   xParab(1) = 19.1 : xParab(2) = 12 : xParab(3) = 9 : xParab(4) = 22.5 : xParab(5) = 24.3 : xParab(6) = 2
        yParab(1) = 18 : yParab(2) = 76.1 : yParab(3) = 9 : yParab(4) = 51 : yParab(5) = 24.3 : yParab(6) = 70
        If ZZ = 1 Then GoTo 3500
        GoTo 3600
3500:   Sub7000()
        GoTo 3301
3502:   i = i + 1 : GoTo 3430
3515:   xParab(1) = 22.4 : xParab(2) = 12 : xParab(3) = 14.4 : xParab(4) = 21.8 : xParab(5) = 27.6 : xParab(6) = 2
        yParab(1) = 22.5 : yParab(2) = 75 : yParab(3) = 14.5 : yParab(4) = 59 : yParab(5) = 27.8 : yParab(6) = 68
        If ZZ = 1 Then GoTo 3520
        GoTo 3600
3520:   Sub7000()
        GoTo 3321
3522:   i = i + 1 : GoTo 3430
3535:   xParab(1) = 25 : xParab(2) = 12 : xParab(3) = 20 : xParab(4) = 19 : xParab(5) = 30.4 : xParab(6) = 2
        yParab(1) = 26 : yParab(2) = 70.5 : yParab(3) = 19.8 : yParab(4) = 62 : yParab(5) = 30.2 : yParab(6) = 67
        If ZZ = 1 Then GoTo 3540
        GoTo 3600
3540:   Sub7000()
        GoTo 3341
3542:   i = i + 1 : GoTo 3430
3555:   xParab(1) = 26.8 : xParab(2) = 12 : xParab(3) = 23 : xParab(4) = 17 : xParab(5) = 31.9 : xParab(6) = 2
        yParab(1) = 29.7 : yParab(2) = 66.5 : yParab(3) = 23.2 : yParab(4) = 60 : yParab(5) = 32 : yParab(6) = 65
        If ZZ = 1 Then GoTo 3560
        GoTo 3600
3560:   Sub7000()
        GoTo 3380
3580:   ZJ = 0
        GoTo 15000
3600:   If ZJ = 1 Then GoTo 3620
        ' solidita .531
        H1 = 0.531 : G1 = 1
        i = 1
        GoTo 3630
3620:   For F1 = 1 To 6
            W(F1) = xParab(F1)
            j(F1) = yParab(F1)
        Next F1
        H2 = 0.531
3630:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 3635
            Case 2
                GoTo 3655
            Case 3
                GoTo 3675
            Case 4
                GoTo 3695
            Case 5
                GoTo 3715
            Case 6
                GoTo 3735
            Case 7
                GoTo 3755
        End Select
3635:   xParab(1) = 10.7 : xParab(2) = 16 : xParab(3) = 1.6 : xParab(4) = 28 : xParab(5) = 16 : xParab(6) = 2
        yParab(1) = 10.8 : yParab(2) = 70.5 : yParab(3) = 1.8 : yParab(4) = 30 : yParab(5) = 16 : yParab(6) = 64
        If ZJ = 1 Then GoTo 3640
        ZW = 1
        GoTo 3800
3640:   Sub7000()
        GoTo 3442
3642:   i = i + 1 : GoTo 3630
3655:   xParab(1) = 14.7 : xParab(2) = 16 : xParab(3) = 3.8 : xParab(4) = 30 : xParab(5) = 20.4 : xParab(6) = 2
        yParab(1) = 14.1 : yParab(2) = 74.8 : yParab(3) = 10.4 : yParab(4) = 70 : yParab(5) = 17.5 : yParab(6) = 70
        If ZJ = 1 Then GoTo 3660
        ZW = 1
        GoTo 3800
3660:   Sub7000()
        GoTo 3462
3662:   i = i + 1 : GoTo 3630
3675:   xParab(1) = 18.6 : xParab(2) = 16 : xParab(3) = 6.1 : xParab(4) = 31.3 : xParab(5) = 24.8 : xParab(6) = 2
        yParab(1) = 19.5 : yParab(2) = 76.6 : yParab(3) = 6.5 : yParab(4) = 45 : yParab(5) = 25 : yParab(6) = 70
        If ZJ = 1 Then GoTo 3680
        ZW = 1
        GoTo 3800
3680:   Sub7000()
        GoTo 3482
3682:   i = i + 1 : GoTo 3630
3695:   xParab(1) = 22.2 : xParab(2) = 16 : xParab(3) = 9.600001 : xParab(4) = 32 : xParab(5) = 28.7 : xParab(6) = 2
        yParab(1) = 22 : yParab(2) = 79 : yParab(3) = 10 : yParab(4) = 52 : yParab(5) = 29 : yParab(6) = 71
        If ZJ = 1 Then GoTo 3700
        ZW = 1
        GoTo 3800
3700:   Sub7000()
        GoTo 3502
3702:   i = i + 1 : GoTo 3630
3715:   xParab(1) = 26.2 : xParab(2) = 16 : xParab(3) = 15 : xParab(4) = 31.2 : xParab(5) = 32.6 : xParab(6) = 2
        yParab(1) = 25.5 : yParab(2) = 76.7 : yParab(3) = 15.2 : yParab(4) = 59 : yParab(5) = 32.5 : yParab(6) = 70
        If ZJ = 1 Then GoTo 3720
        ZW = 1
        GoTo 3800
3720:   Sub7000()
        GoTo 3522
3722:   i = i + 1 : GoTo 3630
3735:   xParab(1) = 29.4 : xParab(2) = 16 : xParab(3) = 20 : xParab(4) = 29.2 : xParab(5) = 35.6 : xParab(6) = 2
        yParab(1) = 30 : yParab(2) = 72 : yParab(3) = 20 : yParab(4) = 61.5 : yParab(5) = 35.5 : yParab(6) = 68
        If ZJ = 1 Then GoTo 3740
        ZW = 1
        GoTo 3800
3740:   Sub7000()
        GoTo 3542
3742:   i = i + 1 : GoTo 3630
3755:   xParab(1) = 31.3 : xParab(2) = 16 : xParab(3) = 23 : xParab(4) = 27.6 : xParab(5) = 37.4 : xParab(6) = 2
        yParab(1) = 32 : yParab(2) = 69 : yParab(3) = 23.6 : yParab(4) = 60.5 : yParab(5) = 37.5 : yParab(6) = 66
        If ZJ = 1 Then GoTo 3760
        ZW = 1
        GoTo 3800
3760:   Sub7000()
        GoTo 3580
        ZW = 0
        GoTo 15000
3800:   If ZW = 1 Then GoTo 3820
        ' solidita .709
        H1 = 0.709 : G1 = 1
        i = 1
        GoTo 3830
3820:   For F1 = 1 To 6
            W(F1) = xParab(F1)
            j(F1) = yParab(F1)
        Next F1
        H2 = 0.709
3830:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 3835
            Case 2
                GoTo 3855
            Case 3
                GoTo 3875
            Case 4
                GoTo 3895
            Case 5
                GoTo 3915
            Case 6
                GoTo 3935
            Case 7
                GoTo 3955
        End Select
3835:   xParab(1) = 10.8 : xParab(2) = 20 : xParab(3) = 2 : xParab(4) = 32 : xParab(5) = 17.6 : xParab(6) = 2
        yParab(1) = 12 : yParab(2) = 69.5 : yParab(3) = 2 : yParab(4) = 33 : yParab(5) = 18 : yParab(6) = 60
        'qui va bene
        If ZW = 1 Then GoTo 3840
        ZY = 1
        GoTo 4000
3840:   Sub7000()
        GoTo 3642
3842:   i = i + 1 : GoTo 3830
3855:   xParab(1) = 14.8 : xParab(2) = 20 : xParab(3) = 3.8 : xParab(4) = 36.2 : xParab(5) = 22.2 : xParab(6) = 2
        yParab(1) = 16.5 : yParab(2) = 73.7 : yParab(3) = 3.9 : yParab(4) = 38 : yParab(5) = 22.3 : yParab(6) = 68
        If ZW = 1 Then GoTo 3860
        GoTo 4000
3860:   Sub7000()
        GoTo 3662
3862:   i = i + 1 : GoTo 3830
3875:   xParab(1) = 19 : xParab(2) = 20 : xParab(3) = 6.1 : xParab(4) = 38.6 : xParab(5) = 26.4 : xParab(6) = 2
        yParab(1) = 20.5 : yParab(2) = 76.7 : yParab(3) = 6.5 : yParab(4) = 47 : yParab(5) = 26.3 : yParab(6) = 70
        If ZW = 1 Then GoTo 3880
        GoTo 4000
3880:   Sub7000()
        GoTo 3682
3882:   i = i + 1 : GoTo 3830
3895:   xParab(1) = 23.2 : xParab(2) = 20 : xParab(3) = 10 : xParab(4) = 40 : xParab(5) = 30.4 : xParab(6) = 2
        yParab(1) = 22.8 : yParab(2) = 79 : yParab(3) = 10 : yParab(4) = 56 : yParab(5) = 30.3 : yParab(6) = 70
        If ZW = 1 Then GoTo 3900
        GoTo 4000
3900:   Sub7000()
        GoTo 3702
3902:   i = i + 1 : GoTo 3830
3915:   xParab(1) = 27.4 : xParab(2) = 20 : xParab(3) = 15.6 : xParab(4) = 39.4 : xParab(5) = 34.4 : xParab(6) = 2
        yParab(1) = 27.2 : yParab(2) = 76.8 : yParab(3) = 15.5 : yParab(4) = 59 : yParab(5) = 34 : yParab(6) = 70
        If ZW = 1 Then GoTo 3920
        GoTo 4000
3920:   Sub7000()
        GoTo 3722
3922:   i = i + 1 : GoTo 3830
3935:   xParab(1) = 30.9 : xParab(2) = 20 : xParab(3) = 21.2 : xParab(4) = 37 : xParab(5) = 37.8 : xParab(6) = 2
        yParab(1) = 31.5 : yParab(2) = 74 : yParab(3) = 21.4 : yParab(4) = 60.5 : yParab(5) = 37.5 : yParab(6) = 68
        If ZW = 1 Then GoTo 3940
        GoTo 4000
3940:   Sub7000()
        GoTo 3742
3942:   i = i + 1 : GoTo 3830
3955:   xParab(1) = 32.8 : xParab(2) = 20 : xParab(3) = 24.2 : xParab(4) = 35 : xParab(5) = 39.7 : xParab(6) = 2
        yParab(1) = 34 : yParab(2) = 72 : yParab(3) = 24 : yParab(4) = 60 : yParab(5) = 39.8 : yParab(6) = 66.5
        If ZW = 1 Then GoTo 3960
        GoTo 4000
3960:   Sub7000()
3980:   ZY = 0
        GoTo 15000
4000:   If ZY = 1 Then GoTo 4020
        ' solidita 1.063
        H1 = 1.063 : G1 = 1
        i = 1
        GoTo 4030
4020:   For F1 = 1 To 6
            W(F1) = xParab(F1)
            j(F1) = yParab(F1)
        Next F1
        H2 = 1.063
4030:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 4035
            Case 2
                GoTo 4055
            Case 3
                GoTo 4075
            Case 4
                GoTo 4095
            Case 5
                GoTo 4115
            Case 6
                GoTo 4135
            Case 7
                GoTo 4155
        End Select
4035:   xParab(1) = 12.1 : xParab(2) = 24 : xParab(3) = 2.5 : xParab(4) = 40.7 : xParab(5) = 18.2 : xParab(6) = 2
        yParab(1) = 12 : yParab(2) = 69 : yParab(3) = 2.8 : yParab(4) = 33 : yParab(5) = 18 : yParab(6) = 60
        If ZY = 1 Then GoTo 4040
        ZX = 1
        GoTo 4200
4040:   Sub7000()
        GoTo 3842
4042:   i = i + 1 : GoTo 4030
4055:   xParab(1) = 16.5 : xParab(2) = 24 : xParab(3) = 4.4 : xParab(4) = 44.8 : xParab(5) = 23.2 : xParab(6) = 2
        yParab(1) = 16.5 : yParab(2) = 74.6 : yParab(3) = 4.4 : yParab(4) = 38 : yParab(5) = 23 : yParab(6) = 64
        If ZY = 1 Then GoTo 4060
        GoTo 4200
4060:   Sub7000()
        GoTo 3862
4062:   i = i + 1 : GoTo 4030
4075:   xParab(1) = 20.7 : xParab(2) = 24 : xParab(3) = 7.2 : xParab(4) = 47.2 : xParab(5) = 28 : xParab(6) = 2
        yParab(1) = 21 : yParab(2) = 78 : yParab(3) = 7.6 : yParab(4) = 47 : yParab(5) = 28 : yParab(6) = 67
        If ZY = 1 Then GoTo 4080
        GoTo 4200
4080:   Sub7000()
        GoTo 3882
4082:   i = i + 1 : GoTo 4030
4095:   xParab(1) = 24.9 : xParab(2) = 24 : xParab(3) = 10.3 : xParab(4) = 48 : xParab(5) = 32.6 : xParab(6) = 2
        yParab(1) = 25 : yParab(2) = 80 : yParab(3) = 10.8 : yParab(4) = 54 : yParab(5) = 32.8 : yParab(6) = 70
        If ZY = 1 Then GoTo 4100
        GoTo 4200
4100:   Sub7000()
        GoTo 3902
4102:   i = i + 1 : GoTo 4030
4115:   xParab(1) = 29.1 : xParab(2) = 24 : xParab(3) = 16.1 : xParab(4) = 46.7 : xParab(5) = 36.6 : xParab(6) = 2
        yParab(1) = 29 : yParab(2) = 76.3 : yParab(3) = 16.2 : yParab(4) = 58 : yParab(5) = 36.8 : yParab(6) = 70.5
        If ZY = 1 Then GoTo 4120
        GoTo 4200
4120:   Sub7000()
        GoTo 3922
4122:   i = i + 1 : GoTo 4030
4135:   xParab(1) = 32.5 : xParab(2) = 24 : xParab(3) = 22.1 : xParab(4) = 43.5 : xParab(5) = 39.6 : xParab(6) = 2
        yParab(1) = 33 : yParab(2) = 73 : yParab(3) = 22.3 : yParab(4) = 60 : yParab(5) = 39.6 : yParab(6) = 68.5
        If ZY = 1 Then GoTo 4140
        GoTo 4200
4140:   Sub7000()
        GoTo 3942
4142:   i = i + 1 : GoTo 4030
4155:   xParab(1) = 34.4 : xParab(2) = 24 : xParab(3) = 26.6 : xParab(4) = 39.8 : xParab(5) = 41.4 : xParab(6) = 2
        yParab(1) = 35.7 : yParab(2) = 71 : yParab(3) = 27 : yParab(4) = 60 : yParab(5) = 41.3 : yParab(6) = 66.5
        If ZY = 1 Then GoTo 4160
        GoTo 4200
4160:   Sub7000()
        GoTo 3980
4180:   ZX = 0
        GoTo 15000
4200:   If ZX = 1 Then GoTo 4220
        ' solidita 1.417
        H1 = 1.417 : G1 = 1
        i = 1
        GoTo 4230
4220:   For F1 = 1 To 6
            W(F1) = xParab(F1)
            j(F1) = yParab(F1)
        Next F1
        H2 = 1.417
4230:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 4235
            Case 2
                GoTo 4255
            Case 3
                GoTo 4275
            Case 4
                GoTo 4295
            Case 5
                GoTo 4315
            Case 6
                GoTo 4335
            Case 7
                GoTo 4355
        End Select
4235:   xParab(1) = 13.2 : xParab(2) = 26 : xParab(3) = 3 : xParab(4) = 45.5 : xParab(5) = 18.6 : xParab(6) = 2
        yParab(1) = 13 : yParab(2) = 69 : yParab(3) = 3 : yParab(4) = 33 : yParab(5) = 18.6 : yParab(6) = 60
        If ZX = 1 Then GoTo 4240
        ZV = 1
        GoTo 4400
4240:   Sub7000()
        GoTo 4042
4242:   i = i + 1 : GoTo 4230
4255:   xParab(1) = 17.8 : xParab(2) = 26 : xParab(3) = 4.5 : xParab(4) = 49 : xParab(5) = 24 : xParab(6) = 2
        yParab(1) = 17 : yParab(2) = 75.1 : yParab(3) = 4.5 : yParab(4) = 40 : yParab(5) = 24 : yParab(6) = 65
        If ZX = 1 Then GoTo 4260
        GoTo 4400
4260:   Sub7000()
        GoTo 4062
4262:   i = i + 1 : GoTo 4230
4275:   xParab(1) = 22.2 : xParab(2) = 26 : xParab(3) = 7.3 : xParab(4) = 51.2 : xParab(5) = 29 : xParab(6) = 2
        yParab(1) = 22 : yParab(2) = 78.2 : yParab(3) = 7.2 : yParab(4) = 48 : yParab(5) = 29 : yParab(6) = 68
        If ZX = 1 Then GoTo 4280
        GoTo 4400
4280:   Sub7000()
        GoTo 4082
4282:   i = i + 1 : GoTo 4230
4295:   xParab(1) = 26.6 : xParab(2) = 26 : xParab(3) = 10.5 : xParab(4) = 52.4 : xParab(5) = 33.8 : xParab(6) = 2
        yParab(1) = 26 : yParab(2) = 78.5 : yParab(3) = 11 : yParab(4) = 55 : yParab(5) = 34.8 : yParab(6) = 70.5
        If ZX = 1 Then GoTo 4300
        GoTo 4400
4300:   Sub7000()
        GoTo 4102
4302:   i = i + 1 : GoTo 4230
4315:   xParab(1) = 31 : xParab(2) = 26 : xParab(3) = 17.6 : xParab(4) = 51.2 : xParab(5) = 37.8 : xParab(6) = 2
        yParab(1) = 31 : yParab(2) = 75.6 : yParab(3) = 17.7 : yParab(4) = 58 : yParab(5) = 38 : yParab(6) = 69
        If ZX = 1 Then GoTo 4320
        GoTo 4400
4320:   Sub7000()
        GoTo 4122
4322:   i = i + 1 : GoTo 4230
4335:   xParab(1) = 35 : xParab(2) = 26 : xParab(3) = 25.4 : xParab(4) = 46.8 : xParab(5) = 41 : xParab(6) = 2
        yParab(1) = 34.8 : yParab(2) = 71 : yParab(3) = 25.5 : yParab(4) = 60 : yParab(5) = 41.2 : yParab(6) = 67
        If ZX = 1 Then GoTo 4340
        GoTo 4400
4340:   Sub7000()
        GoTo 4142
4342:   i = i + 1 : GoTo 4230
4355:   xParab(1) = 37 : xParab(2) = 26 : xParab(3) = 29.7 : xParab(4) = 43.2 : xParab(5) = 42.9 : xParab(6) = 2
        yParab(1) = 37.5 : yParab(2) = 68.5 : yParab(3) = 30 : yParab(4) = 60 : yParab(5) = 43 : yParab(6) = 65
        If ZX = 1 Then GoTo 4360
        GoTo 4400
4360:   Sub7000()
        GoTo 4180
4380:   ZV = 0
        GoTo 15000
4400:   If ZV = 1 Then GoTo 4420
        ' solidita 1.705
        H1 = 1.705 : G1 = 1
        i = 1
        GoTo 4430
4420:   For F1 = 1 To 6
            W(F1) = xParab(F1)
            j(F1) = yParab(F1)
        Next F1
        H2 = 1.705
4430:   Select Case i
            Case Is < 0
                Error (5)
            Case 1
                GoTo 4435
            Case 2
                GoTo 4455
            Case 3
                GoTo 4475
            Case 4
                GoTo 4495
            Case 5
                GoTo 4515
            Case 6
                GoTo 4535
            Case 7
                GoTo 4555
        End Select
4435:   xParab(1) = 12.8 : xParab(2) = 30 : xParab(3) = 3 : xParab(4) = 52 : xParab(5) = 19 : xParab(6) = 2
        yParab(1) = 14 : yParab(2) = 69.5 : yParab(3) = 3 : yParab(4) = 34 : yParab(5) = 19 : yParab(6) = 61
        Sub7000()
        If WW = 1 Then GoTo 4442
        GoTo 4242
4442:   i = i + 1 : GoTo 4430
4455:   xParab(1) = 18 : xParab(2) = 30 : xParab(3) = 4.5 : xParab(4) = 55.6 : xParab(5) = 24.4 : xParab(6) = 2
        yParab(1) = 18 : yParab(2) = 75.3 : yParab(3) = 4.5 : yParab(4) = 36 : yParab(5) = 24.3 : yParab(6) = 66
        Sub7000()
        If WW = 1 Then GoTo 4462
        GoTo 4262
4462:   i = i + 1 : GoTo 4430
4475:   xParab(1) = 22.7 : xParab(2) = 30 : xParab(3) = 7.6 : xParab(4) = 58.1 : xParab(5) = 29.4 : xParab(6) = 2
        yParab(1) = 21 : yParab(2) = 78.5 : yParab(3) = 7.7 : yParab(4) = 47 : yParab(5) = 29.2 : yParab(6) = 68
        Sub7000()
        If WW = 1 Then GoTo 4482
        GoTo 4282
4482:   i = i + 1 : GoTo 4430
4495:   xParab(1) = 27.5 : xParab(2) = 30 : xParab(3) = 10.8 : xParab(4) = 59 : xParab(5) = 34.5 : xParab(6) = 2
        yParab(1) = 25 : yParab(2) = 78.2 : yParab(3) = 11 : yParab(4) = 50 : yParab(5) = 34.5 : yParab(6) = 69
        Sub7000()
        If WW = 1 Then GoTo 4502
        GoTo 4302
4502:   i = i + 1 : GoTo 4430
4515:   xParab(1) = 32.4 : xParab(2) = 30 : xParab(3) = 18.6 : xParab(4) = 57.3 : xParab(5) = 38.6 : xParab(6) = 2
        yParab(1) = 31 : yParab(2) = 75.1 : yParab(3) = 18.7 : yParab(4) = 58 : yParab(5) = 38.5 : yParab(6) = 68
        Sub7000()
        If WW = 1 Then GoTo 4522
        GoTo 4322
4522:   i = i + 1 : GoTo 4430
4535:   xParab(1) = 36.5 : xParab(2) = 30 : xParab(3) = 25.8 : xParab(4) = 52.8 : xParab(5) = 42 : xParab(6) = 2
        yParab(1) = 36 : yParab(2) = 71.3 : yParab(3) = 26 : yParab(4) = 60 : yParab(5) = 42 : yParab(6) = 66.5
        Sub7000()
        If WW = 1 Then GoTo 4542
        GoTo 4342
4542:   i = i + 1 : GoTo 4430
4555:   xParab(1) = 38.6 : xParab(2) = 30 : xParab(3) = 33 : xParab(4) = 44.7 : xParab(5) = 44 : xParab(6) = 2
        yParab(1) = 39.5 : yParab(2) = 69.5 : yParab(3) = 31 : yParab(4) = 60 : yParab(5) = 44 : yParab(6) = 65
        Sub7000()
        If WW = 1 Then GoTo 4562
        GoTo 4380
4562:   WW = 0 ' POLO 12-06-91 (aggiunto label)
15000:  Parabole = 15000
    End Function
    Private Sub Sub8000()
8000:   ' subroutine coefficienti della parabola
        For HH = 0 To 1
            '8030
            Regresso(A, b, abc)
            AA(i) = abc(1)
            BB(i) = abc(2)
            CC(i) = abc(3)
            If alf > 0 Then Exit Sub
            If HH = 1 Then Exit Sub
8180:       dD(i) = AA(i) : EE(i) = BB(i) : FF(i) = CC(i) 'DD EE FF coeff per i dp
            For G = 1 To 2
                AB(i, G) = A(G + 1) 'AB port min e max per il dp
                AC(i, G) = b(G + 1) 'AC dp corrisp.
            Next G
8015:       For G = 1 To 3
                b(G) = e(G)
                A(G) = C(G)
            Next G
        Next HH '     GoTo 8030
    End Sub
    Private Sub Sub7000()
7000:   ' subroutine di interpolazione
        f = 0
        For G = 1 To 5 Step 2
            If H < 0.3 Or H > 1.77 Then
                H3 = 0 'GoTo 7025
            Else 'If H > 1.77 Then GoTo 7025
                H3 = (H - H1) / (H2 - H1)
            End If 'GoTo 7030
            f = f + 1
            A(f) = W(G) + H3 * (xParab(G) - W(G))
            Recup = 1 / CoeffPD * (A(f) / (PI / 4 * (1.524 + 400.8 * V3 / D) ^ 2)) ^ 2
            PD = (A(f) / AQ) ^ 2 / CoeffPD
            Select Case TipoGap ' GoTo 7060, 7065
                Case 1 : b(f) = (W(G + 1) + H3 * (xParab(G + 1) - W(G + 1))) * k + PD * k * RecPerd - 0.7 * (PD - Recup) * k ': GoTo 7070
                Case 2 : b(f) = (W(G + 1) + H3 * (xParab(G + 1) - W(G + 1))) * k * 1.05263 + PD * k * RecPerd - 0.7 * (PD - Recup) * k
            End Select
            C(f) = j(G) + H3 * (yParab(G) - j(G))
            e(f) = j(G + 1) + H3 * (yParab(G + 1) - j(G + 1))
        Next G
        Sub8000()
    End Sub
    Private Sub Plottaggio()
        '26000 Rem routine
DefScala:  ' subroutine Definizione della scala
        Select Case UNITA
            Case Is < 0
                Error (5)
            Case 1
                GoTo 9002
            Case 2
                GoTo 9003
            Case 3
                GoTo 9004
            Case 4
                GoTo 9005
            Case 5
                GoTo 9006
        End Select
9002:   UNPS = 1 : UNVOL = 1 : UNPOT = 1 : UNPD = 1 : GoTo 9007 '"m3/s--mmH2O"
9003:   UNPS = Grav : UNVOL = 1 : UNPOT = 1 : UNPD = 1 : GoTo 9007 ', "m3/s--Pa   "
9004:   UNPS = 1 : UNVOL = 3.6 : UNPOT = 1 : UNPD = 3.6 : GoTo 9007 ', "m3/h--mmH2O"
9005:   UNPS = Grav : UNVOL = 3.6 : UNPOT = 1 : UNPD = 3.6 : GoTo 9007 ', "m3/h--Pa   "
9006:   UNPS = 0.03937 : UNVOL = 2.119 : UNPOT = 0.746 : UNPD = 0.08343 ', "acfm--inH2O"
        '9007 AJ = (D / 1524) ^ 2 * (r / 770) ^ 2 * UNPS
        '     BJ = (D / 1524) ^ 3 * (r / 770) * UNVOL
9007:   AJ = (D / d1524) ^ 2 * (r / r770) ^ 2 * UNPS
        BJ = (D / d1524) ^ 3 * (r / r770) * UNVOL
        ' scala delle pressioni
        AW = 1
        Sc = AC(MaxAngles / 2 + 1, 1) * AJ * 1.2 / 12 * k
        If ITOTAL = 1 Then
            PMAX = 0
            For KLOOP = 1 To MaxAngles
                PDIN = k * (AB(KLOOP, 1) / AR) ^ 2 / CoeffPD
                PMAX0 = AC(KLOOP, 1) * AJ * 1.2 / k + PDIN * UNPS '??? *UNPS
                'correzione fatta da LP il 17/05/2002
                If PMAX0 > PMAX Then PMAX = PMAX0
            Next KLOOP
            Sc = PMAX * 1.2 / 12
            '        PRINT " SC ( pressione totale ) "; Sc
        End If
        Sub9500()
        ' scala delle portate
        AW = 2
        Sc = AB(MaxAngles, 2) * BJ * 1.1 / 12
        Sub9500()
        ' scala delle potenze
        AW = 3
        Re = AA(MaxAngles) * AB(MaxAngles, 1) ^ 2 + BB(MaxAngles) * AB(MaxAngles, 1) + CC(MaxAngles) 'rendimento
        Sc = AB(MaxAngles, 1) * BJ * ((AB(MaxAngles, 1) * BJ / AR / UNVOL) ^ 2 * UNPS * k / CoeffPD + AC(MaxAngles, 1) * AJ) / 1.02 / Re / MaxAngles * 1.2 / UNPOT / UNVOL / UNPS
        Sub9500()
PlotScala:  ' subroutine scrittura delle scale
        PrintLine(ipr, "S2")
        ' pressione
        For i8 = 0 To 12
            X9 = 250 : Y9 = 1000 + i8 * 100 : Call MoveTo()
            If Int(AX * i8 * 1000) < (AX * i8 * 1000) Then Xstr = Str(Int(AX * i8 * 1000 + 0.5) / 1000) Else Xstr = Str(AX * i8)
            Call PrintStr()
        Next i8
        ' portata
        For i8 = 0 To 12 Step 2
            Y9 = 960 : X9 = 315 + i8 * 100 : Call MoveTo()
            If Int(AY * i8 * 1000) < (AY * i8 * 1000) Then Xstr = Str(Int(AY * i8 * 1000 + 0.5) / 1000) Else Xstr = Str(AY * i8)
            Call PrintStr()
        Next i8
        ' potenza
        For i8 = 0 To 7
            X9 = 250 : Y9 = 100 + i8 * 100 : Call MoveTo()
            If Int(AZ * i8 * 1000) < (AZ * i8 * 1000) Then Xstr = Str(Int(AZ * i8 * 1000 + 0.5) / 1000) Else Xstr = Str(AZ * i8)
            Call PrintStr()
        Next i8
PlotPres:  ' subroutine tracciatura curve pressioni
        SetSpess(3)
        S9 = 0
        For S8 = 1 To MaxAngles
            Q7 = (AB(S8, 2) - AB(S8, 1)) * BJ / 15
            X8 = AB(S8, 2)
            X9 = X8 * BJ / AY * 100 + 350 'portata max
            ' Exit Function
            Y8 = AC(S8, 2) * AJ
            If nuovePar Then
                Y7 = (X8 * BJ / AR / UNVOL) ^ 2 / CoeffPD * k * UNPS
                Y6 = Y7 * RecPerd
                Recup = 1 / CoeffPD * (X8 * BJ / UNVOL / (PI / 4 * (D / 1000 + 0.263 * V3) ^ 2)) ^ 2 * UNPS
                Y5 = 0.7 * (Y7 - Recup * k)
                Y8 = Y8 * k + Y6 - Y5
            End If
            Y9 = Y8 / AX * 100 + 1000 'dp alla portata max
            If ITOTAL = 1 Then
                PDIN = k * (AB(S8, 2) * BJ / AR / UNVOL) ^ 2 / CoeffPD '***
                ' LP aggiunse /UNVOL il 17/05/2002
                Y9 = (Y8 * AJ + PDIN * UNPS) / AX * 100 + 1000
            End If
            If Y9 < 1001 Then GoTo 30064
30050:      Call MoveTo()
30064:      For S9 = S9 To 15
                K5 = 0
                If Y9 < 1001 Then GoTo 30065
                GoTo 30070
30065:          K5 = 1 : S9 = S9 + 1
30070:          X8 = AB(S8, 2) - Q7 * S9 / BJ
                X9 = X8 * BJ / AY * 100 + 350
                Y8 = (dD(S8) * X8 ^ 2 + EE(S8) * X8 + FF(S8)) * AJ
                If nuovePar Then
                    Y7 = (X8 * BJ / AR / UNVOL) ^ 2 / CoeffPD * UNPS * k
                    Y6 = Y7 * RecPerd
                    Recup = 1 / CoeffPD * (X8 * BJ / UNVOL / (PI / 4 * (D / 1000 + 0.263 * V3) ^ 2)) ^ 2 * UNPS
                    Y5 = 0.7 * (Y7 - Recup * k)
                    Y8 = Y8 * k + Y6 - Y5 ' Y8 + Y6 - Y5
                End If
                Y9 = Y8 / AX * 100 + 1000
                If ITOTAL = 1 Then
                    PDIN = k * (X8 * BJ / AR / UNVOL) ^ 2 / CoeffPD '***
                    ' LP aggiunse /UNVOL il 17/05/2002
                    Y9 = (Y8 * AJ + PDIN * UNPS) / AX * 100 + 1000
                End If
                If Y9 < 1001 Then GoTo 30065
                If K5 = 1 Then GoTo 30050
                Call DrawTo()
            Next S9
            X5 = -20 : X6 = 10
            Q3 = CorrezAng(D) 'GoSub 27000
            If corda = 360 And idPala = 1 Then
                XXXX = 5 * S8 - Q3 - 1
            Else
                XXXX = 5 * S8 - Q3
            End If
            If XXXX <= 19 And idPala = 1 Then XXXX = XXXX - 1
            Xstr = Str(XXXX)
            Sub22000()
            S9 = 0
        Next S8
PlotPot:  ' subroutine curve di potenza
        F8 = 0 : F5 = 9
        For S8 = 1 To MaxAngles
            Q7 = (AB(S8, 2) - AB(S8, 1)) * BJ / 15 'portata max-portata min
            X8 = AB(S8, 2) * BJ : X7 = AB(S8, 2) 'portata max
            X9 = X8 / AY * 100 + 350 'punto grafico portata max
            Y8 = AC(S8, 2) * AJ 'pr alla portata max
            Z8 = AA(S8) * X7 ^ 2 + BB(S8) * X7 + CC(S8) 'rendimento alla p max
            Y7 = (X8 / AR / UNVOL) ^ 2 / CoeffPD * k * UNPS
            'Y7 = 0 '???????????????????????????????? attenzione press dyn
            Y6 = Y7 * RecPerd '* k
            Recup = 1 / CoeffPD * (X8 / UNVOL / (PI / 4 * (D / 1000 + 0.263 * V3) ^ 2)) ^ 2 * UNPS
            Y5 = 0.7 * (Y7 - Recup * k)
            'Y5 = 0 '???????????????????????????????? remmato
            If nuovePar Then
                Y9 = X8 * (Y7 + Y8 * k + Y6 - Y5) / (1.02 * Z8) / AZ * 100 / UNPOT / UNVOL / UNPS + 100
            Else
                Y9 = X8 * (Y7 + Y8) / (1.02 * Z8) / AZ * 100 / UNPOT / UNVOL / UNPS + 100
            End If
            Call MoveTo()
            For S9 = 0 To 15
                X8 = AB(S8, 2) * BJ - Q7 * S9 : X7 = AB(S8, 2) - Q7 * S9 / BJ
                Y7 = (X8 / AR / UNVOL) ^ 2 / CoeffPD * k * UNPS
                'Y7 = 0 '????????????????????????????????
                X9 = X8 / AY * 100 + 350
                Y8 = (dD(S8) * X7 ^ 2 + EE(S8) * X7 + FF(S8)) * AJ
                Z8 = AA(S8) * X7 ^ 2 + BB(S8) * X7 + CC(S8)
                Y6 = Y7 * RecPerd '* k
                Recup = 1 / CoeffPD * (X8 / UNVOL / (PI / 4 * (D / 1000 + 0.263 * V3) ^ 2)) ^ 2 * UNPS
                Y5 = 0.7 * (Y7 - Recup * k)
                'Y5 = 0 '????????????????????????????????
                If nuovePar Then
                    Y9 = X8 * (Y7 + Y8 * k + Y6 - Y5) / (1.02 * Z8) / AZ * 100 / UNPOT / UNVOL / UNPS + 100
                Else
                    Y9 = X8 * (Y7 + Y8) / (1.02 * Z8) / AZ * 100 / UNPOT / UNVOL / UNPS + 100
                End If
                Call DrawTo()
            Next S9
            X5 = -20 : X6 = 10
            Q3 = CorrezAng(D) 'GoSub 27000
            If corda = 360 And idPala = 1 Then
                XXXX = 5 * S8 - Q3 - 1
            Else
                XXXX = 5 * S8 - Q3
            End If
            If idPala = 1 And XXXX <= 19 Then XXXX = XXXX - 1
            Xstr = Str(XXXX)
            Sub22000()
        Next S8

PlotRumor:  ' rumorosita'
        SetSpess(1)
        If D > 2200 Then GoTo 45015
        SI = 12.8 - 0.0058 * D
        GoTo 45020
45015:  SI = 0
45020:  TI = 1.17 * H
        Q1 = AY * 2 / UNVOL : Q2 = AY * 10 / UNVOL : VP = PI * r * D / 60000.0!
        M7 = AX * 9 / UNPS : M8 = AX * 7 / UNPS : L6 = 50 * System.Math.Log(VP) / System.Math.Log(10)
        If ITOTAL = 1 Then
            Q1 = AY * 5 / UNVOL
            M7 = AX * 3 / UNPS
            Q2 = Q1
            M8 = AX * 8 / UNPS
            PDIN1 = (Q1 / AR) ^ 2 / CoeffPD
            PDIN2 = (Q2 / AR) ^ 2 / CoeffPD
            M7 = M7 - PDIN1
            M8 = M8 - PDIN2
        End If
        L7 = 12 * System.Math.Log(D / 1000) / System.Math.Log(10)
        R8 = L6 + L7 + 5 * System.Math.Log(Q1 * M7 / 102) / System.Math.Log(10) + SI + TI
        R8 = Int(R8)
        R9 = L6 + L7 + 5 * System.Math.Log(Q2 * M8 / 102) / System.Math.Log(10) + SI + TI
        R9 = Int(R9)
        '      IF (R9 - R8) < 4 GOTO 45060
        '   FOR S8 = R8 TO R9 STEP 2      POLO 12-06-91 (commentate)
        '   GOTO 45070                    POLO 12-06-91 (commentate)
        STEPWL = 1
        For S8 = R8 To R9 - 1 Step STEPWL 'modifica
            If ITOTAL = 0 Then
                F8 = F8 + 1
                F5 = F5 + 1
            Else
                F8 = F8 + 0.5
                F5 = F5 + 1
            End If
            '45060 FOR S8 = R8 TO R9
            '      F8 = F8 + 1
            '      F5 = F5 + 1
45070:      L8 = 10 ^ ((S8 - L6 - L7 - SI - TI) / 10)
            Q1 = AY * F8 / UNVOL
            X9 = Q1 / AY * 100 * UNVOL + 350
            PDIN = 0.0!
            If ITOTAL = 1 Then PDIN = k * (Q1 / AR) ^ 2 / CoeffPD
            '      Y9 = L8 ^ 2 * 102 / Q1 / AX * 100 * UNPS + 1000
            Y9 = L8 ^ 2 * 102 / Q1 / AX * 100 * UNPS + PDIN / AX * 100 * UNPS + 1000
            If Y9 > 2050 Then GoTo 45105
            GoTo 45110
45105:      F8 = F8 + 0.5
            GoTo 45070
45110:      Call MoveTo()
            For S9 = Q1 To (AY * F5 / UNVOL) Step (AY / 5 / UNVOL)
                X9 = S9 / AY * 100 * UNVOL + 350
                If X9 > 1450 Then GoTo 45170
                PDIN = 0.0!
                If ITOTAL = 1 Then PDIN = k * (S9 / AR) ^ 2 / CoeffPD
                Y9 = L8 ^ 2 * 102 / S9 / AX * 100 * UNPS + PDIN / AX * 100 * UNPS + 1000
                '      Y9 = L8 ^ 2 * 102 / S9 / AX * 100 * UNPS + 1000
                If Y9 > 2050 Then GoTo 45165
                Call DrawTo()
45165:          X4 = X9 : Y4 = Y9
45170:      Next S9
            X5 = 20 : X6 = 10
            Xstr = Str(S8 - CorrDB) 'modifica
            X1 = "M" & Str(Int(X4 + 20)) & "," & Str(Int(Y4 - 10))
            PrintLine(ipr, X1)
            X1 = "P" & Xstr
            PrintLine(ipr, X1)
            If Not S8 < R9 Then
                X1 = "M" & Str(Int(X4 + 20)) & "," & Str(Int(Y4 + 100))
                PrintLine(ipr, X1)
                PrintLine(ipr, "PPWL")
                X1 = "M" & Str(Int(X4 + 20)) & "," & Str(Int(Y4 + 50))
                PrintLine(ipr, X1)
                PrintLine(ipr, "PdB(A)")
            End If
45180:  Next S8
PresDyn:  ' pressione dinamica
        SetSpess(2)
        MoveTo(370, 1050)
        '      X1$ = "M" + Str$(Int(370)) + "," + Str$(1050)
        '      Print #ipr, X1$
        PrintLine(ipr, "P" & at1(52)) ' "PVel. Press."
        Q1 = AY * 2 / UNVOL
        X9 = Q1 / AY * 100 * UNVOL + 350
        Y9 = (Q1 / AR) ^ 2 / CoeffPD * k / AX * 100 * UNPS + 1000
        Call MoveTo()
        For S9 = Q1 To (AY * 11 / UNVOL) Step (AY / 5 / UNVOL)
            X9 = S9 / AY * 100 * UNVOL + 350
            Y9 = (S9 / AR) ^ 2 / CoeffPD * k / AX * 100 * UNPS + 1000
            Call DrawTo()
        Next S9
50090:  'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        Return
Recup:  ' Perdite o Recupero di pressione
        Q1 = AY * 2 / UNVOL
        X9 = Q1 / AY * 100 * UNVOL + 350
        Y8 = (Q1 / AR) ^ 2 / CoeffPD * k * UNPS
        Recup = k / CoeffPD * (Q1 / (PI / 4 * (D / 1000 + 0.263 * V3) ^ 2)) ^ 2
        Y9 = (RecPerd * Y8 + 0.7 * (Y8 - Recup)) / AX * 100
        If Y9 < 0 Then GoTo 51025
        Y9 = 1000 + Y9
        GoTo 51030
51025:  Y9 = 1000 - Y9
        K7 = 1
51030:  Call MoveTo()
        For S9 = Q1 To (AY * 11 / UNVOL) Step (AY / 5 / UNVOL)
            X9 = S9 / AY * 100 * UNVOL + 350
            Y8 = (S9 / AR) ^ 2 / CoeffPD * k * UNPS
            Recup = k / CoeffPD * (S9 / (PI / 4 * (D / 1000 + 0.263 * V3) ^ 2)) ^ 2 * UNPS
            Y9 = (RecPerd * Y8 + 0.7 * (Y8 - Recup)) / AX * 100
            If Y9 < 0 Then GoTo 51075
            Y9 = 1000 + Y9
            GoTo 51080
51075:      Y9 = 1000 - Y9
51080:      Call DrawTo()
        Next S9
        X1 = "M" & Str(900) & "," & Str(1050)
        PrintLine(ipr, X1)
        If K7 = 1 Then GoTo 51120
        PrintLine(ipr, "P" & at1(53)) ' "PPressure Recovery"
        GoTo 51130
51120:  PrintLine(ipr, "P" & at1(54)) ' "PAdded Losses"
51130:
PlotEta:  ' Scala Rendimenti
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If PEFF = 0 Then Return
        SetSpess(1)
        If FANEF > 0 Then
            PrintLine(ipr, "M1320,40") : PrintLine(ipr, "Q1") : PrintLine(ipr, "S3")
            PrintLine(ipr, "P" & at1(55)) '"PTotal Efficiency  %"
            PrintLine(ipr, "S2") : PrintLine(ipr, "Q0")
        End If
        For i8 = 0 To 7
            X9 = 1570
            Y9 = 100 + i8 * 100
            Call MoveTo()
            Xstr = Str(10 + 10 * i8)
            Call PrintStr()
        Next i8
        ' Rendimenti
        SetSpess(2)
        MaxEta = 0
        For S8 = 1 To MaxAngles
            Q7 = (AB(S8, 2) - AB(S8, 1)) * BJ / 15
            X9 = AB(S8, 2) * BJ / AY * 100 + 350
            Y8 = AA(S8) * AB(S8, 2) ^ 2 + BB(S8) * AB(S8, 2) + CC(S8)
            Y9 = Y8 * 10 * 1.02
            Call MoveTo()
            For S9 = 0 To 15
                X8 = AB(S8, 2) - Q7 * S9 / BJ
                X9 = X8 * BJ / AY * 100 + 350
                Y8 = AA(S8) * X8 ^ 2 + BB(S8) * X8 + CC(S8)
                If Y8 > MaxEta Then
                    MaxEta = Y8
                    QMaxEta = X8
                    iMaxEta = S8
                End If
                Y9 = Y8 * 10 * 1.02
                Call DrawTo()
            Next S9
            X5 = -10 : X6 = -35
            Q3 = CorrezAng(D) 'GoSub 27000
            If corda = 360 And idPala = 1 Then
                XXXX = 5 * S8 - Q3 - 1
            Else
                XXXX = 5 * S8 - Q3
            End If
            If XXXX <= 19 And idPala = 1 Then XXXX = XXXX - 1
            Xstr = Str(XXXX)
            Sub22000()
        Next S8
        If PlotEta1 Then
PlotEta1:
            MaxEta = Int(MaxEta / 5) * 5 / 100
            MinEta = 0.5
            For eff = MaxEta To MinEta Step -0.05
                Pmin1 = AC(MaxAngles / 2 + 1, 1)
                Pmax1 = Pmin1 + (AC(MaxAngles / 2 + 1, 2) - Pmin1) / 10
                Do
                    Eff1 = eta(QMaxEta, Pmin1) / 100
                    Eff2 = eta(QMaxEta, Pmax1) / 100
                    If Eff1 = 0 And Eff2 = 0 Then
                        P3 = Pmin1 + 1.1 * (Pmax1 - Pmin1)
                    ElseIf Eff1 = Eff2 Then
                        P3 = (Pmin1 + Pmax1) / 2
                    Else
                        P3 = Pmin1 + (Pmax1 - Pmin1) * (eff - Eff1) / (Eff2 - Eff1)
                        If P3 < 0 Then P3 = Pmin1 + 1.1 * (Pmax1 - Pmin1)
                    End If
                    If System.Math.Abs(Eff2 - eff) < 0.01 And System.Math.Abs(Eff1 - eff) < 0.01 Then Exit Do
                    If Pmax1 < Pmin1 Then
                        pl = Pmax1
                        Pmax1 = Pmin1
                        Pmin1 = pl
                    End If
                    If P3 > Pmax1 Then
                        Pmin1 = Pmax1
                        Pmax1 = P3
                    ElseIf P3 > Pmin1 Then
                        Pmax1 = P3
                    Else
                        Pmax1 = Pmin1
                        Pmin1 = P3
                    End If
                Loop
TracciaEta:     Dim j As Short
                For ik = 1 To -1 Step -2
                    X9 = QMaxEta * BJ / AY * 100 + 350
                    Y9 = P3 * AJ / AX * 100 + 1000
                    If ITOTAL = 1 Then
                        PDIN = k * (QMaxEta * BJ / AR / UNVOL) ^ 2 / CoeffPD
                        Y9 = (P3 * AJ + PDIN * UNPS) / AX * 100 + 1000
                    End If
                    MoveTo()
                    ql = QMaxEta : pl = P3
                    Do
                        dedp = fdedp(ql, pl)
                        dedq = fdedq(ql, pl)
                        den = System.Math.Sqrt(dedp ^ 2 + dedq ^ 2)
                        cosq = dedp / den
                        cosp = dedq / den
                        For i = -1 * ik To 1 * ik Step 2 * ik
                            For j = -1 * ik To 1 * ik Step 2 * ik
                                If System.Math.Abs(i * cosq * dedq + j * cosp * dedp) < 0.001 * System.Math.Abs(den) Then
                                    ds = System.Math.Sqrt(AC(MaxAngles / 2 + 1, 1) ^ 2 + AB(MaxAngles / 2 + 1, 2) ^ 2) / 100
                                    ql = ql + i * cosq * ds
                                    pl = pl + j * cosp * ds
                                    den = eff - eta(ql, pl) / 100
                                    ' den = eff - eta(ql + i * cosq * ds, pl + j * cosp * ds) / 100
                                    ' den = eff - eta(ql + j * cosp * ds, pl + i * cosq * ds) / 100
                                    ' Debug.Print ql * BJ, pl * AJ, den
                                    If System.Math.Abs(den) > 0.001 Then
                                        If den = eff Then
                                            iC = 10
                                        Else
                                            ds = den / (dedq * j * cosp - dedp * i * cosq)
                                            ' ql = ql + j * cosp * ds
                                            ' pl = pl - i * cosq * ds
                                            Alfa = 1
                                            iC = 0
                                            Do
                                                'For Alfa = -1 To 1 Step 0.1
                                                den1 = eff - eta(ql + Alfa * j * cosp * ds, pl - Alfa * i * cosq * ds) / 100
                                                'Debug.Print Alfa, den1
                                                'Next
                                                'Stop
                                                Alfa = -den / (den1 - den) * Alfa
                                                'den = den1
                                                'Alfav = Alfa
                                                'Alfa = -1
                                                ' Debug.Print Alfa, den1
                                                iC = iC + 1
                                                If iC = 10 Then Exit Do
                                            Loop While System.Math.Abs(den1) > 0.001
                                        End If
                                        If iC = 10 Then Exit Do
                                        ql = ql + Alfa * j * cosp * ds
                                        pl = pl - Alfa * i * cosq * ds
                                        den = eff - eta(ql, pl) / 100
                                    End If
                                    X9 = ql * BJ / AY * 100 + 350
                                    Y9 = pl * AJ / AX * 100 + 1000
                                    If ITOTAL = 1 Then
                                        PDIN = k * (ql * BJ / AR / UNVOL) ^ 2 / CoeffPD
                                        Y9 = (pl * AJ + PDIN * UNPS) / AX * 100 + 1000
                                    End If
                                    DrawTo()
                                    GoTo ContLoop
                                End If
                            Next j
                        Next i
ContLoop:
                    Loop
                Next ik
            Next
        End If
        Exit Sub 'Return
20200:  PrintLine(ipr, X1)
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        Return
    End Sub
    Private Sub Sub9800()
9800:   ' SUBROUTINE SCELTA SCALA
        CS = C1 / Sc
        If CS < 0.95 Then CS = 0 : Exit Sub
        Select Case System.Math.Round(AW)
            Case Is < 0
                Error (5)
            Case 1
                AX = C1
            Case 2
                AY = C1
            Case 3
                AZ = C1
        End Select
    End Sub
    Private Sub Sub22000()
22000:  X1 = "M" & Str(Int(X9 + X5)) & "," & Str(Int(Y9 + X6))
        PrintLine(ipr, X1)
        X1 = "P" & Xstr
        PrintLine(ipr, X1)
    End Sub
    Private Sub Sub9500()
9500:   ' subroutine campo scala
        Select Case UNITA
            Case Is < 0
                Error (5)
            Case 1
                GoTo 9503
            Case 2
                GoTo 9503
            Case 3
                GoTo 9503
            Case 4
                GoTo 9503
            Case 5
                GoTo 9505
        End Select
9503:   C2 = 0.1 : GoTo 9510
9505:   C2 = 0.01
9510:   For C1 = (1 * C2) To (1.5 * C2) Step (0.25 * C2)
            Sub9800()
            If CS <> 0 Then Exit For
        Next C1
        GoTo 9540
9540:   For C1 = (2 * C2) To (2.5 * C2) Step (0.25 * C2)
            Sub9800()
            If CS <> 0 Then Exit For
        Next C1
9570:   For C1 = (3 * C2) To (5 * C2) Step (1 * C2)
            Sub9800()
            If CS <> 0 Then Exit For
        Next C1
9600:   For C1 = (7.5 * C2) To (10 * C2) Step (2.5 * C2)
            Sub9800()
            If CS <> 0 Then Exit For
        Next C1
9630:   If C2 = 1000 Then Exit Sub
        C2 = C2 * 10
        GoTo 9510
    End Sub
    Private Sub PuntoFunz()
        '24000 Rem posizione punto funzionamento
        PDIN = 0
        If ITOTAL = 1 Then PDIN = k * (Q / UNVOL / AR) ^ 2 / CoeffPD
        PTOTALE = p + PDIN * UNPS
        SetSpess(4)
        X9 = Q / AY * 100 + 350 : Y9 = 70 : Call MoveTo()
        X9 = Q / AY * 100 + 350 : Y9 = kW / AZ * 100 + 140 : Call DrawTo()
        If FANEF > 0 Then
            X9 = Q / AY * 100 + 350 : Y9 = FANEF * 10 - 40 : Call MoveTo()
            X9 = Q / AY * 100 + 350 : Y9 = 830 : Call DrawTo()
        End If
        X9 = Q / AY * 100 + 350 : Y9 = 960 : Call MoveTo()
        X9 = Q / AY * 100 + 350 : Y9 = PTOTALE / AX * 100 + 1040 : Call DrawTo() 'corretto P in PTOTALE (LP, 25/05/2002)
        X9 = Q / AY * 100 + 350 : Y9 = PTOTALE / AX * 100 + 1000 : Call MoveTo() 'corretto P in PTOTALE (LP, 25/05/2002)
        SetSpess(1)
        X9 = 1200 : Y9 = 2030 : Call DrawTo()
        X9 = 1200 : Y9 = 2050 : Call MoveTo()
        PrintLine(ipr, "P" & at1(51)) '"PFunct. Point"
        X9 = 1200 : Y9 = 2360 : Call MoveTo()
        PrintLine(ipr, "PItem ")
        X9 = 1350 : Y9 = 2360 : Call MoveTo()
        Xstr = Item : Call PrintStr()
        SetSpess(4)
        X9 = 320 : Y9 = PTOTALE / AX * 100 + 1000 : Call MoveTo() 'corretto P in PTOTALE (LP, 25/05/2002)
        X9 = 390 + Q / AY * 100 : Y9 = PTOTALE / AX * 100 + 1000 : Call DrawTo() 'corretto P in PTOTALE (LP, 25/05/2002)
        If FANEF > 0 Then
            X9 = 1580 : Y9 = FANEF * 10 : Call MoveTo()
            X9 = Q / AY * 100 + 320 : Y9 = FANEF * 10 : Call DrawTo()
        End If
        X9 = 320 : Y9 = kW / AZ * 100 + 100 : Call MoveTo()
        X9 = 380 + Q / AY * 100 : Y9 = kW / AZ * 100 + 100 : Call DrawTo()
        X9 = 0 : Y9 = 0 : Call MoveTo()
    End Sub

    Private Sub PrintStr()
        X1 = "P" & Xstr
        PrintLine(ipr, X1) ': Return
    End Sub

    Private Sub DrawTo()
        X1 = "D" & Str(Int(X9)) & "," & Str(Int(Y9))
        PrintLine(ipr, X1) ': Return
    End Sub

    Private Sub MoveTo(Optional ByRef x As Object = Nothing, Optional ByRef y As Object = Nothing)
        'UPGRADE_NOTE: IsMissing() è stata cambiata in IsNothing(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If Not IsNothing(x) And Not IsNothing(y) Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto x. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X9 = x
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto y. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Y9 = y
        End If
        X1 = "M" & Str(Int(X9)) & "," & Str(Int(Y9))
        PrintLine(ipr, X1) ': Return ' GoTo 20200
    End Sub

    Public Sub StubParabole()
        Dim i, j As Short
        Dim daDove As Short
        Dim Fattore As Single
        Risult.Basic = 0
        daDove = -1
        Fattore = 1 + (TipoGap - 1) * 0.05263
        If Len(Trim(Dati.Sigla)) = 0 Then Stop
        If Asc(Dati.Sigla) < 32 Then Stop
        Dati.CorrRd = CorrRd
        HTR9B(daDove, Dati, Risult, 0, 0, Int(CDbl(daISA)))
        'FPARABOLE idPala, H, Npal, 0, Risult
        kW = Dati.HP * 0.735
        With Risult
            If .MaxI > 7 Then
                For i = 1 To .MaxI Step 2
                    dD(1 + i \ 2) = .AP(i) * Fattore '* k
                    EE(1 + i \ 2) = .BP(i) * Fattore '* k
                    FF(1 + i \ 2) = .CP(i) * Fattore '* k
                    AA(1 + i \ 2) = .AR(i)
                    BB(1 + i \ 2) = .BR(i)
                    CC(1 + i \ 2) = .CR(i)
                    For j = 1 To 2
                        AB(1 + i \ 2, j) = .AB(i, j)
                        '   AC(1 + i \ 2, j) = .AC(i, j) * k
                        Recup = 1 / CoeffPD * (.AB(i, j) / (PI / 4 * (1.524 + 400.8 * V3 / D) ^ 2)) ^ 2
                        PD = (.AB(i, j) / AQ) ^ 2 / CoeffPD
                        AC(1 + i \ 2, j) = .AC(i, j) * Fattore '* k + PD * k * RecPerd - 0.7 * (PD - Recup) * k       ': GoTo 7070
                    Next
                Next
                MaxAngles = .MaxI \ 2 + 1
            Else
                For i = 1 To .MaxI
                    dD(i) = .AP(i) * Fattore '* k
                    EE(i) = .BP(i) * Fattore '* k
                    FF(i) = .CP(i) * Fattore '* k
                    AA(i) = .AR(i)
                    BB(i) = .BR(i)
                    CC(i) = .CR(i)
                    For j = 1 To 2
                        AB(i, j) = .AB(i, j)
                        '   AC(i, j) = .AC(i, j) * k
                        Recup = 1 / CoeffPD * (.AB(i, j) / (PI / 4 * (1.524 + 400.8 * V3 / D) ^ 2)) ^ 2
                        PD = (.AB(i, j) / AQ) ^ 2 / CoeffPD
                        AC(i, j) = .AC(i, j) * Fattore 'k + PD * k * RecPerd - 0.7 * (PD - Recup) * k       ': GoTo 7070
                    Next
                Next
                MaxAngles = .MaxI
            End If
        End With
    End Sub
    Private Function indAng(ByRef Q As Single, ByRef p As Single) As Single
        Dim i As Short
        Dim pr, pr0 As Single
        For i = 1 To MaxAngles
            pr = dD(i) * Q ^ 2 + EE(i) * Q + FF(i)
            If pr > p Then Exit For
        Next
        If pr < p Then
            indAng = -1
        ElseIf i > 1 Then
            pr0 = dD(i - 1) * Q ^ 2 + EE(i - 1) * Q + FF(i - 1)
            indAng = i + (p - pr0) / (pr - pr0) - 1
        Else
            indAng = 0
        End If
    End Function
    Private Function eta(ByRef Q As Single, ByRef p As Single) As Single
        Dim iA As Single
        Dim i As Short
        Dim iAn(3) As Single
        Dim ix As Short
        Dim etax(3) As Single
        Dim abc(3) As Single
        Dim etam, etaz As Single
        iA = indAng(Q, p)
        Select Case iA
            Case 0, -1
                eta = 0
            Case Else
                i = Int(iA)
                etax(1) = AA(i) * Q ^ 2 + BB(i) * Q + CC(i)
                iAn(1) = i
                etax(2) = AA(i + 1) * Q ^ 2 + BB(i + 1) * Q + CC(i + 1)
                iAn(2) = i + 1
                'If iA - i < 0.5 Then ix = i - 1 Else ix = i + 2
                ix = i - 1
                'If ix = 0 Then ix = 3
                'If ix > MaxAngles Then ix = i - 1
                If ix > 0 Then
                    etax(3) = AA(ix) * Q ^ 2 + BB(ix) * Q + CC(ix)
                    iAn(3) = ix
                    Regresso(iAn, etax, abc)
                    etaz = abc(1) * iA ^ 2 + abc(2) * iA + abc(3)
                Else
                    etaz = 0
                End If
                ix = i + 2
                If ix <= MaxAngles Then
                    etax(3) = AA(ix) * Q ^ 2 + BB(ix) * Q + CC(ix)
                    iAn(3) = ix
                    Regresso(iAn, etax, abc)
                    etam = abc(1) * iA ^ 2 + abc(2) * iA + abc(3)
                Else
                    etam = 0
                End If
                'eta = etax(1) + (etax(2) - etax(1)) * (iA - i)
                If etam = 0 Then
                    eta = etaz
                ElseIf etaz = 0 Then
                    eta = etam
                Else
                    eta = (iA - i) * etaz + (i + 1 - iA) * etam
                End If
                'eta = abc(1) * iA ^ 2 + abc(2) * iA + abc(3)
        End Select
    End Function

    Public Sub SetSpess(ByRef s As Short)
        Dim t As String
        t = "J" & Trim(Str(s))
        PrintLine(ipr, t)
    End Sub

    Public Function fdedp(ByRef Q As Single, ByRef p As Single) As Object
        Dim eta1, eta2 As Single
        eta1 = eta(Q, p) / 100
        eta2 = eta(Q, 1.001 * p) / 100
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto fdedp. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        fdedp = (eta2 - eta1) / (0.001 * p)
    End Function
    Public Function fdedq(ByRef Q As Single, ByRef p As Single) As Object
        Dim eta1, eta2 As Single
        eta1 = eta(Q, p) / 100
        eta2 = eta(1.001 * Q, p) / 100
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto fdedq. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        fdedq = (eta2 - eta1) / (0.001 * Q)
    End Function
    Public Sub Regresso(ByRef A() As Single, ByRef b() As Single, ByRef abc() As Single)
        Dim a2, a1, a3 As Single
        Dim D2, Y1, D1, D3 As Single
        Dim G2, G1, G3 As Single
        a1 = A(1) ^ 2 * (A(2) - A(3))
        a2 = -A(2) ^ 2 * (A(1) - A(3))
        a3 = A(3) ^ 2 * (A(1) - A(2))
        Y1 = a1 + a2 + a3
        D1 = b(1) * (A(2) - A(3))
        D2 = -b(2) * (A(1) - A(3))
        D3 = b(3) * (A(1) - A(2))
        abc(1) = (D1 + D2 + D3) / Y1 ' AA, BB, CC coeff. polinomio 2° grado per rend.
        G1 = A(1) ^ 2 * (b(2) - b(3))
        G2 = -A(2) ^ 2 * (b(1) - b(3))
        G3 = A(3) ^ 2 * (b(1) - b(2))
        abc(2) = (G1 + G2 + G3) / Y1
        abc(3) = -abc(1) * A(1) ^ 2 - abc(2) * A(1) + b(1)
    End Sub
    Public Sub GetLingua()
        Dim ifl, i As Short
        ifl = FreeFile()
        If iLingua = 0 Then iLingua = 1
        Select Case iLingua
            Case 1 : FileOpen(ifl, Base & "\FANITA.TXT", OpenMode.Input, , OpenShare.Shared)
            Case 2 : FileOpen(ifl, Base & "\FANFRA.TXT", OpenMode.Input, , OpenShare.Shared)
            Case 3 : FileOpen(ifl, Base & "\FANING.TXT", OpenMode.Input, , OpenShare.Shared)
        End Select
        For i = 1 To 55 : at1(i) = LineInput(ifl) : Next
        FileClose(ifl)

    End Sub
End Module