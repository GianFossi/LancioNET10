Option Strict Off
Option Explicit On
<Serializable()> Public Class Origine
    Inherits Membratura
    '    Public GenMem As clsGenMem
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Spessore = 0
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overloads Sub leggi(ByVal d As String, ByVal Mode As Short)

    End Sub
End Class