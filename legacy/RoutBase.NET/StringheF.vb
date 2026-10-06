Option Strict On
Option Explicit On
Public Class StringheF
    Public Strin1 As String
    Public Ris1 As Boolean
    Private prnextS As StringheF
    Public Property nextS() As StringheF
        Get
            nextS = prnextS
        End Get
        Set(ByVal Value As StringheF)
            prnextS = Value
        End Set
    End Property
End Class