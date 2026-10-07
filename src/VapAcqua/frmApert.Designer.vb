<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmApert
#Region "Codice generato da Progettazione Windows Form "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializzando = False
	End Sub
	'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
	Public WithEvents cmdCalc As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _Label2_11 As System.Windows.Forms.Label
	Public WithEvents _Label1_13 As System.Windows.Forms.Label
	Public WithEvents _Label2_10 As System.Windows.Forms.Label
	Public WithEvents _Label1_12 As System.Windows.Forms.Label
	Public WithEvents _Label2_9 As System.Windows.Forms.Label
	Public WithEvents _Label1_11 As System.Windows.Forms.Label
	Public WithEvents _Label2_8 As System.Windows.Forms.Label
	Public WithEvents _Label1_10 As System.Windows.Forms.Label
	Public WithEvents _Label2_7 As System.Windows.Forms.Label
	Public WithEvents _Label1_9 As System.Windows.Forms.Label
	Public WithEvents _Label2_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents _Frame2_1 As System.Windows.Forms.GroupBox
	Public WithEvents _Label1_7 As System.Windows.Forms.Label
	Public WithEvents _Label2_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label2_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label2_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label2_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents _Frame2_0 As System.Windows.Forms.GroupBox
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
	Public WithEvents _Option2_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option2_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public Frame2 As New System.Collections.Generic.Dictionary(Of Integer, GroupBox)
	Public Label1 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public Label2 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public Option2 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
	Public Text1 As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCalc = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._Frame2_1 = New System.Windows.Forms.GroupBox
        Me._Label2_11 = New System.Windows.Forms.Label
        Me._Label1_13 = New System.Windows.Forms.Label
        Me._Label2_10 = New System.Windows.Forms.Label
        Me._Label1_12 = New System.Windows.Forms.Label
        Me._Label2_9 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label2_8 = New System.Windows.Forms.Label
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label2_7 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Frame2_0 = New System.Windows.Forms.GroupBox
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Option2_1 = New System.Windows.Forms.RadioButton
        Me._Option2_0 = New System.Windows.Forms.RadioButton
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me._Frame2_1.SuspendLayout()
        Me._Frame2_0.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCalc
        '
        Me.cmdCalc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalc.Location = New System.Drawing.Point(278, 72)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalc.Size = New System.Drawing.Size(82, 28)
        Me.cmdCalc.TabIndex = 35
        Me.cmdCalc.Text = "Calcola"
        Me.cmdCalc.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(494, 261)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(64, 28)
        Me.Command1.TabIndex = 34
        Me.Command1.Text = "Finito"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_Frame2_1
        '
        Me._Frame2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frame2_1.Controls.Add(Me._Label2_11)
        Me._Frame2_1.Controls.Add(Me._Label1_13)
        Me._Frame2_1.Controls.Add(Me._Label2_10)
        Me._Frame2_1.Controls.Add(Me._Label1_12)
        Me._Frame2_1.Controls.Add(Me._Label2_9)
        Me._Frame2_1.Controls.Add(Me._Label1_11)
        Me._Frame2_1.Controls.Add(Me._Label2_8)
        Me._Frame2_1.Controls.Add(Me._Label1_10)
        Me._Frame2_1.Controls.Add(Me._Label2_7)
        Me._Frame2_1.Controls.Add(Me._Label1_9)
        Me._Frame2_1.Controls.Add(Me._Label2_6)
        Me._Frame2_1.Controls.Add(Me._Label1_8)
        Me._Frame2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Add(1, Me._Frame2_1)
        Me._Frame2_1.Location = New System.Drawing.Point(287, 117)
        Me._Frame2_1.Name = "_Frame2_1"
        Me._Frame2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame2_1.Size = New System.Drawing.Size(271, 136)
        Me._Frame2_1.TabIndex = 21
        Me._Frame2_1.TabStop = False
        Me._Frame2_1.Text = "Risultati per la fase aeriforme"
        '
        '_Label2_11
        '
        Me._Label2_11.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(11, Me._Label2_11)
        Me._Label2_11.Location = New System.Drawing.Point(180, 18)
        Me._Label2_11.Name = "_Label2_11"
        Me._Label2_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_11.Size = New System.Drawing.Size(73, 19)
        Me._Label2_11.TabIndex = 33
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(13, Me._Label1_13)
        Me._Label1_13.Location = New System.Drawing.Point(9, 18)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(154, 19)
        Me._Label1_13.TabIndex = 32
        Me._Label1_13.Text = "Entalpia (kJ/kg)"
        '
        '_Label2_10
        '
        Me._Label2_10.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(10, Me._Label2_10)
        Me._Label2_10.Location = New System.Drawing.Point(180, 36)
        Me._Label2_10.Name = "_Label2_10"
        Me._Label2_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_10.Size = New System.Drawing.Size(73, 19)
        Me._Label2_10.TabIndex = 31
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(12, Me._Label1_12)
        Me._Label1_12.Location = New System.Drawing.Point(9, 36)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(154, 19)
        Me._Label1_12.TabIndex = 30
        Me._Label1_12.Text = "Calore specifico (J/kg°C)"
        '
        '_Label2_9
        '
        Me._Label2_9.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(9, Me._Label2_9)
        Me._Label2_9.Location = New System.Drawing.Point(180, 54)
        Me._Label2_9.Name = "_Label2_9"
        Me._Label2_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_9.Size = New System.Drawing.Size(73, 19)
        Me._Label2_9.TabIndex = 29
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(11, Me._Label1_11)
        Me._Label1_11.Location = New System.Drawing.Point(9, 54)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(154, 19)
        Me._Label1_11.TabIndex = 28
        Me._Label1_11.Text = "Volume specifico (m3/kg)"
        '
        '_Label2_8
        '
        Me._Label2_8.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(8, Me._Label2_8)
        Me._Label2_8.Location = New System.Drawing.Point(180, 72)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(73, 19)
        Me._Label2_8.TabIndex = 27
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(10, Me._Label1_10)
        Me._Label1_10.Location = New System.Drawing.Point(9, 72)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(154, 19)
        Me._Label1_10.TabIndex = 26
        Me._Label1_10.Text = "Densità (kg/m3)"
        '
        '_Label2_7
        '
        Me._Label2_7.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(7, Me._Label2_7)
        Me._Label2_7.Location = New System.Drawing.Point(180, 90)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(73, 19)
        Me._Label2_7.TabIndex = 25
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(9, Me._Label1_9)
        Me._Label1_9.Location = New System.Drawing.Point(9, 90)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(154, 19)
        Me._Label1_9.TabIndex = 24
        Me._Label1_9.Text = "Viscosità cinematica (kg/m.s)"
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(6, Me._Label2_6)
        Me._Label2_6.Location = New System.Drawing.Point(180, 108)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(73, 19)
        Me._Label2_6.TabIndex = 23
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(8, Me._Label1_8)
        Me._Label1_8.Location = New System.Drawing.Point(9, 108)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(154, 19)
        Me._Label1_8.TabIndex = 22
        Me._Label1_8.Text = "Conducibilità termica (w/m°C)"
        '
        '_Frame2_0
        '
        Me._Frame2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frame2_0.Controls.Add(Me._Label1_7)
        Me._Frame2_0.Controls.Add(Me._Label2_5)
        Me._Frame2_0.Controls.Add(Me._Label1_6)
        Me._Frame2_0.Controls.Add(Me._Label2_4)
        Me._Frame2_0.Controls.Add(Me._Label1_5)
        Me._Frame2_0.Controls.Add(Me._Label2_3)
        Me._Frame2_0.Controls.Add(Me._Label1_4)
        Me._Frame2_0.Controls.Add(Me._Label2_2)
        Me._Frame2_0.Controls.Add(Me._Label1_3)
        Me._Frame2_0.Controls.Add(Me._Label2_1)
        Me._Frame2_0.Controls.Add(Me._Label1_2)
        Me._Frame2_0.Controls.Add(Me._Label2_0)
        Me._Frame2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Add(0, Me._Frame2_0)
        Me._Frame2_0.Location = New System.Drawing.Point(8, 117)
        Me._Frame2_0.Name = "_Frame2_0"
        Me._Frame2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame2_0.Size = New System.Drawing.Size(271, 136)
        Me._Frame2_0.TabIndex = 8
        Me._Frame2_0.TabStop = False
        Me._Frame2_0.Text = "Risultati per la fase liquida"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(7, Me._Label1_7)
        Me._Label1_7.Location = New System.Drawing.Point(9, 108)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(154, 19)
        Me._Label1_7.TabIndex = 20
        Me._Label1_7.Text = "Conducibilità termica (w/m°C)"
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(5, Me._Label2_5)
        Me._Label2_5.Location = New System.Drawing.Point(180, 108)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(73, 19)
        Me._Label2_5.TabIndex = 19
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(6, Me._Label1_6)
        Me._Label1_6.Location = New System.Drawing.Point(9, 90)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(154, 19)
        Me._Label1_6.TabIndex = 18
        Me._Label1_6.Text = "Viscosità cinematica (kg/m.s)"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(4, Me._Label2_4)
        Me._Label2_4.Location = New System.Drawing.Point(180, 90)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(73, 19)
        Me._Label2_4.TabIndex = 17
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(5, Me._Label1_5)
        Me._Label1_5.Location = New System.Drawing.Point(9, 72)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(154, 19)
        Me._Label1_5.TabIndex = 16
        Me._Label1_5.Text = "Densità (kg/m3)"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(3, Me._Label2_3)
        Me._Label2_3.Location = New System.Drawing.Point(180, 72)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(73, 19)
        Me._Label2_3.TabIndex = 15
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(4, Me._Label1_4)
        Me._Label1_4.Location = New System.Drawing.Point(9, 54)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(154, 19)
        Me._Label1_4.TabIndex = 14
        Me._Label1_4.Text = "Volume specifico (m3/kg)"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(2, Me._Label2_2)
        Me._Label2_2.Location = New System.Drawing.Point(180, 54)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(73, 19)
        Me._Label2_2.TabIndex = 13
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(3, Me._Label1_3)
        Me._Label1_3.Location = New System.Drawing.Point(9, 36)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(154, 19)
        Me._Label1_3.TabIndex = 12
        Me._Label1_3.Text = "Calore specifico (J/kg°C)"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(1, Me._Label2_1)
        Me._Label2_1.Location = New System.Drawing.Point(180, 36)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(73, 19)
        Me._Label2_1.TabIndex = 11
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(2, Me._Label1_2)
        Me._Label1_2.Location = New System.Drawing.Point(9, 18)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(154, 19)
        Me._Label1_2.TabIndex = 10
        Me._Label1_2.Text = "Entalpia (kJ/kg)"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Add(0, Me._Label2_0)
        Me._Label2_0.Location = New System.Drawing.Point(180, 18)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(73, 19)
        Me._Label2_0.TabIndex = 9
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(384, 8)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(145, 19)
        Me.Check1.TabIndex = 6
        Me.Check1.Text = "Vapore saturo"
        Me.Check1.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._Option2_1)
        Me.Frame1.Controls.Add(Me._Option2_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(376, 32)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(181, 64)
        Me.Frame1.TabIndex = 4
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Variabile indipendente"
        Me.Frame1.Visible = False
        '
        '_Option2_1
        '
        Me._Option2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Add(1, Me._Option2_1)
        Me._Option2_1.Location = New System.Drawing.Point(9, 36)
        Me._Option2_1.Name = "_Option2_1"
        Me._Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_1.Size = New System.Drawing.Size(163, 19)
        Me._Option2_1.TabIndex = 7
        Me._Option2_1.TabStop = True
        Me._Option2_1.Text = "Pressione di saturazione"
        Me._Option2_1.UseVisualStyleBackColor = False
        '
        '_Option2_0
        '
        Me._Option2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option2_0.Checked = True
        Me._Option2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Add(0, Me._Option2_0)
        Me._Option2_0.Location = New System.Drawing.Point(9, 18)
        Me._Option2_0.Name = "_Option2_0"
        Me._Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_0.Size = New System.Drawing.Size(163, 19)
        Me._Option2_0.TabIndex = 5
        Me._Option2_0.TabStop = True
        Me._Option2_0.Text = "Temperatura di saturazione"
        Me._Option2_0.UseVisualStyleBackColor = False
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(1, Me._Text1_1)
        Me._Text1_1.Location = New System.Drawing.Point(188, 90)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(73, 20)
        Me._Text1_1.TabIndex = 3
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(0, Me._Text1_0)
        Me._Text1_0.Location = New System.Drawing.Point(188, 72)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(73, 20)
        Me._Text1_0.TabIndex = 1
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(1, Me._Label1_1)
        Me._Label1_1.Location = New System.Drawing.Point(8, 90)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(172, 19)
        Me._Label1_1.TabIndex = 2
        Me._Label1_1.Text = "Pressione (bar a)"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(0, Me._Label1_0)
        Me._Label1_0.Location = New System.Drawing.Point(8, 72)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(172, 19)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "Temperatura (°C)"
        '
        'Option2
        '
        '
        'Text1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 64)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Libreria"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(122, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "WasserDampfTafeln"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(84, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "IAWPS IF97"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'frmApert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(565, 297)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCalc)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Frame2_1)
        Me.Controls.Add(Me._Frame2_0)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmApert"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Proprietà del sistema acqua-vapore"
        Me._Frame2_1.ResumeLayout(False)
        Me._Frame2_0.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)



        For Each control In Option2.Values
            AddHandler control.CheckedChanged, AddressOf Option2_CheckedChanged
        Next
        For Each control In Text1.Values
            AddHandler control.TextChanged, AddressOf Text1_TextChanged
        Next
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
#End Region 
End Class