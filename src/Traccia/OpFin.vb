Option Strict Off
Option Explicit On
Friend Class frmOpFin
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
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents _Combo1_6 As System.Windows.Forms.ComboBox
	Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
	Public WithEvents _Combo1_4 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_3 As System.Windows.Forms.ComboBox
	Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents cmdFindMat As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOpFin))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command3 = New System.Windows.Forms.Button
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.Command2 = New System.Windows.Forms.Button
        Me._Combo1_6 = New System.Windows.Forms.ComboBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Combo1_4 = New System.Windows.Forms.ComboBox
        Me._Combo1_3 = New System.Windows.Forms.ComboBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.cmdFindMat = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(288, 176)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(41, 25)
        Me.Command3.TabIndex = 17
        Me.Command3.Text = "OK"
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 176)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(153, 17)
        Me.Check1.TabIndex = 16
        Me.Check1.TabStop = False
        Me.Check1.Text = "Controllo sul file .ADU"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(232, 176)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 25)
        Me.Command2.TabIndex = 14
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        '_Combo1_6
        '
        Me._Combo1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_6.Location = New System.Drawing.Point(160, 152)
        Me._Combo1_6.Name = "_Combo1_6"
        Me._Combo1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_6.Size = New System.Drawing.Size(65, 22)
        Me._Combo1_6.TabIndex = 13
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(160, 128)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(65, 19)
        Me._Text1_5.TabIndex = 12
        Me._Text1_5.Text = ""
        '
        '_Combo1_4
        '
        Me._Combo1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_4.Location = New System.Drawing.Point(160, 104)
        Me._Combo1_4.Name = "_Combo1_4"
        Me._Combo1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_4.Size = New System.Drawing.Size(65, 22)
        Me._Combo1_4.TabIndex = 11
        '
        '_Combo1_3
        '
        Me._Combo1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_3.Location = New System.Drawing.Point(160, 80)
        Me._Combo1_3.Name = "_Combo1_3"
        Me._Combo1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_3.Size = New System.Drawing.Size(65, 22)
        Me._Combo1_3.TabIndex = 10
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(160, 56)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(65, 19)
        Me._Text1_2.TabIndex = 9
        Me._Text1_2.Text = ""
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(160, 32)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(169, 19)
        Me._Text1_1.TabIndex = 8
        Me._Text1_1.Text = ""
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(160, 8)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(136, 19)
        Me._Text1_0.TabIndex = 7
        Me._Text1_0.Text = ""
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(8, 152)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(145, 17)
        Me._Label1_6.TabIndex = 6
        Me._Label1_6.Text = "Passo barre               [mm]"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(8, 128)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(145, 17)
        Me._Label1_5.TabIndex = 5
        Me._Label1_5.Text = "Incremento chioma    [mm]"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(8, 104)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(152, 17)
        Me._Label1_4.TabIndex = 4
        Me._Label1_4.Text = "Materiale speciale / normale"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(8, 80)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(145, 17)
        Me._Label1_3.TabIndex = 3
        Me._Label1_3.Text = "Rapporto con intestazione"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(8, 56)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(145, 17)
        Me._Label1_2.TabIndex = 2
        Me._Label1_2.Text = "Revisione"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(8, 32)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(145, 17)
        Me._Label1_1.TabIndex = 1
        Me._Label1_1.Text = "Identificazione documento"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(8, 8)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(145, 17)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "Materiale Base"
        '
        'cmdFindMat
        '
        Me.cmdFindMat.Image = CType(resources.GetObject("cmdFindMat.Image"), System.Drawing.Image)
        Me.cmdFindMat.Location = New System.Drawing.Point(304, 8)
        Me.cmdFindMat.Name = "cmdFindMat"
        Me.cmdFindMat.Size = New System.Drawing.Size(24, 24)
        Me.cmdFindMat.TabIndex = 18
        '
        'frmOpFin
        '
        Me.AcceptButton = Me.Command3
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(334, 206)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdFindMat)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me._Combo1_6)
        Me.Controls.Add(Me._Text1_5)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me._Combo1_4)
        Me.Controls.Add(Me._Combo1_3)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpFin"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dati Finali"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmOpFin
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmOpFin
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmOpFin()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Annullato = True
        frmOpFin.DefInstance.Hide()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Annullato = False
        frmOpFin.DefInstance.Hide()
    End Sub

    Private Sub frmOpFin_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If DaTos(0).dt(1) > 0 Then
            Mat.Indmat = DaTos(0).dt(1)
            Mat.RecupMat(Monitor.Motore.Inizio.Archdir)
            _Text1_0.Text = Mat.MatStr
        Else
            _Text1_0.Text = ""
        End If
        _Text1_1.Text = System.IO.Path.GetFileNameWithoutExtension(gencommes) & "-TU-000"
        _Text1_2.Text = "00"
        _Combo1_3.Items.Add("Si")
        _Combo1_3.Items.Add("No")
        If Monitor.Motore.Problem.Intest Then _Combo1_3.SelectedIndex = 0 Else _Combo1_3.SelectedIndex = 1
        _Combo1_4.Items.Add("Normale")
        _Combo1_4.Items.Add("Speciale")
        _Combo1_4.SelectedIndex = 0
        _Combo1_6.Items.Add("300")
        _Combo1_6.Items.Add("500")
        _Combo1_6.SelectedIndex = 0
        _Text1_5.Text = "0"
        If DaTos(iDat).TipoFascio < 3 Then
            Text = Text & " - Tubi diritti"
            _Combo1_6.Visible = False
            _Label1_6.Visible = False
            _Text1_5.Visible = False
            _Label1_5.Visible = False
            Check1.Visible = False
        ElseIf DaTos(iDat).TipoFascio = 4 Then
            Check1.Visible = False
            Text = Text & " - Tubi ad U a fontana"
        Else
            Text = Text & " - Tubi ad U"
        End If
    End Sub

    Private Sub Combo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdFindMat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFindMat.Click
        Mat.Scelta(4, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
        _Text1_0.Text = Mat.MatStr
        PesoSpTubi = Mat.PSP
        DaTos(0).dt(1) = Str(Mat.Indmat)
        SaveAll()

    End Sub
End Class