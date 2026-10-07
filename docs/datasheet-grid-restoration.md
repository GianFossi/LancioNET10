# DataSheet: griglia di selezione

DataSheet.Apert costruiva un DataGrid non supportato. Sostituito con
DataGridView, tre colonne esplicite Col1/Col2/Col3 e binding alla stessa dvGrid.
Conservati intestazioni, larghezze, visibilita' e routine dei documenti.
Click ignora intestazioni e riga nuova, ricava la DataRowView selezionata
in modo che ordinare la griglia non selezioni un documento diverso.
Build verificata; interazione Windows da verificare.

Librerie termiche: terAcqua, terPetrol, mnuPPgas, mnuVentilatori hanno chiamate
commentate. WHB invoca LanciaProg(13) ma quel ramo contiene solo chiamate
BabCock commentate. Features=Si non ripristina queste integrazioni.
