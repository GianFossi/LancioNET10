Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmLib
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
	Public WithEvents Command7 As System.Windows.Forms.Button
	Public WithEvents Command6 As System.Windows.Forms.Button
	Public WithEvents Command5 As System.Windows.Forms.Button
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Codici As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Combo1 As System.Windows.Forms.ComboBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents _Text2_3 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_4 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_6 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_7 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_8 As System.Windows.Forms.TextBox
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
	Public WithEvents _Label2_3 As System.Windows.Forms.Label
	Public WithEvents _Label2_5 As System.Windows.Forms.Label
	Public WithEvents _Label2_6 As System.Windows.Forms.Label
	Public WithEvents _Label2_7 As System.Windows.Forms.Label
	Public WithEvents _Label2_8 As System.Windows.Forms.Label
	Public WithEvents _lblUni_3 As System.Windows.Forms.Label
	Public WithEvents _lblUni_4 As System.Windows.Forms.Label
	Public WithEvents _lblUni_5 As System.Windows.Forms.Label
	Public WithEvents _lblUni_6 As System.Windows.Forms.Label
	Public WithEvents _lblUni_7 As System.Windows.Forms.Label
	Public WithEvents _lblUni_8 As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents _rtx_3 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_4 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_5 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_6 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_7 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_8 As System.Windows.Forms.RichTextBox
    Friend WithEvents TabStrip1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command7 = New System.Windows.Forms.Button
        Me.Command6 = New System.Windows.Forms.Button
        Me.Command5 = New System.Windows.Forms.Button
        Me.Command4 = New System.Windows.Forms.Button
        Me.Codici = New System.Windows.Forms.TextBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Command3 = New System.Windows.Forms.Button
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Picture1 = New System.Windows.Forms.Panel
        Me._rtx_8 = New System.Windows.Forms.RichTextBox
        Me._rtx_7 = New System.Windows.Forms.RichTextBox
        Me._rtx_6 = New System.Windows.Forms.RichTextBox
        Me._rtx_5 = New System.Windows.Forms.RichTextBox
        Me._rtx_4 = New System.Windows.Forms.RichTextBox
        Me._rtx_3 = New System.Windows.Forms.RichTextBox
        Me._Text2_3 = New System.Windows.Forms.TextBox
        Me._Text2_4 = New System.Windows.Forms.TextBox
        Me._Text2_5 = New System.Windows.Forms.TextBox
        Me._Text2_6 = New System.Windows.Forms.TextBox
        Me._Text2_7 = New System.Windows.Forms.TextBox
        Me._Text2_8 = New System.Windows.Forms.TextBox
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me._Label2_7 = New System.Windows.Forms.Label
        Me._Label2_8 = New System.Windows.Forms.Label
        Me._lblUni_3 = New System.Windows.Forms.Label
        Me._lblUni_4 = New System.Windows.Forms.Label
        Me._lblUni_5 = New System.Windows.Forms.Label
        Me._lblUni_6 = New System.Windows.Forms.Label
        Me._lblUni_7 = New System.Windows.Forms.Label
        Me._lblUni_8 = New System.Windows.Forms.Label
        Me.TabStrip1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Picture1.SuspendLayout()
        Me.TabStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Command7
        '
        Me.Command7.BackColor = System.Drawing.SystemColors.Control
        Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command7.Location = New System.Drawing.Point(320, 168)
        Me.Command7.Name = "Command7"
        Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command7.Size = New System.Drawing.Size(154, 19)
        Me.Command7.TabIndex = 50
        Me.Command7.Text = "Aggiungi in fondo"
        '
        'Command6
        '
        Me.Command6.BackColor = System.Drawing.SystemColors.Control
        Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command6.Location = New System.Drawing.Point(176, 168)
        Me.Command6.Name = "Command6"
        Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command6.Size = New System.Drawing.Size(136, 19)
        Me.Command6.TabIndex = 49
        Me.Command6.Text = "Inserisci scheda"
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(16, 168)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(145, 19)
        Me.Command5.TabIndex = 48
        Me.Command5.Text = "Elimina questa scheda"
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(192, 304)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(136, 19)
        Me.Command4.TabIndex = 47
        Me.Command4.Text = "Elimina standard attivo"
        '
        'Codici
        '
        Me.Codici.AcceptsReturn = True
        Me.Codici.AutoSize = False
        Me.Codici.BackColor = System.Drawing.SystemColors.Window
        Me.Codici.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Codici.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Codici.Location = New System.Drawing.Point(424, 272)
        Me.Codici.MaxLength = 0
        Me.Codici.Name = "Codici"
        Me.Codici.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Codici.Size = New System.Drawing.Size(46, 19)
        Me.Codici.TabIndex = 45
        Me.Codici.Text = "Text3"
        Me.Codici.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(192, 272)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(136, 19)
        Me.Command2.TabIndex = 43
        Me.Command2.TabStop = False
        Me.Command2.Text = "Nuovo standard"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(424, 328)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(46, 19)
        Me.Command1.TabIndex = 42
        Me.Command1.TabStop = False
        Me.Command1.Text = "Fatto"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Command3)
        Me.Frame2.Controls.Add(Me.Combo1)
        Me.Frame2.ForeColor = System.Drawing.Color.Yellow
        Me.Frame2.Location = New System.Drawing.Point(192, 192)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(280, 73)
        Me.Frame2.TabIndex = 40
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Standard"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(153, 45)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(118, 19)
        Me.Command3.TabIndex = 46
        Me.Command3.TabStop = False
        Me.Command3.Text = "Salva nuovi valori"
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(9, 18)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(262, 21)
        Me.Combo1.TabIndex = 41
        Me.Combo1.TabStop = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._Text1_4)
        Me.Frame1.Controls.Add(Me._Text1_6)
        Me.Frame1.Controls.Add(Me._Text1_5)
        Me.Frame1.Controls.Add(Me._Text1_3)
        Me.Frame1.Controls.Add(Me._Text1_2)
        Me.Frame1.Controls.Add(Me._Text1_1)
        Me.Frame1.Controls.Add(Me._Text1_0)
        Me.Frame1.Controls.Add(Me._Label1_4)
        Me.Frame1.Controls.Add(Me._Label1_6)
        Me.Frame1.Controls.Add(Me._Label1_5)
        Me.Frame1.Controls.Add(Me._Label1_3)
        Me.Frame1.Controls.Add(Me._Label1_2)
        Me.Frame1.Controls.Add(Me._Label1_1)
        Me.Frame1.Controls.Add(Me._Label1_0)
        Me.Frame1.ForeColor = System.Drawing.Color.Yellow
        Me.Frame1.Location = New System.Drawing.Point(8, 192)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(172, 154)
        Me.Frame1.TabIndex = 33
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Scaling factors"
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(117, 90)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(46, 19)
        Me._Text1_4.TabIndex = 12
        Me._Text1_4.Text = "Text1"
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_6.Location = New System.Drawing.Point(117, 126)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(46, 19)
        Me._Text1_6.TabIndex = 14
        Me._Text1_6.Text = "Text1"
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(117, 108)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(46, 19)
        Me._Text1_5.TabIndex = 13
        Me._Text1_5.Text = "Text1"
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_3.Location = New System.Drawing.Point(117, 72)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(46, 19)
        Me._Text1_3.TabIndex = 11
        Me._Text1_3.Text = "Text1"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(117, 54)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(46, 19)
        Me._Text1_2.TabIndex = 10
        Me._Text1_2.Text = "Text1"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(117, 36)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(46, 19)
        Me._Text1_1.TabIndex = 9
        Me._Text1_1.Text = "Text1"
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(117, 18)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(46, 19)
        Me._Text1_0.TabIndex = 8
        Me._Text1_0.Text = "Text1"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(9, 90)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(136, 19)
        Me._Label1_4.TabIndex = 44
        Me._Label1_4.Text = "Rating   900 #"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(9, 126)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(136, 19)
        Me._Label1_6.TabIndex = 39
        Me._Label1_6.Text = "Rating 2500 #"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(9, 108)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(136, 19)
        Me._Label1_5.TabIndex = 38
        Me._Label1_5.Text = "Rating 1500 #"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(9, 72)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(136, 19)
        Me._Label1_3.TabIndex = 37
        Me._Label1_3.Text = "Rating   600 #"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(9, 54)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(136, 19)
        Me._Label1_2.TabIndex = 36
        Me._Label1_2.Text = "Rating   400 #"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(9, 36)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(136, 19)
        Me._Label1_1.TabIndex = 35
        Me._Label1_1.Text = "Rating   300 #"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(9, 18)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(136, 19)
        Me._Label1_0.TabIndex = 34
        Me._Label1_0.Text = "Rating   150 #"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Menu
        Me.Picture1.Controls.Add(Me._rtx_8)
        Me.Picture1.Controls.Add(Me._rtx_7)
        Me.Picture1.Controls.Add(Me._rtx_6)
        Me.Picture1.Controls.Add(Me._rtx_5)
        Me.Picture1.Controls.Add(Me._rtx_4)
        Me.Picture1.Controls.Add(Me._rtx_3)
        Me.Picture1.Controls.Add(Me._Text2_3)
        Me.Picture1.Controls.Add(Me._Text2_4)
        Me.Picture1.Controls.Add(Me._Text2_5)
        Me.Picture1.Controls.Add(Me._Text2_6)
        Me.Picture1.Controls.Add(Me._Text2_7)
        Me.Picture1.Controls.Add(Me._Text2_8)
        Me.Picture1.Controls.Add(Me._Label2_4)
        Me.Picture1.Controls.Add(Me._Label2_3)
        Me.Picture1.Controls.Add(Me._Label2_5)
        Me.Picture1.Controls.Add(Me._Label2_6)
        Me.Picture1.Controls.Add(Me._Label2_7)
        Me.Picture1.Controls.Add(Me._Label2_8)
        Me.Picture1.Controls.Add(Me._lblUni_3)
        Me.Picture1.Controls.Add(Me._lblUni_4)
        Me.Picture1.Controls.Add(Me._lblUni_5)
        Me.Picture1.Controls.Add(Me._lblUni_6)
        Me.Picture1.Controls.Add(Me._lblUni_7)
        Me.Picture1.Controls.Add(Me._lblUni_8)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Location = New System.Drawing.Point(8, 8)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(451, 118)
        Me.Picture1.TabIndex = 7
        Me.Picture1.TabStop = True
        '
        '_rtx_8
        '
        Me._rtx_8.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me._rtx_8.Location = New System.Drawing.Point(200, 90)
        Me._rtx_8.Name = "_rtx_8"
        Me._rtx_8.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_8.Size = New System.Drawing.Size(27, 19)
        Me._rtx_8.TabIndex = 38
        Me._rtx_8.Text = "RichTextBox6"
        '
        '_rtx_7
        '
        Me._rtx_7.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me._rtx_7.Location = New System.Drawing.Point(200, 72)
        Me._rtx_7.Name = "_rtx_7"
        Me._rtx_7.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_7.Size = New System.Drawing.Size(27, 19)
        Me._rtx_7.TabIndex = 37
        Me._rtx_7.Text = "RichTextBox5"
        '
        '_rtx_6
        '
        Me._rtx_6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me._rtx_6.Location = New System.Drawing.Point(200, 54)
        Me._rtx_6.Name = "_rtx_6"
        Me._rtx_6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_6.Size = New System.Drawing.Size(27, 19)
        Me._rtx_6.TabIndex = 36
        Me._rtx_6.Text = "RichTextBox4"
        '
        '_rtx_5
        '
        Me._rtx_5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me._rtx_5.Location = New System.Drawing.Point(200, 36)
        Me._rtx_5.Name = "_rtx_5"
        Me._rtx_5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_5.Size = New System.Drawing.Size(27, 19)
        Me._rtx_5.TabIndex = 35
        Me._rtx_5.Text = "RichTextBox3"
        '
        '_rtx_4
        '
        Me._rtx_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me._rtx_4.Location = New System.Drawing.Point(200, 18)
        Me._rtx_4.Name = "_rtx_4"
        Me._rtx_4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_4.Size = New System.Drawing.Size(27, 19)
        Me._rtx_4.TabIndex = 34
        Me._rtx_4.Text = "RichTextBox2"
        '
        '_rtx_3
        '
        Me._rtx_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me._rtx_3.Location = New System.Drawing.Point(200, 0)
        Me._rtx_3.Name = "_rtx_3"
        Me._rtx_3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_3.Size = New System.Drawing.Size(27, 19)
        Me._rtx_3.TabIndex = 33
        Me._rtx_3.Text = "RichTextBox1"
        '
        '_Text2_3
        '
        Me._Text2_3.AcceptsReturn = True
        Me._Text2_3.AutoSize = False
        Me._Text2_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_3.Location = New System.Drawing.Point(279, 0)
        Me._Text2_3.MaxLength = 0
        Me._Text2_3.Name = "_Text2_3"
        Me._Text2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_3.Size = New System.Drawing.Size(82, 19)
        Me._Text2_3.TabIndex = 1
        Me._Text2_3.Text = "Textg"
        '
        '_Text2_4
        '
        Me._Text2_4.AcceptsReturn = True
        Me._Text2_4.AutoSize = False
        Me._Text2_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_4.Location = New System.Drawing.Point(279, 18)
        Me._Text2_4.MaxLength = 0
        Me._Text2_4.Name = "_Text2_4"
        Me._Text2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_4.Size = New System.Drawing.Size(82, 19)
        Me._Text2_4.TabIndex = 2
        Me._Text2_4.Text = "Textg"
        '
        '_Text2_5
        '
        Me._Text2_5.AcceptsReturn = True
        Me._Text2_5.AutoSize = False
        Me._Text2_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_5.Location = New System.Drawing.Point(279, 36)
        Me._Text2_5.MaxLength = 0
        Me._Text2_5.Name = "_Text2_5"
        Me._Text2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_5.Size = New System.Drawing.Size(82, 19)
        Me._Text2_5.TabIndex = 3
        Me._Text2_5.Text = "Textg"
        '
        '_Text2_6
        '
        Me._Text2_6.AcceptsReturn = True
        Me._Text2_6.AutoSize = False
        Me._Text2_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_6.Location = New System.Drawing.Point(279, 54)
        Me._Text2_6.MaxLength = 0
        Me._Text2_6.Name = "_Text2_6"
        Me._Text2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_6.Size = New System.Drawing.Size(82, 19)
        Me._Text2_6.TabIndex = 4
        Me._Text2_6.Text = "Textg"
        '
        '_Text2_7
        '
        Me._Text2_7.AcceptsReturn = True
        Me._Text2_7.AutoSize = False
        Me._Text2_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_7.Location = New System.Drawing.Point(279, 72)
        Me._Text2_7.MaxLength = 0
        Me._Text2_7.Name = "_Text2_7"
        Me._Text2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_7.Size = New System.Drawing.Size(82, 19)
        Me._Text2_7.TabIndex = 5
        Me._Text2_7.Text = "Textg"
        '
        '_Text2_8
        '
        Me._Text2_8.AcceptsReturn = True
        Me._Text2_8.AutoSize = False
        Me._Text2_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_8.Location = New System.Drawing.Point(279, 90)
        Me._Text2_8.MaxLength = 0
        Me._Text2_8.Name = "_Text2_8"
        Me._Text2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_8.Size = New System.Drawing.Size(82, 19)
        Me._Text2_8.TabIndex = 6
        Me._Text2_8.Text = "Textg"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(0, 18)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(199, 19)
        Me._Label2_4.TabIndex = 32
        Me._Label2_4.Text = "Label1"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(0, 0)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(199, 19)
        Me._Label2_3.TabIndex = 31
        Me._Label2_3.Text = "Label1"
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(0, 36)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(199, 19)
        Me._Label2_5.TabIndex = 30
        Me._Label2_5.Text = "Label1"
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_6.Location = New System.Drawing.Point(0, 54)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(199, 19)
        Me._Label2_6.TabIndex = 29
        Me._Label2_6.Text = "Label1"
        '
        '_Label2_7
        '
        Me._Label2_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_7.Location = New System.Drawing.Point(0, 72)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(199, 19)
        Me._Label2_7.TabIndex = 28
        Me._Label2_7.Text = "Label1"
        '
        '_Label2_8
        '
        Me._Label2_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_8.Location = New System.Drawing.Point(0, 90)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(199, 19)
        Me._Label2_8.TabIndex = 27
        Me._Label2_8.Text = "Label1"
        '
        '_lblUni_3
        '
        Me._lblUni_3.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_3.Location = New System.Drawing.Point(405, 0)
        Me._lblUni_3.Name = "_lblUni_3"
        Me._lblUni_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_3.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_3.TabIndex = 26
        Me._lblUni_3.Text = "Label2"
        Me._lblUni_3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_4
        '
        Me._lblUni_4.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_4.Location = New System.Drawing.Point(405, 18)
        Me._lblUni_4.Name = "_lblUni_4"
        Me._lblUni_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_4.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_4.TabIndex = 25
        Me._lblUni_4.Text = "Label2"
        Me._lblUni_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_5
        '
        Me._lblUni_5.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_5.Location = New System.Drawing.Point(405, 36)
        Me._lblUni_5.Name = "_lblUni_5"
        Me._lblUni_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_5.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_5.TabIndex = 24
        Me._lblUni_5.Text = "Label2"
        Me._lblUni_5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_6
        '
        Me._lblUni_6.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_6.Location = New System.Drawing.Point(405, 54)
        Me._lblUni_6.Name = "_lblUni_6"
        Me._lblUni_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_6.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_6.TabIndex = 23
        Me._lblUni_6.Text = "Label2"
        Me._lblUni_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_7
        '
        Me._lblUni_7.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_7.Location = New System.Drawing.Point(405, 72)
        Me._lblUni_7.Name = "_lblUni_7"
        Me._lblUni_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_7.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_7.TabIndex = 22
        Me._lblUni_7.Text = "Label2"
        Me._lblUni_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_8
        '
        Me._lblUni_8.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_8.Location = New System.Drawing.Point(405, 90)
        Me._lblUni_8.Name = "_lblUni_8"
        Me._lblUni_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_8.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_8.TabIndex = 21
        Me._lblUni_8.Text = "Label2"
        Me._lblUni_8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabStrip1
        '
        Me.TabStrip1.Controls.Add(Me.TabPage1)
        Me.TabStrip1.Location = New System.Drawing.Point(8, 8)
        Me.TabStrip1.Name = "TabStrip1"
        Me.TabStrip1.SelectedIndex = 0
        Me.TabStrip1.Size = New System.Drawing.Size(472, 152)
        Me.TabStrip1.TabIndex = 51
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Picture1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(464, 126)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'frmLib
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(488, 352)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabStrip1)
        Me.Controls.Add(Me.Command7)
        Me.Controls.Add(Me.Command6)
        Me.Controls.Add(Me.Command5)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Codici)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmLib"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Librerie di carichi standard"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Picture1.ResumeLayout(False)
        Me.TabStrip1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmLib
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmLib
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmLib()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private ModifiedData As Boolean
    Private iAct As Short
    Private Inizializzando As Boolean
    Private Sub Codici_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Codici.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            TabStrip1.SelectedTab.Text = "DN" & Str(Val(Codici.Text))
            Codici.Visible = False
            ModifiedData = True
        End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        If ModifiedData Then
            If MsgBox("Vuoi salvare i dati modificati?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then SuperRegist()
        End If
        ModifiedData = False
        Carta = ExtLoads(Combo1.SelectedIndex + 2, Csv)
        LeggiSt()
        AggTabs()
        TabStrip1.SelectedTab = TabStrip1.TabPages(0)
        AggFactor()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        If ModifiedData Then
            If MsgBox("Vuoi salvare i dati modificati?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then SuperRegist()
        End If
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click 'inserimento nuovo standard
        Dim Stringa(2) As String
        Dim Risult(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        Dim NumNuovo As Short
        Dim ifl1, ifl, ik As Short
        Dim StrNum, Riga As String
        Dim Num(99) As Short
        Dim i As Short
        Stringa(1) = "Identificazione dello standard"
        Risult(1) = Space(20)
Rif:    Stringa(2) = "Numero di NPS considerati"
        Risult(2) = " 20"
        If Not Monitor.Motore.InputDati(2, "Nuovo standard", Stringa, Risult, "", Arch, dAiu) Then Exit Sub
        Carta = Risult(1)
        kk = GlobaLroutines.ValVir(Risult(2))
        If kk > 30 Then
            MsgBox("Il numero massimo di NPS ammessi è 30", MsgBoxStyle.Information)
            kk = 30
            GoTo Rif
        End If
        ifl = FreeFile()
210:    FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\INDIR.DAT", OpenMode.Input, , OpenShare.Shared)
        ifl1 = FreeFile()
220:    FileOpen(ifl1, RTrim(Monitor.clsInizio.Archdir) & "\WR\INDI1.DAT", OpenMode.Output)
        ik = 0
        Do
            ik = ik + 1
230:        Riga = LineInput(ifl)
            If VB.Left(Riga, 1) = "," Then
                Call SortNum(Num, ik)
                NumNuovo = ik - 1
                For i = 1 To ik
                    If Num(i) > i - 1 Then
                        NumNuovo = i - 1
                        Exit For
                    End If
                Next
                StrNum = Str(NumNuovo)
                If ik < 10 Then StrNum = "0" & LTrim(StrNum) Else StrNum = LTrim(StrNum)
                Csv = "NOZZ" & StrNum & ".CSV"
                PrintLine(ifl1, Carta & "," & Csv)
                PrintLine(ifl1, ",")
                Exit Do
            Else
                PrintLine(ifl1, Riga)
                Riga = VB.Right(Riga, Len(Riga) - InStr(Riga, ",") - 4)
                Num(ik) = GlobaLroutines.ValVir(Riga)
            End If
        Loop
        FileClose(ifl) : FileClose(ifl1)
        FileCopy(RTrim(Monitor.clsInizio.Archdir) & "\WR\INDI1.DAT", RTrim(Monitor.clsInizio.Archdir) & "\WR\INDIR.DAT")
        Azzera()
        Regist()
        AggCombo()
        Combo1.SelectedIndex = ik - 2
        Exit Sub
    End Sub
    Private Sub SortNum(ByVal Num() As Short, ByVal ik As Short)
        Dim i, j As Integer
        For i = 1 To ik - 1
            For j = i + 1 To ik
                If Num(i) > Num(j) Then globalRoutines.SWAP(Num(i), Num(j))
            Next
        Next
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        SuperRegist()
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click 'elimina standard attivo
        Dim ifl1, ifl, ik As Short
        Dim i As Short
        Dim Riga As String
        Kill(RTrim(Monitor.clsInizio.Archdir) & "\WR\" & Csv)
        ik = Combo1.SelectedIndex + 2
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\INDIR.DAT", OpenMode.Input, , OpenShare.Shared)
        ifl1 = FreeFile()
        FileOpen(ifl1, RTrim(Monitor.clsInizio.Archdir) & "\WR\INDI1.DAT", OpenMode.Output)
        i = 0
        Do
            i = i + 1
            Riga = LineInput(ifl)
            If VB.Left(Riga, 1) = "," Then
                PrintLine(ifl1, Riga)
                Exit Do
            Else
                If i <> ik Then PrintLine(ifl1, Riga)
            End If
        Loop
        FileClose(ifl, ifl1)
        FileCopy(RTrim(Monitor.clsInizio.Archdir) & "\WR\INDI1.DAT", RTrim(Monitor.clsInizio.Archdir) & "\WR\INDIR.DAT")
        AggCombo()
        ik = ik - 1
        If ik <= 1 Then ik = 2
        Combo1.SelectedIndex = ik - 2
    End Sub

    Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click 'elimina scheda
        Dim i, j As Short
        kk = kk - 1
        For i = iAct To kk
            DN(i) = DN(i + 1)
            For j = 1 To 6
                Valor(j, i) = Valor(j, i + 1)
            Next
        Next
        Regist()
        ModifiedData = False
        Combo1_SelectedIndexChanged(Combo1, New System.EventArgs)
        TabStrip1.SelectedIndex = iAct - 1
    End Sub

    Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click 'inserisci scheda
        Dim i, j As Short
        If kk = 30 Then Exit Sub
        kk = kk + 1
        For i = kk To iAct + 1 Step -1
            DN(i) = DN(i - 1)
            For j = 1 To 6
                Valor(j, i) = Valor(j, i - 1)
            Next
        Next
        If iAct > 1 Then
            DN(iAct) = CStr(CDbl(DN(iAct - 1) & DN(iAct)) / 2)
        Else
            DN(iAct) = CStr(CDbl(DN(iAct)) / 2)
        End If
        For j = 1 To 6
            Valor(j, iAct) = 0
        Next
        Regist()
        ModifiedData = False
        Combo1_SelectedIndexChanged(Combo1, New System.EventArgs)
        TabStrip1.SelectedIndex = iAct - 1
    End Sub

    Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click
        Dim j As Short
        If kk = 30 Then Exit Sub
        kk = kk + 1
        DN(kk) = CStr(2 * CDbl(DN(kk - 1)))
        For j = 1 To 6
            Valor(j, kk) = 0
        Next
        Regist()
        ModifiedData = False
        Combo1_SelectedIndexChanged(Combo1, New System.EventArgs)
        TabStrip1.SelectedIndex = kk - 1 ' TabStrip1.Tabs(kk)
    End Sub

    Private Sub frmLib_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Aggiorna()
        AggCombo()
        Combo1.SelectedIndex = 0
    End Sub

    Private Sub Aggiorna()
        Label2(3).Text = "Radial Load"
        lblUni(3).Text = Config.Unit(3)
        rtx(3).Rtf = "{\rtf {\fs16  P}}"
        Label2(5).Text = "Bending Moment (Long.Dir.) "
        lblUni(5).Text = Config.Unit(2)
        rtx(5).Rtf = "{\rtf {\fs16  M\sub L}}"
        Label2(4).Text = "Bending Moment"
        lblUni(4).Text = Config.Unit(2)
        rtx(4).Rtf = "{\rtf {\fs16  M}}"
        Label2(6).Text = "Torsional Moment"
        lblUni(6).Text = Config.Unit(2)
        rtx(6).Rtf = "{\rtf {\fs16  M\sub t}}"
        Label2(7).Text = "Shear Load"
        lblUni(7).Text = Config.Unit(3)
        rtx(7).Rtf = "{\rtf {\fs16  V}}"
        Label2(8).Text = "Shear Load    (Long.Dir.)  "
        lblUni(8).Text = Config.Unit(3)
        rtx(8).Rtf = "{\rtf {\fs16  V\sub L}}"
    End Sub
    Private Sub AggCombo()
        Dim k, k1 As Short
        Dim Testo As String
        k = 2
        Combo1.Items.Clear()
        Do
            k1 = k
200:        Testo = ExtLoads(k1, Csv)
            If k1 = 1 Or VB.Left(Testo, 1) = "." Then Exit Do
            Combo1.Items.Add(Testo)
            k = k + 1
        Loop
    End Sub


    Private Sub AggTabs()
        Dim i As Short
        TabStrip1.TabPages.Clear()
        For i = 1 To kk
            TabStrip1.TabPages.Add(New TabPage("DN" & Str(CDbl(DN(i)))))
        Next

    End Sub

    Private Sub TabStrip1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TabStrip1.Click
        iAct = TabStrip1.SelectedIndex + 1
        AggTesti()
    End Sub

    Private Sub AggTesti()
        Dim i As Short
        For i = 1 To 6
            Text2(i + 2).Text = globalRoutines.myStr(Valor(i, iAct), 10, 2, False)
        Next
    End Sub
    Private Sub Text1_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Factor(Index + 1) = GlobaLroutines.ValVir(Text1(Index).Text)
        ModifiedData = True
    End Sub
    Private ReadOnly Property Text1(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _Text1_0
                Case 1 : Return _Text1_1
                Case 2 : Return _Text1_2
                Case 3 : Return _Text1_3
                Case 4 : Return _Text1_4
                Case 5 : Return _Text1_5
                Case 6 : Return _Text1_6
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
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Text2_TextChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        Valor(Index - 2, iAct) = GlobaLroutines.ValVir(Text2(Index).Text)
        ModifiedData = True
    End Sub
    Private ReadOnly Property Text2(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 3 : Return _Text2_3
                Case 4 : Return _Text2_4
                Case 5 : Return _Text2_5
                Case 6 : Return _Text2_6
                Case 7 : Return _Text2_7
                Case 8 : Return _Text2_8
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Label2(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 3 : Return _Label2_3
                Case 4 : Return _Label2_4
                Case 5 : Return _Label2_5
                Case 6 : Return _Label2_6
                Case 7 : Return _Label2_7
                Case 8 : Return _Label2_8
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property lblUni(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 3 : Return _lblUni_3
                Case 4 : Return _lblUni_4
                Case 5 : Return _lblUni_5
                Case 6 : Return _lblUni_6
                Case 7 : Return _lblUni_7
                Case 8 : Return _lblUni_8
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub AggFactor()
        Dim i As Short
        For i = 0 To 6
            Text1(i).Text = globalRoutines.myStr(Factor(i + 1), 2, 3, False)
        Next
    End Sub

    Private Sub Regist()
        Dim ifl, ik As Short
        If kk < 1 Then Exit Sub
        ifl = FreeFile()
270:    FileOpen(ifl, RTrim(Monitor.clsInizio.Archdir) & "\WR\" & Csv, OpenMode.Output, , OpenShare.Shared)
        PrintLine(ifl, Carta)
        PrintLine(ifl, "  DN,       Fa,       Vl,       Vc,       Ml,       Mc,       Mt")
        For ik = 1 To kk
280:        PrintLine(ifl, globalRoutines.FormatS("\  \_,#########_,#########_,#########_,#.###^^^^_,#.###^^^^_,#.###^^^^", DN(ik), Valor(1, ik), Valor(6, ik), Valor(5, ik), Valor(3, ik), Valor(2, ik), Valor(4, ik)))
        Next ik
290:    PrintLine(ifl, globalRoutines.FormatS("\  \_,#########_,#########_,#########_,#.###^^^^_,#.###^^^^_,#.###^^^^", "    ", Valor(1, kk), Valor(2, kk), Valor(3, kk), Valor(4, kk), Valor(5, kk), Valor(6, kk)))
291:    PrintLine(ifl, "ASA   ,  150,  300,  400,  600,  900, 1500, 2500")
292:    PrintLine(ifl, globalRoutines.FormatS("Bvalue_,#.###_,#.###_,#.###_,#.###_,#.###_,#.###_,#.###", Factor(1), Factor(2), Factor(3), Factor(4), Factor(5), Factor(6), Factor(7)))
        FileClose(ifl)
    End Sub

    Private Sub Azzera()
        Dim i, j As Short
        For i = 1 To kk
            For j = 1 To 6
                Valor(j, i) = 0
            Next
            DN(i) = Str(i)
        Next
        For i = 1 To 7
            Factor(i) = 1
        Next
    End Sub
    Private Sub SuperRegist()
        Dim i As Short
        Dim Testo As String
        For i = 1 To kk
            Testo = TabStrip1.TabPages(i - 1).Text
            Testo = VB.Right(Testo, Len(Testo) - 2)
            DN(i) = CStr(Val(Testo))
        Next
        Regist()
        ModifiedData = False
    End Sub
    Private ReadOnly Property rtx(ByVal i As Integer) As RichTextBox
        Get
            Select Case i
                Case 3 : Return _rtx_3
                Case 4 : Return _rtx_4
                Case 5 : Return _rtx_5
                Case 6 : Return _rtx_6
                Case 7 : Return _rtx_7
                Case 8 : Return _rtx_8
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub TabStrip1_MouseUp(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.MouseEventArgs) Handles TabStrip1.MouseUp
        If EventArgs.Button = System.Windows.Forms.MouseButtons.Left Then Exit Sub 'era 1
        Dim Index As Short
        Dim T As New TabPage
        Index = -1
        For Each T In TabStrip1.TabPages
            If (EventArgs.X - (T.Left - TabStrip1.Left)) * (EventArgs.X - (T.Left + T.Width - TabStrip1.Left)) < 0 _
            And (EventArgs.Y - (T.Top - TabStrip1.Top)) * (EventArgs.Y - (T.Top + T.Height - TabStrip1.Top)) < 0 Then
                T.Select()
                Index = TabStrip1.SelectedIndex
                Exit For
            End If
        Next T
        If Index < 0 Then Exit Sub
        Codici.Top = T.Top
        Codici.Height = T.Height
        Codici.Left = T.Left
        Codici.Width = T.Width
        Codici.Text = T.Text.Substring(T.Text.Length - 4)
        Codici.Visible = True
        Codici.SelectionLength = Len(Codici.Text)
        Codici.Focus()
    End Sub

    Private Sub _Text1_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_0.TextChanged
        Text1_TextChanged(0)
    End Sub

    Private Sub _Text1_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_1.TextChanged
        Text1_TextChanged(1)
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

    Private Sub _Text2_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_3.TextChanged
        Text2_TextChanged(3)
    End Sub

    Private Sub _Text2_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_4.TextChanged
        Text2_TextChanged(4)
    End Sub

    Private Sub _Text2_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_5.TextChanged
        Text2_TextChanged(5)
    End Sub

    Private Sub _Text2_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_6.TextChanged
        Text2_TextChanged(6)
    End Sub

    Private Sub _Text2_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_7.TextChanged
        Text2_TextChanged(7)
    End Sub

    Private Sub _Text2_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_8.TextChanged
        Text2_TextChanged(8)
    End Sub
End Class