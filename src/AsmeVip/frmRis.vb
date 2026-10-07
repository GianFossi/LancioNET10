Option Strict Off
Option Explicit On
Imports RoutBase1
Friend Class frmRis
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'If m_vb6FormDefInstance Is Nothing Then
        '      If m_InitializingDefInstance Then
        '     m_vb6FormDefInstance = Me
        '    Else
        '       Try
        '  'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        ' If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        'm_vb6FormDefInstance = Me
        'End If
        '    Catch
        'End Try
        'End If
        'End If
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializza()
        Inizializzando = False
	End Sub
	'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Richiesto dalla progettazione Windows Form
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents cmdOptim As System.Windows.Forms.Button
	Public WithEvents cmdDilat As System.Windows.Forms.Button
	Public WithEvents cmdFattUs As System.Windows.Forms.Button
    Public WithEvents Picture3 As System.Windows.Forms.Panel
    Public WithEvents _Command3_1 As System.Windows.Forms.Button
	Public WithEvents _Command3_0 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Public WithEvents Picture2 As System.Windows.Forms.Panel
    Public WithEvents OptAll As System.Windows.Forms.Button
    Friend WithEvents TabStrip1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents _Opt0_0 As System.Windows.Forms.Button
    Friend WithEvents _Descrizione0_16 As System.Windows.Forms.RichTextBox
    Friend WithEvents _Dimensioni0_16 As System.Windows.Forms.RichTextBox
    Public WithEvents _Valore0_16 As System.Windows.Forms.TextBox
    Friend WithEvents _Descrizione0_0 As System.Windows.Forms.RichTextBox
    Friend WithEvents _Dimensioni0_0 As System.Windows.Forms.RichTextBox
    Public WithEvents _Valore0_0 As System.Windows.Forms.TextBox
    Public WithEvents _Opt1_0 As System.Windows.Forms.Button
    Friend WithEvents _Descrizione1_16 As System.Windows.Forms.RichTextBox
    Friend WithEvents _Dimensioni1_16 As System.Windows.Forms.RichTextBox
    Public WithEvents _Valore1_16 As System.Windows.Forms.TextBox
    Friend WithEvents _Descrizione1_0 As System.Windows.Forms.RichTextBox
    Friend WithEvents _Dimensioni1_0 As System.Windows.Forms.RichTextBox
    Public WithEvents _Valore1_0 As System.Windows.Forms.TextBox
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Picture1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRis))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOptim = New System.Windows.Forms.Button
        Me.cmdDilat = New System.Windows.Forms.Button
        Me.cmdFattUs = New System.Windows.Forms.Button
        Me.OptAll = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Command4 = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.Picture3 = New System.Windows.Forms.Panel
        Me._Opt1_0 = New System.Windows.Forms.Button
        Me._Descrizione1_16 = New System.Windows.Forms.RichTextBox
        Me._Dimensioni1_16 = New System.Windows.Forms.RichTextBox
        Me._Valore1_16 = New System.Windows.Forms.TextBox
        Me._Descrizione1_0 = New System.Windows.Forms.RichTextBox
        Me._Dimensioni1_0 = New System.Windows.Forms.RichTextBox
        Me._Valore1_0 = New System.Windows.Forms.TextBox
        Me._Command3_1 = New System.Windows.Forms.Button
        Me._Command3_0 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Picture2 = New System.Windows.Forms.Panel
        Me._Opt0_0 = New System.Windows.Forms.Button
        Me._Descrizione0_16 = New System.Windows.Forms.RichTextBox
        Me._Dimensioni0_16 = New System.Windows.Forms.RichTextBox
        Me._Valore0_16 = New System.Windows.Forms.TextBox
        Me._Descrizione0_0 = New System.Windows.Forms.RichTextBox
        Me._Dimensioni0_0 = New System.Windows.Forms.RichTextBox
        Me._Valore0_0 = New System.Windows.Forms.TextBox
        Me.TabStrip1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel1.SuspendLayout()
        Me.Picture3.SuspendLayout()
        Me.Picture2.SuspendLayout()
        Me.TabStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOptim
        '
        Me.cmdOptim.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOptim.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptim.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptim.Image = CType(resources.GetObject("cmdOptim.Image"), System.Drawing.Image)
        Me.cmdOptim.Location = New System.Drawing.Point(376, 0)
        Me.cmdOptim.Name = "cmdOptim"
        Me.cmdOptim.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptim.Size = New System.Drawing.Size(33, 41)
        Me.cmdOptim.TabIndex = 112
        Me.cmdOptim.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdOptim, "Ricerca le dimensioni ottimali del dilatatore")
        Me.cmdOptim.Visible = False
        '
        'cmdDilat
        '
        Me.cmdDilat.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDilat.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDilat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDilat.Image = CType(resources.GetObject("cmdDilat.Image"), System.Drawing.Image)
        Me.cmdDilat.Location = New System.Drawing.Point(512, 16)
        Me.cmdDilat.Name = "cmdDilat"
        Me.cmdDilat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDilat.Size = New System.Drawing.Size(33, 41)
        Me.cmdDilat.TabIndex = 111
        Me.cmdDilat.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdDilat, "Richiama i dati dilatatore")
        '
        'cmdFattUs
        '
        Me.cmdFattUs.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFattUs.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFattUs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.cmdFattUs, "Semaforo.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.cmdFattUs, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmdFattUs.Image = CType(resources.GetObject("cmdFattUs.Image"), System.Drawing.Image)
        Me.cmdFattUs.Location = New System.Drawing.Point(568, 0)
        Me.cmdFattUs.Name = "cmdFattUs"
        Me.cmdFattUs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.cmdFattUs, True)
        Me.cmdFattUs.Size = New System.Drawing.Size(33, 41)
        Me.cmdFattUs.TabIndex = 110
        Me.cmdFattUs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdFattUs, "Mostra i fattori d'uso")
        '
        'OptAll
        '
        Me.OptAll.BackColor = System.Drawing.SystemColors.Control
        Me.OptAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.OptAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptAll.Image = CType(resources.GetObject("OptAll.Image"), System.Drawing.Image)
        Me.OptAll.Location = New System.Drawing.Point(560, 8)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OptAll.Size = New System.Drawing.Size(35, 32)
        Me.OptAll.TabIndex = 180
        Me.OptAll.TabStop = False
        Me.OptAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.OptAll, "Ricalcola tutte le costanti fisiche di questa pagina")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Command4)
        Me.Panel1.Controls.Add(Me.cmdOptim)
        Me.Panel1.Controls.Add(Me.cmdDilat)
        Me.Panel1.Controls.Add(Me.cmdFattUs)
        Me.Panel1.Controls.Add(Me.Picture1)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Panel1.Location = New System.Drawing.Point(8, 544)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(606, 440)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(512, 384)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(82, 32)
        Me.Command4.TabIndex = 113
        Me.Command4.Text = "vedi Piastra B"
        Me.Command4.Visible = False
        '
        'Picture1
        '
        Me.Picture1.Location = New System.Drawing.Point(0, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Size = New System.Drawing.Size(600, 436)
        Me.Picture1.TabIndex = 114
        Me.Picture1.TabStop = False
        '
        'Picture3
        '
        Me.Picture3.BackColor = System.Drawing.SystemColors.Control
        Me.Picture3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture3.Controls.Add(Me._Opt1_0)
        Me.Picture3.Controls.Add(Me._Descrizione1_16)
        Me.Picture3.Controls.Add(Me._Dimensioni1_16)
        Me.Picture3.Controls.Add(Me._Valore1_16)
        Me.Picture3.Controls.Add(Me._Descrizione1_0)
        Me.Picture3.Controls.Add(Me._Dimensioni1_0)
        Me.Picture3.Controls.Add(Me._Valore1_0)
        Me.Picture3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture3.Location = New System.Drawing.Point(8, 8)
        Me.Picture3.Name = "Picture3"
        Me.Picture3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture3.Size = New System.Drawing.Size(606, 440)
        Me.Picture3.TabIndex = 114
        Me.Picture3.TabStop = True
        '
        '_Opt1_0
        '
        Me._Opt1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Opt1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Opt1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Opt1_0.Image = CType(resources.GetObject("_Opt1_0.Image"), System.Drawing.Image)
        Me._Opt1_0.Location = New System.Drawing.Point(272, 8)
        Me._Opt1_0.Name = "_Opt1_0"
        Me._Opt1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Opt1_0.Size = New System.Drawing.Size(23, 26)
        Me._Opt1_0.TabIndex = 188
        Me._Opt1_0.TabStop = False
        Me._Opt1_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me._Opt1_0.Visible = False
        '
        '_Descrizione1_16
        '
        Me._Descrizione1_16.BackColor = System.Drawing.Color.Yellow
        Me._Descrizione1_16.Location = New System.Drawing.Point(296, 8)
        Me._Descrizione1_16.Name = "_Descrizione1_16"
        Me._Descrizione1_16.Size = New System.Drawing.Size(160, 26)
        Me._Descrizione1_16.TabIndex = 187
        Me._Descrizione1_16.Text = "_Descrizione1_16"
        Me._Descrizione1_16.Visible = False
        '
        '_Dimensioni1_16
        '
        Me._Dimensioni1_16.Location = New System.Drawing.Point(456, 8)
        Me._Dimensioni1_16.Name = "_Dimensioni1_16"
        Me._Dimensioni1_16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Dimensioni1_16.Size = New System.Drawing.Size(32, 26)
        Me._Dimensioni1_16.TabIndex = 186
        Me._Dimensioni1_16.Text = "RichTextBox1"
        Me._Dimensioni1_16.Visible = False
        '
        '_Valore1_16
        '
        Me._Valore1_16.AcceptsReturn = True
        Me._Valore1_16.AutoSize = False
        Me._Valore1_16.BackColor = System.Drawing.SystemColors.Window
        Me._Valore1_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valore1_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valore1_16.Location = New System.Drawing.Point(488, 8)
        Me._Valore1_16.MaxLength = 0
        Me._Valore1_16.Name = "_Valore1_16"
        Me._Valore1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valore1_16.Size = New System.Drawing.Size(68, 26)
        Me._Valore1_16.TabIndex = 185
        Me._Valore1_16.Text = "Text1"
        Me._Valore1_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Valore1_16.Visible = False
        '
        '_Descrizione1_0
        '
        Me._Descrizione1_0.BackColor = System.Drawing.Color.Yellow
        Me._Descrizione1_0.Location = New System.Drawing.Point(8, 8)
        Me._Descrizione1_0.Name = "_Descrizione1_0"
        Me._Descrizione1_0.Size = New System.Drawing.Size(160, 26)
        Me._Descrizione1_0.TabIndex = 184
        Me._Descrizione1_0.Text = "RichTextBox1"
        '
        '_Dimensioni1_0
        '
        Me._Dimensioni1_0.Location = New System.Drawing.Point(168, 8)
        Me._Dimensioni1_0.Name = "_Dimensioni1_0"
        Me._Dimensioni1_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Dimensioni1_0.Size = New System.Drawing.Size(32, 26)
        Me._Dimensioni1_0.TabIndex = 183
        Me._Dimensioni1_0.Text = "RichTextBox1"
        Me._Dimensioni1_0.Visible = False
        '
        '_Valore1_0
        '
        Me._Valore1_0.AcceptsReturn = True
        Me._Valore1_0.AutoSize = False
        Me._Valore1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Valore1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valore1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valore1_0.Location = New System.Drawing.Point(200, 8)
        Me._Valore1_0.MaxLength = 0
        Me._Valore1_0.Name = "_Valore1_0"
        Me._Valore1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valore1_0.Size = New System.Drawing.Size(68, 26)
        Me._Valore1_0.TabIndex = 182
        Me._Valore1_0.Text = "Text1"
        Me._Valore1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Command3_1
        '
        Me._Command3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Command3_1, "Avantindre.htm")
        Me.HelpProvider1.SetHelpNavigator(Me._Command3_1, System.Windows.Forms.HelpNavigator.Topic)
        Me._Command3_1.Location = New System.Drawing.Point(512, 520)
        Me._Command3_1.Name = "_Command3_1"
        Me._Command3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Command3_1, True)
        Me._Command3_1.Size = New System.Drawing.Size(73, 25)
        Me._Command3_1.TabIndex = 107
        Me._Command3_1.Text = "Cambia sp."
        '
        '_Command3_0
        '
        Me._Command3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Command3_0, "Avantindre.htm")
        Me.HelpProvider1.SetHelpNavigator(Me._Command3_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._Command3_0.Location = New System.Drawing.Point(432, 520)
        Me._Command3_0.Name = "_Command3_0"
        Me._Command3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Command3_0, True)
        Me._Command3_0.Size = New System.Drawing.Size(73, 25)
        Me._Command3_0.TabIndex = 106
        Me._Command3_0.Text = "Sp. minimo"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(449, 496)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(54, 19)
        Me.Command2.TabIndex = 87
        Me.Command2.Text = "Indietro"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.Color.White
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(217, 512)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(145, 20)
        Me._Text1_1.TabIndex = 4
        Me._Text1_1.Text = ""
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.Color.White
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(217, 496)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(145, 20)
        Me._Text1_0.TabIndex = 2
        Me._Text1_0.Text = ""
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(512, 496)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(54, 19)
        Me.Command1.TabIndex = 1
        Me.Command1.Text = "Avanti"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_1.Location = New System.Drawing.Point(9, 512)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(201, 20)
        Me._Label1_1.TabIndex = 5
        Me._Label1_1.Text = "Label1"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_0.Location = New System.Drawing.Point(9, 496)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(201, 20)
        Me._Label1_0.TabIndex = 3
        Me._Label1_0.Text = "Label1"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "c:\Programmi\LancioNET\bin\AsmeVip.chm"
        '
        'Picture2
        '
        Me.Picture2.BackColor = System.Drawing.SystemColors.Control
        Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture2.Controls.Add(Me._Opt0_0)
        Me.Picture2.Controls.Add(Me.OptAll)
        Me.Picture2.Controls.Add(Me._Descrizione0_16)
        Me.Picture2.Controls.Add(Me._Dimensioni0_16)
        Me.Picture2.Controls.Add(Me._Valore0_16)
        Me.Picture2.Controls.Add(Me._Descrizione0_0)
        Me.Picture2.Controls.Add(Me._Dimensioni0_0)
        Me.Picture2.Controls.Add(Me._Valore0_0)
        Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture2.Location = New System.Drawing.Point(8, 8)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture2.Size = New System.Drawing.Size(606, 440)
        Me.Picture2.TabIndex = 115
        Me.Picture2.TabStop = True
        '
        '_Opt0_0
        '
        Me._Opt0_0.BackColor = System.Drawing.SystemColors.Control
        Me._Opt0_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Opt0_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Opt0_0.Image = CType(resources.GetObject("_Opt0_0.Image"), System.Drawing.Image)
        Me._Opt0_0.Location = New System.Drawing.Point(272, 8)
        Me._Opt0_0.Name = "_Opt0_0"
        Me._Opt0_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Opt0_0.Size = New System.Drawing.Size(23, 26)
        Me._Opt0_0.TabIndex = 181
        Me._Opt0_0.TabStop = False
        Me._Opt0_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me._Opt0_0.Visible = False
        '
        '_Descrizione0_16
        '
        Me._Descrizione0_16.BackColor = System.Drawing.Color.Yellow
        Me._Descrizione0_16.Location = New System.Drawing.Point(296, 8)
        Me._Descrizione0_16.Name = "_Descrizione0_16"
        Me._Descrizione0_16.Size = New System.Drawing.Size(160, 26)
        Me._Descrizione0_16.TabIndex = 179
        Me._Descrizione0_16.Text = "_Descrizione0_16"
        Me._Descrizione0_16.Visible = False
        '
        '_Dimensioni0_16
        '
        Me._Dimensioni0_16.Location = New System.Drawing.Point(456, 8)
        Me._Dimensioni0_16.Name = "_Dimensioni0_16"
        Me._Dimensioni0_16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Dimensioni0_16.Size = New System.Drawing.Size(32, 26)
        Me._Dimensioni0_16.TabIndex = 178
        Me._Dimensioni0_16.Text = "RichTextBox1"
        Me._Dimensioni0_16.Visible = False
        '
        '_Valore0_16
        '
        Me._Valore0_16.AcceptsReturn = True
        Me._Valore0_16.AutoSize = False
        Me._Valore0_16.BackColor = System.Drawing.SystemColors.Window
        Me._Valore0_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valore0_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valore0_16.Location = New System.Drawing.Point(488, 8)
        Me._Valore0_16.MaxLength = 0
        Me._Valore0_16.Name = "_Valore0_16"
        Me._Valore0_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valore0_16.Size = New System.Drawing.Size(68, 26)
        Me._Valore0_16.TabIndex = 177
        Me._Valore0_16.Text = "Text1"
        Me._Valore0_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Valore0_16.Visible = False
        '
        '_Descrizione0_0
        '
        Me._Descrizione0_0.BackColor = System.Drawing.Color.Yellow
        Me._Descrizione0_0.Location = New System.Drawing.Point(8, 8)
        Me._Descrizione0_0.Name = "_Descrizione0_0"
        Me._Descrizione0_0.Size = New System.Drawing.Size(160, 26)
        Me._Descrizione0_0.TabIndex = 176
        Me._Descrizione0_0.Text = "RichTextBox1"
        '
        '_Dimensioni0_0
        '
        Me._Dimensioni0_0.Location = New System.Drawing.Point(168, 8)
        Me._Dimensioni0_0.Name = "_Dimensioni0_0"
        Me._Dimensioni0_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Dimensioni0_0.Size = New System.Drawing.Size(32, 26)
        Me._Dimensioni0_0.TabIndex = 175
        Me._Dimensioni0_0.Text = "RichTextBox1"
        '
        '_Valore0_0
        '
        Me._Valore0_0.AcceptsReturn = True
        Me._Valore0_0.AutoSize = False
        Me._Valore0_0.BackColor = System.Drawing.SystemColors.Window
        Me._Valore0_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valore0_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valore0_0.Location = New System.Drawing.Point(200, 8)
        Me._Valore0_0.MaxLength = 0
        Me._Valore0_0.Name = "_Valore0_0"
        Me._Valore0_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valore0_0.Size = New System.Drawing.Size(68, 26)
        Me._Valore0_0.TabIndex = 135
        Me._Valore0_0.Text = "Text1"
        Me._Valore0_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabStrip1
        '
        Me.TabStrip1.Controls.Add(Me.TabPage1)
        Me.TabStrip1.Controls.Add(Me.TabPage2)
        Me.TabStrip1.Location = New System.Drawing.Point(0, 0)
        Me.TabStrip1.Name = "TabStrip1"
        Me.TabStrip1.SelectedIndex = 0
        Me.TabStrip1.Size = New System.Drawing.Size(632, 480)
        Me.TabStrip1.TabIndex = 116
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Picture2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(624, 454)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = " , "
        Me.TabPage1.Text = "TabPage1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Picture3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(624, 454)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = " , "
        Me.TabPage2.Text = "TabPage2"
        '
        'frmRis
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(634, 616)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabStrip1)
        Me.Controls.Add(Me._Command3_1)
        Me.Controls.Add(Me._Command3_0)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRis"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Calcolo fasci tubieri / piastre tubiere"
        Me.Panel1.ResumeLayout(False)
        Me.Picture3.ResumeLayout(False)
        Me.Picture2.ResumeLayout(False)
        Me.TabStrip1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
    'Private Shared m_vb6FormDefInstance As frmRis
    'Private Shared m_InitializingDefInstance As Boolean
    'Public Shared Property DefInstance() As frmRis
    '		Get
    '			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '				m_InitializingDefInstance = True
    '				m_vb6FormDefInstance = New frmRis()
    '				m_InitializingDefInstance = False
    '			End If
    '			DefInstance = m_vb6FormDefInstance
    '		End Get
    '		Set
    '			m_vb6FormDefInstance = Value
    '		End Set
    '	End Property
