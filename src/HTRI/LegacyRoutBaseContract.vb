Option Strict On
Imports System.Reflection

' An explicit boundary for APIs from a different, unavailable RoutBase version.
' No alternate storage layout or estimate decoding is invented here.
Friend Module LegacyRoutBaseContract
    Public Function InvokeRequired(target As Object, name As String, ParamArray arguments As Object()) As Object
        Try
            Return target.GetType().InvokeMember(name, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.InvokeMethod,
                binder:=Nothing, target:=target, args:=arguments)
        Catch ex As MissingMethodException
            Throw New NotSupportedException("HTRI richiede la versione originale RoutBase con " & name & "(" & arguments.Length & " argomenti). Il percorso resta sospeso per preservare i dati originali.", ex)
        End Try
    End Function
    Public Function GetAddress(comm As RoutBase1.clsComm) As String
        Dim field = comm.GetType().GetField("Indirizzo")
        If field Is Nothing Then Throw New NotSupportedException("HTRI richiede clsComm.Indirizzo, assente nella versione RoutBase fornita.")
        Return DirectCast(field.GetValue(comm), String)
    End Function
    Public Sub SetAddress(comm As RoutBase1.clsComm, address As String)
        Dim field = comm.GetType().GetField("Indirizzo")
        If field Is Nothing Then Throw New NotSupportedException("HTRI richiede clsComm.Indirizzo, assente nella versione RoutBase fornita.")
        field.SetValue(comm, address)
    End Sub
End Module

Friend Class LegacyEstimateDatabase
    Inherits RoutBase1.DatBase
    Public Sub New(Optional motore As RoutBase1.clsMotore = Nothing)
        If motore IsNot Nothing Then objInizio = motore.Inizio
    End Sub
    Public Sub Open(path As String)
        Throw New NotSupportedException("L'importazione PRV di HTRI richiede DatBase.Open della versione RoutBase originale non fornita.")
    End Sub
    Public Sub Close()
        Throw New NotSupportedException("La versione originale DatBase.Close di HTRI non e' presente.")
    End Sub
    Public Overloads Function DatBase(ByRef nre As Short, ByRef ndat As Short, ByRef item As Short, ByRef ialt As Short, ByRef itp As String) As String
        Throw New NotSupportedException("La lettura PRV HTRI richiede DatBase a cinque argomenti. Il significato del parametro ilsi della versione fornita deve essere verificato, senza assumere un valore predefinito.")
    End Function
End Class
