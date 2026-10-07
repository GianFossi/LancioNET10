# RoutBase1 e RoutBase3: migrazione ADO.NET

Le copie sotto src sostituiscono gli ultimi usi ADODB/ADOX dei due progetti
con Lancio.Data.Access. Gli originali legacy e le formule di clsTrigon restano
intatti. Rimossi i riferimenti COM ADODB/ADOX dai due manifest SDK.

DuplicaTableDef legge lo schema della tabella sorgente con OleDb, seleziona le
colonne usando le Caption del DataTable e prepara tutte le istruzioni prima
di modificare il database. Come RoutBase3 originale, la prima colonna diventa
COUNTER (richiede Integer) e le altre rimangono nullable. Gli indici sono
ricostruiti dai metadata reali: nomi, colonne in ordine, direzione, unicità,
primary key e policy NULL supportate. A differenza del vecchio codice, non
si assume che il nome dell'indice coincida con il nome della sua colonna;
sono supportati indici composti. Indici su colonne non selezionate, tipi non
mappati e policy NULL non rappresentabili (IGNORE ANY NULL, valore 4) vengono
rifiutati prima del CREATE, senza omissioni silenziose. La creazione usa una
transazione; un rollback fallito conserva entrambi gli errori. Non si copiano
righe, default, relazioni o chiavi esterne: neppure il percorso originale di
RoutBase3 lo faceva. La creazione non cancella tabelle già esistenti.

TableDelete usa DROP TABLE con identificatore delimitato e conserva la
propagazione delle eccezioni. DuplicaTableDef di RoutBase3 mantiene la finestra
di errore del chiamante. RoutBase1 delega allo stesso adapter: il vecchio
percorso aveva un Catalog non inizializzato e tentava un cast DataTable/ADOX.Table
non valido. La nuova implementazione rende esplicita la duplicazione dello
schema secondo il contratto RoutBase3; questa è una correzione del percorso
precedentemente guasto, da verificare sui database reali prima dell'utilizzo.

ControlArrays.resx è assente anche negli originali disponibili. ControlArrays.vb
contiene classi di collezione di controlli, senza accessi alle risorse; la ricerca
nei sorgenti migrati non trova utilizzatori della risorsa ControlArrays.
Rimossa soltanto la dichiarazione EmbeddedResource inesistente da RoutBase1.
ControlArrays.vb e tutte le risorse dei form rimangono inclusi.

## Risultati

- RoutBase3 Release compila: zero errori, tre warning di piattaforma.
- La build completa oltrepassa ADODB.Connection e ControlArrays.resx; fallisce
  ora con 28 errori RoutBase1 su control array VB6, DriveListBox ed eventi.
  I progetti dipendenti non sono ancora validati integralmente.
- La soluzione dei componenti verificati compila. I runner superano 32 controlli
  SQL/schema, 22 FormulaParser e 22 Word (backend simulato): 76 complessivi.
- Nuovi controlli: schema generico, indici composti ordinati, primary/unique,
  direzione, policy NULL e rifiuto di colonne mancanti/duplicate/non selezionate.

Linux non esegue il provider OleDb Windows. Non sono dichiarate equivalenza
funzionale, transazionalità DDL Jet/ACE o compatibilità UI. Su Windows, con
provider e bitness coerenti, verificare su copie MDB: schema e indici confrontati
con l'originale, ID auto-incremento, errori CREATE INDEX e rollback, cancellazione
della sola tabella richiesta. Nessuna modifica automatica ai database originali.

```sh
dotnet build src/RoutBase3/RoutBase3.vbproj -c Release
dotnet build LancioNET10.Full.slnx -c Release
dotnet run --project tests/Access.Smoke -c Release
```

I report sdk-build-results.json e sdk-conversion.json conservano l'istantanea
precedente della conversione SDK; questo documento registra il check successivo.
