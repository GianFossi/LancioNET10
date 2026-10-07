Option Strict Off
Option Explicit On
Friend Class frmCar
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
	Public WithEvents cmdFatto As System.Windows.Forms.Button
	Public WithEvents _cmdFinal_1 As System.Windows.Forms.Button
	Public WithEvents _Text3_14 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_13 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_12 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_11 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_10 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_9 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_9 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_10 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_11 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_12 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_13 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_14 As System.Windows.Forms.TextBox
	Public WithEvents cmdGiven As System.Windows.Forms.Button
	Public WithEvents _cmdFinal_0 As System.Windows.Forms.Button
	Public WithEvents _Text3_8 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_7 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_6 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_4 As System.Windows.Forms.TextBox
	Public WithEvents _Text3_3 As System.Windows.Forms.TextBox
	Public WithEvents _Command2_3 As System.Windows.Forms.Button
	Public WithEvents _Text2_8 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_7 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_6 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_4 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_3 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_2 As System.Windows.Forms.TextBox
	Public WithEvents _Text2_1 As System.Windows.Forms.TextBox
    Public WithEvents _lblTipo_5 As System.Windows.Forms.Label
	Public WithEvents _lblTipo_4 As System.Windows.Forms.Label
	Public WithEvents _lblUni_14 As System.Windows.Forms.Label
	Public WithEvents _lblUni_13 As System.Windows.Forms.Label
	Public WithEvents _lblUni_12 As System.Windows.Forms.Label
	Public WithEvents _lblUni_11 As System.Windows.Forms.Label
	Public WithEvents _lblUni_10 As System.Windows.Forms.Label
	Public WithEvents _lblUni_9 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_2 As System.Windows.Forms.Label
	Public WithEvents _lblTipo_1 As System.Windows.Forms.Label
    Public WithEvents _lblUni_8 As System.Windows.Forms.Label
	Public WithEvents _lblUni_7 As System.Windows.Forms.Label
	Public WithEvents _lblUni_6 As System.Windows.Forms.Label
	Public WithEvents _lblUni_5 As System.Windows.Forms.Label
	Public WithEvents _lblUni_4 As System.Windows.Forms.Label
	Public WithEvents _lblUni_3 As System.Windows.Forms.Label
	Public WithEvents _lblUni_2 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents _Label2_10 As System.Windows.Forms.Label
    Public WithEvents _Label2_9 As System.Windows.Forms.Label
    Public WithEvents _Label2_11 As System.Windows.Forms.Label
    Public WithEvents _Label2_12 As System.Windows.Forms.Label
    Public WithEvents _Label2_13 As System.Windows.Forms.Label
    Public WithEvents _Label2_14 As System.Windows.Forms.Label
    Public WithEvents _Label2_8 As System.Windows.Forms.Label
    Public WithEvents _Label2_7 As System.Windows.Forms.Label
    Public WithEvents _Label2_6 As System.Windows.Forms.Label
    Public WithEvents _Label2_5 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_3 As System.Windows.Forms.Label
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_0 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_3 As System.Windows.Forms.Label
    Friend WithEvents TabStrip2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents _rtx_3 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_2 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_4 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_6 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_5 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_8 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_7 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_14 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_13 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_12 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_11 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_10 As System.Windows.Forms.RichTextBox
    Friend WithEvents _rtx_9 As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCar))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdFinal_1 = New System.Windows.Forms.Button
        Me.cmdGiven = New System.Windows.Forms.Button
        Me._cmdFinal_0 = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdFatto = New System.Windows.Forms.Button
        Me._Text3_14 = New System.Windows.Forms.TextBox
        Me._Text3_13 = New System.Windows.Forms.TextBox
        Me._Text3_12 = New System.Windows.Forms.TextBox
        Me._Text3_11 = New System.Windows.Forms.TextBox
        Me._Text3_10 = New System.Windows.Forms.TextBox
        Me._Text3_9 = New System.Windows.Forms.TextBox
        Me._Text2_9 = New System.Windows.Forms.TextBox
        Me._Text2_10 = New System.Windows.Forms.TextBox
        Me._Text2_11 = New System.Windows.Forms.TextBox
        Me._Text2_12 = New System.Windows.Forms.TextBox
        Me._Text2_13 = New System.Windows.Forms.TextBox
        Me._Text2_14 = New System.Windows.Forms.TextBox
        Me._Text3_8 = New System.Windows.Forms.TextBox
        Me._Text3_7 = New System.Windows.Forms.TextBox
        Me._Text3_6 = New System.Windows.Forms.TextBox
        Me._Text3_5 = New System.Windows.Forms.TextBox
        Me._Text3_4 = New System.Windows.Forms.TextBox
        Me._Text3_3 = New System.Windows.Forms.TextBox
        Me._Command2_3 = New System.Windows.Forms.Button
        Me._Text2_8 = New System.Windows.Forms.TextBox
        Me._Text2_7 = New System.Windows.Forms.TextBox
        Me._Text2_6 = New System.Windows.Forms.TextBox
        Me._Text2_5 = New System.Windows.Forms.TextBox
        Me._Text2_4 = New System.Windows.Forms.TextBox
        Me._Text2_3 = New System.Windows.Forms.TextBox
        Me._Text2_2 = New System.Windows.Forms.TextBox
        Me._Text2_1 = New System.Windows.Forms.TextBox
        Me._lblTipo_5 = New System.Windows.Forms.Label
        Me._lblTipo_4 = New System.Windows.Forms.Label
        Me._lblUni_14 = New System.Windows.Forms.Label
        Me._lblUni_13 = New System.Windows.Forms.Label
        Me._lblUni_12 = New System.Windows.Forms.Label
        Me._lblUni_11 = New System.Windows.Forms.Label
        Me._lblUni_10 = New System.Windows.Forms.Label
        Me._lblUni_9 = New System.Windows.Forms.Label
        Me._lblTipo_2 = New System.Windows.Forms.Label
        Me._lblTipo_1 = New System.Windows.Forms.Label
        Me._lblUni_8 = New System.Windows.Forms.Label
        Me._lblUni_7 = New System.Windows.Forms.Label
        Me._lblUni_6 = New System.Windows.Forms.Label
        Me._lblUni_5 = New System.Windows.Forms.Label
        Me._lblUni_4 = New System.Windows.Forms.Label
        Me._lblUni_3 = New System.Windows.Forms.Label
        Me._lblUni_2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me._rtx_14 = New System.Windows.Forms.RichTextBox
        Me._rtx_13 = New System.Windows.Forms.RichTextBox
        Me._rtx_12 = New System.Windows.Forms.RichTextBox
        Me._rtx_11 = New System.Windows.Forms.RichTextBox
        Me._rtx_10 = New System.Windows.Forms.RichTextBox
        Me._rtx_9 = New System.Windows.Forms.RichTextBox
        Me._rtx_8 = New System.Windows.Forms.RichTextBox
        Me._rtx_7 = New System.Windows.Forms.RichTextBox
        Me._rtx_6 = New System.Windows.Forms.RichTextBox
        Me._rtx_5 = New System.Windows.Forms.RichTextBox
        Me._rtx_4 = New System.Windows.Forms.RichTextBox
        Me._rtx_2 = New System.Windows.Forms.RichTextBox
        Me._rtx_3 = New System.Windows.Forms.RichTextBox
        Me._lblTipo_3 = New System.Windows.Forms.Label
        Me._lblTipo_0 = New System.Windows.Forms.Label
        Me._Label2_10 = New System.Windows.Forms.Label
        Me._Label2_9 = New System.Windows.Forms.Label
        Me._Label2_11 = New System.Windows.Forms.Label
        Me._Label2_12 = New System.Windows.Forms.Label
        Me._Label2_13 = New System.Windows.Forms.Label
        Me._Label2_14 = New System.Windows.Forms.Label
        Me._Label2_8 = New System.Windows.Forms.Label
        Me._Label2_7 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me.TabStrip2 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1.SuspendLayout()
        Me.TabStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        '_cmdFinal_1
        '
        Me._cmdFinal_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdFinal_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFinal_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdFinal_1.Location = New System.Drawing.Point(432, 232)
        Me._cmdFinal_1.Name = "_cmdFinal_1"
        Me._cmdFinal_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFinal_1.Size = New System.Drawing.Size(19, 19)
        Me._cmdFinal_1.TabIndex = 78
        Me._cmdFinal_1.Text = "R"
        Me.ToolTip1.SetToolTip(Me._cmdFinal_1, "Ricalcola i valori finali ove applicabile (effetto di fondo e riporto dei tagli a" & _
        "l piede)")
        '
        'cmdGiven
        '
        Me.cmdGiven.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGiven.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGiven.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGiven.Location = New System.Drawing.Point(328, 64)
        Me.cmdGiven.Name = "cmdGiven"
        Me.cmdGiven.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGiven.Size = New System.Drawing.Size(19, 19)
        Me.cmdGiven.TabIndex = 44
        Me.cmdGiven.Text = "R"
        Me.ToolTip1.SetToolTip(Me.cmdGiven, "(Ri)applica i carichi standard, se specificati")
        '
        '_cmdFinal_0
        '
        Me._cmdFinal_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdFinal_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFinal_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdFinal_0.Location = New System.Drawing.Point(432, 64)
        Me._cmdFinal_0.Name = "_cmdFinal_0"
        Me._cmdFinal_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFinal_0.Size = New System.Drawing.Size(19, 19)
        Me._cmdFinal_0.TabIndex = 43
        Me._cmdFinal_0.Text = "R"
        Me.ToolTip1.SetToolTip(Me._cmdFinal_0, "Ricalcola i valori finali ove applicabile (effetto di fondo e riporto dei tagli a" & _
        "l piede)")
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(528, 208)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(48, 28)
        Me.cmdCancel.TabIndex = 79
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdFatto
        '
        Me.cmdFatto.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFatto.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFatto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFatto.Location = New System.Drawing.Point(528, 176)
        Me.cmdFatto.Name = "cmdFatto"
        Me.cmdFatto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFatto.Size = New System.Drawing.Size(48, 28)
        Me.cmdFatto.TabIndex = 33
        Me.cmdFatto.Text = "Fatto"
        '
        '_Text3_14
        '
        Me._Text3_14.AcceptsReturn = True
        Me._Text3_14.AutoSize = False
        Me._Text3_14.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_14.Location = New System.Drawing.Point(352, 376)
        Me._Text3_14.MaxLength = 0
        Me._Text3_14.Name = "_Text3_14"
        Me._Text3_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_14.Size = New System.Drawing.Size(82, 24)
        Me._Text3_14.TabIndex = 75
        Me._Text3_14.Text = "Textg"
        '
        '_Text3_13
        '
        Me._Text3_13.AcceptsReturn = True
        Me._Text3_13.AutoSize = False
        Me._Text3_13.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_13.Location = New System.Drawing.Point(352, 352)
        Me._Text3_13.MaxLength = 0
        Me._Text3_13.Name = "_Text3_13"
        Me._Text3_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_13.Size = New System.Drawing.Size(82, 24)
        Me._Text3_13.TabIndex = 74
        Me._Text3_13.Text = "Textg"
        '
        '_Text3_12
        '
        Me._Text3_12.AcceptsReturn = True
        Me._Text3_12.AutoSize = False
        Me._Text3_12.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_12.Location = New System.Drawing.Point(352, 328)
        Me._Text3_12.MaxLength = 0
        Me._Text3_12.Name = "_Text3_12"
        Me._Text3_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_12.Size = New System.Drawing.Size(82, 24)
        Me._Text3_12.TabIndex = 73
        Me._Text3_12.Text = "Textg"
        '
        '_Text3_11
        '
        Me._Text3_11.AcceptsReturn = True
        Me._Text3_11.AutoSize = False
        Me._Text3_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_11.Location = New System.Drawing.Point(352, 304)
        Me._Text3_11.MaxLength = 0
        Me._Text3_11.Name = "_Text3_11"
        Me._Text3_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_11.Size = New System.Drawing.Size(82, 24)
        Me._Text3_11.TabIndex = 72
        Me._Text3_11.Text = "Textg"
        '
        '_Text3_10
        '
        Me._Text3_10.AcceptsReturn = True
        Me._Text3_10.AutoSize = False
        Me._Text3_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_10.Location = New System.Drawing.Point(352, 280)
        Me._Text3_10.MaxLength = 0
        Me._Text3_10.Name = "_Text3_10"
        Me._Text3_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_10.Size = New System.Drawing.Size(82, 24)
        Me._Text3_10.TabIndex = 71
        Me._Text3_10.Text = "Textg"
        '
        '_Text3_9
        '
        Me._Text3_9.AcceptsReturn = True
        Me._Text3_9.AutoSize = False
        Me._Text3_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_9.Location = New System.Drawing.Point(352, 256)
        Me._Text3_9.MaxLength = 0
        Me._Text3_9.Name = "_Text3_9"
        Me._Text3_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_9.Size = New System.Drawing.Size(82, 24)
        Me._Text3_9.TabIndex = 70
        Me._Text3_9.Text = "Textg"
        '
        '_Text2_9
        '
        Me._Text2_9.AcceptsReturn = True
        Me._Text2_9.AutoSize = False
        Me._Text2_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_9.Location = New System.Drawing.Point(248, 256)
        Me._Text2_9.MaxLength = 0
        Me._Text2_9.Name = "_Text2_9"
        Me._Text2_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_9.Size = New System.Drawing.Size(82, 24)
        Me._Text2_9.TabIndex = 51
        Me._Text2_9.Text = "Textg"
        '
        '_Text2_10
        '
        Me._Text2_10.AcceptsReturn = True
        Me._Text2_10.AutoSize = False
        Me._Text2_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_10.Location = New System.Drawing.Point(248, 280)
        Me._Text2_10.MaxLength = 0
        Me._Text2_10.Name = "_Text2_10"
        Me._Text2_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_10.Size = New System.Drawing.Size(82, 24)
        Me._Text2_10.TabIndex = 50
        Me._Text2_10.Text = "Textg"
        '
        '_Text2_11
        '
        Me._Text2_11.AcceptsReturn = True
        Me._Text2_11.AutoSize = False
        Me._Text2_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_11.Location = New System.Drawing.Point(248, 304)
        Me._Text2_11.MaxLength = 0
        Me._Text2_11.Name = "_Text2_11"
        Me._Text2_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_11.Size = New System.Drawing.Size(82, 24)
        Me._Text2_11.TabIndex = 49
        Me._Text2_11.Text = "Textg"
        '
        '_Text2_12
        '
        Me._Text2_12.AcceptsReturn = True
        Me._Text2_12.AutoSize = False
        Me._Text2_12.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_12.Location = New System.Drawing.Point(248, 328)
        Me._Text2_12.MaxLength = 0
        Me._Text2_12.Name = "_Text2_12"
        Me._Text2_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_12.Size = New System.Drawing.Size(82, 24)
        Me._Text2_12.TabIndex = 48
        Me._Text2_12.Text = "Textg"
        '
        '_Text2_13
        '
        Me._Text2_13.AcceptsReturn = True
        Me._Text2_13.AutoSize = False
        Me._Text2_13.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_13.Location = New System.Drawing.Point(248, 352)
        Me._Text2_13.MaxLength = 0
        Me._Text2_13.Name = "_Text2_13"
        Me._Text2_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_13.Size = New System.Drawing.Size(82, 24)
        Me._Text2_13.TabIndex = 47
        Me._Text2_13.Text = "Textg"
        '
        '_Text2_14
        '
        Me._Text2_14.AcceptsReturn = True
        Me._Text2_14.AutoSize = False
        Me._Text2_14.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_14.Location = New System.Drawing.Point(248, 376)
        Me._Text2_14.MaxLength = 0
        Me._Text2_14.Name = "_Text2_14"
        Me._Text2_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_14.Size = New System.Drawing.Size(82, 24)
        Me._Text2_14.TabIndex = 46
        Me._Text2_14.Text = "Textg"
        '
        '_Text3_8
        '
        Me._Text3_8.AcceptsReturn = True
        Me._Text3_8.AutoSize = False
        Me._Text3_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_8.Location = New System.Drawing.Point(352, 208)
        Me._Text3_8.MaxLength = 0
        Me._Text3_8.Name = "_Text3_8"
        Me._Text3_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_8.Size = New System.Drawing.Size(82, 24)
        Me._Text3_8.TabIndex = 40
        Me._Text3_8.Text = "Textg"
        '
        '_Text3_7
        '
        Me._Text3_7.AcceptsReturn = True
        Me._Text3_7.AutoSize = False
        Me._Text3_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_7.Location = New System.Drawing.Point(352, 184)
        Me._Text3_7.MaxLength = 0
        Me._Text3_7.Name = "_Text3_7"
        Me._Text3_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_7.Size = New System.Drawing.Size(82, 24)
        Me._Text3_7.TabIndex = 39
        Me._Text3_7.Text = "Textg"
        '
        '_Text3_6
        '
        Me._Text3_6.AcceptsReturn = True
        Me._Text3_6.AutoSize = False
        Me._Text3_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_6.Location = New System.Drawing.Point(352, 160)
        Me._Text3_6.MaxLength = 0
        Me._Text3_6.Name = "_Text3_6"
        Me._Text3_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_6.Size = New System.Drawing.Size(82, 24)
        Me._Text3_6.TabIndex = 38
        Me._Text3_6.Text = "Textg"
        '
        '_Text3_5
        '
        Me._Text3_5.AcceptsReturn = True
        Me._Text3_5.AutoSize = False
        Me._Text3_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_5.Location = New System.Drawing.Point(352, 136)
        Me._Text3_5.MaxLength = 0
        Me._Text3_5.Name = "_Text3_5"
        Me._Text3_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_5.Size = New System.Drawing.Size(82, 24)
        Me._Text3_5.TabIndex = 37
        Me._Text3_5.Text = "Textg"
        '
        '_Text3_4
        '
        Me._Text3_4.AcceptsReturn = True
        Me._Text3_4.AutoSize = False
        Me._Text3_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_4.Location = New System.Drawing.Point(352, 112)
        Me._Text3_4.MaxLength = 0
        Me._Text3_4.Name = "_Text3_4"
        Me._Text3_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_4.Size = New System.Drawing.Size(82, 24)
        Me._Text3_4.TabIndex = 36
        Me._Text3_4.Text = "Textg"
        '
        '_Text3_3
        '
        Me._Text3_3.AcceptsReturn = True
        Me._Text3_3.AutoSize = False
        Me._Text3_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_3.Location = New System.Drawing.Point(352, 88)
        Me._Text3_3.MaxLength = 0
        Me._Text3_3.Name = "_Text3_3"
        Me._Text3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_3.Size = New System.Drawing.Size(82, 24)
        Me._Text3_3.TabIndex = 35
        Me._Text3_3.Text = "Textg"
        '
        '_Command2_3
        '
        Me._Command2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Command2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command2_3.Image = CType(resources.GetObject("_Command2_3.Image"), System.Drawing.Image)
        Me._Command2_3.Location = New System.Drawing.Point(200, 88)
        Me._Command2_3.Name = "_Command2_3"
        Me._Command2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command2_3.Size = New System.Drawing.Size(24, 24)
        Me._Command2_3.TabIndex = 9
        Me._Command2_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Text2_8
        '
        Me._Text2_8.AcceptsReturn = True
        Me._Text2_8.AutoSize = False
        Me._Text2_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_8.Location = New System.Drawing.Point(248, 208)
        Me._Text2_8.MaxLength = 0
        Me._Text2_8.Name = "_Text2_8"
        Me._Text2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_8.Size = New System.Drawing.Size(82, 24)
        Me._Text2_8.TabIndex = 8
        Me._Text2_8.Text = "Textg"
        '
        '_Text2_7
        '
        Me._Text2_7.AcceptsReturn = True
        Me._Text2_7.AutoSize = False
        Me._Text2_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_7.Location = New System.Drawing.Point(248, 184)
        Me._Text2_7.MaxLength = 0
        Me._Text2_7.Name = "_Text2_7"
        Me._Text2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_7.Size = New System.Drawing.Size(82, 24)
        Me._Text2_7.TabIndex = 7
        Me._Text2_7.Text = "Textg"
        '
        '_Text2_6
        '
        Me._Text2_6.AcceptsReturn = True
        Me._Text2_6.AutoSize = False
        Me._Text2_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_6.Location = New System.Drawing.Point(248, 160)
        Me._Text2_6.MaxLength = 0
        Me._Text2_6.Name = "_Text2_6"
        Me._Text2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_6.Size = New System.Drawing.Size(82, 24)
        Me._Text2_6.TabIndex = 6
        Me._Text2_6.Text = "Textg"
        '
        '_Text2_5
        '
        Me._Text2_5.AcceptsReturn = True
        Me._Text2_5.AutoSize = False
        Me._Text2_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_5.Location = New System.Drawing.Point(248, 136)
        Me._Text2_5.MaxLength = 0
        Me._Text2_5.Name = "_Text2_5"
        Me._Text2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_5.Size = New System.Drawing.Size(82, 24)
        Me._Text2_5.TabIndex = 5
        Me._Text2_5.Text = "Textg"
        '
        '_Text2_4
        '
        Me._Text2_4.AcceptsReturn = True
        Me._Text2_4.AutoSize = False
        Me._Text2_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_4.Location = New System.Drawing.Point(248, 112)
        Me._Text2_4.MaxLength = 0
        Me._Text2_4.Name = "_Text2_4"
        Me._Text2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_4.Size = New System.Drawing.Size(82, 24)
        Me._Text2_4.TabIndex = 4
        Me._Text2_4.Text = "Textg"
        '
        '_Text2_3
        '
        Me._Text2_3.AcceptsReturn = True
        Me._Text2_3.AutoSize = False
        Me._Text2_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_3.Location = New System.Drawing.Point(248, 88)
        Me._Text2_3.MaxLength = 0
        Me._Text2_3.Name = "_Text2_3"
        Me._Text2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_3.Size = New System.Drawing.Size(82, 24)
        Me._Text2_3.TabIndex = 3
        Me._Text2_3.Text = "Textg"
        '
        '_Text2_2
        '
        Me._Text2_2.AcceptsReturn = True
        Me._Text2_2.AutoSize = False
        Me._Text2_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_2.Location = New System.Drawing.Point(248, 40)
        Me._Text2_2.MaxLength = 0
        Me._Text2_2.Name = "_Text2_2"
        Me._Text2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_2.Size = New System.Drawing.Size(82, 24)
        Me._Text2_2.TabIndex = 2
        Me._Text2_2.Text = "Textg"
        '
        '_Text2_1
        '
        Me._Text2_1.AcceptsReturn = True
        Me._Text2_1.AutoSize = False
        Me._Text2_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_1.Location = New System.Drawing.Point(184, 16)
        Me._Text2_1.MaxLength = 0
        Me._Text2_1.Name = "_Text2_1"
        Me._Text2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_1.Size = New System.Drawing.Size(208, 24)
        Me._Text2_1.TabIndex = 1
        Me._Text2_1.Text = "Textg,.1234"
        '
        '_lblTipo_5
        '
        Me._lblTipo_5.BackColor = System.Drawing.SystemColors.Info
        Me._lblTipo_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTipo_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblTipo_5.Location = New System.Drawing.Point(352, 232)
        Me._lblTipo_5.Name = "_lblTipo_5"
        Me._lblTipo_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_5.Size = New System.Drawing.Size(82, 19)
        Me._lblTipo_5.TabIndex = 77
        Me._lblTipo_5.Text = " Final values"
        '
        '_lblTipo_4
        '
        Me._lblTipo_4.BackColor = System.Drawing.SystemColors.Info
        Me._lblTipo_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTipo_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblTipo_4.Location = New System.Drawing.Point(248, 232)
        Me._lblTipo_4.Name = "_lblTipo_4"
        Me._lblTipo_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_4.Size = New System.Drawing.Size(82, 19)
        Me._lblTipo_4.TabIndex = 76
        Me._lblTipo_4.Text = "Given values"
        '
        '_lblUni_14
        '
        Me._lblUni_14.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_14.Location = New System.Drawing.Point(440, 376)
        Me._lblUni_14.Name = "_lblUni_14"
        Me._lblUni_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_14.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_14.TabIndex = 63
        Me._lblUni_14.Text = "Label2"
        Me._lblUni_14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_13
        '
        Me._lblUni_13.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_13.Location = New System.Drawing.Point(440, 352)
        Me._lblUni_13.Name = "_lblUni_13"
        Me._lblUni_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_13.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_13.TabIndex = 62
        Me._lblUni_13.Text = "Label2"
        Me._lblUni_13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_12
        '
        Me._lblUni_12.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_12.Location = New System.Drawing.Point(440, 328)
        Me._lblUni_12.Name = "_lblUni_12"
        Me._lblUni_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_12.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_12.TabIndex = 61
        Me._lblUni_12.Text = "Label2"
        Me._lblUni_12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_11
        '
        Me._lblUni_11.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_11.Location = New System.Drawing.Point(440, 304)
        Me._lblUni_11.Name = "_lblUni_11"
        Me._lblUni_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_11.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_11.TabIndex = 60
        Me._lblUni_11.Text = "Label2"
        Me._lblUni_11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_10
        '
        Me._lblUni_10.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_10.Location = New System.Drawing.Point(440, 280)
        Me._lblUni_10.Name = "_lblUni_10"
        Me._lblUni_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_10.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_10.TabIndex = 59
        Me._lblUni_10.Text = "Label2"
        Me._lblUni_10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_9
        '
        Me._lblUni_9.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_9.Location = New System.Drawing.Point(440, 256)
        Me._lblUni_9.Name = "_lblUni_9"
        Me._lblUni_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_9.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_9.TabIndex = 58
        Me._lblUni_9.Text = "Label2"
        Me._lblUni_9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTipo_2
        '
        Me._lblTipo_2.BackColor = System.Drawing.SystemColors.Info
        Me._lblTipo_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTipo_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblTipo_2.Location = New System.Drawing.Point(352, 64)
        Me._lblTipo_2.Name = "_lblTipo_2"
        Me._lblTipo_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_2.Size = New System.Drawing.Size(82, 19)
        Me._lblTipo_2.TabIndex = 42
        Me._lblTipo_2.Text = " Final values"
        '
        '_lblTipo_1
        '
        Me._lblTipo_1.BackColor = System.Drawing.SystemColors.Info
        Me._lblTipo_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTipo_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblTipo_1.Location = New System.Drawing.Point(248, 64)
        Me._lblTipo_1.Name = "_lblTipo_1"
        Me._lblTipo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_1.Size = New System.Drawing.Size(82, 19)
        Me._lblTipo_1.TabIndex = 41
        Me._lblTipo_1.Text = "Given values"
        '
        '_lblUni_8
        '
        Me._lblUni_8.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_8.Location = New System.Drawing.Point(440, 208)
        Me._lblUni_8.Name = "_lblUni_8"
        Me._lblUni_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_8.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_8.TabIndex = 25
        Me._lblUni_8.Text = "Label2"
        Me._lblUni_8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_7
        '
        Me._lblUni_7.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_7.Location = New System.Drawing.Point(440, 184)
        Me._lblUni_7.Name = "_lblUni_7"
        Me._lblUni_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_7.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_7.TabIndex = 24
        Me._lblUni_7.Text = "Label2"
        Me._lblUni_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_6
        '
        Me._lblUni_6.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_6.Location = New System.Drawing.Point(440, 160)
        Me._lblUni_6.Name = "_lblUni_6"
        Me._lblUni_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_6.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_6.TabIndex = 23
        Me._lblUni_6.Text = "Label2"
        Me._lblUni_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_5
        '
        Me._lblUni_5.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_5.Location = New System.Drawing.Point(440, 136)
        Me._lblUni_5.Name = "_lblUni_5"
        Me._lblUni_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_5.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_5.TabIndex = 22
        Me._lblUni_5.Text = "Label2"
        Me._lblUni_5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_4
        '
        Me._lblUni_4.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_4.Location = New System.Drawing.Point(440, 112)
        Me._lblUni_4.Name = "_lblUni_4"
        Me._lblUni_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_4.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_4.TabIndex = 21
        Me._lblUni_4.Text = "Label2"
        Me._lblUni_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_3
        '
        Me._lblUni_3.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_3.Location = New System.Drawing.Point(440, 88)
        Me._lblUni_3.Name = "_lblUni_3"
        Me._lblUni_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_3.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_3.TabIndex = 20
        Me._lblUni_3.Text = "Label2"
        Me._lblUni_3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_2
        '
        Me._lblUni_2.BackColor = System.Drawing.Color.LimeGreen
        Me._lblUni_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_2.Location = New System.Drawing.Point(352, 40)
        Me._lblUni_2.Name = "_lblUni_2"
        Me._lblUni_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_2.Size = New System.Drawing.Size(48, 24)
        Me._lblUni_2.TabIndex = 19
        Me._lblUni_2.Text = "Label2"
        Me._lblUni_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me._rtx_14)
        Me.GroupBox1.Controls.Add(Me._rtx_13)
        Me.GroupBox1.Controls.Add(Me._rtx_12)
        Me.GroupBox1.Controls.Add(Me._rtx_11)
        Me.GroupBox1.Controls.Add(Me._rtx_10)
        Me.GroupBox1.Controls.Add(Me._rtx_9)
        Me.GroupBox1.Controls.Add(Me._rtx_8)
        Me.GroupBox1.Controls.Add(Me._rtx_7)
        Me.GroupBox1.Controls.Add(Me._rtx_6)
        Me.GroupBox1.Controls.Add(Me._rtx_5)
        Me.GroupBox1.Controls.Add(Me._rtx_4)
        Me.GroupBox1.Controls.Add(Me._rtx_2)
        Me.GroupBox1.Controls.Add(Me._rtx_3)
        Me.GroupBox1.Controls.Add(Me._lblTipo_3)
        Me.GroupBox1.Controls.Add(Me._lblTipo_0)
        Me.GroupBox1.Controls.Add(Me._Label2_10)
        Me.GroupBox1.Controls.Add(Me._Label2_9)
        Me.GroupBox1.Controls.Add(Me._Label2_11)
        Me.GroupBox1.Controls.Add(Me._Label2_12)
        Me.GroupBox1.Controls.Add(Me._Label2_13)
        Me.GroupBox1.Controls.Add(Me._Label2_14)
        Me.GroupBox1.Controls.Add(Me._Label2_8)
        Me.GroupBox1.Controls.Add(Me._Label2_7)
        Me.GroupBox1.Controls.Add(Me._Label2_6)
        Me.GroupBox1.Controls.Add(Me._Label2_5)
        Me.GroupBox1.Controls.Add(Me._Label2_2)
        Me.GroupBox1.Controls.Add(Me._Label2_3)
        Me.GroupBox1.Controls.Add(Me._Label2_4)
        Me.GroupBox1.Controls.Add(Me._Label2_1)
        Me.GroupBox1.Controls.Add(Me._Command2_3)
        Me.GroupBox1.Controls.Add(Me._Text2_3)
        Me.GroupBox1.Controls.Add(Me._Text2_8)
        Me.GroupBox1.Controls.Add(Me._Text2_11)
        Me.GroupBox1.Controls.Add(Me._Text2_10)
        Me.GroupBox1.Controls.Add(Me._Text2_13)
        Me.GroupBox1.Controls.Add(Me._Text2_14)
        Me.GroupBox1.Controls.Add(Me._Text2_6)
        Me.GroupBox1.Controls.Add(Me._Text2_9)
        Me.GroupBox1.Controls.Add(Me._Text2_5)
        Me.GroupBox1.Controls.Add(Me._Text2_12)
        Me.GroupBox1.Controls.Add(Me._Text2_4)
        Me.GroupBox1.Controls.Add(Me._Text2_7)
        Me.GroupBox1.Controls.Add(Me._lblTipo_1)
        Me.GroupBox1.Controls.Add(Me._lblTipo_4)
        Me.GroupBox1.Controls.Add(Me.cmdGiven)
        Me.GroupBox1.Controls.Add(Me._lblTipo_2)
        Me.GroupBox1.Controls.Add(Me._cmdFinal_0)
        Me.GroupBox1.Controls.Add(Me._Text3_9)
        Me.GroupBox1.Controls.Add(Me._Text3_11)
        Me.GroupBox1.Controls.Add(Me._Text3_14)
        Me.GroupBox1.Controls.Add(Me._Text3_6)
        Me.GroupBox1.Controls.Add(Me._Text3_3)
        Me.GroupBox1.Controls.Add(Me._Text3_12)
        Me.GroupBox1.Controls.Add(Me._Text3_8)
        Me.GroupBox1.Controls.Add(Me._Text3_7)
        Me.GroupBox1.Controls.Add(Me._Text3_5)
        Me.GroupBox1.Controls.Add(Me._Text3_13)
        Me.GroupBox1.Controls.Add(Me._Text3_10)
        Me.GroupBox1.Controls.Add(Me._Text3_4)
        Me.GroupBox1.Controls.Add(Me._lblTipo_5)
        Me.GroupBox1.Controls.Add(Me._cmdFinal_1)
        Me.GroupBox1.Controls.Add(Me._lblUni_5)
        Me.GroupBox1.Controls.Add(Me._lblUni_4)
        Me.GroupBox1.Controls.Add(Me._lblUni_3)
        Me.GroupBox1.Controls.Add(Me._lblUni_13)
        Me.GroupBox1.Controls.Add(Me._lblUni_12)
        Me.GroupBox1.Controls.Add(Me._lblUni_11)
        Me.GroupBox1.Controls.Add(Me._lblUni_10)
        Me.GroupBox1.Controls.Add(Me._lblUni_9)
        Me.GroupBox1.Controls.Add(Me._lblUni_14)
        Me.GroupBox1.Controls.Add(Me._lblUni_8)
        Me.GroupBox1.Controls.Add(Me._lblUni_7)
        Me.GroupBox1.Controls.Add(Me._lblUni_6)
        Me.GroupBox1.Controls.Add(Me._lblUni_2)
        Me.GroupBox1.Controls.Add(Me._Text2_2)
        Me.GroupBox1.Controls.Add(Me._Text2_1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 408)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        '
        '_rtx_14
        '
        Me._rtx_14.Location = New System.Drawing.Point(224, 376)
        Me._rtx_14.Name = "_rtx_14"
        Me._rtx_14.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_14.Size = New System.Drawing.Size(24, 24)
        Me._rtx_14.TabIndex = 91
        Me._rtx_14.Text = "RichTextBox8"
        '
        '_rtx_13
        '
        Me._rtx_13.Location = New System.Drawing.Point(224, 352)
        Me._rtx_13.Name = "_rtx_13"
        Me._rtx_13.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_13.Size = New System.Drawing.Size(24, 24)
        Me._rtx_13.TabIndex = 90
        Me._rtx_13.Text = "RichTextBox9"
        '
        '_rtx_12
        '
        Me._rtx_12.Location = New System.Drawing.Point(224, 328)
        Me._rtx_12.Name = "_rtx_12"
        Me._rtx_12.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_12.Size = New System.Drawing.Size(24, 24)
        Me._rtx_12.TabIndex = 89
        Me._rtx_12.Text = "RichTextBox10"
        '
        '_rtx_11
        '
        Me._rtx_11.Location = New System.Drawing.Point(224, 304)
        Me._rtx_11.Name = "_rtx_11"
        Me._rtx_11.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_11.Size = New System.Drawing.Size(24, 24)
        Me._rtx_11.TabIndex = 88
        Me._rtx_11.Text = "RichTextBox11"
        '
        '_rtx_10
        '
        Me._rtx_10.Location = New System.Drawing.Point(224, 280)
        Me._rtx_10.Name = "_rtx_10"
        Me._rtx_10.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_10.Size = New System.Drawing.Size(24, 24)
        Me._rtx_10.TabIndex = 87
        Me._rtx_10.Text = "RichTextBox12"
        '
        '_rtx_9
        '
        Me._rtx_9.Location = New System.Drawing.Point(224, 256)
        Me._rtx_9.Name = "_rtx_9"
        Me._rtx_9.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_9.Size = New System.Drawing.Size(24, 24)
        Me._rtx_9.TabIndex = 86
        Me._rtx_9.Text = "RichTextBox13"
        '
        '_rtx_8
        '
        Me._rtx_8.Location = New System.Drawing.Point(224, 208)
        Me._rtx_8.Name = "_rtx_8"
        Me._rtx_8.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_8.Size = New System.Drawing.Size(24, 24)
        Me._rtx_8.TabIndex = 85
        Me._rtx_8.Text = "RichTextBox6"
        '
        '_rtx_7
        '
        Me._rtx_7.Location = New System.Drawing.Point(224, 184)
        Me._rtx_7.Name = "_rtx_7"
        Me._rtx_7.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_7.Size = New System.Drawing.Size(24, 24)
        Me._rtx_7.TabIndex = 84
        Me._rtx_7.Text = "RichTextBox7"
        '
        '_rtx_6
        '
        Me._rtx_6.Location = New System.Drawing.Point(224, 160)
        Me._rtx_6.Name = "_rtx_6"
        Me._rtx_6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_6.Size = New System.Drawing.Size(24, 24)
        Me._rtx_6.TabIndex = 83
        Me._rtx_6.Text = "RichTextBox4"
        '
        '_rtx_5
        '
        Me._rtx_5.Location = New System.Drawing.Point(224, 136)
        Me._rtx_5.Name = "_rtx_5"
        Me._rtx_5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_5.Size = New System.Drawing.Size(24, 24)
        Me._rtx_5.TabIndex = 82
        Me._rtx_5.Text = "RichTextBox5"
        '
        '_rtx_4
        '
        Me._rtx_4.Location = New System.Drawing.Point(224, 112)
        Me._rtx_4.Name = "_rtx_4"
        Me._rtx_4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_4.Size = New System.Drawing.Size(24, 24)
        Me._rtx_4.TabIndex = 81
        Me._rtx_4.Text = "RichTextBox3"
        '
        '_rtx_2
        '
        Me._rtx_2.Location = New System.Drawing.Point(224, 40)
        Me._rtx_2.Name = "_rtx_2"
        Me._rtx_2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_2.Size = New System.Drawing.Size(24, 24)
        Me._rtx_2.TabIndex = 80
        Me._rtx_2.Text = "RichTextBox2"
        '
        '_rtx_3
        '
        Me._rtx_3.Location = New System.Drawing.Point(224, 88)
        Me._rtx_3.Name = "_rtx_3"
        Me._rtx_3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtx_3.Size = New System.Drawing.Size(24, 24)
        Me._rtx_3.TabIndex = 79
        Me._rtx_3.Text = "RichTextBox1"
        '
        '_lblTipo_3
        '
        Me._lblTipo_3.BackColor = System.Drawing.SystemColors.Info
        Me._lblTipo_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTipo_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblTipo_3.Location = New System.Drawing.Point(24, 232)
        Me._lblTipo_3.Name = "_lblTipo_3"
        Me._lblTipo_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_3.Size = New System.Drawing.Size(145, 19)
        Me._lblTipo_3.TabIndex = 73
        Me._lblTipo_3.Text = "Thermal loads"
        '
        '_lblTipo_0
        '
        Me._lblTipo_0.BackColor = System.Drawing.SystemColors.Info
        Me._lblTipo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_0.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTipo_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblTipo_0.Location = New System.Drawing.Point(24, 64)
        Me._lblTipo_0.Name = "_lblTipo_0"
        Me._lblTipo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_0.Size = New System.Drawing.Size(145, 19)
        Me._lblTipo_0.TabIndex = 72
        Me._lblTipo_0.Text = "Total loads"
        '
        '_Label2_10
        '
        Me._Label2_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_10.Location = New System.Drawing.Point(8, 280)
        Me._Label2_10.Name = "_Label2_10"
        Me._Label2_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_10.Size = New System.Drawing.Size(199, 24)
        Me._Label2_10.TabIndex = 71
        Me._Label2_10.Text = "Label1"
        '
        '_Label2_9
        '
        Me._Label2_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_9.Location = New System.Drawing.Point(8, 256)
        Me._Label2_9.Name = "_Label2_9"
        Me._Label2_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_9.Size = New System.Drawing.Size(199, 24)
        Me._Label2_9.TabIndex = 70
        Me._Label2_9.Text = "Label1"
        '
        '_Label2_11
        '
        Me._Label2_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_11.Location = New System.Drawing.Point(8, 304)
        Me._Label2_11.Name = "_Label2_11"
        Me._Label2_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_11.Size = New System.Drawing.Size(199, 24)
        Me._Label2_11.TabIndex = 69
        Me._Label2_11.Text = "Label1"
        '
        '_Label2_12
        '
        Me._Label2_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_12.Location = New System.Drawing.Point(8, 328)
        Me._Label2_12.Name = "_Label2_12"
        Me._Label2_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_12.Size = New System.Drawing.Size(199, 24)
        Me._Label2_12.TabIndex = 68
        Me._Label2_12.Text = "Label1"
        '
        '_Label2_13
        '
        Me._Label2_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_13.Location = New System.Drawing.Point(8, 352)
        Me._Label2_13.Name = "_Label2_13"
        Me._Label2_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_13.Size = New System.Drawing.Size(199, 24)
        Me._Label2_13.TabIndex = 67
        Me._Label2_13.Text = "Label1"
        '
        '_Label2_14
        '
        Me._Label2_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_14.Location = New System.Drawing.Point(8, 376)
        Me._Label2_14.Name = "_Label2_14"
        Me._Label2_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_14.Size = New System.Drawing.Size(199, 24)
        Me._Label2_14.TabIndex = 66
        Me._Label2_14.Text = "Label1"
        '
        '_Label2_8
        '
        Me._Label2_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_8.Location = New System.Drawing.Point(8, 208)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(199, 24)
        Me._Label2_8.TabIndex = 65
        Me._Label2_8.Text = "Label1"
        '
        '_Label2_7
        '
        Me._Label2_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_7.Location = New System.Drawing.Point(8, 184)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(199, 24)
        Me._Label2_7.TabIndex = 64
        Me._Label2_7.Text = "Label1"
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_6.Location = New System.Drawing.Point(8, 160)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(199, 24)
        Me._Label2_6.TabIndex = 63
        Me._Label2_6.Text = "Label1"
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(8, 136)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(199, 24)
        Me._Label2_5.TabIndex = 62
        Me._Label2_5.Text = "Label1"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(8, 40)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(199, 24)
        Me._Label2_2.TabIndex = 61
        Me._Label2_2.Text = "Label1"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(8, 88)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(176, 24)
        Me._Label2_3.TabIndex = 60
        Me._Label2_3.Text = "Label1"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(8, 112)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(199, 19)
        Me._Label2_4.TabIndex = 59
        Me._Label2_4.Text = "Label1"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(8, 16)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(168, 24)
        Me._Label2_1.TabIndex = 58
        Me._Label2_1.Text = "Label1"
        '
        'TabStrip2
        '
        Me.TabStrip2.Controls.Add(Me.TabPage1)
        Me.TabStrip2.Location = New System.Drawing.Point(0, 0)
        Me.TabStrip2.Name = "TabStrip2"
        Me.TabStrip2.SelectedIndex = 0
        Me.TabStrip2.Size = New System.Drawing.Size(520, 448)
        Me.TabStrip2.TabIndex = 81
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(512, 422)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'frmCar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(582, 448)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabStrip2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdFatto)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmCar"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "WRCB - Carichi applicati"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmCar
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmCar
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmCar()
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
	Public Sub Aggiorna()
		Dim i As Short
		Label2(1).Text = "Load condition"
        Text2(1).Text = globalRoutines.Adjust(Geom(iB).Carichi(iC).CaseDescription, 20)
        Label2(2).Text = "Design Pressure"
        lblUni(2).Text = Config.Unit(5)
        Text2(2).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).DesPress, 2), 5, 3, False)
        rtx(2).Rtf = "{\rtf {\fs16  p\sub 0}}"
        Label2(3).Text = "Radial Load"
        lblUni(3).Text = Config.Unit(3)
        rtx(3).Rtf = "{\rtf {\fs16  P}}"
        Label2(5).Text = "Bending Moment (Long.Dir.) "
        lblUni(5).Text = Config.Unit(2)
        rtx(5).Rtf = "{\rtf {\fs16  M\sub L}}"
        Label2(6).Text = "Torsional Moment"
        lblUni(6).Text = Config.Unit(2)
        rtx(6).Rtf = "{\rtf {\fs16  M\sub t}}"
        Label2(8).Text = "Shear Load    (Long.Dir.)  "
        lblUni(8).Text = Config.Unit(3)
        rtx(8).Rtf = "{\rtf {\fs16  V\sub L}}"
        If Geom(iB).ShellType = 1 Then
            Label2(5).Visible = False
            Text2(5).Visible = False
            Text3(5).Visible = False
            lblUni(5).Visible = False
            rtx(5).Visible = False
            Label2(8).Visible = False
            Text2(8).Visible = False
            Text3(8).Visible = False
            lblUni(8).Visible = False
            rtx(8).Visible = False
            Label2(4).Text = "Bending Moment"
            lblUni(4).Text = Config.Unit(2)
            rtx(4).Rtf = "{\rtf {\fs16  M}}"
            Label2(7).Text = "Shear Load"
            lblUni(7).Text = Config.Unit(3)
            rtx(7).Rtf = "{\rtf {\fs16  V}}"
        Else
            Label2(5).Visible = True
            Text2(5).Visible = True
            Text3(5).Visible = True
            lblUni(5).Visible = True
            rtx(5).Visible = True
            Label2(8).Visible = True
            Text2(8).Visible = True
            Text3(8).Visible = True
            lblUni(8).Visible = True
            rtx(8).Visible = True
            Label2(4).Text = "Bending Moment (Circ.Dir.) "
            lblUni(4).Text = Config.Unit(2)
            rtx(4).Rtf = "{\rtf {\fs16  M\sub c}}"
            Label2(7).Text = "Shear Load    (Circ.Dir.)  "
            lblUni(7).Text = Config.Unit(3)
            rtx(7).Rtf = "{\rtf {\fs16  V\sub c}}"
        End If
        If Config.Analisi = 0 Then
            cmdGiven.Visible = True
            GroupBox1.Height = 240
            TabStrip2.Height = 280
            Height = 306
            lblTipo(3).Visible = False
            lblTipo(4).Visible = False
            lblTipo(5).Visible = False
            _cmdFinal_1.Visible = False
        Else
            cmdGiven.Visible = False
            GroupBox1.Height = 408
            TabStrip2.Height = 448
            Height = 474
            lblTipo(3).Visible = True
            lblTipo(4).Visible = True
            lblTipo(5).Visible = True
            _cmdFinal_1.Visible = True
            lblTipo(0).Text = "Dead loads"
            For i = 1 To 6
                Label2(i + 8).Text = Label2(i + 2).Text
                Label2(i + 8).Visible = Label2(i + 2).Visible
                rtx(i + 8).Rtf = rtx(i + 2).Rtf
                rtx(i + 8).Visible = rtx(i + 2).Visible
                lblUni(i + 8).Text = lblUni(i + 2).Text
                lblUni(i + 8).Visible = lblUni(i + 2).Visible
                Text2(i + 8).Visible = Text2(i + 2).Visible
                Text3(i + 8).Visible = Text3(i + 2).Visible
            Next
        End If 'o
        AggTesti()
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        OK = False
        Hide()
    End Sub

    Private Sub cmdFatto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFatto.Click
        Dim i As Short
        If Config.Analisi = 1 Then
            For iC = 1 To Geom(iB).Casi
                With Geom(iB).Carichi(iC)
                    For i = 1 To 6
                        .Load(i, 1) = .WLoad(i, 1) + .TLoad(i, 1)
                        .Load(i, 2) = .WLoad(i, 2) + .TLoad(i, 2)
                    Next
                End With
            Next
        End If
        OK = True
        Hide()
    End Sub

    Private Sub cmdFinal_Click(ByVal Index As Short)
        Dim Area, Thk, EndEffect As Single
        Dim Vc, AML, AMc, AMt, Vl As Single
        If Geom(iB).Buco = 0 Then Thk = TT Else Thk = 0
        If Geom(iB).Forma = 0 Then
            Area = PI * (RR - Thk) ^ 2
        Else
            Area = (Geom(iB).D1 - Thk) * (Geom(iB).D2 - Thk)
        End If 'i
        Geom(iB).Carichi(iC).Load(0, 2) = -Area * Geom(iB).Carichi(iC).DesPress
        Select Case Index
            Case 0
                If Config.Analisi = 0 Then
                    If Config.EndEffect Then
                        EndEffect = Geom(iB).Carichi(iC).Load(0, 2) + Geom(iB).Carichi(iC).Load(1, 1)
                    Else
                        EndEffect = Geom(iB).Carichi(iC).Load(1, 1)
                    End If
                    Vc = System.Math.Abs(Geom(iB).Carichi(iC).Load(5, 1))
                    Vl = System.Math.Abs(Geom(iB).Carichi(iC).Load(6, 1))
                    AMc = System.Math.Abs(Geom(iB).Carichi(iC).Load(2, 1)) + Geom(iB).Sporg * Vc * Config.Reduced
                    AML = System.Math.Abs(Geom(iB).Carichi(iC).Load(3, 1)) + Geom(iB).Sporg * Vl * Config.Reduced
                    AMt = System.Math.Abs(Geom(iB).Carichi(iC).Load(4, 1))
                    Geom(iB).Carichi(iC).Load(1, 2) = EndEffect
                    Geom(iB).Carichi(iC).Load(5, 2) = Vc
                    Geom(iB).Carichi(iC).Load(6, 2) = Vl
                    Geom(iB).Carichi(iC).Load(2, 2) = AMc
                    Geom(iB).Carichi(iC).Load(3, 2) = AML
                    Geom(iB).Carichi(iC).Load(4, 2) = AMt
                Else
                    If Config.EndEffect Then
                        EndEffect = Geom(iB).Carichi(iC).Load(0, 2) + Geom(iB).Carichi(iC).WLoad(1, 1)
                    Else
                        EndEffect = Geom(iB).Carichi(iC).WLoad(1, 1)
                    End If
                    Vc = System.Math.Abs(Geom(iB).Carichi(iC).WLoad(5, 1))
                    Vl = System.Math.Abs(Geom(iB).Carichi(iC).WLoad(6, 1))
                    AMc = System.Math.Abs(Geom(iB).Carichi(iC).WLoad(2, 1)) + Geom(iB).Sporg * Vc * Config.Reduced
                    AML = System.Math.Abs(Geom(iB).Carichi(iC).WLoad(3, 1)) + Geom(iB).Sporg * Vl * Config.Reduced
                    AMt = System.Math.Abs(Geom(iB).Carichi(iC).WLoad(4, 1))
                    Geom(iB).Carichi(iC).WLoad(1, 2) = EndEffect
                    Geom(iB).Carichi(iC).WLoad(5, 2) = Vc
                    Geom(iB).Carichi(iC).WLoad(6, 2) = Vl
                    Geom(iB).Carichi(iC).WLoad(2, 2) = AMc
                    Geom(iB).Carichi(iC).WLoad(3, 2) = AML
                    Geom(iB).Carichi(iC).WLoad(4, 2) = AMt
                End If
            Case 1
                EndEffect = Geom(iB).Carichi(iC).TLoad(1, 1)
                Vc = System.Math.Abs(Geom(iB).Carichi(iC).TLoad(5, 1))
                Vl = System.Math.Abs(Geom(iB).Carichi(iC).TLoad(6, 1))
                AMc = System.Math.Abs(Geom(iB).Carichi(iC).TLoad(2, 1)) + Geom(iB).Sporg * Vc * Config.Reduced
                AML = System.Math.Abs(Geom(iB).Carichi(iC).TLoad(3, 1)) + Geom(iB).Sporg * Vl * Config.Reduced
                AMt = System.Math.Abs(Geom(iB).Carichi(iC).TLoad(4, 1))
                Geom(iB).Carichi(iC).TLoad(1, 2) = EndEffect
                Geom(iB).Carichi(iC).TLoad(5, 2) = Vc
                Geom(iB).Carichi(iC).TLoad(6, 2) = Vl
                Geom(iB).Carichi(iC).TLoad(2, 2) = AMc
                Geom(iB).Carichi(iC).TLoad(3, 2) = AML
                Geom(iB).Carichi(iC).TLoad(4, 2) = AMt
        End Select
        AggTesti()
    End Sub
    Private Sub cmdGiven_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGiven.Click
        TrasfCar(0)
        AggTesti()
    End Sub
    Private Sub frmCar_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Text = Text & " su " & Trim(Geom(iB).Mark)
        If Config.Chart = 0 Then cmdGiven.Enabled = False
        Aggiorna()
    End Sub
    Private Sub AggTesti()
        Dim codice, i, Index As Short
        Try
            If Config.Analisi = 0 Then
                For i = 1 To 6
                    Index = i + 2
                    codice = Conv(Index)
                    Text2(i + 2).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).Load(i, 1), codice), 10, 2, False)
                    Text3(i + 2).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).Load(i, 2), codice), 10, 2, False)
                Next
            Else
                For i = 1 To 6
                    Index = i + 2
                    codice = Conv(Index)
                    Text2(i + 2).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).WLoad(i, 1), codice), 10, 2, False)
                    Text3(i + 2).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).WLoad(i, 2), codice), 10, 2, False)
                    Index = i + 8
                    codice = Conv(Index)
                    Text2(i + 8).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).TLoad(i, 1), codice), 10, 2, False)
                    Text3(i + 8).Text = globalRoutines.myStr(sConverti(Geom(iB).Carichi(iC).TLoad(i, 2), codice), 10, 2, False)
                Next
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function Conv(ByVal Index As Short) As Short
        Select Case Index
            Case 3, 7, 8, 9, 13, 14 : Conv = 3
            Case 4, 5, 6, 10, 11, 12 : Conv = 4
        End Select
    End Function
    Private Sub Text2_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim codice As Short
        Select Case Index
            Case 3, 7, 8, 9, 13, 14 : codice = 3
            Case 4, 5, 6, 10, 11, 12 : codice = 4
        End Select
        Select Case Index
            Case 1 : Geom(iB).Carichi(iC).CaseDescription = Text2(Index).Text
            Case 2 : Geom(iB).Carichi(iC).DesPress = Converti(Val(Text2(Index).Text), 2)
            Case 3 To 8
                If Config.Analisi = 0 Then
                    Geom(iB).Carichi(iC).Load(Index - 2, 1) = Converti(Val(Text2(Index).Text), codice)
                Else
                    Geom(iB).Carichi(iC).WLoad(Index - 2, 1) = Converti(Val(Text2(Index).Text), codice)
                End If
            Case 9 To 14
                Geom(iB).Carichi(iC).TLoad(Index - 8, 1) = Converti(Val(Text2(Index).Text), codice)
        End Select
    End Sub
    Private Sub Text3_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim codice As Short
        Select Case Index
            Case 3, 7, 8, 9, 13, 14 : codice = 3
            Case 4, 5, 6, 10, 11, 12 : codice = 4
        End Select
        Select Case Index
            Case 3 To 8
                If Config.Analisi = 0 Then
                    Geom(iB).Carichi(iC).Load(Index - 2, 2) = Converti(Val(Text3(Index).Text), codice)
                Else
                    Geom(iB).Carichi(iC).WLoad(Index - 2, 2) = Converti(Val(Text3(Index).Text), codice)
                End If
            Case 9 To 14
                Geom(iB).Carichi(iC).TLoad(Index - 8, 2) = Converti(Val(Text3(Index).Text), codice)
        End Select
    End Sub
    Friend ReadOnly Property Text2(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 1 : Return _Text2_1
                Case 2 : Return _Text2_2
                Case 3 : Return _Text2_3
                Case 4 : Return _Text2_4
                Case 5 : Return _Text2_5
                Case 6 : Return _Text2_6
                Case 7 : Return _Text2_7
                Case 8 : Return _Text2_8
                Case 9 : Return _Text2_9
                Case 10 : Return _Text2_10
                Case 11 : Return _Text2_11
                Case 12 : Return _Text2_12
                Case 13 : Return _Text2_13
                Case 14 : Return _Text2_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property Label2(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 1 : Return _Label2_1
                Case 2 : Return _Label2_2
                Case 3 : Return _Label2_3
                Case 4 : Return _Label2_4
                Case 5 : Return _Label2_5
                Case 6 : Return _Label2_6
                Case 7 : Return _Label2_7
                Case 8 : Return _Label2_8
                Case 9 : Return _Label2_9
                Case 10 : Return _Label2_10
                Case 11 : Return _Label2_11
                Case 12 : Return _Label2_12
                Case 13 : Return _Label2_13
                Case 14 : Return _Label2_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property lblUni(ByVal i As Integer) As Label
        Get
            Select Case i
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
                Case 12 : Return _lblUni_12
                Case 13 : Return _lblUni_13
                Case 14 : Return _lblUni_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property lblTipo(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _lblTipo_0
                Case 1 : Return _lblTipo_1
                Case 2 : Return _lblTipo_2
                Case 3 : Return _lblTipo_3
                Case 4 : Return _lblTipo_4
                Case 5 : Return _lblTipo_5
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property Text3(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 3 : Return _Text3_3
                Case 4 : Return _Text3_4
                Case 5 : Return _Text3_5
                Case 6 : Return _Text3_6
                Case 7 : Return _Text3_7
                Case 8 : Return _Text3_8
                Case 9 : Return _Text3_9
                Case 10 : Return _Text3_10
                Case 11 : Return _Text3_11
                Case 12 : Return _Text3_12
                Case 13 : Return _Text3_13
                Case 14 : Return _Text3_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property rtx(ByVal i As Integer) As RichTextBox
        Get
            Select Case i
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
                Case 12 : Return _rtx_12
                Case 13 : Return _rtx_13
                Case 14 : Return _rtx_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _Text2_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_1.TextChanged
        Text2_TextChanged(1)
    End Sub

    Private Sub _Text2_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_10.TextChanged
        Text2_TextChanged(10)
    End Sub

    Private Sub _Text2_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_11.TextChanged
        Text2_TextChanged(11)
    End Sub

    Private Sub _Text2_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_12.TextChanged
        Text2_TextChanged(12)
    End Sub

    Private Sub _Text2_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_13.TextChanged
        Text2_TextChanged(13)
    End Sub

    Private Sub _Text2_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_14.TextChanged
        Text2_TextChanged(14)
    End Sub

    Private Sub _Text2_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_2.TextChanged
        Text2_TextChanged(2)
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

    Private Sub _Text2_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_9.TextChanged
        Text2_TextChanged(9)
    End Sub

    Private Sub _Text3_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_10.TextChanged
        Text3_TextChanged(10)
    End Sub

    Private Sub _Text3_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_11.TextChanged
        Text3_TextChanged(11)
    End Sub

    Private Sub _Text3_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_12.TextChanged
        Text3_TextChanged(12)
    End Sub

    Private Sub _Text3_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_13.TextChanged
        Text3_TextChanged(13)
    End Sub

    Private Sub _Text3_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_14.TextChanged
        Text3_TextChanged(14)
    End Sub

    Private Sub _Text3_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_3.TextChanged
        Text3_TextChanged(3)
    End Sub

    Private Sub _Text3_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_4.TextChanged
        Text3_TextChanged(4)
    End Sub

    Private Sub _Text3_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_5.TextChanged
        Text3_TextChanged(5)
    End Sub

    Private Sub _Text3_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_6.TextChanged
        Text3_TextChanged(6)
    End Sub

    Private Sub _Text3_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_7.TextChanged
        Text3_TextChanged(7)
    End Sub

    Private Sub _Text3_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_8.TextChanged
        Text3_TextChanged(8)
    End Sub

    Private Sub _Text3_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text3_9.TextChanged
        Text3_TextChanged(9)
    End Sub

    Private Sub _Command2_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command2_3.Click
        Dim Testo As String = "Valori positivi: sforzo verso l'interno|"
        Testo = Testo & "Valori negativi: tiro verso l'esterno"
        MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information + MsgBoxStyle.OKOnly)

    End Sub

    Private Sub _cmdFinal_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdFinal_0.Click
        cmdFinal_Click(0)
    End Sub

    Private Sub _cmdFinal_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdFinal_1.Click
        cmdFinal_Click(1)
    End Sub
    Private Sub TabStrip2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabStrip2.Click
        iC = TabStrip2.SelectedIndex + 1
        Aggiorna()
    End Sub
End Class