# Microsoft Word al posto di WinWordControl

Nel controllo finale il commit remoto b0e0f43 ha aggiunto
legacy/DLL Extra/WinWordControl.dll e diversi interop, ora conservati nel legacy.
La DLL originale è quindi disponibile come riferimento per future analisi e
per la verifica del vecchio comportamento embedded. Non è stata eseguita;
la nuova integrazione rimane indipendente da essa come richiesto.

## Implementazione

Creati due componenti VB.NET SDK-style net10.0-windows:

- Lancio.Office.Word: sessione documento testabile e backend Office COM tramite
  Word.Application. Apertura documenti, creazione da template, salvataggio
  DOC/DOCX/DOCM/DOT/DOTX/DOTM/RTF, esportazione PDF e stampa sincrona.
- Lancio.Office.Word.WinForms: WordReportPanel, un controllo WinForms normale
  che apre il rapporto nella finestra Word. Non incorpora finestre Office
  tramite SetParent o ActiveX e non usa WinWordControl.dll.

La tecnologia sottostante è l'automazione ufficiale del Word desktop installato,
non un pacchetto che installa Office o un editor Word indipendente. Il backend
usa late binding confinato a un singolo file per evitare dipendenze da PIA
generate per Word 2000. Il resto dell'adapter ha Option Strict On.
Richiede Windows, Microsoft Word desktop con SaveAs2/PDF (versione moderna),
licenza e prima configurazione completate, sessione interattiva e thread STA.
Non è previsto l'uso per automazione Office in un servizio cloud Linux.

La sessione crea una propria application Word e non si collega a una sessione
esistente dell'utente. Le scelte di chiusura sono Prompt, Save e Discard;
il default è Prompt. Errori o annullamento della chiusura conservano lo stato
per poter riprovare. Sono rifiutate chiamate da altri thread, operazioni dopo
Dispose e stampe/salvataggi senza documento. SaveAs/ExportPdf non sovrascrivono
file esistenti; l'utente può salvare dal Word esterno o scegliere un altro nome.
Il backend rilascia i riferimenti COM di cui è responsabile senza FinalRelease.

## Integrazione nella copia migrata

Copiati e adattati quattro file in src/AsmeVip e src/RoutBase:
frmASME.vb, mainASME.vb, Inizio.vb e Motore.vb. I tipi e le chiamate al controllo
sconosciuto ora usano WordReportPanel e i suoi metodi espliciti. La voce menu
descrive l'apertura dei rapporti in Microsoft Word, non un editor inglobato.
La vecchia chiave INI WordEmbedded è conservata per leggere le preferenze
esistenti, ma nella copia migrata seleziona il pannello con Word esterno.
La selezione del pannello non avvia più Word durante il caricamento di AsmeVip:
l'istanza COM viene creata soltanto alla prima apertura o creazione effettiva
di un rapporto. Anche la disattivazione del pannello non avvia Word.

Il percorso attivo del pannello in SuperStampa apre/crea tramite la nuova
sessione e passa i documenti/applicazione nativi al vecchio StubW2000 con cast
espliciti, per mantenere la generazione dei rapporti. Nessun algoritmo tecnico
è stato modificato. La chiusura del form cerca di chiudere la sessione con prompt;
un errore annulla la chiusura dove il form espone CancelEventArgs.

**Questi quattro file sono una preparazione dell'integrazione, non progetti
AsmeVip/RoutBase già compilati.** Non fanno parte della soluzione dei componenti
verificati: mancano ancora i loro progetti SDK completi e le altre dipendenze.
StubW2000 resta su tipi Word/Office legacy da migrare; anche il percorso Word
esterno precedente, usato quando il pannello è disabilitato, resta da consolidare.
La vecchia funzionalità embedded è conservata nel legacy originale, ma nella
versione migrata l'interfaccia proposta usa una finestra Word separata. Non
viene dichiarata equivalenza di hosting, focus o comportamento del vecchio
RestoreNormal, la cui implementazione originale non è disponibile.

## Verifica

La soluzione LancioNET10.slnx include core Word, pannello WinForms e Word.Smoke,
oltre a FormulaParser e Access. Build Release riuscita su Linux con targeting
Windows per il pannello. Word.Smoke usa un backend simulato e verifica ciclo
di vita, thread proprietario, annullamento chiusura, template, formati, protezione
dei file esistenti, delega PDF/stampa e Dispose. Non avvia o stampa con Word.

La CI esegue anche questi controlli. Build e test del core/pannello non
dimostrano il funzionamento dei quattro chiamanti non ancora compilati.
Il backend Office reale e il pannello non sono stati eseguiti su Windows.
Prima dell'uso occorre verificare con copie dei template originali: apertura,
bookmark e campi compilati da StubW2000, tabelle/formattazione, DOC/DOCX/PDF,
stampa, documenti chiusi manualmente, annullamento dei prompt, mancanza di Word,
fine sessione e assenza di processi Word rimasti aperti. Il nuovo adapter non
può essere descritto come collaudato con Office finché queste prove non passano.

Comandi dalla radice:

```sh
dotnet build LancioNET10.slnx -c Release
dotnet run --project tests/Word.Smoke -c Release --no-build
dotnet run --project tests/Access.Smoke -c Release --no-build
dotnet run --project tests/FormulaParser.Smoke -c Release --no-build
```

Riferimenti API Microsoft:
[automazione Word](https://learn.microsoft.com/office/vba/api/overview/word),
[Documents.Open](https://learn.microsoft.com/office/vba/api/word.documents.open),
[SaveAs2](https://learn.microsoft.com/office/vba/api/word.saveas2),
[ExportAsFixedFormat](https://learn.microsoft.com/office/vba/api/word.document.exportasfixedformat).
