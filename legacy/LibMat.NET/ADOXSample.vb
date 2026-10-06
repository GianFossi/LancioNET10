
Module ADOXSample
    'Dim cat As ADODB.Connection
    Private Sub Sample()
        Dim cat As New ADOX.Catalog
        Dim FilePath As String
        Dim bAns As Boolean
        Try
            'Make sure the folder
            'provided in the path exists. If file name w/o path 
            'is specified, the database will be created in your
            'application folder.
            Dim sCreateString As String
            sCreateString = _
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FilePath
            cat.Create(sCreateString)
            bAns = True
        Catch Excep As System.Runtime.InteropServices.COMException
            bAns = False
            'MsgBox("Database Could Not Be Created! " & Excep.ToString)
            ' DELETE DATABASE
            Try
                Kill(FilePath)
            Catch ex As Exception
                MsgBox("Someone has an exclusive lock on the database. Try again later.")
                Exit Sub
            End Try
            ' CREATE DATABASE
            Dim sCreateString As String
            sCreateString = _
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FilePath
            cat.Create(sCreateString)
            bAns = True
        Finally
            cat = Nothing
        End Try
        If bAns Then
            'Dim Cn As ADODB.Connection
            Dim Catlog As ADOX.Catalog
            Dim objTable As ADOX.Table, jKey As ADOX.KeyTypeEnum
            'Cn = New ADODB.Connection
            Catlog = New ADOX.Catalog
            objTable = New ADOX.Table
            'Open the connection
            'Cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FilePath) 'Open the Catalog
            'Catlog.ActiveConnection = Cn 'Create the table CrescSongs
            objTable.Name = "CrescSongs"
            objTable.ParentCatalog = Catlog 'Append fields
            objTable.Columns.Append("SongTitle", ADOX.DataTypeEnum.adVarWChar, 255)
            objTable.Columns.Append("Songkey", ADOX.DataTypeEnum.adInteger)
            'add autonumber property here
            objTable.Columns("Songkey").Properties("Autoincrement").Value = True
            objTable.Columns("Songkey").Properties("Nullable").Value = False
            'objTable.Columns("songkey").Properties("duplicates").Value = False
            objTable.Columns.Append("SongLicense", ADOX.DataTypeEnum.adVarWChar, 255)
            objTable.Columns("sONGlICENSE").Properties("default").Value = ""
            'create promary key
            objTable.Keys.Append("PrimaryKey", CType(ADOX.DataTypeEnum.adInteger, ADOX.KeyTypeEnum), _
            "Songkey")
            objTable.Indexes.Append("Title", "SongTitle")
            objTable.Indexes.Append("Songkey", "SongKey")  ' append table to collection
            Catlog.Tables.Append(objTable)
            'Cn.Close()
        End If
    End Sub
End Module
