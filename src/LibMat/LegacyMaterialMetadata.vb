Option Strict On
Imports System.Globalization

' Original source refers to clsTrigon.kWATT, absent from all supplied RoutBase sources.
' Never guess a factor in an engineering calculation. Keep the requirement explicit.
Friend NotInheritable Class LegacyMaterialMetadata
    Public Shared ReadOnly Property ThermalConductivityFactor As Single
        Get
            Dim setting = Environment.GetEnvironmentVariable("LANCIO_LEGACY_KWATT")
            Dim factor As Single
            If Not Single.TryParse(setting, NumberStyles.Float, CultureInfo.InvariantCulture, factor) OrElse
               Not Single.IsFinite(factor) OrElse factor <= 0 Then
                Throw New InvalidOperationException("Il fattore originale clsTrigon.kWATT non e' presente nei sorgenti disponibili. La conversione di conducibilita' termica richiede un valore verificato e le unita' della tabella originale (LANCIO_LEGACY_KWATT). Nessun fattore predefinito e' applicato.")
            End If
            Return factor
        End Get
    End Property
End Class
