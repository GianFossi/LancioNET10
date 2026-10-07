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
