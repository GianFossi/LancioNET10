Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports RoutBase1
Imports RoutBase1.clsInizio
Imports VB = Microsoft.VisualBasic
Friend Class frmMater
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
        Scambia()
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
    Public WithEvents cmdLE As System.Windows.Forms.Button
	Public WithEvents cmdStampaListino As System.Windows.Forms.Button
	Public WithEvents cmdAbilita As System.Windows.Forms.Button
	Public WithEvents Command7 As System.Windows.Forms.Button
	Public WithEvents Check3D2 As System.Windows.Forms.CheckBox
	Public WithEvents Check3D1 As System.Windows.Forms.CheckBox
	Public WithEvents _Option3D2_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D2_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D2_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame3D2 As System.Windows.Forms.GroupBox
	Public WithEvents _Option3D3_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D3_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D3_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame3D3 As System.Windows.Forms.GroupBox
	Public WithEvents Command5 As System.Windows.Forms.Button
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents _Option3D1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_3 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_4 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_5 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_6 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_7 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_8 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_9 As System.Windows.Forms.RadioButton
	Public WithEvents _Option3D1_0 As System.Windows.Forms.RadioButton
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame3D1 As System.Windows.Forms.GroupBox
	Public WithEvents Command8 As System.Windows.Forms.Button
	Public WithEvents Command6 As System.Windows.Forms.Button
	Public WithEvents _cmdEdit_4 As System.Windows.Forms.Button
	Public WithEvents _cmdEdit_3 As System.Windows.Forms.Button
	Public WithEvents _cmdEdit_2 As System.Windows.Forms.Button
	Public WithEvents _cmdEdit_1 As System.Windows.Forms.Button
	Public WithEvents _cmdEdit_0 As System.Windows.Forms.Button
	Public WithEvents _ListInd_2 As System.Windows.Forms.ListBox
	Public WithEvents _ListInd_1 As System.Windows.Forms.ListBox
	Public WithEvents _ListInd_0 As System.Windows.Forms.ListBox
	Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents frmLE As System.Windows.Forms.GroupBox
    Public WithEvents _optLE_2 As System.Windows.Forms.RadioButton
    Public WithEvents _optLE_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optLE_0 As System.Windows.Forms.RadioButton
    Friend WithEvents _List1_0 As System.Windows.Forms.ListView
    Friend WithEvents _List1_1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Gridprezzi As System.Windows.Forms.DataGrid
    Friend WithEvents cmdStampa1Listino As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame3D1 = New System.Windows.Forms.GroupBox
        Me.cmdStampa1Listino = New System.Windows.Forms.Button
        Me.frmLE = New System.Windows.Forms.GroupBox
        Me._optLE_0 = New System.Windows.Forms.RadioButton
        Me._optLE_2 = New System.Windows.Forms.RadioButton
        Me._optLE_1 = New System.Windows.Forms.RadioButton
        Me.cmdLE = New System.Windows.Forms.Button
        Me.cmdStampaListino = New System.Windows.Forms.Button
        Me.cmdAbilita = New System.Windows.Forms.Button
        Me.Command7 = New System.Windows.Forms.Button
        Me.Frame3D2 = New System.Windows.Forms.GroupBox
        Me.Check3D2 = New System.Windows.Forms.CheckBox
        Me.Check3D1 = New System.Windows.Forms.CheckBox
        Me._Option3D2_2 = New System.Windows.Forms.RadioButton
        Me._Option3D2_1 = New System.Windows.Forms.RadioButton
        Me._Option3D2_0 = New System.Windows.Forms.RadioButton
        Me.Frame3D3 = New System.Windows.Forms.GroupBox
        Me._Option3D3_2 = New System.Windows.Forms.RadioButton
        Me._Option3D3_1 = New System.Windows.Forms.RadioButton
        Me._Option3D3_0 = New System.Windows.Forms.RadioButton
        Me.Command5 = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me._Option3D1_1 = New System.Windows.Forms.RadioButton
        Me._Option3D1_2 = New System.Windows.Forms.RadioButton
        Me._Option3D1_3 = New System.Windows.Forms.RadioButton
        Me._Option3D1_4 = New System.Windows.Forms.RadioButton
        Me._Option3D1_5 = New System.Windows.Forms.RadioButton
        Me._Option3D1_6 = New System.Windows.Forms.RadioButton
        Me._Option3D1_7 = New System.Windows.Forms.RadioButton
        Me._Option3D1_8 = New System.Windows.Forms.RadioButton
        Me._Option3D1_9 = New System.Windows.Forms.RadioButton
        Me._Option3D1_0 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Command8 = New System.Windows.Forms.Button
        Me.Command6 = New System.Windows.Forms.Button
        Me._cmdEdit_4 = New System.Windows.Forms.Button
        Me._cmdEdit_3 = New System.Windows.Forms.Button
        Me._cmdEdit_2 = New System.Windows.Forms.Button
        Me._cmdEdit_1 = New System.Windows.Forms.Button
        Me._cmdEdit_0 = New System.Windows.Forms.Button
        Me._ListInd_2 = New System.Windows.Forms.ListBox
        Me._ListInd_1 = New System.Windows.Forms.ListBox
        Me._ListInd_0 = New System.Windows.Forms.ListBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me.Command4 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._List1_0 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me._List1_1 = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.Gridprezzi = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Frame3D1.SuspendLayout()
        Me.frmLE.SuspendLayout()
        Me.Frame3D2.SuspendLayout()
        Me.Frame3D3.SuspendLayout()
        CType(Me.Gridprezzi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Controls.Add(Me.cmdStampa1Listino)
        Me.Frame3D1.Controls.Add(Me.frmLE)
        Me.Frame3D1.Controls.Add(Me.cmdLE)
        Me.Frame3D1.Controls.Add(Me.cmdStampaListino)
        Me.Frame3D1.Controls.Add(Me.cmdAbilita)
        Me.Frame3D1.Controls.Add(Me.Command7)
        Me.Frame3D1.Controls.Add(Me.Frame3D2)
        Me.Frame3D1.Controls.Add(Me.Frame3D3)
        Me.Frame3D1.Controls.Add(Me.Command5)
        Me.Frame3D1.Controls.Add(Me.Command3)
        Me.Frame3D1.Controls.Add(Me._Option3D1_1)
        Me.Frame3D1.Controls.Add(Me._Option3D1_2)
        Me.Frame3D1.Controls.Add(Me._Option3D1_3)
        Me.Frame3D1.Controls.Add(Me._Option3D1_4)
        Me.Frame3D1.Controls.Add(Me._Option3D1_5)
        Me.Frame3D1.Controls.Add(Me._Option3D1_6)
        Me.Frame3D1.Controls.Add(Me._Option3D1_7)
        Me.Frame3D1.Controls.Add(Me._Option3D1_8)
        Me.Frame3D1.Controls.Add(Me._Option3D1_9)
        Me.Frame3D1.Controls.Add(Me._Option3D1_0)
        Me.Frame3D1.Controls.Add(Me.Label1)
        Me.Frame3D1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3D1.Location = New System.Drawing.Point(0, 184)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D1.Size = New System.Drawing.Size(615, 321)
        Me.Frame3D1.TabIndex = 3
        Me.Frame3D1.TabStop = False
        Me.Frame3D1.Text = "Classi materiali"
        '
        'cmdStampa1Listino
        '
        Me.cmdStampa1Listino.Location = New System.Drawing.Point(448, 104)
        Me.cmdStampa1Listino.Name = "cmdStampa1Listino"
        Me.cmdStampa1Listino.Size = New System.Drawing.Size(96, 40)
        Me.cmdStampa1Listino.TabIndex = 53
        Me.cmdStampa1Listino.Text = "Stampa     listno"
        Me.cmdStampa1Listino.Visible = False
        '
        'frmLE
        '
        Me.frmLE.Controls.Add(Me._optLE_0)
        Me.frmLE.Controls.Add(Me._optLE_2)
        Me.frmLE.Controls.Add(Me._optLE_1)
        Me.frmLE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmLE.Location = New System.Drawing.Point(128, 16)
        Me.frmLE.Name = "frmLE"
        Me.frmLE.Size = New System.Drawing.Size(200, 232)
        Me.frmLE.TabIndex = 52
        Me.frmLE.TabStop = False
        Me.frmLE.Text = "Lavorazioni esterne"
        Me.frmLE.Visible = False
        '
        '_optLE_0
        '
        Me._optLE_0.BackColor = System.Drawing.SystemColors.Control
        Me._optLE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optLE_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optLE_0.Location = New System.Drawing.Point(8, 24)
        Me._optLE_0.Name = "_optLE_0"
        Me._optLE_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optLE_0.Size = New System.Drawing.Size(160, 25)
        Me._optLE_0.TabIndex = 52
        Me._optLE_0.TabStop = True
        Me._optLE_0.Text = "Formatura fondi ellittici"
        Me._optLE_0.UseVisualStyleBackColor = False
        '
        '_optLE_2
        '
        Me._optLE_2.BackColor = System.Drawing.SystemColors.Control
        Me._optLE_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optLE_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optLE_2.Location = New System.Drawing.Point(8, 72)
        Me._optLE_2.Name = "_optLE_2"
        Me._optLE_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optLE_2.Size = New System.Drawing.Size(160, 25)
        Me._optLE_2.TabIndex = 54
        Me._optLE_2.TabStop = True
        Me._optLE_2.Text = "Calandratura"
        Me._optLE_2.UseVisualStyleBackColor = False
        '
        '_optLE_1
        '
        Me._optLE_1.BackColor = System.Drawing.SystemColors.Control
        Me._optLE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optLE_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optLE_1.Location = New System.Drawing.Point(8, 48)
        Me._optLE_1.Name = "_optLE_1"
        Me._optLE_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optLE_1.Size = New System.Drawing.Size(180, 25)
        Me._optLE_1.TabIndex = 53
        Me._optLE_1.TabStop = True
        Me._optLE_1.Text = "Formatura fondi emisferici"
        Me._optLE_1.UseVisualStyleBackColor = False
        '
        'cmdLE
        '
        Me.cmdLE.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLE.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLE.Location = New System.Drawing.Point(448, 72)
        Me.cmdLE.Name = "cmdLE"
        Me.cmdLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLE.Size = New System.Drawing.Size(97, 25)
        Me.cmdLE.TabIndex = 44
        Me.cmdLE.Text = "Lav. esterne"
        Me.cmdLE.UseVisualStyleBackColor = False
        '
        'cmdStampaListino
        '
        Me.cmdStampaListino.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStampaListino.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStampaListino.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStampaListino.Location = New System.Drawing.Point(448, 24)
        Me.cmdStampaListino.Name = "cmdStampaListino"
        Me.cmdStampaListino.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStampaListino.Size = New System.Drawing.Size(97, 40)
        Me.cmdStampaListino.TabIndex = 43
        Me.cmdStampaListino.Text = "Visualizza listino"
        Me.cmdStampaListino.UseVisualStyleBackColor = False
        '
        'cmdAbilita
        '
        Me.cmdAbilita.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAbilita.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAbilita.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAbilita.Location = New System.Drawing.Point(32, 272)
        Me.cmdAbilita.Name = "cmdAbilita"
        Me.cmdAbilita.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAbilita.Size = New System.Drawing.Size(159, 21)
        Me.cmdAbilita.TabIndex = 40
        Me.cmdAbilita.Text = "Abilita tutto"
        Me.cmdAbilita.UseVisualStyleBackColor = False
        Me.cmdAbilita.Visible = False
        '
        'Command7
        '
        Me.Command7.BackColor = System.Drawing.SystemColors.Control
        Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command7.Location = New System.Drawing.Point(448, 290)
        Me.Command7.Name = "Command7"
        Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command7.Size = New System.Drawing.Size(71, 21)
        Me.Command7.TabIndex = 38
        Me.Command7.Text = "&Help"
        Me.Command7.UseVisualStyleBackColor = False
        '
        'Frame3D2
        '
        Me.Frame3D2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D2.Controls.Add(Me.Check3D2)
        Me.Frame3D2.Controls.Add(Me.Check3D1)
        Me.Frame3D2.Controls.Add(Me._Option3D2_2)
        Me.Frame3D2.Controls.Add(Me._Option3D2_1)
        Me.Frame3D2.Controls.Add(Me._Option3D2_0)
        Me.Frame3D2.ForeColor = System.Drawing.Color.Black
        Me.Frame3D2.Location = New System.Drawing.Point(240, 20)
        Me.Frame3D2.Name = "Frame3D2"
        Me.Frame3D2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D2.Size = New System.Drawing.Size(141, 132)
        Me.Frame3D2.TabIndex = 16
        Me.Frame3D2.TabStop = False
        Me.Frame3D2.Text = "Tipo rivestimento"
        '
        'Check3D2
        '
        Me.Check3D2.BackColor = System.Drawing.SystemColors.Control
        Me.Check3D2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check3D2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check3D2.Location = New System.Drawing.Point(40, 96)
        Me.Check3D2.Name = "Check3D2"
        Me.Check3D2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check3D2.Size = New System.Drawing.Size(97, 33)
        Me.Check3D2.TabIndex = 42
        Me.Check3D2.Text = "Sui due lati"
        Me.Check3D2.UseVisualStyleBackColor = False
        '
        'Check3D1
        '
        Me.Check3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Check3D1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check3D1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check3D1.Location = New System.Drawing.Point(8, 16)
        Me.Check3D1.Name = "Check3D1"
        Me.Check3D1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check3D1.Size = New System.Drawing.Size(121, 25)
        Me.Check3D1.TabIndex = 41
        Me.Check3D1.Text = "Nessuno"
        Me.Check3D1.UseVisualStyleBackColor = False
        '
        '_Option3D2_2
        '
        Me._Option3D2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D2_2.Location = New System.Drawing.Point(10, 80)
        Me._Option3D2_2.Name = "_Option3D2_2"
        Me._Option3D2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D2_2.Size = New System.Drawing.Size(121, 21)
        Me._Option3D2_2.TabIndex = 19
        Me._Option3D2_2.TabStop = True
        Me._Option3D2_2.Text = "Lining"
        Me._Option3D2_2.UseVisualStyleBackColor = False
        '
        '_Option3D2_1
        '
        Me._Option3D2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D2_1.Location = New System.Drawing.Point(10, 60)
        Me._Option3D2_1.Name = "_Option3D2_1"
        Me._Option3D2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D2_1.Size = New System.Drawing.Size(111, 21)
        Me._Option3D2_1.TabIndex = 18
        Me._Option3D2_1.TabStop = True
        Me._Option3D2_1.Text = "Rivestito"
        Me._Option3D2_1.UseVisualStyleBackColor = False
        '
        '_Option3D2_0
        '
        Me._Option3D2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D2_0.Location = New System.Drawing.Point(10, 40)
        Me._Option3D2_0.Name = "_Option3D2_0"
        Me._Option3D2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D2_0.Size = New System.Drawing.Size(121, 21)
        Me._Option3D2_0.TabIndex = 17
        Me._Option3D2_0.TabStop = True
        Me._Option3D2_0.Text = "Placcato"
        Me._Option3D2_0.UseVisualStyleBackColor = False
        '
        'Frame3D3
        '
        Me.Frame3D3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D3.Controls.Add(Me._Option3D3_2)
        Me.Frame3D3.Controls.Add(Me._Option3D3_1)
        Me.Frame3D3.Controls.Add(Me._Option3D3_0)
        Me.Frame3D3.ForeColor = System.Drawing.Color.Black
        Me.Frame3D3.Location = New System.Drawing.Point(231, 160)
        Me.Frame3D3.Name = "Frame3D3"
        Me.Frame3D3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3D3.Size = New System.Drawing.Size(152, 101)
        Me.Frame3D3.TabIndex = 21
        Me.Frame3D3.TabStop = False
        Me.Frame3D3.Text = "Materiale rivestimento"
        '
        '_Option3D3_2
        '
        Me._Option3D3_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D3_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D3_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D3_2.Location = New System.Drawing.Point(10, 60)
        Me._Option3D3_2.Name = "_Option3D3_2"
        Me._Option3D3_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D3_2.Size = New System.Drawing.Size(131, 21)
        Me._Option3D3_2.TabIndex = 24
        Me._Option3D3_2.TabStop = True
        Me._Option3D3_2.Text = "Varie"
        Me._Option3D3_2.UseVisualStyleBackColor = False
        '
        '_Option3D3_1
        '
        Me._Option3D3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D3_1.Location = New System.Drawing.Point(10, 40)
        Me._Option3D3_1.Name = "_Option3D3_1"
        Me._Option3D3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D3_1.Size = New System.Drawing.Size(139, 21)
        Me._Option3D3_1.TabIndex = 23
        Me._Option3D3_1.TabStop = True
        Me._Option3D3_1.Text = "Riporti e placcature"
        Me._Option3D3_1.UseVisualStyleBackColor = False
        '
        '_Option3D3_0
        '
        Me._Option3D3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D3_0.Location = New System.Drawing.Point(10, 20)
        Me._Option3D3_0.Name = "_Option3D3_0"
        Me._Option3D3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D3_0.Size = New System.Drawing.Size(139, 21)
        Me._Option3D3_0.TabIndex = 22
        Me._Option3D3_0.TabStop = True
        Me._Option3D3_0.Text = "Lam. inox e speciali"
        Me._Option3D3_0.UseVisualStyleBackColor = False
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(286, 290)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(71, 21)
        Me.Command5.TabIndex = 20
        Me.Command5.Text = "&Annulla"
        Me.Command5.UseVisualStyleBackColor = False
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(366, 290)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(71, 21)
        Me.Command3.TabIndex = 14
        Me.Command3.Text = "&OK"
        Me.Command3.UseVisualStyleBackColor = False
        '
        '_Option3D1_1
        '
        Me._Option3D1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_1.Location = New System.Drawing.Point(30, 70)
        Me._Option3D1_1.Name = "_Option3D1_1"
        Me._Option3D1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_1.Size = New System.Drawing.Size(181, 21)
        Me._Option3D1_1.TabIndex = 12
        Me._Option3D1_1.TabStop = True
        Me._Option3D1_1.Text = "Lamiere inox e speciali"
        Me._Option3D1_1.UseVisualStyleBackColor = False
        '
        '_Option3D1_2
        '
        Me._Option3D1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_2.Location = New System.Drawing.Point(30, 90)
        Me._Option3D1_2.Name = "_Option3D1_2"
        Me._Option3D1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_2.Size = New System.Drawing.Size(171, 21)
        Me._Option3D1_2.TabIndex = 11
        Me._Option3D1_2.TabStop = True
        Me._Option3D1_2.Text = "Tondi laminati"
        Me._Option3D1_2.UseVisualStyleBackColor = False
        '
        '_Option3D1_3
        '
        Me._Option3D1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_3.Location = New System.Drawing.Point(30, 110)
        Me._Option3D1_3.Name = "_Option3D1_3"
        Me._Option3D1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_3.Size = New System.Drawing.Size(131, 21)
        Me._Option3D1_3.TabIndex = 10
        Me._Option3D1_3.TabStop = True
        Me._Option3D1_3.Text = "Tubi scambiatori"
        Me._Option3D1_3.UseVisualStyleBackColor = False
        '
        '_Option3D1_4
        '
        Me._Option3D1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_4.Location = New System.Drawing.Point(30, 130)
        Me._Option3D1_4.Name = "_Option3D1_4"
        Me._Option3D1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_4.Size = New System.Drawing.Size(131, 21)
        Me._Option3D1_4.TabIndex = 9
        Me._Option3D1_4.TabStop = True
        Me._Option3D1_4.Text = "Distanziatori"
        Me._Option3D1_4.UseVisualStyleBackColor = False
        '
        '_Option3D1_5
        '
        Me._Option3D1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_5.Location = New System.Drawing.Point(30, 150)
        Me._Option3D1_5.Name = "_Option3D1_5"
        Me._Option3D1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_5.Size = New System.Drawing.Size(121, 21)
        Me._Option3D1_5.TabIndex = 8
        Me._Option3D1_5.TabStop = True
        Me._Option3D1_5.Text = "Tubi (pipes)"
        Me._Option3D1_5.UseVisualStyleBackColor = False
        '
        '_Option3D1_6
        '
        Me._Option3D1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_6.Location = New System.Drawing.Point(30, 170)
        Me._Option3D1_6.Name = "_Option3D1_6"
        Me._Option3D1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_6.Size = New System.Drawing.Size(141, 21)
        Me._Option3D1_6.TabIndex = 7
        Me._Option3D1_6.TabStop = True
        Me._Option3D1_6.Text = "Fucinati"
        Me._Option3D1_6.UseVisualStyleBackColor = False
        '
        '_Option3D1_7
        '
        Me._Option3D1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_7.Location = New System.Drawing.Point(30, 190)
        Me._Option3D1_7.Name = "_Option3D1_7"
        Me._Option3D1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_7.Size = New System.Drawing.Size(131, 21)
        Me._Option3D1_7.TabIndex = 6
        Me._Option3D1_7.TabStop = True
        Me._Option3D1_7.Text = "Tiranti e bulloni"
        Me._Option3D1_7.UseVisualStyleBackColor = False
        '
        '_Option3D1_8
        '
        Me._Option3D1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_8.Location = New System.Drawing.Point(30, 210)
        Me._Option3D1_8.Name = "_Option3D1_8"
        Me._Option3D1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_8.Size = New System.Drawing.Size(141, 21)
        Me._Option3D1_8.TabIndex = 5
        Me._Option3D1_8.TabStop = True
        Me._Option3D1_8.Text = "Riporti e placcature"
        Me._Option3D1_8.UseVisualStyleBackColor = False
        '
        '_Option3D1_9
        '
        Me._Option3D1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_9.Location = New System.Drawing.Point(30, 230)
        Me._Option3D1_9.Name = "_Option3D1_9"
        Me._Option3D1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_9.Size = New System.Drawing.Size(121, 21)
        Me._Option3D1_9.TabIndex = 4
        Me._Option3D1_9.TabStop = True
        Me._Option3D1_9.Text = "Varie"
        Me._Option3D1_9.UseVisualStyleBackColor = False
        '
        '_Option3D1_0
        '
        Me._Option3D1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option3D1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option3D1_0.Enabled = False
        Me._Option3D1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option3D1_0.Location = New System.Drawing.Point(30, 50)
        Me._Option3D1_0.Name = "_Option3D1_0"
        Me._Option3D1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option3D1_0.Size = New System.Drawing.Size(186, 21)
        Me._Option3D1_0.TabIndex = 13
        Me._Option3D1_0.TabStop = True
        Me._Option3D1_0.Text = "Lamiere in acciaio al carbonio"
        Me._Option3D1_0.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(51, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Materiale base"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Command8
        '
        Me.Command8.BackColor = System.Drawing.SystemColors.Control
        Me.Command8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command8.Location = New System.Drawing.Point(552, 88)
        Me.Command8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Command8.Name = "Command8"
        Me.Command8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command8.Size = New System.Drawing.Size(60, 21)
        Me.Command8.TabIndex = 39
        Me.Command8.Text = "&Nessuno"
        Me.Command8.UseVisualStyleBackColor = False
        '
        'Command6
        '
        Me.Command6.BackColor = System.Drawing.SystemColors.Control
        Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command6.Location = New System.Drawing.Point(550, 293)
        Me.Command6.Name = "Command6"
        Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command6.Size = New System.Drawing.Size(60, 21)
        Me.Command6.TabIndex = 37
        Me.Command6.Text = "&Help"
        Me.Command6.UseVisualStyleBackColor = False
        '
        '_cmdEdit_4
        '
        Me._cmdEdit_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdEdit_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdEdit_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdEdit_4.Location = New System.Drawing.Point(552, 64)
        Me._cmdEdit_4.Name = "_cmdEdit_4"
        Me._cmdEdit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdEdit_4.Size = New System.Drawing.Size(61, 21)
        Me._cmdEdit_4.TabIndex = 36
        Me._cmdEdit_4.Text = "Vista"
        Me._cmdEdit_4.UseVisualStyleBackColor = False
        '
        '_cmdEdit_3
        '
        Me._cmdEdit_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdEdit_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdEdit_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdEdit_3.Location = New System.Drawing.Point(552, 40)
        Me._cmdEdit_3.Name = "_cmdEdit_3"
        Me._cmdEdit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdEdit_3.Size = New System.Drawing.Size(61, 21)
        Me._cmdEdit_3.TabIndex = 33
        Me._cmdEdit_3.Text = "Esamina"
        Me._cmdEdit_3.UseVisualStyleBackColor = False
        '
        '_cmdEdit_2
        '
        Me._cmdEdit_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdEdit_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdEdit_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdEdit_2.Location = New System.Drawing.Point(552, 184)
        Me._cmdEdit_2.Name = "_cmdEdit_2"
        Me._cmdEdit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdEdit_2.Size = New System.Drawing.Size(61, 21)
        Me._cmdEdit_2.TabIndex = 32
        Me._cmdEdit_2.Text = "Elimina"
        Me._cmdEdit_2.UseVisualStyleBackColor = False
        '
        '_cmdEdit_1
        '
        Me._cmdEdit_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdEdit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdEdit_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdEdit_1.Location = New System.Drawing.Point(550, 20)
        Me._cmdEdit_1.Name = "_cmdEdit_1"
        Me._cmdEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdEdit_1.Size = New System.Drawing.Size(61, 21)
        Me._cmdEdit_1.TabIndex = 31
        Me._cmdEdit_1.Text = "Ins.dopo"
        Me._cmdEdit_1.UseVisualStyleBackColor = False
        '
        '_cmdEdit_0
        '
        Me._cmdEdit_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdEdit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdEdit_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdEdit_0.Location = New System.Drawing.Point(550, 0)
        Me._cmdEdit_0.Name = "_cmdEdit_0"
        Me._cmdEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdEdit_0.Size = New System.Drawing.Size(61, 21)
        Me._cmdEdit_0.TabIndex = 30
        Me._cmdEdit_0.Text = "Modifica"
        Me._cmdEdit_0.UseVisualStyleBackColor = False
        '
        '_ListInd_2
        '
        Me._ListInd_2.BackColor = System.Drawing.SystemColors.Window
        Me._ListInd_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._ListInd_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ListInd_2.ItemHeight = 14
        Me._ListInd_2.Location = New System.Drawing.Point(400, 190)
        Me._ListInd_2.Name = "_ListInd_2"
        Me._ListInd_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ListInd_2.Size = New System.Drawing.Size(41, 18)
        Me._ListInd_2.TabIndex = 29
        Me._ListInd_2.Visible = False
        '
        '_ListInd_1
        '
        Me._ListInd_1.BackColor = System.Drawing.SystemColors.Window
        Me._ListInd_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ListInd_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ListInd_1.ItemHeight = 14
        Me._ListInd_1.Location = New System.Drawing.Point(400, 110)
        Me._ListInd_1.Name = "_ListInd_1"
        Me._ListInd_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ListInd_1.Size = New System.Drawing.Size(41, 18)
        Me._ListInd_1.TabIndex = 28
        Me._ListInd_1.Visible = False
        '
        '_ListInd_0
        '
        Me._ListInd_0.BackColor = System.Drawing.SystemColors.Window
        Me._ListInd_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ListInd_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ListInd_0.ItemHeight = 14
        Me._ListInd_0.Location = New System.Drawing.Point(400, 40)
        Me._ListInd_0.Name = "_ListInd_0"
        Me._ListInd_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ListInd_0.Size = New System.Drawing.Size(41, 18)
        Me._ListInd_0.TabIndex = 27
        Me._ListInd_0.Visible = False
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._Text1_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(0, 0)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Multiline = True
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(547, 21)
        Me._Text1_4.TabIndex = 1
        Me._Text1_4.TabStop = False
        Me._Text1_4.Text = "Sigla"
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(552, 112)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(60, 21)
        Me.Command4.TabIndex = 15
        Me.Command4.Text = "&Classe"
        Me.Command4.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(550, 251)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(60, 21)
        Me.Command2.TabIndex = 2
        Me.Command2.Text = "&Annulla"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(550, 272)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(60, 21)
        Me.Command1.TabIndex = 0
        Me.Command1.Text = "&OK"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._Text1_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(0, 176)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Multiline = True
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(547, 21)
        Me._Text1_5.TabIndex = 25
        Me._Text1_5.TabStop = False
        Me._Text1_5.Text = "Materiale rivestimento"
        '
        '_List1_0
        '
        Me._List1_0.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me._List1_0.FullRowSelect = True
        Me._List1_0.HideSelection = False
        Me._List1_0.Location = New System.Drawing.Point(0, 24)
        Me._List1_0.MultiSelect = False
        Me._List1_0.Name = "_List1_0"
        Me._List1_0.Size = New System.Drawing.Size(552, 152)
        Me._List1_0.TabIndex = 40
        Me._List1_0.UseCompatibleStateImageBehavior = False
        Me._List1_0.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Sigla"
        Me.ColumnHeader1.Width = 257
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "CAT"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "CT"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "CMT"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Nome Comm."
        '
        '_List1_1
        '
        Me._List1_1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me._List1_1.FullRowSelect = True
        Me._List1_1.HideSelection = False
        Me._List1_1.Location = New System.Drawing.Point(0, 200)
        Me._List1_1.MultiSelect = False
        Me._List1_1.Name = "_List1_1"
        Me._List1_1.Size = New System.Drawing.Size(552, 112)
        Me._List1_1.TabIndex = 41
        Me._List1_1.UseCompatibleStateImageBehavior = False
        Me._List1_1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Sigla"
        Me.ColumnHeader6.Width = 257
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "CAT"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "CT"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "CMT"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Nome Coom."
        '
        'Gridprezzi
        '
        Me.Gridprezzi.CaptionVisible = False
        Me.Gridprezzi.DataMember = ""
        Me.Gridprezzi.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Gridprezzi.Location = New System.Drawing.Point(0, 648)
        Me.Gridprezzi.Name = "Gridprezzi"
        Me.Gridprezzi.Size = New System.Drawing.Size(592, 96)
        Me.Gridprezzi.TabIndex = 42
        Me.Gridprezzi.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.Gridprezzi
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "tabPrezzi"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Materiale"
        Me.DataGridTextBoxColumn1.MappingName = "Mat"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 200
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn2.Format = "####.00"
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Costo (€/kg)"
        Me.DataGridTextBoxColumn2.MappingName = "PrezzoLkg"
        Me.DataGridTextBoxColumn2.Width = 80
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Descrizione dell'offerta"
        Me.DataGridTextBoxColumn3.MappingName = "NoteMie"
        Me.DataGridTextBoxColumn3.Width = 950
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Firma"
        Me.DataGridTextBoxColumn4.MappingName = "Firmato"
        Me.DataGridTextBoxColumn4.Width = 50
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = "dd-MMM-yy"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Data"
        Me.DataGridTextBoxColumn5.MappingName = "DataRev"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Fornitore"
        Me.DataGridTextBoxColumn6.MappingName = "Fornitore"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'frmMater
        '
        Me.AcceptButton = Me.Command6
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(690, 762)
        Me.ControlBox = False
        Me.Controls.Add(Me.Gridprezzi)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me._ListInd_2)
        Me.Controls.Add(Me._ListInd_1)
        Me.Controls.Add(Me._ListInd_0)
        Me.Controls.Add(Me.Command8)
        Me.Controls.Add(Me.Command6)
        Me.Controls.Add(Me._cmdEdit_4)
        Me.Controls.Add(Me._cmdEdit_3)
        Me.Controls.Add(Me._cmdEdit_2)
        Me.Controls.Add(Me._cmdEdit_1)
        Me.Controls.Add(Me._cmdEdit_0)
        Me.Controls.Add(Me._Text1_4)
        Me.Controls.Add(Me._Text1_5)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._List1_0)
        Me.Controls.Add(Me._List1_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(75, 44)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMater"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Scelta materiale"
        Me.Frame3D1.ResumeLayout(False)
        Me.frmLE.ResumeLayout(False)
        Me.Frame3D2.ResumeLayout(False)
        Me.Frame3D3.ResumeLayout(False)
        CType(Me.Gridprezzi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmMater
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMater
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMater()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public Mat As clsMat
    Private Tipo As TipoRivestimento
    Private Inizializzando, consult As Boolean
	Private Rappresent As Short
	Private Vecchio As Short
    Private GiaAttiva As Boolean
    Private InitialDesktopBounds As Rectangle
    Private Sub Check3D1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check3D1.CheckStateChanged
        Dim i As Short
        For i = 0 To 2 : Option3D2(i).Enabled = Not Check3D1.CheckState = 1 : Next
        For i = 0 To 2 : Option3D2(i).Visible = Not Check3D1.CheckState = 1 : Next
        Check3D2.Enabled = Not Check3D1.CheckState = 1
        Check3D2.Visible = Not Check3D1.CheckState = 1
        Frame3D3.Visible = Not Check3D1.CheckState = 1
        _List1_1.Visible = Check3D1.CheckState = 1
        If Check3D1.CheckState = 1 Then
            Tipo = 0
            If Mat.Compos <> 0 Then
                Mat.MatCompos.Mat(2).Indmat = 0
                Mat.MatCompos.Mat(3).Indmat = 0
            End If
        Else
            For i = 0 To 2
                If Option3D2(i).Checked Then
                    Tipo = CType(i + 3, TipoRivestimento)
                    Exit For
                End If
            Next
            If Tipo > 0 Then
                If Check3D2.CheckState = CheckState.Checked Then Tipo = CType(CShort(Tipo) + 3, TipoRivestimento)
            Else
                Option3D2(1).Checked = True
            End If
        End If
        Call RegTipo()
    End Sub
    Private Sub Check3D2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check3D2.CheckStateChanged
        If Inizializzando Then Exit Sub
        If Check3D2.CheckState = 1 And Tipo <= 3 Then Tipo = CType(CShort(Tipo) + 3, TipoRivestimento)
        If Not Check3D2.CheckState = 1 And Tipo > 3 Then Tipo = CType(CShort(Tipo) - 3, TipoRivestimento)
        Call RegTipo()
    End Sub

    Private Sub cmdAbilita_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAbilita.Click
        VediTutteClassi()
    End Sub

    Private Sub cmdEdit(ByVal Index As Short)
        Dim i As Short
        Dim Sigla As String = ""
        Dim Autorizz As Boolean
        Dim r As New DataTable
        Dim CBr As OleDbCommandBuilder
        Dim cmdr As OleDbDataAdapter
        Dim dvr As DataView
        Dim drvr As DataRowView
        Dim iFoundr As Integer
        Dim Ord As Single
        Dim IndiceLista, VList As Short
        Dim m As LibMat.MaterialeNew1
        Dim Mat As clsMat
        Cursor.Current = Cursors.WaitCursor
        Mat = FormMat.Item(FormMat.Count()).TextData
        IndiceLista = Mat.IndiceLista
        If Index = 4 Then
            Scambia()
            GenList(0)
            If _List1_1.Visible Then GenList(1)
            Exit Sub
        End If
        If IndiceLista = 0 Then IndiceLista = 1
        Select Case IndiceLista - 1
            Case 0
                If _List1_0.SelectedItems.Count = 0 Then
                    Funzioni.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
                VList = CShort(_List1_0.SelectedItems(0).Index)
            Case 1
                If _List1_1.SelectedItems.Count = 0 Then
                    Funzioni.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
                VList = CShort(_List1_1.SelectedItems(0).Index)
        End Select
        If Index < 3 Then
            If Monitor.Motore Is Nothing Then
                Autorizz = False
            Else
                Autorizz = RoutBase2.Motore2.Autorizzazione("MAT", Sigla, Monitor.Motore)
            End If
            If Not Autorizz Then
                _cmdEdit_0.Enabled = False
                _cmdEdit_1.Enabled = False
                _cmdEdit_2.Enabled = False
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
        End If
        Call RegMat(0)
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If Not CBool(Mat.Editato) And Index < 3 Then
            Mat.Editato = CShort(True)
        End If
        Try
            Select Case Index
                Case 0 'Modifica
                    consult = False
                    Scheda = New frmScheda
                    Scheda.consult = False
                    Cursor.Current = Cursors.Default
                    Scheda.ShowDialog()
                    GenList(CShort(IndiceLista - 1))
                    SelectIt(IndiceLista, VList)
                Case 3 ' consultazione
                    consult = True
                    Scheda = New frmScheda
                    Scheda.consult = True
                    Cursor.Current = Cursors.Default
                    Scheda.ShowDialog()
                    SelectIt(IndiceLista, VList)
                Case 1 'Inserisci
                    cmdr = New OleDbDataAdapter("SELECT Ind from ListaMat ORDER BY Ind", MatBase)
                    cmdr.Fill(r)
                    dvr = New DataView(r)
                    i = CShort(CInt(dvr(dvr.Count - 1)("Ind")) + 1)
                    r.Clear()
                    cmdr = New OleDbDataAdapter("SELECT * from ListaMat WHERE Classe=" & Str(m.Classe) & " ORDER BY Ordinamento", MatBase)
                    cmdr.Fill(r)
                    CBr = New OleDbCommandBuilder(cmdr)
                    dvr = New DataView(r)
                    dvr.Sort = "Ind"
                    iFoundr = dvr.Find(m.Indmat)
                    Ord = CSng(dvr(iFoundr)("Ordinamento"))
                    dvr.Sort = "Ordinamento"
                    iFoundr = dvr.Find(Ord)
                    If iFoundr = dvr.Count - 1 Then
                        Ord = Ord + 1
                    Else
                        Ord = (Ord + CSng(dvr(iFoundr + 1)("Ordinamento"))) / 2
                    End If
                    drvr = dvr.AddNew
                    drvr("Ind") = i
                    drvr("Mat") = "Nuovo materiale"
                    drvr("Classe") = m.Classe
                    drvr("Ordinamento") = Ord
                    m.Indmat = i
                    m.MatStr = CStr(drvr("Mat"))
                    drvr.EndEdit()
                    cmdr.Update(r)
                    PutMat(1)
                    r.Dispose()
                    cmdr.Dispose()
                    CBr.Dispose()
                    consult = False
                    Scheda = New frmScheda
                    Scheda.consult = False
                    Cursor.Current = Cursors.Default
                    Scheda.ShowDialog()
                    Call GenList(CShort(IndiceLista - 1))
                    VList = CShort(VList + 1)
                    SelectIt(IndiceLista, VList)
                Case 2 'Elimina
                    If MsgBox("Prego confermare eliminazione definitiva del materiale dalla banca dati", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Critical, MsgBoxStyle)) = MsgBoxResult.Yes Then
                        cmdr = New OleDbDataAdapter("SELECT * from ListaMat WHERE Classe=" & Str(m.Classe) & " ORDER BY Ordinamento", MatBase)
                        cmdr.Fill(r)
                        CBr = New OleDbCommandBuilder(cmdr) '19/09/07
                        dvr = r.DefaultView
                        dvr.Sort = "Ind"
                        iFoundr = dvr.Find(m.Indmat)
                        If iFoundr = -1 Then
                            MsgBox("Materiale " & Trim(m.MatStr) & ", indice=" & Str(m.Indmat) & " non trovato")
                            Exit Sub
                        End If
                        EliminaDB(dvr(iFoundr), m.Indmat, m.Classe)
                        cmdr.Update(r) '19/09/07
                        r.Clear()
                        r.Dispose()
                        cmdr.Dispose()
                        CBr.Dispose() '19/09/07
                        Call GenList(CShort(IndiceLista - 1))
                        SelectIt(IndiceLista, VList)
                        Cursor.Current = Cursors.Default
                    End If
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Not Scheda Is Nothing Then
            Scheda.Dispose()
            Scheda = Nothing
        End If
    End Sub
    Private Sub SelectIt(ByVal Indicelista As Short, ByVal VList As Short)
        '        Dim VlistV As Short
        '        On Error GoTo ErrSI
        Select Case Indicelista - 1
            Case 0
                _List1_0.Items(VList).EnsureVisible()
                _List1_0.Items(VList).Selected = True '    Seleziona(_List1_0, VList)
                _List1_0.Items(VList).Focused = True
                '               On Error GoTo 0
                '              VListV = CShort(VList + 5)
                '             If VListV > _List1_0.Items.Count - 1 Then VListV = CShort(_List1_0.Items.Count - 1)
                '            _List1_0.Items(VListV).EnsureVisible()
            Case 1
                _List1_1.Items(VList).EnsureVisible()
                _List1_1.Items(VList).Selected = True 'Seleziona(_List1_1, VList)
                _List1_1.Items(VList).Focused = True
                '           On Error GoTo 0
                '          VListV = CShort(VList + 5)
                '         If VListV > _List1_1.Items.Count - 1 Then VListV = CShort(_List1_1.Items.Count - 1)
                '        _List1_1.Items(VListV).EnsureVisible()
        End Select
        '        Exit Sub
        'ErrSI:  VList = CShort(VList - 1)
        '        If VList = 0 Then Stop
        '        Resume
    End Sub
    Private Sub cmdLE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLE.Click
        Dim Mat As clsMat
        Select Case cmdLE.Text.Substring(0, 1)
            Case "L"
                frmLE.Visible = True
                cmdLE.Text = "Materiali"
                Mat = FormMat.Item(FormMat.Count()).TextData
                Mat.MatCompos = Nothing
                Mat.MatSolo = New LibMat.MaterialeNew1
                _optLE_0.Checked = True
                Command3.Visible = False
            Case "M"
                frmLE.Visible = False
                cmdLE.Text = "Lav. esterne"
                Command3.Visible = True
        End Select
    End Sub
    Private Sub cmdStampaListino_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStampaListino.Click
        Dim Strin(6) As String
        Dim i As Short
        Dim Tit As String
        '    IDHS.IDH_INTERNO_LISTINO1 , "per parametro primario"
        '    IDHS.IDH_INTERNO_LISTINO2 , "per parametro secondario"
        '    IDHS.IDH_INTERNO_LISTINO3 , "per prezzo al chilo"
        '    IDHS.IDH_INTERNO_LISTINO4 , "per data"
        '    IDHS.IDH_INTERNO_LISTINO5 , "per fornitore"
        '    IDHS.IDH_INTERNO_LISTINO6 , "per progettista"
        '=====================================================
        Dim Classi As New DataTable
        Dim cmd As New OleDbDataAdapter("SELECT * FROM CLASSI", MatBase)
        cmd.Fill(Classi)
        '        For i = 0 To CShort(Classi.Rows.Count - 1)
        '        tabella = CStr(Classi.Rows(i)("tabClasPr"))
        '        ' CB = New OleDbCommandBuilder(cmd1)
        '        lprezzi = New DataTable
        '        If i = 3 Or i = 6 Or i = 10 Or i = 11 Or i = 12 Then
        '            cmd1 = New OleDbDataAdapter("SELECT ID,PrezzoLkg,PrezzoAlt,note FROM " & tabella, MatBase)
        '            Updatecmd = New OleDbCommand("UPDATE " & tabella & " SET PrezzoLkg = ?, PrezzoAlt = ?, [Note] = ? WHERE ID = ?", MatBase)
        '            Updatecmd.Parameters.Add("PrezzoLkg", OleDbType.Single, 0, "PrezzoLkg")
        '            Updatecmd.Parameters.Add("PreszzoAlt", OleDbType.Single, 0, "PrezzoAlt")
        '            Updatecmd.Parameters.Add("note", OleDbType.VarWChar, 0, "note")
        '            Updatecmd.Parameters.Add(New OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", DataRowVersion.Original, Nothing))
        '            cmd1.UpdateCommand = Updatecmd
        '        Else
        '            cmd1 = New OleDbDataAdapter("SELECT ID,PrezzoLkg,note FROM " & tabella, MatBase)
        '            Updatecmd = New OleDbCommand("UPDATE " & tabella & " SET  prezzoLkg=?,[Note] = ? WHERE ID = ?", MatBase)
        '            Updatecmd.Parameters.Add("PrezzoLkg", OleDbType.Single, 0, "PrezzoLkg")
        '            Updatecmd.Parameters.Add("note", OleDbType.VarWChar, 0, "note")
        '            Updatecmd.Parameters.Add(New OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", DataRowVersion.Original, Nothing))
        '            cmd1.UpdateCommand = Updatecmd
        '        End If
        '        cmd1.Fill(lprezzi)
        '        For j = 0 To lprezzi.Rows.Count - 1
        '        drv = lprezzi.DefaultView(j)
        '        drv.BeginEdit()
        '       Try
        '       If Not IsDBNull(drv("PrezzoAlt")) Then
        '        If CSng(drv("PrezzoAlt")) > 0 Then
        '        Select Case i
        '            Case 3, 6 : drv("PrezzoAlt") = CSng(drv("PrezzoAlt")) / 1936.0
        '            Case 10 To 12 : drv("PrezzoAlt") = CSng(drv("PrezzoAlt")) / 1936.0 * 1000000
        '        End Select
        '       End If
        '       End If
        '        Catch e As Exception
        '        End Try
        '        If Not IsDBNull(drv("PrezzoLkg")) Then
        '        If CSng(drv("PrezzoLkg")) > 0 Then
        '        drv("PrezzoLkg") = CSng(drv("PrezzoLkg")) / 1936.0
        '        End If
        '        End If

        '        If Not IsDBNull(drv("note")) Then
        '        testo = CStr(drv("note"))
        '        Do
        '        n = InStr(n + 1, testo, Chr(13))
        '        If n > 0 Then Mid(testo, n, 2) = "; "
        '        Loop Until n = 0
        '        drv("note") = testo
        '        End If
        '        drv.EndEdit()
        '        Next
        '        cmd1.Update(lprezzi)
        '        Next
        '======================================================
        For i = 1 To 6
            Strin(i) = Monitor.Motore.HelpStringaG(IDHS.IDH_INTERNO_LISTINO1 - 1 + i)
        Next
        Tit = Monitor.Motore.HelpStringaG(IDHS.IDH_INTERNO_TIT)
        i = Monitor.Motore.Quale(6, Tit, Strin, RadiceHelp, 1, , ChiaviMess.MessOKCancel + ChiaviMess.MessHelpButton, IDHS.IDH_LISTINO_HELP)
        If i < 1 Or i > 6 Then Exit Sub
        Me.DesktopBounds = Screen.PrimaryScreen.Bounds
        With Gridprezzi
            .Top = Frame3D1.Top + Frame3D1.Height
            .Left = 0
            .Width = Me.ClientRectangle.Width
            .Height = Me.ClientRectangle.Height - .Top
            PreparaListino()
            If Mat.Classe < 11 Then
                GenPrezzi(i, Mat.Classe)
            Else
                Genprezzi1(i)
            End If
            .SetDataBinding(dvprezzi, "")
            Dim delta As Integer = .Width - .GetCellBounds(0, 5).Left - .GetCellBounds(0, 5).Width
            .TableStyles(0).GridColumnStyles(2).Width += delta
        End With
        cmdStampa1Listino.Visible = True
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'OK della scelta del materiale
        Try
            Call RegMat(0)
            If Mat.Compos <> 0 Then
                If Tipo > 0 Then
                    Call RegMat(1)
                    Mat.MatCompos.Mat(1).Editato = CBool(Mat.Editato)
                Else
                    Mat.MatSolo = Mat.MatCompos.Mat(1)
                End If
            Else
                Mat.MatSolo.Editato = CBool(Mat.Editato)
            End If
            If Tipo = 0 Then
                Dim Table As DataTable
                Dim Valor As Single
                Dim RigaValori As DataRowView = Nothing
                Dim cmd As OleDbDataAdapter
                Dim myDataColumn As DataColumn
                Dim myDataRow, myDataRow1 As DataRow
                Dim i, j, n As Integer
                Dim m As MaterialeNew1 = Mat.MatSolo
                If m.Agganciato Then
                    If m.alfacod > 0 Then
                        cmd = New OleDbDataAdapter("SELECT * FROM AlfaTer", MatBase)
                        Table = New DataTable
                        cmd.Fill(Table)
                        Valor = PhysAlt(100, m.alfacod, Table, RigaValori, m)
                        If m.AlfaYoung Is Nothing Then m.AlfaYoung = New clsAlfaYoung
                        m.AlfaYoung.tblAlfa = New DataTable
                        j = 0
                        For i = 0 To CShort(Table.Columns.Count - 1)
                            If IsDBNull(Table.Rows(0)(i)) Then
                                If i = 1 Then j += 1
                            ElseIf CSng(Table.Rows(0)(i)) > 0 Then
                                j += 1
                            End If
                        Next
                        n = j
                        For i = 0 To CShort(n - 1)
                            myDataColumn = New DataColumn
                            myDataColumn.DataType = Table.Columns(i).DataType
                            m.AlfaYoung.tblAlfa.Columns.Add(myDataColumn)
                        Next
                        myDataRow = m.AlfaYoung.tblAlfa.NewRow()
                        myDataRow1 = m.AlfaYoung.tblAlfa.NewRow()
                        j = 0
                        For i = 0 To CShort(Table.Columns.Count - 1)
                            If IsDBNull(Table.Rows(0)(i)) Then
                                If i = 1 Then myDataRow1(j) = RigaValori(i) : j += 1
                            ElseIf CSng(Table.Rows(0)(i)) > 0 Then
                                myDataRow(j) = CSng(Table.Rows(0)(i))
                                If IsDBNull(RigaValori(i)) Then
                                    myDataRow(j) = 0
                                Else
                                    myDataRow1(j) = RigaValori(i)
                                End If
                                j += 1
                            End If
                        Next
                        m.AlfaYoung.tblAlfa.Rows.Add(myDataRow)
                        m.AlfaYoung.tblAlfa.Rows.Add(myDataRow1)
                    End If
                    If m.ElasCod > 0 Then
                        cmd = New OleDbDataAdapter("SELECT * FROM Modelas", MatBase)
                        Table = New DataTable
                        cmd.Fill(Table)
                        Valor = PhysAlt(100, m.ElasCod, Table, RigaValori, m)
                        m.AlfaYoung.tblEmod = New DataTable
                        j = 0
                        For i = 0 To CShort(Table.Columns.Count - 1)
                            If IsDBNull(Table.Rows(0)(i)) Then
                                If i = 1 Then j += 1
                            ElseIf CSng(Table.Rows(0)(i)) > 0 Then
                                j += 1
                            End If
                        Next
                        n = j
                        For i = 0 To CShort(n - 1)
                            myDataColumn = New DataColumn
                            myDataColumn.DataType = Table.Columns(i).DataType
                            m.AlfaYoung.tblEmod.Columns.Add(myDataColumn)
                        Next
                        myDataRow = m.AlfaYoung.tblEmod.NewRow()
                        myDataRow1 = m.AlfaYoung.tblEmod.NewRow()
                        j = 0
                        For i = 0 To CShort(Table.Columns.Count - 1)
                            If IsDBNull(Table.Rows(0)(i)) Then
                                If i = 1 Then myDataRow1(j) = RigaValori(i) : j += 1
                            ElseIf CSng(Table.Rows(0)(i)) > 0 Then
                                myDataRow(j) = CSng(Table.Rows(0)(i))
                                If IsDBNull(RigaValori(i)) Then
                                    myDataRow(j) = 0
                                Else
                                    myDataRow1(j) = RigaValori(i)
                                End If
                                j += 1
                            End If
                        Next
                        m.AlfaYoung.tblEmod.Rows.Add(myDataRow)
                        m.AlfaYoung.tblEmod.Rows.Add(myDataRow1)
                    End If
                    If m.ConducTer > 0 Then
                        cmd = New OleDbDataAdapter("SELECT * FROM ConducTer", MatBase)
                        Table = New DataTable
                        cmd.Fill(Table)
                        Valor = PhysAlt(100, m.ConducTer, Table, RigaValori, m)
                        m.AlfaYoung.tblCond = New DataTable
                        j = 0
                        For i = 0 To CShort(Table.Columns.Count - 1)
                            If IsDBNull(Table.Rows(0)(i)) Then
                                If i = 1 Then j += 1
                            ElseIf CSng(Table.Rows(0)(i)) > 0 Then
                                j += 1
                            End If
                        Next
                        n = j
                        For i = 0 To CShort(n - 1)
                            myDataColumn = New DataColumn
                            myDataColumn.DataType = Table.Columns(i).DataType
                            m.AlfaYoung.tblCond.Columns.Add(myDataColumn)
                        Next
                        myDataRow = m.AlfaYoung.tblCond.NewRow()
                        myDataRow1 = m.AlfaYoung.tblCond.NewRow()
                        j = 0
                        For i = 0 To CShort(Table.Columns.Count - 1)
                            If IsDBNull(Table.Rows(0)(i)) Then
                                If i = 1 Then myDataRow1(j) = RigaValori(i) : j += 1
                            ElseIf CSng(Table.Rows(0)(i)) > 0 Then
                                myDataRow(j) = CSng(Table.Rows(0)(i))
                                If IsDBNull(RigaValori(i)) Then
                                    myDataRow(j) = 0
                                Else
                                    myDataRow1(j) = RigaValori(i)
                                End If
                                j += 1
                            End If
                        Next
                        m.AlfaYoung.tblCond.Rows.Add(myDataRow)
                        m.AlfaYoung.tblCond.Rows.Add(myDataRow1)
                    End If
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Me.Close()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        'Annulla della scelta materiale
        Me.Close()
        '   Set frmMater = Nothing
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        'OK della scelta classe
        Dim Clas As ClasseMateriale, i As Short
        Try
            If Not DesktopBounds.Equals(InitialDesktopBounds) Then
                cmdprezzi.Update(prezzi)
                DesktopBounds = InitialDesktopBounds
                cmdStampa1Listino.Visible = False
                Exit Sub
            End If
            If Mat.Classe > 10 Then
                Mat.MatSolo.Classe = Mat.Classe
                Mat.MatSolo.MostraPrezzi()
                Exit Sub
            End If
            For i = 0 To 9
                If Option3D1(i).Checked Then GoTo Cont
            Next
            Funzioni.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
            Exit Sub
Cont:
            With Mat
                AcceptButton = Command1
                Frame3D1.Visible = False
                If .Compos <> 0 Then
                    .MatCompos.Classe = CType(i + 1, ClasseMateriale)
                    .MatCompos.Mat(1).Classe = CType(i + 1, ClasseMateriale)
                    _Text1_4.Text = "Classe: " & Option3D1(i).Text
                    Call GenList(0)
                    If Tipo > 0 Then
                        _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(2310)) ' 1785
                        Select Case Tipo
                            Case TipoRivestimento.Placcato, TipoRivestimento.biPlaccato : Clas = ClasseMateriale.LamiereSS
                            Case TipoRivestimento.WO, TipoRivestimento.biWO : Clas = ClasseMateriale.Riporti
                            Case TipoRivestimento.Lining, TipoRivestimento.biLining : Clas = ClasseMateriale.Varie
                        End Select
                        '.MatCompos.Classe = Clas
                        .MatCompos.Mat(2).Classe = Clas
                        _List1_1.Visible = True
                        Call GenList(1)
                    Else
                        _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
                        _List1_1.Visible = False
                    End If
                Else
                    .MatSolo.Classe = CType(i + 1, ClasseMateriale)
                    _Text1_4.Text = "Classe: " & Option3D1(i).Text
                    Call GenList(0)
                    _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
                    _List1_1.Visible = False
                End If
            End With
            _List1_0.BringToFront()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        'Classe della scelta materiale
        With Mat
            If .Compos <> 0 Then
                Call VediClassi(.MatCompos)
            Else
                Call VediTutteClassi()
            End If
        End With
    End Sub
    Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
        Me.Close()
    End Sub
    Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, Monitor.Motore.HelptopicG(IDHS.IDH_CAP_BD_MAT_SCELTA))
    End Sub
    Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, Monitor.Motore.HelpStringaG(IDHS.IDH_CAP_BD_MAT_CLASSE))
    End Sub
    Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click
        'nessun materiale
        With Mat
            If .Compos <> 0 Then
                .MatCompos.Mat(1).Indmat = 0
                .MatCompos.Mat(1).MatStr = ""
            Else
                .MatSolo.Indmat = 0
                .MatSolo.MatStr = ""
            End If
        End With
        Me.Close()
    End Sub

    'UPGRADE_WARNING: Form evento frmMater.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmMater_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim i As Short
        If GiaAttiva Then Exit Sub
        If Not IniziaBase() Then Hide() : Exit Sub
        GiaAttiva = True
        If Mat.Editato > 0 Then
            Frame3D1.Visible = False
            Exit Sub
        End If
        If Mat.Compos <> 0 Then
            If Mat.MatCompos.Classe > 0 Then
                If Mat.MatCompos.TipoCompos = TipoRivestimento.Lining Then
                    _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
                    _List1_0.BringToFront()
                Else
                    _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(2310)) ' 1785
                    GenList(1)
                End If
                _Text1_4.Text = "Classe: " & Option3D1(CShort(Mat.MatCompos.Classe - 1)).Text
                Frame3D1.Visible = False
                Call GenList(0)
            Else
                Call VediClassi((Mat.MatCompos))
            End If
        Else
            If Mat.MatSolo.Indmat > 0 Then
                Call GenList(0)
                For i = 0 To CShort(_ListInd_0.Items.Count - 1)
                    If Val(_ListInd_0.Items(i)) = Mat.MatSolo.Indmat Then
                        _List1_0.Items(i).Selected = True 'Seleziona(_List1_0, i + 1)
                        Exit For
                    End If
                Next
                RegMat(0)
                _Text1_4.Text = "Classe: " & Option3D1(CShort(Mat.MatSolo.Classe - 1)).Text
                Frame3D1.Visible = False
                _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
                _List1_0.BringToFront()
            ElseIf Mat.MatSolo.Classe > 10 Then
                Exit Sub
            ElseIf Mat.MatSolo.Classe > 0 Then
                _Text1_4.Text = "Classe: " & Option3D1(CShort(Mat.MatSolo.Classe - 1)).Text
                Frame3D1.Visible = False
                _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
                _List1_0.BringToFront()
                Call GenList(0)
                '    ElseIf MatSolo.Classe < 0 Then
                '       VediClassi MatSolo
            Else
                Call VediTutteClassi()
            End If
        End If
    End Sub
    Private Sub GenList(ByRef Bas As Short, Optional ByRef Ordine1 As Short = -1)
        Dim Clas As ClasseMateriale
        Dim i, Indmat As Short
        Dim MatTxt As String
        Dim Ind2, Ind1, Ind3 As Short
        Dim r As DataTable = New DataTable
        Dim cmdr As OleDbDataAdapter
        Dim l As ListViewItem
        Dim testo As String
        Dim j As Short
        Dim n As Short
        Dim sql As String
        Static Ordine As Short
        If Ordine1 > -1 Then Ordine = Ordine1
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        With Mat
            If .Compos <> 0 Then Clas = .MatCompos.Mat(Bas + 1).Classe Else Clas = .MatSolo.Classe
        End With
        If Not IniziaBase() Then Exit Sub
        sql = "SELECT * FROM ListaMat WHERE Classe=" & Str(Clas)
        Select Case Ordine
            Case 0 : sql = sql & " ORDER BY Ordinamento"
            Case 1 : sql = sql & " ORDER BY Mat,Ordinamento"
            Case 2 : sql = sql & " ORDER BY Composiz,Mat,Ordinamento"
            Case 3 : sql = sql & " ORDER BY Product,Mat,Ordinamento"
            Case 4 : sql = sql & " ORDER BY AlloyUNS,Mat,Ordinamento"
        End Select
        Dim lv As New Windows.Forms.ListView
        Dim lb As New ListBox
        Select Case Bas
            Case 0 : lv = _List1_0
                lb = _ListInd_0
            Case 1 : lv = _List1_1
                lb = _ListInd_1
        End Select
        Try
            cmdr = New OleDbDataAdapter(sql, MatBase)
            cmdr.Fill(r)
            lv.Items.Clear()
            lb.Items.Clear()
            Dim dv As DataView = r.DefaultView
            For i = 0 To CShort(r.Rows.Count - 1)
                Dim drv As DataRowView = dv(i)
                If Not CBool(drv("Obsoleto")) Then
                    MatTxt = CStr(drv("Mat"))
                    If Len(MatTxt) < 10 Then MatTxt = MatTxt & Space(10 - Len(MatTxt))
                    l = lv.Items.Add(MatTxt.Trim)
                    If Rappresent = 0 Then
                        l.SubItems.Add(CStr(drv("CAT")))
                        l.SubItems.Add(CStr(drv("CT")))
                        l.SubItems.Add(CStr(drv("CMT")))
                        If IsDBNull(drv("NomeComm")) Then
                            l.SubItems.Add("")
                        Else
                            l.SubItems.Add(CStr(drv("NomeComm")))
                        End If
                    Else
                        If IsDBNull(drv("Composiz")) Then testo = "" Else testo = CStr(drv("Composiz"))
                        If testo.Length > 0 Then
                            j = 1
                            Do
                                n = CShort(testo.IndexOf(" ", j - 1) + 1)
                                If n > 0 Then
                                    testo = testo.Substring(0, n - 1) & testo.Substring(n, testo.Length - n) ' VB.Right(testo, Len(testo) - n)
                                    j = n
                                Else
                                    Exit Do
                                End If
                            Loop
                        End If
                        l.SubItems.Add(testo)
                        If IsDBNull(drv("Product")) Then testo = "" Else testo = CStr(drv("Product"))
                        l.SubItems.Add(testo)
                        If IsDBNull(drv("AlloyUNS")) Then testo = "" Else testo = CStr(drv("AlloyUNS"))
                        l.SubItems.Add(testo)
                        If IsDBNull(drv("NomeComm")) Then testo = "" Else testo = CStr(drv("NomeComm"))
                        l.SubItems.Add(testo)
                    End If
                    lb.Items.Add(drv("Ind"))
                End If
            Next i
            If Mat.Compos <> 0 Then
                Indmat = IndMatAct(Tipo, Ind1, Ind2, Ind3)
            Else
                Indmat = Mat.MatSolo.Indmat
                Tipo = 0
            End If
            If Indmat = 0 Then
                r.Clear()
                r.Dispose()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            dv.Sort = "Ind"
            Dim iFound As Integer = dv.Find(Indmat)
            For i = 0 To CShort(lv.Items.Count - 1)
                If CInt(lb.Items(i)) = Indmat Then
                    lv.Items(i).EnsureVisible()
                    lv.Items(i).Selected = True 'Seleziona(lv, i + 1)
                    lv.Items(i).Focused = True 'Seleziona(lv, i + 1)
                    lb.SelectedIndex = i
                    Exit For
                End If
            Next
            r.Clear()
            r.Dispose()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Function IndMatAct(ByRef Tipo As TipoRivestimento, ByRef Ind1 As Short, ByRef Ind2 As Short, ByRef Ind3 As Short) As Short
        With Mat
            Tipo = .MatCompos.TipoCompos 'DatiSh1(Index1).MateInform(Index2).Tipo
            Ind1 = .MatCompos.Mat(1).Indmat 'DatiSh1(Index1).MateInform(Index2).Ind1
            Ind2 = .MatCompos.Mat(2).Indmat 'DatiSh1(Index1).MateInform(Index2).Ind2
            Ind3 = .MatCompos.Mat(3).Indmat             'DatiSh1(Index1).MateInform(Index2).Ind3
        End With
        IndMatAct = Ind1 'DatiSh1(Index1).MateInform(Index2).Ind1
    End Function
    'Private Sub frmMater_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    '   Scambia()
    'End Sub
    'UPGRADE_WARNING: Form evento frmMater.Unload presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmMater_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        Dim Mat As clsMat 'Form
        If FormMat.Count() > 0 Then
            Mat = FormMat.Item(FormMat.Count()).TextData
            FormMat.remove(FormMat.Count())
            With Mat
                .frm = Nothing
                .MatSolo = Nothing
                .MatCompos = Nothing
            End With
            Mat = Nothing
        Else
            frmMater.DefInstance = Nothing
        End If
    End Sub
    Private Sub Option3D1_CheckedChanged(ByVal Index As Short)
        If Option3D1(Index).Checked Then
            With Mat
                .Classe = CType(Index + 1, ClasseMateriale)
                If .Compos <> 0 Then
                    If Option3D1(Index).Checked Then .MatCompos.Classe = CType(Index + 1, ClasseMateriale)
                Else
                    If Option3D1(Index).Checked Then .MatSolo.Classe = CType(Index + 1, ClasseMateriale)
                End If
            End With
        End If
    End Sub
    Private Sub Option3D2_CheckedChanged(ByVal Index As Short)
        If Option3D2(Index).Checked Then
            If Option3D2(Index).Checked Then
                Select Case Index
                    Case 0 'placcato
                        Option3D3(0).Enabled = True
                        Option3D3(1).Enabled = True
                        Option3D3(1).Checked = True
                        Option3D3(2).Enabled = False
                        Tipo = TipoRivestimento.Placcato
                    Case 1 'W.O.
                        Option3D3(0).Enabled = False
                        Option3D3(1).Enabled = False
                        Option3D3(1).Checked = True
                        Option3D3(2).Enabled = False
                        Tipo = TipoRivestimento.WO
                    Case 2 'lining
                        Option3D3(0).Enabled = True
                        Option3D3(1).Enabled = True
                        Option3D3(0).Checked = True
                        Option3D3(2).Enabled = True
                        Tipo = TipoRivestimento.Lining
                End Select
                If CBool(Check3D2.CheckState) Then Tipo = CType(CShort(Tipo) + 3, TipoRivestimento)
            End If
            Call RegTipo()
        End If
    End Sub
    Private Sub RegMat(ByRef Bas As Short)
        Dim lv As New ListView
        Dim lv1 As New ListView
        Select Case Bas
            Case 0
                lv = _List1_0
                lv1 = _List1_1
            Case 1
                lv = _List1_1
                lv1 = _List1_0
        End Select
        If SelectedItem(lv) Is Nothing Then
            Funzioni.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
            Exit Sub
        End If
        If Tipo > 0 Then
            If SelectedItem(lv1) Is Nothing Then
                Funzioni.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
                Exit Sub
            End If
        End If
        If Not IniziaBase() Then Exit Sub
        Call GetMat(CShort(GetItemStringLI(Bas, CShort(SelectedItem(lv).Index))), CShort(Bas + 1)) 'era -1
    End Sub
    Private Function GetItemStringLI(ByVal Bas As Short, ByVal index As Short) As String
        Try
            Select Case Bas
                Case 0
                    Return CStr(_ListInd_0.Items(index))
                Case 1
                    Return CStr(_ListInd_1.Items(index))
                Case 2
                    Return CStr(_ListInd_2.Items(index))
                Case Else
                    Return ""
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Return ""
        End Try
    End Function
    Private Sub RegTipo()
        Mat.MatCompos.TipoCompos = Tipo 'DatiSh1(Index1).MateInform(Index2).Tipo = Tipo
    End Sub
    Private Sub VediClassi(ByRef MatCompos As clsMatCompos)
        Dim i As Short
        Dim Ind2, Ind1, Ind3 As Short
        Dim Indmat As Short
        Dim r As New DataTable
        Dim cmdr As OleDbDataAdapter
        IniziaBase()
        AcceptButton = Command3
        Frame3D1.Visible = True
        Try
            For i = 0 To 9
                If MatCompos.Ind.Count < i + 1 Then MatCompos.IndAdd(1, CShort(i + 1))
                Option3D1(i).Enabled = (MatCompos.Ind.Item(i + 1).TextData = 1)
                Option3D1(i).Checked = False
            Next
            cmdAbilita.Visible = True
            Indmat = IndMatAct(Tipo, Ind1, Ind2, Ind3)
            If Indmat = 0 Then Tipo = 0 : Call RegTipo()
            Select Case Tipo
                Case 0 : Check3D1.CheckState = System.Windows.Forms.CheckState.Checked 'True
                Case Else
                    Check3D1.CheckState = System.Windows.Forms.CheckState.Unchecked ' False
                    If Ind2 > 0 Then
                        cmdr = New OleDbDataAdapter("SELECT Classe FROM ListaMat WHERE Ind=" & Str(Ind2), MatBase)
                        cmdr.Fill(r)
                        Select Case CInt(r.Rows(0)("Classe"))
                            Case 2 : Option3D3(0).Checked = True
                            Case 9 : Option3D3(1).Checked = True
                            Case 10 : Option3D3(2).Checked = True
                            Case Else : Option3D3(1).Checked = True
                        End Select
                        r.Clear()
                        r.Dispose()
                    Else
                        Option3D3(1).Checked = True
                    End If
                    Select Case Tipo
                        Case TipoRivestimento.Placcato, TipoRivestimento.biPlaccato : Option3D2(0).Checked = True
                        Case TipoRivestimento.WO, TipoRivestimento.biWO : Option3D2(1).Checked = True
                        Case TipoRivestimento.Lining, TipoRivestimento.biLining : Option3D2(2).Checked = True
                    End Select
            End Select
            If Indmat > 0 Then
                cmdr = New OleDbDataAdapter("SELECT Classe FROM ListaMat WHERE Ind=" & Str(Indmat), MatBase)
                cmdr.Fill(r)
                If r.Rows.Count > 0 Then Option3D1(CShort(CShort(r.Rows(0)("Classe")) - 1)).Checked = True
                r.Clear()
                r.Dispose()
            Else
                For i = 0 To 9
                    If MatCompos.Ind.Item(i + 1).TextData = 1 Then
                        Option3D1(i).Checked = True
                        Exit For
                    End If
                Next
            End If
            If Tipo > 0 Then
                _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(2310)) ' 1785
            Else
                _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
            End If
            _List1_0.BringToFront()
            Frame3D1.BringToFront()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub GetMat(ByRef Clas As Short, ByRef Bas As Short)
        Dim r As New DataTable
        Dim cmdr As OleDbDataAdapter
        Dim m As LibMat.MaterialeNew1
        m = MaterAct(Bas)
        Try
            cmdr = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(Clas), MatBase)
            cmdr.Fill(r)
            If r.Rows.Count <> 1 Then MsgBox("Oopss! in GetMat") : Stop
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Dim dvr As New DataView(r)
        TransferMat(dvr(0), Bas)
        dvr.Dispose()
        r.Clear()
        r.Dispose()
    End Sub
    Public Sub VediTutteClassi()
        Dim i As Short
        AcceptButton = Command3
        Frame3D1.Visible = True
        For i = 0 To 9
            Option3D1(i).Enabled = True
            Option3D1(i).Checked = False
        Next
        cmdAbilita.Enabled = False
        If Mat.MatSolo.Classe > 0 Then Option3D1(CShort(Mat.MatSolo.Classe - 1)).Checked = True Else Option3D1(0).Checked = True
        _List1_0.Height = CInt(Funzioni.TwipsToPixelsY(3735))
        _List1_0.BringToFront()
        Frame3D1.BringToFront()
    End Sub
    Public Function Option3D1(ByVal i As Short) As RadioButton
        Select Case i
            Case 0 : Return _Option3D1_0
            Case 1 : Return _Option3D1_1
            Case 2 : Return _Option3D1_2
            Case 3 : Return _Option3D1_3
            Case 4 : Return _Option3D1_4
            Case 5 : Return _Option3D1_5
            Case 6 : Return _Option3D1_6
            Case 7 : Return _Option3D1_7
            Case 8 : Return _Option3D1_8
            Case 9 : Return _Option3D1_9
            Case Else : Return Nothing
        End Select
    End Function
    Public Function Option3D2(ByVal i As Short) As RadioButton
        Select Case i
            Case 0 : Return _Option3D2_0
            Case 1 : Return _Option3D2_1
            Case 2 : Return _Option3D2_2
            Case Else : Return Nothing
        End Select
    End Function
    Public Function Option3D3(ByVal i As Short) As RadioButton
        Select Case i
            Case 0 : Return _Option3D3_0
            Case 1 : Return _Option3D3_1
            Case 2 : Return _Option3D3_2
            Case Else : Return Nothing
        End Select
    End Function
    Private Sub Scambia()
        Dim i As Short, l As ListView
        If Rappresent = 0 Then
            Rappresent = 1
            For i = 0 To 1
                If i = 0 Then l = _List1_0 Else l = _List1_1
                l.Columns(0).Width = CInt(Funzioni.TwipsToPixelsY(3300))
                l.Columns(1).Text = "Composizione"
                l.Columns(1).Width = CInt(Funzioni.TwipsToPixelsY(1500))
                l.Columns(2).Text = "Prodotto"
                l.Columns(2).Width = CInt(Funzioni.TwipsToPixelsY(800))
                l.Columns(3).Text = "Alloy UNS"
                l.Columns(3).Width = CInt(Funzioni.TwipsToPixelsY(1100))
            Next
        Else
            Rappresent = 0
            For i = 0 To 1
                If i = 0 Then l = _List1_0 Else l = _List1_1
                l.Columns(0).Width = CInt(Funzioni.TwipsToPixelsY(3300))
                l.Columns(1).Text = "CAT"
                l.Columns(1).Width = CInt(Funzioni.TwipsToPixelsY(400))
                l.Columns(2).Text = "CT"
                l.Columns(2).Width = CInt(Funzioni.TwipsToPixelsY(400))
                l.Columns(3).Text = "MAT"
                l.Columns(3).Width = CInt(Funzioni.TwipsToPixelsY(400))
            Next
        End If
    End Sub
    Private Sub _List1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _List1_0.Click
        Dim Mat As clsMat
        Mat = FormMat.Item(FormMat.Count()).TextData
        Mat.IndiceLista = 1
    End Sub
    Private Sub _List1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _List1_1.Click
        Dim Mat As clsMat
        Mat = FormMat.Item(FormMat.Count()).TextData
        Mat.IndiceLista = 2
    End Sub
    Private Sub _List1_1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles _List1_1.ColumnClick
        If Vecchio = e.Column Then Exit Sub
        Select Case e.Column
            Case 0 'sigla
                If Vecchio = 0 Then
                    GenList(1, 1)
                    _cmdEdit_1.Enabled = False
                    _cmdEdit_2.Enabled = False
                    Vecchio = -1
                    Exit Sub
                Else
                    GenList(1, 0)
                    _cmdEdit_1.Enabled = True
                    _cmdEdit_2.Enabled = True
                End If
            Case 1, 2, 3
                If Rappresent = 1 Then
                    GenList(1, CShort(e.Column + 1))
                    _cmdEdit_1.Enabled = False
                    _cmdEdit_2.Enabled = False
                Else
                    Exit Sub
                End If
        End Select
        Vecchio = CShort(e.Column)
    End Sub
    Private Sub _List1_0_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles _List1_0.ColumnClick
        Select Case e.Column
            Case 0 'sigla
                If Vecchio = 0 Then
                    GenList(0, 1)
                    _cmdEdit_1.Enabled = False
                    _cmdEdit_2.Enabled = False
                    Vecchio = -1
                    Exit Sub
                Else
                    GenList(0, 0)
                    _cmdEdit_1.Enabled = True
                    _cmdEdit_2.Enabled = True
                End If
            Case 1, 2, 3
                If Rappresent = 1 Then
                    GenList(0, CShort(e.Column + 1))
                    _cmdEdit_1.Enabled = False
                    _cmdEdit_2.Enabled = False
                Else
                    Exit Sub
                End If
        End Select
        Vecchio = CShort(e.Column)
    End Sub
    Private Sub _List1_0_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _List1_0.DoubleClick
        Call RegMat(0)
        Me.Close()
    End Sub
    Private Sub _List1_1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _List1_1.DoubleClick
        Call RegMat(1)
        Me.Close()
    End Sub
    Private Sub _List1_0_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _List1_0.KeyUp
        Static Ind, Classe As Short
        Static r, t As DataTable
        Dim iFound As Integer
        Dim VList As Short
        Dim Ord1, Ord2 As Single
        Static cmd, cmdt As OleDbDataAdapter
        Static dv As DataView
        Static drv As DataRowView
        Static CB As OleDbCommandBuilder
        If e.KeyCode = System.Windows.Forms.Keys.X And e.Control Then   'Ctrl-X
            VList = CShort(_List1_0.SelectedItems(0).Index)
            Ind = CShort(_ListInd_0.Items(VList - 1))
            cmd = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(Ind), MatBase)
            If r Is Nothing Then r = New DataTable
            cmd.Fill(r)
            CB = New OleDbCommandBuilder(cmd)
            dv = New DataView(r)
            drv = dv(0)
            Classe = CShort(drv("Classe"))
            drv.BeginEdit()
            drv("Ordinamento") = 99999.0#
            drv.EndEdit()
            cmd.Update(r)
            GenList(0)
            VList = CShort(VList + 5)
            If VList > _List1_0.Items.Count - 1 Then VList = CShort(_List1_0.Items.Count - 1)
            _List1_0.Items(VList).EnsureVisible()
        ElseIf e.KeyCode = System.Windows.Forms.Keys.V And e.Control Then    'Ctrl-V
            If Ind = 0 Then Exit Sub
            '-------------------------------------------------------------
            VList = CShort(_List1_0.SelectedItems(0).Index)
            Ind = CShort(_ListInd_0.Items(VList - 1))
            cmdt = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Classe=" & Str(Classe) & " ORDER BY Ordinamento", MatBase)
            If t Is Nothing Then t = New DataTable
            cmdt.Fill(t)
            Dim dvt As DataView = New DataView(t)
            dvt.Sort = "Ind"
            iFound = dvt.Find(Ind)
            Ord1 = CSng(dvt(iFound)("Ordinamento"))
            dvt.Sort = "Ordinamento"
            iFound = dvt.Find(Ord1)
            iFound += 1
            If iFound = dvt.Count - 1 Then
                Ord2 = Ord1 + 2
            Else
                Ord2 = CSng(dvt(iFound)("Ordinamento"))
            End If
            t.Clear()
            t.Dispose()
            cmdt.Dispose()
            drv.BeginEdit()
            drv("Ordinamento") = (Ord1 + Ord2) / 2
            drv.EndEdit()
            cmd.Update(r)
            GenList(0)
            VList = CShort(VList + 5)
            If VList > _List1_0.Items.Count - 1 Then VList = CShort(_List1_0.Items.Count - 1)
            _List1_0.Items(VList).EnsureVisible()
            '-------------------------------------------------------------
            Ind = 0
            r.Clear()
            r.Dispose()
            cmd.Dispose()
            CB.Dispose()
        End If
    End Sub
    Private Function SelectedItem(ByVal l As ListView) As ListViewItem
        Dim i As Integer
        For i = 0 To l.Items.Count - 1
            If l.Items(i).Selected Then Return l.Items(i)
        Next
        Return Nothing
    End Function
    '  Private Sub Seleziona(ByVal l As ListView, ByVal j As Integer)
    '     Dim i As Integer
    '    For i = 0 To l.Items.Count - 1
    '       l.Items(i).Selected = i <> j
    '  Next
    'End Sub
    Private Sub frmMater_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Frame3D1.Top = 0
        Me.Height = Me.Frame3D1.Height + SystemInformation.CaptionHeight
        Me.Width = _cmdEdit_0.Left + _cmdEdit_0.Width + 2
        InitialDesktopBounds = DesktopBounds
    End Sub
    Private Sub _cmdEdit_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdEdit_0.Click
        cmdEdit(0)
    End Sub
    Private Sub _cmdEdit_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdEdit_1.Click
        cmdEdit(1)
    End Sub
    Private Sub _cmdEdit_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdEdit_2.Click
        cmdEdit(2)
    End Sub
    Private Sub _cmdEdit_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdEdit_3.Click
        cmdEdit(3)
    End Sub
    Public Function optLE(ByVal i As Short) As RadioButton
        Select Case i
            Case 0 : Return _optLE_0
            Case 1 : Return _optLE_1
            Case 2 : Return _optLE_2
            Case Else : Return Nothing
        End Select
    End Function
    Private Sub _cmdEdit_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdEdit_4.Click
        cmdEdit(4)
    End Sub

    Private Sub _optLE_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optLE_0.CheckedChanged
        If _optLE_0.Checked Then
            Mat.Classe = ClasseMateriale.FormaturaFondiEllittici
        End If
    End Sub

    Private Sub _optLE_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optLE_1.CheckedChanged
        If _optLE_1.Checked Then
            Mat.Classe = ClasseMateriale.FormaturaFondiEmisferici
        End If
    End Sub

    Private Sub _optLE_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optLE_2.CheckedChanged
        If _optLE_2.Checked Then
            Mat.Classe = ClasseMateriale.Calandratura
        End If

    End Sub

    Private Sub _Option3D1_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_0.CheckedChanged
        Option3D1_CheckedChanged(0)
    End Sub
    Private Sub _Option3D1_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_1.CheckedChanged
        Option3D1_CheckedChanged(1)
    End Sub
    Private Sub _Option3D1_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_2.CheckedChanged
        Option3D1_CheckedChanged(2)
    End Sub
    Private Sub _Option3D1_3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_3.CheckedChanged
        Option3D1_CheckedChanged(3)
    End Sub
    Private Sub _Option3D1_4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_4.CheckedChanged
        Option3D1_CheckedChanged(4)
    End Sub
    Private Sub _Option3D1_5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_5.CheckedChanged
        Option3D1_CheckedChanged(5)
    End Sub
    Private Sub _Option3D1_6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_6.CheckedChanged
        Option3D1_CheckedChanged(6)
    End Sub
    Private Sub _Option3D1_7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_7.CheckedChanged
        Option3D1_CheckedChanged(7)
    End Sub
    Private Sub _Option3D1_8_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_8.CheckedChanged
        Option3D1_CheckedChanged(8)
    End Sub
    Private Sub _Option3D1_9_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D1_9.CheckedChanged
        Option3D1_CheckedChanged(9)
    End Sub
    Private Sub _Option3D2_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D2_0.CheckedChanged
        Option3D2_CheckedChanged(0)
    End Sub
    Private Sub _Option3D2_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D2_1.CheckedChanged
        Option3D2_CheckedChanged(1)
    End Sub
    Private Sub _Option3D2_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option3D2_2.CheckedChanged
        Option3D2_CheckedChanged(2)
    End Sub

    Private Sub cmdStampa1Listino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStampa1Listino.Click
        cmdprezzi.Update(prezzi)
        If Mat.Classe < 11 Then
            StampaListino(Option3D1(CShort(Mat.Classe - 1)).Text)
        Else
            StampaListino(optLE(CShort(Mat.Classe - 11)).Text)
        End If

    End Sub
End Class
