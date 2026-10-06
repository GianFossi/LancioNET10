Imports System.Data
Imports System.Data.OleDb
Imports Lancio.Data.Access

Module Program
    Private count As Integer
    Sub Main()
        Equal("[Sheet 1$]", AccessSql.QuoteIdentifier("Sheet 1$"))
        Equal("SELECT DISTINCT [MATERIAL] FROM [Prodotti$]", AccessSql.DistinctMaterials("Prodotti$"))
        Reject(Of ArgumentException)(Sub() AccessSql.QuoteIdentifier(""))
        Reject(Of ArgumentException)(Sub() AccessSql.QuoteIdentifier("x] DROP TABLE y"))
        Reject(Of ArgumentException)(Sub() AccessSql.QuoteIdentifier("x" & vbCr))
        Dim mappings As (Kind As OleDbType, Sql As String)() = {
            (OleDbType.UnsignedTinyInt, "BYTE"), (OleDbType.SmallInt, "SHORT"),
            (OleDbType.Integer, "LONG"), (OleDbType.Single, "SINGLE"),
            (OleDbType.Double, "DOUBLE"), (OleDbType.Currency, "CURRENCY"),
            (OleDbType.Boolean, "BIT"), (OleDbType.Date, "DATETIME"),
            (OleDbType.LongVarWChar, "LONGTEXT"), (OleDbType.VarWChar, "TEXT(40)"),
            (OleDbType.Numeric, "DECIMAL(12,3)")
        }
        For Each item In mappings
            Using schema = MakeSchema(item.Kind)
                Equal("CREATE TABLE [PR1P2] ([ID] COUNTER NOT NULL CONSTRAINT [PrimaryKey] PRIMARY KEY, [VALUE] " & item.Sql & ")",
                      AccessSql.CreateMaterialTable(schema, "PR1P2"))
            End Using
        Next
        Using schema = MakeSchema(OleDbType.VarWChar)
            schema.Rows(1)("ColumnSize") = 256
            Reject(Of NotSupportedException)(Sub() AccessSql.CreateMaterialTable(schema, "NewTable"))
        End Using
        Using schema = MakeSchema(OleDbType.Decimal)
            schema.Rows(1)("NumericScale") = 13
            Reject(Of NotSupportedException)(Sub() AccessSql.CreateMaterialTable(schema, "NewTable"))
        End Using
        Using schema = MakeSchema(OleDbType.Binary)
            Reject(Of NotSupportedException)(Sub() AccessSql.CreateMaterialTable(schema, "NewTable"))
        End Using
        Using schema = MakeSchema(OleDbType.Double)
            schema.Rows(0)("ProviderType") = CInt(OleDbType.Double)
            Reject(Of NotSupportedException)(Sub() AccessSql.CreateMaterialTable(schema, "NewTable"))
            schema.Rows(0)("ColumnName") = "OTHER"
            Reject(Of ArgumentException)(Sub() AccessSql.CreateMaterialTable(schema, "NewTable"))
        End Using
        Using schema = MakeSchema(OleDbType.Double)
            schema.Rows(1)("ColumnName") = "id"
            Reject(Of ArgumentException)(Sub() AccessSql.CreateMaterialTable(schema, "NewTable"))
        End Using
        Console.WriteLine($"PASS: {count} Access SQL/schema planning checks.")
        Console.WriteLine("NOT RUN: Windows Jet/ACE execution, database transactions and Excel integration.")
    End Sub

    Private Function MakeSchema(kind As OleDbType) As DataTable
        Dim schema As New DataTable()
        schema.Columns.Add("ColumnName", GetType(String))
        schema.Columns.Add("ColumnOrdinal", GetType(Integer))
        schema.Columns.Add("ProviderType", GetType(Integer))
        schema.Columns.Add("ColumnSize", GetType(Integer))
        schema.Columns.Add("NumericPrecision", GetType(Integer))
        schema.Columns.Add("NumericScale", GetType(Integer))
        schema.Rows.Add("ID", 0, CInt(OleDbType.Integer), 4, 10, 0)
        schema.Rows.Add("VALUE", 1, CInt(kind), 40, 12, 3)
        Return schema
    End Function

    Private Sub Equal(expected As String, actual As String)
        If expected <> actual Then Throw New Exception($"Expected {expected}, actual {actual}")
        count += 1
    End Sub

    Private Sub Reject(Of T As Exception)(action As Action)
        Try
            action()
        Catch ex As Exception
            If Not TypeOf ex Is T Then Throw
            count += 1
            Return
        End Try
        Throw New Exception("Expected rejection: " & GetType(T).Name)
    End Sub
End Module
