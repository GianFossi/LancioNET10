Imports System.Data
Imports System.Data.OleDb

Public NotInheritable Class AccessDatabase
    Private Sub New()
    End Sub

    Public Shared Function ReadDistinctMaterials(connectionString As String, tableName As String) As DataTable
        Dim sql = AccessSql.DistinctMaterials(tableName)
        Using connection As New OleDbConnection(connectionString),
              command As New OleDbCommand(sql, connection)
            connection.Open()
            Using reader = command.ExecuteReader()
                Dim result As New DataTable()
                Try
                    result.Load(reader)
                    Return result
                Catch
                    result.Dispose()
                    Throw
                End Try
            End Using
        End Using
    End Function

    ' Clone only the columns, with the same ID primary key/index requested by the
    ' original ADOX code. Row population remains in the existing LibMat caller.
    Public Shared Function CloneMaterialSchema(connection As OleDbConnection,
                                              sourceTable As String, targetTable As String) As Integer
        If connection Is Nothing Then Throw New ArgumentNullException(NameOf(connection))
        Dim sourceSql = "SELECT * FROM " & AccessSql.QuoteIdentifier(sourceTable)
        AccessSql.QuoteIdentifier(targetTable)
        Dim openedHere = connection.State = ConnectionState.Closed
        If openedHere Then connection.Open()
        Try
            If connection.State <> ConnectionState.Open Then Throw New InvalidOperationException("The Access connection must be open.")
            Dim ddl As String
            Dim count As Integer
            Using command As New OleDbCommand(sourceSql, connection),
                  reader = command.ExecuteReader(CommandBehavior.SchemaOnly),
                  schema = reader.GetSchemaTable()
                ddl = AccessSql.CreateMaterialTable(schema, targetTable)
                count = schema.Rows.Count
            End Using
            ' Fail before changing an existing table. CREATE TABLE also protects
            ' against a table created concurrently after this check.
            Using tables = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                For Each row As DataRow In tables.Rows
                    If String.Equals(CStr(row("TABLE_NAME")), targetTable, StringComparison.OrdinalIgnoreCase) Then
                        Throw New InvalidOperationException("The destination table already exists: " & targetTable)
                    End If
                Next
            End Using
            Using transaction = connection.BeginTransaction()
                Try
                    Using command As New OleDbCommand(ddl, connection, transaction)
                        command.ExecuteNonQuery()
                        command.CommandText = "CREATE INDEX [ID] ON " & AccessSql.QuoteIdentifier(targetTable) & " ([ID])"
                        command.ExecuteNonQuery()
                    End Using
                    transaction.Commit()
                Catch originalError As Exception
                    Try
                        transaction.Rollback()
                    Catch rollbackError As Exception
                        Throw New AggregateException("Schema creation failed and rollback also failed. Inspect the destination before retrying.", originalError, rollbackError)
                    End Try
                    Throw
                End Try
            End Using
            Return count
        Finally
            If openedHere Then connection.Close()
        End Try
    End Function
End Class
