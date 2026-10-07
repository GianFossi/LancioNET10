Option Strict On
Option Explicit On 
Imports RoutBase1
Friend Class frmMessaggio
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'If m_vb6FormDefInstance Is Nothing Then
        '       If m_InitializingDefInstance Then
        '       m_vb6FormDefInstance = Me
        '       Else
        '           Try
        '       'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        '       If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        '       m_vb6FormDefInstance = Me
        '       End If
        '           Catch
        '       End Try
        '       End If
        '		End If
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
        LoadCommand1()
        LoadCommand2()
        LoadCommand3()
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
	Public WithEvents _Picture1_3 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_2 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
	Public WithEvents _Command1_0 As System.Windows.Forms.Button
    Public WithEvents _Command1_1 As System.Windows.Forms.Button
    Public WithEvents _Command1_2 As System.Windows.Forms.Button
    Public WithEvents _Command1_3 As System.Windows.Forms.Button
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessaggio))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Picture1_3 = New System.Windows.Forms.PictureBox
        Me._Picture1_2 = New System.Windows.Forms.PictureBox
        Me._Picture1_1 = New System.Windows.Forms.PictureBox
        Me._Picture1_0 = New System.Windows.Forms.PictureBox
        Me._Command1_0 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        '_Picture1_3
        '
        Me._Picture1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Picture1_3.Image = CType(resources.GetObject("_Picture1_3.Image"), System.Drawing.Image)
        Me._Picture1_3.Location = New System.Drawing.Point(9, 135)
        Me._Picture1_3.Name = "_Picture1_3"
        Me._Picture1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_3.Size = New System.Drawing.Size(33, 33)
        Me._Picture1_3.TabIndex = 5
        Me._Picture1_3.TabStop = False
        Me._Picture1_3.Visible = False
        '
        '_Picture1_2
        '
        Me._Picture1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Picture1_2.Image = CType(resources.GetObject("_Picture1_2.Image"), System.Drawing.Image)
        Me._Picture1_2.Location = New System.Drawing.Point(8, 88)
        Me._Picture1_2.Name = "_Picture1_2"
        Me._Picture1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_2.Size = New System.Drawing.Size(33, 33)
        Me._Picture1_2.TabIndex = 4
        Me._Picture1_2.TabStop = False
        Me._Picture1_2.Visible = False
        '
        '_Picture1_1
        '
        Me._Picture1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Picture1_1.Image = CType(resources.GetObject("_Picture1_1.Image"), System.Drawing.Image)
        Me._Picture1_1.Location = New System.Drawing.Point(8, 40)
        Me._Picture1_1.Name = "_Picture1_1"
        Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_1.Size = New System.Drawing.Size(33, 33)
        Me._Picture1_1.TabIndex = 3
        Me._Picture1_1.TabStop = False
        Me._Picture1_1.Visible = False
        '
        '_Picture1_0
        '
        Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Picture1_0.Image = CType(resources.GetObject("_Picture1_0.Image"), System.Drawing.Image)
        Me._Picture1_0.Location = New System.Drawing.Point(8, 0)
        Me._Picture1_0.Name = "_Picture1_0"
        Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_0.Size = New System.Drawing.Size(33, 33)
        Me._Picture1_0.TabIndex = 2
        Me._Picture1_0.TabStop = False
        Me._Picture1_0.Visible = False
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_0.Location = New System.Drawing.Point(136, 176)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(81, 25)
        Me._Command1_0.TabIndex = 0
        Me._Command1_0.Text = "OK"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(56, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 160)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "MyText"
        '
        'frmMessaggio
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(323, 203)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._Picture1_3)
        Me.Controls.Add(Me._Picture1_2)
        Me.Controls.Add(Me._Picture1_1)
        Me.Controls.Add(Me._Picture1_0)
        Me.Controls.Add(Me._Command1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessaggio"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
    '	Private Shared m_vb6FormDefInstance As frmMessaggio
    '	Private Shared m_InitializingDefInstance As Boolean
    'Public Shared Property DefInstance() As frmMessaggio
    '		Get
    '			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '				m_InitializingDefInstance = True
    '				m_vb6FormDefInstance = New frmMessaggio()
    '				m_InitializingDefInstance = False
    '			End If
    '			DefInstance = m_vb6FormDefInstance
    '		End Get
    '		Set
    '			m_vb6FormDefInstance = Value
    '		End Set
    '	End Property
#End Region 
    Public Motore As RoutBase1.clsMotore
	Public chm As String
    Public id As String
    Private Sub frmMessaggio_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        TopMost = True
    End Sub
    Private Sub LoadCommand1()
        Me._Command1_1 = New System.Windows.Forms.Button
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_1.Location = New System.Drawing.Point(136, 176)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(81, 25)
        Me._Command1_1.TabIndex = 1
        Me._Command1_1.Text = "OK1"
        Me.Controls.Add(Me._Command1_1)
        Me._Command1_1.Visible = False
    End Sub
    Private Sub LoadCommand2()
        Me._Command1_2 = New System.Windows.Forms.Button
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_2.Location = New System.Drawing.Point(136, 176)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(81, 25)
        Me._Command1_2.TabIndex = 2
        Me._Command1_2.Text = "OK2"
        Me.Controls.Add(Me._Command1_2)
        Me._Command1_2.Visible = False
    End Sub
    Private Sub LoadCommand3()
        Me._Command1_3 = New System.Windows.Forms.Button
        '
        '_Command1_3
        '
        Me._Command1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_3.Location = New System.Drawing.Point(136, 176)
        Me._Command1_3.Name = "_Command1_3"
        Me._Command1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_3.Size = New System.Drawing.Size(81, 25)
        Me._Command1_3.TabIndex = 3
        Me._Command1_3.Text = "OK3"
        Me.Controls.Add(Me._Command1_3)
        Me._Command1_3.Visible = False
    End Sub

    Private Sub _Command1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_0.Click
        Select Case _Command1_0.Text
            Case "OK" : Motore.RispostaMessaggio = ChiaviMess.MessOK
            Case "Si" : Motore.RispostaMessaggio = ChiaviMess.MessSi
            Case "Ignora" : Motore.RispostaMessaggio = ChiaviMess.MessIgnora
        End Select
        Hide()

    End Sub

    Private Sub _Command1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_1.Click
        Select Case _Command1_1.Text
            Case "No" : Motore.RispostaMessaggio = ChiaviMess.Messno
            Case "Annulla" : Motore.RispostaMessaggio = ChiaviMess.MessCancel
        End Select
        Hide()

    End Sub

    Private Sub _Command1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_2.Click
        Select Case _Command1_2.Text
            Case "Help" ': hwndHelp = HtmlHelp(Handle.ToInt32, chm, HH_HELP_CONTEXT, id)
                Help.ShowHelp(Me, chm, HelpNavigator.Topic, id)
            Case "Annulla" : Motore.RispostaMessaggio = ChiaviMess.MessCancel
                Hide()
        End Select
    End Sub

    Private Sub _Command1_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_3.Click
        Help.ShowHelp(Me, chm, HelpNavigator.Topic, id)
    End Sub

    Private Sub Label1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Resize

    End Sub
End Class
