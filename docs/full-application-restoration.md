# Ripristino dell'applicazione VB.NET completa

La destinazione e' Visual Studio 2026, .NET 10 e Windows Forms. I sorgenti originali
in `legacy/` restano separati; le modifiche riguardano soltanto `src/`.
Il progetto principale e' `src/Lancion/Lancion.vbproj` (assembly `Lancio`).

## Modifiche di compatibilita'

- LibMat, Grafic2, DataShDll e Lancion: gli array VB6 di controlli e menu diventano
  dizionari WinForms, con gli stessi indici. Gli eventi sono collegati esplicitamente
  dopo l'inizializzazione; i controlli caricati dinamicamente ricevono gli stessi
  handler. Lo scaricamento rimuove e dispone il controllo.
- Grafic2/DataShDll: conversioni grafiche pixel/twip con DPI dello schermo;
  formattazione VB tramite `Strings.Format`; testo delle liste tramite `GetItemText`.
  L'output diagnostico `TabLayout` usa tabulazioni, senza intervenire nei calcoli.
- Ricerca tiranti: i chiamanti non corrispondevano alla versione di LibMat fornita.
  Tiranti cerca `Dnom` dopo avere assegnato Dnom; AsmeVip cerca `Diam` dopo avere
  assegnato Diam. Entrambi usano la ricerca esistente `clsTira.Cerca(cosa)`.
- StubW2000 riacquista SuperStampa copiando l'implementazione gia' presente in
  StubW9. RoutBase accetta anche clsSW9 per Immatricolazione, usando lo stesso corpo.
- La serializzazione dei documenti rimane nel compatibility layer
  `Lancio.Legacy.Serialization`, disattivato salvo opt-in esplicito
  `LANCIO_ENABLE_LEGACY_BINARY_FORMATTER=1`. E' un ponte temporaneo **insicuro**:
  usare solo file propri fidati, mai file ricevuti da terzi. Non e' un formato moderno.
- Il percorso SQL Server di Grafic2 usa Microsoft.Data.SqlClient 6.1.3, senza
  modificare le query. Verificare sul server reale autenticazione e TLS: il provider
  moderno puo' richiedere certificati corretti; non disattivare la verifica TLS.
- WFO1000 resta visibile come warning nei form migrati: l'inizializzazione manuale
  dei vecchi WithEvents non e' ancora una dichiarazione di compatibilita' con il
  designer moderno. Il build non prova il funzionamento del designer.
- L'attributo di piattaforma Windows, normalmente generato dall'SDK, e' fornito
  esplicitamente per i progetti che conservano il proprio AssemblyInfo originale.
  Nessuna disattivazione generale degli analizzatori.

## Dipendenze native e configurazione Windows

Le DLL originali AsmeLib.dll, MathAV.dll e **Dforrt.dll sono presenti** in
`legacy/AsmeVip.NET/Dll/`; sono tutte PE32 x86. Lancion usa `win-x86`, richiede
il **.NET 10 Desktop Runtime x86**, e copia queste tre DLL accanto all'eseguibile.
Le importazioni di Dforrt sono MSVCRT.dll/KERNEL32.dll. La disponibilita' dei file
non prova la correttezza del marshalling delle strutture: verificarlo con casi
originali prima di usare i risultati ingegneristici.

`LANCIO_INI` permette di indicare un INI locale completo; se non e' impostata resta
la ricerca storica nella directory di sistema. Un percorso impostato inesistente
produce un errore esplicito. Usare una **copia** di `legacy/Lancio.NET/LancioNET.ini`,
adattando Percorsi/DiscoBase, BaseDir, WorkDir, ArchDir e DatiDir al proprio PC.
Conservare l'originale. L'applicazione legge e aggiorna alcune impostazioni nell'INI.
Le cartelle Arch contengono tabelle, database e modelli distribuiti tra i moduli:
non creare un archivio vuoto e non sovrascrivere file omonimi senza verificarli.

Il controllo di licenza originale resta presente. Il programma puo' fermarsi se
la configurazione o i componenti della propria installazione originale mancano.
Le integrazioni Access/Office/AutoCAD richiedono i prodotti/provider Windows
corrispondenti; per Access verificare la disponibilita' del provider a **32 bit**.

