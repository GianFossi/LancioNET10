Option Strict On
Option Explicit On
Friend Class frmLavoriSciolti
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
        IsInitializing = True
		InitializeComponent()
        IsInitializing = False
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
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLavoriSciolti))
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ToolTip1.Active = True
        Me.Command1 = New System.Windows.Forms.Button
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = "Organizzazione dell'archivio lavori"
        Me.ClientSize = New System.Drawing.Size(413, 57)
        Me.Location = New System.Drawing.Point(2, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.HelpButton = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmLavoriSciolti"
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Command1.Text = "OK"
        Me.Command1.Size = New System.Drawing.Size(57, 25)
        Me.Command1.Location = New System.Drawing.Point(351, 27)
        Me.Command1.TabIndex = 1
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.CausesValidation = True
        Me.Command1.Enabled = True
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.TabStop = True
        Me.Command1.Name = "Command1"
        Me.Check1.Text = "Lavori strutturati in commesse e sottocommesse"
        Me.Check1.Size = New System.Drawing.Size(281, 25)
        Me.Check1.Location = New System.Drawing.Point(24, 16)
        Me.Check1.TabIndex = 0
        Me.Check1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Check1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.CausesValidation = True
        Me.Check1.Enabled = True
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Appearance = System.Windows.Forms.Appearance.Normal
        Me.Check1.TabStop = True
        Me.Check1.Visible = True
        Me.Check1.Name = "Check1"
        Me.Controls.Add(Command1)
        Me.Controls.Add(Check1)
    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmLavoriSciolti
    Private Shared m_InitializingDefInstance As Boolean
    Private prIsInitializing As Boolean
    Private Property IsInitializing() As Boolean
        Get
            Return prIsInitializing
        End Get
        Set(ByVal Value As Boolean)
            prIsInitializing = Value
        End Set
    End Property
    Public Shared Property DefInstance() As frmLavoriSciolti
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmLavoriSciolti
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmLavoriSciolti)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region 
    Public Motore As RoutBase1.clsMotore
	Public NonCambia As Boolean
    'UPGRADE_WARNING: L'evento Check1.CheckStateChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Not IsInitializing Then
            Motore.Inizio.LavoriSciolti = Check1.CheckState = 0
        End If
	End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Motore.Inizio.LavoriSciolti = Not (Check1.CheckState = 1)
        frmLavoriSciolti.DefInstance.Hide()
        Me.Close()
    End Sub
    Private Sub frmLavoriSciolti_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Select Case Motore.Inizio.LavoriSciolti
            Case True : Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
            Case False : Check1.CheckState = System.Windows.Forms.CheckState.Checked
        End Select
        If NonCambia Then Check1.Enabled = False
    End Sub
End Class