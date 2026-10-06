Option Strict On
Option Explicit On
Friend Class frmGrafico
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
	Public WithEvents Pittura As System.Windows.Forms.PictureBox
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGrafico))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Pittura = New System.Windows.Forms.PictureBox
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.Text = "Grafico"
		Me.ClientSize = New System.Drawing.Size(613, 384)
		Me.Location = New System.Drawing.Point(14, 24)
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.AutoScaleBaseSize = New System.Drawing.Size(0, 0)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmGrafico"
		Me.Pittura.BackColor = System.Drawing.SystemColors.Window
		Me.Pittura.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Pittura.Size = New System.Drawing.Size(611, 381)
		Me.Pittura.Location = New System.Drawing.Point(0, 0)
		Me.Pittura.TabIndex = 0
		Me.Pittura.Dock = System.Windows.Forms.DockStyle.None
		Me.Pittura.CausesValidation = True
		Me.Pittura.Enabled = True
		Me.Pittura.Cursor = System.Windows.Forms.Cursors.Default
		Me.Pittura.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Pittura.TabStop = True
		Me.Pittura.Visible = True
		Me.Pittura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Pittura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Pittura.Name = "Pittura"
		Me.Controls.Add(Pittura)
	End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmGrafico
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmGrafico
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmGrafico()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public obj As clsGrafico
    Private PTop, PLeft As Integer
    Private PHeight, PWidth As Integer
    Private HeightV, WidthV As Integer
	
	Private Sub frmGrafico_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        PTop = Pittura.Top
        PLeft = Pittura.Left
        PHeight = Pittura.Height
        PWidth = Pittura.Width
        HeightV = Height
        WidthV = Width
		
	End Sub
    Private Sub frmGrafico_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim FactH, FactW As Single
        Dim gPittura As Graphics = Graphics.FromHwnd(Pittura.Handle)
        gPittura.Clear(Color.White)
        FactH = CSng(Height / HeightV)
        FactW = CSng(Width / WidthV)
        Pittura.Top = CInt(PTop * FactH)
        Pittura.Left = CInt(PLeft * FactW)
        Pittura.Height = CInt(PHeight * FactH)
        Pittura.Width = CInt(PWidth * FactW)
        Call obj.SSetGrafico()
        Call obj.SDisCurva()
        PTop = Pittura.Top
        PLeft = Pittura.Left
        PHeight = Pittura.Height
        PWidth = Pittura.Width
        HeightV = Height
        WidthV = Width
    End Sub

    'UPGRADE_WARNING: Form evento frmGrafico.Unload presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmGrafico_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        '  SavePicture Pittura.Image, obj.Motore.Inizio.DiscoRam + "\PIC.WMF"
    End Sub
End Class