## Due incompatibilita' di versione da verificare

1. `Materi~1.vb` usa `clsTrigon.kWATT`, assente dai RoutBase forniti. La conversione
   di conducibilita' termica richiede `LANCIO_LEGACY_KWATT` positivo, finito e con
   punto decimale, **solo dopo aver verificato fattore e unita' originali**. Non
   esiste un valore predefinito. Il resto di LibMat non richiede questa variabile.
2. DataShDll attende `clsBWG.UniMis`, assente nella LibMat fornita. Il form originale
   BWG confronta uno spessore in mm ma assegna un valore della tabella in pollici.
   La selezione BWG dal datasheet e' isolata con un errore esplicito finche' il
   contratto delle unita' non viene verificato; non restituisce uno spessore ambiguo.
   `BWG_Renamed` e' ricondotto al campo esistente `BWG`. Il form e le tabelle non
   sono stati eliminati e le formule non sono state sostituite.

## Compilazione e debugger sul PC

Aprire **LancioNET10.App.slnx** (Lancion e le sue 20 dipendenze (21 progetti)), ripristinare
NuGet e impostare **Lancion** come progetto di avvio, configurazione Debug.
La compilazione dell'applicazione VB non richiede Python; il piccolo harness
AsmeCalculation.Debug usa ancora Python per estrarre i corpi originali.

Il risultato di una compilazione cloud Linux prova la compilazione incrociata
Windows, non l'avvio della GUI o il funzionamento di Office e delle DLL Fortran.
I test Windows di costruzione dei form devono essere eseguiti su Windows.

## Moduli standalone e contratti ancora incompleti

La soluzione **LancioNET10.Full.slnx** include tutti i 26 progetti VB convertiti.
Anche Wald, VapAcqua, Ppgas, BreLock e Surrisc usano collezioni WinForms; nei
form divisi tra Designer/code-behind i collegamenti agli eventi sono conservati.
Le conversioni VB6 Caption/ListIndex diventano Text/SelectedIndex dove pertinenti.
I form della raccolta InputForms conservano l'accesso VB tramite il tipo effettivo
(CObj), perche' la raccolta contiene frmInput, frmQuale e frmCheck. I vecchi
nomi Autodesk sono ricondotti ai tipi della Interop.AutoCAD effettivamente fornita.

La build completa comprende questi confini espliciti di compatibilita':

- **VapAcqua/XSteam**: la DLL non e' fornita. `LANCIO_XSTEAM_DLL` puo' indicare
  la libreria originale verificata; l'adapter delega le chiamate, senza implementare
  proprieta' del vapore alternative. Senza DLL, la funzione segnala l'assenza.
  Caricamento e compatibilita' reale della DLL devono ancora essere verificati.
- **HTRI/BreLock, licenze**: manca Infralution.Licensing. Indicare la DLL della
  propria installazione tramite `LANCIO_HTRI_LICENSE_DLL` o
  `LANCIO_BRELOCK_LICENSE_DLL`. L'adapter conserva GetLicense e il dialogo originale;
  se la verifica manca o fallisce, non autorizza i calcoli. Non fornisce chiavi e non
  elimina il controllo di licenza.
- **HTRI, PRV e salvataggi**: la RoutBase fornita manca di DatBase.Open/Close,
  DatBase a cinque argomenti, clsComm.Indirizzo e diversi overload di salvataggio.
  `LegacyEstimateDatabase` e `LegacyRoutBaseContract` isolano questi percorsi.
  Non viene scelto un valore arbitrario per ilsi, ne' un nuovo layout dei file.
  Il percorso non supportato fallisce esplicitamente prima del salvataggio.
- **HTRI/BreLock, rapporti**: Testata(NumeraPagine) e clsProblem.pagtot non sono
  forniti. `LegacyReportCompatibility` sospende questi rapporti con un errore
  esplicito. I corpi delle routine che li compongono e i calcoli restano disponibili.
- **Surrisc, tracciatura**: manca Traccia.Scrivi(ByRef File), che dovrebbe restituire
  il nome del file da rileggere. `LegacyTracciaExport` lo segnala senza inventare
  un file di output. StubW2000.sLogo viene ripreso dalla versione StubW9 presente.
