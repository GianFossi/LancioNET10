# Recupero del wrapper ADOX

Il check su origin/main, commit a7ab45c, non trova ADOX/ADODB interop né
WinWordControl.dll. La ricerca NuGet ADOX non ha identificato un pacchetto
Microsoft verificabile adatto alla sostituzione diretta; non sono state
scaricate DLL da fonti sconosciute.

ADOX è una libreria COM Windows. Il wrapper .NET può essere generato dalla
type library contenuta nel componente Microsoft msadox.dll già installato,
con tlbimp.exe dei tool .NET Framework SDK. Il solo SDK dotnet non fornisce
necessariamente tale tool. Usare una macchina Windows attendibile e verificare
provenienza/versione dei componenti installati, senza disabilitare verifiche
di firma o TLS per installare tool o librerie.

Da una Developer PowerShell Visual Studio nella radice del repository:

```powershell
./tools/export-adox-interop.ps1 -Architecture x86
```

Se necessario, specificare -TlbImpPath e -TypeLibraryPath con i percorsi
effettivi locali. Il default x86 è una scelta iniziale per il legacy Jet/ActiveX,
non una verifica della bitness dell'intera applicazione. Valutare x64 soltanto
con provider, OCX e processo Windows coerenti.

Lo script produce local/interop/Interop.ADOX.dll e un file di provenienza
con versioni/hash; eventuali wrapper di dipendenze generati da tlbimp restano
nella stessa directory. Non sovrascrive un wrapper esistente. local/ è ignorato
da Git: conservare gli artefatti verificati nel setup o in un archivio controllato,
non tra bin/obj o come DLL raccolte da siti generici.

Lo script non è stato eseguito o validato su Windows nella macchina cloud Linux.
Generare il wrapper non rende disponibile il COM su Linux e non risolve da solo
ADODB, provider Jet/ACE, RoutBase/StubW9, VB6 compatibility e gli altri blocchi.
Il riferimento LibMat cerca il nome Interop.ADOX.dll nella directory indicata.
La build e il funzionamento COM vanno verificati dopo il recupero.

Per WinWordControl cercare sul computer originale DLL Extra/WinWordControl.dll,
percorso indicato dai manifest. Il riferimento di progetto non dimostra che
la DLL sia stata caricata sul repository. La soluzione alternativa Word esterno
e il percorso embedded sono descritti in reconstructed-projects.md.
