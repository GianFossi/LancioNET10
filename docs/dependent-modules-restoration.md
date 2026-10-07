# Dipendenze di Lancion: Orecchia, Saddles, Traccia, Tiranti, Wrcb

Le costruzioni BinaryFormatter usano il bridge LegacyBinarySerializer gia'
introdotto: il requisito di opt-in esplicito vale anche per questi documenti.
Le qualificazioni Windows.Forms diventano System.Windows.Forms per evitare il
conflitto con il namespace Windows. I riferimenti irrisolvibili e non usati sono
rimossi dai manifest SDK; WFO1000 rimane un warning visibile nei form.

In Tiranti il chiamante assegna clsTira.Dnom ma passava due directory a Cerca.
La versione LibMat fornita accetta il nome del campo: la chiamata e' Cerca("Dnom")
e usa il corpo della ricerca esistente. Nessuna formula di serraggio e' sostituita.

[Avvio e limiti del ripristino complessivo](full-application-restoration.md).
