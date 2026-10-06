Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class clsGuarniz
    Inherits Membratura
    Public StandardGua As LibMat.clsGuarn
    Public DiamMed As Single
    Public Largh As Single
    Private prSpess As Single
    Public LarghExt As Single
    Public LarghInt As Single
    Public SpessAn As Single
    'Public TipoMat As Short
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Overrides Property Spess() As Single
        Get
            Return prSpess
        End Get
        Set(ByVal Value As Single)
            prSpess = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                'GenMem.Leggiprezzi(0, 0, 0)
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

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Vartxt(1) = "GU  "
        'grezzo.Vartxt(2) = StandardGua.DN
        grezzo.Dimens(1) = DiamMed + Largh 'LarghExt
        grezzo.Dimens(2) = DiamMed - Largh 'LarghInt
        grezzo.Dimens(3) = Spess
    End Sub
    Public Overloads Sub Pesi()
        Dim peso As Single
        GenMem.LeggiMat(TipoMat)
        GenMem.PesiSp(TipoMat)
        If GenMem.PesoSp1 = 0 Then
            GenMem.PesoSp = 7800
            GenMem.PesiSp(TipoMat)
        End If
        peso = DiamMed * PI * Largh * Spess * GenMem.PesoSp1
        GenMem.Pnet0 = peso * EXP9
        GenMem.plor0 = GenMem.Pnet0 ' * EXP9
        GenMem.Psfri0 = 0
        'GenMem.Converti
        GenMem.PNET = GenMem.Pnet0
    End Sub
    Public Sub StringDIME()
        Dim DIMR1, DIMR2 As String
        DIMR1 = "GUARNIZIONE" & Left(StandardGua.ClassS, 10) & ". "
        DIMR2 = "D.med " & Str(DiamMed) & "x " & Str(Largh)
        GenMem.Dimensioni = DIMR1 & DIMR2
    End Sub
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Public Sub StringNOTE()
        GenMem.Note = StandardGua.TipoS
    End Sub
    Public Sub New()
        MyBase.New()
        StandardGua = New LibMat.clsGuarn
        GenMem = New clsGenMem
        GenMem.Parent = Me
        GenMem.LavorEst = True
        TipoMat = 1
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        StandardGua = Nothing
        MyBase.Finalize()
    End Sub
    Public Overrides Property DiamExt() As Single
        Get
            DiamExt = DiamMed + Largh
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property DiamInt() As Single
        Get
            DiamInt = DiamMed - Largh
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property Diametro() As Single
        Get
            Diametro = Diamint
        End Get
        Set(ByVal Value As Single)
            '  DiamInt = vNewValue
        End Set
    End Property
    Public Overloads Sub Copia(ByRef A As clsGuarniz)
        If Not StandardGua Is Nothing Then StandardGua.Copia((A.StandardGua))
        A.DiamMed = DiamMed
        A.Largh = Largh
        A.Spess = Spess
        A.LarghExt = LarghExt
        A.LarghInt = LarghInt
        A.SpessAn = SpessAn
        A.TipoMat = TipoMat
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
End Class