Option Strict Off
Option Explicit On
Friend Class frmAmm
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
        inizializzando = True
        InitializeComponent()
        inizializzando = False
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents TabStrip1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents _Command1_2 As System.Windows.Forms.Button
    Friend WithEvents _rtx_2 As System.Windows.Forms.RichTextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_9 As System.Windows.Forms.TextBox
    Public WithEvents _Command1_3 As System.Windows.Forms.Button
    Friend WithEvents _rtx_10 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_11 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_4 As System.Windows.Forms.RichTextBox
    Public WithEvents _Text1_10 As System.Windows.Forms.TextBox
    Public WithEvents _Command1_4 As System.Windows.Forms.Button
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _lblUni_1 As System.Windows.Forms.Label
    Public WithEvents _lblUni_2 As System.Windows.Forms.Label
    Public WithEvents _lblUni_3 As System.Windows.Forms.Label
    Public WithEvents _lblUni_4 As System.Windows.Forms.Label
    Public WithEvents _lblUni_5 As System.Windows.Forms.Label
    Public WithEvents _lblUni_6 As System.Windows.Forms.Label
    Public WithEvents _lblUni_7 As System.Windows.Forms.Label
    Public WithEvents _lblUni_8 As System.Windows.Forms.Label
    Public WithEvents _lblUni_9 As System.Windows.Forms.Label
    Public WithEvents _lblUni_10 As System.Windows.Forms.Label
    Public WithEvents _lblUni_11 As System.Windows.Forms.Label
    Public WithEvents _Command1_10 As System.Windows.Forms.Button
    Public WithEvents _Command1_8 As System.Windows.Forms.Button
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Friend WithEvents _rtx_1 As System.Windows.Forms.RichTextBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Command1_5 As System.Windows.Forms.Button
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Friend WithEvents _rtx_7 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_9 As System.Windows.Forms.RichTextBox
    Public WithEvents _Command1_6 As System.Windows.Forms.Button
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_8 As System.Windows.Forms.TextBox
    Friend WithEvents _rtx_5 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_8 As System.Windows.Forms.RichTextBox
    Public WithEvents _Text1_11 As System.Windows.Forms.TextBox
    Friend WithEvents _rtx_6 As System.Windows.Forms.RichTextBox
    Public WithEvents _Label1_11 As System.Windows.Forms.Label
    Friend WithEvents _rtx_3 As System.Windows.Forms.RichTextBox
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAmm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.TabStrip1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Command1_2 = New System.Windows.Forms.Button
        Me._rtx_2 = New System.Windows.Forms.RichTextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Text1_9 = New System.Windows.Forms.TextBox
        Me._rtx_10 = New System.Windows.Forms.RichTextBox
        Me._rtx_11 = New System.Windows.Forms.RichTextBox
        Me._rtx_4 = New System.Windows.Forms.RichTextBox
        Me._Text1_10 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._lblUni_1 = New System.Windows.Forms.Label
        Me._lblUni_5 = New System.Windows.Forms.Label
        Me._lblUni_8 = New System.Windows.Forms.Label
        Me._lblUni_10 = New System.Windows.Forms.Label
        Me._lblUni_11 = New System.Windows.Forms.Label
        Me._Command1_10 = New System.Windows.Forms.Button
        Me._Command1_8 = New System.Windows.Forms.Button
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._rtx_1 = New System.Windows.Forms.RichTextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._rtx_7 = New System.Windows.Forms.RichTextBox
        Me._rtx_9 = New System.Windows.Forms.RichTextBox
        Me._Command1_6 = New System.Windows.Forms.Button
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me._Text1_8 = New System.Windows.Forms.TextBox
        Me._rtx_5 = New System.Windows.Forms.RichTextBox
        Me._rtx_8 = New System.Windows.Forms.RichTextBox
        Me._Text1_11 = New System.Windows.Forms.TextBox
        Me._rtx_6 = New System.Windows.Forms.RichTextBox
        Me._rtx_3 = New System.Windows.Forms.RichTextBox
        Me._Command1_3 = New System.Windows.Forms.Button
        Me._Command1_4 = New System.Windows.Forms.Button
        Me._Command1_5 = New System.Windows.Forms.Button
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._lblUni_2 = New System.Windows.Forms.Label
        Me._lblUni_3 = New System.Windows.Forms.Label
        Me._lblUni_6 = New System.Windows.Forms.Label
        Me._lblUni_4 = New System.Windows.Forms.Label
        Me._lblUni_7 = New System.Windows.Forms.Label
        Me._lblUni_9 = New System.Windows.Forms.Label
        Me.TabStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(392, 160)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(48, 28)
        Me.cmdCancel.TabIndex = 56
        Me.cmdCancel.Text = "Cancel"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(392, 128)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(47, 28)
        Me.Command2.TabIndex = 31
        Me.Command2.Text = "Fatto"
        '
        'TabStrip1
        '
        Me.TabStrip1.Controls.Add(Me.TabPage1)
        Me.TabStrip1.Location = New System.Drawing.Point(0, 0)
        Me.TabStrip1.Name = "TabStrip1"
        Me.TabStrip1.SelectedIndex = 0
        Me.TabStrip1.Size = New System.Drawing.Size(384, 336)
        Me.TabStrip1.TabIndex = 110
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(376, 310)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me._Label1_10)
        Me.GroupBox1.Controls.Add(Me._Command1_2)
        Me.GroupBox1.Controls.Add(Me._rtx_2)
        Me.GroupBox1.Controls.Add(Me._Text1_3)
        Me.GroupBox1.Controls.Add(Me._Text1_9)
        Me.GroupBox1.Controls.Add(Me._rtx_10)
        Me.GroupBox1.Controls.Add(Me._rtx_11)
        Me.GroupBox1.Controls.Add(Me._rtx_4)
        Me.GroupBox1.Controls.Add(Me._Text1_10)
        Me.GroupBox1.Controls.Add(Me._Text1_0)
        Me.GroupBox1.Controls.Add(Me._Text1_1)
        Me.GroupBox1.Controls.Add(Me._Text1_2)
        Me.GroupBox1.Controls.Add(Me._Text1_4)
        Me.GroupBox1.Controls.Add(Me._lblUni_1)
        Me.GroupBox1.Controls.Add(Me._lblUni_5)
        Me.GroupBox1.Controls.Add(Me._lblUni_8)
        Me.GroupBox1.Controls.Add(Me._lblUni_10)
        Me.GroupBox1.Controls.Add(Me._lblUni_11)
        Me.GroupBox1.Controls.Add(Me._Command1_10)
        Me.GroupBox1.Controls.Add(Me._Command1_8)
        Me.GroupBox1.Controls.Add(Me._Text1_6)
        Me.GroupBox1.Controls.Add(Me._rtx_1)
        Me.GroupBox1.Controls.Add(Me._Text1_5)
        Me.GroupBox1.Controls.Add(Me._rtx_7)
        Me.GroupBox1.Controls.Add(Me._rtx_9)
        Me.GroupBox1.Controls.Add(Me._Command1_6)
        Me.GroupBox1.Controls.Add(Me._Text1_7)
        Me.GroupBox1.Controls.Add(Me._Text1_8)
        Me.GroupBox1.Controls.Add(Me._rtx_5)
        Me.GroupBox1.Controls.Add(Me._rtx_8)
        Me.GroupBox1.Controls.Add(Me._Text1_11)
        Me.GroupBox1.Controls.Add(Me._rtx_6)
        Me.GroupBox1.Controls.Add(Me._rtx_3)
        Me.GroupBox1.Controls.Add(Me._Command1_3)
        Me.GroupBox1.Controls.Add(Me._Command1_4)
        Me.GroupBox1.Controls.Add(Me._Command1_5)
        Me.GroupBox1.Controls.Add(Me._Label1_8)
        Me.GroupBox1.Controls.Add(Me._Label1_6)
        Me.GroupBox1.Controls.Add(Me._Label1_5)
        Me.GroupBox1.Controls.Add(Me._Label1_2)
        Me.GroupBox1.Controls.Add(Me._Label1_3)
        Me.GroupBox1.Controls.Add(Me._Label1_4)
        Me.GroupBox1.Controls.Add(Me._Label1_1)
        Me.GroupBox1.Controls.Add(Me._Label1_9)
        Me.GroupBox1.Controls.Add(Me._Label1_11)
        Me.GroupBox1.Controls.Add(Me._Label1_7)
        Me.GroupBox1.Controls.Add(Me._Label1_0)
        Me.GroupBox1.Controls.Add(Me._lblUni_2)
        Me.GroupBox1.Controls.Add(Me._lblUni_3)
        Me.GroupBox1.Controls.Add(Me._lblUni_6)
        Me.GroupBox1.Controls.Add(Me._lblUni_4)
        Me.GroupBox1.Controls.Add(Me._lblUni_7)
        Me.GroupBox1.Controls.Add(Me._lblUni_9)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 304)
        Me.GroupBox1.TabIndex = 165
        Me.GroupBox1.TabStop = False
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(8, 256)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(160, 19)
        Me._Label1_10.TabIndex = 218
        Me._Label1_10.Text = "Label1"
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_2.Image = CType(resources.GetObject("_Command1_2.Image"), System.Drawing.Image)
        Me._Command1_2.Location = New System.Drawing.Point(344, 64)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(24, 24)
        Me._Command1_2.TabIndex = 171
        Me._Command1_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_rtx_2
        '
        Me._rtx_2.Location = New System.Drawing.Point(184, 64)
        Me._rtx_2.Name = "_rtx_2"
        Me._rtx_2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_2.Size = New System.Drawing.Size(32, 24)
        Me._rtx_2.TabIndex = 208
        Me._rtx_2.Text = "Ag"
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_3.Location = New System.Drawing.Point(216, 88)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(82, 24)
        Me._Text1_3.TabIndex = 180
        Me._Text1_3.Text = "Textg"
        '
        '_Text1_9
        '
        Me._Text1_9.AcceptsReturn = True
        Me._Text1_9.AutoSize = False
        Me._Text1_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_9.Location = New System.Drawing.Point(216, 232)
        Me._Text1_9.MaxLength = 0
        Me._Text1_9.Name = "_Text1_9"
        Me._Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_9.Size = New System.Drawing.Size(82, 24)
        Me._Text1_9.TabIndex = 174
        Me._Text1_9.Text = "Textg"
        '
        '_rtx_10
        '
        Me._rtx_10.Location = New System.Drawing.Point(184, 256)
        Me._rtx_10.Name = "_rtx_10"
        Me._rtx_10.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_10.Size = New System.Drawing.Size(32, 24)
        Me._rtx_10.TabIndex = 216
        Me._rtx_10.Text = "Ag"
        '
        '_rtx_11
        '
        Me._rtx_11.Location = New System.Drawing.Point(184, 280)
        Me._rtx_11.Name = "_rtx_11"
        Me._rtx_11.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_11.Size = New System.Drawing.Size(32, 24)
        Me._rtx_11.TabIndex = 217
        Me._rtx_11.Text = "Ag"
        '
        '_rtx_4
        '
        Me._rtx_4.Location = New System.Drawing.Point(184, 112)
        Me._rtx_4.Name = "_rtx_4"
        Me._rtx_4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_4.Size = New System.Drawing.Size(32, 24)
        Me._rtx_4.TabIndex = 210
        Me._rtx_4.Text = "Ag"
        '
        '_Text1_10
        '
        Me._Text1_10.AcceptsReturn = True
        Me._Text1_10.AutoSize = False
        Me._Text1_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_10.Location = New System.Drawing.Point(216, 256)
        Me._Text1_10.MaxLength = 0
        Me._Text1_10.Name = "_Text1_10"
        Me._Text1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_10.Size = New System.Drawing.Size(82, 24)
        Me._Text1_10.TabIndex = 173
        Me._Text1_10.Text = "Textg"
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(104, 16)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(256, 24)
        Me._Text1_0.TabIndex = 194
        Me._Text1_0.Text = "Textg,.1234"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(216, 40)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(82, 24)
        Me._Text1_1.TabIndex = 182
        Me._Text1_1.Text = "Textg,.1234"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(216, 64)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(82, 24)
        Me._Text1_2.TabIndex = 181
        Me._Text1_2.Text = "Textg"
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(216, 112)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(82, 24)
        Me._Text1_4.TabIndex = 179
        Me._Text1_4.Text = "Textg"
        '
        '_lblUni_1
        '
        Me._lblUni_1.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_1.Location = New System.Drawing.Point(304, 40)
        Me._lblUni_1.Name = "_lblUni_1"
        Me._lblUni_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_1.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_1.TabIndex = 196
        Me._lblUni_1.Text = "Label2"
        Me._lblUni_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_5
        '
        Me._lblUni_5.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_5.Location = New System.Drawing.Point(304, 136)
        Me._lblUni_5.Name = "_lblUni_5"
        Me._lblUni_5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_5.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_5.TabIndex = 200
        Me._lblUni_5.Text = "Label2"
        Me._lblUni_5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_8
        '
        Me._lblUni_8.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_8.Location = New System.Drawing.Point(304, 208)
        Me._lblUni_8.Name = "_lblUni_8"
        Me._lblUni_8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_8.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_8.TabIndex = 203
        Me._lblUni_8.Text = "Label2"
        Me._lblUni_8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_10
        '
        Me._lblUni_10.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_10.Location = New System.Drawing.Point(304, 256)
        Me._lblUni_10.Name = "_lblUni_10"
        Me._lblUni_10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_10.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_10.TabIndex = 205
        Me._lblUni_10.Text = "Label2"
        Me._lblUni_10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_11
        '
        Me._lblUni_11.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_11.Location = New System.Drawing.Point(304, 280)
        Me._lblUni_11.Name = "_lblUni_11"
        Me._lblUni_11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_11.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_11.TabIndex = 206
        Me._lblUni_11.Text = "Label2"
        Me._lblUni_11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Command1_10
        '
        Me._Command1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_10.Image = CType(resources.GetObject("_Command1_10.Image"), System.Drawing.Image)
        Me._Command1_10.Location = New System.Drawing.Point(344, 256)
        Me._Command1_10.Name = "_Command1_10"
        Me._Command1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_10.Size = New System.Drawing.Size(24, 24)
        Me._Command1_10.TabIndex = 165
        Me._Command1_10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Command1_8
        '
        Me._Command1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_8.Image = CType(resources.GetObject("_Command1_8.Image"), System.Drawing.Image)
        Me._Command1_8.Location = New System.Drawing.Point(344, 208)
        Me._Command1_8.Name = "_Command1_8"
        Me._Command1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_8.Size = New System.Drawing.Size(24, 24)
        Me._Command1_8.TabIndex = 166
        Me._Command1_8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_6.Location = New System.Drawing.Point(216, 160)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(82, 24)
        Me._Text1_6.TabIndex = 177
        Me._Text1_6.Text = "Textg"
        '
        '_rtx_1
        '
        Me._rtx_1.Location = New System.Drawing.Point(184, 40)
        Me._rtx_1.Name = "_rtx_1"
        Me._rtx_1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_1.Size = New System.Drawing.Size(32, 24)
        Me._rtx_1.TabIndex = 207
        Me._rtx_1.Text = "Ag"
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(216, 136)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(82, 24)
        Me._Text1_5.TabIndex = 178
        Me._Text1_5.Text = "Textg"
        '
        '_rtx_7
        '
        Me._rtx_7.Location = New System.Drawing.Point(184, 184)
        Me._rtx_7.Name = "_rtx_7"
        Me._rtx_7.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_7.Size = New System.Drawing.Size(32, 24)
        Me._rtx_7.TabIndex = 213
        Me._rtx_7.Text = "Ag"
        '
        '_rtx_9
        '
        Me._rtx_9.Location = New System.Drawing.Point(184, 232)
        Me._rtx_9.Name = "_rtx_9"
        Me._rtx_9.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_9.Size = New System.Drawing.Size(32, 24)
        Me._rtx_9.TabIndex = 215
        Me._rtx_9.Text = "Ag"
        '
        '_Command1_6
        '
        Me._Command1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_6.Image = CType(resources.GetObject("_Command1_6.Image"), System.Drawing.Image)
        Me._Command1_6.Location = New System.Drawing.Point(344, 160)
        Me._Command1_6.Name = "_Command1_6"
        Me._Command1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_6.Size = New System.Drawing.Size(24, 24)
        Me._Command1_6.TabIndex = 167
        Me._Command1_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Text1_7
        '
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.AutoSize = False
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_7.Location = New System.Drawing.Point(216, 184)
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Name = "_Text1_7"
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.Size = New System.Drawing.Size(82, 24)
        Me._Text1_7.TabIndex = 176
        Me._Text1_7.Text = "Textg"
        '
        '_Text1_8
        '
        Me._Text1_8.AcceptsReturn = True
        Me._Text1_8.AutoSize = False
        Me._Text1_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_8.Location = New System.Drawing.Point(216, 208)
        Me._Text1_8.MaxLength = 0
        Me._Text1_8.Name = "_Text1_8"
        Me._Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_8.Size = New System.Drawing.Size(82, 24)
        Me._Text1_8.TabIndex = 175
        Me._Text1_8.Text = "Textg"
        '
        '_rtx_5
        '
        Me._rtx_5.Location = New System.Drawing.Point(184, 136)
        Me._rtx_5.Name = "_rtx_5"
        Me._rtx_5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_5.Size = New System.Drawing.Size(32, 24)
        Me._rtx_5.TabIndex = 211
        Me._rtx_5.Text = "Ag"
        '
        '_rtx_8
        '
        Me._rtx_8.Location = New System.Drawing.Point(184, 208)
        Me._rtx_8.Name = "_rtx_8"
        Me._rtx_8.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_8.Size = New System.Drawing.Size(32, 24)
        Me._rtx_8.TabIndex = 214
        Me._rtx_8.Text = "Ag"
        '
        '_Text1_11
        '
        Me._Text1_11.AcceptsReturn = True
        Me._Text1_11.AutoSize = False
        Me._Text1_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_11.Location = New System.Drawing.Point(216, 280)
        Me._Text1_11.MaxLength = 0
        Me._Text1_11.Name = "_Text1_11"
        Me._Text1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_11.Size = New System.Drawing.Size(82, 24)
        Me._Text1_11.TabIndex = 172
        Me._Text1_11.Text = "Textg"
        '
        '_rtx_6
        '
        Me._rtx_6.Location = New System.Drawing.Point(184, 160)
        Me._rtx_6.Name = "_rtx_6"
        Me._rtx_6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_6.Size = New System.Drawing.Size(32, 24)
        Me._rtx_6.TabIndex = 212
        Me._rtx_6.Text = "Ag"
        '
        '_rtx_3
        '
        Me._rtx_3.Location = New System.Drawing.Point(184, 88)
        Me._rtx_3.Name = "_rtx_3"
        Me._rtx_3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_3.Size = New System.Drawing.Size(32, 24)
        Me._rtx_3.TabIndex = 209
        Me._rtx_3.Text = "Ag"
        '
        '_Command1_3
        '
        Me._Command1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_3.Image = CType(resources.GetObject("_Command1_3.Image"), System.Drawing.Image)
        Me._Command1_3.Location = New System.Drawing.Point(344, 88)
        Me._Command1_3.Name = "_Command1_3"
        Me._Command1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_3.Size = New System.Drawing.Size(24, 24)
        Me._Command1_3.TabIndex = 170
        Me._Command1_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Command1_4
        '
        Me._Command1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_4.Image = CType(resources.GetObject("_Command1_4.Image"), System.Drawing.Image)
        Me._Command1_4.Location = New System.Drawing.Point(344, 112)
        Me._Command1_4.Name = "_Command1_4"
        Me._Command1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_4.Size = New System.Drawing.Size(24, 24)
        Me._Command1_4.TabIndex = 169
        Me._Command1_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Command1_5
        '
        Me._Command1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_5.Image = CType(resources.GetObject("_Command1_5.Image"), System.Drawing.Image)
        Me._Command1_5.Location = New System.Drawing.Point(344, 136)
        Me._Command1_5.Name = "_Command1_5"
        Me._Command1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_5.Size = New System.Drawing.Size(24, 24)
        Me._Command1_5.TabIndex = 168
        Me._Command1_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(8, 208)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(168, 24)
        Me._Label1_8.TabIndex = 186
        Me._Label1_8.Text = "Label1"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(8, 160)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(168, 24)
        Me._Label1_6.TabIndex = 188
        Me._Label1_6.Text = "Label1"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(8, 136)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(168, 24)
        Me._Label1_5.TabIndex = 189
        Me._Label1_5.Text = "Label1"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(8, 64)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(168, 24)
        Me._Label1_2.TabIndex = 190
        Me._Label1_2.Text = "Label1"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(8, 88)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(168, 19)
        Me._Label1_3.TabIndex = 191
        Me._Label1_3.Text = "Label1"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(8, 112)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(168, 24)
        Me._Label1_4.TabIndex = 192
        Me._Label1_4.Text = "Label1"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(8, 40)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(168, 24)
        Me._Label1_1.TabIndex = 193
        Me._Label1_1.Text = "Label1"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(8, 232)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(160, 19)
        Me._Label1_9.TabIndex = 185
        Me._Label1_9.Text = "Label1"
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(8, 280)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(168, 19)
        Me._Label1_11.TabIndex = 183
        Me._Label1_11.Text = "Label1"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(8, 184)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(168, 24)
        Me._Label1_7.TabIndex = 187
        Me._Label1_7.Text = "Label1"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(8, 16)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(82, 24)
        Me._Label1_0.TabIndex = 195
        Me._Label1_0.Text = "Load condition"
        '
        '_lblUni_2
        '
        Me._lblUni_2.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_2.Location = New System.Drawing.Point(304, 64)
        Me._lblUni_2.Name = "_lblUni_2"
        Me._lblUni_2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_2.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_2.TabIndex = 197
        Me._lblUni_2.Text = "Label2"
        Me._lblUni_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_3
        '
        Me._lblUni_3.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_3.Location = New System.Drawing.Point(304, 88)
        Me._lblUni_3.Name = "_lblUni_3"
        Me._lblUni_3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_3.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_3.TabIndex = 198
        Me._lblUni_3.Text = "Label2"
        Me._lblUni_3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_6
        '
        Me._lblUni_6.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_6.Location = New System.Drawing.Point(304, 160)
        Me._lblUni_6.Name = "_lblUni_6"
        Me._lblUni_6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_6.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_6.TabIndex = 201
        Me._lblUni_6.Text = "Label2"
        Me._lblUni_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_4
        '
        Me._lblUni_4.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_4.Location = New System.Drawing.Point(304, 112)
        Me._lblUni_4.Name = "_lblUni_4"
        Me._lblUni_4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_4.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_4.TabIndex = 199
        Me._lblUni_4.Text = "Label2"
        Me._lblUni_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_7
        '
        Me._lblUni_7.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_7.Location = New System.Drawing.Point(304, 184)
        Me._lblUni_7.Name = "_lblUni_7"
        Me._lblUni_7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_7.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_7.TabIndex = 202
        Me._lblUni_7.Text = "Label2"
        Me._lblUni_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_9
        '
        Me._lblUni_9.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_9.Location = New System.Drawing.Point(304, 232)
        Me._lblUni_9.Name = "_lblUni_9"
        Me._lblUni_9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._lblUni_9.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_9.TabIndex = 204
        Me._lblUni_9.Text = "Label2"
        Me._lblUni_9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAmm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(440, 336)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.TabStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmAmm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "WRCB - Materiali e ammissibili"
        Me.TabStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmAmm
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmAmm
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmAmm()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public OK As Boolean
    Private inizializzando As Boolean
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        OK = False
        Hide()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        OK = True
        Hide()
    End Sub
    Private Sub frmAmm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Text = Text & " " & Trim(Geom(iB).Mark)
    End Sub
    Private Sub TabStrip1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TabStrip1.Click
        iC = TabStrip1.SelectedIndex + 1
        AggiornaTesti()
    End Sub
    Private Sub Text1_TextChanged(ByVal Index As Short)
        If inizializzando Then Exit Sub
        If Not Text1(Index).Visible Then Exit Sub
        Select Case Index
            Case 0 : Geom(iB).Carichi(iC).CaseDescription = Text1(Index).Text
            Case 1 : Geom(iB).Carichi(iC).DesTemp = Converti(Val(Text1(Index).Text), 1)
            Case 2 : Geom(iB).ShellMat = Text1(Index).Text
            Case 4 : Geom(iB).NozzMat = Text1(Index).Text
            Case 3 : Geom(iB).Carichi(iC).AllowShe = Converti(Val(Text1(Index).Text), 2)
            Case 5 : Geom(iB).Carichi(iC).AllowNoz = Converti(Val(Text1(Index).Text), 2)
            Case 6 : Geom(iB).Carichi(iC).YieldNoz = Converti(Val(Text1(Index).Text), 2)
            Case 7 : Geom(iB).Carichi(iC).fYield = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 8 : Geom(iB).Carichi(iC).UTSNoz = Converti(Val(Text1(Index).Text), 2)
            Case 9 : Geom(iB).Carichi(iC).fUTS = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 10 : Geom(iB).Carichi(iC).AllowSheBr = Converti(Val(Text1(Index).Text), 2)
            Case 11 : Geom(iB).Carichi(iC).fBuc = GlobaLroutines.ValVir(Text1(Index).Text)
        End Select
    End Sub
    Friend ReadOnly Property Text1(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 0 : Return _Text1_0
                Case 1 : Return _Text1_1
                Case 2 : Return _Text1_2
                Case 3 : Return _Text1_3
                Case 4 : Return _Text1_4
                Case 5 : Return _Text1_5
                Case 6 : Return _Text1_6
                Case 7 : Return _Text1_7
                Case 8 : Return _Text1_8
                Case 9 : Return _Text1_9
                Case 10 : Return _Text1_10
                Case 11 : Return _Text1_11
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property Label1(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _Label1_0
                Case 1 : Return _Label1_1
                Case 2 : Return _Label1_2
                Case 3 : Return _Label1_3
                Case 4 : Return _Label1_4
                Case 5 : Return _Label1_5
                Case 6 : Return _Label1_6
                Case 7 : Return _Label1_7
                Case 8 : Return _Label1_8
                Case 9 : Return _Label1_9
                Case 10 : Return _Label1_10
                Case 11 : Return _Label1_11
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property lblUni(ByVal i As Short) As Label
        Get
            Select Case i
                Case 1 : Return _lblUni_1
                Case 2 : Return _lblUni_2
                Case 3 : Return _lblUni_3
                Case 4 : Return _lblUni_4
                Case 5 : Return _lblUni_5
                Case 6 : Return _lblUni_6
                Case 7 : Return _lblUni_7
                Case 8 : Return _lblUni_8
                Case 9 : Return _lblUni_9
                Case 10 : Return _lblUni_10
                Case 11 : Return _lblUni_11
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property Command1(ByVal i As Short) As Button
        Get
            Select Case i
                Case 2 : Return _Command1_2
                Case 3 : Return _Command1_3
                Case 4 : Return _Command1_4
                Case 5 : Return _Command1_5
                Case 6 : Return _Command1_6
                Case 8 : Return _Command1_8
                Case 10 : Return _Command1_10
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Command1_Click(ByVal Index As Short)
        Dim Classe As Short
        Select Case Index
            Case 2 'shell mate
                If Not Matdim(2 * iB - 1) Is Nothing Then
                    Classe = Matdim(2 * iB - 1).Classe
                Else
                    Matdim(2 * iB - 1) = New LibMat.MaterialeNew1
                End If
                If Classe = 0 Then Classe = 1
                Matdim(2 * iB - 1).Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                Text1(2).Text = Matdim(2 * iB - 1).MatStr
                Text1(5).Text = CStr(0)
                Text1(8).Text = CStr(0)
                Text1(7).Text = CStr(0)
                Text1(9).Text = CStr(0)
            Case 4 'nozzle mate
                If Not Matdim(2 * iB) Is Nothing Then
                    Classe = Matdim(2 * iB).Classe
                Else
                    Matdim(2 * iB) = New LibMat.MaterialeNew1
                End If
                If Classe = 0 Then Classe = 7
                Matdim(2 * iB).Scelta(Classe, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                Text1(4).Text = Matdim(2 * iB).MatStr
            Case 3 'shell allow
                indice = 2 * iB - 1
                TensAmm(3)
                'Geom(iB).Carichi(iC).AllowShe = GlobaLroutines.ValVir(Risult$(Compr(nRiga)))
            Case 5 ' Nozzle Allow      'asme
                indice = 2 * iB
                TensAmm(5)
                'Geom(iB).Carichi(iC).AllowNoz = GlobaLroutines.ValVir(Risult$(Compr(nRiga)))
            Case 6 'Yield
                CalcYield()
                'Risult$(Compr(nRiga)) = myStr(Geom(iB).Carichi(iC).YieldNoz, 6, 2, False)
            Case 8 'UTS
                CalcUTS()
                'Risult$(Compr(nRiga)) = myStr(Geom(iB).Carichi(iC).UTSNoz, 6, 2, False)
            Case 10 'f
                If Geom(iB).Carichi(iC).YieldNoz > 0 And Geom(iB).Carichi(iC).UTSNoz > 0 And Geom(iB).Carichi(1).fYield > 0 And Geom(iB).Carichi(1).fUTS > 0 Then
                    CalcfBS()
                    Text1(10).Text = globalRoutines.myStr(Geom(iB).Carichi(iC).AllowSheBr, 6, 2, False)
                End If 'm
        End Select
    End Sub
    Public Sub AggiornaTesti()
        Dim i As Short
        Dim Log1 As Boolean
        Text1(0).Text = Trim(Geom(iB).Carichi(iC).CaseDescription)
        Text1(1).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).DesTemp, 1), 5, 2, False)
        Text1(2).Text = globalRoutines.Adjust(Geom(iB).ShellMat, 20)
        Text1(3).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).AllowShe, 2), 6, 2, False)
        Text1(4).Text = globalRoutines.Adjust(Geom(iB).NozzMat, 20)
        Text1(5).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).AllowNoz, 2), 6, 2, False)
        Text1(6).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).YieldNoz, 2), 6, 2, False)
        Text1(7).Text = globalRoutines.myStr(Geom(iB).Carichi(iC).fYield, 1, 3, False)
        Text1(8).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).UTSNoz, 2), 6, 2, False)
        Text1(9).Text = globalRoutines.myStr(Geom(iB).Carichi(iC).fUTS, 1, 3, False)
        Text1(10).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).AllowSheBr, 2), 6, 2, False)
        Text1(11).Text = globalRoutines.myStr(Geom(iB).Carichi(iC).fBuc, 1, 3, False)
        If DatProg.CodiceM > 2 Then 'non asme
            Text1(5).Text = ""
        End If 'z
        If Config.Analisi = 2 Then
            Text1(2).Text = "" 'Chr$(45)
            Text1(3).Text = "" 'Chr$(45)
        End If 'x
        If Config.WRC297 < 3 Then
            For i = 6 To 11 : Text1(i).Text = "" : Next
        End If 'c
        If Config.WRC297 > 2 And Config.Ammiss = 0 Then
            For i = 7 To 10 : Text1(i).Text = "" : Next
        End If
        Log1 = Geom(iB).ShellType = 0 And Config.WRC297 = 2 'siamo su cilindro con regola 297
        If Config.Analisi = 0 And Not Log1 Then 'Shell only
            Text1(4).Text = ""
            Text1(5).Text = ""
        End If 'v
        If iC > 1 Then
            Text1(7).Text = ""
            Text1(9).Text = ""
            Text1(11).Text = ""
        End If 'b
        For i = 1 To 11
            If Text1(i).Text = "" Then
                Label1(i).Visible = False : Text1(i).Visible = False
                lblUni(i).Visible = False : rtx(i).Visible = False
                On Error Resume Next
                Command1(i).Visible = False
            Else
                Label1(i).Visible = True
                Text1(i).Visible = True
                'lblUni(i).Visible = True
                'rtx(i).Visible = True
                On Error Resume Next
                Command1(i).Visible = True
            End If
        Next
        For i = 2 To 4 Step 2
            Command1(i).Enabled = iC = 1
            Label1(i).Enabled = iC = 1 : Command1(i).Enabled = iC = 1
            Text1(i).Enabled = iC = 1
        Next
    End Sub
    Public Sub AggiornaLbl()
        Label1(1).Text = "Design Temperature       "
        lblUni(1).Text = Config.Unit(0)
        rtx(1).Rtf = "{\rtf {\fs16  T}}" '"{\rtf {\fs16  r\sub i}}"
        Label1(2).Text = "Shell Material           "
        lblUni(2).Visible = False
        rtx(2).Visible = False
        Label1(3).Text = "Shell Design Stress      "
        lblUni(3).Text = Config.Unit(5)
        rtx(3).Rtf = "{\rtf {\fs16  S\sub m}}"
        Label1(4).Text = "Nozzle Material          "
        lblUni(4).Visible = False
        rtx(4).Visible = False
        Label1(5).Text = "Nozzle Design Stress     "
        lblUni(5).Text = Config.Unit(5)
        rtx(5).Rtf = "{\rtf {\fs16  S\sub m}}"
        Label1(6).Text = "Yield stress  @Temp.(sh.)"
        lblUni(6).Text = Config.Unit(5)
        rtx(6).Rtf = "{\rtf {\fs16  Y}}"
        Label1(7).Text = "Safety factor ag. Y @T.  "
        lblUni(7).Visible = False
        rtx(7).Visible = False
        Label1(8).Text = "UTS @ room    (shell)    "
        lblUni(8).Text = Config.Unit(5)
        rtx(8).Rtf = "{\rtf {\fs16 UTS}}"
        Label1(9).Text = "Safety factor ag. UTS@r. "
        lblUni(9).Visible = False
        rtx(9).Visible = False
        Label1(10).Text = "Shell  Design Stress     "
        lblUni(10).Text = Config.Unit(5)
        rtx(10).Rtf = "{\rtf {\fs16  f}}"
        Label1(11).Text = "Safety factor ag.Buckling"
        lblUni(11).Visible = False
        rtx(11).Visible = False
    End Sub
    Private ReadOnly Property rtx(ByVal i As Integer) As RichTextBox
        Get
            Select Case i
                Case 1 : Return _rtx_1
                Case 2 : Return _rtx_2
                Case 3 : Return _rtx_3
                Case 4 : Return _rtx_4
                Case 5 : Return _rtx_5
                Case 6 : Return _rtx_6
                Case 7 : Return _rtx_7
                Case 8 : Return _rtx_8
                Case 9 : Return _rtx_9
                Case 10 : Return _rtx_10
                Case 11 : Return _rtx_11
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _Text1_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_0.TextChanged
        Text1_TextChanged(0)
    End Sub

    Private Sub _Text1_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_1.TextChanged
        Text1_TextChanged(1)
    End Sub

    Private Sub _Text1_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_10.TextChanged
        Text1_TextChanged(10)
    End Sub

    Private Sub _Text1_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_11.TextChanged
        Text1_TextChanged(11)
    End Sub

    Private Sub _Text1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_2.TextChanged
        Text1_TextChanged(2)
    End Sub

    Private Sub _Text1_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_3.TextChanged
        Text1_TextChanged(3)
    End Sub

    Private Sub _Text1_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_4.TextChanged
        Text1_TextChanged(4)
    End Sub

    Private Sub _Text1_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_5.TextChanged
        Text1_TextChanged(5)
    End Sub

    Private Sub _Text1_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_6.TextChanged
        Text1_TextChanged(6)
    End Sub

    Private Sub _Text1_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_7.TextChanged
        Text1_TextChanged(7)
    End Sub

    Private Sub _Text1_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_8.TextChanged
        Text1_TextChanged(8)
    End Sub

    Private Sub _Text1_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_9.TextChanged
        Text1_TextChanged(9)
    End Sub

    Private Sub _Command1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_2.Click
        Command1_Click(2)
    End Sub

    Private Sub _Command1_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_3.Click
        Command1_Click(3)
    End Sub

    Private Sub _Command1_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_4.Click
        Command1_Click(4)
    End Sub

    Private Sub _Command1_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_5.Click
        Command1_Click(5)
    End Sub

    Private Sub _Command1_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_6.Click
        Command1_Click(6)
    End Sub

    Private Sub _Command1_8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_8.Click
        Command1_Click(8)
    End Sub

    Private Sub _Command1_10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_10.Click
        Command1_Click(10)
    End Sub
End Class