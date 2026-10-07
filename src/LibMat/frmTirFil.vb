Option Strict Off
Option Explicit On
Friend Class frmTirFil
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
	Public WithEvents cmbxFil As System.Windows.Forms.ComboBox
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.cmbxFil = New System.Windows.Forms.ComboBox
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(240, 24)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(46, 20)
        Me.Command1.TabIndex = 2
        Me.Command1.Text = "OK"
        '
        'cmbxFil
        '
        Me.cmbxFil.BackColor = System.Drawing.SystemColors.Window
        Me.cmbxFil.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbxFil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxFil.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbxFil.Location = New System.Drawing.Point(106, 0)
        Me.cmbxFil.Name = "cmbxFil"
        Me.cmbxFil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbxFil.Size = New System.Drawing.Size(180, 21)
        Me.cmbxFil.TabIndex = 0
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(6, 0)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(96, 20)
        Me._Label1_0.TabIndex = 1
        Me._Label1_0.Text = "Filettatura"
        '
        'frmTirFil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(288, 46)
        Me.ControlBox = False
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.cmbxFil)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(318, 286)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTirFil"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Libreria tiranti"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmTirFil
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmTirFil
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmTirFil()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	'UPGRADE_WARNING: L'evento cmbxFil.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub cmbxFil_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbxFil.SelectedIndexChanged
		Tirante.Xfil = cmbxFil.SelectedIndex + 1
	End Sub
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.Dispose()
    End Sub
    'UPGRADE_WARNING: Form evento frmTirFil.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmTirFil_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        AppActivate(Text)
    End Sub
    'Private Sub frmTirFil_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    Private Sub Inizializza()
        Dim i As Integer
        cmbxFil.Items.Clear()
        For i = 0 To Tirante.Tipi.Rows.Count - 1
            cmbxFil.Items.Add(Tirante.Tipi.Rows(i)("Descrizione"))
        Next
        cmbxFil.Enabled = False
        If Tirante.Xfil < 1 Then Tirante.Xfil = 1
        cmbxFil.SelectedIndex = Tirante.Xfil - 1
        cmbxFil.Enabled = True
    End Sub
End Class