- **LancioHTRI**: Standard(Assembly) non esiste nella RoutBase fornita. L'avvio
  richiede LANCIO_INI esplicito e usa la routine Standard() corrente; il launcher
  rimane separato da Lancion ed esegue su x86, con thread STA.
- **AzioniPersonalizzate**: System.Configuration.Install non esiste in .NET 10.
  Installer1 conserva le azioni Install/Commit come metodi espliciti di Component,
  con il contesto LegacyInstallerContext. Questo **non ripristina** il caricamento
  tramite InstallUtil o le vecchie custom action MSI: il nuovo packaging deve
  invocare/adattare le azioni e verificare i permessi. Nessuna installazione o
  modifica dell'INI di sistema viene eseguita dalla build o dai test cloud.

Questi adapter consentono la compilazione dei moduli senza confondere una
mancanza di versione con un algoritmo nuovo. **Build completa non significa
funzionalita' complete verificate**: recuperare i contratti originali o definire
la migrazione con casi di confronto prima di usare i percorsi sospesi.

## Avvio da Visual Studio 2026

1. Git > Pull sulla branch `migration/vb-net10-inventory`.
2. File > Apri > Progetto/Soluzione: scegliere `LancioNET10.App.slnx`.
3. In Esplora soluzioni, clic destro su **Lancion** > Imposta come progetto di avvio.
4. Selezionare **Debug**, quindi Compilazione > Ricompila soluzione.
5. Installare il .NET 10 Desktop Runtime **x86** sul PC, se assente.
6. Preparare una copia INI con percorsi/archivi della propria installazione. Se
   manca l'INI storico, Lancion mostra un dialogo per scegliere questa copia.
   In alternativa, impostare LANCIO_INI prima di aprire Visual Studio.
   La scelta nel dialogo vale solo per il processo e non modifica variabili di sistema.
7. Mettere un breakpoint in `src/Lancion/Lancio4.vb`, all'inizio di Main, e premere F5.
   Il breakpoint precede inizializzazione e licenza; F10 segue i controlli di avvio.

Per avviare da PowerShell, senza Python:

```powershell
.\tools\run-lancion.ps1 -IniPath "C:\Percorso\LancioNET.ini"
```

Il launcher e' predisposto per Windows; non e' eseguito nel cloud Linux.
Non abilita automaticamente la serializzazione legacy. Le cartelle e gli archivi
richiesti dall'INI, la licenza e le integrazioni devono essere presenti sul PC.
La configurazione VS Code "Lancion complete VB GUI (Windows x86)" chiede il
percorso INI, compila App.slnx e avvia l'eseguibile a 32 bit.

## Serializzazione: verificare il consenso prima di aprire file

Le 50 routine che costruiscono LegacyBinarySerializer verificano EnsureEnabled
**prima** di aprire stream o file. Senza opt-in, una scrittura/licenza non crea un
file vuoto e non tronca un documento. La licenza Lancion usa un file dati con
estensione HELICG.EXE; non e' un eseguibile da lanciare. Il formato originale
richiede il bridge anche durante questo controllo: in assenza di opt-in Lancion
mostra il motivo e termina, senza disattivare la licenza.

Per il debugger Visual Studio, solo con i propri file originali fidati, impostare
anche LANCIO_ENABLE_LEGACY_BINARY_FORMATTER=1 nell'ambiente ereditato dall'IDE.
Il launcher PowerShell offre la scelta esplicita:

```powershell
.\tools\run-lancion.ps1 -IniPath "C:\Percorso\LancioNET.ini" -EnableTrustedLegacySerialization
```

Il flag vale solo per il processo avviato. La futura versione F# deve usare un
formato nuovo; il bridge non rende sicuro BinaryFormatter.

Per HTRI/Ventil/Wald risultano ancora assenti le DLL native WaldLib, MathVentil,
HtriLib, HtriSub e DAO36; recuperare le versioni della propria installazione o
migrare il relativo motore con casi di confronto. FormatFORTRAN.dll e Dforrt.dll
sono presenti, ma questo non sostituisce le librerie di calcolo mancanti.
