# Menu WinForms .NET 10 (2026-10-07)

MenuItem/MainMenu/ContextMenu compilano ma i costruttori non sono supportati
nel runtime moderno. Convertiti dieci form, compresi Lancion e ASME, a
ToolStripMenuItem/MenuStrip/ContextMenuStrip. I dizionari mantengono indici e
identita; la gerarchia usa Items e DropDownItems nell'ordine originale.
Le scorciatoie mantengono i valori originali tramite Keys. Il menu principale
viene collegato a MainMenuStrip e alla collezione Controls del form.

Click conserva i comandi originali; Popup diventa DropDownOpening per i
sottomenu e Opening per il menu contestuale. I wrapper Popup dei comandi
foglia non vengono collegati nuovamente a Click: sarebbe una doppia esecuzione.
Nessuna modifica a formule o controlli di licenza. Le risorse originali restano.

MenuStartup.Smoke costruisce il form principale e ASME senza mostrarli e verifica
menu collegati e indici. Il test richiede Windows x86 ed e' aggiunto alla CI.
Compilazione verificata su Linux; GUI e test runtime Windows non eseguiti qui.
