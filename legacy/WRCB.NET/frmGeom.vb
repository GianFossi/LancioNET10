Option Strict Off
Option Explicit On
Friend Class frmGeom
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
	Public WithEvents _Text1_20 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _Text1_24 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_23 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_22 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_21 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_19 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_18 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_17 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_16 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_15 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_14 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_13 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_12 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_11 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_10 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_9 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_8 As System.Windows.Forms.TextBox
	Public WithEvents _Combo1_7 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_6 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_5 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_4 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_3 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_2 As System.Windows.Forms.ComboBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblUni_20 As System.Windows.Forms.Label
	Public WithEvents _Label1_20 As System.Windows.Forms.Label
	Public WithEvents _Label1_25 As System.Windows.Forms.Label
	Public WithEvents _lblUni_0 As System.Windows.Forms.Label
	Public WithEvents _lblUni_24 As System.Windows.Forms.Label
	Public WithEvents _lblUni_23 As System.Windows.Forms.Label
	Public WithEvents _lblUni_22 As System.Windows.Forms.Label
	Public WithEvents _lblUni_21 As System.Windows.Forms.Label
	Public WithEvents _lblUni_19 As System.Windows.Forms.Label
	Public WithEvents _lblUni_18 As System.Windows.Forms.Label
	Public WithEvents _lblUni_17 As System.Windows.Forms.Label
	Public WithEvents _lblUni_16 As System.Windows.Forms.Label
	Public WithEvents _lblUni_15 As System.Windows.Forms.Label
	Public WithEvents _lblUni_14 As System.Windows.Forms.Label
	Public WithEvents _lblUni_13 As System.Windows.Forms.Label
	Public WithEvents _lblUni_12 As System.Windows.Forms.Label
	Public WithEvents _lblUni_11 As System.Windows.Forms.Label
	Public WithEvents _lblUni_10 As System.Windows.Forms.Label
	Public WithEvents _lblUni_9 As System.Windows.Forms.Label
	Public WithEvents _lblUni_8 As System.Windows.Forms.Label
	Public WithEvents _Label1_24 As System.Windows.Forms.Label
	Public WithEvents _Label1_23 As System.Windows.Forms.Label
	Public WithEvents _Label1_22 As System.Windows.Forms.Label
	Public WithEvents _Label1_21 As System.Windows.Forms.Label
	Public WithEvents _Label1_19 As System.Windows.Forms.Label
	Public WithEvents _Label1_18 As System.Windows.Forms.Label
	Public WithEvents _Label1_17 As System.Windows.Forms.Label
	Public WithEvents _Label1_16 As System.Windows.Forms.Label
	Public WithEvents _Label1_15 As System.Windows.Forms.Label
	Public WithEvents _Label1_14 As System.Windows.Forms.Label
	Public WithEvents _Label1_13 As System.Windows.Forms.Label
	Public WithEvents _Label1_12 As System.Windows.Forms.Label
	Public WithEvents _Label1_11 As System.Windows.Forms.Label
	Public WithEvents _Label1_10 As System.Windows.Forms.Label
	Public WithEvents _Label1_9 As System.Windows.Forms.Label
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents _Label1_7 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents _rtx_8 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_9 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_10 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_11 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_12 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_13 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_14 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_15 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_16 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_17 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_18 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_19 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_0 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_20 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_21 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_22 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_23 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_24 As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Text1_20 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._Text1_24 = New System.Windows.Forms.TextBox
        Me._Text1_23 = New System.Windows.Forms.TextBox
        Me._Text1_22 = New System.Windows.Forms.TextBox
        Me._Text1_21 = New System.Windows.Forms.TextBox
        Me._Text1_19 = New System.Windows.Forms.TextBox
        Me._Text1_18 = New System.Windows.Forms.TextBox
        Me._Text1_17 = New System.Windows.Forms.TextBox
        Me._Text1_16 = New System.Windows.Forms.TextBox
        Me._Text1_15 = New System.Windows.Forms.TextBox
        Me._Text1_14 = New System.Windows.Forms.TextBox
        Me._Text1_13 = New System.Windows.Forms.TextBox
        Me._Text1_12 = New System.Windows.Forms.TextBox
        Me._Text1_11 = New System.Windows.Forms.TextBox
        Me._Text1_10 = New System.Windows.Forms.TextBox
        Me._Text1_9 = New System.Windows.Forms.TextBox
        Me._Text1_8 = New System.Windows.Forms.TextBox
        Me._Combo1_7 = New System.Windows.Forms.ComboBox
        Me._Combo1_6 = New System.Windows.Forms.ComboBox
        Me._Combo1_5 = New System.Windows.Forms.ComboBox
        Me._Combo1_4 = New System.Windows.Forms.ComboBox
        Me._Combo1_3 = New System.Windows.Forms.ComboBox
        Me._Combo1_2 = New System.Windows.Forms.ComboBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._lblUni_20 = New System.Windows.Forms.Label
        Me._Label1_20 = New System.Windows.Forms.Label
        Me._Label1_25 = New System.Windows.Forms.Label
        Me._lblUni_0 = New System.Windows.Forms.Label
        Me._lblUni_24 = New System.Windows.Forms.Label
        Me._lblUni_23 = New System.Windows.Forms.Label
        Me._lblUni_22 = New System.Windows.Forms.Label
        Me._lblUni_21 = New System.Windows.Forms.Label
        Me._lblUni_19 = New System.Windows.Forms.Label
        Me._lblUni_18 = New System.Windows.Forms.Label
        Me._lblUni_17 = New System.Windows.Forms.Label
        Me._lblUni_16 = New System.Windows.Forms.Label
        Me._lblUni_15 = New System.Windows.Forms.Label
        Me._lblUni_14 = New System.Windows.Forms.Label
        Me._lblUni_13 = New System.Windows.Forms.Label
        Me._lblUni_12 = New System.Windows.Forms.Label
        Me._lblUni_11 = New System.Windows.Forms.Label
        Me._lblUni_10 = New System.Windows.Forms.Label
        Me._lblUni_9 = New System.Windows.Forms.Label
        Me._lblUni_8 = New System.Windows.Forms.Label
        Me._Label1_24 = New System.Windows.Forms.Label
        Me._Label1_23 = New System.Windows.Forms.Label
        Me._Label1_22 = New System.Windows.Forms.Label
        Me._Label1_21 = New System.Windows.Forms.Label
        Me._Label1_19 = New System.Windows.Forms.Label
        Me._Label1_18 = New System.Windows.Forms.Label
        Me._Label1_17 = New System.Windows.Forms.Label
        Me._Label1_16 = New System.Windows.Forms.Label
        Me._Label1_15 = New System.Windows.Forms.Label
        Me._Label1_14 = New System.Windows.Forms.Label
        Me._Label1_13 = New System.Windows.Forms.Label
        Me._Label1_12 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._rtx_8 = New System.Windows.Forms.RichTextBox
        Me._rtx_9 = New System.Windows.Forms.RichTextBox
        Me._rtx_10 = New System.Windows.Forms.RichTextBox
        Me._rtx_11 = New System.Windows.Forms.RichTextBox
        Me._rtx_12 = New System.Windows.Forms.RichTextBox
        Me._rtx_13 = New System.Windows.Forms.RichTextBox
        Me._rtx_14 = New System.Windows.Forms.RichTextBox
        Me._rtx_15 = New System.Windows.Forms.RichTextBox
        Me._rtx_16 = New System.Windows.Forms.RichTextBox
        Me._rtx_17 = New System.Windows.Forms.RichTextBox
        Me._rtx_18 = New System.Windows.Forms.RichTextBox
        Me._rtx_19 = New System.Windows.Forms.RichTextBox
        Me._rtx_0 = New System.Windows.Forms.RichTextBox
        Me._rtx_20 = New System.Windows.Forms.RichTextBox
        Me._rtx_21 = New System.Windows.Forms.RichTextBox
        Me._rtx_22 = New System.Windows.Forms.RichTextBox
        Me._rtx_23 = New System.Windows.Forms.RichTextBox
        Me._rtx_24 = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        '_Text1_20
        '
        Me._Text1_20.AcceptsReturn = True
        Me._Text1_20.AutoSize = False
        Me._Text1_20.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_20.Location = New System.Drawing.Point(232, 504)
        Me._Text1_20.MaxLength = 0
        Me._Text1_20.Name = "_Text1_20"
        Me._Text1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_20.Size = New System.Drawing.Size(55, 24)
        Me._Text1_20.TabIndex = 45
        Me._Text1_20.Text = "Text1"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(232, 480)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(55, 24)
        Me._Text1_2.TabIndex = 86
        Me._Text1_2.Text = "Text1"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(288, 16)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(50, 24)
        Me.Command2.TabIndex = 51
        Me.Command2.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(288, 48)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(50, 24)
        Me.Command1.TabIndex = 50
        Me.Command1.Text = "OK"
        '
        '_Text1_24
        '
        Me._Text1_24.AcceptsReturn = True
        Me._Text1_24.AutoSize = False
        Me._Text1_24.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_24.Location = New System.Drawing.Point(232, 600)
        Me._Text1_24.MaxLength = 0
        Me._Text1_24.Name = "_Text1_24"
        Me._Text1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_24.Size = New System.Drawing.Size(55, 24)
        Me._Text1_24.TabIndex = 49
        Me._Text1_24.Text = "Text1"
        '
        '_Text1_23
        '
        Me._Text1_23.AcceptsReturn = True
        Me._Text1_23.AutoSize = False
        Me._Text1_23.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_23.Location = New System.Drawing.Point(232, 576)
        Me._Text1_23.MaxLength = 0
        Me._Text1_23.Name = "_Text1_23"
        Me._Text1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_23.Size = New System.Drawing.Size(55, 24)
        Me._Text1_23.TabIndex = 48
        Me._Text1_23.Text = "Text1"
        '
        '_Text1_22
        '
        Me._Text1_22.AcceptsReturn = True
        Me._Text1_22.AutoSize = False
        Me._Text1_22.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_22.Location = New System.Drawing.Point(232, 552)
        Me._Text1_22.MaxLength = 0
        Me._Text1_22.Name = "_Text1_22"
        Me._Text1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_22.Size = New System.Drawing.Size(55, 24)
        Me._Text1_22.TabIndex = 47
        Me._Text1_22.Text = "Text1"
        '
        '_Text1_21
        '
        Me._Text1_21.AcceptsReturn = True
        Me._Text1_21.AutoSize = False
        Me._Text1_21.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_21.Location = New System.Drawing.Point(232, 528)
        Me._Text1_21.MaxLength = 0
        Me._Text1_21.Name = "_Text1_21"
        Me._Text1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_21.Size = New System.Drawing.Size(55, 24)
        Me._Text1_21.TabIndex = 46
        Me._Text1_21.Text = "Text1"
        '
        '_Text1_19
        '
        Me._Text1_19.AcceptsReturn = True
        Me._Text1_19.AutoSize = False
        Me._Text1_19.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_19.Location = New System.Drawing.Point(232, 456)
        Me._Text1_19.MaxLength = 0
        Me._Text1_19.Name = "_Text1_19"
        Me._Text1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_19.Size = New System.Drawing.Size(55, 24)
        Me._Text1_19.TabIndex = 44
        Me._Text1_19.Text = "Text1"
        '
        '_Text1_18
        '
        Me._Text1_18.AcceptsReturn = True
        Me._Text1_18.AutoSize = False
        Me._Text1_18.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_18.Location = New System.Drawing.Point(232, 432)
        Me._Text1_18.MaxLength = 0
        Me._Text1_18.Name = "_Text1_18"
        Me._Text1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_18.Size = New System.Drawing.Size(55, 24)
        Me._Text1_18.TabIndex = 43
        Me._Text1_18.Text = "Text1"
        '
        '_Text1_17
        '
        Me._Text1_17.AcceptsReturn = True
        Me._Text1_17.AutoSize = False
        Me._Text1_17.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_17.Location = New System.Drawing.Point(232, 408)
        Me._Text1_17.MaxLength = 0
        Me._Text1_17.Name = "_Text1_17"
        Me._Text1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_17.Size = New System.Drawing.Size(55, 24)
        Me._Text1_17.TabIndex = 42
        Me._Text1_17.Text = "Text1"
        '
        '_Text1_16
        '
        Me._Text1_16.AcceptsReturn = True
        Me._Text1_16.AutoSize = False
        Me._Text1_16.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_16.Location = New System.Drawing.Point(232, 384)
        Me._Text1_16.MaxLength = 0
        Me._Text1_16.Name = "_Text1_16"
        Me._Text1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_16.Size = New System.Drawing.Size(55, 24)
        Me._Text1_16.TabIndex = 41
        Me._Text1_16.Text = "Text1"
        '
        '_Text1_15
        '
        Me._Text1_15.AcceptsReturn = True
        Me._Text1_15.AutoSize = False
        Me._Text1_15.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_15.Location = New System.Drawing.Point(232, 360)
        Me._Text1_15.MaxLength = 0
        Me._Text1_15.Name = "_Text1_15"
        Me._Text1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_15.Size = New System.Drawing.Size(55, 24)
        Me._Text1_15.TabIndex = 40
        Me._Text1_15.Text = "Text1"
        '
        '_Text1_14
        '
        Me._Text1_14.AcceptsReturn = True
        Me._Text1_14.AutoSize = False
        Me._Text1_14.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_14.Location = New System.Drawing.Point(232, 336)
        Me._Text1_14.MaxLength = 0
        Me._Text1_14.Name = "_Text1_14"
        Me._Text1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_14.Size = New System.Drawing.Size(55, 24)
        Me._Text1_14.TabIndex = 39
        Me._Text1_14.Text = "Text1"
        '
        '_Text1_13
        '
        Me._Text1_13.AcceptsReturn = True
        Me._Text1_13.AutoSize = False
        Me._Text1_13.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_13.Location = New System.Drawing.Point(232, 312)
        Me._Text1_13.MaxLength = 0
        Me._Text1_13.Name = "_Text1_13"
        Me._Text1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_13.Size = New System.Drawing.Size(55, 24)
        Me._Text1_13.TabIndex = 38
        Me._Text1_13.Text = "Text1"
        '
        '_Text1_12
        '
        Me._Text1_12.AcceptsReturn = True
        Me._Text1_12.AutoSize = False
        Me._Text1_12.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_12.Location = New System.Drawing.Point(232, 288)
        Me._Text1_12.MaxLength = 0
        Me._Text1_12.Name = "_Text1_12"
        Me._Text1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_12.Size = New System.Drawing.Size(55, 24)
        Me._Text1_12.TabIndex = 37
        Me._Text1_12.Text = "Text1"
        '
        '_Text1_11
        '
        Me._Text1_11.AcceptsReturn = True
        Me._Text1_11.AutoSize = False
        Me._Text1_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_11.Location = New System.Drawing.Point(232, 264)
        Me._Text1_11.MaxLength = 0
        Me._Text1_11.Name = "_Text1_11"
        Me._Text1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_11.Size = New System.Drawing.Size(55, 24)
        Me._Text1_11.TabIndex = 36
        Me._Text1_11.Text = "Text1"
        '
        '_Text1_10
        '
        Me._Text1_10.AcceptsReturn = True
        Me._Text1_10.AutoSize = False
        Me._Text1_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_10.Location = New System.Drawing.Point(232, 240)
        Me._Text1_10.MaxLength = 0
        Me._Text1_10.Name = "_Text1_10"
        Me._Text1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_10.Size = New System.Drawing.Size(55, 24)
        Me._Text1_10.TabIndex = 35
        Me._Text1_10.Text = "Text1"
        '
        '_Text1_9
        '
        Me._Text1_9.AcceptsReturn = True
        Me._Text1_9.AutoSize = False
        Me._Text1_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_9.Location = New System.Drawing.Point(232, 216)
        Me._Text1_9.MaxLength = 0
        Me._Text1_9.Name = "_Text1_9"
        Me._Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_9.Size = New System.Drawing.Size(55, 24)
        Me._Text1_9.TabIndex = 34
        Me._Text1_9.Text = "Text1"
        '
        '_Text1_8
        '
        Me._Text1_8.AcceptsReturn = True
        Me._Text1_8.AutoSize = False
        Me._Text1_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_8.Location = New System.Drawing.Point(232, 192)
        Me._Text1_8.MaxLength = 0
        Me._Text1_8.Name = "_Text1_8"
        Me._Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_8.Size = New System.Drawing.Size(55, 24)
        Me._Text1_8.TabIndex = 33
        Me._Text1_8.Text = "Text1"
        '
        '_Combo1_7
        '
        Me._Combo1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_7.Location = New System.Drawing.Point(128, 168)
        Me._Combo1_7.Name = "_Combo1_7"
        Me._Combo1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_7.Size = New System.Drawing.Size(55, 21)
        Me._Combo1_7.TabIndex = 32
        '
        '_Combo1_6
        '
        Me._Combo1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_6.Location = New System.Drawing.Point(128, 144)
        Me._Combo1_6.Name = "_Combo1_6"
        Me._Combo1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_6.Size = New System.Drawing.Size(145, 21)
        Me._Combo1_6.TabIndex = 31
        '
        '_Combo1_5
        '
        Me._Combo1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_5.Location = New System.Drawing.Point(128, 120)
        Me._Combo1_5.Name = "_Combo1_5"
        Me._Combo1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_5.Size = New System.Drawing.Size(145, 21)
        Me._Combo1_5.TabIndex = 30
        '
        '_Combo1_4
        '
        Me._Combo1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_4.Location = New System.Drawing.Point(128, 96)
        Me._Combo1_4.Name = "_Combo1_4"
        Me._Combo1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_4.Size = New System.Drawing.Size(145, 21)
        Me._Combo1_4.TabIndex = 29
        '
        '_Combo1_3
        '
        Me._Combo1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_3.Location = New System.Drawing.Point(128, 72)
        Me._Combo1_3.Name = "_Combo1_3"
        Me._Combo1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_3.Size = New System.Drawing.Size(55, 21)
        Me._Combo1_3.TabIndex = 28
        '
        '_Combo1_2
        '
        Me._Combo1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_2.Location = New System.Drawing.Point(128, 48)
        Me._Combo1_2.Name = "_Combo1_2"
        Me._Combo1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_2.Size = New System.Drawing.Size(55, 21)
        Me._Combo1_2.TabIndex = 27
        Me._Combo1_2.Text = "Combo1"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(128, 24)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(145, 24)
        Me._Text1_1.TabIndex = 26
        Me._Text1_1.Text = "Text1"
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(128, 0)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(145, 24)
        Me._Text1_0.TabIndex = 25
        Me._Text1_0.Text = "Text1"
        '
        '_lblUni_20
        '
        Me._lblUni_20.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_20.Location = New System.Drawing.Point(296, 504)
        Me._lblUni_20.Name = "_lblUni_20"
        Me._lblUni_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_20.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_20.TabIndex = 64
        Me._lblUni_20.Text = "Label2"
        Me._lblUni_20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Label1_20
        '
        Me._Label1_20.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_20.Location = New System.Drawing.Point(0, 504)
        Me._Label1_20.Name = "_Label1_20"
        Me._Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_20.Size = New System.Drawing.Size(200, 24)
        Me._Label1_20.TabIndex = 20
        Me._Label1_20.Text = "Pad diameter"
        '
        '_Label1_25
        '
        Me._Label1_25.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_25.Location = New System.Drawing.Point(0, 480)
        Me._Label1_25.Name = "_Label1_25"
        Me._Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_25.Size = New System.Drawing.Size(200, 24)
        Me._Label1_25.TabIndex = 89
        Me._Label1_25.Text = "Corrosion allow., nozzle (or clad)"
        '
        '_lblUni_0
        '
        Me._lblUni_0.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_0.Location = New System.Drawing.Point(296, 480)
        Me._lblUni_0.Name = "_lblUni_0"
        Me._lblUni_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_0.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_0.TabIndex = 88
        Me._lblUni_0.Text = "Label2"
        Me._lblUni_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_24
        '
        Me._lblUni_24.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_24.Location = New System.Drawing.Point(296, 600)
        Me._lblUni_24.Name = "_lblUni_24"
        Me._lblUni_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_24.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_24.TabIndex = 68
        Me._lblUni_24.Text = "Label2"
        Me._lblUni_24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblUni_24.Visible = False
        '
        '_lblUni_23
        '
        Me._lblUni_23.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_23.Location = New System.Drawing.Point(296, 576)
        Me._lblUni_23.Name = "_lblUni_23"
        Me._lblUni_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_23.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_23.TabIndex = 67
        Me._lblUni_23.Text = "Label2"
        Me._lblUni_23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_22
        '
        Me._lblUni_22.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_22.Location = New System.Drawing.Point(296, 552)
        Me._lblUni_22.Name = "_lblUni_22"
        Me._lblUni_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_22.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_22.TabIndex = 66
        Me._lblUni_22.Text = "Label2"
        Me._lblUni_22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_21
        '
        Me._lblUni_21.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_21.Location = New System.Drawing.Point(296, 528)
        Me._lblUni_21.Name = "_lblUni_21"
        Me._lblUni_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_21.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_21.TabIndex = 65
        Me._lblUni_21.Text = "Label2"
        Me._lblUni_21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_19
        '
        Me._lblUni_19.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_19.Location = New System.Drawing.Point(296, 456)
        Me._lblUni_19.Name = "_lblUni_19"
        Me._lblUni_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_19.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_19.TabIndex = 63
        Me._lblUni_19.Text = "Label2"
        Me._lblUni_19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_18
        '
        Me._lblUni_18.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_18.Location = New System.Drawing.Point(296, 432)
        Me._lblUni_18.Name = "_lblUni_18"
        Me._lblUni_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_18.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_18.TabIndex = 62
        Me._lblUni_18.Text = "Label2"
        Me._lblUni_18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_17
        '
        Me._lblUni_17.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_17.Location = New System.Drawing.Point(296, 408)
        Me._lblUni_17.Name = "_lblUni_17"
        Me._lblUni_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_17.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_17.TabIndex = 61
        Me._lblUni_17.Text = "Label2"
        Me._lblUni_17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_16
        '
        Me._lblUni_16.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_16.Location = New System.Drawing.Point(296, 384)
        Me._lblUni_16.Name = "_lblUni_16"
        Me._lblUni_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_16.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_16.TabIndex = 60
        Me._lblUni_16.Text = "Label2"
        Me._lblUni_16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_15
        '
        Me._lblUni_15.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_15.Location = New System.Drawing.Point(296, 360)
        Me._lblUni_15.Name = "_lblUni_15"
        Me._lblUni_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_15.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_15.TabIndex = 59
        Me._lblUni_15.Text = "Label2"
        Me._lblUni_15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_14
        '
        Me._lblUni_14.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_14.Location = New System.Drawing.Point(296, 336)
        Me._lblUni_14.Name = "_lblUni_14"
        Me._lblUni_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_14.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_14.TabIndex = 58
        Me._lblUni_14.Text = "Label2"
        Me._lblUni_14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_13
        '
        Me._lblUni_13.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_13.Location = New System.Drawing.Point(296, 312)
        Me._lblUni_13.Name = "_lblUni_13"
        Me._lblUni_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_13.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_13.TabIndex = 57
        Me._lblUni_13.Text = "Label2"
        Me._lblUni_13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_12
        '
        Me._lblUni_12.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_12.Location = New System.Drawing.Point(296, 288)
        Me._lblUni_12.Name = "_lblUni_12"
        Me._lblUni_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_12.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_12.TabIndex = 56
        Me._lblUni_12.Text = "Label2"
        Me._lblUni_12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_11
        '
        Me._lblUni_11.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_11.Location = New System.Drawing.Point(296, 264)
        Me._lblUni_11.Name = "_lblUni_11"
        Me._lblUni_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_11.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_11.TabIndex = 55
        Me._lblUni_11.Text = "Label2"
        Me._lblUni_11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_10
        '
        Me._lblUni_10.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_10.Location = New System.Drawing.Point(296, 240)
        Me._lblUni_10.Name = "_lblUni_10"
        Me._lblUni_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_10.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_10.TabIndex = 54
        Me._lblUni_10.Text = "Label2"
        Me._lblUni_10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_9
        '
        Me._lblUni_9.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_9.Location = New System.Drawing.Point(296, 216)
        Me._lblUni_9.Name = "_lblUni_9"
        Me._lblUni_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_9.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_9.TabIndex = 53
        Me._lblUni_9.Text = "Label2"
        Me._lblUni_9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_8
        '
        Me._lblUni_8.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_8.Location = New System.Drawing.Point(296, 192)
        Me._lblUni_8.Name = "_lblUni_8"
        Me._lblUni_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_8.Size = New System.Drawing.Size(40, 24)
        Me._lblUni_8.TabIndex = 52
        Me._lblUni_8.Text = "Label2"
        Me._lblUni_8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Label1_24
        '
        Me._Label1_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_24.Location = New System.Drawing.Point(0, 600)
        Me._Label1_24.Name = "_Label1_24"
        Me._Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_24.Size = New System.Drawing.Size(136, 24)
        Me._Label1_24.TabIndex = 24
        Me._Label1_24.Text = "Number of load cases"
        '
        '_Label1_23
        '
        Me._Label1_23.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_23.Location = New System.Drawing.Point(0, 576)
        Me._Label1_23.Name = "_Label1_23"
        Me._Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_23.Size = New System.Drawing.Size(190, 24)
        Me._Label1_23.TabIndex = 23
        Me._Label1_23.Text = "Nozzle offset / mid-plane"
        '
        '_Label1_22
        '
        Me._Label1_22.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_22.Location = New System.Drawing.Point(0, 552)
        Me._Label1_22.Name = "_Label1_22"
        Me._Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_22.Size = New System.Drawing.Size(200, 24)
        Me._Label1_22.TabIndex = 22
        Me._Label1_22.Text = "Cylinder length"
        '
        '_Label1_21
        '
        Me._Label1_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_21.Location = New System.Drawing.Point(0, 528)
        Me._Label1_21.Name = "_Label1_21"
        Me._Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_21.Size = New System.Drawing.Size(200, 24)
        Me._Label1_21.TabIndex = 21
        Me._Label1_21.Text = "Longitudinal pad dimension"
        '
        '_Label1_19
        '
        Me._Label1_19.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_19.Location = New System.Drawing.Point(0, 456)
        Me._Label1_19.Name = "_Label1_19"
        Me._Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_19.Size = New System.Drawing.Size(200, 24)
        Me._Label1_19.TabIndex = 19
        Me._Label1_19.Text = "Corrosion allow., shell (or clad)"
        '
        '_Label1_18
        '
        Me._Label1_18.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_18.Location = New System.Drawing.Point(0, 432)
        Me._Label1_18.Name = "_Label1_18"
        Me._Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_18.Size = New System.Drawing.Size(200, 24)
        Me._Label1_18.TabIndex = 18
        Me._Label1_18.Text = "Nozzle thickness (reinforced)"
        '
        '_Label1_17
        '
        Me._Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_17.Location = New System.Drawing.Point(0, 408)
        Me._Label1_17.Name = "_Label1_17"
        Me._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_17.Size = New System.Drawing.Size(200, 24)
        Me._Label1_17.TabIndex = 17
        Me._Label1_17.Text = "Nozzle thickness"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_16.Location = New System.Drawing.Point(0, 384)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(190, 24)
        Me._Label1_16.TabIndex = 16
        Me._Label1_16.Text = "Longitudinal Attachment Dimension"
        '
        '_Label1_15
        '
        Me._Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_15.Location = New System.Drawing.Point(0, 360)
        Me._Label1_15.Name = "_Label1_15"
        Me._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_15.Size = New System.Drawing.Size(190, 24)
        Me._Label1_15.TabIndex = 15
        Me._Label1_15.Text = "Circumferen. Attachment Dimension"
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_14.Location = New System.Drawing.Point(0, 336)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(190, 24)
        Me._Label1_14.TabIndex = 14
        Me._Label1_14.Text = "Outside Attachment Radius"
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_13.Location = New System.Drawing.Point(0, 312)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(190, 24)
        Me._Label1_13.TabIndex = 13
        Me._Label1_13.Text = "Outside Nozzle Radius (reinforced)"
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_12.Location = New System.Drawing.Point(0, 288)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(190, 24)
        Me._Label1_12.TabIndex = 12
        Me._Label1_12.Text = "Outside Nozzle Radius (unreinf.)"
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(0, 264)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(200, 24)
        Me._Label1_11.TabIndex = 11
        Me._Label1_11.Text = "Pad thickness"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(0, 240)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(200, 24)
        Me._Label1_10.TabIndex = 10
        Me._Label1_10.Text = "Shell thickness"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(0, 216)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(200, 24)
        Me._Label1_9.TabIndex = 9
        Me._Label1_9.Text = "Inside Shell Diameter"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(0, 192)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(200, 24)
        Me._Label1_8.TabIndex = 8
        Me._Label1_8.Text = "Nozzle height"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(0, 168)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(109, 24)
        Me._Label1_7.TabIndex = 7
        Me._Label1_7.Text = "Reinforced"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(0, 144)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(109, 24)
        Me._Label1_6.TabIndex = 6
        Me._Label1_6.Text = "Attachment shape"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(0, 120)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(109, 24)
        Me._Label1_5.TabIndex = 5
        Me._Label1_5.Text = "Attachment kind"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(0, 96)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(109, 24)
        Me._Label1_4.TabIndex = 4
        Me._Label1_4.Text = "Type of shell"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(0, 72)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(109, 24)
        Me._Label1_3.TabIndex = 3
        Me._Label1_3.Text = "Rating ASA"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(0, 48)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(120, 24)
        Me._Label1_2.TabIndex = 2
        Me._Label1_2.Text = "Nominal Diameter [in]"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(0, 24)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(109, 24)
        Me._Label1_1.TabIndex = 1
        Me._Label1_1.Text = "Nozzle size"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(0, 0)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(109, 24)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "Nozzle mark"
        '
        '_rtx_8
        '
        Me._rtx_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtx_8.Location = New System.Drawing.Point(200, 192)
        Me._rtx_8.Name = "_rtx_8"
        Me._rtx_8.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_8.Size = New System.Drawing.Size(27, 24)
        Me._rtx_8.TabIndex = 90
        Me._rtx_8.Text = "h"
        '
        '_rtx_9
        '
        Me._rtx_9.Location = New System.Drawing.Point(200, 216)
        Me._rtx_9.Name = "_rtx_9"
        Me._rtx_9.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_9.Size = New System.Drawing.Size(27, 24)
        Me._rtx_9.TabIndex = 91
        Me._rtx_9.Text = ""
        '
        '_rtx_10
        '
        Me._rtx_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtx_10.Location = New System.Drawing.Point(200, 240)
        Me._rtx_10.Name = "_rtx_10"
        Me._rtx_10.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_10.Size = New System.Drawing.Size(27, 24)
        Me._rtx_10.TabIndex = 92
        Me._rtx_10.Text = ""
        '
        '_rtx_11
        '
        Me._rtx_11.Location = New System.Drawing.Point(200, 264)
        Me._rtx_11.Name = "_rtx_11"
        Me._rtx_11.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_11.Size = New System.Drawing.Size(27, 24)
        Me._rtx_11.TabIndex = 93
        Me._rtx_11.Text = ""
        '
        '_rtx_12
        '
        Me._rtx_12.Location = New System.Drawing.Point(200, 288)
        Me._rtx_12.Name = "_rtx_12"
        Me._rtx_12.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_12.Size = New System.Drawing.Size(27, 24)
        Me._rtx_12.TabIndex = 94
        Me._rtx_12.Text = ""
        '
        '_rtx_13
        '
        Me._rtx_13.Location = New System.Drawing.Point(200, 312)
        Me._rtx_13.Name = "_rtx_13"
        Me._rtx_13.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_13.Size = New System.Drawing.Size(27, 24)
        Me._rtx_13.TabIndex = 95
        Me._rtx_13.Text = ""
        '
        '_rtx_14
        '
        Me._rtx_14.Location = New System.Drawing.Point(200, 336)
        Me._rtx_14.Name = "_rtx_14"
        Me._rtx_14.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_14.Size = New System.Drawing.Size(27, 24)
        Me._rtx_14.TabIndex = 96
        Me._rtx_14.Text = ""
        '
        '_rtx_15
        '
        Me._rtx_15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtx_15.Location = New System.Drawing.Point(200, 360)
        Me._rtx_15.Name = "_rtx_15"
        Me._rtx_15.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_15.Size = New System.Drawing.Size(27, 24)
        Me._rtx_15.TabIndex = 97
        Me._rtx_15.Text = ""
        '
        '_rtx_16
        '
        Me._rtx_16.Location = New System.Drawing.Point(200, 384)
        Me._rtx_16.Name = "_rtx_16"
        Me._rtx_16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_16.Size = New System.Drawing.Size(27, 24)
        Me._rtx_16.TabIndex = 98
        Me._rtx_16.Text = ""
        '
        '_rtx_17
        '
        Me._rtx_17.Location = New System.Drawing.Point(200, 408)
        Me._rtx_17.Name = "_rtx_17"
        Me._rtx_17.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_17.Size = New System.Drawing.Size(27, 24)
        Me._rtx_17.TabIndex = 99
        Me._rtx_17.Text = ""
        '
        '_rtx_18
        '
        Me._rtx_18.Location = New System.Drawing.Point(200, 432)
        Me._rtx_18.Name = "_rtx_18"
        Me._rtx_18.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_18.Size = New System.Drawing.Size(27, 24)
        Me._rtx_18.TabIndex = 100
        Me._rtx_18.Text = ""
        '
        '_rtx_19
        '
        Me._rtx_19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtx_19.Location = New System.Drawing.Point(200, 456)
        Me._rtx_19.Name = "_rtx_19"
        Me._rtx_19.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_19.Size = New System.Drawing.Size(27, 24)
        Me._rtx_19.TabIndex = 101
        Me._rtx_19.Text = "c"
        '
        '_rtx_0
        '
        Me._rtx_0.Location = New System.Drawing.Point(200, 480)
        Me._rtx_0.Name = "_rtx_0"
        Me._rtx_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_0.Size = New System.Drawing.Size(27, 24)
        Me._rtx_0.TabIndex = 102
        Me._rtx_0.Text = ""
        '
        '_rtx_20
        '
        Me._rtx_20.Location = New System.Drawing.Point(200, 504)
        Me._rtx_20.Name = "_rtx_20"
        Me._rtx_20.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_20.Size = New System.Drawing.Size(27, 24)
        Me._rtx_20.TabIndex = 103
        Me._rtx_20.Text = ""
        '
        '_rtx_21
        '
        Me._rtx_21.Location = New System.Drawing.Point(200, 528)
        Me._rtx_21.Name = "_rtx_21"
        Me._rtx_21.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_21.Size = New System.Drawing.Size(27, 24)
        Me._rtx_21.TabIndex = 104
        Me._rtx_21.Text = ""
        '
        '_rtx_22
        '
        Me._rtx_22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtx_22.Location = New System.Drawing.Point(200, 552)
        Me._rtx_22.Name = "_rtx_22"
        Me._rtx_22.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_22.Size = New System.Drawing.Size(27, 24)
        Me._rtx_22.TabIndex = 105
        Me._rtx_22.Text = "L"
        '
        '_rtx_23
        '
        Me._rtx_23.Location = New System.Drawing.Point(200, 576)
        Me._rtx_23.Name = "_rtx_23"
        Me._rtx_23.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_23.Size = New System.Drawing.Size(27, 24)
        Me._rtx_23.TabIndex = 106
        Me._rtx_23.Text = ""
        '
        '_rtx_24
        '
        Me._rtx_24.Location = New System.Drawing.Point(200, 600)
        Me._rtx_24.Name = "_rtx_24"
        Me._rtx_24.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_24.Size = New System.Drawing.Size(27, 24)
        Me._rtx_24.TabIndex = 107
        Me._rtx_24.Text = ""
        Me._rtx_24.Visible = False
        '
        'frmGeom
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(342, 630)
        Me.ControlBox = False
        Me.Controls.Add(Me._rtx_8)
        Me.Controls.Add(Me._rtx_10)
        Me.Controls.Add(Me._rtx_15)
        Me.Controls.Add(Me._rtx_24)
        Me.Controls.Add(Me._rtx_23)
        Me.Controls.Add(Me._rtx_22)
        Me.Controls.Add(Me._rtx_21)
        Me.Controls.Add(Me._rtx_20)
        Me.Controls.Add(Me._rtx_0)
        Me.Controls.Add(Me._rtx_19)
        Me.Controls.Add(Me._rtx_18)
        Me.Controls.Add(Me._rtx_17)
        Me.Controls.Add(Me._rtx_16)
        Me.Controls.Add(Me._rtx_14)
        Me.Controls.Add(Me._rtx_13)
        Me.Controls.Add(Me._rtx_12)
        Me.Controls.Add(Me._rtx_11)
        Me.Controls.Add(Me._rtx_9)
        Me.Controls.Add(Me._lblUni_24)
        Me.Controls.Add(Me._lblUni_23)
        Me.Controls.Add(Me._lblUni_22)
        Me.Controls.Add(Me._lblUni_21)
        Me.Controls.Add(Me._Text1_20)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Text1_24)
        Me.Controls.Add(Me._Text1_23)
        Me.Controls.Add(Me._Text1_22)
        Me.Controls.Add(Me._Text1_21)
        Me.Controls.Add(Me._Text1_19)
        Me.Controls.Add(Me._Text1_18)
        Me.Controls.Add(Me._Text1_17)
        Me.Controls.Add(Me._Text1_16)
        Me.Controls.Add(Me._Text1_15)
        Me.Controls.Add(Me._Text1_14)
        Me.Controls.Add(Me._Text1_13)
        Me.Controls.Add(Me._Text1_12)
        Me.Controls.Add(Me._Text1_11)
        Me.Controls.Add(Me._Text1_10)
        Me.Controls.Add(Me._Text1_9)
        Me.Controls.Add(Me._Text1_8)
        Me.Controls.Add(Me._Combo1_7)
        Me.Controls.Add(Me._Combo1_6)
        Me.Controls.Add(Me._Combo1_5)
        Me.Controls.Add(Me._Combo1_4)
        Me.Controls.Add(Me._Combo1_3)
        Me.Controls.Add(Me._Combo1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me._lblUni_20)
        Me.Controls.Add(Me._Label1_20)
        Me.Controls.Add(Me._Label1_25)
        Me.Controls.Add(Me._lblUni_0)
        Me.Controls.Add(Me._lblUni_19)
        Me.Controls.Add(Me._lblUni_18)
        Me.Controls.Add(Me._lblUni_17)
        Me.Controls.Add(Me._lblUni_16)
        Me.Controls.Add(Me._lblUni_15)
        Me.Controls.Add(Me._lblUni_14)
        Me.Controls.Add(Me._lblUni_13)
        Me.Controls.Add(Me._lblUni_12)
        Me.Controls.Add(Me._lblUni_11)
        Me.Controls.Add(Me._lblUni_10)
        Me.Controls.Add(Me._lblUni_9)
        Me.Controls.Add(Me._lblUni_8)
        Me.Controls.Add(Me._Label1_24)
        Me.Controls.Add(Me._Label1_23)
        Me.Controls.Add(Me._Label1_22)
        Me.Controls.Add(Me._Label1_21)
        Me.Controls.Add(Me._Label1_19)
        Me.Controls.Add(Me._Label1_18)
        Me.Controls.Add(Me._Label1_17)
        Me.Controls.Add(Me._Label1_16)
        Me.Controls.Add(Me._Label1_15)
        Me.Controls.Add(Me._Label1_14)
        Me.Controls.Add(Me._Label1_13)
        Me.Controls.Add(Me._Label1_12)
        Me.Controls.Add(Me._Label1_11)
        Me.Controls.Add(Me._Label1_10)
        Me.Controls.Add(Me._Label1_9)
        Me.Controls.Add(Me._Label1_8)
        Me.Controls.Add(Me._Label1_7)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmGeom"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "WRCB - Dati geometrici apertura"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmGeom
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmGeom
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmGeom()
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
    Private Inizializzando As Boolean
    Private Sub Combo1_SelectedIndexChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        Select Case Index
            Case 2 : Geom(iB).DiaN = GlobaLroutines.ValVir(Combo1(Index).Text)
            Case 3 'rating
                Geom(iB).Asa = Combo1(Index).SelectedIndex
            Case 4 'type of shell
                Geom(iB).ShellType = Combo1(Index).SelectedIndex
                AggLabel()
                AggTesti()
            Case 5 'attachment kind
                Geom(iB).Buco = Combo1(Index).SelectedIndex
                AggLabel()
                AggTesti()
            Case 6 'attachement shape
                Geom(iB).Forma = Combo1(Index).SelectedIndex
                AggLabel()
                AggTesti()
            Case 7 'reinforced
                Geom(iB).Rinforzo = -Combo1(Index).SelectedIndex
                If Geom(iB).Rinforzo = 0 Then Geom(iB).Padd = 0 : Geom(iB).PadT = 0
                AggLabel()
                AggTesti()
        End Select
    End Sub
    Private ReadOnly Property Combo1(ByVal i As Integer) As ComboBox
        Get
            Select Case i
                Case 3 : Return _Combo1_3
                Case 4 : Return _Combo1_4
                Case 5 : Return _Combo1_5
                Case 6 : Return _Combo1_6
                Case 7 : Return _Combo1_7
                Case 2 : Return _Combo1_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim a As String
        Dim HLimit1, HLimit2 As Single
        Dim R, Ext As Single
        Dim junk As Integer
        If Config.Analisi = 0 Then
            Geom(iB).R0 = GlobaLroutines.ValVir(Text1(14).Text)
            Geom(iB).RX = Geom(iB).R0
        Else
            Geom(iB).R0 = GlobaLroutines.ValVir(Text1(12).Text)
            Geom(iB).RX = GlobaLroutines.ValVir(Text1(13).Text)
        End If 'h
        If Config.Analisi = 0 Then
            Geom(iB).T0 = GlobaLroutines.ValVir(Text1(17).Text)
            Geom(iB).TX = Geom(iB).T0
        Else
            Geom(iB).T0 = GlobaLroutines.ValVir(Text1(17).Text)
            Geom(iB).TX = GlobaLroutines.ValVir(Text1(18).Text)
        End If
        If Geom(iB).Forma = 1 Then
            Geom(iB).D1Rinf = GlobaLroutines.ValVir(Text1(20).Text)
            Geom(iB).D2Rinf = GlobaLroutines.ValVir(Text1(21).Text)
        End If
        If Geom(iB).Casi > 4 Then Geom(iB).Casi = 4
        If Geom(iB).ShellType = 0 And Config.WRC297 > 2 Then
            If Geom(iB).Cyld > Geom(iB).CylL / 2 Then
                a = " Unconsistent data. Check cylinder |length versus off-centre distance |"
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(a), MsgBoxStyle.Critical + MsgBoxStyle.OKOnly)
                Exit Sub
            End If
        End If
        Geom(iB).BS35434 = False
        If Geom(iB).Rinforzo And Geom(iB).Forma = 0 And Geom(iB).Buco = 0 And Geom(iB).ShellType = 1 And Config.WRC297 > 2 Then
            HLimit1 = 2 * Geom(iB).R0 + Geom(iB).T0
            HLimit2 = 2 * Geom(iB).RX + Geom(iB).TX : If HLimit2 > HLimit1 Then HLimit1 = HLimit2
            HLimit2 = System.Math.Sqrt((2 * Geom(iB).RC + Geom(iB).ShellT) * (Geom(iB).ShellT + Geom(iB).PadT))
            If HLimit2 < HLimit1 Then HLimit1 = HLimit2
            R = Geom(iB).R0
            If Geom(iB).RX > Geom(iB).R0 Then R = Geom(iB).R0
            Ext = (Geom(iB).Padd - R) / 2
            If Ext < HLimit1 Then
                a = " Il rinforzo non è sufficientemente  | esteso (BS 3.5.4.3.4(b).|"
                a = a & "    Estensione attuale:   " & globalRoutines.myStr(Ext, 4, 1, False) & Config.Unit(1)
                a = a & "|    Estensione richiesta: " & globalRoutines.myStr(HLimit1, 4, 1, False) & Config.Unit(1)
                a = a & "| Vuoi correggere come da norma?"
                junk = MsgBox(Monitor.Motore.Inizio.ConvertiCr(a), MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If junk = MsgBoxResult.Yes Then
                    Geom(iB).Padd = CShort(2 * (R + HLimit1))
                    AggTesti()
                    Exit Sub
                End If
                Geom(iB).BS35434 = True
            End If
        End If
        If Geom(iB).Forma = 0 And Geom(iB).Buco = 1 Then
            Geom(iB).D2 = Geom(iB).D1
            Geom(iB).D2Rinf = Geom(iB).D1Rinf
        End If
        OK = True
        If Geom(iB).Buco = 0 And Geom(iB).Forma = 1 Then
            MsgBox(Monitor.Motore.Inizio.ConvertiCr("La combinazione 'forma rettangolare'| con 'attacco forato' non è ammessa"), MsgBoxStyle.Information)
            Geom(iB).Forma = 0
            OK = False
        End If
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        OK = False
        Hide()
    End Sub


    Private Sub frmGeom_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim ifl, i As Short
        Dim Testo As String
        Combo1(3).Items.Add("N.A.")
        Combo1(3).Items.Add(" 150")
        Combo1(3).Items.Add(" 300")
        Combo1(3).Items.Add(" 400")
        Combo1(3).Items.Add(" 600")
        Combo1(3).Items.Add(" 900")
        Combo1(3).Items.Add("1500")
        Combo1(3).Items.Add("2500")
        Combo1(4).Items.Add("On cylinder")
        Combo1(4).Items.Add("On sphere")
        Combo1(5).Items.Add("Hollow attachment")
        Combo1(5).Items.Add("Rigid attachment")
        Combo1(6).Items.Add("Round attachment")
        Combo1(6).Items.Add("Rectangular attachment")
        Combo1(7).Items.Add("NO")
        Combo1(7).Items.Add("SI")
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\ASME1.DAT", OpenMode.Input, , OpenShare.Shared)
        Testo = LineInput(ifl)
        For i = 1 To 30
            Input(ifl, Testo)
            Combo1(2).Items.Add(Testo)
        Next
        FileClose(ifl)
        AggLabel()
        AggTesti()
        AggCombo()
    End Sub
    Public Sub AggLabel()
        Dim i As Short
        Dim Radice As String = Monitor.Motore.Inizio.Archdir + "\RTF\"
        If Geom(iB).ShellType = 1 Then 'sfera
            Label1(9).Text = "Inside Shell Radius   " ' + Config.Unit(1) + " ri "
            'rtx(9).Rtf = "{\rtf {\fs16  r\sub i}}"
            _rtx_9.LoadFile(Radice + "rtfDi.rtf")
        Else
            Label1(9).Text = "Inside Shell Diameter " ' + Config.Unit(1) + " íi "
            'rtx(9).Rtf = "{\rtf {\fs16  D\sub i}}"
            _rtx_9.LoadFile(Radice + "rtfri.rtf")
        End If '\
        'rtx(8).Rtf = "{\rtf {\fs16  h}}"
        'Label1(10) = "Shell Thickness       " + Config.Unit(1) + " ts "
        'rtx(10).Rtf = "{\rtf {\fs16  t\sub s}}"
        _rtx_10.LoadFile(Radice + "rtfts.rtf")
        'Label1(11) = "Pad Thickness         " + Config.Unit(1) + " tp "
        ' rtx(11).Rtf = "{\rtf {\fs16  t\sub p}}"
        _rtx_11.LoadFile(Radice + "rtftp.rtf")
        'Label1(12) = "Outside Nozz.R (unr.) " + Config.Unit(1) + " ro "
        'rtx(12).Rtf = "{\rtf {\fs16  r\sub 0}}"
        _rtx_12.LoadFile(Radice + "rtfr0.rtf")
        'Label1(13) = "Outside Nozz.R (reinf)" + Config.Unit(1) + " r1 "
        'rtx(13).Rtf = "{\rtf {\fs16  r\sub 1}}"
        _rtx_13.LoadFile(Radice + "rtfr1.rtf")
        'Label1(14) = "Outside Attach Radius " + Config.Unit(1) + " ro "
        'rtx(14).Rtf = "{\rtf {\fs16  r\sub 0}}"
        _rtx_14.LoadFile(Radice + "rtfr0.rtf")
        'Label1(15) = "Circumf Attach Dimens " + Config.Unit(1) + "2c1 "
        'rtx(15).Rtf = "{\rtf {\fs20 2c\sub 1}}"
        _rtx_15.LoadFile(Radice + "rtf2c1.rtf")
        'Label1(16) = "Longit. Attach Dimens " + Config.Unit(1) + "2c2 "
        'rtx(16).Rtf = "{\rtf {\fs16 2c\sub 2}}"
        _rtx_16.LoadFile(Radice + "rtfDi.rtf")
        ' rtx(17).Rtf = "{\rtf {\fs16  t\sub n}}"
        _rtx_17.LoadFile(Radice + "rtftn.rtf")
        ' rtx(18).Rtf = "{\rtf {\fs16  t\sub r}}"
        _rtx_18.LoadFile(Radice + "rtftr.rtf")
        'rtx(19).Rtf = "{\rtf {\fs16  c}}"
        'rtx(0).Rtf = "{\rtf {\fs16  c\sub N}}"
        _rtx_0.LoadFile(Radice + "rtfcN.rtf")
        _rtx_20.LoadFile(Radice + "rtfdp.rtf")
        _rtx_21.LoadFile(Radice + "rtfd2.rtf")
        _rtx_23.LoadFile(Radice + "rtfLm.rtf")
        Label1(1).Visible = True
        Label1(2).Visible = True
        Label1(3).Visible = True
        Text1(1).Visible = True
        Combo1(2).Visible = True
        Combo1(3).Visible = True
        'lblUni(0).Visible = True
        lblUni(0).Text = Config.Unit(1)
        For i = 8 To 23
            lblUni(i).Visible = True
            lblUni(i).Text = Config.Unit(1)
            rtx(i).Visible = True
            Label1(i).Visible = True
            Text1(i).Visible = True
        Next
        If Geom(iB).ShellType = 1 Then
            Label1(15).Text = "Attachment Dimension  " ' + Config.Unit(1) + "2c1 "
            'rtx(15).Rtf = "{\rtf {\fs16 2c\sub 1}}"
            _rtx_15.LoadFile(Radice + "rtf2c1.rtf")
            Label1(16).Visible = False
            Text1(16).Visible = False
            rtx(16).Visible = False
            lblUni(16).Visible = False
        End If 'a
        'Label1(17) = "Nozzle Thickness      " + Config.Unit(1) + " t  "
        'Label1(18) = "Nozzle Thck. (reinf.) " + Config.Unit(1) + " t1 "
        'Label1(19) = "Corrosion Allowance   " + Config.Unit(1) + " c  "
        If Geom(iB).Forma = 1 Then
            Label1(20).Text = "Circumf Pad Dimens " ' + Config.Unit(1) + "2c1 "
            'rtx(20).Rtf = "{\rtf {\fs16 2c\sub 1r}}"
            _rtx_20.LoadFile(Radice + "rtf2c1r.rtf")
            'rtx(21).Rtf = "{\rtf {\fs16 2c\sub 2r}}"
            _rtx_21.LoadFile(Radice + "rtf2c2r.rtf")
        Else
            Label1(20).Text = "Pad Diameter          " ' + Config.Unit(1) + " íp "
            'rtx(20).Rtf = "{\rtf {\fs16  D\sub p}}"
            _rtx_20.LoadFile(Radice + "rtfdp.rtf")
        End If
        'Label1(21) = "Longit. Pad Dimens " + Config.Unit(1) + "2c2 "
        If Geom(iB).ShellType = 1 Then
            Label1(20).Text = "Pad Dimension  " ' + Config.Unit(1) + "2c1 "
            'rtx(20).Rtf = "{\rtf {\fs16 2c\sub 1}}"
            _rtx_20.LoadFile(Radice + "rtf2c1.rtf")
            Label1(22).Visible = False
            Text1(22).Visible = False
            rtx(22).Visible = False
            lblUni(22).Visible = False
        End If 'a
        'Label1(22) = "Cylinder length       " + Config.Unit(1) + " L  "
        'Label1(23) = "Nozz.offset/mid-plane " + Config.Unit(1) + " d  "
        'Label1(24) = "Number of load cases  "
        'rtx(22).Rtf = "{\rtf {\fs16  L}}"
        'rtx(23).Rtf = "{\rtf {\fs16  d}}"
        If Config.WRC297 < 3 Or Geom(iB).ShellType > 0 Then
            Label1(22).Visible = False
            Text1(22).Visible = False
            rtx(22).Visible = False
            lblUni(22).Visible = False
            Label1(23).Visible = False
            Text1(23).Visible = False
            rtx(23).Visible = False
            lblUni(23).Visible = False
        End If 's
        If Geom(iB).Forma > 0 Then 'rett.
            If Config.Analisi = 0 Then
                Label1(17).Visible = False
                Label1(18).Visible = False
                Text1(17).Visible = False
                Text1(18).Visible = False
                rtx(17).Visible = False
                lblUni(17).Visible = False
                rtx(18).Visible = False
                lblUni(18).Visible = False
            End If 'd
            Label1(14).Visible = False
            Label1(12).Visible = False
            Label1(13).Visible = False
            Text1(14).Visible = False
            Text1(12).Visible = False
            Text1(13).Visible = False
            rtx(12).Visible = False
            lblUni(12).Visible = False
            rtx(13).Visible = False
            lblUni(13).Visible = False
            rtx(14).Visible = False
            lblUni(14).Visible = False
        Else
            If Config.Analisi = 0 Then
                Label1(12).Visible = False
                Label1(13).Visible = False
                Label1(18).Visible = False
                Text1(12).Visible = False
                Text1(13).Visible = False
                Text1(18).Visible = False
                rtx(12).Visible = False
                lblUni(12).Visible = False
                rtx(13).Visible = False
                lblUni(13).Visible = False
                rtx(18).Visible = False
                lblUni(18).Visible = False
            Else
                Label1(14).Visible = False
                Text1(14).Visible = False
                rtx(14).Visible = False
                lblUni(14).Visible = False
            End If 'f
            Label1(15).Visible = False
            Label1(16).Visible = False
            Label1(21).Visible = False
            Text1(15).Visible = False
            Text1(16).Visible = False
            Text1(21).Visible = False
            rtx(15).Visible = False
            lblUni(15).Visible = False
            rtx(16).Visible = False
            lblUni(16).Visible = False
            rtx(21).Visible = False
            lblUni(21).Visible = False
        End If 'g
        If Geom(iB).Buco = 1 Then
            Label1(1).Visible = False
            Label1(2).Visible = False
            Label1(3).Visible = False
            Text1(1).Visible = False
            Combo1(2).Visible = False
            Combo1(3).Visible = False
            Label1(17).Visible = False
            Label1(18).Visible = False
            Text1(17).Visible = False
            Text1(18).Visible = False
            rtx(17).Visible = False
            lblUni(17).Visible = False
            rtx(18).Visible = False
            lblUni(18).Visible = False
        End If
        If Not Geom(iB).Rinforzo Then
            Label1(11).Visible = False
            Label1(20).Visible = False
            Label1(21).Visible = False
            Text1(11).Visible = False
            Text1(20).Visible = False
            Text1(21).Visible = False
            rtx(11).Visible = False
            lblUni(11).Visible = False
            rtx(20).Visible = False
            lblUni(20).Visible = False
            rtx(21).Visible = False
            lblUni(21).Visible = False
        End If
        If Config.Reduced = 0 Then
            Label1(8).Visible = False
            Text1(8).Visible = False
            rtx(8).Visible = False
            lblUni(8).Visible = False
        End If
    End Sub

    Public Sub AggTesti()
        aggFinestra = True
        Text1(0).Text = Geom(iB).Mark
        Text1(1).Text = Geom(iB).Size
        '   Text1(2) = myStr(Geom(iB).DiaN, 3, 1, False)
        Text1(8).Text = globalRoutines.myStr(Geom(iB).Sporg, 5, 1, False)
        If Geom(iB).ShellType = 1 Then 'sfera
            Text1(9).Text = globalRoutines.myStr(Geom(iB).RC, 5, 2, False)
        Else
            Text1(9).Text = globalRoutines.myStr(Geom(iB).di, 5, 2, False)
        End If '\
        Text1(10).Text = globalRoutines.myStr(Geom(iB).ShellT, 5, 2, False)
        Text1(11).Text = globalRoutines.myStr(Geom(iB).PadT, 5, 2, False)
        Text1(12).Text = globalRoutines.myStr(Geom(iB).R0, 5, 2, False)
        Text1(13).Text = globalRoutines.myStr(Geom(iB).RX, 5, 2, False)
        Text1(14).Text = globalRoutines.myStr(Geom(iB).R0, 5, 2, False)
        Text1(15).Text = globalRoutines.myStr(Geom(iB).D1, 5, 2, False)
        Text1(16).Text = globalRoutines.myStr(Geom(iB).D2, 5, 2, False)
        Text1(17).Text = globalRoutines.myStr(Geom(iB).T0, 5, 2, False)
        Text1(18).Text = globalRoutines.myStr(Geom(iB).TX, 5, 2, False)
        Text1(19).Text = globalRoutines.myStr(Geom(iB).Corr, 5, 2, False)
        Text1(2).Text = globalRoutines.myStr(Geom(iB).CorrN, 5, 2, False)
        If Geom(iB).Forma = 1 Then
            Text1(20).Text = globalRoutines.myStr(Geom(iB).D1Rinf, 5, 2, False)
        Else
            Text1(20).Text = globalRoutines.myStr(Geom(iB).Padd, 5, 2, False)
        End If
        Text1(21).Text = globalRoutines.myStr(Geom(iB).D2Rinf, 5, 2, False)
        If Geom(iB).ShellType = 1 Then
            Text1(15).Text = globalRoutines.myStr(Geom(iB).D1, 5, 2, False)
        End If 'a
        Text1(22).Text = globalRoutines.myStr(Geom(iB).CylL, 5, 2, False)
        Text1(23).Text = globalRoutines.myStr(Geom(iB).Cyld, 5, 2, False)
        Text1(24).Text = globalRoutines.myStr(Geom(iB).Casi, 3, 0, True)
        aggFinestra = False
    End Sub
    Private Sub Text1_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        If aggFinestra Then Exit Sub
        Select Case Index
            Case 0 : Geom(iB).Mark = Text1(Index).Text
            Case 1 : Geom(iB).Size = Text1(Index).Text
            Case 2 : Geom(iB).CorrN = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 8 : Geom(iB).Sporg = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 9 : Geom(iB).di = GlobaLroutines.ValVir(Text1(Index).Text)
                Geom(iB).RC = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 10 : Geom(iB).ShellT = GlobaLroutines.ValVir(Text1(Index).Text)
                Gia297(iB) = False
            Case 11 : Geom(iB).PadT = GlobaLroutines.ValVir(Text1(Index).Text)
                Gia297(iB) = False
            Case 12 : Geom(iB).R0 = GlobaLroutines.ValVir(Text1(Index).Text)
                Gia297(iB) = False
            Case 13 : Geom(iB).RX = GlobaLroutines.ValVir(Text1(Index).Text)
                Gia297(iB) = False
            Case 14 : Geom(iB).R0 = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 15 : Geom(iB).D1 = GlobaLroutines.ValVir(Text1(Index).Text)
                If Geom(iB).ShellType = 1 Then Geom(iB).D2 = Geom(iB).D1
            Case 16 : Geom(iB).D2 = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 17 : Geom(iB).T0 = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 18 : Geom(iB).TX = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 19 : Geom(iB).Corr = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 20
                If Geom(iB).Forma = 1 Then
                    Geom(iB).D1Rinf = GlobaLroutines.ValVir(Text1(Index).Text)
                Else
                    Geom(iB).Padd = GlobaLroutines.ValVir(Text1(Index).Text)
                    Gia297(iB) = False
                End If
            Case 21 : Geom(iB).D2Rinf = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 22 : Geom(iB).CylL = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 23 : Geom(iB).Cyld = GlobaLroutines.ValVir(Text1(Index).Text)
            Case 24 : Geom(iB).Casi = GlobaLroutines.ValVir(Text1(Index).Text)
        End Select
    End Sub
    Private ReadOnly Property Text1(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _Text1_0
                Case 1 : Return _Text1_1
                Case 2 : Return _Text1_2
                Case 8 : Return _Text1_8
                Case 9 : Return _Text1_9
                Case 10 : Return _Text1_10
                Case 11 : Return _Text1_11
                Case 12 : Return _Text1_12
                Case 13 : Return _Text1_13
                Case 14 : Return _Text1_14
                Case 15 : Return _Text1_15
                Case 16 : Return _Text1_16
                Case 17 : Return _Text1_17
                Case 18 : Return _Text1_18
                Case 19 : Return _Text1_19
                Case 20 : Return _Text1_20
                Case 21 : Return _Text1_21
                Case 22 : Return _Text1_22
                Case 23 : Return _Text1_23
                Case 24 : Return _Text1_24
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property lblUni(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _lblUni_0
                Case 8 : Return _lblUni_8
                Case 9 : Return _lblUni_9
                Case 10 : Return _lblUni_10
                Case 11 : Return _lblUni_11
                Case 12 : Return _lblUni_12
                Case 13 : Return _lblUni_13
                Case 14 : Return _lblUni_14
                Case 15 : Return _lblUni_15
                Case 16 : Return _lblUni_16
                Case 17 : Return _lblUni_17
                Case 18 : Return _lblUni_18
                Case 19 : Return _lblUni_19
                Case 20 : Return _lblUni_20
                Case 21 : Return _lblUni_21
                Case 22 : Return _lblUni_22
                Case 23 : Return _lblUni_23
                Case 24 : Return _lblUni_24
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Label1(ByVal i As Integer) As Label
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
                Case 12 : Return _Label1_12
                Case 13 : Return _Label1_13
                Case 14 : Return _Label1_14
                Case 15 : Return _Label1_15
                Case 16 : Return _Label1_16
                Case 17 : Return _Label1_17
                Case 18 : Return _Label1_18
                Case 19 : Return _Label1_19
                Case 20 : Return _Label1_20
                Case 21 : Return _Label1_21
                Case 22 : Return _Label1_22
                Case 23 : Return _Label1_23
                Case 24 : Return _Label1_24
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub AggCombo()
        Combo1(2).Text = Str(Geom(iB).DiaN)
        Combo1(3).SelectedIndex = Geom(iB).Asa
        Combo1(4).SelectedIndex = Geom(iB).ShellType
        Combo1(5).SelectedIndex = Geom(iB).Buco
        Combo1(6).SelectedIndex = Geom(iB).Forma
        Combo1(7).SelectedIndex = -Geom(iB).Rinforzo
    End Sub
    Private ReadOnly Property rtx(ByVal i As Integer) As RichTextBox
        Get
            Select Case i
                Case 8 : Return _rtx_8
                Case 9 : Return _rtx_9
                Case 10 : Return _rtx_10
                Case 11 : Return _rtx_11
                Case 12 : Return _rtx_12
                Case 13 : Return _rtx_13
                Case 14 : Return _rtx_14
                Case 15 : Return _rtx_15
                Case 16 : Return _rtx_16
                Case 17 : Return _rtx_17
                Case 18 : Return _rtx_18
                Case 19 : Return _rtx_19
                Case 20 : Return _rtx_20
                Case 21 : Return _rtx_21
                Case 22 : Return _rtx_22
                Case 23 : Return _rtx_23
                Case 24 : Return _rtx_24
                Case 0 : Return _rtx_14
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

    Private Sub _Text1_12_TextAlignChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_12.TextAlignChanged
        Text1_TextChanged(12)
    End Sub

    Private Sub _Text1_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_13.TextChanged
        Text1_TextChanged(13)
    End Sub

    Private Sub _Text1_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_14.TextChanged
        Text1_TextChanged(14)
    End Sub

    Private Sub _Text1_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_15.TextChanged
        Text1_TextChanged(15)
    End Sub

    Private Sub _Text1_16_TextAlignChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_16.TextAlignChanged
        Text1_TextChanged(16)
    End Sub

    Private Sub _Text1_17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_17.TextChanged
        Text1_TextChanged(17)
    End Sub

    Private Sub _Text1_18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_18.TextChanged
        Text1_TextChanged(18)
    End Sub

    Private Sub _Text1_19_TextAlignChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_19.TextAlignChanged
        Text1_TextChanged(19)
    End Sub

    Private Sub _Text1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_2.TextChanged
        Text1_TextChanged(2)
    End Sub

    Private Sub _Text1_20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_20.TextChanged
        Text1_TextChanged(20)
    End Sub

    Private Sub _Text1_21_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_21.TextChanged
        Text1_TextChanged(21)
    End Sub

    Private Sub _Text1_22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_22.TextChanged
        Text1_TextChanged(22)
    End Sub

    Private Sub _Text1_23_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_23.TextChanged
        Text1_TextChanged(23)
    End Sub

    Private Sub _Text1_24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_24.TextChanged
        Text1_TextChanged(24)
    End Sub

    Private Sub _Text1_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_8.TextChanged
        Text1_TextChanged(8)
    End Sub

    Private Sub _Text1_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_9.TextChanged
        Text1_TextChanged(9)
    End Sub

    Private Sub _Combo1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_2.TextChanged
        If Inizializzando Then Exit Sub
        Geom(iB).DiaN = GlobaLroutines.ValVir(_Combo1_2.Text)
    End Sub

    Private Sub _Combo1_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_2.SelectedIndexChanged
        Combo1_SelectedIndexChanged(2)
    End Sub

    Private Sub _Combo1_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_3.SelectedIndexChanged
        Combo1_SelectedIndexChanged(3)
    End Sub

    Private Sub _Combo1_4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_4.SelectedIndexChanged
        Combo1_SelectedIndexChanged(4)
    End Sub

    Private Sub _Combo1_5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_5.SelectedIndexChanged
        Combo1_SelectedIndexChanged(5)
    End Sub

    Private Sub _Combo1_6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_6.SelectedIndexChanged
        Combo1_SelectedIndexChanged(6)
    End Sub

    Private Sub _Combo1_7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_7.SelectedIndexChanged
        Combo1_SelectedIndexChanged(7)
    End Sub
End Class