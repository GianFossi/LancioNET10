# AsmeVip e DataShDll

## Conversione dei file VIP originali

La conversione inizializza sempre le collezioni degli indici dei materiali,
anche nel percorso `EseguiSciolto`, e controlla gli indici prima di accedere a
`Matdim`. Il salvataggio del nuovo formato avviene prima in un file temporaneo
nella stessa directory e sostituisce il file scelto soltanto dopo una
serializzazione completa; un errore conserva quindi il file originale. Le
directory mancanti vengono create. I vecchi ritorni a `BaseDir\Dll`, directory
non presente nell'installazione .NET 10, usano ora la directory effettiva
dell'eseguibile.

Dopo l'apertura, la finestra dei dati generali viene mostrata come dialogo
figlio centrato sulla finestra AsmeVip. Questo evita che il dialogo modale resti
nascosto dietro la finestra principale facendo apparire l'applicazione bloccata.
Durante la selezione e lettura del file la barra di stato mostra inoltre che il
caricamento è in corso. Annullamento ed errori della finestra di selezione non
vengono più interpretati come un caricamento riuscito.

La schermata iniziale `S&T.jpg` viene nascosta quando un progetto è aperto.
I tre pannelli di lavoro, compreso l'albero laterale usato per selezionare e
inserire i componenti, vengono resi visibili e portati esplicitamente in primo
piano. Alla chiusura del progetto i pannelli vengono nascosti e la schermata
iniziale viene ripristinata.

Un progetto senza componenti mantiene ora abilitato `Inserisci elemento` e
mostra anche un pulsante `Inserisci` nel pannello sinistro. Selezionando
`LatoMant`, `LatoTubi` o `Fra i due`, il pulsante crea il primo elemento; lo
stato riporta il percorso del file anche quando il modello è ancora vuoto.

Ogni avvio registra i tempi cumulativi di costruttore, dipendenze, commessa,
costruzione e visualizzazione della finestra in
`%LOCALAPPDATA%\LancioNET10-Debug\asme-startup.log`. Il report permette di
distinguere il costo dell'avvio del modulo da quello dell'apertura di un file
VIP, incluso un file collocato in una cartella OneDrive.

AsmeVip usa il bridge di serializzazione isolato e namespace WinForms espliciti.
RichiaTir assegna Diam e chiama la ricerca esistente Cerca("Diam"), coerente con
la firma LibMat fornita. I corpi delle routine Calcoli.vb non sono stati cambiati.

DataShDll conserva controlli e indici tramite dizionari WinForms. Gli eventi sono
collegati dopo l'inizializzazione; il testo delle liste e le coordinate pixel/twip
usano API WinForms normali. Il DataTable tbClassi viene Dispose, non Close.

BWG_Renamed diventa il campo esistente BWG; il requisito UniMis rimane un errore
esplicito nel compatibility boundary LibMat, finche' le unita' originali vengono
verificate. Non viene restituito uno spessore ambiguo al datasheet.

WFO1000 resta warning; i riferimenti SDK irrisolvibili e non usati sono rimossi.
I vecchi resx restano presenti: la risorsa duplicata str7278 di HelpTopics e'
segnalata dal build, senza scegliere automaticamente una nuova traduzione.

[Avvio e limiti della verifica funzionale](full-application-restoration.md).
