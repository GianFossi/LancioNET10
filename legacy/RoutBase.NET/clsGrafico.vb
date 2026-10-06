Option Strict On
Option Explicit On 
Imports System.Drawing.Drawing2D
Public Class clsGrafico
    Public Motore As RoutBase1.clsMotore
    Private Curve As New Collection
    Private TRight, HTop, HBot, TLeft As Single
    Private Trightm, HTopm, HBotm, TLeftm As Single
    Private locPic As System.Windows.Forms.PictureBox
    Private glocPic As System.Drawing.Graphics
    Private Titx, Tity As String
    Private locForm As frmGrafico
    Private Titolo As String
    Public Sub DisCurva(ByRef lX() As Single, ByRef lY() As Single, ByRef l0 As Short, ByRef lN As Short, Optional ByRef Didasc As String = "", Optional ByRef Stile As DashStyle = 0)
        Dim Curva As New clsCurva
        Dim i As Short
        'n = lN: N0 = l0
        Curva.P.Inizia(CShort(lN - l0 + 1))
        For i = l0 To lN
            Curva.P.Punti.Item(i - l0 + 1).TextData.X = lX(i)
            Curva.P.Punti.Item(i - l0 + 1).TextData.y = lY(i)
        Next
        Curva.Didasc = Didasc
        Curva.Stile = Stile
        Curve.Add(Curva)
        SDisCurva(CShort(Curve.Count()))
    End Sub
    Private Sub Cifre(ByRef CHTop As Single, ByRef CHBot As Single, ByRef nCifrey As Short, ByRef Expy As Short, ByRef nRighey As Short)
        Dim dH As Single
        Dim n2, jy, n1, n3 As Integer
        Dim HBot1, HTop1 As Single
        Expy = 0
        dH = CHTop - CHBot
        If dH = 0 Then Exit Sub
        jy = System.Math.Sign(dH)
        If CHTop <> 0 Then n1 = CInt(System.Math.Log(System.Math.Abs(CHTop)) / System.Math.Log(10.0#)) Else n1 = 0
        If CHBot <> 0 Then n2 = CInt(System.Math.Log(System.Math.Abs(CHBot)) / System.Math.Log(10.0#)) Else n2 = 0
        n3 = CInt(System.Math.Log(System.Math.Abs(dH)) / System.Math.Log(10.0#))
        nCifrey = CShort(n1) : If System.Math.Abs(n2) > System.Math.Abs(n1) Then nCifrey = CShort(n2)
        If System.Math.Abs(n3) > System.Math.Abs(nCifrey) Then nCifrey = CShort(n3)
        HTop1 = CType((System.Math.Abs(CHTop / 10 ^ nCifrey) + 0.49) * System.Math.Sign(CHTop) * 10 ^ nCifrey, Single)
        If (HTop1 - CHTop) * (CHBot - CHTop) > 0 Then HTop1 = CType((CInt(System.Math.Abs(CHTop / 10 ^ nCifrey) + 0.49) * System.Math.Sign(CHTop) + jy) * 10 ^ nCifrey, Single)
        HBot1 = CType(CInt(System.Math.Abs(CHBot / 10 ^ nCifrey) + 0.49) * System.Math.Sign(CHBot) * 10 ^ nCifrey, Single)
        If (HBot1 - CHBot) * (CHTop - CHBot) > 0 Then HBot1 = CType((CInt(System.Math.Abs(CHBot / 10 ^ nCifrey) + 0.49) * System.Math.Sign(CHBot) - jy) * 10 ^ nCifrey, Single)
        CHTop = HTop1 : CHBot = HBot1
        nRighey = CShort(System.Math.Abs(Int(CHTop / 10 ^ nCifrey + 0.49) - Int(CHBot / 10 ^ nCifrey + 0.49)))
        If nRighey < 4 Then nRighey = CShort(2 * nRighey)
        If nRighey < 6 Then nRighey = CShort(2 * nRighey)
        If CHTop <> 0 Then n1 = CInt(System.Math.Log(System.Math.Abs(CHTop)) / System.Math.Log(10.0#)) Else n1 = 0
        If CHBot <> 0 Then n2 = CInt(System.Math.Log(System.Math.Abs(CHBot)) / System.Math.Log(10.0#)) Else n2 = 0
        nCifrey = CShort(n1) : If System.Math.Abs(n2) > System.Math.Abs(n1) Then nCifrey = CShort(n2)
        nCifrey = CShort(nCifrey + System.Math.Sign(nCifrey))
        If nCifrey > 4 Then Expy = CShort(nCifrey - 2)
        If nCifrey < -4 Then Expy = CShort(nCifrey + 2)
        If nCifrey = 0 Then nCifrey = 1
        'While nRighey < 5: nRighey = nRighey * 2: Wend
        'If nRighey > 10 Then nRighey = 10
    End Sub
    Private Sub SetGrafico(ByRef lHTop As Single, ByRef lHBot As Single, ByRef lTRight As Single, _
    ByRef lTLeft As Single, ByRef llocPic As System.Windows.Forms.PictureBox, ByRef lTitx As String, _
    ByRef lTity As String)
        Dim Curva As clsCurva
        HTop = lHTop
        HBot = lHBot
        TRight = lTRight
        TLeft = lTLeft
        locPic = llocPic
        AddHandler locPic.Paint, AddressOf Me.P_Paint
        Titx = lTitx
        Tity = lTity
        Call SSetGrafico()
        For Each Curva In Curve
            Curve.Remove(1)
        Next Curva
    End Sub
    Public Sub SSetGrafico()
        Dim nCifrex, nCifrey As Short
        Dim nRighex, nRighey As Short
        Dim Expx, Expy As Short
        Dim j As Short
        Dim dH As Single
        Dim x1, y1 As Single
        Dim x2, y2 As Single
        Dim n As Short
        Dim T As String
        Dim nd, np As Short
        Dim myMatrix As New Matrix
        Dim factorx, factory, factor As Single
        Dim CurrentX, CurrentY As Single
        HTopm = HTop : HBotm = HBot
        Call Cifre(HTopm, HBotm, nCifrey, Expy, nRighey)
        dH = HTopm - HBotm
        y1 = HTopm + dH / 5 : y2 = HBotm - dH / 5
        Trightm = TRight : TLeftm = TLeft
        Call Cifre(Trightm, TLeftm, nCifrex, Expx, nRighex)
        dH = Trightm - TLeftm
        x1 = TLeftm - dH / 10 : x2 = Trightm + dH / 10
        If x1 = x2 Or y1 = y2 Then Exit Sub
        factorx = (x2 - x1) / locPic.Width
        factory = (y2 - y1) / locPic.Height
        factor = factorx : If factory < factor Then factory = factor
        myMatrix.Scale(factor, factor)
        myMatrix.Translate(x1, y1)
        glocPic.Transform = myMatrix
        'locPic.Scale((x1, y1) - (x2, y2))
        locPic.Font = New Font("Courier New", 8)
        Dim myPen As New Pen(Color.Black)
        myPen.DashStyle = DashStyle.Solid
        Dim myBrush As New SolidBrush(Color.Black)
        'locPic.DrawStyle = vbSolid
        For j = 0 To nRighex
            x1 = TLeftm + j * (Trightm - TLeftm) / nRighex
            glocPic.DrawLine(myPen, x1, HBotm, x1, HTopm)
            ' locPic.Line((x1, HBotm) - (x1, HTopm))
            If nCifrex < 0 Then np = 1 : nd = System.Math.Abs(nCifrex - Expx) Else np = nCifrex - Expx : nd = 0
            If np <= 1 And nd <= 1 Then np = 1 : nd = 1
            T = Trigon.myStr(CSng(x1 / 10 ^ Expx), np, nd, 0)
            CurrentX = x1 - glocPic.MeasureString(T, locPic.Font).Width / 2 'locPic.FontSize * locPic.ScaleWidth / locPic.Width * (nCifrex - Expx) * 16 * 0.75 '16 rapporto point/twip
            CurrentY = HBotm
            glocPic.DrawString(T, locPic.Font, myBrush, CurrentX, CurrentY)
            'locPic.Print(T)
            If j > 0 Then
                x1 = CSng(TLeftm + (-0.5 + j) * (Trightm - TLeftm) / nRighex)
                glocPic.DrawLine(myPen, x1, HBotm, x1, HTopm)
            End If
        Next
        CurrentY = CSng(HBotm - ((HTopm - HBotm) * 0.75 / 10 - glocPic.MeasureString("A", locPic.Font).Height))
        T = Titx : If Expx <> 0 Then T = T & "*10^" & LTrim(Str(-Expx))
        CurrentX = Trightm - glocPic.MeasureString(T, locPic.Font).Width
        glocPic.DrawString(T, locPic.Font, myBrush, CurrentX, CurrentY)
        For j = 0 To nRighey
            y1 = HBotm + j * (HTopm - HBotm) / nRighey
            glocPic.DrawLine(myPen, TLeftm, y1, Trightm, y1)
            If nCifrey < 0 Then np = 1 : nd = System.Math.Abs(nCifrey - Expy) Else np = nCifrey - Expy : nd = 0
            If np <= 1 And nd <= 1 Then np = 1 : nd = 1
            T = Trigon.myStr(CSng(y1 / 10 ^ Expy), np, nd, 0)
            CurrentX = TLeftm - glocPic.MeasureString(T, locPic.Font).Width '* 1.5 '(Trightm - TLeftm) / 10
            CurrentY = y1 - glocPic.MeasureString(T, locPic.Font).Height / 2
            glocPic.DrawString(T, locPic.Font, myBrush, CurrentX, CurrentY)
            If j > 0 Then
                y1 = CSng(HBotm + (-0.5 + j) * (HTopm - HBotm) / nRighey)
                glocPic.DrawLine(myPen, TLeftm, y1, Trightm, y1)
            End If
        Next
        CurrentY = CSng(HTopm + (HTopm - HBotm) * 0.75 / 10 - glocPic.MeasureString("A", locPic.Font).Height / 2)
        T = Tity
        If Expy <> 0 Then T = T & "*10^" & LTrim(Str(-Expy))
        CurrentX = CSng(TLeftm - (Trightm - TLeftm) / 10 * 0.75)
        glocPic.DrawString(T, locPic.Font, myBrush, CurrentX, CurrentY)
        CurrentX = CSng(TLeftm + 0.25 * (Trightm - TLeftm))
        n = CShort(InStr(Titolo, "|"))
        If n = 0 Then
            glocPic.DrawString(Titolo, locPic.Font, myBrush, CurrentX, CurrentY)
        Else
            T = Left(Titolo, n - 1)
            glocPic.DrawString(T, locPic.Font, myBrush, CurrentX, CurrentY)
            CurrentX = CSng(TLeftm + 0.25 * (Trightm - TLeftm))
            T = Right(Titolo, Len(Titolo) - n)
            glocPic.DrawString(T, locPic.Font, myBrush, CurrentX, CurrentY)
        End If
    End Sub
    Public Sub SDisCurva(Optional ByRef nn As Short = 0)
        Dim Curva As clsCurva
        If nn = 0 Then
            For Each Curva In Curve
                nn = CShort(nn + 1)
                Call Display(Curva, CInt(nn))
            Next Curva
        Else
            Curva = CType(Curve.Item(nn), clsCurva)
            Call Display(Curva, CInt(nn))
        End If
    End Sub
    Private Sub Display(ByVal Curva As clsCurva, ByVal nn As Integer)
        Dim i As Short
        Dim y As Single
        Dim j As Short
        Dim CurrentX, CurrentY As Single
        Dim myPen As New Pen(Color.Black)
        myPen.DashStyle = DashStyle.Solid
        Dim myBrush As New SolidBrush(Color.Black)
        If Len(Curva.Didasc) > 0 Then
            CurrentY = CSng(HBotm + ((nn + 1) * 0.8 * glocPic.MeasureString(Curva.Didasc, locPic.Font).Width + (HTopm - HBotm) / 20))
            y = CurrentY + glocPic.MeasureString(Curva.Didasc, locPic.Font).Height / 2
            CurrentX = CSng(TLeftm + 1.1 * (Trightm - TLeftm) / 10)
            glocPic.DrawString(Curva.Didasc, locPic.Font, myBrush, CurrentX, CurrentY)
            myPen.DashStyle = Curva.Stile
            glocPic.DrawLine(myPen, TLeftm, y, TLeftm + (Trightm - TLeftm) / 10, y)
        End If
        With Curva.P
            For i = 1 To CShort(.Punti.Count() - 1)
                If Not (.Punti.Item(i).TextData.y = 0 Or .Punti.Item(i + 1).TextData.y = 0) Then
                    CurrentX = .Punti.Item(i + 1).TextData.X
                    CurrentY = .Punti.Item(i + 1).TextData.y
                    glocPic.DrawLine(myPen, .Punti.Item(i).TextData.X, .Punti.Item(i).TextData.y, CurrentX, CurrentY)
                    j = CShort(i + 1)
                    Exit For
                End If
            Next
            If j > 0 Then
                For i = j To CShort(.Punti.Count())
                    If Not .Punti.Item(i).TextData.y = 0 Then glocPic.DrawLine(myPen, CurrentX, CurrentY, .Punti.Item(i).TextData.X, .Punti.Item(i).TextData.y)
                    CurrentX = .Punti.Item(i).TextData.X
                    CurrentY = .Punti.Item(i).TextData.y
                Next
            End If
        End With
    End Sub
    Public Sub Ammazza() '17/01/01
        locForm.Hide()
        locForm.Close()
    End Sub
    Public Sub Inizializza(ByRef lHTop As Single, ByRef lHBot As Single, ByRef lTRight As Single, _
    ByRef lTLeft As Single, ByRef lTitx As String, ByRef lTity As String, ByRef Tit As String, _
    Optional ByRef Pic As System.Windows.Forms.PictureBox = Nothing)
        Dim P As System.Windows.Forms.PictureBox
        If Trigon Is Nothing Then Trigon = New clsTrigon
        Titolo = Tit
        If Pic Is Nothing Then
            locForm = New frmGrafico
            P = locForm.Pittura
        Else
            P = Pic
        End If
        SetGrafico(lHTop, lHBot, lTRight, lTLeft, P, lTitx, lTity)
        If Pic Is Nothing Then
            locForm.obj = Me
            locForm.Show()
        End If
    End Sub
    Private Sub P_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        glocPic = e.Graphics
    End Sub
    Public Sub Salva(ByRef File As String)
        locPic.Image.Save(File, System.Drawing.Imaging.ImageFormat.Bmp)
    End Sub
End Class