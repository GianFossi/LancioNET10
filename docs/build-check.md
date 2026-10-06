# Verifica completa di inventario e build

Verificato origin/main al commit `a7ab45c`, senza ulteriori caricamenti remoti.
Ambiente: Linux, SDK .NET 10.0.401. Tutte le prove sono state eseguite dalla
radice del checkout sulla branch migration/vb-net10-inventory. Gli exit code
delle singole build sono stati acquisiti direttamente dal processo dotnet.

## Risultati eseguiti

| Target / comando | Exit code | Risultato |
| --- | ---: | --- |
| dotnet build LancioNET10.slnx -c Release | 0 | Build riuscita di FormulaParser e del runner di verifica |
| dotnet run --project tests/FormulaParser.Smoke -c Release --no-build | 0 | 22 verifiche passate, culture it-IT/en-US |
| dotnet build src/LibMat/LibMat.vbproj -c Release | 1 | Restore riuscito; prerequisito Interop.ADOX.dll assente |
| dotnet build src/Orecchia/Orecchia.vbproj -c Release | 1 | Restore riuscito; fallisce la dipendenza LibMat sul prerequisito ADOX |
| dotnet build legacy/Lancio.sln -c Release | 1 | MSB4025: Root element is missing; non raggiunge la compilazione |
| Build individuali di tutti i 14 .vbproj legacy, --no-restore | 1 ciascuno | Nessun progetto legacy compilato; diagnosi sotto |

Gli originali AsmeVip falliscono con MSB4025 sull'ampersand non escapato alla
riga 618. LibMat e Orecchia originali falliscono con MSB3644 per i reference
assembly .NET Framework 3.5 assenti. Gli altri 11 progetti originali falliscono
con MSB4075: il vecchio formato richiede conversione prima della build MSBuild.
Il messaggio della soluzione non identifica da solo un file vuoto: la soluzione
e i manifest sono presenti e non vuoti. Le build individuali forniscono la
diagnosi concreta dei problemi di formato/target; non è stata modificata la
soluzione originale per aggirare il fallimento.

Nessuna UI WinForms, integrazione Office/AutoCAD/ADO o confronto dei risultati
tecnici dell'applicazione completa è stato eseguito. Una build che si ferma al
controllo dei prerequisiti non valida il compilatore o le risorse dei progetti
LibMat/Orecchia. La soluzione moderna verificata include solo FormulaParser.

## Aggiornamento della copia migrata

Sincronizzati sotto src/LibMat e src/Orecchia i nuovi sorgenti e risorse ricevuti,
senza modificare legacy. Le versioni assembly con wildcard sono fissate nella
copia migrata. Non sono stati cambiati algoritmi o istruzioni dei sorgenti.

I nuovi LegacySources.props elencano esattamente Compile/EmbeddedResource dei
manifest originali; per frmChart e frmMater usano il casing reale del file.
Disabilitati i glob automatici per questi item: i file campione ADONET/ADOXSample
e aa.vb, non dichiarati nel progetto originale, rimangono conservati ma non
vengono compilati. Analogamente InserDati_2/3 non vengono aggiunti arbitrariamente
al progetto Orecchia originale, pur rimanendo disponibili nella copia.
Questo non elimina funzioni dichiarate nei progetti: riallinea gli input di build
agli originali ricevuti, conservando i file extra per l'analisi della provenienza.

LibMat SDK ora dichiara Windows Forms, metadata assembly manuali e supporto
delle risorse legacy; non usa i vecchi file di progetto per compilare.
I controlli di prerequisiti non segnalano più MaterialeNew1/clsInitLibMat o
oreMonitor/Var_Funz come assenti: tali sorgenti sono ora disponibili.

## Inventario corrente e blocchi successivi

2.355 file e 14 progetti VB originali. Rimangono:

- LibMat: My Project/Settings.Designer.vb e Settings.settings, più sei file
  dati/documenti/configurazione, elencati in latest-upload-check.md.
- RoutBase: ControlArrays.resx; Lancion: 18 CHM; AsmeVip: 13 contenuti Arch/RTF.
- RoutBase2, RoutBase3, RoutBase4, StubW9 e WinWordControl.dll non caricati.
- Interop COM e compatibility layer VB6 da modernizzare; i componenti ricevuti
  richiedono ancora ADODB/ADOX, Word e altri tipi non risolti nel runtime moderno.
- Migrazione dei restanti progetti, risorse serializzate e dati BinaryFormatter,
  seguita da esecuzione funzionale su Windows con i componenti necessari.

Il report dettagliato e ripetibile resta in inventory/projects.json.
Non serve chiedere un token GitHub: il fetch funziona con l'accesso esistente.
Non è stato tentato il download di DLL non verificate o la disattivazione delle
verifiche delle risorse per ottenere una build verde.
