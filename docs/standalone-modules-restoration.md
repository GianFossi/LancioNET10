# Wald, VapAcqua e Ppgas

I controlli VB6 nei form Designer/code-behind sono dizionari WinForms con indici
ed eventi originali. Wald usa i helper DPI per le coordinate. Gli accessi ai form
input usano il tipo effettivo; Ventil usa frmInput esplicito per le risposte.
I nomi Autodesk del codice Ventil corrispondono alla Interop.AutoCAD fornita.

VapAcqua conserva XSteam come dipendenza esterna tramite LegacySteamLibrary.
Non viene approssimata alcuna proprieta' termodinamica: occorre la DLL originale
compatibile indicata in LANCIO_XSTEAM_DLL. La sua assenza genera un errore esplicito.

La serializzazione passa dal bridge con preflight prima dei file. I riferimenti
SDK irrisolvibili e non usati sono rimossi. La build non valida le DLL native
WaldLib/MathVentil/HtriLib/HtriSub/DAO36, ancora mancanti nei file forniti.

[Limiti, dipendenze e avvio Windows](full-application-restoration.md).
