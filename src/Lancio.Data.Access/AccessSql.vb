Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Collections.Generic

Public NotInheritable Class AccessSql
    Private Sub New()
    End Sub

    Public Shared Function QuoteIdentifier(name As String) As String
        If String.IsNullOrWhiteSpace(name) OrElse name.IndexOfAny({"["c, "]"c}) >= 0 OrElse
           name.Any(Function(c) Char.IsControl(c)) Then
            Throw New ArgumentException("A nonempty unquoted Access/Excel identifier without brackets or control characters is required.", NameOf(name))
        End If
        Return "[" & name & "]"
    End Function

    Public Shared Function DistinctMaterials(tableName As String) As String
        Return "SELECT DISTINCT [MATERIAL] FROM " & QuoteIdentifier(tableName)
    End Function

    ' Schema comes from OleDbDataReader.GetSchemaTable, not inferred from row values.
    Public Shared Function CreateMaterialTable(schema As DataTable, targetName As String) As String
        If schema Is Nothing OrElse schema.Rows.Count = 0 Then
            Throw New ArgumentException("The source table has no column schema.", NameOf(schema))
        End If
        Dim columns As New List(Of String)
        Dim seen As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim hasId As Boolean = False
        Dim rows = schema.Select("", "ColumnOrdinal ASC")
        For Each row In rows
            Dim name = Convert.ToString(row("ColumnName"), CultureInfo.InvariantCulture)
            If Not seen.Add(name) Then Throw New ArgumentException("Duplicate column: " & name)
            Dim providerType = CType(Convert.ToInt32(row("ProviderType"), CultureInfo.InvariantCulture), OleDbType)
            Dim declaration As String
            If String.Equals(name, "ID", StringComparison.OrdinalIgnoreCase) Then
                If providerType <> OleDbType.Integer Then
                    Throw New NotSupportedException("The material ID must be a 32-bit integer before conversion to COUNTER.")
                End If
                declaration = "COUNTER NOT NULL CONSTRAINT [PrimaryKey] PRIMARY KEY"
                hasId = True
            Else
                declaration = ColumnType(row, providerType)
            End If
            columns.Add(QuoteIdentifier(name) & " " & declaration)
        Next
        If Not hasId Then Throw New ArgumentException("The source material schema has no ID column.")
        Return "CREATE TABLE " & QuoteIdentifier(targetName) & " (" & String.Join(", ", columns) & ")"
    End Function

    ' RoutBase historically forces the first selected column to auto-increment,
    ' makes the remaining columns nullable and copies source indexes.
    Public Shared Function CloneTablePlan(schema As DataTable, indexes As DataTable,
                                          captions As String(), targetName As String) As String()
        If captions Is Nothing OrElse captions.Length = 0 Then Throw New ArgumentException("No columns selected.")
        Dim definitions As New List(Of String)
        Dim selected As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For i = 0 To captions.Length - 1
            Dim name = captions(i)
            If Not selected.Add(name) Then Throw New ArgumentException("Duplicate column: " & name)
            Dim matches = schema.Rows.Cast(Of DataRow)().Where(Function(r) String.Equals(CStr(r("ColumnName")), name, StringComparison.OrdinalIgnoreCase)).ToArray()
            If matches.Length <> 1 Then Throw New ArgumentException("Source column missing or ambiguous: " & name)
            Dim kind = CType(Convert.ToInt32(matches(0)("ProviderType")), OleDbType)
            Dim declaration = ColumnType(matches(0), kind)
            If i = 0 Then
                If kind <> OleDbType.Integer Then Throw New NotSupportedException("Auto-increment requires a 32-bit integer first column.")
                declaration = "COUNTER NOT NULL"
            End If
            definitions.Add(QuoteIdentifier(name) & " " & declaration)
        Next
        Dim statements As New List(Of String) From {
            "CREATE TABLE " & QuoteIdentifier(targetName) & " (" & String.Join(", ", definitions) & ")"}
        If indexes Is Nothing Then Throw New NotSupportedException("Provider returned no index metadata.")
        For Each group In indexes.Rows.Cast(Of DataRow)().GroupBy(Function(r) CStr(r("INDEX_NAME")), StringComparer.OrdinalIgnoreCase)
            Dim ordered = group.OrderBy(Function(r) Convert.ToInt32(r("ORDINAL_POSITION"))).ToArray()
            Dim first = ordered(0)
            Dim columns As New List(Of String)
            For Each row In ordered
                Dim name = CStr(row("COLUMN_NAME"))
                If Not selected.Contains(name) Then Throw New NotSupportedException("Index references an unselected column: " & name)
                Dim direction As String = ""
                If Not row.IsNull("COLLATION") Then
                    Select Case Convert.ToInt32(row("COLLATION"))
                        Case 1 : direction = " ASC"
                        Case 2 : direction = " DESC"
                        Case Else : Throw New NotSupportedException("Unsupported index collation.")
                    End Select
                End If
                columns.Add(QuoteIdentifier(name) & direction)
            Next
            Dim flags As String = ""
            If CBool(first("PRIMARY_KEY")) Then flags = " PRIMARY"
            If first.IsNull("NULLS") Then Throw New NotSupportedException("Missing index NULL policy.")
            Select Case Convert.ToInt32(first("NULLS"))
                Case 1 : flags &= " DISALLOW NULL"
                Case 2 : flags &= " IGNORE NULL"
                Case 0 ' Allow NULL: Access default.
                Case Else : Throw New NotSupportedException("Unsupported index NULL policy.")
            End Select
            statements.Add("CREATE " & If(CBool(first("UNIQUE")), "UNIQUE ", "") & "INDEX " &
                           QuoteIdentifier(group.Key) & " ON " & QuoteIdentifier(targetName) &
                           " (" & String.Join(", ", columns) & ")" & If(flags = "", "", " WITH" & flags))
        Next
        Return statements.ToArray()
    End Function

    Private Shared Function ColumnType(row As DataRow, kind As OleDbType) As String
        Select Case kind
            Case OleDbType.UnsignedTinyInt : Return "BYTE"
            Case OleDbType.SmallInt : Return "SHORT"
            Case OleDbType.Integer : Return "LONG"
            Case OleDbType.Single : Return "SINGLE"
            Case OleDbType.Double : Return "DOUBLE"
            Case OleDbType.Currency : Return "CURRENCY"
            Case OleDbType.Boolean : Return "BIT"
            Case OleDbType.Date, OleDbType.DBDate, OleDbType.DBTime, OleDbType.DBTimeStamp : Return "DATETIME"
            Case OleDbType.LongVarChar, OleDbType.LongVarWChar : Return "LONGTEXT"
            Case OleDbType.Char, OleDbType.WChar, OleDbType.VarChar, OleDbType.VarWChar
                Dim size = Convert.ToInt32(row("ColumnSize"), CultureInfo.InvariantCulture)
                If size < 1 OrElse size > 255 Then
                    Throw New NotSupportedException("Short text column size must be between 1 and 255; refusing implicit conversion to memo.")
                End If
                Return "TEXT(" & size.ToString(CultureInfo.InvariantCulture) & ")"
            Case OleDbType.Decimal, OleDbType.Numeric
                Dim precision = Convert.ToInt32(row("NumericPrecision"), CultureInfo.InvariantCulture)
                Dim scale = Convert.ToInt32(row("NumericScale"), CultureInfo.InvariantCulture)
                If precision < 1 OrElse precision > 28 OrElse scale < 0 OrElse scale > precision Then
                    Throw New NotSupportedException("Unsupported Access decimal precision/scale.")
                End If
                Return "DECIMAL(" & precision.ToString(CultureInfo.InvariantCulture) & "," & scale.ToString(CultureInfo.InvariantCulture) & ")"
            Case Else
                Throw New NotSupportedException("Unmapped Access provider type: " & kind.ToString() & ". No table was created.")
        End Select
    End Function
End Class
