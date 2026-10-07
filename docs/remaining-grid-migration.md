# Completamento DataGrid, Tiranti e Word (2026-10-07)

## Dieci controlli nelle sette finestre

Convertiti tutti i costruttori DataGrid residui in frmScheda, frmNote,
frmNonTrovato, frmDati, frmChart, frmGridn e frmProto. Le colonne statiche
mantengono mapping, formati, intestazioni, larghezze e sola lettura. Le colonne
create in frmScheda usano collezioni moderne. I layout DataGridTableStyle
vengono eliminati, collegando le proprieta' direttamente alla griglia.
frmGridn conserva il binding dinamico e le formule geometriche originali.

LegacyGridView deriva da DataGridView e isola il piccolo contratto di coordinate
riga/colonna, valore delle celle, misure e scorrimento usato dal codice originale.
GridPosition sostituisce DataGridCell. LegacyTextColumn deriva dal controllo
moderno e converte larghezza zero in Visible=False (DataGridView non ammette
larghezza zero). I nomi legacy delle proprieta' sono solo alias delle API pubbliche:
nessuna dipendenza da DataGrid/System.Windows.Forms.DataGridTextBoxColumn.
L'ordinamento dell'interfaccia e' disabilitato per preservare l'indicizzazione
usata dalle formule e dai record originali; i sort delle DataView rimangono.

GridWrap/MultiLineColumn non legge piu' get_DataGridRows tramite reflection.
Usa WrapMode e AutoSizeRowsMode per il testo multilinea, mantenendo sola lettura.
Le selezioni assenti durante il binding non avviano elaborazioni. frmGridn
esegue EndEdit e EndCurrentEdit prima di leggere i valori con OK. Le formule
nelle routine del cambio cella e nei moduli ingegneristici non sono riscritte.

Per la costruzione dei form che chiamavano dati/calcoli dal costruttore,
un overload Friend(False) permette verifiche senza l'ambiente applicativo.
Il costruttore pubblico mantiene il comportamento originale con True.

## Tiranti

ToolBar e ToolBarButton diventano ToolStrip e ToolStripButton, con le cinque
azioni originali, ImageList, indici immagini e abilitazione della stampa.
ItemClicked sostituisce ButtonClick. Il tag Esci e il relativo case sono ora
coerenti (il vecchio case era esci in un progetto con confronto binario).

## Word

SuperStampa verifica l'oggetto restituito da GetObject prima di usarlo. Se nullo,
attiva Word.Application tramite COM; un errore di attivazione viene mostrato
con la causa originale e cursore ripristinato. Microsoft Word desktop rimane
necessario; nessuna modifica al contenuto dei rapporti. Vedere word-startup-null.md.

## Evidenza e limiti

- tools/audit_datagrids.py: zero costruttori DataGrid e zero righe di API obsolete
  nei sorgenti migrati (commenti e bin/obj esclusi).
- Build LancioNET10.App e GridMigration.Smoke: zero errori sul cloud Linux.
- GridMigration.Smoke prepara verifiche Windows di costruzione dei sette form,
  toolbar Tiranti, binding DataView, coordinate, editing/commit numerico,
  colonne nascoste, formato numerico e testo multilinea. Aggiunto alla CI.
- Test Windows, GUI reale, stampa Office e confronto dei casi ingegneristici
  non eseguiti nel cloud Linux. La compilazione non prova equivalenza funzionale.
- Archivi e DLL native mancanti sono prerequisiti separati.