#End Region
    Private Inizializzando As Boolean
    Private dovebitmap As Bitmap
    Private O As wn_FTC
    Friend Descrizione0 As rtfArray
    Friend Dimensioni0 As rtfArray
    Friend Valore0 As TextArray
    Friend Opt As ButtonArray
    Friend Descrizione1 As rtfArray
    Friend Dimensioni1 As rtfArray
    Friend Valore1 As TextArray
    Private ModeGiunto As Short
    Private DLeft(31) As Single
    Private DWidth(31) As Single
    Private VLeft(31) As Single
    Private VWidth(31) As Single
    Private CarHeight, CarWidth As Single
    Private t As TabPage
    Private GiaAttivata As Boolean
    Friend nOpt As Short
    Public AltriDati As Boolean
    Public Risposta As String
    ' Public Chiusa As Boolean
    Public PiastraB As Boolean
    Public GiaDetto As Boolean
    Public mygraphics As Graphics
    Public myfont As Font
    Public mybrush As SolidBrush
    Public x, y As Single
    Private Sub Inizializza()
        dovebitmap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height)
        mygraphics = Graphics.FromImage(dovebitmap)
        Picture1.Image = dovebitmap
        myfont = Picture1.Font
        mybrush = New SolidBrush(Color.Black)
        Descrizione0 = New rtfArray(Me, Picture2, "_Descrizione0")
        Dimensioni0 = New rtfArray(Me, Picture2, "_Dimensioni0")
        Valore0 = New TextArray(Me, Picture2, "_Valore0")
        Opt = New ButtonArray(Me, Picture2, "_Opt0")
        Descrizione1 = New rtfArray(Me, Picture3, "_Descrizione1")
        Dimensioni1 = New rtfArray(Me, Picture3, "_Dimensioni1")
        Valore1 = New TextArray(Me, Picture3, "_Valore1")
        TabStrip1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        '--------------------------------------------------------------------------
        Dim i As Short
        Dim OwPT As wn_PT
        Try
            If Not Involucr(kLato, jInvolucr).Tipo = 7 Then
                OwPT = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
                O = OwPT.Piastra
                If O.Rear < 3 And O.CalcoloInCorso = 1 Then Picture1.Font = New Font(Picture1.Font.FontFamily, 8, Picture1.Font.Style)
            End If
            '            Descrizione0(0).Enabled = False
            '           Dimensioni0(0).Enabled = False
            For i = 1 To 15
                Descrizione0.Load(i)
                Descrizione0(i).Top = 26 * i + 8
                Descrizione0(i).Left = Descrizione(0).Left
                '              Descrizione0(i).Enabled = False
                Dimensioni0.Load(i)
                Dimensioni0(i).Top = 26 * i + 8
                Dimensioni0(i).Left = Dimensioni(0).Left
                '             Dimensioni0(i).Enabled = False
                Valore0.Load(i)
                Valore0(i).Top = 26 * i + 8
                Valore0(i).Left = Valore(0).Left
            Next
            For i = 16 To 31
                Descrizione0.Load(i)
                Descrizione0(i).Top = 26 * (i - 16) + 8
                Descrizione0(i).Left = _Descrizione0_16.Left
                '            Descrizione0(i).Enabled = False
                Dimensioni0.Load(i)
                Dimensioni0(i).Top = 26 * (i - 16) + 8
                Dimensioni0(i).Left = _Dimensioni0_16.Left
                '           Dimensioni0(i).Enabled = False
                Valore0.Load(i)
                Valore0(i).Top = 26 * (i - 16) + 8
                Valore0(i).Left = _Valore0_16.Left
            Next
            '      Descrizione1(0).Enabled = False
            '     Dimensioni1(0).Enabled = False
            For i = 1 To 15
                Descrizione1.Load(i)
                Descrizione1(i).Top = 26 * i + 8
                Descrizione1(i).Left = Descrizione(100).Left
                '        Descrizione1(i).Enabled = False
                Dimensioni1.Load(i)
                Dimensioni1(i).Top = 26 * i + 8
                Dimensioni1(i).Left = Dimensioni(100).Left
                '       Dimensioni1(i).Enabled = False
                Valore1.Load(i)
                Valore1(i).Top = 26 * i + 8
                Valore1(i).Left = Valore(100).Left
            Next
            For i = 16 To 31
                Descrizione1.Load(i)
                Descrizione1(i).Top = 26 * (i - 16) + 8
                Descrizione1(i).Left = _Descrizione1_16.Left
                '      Descrizione1(i).Enabled = False
                Dimensioni1.Load(i)
                Dimensioni1(i).Top = 26 * (i - 16) + 8
                Dimensioni1(i).Left = _Dimensioni1_16.Left
                '     Dimensioni1(i).Enabled = False
                Valore1.Load(i)
                Valore1(i).Top = 26 * (i - 16) + 8
                Valore1(i).Left = _Valore1_16.Left
            Next
            For i = 0 To 31
                DLeft(i) = Descrizione(i).Left
                DWidth(i) = Descrizione(i).Width
                VLeft(i) = Valore(i).Left
                VWidth(i) = Valore(i).Width
            Next
            CarHeight = MisuraStringa("A").Height
            CarWidth = MisuraStringa("A").Width
            Panel1.Top = GlobalRoutines.TwipsToPixelsY(480)
            If Not Involucr(kLato, jInvolucr).Tipo = 7 Then
                If O.Rear < 3 And O.CalcoloInCorso = 1 Then Picture1.Font = New Font(Picture1.Font.FontFamily, 8, Picture1.Font.Style)
                _Command3_0.Visible = O.CalcoloInCorso = 0
            End If
            HelpProvider1.HelpNamespace = RadiceHelp
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function MisuraStringa(ByVal t As String) As SizeF
        Dim characterRanges As CharacterRange() = _
        {New CharacterRange(0, t.Length)}
        Dim layoutRect As RectangleF = New RectangleF(0, 0, Picture1.Width, Picture1.Height)
        Dim stringFormat As New StringFormat
        'stringFormat.FormatFlags = StringFormatFlags.DirectionVertical
        stringFormat.SetMeasurableCharacterRanges(characterRanges)
        Dim stringRegions(0) As [Region]
        stringRegions = mygraphics.MeasureCharacterRanges(t, _
        myfont, layoutRect, stringFormat)
        Dim Rect As RectangleF = stringRegions(0).GetBounds(mygraphics)
        Dim s As New SizeF(Rect.Width, Rect.Height)
        Return s
    End Function
    Friend ReadOnly Property Descrizione(ByVal i As Short) As arrRTF
        Get
            If i >= 100 Then
                Return Descrizione1(i - 100)
            Else
                Return Descrizione0(i)
            End If

        End Get
    End Property
    Friend ReadOnly Property Dimensioni(ByVal i As Short) As arrRTF
        Get
            If i >= 100 Then
                Return Dimensioni1(i - 100)
            Else
                Return Dimensioni0(i)
            End If
        End Get
    End Property
    Friend ReadOnly Property Valore(ByVal i As Short) As arrText
        Get
            If i >= 100 Then
                Return Valore1(i - 100)
            Else
                Return Valore0(i)
            End If
        End Get
    End Property
    Private Sub cmdDilat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDilat.Click
        Dim jSav, iDilat, kSav As Short
        Dim Res As Short
        Dim t As TabPage
        t = TabStrip1.SelectedTab
        iDilat = O.IndiceDilat
        If iDilat < 0 Then iDilat = jInvolucr
        jSav = jInvolucr : kSav = kLato
        Res = DatiDilat(1, iDilat)
        jInvolucr = jSav : kLato = kSav
        If Not Res Then Exit Sub
        TabStrip1_ClickEvent(TabStrip1, New System.EventArgs)
    End Sub
    Private Sub cmdFattUs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFattUs.Click
        O.FattUs(True)
    End Sub
    Private Sub cmdOptim_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOptim.Click
        O.SuperOtt()
        Risposta = "Ammazza"
    End Sub
    Public Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'Avanti
        Dim t As TabPage
        Dim f As Single
        Dim Testo, Testo1 As String
        For Each t In TabStrip1.TabPages
            If InStr(getmiotag(t.Tag, 0), "Sint") > 0 Then
                PiastraB = False
                Risposta = "Visualizza"
                If O.F2F3(0, 1) = 0 Then
                    O.FattUs(True, True, f)
                    Risposta = "F1"
                    If f > 1 Then
                        Testo1 = Helpstringa(IDH_ST_TUBESHNO)
                        Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Testo1), 100 * f)
                        If ContinuoAuto Then
                            PrintlstRes(Testo)
                        Else
                            If MostraAiuto(IDH_ST_TUBESHNO, RoutBase1.ChiaviMess.MessYesNo + RoutBase1.ChiaviMess.MessHelpButton, Testo) = RoutBase1.ChiaviMess.MessSi Then
                                If O.CalcoloInCorso = 1 Then
                                    O.Padre.RulesAA.ScelSpes()
                                End If
                                Risposta = "Non valido1"
                            Else
                                Risposta = "Non valido"
                            End If
                        End If
                    End If
                End If
                GoTo Fine
            End If
        Next t
        For Each t In TabStrip1.TabPages
            If InStr(getmiotag(t.Tag, 0), "Ris") > 0 Then
                Risposta = "Visualizza"
                O.F2F3(1, 0, True)
            End If
        Next t
        Risposta = "F1"
