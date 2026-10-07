# WRCB: archivi e barre di stato

Lo script di preparazione include src/Wrcb/Arch, mantenendo la sottocartella WR
con WRCBDATA.DAT e i file originali. Verificati 256 percorsi unici senza conflitti
nelle cinque sorgenti LibMat, Grafic2, RoutBase, Traccia e Wrcb.
Una copia successiva agli 85 file precedenti aggiunge 171 file mancanti.

StatusBar e StatusBarPanel hanno costruttori non supportati da .NET 10.
Convertiti i cinque form che li costruivano (WRCB, Traccia, ASME, DataSheet,
BreLock) a StatusStrip e ToolStripStatusLabel. Conservati ordine e aggiornamenti
dei testi: Panels diventa Items; Spring conserva l'espansione; LegacyStatusLabel estende il controllo moderno
con MinimumWidth nella misura preferita per conservare i minimi originali.
Traccia conserva il comando del terzo pannello usando ItemClicked/ClickedItem.
Nessuna modifica alle formule o al contenuto degli archivi originali.

MenuStartup.Smoke include la costruzione del form WRCB e controlla tre campi,
collegamento al form, espansione e aggiornamento del testo. Build Linux verifica
la compilazione; apertura WRCB e test runtime Windows restano da verificare.
