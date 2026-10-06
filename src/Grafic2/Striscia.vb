Option Strict Off
Option Explicit On
<Serializable()> Public Class Striscia
    Inherits Membratura
    Private prLunghezza As Single
    Private prLarghezza As Single
    Private prSpessore As Single
    'Public TipoMat As Short 'sempre 1
    Public isW As Boolean 'interruttore di disegnazione
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Overrides Function Convalida() As Boolean
        Convalida = True
    End Function
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
        End Set
    End Property
    Public Overrides Property Larghezza() As Single
        Get
            Return prLarghezza
        End Get
        Set(ByVal Value As Single)
            prLarghezza = Value
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
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                GenMem.Leggiprezzi((Spessore), 0, 0)
                StringDIME()
                StringMATE()
                StringNOTE()
                CalcGrezzi()
                Variato = False
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        GenMem.LavorEst = True
        TipoMat = 1
        isW = True
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub StringDIME()
        GenMem.Dimensioni = "LAM. " & GlobalRoutines.myStr(Lunghezza, 5, 0, False) & " x " & GlobalRoutines.myStr(Larghezza, 4, 0, False) & " sp." & Str(Spessore)
    End Sub
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Private Sub StringNOTE()

    End Sub

    Public Overloads Sub Pesi()
        GenMem.LeggiMat(TipoMat)
        GenMem.PesiSp(TipoMat)
        GenMem.Pnet0 = Larghezza * Lunghezza * Spessore * GenMem.PesoSp1
        If GenMem.Classe1 = 3 Then
            GenMem.plor0 = GenMem.Pnet0
            ' Param% = 1
        Else
            '      PLOR = 1.05 * PNET
            GenMem.plor0 = (Larghezza + GenMem.MargTag(Int(Spessore))) * (Lunghezza + GenMem.MargTag(Int(Spessore))) * Spessore * GenMem.PesoSp1
            '   Param% = t
        End If
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        GenMem.PNET = GenMem.Pnet0
    End Sub

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Dimens(1) = Larghezza + GenMem.MargTag(Int(Spessore)) '+ Record(jRec).Dati(5) 'toll lav
        grezzo.Dimens(2) = Lunghezza + GenMem.MargTag(Int(Spessore))
        grezzo.NPezzi = GenMem.Qta
        grezzo.Vartxt(1) = "RE  "
        grezzo.Variab(1) = Spessore ' + Record(jRec).Dati(4) 'toll.lav
    End Sub
    Public Overrides Property Diametro() As Single
        Get
            Return 0
        End Get
        Set(ByVal Value As Single)
            Dim d As Single = Value
        End Set
    End Property

    Public Overloads Sub Copia(ByRef s As Striscia)
        If s Is Nothing Then s = New Striscia
        With s
            .Lunghezza = Lunghezza
            .Larghezza = Larghezza
            .Spessore = Spessore
            .TipoMat = TipoMat
            .isW = isW
            GenMem.Copia(.GenMem)
            s.GenMem.Parent = s
        End With
    End Sub
End Class