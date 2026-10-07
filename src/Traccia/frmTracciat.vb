Option Strict On
Option Explicit On 
Imports VB = Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports RoutBase1
Friend Class frmTracciat
    Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()
        ' If m_vb6FormDefInstance Is Nothing Then
        ' If m_InitializingDefInstance Then
        ' m_vb6FormDefInstance = Me
        ' Else
        '     Try
        ' 'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        ' If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        ' m_vb6FormDefInstance = Me
        ' End If
        '     Catch
        ' End Try
        ' End If
        ' End If
        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        Text1 = New Text1Array(Me)
        Dim Text1_0 As arrText1 = Text1.AddNewTextBox
        Text1_0.Location = New System.Drawing.Point(10, 10)
        Text1_0.Size = New System.Drawing.Size(128, 21)
        Text1_0.Multiline = True
        Text1_0.TextAlign = HorizontalAlignment.Right
        Pix = New PixArray(Me)
        Dim Pix_0 As arrPix = Pix.AddNewTextBox
        Pix_0.Location = New System.Drawing.Point(10, 10)
        Pix_0.Size = New System.Drawing.Size(89, 57)
        Pix_0.BorderStyle = BorderStyle.FixedSingle
        Pix_0.Visible = False
        Check1 = New CheckArray(Me)
        Dim Check1_0 As arrCheck = Check1.AddNewTextBox
        Check1_0.Location = New System.Drawing.Point(10, 10)
        Check1_0.Size = New System.Drawing.Size(128, 21)
        Label1 = New LabelArray(CType(Me.Frame, Control))
        Dim Label1_0 As arrLabel = Label1.AddNewTextBox("Label1")
        Label1_0.Location = New System.Drawing.Point(10, 10)
        Label1_0.Size = New System.Drawing.Size(172, 21)
        Label1_0.BorderStyle = BorderStyle.Fixed3D
        Label1_0.FlatStyle = FlatStyle.Standard
        Label2 = New LabelArray(CType(Me.Frame, Control))
        Dim Label2_0 As arrLabel = Label2.AddNewTextBox("Label2")
        Label2_0.Location = New System.Drawing.Point(10, 10)
        Label2_0.Size = New System.Drawing.Size(41, 21)
        Label2_0.BorderStyle = BorderStyle.FixedSingle
        Label2_0.FlatStyle = FlatStyle.Standard
        Label2_0.BackColor = Color.Cyan
        Combo1 = New ComboArray(Me)
        Dim Combo1_0 As arrCombo = Combo1.AddNewTextBox("Combo1")
        Combo1_0.Location = New System.Drawing.Point(10, 10)
        Combo1_0.Size = New System.Drawing.Size(128, 21)
        Combo1_0.DropDownStyle = ComboBoxStyle.DropDown
        Combo1_0.DropDownWidth = 200
        Combo1_0.TabStop = False
        Combo2 = New ComboArray(Me)
        Dim Combo2_0 As arrCombo = Combo2.AddNewTextBox("Combo2")
        Combo2_0.Location = New System.Drawing.Point(10, 10)
        Combo2_0.Size = New System.Drawing.Size(128, 21)
        Combo2_0.DropDownStyle = ComboBoxStyle.DropDownList
        Combo2_0.TabStop = False
        Combo2_0.BackColor = Color.Cyan
        HelpProvider1.HelpNamespace = RadiceHelp
        HelpProvider1.SetShowHelp(_cmdTraccia_2, True)
        Inizializza()
    End Sub

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalvaCome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEsci As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pctRisult As System.Windows.Forms.PictureBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents panRisult As System.Windows.Forms.Panel
    Friend WithEvents cmdAggiorna As System.Windows.Forms.Button
    Friend WithEvents mnuStampa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Frame1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSpostOK As System.Windows.Forms.Button
    Friend WithEvents cmdUp As System.Windows.Forms.Button
    Friend WithEvents cmdRight As System.Windows.Forms.Button
    Friend WithEvents cmdLeft As System.Windows.Forms.Button
    Friend WithEvents cmdDown As System.Windows.Forms.Button
    Friend WithEvents MenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDati As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCalcola As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDisegna As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu4sp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuElim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusBarPanel1 As Global.LancioMigration.LegacyStatusLabel
    Friend WithEvents StatusBarPanel2 As Global.LancioMigration.LegacyStatusLabel
    Friend WithEvents StatusBarPanel3 As Global.LancioMigration.LegacyStatusLabel
    Friend WithEvents panStrumenti As System.Windows.Forms.Panel
    Friend WithEvents cmdZoom As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdFull As System.Windows.Forms.Button
    Friend WithEvents Picture1 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuPref As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd4Ssp As System.Windows.Forms.Button
    Friend WithEvents mnuTiranti As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTondi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPiatti As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTagli As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mioContesto As System.Windows.Forms.ContextMenuStrip
    Public WithEvents _cmdTraccia_2 As System.Windows.Forms.Button
    Friend WithEvents popTogli As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popCambia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popDimen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popRuota As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popRuotaGen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRipristina As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Break As System.Windows.Forms.Button
    Friend WithEvents mnuAree As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLavori As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStrategia As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents popToglTi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListSelect As System.Windows.Forms.ListBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents mnuApri As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdElim As System.Windows.Forms.Button
    Friend WithEvents ToolTipHelp As System.Windows.Forms.ToolTip
    Friend WithEvents Frame As System.Windows.Forms.GroupBox
    Friend WithEvents cmdApri As System.Windows.Forms.Button
    Friend WithEvents cmdDati As System.Windows.Forms.Button
    Friend WithEvents cmdCalcola As System.Windows.Forms.Button
    Public WithEvents cmdTipPass As System.Windows.Forms.Button
    Friend WithEvents mnuSoloPerif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents cmdDisTrk As System.Windows.Forms.Button
    Friend WithEvents cmdStampa As System.Windows.Forms.Button
    Friend WithEvents MenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGuida As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInformazioni As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuChiudi As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTracciat))
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.MenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuApri = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSalva = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSalvaCome = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRipristina = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStampa = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRM = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuChiudi = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEsci = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDati = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTiranti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTondi = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPiatti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTagli = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCalcola = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDisegna = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu4sp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuElim = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPref = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAree = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLavori = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStrategia = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSoloPerif = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGuida = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInformazioni = New System.Windows.Forms.ToolStripMenuItem
        Me.pctRisult = New System.Windows.Forms.PictureBox
        Me.panRisult = New System.Windows.Forms.Panel
        Me.cmdAggiorna = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Frame1 = New System.Windows.Forms.Panel
        Me.cmdDown = New System.Windows.Forms.Button
        Me.cmdLeft = New System.Windows.Forms.Button
        Me.cmdRight = New System.Windows.Forms.Button
        Me.cmdUp = New System.Windows.Forms.Button
        Me.cmdSpostOK = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusStrip
        Me.StatusBarPanel1 = New Global.LancioMigration.LegacyStatusLabel
        Me.StatusBarPanel2 = New Global.LancioMigration.LegacyStatusLabel
        Me.StatusBarPanel3 = New Global.LancioMigration.LegacyStatusLabel
        Me.panStrumenti = New System.Windows.Forms.Panel
        Me.cmdStampa = New System.Windows.Forms.Button
        Me.cmdDisTrk = New System.Windows.Forms.Button
        Me.cmdSalva = New System.Windows.Forms.Button
        Me.cmdCalcola = New System.Windows.Forms.Button
        Me.cmdDati = New System.Windows.Forms.Button
        Me.cmdApri = New System.Windows.Forms.Button
        Me.cmdElim = New System.Windows.Forms.Button
        Me.Break = New System.Windows.Forms.Button
        Me._cmdTraccia_2 = New System.Windows.Forms.Button
        Me.cmdFull = New System.Windows.Forms.Button
        Me.cmdZoom = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmd4Ssp = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.mioContesto = New System.Windows.Forms.ContextMenuStrip
        Me.popTogli = New System.Windows.Forms.ToolStripMenuItem
        Me.popCambia = New System.Windows.Forms.ToolStripMenuItem
        Me.popToglTi = New System.Windows.Forms.ToolStripMenuItem
        Me.popDimen = New System.Windows.Forms.ToolStripMenuItem
        Me.popRuota = New System.Windows.Forms.ToolStripMenuItem
        Me.popRuotaGen = New System.Windows.Forms.ToolStripMenuItem
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ListSelect = New System.Windows.Forms.ListBox
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.cmdTipPass = New System.Windows.Forms.Button
        Me.ToolTipHelp = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame = New System.Windows.Forms.GroupBox
        Me.panRisult.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.panStrumenti.SuspendLayout()
        Me.Frame.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.MenuItem1, Me.MenuItem4, Me.MenuItem5, Me.mnuPref, Me.MenuItem6})
        '
        'MenuItem1
        '

        Me.MenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuApri, Me.mnuSalva, Me.mnuSalvaCome, Me.mnuRipristina, Me.MenuItem3, Me.mnuStampa, Me.mnuRM, Me.MenuItem2, Me.mnuChiudi, Me.mnuEsci})
        Me.MenuItem1.Text = "File"
        '
        'mnuApri
        '

        Me.mnuApri.Text = "Apri"
        '
        'mnuSalva
        '
        Me.mnuSalva.Enabled = False

        Me.mnuSalva.Text = "Salva"
        '
        'mnuSalvaCome
        '
        Me.mnuSalvaCome.Enabled = False

        Me.mnuSalvaCome.Text = "Salva come ..."
        '
        'mnuRipristina
        '
        Me.mnuRipristina.Enabled = False

        Me.mnuRipristina.Text = "Ripristina"
        '
        'MenuItem3
        '

        Me.MenuItem3.Text = "-"
        '
        'mnuStampa
        '
        Me.mnuStampa.Enabled = False

        Me.mnuStampa.Text = "Esposta disegno ..."
        '
        'mnuRM
        '
        Me.mnuRM.Enabled = False

        Me.mnuRM.Text = "RM"
        '
        'MenuItem2
        '

        Me.MenuItem2.Text = "-"
        '
        'mnuChiudi
        '
        Me.mnuChiudi.Enabled = False

        Me.mnuChiudi.Text = "Chiudi"
        '
        'mnuEsci
        '

        Me.mnuEsci.Text = "Esci"
        '
        'MenuItem4
        '

        Me.MenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuDati, Me.mnuTiranti, Me.mnuTondi, Me.mnuPiatti, Me.mnuTagli})
        Me.MenuItem4.Text = "Modifica"
        '
        'mnuDati
        '

        Me.mnuDati.Text = "Dati di progetto"
        '
        'mnuTiranti
        '

        Me.mnuTiranti.Text = "Tiranti"
        '
        'mnuTondi
        '

        Me.mnuTondi.Text = "Tondi"
        '
        'mnuPiatti
        '

        Me.mnuPiatti.Text = "Piatti"
        '
        'mnuTagli
        '

        Me.mnuTagli.Text = "Tagli diaframmi"
        '
        'MenuItem5
        '

        Me.MenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuCalcola, Me.mnuDisegna, Me.mnu4sp, Me.mnuElim})
        Me.MenuItem5.Text = "Tracciatura"
        '
        'mnuCalcola
        '

        Me.mnuCalcola.Text = "Calcola Tracciatura"
        '
        'mnuDisegna
        '

        Me.mnuDisegna.Text = "Disegna Tracciatura"
        '
        'mnu4sp
        '

        Me.mnu4sp.Text = "Calcola 4S/p"
        '
        'mnuElim
        '
        Me.mnuElim.Enabled = False

        Me.mnuElim.Text = "Elimina Dati Finali"
        '
        'mnuPref
        '

        Me.mnuPref.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuAree, Me.mnuLavori, Me.mnuStrategia, Me.mnuSoloPerif})
        Me.mnuPref.Text = "Preferenze"
        '
        'mnuAree
        '

        Me.mnuAree.Text = "Aree di Lavoro"
        '
        'mnuLavori
        '

        Me.mnuLavori.Text = "Tipo di Lavori"
        '
        'mnuStrategia
        '

        Me.mnuStrategia.Text = "Fattore strategia"
        '
        'mnuSoloPerif
        '

        Me.mnuSoloPerif.Text = "Dis. solo periferia"
        '
        'MenuItem6
        '

        Me.MenuItem6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuGuida, Me.mnuInformazioni})
        Me.MenuItem6.Text = "?"
        '
        'mnuGuida
        '

        Me.mnuGuida.Text = "Guida"
        '
        'mnuInformazioni
        '

        Me.mnuInformazioni.Text = "Informazioni"
        '
        'pctRisult
        '
        Me.pctRisult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctRisult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctRisult.Location = New System.Drawing.Point(656, 240)
        Me.pctRisult.Name = "pctRisult"
        Me.pctRisult.Size = New System.Drawing.Size(120, 211)
        Me.pctRisult.TabIndex = 0
        Me.pctRisult.TabStop = False
        '
        'panRisult
        '
        Me.panRisult.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panRisult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panRisult.Controls.Add(Me.cmdAggiorna)
        Me.panRisult.Controls.Add(Me.Label3)
        Me.panRisult.Location = New System.Drawing.Point(656, 216)
        Me.panRisult.Name = "panRisult"
        Me.panRisult.Size = New System.Drawing.Size(120, 24)
        Me.panRisult.TabIndex = 1
        '
        'cmdAggiorna
        '
        Me.cmdAggiorna.Location = New System.Drawing.Point(56, 2)
        Me.cmdAggiorna.Name = "cmdAggiorna"
        Me.cmdAggiorna.Size = New System.Drawing.Size(64, 20)
        Me.cmdAggiorna.TabIndex = 24
        Me.cmdAggiorna.Text = "Aggiorna"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Risultati"
        '
        'Timer1
        '
        Me.Timer1.Interval = 823
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.cmdDown)
        Me.Frame1.Controls.Add(Me.cmdLeft)
        Me.Frame1.Controls.Add(Me.cmdRight)
        Me.Frame1.Controls.Add(Me.cmdUp)
        Me.Frame1.Controls.Add(Me.cmdSpostOK)
        Me.Frame1.Location = New System.Drawing.Point(16, 48)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(88, 88)
        Me.Frame1.TabIndex = 2
        Me.Frame1.Visible = False
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDown.Image = CType(resources.GetObject("cmdDown.Image"), System.Drawing.Image)
        Me.cmdDown.Location = New System.Drawing.Point(32, 56)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(24, 32)
        Me.cmdDown.TabIndex = 4
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLeft.Image = CType(resources.GetObject("cmdLeft.Image"), System.Drawing.Image)
        Me.cmdLeft.Location = New System.Drawing.Point(0, 32)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(32, 24)
        Me.cmdLeft.TabIndex = 3
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRight.Image = CType(resources.GetObject("cmdRight.Image"), System.Drawing.Image)
        Me.cmdRight.Location = New System.Drawing.Point(56, 32)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(32, 24)
        Me.cmdRight.TabIndex = 2
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUp.Image = CType(resources.GetObject("cmdUp.Image"), System.Drawing.Image)
        Me.cmdUp.Location = New System.Drawing.Point(32, 0)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(24, 32)
        Me.cmdUp.TabIndex = 1
        '
        'cmdSpostOK
        '
        Me.cmdSpostOK.Image = CType(resources.GetObject("cmdSpostOK.Image"), System.Drawing.Image)
        Me.cmdSpostOK.Location = New System.Drawing.Point(32, 32)
        Me.cmdSpostOK.Name = "cmdSpostOK"
        Me.cmdSpostOK.Size = New System.Drawing.Size(24, 24)
        Me.cmdSpostOK.TabIndex = 0
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 452)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Items.AddRange(New Global.LancioMigration.LegacyStatusLabel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar1.Size = New System.Drawing.Size(778, 18)
        Me.StatusBar1.TabIndex = 3
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = True
        Me.StatusBarPanel1.Width = 10
        '
        'panStrumenti
        '
        Me.panStrumenti.Controls.Add(Me.cmdStampa)
        Me.panStrumenti.Controls.Add(Me.cmdDisTrk)
        Me.panStrumenti.Controls.Add(Me.cmdSalva)
        Me.panStrumenti.Controls.Add(Me.cmdCalcola)
        Me.panStrumenti.Controls.Add(Me.cmdDati)
        Me.panStrumenti.Controls.Add(Me.cmdApri)
        Me.panStrumenti.Controls.Add(Me.cmdElim)
        Me.panStrumenti.Controls.Add(Me.Break)
        Me.panStrumenti.Controls.Add(Me._cmdTraccia_2)
        Me.panStrumenti.Controls.Add(Me.cmdFull)
        Me.panStrumenti.Controls.Add(Me.cmdZoom)
        Me.panStrumenti.Location = New System.Drawing.Point(8, 0)
        Me.panStrumenti.Name = "panStrumenti"
        Me.panStrumenti.Size = New System.Drawing.Size(376, 32)
        Me.panStrumenti.TabIndex = 4
        '
        'cmdStampa
        '
        Me.cmdStampa.Image = CType(resources.GetObject("cmdStampa.Image"), System.Drawing.Image)
        Me.cmdStampa.Location = New System.Drawing.Point(192, 0)
        Me.cmdStampa.Name = "cmdStampa"
        Me.cmdStampa.Size = New System.Drawing.Size(24, 24)
        Me.cmdStampa.TabIndex = 49
        Me.ToolTip1.SetToolTip(Me.cmdStampa, "Esporta il disegno in formato DXF o RTF")
        Me.cmdStampa.Visible = False
        '
        'cmdDisTrk
        '
        Me.cmdDisTrk.Image = CType(resources.GetObject("cmdDisTrk.Image"), System.Drawing.Image)
        Me.cmdDisTrk.Location = New System.Drawing.Point(120, 0)
        Me.cmdDisTrk.Name = "cmdDisTrk"
        Me.cmdDisTrk.Size = New System.Drawing.Size(24, 24)
        Me.cmdDisTrk.TabIndex = 48
        Me.ToolTip1.SetToolTip(Me.cmdDisTrk, "Esegue il disegno quotato")
        '
        'cmdSalva
        '
        Me.cmdSalva.Image = CType(resources.GetObject("cmdSalva.Image"), System.Drawing.Image)
        Me.cmdSalva.Location = New System.Drawing.Point(24, 0)
        Me.cmdSalva.Name = "cmdSalva"
        Me.cmdSalva.Size = New System.Drawing.Size(24, 24)
        Me.cmdSalva.TabIndex = 47
        Me.ToolTip1.SetToolTip(Me.cmdSalva, "Salva il progetto")
        Me.cmdSalva.Visible = False
        '
        'cmdCalcola
        '
        Me.cmdCalcola.Image = CType(resources.GetObject("cmdCalcola.Image"), System.Drawing.Image)
        Me.cmdCalcola.Location = New System.Drawing.Point(96, 0)
        Me.cmdCalcola.Name = "cmdCalcola"
        Me.cmdCalcola.Size = New System.Drawing.Size(24, 24)
        Me.cmdCalcola.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.cmdCalcola, "Calcola e disegna la tracciatura")
        Me.cmdCalcola.Visible = False
        '
        'cmdDati
        '
        Me.cmdDati.Image = CType(resources.GetObject("cmdDati.Image"), System.Drawing.Image)
        Me.cmdDati.Location = New System.Drawing.Point(48, 0)
        Me.cmdDati.Name = "cmdDati"
        Me.cmdDati.Size = New System.Drawing.Size(24, 24)
        Me.cmdDati.TabIndex = 45
        Me.ToolTip1.SetToolTip(Me.cmdDati, "fornisci o modifica i dati iniziali")
        Me.cmdDati.Visible = False
        '
        'cmdApri
        '
        Me.cmdApri.Image = CType(resources.GetObject("cmdApri.Image"), System.Drawing.Image)
        Me.cmdApri.Location = New System.Drawing.Point(0, 0)
        Me.cmdApri.Name = "cmdApri"
        Me.cmdApri.Size = New System.Drawing.Size(24, 24)
        Me.cmdApri.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.cmdApri, "apri un progetto nuovo o uno esistente")
        '
        'cmdElim
        '
        Me.cmdElim.Image = CType(resources.GetObject("cmdElim.Image"), System.Drawing.Image)
        Me.cmdElim.Location = New System.Drawing.Point(72, 0)
        Me.cmdElim.Name = "cmdElim"
        Me.cmdElim.Size = New System.Drawing.Size(24, 24)
        Me.cmdElim.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.cmdElim, "Elimina i dati finali")
        Me.cmdElim.Visible = False
        '
        'Break
        '
        Me.Break.BackColor = System.Drawing.SystemColors.Control
        Me.Break.Cursor = System.Windows.Forms.Cursors.Default
        Me.Break.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Break.Image = CType(resources.GetObject("Break.Image"), System.Drawing.Image)
        Me.Break.Location = New System.Drawing.Point(272, 0)
        Me.Break.Name = "Break"
        Me.Break.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Break.Size = New System.Drawing.Size(24, 24)
        Me.Break.TabIndex = 41
        Me.ToolTip1.SetToolTip(Me.Break, "Interrompe l'elaborazione in corso")
        Me.Break.Visible = False
        '
        '_cmdTraccia_2
        '
        Me._cmdTraccia_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdTraccia_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTraccia_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdTraccia_2.Location = New System.Drawing.Point(296, 0)
        Me._cmdTraccia_2.Name = "_cmdTraccia_2"
        Me._cmdTraccia_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTraccia_2.Size = New System.Drawing.Size(64, 24)
        Me._cmdTraccia_2.TabIndex = 20
        Me._cmdTraccia_2.Text = "D.Interno"
        '
        'cmdFull
        '
        Me.cmdFull.Image = CType(resources.GetObject("cmdFull.Image"), System.Drawing.Image)
        Me.cmdFull.Location = New System.Drawing.Point(168, 0)
        Me.cmdFull.Name = "cmdFull"
        Me.cmdFull.Size = New System.Drawing.Size(24, 24)
        Me.cmdFull.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdFull, "Pieno schermo")
        '
        'cmdZoom
        '
        Me.cmdZoom.Image = CType(resources.GetObject("cmdZoom.Image"), System.Drawing.Image)
        Me.cmdZoom.Location = New System.Drawing.Point(144, 0)
        Me.cmdZoom.Name = "cmdZoom"
        Me.cmdZoom.Size = New System.Drawing.Size(24, 24)
        Me.cmdZoom.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmdZoom, "Premere qui per zoommare, poi ritagliare una finestra sul disegno")
        '
        'cmd4Ssp
        '
        Me.cmd4Ssp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd4Ssp.Image = CType(resources.GetObject("cmd4Ssp.Image"), System.Drawing.Image)
        Me.cmd4Ssp.Location = New System.Drawing.Point(592, 48)
        Me.cmd4Ssp.Name = "cmd4Ssp"
        Me.cmd4Ssp.Size = New System.Drawing.Size(48, 64)
        Me.cmd4Ssp.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmd4Ssp, "Calcolo del diametro equivalente per la resistenza al taglio secondo norme TEMA")
        Me.cmd4Ssp.Visible = False
        '
        'Picture1
        '
        Me.Picture1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.ContextMenuStrip = Me.mioContesto
        Me.Picture1.Location = New System.Drawing.Point(8, 40)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Size = New System.Drawing.Size(640, 411)
        Me.Picture1.TabIndex = 5
        Me.Picture1.TabStop = False
        '
        'mioContesto
        '
        Me.mioContesto.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.popTogli, Me.popCambia, Me.popToglTi, Me.popDimen, Me.popRuota, Me.popRuotaGen})
        '
        'popTogli
        '

        Me.popTogli.Text = "Togli"
        '
        'popCambia
        '

        Me.popCambia.Text = "Cambia"
        '
        'popToglTi
        '

        Me.popToglTi.Text = "ToglTi"
        '
        'popDimen
        '

        Me.popDimen.Text = "Dimen"
        '
        'popRuota
        '

        Me.popRuota.Text = "Ruota"
        '
        'popRuotaGen
        '

        Me.popRuotaGen.Text = "RuotaGen"
        '
        'Timer2
        '
        Me.Timer2.Interval = 20
        '
        'ListSelect
        '
        Me.ListSelect.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListSelect.Location = New System.Drawing.Point(656, 112)
        Me.ListSelect.Name = "ListSelect"
        Me.ListSelect.Size = New System.Drawing.Size(32, 17)
        Me.ListSelect.TabIndex = 44
        Me.ListSelect.Visible = False
        '
        'cmdTipPass
        '
        Me.cmdTipPass.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTipPass.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdTipPass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpString(Me.cmdTipPass, "")
        Me.cmdTipPass.Location = New System.Drawing.Point(-16, 34)
        Me.cmdTipPass.Name = "cmdTipPass"
        Me.cmdTipPass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.cmdTipPass, False)
        Me.cmdTipPass.Size = New System.Drawing.Size(128, 20)
        Me.cmdTipPass.TabIndex = 43
        Me.cmdTipPass.TabStop = False
        Me.cmdTipPass.Text = "command"
        '
        'ToolTipHelp
        '
        Me.ToolTipHelp.AutomaticDelay = 200
        '
        'Frame
        '
        Me.Frame.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame.Controls.Add(Me.cmdTipPass)
        Me.Frame.Location = New System.Drawing.Point(664, 24)
        Me.Frame.Name = "Frame"
        Me.Frame.Size = New System.Drawing.Size(96, 67)
        Me.Frame.TabIndex = 45
        Me.Frame.TabStop = False
        Me.Frame.Text = "Dati iniziali"
        '
        'frmTracciat
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(778, 491)
        Me.Controls.Add(Me.Frame)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.ListSelect)
        Me.Controls.Add(Me.cmd4Ssp)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.panStrumenti)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.panRisult)
        Me.Controls.Add(Me.pctRisult)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MainMenuStrip = Me.MainMenu1
        Me.Controls.Add(Me.MainMenu1)
        Me.MinimizeBox = False
        Me.Name = "frmTracciat"
        Me.Text = "TRACCIA"
        Me.panRisult.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.panStrumenti.ResumeLayout(False)
        Me.Frame.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Supporto aggiornamento "
    'Private Shared m_vb6FormDefInstance As frmTracciat
    'Private Shared m_InitializingDefInstance As Boolean
    'Public Shared Property DefInstance() As frmTracciat
    '    Get
    '        If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '            m_InitializingDefInstance = True
    '            m_vb6FormDefInstance = New frmTracciat
    '            m_InitializingDefInstance = False
    '        End If
    '        DefInstance = m_vb6FormDefInstance
    '    End Get
    '    Set(ByVal Value As frmTracciat)
    '        m_vb6FormDefInstance = Value
    '    End Set
    'End Property
