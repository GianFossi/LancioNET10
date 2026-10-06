Imports System.Data
Imports System.Data.OleDb
Public Class Motore2
    Private Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Private Const ConnFine As String = ";Persist Security Info=False"
    Public Shared Function Autorizzazione(ByRef Oper As String, ByRef Sigla As String, ByVal m As RoutBase1.clsMotore) As Boolean
        Dim i, j As Short
        Dim Testo As String
        Dim Autorizz As Boolean
        Dim cString As String = Conn & m.Inizio.Archdir & "\Gestione\Commesse.mdb" & ConnFine
        Dim cnConn As OleDbConnection = New OleDbConnection(cString)
        Autorizzazione = True
        If Not m.Inizio.InRete Then
            Sigla = Environment.MachineName.Substring(0, 3)
            Exit Function
        End If
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * from Autorizz WHERE Operazione = '" & Oper & "'", cnConn)
        Dim MyTable1 As DataTable = New DataTable("Autorizz")
        cmd.Fill(MyTable1)
        If MyTable1.Rows.Count = 0 Then
            MyTable1.Dispose()
            cmd.Dispose()
            Exit Function
        End If
        Dim cmd1 As OleDbDataAdapter = New OleDbDataAdapter("SELECT * from Utenti WHERE Utente = '" & m.Inizio.Utente & "'", cnConn)
        Dim MyTable2 As DataTable = New DataTable("Utenti")
        cmd1.Fill(MyTable2)
        If MyTable2.Rows.Count = 0 Then
            MyTable1.Dispose()
            MyTable2.Dispose()
            cmd.Dispose()
            cmd1.Dispose()
            Autorizz = False
            If m.Inizio.Utente.Length = 0 Then m.Inizio.Utente = "Utente sconosciuto"
            GoTo ju
        End If
        Autorizz = False
        Sigla = CStr(MyTable2.Rows(0)("Sigla"))
        For i = 3 To 5
            For j = 2 To 10
                If CStr(MyTable1.Rows(0)(j)) = CStr(MyTable2.Rows(0)(i)) Then Autorizz = True : Exit For
            Next j
        Next i
        MyTable1.Dispose()
        MyTable2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
ju:     If Not Autorizz Then
            Testo = "Sig. " & Trim(m.Inizio.Utente) & ",| Lei non ha le autorizzazioni"
            Testo = Testo & "|per questa operazione."
            MsgBox(m.Inizio.ConvertiCr(Testo), MsgBoxStyle.Critical)
        End If
        Autorizzazione = Autorizz
    End Function

End Class
