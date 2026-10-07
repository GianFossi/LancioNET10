Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmTub
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
        Inizializzando = True
        InitializeComponent()
        Inizializzando = False
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
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_19 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_18 As System.Windows.Forms.TextBox
	Public WithEvents cmdCalcol As System.Windows.Forms.Button
	Public WithEvents _TextCil_17 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_16 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_15 As System.Windows.Forms.TextBox
	Public WithEvents _cmbCil_4 As System.Windows.Forms.ComboBox
	Public WithEvents _cmbCil_3 As System.Windows.Forms.ComboBox
	Public WithEvents _LabelCil_24 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_23 As System.Windows.Forms.Label
	Public WithEvents lblVal As System.Windows.Forms.Label
	Public WithEvents lblFatt As System.Windows.Forms.Label
	Public WithEvents _LabelCil_22 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_21 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_20 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_19 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_18 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAxial As System.Windows.Forms.Button
	Public WithEvents chkD1D2 As System.Windows.Forms.CheckBox
	Public WithEvents _cmdCil_8 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_7 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_3 As System.Windows.Forms.Button
	Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
	Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
	Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
	Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
	Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
	Public WithEvents _TextCil_12 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
	Public WithEvents _TextCil_11 As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
	Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_9 As System.Windows.Forms.TextBox
	Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
	Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
	Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_17 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
	Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
	Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents _TextCil_14 As System.Windows.Forms.NumericUpDown
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTub))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_8 = New System.Windows.Forms.Button
        Me._cmdCil_7 = New System.Windows.Forms.Button
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me._TextCil_19 = New System.Windows.Forms.TextBox
        Me._TextCil_18 = New System.Windows.Forms.TextBox
        Me.cmdCalcol = New System.Windows.Forms.Button
        Me._TextCil_17 = New System.Windows.Forms.TextBox
        Me._TextCil_16 = New System.Windows.Forms.TextBox
        Me._TextCil_15 = New System.Windows.Forms.TextBox
        Me._cmbCil_4 = New System.Windows.Forms.ComboBox
        Me._cmbCil_3 = New System.Windows.Forms.ComboBox
        Me._LabelCil_24 = New System.Windows.Forms.Label
        Me._LabelCil_23 = New System.Windows.Forms.Label
        Me.lblVal = New System.Windows.Forms.Label
        Me.lblFatt = New System.Windows.Forms.Label
        Me._LabelCil_22 = New System.Windows.Forms.Label
        Me._LabelCil_21 = New System.Windows.Forms.Label
        Me._LabelCil_20 = New System.Windows.Forms.Label
        Me._LabelCil_19 = New System.Windows.Forms.Label
        Me._LabelCil_18 = New System.Windows.Forms.Label
        Me.Frames = New System.Windows.Forms.GroupBox
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me._TextCil_14 = New System.Windows.Forms.NumericUpDown
        Me.cmdAxial = New System.Windows.Forms.Button
        Me.chkD1D2 = New System.Windows.Forms.CheckBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._TextCil_12 = New System.Windows.Forms.TextBox
        Me._TextCil_11 = New System.Windows.Forms.TextBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._TextCil_9 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._LabelCil_17 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frame3.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frames.SuspendLayout()
        CType(Me._TextCil_14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_cmdCil_8
        '
        Me._cmdCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_8.Image = CType(resources.GetObject("_cmdCil_8.Image"), System.Drawing.Image)
        Me._cmdCil_8.Location = New System.Drawing.Point(272, 64)
        Me._cmdCil_8.Name = "_cmdCil_8"
        Me._cmdCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_8.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_8.TabIndex = 48
        Me._cmdCil_8.TabStop = False
        Me._cmdCil_8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_8, "Richiama la libreria dei diametri/spessori dei tubi secondo norme TEMA")
        '
        '_cmdCil_7
        '
        Me._cmdCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_7.Image = CType(resources.GetObject("_cmdCil_7.Image"), System.Drawing.Image)
        Me._cmdCil_7.Location = New System.Drawing.Point(284, 317)
        Me._cmdCil_7.Name = "_cmdCil_7"
        Me._cmdCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_7.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_7.TabIndex = 44
        Me._cmdCil_7.TabStop = False
        Me._cmdCil_7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_7, "Mostra la tracciatura")
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(264, 317)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_3.TabIndex = 43
        Me._cmdCil_3.TabStop = False
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_3, "Riporta i valori  dalla traccatura")
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(272, 240)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_6.TabIndex = 37
        Me._cmdCil_6.TabStop = False
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_6, "Riporta i valori  di progetto dell'apparecchio")
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(272, 221)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 34
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_5, "Riporta i valori  di progetto dell'apparecchio")
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(272, 260)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 31
        Me._cmdCil_4.TabStop = False
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_4, "Riporta i valori  di progetto dell'apparecchio")
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(216, 34)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 13
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_0, "Richiama la libreria materiali")
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(272, 166)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 12
        Me._cmdCil_1.TabStop = False
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_1, "Calcola l'ammissibile")
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(272, 184)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 11
        Me._cmdCil_2.TabStop = False
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_2, "Calcola l'ammissibile")
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(240, 32)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciato.TabIndex = 99
        Me.chkAgganciato.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.Label2)
        Me.Frame3.Controls.Add(Me.Label1)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(8, 272)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(313, 160)
        Me.Frame3.TabIndex = 71
        Me.Frame3.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(297, 41)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Standard design methods for the tube-to-tubesheet weld are not given by the Code"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(297, 25)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "UHX-11.1(d)"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Picture1)
        Me.Frame1.Controls.Add(Me.Frame2)
        Me.Frame1.Controls.Add(Me.Frame3)
        Me.Frame1.ForeColor = System.Drawing.Color.Blue
        Me.Frame1.Location = New System.Drawing.Point(312, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(328, 448)
        Me.Frame1.TabIndex = 49
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "UW-20 Tube-to-tobesheets welds"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(32, 16)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(256, 252)
        Me.Picture1.TabIndex = 50
        Me.Picture1.TabStop = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._TextCil_19)
        Me.Frame2.Controls.Add(Me._TextCil_18)
        Me.Frame2.Controls.Add(Me.cmdCalcol)
        Me.Frame2.Controls.Add(Me._TextCil_17)
        Me.Frame2.Controls.Add(Me._TextCil_16)
        Me.Frame2.Controls.Add(Me._TextCil_15)
        Me.Frame2.Controls.Add(Me._cmbCil_4)
        Me.Frame2.Controls.Add(Me._cmbCil_3)
        Me.Frame2.Controls.Add(Me._LabelCil_24)
        Me.Frame2.Controls.Add(Me._LabelCil_23)
        Me.Frame2.Controls.Add(Me.lblVal)
        Me.Frame2.Controls.Add(Me.lblFatt)
        Me.Frame2.Controls.Add(Me._LabelCil_22)
        Me.Frame2.Controls.Add(Me._LabelCil_21)
        Me.Frame2.Controls.Add(Me._LabelCil_20)
        Me.Frame2.Controls.Add(Me._LabelCil_19)
        Me.Frame2.Controls.Add(Me._LabelCil_18)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 272)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(313, 168)
        Me.Frame2.TabIndex = 53
        Me.Frame2.TabStop = False
        '
        '_TextCil_19
        '
        Me._TextCil_19.AcceptsReturn = True
        Me._TextCil_19.AutoSize = False
        Me._TextCil_19.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_19.Location = New System.Drawing.Point(168, 120)
        Me._TextCil_19.MaxLength = 0
        Me._TextCil_19.Name = "_TextCil_19"
        Me._TextCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_19.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_19.TabIndex = 61
        Me._TextCil_19.Text = "Text1"
        '
        '_TextCil_18
        '
        Me._TextCil_18.AcceptsReturn = True
        Me._TextCil_18.AutoSize = False
        Me._TextCil_18.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_18.Location = New System.Drawing.Point(168, 100)
        Me._TextCil_18.MaxLength = 0
        Me._TextCil_18.Name = "_TextCil_18"
        Me._TextCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_18.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_18.TabIndex = 60
        Me._TextCil_18.Text = "Text1"
        '
        'cmdCalcol
        '
        Me.cmdCalcol.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalcol.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalcol.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalcol.Location = New System.Drawing.Point(248, 136)
        Me.cmdCalcol.Name = "cmdCalcol"
        Me.cmdCalcol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalcol.Size = New System.Drawing.Size(56, 25)
        Me.cmdCalcol.TabIndex = 59
        Me.cmdCalcol.Text = "Calcola"
        '
        '_TextCil_17
        '
        Me._TextCil_17.AcceptsReturn = True
        Me._TextCil_17.AutoSize = False
        Me._TextCil_17.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_17.Location = New System.Drawing.Point(168, 80)
        Me._TextCil_17.MaxLength = 0
        Me._TextCil_17.Name = "_TextCil_17"
        Me._TextCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_17.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_17.TabIndex = 58
        Me._TextCil_17.Text = "Text1"
        '
        '_TextCil_16
        '
        Me._TextCil_16.AcceptsReturn = True
        Me._TextCil_16.AutoSize = False
        Me._TextCil_16.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_16.Location = New System.Drawing.Point(168, 58)
        Me._TextCil_16.MaxLength = 0
        Me._TextCil_16.Name = "_TextCil_16"
        Me._TextCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_16.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_16.TabIndex = 57
        Me._TextCil_16.Text = "Text1"
        '
        '_TextCil_15
        '
        Me._TextCil_15.AcceptsReturn = True
        Me._TextCil_15.AutoSize = False
        Me._TextCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_15.Location = New System.Drawing.Point(274, 16)
        Me._TextCil_15.MaxLength = 0
        Me._TextCil_15.Name = "_TextCil_15"
        Me._TextCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_15.Size = New System.Drawing.Size(33, 20)
        Me._TextCil_15.TabIndex = 56
        Me._TextCil_15.Text = "Text1"
        '
        '_cmbCil_4
        '
        Me._cmbCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_4.Location = New System.Drawing.Point(144, 38)
        Me._cmbCil_4.Name = "_cmbCil_4"
        Me._cmbCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_4.Size = New System.Drawing.Size(161, 21)
        Me._cmbCil_4.TabIndex = 55
        Me._cmbCil_4.Text = "cmbCil"
        '
        '_cmbCil_3
        '
        Me._cmbCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_3.Location = New System.Drawing.Point(96, 16)
        Me._cmbCil_3.Name = "_cmbCil_3"
        Me._cmbCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_3.Size = New System.Drawing.Size(81, 21)
        Me._cmbCil_3.TabIndex = 54
        '
        '_LabelCil_24
        '
        Me._LabelCil_24.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_24.Location = New System.Drawing.Point(8, 121)
        Me._LabelCil_24.Name = "_LabelCil_24"
        Me._LabelCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_24.Size = New System.Drawing.Size(152, 17)
        Me._LabelCil_24.TabIndex = 70
        Me._LabelCil_24.Tag = "kPress"
        Me._LabelCil_24.Text = "Amm. tubo a trazione"
        '
        '_LabelCil_23
        '
        Me._LabelCil_23.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_23.Location = New System.Drawing.Point(8, 101)
        Me._LabelCil_23.Name = "_LabelCil_23"
        Me._LabelCil_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_23.Size = New System.Drawing.Size(152, 17)
        Me._LabelCil_23.TabIndex = 69
        Me._LabelCil_23.Tag = "kPress"
        Me._LabelCil_23.Text = "Ammissibile piastra [psi]"
        '
        'lblVal
        '
        Me.lblVal.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.lblVal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVal.Location = New System.Drawing.Point(184, 144)
        Me.lblVal.Name = "lblVal"
        Me.lblVal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVal.Size = New System.Drawing.Size(57, 17)
        Me.lblVal.TabIndex = 68
        '
        'lblFatt
        '
        Me.lblFatt.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.lblFatt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFatt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFatt.Location = New System.Drawing.Point(8, 144)
        Me.lblFatt.Name = "lblFatt"
        Me.lblFatt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFatt.Size = New System.Drawing.Size(176, 17)
        Me.lblFatt.TabIndex = 67
        Me.lblFatt.Text = "Fattore di sovradimensionamento:"
        '
        '_LabelCil_22
        '
        Me._LabelCil_22.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_22.Location = New System.Drawing.Point(8, 81)
        Me._LabelCil_22.Name = "_LabelCil_22"
        Me._LabelCil_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_22.Size = New System.Drawing.Size(152, 17)
        Me._LabelCil_22.TabIndex = 66
        Me._LabelCil_22.Tag = "kLength"
        Me._LabelCil_22.Text = "Groove weld leg (ag)  [mm]"
        '
        '_LabelCil_21
        '
        Me._LabelCil_21.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_21.Location = New System.Drawing.Point(8, 60)
        Me._LabelCil_21.Name = "_LabelCil_21"
        Me._LabelCil_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_21.Size = New System.Drawing.Size(160, 17)
        Me._LabelCil_21.TabIndex = 65
        Me._LabelCil_21.Tag = "kLength"
        Me._LabelCil_21.Text = "Fillet weld leg      (af)  [mm]"
        '
        '_LabelCil_20
        '
        Me._LabelCil_20.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_20.Location = New System.Drawing.Point(184, 18)
        Me._LabelCil_20.Name = "_LabelCil_20"
        Me._LabelCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_20.Size = New System.Drawing.Size(96, 17)
        Me._LabelCil_20.TabIndex = 64
        Me._LabelCil_20.Text = "Rapporto di forza"
        '
        '_LabelCil_19
        '
        Me._LabelCil_19.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_19.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_19.Name = "_LabelCil_19"
        Me._LabelCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_19.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_19.TabIndex = 63
        Me._LabelCil_19.Text = "Geometria del giunto"
        '
        '_LabelCil_18
        '
        Me._LabelCil_18.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_18.Location = New System.Drawing.Point(8, 17)
        Me._LabelCil_18.Name = "_LabelCil_18"
        Me._LabelCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_18.Size = New System.Drawing.Size(97, 17)
        Me._LabelCil_18.TabIndex = 62
        Me._LabelCil_18.Text = "Forza del giunto"
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me.cmbMat)
        Me.Frames.Controls.Add(Me._TextCil_14)
        Me.Frames.Controls.Add(Me.cmdAxial)
        Me.Frames.Controls.Add(Me.chkD1D2)
        Me.Frames.Controls.Add(Me._cmdCil_8)
        Me.Frames.Controls.Add(Me._cmdCil_7)
        Me.Frames.Controls.Add(Me._cmdCil_3)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me._cmbCil_2)
        Me.Frames.Controls.Add(Me._cmbCil_1)
        Me.Frames.Controls.Add(Me._cmdCil_6)
        Me.Frames.Controls.Add(Me._TextCil_13)
        Me.Frames.Controls.Add(Me._cmdCil_5)
        Me.Frames.Controls.Add(Me._TextCil_12)
        Me.Frames.Controls.Add(Me._cmdCil_4)
        Me.Frames.Controls.Add(Me._TextCil_11)
        Me.Frames.Controls.Add(Me.Command2)
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._TextCil_6)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_2)
        Me.Frames.Controls.Add(Me._TextCil_1)
        Me.Frames.Controls.Add(Me._cmbCil_0)
        Me.Frames.Controls.Add(Me._TextCil_5)
        Me.Frames.Controls.Add(Me._TextCil_7)
        Me.Frames.Controls.Add(Me._TextCil_8)
        Me.Frames.Controls.Add(Me._TextCil_9)
        Me.Frames.Controls.Add(Me._TextCil_10)
        Me.Frames.Controls.Add(Me._cmdCil_0)
        Me.Frames.Controls.Add(Me._cmdCil_1)
        Me.Frames.Controls.Add(Me._cmdCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_17)
        Me.Frames.Controls.Add(Me._LabelCil_16)
        Me.Frames.Controls.Add(Me._LabelCil_15)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_14)
        Me.Frames.Controls.Add(Me._LabelCil_13)
        Me.Frames.Controls.Add(Me._LabelCil_8)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_0)
        Me.Frames.Controls.Add(Me._LabelCil_7)
        Me.Frames.Controls.Add(Me._LabelCil_9)
        Me.Frames.Controls.Add(Me._LabelCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_11)
        Me.Frames.Controls.Add(Me._LabelCil_12)
        Me.Frames.Controls.Add(Me.chkAgganciato)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(305, 448)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.DropDownWidth = 190
        Me.cmbMat.Location = New System.Drawing.Point(96, 34)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(120, 21)
        Me.cmbMat.TabIndex = 100
        '
        '_TextCil_14
        '
        Me._TextCil_14.Location = New System.Drawing.Point(200, 344)
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.Size = New System.Drawing.Size(64, 20)
        Me._TextCil_14.TabIndex = 53
        '
        'cmdAxial
        '
        Me.cmdAxial.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAxial.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAxial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAxial.Location = New System.Drawing.Point(104, 238)
        Me.cmdAxial.Name = "cmdAxial"
        Me.cmdAxial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAxial.Size = New System.Drawing.Size(73, 41)
        Me.cmdAxial.TabIndex = 52
        Me.cmdAxial.Text = "Tensioni assiali "
        '
        'chkD1D2
        '
        Me.chkD1D2.BackColor = System.Drawing.SystemColors.Control
        Me.chkD1D2.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkD1D2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkD1D2.Location = New System.Drawing.Point(16, 368)
        Me.chkD1D2.Name = "chkD1D2"
        Me.chkD1D2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkD1D2.Size = New System.Drawing.Size(249, 17)
        Me.chkD1D2.TabIndex = 51
        Me.chkD1D2.Text = "Scelta automatica della divisione applicabile "
        Me.chkD1D2.Visible = False
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.Enabled = False
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(80, 317)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(187, 20)
        Me._TextCil_3.TabIndex = 41
        Me._TextCil_3.TabStop = False
        Me._TextCil_3.Text = ""
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_2.Location = New System.Drawing.Point(192, 91)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_2.Size = New System.Drawing.Size(72, 21)
        Me._cmbCil_2.TabIndex = 40
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_1.Location = New System.Drawing.Point(81, 298)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_1.Size = New System.Drawing.Size(200, 21)
        Me._cmbCil_1.TabIndex = 38
        Me._cmbCil_1.Text = "cmbCil"
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(192, 110)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_13.TabIndex = 35
        Me._TextCil_13.Text = "Text1"
        '
        '_TextCil_12
        '
        Me._TextCil_12.AcceptsReturn = True
        Me._TextCil_12.AutoSize = False
        Me._TextCil_12.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_12.Location = New System.Drawing.Point(192, 221)
        Me._TextCil_12.MaxLength = 0
        Me._TextCil_12.Name = "_TextCil_12"
        Me._TextCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_12.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_12.TabIndex = 33
        Me._TextCil_12.Text = "Text1"
        '
        '_TextCil_11
        '
        Me._TextCil_11.AcceptsReturn = True
        Me._TextCil_11.AutoSize = False
        Me._TextCil_11.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_11.Location = New System.Drawing.Point(192, 259)
        Me._TextCil_11.MaxLength = 0
        Me._TextCil_11.Name = "_TextCil_11"
        Me._TextCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_11.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_11.TabIndex = 30
        Me._TextCil_11.Text = "Text1"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(208, 392)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 25)
        Me.Command2.TabIndex = 28
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(256, 392)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 25)
        Me.Command1.TabIndex = 27
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(192, 166)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_6.TabIndex = 7
        Me._TextCil_6.Text = "Text1"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 128)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 5
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(192, 72)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 4
        Me._TextCil_2.Text = "Text1"
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(192, 53)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_1.TabIndex = 3
        Me._TextCil_1.Text = "Text1"
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 14)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(121, 21)
        Me._cmbCil_0.TabIndex = 1
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(192, 148)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_5.TabIndex = 6
        Me._TextCil_5.Text = "Text1"
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(192, 185)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_7.TabIndex = 8
        Me._TextCil_7.Text = "Text1"
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_8.Location = New System.Drawing.Point(192, 203)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 9
        Me._TextCil_8.Text = "Text1"
        '
        '_TextCil_9
        '
        Me._TextCil_9.AcceptsReturn = True
        Me._TextCil_9.AutoSize = False
        Me._TextCil_9.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_9.Location = New System.Drawing.Point(192, 280)
        Me._TextCil_9.MaxLength = 0
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_9.Size = New System.Drawing.Size(89, 20)
        Me._TextCil_9.TabIndex = 14
        Me._TextCil_9.TabStop = False
        Me._TextCil_9.Text = "Text1"
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_10.Location = New System.Drawing.Point(192, 240)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_10.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_10.TabIndex = 10
        Me._TextCil_10.Text = "Text1"
        '
        '_LabelCil_17
        '
        Me._LabelCil_17.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_17.Location = New System.Drawing.Point(9, 338)
        Me._LabelCil_17.Name = "_LabelCil_17"
        Me._LabelCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_17.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_17.TabIndex = 47
        Me._LabelCil_17.Text = "Number of tube types"
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(9, 318)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(63, 17)
        Me._LabelCil_16.TabIndex = 42
        Me._LabelCil_16.Text = "Tracciatura"
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(9, 299)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_15.TabIndex = 39
        Me._LabelCil_15.Text = "Tipo di giunto"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(9, 111)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_1.TabIndex = 36
        Me._LabelCil_1.Text = "Tolleranza spessore [+/- %]"
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(8, 224)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_14.TabIndex = 32
        Me._LabelCil_14.Tag = "kTemp"
        Me._LabelCil_14.Text = "Temperatura di progetto"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(8, 260)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_13.TabIndex = 29
        Me._LabelCil_13.Tag = "kPress"
        Me._LabelCil_13.Text = "Pressione esterna"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 167)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_8.TabIndex = 26
        Me._LabelCil_8.Tag = "kPress"
        Me._LabelCil_8.Text = "Allowable stress @ room"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 130)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 25
        Me._LabelCil_6.Tag = "kLength"
        Me._LabelCil_6.Text = "Lunghezza [mm]"
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 93)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_5.TabIndex = 24
        Me._LabelCil_5.Text = "Tipo tolleranza"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 75)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(161, 17)
        Me._LabelCil_4.TabIndex = 23
        Me._LabelCil_4.Tag = "kLength"
        Me._LabelCil_4.Text = "Spessore [mm]"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 55)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_3.TabIndex = 22
        Me._LabelCil_3.Tag = "kLength"
        Me._LabelCil_3.Text = "Diametro esterno [mm]"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 34)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_2, True)
        Me._LabelCil_2.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_2.TabIndex = 21
        Me._LabelCil_2.Text = "Tube Material"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 14)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 20
        Me._LabelCil_0.Text = "Tube identification"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 148)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_7.TabIndex = 19
        Me._LabelCil_7.Tag = "kLength"
        Me._LabelCil_7.Text = "Raggio minimo di curvatura [mm]"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 185)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_9.TabIndex = 18
        Me._LabelCil_9.Tag = "kPress"
        Me._LabelCil_9.Text = "Allowable stress @ temp"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 204)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_10.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_10.TabIndex = 17
        Me._LabelCil_10.Text = "Efficienza di saldatura"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 280)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 16
        Me._LabelCil_11.Text = "Corrosione"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 241)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_12.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_12.TabIndex = 15
        Me._LabelCil_12.Tag = "kPress"
        Me._LabelCil_12.Text = "Pressione interna"
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(256, 252)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmTub
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(642, 447)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTub"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Tubi scambiatori"
        Me.Frame3.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frames.ResumeLayout(False)
        CType(Me._TextCil_14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmTub
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmTub
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmTub
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmTub)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public kLatoLoc As Short
    Public jInvolucrLoc As Short
    Public Cancel As Boolean
    Public NumTipo As Short
    Public NonProssimo As Boolean
    Private iPT As Short
    Private ColorLabel As Integer
    Private Figlio(3) As frmTub
    Private Inizializzando As Boolean
    Private Width0 As Short = GlobalRoutines.TwipsToPixelsX(4680)
    Private Width1 As Short = GlobalRoutines.TwipsToPixelsX(9500)
    Private TagImageList1() As String = {"(a)", _
                                         "(b)", _
                                         "(c)", _
                                         "(d)", _
                                         "UHX-11.1(d)"}
    Private Sub Inizializza()
        Dim ifl, i As Short
        Dim Testo As String
        Dim k As Short
        Dim File As String
        ColorLabel = System.Drawing.ColorTranslator.ToOle(lblFatt.BackColor)
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(2835)
        _cmbCil_4.Items.Clear()
        _cmbCil_4.Items.Add("(a) - fillet")
        _cmbCil_4.Items.Add("(b) - groove")
        _cmbCil_4.Items.Add("(c) - f+g simm.")
        _cmbCil_4.Items.Add("(d) - f+g diss.")
        _cmbCil_3.Items.Clear()
        _cmbCil_3.Items.Add("Partial strength")
        _cmbCil_3.Items.Add("Full strength")
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("Tubi scambiatori")
        _cmbCil_0.Items.Add("Exchanging tubes")
        _cmbCil_0.Items.Add("Other (write)")
        _cmbCil_1.Items.Clear()
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\GIUNTO.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 9
            Testo = LineInput(ifl)
            _cmbCil_1.Items.Add(Testo)
        Next
        FileClose(ifl)
        _cmbCil_2.Items.Clear()
        _cmbCil_2.Items.Add("MW")
        _cmbCil_2.Items.Add("AW")
        If NumTipo = 1 Then
            Figlio(1) = Me
            nTipiTubi = Involucr(kLatoLoc, jInvolucrLoc).jmemb1
            If nTipiTubi > 1 Then Text = Text & " Tipo 1"
            'Figlio(1).kLatoLoc = kLatoLoc
            'Figlio(1).jInvolucrLoc = jInvolucrLoc
            'Figlio(1).NumTipo = 1
            For i = 2 To nTipiTubi 'Involucr(kLatoLoc, jInvolucrLoc).jmemb1
                Figlio(i) = New frmTub
                Figlio(i).Text = Figlio(i).Text & " Tipo" & i.ToString
                Figlio(i).kLatoLoc = 4
                Figlio(i).NumTipo = i
                Figlio(i).jInvolucrLoc = Involucr(kLatoLoc, jInvolucrLoc).IndAccopp(i - 1)
            Next
            For i = 1 To nTipiTubi
                For k = 1 To nTipiTubi
                    Figlio(i).pFiglio(k) = Figlio(k)
                Next
                'If i > 1 Then Figlio(i).Show vbModal
            Next
        End If
        ' DisplayProssimi
        Select Case Config(3).DC
            Case 0 To 2, 9 To 11
                _LabelCil_14.Text = "Temperatura di progetto"
                cmdAxial.Visible = False
            Case 3 To 5
                _LabelCil_14.Text = "Temperatura di progetto"
                cmdAxial.Visible = True
            Case 6 To 8
                _LabelCil_14.Text = "Temperatura di calcolo"
                cmdAxial.Visible = True
        End Select
        File = Trim(Involucr(kLato, jInvolucr).File) 'GenFileTraccia()
        If Not File Is Nothing Then
            If File.Trim.Length > 0 Then
                If IO.File.Exists(File) Then
                    _TextCil_3.Text = File
                Else
                    Involucr(kLato, jInvolucr).File = ""
                    _TextCil_3.Text = "(nessuno)"
                End If
            End If
        End If
        _LabelCil_9.Visible = Not VerificandoPI
        _TextCil_7.Visible = Not VerificandoPI
        _cmdCil_2.Visible = Not VerificandoPI
        _TextCil_10.Enabled = Not VerificandoPI
        _TextCil_11.Enabled = Not VerificandoPI
        _TextCil_12.Enabled = Not VerificandoPI
        _LabelCil_11.Visible = Not VerificandoPI
        _TextCil_9.Visible = Not VerificandoPI
        If VerificandoPI Then
            _LabelCil_8.Text = "Allowable Stress in H.T."
        End If
        Popola(cmbMat)
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub chkD1D2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkD1D2.CheckStateChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Norma = 1 - chkD1D2.CheckState
    End Sub
    Private Sub cmdAxial_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAxial.Click
        Dim Strin(4) As String
        Dim Dom(4) As String
        Dim Arch(4) As Short
        Dim dAiu(4) As String
        Dim UltAiu As String = ""
        Dim Aiuto As String = ""
        Dim i, n As Short
        If CType(CodiceStress(), LibMat.Codes) = LibMat.Codes.EU Then n = 2
        UltAiu = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_TUB_AXIAL5))
        For i = 1 To 4
            Dom(i) = Trim(Helpstringa(IDH_TUB_AXIAL1 + i - 1))
            Strin(i) = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Dati(i + 3 - 4), 6 - n, n, False)
        Next
        If Not Monitor.Motore.InputDati(4, "AsmeVip", Dom, Strin, Aiuto, Arch, dAiu, UltAiu) Then Exit Sub
        For i = 1 To 4
            Involucr(kLato, jInvolucr).Dati(3 + i - 4) = GlobalRoutines.ValVir(Strin(i))
        Next
    End Sub

    Private Sub cmdCalcol_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalcol.Click
        Dim fact As Single
        AggUW20()
        fact = CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcola
        AggUW20()
        If fact >= 1 Then
            lblFatt.BackColor = System.Drawing.ColorTranslator.FromOle(ColorLabel)
        Else
            lblFatt.BackColor = System.Drawing.Color.Red
        End If
        lblVal.Text = Format(100 * (fact - 1), "##.###") & "%"
    End Sub
    Private Function RetrieveTracciatura(ByVal objtraccia As traccia.clsTracciatura) As Short
        With Involucr(kLatoLoc, jInvolucrLoc)
            .dns = objtraccia.DiametroTubo
            .Spess = objtraccia.SpessoreTubo
            .L0 = objtraccia.LunghezzaTubi
            .R0 = objtraccia.RaggioMinimo
        End With
        If iPT > 0 Then
            With CType(objMemb(Involucr(3, iPT).IndObject), wn_PT)
                .TubPass = objtraccia.Passo
                .TipPass = objtraccia.TipoPasso
                .OTL = objtraccia.OTL
                .EquDiam = objtraccia.Diaml
                If .TipoPT = 2 Then
                    CType(.Piastra, wn_FTC).Zp(1, 29) = objtraccia.NumeroTubi
                    Select Case objtraccia.TipoFascio
                        Case traccia.clsTracciatura.TipiFascio.TesteFisse : CType(.Piastra, wn_FTC).Rear = 1
                        Case traccia.clsTracciatura.TipiFascio.TestaFlottante : CType(.Piastra, wn_FTC).Rear = 2
                        Case traccia.clsTracciatura.TipiFascio.Utube, traccia.clsTracciatura.TipiFascio.Fontana : CType(.Piastra, wn_FTC).Rear = 3
                    End Select
                End If
            End With
        End If
    End Function

    Private Function GeneraTracciatura(ByVal objtraccia As traccia.clsTracciatura, ByVal File As String) As Short
        If MessageBox.Show(Me, "La tracciatura " & File & " non è stata trovata. Vuoi generarla?", "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            With Involucr(kLatoLoc, jInvolucrLoc)
                objtraccia.DiametroTubo = .dns
                objtraccia.SpessoreTubo = .Spess
                objtraccia.LunghezzaTubi = .L0
                objtraccia.RaggioMinimo = .R0
            End With
            If iPT > 0 Then
                With CType(objMemb(Involucr(3, iPT).IndObject), wn_PT)
                    objtraccia.Passo = .TubPass
                    objtraccia.TipoPasso = .TipPass
                    If .TipoPT = 2 Then
                        objtraccia.NumeroTubi = CType(.Piastra, wn_FTC).Zp(1, 29)
                        Select Case CType(.Piastra, wn_FTC).Rear
                            Case 1 : objtraccia.TipoFascio = traccia.clsTracciatura.TipiFascio.TesteFisse
                            Case 2 : objtraccia.TipoFascio = traccia.clsTracciatura.TipiFascio.TestaFlottante
                            Case 3 : objtraccia.TipoFascio = traccia.clsTracciatura.TipiFascio.Utube
                        End Select
                    Else
                        objtraccia.TipoFascio = traccia.clsTracciatura.TipiFascio.Utube
                    End If
                End With
            End If
            Return objtraccia.Esegui(-1, File)
        End If
    End Function
    Private Sub cmdCil_Click(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim objTraccia As traccia.clsTracciatura
        Dim Res As Short
        Dim File As String
        Dim objBWG As LibMat.clsBWG
        Dim jSav As Integer = jInvolucr
        Dim kSav As Integer = kLato
        jInvolucr = jInvolucrLoc
        kLato = kLatoLoc
        With Involucr(kLatoLoc, jInvolucrLoc)
            Select Case Index
                Case 0 : SelMat()
                    PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(1 - 1))
                    SubAmm()
                Case 1, 2
                    SubAmm()
                Case 3 'tracciatura
                    objTraccia = New traccia.clsTracciatura
                    objTraccia.DoveMotore = Monitor.Motore
                    File = GenFileTraccia()
                    Res = objTraccia.Esegui(1, File)
                    .File = File
                    Select Case Res
                        Case 0
                            _TextCil_3.Text = File
                        Case 1
                            Res = GeneraTracciatura(objTraccia, File)
                            Select Case Res
                                Case 0
                                    _TextCil_3.Text = File
                                Case 1
                                    _TextCil_3.Text = ""
                                    .File = ""
                            End Select
                        Case 2
                    End Select
                    If Res = 0 Then
                        RetrieveTracciatura(objTraccia)
                    End If
                    AggDatiTub()
                    objTraccia = Nothing
                Case 5 'riporto temp prog.
                    _TextCil_12.Text = GlobalRoutines.myStr(Config(1).tdx * kTemp + kTemp32, 6, 2, 0)
                    If Config(2).tdx > Config(1).tdx Then _TextCil_12.Text = GlobalRoutines.myStr(Config(2).tdx * kTemp + kTemp32, 6, 2, 0)
                Case 4, 6 'riporto pressioni
                    _TextCil_11.Text = GlobalRoutines.myStr(Config(1).p0x * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    _TextCil_10.Text = GlobalRoutines.myStr(Config(2).p0x * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                Case 7 'visualizza tracciatura
                    objTraccia = New traccia.clsTracciatura
                    objTraccia.DoveMotore = Monitor.Motore
                    File = GenFileTraccia()
                    ' Res = objTraccia.Esegui(1, File)
                    Res = objTraccia.Esegui(2, File)
                    _TextCil_3.Text = File
                    .File = File
                    If Res = 0 Then
                        RetrieveTracciatura(objTraccia)
                    Else
                        Res = GeneraTracciatura(objTraccia, File)
                        RetrieveTracciatura(objTraccia)
                    End If
                    AggDatiTub()
                    objTraccia = Nothing
                Case 8
                    objBWG = New LibMat.clsBWG
                    objBWG.DoveMotore = Monitor.Motore
                    objBWG.Spess = .Spess
                    objBWG.Diam = .dns
                    objBWG.TipoMat = 1
                    objBWG.Mostra()
                    _TextCil_2.Text = GlobalRoutines.myStr(objBWG.Spess * kLength, 3, 3, False)
                    _TextCil_1.Text = GlobalRoutines.myStr(objBWG.Diam * kLength, 5, 2, False)
                    objBWG = Nothing
            End Select
        End With
        jInvolucr = jSav
        kLato = kSav
    End Sub
    Private Sub SubAmm()
        Call Ammiss(jInvolucrLoc)
        If VerificandoPI Then
            _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLatoLoc, jInvolucrLoc).Shydr * kPress, 5, 3, False)
        Else
            _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLatoLoc, jInvolucrLoc).S0 * kPress, 5, 3, False)
            _TextCil_7.Text = GlobalRoutines.myStr(Involucr(kLatoLoc, jInvolucrLoc).St * kPress, 5, 3, False)
        End If
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Cancel = False
        If NumTipo > 1 Then
            Figlio(NumTipo - 1).NonProssimo = True
        End If
        Hide()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        If NumTipo > 1 Then
            Figlio(NumTipo - 1).NonProssimo = True
        End If
        Hide()
    End Sub
    Private Sub DisplayProssimi()
        Dim FinX, FinY As Single
        If NonProssimo Then Exit Sub
        'DoEvents
        If NumTipo > 1 Then
            _LabelCil_17.Visible = False
            _TextCil_14.Visible = False
            _LabelCil_16.Visible = False
            _TextCil_3.Visible = False
            _cmdCil_3.Visible = False
            _cmdCil_7.Visible = False
            FinX = Figlio(NumTipo - 1).Left + 16
            FinY = Figlio(NumTipo - 1).Top + 32
            Me.TopMost = True
            Me.Left = FinX
            Me.Top = FinY
        End If
        If Not Figlio(NumTipo + 1) Is Nothing Then Figlio(NumTipo + 1).ShowDialog()
    End Sub
    'UPGRADE_WARNING: Form evento frmTub.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmTub_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        With Involucr(kLatoLoc, jInvolucrLoc)
            If .H0 <= 0 Then .H0 = 12
        End With
        AggDatiTub()
        DisplayProssimi()
        kLato = kLatoLoc
        jInvolucr = jInvolucrLoc
        AggiornaLabels(Me, 24)
    End Sub
    Private Sub frmTub_Closing(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Cancel As Short = eventArgs.Cancel
        With Involucr(kLatoLoc, jInvolucrLoc)
            If iPT > 0 Then CType(objMemb(Involucr(3, iPT).IndObject), wn_PT).TipoGiunto = .ms
        End With
        If NumTipo = 1 Then
            kLato = kLatoLoc
            jInvolucr = jInvolucrLoc
        End If
        eventArgs.Cancel = Cancel
    End Sub
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Try
            With Involucr(kLatoLoc, jInvolucrLoc)
                Select Case Index
                    Case 1 : .dns = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    Case 2 : .Spess = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        If .xs = 1 Then
                            .TubeMinT = .Spess
                        Else
                            .TubeMinT = .Spess * (1 - .H0 / 100)
                        End If
                    Case 4 : .L0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    Case 5 : .R0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    Case 6 : .S0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Case 7 : .St = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Case 8 : .ES = GlobalRoutines.ValVir(TextCil(Index).Text)
                    Case 9 : .cs = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    Case 10 : .PressInt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'press int
                    Case 11 : .PressExt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'press ext
                    Case 12 : .Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
                    Case 13 : .H0 = GlobalRoutines.ValVir(TextCil(Index).Text) 'toller
                    Case 15
                        .Dati1 = GlobalRoutines.ValVir(TextCil(Index).Text)
                        CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcolato = False
                    Case 16 : .Dati2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcolato = False
                    Case 17 : .Dati3 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcolato = False
                    Case 18 : .UW20St = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                        CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcolato = False
                    Case 19 : .UW20Sa = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                        CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcolato = False
                End Select
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggDatiTub()
        Dim i As Short
        Dim Log1 As Boolean
        With Involucr(kLatoLoc, jInvolucrLoc)
            _cmbCil_0.Text = .Mark
            iPT = 0
            For i = 1 To Config(3).Ninvolucri
                If Involucr(3, i).Tipo = 6 Then iPT = i : Exit For
            Next
            If .ms = 0 Then
                If iPT > 0 Then .ms = objMemb(Involucr(3, iPT).IndObject).TipoGiunto
            End If
            If .ms = 0 Then .ms = 1
            If .xs = 0 Then .xs = 1
            _cmbCil_1.SelectedIndex = .ms - 1 'tipo giunto
            _cmbCil_2.SelectedIndex = .xs - 1 'MW,AW
            cmbMat.Text = .MATE.Trim
            chkAgganciato.Checked = Matdim(.indice(1 - 1)).Agganciato
            _TextCil_1.Text = GlobalRoutines.myStr(.dns * kLength, 5, 2, False)
            _TextCil_2.Text = GlobalRoutines.myStr(.Spess * kLength, 6, 3, False)
            _TextCil_3.Text = .File
            _TextCil_4.Text = GlobalRoutines.myStr(.L0 * kLength, 5, 2, False)
            _TextCil_5.Text = GlobalRoutines.myStr(.R0 * kLength, 5, 2, False)
            If VerificandoPI Then
                _TextCil_6.Text = GlobalRoutines.myStr(.Shydr * kPress, 5, 3, False)
            Else
                _TextCil_6.Text = GlobalRoutines.myStr(.S0 * kPress, 5, 3, False)
            End If
            _TextCil_7.Text = GlobalRoutines.myStr(.St * kPress, 5, 3, False)
            If .ES = 0 Then .ES = 1
            _TextCil_8.Text = GlobalRoutines.myStr(.ES, 2, 2, False)
            _TextCil_9.Text = GlobalRoutines.myStr(.cs * kLength, 2, 2, False)
            If VerificandoPI Then
                _TextCil_12.Text = GlobalRoutines.myStr(20 * kTemp + kTemp32, 5, 3, False)
                _TextCil_10.Text = GlobalRoutines.myStr(Config(2).pxTest * kPress, 5, 3, False)
                _TextCil_11.Text = GlobalRoutines.myStr(Config(1).pxTest * kPress, 5, 3, False)
            Else
                _TextCil_12.Text = GlobalRoutines.myStr(.Destemp * kTemp + kTemp32, 5, 3, False)
                _TextCil_10.Text = GlobalRoutines.myStr(.PressInt * kPress, 5, 3, False)
                _TextCil_11.Text = GlobalRoutines.myStr(.PressExt * kPress, 5, 3, False)
            End If
            _TextCil_13.Text = GlobalRoutines.myStr(.H0, 5, 3, False)
            If NumTipo = 1 Then
                If .jmemb1 = 0 Then .jmemb1 = 1
                _TextCil_14.Value = .jmemb1
                If NumTipo = 1 Then nTipiTubi = .jmemb1
            End If
            If .ms <= 2 Then AggUW20()
            Log1 = Config(0).NumeroLati > 1 And Config(1).DC <> Config(2).DC
            Log1 = Log1 And Not (Config(1).DC > 5 And Config(1).DC < 10)
            Log1 = Log1 And Not (Config(2).DC > 5 And Config(2).DC < 10)
            chkD1D2.Visible = Log1
            If .Norma < 0 Or .Norma > 1 Then .Norma = 0
            chkD1D2.CheckState = 1 - .Norma
        End With
    End Sub
    Public WriteOnly Property pFiglio(ByVal i As Short) As frmTub
        Set(ByVal Value As frmTub)
            Figlio(i) = Value
        End Set
    End Property
    Private Function AllowPiastra() As Single
        Dim i As Short
        AllowPiastra = 0
        For i = 1 To Config(3).Ninvolucri
            If Involucr(3, i).Tipo = 6 Then
                AllowPiastra = Involucr(3, i).St
            End If
        Next
    End Function
    Private Sub AggUW20()
        Dim n As Short
        With Involucr(kLatoLoc, jInvolucrLoc)
            If .Dati1 < 0.1 Then .Dati1 = 1.0#
            If .Dati1 = 1.0# Then
                _cmbCil_3.SelectedIndex = 1
            Else
                _cmbCil_3.SelectedIndex = 0
            End If
            _TextCil_15.Text = Format(.Dati1, Form1_2)
            _TextCil_16.Text = GlobalRoutines.myStr(.Dati2 * kLength, 6, 3, 0)
            _TextCil_17.Text = GlobalRoutines.myStr(.Dati3 * kLength, 6, 3, 0)
            If .di < 1 Then .di = 1
            _cmbCil_4.SelectedIndex = .di - 1
            If .UW20Sa = 0 Then .UW20Sa = .St
            If .UW20St = 0 Then .UW20St = AllowPiastra()
            If CType(CodiceStress(), LibMat.Codes) = LibMat.Codes.EU Then n = 2
            _TextCil_18.Text = GlobalRoutines.myStr(.UW20St * kPress, 6 - n, n, False)
            _TextCil_19.Text = GlobalRoutines.myStr(.UW20Sa * kPress, 6 - n, n, False)
        End With
    End Sub
    Private ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
                'Case 0 : Return _TextCil_0
                Case 1 : Return _TextCil_1
                Case 2 : Return _TextCil_2
                Case 3 : Return _TextCil_3
                Case 4 : Return _TextCil_4
                Case 5 : Return _TextCil_5
                Case 6 : Return _TextCil_6
                Case 7 : Return _TextCil_7
                Case 8 : Return _TextCil_8
                Case 9 : Return _TextCil_9
                Case 10 : Return _TextCil_10
                Case 11 : Return _TextCil_11
                Case 12 : Return _TextCil_12
                Case 13 : Return _TextCil_13
                Case 15 : Return _TextCil_15
                Case 16 : Return _TextCil_16
                Case 17 : Return _TextCil_17
                Case 18 : Return _TextCil_18
                Case 19 : Return _TextCil_19
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub _TextCil_14_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.ValueChanged
        If Inizializzando Then Exit Sub
        Dim i, k As Short
        With Involucr(kLatoLoc, jInvolucrLoc)
            If NumTipo = 1 Then
                ' NonProssimo = False
                nTipiTubi = _TextCil_14.Value 'numero di tipi
                If nTipiTubi > .jmemb1 Then
                    Figlio(nTipiTubi) = New frmTub
                    Figlio(nTipiTubi).Text = Figlio(nTipiTubi).Text & " Tipo" & Str(nTipiTubi)
                    Config(4).Ninvolucri = Config(4).Ninvolucri + 1
                    Involucr(kLatoLoc, jInvolucrLoc).IndAccopp(nTipiTubi - 1) = Config(4).Ninvolucri
                    Figlio(nTipiTubi).NumTipo = nTipiTubi
                    Figlio(nTipiTubi).kLatoLoc = 4
                    Figlio(nTipiTubi).jInvolucrLoc = Config(4).Ninvolucri
                    For i = 2 To nTipiTubi - 1
                        Figlio(i).pFiglio(nTipiTubi) = Figlio(nTipiTubi)
                    Next
                    For i = 1 To nTipiTubi
                        Figlio(nTipiTubi).pFiglio(i) = Figlio(i)
                    Next
                    Figlio(2).ShowDialog()
                ElseIf nTipiTubi < .jmemb1 Then
                    For i = Involucr(kLatoLoc, jInvolucrLoc).IndAccopp(nTipiTubi) To Config(4).Ninvolucri - 1
                        Involucr(4, i) = Involucr(4, i + 1)
                    Next
                    Config(4).Ninvolucri = Config(4).Ninvolucri - 1
                    If nTipiTubi = 1 Then Text = VB.Left(Text, Len(Text) - 7)
                End If
                .jmemb1 = nTipiTubi 'numero di tipi
                For i = 2 To nTipiTubi
                    Involucr(4, Involucr(kLatoLoc, jInvolucrLoc).IndAccopp(i - 1)).jmemb1 = nTipiTubi
                    For k = 2 To nTipiTubi
                        Involucr(4, Involucr(kLatoLoc, jInvolucrLoc).IndAccopp(i - 1)).IndAccopp(k - 1) = Involucr(kLatoLoc, jInvolucrLoc).IndAccopp(k - 1)
                    Next
                Next
            End If
        End With
    End Sub

    Private Sub _TextCil_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextCil_TextChanged(0)
    End Sub

    Private Sub _TextCil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_1.TextChanged
        TextCil_TextChanged(1)
    End Sub

    Private Sub _TextCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.TextChanged
        TextCil_TextChanged(10)
    End Sub

    Private Sub _TextCil_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_11.TextChanged
        TextCil_TextChanged(11)
    End Sub

    Private Sub _TextCil_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.TextChanged
        TextCil_TextChanged(12)
    End Sub

    Private Sub _TextCil_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_13.TextChanged
        TextCil_TextChanged(13)
    End Sub

    Private Sub _TextCil_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_15.TextChanged
        TextCil_TextChanged(15)
    End Sub

    Private Sub _TextCil_16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_16.TextChanged
        TextCil_TextChanged(16)
    End Sub

    Private Sub _TextCil_17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_17.TextChanged
        TextCil_TextChanged(17)
    End Sub

    Private Sub _TextCil_18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_18.TextChanged
        TextCil_TextChanged(18)
    End Sub

    Private Sub _TextCil_19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_19.TextChanged
        TextCil_TextChanged(19)
    End Sub

    Private Sub _TextCil_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_2.TextChanged
        TextCil_TextChanged(2)
    End Sub

    Private Sub _TextCil_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_3.TextChanged
        TextCil_TextChanged(3)
    End Sub

    Private Sub _TextCil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_4.TextChanged
        TextCil_TextChanged(4)
    End Sub

    Private Sub _TextCil_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_5.TextChanged
        TextCil_TextChanged(5)
    End Sub

    Private Sub _TextCil_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_6.TextChanged
        TextCil_TextChanged(6)
    End Sub

    Private Sub _TextCil_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_7.TextChanged
        TextCil_TextChanged(7)
    End Sub

    Private Sub _TextCil_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_8.TextChanged
        TextCil_TextChanged(8)
    End Sub

    Private Sub _TextCil_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.TextChanged
        TextCil_TextChanged(9)
    End Sub

    Private Sub _TextCil_12_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.Leave
        If Inizializzando Then Exit Sub
        AvvertiDT()
    End Sub

    Private Sub _TextCil_15_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_15.Leave
        If Inizializzando Then Exit Sub
        If GlobalRoutines.ValVir(_TextCil_15.Text) > 1 Then _cmbCil_3.SelectedIndex = 1
        If GlobalRoutines.ValVir(_TextCil_15.Text) < 0.1 Then _TextCil_15.Text = "0.1"
        Involucr(kLatoLoc, jInvolucrLoc).Dati1 = GlobalRoutines.ValVir(_TextCil_15.Text)
    End Sub

    Private Sub _cmbCil_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLatoLoc, jInvolucrLoc).Mark = _cmbCil_0.Text
    End Sub

    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Involucr(kLatoLoc, jInvolucrLoc).Mark = _cmbCil_0.Text
    End Sub

    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        With Involucr(kLatoLoc, jInvolucrLoc)
            .ms = _cmbCil_1.SelectedIndex + 1
            If .ms < 3 Or .ms = 9 And Not VerificandoPI Then
                Width = Width1
                Frame2.Visible = .ms < 3
                Frame3.Visible = Not Frame2.Visible
                If .ms = 9 Then Picture1.Image = ImageList1.Images(5) 'IBW
                AggDatiTub()
            Else
                Width = Width0
            End If
        End With
    End Sub

    Private Sub _cmbCil_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_2.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        With Involucr(kLatoLoc, jInvolucrLoc)
            .xs = _cmbCil_2.SelectedIndex + 1
            _LabelCil_1.Visible = _cmbCil_2.SelectedIndex = 1
            _TextCil_13.Visible = _cmbCil_2.SelectedIndex = 1
            If .xs = 1 Then
                .TubeMinT = .Spess
            Else
                .TubeMinT = .Spess * (1 - .H0 / 100)
            End If
        End With
    End Sub

    Private Sub _cmbCil_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_3.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        If _cmbCil_3.SelectedIndex = 1 Then
            _TextCil_15.Enabled = False
            _TextCil_15.Text = "1.0"
        Else
            _TextCil_15.Enabled = True
        End If

    End Sub

    Private Sub _cmbCil_4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_4.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        With Involucr(kLatoLoc, jInvolucrLoc)
            .di = _cmbCil_4.SelectedIndex + 1
            Picture1.Image = ImageList1.Images(CInt(.di))
            _TextCil_17.Visible = .di > 1
            _LabelCil_22.Visible = .di > 1
            _TextCil_16.Visible = .di <> 2
            _LabelCil_21.Visible = .di <> 2
            CType(objMemb(Involucr(kLatoLoc, jInvolucrLoc).IndObject), wn_Tub).Calcolato = False
        End With
    End Sub

    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        cmdCil_Click(0)
    End Sub

    Private Sub _cmdCil_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        cmdCil_Click(1)
    End Sub

    Private Sub _cmdCil_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_2.Click
        cmdCil_Click(2)
    End Sub

    Private Sub _cmdCil_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_3.Click
        cmdCil_Click(3)
    End Sub

    Private Sub _cmdCil_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_4.Click
        cmdCil_Click(4)
    End Sub

    Private Sub _cmdCil_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_5.Click
        cmdCil_Click(5)
    End Sub

    Private Sub _cmdCil_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_6.Click
        cmdCil_Click(6)
    End Sub
    Private Sub _cmdCil_7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_7.Click
        cmdCil_Click(7)
    End Sub
    Private Sub _cmdCil_8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_8.Click
        cmdCil_Click(8)
    End Sub
    Private Sub chkAgganciato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato.CheckedChanged
        Matdim(Involucr(kLatoLoc, jInvolucrLoc).indice(1 - 1)).Agganciato = chkAgganciato.Checked
        ModifiedData = True
    End Sub
    Public ReadOnly Property LabelCil(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _LabelCil_0
                Case 1 : Return _LabelCil_1
                Case 2 : Return _LabelCil_2
                Case 3 : Return _LabelCil_3
                Case 4 : Return _LabelCil_4
                Case 5 : Return _LabelCil_5
                Case 6 : Return _LabelCil_6
                Case 7 : Return _LabelCil_7
                Case 8 : Return _LabelCil_8
                Case 9 : Return _LabelCil_9
                Case 10 : Return _LabelCil_10
                Case 11 : Return _LabelCil_11
                Case 12 : Return _LabelCil_12
                Case 13 : Return _LabelCil_13
                Case 14 : Return _LabelCil_14
                Case 15 : Return _LabelCil_15
                Case 16 : Return _LabelCil_16
                Case 17 : Return _LabelCil_17
                Case 18 : Return _LabelCil_18
                Case 19 : Return _LabelCil_19
                Case 20 : Return _LabelCil_20
                Case 21 : Return _LabelCil_21
                Case 22 : Return _LabelCil_22
                Case 23 : Return _LabelCil_23
                Case 24 : Return _LabelCil_24
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Involucr(kLato, jInvolucr).indice(0), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
        chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato

    End Sub
End Class