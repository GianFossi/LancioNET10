# Progetti ricostruiti e alternativa a WinWordControl

## LibMat e Orecchia

Creati `src/LibMat/LibMat.vbproj` e `src/Orecchia/Orecchia.vbproj` in VB.NET,
SDK-style, target net10.0-windows e Option Strict Off. I file disponibili sono
copiati dalle rispettive cartelle legacy; gli originali non vengono modificati.
Orecchia usa Windows Forms e include esplicitamente le tre risorse .resX.
L'assembly version della copia Orecchia è fissata a 1.1.0.0 invece di 1.1.*,
come per FormulaParser, per evitare versioni dipendenti dal tempo.

I manifest originali non sono disponibili: namespace, nomi assembly e riferimenti
sono ricostruiti dai consumatori e dai sorgenti, non confermati dall'originale.
Questi due progetti non sono ancora inclusi nella soluzione dei componenti
verificati e non sono pronti per l'uso applicativo.

- LibMat contiene soltanto ADONET.vb, ADOXSample.vb e il dataset aa.vb.
  Non definisce MaterialeNew1 o clsInitLibMat, richiesti da Orecchia e dal resto
  dell'applicazione. Non inventare implementazioni di calcolo per colmare il vuoto.
- Orecchia contiene i tre form e Calc_Orecchia, ma non le definizioni del modulo
  Orecchia e clsMonitor usate da quei file. Cerca anche definizioni di Problem,
  Matdim e costanti nella copia originale prima di ricostruire il codice.
- ADOXSample conserva il proprio riferimento ADOX. Fornire un wrapper verificato
  in `local/interop/Interop.ADOX.dll` o impostare LegacyInteropDirectory con
  `-p:LegacyInteropDirectory=...`; non scaricare DLL da siti non verificati.
- Orecchia richiede RoutBase1 migrato in `local/dependencies/RoutBase1.dll` oppure
  MigrationDependencyDirectory. Il riferimento assembly è provvisorio: sarà
  sostituito da ProjectReference quando RoutBase1 sarà migrato. Non basta usare
  il vecchio binario .NET 1.1 per dichiarare compatibilità con .NET 10.
- I controlli preliminari nei progetti segnalano i prerequisiti assenti. Anche
  soddisfandoli, mancano sorgenti e resta da verificare la compatibilità delle
  risorse, dei form e degli altri simboli; nessuna build completa è dichiarata.

Comandi dalla radice, con SDK 10.0.401:

```sh
dotnet build src/LibMat/LibMat.vbproj
dotnet build src/Orecchia/Orecchia.vbproj
```

Verifica nella macchina cloud: restore riuscito per entrambi i manifest;
entrambe le build falliscono sul prerequisito Interop.ADOX di LibMat.
Orecchia non raggiunge la compilazione perché dipende da LibMat: il controllo
RoutBase1 e la compatibilità dei suoi sorgenti restano da eseguire. Verificati
XML dei manifest e identità byte per byte delle copie, eccetto la versione
assembly documentata. Nessun file sotto legacy è stato modificato.

## Alternative a WinWordControl

WinWordControl era un componente di hosting Word dentro il form. I chiamanti
usano PreActivate, DoveTemplate, LoadDocument, RestoreNormal, CloseControl,
document e wd, oltre alle proprietà ereditate dei controlli WinForms.
Sostituirlo con un semplice TextBox o RichTextBox non conserva automazione Word,
template e stampa.

### Prima scelta: Word in finestra esterna

Il legacy contiene già questo percorso in RoutBase.NET/Inizio.vb, SuperStampa:
quando il controllo è assente o disabilitato, usa Word.Application e StubW2000.
frmASME.vb salva la preferenza WordEmbedded sotto Preferenze AsmeVip;
OptWordIn sceglie il percorso. Questa è la base per un adapter VB.NET con
automazione Office su Windows, senza riscrivere la generazione dei rapporti.

Occorre spostare i tipi Word/Office e l'apertura dei documenti dietro un contratto
di sessione documento e adattare i chiamanti nella copia migrata. Impostare
OptWordIn a False da solo non elimina i riferimenti di compilazione al tipo
WinWordControl. Word deve essere installato e disponibile nella sessione desktop;
validare template .dot, SaveAs, stampa, bitness, thread STA e rilascio COM.
La finestra esterna preserva la modifica dei documenti ma cambia il loro hosting:
non va dichiarata equivalente alla funzione embedded.

### Funzione embedded da conservare

Se l'hosting dentro il form è necessario, mantenere un backend separato da
implementare e verificare: recupero del componente originale, controllo Office
supportato con licenza appropriata, oppure processo legacy Windows isolato.
Valutare compatibilità di Office, proprietà delle finestre, focus, ciclo di vita,
stampa e licenze prima di scegliere. Non implementare CloseControl/RestoreNormal
come no-op solo per ottenere una build verde.

### Rapporti senza Office installato

Open XML può produrre documenti .docx ma non esegue Word, non stampa e non ospita
l'editor. È un possibile backend futuro di esportazione dopo la conversione
controllata dei template .doc/.dot, non una sostituzione immediata delle funzioni.

Nessuna funzionalità Word è stata cancellata; questa fase ricostruisce i manifest
e documenta un percorso di sostituzione. Il backend Office e l'hosting embedded
non sono ancora implementati né verificati.
