# Comandi di avvio non implementati

I comandi del launcher con sole chiamate legacy commentate mostrano ora una
finestra con NOT IMPLEMENTED e il nome del modulo: PPSM, le quattro librerie
termiche, WHB/BabCock, Surrisc, Coni, BreLock, WPS, FBMUtil, LigTem, Fire e
stampa della libreria flange. I commenti originali rimangono disponibili.
I percorsi non operativi tornano prima di minimizzare il launcher, modificare
stato o scrivere la configurazione. Nessuna modifica a moduli operativi o formule.

Gli eventi Popup dei comandi notificati non sono usati per eseguire l'azione
quando si apre un menu; Click mostra la finestra. Gli indici mnuTerm mantengono
il gestore Click senza il wrapper Popup che richiamava lo stesso comando.
La disponibilita' delle voci continua a seguire Features nell'INI.

Verifica: compilazione LancioNET10.App su Linux. Finestre modali da verificare
su Windows; il messaggio non indica che il modulo e' stato ripristinato.
