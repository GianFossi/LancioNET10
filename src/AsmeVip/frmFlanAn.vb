Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmFlanAn
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
    Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
    Public WithEvents chkTorq As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
    Public WithEvents Check4 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_14 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
    Public WithEvents _TextCil_15 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_16 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
    Public WithEvents Check2 As System.Windows.Forms.CheckBox
    Public WithEvents List1 As System.Windows.Forms.ListBox
    Public WithEvents _cmbCil_4 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_3 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_19 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_17 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_18 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
    Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents _TextCil_9 As System.Windows.Forms.NumericUpDown
    Public WithEvents Check3 As System.Windows.Forms.CheckBox
    Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
    Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
    Friend WithEvents chkAgganciatoB As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatBolt As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFlanAn))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me.chkAgganciatoB = New System.Windows.Forms.CheckBox
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me.Frames = New System.Windows.Forms.GroupBox
        Me.cmbMatBolt = New System.Windows.Forms.ComboBox
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me.Check3 = New System.Windows.Forms.CheckBox
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me.Check4 = New System.Windows.Forms.CheckBox
        Me._TextCil_9 = New System.Windows.Forms.NumericUpDown
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_14 = New System.Windows.Forms.TextBox
        Me._TextCil_15 = New System.Windows.Forms.TextBox
        Me._TextCil_16 = New System.Windows.Forms.TextBox
        Me.List1 = New System.Windows.Forms.ListBox
        Me._cmbCil_4 = New System.Windows.Forms.ComboBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._cmbCil_3 = New System.Windows.Forms.ComboBox
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._LabelCil_19 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_17 = New System.Windows.Forms.Label
        Me._LabelCil_18 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me.chkTorq = New System.Windows.Forms.CheckBox
        Me.Check2 = New System.Windows.Forms.CheckBox
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frames.SuspendLayout()
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(264, 352)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 53
        Me._cmdCil_2.TabStop = False
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_2, "Riporta il valore definito per l'apparecchio")
        Me._cmdCil_2.Visible = False
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(272, 544)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_4.TabIndex = 45
        Me._cmdCil_4.TabStop = False
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_4, "Riporta i valori definiti per l'apparecchio")
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(272, 448)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 34
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_5, "Riporta il valore definito per l'apparecchio")
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(272, 488)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_6.TabIndex = 31
        Me._cmdCil_6.TabStop = False
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_6, "Riporta i valori del lato mantello e del lato tubi")
        Me._cmdCil_6.Visible = False
        '
        'chkAgganciatoB
        '
        Me.chkAgganciatoB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoB, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoB, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoB.Location = New System.Drawing.Point(176, 112)
        Me.chkAgganciatoB.Name = "chkAgganciatoB"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoB, True)
        Me.chkAgganciatoB.TabIndex = 68
        Me.chkAgganciatoB.Text = "bound to library"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoB, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(176, 72)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.TabIndex = 69
        Me.chkAgganciato.Text = "bound to library"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me.cmbMatBolt)
        Me.Frames.Controls.Add(Me.cmbMat)
        Me.Frames.Controls.Add(Me.Check3)
        Me.Frames.Controls.Add(Me._cmbCil_1)
        Me.Frames.Controls.Add(Me._cmdCil_0)
        Me.Frames.Controls.Add(Me._cmbCil_0)
        Me.Frames.Controls.Add(Me._cmdCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_0)
        Me.Frames.Controls.Add(Me.Check4)
        Me.Frames.Controls.Add(Me._TextCil_9)
        Me.Frames.Controls.Add(Me._TextCil_8)
        Me.Frames.Controls.Add(Me._cmdCil_2)
        Me.Frames.Controls.Add(Me._TextCil_7)
        Me.Frames.Controls.Add(Me._TextCil_6)
        Me.Frames.Controls.Add(Me._TextCil_13)
        Me.Frames.Controls.Add(Me._cmdCil_4)
        Me.Frames.Controls.Add(Me._TextCil_5)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_14)
        Me.Frames.Controls.Add(Me._cmdCil_5)
        Me.Frames.Controls.Add(Me._TextCil_15)
        Me.Frames.Controls.Add(Me._TextCil_16)
        Me.Frames.Controls.Add(Me._cmdCil_6)
        Me.Frames.Controls.Add(Me.List1)
        Me.Frames.Controls.Add(Me._cmbCil_4)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me.Check1)
        Me.Frames.Controls.Add(Me._TextCil_2)
        Me.Frames.Controls.Add(Me._cmbCil_3)
        Me.Frames.Controls.Add(Me._cmbCil_2)
        Me.Frames.Controls.Add(Me.Command2)
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._TextCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_19)
        Me.Frames.Controls.Add(Me._LabelCil_15)
        Me.Frames.Controls.Add(Me._LabelCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_9)
        Me.Frames.Controls.Add(Me._LabelCil_16)
        Me.Frames.Controls.Add(Me._LabelCil_17)
        Me.Frames.Controls.Add(Me._LabelCil_18)
        Me.Frames.Controls.Add(Me._LabelCil_8)
        Me.Frames.Controls.Add(Me._LabelCil_7)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_11)
        Me.Frames.Controls.Add(Me._LabelCil_12)
        Me.Frames.Controls.Add(Me.chkTorq)
        Me.Frames.Controls.Add(Me.Check2)
        Me.Frames.Controls.Add(Me._LabelCil_13)
        Me.Frames.Controls.Add(Me._LabelCil_14)
        Me.Frames.Controls.Add(Me.chkAgganciatoB)
        Me.Frames.Controls.Add(Me.chkAgganciato)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(305, 624)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        'cmbMatBolt
        '
        Me.cmbMatBolt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatBolt.Location = New System.Drawing.Point(96, 96)
        Me.cmbMatBolt.Name = "cmbMatBolt"
        Me.cmbMatBolt.Size = New System.Drawing.Size(176, 21)
        Me.cmbMatBolt.TabIndex = 71
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.Location = New System.Drawing.Point(96, 56)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(176, 21)
        Me.cmbMat.TabIndex = 70
        '
        'Check3
        '
        Me.Check3.BackColor = System.Drawing.SystemColors.Control
        Me.Check3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check3.Location = New System.Drawing.Point(8, 160)
        Me.Check3.Name = "Check3"
        Me.Check3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check3.Size = New System.Drawing.Size(253, 19)
        Me.Check3.TabIndex = 67
        Me.Check3.Text = "Lap joint loose type flange"
        Me.Check3.Visible = False
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_1.Location = New System.Drawing.Point(80, 136)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_1.Size = New System.Drawing.Size(217, 21)
        Me._cmbCil_1.TabIndex = 66
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(280, 56)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 64
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 16)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(137, 21)
        Me._cmbCil_0.TabIndex = 58
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_1, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_1, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(280, 96)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_1, True)
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 57
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_1, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_1, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 56)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_1, True)
        Me._LabelCil_1.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_1.TabIndex = 65
        Me._LabelCil_1.Text = "Member Material"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 136)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(80, 17)
        Me._LabelCil_3.TabIndex = 62
        Me._LabelCil_3.Text = "Member type"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 96)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_2, True)
        Me._LabelCil_2.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_2.TabIndex = 61
        Me._LabelCil_2.Text = "Bolt Material"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 16)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 60
        Me._LabelCil_0.Text = "Member identification"
        '
        'Check4
        '
        Me.Check4.BackColor = System.Drawing.SystemColors.Control
        Me.Check4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check4.Location = New System.Drawing.Point(8, 328)
        Me.Check4.Name = "Check4"
        Me.Check4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check4.Size = New System.Drawing.Size(168, 17)
        Me.Check4.TabIndex = 44
        Me.Check4.Text = "Tiranti prigionieri"
        '
        '_TextCil_9
        '
        Me._TextCil_9.Location = New System.Drawing.Point(192, 568)
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.Size = New System.Drawing.Size(72, 20)
        Me._TextCil_9.TabIndex = 56
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_8.Location = New System.Drawing.Point(192, 280)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 54
        Me._TextCil_8.Text = ""
        Me._TextCil_8.Visible = False
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(184, 360)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_7.TabIndex = 50
        Me._TextCil_7.Text = "Text1"
        Me._TextCil_7.Visible = False
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(184, 344)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_6.TabIndex = 49
        Me._TextCil_6.Text = "Text1"
        Me._TextCil_6.Visible = False
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(192, 544)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_13.TabIndex = 46
        Me._TextCil_13.Text = "Text1"
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(192, 400)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_5.TabIndex = 42
        Me._TextCil_5.Text = "Text1"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 424)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 40
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_14
        '
        Me._TextCil_14.AcceptsReturn = True
        Me._TextCil_14.AutoSize = False
        Me._TextCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_14.Location = New System.Drawing.Point(192, 448)
        Me._TextCil_14.MaxLength = 0
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_14.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_14.TabIndex = 35
        Me._TextCil_14.Text = "Text1"
        '
        '_TextCil_15
        '
        Me._TextCil_15.AcceptsReturn = True
        Me._TextCil_15.AutoSize = False
        Me._TextCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_15.Location = New System.Drawing.Point(192, 472)
        Me._TextCil_15.MaxLength = 0
        Me._TextCil_15.Name = "_TextCil_15"
        Me._TextCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_15.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_15.TabIndex = 33
        Me._TextCil_15.Text = "Text1"
        Me._TextCil_15.Visible = False
        '
        '_TextCil_16
        '
        Me._TextCil_16.AcceptsReturn = True
        Me._TextCil_16.AutoSize = False
        Me._TextCil_16.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_16.Location = New System.Drawing.Point(192, 496)
        Me._TextCil_16.MaxLength = 0
        Me._TextCil_16.Name = "_TextCil_16"
        Me._TextCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_16.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_16.TabIndex = 32
        Me._TextCil_16.Text = "Text1"
        Me._TextCil_16.Visible = False
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.Location = New System.Drawing.Point(128, 520)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(41, 17)
        Me.List1.TabIndex = 29
        Me.List1.Visible = False
        '
        '_cmbCil_4
        '
        Me._cmbCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_4.Location = New System.Drawing.Point(144, 304)
        Me._cmbCil_4.Name = "_cmbCil_4"
        Me._cmbCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_4.Size = New System.Drawing.Size(121, 21)
        Me._cmbCil_4.TabIndex = 27
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(192, 256)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 25
        Me._TextCil_3.Text = ""
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 376)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(161, 17)
        Me.Check1.TabIndex = 24
        Me.Check1.Text = "Esecuzione commentata"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(192, 232)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 22
        Me._TextCil_2.Text = ""
        '
        '_cmbCil_3
        '
        Me._cmbCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_3.Location = New System.Drawing.Point(144, 208)
        Me._cmbCil_3.Name = "_cmbCil_3"
        Me._cmbCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_3.Size = New System.Drawing.Size(121, 21)
        Me._cmbCil_3.TabIndex = 21
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_2.Location = New System.Drawing.Point(144, 184)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_2.Size = New System.Drawing.Size(121, 21)
        Me._cmbCil_2.TabIndex = 20
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(200, 592)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 25)
        Me.Command2.TabIndex = 15
        Me.Command2.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(248, 592)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(48, 25)
        Me.Command1.TabIndex = 14
        Me.Command1.Text = "OK"
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_10.Location = New System.Drawing.Point(192, 520)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_10.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_10.TabIndex = 2
        Me._TextCil_10.Text = ""
        '
        '_LabelCil_19
        '
        Me._LabelCil_19.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_19.Location = New System.Drawing.Point(8, 280)
        Me._LabelCil_19.Name = "_LabelCil_19"
        Me._LabelCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_19.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_19.TabIndex = 55
        Me._LabelCil_19.Tag = "kPress"
        Me._LabelCil_19.Text = "Minimum prestress [psi]"
        Me._LabelCil_19.Visible = False
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(8, 544)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(177, 18)
        Me._LabelCil_15.TabIndex = 47
        Me._LabelCil_15.Text = "Relative density of contained fluid"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 400)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_10.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_10.TabIndex = 43
        Me._LabelCil_10.Tag = "kLength"
        Me._LabelCil_10.Text = "Corrosion allowance"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 424)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_9.TabIndex = 41
        Me._LabelCil_9.Tag = "kLength"
        Me._LabelCil_9.Text = "Clad or WO thk."
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(8, 448)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_16.TabIndex = 38
        Me._LabelCil_16.Tag = "kTemp"
        Me._LabelCil_16.Text = "Design temperature"
        '
        '_LabelCil_17
        '
        Me._LabelCil_17.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_17.Location = New System.Drawing.Point(8, 472)
        Me._LabelCil_17.Name = "_LabelCil_17"
        Me._LabelCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_17.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_17.TabIndex = 37
        Me._LabelCil_17.Tag = "kPress"
        Me._LabelCil_17.Text = "Design pressure (internal)"
        Me._LabelCil_17.Visible = False
        '
        '_LabelCil_18
        '
        Me._LabelCil_18.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_18.Location = New System.Drawing.Point(8, 496)
        Me._LabelCil_18.Name = "_LabelCil_18"
        Me._LabelCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_18.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_18.TabIndex = 36
        Me._LabelCil_18.Tag = "kPress"
        Me._LabelCil_18.Text = "Design pressure (external)"
        Me._LabelCil_18.Visible = False
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 304)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_8.TabIndex = 28
        Me._LabelCil_8.Text = "Membro accoppiato"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 248)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_7.TabIndex = 26
        Me._LabelCil_7.Text = "Frazione Sy bulloni in P.I."
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 232)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 23
        Me._LabelCil_6.Text = "Disuniformità tiro bulloni"
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 208)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(137, 17)
        Me._LabelCil_5.TabIndex = 13
        Me._LabelCil_5.Text = "Bolt load option"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 184)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(129, 17)
        Me._LabelCil_4.TabIndex = 12
        Me._LabelCil_4.Text = "Calculation type"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 568)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 8
        Me._LabelCil_11.Text = "Number of openings"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 520)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_12.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_12.TabIndex = 7
        Me._LabelCil_12.Tag = "kLength"
        Me._LabelCil_12.Text = "Hydrostatc depth"
        '
        'chkTorq
        '
        Me.chkTorq.BackColor = System.Drawing.SystemColors.Control
        Me.chkTorq.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTorq.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTorq.Location = New System.Drawing.Point(8, 344)
        Me.chkTorq.Name = "chkTorq"
        Me.chkTorq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTorq.Size = New System.Drawing.Size(262, 17)
        Me.chkTorq.TabIndex = 48
        Me.chkTorq.Text = "Calcolo analitico della coppia di serraggio"
        '
        'Check2
        '
        Me.Check2.BackColor = System.Drawing.SystemColors.Control
        Me.Check2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check2.Location = New System.Drawing.Point(8, 360)
        Me.Check2.Name = "Check2"
        Me.Check2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check2.Size = New System.Drawing.Size(217, 17)
        Me.Check2.TabIndex = 30
        Me.Check2.Text = "Verifica del sovraccarico guarnizione"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(8, 344)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_13.TabIndex = 51
        Me._LabelCil_13.Text = "Bolting moment operating [lb.in]"
        Me._LabelCil_13.Visible = False
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(8, 360)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_14.TabIndex = 52
        Me._LabelCil_14.Text = "Bolting moment seating [lb.in]"
        Me._LabelCil_14.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "bin\AsmeVip.chm"
        '
        'frmFlanAn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(306, 632)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFlanAn"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Flangioni/Anelli fucinati/Coperchi piani"
        Me.Frames.ResumeLayout(False)
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmFlanAn
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmFlanAn
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmFlanAn()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public Cancel As Boolean
    Private Loading, Parziale, Inizializzando As Boolean
    Private Sub Inizializza()
        Dim i, ifl As Short
        Dim Riga As String
        Dim NBocch As Short
        Loading = True
        NBocch = Involucr(kLato, jInvolucr).Fine - Involucr(kLato, jInvolucr).inizio + 1
        If NBocch < 0 Or Involucr(kLato, jInvolucr).Fine < 1 Then NBocch = 0
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(2835)
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("Shell Flange ")
        _cmbCil_0.Items.Add("Channel flange")
        _cmbCil_0.Items.Add("Channel cover")
        _cmbCil_0.Items.Add("Other (write)")
        _cmbCil_0.Text = Involucr(kLato, jInvolucr).Mark
        _cmbCil_1.Items.Clear()
        ifl = FreeFile()
        FileOpen(ifl, Trim(clsInizio.Archdir) & "\WN5\WNLJ01.DAT", OpenMode.Input)
        For i = 1 To 9
            Riga = LineInput(ifl)
            _cmbCil_1.Items.Add(Riga)
        Next
        FileClose(ifl)
        i = Involucr(kLato, jInvolucr).IndObject
        _cmbCil_1.SelectedIndex = CType(objMemb(i), wn_flan).Mem.LOOSE + 1
        Select Case CType(objMemb(i), wn_flan).Mem.LOOSE
            Case -1
                If CType(objMemb(i), wn_flan).Zp(7) < 0 Then Check3.CheckState = System.Windows.Forms.CheckState.Checked Else Check3.CheckState = System.Windows.Forms.CheckState.Unchecked
            Case 2
                Check3.CheckState = -CShort(CType(objMemb(i), wn_flan).Mp(195) > 0)
        End Select
        If CType(objMemb(i), wn_flan).Mp(199) = 1 Then Check4.CheckState = System.Windows.Forms.CheckState.Checked Else Check4.CheckState = System.Windows.Forms.CheckState.Unchecked
        _cmbCil_2.Items.Clear()
        _cmbCil_2.Items.Add("Progetto")
        _cmbCil_2.Items.Add("Verifica")
        If Config(0).CalcPI = 1 Then
            _cmbCil_2.Items.Add("P.I. + progetto")
            If Config(0).VerifPI = 1 Then _cmbCil_2.Items.Add("Prova Idraulica")
        End If
        If VerificandoPI Then
            CType(objMemb(i), wn_flan).TipCalc = 4
        Else
            If CType(objMemb(i), wn_flan).TipCalc = 4 Then CType(objMemb(i), wn_flan).TipCalc = 3
        End If
        _cmbCil_2.SelectedIndex = CType(objMemb(i), wn_flan).TipCalc - 1
        If VerificandoPI Then _cmbCil_2.Enabled = False
        cmbCil(3).Items.Clear()
        cmbCil(3).Items.Add("ASME")
        cmbCil(3).Items.Add("Full Bolt")
        cmbCil(3).Items.Add("Fluor Daniel")
        cmbCil(3).Items.Add("Min Prestress")
        cmbCil(3).SelectedIndex = CType(objMemb(i), wn_flan).FullBolt
        If VerificandoPI Then cmbCil(3).Enabled = False
        Popola(cmbMat)
        Popola(cmbMatBolt)
        Dim ij As Short = Involucr(kLato, jInvolucr).indice(1 - 1)
        If ij > -1 Then
            If Not Matdim(ij) Is Nothing Then
                If Not Matdim(ij).MatStr Is Nothing Then
                    cmbMat.Text = Matdim(ij).MatStr.Trim
                    'chkAgganciato.Checked = Matdim(ij).Agganciato
                Else
                    cmbMatBolt.Text = ""
                End If
            Else
                cmbMat.Text = ""
            End If
        End If
        ij = Involucr(kLato, jInvolucr).indice(2 - 1)
        If ij > -1 Then
            If Not Matdim(ij) Is Nothing Then
                If Not Matdim(ij).MatStr Is Nothing Then
                    cmbMatBolt.Text = Matdim(ij).MatStr.Trim
                    'chkAgganciatoB.Checked = Matdim(ij).Agganciato
                Else
                    cmbMatBolt.Text = ""
                End If
            Else
                cmbMatBolt.Text = ""
                End If
            End If
        _TextCil_2.Text = CType(objMemb(i), wn_flan).SicBullp.ToString
        _TextCil_3.Text = CType(objMemb(i), wn_flan).FattBoltSy.ToString
        _TextCil_4.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).OS * kLength, 2, 2, False)
        _TextCil_5.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).cs * kLength, 2, 2, False)
        _TextCil_9.Value = NBocch
        _TextCil_8.Text = Format(objMemb(Involucr(kLato, jInvolucr).IndObject).Zp(204) * kPress, Fors)
        _TextCil_10.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).HydrDepth * kLength, 5, 2, False)
        _TextCil_13.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).DensFluido, 2, 3, False)
        _TextCil_14.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Destemp * kTemp + kTemp32, 5, 3, False)
        If VerificandoPI Then
            _TextCil_14.Visible = False
            _LabelCil_16.Visible = False
        End If
        _TextCil_15.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).PressInt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        _TextCil_16.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).PressExt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        If Config(0).DiverseTemp = 0 Or VerificandoPI Then
            _LabelCil_16.Visible = False
            _TextCil_14.Visible = False
            _cmdCil_5.Visible = False
        End If
        _LabelCil_15.Visible = Not VerificandoPI
        _TextCil_13.Visible = Not VerificandoPI
        _cmdCil_4.Visible = Not VerificandoPI
        _LabelCil_6.Enabled = Not VerificandoPI
        _TextCil_2.Enabled = Not VerificandoPI
        _LabelCil_7.Enabled = Not VerificandoPI
        _TextCil_3.Enabled = Not VerificandoPI
        _LabelCil_8.Enabled = Not VerificandoPI
        _cmbCil_4.Enabled = Not VerificandoPI
        If kLato = 3 Then
            LabelCil(17).Visible = True
            LabelCil(18).Visible = True
            _TextCil_15.Visible = True
            _TextCil_16.Visible = True
            _cmdCil_6.Visible = True
            _LabelCil_16.Visible = True
            _TextCil_14.Visible = True
            _cmdCil_5.Visible = True
        End If
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan)
            If .Verbose Then Check1.CheckState = CheckState.Checked Else Check1.CheckState = CheckState.Unchecked
            If .CRUSH Then Check2.CheckState = CheckState.Checked Else Check2.CheckState = CheckState.Unchecked
            If .BoltLoadDetail Then chkTorq.CheckState = CheckState.Checked Else chkTorq.CheckState = CheckState.Unchecked
        End With
        AggCmb4()
        HelpProvider1.HelpNamespace = RadiceHelp
        Loading = False
    End Sub
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Inizializzando Then Exit Sub
        CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Verbose = (Check1.CheckState = 1)
        Config(0).Verbose = (Check1.CheckState = 1)
    End Sub
    Private Sub Check2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check2.CheckStateChanged
        If Inizializzando Then Exit Sub
        CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).CRUSH = (Check2.CheckState = 1)
    End Sub
    Private Sub Check3_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check3.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim k, i, n As Short
        i = Involucr(kLato, jInvolucr).IndObject
        Select Case CType(objMemb(i), wn_flan).Mem.LOOSE
            Case -1
                If Check3.CheckState = 1 Then
                    CType(objMemb(i), wn_flan).Zp(7) = -1
                Else
                    If CType(objMemb(i), wn_flan).Zp(7) < 0 Then CType(objMemb(i), wn_flan).Zp(7) = 0
                End If
            Case 2
                n = 1
                For k = 1 To Config(3).Ninvolucri
                    If Involucr(3, k).Tipo = 6 Then
                        If CType(objMemb(Involucr(3, k).IndObject), wn_PT).TipoPT = 2 Then
                            If CType(CType(objMemb(Involucr(3, k).IndObject), wn_PT).Piastra, wn_FTC).TipoFF = 10 Then
                                n = 2
                                Exit For
                            End If
                        End If
                    End If
                Next
                CType(objMemb(i), wn_flan).Mp(195) = Check3.CheckState * n
                If Check3.CheckState = 1 Then AggCmb4()
        End Select
    End Sub
    Private Sub Check4_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check4.CheckStateChanged
        If Inizializzando Then Exit Sub
        If Check4.CheckState = 1 Then
            CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Mp(199) = 1
        Else
            CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Mp(199) = 0
        End If
    End Sub
    Private Sub chkTorq_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkTorq.CheckStateChanged
        If Inizializzando Then Exit Sub
        CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).BoltLoadDetail = (chkTorq.CheckState = 1)
    End Sub
    Private Sub cmbCil_SelectedIndexChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim k, i, l, j As Short
        Dim n As Short
        Dim Nodex As TreeNode
        Dim Testo As String
        i = Involucr(kLato, jInvolucr).IndObject
        Try
            Select Case Index
                Case 0 'identification
                    Involucr(kLato, jInvolucr).Mark = cmbCil(Index).Text
                Case 1 'tipo membratura
                    l = cmbCil(Index).SelectedIndex - 1
                    Check3.Visible = (l = -1 Or l = 2)
                    If Not (l = -1 Or l = 2) Then
                        Select Case CType(objMemb(i), wn_flan).Mem.LOOSE
                            Case -1
                                CType(objMemb(i), wn_flan).Zp(7) = 0
                            Case 2
                                CType(objMemb(i), wn_flan).Mp(195) = 0
                        End Select
                    End If
                    Check4.Visible = (l = 0 Or l = 1 Or l = 3 Or l = 7)
                    chkTorq.Visible = (l < 5 Or l = 7)
                    Select Case l
                        Case -1 : Check3.Text = "Split ring for fl.head type S"
                        Case 2 : Check3.Text = "Flange for fl.head type 1.6(d)"
                    End Select
                    Nodex = mioApert.TreeView1.SelectedNode ' mioApert.TreeView1.Nodes(strKey)
                    Select Case l
                        Case -1, 2 : Nodex.ImageIndex = 17
                        Case 4 : Nodex.ImageIndex = 15
                        Case 5 : Nodex.ImageIndex = 16
                        Case Else : Nodex.ImageIndex = 6
                    End Select
                    CType(objMemb(i), wn_flan).Mem.LOOSE = l
                    Select Case l
                        Case 4
                            _LabelCil_11.Visible = True
                            _TextCil_9.Visible = True
                        Case 5, 6
                            Involucr(kLato, jInvolucr).indice(2 - 1) = -1
                        Case Else
                            _LabelCil_11.Visible = False
                            _TextCil_9.Visible = False
                    End Select
                    Select Case l
                        Case 5, 6
                            CType(objMemb(i), wn_flan).TipCalc = 1
                            _LabelCil_4.Visible = False : _cmbCil_2.Visible = False
                            _LabelCil_2.Visible = False : cmbMatBolt.Visible = False : _cmdCil_1.Visible = False : chkAgganciatoB.Visible = False
                            _LabelCil_5.Visible = False : cmbCil(3).Visible = False
                            _LabelCil_6.Visible = False : _TextCil_2.Visible = False
                            _LabelCil_7.Visible = False : _TextCil_3.Visible = False
                            _LabelCil_8.Visible = True : _cmbCil_4.Visible = True
                            Check2.Visible = False
                            chkAgganciatoB.Visible = False
                        Case Else
                            _LabelCil_4.Visible = True : _cmbCil_2.Visible = True
                            _LabelCil_2.Visible = True : cmbMatBolt.Visible = True : _cmdCil_1.Visible = True : chkAgganciatoB.Visible = True
                            _LabelCil_5.Visible = True : cmbCil(3).Visible = True
                            _LabelCil_6.Visible = True : _TextCil_2.Visible = True
                            _LabelCil_7.Visible = True : _TextCil_3.Visible = True
                            _LabelCil_8.Visible = True : _cmbCil_4.Visible = True
                            Check2.Visible = True
                            chkAgganciatoB.Visible = True
                    End Select
                    Select Case l
                        Case 5
                            _LabelCil_13.Visible = True : _TextCil_6.Visible = True
                            LabelCil(14).Visible = True : _TextCil_7.Visible = True
                            _cmdCil_2.Visible = True
                            AggMomBolt(0, False)
                        Case Else
                            _LabelCil_13.Visible = False : _TextCil_6.Visible = False
                            LabelCil(14).Visible = False : _TextCil_7.Visible = False
                            _cmdCil_2.Visible = False
                    End Select
                    CType(objMemb(i), wn_flan).Vari()
                    AggCmb4()
                Case 2 'tipo di calcolo
                    CType(objMemb(i), wn_flan).TipCalc = cmbCil(Index).SelectedIndex + 1
                Case 3 'carico bulloni
                    CType(objMemb(i), wn_flan).FullBolt = cmbCil(Index).SelectedIndex
                    Select Case CType(objMemb(i), wn_flan).FullBolt
                        Case 3 ' Min Prestress
                            If CType(objMemb(i), wn_flan).TipCalc < 3 Then
                                Testo = "Questa opzione può essere attivata solo" & vbCrLf
                                Testo = Testo & "per il tipo di calcolo 'PI + Progetto'."
                                MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                cmbCil(3).SelectedIndex = 0
                            Else
                                LabelCil(19).Visible = True : _TextCil_8.Visible = True
                                If objMemb(i).Zp(204) = 0 Then objMemb(i).Zp(204) = 50000
                                _TextCil_8.Text = Format(objMemb(i).Zp(204), Fors)
                            End If
                        Case Else
                            LabelCil(19).Visible = False : _TextCil_8.Visible = False
                    End Select
                Case 4 'accoppiate
                    List1.SelectedIndex = cmbCil(Index).SelectedIndex
                    If List1.Text = "Nessuno" Or List1.Text = "" Then
                        k = Involucr(kLato, jInvolucr).AccoppK
                        j = Involucr(kLato, jInvolucr).AccoppJ
                        If k > 0 And j > 0 Then
                            Involucr(k, j).AccoppK = 0
                            Involucr(k, j).AccoppJ = 0
                            If CType(objMemb(i), wn_flan).Mem.LOOSE = 5 Then
                                Involucr(k, j).IndAccopp(2) = 0
                            End If
                        End If
                        Involucr(kLato, jInvolucr).AccoppK = 0
                        Involucr(kLato, jInvolucr).AccoppJ = 0
                        If CType(objMemb(i), wn_flan).Mem.LOOSE = 5 Then
                            CType(objMemb(i), wn_flan).Zp(45) = 0
                            CType(objMemb(i), wn_flan).Zp(46) = 0
                        End If
                    Else
                        n = InStr(List1.Text, "_")
                        k = GlobalRoutines.ValVir(VB.Left(List1.Text, n - 1))
                        j = GlobalRoutines.ValVir(VB.Right(List1.Text, Len(List1.Text) - n))
                        If j > 0 And k > 0 Then
                            If Not Parziale Then
                                Involucr(kLato, jInvolucr).AccoppK = k
                                Involucr(kLato, jInvolucr).AccoppJ = j
                                Involucr(k, j).AccoppK = kLato
                                Involucr(k, j).AccoppJ = jInvolucr
                            End If
                            l = Involucr(k, j).indice(2 - 1)
                            If l > -1 Then
                                If l < UBound(Matdim) Then
                                    If Not Matdim(l) Is Nothing Then
                                        Involucr(kLato, jInvolucr).indice(2 - 1) = l
                                        cmbMatBolt.Text = Matdim(l).MatStr
                                        chkAgganciatoB.Checked = Matdim(l).Agganciato
                                    End If
                                End If
                            End If
                        End If
                        AggMomBolt(1, False)
                        End If
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub _cmbCil_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbCil_0.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Mark = _cmbCil_0.Text.Trim
    End Sub

    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(0)
    End Sub

    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
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
    Private Sub _cmdCil_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        cmdCil_Click(0)
    End Sub

    Private Sub _cmdCil_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        cmdCil_Click(1)
    End Sub

    Private Sub _cmdCil_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_2.Click
        cmdCil_Click(2)
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
    Private Sub cmdCil_Click(ByVal Index As Short)
        Dim j, indice, k As Short
        Dim Testo As String
        Select Case Index
            Case 0 'Materiale flangia
                indice = Involucr(kLato, jInvolucr).indice(1 - 1)
                If Matdim(indice) Is Nothing Then
                    Matdim(indice) = New LibMat.MaterialeNew1
                End If
                MatdimScelta(indice, 7, kLato, jInvolucr)
                If Matdim(indice).Editato Then Uniforma(indice)
                Involucr(kLato, jInvolucr).MATE = Matdim(indice).MatStr
                PostSelMat(cmbMat, indice)
            Case 1 'materiale bulloni
                indice = Involucr(kLato, jInvolucr).indice(2 - 1) 'fatto
                MatdimScelta(indice, 8, kLato, jInvolucr)
                If Matdim(indice).Editato Then Uniforma(indice)
                PostSelMat(cmbMatBolt, indice)
                j = Involucr(kLato, jInvolucr).AccoppJ
                k = Involucr(kLato, jInvolucr).AccoppK
                If j > 0 And k > 0 Then
                    If Involucr(k, j).indice(2 - 1) > 0 Then
                        indice = Involucr(kLato, jInvolucr).indice(2 - 1) 'fatto
                        If Matdim(indice).Indmat <> Matdim(Involucr(k, j).indice(2 - 1)).Indmat Then
                            If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Verbose Then
                                Testo = "I tiranti dichiarati nei dati del grande fucinato" & vbCrLf
                                Testo = Testo & "(denominato " & Trim(Involucr(k, j).Mark) & "e accoppiato a" & vbCrLf
                                Testo = Testo & Trim(Involucr(kLato, jInvolucr).Mark) & ") non sono dello stesso" & vbCrLf
                                Testo = Testo & "materiale dei tiranti qui dichiarati." & vbCrLf
                                Testo = Testo & "Vuoi correggere il materiale dei tiranti di " & Trim(Involucr(k, j).Mark) & "?" & vbCrLf
                                Testo = Testo & "N.B.: Se si vuole correggere il materiale di " & Involucr(kLato, jInvolucr).Mark.Trim & vbCrLf
                                Testo = Testo & "rispondere no e selezionare nuovamente il materiale."
                                If MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then Uniforma1(k, j, indice)
                            Else
                                Uniforma1(k, j, indice)
                            End If
                        End If
                    End If
                End If
            Case 2 : AggMomBolt(1, True)
            Case 4
                _TextCil_13.Text = GlobalRoutines.myStr(Config(kLato).DensFluido, 5, 3, False)
            Case 5
                _TextCil_14.Text = GlobalRoutines.myStr(TempDes() * kTemp + kTemp32, 5, 3, False)
            Case 6
                _TextCil_15.Text = GlobalRoutines.myStr(Config(2).p0x * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                _TextCil_16.Text = GlobalRoutines.myStr(Config(1).p0x * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        End Select
    End Sub
    Private Sub Uniforma1(ByVal k As Short, ByVal j As Short, ByVal indice As Short)
        Matdim(Involucr(k, j).indice(2 - 1)).Indmat = Matdim(indice).Indmat 'fatto
        '080706  Involucr(k, j).RecInd(1) = Matdim(indice).Indmat
        Matdim(Involucr(k, j).indice(2 - 1)).RecupMat()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Hide()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        Hide()
    End Sub
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        If Not TextCil(Index).Enabled Then Exit Sub
        With Involucr(kLato, jInvolucr)
            If Not Loading Then CType(objMemb(.IndObject), wn_flan).AzzeraImposti()
            Select Case Index
                Case 2 : If GlobalRoutines.ValVir(TextCil(Index).Text) < 1 Then TextCil(Index).Text = GlobalRoutines.myStr(1.1, 1, 1, False)
                    CType(objMemb(.IndObject), wn_flan).SicBullp = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 3 'If GlobaLroutines.ValVir(TextCil(Index)) > 0.69 Then TextCil(Index) = Str(0.69)
                    CType(objMemb(.IndObject), wn_flan).FattBoltSy = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 4 : .OS = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    Transf()
                Case 5 : .cs = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    Transf()
                Case 6, 7
                    AggMomBolt(Index, False)
                Case 8
                    CType(objMemb(.IndObject), wn_flan).Zp(204) = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    'Case 9 : VariaBocc(Val(TextCil(Index).Text))
                Case 10 : .HydrDepth = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 13 : .DensFluido = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 14 : .Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
                Case 15 : .PressInt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 16 : .PressExt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
            End Select
        End With
    End Sub
    Private Sub Transf()
        Dim iCorr As Short
        Dim c As Single
        With Involucr(kLato, jInvolucr)
            c = .OS : If .cs > .OS Then c = .cs
            Select Case CType(objMemb(.IndObject), wn_flan).Mem.LOOSE
                Case 5, 6 : iCorr = 12
                Case Else : iCorr = 11
            End Select
            CType(objMemb(.IndObject), wn_flan).Zp(iCorr) = c / inc
            CType(objMemb(.IndObject), wn_flan).Mp(iCorr) = c
        End With
    End Sub
    Private Sub AggCmb4()
        Dim ii, i, k As Short
        Dim IndObj As Short
        IndObj = Involucr(kLato, jInvolucr).IndObject
        _cmbCil_4.Items.Clear()
        List1.Items.Clear()
        _cmbCil_4.Items.Add("Nessuno")
        List1.Items.Add("Nessuno")
        ii = 0
        If CType(objMemb(IndObj), wn_flan).Mem.LOOSE = 5 Or (CType(objMemb(IndObj), wn_flan).Mp(195) > 0 And CType(objMemb(IndObj), wn_flan).Mem.LOOSE = 2) Then
            For k = 1 To Config(3).Ninvolucri
                If Involucr(3, k).Tipo = 5 Or Involucr(3, k).Tipo = 6 Then
                    _cmbCil_4.Items.Add(Involucr(3, k).Mark)
                    List1.Items.Add(Trim("3") & "_" & Trim(Str(k)))
                    ii = ii + 1
                    If Involucr(kLato, jInvolucr).AccoppJ = k And Involucr(kLato, jInvolucr).AccoppK = 3 Then _cmbCil_4.SelectedIndex = ii
                End If
            Next
        Else
            For i = 1 To Config(0).NumeroLati
                For k = 1 To Config(i).Ninvolucri
                    If Not (i = kLato And k = jInvolucr) Then
                        If Involucr(i, k).Tipo = 5 Or Involucr(i, k).Tipo = 6 Then
                            _cmbCil_4.Items.Add(Involucr(i, k).Mark)
                            List1.Items.Add(Trim(i.ToString) & "_" & Trim(Str(k)))
                            ii = ii + 1
                            If Involucr(kLato, jInvolucr).AccoppJ = k And Involucr(kLato, jInvolucr).AccoppK = i Then
                                Parziale = True
                                _cmbCil_4.SelectedIndex = ii
                                Parziale = False
                            End If
                        End If
                    End If
                Next
            Next
        End If
        If ii = 0 Then
            _cmbCil_4.SelectedIndex = 0
        Else
            If _cmbCil_4.SelectedIndex = -1 Then _cmbCil_4.SelectedIndex = 0
        End If
    End Sub
    Private Sub AggMomBolt(ByRef mode As Short, ByRef visual As Boolean)
        Dim k, IndObj, j As Short
        Dim PTUTEMA As wn_UTEMA
        Dim PT As wn_PT
        Dim wn As wn_flan
        Dim Num As Single
        Dim Testo As String
        _TextCil_6.Text = ""
        _TextCil_7.Text = ""
        k = Involucr(kLato, jInvolucr).AccoppK
        j = Involucr(kLato, jInvolucr).AccoppJ
        If k = 3 And j > 0 Then
            If Involucr(k, j).Tipo = 6 Then
                IndObj = Involucr(k, j).IndObject
                If IndObj > 0 Then
                    PT = objMemb(IndObj)
                    If PT.TipoPT = 1 Then
                        IndObj = Involucr(kLato, jInvolucr).IndObject
                        If IndObj > 0 Then
                            wn = objMemb(IndObj)
                            PTUTEMA = PT.Piastra
                            If Not wn Is Nothing And Not PTUTEMA Is Nothing Then
                                If mode < 2 Then
                                    If mode = 1 Then
                                        wn.Zp(45) = System.Math.Abs(PTUTEMA.Mom1)
                                        wn.Zp(46) = System.Math.Abs(PTUTEMA.Mom2)
                                        If System.Math.Abs(PTUTEMA.Mom1) = 0 And System.Math.Abs(PTUTEMA.Mom2) = 0 Then
                                            Testo = "I momenti di flangia provenienti dall'estensione della piastra tubiera" & vbCrLf
                                            Testo = Testo & "risultano nulli. Assicurarsi di eseguire prima il calcolo di quest'ultima" & vbCrLf
                                            Testo = Testo & "se si vuole eseguire il calcolo automatico del carico di serraggio trasmesso" & vbCrLf
                                            Testo = Testo & " al transition piece."
                                            If visual Then MessageBox.Show(Me, Testo, "AsmeVip - " & Trim(Involucr(kLato, jInvolucr).Mark), MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If
                                    End If
                                    _TextCil_6.Enabled = False
                                    _TextCil_7.Enabled = False
                                    _TextCil_6.Text = GlobalRoutines.myStr(wn.Zp(45) * kMomF, 8, 1, False)
                                    _TextCil_7.Text = GlobalRoutines.myStr(wn.Zp(46) * kMomF, 8, 1, False)
                                    _TextCil_6.Enabled = True
                                    _TextCil_7.Enabled = True
                                Else
                                    If mode = 6 Then
                                        Num = GlobalRoutines.ValVir(_TextCil_6.Text) / kMomF
                                        If Num > 0 Then wn.Zp(45) = Num
                                    Else
                                        Num = GlobalRoutines.ValVir(_TextCil_7.Text) / kMomF
                                        If Num > 0 Then wn.Zp(46) = Num
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            Testo = "Non è stata collegata una piastra tubiera a questa membratura." & vbCrLf
            Testo = Testo & "Di conseguenza non è possibile aggiornare in modo automatico" & vbCrLf
            Testo = Testo & "i valori delle azioni provenienti dai bulloni."
            If visual Then MessageBox.Show(Testo, "AsmeVip - " & Trim(Involucr(kLato, jInvolucr).Mark), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
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
                Case 4 : Return _cmdCil_4
                Case 5 : Return _cmdCil_5
                Case 6 : Return _cmdCil_6
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 2 : Return _TextCil_2
                Case 3 : Return _TextCil_3
                Case 4 : Return _TextCil_4
                Case 5 : Return _TextCil_5
                Case 6 : Return _TextCil_6
                Case 7 : Return _TextCil_7
                Case 8 : Return _TextCil_8
                    'Case 9 : Return _TextCil_9
                Case 10 : Return _TextCil_10
                Case 13 : Return _TextCil_13
                Case 14 : Return _TextCil_14
                Case 15 : Return _TextCil_15
                Case 16 : Return _TextCil_16
                Case Else : Return Nothing
            End Select
        End Get
    End Property
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
    Private Sub _TextCil_9_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.ValueChanged
        VariaBocc(_TextCil_9.Value)
    End Sub
    Private Sub _TextCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.TextChanged
        TextCil_TextChanged(10)
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
    Private Sub _TextCil_14_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.Leave
        AvvertiDT()
    End Sub
    Private Sub chkAgganciato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato = chkAgganciato.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciato_CheckedChangedB(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoB.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(1)).Agganciato = chkAgganciatoB.Checked
        ModifiedData = True
    End Sub
    Private Sub frmFlanAn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AggiornaLabels(Me, 19)
    End Sub
    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Involucr(kLato, jInvolucr).indice(0), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
        chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub
    Private Sub cmbMatBolt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatBolt.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatBolt, Involucr(kLato, jInvolucr).indice(1), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatBolt.SelectedIndex = nuovoSelect
        chkAgganciatoB.Checked = Matdim(Involucr(kLato, jInvolucr).indice(1)).Agganciato
    End Sub
End Class