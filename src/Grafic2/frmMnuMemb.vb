Option Strict Off
Option Explicit On
Friend Class frmMnuMemb
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
	Public WithEvents _Option1_19 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_27 As System.Windows.Forms.RadioButton
	Public WithEvents _Command1_2 As System.Windows.Forms.Button
	Public WithEvents _Command1_1 As System.Windows.Forms.Button
	Public WithEvents _Command1_0 As System.Windows.Forms.Button
	Public WithEvents _Option1_26 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_25 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_24 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_23 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_22 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_21 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_20 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_18 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_17 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_16 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_15 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_14 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_13 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_12 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_11 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_10 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_9 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_8 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_7 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_6 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_5 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_4 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_3 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public Command1 As New System.Collections.Generic.Dictionary(Of Integer, Button)
	Public Option1 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMnuMemb))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me._Option1_19 = New System.Windows.Forms.RadioButton
		Me._Option1_27 = New System.Windows.Forms.RadioButton
		Me._Command1_2 = New System.Windows.Forms.Button
		Me._Command1_1 = New System.Windows.Forms.Button
		Me._Command1_0 = New System.Windows.Forms.Button
		Me._Option1_26 = New System.Windows.Forms.RadioButton
		Me._Option1_25 = New System.Windows.Forms.RadioButton
		Me._Option1_24 = New System.Windows.Forms.RadioButton
		Me._Option1_23 = New System.Windows.Forms.RadioButton
		Me._Option1_22 = New System.Windows.Forms.RadioButton
		Me._Option1_21 = New System.Windows.Forms.RadioButton
		Me._Option1_20 = New System.Windows.Forms.RadioButton
		Me._Option1_18 = New System.Windows.Forms.RadioButton
		Me._Option1_17 = New System.Windows.Forms.RadioButton
		Me._Option1_16 = New System.Windows.Forms.RadioButton
		Me._Option1_15 = New System.Windows.Forms.RadioButton
		Me._Option1_14 = New System.Windows.Forms.RadioButton
		Me._Option1_13 = New System.Windows.Forms.RadioButton
		Me._Option1_12 = New System.Windows.Forms.RadioButton
		Me._Option1_11 = New System.Windows.Forms.RadioButton
		Me._Option1_10 = New System.Windows.Forms.RadioButton
		Me._Option1_9 = New System.Windows.Forms.RadioButton
		Me._Option1_8 = New System.Windows.Forms.RadioButton
		Me._Option1_7 = New System.Windows.Forms.RadioButton
		Me._Option1_6 = New System.Windows.Forms.RadioButton
		Me._Option1_5 = New System.Windows.Forms.RadioButton
		Me._Option1_4 = New System.Windows.Forms.RadioButton
		Me._Option1_3 = New System.Windows.Forms.RadioButton
		Me._Option1_2 = New System.Windows.Forms.RadioButton
		Me._Option1_1 = New System.Windows.Forms.RadioButton
		Me._Option1_0 = New System.Windows.Forms.RadioButton
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Inserimento nuova membratura"
		Me.ClientSize = New System.Drawing.Size(232, 489)
		Me.Location = New System.Drawing.Point(65, 25)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMnuMemb"
		Me._Option1_19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_19.Text = "Riduzioni"
		Me._Option1_19.Size = New System.Drawing.Size(225, 17)
		Me._Option1_19.Location = New System.Drawing.Point(0, 352)
		Me._Option1_19.TabIndex = 30
		Me._Option1_19.Tag = "46"
		Me._Option1_19.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_19.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_19.CausesValidation = True
		Me._Option1_19.Enabled = True
		Me._Option1_19.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_19.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_19.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_19.TabStop = True
		Me._Option1_19.Checked = False
		Me._Option1_19.Visible = True
		Me._Option1_19.Name = "_Option1_19"
		Me._Option1_27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_27.Text = "Setti partitori"
		Me._Option1_27.Size = New System.Drawing.Size(225, 17)
		Me._Option1_27.Location = New System.Drawing.Point(0, 400)
		Me._Option1_27.TabIndex = 29
		Me._Option1_27.Tag = "37"
		Me._Option1_27.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_27.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_27.CausesValidation = True
		Me._Option1_27.Enabled = True
		Me._Option1_27.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_27.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_27.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_27.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_27.TabStop = True
		Me._Option1_27.Checked = False
		Me._Option1_27.Visible = True
		Me._Option1_27.Name = "_Option1_27"
		Me._Command1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._Command1_2.Text = "Aiuto"
		Me._Command1_2.Size = New System.Drawing.Size(73, 25)
		Me._Command1_2.Location = New System.Drawing.Point(152, 464)
		Me._Command1_2.TabIndex = 28
		Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
		Me._Command1_2.CausesValidation = True
		Me._Command1_2.Enabled = True
		Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Command1_2.TabStop = True
		Me._Command1_2.Name = "_Command1_2"
		Me._Command1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._Command1_1.Text = "Annulla"
		Me._Command1_1.Size = New System.Drawing.Size(73, 25)
		Me._Command1_1.Location = New System.Drawing.Point(72, 464)
		Me._Command1_1.TabIndex = 27
		Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Command1_1.CausesValidation = True
		Me._Command1_1.Enabled = True
		Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Command1_1.TabStop = True
		Me._Command1_1.Name = "_Command1_1"
		Me._Command1_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._Command1_0.Text = "Accetta"
		Me.AcceptButton = Me._Command1_0
		Me._Command1_0.Size = New System.Drawing.Size(73, 25)
		Me._Command1_0.Location = New System.Drawing.Point(-8, 464)
		Me._Command1_0.TabIndex = 26
		Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Command1_0.CausesValidation = True
		Me._Command1_0.Enabled = True
		Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Command1_0.TabStop = True
		Me._Command1_0.Name = "_Command1_0"
		Me._Option1_26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_26.Text = "Guarnizioni"
		Me._Option1_26.Size = New System.Drawing.Size(225, 17)
		Me._Option1_26.Location = New System.Drawing.Point(0, 128)
		Me._Option1_26.TabIndex = 25
		Me._Option1_26.Tag = "28"
		Me._Option1_26.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_26.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_26.CausesValidation = True
		Me._Option1_26.Enabled = True
		Me._Option1_26.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_26.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_26.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_26.TabStop = True
		Me._Option1_26.Checked = False
		Me._Option1_26.Visible = True
		Me._Option1_26.Name = "_Option1_26"
		Me._Option1_25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_25.Text = "Tappi forgiati"
		Me._Option1_25.Size = New System.Drawing.Size(225, 17)
		Me._Option1_25.Location = New System.Drawing.Point(0, 384)
		Me._Option1_25.TabIndex = 24
		Me._Option1_25.Tag = "29"
		Me._Option1_25.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_25.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_25.CausesValidation = True
		Me._Option1_25.Enabled = True
		Me._Option1_25.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_25.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_25.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_25.TabStop = True
		Me._Option1_25.Checked = False
		Me._Option1_25.Visible = True
		Me._Option1_25.Name = "_Option1_25"
		Me._Option1_24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_24.Text = "Manicotti forgiati"
		Me._Option1_24.Size = New System.Drawing.Size(225, 17)
		Me._Option1_24.Location = New System.Drawing.Point(0, 368)
		Me._Option1_24.TabIndex = 23
		Me._Option1_24.Tag = "27"
		Me._Option1_24.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_24.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_24.CausesValidation = True
		Me._Option1_24.Enabled = True
		Me._Option1_24.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_24.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_24.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_24.TabStop = True
		Me._Option1_24.Checked = False
		Me._Option1_24.Visible = True
		Me._Option1_24.Name = "_Option1_24"
		Me._Option1_23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_23.Text = "Fasci tubieri"
		Me._Option1_23.Size = New System.Drawing.Size(225, 17)
		Me._Option1_23.Location = New System.Drawing.Point(0, 176)
		Me._Option1_23.TabIndex = 22
		Me._Option1_23.Tag = "26"
		Me._Option1_23.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_23.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_23.CausesValidation = True
		Me._Option1_23.Enabled = True
		Me._Option1_23.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_23.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_23.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_23.TabStop = True
		Me._Option1_23.Checked = False
		Me._Option1_23.Visible = True
		Me._Option1_23.Name = "_Option1_23"
		Me._Option1_22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_22.Text = "Supporti"
		Me._Option1_22.Size = New System.Drawing.Size(225, 17)
		Me._Option1_22.Location = New System.Drawing.Point(0, 432)
		Me._Option1_22.TabIndex = 21
		Me._Option1_22.Tag = "25"
		Me._Option1_22.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_22.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_22.CausesValidation = True
		Me._Option1_22.Enabled = True
		Me._Option1_22.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_22.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_22.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_22.TabStop = True
		Me._Option1_22.Checked = False
		Me._Option1_22.Visible = True
		Me._Option1_22.Name = "_Option1_22"
		Me._Option1_21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_21.Text = "Varie"
		Me._Option1_21.Size = New System.Drawing.Size(225, 17)
		Me._Option1_21.Location = New System.Drawing.Point(0, 416)
		Me._Option1_21.TabIndex = 20
		Me._Option1_21.Tag = "24"
		Me._Option1_21.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_21.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_21.CausesValidation = True
		Me._Option1_21.Enabled = True
		Me._Option1_21.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_21.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_21.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_21.TabStop = True
		Me._Option1_21.Checked = False
		Me._Option1_21.Visible = True
		Me._Option1_21.Name = "_Option1_21"
		Me._Option1_20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_20.Text = "Tondi"
		Me._Option1_20.Size = New System.Drawing.Size(225, 17)
		Me._Option1_20.Location = New System.Drawing.Point(0, 224)
		Me._Option1_20.TabIndex = 19
		Me._Option1_20.Tag = "23"
		Me._Option1_20.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_20.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_20.CausesValidation = True
		Me._Option1_20.Enabled = True
		Me._Option1_20.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_20.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_20.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_20.TabStop = True
		Me._Option1_20.Checked = False
		Me._Option1_20.Visible = True
		Me._Option1_20.Name = "_Option1_20"
		Me._Option1_18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_18.Text = "Curve"
		Me._Option1_18.Size = New System.Drawing.Size(225, 17)
		Me._Option1_18.Location = New System.Drawing.Point(0, 336)
		Me._Option1_18.TabIndex = 18
		Me._Option1_18.Tag = "21"
		Me._Option1_18.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_18.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_18.CausesValidation = True
		Me._Option1_18.Enabled = True
		Me._Option1_18.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_18.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_18.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_18.TabStop = True
		Me._Option1_18.Checked = False
		Me._Option1_18.Visible = True
		Me._Option1_18.Name = "_Option1_18"
		Me._Option1_17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_17.Text = "Casse a bicchiere"
		Me._Option1_17.Size = New System.Drawing.Size(225, 17)
		Me._Option1_17.Location = New System.Drawing.Point(0, 304)
		Me._Option1_17.TabIndex = 17
		Me._Option1_17.Tag = "20"
		Me._Option1_17.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_17.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_17.CausesValidation = True
		Me._Option1_17.Enabled = True
		Me._Option1_17.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_17.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_17.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_17.TabStop = True
		Me._Option1_17.Checked = False
		Me._Option1_17.Visible = True
		Me._Option1_17.Name = "_Option1_17"
		Me._Option1_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_16.Text = "Diaframmi e piatti forati"
		Me._Option1_16.Size = New System.Drawing.Size(225, 17)
		Me._Option1_16.Location = New System.Drawing.Point(0, 240)
		Me._Option1_16.TabIndex = 16
		Me._Option1_16.Tag = "19"
		Me._Option1_16.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_16.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_16.CausesValidation = True
		Me._Option1_16.Enabled = True
		Me._Option1_16.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_16.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_16.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_16.TabStop = True
		Me._Option1_16.Checked = False
		Me._Option1_16.Visible = True
		Me._Option1_16.Name = "_Option1_16"
		Me._Option1_15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_15.Text = "Dilatatori"
		Me._Option1_15.Size = New System.Drawing.Size(225, 17)
		Me._Option1_15.Location = New System.Drawing.Point(0, 288)
		Me._Option1_15.TabIndex = 15
		Me._Option1_15.Tag = "18"
		Me._Option1_15.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_15.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_15.CausesValidation = True
		Me._Option1_15.Enabled = True
		Me._Option1_15.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_15.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_15.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_15.TabStop = True
		Me._Option1_15.Checked = False
		Me._Option1_15.Visible = True
		Me._Option1_15.Name = "_Option1_15"
		Me._Option1_14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_14.Text = "Anelli da lamiera"
		Me._Option1_14.Size = New System.Drawing.Size(225, 17)
		Me._Option1_14.Location = New System.Drawing.Point(0, 272)
		Me._Option1_14.TabIndex = 14
		Me._Option1_14.Tag = "17"
		Me._Option1_14.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_14.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_14.CausesValidation = True
		Me._Option1_14.Enabled = True
		Me._Option1_14.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_14.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_14.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_14.TabStop = True
		Me._Option1_14.Checked = False
		Me._Option1_14.Visible = True
		Me._Option1_14.Name = "_Option1_14"
		Me._Option1_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_13.Text = "Dischi / calotte / fondi piani"
		Me._Option1_13.Size = New System.Drawing.Size(225, 17)
		Me._Option1_13.Location = New System.Drawing.Point(0, 64)
		Me._Option1_13.TabIndex = 13
		Me._Option1_13.Tag = "16"
		Me._Option1_13.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_13.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_13.CausesValidation = True
		Me._Option1_13.Enabled = True
		Me._Option1_13.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_13.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_13.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_13.TabStop = True
		Me._Option1_13.Checked = False
		Me._Option1_13.Visible = True
		Me._Option1_13.Name = "_Option1_13"
		Me._Option1_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_12.Text = "Lamiere piane"
		Me._Option1_12.Size = New System.Drawing.Size(225, 17)
		Me._Option1_12.Location = New System.Drawing.Point(0, 256)
		Me._Option1_12.TabIndex = 12
		Me._Option1_12.Tag = "15"
		Me._Option1_12.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_12.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_12.CausesValidation = True
		Me._Option1_12.Enabled = True
		Me._Option1_12.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_12.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_12.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_12.TabStop = True
		Me._Option1_12.Checked = False
		Me._Option1_12.Visible = True
		Me._Option1_12.Name = "_Option1_12"
		Me._Option1_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_11.Text = "Bocchelli integrali da forgiato"
		Me._Option1_11.Size = New System.Drawing.Size(225, 17)
		Me._Option1_11.Location = New System.Drawing.Point(0, 160)
		Me._Option1_11.TabIndex = 11
		Me._Option1_11.Tag = "14"
		Me._Option1_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_11.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_11.CausesValidation = True
		Me._Option1_11.Enabled = True
		Me._Option1_11.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_11.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_11.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_11.TabStop = True
		Me._Option1_11.Checked = False
		Me._Option1_11.Visible = True
		Me._Option1_11.Name = "_Option1_11"
		Me._Option1_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_10.Text = "Tiranteria metrica / ANSI"
		Me._Option1_10.Size = New System.Drawing.Size(225, 17)
		Me._Option1_10.Location = New System.Drawing.Point(0, 112)
		Me._Option1_10.TabIndex = 10
		Me._Option1_10.Tag = "13"
		Me._Option1_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_10.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_10.CausesValidation = True
		Me._Option1_10.Enabled = True
		Me._Option1_10.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_10.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_10.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_10.TabStop = True
		Me._Option1_10.Checked = False
		Me._Option1_10.Visible = True
		Me._Option1_10.Name = "_Option1_10"
		Me._Option1_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_9.Text = "Piastre tubiere / coperchi piani"
		Me._Option1_9.Size = New System.Drawing.Size(225, 17)
		Me._Option1_9.Location = New System.Drawing.Point(0, 96)
		Me._Option1_9.TabIndex = 9
		Me._Option1_9.Tag = "12"
		Me._Option1_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_9.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_9.CausesValidation = True
		Me._Option1_9.Enabled = True
		Me._Option1_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_9.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_9.TabStop = True
		Me._Option1_9.Checked = False
		Me._Option1_9.Visible = True
		Me._Option1_9.Name = "_Option1_9"
		Me._Option1_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_8.Text = "Flangioni / anelli fucinati"
		Me._Option1_8.Size = New System.Drawing.Size(225, 17)
		Me._Option1_8.Location = New System.Drawing.Point(0, 80)
		Me._Option1_8.TabIndex = 8
		Me._Option1_8.Tag = "11"
		Me._Option1_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_8.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_8.CausesValidation = True
		Me._Option1_8.Enabled = True
		Me._Option1_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_8.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_8.TabStop = True
		Me._Option1_8.Checked = False
		Me._Option1_8.Visible = True
		Me._Option1_8.Name = "_Option1_8"
		Me._Option1_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_7.Text = "Bocchelli con flangia standard"
		Me._Option1_7.Size = New System.Drawing.Size(225, 17)
		Me._Option1_7.Location = New System.Drawing.Point(0, 144)
		Me._Option1_7.TabIndex = 7
		Me._Option1_7.Tag = "10"
		Me._Option1_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_7.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_7.CausesValidation = True
		Me._Option1_7.Enabled = True
		Me._Option1_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_7.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_7.TabStop = True
		Me._Option1_7.Checked = False
		Me._Option1_7.Visible = True
		Me._Option1_7.Name = "_Option1_7"
		Me._Option1_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_6.Text = "Tubi ad U"
		Me._Option1_6.Size = New System.Drawing.Size(225, 17)
		Me._Option1_6.Location = New System.Drawing.Point(0, 208)
		Me._Option1_6.TabIndex = 6
		Me._Option1_6.Tag = "9"
		Me._Option1_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_6.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_6.CausesValidation = True
		Me._Option1_6.Enabled = True
		Me._Option1_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_6.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_6.TabStop = True
		Me._Option1_6.Checked = False
		Me._Option1_6.Visible = True
		Me._Option1_6.Name = "_Option1_6"
		Me._Option1_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_5.Text = "Tubi scambiatori / distanziatori"
		Me._Option1_5.Size = New System.Drawing.Size(225, 17)
		Me._Option1_5.Location = New System.Drawing.Point(0, 192)
		Me._Option1_5.TabIndex = 5
		Me._Option1_5.Tag = "8"
		Me._Option1_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_5.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_5.CausesValidation = True
		Me._Option1_5.Enabled = True
		Me._Option1_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_5.TabStop = True
		Me._Option1_5.Checked = False
		Me._Option1_5.Visible = True
		Me._Option1_5.Name = "_Option1_5"
		Me._Option1_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_4.Text = "Coni"
		Me._Option1_4.Size = New System.Drawing.Size(225, 17)
		Me._Option1_4.Location = New System.Drawing.Point(0, 16)
		Me._Option1_4.TabIndex = 4
		Me._Option1_4.Tag = "7"
		Me._Option1_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_4.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_4.CausesValidation = True
		Me._Option1_4.Enabled = True
		Me._Option1_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_4.TabStop = True
		Me._Option1_4.Checked = False
		Me._Option1_4.Visible = True
		Me._Option1_4.Name = "_Option1_4"
		Me._Option1_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_3.Text = "Conoidi"
		Me._Option1_3.Size = New System.Drawing.Size(225, 17)
		Me._Option1_3.Location = New System.Drawing.Point(0, 32)
		Me._Option1_3.TabIndex = 3
		Me._Option1_3.Tag = "6"
		Me._Option1_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_3.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_3.CausesValidation = True
		Me._Option1_3.Enabled = True
		Me._Option1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_3.TabStop = True
		Me._Option1_3.Checked = False
		Me._Option1_3.Visible = True
		Me._Option1_3.Name = "_Option1_3"
		Me._Option1_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_2.Text = "Fondi"
		Me._Option1_2.Size = New System.Drawing.Size(225, 17)
		Me._Option1_2.Location = New System.Drawing.Point(0, 48)
		Me._Option1_2.TabIndex = 2
		Me._Option1_2.Tag = "3"
		Me._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_2.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_2.CausesValidation = True
		Me._Option1_2.Enabled = True
		Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_2.TabStop = True
		Me._Option1_2.Checked = False
		Me._Option1_2.Visible = True
		Me._Option1_2.Name = "_Option1_2"
		Me._Option1_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_1.Text = "Tubi (tronchetti)"
		Me._Option1_1.Size = New System.Drawing.Size(225, 17)
		Me._Option1_1.Location = New System.Drawing.Point(0, 320)
		Me._Option1_1.TabIndex = 1
		Me._Option1_1.Tag = "2"
		Me._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_1.CausesValidation = True
		Me._Option1_1.Enabled = True
		Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_1.TabStop = True
		Me._Option1_1.Checked = False
		Me._Option1_1.Visible = True
		Me._Option1_1.Name = "_Option1_1"
		Me._Option1_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_0.Text = "Cilindri/Virole fucinate"
		Me._Option1_0.Size = New System.Drawing.Size(225, 17)
		Me._Option1_0.Location = New System.Drawing.Point(0, 0)
		Me._Option1_0.TabIndex = 0
		Me._Option1_0.Tag = "1"
		Me._Option1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_0.CausesValidation = True
		Me._Option1_0.Enabled = True
		Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_0.TabStop = True
		Me._Option1_0.Checked = False
		Me._Option1_0.Visible = True
		Me._Option1_0.Name = "_Option1_0"
		Me.Controls.Add(_Option1_19)
		Me.Controls.Add(_Option1_27)
		Me.Controls.Add(_Command1_2)
		Me.Controls.Add(_Command1_1)
		Me.Controls.Add(_Command1_0)
		Me.Controls.Add(_Option1_26)
		Me.Controls.Add(_Option1_25)
		Me.Controls.Add(_Option1_24)
		Me.Controls.Add(_Option1_23)
		Me.Controls.Add(_Option1_22)
		Me.Controls.Add(_Option1_21)
		Me.Controls.Add(_Option1_20)
		Me.Controls.Add(_Option1_18)
		Me.Controls.Add(_Option1_17)
		Me.Controls.Add(_Option1_16)
		Me.Controls.Add(_Option1_15)
		Me.Controls.Add(_Option1_14)
		Me.Controls.Add(_Option1_13)
		Me.Controls.Add(_Option1_12)
		Me.Controls.Add(_Option1_11)
		Me.Controls.Add(_Option1_10)
		Me.Controls.Add(_Option1_9)
		Me.Controls.Add(_Option1_8)
		Me.Controls.Add(_Option1_7)
		Me.Controls.Add(_Option1_6)
		Me.Controls.Add(_Option1_5)
		Me.Controls.Add(_Option1_4)
		Me.Controls.Add(_Option1_3)
		Me.Controls.Add(_Option1_2)
		Me.Controls.Add(_Option1_1)
		Me.Controls.Add(_Option1_0)
		Me.Command1.Add(2, _Command1_2)
		Me.Command1.Add(1, _Command1_1)
		Me.Command1.Add(0, _Command1_0)
		Me.Option1.Add(19, _Option1_19)
		Me.Option1.Add(27, _Option1_27)
		Me.Option1.Add(26, _Option1_26)
		Me.Option1.Add(25, _Option1_25)
		Me.Option1.Add(24, _Option1_24)
		Me.Option1.Add(23, _Option1_23)
		Me.Option1.Add(22, _Option1_22)
		Me.Option1.Add(21, _Option1_21)
		Me.Option1.Add(20, _Option1_20)
		Me.Option1.Add(18, _Option1_18)
		Me.Option1.Add(17, _Option1_17)
		Me.Option1.Add(16, _Option1_16)
		Me.Option1.Add(15, _Option1_15)
		Me.Option1.Add(14, _Option1_14)
		Me.Option1.Add(13, _Option1_13)
		Me.Option1.Add(12, _Option1_12)
		Me.Option1.Add(11, _Option1_11)
		Me.Option1.Add(10, _Option1_10)
		Me.Option1.Add(9, _Option1_9)
		Me.Option1.Add(8, _Option1_8)
		Me.Option1.Add(7, _Option1_7)
		Me.Option1.Add(6, _Option1_6)
		Me.Option1.Add(5, _Option1_5)
		Me.Option1.Add(4, _Option1_4)
		Me.Option1.Add(3, _Option1_3)
		Me.Option1.Add(2, _Option1_2)
		Me.Option1.Add(1, _Option1_1)
		Me.Option1.Add(0, _Option1_0)
        For Each control In Option1.Values
            AddHandler control.CheckedChanged, AddressOf Option1_CheckedChanged
        Next
        For Each control In Command1.Values
            AddHandler control.Click, AddressOf Command1_Click
        Next
	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmMnuMemb
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMnuMemb
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMnuMemb()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Dim Index As Short = IndexedControls.IndexOf(Command1, eventSender)
		Select Case Index
			Case 0 'OK
			Case 1 'Annulla
				Funzioni.membratura = 0
			Case 2 'Help
		End Select
        Hide()
	End Sub
	
	'UPGRADE_WARNING: Form evento frmMnuMemb.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmMnuMemb_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		option1(0).Checked = True
		Option1_CheckedChanged(Option1.Item(0), New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		If eventSender.Checked Then
			Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
			Funzioni.membratura = Val(option1(Index).Tag)
			Funzioni.Lato = 0
		End If
	End Sub
End Class