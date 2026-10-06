Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
<Serializable()> Public Class Cilindro
    Inherits Membratura
    Private prDiametro As Single
    Private prLunghezza As Single
    Private prSpessBase As Single
    Public SpessRive As Single
    Public SpessPar As Single
    'Public TipoMat As Short '1,2,3,4
    Public Virolamento As New OggList(0)
    Public NumVir As Short
    Public AngTegola As Single
    Public Tnear As Single
    Public Tfar As Single
    Public Hnear As Single
    Public Hfar As Single
    Private prRanda As Single
    Private prSpostLat As Single
    Public HRANZA As Single
    '----------------------
    Private prStandardPip As LibMat.clsPipe
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Private A, b As Single
    Private TOLE, TOLI, l As Short
    Private di, de As Single
    Private E As Short
    Private deltaLun As Single
    Public Overrides Property SpostLat() As Single
        Get
            Return prSpostLat
        End Get
        Set(ByVal Value As Single)
            prSpostLat = Value
        End Set
    End Property
    Public Overrides Property SpessBase() As Single
        Get
            Return prSpessBase
        End Get
        Set(ByVal Value As Single)
            prSpessBase = Value
        End Set
    End Property
    Public Overrides Property Diametro() As Single
        Get
            Return prDiametro
        End Get
        Set(ByVal Value As Single)
            prDiametro = Value
        End Set
    End Property
    Public Overrides Property Lunghezza() As Single
        Get
            Return prLunghezza
        End Get
        Set(ByVal Value As Single)
            prLunghezza = Value
        End Set
    End Property
    Public Overrides Property Randa() As Single
        Get
            Return prRanda
        End Get
        Set(ByVal Value As Single)
            prRanda = Value
        End Set
    End Property
    Public Overrides Property StandardPip() As LibMat.clsPipe
        Get
            Return prStandardPip
        End Get
        Set(ByVal Value As LibMat.clsPipe)
            prStandardPip = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Dim Code As Short
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                If GenMem.Classe1 = 7 Then
                    Code = 6
                    StandardPip.Diam = Diametro
                    StandardPip.Spess = SpessBase
                    StandardPip.Cerca(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                End If
                GenMem.Leggiprezzi(Int(SpessPar - SpessRive), Int(SpessRive), 0, Code)
                StringDIME()
                StringMATE()
                StringNOTE()
                If IUNL < 5 Then CalcGrezzi()
                Variato = False
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
        'SalvaLav
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        StandardPip = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub NVirLam()
        Dim NVIR As Short
        If job Is Nothing Then Exit Sub
        If GenMem.Classe1 = 7 Then Exit Sub
        If Lunghezza + deltaLun < job.Comm.LargM Then
            Virolamento.Add(1)
            Virolamento.Add(Int(Lunghezza + deltaLun))
            NumVir = 1
        Else
            If job.Comm.LargM = 0 Then job.Comm.LargM = 2500
            NVIR = (Lunghezza + deltaLun) \ job.Comm.LargM
            Virolamento.Add(NVIR)
            Virolamento.Add(job.Comm.LargM)
            Virolamento.Add(1)
            Virolamento.Add(Int(Lunghezza + deltaLun - NVIR * job.Comm.LargM))
            NumVir = NVIR + 1
        End If
    End Sub
    Public Overloads Sub Pesi()
        GenMem.LeggiMat((TipoMat))
        GenMem.PesiSp((TipoMat))
        If IUNL < 5 And System.Math.Abs(GenMem.Tipo) = 1 Then NVirLam()
        If Randa = 0 Then
            deltaLun = 0
        Else
            If Randa ^ 2 > ((Diametro + 2 * Spessore) / 2) ^ 2 Then
                deltaLun = Randa - System.Math.Sqrt(Randa ^ 2 - ((Diametro + 2 * Spessore) / 2) ^ 2)
            Else
                Randa = 0
                deltaLun = 0
            End If
        End If
        If TipoMat > 1 Then
            GenMem.Pnet0 = ((Diametro + SpessBase) * PI * (Lunghezza + deltaLun / 2)) * SpessBase * GenMem.PesoSp1 '* EXP9 'cilindro riportato senza riporto
            GenMem.Pnet1 = ((Diametro + SpessRive) * PI * (Lunghezza + deltaLun / 2)) * SpessRive * GenMem.PesoSp2 '* EXP9 'riporto
        Else
            GenMem.Pnet0 = ((Diametro + SpessBase) * PI * (Lunghezza + deltaLun / 2)) * (SpessBase * GenMem.PesoSp1 + SpessRive * GenMem.PesoSp2) ' * EXP9 'cilindro semplice o placato
            GenMem.Pnet1 = 0
        End If
        If System.Math.Abs(GenMem.Tipo) = 34 Then GenMem.Pnet0 = GenMem.Pnet0 * AngTegola / 360 : GenMem.Pnet1 = GenMem.Pnet1 * AngTegola / 360
        '**************************************************************************
        'PESOLORDO
        Select Case GenMem.LavorEst
            Case False
                Select Case GenMem.Classe1
                    Case 1, 2
                        LorLam()
                    Case 7
                        LorFuc()
                    Case 6 'tronchetti
                        GenMem.plor0 = (((Diametro + (SpessBase + SpessRive)) * PI * (Lunghezza + deltaLun)) * (SpessBase + SpessRive) * GenMem.PesoSp1)
                End Select
            Case True
                'VFuori:
                If GenMem.Classe1 < 9 Then
                    GenMem.plor0 = (((Diametro + (SpessBase + SpessRive)) * PI * (Lunghezza + deltaLun)) * (SpessBase + SpessRive) * GenMem.PesoSp1)
                Else
                    GenMem.plor0 = ((Diametro + SpessBase) * PI * (Lunghezza + deltaLun) * SpessBase * GenMem.PesoSp1)
                End If
        End Select
        If System.Math.Abs(GenMem.Tipo) = 34 Then GenMem.plor0 = GenMem.plor0 * AngTegola / 360 : A = CShort(A * AngTegola / 360)
        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
    End Sub
    Private Sub LorLam()
        'PESO LORDO DA LAMIERA
        'A=lunghezza lorda virola
        'B=sviluppo lordo virola
        'TF=spessore lordo
        If TipoMat <> 2 Then 'diverso da placcato per esplosione
            If SpessBase > 80 Then SpessPar = Int(SpessBase * 1.015) + 1 Else SpessPar = SpessBase
        Else
            If (SpessBase + SpessRive) > 80 Then SpessPar = Int((SpessBase + SpessRive) * 1.015) + 1 Else SpessPar = (SpessBase + SpessRive)
        End If
        GenMem.TAGLIO = GenMem.MargTag(SpessPar)
        If SpessPar <= 50 Then b = Int((Diametro + SpessPar) * PI + GenMem.TAGLIO)
        If SpessPar > 50 Then b = Int((Diametro + SpessPar) * PI + 6 * SpessPar)
        A = Int(Lunghezza + deltaLun + (NumVir + 1) * GenMem.TAGLIO)
        GenMem.plor0 = A * b * SpessPar * GenMem.PesoSp1 'Peso lordo virola da lamiera
        '*************************************************************************
    End Sub
    Private Sub LorFuc()
        'PESO LORDO VIROLA DA FUCINATO
        'Nø VIROLE FORGIATE E LIMITI FORGIATO
        If Diametro <= 350 Then
            TOLI = 30 : TOLE = 25 : l = 40
        ElseIf Diametro <= 600 Then
            TOLI = 35 : TOLE = 30 : l = 40
        ElseIf Diametro <= 900 Then
            TOLI = 40 : TOLE = 35 : l = 50
        ElseIf Diametro <= 1200 Then
            TOLI = 45 : TOLE = 40 : l = 50
        ElseIf Diametro > 1200 Then
            TOLI = 45 : TOLE = 40 : l = 50
        End If
        di = (Diametro - TOLI)
        If di <= 600 Then
            E = 80
        ElseIf di <= 900 Then
            E = 100
        ElseIf di > 900 Then
            E = 120
        End If
        If (di + (2 * E)) > (Diametro + (2 * SpessBase) + TOLE) Then
            de = (di + (2 * E))
        Else
            de = (Diametro + (2 * SpessBase) + TOLE)
        End If
        '     If Diametro <= 700 Then
        '            k = (6000 - L)
        '     ElseIf di < 900 Then
        '            k = (4500 - L)
        '     ElseIf di >= 900 Then
        '            k = (3000 - L)
        '     End If
        '-----------------------------------
        '   If di < 130 Then
        '       a$ = " SEI FUORI DAI PARAMETRI DEL FUCINATO: |"
        '       a$ = a$ + " Desideri cambiare qualche dato? |"
        '       junk = Alert(4, Stringa1$(4), 4, 3, 11, 48, "SI", "NO", "")
        '       If junk = 1 Then Return
        '    End If
        GenMem.plor0 = ((de ^ 2 - di ^ 2) * (PI / 4) * Int(Lunghezza + deltaLun + (NumVir * l)) * GenMem.PesoSp1)
    End Sub

    Public Sub StringDIME()
        Dim i, ifl As Short
        Dim Stringa1(5) As String
        Dim Note(6) As String
        Dim T1str, Dstr, T2str As String
        Dim NVstr As String = ""
        Dim LCstr As String = ""
        Dim AngStr As String = ""
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\CALA15.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 5 : Stringa1(i) = LineInput(ifl) : Next
        FileClose(ifl)
        If System.Math.Abs(GenMem.Tipo) = 2 And GenMem.Classe1 = 6 Then
            Stringa1(1) = "De"
            Dstr = GlobalRoutines.FormatS("####.##", Diametro)
            T1str = GlobalRoutines.FormatS("####.##", SpessBase)
            T2str = GlobalRoutines.FormatS("####.##", SpessRive)
            LCstr = LTrim(Str(Int(Lunghezza)))
            If TipoMat > 1 Then
                Note(2) = Stringa1(1) & Dstr & Stringa1(2) & T1str & Stringa1(3) & T2str & Stringa1(4) & LCstr
            Else
                Note(2) = Stringa1(1) & Dstr & Stringa1(2) & T1str & Stringa1(4) & LCstr
            End If
        Else
            Dstr = LTrim(Str(Int(Diametro)))
            T1str = LTrim(Str(Int(SpessBase)))
            T2str = Str(Int(SpessRive))
            LCstr = LTrim(Str(Int(Lunghezza)))
            NVstr = LTrim(Str(NumVir))
            AngStr = GlobalRoutines.myStr(AngTegola, 4, 2, False)
            If TipoMat > 1 Then
                Note(2) = Stringa1(1) & Dstr & Stringa1(2) & T1str & Stringa1(3) & T2str & Stringa1(4) & LCstr & Stringa1(5) & NVstr
                'Note(6) = Stringa1(2) + T2str
                'Note(2) = Note(2) + " " + Note(6)
            Else
                Note(2) = Stringa1(1) & Dstr & Stringa1(2) & T1str & Stringa1(4) & LCstr & Stringa1(5) & NVstr
            End If
        End If
        If GenMem.Tipo = 34 Then Note(2) = Note(2) & AngStr & "°"
        If Len(Note(2)) < 51 Then Note(2) = Chr(32) & Note(2) & New String(Chr(32), 51 - Len(Note(2))) & Chr(32) Else Note(2) = Chr(32) & Mid(Note(2), 1, 51) & Chr(32)
        GenMem.Dimensioni = Note(2)
    End Sub
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        Dim i As Short
        'sistemare il materiale della seconda riga
        Try
            M0 = GenMem.MaterNome(1).Trim
            If M0 = "" Then M0 = GenMem.Materiale.Trim
            If SpessRive <> 0 And GenMem.Classe2 = 2 Then
                M1 = GenMem.MaterNome(2).Trim
                Riga = M0 & " + " & M1
            Else 'hh
                Riga = M0
            End If
            If Len(Riga) < 30 Then Riga = Chr(32) & Riga & New String(Chr(32), 30 - Len(Riga)) & Chr(32) Else Riga = Chr(32) & Mid(Riga, 1, 30) & Chr(32)
            GenMem.Materiale = Riga
        Catch
        End Try
    End Sub
    Private Sub StringNOTE()
        Dim Note As String
        Note = New String(Chr(32), 32)
        If System.Math.Abs(GenMem.Tipo) = 2 And GenMem.Classe1 = 6 Then
            Note = "PIPE"
        Else
            If GenMem.Classe1 = 7 Then
330:            Note = "FUCINATO Di" & Str(de) & " /" & Str(di) & " L" & Str(Int(Lunghezza + NumVir * l))
            Else
                Note = "LAMIERA" & Str(b) & " x" & Str(A) & " x" & Str(SpessPar)
            End If
        End If
        If Len(Note) >= 32 Then Note = Mid(Note, 1, 32) Else Note = Note & New String(Chr(32), 32 - Len(Note))
        GenMem.Note = Note
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        Select Case GenMem.Classe1
            Case 7
                grezzo.Dimens(1) = de
                grezzo.Dimens(2) = di
                grezzo.Variab(1) = GenMem.plor0
                grezzo.Variab(2) = Int(Lunghezza + deltaLun + NumVir * l)
                grezzo.Vartxt(1) = "AF  "
            Case 6 'tronchetto
                grezzo.Vartxt(1) = "TR  "
                grezzo.Dimens(1) = Diametro
                grezzo.Dimens(2) = SpessBase
                grezzo.Variab(2) = Lunghezza + deltaLun
            Case Else
                grezzo.Variab(1) = SpessPar
                grezzo.Vartxt(1) = "RE  "
                If GenMem.Classe2 = 2 Then
                    grezzo.Variab(2) = SpessRive
                    'grezzo.Variab(3) = Record(1).Indmat
                End If
                grezzo.Dimens(1) = b
                grezzo.Dimens(2) = A
                grezzo.Dimens(3) = 1
                grezzo.Dimens(4) = NumVir
        End Select
        Select Case TipoMat
            Case 3 ' WO
                GenMem.IniziaGrezzo(grezzo)
                grezzo.Vartxt(1) = "WO  "
                GenMem.WOGrezzo(grezzo)
        End Select
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Spessore = SpessBase + SpessRive
        End Get
        Set(ByVal Value As Single)
            SpessBase = Value
        End Set
    End Property
    Public Overrides Property Code7() As Short
        Get
            Code7 = 0 'If GenMem.Classe1 = 7 Then Code7 = 2 Else Code7 = 0
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = Spessore
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property

    Public Overloads Sub Copia(ByRef A As Cilindro)
        Dim v As Membratura
        If A Is Nothing Then A = New Cilindro
        A.Diametro = Diametro
        A.Lunghezza = Lunghezza
        A.SpessBase = SpessBase
        A.SpessRive = SpessRive
        A.SpessPar = SpessPar
        A.TipoMat = TipoMat
        Dim n As OggList.NodeP = Virolamento.nodeHead.Next
        While Not n Is Nothing
            v = n.TextData
            A.Virolamento.Add(v)
            n = n.Next
        End While
        A.NumVir = NumVir
        A.AngTegola = AngTegola
        A.Tnear = Tnear
        A.Tfar = Tfar
        A.Hnear = Hnear
        A.Hfar = Hfar
        'A.StandardPip As New LibMat.clsPipe
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
End Class