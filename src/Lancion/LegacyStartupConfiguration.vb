Option Strict On
Imports System.Windows.Forms

Friend Module LegacyStartupConfiguration
    Public Function Initialize(inizio As RoutBase1.clsInizio) As Short
        Dim result = inizio.Standard()
        If result <> 1 Then Return result
        Using dialog As New OpenFileDialog With {
            .Title = "Seleziona una copia di LancioNET.ini configurata per questo PC",
            .Filter = "Configurazione Lancion (*.ini)|*.ini",
            .FileName = "LancioNET.ini",
            .CheckFileExists = True, .CheckPathExists = True}
            If dialog.ShowDialog() <> DialogResult.OK Then Return result
            ' Process-local setting; the selected file still undergoes the original checks.
            Environment.SetEnvironmentVariable("LANCIO_INI", dialog.FileName)
            Return inizio.Standard()
        End Using
    End Function
End Module
