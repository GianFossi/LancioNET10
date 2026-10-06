Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class clsTirante
    Inherits Membratura
    Public StandardTir As LibMat.clsTira
    Private prLunghezza As Single
    Public DiamScar As Single
    Public LunScar As Single
    Public nDadi As Short
    Public Tipo As String ' "T" tirante "P" prigioniero
    Public Dinst As Single
    'Public TipoMat As Short 'sempre 1
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    <NonSerialized()> Private xFilv As Short
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
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                Pesi()
                GenMem.Leggiprezzi(Param1, 0, 0)
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
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        GenMem.LavorEst = True
        StandardTir = New LibMat.clsTira
        TipoMat = 1
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        StandardTir = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub StringDIME()
        Dim DIMR1 As String = ""
        Dim DIMR2 As String = ""
        If Tipo = "T" Then DIMR1 = "TIRANTE " & StandardTir.DN & " L." & LTrim(Str(Lunghezza)) & " N° DADI =" & Str(nDadi)
        If Tipo = "P" Then DIMR1 = "PRIGION." & StandardTir.DN & " L." & LTrim(Str(Lunghezza)) & " N° DADI =" & Str(nDadi)
        If DiamScar < Val(CStr(StandardTir.Diam)) And DiamScar > 0 Then DIMR2 = " SC.d." & Str(DiamScar) & " L =" & Str(LunScar)
        GenMem.Dimensioni = DIMR1 & DIMR2
    End Sub
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub

    Private Sub StringNOTE()

    End Sub

    Public Overloads Sub Pesi()
        Dim peso, PesoD As Single
        peso = ((Val(CStr(StandardTir.Diam)) ^ 2 * (PI / 4) * Lunghezza) - ((Val(CStr(StandardTir.Diam)) ^ 2 - DiamScar ^ 2) * (PI / 4) * LunScar)) * GenMem.PesoSp1
        PesoD = (Val(CStr(StandardTir.Chia)) ^ 2 * 0.866 - (Val(CStr(StandardTir.Diam)) ^ 2 * PI / 4)) * (Val(CStr(StandardTir.Diam)) + 3) * GenMem.PesoSp1 * nDadi
        GenMem.Pnet0 = (peso + PesoD) * EXP9 * GenMem.Qta
        GenMem.plor0 = GenMem.Pnet0
        GenMem.Psfri0 = 0
        GenMem.PNET = GenMem.Pnet0
        'GenMem.Converti
    End Sub

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Vartxt(1) = "BU  "
        grezzo.Vartxt(2) = StandardTir.DN
        grezzo.Dimens(1) = Lunghezza
        grezzo.Dimens(2) = nDadi
        grezzo.Variab(1) = Val(CStr(StandardTir.Diam))
        grezzo.Dimens(3) = GenMem.Pnet0
    End Sub
    Public Overloads Sub Copia(ByRef A As clsTirante)
        If A Is Nothing Then A = New clsTirante
        If Not StandardTir Is Nothing Then StandardTir.Copia((A.StandardTir))
        A.Lunghezza = Lunghezza
        A.DiamScar = DiamScar
        A.LunScar = LunScar
        A.nDadi = nDadi
        A.Tipo = Tipo
        A.Dinst = Dinst
        A.TipoMat = TipoMat
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
    Public Overrides Property Param1() As Single
        Get
            Param1 = StandardTir.Diam
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property Code7() As Short
        Get
            Code7 = 0
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
End Class