#End Region
    Public Breckato As Boolean
    Public MenuClick As Short
    Public FuoriLayOut, Nelem As Short
    Public DELTAX, DELTAA As Single
    Public pictWidth, pictHeight As Single
    Public rutdis As Integer
    Private Calcolando As Boolean
    Private iGr(4, 19) As Short
    Private igr1() As Short = {0, 10, 2, 3, 4, 5, 6, 7, 8, 9, -10, -45}
    Private igr2() As Short = {0, 11, 11, 15, 24, 25, -27, 26, -13, 16, 21, -46, -51}
    Private igr3() As Short = {0, 9, 41, -14, -12, 17, 18, 30, -31, -32, -33}
    Private igr41() As Short = {0, 12, -19, 23, -28, 29, 34, 35, 36, -37, 22, -40, 38, 39}
    Private igr42() As Short = {0, 18, -19, 23, -28, 29, 34, 44, 42, 16, 43, 35, 36, -37, 22, -40, 47, 48, 49, 50}
    Private cod(16) As Short
    Private nominput(51) As String
    Friend MioContr() As System.Windows.Forms.Control
    Private xtub, ytub As Single
    Private isek, H As Short
    Private k, j As Short
    Private itir, isg As Short
    Private jsfa As Short
    Private xBot, xTop, yTop, yBot As Single
    Private Gia As Boolean
    Private ntir, jshe As Short
    Private icoo As String
    Private iExist As Boolean
    Private Raggio, Alfa As Single
    Private FrecciaDown As Double
    Private FrecciaUp As Double
    Private FrecciaLeft As Double
    Private FrecciaRight As Double
    Private Zooming As Boolean
    Public b As SolidBrush
    Public g As Graphics
    Public p As Pen
    Private Const npagine As Integer = 8
    Private Text1 As Text1Array
    Friend Pix As PixArray
    Friend Check1 As CheckArray
    Friend Label1, Label2 As LabelArray
    Friend Combo1, Combo2 As ComboArray
    Private Sub Legigr()
        Dim j As Short
        For j = 1 To CShort(igr1(1) + 1) : iGr(1, j) = igr1(j) : Next
        For j = 1 To CShort(igr2(1) + 1) : iGr(2, j) = igr2(j) : Next
        For j = 1 To CShort(igr3(1) + 1) : iGr(3, j) = igr3(j) : Next
        For j = 1 To CShort(igr41(1) + 1) : iGr(4, j) = igr41(j) : Next
        nominput(34) = at1(209) '"Eventuale d.int. corona [mm]"
    End Sub
    Private Sub Inizializza()
        Dim Ext1 As String
        Dim dH, dW As Single
        Dim Height0 As Integer = Height
        Dim Width0 As Integer = Width
        Ext1 = Monitor.Motore.Problem.Extension
        ReDim MioContr(60)
        If Len(Monitor.Motore.Inizio.Gancio) = 0 Then Monitor.Motore.Inizio.Gancio = Chr(32)
        Call InitDaTos()
        Call Legigr()
        Ncontr = 51
        Call Etichette()
        Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Top = 0
        Left = 0
        Me.WindowState = FormWindowState.Maximized
        'pctRisult.Left = CInt(Width - pctRisult.Width - GlobalRoutines.TwipsToPixelsX(200))
        'panRisult.Left = pctRisult.Left
        'dH = CSng(Height - Height0) ' CSng(Height - Picture1.Top - StatusBar1.Height - GlobalRoutines.TwipsToPixelsY(400) - Picture1.Height)
        'dW = CSng(Width - Width0) ' CSng(Width - Picture1.Left - pctRisult.Width - GlobalRoutines.TwipsToPixelsX(200) - Picture1.Width)
        'Picture1.Height = CInt(Picture1.Height + dH)
        'Picture1.Width = CInt(Picture1.Width + dW)
        'cmd4Ssp.Left = CInt(cmd4Ssp.Left + dW)
        'pctRisult.Height = CInt(Picture1.Height - pctRisult.Top - StatusBar1.Height - GlobalRoutines.TwipsToPixelsY(100))
        pictWidth = Picture1.ClientRectangle.Width
        pictHeight = Picture1.ClientRectangle.Height
        mnuEnable(False, 1, npagine)
        DELTAX = 1 : DELTAA = 1
        StatusBar1.Items(2).Text = "" '"dX=" + myStr(DELTAX, 2, 2, False) + " dA=" + myStr(DELTAA, 2, 2, False)
        p = New Pen(Color.Black)
        b = New SolidBrush(Color.Black)
        IniziaPagina()
    End Sub
    Private Sub Etichette()
        Dim i As Short
        'FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\TRAC01w.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To Ncontr
            nominput(i) = at1(106 + i) ' Trim(VB.Left(Riga, n - 1))
        Next
        'a$(1) = "Commessa (MAX 6 caratteri)"
        'a$(2) = "Diametro interno fasciame lato corpo"
        'a$(3) = "D.I. bocchello d'ingresso     [mm]  "
        'a$(4) = "D.I. Bocchello d'uscita       [mm]  "
        'a$(5) = "RO Bocchello d'ingresso   [kg/dm^3] "
        'a$(6) = "Portata ingresso          [kg/sec]  "
        'a$(7) = "RO uscita                 [kg/dm^3] "
        'a$(8) = "Portata  uscita           [kg/sec]  "
        'a$(9) = "Zona libera ingresso          [mm]  "
        'a$(10) = "Zona libera uscita           [mm]  "
        'a$(11) = "Numero di tubi"
        'a$(12) = "Indice  passo"
        'a$(13) = "Indice  tracciatura"
        'a$(14) = "(1=FIX/2=FLOAT/3=UTUBE)"
        'a$(15) = "D.E. Tubo scambiatore"
        'a$(16) = "Passo tubi scambiatori"
        'a$(17) = "Passo dei diaframmi"
        'a$(18) = "Passo primo diaframma"
        'a$(19) = "1=FERROSO/2=NON FERROSO"
        'a$(20) = "(0=MANDR. * 1=SALD )"
        'a$(21) = "Raggio tubi a U(0 = STD)"
        'a$(22) = "Passo iterazioni(0 = STD)"
        'a$(23) = "Larghezza di cava"
        'a$(24) = "Spessore dei tubi            [mm] "
        'a$(25) = "Spessore dei tubi           [BWG] "
        'a$(26) = "Lunghezza dei tubi           [mm] "
        'a$(27) = "1=AV.WALL / 2=MIN.WALL"
        'a$(28) = "1=SALD.+MND/2=SALD.+MND.LEGG/3=MND."
        'a$(29) = "Fattore di riduzione "
        'a$(30) = "% Taglio diafr. (negativo se area)"
        'a$(31) = "Angolo di taglio (0=HOR 90=VER)"
        'a$(32) = "Tipo di diaframmi"
        'a$(33) = "Piatto d'urto (0=NO 1=SI)"
        'a$(34) = "Eventuale diametro interno corona"
        'a$(35) = "Numero di sealing strips"
        'a$(36) = "Numero di rod runners"
        'a$(37) = "Tacche (0=NO 1=SU 2=GIU 3=SU/GIU)"
        'a$(38) = "Distanza tra tubi e setto orizz."
        'a$(39) = "Distanza tra tubi e setto vert."
        'a$(40) = "Indice OTL(0 = OTL MIN,1 = OTL MAX)"

    End Sub
    Private Sub DisegnoNonpronto()
        mnuCalcola.Enabled = False
        cmdCalcola.Visible = False
        mnuDisegna.Enabled = False
        cmdDisTrk.Visible = False
        mnu4sp.Enabled = False
        cmd4Ssp.Visible = False
    End Sub
    Private Sub cmdAggiorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAggiorna.Click
        If iPagina = 4 Then
            datiout(1)
        Else
            datiout(0)
        End If
    End Sub
    Private Sub mnuStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStampa.Click
        Dim Tipo As Short
        Dim Strin1(2) As String
        Dim Testo, Ext As String
        Dim Mode As Short
        Dim File As String
        Strin1(1) = "File di tipo DXF per AutoCAD"
        Strin1(2) = "File di tipo RTF per WinWord"
        Tipo = Monitor.Motore.Quale(2, "Periferica di stampa", Strin1, "", 2)
        Select Case Tipo
            Case 1 : Tipo = 2
                Testo = "Il file DXF viene registrato sotto" & vbCrLf
                Ext = "DXF"
            Case 2 : Tipo = 4
                Testo = "Il file RTF viene registrato sotto" & vbCrLf
                Ext = "RTF"
            Case Else : Exit Sub
        End Select
        Testo = Testo & "il nome " & RTrim(gencommes) & "T." & Ext
        Mode = 0
        File = RTrim(gencommes) & "T"
        Tracciatura.ScriviTraccia(File, Testo, Ext, Mode, Tipo, Nothing)
    End Sub
    Private Sub mnuSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalva.Click
        SaveAll()
        AggiornaTitoloFinestra()
    End Sub
    Public Sub mnuSalvaCome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalvaCome.Click
        Dim File As String, n As Integer
        SaveFileDialog1.InitialDirectory = Monitor.Motore.Inizio.Datidir
        Dim Ext0 As String = Monitor.Motore.Problem.Extension
        Dim Ext1 As String = Ext0.Substring(1, Ext0.Length - 1)
        SaveFileDialog1.Filter = Monitor.Motore.Problem.TipoFile & Ext0 & " (*" & Ext1 & ")|*" & Ext1
        SaveFileDialog1.ShowDialog()
        File = SaveFileDialog1.FileName
        n = File.IndexOf(".")
        If n > -1 Then File = File.Substring(0, n + 1)
        gencommes = File
        SaveAll()
        AggiornaTitoloFinestra()
    End Sub

    Private Sub mnuRM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRM.Click
        Timer1.Enabled = False
        SubTraccia(0)
        Tracciatura.SuperRMT()
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim tempo As Double
        If Tracciatura Is Nothing Then Exit Sub
        If iAction > 1 And Not iAction = 9 Then Exit Sub
        Try
            mnuElim.Enabled = False
            cmdElim.Visible = False
            If (iPagina = 2 Or iPagina = 3) And (DaTos(iDat).ILFINAL = 1 Or DaTos(iDat).ILFINAL = 0 _
            And DaTos(iDat).Elimin = 0) Then
                mnuElim.Enabled = True : cmdElim.Visible = True
                MenuFinali(True)
            End If
            If iPagina = 2 Then Exit Sub
            tempo = VB.Timer()
            If (tempo - FrecciaDown) > 0.5 And FrecciaDown <> 0 And cmdDown.Visible Then
                While FrecciaDown <> 0
                    cmdDown_MouseDown(sender, New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
            If (tempo - FrecciaUp) > 1 And FrecciaUp <> 0 And cmdUp.Visible Then
                While FrecciaUp <> 0
                    cmdUp_MouseDown(sender, New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
            If (tempo - FrecciaLeft) > 1 And FrecciaLeft <> 0 And cmdLeft.Visible Then
                While FrecciaLeft <> 0
                    cmdLeft_MouseDown(cmdLeft, New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
            If (tempo - FrecciaRight) > 1 And FrecciaRight <> 0 And cmdRight.Visible Then
                While FrecciaRight <> 0
                    cmdRight_MouseDown(cmdRight, New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
        Catch er As Exception
            MsgBox(er.Message + vbCrLf + er.StackTrace)
        End Try
    End Sub

    Private Sub mnuEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEsci.Click
        If Not Tracciatura.DaPPSM Then mnuChiudi_Click(Me, New EventArgs)
        Hide()
        Close()
        If Not StubWord Is Nothing Then StubWord.sQuit()
        Monitor.Routines.DoveBitmap.Dispose()
        Monitor.Routines.DoveDisegnogPic.Dispose()
        Monitor.Motore.Ammazza("Trac")
        rmTestiTraccia.ReleaseAllResources()
        rmHelpStrings.ReleaseAllResources()
        rmHelpTopics.ReleaseAllResources()
        g.Dispose()
        bmRisult.Dispose()
        gRisult.Dispose()
        Tracciatura = Nothing
    End Sub
    Private Sub cmdSpostOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSpostOK.Click
        cmdUp.Visible = True
        cmdDown.Visible = True
        cmdLeft.Visible = True
        cmdRight.Visible = True
        Frame1.Visible = False
        cmdZoom.Enabled = True
        cmdFull.Enabled = True
        mnuEnable(True, 0, npagine)
    End Sub
    Private Sub cmdUp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdUp.MouseDown
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim ForeColore As Color
        FrecciaUp = VB.Timer()
        VariatiDati = True
        VariatiOpfin = True
        Try
            Select Case FuoriLayOut
                Case 3 'Up tirante
                    ForeColore = p.Color
                    p.Color = Picture1.BackColor
                    g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                    g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                    DaTos(iDat).td(2, Nelem) = DaTos(iDat).td(2, Nelem) + DELTAX
                    p.Color = ForeColore
                    g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                    g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                    Picture1.Refresh()
                Case 4 'Up tondo
                    SpostaTondo(1)
                Case 51
                    p.DashStyle = Drawing2D.DashStyle.Solid
                    PiattoDimens(PX, PY)
                    ForeColore = b.Color
                    b.Color = Picture1.BackColor
                    g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                    DaTos(iDat).URTY(1) = DaTos(iDat).URTY(1) + DELTAX
                    b.Color = Color.Blue
                    g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                    g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                    b.Color = ForeColore
                    Picture1.Refresh()
                Case 52
                    p.DashStyle = Drawing2D.DashStyle.Solid
                    PiattoDimens(PX, PY)
                    ForeColore = b.Color
                    b.Color = Picture1.BackColor
                    g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                    DaTos(iDat).URTY(3) = DaTos(iDat).URTY(3) + DELTAX / 2
                    DaTos(iDat).URTY(1) = DaTos(iDat).URTY(1) + DELTAX / 2
                    PiattoDimens(PX, PY)
                    b.Color = Color.Blue
                    g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                    g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                    b.Color = ForeColore
                    Picture1.Refresh()
                Case 6
                    DaTos(iDat).seal(2, Nelem) = DaTos(iDat).seal(2, Nelem) + DELTAX
                    SecPun(Nelem)
                    PXPY(PX, PY, Nelem)
                    DisegnoSS(PX, PY, Nelem, 1)
                Case 61 'ruota SS
                    DaTos(iDat).seal(10, Nelem) = -6
                    DaTos(iDat).seal(7, Nelem) = CSng(DaTos(iDat).seal(7, Nelem) + _
                    System.Math.PI / 180 * DELTAA)
                    If DaTos(iDat).seal(7, Nelem) > 2 * System.Math.PI Then _
                    DaTos(iDat).seal(7, Nelem) = CSng(DaTos(iDat).seal(7, Nelem) - 2 * System.Math.PI)
                    SecPun(Nelem)
                    PXPY(PX, PY, Nelem)
                    DisegnoSS(PX, PY, Nelem, 1)
                Case 62 'slarga SS 3 sp. 5 altezza
                    DaTos(iDat).seal(3, Nelem) = DaTos(iDat).seal(3, Nelem) + DELTAX
                    SecPun(Nelem)
                    PXPY(PX, PY, Nelem)
                    DisegnoSS(PX, PY, Nelem, 1)
                Case 63 'ruota SS attorno al centro
                    With DaTos(iDat)
                        .seal(10, Nelem) = -6
                        .seal(7, Nelem) = CSng(.seal(7, Nelem) + System.Math.PI / 180 * DELTAA)
                        If .seal(7, Nelem) > 2 * System.Math.PI Then .seal(7, Nelem) = CSng(.seal(7, Nelem) - 2 * System.Math.PI)
                        Raggio = CSng(System.Math.Sqrt(.seal(1, Nelem) ^ 2 + .seal(2, Nelem) ^ 2))
                        Alfa = CSng(GlobalRoutines.arco(.seal(1, Nelem) / Raggio, .seal(2, Nelem) / Raggio) + System.Math.PI / 180 * DELTAA)
                        If Alfa > 2 * System.Math.PI Then Alfa = CSng(Alfa - 2 * System.Math.PI)
                        .seal(1, Nelem) = CSng(Raggio * System.Math.Cos(Alfa))
                        .seal(2, Nelem) = CSng(Raggio * System.Math.Sin(Alfa))
                    End With
                    SecPun(Nelem)
                    PXPY(PX, PY, Nelem)
                    DisegnoSS(PX, PY, Nelem, 1)
                Case 7
                    MuoviTaglio(1)
            End Select
        Catch er As Exception
            MsgBox(er.Message + vbCrLf + er.StackTrace)
        End Try
    End Sub
    Public Sub AggSecondaPagina()
        Dim k, j0, j As Short
        Dim Ind As Single
        If Not iPagina = 2 Then Exit Sub
        Aggiornando = True
        j0 = 0
        Try
            For k = 1 To 4
                For j = 1 To iGr(k, 1)
                    If iGr(k, j + 1) > 0 Then
                        If Not Text1(j + j0 - 1).BackColor.Equals(Color.Yellow) Then _
                               Text1(j + j0 - 1).Text = DaTos(0).dt(iGr(k, j + 1)).ToString
                        ' If iGr(k, j + 1) = 39 Then Stop
                    Else
                        If iGr(k, j + 1) = -46 Then
                            If DaTos(iDat).FilaCentraleStorta Then Check1(j + j0 - 1).CheckState = CheckState.Checked Else Check1(j + j0 - 1).CheckState = CheckState.Unchecked
                        Else
3510:                       Ind = DaTos(0).dt(-iGr(k, j + 1))
                            Select Case -iGr(k, j + 1)
                                Case 46
                                Case 51
                                    If Check1(20).Visible Then Check1(j + j0 - 1).Checked = DaTos(iDat).Passi4CurveVert
                                Case 13
                                    CType(MioContr(j + j0 - 1), ComboBox).SelectedIndex = CInt(Ind - 1) ' Traduci(-igr(k, j + 1), Ind)
                                    cmdTipPass.Text = Trim(MioContr(j + j0 - 1).Text)
                                Case 12, 14, 19, 27, 28 '12, 13, 14, 19, 27, 28 ' If Ind = 0 Then Ind = 1 + Ind
                                    CType(MioContr(j + j0 - 1), ComboBox).SelectedIndex = CInt(Ind - 1) ' Traduci(-igr(k, j + 1), Ind)
                                Case 10
                                    If Ind > 10 Then
                                        CType(MioContr(j + j0 - 1), ComboBox).SelectedIndex = -1
                                        MioContr(j + j0 - 1).Text = Ind.ToString
                                    Else
                                        CType(MioContr(j + j0 - 1), ComboBox).SelectedIndex = CInt(Ind) ' Traduci(-igr(k, j + 1), Ind)
                                    End If
                                Case Else
                                    CType(MioContr(j + j0 - 1), ComboBox).SelectedIndex = CInt(Ind) ' Traduci(-igr(k, j + 1), Ind)
                            End Select
                        End If
                    End If
                Next j
                j0 = iGr(k, 1) + j0
            Next k
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Aggiornando = False
    End Sub
    Public Sub mettileva(ByRef Mode As Short, ByVal ColoreInverso As Boolean)
        Dim ForeColore As Color
        Dim ym, X, y, xm As Single
        Dim ii As Short
        X = xtub : y = ytub : ym = -ytub : xm = xtub
        '??????????????????????
        If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(y - DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER Then X = X + DaTos(iDat).PassoOrizzontale
        '???????????????????????
        If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(ym - DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER Then xm = xm + DaTos(iDat).PassoOrizzontale
        'Mode=1: tirante in tubo
        ForeColore = p.Color
        If ColoreInverso Then p.Color = Picture1.BackColor
        g.DrawEllipse(p, X - (DaTos(iDat).dtubo / 2), y - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
        If jshe = 2 Then
            g.DrawEllipse(p, xm - (DaTos(iDat).dtubo / 2), ym - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
            If itir = 1 Then g.DrawEllipse(p, CSng(xm - (DaTos(iDat).dtubo / 2) * 0.7), CSng(ym - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7))
        End If
        If jshe = 3 Then
            g.DrawEllipse(p, -X - (DaTos(iDat).dtubo / 2), y - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
            If itir = 1 Then g.DrawEllipse(p, CSng(-X - (DaTos(iDat).dtubo / 2) * 0.7), CSng(y - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7))
        End If
        If itir = 1 Then g.DrawEllipse(p, CSng(X - (DaTos(iDat).dtubo / 2) * 0.7), CSng(y - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7))
        If ColoreInverso Then p.Color = ForeColore
        If Mode = 1 Then g.DrawEllipse(p, X - (DaTos(iDat).dtubo / 2), y - (DaTos(iDat).dtubo / 2), CSng(2 * (DaTos(iDat).dtubo / 2)), CSng(2 * (DaTos(iDat).dtubo / 2)))
        If Mode = 1 And jshe = 2 Then g.DrawEllipse(p, xm - (DaTos(iDat).dtubo / 2), ym - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
        If Mode = 1 And jshe = 3 Then g.DrawEllipse(p, -X - (DaTos(iDat).dtubo / 2), y - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
        Picture1.Refresh()
        DaTos(iDat).ktotal = DaTos(iDat).ktotal + isg
        If isek = 0 Then DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).NumeroTubiFila(j) + isg
        If jshe > 1 Then DaTos(iDat).ntus(j) = DaTos(iDat).NumeroTubiFila(j)
        If isek = 0 And jshe = 3 Then DaTos(iDat).NumeroTubiSettore(k + 1) = DaTos(iDat).NumeroTubiSettore(k + 1) + isg
        If isek = 1 Then DaTos(iDat).ntus(j) = DaTos(iDat).ntus(j) + isg
        If jshe = 3 Then DaTos(iDat).NumeroTubiFila(j) = DaTos(iDat).ntus(j)
        If isek = 1 And jshe = 3 Then DaTos(iDat).NumeroTubiSettore(k) = DaTos(iDat).NumeroTubiSettore(k) + isg
        DaTos(iDat).NumeroTubiSettore(k + isek) = DaTos(iDat).NumeroTubiSettore(k + isek) + isg
        If DaTos(iDat).CurveInPianoVert And DaTos(iDat).PassoFascio > 2 Then
            ii = 2 : If k + isek > 2 Then ii = -2
            DaTos(iDat).NumeroTubiSettore(k + isek + ii) = DaTos(iDat).NumeroTubiSettore(k + isek + ii) + isg
        End If
    End Sub
    Public Sub MettiTirante(ByRef Mode As Short, ByRef X As Single, ByRef y As Single)
        'Mode=1 kStr="D"' tubo in tirante
        Dim jj As Short
        Dim xx, yy As Single
        xx = X : yy = y
        For jj = 1 To 60
            If DaTos(iDat).td(1, jj) = 0 And DaTos(iDat).td(2, jj) = 0 Then GoTo 1254
        Next jj
        If jj >= 61 Then Beep() : Exit Sub
        DaTos(iDat).ntira = CShort(DaTos(iDat).ntira + 1)
1254:   If Mode = 1 Then Exit Sub
        If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(yy - DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER Then xx = xx + DaTos(iDat).PassoOrizzontale
        If xx ^ 2 + yy ^ 2 > DaTos(iDat).di1 ^ 2 / 4 Then Beep() : Exit Sub
        DaTos(iDat).td(1, jj) = xx
        DaTos(iDat).td(2, jj) = yy
        g.DrawEllipse(p, DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
        g.DrawEllipse(p, CSng(DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7))
        Picture1.Refresh()
        ntir = CShort(ntir + 1)
        If ntir < jj Then ntir = jj
    End Sub
    Public Sub TogliTirante(ByRef Mode As Short, ByRef X As Single, ByRef y As Single)
        'Mode=1 kStr="D"' tubo in tirante
        Dim jj As Short
        Dim xx, yy As Single
        Dim ForeColore As Color
        xx = X : yy = y
        If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(yy - DaTos(iDat).y(DaTos(iDat).kymax)) < clsTrigon.TOLER Then xx = xx + DaTos(iDat).PassoOrizzontale
        For jj = 1 To 60
            If (DaTos(iDat).td(1, jj) - xx) ^ 2 + (DaTos(iDat).td(2, jj) - yy) ^ 2 < clsTrigon.TOLER Then GoTo 1254
        Next jj
        If jj > DaTos(iDat).ntira Then Beep() : Exit Sub
1254:   DaTos(iDat).ntira = CShort(DaTos(iDat).ntira - 1)
        If Mode = 0 Then
            ForeColore = p.Color
            p.Color = Picture1.BackColor
            g.DrawEllipse(p, DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
            g.DrawEllipse(p, CSng(DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7))
            p.Color = ForeColore
        End If
        Picture1.Refresh()
        DaTos(iDat).td(1, jj) = 0
        DaTos(iDat).td(2, jj) = 0
        ntir = CShort(ntir - 1)
    End Sub
    Public Sub CancTir(ByRef Mode As Short)
        'Mode=1 kStr="C" tirante in tubo
        Dim jj As Short
        Dim ForeColore As Color
1236:   jj = Nelem 'CercaTir
        If jj = 0 Then MsgBox("Impossibile in CancTir") : jj = 1
1244:   If Mode = 0 Then
            ForeColore = p.Color
            p.Color = Picture1.BackColor
            g.DrawEllipse(p, DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2))
            g.DrawEllipse(p, CSng(DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7))
            p.Color = ForeColore
            Picture1.Refresh()
        End If
1238:   If jshe = 3 And Mode = 1 Then
            If jsfa = 1 Then jsfa = 0 : xcsi = -xcsi : GoTo 1249
            jsfa = 1 : xcsi = -xcsi
            ElimTir(jj) : GoTo 1236
        End If
        If jshe = 2 And Mode = 1 Then
            If jsfa = 1 Then jsfa = 0 : ypsi = -ypsi : GoTo 1249
            jsfa = 1 : ypsi = -ypsi
            ElimTir(jj) : GoTo 1236
        End If
1249:   ElimTir(jj)
    End Sub
    Private Sub ElimTir(ByVal jj As Short)
        DaTos(iDat).td(1, jj) = 0
        DaTos(iDat).td(2, jj) = 0
        If ntir > 0 Then ntir = CShort(ntir - 1)
    End Sub
    Private Function CercaTir() As Short
        Dim jj As Short
        For jj = 1 To DaTos(iDat).ntira
            If DaTos(iDat).td(2, jj) >= ypsi - (DaTos(iDat).dtubo / 2) And ypsi >= DaTos(iDat).td(2, jj) - (DaTos(iDat).dtubo / 2) Then
                If DaTos(iDat).td(1, jj) >= xcsi - (DaTos(iDat).dtubo / 2) And xcsi >= DaTos(iDat).td(1, jj) - (DaTos(iDat).dtubo / 2) Then CercaTir = jj : Exit Function
            End If
        Next jj
        CercaTir = 0
    End Function
    Private Sub MettiTondo(ByRef Mode As Short, ByRef X As Single, ByRef y As Single)
        Dim jj As Short
        Dim ypsiro, xcsiro As Single
        For jj = 1 To 60
            If DaTos(iDat).runn(1, jj) = 0 And DaTos(iDat).runn(2, jj) = 0 Then
                If X = 0 And y = 0 Then Beep() : Exit Sub
                If X = 0 Then X = -0.001
                If y = 0 Then y = -0.001
                ypsiro = y : xcsiro = X
                DaTos(iDat).Nrod = CShort(DaTos(iDat).Nrod + 1)
                DaTos(iDat).dt(36) = DaTos(iDat).Nrod
                AggiustaTondo(xcsiro, ypsiro, jj)
                Dim Colore As Color = b.Color
                b.Color = Color.Red
                g.FillEllipse(b, DaTos(iDat).runn(1, jj) - DaTos(iDat).runn(4, jj) / 2, DaTos(iDat).runn(2, jj) + 1 * System.Math.Sign(ypsi) - DaTos(iDat).runn(4, jj) / 2, DaTos(iDat).runn(4, jj), DaTos(iDat).runn(4, jj))
                b.Color = Colore
                Picture1.Refresh()
                Exit Sub
            End If
        Next jj
    End Sub
    Private Function CercaRod() As Short
        Dim isk, iski As Short
        Dim DistMin As Single
        Dim Yci, Xci, Dist As Single
        Dim diro As Single
        DistMin = 1.0E+20 : iski = 0
        For isk = 1 To DaTos(iDat).Nrod
            Yci = DaTos(iDat).runn(2, isk) - ypsi
            Xci = DaTos(iDat).runn(1, isk) - xcsi
            Dist = CSng(System.Math.Sqrt(Xci ^ 2 + Yci ^ 2))
            If Dist < DistMin Then
                DistMin = Dist : iski = isk
            End If
        Next isk
        If iski = 0 Then CercaRod = 0 : Exit Function
        diro = CSng(0.5 * DaTos(iDat).runn(4, iski))
        If DistMin < diro Then CercaRod = iski Else CercaRod = 0
    End Function
    Private Sub CancTondo()
        Dim jj, i As Short
        Dim diro As Single
        Dim ForeColore As Color
        Dim k As Short
        jj = Nelem 'CercaRod
        ForeColore = b.Color
        b.Color = Picture1.BackColor
        diro = CSng(0.5 * DaTos(iDat).runn(4, jj))
        g.FillEllipse(b, DaTos(iDat).runn(1, jj) - diro, DaTos(iDat).runn(2, jj) + 1 * System.Math.Sign(ypsi) - diro, 2 * diro, 2 * diro)
        b.Color = ForeColore
        Picture1.Refresh()
        For i = jj To 59
            For k = 1 To 4
                DaTos(iDat).runn(k, i) = DaTos(iDat).runn(k, i + 1)
            Next
        Next
        DaTos(iDat).runn(1, 60) = 0 : DaTos(iDat).runn(2, 60) = 0
        DaTos(iDat).Nrod = CShort(DaTos(iDat).Nrod - 1)
        DaTos(iDat).dt(36) = DaTos(iDat).Nrod
    End Sub
    Private Sub CambiaOTL()
        Dim Mess, Titolo As String
        Dim Default_Renamed, Risposta As String
        Dim Res As Boolean
        Risposta = " "
        If DaTos(iDat).ILFINAL = 0 Then Call SaveAll()
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
            'Mess = "Si vuole ridefinire l'OTL della corona esterna (E) o interna (I) ?"
            'Default = "E"
            'Titolo = "Variazione OTL"
            'Risposta = InputBox(Mess, Titolo, Default)
            If FuoriLayOut = 22 Then
                QualeCorona = 2
            End If
        End If
        iDat = CShort(QualeCorona - 1)
        Mess = "OTL massimo: " & Str(DaTos(iDat).otlmax) & vbCrLf
        Mess = Mess & "Nuovo OTL ?"
        Titolo = "Variazione OTL"
        Default_Renamed = Str(DaTos(iDat).OTL)
2002:   DaTos(iDat).otimp = CSng(GlobalRoutines.ValVir(InputBox(Mess, Titolo, Default_Renamed)))
        If DaTos(iDat).otimp > DaTos(iDat).otlmax + 1 Then DaTos(iDat).otimp = DaTos(iDat).otlmax + 1 : Beep()
        If DaTos(iDat).otimp = 0 Then DaTos(iDat).otimp = DaTos(iDat).OTL
2007:   Call nuotielle()
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana And FuoriLayOut = 22 Then
            QualeCorona = 1
        End If
        iDat = CShort(QualeCorona - 1)
        Res = inizio2()
    End Sub
    Private Sub CambiaITL()
        Dim Mess, Titolo As String
        Dim Default_Renamed, Risposta As String
        Dim Res As Boolean
        Risposta = " "
        If DaTos(iDat).ILFINAL = 0 Then Call SaveAll()
        If DaTos(iDat).TipoFascio = 4 Then
            If FuoriLayOut = 13 Then
                QualeCorona = 2 : iDat = 1
            End If
        End If
        Mess = "ITL massimo: " & Str(DaTos(iDat).otlmax) & vbCrLf
        Mess = Mess & "Nuovo ITL ?"
        Titolo = "Variazione ITL"
        Default_Renamed = Str(2 * DaTos(iDat).cinter)
2002:   DaTos(iDat).cinter = CSng(GlobalRoutines.ValVir(InputBox(Mess, Titolo, Default_Renamed)) / 2)
        If 2 * DaTos(iDat).cinter > DaTos(iDat).otlmax - 1 Then DaTos(iDat).cinter = (DaTos(iDat).otlmax + 1) / 2 : Beep()
2007:   Call nuitielle()
        If DaTos(iDat).TipoFascio = 4 And FuoriLayOut = 13 Then
            QualeCorona = 1 : iDat = 0
        End If
        Res = inizio2()
    End Sub
    Private Sub InitVista()
        DaTos(iDat).ILFINAL = 1 : DaTos(iDat).Elimin = 0
        If DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
            DaTos(1).ILFINAL = 1 : DaTos(1).Elimin = 0
            icoo = RTrim(gencommes) & ".COO"
            iExist = IO.File.Exists(icoo)
        End If
        jshe = 1
        If DaTos(iDat).CurveInPianoVert Then
            jshe = 2
        ElseIf DaTos(iDat).TipoFascio = traccia.clsTracciatura.TipiFascio.Utube Then
            jshe = 3
        End If
    End Sub
    Private Function Allerta() As VB.MsgBoxResult
        Dim Testo As String
        Allerta = MsgBoxResult.Yes
        If DaTos(iDat).TipoFascio < 4 Then Exit Function
        If Not iExist Then Exit Function
        Testo = "Devo cancellare i risultati del precedente infilaggio ?"
        If MsgBox(Testo, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Kill(icoo)
            icoo = icoo.Substring(0, icoo.Length - 3) & "RES"
            IO.File.Delete(icoo)
            icoo = icoo.Substring(0, icoo.Length - 3) & "MTO"
            IO.File.Delete(icoo)
            icoo = icoo.Substring(0, icoo.Length - 3) & "DXF"
            IO.File.Delete(icoo)
            iExist = False
        Else
            Allerta = MsgBoxResult.No
        End If
    End Function
    Private Sub MettiUrto()
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim FillColore As Color
        DaTos(iDat).EsistePiatto = True
        If DaTos(iDat).URTY(1) > 0.0! And DaTos(iDat).URTY(2) > 0.0! And DaTos(iDat).URTY(3) > 0.0! And DaTos(iDat).URTY(4) > 0.0! Then
        Else
            DaTos(iDat).URTY(1) = DaTos(iDat).y(DaTos(iDat).kymax) + DaTos(iDat).dtubo
            DaTos(iDat).URTY(2) = 100
            DaTos(iDat).URTY(4) = 100
            DaTos(iDat).URTY(3) = 5
        End If
        PiattoDimens(PX, PY)
        p.DashStyle = Drawing2D.DashStyle.Solid
        FillColore = b.Color
        b.Color = Color.Blue
        g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
        g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
        b.Color = FillColore
        Picture1.Refresh()
    End Sub
    Private Sub SetPopMenu(ByRef Mode As Short)
        popDimen.Visible = False
        popRuota.Visible = False
        popRuotaGen.Visible = False
        Select Case Mode
            Case 1 'tubo
                popTogli.Text = "Togli il tubo" '"T"
                popCambia.Text = "Converti in tirante" '"D"
                popTogli.Visible = True
                popCambia.Visible = True
                popToglTi.Visible = False
            Case 2 'tubo tolto
                popTogli.Text = "Metti un tubo" '"M"
                popCambia.Text = "Metti un tirante" '"F"
                popTogli.Visible = True
                popCambia.Visible = True
                popToglTi.Visible = False
            Case 3 'tirante
                popToglTi.Text = "Togli il tirante" '"E"
                popCambia.Text = "Converti in tubo" '"C"
                popTogli.Visible = False
                popCambia.Visible = True
                popToglTi.Visible = True
            Case 4
                popTogli.Text = "Metti tirante"
                popCambia.Text = "Metti rod runner"
                popToglTi.Text = "Metti piatto d'urto"
                popDimen.Text = "Metti piatto di tenuta"
                popTogli.Visible = True
                popCambia.Visible = True
                popToglTi.Visible = True
                popDimen.Visible = True
                If DaTos(iDat).URTY(1) > 0.0! Or DaTos(iDat).URTY(2) > 0.0! Or DaTos(iDat).URTY(3) > 0.0! Then popToglTi.Visible = False
            Case 5 'raggio shell
                popToglTi.Text = "Cambia Diametro Mantello"
                SetMenuOTL()
            Case 6 'OTL
                popToglTi.Text = "Cambia OTL"
                SetMenuOTL()
            Case 66 'OTL int
                popToglTi.Text = "Cambia OTL interno"
                SetMenuOTL()
            Case 7 'tirante fuori layout
                popCambia.Text = "Edita tirante"
                popToglTi.Text = "Togli tirante"
                popRuota.Text = "Muovi tirante"
                popTogli.Visible = False
                popCambia.Visible = True
                popToglTi.Visible = True
                popRuota.Visible = True
            Case 8 'tondo fuori layout
                popCambia.Text = "Edita tondo"
                popToglTi.Text = "Togli tondo"
                popRuota.Text = "Muovi tondo"
                popTogli.Visible = False
                popCambia.Visible = True
                popToglTi.Visible = True
                popRuota.Visible = True
            Case 9 'Piatto d'urto
                popTogli.Text = "Togli piatto"
                popCambia.Text = "Edita piatto"
                popToglTi.Text = "Muovi piatto"
                popDimen.Text = "Modifica piatto"
                popTogli.Visible = True
                popCambia.Visible = True
                popToglTi.Visible = True
                popDimen.Visible = True
            Case 10 ' SS
                popTogli.Text = "Togli S.Strip"
                popCambia.Text = "Edita S.Strip"
                popToglTi.Text = "Muovi S.Strip"
                popDimen.Text = "Modifica S.Strip"
                popRuota.Text = "Ruota S.Strip"
                popRuotaGen.Text = "Ruota al centro"
                popTogli.Visible = True
                popCambia.Visible = True
                popToglTi.Visible = True
                popDimen.Visible = True
                popRuota.Visible = True
                popRuotaGen.Visible = True
            Case 11 'tagli diaframmi
                popToglTi.Text = "Togli taglio"
                popRuota.Text = "Muovi taglio"
                popTogli.Visible = False
                popCambia.Visible = False
                popToglTi.Visible = True
                popRuota.Visible = True
            Case 12 'ITL
                popToglTi.Text = "Cambia ITL"
                SetMenuOTL()
            Case 13 'ITL interno
                popToglTi.Text = "Cambia ITL interno"
                SetMenuOTL()
        End Select
    End Sub
    Private Sub SetMenuOTL()
        popTogli.Visible = False
        popCambia.Visible = False
        popToglTi.Visible = True
        If Raggio < DaTos(iDat).di1 / 2 Then
            popTogli.Visible = True
            popCambia.Visible = True
            popDimen.Visible = True
            popTogli.Text = "Metti tirante"
            popCambia.Text = "Metti rod runner"
            popDimen.Text = "Metti piatto di tenuta"
        End If
    End Sub
    Private Sub MultiSelezione(ByRef Shift As Short)
        Dim Azione As Short
        Azione = ScelPopupMenu()
        If Azione > 3 Then
            Deseleziona()
            ListSelect.Tag = Str(Azione)
            Exit Sub
        End If
        If Shift = 2 Then
            If Len(ListSelect.Tag) = 0 Then
                Deseleziona()
                ListSelect.Items.Add(Str(xtub) & "|" & Str(ytub))
                ListSelect.Tag = Str(Azione)
            Else
                If GlobalRoutines.ValVir(CStr(ListSelect.Tag)) <> Azione Then
                    Deseleziona()
                    ListSelect.Items.Add(Str(xtub) & "|" & Str(ytub))
                    ListSelect.Tag = Str(Azione)
                Else
                    ListSelect.Items.Add(Str(xtub) & "|" & Str(ytub))
                End If
            End If
        Else
            Deseleziona()
            ListSelect.Items.Add(Str(xtub) & "|" & Str(ytub))
            ListSelect.Tag = Str(Azione)
        End If
        Dim Colore As Color = b.Color
        b.Color = Color.Blue
        g.FillRectangle(b, CSng(xtub - 0.3 * (DaTos(iDat).dtubo / 2)), CSng(ytub - 0.3 * (DaTos(iDat).dtubo / 2)), CSng(0.6 * (DaTos(iDat).dtubo / 2)), CSng(0.6 * (DaTos(iDat).dtubo / 2)))
        b.Color = Colore
        Picture1.Refresh()
    End Sub
    Private Function ScelPopupMenu() As Short
        Dim hh As Short
        If H = 0 Then Exit Function
        If Not FuoriReticolo Then
            hh = H
            If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(ytub + DaTos(iDat).y(DaTos(iDat).kymax)) _
            < clsTrigon.TOLER Then hh = CShort(hh + 1)
            If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(ytub - DaTos(iDat).y(DaTos(iDat).kymax)) _
            < clsTrigon.TOLER Then hh = CShort(hh - 1)
            Select Case DaTos(iDat).bu(j, hh)
                Case CChar("1") : ScelPopupMenu = 1 'tubo
                Case CChar("0") : ScelPopupMenu = 2 'tubo tolto
                Case CChar("2") : ScelPopupMenu = 3 'tirante
            End Select
        Else
            Select Case FuoriLayOut
                Case -1 : ScelPopupMenu = 4
                Case 1 : ScelPopupMenu = 5 'raggio shell
                Case 2 : ScelPopupMenu = 6 'OTL
                Case 3 : ScelPopupMenu = 7 'tirante fuori layout
                Case 4 : ScelPopupMenu = 8 'tondo fuori layout
                Case 5 : ScelPopupMenu = 9 'Piatto d'urto
                Case 6 : ScelPopupMenu = 10 ' SS
                Case 7 : ScelPopupMenu = 11 'tagli diaframmi
                Case 22 : ScelPopupMenu = 66 'OTL interno
                Case 12, 13 : ScelPopupMenu = FuoriLayOut
            End Select
        End If
    End Function
    Private Sub ExecPopupMenu()
        Dim n, Azione, i As Short
        Dim t As String
        Dim X, y As Single
        Azione = ScelPopupMenu()
        If ListSelect.Items.Count < 2 Then
            SetPopMenu(Azione)
        Else
            For i = 0 To CShort(ListSelect.Items.Count - 1)
                t = CStr(ListSelect.Items(i))
                n = CShort(t.IndexOf("|") + 1)
                X = CSng(GlobalRoutines.ValVir(VB.Left(t, n - 1)))
                y = CSng(GlobalRoutines.ValVir(VB.Right(t, Len(t) - n)))
                qualy(X, y, xtub, ytub, isek, H, j, k)
                If i = 0 Then
                    SetPopMenu(Azione)
                Else
                    Select Case MenuClick
                        Case 1 : popTogli_Click(popTogli, New System.EventArgs)
                        Case 2 : popToglTi_Click(popToglTi, New System.EventArgs)
                        Case 3 : popCambia_Click(popCambia, New System.EventArgs)
                    End Select
                End If
            Next
            Deseleziona()
        End If
    End Sub
    Private Sub Deseleziona()
        Dim i As Short
        Dim X, y As Single
        Dim t As String
        Dim n As Short
        Dim Colore As Color = b.Color
        b.Color = Picture1.BackColor
        For i = 0 To CShort(ListSelect.Items.Count - 1)
            t = CStr(ListSelect.Items(i))
            n = CShort(t.IndexOf("|") + 1)
            X = CSng(GlobalRoutines.ValVir(VB.Left(t, n - 1)))
            y = CSng(GlobalRoutines.ValVir(VB.Right(t, Len(t) - n)))
            g.FillRectangle(b, CSng(X - 0.3 * (DaTos(iDat).dtubo / 2)), _
            CSng(y - 0.3 * (DaTos(iDat).dtubo / 2)), CSng(0.6 * (DaTos(iDat).dtubo / 2)), _
            CSng(0.6 * (DaTos(iDat).dtubo / 2)))
        Next
        b.Color = Colore
        Picture1.Refresh()
        ListSelect.Items.Clear()
        ListSelect.Tag = ""
    End Sub
    Private Sub Aggiutu()
        Dim i As Short
        Select Case DaTos(iDat).CurveInPianoVert
            Case False
                MioContr(8).Visible = True
                Label1(8).Visible = True
                Label2(8).Visible = True
                i = CShort(DaTos(0).dt(10))
                Select Case i
                    Case 1, 2, 3, 4, 5
                        CType(MioContr(8), ComboBox).SelectedIndex = i
                    Case Else
                        'MioContr(8).ListIndex = 0
                        MioContr(8).Text = DaTos(0).dt(10).ToString
                End Select
            Case True
                'MioContr(8).Visible = False
                'Label1(8).Visible = False
                'Label2(8).Visible = False
                DaTos(0).dt(10) = 1
        End Select
    End Sub
    Private Sub IniziaPagina()
        Picture1.BackColor = Color.White
        Call Scarica()
        Dati(True)
        AggiornaTitoloFinestra()
        pctRisult.Visible = False
        panRisult.Visible = False
        _cmdTraccia_2.Visible = False
        cmdAggiorna.Visible = False
        cmdZoom.Visible = False
        cmdFull.Visible = False
    End Sub
    Private Sub cmdUp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdUp.MouseUp
        FrecciaUp = 0
    End Sub
    Private Sub cmdDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdDown.MouseDown
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim ForeColore As Color
        Dim Raggio, Alfa As Single
        VariatiDati = True
        VariatiOpfin = True
        FrecciaDown = VB.Timer()
        Select Case FuoriLayOut
            Case 3 'Down tirante
                ForeColore = p.Color
                p.Color = Picture1.BackColor
                g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                DaTos(iDat).td(2, Nelem) = DaTos(iDat).td(2, Nelem) - DELTAX
                p.Color = ForeColore
                g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                Picture1.Refresh()
            Case 4 'Down tondo
                SpostaTondo(-1)
            Case 51
                p.DashStyle = Drawing2D.DashStyle.Solid
                PiattoDimens(PX, PY)
                ForeColore = b.Color
                b.Color = Picture1.BackColor
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                DaTos(iDat).URTY(1) = DaTos(iDat).URTY(1) - DELTAX
                PiattoDimens(PX, PY)
                b.Color = Color.Blue
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                b.Color = ForeColore
                Picture1.Refresh()
            Case 52
                p.DashStyle = Drawing2D.DashStyle.Solid
                PiattoDimens(PX, PY)
                ForeColore = b.Color
                b.Color = Picture1.BackColor
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                If DaTos(iDat).URTY(3) > DELTAX Then
                    DaTos(iDat).URTY(3) = DaTos(iDat).URTY(3) - DELTAX / 2
                    DaTos(iDat).URTY(1) = DaTos(iDat).URTY(1) - DELTAX / 2
                Else
                    Beep()
                End If
                PiattoDimens(PX, PY)
                b.Color = Color.Blue
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                b.Color = ForeColore
                Picture1.Refresh()
            Case 6
                DaTos(iDat).seal(2, Nelem) = DaTos(iDat).seal(2, Nelem) - DELTAX
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 61 'ruota SS
                DaTos(iDat).seal(10, Nelem) = -6
                DaTos(iDat).seal(7, Nelem) = CSng(DaTos(iDat).seal(7, Nelem) - System.Math.PI / 180 * DELTAA)
                If DaTos(iDat).seal(7, Nelem) < -System.Math.PI Then DaTos(iDat).seal(7, Nelem) = CSng(DaTos(iDat).seal(7, Nelem) + 2 * System.Math.PI)
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 62 'slarga SS 3 sp. 5 altezza
                DaTos(iDat).seal(3, Nelem) = DaTos(iDat).seal(3, Nelem) - DELTAX
                If DaTos(iDat).seal(3, Nelem) < 1 Then DaTos(iDat).seal(3, Nelem) = 1
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 63 'ruota SS attorno al centro
                With DaTos(iDat)
                    .seal(10, Nelem) = -6
                    .seal(7, Nelem) = CSng(.seal(7, Nelem) - System.Math.PI / 180 * DELTAA)
                    If .seal(7, Nelem) < -System.Math.PI Then .seal(7, Nelem) = CSng(.seal(7, Nelem) + 2 * System.Math.PI)
                    Raggio = CSng(System.Math.Sqrt(.seal(1, Nelem) ^ 2 + .seal(2, Nelem) ^ 2))
                    Alfa = CSng(GlobalRoutines.arco(.seal(1, Nelem) / Raggio, .seal(2, Nelem) / Raggio) - System.Math.PI / 180 * DELTAA)
                    If Alfa < -System.Math.PI Then Alfa = CSng(Alfa + 2 * System.Math.PI)
                    .seal(1, Nelem) = CSng(Raggio * System.Math.Cos(Alfa))
                    .seal(2, Nelem) = CSng(Raggio * System.Math.Sin(Alfa))
                End With
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 7
                MuoviTaglio(-1)
        End Select


    End Sub
    Private Sub cmdDown_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdDown.MouseUp
        FrecciaDown = 0
    End Sub
    Private Sub cmdLeft_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeft.MouseDown
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim ForeColore As Color
        VariatiDati = True
        VariatiOpfin = True
        FrecciaLeft = VB.Timer()
        Select Case FuoriLayOut
            Case 3 'Left tirante
                ForeColore = p.Color
                p.Color = Picture1.BackColor
                g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                DaTos(iDat).td(1, Nelem) = DaTos(iDat).td(1, Nelem) - DELTAX
                p.Color = ForeColore
                g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                Picture1.Refresh()
            Case 52
                p.DashStyle = Drawing2D.DashStyle.Solid
                PiattoDimens(PX, PY)
                ForeColore = b.Color
                b.Color = Picture1.BackColor
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                DaTos(iDat).URTY(2) = DaTos(iDat).URTY(2) - DELTAX
                PiattoDimens(PX, PY)
                b.Color = Color.Blue
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                b.Color = ForeColore
                Picture1.Refresh()
            Case 6
                DaTos(iDat).seal(1, Nelem) = DaTos(iDat).seal(1, Nelem) - DELTAX
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 62 'slarga SS 3 sp. 5 altezza
                DaTos(iDat).seal(5, Nelem) = DaTos(iDat).seal(5, Nelem) - DELTAX
                If DaTos(iDat).seal(5, Nelem) < 10 Then DaTos(iDat).seal(5, Nelem) = 1
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 7
                MuoviTaglio(-1)
        End Select

    End Sub
    Private Sub cmdLeft_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeft.MouseUp
        FrecciaLeft = 0

    End Sub

    Private Sub cmdRight_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdRight.MouseDown
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim ForeColore As Color
        VariatiDati = True
        VariatiOpfin = True
        FrecciaRight = VB.Timer()
        Select Case FuoriLayOut
            Case 3 'Right tirante
                ForeColore = p.Color
                p.Color = Picture1.BackColor
                g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                DaTos(iDat).td(1, Nelem) = DaTos(iDat).td(1, Nelem) + DELTAX
                p.Color = ForeColore
                g.DrawArc(p, DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2), DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 2 * (DaTos(iDat).dtubo / 2), 0, 360)
                g.DrawArc(p, CSng(DaTos(iDat).td(1, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(DaTos(iDat).td(2, Nelem) - (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), CSng(2 * (DaTos(iDat).dtubo / 2) * 0.7), 0, 360)
                Picture1.Refresh()
            Case 52
                p.DashStyle = Drawing2D.DashStyle.Solid
                PiattoDimens(PX, PY)
                ForeColore = b.Color
                b.Color = Picture1.BackColor
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                DaTos(iDat).URTY(2) = DaTos(iDat).URTY(2) + DELTAX
                PiattoDimens(PX, PY)
                b.Color = Color.Blue
                g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                g.DrawRectangle(p, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
                b.Color = ForeColore
                Picture1.Refresh()
            Case 6
                DaTos(iDat).seal(1, Nelem) = DaTos(iDat).seal(1, Nelem) + DELTAX
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 62 'slarga SS 3 sp. 5 altezza
                DaTos(iDat).seal(5, Nelem) = DaTos(iDat).seal(5, Nelem) + DELTAX
                SecPun(Nelem)
                PXPY(PX, PY, Nelem)
                DisegnoSS(PX, PY, Nelem, 1)
            Case 7
                MuoviTaglio(1)
        End Select

    End Sub

    Private Sub cmdRight_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdRight.MouseUp
        FrecciaRight = 0

    End Sub

    Private Sub mnuApri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuApri.Click
        Dim ContrNome As String = ""
        Dim ContrFile As String = ""
        mnuChiudi_Click(Me, New EventArgs)
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        MenuFinali(False)
        Timer1.Enabled = False
        IniziaPagina()
        iPagina = 1
        mnuDati.Enabled = True
        cmdDati.Visible = True
        mnuChiudi.Enabled = True
        DisegnoNonpronto()
        If Monitor.Motore.Inizio.LavoriSciolti Then
            Monitor.Motore.Mostra(Reflection.Assembly.GetExecutingAssembly, 2)
        Else
            job = Monitor.Motore.Sceglijob(ContrNome, ContrFile)
            If Len(ContrFile) = 0 Then Exit Sub
            If Not job.Selezione Then gencommes = "" : Exit Sub
            With job.Comm
                If .indice > 0 Then
                    gencommes = Monitor.Motore.Inizio.Workdir & "\A" & .Arch & "\" & .Ind.Item(.indice).Data.File & ".VIP"
                Else
                    gencommes = ""
                    Exit Sub
                End If
            End With
            gencommes = gencommes.Substring(0, gencommes.Length - 4)
            Tracciatura.Modo = 1
            If Not Loadd() Then Exit Sub
            Text = GlobalRoutines.StringaInformativaProgramma(Reflection.Assembly.GetExecutingAssembly) & gencommes
            AggSecondaPagina()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub mnuDati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDati.Click
        kdati = 0
        IniziaPagina()
        Timer1.Enabled = True
        iPagina = 2
        DisegnaFontana()
        SecondaPagina()
        mnuEnable(False, 7, 7)
        mnuEnable(True, 1, 2)
        Text1Changed(0)
        Text1Changed(1)
        Text1Changed(7)
        ComboTextChanged(8, Combo1.Item(8), New System.EventArgs)
    End Sub
    Friend Sub Check1CheckStateChanged(ByVal Index As Short, ByVal e As System.EventArgs)
        Select Case Index
            Case 19
                DaTos(iDat).FilaCentraleStorta = (Check1(Index).CheckState = CheckState.Checked)
            Case 20
                DaTos(iDat).Passi4CurveVert = (Check1(Index).CheckState = CheckState.Checked)
                If DaTos(iDat).CurveInPianoVert <> DaTos(iDat).Passi4CurveVert Then DaTos(0).dt(38) = 0 : DaTos(0).dt(39) = 0
                DaTos(iDat).CurveInPianoVert = DaTos(iDat).Passi4CurveVert
                Aggiutu()
        End Select

    End Sub
    Friend Sub ComboTextChanged(ByVal Index As Short, ByVal c As ComboBox, ByVal e As System.EventArgs)
        Dim idt As Short
        Dim Zero As Boolean
        If InStr(c.Name, "Combo1") > 0 Then
            If Index = 8 Then 'y0out
                If Aggiornando Then Exit Sub
                'If Combo1(Index).ListIndex < 1 Then
                '      v = GlobalRoutines.ValVir(Combo1(Index).Text)
                'Else
                '      v = Combo1(Index).ListIndex
                'End If
                Zero = (Combo1(8).SelectedIndex < 1) Or Combo1(8).BackColor.Equals(Color.Yellow) ' Or v > 0
                Label1(2).Visible = Zero
                MioContr(2).Visible = Zero
                Zero = GlobalRoutines.ValVir(Text1(2).Text) > 0 And Text1(2).Visible
                Label1(5).Visible = Zero
                MioContr(5).Visible = Zero
                Label1(6).Visible = Zero
                MioContr(6).Visible = Zero
                If Not Zero Then
                    MioContr(5).Text = "0."
                    MioContr(6).Text = "0."
                End If
            End If
            idt = CShort(-GlobalRoutines.ValVir(GetTag(CStr(Label1(Index).Tag))))
            If Combo1(8).SelectedIndex > 0 Then
                DaTos(0).dt(idt) = Combo1(8).SelectedIndex
            Else
                DaTos(0).dt(idt) = CSng(GlobalRoutines.ValVir(Combo1(Index).Text))
            End If
            If Not Aggiornando Then VariatiDati = True
        Else
            If Not Aggiornando Then VariatiDati = True
        End If
    End Sub
    Friend Sub ComboSelectedIndexChanged(ByVal Index As Short, ByVal c As ComboBox, ByVal e As System.EventArgs)
        Dim idt As Short
        Dim Log1, Log2 As Boolean
        If InStr(c.Name, "Combo1") > 0 Then
            If Combo1(Index).SelectedIndex < 0 Then
                CType(MioContr(Index), ComboBox).SelectedIndex = 0
                MioContr(Index).Visible = False
                Label1(Index).Visible = False
            Else
                idt = CShort(-GlobalRoutines.ValVir(GetTag(CStr(Label1(Index).Tag))))
                Select Case idt
                    Case 12, 13, 14, 19, 27, 28
                        DaTos(0).dt(idt) = Combo1(Index).SelectedIndex + 1
                    Case Else
                        DaTos(0).dt(idt) = Combo1(Index).SelectedIndex
                End Select
                MioContr(Index).Visible = True
                Label1(Index).Visible = True
                If Index = 8 And DaTos(iDat).CurveInPianoVert Then
                    If Combo1(Index).SelectedIndex < 2 Or Combo1(Index).SelectedIndex > 3 Then
                        MostraAiuto(IDH_ERR_BADSYMM)
                        Combo1(Index).SelectedIndex = 2
                    End If
                    ComboTextChanged(8, Combo1(8), New System.EventArgs)
                End If
            End If
        Else
            idt = CShort(-GlobalRoutines.ValVir(GetTag(CStr(Label1(Index).Tag))))
            Select Case idt
                Case 12, 13, 19, 27, 28 '    ,13 PassoFascio,
                    DaTos(0).dt(idt) = Combo2(Index).SelectedIndex + 1
                    If idt = 12 Then Storto()
                    If idt = 13 Then Setiutu()
                Case 14 'tipo di fascio
                    Log1 = DaTos(0).dt(idt) = 4 Or Combo2(Index).SelectedIndex + 1 = 4
                    Log2 = Not (DaTos(0).dt(idt) = Combo2(Index).SelectedIndex + 1)
                    DaTos(0).dt(idt) = Combo2(Index).SelectedIndex + 1
                    If Log1 And Log2 Then
                        Enabled = False
                        Timer2.Enabled = True
                    End If
                    If Combo2(Index).SelectedIndex < 2 Then
                        MioContr(18).Visible = False 'raggio tubi ad U
                        Label1(18).Visible = False
                        Label2(18).Visible = False
                    Else
                        MioContr(18).Visible = True
                        Label1(18).Visible = True
                        Label2(18).Visible = True
                    End If
                    Setiutu()
                    If Combo2(Index).SelectedIndex = 2 Then
                        MioContr(9).Visible = False 'controllo fila mezzeria
                        Label1(9).Visible = False
                        Label2(9).Visible = False
                        FilaMezzeria = ControlloFilaMezzeria.NessunControllo
                    Else
                        MioContr(9).Visible = True
                        Label1(9).Visible = True
                        Label2(9).Visible = True
                    End If
                    Storto()
                Case Else
                    DaTos(0).dt(idt) = Combo2(Index).SelectedIndex
            End Select
        End If
    End Sub
    Private Sub Setiutu()
        MioContr(20).Visible = False
        Label1(20).Visible = False
        Label2(20).Visible = False
        If DaTos(0).TipoFascio = clsTracciatura.TipiFascio.Utube Then
            If DaTos(0).PassoFascio = clsTracciatura.PassiFascio._2U Then
                If Not DaTos(iDat).CurveInPianoVert Then DaTos(0).dt(38) = 0 : DaTos(0).dt(39) = 0
                DaTos(iDat).CurveInPianoVert = True
            ElseIf DaTos(0).PassoFascio = clsTracciatura.PassiFascio._4U Then
                MioContr(20).Visible = True
                Label1(20).Visible = True
                Label2(20).Visible = True
                If DaTos(iDat).CurveInPianoVert <> DaTos(iDat).Passi4CurveVert Then DaTos(0).dt(38) = 0 : DaTos(0).dt(39) = 0
                DaTos(iDat).CurveInPianoVert = DaTos(iDat).Passi4CurveVert
                If DaTos(iDat).CurveInPianoVert Then Check1(20).CheckState = CheckState.Checked Else Check1(20).CheckState = CheckState.Unchecked
            Else
                If DaTos(iDat).CurveInPianoVert Then DaTos(0).dt(38) = 0 : DaTos(0).dt(39) = 0
                DaTos(iDat).CurveInPianoVert = False
            End If
        Else
            If DaTos(iDat).CurveInPianoVert Then DaTos(0).dt(38) = 0 : DaTos(0).dt(39) = 0
            DaTos(iDat).CurveInPianoVert = False
        End If
        Aggiutu()
    End Sub
    Private Sub AggiornaTitoloFinestra()
        Dim icome, astring As String
        icome = gencommes.Trim
        astring = "nessuno"
        If Len(icome) = 0 Then icome = " "
        If Asc(icome) > 32 Then
            astring = icome
            mnuCalcola.Enabled = True
            cmdCalcola.Visible = True
        End If
        astring = " File corrente = " & astring
        'Print A$;
        If Asc(icome) > 32 Then
            astring = astring & "; dati finali: "
            If DaTos(iDat).ILFINAL = 0 Then
                If DaTos(iDat).Elimin = 1 Then
                    astring = astring & "assenti."
                Else
                    astring = astring & "presenti, di validità dubbia."
                    mnuDisegna.Enabled = True
                    cmdDisTrk.Visible = True
                    mnu4sp.Enabled = True
                    cmd4Ssp.Visible = True
                End If
            Else
                astring = astring & "presenti."
                mnuDisegna.Enabled = True
                cmdDisTrk.Visible = True
                mnu4sp.Enabled = True
                cmd4Ssp.Visible = True
            End If
        End If
        Me.Text = GlobalRoutines.StringaInformativaProgramma(Reflection.Assembly.GetExecutingAssembly) & astring
    End Sub
    Private Sub Storto()
        If Combo2(22).SelectedIndex <> 2 Or Combo2(23).SelectedIndex <> 2 Then
            MioContr(19).Visible = False
            Label1(19).Visible = False
        Else
            MioContr(19).Visible = True
            Label1(19).Visible = True
        End If
    End Sub
    Friend Sub Text1Changed(ByVal index As Short)
        Dim Zero As Boolean, i As Short
        If Aggiornando Then Exit Sub
        If index = 0 Or index = 10 Then 'diam mant e numero tubi
            If index = 0 And GlobalRoutines.ValVir(Text1(1).Text) > 0 And Text1(1).Visible Then
                DaTos(iDat).yin = 0
                Text1Leave(index, New System.EventArgs)
                Dati(True)
                DaTos(iDat).di1 = DaTos(iDat).di0
                YINOUT()
                Text1(7).Text = GlobalRoutines.myStr(DaTos(iDat).y0in, 4, 2, 0)
            End If
            If index = 0 And GlobalRoutines.ValVir(Text1(2).Text) > 0 And Text1(2).Visible Then
                DaTos(iDat).yout = 0
                Text1Leave(index, New System.EventArgs)
                Dati(True)
                DaTos(iDat).di1 = DaTos(iDat).di0
                YINOUT()
                MioContr(8).Text = GlobalRoutines.myStr(DaTos(iDat).yout, 4, 2, 0)
            End If
            Zero = (GlobalRoutines.ValVir(Text1(0).Text) = 0 Or GlobalRoutines.ValVir(Text1(10).Text) = 0)
            For i = 0 To CShort(Label1.Count - 1)
                If System.Math.Abs(GlobalRoutines.ValVir(GetTag(CStr(Label1(i).Tag)))) = 40 Then
                    Label1(i).Visible = Not Zero
                    MioContr(i).Visible = Not Zero
                    Exit For
                End If
            Next
        ElseIf index = 7 Then  'y0in
            'If Not Text1(7).Enabled Then Exit Sub
            Zero = (GlobalRoutines.ValVir(Text1(7).Text) = 0) Or Text1(7).BackColor.Equals(Color.Yellow) 'Or MioContr(8).ListIndex < 1 And GlobalRoutines.ValVir(MioContr(8).Text) = 0)
            Label1(1).Visible = Zero
            MioContr(1).Visible = Zero
            Zero = GlobalRoutines.ValVir(Text1(1).Text) > 0 And Text1(1).Visible
            Label1(3).Visible = Zero
            MioContr(3).Visible = Zero
            Label1(4).Visible = Zero
            MioContr(4).Visible = Zero
            If Not Zero Then
                MioContr(3).Text = "0."
                MioContr(4).Text = "0."
            End If
        ElseIf index = 1 Then  'diam bocch.ingresso
            Zero = GlobalRoutines.ValVir(Text1(index).Text) > 0 'Or Text1(Index).BackColor = vbYellow
            Label1(3).Visible = Zero
            MioContr(3).Visible = Zero
            Label1(4).Visible = Zero
            MioContr(4).Visible = Zero
            If Not Zero Then
                MioContr(3).Text = "0."
                MioContr(4).Text = "0."
            End If
            If GlobalRoutines.ValVir(Text1(index).Text) = 0 Then
                Text1(7).BackColor = System.Drawing.Color.White
                Text1(7).Enabled = True
                Text1Changed(7)
            Else
                Text1(7).BackColor = System.Drawing.Color.Yellow
                Text1(7).Enabled = False
                DaTos(iDat).yin = 0
                Text1Leave(index, New System.EventArgs)
                Dati(True)
                YINOUT()
                Text1(7).Text = GlobalRoutines.myStr(DaTos(iDat).yin, 4, 2, 0)
            End If
        ElseIf index = 2 Then  'diam bocch.uscita
            Zero = GlobalRoutines.ValVir(Text1(index).Text) > 0 'Or Text1(Index).BackColor = vbYellow
            Label1(5).Visible = Zero
            MioContr(5).Visible = Zero
            Label1(6).Visible = Zero
            MioContr(6).Visible = Zero
            If Not Zero Then
                MioContr(5).Text = "0."
                MioContr(6).Text = "0."
            End If
            If GlobalRoutines.ValVir(Text1(index).Text) = 0 Then
                MioContr(8).BackColor = System.Drawing.Color.White
                MioContr(8).Enabled = True
                ComboTextChanged(8, Combo1.Item(8), New System.EventArgs)
            Else
                MioContr(8).BackColor = System.Drawing.Color.Yellow
                MioContr(8).Enabled = False
                DaTos(iDat).yout = 0
                Text1Leave(index, New System.EventArgs)
                Dati(True)
                YINOUT()
                MioContr(8).Text = GlobalRoutines.myStr(DaTos(iDat).yout, 4, 2, 0)
            End If
        ElseIf index = 3 Or index = 4 Then
            DaTos(iDat).yin = 0
            Text1Leave(index, New System.EventArgs)
            Dati(True)
            YINOUT()
            If DaTos(iDat).yin = 0 Then
                Text1(7).BackColor = System.Drawing.Color.White
                Text1(7).Enabled = True
            Else
                Text1(7).BackColor = System.Drawing.Color.Yellow
                Text1(7).Enabled = False
            End If
            Text1(7).Text = GlobalRoutines.myStr(DaTos(iDat).y0in, 4, 2, 0)
        ElseIf index = 5 Or index = 6 Then
            DaTos(iDat).yout = 0
            Text1Leave(index, New System.EventArgs)
            Dati(True)
            YINOUT()
            If DaTos(iDat).yout = 0 Then
                MioContr(8).BackColor = System.Drawing.Color.White
                MioContr(8).Enabled = True
            Else
                MioContr(8).BackColor = System.Drawing.Color.Yellow
                MioContr(8).Enabled = False
                MioContr(8).Text = GlobalRoutines.myStr(DaTos(iDat).yout, 4, 2, 0)
            End If
            '     MioContr(8).Text = myStr(DaTos(iDat).yout, 4, 2, False)
        End If
        If Not Aggiornando Then VariatiDati = True
    End Sub
    Friend Sub Text1KeyPress(ByVal Index As Short, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Keys = CType(Asc(e.KeyChar), Keys)
        Select Case KeyAscii
            Case Keys.Return
                KeyAscii = 0
                On Error Resume Next
                Text1(Index + 1).Focus()
        End Select
        On Error GoTo 0
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Friend Sub Text1Leave(ByVal Index As Short, ByVal e As System.EventArgs)
        Dim idt As Short
        idt = CShort(GlobalRoutines.ValVir(GetTag(CStr(Label1(Index).Tag))))
        DaTos(0).dt(idt) = CShort(GlobalRoutines.ValVir(Text1(Index).Text))
    End Sub
    Friend Sub Text1MouseMove(ByVal Index As Short, ByVal EventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = CShort(EventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        Dim X As Single = EventArgs.X
        Dim y As Single = EventArgs.Y
    End Sub
    Private Sub mnuElim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuElim.Click
        MenuFinali(False)
        Elimina()
        AggiornaTitoloFinestra()
    End Sub
    Private Sub cmdFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFull.Click
        iAction = 0
        scalavi()
        Select Case iPagina
            Case 3 : Distraccia()
            Case 4 : Tracciatura.DisTrk(RTrim(gencommes) & ".TRK", RTrim(gencommes), 1, 1)
                DisTEMA((Tracciatura.icount))
        End Select
    End Sub
    Private Sub Scarica()
        Dim i As Short
        Try
            For i = 1 To Ncontr
                If Not MioContr(i) Is Nothing Then
                    If CStr(MioContr(i).Tag).IndexOf("T") > -1 Then cmdTipPass.Visible = False
                Else
                    cmdTipPass.Visible = False
                End If
            Next
            '   Text1.RemoveAll(1)
            '   Combo1.RemoveAll(1)
            '   Combo2.RemoveAll(1)
            '   Check1.RemoveAll(1)
            '   Pix.RemoveAll(1)
            '   Label1.RemoveAll(1)
            '   Label2.RemoveAll(1)
            'Label1(0).Visible = False
            'Text1(0).Visible = False
            Frame.Visible = False
            '   If Not g Is Nothing Then
            '   g.Clear(Color.White)
            '   End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggiustaTondo(ByVal xcsiro As Single, ByVal ypsiro As Single, ByRef jj As Short)
        Dim RAFITTI, Raggio As Single
        Dim diro As Single
        diro = CSng(0.5 * DaTos(iDat).runn(4, jj))
        If diro = 0 Then diro = 10 : DaTos(iDat).runn(4, jj) = 20
        RAFITTI = CSng(System.Math.Sqrt(xcsiro ^ 2 + ypsiro ^ 2) + diro)
        If RAFITTI + 20 > DaTos(iDat).di1 / 2 And RAFITTI - 20 < DaTos(iDat).di1 / 2 Then
            ypsiro = CSng(System.Math.Sqrt((DaTos(iDat).di1 / 2 - diro) ^ 2 - xcsiro ^ 2) * System.Math.Sign(ypsiro))
        End If
        Raggio = CSng(System.Math.Sqrt(xcsiro ^ 2 + ypsiro ^ 2))
        If Raggio > DaTos(iDat).di1 / 2 Then Beep() : Exit Sub
        DaTos(iDat).runn(1, jj) = xcsiro : DaTos(iDat).runn(2, jj) = ypsiro
        DaTos(iDat).runn(3, jj) = GlobalRoutines.arco(xcsiro / Raggio, ypsiro / Raggio)
    End Sub
    Private Sub SpostaTondo(ByRef i As Short)
        Dim ForeColore As Color
        Dim Raggio As Single
        ForeColore = b.Color
        b.Color = Picture1.BackColor
        g.FillEllipse(b, DaTos(iDat).runn(1, Nelem) - DaTos(iDat).runn(4, Nelem) / 2, DaTos(iDat).runn(2, Nelem) + 1 * System.Math.Sign(ypsi) - DaTos(iDat).runn(4, Nelem) / 2, DaTos(iDat).runn(4, Nelem), DaTos(iDat).runn(4, Nelem))
        AggiustaTondo(DaTos(iDat).runn(1, Nelem), DaTos(iDat).runn(2, Nelem), Nelem)
        DaTos(iDat).runn(3, Nelem) = CSng(DaTos(iDat).runn(3, Nelem) + i * System.Math.PI / 180 * DELTAA)
        Raggio = CSng(System.Math.Sqrt(DaTos(iDat).runn(1, Nelem) ^ 2 + DaTos(iDat).runn(2, Nelem) ^ 2))
        DaTos(iDat).runn(1, Nelem) = CSng(Raggio * System.Math.Cos(DaTos(iDat).runn(3, Nelem)))
        DaTos(iDat).runn(2, Nelem) = CSng(Raggio * System.Math.Sin(DaTos(iDat).runn(3, Nelem)))
        b.Color = Color.Red
        g.FillEllipse(b, DaTos(iDat).runn(1, Nelem) - DaTos(iDat).runn(4, Nelem) / 2, DaTos(iDat).runn(2, Nelem) + 1 * System.Math.Sign(ypsi) - DaTos(iDat).runn(4, Nelem) / 2, DaTos(iDat).runn(4, Nelem), DaTos(iDat).runn(4, Nelem))
        b.Color = ForeColore
        Picture1.Refresh()
    End Sub
    Private Function SulTaglio() As Short
        Dim i As Short
        Dim X, y As Single
        Select Case DaTos(iDat).tagli(9)
            Case 0 'no tagli
            Case 1 'orizzontale
                For i = 1 To 4
                    y = DaTos(iDat).tagli(i)
                    If System.Math.Abs(y) > 0.1 Then
                        If System.Math.Abs(ypsi - y) < 20 Then
                            SulTaglio = i
                            Exit Function
                        End If
                    End If
                Next
            Case 2 'verticale
                For i = 1 To 4
                    X = DaTos(iDat).tagli(i)
                    If System.Math.Abs(y) > 0.1 Then
                        If System.Math.Abs(xcsi - X) < 20 Then
                            SulTaglio = i
                            Exit Function
                        End If
                    End If
                Next
        End Select
    End Function

    Private Sub PiattoDimens(ByRef PX() As Single, ByRef PY() As Single)
        PX(1) = -DaTos(iDat).URTY(2) / 2
        PX(2) = PX(1) : PX(3) = -PX(1) : PX(4) = PX(3)
        PY(1) = DaTos(iDat).URTY(1)
        PY(2) = DaTos(iDat).URTY(1) + DaTos(iDat).URTY(3)
        PY(3) = PY(2) : PY(4) = PY(1)
    End Sub

    Private Function SulPiatto() As Boolean
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim Log1, Log2 As Boolean
        PiattoDimens(PX, PY)
        Log1 = ((xcsi - PX(1)) * (xcsi - PX(3))) < 0
        Log2 = ((ypsi - PY(1)) * (ypsi - PY(3))) < 0
        SulPiatto = Log1 And Log2
    End Function

    Private Sub TogliPiatto()
        Dim PX(4) As Single
        Dim PY(4) As Single
        Dim FillColore As Color
        Dim i As Short
        DaTos(iDat).EsistePiatto = False
        PiattoDimens(PX, PY)
        FillColore = b.Color
        b.Color = Picture1.BackColor
        g.FillRectangle(b, PX(1), PY(1), PX(3) - PX(1), PY(3) - PY(1))
        For i = 1 To 4 : DaTos(iDat).URTY(i) = 0.0! : Next
        b.Color = FillColore
        Picture1.Refresh()
    End Sub

    Private Sub MettiSS()
        Dim PX(4), PY(4) As Single
        Dim isk As Short
        Dim Raggio As Single
        Dim Dirx, SEA2, Diry As Single
        If DaTos(iDat).ISEAL > 59 Then
            MsgBox("Troppi piatti")
            Exit Sub
        End If
        For isk = 1 To DaTos(iDat).ISEAL
            If DaTos(iDat).seal(10, isk) = -7 Or DaTos(iDat).seal(10, isk) = -0 Then GoTo 1321
        Next isk
        isk = CShort(DaTos(iDat).ISEAL + 1) : DaTos(iDat).ISEAL = isk : DaTos(iDat).dt(35) = isk
1321:   DaTos(iDat).seal(10, isk) = -6
        DaTos(iDat).seal(1, isk) = xcsi
        DaTos(iDat).seal(2, isk) = ypsi
        DaTos(iDat).seal(3, isk) = 6
        DaTos(iDat).seal(5, isk) = 50
        '   DaTos(iDat).seal(7, isk) = 0
        Raggio = CSng(System.Math.Sqrt(DaTos(iDat).seal(1, isk) ^ 2 + DaTos(iDat).seal(2, isk) ^ 2))
        Dirx = DaTos(iDat).seal(1, isk) / Raggio
        Diry = DaTos(iDat).seal(2, isk) / Raggio
        DaTos(iDat).seal(7, isk) = GlobalRoutines.arco(Dirx, Diry)
        SEA2 = DaTos(iDat).seal(3, isk) / 2
        SecPun(isk)
        If DaTos(iDat).seal(8, isk) ^ 2 + DaTos(iDat).seal(9, isk) ^ 2 > (DaTos(iDat).di1 / 2) ^ 2 Then
            If DaTos(iDat).seal(8, isk) ^ 2 + DaTos(iDat).seal(9, isk) ^ 2 > DaTos(iDat).seal(1, isk) ^ 2 + DaTos(iDat).seal(2, isk) ^ 2 Then
                DaTos(iDat).seal(7, isk) = CSng(DaTos(iDat).seal(7, isk) + System.Math.PI)
                If DaTos(iDat).seal(7, isk) > 2 * System.Math.PI Then _
                DaTos(iDat).seal(7, isk) = CSng(DaTos(iDat).seal(7, isk) - 2 * System.Math.PI)
                SecPun(isk)
            End If
        End If
        PXPY(PX, PY, isk)
        DisegnoSS(PX, PY, isk, 1)
    End Sub
    Private Function CercaSS() As Short
        Dim isk, iski As Short
        Dim DistMin As Single
        Dim Yci, Xci, Dist As Single
        Dim CenX, Ang, CenY As Single
        Dim diSS As Single
        DistMin = 1.0E+20 : iski = 0
        For isk = 1 To DaTos(iDat).ISEAL
            Select Case DaTos(iDat).seal(10, isk)
                Case -1 : CalcDir(isk)
                    Ang = DaTos(iDat).seal(7, isk)
                Case -2, -3, -4, -5 : Ang = CSng(-2 * DaTos(iDat).seal(10, isk) * System.Math.PI / 4)
                    DaTos(iDat).seal(7, isk) = Ang
                Case -6 : Ang = DaTos(iDat).seal(7, isk)
                Case Else : GoTo 237
            End Select
            CenY = CSng(DaTos(iDat).seal(2, isk) + System.Math.Sin(Ang) * DaTos(iDat).seal(5, isk) / 2)
            CenX = CSng(DaTos(iDat).seal(1, isk) + System.Math.Cos(Ang) * DaTos(iDat).seal(5, isk) / 2)
            Yci = CenY - ypsi
            Xci = CenX - xcsi
            Dist = CSng(System.Math.Sqrt(Xci ^ 2 + Yci ^ 2))
            If Dist < DistMin Then
                DistMin = Dist : iski = isk
            End If
237:    Next isk
        If iski = 0 Then
            CercaSS = 0 : Exit Function
        End If
        diSS = DaTos(iDat).seal(5, iski)
        If DistMin < diSS Then
            CercaSS = iski
        Else
            CercaSS = 0
        End If
    End Function
    Private Sub mnuEnable(ByVal e As Boolean, ByVal istart As Integer, ByVal istop As Integer)
        Dim i As Integer
        For i = istart To istop
            Select Case i
                Case 1
                    Me.mnuDati.Enabled = e
                    Me.cmdDati.Visible = e
                Case 2
                    Me.mnuCalcola.Enabled = e
                    Me.cmdCalcola.Visible = e
                Case 3
                    Me.mnuTiranti.Enabled = e
                Case 4
                    Me.mnuTondi.Enabled = e
                Case 5
                    Me.mnuPiatti.Enabled = e
                Case 6
                    Me.mnuTagli.Enabled = e
                Case 7
                    Me.mnu4sp.Enabled = e
                    Me.cmd4Ssp.Visible = e
                Case 8
                    Me.mnuDisegna.Enabled = e
                    cmdDisTrk.Visible = e
            End Select
        Next
    End Sub
    Private Sub TogliSS()
        Dim twWidth, twLeft, twTop, twHeight As Single
        Dim ijk, isk, isk1 As Short
        isk = Nelem
        With Pix(isk)
            Try
                Dim delimiter As Char() = {CChar("|")}
                Dim s As String() = CStr(Tag).Split(delimiter)
                twTop = CSng(s(0))
                twLeft = CSng(s(1))
                twHeight = CSng(s(2))
                twWidth = CSng(s(3))
                Dim points1(0) As PointF
                points1(0) = New PointF(twLeft, twTop)
                Dim m As Matrix = g.Transform
                g.Transform = New Matrix
                g.DrawImage(.Image, points1(0))
                g.Transform = m
                Picture1.Refresh()
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
        '        Monitor.Routines.Scala(-XSC1, XSC1, -YSC1, YSC1, , True, p)
        Pix.UnLoad(isk)
        For isk1 = isk To CShort(DaTos(iDat).ISEAL - 1)
            For ijk = 1 To 10
                DaTos(iDat).seal(ijk, isk1) = DaTos(iDat).seal(ijk, isk1 + 1)
            Next ijk
            'Pix(isk1).Image = Pix(isk1 + 1).Image fatto automaticamente dalla lista contigua
        Next isk1
        Pix.UnLoad(DaTos(iDat).ISEAL)
        For ijk = 1 To 10 : DaTos(iDat).seal(ijk, DaTos(iDat).ISEAL) = 0 : Next ijk
        DaTos(iDat).seal(10, DaTos(iDat).ISEAL) = -7
        If DaTos(iDat).ISEAL > 0 Then
            DaTos(iDat).ISEAL = CShort(DaTos(iDat).ISEAL - 1)
            DaTos(iDat).dt(35) = DaTos(iDat).ISEAL
        End If
    End Sub
    Sub SecondaPagina()
        Dim i As Short
        Dim k, n As Short
        Dim Nome, TestoTool As String
        Dim j, jj, j0 As Short
        Dim Ncontr1, Ncontr2 As Short
        Dim NuovaW, NuovaH As Single
        Try
            For i = 1 To Ncontr
                Label2.Load(i, "Label2")
                Label1.Load(i, "Label1")
                Label2(i).Text = ""
                Label2(i).BringToFront()
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        MioContr(0) = Text1(0)
        Label1(0).Visible = True
        Text1(0).Visible = True
        j0 = 0
        If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then Legigr1() Else Legigr()
        For k = 1 To 4
            '      If k = 2 And GlobalRoutines.ValVir(dts(14)) = 4 Then A$(16) = "Passo tubi corona esterna"
            For j = 1 To iGr(k, 1)
                i = CShort(j + j0 - 1)
                jj = System.Math.Abs(iGr(k, j + 1))
                Label1(i).Tag = SetTag(CStr(Label1(i).Tag), Str(iGr(k, j + 1)))
                Try
                    If i > 0 Then
                        If iGr(k, j + 1) = -46 Then
                            Check1.Load(i)
                            MioContr(i) = Check1(i)
                        ElseIf iGr(k, j + 1) = -51 Then
                            Check1.Load(i)
                            MioContr(i) = Check1(i)
                        ElseIf iGr(k, j + 1) > 0 Then
                            Text1.Load(i)
                            MioContr(i) = Text1(i)
                        Else
                            If iGr(k, j + 1) = -10 Then
                                Combo1.Load(i, "Combo1")
                                MioContr(i) = Combo1(i)
                            ElseIf iGr(k, j + 1) = -13 Then
                                Combo2.Load(i, "Combo2")
                                Combo2(i).Tag = SetTag(CStr(Combo2(i).Tag), "T")
                                MioContr(i) = Combo2(i)
                            Else
                                Combo2.Load(i, "Combo2")
                                MioContr(i) = Combo2(i)
                            End If
                            ComboFill(jj, i)
                        End If
                    End If
                Catch e As Exception
                    MsgBox(e.Message + vbCrLf + e.StackTrace)
                End Try
                TestoTool = Monitor.Motore.Inizio.ConvertiCr(msgg(jj))
                Nome = nominput(jj)
                If i = 17 Or i = 16 Then
                    If DaTos(0).TipoFascio = traccia.clsTracciatura.TipiFascio.Fontana Then
                        MioContr(i).Tag = SetTag(CStr(MioContr(i).Tag), "No" & CStr(MioContr(i).Tag))
                        DaTos(0).PassoFascio = traccia.clsTracciatura.PassiFascio._2U
                        DaTos(0).dt(13) = DaTos(0).PassoFascio
                    End If
                End If
                If iGr(k, j + 1) = 29 Then 'Fattore di riduzione
                    MioContr(i).Tag = SetTag(CStr(MioContr(i).Tag), "No" & CStr(MioContr(i).Tag))
                End If
                n = CShort(Nome.IndexOf("[") + 1)
                If n > 0 Then
                    Label2(i).Text = VB.Right(Nome, Len(Nome) - n + 1)
                    Nome = VB.Left(Nome, n - 1)
                    Label2(i).Tag = SetTag(CStr(Label2(i).Tag), "0")
                Else
                    Label2(i).Tag = SetTag(CStr(Label2(i).Tag), "-1")
                End If
3500:           Label1(i).Text = Nome
                ToolTip1.SetToolTip(Label1(i), TestoTool)
            Next j
            j0 = iGr(k, 1) + j0
            If k = 2 Then Ncontr1 = CShort(j0 - 1)
            If k = 4 Then Ncontr2 = CShort(j0 - 1)
        Next k
        Try
            With HelpProvider1
                For i = 0 To Ncontr2
                    .SetHelpNavigator(MioContr(i), HelpNavigator.Topic)
                    .SetHelpKeyword(MioContr(i), HelpTopic(10 + i))
                    .SetShowHelp(MioContr(i), True)
                    .SetHelpNavigator(Label1(i), HelpNavigator.Topic)
                    .SetHelpKeyword(Label1(i), HelpTopic(10 + i))
                    .SetShowHelp(Label1(i), True)
                Next
                If DaTos(0).TipoFascio = 4 Then
                    .SetHelpKeyword(MioContr(34), HelpTopic(IDH_HID_DIAMINTCOREXT))
                    .SetHelpKeyword(MioContr(16), HelpTopic(IDH_HID_PASSOEXT))
                    .SetHelpKeyword(Label1(34), HelpTopic(IDH_HID_DIAMINTCOREXT))
                    .SetHelpKeyword(Label1(16), HelpTopic(IDH_HID_PASSOEXT))
                Else
                    .SetHelpKeyword(MioContr(34), HelpTopic(IDH_HID_EVDIAMINTCOR))
                    .SetHelpKeyword(Label1(34), HelpTopic(IDH_HID_EVDIAMINTCOR))
                End If
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Try
            For i = 0 To Ncontr1
                Label1(i).Left = Picture1.Left + 2
                Label1(i).Top = CInt((i + 0.1) * Label1(i).Height + Picture1.Top + 2)
                Label1(i).BringToFront()
                Label2(i).Left = Label1(i).Left + Label1(i).Width + 2
                Label2(i).Top = Label1(i).Top
                If InStr(CStr(MioContr(i).Tag), "T") > 0 Then
                    cmdTipPass.Left = Label2(0).Left + Label2(0).Width + 2
                    cmdTipPass.Top = Label1(i).Top
                Else
                    MioContr(i).Left = Label2(0).Left + Label2(0).Width + 2
                    MioContr(i).Top = Label1(i).Top
                    MioContr(i).TabIndex = i
                End If
                'cmdTipPass.Visible = False
                If Not CStr(MioContr(i).Tag).IndexOf("No") > -1 Then
                    If CStr(MioContr(i).Tag).IndexOf("T") < 0 Then
                        MioContr(i).Visible = True
                        MioContr(i).BringToFront()
                    Else
                        MioContr(i).Visible = False
                        cmdTipPass.Visible = True
                        cmdTipPass.BringToFront()
                    End If
                    Label1(i).Visible = True
                    If Not GetTag(CStr(Label2(i).Tag)) = "-1" Then Label2(i).Visible = True
                End If
                MioContr(i).Enabled = True
                Label1(i).Enabled = True
                Label2(i).Enabled = True
                If InStr(CStr(MioContr(i).Tag), "No") > 0 Then
                    MioContr(i).Visible = False
                    Label1(i).Visible = False
                End If
            Next
            For i = CShort(Ncontr1 + 1) To Ncontr2
                Label1(i).Left = MioContr(Ncontr1).Left + MioContr(Ncontr1).Width + 2
                Label1(i).Top = CInt((i - Ncontr1 - 1 + 0.1) * Label1(i).Height + Picture1.Top + 2)
                Label1(i).BringToFront()
                Label2(i).Left = Label1(i).Left + Label1(i).Width + 2
                Label2(i).Top = Label1(i).Top
                MioContr(i).Left = Label2(Ncontr1 + 1).Left + Label2(Ncontr1 + 1).Width + 2
                MioContr(i).Top = Label1(i).Top
                MioContr(i).TabIndex = i
                MioContr(i).BringToFront()
                If InStr(CStr(MioContr(i).Tag), "No") = 0 Then
                    MioContr(i).Visible = True
                    Label1(i).Visible = True
                Else
                    MioContr(i).Visible = False
                    Label1(i).Visible = False
                End If
                If Not GetTag(CStr(Label2(i).Tag)) = "-1" Then Label2(i).Visible = True
                MioContr(i).Enabled = True
                Label1(i).Enabled = True
                Label2(i).Enabled = True
            Next
            NuovaW = MioContr(Ncontr2).Left + MioContr(Ncontr2).Width + 7
            NuovaH = MioContr(Ncontr2).Top + MioContr(Ncontr2).Height + 7
            If Frame.Width < NuovaW Then Frame.Width = CInt(NuovaW)
            If Frame.Height < NuovaH Then Frame.Height = CInt(NuovaH)
            Frame.Top = Picture1.Top
            Frame.Left = Picture1.Left
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        '-----------------------------------------------
        Call AggSecondaPagina()
        '----------------------------------------------------
        Frame.Visible = True
        Frame.BringToFront()
    End Sub
    Private Sub Legigr1()
        Dim j As Short
        For j = 1 To CShort(igr42(1) + 1) : iGr(4, j) = igr42(j) : Next
        nominput(34) = at1(207) ' "Diam.int. corona esterna [mm]"
        nominput(16) = at1(208) ' "Passo tubi corona esterna [mm]"
    End Sub
    Private Sub ComboFill(ByRef idt As Short, ByRef ic As Short)
        Dim Ind, Ind1 As Short
        Dim i As Short
        Dim c As ComboBox = CType(MioContr(ic), ComboBox)
        c.Items.Clear()
        Try
            Select Case idt
                Case 10
                    c.Items.Add(at1(70))
                    For Ind = 1 To 5
                        c.Items.Add(at1(11 + Ind))
                    Next
                Case 12 ' If Ind = 0 Then Ind = 1       'TipoPasso
                    For Ind = 1 To 4
                        c.Items.Add(at1(19 + Ind))
                    Next
                Case 13 ': If Ind = 0 Then Ind = 1       'PassoFascio
                    For Ind = 1 To 11
                        c.Items.Add(at1(24 + Ind))
                    Next
                Case 14 ': If Ind = 0 Then Ind = 1       'TipoFascio
                    For Ind = 1 To 4
                        Ind1 = CShort(85 + Ind)
                        If Ind = 4 Then Ind1 = 91
                        c.Items.Add(at1(Ind1))
                    Next
                Case 19 ': If Ind = 0 Then Ind = 1      'ferroso non ferroso
                    For Ind = 1 To 2
                        c.Items.Add(at1(70 + Ind))
                    Next
                Case 20
                    For Ind = 1 To 2
                        c.Items.Add(at1(76 + Ind + 1))
                    Next
                Case 27 ': If Ind = 0 Then Ind = 1      'AW MW
                    For Ind = 1 To 2
                        c.Items.Add(at1(83 + Ind))
                    Next
                Case 28 ': If Ind = 0 Then Ind = 1      'ferroso non ferroso
                    For Ind = 1 To 3
                        c.Items.Add(at1(78 + Ind))
                    Next
                Case 31 ': If Ind > 0 Then Ind = 1
                    For Ind = 1 To 2
                        c.Items.Add(at1(81 + Ind))
                    Next
                Case 32
                    For i = 1 To 6
                        c.Items.Add(at1(91 + i))
                    Next
                Case 33 ': Traduci = Adjust(at1(88 + Ind + 1), 2)
                    For Ind = 1 To 2
                        c.Items.Add(at1(88 + Ind))
                    Next
                Case 37 ': Traduci = Adjust(at1(72 + Ind + 1), 19)
                    For Ind = 1 To 4
                        c.Items.Add(at1(72 + Ind))
                    Next
                Case 40 'OTL Max,Min
                    c.Items.Add(at1(98)) '"OTL minimo")
                    c.Items.Add(at1(99)) '"OTL massimo")
                Case 45 ': Traduci = Adjust(at1(44 + Ind), 32)
                    For Ind = 0 To 3
                        c.Items.Add(at1(44 + Ind))
                    Next
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub MuoviTaglio(ByRef i As Short)
        Monitor.Routines.ColoreTratto(Picture1.BackColor)
        DisTaglio(Nelem)
        DaTos(iDat).tagli(Nelem) = DaTos(iDat).tagli(Nelem) + i * DELTAX
        AggiustaTaglio(Nelem)
        Monitor.Routines.ColoreTratto(Picture1.ForeColor)
        DisTaglio(Nelem)
        Picture1.Refresh()
    End Sub
    Private Sub frmTracciat_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        p.Dispose()
        b.Dispose()
    End Sub
    Private Sub cmdZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdZoom.Click
        If Not Zooming Then
            Zooming = True
            Picture1.Cursor = Cursors.Cross
            Pix.RemoveAll(1)
            ToolTipHelp.Active = True
        Else
            Zooming = False
            Picture1.Cursor = Cursors.Default
            ToolTipHelp.Active = False
        End If
    End Sub
    Private Sub Picture1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseDown
        Dim Button As Short = CShort(e.Button \ &H100000)
        Dim Shift As Short = CShort(Control.ModifierKeys \ &H10000)
        Dim X As Single = e.X
        Dim y As Single = e.Y
        Select Case Button
            Case 1
                If Zooming Then
                    xTop = X
                    yTop = y
                    Gia = False
                Else
                    MultiSelezione(Shift)
                End If
            Case 2
                ExecPopupMenu()
        End Select

    End Sub

    Private Sub Picture1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseMove
        Dim Button As Short = CShort(e.Button \ &H100000)
        Dim Shift As Short = CShort(Control.ModifierKeys \ &H10000)
        Dim Testo As String
        Dim nn, hh As Short
        Dim Alfadeg As Single
        Dim delta As Single
        'Dim cDummy As New Control
        Dim x, y As Integer
        Dim points(0) As Point
        Static kvec, jvec, Hvec As Short
        Static xvec, yvec As Single
        If Tracciatura Is Nothing Then Exit Sub
        'If iPagina = 2 Then PictHelp.Visible = False : Exit Sub
        If iPagina = 2 Then ToolTipHelp.Active = False : Exit Sub
        'If iAction > 1 And iAgg > 0 Or Tracciatura.File5 = 0 Then PictHelp.Visible = False : Exit Sub
        If iAction > 1 And iAgg > 0 Then ToolTipHelp.Active = False : Exit Sub
        If Frame1.Visible Then Exit Sub
        If Calcolando Then Exit Sub
        If g Is Nothing Then Exit Sub
        Try
            points(0) = New Point(e.X, e.Y)
            Dim m As Matrix = g.Transform.Clone
            m.Invert()
            m.TransformPoints(points)
            x = points(0).X : y = points(0).Y
            If Button = 1 And Zooming Then
                Dim r As New Rectangle(CInt(xTop), CInt(yTop), CInt(xBot - xTop), CInt(yBot - yTop))
                If Gia Then
                    r = Picture1.RectangleToScreen(r)
                    ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
                Else
                    Gia = True
                End If
                xBot = e.X : yBot = e.Y
                r = New Rectangle(CInt(xTop), CInt(yTop), CInt(xBot - xTop), CInt(yBot - yTop))
                r = Picture1.RectangleToScreen(r)
                ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
                Exit Sub
            End If
            xcsi = x : ypsi = y
            If (x - xvec) ^ 2 + (y - yvec) ^ 2 < (DaTos(iDat).dtubo / 2) ^ 2 / 2 Then
                Exit Sub
            End If
            xvec = x : yvec = y
            If iPagina = 3 And Not Zooming Then
                If Not InStr(StatusBar1.Items(0).Text, "Non è") = 1 Then StatusBar1.Items(0).Text = "x=" & GlobalRoutines.myStr(CSng(x), 5, 2, 0) & " y=" & GlobalRoutines.myStr(CSng(y), 5, 2, 0)
                Try
                    Raggio = CSng(System.Math.Sqrt(x * x + y * y))
                Catch
                    Exit Sub
                End Try
                Alfa = GlobalRoutines.arco(x / Raggio, y / Raggio)
                Alfadeg = CSng(Alfa * 180 / System.Math.PI)
                StatusBar1.Items(1).Text = "R=" & GlobalRoutines.myStr(Raggio, 5, 2, 0) & " a=" & GlobalRoutines.myStr(Alfadeg, 3, 2, 0) & "°"
                StatusBar1.Items(2).Text = "dX=" & GlobalRoutines.myStr(DELTAX, 2, 2, 0) & " dA=" & GlobalRoutines.myStr(DELTAA, 2, 2, 0)
                If DaTos(iDat).TipoFascio = 4 Then
                    If Raggio < (DaTos(1).OTL + 2 * DaTos(iDat).cinter) / 4 Then
                        QualeCorona = 2
                    Else
                        QualeCorona = 1
                    End If
                End If
                qualy(CSng(x), CSng(y), xtub, ytub, isek, H, j, k)
                FuoriLayOut = 0
                If FuoriReticolo Then  'non siamo sul reticolo
                    jvec = 0 : kvec = 0
                    'PictHelp.Visible = False
                    ToolTipHelp.Active = False
                    delta = System.Math.Abs(Raggio - DaTos(iDat).di1 / 2)
                    Testo = "Diametro interno mantello" & vbCrLf & Str(2 * DaTos(iDat).di1 / 2)
                    FuoriLayOut = 1
                    If System.Math.Abs(Raggio - DaTos(iDat).OTL / 2) < delta Then
                        delta = System.Math.Abs(Raggio - DaTos(iDat).OTL / 2)
                        Testo = "OTL" & Str(DaTos(iDat).OTL)
                        FuoriLayOut = 2
                    End If
                    If DaTos(iDat).cinter > 0 Then
                        If System.Math.Abs(Raggio - DaTos(iDat).cinter) < delta Then
                            delta = System.Math.Abs(Raggio - DaTos(iDat).cinter)
                            Testo = "ITL" & Str(2 * DaTos(iDat).cinter)
                            FuoriLayOut = 12
                        End If
                    End If
                    If DaTos(iDat).TipoFascio = 4 Then
                        If System.Math.Abs(Raggio - DaTos(1).OTL / 2) < delta Then
                            delta = System.Math.Abs(Raggio - DaTos(1).OTL / 2)
                            Testo = "OTL" & Str(DaTos(1).OTL)
                            FuoriLayOut = 22
                        End If
                        If DaTos(1).cinter > 0 Then
                            If System.Math.Abs(Raggio - DaTos(1).cinter) < delta Then
                                delta = System.Math.Abs(Raggio - DaTos(1).cinter)
                                Testo = "ITL" & Str(2 * DaTos(1).cinter)
                                FuoriLayOut = 13
                            End If
                        End If
                    End If
                    nn = CercaTir()
                    If nn > 0 Then
                        Nelem = nn
                        delta = 0
                        FuoriLayOut = 3
                        Testo = "Tirante n°" & Str(Nelem)
                    End If
                    nn = CercaRod()
                    If nn > 0 Then
                        Nelem = nn
                        delta = 0
                        FuoriLayOut = 4
                        Testo = "Tondo n°" & Str(Nelem)
                    End If
                    If SulPiatto() Then
                        delta = 0
                        FuoriLayOut = 5
                        Testo = "Piatto d'urto"
                    End If
                    nn = CercaSS()
                    If nn > 0 Then
                        Nelem = nn
                        delta = 0
                        FuoriLayOut = 6
                        Testo = "S.Strip n°" & Str(Nelem)
                    End If
                    nn = SulTaglio()
                    If nn > 0 Then
                        Nelem = nn
                        delta = 0
                        FuoriLayOut = 7
                        Testo = "Taglio diaf. n°" & Str(Nelem)
                    End If
                    If delta / Raggio < 0.05 Then
                        points(0).Y = CInt(y - (DaTos(iDat).dtubo / 2))
                        points(0).X = CInt(x - (DaTos(iDat).dtubo / 2))
                        g.Transform.TransformPoints(points)
                        ToolTipHelp.SetToolTip(Picture1, Testo)
                        ToolTipHelp.Active = True
                    Else
                        FuoriLayOut = -1
                    End If
                End If
                If Not FuoriReticolo Then  'siamo su un tubo
                    If Not InStr(StatusBar1.Items(0).Text, "Non è") = 1 Then _
                    StatusBar1.Items(0).Text = "x=" & GlobalRoutines.myStr(xtub, 5, 2, 0) & _
                    " y=" & GlobalRoutines.myStr(ytub, 5, 2, 0)
                    Raggio = CSng(System.Math.Sqrt(xtub * xtub + ytub * ytub))
                    If Raggio = 0 Then
                        Alfa = 0
                    Else
                        Alfa = GlobalRoutines.arco(xtub / Raggio, ytub / Raggio)
                    End If
                    Alfadeg = CSng(Alfa * 180 / System.Math.PI)
                    StatusBar1.Items(1).Text = "R=" & GlobalRoutines.myStr(Raggio, 5, 2, 0) & _
                    " a=" & GlobalRoutines.myStr(Alfadeg, 3, 2, 0) & "°"
                End If
                If Not FuoriReticolo And (j <> jvec Or k <> kvec Or H <> Hvec) Then
                    ToolTipHelp.Active = False
                    jvec = j : kvec = k : Hvec = H
                    points(0).Y = CInt(ytub - (DaTos(iDat).dtubo / 2))
                    points(0).X = CInt(xtub - (DaTos(iDat).dtubo / 2))
                    g.Transform.TransformPoints(points)
                    Testo = "Fila" & Str(j) & vbCrLf
                    Testo = Testo & "Sett" & Str(k) & vbCrLf
                    hh = H
                    If DaTos(iDat).FilaCentraleStorta And j = DaTos(iDat).kymax Then
                        hh = CShort(hh + 1)
                    End If
                    Testo = Testo & "Tubo" & Str(hh)
                    Select Case DaTos(iDat).bu(j, hh)
                        Case CChar("0")
                            Testo = Testo & vbCrLf & "assente"
                        Case CChar("2")
                            nn = CercaTir()
                            If nn = 0 Then
                                Testo = Testo & vbCrLf & "ERRORE"
                            Else
                                Testo = Testo & vbCrLf & "Tirante" & Str(nn)
                            End If
                        Case Else
                    End Select
                    ToolTipHelp.SetToolTip(Picture1, Testo)
                    ToolTipHelp.Active = True
                End If
            Else
                    StatusBar1.Items(0).Text = ""
            End If
        Catch er As Exception
            MsgBox(er.Message + vbCrLf + er.StackTrace)
        End Try
    End Sub
    Private Sub Picture1_MouseUp(ByVal sender As Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseUp
        Dim Button As Short = CShort(eventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        Dim X As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        Dim points(1) As PointF
        Dim x0, y0, x1, y1 As Single
        If Not Zooming Then Exit Sub
        Zooming = False
        Picture1.Cursor = Cursors.Default
        points(0) = New PointF(xBot, yBot)
        points(1) = New PointF(xTop, yTop)
        Dim m As Matrix = g.Transform.Clone
        m.Invert()
        m.TransformPoints(points)
        x1 = points(1).X : y1 = points(1).Y
        x0 = points(0).X : y0 = points(0).Y
        If x1 < x0 Then GlobalRoutines.SWAP(x1, x0)
        If y1 < y0 Then GlobalRoutines.SWAP(y1, y0)
        If Not Monitor.Routines.Scala(x0, x1, y0, y1, , True, p) Then Exit Sub
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        g.Clear(Color.Turquoise)
        Dim Colore As Color = b.Color
        b.Color = Color.FromArgb(200, 255, 255)
        g.FillRectangle(b, x0, y0, x1 - x0, y1 - y0)
        b.Color = Colore
        g.DrawRectangle(p, x0, y0, x1 - x0, y1 - y0)
        Select Case iPagina
            Case 3 : Distraccia(True)
            Case 4
                Tracciatura.DisTrk(RTrim(gencommes) & ".TRK", RTrim(gencommes), 1, 1)
                DisTEMA((Tracciatura.icount))
        End Select
        Cursor = System.Windows.Forms.Cursors.Default
        Picture1.Refresh()
    End Sub
    Private Sub StatusBar1_PanelClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusBar1.ItemClicked
        Dim FV_Renamed As Short
        If e.ClickedItem Is StatusBar1.Items(2) Then
            FV_Renamed = FuoriLayOut
            FuoriLayOut = 100
            frmEdita.DefInstance.Left = StatusBar1.Items(0).Width + StatusBar1.Items(1).Width
            frmEdita.DefInstance.Top = CInt(StatusBar1.Top - frmEdita.DefInstance.Height - GlobalRoutines.TwipsToPixelsY(200))
            frmEdita.DefInstance.ShowDialog()
            frmEdita.DefInstance.Dispose()
            StatusBar1.Items(2).Text = "dX=" & GlobalRoutines.myStr(DELTAX, 2, 2, 0) & _
            " dA=" & GlobalRoutines.myStr(DELTAA, 2, 2, 0)
            FuoriLayOut = FV_Renamed
        End If
    End Sub
    Private Sub cmdFull_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdFull.MouseMove
        Dim Testo As String
        If Frame1.Visible Then Exit Sub
        Testo = "Premere qui per ritornare" & Chr(13)
        Testo = Testo & "alla vista completa"
        ToolTip1.SetToolTip(cmdFull, Testo)
    End Sub
    Private Sub cmdTipPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTipPass.Click
        Dim c As System.Windows.Forms.ComboBox
        For Each c In Combo2
            If CStr(c.Tag).IndexOf("T") > -1 Then GoTo ContP
        Next c
        MsgBox("Errore imprevisto in cmdTipPass_Click", MsgBoxStyle.Critical)
        Exit Sub
ContP:
        With PASSI.DefInstance
            .Picture1(11).Visible = False
            If DaTos(0).TipoFascio = 3 Then
                .Picture1(0).Visible = False
                .Picture1(2).Visible = False
                .Picture1(3).Visible = False
                .Picture1(4).Visible = False
                .Picture1(6).Visible = False
                .Picture1(8).Visible = False
                .Picture1(10).Visible = False
            End If
            .indice = CShort(c.SelectedIndex)
            .ShowDialog()
            c.SelectedIndex = .indice
            Dim ii As Integer = CInt(GlobalRoutines.ValVir(GetTag0(CStr(c.Tag))))
            ComboSelectedIndexChanged(CShort(GlobalRoutines.ValVir(GetTag0(CStr(c.Tag)))), Combo2(ii), New System.EventArgs)
            cmdTipPass.Text = Trim(c.Text)
        End With
        PASSI.DefInstance.Dispose()
    End Sub
    Private Sub _cmdTraccia_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdTraccia_2.Click
        Dim q As Short
        Dim Res As Boolean
        Dim File As String = ""
        Dim Strin1(2) As String
        Select Case iAction
            Case 0
                DaTos(iDat).ILFINAL = 1 : DaTos(iDat).Elimin = 0
                kdati = 1
                Res = inizio2()
            Case 1
                '     LOCATE 26, 67: Color 13
                '     Print "Attendere....": Color 15
                Timer1.Enabled = False
                Call Bilancio()
                iAction = -1
                Res = inizio2() ': GoTo 9197
                Timer1.Enabled = True
            Case 2
                '     LOCATE 26, 67: Color 13
                '     Print "Attendere....": Color 15
                If iAgg = 0 Then
                    iAgg = 1
                    Call Aggancia() ':  GoTo 9197
                    iAction = -1
                    Res = inizio2() ': GoTo 9197
                ElseIf iAgg = 1 Then
                    iAgg = 2
                    Call Infilaggio("C", 2 * (DaTos(iDat).dtubo / 2), 0.0!, DaTos(iDat).Interf, DaTos(iDat).Tublu, 0.01, DaTos(iDat).GapCurve)
                    'Call Infilaggio("C", DaTos(iDat).Passo, 0!, 1, DaTos(iDat).Tublu, 1!)
                    iAction = -1
                    _cmdTraccia_2.Text = "Ritraccia"
                    Res = inizio2() ': GoTo 9197
                ElseIf iAgg = 2 Then
                    iAgg = 3
                    Strin1(1) = Helpstringa(IDH_HID_AUTOCAD2)
                    Strin1(2) = Helpstringa(IDH_HID_AUTOCAD3)
                    q = Monitor.Motore.Quale(2, Helpstringa(IDH_HID_AUTOCAD4), Strin1, RadiceHelp, 1, , , IDH_HID_AUTOCAD1)
                    Select Case q
                        Case 1
                            Call DisegnoCAD(2 * (DaTos(iDat).dtubo / 2), DaTos(iDat).Passo, DaTos(iDat).passoint, File)
                        Case 2
                            frmDis3D.DefInstance.ShowDialog()
                    End Select
                    iAction = -1
                    Res = inizio2() ': GoTo 9197
                ElseIf iAgg = 3 Then
                    iAgg = 4
                    Riordino(1)
                    ControllaRMT()
                    iAction = -1
                    Res = inizio2() ': GoTo 9197
                End If
        End Select
    End Sub
    Private Sub frmTracciat_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Monitor.Motore.Problem = Monitor.Motore.Problems("Trac").Problem
        Monitor.Motore.About = Monitor.Motore.Problems("Trac").About
        ' AggiornaTitoloFinestra()
        '  If Tracciatura.Modo = 2 And iPagina < 2 Then mnuDati_Click(mnuDati, New System.EventArgs)
        '  If Tracciatura.DaPPSM Then
        '  If Tracciatura.Modo < 3 And iPagina < 2 Then
        '  mnuDati_Click(mnuDati, New System.EventArgs)
        '  ElseIf Tracciatura.Modo = 3 Then
        '      mnuCalcola_Click(Me, New EventArgs)
        '      mnuDisegna_Click(Me, New EventArgs)
        '      mnu4sp_Click(Me, New EventArgs)
        '  End If
        '  End If
    End Sub
    Private Sub frmTracciat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Keys = CType(Asc(e.KeyChar), Keys)
        If Not KeyAscii = Keys.Escape Then GoTo EventExitSub
        Select Case iAction
            Case 2
                Select Case iAgg
                    Case 1 : iAgg = 0
                    Case 2 : iAgg = 1
                    Case 3 : iAgg = 2
                    Case 4 : iAgg = 3
                End Select
        End Select
EventExitSub:
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub frmTracciat_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Dim Button As Short = CShort(e.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        Dim X As Single = e.X
        Dim y As Single = e.Y
    End Sub
    Private Sub popCambia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popCambia.Click
        Dim hh As Short
        Dim cod As String
        VariatiDati = True
        VariatiOpfin = True
        MenuClick = 3
        hh = H
        If DaTos(iDat).FilaCentraleStorta And System.Math.Abs(ytub + DaTos(iDat).y(DaTos(iDat).kymax)) _
        < clsTrigon.TOLER Then hh = CShort(hh + 1)
        Select Case FuoriLayOut
            Case 0
                If Allerta() = MsgBoxResult.No Then Exit Sub
                If jshe = 3 And H > (DaTos(iDat).ici(j) - 1) / 2 Then H = CShort(DaTos(iDat).ici(j) - H + 1)
                cod = DaTos(iDat).bu(j, hh)
                Select Case cod
                    Case "0", "1"
                        itir = 1
                        If DaTos(iDat).bu(j, hh) = "0" Then isg = 0 Else isg = -1
                        If ntir >= 60 Then Beep() : Exit Sub
                        DaTos(iDat).bu(j, hh) = CChar("2")
                        If jshe = 3 Then DaTos(iDat).bu(j, DaTos(iDat).ici(j) - hh + 1) = CChar("2")
                        If cod = "1" Then
                            mettileva(0, False)
                        End If
                        MettiTirante(0, xtub, ytub)
                        If jshe = 3 Then
                            MettiTirante(0, -xtub, ytub)
                        End If
                        If jshe = 2 Then
                            MettiTirante(0, xtub, -ytub)
                        End If
                    Case "2"
                        DaTos(iDat).bu(j, hh) = CChar("1") ' Titu
                        If jshe = 3 Then DaTos(iDat).bu(j, DaTos(iDat).ici(j) - hh + 1) = CChar("1") ' Titu
                        TogliTirante(0, xtub, ytub)
                        If jshe = 3 Then
                            TogliTirante(0, -xtub, ytub)
                        End If
                        If jshe = 2 Then
                            TogliTirante(0, xtub, -ytub)
                        End If
                        itir = 1 : isg = 1
                        mettileva(1, True)
                End Select
                If DaTos(iDat).ntira < ntir Then DaTos(iDat).ntira = ntir
            Case -1, 1, 2
                If iDat = 1 Then iDat = 0 : QualeCorona = 1 : iDat = 0
                MettiTondo(0, xcsi, ypsi)
            Case 3, 4, 5, 6 'edita tirante/tondo/piatto/SS
                frmEdita.DefInstance.ShowDialog()
                frmEdita.DefInstance.Dispose()
                SubTraccia(1)
        End Select
    End Sub
    Private Sub popTogli_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popTogli.Click
        Dim nopiu As Short
        VariatiDati = True
        VariatiOpfin = True
        MenuClick = 1
        Select Case FuoriLayOut
            Case 0
                Select Case DaTos(iDat).bu(j, H)
                    Case CChar("1")
                        If Allerta() = MsgBoxResult.No Then Exit Sub
                        DaTos(iDat).bu(j, H) = CChar("0")
                        If jshe = 3 Then DaTos(iDat).bu(j, DaTos(iDat).ici(j) - H + 1) = CChar("0")
                        itir = 0 : isg = -1
                        mettileva(0, True)
                    Case CChar("0"), CChar("2")
                        If Allerta() = MsgBoxResult.No Then Exit Sub
                        If DaTos(iDat).bu(j, H) = "2" Then nopiu = 1
                        DaTos(iDat).bu(j, H) = CChar("1") 'Titu
                        If jshe = 3 Then DaTos(iDat).bu(j, DaTos(iDat).ici(j) - H + 1) = CChar("1")
                        itir = 0 : isg = 1
                        If nopiu = 1 Then nopiu = 0 : isg = 0
                        mettileva(0, False)
                End Select
            Case -1, 1, 2
                MettiTirante(0, xcsi, ypsi)
            Case 5
                TogliPiatto()
            Case 6
                TogliSS()
        End Select

    End Sub
    Private Sub popToglTi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popToglTi.Click
        Dim Res As Boolean
        Dim idi0 As Single
        VariatiDati = True
        VariatiOpfin = True
        MenuClick = 2
        If Not FuoriReticolo Then
            Select Case DaTos(iDat).bu(j, H)
                Case CChar("2")
                    DaTos(iDat).bu(j, H) = CChar("0")
                    CancTir(0)
            End Select
        Else
            Select Case FuoriLayOut
                Case -1
                    MettiUrto()
                Case 1
                    idi0 = CShort(GlobalRoutines.ValVir(InputBox("Nuovo diametro interno", "", Str(DaTos(iDat).di1))))
                    If idi0 > DaTos(iDat).OTL Then DaTos(iDat).di1 = idi0
                    Res = inizio2()
                    Distraccia()
                Case 2 'cambia OTL
                    CambiaOTL()
                Case 22 'cambia OTL interno
                    CambiaOTL()
                Case 3 'tirante fuori layout
                    CancTir(0)
                Case 12, 13
                    CambiaITL()
                Case 4 'tondo fuori layout
                    CancTondo()
                Case 5 'muovi piatto
                    FuoriLayOut = 51
                    Frame1.Visible = True
                    cmdLeft.Visible = False
                    cmdRight.Visible = False
                    cmdZoom.Enabled = False
                    cmdFull.Enabled = False
                    mnuEnable(False, 0, npagine)
                Case 6 'muovi SS
                    Frame1.Visible = True
                    cmdZoom.Enabled = False
                    cmdFull.Enabled = False
                    mnuEnable(False, 0, npagine)
                Case 7 'togli taglio
                    Monitor.Routines.ColoreTratto(Picture1.BackColor)
                    DisTaglio(Nelem)
                    DaTos(iDat).tagli(Nelem) = 0
                    Monitor.Routines.ColoreTratto(Picture1.ForeColor)
            End Select
        End If
        Picture1.Refresh()
    End Sub

    Public Sub mnuCalcola_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCalcola.Click
        mnuStampa.Enabled = False
        cmdStampa.Visible = False
        mnuRM.Enabled = False
        Timer1.Enabled = False
        If gencommes.Trim.Length = 0 Then
            '      MsgBox(at1(158), MsgBoxStyle.Critical) '"Non è stato definito il numero di commessa", MsgBoxStyle.Critical)
            mnuSalvaCome_Click(sender, e) 'Exit Sub
        End If
        Timer1.Enabled = True
        If iPagina < 3 And Not ActiveControl Is Nothing Then
            If ActiveControl.Name.IndexOf("Text1") > -1 Then Text1Leave(CShort(GetTag0(CStr(CType(ActiveControl, arrText1).Tag))), New EventArgs)
            If Not Dati() Then Exit Sub
        End If
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        mnuRM.Enabled = True
        IniziaPagina()
        iPagina = 3
        Calcolando = True
        Picture1.BackColor = Color.White
        cmdZoom.Visible = True
        cmdFull.Visible = True
        If inizio1() Then
            '   SaveAll()
            InitVista()
            mnuEnable(True, 1, npagine)
            cmdAggiorna.Visible = True
            _cmdTraccia_2.Visible = (DaTos(iDat).TipoFascio = clsTracciatura.TipiFascio.Fontana)
            datiout(0)
            Cursor = Cursors.Default
        Else
            Cursor = Cursors.Default
            mnuDati_Click(sender, e)
            Calcolando = False
            Exit Sub
        End If
        Application.DoEvents()
        Distraccia()
        Calcolando = False
    End Sub
    Private Sub mnuTiranti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTiranti.Click
        MenuFinali(False)
        Timer1.Enabled = True
        iPagina = 3
        FuoriLayOut = 3
        frmGridn.DefInstance.ShowDialog()
        frmGridn.DefInstance.Close()
        frmGridn.DefInstance.Dispose()
        VariatiDati = True
        VariatiOpfin = True
        MenuFinali(True)
    End Sub

    Private Sub mnuTondi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTondi.Click
        MenuFinali(False)
        Timer1.Enabled = True
        iPagina = 3
        FuoriLayOut = 4
        frmGridn.DefInstance.ShowDialog()
        frmGridn.DefInstance.Dispose()
        Distraccia()
        VariatiDati = True
        VariatiOpfin = True
        MenuFinali(True)
    End Sub

    Private Sub mnuPiatti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPiatti.Click
        MenuFinali(False)
        Timer1.Enabled = True
        iPagina = 3
        FuoriLayOut = 6
        frmGridn.DefInstance.ShowDialog()
        frmGridn.DefInstance.Dispose()
        Distraccia()
        VariatiDati = True
        VariatiOpfin = True
        MenuFinali(True)
    End Sub
    Private Sub mnuTagli_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTagli.Click
        MenuFinali(False)
        Timer1.Enabled = True
        iPagina = 3
        FuoriLayOut = 7
        frmGridn.DefInstance.ShowDialog()
        frmGridn.DefInstance.Dispose()
        Distraccia()
        VariatiDati = True
        VariatiOpfin = True
        MenuFinali(True)
    End Sub
    Private Sub MenuFinali(ByVal v As Boolean)
        mnuSalva.Enabled = v
        cmdSalva.Visible = v
        mnuSalvaCome.Enabled = v
        mnuRipristina.Enabled = v
        mnuStampa.Enabled = v
        cmdStampa.Visible = v
        mnuRM.Enabled = v
    End Sub
    Private Sub Click78(ByVal Index As Integer)
        Timer1.Enabled = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        MenuFinali(True)
        If iPagina = 4 Then  '4s/p dopo disegno
            iPagina = -1
            Tracciatura.Calc4SsP(RTrim(gencommes) & ".TRK", 1)
            iPagina = 4
        Else
            IniziaPagina()
            iPagina = 4
            Picture1.BackColor = Drawing.Color.White
            cmdZoom.Visible = True
            cmdFull.Visible = True
            cmdAggiorna.Visible = True
            _cmdTraccia_2.Visible = False
            mnuEnable(False, 3, npagine)
            'SaveAll()
            If Index = 7 Then 'disegno + 4S/p da altra pagina
                Tracciatura.Calc4SsP(RTrim(gencommes) & ".TRK", 1)
            ElseIf Index = 8 Then  'disegno da altra pagina
                Tracciatura.DisTrk(RTrim(gencommes) & ".TRK", RTrim(gencommes), 1, 0)
            End If
            mnuEnable(True, 1, npagine)
            _cmdTraccia_2.Visible = (DaTos(iDat).TipoFascio = 4)
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        VariatiDati = True
        VariatiOpfin = True
    End Sub

    Private Sub cmd4Ssp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd4Ssp.Click
        Me.mnu4sp_Click(sender, e)
    End Sub

    Public Sub mnu4sp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu4sp.Click
        Click78(7)
    End Sub

    Public Sub mnuDisegna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDisegna.Click
        Click78(8)
    End Sub

    Private Sub mnuRipristina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRipristina.Click
        Carica(1)
        AggSecondaPagina()

    End Sub
    Private Sub Break_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Break.Click
        Me.Breckato = True
    End Sub

    Private Sub mnuAree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAree.Click
        Monitor.Motore.Aree(True)
    End Sub

    Private Sub popDimen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popDimen.Click
        VariatiDati = True
        Select Case FuoriLayOut
            Case -1, 1, 2 'metti SS
                MettiSS()
            Case 5 'modifica piatto d'urto
                FuoriLayOut = 52
                Frame1.Visible = True
                cmdZoom.Enabled = False
                cmdFull.Enabled = False
                mnuEnable(False, 0, npagine)
            Case 6 'modifica dimensioni SS
                FuoriLayOut = 62
                Frame1.Visible = True
        End Select

    End Sub
    Private Sub mnuStrategia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuStrategia.Click
        Dim Testo As String, R As Boolean
        Dim Strin1(1), Ris1(1), dAiu(1) As String
        Dim Archiv(1) As Short
        With Monitor.Motore
            Testo = .Inizio.ConvertiCr(Helpstringa(IDH_PREF_FACT))
            Strin1(1) = Testo
            Ris1(1) = Format(Fact, "##.##")
            R = .InputDati(1, "TRACCIA - Fattore di strategia", Strin1, Ris1, RadiceHelp, Archiv, dAiu, , , , IDH_PREF_FACT)
            Fact = CSng(GlobalRoutines.ValVir(Ris1(1)))
            .Inizio.WriteIniFile("", "Preferenze Traccia", "FattStrategiaAggiancio", GlobalRoutines.myStr(Fact, 2, 2, 0))
        End With
    End Sub
    Private Sub popRuota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popRuota.Click
        VariatiDati = True
        Select Case FuoriLayOut
            Case 3 'muovi tirante
                Frame1.Visible = True
            Case 4 'muovi tondo
                Frame1.Visible = True
                cmdLeft.Visible = False
                cmdRight.Visible = False
            Case 6 'Ruota SS
                FuoriLayOut = 61
                Frame1.Visible = True
                cmdLeft.Visible = False
                cmdRight.Visible = False
            Case 7
                Frame1.Visible = True
                Select Case DaTos(iDat).tagli(9)
                    Case 1
                        cmdLeft.Visible = False
                        cmdRight.Visible = False
                    Case 2
                        cmdUp.Visible = False
                        cmdDown.Visible = False
                End Select
        End Select
        cmdZoom.Enabled = False
        cmdFull.Enabled = False
        mnuEnable(False, 0, npagine)
    End Sub

    Private Sub popRuotaGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles popRuotaGen.Click
        VariatiDati = True
        Select Case FuoriLayOut
            Case 6 'Ruota SS attorno al centro
                FuoriLayOut = 63
                Frame1.Visible = True
                cmdLeft.Visible = False
                cmdRight.Visible = False
        End Select
        cmdZoom.Enabled = False
        cmdFull.Enabled = False
        mnuEnable(False, 0, npagine)
    End Sub
    Private Sub mnuLavori_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLavori.Click
        Monitor.Motore.SetLavoriSciolti()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        IniziaPagina()
        SecondaPagina()
        Enabled = True
    End Sub
    Private Sub mioContesto_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mioContesto.Opening
        ExecPopupMenu()
    End Sub
    Private Sub cmdElim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElim.Click
        Elimina()
        AggiornaTitoloFinestra()
        iAction = 0
        _cmdTraccia_2.Visible = False
    End Sub
    Private Sub mnuSoloPerif_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSoloPerif.Click
        DisegnaSoloPerif = Not DisegnaSoloPerif
        mnuSoloPerif.Checked = DisegnaSoloPerif
    End Sub

    Private Sub cmdApri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApri.Click
        Me.mnuApri_Click(sender, e)
    End Sub

    Private Sub cmdSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalva.Click
        Me.mnuSalva_Click(sender, e)
    End Sub

    Private Sub cmdDati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDati.Click
        Me.mnuDati_Click(sender, e)
    End Sub

    Private Sub cmdCalcola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcola.Click
        Me.mnuCalcola_Click(sender, e)
    End Sub
    Private Sub cmdDisTrk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDisTrk.Click
        Click78(8)
    End Sub
    Private Sub cmdStampa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStampa.Click
        mnuStampa_Click(sender, e)
    End Sub
    Private Sub mnuGuida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGuida.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub
    Private Sub mnuInformazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInformazioni.Click
        Monitor.Motore.Informazioni(Me, Reflection.Assembly.GetExecutingAssembly)
    End Sub
    Private Sub frmTracciat_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        '    If Not Inizializzando Then DisegnaFontana()
    End Sub
    Private Sub mnuChiudi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuChiudi.Click
        If Not mnuChiudi.Enabled Then Exit Sub
        If gencommes.Trim.Length > 0 Then
            If Chiudi() = MsgBoxResult.Cancel Then Exit Sub
        End If
        FileClose()
        gencommes = " "
        IniziaPagina()
        DisegnaFontana()
        mnuChiudi.Enabled = False
    End Sub
    Private Class arrText1
        Inherits System.Windows.Forms.TextBox
        Private ReadOnly HostForm As frmTracciat
        Public Sub New(ByVal host As frmTracciat)
            MyBase.new()
            HostForm = host
        End Sub
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            HostForm.Text1Changed(CShort(GetTag0(CStr(Tag))))
        End Sub
        Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            HostForm.Text1KeyPress(CShort(GetTag0(CStr(Tag))), e)
        End Sub
        Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
            HostForm.Text1Leave(CShort(GetTag0(CStr(Tag))), e)
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            HostForm.Text1MouseMove(CShort(GetTag0(CStr(Tag))), e)
        End Sub
    End Class
    Private Class Text1Array
        Inherits System.Collections.CollectionBase
        Private ReadOnly HostForm As frmTracciat
        Public Sub New(ByRef m As frmTracciat)
            HostForm = m
        End Sub
        Default Public ReadOnly Property Item(ByVal Index As Integer) As arrText1
            Get
                Return CType(List.Item(Index), arrText1)
            End Get
        End Property
        Public Sub UnLoad(ByVal Index As Integer)
            Me.Item(Index).Dispose()
            HostForm.Frame.Controls.Remove(Me(Index))
            Me.List.RemoveAt(Index)
        End Sub
        Public Sub Remove()
            ' Check to be sure there is a button to remove.
            If Me.Count > 0 Then
                ' Remove the last button added to the array from the host form 
                ' controls collection. Note the use of the default property in 
                ' accessing the array.
                Me.Item(Me.Count - 1).Dispose()
                HostForm.Frame.Controls.Remove(Me(Me.Count - 1))
                Me.List.RemoveAt(Me.Count - 1)
            End If
        End Sub
        Public Sub RemoveAll(Optional ByVal i As Integer = 0)
            Do While Count > i
                Remove()
            Loop
        End Sub
        Public Function Load(ByVal Index As Integer) As arrText1
            Dim i As Integer
            If Index >= Count Then
                For i = Count To Index - 1
                    AddNewTextBox()
                Next
                Return AddNewTextBox()
            Else
                Return CType(list(Index), arrText1)
            End If
        End Function
        Public Function AddNewTextBox() As arrText1
            Dim aButton As New arrText1(HostForm)
            ' Add the button to the collection's internal list.
            Me.List.Add(aButton)
            ' Add the button to the controls collection of the form 
            ' referenced by the HostForm field.
            HostForm.Frame.Controls.Add(aButton)
            aButton.Tag = Me.Count - 1
            aButton.Name = "Text1_" & CStr(aButton.Tag).Trim
            aButton.Visible = False
            aButton.Width = CType(list(0), arrText1).Width
            aButton.Height = CType(list(0), arrText1).Height
            aButton.Multiline = CType(list(0), arrText1).Multiline
            aButton.TextAlign = CType(list(0), arrText1).TextAlign
            Return aButton
        End Function
    End Class
End Class
Friend Class arrPix
    Inherits System.Windows.Forms.PictureBox
    Private ReadOnly HostForm As frmTracciat
    Public Sub New(ByVal host As frmTracciat)
        MyBase.new()
        HostForm = host
    End Sub
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
    End Sub
End Class
Friend Class PixArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As frmTracciat
    Public Sub New(ByVal host As frmTracciat)
        HostForm = host
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrPix
        Get
            Return CType(List.Item(Index), arrPix)
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        Me.Item(Index).Dispose()
        HostForm.Frame.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            With Me.Item(Me.Count - 1)
                If Not .Image Is Nothing Then .Image.Dispose()
                .Dispose()
            End With
            HostForm.Frame.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrPix
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox()
            Next
            Return AddNewTextBox()
        Else
            Return CType(list(Index), arrPix)
        End If
    End Function
    Public Function AddNewTextBox() As arrPix
        Dim aButton As New arrPix(HostForm)
        ' Add the button to the collection's internal list.
        Me.List.Add(aButton)
        ' Add the button to the controls collection of the form 
        ' referenced by the HostForm field.
        HostForm.Frame.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = "Pix_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Width = CType(list(0), arrPix).Width
        aButton.Height = CType(list(0), arrPix).Height
        aButton.BorderStyle = CType(list(0), arrPix).BorderStyle
        Return aButton
    End Function
End Class
Friend Class arrCheck
    Inherits System.Windows.Forms.CheckBox
    Private ReadOnly HostForm As frmTracciat
    Public Sub New(ByVal host As frmTracciat)
        MyBase.new()
        HostForm = host
    End Sub
    Protected Overrides Sub OnCheckStateChanged(ByVal e As System.EventArgs)
        HostForm.Check1CheckStateChanged(CShort(GetTag0(CStr(Tag))), e)
    End Sub
End Class
Friend Class CheckArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As frmTracciat
    Public Sub New(ByVal host As frmTracciat)
        HostForm = host
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrCheck
        Get
            Return CType(List.Item(Index), arrCheck)
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        Me.Item(Index).Dispose()
        HostForm.Frame.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            HostForm.Frame.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrCheck
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox()
            Next
            Return AddNewTextBox()
        Else
            Return CType(list(Index), arrCheck)
        End If
    End Function
    Public Function AddNewTextBox() As arrCheck
        Dim aButton As New arrCheck(HostForm)
        ' Add the button to the collection's internal list.
        Me.List.Add(aButton)
        ' Add the button to the controls collection of the form 
        ' referenced by the HostForm field.
        HostForm.Frame.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = "Check1_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Width = CType(list(0), arrCheck).Width
        aButton.Height = CType(list(0), arrCheck).Height
        Return aButton
    End Function
End Class
Friend Class arrLabel
    Inherits System.Windows.Forms.Label
    Private ReadOnly quadro As Control
    Public Sub New(ByRef q As Control)
        MyBase.new()
        quadro = q
    End Sub
End Class
Friend Class LabelArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly quadro As Control
    Public Sub New(ByRef q As Control)
        quadro = q
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrLabel
        Get
            Return CType(List.Item(Index), arrLabel)
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        Me.Item(Index).Dispose()
        quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer, ByVal p As String) As arrLabel
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(p)
            Next
            Return AddNewTextBox(p)
        Else
            Return CType(list(Index), arrLabel)
        End If
    End Function
    Public Function AddNewTextBox(ByVal PrefixName As String) As arrLabel
        Dim aButton As New arrLabel(quadro)
        Me.List.Add(aButton)
        quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Width = CType(list(0), arrLabel).Width
        aButton.Height = CType(list(0), arrLabel).Height
        aButton.BorderStyle = CType(list(0), arrLabel).BorderStyle
        aButton.FlatStyle = CType(list(0), arrLabel).FlatStyle
        aButton.BackColor = CType(list(0), arrLabel).BackColor
        Return aButton
    End Function
End Class
Friend Class arrCombo
    Inherits System.Windows.Forms.ComboBox
    Private ReadOnly HostForm As frmTracciat
    Public Sub New(ByVal host As frmTracciat)
        MyBase.new()
        HostForm = host
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        Dim Index As Short = CShort(GetTag0(CStr(Tag))) 'HostForm.IndexText1
        HostForm.ComboTextChanged(Index, Me, e)
    End Sub
    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
        Dim Index As Short = CShort(GetTag0(CStr(Tag))) '   HostForm.IndexText1
        HostForm.ComboSelectedIndexChanged(Index, Me, e)
    End Sub
End Class
Friend Class ComboArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As frmTracciat
    Public Sub New(ByVal host As frmTracciat)
        HostForm = host
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrCombo
        Get
            Return CType(List.Item(Index), arrCombo)
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        Me.Item(Index).Dispose()
        HostForm.Frame.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            HostForm.Frame.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer, ByVal p As String) As arrCombo
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(p)
            Next
            Return AddNewTextBox(p)
        Else
            Return CType(list(Index), arrCombo)
        End If
    End Function
    Public Function AddNewTextBox(ByVal PrefixName As String) As arrCombo
        Dim aButton As New arrCombo(HostForm)
        Me.List.Add(aButton)
        HostForm.Frame.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Width = CType(list(0), arrCombo).Width
        aButton.Height = CType(list(0), arrCombo).Height
        aButton.TabStop = CType(list(0), arrCombo).TabStop
        aButton.DropDownStyle = CType(list(0), arrCombo).DropDownStyle
        aButton.DropDownWidth = CType(list(0), arrCombo).DropDownWidth
        Return aButton
    End Function
End Class
Module GestioneTag
    Friend Function GetTag(ByVal s As String) As String
        Dim n As Integer = InStr(s, "*")
        If n = 0 Then
            Return s
        Else
            Dim s1 As String = VB.Right$(s, Len(s) - n)
            Return s1
        End If
    End Function
    Friend Function SetTag(ByVal vTag As String, ByVal s As String) As String
        Dim n As Integer = InStr(vTag, "*")
        If n = 0 Then
            Return vTag & "*" & s
        Else
            Dim s1 As String = VB.Left(vTag, n)
            Return s1 & s
        End If
    End Function
    Friend Function GetTag0(ByVal s As String) As String
        Dim n As Integer = InStr(s, "*")
        If n = 0 Then
            Return s
        Else
            Dim s1 As String = VB.Left$(s, n - 1)
            Return s1
        End If
    End Function
End Module
