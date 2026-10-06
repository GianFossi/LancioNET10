Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmScelFla
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
        Inizializzando = True
		InitializeComponent()
        Inizializzando = False
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
    Public WithEvents Direzione As System.Windows.Forms.ComboBox
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents _Option2_1 As System.Windows.Forms.RadioButton
    Public WithEvents _Option2_0 As System.Windows.Forms.RadioButton
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Nome As System.Windows.Forms.ComboBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Option1_4 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_3 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmbFacing As System.Windows.Forms.ComboBox
    Public WithEvents cmbRating As System.Windows.Forms.ComboBox
    Public WithEvents cmbDiaN As System.Windows.Forms.ComboBox
    Public WithEvents cmbTab As System.Windows.Forms.ComboBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Option1 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents Option2 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.Direzione = New System.Windows.Forms.ComboBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me._Option2_1 = New System.Windows.Forms.RadioButton
        Me._Option2_0 = New System.Windows.Forms.RadioButton
        Me.Nome = New System.Windows.Forms.ComboBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Option1_4 = New System.Windows.Forms.RadioButton
        Me._Option1_3 = New System.Windows.Forms.RadioButton
        Me._Option1_2 = New System.Windows.Forms.RadioButton
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me.cmbFacing = New System.Windows.Forms.ComboBox
        Me.cmbRating = New System.Windows.Forms.ComboBox
        Me.cmbDiaN = New System.Windows.Forms.ComboBox
        Me.cmbTab = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Option1 = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.Option2 = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.Option1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Option2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.Direzione)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(160, 160)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(145, 41)
        Me.Frame3.TabIndex = 21
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Direzione"
        '
        'Direzione
        '
        Me.Direzione.BackColor = System.Drawing.SystemColors.Window
        Me.Direzione.Cursor = System.Windows.Forms.Cursors.Default
        Me.Direzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Direzione.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Direzione.Location = New System.Drawing.Point(8, 16)
        Me.Direzione.Name = "Direzione"
        Me.Direzione.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Direzione.Size = New System.Drawing.Size(129, 21)
        Me.Direzione.TabIndex = 22
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._Option2_1)
        Me.Frame2.Controls.Add(Me._Option2_0)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(160, 96)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(145, 57)
        Me.Frame2.TabIndex = 18
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Rappresentazione"
        '
        '_Option2_1
        '
        Me._Option2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.SetIndex(Me._Option2_1, CType(1, Short))
        Me._Option2_1.Location = New System.Drawing.Point(16, 32)
        Me._Option2_1.Name = "_Option2_1"
        Me._Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_1.Size = New System.Drawing.Size(81, 17)
        Me._Option2_1.TabIndex = 20
        Me._Option2_1.TabStop = True
        Me._Option2_1.Text = "In sezione"
        '
        '_Option2_0
        '
        Me._Option2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.SetIndex(Me._Option2_0, CType(0, Short))
        Me._Option2_0.Location = New System.Drawing.Point(16, 16)
        Me._Option2_0.Name = "_Option2_0"
        Me._Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_0.Size = New System.Drawing.Size(73, 17)
        Me._Option2_0.TabIndex = 19
        Me._Option2_0.TabStop = True
        Me._Option2_0.Text = "In vista"
        '
        'Nome
        '
        Me.Nome.BackColor = System.Drawing.SystemColors.Window
        Me.Nome.Cursor = System.Windows.Forms.Cursors.Default
        Me.Nome.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Nome.Location = New System.Drawing.Point(104, 208)
        Me.Nome.Name = "Nome"
        Me.Nome.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Nome.Size = New System.Drawing.Size(137, 21)
        Me.Nome.TabIndex = 17
        Me.Nome.Text = "Flangia 1"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(248, 0)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(57, 25)
        Me.Command2.TabIndex = 15
        Me.Command2.Text = "Annulla"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(248, 32)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(57, 25)
        Me.Command1.TabIndex = 14
        Me.Command1.Text = "OK"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._Option1_4)
        Me.Frame1.Controls.Add(Me._Option1_3)
        Me.Frame1.Controls.Add(Me._Option1_2)
        Me.Frame1.Controls.Add(Me._Option1_1)
        Me.Frame1.Controls.Add(Me._Option1_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 96)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(153, 105)
        Me.Frame1.TabIndex = 8
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Tipo flangia"
        '
        '_Option1_4
        '
        Me._Option1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_4, CType(4, Short))
        Me._Option1_4.Location = New System.Drawing.Point(16, 80)
        Me._Option1_4.Name = "_Option1_4"
        Me._Option1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_4.Size = New System.Drawing.Size(129, 13)
        Me._Option1_4.TabIndex = 13
        Me._Option1_4.TabStop = True
        '
        '_Option1_3
        '
        Me._Option1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_3, CType(3, Short))
        Me._Option1_3.Location = New System.Drawing.Point(16, 64)
        Me._Option1_3.Name = "_Option1_3"
        Me._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_3.Size = New System.Drawing.Size(129, 13)
        Me._Option1_3.TabIndex = 12
        Me._Option1_3.TabStop = True
        '
        '_Option1_2
        '
        Me._Option1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_2, CType(2, Short))
        Me._Option1_2.Location = New System.Drawing.Point(16, 48)
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Size = New System.Drawing.Size(121, 13)
        Me._Option1_2.TabIndex = 11
        Me._Option1_2.TabStop = True
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_1, CType(1, Short))
        Me._Option1_1.Location = New System.Drawing.Point(16, 32)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(121, 13)
        Me._Option1_1.TabIndex = 10
        Me._Option1_1.TabStop = True
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_0, CType(0, Short))
        Me._Option1_0.Location = New System.Drawing.Point(16, 16)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(113, 13)
        Me._Option1_0.TabIndex = 9
        Me._Option1_0.TabStop = True
        '
        'cmbFacing
        '
        Me.cmbFacing.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFacing.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbFacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacing.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbFacing.Location = New System.Drawing.Point(104, 72)
        Me.cmbFacing.Name = "cmbFacing"
        Me.cmbFacing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbFacing.Size = New System.Drawing.Size(136, 21)
        Me.cmbFacing.TabIndex = 7
        '
        'cmbRating
        '
        Me.cmbRating.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRating.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRating.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbRating.Location = New System.Drawing.Point(104, 48)
        Me.cmbRating.Name = "cmbRating"
        Me.cmbRating.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbRating.Size = New System.Drawing.Size(73, 21)
        Me.cmbRating.TabIndex = 5
        '
        'cmbDiaN
        '
        Me.cmbDiaN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDiaN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDiaN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiaN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDiaN.Location = New System.Drawing.Point(104, 24)
        Me.cmbDiaN.Name = "cmbDiaN"
        Me.cmbDiaN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDiaN.Size = New System.Drawing.Size(72, 21)
        Me.cmbDiaN.TabIndex = 3
        '
        'cmbTab
        '
        Me.cmbTab.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTab.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTab.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTab.Location = New System.Drawing.Point(104, 0)
        Me.cmbTab.Name = "cmbTab"
        Me.cmbTab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTab.Size = New System.Drawing.Size(134, 21)
        Me.cmbTab.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(0, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Nome del blocco"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(0, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(40, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Facing"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(0, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Rating"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Tabella"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(0, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Diametro nominale"
        '
        'frmScelFla
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(312, 231)
        Me.ControlBox = False
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Nome)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmbFacing)
        Me.Controls.Add(Me.cmbRating)
        Me.Controls.Add(Me.cmbDiaN)
        Me.Controls.Add(Me.cmbTab)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmScelFla"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Selezione flangia"
        Me.Frame3.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.Option1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Option2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmScelFla
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmScelFla
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmScelFla()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public OK As Boolean
    Private Inizializzando As Boolean
    Private Sub cmbDiaN_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDiaN.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        globFlangia.K1 = cmbDiaN.SelectedIndex + 1
        If Not cmbDiaN.Enabled Then Exit Sub
        Stop
        'globFlangia.RetrieveRECf(Me)
    End Sub
    Private Sub cmbFacing_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFacing.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        FacSav = globFlangia.Facing
        globFlangia.Facing = cmbFacing.SelectedIndex + 1
        If Not cmbFacing.Enabled Then Exit Sub
        Stop
        'globFlangia.AggFacing(Me)
    End Sub
    Private Sub cmbRating_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbRating.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        globFlangia.K2 = cmbRating.SelectedIndex + 1
        If Not cmbRating.Enabled Then Exit Sub
        Stop
        'globFlangia.RetrieveRECf(Me)
    End Sub
    Private Sub cmbTab_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTab.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        globFlangia.TabFlan = cmbTab.SelectedValue
        Call globFlangia.AggTab(Me)
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim i As Short
        For i = 0 To Nome.Items.Count - 1
            If VB6.GetItemString(Nome, i) = Nome.Text Then
                MsgBox("Il nome dato al nuovo blocco esiste già. Cambiarlo", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly)
                Exit Sub
            End If
        Next
        For i = 0 To 4
            If Option1(i).Checked Then Exit For
        Next
        globFlangia.K3 = i + 1
        OK = True
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        OK = False
        Hide()
    End Sub
    Private Sub AggiornaOptions()
        Dim i As Short
        Dim dv As DataView = New DataView(Tipi)
        dv.RowFilter = "Codice=" & Str(globFlangia.TabFlan)
        dv.Sort = "Indice"
        For i = 0 To dv.Count
            Option1(CShort(dv(i)("indice")) - 1).Text = CStr(dv(i)("Tipo"))
        Next
    End Sub
    Private Sub frmScelFla_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim block As AutoCAD.AcadBlock
        FormFlangia = New frmFlange 'allo scopo di IniziaBase
        AggiornaOptions()
        Option1(0).Checked = True
        For Each block In Monitor.AcadDis.Blocks
            If Len(block.Name) > 0 Then
                If Not VB.Left(block.Name, 1) = "*" Then
                    Nome.Items.Add(block.Name)
                End If
            End If
        Next block
        Option2(1).Checked = True
        Direzione.Items.Clear()
        Direzione.Items.Add("Verso l'alto")
        Direzione.Items.Add("Verso il basso")
        Direzione.Items.Add("Verso destra")
        Direzione.Items.Add("Verso sinistra")
        Direzione.Items.Add("Contro il foglio")
        Direzione.Items.Add("Verso l'osservatore")
        Direzione.SelectedIndex = 0
    End Sub
End Class