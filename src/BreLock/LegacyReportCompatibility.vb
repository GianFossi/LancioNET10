Option Strict On
Friend Module LegacyReportCompatibility
    Public Sub Testata(motore As RoutBase1.clsMotore, numeraPagine As Boolean)
        Throw New NotSupportedException("La versione RoutBase fornita non contiene Testata(NumeraPagine). Recuperare o verificare il contratto originale prima di stampare rapporti BreLock.")
    End Sub
    Public Sub SetTotalPages(motore As RoutBase1.clsMotore, totalPages As Integer)
        Throw New NotSupportedException("La versione RoutBase fornita non contiene clsProblem.pagtot richiesto dai rapporti BreLock.")
    End Sub
End Module
