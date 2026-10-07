# Verifica del ripristino — 7 ottobre 2026

SDK effettivo: **10.0.401**, conforme a global.json. Ambiente di verifica: Linux,
con targeting Windows abilitato. Originali legacy e branch main non modificati.

| Verifica | Esito |
| --- | --- |
| LancioNET10.Full.slnx Debug, tutti i 26 progetti VB | PASS, 0 errori |
| LancioNET10.Full.slnx Release, tutti i 26 progetti VB | PASS, 0 errori |
| LancioNET10.App.slnx Debug, Lancion e 20 dipendenze | PASS, 0 errori |
| LancioNET10.slnx Debug, componenti/harness/test Windows compilati | PASS, 0 errori |
| FormulaParser | 22 controlli superati |
| Access SQL/schema, senza DB reale | 32 controlli superati |
| Word lifecycle, backend simulato | 22 controlli superati |
| Record fissi, serializzazione isolata, fattore mancante/XSteam assente | 20 controlli superati |
| Routine originali ASME cilindro | 21 controlli superati |
| Avvio della GUI su Windows, test Windows form/clsjob | Non eseguiti nel cloud Linux |
| Word/Office/AutoCAD reali, provider Access e DLL Fortran | Non eseguiti |
| Workflow GitHub Actions Windows aggiornato | Predisposto; esito remoto non verificato |
| Launcher PowerShell Windows | Predisposto; non eseguito nel cloud Linux |

Totale controlli effettivamente eseguiti: **117**, tutti superati.
Rimangono warning del codice legacy e del designer WFO1000; non e' una build
senza warning. Il resx HelpTopics segnala str7278 duplicato.

Lancio.exe, AsmeLib.dll, MathAV.dll e Dforrt.dll sono presenti nell'output
`src/Lancion/bin/Release/net10.0-windows/win-x86/`. Le tre DLL native copiate
corrispondono byte per byte agli originali forniti. Non sono aggiunte a Git come
output di build. La GUI principale non richiede Python.

Il CI Windows compila la soluzione completa, controlla questi file e verifica
le collezioni/form senza database reali, inclusa l'assenza di file JOB creati
quando il formato legacy e' disabilitato. Le API GitHub del cloud non consentono
di leggere lo stato remoto; un push non e' considerato una prova di CI superata.

[Avvio in Visual Studio 2026 e percorsi funzionali ancora sospesi](full-application-restoration.md).
