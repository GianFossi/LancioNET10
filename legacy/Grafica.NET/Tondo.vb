Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Tondo
    Inherits Membratura
    Private prLunghezza As Single
    Private prDiametro As Single
    'Public TipoMat As Short 'sempre 1
    Public isW As Boolean 'interruttore di disegnazione
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
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
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                GenMem.Leggiprezzi((Diametro), 0, 0)
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
        GenMem.Dimensioni = "TONDO " & GlobalRoutines.myStr(Lunghezza, 5, 0, False) & " De " & GlobalRoutines.myStr(Diametro, 4, 0, False) & " De" & Str(Diametro)
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
        GenMem.Pnet0 = PI / 4 * Diametro * Diametro * Lunghezza * GenMem.PesoSp1
        If GenMem.Classe1 = 3 Then
            GenMem.plor0 = GenMem.Pnet0
            ' Param% = 1
        Else
            GenMem.plor0 = 1.05 * GenMem.Pnet0 '???????????? (Larghezza + GenMem.MargTag(Int(Spessore))) * (Lunghezza + GenMem.MargTag(Int(Spessore))) * Spessore * GenMem.PesoSp1
            '   Param% = t
        End If
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        'LTO# = GuardaPrezzo#(prezzo0&, prezzo1&, 0, 0, Param%, 0, "--", PLOR0, 0!, 1)
        GenMem.PNET = GenMem.Pnet0
    End Sub
    Public Overrides Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Variab(1) = Diametro ' + GenMem.MargTag(Int(Spessore)) '+ Record(jRec).Dati(5) 'toll lav
        grezzo.Dimens(1) = Lunghezza
        grezzo.NPezzi = GenMem.Qta
        grezzo.Vartxt(1) = "TN  "
        'grezzo.Variab(1) = Spessore ' + Record(jRec).Dati(4) 'toll.lav
    End Sub
    Public Overrides Property Code7() As Short
        Get
            Code7 = 0
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = 0
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
End Class