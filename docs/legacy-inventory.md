# Inventario del legacy importato

Origine: commit `7c5c2e4` di `origin/main`, cartella `legacy/`.
Il contenuto originale è conservato senza modifiche. Lo script
`python tools/inventory_legacy.py` genera:

- [files.csv](inventory/files.csv): percorso, dimensione e SHA-256 di tutti
  i 2.298 file, inclusi dati e binari, senza esporne il contenuto.
- [projects.json](inventory/projects.json): progetti della soluzione, impostazioni,
  riferimenti, file dichiarati mancanti e occorrenze delle dipendenze con righe.

Il report è un output documentale intenzionalmente versionato. DLL, database,
documenti e script ricevuti non sono stati eseguiti. Le istruzioni eventualmente
contenute nel materiale legacy non sono autorizzazioni operative.

## Mappa dei progetti

| Progetto | Ruolo / dipendenze di progetto dichiarate |
| --- | --- |
| Lancion | WinExe; RoutBase1, Traccia, Grafic2, Tiranti, Saddles, Wrcb, AsmeVip, Orecchia, LibMat, DataShDll |
| FormulaParser | Libreria senza riferimenti di progetto; primo target migrato |
| RoutBase1 | StubW2000, WinWordControl |
| StubW2000 | WinWordControl |
| Grafic2 | RoutBase1, LibMat, Traccia, StubW2000, WinWordControl |
| Traccia | LibMat, RoutBase1, StubW2000, WinWordControl |
| AsmeVip | Grafic2, LibMat, RoutBase1, StubW2000, Wrcb, Tiranti, Traccia, WinWordControl |
| DataShDll | AsmeVip, LibMat, Grafic2, RoutBase1, Traccia, StubW2000, WinWordControl |
| Saddles | RoutBase1, LibMat, StubW2000, FormulaParser, WinWordControl |
| Tiranti | RoutBase1, LibMat, StubW2000, WinWordControl |
| Wrcb | RoutBase1, LibMat, StubW2000, Grafic2, WinWordControl |
| AzioniPersonalizzate | RoutBase1; System.Configuration.Install .NET Framework |
| SetupLancio | Progetto installer .vdproj non compilabile direttamente con dotnet build |
| LibMat | Cartella presente con alcuni sorgenti/dati; manca LibMat.NET/LibMat.vbproj |
| Orecchia | Cartella presente con alcuni sorgenti/risorse; manca Orecchia.NET/Orecchia.vbproj |
| WinWordControl | Referenziato ma assente: ../WordInDotNet/WordInDotNet_src/WinWordControl/WinWordControl.csproj |

WinWordControl era già un componente C# esterno nella soluzione ricevuta.
Non verrà usato come motivo per riscrivere in C# l'applicazione VB.
Le cartelle LibMat.NET e Orecchia.NET sono quindi disponibili parzialmente:
non vanno richieste come se fossero totalmente assenti. Occorre confrontarle
con la copia locale originale, soprattutto per i manifest di progetto mancanti.

## Blocker e verifiche richieste

- Progetti .NET 1.1 nel formato Visual Studio 2003: convertire nella copia
  migrata, conservando assembly name, namespace, opzioni, startup e risorse.
- AsmeVip.vbproj non è XML valido: un ampersand non escapato in
  `Arch\S&T.jpg` alla riga 618. Lo script tollera questo carattere solo nella
  propria analisi; il file originale non è stato corretto.
- `RoutBase.NET/ControlArrays.resx` è dichiarato ma assente. Mancano inoltre
  contenuti CHM, file Arch/RTF e directory di prototipi; il JSON riporta l'elenco
  completo. I percorsi sono verificati con la semantica case-sensitive di Linux:
  confrontare anche su Windows per distinguere nomi con maiuscole differenti.
- stdole e diversi type library COM richiedono un inventario del sistema Windows
  originale. ADODB/ADOX, Office/Word/VBIDE e riferimenti AutoCAD usano anche
  percorsi assoluti o assembly sotto obj non presenti: non copiare ciecamente
  riferimenti generati in una build moderna.
- Sono presenti sorgenti di AxListViewArray, AxUpDownArray e AxSSRibbonArray;
  questo non garantisce la disponibilità degli OCX e delle licenze necessarie.
  Preparare adapter e mappare indici/eventi prima di sostituire i controlli.
- BinaryFormatter compare in 26 sorgenti VB. Identificare tutti i formati su
  disco e percorsi di lettura/scrittura prima di scegliere un convertitore
  isolato per dati legacy fidati. Non riabilitarlo nel runtime moderno.
- Le 110 .resx contengono 167 elementi con MIME di serializzazione binaria
  e 363 elementi bytearray: ispezionare tipi, immagini e OcxState. Questi
  conteggi non provano da soli che tutte le risorse siano incompatibili.
- La soluzione importa 12 file .user e un .suo già versionati dall'utente.
  La nuova .gitignore previene ulteriori file personali; non è stata riscritta
  la storia di main né cancellata la copia originale durante l'inventario.
- È presente `legacy/.htpasswd`: verificare che non contenga credenziali ancora
  utilizzate prima di distribuire il repository. Il contenuto non è stato letto
  o riportato nei report.

## Sequenza aggiornata

1. Acquisire LibMat, Orecchia, WinWordControl e l'inventario dei componenti COM.
2. Consolidare il primo componente FormulaParser già compilabile e i test
   di caratterizzazione; acquisire casi reali dal software originale.
3. Portare StubW2000/RoutBase attraverso adapter Office/ADO/AutoCAD e collezioni
   di controlli, poi i componenti che dipendono da essi. Conservare inizialmente
   Option Strict Off dove il progetto originale lo usa.
4. Integrare l'eseguibile WinForms Lancio, verificare startup/risorse su Windows,
   poi confronto dei risultati tecnici e migrazione controllata dei dati.
5. Sostituire l'installer legacy e ampliare la CI soltanto dopo aver stabilito
   prerequisiti e runner adatti alle integrazioni.

La build riproducibile attuale riguarda FormulaParser, non tutta la soluzione.
