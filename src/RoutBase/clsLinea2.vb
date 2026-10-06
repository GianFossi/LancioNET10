Option Strict On
Option Explicit On
<Serializable()> Public Class clsLinea2
    Public P0 As New clsVec2
    Public p1 As New clsVec2
    Public Direz As New clsVec2
    Public a As Single
    Public b As Single
    Public c As Single
    Public Sub Copia(ByVal L As clsLinea2)
        P0.copia(L.P0)
        p1.copia(L.p1)
        Direz.copia(L.Direz)
        L.a = a
        L.b = b
        L.c = c
    End Sub
    Public Function DistPunRet(ByRef Pun As clsVec2, ByRef Ret As clsVec3, ByRef segno As Boolean) As Single
        If segno Then
            DistPunRet = CType((Ret.X * Pun.X + Ret.y * Pun.y + Ret.Z) / System.Math.Sqrt(Ret.X ^ 2 + Ret.y ^ 2), Single)
        Else
            DistPunRet = CType(System.Math.Abs(Ret.X * Pun.X + Ret.y * Pun.y + Ret.Z) / System.Math.Sqrt(Ret.X ^ 2 + Ret.y ^ 2), Single)
        End If
    End Function
    Public Function DistPunLinea(ByRef Pun As clsVec2, Optional ByRef segno As Boolean = False) As Single
        Dim Ret As clsVec3
        Ret = New clsVec3
        If Trigon Is Nothing Then Trigon = New clsTrigon
        If System.Math.Abs(P0.X - p1.X) < clsTrigon.TOLER Then
            DistPunLinea = System.Math.Abs(Pun.X - P0.X)
        ElseIf System.Math.Abs(P0.y - p1.y) < clsTrigon.TOLER Then
            DistPunLinea = System.Math.Abs(Pun.y - P0.y)
        Else
            Ret.X = -1 / (p1.X - P0.X)
            Ret.y = 1 / (p1.y - P0.y)
            Ret.Z = -P0.y * Ret.y - P0.X * Ret.X
            DistPunLinea = DistPunRet(Pun, Ret, segno)
        End If
    End Function
    Public Sub CalcolaDir()
        Dim Dist As Single
        If System.Math.Abs(1 - Direz.X ^ 2 - Direz.y ^ 2) > clsTrigon.TOLER Then
            Dist = CType(System.Math.Sqrt((P0.X - p1.X) ^ 2 + (P0.y - p1.y) ^ 2), Single)
            If Dist = 0 Then Exit Sub
            Direz.X = (p1.X - P0.X) / Dist
            Direz.y = (p1.y - P0.y) / Dist
        Else
            p1.X = P0.X + 100 * Direz.X
            p1.y = P0.y + 100 * Direz.y
        End If
        a = -Direz.y
        b = Direz.X
        c = -P0.X * Direz.y + P0.y * Direz.X
    End Sub
    Public Function InterRettRett(ByRef Retta As clsLinea2, ByRef Inters As clsVec2) As Boolean
        Dim Det As Single
        Det = a * Retta.b - Retta.a * b
        If System.Math.Abs(Det) < clsTrigon.TOLER Then
            InterRettRett = False
        Else
            Inters.X = (c * Retta.b - Retta.c * b) / Det
            Inters.y = (a * Retta.c - Retta.a * c) / Det
            InterRettRett = True
        End If
    End Function
    Public Function Interno(ByRef Retta As clsLinea2) As Short
        Dim Intersez As Boolean
        Dim P As New clsVec2
        Dim Dist2, Dist1, Dist As Single
        Dim Locale As Boolean
        Intersez = InterRettRett(Retta, P)
        If Not Intersez Then
            Interno = 1 'parallele
            Exit Function
        End If
        Dist1 = (P.X - P0.X) * (P.X - P0.X) + (P.y - P0.y) * (P.y - P0.y)
        Dist2 = (P.X - p1.X) * (P.X - p1.X) + (P.y - p1.y) * (P.y - p1.y)
        Dist = CType((P0.X - p1.X) ^ 2 + (P0.y - p1.y) ^ 2, Single)
        Locale = (Dist1 <= Dist) And (Dist2 <= Dist)
        Dist1 = (P.X - Retta.P0.X) * (P.X - Retta.P0.X) + (P.y - Retta.P0.y) * (P.y - Retta.P0.y)
        Dist2 = (P.X - Retta.p1.X) * (P.X - Retta.p1.X) + (P.y - Retta.p1.y) * (P.y - Retta.p1.y)
        Dist = CType((Retta.P0.X - Retta.p1.X) ^ 2 + (Retta.P0.y - Retta.p1.y) ^ 2, Single)
        Locale = Locale And (Dist1 <= Dist) And (Dist2 <= Dist)
        Interno = CShort(Locale)
    End Function
    Public Sub InterRettCerch(ByRef RP As Single, ByRef CentroCerchio As clsVec2, ByRef RG As Single, ByRef Punti As clsPunti, ByRef n1 As Short, ByRef n2 As Short)
        Dim b, a, c As Single
        Dim BB, AA, cc As Single
        Dim bb1, c1, c2, bb2 As Single
        Dim i As Short
        Dim delta1, delta2 As Single
