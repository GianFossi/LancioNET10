Option Strict Off
Option Explicit On 
Imports System.Windows.forms
Friend Class SaldMand
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
    Public WithEvents Frame3D1 As Panel
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents _Option3D1_0 As System.Windows.Forms.RadioButton
    Friend WithEvents _Option3D1_1 As System.Windows.Forms.RadioButton
    Friend WithEvents _Option3D1_2 As System.Windows.Forms.RadioButton
    Friend WithEvents _Option3D1_3 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.Frame3D1 = New System.Windows.Forms.Panel
        Me._Option3D1_0 = New System.Windows.Forms.RadioButton
        Me._Option3D1_1 = New System.Windows.Forms.RadioButton
        Me._Option3D1_2 = New System.Windows.Forms.RadioButton
        Me._Option3D1_3 = New System.Windows.Forms.RadioButton
        Me.Frame3D1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(260, 40)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 21)
        Me.Command1.TabIndex = 5
        Me.Command1.Text = "&OK"
        '
        'Frame3D1
        '
        Me.Frame3D1.Controls.Add(Me._Option3D1_3)
        Me.Frame3D1.Controls.Add(Me._Option3D1_2)
        Me.Frame3D1.Controls.Add(Me._Option3D1_1)
        Me.Frame3D1.Controls.Add(Me._Option3D1_0)
        Me.Frame3D1.Location = New System.Drawing.Point(0, 0)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.Size = New System.Drawing.Size(251, 111)
        Me.Frame3D1.TabIndex = 0
        '
        '_Option3D1_0
        '
        Me._Option3D1_0.Location = New System.Drawing.Point(8, 8)
        Me._Option3D1_0.Name = "_Option3D1_0"
        Me._Option3D1_0.Size = New System.Drawing.Size(240, 16)
        Me._Option3D1_0.TabIndex = 0
        Me._Option3D1_0.Text = "RadioButton1"
        '
        '_Option3D1_1
        '
        Me._Option3D1_1.Location = New System.Drawing.Point(8, 32)
        Me._Option3D1_1.Name = "_Option3D1_1"
        Me._Option3D1_1.Size = New System.Drawing.Size(240, 16)
        Me._Option3D1_1.TabIndex = 1
        Me._Option3D1_1.Text = "RadioButton2"
        '
        '_Option3D1_2
        '
        Me._Option3D1_2.Location = New System.Drawing.Point(8, 56)
        Me._Option3D1_2.Name = "_Option3D1_2"
        Me._Option3D1_2.Size = New System.Drawing.Size(240, 16)
        Me._Option3D1_2.TabIndex = 2
        Me._Option3D1_2.Text = "RadioButton3"
        '
        '_Option3D1_3
        '
        Me._Option3D1_3.Location = New System.Drawing.Point(8, 80)
        Me._Option3D1_3.Name = "_Option3D1_3"
        Me._Option3D1_3.Size = New System.Drawing.Size(240, 16)
        Me._Option3D1_3.TabIndex = 3
        Me._Option3D1_3.Text = "RadioButton4"
        '
        'SaldMand
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(308, 112)
        Me.ControlBox = False
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Frame3D1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(312, 289)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaldMand"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mandrinatura per tubi saldati"
        Me.Frame3D1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As SaldMand
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As SaldMand
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New SaldMand()
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
    Private Sub SaldMand_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        _Option3D1_3.Visible = (DataShe1.DefInstance.ComboM(5).SelectedIndex = 1)
    End Sub
    Friend ReadOnly Property Option3D1(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _Option3D1_0
                Case 1 : Return _Option3D1_1
                Case 2 : Return _Option3D1_2
                Case 3 : Return _Option3D1_3
            End Select
        End Get
    End Property
    Private Sub Option3D1_Click(ByVal Index As Integer)
        If Option3D1(Index).Checked Then
            DataSheet.DatiPrg.TubiInform.TipoG = DataSheet.DatiPrg.TubiInform.TipoG + Index + 1
            'DataShe1.ComboM(5).Text = RTrim$(DataShe1.ComboM(5).Text) & " + " & Option3D1(Index).Caption
        End If
    End Sub

    Private Sub _Option3D1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_0.Click
        Option3D1_Click(0)
    End Sub

    Private Sub _Option3D1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_1.Click
        Option3D1_Click(1)
    End Sub

    Private Sub _Option3D1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_2.Click
        Option3D1_Click(2)
    End Sub

    Private Sub _Option3D1_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_3.Click
        Option3D1_Click(3)
    End Sub
End Class