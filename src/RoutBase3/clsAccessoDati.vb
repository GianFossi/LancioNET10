Public Class clsAccessoDati
    Public Shared Sub DuplicaTableDef(ByVal vTesta As DataTable, ByVal tabTesta As String, ByVal StringConnection As String)
        Try
            Lancio.Data.Access.AccessDatabase.CloneTableDefinition(vTesta, tabTesta, StringConnection)
        Catch e As Exception
            System.Windows.Forms.MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Shared Sub TableDelete(ByVal Nome As String, ByVal StringConnection As String)
        Lancio.Data.Access.AccessDatabase.DeleteTable(Nome, StringConnection)
    End Sub
End Class
