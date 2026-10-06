# Primo adapter ADO.NET al posto di ADOX/ADODB

## Modifica implementata

La copia migrata LibMat non usa più ADOX/ADODB nei due percorsi applicativi
che li richiedevano. Gli originali sotto legacy restano invariati.
L'adapter VB.NET `Lancio.Data.Access` è SDK-style, net10.0-windows, Option Strict
On, e usa System.Data.OleDb 10.0.0; non richiede Interop.ADOX o ADODB COM.

- AggiornaXLS ora legge SELECT DISTINCT MATERIAL direttamente da Excel tramite
  OleDbConnection/DataReader. Il precedente percorso convertiva un DataSet in
  ADOX.Catalog e un recordset COM in DataTable, senza una conversione valida.
  Eliminato il helper ConnectOutput, il cui unico chiamante era AggiornaXLS.
  Vengono conservati connessione/configurazione Excel, colonna MATERIAL e
  popolamento della combo. Risorse e cursore sono ripristinati anche in errore;
  una query senza righe non tenta di selezionare l'elemento zero.
- frmScheda crea lo schema della tabella materiali da PR1P0 con metadata
  GetSchemaTable e DDL Access. Conserva ordine e nomi delle colonne, tipi
  supportati, dimensioni del testo, precisione/scala decimal, ID COUNTER NOT NULL,
  primary key e indice ID. Il codice esistente di popolamento dei dati non cambia.
  Non copia arbitrariamente default o altre constraints, che neppure il blocco
  ADOX originale copiava. Per i tipi non mappati fallisce prima di creare tabelle;
  non converte silenziosamente tipi sconosciuti in testo o numeri.
- Gli identificatori sono delimitati; nomi vuoti, parentesi quadre e caratteri
  di controllo vengono rifiutati. Nessuna modifica alle formule tecniche.
- Creazione e indice usano una transazione; una tabella esistente viene rifiutata
  e non cancellata. In caso di rollback fallito vengono conservati entrambi gli
  errori. La connessione già aperta dal chiamante non viene chiusa dall'adapter.

Le query SELECT e CREATE TABLE sono ricostruite in un layer dedicato; non è
una conversione di ogni possibile Recordset/Catalog COM in una falsa API uguale.
Il file ADOXSample.vb rimane conservato tra gli extra non compilati: non è un
percorso del progetto originale. Le funzioni ADOX/ADODB del legacy RoutBase
restano da portare, così come gli altri componenti non ancora migrati.

## Verifiche e limiti

- Build Release dell'adapter e della soluzione dei componenti migrati riuscita.
- 22 controlli di pianificazione SQL/schema passati: query Excel, identificatori,
  tipi numerici/testo/data, auto-incremento/chiave ID, dimensioni e precisione,
  rifiuto di schema senza ID, ID errato, duplicati e tipi non supportati.
- 22 controlli FormulaParser ancora passati.
- La build LibMat ora oltrepassa il controllo ADOX precedente e fallisce con
  BC2001 per My Project/Settings.Designer.vb mancante. Il compiler non ha ancora
  validato integralmente i form/callsite e le altre dipendenze LibMat.
- L'ambiente Linux non esegue OleDb/Jet/ACE. Non sono state eseguite query su MDB
  o Excel, DDL, commit/rollback, verifica degli indici o prove WinForms.
  I test di pianificazione non sostituiscono queste verifiche di integrazione.

Comandi dalla radice:

```sh
dotnet build LancioNET10.slnx -c Release
dotnet run --project tests/Access.Smoke -c Release --no-build
dotnet run --project tests/FormulaParser.Smoke -c Release --no-build
dotnet build src/LibMat/LibMat.vbproj -c Release
```

## Requisiti della validazione Windows

OleDb rimane un provider Windows: conservare per ora MDB/XLS e configurare
Jet/ACE con bitness coerente col processo. Questo elimina i wrapper ADOX/ADODB
dal codice migrato descritto, non il provider database. Nessuna richiesta di
credenziali o conversione automatica dei dati è introdotta.

Prima di usare la nuova creazione di tabelle su dati reali, eseguire le prove
su copie dei database originali: confrontare colonne, nullable, tipi, precisione,
scale, primary key/indice, numerazione ID e righe create da frmScheda. Verificare
la transazionalità DDL del provider installato con un errore deliberato fra CREATE
TABLE e CREATE INDEX. Confrontare lettura Excel su file con righe duplicate,
NULL e nessun risultato. Acquisire gli MDB mancanti elencati nell'inventario.
Non è ancora dichiarata l'equivalenza funzionale con l'applicazione originale.
