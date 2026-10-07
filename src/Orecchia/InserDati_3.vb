Option Strict Off
Option Explicit On
Friend Class InserDati_3
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
	Public WithEvents Indietro As System.Windows.Forms.Button
	Public WithEvents Calcola As System.Windows.Forms.Button
	Public WithEvents sy5t As System.Windows.Forms.TextBox
	Public WithEvents sa5t As System.Windows.Forms.TextBox
	Public WithEvents sy4t As System.Windows.Forms.TextBox
	Public WithEvents sa4t As System.Windows.Forms.TextBox
	Public WithEvents sy3t As System.Windows.Forms.TextBox
	Public WithEvents sa3t As System.Windows.Forms.TextBox
	Public WithEvents sy2t As System.Windows.Forms.TextBox
	Public WithEvents sa2t As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Resoconto As System.Windows.Forms.Label
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
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Titolo As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InserDati_3))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me.Cancella = New System.Windows.Forms.Button
        Me.List_err = New System.Windows.Forms.ListBox
        Me.cmdStampa = New System.Windows.Forms.Button
        Me.Indietro = New System.Windows.Forms.Button
        Me.Calcola = New System.Windows.Forms.Button
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Resoconto = New System.Windows.Forms.Label
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Titolo = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(376, 424)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 43
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_4, "Inserisci il materiale relativo all'orecchia inferiore")
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(376, 336)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_3.TabIndex = 42
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_3, "Inserisci il materiale relativo al rinforzo")
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(376, 248)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 41
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_2, "Inserisci il materiale relativo alla nervatura")
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(376, 160)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 40
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_1, "Inserisci il materiale relativo all'orecchia superiore")
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(376, 72)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 34
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_0, "Inserisci il materiale re")
        '
        'Cancella
        '
        Me.Cancella.BackColor = System.Drawing.SystemColors.Control
        Me.Cancella.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancella.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancella.Location = New System.Drawing.Point(800, 232)
        Me.Cancella.Name = "Cancella"
        Me.Cancella.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancella.Size = New System.Drawing.Size(89, 33)
        Me.Cancella.TabIndex = 30
        Me.Cancella.Text = "Cancella"
        Me.ToolTip1.SetToolTip(Me.Cancella, "Cancella i valori della lista")
        '
        'List_err
        '
        Me.List_err.BackColor = System.Drawing.SystemColors.Window
        Me.List_err.Cursor = System.Windows.Forms.Cursors.Default
        Me.List_err.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List_err.Location = New System.Drawing.Point(400, 72)
        Me.List_err.Name = "List_err"
        Me.List_err.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List_err.Size = New System.Drawing.Size(489, 147)
        Me.List_err.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.List_err, "Visualizza gli eventuali errori")
        '
        'cmdStampa
        '
        Me.cmdStampa.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStampa.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStampa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStampa.Location = New System.Drawing.Point(261, 528)
        Me.cmdStampa.Name = "cmdStampa"
        Me.cmdStampa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStampa.Size = New System.Drawing.Size(89, 25)
        Me.cmdStampa.TabIndex = 28
        Me.cmdStampa.Text = "Rapporto"
        Me.ToolTip1.SetToolTip(Me.cmdStampa, "Stampa il calcolo")
        '
        'Indietro
        '
        Me.Indietro.BackColor = System.Drawing.SystemColors.Control
        Me.Indietro.Cursor = System.Windows.Forms.Cursors.Default
        Me.Indietro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Indietro.Location = New System.Drawing.Point(800, 528)
        Me.Indietro.Name = "Indietro"
        Me.Indietro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Indietro.Size = New System.Drawing.Size(89, 25)
        Me.Indietro.TabIndex = 29
        Me.Indietro.Text = "<-- Indietro"
        Me.ToolTip1.SetToolTip(Me.Indietro, "Torna alla schermata precedente")
        '
        'Calcola
        '
        Me.Calcola.BackColor = System.Drawing.SystemColors.Control
        Me.Calcola.Cursor = System.Windows.Forms.Cursors.Default
        Me.Calcola.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Calcola.Location = New System.Drawing.Point(162, 528)
        Me.Calcola.Name = "Calcola"
        Me.Calcola.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Calcola.Size = New System.Drawing.Size(89, 25)
        Me.Calcola.TabIndex = 27
        Me.Calcola.Text = "Calcola"
        Me.ToolTip1.SetToolTip(Me.Calcola, "Calcola se l'orecchia può resistere")
        '
        '_Textcil_4
        '
        Me._Textcil_4.AcceptsReturn = True
        Me._Textcil_4.AutoSize = False
        Me._Textcil_4.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_4.Location = New System.Drawing.Point(232, 424)
        Me._Textcil_4.MaxLength = 0
        Me._Textcil_4.Name = "_Textcil_4"
        Me._Textcil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_4.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_4.TabIndex = 39
        Me._Textcil_4.Text = ""
        '
        '_Textcil_3
        '
        Me._Textcil_3.AcceptsReturn = True
        Me._Textcil_3.AutoSize = False
        Me._Textcil_3.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_3.Location = New System.Drawing.Point(232, 336)
        Me._Textcil_3.MaxLength = 0
        Me._Textcil_3.Name = "_Textcil_3"
        Me._Textcil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_3.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_3.TabIndex = 38
        Me._Textcil_3.Text = ""
        '
        '_Textcil_2
        '
        Me._Textcil_2.AcceptsReturn = True
        Me._Textcil_2.AutoSize = False
        Me._Textcil_2.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_2.Location = New System.Drawing.Point(232, 248)
        Me._Textcil_2.MaxLength = 0
        Me._Textcil_2.Name = "_Textcil_2"
        Me._Textcil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_2.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_2.TabIndex = 37
        Me._Textcil_2.Text = ""
        '
        '_Textcil_1
        '
        Me._Textcil_1.AcceptsReturn = True
        Me._Textcil_1.AutoSize = False
        Me._Textcil_1.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_1.Location = New System.Drawing.Point(232, 160)
        Me._Textcil_1.MaxLength = 0
        Me._Textcil_1.Name = "_Textcil_1"
        Me._Textcil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_1.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_1.TabIndex = 36
        Me._Textcil_1.Text = ""
        '
        'sy1t
        '
        Me.sy1t.AcceptsReturn = True
        Me.sy1t.AutoSize = False
        Me.sy1t.BackColor = System.Drawing.SystemColors.Window
        Me.sy1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy1t.Location = New System.Drawing.Point(232, 120)
        Me.sy1t.MaxLength = 0
        Me.sy1t.Name = "sy1t"
        Me.sy1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy1t.Size = New System.Drawing.Size(105, 19)
        Me.sy1t.TabIndex = 18
        Me.sy1t.Text = ""
        '
        'sa1t
        '
        Me.sa1t.AcceptsReturn = True
        Me.sa1t.AutoSize = False
        Me.sa1t.BackColor = System.Drawing.SystemColors.Window
        Me.sa1t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa1t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa1t.Location = New System.Drawing.Point(232, 96)
        Me.sa1t.MaxLength = 0
        Me.sa1t.Name = "sa1t"
        Me.sa1t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa1t.Size = New System.Drawing.Size(105, 19)
        Me.sa1t.TabIndex = 17
        Me.sa1t.Text = ""
        '
        '_Textcil_0
        '
        Me._Textcil_0.AcceptsReturn = True
        Me._Textcil_0.AutoSize = False
        Me._Textcil_0.BackColor = System.Drawing.SystemColors.Window
        Me._Textcil_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Textcil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Textcil_0.Location = New System.Drawing.Point(232, 72)
        Me._Textcil_0.MaxLength = 0
        Me._Textcil_0.Name = "_Textcil_0"
        Me._Textcil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Textcil_0.Size = New System.Drawing.Size(137, 19)
        Me._Textcil_0.TabIndex = 33
        Me._Textcil_0.Text = ""
        '
        'sy5t
        '
        Me.sy5t.AcceptsReturn = True
        Me.sy5t.AutoSize = False
        Me.sy5t.BackColor = System.Drawing.SystemColors.Window
        Me.sy5t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy5t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy5t.Location = New System.Drawing.Point(232, 472)
        Me.sy5t.MaxLength = 0
        Me.sy5t.Name = "sy5t"
        Me.sy5t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy5t.Size = New System.Drawing.Size(105, 19)
        Me.sy5t.TabIndex = 26
        Me.sy5t.Text = ""
        '
        'sa5t
        '
        Me.sa5t.AcceptsReturn = True
        Me.sa5t.AutoSize = False
        Me.sa5t.BackColor = System.Drawing.SystemColors.Window
        Me.sa5t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa5t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa5t.Location = New System.Drawing.Point(232, 448)
        Me.sa5t.MaxLength = 0
        Me.sa5t.Name = "sa5t"
        Me.sa5t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa5t.Size = New System.Drawing.Size(105, 19)
        Me.sa5t.TabIndex = 25
        Me.sa5t.Text = ""
        '
        'sy4t
        '
        Me.sy4t.AcceptsReturn = True
        Me.sy4t.AutoSize = False
        Me.sy4t.BackColor = System.Drawing.SystemColors.Window
        Me.sy4t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy4t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy4t.Location = New System.Drawing.Point(232, 384)
        Me.sy4t.MaxLength = 0
        Me.sy4t.Name = "sy4t"
        Me.sy4t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy4t.Size = New System.Drawing.Size(105, 19)
        Me.sy4t.TabIndex = 24
        Me.sy4t.Text = ""
        '
        'sa4t
        '
        Me.sa4t.AcceptsReturn = True
        Me.sa4t.AutoSize = False
        Me.sa4t.BackColor = System.Drawing.SystemColors.Window
        Me.sa4t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa4t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa4t.Location = New System.Drawing.Point(232, 360)
        Me.sa4t.MaxLength = 0
        Me.sa4t.Name = "sa4t"
        Me.sa4t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa4t.Size = New System.Drawing.Size(105, 19)
        Me.sa4t.TabIndex = 23
        Me.sa4t.Text = ""
        '
        'sy3t
        '
        Me.sy3t.AcceptsReturn = True
        Me.sy3t.AutoSize = False
        Me.sy3t.BackColor = System.Drawing.SystemColors.Window
        Me.sy3t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy3t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy3t.Location = New System.Drawing.Point(232, 296)
        Me.sy3t.MaxLength = 0
        Me.sy3t.Name = "sy3t"
        Me.sy3t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy3t.Size = New System.Drawing.Size(105, 19)
        Me.sy3t.TabIndex = 22
        Me.sy3t.Text = ""
        '
        'sa3t
        '
        Me.sa3t.AcceptsReturn = True
        Me.sa3t.AutoSize = False
        Me.sa3t.BackColor = System.Drawing.SystemColors.Window
        Me.sa3t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa3t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa3t.Location = New System.Drawing.Point(232, 272)
        Me.sa3t.MaxLength = 0
        Me.sa3t.Name = "sa3t"
        Me.sa3t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa3t.Size = New System.Drawing.Size(105, 19)
        Me.sa3t.TabIndex = 21
        Me.sa3t.Text = ""
        '
        'sy2t
        '
        Me.sy2t.AcceptsReturn = True
        Me.sy2t.AutoSize = False
        Me.sy2t.BackColor = System.Drawing.SystemColors.Window
        Me.sy2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sy2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sy2t.Location = New System.Drawing.Point(232, 208)
        Me.sy2t.MaxLength = 0
        Me.sy2t.Name = "sy2t"
        Me.sy2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sy2t.Size = New System.Drawing.Size(105, 19)
        Me.sy2t.TabIndex = 20
        Me.sy2t.Text = ""
        '
        'sa2t
        '
        Me.sa2t.AcceptsReturn = True
        Me.sa2t.AutoSize = False
        Me.sa2t.BackColor = System.Drawing.SystemColors.Window
        Me.sa2t.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sa2t.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sa2t.Location = New System.Drawing.Point(232, 184)
        Me.sa2t.MaxLength = 0
        Me.sa2t.Name = "sa2t"
        Me.sa2t.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sa2t.Size = New System.Drawing.Size(105, 19)
        Me.sa2t.TabIndex = 19
        Me.sa2t.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(199, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(199, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Materiale Mantello"
        '
        'Resoconto
        '
        Me.Resoconto.BackColor = System.Drawing.SystemColors.Control
        Me.Resoconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Resoconto.Cursor = System.Windows.Forms.Cursors.Default
        Me.Resoconto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Resoconto.Location = New System.Drawing.Point(400, 288)
        Me.Resoconto.Name = "Resoconto"
        Me.Resoconto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Resoconto.Size = New System.Drawing.Size(289, 25)
        Me.Resoconto.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(24, 448)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(199, 16)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(24, 472)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(199, 16)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(24, 424)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(103, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Materiale orecc. inf."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(24, 360)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(199, 16)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(24, 384)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(199, 16)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(24, 336)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(92, 16)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Materiale rinforzo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(24, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(199, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(24, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(199, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(24, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(102, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Materiale nervatura"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(24, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(199, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Specif. Min. Tensile                    Sa  Psi"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(199, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Specif. Min. Yield                        Sy  Psi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Materiale orecchia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proprietà Materiali"
        '
        'Titolo
        '
        Me.Titolo.AutoSize = True
        Me.Titolo.BackColor = System.Drawing.SystemColors.Control
        Me.Titolo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Titolo.Cursor = System.Windows.Forms.Cursors.Default
        Me.Titolo.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titolo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Titolo.Location = New System.Drawing.Point(86, 8)
        Me.Titolo.Name = "Titolo"
        Me.Titolo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Titolo.Size = New System.Drawing.Size(434, 31)
        Me.Titolo.TabIndex = 0
        Me.Titolo.Text = "CALCOLO ORECCHIE DI SOLLEVAMENTO"
        Me.Titolo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(360, 528)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(432, 24)
        Me.ProgressBar1.TabIndex = 44
        '
        'InserDati_3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me._cmdCil_4)
        Me.Controls.Add(Me._cmdCil_3)
        Me.Controls.Add(Me._cmdCil_2)
        Me.Controls.Add(Me._cmdCil_1)
        Me.Controls.Add(Me._Textcil_4)
        Me.Controls.Add(Me._Textcil_3)
        Me.Controls.Add(Me._Textcil_2)
        Me.Controls.Add(Me._Textcil_1)
        Me.Controls.Add(Me.sy1t)
        Me.Controls.Add(Me.sa1t)
        Me.Controls.Add(Me._cmdCil_0)
        Me.Controls.Add(Me._Textcil_0)
        Me.Controls.Add(Me.Cancella)
        Me.Controls.Add(Me.List_err)
        Me.Controls.Add(Me.cmdStampa)
        Me.Controls.Add(Me.Indietro)
        Me.Controls.Add(Me.Calcola)
        Me.Controls.Add(Me.sy5t)
        Me.Controls.Add(Me.sa5t)
        Me.Controls.Add(Me.sy4t)
        Me.Controls.Add(Me.sa4t)
        Me.Controls.Add(Me.sy3t)
        Me.Controls.Add(Me.sa3t)
        Me.Controls.Add(Me.sy2t)
        Me.Controls.Add(Me.sa2t)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Resoconto)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Titolo)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.Name = "InserDati_3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Orecchia"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As InserDati_3
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As InserDati_3
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New InserDati_3()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Dim Materiale As String
	Dim dic As Short
	Dim ms As String
	
	Private Sub Calcola_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Calcola.Click
		ms = "Alcuni valori sono diversi da un numero, o sono mancanti; prego ricontrollare"
		dic = 0
		
        If _Textcil_0.Text = "" Then
            dic = 1
        End If

        If sy1t.Text = "" Then
            dic = 1
        End If

        If sa1t.Text = "" Then
            dic = 1
        End If

        If _Textcil_1.Text = "" Then
            dic = 1
        End If

        If sy2t.Text = "" Then
            dic = 1
        End If

        If sa2t.Text = "" Then
            dic = 1
        End If

        If _Textcil_2.Text = "" Then
            dic = 1
        End If

        If sy3t.Text = "" Then
            dic = 1
        End If

        If sa3t.Text = "" Then
            dic = 1
        End If

        If _Textcil_3.Text = "" Then
            dic = 1
        End If

        If sy4t.Text = "" Then
            dic = 1
        End If

        If sa4t.Text = "" Then
            dic = 1
        End If

        If _Textcil_4.Text = "" Then
            dic = 1
        End If

        If sy5t.Text = "" Then
            dic = 1
        End If

        If sa5t.Text = "" Then
            dic = 1
        End If

        If dic = 1 Then
            MsgBox(ms)
        End If
        With Orecchia
            If dic = 0 Then
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
                Calcola.Enabled = False

                If temp = 0 Then
                    Resoconto.Text = "ORECCHIA DI SOLLEVAMENTO IDONEA"
                End If

            End If
        End With
    End Sub

    Private Sub Cancella_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancella.Click
        List_err.Items.Clear()
    End Sub

    Private Sub cmdCil_Click(ByVal Index As Integer)
        Dim Sfa, td1, Sfo As Single
        '                  yield strength at room
        '                                 yield strenfth at temperature
        Dim US As Single 'ultimate strength
        SelMat(Index)
        td1 = 68
        Matdim(Index).YieldTemp(1, td1, Sfa, Sfo)
        US = Matdim(Index).UltStrength(td1) * MPA
        Select Case Index
            Case 0
                sa1t.Text = GlobalRoutines.myStr(Sfo * MPA, 6, 0, False)
                sy1t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_0.Text = Matdim(Index).MatStr
            Case 1
                sa2t.Text = GlobalRoutines.myStr(Sfo * MPA, 6, 0, False)
                sy2t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_1.Text = Matdim(Index).MatStr
            Case 2
                sa3t.Text = GlobalRoutines.myStr(Sfo * MPA, 6, 0, False)
                sy3t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_2.Text = Matdim(Index).MatStr
            Case 3
                sa4t.Text = GlobalRoutines.myStr(Sfo * MPA, 6, 0, False)
                sy4t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_3.Text = Matdim(Index).MatStr
            Case 4
                sa5t.Text = GlobalRoutines.myStr(Sfo * MPA, 6, 0, False)
                sy5t.Text = GlobalRoutines.myStr(US, 6, 0, False)
                _Textcil_4.Text = Matdim(Index).MatStr
        End Select
    End Sub

    Private Sub cmdStampa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStampa.Click
        Segnalibri()
    End Sub

    'UPGRADE_WARNING: Form evento InserDati_3.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub InserDati_3_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        With Orecchia
            _Textcil_0.Text = .mat1
            sy1t.Text = CStr(.sy1)
            sa1t.Text = CStr(.sa1)
            _Textcil_1.Text = .mat2
            sy2t.Text = CStr(.sy2)
            sa2t.Text = CStr(.sa2)
            _Textcil_2.Text = .mat3
            sy3t.Text = CStr(.sy3)
            sa3t.Text = CStr(.sa3)
            _Textcil_3.Text = .mat4
            sy4t.Text = CStr(.sy4)
            sa4t.Text = CStr(.sa4)
            _Textcil_4.Text = .mat5
            sy5t.Text = CStr(.sy5)
            sa5t.Text = CStr(.sa5)
        End With
    End Sub

    Private Sub InserDati_3_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim cicle As Short
        cicle = 0
        Calcola.Enabled = True
        Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Width / 2 ' Centra il form orizzontalmente.
        Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Height / 2 ' Centra il form verticalmente.
        Titolo.Left = InserDati_3.DefInstance.Width - Titolo.Width / 2 'Centra il titolo orizzontalmente
    End Sub

    Private Sub Indietro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Indietro.Click
        temp4 = 1
        If per = 1 Then
            Orecchia.we *= 100
            per = 0
        End If
        InserDati_3.DefInstance.Close()
        InserDati_2.DefInstance.ShowDialog()

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
End Class