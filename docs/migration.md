# Migrazione VB.NET verso .NET 10

## Stato corrente dopo l'importazione

Aggiornamento successivo: ricevuti e conservati i manifest originali LibMat e
Orecchia (.NET Framework 3.5). L'inventario corrente conta 2.300 file e 14
progetti VB; le cifre sotto descrivono l'importazione iniziale. I manifest
identificano sorgenti e dipendenze ancora mancanti e un riferimento a
`DLL Extra/WinWordControl.dll`. Dettagli in reconstructed-projects.md.

I manifest LibMat e Orecchia sono stati ricostruiti in `src/` su richiesta,
con copie separate dei file disponibili. Vedere
[progetti ricostruiti e alternative Word](reconstructed-projects.md) per
prerequisiti, sorgenti mancanti e risultati delle build. Questo aggiornamento
non rende complete le cartelle originali né sostituisce WinWordControl.

Il commit remoto `7c5c2e4` ha aggiunto `legacy/` a main. È stato integrato
sulla branch `migration/vb-net10-inventory` senza scrivere su main.
I paragrafi dell'inventario iniziale sotto riportano lo stato precedente
all'importazione; l'inventario aggiornato è in [legacy-inventory.md](legacy-inventory.md).

Sono ora disponibili 2.298 file, 12 progetti VB.NET e 110 risorse .resx.
Restano assenti LibMat, Orecchia e il progetto esterno WinWordControl.
Non è ancora possibile compilare né avviare l'intera applicazione.

### Primo componente migrato: FormulaParser

`src/FormulaParser/` è una copia separata del componente originale con un
progetto SDK-style VB.NET, target `net10.0-windows`, namespace originale e
Option Strict On già presente nel legacy. Non usa Windows Forms e non richiede
COM. Non sono state modificate le istruzioni di `clsFormulaParser.vb`;
il file è identico byte per byte. Encoding Windows-1252 dichiarato nel progetto.

In `AssemblyInfo.vb` soltanto `AssemblyVersion("1.0.*")` è diventato
`AssemblyVersion("1.0.0.0")`: la versione dipendente dal tempo impedisce la
compilazione deterministica moderna. Gli altri attributi restano invariati.
Una rebuild Release ha prodotto gli stessi SHA-256 di entrambe le DLL.
Gli spazi finali dei sorgenti copiati sono conservati per evitare diff inutili;
il controllo whitespace segnala quindi gli stessi spazi del legacy nei nuovi
file VB, senza conseguenze sulla build.
L'SDK è fissato a 10.0.401 in `global.json`. Non sono necessari pacchetti NuGet
per questo primo componente. L'installazione cloud usa `/workspace/dotnet`,
fuori dal checkout; aggiungere tale cartella a PATH nella sessione.

Comandi dalla radice del repository, dopo aver installato l'SDK:

```sh
dotnet restore LancioNET10.slnx
dotnet build LancioNET10.slnx -c Release --no-restore
dotnet run --project tests/FormulaParser.Smoke -c Release --no-build
```

La soluzione moderna include per ora solo FormulaParser e il suo eseguibile
di verifica VB. La build pulita del parser ha tre avvisi BC42353 per percorsi
senza Return nel codice originale; non sono stati nascosti o corretti durante
il porting. Le build incrementali possono non ripeterli.

Sono passati 22 controlli di aritmetica, precedenza, funzioni, costanti e
separatore decimale in it-IT/en-US. I controlli esercitano calc_scan/level0
direttamente, così gli errori arrivano al runner senza il MsgBox del wrapper
legacy evaluate. Non coprono il wrapper, gli input invalidi o una baseline
eseguibile .NET 1.1; non dimostrano l'equivalenza di tutti i calcoli tecnici.

`.vscode/tasks.json` configura build e verifiche di questi componenti.
`.vscode/launch.json` avvia il runner con il debugger coreclr, che richiede
l'estensione Microsoft C# (`ms-dotnettools.csharp`); i sorgenti rimangono VB.
La sessione interattiva del debugger non è stata provata nella macchina cloud.
Il workflow `migrated-components.yml` esegue restore/build/verifiche su Windows:
i comandi sono stati provati localmente su Linux per il parser, ma il workflow
GitHub e il comportamento Windows non sono ancora stati eseguiti.

Il primo componente non include una UI WinForms. Nessuna funzionalità Office,
ActiveX, database, AutoCAD o serializzazione è stata eliminata o sostituita.
Tali funzionalità restano nel legacy in attesa degli adapter e delle dipendenze.

## Inventario iniziale — 6 ottobre 2026

Il checkout iniziale è pulito. La branch di lavoro è
`migration/vb-net10-inventory`, creata dal commit di main
`5343633f98495df9f534dd1bde940e51b8b384c8` senza modificare main.

L'inventario completo dei file versionati iniziali contiene un solo elemento:

| File | Dimensione | Contenuto |
| --- | ---: | --- |
| README.md | 73 byte | Nome del progetto e descrizione del software per recipienti in pressione e scambiatori |

Non sono presenti file non versionati, soluzioni, progetti, sorgenti VB,
risorse, librerie, manifest, lockfile, test, script o istruzioni AGENTS.md nel
checkout. Anche il riferimento remoto
`copilot/modernize-migrate-to-dotnet10` è stato ispezionato senza merge:
contiene soltanto README.md e un commit denominato `Initial plan`.

### Mappa dei progetti e dipendenze

| Elemento | Evidenza disponibile | Stato |
| --- | --- | --- |
| Soluzione VS .NET 2003 | Nessun .sln | Non disponibile |
| Progetti VB.NET | Nessun .vbproj o .vb | Non disponibile |
| Risorse e designer WinForms | Nessun .resx | Non disponibile |
| Dipendenze COM, ActiveX e assembly | Nessun riferimento o binario | Non determinabile |
| Test e dati di riferimento | Assenti | Da acquisire |

