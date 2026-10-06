Option Strict Off
Option Explicit On
<Serializable()> Public Class Foratura
    Inherits Membratura
    Public Profon As Single
    Public Quota As Single
    Public Raggio As Single
    Public anom As Single
    Public DiamFor As Single
    Private prBucante As Membratura
    Public isW As Short
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        GenMem.Tipo = 97
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        Bucante = Nothing
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Copia(ByRef A As Foratura)
        MsgBox("mi rifiuto di copiare una foratura")
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
    End Sub
    Public Overrides Property Bucante() As Membratura
        Get
            Return prBucante
        End Get
        Set(ByVal Value As Membratura)
            prBucante = Value
        End Set
    End Property
End Class