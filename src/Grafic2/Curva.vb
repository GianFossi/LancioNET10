Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Curva
    Inherits Membratura
    Private prDiametro As Single
    Private prApertura As Single 'angolo al centro in gradi
    Public Raggio As Single 'raggio di curvatura
    Private prSpessBase As Single
    Public SpessRive As Single
    Public SpessPar As Single
    'Public TipoMat As Short '1,2,3,4
    'Public TipoS As Short '0 a gusci 1 a spicchi
    Public DueMeta As Boolean
    Public Numero As Short 'numero di spicchi
    '----------------------
    Private prStandardPip As LibMat.clsPipe
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Private b, A, prLunghezza As Single
    Private di, de As Single
    Private E As Short
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
    Public Overrides Property StandardPip() As LibMat.clsPipe
        Get
            Return prStandardPip
        End Get
        Set(ByVal Value As LibMat.clsPipe)
            prStandardPip = Value
        End Set
    End Property
    Public Overrides Property Apertura() As Single
        Get
            Return prApertura
        End Get
        Set(ByVal Value As Single)
            prApertura = Value
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
                Code = 9
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
        ' SalvaLav
    End Sub
    'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        GenMem.Denom = "CURVA"
        Variato = True
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    'UPGRADE_NOTE: Class_Terminate è stato aggiornato a Class_Terminate_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: È possibile che l'oggetto GenMem non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        GenMem = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto Standard non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Standard = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Pesi()
        GenMem.LeggiMat((TipoMat))
        GenMem.PesiSp((TipoMat))
        Select Case TipoS
            Case 0
                prLunghezza = Raggio * Apertura * PI / 180
                If TipoMat > 1 Then
                    GenMem.Pnet0 = ((Diametro + SpessBase) * PI * prLunghezza) * SpessBase * GenMem.PesoSp1 '* EXP9 'cilindro riportato senza riporto
                    GenMem.Pnet1 = ((Diametro + SpessRive) * PI * prLunghezza) * SpessRive * GenMem.PesoSp2 '* EXP9 'riporto
                Else
                    GenMem.Pnet0 = ((Diametro + SpessBase) * PI * prLunghezza) * (SpessBase * GenMem.PesoSp1 + SpessRive * GenMem.PesoSp2) ' * EXP9 'cilindro semplice o placato
                    GenMem.Pnet1 = 0
                End If
            Case 1
                MsgBox("da programmare 1 in Curva")
        End Select
        '**************************************************************************
        'PESOLORDO
        Select Case GenMem.LavorEst
            Case False
                If GenMem.Classe1 <> 7 Then
                    GenMem.plor0 = GenMem.Pnet0
                    GenMem.Plor1 = GenMem.Pnet1
                Else
                    MsgBox("Curva: da programmare") 'GoSub LorFuc
                End If
            Case True
                If GenMem.Classe1 < 9 Then
                    GenMem.plor0 = (((Diametro + (SpessBase + SpessRive)) * PI * prLunghezza) * (SpessBase + SpessRive) * GenMem.PesoSp1)
                Else
                    GenMem.plor0 = ((Diametro + SpessBase) * PI * prLunghezza * SpessBase * GenMem.PesoSp1)
                End If
        End Select
        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
    End Sub

    Public Sub StringDIME()
        Dim Note(6) As String
        Dim T1str, Dstr, T2str As String
        Dim AngStr As String
        Dim Rstr As String
        Select Case TipoS
            Case 0
                If GenMem.Classe1 = 6 Then 'pipe
                    Dstr = LTrim(Microsoft.VisualBasic.Strings.Format(Diametro, "####.##"))
                    T1str = LTrim(Microsoft.VisualBasic.Strings.Format(SpessBase, "####.##"))
                    T2str = Microsoft.VisualBasic.Strings.Format(SpessRive, "####.##")
                    AngStr = Microsoft.VisualBasic.Strings.Format(Apertura, "####.##")
                    Rstr = LTrim(Microsoft.VisualBasic.Strings.Format(Raggio, "####.##"))
                    If TipoMat > 1 Then
                        Note(2) = "De" & Dstr & " sp." & T1str & "+" & T2str & "ap." & AngStr & "° R." & Rstr
                    Else
                        Note(2) = "De" & Dstr & " sp." & T1str & " ap." & AngStr & "° R." & Rstr
                    End If
                Else
                    MsgBox("da programmare, curva stringDime")
                End If
            Case 1
                MsgBox("da programmare, curva stringDime")
        End Select
        GenMem.Dimensioni = Note(2)
    End Sub
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        Dim i As Short
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
    End Sub
    Private Sub StringNOTE()
        Dim Note As String = ""
        'If Abs(GenMem.Tipo) = 2 And GenMem.Classe1 = 6 Then
        '      Note = "PIPE"
        'Else
        'If GenMem.Classe1 = 7 Then
        '330   Note = "FUCINATO Di" + Str$(de) + " /" + Str$(di) + " L" + Str$(Int(Lunghezza + NumVir * l))
        'Else
        '      Note = "LAMIERA" + Str$(b) + " x" + Str$(a) + " x" + Str$(SpessPar)
        'End If
        'End If
        'If Len(Note) >= 32 Then Note = Mid$(Note, 1, 32) Else Note = Note + String$((32 - Len(Note)), 32)
        GenMem.Note = Note
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        Select Case TipoS
            Case 0 'a gusci
                grezzo.Variab(1) = SpessBase
                grezzo.Variab(2) = Raggio
                grezzo.Variab(3) = Apertura
                grezzo.Vartxt(1) = "GOM "
            Case 1 'a spicchi
                MsgBox("Curva a spicchi da programmare")
        End Select
        '   Select Case TipoMat
        '      Case 3 ' WO
        '         GenMem.IniziaGrezzo grezzo
        '         If grezzo Is Nothing Then Exit Sub
        '         grezzo.Vartxt(1) = "WO  "
        '         GenMem.WOGrezzo grezzo
        '   End Select
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Spessore = SpessBase + SpessRive
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overloads Sub Copia(ByRef A As Curva)
        If A Is Nothing Then A = New Curva
        A.Diametro = Diametro
        A.Apertura = Apertura
        A.SpessBase = SpessBase
        A.SpessRive = SpessRive
        A.SpessPar = SpessPar
        A.TipoMat = TipoMat
        A.Raggio = Raggio
        A.TipoS = TipoS
        A.DueMeta = DueMeta
        A.Numero = Numero
        'A.Standard As New LibMat.clsPipe
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
End Class