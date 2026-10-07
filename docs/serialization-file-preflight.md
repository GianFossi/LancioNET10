# Verifica del formato legacy prima dell'apertura dei file

Il controllo dentro Serialize/Deserialize non impediva ai chiamanti di creare o
troncare un file prima del rifiuto. EnsureEnabled e' quindi un preflight pubblico:
le 50 routine sorgenti che costruiscono il bridge lo invocano all'ingresso, prima
delle operazioni sui file. I controlli dentro il bridge rimangono attivi.

L'opt-in rimane LANCIO_ENABLE_LEGACY_BINARY_FORMATTER=1, solo per i propri dati
originali fidati. I corpi degli algoritmi e il formato dei dati non sono cambiati.
Lancion spiega il rifiuto durante il controllo di licenza e termina; non bypassa
la licenza. Il launcher PowerShell accetta -EnableTrustedLegacySerialization e
ripristina l'ambiente del chiamante al termine.

Il test Windows usa il vero clsjob.Salva con opt-in assente e verifica che non
venga creato il file JOB. Il test e' compilato nel cloud; l'esecuzione richiede
Windows. I test portabili del bridge restano eseguiti sul cloud Linux.
