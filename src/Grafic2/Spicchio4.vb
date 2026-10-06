Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Spicchio4
    Public Origin As New RoutBase1.clsVec2
    Public Direct As New RoutBase1.clsVec2
    Public RG As Single
    Public RP As Single
    Public Alfa As Single
    Public Sub Copia(ByRef A As Spicchio4)
        A.RG = RG
        A.RP = RP
        A.Alfa = Alfa
        Origin.copia((A.Origin))
        Direct.copia((A.Direct))
    End Sub
    Sub SpicGraf(ByRef Mode As Short, ByRef Punti0 As RoutBase1.clsPunti, ByRef Punti1 As RoutBase1.clsPunti)
        Dim Alfa1, ang, Alfa2 As Single
        Dim i As Short
        Punti0 = New RoutBase1.clsPunti
        Punti1 = New RoutBase1.clsPunti
        ang = GlobalRoutines.arco((Direct.X), (Direct.y))
        Punti0.Inizia(3)
        Punti1.Inizia(3)
        For i = 0 To 2
            Punti0.Punti.Item(i + 1).TextData.X = Origin.X + RP * System.Math.Cos(ang + (i - 1) * Alfa / 2)
            Punti1.Punti.Item(i + 1).TextData.X = Origin.X + RG * System.Math.Cos(ang + (i - 1) * Alfa / 2)
            Punti0.Punti.Item(i + 1).TextData.y = Origin.y + RP * System.Math.Sin(ang + (i - 1) * Alfa / 2)
            Punti1.Punti.Item(i + 1).TextData.y = Origin.y + RG * System.Math.Sin(ang + (i - 1) * Alfa / 2)
            If i <> 1 And Mode < 2 And Mode > -1 Then
                Funzioni.DisRut.tratto(Punti0.Punti.Item(i + 1).TextData.X, Punti0.Punti.Item(i + 1).TextData.y, _
                Punti1.Punti.Item(i + 1).TextData.X, Punti1.Punti.Item(i + 1).TextData.y, 0.1, 0)
            End If
        Next i
        '   If IUNL = 3 Then ang = -ang
        Alfa1 = ang - Alfa / 2
        Alfa2 = ang + Alfa / 2
        If RP > 0 And Mode > -1 Then
            Funzioni.DisRut.Cerchio((Origin.X), (Origin.y), RP, Alfa1, Alfa2, 0.1)
        End If
        Funzioni.DisRut.Cerchio((Origin.X), (Origin.y), RG, Alfa1, Alfa2, 0.1)
        If IUNL = 3 Then Exit Sub
        If Mode > 1 Then
            Funzioni.DisRut.tratto(Punti0.Punti.Item(1).TextData.X, Punti0.Punti.Item(1).TextData.y, _
            Punti1.Punti.Item(1).TextData.X, Punti1.Punti.Item(1).TextData.y, 0.1, 0)
            '  PSet (P0(0).X, ymax + ymin - P0(0).Y): PSet (P1(0).X, ymax + ymin - P1(0).Y)
            Funzioni.DisRut.tratto(Punti0.Punti.Item(3).TextData.X, Punti0.Punti.Item(3).TextData.y, _
            Punti1.Punti.Item(3).TextData.X, Punti1.Punti.Item(3).TextData.y, 0.1, 0)
            '  PSet (P0(2).X, ymax + ymin - P0(2).Y): PSet (P1(2).X, ymax + ymin - P1(2).Y)
        End If
    End Sub
End Class