Option Strict Off
Option Explicit On
Friend Class frmForature
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
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public Label1 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public Text1 As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmForature))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdOK = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me._Text1_5 = New System.Windows.Forms.TextBox
		Me._Text1_4 = New System.Windows.Forms.TextBox
		Me._Text1_3 = New System.Windows.Forms.TextBox
		Me._Text1_2 = New System.Windows.Forms.TextBox
		Me._Text1_1 = New System.Windows.Forms.TextBox
		Me._Text1_0 = New System.Windows.Forms.TextBox
		Me._Label1_5 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "F"
		Me.ClientSize = New System.Drawing.Size(182, 190)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmForature"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(57, 33)
		Me.cmdOK.Location = New System.Drawing.Point(112, 152)
		Me.cmdOK.TabIndex = 13
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(8, 152)
		Me.cmdCancel.TabIndex = 12
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me._Text1_5.AutoSize = False
		Me._Text1_5.BackColor = System.Drawing.Color.White
		Me._Text1_5.Size = New System.Drawing.Size(57, 19)
		Me._Text1_5.Location = New System.Drawing.Point(112, 128)
		Me._Text1_5.TabIndex = 11
		Me._Text1_5.AcceptsReturn = True
		Me._Text1_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_5.CausesValidation = True
		Me._Text1_5.Enabled = True
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
		Me._Text1_4.BackColor = System.Drawing.Color.White
		Me._Text1_4.Size = New System.Drawing.Size(57, 19)
		Me._Text1_4.Location = New System.Drawing.Point(112, 104)
		Me._Text1_4.TabIndex = 9
		Me._Text1_4.AcceptsReturn = True
		Me._Text1_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_4.CausesValidation = True
		Me._Text1_4.Enabled = True
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
		Me._Text1_3.BackColor = System.Drawing.Color.Yellow
		Me._Text1_3.Enabled = False
		Me._Text1_3.Size = New System.Drawing.Size(57, 19)
		Me._Text1_3.Location = New System.Drawing.Point(112, 80)
		Me._Text1_3.TabIndex = 7
		Me._Text1_3.AcceptsReturn = True
		Me._Text1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
		Me._Text1_2.AutoSize = False
		Me._Text1_2.BackColor = System.Drawing.Color.Yellow
		Me._Text1_2.Enabled = False
		Me._Text1_2.Size = New System.Drawing.Size(57, 19)
		Me._Text1_2.Location = New System.Drawing.Point(112, 56)
		Me._Text1_2.TabIndex = 6
		Me._Text1_2.AcceptsReturn = True
		Me._Text1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
		Me._Text1_1.BackColor = System.Drawing.Color.Yellow
		Me._Text1_1.Enabled = False
		Me._Text1_1.Size = New System.Drawing.Size(57, 19)
		Me._Text1_1.Location = New System.Drawing.Point(112, 32)
		Me._Text1_1.TabIndex = 5
		Me._Text1_1.AcceptsReturn = True
		Me._Text1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
		Me._Text1_0.BackColor = System.Drawing.Color.Yellow
		Me._Text1_0.Enabled = False
		Me._Text1_0.Size = New System.Drawing.Size(57, 19)
		Me._Text1_0.Location = New System.Drawing.Point(112, 8)
		Me._Text1_0.TabIndex = 4
		Me._Text1_0.AcceptsReturn = True
		Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
		Me._Label1_5.Text = "Costo  (MLit)"
		Me._Label1_5.Size = New System.Drawing.Size(97, 17)
		Me._Label1_5.Location = New System.Drawing.Point(8, 128)
		Me._Label1_5.TabIndex = 10
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
		Me._Label1_4.Text = "Lire al metro"
		Me._Label1_4.Size = New System.Drawing.Size(97, 17)
		Me._Label1_4.Location = New System.Drawing.Point(8, 104)
		Me._Label1_4.TabIndex = 8
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
		Me._Label1_3.Text = "Lunghezza tot. (m)"
		Me._Label1_3.Size = New System.Drawing.Size(97, 17)
		Me._Label1_3.Location = New System.Drawing.Point(8, 80)
		Me._Label1_3.TabIndex = 3
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
		Me._Label1_2.Text = "Profondità  (mm)"
		Me._Label1_2.Size = New System.Drawing.Size(97, 17)
		Me._Label1_2.Location = New System.Drawing.Point(8, 56)
		Me._Label1_2.TabIndex = 2
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
		Me._Label1_1.Text = "Diametro fori  (mm)"
		Me._Label1_1.Size = New System.Drawing.Size(97, 17)
		Me._Label1_1.Location = New System.Drawing.Point(8, 32)
		Me._Label1_1.TabIndex = 1
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
		Me._Label1_0.Text = "Numero fori"
		Me._Label1_0.Size = New System.Drawing.Size(97, 17)
		Me._Label1_0.Location = New System.Drawing.Point(8, 8)
		Me._Label1_0.TabIndex = 0
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
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(_Text1_5)
		Me.Controls.Add(_Text1_4)
		Me.Controls.Add(_Text1_3)
		Me.Controls.Add(_Text1_2)
		Me.Controls.Add(_Text1_1)
		Me.Controls.Add(_Text1_0)
		Me.Controls.Add(_Label1_5)
		Me.Controls.Add(_Label1_4)
		Me.Controls.Add(_Label1_3)
		Me.Controls.Add(_Label1_2)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label1_0)
		Me.Label1.Add(5, _Label1_5)
		Me.Label1.Add(4, _Label1_4)
		Me.Label1.Add(3, _Label1_3)
		Me.Label1.Add(2, _Label1_2)
		Me.Label1.Add(1, _Label1_1)
		Me.Label1.Add(0, _Label1_0)
		Me.Text1.Add(5, _Text1_5)
		Me.Text1.Add(4, _Text1_4)
		Me.Text1.Add(3, _Text1_3)
		Me.Text1.Add(2, _Text1_2)
		Me.Text1.Add(1, _Text1_1)
		Me.Text1.Add(0, _Text1_0)
        For Each control In Text1.Values
            AddHandler control.TextChanged, AddressOf Text1_TextChanged
        Next

	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmForature
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmForature
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmForature()
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
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		OK = False
		Hide()
	End Sub
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		OK = True
		Hide()
	End Sub
	Private Sub frmForature_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(Membro.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Text = CStr(CDbl("Foratura ") + ctype(Membro.Genmem,clsGenmem).Denom)
	End Sub
	'UPGRADE_WARNING: L'evento Text1.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Dim Index As Short = IndexedControls.IndexOf(Text1, eventSender)
		Select Case Index
			Case 4
				Text1(5).Text = GlobalRoutines.myStr(Val(Text1(3).Text) * Val(Text1(4).Text) / 1000000#, 4, 1, False)
		End Select
	End Sub
End Class