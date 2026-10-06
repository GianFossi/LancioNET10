Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Piastrone
    Inherits Membratura
    Private prSottoTipo As Short
    Private prSpessBase As Single '   .t = Dati(1)
    Private prDiamExt As Single '   .Adim = Dati(2)
    Public H1 As Single '   .H1 = Dati(3)
    Public B1 As Single '   .B1 = Dati(4)
    Public H2 As Single '   .H2 = Dati(5)
    Public B2 As Single '   .B2 = Dati(6)
    Public H3 As Single '   .H3 = Dati(7)
    Private prB3 As Single '   .B3 = Dati(8)
    Public H4 As Single
    Public B4 As Single
    Public SovraRid As Short
    Public AG, TG As Single
    'Public Variato As Boolean
    Private Ttot, Ttotv As Single
    Private HH As Single
    Private Driporto As Single
    Public SpessRive As Single '   .T1 = Dati(10) \ 900
    Public LargCava As Single '   .LargCava = .Dum \ 30:
    Public ProfCava As Single '  .ProfCava = .Dum - 30 * .LargCava
    'Public TipoMat As Short '1,2,3,4
    <NonSerialized()> Private Mom As Single
    <NonSerialized()> Private HG As Single
    <NonSerialized()> Private BG, PAN, PAL, B1G As Single
    <NonSerialized()> Private PH1L, H1G, PH2L As Single
    <NonSerialized()> Private PH2N, PH1N, PH3N As Single
    <NonSerialized()> Private P1N, P1L As Single
    <NonSerialized()> Private Look As New clsLook
    <NonSerialized()> Private Mom2, Mom1, Mom3 As Single
    <NonSerialized()> Private B2G, b, H, H2G As Single
    '----------------------
    'Public GenMem As clsGenMem
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        M0 = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        If SpessRive <> 0 And (GenMem.Classe2 = 2 Or GenMem.Classe2 = 9) Then
            M1 = GenMem.MaterNome(2).Trim
            Riga = M0 & " + " & M1
        Else 'hh
            Riga = M0
        End If
        If Len(Riga) < 30 Then Riga = Chr(32) & Riga & New String(Chr(32), 30 - Len(Riga)) & Chr(32) Else Riga = Chr(32) & Mid(Riga, 1, 30) & Chr(32)
        GenMem.Materiale = Riga
    End Sub
    Public Overrides Property SpessBase() As Single
        Get
            Return prSpessBase
        End Get
        Set(ByVal Value As Single)
            prSpessBase = Value
        End Set
    End Property
    Public Overrides Property SottoTipo() As Short
        Get
            Return prSottoTipo
        End Get
        Set(ByVal Value As Short)
            prSottoTipo = Value
        End Set
    End Property
    Public Overrides Property Diamext() As Single
        Get
            Return prDiamExt
        End Get
        Set(ByVal Value As Single)
            prDiamExt = Value
        End Set
    End Property
    Public Overrides Property B3() As Single
        Get
            Return prB3
        End Get
        Set(ByVal Value As Single)
            prB3 = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Aggiusta()
                Pesi()
                GenMem.Leggiprezzi(Int(GenMem.plor0), Int(SpessRive), 0, Code7)
                StringDIME()
                StringMATE()
                StringNOTE()
                CalcGrezzi()
                Variato = False
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
        ' SalvaLav
    End Sub
    Public Sub StringDIME()
        Dim ifl, i As Short
        Dim Stringa1(12) As String
        Dim DIME0 As String = ""
        Dim NOTE0 As String = ""
        Dim Note6 As String = ""
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\PIAS07.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 12 : Stringa1(i) = LineInput(ifl) : Next
        FileClose(ifl)
        If SovraRid Or GenMem.Classe1 = 7 Then
            NOTE0 = Stringa1(1) & Str(AG) & Stringa1(2) & Str(TG)
        Else
            NOTE0 = Stringa1(3) & Str(AG) & Stringa1(2) & Str(TG)
        End If
        If (H1 <> 0 Or H2 <> 0) And SottoTipo >= 4 And SottoTipo < 7 Then
            DIME0 = Stringa1(4) & Str(Diamext) & Stringa1(5) & Str(Ttot)
        End If
        If (H1 <> 0 Or H2 <> 0) And (SottoTipo < 4 Or SottoTipo = 7) Then
            DIME0 = Stringa1(4) & Str(Diamext) & Stringa1(5)
            If H1 > 0 Then DIME0 = DIME0 & Str(H1) & Stringa1(6) ' "+"
            DIME0 = DIME0 & LTrim(Str(SpessBase)) '  "+"
            If H2 > 0 Then DIME0 = DIME0 & Stringa1(6) & LTrim(Str(H2))
            NOTE0 = NOTE0 & Stringa1(7) '" sagomato"
        End If
        If H1 = 0 And H2 = 0 Then DIME0 = Stringa1(4) & Str(Diamext) & Stringa1(5) & Str(SpessBase)
        If TipoMat > 1 Then
            Select Case TipoMat
                Case 2 : Note6 = Stringa1(8) & Str(SpessRive)
                Case 3 : Note6 = Stringa1(9) & Str(SpessRive)
                Case 4 : Note6 = Stringa1(10) & Str(SpessRive)
            End Select
            If TipoMat > 4 Then Note6 = Note6 & Stringa1(11) ' " su entrambe le facce"
        End If
        If GenMem.MF = "PE" Or GenMem.MF = "PC" Then NOTE0 = Stringa1(12) & Str(Diamext) & Stringa1(5) & Str(Ttot) & "+" & Str(SpessRive)
        If GenMem.MF = "PE" Or GenMem.MF = "PC" Then NOTE0 = NOTE0 & Stringa1(6) & Str(SpessRive)
        If TipoMat > 1 Then DIME0 = DIME0 & Note6
        If TipoMat > 4 Then DIME0 = DIME0 & " x 2"
        GenMem.Dimensioni = DIME0
        GenMem.Note = NOTE0
    End Sub

    Public Sub StringNOTE()

    End Sub

    Public Overloads Sub Pesi()
        'PESO NETTO
        GenMem.LeggiMat((TipoMat))
        GenMem.PesiSp((TipoMat))
        Call CalcTT()
        On Error GoTo ErrPesi
        PAN = (Diamext ^ 2 * PI / 4 * Ttotv * GenMem.PesoSp1) 'disco conpleto
        Mom = PAN * Ttotv / 2.0!
        Traduci(Look)
        With Look
            Select Case SottoTipo
                Case 1
                    PH1N = .B1 ^ 2 * PI / 4 * .H1 * GenMem.PesoSp1 'Iø     codulo
                    PH2N = .B2 ^ 2 * PI / 4 * .H2 * GenMem.PesoSp1 'IIø    codulo
                    PH3N = 0
                Case 2
                    PH1N = .B1 ^ 2 * PI / 4 * .H1 * GenMem.PesoSp1 'Iø     codulo
                    PH2N = .B2 ^ 2 * PI / 4 * .H2 * GenMem.PesoSp1 'IIø    codulo
                    PH3N = (Diamext ^ 2 - .B3 ^ 2) * PI / 4 * .H3 * GenMem.PesoSp1 'IIIø   codulo
                Case 3, 7
                    PH1N = 0 'Iø     codulo
                    PH2N = .B2 ^ 2 * PI / 4 * .H2 * GenMem.PesoSp1
                    PH3N = (Diamext ^ 2 - .B3 ^ 2) * PI / 4 * .H3 * GenMem.PesoSp1 'IIIø   codulo
                Case 4
                    PH1N = (Diamext ^ 2 - .B1 ^ 2) * PI / 4 * .H1 * GenMem.PesoSp1 'Iø     codulo
                    PH2N = (Diamext ^ 2 - .B2 ^ 2) * PI / 4 * .H2 * GenMem.PesoSp1 'IIø    codulo
                    PH3N = 0
                Case 5, 6
                    PH1N = (Diamext ^ 2 - .B1 ^ 2) * PI / 4 * .H1 * GenMem.PesoSp1 'Iø     codulo
                    PH2N = (.B1 ^ 2 - .B2 ^ 2) * PI / 4 * .H2 * GenMem.PesoSp1 'IIø    codulo
                    PH3N = 0
            End Select
            If SottoTipo = 6 Then PH1N = 2 * PH1N : PH2N = 2 * PH2N
            Mom1 = PH1N * .H1 / 2
            If SottoTipo = 5 Then Mom2 = PH2N * .H2 / 2 Else Mom2 = PH2N * (.H1 + SpessBase + .H2 / 2)
            Mom3 = PH3N * (.H1 + SpessBase + .H3 / 2)
            GenMem.Pnet0 = (PAN - PH1N - PH2N - PH3N)
            Mom = (Mom - Mom1 - Mom2 - Mom3) / GenMem.Pnet0
            If SottoTipo = 6 Then Mom = SpessBase / 2
            '*************************************************************************
            'PESO LORDO
            'Call SovraMet DA METTERE COME BOTTONE
            If TG < SpessBase Or AG < Diamext Then Call SovraMet()
            If GenMem.Classe1 = 7 Then
                'PESO LORDO FORGIATO
                '   Call SovraMet(6)
                PAL = (AG ^ 2 * (PI / 4) * TG * GenMem.PesoSp1) 'disco completo
                If .B1 > 0 Then
                    b = .B1
                    SovraMetI()
                    H = .H1
                    SovraMetH()
                    B1G = BG : H1G = HG
                End If
                If .B2 > 0 Then
                    b = .B2
                    SovraMetI()
                    H = .H2
                    SovraMetH()
                    B2G = BG : H2G = HG
                End If
                PH1L = (CSng(B1G) ^ 2 * (PI / 4) * H1G * GenMem.PesoSp1) 'Iø    codulo
                PH2L = (CSng(B2G) ^ 2 * (PI / 4) * H2G * GenMem.PesoSp1) 'IIø   codulo
                If PH2L = 0 Or .H2 <= (.H1 / 3) Then PH2L = 0
                If PH1L <= PH2L Then PH2L = PH1L Else PH1L = PH2L
            Else
                'peso lordo da lamiera
                If SovraRid Then
                    '      AG = DiamExt + 6: TG = Ttot + 6
                    '      GoSub SpessLor: If y = -2 Then Return
                    '      Call SovraMet(6)
                    PAL = (AG ^ 2 * TG * GenMem.PesoSp1) * PI / 4
                Else
                    '      If GenMem.Classe2 = 2 Then TG = Ttot + 6 Else TG = Int(Ttot + (DiamExt * 0.01))
                    '      AG = DiamExt + 50
                    '      GoSub SpessLor: If y = -2 Then Return
                    '      Call SovraMet(50)
                    PAL = (AG ^ 2 * TG * GenMem.PesoSp1)
                End If
            End If
            If GenMem.Classe2 > 0 Then
                If .B1 > .B2 Then Driporto = .B1 Else Driporto = .B2
                ' If SottoTipo = 4 Then Driporto = DiamExt
                ' If SottoTipo = 5 Then Driporto = .B1
                P1N = (Driporto ^ 2 * (PI / 4) * SpessRive * GenMem.PesoSp2)
                If GenMem.Classe3 > 0 Then P1N = P1N * 2
                P1L = P1N
            End If
        End With
        GenMem.plor0 = (PAL - PH1L - PH2L)
        GenMem.Pnet1 = P1N
        GenMem.Plor1 = P1L
        'PESO LORDO = PESO NETTO
        'If GenMem.Classe2 = 2 Then
        '   GenMem.MF = "PE"
        'ElseIf GenMem.LavorEst Then
        '   GenMem.MF = "MF"
        '   GenMem.plor0 = GenMem.Pnet0
        '   GenMem.Plor1 = GenMem.Pnet1
        'Else
        '   GenMem.MF = "--"
        'End If
        If Not (GenMem.MF = "PE" Or GenMem.MF = "PC") And GenMem.Classe2 = 2 Then
            GenMem.Pnet0 = GenMem.Pnet0 + GenMem.Pnet1
            GenMem.plor0 = PAN + GenMem.Plor1
            GenMem.Pnet1 = 0 : GenMem.Plor1 = 0
        End If
        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
