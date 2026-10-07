# Griglia Materiali .NET 10

Il costruttore DataGrid non e' supportato nel runtime moderno. frmMater usa
ora DataGridView per il listino prezzi: sei colonne esplicite con gli stessi
campi, intestazioni, larghezze, formati numerici/data e sola lettura di Mat.
Il binding conserva la DataView dvprezzi e le routine originali di generazione.
La larghezza della descrizione si adatta con GetCellDisplayRectangle e Columns.
Nessuna modifica a query, prezzi, formule o archivi. Risorse originali conservate.

WinForms.Smoke costruisce frmMater senza Show/Load e controlla mapping e formati.
Build verificata su Linux; test Windows e modifica reale dei prezzi non eseguiti
qui. Altri form contengono ancora DataGrid e richiedono una migrazione separata
basata sui rispettivi eventi e binding; questa modifica riguarda frmMater.
