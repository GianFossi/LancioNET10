# Controllo unificato degli archivi

`tools/check-legacy-data.ps1` legge ArchDir/DatiDir da LANCIO_INI o dal file
LancioNET.ini nella radice; -IniPath consente la scelta esplicita. Confronta
ricorsivamente i file MDB/DAT forniti nelle cartelle Arch/Dati dei moduli src
con i relativi percorsi installati, conservando le sottocartelle. -Modules
limita la verifica a uno o piu' moduli. Riepilogo e CSV riportano PRESENT,
MISSING o EMPTY. Il report ha nome datato e non sovrascrive un file esistente.

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\check-legacy-data.ps1
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\check-legacy-data.ps1 -Modules AsmeVip
```

Exit 0: tutti i file selezionati presenti e non vuoti; 2: mancanti/vuoti.
Il controllo non copia ne' modifica archivi, non apre Access, non prova
schema, contenuto, provider, formule o DLL native. Non rileva file richiesti
ma assenti anche dalle sorgenti, nomi generati dinamicamente, file utente o
formati diversi da MDB/DAT. I moduli opzionali possono risultare mancanti.
Inventario sorgenti: 216 file MDB/DAT nelle cartelle Arch/Dati.
PowerShell non disponibile nel cloud: esecuzione script da verificare su Windows.

`tools/prepare-library-archives.ps1` copia inoltre gli archivi applicativi di
AsmeVip nella directory `ARCH` configurata, compreso `S&T.jpg`, richiesto
all'apertura della finestra principale. Lo script verifica gli hash e non
sovrascrive un file locale con contenuto diverso.
