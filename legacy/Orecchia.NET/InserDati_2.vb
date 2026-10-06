Option Strict Off
Option Explicit On
Friend Class InserDati_2
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
	Public WithEvents Indietro As System.Windows.Forms.Button
	Public WithEvents Avanti As System.Windows.Forms.Button
	Public WithEvents We2t As System.Windows.Forms.TextBox
	Public WithEvents dft As System.Windows.Forms.TextBox
	Public WithEvents R1t As System.Windows.Forms.TextBox
	Public WithEvents L10t As System.Windows.Forms.TextBox
	Public WithEvents t4t As System.Windows.Forms.TextBox
	Public WithEvents l2t As System.Windows.Forms.TextBox
	Public WithEvents l1t As System.Windows.Forms.TextBox
	Public WithEvents Qt As System.Windows.Forms.TextBox
	Public WithEvents B2t As System.Windows.Forms.TextBox
	Public WithEvents B1t As System.Windows.Forms.TextBox
	Public WithEvents alphat As System.Windows.Forms.TextBox
	Public WithEvents et2 As System.Windows.Forms.TextBox
	Public WithEvents wt As System.Windows.Forms.TextBox
	Public WithEvents Image2 As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Titolo As System.Windows.Forms.Label
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InserDati_2))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Indietro = New System.Windows.Forms.Button
		Me.Avanti = New System.Windows.Forms.Button
		Me.We2t = New System.Windows.Forms.TextBox
		Me.dft = New System.Windows.Forms.TextBox
		Me.R1t = New System.Windows.Forms.TextBox
		Me.L10t = New System.Windows.Forms.TextBox
		Me.t4t = New System.Windows.Forms.TextBox
		Me.l2t = New System.Windows.Forms.TextBox
		Me.l1t = New System.Windows.Forms.TextBox
		Me.Qt = New System.Windows.Forms.TextBox
		Me.B2t = New System.Windows.Forms.TextBox
		Me.B1t = New System.Windows.Forms.TextBox
		Me.alphat = New System.Windows.Forms.TextBox
		Me.et2 = New System.Windows.Forms.TextBox
		Me.wt = New System.Windows.Forms.TextBox
		Me.Image2 = New System.Windows.Forms.PictureBox
		Me.Image1 = New System.Windows.Forms.PictureBox
		Me.Label13 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Titolo = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Orecchia"
		Me.ClientSize = New System.Drawing.Size(735, 414)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("InserDati_2.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "InserDati_2"
		Me.Indietro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Indietro.Text = "<-- Indietro"
		Me.Indietro.Size = New System.Drawing.Size(97, 25)
		Me.Indietro.Location = New System.Drawing.Point(16, 384)
		Me.Indietro.TabIndex = 28
		Me.ToolTip1.SetToolTip(Me.Indietro, "Passa alla schermata precedente")
		Me.Indietro.BackColor = System.Drawing.SystemColors.Control
		Me.Indietro.CausesValidation = True
		Me.Indietro.Enabled = True
		Me.Indietro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Indietro.Cursor = System.Windows.Forms.Cursors.Default
		Me.Indietro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Indietro.TabStop = True
		Me.Indietro.Name = "Indietro"
		Me.Avanti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Avanti.Text = "Avanti -->"
		Me.Avanti.Size = New System.Drawing.Size(97, 25)
		Me.Avanti.Location = New System.Drawing.Point(632, 384)
		Me.Avanti.TabIndex = 27
		Me.ToolTip1.SetToolTip(Me.Avanti, "Passa alla schermata successiva")
		Me.Avanti.BackColor = System.Drawing.SystemColors.Control
		Me.Avanti.CausesValidation = True
		Me.Avanti.Enabled = True
		Me.Avanti.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Avanti.Cursor = System.Windows.Forms.Cursors.Default
		Me.Avanti.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Avanti.TabStop = True
		Me.Avanti.Name = "Avanti"
		Me.We2t.AutoSize = False
		Me.We2t.Size = New System.Drawing.Size(97, 19)
		Me.We2t.Location = New System.Drawing.Point(224, 336)
		Me.We2t.TabIndex = 26
		Me.We2t.AcceptsReturn = True
		Me.We2t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.We2t.BackColor = System.Drawing.SystemColors.Window
		Me.We2t.CausesValidation = True
		Me.We2t.Enabled = True
		Me.We2t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.We2t.HideSelection = True
		Me.We2t.ReadOnly = False
		Me.We2t.Maxlength = 0
		Me.We2t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.We2t.MultiLine = False
		Me.We2t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.We2t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.We2t.TabStop = True
		Me.We2t.Visible = True
		Me.We2t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.We2t.Name = "We2t"
		Me.dft.AutoSize = False
		Me.dft.Size = New System.Drawing.Size(97, 19)
		Me.dft.Location = New System.Drawing.Point(224, 312)
		Me.dft.TabIndex = 25
		Me.dft.AcceptsReturn = True
		Me.dft.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.dft.BackColor = System.Drawing.SystemColors.Window
		Me.dft.CausesValidation = True
		Me.dft.Enabled = True
		Me.dft.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dft.HideSelection = True
		Me.dft.ReadOnly = False
		Me.dft.Maxlength = 0
		Me.dft.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.dft.MultiLine = False
		Me.dft.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dft.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.dft.TabStop = True
		Me.dft.Visible = True
		Me.dft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dft.Name = "dft"
		Me.R1t.AutoSize = False
		Me.R1t.Size = New System.Drawing.Size(97, 19)
		Me.R1t.Location = New System.Drawing.Point(224, 288)
		Me.R1t.TabIndex = 24
		Me.R1t.AcceptsReturn = True
		Me.R1t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.R1t.BackColor = System.Drawing.SystemColors.Window
		Me.R1t.CausesValidation = True
		Me.R1t.Enabled = True
		Me.R1t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R1t.HideSelection = True
		Me.R1t.ReadOnly = False
		Me.R1t.Maxlength = 0
		Me.R1t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.R1t.MultiLine = False
		Me.R1t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R1t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.R1t.TabStop = True
		Me.R1t.Visible = True
		Me.R1t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.R1t.Name = "R1t"
		Me.L10t.AutoSize = False
		Me.L10t.Size = New System.Drawing.Size(97, 19)
		Me.L10t.Location = New System.Drawing.Point(224, 264)
		Me.L10t.TabIndex = 23
		Me.L10t.AcceptsReturn = True
		Me.L10t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.L10t.BackColor = System.Drawing.SystemColors.Window
		Me.L10t.CausesValidation = True
		Me.L10t.Enabled = True
		Me.L10t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.L10t.HideSelection = True
		Me.L10t.ReadOnly = False
		Me.L10t.Maxlength = 0
		Me.L10t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.L10t.MultiLine = False
		Me.L10t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.L10t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.L10t.TabStop = True
		Me.L10t.Visible = True
		Me.L10t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.L10t.Name = "L10t"
		Me.t4t.AutoSize = False
		Me.t4t.Size = New System.Drawing.Size(97, 19)
		Me.t4t.Location = New System.Drawing.Point(224, 240)
		Me.t4t.TabIndex = 22
		Me.t4t.AcceptsReturn = True
		Me.t4t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.t4t.BackColor = System.Drawing.SystemColors.Window
		Me.t4t.CausesValidation = True
		Me.t4t.Enabled = True
		Me.t4t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.t4t.HideSelection = True
		Me.t4t.ReadOnly = False
		Me.t4t.Maxlength = 0
		Me.t4t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.t4t.MultiLine = False
		Me.t4t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.t4t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.t4t.TabStop = True
		Me.t4t.Visible = True
		Me.t4t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.t4t.Name = "t4t"
		Me.l2t.AutoSize = False
		Me.l2t.Size = New System.Drawing.Size(97, 19)
		Me.l2t.Location = New System.Drawing.Point(224, 216)
		Me.l2t.TabIndex = 21
		Me.l2t.AcceptsReturn = True
		Me.l2t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.l2t.BackColor = System.Drawing.SystemColors.Window
		Me.l2t.CausesValidation = True
		Me.l2t.Enabled = True
		Me.l2t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.l2t.HideSelection = True
		Me.l2t.ReadOnly = False
		Me.l2t.Maxlength = 0
		Me.l2t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.l2t.MultiLine = False
		Me.l2t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.l2t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.l2t.TabStop = True
		Me.l2t.Visible = True
		Me.l2t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.l2t.Name = "l2t"
		Me.l1t.AutoSize = False
		Me.l1t.Size = New System.Drawing.Size(97, 19)
		Me.l1t.Location = New System.Drawing.Point(224, 192)
		Me.l1t.TabIndex = 20
		Me.l1t.AcceptsReturn = True
		Me.l1t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.l1t.BackColor = System.Drawing.SystemColors.Window
		Me.l1t.CausesValidation = True
		Me.l1t.Enabled = True
		Me.l1t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.l1t.HideSelection = True
		Me.l1t.ReadOnly = False
		Me.l1t.Maxlength = 0
		Me.l1t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.l1t.MultiLine = False
		Me.l1t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.l1t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.l1t.TabStop = True
		Me.l1t.Visible = True
		Me.l1t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.l1t.Name = "l1t"
		Me.Qt.AutoSize = False
		Me.Qt.Size = New System.Drawing.Size(97, 19)
		Me.Qt.Location = New System.Drawing.Point(224, 168)
		Me.Qt.TabIndex = 19
		Me.Qt.AcceptsReturn = True
		Me.Qt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Qt.BackColor = System.Drawing.SystemColors.Window
		Me.Qt.CausesValidation = True
		Me.Qt.Enabled = True
		Me.Qt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Qt.HideSelection = True
		Me.Qt.ReadOnly = False
		Me.Qt.Maxlength = 0
		Me.Qt.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Qt.MultiLine = False
		Me.Qt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Qt.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Qt.TabStop = True
		Me.Qt.Visible = True
		Me.Qt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Qt.Name = "Qt"
		Me.B2t.AutoSize = False
		Me.B2t.Size = New System.Drawing.Size(97, 19)
		Me.B2t.Location = New System.Drawing.Point(224, 144)
		Me.B2t.TabIndex = 18
		Me.B2t.AcceptsReturn = True
		Me.B2t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.B2t.BackColor = System.Drawing.SystemColors.Window
		Me.B2t.CausesValidation = True
		Me.B2t.Enabled = True
		Me.B2t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.B2t.HideSelection = True
		Me.B2t.ReadOnly = False
		Me.B2t.Maxlength = 0
		Me.B2t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.B2t.MultiLine = False
		Me.B2t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.B2t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.B2t.TabStop = True
		Me.B2t.Visible = True
		Me.B2t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.B2t.Name = "B2t"
		Me.B1t.AutoSize = False
		Me.B1t.Size = New System.Drawing.Size(97, 19)
		Me.B1t.Location = New System.Drawing.Point(224, 120)
		Me.B1t.TabIndex = 17
		Me.B1t.AcceptsReturn = True
		Me.B1t.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.B1t.BackColor = System.Drawing.SystemColors.Window
		Me.B1t.CausesValidation = True
		Me.B1t.Enabled = True
		Me.B1t.ForeColor = System.Drawing.SystemColors.WindowText
		Me.B1t.HideSelection = True
		Me.B1t.ReadOnly = False
		Me.B1t.Maxlength = 0
		Me.B1t.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.B1t.MultiLine = False
		Me.B1t.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.B1t.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.B1t.TabStop = True
		Me.B1t.Visible = True
		Me.B1t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.B1t.Name = "B1t"
		Me.alphat.AutoSize = False
		Me.alphat.Size = New System.Drawing.Size(97, 19)
		Me.alphat.Location = New System.Drawing.Point(224, 96)
		Me.alphat.TabIndex = 16
		Me.alphat.AcceptsReturn = True
		Me.alphat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.alphat.BackColor = System.Drawing.SystemColors.Window
		Me.alphat.CausesValidation = True
		Me.alphat.Enabled = True
		Me.alphat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.alphat.HideSelection = True
		Me.alphat.ReadOnly = False
		Me.alphat.Maxlength = 0
		Me.alphat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.alphat.MultiLine = False
		Me.alphat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.alphat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.alphat.TabStop = True
		Me.alphat.Visible = True
		Me.alphat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.alphat.Name = "alphat"
		Me.et2.AutoSize = False
		Me.et2.Size = New System.Drawing.Size(97, 19)
		Me.et2.Location = New System.Drawing.Point(224, 72)
		Me.et2.TabIndex = 15
		Me.et2.AcceptsReturn = True
		Me.et2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.et2.BackColor = System.Drawing.SystemColors.Window
		Me.et2.CausesValidation = True
		Me.et2.Enabled = True
		Me.et2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.et2.HideSelection = True
		Me.et2.ReadOnly = False
		Me.et2.Maxlength = 0
		Me.et2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.et2.MultiLine = False
		Me.et2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.et2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.et2.TabStop = True
		Me.et2.Visible = True
		Me.et2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.et2.Name = "et2"
		Me.wt.AutoSize = False
		Me.wt.Size = New System.Drawing.Size(97, 19)
		Me.wt.Location = New System.Drawing.Point(224, 48)
		Me.wt.TabIndex = 14
		Me.wt.AcceptsReturn = True
		Me.wt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.wt.BackColor = System.Drawing.SystemColors.Window
		Me.wt.CausesValidation = True
		Me.wt.Enabled = True
		Me.wt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.wt.HideSelection = True
		Me.wt.ReadOnly = False
		Me.wt.Maxlength = 0
		Me.wt.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.wt.MultiLine = False
		Me.wt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.wt.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.wt.TabStop = True
		Me.wt.Visible = True
		Me.wt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.wt.Name = "wt"
		Me.Image2.Size = New System.Drawing.Size(202, 188)
		Me.Image2.Location = New System.Drawing.Point(336, 192)
		Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
		Me.Image2.Enabled = True
		Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image2.Visible = True
		Me.Image2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Image2.Name = "Image2"
		Me.Image1.Size = New System.Drawing.Size(399, 140)
		Me.Image1.Location = New System.Drawing.Point(336, 48)
		Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
		Me.Image1.Enabled = True
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image1.Visible = True
		Me.Image1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Image1.Name = "Image1"
		Me.Label13.Text = "Angolo saldatura                  We2        mm"
		Me.Label13.Size = New System.Drawing.Size(196, 13)
		Me.Label13.Location = New System.Drawing.Point(16, 336)
		Me.Label13.TabIndex = 13
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.SystemColors.Control
		Me.Label13.Enabled = True
		Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = True
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.Label12.Text = "Diametro foro                       df             mm"
		Me.Label12.Size = New System.Drawing.Size(196, 13)
		Me.Label12.Location = New System.Drawing.Point(16, 312)
		Me.Label12.TabIndex = 12
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.SystemColors.Control
		Me.Label12.Enabled = True
		Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = True
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label11.Text = "Raggio orecchia inf.            R1            mm"
		Me.Label11.Size = New System.Drawing.Size(197, 13)
		Me.Label11.Location = New System.Drawing.Point(16, 288)
		Me.Label11.TabIndex = 11
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = True
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label10.Text = "Larghezza orecch.              L10           mm"
		Me.Label10.Size = New System.Drawing.Size(197, 13)
		Me.Label10.Location = New System.Drawing.Point(16, 264)
		Me.Label10.TabIndex = 10
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.SystemColors.Control
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = True
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.Text = "Spessore orecch. inf.          t4              mm"
		Me.Label9.Size = New System.Drawing.Size(197, 13)
		Me.Label9.Location = New System.Drawing.Point(16, 240)
		Me.Label9.TabIndex = 9
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.SystemColors.Control
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = True
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label8.Text = "Distanza baricentro             l2              mm"
		Me.Label8.Size = New System.Drawing.Size(196, 13)
		Me.Label8.Location = New System.Drawing.Point(16, 216)
		Me.Label8.TabIndex = 8
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = True
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "Distanza                              l1              mm"
		Me.Label7.Size = New System.Drawing.Size(197, 13)
		Me.Label7.Location = New System.Drawing.Point(16, 192)
		Me.Label7.TabIndex = 7
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = True
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Peso apparecchio               w              Kg"
		Me.Label6.Size = New System.Drawing.Size(194, 13)
		Me.Label6.Location = New System.Drawing.Point(16, 168)
		Me.Label6.TabIndex = 6
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = True
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Max. angolo soll. vert.         ß2             °"
		Me.Label5.Size = New System.Drawing.Size(185, 13)
		Me.Label5.Location = New System.Drawing.Point(16, 144)
		Me.Label5.TabIndex = 5
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = True
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Max. angolo soll. oriz.          ß1             °"
		Me.Label4.Size = New System.Drawing.Size(186, 13)
		Me.Label4.Location = New System.Drawing.Point(16, 120)
		Me.Label4.TabIndex = 4
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = True
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Angolo nervatura                 ð               °"
		Me.Label3.Size = New System.Drawing.Size(187, 13)
		Me.Label3.Location = New System.Drawing.Point(16, 96)
		Me.Label3.TabIndex = 3
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = True
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Efficienza saldatura             we             %"
		Me.Label2.Size = New System.Drawing.Size(192, 13)
		Me.Label2.Location = New System.Drawing.Point(16, 72)
		Me.Label2.TabIndex = 2
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Angolo di saldatura              wl             mm"
		Me.Label1.Size = New System.Drawing.Size(197, 13)
		Me.Label1.Location = New System.Drawing.Point(16, 48)
		Me.Label1.TabIndex = 1
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Titolo.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Titolo.Text = "CALCOLO ORECCHIE DI SOLLEVAMENTO"
		Me.Titolo.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Titolo.Size = New System.Drawing.Size(407, 27)
		Me.Titolo.Location = New System.Drawing.Point(134, 8)
		Me.Titolo.TabIndex = 0
		Me.Titolo.BackColor = System.Drawing.SystemColors.Control
		Me.Titolo.Enabled = True
		Me.Titolo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Titolo.Cursor = System.Windows.Forms.Cursors.Default
		Me.Titolo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Titolo.UseMnemonic = True
		Me.Titolo.Visible = True
		Me.Titolo.AutoSize = True
		Me.Titolo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Titolo.Name = "Titolo"
		Me.Controls.Add(Indietro)
		Me.Controls.Add(Avanti)
		Me.Controls.Add(We2t)
		Me.Controls.Add(dft)
		Me.Controls.Add(R1t)
		Me.Controls.Add(L10t)
		Me.Controls.Add(t4t)
		Me.Controls.Add(l2t)
		Me.Controls.Add(l1t)
		Me.Controls.Add(Qt)
		Me.Controls.Add(B2t)
		Me.Controls.Add(B1t)
		Me.Controls.Add(alphat)
		Me.Controls.Add(et2)
		Me.Controls.Add(wt)
		Me.Controls.Add(Image2)
		Me.Controls.Add(Image1)
		Me.Controls.Add(Label13)
		Me.Controls.Add(Label12)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Titolo)
	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As InserDati_2
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As InserDati_2
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New InserDati_2()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Dim c As Short
	Dim m As String
    Private Sub alphat_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles alphat.TextChanged
        Orecchia.alpha = CDbl(alphat.Text)
    End Sub

    Private Sub Avanti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Avanti.Click
        m = "Alcuni valori sono diversi da un numero, o sono mancanti; prego ricontrollare"
        c = 0
        If wt.Text = "" Then
            c = 1
        End If

        If et2.Text = "" Then
            c = 1
        End If

        If alphat.Text = "" Then
            c = 1
        End If

        If B1t.Text = "" Then
            c = 1
        End If

        If B2t.Text = "" Then
            c = 1
        End If

        If Qt.Text = "" Then
            c = 1
        End If

        If l1t.Text = "" Then
            c = 1
        End If

        If l2t.Text = "" Then
            c = 1
        End If

        If t4t.Text = "" Then
            c = 1
        End If

        If L10t.Text = "" Then
            c = 1
        End If

        If R1t.Text = "" Then
            c = 1
        End If

        If dft.Text = "" Then
            c = 1
        End If

        If We2t.Text = "" Then
            c = 1
        End If

        If c = 1 Then
            MsgBox(m)
        End If
        With Orecchia
            If c = 0 Then
                .wl = CDbl(wt.Text)
                .we = CDbl(et2.Text)
                .alpha = CDbl(alphat.Text)
                .theta1 = CDbl(B1t.Text)
                .theta2 = CDbl(B2t.Text)
                .W = CDbl(Qt.Text)
                .li = CDbl(l1t.Text)
                .ll = CDbl(l2t.Text)
                .t4 = CDbl(t4t.Text)
                .L10 = CDbl(L10t.Text)
                .R11 = CDbl(R1t.Text)
                .dff = CDbl(dft.Text)
                .We2 = CDbl(We2t.Text)
                InserDati_2.DefInstance.Close()
                InserDati_3.DefInstance.ShowDialog()
        End If
        End With

    End Sub
    Private Sub B1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles B1t.TextChanged
        Orecchia.theta1 = CDbl(B1t.Text)
    End Sub
    Private Sub B2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles B2t.TextChanged
        Orecchia.theta2 = CDbl(B2t.Text)
    End Sub
    Private Sub dft_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dft.TextChanged
        Orecchia.dff = CDbl(dft.Text)
    End Sub
    Private Sub et2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles et2.TextChanged
        Orecchia.we = CDbl(et2.Text)
    End Sub
    Private Sub InserDati_2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        With Orecchia
            wt.Text = CStr(.wl)
            et2.Text = CStr(.we)
            alphat.Text = CStr(.alpha)
            B1t.Text = CStr(.theta1)
            B2t.Text = CStr(.theta2)
            Qt.Text = CStr(.W)
            l1t.Text = CStr(.li)
            l2t.Text = CStr(.ll)
            t4t.Text = CStr(.t4)
            L10t.Text = CStr(.L10)
            R1t.Text = CStr(.R11)
            dft.Text = CStr(.dff)
            We2t.Text = CStr(.We2)
        End With
    End Sub

    Private Sub InserDati_2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Width / 2 ' Centra il form orizzontalmente.
        Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Height / 2 ' Centra il form verticalmente.
        Titolo.Left = InserDati_2.DefInstance.Width - Titolo.Width / 2 'Centra il titolo orizzontalmente
    End Sub

    Private Sub Indietro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Indietro.Click
        temp3 = 1
        With Orecchia
            .wl = CDbl(wt.Text)
            .we = CDbl(et2.Text)
            .alpha = CDbl(alphat.Text)
            .theta1 = CDbl(B1t.Text)
            .theta2 = CDbl(B2t.Text)
            .W = CDbl(Qt.Text)
            .li = CDbl(l1t.Text)
            .ll = CDbl(l2t.Text)
            .t4 = CDbl(t4t.Text)
            .L10 = CDbl(L10t.Text)
            .R11 = CDbl(R1t.Text)
            .dff = CDbl(dft.Text)
            .We2 = CDbl(We2t.Text)
        End With
        InserDati_2.DefInstance.Close()
        InserDati_1.DefInstance.ShowDialog()
    End Sub
    Private Sub L10t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles L10t.TextChanged
        Orecchia.L10 = CDbl(L10t.Text)
    End Sub
    Private Sub l1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles l1t.TextChanged
        Orecchia.li = CDbl(l1t.Text)
    End Sub
    Private Sub l2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles l2t.TextChanged
        Orecchia.ll = CDbl(l2t.Text)
    End Sub
    Private Sub Qt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Qt.TextChanged
        Orecchia.W = CDbl(Qt.Text)
    End Sub
    Private Sub R1t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R1t.TextChanged
        Orecchia.R11 = CDbl(R1t.Text)
    End Sub
    Private Sub t4t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles t4t.TextChanged
        Orecchia.t4 = CDbl(t4t.Text)
    End Sub
    Private Sub We2t_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles We2t.TextChanged
        Orecchia.We2 = CDbl(We2t.Text)
    End Sub
    Private Sub wt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wt.TextChanged
        Orecchia.wl = CDbl(wt.Text)
    End Sub
End Class