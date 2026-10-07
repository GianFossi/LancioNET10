# Grafic2: controlli e connessione SQL Server

Gli array VB6 sono dizionari di controlli WinForms. Gli indici originali restano
stabili; gli handler statici vengono collegati dopo l'inizializzazione e quelli
dinamici dopo la creazione del clone. Unload rimuove e dispone il controllo.
La navigazione TrattaCar mantiene lo stesso controllo anche nei parametri ByRef.
Il costruttore pubblico di frmFlange mantiene l'inizializzazione dati; l'overload
Friend consente verifiche Windows dei controlli senza il database.

I helper UI usano il DPI effettivo per pixel/twip. Format e' Strings.Format;
GetItemString e' GetItemText; TabLayout riguarda soltanto l'output diagnostico.
Due dichiarazioni Overloads in un Module perdono la parola chiave non consentita,
conservando firme e corpi delle routine.

Il percorso SQL Server di frmDBSelle usa Microsoft.Data.SqlClient 6.1.3. Le query
restano originali. Sul server reale verificare TLS/autenticazione e le differenze
di default del provider, senza disattivare la verifica dei certificati.

[Checkpoint complessivo e verifica Windows ancora necessaria](full-application-restoration.md).
