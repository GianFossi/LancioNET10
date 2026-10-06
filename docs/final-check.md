# Controllo finale prima del push

Ultimo main verificato e integrato nella branch migration/vb-net10-inventory:
b0e0f43, che aggiunge WinWordControl.dll, Interop.ADOX.dll e altri interop sotto
legacy/DLL Extra. Conservati senza esecuzione. Non è stato fatto push su main.

| Verifica eseguita | Esito |
| --- | --- |
| Build Release LancioNET10.slnx con SDK 10.0.401 | Passata: 7 progetti, incluse libreria Office e pannello WinForms |
| FormulaParser.Smoke | 22 controlli passati |
| Access.Smoke | 22 controlli SQL/schema passati; provider reale non eseguito |
| Word.Smoke | 22 controlli sessione con backend simulato passati; Office reale non eseguito |
| LibMat SDK Release | Fallita: BC2001, My Project/Settings.Designer.vb assente |
| Orecchia SDK Release | Fallita sulla stessa dipendenza LibMat |

Sono ancora presenti i tre avvisi BC42353 del parser nelle build che ricompilano
i sorgenti. Le build incrementali possono non ripeterli. L'adapter e il pannello
Word compilano, ma i quattro file applicativi adattati sotto src/AsmeVip e
src/RoutBase sono ancora esclusi dalla soluzione: non costituiscono una build
del programma completo e non sono stati validati dal compilatore.

Le DLL appena caricate non sostituiscono i file mancanti My Project né i progetti
RoutBase2/3/4 e StubW9. La validazione Word, MDB/XLS e UI richiede una macchina
Windows con Office e provider compatibili. Nessun algoritmo di calcolo è stato
modificato. Le copie originali sono conservate e i file bin/obj/.user generati
dalle verifiche non sono inclusi nei nuovi commit.

Per ripetere:

```sh
dotnet build LancioNET10.slnx -c Release
dotnet run --project tests/FormulaParser.Smoke -c Release --no-build
dotnet run --project tests/Access.Smoke -c Release --no-build
dotnet run --project tests/Word.Smoke -c Release --no-build
```

Dettagli dell'integrazione Word e dei limiti in word-modernization.md; percorso
ADO.NET in ado-modernization.md. La CI ora esegue tutte e tre le suite, ma una
run GitHub Actions non è ancora stata osservata durante questo controllo.