L'assenza di riferimenti nel repository non dimostra che il software originale
sia privo di dipendenze obsolete.

## Blocchi attuali

1. Mancano i sorgenti legacy: non è possibile migrare o verificare i calcoli.
2. La macchina corrente è Linux e non dispone del comando dotnet. La UI
   Windows Forms e le integrazioni COM devono essere validate su Windows.
   Un'eventuale cross-build Linux richiederà EnableWindowsTargeting; non
   dimostrerà il funzionamento di UI, ActiveX o automazione Office.
3. Versioni, architettura x86/x64, licenze e componenti installati sul sistema
   originale non sono documentati.

Non è stata eseguita alcuna build o prova funzionale. Non è stato creato un
progetto vuoto per sostituire l'applicazione mancante.

## Strategia a fasi

### 1. Acquisizione e baseline originale

Importare una copia integra del software sotto `legacy/`, conservando
struttura, encoding, risorse e metadati originali. Separare output generati e
stato personale dell'IDE dal codice da conservare. Inventariare ogni progetto,
ProjectReference, Reference, COMReference, componente ActiveX, database,
template Office, configurazione, licenza e requisito di registrazione.
Registrare GUID, versioni, percorsi e bitness; non committare credenziali.

Acquisire casi di calcolo di riferimento con input, output, unità, tolleranze
e versione dell'applicazione originale. Conservare il legacy senza refactoring.

### 2. Prima build riproducibile

Creare i progetti migrati separati sotto `src/`, in VB.NET SDK-style con
TargetFramework `net10.0-windows` e UseWindowsForms true per i progetti UI.
Mantenere inizialmente Option Strict Off dove richiesto; verificare namespace,
startup object, My Project, impostazioni, risorse e comportamento del designer.
Non riscrivere in C# e non modificare algoritmi tecnici durante il porting.

Scegliere e fissare una versione SDK .NET 10 realmente testata in global.json.
Definire restore e build della soluzione effettiva, con dipendenze e toolchain
documentate. Aggiungere VS Code tasks/launch con percorsi reali e supporto di
debug VB verificato; VS Code non sostituisce il designer WinForms di Visual
Studio. Configurare GitHub Actions su Windows per restore, build e test.
Per COM proprietari valutare un runner Windows dedicato con prerequisiti
installati e licenze valide. Non dichiarare tali integrazioni verificate su
un runner privo dei componenti.

### 3. Isolamento e rimozione progressiva delle dipendenze obsolete

| Dipendenza da cercare | Analisi e intervento previsti |
| --- | --- |
| Microsoft.VisualBasic.Compatibility.VB6 | Inventariare API e semantica; sostituire gradualmente mantenendo VB.NET |
| TextBoxArray / PictureBoxArray / MenuItemArray | Collezioni WinForms normali; preservare indici, ordine, eventi, creazione dinamica e disposal |
| stdole | Individuare usi COM di immagini/font e marshalling; preservare i contratti prima di sostituirli |
| ADODB / ADOX | Adapter per connessioni, transazioni, schema e recordset; verificare provider, NULL, cursori e architettura |
| Word / Office Interop / WinWordControl | Adapter per automazione e hosting; verificare versione Office, STA, documenti e rilascio COM |
| AutoCAD | Adapter versionato; verificare API, bitness, installazione e risultati dei disegni |
| ActiveX / AxListViewArray / AxUpDownArray | Inventariare OCX, licenze, wrapper e stato serializzato; preservare gli eventi dietro un layer compatibile |
| BinaryFormatter | In .NET 10 non costituisce una strada supportata per il formato originale; progettare conversione dei dati fidati in un processo legacy isolato e un formato moderno versionato |
| Vecchi .resx | Ispezionare tipi serializzati, riferimenti ad assembly, encoding e stato ActiveX; verificare caricamento, designer e risorse localizzate senza rigenerazione indiscriminata |

Questa tabella è una checklist di indagine, non un inventario di dipendenze
effettivamente riscontrate. Se una sostituzione immediata non è fattibile,
preservare la funzionalità tramite adapter; valutare un processo Windows legacy
isolato quando il componente non può essere caricato nel runtime moderno.
Documentare il protocollo e i requisiti senza nascondere dipendenze irrisolte.

### 4. Verifica funzionale e consolidamento

Confrontare i calcoli con la baseline originale, quindi verificare UI, file,
database, esportazioni Word e AutoCAD e comportamento delle integrazioni.
Distinguere test passati, falliti, saltati e non eseguiti. Attivare Option Strict
On per aree validate, in commit separati dalle modifiche algoritmiche.

## Modifiche di questa branch

- `.gitignore`: esclude bin/, obj/, .vs/, .suo, .user e risultati di test/build;
  conserva visibili risorse e dipendenze legacy da inventariare.
- `.editorconfig`: convenzioni per i nuovi file; non applica conversioni massive
  al codice originale.
- Questo documento registra inventario, limiti e sequenza di migrazione.

Tasks, launch, workflow applicativo e progetti SDK-style restano da configurare
quando i sorgenti saranno disponibili, evitando percorsi inventati e CI che
non compila l'applicazione. Ogni passaggio significativo dovrà aggiungere qui
motivazione, comandi di verifica, risultati e limitazioni, in piccoli commit.

## Verifiche ripetibili

Dal checkout: `git ls-files`, `git status --short` e `git diff --check`.
Per la protezione degli output: `git check-ignore` su percorsi campione di
bin/, obj/, .vs/, .suo e .user. Questi controlli validano soltanto le regole
del repository e la documentazione, non la build o il comportamento tecnico.
