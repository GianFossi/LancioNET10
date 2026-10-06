Option Strict Off
Option Explicit On
Friend Class frmScelta
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmScelta))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Command1 = New System.Windows.Forms.Button
		Me._Text1_0 = New System.Windows.Forms.TextBox
		Me.List1 = New System.Windows.Forms.ListBox
		Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Scelta prototipo foglio carichi"
		Me.ClientSize = New System.Drawing.Size(244, 247)
		Me.Location = New System.Drawing.Point(149, 156)
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
		Me.Name = "frmScelta"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "OK"
		Me.Command1.Size = New System.Drawing.Size(208, 20)
		Me.Command1.Location = New System.Drawing.Point(17, 212)
		Me.Command1.TabIndex = 2
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me._Text1_0.AutoSize = False
		Me._Text1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me._Text1_0.Size = New System.Drawing.Size(197, 88)
		Me._Text1_0.Location = New System.Drawing.Point(23, 106)
		Me._Text1_0.MultiLine = True
		Me._Text1_0.TabIndex = 1
		Me._Text1_0.Text = "Text1"
		Me._Text1_0.Visible = False
		Me._Text1_0.AcceptsReturn = True
		Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._Text1_0.CausesValidation = True
		Me._Text1_0.Enabled = True
		Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Text1_0.HideSelection = True
		Me._Text1_0.ReadOnly = False
		Me._Text1_0.Maxlength = 0
		Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Text1_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._Text1_0.TabStop = True
		Me._Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Text1_0.Name = "_Text1_0"
		Me.List1.Size = New System.Drawing.Size(197, 83)
		Me.List1.Location = New System.Drawing.Point(23, 20)
		Me.List1.TabIndex = 0
		Me.List1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.List1.BackColor = System.Drawing.SystemColors.Window
		Me.List1.CausesValidation = True
		Me.List1.Enabled = True
		Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List1.IntegralHeight = True
		Me.List1.Cursor = System.Windows.Forms.Cursors.Default
		Me.List1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List1.Sorted = False
		Me.List1.TabStop = True
		Me.List1.Visible = True
		Me.List1.MultiColumn = False
		Me.List1.Name = "List1"
		Me.Controls.Add(Command1)
		Me.Controls.Add(_Text1_0)
		Me.Controls.Add(List1)
		Me.Text1.SetIndex(_Text1_0, CType(0, Short))
		CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmScelta
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmScelta
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmScelta()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Hide()
	End Sub
	
	'UPGRADE_WARNING: Form evento frmScelta.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmScelta_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Text1(1).Visible = True
		
	End Sub
	
	'UPGRADE_WARNING: L'evento List1.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub List1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles List1.SelectedIndexChanged
		Dim i As Object
		For i = 0 To List1.Items.Count - 1
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			Text1(i + 1).Visible = (i = List1.SelectedIndex)
		Next 
	End Sub
End Class