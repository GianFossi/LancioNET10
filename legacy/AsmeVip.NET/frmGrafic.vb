Option Strict Off
Option Explicit On
Friend Class frmGrafic
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'If m_vb6FormDefInstance Is Nothing Then
        '      If m_InitializingDefInstance Then
        '     m_vb6FormDefInstance = Me
        '    Else
        '       Try
        '  'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        ' If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        'm_vb6FormDefInstance = Me
        'End If
        '    Catch
        'End Try
        'End If
        'End If
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
        'Inizializza()
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
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Public WithEvents cmdHelp As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(528, 0)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(82, 28)
        Me.Command1.TabIndex = 1
        Me.Command1.Text = "Avanti"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Window
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me.Picture1, "Grafici.htm#Simboli")
        Me.HelpProvider1.SetHelpNavigator(Me.Picture1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Picture1.Location = New System.Drawing.Point(9, 36)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.Picture1, True)
        Me.Picture1.Size = New System.Drawing.Size(605, 408)
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = False
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(440, 0)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(82, 28)
        Me.cmdHelp.TabIndex = 2
        Me.cmdHelp.Text = "Help"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(352, 0)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(82, 28)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'frmGrafic
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(630, 460)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Picture1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(4, 24)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGrafic"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Grafico di controllo"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
    'Private Shared m_vb6FormDefInstance As frmGrafic
    'Private Shared m_InitializingDefInstance As Boolean
    'Public Shared Property DefInstance() As frmGrafic
    '		Get
    '			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '				m_InitializingDefInstance = True
    '				m_vb6FormDefInstance = New frmGrafic()
    '				m_InitializingDefInstance = False
    '			End If
    '			DefInstance = m_vb6FormDefInstance
    '		End Get
    '		Set
    '			m_vb6FormDefInstance = Value
    '		End Set
    '	End Property
#End Region
    'Public mygraphics As Graphics
    'Private dovebitmap As Bitmap
    Public OK As Boolean
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        OK = True
        Hide()
    End Sub
    Private Sub Inizializza()
        'dovebitmap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height)
        'mygraphics = Graphics.FromImage(dovebitmap)
        'Picture1.Image = dovebitmap
        HelpProvider1.HelpNamespace = RadiceHelp
        OK = False
    End Sub

    Private Sub cmdHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, "Grafici.htm")

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        OK = False
        Hide()
    End Sub
End Class