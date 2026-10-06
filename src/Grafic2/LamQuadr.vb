Option Strict Off
Option Explicit On
Imports System.Math
Imports System.Data
Imports System.Data.OleDb
<Serializable()> Public Class clsLamQuadr
    Public TopLeft As New RoutBase1.clsVec2
    Public Botrigt As New RoutBase1.clsVec2
    Public Sub Scrivi(ByRef IDLam As Short, ByRef i As Short)
        Dim dv As New DataView(iflLamQuadr)
        Dim drv As DataRowView
        dv.Sort = "Ordine"
        Dim iFound As Integer = dv.Find(i.ToString)
        If iFound = -1 Then
            drv = dv.AddNew()
            drv("IDLam") = IDLam
        Else
            drv = dv(iFound)
            drv.BeginEdit()
        End If
        drv("Ordine") = i
        drv("TopLeftx") = TopLeft.X
        drv("TopLefty") = TopLeft.y
        drv("Botrigtx") = Botrigt.X
        drv("Botrigty") = Botrigt.y
        drv.EndEdit()
        cmdLamQuadr.Update(iflLamQuadr)
    End Sub
    Public Function leggi(ByRef i As Short) As Boolean
        Dim dv As New DataView(iflLamQuadr)
        Dim drv As DataRowView
        dv.Sort = "Ordine"
        Dim iFound As Integer = dv.Find(i.ToString)
        If iFound = -1 Then
            MsgBox("Errore leggi")
            leggi = False
            Exit Function
        End If
        drv = dv(iFound)
        TopLeft.X = drv("TopLeftx")
        TopLeft.y = drv("TopLefty")
        Botrigt.X = drv("Botrigtx")
        Botrigt.y = drv("Botrigty")
        leggi = True
    End Function
    Public Sub DrawRE(ByRef Margin As Single, ByRef LARG As Single, ByRef Mode As Short, ByRef NumP As Short)
        Dim SubRect As New RoutBase1.Rettangolo
        Dim H As Single
        MakeRectQuadro(SubRect, Margin, LARG)
        'Debug.Print SubRect.x(1); SubRect.y(1); SubRect.x(3); SubRect.y(3)
        SubRect.RettGraf(Funzioni.DisRut, Mode)
        If Mode = 2 Then
            If SubRect.x(2) - SubRect.x(1) < 8 Or SubRect.y(3) - SubRect.y(1) < 30 Then H = 1.5 Else H = 3
            Funzioni.DisRut.texts(SubRect.x(2) - 1.0!, SubRect.y(2) + 1.0!, Str(NumP), H, PI / 2.0!, 0.15)
        End If
    End Sub
    Public Sub MakeRectQuadro(ByRef SubRect As RoutBase1.Rettangolo, ByRef Margin As Single, ByRef LARG As Single)
        Dim k As Short
        SubRect.MakeCorners(Botrigt.y - TopLeft.y - Margin, Botrigt.X - TopLeft.X - Margin)
        For k = 1 To 4
            '           SubRect.x(k) = SubRect.x(k) + TopLeft.x + Margin / 2 + (Botrigt.x - TopLeft.x - Margin - LARG) / 2
            '           SubRect.y(k) = SubRect.y(k) + TopLeft.y + Margin / 2
            SubRect.x(k) = SubRect.x(k) + TopLeft.X + Margin / 2 + (Botrigt.X - TopLeft.X - Margin - LARG) / 2
            SubRect.y(k) = SubRect.y(k) + TopLeft.y + Margin / 2
        Next k
    End Sub
    Public Sub Copia(ByRef A As clsLamQuadr)
        With A
            .TopLeft.X = TopLeft.X
            .TopLeft.y = TopLeft.y
            .Botrigt.X = Botrigt.X
            .Botrigt.y = Botrigt.y
        End With
    End Sub
    Public Sub Apri(ByRef MDB As OleDbConnection, ByRef IDLam As Short)
        If Not iflLamQuadr Is Nothing Then iflLamQuadr.Dispose()
        cmdLamQuadr = New OleDbDataAdapter("SELECT * FROM Quadri WHERE IDLam=" & Str(IDLam), MDB)
        cmdLamQuadr.Fill(iflLamQuadr) '= MDB.OpenRecordset("SELECT * FROM Quadri WHERE IDLam=" & Str(IDLam))
        CBLAmQuadr = New OleDbCommandBuilder(cmdLamQuadr)
    End Sub
    Public Sub Chiudi()
        iflLamQuadr.Dispose()
    End Sub
    Public Sub Delete(ByRef MDB As OleDbConnection, ByRef i As Integer)
        Dim l As New DataTable
        Dim ii As Integer
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Quadri WHERE IDLam=" & Str(i), MDB)
        Dim CB As New OleDbCommandBuilder(cmd)
        cmd.Fill(l) ' = MDB.OpenRecordset("SELECT * FROM Quadri WHERE IDLam=" & Str(i))
        Dim dv As New DataView(l)
        Dim drv As DataRowView
        For ii = 0 To l.Rows.Count - 1
            drv = dv(ii)
            drv.Delete()
        Next
        cmd.Update(l)
        l.Dispose()
        cmd.Dispose()
        CB.Dispose()
    End Sub
End Class