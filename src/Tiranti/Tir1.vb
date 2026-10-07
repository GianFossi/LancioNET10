Option Strict On
Option Explicit On 
'Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic
Friend Class Tir1
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
    Public WithEvents cmdDone As System.Windows.Forms.Button
	Public WithEvents _Text_29 As System.Windows.Forms.TextBox
	Public WithEvents _Text_28 As System.Windows.Forms.TextBox
	Public WithEvents _Coeff_1 As System.Windows.Forms.ComboBox
	Public WithEvents _Coeff_0 As System.Windows.Forms.ComboBox
	Public WithEvents _Text_27 As System.Windows.Forms.TextBox
	Public WithEvents _Text_10 As System.Windows.Forms.TextBox
	Public WithEvents _Text_11 As System.Windows.Forms.TextBox
	Public WithEvents _Text_26 As System.Windows.Forms.TextBox
	Public WithEvents _Label_33 As System.Windows.Forms.Label
	Public WithEvents _lblMis_29 As System.Windows.Forms.Label
	Public WithEvents _Label_32 As System.Windows.Forms.Label
	Public WithEvents _Label_9 As System.Windows.Forms.Label
	Public WithEvents _Label_10 As System.Windows.Forms.Label
	Public WithEvents _lblMis_27 As System.Windows.Forms.Label
	Public WithEvents _Label_31 As System.Windows.Forms.Label
	Public WithEvents _lblMis_10 As System.Windows.Forms.Label
	Public WithEvents _Label_14 As System.Windows.Forms.Label
	Public WithEvents _Label_15 As System.Windows.Forms.Label
	Public WithEvents _lblMis_11 As System.Windows.Forms.Label
	Public WithEvents _Label_30 As System.Windows.Forms.Label
	Public WithEvents Frame4 As System.Windows.Forms.GroupBox
	Public WithEvents _Text_25 As System.Windows.Forms.TextBox
	Public WithEvents _Text_24 As System.Windows.Forms.TextBox
	Public WithEvents _Text_22 As System.Windows.Forms.TextBox
	Public WithEvents _Text_23 As System.Windows.Forms.TextBox
	Public WithEvents _Text_21 As System.Windows.Forms.TextBox
	Public WithEvents _Label_29 As System.Windows.Forms.Label
	Public WithEvents _lblMis_25 As System.Windows.Forms.Label
	Public WithEvents _lblMis_24 As System.Windows.Forms.Label
	Public WithEvents _Label_28 As System.Windows.Forms.Label
	Public WithEvents _Label_27 As System.Windows.Forms.Label
	Public WithEvents _Label_26 As System.Windows.Forms.Label
	Public WithEvents _lblMis_22 As System.Windows.Forms.Label
	Public WithEvents _Label_25 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents _Text_20 As System.Windows.Forms.TextBox
	Public WithEvents _Text_19 As System.Windows.Forms.TextBox
	Public WithEvents _Text_18 As System.Windows.Forms.TextBox
	Public WithEvents _Text_17 As System.Windows.Forms.TextBox
	Public WithEvents _Label_24 As System.Windows.Forms.Label
	Public WithEvents _lblMis_20 As System.Windows.Forms.Label
	Public WithEvents _Label_23 As System.Windows.Forms.Label
	Public WithEvents _Label_22 As System.Windows.Forms.Label
	Public WithEvents _lblMis_18 As System.Windows.Forms.Label
	Public WithEvents _Label_11 As System.Windows.Forms.Label
	Public WithEvents _lblMis_17 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents _Text_32 As System.Windows.Forms.TextBox
	Public WithEvents _Text_0 As System.Windows.Forms.TextBox
	Public WithEvents _Text_6 As System.Windows.Forms.TextBox
	Public WithEvents _Text_5 As System.Windows.Forms.TextBox
	Public WithEvents _Text_8 As System.Windows.Forms.TextBox
	Public WithEvents _Text_9 As System.Windows.Forms.TextBox
	Public WithEvents _Text_7 As System.Windows.Forms.TextBox
	Public WithEvents _Text_14 As System.Windows.Forms.TextBox
	Public WithEvents _Text_31 As System.Windows.Forms.TextBox
	Public WithEvents _Text_13 As System.Windows.Forms.TextBox
	Public WithEvents _Text_12 As System.Windows.Forms.TextBox
	Public WithEvents _Text_3 As System.Windows.Forms.TextBox
	Public WithEvents _Text_16 As System.Windows.Forms.TextBox
	Public WithEvents _Text_1 As System.Windows.Forms.TextBox
	Public WithEvents _Command1_2 As System.Windows.Forms.Button
	Public WithEvents _Text_15 As System.Windows.Forms.TextBox
	Public WithEvents _Command1_1 As System.Windows.Forms.Button
	Public WithEvents _Text_30 As System.Windows.Forms.TextBox
	Public WithEvents _Text_2 As System.Windows.Forms.TextBox
	Public WithEvents _Command1_0 As System.Windows.Forms.Button
	Public WithEvents _Text_4 As System.Windows.Forms.TextBox
	Public WithEvents _Label_34 As System.Windows.Forms.Label
	Public WithEvents _lblMis_32 As System.Windows.Forms.Label
	Public WithEvents _lblMis_6 As System.Windows.Forms.Label
	Public WithEvents _Label_6 As System.Windows.Forms.Label
	Public WithEvents _lblMis_5 As System.Windows.Forms.Label
	Public WithEvents _Label_5 As System.Windows.Forms.Label
	Public WithEvents _Label_8 As System.Windows.Forms.Label
	Public WithEvents _Label_7 As System.Windows.Forms.Label
	Public WithEvents _lblMis_9 As System.Windows.Forms.Label
	Public WithEvents _Label_13 As System.Windows.Forms.Label
	Public WithEvents _Label_21 As System.Windows.Forms.Label
	Public WithEvents _Label_20 As System.Windows.Forms.Label
	Public WithEvents _lblMis_15 As System.Windows.Forms.Label
	Public WithEvents _lblMis_14 As System.Windows.Forms.Label
	Public WithEvents _Label_19 As System.Windows.Forms.Label
	Public WithEvents _Label_18 As System.Windows.Forms.Label
	Public WithEvents _Label_17 As System.Windows.Forms.Label
	Public WithEvents _lblMis_13 As System.Windows.Forms.Label
	Public WithEvents _Label_16 As System.Windows.Forms.Label
	Public WithEvents _lblMis_12 As System.Windows.Forms.Label
	Public WithEvents _Label_2 As System.Windows.Forms.Label
	Public WithEvents _Label_3 As System.Windows.Forms.Label
	Public WithEvents _lblMis_2 As System.Windows.Forms.Label
	Public WithEvents _lblMis_3 As System.Windows.Forms.Label
	Public WithEvents _Label_4 As System.Windows.Forms.Label
	Public WithEvents _Label_0 As System.Windows.Forms.Label
	Public WithEvents _Label_12 As System.Windows.Forms.Label
	Public WithEvents _lblMis_0 As System.Windows.Forms.Label
	Public WithEvents _Label_1 As System.Windows.Forms.Label
	Public WithEvents _lblMis_1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Labelcom1 As System.Windows.Forms.Label
	Public WithEvents Commento As System.Windows.Forms.GroupBox
	Public WithEvents _calcasme_1 As System.Windows.Forms.RadioButton
	Public WithEvents _calcasme_0 As System.Windows.Forms.RadioButton
	Public WithEvents Tipocalc As System.Windows.Forms.GroupBox
	Public WithEvents _SysInter_2 As System.Windows.Forms.RadioButton
	Public WithEvents _SysInter_1 As System.Windows.Forms.RadioButton
	Public WithEvents _SysInter_0 As System.Windows.Forms.RadioButton
	Public WithEvents Sistema As System.Windows.Forms.GroupBox
    Public WithEvents mennuovo As System.Windows.Forms.MenuItem
	Public WithEvents menapri As System.Windows.Forms.MenuItem
	Public WithEvents menSalva As System.Windows.Forms.MenuItem
	Public WithEvents line1 As System.Windows.Forms.MenuItem
	Public WithEvents menstampa As System.Windows.Forms.MenuItem
	Public WithEvents line2 As System.Windows.Forms.MenuItem
	Public WithEvents menEsci As System.Windows.Forms.MenuItem
	Public WithEvents menfile As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents O_S As System.Windows.Forms.OpenFileDialog
    Friend WithEvents S_S As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
    Friend WithEvents Nuovo As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarImageList As System.Windows.Forms.ImageList
    Friend WithEvents Apri As System.Windows.Forms.ToolBarButton
    Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
    Friend WithEvents Stampa As System.Windows.Forms.ToolBarButton
    Friend WithEvents Esci As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Tir1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Command1_2 = New System.Windows.Forms.Button
        Me._Command1_1 = New System.Windows.Forms.Button
        Me._Command1_0 = New System.Windows.Forms.Button
        Me.cmdDone = New System.Windows.Forms.Button
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me._Text_29 = New System.Windows.Forms.TextBox
        Me._Text_28 = New System.Windows.Forms.TextBox
        Me._Coeff_1 = New System.Windows.Forms.ComboBox
        Me._Coeff_0 = New System.Windows.Forms.ComboBox
        Me._Text_27 = New System.Windows.Forms.TextBox
        Me._Text_10 = New System.Windows.Forms.TextBox
        Me._Text_11 = New System.Windows.Forms.TextBox
        Me._Text_26 = New System.Windows.Forms.TextBox
        Me._Label_33 = New System.Windows.Forms.Label
        Me._lblMis_29 = New System.Windows.Forms.Label
        Me._Label_32 = New System.Windows.Forms.Label
        Me._Label_9 = New System.Windows.Forms.Label
        Me._Label_10 = New System.Windows.Forms.Label
        Me._lblMis_27 = New System.Windows.Forms.Label
        Me._Label_31 = New System.Windows.Forms.Label
        Me._lblMis_10 = New System.Windows.Forms.Label
        Me._Label_14 = New System.Windows.Forms.Label
        Me._Label_15 = New System.Windows.Forms.Label
        Me._lblMis_11 = New System.Windows.Forms.Label
        Me._Label_30 = New System.Windows.Forms.Label
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me._Text_25 = New System.Windows.Forms.TextBox
        Me._Text_24 = New System.Windows.Forms.TextBox
        Me._Text_22 = New System.Windows.Forms.TextBox
        Me._Text_23 = New System.Windows.Forms.TextBox
        Me._Text_21 = New System.Windows.Forms.TextBox
        Me._Label_29 = New System.Windows.Forms.Label
        Me._lblMis_25 = New System.Windows.Forms.Label
        Me._lblMis_24 = New System.Windows.Forms.Label
        Me._Label_28 = New System.Windows.Forms.Label
        Me._Label_27 = New System.Windows.Forms.Label
        Me._Label_26 = New System.Windows.Forms.Label
        Me._lblMis_22 = New System.Windows.Forms.Label
        Me._Label_25 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me._Text_20 = New System.Windows.Forms.TextBox
        Me._Text_19 = New System.Windows.Forms.TextBox
        Me._Text_18 = New System.Windows.Forms.TextBox
        Me._Text_17 = New System.Windows.Forms.TextBox
        Me._Label_24 = New System.Windows.Forms.Label
        Me._lblMis_20 = New System.Windows.Forms.Label
        Me._Label_23 = New System.Windows.Forms.Label
        Me._Label_22 = New System.Windows.Forms.Label
        Me._lblMis_18 = New System.Windows.Forms.Label
        Me._Label_11 = New System.Windows.Forms.Label
        Me._lblMis_17 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Text_32 = New System.Windows.Forms.TextBox
        Me._Text_0 = New System.Windows.Forms.TextBox
        Me._Text_6 = New System.Windows.Forms.TextBox
        Me._Text_5 = New System.Windows.Forms.TextBox
        Me._Text_8 = New System.Windows.Forms.TextBox
        Me._Text_9 = New System.Windows.Forms.TextBox
        Me._Text_7 = New System.Windows.Forms.TextBox
        Me._Text_14 = New System.Windows.Forms.TextBox
        Me._Text_31 = New System.Windows.Forms.TextBox
        Me._Text_13 = New System.Windows.Forms.TextBox
        Me._Text_12 = New System.Windows.Forms.TextBox
        Me._Text_3 = New System.Windows.Forms.TextBox
        Me._Text_16 = New System.Windows.Forms.TextBox
        Me._Text_1 = New System.Windows.Forms.TextBox
        Me._Text_15 = New System.Windows.Forms.TextBox
        Me._Text_30 = New System.Windows.Forms.TextBox
        Me._Text_2 = New System.Windows.Forms.TextBox
        Me._Text_4 = New System.Windows.Forms.TextBox
        Me._Label_34 = New System.Windows.Forms.Label
        Me._lblMis_32 = New System.Windows.Forms.Label
        Me._lblMis_6 = New System.Windows.Forms.Label
        Me._Label_6 = New System.Windows.Forms.Label
        Me._lblMis_5 = New System.Windows.Forms.Label
        Me._Label_5 = New System.Windows.Forms.Label
        Me._Label_8 = New System.Windows.Forms.Label
        Me._Label_7 = New System.Windows.Forms.Label
        Me._lblMis_9 = New System.Windows.Forms.Label
        Me._Label_13 = New System.Windows.Forms.Label
        Me._Label_21 = New System.Windows.Forms.Label
        Me._Label_20 = New System.Windows.Forms.Label
        Me._lblMis_15 = New System.Windows.Forms.Label
        Me._lblMis_14 = New System.Windows.Forms.Label
        Me._Label_19 = New System.Windows.Forms.Label
        Me._Label_18 = New System.Windows.Forms.Label
        Me._Label_17 = New System.Windows.Forms.Label
        Me._lblMis_13 = New System.Windows.Forms.Label
        Me._Label_16 = New System.Windows.Forms.Label
        Me._lblMis_12 = New System.Windows.Forms.Label
        Me._Label_2 = New System.Windows.Forms.Label
        Me._Label_3 = New System.Windows.Forms.Label
        Me._lblMis_2 = New System.Windows.Forms.Label
        Me._lblMis_3 = New System.Windows.Forms.Label
        Me._Label_4 = New System.Windows.Forms.Label
        Me._Label_0 = New System.Windows.Forms.Label
        Me._Label_12 = New System.Windows.Forms.Label
        Me._lblMis_0 = New System.Windows.Forms.Label
        Me._Label_1 = New System.Windows.Forms.Label
        Me._lblMis_1 = New System.Windows.Forms.Label
        Me.Commento = New System.Windows.Forms.GroupBox
        Me.Labelcom1 = New System.Windows.Forms.Label
        Me.Tipocalc = New System.Windows.Forms.GroupBox
        Me._calcasme_1 = New System.Windows.Forms.RadioButton
        Me._calcasme_0 = New System.Windows.Forms.RadioButton
        Me.Sistema = New System.Windows.Forms.GroupBox
        Me._SysInter_2 = New System.Windows.Forms.RadioButton
        Me._SysInter_1 = New System.Windows.Forms.RadioButton
        Me._SysInter_0 = New System.Windows.Forms.RadioButton
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.menfile = New System.Windows.Forms.MenuItem
        Me.mennuovo = New System.Windows.Forms.MenuItem
        Me.menapri = New System.Windows.Forms.MenuItem
        Me.menSalva = New System.Windows.Forms.MenuItem
        Me.line1 = New System.Windows.Forms.MenuItem
        Me.menstampa = New System.Windows.Forms.MenuItem
        Me.line2 = New System.Windows.Forms.MenuItem
        Me.menEsci = New System.Windows.Forms.MenuItem
        Me.O_S = New System.Windows.Forms.OpenFileDialog
        Me.S_S = New System.Windows.Forms.SaveFileDialog
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.Nuovo = New System.Windows.Forms.ToolBarButton
        Me.Apri = New System.Windows.Forms.ToolBarButton
        Me.Salva = New System.Windows.Forms.ToolBarButton
        Me.Stampa = New System.Windows.Forms.ToolBarButton
        Me.Esci = New System.Windows.Forms.ToolBarButton
        Me.ToolBarImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Frame4.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Commento.SuspendLayout()
        Me.Tipocalc.SuspendLayout()
        Me.Sistema.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_2.Image = CType(resources.GetObject("_Command1_2.Image"), System.Drawing.Image)
        Me._Command1_2.Location = New System.Drawing.Point(280, 192)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(22, 22)
        Me._Command1_2.TabIndex = 57
        Me._Command1_2.TabStop = False
        Me._Command1_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._Command1_2, "Richiama la libreria tiranti")
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_1.Image = CType(resources.GetObject("_Command1_1.Image"), System.Drawing.Image)
        Me._Command1_1.Location = New System.Drawing.Point(280, 144)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(22, 22)
        Me._Command1_1.TabIndex = 43
        Me._Command1_1.TabStop = False
        Me._Command1_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._Command1_1, "Richiama la libreria materiali")
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_0.Image = CType(resources.GetObject("_Command1_0.Image"), System.Drawing.Image)
        Me._Command1_0.Location = New System.Drawing.Point(280, 56)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(22, 22)
        Me._Command1_0.TabIndex = 31
        Me._Command1_0.TabStop = False
        Me._Command1_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._Command1_0, "Richiama la libreria guarnizioni")
        '
        'cmdDone
        '
        Me.cmdDone.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDone.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDone.Location = New System.Drawing.Point(192, 72)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDone.Size = New System.Drawing.Size(121, 33)
        Me.cmdDone.TabIndex = 109
        Me.cmdDone.Text = "Approvato"
        Me.cmdDone.Visible = False
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me._Text_29)
        Me.Frame4.Controls.Add(Me._Text_28)
        Me.Frame4.Controls.Add(Me._Coeff_1)
        Me.Frame4.Controls.Add(Me._Coeff_0)
        Me.Frame4.Controls.Add(Me._Text_27)
        Me.Frame4.Controls.Add(Me._Text_10)
        Me.Frame4.Controls.Add(Me._Text_11)
        Me.Frame4.Controls.Add(Me._Text_26)
        Me.Frame4.Controls.Add(Me._Label_33)
        Me.Frame4.Controls.Add(Me._lblMis_29)
        Me.Frame4.Controls.Add(Me._Label_32)
        Me.Frame4.Controls.Add(Me._Label_9)
        Me.Frame4.Controls.Add(Me._Label_10)
        Me.Frame4.Controls.Add(Me._lblMis_27)
        Me.Frame4.Controls.Add(Me._Label_31)
        Me.Frame4.Controls.Add(Me._lblMis_10)
        Me.Frame4.Controls.Add(Me._Label_14)
        Me.Frame4.Controls.Add(Me._Label_15)
        Me.Frame4.Controls.Add(Me._lblMis_11)
        Me.Frame4.Controls.Add(Me._Label_30)
        Me.Frame4.ForeColor = System.Drawing.Color.Blue
        Me.Frame4.Location = New System.Drawing.Point(320, 240)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(289, 177)
        Me.Frame4.TabIndex = 86
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Serraggio con chiave / verricello"
        '
        '_Text_29
        '
        Me._Text_29.AcceptsReturn = True
        Me._Text_29.AutoSize = False
        Me._Text_29.BackColor = System.Drawing.Color.Yellow
        Me._Text_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_29.Location = New System.Drawing.Point(168, 131)
        Me._Text_29.MaxLength = 0
        Me._Text_29.Name = "_Text_29"
        Me._Text_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_29.Size = New System.Drawing.Size(65, 19)
        Me._Text_29.TabIndex = 103
        Me._Text_29.TabStop = False
        Me._Text_29.Tag = "fl"
        Me._Text_29.Text = ""
        '
        '_Text_28
        '
        Me._Text_28.AcceptsReturn = True
        Me._Text_28.AutoSize = False
        Me._Text_28.BackColor = System.Drawing.Color.Yellow
        Me._Text_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_28.Location = New System.Drawing.Point(168, 115)
        Me._Text_28.MaxLength = 0
        Me._Text_28.Name = "_Text_28"
        Me._Text_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_28.Size = New System.Drawing.Size(65, 19)
        Me._Text_28.TabIndex = 101
        Me._Text_28.TabStop = False
        Me._Text_28.Text = ""
        '
        '_Coeff_1
        '
        Me._Coeff_1.BackColor = System.Drawing.SystemColors.Window
        Me._Coeff_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Coeff_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Coeff_1.Location = New System.Drawing.Point(144, 96)
        Me._Coeff_1.Name = "_Coeff_1"
        Me._Coeff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Coeff_1.Size = New System.Drawing.Size(137, 21)
        Me._Coeff_1.TabIndex = 97
        Me._Coeff_1.TabStop = False
        '
        '_Coeff_0
        '
        Me._Coeff_0.BackColor = System.Drawing.SystemColors.Window
        Me._Coeff_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Coeff_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Coeff_0.Location = New System.Drawing.Point(144, 80)
        Me._Coeff_0.Name = "_Coeff_0"
        Me._Coeff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Coeff_0.Size = New System.Drawing.Size(137, 21)
        Me._Coeff_0.TabIndex = 98
        Me._Coeff_0.TabStop = False
        '
        '_Text_27
        '
        Me._Text_27.AcceptsReturn = True
        Me._Text_27.AutoSize = False
        Me._Text_27.BackColor = System.Drawing.Color.Yellow
        Me._Text_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_27.Location = New System.Drawing.Point(168, 64)
        Me._Text_27.MaxLength = 0
        Me._Text_27.Name = "_Text_27"
        Me._Text_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_27.Size = New System.Drawing.Size(65, 19)
        Me._Text_27.TabIndex = 94
        Me._Text_27.TabStop = False
        Me._Text_27.Tag = "l"
        Me._Text_27.Text = ""
        '
        '_Text_10
        '
        Me._Text_10.AcceptsReturn = True
        Me._Text_10.AutoSize = False
        Me._Text_10.BackColor = System.Drawing.Color.Yellow
        Me._Text_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_10.Location = New System.Drawing.Point(168, 48)
        Me._Text_10.MaxLength = 0
        Me._Text_10.Name = "_Text_10"
        Me._Text_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_10.Size = New System.Drawing.Size(65, 19)
        Me._Text_10.TabIndex = 91
        Me._Text_10.TabStop = False
        Me._Text_10.Tag = "passo"
        Me._Text_10.Text = ""
        '
        '_Text_11
        '
        Me._Text_11.AcceptsReturn = True
        Me._Text_11.AutoSize = False
        Me._Text_11.BackColor = System.Drawing.Color.Yellow
        Me._Text_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_11.Location = New System.Drawing.Point(168, 32)
        Me._Text_11.MaxLength = 0
        Me._Text_11.Name = "_Text_11"
        Me._Text_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_11.Size = New System.Drawing.Size(65, 19)
        Me._Text_11.TabIndex = 88
        Me._Text_11.TabStop = False
        Me._Text_11.Tag = "l"
        Me._Text_11.Text = ""
        '
        '_Text_26
        '
        Me._Text_26.AcceptsReturn = True
        Me._Text_26.AutoSize = False
        Me._Text_26.BackColor = System.Drawing.Color.White
        Me._Text_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_26.Location = New System.Drawing.Point(168, 16)
        Me._Text_26.MaxLength = 0
        Me._Text_26.Name = "_Text_26"
        Me._Text_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_26.Size = New System.Drawing.Size(65, 19)
        Me._Text_26.TabIndex = 11
        Me._Text_26.Text = ""
        '
        '_Label_33
        '
        Me._Label_33.AutoSize = True
        Me._Label_33.BackColor = System.Drawing.SystemColors.Control
        Me._Label_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_33.Location = New System.Drawing.Point(8, 128)
        Me._Label_33.Name = "_Label_33"
        Me._Label_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_33.Size = New System.Drawing.Size(102, 16)
        Me._Label_33.TabIndex = 105
        Me._Label_33.Text = "Coppia di serraggio"
        '
        '_lblMis_29
        '
        Me._lblMis_29.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_29.Location = New System.Drawing.Point(240, 131)
        Me._lblMis_29.Name = "_lblMis_29"
        Me._lblMis_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_29.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_29.TabIndex = 104
        Me._lblMis_29.Text = "Label2"
        '
        '_Label_32
        '
        Me._Label_32.AutoSize = True
        Me._Label_32.BackColor = System.Drawing.SystemColors.Control
        Me._Label_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_32.Location = New System.Drawing.Point(8, 112)
        Me._Label_32.Name = "_Label_32"
        Me._Label_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_32.Size = New System.Drawing.Size(128, 16)
        Me._Label_32.TabIndex = 102
        Me._Label_32.Text = "Fattore globale di coppia"
        '
        '_Label_9
        '
        Me._Label_9.AutoSize = True
        Me._Label_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_9.Location = New System.Drawing.Point(8, 80)
        Me._Label_9.Name = "_Label_9"
        Me._Label_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_9.Size = New System.Drawing.Size(144, 16)
        Me._Label_9.TabIndex = 100
        Me._Label_9.Text = "Coeff. attrito dado-appoggio"
        '
        '_Label_10
        '
        Me._Label_10.AutoSize = True
        Me._Label_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_10.Location = New System.Drawing.Point(8, 96)
        Me._Label_10.Name = "_Label_10"
        Me._Label_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_10.Size = New System.Drawing.Size(115, 16)
        Me._Label_10.TabIndex = 99
        Me._Label_10.Text = "Coeff. attrito vite-dado"
        '
        '_lblMis_27
        '
        Me._lblMis_27.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_27.Location = New System.Drawing.Point(240, 64)
        Me._lblMis_27.Name = "_lblMis_27"
        Me._lblMis_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_27.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_27.TabIndex = 96
        Me._lblMis_27.Text = "Label2"
        '
        '_Label_31
        '
        Me._Label_31.AutoSize = True
        Me._Label_31.BackColor = System.Drawing.SystemColors.Control
        Me._Label_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_31.Location = New System.Drawing.Point(8, 64)
        Me._Label_31.Name = "_Label_31"
        Me._Label_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_31.Size = New System.Drawing.Size(112, 16)
        Me._Label_31.TabIndex = 95
        Me._Label_31.Text = "Apertura chiave dado"
        '
        '_lblMis_10
        '
        Me._lblMis_10.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_10.Location = New System.Drawing.Point(240, 48)
        Me._lblMis_10.Name = "_lblMis_10"
        Me._lblMis_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_10.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_10.TabIndex = 93
        Me._lblMis_10.Text = "Label2"
        '
        '_Label_14
        '
        Me._Label_14.AutoSize = True
        Me._Label_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_14.Location = New System.Drawing.Point(8, 48)
        Me._Label_14.Name = "_Label_14"
        Me._Label_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_14.Size = New System.Drawing.Size(85, 16)
        Me._Label_14.TabIndex = 92
        Me._Label_14.Text = "Passo filettatura"
        '
        '_Label_15
        '
        Me._Label_15.AutoSize = True
        Me._Label_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_15.Location = New System.Drawing.Point(8, 32)
        Me._Label_15.Name = "_Label_15"
        Me._Label_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_15.Size = New System.Drawing.Size(134, 16)
        Me._Label_15.TabIndex = 90
        Me._Label_15.Text = "Diametro medio filettatura"
        '
        '_lblMis_11
        '
        Me._lblMis_11.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_11.Location = New System.Drawing.Point(240, 32)
        Me._lblMis_11.Name = "_lblMis_11"
        Me._lblMis_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_11.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_11.TabIndex = 89
        Me._lblMis_11.Text = "Label2"
        '
        '_Label_30
        '
        Me._Label_30.AutoSize = True
        Me._Label_30.BackColor = System.Drawing.SystemColors.Control
        Me._Label_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_30.Location = New System.Drawing.Point(8, 16)
        Me._Label_30.Name = "_Label_30"
        Me._Label_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_30.Size = New System.Drawing.Size(136, 16)
        Me._Label_30.TabIndex = 87
        Me._Label_30.Text = "Fattore di disuniformità K2"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me._Text_25)
        Me.Frame3.Controls.Add(Me._Text_24)
        Me.Frame3.Controls.Add(Me._Text_22)
        Me.Frame3.Controls.Add(Me._Text_23)
        Me.Frame3.Controls.Add(Me._Text_21)
        Me.Frame3.Controls.Add(Me._Label_29)
        Me.Frame3.Controls.Add(Me._lblMis_25)
        Me.Frame3.Controls.Add(Me._lblMis_24)
        Me.Frame3.Controls.Add(Me._Label_28)
        Me.Frame3.Controls.Add(Me._Label_27)
        Me.Frame3.Controls.Add(Me._Label_26)
        Me.Frame3.Controls.Add(Me._lblMis_22)
        Me.Frame3.Controls.Add(Me._Label_25)
        Me.Frame3.ForeColor = System.Drawing.Color.Blue
        Me.Frame3.Location = New System.Drawing.Point(320, 128)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(289, 105)
        Me.Frame3.TabIndex = 75
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Serraggio con martinetto idraulico assiale"
        '
        '_Text_25
        '
        Me._Text_25.AcceptsReturn = True
        Me._Text_25.AutoSize = False
        Me._Text_25.BackColor = System.Drawing.Color.Yellow
        Me._Text_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_25.Location = New System.Drawing.Point(168, 80)
        Me._Text_25.MaxLength = 0
        Me._Text_25.Name = "_Text_25"
        Me._Text_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_25.Size = New System.Drawing.Size(65, 19)
        Me._Text_25.TabIndex = 85
        Me._Text_25.TabStop = False
        Me._Text_25.Tag = "pamm"
        Me._Text_25.Text = ""
        '
        '_Text_24
        '
        Me._Text_24.AcceptsReturn = True
        Me._Text_24.AutoSize = False
        Me._Text_24.BackColor = System.Drawing.Color.White
        Me._Text_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_24.Location = New System.Drawing.Point(168, 64)
        Me._Text_24.MaxLength = 0
        Me._Text_24.Name = "_Text_24"
        Me._Text_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_24.Size = New System.Drawing.Size(65, 19)
        Me._Text_24.TabIndex = 10
        Me._Text_24.Tag = "l2"
        Me._Text_24.Text = ""
        '
        '_Text_22
        '
        Me._Text_22.AcceptsReturn = True
        Me._Text_22.AutoSize = False
        Me._Text_22.BackColor = System.Drawing.Color.Yellow
        Me._Text_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_22.Location = New System.Drawing.Point(168, 48)
        Me._Text_22.MaxLength = 0
        Me._Text_22.Name = "_Text_22"
        Me._Text_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_22.Size = New System.Drawing.Size(65, 19)
        Me._Text_22.TabIndex = 79
        Me._Text_22.TabStop = False
        Me._Text_22.Tag = "f"
        Me._Text_22.Text = ""
        '
        '_Text_23
        '
        Me._Text_23.AcceptsReturn = True
        Me._Text_23.AutoSize = False
        Me._Text_23.BackColor = System.Drawing.Color.White
        Me._Text_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_23.Location = New System.Drawing.Point(168, 32)
        Me._Text_23.MaxLength = 0
        Me._Text_23.Name = "_Text_23"
        Me._Text_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_23.Size = New System.Drawing.Size(65, 19)
        Me._Text_23.TabIndex = 9
        Me._Text_23.Text = ""
        '
        '_Text_21
        '
        Me._Text_21.AcceptsReturn = True
        Me._Text_21.AutoSize = False
        Me._Text_21.BackColor = System.Drawing.Color.White
        Me._Text_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_21.Location = New System.Drawing.Point(168, 16)
        Me._Text_21.MaxLength = 0
        Me._Text_21.Name = "_Text_21"
        Me._Text_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_21.Size = New System.Drawing.Size(65, 19)
        Me._Text_21.TabIndex = 8
        Me._Text_21.Text = ""
        '
        '_Label_29
        '
        Me._Label_29.AutoSize = True
        Me._Label_29.BackColor = System.Drawing.SystemColors.Control
        Me._Label_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_29.Location = New System.Drawing.Point(8, 80)
        Me._Label_29.Name = "_Label_29"
        Me._Label_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_29.Size = New System.Drawing.Size(143, 16)
        Me._Label_29.TabIndex = 84
        Me._Label_29.Text = "Pressione centrale idraulica"
        '
        '_lblMis_25
        '
        Me._lblMis_25.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_25.Location = New System.Drawing.Point(240, 80)
        Me._lblMis_25.Name = "_lblMis_25"
        Me._lblMis_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_25.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_25.TabIndex = 83
        Me._lblMis_25.Text = "Label2"
        '
        '_lblMis_24
        '
        Me._lblMis_24.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_24.Location = New System.Drawing.Point(240, 64)
        Me._lblMis_24.Name = "_lblMis_24"
        Me._lblMis_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_24.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_24.TabIndex = 82
        Me._lblMis_24.Text = "Label2"
        '
        '_Label_28
        '
        Me._Label_28.AutoSize = True
        Me._Label_28.BackColor = System.Drawing.SystemColors.Control
        Me._Label_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_28.Location = New System.Drawing.Point(8, 64)
        Me._Label_28.Name = "_Label_28"
        Me._Label_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_28.Size = New System.Drawing.Size(110, 16)
        Me._Label_28.TabIndex = 81
        Me._Label_28.Text = "Sezione retta pistone"
        '
        '_Label_27
        '
        Me._Label_27.AutoSize = True
        Me._Label_27.BackColor = System.Drawing.SystemColors.Control
        Me._Label_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_27.Location = New System.Drawing.Point(8, 32)
        Me._Label_27.Name = "_Label_27"
        Me._Label_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_27.Size = New System.Drawing.Size(136, 16)
        Me._Label_27.TabIndex = 80
        Me._Label_27.Text = "Fattore di rilassamento K3"
        '
        '_Label_26
        '
        Me._Label_26.AutoSize = True
        Me._Label_26.BackColor = System.Drawing.SystemColors.Control
        Me._Label_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_26.Location = New System.Drawing.Point(8, 48)
        Me._Label_26.Name = "_Label_26"
        Me._Label_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_26.Size = New System.Drawing.Size(118, 16)
        Me._Label_26.TabIndex = 78
        Me._Label_26.Text = "Carico sotto martinetto"
        '
        '_lblMis_22
        '
        Me._lblMis_22.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_22.Location = New System.Drawing.Point(240, 48)
        Me._lblMis_22.Name = "_lblMis_22"
        Me._lblMis_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_22.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_22.TabIndex = 77
        Me._lblMis_22.Text = "Label2"
        '
        '_Label_25
        '
        Me._Label_25.AutoSize = True
        Me._Label_25.BackColor = System.Drawing.SystemColors.Control
        Me._Label_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_25.Location = New System.Drawing.Point(8, 16)
        Me._Label_25.Name = "_Label_25"
        Me._Label_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_25.Size = New System.Drawing.Size(136, 16)
        Me._Label_25.TabIndex = 76
        Me._Label_25.Text = "Fattore di disuniformità K2"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._Text_20)
        Me.Frame2.Controls.Add(Me._Text_19)
        Me.Frame2.Controls.Add(Me._Text_18)
        Me.Frame2.Controls.Add(Me._Text_17)
        Me.Frame2.Controls.Add(Me._Label_24)
        Me.Frame2.Controls.Add(Me._lblMis_20)
        Me.Frame2.Controls.Add(Me._Label_23)
        Me.Frame2.Controls.Add(Me._Label_22)
        Me.Frame2.Controls.Add(Me._lblMis_18)
        Me.Frame2.Controls.Add(Me._Label_11)
        Me.Frame2.Controls.Add(Me._lblMis_17)
        Me.Frame2.ForeColor = System.Drawing.Color.Blue
        Me.Frame2.Location = New System.Drawing.Point(320, 32)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(289, 89)
        Me.Frame2.TabIndex = 65
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Carico su un tirante per la tenuta in P.I."
        '
        '_Text_20
        '
        Me._Text_20.AcceptsReturn = True
        Me._Text_20.AutoSize = False
        Me._Text_20.BackColor = System.Drawing.Color.Yellow
        Me._Text_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_20.Location = New System.Drawing.Point(168, 64)
        Me._Text_20.MaxLength = 0
        Me._Text_20.Name = "_Text_20"
        Me._Text_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_20.Size = New System.Drawing.Size(65, 19)
        Me._Text_20.TabIndex = 74
        Me._Text_20.TabStop = False
        Me._Text_20.Tag = "f"
        Me._Text_20.Text = ""
        '
        '_Text_19
        '
        Me._Text_19.AcceptsReturn = True
        Me._Text_19.AutoSize = False
        Me._Text_19.BackColor = System.Drawing.Color.White
        Me._Text_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_19.Location = New System.Drawing.Point(168, 48)
        Me._Text_19.MaxLength = 0
        Me._Text_19.Name = "_Text_19"
        Me._Text_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_19.Size = New System.Drawing.Size(65, 19)
        Me._Text_19.TabIndex = 7
        Me._Text_19.Text = ""
        '
        '_Text_18
        '
        Me._Text_18.AcceptsReturn = True
        Me._Text_18.AutoSize = False
        Me._Text_18.BackColor = System.Drawing.Color.Yellow
        Me._Text_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_18.Location = New System.Drawing.Point(168, 32)
        Me._Text_18.MaxLength = 0
        Me._Text_18.Name = "_Text_18"
        Me._Text_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_18.Size = New System.Drawing.Size(65, 19)
        Me._Text_18.TabIndex = 70
        Me._Text_18.TabStop = False
        Me._Text_18.Tag = "f"
        Me._Text_18.Text = ""
        '
        '_Text_17
        '
        Me._Text_17.AcceptsReturn = True
        Me._Text_17.AutoSize = False
        Me._Text_17.BackColor = System.Drawing.Color.White
        Me._Text_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_17.Location = New System.Drawing.Point(168, 16)
        Me._Text_17.MaxLength = 0
        Me._Text_17.Name = "_Text_17"
        Me._Text_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_17.Size = New System.Drawing.Size(65, 19)
        Me._Text_17.TabIndex = 6
        Me._Text_17.Tag = "p"
        Me._Text_17.Text = ""
        '
        '_Label_24
        '
        Me._Label_24.AutoSize = True
        Me._Label_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_24.Location = New System.Drawing.Point(8, 64)
        Me._Label_24.Name = "_Label_24"
        Me._Label_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_24.Size = New System.Drawing.Size(157, 16)
        Me._Label_24.TabIndex = 73
        Me._Label_24.Text = "Carico obiettivo a vuoto K1* W"
        '
        '_lblMis_20
        '
        Me._lblMis_20.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_20.Location = New System.Drawing.Point(240, 64)
        Me._lblMis_20.Name = "_lblMis_20"
        Me._lblMis_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_20.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_20.TabIndex = 72
        Me._lblMis_20.Text = "Label2"
        '
        '_Label_23
        '
        Me._Label_23.AutoSize = True
        Me._Label_23.BackColor = System.Drawing.SystemColors.Control
        Me._Label_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_23.Location = New System.Drawing.Point(8, 48)
        Me._Label_23.Name = "_Label_23"
        Me._Label_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_23.Size = New System.Drawing.Size(139, 16)
        Me._Label_23.TabIndex = 71
        Me._Label_23.Text = "Fattore di rilassamento  K1"
        '
        '_Label_22
        '
        Me._Label_22.AutoSize = True
        Me._Label_22.BackColor = System.Drawing.SystemColors.Control
        Me._Label_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_22.Location = New System.Drawing.Point(8, 32)
        Me._Label_22.Name = "_Label_22"
        Me._Label_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_22.Size = New System.Drawing.Size(127, 16)
        Me._Label_22.TabIndex = 69
        Me._Label_22.Text = "Carico teorico minimo W"
        '
        '_lblMis_18
        '
        Me._lblMis_18.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_18.Location = New System.Drawing.Point(240, 32)
        Me._lblMis_18.Name = "_lblMis_18"
        Me._lblMis_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_18.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_18.TabIndex = 68
        Me._lblMis_18.Text = "Label2"
        '
        '_Label_11
        '
        Me._Label_11.AutoSize = True
        Me._Label_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_11.Location = New System.Drawing.Point(8, 16)
        Me._Label_11.Name = "_Label_11"
        Me._Label_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_11.Size = New System.Drawing.Size(143, 16)
        Me._Label_11.TabIndex = 67
        Me._Label_11.Text = "Pressione di prova idraulica"
        '
        '_lblMis_17
        '
        Me._lblMis_17.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_17.Location = New System.Drawing.Point(240, 16)
        Me._lblMis_17.Name = "_lblMis_17"
        Me._lblMis_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_17.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_17.TabIndex = 66
        Me._lblMis_17.Text = "Label2"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._Text_32)
        Me.Frame1.Controls.Add(Me._Text_0)
        Me.Frame1.Controls.Add(Me._Text_6)
        Me.Frame1.Controls.Add(Me._Text_5)
        Me.Frame1.Controls.Add(Me._Text_8)
        Me.Frame1.Controls.Add(Me._Text_9)
        Me.Frame1.Controls.Add(Me._Text_7)
        Me.Frame1.Controls.Add(Me._Text_14)
        Me.Frame1.Controls.Add(Me._Text_31)
        Me.Frame1.Controls.Add(Me._Text_13)
        Me.Frame1.Controls.Add(Me._Text_12)
        Me.Frame1.Controls.Add(Me._Text_3)
        Me.Frame1.Controls.Add(Me._Text_16)
        Me.Frame1.Controls.Add(Me._Text_1)
        Me.Frame1.Controls.Add(Me._Command1_2)
        Me.Frame1.Controls.Add(Me._Text_15)
        Me.Frame1.Controls.Add(Me._Command1_1)
        Me.Frame1.Controls.Add(Me._Text_30)
        Me.Frame1.Controls.Add(Me._Text_2)
        Me.Frame1.Controls.Add(Me._Command1_0)
        Me.Frame1.Controls.Add(Me._Text_4)
        Me.Frame1.Controls.Add(Me._Label_34)
        Me.Frame1.Controls.Add(Me._lblMis_32)
        Me.Frame1.Controls.Add(Me._lblMis_6)
        Me.Frame1.Controls.Add(Me._Label_6)
        Me.Frame1.Controls.Add(Me._lblMis_5)
        Me.Frame1.Controls.Add(Me._Label_5)
        Me.Frame1.Controls.Add(Me._Label_8)
        Me.Frame1.Controls.Add(Me._Label_7)
        Me.Frame1.Controls.Add(Me._lblMis_9)
        Me.Frame1.Controls.Add(Me._Label_13)
        Me.Frame1.Controls.Add(Me._Label_21)
        Me.Frame1.Controls.Add(Me._Label_20)
        Me.Frame1.Controls.Add(Me._lblMis_15)
        Me.Frame1.Controls.Add(Me._lblMis_14)
        Me.Frame1.Controls.Add(Me._Label_19)
        Me.Frame1.Controls.Add(Me._Label_18)
        Me.Frame1.Controls.Add(Me._Label_17)
        Me.Frame1.Controls.Add(Me._lblMis_13)
        Me.Frame1.Controls.Add(Me._Label_16)
        Me.Frame1.Controls.Add(Me._lblMis_12)
        Me.Frame1.Controls.Add(Me._Label_2)
        Me.Frame1.Controls.Add(Me._Label_3)
        Me.Frame1.Controls.Add(Me._lblMis_2)
        Me.Frame1.Controls.Add(Me._lblMis_3)
        Me.Frame1.Controls.Add(Me._Label_4)
        Me.Frame1.Controls.Add(Me._Label_0)
        Me.Frame1.Controls.Add(Me._Label_12)
        Me.Frame1.Controls.Add(Me._lblMis_0)
        Me.Frame1.Controls.Add(Me._Label_1)
        Me.Frame1.Controls.Add(Me._lblMis_1)
        Me.Frame1.ForeColor = System.Drawing.Color.Blue
        Me.Frame1.Location = New System.Drawing.Point(0, 112)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(313, 305)
        Me.Frame1.TabIndex = 22
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Carichi tiranti a codice"
        '
        '_Text_32
        '
        Me._Text_32.AcceptsReturn = True
        Me._Text_32.AutoSize = False
        Me._Text_32.BackColor = System.Drawing.Color.Yellow
        Me._Text_32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_32.Enabled = False
        Me._Text_32.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_32.Location = New System.Drawing.Point(168, 272)
        Me._Text_32.MaxLength = 0
        Me._Text_32.Name = "_Text_32"
        Me._Text_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_32.Size = New System.Drawing.Size(65, 19)
        Me._Text_32.TabIndex = 106
        Me._Text_32.TabStop = False
        Me._Text_32.Tag = "f"
        Me._Text_32.Text = ""
        '
        '_Text_0
        '
        Me._Text_0.AcceptsReturn = True
        Me._Text_0.AutoSize = False
        Me._Text_0.BackColor = System.Drawing.Color.White
        Me._Text_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_0.Location = New System.Drawing.Point(168, 32)
        Me._Text_0.MaxLength = 0
        Me._Text_0.Name = "_Text_0"
        Me._Text_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_0.Size = New System.Drawing.Size(65, 19)
        Me._Text_0.TabIndex = 1
        Me._Text_0.Tag = "t"
        Me._Text_0.Text = ""
        '
        '_Text_6
        '
        Me._Text_6.AcceptsReturn = True
        Me._Text_6.AutoSize = False
        Me._Text_6.BackColor = System.Drawing.Color.Yellow
        Me._Text_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_6.Location = New System.Drawing.Point(168, 256)
        Me._Text_6.MaxLength = 0
        Me._Text_6.Name = "_Text_6"
        Me._Text_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_6.Size = New System.Drawing.Size(65, 19)
        Me._Text_6.TabIndex = 62
        Me._Text_6.TabStop = False
        Me._Text_6.Tag = "f"
        Me._Text_6.Text = ""
        '
        '_Text_5
        '
        Me._Text_5.AcceptsReturn = True
        Me._Text_5.AutoSize = False
        Me._Text_5.BackColor = System.Drawing.Color.Yellow
        Me._Text_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_5.Location = New System.Drawing.Point(168, 240)
        Me._Text_5.MaxLength = 0
        Me._Text_5.Name = "_Text_5"
        Me._Text_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_5.Size = New System.Drawing.Size(65, 19)
        Me._Text_5.TabIndex = 59
        Me._Text_5.TabStop = False
        Me._Text_5.Tag = "f"
        Me._Text_5.Text = ""
        '
        '_Text_8
        '
        Me._Text_8.AcceptsReturn = True
        Me._Text_8.AutoSize = False
        Me._Text_8.BackColor = System.Drawing.Color.White
        Me._Text_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_8.Location = New System.Drawing.Point(168, 224)
        Me._Text_8.MaxLength = 0
        Me._Text_8.Name = "_Text_8"
        Me._Text_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_8.Size = New System.Drawing.Size(65, 19)
        Me._Text_8.TabIndex = 5
        Me._Text_8.Text = ""
        '
        '_Text_9
        '
        Me._Text_9.AcceptsReturn = True
        Me._Text_9.AutoSize = False
        Me._Text_9.BackColor = System.Drawing.Color.Yellow
        Me._Text_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_9.Location = New System.Drawing.Point(168, 208)
        Me._Text_9.MaxLength = 0
        Me._Text_9.Name = "_Text_9"
        Me._Text_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_9.Size = New System.Drawing.Size(65, 19)
        Me._Text_9.TabIndex = 52
        Me._Text_9.TabStop = False
        Me._Text_9.Tag = "l"
        Me._Text_9.Text = ""
        '
        '_Text_7
        '
        Me._Text_7.AcceptsReturn = True
        Me._Text_7.AutoSize = False
        Me._Text_7.BackColor = System.Drawing.Color.Yellow
        Me._Text_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_7.Location = New System.Drawing.Point(168, 192)
        Me._Text_7.MaxLength = 0
        Me._Text_7.Name = "_Text_7"
        Me._Text_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_7.Size = New System.Drawing.Size(65, 19)
        Me._Text_7.TabIndex = 53
        Me._Text_7.TabStop = False
        Me._Text_7.Text = ""
        '
        '_Text_14
        '
        Me._Text_14.AcceptsReturn = True
        Me._Text_14.AutoSize = False
        Me._Text_14.BackColor = System.Drawing.Color.Yellow
        Me._Text_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_14.Location = New System.Drawing.Point(168, 176)
        Me._Text_14.MaxLength = 0
        Me._Text_14.Name = "_Text_14"
        Me._Text_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_14.Size = New System.Drawing.Size(65, 19)
        Me._Text_14.TabIndex = 45
        Me._Text_14.TabStop = False
        Me._Text_14.Tag = "pamm"
        Me._Text_14.Text = ""
        '
        '_Text_31
        '
        Me._Text_31.AcceptsReturn = True
        Me._Text_31.AutoSize = False
        Me._Text_31.BackColor = System.Drawing.Color.Yellow
        Me._Text_31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_31.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_31.Location = New System.Drawing.Point(96, 144)
        Me._Text_31.MaxLength = 0
        Me._Text_31.Name = "_Text_31"
        Me._Text_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_31.Size = New System.Drawing.Size(177, 19)
        Me._Text_31.TabIndex = 44
        Me._Text_31.TabStop = False
        Me._Text_31.Text = ""
        '
        '_Text_13
        '
        Me._Text_13.AcceptsReturn = True
        Me._Text_13.AutoSize = False
        Me._Text_13.BackColor = System.Drawing.Color.Yellow
        Me._Text_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_13.Location = New System.Drawing.Point(168, 128)
        Me._Text_13.MaxLength = 0
        Me._Text_13.Name = "_Text_13"
        Me._Text_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_13.Size = New System.Drawing.Size(65, 19)
        Me._Text_13.TabIndex = 38
        Me._Text_13.TabStop = False
        Me._Text_13.Tag = "p"
        Me._Text_13.Text = ""
        '
        '_Text_12
        '
        Me._Text_12.AcceptsReturn = True
        Me._Text_12.AutoSize = False
        Me._Text_12.BackColor = System.Drawing.Color.White
        Me._Text_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_12.Location = New System.Drawing.Point(168, 112)
        Me._Text_12.MaxLength = 0
        Me._Text_12.Name = "_Text_12"
        Me._Text_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_12.Size = New System.Drawing.Size(65, 19)
        Me._Text_12.TabIndex = 4
        Me._Text_12.Tag = "l"
        Me._Text_12.Text = ""
        '
        '_Text_3
        '
        Me._Text_3.AcceptsReturn = True
        Me._Text_3.AutoSize = False
        Me._Text_3.BackColor = System.Drawing.Color.White
        Me._Text_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_3.Location = New System.Drawing.Point(168, 96)
        Me._Text_3.MaxLength = 0
        Me._Text_3.Name = "_Text_3"
        Me._Text_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_3.Size = New System.Drawing.Size(65, 19)
        Me._Text_3.TabIndex = 3
        Me._Text_3.Tag = "l"
        Me._Text_3.Text = ""
        '
        '_Text_16
        '
        Me._Text_16.AcceptsReturn = True
        Me._Text_16.AutoSize = False
        Me._Text_16.BackColor = System.Drawing.Color.Yellow
        Me._Text_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_16.Location = New System.Drawing.Point(96, 64)
        Me._Text_16.MaxLength = 0
        Me._Text_16.Name = "_Text_16"
        Me._Text_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_16.Size = New System.Drawing.Size(177, 19)
        Me._Text_16.TabIndex = 27
        Me._Text_16.TabStop = False
        Me._Text_16.Text = ""
        '
        '_Text_1
        '
        Me._Text_1.AcceptsReturn = True
        Me._Text_1.AutoSize = False
        Me._Text_1.BackColor = System.Drawing.Color.White
        Me._Text_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_1.Location = New System.Drawing.Point(168, 16)
        Me._Text_1.MaxLength = 0
        Me._Text_1.Name = "_Text_1"
        Me._Text_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_1.Size = New System.Drawing.Size(65, 19)
        Me._Text_1.TabIndex = 0
        Me._Text_1.Tag = "p"
        Me._Text_1.Text = ""
        '
        '_Text_15
        '
        Me._Text_15.AcceptsReturn = True
        Me._Text_15.AutoSize = False
        Me._Text_15.BackColor = System.Drawing.Color.Yellow
        Me._Text_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_15.Location = New System.Drawing.Point(168, 160)
        Me._Text_15.MaxLength = 0
        Me._Text_15.Name = "_Text_15"
        Me._Text_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_15.Size = New System.Drawing.Size(65, 19)
        Me._Text_15.TabIndex = 46
        Me._Text_15.TabStop = False
        Me._Text_15.Tag = "pamm"
        Me._Text_15.Text = ""
        '
        '_Text_30
        '
        Me._Text_30.AcceptsReturn = True
        Me._Text_30.AutoSize = False
        Me._Text_30.BackColor = System.Drawing.Color.Yellow
        Me._Text_30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_30.Location = New System.Drawing.Point(72, 128)
        Me._Text_30.MaxLength = 0
        Me._Text_30.Name = "_Text_30"
        Me._Text_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_30.Size = New System.Drawing.Size(65, 19)
        Me._Text_30.TabIndex = 41
        Me._Text_30.TabStop = False
        Me._Text_30.Text = ""
        '
        '_Text_2
        '
        Me._Text_2.AcceptsReturn = True
        Me._Text_2.AutoSize = False
        Me._Text_2.BackColor = System.Drawing.Color.White
        Me._Text_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_2.Location = New System.Drawing.Point(168, 80)
        Me._Text_2.MaxLength = 0
        Me._Text_2.Name = "_Text_2"
        Me._Text_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_2.Size = New System.Drawing.Size(65, 19)
        Me._Text_2.TabIndex = 2
        Me._Text_2.Tag = "l"
        Me._Text_2.Text = ""
        '
        '_Text_4
        '
        Me._Text_4.AcceptsReturn = True
        Me._Text_4.AutoSize = False
        Me._Text_4.BackColor = System.Drawing.Color.Yellow
        Me._Text_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text_4.Location = New System.Drawing.Point(96, 48)
        Me._Text_4.MaxLength = 0
        Me._Text_4.Name = "_Text_4"
        Me._Text_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text_4.Size = New System.Drawing.Size(177, 19)
        Me._Text_4.TabIndex = 28
        Me._Text_4.TabStop = False
        Me._Text_4.Text = ""
        '
        '_Label_34
        '
        Me._Label_34.AutoSize = True
        Me._Label_34.BackColor = System.Drawing.SystemColors.Control
        Me._Label_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_34.Location = New System.Drawing.Point(8, 272)
        Me._Label_34.Name = "_Label_34"
        Me._Label_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_34.Size = New System.Drawing.Size(140, 16)
        Me._Label_34.TabIndex = 108
        Me._Label_34.Text = "Carico di progetto            W"
        '
        '_lblMis_32
        '
        Me._lblMis_32.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_32.Location = New System.Drawing.Point(240, 272)
        Me._lblMis_32.Name = "_lblMis_32"
        Me._lblMis_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_32.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_32.TabIndex = 107
        Me._lblMis_32.Text = "Label2"
        '
        '_lblMis_6
        '
        Me._lblMis_6.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_6.Location = New System.Drawing.Point(240, 256)
        Me._lblMis_6.Name = "_lblMis_6"
        Me._lblMis_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_6.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_6.TabIndex = 64
        Me._lblMis_6.Text = "Label2"
        '
        '_Label_6
        '
        Me._Label_6.AutoSize = True
        Me._Label_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_6.Location = New System.Drawing.Point(128, 256)
        Me._Label_6.Name = "_Label_6"
        Me._Label_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_6.Size = New System.Drawing.Size(31, 16)
        Me._Label_6.TabIndex = 63
        Me._Label_6.Text = "Wm2"
        '
        '_lblMis_5
        '
        Me._lblMis_5.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_5.Location = New System.Drawing.Point(240, 240)
        Me._lblMis_5.Name = "_lblMis_5"
        Me._lblMis_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_5.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_5.TabIndex = 61
        Me._lblMis_5.Text = "Label2"
        '
        '_Label_5
        '
        Me._Label_5.AutoSize = True
        Me._Label_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_5.Location = New System.Drawing.Point(128, 240)
        Me._Label_5.Name = "_Label_5"
        Me._Label_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_5.Size = New System.Drawing.Size(31, 16)
        Me._Label_5.TabIndex = 60
        Me._Label_5.Text = "Wm1"
        '
        '_Label_8
        '
        Me._Label_8.AutoSize = True
        Me._Label_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_8.Location = New System.Drawing.Point(8, 224)
        Me._Label_8.Name = "_Label_8"
        Me._Label_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_8.Size = New System.Drawing.Size(87, 16)
        Me._Label_8.TabIndex = 58
        Me._Label_8.Text = "Numero di tiranti"
        '
        '_Label_7
        '
        Me._Label_7.AutoSize = True
        Me._Label_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_7.Location = New System.Drawing.Point(8, 192)
        Me._Label_7.Name = "_Label_7"
        Me._Label_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_7.Size = New System.Drawing.Size(130, 16)
        Me._Label_7.TabIndex = 56
        Me._Label_7.Text = "Diametro nominale tiranti"
        '
        '_lblMis_9
        '
        Me._lblMis_9.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_9.Location = New System.Drawing.Point(240, 208)
        Me._lblMis_9.Name = "_lblMis_9"
        Me._lblMis_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_9.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_9.TabIndex = 55
        Me._lblMis_9.Text = "Label2"
        '
        '_Label_13
        '
        Me._Label_13.AutoSize = True
        Me._Label_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_13.Location = New System.Drawing.Point(8, 208)
        Me._Label_13.Name = "_Label_13"
        Me._Label_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_13.Size = New System.Drawing.Size(95, 16)
        Me._Label_13.TabIndex = 54
        Me._Label_13.Text = "Diametro nocciolo"
        '
        '_Label_21
        '
        Me._Label_21.AutoSize = True
        Me._Label_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_21.Location = New System.Drawing.Point(8, 160)
        Me._Label_21.Name = "_Label_21"
        Me._Label_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_21.Size = New System.Drawing.Size(163, 16)
        Me._Label_21.TabIndex = 51
        Me._Label_21.Text = "Soll. ammiss. tiranti temp. prog."
        '
        '_Label_20
        '
        Me._Label_20.AutoSize = True
        Me._Label_20.BackColor = System.Drawing.SystemColors.Control
        Me._Label_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_20.Location = New System.Drawing.Point(8, 144)
        Me._Label_20.Name = "_Label_20"
        Me._Label_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_20.Size = New System.Drawing.Size(82, 16)
        Me._Label_20.TabIndex = 50
        Me._Label_20.Text = "Materiale tiranti"
        '
        '_lblMis_15
        '
        Me._lblMis_15.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_15.Location = New System.Drawing.Point(240, 160)
        Me._lblMis_15.Name = "_lblMis_15"
        Me._lblMis_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_15.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_15.TabIndex = 49
        Me._lblMis_15.Text = "Label2"
        '
        '_lblMis_14
        '
        Me._lblMis_14.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_14.Location = New System.Drawing.Point(240, 176)
        Me._lblMis_14.Name = "_lblMis_14"
        Me._lblMis_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_14.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_14.TabIndex = 48
        Me._lblMis_14.Text = "Label2"
        '
        '_Label_19
        '
        Me._Label_19.AutoSize = True
        Me._Label_19.BackColor = System.Drawing.SystemColors.Control
        Me._Label_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_19.Location = New System.Drawing.Point(8, 176)
        Me._Label_19.Name = "_Label_19"
        Me._Label_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_19.Size = New System.Drawing.Size(162, 16)
        Me._Label_19.TabIndex = 47
        Me._Label_19.Text = "Soll. ammiss. tiranti temp. amb."
        '
        '_Label_18
        '
        Me._Label_18.AutoSize = True
        Me._Label_18.BackColor = System.Drawing.SystemColors.Control
        Me._Label_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_18.Location = New System.Drawing.Point(56, 128)
        Me._Label_18.Name = "_Label_18"
        Me._Label_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_18.Size = New System.Drawing.Size(14, 16)
        Me._Label_18.TabIndex = 42
        Me._Label_18.Text = "m"
        '
        '_Label_17
        '
        Me._Label_17.AutoSize = True
        Me._Label_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_17.Location = New System.Drawing.Point(152, 128)
        Me._Label_17.Name = "_Label_17"
        Me._Label_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_17.Size = New System.Drawing.Size(12, 16)
        Me._Label_17.TabIndex = 40
        Me._Label_17.Text = "Y"
        '
        '_lblMis_13
        '
        Me._lblMis_13.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_13.Location = New System.Drawing.Point(240, 128)
        Me._lblMis_13.Name = "_lblMis_13"
        Me._lblMis_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_13.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_13.TabIndex = 39
        Me._lblMis_13.Text = "Label2"
        '
        '_Label_16
        '
        Me._Label_16.AutoSize = True
        Me._Label_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_16.Location = New System.Drawing.Point(8, 112)
        Me._Label_16.Name = "_Label_16"
        Me._Label_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_16.Size = New System.Drawing.Size(94, 16)
        Me._Label_16.TabIndex = 37
        Me._Label_16.Text = "Larghezza nubbin"
        '
        '_lblMis_12
        '
        Me._lblMis_12.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_12.Location = New System.Drawing.Point(240, 112)
        Me._lblMis_12.Name = "_lblMis_12"
        Me._lblMis_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_12.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_12.TabIndex = 36
        Me._lblMis_12.Text = "Label2"
        '
        '_Label_2
        '
        Me._Label_2.AutoSize = True
        Me._Label_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_2.Location = New System.Drawing.Point(8, 80)
        Me._Label_2.Name = "_Label_2"
        Me._Label_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_2.Size = New System.Drawing.Size(153, 16)
        Me._Label_2.TabIndex = 35
        Me._Label_2.Text = "Diametro esterno guarnizione"
        '
        '_Label_3
        '
        Me._Label_3.AutoSize = True
        Me._Label_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_3.Location = New System.Drawing.Point(8, 96)
        Me._Label_3.Name = "_Label_3"
        Me._Label_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_3.Size = New System.Drawing.Size(119, 16)
        Me._Label_3.TabIndex = 34
        Me._Label_3.Text = "Larghezza guarnizione"
        '
        '_lblMis_2
        '
        Me._lblMis_2.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_2.Location = New System.Drawing.Point(240, 80)
        Me._lblMis_2.Name = "_lblMis_2"
        Me._lblMis_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_2.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_2.TabIndex = 33
        Me._lblMis_2.Text = "Label2"
        '
        '_lblMis_3
        '
        Me._lblMis_3.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_3.Location = New System.Drawing.Point(240, 96)
        Me._lblMis_3.Name = "_lblMis_3"
        Me._lblMis_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_3.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_3.TabIndex = 32
        Me._lblMis_3.Text = "Label2"
        '
        '_Label_4
        '
        Me._Label_4.AutoSize = True
        Me._Label_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_4.Location = New System.Drawing.Point(8, 48)
        Me._Label_4.Name = "_Label_4"
        Me._Label_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_4.Size = New System.Drawing.Size(88, 16)
        Me._Label_4.TabIndex = 30
        Me._Label_4.Text = "Tipo guarnizione"
        '
        '_Label_0
        '
        Me._Label_0.AutoSize = True
        Me._Label_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_0.Location = New System.Drawing.Point(8, 64)
        Me._Label_0.Name = "_Label_0"
        Me._Label_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_0.Size = New System.Drawing.Size(88, 16)
        Me._Label_0.TabIndex = 29
        Me._Label_0.Text = "Mat. guarnizione"
        '
        '_Label_12
        '
        Me._Label_12.AutoSize = True
        Me._Label_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_12.Location = New System.Drawing.Point(8, 32)
        Me._Label_12.Name = "_Label_12"
        Me._Label_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_12.Size = New System.Drawing.Size(128, 16)
        Me._Label_12.TabIndex = 26
        Me._Label_12.Text = "Temperatura di progetto "
        '
        '_lblMis_0
        '
        Me._lblMis_0.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_0.Location = New System.Drawing.Point(240, 32)
        Me._lblMis_0.Name = "_lblMis_0"
        Me._lblMis_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_0.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_0.TabIndex = 25
        Me._lblMis_0.Text = "Label2"
        '
        '_Label_1
        '
        Me._Label_1.AutoSize = True
        Me._Label_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label_1.Location = New System.Drawing.Point(8, 16)
        Me._Label_1.Name = "_Label_1"
        Me._Label_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label_1.Size = New System.Drawing.Size(114, 16)
        Me._Label_1.TabIndex = 24
        Me._Label_1.Text = "Pressione di progetto "
        '
        '_lblMis_1
        '
        Me._lblMis_1.BackColor = System.Drawing.Color.Cyan
        Me._lblMis_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMis_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMis_1.Location = New System.Drawing.Point(240, 16)
        Me._lblMis_1.Name = "_lblMis_1"
        Me._lblMis_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMis_1.Size = New System.Drawing.Size(40, 17)
        Me._lblMis_1.TabIndex = 23
        Me._lblMis_1.Text = "Label2"
        '
        'Commento
        '
        Me.Commento.BackColor = System.Drawing.SystemColors.Control
        Me.Commento.Controls.Add(Me.Labelcom1)
        Me.Commento.ForeColor = System.Drawing.Color.Blue
        Me.Commento.Location = New System.Drawing.Point(0, 416)
        Me.Commento.Name = "Commento"
        Me.Commento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Commento.Size = New System.Drawing.Size(609, 73)
        Me.Commento.TabIndex = 18
        Me.Commento.TabStop = False
        Me.Commento.Text = "Situazione del calcolo"
        '
        'Labelcom1
        '
        Me.Labelcom1.BackColor = System.Drawing.SystemColors.Control
        Me.Labelcom1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labelcom1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labelcom1.Location = New System.Drawing.Point(8, 16)
        Me.Labelcom1.Name = "Labelcom1"
        Me.Labelcom1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labelcom1.Size = New System.Drawing.Size(585, 49)
        Me.Labelcom1.TabIndex = 19
        '
        'Tipocalc
        '
        Me.Tipocalc.BackColor = System.Drawing.SystemColors.Control
        Me.Tipocalc.Controls.Add(Me._calcasme_1)
        Me.Tipocalc.Controls.Add(Me._calcasme_0)
        Me.Tipocalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tipocalc.Location = New System.Drawing.Point(160, 32)
        Me.Tipocalc.Name = "Tipocalc"
        Me.Tipocalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tipocalc.Size = New System.Drawing.Size(121, 57)
        Me.Tipocalc.TabIndex = 17
        Me.Tipocalc.TabStop = False
        Me.Tipocalc.Text = "Tipo di calcolo"
        '
        '_calcasme_1
        '
        Me._calcasme_1.BackColor = System.Drawing.SystemColors.Control
        Me._calcasme_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._calcasme_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._calcasme_1.Location = New System.Drawing.Point(8, 32)
        Me._calcasme_1.Name = "_calcasme_1"
        Me._calcasme_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._calcasme_1.Size = New System.Drawing.Size(73, 17)
        Me._calcasme_1.TabIndex = 15
        Me._calcasme_1.Text = "ISPESL"
        '
        '_calcasme_0
        '
        Me._calcasme_0.BackColor = System.Drawing.SystemColors.Control
        Me._calcasme_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._calcasme_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._calcasme_0.Location = New System.Drawing.Point(8, 16)
        Me._calcasme_0.Name = "_calcasme_0"
        Me._calcasme_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._calcasme_0.Size = New System.Drawing.Size(57, 17)
        Me._calcasme_0.TabIndex = 14
        Me._calcasme_0.Text = "ASME"
        '
        'Sistema
        '
        Me.Sistema.BackColor = System.Drawing.SystemColors.Control
        Me.Sistema.Controls.Add(Me._SysInter_2)
        Me.Sistema.Controls.Add(Me._SysInter_1)
        Me.Sistema.Controls.Add(Me._SysInter_0)
        Me.Sistema.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Sistema.Location = New System.Drawing.Point(0, 32)
        Me.Sistema.Name = "Sistema"
        Me.Sistema.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Sistema.Size = New System.Drawing.Size(121, 73)
        Me.Sistema.TabIndex = 16
        Me.Sistema.TabStop = False
        Me.Sistema.Text = "Sistema di misura"
        '
        '_SysInter_2
        '
        Me._SysInter_2.BackColor = System.Drawing.SystemColors.Control
        Me._SysInter_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._SysInter_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._SysInter_2.Location = New System.Drawing.Point(8, 48)
        Me._SysInter_2.Name = "_SysInter_2"
        Me._SysInter_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._SysInter_2.Size = New System.Drawing.Size(100, 17)
        Me._SysInter_2.TabIndex = 21
        Me._SysInter_2.Text = "Imperiale"
        '
        '_SysInter_1
        '
        Me._SysInter_1.BackColor = System.Drawing.SystemColors.Control
        Me._SysInter_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._SysInter_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._SysInter_1.Location = New System.Drawing.Point(8, 32)
        Me._SysInter_1.Name = "_SysInter_1"
        Me._SysInter_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._SysInter_1.Size = New System.Drawing.Size(100, 17)
        Me._SysInter_1.TabIndex = 13
        Me._SysInter_1.Text = "Tecnico metrico"
        '
        '_SysInter_0
        '
        Me._SysInter_0.BackColor = System.Drawing.SystemColors.Control
        Me._SysInter_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._SysInter_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._SysInter_0.Location = New System.Drawing.Point(8, 16)
        Me._SysInter_0.Name = "_SysInter_0"
        Me._SysInter_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._SysInter_0.Size = New System.Drawing.Size(100, 17)
        Me._SysInter_0.TabIndex = 12
        Me._SysInter_0.Text = "Internazionale"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menfile})
        '
        'menfile
        '
        Me.menfile.Index = 0
        Me.menfile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mennuovo, Me.menapri, Me.menSalva, Me.line1, Me.menstampa, Me.line2, Me.menEsci})
        Me.menfile.Text = "File"
        '
        'mennuovo
        '
        Me.mennuovo.Index = 0
        Me.mennuovo.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mennuovo.Text = "Nuovo"
        '
        'menapri
        '
        Me.menapri.Index = 1
        Me.menapri.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.menapri.Text = "Apri"
        '
        'menSalva
        '
        Me.menSalva.Index = 2
        Me.menSalva.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.menSalva.Text = "Salva"
        '
        'line1
        '
        Me.line1.Index = 3
        Me.line1.Text = "-"
        '
        'menstampa
        '
        Me.menstampa.Index = 4
        Me.menstampa.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.menstampa.Text = "Stampa"
        '
        'line2
        '
        Me.line2.Index = 5
        Me.line2.Text = "-"
        '
        'menEsci
        '
        Me.menEsci.Index = 6
        Me.menEsci.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.menEsci.Text = "Esci"
        '
        'ToolBar2
        '
        Me.ToolBar2.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Nuovo, Me.Apri, Me.Salva, Me.Stampa, Me.Esci})
        Me.ToolBar2.DropDownArrows = True
        Me.ToolBar2.ImageList = Me.ToolBarImageList
        Me.ToolBar2.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar2.Name = "ToolBar2"
        Me.ToolBar2.ShowToolTips = True
        Me.ToolBar2.Size = New System.Drawing.Size(613, 28)
        Me.ToolBar2.TabIndex = 112
        '
        'Nuovo
        '
        Me.Nuovo.ImageIndex = 0
        Me.Nuovo.Tag = "Nuovo"
        '
        'Apri
        '
        Me.Apri.ImageIndex = 1
        Me.Apri.Tag = "Apri"
        '
        'Salva
        '
        Me.Salva.ImageIndex = 2
        Me.Salva.Tag = "Salva"
        '
        'Stampa
        '
        Me.Stampa.ImageIndex = 3
        Me.Stampa.Tag = "Stampa"
        '
        'Esci
        '
        Me.Esci.ImageIndex = 4
        Me.Esci.Tag = "Esci"
        '
        'ToolBarImageList
        '
        Me.ToolBarImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.ToolBarImageList.ImageStream = CType(resources.GetObject("ToolBarImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ToolBarImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'Tir1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(613, 491)
        Me.Controls.Add(Me.ToolBar2)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Commento)
        Me.Controls.Add(Me.Tipocalc)
        Me.Controls.Add(Me.Sistema)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(123, 122)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Tir1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcolo Serraggio Tiranti"
        Me.Frame4.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Commento.ResumeLayout(False)
        Me.Tipocalc.ResumeLayout(False)
        Me.Sistema.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As Tir1
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As Tir1
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New Tir1()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
    Private Text_Renamed As TextArray
    Private Antiripeti As Boolean
    Private Sub Inizializza()
        Dim i As Integer, s() As String
        Dim f As Control, c As Control
        Text_Renamed = New TextArray(Me)
        For i = 0 To 32
            For Each f In Controls
                If f.GetType Is GetType(GroupBox) Then
                    For Each c In f.Controls
                        If c.GetType Is GetType(TextBox) Then
                            s = c.Name.Split(CChar("_"))
                            If s(1) = "Text" And s(2) = i.ToString Then
                                Text_Renamed.AddNewTextBox(CType(c, TextBox))
                                GoTo Cont
                            End If
                        End If
                    Next
                End If
            Next
Cont:   Next
    End Sub
    Private Sub cmdDone_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDone.Click
        Hide()
        Me.Close()
    End Sub
    Private Sub Coeff_SelectedIndexChanged(ByVal Index As Integer)
        Static InCorso As Boolean
        If InCorso Then Exit Sub
        With Problem
            Select Case Index
                Case 0
                    If _Coeff_0.SelectedIndex = 3 Then
                        frmcoef.DefInstance.Index = 0
                        InCorso = True
                        frmcoef.DefInstance.ShowDialog()
                        frmcoef.DefInstance.Dispose()
                        InCorso = False
                    End If
                    .fDado = .coefft(_Coeff_0.SelectedIndex).Coeff
                    .coeffindexD = CShort(_Coeff_0.SelectedIndex)
                Case 1
                    If _Coeff_1.SelectedIndex = 3 Then
                        frmcoef.DefInstance.Index = 1
                        InCorso = True
                        frmcoef.DefInstance.ShowDialog()
                        frmcoef.DefInstance.Dispose()
                        InCorso = False
                    End If
                    .fFil = .coefft(_Coeff_1.SelectedIndex).Coeff
                    .coeffindexF = CShort(_Coeff_1.SelectedIndex)
            End Select
        End With
        Calcol3()
        AggText()
    End Sub
    Private Sub Command1_Click(ByVal Index As Integer)
        Select Case Index
            Case 0
                With Guarn
                    .Class = Problem.ClasseGuarnizione
                    .Tipo = Problem.TipoGuarnizione
                    .Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    Problem.m = .m ' tab1(Combo1.ListIndex + 1, Combo2.ListIndex).m
                    Problem.yy = CSng(.y / CType(colConv.Item("p"), UnitCollection)(3) * CType(colConv.Item("p"), UnitCollection)(Problem.unmi)) ' tab1(Combo1.ListIndex + 1, Combo2.ListIndex).y
                    Problem.Face = .Face
                    If Not (.Face > 2 And .Face < 7) Then
                        Text_Renamed(12).Visible = False
                        _lblMis_12.Visible = False
                        _Label_16.Visible = False
                    Else
                        Text_Renamed(12).Visible = True
                        _lblMis_12.Visible = True
                        _Label_16.Visible = True
                    End If
                    Problem.ClasseGuarnizione = .Class ' Combo1.ListIndex
                    Problem.TipoGuarnizione = .Tipo ' Combo2.ListIndex
                    Problem.strClasseGuarnizione = .ClassS ' Combo1.ListIndex
                    Problem.strTipoGuarnizione = .TipoS ' Combo2.ListIndex
                End With
            Case 1 'mat bull
                With objMat
                    .Indmat = Problem.indMat
                    .Scelta(LibMat.ClasseMateriale.Bulloneria, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    Problem.indMat = .Indmat
                    Problem.MatTira = .MatStr
                End With
                SigmaAmm()
            Case 2 'tiranti
                With objTir
                    If Problem.xfil > 0 Then
                        .Xfil = Problem.xfil
                    Else
                        .Scelfil(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    End If
                    If Problem.Diam > 0 Then
                        .Dnom = Problem.Diam
                        .Cerca("Dnom")
                    End If
                    .Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    Problem.Diam = .Dnom
                    Problem.Chiave = .Chia
                    Problem.DN = .DN
                    Problem.Dnoc = .Diam
                    If Problem.xfil < 2 Then
                        Problem.passofil = .Passo
                    Else
                        Problem.passofil = CSng(25.4 / .Passo)
                    End If
                End With
        End Select
        calcolo()
        AggText()
    End Sub
    'UPGRADE_WARNING: Form evento Tir1.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub Tir1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Text_Renamed(0).Focus()
    End Sub
    Private Sub Tir1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        NormalColor = System.Drawing.ColorTranslator.ToOle(Frame1.BackColor)
        CommentoC = ""
        menstampa.Enabled = False
        ToolBar2.Buttons.Item(3).Enabled = False
        _Coeff_0.Items.Add("A secco: 0.31")
        _Coeff_0.Items.Add("Gr. ordinario: 0.17")
        _Coeff_0.Items.Add("Gr. al Molicote: 0.08")
        _Coeff_0.Items.Add("Generico: .10")
        _Coeff_1.Items.Add("A secco: 0.31")
        _Coeff_1.Items.Add("Gr. ordinario: 0.17")
        _Coeff_1.Items.Add("Gr. al Molicote: 0.08")
        _Coeff_1.Items.Add("Generico: .10")
        ClickManuale = True
        Aggiorna()
        ClickManuale = False
    End Sub
    Public WriteOnly Property CommentoC() As String
        Set(ByVal Value As String)
            Labelcom1.Text = Value
            If Len(Labelcom1.Text) = 0 Then
                ToolBar2.Buttons.Item(3).Enabled = True
                menstampa.Enabled = True
            Else
                ToolBar2.Buttons.Item(3).Enabled = False
                menstampa.Enabled = False
            End If
        End Set
    End Property
    Public Sub menapri_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menapri.Popup
        menapri_Click(eventSender, eventArgs)
    End Sub
    Public Sub menapri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menapri.Click
        If ModifiedData And nomefile.Length > 0 Then DomSalva()
        O_S.Filter = "Tiranti (*.TIR)|*.TIR"
        O_S.FileName = ""
        O_S.InitialDirectory = Monitor.Motore.Inizio.Datidir
        O_S.ShowDialog()
        nomefile = O_S.FileName
        If nomefile = "" Then Exit Sub
        If IO.File.Exists(nomefile) Then
            If Monitor.Oggetto.apri() Then
                Aggiorna()
                calcolo()
                Text_Renamed(0).Focus()
                Text_Renamed_Leave(0, New System.EventArgs)
            End If
        End If
    End Sub
    Public Sub menEsci_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menEsci.Popup
        menEsci_Click(eventSender, eventArgs)
    End Sub
    Public Sub menEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menEsci.Click
        If ModifiedData Then DomSalva()
        Hide()
        Me.Close()
    End Sub
    Public Sub mennuovo_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mennuovo.Popup
        mennuovo_Click(eventSender, eventArgs)
    End Sub
    Public Sub mennuovo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mennuovo.Click
        Dim ne As Short
        For ne = 1 To 8
            Text_Renamed(ne).Text = ""
        Next
    End Sub
    Public Sub menSalva_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menSalva.Popup
        menSalva_Click(eventSender, eventArgs)
    End Sub
    Public Sub menSalva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menSalva.Click
        S_S.Filter = "Tiranti (*.TIR)|*.TIR"
        S_S.InitialDirectory = Monitor.Motore.Inizio.Datidir
        S_S.ShowDialog()
        nomefile = S_S.FileName
        Monitor.Oggetto.scrivi()
        Tir1.DefInstance.Refresh()
        ModifiedData = False
    End Sub
    Public Sub menstampa_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menstampa.Popup
        menstampa_Click(eventSender, eventArgs)
    End Sub
    Public Sub menstampa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menstampa.Click
        StampaRapp()
    End Sub
    Private Sub Text_Renamed_TextChanged(ByVal Index As Integer, ByVal eventArgs As System.EventArgs)
        If Antiripeti Then Exit Sub
        ModifiedData = True
        Dim s As Single
        Dim t As String = Text_Renamed(Index).Text
        If t.Length = 0 Then t = "0"
        Try
            s = CSng(t)
        Catch
            s = 0
        End Try
        With Problem
            Select Case Index
                Case 0 : .t = s
                Case 1 : .p = s
                Case 2 : .DiamExtGuar = s
                Case 3 : .N = s
                Case 4 : .strClasseGuarnizione = Text_Renamed(Index).Text
                Case 5 : .wm1 = s
                Case 6 : .wm2 = s
                Case 7 : .DN = Text_Renamed(Index).Text
                Case 8 : .nb = CInt(Text_Renamed(Index).Text)
                Case 9 : .Dnoc = s
                Case 10 : .passofil = s
                Case 11 : .diammed = s
                Case 12 : .wnubbin = s
                Case 13 : .yy = s
                Case 14 : .sa2 = s
                Case 15 : .sa1 = s
                Case 16 : .strTipoGuarnizione = Text_Renamed(Index).Text
                Case 17 : .phydr = s
                Case 18 : .v = s
                Case 19 : .k1 = s
                Case 20 : .vobb = s
                Case 21 : .k2Pilgrim = s
                Case 22 : .vPilgrim = s
                Case 23 : .k3 = s
                Case 24 : .areaPist = s
                Case 25 : .presPist = s
                Case 26 : .k2Torque = s
                Case 27 : .Chiave = s
                Case 28 : .fGlob = s
                Case 29 : .torque = s
                Case 30 : .m = s
                Case 31 : .MatTira = Text_Renamed(Index).Text
            End Select
        End With
    End Sub

    Private Sub Text_Renamed_KeyPress(ByVal Index As Integer, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
        Dim t As System.Windows.Forms.TextBox
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                For Each t In Text_Renamed
                    If t.TabStop And t.TabIndex = Text_Renamed(Index).TabIndex + 1 Then
                        On Error GoTo Res
                        t.Focus()
                        GoTo EventExitSub
                    End If
                Next t
        End Select
        GoTo EventExitSub
ExS:    Text_Renamed(0).Focus()
        GoTo EventExitSub
Res:    Resume ExS
EventExitSub:
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Text_Renamed_Leave(ByVal Index As Integer, ByVal eventArgs As System.EventArgs)
        Dim Nome As String = Text_Renamed(Index).Name
        If Nome.IndexOf("Text") < 0 Then Exit Sub
        If Antiripeti Then Exit Sub
        With Problem
            Select Case Index
                Case 0
                    SigmaAmm()
                    calcolo()
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 1, 2, 3, 5, 6, 8, 9, 12, 13, 14, 15, 17, 30
                    calcolo()
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 18, 19
                    calcol1()
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 20 To 24
                    Calcol2()
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 10, 11, 26, 27, 28
                    Calcol3()
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
            End Select
        End With

    End Sub
    Public Sub converti(ByRef univecchio As Short, ByRef uninuovo As Short)
        Dim c As System.Windows.Forms.TextBox, Index As Short
        Dim l As Label
        Try
            For Index = 0 To CShort(Text_Renamed.Count - 1)
                c = Text_Renamed(Index)
                If Len(CStr(c.Tag)) > 0 Then
                    l = lblMis(Index)
                    If Not l Is Nothing Then
                        Select Case uninuovo
                            Case 1
                                l.Text = CStr(colSI.Item(CStr(c.Tag)))
                            Case 2
                                l.Text = CStr(colTec.Item(CStr(c.Tag)))
                            Case 3
                                l.Text = CStr(colBR.Item(CStr(c.Tag)))
                        End Select
                    End If
                    If CStr(c.Tag) = "t" Then
                        If uninuovo <> univecchio Then
                            If univecchio = 3 Then
                                c.Text = ((CSng(c.Text) - 32) / 1.8).ToString
                            ElseIf uninuovo = 3 Then
                                c.Text = ((CSng(Text_Renamed(Index).Text) * 1.8) + 32).ToString
                            End If
                        End If
                    Else
                        c.Text = ((CSng(c.Text) / CType(colConv.Item(CStr(c.Tag)), UnitCollection)(univecchio) * CType(colConv.Item(CStr(c.Tag)), UnitCollection)(uninuovo))).ToString
                    End If
                End If
            Next Index
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function lblMis(ByVal Index As Short) As Label
        Select Case Index
            Case 0 : Return _lblMis_0
            Case 1 : Return _lblMis_1
            Case 2 : Return _lblMis_2
            Case 3 : Return _lblMis_3
                '    Case 4 : Return _lblMis_4
            Case 5 : Return _lblMis_5
            Case 6 : Return _lblMis_6
                '   Case 7 : Return _lblMis_7
                '  Case 8 : Return _lblMis_8
            Case 9 : Return _lblMis_9
            Case 10 : Return _lblMis_10
            Case 11 : Return _lblMis_11
            Case 12 : Return _lblMis_12
            Case 13 : Return _lblMis_13
            Case 14 : Return _lblMis_14
            Case 15 : Return _lblMis_15
                '  Case 16 : Return _lblMis_16
            Case 17 : Return _lblMis_17
            Case 18 : Return _lblMis_18
                '  Case 19 : Return _lblMis_19
            Case 20 : Return _lblMis_20
                '  Case 21 : Return _lblMis_21
            Case 22 : Return _lblMis_22
                '  Case 23 : Return _lblMis_23
            Case 24 : Return _lblMis_24
            Case 25 : Return _lblMis_25
                '  Case 26 : Return _lblMis_26
            Case 27 : Return _lblMis_27
                '  Case 28 : Return _lblMis_28
            Case 29 : Return _lblMis_29
                '  Case 30 : Return _lblMis_30
                '  Case 31 : Return _lblMis_31
            Case 32 : Return _lblMis_32
            Case Else : Return Nothing
        End Select
    End Function
    Public Sub Aggiorna()
        With Problem
            If Len(Trim(.coefft(3).Nome)) > 0 Then
                If Asc(.coefft(3).Nome) > 32 Then
                    _Coeff_0.Items.RemoveAt(3)
                    _Coeff_0.Items.Add(.coefft(3).Nome & ": " & Str(.coefft(3).Coeff))
                    _Coeff_1.Items.RemoveAt(3)
                    _Coeff_1.Items.Add(.coefft(3).Nome & ": " & Str(.coefft(3).Coeff))
                End If
            End If
            If .coeffindexD = -1 Then .coeffindexD = 2
            .fDado = .coefft(.coeffindexD).Coeff
            _Coeff_0.SelectedIndex = .coeffindexD
            If .coeffindexF = -1 Then .coeffindexF = 2
            .fFil = .coefft(.coeffindexF).Coeff
            _Coeff_1.SelectedIndex = .coeffindexF
            AggText()
            Select Case .unmi - 1
                Case 0 : _SysInter_0.Checked = True
                Case 1 : _SysInter_1.Checked = True
                Case 2 : _SysInter_2.Checked = True
            End Select
            Select Case .cod - 1
                Case 0 : _calcasme_0.Checked = True
                Case 1 : _calcasme_1.Checked = True
            End Select
            If Not (.Face > 2 And .Face < 7) Then
                Text_Renamed(12).Visible = False
                _lblMis_12.Visible = False
                _Label_16.Visible = False
            Else
                Text_Renamed(12).Visible = True
                _lblMis_12.Visible = True
                _Label_16.Visible = True
            End If
        End With
    End Sub
    Public Sub AggText()
        With Problem
            Text_Renamed(0).Text = RoutBase1clsTrigon_definst.myStr(.t, CShort(CType(colPrima.Item("t"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("t"), UnitCollection)(.unmi)), 0)
            Text_Renamed(1).Text = RoutBase1clsTrigon_definst.myStr(.p, CShort(CType(colPrima.Item("p"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("p"), UnitCollection)(.unmi)), 0)
            Text_Renamed(2).Text = RoutBase1clsTrigon_definst.myStr(.DiamExtGuar, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(3).Text = RoutBase1clsTrigon_definst.myStr(.N, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(4).Text = .strClasseGuarnizione
            Text_Renamed(5).Text = RoutBase1clsTrigon_definst.myStr(.wm1, CShort(CType(colPrima.Item("f"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("f"), UnitCollection)(.unmi)), 0)
            Text_Renamed(6).Text = RoutBase1clsTrigon_definst.myStr(.wm2, CShort(CType(colPrima.Item("f"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("f"), UnitCollection)(.unmi)), 0)
            Text_Renamed(7).Text = .DN
            Text_Renamed(8).Text = Str(.nb)
            Text_Renamed(9).Text = RoutBase1clsTrigon_definst.myStr(.Dnoc, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(10).Text = RoutBase1clsTrigon_definst.myStr(.passofil, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(11).Text = RoutBase1clsTrigon_definst.myStr(.diammed, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(12).Text = RoutBase1clsTrigon_definst.myStr(.wnubbin, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(13).Text = RoutBase1clsTrigon_definst.myStr(.yy, CShort(CType(colPrima.Item("p"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("p"), UnitCollection)(.unmi)), 0)
            Text_Renamed(14).Text = RoutBase1clsTrigon_definst.myStr(.sa2, CShort(CType(colPrima.Item("pamm"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("pamm"), UnitCollection)(.unmi)), 0)
            Text_Renamed(15).Text = RoutBase1clsTrigon_definst.myStr(.sa1, CShort(CType(colPrima.Item("pamm"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("pamm"), UnitCollection)(.unmi)), 0)
            Text_Renamed(16).Text = .strTipoGuarnizione
            Text_Renamed(17).Text = RoutBase1clsTrigon_definst.myStr(.phydr, CShort(CType(colPrima.Item("p"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("p"), UnitCollection)(.unmi)), 0)
            Text_Renamed(18).Text = RoutBase1clsTrigon_definst.myStr(.v, CShort(CType(colPrima.Item("f"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("f"), UnitCollection)(.unmi)), 0)
            Text_Renamed(19).Text = RoutBase1clsTrigon_definst.myStr(.k1, 2, 4, 0)
            Text_Renamed(20).Text = RoutBase1clsTrigon_definst.myStr(.vobb, CShort(CType(colPrima.Item("f"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("f"), UnitCollection)(.unmi)), 0)
            Text_Renamed(21).Text = RoutBase1clsTrigon_definst.myStr(.k2Pilgrim, 2, 4, 0)
            Text_Renamed(22).Text = RoutBase1clsTrigon_definst.myStr(.vPilgrim, CShort(CType(colPrima.Item("f"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("f"), UnitCollection)(.unmi)), 0)
            Text_Renamed(23).Text = RoutBase1clsTrigon_definst.myStr(.k3, 2, 4, 0)
            Text_Renamed(24).Text = RoutBase1clsTrigon_definst.myStr(.areaPist, CShort(CType(colPrima.Item("l2"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l2"), UnitCollection)(.unmi)), 0)
            Text_Renamed(25).Text = RoutBase1clsTrigon_definst.myStr(.presPist, CShort(CType(colPrima.Item("p"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("p"), UnitCollection)(.unmi)), 0)
            Text_Renamed(26).Text = RoutBase1clsTrigon_definst.myStr(.k2Torque, 2, 4, 0)
            Text_Renamed(27).Text = RoutBase1clsTrigon_definst.myStr(.Chiave, CShort(CType(colPrima.Item("l"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("l"), UnitCollection)(.unmi)), 0)
            Text_Renamed(28).Text = RoutBase1clsTrigon_definst.myStr(.fGlob, 2, 4, 0)
            Text_Renamed(29).Text = RoutBase1clsTrigon_definst.myStr(.torque, CShort(CType(colPrima.Item("fl"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("fl"), UnitCollection)(.unmi)), 0)
            Text_Renamed(30).Text = RoutBase1clsTrigon_definst.myStr(.m, 2, 4, 0)
            Text_Renamed(31).Text = .MatTira
            Text_Renamed(32).Text = RoutBase1clsTrigon_definst.myStr(.w0, CShort(CType(colPrima.Item("f"), UnitCollection)(.unmi)), CShort(CType(colDopo.Item("f"), UnitCollection)(.unmi)), 0)
        End With
    End Sub
    Public Sub DomSalva()
        If MsgBox("Vuoi salvare il lavoro in corso?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            menSalva_Click(menSalva, New System.EventArgs)
        End If
    End Sub
    Friend Class TextArray
        Inherits System.Collections.CollectionBase
        Private ReadOnly HostForm As Tir1
        Public Sub New(ByVal host As Tir1)
            HostForm = host
        End Sub
        Default Public ReadOnly Property Item(ByVal Index As Integer) As System.Windows.Forms.TextBox
            Get
                Return CType(List.Item(Index), System.Windows.Forms.TextBox)
            End Get
        End Property
        Public Sub UnLoad(ByVal Index As Integer)
            Me.Item(Index).Dispose()
            Me.List.RemoveAt(Index)
        End Sub
        Public Sub Remove()
            ' Check to be sure there is a button to remove.
            If Me.Count > 0 Then
                ' Remove the last button added to the array from the host form 
                ' controls collection. Note the use of the default property in 
                ' accessing the array.
                Me.Item(Me.Count - 1).Dispose()
                Me.List.RemoveAt(Me.Count - 1)
            End If
        End Sub
        Public Sub RemoveAll(Optional ByVal i As Integer = 0)
            Do While Count > i
                Remove()
            Loop
        End Sub
        Public Sub AddNewTextBox(ByVal aButton As System.Windows.Forms.TextBox)
            Me.List.Add(aButton)
            AddHandler aButton.Leave, AddressOf TextLeave
            AddHandler aButton.TextChanged, AddressOf TextChanged
            AddHandler aButton.KeyPress, AddressOf KeyPress
        End Sub
        Friend Sub TextLeave(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim Nome As String = CType(sender, TextBox).Name
            Dim s() As String = Nome.Split(CChar("_"))
            HostForm.Text_Renamed_Leave(CInt(s(2)), e)
        End Sub
        Friend Sub TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim Nome As String = CType(sender, TextBox).Name
            Dim s() As String = Nome.Split(CChar("_"))
            HostForm.Text_Renamed_TextChanged(CInt(s(2)), e)
        End Sub
        Friend Sub KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Dim Nome As String = CType(sender, TextBox).Name
            Dim s() As String = Nome.Split(CChar("_"))
            HostForm.Text_Renamed_KeyPress(CInt(s(2)), e)
        End Sub
    End Class

    Private Sub _SysInter_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SysInter_0.CheckedChanged
        If _SysInter_0.Checked Then
            converti(Problem.unmi, 1)
            Problem.unmi = 1
        End If
    End Sub

    Private Sub _SysInter_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SysInter_1.CheckedChanged
        If _SysInter_1.Checked Then
            converti(Problem.unmi, 2)
            Problem.unmi = 2
        End If
    End Sub

    Private Sub _SysInter_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SysInter_2.CheckedChanged
        If _SysInter_2.Checked Then
            converti(Problem.unmi, 3)
            Problem.unmi = 3
        End If

    End Sub

    Private Sub _Coeff_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Coeff_0.SelectedIndexChanged
        Coeff_SelectedIndexChanged(0)
    End Sub

    Private Sub _Coeff_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Coeff_1.SelectedIndexChanged
        Coeff_SelectedIndexChanged(1)
    End Sub

    Private Sub _Command1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_0.Click
        Command1_Click(0)
    End Sub

    Private Sub _Command1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_1.Click
        Command1_Click(1)
    End Sub

    Private Sub _Command1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_2.Click
        Command1_Click(2)
    End Sub

    Private Sub _calcasme_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _calcasme_0.CheckedChanged
        If _calcasme_0.Checked Then
            CommentoC = ""
            Problem.cod = 1
        End If
    End Sub

    Private Sub _calcasme_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _calcasme_1.CheckedChanged
        If _calcasme_1.Checked Then
            CommentoC = ""
            Problem.cod = 2
        End If
    End Sub

    Private Sub ToolBar2_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar2.ButtonClick
        Select Case CStr(e.Button.Tag)
            Case "Nuovo"
                Azzera()
                CommentoC = ""
                Aggiorna()
            Case "Apri"
                menapri_Click(menapri, New System.EventArgs)
            Case "Salva"
                menSalva_Click(menSalva, New System.EventArgs)
            Case "Stampa"
                StampaRapp()
            Case "esci"
                menEsci_Click(menEsci, New System.EventArgs)
        End Select
    End Sub
End Class