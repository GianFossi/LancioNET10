Option Strict Off
Option Explicit On
Friend Class frmDatiPart
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
        Inizializza()
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
	Public WithEvents Combo2 As System.Windows.Forms.ComboBox
	Public WithEvents Text9 As System.Windows.Forms.TextBox
	Public WithEvents Combo1 As System.Windows.Forms.ComboBox
	Public WithEvents Text10 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Text8 As System.Windows.Forms.TextBox
    Public WithEvents Text7 As System.Windows.Forms.TextBox
	Public WithEvents Text6 As System.Windows.Forms.TextBox
	Public WithEvents Text5 As System.Windows.Forms.TextBox
	Public WithEvents Text4 As System.Windows.Forms.TextBox
	Public WithEvents Text3 As System.Windows.Forms.TextBox
	Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
	Public WithEvents _Label1_9 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
	Public WithEvents _Label2_6 As System.Windows.Forms.Label
	Public WithEvents _Label2_5 As System.Windows.Forms.Label
	Public WithEvents _Label2_4 As System.Windows.Forms.Label
	Public WithEvents _Label2_3 As System.Windows.Forms.Label
	Public WithEvents _Label2_2 As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents _Label1_7 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDatiPart))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me.Combo2 = New System.Windows.Forms.ComboBox
        Me.Text9 = New System.Windows.Forms.TextBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Text10 = New System.Windows.Forms.TextBox
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me.Command4 = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me.Text8 = New System.Windows.Forms.TextBox
        Me.Text7 = New System.Windows.Forms.TextBox
        Me.Text6 = New System.Windows.Forms.TextBox
        Me.Text5 = New System.Windows.Forms.TextBox
        Me.Text4 = New System.Windows.Forms.TextBox
        Me.Text3 = New System.Windows.Forms.TextBox
        Me.Text2 = New System.Windows.Forms.TextBox
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(288, 96)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 30
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_5, "Riporta il valore definito per l'apparecchio")
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(272, 24)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciato.TabIndex = 99
        Me.chkAgganciato.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'Combo2
        '
        Me.Combo2.BackColor = System.Drawing.SystemColors.Window
        Me.Combo2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo2.Location = New System.Drawing.Point(136, 48)
        Me.Combo2.Name = "Combo2"
        Me.Combo2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo2.Size = New System.Drawing.Size(81, 21)
        Me.Combo2.TabIndex = 37
        '
        'Text9
        '
        Me.Text9.AcceptsReturn = True
        Me.Text9.AutoSize = False
        Me.Text9.BackColor = System.Drawing.SystemColors.Window
        Me.Text9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text9.Location = New System.Drawing.Point(136, 264)
        Me.Text9.MaxLength = 0
        Me.Text9.Name = "Text9"
        Me.Text9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text9.Size = New System.Drawing.Size(81, 19)
        Me.Text9.TabIndex = 35
        Me.Text9.Text = "0"
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(136, 240)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(169, 21)
        Me.Combo1.TabIndex = 33
        '
        'Text10
        '
        Me.Text10.AcceptsReturn = True
        Me.Text10.AutoSize = False
        Me.Text10.BackColor = System.Drawing.SystemColors.Window
        Me.Text10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text10.Location = New System.Drawing.Point(136, 0)
        Me.Text10.MaxLength = 0
        Me.Text10.Name = "Text10"
        Me.Text10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text10.Size = New System.Drawing.Size(177, 19)
        Me.Text10.TabIndex = 32
        Me.Text10.Text = ""
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(288, 120)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 29
        Me._cmdCil_1.TabStop = False
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(248, 24)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 28
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(285, 320)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(44, 25)
        Me.Command4.TabIndex = 27
        Me.Command4.TabStop = False
        Me.Command4.Text = "OK"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(232, 320)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(48, 25)
        Me.Command3.TabIndex = 26
        Me.Command3.TabStop = False
        Me.Command3.Text = "Cancel"
        '
        'Text8
        '
        Me.Text8.AcceptsReturn = True
        Me.Text8.AutoSize = False
        Me.Text8.BackColor = System.Drawing.SystemColors.Window
        Me.Text8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text8.Location = New System.Drawing.Point(136, 216)
        Me.Text8.MaxLength = 0
        Me.Text8.Name = "Text8"
        Me.Text8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text8.Size = New System.Drawing.Size(81, 19)
        Me.Text8.TabIndex = 25
        Me.Text8.Text = "0"
        '
        'Text7
        '
        Me.Text7.AcceptsReturn = True
        Me.Text7.AutoSize = False
        Me.Text7.BackColor = System.Drawing.SystemColors.Window
        Me.Text7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text7.Location = New System.Drawing.Point(136, 192)
        Me.Text7.MaxLength = 0
        Me.Text7.Name = "Text7"
        Me.Text7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text7.Size = New System.Drawing.Size(81, 19)
        Me.Text7.TabIndex = 15
        Me.Text7.Text = "0"
        '
        'Text6
        '
        Me.Text6.AcceptsReturn = True
        Me.Text6.AutoSize = False
        Me.Text6.BackColor = System.Drawing.SystemColors.Window
        Me.Text6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text6.Location = New System.Drawing.Point(136, 168)
        Me.Text6.MaxLength = 0
        Me.Text6.Name = "Text6"
        Me.Text6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text6.Size = New System.Drawing.Size(81, 19)
        Me.Text6.TabIndex = 14
        Me.Text6.Text = "0"
        '
        'Text5
        '
        Me.Text5.AcceptsReturn = True
        Me.Text5.AutoSize = False
        Me.Text5.BackColor = System.Drawing.SystemColors.Window
        Me.Text5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text5.Location = New System.Drawing.Point(136, 144)
        Me.Text5.MaxLength = 0
        Me.Text5.Name = "Text5"
        Me.Text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text5.Size = New System.Drawing.Size(81, 19)
        Me.Text5.TabIndex = 13
        Me.Text5.Text = "0"
        '
        'Text4
        '
        Me.Text4.AcceptsReturn = True
        Me.Text4.AutoSize = False
        Me.Text4.BackColor = System.Drawing.SystemColors.Window
        Me.Text4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text4.Location = New System.Drawing.Point(136, 120)
        Me.Text4.MaxLength = 0
        Me.Text4.Name = "Text4"
        Me.Text4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text4.Size = New System.Drawing.Size(81, 19)
        Me.Text4.TabIndex = 12
        Me.Text4.Text = "0"
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.AutoSize = False
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(136, 96)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(81, 19)
        Me.Text3.TabIndex = 11
        Me.Text3.Text = "0"
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.AutoSize = False
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(136, 72)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(81, 19)
        Me.Text2.TabIndex = 10
        Me.Text2.Text = "0"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(8, 48)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(121, 17)
        Me._Label1_10.TabIndex = 36
        Me._Label1_10.Text = "Type of material"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(8, 264)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(121, 17)
        Me._Label1_9.TabIndex = 34
        Me._Label1_9.Text = "Adopted Thickness : "
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 4)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 31
        Me._LabelCil_0.Text = "Member identification"
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_6.Location = New System.Drawing.Point(224, 216)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(41, 17)
        Me._Label2_6.TabIndex = 22
        Me._Label2_6.Text = "Label2"
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(224, 192)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(41, 17)
        Me._Label2_5.TabIndex = 21
        Me._Label2_5.Text = "Label2"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(224, 168)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(41, 17)
        Me._Label2_4.TabIndex = 20
        Me._Label2_4.Text = "Label2"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(224, 144)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(41, 17)
        Me._Label2_3.TabIndex = 19
        Me._Label2_3.Text = "Label2"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(224, 120)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(41, 17)
        Me._Label2_2.TabIndex = 18
        Me._Label2_2.Text = "Label2"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(224, 96)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(41, 17)
        Me._Label2_1.TabIndex = 17
        Me._Label2_1.Text = "Label2"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(224, 72)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(41, 17)
        Me._Label2_0.TabIndex = 16
        Me._Label2_0.Text = "Label2"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(8, 240)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(121, 17)
        Me._Label1_8.TabIndex = 8
        Me._Label1_8.Text = "Pass Partition Type : "
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(8, 216)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(121, 17)
        Me._Label1_7.TabIndex = 7
        Me._Label1_7.Text = "Length in transverse dir."
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(8, 192)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(121, 17)
        Me._Label1_6.TabIndex = 6
        Me._Label1_6.Text = "Length in longitud. dir. "
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(8, 168)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(121, 17)
        Me._Label1_5.TabIndex = 5
        Me._Label1_5.Text = "Shell Diameter"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(8, 96)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(128, 17)
        Me._Label1_2.TabIndex = 4
        Me._Label1_2.Text = "Design Temperature   T ="
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(8, 144)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(121, 17)
        Me._Label1_4.TabIndex = 3
        Me._Label1_4.Text = "Corrosion                    c ="
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(8, 120)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(136, 17)
        Me._Label1_3.TabIndex = 2
        Me._Label1_3.Text = "Allowable Stress         S"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(8, 72)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(121, 17)
        Me._Label1_1.TabIndex = 1
        Me._Label1_1.Text = "Design Pressure         q = "
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Label1_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._Label1_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._Label1_0.Location = New System.Drawing.Point(8, 24)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Label1_0, True)
        Me._Label1_0.Size = New System.Drawing.Size(121, 17)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "Materiale :"
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.Location = New System.Drawing.Point(136, 24)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(112, 21)
        Me.cmbMat.TabIndex = 100
        '
        'frmDatiPart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(334, 351)
        Me.Controls.Add(Me.cmbMat)
        Me.Controls.Add(Me.chkAgganciato)
        Me.Controls.Add(Me.Combo2)
        Me.Controls.Add(Me.Text9)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Text10)
        Me.Controls.Add(Me._cmdCil_5)
        Me.Controls.Add(Me._cmdCil_1)
        Me.Controls.Add(Me._cmdCil_0)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Text8)
        Me.Controls.Add(Me.Text7)
        Me.Controls.Add(Me.Text6)
        Me.Controls.Add(Me.Text5)
        Me.Controls.Add(Me.Text4)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me._Label1_10)
        Me.Controls.Add(Me._Label1_9)
        Me.Controls.Add(Me._LabelCil_0)
        Me.Controls.Add(Me._Label2_6)
        Me.Controls.Add(Me._Label2_5)
        Me.Controls.Add(Me._Label2_4)
        Me.Controls.Add(Me._Label2_3)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me._Label1_8)
        Me.Controls.Add(Me._Label1_7)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDatiPart"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dati Setti Partitori"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmDatiPart
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmDatiPart
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmDatiPart()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public Cancel, Inizializzando As Boolean
	Private virgola As Boolean
	Private objPart As wn_Part
	Private Sub aggiorna_label()
        With objPart
            Select Case Config(0).US
                Case 0
                    _Label2_0.Text = "Mpa"
                    _Label2_1.Text = "°C"
                    _Label2_2.Text = "Mpa"
                    _Label2_3.Text = "mm"
                    _Label2_4.Text = "mm"
                    _Label2_5.Text = "mm"
                    _Label2_6.Text = "mm"
                Case 1
                    _Label2_0.Text = "psi"
                    _Label2_1.Text = "°F"
                    _Label2_2.Text = "psi"
                    _Label2_3.Text = "mm"
                    _Label2_4.Text = "mm"
                    _Label2_5.Text = "mm"
                    _Label2_6.Text = "mm"
                Case 2
                    _Label2_0.Text = "psi"
                    _Label2_1.Text = "°F"
                    _Label2_2.Text = "psi"
                    _Label2_3.Text = "in"
                    _Label2_4.Text = "in"
                    _Label2_5.Text = "in"
                    _Label2_6.Text = "in"
            End Select
        End With
	End Sub
    Private Sub SubAmm()
        Dim s As Single
        Call Ammiss(jInvolucr)
        s = Involucr(kLato, jInvolucr).St
        Text4.Text = GlobalRoutines.myStr(s * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        objPart.TreLati = Combo1.SelectedIndex = 0
    End Sub
    Private Sub Combo2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo2.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        objPart.tipo_Materiale = Combo2.SelectedIndex
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Cancel = True
        Hide()
    End Sub
    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        'With objPart
        '.design_pressure = .design_pressure / kPress
        '.design_Temperature = (.design_Temperature - kTemp32) / kTemp
        '.allowable_stress = .allowable_stress / kPress
        '.corrosion = .corrosion / kLength
        '.Shell_Diameter = .Shell_Diameter / kLength
        '.dimensione_a = .dimensione_a / kLength
        '.dimensione_b = .dimensione_b / kLength
        'End With
        Cancel = False
        Hide()
    End Sub
    Private Sub Inizializza()
        Dim t As Single
        Popola(cmbMat)
        objPart = objMemb(Involucr(kLato, jInvolucr).IndObject)
        With objPart
            Combo1.Items.Add("Three Sides Fixed")
            Combo1.Items.Add("Two Sides Fixed")
            Combo2.Items.Add("Carbon Steel")
            Combo2.Items.Add("Alloy Material")
            'Se il valore di B è stato scelto dalla tabella
            'allora non sono siposnibili i valori di a e b
            'quindi le relative TextBox vengono disabilitate
            Combo2.SelectedIndex = .tipo_Materiale
            Text10.Text = Involucr(kLato, jInvolucr).Mark.Trim
            cmbMat.Text = .Materiale.Trim
            chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
            Text2.Text = GlobalRoutines.myStr(.design_pressure * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            If .design_Temperature = 0 Then
                t = TempDes()
                .design_Temperature = t
            End If
            Text3.Text = GlobalRoutines.myStr(.design_Temperature * kTemp + kTemp32, 3, 2, 0)
            Text4.Text = GlobalRoutines.myStr(.allowable_stress * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Text5.Text = GlobalRoutines.myStr(.corrosion * kLength, 1, 3 - IncrVirgola, 0)
            Text6.Text = GlobalRoutines.myStr(.Shell_Diameter * kLength, 4, 3 - IncrVirgola, 0)
            Text7.Text = GlobalRoutines.myStr(.longdim * kLength, 4, 3 - IncrVirgola, 0)
            Text8.Text = GlobalRoutines.myStr(.transvdim * kLength, 4, 3 - IncrVirgola, 0)
            Text9.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Spess, 3, 3 - IncrVirgola, False)
            'AggCase()
        End With
        AggCase()
        aggiorna_label()
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        objPart.Materiale = cmbMat.Text.Trim
    End Sub
    Private Sub Text10_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text10.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Mark = Text10.Text
    End Sub
    Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
        If Inizializzando Then Exit Sub
        If Text2.Text <> "" And lettere((Text2.Text)) = False Then
            objPart.design_pressure = GlobalRoutines.ValVir(Text2.Text) / kPress
        Else
            objPart.design_pressure = 0
            Text2.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text2.SelectionStart = 0
            Text2.SelectionLength = Len(Text2.Text)
        End If
    End Sub
    Private Sub Text2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        'Se viene premuto un tasto e il colore dello sfondo della Textbox è rosso allora
        'vuol dire che ci troviamo in una situazione di
        'errore.
        If Text2.BackColor.Equals(System.Drawing.Color.Red) Then Text2.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub Text2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii < Asc("0") And KeyAscii > Asc("9") Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Text2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.Leave
        If Text2.Text = "" Then Text2.Text = "0"
    End Sub
    Private Sub Text3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.TextChanged
        If Inizializzando Then Exit Sub
        If Text3.Text <> "" And lettere((Text3.Text)) = False Then
            objPart.design_Temperature = GlobalRoutines.ValVir(Text3.Text)
        Else
            objPart.design_Temperature = 0
            Text3.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text3.SelectionStart = 0
            Text3.SelectionLength = Len(Text3.Text)
        End If
    End Sub
    Private Sub Text3_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text3.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Text3.BackColor.Equals(System.Drawing.Color.Red) Then Text3.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub Text3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.Leave
        If Text3.Text = "" Then Text3.Text = "0"
    End Sub
    Private Sub Text4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text4.TextChanged
        If Inizializzando Then Exit Sub
        If Text4.Text <> "" And lettere((Text4.Text)) = False Then
            objPart.allowable_stress = GlobalRoutines.ValVir(Text4.Text)
        Else
            objPart.allowable_stress = 0
            Text4.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text4.SelectionStart = 0
            Text4.SelectionLength = Len(Text4.Text)
        End If
    End Sub
    Private Sub Text4_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text4.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If System.Drawing.ColorTranslator.ToOle(Text4.BackColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then Text4.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub Text4_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text4.Leave
        If Text4.Text = "" Then Text4.Text = "0"
    End Sub
    Private Sub Text5_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text5.TextChanged
        If Inizializzando Then Exit Sub
        If Text5.Text <> "" And lettere((Text5.Text)) = False Then
            objPart.corrosion = GlobalRoutines.ValVir(Text5.Text)
        Else
            objPart.corrosion = 0
            Text5.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text5.SelectionStart = 0
            Text5.SelectionLength = Len(Text5.Text)
        End If
    End Sub
    Private Sub Text5_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text5.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Text5.BackColor.Equals(System.Drawing.Color.Red) Then Text5.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub Text5_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text5.Leave
        If Text5.Text = "" Then Text5.Text = "0"
    End Sub
    Private Sub Text6_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text6.TextChanged
        If Inizializzando Then Exit Sub
        If Text6.Text <> "" And lettere((Text6.Text)) = False Then
            objPart.Shell_Diameter = GlobalRoutines.ValVir(Text6.Text)
        Else
            objPart.Shell_Diameter = 0
            Text6.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text6.SelectionStart = 0
            Text6.SelectionLength = Len(Text6.Text)
        End If
    End Sub
    Private Sub Text6_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text6.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Text6.BackColor.Equals(System.Drawing.Color.Red) Then Text6.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub Text6_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text6.Leave
        If Text6.Text = "" Then Text6.Text = "0"
    End Sub
    Private Sub Text7_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text7.TextChanged
        If Inizializzando Then Exit Sub
        If lettere((Text7.Text)) = False Then
            objPart.longdim = GlobalRoutines.ValVir(Val(Text7.Text))
        Else
            Text7.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text7.SelectionStart = 0
            Text7.SelectionLength = Len(Text7.Text)
        End If
    End Sub
    Private Sub Text7_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text7.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Text7.BackColor.Equals(System.Drawing.Color.Red) Then Text7.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub Text8_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text8.TextChanged
        If Inizializzando Then Exit Sub
        If lettere((Text8.Text)) = False Then
            objPart.transvdim = GlobalRoutines.ValVir(Val(Text8.Text))
        Else
            Text8.BackColor = System.Drawing.Color.Red
            'messagebox.show "Valore Inserito non valido", vbExclamation, "Pass Partition "
            Text8.SelectionStart = 0
            Text8.SelectionLength = Len(Text8.Text)
        End If
    End Sub
    Private Function lettere(ByRef St As String) As Boolean
        Dim i As Short
        Dim ch As Short
        Dim lett As Boolean
        lett = False
        For i = 1 To Len(St)
            ch = Asc(Mid(St, i, 1))
            If (ch < Asc("0") Or ch > Asc("9")) And ch <> Asc("-") And ch <> Asc(".") And ch <> Asc(",") And ch <> 32 Then
                lett = True
            End If
        Next
        lettere = lett
    End Function
    Private Sub Text8_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text8.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Text8.BackColor.Equals(System.Drawing.Color.Red) Then Text8.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub AggCase()
        Select Case objPart.TreLati
            Case True : Combo1.SelectedIndex = 0
            Case False : Combo1.SelectedIndex = 1
        End Select
    End Sub
    Private Sub Text9_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text9.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Spess = GlobalRoutines.ValVir(Text9.Text * kLength)
    End Sub
    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        SelMat()
        PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(0))
        Select Case Matdim(Involucr(kLato, jInvolucr).indice(0)).Classe
            Case 1 : Combo2.SelectedIndex = 0
            Case Else : Combo2.SelectedIndex = 1
        End Select
        SubAmm()
    End Sub
    Private Sub _cmdCil_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        SubAmm()
    End Sub
    Private Sub _cmdCil_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_5.Click
        Text3.Text = GlobalRoutines.myStr(TempDes() * kTemp + kTemp32, 5, 3, False)
    End Sub
    Private Sub chkAgganciato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato = chkAgganciato.Checked
        ModifiedData = True
    End Sub
End Class