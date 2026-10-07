# Archivi flange, tiranti e materiali

L'INI di debug punta ad ARCH sotto LocalAppData/LancioNET10-Debug.
Creare la cartella non installa i database: Flange.mdb manca finche' gli archivi
non vengono copiati. Gli originali sono forniti in src/Grafic2/Arch e src/LibMat/Arch.

Da PowerShell, con Lancion fermo:

```powershell
cd C:\Users\gianl\source\repos\GianFossi\LancioNET10
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\prepare-library-archives.ps1
```

Se ArchDir nell'INI e' diverso, passare `-ArchiveDirectory` con quel percorso.
Lo script precontrolla conflitti SHA256, conserva la struttura delle sottocartelle,
non sovrascrive alcun file e verifica le copie. Una seconda esecuzione conserva
le copie identiche. Non modificare i database sotto legacy o src per lavorare.

Inventario verificato: 58 percorsi distinti, nessun conflitto tra le due sorgenti;
Flange.mdb, tabelle.mdb, Mat200400.mdb presenti. PowerShell non disponibile nel
cloud Linux: script e accesso reale OLE DB devono essere verificati su Windows.
Non e' un'installazione completa degli archivi ASME o di altri moduli.

## Tracciature e archivi condivisi

Lo script include ora src/RoutBase/Arch e src/Traccia/Arch. STRI04.DAT viene
letto da Routines.Init200 prima di costruire il form di tracciatura.
Verificati 85 percorsi distinti senza conflitti; STRI04.DAT contiene almeno
le nove righe richieste dalla routine originale. La seconda esecuzione dopo
la prima copia conserva i 58 file identici e aggiunge 27 file mancanti.
Non sono state modificate formule o routine di disegno. L'apertura del modulo
su Windows resta da verificare; gli archivi degli altri moduli non sono inclusi.
