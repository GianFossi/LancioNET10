Public Class clsAccessoDati
    Public Shared Sub DuplicaTableDef(ByVal vTesta As DataTable, ByVal tabTesta As String, ByVal StringConnection As String)
        Dim Testa As DataTable = vTesta.Clone
        Dim i As Integer
        Testa.TableName = tabTesta
        Dim Catlog As New ADOX.Catalog
        Dim Cn As New ADODB.Connection
        Dim Testax As New ADOX.Table
        Dim cx As ADOX.Column
        Dim c As ADOX.Column
        'Dim k, kx As ADOX.Key
        Dim ind, indx As ADOX.Index
        Try
            Cn.Open(StringConnection)
            Catlog.ActiveConnection = Cn
            Dim tCS1 As ADOX.Table = Catlog.Tables(vTesta.TableName)
            Testax.Name = tabTesta
            For i = 0 To vTesta.Columns.Count - 1
                ' For Each c In tCS1.Columns
                c = tCS1.Columns(vTesta.Columns(i).Caption)
                cx = New ADOX.Column
                cx.Name = c.Name
                cx.Type = c.Type
                cx.DefinedSize = c.DefinedSize
                cx.NumericScale = c.NumericScale
                cx.ParentCatalog = c.ParentCatalog
                cx.Precision = c.Precision
                If i = 0 Then
                    cx.Properties("Autoincrement").Value = True
                Else
                    cx.Properties("Nullable").Value = True
                End If
                Testax.Columns.Append(cx)
            Next
            For Each ind In tCS1.Indexes
                indx = New ADOX.Index
                indx.PrimaryKey = ind.PrimaryKey
                indx.Name = ind.Name
                indx.Unique = ind.Unique
                indx.IndexNulls = ind.IndexNulls
                indx.Columns.Append(ind.Name)
                Testax.Indexes.Append(indx)
            Next
            'For Each k In tCS1.Keys
            ' kx = New ADOX.Key
            ' kx.Name = k.Name
            ' kx.Type = k.Type
            ' kx.RelatedTable = k.RelatedTable
            ' kx.Columns.Append(kx.Name)
            ' Testax.Keys.Append(kx)
            ' Next
            Catlog.Tables.Append(Testax)
            Cn.Close()
        Catch e As Exception
            System.Windows.Forms.MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Shared Sub TableDelete(ByVal Nome As String, ByVal StringConnection As String)
        Dim Catlog As New ADOX.Catalog
        Dim Cn As New ADODB.Connection
        Cn.Open(StringConnection)
        Catlog.ActiveConnection = Cn
        Catlog.Tables.Delete(Nome)
        Cn.Close()
    End Sub

End Class
