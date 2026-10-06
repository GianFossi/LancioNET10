# Ricontrollo dopo il caricamento 74b259e

Recuperato e integrato origin/main al commit 74b259e nella branch di migrazione.
L'inventario completo ora contiene 3.086 file e 26 progetti VB.NET; sono presenti
anche il progetto C# originale WinWordControl e sorgenti/librerie Fortran.
I file originali non sono stati modificati e i binari caricati non sono stati
eseguiti. Il progetto C# originale è stato soltanto sottoposto a build: nessuna
parte del software VB è stata riscritta in C#.

## Nuovi prerequisiti disponibili

Sono ora presenti RoutBase2/3/4, StubW9, i file My Project di LibMat e i sei
file dati/configurazione prima mancanti. LibMat e Orecchia non hanno più file
dichiarati mancanti nel proprio manifest. WinWordControl ha anche i sorgenti
in legacy/WinWordControl, mentre la vecchia soluzione usa ancora un percorso
diverso: la presenza dei sorgenti non corregge automaticamente quel riferimento.

Copiati nella versione migrata soltanto i file disponibili che erano assenti,
preservando gli adapter ADO.NET/Word e le modifiche precedenti. Ripristinati nel
progetto LibMat gli import System.Data, System.Drawing e System.Windows.Forms,
e in Orecchia System.Drawing/System.Windows.Forms, già presenti negli originali.
Questo elimina errori su tipi WinForms non qualificati senza toccare i calcoli.

## Build e controlli eseguiti

Ambiente Linux, SDK .NET 10.0.401. Exit code acquisiti da ciascun processo dotnet.

| Target | Risultato |
| --- | --- |
| LancioNET10.slnx, Release | Passata, 7 progetti migrati |
| FormulaParser.Smoke | 22 controlli passati |
| Access.Smoke | 22 controlli SQL/schema passati |
| Word.Smoke | 22 controlli sessione con backend simulato passati |
| LibMat SDK Release | Fallita, 58 errori e 126 warning dopo la correzione degli import |
| Orecchia SDK Release | Fallita sulla dipendenza LibMat, stesso blocco |
| legacy/Lancio.sln | Fallita con MSB4025 prima della compilazione |
| Tutti i 26 progetti VB legacy, individualmente | 11 MSB4075, 14 MSB3644, 1 MSB4025 |
| WinWordControl.csproj originale | Fallita: reference assemblies .NET Framework 4.0 assenti |

Il vecchio errore Settings.Designer.vb mancante è risolto. Gli errori LibMat
ora riguardano soprattutto RoutBase1/4 e StubW2000/StubW9 non ancora collegati
a progetti SDK migrati, i control array Microsoft.VisualBasic.Compatibility.VB6
e gli eventi/tipi che dipendono da tali riferimenti. Esempi: LinkListS/LinkListSh,
clsMotore, LabelArray, ButtonArray, TextArray. I sorgenti delle dipendenze ora
ci sono: il blocco è il porting/collegamento, non la loro assenza dal repository.

I MSB4075 richiedono conversione dei formati Visual Studio 2003. I MSB3644
riguardano reference assembly .NET Framework 3.5/4.0 assenti in questa macchina.
AsmeVip conserva l'ampersand non escapato alla riga 618 del manifest originale
(MSB4025). Non è stato alterato il legacy per mascherare questi errori.

Risultati riproducibili dei singoli processi in
inventory/libraries-build-results.json; inventario aggiornato in projects.json.
Le prove dei database/provider e Word reali non sono state eseguite su Linux.
Non sono state tentate build native Fortran: i sette progetti .dsp e i 59
sorgenti .for/.f90 richiedono una valutazione dedicata della toolchain Windows,
ABI ed export, senza riscrivere i calcoli.

## Elementi ancora mancanti e prossimo lavoro

- RoutBase1: ControlArrays.resx.
- Lancion: 18 CHM dichiarati sotto Bin (documentazione compilata).
- Wald: Dll/WaldLib.dll; sono disponibili sorgenti Fortran da valutare.

Priorità successiva: migrare e collegare RoutBase/Stub e sostituire i control
array con collezioni WinForms, poi ripetere LibMat/Orecchia. La build completa
e il comportamento dell'applicazione non sono ancora verificati.
