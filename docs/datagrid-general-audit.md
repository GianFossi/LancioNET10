> Aggiornamento 2026-10-07: tutti i dieci costruttori elencati sotto sono stati
> migrati. L'inventario corrente riporta zero costruttori DataGrid obsoleti.
> Vedere [remaining-grid-migration.md](remaining-grid-migration.md) per evidenza
> e limiti. Il seguito conserva i risultati del controllo prima della correzione.

# Controllo generalizzato DataGrid (2026-10-07)

Controllati tutti i sorgenti VB di src, escludendo bin/obj e commenti.
Inventario riproducibile: `python tools/audit_datagrids.py` (nessuna modifica).
I costruttori DataGrid compilano ma generano PlatformNotSupportedException
su .NET 10: build riuscita non equivale a finestra utilizzabile.

## Blocchi residui

| File | Costruttori DataGrid | Righe |
| --- | ---: | --- |
| src/DataShDll/frmProto.vb | 1 | 59 |
| src/LibMat/frmChart.vb | 2 | 95, 108 |
| src/LibMat/frmDati.vb | 1 | 90 |
| src/LibMat/frmNonTrovato.vb | 1 | 54 |
| src/LibMat/frmNote.vb | 2 | 55, 63 |
| src/LibMat/frmScheda.vb | 2 | 137, 138 |
| src/Traccia/frmGridn.vb | 1 | 56 |

Totale: 10 costruttori in 7 finestre, distribuite in LibMat, Traccia e DataSheet.
Queste finestre non sono dichiarate funzionanti e richiedono migrazione.

## Ulteriori rischi verificati

- LibMat/GridWrap.vb: MultiLineColumn eredita DataGridTextBoxColumn e legge
  get_DataGridRows via reflection. Occorre riscrivere il rendering/altezza righe
  con le API pubbliche DataGridView, conservando testo multilinea e sola lettura.
- LibMat/frmScheda: stili dinamici e coordinate GetCellBounds usate per disegnare.
  Verificare grafici e corrispondenza con le righe dopo la migrazione.
- Traccia/frmGridn: cambio cella esegue conversioni geometriche usando VecchiaCella.
  Conservare tempistica di commit dell'editor e le formule originali.
- DataSheet/frmProto: il costruttore obsoleto blocca il form anche se molti
  accessi della vecchia griglia ActiveX sono commentati.

## Griglie convertite

Materiali (frmMater), selezione DataSheet (apert4), Selle (frmSaddles e Saddl01)
e la griglia DataGridView gia' presente in Wald. Verificati staticamente
binding, selezione e handler nei percorsi modificati. Questo non equivale
a validazione funzionale completa su Windows.
Selle: eventi dell'editor reale preservati, ordinamento disabilitato per non
alterare l'indicizzazione dei carichi, titoli e mapping conservati.
MenuStartup.Smoke include costruzione delle 13 griglie e binding sintetico.

La migrazione restante va effettuata per form, con controlli Windows di binding,
selezione, modifica/commit dei valori, grafici e confronto dei risultati.
Nessuna sostituzione globale dei tipi o eliminazione delle funzioni difficili.
