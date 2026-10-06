Option Strict On
Option Explicit On
Public Class clsPunti3
    Public Punti As New LinkedListP3
    Public Sub Inizia(ByRef n As Short)
        Dim P As clsVec3
        Dim i As Short
        If Punti.Count() > 0 Then Class_Terminate_Renamed()
        For i = 1 To n
            P = New clsVec3
            Punti.Add(P)
        Next
    End Sub
    Private Sub Class_Terminate_Renamed()
        Do While Punti.Count > 0
            Punti.remove(1)
        Loop
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    'Public Sub Trasferisci(X As Single, Y As Single, i As Integer)
    '    Punti(i).X = X
    '    Punti(i).Y = Y
    'End Sub
    'Public Sub SWAP(i As Integer, j As Integer)
    '    Dim X As Single, Y As Single
    '    X = Punti(i).X
    '    Y = Punti(i).Y
    '    Punti(i).X = Punti(j).X
    '    Punti(i).Y = Punti(j).Y
    '    Punti(j).X = X
    '    Punti(j).Y = Y
    'End Sub
End Class