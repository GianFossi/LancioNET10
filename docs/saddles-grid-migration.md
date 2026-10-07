# Selle: migrazione delle griglie

Convertite le 13 griglie del form e quelle create dinamicamente nelle schede
a DataGridView. Liste esplicite di colonne sostituiscono DataGridTableStyle;
DataPropertyName mantiene i campi originali delle DataView. Conservati larghezze,
colori, colonne non modificabili, titoli, dati e routine di calcolo.
LoadGridView e' un controllo moderno con titolo disegnato nell'intestazione.
Blocca l'ordinamento per mantenere gli indici usati dalle routine ingegneristiche.

Gli eventi TextChanged sono collegati all'editor reale tramite
EditingControlShowing, rimuovendo i collegamenti precedenti quando l'editor
viene riutilizzato. Mantenuti i cinque gestori originali. Selezioni nulle
sono ignorate durante il binding; GetCellDisplayRectangle conserva le misure.
Il costruttore pubblico mantiene l'inizializzazione originale. Un overload
Friend(false) permette il test dei controlli senza inizializzare dati/calcoli.

MenuStartup.Smoke verifica costruzione, 13 controlli collegati e ordinamento
disabilitato su una DataView sintetica. Build Linux verificata; test runtime,
modifiche dei carichi e confronto dei risultati richiedono Windows.