ExPesi: On Error GoTo 0
        Exit Sub
        '***********************************************************************
ErrPesi:
        If Err.Number = 6 Or Err.Number = 11 Then
            Resume ExPesi
        Else
            MsgBox(ErrorToString() & " in Piastrone-Pesi")
        End If
    End Sub
    Private Sub SovraMetI()
        'sovrametalli impronta
        If b < 600 Then
            BG = 0
        ElseIf b <= 750 Then
            BG = 450
        ElseIf b <= 900 Then
            BG = 600
        ElseIf b <= 1050 Then
            BG = 700
        ElseIf b > 1200 Then
            BG = 800
        ElseIf b < BG Then
            BG = 0
        End If
    End Sub
    Private Sub SovraMetH()
        If H < 50 Then
            HG = 0
            Exit Sub
        End If
        If H > 50 Then HG = H
        If H > 150 Then HG = 150
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        Select Case GenMem.Classe1
            Case 7
                grezzo.Vartxt(1) = "DF  "
                grezzo.Dimens(1) = AG
                grezzo.Dimens(2) = TG
            Case 1, 2
                grezzo.Vartxt(1) = "DI  "
                grezzo.Dimens(1) = AG
                grezzo.Dimens(2) = AG
                grezzo.Variab(1) = TG
        End Select
        Select Case TipoMat
            Case 3 ' WO
                GenMem.IniziaGrezzo(grezzo)
                grezzo.Vartxt(1) = "WO  "
                GenMem.WOGrezzo(grezzo)
        End Select
    End Sub

    Private Sub CalcTT()
        Dim H1c, H2c As Single
        H1c = H1 : H2c = H2
        If H1 < 0 Then H1c = 0
        If H2 < 0 Then H2c = 0
        Ttot = SpessBase + H1c + H2c
        Ttotv = SpessBase + H1 + H2
        If SottoTipo = 3 Or SottoTipo = 7 Then Ttot = SpessBase + H2 : Ttotv = Ttot
        If SottoTipo = 4 Then
            Ttot = SpessBase : Ttotv = Ttot
            If H1 < 0 Then Ttot = Ttot - H1
            If H2 < 0 Then Ttot = Ttot - H2
        End If
        If SottoTipo = 5 Or SottoTipo = 6 Then
            Ttotv = SpessBase
            If H1 < 0 And H2 < 0 Then
                HH = H1 : If H2 < H1 Then HH = H2
            ElseIf H1 < 0 Then
                HH = H1
            ElseIf H2 < 0 Then
                HH = H2
            Else
                HH = 0
            End If
            Ttot = SpessBase - HH
        End If

    End Sub
    Public Sub SovraMet()
        Dim c1, o1 As Single
        CalcTT()
        If GenMem.Classe1 = 7 Then
            o1 = 6
        Else
            If SovraRid Then o1 = 6 Else o1 = 50
        End If
        If SovraRid Then
            c1 = 6
        Else
            'PESO LORDO FORGIATO CON SOVRAMETALLI NORMALI
            If GenMem.Classe2 = 2 Then c1 = 6 Else c1 = Int(Ttot + (Diamext * 0.01)) - Ttot
            SovrametD(c1, o1)
        End If
        AG = Diamext + o1 : TG = Ttot + c1
        If (AG / 12) > TG Then TG = Int(AG / 12)
    End Sub
    '************************************************************************
    Private Sub SovrametD(ByVal c1 As Single, ByVal o1 As Single)
        'Sovrametalli disco forgiato
        If Diamext <= 400 Then
            o1 = 15 : c1 = 10
        ElseIf Diamext <= 700 Then
            o1 = 15 : c1 = 15
        ElseIf Diamext <= 1000 Then
            o1 = 20 : c1 = 20
        ElseIf Diamext <= 1400 Then
            o1 = 25 : c1 = 20
        ElseIf Diamext <= 1800 Then
            o1 = 30 : c1 = 25
        ElseIf Diamext <= 2200 Then
            o1 = 40 : c1 = 30
        ElseIf Diamext > 2200 Then
            o1 = 40 : c1 = 30
        End If
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        SottoTipo = 1
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub Traduci(ByRef Look As clsLook)
        With Look
            Select Case SottoTipo
                Case 1
                    .B1 = Diamext - 2 * B1
                    .H1 = H1
                    .B2 = Diamext - 2 * B2
                    .H2 = H2
                    .B3 = 0
                    .H3 = 0
                Case 2
                    .B1 = Diamext - 2 * B1
                    .H1 = H1 : .H2 = H2
                    .B3 = B3 + 2 * B2
                    .B2 = .B3 - 2 * B2
                    .H3 = SpessBase - H3 + H2
                Case 3, 7
                    .B1 = B1
                    .H1 = H1 : .H2 = H2
                    .B3 = B3 + 2 * B2
                    .B2 = .B3 - 2 * B2
                    .H3 = SpessBase - H3 - H1
                    .H4 = H4 : .B4 = B4
                Case 4, 5, 6
                    .B1 = B1 : .B2 = B2
                    .H1 = H1 : .H2 = H2
                    .H3 = 0 : .B3 = 0
            End Select
        End With
    End Sub

    Public Sub Converti(ByRef jRec As Short)
        'Dim Dummy As Single
        'Dim Lungo As Integer
        'Dim Look As New clsGenLook
        'GenMem.ConvertiPos(jRec)
        'SpessBase = RecordD(jRec).Dati(1)
        'DiamExt = RecordD(jRec).Dati(2)
        'Look.H1 = RecordD(jRec).Dati(3)
        'Look.B1 = RecordD(jRec).Dati(4)
        'Look.H2 = RecordD(jRec).Dati(5)
        'Look.B2 = RecordD(jRec).Dati(6)
        'Look.H3 = RecordD(jRec).Dati(7)
        'Look.B3 = RecordD(jRec).Dati(8)
        'SovraRid = -RecordD(jRec).Dati(9) \ 1000
        'Dummy = RecordD(jRec).Dati(9) + 1000 * SovraRid
        'GenMem.LavorEst = -Dummy \ 100
        'Dummy = Dummy + 100 * GenMem.LavorEst
        'SottoTipo = Dummy \ 10
        'TipoMat = Dummy - 10 * SottoTipo
        'If SottoTipo < 1 Then SottoTipo = 1
        'If TipoMat < 1 Then TipoMat = 1
        'SpessRive = RecordD(jRec).Dati(10) \ 900
        'Dummy = RecordD(jRec).Dati(10) - 900 * SpessRive
        'LargCava = Dummy \ 30
        'ProfCava = Dummy - 30 * LargCava
        'If SottoTipo = 3 Or SottoTipo = 7 Then
        'Look.H1 = RecordD(jRec).Dati(3) \ 100
        'Look.H4 = RecordD(jRec).Dati(3) - 100 * Look.H1
        'Look.H2 = RecordD(jRec).Dati(5) \ 100
        'If Look.H2 < 0 And Look.H2 * 100 > RecordD(jRec).Dati(5) + 1 Then Look.H2 = Look.H2 - 1
        'Look.H3 = RecordD(jRec).Dati(5) - 100 * Look.H2
        'Look.B4 = RecordD(jRec).Dati(7)
        'End If
        'Select Case SottoTipo
        '    Case 1
        'H1 = Look.H1
        'B1 = (DiamExt - Look.B1) / 2
        'H2 = Look.H2
        'B2 = (DiamExt - Look.B2) / 2
        '    Case 2
        'H1 = Look.H1
        'B1 = (DiamExt - Look.B1) / 2
        'H2 = Look.H2
        'B2 = (Look.B3 - Look.B2) / 2
        'B3 = Look.B3 - 2 * B2
        'H3 = SpessBase - Look.H3 + Look.H2
        '    Case 3, 7
        'H1 = Look.H1
        'B1 = Look.B1
        'H2 = Look.H2
        'B2 = (Look.B3 - Look.B2) / 2
        'B3 = Look.B3 - 2 * B2
        'H3 = SpessBase - Look.H3 - Look.H1
        'H4 = Look.H4
        'B4 = Look.B4
        '    Case 4, 5, 6
        'H1 = Look.H1
        'B1 = Look.B1
        'H2 = Look.H2
        'B2 = Look.B2
        'End Select
    End Sub
    Private Sub Aggiusta()
        Select Case SottoTipo
            Case 1
                B3 = Diamext - 2 * B2
            Case 4, 5, 6
                B3 = 0 : H3 = 0
                B4 = 0 : H4 = 0
        End Select
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Spessore = SpessBase + SpessRive
            If TipoMat > 4 Then Spessore = SpessBase + 2 * SpessRive
        End Get
        Set(ByVal Value As Single)
            SpessBase = Value
            SpessRive = 0
        End Set
    End Property
    Public Overrides Property Code7() As Short
        Get
            Dim ePiastra As Boolean
            If GenMem.Classe1 = 7 Then
                Dim Tubi As Tubi = Apparecchio.CercaTubi
                Dim Fascio As Fascio = Apparecchio.CercaFascio
                If Not Tubi Is Nothing Then
                    ePiastra = GenMem.posizione.SuChi Is Tubi Or Tubi Is GenMem.posizione.SuChi
                End If
                If Not ePiastra And Not Fascio Is Nothing Then
                    ePiastra = GenMem.posizione.SuChi Is Fascio Or Fascio Is GenMem.posizione.SuChi
                End If
                If Not ePiastra Then ePiastra = GenMem.Lato = 3
                If ePiastra Then
                    Code7 = 8 'PT
                Else
                    Code7 = 2 'dischi
                End If
            Else
                Code7 = 0
            End If
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = GenMem.PNET
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overloads Sub Copia(ByRef A As Piastrone)
        If A Is Nothing Then A = New Piastrone
        A.SottoTipo = SottoTipo
        A.SpessBase = SpessBase
        A.Diamext = Diamext
        A.H1 = H1
        A.B1 = B1
        A.H2 = H2
        A.B2 = B2
        A.H3 = H3
        A.B3 = B3
        A.H4 = H4
        A.B4 = B4
        A.SovraRid = SovraRid
        A.AG = AG
        A.TG = TG
        A.SpessRive = SpessRive
        A.LargCava = LargCava
        A.ProfCava = ProfCava
        A.TipoMat = TipoMat
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
End Class