Option Strict On
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

' Transitional reader/writer for original NRBF files, never enabled implicitly.
' Use only for trusted local legacy data in a controlled migration environment.
Public NotInheritable Class LegacyBinarySerializer
    Private Shared Sub RequireExplicitOptIn()
        If Environment.GetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER") <> "1" Then
            Throw New SerializationException("Formato binario legacy: per migrare esclusivamente file locali attendibili, impostare LANCIO_ENABLE_LEGACY_BINARY_FORMATTER=1. Il lettore legacy non e' abilitato per impostazione predefinita.")
        End If
        AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", True)
    End Sub

#Disable Warning SYSLIB0011
    Public Sub Serialize(stream As Stream, graph As Object)
        RequireExplicitOptIn()
        Dim formatter As New BinaryFormatter()
        formatter.Serialize(stream, graph)
    End Sub

    Public Function Deserialize(stream As Stream) As Object
        RequireExplicitOptIn()
        Dim formatter As New BinaryFormatter()
        Return formatter.Deserialize(stream)
    End Function
#Enable Warning SYSLIB0011
End Class
