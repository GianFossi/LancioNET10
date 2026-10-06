Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmNoz
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
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_3 As System.Windows.Forms.Button
    Public WithEvents _TextCil_18 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _TextCil_15 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_16 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_23 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_22 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_17 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_18 As System.Windows.Forms.Label
    Public WithEvents _Frames_2 As System.Windows.Forms.GroupBox
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents _cmdCil_15 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_14 As System.Windows.Forms.Button
    Public WithEvents _TextCil_29 As System.Windows.Forms.TextBox
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents framSleeve As System.Windows.Forms.Panel
    Public WithEvents _cmdCil_13 As System.Windows.Forms.Button
    Public WithEvents _TextCil_28 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_27 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_12 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_11 As System.Windows.Forms.Button
    Public WithEvents _TextCil_24 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_23 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
    Public WithEvents _cmbCil_5 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_14 As System.Windows.Forms.TextBox
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_12 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_11 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_9 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_34 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_33 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_32 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_31 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_29 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_28 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
    Public WithEvents _Frames_0 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_22 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_21 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_20 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
    Public WithEvents _TextCil_19 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_4 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_3 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
    Public WithEvents _LabelCil_30 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_27 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_26 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_25 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_24 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_21 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_20 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_19 As System.Windows.Forms.Label
    Public WithEvents _Frames_1 As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents _TextCil_25 As System.Windows.Forms.NumericUpDown
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciatoN As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciatoF As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciatoP As System.Windows.Forms.CheckBox
    Friend WithEvents _Frames_3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkApp2 As System.Windows.Forms.CheckBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmdBoltMat As System.Windows.Forms.Button
    Friend WithEvents chkBoltMat As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatFl As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatBolt As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatPad As System.Windows.Forms.ComboBox
    Friend WithEvents chkCategA As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNoz))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkAgganciatoN = New System.Windows.Forms.CheckBox
        Me.chkAgganciatoF = New System.Windows.Forms.CheckBox
        Me.chkAgganciatoP = New System.Windows.Forms.CheckBox
        Me.chkBoltMat = New System.Windows.Forms.CheckBox
        Me._cmdCil_14 = New System.Windows.Forms.Button
        Me._cmdCil_11 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._Frames_2 = New System.Windows.Forms.GroupBox
        Me.cmbMatPad = New System.Windows.Forms.ComboBox
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me._TextCil_18 = New System.Windows.Forms.TextBox
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._TextCil_15 = New System.Windows.Forms.TextBox
        Me._TextCil_16 = New System.Windows.Forms.TextBox
        Me._LabelCil_23 = New System.Windows.Forms.Label
        Me._LabelCil_22 = New System.Windows.Forms.Label
        Me._LabelCil_17 = New System.Windows.Forms.Label
        Me._LabelCil_18 = New System.Windows.Forms.Label
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me._Frames_0 = New System.Windows.Forms.GroupBox
        Me.framSleeve = New System.Windows.Forms.Panel
        Me.Command3 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkCategA = New System.Windows.Forms.CheckBox
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me._TextCil_12 = New System.Windows.Forms.TextBox
        Me._cmbCil_5 = New System.Windows.Forms.ComboBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me.cmbMatFl = New System.Windows.Forms.ComboBox
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me._cmdCil_15 = New System.Windows.Forms.Button
        Me._TextCil_29 = New System.Windows.Forms.TextBox
        Me._cmdCil_13 = New System.Windows.Forms.Button
        Me._TextCil_28 = New System.Windows.Forms.TextBox
        Me._TextCil_27 = New System.Windows.Forms.TextBox
        Me._cmdCil_12 = New System.Windows.Forms.Button
        Me._TextCil_24 = New System.Windows.Forms.TextBox
        Me._TextCil_23 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._TextCil_14 = New System.Windows.Forms.TextBox
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me._TextCil_11 = New System.Windows.Forms.TextBox
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._TextCil_9 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._LabelCil_34 = New System.Windows.Forms.Label
        Me._LabelCil_33 = New System.Windows.Forms.Label
        Me._LabelCil_32 = New System.Windows.Forms.Label
        Me._LabelCil_31 = New System.Windows.Forms.Label
        Me._LabelCil_29 = New System.Windows.Forms.Label
        Me._LabelCil_28 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me._Frames_1 = New System.Windows.Forms.GroupBox
        Me._TextCil_25 = New System.Windows.Forms.NumericUpDown
        Me._TextCil_22 = New System.Windows.Forms.TextBox
        Me._TextCil_21 = New System.Windows.Forms.TextBox
        Me._TextCil_20 = New System.Windows.Forms.TextBox
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me._TextCil_19 = New System.Windows.Forms.TextBox
        Me._cmbCil_4 = New System.Windows.Forms.ComboBox
        Me._cmbCil_3 = New System.Windows.Forms.ComboBox
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me._LabelCil_30 = New System.Windows.Forms.Label
        Me._LabelCil_27 = New System.Windows.Forms.Label
        Me._LabelCil_26 = New System.Windows.Forms.Label
        Me._LabelCil_25 = New System.Windows.Forms.Label
        Me._LabelCil_24 = New System.Windows.Forms.Label
        Me._LabelCil_21 = New System.Windows.Forms.Label
        Me._LabelCil_20 = New System.Windows.Forms.Label
        Me._LabelCil_19 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.chkApp2 = New System.Windows.Forms.CheckBox
        Me.cmdBoltMat = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me._Frames_3 = New System.Windows.Forms.GroupBox
        Me.cmbMatBolt = New System.Windows.Forms.ComboBox
        Me._Frames_2.SuspendLayout()
        Me._Frames_0.SuspendLayout()
        Me.framSleeve.SuspendLayout()
        Me._Frames_1.SuspendLayout()
        CType(Me._TextCil_25, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._Frames_3.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkAgganciatoN
        '
        Me.chkAgganciatoN.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoN, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoN, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoN.Location = New System.Drawing.Point(240, 50)
        Me.chkAgganciatoN.Name = "chkAgganciatoN"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoN, True)
        Me.chkAgganciatoN.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoN.TabIndex = 98
        Me.chkAgganciatoN.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoN, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciatoF
        '
        Me.chkAgganciatoF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoF, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoF, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoF.Location = New System.Drawing.Point(240, 68)
        Me.chkAgganciatoF.Name = "chkAgganciatoF"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoF, True)
        Me.chkAgganciatoF.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoF.TabIndex = 99
        Me.chkAgganciatoF.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoF, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciatoP
        '
        Me.chkAgganciatoP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoP, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoP, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoP.Location = New System.Drawing.Point(436, 6)
        Me.chkAgganciatoP.Name = "chkAgganciatoP"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoP, True)
        Me.chkAgganciatoP.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoP.TabIndex = 99
        Me.chkAgganciatoP.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoP, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkBoltMat
        '
        Me.chkBoltMat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBoltMat.Enabled = False
        Me.chkBoltMat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkBoltMat, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkBoltMat, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkBoltMat.Location = New System.Drawing.Point(176, 28)
        Me.chkBoltMat.Name = "chkBoltMat"
        Me.HelpProvider1.SetShowHelp(Me.chkBoltMat, True)
        Me.chkBoltMat.Size = New System.Drawing.Size(56, 24)
        Me.chkBoltMat.TabIndex = 103
        Me.chkBoltMat.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkBoltMat, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        '_cmdCil_14
        '
        Me._cmdCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_14.Image = CType(resources.GetObject("_cmdCil_14.Image"), System.Drawing.Image)
        Me._cmdCil_14.Location = New System.Drawing.Point(272, 440)
        Me._cmdCil_14.Name = "_cmdCil_14"
        Me._cmdCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_14.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_14.TabIndex = 96
        Me._cmdCil_14.TabStop = False
        Me._cmdCil_14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_14, "Calcola il valore definito dal codice")
        '
        '_cmdCil_11
        '
        Me._cmdCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_11.Image = CType(resources.GetObject("_cmdCil_11.Image"), System.Drawing.Image)
        Me._cmdCil_11.Location = New System.Drawing.Point(272, 387)
        Me._cmdCil_11.Name = "_cmdCil_11"
        Me._cmdCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_11.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_11.TabIndex = 79
        Me._cmdCil_11.TabStop = False
        Me._cmdCil_11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_11, "Fornisce il valore minimo richiesto dal codice (Ad-613)")
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(520, 472)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(49, 25)
        Me.Command2.TabIndex = 70
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(520, 496)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(49, 25)
        Me.Command1.TabIndex = 62
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        '_Frames_2
        '
        Me._Frames_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_2.Controls.Add(Me.cmbMatPad)
        Me._Frames_2.Controls.Add(Me._cmdCil_3)
        Me._Frames_2.Controls.Add(Me._TextCil_18)
        Me._Frames_2.Controls.Add(Me._cmdCil_2)
        Me._Frames_2.Controls.Add(Me._TextCil_15)
        Me._Frames_2.Controls.Add(Me._TextCil_16)
        Me._Frames_2.Controls.Add(Me._LabelCil_23)
        Me._Frames_2.Controls.Add(Me._LabelCil_22)
        Me._Frames_2.Controls.Add(Me._LabelCil_17)
        Me._Frames_2.Controls.Add(Me._LabelCil_18)
        Me._Frames_2.Controls.Add(Me.chkAgganciatoP)
        Me._Frames_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frames_2.Location = New System.Drawing.Point(8, 472)
        Me._Frames_2.Name = "_Frames_2"
        Me._Frames_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_2.Size = New System.Drawing.Size(497, 56)
        Me._Frames_2.TabIndex = 52
        Me._Frames_2.TabStop = False
        '
        'cmbMatPad
        '
        Me.cmbMatPad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatPad.Location = New System.Drawing.Point(296, 8)
        Me.cmbMatPad.Name = "cmbMatPad"
        Me.cmbMatPad.Size = New System.Drawing.Size(120, 21)
        Me.cmbMatPad.TabIndex = 100
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(472, 27)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_3.TabIndex = 57
        Me._cmdCil_3.TabStop = False
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_18
        '
        Me._TextCil_18.AcceptsReturn = True
        Me._TextCil_18.AutoSize = False
        Me._TextCil_18.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_18.Location = New System.Drawing.Point(392, 27)
        Me._TextCil_18.MaxLength = 0
        Me._TextCil_18.Name = "_TextCil_18"
        Me._TextCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_18.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_18.TabIndex = 20
        Me._TextCil_18.Text = ""
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(416, 8)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 55
        Me._cmdCil_2.TabStop = False
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_15
        '
        Me._TextCil_15.AcceptsReturn = True
        Me._TextCil_15.AutoSize = False
        Me._TextCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_15, "")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_15, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me._TextCil_15, "")
        Me._TextCil_15.Location = New System.Drawing.Point(144, 8)
        Me._TextCil_15.MaxLength = 0
        Me._TextCil_15.Name = "_TextCil_15"
        Me._TextCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_15, True)
        Me._TextCil_15.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_15.TabIndex = 17
        Me._TextCil_15.Text = "Text1"
        '
        '_TextCil_16
        '
        Me._TextCil_16.AcceptsReturn = True
        Me._TextCil_16.AutoSize = False
        Me._TextCil_16.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_16.Location = New System.Drawing.Point(144, 32)
        Me._TextCil_16.MaxLength = 0
        Me._TextCil_16.Name = "_TextCil_16"
        Me._TextCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_16.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_16.TabIndex = 18
        Me._TextCil_16.Text = "Text1"
        '
        '_LabelCil_23
        '
        Me._LabelCil_23.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_23.Location = New System.Drawing.Point(224, 28)
        Me._LabelCil_23.Name = "_LabelCil_23"
        Me._LabelCil_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_23.Size = New System.Drawing.Size(152, 17)
        Me._LabelCil_23.TabIndex = 58
        Me._LabelCil_23.Tag = "kPress"
        Me._LabelCil_23.Text = "Allowable stress"
        '
        '_LabelCil_22
        '
        Me._LabelCil_22.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_22.Location = New System.Drawing.Point(224, 9)
        Me._LabelCil_22.Name = "_LabelCil_22"
        Me._LabelCil_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_22.Size = New System.Drawing.Size(73, 17)
        Me._LabelCil_22.TabIndex = 56
        Me._LabelCil_22.Text = "Pad Material"
        '
        '_LabelCil_17
        '
        Me._LabelCil_17.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_17, "")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_17, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me._LabelCil_17, "")
        Me._LabelCil_17.Location = New System.Drawing.Point(8, 9)
        Me._LabelCil_17.Name = "_LabelCil_17"
        Me._LabelCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_17, True)
        Me._LabelCil_17.Size = New System.Drawing.Size(136, 17)
        Me._LabelCil_17.TabIndex = 54
        Me._LabelCil_17.Tag = "kLength"
        Me._LabelCil_17.Text = "Pad Diameter"
        '
        '_LabelCil_18
        '
        Me._LabelCil_18.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_18.Location = New System.Drawing.Point(8, 28)
        Me._LabelCil_18.Name = "_LabelCil_18"
        Me._LabelCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_18.Size = New System.Drawing.Size(144, 17)
        Me._LabelCil_18.TabIndex = 53
        Me._LabelCil_18.Tag = "kLength"
        Me._LabelCil_18.Text = "Pad thickness"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(320, 8)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(249, 225)
        Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Picture1.TabIndex = 47
        Me.Picture1.TabStop = False
        '
        '_Frames_0
        '
        Me._Frames_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_0.Controls.Add(Me.framSleeve)
        Me._Frames_0.Controls.Add(Me.chkCategA)
        Me._Frames_0.Controls.Add(Me._TextCil_13)
        Me._Frames_0.Controls.Add(Me._TextCil_1)
        Me._Frames_0.Controls.Add(Me._TextCil_12)
        Me._Frames_0.Controls.Add(Me._cmbCil_5)
        Me._Frames_0.Controls.Add(Me._cmbCil_0)
        Me._Frames_0.Controls.Add(Me.cmbMatFl)
        Me._Frames_0.Controls.Add(Me.cmbMat)
        Me._Frames_0.Controls.Add(Me._cmdCil_15)
        Me._Frames_0.Controls.Add(Me._cmdCil_14)
        Me._Frames_0.Controls.Add(Me._TextCil_29)
        Me._Frames_0.Controls.Add(Me._cmdCil_13)
        Me._Frames_0.Controls.Add(Me._TextCil_28)
        Me._Frames_0.Controls.Add(Me._TextCil_27)
        Me._Frames_0.Controls.Add(Me._cmdCil_12)
        Me._Frames_0.Controls.Add(Me._cmdCil_11)
        Me._Frames_0.Controls.Add(Me._TextCil_24)
        Me._Frames_0.Controls.Add(Me._TextCil_23)
        Me._Frames_0.Controls.Add(Me._TextCil_2)
        Me._Frames_0.Controls.Add(Me._cmdCil_5)
        Me._Frames_0.Controls.Add(Me._TextCil_14)
        Me._Frames_0.Controls.Add(Me.Check1)
        Me._Frames_0.Controls.Add(Me._TextCil_11)
        Me._Frames_0.Controls.Add(Me._TextCil_6)
        Me._Frames_0.Controls.Add(Me._TextCil_4)
        Me._Frames_0.Controls.Add(Me._TextCil_3)
        Me._Frames_0.Controls.Add(Me._cmbCil_1)
        Me._Frames_0.Controls.Add(Me._TextCil_5)
        Me._Frames_0.Controls.Add(Me._TextCil_7)
        Me._Frames_0.Controls.Add(Me._TextCil_8)
        Me._Frames_0.Controls.Add(Me._TextCil_9)
        Me._Frames_0.Controls.Add(Me._TextCil_10)
        Me._Frames_0.Controls.Add(Me._cmdCil_0)
        Me._Frames_0.Controls.Add(Me._cmdCil_1)
        Me._Frames_0.Controls.Add(Me._LabelCil_34)
        Me._Frames_0.Controls.Add(Me._LabelCil_33)
        Me._Frames_0.Controls.Add(Me._LabelCil_32)
        Me._Frames_0.Controls.Add(Me._LabelCil_31)
        Me._Frames_0.Controls.Add(Me._LabelCil_29)
        Me._Frames_0.Controls.Add(Me._LabelCil_28)
        Me._Frames_0.Controls.Add(Me._LabelCil_16)
        Me._Frames_0.Controls.Add(Me._LabelCil_15)
        Me._Frames_0.Controls.Add(Me._LabelCil_14)
        Me._Frames_0.Controls.Add(Me._LabelCil_13)
        Me._Frames_0.Controls.Add(Me._LabelCil_8)
        Me._Frames_0.Controls.Add(Me._LabelCil_6)
        Me._Frames_0.Controls.Add(Me._LabelCil_5)
        Me._Frames_0.Controls.Add(Me._LabelCil_4)
        Me._Frames_0.Controls.Add(Me._LabelCil_3)
        Me._Frames_0.Controls.Add(Me._LabelCil_2)
        Me._Frames_0.Controls.Add(Me._LabelCil_1)
        Me._Frames_0.Controls.Add(Me._LabelCil_0)
        Me._Frames_0.Controls.Add(Me._LabelCil_7)
        Me._Frames_0.Controls.Add(Me._LabelCil_9)
        Me._Frames_0.Controls.Add(Me._LabelCil_10)
        Me._Frames_0.Controls.Add(Me._LabelCil_11)
        Me._Frames_0.Controls.Add(Me._LabelCil_12)
        Me._Frames_0.Controls.Add(Me.chkAgganciatoN)
        Me._Frames_0.Controls.Add(Me.chkAgganciatoF)
        Me._Frames_0.ForeColor = System.Drawing.Color.Blue
        Me._Frames_0.Location = New System.Drawing.Point(8, 8)
        Me._Frames_0.Name = "_Frames_0"
        Me._Frames_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_0.Size = New System.Drawing.Size(305, 465)
        Me._Frames_0.TabIndex = 0
        Me._Frames_0.TabStop = False
        '
        'framSleeve
        '
        Me.framSleeve.BackColor = System.Drawing.SystemColors.Control
        Me.framSleeve.Controls.Add(Me.Command3)
        Me.framSleeve.Controls.Add(Me.Label1)
        Me.framSleeve.Cursor = System.Windows.Forms.Cursors.Default
        Me.framSleeve.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framSleeve.Location = New System.Drawing.Point(8, 184)
        Me.framSleeve.Name = "framSleeve"
        Me.framSleeve.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framSleeve.Size = New System.Drawing.Size(289, 33)
        Me.framSleeve.TabIndex = 91
        Me.framSleeve.Text = "Frame1"
        Me.framSleeve.Visible = False
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(232, 0)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(49, 25)
        Me.Command3.TabIndex = 93
        Me.Command3.TabStop = False
        Me.Command3.Text = "Help"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(289, 14)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Il tronchetto non è disponibile per il rinforzo"
        '
        'chkCategA
        '
        Me.chkCategA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCategA.Location = New System.Drawing.Point(152, 181)
        Me.chkCategA.Name = "chkCategA"
        Me.chkCategA.Size = New System.Drawing.Size(144, 16)
        Me.chkCategA.TabIndex = 102
        Me.chkCategA.Text = "Throu a Cat.A joint"
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(192, 162)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_13.TabIndex = 7
        Me._TextCil_13.Text = "Text1"
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(192, 143)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_1.TabIndex = 6
        Me._TextCil_1.Text = "Text1"
        '
        '_TextCil_12
        '
        Me._TextCil_12.AcceptsReturn = True
        Me._TextCil_12.AutoSize = False
        Me._TextCil_12.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_12.Location = New System.Drawing.Point(192, 124)
        Me._TextCil_12.MaxLength = 0
        Me._TextCil_12.Name = "_TextCil_12"
        Me._TextCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_12.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_12.TabIndex = 5
        Me._TextCil_12.Text = "Text1"
        '
        '_cmbCil_5
        '
        Me._cmbCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_5.Location = New System.Drawing.Point(192, 105)
        Me._cmbCil_5.Name = "_cmbCil_5"
        Me._cmbCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_5.Size = New System.Drawing.Size(73, 21)
        Me._cmbCil_5.TabIndex = 63
        Me._cmbCil_5.Text = "Comb"
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(192, 88)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(73, 21)
        Me._cmbCil_0.TabIndex = 3
        '
        'cmbMatFl
        '
        Me.cmbMatFl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatFl.Location = New System.Drawing.Point(96, 70)
        Me.cmbMatFl.Name = "cmbMatFl"
        Me.cmbMatFl.Size = New System.Drawing.Size(120, 21)
        Me.cmbMatFl.TabIndex = 101
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.Location = New System.Drawing.Point(96, 52)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(120, 21)
        Me.cmbMat.TabIndex = 100
        '
        '_cmdCil_15
        '
        Me._cmdCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_15.Image = CType(resources.GetObject("_cmdCil_15.Image"), System.Drawing.Image)
        Me._cmdCil_15.Location = New System.Drawing.Point(272, 422)
        Me._cmdCil_15.Name = "_cmdCil_15"
        Me._cmdCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_15.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_15.TabIndex = 97
        Me._cmdCil_15.TabStop = False
        Me._cmdCil_15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_29
        '
        Me._TextCil_29.AcceptsReturn = True
        Me._TextCil_29.AutoSize = False
        Me._TextCil_29.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_29, "DatiAperture.htm#TempRange")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_29, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_29.Location = New System.Drawing.Point(192, 440)
        Me._TextCil_29.MaxLength = 0
        Me._TextCil_29.Name = "_TextCil_29"
        Me._TextCil_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_29, True)
        Me._TextCil_29.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_29.TabIndex = 94
        Me._TextCil_29.Text = "Text1"
        '
        '_cmdCil_13
        '
        Me._cmdCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_13.Image = CType(resources.GetObject("_cmdCil_13.Image"), System.Drawing.Image)
        Me._cmdCil_13.Location = New System.Drawing.Point(272, 367)
        Me._cmdCil_13.Name = "_cmdCil_13"
        Me._cmdCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_13.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_13.TabIndex = 90
        Me._cmdCil_13.TabStop = False
        Me._cmdCil_13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_28
        '
        Me._TextCil_28.AcceptsReturn = True
        Me._TextCil_28.AutoSize = False
        Me._TextCil_28.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_28.Location = New System.Drawing.Point(192, 366)
        Me._TextCil_28.MaxLength = 0
        Me._TextCil_28.Name = "_TextCil_28"
        Me._TextCil_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_28.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_28.TabIndex = 88
        Me._TextCil_28.Text = "Text1"
        '
        '_TextCil_27
        '
        Me._TextCil_27.AcceptsReturn = True
        Me._TextCil_27.AutoSize = False
        Me._TextCil_27.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_27.Location = New System.Drawing.Point(192, 422)
        Me._TextCil_27.MaxLength = 0
        Me._TextCil_27.Name = "_TextCil_27"
        Me._TextCil_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_27.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_27.TabIndex = 87
        Me._TextCil_27.Text = "Text1"
        '
        '_cmdCil_12
        '
        Me._cmdCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_12.Image = CType(resources.GetObject("_cmdCil_12.Image"), System.Drawing.Image)
        Me._cmdCil_12.Location = New System.Drawing.Point(216, 70)
        Me._cmdCil_12.Name = "_cmdCil_12"
        Me._cmdCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_12.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_12.TabIndex = 84
        Me._cmdCil_12.TabStop = False
        Me._cmdCil_12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_24
        '
        Me._TextCil_24.AcceptsReturn = True
        Me._TextCil_24.AutoSize = False
        Me._TextCil_24.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_24.Location = New System.Drawing.Point(192, 403)
        Me._TextCil_24.MaxLength = 0
        Me._TextCil_24.Name = "_TextCil_24"
        Me._TextCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_24.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_24.TabIndex = 78
        Me._TextCil_24.Text = "Text1"
        '
        '_TextCil_23
        '
        Me._TextCil_23.AcceptsReturn = True
        Me._TextCil_23.AutoSize = False
        Me._TextCil_23.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_23.Location = New System.Drawing.Point(192, 384)
        Me._TextCil_23.MaxLength = 0
        Me._TextCil_23.Name = "_TextCil_23"
        Me._TextCil_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_23.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_23.TabIndex = 76
        Me._TextCil_23.Text = "Text1"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(120, 128)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(55, 19)
        Me._TextCil_2.TabIndex = 4
        Me._TextCil_2.Text = "Text1"
        Me._TextCil_2.Visible = False
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(272, 161)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 64
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_14
        '
        Me._TextCil_14.AcceptsReturn = True
        Me._TextCil_14.AutoSize = False
        Me._TextCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_14.Location = New System.Drawing.Point(192, 347)
        Me._TextCil_14.MaxLength = 0
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_14.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_14.TabIndex = 16
        Me._TextCil_14.Text = "Text1"
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 181)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(144, 17)
        Me.Check1.TabIndex = 45
        Me.Check1.Text = "For access / inspection"
        '
        '_TextCil_11
        '
        Me._TextCil_11.AcceptsReturn = True
        Me._TextCil_11.AutoSize = False
        Me._TextCil_11.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_11.Location = New System.Drawing.Point(120, 14)
        Me._TextCil_11.MaxLength = 0
        Me._TextCil_11.Name = "_TextCil_11"
        Me._TextCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_11.Size = New System.Drawing.Size(145, 20)
        Me._TextCil_11.TabIndex = 1
        Me._TextCil_11.Text = ""
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(192, 254)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_6.TabIndex = 11
        Me._TextCil_6.Text = "Text1"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 216)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 9
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(192, 198)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 8
        Me._TextCil_3.Text = "Text1"
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_1.Location = New System.Drawing.Point(96, 32)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_1.Size = New System.Drawing.Size(201, 21)
        Me._cmbCil_1.TabIndex = 2
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(192, 235)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_5.TabIndex = 10
        Me._TextCil_5.Text = "Text1"
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(192, 273)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_7.TabIndex = 12
        Me._TextCil_7.Text = "Text1"
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_8, "DatiAperture.htm#Case8")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_8, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_8.Location = New System.Drawing.Point(192, 291)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_8, True)
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 13
        Me._TextCil_8.Text = "Text1"
        '
        '_TextCil_9
        '
        Me._TextCil_9.AcceptsReturn = True
        Me._TextCil_9.AutoSize = False
        Me._TextCil_9.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_9, "DatiAperture.htm#Case7")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_9, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me._TextCil_9, "")
        Me._TextCil_9.Location = New System.Drawing.Point(192, 328)
        Me._TextCil_9.MaxLength = 0
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_9, True)
        Me._TextCil_9.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_9.TabIndex = 15
        Me._TextCil_9.Text = "Text1"
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_10, "DatiAperture.htm#Case6")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_10, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_10.Location = New System.Drawing.Point(192, 309)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_10, True)
        Me._TextCil_10.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_10.TabIndex = 14
        Me._TextCil_10.Text = "Text1"
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(216, 52)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 27
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(272, 253)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 26
        Me._cmdCil_1.TabStop = False
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_34
        '
        Me._LabelCil_34.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_34, "DatiAperture.htm#TempRange")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_34, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_34.Location = New System.Drawing.Point(8, 441)
        Me._LabelCil_34.Name = "_LabelCil_34"
        Me._LabelCil_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_34, True)
        Me._LabelCil_34.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_34.TabIndex = 95
        Me._LabelCil_34.Tag = "kTemp"
        Me._LabelCil_34.Text = "Operating temperature range"
        '
        '_LabelCil_33
        '
        Me._LabelCil_33.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_33.Location = New System.Drawing.Point(8, 367)
        Me._LabelCil_33.Name = "_LabelCil_33"
        Me._LabelCil_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_33.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_33.TabIndex = 89
        Me._LabelCil_33.Tag = "kLength"
        Me._LabelCil_33.Text = "Transition radius r1"
        '
        '_LabelCil_32
        '
        Me._LabelCil_32.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_32.Location = New System.Drawing.Point(8, 423)
        Me._LabelCil_32.Name = "_LabelCil_32"
        Me._LabelCil_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_32.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_32.TabIndex = 86
        Me._LabelCil_32.Tag = "kLength"
        Me._LabelCil_32.Text = "Shell thk in the nozzle area"
        '
        '_LabelCil_31
        '
        Me._LabelCil_31.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_31.Location = New System.Drawing.Point(8, 70)
        Me._LabelCil_31.Name = "_LabelCil_31"
        Me._LabelCil_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_31.Size = New System.Drawing.Size(88, 17)
        Me._LabelCil_31.TabIndex = 85
        Me._LabelCil_31.Text = "Flange Material"
        '
        '_LabelCil_29
        '
        Me._LabelCil_29.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_29.Location = New System.Drawing.Point(8, 404)
        Me._LabelCil_29.Name = "_LabelCil_29"
        Me._LabelCil_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_29.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_29.TabIndex = 77
        Me._LabelCil_29.Text = "Taper slope (deg)"
        '
        '_LabelCil_28
        '
        Me._LabelCil_28.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_28.Location = New System.Drawing.Point(8, 385)
        Me._LabelCil_28.Name = "_LabelCil_28"
        Me._LabelCil_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_28.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_28.TabIndex = 75
        Me._LabelCil_28.Tag = "kLength"
        Me._LabelCil_28.Text = "Transition radius r2"
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(8, 348)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_16.TabIndex = 46
        Me._LabelCil_16.Tag = "kLength"
        Me._LabelCil_16.Text = "Selfreinforced thickness"
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(8, 163)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_15.TabIndex = 44
        Me._LabelCil_15.Tag = "kLength"
        Me._LabelCil_15.Text = "Spessore tronchetto"
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(8, 125)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_14.TabIndex = 43
        Me._LabelCil_14.Tag = "kLength"
        Me._LabelCil_14.Text = "External diameter [mm]"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(8, 145)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_13.TabIndex = 42
        Me._LabelCil_13.Tag = "kLength"
        Me._LabelCil_13.Text = "Internal diameter [mm]"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 255)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_8.TabIndex = 41
        Me._LabelCil_8.Tag = "kPress"
        Me._LabelCil_8.Text = "Allowable stress"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 218)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 40
        Me._LabelCil_6.Tag = "kLength"
        Me._LabelCil_6.Text = "Clad or WO thk."
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 198)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_5.TabIndex = 39
        Me._LabelCil_5.Text = "Joint efficiency"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 106)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(161, 17)
        Me._LabelCil_4.TabIndex = 38
        Me._LabelCil_4.Text = "Nominal diameter [in]"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 88)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_3.TabIndex = 37
        Me._LabelCil_3.Text = "Rating"
        Me._LabelCil_3.Visible = False
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 52)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_2.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_2.TabIndex = 36
        Me._LabelCil_2.Text = "Nozzle Material"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(97, 17)
        Me._LabelCil_1.TabIndex = 35
        Me._LabelCil_1.Text = "Nozzle type"
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
        Me._LabelCil_0.TabIndex = 34
        Me._LabelCil_0.Text = "Nozzle identification"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 236)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_7.TabIndex = 33
        Me._LabelCil_7.Tag = "kLength"
        Me._LabelCil_7.Text = "Corrosion allowance"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 273)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_9.TabIndex = 32
        Me._LabelCil_9.Tag = ""
        Me._LabelCil_9.Text = "Mill undertolerance [%]"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_10, "DatiAperture.htm#Case8")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_10, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 291)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_10, True)
        Me._LabelCil_10.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_10.TabIndex = 31
        Me._LabelCil_10.Tag = "kLength"
        Me._LabelCil_10.Text = "Reinforcement height"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_11, "DatiAperture.htm#Case7")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_11, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 328)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_11, True)
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 30
        Me._LabelCil_11.Tag = "kLength"
        Me._LabelCil_11.Text = "Available shell length"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_12, "DatiAperture.htm#Case6")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_12, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 310)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_12, True)
        Me._LabelCil_12.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_12.TabIndex = 29
        Me._LabelCil_12.Tag = "kLength"
        Me._LabelCil_12.Text = "Available height"
        '
        '_Frames_1
        '
        Me._Frames_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_1.Controls.Add(Me._TextCil_25)
        Me._Frames_1.Controls.Add(Me._TextCil_22)
        Me._Frames_1.Controls.Add(Me._TextCil_21)
        Me._Frames_1.Controls.Add(Me._TextCil_20)
        Me._Frames_1.Controls.Add(Me._cmdCil_4)
        Me._Frames_1.Controls.Add(Me._TextCil_19)
        Me._Frames_1.Controls.Add(Me._cmbCil_4)
        Me._Frames_1.Controls.Add(Me._cmbCil_3)
        Me._Frames_1.Controls.Add(Me._cmbCil_2)
        Me._Frames_1.Controls.Add(Me._LabelCil_30)
        Me._Frames_1.Controls.Add(Me._LabelCil_27)
        Me._Frames_1.Controls.Add(Me._LabelCil_26)
        Me._Frames_1.Controls.Add(Me._LabelCil_25)
        Me._Frames_1.Controls.Add(Me._LabelCil_24)
        Me._Frames_1.Controls.Add(Me._LabelCil_21)
        Me._Frames_1.Controls.Add(Me._LabelCil_20)
        Me._Frames_1.Controls.Add(Me._LabelCil_19)
        Me._Frames_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frames_1.Location = New System.Drawing.Point(320, 248)
        Me._Frames_1.Name = "_Frames_1"
        Me._Frames_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_1.Size = New System.Drawing.Size(249, 161)
        Me._Frames_1.TabIndex = 48
        Me._Frames_1.TabStop = False
        '
        '_TextCil_25
        '
        Me._TextCil_25.Location = New System.Drawing.Point(168, 136)
        Me._TextCil_25.Name = "_TextCil_25"
        Me._TextCil_25.Size = New System.Drawing.Size(56, 20)
        Me._TextCil_25.TabIndex = 83
        '
        '_TextCil_22
        '
        Me._TextCil_22.AcceptsReturn = True
        Me._TextCil_22.AutoSize = False
        Me._TextCil_22.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_22.Location = New System.Drawing.Point(211, 48)
        Me._TextCil_22.MaxLength = 0
        Me._TextCil_22.Name = "_TextCil_22"
        Me._TextCil_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_22.Size = New System.Drawing.Size(33, 20)
        Me._TextCil_22.TabIndex = 73
        Me._TextCil_22.Text = "Text1"
        Me._TextCil_22.Visible = False
        '
        '_TextCil_21
        '
        Me._TextCil_21.AcceptsReturn = True
        Me._TextCil_21.AutoSize = False
        Me._TextCil_21.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_21.Location = New System.Drawing.Point(211, 10)
        Me._TextCil_21.MaxLength = 0
        Me._TextCil_21.Name = "_TextCil_21"
        Me._TextCil_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_21.Size = New System.Drawing.Size(33, 20)
        Me._TextCil_21.TabIndex = 72
        Me._TextCil_21.Text = "Text1"
        Me._TextCil_21.Visible = False
        '
        '_TextCil_20
        '
        Me._TextCil_20.AcceptsReturn = True
        Me._TextCil_20.AutoSize = False
        Me._TextCil_20.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_20.Location = New System.Drawing.Point(211, 30)
        Me._TextCil_20.MaxLength = 0
        Me._TextCil_20.Name = "_TextCil_20"
        Me._TextCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_20.Size = New System.Drawing.Size(33, 20)
        Me._TextCil_20.TabIndex = 22
        Me._TextCil_20.Text = "Text1"
        Me._TextCil_20.Visible = False
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(80, 123)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 61
        Me._cmdCil_4.TabStop = False
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_19
        '
        Me._TextCil_19.AcceptsReturn = True
        Me._TextCil_19.AutoSize = False
        Me._TextCil_19.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_19.Location = New System.Drawing.Point(168, 107)
        Me._TextCil_19.MaxLength = 0
        Me._TextCil_19.Name = "_TextCil_19"
        Me._TextCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_19.Size = New System.Drawing.Size(76, 20)
        Me._TextCil_19.TabIndex = 25
        Me._TextCil_19.Text = "Text1"
        '
        '_cmbCil_4
        '
        Me._cmbCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_4.Location = New System.Drawing.Point(76, 87)
        Me._cmbCil_4.Name = "_cmbCil_4"
        Me._cmbCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_4.Size = New System.Drawing.Size(169, 21)
        Me._cmbCil_4.TabIndex = 24
        '
        '_cmbCil_3
        '
        Me._cmbCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_3.Location = New System.Drawing.Point(76, 68)
        Me._cmbCil_3.Name = "_cmbCil_3"
        Me._cmbCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_3.Size = New System.Drawing.Size(169, 21)
        Me._cmbCil_3.TabIndex = 23
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_2.Location = New System.Drawing.Point(76, 10)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_2.Size = New System.Drawing.Size(169, 21)
        Me._cmbCil_2.TabIndex = 21
        '
        '_LabelCil_30
        '
        Me._LabelCil_30.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_30.Location = New System.Drawing.Point(8, 140)
        Me._LabelCil_30.Name = "_LabelCil_30"
        Me._LabelCil_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_30.Size = New System.Drawing.Size(145, 17)
        Me._LabelCil_30.TabIndex = 82
        Me._LabelCil_30.Text = "Number of openings"
        '
        '_LabelCil_27
        '
        Me._LabelCil_27.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_27.Location = New System.Drawing.Point(8, 50)
        Me._LabelCil_27.Name = "_LabelCil_27"
        Me._LabelCil_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_27.Size = New System.Drawing.Size(201, 17)
        Me._LabelCil_27.TabIndex = 74
        Me._LabelCil_27.Text = "Configuration"
        Me._LabelCil_27.Visible = False
        '
        '_LabelCil_26
        '
        Me._LabelCil_26.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_26.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_26.Name = "_LabelCil_26"
        Me._LabelCil_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_26.Size = New System.Drawing.Size(201, 17)
        Me._LabelCil_26.TabIndex = 71
        Me._LabelCil_26.Text = "Configuration"
        Me._LabelCil_26.Visible = False
        '
        '_LabelCil_25
        '
        Me._LabelCil_25.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_25.Location = New System.Drawing.Point(8, 124)
        Me._LabelCil_25.Name = "_LabelCil_25"
        Me._LabelCil_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_25.Size = New System.Drawing.Size(81, 17)
        Me._LabelCil_25.TabIndex = 60
        Me._LabelCil_25.Text = "Weld details"
        '
        '_LabelCil_24
        '
        Me._LabelCil_24.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_24.Location = New System.Drawing.Point(8, 107)
        Me._LabelCil_24.Name = "_LabelCil_24"
        Me._LabelCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_24.Size = New System.Drawing.Size(128, 17)
        Me._LabelCil_24.TabIndex = 59
        Me._LabelCil_24.Tag = "kLength"
        Me._LabelCil_24.Text = "Protusion"
        '
        '_LabelCil_21
        '
        Me._LabelCil_21.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_21.Location = New System.Drawing.Point(8, 87)
        Me._LabelCil_21.Name = "_LabelCil_21"
        Me._LabelCil_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_21.Size = New System.Drawing.Size(57, 17)
        Me._LabelCil_21.TabIndex = 51
        Me._LabelCil_21.Text = "Sketch"
        '
        '_LabelCil_20
        '
        Me._LabelCil_20.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_20.Location = New System.Drawing.Point(8, 68)
        Me._LabelCil_20.Name = "_LabelCil_20"
        Me._LabelCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_20.Size = New System.Drawing.Size(72, 17)
        Me._LabelCil_20.TabIndex = 50
        Me._LabelCil_20.Text = "Configuration"
        '
        '_LabelCil_19
        '
        Me._LabelCil_19.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_19.Location = New System.Drawing.Point(8, 12)
        Me._LabelCil_19.Name = "_LabelCil_19"
        Me._LabelCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_19.Size = New System.Drawing.Size(193, 17)
        Me._LabelCil_19.TabIndex = 49
        Me._LabelCil_19.Text = "Location"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(248, 224)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(248, 224)
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageList3
        '
        Me.ImageList3.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
        Me.ImageList3.ImageSize = New System.Drawing.Size(248, 224)
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        '
        'chkApp2
        '
        Me.HelpProvider1.SetHelpKeyword(Me.chkApp2, "CalcFlBocc.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.chkApp2, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkApp2.Location = New System.Drawing.Point(8, 12)
        Me.chkApp2.Name = "chkApp2"
        Me.HelpProvider1.SetShowHelp(Me.chkApp2, True)
        Me.chkApp2.Size = New System.Drawing.Size(232, 16)
        Me.chkApp2.TabIndex = 0
        Me.chkApp2.Text = "Flange calculated to Appendix 2"
        '
        'cmdBoltMat
        '
        Me.cmdBoltMat.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBoltMat.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBoltMat.Enabled = False
        Me.cmdBoltMat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.cmdBoltMat, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.cmdBoltMat, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmdBoltMat.Image = CType(resources.GetObject("cmdBoltMat.Image"), System.Drawing.Image)
        Me.cmdBoltMat.Location = New System.Drawing.Point(152, 28)
        Me.cmdBoltMat.Name = "cmdBoltMat"
        Me.cmdBoltMat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.cmdBoltMat, True)
        Me.cmdBoltMat.Size = New System.Drawing.Size(20, 20)
        Me.cmdBoltMat.TabIndex = 101
        Me.cmdBoltMat.TabStop = False
        Me.cmdBoltMat.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.Label2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.Label2, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.Label2, True)
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Bolt Mat."
        '
        '_Frames_3
        '
        Me._Frames_3.Controls.Add(Me.cmbMatBolt)
        Me._Frames_3.Controls.Add(Me.cmdBoltMat)
        Me._Frames_3.Controls.Add(Me.Label2)
        Me._Frames_3.Controls.Add(Me.chkBoltMat)
        Me._Frames_3.Controls.Add(Me.chkApp2)
        Me._Frames_3.Location = New System.Drawing.Point(320, 416)
        Me._Frames_3.Name = "_Frames_3"
        Me._Frames_3.Size = New System.Drawing.Size(248, 56)
        Me._Frames_3.TabIndex = 71
        Me._Frames_3.TabStop = False
        '
        'cmbMatBolt
        '
        Me.cmbMatBolt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatBolt.Location = New System.Drawing.Point(56, 28)
        Me.cmbMatBolt.Name = "cmbMatBolt"
        Me.cmbMatBolt.Size = New System.Drawing.Size(96, 21)
        Me.cmbMatBolt.TabIndex = 104
        '
        'frmNoz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(578, 536)
        Me.Controls.Add(Me._Frames_3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Frames_2)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me._Frames_0)
        Me.Controls.Add(Me._Frames_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "DatiAperture.htm")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNoz"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Dati Apertura"
        Me._Frames_2.ResumeLayout(False)
        Me._Frames_0.ResumeLayout(False)
        Me.framSleeve.ResumeLayout(False)
        Me._Frames_1.ResumeLayout(False)
        CType(Me._TextCil_25, System.ComponentModel.ISupportInitialize).EndInit()
        Me._Frames_3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmNoz
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmNoz
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmNoz()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	' classificazione bocchelli div.2 Regola
	'1    AD-540.1   (a)                1
	'2               (b)                1
	'3               (c)                2
	'4               (d)                3
	'5    AD-610.1   (a)               12
	'6               (b)               12
	'7               (c)               11
	'8               (d)               11
	'9               (d-1)
	'10              (e)               11
	'11              (e-1)             11
	'12              (f)               12
	'13              (g)               11
	'14   AD-612.1   (a)
	'15              (b)
	'16              (c)
	'17              (d-1)              4
	'18              (d-2)              4
	'19   AD-613.1   (a)
	'20              (b)
	'21              (c)
	'22              (c-1)
	'23              (d)
	'24              (e)
	'25              (f)
	'26   AD-621.1   (a)
	'27              (b)
	'28              (c-1)              5
	'29              (c-2)              6
	'30              (c-3)              6
	'31                                 6
	'32   AD-610.1   (g)'              11
    '33   AD-610.1   (a)'              12
    Private TagImageList1() As String = {"UW-16.1 (a)", _
                                         "UW-16.1 (a)", _
                                         "UW-16.1 (a-1)", _
                                         "UW-16.1 (a-2)", _
                                         "UW-16.1 (a-3)", _
                                         "UW-16.1 (b)", _
                                         "UW-16.1 (c)", _
                                         "UW-16.1 (d)", _
                                         "UW-16.1 (e)", _
                                         "UW-16.1 (f-1)", _
                                         "UW-16.1 (f-2)", _
                                         "UW-16.1 (f-3)", _
                                         "UW-16.1 (f-4)", _
                                         "UW-16.1 (g)", _
                                         "UW-16.1 (h)", _
                                         "UW-16.1 (i)", _
                                         "UW-16.1 (j)", _
                                         "UW-16.1 (k)", _
                                         "UW-16.1 (l)", _
                                         "UW-16.1 (m)", _
                                         "UW-16.1 (n)", _
                                         "UW-16.1 (o)", _
                                         "UW-16.1 (p)", _
                                         "UW-16.1 (q)", _
                                         "UW-16.1 (r)", _
                                         "UW-16.1 (s)", _
                                         "UW-16.1 (t)", _
                                         "UW-16.1 (u)", _
                                         "UW-16.1 (v)", _
                                         "UW-16.1 (w)", _
                                         "UW-16.1 (x)", _
                                         "UW-16.1 (y)", _
                                         "UW-16.1 (z)", _
                                         "UHT-18.1", _
                                         "UHT-18.2", _
                                         "(open)", _
                                         "UHT-18.1 (d)", _
                                         "Son-sr"}
    Private TagImageList2() As String = {"AD-540.1 (a)", _
                                         "AD-540.1 (a)", _
                                         "AD-540.1 (b)", _
                                         "AD-540.1 (c)", _
                                         "AD-540.1 (d)", _
                                         "AD-610.1 (a)", _
                                         "AD-610.1 (b)", _
                                         "AD-610.1 (c)", _
                                         "AD-610.1 (d)", _
                                         "AD-610.1 (d-1)", _
                                         "AD-610.1 (e)", _
                                         "AD-610.1 (e-1)", _
                                         "AD-610.1 (f)", _
                                         "AD-610.1 (g)", _
                                         "AD-612.1 (a)", _
                                         "AD-612.1 (b)", _
                                         "AD-612.1 (c)", _
                                         "AD-612.1 (d-1)", _
                                         "AD-612.1 (d-2)", _
                                         "AD-613.1 (a)", _
                                         "AD-613.1 (b)", _
                                         "AD-613.1 (c)", _
                                         "AD-613.1 (c-1)", _
                                         "AD-613.1 (d)", _
                                         "AD-613.1 (e)", _
                                         "AD-613.1 (f)", _
                                         "AD-621.1 (a)", _
                                         "AD-621.1 (b)", _
                                         "AD-621.1 (c-1)", _
                                         "AD-621.1 (c-2)", _
                                         "AD-621.1 (c-3)", _
                                         "(open)", _
                                         "AD-610.1 (g)'", _
                                         "AD-610.1 (a)'"}
    Private TagImageList3() As String = {"9.4-1", _
                                         "9.4-2", _
                                         "9.4-3", _
                                         "9.4-4", _
                                         "9.4-5", _
                                         "9.4-6", _
                                         "9.4-7", _
                                         "9.4-8", _
                                         "9.4-9", _
                                         "9.4-10", _
                                         "9.4-11", _
                                         "9.4-13", _
                                         "9.5-1", _
                                         "9.5-2", _
                                         "9.5-3"}
    Public ListaImmagini As ImageList
    Public TagListaImmagini() As String
    Public Cancel As Boolean
    Private AllFRoo, AllFOpe, AllFHyd As Single
    Private Inizializzando As Boolean
    Private td1 As Single
    Private Posiz0(3) As String
	Private Posiz1(4) As String
	Private Posiz2(2) As String
	Private Posiz3(5) As String
	Private PosizC(4) As String 'per coperchio piano
	Private Stringa2(9) As String
    Private Stringa4(9) As String
	Private Stringa7(2) As String
	Private Stringa8(5) As String
	Private Const framSleeveTop As Single = 2720
    Private ang As Single
    Private Tipo As Short
    Private strTipo, strTL As String
    Private l As Short
    Private GiaAttivato As Boolean
    Private Sub Inizializza()
        Dim ifl, i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & "\ASME6.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 5 : Posiz3(i) = LineInput(ifl) : Posiz3(i) = VB.Left(Posiz3(i), Len(Posiz3(i)) - 1) : Next
        For i = 1 To 2 : Posiz2(i) = LineInput(ifl) : Posiz2(i) = VB.Left(Posiz2(i), Len(Posiz2(i)) - 1) : Next
        For i = 1 To 3 : Posiz0(i) = LineInput(ifl) : Posiz0(i) = VB.Left(Posiz0(i), Len(Posiz0(i)) - 1) : Next
        Posiz0(0) = "non definita"
        Posiz1(0) = Posiz0(0)
        Posiz2(0) = Posiz0(0)
        Posiz3(0) = Posiz0(0)
        '   Posiz0$(1) = "standard (radiale)            "
        '   Posiz0$(2) = "inclinato longitudinalmente   "
        '   Posiz0$(3) = "inclinato circonferenzialmente"
        For i = 1 To 4 : Posiz1(i) = LineInput(ifl) : Posiz1(i) = VB.Left(Posiz1(i), Len(Posiz1(i)) - 1) : Next
        '   Posiz1$(1) = "assiale centrato            "
        '   Posiz1$(2) = "radiale rispetto al fondo   "
        '   Posiz1$(3) = "radiale rispetto al cilindro"
        '   Posiz1$(4) = "assiale decentrato          "
        PosizC(0) = Posiz1(0) : PosizC(1) = Posiz1(1) : PosizC(2) = Posiz1(4)
        PosizC(3) = "su codolo grande"
        PosizC(4) = "su codolo piccolo"
        For i = 1 To 2 : Stringa7(i) = LineInput(ifl) : Stringa7(i) = VB.Left(Stringa7(i), Len(Stringa7(i)) - 1) : Next
        '   Stringa7$(1) = "YES"
        '   Stringa7$(2) = "NO "
        For i = 1 To 9 : Stringa2(i) = LineInput(ifl) : Stringa2(i) = VB.Left(Stringa2(i), Len(Stringa2(i)) - 1) : Next
        '50 Stringa2$(1) = "WN  :WN/SO        + tronchetto         "
        '   Stringa2$(2) = "WN1 :WN/SO        + tronchetto + pezza "
        '   Stringa2$(3) = "LWN :Standard LWN                      "
        '   Stringa2$(4) = "LWN1:Forgiato autorinf. Fig.UG-40(d)(e)"
        '   Stringa2$(5) = "LWN2:Forgiato con scarpa Fig.UG-40(f)  "
        '   Stringa2$(6) = "Sola:Verifica del solo rating          "
        For i = 0 To 8 : Stringa4(i + 1) = LineInput(ifl) : Next
        '   Stringa4$(1) = " 150"
        '   Stringa4$(2) = " 300"
        '   Stringa4$(3) = " 400"
        '   Stringa4$(4) = " 600"
        '   Stringa4$(5) = " 900"
        '   Stringa4$(6) = "1500"
        '   Stringa4$(7) = "2500"
        For i = 1 To 5 : Stringa8(i) = LineInput(ifl) : Next
        FileClose(ifl)
        SetImage()
        If VerificandoPI Then
            _LabelCil_23.Text = "Allowable Stress in H.T."
            _LabelCil_8.Text = "Allowable Stress in H.T."
        End If
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Check1.CheckState = CheckState.Checked Then Nozzles(kLato, kNozzle).Xacc = "X" Else Nozzles(kLato, kNozzle).Xacc = " "
    End Sub
    Private Sub cmbCil_SelectedIndexChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim iDisp As Short
        Dim Domand(2) As String
        Dim Rispost(2) As String
        Dim Archiv(2) As Short
        Dim dAiu(2) As String
        Dim k As Short
        Dim iAbu As Short
        k = kNozzle
        If Saltacombo Then Exit Sub
        Select Case Index
            Case 0 'Rating
                Nozzles(kLato, kNozzle).Rati = GlobalRoutines.ValVir(cmbCil(Index).Text)
                If _cmbCil_0.SelectedIndex = _cmbCil_0.Items.Count - 1 Then Nozzles(kLato, kNozzle).Rati = -1 ' non std
                AggMatFlan()
                AzzeraNonStd()
            Case 1 'Nozzle type
                Nozzles(kLato, kNozzle).Tipo = cmbCil(Index).Text.Substring(0, 4).Trim
                AggiornaAiuti()
                AggMatFlan()
                Select Case Nozzles(kLato, kNozzle).Tipo
                    Case "WN", "WN1", "OPEN"
                        Nozzles(kLato, kNozzle).HX = 0
                End Select
                If Not SaltaDati Then AggDatiNoz(kLato, jInvolucr, k)
                cmbCil_SelectedIndexChanged(3) '??????????????
                AzzeraNonStd()
            Case 2
                _LabelCil_26.Visible = False : _TextCil_20.Visible = False
                _LabelCil_27.Visible = False : _TextCil_22.Visible = False
                iDisp = cmbCil(Index).SelectedIndex
                AggiDisp(k, iDisp)
            Case 3 'configurazione
                iAbu = cmbCil(Index).SelectedIndex + 1
                If NAbu = 3 And iAbu = 3 And (div = 1 And Not Nozzles(kLato, k).Tipo = "LWN3") Then
                    iAbu = 5
                ElseIf NAbu = 3 And iAbu > 1 And (div = 0 Or div = 2) Then
                    iAbu = iAbu + 1
                ElseIf NAbu = 3 And iAbu > 2 And div = 1 Then
                    iAbu = iAbu + 1
                ElseIf (NAbu = 2 Or NAbu = 3) And iAbu = 2 And (div = 1 And Not Nozzles(kLato, k).Tipo = "LWN3") Then
                    iAbu = 3
                ElseIf NAbu = 0 And iAbu >= 2 Then
                    iAbu = iAbu + 1
                End If
                NozzAdd(kLato, k).TipAbutt = iAbu
                Saltacombo = True
                If Not SaltaDati Then AggDatiNoz(kLato, jInvolucr, k)
                Saltacombo = False
                cmbCil_SelectedIndexChanged(4) '??????????????????????
            Case 4 : AggImage(k)
                AggVisible(kLato, jInvolucr, k)
            Case 5
                '     For kk = 1 To 30
                '     If GlobaLroutines.ValVir(Risult$(Compr(5))) = mmm(1, kk) Then iTipoDV = kk: Exit For
                '     Next
                '  iTipoD = myListBox(3, 1, iTipoDV, M$(), 30, 0, "DN", True)
                Nozzles(kLato, k).DiaN = MMM(1, cmbCil(Index).SelectedIndex + 1)
                _TextCil_2.Text = GlobalRoutines.myStr(Nozzles(kLato, k).DiaN, 3, 3, False)
                ' _cmbCil_5.Text = mystr(Nozzles(kLato, k).DiaN, 3, 2, False)
                'iRegis = True
                Call Diametri(kLato, kNozzle, 0)
                'cmdCil_Click 5
                'Exit Sub
                AzzeraNonStd()
        End Select
        AggTesti(kNozzle)
    End Sub
    Private Sub AzzeraNonStd()
        Dim indice As Short = Nozzles(kLato, kNozzle).IndObject
        If indice > 0 Then
            CType(objMemb(indice), wn_flan).Mp(3) = 0
        End If
    End Sub
    Private Sub cmdCil_Click(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim Testo As String
        Dim kk, ii As Short
        Dim x As Short
        Dim Strin1(2) As String
        Dim rR2 As Single
        Select Case Index
            Case 0
                ' Nozzles(kLato, kNozzle).indice = NuovoIndice
                Matdim(Nozzles(kLato, kNozzle).indice).IndAdd(1, 1)
                Matdim(Nozzles(kLato, kNozzle).indice).IndAdd(1, 2)
                Matdim(Nozzles(kLato, kNozzle).indice).IndAdd(1, 6)
                Matdim(Nozzles(kLato, kNozzle).indice).IndAdd(1, 7)
                MatdimScelta(Nozzles(kLato, kNozzle).indice, Matdim(Nozzles(kLato, kNozzle).indice).Classe, _
                             kLato, , kNozzle)
                If Matdim(Nozzles(kLato, kNozzle).indice).Editato Then Uniforma(Nozzles(kLato, kNozzle).indice)
                Nozzles(kLato, kNozzle).RecInd = Matdim(Nozzles(kLato, kNozzle).indice).Indmat
                PostSelMat(cmbMat, Nozzles(kLato, kNozzle).indice)
                SubAmm()
                If InStr(Nozzles(kLato, kNozzle).Tipo, "LW") > 0 Then
                    If Nozzles(kLato, kNozzle).IndexF < 1 Then
                        Nozzles(kLato, kNozzle).IndexF = NuovoIndice()
                        indici.Add(Nozzles(kLato, kNozzle).IndexF)
                    End If
                    If Nozzles(kLato, kNozzle).RecIndF < 1 Then
                        Nozzles(kLato, kNozzle).RecIndF = Nozzles(kLato, kNozzle).RecInd
                        Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat = Nozzles(kLato, kNozzle).RecIndF
                        Matdim(Nozzles(kLato, kNozzle).IndexF).RecupMat(Monitor.Motore.Inizio.Archdir)
                        cmbMatFl.Text = Matdim(Nozzles(kLato, kNozzle).IndexF).MatStr
                    End If
                End If
                PopolacmbMat()
                AggTesti(kNozzle)
            Case 1
                SubAmm()
            Case 2
                If Nozzles(kLato, kNozzle).IndiceP = 0 Then
                    Nozzles(kLato, kNozzle).IndiceP = NuovoIndice()
                    indici.Add(Nozzles(kLato, kNozzle).IndiceP)
                End If
                If Matdim(Nozzles(kLato, kNozzle).IndiceP) Is Nothing Then
                    Matdim(Nozzles(kLato, kNozzle).IndiceP) = New LibMat.MaterialeNew1
                    Matdim(Nozzles(kLato, kNozzle).IndiceP).Indmat = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Indmat
                    Matdim(Nozzles(kLato, kNozzle).IndiceP).RecupMat(clsInizio.Archdir)
                End If
                Matdim(Nozzles(kLato, kNozzle).IndiceP).IndAdd(1, 1)
                Matdim(Nozzles(kLato, kNozzle).IndiceP).IndAdd(1, 2)
                Matdim(Nozzles(kLato, kNozzle).IndiceP).IndAdd(1, 6)
                Matdim(Nozzles(kLato, kNozzle).IndiceP).IndAdd(1, 7)
                MatdimScelta(Nozzles(kLato, kNozzle).IndiceP, 0, kLato, , kNozzle)
                If Matdim(Nozzles(kLato, kNozzle).IndiceP).Editato Then Uniforma(Nozzles(kLato, kNozzle).IndiceP)
                Nozzles(kLato, kNozzle).RecIndP = Matdim(Nozzles(kLato, kNozzle).IndiceP).Indmat
                PostSelMat(cmbMatPad, Nozzles(kLato, kNozzle).IndiceP)
                SubAmmP()
                PopolacmbMat()
                AggTesti(kNozzle)
            Case 3
                SubAmmP()
            Case 4 : Call WeldDet(kNozzle, 0)
                AggTesti(kNozzle)
            Case 5 'tronchetto
                'Screen.MousePointer = vbHourglass
                If Nozzles(kLato, kNozzle).Rati = 0 Then
                    x = 1
                ElseIf Not VB.Left(Nozzles(kLato, kNozzle).Tipo, 1) = "L" Then
                    Strin1(1) = "Libreria piping"
                    Strin1(2) = "Libreria Flange"
                    x = Monitor.Motore.Quale(2, "Tipo libreria", Strin1, "", 1)
                Else
                    x = 2
                End If
                Select Case x
                    Case 1
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto DiamNom(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        ii = DiamNom(kLato, kNozzle, 0)
                        '              CALL StdPipe(ii)
                        Tubo = New LibMat.clsPipe
                        Tubo.DoveMotore = Monitor.Motore
                        Tubo.Diam = MMM(2, ii)
                        Tubo.Scelta(clsInizio.Archdir, clsInizio.DiscoTem)
                        Nozzles(kLato, kNozzle).Spess = Tubo.Spess
                        '             If Abs(Tubo.Diam - GlobaLroutines.ValVir(_TextCil_12.Text)) > 1 Then
                        For kk = 1 To 30
                            If System.Math.Abs(Tubo.Diam - MMM(2, kk)) < 1 Then Exit For
                        Next
                        If kk < 31 Then
                            Nozzles(kLato, kNozzle).DiOn = MMM(2, kk)
                            Nozzles(kLato, kNozzle).DiaN = MMM(1, kk)
                        Else
                            Nozzles(kLato, kNozzle).DiOn = Tubo.Diam
                            Nozzles(kLato, kNozzle).DiaN = MMM(1, _cmbCil_5.SelectedIndex + 1)
                        End If
                        Nozzles(kLato, kNozzle).DiIn = Nozzles(kLato, kNozzle).DiOn - 2 * Nozzles(kLato, kNozzle).Spess
                        Tubo = Nothing
                    Case 2
                        ' If AddDistinta = 0 Then
                        ' Set Libgra = New Grafica.Libgra
                        ' Set Libgra.DoveMotore = Monitor.Motore
                        ' Set Libgra.DoveRoutines = Routines
                        ' End If
                        Flangia = New Grafica.Flangia
                        Flangia.DoveMotore = Monitor.Motore
                        ' Flangia.K1 = 1
                        ' Flangia.K2 = 1
                        Flangia.K3 = 1
                        If VB.Left(Nozzles(kLato, kNozzle).Tipo, 1) = "L" Then Flangia.K3 = 4
                        Flangia.Facing = 1
                        If Nozzles(kLato, kNozzle).indiceF = 0 Then Nozzles(kLato, kNozzle).indiceF = 1
                        Flangia.TabFlan = Nozzles(kLato, kNozzle).indiceF
                        Flangia.carica((clsInizio.DiscoRam))
                        Flangia.SetDiam(Nozzles(kLato, kNozzle).DiaN)
                        Flangia.SetRating(Nozzles(kLato, kNozzle).Rati)
                        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        Flangia.Scelta((clsInizio.DiscoRam))
                        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                        If Not Flangia.Annullato Then
                            Nozzles(kLato, kNozzle).DiOn = Flangia.DiamTr
                            Nozzles(kLato, kNozzle).DiIn = Flangia.DiamInt
                            Nozzles(kLato, kNozzle).Spess = (Flangia.DiamTr - Flangia.DiamInt) / 2
                            Nozzles(kLato, kNozzle).DiaN = GlobalRoutines.ConvPoll((Flangia.strDiam))
                            Nozzles(kLato, kNozzle).Rati = GlobalRoutines.ValVir(Flangia.strRati)
                            Nozzles(kLato, kNozzle).indiceF = Flangia.TabFlan
                            Nozzles(kLato, kNozzle).DiamExt = Flangia.DiamExt
                            Nozzles(kLato, kNozzle).Spessore = Flangia.Spessore
                            Nozzles(kLato, kNozzle).Altezza = Flangia.Altezza
                            If Flangia.K3 = 4 Then Nozzles(kLato, kNozzle).Altezza = Flangia.Spessore
                        End If
                        Flangia = Nothing
                End Select
                AggTesti(kNozzle)
                AggDatiNoz(kLato, jInvolucr, kNozzle)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Case 11
                rR2 = GlobalRoutines.ValVir(_TextCil_23.Text)
                If rR2 < 19 Then rR2 = 19
                Testo = "Il valore minimo richiesto dalla Fig.AD-613.1 è " & GlobalRoutines.myStr(rR2, 4, 2, False) & " mm"
                MessageBox.Show(Me, clsInizio.ConvertiCr(Testo), "AsmeVip - Dati Aperture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '_TextCil_23 = mystr(rR2, 4, 2, False)
            Case 12
                If Nozzles(kLato, kNozzle).IndexF < 0 Then
                    Nozzles(kLato, kNozzle).IndexF = NuovoIndice()
                    indici.Add(Nozzles(kLato, kNozzle).IndexF)
                End If
                If Matdim(Nozzles(kLato, kNozzle).IndexF) Is Nothing Then
                    Matdim(Nozzles(kLato, kNozzle).IndexF) = New LibMat.MaterialeNew1
                End If
                MatdimScelta(Nozzles(kLato, kNozzle).IndexF, 7, kLato, , kNozzle)
                If Matdim(Nozzles(kLato, kNozzle).IndexF).Editato Then Uniforma(Nozzles(kLato, kNozzle).IndexF)
                Nozzles(kLato, kNozzle).RecIndF = Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat
                PostSelMat(cmbMatFl, Nozzles(kLato, kNozzle).IndexF)
                PopolacmbMat()
                AggTesti(kNozzle)
            Case 13 'raggio r1 in div 2
                With Nozzles(kLato, kNozzle)
                    If .R1 < .ShThkNozArea / 8 Or .R1 > .ShThkNozArea / 2 Then
                        .R1 = Int(.ShThkNozArea / 8 + 1)
                    End If
                    If Config(0).Verbose Then
                        Testo = "  Il raggio di raccordo r1 deve essere compreso|"
                        Testo = Testo & "tra 1/8 e 1/2 dello spessore del mantello, e cioè|"
                        Testo = Testo & "tra " & GlobalRoutines.myStr(.ShThkNozArea / 8, 3, 1, False) & " e " & GlobalRoutines.myStr(.ShThkNozArea / 2, 3, 1, False) & "."
                        MessageBox.Show(Me, clsInizio.ConvertiCr(Testo), "AsmeVip - Dati Aperture", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    _TextCil_28.Text = GlobalRoutines.myStr(.R1, 4, 2, False)
                End With
            Case 14 'deltat per AD550(f)
                td1 = (TempDes() - 70) / 1.8
                _TextCil_29.Text = GlobalRoutines.myStr(td1, 4, 1, False)
                MostraAiuto(IDH_OP2_TEMPRANGE, RoutBase1.ChiaviMess.MessInformation Or RoutBase1.ChiaviMess.MessHelpButton Or RoutBase1.ChiaviMess.MessOkOnly)
            Case 15 'Shell thk in the nozzle area
                _TextCil_27.Text = GlobalRoutines.myStr(ShThkDefault, 4, 1, False)
        End Select
    End Sub
    Private Sub SubAmmP()
        If Matdim(Nozzles(kLato, kNozzle).IndiceP).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).IndiceP).Agganciato Then
            If VerificandoPI Then
                AllFOpe = Matdim(Nozzles(kLato, kNozzle).IndiceP).Yield() * FractSyPI
            Else
                Matdim(Nozzles(kLato, kNozzle).IndiceP).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
            End If
        Else
            Dim Testo As String = "Il materiale del pad del bocchello " & Trim(Nozzles(kLato, kNozzle).Mark) & " non è definito correttamente." & vbCrLf
            Testo = Testo & "Accedere alla libreria materiali tramite il pulsante apposito."
            MessageBox.Show(Me, Testo)
        End If 'j
        If VerificandoPI Then
            Nozzles(kLato, kNozzle).AllPadPI = AllFOpe
        Else
            Nozzles(kLato, kNozzle).AllPad = AllFOpe
        End If
        _TextCil_18.Text = GlobalRoutines.myStr(AllFOpe * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
    End Sub
    Private Sub SubAmm()
        AllFOpe = Nozzles(kLato, kNozzle).AllN
        AllFHyd = Nozzles(kLato, kNozzle).AllNPI
        If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
            If VerificandoPI Then
                AllFHyd = Matdim(Nozzles(kLato, kNozzle).indice).Yield() * FractSyPI
            Else
                Matdim(Nozzles(kLato, kNozzle).indice).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
            End If
        Else
            Dim Testo As String = "Il materiale del bocchello " & Trim(Nozzles(kLato, kNozzle).Mark) & " non è definito correttamente." & vbCrLf
            Testo = Testo & "Accedere alla libreria materiali tramite il pulsante apposito."
            MessageBox.Show(Me, Testo, "AsmeVip - Dati aperture", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If 'j
        If VerificandoPI Then
            _TextCil_6.Text = GlobalRoutines.myStr(AllFHyd * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Nozzles(kLato, kNozzle).AllNPI = AllFHyd
        Else
            _TextCil_6.Text = GlobalRoutines.myStr(AllFOpe * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Nozzles(kLato, kNozzle).AllN = AllFOpe
        End If
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        If Not _TextCil_14.Visible Then Nozzles(kLato, kNozzle).HX = Nozzles(kLato, kNozzle).Spess
        Cancel = False
        Hide()
        GiaAttivato = False
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        Hide()
        GiaAttivato = False
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, "AD500.htm#AD5501")
    End Sub
    Private Sub Inizializza1()
        Dim Log1 As Boolean
        Dim i As Short
        Dim iDisp, n As Short
        SetImage()
        _cmbCil_1.Items.Clear()
        If jInvolucr > 0 Then
            Log1 = Involucr(kLato, jInvolucr).Tipo = 5
        Else
            Log1 = False
        End If
        If Log1 Then
            _cmbCil_1.Items.Add(Stringa2(1))
            _cmbCil_1.Items.Add(Stringa2(3))
            _cmbCil_1.Items.Add(Stringa2(4))
            _cmbCil_1.Items.Add(Stringa2(9))
        Else
            n = 7
            If div = 1 Or div = 2 Then
                Stringa2(4) = "LWN1:Forgiato autorinforzato"
                Stringa2(5) = "LWN2:Forgiato con scarpa"
                Stringa2(6) = "LWN3:Pad e/o sleeve"
            End If
            For i = 1 To n
                _cmbCil_1.Items.Add(Stringa2(i))
            Next
            _cmbCil_1.Items.Add(Stringa2(9))
        End If
        If Log1 Then
            If SistCoorCop = 1 Then
                _LabelCil_25.Visible = False : _cmdCil_4.Visible = False
                _LabelCil_24.Visible = False : _TextCil_19.Visible = False
                _cmbCil_2.Visible = False : _TextCil_21.Visible = True
                _LabelCil_26.Text = "Y-coordinate on cover plane"
                _LabelCil_19.Text = "X-coordinate on cover plane"
                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                _LabelCil_19.Visible = True : _TextCil_21.Visible = True
            End If
        Else
            _LabelCil_26.Text = "Configuration" : _TextCil_20.Visible = False
            _LabelCil_25.Visible = True : _cmdCil_4.Visible = True
            _LabelCil_24.Visible = False : _TextCil_19.Visible = False
            _cmbCil_2.Visible = True : _TextCil_21.Visible = False
        End If
        _cmbCil_0.Items.Clear()
        Select Case Nozzles(kLato, kNozzle).indiceF
            Case 2, 3
                _cmbCil_0.Items.Add("75")
                For i = 1 To 6
                    _cmbCil_0.Items.Add(Stringa4(i))
                Next
                _cmbCil_0.Items.Add(Stringa4(9))
            Case 1
                For i = 1 To 9
                    _cmbCil_0.Items.Add(Stringa4(i))
                Next
            Case Else
                Nozzles(kLato, kNozzle).indiceF = 1
                For i = 1 To 9
                    _cmbCil_0.Items.Add(Stringa4(i))
                Next
        End Select
        _cmbCil_5.Items.Clear()
        For i = 1 To 30
            _cmbCil_5.Items.Add(diamNm(i))
        Next
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(2835)
        Picture1.Image = ListaImmagini.Images(1)
        WeldDet((kNozzle), 1)
        RetrDisp((kNozzle), iDisp)
        PopolacmbMat()
        AggDatiNoz((kLato), (jInvolucr), (kNozzle))
        If _cmbCil_2.Visible Then
            _cmbCil_2.SelectedIndex = iDisp
            AggiDisp(kNozzle, iDisp)
        End If
        Saltacombo = False
        _cmbCil_2.Enabled = True
        AggImage(kNozzle)
        AggiornaAiuti()
        Check1.Checked = Nozzles(kLato, kNozzle).Xacc = "X"
        If jInvolucr > 0 Then
            If Involucr(kLato, jInvolucr).ES < 1 Then
                chkCategA.Checked = Nozzles(kLato, kNozzle).MUN = 1.0!
                chkCategA.Enabled = True
            Else
                Nozzles(kLato, kNozzle).MUN = 0
                chkCategA.Enabled = False
            End If
        Else
            Nozzles(kLato, kNozzle).MUN = 0
            chkCategA.Enabled = False
        End If
        chkCategA.Checked = Nozzles(kLato, kNozzle).MUN = 1.0!
    End Sub
    Private Sub PopolacmbMat()
        Popola(cmbMat)
        Popola(cmbMatFl)
        Popola(cmbMatBolt)
        Popola(cmbMatPad)
    End Sub
    Private Sub AggiornaAiuti()
        Dim keyword As String
        HelpProvider1.SetHelpString(_TextCil_15, "")
        HelpProvider1.SetHelpString(_LabelCil_17, "")
        If Nozzles(kLato, kNozzle).Tipo = "LWN3" And (div = 0 Or div = 2) Then
            keyword = "DatiAPerture.htm#RagRacc"
            '     Testo = " Fornire il raggio di raccordo tra boc-|"
            '     Testo = Testo & "chello e mantello (min 19 mm).         |"
        ElseIf NozzAdd(kLato, kNozzle).UW16 < 4 And div = 1 Then
            keyword = Helpstringa(8000)
            HelpProvider1.SetHelpString(_TextCil_15, keyword)
            HelpProvider1.SetHelpString(_LabelCil_17, keyword)
            GoTo Cont
        ElseIf NozzAdd(kLato, kNozzle).UW16 = 4 And div = 1 Then
            keyword = "Bocch2Forg.htm"
        Else
            keyword = "DatiAperture.htm#PadD"
        End If
        HelpProvider1.SetHelpKeyword(_LabelCil_17, keyword)
        HelpProvider1.SetHelpKeyword(_TextCil_15, keyword)
Cont:
        If Nozzles(kLato, kNozzle).Tipo = "LWN3" And (div = 0 Or div = 2) Then
            keyword = "DatiAperture.htm#AreaFori"
            '           Testo = " Fornire l'area dei fori per prigio- | nieri eventualmente situata al-|"
            '           Testo = Testo & "l'interno dell'area di rinforzo."
        Else
            keyword = "DatiAperture.htm#PadT"
        End If
        HelpProvider1.SetHelpKeyword(_LabelCil_18, keyword)
        HelpProvider1.SetHelpKeyword(_TextCil_16, keyword)
    End Sub
    Private Sub _TextCil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_1.TextChanged
        TextCil_TextChanged(1)
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
    Private Sub _TextCil_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.TextChanged
        TextCil_TextChanged(14)
    End Sub
    Private Sub _TextCil_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_15.TextChanged
        TextCil_TextChanged(15)
    End Sub
    Private Sub _TextCil_16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_16.TextChanged
        TextCil_TextChanged(16)
    End Sub
    Private Sub _TextCil_18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_18.TextChanged
        TextCil_TextChanged(18)
    End Sub
    Private Sub _TextCil_19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_19.TextChanged
        TextCil_TextChanged(19)
    End Sub
    Private Sub _TextCil_20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_20.TextChanged
        TextCil_TextChanged(20)
    End Sub
    Private Sub _TextCil_21_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_21.TextChanged
        TextCil_TextChanged(21)
    End Sub
    Private Sub _TextCil_22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_22.TextChanged
        TextCil_TextChanged(22)
    End Sub
    Private Sub _TextCil_23_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_23.TextChanged
        TextCil_TextChanged(23)
    End Sub
    Private Sub _TextCil_24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_24.TextChanged
        TextCil_TextChanged(24)
    End Sub
    Private Sub _TextCil_27_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_27.TextChanged
        TextCil_TextChanged(27)
    End Sub
    Private Sub _TextCil_28_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_28.TextChanged
        TextCil_TextChanged(28)
    End Sub
    Private Sub _TextCil_29_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_29.TextChanged
        TextCil_TextChanged(29)
    End Sub
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim iDisp As Short
        With Nozzles(kLato, kNozzle)
            Select Case Index
                Case 0 : .MATE = TextCil(Index).Text
                Case 1 : .DiIn = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    If .DiOn > .DiIn Then
                        .Spess = (.DiOn - .DiIn) / 2
                    End If
                    AzzeraNonStd()
                    'Case 2: .DiaN = GlobaLroutines.ValVir(TextCil(Index))
                Case 3 : .EffN = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 4 : .ONn = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 5 : .CorrA = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 6
                    If VerificandoPI Then
                        .AllNPI = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        .AllN = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                Case 7 : .MNT = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 8 : .LX = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 9 : .LSDisp = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 10 : .LXdisp = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 11 : .Mark = TextCil(Index).Text
                Case 12 : .DiOn = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    If .DiOn > .DiIn Then
                        .Spess = (.DiOn - .DiIn) / 2
                    End If
                    AzzeraNonStd()
                Case 13 : .Spess = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    AzzeraNonStd()
                Case 14 : .HX = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 15 : .Padd = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 16 : .PadT = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 18
                    If VerificandoPI Then
                        .AllPadPI = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        .AllPad = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                Case 19 : NozzAdd(kLato, kNozzle).Protusion = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 20
                    If jInvolucr > 0 Then
                        If Involucr(kLato, jInvolucr).Tipo = 5 Then
                            .DTL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'nel caso di coperchi questa è la Y o la R
                        Else
Standard:
                            iDisp = _cmbCil_2.SelectedIndex
                            Select Case Involucr(kLato, jInvolucr).Tipo
                                Case 0
                                    Select Case iDisp
                                        Case 2 : Nozzles(kLato, kNozzle).beta = GlobalRoutines.ValVir(TextCil(Index).Text)
                                        Case 3 : Nozzles(kLato, kNozzle).DCL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                                            Nozzles(kLato, kNozzle).beta = 0
                                    End Select
                                Case 1
                                    Select Case iDisp
                                        Case 1 '"assiale centrato            "
                                        Case 2 : Nozzles(kLato, kNozzle).beta = GlobalRoutines.ValVir(TextCil(Index).Text) '"radiale rispetto al fondo   "
                                            Nozzles(kLato, kNozzle).DTL = 0
                                            Nozzles(kLato, kNozzle).DCL = 0
                                        Case 3 : Nozzles(kLato, kNozzle).DTL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength '"radiale rispetto al cilindro"
                                            Nozzles(kLato, kNozzle).beta = 0
                                            Nozzles(kLato, kNozzle).DCL = 0
                                        Case 4 : Nozzles(kLato, kNozzle).DCL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'assiale decentrato
                                            Nozzles(kLato, kNozzle).beta = 0
                                            Nozzles(kLato, kNozzle).DTL = 0
                                    End Select
                                Case 2, 3 : Nozzles(kLato, kNozzle).DCL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                                    'Case 5
                                    '       Select Case objMemb(Involucr(kLato, jInvolucr).IndObject).LOOSE
                                    '       Case 4 'coperchio
                                    '           Select Case iDisp
                                    '           Case 1: Nozzles(kLato, kNozzle).DCL = GlobaLroutines.ValVir(TextCil(Index))
                                    '                   Nozzles(kLato, kNozzle).beta = 0
                                    '                   Nozzles(kLato, kNozzle).DTL = 0
                                    '           End Select
                                    '       Case 5, 6
                                    '       Case 7
                                    '       Case Else
                                    '           Select Case iDisp
                                    '           Case 2: Nozzles(kLato, kNozzle).beta = GlobaLroutines.ValVir(TextCil(Index))
                                    '                   Nozzles(kLato, kNozzle).DTL = 0
                                    '                   Nozzles(kLato, kNozzle).DCL = 0
                                    '          Case 3: Nozzles(kLato, kNozzle).DTL = GlobaLroutines.ValVir(TextCil(Index))
                                    '                  Nozzles(kLato, kNozzle).beta = 0
                                    '                    Nozzles(kLato, kNozzle).DCL = 0
                                    '            Case 4: Nozzles(kLato, kNozzle).DCL = GlobaLroutines.ValVir(TextCil(Index))
                                    'assiale decentra'to
                                    '                    Nozzles(kLato, kNozzle).beta = 0
                                    '                    Nozzles(kLato, kNozzle).DTL = 0
                                    '           End Select
                                    '        End Select
                            End Select
                        End If
                    Else
                        iDisp = _cmbCil_2.SelectedIndex
                        Select Case iDisp
                            Case 2 : Nozzles(kLato, kNozzle).beta = GlobalRoutines.ValVir(TextCil(Index).Text)
                            Case 3 : Nozzles(kLato, kNozzle).DCL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                                Nozzles(kLato, kNozzle).beta = 0
                        End Select
                    End If
                Case 21 : .DCL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength ' nel caso di coperchi questa è la X
                Case 22 : .Anomal = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 23 : .R2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 24
                    .TransitionAngle = GlobalRoutines.ValVir(TextCil(Index).Text)
                    If .TransitionAngle < 45 And div = 1 Then .TransitionAngle = 45
                    If .TransitionAngle < 30 And div = 0 Then .TransitionAngle = 30
                    '  Case 25 : VariaBocc(_TextCil_25.Value, -1)
                Case 27 : .ShThkNozArea = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 28 : .R1 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 29 : .dtAD550f = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
            End Select
            If VB.Left(.Tipo, 1) = "W" Then .DiIn = .DiOn - 2 * .Spess
        End With
    End Sub

    Private Sub AggDatiNoz(ByRef KL As Short, ByRef j As Short, ByRef k As Short)
        Dim i, iAcc As Short
        Dim iDisp As Short
        Dim Sketch(50) As String
        Dim isk(50) As Short
        Dim Nsk, iScel As Short
        Dim Stringa88(5) As String
        Dim iAbu, Tipo As Short
        For i = 1 To 6
            If _cmbCil_1.Items(i - 1).substring(0, 4).trim = Nozzles(KL, k).Tipo.Trim Then
                _cmbCil_1.SelectedIndex = i - 1
                Exit For
            End If
        Next
        If Nozzles(KL, k).Rati = 0 Then
            'Nozzles(KL, k).Rati = GlobaLroutines.ValVir(Stringa4(1))
            _cmbCil_0.SelectedIndex = 0
        ElseIf Nozzles(KL, k).Rati = -1 Then
            _cmbCil_0.SelectedIndex = _cmbCil_0.Items.Count - 1
        Else
            For i = 1 To 8
                If InStr(Trim(_cmbCil_0.Items(i - 1)), Trim(Str(Nozzles(KL, k).Rati))) Then
                    _cmbCil_0.SelectedIndex = i - 1
                    Exit For
                End If
            Next
        End If
210:    If Nozzles(KL, k).Xacc = "X" Then iAcc = 1 Else iAcc = 0
        Check1.CheckState = iAcc
        AggTesti(k)
        AggVisible(KL, j, k)
        Stringa8(5) = "Set-in/on"
        For i = 1 To 5
            Stringa88(i) = Stringa8(i)
        Next
        If NAbu = 0 Then
            NAbu = 3
            Stringa88(2) = Stringa8(3)
            Stringa88(3) = Stringa8(4)
            ' NAbu = 2
            ' Stringa88(2) = Stringa8(4)
            'Stringa88(3) = Stringa8(4)
        End If
        If div = 1 Then
            Select Case Nozzles(KL, k).Tipo.Trim
                Case "LWN3"
                    Stringa88(3) = Stringa8(4)
                Case "LWN2"
                    Stringa88(2) = Stringa8(3)
                Case "WN", "LWN", "LWN1"
                    Stringa88(2) = Stringa8(3)
                    Stringa88(3) = Stringa8(5)
            End Select
        End If
        _cmbCil_3.Items.Clear()
        For i = 1 To NAbu
            _cmbCil_3.Items.Add(Stringa88(i))
        Next
        If jInvolucr > 0 Then Tipo = Involucr(kLato, jInvolucr).Tipo Else Tipo = 0
        Call Disposiz(Tipo, k, iDisp)
        _cmbCil_2.Items.Clear()
        Select Case Tipo
            Case 0
                For i = 0 To 3
                    _cmbCil_2.Items.Add(Posiz0(i))
                Next
            Case 1
                For i = 0 To 4
                    _cmbCil_2.Items.Add(Posiz1(i))
                Next
            Case 2
                For i = 0 To 2
                    _cmbCil_2.Items.Add(Posiz2(i))
                Next
            Case 3
                For i = 0 To 5
                    _cmbCil_2.Items.Add(Posiz3(i))
                Next
            Case 5 'su gr.fuc
                Select Case CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Mem.LOOSE
                    Case 4 'coperchio piano
                        For i = 0 To 2
                            _cmbCil_2.Items.Add(PosizC(i))
                        Next
                    Case 5, 6 'flat head with large opening
                        For i = 0 To 4
                            If i <> 1 Then _cmbCil_2.Items.Add(PosizC(i))
                        Next
                    Case 7 'reverse flange
                        For i = 0 To 4
                            _cmbCil_2.Items.Add(Posiz1(i))
                        Next
                    Case Else 'flangioni loose e no
                        For i = 0 To 4
                            _cmbCil_2.Items.Add(Posiz1(i))
                        Next
                End Select
        End Select
        '  _cmbCil_2.Enabled = False
        ' On Error Resume Next
        _cmbCil_2.SelectedIndex = iDisp
        ' On Error GoTo 0
        '  _cmbCil_2.Enabled = True
        '  AggiDisp k, iDisp
        iAbu = NozzAdd(KL, k).TipAbutt
        If NAbu = 3 And iAbu > 2 Then iAbu = iAbu - 1
        If iAbu > NAbu Then iAbu = NAbu
        If iAbu > _cmbCil_3.Items.Count Then iAbu = _cmbCil_3.Items.Count
        _cmbCil_3.SelectedIndex = iAbu - 1
        ListSk(Sketch, isk, k)
        _cmbCil_4.Items.Clear()
        For i = 1 To 35
            If isk(i) = 0 Then Nsk = i - 1 : Exit For
            If isk(i) = NozzAdd(KL, k).UW16 Then iScel = i
            _cmbCil_4.Items.Add(Sketch(i))
        Next  'c
        If iScel = 0 Then iScel = 1
        If Sketch(iScel) = "" Then
            'UPGRADE_NOTE: È possibile che l'oggetto Picture1.Picture non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            Picture1.Image = Nothing
        Else
            _cmbCil_4.SelectedIndex = iScel - 1
            Picture1.Image = ListaImmagini.Images(iScel)
        End If
        If Nozzles(KL, k).FlanNonStd = 1 Then
            Me.chkApp2.Checked = True
            If Nozzles(KL, k).IndiceB > 0 Then
                cmbMatBolt.Text = Matdim(Nozzles(KL, k).IndiceB).MatStr.Trim
                Me.chkBoltMat.Checked = Matdim(Nozzles(KL, k).IndiceB).Agganciato
            End If
        Else
            Me.chkApp2.Checked = False
        End If
    End Sub


    Public Sub Diam(ByRef KL As Short, ByRef k As Short)
        Dim ii As Short
        For ii = 1 To 9
            If RTrim(Nozzles(KL, k).Tipo) = RTrim(VB.Left(Stringa2(ii), 4)) Then GoTo 200
        Next
        Nozzles(KL, k).Tipo = "WN" ': iTipo = 1
200:    Exit Sub
        'If iTipo > 2 Then Nozzles(k).EffN = 1!

    End Sub

    Private Sub AggTesti(ByRef k As Short)
        Dim Log1 As Boolean
        Dim Spess As Single
        cmbMat.Text = Nozzles(kLato, k).MATE.Trim
        chkAgganciatoN.Checked = Matdim(Nozzles(kLato, k).indice).Agganciato
        _TextCil_11.Text = Trim(Nozzles(kLato, k).Mark)
        ' _TextCil_2 = mystr(Nozzles(kLato, k).DiaN, 3, 3, False)
        _cmbCil_5.Text = GlobalRoutines.myStr(Nozzles(kLato, k).DiaN, 3, 3, False)
        _TextCil_12.Text = GlobalRoutines.myStr(Nozzles(kLato, k).DiOn * kLength, 5, 3, False)
        _TextCil_1.Text = GlobalRoutines.myStr(Nozzles(kLato, k).DiIn * kLength, 5, 3, False)
        _TextCil_13.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Spess * kLength, 5, 3, False)
        If Nozzles(kLato, k).EffN = 0 Then Nozzles(kLato, k).EffN = 1
        _TextCil_3.Text = GlobalRoutines.myStr(Nozzles(kLato, k).EffN, 2, 2, False)
        _TextCil_4.Text = GlobalRoutines.myStr(Nozzles(kLato, k).ONn * kLength, 2, 2, False)
        _TextCil_5.Text = GlobalRoutines.myStr(Nozzles(kLato, k).CorrA * kLength, 2, 2, False)
        If VerificandoPI Then
            _TextCil_6.Text = GlobalRoutines.myStr(Nozzles(kLato, k).AllNPI * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        Else
            _TextCil_6.Text = GlobalRoutines.myStr(Nozzles(kLato, k).AllN * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        End If
        'If Nozzles(kLato, k).MNT = 0 Then Nozzles(kLato, k).MNT = 12.5
        _TextCil_7.Text = GlobalRoutines.myStr(Nozzles(kLato, k).MNT, 2, 2, False)
        _TextCil_8.Text = GlobalRoutines.myStr(Nozzles(kLato, k).LX * kLength, 4, 2, False)
        _TextCil_10.Text = GlobalRoutines.myStr(Nozzles(kLato, k).LXdisp * kLength, 4, 2, False)
        _TextCil_9.Text = GlobalRoutines.myStr(Nozzles(kLato, k).LSDisp * kLength, 4, 2, False)
        _TextCil_14.Text = GlobalRoutines.myStr(Nozzles(kLato, k).HX * kLength, 4, 2, False)
        _TextCil_15.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Padd * kLength, 6, 2, False)
        _TextCil_16.Text = GlobalRoutines.myStr(Nozzles(kLato, k).PadT * kLength, 6, 2, False)
        If VerificandoPI Then
            If Nozzles(kLato, k).AllPadPI = 0 Then
                If Nozzles(kLato, k).InvolucroSU > 0 Then
                    Nozzles(kLato, k).AllPadPI = Involucr(kLato, Nozzles(kLato, k).InvolucroSU).Shydr
                ElseIf Nozzles(kLato, k).InvolucroSU < 0 Then
                    Nozzles(kLato, k).AllPadPI = Nozzles(kLato, -Nozzles(kLato, k).InvolucroSU).AllNPI
                End If
            End If
            _TextCil_18.Text = GlobalRoutines.myStr(Nozzles(kLato, k).AllPad * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        Else
            If Nozzles(kLato, k).AllPad = 0 Then
                If Nozzles(kLato, k).InvolucroSU > 0 Then
                    Nozzles(kLato, k).AllPad = Involucr(kLato, Nozzles(kLato, k).InvolucroSU).St
                ElseIf Nozzles(kLato, k).InvolucroSU < 0 Then
                    Nozzles(kLato, k).AllPad = Nozzles(kLato, -Nozzles(kLato, k).InvolucroSU).AllN
                End If
            End If
            _TextCil_18.Text = GlobalRoutines.myStr(Nozzles(kLato, k).AllPad * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        End If
        If Nozzles(kLato, k).IndiceP > 0 Then
            If Not Matdim(Nozzles(kLato, k).IndiceP) Is Nothing Then
                If Not Matdim(Nozzles(kLato, k).IndiceP).MatStr Is Nothing Then
                    cmbMatPad.Text = Matdim(Nozzles(kLato, k).IndiceP).MatStr.Trim
                Else
                    cmbMatPad.Text = "?"
                End If
                chkAgganciatoP.Checked = Matdim(Nozzles(kLato, k).IndiceP).Agganciato
            End If
            End If
        If Nozzles(kLato, k).IndexF > 0 Then
            If Not Matdim(Nozzles(kLato, k).IndexF) Is Nothing Then
                If Not Matdim(Nozzles(kLato, k).IndexF).MatStr Is Nothing Then
                    cmbMatFl.Text = Matdim(Nozzles(kLato, k).IndexF).MatStr.Trim
                Else
                    cmbMatFl.Text = "?"
                End If
                chkAgganciatoF.Checked = Matdim(Nozzles(kLato, k).IndexF).Agganciato
            End If
        End If
        _TextCil_19.Text = GlobalRoutines.myStr(NozzAdd(kLato, k).Protusion * kLength, 4, 0, False)
        If jInvolucr > 0 Then
            If Involucr(kLato, jInvolucr).Tipo = 5 Then Log1 = True
            If SistCoorCop = 0 Then Log1 = False
        Else
            Log1 = False
        End If
        If Log1 Then
            _TextCil_21.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DCL * kLength, 5, 0, False))
            _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DTL * kLength, 5, 0, False))
        End If
        _TextCil_22.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Anomal, 5, 0, False)
        _TextCil_23.Text = GlobalRoutines.myStr(Nozzles(kLato, k).R2 * kLength, 5, 0, False)
        _TextCil_24.Text = GlobalRoutines.myStr(Nozzles(kLato, k).TransitionAngle, 5, 0, False)
        _TextCil_25.Value = NumLoc(kLato, -k)
        Spess = ShThkDefault()
        If Nozzles(kLato, k).ShThkNozArea < Spess / 4 Or Nozzles(kLato, k).ShThkNozArea > Spess * 4 Then Nozzles(kLato, k).ShThkNozArea = Spess
        _TextCil_27.Text = GlobalRoutines.myStr(Nozzles(kLato, k).ShThkNozArea * kLength, 4, 2, False)
        _TextCil_28.Text = GlobalRoutines.myStr(Nozzles(kLato, k).R1 * kLength, 4, 2, False)
        _TextCil_29.Text = GlobalRoutines.myStr(Nozzles(kLato, k).dtAD550f * kTemp + kTemp32, 4, 1, False)
    End Sub

    Private Sub AggiDisp(ByRef k As Short, ByRef iDisp As Short)
        If jInvolucr > 0 Then Tipo = Involucr(kLato, jInvolucr).Tipo Else Tipo = 0
        AggVisSolo(True)
        Select Case Tipo
            Case 0 'cilindro
                Select Case iDisp
                    Case 1
                        Nozzles(kLato, k).DCL = 0
                        Nozzles(kLato, k).beta = 90
                    Case 2
                        _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                        _LabelCil_26.Text = "Angolo asse-bocch./asse-cilindro [°]"
                        _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).beta, 5, 2, False))
                        'If Not Monitor.Motore.InputDati(1, "Inclinazione", Domand(), Rispost(), "", Archiv(), dAiu()) Then Exit Sub
                        'Nozzles(kLato,k).beta = GlobaLroutines.ValVir(Rispost(1))
                    Case 3
                        _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                        _LabelCil_26.Text = "Disassamento bocch./cilindro " & UnitLength '  [mm]"
                        _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DCL * kLength, 5, 2, False))
                        'If Not Monitor.Motore.InputDati(1, "Disassamento", Domand(), Rispost(), "", Archiv(), dAiu()) Then Exit Sub
                        'Nozzles(kLato,k).DCL = GlobaLroutines.ValVir(Rispost(1))
                    Case 5
                End Select
                Nozzles(kLato, k).DTL = 0
            Case 1 'fondo
                strTipo = "fondo" : strTL = "tang.line"
                Call DispFondo(k, iDisp)
            Case 2 'su cono
                Nozzles(kLato, k).DTL = 0
                If iDisp = 1 Then Nozzles(kLato, k).beta = 90 Else Nozzles(kLato, k).beta = 90 - Involucr(kLato, Nozzles(kLato, k).InvolucroSU).R0
                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                _LabelCil_26.Text = "Distanza da piano diametro grande  " & UnitLength '[mm]"
                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DCL * kLength, 5, 2, False))
                'If Not Monitor.Motore.InputDati(1, "Posizione", Domand(), Rispost(), "", Archiv(), dAiu()) Then Exit Sub
                'Nozzles(kLato,k).DCL = GlobaLroutines.ValVir(Rispost$(1))
            Case 3 ' su conoide
                Select Case iDisp
                    Case 1 'p.asse sopra
                        Nozzles(kLato, k).DTL = 180
                        Nozzles(kLato, k).beta = 90
                    Case 2 'p.gen sopra
                        Nozzles(kLato, k).DTL = 180
                        Nozzles(kLato, k).beta = 90 - Involucr(kLato, Nozzles(kLato, k).InvolucroSU).R0
                    Case 3 'sotto
                        Nozzles(kLato, k).DTL = 0
                        Nozzles(kLato, k).beta = 90
                    Case 4 'p.asse fianco
                        Nozzles(kLato, k).DTL = 90
                        Nozzles(kLato, k).beta = 90
                    Case 5 'p.gen  fianco
                        Nozzles(kLato, k).DTL = 90
                        ang = (90 - Involucr(kLato, Nozzles(kLato, k).InvolucroSU).R0) * pi / 180
                        ang = System.Math.Atan(ang / 2)
                        Nozzles(kLato, k).beta = ang * 180 / pi
                End Select
                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                _LabelCil_26.Text = "Distanza da piano diametro grande  " & UnitLength '[mm]"
                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DCL * kLength, 5, 2, False))
                'If Not Monitor.Motore.InputDati(1, "Posizione", Domand(), Rispost(), "", Archiv(), dAiu()) Then Exit Sub
                'Nozzles(kLato,k).DCL = GlobaLroutines.ValVir(Rispost(1))
            Case 5 'gr.fuc.
                l = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Mem.LOOSE
                Select Case l
                    Case 4 'coperchio
                        Select Case iDisp
                            Case 1
                                Nozzles(kLato, k).DCL = 0
                                Nozzles(kLato, k).beta = 0
                                Nozzles(kLato, k).DTL = 0
                            Case 2
                                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                                _LabelCil_26.Text = "Disassam.asse-bocch./asse-cop.  " & UnitLength '[mm]"
                                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DTL * kLength, 5, 2, False))
                                _LabelCil_27.Visible = True : _TextCil_22.Visible = True
                                _LabelCil_27.Text = "Anomalia (orientamento) [°]"
                                _TextCil_22.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Anomal, 3, 2, False)
                        End Select
                    Case 5, 6 'flat head with large opening
                        Select Case iDisp
                            Case 1
                                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                                _LabelCil_26.Text = "Disassam.asse-bocch./asse-cop.  " & UnitLength '[mm]"
                                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DTL * kLength, 5, 2, False))
                                _LabelCil_27.Visible = True : _TextCil_22.Visible = True
                                _LabelCil_27.Text = "Anomalia (orientamento) [°]"
                                _TextCil_22.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Anomal, 3, 2, False)
                            Case 2 'su codolo grande
                                Nozzles(kLato, k).DCL = -1
                                Nozzles(kLato, k).beta = 0
                                Nozzles(kLato, k).DTL = 0
                                AggVisSolo(False)
                            Case 3 'su codolo piccolo
                                Nozzles(kLato, k).DCL = -2
                                Nozzles(kLato, k).beta = 0
                                Nozzles(kLato, k).DTL = 0
                                AggVisSolo(False)
                        End Select
                    Case 7
                        MessageBox.Show("da programmare in AggiDisp")
                    Case Else
                        strTipo = "flangione" : strTL = "cima codolo"
                        Call DispFondo(k, iDisp)
                End Select
                Exit Sub
        End Select
        Exit Sub
    End Sub
    Private Sub DispFondo(ByRef k As Short, ByRef iDisp As Short)
        Select Case iDisp
            Case 1
                Nozzles(kLato, k).DCL = 0
                Nozzles(kLato, k).beta = 0
                Nozzles(kLato, k).DTL = 0
            Case 2
                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                _LabelCil_26.Text = "Angolo asse-bocch./asse-" & strTipo & " [°]"
                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).beta, 5, 2, False))
                _LabelCil_27.Visible = True : _TextCil_22.Visible = True
                _LabelCil_27.Text = "Anomalia (orientamento) [°]"
                _TextCil_22.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Anomal, 3, 2, False)
                Nozzles(kLato, k).DTL = 0
                Nozzles(kLato, k).DCL = 0
            Case 3
                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                _LabelCil_26.Text = "Distanza asse-bocch./" & strTL & " " & UnitLength '[mm]"
                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DTL * kLength, 5, 2, False))
                _LabelCil_27.Visible = True : _TextCil_22.Visible = True
                _LabelCil_27.Text = "Anomalia (orientamento) [°]"
                _TextCil_22.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Anomal, 3, 2, False)
                'If Not Monitor.Motore.InputDati(1, "Quota assiale", Domand(), Rispost(), "", Archiv(), dAiu()) Then Exit Sub
                'Nozzles(kLato,k).beta = 0
                'Nozzles(kLato,k).DTL = GlobaLroutines.ValVir(Rispost(1))
                'Nozzles(kLato,k).DCL = 0
            Case 4
                _LabelCil_26.Visible = True : _TextCil_20.Visible = True
                _LabelCil_26.Text = "Disassam.asse-bocch./asse-" & strTipo & " " & UnitLength '[mm]"
                _TextCil_20.Text = Trim(GlobalRoutines.myStr(Nozzles(kLato, k).DCL * kLength, 5, 2, False))
                _LabelCil_27.Visible = True : _TextCil_22.Visible = True
                _LabelCil_27.Text = "Anomalia (orientamento) [°]"
                _TextCil_22.Text = GlobalRoutines.myStr(Nozzles(kLato, k).Anomal, 3, 2, False)
                'If Not Monitor.Motore.InputDati(1, "Disassamento", Domand(), Rispost(), "", Archiv(), dAiu()) Then Exit Sub
                'Nozzles(kLato,k).beta = 0
                'Nozzles(kLato,k).DTL = 0
                'Nozzles(kLato,k).DCL = GlobaLroutines.ValVir(Rispost(1))
        End Select
    End Sub
    Public Sub AggImage(ByRef k As Short)
        Dim Imag As Image
        If _cmbCil_4.Text.Length = 0 Then Exit Sub
        Imag = TagImages(_cmbCil_4.Text)
        Picture1.Image = Imag
        Select Case Trim(_cmbCil_4.Text)
            Case "UW-16.1 (h)", "UW-16.1 (f-4)", "UW-16.1 (i)", "UW-16.1 (l)", "UW-16.1 (r)", "UW-16.1 (s)", "UW-16.1 (w)"
                _LabelCil_24.Visible = True : _TextCil_19.Visible = True
            Case Else
                _LabelCil_24.Visible = False : _TextCil_19.Visible = False
                NozzAdd(kLato, k).Protusion = 0
        End Select
        NozzAdd(kLato, k).UW16 = IndexImages(_cmbCil_4.Text)  ' Imag.Index
        AggiornaAiuti()
    End Sub
    Friend Function TagImages(ByVal Tag As String) As Image
        Dim i As Integer
        For i = 1 To ListaImmagini.Images.Count - 1
            If TagListaImmagini(i) = Tag Then Return ListaImmagini.Images(i)
        Next
        Return Nothing
    End Function
    Friend Function IndexImages(ByVal Tag As String) As Short
        Dim i As Short
        For i = 1 To ListaImmagini.Images.Count - 1
            If TagListaImmagini(i) = Tag Then Return i
        Next
    End Function
    Private Sub AggMatFlan()
        Dim Tipo As String
        Dim V, V1 As Boolean
        Tipo = Nozzles(kLato, kNozzle).Tipo
        If Nozzles(kLato, kNozzle).Rati = -1 Then
            V = False
            V1 = False
        Else
            V = InStr(Tipo, "WN") > 0 And Nozzles(kLato, kNozzle).Rati > 0
            V1 = True
        End If
        _LabelCil_31.Visible = V
        chkAgganciatoF.Visible = V
        cmbMatFl.Visible = V
        _cmdCil_12.Visible = V
        _Frames_3.Visible = V
        _LabelCil_3.Visible = V1
        _cmbCil_0.Visible = V1
        _LabelCil_15.Visible = V1 : _TextCil_13.Visible = V1 : _cmdCil_5.Visible = V1
        _LabelCil_13.Visible = Not V1 : _TextCil_1.Visible = Not V1
    End Sub
    Public Sub SetImage()
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11
                div = 0
                ListaImmagini = ImageList1
                TagListaImmagini = TagImageList1
            Case 3, 4, 5
                div = 1
                ListaImmagini = ImageList2
                TagListaImmagini = TagImageList2
            Case 6, 7, 8
                div = 2
                ListaImmagini = ImageList3
                TagListaImmagini = TagImageList3
            Case Else
                div = -1
                ' Stop
        End Select
    End Sub

    Private Sub AggVisible(ByRef KL As Short, ByRef j As Short, ByRef k As Short)
        Dim Log1 As Boolean
        LabelCil(30).Visible = True : _TextCil_25.Visible = True
        If Nozzles(KL, k).InvolucroSU < 0 Then
            LabelCil(30).Visible = False : _TextCil_25.Visible = False
        End If
        Check1.Visible = True
        Picture1.Visible = True
        _Frames_1.Visible = True
        _Frames_2.Visible = True
        _cmbCil_0.Visible = True : LabelCil(3).Visible = True 'rating
        LabelCil(2).Visible = True : cmbMat.Visible = True : cmdCil(0).Visible = True
        chkAgganciatoN.Visible = True
        _Frames_3.Visible = True
        _LabelCil_4.Visible = True : _TextCil_2.Visible = False : _cmbCil_5.Visible = True
        LabelCil(14).Visible = True : _TextCil_12.Visible = True : _cmbCil_5.Visible = True
        _TextCil_12.Visible = True : LabelCil(14).Visible = True 'Ext dia
        LabelCil(14).Text = "External Diameter  " & UnitLength '[mm]"
        _TextCil_1.Visible = True : _LabelCil_13.Visible = True 'Int dia
        _TextCil_13.Visible = True : _LabelCil_15.Visible = True : _cmdCil_5.Visible = True 'Spess tr
        _TextCil_3.Visible = True : _LabelCil_5.Visible = True 'E
        _TextCil_4.Visible = True : _LabelCil_6.Visible = True 'OS
        _TextCil_5.Visible = True : _LabelCil_7.Visible = True 'CS
        _LabelCil_8.Visible = True : _TextCil_6.Visible = True : _cmdCil_1.Visible = True
        _TextCil_7.Visible = True : _LabelCil_9.Visible = True 'Mnt
        _LabelCil_10.Visible = True : _TextCil_8.Visible = True
        _TextCil_10.Visible = True : _LabelCil_12.Visible = True
        _TextCil_9.Visible = True : _LabelCil_11.Visible = True 'Avail. shell
        _TextCil_14.Visible = True : _LabelCil_16.Visible = True 'Self thk
        _TextCil_15.Visible = True : _LabelCil_17.Visible = True 'PadD
        _TextCil_16.Visible = True : _LabelCil_18.Visible = True 'PadT
        cmbMatPad.Visible = True : _LabelCil_22.Visible = True : _cmdCil_2.Visible = True : chkAgganciatoP.Visible = True 'Pad mat
        _TextCil_18.Visible = True : _LabelCil_23.Visible = True : _cmdCil_3.Visible = True 'Pad all
        _LabelCil_20.Visible = True : _cmbCil_3.Visible = True
        _TextCil_23.Visible = False : _LabelCil_28.Visible = False : cmdCil(11).Visible = False 'r2
        _TextCil_24.Visible = False : _LabelCil_29.Visible = False 'theta
        framSleeve.Visible = False
        If jInvolucr > 0 Then
            If Involucr(kLato, jInvolucr).Tipo = 5 Then Log1 = True
            If SistCoorCop = 0 Then Log1 = False
        Else
            Log1 = False
        End If
        If Not Log1 Then
            _LabelCil_25.Visible = True : _cmdCil_4.Visible = True 'Weld det
            If Not (div = 1 And (NozzAdd(KL, k).UW16 = 13 Or NozzAdd(KL, k).UW16 = 32 Or NozzAdd(KL, k).UW16 < 5)) Then Nozzles(KL, k).R2 = 0
        End If
        Log1 = div = 1
        LabelCil(33).Visible = Log1
        _TextCil_28.Visible = Log1
        cmdCil(13).Visible = Log1
        LabelCil(34).Visible = Log1
        _TextCil_29.Visible = Log1
        cmdCil(14).Visible = Log1
        _LabelCil_17.Text = "Pad diameter"
        _LabelCil_18.Text = "Pad thickness"
        Select Case Nozzles(KL, k).Tipo.Trim
            Case "OPEN"
                LabelCil(30).Visible = False : _TextCil_25.Visible = False
                LabelCil(3).Visible = False : _cmbCil_0.Visible = False
                _LabelCil_5.Visible = False : _TextCil_3.Visible = False
                LabelCil(2).Visible = False : cmbMat.Visible = False : cmdCil(0).Visible = False
                chkAgganciatoN.Visible = False
                _Frames_3.Visible = False
                _LabelCil_4.Visible = False : _TextCil_2.Visible = False : _cmbCil_5.Visible = False
                LabelCil(14).Text = "Opening Diameter  " & UnitLength '[mm]"
                _LabelCil_12.Visible = False : _TextCil_10.Visible = False
                _LabelCil_13.Visible = False : _TextCil_1.Visible = False
                _LabelCil_15.Visible = False : _TextCil_13.Visible = False : _cmdCil_5.Visible = False
                _LabelCil_16.Visible = False : _TextCil_14.Visible = False
                _LabelCil_8.Visible = False : _TextCil_6.Visible = False : _cmdCil_1.Visible = False
                _LabelCil_9.Visible = False : _TextCil_7.Visible = False : Nozzles(KL, k).MNT = 0
                _LabelCil_10.Visible = False : _TextCil_8.Visible = False
                _LabelCil_20.Visible = False : _cmbCil_3.Visible = False
                _Frames_2.Visible = False
                _TextCil_15.Text = CStr(0) : _TextCil_16.Text = CStr(0)
                Nozzles(KL, k).Padd = 0 : Nozzles(KL, k).PadT = 0
                Select Case div
                    Case 0, 2
                        NAbu = 4
                    Case 1
                        NAbu = 3
                End Select
            Case "Sola"
                LabelCil(30).Visible = False : _TextCil_25.Visible = False
                Check1.Visible = False
                Picture1.Visible = False
                _Frames_1.Visible = False
                _Frames_2.Visible = False
                _TextCil_15.Text = CStr(0) : _TextCil_16.Text = CStr(0)
                Nozzles(KL, k).Padd = 0 : Nozzles(KL, k).PadT = 0
                _TextCil_3.Visible = False : _LabelCil_5.Visible = False 'E
                _TextCil_4.Visible = False : _LabelCil_6.Visible = False 'OS
                _TextCil_5.Visible = False : _LabelCil_7.Visible = False 'CS
                _TextCil_6.Visible = False : _LabelCil_8.Visible = False 'Allowab
                _TextCil_7.Visible = False : _LabelCil_9.Visible = False : Nozzles(KL, k).MNT = 0
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _TextCil_10.Visible = False : _LabelCil_12.Visible = False 'Avail. height
                _TextCil_9.Visible = False : _LabelCil_11.Visible = False 'Avail. shell
                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
            Case "WN"
                _TextCil_1.Visible = False : _LabelCil_13.Visible = False 'Int dia
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
                _Frames_2.Visible = False
                _TextCil_15.Text = CStr(0) : _TextCil_16.Text = CStr(0)
                Nozzles(KL, k).Padd = 0 : Nozzles(KL, k).PadT = 0
                Select Case div
                    Case 0, 2
                        NAbu = 5
                    Case 1
                        NAbu = 3
                End Select
            Case "WN1"
                _TextCil_1.Visible = True : _LabelCil_13.Visible = True 'Int dia
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
                Select Case div
                    Case 0, 2
                        NAbu = 4
                    Case 1
                        NAbu = 1
                End Select
            Case "LWN"
                _TextCil_13.Visible = False : _LabelCil_15.Visible = False : _cmdCil_5.Visible = True 'Spess tr
                _TextCil_7.Visible = False : _LabelCil_9.Visible = False : Nozzles(KL, k).MNT = 0
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
                _Frames_2.Visible = False
                _TextCil_15.Text = CStr(0) : _TextCil_16.Text = CStr(0)
                Nozzles(KL, k).Padd = 0 : Nozzles(KL, k).PadT = 0
                Select Case div
                    Case 0, 2
                        NAbu = 5
                    Case 1
                        NAbu = 3
                End Select
            Case "LWN1"
                _TextCil_13.Visible = False : _LabelCil_15.Visible = False : _cmdCil_5.Visible = True 'Spess tr
                _TextCil_7.Visible = False : _LabelCil_9.Visible = False : Nozzles(KL, k).MNT = 0
                _Frames_2.Visible = False
                _TextCil_15.Text = CStr(0) : _TextCil_16.Text = CStr(0)
                Nozzles(KL, k).Padd = 0 : Nozzles(KL, k).PadT = 0
                Select Case div
                    Case 0, 2
                        NAbu = 0
                        _TextCil_24.Visible = True : _LabelCil_29.Visible = True 'theta
                    Case 1
                        NAbu = 2
                        _TextCil_23.Visible = True : _LabelCil_28.Visible = True : cmdCil(11).Visible = True 'r2
                        _TextCil_24.Visible = True : _LabelCil_29.Visible = True 'theta
                        Select Case NozzAdd(KL, k).UW16
                            Case 13
                                _LabelCil_10.Visible = False : _TextCil_8.Visible = False
                            Case 32 'AD-610.1(g)'
                            Case 33 'AD-610.1(a)'
                                _TextCil_23.Visible = False : _LabelCil_28.Visible = False : cmdCil(11).Visible = False 'r2
                                _TextCil_8.Visible = True : _LabelCil_10.Visible = True 'Reinf. height
                        End Select
                End Select
            Case "LWN2"
                _TextCil_13.Visible = False : _LabelCil_15.Visible = False : _cmdCil_5.Visible = True 'Spess tr
                _TextCil_7.Visible = False : _LabelCil_9.Visible = False : Nozzles(KL, k).MNT = 0
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
                cmbMatPad.Visible = False : _LabelCil_22.Visible = False : _cmdCil_2.Visible = False : chkAgganciatoP.Visible = False 'Pad mat
                _TextCil_18.Visible = False : _LabelCil_23.Visible = False : _cmdCil_3.Visible = False 'Pad all
                _LabelCil_17.Text = "Diametro scarpa " & UnitLength 'PadD
                _LabelCil_18.Text = "Spessore scarpa " & UnitLength 'PadT
                Select Case div
                    Case 0, 2
                        NAbu = 1
                    Case 1
                        NAbu = 2
                        Select Case NozzAdd(KL, k).UW16
                            Case 4, 19
                                _TextCil_15.Visible = True : _LabelCil_17.Visible = True 'PadD
                                '_cmdCil_9.Visible = True
                                _LabelCil_18.Visible = True
                                _TextCil_16.Visible = True
                                'cmdCil(10).Visible = True
                            Case Else 'senza scarpa
                                _LabelCil_18.Visible = False
                                _TextCil_16.Visible = False
                                'cmdCil(10).Visible = False
                        End Select
                        _TextCil_24.Visible = True : _LabelCil_29.Visible = True 'theta
                        Select Case NozzAdd(KL, k).UW16
                            Case 1
                                _TextCil_8.Visible = True : _LabelCil_10.Visible = True 'Reinf. height
                                _TextCil_14.Visible = True : _LabelCil_16.Visible = True 'Self thk
                            Case 3
                                _TextCil_8.Visible = True : _LabelCil_10.Visible = True 'Reinf. height
                                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
                            Case 2, 4
                                _TextCil_24.Visible = False : _LabelCil_29.Visible = False
                        End Select
                        Select Case NozzAdd(KL, k).UW16
                            Case 1 To 3
                                _LabelCil_25.Visible = False : _cmdCil_4.Visible = False
                                _TextCil_25.Enabled = False
                            Case 4
                                _LabelCil_25.Visible = False : _cmdCil_4.Visible = False
                                _TextCil_25.Enabled = True
                            Case Else
                                _TextCil_25.Enabled = True
                        End Select
                        _TextCil_23.Visible = True : _LabelCil_28.Visible = True : cmdCil(11).Visible = True 'r2
                End Select
            Case "LWN3"
                _TextCil_13.Visible = False : _LabelCil_15.Visible = False : _cmdCil_5.Visible = False 'Spess tr
                _TextCil_7.Visible = False : _LabelCil_9.Visible = False : Nozzles(KL, k).MNT = 0
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _TextCil_14.Visible = False : _LabelCil_16.Visible = False 'Self thk
                cmbMatPad.Visible = False : _LabelCil_22.Visible = False : _cmdCil_2.Visible = False : chkAgganciatoP.Visible = False 'Pad mat
                _TextCil_18.Visible = False : _LabelCil_23.Visible = False : _cmdCil_3.Visible = False 'Pad all
                Select Case div
                    Case 0, 2
                        NAbu = 1
                        _LabelCil_17.Text = "Raggio di raccordo" & UnitLength
                        _LabelCil_18.Text = "Area fori [mm2]" 'CHR$(45)'"Spessore scarpa" + GD$'PadT
                    Case 1
                        _LabelCil_17.Text = "Diametro pad" & UnitLength 'PadD
                        _LabelCil_18.Text = "Spessore pad" & UnitLength 'PadT
                        NAbu = 3
                        Select Case NozzAdd(KL, k).UW16
                            Case 28
                                _TextCil_15.Visible = False : _LabelCil_17.Visible = False 'PadD
                                ' cmdCil(9).Visible = False
                                _TextCil_16.Visible = False : _LabelCil_18.Visible = False 'PadT
                                ' cmdCil(10).Visible = False
                            Case Else
                                _TextCil_15.Visible = True : _LabelCil_17.Visible = True 'PadD
                                ' cmdCil(9).Visible = True
                                _TextCil_16.Visible = True : _LabelCil_18.Visible = True 'PadT
                                '  cmdCil(10).Visible = True
                        End Select
                        Select Case NozzAdd(KL, k).UW16
                            Case 17, 18
                                LabelCil(14).Visible = False : _TextCil_12.Visible = False
                        End Select
                        If NozzAdd(KL, k).UW16 >= 28 And NozzAdd(KL, k).UW16 <= 30 Then
                            framSleeve.Visible = True
                            framSleeve.Top = framSleeveTop
                            framSleeve.BringToFront()
                        End If
                End Select
            Case "SPC1"
                LabelCil(30).Visible = False : _TextCil_25.Visible = False
                _cmbCil_0.Visible = True : LabelCil(3).Visible = True 'rating
                _TextCil_13.Visible = False : _LabelCil_15.Visible = False : _cmdCil_5.Visible = False 'Spess tr
                'Stringa(11) = Chr$(45): Stringa(12) = Chr$(45)
                _TextCil_7.Visible = False : _LabelCil_9.Visible = False : Nozzles(KL, k).MNT = 0
                _TextCil_8.Visible = False : _LabelCil_10.Visible = False 'Reinf. height
                _LabelCil_25.Visible = True : _cmdCil_4.Visible = True 'Weld det
                Nozzles(KL, k).R2 = 0
                _Frames_2.Visible = False
                _TextCil_15.Text = CStr(0) : _TextCil_16.Text = CStr(0)
                Nozzles(KL, k).Padd = 0 : Nozzles(KL, k).PadT = 0
                NozzAdd(KL, k).TipAbutt = 1 'iAbu
                Nozzles(KL, k).CorrA = 0
        End Select
        If _LabelCil_15.Visible Then _cmdCil_5.Top = _LabelCil_15.Top Else _cmdCil_5.Top = _LabelCil_4.Top
    End Sub
    Private Function ShThkDefault() As Single
        If jInvolucr > 0 Then
            If Involucr(kLato, jInvolucr).Tipo = 5 Then
                ShThkDefault = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Zp(119) * inc
                On Error GoTo 0
            Else
                ShThkDefault = Involucr(kLato, jInvolucr).Spess
            End If
        ElseIf jInvolucr < 0 Then
            ShThkDefault = Nozzles(kLato, -jInvolucr).Spess
        End If
    End Function

    Public Sub AggVisSolo(ByRef V As Boolean)
        LabelCil(32).Visible = V
        _TextCil_27.Visible = V
        cmdCil(15).Visible = V
        _LabelCil_25.Visible = V
        _cmdCil_4.Visible = V
        _LabelCil_21.Visible = V
        _cmbCil_4.Visible = V
        Picture1.Visible = V
        _LabelCil_12.Visible = V
        _TextCil_10.Visible = V
        _LabelCil_11.Visible = V
        _TextCil_9.Visible = V
        _LabelCil_20.Visible = V
        _cmbCil_3.Visible = V

    End Sub
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
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
                Case 14 : Return _TextCil_14
                Case 15 : Return _TextCil_15
                Case 16 : Return _TextCil_16
                Case 18 : Return _TextCil_18
                Case 19 : Return _TextCil_19
                Case 20 : Return _TextCil_20
                Case 21 : Return _TextCil_21
                Case 22 : Return _TextCil_22
                Case 23 : Return _TextCil_23
                Case 24 : Return _TextCil_24
                    '                Case 25 : Return _TextCil_25
                Case 27 : Return _TextCil_27
                Case 28 : Return _TextCil_28
                Case 29 : Return _TextCil_29
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property cmbCil(ByVal i As Short) As ComboBox
        Get
            Select Case i
                Case 0 : Return _cmbCil_0
                Case 1 : Return _cmbCil_1
                Case 2 : Return _cmbCil_2
                Case 3 : Return _cmbCil_3
                Case 4 : Return _cmbCil_4
                Case 5 : Return _cmbCil_5
                Case Else : Return Nothing
            End Select
        End Get
    End Property
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
                Case 25 : Return _LabelCil_25
                Case 26 : Return _LabelCil_26
                Case 27 : Return _LabelCil_27
                Case 28 : Return _LabelCil_28
                Case 29 : Return _LabelCil_29
                Case 30 : Return _LabelCil_30
                Case 31 : Return _LabelCil_31
                Case 32 : Return _LabelCil_32
                Case 33 : Return _LabelCil_33
                Case 34 : Return _LabelCil_34
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property cmdCil(ByVal i As Short) As Button
        Get
            Select Case i
                Case 0 : Return _cmdCil_0
                Case 1 : Return _cmdCil_1
                Case 2 : Return _cmdCil_2
                Case 3 : Return _cmdCil_3
                Case 4 : Return _cmdCil_4
                Case 5 : Return _cmdCil_5
                Case 11 : Return _cmdCil_11
                Case 12 : Return _cmdCil_12
                Case 13 : Return _cmdCil_13
                Case 14 : Return _cmdCil_14
                Case 15 : Return _cmdCil_15
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _cmbCil_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_5.TextChanged
        If Inizializzando Then Exit Sub
        Nozzles(kLato, kNozzle).DiaN = GlobalRoutines.ValVir(_cmbCil_5.Text)
    End Sub

    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(0)
    End Sub

    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(1)
    End Sub

    Private Sub _cmbCil_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_2.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(2)
    End Sub

    Private Sub _cmbCil_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_3.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(3)
    End Sub

    Private Sub _cmbCil_4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_4.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(4)
    End Sub

    Private Sub _cmbCil_5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_5.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(5)
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
    Private Sub _cmdCil_11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_11.Click
        cmdCil_Click(11)
    End Sub
    Private Sub _cmdCil_12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_12.Click
        cmdCil_Click(12)
    End Sub
    Private Sub _cmdCil_13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_13.Click
        cmdCil_Click(13)
    End Sub
    Private Sub _cmdCil_14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_14.Click
        cmdCil_Click(14)
    End Sub
    Private Sub _cmdCil_15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_15.Click
        cmdCil_Click(15)
    End Sub

    Private Sub chkAgganciatoN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoN.CheckedChanged
        Matdim(Nozzles(kLato, kNozzle).indice).Agganciato = chkAgganciatoN.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciatoF_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoF.CheckedChanged
        Matdim(Nozzles(kLato, kNozzle).IndexF).Agganciato = chkAgganciatoF.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciatoP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoP.CheckedChanged
        Matdim(Nozzles(kLato, kNozzle).IndiceP).Agganciato = chkAgganciatoP.Checked
        ModifiedData = True
    End Sub
    Private Sub chkApp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApp2.CheckedChanged
        If chkApp2.Checked Then
            cmbMatBolt.Enabled = True
            cmdBoltMat.Enabled = True
            chkBoltMat.Enabled = True
            With Nozzles(kLato, kNozzle)
                .FlanNonStd = 1
                If .IndObject <= 0 Then
                    .IndObject = NuovoIndObj()
                    objMemb(.IndObject) = New wn_flan
                End If
                If .IndiceB <= 0 Then
                    .IndiceB = NuovoIndice()
                    indici.Add(.IndiceB)
                    Matdim(.IndiceB).Agganciato = True
                    chkBoltMat.Checked = True
                End If
            End With
        Else
            Nozzles(kLato, kNozzle).FlanNonStd = 0
            cmbMatBolt.Text = ""
            cmbMatBolt.Enabled = False
            cmdBoltMat.Enabled = False
            chkBoltMat.Enabled = False
            chkBoltMat.Checked = False
        End If
    End Sub
    Private Sub cmdBoltMat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBoltMat.Click
        Matdim(Nozzles(kLato, kNozzle).IndiceB).IndAdd(1, 8)
        Matdim(Nozzles(kLato, kNozzle).IndiceB).Classe = 8
        MatdimScelta(Nozzles(kLato, kNozzle).IndiceB, 8, kLato, , kNozzle)
        Nozzles(kLato, kNozzle).RecIndB = Matdim(Nozzles(kLato, kNozzle).IndiceB).Indmat
        PostSelMat(cmbMatBolt, Nozzles(kLato, kNozzle).IndiceB)
        PopolacmbMat()
        AggTesti(kNozzle)
    End Sub
    Private Sub chkBoltMat_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoltMat.CheckedChanged
        Matdim(Nozzles(kLato, kNozzle).IndiceB).Agganciato = chkBoltMat.Checked
        ModifiedData = True
    End Sub
    Private Sub frmNoz_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If GiaAttivato Then Exit Sub
        Inizializza1()
        AggiornaLabels(Me, 34)
        GiaAttivato = True
    End Sub
    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Nozzles(kLato, kNozzle).indice, False, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Nozzles(kLato, kNozzle).MATE = Matdim(Nozzles(kLato, kNozzle).indice).MatStr
        chkAgganciatoN.Checked = Matdim(Nozzles(kLato, kNozzle).indice).Agganciato
    End Sub
    Private Sub cmbMatBolt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatBolt.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatBolt, Nozzles(kLato, kNozzle).IndiceB, False, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatBolt.SelectedIndex = nuovoSelect
        chkBoltMat.Checked = Matdim(Nozzles(kLato, kNozzle).IndiceB).Agganciato
    End Sub
    Private Sub cmbMatFl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatFl.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatFl, Nozzles(kLato, kNozzle).IndexF, False, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatFl.SelectedIndex = nuovoSelect
        chkAgganciatoF.Checked = Matdim(Nozzles(kLato, kNozzle).IndexF).Agganciato
    End Sub
    Private Sub cmbMatPad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatPad.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatPad, Nozzles(kLato, kNozzle).IndiceP, False, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatPad.SelectedIndex = nuovoSelect
        chkAgganciatoP.Checked = Matdim(Nozzles(kLato, kNozzle).IndiceP).Agganciato
    End Sub
    Private Sub _TextCil_25_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_25.ValueChanged
        VariaBocc(_TextCil_25.Value, -1)
    End Sub
    Private Sub chkCategA_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCategA.CheckStateChanged
        If chkCategA.CheckState = CheckState.Checked Then Nozzles(kLato, kNozzle).MUN = 1 Else Nozzles(kLato, kNozzle).MUN = 0
    End Sub
End Class