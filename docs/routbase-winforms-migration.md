# RoutBase1: control array e build eseguibile

## Modifiche

frmAbout, frmCheck, frmInput e frmQuale usano ora Dictionary(Of Integer, T)
con normali Label, Button, CheckBox, RadioButton, TextBox e ComboBox WinForms.
Gli indici originali e l'accesso collection(index) rimangono; GetIndex diventa
una ricerca per identità del sender, senza riutilizzare Tag. Gli eventi dei
controlli iniziali sono collegati dopo l'inizializzazione delle proprietà;
quelli dei controlli dinamici sono collegati subito dopo la creazione.

IndexedControls gestisce esclusivamente ricerca dell'indice e creazione dei
controlli dal modello zero: contenitore, posizione, dimensioni, stile e proprietà
specifiche. Gli handler restano nei form; nessun algoritmo viene trasferito
nell'helper. Gli indici duplicati vengono rifiutati. I nuovi RadioButton iniziano
non selezionati; la selezione resta assegnata dal form. I controlli sono posseduti
e liberati dai contenitori WinForms. ControlArrays.vb originale resta compilato.

frmOpzioni usa una ComboBox per le unità e due ListBox per cartelle/file. Mostra
cartella superiore e sottocartelle; doppio click o uscita dalla lista navigano,
aggiornando il percorso selezionato del motore. Directory e file vengono letti
prima di cambiare lo stato: una cartella inaccessibile mostra un errore e non
sovrascrive il percorso precedente. Questa modifica del browser va verificata
anche con cartelle di rete e unità mappate su Windows.

Utility VB6 eliminate da RoutBase1: Clone per gli array AutoCAD, GetItemText per
le combo, Strings.Format per la formattazione, conversione twips usando il DPI
dello schermo. FixedRecordString conserva padding e troncamento ai punti
FileGet/FilePut esistenti, senza riscrivere i formati binari o gli algoritmi.
Un File.Exists è qualificato per evitare l'ambiguità con il nuovo Path.Exists.
Le formule di interpolazione, geometria e calcolo restano in VB e invariate.

WFO1000 rimane visibile come warning nel solo src/RoutBase: WithEvents genera
proprietà VB le cui annotazioni sui campi non risolvono il controllo del designer.
Non sono disabilitati gli analyzer nel loro insieme. Questa è una scelta
transitoria per form inizializzati manualmente, non una validazione del designer.
Restano numerosi warning legacy e di piattaforma; non si dichiara build senza warning.

## Serializzazione isolata, non modernizzata definitivamente

.NET 10 non implementa più BinaryFormatter. I quattro callsite di RoutBase1
usano ora Lancio.Legacy.Serialization, unico progetto che riferisce il pacchetto
compatibile System.Runtime.Serialization.Formatters 10.0.0. SYSLIB0011 è soppresso
soltanto dentro i due metodi dell'adapter; il resto del codice non lo disabilita.

Il percorso NRBF è disabilitato per impostazione predefinita: per un ambiente di
migrazione con **soli file locali attendibili**, impostare
LANCIO_ENABLE_LEGACY_BINARY_FORMATTER=1 prima dell'esecuzione. Questo abilita un
formatter insicuro, non lo rende sicuro per file di terzi. L'adapter controlla
l'abilitazione prima di leggere/scrivere lo stream e mantiene il formato legacy.
Le funzioni non sono state cancellate, ma richiedono questa configurazione
esplicita. Non viene applicata durante il normale avvio né per leggere file reali
in questo ambiente. La futura applicazione F# dovrà usare un formato moderno
versionato e un importatore separato, senza dipendenza da questo adapter.

## Verifiche

- RoutBase1 e RoutBase3 compilano Release, zero errori.
- LancioNET10.slnx include ora entrambi, il bridge di serializzazione e i nuovi
  runner; build Release riuscita. Il parser e i precedenti adapter restano inclusi.
- Linux: 22 FormulaParser, 32 Access/schema, 22 Word con backend simulato e
  10 record/serializzazione: **86 controlli passati**. I controlli record coprono
  padding, troncamento e FileGet/FilePut ASCII; il round trip NRBF verifica un
  grafo locale nuovo con riferimenti ciclici e il rifiuto senza abilitazione.
  Non sono prove di lettura dei file binari originali .NET Framework.
- WinForms.Smoke compila; esecuzione disponibile nella CI Windows. Controlla
  cloni, indici sparsi, eventi dinamici, costruzione dei quattro form e browser
  cartelle su dati temporanei. Non è stato eseguito sul container Linux.
- Il runner LegacyCalculation.Debug compila Debug con simboli; richiede Windows
  per esecuzione. Chiama direttamente clsTrigon.InterLogar; non copia la formula.
- La build completa LancioNET10.Full.slnx arriva oltre RoutBase, ma resta fallita:
  18 errori LibMat, 33 Wald, 8 VapAcqua (control array VB6), 4 AzioniPersonalizzate
  (System.Configuration.Install rimosso) e 1 Ventil (tipo AutoCAD non risolto).
  Totale 64. Altri errori possono emergere dopo questi; non si dichiara avvio della GUI.

Risultati: inventory/routbase-controls-build.json. Originali in legacy immutati.
