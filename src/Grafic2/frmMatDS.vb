Option Strict Off
Option Explicit On
Friend Class frmMatDS
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
	Public WithEvents cmdHelp As System.Windows.Forms.Button
	Public WithEvents cmdIgnora As System.Windows.Forms.Button
	Public WithEvents cmdAggiorna As System.Windows.Forms.Button
	Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
	Public WithEvents _Label2_5 As System.Windows.Forms.Label
	Public WithEvents _Label2_4 As System.Windows.Forms.Label
	Public WithEvents _Label2_3 As System.Windows.Forms.Label
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
	Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents _Label2_2 As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public Frame1 As New System.Collections.Generic.Dictionary(Of Integer, GroupBox)
	Public Label2 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public Text1 As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMatDS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdHelp = New System.Windows.Forms.Button
		Me.cmdIgnora = New System.Windows.Forms.Button
		Me.cmdAggiorna = New System.Windows.Forms.Button
		Me._Frame1_1 = New System.Windows.Forms.GroupBox
		Me._Text1_5 = New System.Windows.Forms.TextBox
		Me._Text1_4 = New System.Windows.Forms.TextBox
		Me._Text1_3 = New System.Windows.Forms.TextBox
		Me._Label2_5 = New System.Windows.Forms.Label
		Me._Label2_4 = New System.Windows.Forms.Label
		Me._Label2_3 = New System.Windows.Forms.Label
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me._Text1_2 = New System.Windows.Forms.TextBox
		Me._Text1_1 = New System.Windows.Forms.TextBox
		Me._Text1_0 = New System.Windows.Forms.TextBox
		Me._Label2_2 = New System.Windows.Forms.Label
		Me._Label2_1 = New System.Windows.Forms.Label
		Me._Label2_0 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Congruenza con Data Sheet"
		Me.ClientSize = New System.Drawing.Size(441, 190)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMatDS"
		Me.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdHelp.Text = "Help"
		Me.cmdHelp.Size = New System.Drawing.Size(73, 25)
		Me.cmdHelp.Location = New System.Drawing.Point(368, 160)
		Me.cmdHelp.TabIndex = 18
		Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdHelp.CausesValidation = True
		Me.cmdHelp.Enabled = True
		Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdHelp.TabStop = True
		Me.cmdHelp.Name = "cmdHelp"
		Me.cmdIgnora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdIgnora.Text = "Ignora"
		Me.cmdIgnora.Size = New System.Drawing.Size(73, 25)
		Me.cmdIgnora.Location = New System.Drawing.Point(288, 160)
		Me.cmdIgnora.TabIndex = 16
		Me.cmdIgnora.BackColor = System.Drawing.SystemColors.Control
		Me.cmdIgnora.CausesValidation = True
		Me.cmdIgnora.Enabled = True
		Me.cmdIgnora.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdIgnora.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdIgnora.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdIgnora.TabStop = True
		Me.cmdIgnora.Name = "cmdIgnora"
		Me.cmdAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAggiorna.Text = "Aggiorna"
		Me.cmdAggiorna.Size = New System.Drawing.Size(73, 25)
		Me.cmdAggiorna.Location = New System.Drawing.Point(208, 160)
		Me.cmdAggiorna.TabIndex = 15
		Me.cmdAggiorna.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAggiorna.CausesValidation = True
		Me.cmdAggiorna.Enabled = True
		Me.cmdAggiorna.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAggiorna.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAggiorna.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAggiorna.TabStop = True
		Me.cmdAggiorna.Name = "cmdAggiorna"
		Me._Frame1_1.Text = "Materiale del Data Sheet"
		Me._Frame1_1.Size = New System.Drawing.Size(217, 97)
		Me._Frame1_1.Location = New System.Drawing.Point(224, 56)
		Me._Frame1_1.TabIndex = 8
		Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_1.Enabled = True
		Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_1.Visible = True
		Me._Frame1_1.Name = "_Frame1_1"
		Me._Text1_5.AutoSize = False
		Me._Text1_5.Enabled = False
		Me._Text1_5.Size = New System.Drawing.Size(121, 19)
		Me._Text1_5.Location = New System.Drawing.Point(88, 24)
		Me._Text1_5.TabIndex = 11
		Me._Text1_5.Text = "Text1"
		Me._Text1_5.AcceptsReturn = True
		Me._Text1_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
		Me._Text1_5.CausesValidation = True
		Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_5.HideSelection = True
		Me._Text1_5.ReadOnly = False
		Me._Text1_5.Maxlength = 0
		Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_5.MultiLine = False
		Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_5.TabStop = True
		Me._Text1_5.Visible = True
		Me._Text1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Text1_5.Name = "_Text1_5"
		Me._Text1_4.AutoSize = False
		Me._Text1_4.Enabled = False
		Me._Text1_4.Size = New System.Drawing.Size(121, 19)
		Me._Text1_4.Location = New System.Drawing.Point(88, 48)
		Me._Text1_4.TabIndex = 10
		Me._Text1_4.Text = "Text1"
		Me._Text1_4.AcceptsReturn = True
		Me._Text1_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
		Me._Text1_4.CausesValidation = True
		Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_4.HideSelection = True
		Me._Text1_4.ReadOnly = False
		Me._Text1_4.Maxlength = 0
		Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_4.MultiLine = False
		Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_4.TabStop = True
		Me._Text1_4.Visible = True
		Me._Text1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Text1_4.Name = "_Text1_4"
		Me._Text1_3.AutoSize = False
		Me._Text1_3.Enabled = False
		Me._Text1_3.Size = New System.Drawing.Size(121, 19)
		Me._Text1_3.Location = New System.Drawing.Point(88, 72)
		Me._Text1_3.TabIndex = 9
		Me._Text1_3.Text = "Text1"
		Me._Text1_3.AcceptsReturn = True
		Me._Text1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
		Me._Text1_3.CausesValidation = True
		Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_3.HideSelection = True
		Me._Text1_3.ReadOnly = False
		Me._Text1_3.Maxlength = 0
		Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_3.MultiLine = False
		Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_3.TabStop = True
		Me._Text1_3.Visible = True
		Me._Text1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Text1_3.Name = "_Text1_3"
		Me._Label2_5.Text = "Materiale base"
		Me._Label2_5.Size = New System.Drawing.Size(81, 17)
		Me._Label2_5.Location = New System.Drawing.Point(8, 24)
		Me._Label2_5.TabIndex = 14
		Me._Label2_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
		Me._Label2_5.Enabled = True
		Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_5.UseMnemonic = True
		Me._Label2_5.Visible = True
		Me._Label2_5.AutoSize = False
		Me._Label2_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_5.Name = "_Label2_5"
		Me._Label2_4.Text = "Rivestimento 1"
		Me._Label2_4.Size = New System.Drawing.Size(81, 17)
		Me._Label2_4.Location = New System.Drawing.Point(8, 48)
		Me._Label2_4.TabIndex = 13
		Me._Label2_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
		Me._Label2_4.Enabled = True
		Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_4.UseMnemonic = True
		Me._Label2_4.Visible = True
		Me._Label2_4.AutoSize = False
		Me._Label2_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_4.Name = "_Label2_4"
		Me._Label2_3.Text = "Rivestimento 2"
		Me._Label2_3.Size = New System.Drawing.Size(81, 17)
		Me._Label2_3.Location = New System.Drawing.Point(8, 72)
		Me._Label2_3.TabIndex = 12
		Me._Label2_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
		Me._Label2_3.Enabled = True
		Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_3.UseMnemonic = True
		Me._Label2_3.Visible = True
		Me._Label2_3.AutoSize = False
		Me._Label2_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_3.Name = "_Label2_3"
		Me._Frame1_0.Text = "Materiale della membratura"
		Me._Frame1_0.Size = New System.Drawing.Size(217, 97)
		Me._Frame1_0.Location = New System.Drawing.Point(0, 56)
		Me._Frame1_0.TabIndex = 1
		Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Name = "_Frame1_0"
		Me._Text1_2.AutoSize = False
		Me._Text1_2.Enabled = False
		Me._Text1_2.Size = New System.Drawing.Size(121, 19)
		Me._Text1_2.Location = New System.Drawing.Point(88, 72)
		Me._Text1_2.TabIndex = 7
		Me._Text1_2.Text = "Text1"
		Me._Text1_2.AcceptsReturn = True
		Me._Text1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
		Me._Text1_2.CausesValidation = True
		Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_2.HideSelection = True
		Me._Text1_2.ReadOnly = False
		Me._Text1_2.Maxlength = 0
		Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_2.MultiLine = False
		Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_2.TabStop = True
		Me._Text1_2.Visible = True
		Me._Text1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Text1_2.Name = "_Text1_2"
		Me._Text1_1.AutoSize = False
		Me._Text1_1.Enabled = False
		Me._Text1_1.Size = New System.Drawing.Size(121, 19)
		Me._Text1_1.Location = New System.Drawing.Point(88, 48)
		Me._Text1_1.TabIndex = 6
		Me._Text1_1.Text = "Text1"
		Me._Text1_1.AcceptsReturn = True
		Me._Text1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
		Me._Text1_1.CausesValidation = True
		Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_1.HideSelection = True
		Me._Text1_1.ReadOnly = False
		Me._Text1_1.Maxlength = 0
		Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_1.MultiLine = False
		Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_1.TabStop = True
		Me._Text1_1.Visible = True
		Me._Text1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Text1_1.Name = "_Text1_1"
		Me._Text1_0.AutoSize = False
		Me._Text1_0.Enabled = False
		Me._Text1_0.Size = New System.Drawing.Size(121, 19)
		Me._Text1_0.Location = New System.Drawing.Point(88, 24)
		Me._Text1_0.TabIndex = 5
		Me._Text1_0.Text = "Text1"
		Me._Text1_0.AcceptsReturn = True
		Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
		Me._Text1_0.CausesValidation = True
		Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_0.HideSelection = True
		Me._Text1_0.ReadOnly = False
		Me._Text1_0.Maxlength = 0
		Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_0.MultiLine = False
		Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_0.TabStop = True
		Me._Text1_0.Visible = True
		Me._Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Text1_0.Name = "_Text1_0"
		Me._Label2_2.Text = "Rivestimento 2"
		Me._Label2_2.Size = New System.Drawing.Size(81, 17)
		Me._Label2_2.Location = New System.Drawing.Point(8, 72)
		Me._Label2_2.TabIndex = 4
		Me._Label2_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
		Me._Label2_2.Enabled = True
		Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_2.UseMnemonic = True
		Me._Label2_2.Visible = True
		Me._Label2_2.AutoSize = False
		Me._Label2_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_2.Name = "_Label2_2"
		Me._Label2_1.Text = "Rivestimento 1"
		Me._Label2_1.Size = New System.Drawing.Size(81, 17)
		Me._Label2_1.Location = New System.Drawing.Point(8, 48)
		Me._Label2_1.TabIndex = 3
		Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
		Me._Label2_1.Enabled = True
		Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_1.UseMnemonic = True
		Me._Label2_1.Visible = True
		Me._Label2_1.AutoSize = False
		Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_1.Name = "_Label2_1"
		Me._Label2_0.Text = "Materiale base"
		Me._Label2_0.Size = New System.Drawing.Size(81, 17)
		Me._Label2_0.Location = New System.Drawing.Point(8, 24)
		Me._Label2_0.TabIndex = 2
		Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
		Me._Label2_0.Enabled = True
		Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_0.UseMnemonic = True
		Me._Label2_0.Visible = True
		Me._Label2_0.AutoSize = False
		Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_0.Name = "_Label2_0"
		Me.Label3.Text = "Label3"
		Me.Label3.ForeColor = System.Drawing.Color.FromARGB(192, 64, 0)
		Me.Label3.Size = New System.Drawing.Size(377, 17)
		Me.Label3.Location = New System.Drawing.Point(24, 32)
		Me.Label3.TabIndex = 17
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label1.Text = "Il materiale della membratura non è congruente con i materiali predefiniti nel Data Sheet"
		Me.Label1.Size = New System.Drawing.Size(417, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 8)
		Me.Label1.TabIndex = 0
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdHelp)
		Me.Controls.Add(cmdIgnora)
		Me.Controls.Add(cmdAggiorna)
		Me.Controls.Add(_Frame1_1)
		Me.Controls.Add(_Frame1_0)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label1)
		Me._Frame1_1.Controls.Add(_Text1_5)
		Me._Frame1_1.Controls.Add(_Text1_4)
		Me._Frame1_1.Controls.Add(_Text1_3)
		Me._Frame1_1.Controls.Add(_Label2_5)
		Me._Frame1_1.Controls.Add(_Label2_4)
		Me._Frame1_1.Controls.Add(_Label2_3)
		Me._Frame1_0.Controls.Add(_Text1_2)
		Me._Frame1_0.Controls.Add(_Text1_1)
		Me._Frame1_0.Controls.Add(_Text1_0)
		Me._Frame1_0.Controls.Add(_Label2_2)
		Me._Frame1_0.Controls.Add(_Label2_1)
		Me._Frame1_0.Controls.Add(_Label2_0)
		Me.Frame1.Add(1, _Frame1_1)
		Me.Frame1.Add(0, _Frame1_0)
		Me.Label2.Add(5, _Label2_5)
		Me.Label2.Add(4, _Label2_4)
		Me.Label2.Add(3, _Label2_3)
		Me.Label2.Add(2, _Label2_2)
		Me.Label2.Add(1, _Label2_1)
		Me.Label2.Add(0, _Label2_0)
		Me.Text1.Add(5, _Text1_5)
		Me.Text1.Add(4, _Text1_4)
		Me.Text1.Add(3, _Text1_3)
		Me.Text1.Add(2, _Text1_2)
		Me.Text1.Add(1, _Text1_1)
		Me.Text1.Add(0, _Text1_0)



	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmMatDS
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMatDS
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMatDS()
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
	Private Sub cmdAggiorna_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAggiorna.Click
		OK = True
		Me.Close()
	End Sub
    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, HelpStringa(IDHG.IDH_DS_NONCONGRUO))
    End Sub
    Private Sub cmdIgnora_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdIgnora.Click
        OK = False
        Me.Close()
    End Sub
End Class