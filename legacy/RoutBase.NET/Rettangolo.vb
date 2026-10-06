Option Strict Off
Option Explicit On
<Serializable()> Public Class Rettangolo
    Public x(4) As Single
    Public y(4) As Single
    Public Lung As Single
    Public LARG As Single
    Public Sub copia(ByRef a As Rettangolo)
        Dim i As Short
        a.Lung = Lung
        a.LARG = LARG
        For i = 1 To 4
            a.x(i) = x(i)
            a.y(i) = y(i)
        Next
    End Sub
    Public Sub RettGraf(ByRef R As Routines, ByRef Mode As Short)
        Dim i, j As Short
        If Mode <= 1 Then
            R.tratto(x(4), y(4), x(1), y(1), 0.1, 0)
            For i = 2 To 4
                R.tratto(-1, -1, x(i), y(i), 0.1, 0)
            Next
        ElseIf Mode = 2 Or Mode = 4 Then
            For i = 1 To 4
                j = i + 1 : If j = 5 Then j = 1
                R.tratto(x(i), y(i), x(j), y(j), 0.1, 0)
            Next i
        ElseIf Mode = 3 Then
            R.quadrato(x(1), y(1), x(3), y(3), 0.1, 0, False)
        ElseIf Mode = 5 Then
            R.quadrato(x(1), y(1), x(3), y(3), 0.1, 0, False)
        End If
    End Sub
    Public Sub MakeCorners(ByVal Lu As Single, ByVal La As Single)
        x(1) = -La / 2
        x(2) = La / 2
        x(3) = La / 2
        x(4) = -La / 2
        y(1) = 0
        y(2) = 0
        y(3) = Lu
        y(4) = Lu
        Lung = Lu
        LARG = La
    End Sub
End Class