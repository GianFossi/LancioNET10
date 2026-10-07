# Azioni di installazione

.NET 10 non fornisce System.Configuration.Install.Installer. Installer1 conserva
Install/Commit come metodi espliciti di Component e LegacyInstallerContext fornisce
la raccolta dei parametri richiesta dalle azioni originali.

Il codice compila, ma questa trasformazione non rende la DLL utilizzabile come
custom action .NET Framework MSI/InstallUtil. Un nuovo installer deve adattare
l'invocazione delle azioni, le cartelle e i permessi. La build e i test cloud non
invocano Commit/AggiornaINI e non scrivono nella directory di sistema.

[Configurazione INI locale di Lancion](full-application-restoration.md).
