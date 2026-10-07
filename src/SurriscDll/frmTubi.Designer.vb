<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTubi
#Region "Codice generato da Progettazione Windows Form "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Chiamata richiesta dalla progettazione Windows Form.
		InitializeComponent()
	End Sub
	'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _txtTemp_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtTemp_8 As System.Windows.Forms.TextBox
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label3_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label3_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label3_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label3_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label3_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label3_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents _Label3_0 As System.Windows.Forms.Label
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents _Label3_9 As System.Windows.Forms.Label
	Public Label1 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public Label3 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public txtTemp As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTubi))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me._txtTemp_6 = New System.Windows.Forms.TextBox
		Me._txtTemp_5 = New System.Windows.Forms.TextBox
		Me._txtTemp_4 = New System.Windows.Forms.TextBox
		Me._txtTemp_3 = New System.Windows.Forms.TextBox
		Me._txtTemp_2 = New System.Windows.Forms.TextBox
		Me._txtTemp_1 = New System.Windows.Forms.TextBox
		Me._txtTemp_0 = New System.Windows.Forms.TextBox
		Me._txtTemp_8 = New System.Windows.Forms.TextBox
		Me._Label1_6 = New System.Windows.Forms.Label
		Me._Label3_6 = New System.Windows.Forms.Label
		Me._Label1_5 = New System.Windows.Forms.Label
		Me._Label3_5 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label3_4 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label3_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label3_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label3_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me._Label3_0 = New System.Windows.Forms.Label
		Me._Label1_8 = New System.Windows.Forms.Label
		Me._Label3_9 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Verifica spessore tubi"
		Me.ClientSize = New System.Drawing.Size(312, 213)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmTubi"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Approvo"
		Me.Command2.Size = New System.Drawing.Size(55, 19)
		Me.Command2.Location = New System.Drawing.Point(252, 171)
		Me.Command2.TabIndex = 25
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Calcola"
		Me.Command1.Size = New System.Drawing.Size(55, 19)
		Me.Command1.Location = New System.Drawing.Point(252, 144)
		Me.Command1.TabIndex = 24
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me._txtTemp_6.AutoSize = False
		Me._txtTemp_6.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_6.Location = New System.Drawing.Point(148, 171)
		Me._txtTemp_6.TabIndex = 21
		Me._txtTemp_6.Text = " "
		Me._txtTemp_6.AcceptsReturn = True
		Me._txtTemp_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_6.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_6.CausesValidation = True
		Me._txtTemp_6.Enabled = True
		Me._txtTemp_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_6.HideSelection = True
		Me._txtTemp_6.ReadOnly = False
		Me._txtTemp_6.Maxlength = 0
		Me._txtTemp_6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_6.MultiLine = False
		Me._txtTemp_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_6.TabStop = True
		Me._txtTemp_6.Visible = True
		Me._txtTemp_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_6.Name = "_txtTemp_6"
		Me._txtTemp_5.AutoSize = False
		Me._txtTemp_5.Enabled = False
		Me._txtTemp_5.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_5.Location = New System.Drawing.Point(148, 144)
		Me._txtTemp_5.TabIndex = 18
		Me._txtTemp_5.Text = " "
		Me._txtTemp_5.AcceptsReturn = True
		Me._txtTemp_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_5.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_5.CausesValidation = True
		Me._txtTemp_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_5.HideSelection = True
		Me._txtTemp_5.ReadOnly = False
		Me._txtTemp_5.Maxlength = 0
		Me._txtTemp_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_5.MultiLine = False
		Me._txtTemp_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_5.TabStop = True
		Me._txtTemp_5.Visible = True
		Me._txtTemp_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_5.Name = "_txtTemp_5"
		Me._txtTemp_4.AutoSize = False
		Me._txtTemp_4.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_4.Location = New System.Drawing.Point(148, 108)
		Me._txtTemp_4.TabIndex = 15
		Me._txtTemp_4.Text = " "
		Me._txtTemp_4.AcceptsReturn = True
		Me._txtTemp_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_4.CausesValidation = True
		Me._txtTemp_4.Enabled = True
		Me._txtTemp_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_4.HideSelection = True
		Me._txtTemp_4.ReadOnly = False
		Me._txtTemp_4.Maxlength = 0
		Me._txtTemp_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_4.MultiLine = False
		Me._txtTemp_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_4.TabStop = True
		Me._txtTemp_4.Visible = True
		Me._txtTemp_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_4.Name = "_txtTemp_4"
		Me._txtTemp_3.AutoSize = False
		Me._txtTemp_3.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_3.Location = New System.Drawing.Point(148, 90)
		Me._txtTemp_3.TabIndex = 12
		Me._txtTemp_3.Text = " "
		Me._txtTemp_3.AcceptsReturn = True
		Me._txtTemp_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_3.CausesValidation = True
		Me._txtTemp_3.Enabled = True
		Me._txtTemp_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_3.HideSelection = True
		Me._txtTemp_3.ReadOnly = False
		Me._txtTemp_3.Maxlength = 0
		Me._txtTemp_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_3.MultiLine = False
		Me._txtTemp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_3.TabStop = True
		Me._txtTemp_3.Visible = True
		Me._txtTemp_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_3.Name = "_txtTemp_3"
		Me._txtTemp_2.AutoSize = False
		Me._txtTemp_2.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_2.Location = New System.Drawing.Point(148, 72)
		Me._txtTemp_2.TabIndex = 9
		Me._txtTemp_2.Text = " "
		Me._txtTemp_2.AcceptsReturn = True
		Me._txtTemp_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_2.CausesValidation = True
		Me._txtTemp_2.Enabled = True
		Me._txtTemp_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_2.HideSelection = True
		Me._txtTemp_2.ReadOnly = False
		Me._txtTemp_2.Maxlength = 0
		Me._txtTemp_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_2.MultiLine = False
		Me._txtTemp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_2.TabStop = True
		Me._txtTemp_2.Visible = True
		Me._txtTemp_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_2.Name = "_txtTemp_2"
		Me._txtTemp_1.AutoSize = False
		Me._txtTemp_1.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_1.Location = New System.Drawing.Point(148, 54)
		Me._txtTemp_1.TabIndex = 6
		Me._txtTemp_1.Text = " "
		Me._txtTemp_1.AcceptsReturn = True
		Me._txtTemp_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_1.CausesValidation = True
		Me._txtTemp_1.Enabled = True
		Me._txtTemp_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_1.HideSelection = True
		Me._txtTemp_1.ReadOnly = False
		Me._txtTemp_1.Maxlength = 0
		Me._txtTemp_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_1.MultiLine = False
		Me._txtTemp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_1.TabStop = True
		Me._txtTemp_1.Visible = True
		Me._txtTemp_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_1.Name = "_txtTemp_1"
		Me._txtTemp_0.AutoSize = False
		Me._txtTemp_0.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_0.Location = New System.Drawing.Point(148, 36)
		Me._txtTemp_0.TabIndex = 3
		Me._txtTemp_0.Text = " "
		Me._txtTemp_0.AcceptsReturn = True
		Me._txtTemp_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_0.CausesValidation = True
		Me._txtTemp_0.Enabled = True
		Me._txtTemp_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_0.HideSelection = True
		Me._txtTemp_0.ReadOnly = False
		Me._txtTemp_0.Maxlength = 0
		Me._txtTemp_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_0.MultiLine = False
		Me._txtTemp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_0.TabStop = True
		Me._txtTemp_0.Visible = True
		Me._txtTemp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_0.Name = "_txtTemp_0"
		Me._txtTemp_8.AutoSize = False
		Me._txtTemp_8.Enabled = False
		Me._txtTemp_8.Size = New System.Drawing.Size(57, 19)
		Me._txtTemp_8.Location = New System.Drawing.Point(148, 15)
		Me._txtTemp_8.TabIndex = 0
		Me._txtTemp_8.Text = " "
		Me._txtTemp_8.AcceptsReturn = True
		Me._txtTemp_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtTemp_8.BackColor = System.Drawing.SystemColors.Window
		Me._txtTemp_8.CausesValidation = True
		Me._txtTemp_8.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtTemp_8.HideSelection = True
		Me._txtTemp_8.ReadOnly = False
		Me._txtTemp_8.Maxlength = 0
		Me._txtTemp_8.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtTemp_8.MultiLine = False
		Me._txtTemp_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtTemp_8.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtTemp_8.TabStop = True
		Me._txtTemp_8.Visible = True
		Me._txtTemp_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtTemp_8.Name = "_txtTemp_8"
		Me._Label1_6.Text = "Spessore adottato"
		Me._Label1_6.Size = New System.Drawing.Size(132, 25)
		Me._Label1_6.Location = New System.Drawing.Point(9, 171)
		Me._Label1_6.TabIndex = 23
		Me._Label1_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_6.Enabled = True
		Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_6.UseMnemonic = True
		Me._Label1_6.Visible = True
		Me._Label1_6.AutoSize = False
		Me._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_6.Name = "_Label1_6"
		Me._Label3_6.BackColor = System.Drawing.Color.Cyan
		Me._Label3_6.Text = "mm"
		Me._Label3_6.Size = New System.Drawing.Size(26, 17)
		Me._Label3_6.Location = New System.Drawing.Point(212, 171)
		Me._Label3_6.TabIndex = 22
		Me._Label3_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_6.Enabled = True
		Me._Label3_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_6.UseMnemonic = True
		Me._Label3_6.Visible = True
		Me._Label3_6.AutoSize = False
		Me._Label3_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_6.Name = "_Label3_6"
		Me._Label1_5.Text = "Spessore minimo"
		Me._Label1_5.Size = New System.Drawing.Size(132, 25)
		Me._Label1_5.Location = New System.Drawing.Point(9, 144)
		Me._Label1_5.TabIndex = 20
		Me._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_5.Enabled = True
		Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_5.UseMnemonic = True
		Me._Label1_5.Visible = True
		Me._Label1_5.AutoSize = False
		Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_5.Name = "_Label1_5"
		Me._Label3_5.BackColor = System.Drawing.Color.Cyan
		Me._Label3_5.Text = "mm"
		Me._Label3_5.Size = New System.Drawing.Size(26, 17)
		Me._Label3_5.Location = New System.Drawing.Point(212, 144)
		Me._Label3_5.TabIndex = 19
		Me._Label3_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_5.Enabled = True
		Me._Label3_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_5.UseMnemonic = True
		Me._Label3_5.Visible = True
		Me._Label3_5.AutoSize = False
		Me._Label3_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_5.Name = "_Label3_5"
		Me._Label1_4.Text = "Tensione ammissibile"
		Me._Label1_4.Size = New System.Drawing.Size(132, 25)
		Me._Label1_4.Location = New System.Drawing.Point(9, 108)
		Me._Label1_4.TabIndex = 17
		Me._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_4.Enabled = True
		Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_4.UseMnemonic = True
		Me._Label1_4.Visible = True
		Me._Label1_4.AutoSize = False
		Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_4.Name = "_Label1_4"
		Me._Label3_4.BackColor = System.Drawing.Color.Cyan
		Me._Label3_4.Text = "MPa"
		Me._Label3_4.Size = New System.Drawing.Size(26, 17)
		Me._Label3_4.Location = New System.Drawing.Point(212, 108)
		Me._Label3_4.TabIndex = 16
		Me._Label3_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_4.Enabled = True
		Me._Label3_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_4.UseMnemonic = True
		Me._Label3_4.Visible = True
		Me._Label3_4.AutoSize = False
		Me._Label3_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_4.Name = "_Label3_4"
		Me._Label1_3.Text = "Corrosione"
		Me._Label1_3.Size = New System.Drawing.Size(132, 25)
		Me._Label1_3.Location = New System.Drawing.Point(9, 90)
		Me._Label1_3.TabIndex = 14
		Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_3.Enabled = True
		Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_3.UseMnemonic = True
		Me._Label1_3.Visible = True
		Me._Label1_3.AutoSize = False
		Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_3.Name = "_Label1_3"
		Me._Label3_3.BackColor = System.Drawing.Color.Cyan
		Me._Label3_3.Text = "mm"
		Me._Label3_3.Size = New System.Drawing.Size(26, 17)
		Me._Label3_3.Location = New System.Drawing.Point(212, 90)
		Me._Label3_3.TabIndex = 13
		Me._Label3_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_3.Enabled = True
		Me._Label3_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_3.UseMnemonic = True
		Me._Label3_3.Visible = True
		Me._Label3_3.AutoSize = False
		Me._Label3_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_3.Name = "_Label3_3"
		Me._Label1_2.Text = "Raggio di curvatura min."
		Me._Label1_2.Size = New System.Drawing.Size(132, 25)
		Me._Label1_2.Location = New System.Drawing.Point(9, 72)
		Me._Label1_2.TabIndex = 11
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_2.Enabled = True
		Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = False
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label3_2.BackColor = System.Drawing.Color.Cyan
		Me._Label3_2.Text = "mm"
		Me._Label3_2.Size = New System.Drawing.Size(26, 17)
		Me._Label3_2.Location = New System.Drawing.Point(212, 72)
		Me._Label3_2.TabIndex = 10
		Me._Label3_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_2.Enabled = True
		Me._Label3_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_2.UseMnemonic = True
		Me._Label3_2.Visible = True
		Me._Label3_2.AutoSize = False
		Me._Label3_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_2.Name = "_Label3_2"
		Me._Label1_1.Text = "Temperatura di progetto"
		Me._Label1_1.Size = New System.Drawing.Size(132, 25)
		Me._Label1_1.Location = New System.Drawing.Point(9, 54)
		Me._Label1_1.TabIndex = 8
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_1.Enabled = True
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label3_1.BackColor = System.Drawing.Color.Cyan
		Me._Label3_1.Text = "°C"
		Me._Label3_1.Size = New System.Drawing.Size(26, 17)
		Me._Label3_1.Location = New System.Drawing.Point(212, 54)
		Me._Label3_1.TabIndex = 7
		Me._Label3_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_1.Enabled = True
		Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_1.UseMnemonic = True
		Me._Label3_1.Visible = True
		Me._Label3_1.AutoSize = False
		Me._Label3_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_1.Name = "_Label3_1"
		Me._Label1_0.Text = "Pressione di progetto"
		Me._Label1_0.Size = New System.Drawing.Size(105, 25)
		Me._Label1_0.Location = New System.Drawing.Point(9, 36)
		Me._Label1_0.TabIndex = 5
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_0.Enabled = True
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me._Label3_0.BackColor = System.Drawing.Color.Cyan
		Me._Label3_0.Text = "bar g"
		Me._Label3_0.Size = New System.Drawing.Size(26, 17)
		Me._Label3_0.Location = New System.Drawing.Point(212, 36)
		Me._Label3_0.TabIndex = 4
		Me._Label3_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_0.Enabled = True
		Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_0.UseMnemonic = True
		Me._Label3_0.Visible = True
		Me._Label3_0.AutoSize = False
		Me._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_0.Name = "_Label3_0"
		Me._Label1_8.Text = "Diam. esterno tubi"
		Me._Label1_8.Size = New System.Drawing.Size(105, 25)
		Me._Label1_8.Location = New System.Drawing.Point(9, 15)
		Me._Label1_8.TabIndex = 2
		Me._Label1_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_8.Enabled = True
		Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_8.UseMnemonic = True
		Me._Label1_8.Visible = True
		Me._Label1_8.AutoSize = False
		Me._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_8.Name = "_Label1_8"
		Me._Label3_9.BackColor = System.Drawing.Color.Cyan
		Me._Label3_9.Text = "mm"
		Me._Label3_9.Size = New System.Drawing.Size(17, 17)
		Me._Label3_9.Location = New System.Drawing.Point(212, 15)
		Me._Label3_9.TabIndex = 1
		Me._Label3_9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_9.Enabled = True
		Me._Label3_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_9.UseMnemonic = True
		Me._Label3_9.Visible = True
		Me._Label3_9.AutoSize = False
		Me._Label3_9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_9.Name = "_Label3_9"
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
		Me.Controls.Add(_txtTemp_6)
		Me.Controls.Add(_txtTemp_5)
		Me.Controls.Add(_txtTemp_4)
		Me.Controls.Add(_txtTemp_3)
		Me.Controls.Add(_txtTemp_2)
		Me.Controls.Add(_txtTemp_1)
		Me.Controls.Add(_txtTemp_0)
		Me.Controls.Add(_txtTemp_8)
		Me.Controls.Add(_Label1_6)
		Me.Controls.Add(_Label3_6)
		Me.Controls.Add(_Label1_5)
		Me.Controls.Add(_Label3_5)
		Me.Controls.Add(_Label1_4)
		Me.Controls.Add(_Label3_4)
		Me.Controls.Add(_Label1_3)
		Me.Controls.Add(_Label3_3)
		Me.Controls.Add(_Label1_2)
		Me.Controls.Add(_Label3_2)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label3_1)
		Me.Controls.Add(_Label1_0)
		Me.Controls.Add(_Label3_0)
		Me.Controls.Add(_Label1_8)
		Me.Controls.Add(_Label3_9)
		Me.Label1.Add(6, _Label1_6)
		Me.Label1.Add(5, _Label1_5)
		Me.Label1.Add(4, _Label1_4)
		Me.Label1.Add(3, _Label1_3)
		Me.Label1.Add(2, _Label1_2)
		Me.Label1.Add(1, _Label1_1)
		Me.Label1.Add(0, _Label1_0)
		Me.Label1.Add(8, _Label1_8)
		Me.Label3.Add(6, _Label3_6)
		Me.Label3.Add(5, _Label3_5)
		Me.Label3.Add(4, _Label3_4)
		Me.Label3.Add(3, _Label3_3)
		Me.Label3.Add(2, _Label3_2)
		Me.Label3.Add(1, _Label3_1)
		Me.Label3.Add(0, _Label3_0)
		Me.Label3.Add(9, _Label3_9)
		Me.txtTemp.Add(6, _txtTemp_6)
		Me.txtTemp.Add(5, _txtTemp_5)
		Me.txtTemp.Add(4, _txtTemp_4)
		Me.txtTemp.Add(3, _txtTemp_3)
		Me.txtTemp.Add(2, _txtTemp_2)
		Me.txtTemp.Add(1, _txtTemp_1)
		Me.txtTemp.Add(0, _txtTemp_0)
		Me.txtTemp.Add(8, _txtTemp_8)
        For Each control In txtTemp.Values
            AddHandler control.TextChanged, AddressOf txtTemp_TextChanged
        Next


		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class