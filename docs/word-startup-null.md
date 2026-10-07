# SuperStampa: avvio Word nullo

Il vecchio codice usava GetObject e tentava CreateObject solo se il primo
sollevava un'eccezione. Un risultato Nothing arrivava fino a lApp.Visible,
causando NullReferenceException. Ora verifica il risultato, tenta attivazione
COM con Word.Application (stessa API del backend Office moderno) e controlla
anche l'oggetto creato. Se l'attivazione fallisce, mostra il messaggio originale,
ripristina il cursore e lascia Stub Nothing. File Nothing equivale al documento
nuovo gia' previsto per il percorso vuoto. Percorso wordPanel invariato.

Nessuna modifica al contenuto dei rapporti o alle formule. Microsoft Word
desktop installato e COM registrato restano necessari: il build Linux non
verifica Office o la stampa reale. Verificata compilazione RoutBase1.
