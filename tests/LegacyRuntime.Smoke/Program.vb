Imports System.IO
Imports System.Runtime.Serialization
Imports Lancio.Legacy.Serialization

Module Program
    Private count As Integer
    Sub Main()
        Dim fixed As New FixedRecordString(4)
        Equal("    ", fixed.Value)
        fixed.Value = "A" : Equal("A   ", fixed.Value)
        fixed.Value = "abcdef" : Equal("abcd", fixed.Value)
        fixed.Value = Nothing : Equal("    ", fixed.Value)
        Dim file = Path.GetTempFileName()
        Dim number = FreeFile()
        Try
            fixed.Value = "ABCD"
            FileOpen(number, file, OpenMode.Binary, OpenAccess.ReadWrite)
            FilePut(number, fixed.Value, 1)
            fixed.Value = ""
            FileGet(number, fixed.Value, 1)
            Equal("ABCD", fixed.Value)
            Mid(fixed.Value, 2, 2) = "xy"
            FilePut(number, fixed.Value, 1)
            fixed.Value = ""
            FileGet(number, fixed.Value, 1)
            Equal("AxyD", fixed.Value)
        Finally
            FileClose(number)
            IO.File.Delete(file)
        End Try
        Dim previous = Environment.GetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER")
        Try
            Environment.SetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER", Nothing)
            Dim serializer As New LegacyBinarySerializer()
            Using stream As New MemoryStream()
                Try
                    serializer.Serialize(stream, "refused")
                    Throw New Exception("Missing opt-in must refuse serialization.")
                Catch ex As SerializationException
                    If stream.Length <> 0 Then Throw New Exception("Refused serialization wrote bytes.")
                    count += 1
                End Try
                Try
                    serializer.Deserialize(stream)
                    Throw New Exception("Missing opt-in must refuse deserialization.")
                Catch ex As SerializationException
                    count += 1
                End Try
                Environment.SetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER", "1")
                Dim root As New Node With {.Name = "round trip"}
                root.Next = root
                serializer.Serialize(stream, root)
                stream.Position = 0
                Dim copy = DirectCast(serializer.Deserialize(stream), Node)
                Equal(root.Name, copy.Name)
                If Not Object.ReferenceEquals(copy, copy.Next) Then Throw New Exception("Cycle was not preserved.")
                count += 1
            End Using
        Finally
            Environment.SetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER", previous)
        End Try
        Console.WriteLine($"PASS: {count} fixed-record and isolated legacy serialization checks.")
        Console.WriteLine("NOT RUN: original .NET Framework job files or Windows UI.")
    End Sub
    Private Sub Equal(expected As String, actual As String)
        If expected <> actual Then Throw New Exception($"Expected '{expected}', got '{actual}'.")
        count += 1
    End Sub
    <Serializable>
    Private Class Node
        Public Name As String
        Public [Next] As Node
    End Class
End Module
