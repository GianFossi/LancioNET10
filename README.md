# LancioNET10

Migrazione VB.NET di Lancion, per recipienti in pressione e scambiatori di calore.
I sorgenti originali sono conservati in `legacy/`; la versione .NET 10 e' in `src/`.

Per **Visual Studio 2026**, aprire `LancioNET10.App.slnx` e impostare **Lancion**
come progetto di avvio. La compilazione della GUI non richiede Python.
Sono necessari SDK .NET 10.0.401 e, per l'avvio, Windows e Desktop Runtime .NET 10 x86.

- `LancioNET10.App.slnx`: Lancion e le sue 20 dipendenze (21 progetti).
- `LancioNET10.Full.slnx`: tutti i 26 progetti VB convertiti, inclusi moduli standalone.
- `LancioNET10.slnx`: componenti e test; l'harness ASME richiede anche Python.

[Avvio sul PC, modifiche e funzionalita' ancora da verificare](docs/full-application-restoration.md).
La compilazione completa non prova il funzionamento di ogni percorso: alcuni
adapter segnalano API o librerie originali ancora mancanti.

[Debugger ASME e progetto del futuro core F#](docs/engineering-debug-and-new-core.md).

[Modulo Tracciatura: funzionamento, algoritmi e flowchart](docs/Tracciatura-funzionamento-e-algoritmi.pdf)
([sorgente modificabile](docs/tracciatura-algoritmi.md)).
