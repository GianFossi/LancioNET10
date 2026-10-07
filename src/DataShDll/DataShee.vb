Option Strict Off
Option Explicit On
Friend Class DataShee
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
	Public WithEvents chkApproved As System.Windows.Forms.CheckBox
	Public WithEvents PassM As System.Windows.Forms.ComboBox
	Public WithEvents PassT As System.Windows.Forms.TextBox
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Indietro As System.Windows.Forms.Button
	Public WithEvents Avanti As System.Windows.Forms.Button
	Public WithEvents FaseT As System.Windows.Forms.ComboBox
	Public WithEvents FaseM As System.Windows.Forms.ComboBox
	Public WithEvents NomFluiT As System.Windows.Forms.TextBox
	Public WithEvents NomFluiM As System.Windows.Forms.TextBox
	Public WithEvents TexServ As System.Windows.Forms.TextBox
	Public WithEvents TexImp As System.Windows.Forms.TextBox
	Public WithEvents Cliente As System.Windows.Forms.TextBox
	Public WithEvents TexItem As System.Windows.Forms.TextBox
    Public WithEvents _ValorT_5 As TextBox
    Public WithEvents _ValorM_5 As TextBox
    Public WithEvents _ValorT_4 As TextBox
    Public WithEvents _ValorT_3 As TextBox
    Public WithEvents _ValorT_2 As TextBox
    Public WithEvents _ValorT_1 As TextBox
    Public WithEvents _ValorM_4 As TextBox
    Public WithEvents _ValorM_3 As TextBox
    Public WithEvents _ValorM_2 As TextBox
    Public WithEvents _ValorM_1 As TextBox
    Public WithEvents _ValorT_0 As TextBox
    Public WithEvents _ValorM_0 As TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents LabITEM As System.Windows.Forms.Label
    Public WithEvents TEMA As System.Windows.Forms.Label
    Public WithEvents _LabFlui_8 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_5 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_4 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_3 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_2 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_1 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents LabServ As System.Windows.Forms.Label
    Public WithEvents LabImp As System.Windows.Forms.Label
    Public WithEvents LabClie As System.Windows.Forms.Label
    Public WithEvents LabTEMA As System.Windows.Forms.Label
    Public LabFlui As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Label1 As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Option1 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
    Public ValorM As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    Public ValorT As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DataShee))
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ToolTip1.Active = True
        Me.chkApproved = New System.Windows.Forms.CheckBox
        Me.PassM = New System.Windows.Forms.ComboBox
        Me.PassT = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Option1_2 = New System.Windows.Forms.RadioButton
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me.Indietro = New System.Windows.Forms.Button
        Me.Avanti = New System.Windows.Forms.Button
        Me.FaseT = New System.Windows.Forms.ComboBox
        Me.FaseM = New System.Windows.Forms.ComboBox
        Me.NomFluiT = New System.Windows.Forms.TextBox
        Me.NomFluiM = New System.Windows.Forms.TextBox
        Me.TexServ = New System.Windows.Forms.TextBox
        Me.TexImp = New System.Windows.Forms.TextBox
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.TexItem = New System.Windows.Forms.TextBox
        Me._ValorT_5 = New TextBox
        Me._ValorM_5 = New TextBox
        Me._ValorT_4 = New TextBox
        Me._ValorT_3 = New TextBox
        Me._ValorT_2 = New TextBox
        Me._ValorT_1 = New TextBox
        Me._ValorM_4 = New TextBox
        Me._ValorM_3 = New TextBox
        Me._ValorM_2 = New TextBox
        Me._ValorM_1 = New TextBox
        Me._ValorT_0 = New TextBox
        Me._ValorM_0 = New TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.LabITEM = New System.Windows.Forms.Label
        Me.TEMA = New System.Windows.Forms.Label
        Me._LabFlui_8 = New System.Windows.Forms.Label
        Me._LabFlui_5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me._LabFlui_4 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me._LabFlui_3 = New System.Windows.Forms.Label
        Me._LabFlui_2 = New System.Windows.Forms.Label
        Me._LabFlui_1 = New System.Windows.Forms.Label
        Me._LabFlui_0 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me.LabServ = New System.Windows.Forms.Label
        Me.LabImp = New System.Windows.Forms.Label
        Me.LabClie = New System.Windows.Forms.Label
        Me.LabTEMA = New System.Windows.Forms.Label
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = "Foglio dati - Dati funzionali"
        Me.ClientSize = New System.Drawing.Size(380, 389)
        Me.Location = New System.Drawing.Point(42, 55)
        Me.ControlBox = False
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(0, 0)
        Me.Enabled = True
        Me.KeyPreview = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "DataShee"
        Me.chkApproved.Text = "Data sheet approvato"
        Me.chkApproved.Size = New System.Drawing.Size(193, 25)
        Me.chkApproved.Location = New System.Drawing.Point(8, 288)
        Me.chkApproved.TabIndex = 48
        Me.chkApproved.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkApproved.BackColor = System.Drawing.SystemColors.Control
        Me.chkApproved.CausesValidation = True
        Me.chkApproved.Enabled = True
        Me.chkApproved.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkApproved.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkApproved.Appearance = System.Windows.Forms.Appearance.Normal
        Me.chkApproved.TabStop = True
        Me.chkApproved.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.chkApproved.Visible = True
        Me.chkApproved.Name = "chkApproved"
        Me.PassM.Size = New System.Drawing.Size(111, 21)
        Me.PassM.Location = New System.Drawing.Point(160, 260)
        Me.PassM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PassM.TabIndex = 19
        Me.PassM.BackColor = System.Drawing.SystemColors.Window
        Me.PassM.CausesValidation = True
        Me.PassM.Enabled = True
        Me.PassM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PassM.IntegralHeight = True
        Me.PassM.Cursor = System.Windows.Forms.Cursors.Default
        Me.PassM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PassM.Sorted = False
        Me.PassM.TabStop = True
        Me.PassM.Visible = True
        Me.PassM.Name = "PassM"
        Me.PassT.AutoSize = False
        Me.PassT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PassT.Size = New System.Drawing.Size(111, 21)
        Me.PassT.Location = New System.Drawing.Point(270, 260)
        Me.PassT.Multiline = True
        Me.PassT.TabIndex = 18
        Me.PassT.Text = "1"
        Me.PassT.Visible = False
        Me.PassT.AcceptsReturn = True
        Me.PassT.BackColor = System.Drawing.SystemColors.Window
        Me.PassT.CausesValidation = True
        Me.PassT.Enabled = True
        Me.PassT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PassT.HideSelection = True
        Me.PassT.ReadOnly = False
        Me.PassT.MaxLength = 0
        Me.PassT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PassT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PassT.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.PassT.TabStop = True
        Me.PassT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PassT.Name = "PassT"
        Me.Frame1.BackColor = System.Drawing.Color.FromArgb(192, 192, 0)
        Me.Frame1.Text = "Sistema di misura"
        Me.Frame1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame1.Size = New System.Drawing.Size(209, 51)
        Me.Frame1.Location = New System.Drawing.Point(170, 320)
        Me.Frame1.TabIndex = 43
        Me.Frame1.Enabled = True
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Visible = True
        Me.Frame1.Name = "Frame1"
        Me._Option1_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._Option1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Option1_2.Text = "SI"
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Option1_2.Size = New System.Drawing.Size(59, 21)
        Me._Option1_2.Location = New System.Drawing.Point(140, 20)
        Me._Option1_2.TabIndex = 46
        Me._Option1_2.TabStop = False
        Me._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._Option1_2.CausesValidation = True
        Me._Option1_2.Enabled = True
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Appearance = System.Windows.Forms.Appearance.Normal
        Me._Option1_2.Checked = False
        Me._Option1_2.Visible = True
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Option1_1.Text = "British"
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Option1_1.Size = New System.Drawing.Size(61, 21)
        Me._Option1_1.Location = New System.Drawing.Point(70, 20)
        Me._Option1_1.TabIndex = 45
        Me._Option1_1.TabStop = False
        Me._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._Option1_1.CausesValidation = True
        Me._Option1_1.Enabled = True
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Appearance = System.Windows.Forms.Appearance.Normal
        Me._Option1_1.Checked = False
        Me._Option1_1.Visible = True
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Option1_0.Text = "Tecn"
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Option1_0.Size = New System.Drawing.Size(51, 21)
        Me._Option1_0.Location = New System.Drawing.Point(10, 20)
        Me._Option1_0.TabIndex = 44
        Me._Option1_0.TabStop = False
        Me._Option1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._Option1_0.CausesValidation = True
        Me._Option1_0.Enabled = True
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Appearance = System.Windows.Forms.Appearance.Normal
        Me._Option1_0.Checked = False
        Me._Option1_0.Visible = True
        Me._Option1_0.Name = "_Option1_0"
        Me.Indietro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Indietro.BackColor = System.Drawing.SystemColors.Control
        Me.Indietro.Text = "Indietro"
        Me.Indietro.Size = New System.Drawing.Size(71, 21)
        Me.Indietro.Location = New System.Drawing.Point(90, 320)
        Me.Indietro.TabIndex = 21
        Me.Indietro.CausesValidation = True
        Me.Indietro.Enabled = True
        Me.Indietro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Indietro.Cursor = System.Windows.Forms.Cursors.Default
        Me.Indietro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Indietro.TabStop = True
        Me.Indietro.Name = "Indietro"
        Me.Avanti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Avanti.BackColor = System.Drawing.SystemColors.Control
        Me.Avanti.Text = "Avanti"
        Me.AcceptButton = Me.Avanti
        Me.Avanti.Size = New System.Drawing.Size(71, 21)
        Me.Avanti.Location = New System.Drawing.Point(10, 320)
        Me.Avanti.TabIndex = 20
        Me.Avanti.CausesValidation = True
        Me.Avanti.Enabled = True
        Me.Avanti.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Avanti.Cursor = System.Windows.Forms.Cursors.Default
        Me.Avanti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Avanti.TabStop = True
        Me.Avanti.Name = "Avanti"
        Me.FaseT.Size = New System.Drawing.Size(111, 20)
        Me.FaseT.Location = New System.Drawing.Point(270, 120)
        Me.FaseT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FaseT.TabIndex = 5
        Me.FaseT.BackColor = System.Drawing.SystemColors.Window
        Me.FaseT.CausesValidation = True
        Me.FaseT.Enabled = True
        Me.FaseT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FaseT.IntegralHeight = True
        Me.FaseT.Cursor = System.Windows.Forms.Cursors.Default
        Me.FaseT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FaseT.Sorted = False
        Me.FaseT.TabStop = True
        Me.FaseT.Visible = True
        Me.FaseT.Name = "FaseT"
        Me.FaseM.Size = New System.Drawing.Size(111, 20)
        Me.FaseM.Location = New System.Drawing.Point(160, 120)
        Me.FaseM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FaseM.TabIndex = 4
        Me.FaseM.BackColor = System.Drawing.SystemColors.Window
        Me.FaseM.CausesValidation = True
        Me.FaseM.Enabled = True
        Me.FaseM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FaseM.IntegralHeight = True
        Me.FaseM.Cursor = System.Windows.Forms.Cursors.Default
        Me.FaseM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FaseM.Sorted = False
        Me.FaseM.TabStop = True
        Me.FaseM.Visible = True
        Me.FaseM.Name = "FaseM"
        Me.NomFluiT.AutoSize = False
        Me.NomFluiT.Size = New System.Drawing.Size(111, 21)
        Me.NomFluiT.Location = New System.Drawing.Point(270, 100)
        Me.NomFluiT.TabIndex = 3
        Me.NomFluiT.AcceptsReturn = True
        Me.NomFluiT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.NomFluiT.BackColor = System.Drawing.SystemColors.Window
        Me.NomFluiT.CausesValidation = True
        Me.NomFluiT.Enabled = True
        Me.NomFluiT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NomFluiT.HideSelection = True
        Me.NomFluiT.ReadOnly = False
        Me.NomFluiT.MaxLength = 0
        Me.NomFluiT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NomFluiT.Multiline = False
        Me.NomFluiT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NomFluiT.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.NomFluiT.TabStop = True
        Me.NomFluiT.Visible = True
        Me.NomFluiT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NomFluiT.Name = "NomFluiT"
        Me.NomFluiM.AutoSize = False
        Me.NomFluiM.Size = New System.Drawing.Size(111, 21)
        Me.NomFluiM.Location = New System.Drawing.Point(160, 100)
        Me.NomFluiM.TabIndex = 2
        Me.NomFluiM.AcceptsReturn = True
        Me.NomFluiM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.NomFluiM.BackColor = System.Drawing.SystemColors.Window
        Me.NomFluiM.CausesValidation = True
        Me.NomFluiM.Enabled = True
        Me.NomFluiM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NomFluiM.HideSelection = True
        Me.NomFluiM.ReadOnly = False
        Me.NomFluiM.MaxLength = 0
        Me.NomFluiM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NomFluiM.Multiline = False
        Me.NomFluiM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NomFluiM.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.NomFluiM.TabStop = True
        Me.NomFluiM.Visible = True
        Me.NomFluiM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NomFluiM.Name = "NomFluiM"
        Me.TexServ.AutoSize = False
        Me.TexServ.Enabled = False
        Me.TexServ.Size = New System.Drawing.Size(221, 21)
        Me.TexServ.Location = New System.Drawing.Point(160, 60)
        Me.TexServ.TabIndex = 29
        Me.TexServ.AcceptsReturn = True
        Me.TexServ.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TexServ.BackColor = System.Drawing.SystemColors.Window
        Me.TexServ.CausesValidation = True
        Me.TexServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TexServ.HideSelection = True
        Me.TexServ.ReadOnly = False
        Me.TexServ.MaxLength = 0
        Me.TexServ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TexServ.Multiline = False
        Me.TexServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexServ.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TexServ.TabStop = True
        Me.TexServ.Visible = True
        Me.TexServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexServ.Name = "TexServ"
        Me.TexImp.AutoSize = False
        Me.TexImp.Enabled = False
        Me.TexImp.Size = New System.Drawing.Size(221, 21)
        Me.TexImp.Location = New System.Drawing.Point(160, 40)
        Me.TexImp.TabIndex = 1
        Me.TexImp.AcceptsReturn = True
        Me.TexImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TexImp.BackColor = System.Drawing.SystemColors.Window
        Me.TexImp.CausesValidation = True
        Me.TexImp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TexImp.HideSelection = True
        Me.TexImp.ReadOnly = False
        Me.TexImp.MaxLength = 0
        Me.TexImp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TexImp.Multiline = False
        Me.TexImp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexImp.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TexImp.TabStop = True
        Me.TexImp.Visible = True
        Me.TexImp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexImp.Name = "TexImp"
        Me.Cliente.AutoSize = False
        Me.Cliente.Enabled = False
        Me.Cliente.Size = New System.Drawing.Size(221, 21)
        Me.Cliente.Location = New System.Drawing.Point(160, 20)
        Me.Cliente.TabIndex = 26
        Me.Cliente.AcceptsReturn = True
        Me.Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cliente.BackColor = System.Drawing.SystemColors.Window
        Me.Cliente.CausesValidation = True
        Me.Cliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cliente.HideSelection = True
        Me.Cliente.ReadOnly = False
        Me.Cliente.MaxLength = 0
        Me.Cliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Cliente.Multiline = False
        Me.Cliente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cliente.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cliente.TabStop = True
        Me.Cliente.Visible = True
        Me.Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cliente.Name = "Cliente"
        Me.TexItem.AutoSize = False
        Me.TexItem.Enabled = False
        Me.TexItem.Size = New System.Drawing.Size(81, 21)
        Me.TexItem.Location = New System.Drawing.Point(160, 0)
        Me.TexItem.TabIndex = 22
        Me.TexItem.AcceptsReturn = True
        Me.TexItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TexItem.BackColor = System.Drawing.SystemColors.Window
        Me.TexItem.CausesValidation = True
        Me.TexItem.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TexItem.HideSelection = True
        Me.TexItem.ReadOnly = False
        Me.TexItem.MaxLength = 0
        Me.TexItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TexItem.Multiline = False
        Me.TexItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexItem.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TexItem.TabStop = True
        Me.TexItem.Visible = True
        Me.TexItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexItem.Name = "TexItem"
        Me._ValorT_5.Size = New System.Drawing.Size(111, 21)
        Me._ValorT_5.Location = New System.Drawing.Point(270, 240)
        Me._ValorT_5.TabIndex = 17
        Me._ValorT_5.Name = "_ValorT_5"
        Me._ValorM_5.Size = New System.Drawing.Size(111, 21)
        Me._ValorM_5.Location = New System.Drawing.Point(160, 240)
        Me._ValorM_5.TabIndex = 16
        Me._ValorM_5.Name = "_ValorM_5"
        Me._ValorT_4.Size = New System.Drawing.Size(111, 21)
        Me._ValorT_4.Location = New System.Drawing.Point(270, 220)
        Me._ValorT_4.TabIndex = 15
        Me._ValorT_4.Name = "_ValorT_4"
        Me._ValorT_3.Size = New System.Drawing.Size(111, 21)
        Me._ValorT_3.Location = New System.Drawing.Point(270, 200)
        Me._ValorT_3.TabIndex = 13
        Me._ValorT_3.Name = "_ValorT_3"
        Me._ValorT_2.Size = New System.Drawing.Size(111, 21)
        Me._ValorT_2.Location = New System.Drawing.Point(270, 180)
        Me._ValorT_2.TabIndex = 11
        Me._ValorT_2.Name = "_ValorT_2"
        Me._ValorT_1.Size = New System.Drawing.Size(111, 21)
        Me._ValorT_1.Location = New System.Drawing.Point(270, 160)
        Me._ValorT_1.TabIndex = 9
        Me._ValorT_1.Name = "_ValorT_1"
        Me._ValorM_4.Size = New System.Drawing.Size(111, 21)
        Me._ValorM_4.Location = New System.Drawing.Point(160, 220)
        Me._ValorM_4.TabIndex = 14
        Me._ValorM_4.Name = "_ValorM_4"
        Me._ValorM_3.Size = New System.Drawing.Size(111, 21)
        Me._ValorM_3.Location = New System.Drawing.Point(160, 200)
        Me._ValorM_3.TabIndex = 12
        Me._ValorM_3.Name = "_ValorM_3"
        Me._ValorM_2.Size = New System.Drawing.Size(111, 21)
        Me._ValorM_2.Location = New System.Drawing.Point(160, 180)
        Me._ValorM_2.TabIndex = 10
        Me._ValorM_2.Name = "_ValorM_2"
        Me._ValorM_1.Size = New System.Drawing.Size(111, 21)
        Me._ValorM_1.Location = New System.Drawing.Point(160, 160)
        Me._ValorM_1.TabIndex = 8
        Me._ValorM_1.Name = "_ValorM_1"
        Me._ValorT_0.Size = New System.Drawing.Size(111, 21)
        Me._ValorT_0.Location = New System.Drawing.Point(270, 140)
        Me._ValorT_0.TabIndex = 7
        Me._ValorT_0.Name = "_ValorT_0"
        Me._ValorM_0.Size = New System.Drawing.Size(111, 21)
        Me._ValorM_0.Location = New System.Drawing.Point(160, 140)
        Me._ValorM_0.TabIndex = 6
        Me._ValorM_0.Name = "_ValorM_0"
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(192, 192, 0)
        Me.Label6.Text = "Pag. 1 / 3"
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Size = New System.Drawing.Size(151, 21)
        Me.Label6.Location = New System.Drawing.Point(10, 350)
        Me.Label6.TabIndex = 0
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.Enabled = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.UseMnemonic = True
        Me.Label6.Visible = True
        Me.Label6.AutoSize = False
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label6.Name = "Label6"
        Me.LabITEM.BackColor = System.Drawing.SystemColors.Window
        Me.LabITEM.Text = "ITEM"
        Me.LabITEM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabITEM.Size = New System.Drawing.Size(61, 21)
        Me.LabITEM.Location = New System.Drawing.Point(100, 0)
        Me.LabITEM.TabIndex = 24
        Me.LabITEM.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabITEM.Enabled = True
        Me.LabITEM.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabITEM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabITEM.UseMnemonic = True
        Me.LabITEM.Visible = True
        Me.LabITEM.AutoSize = False
        Me.LabITEM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabITEM.Name = "LabITEM"
        Me.TEMA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.TEMA.BackColor = System.Drawing.SystemColors.Window
        Me.TEMA.Enabled = False
        Me.TEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TEMA.Size = New System.Drawing.Size(61, 21)
        Me.TEMA.Location = New System.Drawing.Point(320, 0)
        Me.TEMA.TabIndex = 33
        Me.TEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEMA.UseMnemonic = True
        Me.TEMA.Visible = True
        Me.TEMA.AutoSize = False
        Me.TEMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEMA.Name = "TEMA"
        Me._LabFlui_8.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_8.Text = "PASSAGGI"
        Me._LabFlui_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_8.Size = New System.Drawing.Size(161, 21)
        Me._LabFlui_8.Location = New System.Drawing.Point(0, 260)
        Me._LabFlui_8.TabIndex = 47
        Me._LabFlui_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_8.Enabled = True
        Me._LabFlui_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_8.UseMnemonic = True
        Me._LabFlui_8.Visible = True
        Me._LabFlui_8.AutoSize = False
        Me._LabFlui_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_8.Name = "_LabFlui_8"
        Me._LabFlui_5.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_5.Text = "VOLUME                    (m3)"
        Me._LabFlui_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_5.Size = New System.Drawing.Size(161, 21)
        Me._LabFlui_5.Location = New System.Drawing.Point(0, 240)
        Me._LabFlui_5.TabIndex = 42
        Me._LabFlui_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_5.Enabled = True
        Me._LabFlui_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_5.UseMnemonic = True
        Me._LabFlui_5.Visible = True
        Me._LabFlui_5.AutoSize = False
        Me._LabFlui_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_5.Name = "_LabFlui_5"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Text = "MANTELLO"
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Size = New System.Drawing.Size(111, 21)
        Me.Label2.Location = New System.Drawing.Point(160, 80)
        Me.Label2.TabIndex = 31
        Me.Label2.Enabled = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.UseMnemonic = True
        Me.Label2.Visible = True
        Me.Label2.AutoSize = False
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Name = "Label2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Text = "TUBI"
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Size = New System.Drawing.Size(111, 21)
        Me.Label3.Location = New System.Drawing.Point(270, 80)
        Me.Label3.TabIndex = 32
        Me.Label3.Enabled = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.UseMnemonic = True
        Me.Label3.Visible = True
        Me.Label3.AutoSize = False
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Name = "Label3"
        Me._LabFlui_4.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_4.Text = "Portata      (Kg/hr)"
        Me._LabFlui_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_4.Size = New System.Drawing.Size(111, 21)
        Me._LabFlui_4.Location = New System.Drawing.Point(50, 220)
        Me._LabFlui_4.TabIndex = 41
        Me._LabFlui_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_4.Enabled = True
        Me._LabFlui_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_4.UseMnemonic = True
        Me._LabFlui_4.Visible = True
        Me._LabFlui_4.AutoSize = False
        Me._LabFlui_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_4.Name = "_LabFlui_4"
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Text = "FLUIDI"
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Size = New System.Drawing.Size(51, 141)
        Me.Label4.Location = New System.Drawing.Point(0, 100)
        Me.Label4.TabIndex = 40
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Enabled = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.UseMnemonic = True
        Me.Label4.Visible = True
        Me.Label4.AutoSize = False
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Name = "Label4"
        Me._LabFlui_3.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_3.Text = "k     (Cal/hr/m/°C)"
        Me._LabFlui_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_3.Size = New System.Drawing.Size(111, 21)
        Me._LabFlui_3.Location = New System.Drawing.Point(50, 200)
        Me._LabFlui_3.TabIndex = 39
        Me._LabFlui_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_3.Enabled = True
        Me._LabFlui_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_3.UseMnemonic = True
        Me._LabFlui_3.Visible = True
        Me._LabFlui_3.AutoSize = False
        Me._LabFlui_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_3.Name = "_LabFlui_3"
        Me._LabFlui_2.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_2.Text = "Viscosità      (cp)"
        Me._LabFlui_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_2.Size = New System.Drawing.Size(111, 21)
        Me._LabFlui_2.Location = New System.Drawing.Point(50, 180)
        Me._LabFlui_2.TabIndex = 38
        Me._LabFlui_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_2.Enabled = True
        Me._LabFlui_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_2.UseMnemonic = True
        Me._LabFlui_2.Visible = True
        Me._LabFlui_2.AutoSize = False
        Me._LabFlui_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_2.Name = "_LabFlui_2"
        Me._LabFlui_1.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_1.Text = "Cal.sp.(Cal/kg/°C)"
        Me._LabFlui_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_1.Size = New System.Drawing.Size(111, 21)
        Me._LabFlui_1.Location = New System.Drawing.Point(50, 160)
        Me._LabFlui_1.TabIndex = 37
        Me._LabFlui_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_1.Enabled = True
        Me._LabFlui_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_1.UseMnemonic = True
        Me._LabFlui_1.Visible = True
        Me._LabFlui_1.AutoSize = False
        Me._LabFlui_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_1.Name = "_LabFlui_1"
        Me._LabFlui_0.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_0.Text = "Densità     (Kg/m3)"
        Me._LabFlui_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LabFlui_0.Size = New System.Drawing.Size(111, 21)
        Me._LabFlui_0.Location = New System.Drawing.Point(50, 140)
        Me._LabFlui_0.TabIndex = 36
        Me._LabFlui_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._LabFlui_0.Enabled = True
        Me._LabFlui_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_0.UseMnemonic = True
        Me._LabFlui_0.Visible = True
        Me._LabFlui_0.AutoSize = False
        Me._LabFlui_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_0.Name = "_LabFlui_0"
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Label1_2.Text = "Fase"
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_2.Size = New System.Drawing.Size(111, 21)
        Me._Label1_2.Location = New System.Drawing.Point(50, 120)
        Me._Label1_2.TabIndex = 35
        Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_2.Enabled = True
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.UseMnemonic = True
        Me._Label1_2.Visible = True
        Me._Label1_2.AutoSize = False
        Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Label1_0.Text = "Nome"
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_0.Size = New System.Drawing.Size(111, 21)
        Me._Label1_0.Location = New System.Drawing.Point(50, 100)
        Me._Label1_0.TabIndex = 34
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_0.Enabled = True
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.UseMnemonic = True
        Me._Label1_0.Visible = True
        Me._Label1_0.AutoSize = False
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Label1_1.Text = "LATO"
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_1.Size = New System.Drawing.Size(161, 21)
        Me._Label1_1.Location = New System.Drawing.Point(0, 80)
        Me._Label1_1.TabIndex = 30
        Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_1.Enabled = True
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.UseMnemonic = True
        Me._Label1_1.Visible = True
        Me._Label1_1.AutoSize = False
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_1.Name = "_Label1_1"
        Me.LabServ.BackColor = System.Drawing.SystemColors.Window
        Me.LabServ.Text = "Servizio"
        Me.LabServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabServ.Size = New System.Drawing.Size(51, 21)
        Me.LabServ.Location = New System.Drawing.Point(100, 60)
        Me.LabServ.TabIndex = 28
        Me.LabServ.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabServ.Enabled = True
        Me.LabServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabServ.UseMnemonic = True
        Me.LabServ.Visible = True
        Me.LabServ.AutoSize = False
        Me.LabServ.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabServ.Name = "LabServ"
        Me.LabImp.BackColor = System.Drawing.SystemColors.Window
        Me.LabImp.Text = "Impianto"
        Me.LabImp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabImp.Size = New System.Drawing.Size(51, 21)
        Me.LabImp.Location = New System.Drawing.Point(100, 40)
        Me.LabImp.TabIndex = 27
        Me.LabImp.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabImp.Enabled = True
        Me.LabImp.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabImp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabImp.UseMnemonic = True
        Me.LabImp.Visible = True
        Me.LabImp.AutoSize = False
        Me.LabImp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabImp.Name = "LabImp"
        Me.LabClie.BackColor = System.Drawing.SystemColors.Window
        Me.LabClie.Text = "Cliente"
        Me.LabClie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabClie.Size = New System.Drawing.Size(41, 21)
        Me.LabClie.Location = New System.Drawing.Point(100, 20)
        Me.LabClie.TabIndex = 25
        Me.LabClie.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabClie.Enabled = True
        Me.LabClie.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabClie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabClie.UseMnemonic = True
        Me.LabClie.Visible = True
        Me.LabClie.AutoSize = False
        Me.LabClie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabClie.Name = "LabClie"
        Me.LabTEMA.BackColor = System.Drawing.SystemColors.Window
        Me.LabTEMA.Text = "Tipo TEMA"
        Me.LabTEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabTEMA.Size = New System.Drawing.Size(71, 21)
        Me.LabTEMA.Location = New System.Drawing.Point(240, 0)
        Me.LabTEMA.TabIndex = 23
        Me.LabTEMA.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabTEMA.Enabled = True
        Me.LabTEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabTEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabTEMA.UseMnemonic = True
        Me.LabTEMA.Visible = True
        Me.LabTEMA.AutoSize = False
        Me.LabTEMA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabTEMA.Name = "LabTEMA"
        Me.Controls.Add(chkApproved)
        Me.Controls.Add(PassM)
        Me.Controls.Add(PassT)
        Me.Controls.Add(Frame1)
        Me.Controls.Add(Indietro)
        Me.Controls.Add(Avanti)
        Me.Controls.Add(FaseT)
        Me.Controls.Add(FaseM)
        Me.Controls.Add(NomFluiT)
        Me.Controls.Add(NomFluiM)
        Me.Controls.Add(TexServ)
        Me.Controls.Add(TexImp)
        Me.Controls.Add(Cliente)
        Me.Controls.Add(TexItem)
        Me.Controls.Add(_ValorT_5)
        Me.Controls.Add(_ValorM_5)
        Me.Controls.Add(_ValorT_4)
        Me.Controls.Add(_ValorT_3)
        Me.Controls.Add(_ValorT_2)
        Me.Controls.Add(_ValorT_1)
        Me.Controls.Add(_ValorM_4)
        Me.Controls.Add(_ValorM_3)
        Me.Controls.Add(_ValorM_2)
        Me.Controls.Add(_ValorM_1)
        Me.Controls.Add(_ValorT_0)
        Me.Controls.Add(_ValorM_0)
        Me.Controls.Add(Label6)
        Me.Controls.Add(LabITEM)
        Me.Controls.Add(TEMA)
        Me.Controls.Add(_LabFlui_8)
        Me.Controls.Add(_LabFlui_5)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label3)
        Me.Controls.Add(_LabFlui_4)
        Me.Controls.Add(Label4)
        Me.Controls.Add(_LabFlui_3)
        Me.Controls.Add(_LabFlui_2)
        Me.Controls.Add(_LabFlui_1)
        Me.Controls.Add(_LabFlui_0)
        Me.Controls.Add(_Label1_2)
        Me.Controls.Add(_Label1_0)
        Me.Controls.Add(_Label1_1)
        Me.Controls.Add(LabServ)
        Me.Controls.Add(LabImp)
        Me.Controls.Add(LabClie)
        Me.Controls.Add(LabTEMA)
        Me.Frame1.Controls.Add(_Option1_2)
        Me.Frame1.Controls.Add(_Option1_1)
        Me.Frame1.Controls.Add(_Option1_0)
        Me.LabFlui.Add(8, _LabFlui_8)
        Me.LabFlui.Add(5, _LabFlui_5)
        Me.LabFlui.Add(4, _LabFlui_4)
        Me.LabFlui.Add(3, _LabFlui_3)
        Me.LabFlui.Add(2, _LabFlui_2)
        Me.LabFlui.Add(1, _LabFlui_1)
        Me.LabFlui.Add(0, _LabFlui_0)
        Me.Label1.Add(2, _Label1_2)
        Me.Label1.Add(0, _Label1_0)
        Me.Label1.Add(1, _Label1_1)
        Me.Option1.Add(2, _Option1_2)
        Me.Option1.Add(1, _Option1_1)
        Me.Option1.Add(0, _Option1_0)
        Me.ValorM.Add(5, _ValorM_5)
        Me.ValorM.Add(4, _ValorM_4)
        Me.ValorM.Add(3, _ValorM_3)
        Me.ValorM.Add(2, _ValorM_2)
        Me.ValorM.Add(1, _ValorM_1)
        Me.ValorM.Add(0, _ValorM_0)
        Me.ValorT.Add(5, _ValorT_5)
        Me.ValorT.Add(4, _ValorT_4)
        Me.ValorT.Add(3, _ValorT_3)
        Me.ValorT.Add(2, _ValorT_2)
        Me.ValorT.Add(1, _ValorT_1)
        Me.ValorT.Add(0, _ValorT_0)
        For Each control In ValorT.Values
            AddHandler control.TextChanged, AddressOf ValorT_Change
        Next
        For Each control In ValorM.Values
            AddHandler control.TextChanged, AddressOf ValorM_Change
        Next
        For Each control In ValorM.Values
            AddHandler control.KeyPress, AddressOf ValorM_KeyPressEvent
        Next
        For Each control In Option1.Values
            AddHandler control.CheckedChanged, AddressOf Option1_CheckedChanged
        Next


    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As DataShee
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As DataShee
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New DataShee()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Dim OKpuoiIniziare As Boolean '13-5-99
	Private Sub Avanti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Avanti.Click
		Hide()
		DataShe1.DefInstance.Show()
	End Sub
	
	'UPGRADE_WARNING: L'evento chkApproved.CheckStateChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub chkApproved_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkApproved.CheckStateChanged
        DataSheet.DatiSh0.Approved = chkApproved.CheckState = 1
    End Sub

    'UPGRADE_WARNING: L'evento FaseM.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub FaseM_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FaseM.SelectedIndexChanged
        DataSheet.DatiSh0.FaseM = DataShee.DefInstance.FaseM.SelectedIndex + 1
        ModifiedData = True
    End Sub

    'UPGRADE_WARNING: L'evento FaseT.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub FaseT_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FaseT.SelectedIndexChanged
        DataSheet.DatiSh0.FaseT = DataShee.DefInstance.FaseT.SelectedIndex + 1
        ModifiedData = True
    End Sub

    Private Sub Indietro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Indietro.Click
        Hide()
        Salva(OKpuoiIniziare) '13-5-99
        mioApert.Show()
    End Sub

    'UPGRADE_WARNING: L'evento NomFluiM.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub NomFluiM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NomFluiM.TextChanged
        DataSheet.DatiPrg.FluidoMant = NomFluiM.Text
    End Sub

    Private Sub NomFluiM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles NomFluiM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    'UPGRADE_WARNING: L'evento NomFluiT.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub NomFluiT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NomFluiT.TextChanged
        DataSheet.DatiPrg.FluidoTubi = NomFluiT.Text
    End Sub

    Private Sub NomFluiT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles NomFluiT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True

        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
            Call Convert(Index + 1)
            DataSheet.DatiPrg.UniMis = Index + 1
            DataShe1.DefInstance.Option1(Index).Checked = True
        End If
    End Sub

    'UPGRADE_WARNING: L'evento PassM.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    'UPGRADE_WARNING: ComboBox evento PassM.Change è stato aggiornato a PassM.TextChanged che presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2074"'
    Private Sub PassM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PassM.TextChanged
        DataSheet.DatiSh0.PassM = DataShee.DefInstance.PassM.Text
    End Sub

    'UPGRADE_WARNING: L'evento PassT.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub PassT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PassT.TextChanged
        DataSheet.DatiSh0.PassT = Val(DataShee.DefInstance.PassT.Text)
        ModifiedData = True
    End Sub

    Private Sub PassT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles PassT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    'UPGRADE_WARNING: L'evento TexImp.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub TexImp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TexImp.TextChanged
        DataSheet.DatiSh0.Impianto = TexImp.Text
    End Sub

    Private Sub ValorM_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ValorM, eventSender)
        DataSheet.DatiS2.ValorM(Index + 1) = Val(DataShee.DefInstance.ValorM(Index).Text)
    End Sub

    Private Sub ValorM_KeyPressEvent(ByVal eventSender As System.Object, ByVal e As KeyPressEventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ValorM, eventSender)
        ModifiedData = True
    End Sub

    Private Sub ValorT_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ValorT, eventSender)
        DataSheet.DatiS2.ValorT(Index + 1) = Val(DataShee.DefInstance.ValorT(Index).Text)
    End Sub
End Class