# AsmeVip e DataShDll

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
