Option Strict Off
Option Explicit On
Friend Class frmFattUs
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
        Inizializza()
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
    Public WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFattUs))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.AccessibleDescription = resources.GetString("Command1.AccessibleDescription")
        Me.Command1.AccessibleName = resources.GetString("Command1.AccessibleName")
        Me.Command1.Anchor = CType(resources.GetObject("Command1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.BackgroundImage = CType(resources.GetObject("Command1.BackgroundImage"), System.Drawing.Image)
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Dock = CType(resources.GetObject("Command1.Dock"), System.Windows.Forms.DockStyle)
        Me.Command1.Enabled = CType(resources.GetObject("Command1.Enabled"), Boolean)
        Me.Command1.FlatStyle = CType(resources.GetObject("Command1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.Command1.Font = CType(resources.GetObject("Command1.Font"), System.Drawing.Font)
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Image = CType(resources.GetObject("Command1.Image"), System.Drawing.Image)
        Me.Command1.ImageAlign = CType(resources.GetObject("Command1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Command1.ImageIndex = CType(resources.GetObject("Command1.ImageIndex"), Integer)
        Me.Command1.ImeMode = CType(resources.GetObject("Command1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Command1.Location = CType(resources.GetObject("Command1.Location"), System.Drawing.Point)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = CType(resources.GetObject("Command1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Command1.Size = CType(resources.GetObject("Command1.Size"), System.Drawing.Size)
        Me.Command1.TabIndex = CType(resources.GetObject("Command1.TabIndex"), Integer)
        Me.Command1.Text = resources.GetString("Command1.Text")
        Me.Command1.TextAlign = CType(resources.GetObject("Command1.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.Command1, resources.GetString("Command1.ToolTip"))
        Me.Command1.Visible = CType(resources.GetObject("Command1.Visible"), Boolean)
        '
        'Picture1
        '
        Me.Picture1.AccessibleDescription = resources.GetString("Picture1.AccessibleDescription")
        Me.Picture1.AccessibleName = resources.GetString("Picture1.AccessibleName")
        Me.Picture1.Anchor = CType(resources.GetObject("Picture1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BackgroundImage = CType(resources.GetObject("Picture1.BackgroundImage"), System.Drawing.Image)
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Dock = CType(resources.GetObject("Picture1.Dock"), System.Windows.Forms.DockStyle)
        Me.Picture1.Enabled = CType(resources.GetObject("Picture1.Enabled"), Boolean)
        Me.Picture1.Font = CType(resources.GetObject("Picture1.Font"), System.Drawing.Font)
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
        Me.Picture1.ImeMode = CType(resources.GetObject("Picture1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Picture1.Location = CType(resources.GetObject("Picture1.Location"), System.Drawing.Point)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = CType(resources.GetObject("Picture1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Picture1.Size = CType(resources.GetObject("Picture1.Size"), System.Drawing.Size)
        Me.Picture1.SizeMode = CType(resources.GetObject("Picture1.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.Picture1.TabIndex = CType(resources.GetObject("Picture1.TabIndex"), Integer)
        Me.Picture1.TabStop = False
        Me.Picture1.Text = resources.GetString("Picture1.Text")
        Me.ToolTip1.SetToolTip(Me.Picture1, resources.GetString("Picture1.ToolTip"))
        Me.Picture1.Visible = CType(resources.GetObject("Picture1.Visible"), Boolean)
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = resources.GetString("Button1.AccessibleDescription")
        Me.Button1.AccessibleName = resources.GetString("Button1.AccessibleName")
        Me.Button1.Anchor = CType(resources.GetObject("Button1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Dock = CType(resources.GetObject("Button1.Dock"), System.Windows.Forms.DockStyle)
        Me.Button1.Enabled = CType(resources.GetObject("Button1.Enabled"), Boolean)
        Me.Button1.FlatStyle = CType(resources.GetObject("Button1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.Button1.Font = CType(resources.GetObject("Button1.Font"), System.Drawing.Font)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = CType(resources.GetObject("Button1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Button1.ImageIndex = CType(resources.GetObject("Button1.ImageIndex"), Integer)
        Me.Button1.ImeMode = CType(resources.GetObject("Button1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Button1.Location = CType(resources.GetObject("Button1.Location"), System.Drawing.Point)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = CType(resources.GetObject("Button1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Button1.Size = CType(resources.GetObject("Button1.Size"), System.Drawing.Size)
        Me.Button1.TabIndex = CType(resources.GetObject("Button1.TabIndex"), Integer)
        Me.Button1.Text = resources.GetString("Button1.Text")
        Me.Button1.TextAlign = CType(resources.GetObject("Button1.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.Button1, resources.GetString("Button1.ToolTip"))
        Me.Button1.Visible = CType(resources.GetObject("Button1.Visible"), Boolean)
        '
        'frmFattUs
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Picture1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmFattUs"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmFattUs
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmFattUs
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmFattUs()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
    Public mygraphics As Graphics
    Public myfont As Font
    Public mybrush As SolidBrush
    Public x, y As Single
    Private dovebitmap As Bitmap
    Private Sub Inizializza()
        dovebitmap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height)
        mygraphics = Graphics.FromImage(dovebitmap)
        Picture1.Image = dovebitmap
        myfont = Picture1.Font
        mybrush = New SolidBrush(Color.Black)
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, "Semaforo.htm")
    End Sub
End Class