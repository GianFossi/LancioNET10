Option Strict On
Friend Module LegacyStartup
    Public Function Initialize(inizio As RoutBase1.clsInizio) As Short
        If String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("LANCIO_INI")) Then
            Throw New NotSupportedException("LancioHTRI richiede un INI esplicito tramite LANCIO_INI: la versione RoutBase fornita non contiene Standard(Assembly).")
        End If
        Return inizio.Standard()
    End Function
End Module
