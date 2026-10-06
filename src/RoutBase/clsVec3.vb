Option Strict On
Option Explicit On
<Serializable()> Public Class clsVec3
    Public X As Single
    Public y As Single
    Public Z As Single
    Public Sub Salva(ByRef a As Single, ByRef b As Single, ByRef c As Single)
        X = a
        y = b
        Z = c
    End Sub
    Public Sub Retri(ByRef a As Single, ByRef b As Single, ByRef c As Single)
        a = X
        b = y
        c = Z
    End Sub
    Public Function ProdScalar(ByRef V2 As clsVec3) As Single
        ProdScalar = X * V2.X + y * V2.y + Z * V2.Z
    End Function
    Function ProdTripl(ByRef V2 As clsVec3, ByRef V3 As clsVec3) As Single
        Dim s As Single
        s = X * V2.y * V3.Z
        s = s + y * V2.Z * V3.X
        s = s + Z * V2.X * V3.y
        s = s - Z * V2.y * V3.X
        s = s - y * V2.X * V3.Z
        s = s - X * V2.Z * V3.y
        ProdTripl = s
    End Function
    Public Sub DirAlpha(ByRef Dir_Renamed As clsVec3, ByRef Sol As clsVec3, ByRef Alfa As Single)
        On Error GoTo errdiral
        'Trav e Dir ortogonali. Cercare Sol che sta in un piano perpendicolare
        'a Dir e che forma un angolo Alfa con Trav
        Dim Solmat(2) As clsVec3
        Dim i As Short
        Dim Det As Double
        Dim PTripl(2) As Single
        Dim CosAlfa, SinAlfa As Double
        Dim iSw13, iSw23 As Boolean
        Dim xx2, xx1, Adim As Double
        Dim c, b, d As Double
        Solmat(1) = New clsVec3
        Solmat(2) = New clsVec3
        CosAlfa = System.Math.Cos(Alfa)
        SinAlfa = System.Math.Sin(Alfa)
        Det = -X * Dir_Renamed.y + y * Dir_Renamed.X
        If System.Math.Abs(Det) < clsTrigon.TOLER Then
            iSw13 = True
            Dir_Renamed.SWAPXZ() : Trigon.SWAP(X, Z)
            Det = -X * Dir_Renamed.y + y * Dir_Renamed.X
        End If
        If System.Math.Abs(Det) < clsTrigon.TOLER Then
            iSw13 = False
            Dir_Renamed.SWAPXZ() : Trigon.SWAP(X, Z)
            iSw23 = True
            Dir_Renamed.SWAPYZ() : Trigon.SWAP(y, Z)
            Det = -X * Dir_Renamed.y + y * Dir_Renamed.X
        End If
        If System.Math.Abs(Det) < clsTrigon.TOLER Then MsgBox("Err.imp. in DirAlpha ") : Stop 'End
        xx1 = (Dir_Renamed.Z * y - Dir_Renamed.y * Z)
        xx2 = -(Dir_Renamed.Z * X - Dir_Renamed.X * Z)
1021:   Adim = xx1 * xx1 + xx2 * xx2 + Det * Det
1024:   b = -2.0! * CosAlfa * (xx2 * Dir_Renamed.X - xx1 * Dir_Renamed.y)
1025:   c = CosAlfa * CosAlfa * (Dir_Renamed.X * Dir_Renamed.X + Dir_Renamed.y * Dir_Renamed.y) - Det * Det
1030:
        If (System.Math.Abs(Adim) < clsTrigon.TOLER Or System.Math.Abs(b) < clsTrigon.TOLER) And System.Math.Abs(c) < clsTrigon.TOLER Then
            Solmat(1).Z = 0
            Solmat(2).Z = 0
        Else
            d = b * b - 4.0! * Adim * c
            If System.Math.Abs(d) < clsTrigon.TOLER / 10 Then d = 0
            d = System.Math.Sqrt(d)
            Solmat(1).Z = CType((-b + d) / 2.0! / Adim, Single)
            Solmat(2).Z = CType((-b - d) / 2.0! / Adim, Single)
        End If
        ' Debug.Print -b / 2 / Adim
