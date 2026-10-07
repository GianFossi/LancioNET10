# Traccia: errori di inizializzazione

InizializzaGen intercettava l'errore originale e proseguiva con MainForm nullo:
Esegui falliva poi su ShowDialog, nascondendo la causa utile. Ora l'errore viene
propagato con Throw al gestore di Esegui e Inizializzando viene ripristinato nel
Finally. Routines e' pubblicato sul monitor solo dopo Init200 riuscito, evitando
che un tentativo successivo salti la lettura dei dati per un oggetto incompleto.
Nessuna modifica a formule, disegno o dati. Questa correzione elimina la
prosecuzione dopo errore: non dimostra che l'inizializzazione riesca su Windows.
Serve il primo messaggio originale per diagnosticare eventuali ulteriori blocchi.
