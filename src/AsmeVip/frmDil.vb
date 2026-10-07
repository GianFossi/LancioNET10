Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmDil
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
        Inizializzando = True
        InitializeComponent()
        Inizializza()
        Attivata()
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
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents _cmbCil_4 As System.Windows.Forms.ComboBox
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
	Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
    Public WithEvents _cmbCil_3 As System.Windows.Forms.ComboBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
	Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
	Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
	Public WithEvents _TextCil_14 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
	Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_3 As System.Windows.Forms.Button
	Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
	Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
	Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
	Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
	Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents _TextCil_9 As System.Windows.Forms.NumericUpDown
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatConn As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDil))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me.List1 = New System.Windows.Forms.ListBox
        Me.Frames = New System.Windows.Forms.GroupBox
        Me._cmbCil_3 = New System.Windows.Forms.ComboBox
        Me._TextCil_9 = New System.Windows.Forms.NumericUpDown
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._cmbCil_4 = New System.Windows.Forms.ComboBox
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._TextCil_14 = New System.Windows.Forms.TextBox
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me.cmbMatConn = New System.Windows.Forms.ComboBox
        Me.Frames.SuspendLayout()
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(216, 104)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.TabIndex = 55
        Me.chkAgganciato.Text = "bound to library"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.Location = New System.Drawing.Point(0, 0)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(46, 17)
        Me.List1.TabIndex = 38
        Me.List1.Visible = False
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me.cmbMatConn)
        Me.Frames.Controls.Add(Me.cmbMat)
        Me.Frames.Controls.Add(Me.chkAgganciato)
        Me.Frames.Controls.Add(Me._cmbCil_3)
        Me.Frames.Controls.Add(Me._TextCil_9)
        Me.Frames.Controls.Add(Me._TextCil_13)
        Me.Frames.Controls.Add(Me._TextCil_7)
        Me.Frames.Controls.Add(Me._TextCil_10)
        Me.Frames.Controls.Add(Me._TextCil_6)
        Me.Frames.Controls.Add(Me._TextCil_1)
        Me.Frames.Controls.Add(Me._TextCil_5)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me._cmbCil_4)
        Me.Frames.Controls.Add(Me.Check1)
        Me.Frames.Controls.Add(Me._cmdCil_6)
        Me.Frames.Controls.Add(Me._cmdCil_0)
        Me.Frames.Controls.Add(Me._cmbCil_2)
        Me.Frames.Controls.Add(Me._cmdCil_5)
        Me.Frames.Controls.Add(Me._TextCil_14)
        Me.Frames.Controls.Add(Me._cmdCil_4)
        Me.Frames.Controls.Add(Me.Command2)
        Me.Frames.Controls.Add(Me._cmdCil_3)
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._cmbCil_1)
        Me.Frames.Controls.Add(Me._cmbCil_0)
        Me.Frames.Controls.Add(Me._cmdCil_1)
        Me.Frames.Controls.Add(Me._cmdCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_14)
        Me.Frames.Controls.Add(Me._LabelCil_13)
        Me.Frames.Controls.Add(Me._LabelCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_11)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_16)
        Me.Frames.Controls.Add(Me._LabelCil_15)
        Me.Frames.Controls.Add(Me._LabelCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_8)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_0)
        Me.Frames.Controls.Add(Me._LabelCil_7)
        Me.Frames.Controls.Add(Me._LabelCil_9)
        Me.Frames.Controls.Add(Me._LabelCil_12)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(329, 544)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        '_cmbCil_3
        '
        Me._cmbCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_3.Location = New System.Drawing.Point(136, 392)
        Me._cmbCil_3.Name = "_cmbCil_3"
        Me._cmbCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_3.Size = New System.Drawing.Size(186, 21)
        Me._cmbCil_3.TabIndex = 39
        '
        '_TextCil_9
        '
        Me._TextCil_9.Location = New System.Drawing.Point(224, 368)
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_9.TabIndex = 47
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(224, 344)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_13.TabIndex = 28
        Me._TextCil_13.Text = "Text1"
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(224, 272)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_7.TabIndex = 8
        Me._TextCil_7.Text = "Text1"
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_10.Location = New System.Drawing.Point(224, 320)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_10.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_10.TabIndex = 9
        Me._TextCil_10.Text = "Text1"
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(224, 248)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_6.TabIndex = 7
        Me._TextCil_6.Text = "Text1"
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(224, 224)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_1.TabIndex = 6
        Me._TextCil_1.Text = "Text1"
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(224, 200)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_5.TabIndex = 5
        Me._TextCil_5.Text = "Text1"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(224, 176)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_4.TabIndex = 4
        Me._TextCil_4.Tag = ""
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(224, 152)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_3.TabIndex = 3
        Me._TextCil_3.Text = "Text1"
        '
        '_cmbCil_4
        '
        Me._cmbCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_4.Location = New System.Drawing.Point(144, 128)
        Me._cmbCil_4.Name = "_cmbCil_4"
        Me._cmbCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_4.Size = New System.Drawing.Size(177, 21)
        Me._cmbCil_4.TabIndex = 45
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Checked = True
        Me.Check1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(16, 480)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(201, 19)
        Me.Check1.TabIndex = 44
        Me.Check1.Text = "Stampa pienamente documentata"
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(304, 416)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_6.TabIndex = 42
        Me._cmdCil_6.TabStop = False
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(304, 80)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_0.TabIndex = 12
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_2.Location = New System.Drawing.Point(144, 56)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_2.Size = New System.Drawing.Size(177, 21)
        Me._cmbCil_2.TabIndex = 33
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(304, 296)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_5.TabIndex = 32
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_14
        '
        Me._TextCil_14.AcceptsReturn = True
        Me._TextCil_14.AutoSize = False
        Me._TextCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_14.Location = New System.Drawing.Point(224, 296)
        Me._TextCil_14.MaxLength = 0
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_14.Size = New System.Drawing.Size(80, 20)
        Me._TextCil_14.TabIndex = 31
        Me._TextCil_14.Text = "Text1"
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(304, 344)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_4.TabIndex = 29
        Me._cmdCil_4.TabStop = False
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(224, 512)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 28)
        Me.Command2.TabIndex = 26
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(304, 224)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_3.TabIndex = 24
        Me._cmdCil_3.TabStop = False
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(272, 512)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(45, 28)
        Me.Command1.TabIndex = 23
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_1.Location = New System.Drawing.Point(144, 32)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_1.Size = New System.Drawing.Size(177, 21)
        Me._cmbCil_1.TabIndex = 2
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 8)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(177, 21)
        Me._cmbCil_0.TabIndex = 1
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(304, 248)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_1.TabIndex = 11
        Me._cmdCil_1.TabStop = False
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(304, 272)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_2.TabIndex = 10
        Me._cmdCil_2.TabStop = False
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(8, 128)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(107, 19)
        Me._LabelCil_14.TabIndex = 46
        Me._LabelCil_14.Text = "Material status"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(8, 416)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_13.TabIndex = 43
        Me._LabelCil_13.Text = "Connected shell mat'l"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 392)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_10.Size = New System.Drawing.Size(107, 19)
        Me._LabelCil_10.TabIndex = 40
        Me._LabelCil_10.Text = "Connected shell"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 368)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 37
        Me._LabelCil_11.Text = "Number of load conditions"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 56)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(107, 19)
        Me._LabelCil_4.TabIndex = 34
        Me._LabelCil_4.Text = "Bellow type"
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(8, 296)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_16.TabIndex = 30
        Me._LabelCil_16.Tag = "kTemp"
        Me._LabelCil_16.Text = "Design temperature"
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(8, 344)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_15.TabIndex = 27
        Me._LabelCil_15.Text = "Relative density of contained fluid"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 224)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_3.TabIndex = 25
        Me._LabelCil_3.Tag = "kPress"
        Me._LabelCil_3.Text = "Yield Strength @temp"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 248)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_8.TabIndex = 22
        Me._LabelCil_8.Tag = "kPress"
        Me._LabelCil_8.Text = "Allowable stress @ room"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 176)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_6.TabIndex = 21
        Me._LabelCil_6.Tag = "kLength"
        Me._LabelCil_6.Text = "Clad or WO thk."
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 152)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_5.TabIndex = 20
        Me._LabelCil_5.Text = "Joint efficiency"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 80)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_2, True)
        Me._LabelCil_2.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_2.TabIndex = 19
        Me._LabelCil_2.Text = "Bellow Material"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(107, 19)
        Me._LabelCil_1.TabIndex = 18
        Me._LabelCil_1.Text = "Bellow standard"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 8)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(124, 19)
        Me._LabelCil_0.TabIndex = 17
        Me._LabelCil_0.Text = "Bellow identification"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 200)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_7.TabIndex = 16
        Me._LabelCil_7.Tag = "kLength"
        Me._LabelCil_7.Text = "Corrosion allowance"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 272)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_9.TabIndex = 15
        Me._LabelCil_9.Tag = "kPress"
        Me._LabelCil_9.Text = "Allowable stress @ temp"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 320)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_12.Size = New System.Drawing.Size(177, 19)
        Me._LabelCil_12.TabIndex = 14
        Me._LabelCil_12.Tag = "kLength"
        Me._LabelCil_12.Text = "Hydrostatic depth"
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.Location = New System.Drawing.Point(96, 80)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(200, 21)
        Me.cmbMat.TabIndex = 56
        '
        'cmbMatConn
        '
        Me.cmbMatConn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatConn.Location = New System.Drawing.Point(120, 416)
        Me.cmbMatConn.Name = "cmbMatConn"
        Me.cmbMatConn.Size = New System.Drawing.Size(176, 21)
        Me.cmbMatConn.TabIndex = 57
        '
        'frmDil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(330, 543)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDil"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Dilatatore"
        Me.Frames.ResumeLayout(False)
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmDil
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmDil
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmDil()
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
        Dim k, ii As Short
        Top = 50 ' GlobalRoutines.TwipsToPixelsY(660)
        Left = 200 ' GlobalRoutines.TwipsToPixelsX(2835)
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("Flexible joint  ")
        _cmbCil_0.Items.Add("Other (write)")
        _cmbCil_0.SelectedIndex = 0
        _cmbCil_1.Items.Clear()
        _cmbCil_1.Items.Add("TEMA  ")
        _cmbCil_1.Items.Add("EJMA ")
        cmbCil(3).Items.Add("Nessuno")
        List1.Items.Add("Nessuno")
        ii = 0
        For k = 1 To Config(kLato).Ninvolucri
            If Involucr(kLato, k).Tipo = 0 Then
                cmbCil(3).Items.Add(Involucr(kLato, k).Mark)
                List1.Items.Add(Trim(Str(kLato)) & "_" & Trim(Str(k)))
                ii = ii + 1
                If Involucr(kLato, jInvolucr).AccoppJ = k Then cmbCil(3).SelectedIndex = ii
            End If
        Next
        If cmbCil(3).SelectedIndex = -1 Then cmbCil(3).SelectedIndex = 0
        _cmbCil_4.Items.Clear()
        _cmbCil_4.Items.Add("Annealed condition (without cold work)")
        _cmbCil_4.Items.Add("As-formed condition (with cold work)")
        _LabelCil_9.Visible = Not VerificandoPI
        _TextCil_7.Visible = Not VerificandoPI
        _cmdCil_2.Visible = Not VerificandoPI
        _LabelCil_15.Visible = Not VerificandoPI
        _TextCil_13.Visible = Not VerificandoPI
        _cmdCil_4.Visible = Not VerificandoPI
        Popola(cmbMat)
        Popola(cmbMatConn)
        If VerificandoPI Then _LabelCil_8.Text = "Allowable Stress in H.T."
        AggDati()
        With Involucr(kLato, jInvolucr)
            Dim O As wn_FTC = CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC)
            If O.Documented = 2 Then Check1.CheckState = System.Windows.Forms.CheckState.Checked Else Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
            If O.IndiceDilat > -1 Then
                _LabelCil_11.Visible = False : _TextCil_9.Visible = False
                _TextCil_9.Visible = False : Check1.Visible = False
            End If
        End With
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 1 : Return _TextCil_1
                Case 3 : Return _TextCil_3
                Case 4 : Return _TextCil_4
                Case 5 : Return _TextCil_5
                Case 6 : Return _TextCil_6
                Case 7 : Return _TextCil_7
                    '               Case 9 : Return _TextCil_9
                Case 10 : Return _TextCil_10
                Case 13 : Return _TextCil_13
                Case 14 : Return _TextCil_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim O As wn_FTC
        With Involucr(kLato, jInvolucr)
            O = CType(objMemb(.IndObject), wn_PT).Piastra
            If Check1.CheckState = 1 Then
                O.Documented = 2
            Else
                O.Documented = 1
            End If
        End With
    End Sub
    Private ReadOnly Property cmbCil(ByVal i As Short) As ComboBox
        Get
            Select Case i
                Case 0 : Return _cmbCil_0
                Case 1 : Return _cmbCil_1
                Case 2 : Return _cmbCil_2
                Case 3 : Return _cmbCil_3
                Case 4 : Return _cmbCil_4
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub cmbCil_SelectedIndexChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim n, vN, k As Short
        Dim j As Short
        If Dilatatore Is Nothing Then Dilatatore = New Grafica.Dilat
        With Involucr(kLato, jInvolucr)
            Select Case Index
                Case 0 'identification
                    .Mark = _cmbCil_0.Text
                Case 1 'standard
                    vN = .Norma
                    .Norma = cmbCil(Index).SelectedIndex + 1
                    If vN <> .Norma Or _cmbCil_2.Items.Count = 0 Then
                        AggCombo2()
                    End If
                Case 2 'tipo
                    Select Case _cmbCil_1.SelectedIndex
                        Case 0
                            LabelCil(14).Visible = False : _cmbCil_4.Visible = False
                            _cmdCil_6.Visible = True : cmbMatConn.Visible = True
                            _LabelCil_10.Visible = True : _LabelCil_13.Visible = True
                            cmbCil(3).Visible = True
                            Select Case cmbCil(Index).SelectedIndex
                                Case 0 : .SottoTipo = 1
                                Case 1 : .SottoTipo = 2
                                Case 2 : .SottoTipo = 6
                            End Select
                            Dilatatore.SottoTipo = .SottoTipo
                        Case 1
                            LabelCil(14).Visible = True : _cmbCil_4.Visible = True
                            _cmdCil_6.Visible = False : cmbMatConn.Visible = False
                            _LabelCil_10.Visible = False : _LabelCil_13.Visible = False
                            cmbCil(3).Visible = False
                            Select Case cmbCil(Index).SelectedIndex
                                Case 0 : .SottoTipo = 3
                                    'UPGRADE_NOTE: È possibile che l'oggetto Matdim() non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                                    If .indice(3 - 1) > 0 Then Matdim(.indice(3 - 1)) = Nothing
                                    .indice(3 - 1) = -1
                                    'UPGRADE_NOTE: È possibile che l'oggetto Matdim() non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                                    If .indice(4 - 1) > 0 Then Matdim(.indice(4 - 1)) = Nothing
                                    .indice(4 - 1) = -1
                                Case 1 : .SottoTipo = 4
                                    'UPGRADE_NOTE: È possibile che l'oggetto Matdim() non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                                    If .indice(4 - 1) > 0 Then Matdim(.indice(4 - 1)) = Nothing
                                    .indice(4 - 1) = -1
                                Case 2 : .SottoTipo = 5
                            End Select
                            Dilatatore.SottoTipo = .SottoTipo
                    End Select
                Case 3
                    List1.SelectedIndex = cmbCil(Index).SelectedIndex
                    If List1.Text = "Nessuno" Then
                        .AccoppK = 0
                        .AccoppJ = 0
                    Else
                        n = InStr(List1.Text, "_")
                        k = GlobalRoutines.ValVir(VB.Left(List1.Text, n - 1))
                        j = GlobalRoutines.ValVir(VB.Right(List1.Text, Len(List1.Text) - n))
                        .AccoppK = k
                        .AccoppJ = j
                        .indice(5 - 1) = Involucr(k, j).indice(1 - 1)
                        If .indice(5 - 1) > 0 Then
                            cmbMatConn.Text = Matdim(.indice(5 - 1)).MatStr
                            '080706 .RecInd(5 - 1) = Matdim(.indice(5 - 1)).Indmat
                        End If
                        Dilatatore.SpesCol = Involucr(k, j).Spess
                        If Dilatatore.LungCol = 0 Then Dilatatore.LungCol = Involucr(k, j).L0 / 2
                    End If
                    CheckCollegamenti()
                Case 4
                    Dim O As wn_FTC = CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC)
                    O.Ricotto = _cmbCil_4.SelectedIndex = 0
            End Select
        End With
    End Sub
    Private Sub cmdCil_Click(ByVal Index As Short)
        Select Case Index
            Case 0 : SelMat()
                PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(0))
                SubAmm()
            Case 1, 2, 3
                SubAmm()
            Case 4 : _TextCil_13.Text = GlobalRoutines.myStr(Config(kLato).DensFluido, 5, 3, False)
            Case 5 : _TextCil_14.Text = GlobalRoutines.myStr((TempDes() - 32) / 1.8 * kTemp - kTemp32, 5, 3, False)
            Case 6 : SelMat(5, 0)
                PostSelMat(cmbMatConn, Involucr(kLato, jInvolucr).indice(5 - 1))
        End Select
        Exit Sub
    End Sub
    Private Sub SubAmm()
        Dim Sfa, Sfo As Single
        Call Ammiss(jInvolucr)
        Dim p As wn_FTC = objMemb(Involucr(kLato, jInvolucr).IndObject).Piastra
        If VerificandoPI Then
            _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            p.Zp(0, 274) = Involucr(kLato, jInvolucr).Shydr * psi
        Else
            _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            _TextCil_7.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).YieldTemp(CodiceStress, TempDes, Sfa, Sfo)
            Involucr(kLato, jInvolucr).SU = Sfo
            _TextCil_1.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).SU * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            p.Zp(0, 274) = Involucr(kLato, jInvolucr).St * psi
        End If
        Dim O As wn_Dilat = p.objDilat
        If Not O Is Nothing Then O.Transfer(274, p)
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Cancel = False
        Hide()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        Hide()
    End Sub
    Private Sub Attivata()
        Dim i As Short
        AggCombo2()
        Select Case Involucr(kLato, jInvolucr).SottoTipo
            Case 1, 3 : i = 0
            Case 2, 4 : i = 1
            Case 5, 6 : i = 2
        End Select
        _cmbCil_2.SelectedIndex = i
    End Sub
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        With Involucr(kLato, jInvolucr)
            Select Case Index
                Case 1 : .SU = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 3 : .ES = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 4 : .OS = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 5 : .cs = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 6
                    If VerificandoPI Then
                        .Shydr = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        .S0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                Case 7 : .St = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 10 : .HydrDepth = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 13 : .DensFluido = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 14 : .Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
            End Select
        End With
    End Sub
    Private Sub AggCombo2()
        _cmbCil_2.Items.Clear()
        Select Case _cmbCil_1.SelectedIndex
            Case 0 'TEMA
                _cmbCil_2.Items.Add("Flued   (TEMA), constant thk.")
                _cmbCil_2.Items.Add("Flanged (TEMA), constant thk.")
                _cmbCil_2.Items.Add("Flued (TEMA), non uniform thks.")
            Case 1 'EJMA
                _cmbCil_2.Items.Add("EJMA, not-reinforced")
                _cmbCil_2.Items.Add("EJMA, with integral rings")
                _cmbCil_2.Items.Add("EJMA, with bolted rings")
        End Select
    End Sub
    Private Sub AggDati()
        Dim n As Short
        Dim O As wn_FTC
        With Involucr(kLato, jInvolucr)
            O = CType(objMemb(.IndObject).Piastra, wn_FTC)
            _cmbCil_0.Text = Trim(.Mark)
            If .Norma = 0 Then .Norma = 1
            _cmbCil_1.SelectedIndex = .Norma - 1
            If O.Ricotto Then _cmbCil_4.SelectedIndex = 0 Else _cmbCil_4.SelectedIndex = 1
            If .SottoTipo = 0 Then .SottoTipo = 1
            cmbMat.Text = .MATE.Trim
            _TextCil_1.Text = GlobalRoutines.myStr(.SU * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            _TextCil_3.Text = GlobalRoutines.myStr(.ES, 2, 2, False)
            _TextCil_4.Text = GlobalRoutines.myStr(.OS * kLength, 2, 2, False)
            _TextCil_5.Text = GlobalRoutines.myStr(.cs * kLength, 2, 2, False)
            If VerificandoPI Then
                _TextCil_6.Text = GlobalRoutines.myStr(.Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                _TextCil_6.Text = GlobalRoutines.myStr(.S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                _TextCil_7.Text = GlobalRoutines.myStr(.St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
            n = objMemb(.IndObject).Piastra.Zp(1, 261)
            If n > 0 Then _TextCil_9.Value = n Else _TextCil_9.Value = 1
            _TextCil_10.Text = GlobalRoutines.myStr(.HydrDepth * kLength, 5, 3, False)
            _TextCil_13.Text = GlobalRoutines.myStr(.DensFluido, 5, 3, False)
            _TextCil_14.Text = GlobalRoutines.myStr(.Destemp * kTemp + kTemp32, 5, 3, False)
            If Config(0).DiverseTemp = 0 Or VerificandoPI Then
                _LabelCil_16.Visible = False
                _TextCil_14.Visible = False
                _cmdCil_5.Visible = False
            End If
            If .indice(5 - 1) > 0 Then
                If Not Matdim(.indice(5 - 1)) Is Nothing Then
                    cmbMatConn.Text = Matdim(.indice(5 - 1)).MatStr
                End If
            End If
        End With
    End Sub
    Private Sub _TextCil_9_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.ValueChanged
        objMemb(Involucr(kLato, jInvolucr).IndObject).Piastra.Zp(1, 261) = _TextCil_9.Value
    End Sub

    Private Sub _TextCil_14_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.Leave
        AvvertiDT()
    End Sub
    Private Sub _TextCil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_1.TextChanged
        TextCil_TextChanged(1)
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
    Private Sub _TextCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.TextChanged
        TextCil_TextChanged(10)
    End Sub
    Private Sub _TextCil_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_13.TextChanged
        TextCil_TextChanged(13)
    End Sub
    Private Sub _TextCil_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.TextChanged
        TextCil_TextChanged(14)
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
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub _cmbCil_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Mark = _cmbCil_0.Text.Trim
    End Sub
    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(0)
    End Sub
    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(1)
    End Sub
    Private Sub _cmbCil_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_2.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(2)
    End Sub
    Private Sub _cmbCil_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_3.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(3)
    End Sub
    Private Sub _cmbCil_4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_4.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(4)
    End Sub
    Friend ReadOnly Property cmdCil(ByVal i As Short) As Button
        Get
            Select Case i
                Case 0 : Return _cmdCil_0
                Case 1 : Return _cmdCil_1
                Case 2 : Return _cmdCil_2
                Case 3 : Return _cmdCil_3
                Case 4 : Return _cmdCil_4
                Case 5 : Return _cmdCil_5
                Case 6 : Return _cmdCil_6
                Case Else : Return Nothing
            End Select
        End Get
    End Property

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

    Private Sub _cmdCil_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_5.Click
        cmdCil_Click(5)
    End Sub

    Private Sub _cmdCil_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_6.Click
        cmdCil_Click(6)
    End Sub

    Private Sub frmDil_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AggiornaLabels(Me, 15)
    End Sub

    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Involucr(kLato, jInvolucr).indice(0), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
        chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub

    Private Sub cmbMatConn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatConn.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatConn, Involucr(kLato, jInvolucr).indice(4), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatConn.SelectedIndex = nuovoSelect
    End Sub
End Class