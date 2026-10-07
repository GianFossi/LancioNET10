Option Strict Off
Option Explicit On
Friend Class frmTipoP
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _Picture1_3 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_2 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
	Public WithEvents _Option1_3 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public Option1 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
	Public Picture1 As New System.Collections.Generic.Dictionary(Of Integer, PictureBox)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTipoP))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Command1 = New System.Windows.Forms.Button
		Me._Picture1_3 = New System.Windows.Forms.PictureBox
		Me._Picture1_2 = New System.Windows.Forms.PictureBox
		Me._Picture1_1 = New System.Windows.Forms.PictureBox
		Me._Picture1_0 = New System.Windows.Forms.PictureBox
		Me._Option1_3 = New System.Windows.Forms.RadioButton
		Me._Option1_2 = New System.Windows.Forms.RadioButton
		Me._Option1_1 = New System.Windows.Forms.RadioButton
		Me._Option1_0 = New System.Windows.Forms.RadioButton
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Tipo Passo"
		Me.ClientSize = New System.Drawing.Size(201, 101)
		Me.Location = New System.Drawing.Point(263, 304)
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
		Me.Name = "frmTipoP"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.Text = "&OK"
		Me.AcceptButton = Me.Command1
		Me.Command1.Size = New System.Drawing.Size(201, 21)
		Me.Command1.Location = New System.Drawing.Point(0, 80)
		Me.Command1.TabIndex = 8
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me._Picture1_3.BackColor = System.Drawing.SystemColors.Window
		Me._Picture1_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Picture1_3.Size = New System.Drawing.Size(31, 21)
		Me._Picture1_3.Location = New System.Drawing.Point(170, 60)
		Me._Picture1_3.TabIndex = 7
		Me._Picture1_3.Dock = System.Windows.Forms.DockStyle.None
		Me._Picture1_3.CausesValidation = True
		Me._Picture1_3.Enabled = True
		Me._Picture1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Picture1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Picture1_3.TabStop = True
		Me._Picture1_3.Visible = True
		Me._Picture1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Picture1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._Picture1_3.Name = "_Picture1_3"
		Me._Picture1_2.BackColor = System.Drawing.SystemColors.Window
		Me._Picture1_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Picture1_2.Size = New System.Drawing.Size(31, 21)
		Me._Picture1_2.Location = New System.Drawing.Point(170, 40)
		Me._Picture1_2.TabIndex = 6
		Me._Picture1_2.Dock = System.Windows.Forms.DockStyle.None
		Me._Picture1_2.CausesValidation = True
		Me._Picture1_2.Enabled = True
		Me._Picture1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Picture1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Picture1_2.TabStop = True
		Me._Picture1_2.Visible = True
		Me._Picture1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Picture1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._Picture1_2.Name = "_Picture1_2"
		Me._Picture1_1.BackColor = System.Drawing.SystemColors.Window
		Me._Picture1_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Picture1_1.Size = New System.Drawing.Size(31, 21)
		Me._Picture1_1.Location = New System.Drawing.Point(170, 20)
		Me._Picture1_1.TabIndex = 5
		Me._Picture1_1.Dock = System.Windows.Forms.DockStyle.None
		Me._Picture1_1.CausesValidation = True
		Me._Picture1_1.Enabled = True
		Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Picture1_1.TabStop = True
		Me._Picture1_1.Visible = True
		Me._Picture1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Picture1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._Picture1_1.Name = "_Picture1_1"
		Me._Picture1_0.BackColor = System.Drawing.SystemColors.Window
		Me._Picture1_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Picture1_0.Size = New System.Drawing.Size(31, 21)
		Me._Picture1_0.Location = New System.Drawing.Point(170, 0)
		Me._Picture1_0.TabIndex = 4
		Me._Picture1_0.Dock = System.Windows.Forms.DockStyle.None
		Me._Picture1_0.CausesValidation = True
		Me._Picture1_0.Enabled = True
		Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Picture1_0.TabStop = True
		Me._Picture1_0.Visible = True
		Me._Picture1_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Picture1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._Picture1_0.Name = "_Picture1_0"
		Me._Option1_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_3.BackColor = System.Drawing.SystemColors.Window
		Me._Option1_3.Text = "Quadrato ruotato"
		Me._Option1_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Option1_3.Size = New System.Drawing.Size(151, 21)
		Me._Option1_3.Location = New System.Drawing.Point(10, 60)
		Me._Option1_3.TabIndex = 3
		Me._Option1_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_3.CausesValidation = True
		Me._Option1_3.Enabled = True
		Me._Option1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_3.TabStop = True
		Me._Option1_3.Checked = False
		Me._Option1_3.Visible = True
		Me._Option1_3.Name = "_Option1_3"
		Me._Option1_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_2.BackColor = System.Drawing.SystemColors.Window
		Me._Option1_2.Text = "Quadrato"
		Me._Option1_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Option1_2.Size = New System.Drawing.Size(151, 21)
		Me._Option1_2.Location = New System.Drawing.Point(10, 40)
		Me._Option1_2.TabIndex = 2
		Me._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_2.CausesValidation = True
		Me._Option1_2.Enabled = True
		Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_2.TabStop = True
		Me._Option1_2.Checked = False
		Me._Option1_2.Visible = True
		Me._Option1_2.Name = "_Option1_2"
		Me._Option1_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_1.BackColor = System.Drawing.SystemColors.Window
		Me._Option1_1.Text = "Triangolare ruotato"
		Me._Option1_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Option1_1.Size = New System.Drawing.Size(151, 21)
		Me._Option1_1.Location = New System.Drawing.Point(10, 20)
		Me._Option1_1.TabIndex = 1
		Me._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_1.CausesValidation = True
		Me._Option1_1.Enabled = True
		Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_1.TabStop = True
		Me._Option1_1.Checked = False
		Me._Option1_1.Visible = True
		Me._Option1_1.Name = "_Option1_1"
		Me._Option1_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_0.BackColor = System.Drawing.SystemColors.Window
		Me._Option1_0.Text = "Triangolare"
		Me._Option1_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Option1_0.Size = New System.Drawing.Size(151, 21)
		Me._Option1_0.Location = New System.Drawing.Point(10, 0)
		Me._Option1_0.TabIndex = 0
		Me._Option1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_0.CausesValidation = True
		Me._Option1_0.Enabled = True
		Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Option1_0.TabStop = True
		Me._Option1_0.Checked = False
		Me._Option1_0.Visible = True
		Me._Option1_0.Name = "_Option1_0"
		Me.Controls.Add(Command1)
		Me.Controls.Add(_Picture1_3)
		Me.Controls.Add(_Picture1_2)
		Me.Controls.Add(_Picture1_1)
		Me.Controls.Add(_Picture1_0)
		Me.Controls.Add(_Option1_3)
		Me.Controls.Add(_Option1_2)
		Me.Controls.Add(_Option1_1)
		Me.Controls.Add(_Option1_0)
		Me.Option1.Add(3, _Option1_3)
		Me.Option1.Add(2, _Option1_2)
		Me.Option1.Add(1, _Option1_1)
		Me.Option1.Add(0, _Option1_0)
		Me.Picture1.Add(3, _Picture1_3)
		Me.Picture1.Add(2, _Picture1_2)
		Me.Picture1.Add(1, _Picture1_1)
		Me.Picture1.Add(0, _Picture1_0)

        For Each control In Option1.Values
            AddHandler control.CheckedChanged, AddressOf Option1_CheckedChanged
        Next
	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmTipoP
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmTipoP
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmTipoP()
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
	
	'UPGRADE_WARNING: Form evento frmTipoP.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmTipoP_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Dim i As Short
		For i = 0 To 3
			Picture1(i).Image = System.Drawing.Image.FromFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\TIPOP" & LTrim(Str(i)) & ".BMP")
		Next 
		Option1(DataSheet.DatiPrg.TubiInform.TipoP).Checked = True
	End Sub
	
	'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		If eventSender.Checked Then
			Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
			DataSheet.DatiPrg.TubiInform.TipoP = Index
			DataShe1.DefInstance.TipoP.Image = System.Drawing.Image.FromFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\TIPOP" & LTrim(Str(Index)) & ".BMP")
		End If
	End Sub
End Class