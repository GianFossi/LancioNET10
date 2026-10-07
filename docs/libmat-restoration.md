# Primo checkpoint: LibMat e supporto Word/RoutBase

LibMat compila su .NET 10: frmGuarn, frmTira e frmUpdate conservano controlli,
indici ed eventi usando dizionari WinForms. Le chiamate ByRef ricevono lo stesso
controllo, senza una conversione di ritorno da Control a TextBox.

Le API mancanti SuperStampa e sLogo di StubW2000 sono riprese dalla StubW9
fornita. RoutBase.Immatricolazione ha un overload clsSW9 con lo stesso corpo.
Il helper IndexOf accetta anche MenuItem, confrontando l'identita' dei riferimenti.

Non e' stato inventato clsTrigon.kWATT: la conversione termica richiede un valore
originale verificato tramite LANCIO_LEGACY_KWATT. Il codice disponibile clsBWG
non contiene UniMis e restituisce uno spessore della tabella in pollici, mentre
l'inizializzazione del form lo confronta in mm: il confine UniMis segnala questo
contratto mancante finche' viene verificato, evitando risultati ambigui.

I costruttori pubblici dei form conservano l'inizializzazione dati originale.
Un overload Friend separa la costruzione dei controlli per test Windows senza
aprire database reali. La politica temporanea WFO1000 e' warning visibile; i
progetti con AssemblyInfo manuale dichiarano esplicitamente la piattaforma Windows.

Il percorso locale LANCIO_INI si applica solo se esplicito; rimane la ricerca
storica nella directory di sistema. Un percorso esplicito inesistente e' un errore.

[Checkpoint complessivo, avvio e funzionalita' sospese](full-application-restoration.md).
