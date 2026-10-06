Option Strict Off
Option Explicit On
Friend Class frmCil
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
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
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
	Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
	Public WithEvents _cmdCil_7 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
	Public WithEvents _TextCil_15 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_14 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
	Public WithEvents _TextCil_12 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
	Public WithEvents _TextCil_11 As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
	Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
	Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_3 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_18 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_17 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
	Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents _TextCil_9 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _TextCil_16 As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCil))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me.Frames = New System.Windows.Forms.GroupBox
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me._TextCil_16 = New System.Windows.Forms.NumericUpDown
        Me._TextCil_9 = New System.Windows.Forms.NumericUpDown
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me._cmdCil_7 = New System.Windows.Forms.Button
        Me._TextCil_15 = New System.Windows.Forms.TextBox
        Me._TextCil_14 = New System.Windows.Forms.TextBox
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._TextCil_12 = New System.Windows.Forms.TextBox
        Me._TextCil_11 = New System.Windows.Forms.TextBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me._LabelCil_18 = New System.Windows.Forms.Label
        Me._LabelCil_17 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frames.SuspendLayout()
        CType(Me._TextCil_16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(272, 384)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_6.TabIndex = 46
        Me._cmdCil_6.TabStop = False
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_6, "Riporta i valori del lato mantello e del lato tubi")
        Me._cmdCil_6.Visible = False
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(272, 352)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 39
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_5, "Riporta il valore definito per l'apparecchio")
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(272, 448)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 36
        Me._cmdCil_4.TabStop = False
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_4, "Riporta il valore definito per l'apparecchio")
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(160, 88)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.TabIndex = 54
        Me.chkAgganciato.Text = "bound to library"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(272, 64)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 16
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_0, "SEleziona e modifica le caratteristiche del materiale")
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me.cmbMat)
        Me.Frames.Controls.Add(Me.chkAgganciato)
        Me.Frames.Controls.Add(Me._TextCil_16)
        Me.Frames.Controls.Add(Me._TextCil_9)
        Me.Frames.Controls.Add(Me._cmbCil_2)
        Me.Frames.Controls.Add(Me._cmdCil_7)
        Me.Frames.Controls.Add(Me._cmdCil_6)
        Me.Frames.Controls.Add(Me._TextCil_15)
        Me.Frames.Controls.Add(Me._TextCil_14)
        Me.Frames.Controls.Add(Me._TextCil_13)
        Me.Frames.Controls.Add(Me._cmdCil_5)
        Me.Frames.Controls.Add(Me._TextCil_12)
        Me.Frames.Controls.Add(Me._cmdCil_4)
        Me.Frames.Controls.Add(Me._TextCil_11)
        Me.Frames.Controls.Add(Me.Command2)
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._TextCil_6)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me._TextCil_2)
        Me.Frames.Controls.Add(Me._TextCil_1)
        Me.Frames.Controls.Add(Me._cmbCil_1)
        Me.Frames.Controls.Add(Me._cmbCil_0)
        Me.Frames.Controls.Add(Me._TextCil_5)
        Me.Frames.Controls.Add(Me._TextCil_7)
        Me.Frames.Controls.Add(Me._TextCil_8)
        Me.Frames.Controls.Add(Me._TextCil_10)
        Me.Frames.Controls.Add(Me._cmdCil_0)
        Me.Frames.Controls.Add(Me._cmdCil_1)
        Me.Frames.Controls.Add(Me._cmdCil_2)
        Me.Frames.Controls.Add(Me._cmdCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_18)
        Me.Frames.Controls.Add(Me._LabelCil_17)
        Me.Frames.Controls.Add(Me._LabelCil_16)
        Me.Frames.Controls.Add(Me._LabelCil_15)
        Me.Frames.Controls.Add(Me._LabelCil_14)
        Me.Frames.Controls.Add(Me._LabelCil_13)
        Me.Frames.Controls.Add(Me._LabelCil_8)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_0)
        Me.Frames.Controls.Add(Me._LabelCil_7)
        Me.Frames.Controls.Add(Me._LabelCil_9)
        Me.Frames.Controls.Add(Me._LabelCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_11)
        Me.Frames.Controls.Add(Me._LabelCil_12)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(305, 528)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.Location = New System.Drawing.Point(88, 64)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(176, 21)
        Me.cmbMat.TabIndex = 55
        '
        '_TextCil_16
        '
        Me._TextCil_16.Location = New System.Drawing.Point(192, 328)
        Me._TextCil_16.Name = "_TextCil_16"
        Me._TextCil_16.Size = New System.Drawing.Size(72, 20)
        Me._TextCil_16.TabIndex = 53
        '
        '_TextCil_9
        '
        Me._TextCil_9.Location = New System.Drawing.Point(192, 472)
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.Size = New System.Drawing.Size(72, 20)
        Me._TextCil_9.TabIndex = 52
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_2.Location = New System.Drawing.Point(120, 184)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_2.Size = New System.Drawing.Size(145, 21)
        Me._cmbCil_2.TabIndex = 51
        Me._cmbCil_2.Visible = False
        '
        '_cmdCil_7
        '
        Me._cmdCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_7.Image = CType(resources.GetObject("_cmdCil_7.Image"), System.Drawing.Image)
        Me._cmdCil_7.Location = New System.Drawing.Point(272, 328)
        Me._cmdCil_7.Name = "_cmdCil_7"
        Me._cmdCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_7.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_7.TabIndex = 50
        Me._cmdCil_7.TabStop = False
        Me._cmdCil_7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_15
        '
        Me._TextCil_15.AcceptsReturn = True
        Me._TextCil_15.AutoSize = False
        Me._TextCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_15.Location = New System.Drawing.Point(192, 400)
        Me._TextCil_15.MaxLength = 0
        Me._TextCil_15.Name = "_TextCil_15"
        Me._TextCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_15.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_15.TabIndex = 44
        Me._TextCil_15.Text = "Text1"
        Me._TextCil_15.Visible = False
        '
        '_TextCil_14
        '
        Me._TextCil_14.AcceptsReturn = True
        Me._TextCil_14.AutoSize = False
        Me._TextCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_14.Location = New System.Drawing.Point(192, 376)
        Me._TextCil_14.MaxLength = 0
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_14.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_14.TabIndex = 42
        Me._TextCil_14.Text = "Text1"
        Me._TextCil_14.Visible = False
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(192, 160)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_13.TabIndex = 40
        Me._TextCil_13.Text = "Text1"
        '
        '_TextCil_12
        '
        Me._TextCil_12.AcceptsReturn = True
        Me._TextCil_12.AutoSize = False
        Me._TextCil_12.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_12.Location = New System.Drawing.Point(192, 352)
        Me._TextCil_12.MaxLength = 0
        Me._TextCil_12.Name = "_TextCil_12"
        Me._TextCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_12.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_12.TabIndex = 38
        Me._TextCil_12.Text = "Text1"
        '
        '_TextCil_11
        '
        Me._TextCil_11.AcceptsReturn = True
        Me._TextCil_11.AutoSize = False
        Me._TextCil_11.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_11.Location = New System.Drawing.Point(192, 448)
        Me._TextCil_11.MaxLength = 0
        Me._TextCil_11.Name = "_TextCil_11"
        Me._TextCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_11.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_11.TabIndex = 35
        Me._TextCil_11.Text = "Text1"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(208, 496)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 25)
        Me.Command2.TabIndex = 33
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(256, 496)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 25)
        Me.Command1.TabIndex = 32
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(192, 256)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_6.TabIndex = 9
        Me._TextCil_6.Text = "Text1"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 208)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 7
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(192, 184)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 6
        Me._TextCil_3.Text = "Text1"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(192, 136)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 5
        Me._TextCil_2.Text = "Text1"
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(192, 112)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_1.TabIndex = 4
        Me._TextCil_1.Text = "Text1"
        Me._TextCil_1.Visible = False
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_1.Location = New System.Drawing.Point(144, 40)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_1.Size = New System.Drawing.Size(121, 21)
        Me._cmbCil_1.TabIndex = 2
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 14)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(121, 21)
        Me._cmbCil_0.TabIndex = 1
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(192, 232)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_5.TabIndex = 8
        Me._TextCil_5.Text = "Text1"
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(192, 280)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_7.TabIndex = 10
        Me._TextCil_7.Text = "Text1"
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_8.Location = New System.Drawing.Point(192, 304)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 11
        Me._TextCil_8.Text = "Text1"
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_10.Location = New System.Drawing.Point(192, 424)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_10.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_10.TabIndex = 12
        Me._TextCil_10.Text = "Text1"
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(272, 256)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 15
        Me._cmdCil_1.TabStop = False
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(272, 280)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 14
        Me._cmdCil_2.TabStop = False
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(272, 112)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_3.TabIndex = 13
        Me._cmdCil_3.TabStop = False
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me._cmdCil_3.Visible = False
        '
        '_LabelCil_18
        '
        Me._LabelCil_18.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_18.Location = New System.Drawing.Point(8, 328)
        Me._LabelCil_18.Name = "_LabelCil_18"
        Me._LabelCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_18.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_18.TabIndex = 49
        Me._LabelCil_18.Text = "Number of interm. stiffening rings"
        '
        '_LabelCil_17
        '
        Me._LabelCil_17.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_17.Location = New System.Drawing.Point(8, 400)
        Me._LabelCil_17.Name = "_LabelCil_17"
        Me._LabelCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_17.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_17.TabIndex = 45
        Me._LabelCil_17.Tag = "kPress"
        Me._LabelCil_17.Text = "Design pressure (external)"
        Me._LabelCil_17.Visible = False
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(8, 376)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_16.TabIndex = 43
        Me._LabelCil_16.Tag = "kPress"
        Me._LabelCil_16.Text = "Design pressure (internal)"
        Me._LabelCil_16.Visible = False
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(8, 160)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_15.TabIndex = 41
        Me._LabelCil_15.Tag = "kLength"
        Me._LabelCil_15.Text = "Shell nominal thickness"
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(8, 352)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_14.TabIndex = 37
        Me._LabelCil_14.Tag = "kTemp"
        Me._LabelCil_14.Text = "Design temperature"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(8, 448)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_13.TabIndex = 34
        Me._LabelCil_13.Text = "Relative density of contained fluid"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 256)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_8.TabIndex = 31
        Me._LabelCil_8.Tag = "kPress"
        Me._LabelCil_8.Text = "Allowable stress @ room"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 208)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 30
        Me._LabelCil_6.Tag = "kLength"
        Me._LabelCil_6.Text = "Clad or WO thk."
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 184)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_5.TabIndex = 29
        Me._LabelCil_5.Text = "Joint efficiency"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 136)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(161, 17)
        Me._LabelCil_4.TabIndex = 28
        Me._LabelCil_4.Tag = "kLength"
        Me._LabelCil_4.Text = "Shell inner diameter"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 112)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_3.TabIndex = 27
        Me._LabelCil_3.Tag = "kLength"
        Me._LabelCil_3.Text = "Pipe Diameter [mm]"
        Me._LabelCil_3.Visible = False
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 64)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_2, True)
        Me._LabelCil_2.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_2.TabIndex = 26
        Me._LabelCil_2.Text = "Shell Material"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(105, 17)
        Me._LabelCil_1.TabIndex = 25
        Me._LabelCil_1.Text = "Shell Product"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 14)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 24
        Me._LabelCil_0.Text = "Shell identification"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 232)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_7.TabIndex = 23
        Me._LabelCil_7.Tag = "kLength"
        Me._LabelCil_7.Text = "Corrosion allowance"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 280)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_9.TabIndex = 22
        Me._LabelCil_9.Tag = "kPress"
        Me._LabelCil_9.Text = "Allowable stress @ temp"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 304)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_10.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_10.TabIndex = 21
        Me._LabelCil_10.Tag = "kLength"
        Me._LabelCil_10.Text = "Free length"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 472)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 20
        Me._LabelCil_11.Text = "Number of openings"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 424)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_12.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_12.TabIndex = 19
        Me._LabelCil_12.Tag = "kLength"
        Me._LabelCil_12.Text = "Hydrostatic depth"
        '
        'frmCil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(306, 527)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCil"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Cilindro"
        Me.Frames.ResumeLayout(False)
        CType(Me._TextCil_16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmCil
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmCil
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmCil()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public Cancel As Boolean
    Private Inizializzando As Boolean
    Private Sub Inizializza()
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(2835)
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("Shell        ")
        _cmbCil_0.Items.Add("Shell Cover  ")
        _cmbCil_0.Items.Add("Channel      ")
        _cmbCil_0.Items.Add("Other (write)")
        _cmbCil_1.Items.Clear()
        _cmbCil_1.Items.Add("Steel Plate")
        _cmbCil_1.Items.Add("Steel Forging")
        _cmbCil_1.Items.Add("Steel Pipe")
        If kLato = 3 Then
            _LabelCil_16.Visible = True
            LabelCil(17).Visible = True
            _TextCil_14.Visible = True
            _TextCil_15.Visible = True
            _cmdCil_6.Visible = True
        Else
            ' _LabelCil_10.Visible = Config(kLato).Vacuum
            LabelCil(18).Visible = Config(kLato).Vacuum
            _TextCil_16.Visible = Config(kLato).Vacuum
            ' _TextCil_8.Visible = Config(kLato).Vacuum
            _cmdCil_7.Visible = Config(kLato).Vacuum
        End If
        _LabelCil_9.Visible = Not VerificandoPI
        _TextCil_7.Visible = Not VerificandoPI
        _cmdCil_2.Visible = Not VerificandoPI
        _LabelCil_13.Visible = Not VerificandoPI
        _TextCil_11.Visible = Not VerificandoPI
        _cmdCil_4.Visible = Not VerificandoPI
        If VerificandoPI Then _LabelCil_8.Text = "Allowable stress in H.T."
        Popola(cmbMat)
        If div = 2 Then TestGroupCombo(_cmbCil_2, _LabelCil_8, _LabelCil_9)
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Public ReadOnly Property LabelCil(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _LabelCil_0
                Case 1 : Return _LabelCil_1
                Case 2 : Return _LabelCil_2
                Case 3 : Return _LabelCil_3
                Case 4 : Return _LabelCil_4
                Case 5 : Return _LabelCil_5
                Case 6 : Return _LabelCil_6
                Case 7 : Return _LabelCil_7
                Case 8 : Return _LabelCil_8
                Case 9 : Return _LabelCil_9
                Case 10 : Return _LabelCil_10
                Case 11 : Return _LabelCil_11
                Case 12 : Return _LabelCil_12
                Case 13 : Return _LabelCil_13
                Case 14 : Return _LabelCil_14
                Case 15 : Return _LabelCil_15
                Case 16 : Return _LabelCil_16
                Case 17 : Return _LabelCil_17
                Case 18 : Return _LabelCil_18
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 1 : Return _TextCil_1
                Case 2 : Return _TextCil_2
                Case 3 : Return _TextCil_3
                Case 4 : Return _TextCil_4
                Case 5 : Return _TextCil_5
                Case 6 : Return _TextCil_6
                Case 7 : Return _TextCil_7
                Case 8 : Return _TextCil_8
                    '               Case 9 : Return _TextCil_9
                Case 10 : Return _TextCil_10
                Case 11 : Return _TextCil_11
                Case 12 : Return _TextCil_12
                Case 13 : Return _TextCil_13
                Case 14 : Return _TextCil_14
                Case 15 : Return _TextCil_15
                    '                Case 16 : Return _TextCil_16
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub SubAmm()
        Call Ammiss(jInvolucr)
        If div = 2 Then
            _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            _TextCil_7.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        Else
            If VerificandoPI Then
                _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                _TextCil_7.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
        End If
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Cancel = False
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        Hide()
    End Sub
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        With Involucr(kLato, jInvolucr)
            Select Case Index
                Case 1 : .dns = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    .di = .dns - 2 * .Spess
                Case 2 : .di = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    .dns = .di + 2 * .Spess
                Case 3 : .ES = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 4 : .OS = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 5 : .cs = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 6
                    If VerificandoPI Or div = 2 Then
                        Involucr(kLato, jInvolucr).Shydr = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        Involucr(kLato, jInvolucr).S0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                Case 7 : .St = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 8 : .L0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    'Case 9 : VariaBocc(Val(TextCil(Index).Text))
                Case 10 : .HydrDepth = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 11 : .DensFluido = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 12 : .Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
                Case 13 : .Spess = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 14 : .PressInt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 15 : .PressExt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    '  Case 16 : .SottoTipo = GlobaLroutines.ValVir(TextCil(Index).Text)
                    ' If .SottoTipo > 0 And Visible Then StiffRings
                    '      _cmdCil_7.Visible = .SottoTipo > 0

            End Select
        End With
    End Sub
    Private Sub _TextCil_9_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.ValueChanged
        VariaBocc(_TextCil_9.Value)
    End Sub
    Private Sub _TextCil_16_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_16.ValueChanged
        With Involucr(kLato, jInvolucr)
            .SottoTipo = _TextCil_16.Value
            ' If .SottoTipo > 0 And Visible Then StiffRings
            _cmdCil_7.Visible = .SottoTipo > 0
        End With
    End Sub
    Private Sub _TextCil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_1.TextChanged
        TextCil_TextChanged(1)
    End Sub
    Private Sub _TextCil_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_2.TextChanged
        TextCil_TextChanged(2)
    End Sub
    Private Sub _TextCil_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_3.TextChanged
        TextCil_TextChanged(3)
    End Sub
    Private Sub _TextCil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_4.TextChanged
        TextCil_TextChanged(4)
    End Sub
    Private Sub _TextCil_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_5.TextChanged
        TextCil_TextChanged(5)
    End Sub
    Private Sub _TextCil_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_6.TextChanged
        TextCil_TextChanged(6)
    End Sub
    Private Sub _TextCil_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_7.TextChanged
        TextCil_TextChanged(7)
    End Sub
    Private Sub _TextCil_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_8.TextChanged
        TextCil_TextChanged(8)
    End Sub
    Private Sub _TextCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.TextChanged
        TextCil_TextChanged(10)
    End Sub
    Private Sub _TextCil_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_11.TextChanged
        TextCil_TextChanged(11)
    End Sub
    Private Sub _TextCil_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.TextChanged
        TextCil_TextChanged(12)
    End Sub
    Private Sub _TextCil_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_13.TextChanged
        TextCil_TextChanged(13)
    End Sub
    Private Sub _TextCil_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.TextChanged
        TextCil_TextChanged(14)
    End Sub
    Private Sub _TextCil_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_15.TextChanged
        TextCil_TextChanged(15)
    End Sub
    Private Sub _TextCil_12_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.Leave
        AvvertiDT()
    End Sub
    Private Sub _cmbCil_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Mark = _cmbCil_0.Text
    End Sub
    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        Involucr(kLato, jInvolucr).Mark = _cmbCil_0.Text
    End Sub
    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
        If Involucr(kLato, jInvolucr).ms <> _cmbCil_1.SelectedIndex Then
            Involucr(kLato, jInvolucr).ms = _cmbCil_1.SelectedIndex
            SelMat()
            PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(1 - 1))
            AggDatiCil(kLato, jInvolucr)
        End If 'l
    End Sub
    Private Sub _cmbCil_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_2.SelectedIndexChanged
        AggTestGroup(_cmbCil_2.SelectedIndex)
    End Sub
    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        SelMat()
        PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(1 - 1))
        SubAmm()
    End Sub
    Private Sub _cmdCil_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        SubAmm()
    End Sub
    Private Sub _cmdCil_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_2.Click
        SubAmm()
    End Sub
    Private Sub _cmdCil_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_3.Click
        Tubo = New LibMat.clsPipe
        Tubo.DoveMotore = Monitor.Motore
        Tubo.Diam = Involucr(kLato, jInvolucr).dns
        Tubo.Cerca(clsInizio.Archdir, clsInizio.DiscoTem)
        Tubo.Scelta(clsInizio.Archdir, clsInizio.DiscoTem)
        Involucr(kLato, jInvolucr).dns = Tubo.Diam
        Involucr(kLato, jInvolucr).Spess = Tubo.Spess
        _TextCil_1.Text = GlobalRoutines.myStr(Tubo.Diam * kLength, 5, 2, False)
        _TextCil_13.Text = GlobalRoutines.myStr(Tubo.Spess * kLength, 4, 2, False)
        Tubo = Nothing

    End Sub
    Private Sub _cmdCil_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_4.Click
        _TextCil_11.Text = GlobalRoutines.myStr(Config(kLato).DensFluido, 5, 3, False)
    End Sub
    Private Sub _cmdCil_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_5.Click
        _TextCil_12.Text = GlobalRoutines.myStr(TempDes() * kTemp + kTemp32, 5, 3, False)
    End Sub
    Private Sub _cmdCil_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_6.Click
        _TextCil_14.Text = GlobalRoutines.myStr(Config(2).p0x * kPress, 5, 3, False)
        _TextCil_15.Text = GlobalRoutines.myStr(Config(1).p0x * kPress, 5, 3, False)
    End Sub
    Private Sub _cmdCil_7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_7.Click
        StiffRings()
    End Sub
    Private Sub chkAgganciato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato = chkAgganciato.Checked
        ModifiedData = True
    End Sub
    Private Sub frmCil_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AggiornaLabels(Me, 18)
    End Sub
    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Involucr(kLato, jInvolucr).indice(0), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
        chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub
End Class