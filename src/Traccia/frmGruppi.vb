Option Strict Off
Option Explicit On
Friend Class frmGruppi
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
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents _Valor_12 As System.Windows.Forms.TextBox
    Public WithEvents _Valor_17 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_16 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_15 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_14 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_13 As System.Windows.Forms.TextBox
    Public WithEvents _Etich_17 As System.Windows.Forms.Label
	Public WithEvents _Etich_16 As System.Windows.Forms.Label
	Public WithEvents _Etich_15 As System.Windows.Forms.Label
	Public WithEvents _Etich_14 As System.Windows.Forms.Label
	Public WithEvents _Etich_13 As System.Windows.Forms.Label
	Public WithEvents _Etich_12 As System.Windows.Forms.Label
	Public WithEvents _Frame1_2 As System.Windows.Forms.GroupBox
	Public WithEvents _Valor_6 As System.Windows.Forms.TextBox
    Public WithEvents _Valor_11 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_10 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_9 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_8 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_7 As System.Windows.Forms.TextBox
    Public WithEvents _Etich_11 As System.Windows.Forms.Label
	Public WithEvents _Etich_10 As System.Windows.Forms.Label
	Public WithEvents _Etich_9 As System.Windows.Forms.Label
	Public WithEvents _Etich_8 As System.Windows.Forms.Label
	Public WithEvents _Etich_7 As System.Windows.Forms.Label
	Public WithEvents _Etich_6 As System.Windows.Forms.Label
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents _Valor_0 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_1 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_2 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_3 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_4 As System.Windows.Forms.TextBox
	Public WithEvents _Valor_5 As System.Windows.Forms.TextBox
	Public WithEvents _Etich_5 As System.Windows.Forms.Label
	Public WithEvents _Etich_4 As System.Windows.Forms.Label
	Public WithEvents _Etich_3 As System.Windows.Forms.Label
	Public WithEvents _Etich_2 As System.Windows.Forms.Label
	Public WithEvents _Etich_1 As System.Windows.Forms.Label
	Public WithEvents _Etich_0 As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _ListView1_2 As System.Windows.Forms.ListView
    Friend WithEvents _ListView1_1 As System.Windows.Forms.ListView
    Friend WithEvents _ListView1_0 As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGruppi))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me._Frame1_2 = New System.Windows.Forms.GroupBox
        Me._ListView1_2 = New System.Windows.Forms.ListView
        Me.NUpDown3 = New System.Windows.Forms.NumericUpDown
        Me._Valor_12 = New System.Windows.Forms.TextBox
        Me._Valor_17 = New System.Windows.Forms.TextBox
        Me._Valor_16 = New System.Windows.Forms.TextBox
        Me._Valor_15 = New System.Windows.Forms.TextBox
        Me._Valor_14 = New System.Windows.Forms.TextBox
        Me._Valor_13 = New System.Windows.Forms.TextBox
        Me._Etich_17 = New System.Windows.Forms.Label
        Me._Etich_16 = New System.Windows.Forms.Label
        Me._Etich_15 = New System.Windows.Forms.Label
        Me._Etich_14 = New System.Windows.Forms.Label
        Me._Etich_13 = New System.Windows.Forms.Label
        Me._Etich_12 = New System.Windows.Forms.Label
        Me._Frame1_1 = New System.Windows.Forms.GroupBox
        Me._ListView1_1 = New System.Windows.Forms.ListView
        Me.NUpDown2 = New System.Windows.Forms.NumericUpDown
        Me._Valor_6 = New System.Windows.Forms.TextBox
        Me._Valor_11 = New System.Windows.Forms.TextBox
        Me._Valor_10 = New System.Windows.Forms.TextBox
        Me._Valor_9 = New System.Windows.Forms.TextBox
        Me._Valor_8 = New System.Windows.Forms.TextBox
        Me._Valor_7 = New System.Windows.Forms.TextBox
        Me._Etich_11 = New System.Windows.Forms.Label
        Me._Etich_10 = New System.Windows.Forms.Label
        Me._Etich_9 = New System.Windows.Forms.Label
        Me._Etich_8 = New System.Windows.Forms.Label
        Me._Etich_7 = New System.Windows.Forms.Label
        Me._Etich_6 = New System.Windows.Forms.Label
        Me.Command3 = New System.Windows.Forms.Button
        Me.Text2 = New System.Windows.Forms.TextBox
        Me._Frame1_0 = New System.Windows.Forms.GroupBox
        Me._ListView1_0 = New System.Windows.Forms.ListView
        Me.NUpDown1 = New System.Windows.Forms.NumericUpDown
        Me._Valor_0 = New System.Windows.Forms.TextBox
        Me._Valor_1 = New System.Windows.Forms.TextBox
        Me._Valor_2 = New System.Windows.Forms.TextBox
        Me._Valor_3 = New System.Windows.Forms.TextBox
        Me._Valor_4 = New System.Windows.Forms.TextBox
        Me._Valor_5 = New System.Windows.Forms.TextBox
        Me._Etich_5 = New System.Windows.Forms.Label
        Me._Etich_4 = New System.Windows.Forms.Label
        Me._Etich_3 = New System.Windows.Forms.Label
        Me._Etich_2 = New System.Windows.Forms.Label
        Me._Etich_1 = New System.Windows.Forms.Label
        Me._Etich_0 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me._Frame1_2.SuspendLayout()
        CType(Me.NUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._Frame1_1.SuspendLayout()
        CType(Me.NUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._Frame1_0.SuspendLayout()
        CType(Me.NUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Image = CType(resources.GetObject("Command2.Image"), System.Drawing.Image)
        Me.Command2.Location = New System.Drawing.Point(480, 0)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(33, 33)
        Me.Command2.TabIndex = 18
        Me.Command2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Command2, "Salva il file ADU")
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Image = CType(resources.GetObject("Command1.Image"), System.Drawing.Image)
        Me.Command1.Location = New System.Drawing.Point(440, 0)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(33, 33)
        Me.Command1.TabIndex = 17
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Command1, "Apri un altro file ADU creato esternamente")
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(168, 32)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(217, 17)
        Me.Check1.TabIndex = 53
        Me.Check1.Text = "Tutti i gruppi dallo stesso tipo di barra"
        '
        '_Frame1_2
        '
        Me._Frame1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_2.Controls.Add(Me._ListView1_2)
        Me._Frame1_2.Controls.Add(Me.NUpDown3)
        Me._Frame1_2.Controls.Add(Me._Valor_12)
        Me._Frame1_2.Controls.Add(Me._Valor_17)
        Me._Frame1_2.Controls.Add(Me._Valor_16)
        Me._Frame1_2.Controls.Add(Me._Valor_15)
        Me._Frame1_2.Controls.Add(Me._Valor_14)
        Me._Frame1_2.Controls.Add(Me._Valor_13)
        Me._Frame1_2.Controls.Add(Me._Etich_17)
        Me._Frame1_2.Controls.Add(Me._Etich_16)
        Me._Frame1_2.Controls.Add(Me._Etich_15)
        Me._Frame1_2.Controls.Add(Me._Etich_14)
        Me._Frame1_2.Controls.Add(Me._Etich_13)
        Me._Frame1_2.Controls.Add(Me._Etich_12)
        Me._Frame1_2.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_2.Location = New System.Drawing.Point(376, 56)
        Me._Frame1_2.Name = "_Frame1_2"
        Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_2.Size = New System.Drawing.Size(177, 385)
        Me._Frame1_2.TabIndex = 33
        Me._Frame1_2.TabStop = False
        Me._Frame1_2.Text = "Gruppo n° 3"
        Me._Frame1_2.Visible = False
        '
        '_ListView1_2
        '
        Me._ListView1_2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me._ListView1_2.Location = New System.Drawing.Point(8, 120)
        Me._ListView1_2.MultiSelect = False
        Me._ListView1_2.Name = "_ListView1_2"
        Me._ListView1_2.Size = New System.Drawing.Size(160, 256)
        Me._ListView1_2.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me._ListView1_2.TabIndex = 54
        Me._ListView1_2.View = System.Windows.Forms.View.Details
        '
        'NUpDown3
        '
        Me.NUpDown3.Location = New System.Drawing.Point(152, 96)
        Me.NUpDown3.Name = "NUpDown3"
        Me.NUpDown3.Size = New System.Drawing.Size(20, 19)
        Me.NUpDown3.TabIndex = 53
        '
        '_Valor_12
        '
        Me._Valor_12.AcceptsReturn = True
        Me._Valor_12.AutoSize = False
        Me._Valor_12.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_12.Enabled = False
        Me._Valor_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_12.Location = New System.Drawing.Point(112, 96)
        Me._Valor_12.MaxLength = 0
        Me._Valor_12.Name = "_Valor_12"
        Me._Valor_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_12.Size = New System.Drawing.Size(41, 20)
        Me._Valor_12.TabIndex = 34
        Me._Valor_12.Text = "Text2"
        '
        '_Valor_17
        '
        Me._Valor_17.AcceptsReturn = True
        Me._Valor_17.AutoSize = False
        Me._Valor_17.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_17.Location = New System.Drawing.Point(128, 16)
        Me._Valor_17.MaxLength = 0
        Me._Valor_17.Name = "_Valor_17"
        Me._Valor_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_17.Size = New System.Drawing.Size(41, 20)
        Me._Valor_17.TabIndex = 39
        Me._Valor_17.Text = "Text2"
        '
        '_Valor_16
        '
        Me._Valor_16.AcceptsReturn = True
        Me._Valor_16.AutoSize = False
        Me._Valor_16.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_16.Location = New System.Drawing.Point(128, 32)
        Me._Valor_16.MaxLength = 0
        Me._Valor_16.Name = "_Valor_16"
        Me._Valor_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_16.Size = New System.Drawing.Size(41, 20)
        Me._Valor_16.TabIndex = 38
        Me._Valor_16.Text = "Text2"
        '
        '_Valor_15
        '
        Me._Valor_15.AcceptsReturn = True
        Me._Valor_15.AutoSize = False
        Me._Valor_15.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_15.Location = New System.Drawing.Point(128, 48)
        Me._Valor_15.MaxLength = 0
        Me._Valor_15.Name = "_Valor_15"
        Me._Valor_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_15.Size = New System.Drawing.Size(41, 20)
        Me._Valor_15.TabIndex = 37
        Me._Valor_15.Text = "Text2"
        '
        '_Valor_14
        '
        Me._Valor_14.AcceptsReturn = True
        Me._Valor_14.AutoSize = False
        Me._Valor_14.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_14.Location = New System.Drawing.Point(128, 64)
        Me._Valor_14.MaxLength = 0
        Me._Valor_14.Name = "_Valor_14"
        Me._Valor_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_14.Size = New System.Drawing.Size(41, 20)
        Me._Valor_14.TabIndex = 36
        Me._Valor_14.Text = "Text2"
        '
        '_Valor_13
        '
        Me._Valor_13.AcceptsReturn = True
        Me._Valor_13.AutoSize = False
        Me._Valor_13.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_13.Location = New System.Drawing.Point(128, 80)
        Me._Valor_13.MaxLength = 0
        Me._Valor_13.Name = "_Valor_13"
        Me._Valor_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_13.Size = New System.Drawing.Size(41, 20)
        Me._Valor_13.TabIndex = 35
        Me._Valor_13.Text = "Text2"
        '
        '_Etich_17
        '
        Me._Etich_17.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_17.Location = New System.Drawing.Point(8, 16)
        Me._Etich_17.Name = "_Etich_17"
        Me._Etich_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_17.Size = New System.Drawing.Size(113, 17)
        Me._Etich_17.TabIndex = 45
        Me._Etich_17.Text = "Diam. est. tubo       [mm]"
        '
        '_Etich_16
        '
        Me._Etich_16.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_16.Location = New System.Drawing.Point(8, 32)
        Me._Etich_16.Name = "_Etich_16"
        Me._Etich_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_16.Size = New System.Drawing.Size(113, 17)
        Me._Etich_16.TabIndex = 44
        Me._Etich_16.Text = "Spessore tubo      [mm]"
        '
        '_Etich_15
        '
        Me._Etich_15.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_15.Location = New System.Drawing.Point(8, 48)
        Me._Etich_15.Name = "_Etich_15"
        Me._Etich_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_15.Size = New System.Drawing.Size(113, 17)
        Me._Etich_15.TabIndex = 43
        Me._Etich_15.Text = "Lungh. rettilinea     [mm]"
        '
        '_Etich_14
        '
        Me._Etich_14.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_14.Location = New System.Drawing.Point(8, 64)
        Me._Etich_14.Name = "_Etich_14"
        Me._Etich_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_14.Size = New System.Drawing.Size(113, 17)
        Me._Etich_14.TabIndex = 42
        Me._Etich_14.Text = "Raggio minimo      [mm]"
        '
        '_Etich_13
        '
        Me._Etich_13.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_13.Location = New System.Drawing.Point(8, 80)
        Me._Etich_13.Name = "_Etich_13"
        Me._Etich_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_13.Size = New System.Drawing.Size(113, 17)
        Me._Etich_13.TabIndex = 41
        Me._Etich_13.Text = "Incremento raggio [mm]"
        '
        '_Etich_12
        '
        Me._Etich_12.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_12.Location = New System.Drawing.Point(8, 96)
        Me._Etich_12.Name = "_Etich_12"
        Me._Etich_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_12.Size = New System.Drawing.Size(113, 17)
        Me._Etich_12.TabIndex = 40
        Me._Etich_12.Text = "Numero di file"
        '
        '_Frame1_1
        '
        Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_1.Controls.Add(Me._ListView1_1)
        Me._Frame1_1.Controls.Add(Me.NUpDown2)
        Me._Frame1_1.Controls.Add(Me._Valor_6)
        Me._Frame1_1.Controls.Add(Me._Valor_11)
        Me._Frame1_1.Controls.Add(Me._Valor_10)
        Me._Frame1_1.Controls.Add(Me._Valor_9)
        Me._Frame1_1.Controls.Add(Me._Valor_8)
        Me._Frame1_1.Controls.Add(Me._Valor_7)
        Me._Frame1_1.Controls.Add(Me._Etich_11)
        Me._Frame1_1.Controls.Add(Me._Etich_10)
        Me._Frame1_1.Controls.Add(Me._Etich_9)
        Me._Frame1_1.Controls.Add(Me._Etich_8)
        Me._Frame1_1.Controls.Add(Me._Etich_7)
        Me._Frame1_1.Controls.Add(Me._Etich_6)
        Me._Frame1_1.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_1.Location = New System.Drawing.Point(192, 56)
        Me._Frame1_1.Name = "_Frame1_1"
        Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_1.Size = New System.Drawing.Size(177, 385)
        Me._Frame1_1.TabIndex = 20
        Me._Frame1_1.TabStop = False
        Me._Frame1_1.Text = "Gruppo n° 2"
        Me._Frame1_1.Visible = False
        '
        '_ListView1_1
        '
        Me._ListView1_1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me._ListView1_1.Location = New System.Drawing.Point(8, 120)
        Me._ListView1_1.MultiSelect = False
        Me._ListView1_1.Name = "_ListView1_1"
        Me._ListView1_1.Size = New System.Drawing.Size(160, 256)
        Me._ListView1_1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me._ListView1_1.TabIndex = 55
        Me._ListView1_1.View = System.Windows.Forms.View.Details
        '
        'NUpDown2
        '
        Me.NUpDown2.Location = New System.Drawing.Point(152, 96)
        Me.NUpDown2.Name = "NUpDown2"
        Me.NUpDown2.Size = New System.Drawing.Size(20, 19)
        Me.NUpDown2.TabIndex = 52
        '
        '_Valor_6
        '
        Me._Valor_6.AcceptsReturn = True
        Me._Valor_6.AutoSize = False
        Me._Valor_6.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_6.Enabled = False
        Me._Valor_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_6.Location = New System.Drawing.Point(112, 96)
        Me._Valor_6.MaxLength = 0
        Me._Valor_6.Name = "_Valor_6"
        Me._Valor_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_6.Size = New System.Drawing.Size(41, 20)
        Me._Valor_6.TabIndex = 21
        Me._Valor_6.Text = "Text2"
        '
        '_Valor_11
        '
        Me._Valor_11.AcceptsReturn = True
        Me._Valor_11.AutoSize = False
        Me._Valor_11.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_11.Location = New System.Drawing.Point(128, 16)
        Me._Valor_11.MaxLength = 0
        Me._Valor_11.Name = "_Valor_11"
        Me._Valor_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_11.Size = New System.Drawing.Size(41, 20)
        Me._Valor_11.TabIndex = 26
        Me._Valor_11.Text = "Text2"
        '
        '_Valor_10
        '
        Me._Valor_10.AcceptsReturn = True
        Me._Valor_10.AutoSize = False
        Me._Valor_10.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_10.Location = New System.Drawing.Point(128, 32)
        Me._Valor_10.MaxLength = 0
        Me._Valor_10.Name = "_Valor_10"
        Me._Valor_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_10.Size = New System.Drawing.Size(41, 20)
        Me._Valor_10.TabIndex = 25
        Me._Valor_10.Text = "Text2"
        '
        '_Valor_9
        '
        Me._Valor_9.AcceptsReturn = True
        Me._Valor_9.AutoSize = False
        Me._Valor_9.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_9.Location = New System.Drawing.Point(128, 48)
        Me._Valor_9.MaxLength = 0
        Me._Valor_9.Name = "_Valor_9"
        Me._Valor_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_9.Size = New System.Drawing.Size(41, 20)
        Me._Valor_9.TabIndex = 24
        Me._Valor_9.Text = "Text2"
        '
        '_Valor_8
        '
        Me._Valor_8.AcceptsReturn = True
        Me._Valor_8.AutoSize = False
        Me._Valor_8.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_8.Location = New System.Drawing.Point(128, 64)
        Me._Valor_8.MaxLength = 0
        Me._Valor_8.Name = "_Valor_8"
        Me._Valor_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_8.Size = New System.Drawing.Size(41, 20)
        Me._Valor_8.TabIndex = 23
        Me._Valor_8.Text = "Text2"
        '
        '_Valor_7
        '
        Me._Valor_7.AcceptsReturn = True
        Me._Valor_7.AutoSize = False
        Me._Valor_7.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_7.Location = New System.Drawing.Point(128, 80)
        Me._Valor_7.MaxLength = 0
        Me._Valor_7.Name = "_Valor_7"
        Me._Valor_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_7.Size = New System.Drawing.Size(41, 20)
        Me._Valor_7.TabIndex = 22
        Me._Valor_7.Text = "Text2"
        '
        '_Etich_11
        '
        Me._Etich_11.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_11.Location = New System.Drawing.Point(8, 16)
        Me._Etich_11.Name = "_Etich_11"
        Me._Etich_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_11.Size = New System.Drawing.Size(113, 17)
        Me._Etich_11.TabIndex = 32
        Me._Etich_11.Text = "Diam. est. tubo       [mm]"
        '
        '_Etich_10
        '
        Me._Etich_10.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_10.Location = New System.Drawing.Point(8, 32)
        Me._Etich_10.Name = "_Etich_10"
        Me._Etich_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_10.Size = New System.Drawing.Size(113, 17)
        Me._Etich_10.TabIndex = 31
        Me._Etich_10.Text = "Spessore tubo      [mm]"
        '
        '_Etich_9
        '
        Me._Etich_9.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_9.Location = New System.Drawing.Point(8, 48)
        Me._Etich_9.Name = "_Etich_9"
        Me._Etich_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_9.Size = New System.Drawing.Size(113, 17)
        Me._Etich_9.TabIndex = 30
        Me._Etich_9.Text = "Lungh. rettilinea     [mm]"
        '
        '_Etich_8
        '
        Me._Etich_8.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_8.Location = New System.Drawing.Point(8, 64)
        Me._Etich_8.Name = "_Etich_8"
        Me._Etich_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_8.Size = New System.Drawing.Size(113, 17)
        Me._Etich_8.TabIndex = 29
        Me._Etich_8.Text = "Raggio minimo      [mm]"
        '
        '_Etich_7
        '
        Me._Etich_7.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_7.Location = New System.Drawing.Point(8, 80)
        Me._Etich_7.Name = "_Etich_7"
        Me._Etich_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_7.Size = New System.Drawing.Size(113, 17)
        Me._Etich_7.TabIndex = 28
        Me._Etich_7.Text = "Incremento raggio [mm]"
        '
        '_Etich_6
        '
        Me._Etich_6.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_6.Location = New System.Drawing.Point(8, 96)
        Me._Etich_6.Name = "_Etich_6"
        Me._Etich_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_6.Size = New System.Drawing.Size(113, 17)
        Me._Etich_6.TabIndex = 27
        Me._Etich_6.Text = "Numero di file"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(520, 0)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(33, 33)
        Me.Command3.TabIndex = 19
        Me.Command3.Text = "OK"
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.AutoSize = False
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Enabled = False
        Me.Text2.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(240, 8)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(193, 22)
        Me.Text2.TabIndex = 16
        Me.Text2.Text = ""
        '
        '_Frame1_0
        '
        Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_0.Controls.Add(Me._ListView1_0)
        Me._Frame1_0.Controls.Add(Me.NUpDown1)
        Me._Frame1_0.Controls.Add(Me._Valor_0)
        Me._Frame1_0.Controls.Add(Me._Valor_1)
        Me._Frame1_0.Controls.Add(Me._Valor_2)
        Me._Frame1_0.Controls.Add(Me._Valor_3)
        Me._Frame1_0.Controls.Add(Me._Valor_4)
        Me._Frame1_0.Controls.Add(Me._Valor_5)
        Me._Frame1_0.Controls.Add(Me._Etich_5)
        Me._Frame1_0.Controls.Add(Me._Etich_4)
        Me._Frame1_0.Controls.Add(Me._Etich_3)
        Me._Frame1_0.Controls.Add(Me._Etich_2)
        Me._Frame1_0.Controls.Add(Me._Etich_1)
        Me._Frame1_0.Controls.Add(Me._Etich_0)
        Me._Frame1_0.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_0.Location = New System.Drawing.Point(8, 56)
        Me._Frame1_0.Name = "_Frame1_0"
        Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_0.Size = New System.Drawing.Size(177, 385)
        Me._Frame1_0.TabIndex = 2
        Me._Frame1_0.TabStop = False
        Me._Frame1_0.Text = "Gruppo n° 1"
        '
        '_ListView1_0
        '
        Me._ListView1_0.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me._ListView1_0.Location = New System.Drawing.Point(8, 120)
        Me._ListView1_0.MultiSelect = False
        Me._ListView1_0.Name = "_ListView1_0"
        Me._ListView1_0.Size = New System.Drawing.Size(160, 256)
        Me._ListView1_0.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me._ListView1_0.TabIndex = 55
        Me._ListView1_0.View = System.Windows.Forms.View.Details
        '
        'NUpDown1
        '
        Me.NUpDown1.Location = New System.Drawing.Point(152, 96)
        Me.NUpDown1.Name = "NUpDown1"
        Me.NUpDown1.Size = New System.Drawing.Size(20, 19)
        Me.NUpDown1.TabIndex = 51
        '
        '_Valor_0
        '
        Me._Valor_0.AcceptsReturn = True
        Me._Valor_0.AutoSize = False
        Me._Valor_0.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_0.Enabled = False
        Me._Valor_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_0.Location = New System.Drawing.Point(112, 96)
        Me._Valor_0.MaxLength = 0
        Me._Valor_0.Name = "_Valor_0"
        Me._Valor_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_0.Size = New System.Drawing.Size(41, 20)
        Me._Valor_0.TabIndex = 8
        Me._Valor_0.Text = "Text2"
        '
        '_Valor_1
        '
        Me._Valor_1.AcceptsReturn = True
        Me._Valor_1.AutoSize = False
        Me._Valor_1.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_1.Location = New System.Drawing.Point(128, 80)
        Me._Valor_1.MaxLength = 0
        Me._Valor_1.Name = "_Valor_1"
        Me._Valor_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_1.Size = New System.Drawing.Size(41, 20)
        Me._Valor_1.TabIndex = 7
        Me._Valor_1.Text = "Text2"
        '
        '_Valor_2
        '
        Me._Valor_2.AcceptsReturn = True
        Me._Valor_2.AutoSize = False
        Me._Valor_2.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_2.Location = New System.Drawing.Point(128, 64)
        Me._Valor_2.MaxLength = 0
        Me._Valor_2.Name = "_Valor_2"
        Me._Valor_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_2.Size = New System.Drawing.Size(41, 20)
        Me._Valor_2.TabIndex = 6
        Me._Valor_2.Text = "Text2"
        '
        '_Valor_3
        '
        Me._Valor_3.AcceptsReturn = True
        Me._Valor_3.AutoSize = False
        Me._Valor_3.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_3.Location = New System.Drawing.Point(128, 48)
        Me._Valor_3.MaxLength = 0
        Me._Valor_3.Name = "_Valor_3"
        Me._Valor_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_3.Size = New System.Drawing.Size(41, 20)
        Me._Valor_3.TabIndex = 5
        Me._Valor_3.Text = "Text2"
        '
        '_Valor_4
        '
        Me._Valor_4.AcceptsReturn = True
        Me._Valor_4.AutoSize = False
        Me._Valor_4.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_4.Location = New System.Drawing.Point(128, 32)
        Me._Valor_4.MaxLength = 0
        Me._Valor_4.Name = "_Valor_4"
        Me._Valor_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_4.Size = New System.Drawing.Size(41, 20)
        Me._Valor_4.TabIndex = 4
        Me._Valor_4.Text = "Text2"
        '
        '_Valor_5
        '
        Me._Valor_5.AcceptsReturn = True
        Me._Valor_5.AutoSize = False
        Me._Valor_5.BackColor = System.Drawing.SystemColors.Window
        Me._Valor_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valor_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valor_5.Location = New System.Drawing.Point(128, 16)
        Me._Valor_5.MaxLength = 0
        Me._Valor_5.Name = "_Valor_5"
        Me._Valor_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valor_5.Size = New System.Drawing.Size(41, 20)
        Me._Valor_5.TabIndex = 3
        Me._Valor_5.Text = "Text2"
        '
        '_Etich_5
        '
        Me._Etich_5.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_5.Location = New System.Drawing.Point(8, 96)
        Me._Etich_5.Name = "_Etich_5"
        Me._Etich_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_5.Size = New System.Drawing.Size(113, 17)
        Me._Etich_5.TabIndex = 14
        Me._Etich_5.Text = "Numero di file"
        '
        '_Etich_4
        '
        Me._Etich_4.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_4.Location = New System.Drawing.Point(8, 80)
        Me._Etich_4.Name = "_Etich_4"
        Me._Etich_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_4.Size = New System.Drawing.Size(113, 17)
        Me._Etich_4.TabIndex = 13
        Me._Etich_4.Text = "Incremento raggio [mm]"
        '
        '_Etich_3
        '
        Me._Etich_3.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_3.Location = New System.Drawing.Point(8, 64)
        Me._Etich_3.Name = "_Etich_3"
        Me._Etich_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_3.Size = New System.Drawing.Size(113, 17)
        Me._Etich_3.TabIndex = 12
        Me._Etich_3.Text = "Raggio minimo      [mm]"
        '
        '_Etich_2
        '
        Me._Etich_2.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_2.Location = New System.Drawing.Point(8, 48)
        Me._Etich_2.Name = "_Etich_2"
        Me._Etich_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_2.Size = New System.Drawing.Size(113, 17)
        Me._Etich_2.TabIndex = 11
        Me._Etich_2.Text = "Lungh. rettilinea     [mm]"
        '
        '_Etich_1
        '
        Me._Etich_1.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_1.Location = New System.Drawing.Point(8, 32)
        Me._Etich_1.Name = "_Etich_1"
        Me._Etich_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_1.Size = New System.Drawing.Size(113, 17)
        Me._Etich_1.TabIndex = 10
        Me._Etich_1.Text = "Spessore tubo      [mm]"
        '
        '_Etich_0
        '
        Me._Etich_0.BackColor = System.Drawing.SystemColors.Control
        Me._Etich_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Etich_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Etich_0.Location = New System.Drawing.Point(8, 16)
        Me._Etich_0.Name = "_Etich_0"
        Me._Etich_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Etich_0.Size = New System.Drawing.Size(113, 17)
        Me._Etich_0.TabIndex = 9
        Me._Etich_0.Text = "Diam. est. tubo       [mm]"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(168, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 25)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "File ADU"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "N° di gruppi"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(104, 8)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(56, 20)
        Me.NumericUpDown1.TabIndex = 54
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmGruppi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(556, 448)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me._Frame1_2)
        Me.Controls.Add(Me._Frame1_1)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me._Frame1_0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Name = "frmGruppi"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Gestione gruppi di tubi"
        Me._Frame1_2.ResumeLayout(False)
        CType(Me.NUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me._Frame1_1.ResumeLayout(False)
        CType(Me.NUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me._Frame1_0.ResumeLayout(False)
        CType(Me.NUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmGruppi
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmGruppi
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmGruppi()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public cotub As String
	Private Intest(13) As String
	Private Ngruppi As Short
	Private DuranteCarica As Boolean
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        OpenFileDialog1.InitialDirectory = Monitor.Motore.Inizio.Datidir
        OpenFileDialog1.FileName = cotub
        OpenFileDialog1.ShowDialog()
        cotub = OpenFileDialog1.FileName
		Carica()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        SaveFileDialog1.InitialDirectory = Monitor.Motore.Inizio.Datidir
        SaveFileDialog1.FileName = cotub
        SaveFileDialog1.ShowDialog()
        cotub = SaveFileDialog1.FileName
		Text2.Text = cotub
		Salva()
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		Salva()
		frmGruppi.DefInstance.Hide()
	End Sub
	
	'UPGRADE_WARNING: Form evento frmGruppi.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmGruppi_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Carica()
	End Sub
    Private ReadOnly Property Frame1(ByVal i As Short) As GroupBox
        Get
            Select Case i
                Case 0 : Return _Frame1_0
                Case 1 : Return _Frame1_1
                Case 2 : Return _Frame1_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Valor(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 0 : Return _Valor_0
                Case 1 : Return _Valor_1
                Case 2 : Return _Valor_2
                Case 3 : Return _Valor_3
                Case 4 : Return _Valor_4
                Case 5 : Return _Valor_5
                Case 6 : Return _Valor_6
                Case 7 : Return _Valor_7
                Case 8 : Return _Valor_8
                Case 9 : Return _Valor_9
                Case 10 : Return _Valor_10
                Case 11 : Return _Valor_11
                Case 12 : Return _Valor_12
                Case 13 : Return _Valor_13
                Case 14 : Return _Valor_14
                Case 15 : Return _Valor_15
                Case 16 : Return _Valor_16
                Case 17 : Return _Valor_17
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Carica()
        Dim ifl4 As Short
        Dim Testo As String = ""
        Dim Testo1 As String = ""
        Dim i, iNum As Short
        Dim Num As Single
        Dim k, Omog As Short
        Dim Item As System.Windows.Forms.ListViewItem
        Dim l As New System.Windows.Forms.ListView
        DuranteCarica = True
        On Error GoTo ErrCarica
        Text2.Text = cotub
        ifl4 = FreeFile()
        FileOpen(ifl4, cotub, OpenMode.Input)
        For i = 1 To 12
            Intest(i) = LineInput(ifl4)
        Next
        Input(ifl4, Ngruppi)
        Input(ifl4, Omog)
        Input(ifl4, Testo)
        Check1.CheckState = Omog
        NumericUpDown1.Value = Ngruppi
        Check1.Visible = Ngruppi > 1
        For i = 1 To Ngruppi
            If i > 3 Then
                MsgBox("Sono previsti 3 gruppi al massimo")
                GoTo Cont
            End If
            If i > 1 Then Frame1(i - 1).Visible = True
            Input(ifl4, Num)
            Input(ifl4, Testo) 'Diametro esterno
            Valor(5 + (i - 1) * 6).Text = GlobalRoutines.myStr(Num, 3, 3, False)
            Valor(5 + (i - 1) * 6).Tag = Testo
            Input(ifl4, Num)
            Input(ifl4, Testo) 'Spessore
            Valor(4 + (i - 1) * 6).Text = GlobalRoutines.myStr(Num, 3, 3, False)
            Valor(4 + (i - 1) * 6).Tag = Testo
            Input(ifl4, Num)
            Input(ifl4, Testo) 'Lunghezza
            Valor(3 + (i - 1) * 6).Text = GlobalRoutines.myStr(Num, 5, 1, False)
            Valor(3 + (i - 1) * 6).Tag = Testo
            Input(ifl4, Num)
            Input(ifl4, Testo) 'Raggio min
            Valor(2 + (i - 1) * 6).Tag = Testo
            Valor(2 + (i - 1) * 6).Text = GlobalRoutines.myStr(Num, 3, 3, False)
            Input(ifl4, Num)
            Input(ifl4, Testo) 'Incremento
            Intest(13) = LineInput(ifl4)
            Valor(1 + (i - 1) * 6).Text = GlobalRoutines.myStr(Num, 3, 3, False)
            Valor(1 + (i - 1) * 6).Tag = Testo
            Input(ifl4, iNum)
            Input(ifl4, Testo) 'N° file
            Valor(0 + (i - 1) * 6).Text = GlobalRoutines.myStr(CSng(iNum), 4, 0, True)
            Valor(0 + (i - 1) * 6).Tag = Testo
            Select Case i
                Case 0 : l = _ListView1_0
                Case 1 : l = _ListView1_1
                Case 2 : l = _ListView1_2
            End Select
            l.Items.Clear()
            For k = 1 To GlobalRoutines.ValVir(Valor(0 + (i - 1) * 6).Text)
                Input(ifl4, Testo1)
                Input(ifl4, Testo) 'N°
                Item = l.Items.Add(Testo1)
                Item.SubItems.Add(Testo)
            Next k
            Frame1(i - 1).Visible = True
Cont:   Next
        For i = Ngruppi + 1 To 3 : Frame1(i - 1).Visible = False : Next
ExCarica:
        FileClose(ifl4)
        DuranteCarica = False
        Exit Sub
ErrCarica: MsgBox("Il file ADU specificato non è valido" & Err.Description)
        Resume ExCarica
    End Sub
    Private Sub Valor_TextChanged(ByVal Index As Short)
        Dim kframe, Ind As Short
        Dim NuoveFile, VecchieFile As Short
        Dim i As Short
        Dim l As New ListView
        Dim lv As ListViewItem
        If DuranteCarica Then Exit Sub
        kframe = Index \ 6
        Select Case kframe
            Case 0 : l = _ListView1_0
            Case 1 : l = _ListView1_1
            Case 2 : l = _ListView1_2
        End Select
        Ind = Index Mod 6
        Select Case Ind
            Case 0 'n° file
                NuoveFile = GlobalRoutines.ValVir(Valor(Index).Text)
                If NuoveFile < 1 Then Exit Sub
                VecchieFile = l.Items.Count
                For i = VecchieFile To NuoveFile + 1 Step -1
                    l.Items.RemoveAt(i)
                Next
                For i = VecchieFile + 1 To NuoveFile
                    lv = l.Items.Add("1")
                    lv.SubItems.Add(i.ToString & "|FILA")
                Next
            Case Else
        End Select
    End Sub
    Private Sub Salva()
        Dim ifl4 As Short
        Dim i, k As Short
        Dim l As New ListView
        Dim lv As ListViewItem
        cotub = Text2.Text
        ifl4 = FreeFile()
        FileOpen(ifl4, cotub, OpenMode.Output)
        For i = 1 To 12
            PrintLine(ifl4, Intest(i))
        Next
        PrintLine(ifl4, Ngruppi, Check1.CheckState & ",N° GRUPPI (BARRE OMOGENNE (1/0)")
        For i = 1 To Ngruppi
            PrintLine(ifl4, Valor(5 + (i - 1) * 6).Text, ",", Valor(5 + (i - 1) * 6).Tag) 'Diametro esterno
            PrintLine(ifl4, Valor(4 + (i - 1) * 6).Text, ",", Valor(4 + (i - 1) * 6).Tag) 'Spessore
            PrintLine(ifl4, Valor(3 + (i - 1) * 6).Text, "," & Valor(3 + (i - 1) * 6).Tag) 'Lunghezza
            PrintLine(ifl4, Valor(2 + (i - 1) * 6).Text, "," & Valor(2 + (i - 1) * 6).Tag) 'Raggio min
            PrintLine(ifl4, Valor(1 + (i - 1) * 6).Text, ",", Valor(1 + (i - 1) * 6).Tag) 'Incremento
            PrintLine(ifl4, Intest(13))
            PrintLine(ifl4, Valor(0 + (i - 1) * 6).Text, ",", Valor(0 + (i - 1) * 6).Tag) 'N° file
            Select Case i
                Case 0 : l = _ListView1_0
                Case 1 : l = _ListView1_1
                Case 2 : l = _ListView1_2
            End Select
            For k = 1 To GlobalRoutines.ValVir(Valor(0 + (i - 1) * 6).Text)
                lv = l.Items(k)
                PrintLine(ifl4, lv.Text, ",", lv.SubItems(0).Text) 'N° file
            Next k
        Next
        FileClose(ifl4)

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim i As Short
        If DuranteCarica Then Exit Sub
        Dim Valore As Integer = NumericUpDown1.Value
        Dim l As New ListView
        Dim lv As ListViewItem
        If GlobalRoutines.ValVir(Valore) < Ngruppi Then
            Frame1(GlobalRoutines.ValVir(Valore) - 1).Visible = False
            Ngruppi = GlobalRoutines.ValVir(Valore)
        End If
        If GlobalRoutines.ValVir(Valore) > Ngruppi Then
            Frame1(GlobalRoutines.ValVir(Valore) - 1).Visible = True
            Ngruppi = GlobalRoutines.ValVir(Valore)
            Select Case Ngruppi
                Case 1 : l = _ListView1_0
                Case 2 : l = _ListView1_1
                Case 3 : l = _ListView1_2
            End Select
            DuranteCarica = True
            For i = 0 To 5
                Valor(i + (Ngruppi - 1) * 6).Text = Valor(i + (Ngruppi - 2) * 6).Text
                Valor(i + (Ngruppi - 1) * 6).Tag = Valor(i + (Ngruppi - 2) * 6).Tag
            Next
            l.Items.Clear()
            For i = 1 To GlobalRoutines.ValVir(Valor((Ngruppi - 1) * 6).Text)
                lv = l.Items.Add("1")
                lv.SubItems.Add(i.ToString & "|FILA")
            Next
            DuranteCarica = False
        End If
        Check1.Visible = Ngruppi > 1

    End Sub
    Private Sub NUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDown1.ValueChanged
        _Valor_0.Text = NUpDown1.Value.ToString
    End Sub
    Private Sub NUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDown2.ValueChanged
        _Valor_6.Text = NUpDown2.Value.ToString
    End Sub
    Private Sub NUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDown3.ValueChanged
        _Valor_12.Text = NUpDown3.Value.ToString
    End Sub

    Private Sub _Valor_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_0.TextChanged
        NUpDown1.Value = CInt(_Valor_0.Text)
    End Sub
    Private Sub _Valor_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_6.TextChanged
        NUpDown2.Value = CInt(_Valor_6.Text)
    End Sub
    Private Sub _Valor_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_12.TextChanged
        NUpDown3.Value = CInt(_Valor_12.Text)
    End Sub

    Private Sub _Valor_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_1.TextChanged
        Valor_TextChanged(0)
    End Sub

    Private Sub _Valor_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_10.TextChanged
        Valor_TextChanged(10)
    End Sub

    Private Sub _Valor_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_11.TextChanged
        Valor_TextChanged(11)
    End Sub

    Private Sub _Valor_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_13.TextChanged
        Valor_TextChanged(13)
    End Sub

    Private Sub _Valor_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_14.TextChanged
        Valor_TextChanged(14)
    End Sub

    Private Sub _Valor_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_15.TextChanged
        Valor_TextChanged(15)
    End Sub

    Private Sub _Valor_16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_16.TextChanged
        Valor_TextChanged(16)
    End Sub

    Private Sub _Valor_17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_17.TextChanged
        Valor_TextChanged(17)
    End Sub

    Private Sub _Valor_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_2.TextChanged
        Valor_TextChanged(2)
    End Sub

    Private Sub _Valor_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_3.TextChanged
        Valor_TextChanged(3)
    End Sub

    Private Sub _Valor_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_4.TextChanged
        Valor_TextChanged(4)
    End Sub

    Private Sub _Valor_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_5.TextChanged
        Valor_TextChanged(5)
    End Sub

    Private Sub _Valor_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_7.TextChanged
        Valor_TextChanged(7)
    End Sub

    Private Sub _Valor_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_8.TextChanged
        Valor_TextChanged(8)
    End Sub

    Private Sub _Valor_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Valor_9.TextChanged
        Valor_TextChanged(9)
    End Sub
End Class