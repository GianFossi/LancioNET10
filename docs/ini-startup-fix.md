# Lettura INI durante avvio (2026-10-07)

`Standard()` segnala la chiave DiscoBase vuota prima di impostare RadiceHelp.
`Messaggio()` accettava quel Nothing e chiamava Length, causando una
NullReferenceException che nascondeva il problema della configurazione.
Ora i titoli e i percorsi help nulli ricevono gli stessi default delle stringhe vuote.

GetPrivateProfileStringA usa ora un StringBuilder come buffer di uscita invece
 di una String ByVal immutabile. Sezioni, chiavi, API ANSI, dimensione del buffer
 e valori predefiniti rimangono invariati. Nessuna modifica ai calcoli o alle licenze.

Il test Windows WinForms.Smoke verifica tre letture: DiscoBase, percorso con
spazi e chiave assente. La build Linux verifica la compilazione, ma non esegue
questa API Windows. L'avvio reale deve essere verificato sul PC Windows.
