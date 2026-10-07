# Tracciature: cast residui dei pannelli

Rimossi sei cast ISupportInitialize ai vecchi StatusBarPanel nel designer
manuale di frmTracciat. I nuovi LegacyStatusLabel derivano da ToolStripStatusLabel
e non implementano quell'interfaccia. I cast bloccavano InitializeComponent.
Rimossi anche i sedici cast identici rimasti nei form ASME, WRCB e DataSheet.
Nessuna modifica a formule, testi o eventi. MenuStartup.Smoke costruisce ora
anche frmTracciat senza aprirlo e verifica i tre pannelli collegati al form.
Compilazione verificata su Linux; test runtime richiede Windows.

PPSM e' un problema distinto: mnuPPSM_Click contiene solo chiamate commentate
a PPSM.clsPPSM. Nel materiale disponibile non risultano progetto o assembly
PPSM; PPSM.doc e file di aiuto non sostituiscono l'implementazione.
Occorre recuperare il progetto/DLL originale prima di ricollegare il comando.
