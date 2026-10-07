# Controllo testo delle finestre e dei menu

Il controllo è opzionale, non modifica dimensioni, font, formule o dati. Misura etichette, pulsanti e voci ToolStrip visibili usando il layout corrente e registra possibili tagli in CSV. Si applica alle finestre di tutti i moduli aperte nello stesso processo Lancio. I menu a discesa e le schede devono essere aperti perché il loro layout sia misurato.

Da PowerShell, nella cartella del repository, dopo il pull:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\check-ui-text.ps1 -IniPath .\LancioNET.ini
```

Aggiungere `-EnableTrustedLegacySerialization` soltanto per usare archivi originali locali attendibili. Lo script compila e avvia Lancio; aprire ogni modulo, ogni menu e ogni scheda, quindi chiudere l'applicazione. Il percorso del CSV viene mostrato nel terminale. Ripetere con le scale Windows effettivamente usate (100%, 125%, 150%).

Per il debugger Visual Studio, impostare `LANCIO_TEXT_LAYOUT_REPORT` nell'ambiente di avvio del progetto Lancion a un percorso CSV scrivibile. Senza questa variabile il controllo non si attiva.

Le segnalazioni sono indizi da verificare visivamente, non prove di testo tagliato: immagini nei pulsanti e layout personalizzati possono influenzare la misura. Un report vuoto non certifica finestre mai aperte, contenuto scorrevole, titoli di finestra, griglie o controlli personalizzati. Il cloud Linux verifica la compilazione; non può verificare la resa WinForms su Windows. Non sono stati applicati ridimensionamenti indiscriminati, che potrebbero sovrapporre i controlli.
