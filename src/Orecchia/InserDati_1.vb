Option Strict Off
Option Explicit On 
Imports RoutBase1
Friend Class InserDati_1
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'Chiamata richiesta dalla progettazione Windows Form.
		InitializeComponent()
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
    Public WithEvents Titolo As System.Windows.Forms.Label
    Public WithEvents _mnuFile0_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile0_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile0_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile0_3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents CommonDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Public WithEvents t2t As System.Windows.Forms.TextBox
    Public WithEvents llt As System.Windows.Forms.TextBox
    Public WithEvents l7t As System.Windows.Forms.TextBox
    Public WithEvents t3t As System.Windows.Forms.TextBox
    Public WithEvents Kt As System.Windows.Forms.TextBox
    Public WithEvents Gt As System.Windows.Forms.TextBox
    Public WithEvents Et1 As System.Windows.Forms.TextBox
    Public WithEvents Ft As System.Windows.Forms.TextBox
    Public WithEvents l3t As System.Windows.Forms.TextBox
    Public WithEvents l6t As System.Windows.Forms.TextBox
    Public WithEvents t1t As System.Windows.Forms.TextBox
    Public WithEvents dt As System.Windows.Forms.TextBox
    Public WithEvents d1t As System.Windows.Forms.TextBox
    Public WithEvents Rt As System.Windows.Forms.TextBox
    Public WithEvents At As System.Windows.Forms.TextBox
    Public WithEvents Ht As System.Windows.Forms.TextBox
    Public WithEvents tt As System.Windows.Forms.TextBox
    Public WithEvents Tst As System.Windows.Forms.TextBox
    Public WithEvents dit As System.Windows.Forms.TextBox
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents We2t As System.Windows.Forms.TextBox
    Public WithEvents dft As System.Windows.Forms.TextBox
    Public WithEvents R1t As System.Windows.Forms.TextBox
    Public WithEvents L10t As System.Windows.Forms.TextBox
    Public WithEvents t4t As System.Windows.Forms.TextBox
    Public WithEvents l2t As System.Windows.Forms.TextBox
    Public WithEvents l1t As System.Windows.Forms.TextBox
    Public WithEvents Qt As System.Windows.Forms.TextBox
    Public WithEvents B2t As System.Windows.Forms.TextBox
    Public WithEvents B1t As System.Windows.Forms.TextBox
    Public WithEvents alphat As System.Windows.Forms.TextBox
    Public WithEvents et2 As System.Windows.Forms.TextBox
    Public WithEvents wt As System.Windows.Forms.TextBox
    Public WithEvents Image2 As System.Windows.Forms.PictureBox
    Public WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_3 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
    Public WithEvents _Textcil_4 As System.Windows.Forms.TextBox
    Public WithEvents _Textcil_3 As System.Windows.Forms.TextBox
    Public WithEvents _Textcil_2 As System.Windows.Forms.TextBox
    Public WithEvents _Textcil_1 As System.Windows.Forms.TextBox
    Public WithEvents sy1t As System.Windows.Forms.TextBox
    Public WithEvents sa1t As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _Textcil_0 As System.Windows.Forms.TextBox
    Public WithEvents Cancella As System.Windows.Forms.Button
    Public WithEvents List_err As System.Windows.Forms.ListBox
    Public WithEvents cmdStampa As System.Windows.Forms.Button
    Public WithEvents Calcola As System.Windows.Forms.Button
    Public WithEvents sy5t As System.Windows.Forms.TextBox
    Public WithEvents sa5t As System.Windows.Forms.TextBox
    Public WithEvents sy4t As System.Windows.Forms.TextBox
    Public WithEvents sa4t As System.Windows.Forms.TextBox
    Public WithEvents sy3t As System.Windows.Forms.TextBox
    Public WithEvents sa3t As System.Windows.Forms.TextBox
    Public WithEvents sy2t As System.Windows.Forms.TextBox
    Public WithEvents sa2t As System.Windows.Forms.TextBox
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Resoconto As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents Label45 As System.Windows.Forms.Label
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents mnuCalcola As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRapporto As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InserDati_1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me.Cancella = New System.Windows.Forms.Button
        Me.List_err = New System.Windows.Forms.ListBox
        Me.cmdStampa = New System.Windows.Forms.Button
        Me.Calcola = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Titolo = New System.Windows.Forms.Label
        Me._mnuFile0_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile0_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile0_2 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile0_3 = New System.Windows.Forms.ToolStripMenuItem
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.CommonDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.t2t = New System.Windows.Forms.TextBox
        Me.llt = New System.Windows.Forms.TextBox
        Me.l7t = New System.Windows.Forms.TextBox
        Me.t3t = New System.Windows.Forms.TextBox
        Me.Kt = New System.Windows.Forms.TextBox
        Me.Gt = New System.Windows.Forms.TextBox
        Me.Et1 = New System.Windows.Forms.TextBox
        Me.Ft = New System.Windows.Forms.TextBox
        Me.l3t = New System.Windows.Forms.TextBox
        Me.l6t = New System.Windows.Forms.TextBox
        Me.t1t = New System.Windows.Forms.TextBox
        Me.dt = New System.Windows.Forms.TextBox
        Me.d1t = New System.Windows.Forms.TextBox
        Me.Rt = New System.Windows.Forms.TextBox
        Me.At = New System.Windows.Forms.TextBox
        Me.Ht = New System.Windows.Forms.TextBox
        Me.tt = New System.Windows.Forms.TextBox
        Me.Tst = New System.Windows.Forms.TextBox
        Me.dit = New System.Windows.Forms.TextBox
        Me.Image1 = New System.Windows.Forms.PictureBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.We2t = New System.Windows.Forms.TextBox
        Me.dft = New System.Windows.Forms.TextBox
        Me.R1t = New System.Windows.Forms.TextBox
        Me.L10t = New System.Windows.Forms.TextBox
        Me.t4t = New System.Windows.Forms.TextBox
        Me.l2t = New System.Windows.Forms.TextBox
        Me.l1t = New System.Windows.Forms.TextBox
        Me.Qt = New System.Windows.Forms.TextBox
        Me.B2t = New System.Windows.Forms.TextBox
        Me.B1t = New System.Windows.Forms.TextBox
        Me.alphat = New System.Windows.Forms.TextBox
        Me.et2 = New System.Windows.Forms.TextBox
        Me.wt = New System.Windows.Forms.TextBox
        Me.Image2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me._Textcil_4 = New System.Windows.Forms.TextBox
        Me._Textcil_3 = New System.Windows.Forms.TextBox
        Me._Textcil_2 = New System.Windows.Forms.TextBox
        Me._Textcil_1 = New System.Windows.Forms.TextBox
        Me.sy1t = New System.Windows.Forms.TextBox
        Me.sa1t = New System.Windows.Forms.TextBox
        Me._Textcil_0 = New System.Windows.Forms.TextBox
        Me.sy5t = New System.Windows.Forms.TextBox
        Me.sa5t = New System.Windows.Forms.TextBox
        Me.sy4t = New System.Windows.Forms.TextBox
        Me.sa4t = New System.Windows.Forms.TextBox
        Me.sy3t = New System.Windows.Forms.TextBox
        Me.sa3t = New System.Windows.Forms.TextBox
        Me.sy2t = New System.Windows.Forms.TextBox
        Me.sa2t = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Resoconto = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.mnuCalcola = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRapporto = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(372, 367)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 84
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_4, "Inserisci il materiale relativo all'orecchia inferiore")
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(372, 279)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_3.TabIndex = 83
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_3, "Inserisci il materiale relativo al rinforzo")
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(372, 191)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 82
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_2, "Inserisci il materiale relativo alla nervatura")
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(372, 103)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 81
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_1, "Inserisci il materiale relativo all'orecchia superiore")
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(372, 15)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 76
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_0, "Inserisci il materiale re")
        '
        'Cancella
        '
        Me.Cancella.BackColor = System.Drawing.SystemColors.Control
        Me.Cancella.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancella.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancella.Location = New System.Drawing.Point(656, 304)
        Me.Cancella.Name = "Cancella"
        Me.Cancella.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancella.Size = New System.Drawing.Size(89, 33)
        Me.Cancella.TabIndex = 72
        Me.Cancella.Text = "Cancella"
        Me.ToolTip1.SetToolTip(Me.Cancella, "Cancella i valori della lista")
        '
        'List_err
        '
        Me.List_err.BackColor = System.Drawing.SystemColors.Window
        Me.List_err.Cursor = System.Windows.Forms.Cursors.Default
        Me.List_err.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List_err.HorizontalScrollbar = True
        Me.List_err.Location = New System.Drawing.Point(396, 15)
        Me.List_err.Name = "List_err"
        Me.List_err.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List_err.Size = New System.Drawing.Size(352, 277)
        Me.List_err.TabIndex = 74
        Me.ToolTip1.SetToolTip(Me.List_err, "Visualizza gli eventuali errori")
        '
        'cmdStampa
        '
        Me.cmdStampa.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStampa.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStampa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStampa.Location = New System.Drawing.Point(664, 472)
        Me.cmdStampa.Name = "cmdStampa"
        Me.cmdStampa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStampa.Size = New System.Drawing.Size(89, 25)
        Me.cmdStampa.TabIndex = 70
        Me.cmdStampa.Text = "Rapporto"
        Me.ToolTip1.SetToolTip(Me.cmdStampa, "Stampa il calcolo")
        '
        'Calcola
        '
        Me.Calcola.BackColor = System.Drawing.SystemColors.Control
        Me.Calcola.Cursor = System.Windows.Forms.Cursors.Default
        Me.Calcola.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Calcola.Location = New System.Drawing.Point(552, 472)
        Me.Calcola.Name = "Calcola"
        Me.Calcola.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Calcola.Size = New System.Drawing.Size(89, 25)
        Me.Calcola.TabIndex = 69
        Me.Calcola.Text = "Calcola"
        Me.ToolTip1.SetToolTip(Me.Calcola, "Calcola se l'orecchia può resistere")
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(25, 171)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(201, 16)
        Me.Label28.TabIndex = 35
        Me.Label28.Text = "Max. angolo soll. vert.    theta2             °"
        Me.ToolTip1.SetToolTip(Me.Label28, "vedi figura sulla prima scheda")
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(25, 147)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(204, 16)
        Me.Label29.TabIndex = 34
        Me.Label29.Text = "Max. angolo soll. oriz.     theta1             °"
        Me.ToolTip1.SetToolTip(Me.Label29, "vedi figura a fianco")
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(25, 123)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(201, 16)
        Me.Label30.TabIndex = 33
        Me.Label30.Text = "Angolo nervatura           alpha               °"
        Me.ToolTip1.SetToolTip(Me.Label30, "vedi figura sulla prima scheda")
        '
        'Titolo
        '
        Me.Titolo.AutoSize = True
        Me.Titolo.BackColor = System.Drawing.SystemColors.Control
        Me.Titolo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Titolo.Cursor = System.Windows.Forms.Cursors.Default
        Me.Titolo.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titolo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Titolo.Location = New System.Drawing.Point(142, 0)
        Me.Titolo.Name = "Titolo"
        Me.Titolo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Titolo.Size = New System.Drawing.Size(434, 31)
        Me.Titolo.TabIndex = 0
        Me.Titolo.Text = "CALCOLO ORECCHIE DI SOLLEVAMENTO"
        Me.Titolo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_mnuFile0_0
        '

        Me._mnuFile0_0.Text = "Apri"
        '
        '_mnuFile0_1
        '

        Me._mnuFile0_1.Text = "Salva"
        '
        '_mnuFile0_2
        '

        Me._mnuFile0_2.Text = "Salva Come"
        '
        '_mnuFile0_3
        '

        Me._mnuFile0_3.Text = "Esci"
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuFile, Me.MenuItem1, Me.MenuItem2})
        '
        'mnuFile
        '

        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me._mnuFile0_0, Me._mnuFile0_1, Me._mnuFile0_2, Me._mnuFile0_3})
        Me.mnuFile.Text = "File"
        '
        'MenuItem1
        '

        Me.MenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuCalcola, Me.mnuRapporto})
        Me.MenuItem1.Text = "Azioni"
        '
        'MenuItem2
        '

        Me.MenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem2.Text = "?"
        '
        'MenuItem3
        '

        Me.MenuItem3.Text = "Guida"
        '
        'MenuItem4
        '

        Me.MenuItem4.Text = "Informazioni"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(8, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 536)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.t2t)
        Me.TabPage1.Controls.Add(Me.llt)
        Me.TabPage1.Controls.Add(Me.l7t)
        Me.TabPage1.Controls.Add(Me.t3t)
        Me.TabPage1.Controls.Add(Me.Kt)
        Me.TabPage1.Controls.Add(Me.Gt)
        Me.TabPage1.Controls.Add(Me.Et1)
        Me.TabPage1.Controls.Add(Me.Ft)
        Me.TabPage1.Controls.Add(Me.l3t)
        Me.TabPage1.Controls.Add(Me.l6t)
        Me.TabPage1.Controls.Add(Me.t1t)
        Me.TabPage1.Controls.Add(Me.dt)
        Me.TabPage1.Controls.Add(Me.d1t)
        Me.TabPage1.Controls.Add(Me.Rt)
        Me.TabPage1.Controls.Add(Me.At)
        Me.TabPage1.Controls.Add(Me.Ht)
        Me.TabPage1.Controls.Add(Me.tt)
        Me.TabPage1.Controls.Add(Me.Tst)
        Me.TabPage1.Controls.Add(Me.dit)
        Me.TabPage1.Controls.Add(Me.Image1)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(768, 510)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Orecchie di testa"
        '
        't2t
        '
        Me.t2t.AcceptsReturn = True
        Me.t2t.AutoSize = False
        Me.t2t.BackColor = System.Drawing.SystemColors.Window
        Me.t2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.t2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.t2t.Location = New System.Drawing.Point(200, 464)
        Me.t2t.MaxLength = 0
        Me.t2t.Name = "t2t"
        Me.t2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.t2t.Size = New System.Drawing.Size(97, 19)
        Me.t2t.TabIndex = 82
        Me.t2t.Text = ""
        '
        'llt
        '
        Me.llt.AcceptsReturn = True
        Me.llt.AutoSize = False
        Me.llt.BackColor = System.Drawing.SystemColors.Window
        Me.llt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.llt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.llt.Location = New System.Drawing.Point(200, 440)
        Me.llt.MaxLength = 0
        Me.llt.Name = "llt"
        Me.llt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.llt.Size = New System.Drawing.Size(97, 19)
        Me.llt.TabIndex = 81
        Me.llt.Text = ""
        '
        'l7t
        '
        Me.l7t.AcceptsReturn = True
        Me.l7t.AutoSize = False
        Me.l7t.BackColor = System.Drawing.SystemColors.Window
        Me.l7t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.l7t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.l7t.Location = New System.Drawing.Point(200, 416)
        Me.l7t.MaxLength = 0
        Me.l7t.Name = "l7t"
        Me.l7t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.l7t.Size = New System.Drawing.Size(97, 19)
        Me.l7t.TabIndex = 80
        Me.l7t.Text = ""
        '
        't3t
        '
        Me.t3t.AcceptsReturn = True
        Me.t3t.AutoSize = False
        Me.t3t.BackColor = System.Drawing.SystemColors.Window
        Me.t3t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.t3t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.t3t.Location = New System.Drawing.Point(200, 392)
        Me.t3t.MaxLength = 0
        Me.t3t.Name = "t3t"
        Me.t3t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.t3t.Size = New System.Drawing.Size(97, 19)
        Me.t3t.TabIndex = 79
        Me.t3t.Text = ""
        '
        'Kt
        '
        Me.Kt.AcceptsReturn = True
        Me.Kt.AutoSize = False
        Me.Kt.BackColor = System.Drawing.SystemColors.Window
        Me.Kt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Kt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Kt.Location = New System.Drawing.Point(200, 368)
        Me.Kt.MaxLength = 0
        Me.Kt.Name = "Kt"
        Me.Kt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Kt.Size = New System.Drawing.Size(97, 19)
        Me.Kt.TabIndex = 78
        Me.Kt.Text = ""
        '
        'Gt
        '
        Me.Gt.AcceptsReturn = True
        Me.Gt.AutoSize = False
        Me.Gt.BackColor = System.Drawing.SystemColors.Window
        Me.Gt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Gt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Gt.Location = New System.Drawing.Point(200, 344)
        Me.Gt.MaxLength = 0
        Me.Gt.Name = "Gt"
        Me.Gt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Gt.Size = New System.Drawing.Size(97, 19)
        Me.Gt.TabIndex = 77
        Me.Gt.Text = ""
        '
        'Et1
        '
        Me.Et1.AcceptsReturn = True
        Me.Et1.AutoSize = False
        Me.Et1.BackColor = System.Drawing.SystemColors.Window
        Me.Et1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Et1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Et1.Location = New System.Drawing.Point(200, 320)
        Me.Et1.MaxLength = 0
        Me.Et1.Name = "Et1"
        Me.Et1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Et1.Size = New System.Drawing.Size(97, 19)
        Me.Et1.TabIndex = 76
        Me.Et1.Text = ""
        '
        'Ft
        '
        Me.Ft.AcceptsReturn = True
        Me.Ft.AutoSize = False
        Me.Ft.BackColor = System.Drawing.SystemColors.Window
        Me.Ft.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ft.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ft.Location = New System.Drawing.Point(200, 296)
        Me.Ft.MaxLength = 0
        Me.Ft.Name = "Ft"
        Me.Ft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ft.Size = New System.Drawing.Size(97, 19)
        Me.Ft.TabIndex = 75
        Me.Ft.Text = ""
        '
        'l3t
        '
        Me.l3t.AcceptsReturn = True
        Me.l3t.AutoSize = False
        Me.l3t.BackColor = System.Drawing.SystemColors.Window
        Me.l3t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.l3t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.l3t.Location = New System.Drawing.Point(200, 272)
        Me.l3t.MaxLength = 0
        Me.l3t.Name = "l3t"
        Me.l3t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.l3t.Size = New System.Drawing.Size(97, 19)
        Me.l3t.TabIndex = 74
        Me.l3t.Text = ""
        '
        'l6t
        '
        Me.l6t.AcceptsReturn = True
        Me.l6t.AutoSize = False
        Me.l6t.BackColor = System.Drawing.SystemColors.Window
        Me.l6t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.l6t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.l6t.Location = New System.Drawing.Point(200, 248)
        Me.l6t.MaxLength = 0
        Me.l6t.Name = "l6t"
        Me.l6t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.l6t.Size = New System.Drawing.Size(97, 19)
        Me.l6t.TabIndex = 73
        Me.l6t.Text = ""
        '
        't1t
        '
        Me.t1t.AcceptsReturn = True
        Me.t1t.AutoSize = False
        Me.t1t.BackColor = System.Drawing.SystemColors.Window
        Me.t1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.t1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.t1t.Location = New System.Drawing.Point(200, 224)
        Me.t1t.MaxLength = 0
        Me.t1t.Name = "t1t"
        Me.t1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.t1t.Size = New System.Drawing.Size(97, 19)
        Me.t1t.TabIndex = 72
        Me.t1t.Text = ""
        '
        'dt
        '
        Me.dt.AcceptsReturn = True
        Me.dt.AutoSize = False
        Me.dt.BackColor = System.Drawing.SystemColors.Window
        Me.dt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dt.Location = New System.Drawing.Point(200, 200)
        Me.dt.MaxLength = 0
        Me.dt.Name = "dt"
        Me.dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dt.Size = New System.Drawing.Size(97, 19)
        Me.dt.TabIndex = 71
        Me.dt.Text = ""
        '
        'd1t
        '
        Me.d1t.AcceptsReturn = True
        Me.d1t.AutoSize = False
        Me.d1t.BackColor = System.Drawing.SystemColors.Window
        Me.d1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.d1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.d1t.Location = New System.Drawing.Point(200, 176)
        Me.d1t.MaxLength = 0
        Me.d1t.Name = "d1t"
        Me.d1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.d1t.Size = New System.Drawing.Size(97, 19)
        Me.d1t.TabIndex = 70
        Me.d1t.Text = ""
        '
        'Rt
        '
        Me.Rt.AcceptsReturn = True
        Me.Rt.AutoSize = False
        Me.Rt.BackColor = System.Drawing.SystemColors.Window
        Me.Rt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Rt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Rt.Location = New System.Drawing.Point(200, 152)
        Me.Rt.MaxLength = 0
        Me.Rt.Name = "Rt"
        Me.Rt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Rt.Size = New System.Drawing.Size(97, 19)
        Me.Rt.TabIndex = 69
        Me.Rt.Text = ""
        '
        'At
        '
        Me.At.AcceptsReturn = True
        Me.At.AutoSize = False
        Me.At.BackColor = System.Drawing.SystemColors.Window
        Me.At.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.At.ForeColor = System.Drawing.SystemColors.WindowText
        Me.At.Location = New System.Drawing.Point(200, 128)
        Me.At.MaxLength = 0
        Me.At.Name = "At"
        Me.At.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.At.Size = New System.Drawing.Size(97, 19)
        Me.At.TabIndex = 68
        Me.At.Text = ""
        '
        'Ht
        '
        Me.Ht.AcceptsReturn = True
        Me.Ht.AutoSize = False
        Me.Ht.BackColor = System.Drawing.SystemColors.Window
        Me.Ht.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ht.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ht.Location = New System.Drawing.Point(200, 104)
        Me.Ht.MaxLength = 0
        Me.Ht.Name = "Ht"
        Me.Ht.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ht.Size = New System.Drawing.Size(97, 19)
        Me.Ht.TabIndex = 67
        Me.Ht.Text = ""
        '
        'tt
        '
        Me.tt.AcceptsReturn = True
        Me.tt.AutoSize = False
        Me.tt.BackColor = System.Drawing.SystemColors.Window
        Me.tt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tt.Location = New System.Drawing.Point(200, 80)
        Me.tt.MaxLength = 0
        Me.tt.Name = "tt"
        Me.tt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tt.Size = New System.Drawing.Size(97, 19)
        Me.tt.TabIndex = 66
        Me.tt.Text = ""
        '
        'Tst
        '
        Me.Tst.AcceptsReturn = True
        Me.Tst.AutoSize = False
        Me.Tst.BackColor = System.Drawing.SystemColors.Window
        Me.Tst.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Tst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Tst.Location = New System.Drawing.Point(200, 56)
        Me.Tst.MaxLength = 0
        Me.Tst.Name = "Tst"
        Me.Tst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tst.Size = New System.Drawing.Size(97, 19)
        Me.Tst.TabIndex = 65
        Me.Tst.Text = ""
        '
        'dit
        '
        Me.dit.AcceptsReturn = True
        Me.dit.AutoSize = False
        Me.dit.BackColor = System.Drawing.SystemColors.Window
        Me.dit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dit.Location = New System.Drawing.Point(200, 32)
        Me.dit.MaxLength = 0
        Me.dit.Name = "dit"
        Me.dit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dit.Size = New System.Drawing.Size(97, 19)
        Me.dit.TabIndex = 64
        Me.dit.Text = ""
        '
        'Image1
        '
        Me.Image1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(336, 80)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(395, 308)
        Me.Image1.TabIndex = 84
        Me.Image1.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(16, 472)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(193, 16)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Spessore rinforzo             t2           mm"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(16, 448)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(193, 16)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Larghezza nervatura        l             mm"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 424)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(192, 16)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Lunghezza nervatura       l7           mm"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(16, 400)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(191, 16)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Spessore nervatura          t3          mm"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(16, 376)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(189, 16)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Larghezza cava               K           mm"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(16, 352)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(189, 16)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Altezza cava                    G           mm"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(16, 328)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(190, 16)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Sviluppo rinforzo               E          mm"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(16, 304)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(192, 16)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Altezza rinforzo                 F           mm"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(16, 280)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(190, 16)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Distanza nerv. / rinf.         l3          mm"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 256)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(190, 16)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Distanza foro / nerv.         l6          mm"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(16, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(191, 16)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Spessore disco                 t1          mm"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 208)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(191, 16)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Diametro foro                    dd         mm"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(193, 16)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Diametro disco rinf.           d1         mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(188, 16)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Raggio orecchia               R          mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(190, 16)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Larghezza orecchia          A          mm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(190, 16)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Altezza tot. orecchia         H          mm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(189, 16)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Spessore orecchia            t           mm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(190, 16)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Spessore Mantello            Ts        mm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(189, 16)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Dia. Int. Mantello               di         mm"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.We2t)
        Me.TabPage2.Controls.Add(Me.dft)
        Me.TabPage2.Controls.Add(Me.R1t)
        Me.TabPage2.Controls.Add(Me.L10t)
        Me.TabPage2.Controls.Add(Me.t4t)
        Me.TabPage2.Controls.Add(Me.l2t)
        Me.TabPage2.Controls.Add(Me.l1t)
        Me.TabPage2.Controls.Add(Me.Qt)
        Me.TabPage2.Controls.Add(Me.B2t)
        Me.TabPage2.Controls.Add(Me.B1t)
        Me.TabPage2.Controls.Add(Me.alphat)
        Me.TabPage2.Controls.Add(Me.et2)
        Me.TabPage2.Controls.Add(Me.wt)
        Me.TabPage2.Controls.Add(Me.Image2)
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(768, 510)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Orecchia di coda"
        '
        'We2t
        '
        Me.We2t.AcceptsReturn = True
        Me.We2t.AutoSize = False
        Me.We2t.BackColor = System.Drawing.SystemColors.Window
        Me.We2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.We2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.We2t.Location = New System.Drawing.Point(233, 363)
        Me.We2t.MaxLength = 0
        Me.We2t.Name = "We2t"
        Me.We2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.We2t.Size = New System.Drawing.Size(97, 19)
        Me.We2t.TabIndex = 56
        Me.We2t.Text = ""
        '
        'dft
        '
        Me.dft.AcceptsReturn = True
        Me.dft.AutoSize = False
        Me.dft.BackColor = System.Drawing.SystemColors.Window
        Me.dft.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dft.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dft.Location = New System.Drawing.Point(233, 339)
        Me.dft.MaxLength = 0
        Me.dft.Name = "dft"
        Me.dft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dft.Size = New System.Drawing.Size(97, 19)
        Me.dft.TabIndex = 55
        Me.dft.Text = ""
        '
        'R1t
        '
        Me.R1t.AcceptsReturn = True
        Me.R1t.AutoSize = False
        Me.R1t.BackColor = System.Drawing.SystemColors.Window
        Me.R1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.R1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.R1t.Location = New System.Drawing.Point(233, 315)
        Me.R1t.MaxLength = 0
        Me.R1t.Name = "R1t"
        Me.R1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.R1t.Size = New System.Drawing.Size(97, 19)
        Me.R1t.TabIndex = 54
        Me.R1t.Text = ""
        '
        'L10t
        '
        Me.L10t.AcceptsReturn = True
        Me.L10t.AutoSize = False
        Me.L10t.BackColor = System.Drawing.SystemColors.Window
        Me.L10t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.L10t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.L10t.Location = New System.Drawing.Point(233, 291)
        Me.L10t.MaxLength = 0
        Me.L10t.Name = "L10t"
        Me.L10t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.L10t.Size = New System.Drawing.Size(97, 19)
        Me.L10t.TabIndex = 53
        Me.L10t.Text = ""
        '
        't4t
        '
        Me.t4t.AcceptsReturn = True
        Me.t4t.AutoSize = False
        Me.t4t.BackColor = System.Drawing.SystemColors.Window
        Me.t4t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.t4t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.t4t.Location = New System.Drawing.Point(233, 267)
        Me.t4t.MaxLength = 0
        Me.t4t.Name = "t4t"
        Me.t4t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.t4t.Size = New System.Drawing.Size(97, 19)
        Me.t4t.TabIndex = 52
        Me.t4t.Text = ""
        '
        'l2t
        '
        Me.l2t.AcceptsReturn = True
        Me.l2t.AutoSize = False
        Me.l2t.BackColor = System.Drawing.SystemColors.Window
        Me.l2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.l2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.l2t.Location = New System.Drawing.Point(233, 243)
        Me.l2t.MaxLength = 0
        Me.l2t.Name = "l2t"
        Me.l2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.l2t.Size = New System.Drawing.Size(97, 19)
        Me.l2t.TabIndex = 51
        Me.l2t.Text = ""
        '
        'l1t
        '
        Me.l1t.AcceptsReturn = True
        Me.l1t.AutoSize = False
        Me.l1t.BackColor = System.Drawing.SystemColors.Window
        Me.l1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.l1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.l1t.Location = New System.Drawing.Point(233, 219)
        Me.l1t.MaxLength = 0
        Me.l1t.Name = "l1t"
        Me.l1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.l1t.Size = New System.Drawing.Size(97, 19)
        Me.l1t.TabIndex = 50
        Me.l1t.Text = ""
        '
        'Qt
        '
        Me.Qt.AcceptsReturn = True
        Me.Qt.AutoSize = False
        Me.Qt.BackColor = System.Drawing.SystemColors.Window
        Me.Qt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Qt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Qt.Location = New System.Drawing.Point(233, 195)
        Me.Qt.MaxLength = 0
        Me.Qt.Name = "Qt"
        Me.Qt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Qt.Size = New System.Drawing.Size(97, 19)
        Me.Qt.TabIndex = 49
        Me.Qt.Text = ""
        '
        'B2t
        '
        Me.B2t.AcceptsReturn = True
        Me.B2t.AutoSize = False
        Me.B2t.BackColor = System.Drawing.SystemColors.Window
        Me.B2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.B2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.B2t.Location = New System.Drawing.Point(233, 171)
        Me.B2t.MaxLength = 0
        Me.B2t.Name = "B2t"
        Me.B2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.B2t.Size = New System.Drawing.Size(97, 19)
        Me.B2t.TabIndex = 48
        Me.B2t.Text = ""
        '
        'B1t
        '
        Me.B1t.AcceptsReturn = True
        Me.B1t.AutoSize = False
        Me.B1t.BackColor = System.Drawing.SystemColors.Window
        Me.B1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.B1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.B1t.Location = New System.Drawing.Point(233, 147)
        Me.B1t.MaxLength = 0
        Me.B1t.Name = "B1t"
        Me.B1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.B1t.Size = New System.Drawing.Size(97, 19)
        Me.B1t.TabIndex = 47
        Me.B1t.Text = ""
        '
        'alphat
        '
        Me.alphat.AcceptsReturn = True
        Me.alphat.AutoSize = False
        Me.alphat.BackColor = System.Drawing.SystemColors.Window
        Me.alphat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.alphat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.alphat.Location = New System.Drawing.Point(233, 123)
        Me.alphat.MaxLength = 0
        Me.alphat.Name = "alphat"
        Me.alphat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.alphat.Size = New System.Drawing.Size(97, 19)
        Me.alphat.TabIndex = 46
        Me.alphat.Text = ""
        '
        'et2
        '
        Me.et2.AcceptsReturn = True
        Me.et2.AutoSize = False
        Me.et2.BackColor = System.Drawing.SystemColors.Window
        Me.et2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.et2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.et2.Location = New System.Drawing.Point(233, 99)
        Me.et2.MaxLength = 0
        Me.et2.Name = "et2"
        Me.et2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.et2.Size = New System.Drawing.Size(97, 19)
        Me.et2.TabIndex = 45
        Me.et2.Text = ""
        '
        'wt
        '
        Me.wt.AcceptsReturn = True
        Me.wt.AutoSize = False
        Me.wt.BackColor = System.Drawing.SystemColors.Window
        Me.wt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.wt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.wt.Location = New System.Drawing.Point(233, 75)
        Me.wt.MaxLength = 0
        Me.wt.Name = "wt"
        Me.wt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.wt.Size = New System.Drawing.Size(97, 19)
        Me.wt.TabIndex = 44
        Me.wt.Text = ""
        '
        'Image2
        '
        Me.Image2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
        Me.Image2.Location = New System.Drawing.Point(345, 219)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(202, 188)
        Me.Image2.TabIndex = 59
        Me.Image2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(345, 75)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(399, 140)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(25, 363)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(199, 16)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Fillet weld leg                   We2         mm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(25, 339)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(209, 16)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Diametro foro                       df             mm"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(25, 315)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(207, 16)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "Raggio orecchia inf.           R1            mm"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(25, 291)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(207, 16)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "Larghezza orecchia           L10           mm"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(25, 267)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(208, 16)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "Spessore orecch. inf.         t4              mm"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(25, 243)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(208, 16)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "Distanza baricentro           L2              mm"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(25, 219)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(206, 16)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "Distanza                            L1              mm"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(25, 195)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(202, 16)
        Me.Label27.TabIndex = 36
        Me.Label27.Text = "Massa apparecchio           W              Kg"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(25, 99)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(203, 16)
        Me.Label31.TabIndex = 32
        Me.Label31.Text = "Efficienza saldatura             we             --"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(25, 75)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(211, 16)
        Me.Label32.TabIndex = 31
        Me.Label32.Text = "Fillet weld leg                       wl             mm"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CheckBox1)
        Me.TabPage3.Controls.Add(Me._cmdCil_4)
        Me.TabPage3.Controls.Add(Me._cmdCil_3)
        Me.TabPage3.Controls.Add(Me._cmdCil_2)
        Me.TabPage3.Controls.Add(Me._cmdCil_1)
        Me.TabPage3.Controls.Add(Me._Textcil_4)
        Me.TabPage3.Controls.Add(Me._Textcil_3)
        Me.TabPage3.Controls.Add(Me._Textcil_2)
        Me.TabPage3.Controls.Add(Me._Textcil_1)
        Me.TabPage3.Controls.Add(Me.sy1t)
        Me.TabPage3.Controls.Add(Me.sa1t)
        Me.TabPage3.Controls.Add(Me._cmdCil_0)
        Me.TabPage3.Controls.Add(Me._Textcil_0)
        Me.TabPage3.Controls.Add(Me.Cancella)
        Me.TabPage3.Controls.Add(Me.List_err)
        Me.TabPage3.Controls.Add(Me.cmdStampa)
        Me.TabPage3.Controls.Add(Me.Calcola)
        Me.TabPage3.Controls.Add(Me.sy5t)
        Me.TabPage3.Controls.Add(Me.sa5t)
        Me.TabPage3.Controls.Add(Me.sy4t)
        Me.TabPage3.Controls.Add(Me.sa4t)
        Me.TabPage3.Controls.Add(Me.sy3t)
        Me.TabPage3.Controls.Add(Me.sa3t)
        Me.TabPage3.Controls.Add(Me.sy2t)
        Me.TabPage3.Controls.Add(Me.sa2t)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.Label34)
        Me.TabPage3.Controls.Add(Me.Label35)
        Me.TabPage3.Controls.Add(Me.Resoconto)
        Me.TabPage3.Controls.Add(Me.Label36)
        Me.TabPage3.Controls.Add(Me.Label37)
        Me.TabPage3.Controls.Add(Me.Label38)
        Me.TabPage3.Controls.Add(Me.Label39)
        Me.TabPage3.Controls.Add(Me.Label40)
        Me.TabPage3.Controls.Add(Me.Label41)
        Me.TabPage3.Controls.Add(Me.Label42)
        Me.TabPage3.Controls.Add(Me.Label43)
        Me.TabPage3.Controls.Add(Me.Label44)
        Me.TabPage3.Controls.Add(Me.Label45)
        Me.TabPage3.Controls.Add(Me.Label46)
        Me.TabPage3.Controls.Add(Me.Label47)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(768, 510)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Materiali e calcolo"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(552, 448)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(200, 16)
        Me.CheckBox1.TabIndex = 86
        Me.CheckBox1.Text = "Rapporto con indice e intestazioni"
        '
        '_Textcil_4
        '
        Me._Textcil_4.AcceptsReturn = True
        Me._Textcil_4.AutoSize = False
        Me._Textcil_4.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_4.Location = New System.Drawing.Point(228, 367)
        Me._Textcil_4.MaxLength = 0
        Me._Textcil_4.Name = "_Textcil_4"
        Me._Textcil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_4.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_4.TabIndex = 80
        Me._Textcil_4.Text = ""
        '
        '_Textcil_3
        '
        Me._Textcil_3.AcceptsReturn = True
        Me._Textcil_3.AutoSize = False
        Me._Textcil_3.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_3.Location = New System.Drawing.Point(228, 279)
        Me._Textcil_3.MaxLength = 0
        Me._Textcil_3.Name = "_Textcil_3"
        Me._Textcil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_3.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_3.TabIndex = 79
        Me._Textcil_3.Text = ""
        '
        '_Textcil_2
        '
        Me._Textcil_2.AcceptsReturn = True
        Me._Textcil_2.AutoSize = False
        Me._Textcil_2.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_2.Location = New System.Drawing.Point(228, 191)
        Me._Textcil_2.MaxLength = 0
        Me._Textcil_2.Name = "_Textcil_2"
        Me._Textcil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_2.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_2.TabIndex = 78
        Me._Textcil_2.Text = ""
        '
        '_Textcil_1
        '
        Me._Textcil_1.AcceptsReturn = True
        Me._Textcil_1.AutoSize = False
        Me._Textcil_1.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_1.Location = New System.Drawing.Point(228, 103)
        Me._Textcil_1.MaxLength = 0
        Me._Textcil_1.Name = "_Textcil_1"
        Me._Textcil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_1.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_1.TabIndex = 77
        Me._Textcil_1.Text = ""
        '
        'sy1t
        '
        Me.sy1t.AcceptsReturn = True
        Me.sy1t.AutoSize = False
        Me.sy1t.BackColor = System.Drawing.SystemColors.Window
        Me.sy1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy1t.Location = New System.Drawing.Point(228, 63)
        Me.sy1t.MaxLength = 0
        Me.sy1t.Name = "sy1t"
        Me.sy1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy1t.Size = New System.Drawing.Size(105, 19)
        Me.sy1t.TabIndex = 60
        Me.sy1t.Text = ""
        '
        'sa1t
        '
        Me.sa1t.AcceptsReturn = True
        Me.sa1t.AutoSize = False
        Me.sa1t.BackColor = System.Drawing.SystemColors.Window
        Me.sa1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa1t.Location = New System.Drawing.Point(228, 39)
        Me.sa1t.MaxLength = 0
        Me.sa1t.Name = "sa1t"
        Me.sa1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa1t.Size = New System.Drawing.Size(105, 19)
        Me.sa1t.TabIndex = 59
        Me.sa1t.Text = ""
        '
        '_Textcil_0
        '
        Me._Textcil_0.AcceptsReturn = True
        Me._Textcil_0.AutoSize = False
        Me._Textcil_0.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_0.Location = New System.Drawing.Point(228, 15)
        Me._Textcil_0.MaxLength = 0
        Me._Textcil_0.Name = "_Textcil_0"
        Me._Textcil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_0.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_0.TabIndex = 75
        Me._Textcil_0.Text = ""
        '
        'sy5t
        '
        Me.sy5t.AcceptsReturn = True
        Me.sy5t.AutoSize = False
        Me.sy5t.BackColor = System.Drawing.SystemColors.Window
        Me.sy5t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy5t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy5t.Location = New System.Drawing.Point(228, 415)
        Me.sy5t.MaxLength = 0
        Me.sy5t.Name = "sy5t"
        Me.sy5t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy5t.Size = New System.Drawing.Size(105, 19)
        Me.sy5t.TabIndex = 68
        Me.sy5t.Text = ""
        '
        'sa5t
        '
        Me.sa5t.AcceptsReturn = True
        Me.sa5t.AutoSize = False
        Me.sa5t.BackColor = System.Drawing.SystemColors.Window
        Me.sa5t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa5t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa5t.Location = New System.Drawing.Point(228, 391)
        Me.sa5t.MaxLength = 0
        Me.sa5t.Name = "sa5t"
        Me.sa5t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa5t.Size = New System.Drawing.Size(105, 19)
        Me.sa5t.TabIndex = 67
        Me.sa5t.Text = ""
        '
        'sy4t
        '
        Me.sy4t.AcceptsReturn = True
        Me.sy4t.AutoSize = False
        Me.sy4t.BackColor = System.Drawing.SystemColors.Window
        Me.sy4t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy4t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy4t.Location = New System.Drawing.Point(228, 327)
        Me.sy4t.MaxLength = 0
        Me.sy4t.Name = "sy4t"
        Me.sy4t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy4t.Size = New System.Drawing.Size(105, 19)
        Me.sy4t.TabIndex = 66
        Me.sy4t.Text = ""
        '
        'sa4t
        '
        Me.sa4t.AcceptsReturn = True
        Me.sa4t.AutoSize = False
        Me.sa4t.BackColor = System.Drawing.SystemColors.Window
        Me.sa4t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa4t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa4t.Location = New System.Drawing.Point(228, 303)
        Me.sa4t.MaxLength = 0
        Me.sa4t.Name = "sa4t"
        Me.sa4t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa4t.Size = New System.Drawing.Size(105, 19)
        Me.sa4t.TabIndex = 65
        Me.sa4t.Text = ""
        '
        'sy3t
        '
        Me.sy3t.AcceptsReturn = True
        Me.sy3t.AutoSize = False
        Me.sy3t.BackColor = System.Drawing.SystemColors.Window
        Me.sy3t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy3t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy3t.Location = New System.Drawing.Point(228, 239)
        Me.sy3t.MaxLength = 0
        Me.sy3t.Name = "sy3t"
        Me.sy3t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy3t.Size = New System.Drawing.Size(105, 19)
        Me.sy3t.TabIndex = 64
        Me.sy3t.Text = ""
        '
        'sa3t
        '
        Me.sa3t.AcceptsReturn = True
        Me.sa3t.AutoSize = False
        Me.sa3t.BackColor = System.Drawing.SystemColors.Window
        Me.sa3t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa3t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa3t.Location = New System.Drawing.Point(228, 215)
        Me.sa3t.MaxLength = 0
        Me.sa3t.Name = "sa3t"
        Me.sa3t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa3t.Size = New System.Drawing.Size(105, 19)
        Me.sa3t.TabIndex = 63
        Me.sa3t.Text = ""
        '
        'sy2t
        '
        Me.sy2t.AcceptsReturn = True
        Me.sy2t.AutoSize = False
        Me.sy2t.BackColor = System.Drawing.SystemColors.Window
        Me.sy2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy2t.Location = New System.Drawing.Point(228, 151)
        Me.sy2t.MaxLength = 0
        Me.sy2t.Name = "sy2t"
        Me.sy2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy2t.Size = New System.Drawing.Size(105, 19)
        Me.sy2t.TabIndex = 62
        Me.sy2t.Text = ""
        '
        'sa2t
        '
        Me.sa2t.AcceptsReturn = True
        Me.sa2t.AutoSize = False
        Me.sa2t.BackColor = System.Drawing.SystemColors.Window
        Me.sa2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa2t.Location = New System.Drawing.Point(228, 127)
        Me.sa2t.MaxLength = 0
        Me.sa2t.Name = "sa2t"
        Me.sa2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa2t.Size = New System.Drawing.Size(105, 19)
        Me.sa2t.TabIndex = 61
        Me.sa2t.Text = ""
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(20, 39)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(199, 16)
        Me.Label33.TabIndex = 46
        Me.Label33.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(20, 63)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(199, 16)
        Me.Label34.TabIndex = 45
        Me.Label34.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.SystemColors.Control
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(20, 15)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(97, 16)
        Me.Label35.TabIndex = 44
        Me.Label35.Text = "Materiale Mantello"
        '
        'Resoconto
        '
        Me.Resoconto.BackColor = System.Drawing.SystemColors.Control
        Me.Resoconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Resoconto.Cursor = System.Windows.Forms.Cursors.Default
        Me.Resoconto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Resoconto.Location = New System.Drawing.Point(24, 464)
        Me.Resoconto.Name = "Resoconto"
        Me.Resoconto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Resoconto.Size = New System.Drawing.Size(289, 25)
        Me.Resoconto.TabIndex = 73
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(20, 391)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(199, 16)
        Me.Label36.TabIndex = 58
        Me.Label36.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(20, 415)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(199, 16)
        Me.Label37.TabIndex = 57
        Me.Label37.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(20, 367)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(103, 16)
        Me.Label38.TabIndex = 56
        Me.Label38.Text = "Materiale orecc. inf."
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(20, 303)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(199, 16)
        Me.Label39.TabIndex = 55
        Me.Label39.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.SystemColors.Control
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(20, 327)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(199, 16)
        Me.Label40.TabIndex = 54
        Me.Label40.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(20, 279)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(92, 16)
        Me.Label41.TabIndex = 53
        Me.Label41.Text = "Materiale rinforzo"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(20, 215)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(199, 16)
        Me.Label42.TabIndex = 52
        Me.Label42.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(20, 239)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(199, 16)
        Me.Label43.TabIndex = 51
        Me.Label43.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(20, 191)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(102, 16)
        Me.Label44.TabIndex = 50
        Me.Label44.Text = "Materiale nervatura"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.SystemColors.Control
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(20, 127)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(199, 16)
        Me.Label45.TabIndex = 49
        Me.Label45.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.SystemColors.Control
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(20, 151)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(199, 16)
        Me.Label46.TabIndex = 48
        Me.Label46.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.SystemColors.Control
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(20, 103)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(97, 16)
        Me.Label47.TabIndex = 47
        Me.Label47.Text = "Materiale orecchia"
        '
        'mnuCalcola
        '

        Me.mnuCalcola.Text = "Calcola"
        '
        'mnuRapporto
        '

        Me.mnuRapporto.Text = "Rapporto"
        '
        'InserDati_1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 585)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Titolo)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 48)
        Me.MaximizeBox = False
        Me.MainMenuStrip = Me.MainMenu1
        Me.Controls.Add(Me.MainMenu1)
        Me.MinimizeBox = False
        Me.Name = "InserDati_1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "OREC"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As InserDati_1
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As InserDati_1
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New InserDati_1()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Private msg As String
    Private temp2 As Short
    Private iPagina As Integer
    Private Sub At_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.a = CDbl(At.Text)
    End Sub
    Private Sub Avanti_0_1()
        msg = "Alcuni valori sono diversi da un numero, o sono mancanti; prego ricontrollare"
        temp2 = 0
        If dit.Text = "" Then
            temp2 = 1
        End If

        If Tst.Text = "" Then
            temp2 = 1
        End If

        If tt.Text = "" Then
            temp2 = 1
        End If

        If Ht.Text = "" Then
            temp2 = 1
        End If

        If At.Text = "" Then
            temp2 = 1
        End If

        If Rt.Text = "" Then
            temp2 = 1
        End If

        If d1t.Text = "" Then
            temp2 = 1
        End If

        If dt.Text = "" Then
            temp2 = 1
        End If

        If t1t.Text = "" Then
            temp2 = 1
        End If

        If l6t.Text = "" Then
            temp2 = 1
        End If

        If l3t.Text = "" Then
            temp2 = 1
        End If

        If Ft.Text = "" Then
            temp2 = 1
        End If

        If Et1.Text = "" Then
            temp2 = 1
        End If

        If Gt.Text = "" Then
            temp2 = 1
        End If

        If Kt.Text = "" Then
            temp2 = 1
        End If

        If t3t.Text = "" Then
            temp2 = 1
        End If

        If l7t.Text = "" Then
            temp2 = 1
        End If

        If llt.Text = "" Then
            temp2 = 1
        End If

        If t2t.Text = "" Then
            temp2 = 1
        End If

        If temp2 <> 0 Then
            MsgBox(msg)
        End If
        With Orecchia
            If temp2 = 0 Then
                .di = Val(dit.Text)
                .ts = Val(Tst.Text)
                .t = Val(tt.Text)
                .H = Val(Ht.Text)
                .a = Val(At.Text)
                .R = Val(Rt.Text)
                .d1 = Val(d1t.Text)
                .d = Val(dt.Text)
                .t1 = Val(t1t.Text)
                .l6 = Val(l6t.Text)
                .l2 = Val(l3t.Text)
                .F = Val(Ft.Text)
                .E = Val(Et1.Text)
                .G = Val(Gt.Text)
                .k = Val(Kt.Text)
                .t3 = Val(t3t.Text)
                .l7 = Val(l7t.Text)
                .l = Val(llt.Text)
                .t2 = Val(t2t.Text)
            End If
        End With
    End Sub
    Private Sub d1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.d1 = CDbl(d1t.Text)
    End Sub
    Private Sub dit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.di = CDbl(dit.Text)
    End Sub
    Private Sub dt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.d = CDbl(dt.Text)
    End Sub
    Private Sub Et1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.E = CDbl(Et1.Text)
    End Sub
    Public Sub InserDati_1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        With Orecchia
            dit.Text = .di.ToString
            Tst.Text = .ts.ToString
            tt.Text = .t.ToString
            Ht.Text = .H.ToString
            At.Text = .a.ToString
            Rt.Text = .R.ToString
            d1t.Text = .d1.ToString
            dt.Text = .d.ToString
            t1t.Text = .t1.ToString
            l6t.Text = .l6.ToString
            l3t.Text = .l2.ToString
            Ft.Text = .F.ToString
            Et1.Text = .E.ToString
            Gt.Text = .G.ToString
            Kt.Text = .k.ToString
            t3t.Text = .t3.ToString
            l7t.Text = .l7.ToString
            llt.Text = .l.ToString
            t2t.Text = .t2.ToString
        End With
    End Sub

    Private Sub InserDati_1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        GlobalRoutines.CenterForm(Me)
    End Sub
    Private Sub Ft_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.F = Val(Ft.Text)
    End Sub
    Private Sub Gt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.G = Val(Gt.Text)
    End Sub
    Private Sub Ht_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.H = Val(Ht.Text)
    End Sub
    Private Sub Kt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.k = Val(Kt.Text)
    End Sub
    Private Sub l3t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.l2 = Val(l3t.Text)
    End Sub
    Private Sub l6t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.l6 = Val(l6t.Text)
    End Sub
    Private Sub l7t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.l7 = Val(l7t.Text)
    End Sub
    Private Sub llt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.l = Val(llt.Text)
    End Sub
    Private Sub Rt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.R = Val(Rt.Text)
    End Sub
    Private Sub t1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.t1 = Val(t1t.Text)
    End Sub
    Private Sub t2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.t2 = Val(t2t.Text)
    End Sub
    Private Sub t3t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.t3 = Val(t3t.Text)
    End Sub
    Private Sub Tst_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.ts = Val(Tst.Text)
    End Sub
    Private Sub tt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Orecchia.t = Val(tt.Text)
    End Sub
    Private Sub _mnuFile0_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile0_0.Click
        CaricaCommessa()
    End Sub
    Private Sub _mnuFile0_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile0_1.Click
        Salva()
    End Sub
    Private Sub _mnuFile0_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile0_3.Click
        Monitor.Motore.Ammazza("OREC")
        Monitor.Oggetto = Nothing
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Monitor = Nothing
        Dispose()
    End Sub
    Private Sub _mnuFile0_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile0_2.Click
        Dim Ext0 As String = Monitor.Motore.Problem.Extension
        Dim Ext1 As String = Ext0.Substring(1, Ext0.Length - 1)
        CommonDialog1.FileName = nomefile
        CommonDialog1.InitialDirectory = Monitor.Motore.Inizio.Datidir
        CommonDialog1.Filter = Monitor.Motore.Problem.TipoFile & Ext0 & " (*" & Ext1 & ")|*" & Ext1
        CommonDialog1.ShowDialog()
        nomefile = CommonDialog1.FileName
        Call Salva()
    End Sub
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Monitor.Motore.Informazioni(Me, Reflection.Assembly.GetExecutingAssembly)
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim nuovaPagina As Integer = TabControl1.SelectedIndex
        Select Case iPagina
            Case 0
                Select Case nuovaPagina
                    Case 1
                        Aggiorna1()
                        Avanti_0_1()
                    Case 2 ': TabControl1.SelectedIndex = 1
                        Aggiorna2()
                        Avanti_0_1()
                End Select
            Case 1
                Select Case nuovaPagina
                    Case 2
                        Aggiorna2()
                        Avanti_1_2()
                    Case 0
                        Avanti_1_2()
                End Select
            Case 2
                Select Case nuovaPagina
                    Case 1
                        Indietro_2_1()
                        Aggiorna1()
                    Case 0 ': TabControl1.SelectedIndex = 1
                        Indietro_2_1()
                End Select
        End Select
        iPagina = nuovaPagina
    End Sub
    Private Sub Aggiorna2()
        With Orecchia
            _Textcil_0.Text = .mat1
            sy1t.Text = .sy1.ToString(Formpsi)
            sa1t.Text = .sa1.ToString(Formpsi)
            _Textcil_1.Text = .mat2
            sy2t.Text = .sy2.ToString(Formpsi)
            sa2t.Text = .sa2.ToString(Formpsi)
            _Textcil_2.Text = .mat3
            sy3t.Text = .sy3.ToString(Formpsi)
            sa3t.Text = .sa3.ToString(Formpsi)
            _Textcil_3.Text = .mat4
            sy4t.Text = .sy4.ToString(Formpsi)
            sa4t.Text = .sa4.ToString(Formpsi)
            _Textcil_4.Text = .mat5
            sy5t.Text = .sy5.ToString(Formpsi)
            sa5t.Text = .sa5.ToString(Formpsi)
        End With

    End Sub
    Private Sub Indietro_2_1()
        If per = 1 Then
            Orecchia.we *= 100
            per = 0
        End If
    End Sub
    Private Sub Aggiorna1()
        With Orecchia
            wt.Text = .wl.ToString
            et2.Text = .we.ToString
            alphat.Text = .alpha.ToString
            B1t.Text = .theta1.ToString
            B2t.Text = .theta2.ToString
            Qt.Text = .W.ToString
            l1t.Text = .li.ToString
            l2t.Text = .ll.ToString
            t4t.Text = .t4.ToString
            L10t.Text = .L10.ToString
            R1t.Text = .R11.ToString
            dft.Text = .dff.ToString
            We2t.Text = .We2.ToString
        End With
    End Sub
    Private Sub Avanti_1_2()
        msg = "Alcuni valori sono diversi da un numero, o sono mancanti; prego ricontrollare"
        temp2 = 0
        If wt.Text = "" Then
            temp2 = 1
        End If

        If et2.Text = "" Then
            temp2 = 1
        End If

        If alphat.Text = "" Then
            temp2 = 1
        End If

        If B1t.Text = "" Then
            temp2 = 1
        End If

        If B2t.Text = "" Then
            temp2 = 1
        End If

        If Qt.Text = "" Then
            temp2 = 1
        End If

        If l1t.Text = "" Then
            temp2 = 1
        End If

        If l2t.Text = "" Then
            temp2 = 1
        End If

        If t4t.Text = "" Then
            temp2 = 1
        End If

        If L10t.Text = "" Then
            temp2 = 1
        End If

        If R1t.Text = "" Then
            temp2 = 1
        End If

        If dft.Text = "" Then
            temp2 = 1
        End If

        If We2t.Text = "" Then
            temp2 = 1
        End If

        If temp2 = 1 Then
            MsgBox(msg)
        End If
        With Orecchia
            If temp2 = 0 Then
                .wl = CDbl(wt.Text)
                .we = CDbl(et2.Text)
                .alpha = CDbl(alphat.Text)
                .theta1 = CDbl(B1t.Text)
                .theta2 = CDbl(B2t.Text)
                .W = CDbl(Qt.Text)
                .li = CDbl(l1t.Text)
                .ll = CDbl(l2t.Text)
                .t4 = CDbl(t4t.Text)
                .L10 = CDbl(L10t.Text)
                .R11 = CDbl(R1t.Text)
                .dff = CDbl(dft.Text)
                .We2 = CDbl(We2t.Text)
            End If
        End With
    End Sub
    Private Sub B1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles B1t.TextChanged
        Orecchia.theta1 = CDbl(B1t.Text)
    End Sub
    Private Sub B2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles B2t.TextChanged
        Orecchia.theta2 = CDbl(B2t.Text)
    End Sub
    Private Sub dft_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dft.TextChanged
        Orecchia.dff = CDbl(dft.Text)
    End Sub
    Private Sub et2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles et2.TextChanged
        Orecchia.we = CDbl(et2.Text)
    End Sub
    Private Sub L10t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles L10t.TextChanged
        Orecchia.L10 = CDbl(L10t.Text)
    End Sub
    Private Sub l1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles l1t.TextChanged
        Orecchia.li = CDbl(l1t.Text)
    End Sub
    Private Sub l2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles l2t.TextChanged
        Orecchia.ll = CDbl(l2t.Text)
    End Sub
    Private Sub Qt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Qt.TextChanged
        Orecchia.W = CDbl(Qt.Text)
    End Sub
    Private Sub R1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R1t.TextChanged
        Orecchia.R11 = CDbl(R1t.Text)
    End Sub
    Private Sub t4t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles t4t.TextChanged
        Orecchia.t4 = CDbl(t4t.Text)
    End Sub
    Private Sub We2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles We2t.TextChanged
        Orecchia.We2 = CDbl(We2t.Text)
    End Sub
    Private Sub wt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wt.TextChanged
        Orecchia.wl = CDbl(wt.Text)
    End Sub
    Private Sub alphat_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles alphat.TextChanged
        Orecchia.alpha = CDbl(alphat.Text)
    End Sub

    Private Sub Cancella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancella.Click
        List_err.Items.Clear()
    End Sub

    Private Sub Calcola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calcola.Click
        msg = "Alcuni valori sono diversi da un numero, o sono mancanti; prego ricontrollare"
        temp2 = 0

        If _Textcil_0.Text = "" Then
            temp2 = 1
        End If

        If sy1t.Text = "" Then
            temp2 = 1
        End If

        If sa1t.Text = "" Then
            temp2 = 1
        End If

        If _Textcil_1.Text = "" Then
            temp2 = 1
        End If

        If sy2t.Text = "" Then
            temp2 = 1
        End If

        If sa2t.Text = "" Then
            temp2 = 1
        End If

        If _Textcil_2.Text = "" Then
            temp2 = 1
        End If

        If sy3t.Text = "" Then
            temp2 = 1
        End If

        If sa3t.Text = "" Then
            temp2 = 1
        End If

        If _Textcil_3.Text = "" Then
            temp2 = 1
        End If

        If sy4t.Text = "" Then
            temp2 = 1
        End If

        If sa4t.Text = "" Then
            temp2 = 1
        End If

        If _Textcil_4.Text = "" Then
            temp2 = 1
        End If

        If sy5t.Text = "" Then
            temp2 = 1
        End If

        If sa5t.Text = "" Then
            temp2 = 1
        End If

        If temp2 = 1 Then
            MsgBox(msg)
        End If
        With Orecchia
            If temp2 = 0 Then
                .mat1 = _Textcil_0.Text
                .sy1 = CDbl(sy1t.Text)
                .sa1 = CDbl(sa1t.Text)

                .mat2 = _Textcil_1.Text
                .sy2 = CDbl(sy2t.Text)
                .sa2 = CDbl(sa2t.Text)

                .mat3 = _Textcil_2.Text
                .sy3 = CDbl(sy3t.Text)
                .sa3 = CDbl(sa3t.Text)

                .mat4 = _Textcil_3.Text
                .sy4 = CDbl(sy4t.Text)
                .sa4 = CDbl(sa4t.Text)

                .mat5 = _Textcil_4.Text
                .sy5 = CDbl(sy5t.Text)
                .sa5 = CDbl(sa5t.Text)
                calcolaOrec()

                If temp = 0 Then
                    Resoconto.Text = "ORECCHIE DI SOLLEVAMENTO IDONEE"
                End If

            End If
        End With

    End Sub
    Private Sub cmdCil_Click(ByVal Index As Integer)
        Dim Sfa, td1, Sfo As Single
        '                  yield strength at room
        '                                 yield strenfth at temperature
        Dim US As Single 'ultimate strength
        SelMat(Index)
        td1 = 68
        Matdim(Index).YieldTemp(1, td1, Sfa, Sfo)
        US = Matdim(Index).UltStrength(td1) * clsTrigon.psi
        Select Case Index
            Case 0
                sa1t.Text = GlobalRoutines.myStr(Sfo * clsTrigon.psi, 6, 0, False)
                sy1t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_0.Text = Matdim(Index).MatStr
            Case 1
                sa2t.Text = GlobalRoutines.myStr(Sfo * clsTrigon.psi, 6, 0, False)
                sy2t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_1.Text = Matdim(Index).MatStr
            Case 2
                sa3t.Text = GlobalRoutines.myStr(Sfo * clsTrigon.psi, 6, 0, False)
                sy3t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_2.Text = Matdim(Index).MatStr
            Case 3
                sa4t.Text = GlobalRoutines.myStr(Sfo * clsTrigon.psi, 6, 0, False)
                sy4t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_3.Text = Matdim(Index).MatStr
            Case 4
                sa5t.Text = GlobalRoutines.myStr(Sfo * clsTrigon.psi, 6, 0, False)
                sy5t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_4.Text = Matdim(Index).MatStr
        End Select
    End Sub
    Private Sub sa1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sa1t.TextChanged
        Orecchia.sa1 = Val(sa1t.Text)
    End Sub
    Private Sub sy1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sy1t.TextChanged
        Orecchia.sy1 = Val(sy1t.Text)
    End Sub
    Private Sub sa2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sa2t.TextChanged
        Orecchia.sa2 = Val(sa2t.Text)
    End Sub
    Private Sub sy2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sy2t.TextChanged
        Orecchia.sy2 = Val(sy2t.Text)
    End Sub
    Private Sub sa3t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sa3t.TextChanged
        Orecchia.sa3 = Val(sa3t.Text)
    End Sub
    Private Sub sy3t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sy3t.TextChanged
        Orecchia.sy3 = Val(sy3t.Text)
    End Sub
    Private Sub sa4t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sa4t.TextChanged
        Orecchia.sa4 = Val(sa4t.Text)
    End Sub
    Private Sub sy4t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sy4t.TextChanged
        Orecchia.sy4 = Val(sy4t.Text)
    End Sub
    Private Sub sa5t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sa5t.TextChanged
        Orecchia.sa5 = Val(sa5t.Text)
    End Sub
    Private Sub sy5t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sy5t.TextChanged
        Orecchia.sy5 = Val(sy5t.Text)
    End Sub
    Private Sub _Textcil_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Textcil_0.TextChanged
        Orecchia.mat1 = _Textcil_0.Text
    End Sub
    Private Sub _Textcil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Textcil_1.TextChanged
        Orecchia.mat2 = _Textcil_1.Text
    End Sub
    Private Sub _Textcil_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Textcil_2.TextChanged
        Orecchia.mat3 = _Textcil_2.Text
    End Sub
    Private Sub _Textcil_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Textcil_3.TextChanged
        Orecchia.mat4 = _Textcil_3.Text
    End Sub
    Private Sub _Textcil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Textcil_4.TextChanged
        Orecchia.mat5 = _Textcil_4.Text
    End Sub
    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        cmdCil_Click(0)
    End Sub
    Private Sub _cmdCil_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        cmdCil_Click(1)
    End Sub

    Private Sub _cmdCil_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_2.Click
        cmdCil_Click(2)
    End Sub

    Private Sub _cmdCil_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_3.Click
        cmdCil_Click(3)
    End Sub

    Private Sub _cmdCil_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_4.Click
        cmdCil_Click(4)
    End Sub
    Private Sub cmdStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStampa.Click
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Segnalibri9()
        Else
            Segnalibri()
        End If
    End Sub

    Private Sub mnuCalcola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCalcola.Click
        calcolaOrec()
    End Sub

    Private Sub mnuRapporto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRapporto.Click
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Segnalibri9()
        Else
            Segnalibri()
        End If
    End Sub
End Class