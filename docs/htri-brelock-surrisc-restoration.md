# HTRI, BreLock e Surrisc: confini delle versioni mancanti

I form BreLock/Surrisc usano dizionari WinForms con indici e handler originali.
HTRI accede tramite il tipo effettivo ai diversi form in InputForms; Caption,
ListIndex e l'assegnazione dei RadioButton diventano Text, SelectedIndex e Checked.
I helper di formattazione degli ID usano lo stesso numero di cifre decimali.
Le formule di ingegneria non vengono sostituite.

LegacyBreLockLicense delega al provider originale Infralution: GetLicense e,
se necessario, LicenseInstallForm.ShowDialog. La DLL e' richiesta esplicitamente
per ciascun modulo; il provider assente/incompatibile nega la verifica. Nessuna
chiave e' generata e nessun controllo di licenza e' bypassato.

HTRI richiede API RoutBase assenti: lettura PRV a cinque argomenti/Open/Close,
overload di salvataggio e Indirizzo. LegacyEstimateDatabase e LegacyRoutBaseContract
rifiutano i percorsi non disponibili: non inventano un valore ilsi o un nuovo
layout dei documenti. I rapporti HTRI/BreLock restano sospesi tramite
LegacyReportCompatibility, per Testata(NumeraPagine)/pagtot mancanti.

Surrisc richiede l'export Traccia.Scrivi(ByRef File), assente nella Traccia fornita.
LegacyTracciaExport segnala il requisito: Scrivi() non restituisce il percorso
da rileggere, quindi non viene usato come sostituzione arbitraria.

Il launcher LancioHTRI usa x86/STA e un INI esplicito invece della Standard(Assembly)
non fornita. Le DLL native mancanti restano un requisito funzionale esterno.

[Build completa, percorsi sospesi e passi Windows](full-application-restoration.md).
