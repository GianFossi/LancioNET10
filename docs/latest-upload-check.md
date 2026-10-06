# Verifica del caricamento a7ab45c

Verificato il commit `a7ab45c` di origin/main e integrato sulla branch di
migrazione. Nessuna modifica è stata inviata a main. I manifest del commit
remoto sono conservati nel legacy; le precedenti versioni allegate sono
conservate separatamente in docs/original-manifests per non perdere la provenienza.

- LibMat.NET contiene ora 68 file. Sono presenti i sorgenti di calcolo prima
  mancanti, tra cui clsMat.vb, InitLibMat.vb, CarattMat.vb e i form.
- Orecchia.NET contiene 19 file: tutti i Compile, EmbeddedResource e contenuti
  dichiarati nel suo manifest sono presenti, inclusi oreMonitor.vb, Var_Funz.vb
  e ProjectResources.resx.
- frmChart.resx e frmMater.resx sono presenti: il manifest LibMat usa resX.
  Questo è un problema di casing su Linux, non un upload mancante. Lo script
  ora registra tali differenze separatamente dai file effettivamente assenti.

## File LibMat ancora assenti

| Categoria | Percorso nel progetto originale |
| --- | --- |
| Sorgente generato impostazioni | My Project/Settings.Designer.vb |
| Definizione impostazioni | My Project/Settings.settings |
| Database | Arch/Mat200400.mdb |
| Dati | Arch/piping.new |
| Documento | Arch/Prezzi.doc |
| Database | Arch/tabelle.mdb |
| Configurazione | Arch/UpDateASME.ini |
| Database | Arch/WN5/gasket.mdb |

Le impostazioni potranno essere rigenerate quando sarà disponibile la definizione
originale; non inventare valori o database per completare l'inventario.

## Dipendenze ancora assenti

I manifest LibMat/Orecchia riferiscono anche progetti non caricati:
RoutBase2.NET/RoutBase2/RoutBase2.vbproj,
RoutBase3.NET/RoutBase3/RoutBase3.vbproj,
RoutBase4.NET/RoutBase4/RoutBase4.vbproj e StubW9.NET/StubW9.vbproj.
Non è presente DLL Extra/WinWordControl.dll.
Restano inoltre da preparare gli interop COM verificati e il porting delle
dipendenze condivise: i file ricevuti non dimostrano una build completa .NET 10.

Questa verifica riguarda presenza e coerenza dei file, non una nuova build o
validazione funzionale. I progetti SDK parziali in src non sono stati sincronizzati
automaticamente durante il check: l'integrazione dei nuovi sorgenti è il prossimo
passaggio di migrazione. Le precedenti sezioni dei documenti registrano lo stato
storico; il dettaglio corrente è in inventory/projects.json.
