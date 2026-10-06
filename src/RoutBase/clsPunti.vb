Option Strict On
Option Explicit On
Public Class clsPunti
    Public Punti As New LinkedListP(0)
    Public Sub Inizia(ByRef n As Short)
        Dim P As clsVec2
        Dim i As Short
        If Punti.Count() > 0 Then Class_Terminate_Renamed()
        For i = 0 To n
            P = New clsVec2
            Punti.Add(P)
        Next
    End Sub
    Private Sub Class_Terminate_Renamed()
        Do While Punti.Count() > 0
            Punti.remove(0)
        Loop
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    Public Sub SpezzGraf(ByRef Start As Short, ByRef Fine As Short, ByRef R As Routines)
        Dim i As Short
        R.tratto((Punti0(Start).X), (Punti0(Start).y), (Punti0(CShort(Start + 1)).X), (Punti0(CShort(Start + 1)).y), 0.1, 0)
        For i = CShort(Start + 2) To Fine
            If (Punti0(i).X - Punti0(CShort(i - 1)).X) ^ 2 + (Punti0(i).y - Punti0(CShort(i - 1)).y) ^ 2 > 0.001 Then
                R.tratto((Punti0(CShort(i - 1)).X), (Punti0(CShort(i - 1)).y), (Punti0(i).X), (Punti0(i).y), 0.1, 0)
            End If
        Next
    End Sub
    Public Sub Trasferisci(ByRef x As Single, ByRef y As Single, ByRef i As Short)
        Punti.Item(i).TextData.X = x
        Punti.Item(i).TextData.y = y
    End Sub
    Public Sub SWAP(ByRef i As Short, ByRef j As Short)
        Dim x, y As Single
        x = Punti.Item(i).TextData.X
        y = Punti.Item(i).TextData.y
        Punti.Item(i).TextData.X = Punti.Item(j).TextData.X
        Punti.Item(i).TextData.y = Punti.Item(j).TextData.y
        Punti.Item(j).TextData.X = x
        Punti.Item(j).TextData.y = y
    End Sub
    Public Property Punti0(ByVal i As Short) As clsVec2
        Get
            Punti0 = Punti.Item(i).TextData
        End Get
        Set(ByVal Value As clsVec2)

        End Set
    End Property
    Public Sub Copia(ByRef a As clsPunti)
        Dim j As Short
        a.Inizia(CShort(Punti.Count()))
        For j = 1 To CShort(Punti.Count())
            a.Punti.Item(j).TextData.copia(Punti.Item(j).TextData)
        Next
    End Sub
End Class