Fine:
        cmdOptim.Visible = False
        Hide()
        GiaAttivata = False
    End Sub
    Public Sub ResetBoxes()
        Dim i, j As Short
        For i = 0 To 31
            Descrizione(i).Left = DLeft(i)
            Descrizione(i).Width = DWidth(i)
            Valore(i).Left = VLeft(i)
            Valore(i).Width = VWidth(i)
            Valore(i).Tag = ""
            Valore(i).Visible = False
            Descrizione(i).Visible = False
            Dimensioni(i).Visible = False
        Next
        For j = 0 To 1
            For i = 0 To 31
                Valore(i + 100 * j).Tag = ""
                Valore(i + 100 * j).Visible = False
            Next
            For i = 0 To 31
                Descrizione(i + 100 * j).Tag = ""
                Descrizione(i + 100 * j).Visible = False
            Next
            For i = 0 To 31
                Dimensioni(i + 100 * j).Tag = ""
                Dimensioni(i + 100 * j).Visible = False
            Next
        Next
        For i = 0 To 31
            If Opt(i) Is Nothing Then Exit For
            Opt(i).Visible = False
        Next
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        'Indietro
        Risposta = "Annulla"
        Hide()
        GiaAttivata = False
    End Sub
    Public Sub Rinnova()
        mygraphics.Clear(Color.White)
        x = 0
        y = 0
    End Sub
    Private Sub Command3_Click(ByVal Index As Short)
        'Ottimizza
        Dim iPag As Short
        Dim R As String = ""
        t = TabStrip1.SelectedTab
        Dim Tit As String = getmiotag(t.Tag, 0)
        If Tit.Length > 2 Then
            R = Tit.Substring(Tit.Length - 1) ' VB.Right(t.Tag, Len(t.Tag) - 3)
        Else
            iPag = 1
        End If
        iPag = GlobalRoutines.ValVir(R)
        Panel1.Visible = True
        Select Case Index
            Case 0
                Rinnova()
                Risposta = "Ottimizza"
            Case 1 : Risposta = "Scelta"
        End Select
        O.Chiave = 0
        O.F2F3(iPag, 0, True)
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        If PiastraB Then
            O.SetPiastra(1, False)
        Else
            O.SetPiastra(2, False)
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If O.Rear = 1 Then
            Risposta = "Scambia"
            TabStrip1_ClickEvent(TabStrip1, New System.EventArgs)
        Else
            Risposta = "Sw"
            If InStr(getmiotag(TabStrip1.SelectedTab.Tag, 0), "Sint") > 0 Then Risposta = "SwSi"
            '  Chiusa = True
            Hide()
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub frmRis_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        GiaDetto = False
        Risposta = ""
        If Not GiaAttivata And TabStrip1.Visible Then
            TabStrip1.SelectedTab = TabStrip1.TabPages(0)
            TabStrip1_ClickEvent(Me, New EventArgs)
        End If
        GiaAttivata = True
    End Sub
    Friend Sub TracciaTesto(ByVal t As String)
        mygraphics.DrawString(t, myfont, mybrush, x, y)
        y += CarHeight
    End Sub
    Public Sub Button_Click(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        OptClick(Index, True)
    End Sub
    Private Sub OptAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptAll.Click
        Dim i As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        ModeGiunto = 1
        For i = 0 To 31
            If IsNothing(Opt(i)) Then Exit For
            If Opt(i).Visible Then OptClick(i, False)
        Next
        ModeGiunto = 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub TabStrip1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TabStrip1.Click
        Dim t As TabPage
        Dim i As Short
        Dim iPag As Short
        Dim R As String
        Dim Res As Short
        t = TabStrip1.SelectedTab
        _Command3_0.Visible = False
        _Command3_1.Visible = False
        Command4.Visible = False
        cmdFattUs.Visible = False
        cmdDilat.Visible = False
        cmdDilat.Left = cmdFattUs.Left
        cmdOptim.Visible = False
        O.Chiave = 0
        AltriDati = False
        Dim Tit As String = getmiotag(t.Tag, 0)
        If InStr(Tit, "Dati") > 0 Then
            PiastraB = False
            R = Tit.Substring(4) ' VB.Right(Tit, Len(Tit) - 4)
            iPag = GlobalRoutines.ValVir(R)
            Panel1.Visible = False
            t.Controls.Add(Picture2)
            O.RefreshVideo(iPag)
        ElseIf InStr(Tit, "Altri") > 0 Then
            PiastraB = False
            AltriDati = True
            R = Tit.Substring(Tit.Length - 2) ' VB.Right(Tit, 2)
            iPag = GlobalRoutines.ValVir(R)
            Panel1.Visible = False
            t.Controls.Add(Picture3)
            O.RefreshVideo(iPag)
        ElseIf InStr(Tit, "Ris") > 0 Then
            Rinnova()
            R = Tit.Substring(3) ' VB.Right(Tit, Len(Tit) - 3)
            iPag = GlobalRoutines.ValVir(R)
            Panel1.Visible = True
            If O.Rear = 1 Or O.Rear = 2 And O.CalcoloInCorso = 1 Then
                _Command3_0.Visible = O.Rear = 1
                _Command3_1.Visible = True
            End If
            If Not Risposta = "Scambia" Then Risposta = "Visualizza"
            Res = O.F2F3(iPag, 0, True)
        ElseIf InStr(Tit, "Giu") > 0 Then
            O.SetPiastra(1, False)
            '      PiastraB = False
            cmdDilat.Visible = O.TipoDilatp <> 7
            Rinnova()
            R = Tit.Substring(3) ' VB.Right(Tit, Len(Tit) - 3)
            iPag = GlobalRoutines.ValVir(R)
            Panel1.Visible = True
            Risposta = "Visualizza"
            Res = O.F2F3(iPag, 0)
            If Not Res = 3 Then Res = O.F2F3(iPag, -1)
            If Not Res = 3 Then Call O.objDilat.DisplayDilat(1, iPag, O.TipoDilatp)
        ElseIf InStr(Tit, "Man") > 0 Then
            O.SetPiastra(1, False)
            '      PiastraB = False
            Rinnova()
            R = Tit.Substring(3) ' VB.Right(Tit, Len(Tit) - 3)
            iPag = GlobalRoutines.ValVir(R)
            Panel1.Visible = True
            Risposta = "Visualizza"
            Res = O.F2F3(iPag, 0)
            If Not Res = 3 Then Res = O.F2F3(iPag, -1)
        ElseIf InStr(Tit, "Sint") > 0 Then
            ' PiastraB = False
            cmdFattUs.Visible = True
            If O.Zp(1, 26) > 0 And O.Rear = 1 Then
                cmdDilat.Visible = O.TipoDilatp <> 7
                cmdDilat.Left = cmdFattUs.Left
                cmdDilat.Top = cmdFattUs.Top + 1.1 * cmdFattUs.Height
            End If
            Rinnova()
            Panel1.Visible = True
            i = 1 : If InStr(Tit, "2") > 0 Then i = 5
            Risposta = "Visualizza"
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Res = O.F2F3(0, i)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        ElseIf InStr(Tit, "SiDi") > 0 Then
            PiastraB = False
            cmdFattUs.Visible = True
            If O.Zp(1, 26) > 0 Then
                cmdDilat.Visible = O.TipoDilatp <> 7
                cmdDilat.Left = cmdFattUs.Left 'cmdDilat.Left - 1.1 * cmdDilat.Width
                cmdDilat.Top = cmdFattUs.Top + 1.1 * cmdFattUs.Height
                cmdOptim.Visible = True
                cmdOptim.Left = cmdFattUs.Left 'cmdDilat.Left - 1.1 * cmdOptim.Width
                cmdOptim.Top = cmdFattUs.Top + 2.2 * cmdFattUs.Height
            End If
            Rinnova()
            Panel1.Visible = True
            i = 1 : If InStr(Tit, "2") > 0 Then i = 5
            Risposta = "Visualizza"
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Res = O.F2F3(0, i)
            O.objDilat.SintDil(O.Zp(1, 261), O.TipoDilatp, i)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
        Picture1.Refresh()
    End Sub
    Public Sub Text_Leave(ByVal Nome As String)

    End Sub
    Public Sub Text_Enter(ByVal Nome As String)

    End Sub
    Public Sub Text_Changed(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        If Textnum.EndsWith("1") Then Index += 100
        O.AggValori(Index)
        O.Ricalcola = True
    End Sub

    Public Sub Scrivi(ByRef t As String, Optional ByRef locy As Integer = -1, Optional ByRef locx As Integer = -1, Optional ByRef mode As Integer = -1, Optional ByRef PunVir As Boolean = False)
        Static sx, sY As Single
        Dim xx, yy As Single
        Dim Cont As Boolean
        Dim Lunghezza As Single = MisuraStringa(t).Width
        If Not PunVir Then
            If locy > -1 Then
                y = locy * CarHeight
                Cont = False
            Else
                Cont = True
            End If
            If locx > 0 Then x = MisuraStringa(New String("A"c, CInt(locx))).Width
            If Cont Then
                x = sx
                y = sY
            End If
        End If
        If mode > -1 Then
            If PunVir Then
                If mode = 1 Then
                    mybrush.Color = Color.LightCoral
                    mygraphics.FillRectangle(mybrush, New RectangleF(x, y, Lunghezza, CarHeight))
                    mybrush.Color = Color.Black
                End If
            Else
                If mode = 1 Then
                    If Cont Then
                        xx = sx / CarWidth
                        yy = sY / CarHeight
                    Else
                        yy = locy
                    End If
                    mybrush.Color = Color.LightCoral
                    mygraphics.FillRectangle(mybrush, New RectangleF(x, yy * CarHeight, Lunghezza, CarHeight))
                    mybrush.Color = Color.Black
                    y = yy * CarHeight
                End If
            End If
        End If
        If Not PunVir Then
            sx = x + Lunghezza
            sY = y
        End If
        mygraphics.DrawString(t, myfont, mybrush, x, y)
    End Sub
    Private Sub OptClick(ByRef Index As Short, ByRef dimmi As Boolean)
        Dim Ind As Short
        Try
5:          Ind = GlobalRoutines.ValVir(Opt(Index).Tag)
            Select Case Ind
                Case 33, 32, 269, 270 'momento al serraggio
10:                 O.LeggiTab(2, Ind)
12:                 O.AggTxt(Ind)
                Case 36, 37
                    If O.TipoDilatp = 7 Then
                        MessageBox.Show("E' stato impostato un dilatatore con imputazione manuale della costante elastica")
                    End If
20:                 O.SjCalc(Ind) 'Sj
22:                 O.AggTxt(36)
                    O.AggTxt(37)
                Case 274, 275 : kLato = 1
30:                 O.LeggiSigma(2, Ind) 'ammiss dilat'snerv dil
32:                 O.AggTxt(Ind)
                    kLato = 3
                Case 276, 278, 280 : kLato = 1
40:                 O.LeggiSigma(2, Ind) 'ammiss rinf coll
42:                 O.AggTxt(Ind)
                    kLato = 3
                Case 8, 277, 279, 287 : kLato = 1
50:                 O.LeggiTab(2, Ind) 'E anelli
52:                 O.AggTxt(Ind)
                    kLato = 3
                Case 12 : kLato = 1
60:                 O.LeggiSigma(2, Ind) 'ammiss.mant.
62:                 O.AggTxt(Ind)
                    kLato = 3
                Case 35, 266 'piastra
70:                 O.LeggiSigma(2, Ind)
72:                 O.AggTxt(Ind)
                Case 13, 38 'amm. tubi.snerv tubi
80:                 O.LeggiSigma(2, Ind)
82:                 O.AggTxt(Ind)
                Case 7, 8, 9, 14, 15, 267
                    O.LeggiTab(2, Ind)
90:                 O.AggTxt(Ind)
                Case 259, 260 : kLato = 1
100:                O.Zp(0, Ind) = 0
                    O.LeggiSigma(2, Ind) ' Ammiss a compr. mant nuovo e corr
102:                O.AggTxt(Ind)
                    kLato = 3
                Case 285
110:                O.CarGiunto(ModeGiunto)
112:                O.AggTxt(285) 'giunto
                Case 747 'temp. des piastra
                    Avverti(dimmi)
                Case 777 'temp des shell
                    Aggdestemp(True, 1)
                    O.AggTxt(Ind)
                Case 764 'temp des tubi
                    Aggdestemp(True, 2)
                    O.AggTxt(Ind)
                Case 322 'temp des channel A
                    Aggdestemp(True, 3)
                    O.AggTxt(Ind)
                Case 1322 'temp des channel B
                    Aggdestemp(True, 4)
                    O.AggTxt(Ind)
                Case 324 'alfa channel A
                    Aggdestemp(True, 3)
                    If dimmi Then O.LeggiTab(2, Ind)
                    O.AggTxt(Ind)
                Case 1324 'alfa channel B
                    Aggdestemp(True, 4)
                    If dimmi Then O.LeggiTab(2, Ind - 1000)
                    O.AggTxt(Ind)
                Case 1 'p op LM
                    Aggdespres(True, 1)
                    O.AggTxt(Ind)
                Case 2 'p op LT
                    Aggdespres(True, 2)
                    O.AggTxt(Ind)
                Case 4 'T op PT
                    Avverti(dimmi)
                Case 5 'T op Shel
                    Avverti(dimmi)
                Case Else
                    Avverti(dimmi)
            End Select
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Avverti(ByVal dimmi As Boolean)
        If Not dimmi Then Exit Sub
        Dim Testo As String = "Per questa variabile non è disponibile una procedura" & vbCrLf
        Testo = Testo & "di aggiornamento o calcolo automatico." & vbCrLf
        Testo = Testo & "Fornire il valore manualmente"
        MessageBox.Show(Testo)
    End Sub
    Private Sub TabStrip1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabStrip1.DrawItem
        Dim fntTab As Font
        Dim bshBack As Brush
        Dim bshFore As Brush

        If getmiotag(CStr(TabStrip1.TabPages(e.Index).Tag), 1) = "rosso" Then
            fntTab = New Font(e.Font, FontStyle.Bold)
            bshBack = New System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
            bshFore = Brushes.Red
            '				//bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.LightSkyBlue , Color.LightGreen, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
            '				//bshFore = Brushes.Blue;
        Else
            fntTab = e.Font
            bshBack = New SolidBrush(SystemColors.Control)
            bshFore = New SolidBrush(Color.Black)

            '				//bshBack = new SolidBrush(Color.White);
            '				//bshFore = new SolidBrush(Color.Black);
        End If
        Dim tabName As String = TabStrip1.TabPages(e.Index).Text
        Dim sftTab As StringFormat = New StringFormat
        e.Graphics.FillRectangle(bshBack, e.Bounds)
        Dim x As Single = e.Bounds.X
        Dim y As Single = e.Bounds.Y
        e.Graphics.DrawString(tabName, fntTab, bshFore, x, y, sftTab)
    End Sub

    Private Sub _Command3_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command3_0.Click
        Command3_Click(0)
    End Sub

    Private Sub _Command3_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command3_1.Click
        Command3_Click(1)
    End Sub

    Private Sub frmRis_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Risposta = "" Then Risposta = "Annulla"
    End Sub
End Class