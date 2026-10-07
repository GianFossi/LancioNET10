> Aggiornamento 7 ottobre 2026: la soluzione completa di 26 progetti VB compila.
> Per stato attuale, avvio Lancion e funzionalita' ancora sospese, vedere
> [il checkpoint di ripristino](full-application-restoration.md). I risultati precedenti sotto sono storici.

# Correzione dei tre blocchi di progetto

## Intervento

Preparati manifest SDK-style per tutti i 26 progetti VB.NET, con target
net10.0-windows. I 23 manifest mancanti sono stati creati sotto src; i tre
SDK esistenti sono mantenuti, estendendo LibMat e Orecchia con i riferimenti
ai nuovi progetti condivisi. La nuova LancioNET10.Full.slnx contiene tutti
i progetti applicativi VB; LancioNET10.slnx continua a contenere i componenti
già verificati e i loro runner. Usare il nome esplicito della soluzione.

- Formato VS2003: sostituito nella copia migrata da Project Sdk, mantenendo
  namespace, assembly name, opzioni VB, startup dove applicabile, simboli di
  compilazione e liste esplicite dei sorgenti/risorse. Non è richiesto aprire
  i progetti vecchi in Visual Studio per usarne le copie moderne.
- Targeting pack .NET Framework 3.5/4.0: non è più richiesto dai progetti nuovi,
  che usano SDK .NET 10 e Windows targeting. Non sono stati installati pack
  legacy né dichiarata la build degli originali .NET Framework su Linux.
- XML AsmeVip: il nuovo manifest scrive `Arch/S&amp;T.jpg` correttamente come
  attributo XML escapato; il parser restituisce il percorso reale `Arch/S&T.jpg`.
  L'originale resta intatto come richiesto, con il difetto storico documentato.

Il comando di build per il porting completo è:

```sh
dotnet build LancioNET10.Full.slnx -c Release
```

## Conservazione e dipendenze

La copia non sovrascrive sorgenti già adattati, compresi gli interventi ADO.NET
e Word. I nuovi sorgenti e le risorse sono copiati dagli originali; soltanto le
wildcard di versione AssemblyInfo sono fissate nella copia per supportare
compilazione deterministica. Non sono stati riscritti algoritmi in C# o VB.
Gli output bin/obj e i file IDE restano fuori dai nuovi commit.

Gli SDK usano ProjectReference per le dipendenze VB note. Orecchia non richiede
più un RoutBase1.dll manuale in local/dependencies: ora riferisce il progetto.
Per gli interop disponibili sono indicati gli assembly sotto legacy/DLL Extra;
questo ne consente l'uso come riferimenti di compilazione, senza affermare che
siano compatibili funzionalmente col nuovo runtime. Non viene introdotto il
progetto C# WinWordControl nella soluzione nuova: il suo riferimento inutilizzato
è sostituito dall'integrazione Word già preparata nei chiamanti.

Non sono state create false implementazioni per Microsoft.VisualBasic.Compatibility,
ADODB, stdole, XSteam o System.Configuration.Install. Le dipendenze mancanti o
non supportate restano segnalate. La conversione dei manifest non sostituisce
la migrazione dei loro usi nel codice. XSteam, riferito da VapAcqua, non è stato
trovato tra i progetti disponibili.

## Verifica eseguita

- Validati i 26 manifest: Project Sdk, target net10.0-windows, assenza di
  TargetFrameworkVersion e dell'import esplicito dei vecchi target VB.
- Verificato in AsmeVip sia l'XML escapato sia il percorso decodificato corretto.
- Restore della soluzione completa riuscito; tentata la build Release.
- Non compaiono più MSB4075, MSB3644 o MSB4025 nelle build SDK eseguite.
- La build completa fallisce con due BC30002 ADODB.Connection in RoutBase3
  e MSB3552 ControlArrays.resx mancante in RoutBase1. I nodi che dipendono
  da questi progetti non hanno ancora raggiunto la compilazione dei sorgenti;
  altri errori possono emergere dopo la correzione delle dipendenze.
- Build individuali senza ricompilare i riferimenti: FormulaParser, RoutBase4,
  StubW2000 e StubW9 passano. Gli altri progetti falliscono sulle dipendenze non
  compilate (BC2017), oppure sui due blocchi sopra. Questo non dimostra la
  compilabilità completa di AsmeVip o degli eseguibili.
- La soluzione dei componenti verificati continua a compilare e i tre runner
  passano 66 controlli. Word/Access reali e UI restano da verificare su Windows.

Report metadata in inventory/sdk-conversion.json e risultati per progetto in
inventory/sdk-build-results.json. I molti warning degli assembly legacy non
sono stati nascosti; comprendono API obsolete e annotazioni di piattaforma
ancora da aggiornare. Compilare un wrapper Office non valida il funzionamento
di Word né il porting del vecchio Stub.

## Riproduzione della conversione

```sh
python tools/inventory_legacy.py
python tools/convert_legacy_projects.py
```

Lo script preserva gli SDK e i sorgenti migrati esistenti. La prima esecuzione
prepara gli SDK mancanti; le successive collegano le dipendenze note senza
sovrascrivere il lavoro manuale. Non è un sincronizzatore automatico delle
revisioni legacy: ulteriori variazioni di sorgenti/manifest vanno confrontate
prima di applicarle alle copie migrate. Eventuali file dati sensibili devono
seguire le regole del repository, senza valori segreti nei manifest generati.
