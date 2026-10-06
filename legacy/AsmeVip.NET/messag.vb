Option Strict Off
Option Explicit On
Friend Class frmMsgDiaf
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
	Public WithEvents _Label2_4 As System.Windows.Forms.Label
	Public WithEvents _Label2_3 As System.Windows.Forms.Label
	Public WithEvents _Label2_2 As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(200, 56)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(137, 25)
        Me._Label2_4.TabIndex = 5
        Me._Label2_4.Text = "Label2"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(24, 112)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(137, 25)
        Me._Label2_3.TabIndex = 4
        Me._Label2_3.Text = "Label2"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(200, 112)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(129, 25)
        Me._Label2_2.TabIndex = 3
        Me._Label2_2.Text = "Label2"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(16, 64)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(137, 25)
        Me._Label2_1.TabIndex = 2
        Me._Label2_1.Text = "Label2"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(16, 40)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(345, 25)
        Me._Label2_0.TabIndex = 1
        Me._Label2_0.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(372, 187)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'frmMsgDiaf
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(387, 201)
        Me.Controls.Add(Me._Label2_4)
        Me.Controls.Add(Me._Label2_3)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(296, 252)
        Me.Name = "frmMsgDiaf"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Risultati calcolo diaframma"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmMsgDiaf
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMsgDiaf
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMsgDiaf()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Sub frmMsgDiaf_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim x, rit As Short
		'Dimensionamento label 1 del frmMsgDiaf
		Label1.Visible = False
		'Label1.Height = 2800
		'Label1.Width = 5850
		Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		'Label1.Top = 100
		'Label1.Left = 20
        Label1.Font = New Font(Label1.Font.FontFamily, 11, FontStyle.Bold, GraphicsUnit.Point)
        x = 600
		For rit = 0 To 4
			Label2(rit).Height = GlobalRoutines.TwipsToPixelsY(350)
			Label2(rit).Width = GlobalRoutines.TwipsToPixelsX(4800)
			Label2(rit).Left = GlobalRoutines.TwipsToPixelsX(240)
			Label2(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
			x = x + 360
		Next 
		
    End Sub
    Friend ReadOnly Property Label2(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _Label2_0
                Case 1 : Return _Label2_1
                Case 2 : Return _Label2_2
                Case 3 : Return _Label2_3
                Case 4 : Return _Label2_4
                Case Else : Return Nothing
            End Select
        End Get
    End Property
End Class