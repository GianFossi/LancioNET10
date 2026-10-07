Option Strict Off
Option Explicit On
Friend Class frmConDoub
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
        inizializza()
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
	Public WithEvents _List1_20 As System.Windows.Forms.ListBox
	Public WithEvents _List1_0 As System.Windows.Forms.ListBox
	Public WithEvents _cmbCil_20 As System.Windows.Forms.ComboBox
	Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
	Public WithEvents _TextCil_30 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_29 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_28 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_27 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_26 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_25 As System.Windows.Forms.Button
	Public WithEvents _TextCil_26 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_25 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_24 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_23 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_22 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_21 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_20 As System.Windows.Forms.Button
	Public WithEvents _TextCil_20 As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_0 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_9 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
	Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
	Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConDoub))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me.Frames = New System.Windows.Forms.GroupBox
        Me._List1_20 = New System.Windows.Forms.ListBox
        Me._List1_0 = New System.Windows.Forms.ListBox
        Me._cmbCil_20 = New System.Windows.Forms.ComboBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._TextCil_30 = New System.Windows.Forms.TextBox
        Me._TextCil_29 = New System.Windows.Forms.TextBox
        Me._TextCil_28 = New System.Windows.Forms.TextBox
        Me._TextCil_27 = New System.Windows.Forms.TextBox
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._cmdCil_26 = New System.Windows.Forms.Button
        Me._cmdCil_25 = New System.Windows.Forms.Button
        Me._TextCil_26 = New System.Windows.Forms.TextBox
        Me._TextCil_25 = New System.Windows.Forms.TextBox
        Me._TextCil_24 = New System.Windows.Forms.TextBox
        Me._TextCil_23 = New System.Windows.Forms.TextBox
        Me._TextCil_22 = New System.Windows.Forms.TextBox
        Me._TextCil_21 = New System.Windows.Forms.TextBox
        Me._cmdCil_20 = New System.Windows.Forms.Button
        Me._TextCil_20 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me._TextCil_0 = New System.Windows.Forms.TextBox
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_9 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frames.SuspendLayout()
        Me.SuspendLayout()
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_10, "Cono.htm#k")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_10, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 241)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_10, True)
        Me._LabelCil_10.Size = New System.Drawing.Size(129, 17)
        Me._LabelCil_10.TabIndex = 28
        Me._LabelCil_10.Text = "Reinforcement factor k"
        Me.ToolTip1.SetToolTip(Me._LabelCil_10, "aaa")
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me._List1_20)
        Me.Frames.Controls.Add(Me._List1_0)
        Me.Frames.Controls.Add(Me._cmbCil_20)
        Me.Frames.Controls.Add(Me._cmbCil_0)
        Me.Frames.Controls.Add(Me._TextCil_30)
        Me.Frames.Controls.Add(Me._TextCil_29)
        Me.Frames.Controls.Add(Me._TextCil_28)
        Me.Frames.Controls.Add(Me._TextCil_27)
        Me.Frames.Controls.Add(Me._TextCil_8)
        Me.Frames.Controls.Add(Me._TextCil_7)
        Me.Frames.Controls.Add(Me._cmdCil_26)
        Me.Frames.Controls.Add(Me._cmdCil_25)
        Me.Frames.Controls.Add(Me._TextCil_26)
        Me.Frames.Controls.Add(Me._TextCil_25)
        Me.Frames.Controls.Add(Me._TextCil_24)
        Me.Frames.Controls.Add(Me._TextCil_23)
        Me.Frames.Controls.Add(Me._TextCil_22)
        Me.Frames.Controls.Add(Me._TextCil_21)
        Me.Frames.Controls.Add(Me._cmdCil_20)
        Me.Frames.Controls.Add(Me._TextCil_20)
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._TextCil_5)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me._TextCil_2)
        Me.Frames.Controls.Add(Me._TextCil_1)
        Me.Frames.Controls.Add(Me._TextCil_0)
        Me.Frames.Controls.Add(Me._TextCil_6)
        Me.Frames.Controls.Add(Me._TextCil_9)
        Me.Frames.Controls.Add(Me._TextCil_10)
        Me.Frames.Controls.Add(Me._cmdCil_0)
        Me.Frames.Controls.Add(Me._cmdCil_5)
        Me.Frames.Controls.Add(Me._cmdCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_15)
        Me.Frames.Controls.Add(Me._LabelCil_11)
        Me.Frames.Controls.Add(Me._LabelCil_7)
        Me.Frames.Controls.Add(Me._LabelCil_0)
        Me.Frames.Controls.Add(Me._LabelCil_8)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_9)
        Me.Frames.Controls.Add(Me._LabelCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_12)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(528, 297)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        '_List1_20
        '
        Me._List1_20.BackColor = System.Drawing.SystemColors.Window
        Me._List1_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._List1_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List1_20.Location = New System.Drawing.Point(296, 168)
        Me._List1_20.Name = "_List1_20"
        Me._List1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List1_20.Size = New System.Drawing.Size(49, 17)
        Me._List1_20.TabIndex = 48
        Me._List1_20.Visible = False
        '
        '_List1_0
        '
        Me._List1_0.BackColor = System.Drawing.SystemColors.Window
        Me._List1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._List1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List1_0.Location = New System.Drawing.Point(296, 96)
        Me._List1_0.Name = "_List1_0"
        Me._List1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List1_0.Size = New System.Drawing.Size(49, 17)
        Me._List1_0.TabIndex = 47
        Me._List1_0.Visible = False
        '
        '_cmbCil_20
        '
        Me._cmbCil_20.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_20.Location = New System.Drawing.Point(312, 48)
        Me._cmbCil_20.Name = "_cmbCil_20"
        Me._cmbCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_20.Size = New System.Drawing.Size(169, 21)
        Me._cmbCil_20.TabIndex = 12
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(96, 48)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(169, 21)
        Me._cmbCil_0.TabIndex = 1
        '
        '_TextCil_30
        '
        Me._TextCil_30.AcceptsReturn = True
        Me._TextCil_30.AutoSize = False
        Me._TextCil_30.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_30, "Cono.htm#A")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_30, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_30.Location = New System.Drawing.Point(408, 260)
        Me._TextCil_30.MaxLength = 0
        Me._TextCil_30.Name = "_TextCil_30"
        Me._TextCil_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_30, True)
        Me._TextCil_30.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_30.TabIndex = 22
        Me._TextCil_30.Text = ""
        '
        '_TextCil_29
        '
        Me._TextCil_29.AcceptsReturn = True
        Me._TextCil_29.AutoSize = False
        Me._TextCil_29.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_29, "Cono.htm#k")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_29, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_29.Location = New System.Drawing.Point(408, 240)
        Me._TextCil_29.MaxLength = 0
        Me._TextCil_29.Name = "_TextCil_29"
        Me._TextCil_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_29, True)
        Me._TextCil_29.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_29.TabIndex = 21
        Me._TextCil_29.Text = ""
        '
        '_TextCil_28
        '
        Me._TextCil_28.AcceptsReturn = True
        Me._TextCil_28.AutoSize = False
        Me._TextCil_28.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_28, "Cono.htm#f")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_28, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_28.Location = New System.Drawing.Point(408, 221)
        Me._TextCil_28.MaxLength = 0
        Me._TextCil_28.Name = "_TextCil_28"
        Me._TextCil_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_28, True)
        Me._TextCil_28.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_28.TabIndex = 20
        Me._TextCil_28.Text = ""
        '
        '_TextCil_27
        '
        Me._TextCil_27.AcceptsReturn = True
        Me._TextCil_27.AutoSize = False
        Me._TextCil_27.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_27, "Cono.htm#f")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_27, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_27.Location = New System.Drawing.Point(408, 202)
        Me._TextCil_27.MaxLength = 0
        Me._TextCil_27.Name = "_TextCil_27"
        Me._TextCil_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_27, True)
        Me._TextCil_27.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_27.TabIndex = 19
        Me._TextCil_27.Text = ""
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_8, "Cono.htm#f")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_8, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_8.Location = New System.Drawing.Point(192, 221)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_8, True)
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 9
        Me._TextCil_8.Text = ""
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_7, "Cono.htm#f")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_7, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_7.Location = New System.Drawing.Point(192, 202)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_7, True)
        Me._TextCil_7.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_7.TabIndex = 8
        Me._TextCil_7.Text = ""
        '
        '_cmdCil_26
        '
        Me._cmdCil_26.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_26.Image = CType(resources.GetObject("_cmdCil_26.Image"), System.Drawing.Image)
        Me._cmdCil_26.Location = New System.Drawing.Point(488, 183)
        Me._cmdCil_26.Name = "_cmdCil_26"
        Me._cmdCil_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_26.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_26.TabIndex = 42
        Me._cmdCil_26.TabStop = False
        Me._cmdCil_26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_25
        '
        Me._cmdCil_25.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_25.Image = CType(resources.GetObject("_cmdCil_25.Image"), System.Drawing.Image)
        Me._cmdCil_25.Location = New System.Drawing.Point(488, 164)
        Me._cmdCil_25.Name = "_cmdCil_25"
        Me._cmdCil_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_25.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_25.TabIndex = 41
        Me._cmdCil_25.TabStop = False
        Me._cmdCil_25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_26
        '
        Me._TextCil_26.AcceptsReturn = True
        Me._TextCil_26.AutoSize = False
        Me._TextCil_26.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_26.Location = New System.Drawing.Point(408, 183)
        Me._TextCil_26.MaxLength = 0
        Me._TextCil_26.Name = "_TextCil_26"
        Me._TextCil_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_26.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_26.TabIndex = 18
        Me._TextCil_26.Text = ""
        '
        '_TextCil_25
        '
        Me._TextCil_25.AcceptsReturn = True
        Me._TextCil_25.AutoSize = False
        Me._TextCil_25.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_25.Location = New System.Drawing.Point(408, 164)
        Me._TextCil_25.MaxLength = 0
        Me._TextCil_25.Name = "_TextCil_25"
        Me._TextCil_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_25.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_25.TabIndex = 17
        Me._TextCil_25.Text = ""
        '
        '_TextCil_24
        '
        Me._TextCil_24.AcceptsReturn = True
        Me._TextCil_24.AutoSize = False
        Me._TextCil_24.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_24.Location = New System.Drawing.Point(408, 144)
        Me._TextCil_24.MaxLength = 0
        Me._TextCil_24.Name = "_TextCil_24"
        Me._TextCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_24.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_24.TabIndex = 16
        Me._TextCil_24.Text = ""
        '
        '_TextCil_23
        '
        Me._TextCil_23.AcceptsReturn = True
        Me._TextCil_23.AutoSize = False
        Me._TextCil_23.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_23.Location = New System.Drawing.Point(408, 125)
        Me._TextCil_23.MaxLength = 0
        Me._TextCil_23.Name = "_TextCil_23"
        Me._TextCil_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_23.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_23.TabIndex = 15
        Me._TextCil_23.Text = ""
        '
        '_TextCil_22
        '
        Me._TextCil_22.AcceptsReturn = True
        Me._TextCil_22.AutoSize = False
        Me._TextCil_22.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_22.Location = New System.Drawing.Point(408, 106)
        Me._TextCil_22.MaxLength = 0
        Me._TextCil_22.Name = "_TextCil_22"
        Me._TextCil_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_22.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_22.TabIndex = 14
        Me._TextCil_22.Text = ""
        '
        '_TextCil_21
        '
        Me._TextCil_21.AcceptsReturn = True
        Me._TextCil_21.AutoSize = False
        Me._TextCil_21.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_21.Location = New System.Drawing.Point(408, 87)
        Me._TextCil_21.MaxLength = 0
        Me._TextCil_21.Name = "_TextCil_21"
        Me._TextCil_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_21.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_21.TabIndex = 13
        Me._TextCil_21.Text = ""
        Me._TextCil_21.Visible = False
        '
        '_cmdCil_20
        '
        Me._cmdCil_20.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_20.Image = CType(resources.GetObject("_cmdCil_20.Image"), System.Drawing.Image)
        Me._cmdCil_20.Location = New System.Drawing.Point(488, 68)
        Me._cmdCil_20.Name = "_cmdCil_20"
        Me._cmdCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_20.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_20.TabIndex = 40
        Me._cmdCil_20.TabStop = False
        Me._cmdCil_20.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_20
        '
        Me._TextCil_20.AcceptsReturn = True
        Me._TextCil_20.AutoSize = False
        Me._TextCil_20.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_20.Location = New System.Drawing.Point(312, 68)
        Me._TextCil_20.MaxLength = 0
        Me._TextCil_20.Name = "_TextCil_20"
        Me._TextCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_20.Size = New System.Drawing.Size(169, 20)
        Me._TextCil_20.TabIndex = 39
        Me._TextCil_20.TabStop = False
        Me._TextCil_20.Text = ""
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(483, 264)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(38, 25)
        Me.Command1.TabIndex = 37
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(192, 164)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_5.TabIndex = 6
        Me._TextCil_5.Text = ""
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 144)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 5
        Me._TextCil_4.Text = ""
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(192, 125)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 4
        Me._TextCil_3.Text = ""
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(192, 106)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 3
        Me._TextCil_2.Text = ""
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(192, 87)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_1.TabIndex = 2
        Me._TextCil_1.Text = ""
        Me._TextCil_1.Visible = False
        '
        '_TextCil_0
        '
        Me._TextCil_0.AcceptsReturn = True
        Me._TextCil_0.AutoSize = False
        Me._TextCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_0.Location = New System.Drawing.Point(96, 68)
        Me._TextCil_0.MaxLength = 0
        Me._TextCil_0.Name = "_TextCil_0"
        Me._TextCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_0.Size = New System.Drawing.Size(169, 20)
        Me._TextCil_0.TabIndex = 26
        Me._TextCil_0.TabStop = False
        Me._TextCil_0.Text = ""
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(192, 183)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_6.TabIndex = 7
        Me._TextCil_6.Text = ""
        '
        '_TextCil_9
        '
        Me._TextCil_9.AcceptsReturn = True
        Me._TextCil_9.AutoSize = False
        Me._TextCil_9.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_9, "Cono.htm#k")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_9, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_9.Location = New System.Drawing.Point(192, 240)
        Me._TextCil_9.MaxLength = 0
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_9, True)
        Me._TextCil_9.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_9.TabIndex = 10
        Me._TextCil_9.Text = ""
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_10, "Cono.htm#A")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_10, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_10.Location = New System.Drawing.Point(192, 260)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_10, True)
        Me._TextCil_10.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_10.TabIndex = 11
        Me._TextCil_10.Text = ""
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(272, 68)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 25
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(272, 164)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 24
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(272, 183)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_6.TabIndex = 23
        Me._cmdCil_6.TabStop = False
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(8, 50)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(81, 17)
        Me._LabelCil_15.TabIndex = 46
        Me._LabelCil_15.Text = "Cylinder mark"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_11, "Cono.htm#f")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_11, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 222)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_11, True)
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 44
        Me._LabelCil_11.Tag = "kForce"
        Me._LabelCil_11.Text = "Axial load (case #2)"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_7, "Cono.htm#f")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_7, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 203)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_7, True)
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_7.TabIndex = 43
        Me._LabelCil_7.Tag = "kForce"
        Me._LabelCil_7.Text = "Axial load (case #1) "
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(312, 20)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 38
        Me._LabelCil_0.Text = "Cylinder on small end"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 164)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_8.TabIndex = 36
        Me._LabelCil_8.Tag = "kPress"
        Me._LabelCil_8.Text = "Allowable stress @ room"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 146)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 35
        Me._LabelCil_6.Text = "Joint efficiency (longitudinal cone)"
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 127)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(192, 17)
        Me._LabelCil_5.TabIndex = 34
        Me._LabelCil_5.Text = "Joint efficiency (longitudinal cylinder)"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 108)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(161, 17)
        Me._LabelCil_4.TabIndex = 33
        Me._LabelCil_4.Tag = "kLength"
        Me._LabelCil_4.Text = "Cylinder length [mm]"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 88)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_3.TabIndex = 32
        Me._LabelCil_3.Tag = "kLength"
        Me._LabelCil_3.Text = "Cylinder thickness [mm]"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 68)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_2.Size = New System.Drawing.Size(89, 17)
        Me._LabelCil_2.TabIndex = 31
        Me._LabelCil_2.Text = "Material"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(144, 20)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_1.TabIndex = 30
        Me._LabelCil_1.Text = "Cylinder on large end"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 184)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_9.TabIndex = 29
        Me._LabelCil_9.Tag = "kPress"
        Me._LabelCil_9.Text = "Allowable stress @ temp"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_12, "Cono.htm#A")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_12, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 260)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_12, True)
        Me._LabelCil_12.Size = New System.Drawing.Size(184, 17)
        Me._LabelCil_12.TabIndex = 27
        Me._LabelCil_12.Tag = "kArea"
        Me._LabelCil_12.Text = "Provided reinforcement area"
        '
        'frmConDoub
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(530, 299)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConDoub"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Addizionali Cono"
        Me.Frames.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmConDoub
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmConDoub
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmConDoub()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Private Sub Inizializza()
        Dim i As Short
        Top = 50 ' GlobalRoutines.TwipsToPixelsY(660)
        Left = 200 ' GlobalRoutines.TwipsToPixelsX(2835)
        _List1_0.Items.Add("0")
        _List1_20.Items.Add("0")
        _cmbCil_0.Items.Add("Rigid connection")
        _cmbCil_20.Items.Add("Rigid connection")
        For i = 1 To Config(kLato).Ninvolucri
            If Involucr(kLato, i).Tipo = 0 Then
                _cmbCil_0.Items.Add(Involucr(kLato, i).Mark)
                _cmbCil_20.Items.Add(Involucr(kLato, i).Mark)
                _List1_0.Items.Add(i.ToString)
                _List1_20.Items.Add(i.ToString)
            End If
        Next
        If VerificandoPI Then
            _LabelCil_9.Visible = False
            _TextCil_6.Visible = False
            _cmdCil_6.Visible = False
            _TextCil_26.Visible = False
            cmdCil(26).Visible = False
            _LabelCil_8.Text = "Allowable stress in H.T."
        End If
        HelpProvider1.HelpNamespace = RadiceHelp
        ToolTip1.SetToolTip(_LabelCil_10, Monitor.Motore.Inizio.ConvertiCr(Helpstringa(2107)))
        ToolTip1.SetToolTip(_TextCil_9, Monitor.Motore.Inizio.ConvertiCr(Helpstringa(2107)))
        ToolTip1.SetToolTip(_TextCil_29, Monitor.Motore.Inizio.ConvertiCr(Helpstringa(2107)))
    End Sub
    Private Sub cmdCil_Click(ByVal Index As Short)
        Dim iyy, indice As Short
        Dim jmemb As Short
        Select Case Index
            Case 0, 5, 6
                iyy = 1
                jmemb = Involucr(kLato, jInvolucr).jmemb1
                indice = Involucr(kLato, jmemb).indice(1 - 1)
            Case 20, 25, 26
                iyy = 2
                jmemb = Involucr(kLato, jInvolucr).jmemb2
                indice = Involucr(kLato, jmemb).indice(1 - 1)
        End Select
        Select Case Index
            Case 0, 20 ' SelMat
                MatdimScelta(indice, Matdim(indice).Classe, kLato, jInvolucr)
                If Matdim(indice).Editato Then Uniforma(indice)
                TextCil(Index).Text = Matdim(indice).MatStr
                If iyy = 1 Then
                    AdditCono(kLato, jInvolucr).MATE1 = Matdim(indice).MatStr
                ElseIf iyy = 2 Then
                    AdditCono(kLato, jInvolucr).MATE2 = Matdim(indice).MatStr
                End If
                Involucr(kLato, jmemb).MATE = Matdim(indice).MatStr
                AdditCono(kLato, jInvolucr).matind(iyy - 1) = Matdim(indice).Indmat
            Case 5, 25, 6, 26
                ConAmm(jInvolucr, iyy)
                If VerificandoPI Then
                    TextCil((iyy - 1) * 20 + 5).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).Shydr(iyy - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    Involucr(kLato, jmemb).S0 = AdditCono(kLato, jInvolucr).Shydr(iyy - 1)
                Else
                    TextCil((iyy - 1) * 20 + 5).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).S0(iyy - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    TextCil((iyy - 1) * 20 + 6).Text = GlobalRoutines.myStr(AdditCono(kLato, jInvolucr).St(iyy - 1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    Involucr(kLato, jmemb).St = AdditCono(kLato, jInvolucr).St(iyy - 1)
                    Involucr(kLato, jmemb).S0 = AdditCono(kLato, jInvolucr).S0(iyy - 1)
                End If
        End Select
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Hide()
    End Sub
    Private Sub _HelpFile_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Testo As String
        Testo = "Vale 1 se non c'è anello di rinforzo. Altrimenti|"
        Testo = Testo & "è pari al rapporto del prodotto SE per il materiale|"
        Testo = Testo & "del mantello sullo stesso prodotto per il materiale| del rinforzo."
        MessageBox.Show(clsInizio.ConvertiCr(Testo))

    End Sub

    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        Dim j, iyy As Short
        _List1_0.SelectedIndex = _cmbCil_0.SelectedIndex
        j = GlobalRoutines.ValVir(_List1_0.Text)
        If j = 0 Then j = -1
        iyy = 1
        Involucr(kLato, jInvolucr).jmemb1 = j
        If Not j = -1 Then
            If AdditCono(kLato, jInvolucr).Spess(iyy - 1) = 0 Then AdditCono(kLato, jInvolucr).Spess(iyy - 1) = Involucr(kLato, j).Spess
            AggMatCil(iyy, jInvolucr)
        End If
        AggForm()
        CheckCollegamenti()
    End Sub

    Private Sub _cmbCil_20_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_20.SelectedIndexChanged
        Dim j, iyy As Short
        _List1_20.SelectedIndex = _cmbCil_20.SelectedIndex
        j = GlobalRoutines.ValVir(_List1_20.Text)
        If j = 0 Then j = -1
        Involucr(kLato, jInvolucr).jmemb2 = j
        iyy = 2
        If Not j = -1 Then
            If AdditCono(kLato, jInvolucr).Spess(iyy - 1) = 0 Then AdditCono(kLato, jInvolucr).Spess(iyy - 1) = Involucr(kLato, j).Spess
            AggMatCil(iyy, jInvolucr)
        End If
        AggForm()
        CheckCollegamenti()
    End Sub
    Friend ReadOnly Property cmdCil(ByVal i As Short) As Button
        Get
            Select Case i
                Case 0 : Return _cmdCil_0
                Case 5 : Return _cmdCil_5
                Case 6 : Return _cmdCil_6
                Case 20 : Return _cmdCil_20
                Case 25 : Return _cmdCil_25
                Case 26 : Return _cmdCil_26
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        cmdCil_Click(0)
    End Sub
    Private Sub _cmdCil_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_5.Click
        cmdCil_Click(5)
    End Sub
    Private Sub _cmdCil_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_6.Click
        cmdCil_Click(6)
    End Sub
    Private Sub _cmdCil_20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_20.Click
        cmdCil_Click(20)
    End Sub
    Private Sub _cmdCil_25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_25.Click
        cmdCil_Click(25)
    End Sub
    Private Sub _cmdCil_26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_26.Click
        cmdCil_Click(26)
    End Sub
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 0 : Return _TextCil_0
                Case 1 : Return _TextCil_1
                Case 2 : Return _TextCil_2
                Case 3 : Return _TextCil_3
                Case 4 : Return _TextCil_4
                Case 5 : Return _TextCil_5
                Case 6 : Return _TextCil_6
                Case 7 : Return _TextCil_7
                Case 8 : Return _TextCil_8
                Case 9 : Return _TextCil_9
                Case 10 : Return _TextCil_10
                Case 20 : Return _TextCil_20
                Case 21 : Return _TextCil_21
                Case 22 : Return _TextCil_22
                Case 23 : Return _TextCil_23
                Case 24 : Return _TextCil_24
                Case 25 : Return _TextCil_25
                Case 26 : Return _TextCil_26
                Case 27 : Return _TextCil_27
                Case 28 : Return _TextCil_28
                Case 29 : Return _TextCil_29
                Case 30 : Return _TextCil_30
                Case Else : Return Nothing
            End Select
        End Get
    End Property
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
                Case 15 : Return _LabelCil_15
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub frmConDoub_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AggiornaLabels(Me, 15)
    End Sub
End Class