1040:
        For i = 1 To 2
            Solmat(i).X = CType((-CosAlfa * Dir_Renamed.y - xx1 * Solmat(i).Z) / Det, Single)
            Solmat(i).y = CType((CosAlfa * Dir_Renamed.X - xx2 * Solmat(i).Z) / Det, Single)
        Next i
        If iSw13 Then
            Dir_Renamed.SWAPXZ() : Trigon.SWAP(X, Z)
            Solmat(1).SWAPXZ() : Solmat(2).SWAPXZ()
        ElseIf iSw23 Then
            Dir_Renamed.SWAPYZ() : Trigon.SWAP(y, Z)
            Solmat(1).SWAPYZ() : Solmat(2).SWAPYZ()
        End If
        For i = 1 To 2
            PTripl(i) = ProdTripl(Solmat(i), Dir_Renamed)
        Next i
1050:
        If SinAlfa >= 0.0! Then
            If PTripl(1) > 0.0! Then Solmat(1).copia(Sol) Else Solmat(2).copia(Sol)
        Else
            If PTripl(1) > 0.0! Then Solmat(2).copia(Sol) Else Solmat(1).copia(Sol)
        End If
        Exit Sub
errdiral:
        MsgBox("Errore in DirAlpha" & ErrorToString() & Str(Erl()))
        'Resume
        Stop 'End
    End Sub
    Public Sub DirTrav(ByRef Orig As clsVec3, ByRef Dirvec As clsVec3, ByRef Sol As clsVec3)
        Dim a12, a11, a13 As Single
        Dim a22, a21, a23 As Single
        Dim iSwap As Short
        Dim AA, Det, BB As Single
        On Error GoTo ErrDirTrav
        'Sol perpendicolare a Dir e complanare con Orig e Dirvec
        For iSwap = 1 To 3
            a11 = X : a12 = y : a13 = Z
            a21 = Orig.y * Dirvec.Z - Orig.Z * Dirvec.y
            a22 = Orig.X * Dirvec.Z - Orig.Z * Dirvec.X
            a23 = Orig.X * Dirvec.y - Orig.y * Dirvec.X
            'x=aa.z  y=bb.z
20:         Det = a11 * a22 - a12 * a21
            If System.Math.Abs(Det) > clsTrigon.TOLER Then Exit For
            If iSwap = 1 Then
                SuperSWAPXZ(Sol, Orig, Dirvec)
            ElseIf iSwap = 2 Then
                SuperSWAPXZ(Sol, Orig, Dirvec)
                SuperSWAPYZ(Sol, Orig, Dirvec)
            ElseIf iSwap = 3 Then
                MsgBox("Err.imp. in DirTrav") ': End
                GoTo ExITT
            End If
        Next
        AA = (-a13 * a22 + a23 * a12) / Det
        BB = (-a11 * a23 + a21 * a13) / Det
30:     Sol.Z = CType(1 / System.Math.Sqrt(1 + AA * AA + BB * BB), Single)
        Sol.X = AA * Sol.Z
        Sol.y = BB * Sol.Z
        If (Sol.X * Orig.X + Sol.y * Orig.y + Sol.Z * Orig.Z) > 0 Then
            Sol.X = -Sol.X : Sol.y = -Sol.y : Sol.Z = -Sol.Z
        End If
ExITT:
        If iSwap = 2 Then
            SuperSWAPXZ(Sol, Orig, Dirvec)
        ElseIf iSwap = 3 Then
            SuperSWAPYZ(Sol, Orig, Dirvec)
        End If
        Exit Sub