699:    a = Direz.y : b = -Direz.X
        c1 = -(a * P0.X + b * P0.y) + RP
        c2 = -(a * P0.X + b * P0.y) - RP
        '-----------------
        c = c1 'poi c=c2
        For i = 1 To 2
            AA = a * a + b * b
            BB = 2 * (b * c + a * b * CentroCerchio.X - a * a * CentroCerchio.y)
            bb1 = BB * BB
            cc = c * c + 2 * a * c * CentroCerchio.X + a * a * (CentroCerchio.X * CentroCerchio.X + CentroCerchio.y * CentroCerchio.y - RG * RG)
            delta1 = bb1 - 4 * AA * cc
            If delta1 > clsTrigon.TOLER * bb1 Then
                Punti.Punti.Item(1 + 2 * (i - 1)).TextData.y = CType((-BB + System.Math.Sign(Direz.y) * System.Math.Sqrt(delta1)) / 2 / AA, Single)
                Punti.Punti.Item(2 + 2 * (i - 1)).TextData.y = CType((-BB - System.Math.Sign(Direz.y) * System.Math.Sqrt(delta1)) / 2 / AA, Single)
            ElseIf System.Math.Abs(delta1) < clsTrigon.TOLER * bb1 Then
                Punti.Punti.Item(1 + 2 * (i - 1)).TextData.y = -BB / 2 / AA
                Punti.Punti.Item(2 + 2 * (i - 1)).TextData.y = -BB / 2 / AA
            Else
            End If
705:        AA = a * a + b * b
            BB = 2 * (a * c + a * b * CentroCerchio.y - b * b * CentroCerchio.X)
            bb2 = BB * BB
            cc = c * c + 2 * b * c * CentroCerchio.y + b * b * (CentroCerchio.X * CentroCerchio.X + CentroCerchio.y * CentroCerchio.y - RG * RG)
            delta2 = bb2 - 4 * AA * cc
            If delta2 > clsTrigon.TOLER * bb2 Then
                Punti.Punti.Item(1 + 2 * (i - 1)).TextData.X = CType((-BB + System.Math.Sign(Direz.X) * System.Math.Sqrt(delta2)) / 2 / AA, Single)
                Punti.Punti.Item(2 + 2 * (i - 1)).TextData.X = CType((-BB - System.Math.Sign(Direz.X) * System.Math.Sqrt(delta2)) / 2 / AA, Single)
            ElseIf System.Math.Abs(delta2) < clsTrigon.TOLER * bb2 Then
                Punti.Punti.Item(1 + 2 * (i - 1)).TextData.X = -BB / 2 / AA
                Punti.Punti.Item(2 + 2 * (i - 1)).TextData.X = -BB / 2 / AA
            End If
            c = c2
            If delta1 * delta2 < 0 And System.Math.Abs(delta1) > clsTrigon.TOLER * bb1 And System.Math.Abs(delta2) > clsTrigon.TOLER * bb2 Then
                MsgBox("Err imp in InterRettCerch")
                Stop
            ElseIf delta1 > clsTrigon.TOLER * bb1 Or delta2 > clsTrigon.TOLER * bb2 Then
                If i = 1 Then n1 = 2 Else n2 = 2
            ElseIf System.Math.Abs(delta1) < clsTrigon.TOLER * bb1 And System.Math.Abs(delta2) < clsTrigon.TOLER * bb2 Then
                If i = 1 Then n1 = 1 Else n2 = 1
            Else
                If i = 1 Then n1 = 0 Else n2 = 0
            End If
        Next
    End Sub
    Public Function Proiez(ByRef P As clsVec2) As Single
        Proiez = (P.X - P0.X) * Direz.X + (P.y - P0.y) * Direz.y
    End Function
End Class