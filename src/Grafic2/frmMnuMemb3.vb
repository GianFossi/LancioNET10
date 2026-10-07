Option Strict Off
Option Explicit On
Friend Class frmMnuMemb3
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
	Public WithEvents _Option1_105 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_104 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_103 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_98 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_97 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_96 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_88 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_87 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_86 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_85 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_84 As System.Windows.Forms.RadioButton
	Public WithEvents _frmLato_3 As System.Windows.Forms.GroupBox
	Public WithEvents _Option1_83 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_82 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_81 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_80 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_79 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_78 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_77 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_76 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_75 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_74 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_73 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_72 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_71 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_70 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_69 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_68 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_67 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_65 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_64 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_63 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_61 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_60 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_59 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_58 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_56 As System.Windows.Forms.RadioButton
	Public WithEvents _frmLato_2 As System.Windows.Forms.GroupBox
	Public WithEvents _Option1_55 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_54 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_53 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_52 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_51 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_48 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_47 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_46 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_45 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_44 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_43 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_42 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_41 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_40 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_39 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_38 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_37 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_36 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_35 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_32 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_31 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_30 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_29 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_28 As System.Windows.Forms.RadioButton
	Public WithEvents _frmLato_1 As System.Windows.Forms.GroupBox
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_3 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_4 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_7 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_8 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_9 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_10 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_11 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_12 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_13 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_14 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_15 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_16 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_18 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_20 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_21 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_24 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_25 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_26 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_19 As System.Windows.Forms.RadioButton
	Public WithEvents _frmLato_0 As System.Windows.Forms.GroupBox
	Public WithEvents _Command1_2 As System.Windows.Forms.Button
	Public WithEvents _Command1_1 As System.Windows.Forms.Button
	Public WithEvents _Command1_0 As System.Windows.Forms.Button
	Public Command1 As New System.Collections.Generic.Dictionary(Of Integer, Button)
	Public Option1 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
	Public frmLato As New System.Collections.Generic.Dictionary(Of Integer, GroupBox)
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._frmLato_3 = New System.Windows.Forms.GroupBox
        Me._Option1_105 = New System.Windows.Forms.RadioButton
        Me._Option1_104 = New System.Windows.Forms.RadioButton
        Me._Option1_103 = New System.Windows.Forms.RadioButton
        Me._Option1_98 = New System.Windows.Forms.RadioButton
        Me._Option1_97 = New System.Windows.Forms.RadioButton
        Me._Option1_96 = New System.Windows.Forms.RadioButton
        Me._Option1_88 = New System.Windows.Forms.RadioButton
        Me._Option1_87 = New System.Windows.Forms.RadioButton
        Me._Option1_86 = New System.Windows.Forms.RadioButton
        Me._Option1_85 = New System.Windows.Forms.RadioButton
        Me._Option1_84 = New System.Windows.Forms.RadioButton
        Me._frmLato_2 = New System.Windows.Forms.GroupBox
        Me._Option1_83 = New System.Windows.Forms.RadioButton
        Me._Option1_82 = New System.Windows.Forms.RadioButton
        Me._Option1_81 = New System.Windows.Forms.RadioButton
        Me._Option1_80 = New System.Windows.Forms.RadioButton
        Me._Option1_79 = New System.Windows.Forms.RadioButton
        Me._Option1_78 = New System.Windows.Forms.RadioButton
        Me._Option1_77 = New System.Windows.Forms.RadioButton
        Me._Option1_76 = New System.Windows.Forms.RadioButton
        Me._Option1_75 = New System.Windows.Forms.RadioButton
        Me._Option1_74 = New System.Windows.Forms.RadioButton
        Me._Option1_73 = New System.Windows.Forms.RadioButton
        Me._Option1_72 = New System.Windows.Forms.RadioButton
        Me._Option1_71 = New System.Windows.Forms.RadioButton
        Me._Option1_70 = New System.Windows.Forms.RadioButton
        Me._Option1_69 = New System.Windows.Forms.RadioButton
        Me._Option1_68 = New System.Windows.Forms.RadioButton
        Me._Option1_67 = New System.Windows.Forms.RadioButton
        Me._Option1_65 = New System.Windows.Forms.RadioButton
        Me._Option1_64 = New System.Windows.Forms.RadioButton
        Me._Option1_63 = New System.Windows.Forms.RadioButton
        Me._Option1_61 = New System.Windows.Forms.RadioButton
        Me._Option1_60 = New System.Windows.Forms.RadioButton
        Me._Option1_59 = New System.Windows.Forms.RadioButton
        Me._Option1_58 = New System.Windows.Forms.RadioButton
        Me._Option1_56 = New System.Windows.Forms.RadioButton
        Me._frmLato_1 = New System.Windows.Forms.GroupBox
        Me._Option1_55 = New System.Windows.Forms.RadioButton
        Me._Option1_54 = New System.Windows.Forms.RadioButton
        Me._Option1_53 = New System.Windows.Forms.RadioButton
        Me._Option1_52 = New System.Windows.Forms.RadioButton
        Me._Option1_51 = New System.Windows.Forms.RadioButton
        Me._Option1_48 = New System.Windows.Forms.RadioButton
        Me._Option1_47 = New System.Windows.Forms.RadioButton
        Me._Option1_46 = New System.Windows.Forms.RadioButton
        Me._Option1_45 = New System.Windows.Forms.RadioButton
        Me._Option1_44 = New System.Windows.Forms.RadioButton
        Me._Option1_43 = New System.Windows.Forms.RadioButton
        Me._Option1_42 = New System.Windows.Forms.RadioButton
        Me._Option1_41 = New System.Windows.Forms.RadioButton
        Me._Option1_40 = New System.Windows.Forms.RadioButton
        Me._Option1_39 = New System.Windows.Forms.RadioButton
        Me._Option1_38 = New System.Windows.Forms.RadioButton
        Me._Option1_37 = New System.Windows.Forms.RadioButton
        Me._Option1_36 = New System.Windows.Forms.RadioButton
        Me._Option1_35 = New System.Windows.Forms.RadioButton
        Me._Option1_32 = New System.Windows.Forms.RadioButton
        Me._Option1_31 = New System.Windows.Forms.RadioButton
        Me._Option1_30 = New System.Windows.Forms.RadioButton
        Me._Option1_29 = New System.Windows.Forms.RadioButton
        Me._Option1_28 = New System.Windows.Forms.RadioButton
        Me._frmLato_0 = New System.Windows.Forms.GroupBox
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_2 = New System.Windows.Forms.RadioButton
        Me._Option1_3 = New System.Windows.Forms.RadioButton
        Me._Option1_4 = New System.Windows.Forms.RadioButton
        Me._Option1_7 = New System.Windows.Forms.RadioButton
        Me._Option1_8 = New System.Windows.Forms.RadioButton
        Me._Option1_9 = New System.Windows.Forms.RadioButton
        Me._Option1_10 = New System.Windows.Forms.RadioButton
        Me._Option1_11 = New System.Windows.Forms.RadioButton
        Me._Option1_12 = New System.Windows.Forms.RadioButton
        Me._Option1_13 = New System.Windows.Forms.RadioButton
        Me._Option1_14 = New System.Windows.Forms.RadioButton
        Me._Option1_15 = New System.Windows.Forms.RadioButton
        Me._Option1_16 = New System.Windows.Forms.RadioButton
        Me._Option1_18 = New System.Windows.Forms.RadioButton
        Me._Option1_20 = New System.Windows.Forms.RadioButton
        Me._Option1_21 = New System.Windows.Forms.RadioButton
        Me._Option1_24 = New System.Windows.Forms.RadioButton
        Me._Option1_25 = New System.Windows.Forms.RadioButton
        Me._Option1_26 = New System.Windows.Forms.RadioButton
        Me._Option1_19 = New System.Windows.Forms.RadioButton
        Me._Command1_2 = New System.Windows.Forms.Button
        Me._Command1_1 = New System.Windows.Forms.Button
        Me._Command1_0 = New System.Windows.Forms.Button
        Me._frmLato_3.SuspendLayout()
        Me._frmLato_2.SuspendLayout()
        Me._frmLato_1.SuspendLayout()
        Me._frmLato_0.SuspendLayout()
        Me.SuspendLayout()
        '
        '_frmLato_3
        '
        Me._frmLato_3.BackColor = System.Drawing.SystemColors.Control
        Me._frmLato_3.Controls.Add(Me._Option1_105)
        Me._frmLato_3.Controls.Add(Me._Option1_104)
        Me._frmLato_3.Controls.Add(Me._Option1_103)
        Me._frmLato_3.Controls.Add(Me._Option1_98)
        Me._frmLato_3.Controls.Add(Me._Option1_97)
        Me._frmLato_3.Controls.Add(Me._Option1_96)
        Me._frmLato_3.Controls.Add(Me._Option1_88)
        Me._frmLato_3.Controls.Add(Me._Option1_87)
        Me._frmLato_3.Controls.Add(Me._Option1_86)
        Me._frmLato_3.Controls.Add(Me._Option1_85)
        Me._frmLato_3.Controls.Add(Me._Option1_84)
        Me._frmLato_3.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.frmLato.Add(3, Me._frmLato_3)
        Me._frmLato_3.Location = New System.Drawing.Point(592, 0)
        Me._frmLato_3.Name = "_frmLato_3"
        Me._frmLato_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmLato_3.Size = New System.Drawing.Size(201, 473)
        Me._frmLato_3.TabIndex = 77
        Me._frmLato_3.TabStop = False
        Me._frmLato_3.Tag = "4"
        Me._frmLato_3.Text = "Non a pressione"
        '
        '_Option1_105
        '
        Me._Option1_105.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_105.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_105.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(105, Me._Option1_105)
        Me._Option1_105.Location = New System.Drawing.Point(8, 448)
        Me._Option1_105.Name = "_Option1_105"
        Me._Option1_105.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_105.Size = New System.Drawing.Size(180, 17)
        Me._Option1_105.TabIndex = 88
        Me._Option1_105.TabStop = True
        Me._Option1_105.Tag = "25"
        Me._Option1_105.Text = "Supporti"
        '
        '_Option1_104
        '
        Me._Option1_104.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_104.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_104.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(104, Me._Option1_104)
        Me._Option1_104.Location = New System.Drawing.Point(8, 432)
        Me._Option1_104.Name = "_Option1_104"
        Me._Option1_104.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_104.Size = New System.Drawing.Size(180, 17)
        Me._Option1_104.TabIndex = 87
        Me._Option1_104.TabStop = True
        Me._Option1_104.Tag = "24"
        Me._Option1_104.Text = "Varie"
        '
        '_Option1_103
        '
        Me._Option1_103.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_103.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_103.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(103, Me._Option1_103)
        Me._Option1_103.Location = New System.Drawing.Point(8, 240)
        Me._Option1_103.Name = "_Option1_103"
        Me._Option1_103.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_103.Size = New System.Drawing.Size(180, 17)
        Me._Option1_103.TabIndex = 86
        Me._Option1_103.TabStop = True
        Me._Option1_103.Tag = "23"
        Me._Option1_103.Text = "Tondi"
        '
        '_Option1_98
        '
        Me._Option1_98.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_98.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_98.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(98, Me._Option1_98)
        Me._Option1_98.Location = New System.Drawing.Point(8, 288)
        Me._Option1_98.Name = "_Option1_98"
        Me._Option1_98.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_98.Size = New System.Drawing.Size(180, 17)
        Me._Option1_98.TabIndex = 85
        Me._Option1_98.TabStop = True
        Me._Option1_98.Tag = "17"
        Me._Option1_98.Text = "Anelli da lamiera"
        '
        '_Option1_97
        '
        Me._Option1_97.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_97.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_97.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(97, Me._Option1_97)
        Me._Option1_97.Location = New System.Drawing.Point(8, 80)
        Me._Option1_97.Name = "_Option1_97"
        Me._Option1_97.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_97.Size = New System.Drawing.Size(180, 17)
        Me._Option1_97.TabIndex = 84
        Me._Option1_97.TabStop = True
        Me._Option1_97.Tag = "16"
        Me._Option1_97.Text = "Dischi / calotte / fondi piani"
        '
        '_Option1_96
        '
        Me._Option1_96.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_96.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_96.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(96, Me._Option1_96)
        Me._Option1_96.Location = New System.Drawing.Point(8, 272)
        Me._Option1_96.Name = "_Option1_96"
        Me._Option1_96.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_96.Size = New System.Drawing.Size(180, 17)
        Me._Option1_96.TabIndex = 83
        Me._Option1_96.TabStop = True
        Me._Option1_96.Tag = "15"
        Me._Option1_96.Text = "Lamiere piane"
        '
        '_Option1_88
        '
        Me._Option1_88.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_88.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_88.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(88, Me._Option1_88)
        Me._Option1_88.Location = New System.Drawing.Point(8, 32)
        Me._Option1_88.Name = "_Option1_88"
        Me._Option1_88.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_88.Size = New System.Drawing.Size(180, 17)
        Me._Option1_88.TabIndex = 82
        Me._Option1_88.TabStop = True
        Me._Option1_88.Tag = "7"
        Me._Option1_88.Text = "Coni"
        '
        '_Option1_87
        '
        Me._Option1_87.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_87.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_87.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(87, Me._Option1_87)
        Me._Option1_87.Location = New System.Drawing.Point(8, 48)
        Me._Option1_87.Name = "_Option1_87"
        Me._Option1_87.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_87.Size = New System.Drawing.Size(180, 17)
        Me._Option1_87.TabIndex = 81
        Me._Option1_87.TabStop = True
        Me._Option1_87.Tag = "6"
        Me._Option1_87.Text = "Conoidi"
        '
        '_Option1_86
        '
        Me._Option1_86.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_86.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_86.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(86, Me._Option1_86)
        Me._Option1_86.Location = New System.Drawing.Point(8, 64)
        Me._Option1_86.Name = "_Option1_86"
        Me._Option1_86.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_86.Size = New System.Drawing.Size(180, 17)
        Me._Option1_86.TabIndex = 80
        Me._Option1_86.TabStop = True
        Me._Option1_86.Tag = "3"
        Me._Option1_86.Text = "Fondi"
        '
        '_Option1_85
        '
        Me._Option1_85.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_85.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_85.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(85, Me._Option1_85)
        Me._Option1_85.Location = New System.Drawing.Point(8, 336)
        Me._Option1_85.Name = "_Option1_85"
        Me._Option1_85.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_85.Size = New System.Drawing.Size(180, 17)
        Me._Option1_85.TabIndex = 79
        Me._Option1_85.TabStop = True
        Me._Option1_85.Tag = "2"
        Me._Option1_85.Text = "Tubi (tronchetti)"
        '
        '_Option1_84
        '
        Me._Option1_84.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_84.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_84.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(84, Me._Option1_84)
        Me._Option1_84.Location = New System.Drawing.Point(8, 16)
        Me._Option1_84.Name = "_Option1_84"
        Me._Option1_84.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_84.Size = New System.Drawing.Size(180, 17)
        Me._Option1_84.TabIndex = 78
        Me._Option1_84.TabStop = True
        Me._Option1_84.Tag = "1"
        Me._Option1_84.Text = "Cilindri/Virole fucinate"
        '
        '_frmLato_2
        '
        Me._frmLato_2.BackColor = System.Drawing.SystemColors.Control
        Me._frmLato_2.Controls.Add(Me._Option1_83)
        Me._frmLato_2.Controls.Add(Me._Option1_82)
        Me._frmLato_2.Controls.Add(Me._Option1_81)
        Me._frmLato_2.Controls.Add(Me._Option1_80)
        Me._frmLato_2.Controls.Add(Me._Option1_79)
        Me._frmLato_2.Controls.Add(Me._Option1_78)
        Me._frmLato_2.Controls.Add(Me._Option1_77)
        Me._frmLato_2.Controls.Add(Me._Option1_76)
        Me._frmLato_2.Controls.Add(Me._Option1_75)
        Me._frmLato_2.Controls.Add(Me._Option1_74)
        Me._frmLato_2.Controls.Add(Me._Option1_73)
        Me._frmLato_2.Controls.Add(Me._Option1_72)
        Me._frmLato_2.Controls.Add(Me._Option1_71)
        Me._frmLato_2.Controls.Add(Me._Option1_70)
        Me._frmLato_2.Controls.Add(Me._Option1_69)
        Me._frmLato_2.Controls.Add(Me._Option1_68)
        Me._frmLato_2.Controls.Add(Me._Option1_67)
        Me._frmLato_2.Controls.Add(Me._Option1_65)
        Me._frmLato_2.Controls.Add(Me._Option1_64)
        Me._frmLato_2.Controls.Add(Me._Option1_63)
        Me._frmLato_2.Controls.Add(Me._Option1_61)
        Me._frmLato_2.Controls.Add(Me._Option1_60)
        Me._frmLato_2.Controls.Add(Me._Option1_59)
        Me._frmLato_2.Controls.Add(Me._Option1_58)
        Me._frmLato_2.Controls.Add(Me._Option1_56)
        Me._frmLato_2.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.frmLato.Add(2, Me._frmLato_2)
        Me._frmLato_2.Location = New System.Drawing.Point(400, 0)
        Me._frmLato_2.Name = "_frmLato_2"
        Me._frmLato_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmLato_2.Size = New System.Drawing.Size(201, 473)
        Me._frmLato_2.TabIndex = 51
        Me._frmLato_2.TabStop = False
        Me._frmLato_2.Tag = "3"
        Me._frmLato_2.Text = "Fra i due lati"
        '
        '_Option1_83
        '
        Me._Option1_83.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_83.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(83, Me._Option1_83)
        Me._Option1_83.Location = New System.Drawing.Point(8, 16)
        Me._Option1_83.Name = "_Option1_83"
        Me._Option1_83.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_83.Size = New System.Drawing.Size(180, 17)
        Me._Option1_83.TabIndex = 76
        Me._Option1_83.TabStop = True
        Me._Option1_83.Tag = "1"
        Me._Option1_83.Text = "Cilindri/Virole fucinate"
        '
        '_Option1_82
        '
        Me._Option1_82.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_82.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_82.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(82, Me._Option1_82)
        Me._Option1_82.Location = New System.Drawing.Point(8, 336)
        Me._Option1_82.Name = "_Option1_82"
        Me._Option1_82.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_82.Size = New System.Drawing.Size(180, 17)
        Me._Option1_82.TabIndex = 75
        Me._Option1_82.TabStop = True
        Me._Option1_82.Tag = "2"
        Me._Option1_82.Text = "Tubi (tronchetti)"
        '
        '_Option1_81
        '
        Me._Option1_81.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_81.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_81.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(81, Me._Option1_81)
        Me._Option1_81.Location = New System.Drawing.Point(8, 64)
        Me._Option1_81.Name = "_Option1_81"
        Me._Option1_81.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_81.Size = New System.Drawing.Size(180, 17)
        Me._Option1_81.TabIndex = 74
        Me._Option1_81.TabStop = True
        Me._Option1_81.Tag = "3"
        Me._Option1_81.Text = "Fondi"
        '
        '_Option1_80
        '
        Me._Option1_80.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_80.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(80, Me._Option1_80)
        Me._Option1_80.Location = New System.Drawing.Point(8, 48)
        Me._Option1_80.Name = "_Option1_80"
        Me._Option1_80.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_80.Size = New System.Drawing.Size(180, 17)
        Me._Option1_80.TabIndex = 73
        Me._Option1_80.TabStop = True
        Me._Option1_80.Tag = "6"
        Me._Option1_80.Text = "Conoidi"
        '
        '_Option1_79
        '
        Me._Option1_79.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_79.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_79.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(79, Me._Option1_79)
        Me._Option1_79.Location = New System.Drawing.Point(8, 32)
        Me._Option1_79.Name = "_Option1_79"
        Me._Option1_79.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_79.Size = New System.Drawing.Size(180, 17)
        Me._Option1_79.TabIndex = 72
        Me._Option1_79.TabStop = True
        Me._Option1_79.Tag = "7"
        Me._Option1_79.Text = "Coni"
        '
        '_Option1_78
        '
        Me._Option1_78.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_78.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_78.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(78, Me._Option1_78)
        Me._Option1_78.Location = New System.Drawing.Point(8, 208)
        Me._Option1_78.Name = "_Option1_78"
        Me._Option1_78.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_78.Size = New System.Drawing.Size(180, 17)
        Me._Option1_78.TabIndex = 71
        Me._Option1_78.TabStop = True
        Me._Option1_78.Tag = "8"
        Me._Option1_78.Text = "Tubi scambiatori / distanziatori"
        '
        '_Option1_77
        '
        Me._Option1_77.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_77.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(77, Me._Option1_77)
        Me._Option1_77.Location = New System.Drawing.Point(8, 224)
        Me._Option1_77.Name = "_Option1_77"
        Me._Option1_77.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_77.Size = New System.Drawing.Size(180, 17)
        Me._Option1_77.TabIndex = 70
        Me._Option1_77.TabStop = True
        Me._Option1_77.Tag = "9"
        Me._Option1_77.Text = "Tubi ad U"
        '
        '_Option1_76
        '
        Me._Option1_76.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_76.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(76, Me._Option1_76)
        Me._Option1_76.Location = New System.Drawing.Point(8, 160)
        Me._Option1_76.Name = "_Option1_76"
        Me._Option1_76.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_76.Size = New System.Drawing.Size(180, 17)
        Me._Option1_76.TabIndex = 69
        Me._Option1_76.TabStop = True
        Me._Option1_76.Tag = "10"
        Me._Option1_76.Text = "Bocchelli con flangia standard"
        '
        '_Option1_75
        '
        Me._Option1_75.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_75.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_75.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(75, Me._Option1_75)
        Me._Option1_75.Location = New System.Drawing.Point(8, 96)
        Me._Option1_75.Name = "_Option1_75"
        Me._Option1_75.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_75.Size = New System.Drawing.Size(180, 17)
        Me._Option1_75.TabIndex = 68
        Me._Option1_75.TabStop = True
        Me._Option1_75.Tag = "11"
        Me._Option1_75.Text = "Flangioni / anelli fucinati"
        '
        '_Option1_74
        '
        Me._Option1_74.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_74.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_74.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(74, Me._Option1_74)
        Me._Option1_74.Location = New System.Drawing.Point(8, 112)
        Me._Option1_74.Name = "_Option1_74"
        Me._Option1_74.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_74.Size = New System.Drawing.Size(180, 17)
        Me._Option1_74.TabIndex = 67
        Me._Option1_74.TabStop = True
        Me._Option1_74.Tag = "12"
        Me._Option1_74.Text = "Piastre tubiere"
        '
        '_Option1_73
        '
        Me._Option1_73.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_73.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_73.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(73, Me._Option1_73)
        Me._Option1_73.Location = New System.Drawing.Point(8, 128)
        Me._Option1_73.Name = "_Option1_73"
        Me._Option1_73.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_73.Size = New System.Drawing.Size(180, 17)
        Me._Option1_73.TabIndex = 66
        Me._Option1_73.TabStop = True
        Me._Option1_73.Tag = "13"
        Me._Option1_73.Text = "Tiranteria metrica / ANSI"
        '
        '_Option1_72
        '
        Me._Option1_72.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_72.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_72.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(72, Me._Option1_72)
        Me._Option1_72.Location = New System.Drawing.Point(8, 176)
        Me._Option1_72.Name = "_Option1_72"
        Me._Option1_72.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_72.Size = New System.Drawing.Size(180, 17)
        Me._Option1_72.TabIndex = 65
        Me._Option1_72.TabStop = True
        Me._Option1_72.Tag = "14"
        Me._Option1_72.Text = "Bocchelli integrali da forgiato"
        '
        '_Option1_71
        '
        Me._Option1_71.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_71.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_71.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(71, Me._Option1_71)
        Me._Option1_71.Location = New System.Drawing.Point(8, 272)
        Me._Option1_71.Name = "_Option1_71"
        Me._Option1_71.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_71.Size = New System.Drawing.Size(180, 17)
        Me._Option1_71.TabIndex = 64
        Me._Option1_71.TabStop = True
        Me._Option1_71.Tag = "15"
        Me._Option1_71.Text = "Lamiere piane"
        '
        '_Option1_70
        '
        Me._Option1_70.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_70.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(70, Me._Option1_70)
        Me._Option1_70.Location = New System.Drawing.Point(8, 80)
        Me._Option1_70.Name = "_Option1_70"
        Me._Option1_70.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_70.Size = New System.Drawing.Size(180, 17)
        Me._Option1_70.TabIndex = 63
        Me._Option1_70.TabStop = True
        Me._Option1_70.Tag = "16"
        Me._Option1_70.Text = "Dischi / calotte / fondi piani"
        '
        '_Option1_69
        '
        Me._Option1_69.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_69.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(69, Me._Option1_69)
        Me._Option1_69.Location = New System.Drawing.Point(8, 288)
        Me._Option1_69.Name = "_Option1_69"
        Me._Option1_69.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_69.Size = New System.Drawing.Size(180, 17)
        Me._Option1_69.TabIndex = 62
        Me._Option1_69.TabStop = True
        Me._Option1_69.Tag = "17"
        Me._Option1_69.Text = "Anelli da lamiera"
        '
        '_Option1_68
        '
        Me._Option1_68.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_68.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(68, Me._Option1_68)
        Me._Option1_68.Location = New System.Drawing.Point(8, 304)
        Me._Option1_68.Name = "_Option1_68"
        Me._Option1_68.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_68.Size = New System.Drawing.Size(180, 17)
        Me._Option1_68.TabIndex = 61
        Me._Option1_68.TabStop = True
        Me._Option1_68.Tag = "18"
        Me._Option1_68.Text = "Dilatatori"
        '
        '_Option1_67
        '
        Me._Option1_67.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_67.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(67, Me._Option1_67)
        Me._Option1_67.Location = New System.Drawing.Point(8, 256)
        Me._Option1_67.Name = "_Option1_67"
        Me._Option1_67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_67.Size = New System.Drawing.Size(180, 17)
        Me._Option1_67.TabIndex = 60
        Me._Option1_67.TabStop = True
        Me._Option1_67.Tag = "19"
        Me._Option1_67.Text = "Diaframmi e piatti forati"
        '
        '_Option1_65
        '
        Me._Option1_65.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_65.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(65, Me._Option1_65)
        Me._Option1_65.Location = New System.Drawing.Point(8, 352)
        Me._Option1_65.Name = "_Option1_65"
        Me._Option1_65.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_65.Size = New System.Drawing.Size(180, 17)
        Me._Option1_65.TabIndex = 59
        Me._Option1_65.TabStop = True
        Me._Option1_65.Tag = "21"
        Me._Option1_65.Text = "Curve"
        '
        '_Option1_64
        '
        Me._Option1_64.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_64.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(64, Me._Option1_64)
        Me._Option1_64.Location = New System.Drawing.Point(8, 240)
        Me._Option1_64.Name = "_Option1_64"
        Me._Option1_64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_64.Size = New System.Drawing.Size(180, 17)
        Me._Option1_64.TabIndex = 58
        Me._Option1_64.TabStop = True
        Me._Option1_64.Tag = "23"
        Me._Option1_64.Text = "Tondi"
        '
        '_Option1_63
        '
        Me._Option1_63.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_63.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(63, Me._Option1_63)
        Me._Option1_63.Location = New System.Drawing.Point(8, 432)
        Me._Option1_63.Name = "_Option1_63"
        Me._Option1_63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_63.Size = New System.Drawing.Size(180, 17)
        Me._Option1_63.TabIndex = 57
        Me._Option1_63.TabStop = True
        Me._Option1_63.Tag = "24"
        Me._Option1_63.Text = "Varie"
        '
        '_Option1_61
        '
        Me._Option1_61.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_61.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(61, Me._Option1_61)
        Me._Option1_61.Location = New System.Drawing.Point(8, 192)
        Me._Option1_61.Name = "_Option1_61"
        Me._Option1_61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_61.Size = New System.Drawing.Size(180, 17)
        Me._Option1_61.TabIndex = 56
        Me._Option1_61.TabStop = True
        Me._Option1_61.Tag = "26"
        Me._Option1_61.Text = "Fasci tubieri"
        '
        '_Option1_60
        '
        Me._Option1_60.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_60.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(60, Me._Option1_60)
        Me._Option1_60.Location = New System.Drawing.Point(8, 384)
        Me._Option1_60.Name = "_Option1_60"
        Me._Option1_60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_60.Size = New System.Drawing.Size(180, 17)
        Me._Option1_60.TabIndex = 55
        Me._Option1_60.TabStop = True
        Me._Option1_60.Tag = "27"
        Me._Option1_60.Text = "Manicotti forgiati"
        '
        '_Option1_59
        '
        Me._Option1_59.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_59.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(59, Me._Option1_59)
        Me._Option1_59.Location = New System.Drawing.Point(8, 400)
        Me._Option1_59.Name = "_Option1_59"
        Me._Option1_59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_59.Size = New System.Drawing.Size(180, 17)
        Me._Option1_59.TabIndex = 54
        Me._Option1_59.TabStop = True
        Me._Option1_59.Tag = "29"
        Me._Option1_59.Text = "Tappi forgiati"
        '
        '_Option1_58
        '
        Me._Option1_58.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_58.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(58, Me._Option1_58)
        Me._Option1_58.Location = New System.Drawing.Point(8, 144)
        Me._Option1_58.Name = "_Option1_58"
        Me._Option1_58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_58.Size = New System.Drawing.Size(180, 17)
        Me._Option1_58.TabIndex = 53
        Me._Option1_58.TabStop = True
        Me._Option1_58.Tag = "28"
        Me._Option1_58.Text = "Guarnizioni"
        '
        '_Option1_56
        '
        Me._Option1_56.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_56.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(56, Me._Option1_56)
        Me._Option1_56.Location = New System.Drawing.Point(8, 368)
        Me._Option1_56.Name = "_Option1_56"
        Me._Option1_56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_56.Size = New System.Drawing.Size(180, 17)
        Me._Option1_56.TabIndex = 52
        Me._Option1_56.TabStop = True
        Me._Option1_56.Tag = "46"
        Me._Option1_56.Text = "Riduzioni"
        '
        '_frmLato_1
        '
        Me._frmLato_1.BackColor = System.Drawing.SystemColors.Control
        Me._frmLato_1.Controls.Add(Me._Option1_55)
        Me._frmLato_1.Controls.Add(Me._Option1_54)
        Me._frmLato_1.Controls.Add(Me._Option1_53)
        Me._frmLato_1.Controls.Add(Me._Option1_52)
        Me._frmLato_1.Controls.Add(Me._Option1_51)
        Me._frmLato_1.Controls.Add(Me._Option1_48)
        Me._frmLato_1.Controls.Add(Me._Option1_47)
        Me._frmLato_1.Controls.Add(Me._Option1_46)
        Me._frmLato_1.Controls.Add(Me._Option1_45)
        Me._frmLato_1.Controls.Add(Me._Option1_44)
        Me._frmLato_1.Controls.Add(Me._Option1_43)
        Me._frmLato_1.Controls.Add(Me._Option1_42)
        Me._frmLato_1.Controls.Add(Me._Option1_41)
        Me._frmLato_1.Controls.Add(Me._Option1_40)
        Me._frmLato_1.Controls.Add(Me._Option1_39)
        Me._frmLato_1.Controls.Add(Me._Option1_38)
        Me._frmLato_1.Controls.Add(Me._Option1_37)
        Me._frmLato_1.Controls.Add(Me._Option1_36)
        Me._frmLato_1.Controls.Add(Me._Option1_35)
        Me._frmLato_1.Controls.Add(Me._Option1_32)
        Me._frmLato_1.Controls.Add(Me._Option1_31)
        Me._frmLato_1.Controls.Add(Me._Option1_30)
        Me._frmLato_1.Controls.Add(Me._Option1_29)
        Me._frmLato_1.Controls.Add(Me._Option1_28)
        Me._frmLato_1.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.frmLato.Add(1, Me._frmLato_1)
        Me._frmLato_1.Location = New System.Drawing.Point(208, 0)
        Me._frmLato_1.Name = "_frmLato_1"
        Me._frmLato_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmLato_1.Size = New System.Drawing.Size(201, 473)
        Me._frmLato_1.TabIndex = 26
        Me._frmLato_1.TabStop = False
        Me._frmLato_1.Tag = "2"
        Me._frmLato_1.Text = "Lato tubi"
        '
        '_Option1_55
        '
        Me._Option1_55.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_55.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(55, Me._Option1_55)
        Me._Option1_55.Location = New System.Drawing.Point(8, 368)
        Me._Option1_55.Name = "_Option1_55"
        Me._Option1_55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_55.Size = New System.Drawing.Size(180, 17)
        Me._Option1_55.TabIndex = 50
        Me._Option1_55.TabStop = True
        Me._Option1_55.Tag = "46"
        Me._Option1_55.Text = "Riduzioni"
        '
        '_Option1_54
        '
        Me._Option1_54.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_54.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(54, Me._Option1_54)
        Me._Option1_54.Location = New System.Drawing.Point(8, 416)
        Me._Option1_54.Name = "_Option1_54"
        Me._Option1_54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_54.Size = New System.Drawing.Size(180, 17)
        Me._Option1_54.TabIndex = 49
        Me._Option1_54.TabStop = True
        Me._Option1_54.Tag = "37"
        Me._Option1_54.Text = "Setti partitori"
        '
        '_Option1_53
        '
        Me._Option1_53.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_53.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(53, Me._Option1_53)
        Me._Option1_53.Location = New System.Drawing.Point(8, 144)
        Me._Option1_53.Name = "_Option1_53"
        Me._Option1_53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_53.Size = New System.Drawing.Size(180, 17)
        Me._Option1_53.TabIndex = 48
        Me._Option1_53.TabStop = True
        Me._Option1_53.Tag = "28"
        Me._Option1_53.Text = "Guarnizioni"
        '
        '_Option1_52
        '
        Me._Option1_52.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_52.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(52, Me._Option1_52)
        Me._Option1_52.Location = New System.Drawing.Point(8, 400)
        Me._Option1_52.Name = "_Option1_52"
        Me._Option1_52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_52.Size = New System.Drawing.Size(180, 17)
        Me._Option1_52.TabIndex = 47
        Me._Option1_52.TabStop = True
        Me._Option1_52.Tag = "29"
        Me._Option1_52.Text = "Tappi forgiati"
        '
        '_Option1_51
        '
        Me._Option1_51.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_51.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(51, Me._Option1_51)
        Me._Option1_51.Location = New System.Drawing.Point(8, 384)
        Me._Option1_51.Name = "_Option1_51"
        Me._Option1_51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_51.Size = New System.Drawing.Size(180, 17)
        Me._Option1_51.TabIndex = 46
        Me._Option1_51.TabStop = True
        Me._Option1_51.Tag = "27"
        Me._Option1_51.Text = "Manicotti forgiati"
        '
        '_Option1_48
        '
        Me._Option1_48.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_48.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(48, Me._Option1_48)
        Me._Option1_48.Location = New System.Drawing.Point(8, 432)
        Me._Option1_48.Name = "_Option1_48"
        Me._Option1_48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_48.Size = New System.Drawing.Size(180, 17)
        Me._Option1_48.TabIndex = 45
        Me._Option1_48.TabStop = True
        Me._Option1_48.Tag = "24"
        Me._Option1_48.Text = "Varie"
        '
        '_Option1_47
        '
        Me._Option1_47.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_47.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(47, Me._Option1_47)
        Me._Option1_47.Location = New System.Drawing.Point(8, 240)
        Me._Option1_47.Name = "_Option1_47"
        Me._Option1_47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_47.Size = New System.Drawing.Size(180, 17)
        Me._Option1_47.TabIndex = 44
        Me._Option1_47.TabStop = True
        Me._Option1_47.Tag = "23"
        Me._Option1_47.Text = "Tondi"
        '
        '_Option1_46
        '
        Me._Option1_46.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_46.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(46, Me._Option1_46)
        Me._Option1_46.Location = New System.Drawing.Point(8, 352)
        Me._Option1_46.Name = "_Option1_46"
        Me._Option1_46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_46.Size = New System.Drawing.Size(180, 17)
        Me._Option1_46.TabIndex = 43
        Me._Option1_46.TabStop = True
        Me._Option1_46.Tag = "21"
        Me._Option1_46.Text = "Curve"
        '
        '_Option1_45
        '
        Me._Option1_45.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_45.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(45, Me._Option1_45)
        Me._Option1_45.Location = New System.Drawing.Point(8, 320)
        Me._Option1_45.Name = "_Option1_45"
        Me._Option1_45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_45.Size = New System.Drawing.Size(180, 17)
        Me._Option1_45.TabIndex = 42
        Me._Option1_45.TabStop = True
        Me._Option1_45.Tag = "20"
        Me._Option1_45.Text = "Casse a bicchiere"
        '
        '_Option1_44
        '
        Me._Option1_44.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_44.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(44, Me._Option1_44)
        Me._Option1_44.Location = New System.Drawing.Point(8, 256)
        Me._Option1_44.Name = "_Option1_44"
        Me._Option1_44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_44.Size = New System.Drawing.Size(180, 17)
        Me._Option1_44.TabIndex = 41
        Me._Option1_44.TabStop = True
        Me._Option1_44.Tag = "19"
        Me._Option1_44.Text = "Diaframmi e piatti forati"
        '
        '_Option1_43
        '
        Me._Option1_43.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_43.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(43, Me._Option1_43)
        Me._Option1_43.Location = New System.Drawing.Point(8, 304)
        Me._Option1_43.Name = "_Option1_43"
        Me._Option1_43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_43.Size = New System.Drawing.Size(180, 17)
        Me._Option1_43.TabIndex = 40
        Me._Option1_43.TabStop = True
        Me._Option1_43.Tag = "18"
        Me._Option1_43.Text = "Dilatatori"
        '
        '_Option1_42
        '
        Me._Option1_42.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_42.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(42, Me._Option1_42)
        Me._Option1_42.Location = New System.Drawing.Point(8, 288)
        Me._Option1_42.Name = "_Option1_42"
        Me._Option1_42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_42.Size = New System.Drawing.Size(180, 17)
        Me._Option1_42.TabIndex = 39
        Me._Option1_42.TabStop = True
        Me._Option1_42.Tag = "17"
        Me._Option1_42.Text = "Anelli da lamiera"
        '
        '_Option1_41
        '
        Me._Option1_41.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_41.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(41, Me._Option1_41)
        Me._Option1_41.Location = New System.Drawing.Point(8, 80)
        Me._Option1_41.Name = "_Option1_41"
        Me._Option1_41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_41.Size = New System.Drawing.Size(180, 17)
        Me._Option1_41.TabIndex = 38
        Me._Option1_41.TabStop = True
        Me._Option1_41.Tag = "16"
        Me._Option1_41.Text = "Dischi / calotte / fondi piani"
        '
        '_Option1_40
        '
        Me._Option1_40.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_40.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(40, Me._Option1_40)
        Me._Option1_40.Location = New System.Drawing.Point(8, 272)
        Me._Option1_40.Name = "_Option1_40"
        Me._Option1_40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_40.Size = New System.Drawing.Size(180, 17)
        Me._Option1_40.TabIndex = 37
        Me._Option1_40.TabStop = True
        Me._Option1_40.Tag = "15"
        Me._Option1_40.Text = "Lamiere piane"
        '
        '_Option1_39
        '
        Me._Option1_39.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_39.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(39, Me._Option1_39)
        Me._Option1_39.Location = New System.Drawing.Point(8, 176)
        Me._Option1_39.Name = "_Option1_39"
        Me._Option1_39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_39.Size = New System.Drawing.Size(180, 17)
        Me._Option1_39.TabIndex = 36
        Me._Option1_39.TabStop = True
        Me._Option1_39.Tag = "14"
        Me._Option1_39.Text = "Bocchelli integrali da forgiato"
        '
        '_Option1_38
        '
        Me._Option1_38.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(38, Me._Option1_38)
        Me._Option1_38.Location = New System.Drawing.Point(8, 128)
        Me._Option1_38.Name = "_Option1_38"
        Me._Option1_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_38.Size = New System.Drawing.Size(180, 17)
        Me._Option1_38.TabIndex = 35
        Me._Option1_38.TabStop = True
        Me._Option1_38.Tag = "13"
        Me._Option1_38.Text = "Tiranteria metrica / ANSI"
        '
        '_Option1_37
        '
        Me._Option1_37.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_37.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(37, Me._Option1_37)
        Me._Option1_37.Location = New System.Drawing.Point(8, 112)
        Me._Option1_37.Name = "_Option1_37"
        Me._Option1_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_37.Size = New System.Drawing.Size(180, 17)
        Me._Option1_37.TabIndex = 34
        Me._Option1_37.TabStop = True
        Me._Option1_37.Tag = "12"
        Me._Option1_37.Text = "Coperchi piani"
        '
        '_Option1_36
        '
        Me._Option1_36.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_36.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(36, Me._Option1_36)
        Me._Option1_36.Location = New System.Drawing.Point(8, 96)
        Me._Option1_36.Name = "_Option1_36"
        Me._Option1_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_36.Size = New System.Drawing.Size(180, 17)
        Me._Option1_36.TabIndex = 33
        Me._Option1_36.TabStop = True
        Me._Option1_36.Tag = "11"
        Me._Option1_36.Text = "Flangioni / anelli fucinati"
        '
        '_Option1_35
        '
        Me._Option1_35.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(35, Me._Option1_35)
        Me._Option1_35.Location = New System.Drawing.Point(8, 160)
        Me._Option1_35.Name = "_Option1_35"
        Me._Option1_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_35.Size = New System.Drawing.Size(180, 17)
        Me._Option1_35.TabIndex = 32
        Me._Option1_35.TabStop = True
        Me._Option1_35.Tag = "10"
        Me._Option1_35.Text = "Bocchelli con flangia standard"
        '
        '_Option1_32
        '
        Me._Option1_32.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(32, Me._Option1_32)
        Me._Option1_32.Location = New System.Drawing.Point(8, 32)
        Me._Option1_32.Name = "_Option1_32"
        Me._Option1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_32.Size = New System.Drawing.Size(180, 17)
        Me._Option1_32.TabIndex = 31
        Me._Option1_32.TabStop = True
        Me._Option1_32.Tag = "7"
        Me._Option1_32.Text = "Coni"
        '
        '_Option1_31
        '
        Me._Option1_31.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(31, Me._Option1_31)
        Me._Option1_31.Location = New System.Drawing.Point(8, 48)
        Me._Option1_31.Name = "_Option1_31"
        Me._Option1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_31.Size = New System.Drawing.Size(180, 17)
        Me._Option1_31.TabIndex = 30
        Me._Option1_31.TabStop = True
        Me._Option1_31.Tag = "6"
        Me._Option1_31.Text = "Conoidi"
        '
        '_Option1_30
        '
        Me._Option1_30.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(30, Me._Option1_30)
        Me._Option1_30.Location = New System.Drawing.Point(8, 64)
        Me._Option1_30.Name = "_Option1_30"
        Me._Option1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_30.Size = New System.Drawing.Size(180, 17)
        Me._Option1_30.TabIndex = 29
        Me._Option1_30.TabStop = True
        Me._Option1_30.Tag = "3"
        Me._Option1_30.Text = "Fondi"
        '
        '_Option1_29
        '
        Me._Option1_29.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(29, Me._Option1_29)
        Me._Option1_29.Location = New System.Drawing.Point(8, 336)
        Me._Option1_29.Name = "_Option1_29"
        Me._Option1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_29.Size = New System.Drawing.Size(180, 17)
        Me._Option1_29.TabIndex = 28
        Me._Option1_29.TabStop = True
        Me._Option1_29.Tag = "2"
        Me._Option1_29.Text = "Tubi (tronchetti)"
        '
        '_Option1_28
        '
        Me._Option1_28.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(28, Me._Option1_28)
        Me._Option1_28.Location = New System.Drawing.Point(8, 16)
        Me._Option1_28.Name = "_Option1_28"
        Me._Option1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_28.Size = New System.Drawing.Size(180, 17)
        Me._Option1_28.TabIndex = 27
        Me._Option1_28.TabStop = True
        Me._Option1_28.Tag = "1"
        Me._Option1_28.Text = "Cilindri/Virole fucinate"
        '
        '_frmLato_0
        '
        Me._frmLato_0.BackColor = System.Drawing.SystemColors.Control
        Me._frmLato_0.Controls.Add(Me._Option1_0)
        Me._frmLato_0.Controls.Add(Me._Option1_1)
        Me._frmLato_0.Controls.Add(Me._Option1_2)
        Me._frmLato_0.Controls.Add(Me._Option1_3)
        Me._frmLato_0.Controls.Add(Me._Option1_4)
        Me._frmLato_0.Controls.Add(Me._Option1_7)
        Me._frmLato_0.Controls.Add(Me._Option1_8)
        Me._frmLato_0.Controls.Add(Me._Option1_9)
        Me._frmLato_0.Controls.Add(Me._Option1_10)
        Me._frmLato_0.Controls.Add(Me._Option1_11)
        Me._frmLato_0.Controls.Add(Me._Option1_12)
        Me._frmLato_0.Controls.Add(Me._Option1_13)
        Me._frmLato_0.Controls.Add(Me._Option1_14)
        Me._frmLato_0.Controls.Add(Me._Option1_15)
        Me._frmLato_0.Controls.Add(Me._Option1_16)
        Me._frmLato_0.Controls.Add(Me._Option1_18)
        Me._frmLato_0.Controls.Add(Me._Option1_20)
        Me._frmLato_0.Controls.Add(Me._Option1_21)
        Me._frmLato_0.Controls.Add(Me._Option1_24)
        Me._frmLato_0.Controls.Add(Me._Option1_25)
        Me._frmLato_0.Controls.Add(Me._Option1_26)
        Me._frmLato_0.Controls.Add(Me._Option1_19)
        Me._frmLato_0.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.frmLato.Add(0, Me._frmLato_0)
        Me._frmLato_0.Location = New System.Drawing.Point(8, 0)
        Me._frmLato_0.Name = "_frmLato_0"
        Me._frmLato_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmLato_0.Size = New System.Drawing.Size(201, 473)
        Me._frmLato_0.TabIndex = 3
        Me._frmLato_0.TabStop = False
        Me._frmLato_0.Tag = "1"
        Me._frmLato_0.Text = "Lato mantello"
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(0, Me._Option1_0)
        Me._Option1_0.Location = New System.Drawing.Point(8, 16)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(180, 17)
        Me._Option1_0.TabIndex = 25
        Me._Option1_0.TabStop = True
        Me._Option1_0.Tag = "1"
        Me._Option1_0.Text = "Cilindri/Virole fucinate"
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(1, Me._Option1_1)
        Me._Option1_1.Location = New System.Drawing.Point(8, 336)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(180, 17)
        Me._Option1_1.TabIndex = 24
        Me._Option1_1.TabStop = True
        Me._Option1_1.Tag = "2"
        Me._Option1_1.Text = "Tubi (tronchetti)"
        '
        '_Option1_2
        '
        Me._Option1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(2, Me._Option1_2)
        Me._Option1_2.Location = New System.Drawing.Point(8, 64)
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Size = New System.Drawing.Size(180, 17)
        Me._Option1_2.TabIndex = 23
        Me._Option1_2.TabStop = True
        Me._Option1_2.Tag = "3"
        Me._Option1_2.Text = "Fondi"
        '
        '_Option1_3
        '
        Me._Option1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(3, Me._Option1_3)
        Me._Option1_3.Location = New System.Drawing.Point(8, 48)
        Me._Option1_3.Name = "_Option1_3"
        Me._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_3.Size = New System.Drawing.Size(180, 17)
        Me._Option1_3.TabIndex = 22
        Me._Option1_3.TabStop = True
        Me._Option1_3.Tag = "6"
        Me._Option1_3.Text = "Conoidi"
        '
        '_Option1_4
        '
        Me._Option1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(4, Me._Option1_4)
        Me._Option1_4.Location = New System.Drawing.Point(8, 32)
        Me._Option1_4.Name = "_Option1_4"
        Me._Option1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_4.Size = New System.Drawing.Size(180, 17)
        Me._Option1_4.TabIndex = 21
        Me._Option1_4.TabStop = True
        Me._Option1_4.Tag = "7"
        Me._Option1_4.Text = "Coni"
        '
        '_Option1_7
        '
        Me._Option1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(7, Me._Option1_7)
        Me._Option1_7.Location = New System.Drawing.Point(8, 160)
        Me._Option1_7.Name = "_Option1_7"
        Me._Option1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_7.Size = New System.Drawing.Size(180, 17)
        Me._Option1_7.TabIndex = 20
        Me._Option1_7.TabStop = True
        Me._Option1_7.Tag = "10"
        Me._Option1_7.Text = "Bocchelli con flangia standard"
        '
        '_Option1_8
        '
        Me._Option1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(8, Me._Option1_8)
        Me._Option1_8.Location = New System.Drawing.Point(8, 96)
        Me._Option1_8.Name = "_Option1_8"
        Me._Option1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_8.Size = New System.Drawing.Size(180, 17)
        Me._Option1_8.TabIndex = 19
        Me._Option1_8.TabStop = True
        Me._Option1_8.Tag = "11"
        Me._Option1_8.Text = "Flangioni / anelli fucinati"
        '
        '_Option1_9
        '
        Me._Option1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(9, Me._Option1_9)
        Me._Option1_9.Location = New System.Drawing.Point(8, 112)
        Me._Option1_9.Name = "_Option1_9"
        Me._Option1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_9.Size = New System.Drawing.Size(180, 17)
        Me._Option1_9.TabIndex = 18
        Me._Option1_9.TabStop = True
        Me._Option1_9.Tag = "12"
        Me._Option1_9.Text = "Coperchi piani"
        '
        '_Option1_10
        '
        Me._Option1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(10, Me._Option1_10)
        Me._Option1_10.Location = New System.Drawing.Point(8, 128)
        Me._Option1_10.Name = "_Option1_10"
        Me._Option1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_10.Size = New System.Drawing.Size(180, 17)
        Me._Option1_10.TabIndex = 17
        Me._Option1_10.TabStop = True
        Me._Option1_10.Tag = "13"
        Me._Option1_10.Text = "Tiranteria metrica / ANSI"
        '
        '_Option1_11
        '
        Me._Option1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(11, Me._Option1_11)
        Me._Option1_11.Location = New System.Drawing.Point(8, 176)
        Me._Option1_11.Name = "_Option1_11"
        Me._Option1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_11.Size = New System.Drawing.Size(180, 17)
        Me._Option1_11.TabIndex = 16
        Me._Option1_11.TabStop = True
        Me._Option1_11.Tag = "14"
        Me._Option1_11.Text = "Bocchelli integrali da forgiato"
        '
        '_Option1_12
        '
        Me._Option1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(12, Me._Option1_12)
        Me._Option1_12.Location = New System.Drawing.Point(8, 272)
        Me._Option1_12.Name = "_Option1_12"
        Me._Option1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_12.Size = New System.Drawing.Size(180, 17)
        Me._Option1_12.TabIndex = 15
        Me._Option1_12.TabStop = True
        Me._Option1_12.Tag = "15"
        Me._Option1_12.Text = "Lamiere piane"
        '
        '_Option1_13
        '
        Me._Option1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(13, Me._Option1_13)
        Me._Option1_13.Location = New System.Drawing.Point(8, 80)
        Me._Option1_13.Name = "_Option1_13"
        Me._Option1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_13.Size = New System.Drawing.Size(180, 17)
        Me._Option1_13.TabIndex = 14
        Me._Option1_13.TabStop = True
        Me._Option1_13.Tag = "16"
        Me._Option1_13.Text = "Dischi / calotte / fondi piani"
        '
        '_Option1_14
        '
        Me._Option1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(14, Me._Option1_14)
        Me._Option1_14.Location = New System.Drawing.Point(8, 288)
        Me._Option1_14.Name = "_Option1_14"
        Me._Option1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_14.Size = New System.Drawing.Size(180, 17)
        Me._Option1_14.TabIndex = 13
        Me._Option1_14.TabStop = True
        Me._Option1_14.Tag = "17"
        Me._Option1_14.Text = "Anelli da lamiera"
        '
        '_Option1_15
        '
        Me._Option1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(15, Me._Option1_15)
        Me._Option1_15.Location = New System.Drawing.Point(8, 304)
        Me._Option1_15.Name = "_Option1_15"
        Me._Option1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_15.Size = New System.Drawing.Size(180, 17)
        Me._Option1_15.TabIndex = 12
        Me._Option1_15.TabStop = True
        Me._Option1_15.Tag = "18"
        Me._Option1_15.Text = "Dilatatori"
        '
        '_Option1_16
        '
        Me._Option1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(16, Me._Option1_16)
        Me._Option1_16.Location = New System.Drawing.Point(8, 256)
        Me._Option1_16.Name = "_Option1_16"
        Me._Option1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_16.Size = New System.Drawing.Size(180, 17)
        Me._Option1_16.TabIndex = 11
        Me._Option1_16.TabStop = True
        Me._Option1_16.Tag = "19"
        Me._Option1_16.Text = "Diaframmi e piatti forati"
        '
        '_Option1_18
        '
        Me._Option1_18.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(18, Me._Option1_18)
        Me._Option1_18.Location = New System.Drawing.Point(8, 352)
        Me._Option1_18.Name = "_Option1_18"
        Me._Option1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_18.Size = New System.Drawing.Size(180, 17)
        Me._Option1_18.TabIndex = 10
        Me._Option1_18.TabStop = True
        Me._Option1_18.Tag = "21"
        Me._Option1_18.Text = "Curve"
        '
        '_Option1_20
        '
        Me._Option1_20.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(20, Me._Option1_20)
        Me._Option1_20.Location = New System.Drawing.Point(8, 240)
        Me._Option1_20.Name = "_Option1_20"
        Me._Option1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_20.Size = New System.Drawing.Size(180, 17)
        Me._Option1_20.TabIndex = 9
        Me._Option1_20.TabStop = True
        Me._Option1_20.Tag = "23"
        Me._Option1_20.Text = "Tondi"
        '
        '_Option1_21
        '
        Me._Option1_21.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(21, Me._Option1_21)
        Me._Option1_21.Location = New System.Drawing.Point(8, 432)
        Me._Option1_21.Name = "_Option1_21"
        Me._Option1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_21.Size = New System.Drawing.Size(180, 17)
        Me._Option1_21.TabIndex = 8
        Me._Option1_21.TabStop = True
        Me._Option1_21.Tag = "24"
        Me._Option1_21.Text = "Varie"
        '
        '_Option1_24
        '
        Me._Option1_24.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(24, Me._Option1_24)
        Me._Option1_24.Location = New System.Drawing.Point(8, 384)
        Me._Option1_24.Name = "_Option1_24"
        Me._Option1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_24.Size = New System.Drawing.Size(180, 17)
        Me._Option1_24.TabIndex = 7
        Me._Option1_24.TabStop = True
        Me._Option1_24.Tag = "27"
        Me._Option1_24.Text = "Manicotti forgiati"
        '
        '_Option1_25
        '
        Me._Option1_25.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(25, Me._Option1_25)
        Me._Option1_25.Location = New System.Drawing.Point(8, 400)
        Me._Option1_25.Name = "_Option1_25"
        Me._Option1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_25.Size = New System.Drawing.Size(180, 17)
        Me._Option1_25.TabIndex = 6
        Me._Option1_25.TabStop = True
        Me._Option1_25.Tag = "29"
        Me._Option1_25.Text = "Tappi forgiati"
        '
        '_Option1_26
        '
        Me._Option1_26.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(26, Me._Option1_26)
        Me._Option1_26.Location = New System.Drawing.Point(8, 144)
        Me._Option1_26.Name = "_Option1_26"
        Me._Option1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_26.Size = New System.Drawing.Size(180, 17)
        Me._Option1_26.TabIndex = 5
        Me._Option1_26.TabStop = True
        Me._Option1_26.Tag = "28"
        Me._Option1_26.Text = "Guarnizioni"
        '
        '_Option1_19
        '
        Me._Option1_19.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(19, Me._Option1_19)
        Me._Option1_19.Location = New System.Drawing.Point(8, 368)
        Me._Option1_19.Name = "_Option1_19"
        Me._Option1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_19.Size = New System.Drawing.Size(180, 17)
        Me._Option1_19.TabIndex = 4
        Me._Option1_19.TabStop = True
        Me._Option1_19.Tag = "46"
        Me._Option1_19.Text = "Riduzioni"
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(2, Me._Command1_2)
        Me._Command1_2.Location = New System.Drawing.Point(720, 480)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(73, 25)
        Me._Command1_2.TabIndex = 2
        Me._Command1_2.Text = "Aiuto"
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(1, Me._Command1_1)
        Me._Command1_1.Location = New System.Drawing.Point(640, 480)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(73, 25)
        Me._Command1_1.TabIndex = 1
        Me._Command1_1.Text = "Annulla"
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(0, Me._Command1_0)
        Me._Command1_0.Location = New System.Drawing.Point(560, 480)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(73, 25)
        Me._Command1_0.TabIndex = 0
        Me._Command1_0.Text = "Accetta"
        '
        'Command1
        '
        '
        'Option1
        '
        '
        'frmMnuMemb3
        '
        Me.AcceptButton = Me._Command1_0
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(796, 508)
        Me.ControlBox = False
        Me.Controls.Add(Me._frmLato_3)
        Me.Controls.Add(Me._frmLato_2)
        Me.Controls.Add(Me._frmLato_1)
        Me.Controls.Add(Me._frmLato_0)
        Me.Controls.Add(Me._Command1_2)
        Me.Controls.Add(Me._Command1_1)
        Me.Controls.Add(Me._Command1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(65, 25)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMnuMemb3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Inserimento nuova membratura"
        Me._frmLato_3.ResumeLayout(False)
        Me._frmLato_2.ResumeLayout(False)
        Me._frmLato_1.ResumeLayout(False)
        Me._frmLato_0.ResumeLayout(False)
        For Each control In Command1.Values
            AddHandler control.Click, AddressOf Command1_Click
        Next
        For Each control In Option1.Values
            AddHandler control.CheckedChanged, AddressOf Option1_CheckedChanged
        Next

        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmMnuMemb3
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMnuMemb3
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMnuMemb3()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Dim Index As Short = IndexedControls.IndexOf(Command1, eventSender)
		Select Case Index
			Case 0 'OK
			Case 1 'Annulla
				Funzioni.membratura = 0
			Case 2 'Help
		End Select
        Hide()
	End Sub
	
	'UPGRADE_WARNING: Form evento frmMnuMemb3.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmMnuMemb3_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		option1(0).Checked = True
		Option1_CheckedChanged(Option1.Item(0), New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		If eventSender.Checked Then
			Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
			Dim f As System.Windows.Forms.GroupBox
			Dim opt As System.Windows.Forms.RadioButton
			Funzioni.membratura = Val(option1(Index).Tag)
			f = option1(Index).Parent
            Funzioni.Lato = f.Tag
			For Each opt In option1.Values
				If Not opt.Parent Is f Then
					opt.Checked = False
				End If
			Next opt
		End If
	End Sub
End Class