ErrDirTrav: MsgBox("ErrDirTrav" & Str(Err.Number) & Str(Erl()))
        Resume Next
    End Sub
    Public Sub copia(ByRef V As clsVec3)
        V.X = X
        V.y = y
        V.Z = Z
    End Sub
    Public Sub SWAPXY()
        Trigon.SWAP(X, y)
    End Sub
    Public Sub SWAPYZ()
        Trigon.SWAP(y, Z)
    End Sub
    Public Sub SWAPXZ()
        Trigon.SWAP(X, Z)
    End Sub
    Public Function DistPunPun(ByRef P As clsVec3) As Single
        DistPunPun = CSng(System.Math.Sqrt((X - P.X) * (X - P.X) + (y - P.y) * (y - P.y) + (Z - P.Z) * (Z - P.Z)))
    End Function
    Public Function MaxDir(ByRef Diritta As clsVec3, ByRef xx As Short) As Short
        'Diritta perpendicolare e con il coseno massimo nell'asse specificato da (xx)
        'xx= 1 +x;2 -x;3 +y; 4 -y; 5 +z; 6 -z
        Dim b, a, c As Single
        Dim zmax, ymax, xmax As Single
        Dim i, j As Short
        Dim ymaxmax, zmaxmax As Single
        Dim ymaxmin, zmaxmin As Single
        With Diritta
            Select Case xx
                Case 5, 6
                    If .X = 0 And .y = 0 Then
                        MaxDir = 1
                        Exit Function
                    ElseIf .X * .X > .y * .y Then
                        a = .X : b = .y : c = .Z
                    Else
                        b = .X : a = .y : c = .Z
                    End If
                Case 3, 4
                    If .X = 0 And .Z = 0 Then
                        MaxDir = 1
                        Exit Function
                    ElseIf .X * .X > .Z * .Z Then
                        a = .X : b = .Z : c = .y
                    Else
                        b = .X : a = .Z : c = .y
                    End If
                Case 1, 2
                    If .y = 0 And .Z = 0 Then
                        MaxDir = 1
                        Exit Function
                    ElseIf .y * .y > .Z * .Z Then
                        a = .y : b = .Z : c = .X
                    Else
                        b = .y : a = .Z : c = .X
                    End If
            End Select
            zmaxmax = -1.1
            zmaxmin = 1.1
            For i = -1 To 1 Step 2
                ymax = CSng(i * a * b * c * System.Math.Sqrt((a * a + c * c) / ((a * a + c * c) ^ 2 * (a * a + b * b) ^ 2 - b * b * c * c * (a * a + c * c) * (a * a + b * b))))
                For j = -1 To 1 Step 2
                    zmax = CSng((-b * c * ymax + j * System.Math.Sqrt(b * b * c * c * ymax * ymax - (a * a + c * c) * ((a * a + b * b) * ymax * ymax - a * a))) / (a * a + c * c))
                    If zmax > zmaxmax Then ymaxmax = ymax : zmaxmax = zmax
                    If zmax < zmaxmin Then ymaxmin = ymax : zmaxmin = zmax
                Next
            Next
            If xx Mod 2 = 0 Then
                zmax = zmaxmin : ymax = ymaxmin
            Else
                zmax = zmaxmax : ymax = ymaxmax
            End If
            xmax = -(b * ymax + c * zmax) / a
            Select Case xx
                Case 5, 6
                    If .X * .X > .y * y Then
                        X = xmax
                        y = ymax
                        Z = zmax
                    Else
                        y = xmax
                        X = ymax
                        Z = zmax
                    End If
                Case 3, 4
                    If .X * .X > .Z * .Z Then
                        X = xmax
                        y = zmax
                        Z = ymax
                    Else
                        y = zmax
                        X = ymax
                        Z = zmax
                    End If
                Case 1, 2
                    If .y * .y > .Z * .Z Then
                        X = zmax
                        y = xmax
                        Z = ymax
                    Else
                        y = ymax
                        X = zmax
                        Z = xmax
                    End If
            End Select
        End With
    End Function
    Private Sub SuperSWAPXZ(ByRef Sol As clsVec3, ByRef orig As clsVec3, ByRef dirvec As clsVec3)
        Sol.SWAPXZ()
        Trigon.SWAP(X, Z)
        orig.SWAPXZ()
        dirvec.SWAPXZ()
    End Sub
    Private Sub SuperSWAPYZ(ByRef Sol As clsVec3, ByRef Orig As clsVec3, ByRef Dirvec As clsVec3)
        Sol.SWAPYZ()
        Trigon.SWAP(y, Z)
        Orig.SWAPYZ()
        Dirvec.SWAPYZ()
    End Sub
End Class