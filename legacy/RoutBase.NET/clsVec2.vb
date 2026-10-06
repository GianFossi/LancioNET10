Option Strict On
Option Explicit On
<Serializable()> Public Class clsVec2
    Public X As Single
    Public y As Single
    Public Function DistPunPun(ByRef P As clsVec2) As Single
        DistPunPun = CType(System.Math.Sqrt((X - P.X) * (X - P.X) + (y - P.y) * (y - P.y)), Single)
    End Function
    Public Sub copia(ByRef V As clsVec2)
        V.X = X
        V.y = y
    End Sub
    Public Sub New(Optional ByVal xx As Single = 0, Optional ByVal yy As Single = 0)
        X = xx
        y = yy
    End Sub
End Class