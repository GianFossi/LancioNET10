Option Strict On
Friend Module LegacyTracciaExport
    Public Sub Scrivi(traccia As Object, ByRef outputPath As String)
        Throw New NotSupportedException("Surrisc richiede Traccia.Scrivi(ByRef File), che restituisce il file da leggere. La versione Traccia fornita contiene soltanto Scrivi() e non specifica questo contratto.")
    End Sub
End Module
