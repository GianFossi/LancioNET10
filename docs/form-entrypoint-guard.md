# Istanze predefinite dei form in librerie (2026-10-07)

Il codice generato legacy nei costruttori controllava EntryPoint.DeclaringType
per individuare il form di avvio. Gli assembly DLL come LibMat non hanno
EntryPoint: la dereferenziazione generava NullReferenceException, gia' catturata
dal Try/Catch originale, ma visibile al debugger con interruzione sulle eccezioni.

Aggiunto controllo IsNot Nothing con AndAlso nei 75 costruttori con lo stesso
schema. Conservati istanze predefinite, inizializzazione dei controlli, gestori
e calcoli. La modifica evita l'eccezione invece di ignorarla nel debugger.

Verifica: compilazione della soluzione completa su Linux; apertura dei form
nel debugger Windows ancora da verificare. Gli archivi mancanti rimangono
un problema separato: questa correzione non li crea o sostituisce.
