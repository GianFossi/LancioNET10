Option Strict Off
Option Explicit On 
Imports RoutBase1
Friend Class frmPT
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializza()
        Inizializzando = False
        AggCheck()
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
    Public WithEvents List1 As System.Windows.Forms.ListBox
    Public WithEvents _TextCil_32 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_33 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_34 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_35 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_36 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_37 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_38 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
    Public WithEvents _TextCil_39 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_40 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_41 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_42 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_43 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_44 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_45 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_50 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_52 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_39 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_40 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_41 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_42 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_43 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_44 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_45 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_46 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_47 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_48 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_49 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_51 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.Panel
    Public WithEvents _TextCil_108 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_92 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_151 As System.Windows.Forms.Button
    Public WithEvents _List2_51 As System.Windows.Forms.ListBox
    Public WithEvents _TextCil_51 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_51 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_50 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_49 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_48 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_47 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_46 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_144 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_143 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_151 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_83 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_57 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_56 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_55 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_54 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_53 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_38 As System.Windows.Forms.Label
    Public WithEvents _Frames_1 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_75 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_74 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_73 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_72 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_71 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_70 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_69 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
    Public WithEvents _TextCil_68 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_67 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_66 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_65 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_64 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_63 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_62 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_64 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_63 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_65 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_66 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_67 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_68 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_69 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_70 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_71 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_72 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_73 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_74 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_75 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_76 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.Panel
    Public WithEvents _TextCil_110 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_109 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_181 As System.Windows.Forms.Button
    Public WithEvents _List2_81 As System.Windows.Forms.ListBox
    Public WithEvents _TextCil_54 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_81 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_76 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_77 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_78 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_79 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_80 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_146 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_145 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_181 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_84 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_77 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_62 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_61 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_60 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_59 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_58 As System.Windows.Forms.Label
    Public WithEvents _Frames_2 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCil_201 As System.Windows.Forms.Button
    Public WithEvents _List2_101 As System.Windows.Forms.ListBox
    Public WithEvents _cmbCil_101 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_102 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_103 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_201 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_97 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_96 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_95 As System.Windows.Forms.Label
    Public WithEvents _Frames_3 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_91 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_108 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.Panel
    Public WithEvents _cmdCil_32 As System.Windows.Forms.Button
    Public WithEvents _TextCil_52 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_31 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_30 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_29 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_25 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_24 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_27 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_26 As System.Windows.Forms.Button
    Public WithEvents _Check1_7 As System.Windows.Forms.CheckBox
    Public WithEvents _Check1_6 As System.Windows.Forms.CheckBox
    Public WithEvents _Check1_5 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_31 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_30 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_29 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_28 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_25 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_24 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_27 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_26 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_141 As System.Windows.Forms.Label
    Public WithEvents _lblUni_91 As System.Windows.Forms.Label
    Public WithEvents _lblUni_52 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_81 As System.Windows.Forms.Label
    Public WithEvents _lblUni_31 As System.Windows.Forms.Label
    Public WithEvents _lblUni_30 As System.Windows.Forms.Label
    Public WithEvents _lblUni_29 As System.Windows.Forms.Label
    Public WithEvents _lblUni_25 As System.Windows.Forms.Label
    Public WithEvents _lblUni_24 As System.Windows.Forms.Label
    Public WithEvents _lblUni_28 As System.Windows.Forms.Label
    Public WithEvents _lblUni_10 As System.Windows.Forms.Label
    Public WithEvents _lblUni_27 As System.Windows.Forms.Label
    Public WithEvents _lblUni_26 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_37 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_36 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_35 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_34 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_31 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_30 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_33 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_32 As System.Windows.Forms.Label
    Public WithEvents _Frames_5 As System.Windows.Forms.GroupBox
    Public WithEvents _optColl_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optColl_0 As System.Windows.Forms.RadioButton
    Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_18 As System.Windows.Forms.Label
    Public WithEvents _frmCollars_0 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
    Public WithEvents _Check1_2 As System.Windows.Forms.CheckBox
    Public WithEvents _Check1_1 As System.Windows.Forms.CheckBox
    Public WithEvents _cmbCil_3 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_16 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_15 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _TextCil_12 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_11 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_9 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_21 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_20 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_17 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
    Public WithEvents _Frames_0 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_114 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_113 As System.Windows.Forms.TextBox
    Public WithEvents Check2 As System.Windows.Forms.CheckBox
    Public WithEvents _cmbCil_6 As System.Windows.Forms.ComboBox
    Public WithEvents _cmdCil_7 As System.Windows.Forms.Button
    Public WithEvents _TextCil_53 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_23 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_19 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_18 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_17 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_14 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_150 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_149 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_85 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_82 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_29 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_24 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_23 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_22 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_19 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
    Public WithEvents _Framesf_1 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCil_221 As System.Windows.Forms.Button
    Public WithEvents _List2_121 As System.Windows.Forms.ListBox
    Public WithEvents _cmbCil_121 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_123 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_122 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_221 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_80 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_79 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_78 As System.Windows.Forms.Label
    Public WithEvents _Frames_4 As System.Windows.Forms.GroupBox
    Public WithEvents List6 As System.Windows.Forms.ListBox
    Public WithEvents _cmbCil_15 As System.Windows.Forms.ComboBox
    Public WithEvents List5 As System.Windows.Forms.ListBox
    Public WithEvents List4 As System.Windows.Forms.ListBox
    Public WithEvents _cmbCil_14 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_13 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_106 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_107 As System.Windows.Forms.TextBox
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents _TextCil_93 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_11 As System.Windows.Forms.ComboBox
    Public WithEvents _LabelCil_142 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_127 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_126 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_114 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_113 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_112 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_111 As System.Windows.Forms.Label
    Public WithEvents _Frames_6 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_112 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_111 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_11 As System.Windows.Forms.Button
    Public WithEvents _TextCil_101 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_9 As System.Windows.Forms.Button
    Public WithEvents _TextCil_61 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_60 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_59 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_58 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_57 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_56 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_8 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_55 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_8 As System.Windows.Forms.Button
    Public WithEvents _cmbCil_7 As System.Windows.Forms.ComboBox
    Public WithEvents _LabelCil_148 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_147 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_123 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_98 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_94 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_93 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_92 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_91 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_90 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_89 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_88 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_87 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_86 As System.Windows.Forms.Label
    Public WithEvents _Framesf_2 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_405 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_406 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_407 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_409 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_411 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_412 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_402 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_401 As System.Windows.Forms.Button
    Public WithEvents _TextCil_415 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_416 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_403 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_402 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_403 As System.Windows.Forms.ComboBox
    Public WithEvents _Check1_401 As System.Windows.Forms.CheckBox
    Public WithEvents _Check1_402 As System.Windows.Forms.CheckBox
    Public WithEvents _cmdCil_406 As System.Windows.Forms.Button
    Public WithEvents _TextCil_413 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_128 As System.Windows.Forms.Label
    Public WithEvents _frmCollars_1 As System.Windows.Forms.GroupBox
    Public WithEvents _LabelCil_140 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_139 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_138 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_137 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_136 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_135 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_134 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_133 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_132 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_131 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_130 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_129 As System.Windows.Forms.Label
    Public WithEvents _Frames_8 As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_104 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_105 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_125 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_124 As System.Windows.Forms.Label
    Public WithEvents framCones As System.Windows.Forms.GroupBox
    Public WithEvents _TextCil_100 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_99 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_98 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_97 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_121 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_120 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_119 As System.Windows.Forms.Label
    Public WithEvents framPort As System.Windows.Forms.GroupBox
    Public WithEvents chkCalcFBM As System.Windows.Forms.CheckBox
    Public WithEvents List3 As System.Windows.Forms.ListBox
    Public WithEvents _cmbCil_10 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_87 As System.Windows.Forms.TextBox
    Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents _TextCil_86 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_13 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_122 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_109 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_106 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_105 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_104 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_103 As System.Windows.Forms.Label
    Public WithEvents _Frames_7 As System.Windows.Forms.GroupBox
    Public WithEvents _Check1_12 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_83 As System.Windows.Forms.TextBox
    Public WithEvents txtIBW As System.Windows.Forms.TextBox
    Public WithEvents _Check1_11 As System.Windows.Forms.CheckBox
    Public WithEvents chkltx As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_96 As System.Windows.Forms.TextBox
    Public WithEvents _LabelCil_118 As System.Windows.Forms.Label
    Public WithEvents framltx As System.Windows.Forms.GroupBox
    Public WithEvents _Check1_10 As System.Windows.Forms.CheckBox
    Public WithEvents _Check1_9 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_95 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_94 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_16 As System.Windows.Forms.Button
    Public WithEvents _cmbCil_12 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_90 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_88 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_12 As System.Windows.Forms.Button
    Public WithEvents _TextCil_84 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_82 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_9 As System.Windows.Forms.ComboBox
    Public WithEvents _Check1_8 As System.Windows.Forms.CheckBox
    Public WithEvents _TextCil_22 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_5 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_21 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_20 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
    Public WithEvents _Check1_3 As System.Windows.Forms.CheckBox
    Public WithEvents _cmbCil_4 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
    Public WithEvents _Check1_0 As System.Windows.Forms.CheckBox
    Public WithEvents _Check1_4 As System.Windows.Forms.CheckBox
    Public WithEvents LabIBWmm As System.Windows.Forms.Label
    Public WithEvents labIBW As System.Windows.Forms.Label
    Public WithEvents _LabelCil_117 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_116 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_115 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_110 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_107 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_102 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_101 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_100 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_99 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_28 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_27 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_26 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_25 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
    Public WithEvents _Framesf_0 As System.Windows.Forms.GroupBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents _TextCil_89 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabStrip1 As System.Windows.Forms.TabControl
    Friend WithEvents TabStrip2 As System.Windows.Forms.TabControl
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciato2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciato1 As System.Windows.Forms.CheckBox
    Private frmCollarsInitialHeigth As Integer
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMat2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatFlLM As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatFlLT As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatSlLT As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatSlLM As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatBoltLM As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatShell As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMatBoltLT As System.Windows.Forms.ComboBox
    Friend WithEvents chkAggancBoltLT As System.Windows.Forms.CheckBox
    Friend WithEvents chkAggancBoltLM As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPT))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_32 = New System.Windows.Forms.Button
        Me._cmdCil_31 = New System.Windows.Forms.Button
        Me._cmdCil_30 = New System.Windows.Forms.Button
        Me._cmdCil_29 = New System.Windows.Forms.Button
        Me._cmdCil_25 = New System.Windows.Forms.Button
        Me._cmdCil_24 = New System.Windows.Forms.Button
        Me._cmdCil_27 = New System.Windows.Forms.Button
        Me._cmdCil_26 = New System.Windows.Forms.Button
        Me._cmdCil_11 = New System.Windows.Forms.Button
        Me._cmdCil_16 = New System.Windows.Forms.Button
        Me._cmdCil_12 = New System.Windows.Forms.Button
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me.chkAgganciato2 = New System.Windows.Forms.CheckBox
        Me.chkAgganciato1 = New System.Windows.Forms.CheckBox
        Me._TextCil_101 = New System.Windows.Forms.TextBox
        Me._LabelCil_123 = New System.Windows.Forms.Label
        Me.chkAggancBoltLT = New System.Windows.Forms.CheckBox
        Me.chkAggancBoltLM = New System.Windows.Forms.CheckBox
        Me._Frames_1 = New System.Windows.Forms.GroupBox
        Me.cmbMatFlLT = New System.Windows.Forms.ComboBox
        Me.List1 = New System.Windows.Forms.ListBox
        Me.Frame2 = New System.Windows.Forms.Panel
        Me._TextCil_32 = New System.Windows.Forms.TextBox
        Me._TextCil_33 = New System.Windows.Forms.TextBox
        Me._TextCil_34 = New System.Windows.Forms.TextBox
        Me._TextCil_35 = New System.Windows.Forms.TextBox
        Me._TextCil_36 = New System.Windows.Forms.TextBox
        Me._TextCil_37 = New System.Windows.Forms.TextBox
        Me._TextCil_38 = New System.Windows.Forms.TextBox
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me._TextCil_39 = New System.Windows.Forms.TextBox
        Me._TextCil_40 = New System.Windows.Forms.TextBox
        Me._TextCil_41 = New System.Windows.Forms.TextBox
        Me._TextCil_42 = New System.Windows.Forms.TextBox
        Me._TextCil_43 = New System.Windows.Forms.TextBox
        Me._TextCil_44 = New System.Windows.Forms.TextBox
        Me._TextCil_45 = New System.Windows.Forms.TextBox
        Me._LabelCil_50 = New System.Windows.Forms.Label
        Me._LabelCil_52 = New System.Windows.Forms.Label
        Me._LabelCil_39 = New System.Windows.Forms.Label
        Me._LabelCil_40 = New System.Windows.Forms.Label
        Me._LabelCil_41 = New System.Windows.Forms.Label
        Me._LabelCil_42 = New System.Windows.Forms.Label
        Me._LabelCil_43 = New System.Windows.Forms.Label
        Me._LabelCil_44 = New System.Windows.Forms.Label
        Me._LabelCil_45 = New System.Windows.Forms.Label
        Me._LabelCil_46 = New System.Windows.Forms.Label
        Me._LabelCil_47 = New System.Windows.Forms.Label
        Me._LabelCil_48 = New System.Windows.Forms.Label
        Me._LabelCil_49 = New System.Windows.Forms.Label
        Me._LabelCil_51 = New System.Windows.Forms.Label
        Me._TextCil_108 = New System.Windows.Forms.TextBox
        Me._TextCil_92 = New System.Windows.Forms.TextBox
        Me._cmdCil_151 = New System.Windows.Forms.Button
        Me._List2_51 = New System.Windows.Forms.ListBox
        Me._TextCil_51 = New System.Windows.Forms.TextBox
        Me._cmbCil_51 = New System.Windows.Forms.ComboBox
        Me._TextCil_50 = New System.Windows.Forms.TextBox
        Me._TextCil_49 = New System.Windows.Forms.TextBox
        Me._TextCil_48 = New System.Windows.Forms.TextBox
        Me._TextCil_47 = New System.Windows.Forms.TextBox
        Me._TextCil_46 = New System.Windows.Forms.TextBox
        Me._LabelCil_144 = New System.Windows.Forms.Label
        Me._LabelCil_143 = New System.Windows.Forms.Label
        Me._LabelCil_151 = New System.Windows.Forms.Label
        Me._LabelCil_83 = New System.Windows.Forms.Label
        Me._LabelCil_57 = New System.Windows.Forms.Label
        Me._LabelCil_56 = New System.Windows.Forms.Label
        Me._LabelCil_55 = New System.Windows.Forms.Label
        Me._LabelCil_54 = New System.Windows.Forms.Label
        Me._LabelCil_53 = New System.Windows.Forms.Label
        Me._LabelCil_38 = New System.Windows.Forms.Label
        Me._Frames_2 = New System.Windows.Forms.GroupBox
        Me.cmbMatFlLM = New System.Windows.Forms.ComboBox
        Me.Frame3 = New System.Windows.Forms.Panel
        Me._TextCil_75 = New System.Windows.Forms.TextBox
        Me._TextCil_74 = New System.Windows.Forms.TextBox
        Me._TextCil_73 = New System.Windows.Forms.TextBox
        Me._TextCil_72 = New System.Windows.Forms.TextBox
        Me._TextCil_71 = New System.Windows.Forms.TextBox
        Me._TextCil_70 = New System.Windows.Forms.TextBox
        Me._TextCil_69 = New System.Windows.Forms.TextBox
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._TextCil_68 = New System.Windows.Forms.TextBox
        Me._TextCil_67 = New System.Windows.Forms.TextBox
        Me._TextCil_66 = New System.Windows.Forms.TextBox
        Me._TextCil_65 = New System.Windows.Forms.TextBox
        Me._TextCil_64 = New System.Windows.Forms.TextBox
        Me._TextCil_63 = New System.Windows.Forms.TextBox
        Me._TextCil_62 = New System.Windows.Forms.TextBox
        Me._LabelCil_64 = New System.Windows.Forms.Label
        Me._LabelCil_63 = New System.Windows.Forms.Label
        Me._LabelCil_65 = New System.Windows.Forms.Label
        Me._LabelCil_66 = New System.Windows.Forms.Label
        Me._LabelCil_67 = New System.Windows.Forms.Label
        Me._LabelCil_68 = New System.Windows.Forms.Label
        Me._LabelCil_69 = New System.Windows.Forms.Label
        Me._LabelCil_70 = New System.Windows.Forms.Label
        Me._LabelCil_71 = New System.Windows.Forms.Label
        Me._LabelCil_72 = New System.Windows.Forms.Label
        Me._LabelCil_73 = New System.Windows.Forms.Label
        Me._LabelCil_74 = New System.Windows.Forms.Label
        Me._LabelCil_75 = New System.Windows.Forms.Label
        Me._LabelCil_76 = New System.Windows.Forms.Label
        Me._TextCil_110 = New System.Windows.Forms.TextBox
        Me._TextCil_109 = New System.Windows.Forms.TextBox
        Me._cmdCil_181 = New System.Windows.Forms.Button
        Me._List2_81 = New System.Windows.Forms.ListBox
        Me._TextCil_54 = New System.Windows.Forms.TextBox
        Me._cmbCil_81 = New System.Windows.Forms.ComboBox
        Me._TextCil_76 = New System.Windows.Forms.TextBox
        Me._TextCil_77 = New System.Windows.Forms.TextBox
        Me._TextCil_78 = New System.Windows.Forms.TextBox
        Me._TextCil_79 = New System.Windows.Forms.TextBox
        Me._TextCil_80 = New System.Windows.Forms.TextBox
        Me._LabelCil_146 = New System.Windows.Forms.Label
        Me._LabelCil_145 = New System.Windows.Forms.Label
        Me._LabelCil_181 = New System.Windows.Forms.Label
        Me._LabelCil_84 = New System.Windows.Forms.Label
        Me._LabelCil_77 = New System.Windows.Forms.Label
        Me._LabelCil_62 = New System.Windows.Forms.Label
        Me._LabelCil_61 = New System.Windows.Forms.Label
        Me._LabelCil_60 = New System.Windows.Forms.Label
        Me._LabelCil_59 = New System.Windows.Forms.Label
        Me._LabelCil_58 = New System.Windows.Forms.Label
        Me._Frames_0 = New System.Windows.Forms.GroupBox
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._TextCil_15 = New System.Windows.Forms.TextBox
        Me.cmbMatBoltLT = New System.Windows.Forms.ComboBox
        Me._frmCollars_0 = New System.Windows.Forms.GroupBox
        Me._optColl_1 = New System.Windows.Forms.RadioButton
        Me._optColl_0 = New System.Windows.Forms.RadioButton
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._LabelCil_18 = New System.Windows.Forms.Label
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me._Check1_2 = New System.Windows.Forms.CheckBox
        Me._Check1_1 = New System.Windows.Forms.CheckBox
        Me._cmbCil_3 = New System.Windows.Forms.ComboBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._TextCil_16 = New System.Windows.Forms.TextBox
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._TextCil_12 = New System.Windows.Forms.TextBox
        Me._TextCil_11 = New System.Windows.Forms.TextBox
        Me._TextCil_9 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_21 = New System.Windows.Forms.Label
        Me._LabelCil_20 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_17 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._Frames_3 = New System.Windows.Forms.GroupBox
        Me.cmbMatSlLT = New System.Windows.Forms.ComboBox
        Me._cmdCil_201 = New System.Windows.Forms.Button
        Me._List2_101 = New System.Windows.Forms.ListBox
        Me._cmbCil_101 = New System.Windows.Forms.ComboBox
        Me._TextCil_102 = New System.Windows.Forms.TextBox
        Me._TextCil_103 = New System.Windows.Forms.TextBox
        Me._LabelCil_201 = New System.Windows.Forms.Label
        Me._LabelCil_97 = New System.Windows.Forms.Label
        Me._LabelCil_96 = New System.Windows.Forms.Label
        Me._LabelCil_95 = New System.Windows.Forms.Label
        Me._Frames_5 = New System.Windows.Forms.GroupBox
        Me._TextCil_91 = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.Panel
        Me._TextCil_89 = New System.Windows.Forms.NumericUpDown
        Me._LabelCil_108 = New System.Windows.Forms.Label
        Me._TextCil_52 = New System.Windows.Forms.TextBox
        Me._Check1_7 = New System.Windows.Forms.CheckBox
        Me._Check1_6 = New System.Windows.Forms.CheckBox
        Me._Check1_5 = New System.Windows.Forms.CheckBox
        Me._TextCil_31 = New System.Windows.Forms.TextBox
        Me._TextCil_30 = New System.Windows.Forms.TextBox
        Me._TextCil_29 = New System.Windows.Forms.TextBox
        Me._TextCil_28 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._TextCil_25 = New System.Windows.Forms.TextBox
        Me._TextCil_24 = New System.Windows.Forms.TextBox
        Me._TextCil_27 = New System.Windows.Forms.TextBox
        Me._TextCil_26 = New System.Windows.Forms.TextBox
        Me._LabelCil_141 = New System.Windows.Forms.Label
        Me._lblUni_91 = New System.Windows.Forms.Label
        Me._lblUni_52 = New System.Windows.Forms.Label
        Me._LabelCil_81 = New System.Windows.Forms.Label
        Me._lblUni_31 = New System.Windows.Forms.Label
        Me._lblUni_30 = New System.Windows.Forms.Label
        Me._lblUni_29 = New System.Windows.Forms.Label
        Me._lblUni_25 = New System.Windows.Forms.Label
        Me._lblUni_24 = New System.Windows.Forms.Label
        Me._lblUni_28 = New System.Windows.Forms.Label
        Me._lblUni_10 = New System.Windows.Forms.Label
        Me._lblUni_27 = New System.Windows.Forms.Label
        Me._lblUni_26 = New System.Windows.Forms.Label
        Me._LabelCil_37 = New System.Windows.Forms.Label
        Me._LabelCil_36 = New System.Windows.Forms.Label
        Me._LabelCil_35 = New System.Windows.Forms.Label
        Me._LabelCil_34 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me._LabelCil_31 = New System.Windows.Forms.Label
        Me._LabelCil_30 = New System.Windows.Forms.Label
        Me._LabelCil_33 = New System.Windows.Forms.Label
        Me._LabelCil_32 = New System.Windows.Forms.Label
        Me._Framesf_1 = New System.Windows.Forms.GroupBox
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me.Check2 = New System.Windows.Forms.CheckBox
        Me._TextCil_114 = New System.Windows.Forms.TextBox
        Me._TextCil_113 = New System.Windows.Forms.TextBox
        Me._cmbCil_6 = New System.Windows.Forms.ComboBox
        Me._cmdCil_7 = New System.Windows.Forms.Button
        Me._TextCil_53 = New System.Windows.Forms.TextBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._TextCil_23 = New System.Windows.Forms.TextBox
        Me._TextCil_19 = New System.Windows.Forms.TextBox
        Me._TextCil_18 = New System.Windows.Forms.TextBox
        Me._TextCil_17 = New System.Windows.Forms.TextBox
        Me._TextCil_14 = New System.Windows.Forms.TextBox
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._LabelCil_150 = New System.Windows.Forms.Label
        Me._LabelCil_149 = New System.Windows.Forms.Label
        Me._LabelCil_85 = New System.Windows.Forms.Label
        Me._LabelCil_82 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_29 = New System.Windows.Forms.Label
        Me._LabelCil_24 = New System.Windows.Forms.Label
        Me._LabelCil_23 = New System.Windows.Forms.Label
        Me._LabelCil_22 = New System.Windows.Forms.Label
        Me._LabelCil_19 = New System.Windows.Forms.Label
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._Frames_4 = New System.Windows.Forms.GroupBox
        Me.cmbMatSlLM = New System.Windows.Forms.ComboBox
        Me._cmdCil_221 = New System.Windows.Forms.Button
        Me._List2_121 = New System.Windows.Forms.ListBox
        Me._cmbCil_121 = New System.Windows.Forms.ComboBox
        Me._TextCil_123 = New System.Windows.Forms.TextBox
        Me._TextCil_122 = New System.Windows.Forms.TextBox
        Me._LabelCil_221 = New System.Windows.Forms.Label
        Me._LabelCil_80 = New System.Windows.Forms.Label
        Me._LabelCil_79 = New System.Windows.Forms.Label
        Me._LabelCil_78 = New System.Windows.Forms.Label
        Me._Frames_6 = New System.Windows.Forms.GroupBox
        Me.List6 = New System.Windows.Forms.ListBox
        Me._cmbCil_15 = New System.Windows.Forms.ComboBox
        Me.List5 = New System.Windows.Forms.ListBox
        Me.List4 = New System.Windows.Forms.ListBox
        Me._cmbCil_14 = New System.Windows.Forms.ComboBox
        Me._cmbCil_13 = New System.Windows.Forms.ComboBox
        Me._TextCil_106 = New System.Windows.Forms.TextBox
        Me._TextCil_107 = New System.Windows.Forms.TextBox
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me._TextCil_93 = New System.Windows.Forms.TextBox
        Me._cmbCil_11 = New System.Windows.Forms.ComboBox
        Me._LabelCil_142 = New System.Windows.Forms.Label
        Me._LabelCil_127 = New System.Windows.Forms.Label
        Me._LabelCil_126 = New System.Windows.Forms.Label
        Me._LabelCil_114 = New System.Windows.Forms.Label
        Me._LabelCil_113 = New System.Windows.Forms.Label
        Me._LabelCil_112 = New System.Windows.Forms.Label
        Me._LabelCil_111 = New System.Windows.Forms.Label
        Me._Framesf_2 = New System.Windows.Forms.GroupBox
        Me.cmbMat2 = New System.Windows.Forms.ComboBox
        Me._TextCil_112 = New System.Windows.Forms.TextBox
        Me._TextCil_111 = New System.Windows.Forms.TextBox
        Me._cmdCil_9 = New System.Windows.Forms.Button
        Me._TextCil_61 = New System.Windows.Forms.TextBox
        Me._TextCil_60 = New System.Windows.Forms.TextBox
        Me._TextCil_59 = New System.Windows.Forms.TextBox
        Me._TextCil_58 = New System.Windows.Forms.TextBox
        Me._TextCil_57 = New System.Windows.Forms.TextBox
        Me._TextCil_56 = New System.Windows.Forms.TextBox
        Me._cmbCil_8 = New System.Windows.Forms.ComboBox
        Me._TextCil_55 = New System.Windows.Forms.TextBox
        Me._cmdCil_8 = New System.Windows.Forms.Button
        Me._cmbCil_7 = New System.Windows.Forms.ComboBox
        Me._LabelCil_148 = New System.Windows.Forms.Label
        Me._LabelCil_147 = New System.Windows.Forms.Label
        Me._LabelCil_98 = New System.Windows.Forms.Label
        Me._LabelCil_94 = New System.Windows.Forms.Label
        Me._LabelCil_93 = New System.Windows.Forms.Label
        Me._LabelCil_92 = New System.Windows.Forms.Label
        Me._LabelCil_91 = New System.Windows.Forms.Label
        Me._LabelCil_90 = New System.Windows.Forms.Label
        Me._LabelCil_89 = New System.Windows.Forms.Label
        Me._LabelCil_88 = New System.Windows.Forms.Label
        Me._LabelCil_87 = New System.Windows.Forms.Label
        Me._LabelCil_86 = New System.Windows.Forms.Label
        Me._Frames_8 = New System.Windows.Forms.GroupBox
        Me._cmdCil_401 = New System.Windows.Forms.Button
        Me.cmbMatBoltLM = New System.Windows.Forms.ComboBox
        Me._TextCil_405 = New System.Windows.Forms.TextBox
        Me._TextCil_406 = New System.Windows.Forms.TextBox
        Me._TextCil_407 = New System.Windows.Forms.TextBox
        Me._TextCil_409 = New System.Windows.Forms.TextBox
        Me._TextCil_411 = New System.Windows.Forms.TextBox
        Me._TextCil_412 = New System.Windows.Forms.TextBox
        Me._cmdCil_402 = New System.Windows.Forms.Button
        Me._TextCil_415 = New System.Windows.Forms.TextBox
        Me._TextCil_416 = New System.Windows.Forms.TextBox
        Me._TextCil_403 = New System.Windows.Forms.TextBox
        Me._TextCil_402 = New System.Windows.Forms.TextBox
        Me._cmbCil_403 = New System.Windows.Forms.ComboBox
        Me._Check1_401 = New System.Windows.Forms.CheckBox
        Me._Check1_402 = New System.Windows.Forms.CheckBox
        Me._cmdCil_406 = New System.Windows.Forms.Button
        Me._frmCollars_1 = New System.Windows.Forms.GroupBox
        Me._TextCil_413 = New System.Windows.Forms.TextBox
        Me._LabelCil_128 = New System.Windows.Forms.Label
        Me._LabelCil_140 = New System.Windows.Forms.Label
        Me._LabelCil_139 = New System.Windows.Forms.Label
        Me._LabelCil_138 = New System.Windows.Forms.Label
        Me._LabelCil_137 = New System.Windows.Forms.Label
        Me._LabelCil_136 = New System.Windows.Forms.Label
        Me._LabelCil_135 = New System.Windows.Forms.Label
        Me._LabelCil_134 = New System.Windows.Forms.Label
        Me._LabelCil_133 = New System.Windows.Forms.Label
        Me._LabelCil_132 = New System.Windows.Forms.Label
        Me._LabelCil_131 = New System.Windows.Forms.Label
        Me._LabelCil_130 = New System.Windows.Forms.Label
        Me._LabelCil_129 = New System.Windows.Forms.Label
        Me._Frames_7 = New System.Windows.Forms.GroupBox
        Me.cmbMatShell = New System.Windows.Forms.ComboBox
        Me.framCones = New System.Windows.Forms.GroupBox
        Me._TextCil_104 = New System.Windows.Forms.TextBox
        Me._TextCil_105 = New System.Windows.Forms.TextBox
        Me._LabelCil_125 = New System.Windows.Forms.Label
        Me._LabelCil_124 = New System.Windows.Forms.Label
        Me._TextCil_100 = New System.Windows.Forms.TextBox
        Me.framPort = New System.Windows.Forms.GroupBox
        Me._TextCil_99 = New System.Windows.Forms.TextBox
        Me._TextCil_98 = New System.Windows.Forms.TextBox
        Me._TextCil_97 = New System.Windows.Forms.TextBox
        Me._LabelCil_121 = New System.Windows.Forms.Label
        Me._LabelCil_120 = New System.Windows.Forms.Label
        Me._LabelCil_119 = New System.Windows.Forms.Label
        Me.chkCalcFBM = New System.Windows.Forms.CheckBox
        Me.List3 = New System.Windows.Forms.ListBox
        Me._cmbCil_10 = New System.Windows.Forms.ComboBox
        Me._TextCil_87 = New System.Windows.Forms.TextBox
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me._TextCil_86 = New System.Windows.Forms.TextBox
        Me._cmdCil_13 = New System.Windows.Forms.Button
        Me._LabelCil_122 = New System.Windows.Forms.Label
        Me._LabelCil_109 = New System.Windows.Forms.Label
        Me._LabelCil_106 = New System.Windows.Forms.Label
        Me._LabelCil_105 = New System.Windows.Forms.Label
        Me._LabelCil_104 = New System.Windows.Forms.Label
        Me._LabelCil_103 = New System.Windows.Forms.Label
        Me._Framesf_0 = New System.Windows.Forms.GroupBox
        Me._Check1_12 = New System.Windows.Forms.CheckBox
        Me._TextCil_83 = New System.Windows.Forms.TextBox
        Me.txtIBW = New System.Windows.Forms.TextBox
        Me._Check1_11 = New System.Windows.Forms.CheckBox
        Me.framltx = New System.Windows.Forms.GroupBox
        Me.chkltx = New System.Windows.Forms.CheckBox
        Me._TextCil_96 = New System.Windows.Forms.TextBox
        Me._LabelCil_118 = New System.Windows.Forms.Label
        Me._Check1_10 = New System.Windows.Forms.CheckBox
        Me._Check1_9 = New System.Windows.Forms.CheckBox
        Me._TextCil_95 = New System.Windows.Forms.TextBox
        Me._TextCil_94 = New System.Windows.Forms.TextBox
        Me._cmbCil_12 = New System.Windows.Forms.ComboBox
        Me._TextCil_90 = New System.Windows.Forms.TextBox
        Me._TextCil_88 = New System.Windows.Forms.TextBox
        Me._TextCil_84 = New System.Windows.Forms.TextBox
        Me._TextCil_82 = New System.Windows.Forms.TextBox
        Me._cmbCil_9 = New System.Windows.Forms.ComboBox
        Me._Check1_8 = New System.Windows.Forms.CheckBox
        Me._TextCil_22 = New System.Windows.Forms.TextBox
        Me._cmbCil_5 = New System.Windows.Forms.ComboBox
        Me._TextCil_21 = New System.Windows.Forms.TextBox
        Me._TextCil_20 = New System.Windows.Forms.TextBox
        Me._Check1_3 = New System.Windows.Forms.CheckBox
        Me._cmbCil_4 = New System.Windows.Forms.ComboBox
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._Check1_0 = New System.Windows.Forms.CheckBox
        Me._Check1_4 = New System.Windows.Forms.CheckBox
        Me.LabIBWmm = New System.Windows.Forms.Label
        Me.labIBW = New System.Windows.Forms.Label
        Me._LabelCil_117 = New System.Windows.Forms.Label
        Me._LabelCil_116 = New System.Windows.Forms.Label
        Me._LabelCil_115 = New System.Windows.Forms.Label
        Me._LabelCil_110 = New System.Windows.Forms.Label
        Me._LabelCil_107 = New System.Windows.Forms.Label
        Me._LabelCil_102 = New System.Windows.Forms.Label
        Me._LabelCil_101 = New System.Windows.Forms.Label
        Me._LabelCil_100 = New System.Windows.Forms.Label
        Me._LabelCil_99 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_28 = New System.Windows.Forms.Label
        Me._LabelCil_27 = New System.Windows.Forms.Label
        Me._LabelCil_26 = New System.Windows.Forms.Label
        Me._LabelCil_25 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me.Command1 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabStrip1 = New System.Windows.Forms.TabControl
        Me.TabStrip2 = New System.Windows.Forms.TabControl
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me._Frames_1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me._Frames_2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me._Frames_0.SuspendLayout()
        Me._frmCollars_0.SuspendLayout()
        Me._Frames_3.SuspendLayout()
        Me._Frames_5.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me._TextCil_89, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._Framesf_1.SuspendLayout()
        Me._Frames_4.SuspendLayout()
        Me._Frames_6.SuspendLayout()
        Me._Framesf_2.SuspendLayout()
        Me._Frames_8.SuspendLayout()
        Me._frmCollars_1.SuspendLayout()
        Me._Frames_7.SuspendLayout()
        Me.framCones.SuspendLayout()
        Me.framPort.SuspendLayout()
        Me._Framesf_0.SuspendLayout()
        Me.framltx.SuspendLayout()
        Me.SuspendLayout()
        '
        '_cmdCil_32
        '
        Me._cmdCil_32.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_32.Image = CType(resources.GetObject("_cmdCil_32.Image"), System.Drawing.Image)
        Me._cmdCil_32.Location = New System.Drawing.Point(261, 180)
        Me._cmdCil_32.Name = "_cmdCil_32"
        Me._cmdCil_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_32.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_32.TabIndex = 149
        Me._cmdCil_32.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_32, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_31
        '
        Me._cmdCil_31.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_31.Image = CType(resources.GetObject("_cmdCil_31.Image"), System.Drawing.Image)
        Me._cmdCil_31.Location = New System.Drawing.Point(261, 162)
        Me._cmdCil_31.Name = "_cmdCil_31"
        Me._cmdCil_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_31.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_31.TabIndex = 143
        Me._cmdCil_31.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_31, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_30
        '
        Me._cmdCil_30.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_30.Image = CType(resources.GetObject("_cmdCil_30.Image"), System.Drawing.Image)
        Me._cmdCil_30.Location = New System.Drawing.Point(261, 144)
        Me._cmdCil_30.Name = "_cmdCil_30"
        Me._cmdCil_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_30.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_30.TabIndex = 142
        Me._cmdCil_30.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_30, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_29
        '
        Me._cmdCil_29.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_29.Image = CType(resources.GetObject("_cmdCil_29.Image"), System.Drawing.Image)
        Me._cmdCil_29.Location = New System.Drawing.Point(261, 126)
        Me._cmdCil_29.Name = "_cmdCil_29"
        Me._cmdCil_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_29.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_29.TabIndex = 141
        Me._cmdCil_29.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_29, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_25
        '
        Me._cmdCil_25.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_25.Image = CType(resources.GetObject("_cmdCil_25.Image"), System.Drawing.Image)
        Me._cmdCil_25.Location = New System.Drawing.Point(261, 108)
        Me._cmdCil_25.Name = "_cmdCil_25"
        Me._cmdCil_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_25.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_25.TabIndex = 140
        Me._cmdCil_25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_25, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_24
        '
        Me._cmdCil_24.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_24.Image = CType(resources.GetObject("_cmdCil_24.Image"), System.Drawing.Image)
        Me._cmdCil_24.Location = New System.Drawing.Point(261, 90)
        Me._cmdCil_24.Name = "_cmdCil_24"
        Me._cmdCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_24.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_24.TabIndex = 139
        Me._cmdCil_24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_24, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_27
        '
        Me._cmdCil_27.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_27.Image = CType(resources.GetObject("_cmdCil_27.Image"), System.Drawing.Image)
        Me._cmdCil_27.Location = New System.Drawing.Point(261, 36)
        Me._cmdCil_27.Name = "_cmdCil_27"
        Me._cmdCil_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_27.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_27.TabIndex = 138
        Me._cmdCil_27.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_27, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_26
        '
        Me._cmdCil_26.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_26.Image = CType(resources.GetObject("_cmdCil_26.Image"), System.Drawing.Image)
        Me._cmdCil_26.Location = New System.Drawing.Point(261, 18)
        Me._cmdCil_26.Name = "_cmdCil_26"
        Me._cmdCil_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_26.Size = New System.Drawing.Size(19, 19)
        Me._cmdCil_26.TabIndex = 137
        Me._cmdCil_26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_26, "Richiama i valori generali dell'apparecchio")
        '
        '_cmdCil_11
        '
        Me._cmdCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_11.Image = CType(resources.GetObject("_cmdCil_11.Image"), System.Drawing.Image)
        Me._cmdCil_11.Location = New System.Drawing.Point(155, 126)
        Me._cmdCil_11.Name = "_cmdCil_11"
        Me._cmdCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_11.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_11.TabIndex = 283
        Me._cmdCil_11.TabStop = False
        Me._cmdCil_11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_11, "Calcola i valori dalla tracciatura, se esistente")
        '
        '_cmdCil_16
        '
        Me._cmdCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_16, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_16, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_16.Image = CType(resources.GetObject("_cmdCil_16.Image"), System.Drawing.Image)
        Me._cmdCil_16.Location = New System.Drawing.Point(328, 106)
        Me._cmdCil_16.Name = "_cmdCil_16"
        Me._cmdCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_16, True)
        Me._cmdCil_16.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_16.TabIndex = 235
        Me._cmdCil_16.TabStop = False
        Me._cmdCil_16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_16, "Calcola i valori dalla tracciatura, se esistente")
        '
        '_cmdCil_12
        '
        Me._cmdCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_12, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_12, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_12.Image = CType(resources.GetObject("_cmdCil_12.Image"), System.Drawing.Image)
        Me._cmdCil_12.Location = New System.Drawing.Point(328, 88)
        Me._cmdCil_12.Name = "_cmdCil_12"
        Me._cmdCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_12, True)
        Me._cmdCil_12.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_12.TabIndex = 202
        Me._cmdCil_12.TabStop = False
        Me._cmdCil_12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_12, "Calcola i valori dalla tracciatura, se esistente")
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_4, "DatiGenPT.htm#RappEst")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_4, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_4.Location = New System.Drawing.Point(256, 144)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_4, True)
        Me._TextCil_4.Size = New System.Drawing.Size(49, 20)
        Me._TextCil_4.TabIndex = 9
        Me._TextCil_4.Text = ""
        Me.ToolTip1.SetToolTip(Me._TextCil_4, "2290")
        '
        'chkAgganciato2
        '
        Me.chkAgganciato2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato2, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato2.Location = New System.Drawing.Point(272, 48)
        Me.chkAgganciato2.Name = "chkAgganciato2"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato2, True)
        Me.chkAgganciato2.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciato2.TabIndex = 341
        Me.chkAgganciato2.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato2, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciato1
        '
        Me.chkAgganciato1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato1, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato1, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato1.Location = New System.Drawing.Point(272, 48)
        Me.chkAgganciato1.Name = "chkAgganciato1"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato1, True)
        Me.chkAgganciato1.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciato1.TabIndex = 345
        Me.chkAgganciato1.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato1, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        '_TextCil_101
        '
        Me._TextCil_101.AcceptsReturn = True
        Me._TextCil_101.AutoSize = False
        Me._TextCil_101.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_101.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_101.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_101.Location = New System.Drawing.Point(108, 124)
        Me._TextCil_101.MaxLength = 0
        Me._TextCil_101.Name = "_TextCil_101"
        Me._TextCil_101.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_101.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_101.TabIndex = 277
        Me._TextCil_101.Text = ""
        Me.ToolTip1.SetToolTip(Me._TextCil_101, "Diametro del cerchio equivalente all'area della porzione forata")
        '
        '_LabelCil_123
        '
        Me._LabelCil_123.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_123.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_123.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_123.Location = New System.Drawing.Point(9, 124)
        Me._LabelCil_123.Name = "_LabelCil_123"
        Me._LabelCil_123.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_123.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_123.TabIndex = 278
        Me._LabelCil_123.Text = "Dc (RCB-7.1411)"
        Me.ToolTip1.SetToolTip(Me._LabelCil_123, "Diametro del cerchio equivalente all'area della porzione forata")
        '
        'chkAggancBoltLT
        '
        Me.chkAggancBoltLT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAggancBoltLT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAggancBoltLT, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAggancBoltLT, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAggancBoltLT.Location = New System.Drawing.Point(288, 136)
        Me.chkAggancBoltLT.Name = "chkAggancBoltLT"
        Me.HelpProvider1.SetShowHelp(Me.chkAggancBoltLT, True)
        Me.chkAggancBoltLT.Size = New System.Drawing.Size(56, 24)
        Me.chkAggancBoltLT.TabIndex = 346
        Me.chkAggancBoltLT.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAggancBoltLT, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAggancBoltLM
        '
        Me.chkAggancBoltLM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAggancBoltLM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAggancBoltLM, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAggancBoltLM, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAggancBoltLM.Location = New System.Drawing.Point(288, 144)
        Me.chkAggancBoltLM.Name = "chkAggancBoltLM"
        Me.HelpProvider1.SetShowHelp(Me.chkAggancBoltLM, True)
        Me.chkAggancBoltLM.Size = New System.Drawing.Size(56, 24)
        Me.chkAggancBoltLM.TabIndex = 346
        Me.chkAggancBoltLM.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAggancBoltLM, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        '_Frames_1
        '
        Me._Frames_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_1.Controls.Add(Me.cmbMatFlLT)
        Me._Frames_1.Controls.Add(Me.List1)
        Me._Frames_1.Controls.Add(Me.Frame2)
        Me._Frames_1.Controls.Add(Me._TextCil_108)
        Me._Frames_1.Controls.Add(Me._TextCil_92)
        Me._Frames_1.Controls.Add(Me._cmdCil_151)
        Me._Frames_1.Controls.Add(Me._List2_51)
        Me._Frames_1.Controls.Add(Me._TextCil_51)
        Me._Frames_1.Controls.Add(Me._cmbCil_51)
        Me._Frames_1.Controls.Add(Me._TextCil_50)
        Me._Frames_1.Controls.Add(Me._TextCil_49)
        Me._Frames_1.Controls.Add(Me._TextCil_48)
        Me._Frames_1.Controls.Add(Me._TextCil_47)
        Me._Frames_1.Controls.Add(Me._TextCil_46)
        Me._Frames_1.Controls.Add(Me._LabelCil_144)
        Me._Frames_1.Controls.Add(Me._LabelCil_143)
        Me._Frames_1.Controls.Add(Me._LabelCil_151)
        Me._Frames_1.Controls.Add(Me._LabelCil_57)
        Me._Frames_1.Controls.Add(Me._LabelCil_56)
        Me._Frames_1.Controls.Add(Me._LabelCil_55)
        Me._Frames_1.Controls.Add(Me._LabelCil_54)
        Me._Frames_1.Controls.Add(Me._LabelCil_53)
        Me._Frames_1.Controls.Add(Me._LabelCil_38)
        Me._Frames_1.Controls.Add(Me._LabelCil_83)
        Me._Frames_1.ForeColor = System.Drawing.Color.Blue
        Me._Frames_1.Location = New System.Drawing.Point(360, 144)
        Me._Frames_1.Name = "_Frames_1"
        Me._Frames_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_1.Size = New System.Drawing.Size(352, 324)
        Me._Frames_1.TabIndex = 73
        Me._Frames_1.TabStop = False
        Me._Frames_1.Text = "Dati flangiatura L.T."
        '
        'cmbMatFlLT
        '
        Me.cmbMatFlLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatFlLT.Location = New System.Drawing.Point(128, 40)
        Me.cmbMatFlLT.Name = "cmbMatFlLT"
        Me.cmbMatFlLT.Size = New System.Drawing.Size(192, 21)
        Me.cmbMatFlLT.TabIndex = 381
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.Location = New System.Drawing.Point(296, 256)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(46, 30)
        Me.List1.TabIndex = 380
        Me.List1.Visible = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._TextCil_32)
        Me.Frame2.Controls.Add(Me._TextCil_33)
        Me.Frame2.Controls.Add(Me._TextCil_34)
        Me.Frame2.Controls.Add(Me._TextCil_35)
        Me.Frame2.Controls.Add(Me._TextCil_36)
        Me.Frame2.Controls.Add(Me._TextCil_37)
        Me.Frame2.Controls.Add(Me._TextCil_38)
        Me.Frame2.Controls.Add(Me._cmdCil_4)
        Me.Frame2.Controls.Add(Me._TextCil_39)
        Me.Frame2.Controls.Add(Me._TextCil_40)
        Me.Frame2.Controls.Add(Me._TextCil_41)
        Me.Frame2.Controls.Add(Me._TextCil_42)
        Me.Frame2.Controls.Add(Me._TextCil_43)
        Me.Frame2.Controls.Add(Me._TextCil_44)
        Me.Frame2.Controls.Add(Me._TextCil_45)
        Me.Frame2.Controls.Add(Me._LabelCil_50)
        Me.Frame2.Controls.Add(Me._LabelCil_52)
        Me.Frame2.Controls.Add(Me._LabelCil_39)
        Me.Frame2.Controls.Add(Me._LabelCil_40)
        Me.Frame2.Controls.Add(Me._LabelCil_41)
        Me.Frame2.Controls.Add(Me._LabelCil_42)
        Me.Frame2.Controls.Add(Me._LabelCil_43)
        Me.Frame2.Controls.Add(Me._LabelCil_44)
        Me.Frame2.Controls.Add(Me._LabelCil_45)
        Me.Frame2.Controls.Add(Me._LabelCil_46)
        Me.Frame2.Controls.Add(Me._LabelCil_47)
        Me.Frame2.Controls.Add(Me._LabelCil_48)
        Me.Frame2.Controls.Add(Me._LabelCil_49)
        Me.Frame2.Controls.Add(Me._LabelCil_51)
        Me.Frame2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(3, 64)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(346, 153)
        Me.Frame2.TabIndex = 350
        '
        '_TextCil_32
        '
        Me._TextCil_32.AcceptsReturn = True
        Me._TextCil_32.AutoSize = False
        Me._TextCil_32.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_32.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_32.Location = New System.Drawing.Point(125, 0)
        Me._TextCil_32.MaxLength = 0
        Me._TextCil_32.Name = "_TextCil_32"
        Me._TextCil_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_32.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_32.TabIndex = 365
        Me._TextCil_32.Text = ""
        '
        '_TextCil_33
        '
        Me._TextCil_33.AcceptsReturn = True
        Me._TextCil_33.AutoSize = False
        Me._TextCil_33.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_33.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_33.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_33.Location = New System.Drawing.Point(296, 0)
        Me._TextCil_33.MaxLength = 0
        Me._TextCil_33.Name = "_TextCil_33"
        Me._TextCil_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_33.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_33.TabIndex = 364
        Me._TextCil_33.Text = ""
        '
        '_TextCil_34
        '
        Me._TextCil_34.AcceptsReturn = True
        Me._TextCil_34.AutoSize = False
        Me._TextCil_34.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_34.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_34.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_34.Location = New System.Drawing.Point(125, 18)
        Me._TextCil_34.MaxLength = 0
        Me._TextCil_34.Name = "_TextCil_34"
        Me._TextCil_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_34.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_34.TabIndex = 363
        Me._TextCil_34.Text = ""
        '
        '_TextCil_35
        '
        Me._TextCil_35.AcceptsReturn = True
        Me._TextCil_35.AutoSize = False
        Me._TextCil_35.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_35.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_35.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_35.Location = New System.Drawing.Point(296, 18)
        Me._TextCil_35.MaxLength = 0
        Me._TextCil_35.Name = "_TextCil_35"
        Me._TextCil_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_35.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_35.TabIndex = 362
        Me._TextCil_35.Text = ""
        '
        '_TextCil_36
        '
        Me._TextCil_36.AcceptsReturn = True
        Me._TextCil_36.AutoSize = False
        Me._TextCil_36.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_36.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_36.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_36.Location = New System.Drawing.Point(125, 36)
        Me._TextCil_36.MaxLength = 0
        Me._TextCil_36.Name = "_TextCil_36"
        Me._TextCil_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_36.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_36.TabIndex = 361
        Me._TextCil_36.Text = ""
        '
        '_TextCil_37
        '
        Me._TextCil_37.AcceptsReturn = True
        Me._TextCil_37.AutoSize = False
        Me._TextCil_37.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_37.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_37.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_37.Location = New System.Drawing.Point(296, 36)
        Me._TextCil_37.MaxLength = 0
        Me._TextCil_37.Name = "_TextCil_37"
        Me._TextCil_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_37.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_37.TabIndex = 360
        Me._TextCil_37.Text = ""
        '
        '_TextCil_38
        '
        Me._TextCil_38.AcceptsReturn = True
        Me._TextCil_38.AutoSize = False
        Me._TextCil_38.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_38.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_38.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_38.Location = New System.Drawing.Point(125, 54)
        Me._TextCil_38.MaxLength = 0
        Me._TextCil_38.Name = "_TextCil_38"
        Me._TextCil_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_38.Size = New System.Drawing.Size(199, 20)
        Me._TextCil_38.TabIndex = 359
        Me._TextCil_38.Text = ""
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(323, 54)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 358
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_39
        '
        Me._TextCil_39.AcceptsReturn = True
        Me._TextCil_39.AutoSize = False
        Me._TextCil_39.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_39.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_39.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_39.Location = New System.Drawing.Point(125, 72)
        Me._TextCil_39.MaxLength = 0
        Me._TextCil_39.Name = "_TextCil_39"
        Me._TextCil_39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_39.Size = New System.Drawing.Size(199, 20)
        Me._TextCil_39.TabIndex = 357
        Me._TextCil_39.Text = ""
        '
        '_TextCil_40
        '
        Me._TextCil_40.AcceptsReturn = True
        Me._TextCil_40.AutoSize = False
        Me._TextCil_40.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_40.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_40.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_40.Location = New System.Drawing.Point(125, 90)
        Me._TextCil_40.MaxLength = 0
        Me._TextCil_40.Name = "_TextCil_40"
        Me._TextCil_40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_40.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_40.TabIndex = 356
        Me._TextCil_40.Text = ""
        '
        '_TextCil_41
        '
        Me._TextCil_41.AcceptsReturn = True
        Me._TextCil_41.AutoSize = False
        Me._TextCil_41.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_41.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_41.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_41.Location = New System.Drawing.Point(296, 90)
        Me._TextCil_41.MaxLength = 0
        Me._TextCil_41.Name = "_TextCil_41"
        Me._TextCil_41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_41.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_41.TabIndex = 355
        Me._TextCil_41.Text = ""
        '
        '_TextCil_42
        '
        Me._TextCil_42.AcceptsReturn = True
        Me._TextCil_42.AutoSize = False
        Me._TextCil_42.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_42.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_42.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_42.Location = New System.Drawing.Point(125, 108)
        Me._TextCil_42.MaxLength = 0
        Me._TextCil_42.Name = "_TextCil_42"
        Me._TextCil_42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_42.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_42.TabIndex = 354
        Me._TextCil_42.Text = ""
        '
        '_TextCil_43
        '
        Me._TextCil_43.AcceptsReturn = True
        Me._TextCil_43.AutoSize = False
        Me._TextCil_43.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_43.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_43.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_43.Location = New System.Drawing.Point(296, 108)
        Me._TextCil_43.MaxLength = 0
        Me._TextCil_43.Name = "_TextCil_43"
        Me._TextCil_43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_43.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_43.TabIndex = 353
        Me._TextCil_43.Text = ""
        '
        '_TextCil_44
        '
        Me._TextCil_44.AcceptsReturn = True
        Me._TextCil_44.AutoSize = False
        Me._TextCil_44.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_44.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_44.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_44.Location = New System.Drawing.Point(125, 126)
        Me._TextCil_44.MaxLength = 0
        Me._TextCil_44.Name = "_TextCil_44"
        Me._TextCil_44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_44.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_44.TabIndex = 352
        Me._TextCil_44.Text = ""
        '
        '_TextCil_45
        '
        Me._TextCil_45.AcceptsReturn = True
        Me._TextCil_45.AutoSize = False
        Me._TextCil_45.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_45.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_45.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_45.Location = New System.Drawing.Point(296, 126)
        Me._TextCil_45.MaxLength = 0
        Me._TextCil_45.Name = "_TextCil_45"
        Me._TextCil_45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_45.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_45.TabIndex = 351
        Me._TextCil_45.Text = ""
        '
        '_LabelCil_50
        '
        Me._LabelCil_50.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_50.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_50.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_50.Location = New System.Drawing.Point(176, 112)
        Me._LabelCil_50.Name = "_LabelCil_50"
        Me._LabelCil_50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_50.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_50.TabIndex = 379
        Me._LabelCil_50.Text = "Y traversini [psi]"
        '
        '_LabelCil_52
        '
        Me._LabelCil_52.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_52.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_52.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_52.Location = New System.Drawing.Point(176, 130)
        Me._LabelCil_52.Name = "_LabelCil_52"
        Me._LabelCil_52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_52.Size = New System.Drawing.Size(128, 17)
        Me._LabelCil_52.TabIndex = 378
        Me._LabelCil_52.Text = "Largh.efficace traversini"
        '
        '_LabelCil_39
        '
        Me._LabelCil_39.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_39.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_39.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_39.Location = New System.Drawing.Point(8, 0)
        Me._LabelCil_39.Name = "_LabelCil_39"
        Me._LabelCil_39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_39.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_39.TabIndex = 377
        Me._LabelCil_39.Tag = "kLength"
        Me._LabelCil_39.Text = "Diametro esterno"
        '
        '_LabelCil_40
        '
        Me._LabelCil_40.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_40.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_40.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_40.Location = New System.Drawing.Point(179, 0)
        Me._LabelCil_40.Name = "_LabelCil_40"
        Me._LabelCil_40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_40.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_40.TabIndex = 376
        Me._LabelCil_40.Tag = "kLength"
        Me._LabelCil_40.Text = "Diametro interno"
        '
        '_LabelCil_41
        '
        Me._LabelCil_41.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_41.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_41.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_41.Location = New System.Drawing.Point(8, 18)
        Me._LabelCil_41.Name = "_LabelCil_41"
        Me._LabelCil_41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_41.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_41.TabIndex = 375
        Me._LabelCil_41.Tag = "kLength"
        Me._LabelCil_41.Text = "Sp. max codolo"
        '
        '_LabelCil_42
        '
        Me._LabelCil_42.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_42.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_42.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_42.Location = New System.Drawing.Point(179, 18)
        Me._LabelCil_42.Name = "_LabelCil_42"
        Me._LabelCil_42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_42.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_42.TabIndex = 374
        Me._LabelCil_42.Tag = "kLength"
        Me._LabelCil_42.Text = "Sp. min codolo"
        '
        '_LabelCil_43
        '
        Me._LabelCil_43.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_43.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_43.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_43.Location = New System.Drawing.Point(8, 36)
        Me._LabelCil_43.Name = "_LabelCil_43"
        Me._LabelCil_43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_43.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_43.TabIndex = 373
        Me._LabelCil_43.Tag = "kLength"
        Me._LabelCil_43.Text = "Diam. medio g."
        '
        '_LabelCil_44
        '
        Me._LabelCil_44.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_44.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_44.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_44.Location = New System.Drawing.Point(179, 36)
        Me._LabelCil_44.Name = "_LabelCil_44"
        Me._LabelCil_44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_44.Size = New System.Drawing.Size(125, 17)
        Me._LabelCil_44.TabIndex = 372
        Me._LabelCil_44.Tag = "kLength"
        Me._LabelCil_44.Text = "Largh. guarn."
        '
        '_LabelCil_45
        '
        Me._LabelCil_45.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_45.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_45.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_45.Location = New System.Drawing.Point(8, 54)
        Me._LabelCil_45.Name = "_LabelCil_45"
        Me._LabelCil_45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_45.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_45.TabIndex = 371
        Me._LabelCil_45.Text = "Tipo guarnizione"
        '
        '_LabelCil_46
        '
        Me._LabelCil_46.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_46.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_46.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_46.Location = New System.Drawing.Point(8, 72)
        Me._LabelCil_46.Name = "_LabelCil_46"
        Me._LabelCil_46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_46.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_46.TabIndex = 370
        Me._LabelCil_46.Text = "Materiale guarnizione"
        '
        '_LabelCil_47
        '
        Me._LabelCil_47.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_47.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_47.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_47.Location = New System.Drawing.Point(8, 90)
        Me._LabelCil_47.Name = "_LabelCil_47"
        Me._LabelCil_47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_47.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_47.TabIndex = 369
        Me._LabelCil_47.Text = "m di guarnizione"
        '
        '_LabelCil_48
        '
        Me._LabelCil_48.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_48.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_48.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_48.Location = New System.Drawing.Point(179, 90)
        Me._LabelCil_48.Name = "_LabelCil_48"
        Me._LabelCil_48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_48.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_48.TabIndex = 368
        Me._LabelCil_48.Text = "Y di guarnizione [psi]"
        '
        '_LabelCil_49
        '
        Me._LabelCil_49.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_49.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_49.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_49.Location = New System.Drawing.Point(8, 108)
        Me._LabelCil_49.Name = "_LabelCil_49"
        Me._LabelCil_49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_49.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_49.TabIndex = 367
        Me._LabelCil_49.Text = "m traversini"
        '
        '_LabelCil_51
        '
        Me._LabelCil_51.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_51.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_51.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_51.Location = New System.Drawing.Point(8, 126)
        Me._LabelCil_51.Name = "_LabelCil_51"
        Me._LabelCil_51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_51.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_51.TabIndex = 366
        Me._LabelCil_51.Text = "Sviluppo traversini"
        '
        '_TextCil_108
        '
        Me._TextCil_108.AcceptsReturn = True
        Me._TextCil_108.AutoSize = False
        Me._TextCil_108.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_108.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_108.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_108.Location = New System.Drawing.Point(93, 256)
        Me._TextCil_108.MaxLength = 0
        Me._TextCil_108.Name = "_TextCil_108"
        Me._TextCil_108.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_108.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_108.TabIndex = 330
        Me._TextCil_108.Text = ""
        '
        '_TextCil_92
        '
        Me._TextCil_92.AcceptsReturn = True
        Me._TextCil_92.AutoSize = False
        Me._TextCil_92.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_92.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_92.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_92.Location = New System.Drawing.Point(93, 274)
        Me._TextCil_92.MaxLength = 0
        Me._TextCil_92.Name = "_TextCil_92"
        Me._TextCil_92.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_92.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_92.TabIndex = 329
        Me._TextCil_92.Text = ""
        Me._TextCil_92.Visible = False
        '
        '_cmdCil_151
        '
        Me._cmdCil_151.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_151.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_151.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_151.Image = CType(resources.GetObject("_cmdCil_151.Image"), System.Drawing.Image)
        Me._cmdCil_151.Location = New System.Drawing.Point(323, 40)
        Me._cmdCil_151.Name = "_cmdCil_151"
        Me._cmdCil_151.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_151.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_151.TabIndex = 247
        Me._cmdCil_151.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_List2_51
        '
        Me._List2_51.BackColor = System.Drawing.SystemColors.Window
        Me._List2_51.Cursor = System.Windows.Forms.Cursors.Default
        Me._List2_51.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List2_51.Location = New System.Drawing.Point(200, 280)
        Me._List2_51.Name = "_List2_51"
        Me._List2_51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List2_51.Size = New System.Drawing.Size(55, 17)
        Me._List2_51.TabIndex = 160
        Me._List2_51.Visible = False
        '
        '_TextCil_51
        '
        Me._TextCil_51.AcceptsReturn = True
        Me._TextCil_51.AutoSize = False
        Me._TextCil_51.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_51.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_51.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_51.Location = New System.Drawing.Point(126, 220)
        Me._TextCil_51.MaxLength = 0
        Me._TextCil_51.Name = "_TextCil_51"
        Me._TextCil_51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_51.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_51.TabIndex = 155
        Me._TextCil_51.Text = ""
        '
        '_cmbCil_51
        '
        Me._cmbCil_51.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_51.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_51.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_51.Location = New System.Drawing.Point(128, 16)
        Me._cmbCil_51.Name = "_cmbCil_51"
        Me._cmbCil_51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_51.Size = New System.Drawing.Size(216, 21)
        Me._cmbCil_51.TabIndex = 153
        Me._cmbCil_51.Text = "cmbCil"
        '
        '_TextCil_50
        '
        Me._TextCil_50.AcceptsReturn = True
        Me._TextCil_50.AutoSize = False
        Me._TextCil_50.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_50.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_50.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_50.Location = New System.Drawing.Point(297, 296)
        Me._TextCil_50.MaxLength = 0
        Me._TextCil_50.Name = "_TextCil_50"
        Me._TextCil_50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_50.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_50.TabIndex = 84
        Me._TextCil_50.Text = ""
        '
        '_TextCil_49
        '
        Me._TextCil_49.AcceptsReturn = True
        Me._TextCil_49.AutoSize = False
        Me._TextCil_49.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_49.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_49.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_49.Location = New System.Drawing.Point(265, 238)
        Me._TextCil_49.MaxLength = 0
        Me._TextCil_49.Name = "_TextCil_49"
        Me._TextCil_49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_49.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_49.TabIndex = 82
        Me._TextCil_49.Text = ""
        '
        '_TextCil_48
        '
        Me._TextCil_48.AcceptsReturn = True
        Me._TextCil_48.AutoSize = False
        Me._TextCil_48.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_48.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_48.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_48.Location = New System.Drawing.Point(94, 238)
        Me._TextCil_48.MaxLength = 0
        Me._TextCil_48.Name = "_TextCil_48"
        Me._TextCil_48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_48.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_48.TabIndex = 80
        Me._TextCil_48.Text = ""
        '
        '_TextCil_47
        '
        Me._TextCil_47.AcceptsReturn = True
        Me._TextCil_47.AutoSize = False
        Me._TextCil_47.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_47.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_47.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_47.Location = New System.Drawing.Point(265, 220)
        Me._TextCil_47.MaxLength = 0
        Me._TextCil_47.Name = "_TextCil_47"
        Me._TextCil_47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_47.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_47.TabIndex = 78
        Me._TextCil_47.Text = ""
        '
        '_TextCil_46
        '
        Me._TextCil_46.AcceptsReturn = True
        Me._TextCil_46.AutoSize = False
        Me._TextCil_46.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_46.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_46.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_46.Location = New System.Drawing.Point(94, 220)
        Me._TextCil_46.MaxLength = 0
        Me._TextCil_46.Name = "_TextCil_46"
        Me._TextCil_46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_46.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_46.TabIndex = 76
        Me._TextCil_46.Text = ""
        '
        '_LabelCil_144
        '
        Me._LabelCil_144.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_144.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_144.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_144.Location = New System.Drawing.Point(184, 220)
        Me._LabelCil_144.Name = "_LabelCil_144"
        Me._LabelCil_144.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_144.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_144.TabIndex = 332
        Me._LabelCil_144.Tag = "kForce"
        Me._LabelCil_144.Text = "Wm2         "
        '
        '_LabelCil_143
        '
        Me._LabelCil_143.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_143.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_143.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_143.Location = New System.Drawing.Point(184, 238)
        Me._LabelCil_143.Name = "_LabelCil_143"
        Me._LabelCil_143.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_143.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_143.TabIndex = 331
        Me._LabelCil_143.Tag = "kForce"
        Me._LabelCil_143.Text = "Wm2  H.T. "
        '
        '_LabelCil_151
        '
        Me._LabelCil_151.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_151.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_151.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_151.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_151.Name = "_LabelCil_151"
        Me._LabelCil_151.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_151.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_151.TabIndex = 249
        Me._LabelCil_151.Text = "Materiale flangia"
        '
        '_LabelCil_83
        '
        Me._LabelCil_83.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_83.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_83.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_83.Location = New System.Drawing.Point(8, 220)
        Me._LabelCil_83.Name = "_LabelCil_83"
        Me._LabelCil_83.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_83.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_83.TabIndex = 156
        Me._LabelCil_83.Text = "Larghezza nubbin"
        '
        '_LabelCil_57
        '
        Me._LabelCil_57.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_57.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_57.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_57.Location = New System.Drawing.Point(8, 296)
        Me._LabelCil_57.Name = "_LabelCil_57"
        Me._LabelCil_57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_57.Size = New System.Drawing.Size(258, 17)
        Me._LabelCil_57.TabIndex = 85
        Me._LabelCil_57.Tag = "kLength"
        Me._LabelCil_57.Text = "Diametro equivalente guarnizione"
        '
        '_LabelCil_56
        '
        Me._LabelCil_56.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_56.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_56.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_56.Location = New System.Drawing.Point(12, 276)
        Me._LabelCil_56.Name = "_LabelCil_56"
        Me._LabelCil_56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_56.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_56.TabIndex = 83
        Me._LabelCil_56.Tag = "kForce"
        Me._LabelCil_56.Text = "W      H.T. "
        '
        '_LabelCil_55
        '
        Me._LabelCil_55.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_55.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_55.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_55.Location = New System.Drawing.Point(9, 238)
        Me._LabelCil_55.Name = "_LabelCil_55"
        Me._LabelCil_55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_55.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_55.TabIndex = 81
        Me._LabelCil_55.Tag = "kForce"
        Me._LabelCil_55.Text = "Wm1 H.T. "
        '
        '_LabelCil_54
        '
        Me._LabelCil_54.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_54.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_54.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_54.Location = New System.Drawing.Point(12, 258)
        Me._LabelCil_54.Name = "_LabelCil_54"
        Me._LabelCil_54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_54.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_54.TabIndex = 79
        Me._LabelCil_54.Tag = "kForce"
        Me._LabelCil_54.Text = "W   design "
        '
        '_LabelCil_53
        '
        Me._LabelCil_53.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_53.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_53.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_53.Location = New System.Drawing.Point(8, 220)
        Me._LabelCil_53.Name = "_LabelCil_53"
        Me._LabelCil_53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_53.Size = New System.Drawing.Size(104, 17)
        Me._LabelCil_53.TabIndex = 77
        Me._LabelCil_53.Tag = "kForce"
        Me._LabelCil_53.Text = "Wm1 design "
        '
        '_LabelCil_38
        '
        Me._LabelCil_38.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_38.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_38.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_38.Name = "_LabelCil_38"
        Me._LabelCil_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_38.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_38.TabIndex = 75
        Me._LabelCil_38.Text = "Flange identification"
        '
        '_Frames_2
        '
        Me._Frames_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_2.Controls.Add(Me.cmbMatFlLM)
        Me._Frames_2.Controls.Add(Me.Frame3)
        Me._Frames_2.Controls.Add(Me._TextCil_110)
        Me._Frames_2.Controls.Add(Me._TextCil_109)
        Me._Frames_2.Controls.Add(Me._cmdCil_181)
        Me._Frames_2.Controls.Add(Me._List2_81)
        Me._Frames_2.Controls.Add(Me._TextCil_54)
        Me._Frames_2.Controls.Add(Me._cmbCil_81)
        Me._Frames_2.Controls.Add(Me._TextCil_76)
        Me._Frames_2.Controls.Add(Me._TextCil_77)
        Me._Frames_2.Controls.Add(Me._TextCil_78)
        Me._Frames_2.Controls.Add(Me._TextCil_79)
        Me._Frames_2.Controls.Add(Me._TextCil_80)
        Me._Frames_2.Controls.Add(Me._LabelCil_146)
        Me._Frames_2.Controls.Add(Me._LabelCil_145)
        Me._Frames_2.Controls.Add(Me._LabelCil_181)
        Me._Frames_2.Controls.Add(Me._LabelCil_77)
        Me._Frames_2.Controls.Add(Me._LabelCil_62)
        Me._Frames_2.Controls.Add(Me._LabelCil_61)
        Me._Frames_2.Controls.Add(Me._LabelCil_60)
        Me._Frames_2.Controls.Add(Me._LabelCil_59)
        Me._Frames_2.Controls.Add(Me._LabelCil_58)
        Me._Frames_2.Controls.Add(Me._LabelCil_84)
        Me._Frames_2.ForeColor = System.Drawing.Color.Blue
        Me._Frames_2.Location = New System.Drawing.Point(360, 132)
        Me._Frames_2.Name = "_Frames_2"
        Me._Frames_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_2.Size = New System.Drawing.Size(352, 324)
        Me._Frames_2.TabIndex = 86
        Me._Frames_2.TabStop = False
        Me._Frames_2.Text = "Dati flangiatura L.M."
        '
        'cmbMatFlLM
        '
        Me.cmbMatFlLM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatFlLM.Location = New System.Drawing.Point(120, 40)
        Me.cmbMatFlLM.Name = "cmbMatFlLM"
        Me.cmbMatFlLM.Size = New System.Drawing.Size(208, 21)
        Me.cmbMatFlLM.TabIndex = 382
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me._TextCil_75)
        Me.Frame3.Controls.Add(Me._TextCil_74)
        Me.Frame3.Controls.Add(Me._TextCil_73)
        Me.Frame3.Controls.Add(Me._TextCil_72)
        Me.Frame3.Controls.Add(Me._TextCil_71)
        Me.Frame3.Controls.Add(Me._TextCil_70)
        Me.Frame3.Controls.Add(Me._TextCil_69)
        Me.Frame3.Controls.Add(Me._cmdCil_5)
        Me.Frame3.Controls.Add(Me._TextCil_68)
        Me.Frame3.Controls.Add(Me._TextCil_67)
        Me.Frame3.Controls.Add(Me._TextCil_66)
        Me.Frame3.Controls.Add(Me._TextCil_65)
        Me.Frame3.Controls.Add(Me._TextCil_64)
        Me.Frame3.Controls.Add(Me._TextCil_63)
        Me.Frame3.Controls.Add(Me._TextCil_62)
        Me.Frame3.Controls.Add(Me._LabelCil_64)
        Me.Frame3.Controls.Add(Me._LabelCil_63)
        Me.Frame3.Controls.Add(Me._LabelCil_65)
        Me.Frame3.Controls.Add(Me._LabelCil_66)
        Me.Frame3.Controls.Add(Me._LabelCil_67)
        Me.Frame3.Controls.Add(Me._LabelCil_68)
        Me.Frame3.Controls.Add(Me._LabelCil_69)
        Me.Frame3.Controls.Add(Me._LabelCil_70)
        Me.Frame3.Controls.Add(Me._LabelCil_71)
        Me.Frame3.Controls.Add(Me._LabelCil_72)
        Me.Frame3.Controls.Add(Me._LabelCil_73)
        Me.Frame3.Controls.Add(Me._LabelCil_74)
        Me.Frame3.Controls.Add(Me._LabelCil_75)
        Me.Frame3.Controls.Add(Me._LabelCil_76)
        Me.Frame3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(8, 64)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(337, 153)
        Me.Frame3.TabIndex = 381
        Me.Frame3.Text = "Frame3"
        '
        '_TextCil_75
        '
        Me._TextCil_75.AcceptsReturn = True
        Me._TextCil_75.AutoSize = False
        Me._TextCil_75.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_75.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_75.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_75.Location = New System.Drawing.Point(288, 126)
        Me._TextCil_75.MaxLength = 0
        Me._TextCil_75.Name = "_TextCil_75"
        Me._TextCil_75.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_75.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_75.TabIndex = 396
        Me._TextCil_75.Text = ""
        '
        '_TextCil_74
        '
        Me._TextCil_74.AcceptsReturn = True
        Me._TextCil_74.AutoSize = False
        Me._TextCil_74.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_74.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_74.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_74.Location = New System.Drawing.Point(117, 124)
        Me._TextCil_74.MaxLength = 0
        Me._TextCil_74.Name = "_TextCil_74"
        Me._TextCil_74.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_74.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_74.TabIndex = 395
        Me._TextCil_74.Text = ""
        '
        '_TextCil_73
        '
        Me._TextCil_73.AcceptsReturn = True
        Me._TextCil_73.AutoSize = False
        Me._TextCil_73.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_73.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_73.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_73.Location = New System.Drawing.Point(288, 108)
        Me._TextCil_73.MaxLength = 0
        Me._TextCil_73.Name = "_TextCil_73"
        Me._TextCil_73.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_73.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_73.TabIndex = 394
        Me._TextCil_73.Text = ""
        '
        '_TextCil_72
        '
        Me._TextCil_72.AcceptsReturn = True
        Me._TextCil_72.AutoSize = False
        Me._TextCil_72.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_72.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_72.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_72.Location = New System.Drawing.Point(117, 108)
        Me._TextCil_72.MaxLength = 0
        Me._TextCil_72.Name = "_TextCil_72"
        Me._TextCil_72.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_72.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_72.TabIndex = 393
        Me._TextCil_72.Text = ""
        '
        '_TextCil_71
        '
        Me._TextCil_71.AcceptsReturn = True
        Me._TextCil_71.AutoSize = False
        Me._TextCil_71.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_71.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_71.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_71.Location = New System.Drawing.Point(288, 90)
        Me._TextCil_71.MaxLength = 0
        Me._TextCil_71.Name = "_TextCil_71"
        Me._TextCil_71.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_71.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_71.TabIndex = 392
        Me._TextCil_71.Text = ""
        '
        '_TextCil_70
        '
        Me._TextCil_70.AcceptsReturn = True
        Me._TextCil_70.AutoSize = False
        Me._TextCil_70.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_70.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_70.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_70.Location = New System.Drawing.Point(117, 90)
        Me._TextCil_70.MaxLength = 0
        Me._TextCil_70.Name = "_TextCil_70"
        Me._TextCil_70.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_70.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_70.TabIndex = 391
        Me._TextCil_70.Text = ""
        '
        '_TextCil_69
        '
        Me._TextCil_69.AcceptsReturn = True
        Me._TextCil_69.AutoSize = False
        Me._TextCil_69.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_69.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_69.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_69.Location = New System.Drawing.Point(117, 72)
        Me._TextCil_69.MaxLength = 0
        Me._TextCil_69.Name = "_TextCil_69"
        Me._TextCil_69.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_69.Size = New System.Drawing.Size(199, 20)
        Me._TextCil_69.TabIndex = 390
        Me._TextCil_69.Text = ""
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(315, 54)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 389
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_68
        '
        Me._TextCil_68.AcceptsReturn = True
        Me._TextCil_68.AutoSize = False
        Me._TextCil_68.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_68.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_68.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_68.Location = New System.Drawing.Point(117, 54)
        Me._TextCil_68.MaxLength = 0
        Me._TextCil_68.Name = "_TextCil_68"
        Me._TextCil_68.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_68.Size = New System.Drawing.Size(199, 20)
        Me._TextCil_68.TabIndex = 388
        Me._TextCil_68.Text = ""
        '
        '_TextCil_67
        '
        Me._TextCil_67.AcceptsReturn = True
        Me._TextCil_67.AutoSize = False
        Me._TextCil_67.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_67.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_67.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_67.Location = New System.Drawing.Point(288, 36)
        Me._TextCil_67.MaxLength = 0
        Me._TextCil_67.Name = "_TextCil_67"
        Me._TextCil_67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_67.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_67.TabIndex = 387
        Me._TextCil_67.Text = ""
        '
        '_TextCil_66
        '
        Me._TextCil_66.AcceptsReturn = True
        Me._TextCil_66.AutoSize = False
        Me._TextCil_66.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_66.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_66.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_66.Location = New System.Drawing.Point(117, 36)
        Me._TextCil_66.MaxLength = 0
        Me._TextCil_66.Name = "_TextCil_66"
        Me._TextCil_66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_66.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_66.TabIndex = 386
        Me._TextCil_66.Text = ""
        '
        '_TextCil_65
        '
        Me._TextCil_65.AcceptsReturn = True
        Me._TextCil_65.AutoSize = False
        Me._TextCil_65.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_65.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_65.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_65.Location = New System.Drawing.Point(288, 18)
        Me._TextCil_65.MaxLength = 0
        Me._TextCil_65.Name = "_TextCil_65"
        Me._TextCil_65.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_65.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_65.TabIndex = 385
        Me._TextCil_65.Text = ""
        '
        '_TextCil_64
        '
        Me._TextCil_64.AcceptsReturn = True
        Me._TextCil_64.AutoSize = False
        Me._TextCil_64.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_64.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_64.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_64.Location = New System.Drawing.Point(117, 18)
        Me._TextCil_64.MaxLength = 0
        Me._TextCil_64.Name = "_TextCil_64"
        Me._TextCil_64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_64.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_64.TabIndex = 384
        Me._TextCil_64.Text = ""
        '
        '_TextCil_63
        '
        Me._TextCil_63.AcceptsReturn = True
        Me._TextCil_63.AutoSize = False
        Me._TextCil_63.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_63.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_63.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_63.Location = New System.Drawing.Point(288, 0)
        Me._TextCil_63.MaxLength = 0
        Me._TextCil_63.Name = "_TextCil_63"
        Me._TextCil_63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_63.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_63.TabIndex = 383
        Me._TextCil_63.Text = ""
        '
        '_TextCil_62
        '
        Me._TextCil_62.AcceptsReturn = True
        Me._TextCil_62.AutoSize = False
        Me._TextCil_62.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_62.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_62.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_62.Location = New System.Drawing.Point(117, 0)
        Me._TextCil_62.MaxLength = 0
        Me._TextCil_62.Name = "_TextCil_62"
        Me._TextCil_62.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_62.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_62.TabIndex = 382
        Me._TextCil_62.Text = ""
        '
        '_LabelCil_64
        '
        Me._LabelCil_64.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_64.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_64.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_64.Location = New System.Drawing.Point(0, 126)
        Me._LabelCil_64.Name = "_LabelCil_64"
        Me._LabelCil_64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_64.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_64.TabIndex = 410
        Me._LabelCil_64.Text = "Sviluppo traversini"
        '
        '_LabelCil_63
        '
        Me._LabelCil_63.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_63.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_63.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_63.Location = New System.Drawing.Point(171, 126)
        Me._LabelCil_63.Name = "_LabelCil_63"
        Me._LabelCil_63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_63.Size = New System.Drawing.Size(133, 17)
        Me._LabelCil_63.TabIndex = 409
        Me._LabelCil_63.Text = "Largh.efficace traversini"
        '
        '_LabelCil_65
        '
        Me._LabelCil_65.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_65.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_65.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_65.Location = New System.Drawing.Point(171, 108)
        Me._LabelCil_65.Name = "_LabelCil_65"
        Me._LabelCil_65.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_65.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_65.TabIndex = 408
        Me._LabelCil_65.Text = "Y traversini [psi]"
        '
        '_LabelCil_66
        '
        Me._LabelCil_66.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_66.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_66.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_66.Location = New System.Drawing.Point(0, 108)
        Me._LabelCil_66.Name = "_LabelCil_66"
        Me._LabelCil_66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_66.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_66.TabIndex = 407
        Me._LabelCil_66.Text = "m traversini"
        '
        '_LabelCil_67
        '
        Me._LabelCil_67.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_67.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_67.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_67.Location = New System.Drawing.Point(171, 90)
        Me._LabelCil_67.Name = "_LabelCil_67"
        Me._LabelCil_67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_67.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_67.TabIndex = 406
        Me._LabelCil_67.Text = "Y di guarnizione [psi]"
        '
        '_LabelCil_68
        '
        Me._LabelCil_68.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_68.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_68.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_68.Location = New System.Drawing.Point(0, 90)
        Me._LabelCil_68.Name = "_LabelCil_68"
        Me._LabelCil_68.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_68.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_68.TabIndex = 405
        Me._LabelCil_68.Text = "m di guarnizione"
        '
        '_LabelCil_69
        '
        Me._LabelCil_69.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_69.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_69.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_69.Location = New System.Drawing.Point(0, 72)
        Me._LabelCil_69.Name = "_LabelCil_69"
        Me._LabelCil_69.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_69.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_69.TabIndex = 404
        Me._LabelCil_69.Text = "Materiale guarnizione"
        '
        '_LabelCil_70
        '
        Me._LabelCil_70.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_70.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_70.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_70.Location = New System.Drawing.Point(0, 54)
        Me._LabelCil_70.Name = "_LabelCil_70"
        Me._LabelCil_70.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_70.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_70.TabIndex = 403
        Me._LabelCil_70.Text = "Tipo guarnizione"
        '
        '_LabelCil_71
        '
        Me._LabelCil_71.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_71.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_71.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_71.Location = New System.Drawing.Point(171, 36)
        Me._LabelCil_71.Name = "_LabelCil_71"
        Me._LabelCil_71.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_71.Size = New System.Drawing.Size(125, 17)
        Me._LabelCil_71.TabIndex = 402
        Me._LabelCil_71.Text = "Largh. guarn."
        '
        '_LabelCil_72
        '
        Me._LabelCil_72.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_72.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_72.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_72.Location = New System.Drawing.Point(0, 36)
        Me._LabelCil_72.Name = "_LabelCil_72"
        Me._LabelCil_72.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_72.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_72.TabIndex = 401
        Me._LabelCil_72.Tag = "kLength"
        Me._LabelCil_72.Text = "Diam. medio g."
        '
        '_LabelCil_73
        '
        Me._LabelCil_73.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_73.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_73.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_73.Location = New System.Drawing.Point(171, 18)
        Me._LabelCil_73.Name = "_LabelCil_73"
        Me._LabelCil_73.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_73.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_73.TabIndex = 400
        Me._LabelCil_73.Tag = "kLength"
        Me._LabelCil_73.Text = "Sp. min codolo"
        '
        '_LabelCil_74
        '
        Me._LabelCil_74.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_74.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_74.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_74.Location = New System.Drawing.Point(0, 18)
        Me._LabelCil_74.Name = "_LabelCil_74"
        Me._LabelCil_74.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_74.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_74.TabIndex = 399
        Me._LabelCil_74.Tag = "kLength"
        Me._LabelCil_74.Text = "Sp. max codolo"
        '
        '_LabelCil_75
        '
        Me._LabelCil_75.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_75.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_75.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_75.Location = New System.Drawing.Point(171, 0)
        Me._LabelCil_75.Name = "_LabelCil_75"
        Me._LabelCil_75.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_75.Size = New System.Drawing.Size(117, 17)
        Me._LabelCil_75.TabIndex = 398
        Me._LabelCil_75.Tag = "kLength"
        Me._LabelCil_75.Text = "Diametro interno"
        '
        '_LabelCil_76
        '
        Me._LabelCil_76.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_76.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_76.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_76.Location = New System.Drawing.Point(0, 0)
        Me._LabelCil_76.Name = "_LabelCil_76"
        Me._LabelCil_76.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_76.Size = New System.Drawing.Size(120, 17)
        Me._LabelCil_76.TabIndex = 397
        Me._LabelCil_76.Tag = "kLength"
        Me._LabelCil_76.Text = "Diametro esterno"
        '
        '_TextCil_110
        '
        Me._TextCil_110.AcceptsReturn = True
        Me._TextCil_110.AutoSize = False
        Me._TextCil_110.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_110.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_110.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_110.Location = New System.Drawing.Point(93, 256)
        Me._TextCil_110.MaxLength = 0
        Me._TextCil_110.Name = "_TextCil_110"
        Me._TextCil_110.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_110.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_110.TabIndex = 334
        Me._TextCil_110.Text = ""
        '
        '_TextCil_109
        '
        Me._TextCil_109.AcceptsReturn = True
        Me._TextCil_109.AutoSize = False
        Me._TextCil_109.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_109.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_109.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_109.Location = New System.Drawing.Point(93, 274)
        Me._TextCil_109.MaxLength = 0
        Me._TextCil_109.Name = "_TextCil_109"
        Me._TextCil_109.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_109.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_109.TabIndex = 333
        Me._TextCil_109.Text = ""
        '
        '_cmdCil_181
        '
        Me._cmdCil_181.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_181.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_181.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_181.Image = CType(resources.GetObject("_cmdCil_181.Image"), System.Drawing.Image)
        Me._cmdCil_181.Location = New System.Drawing.Point(328, 40)
        Me._cmdCil_181.Name = "_cmdCil_181"
        Me._cmdCil_181.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_181.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_181.TabIndex = 246
        Me._cmdCil_181.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_List2_81
        '
        Me._List2_81.BackColor = System.Drawing.SystemColors.Window
        Me._List2_81.Cursor = System.Windows.Forms.Cursors.Default
        Me._List2_81.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List2_81.Location = New System.Drawing.Point(256, 280)
        Me._List2_81.Name = "_List2_81"
        Me._List2_81.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List2_81.Size = New System.Drawing.Size(55, 17)
        Me._List2_81.TabIndex = 159
        Me._List2_81.Visible = False
        '
        '_TextCil_54
        '
        Me._TextCil_54.AcceptsReturn = True
        Me._TextCil_54.AutoSize = False
        Me._TextCil_54.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_54.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_54.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_54.Location = New System.Drawing.Point(126, 220)
        Me._TextCil_54.MaxLength = 0
        Me._TextCil_54.Name = "_TextCil_54"
        Me._TextCil_54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_54.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_54.TabIndex = 157
        Me._TextCil_54.Text = ""
        '
        '_cmbCil_81
        '
        Me._cmbCil_81.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_81.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_81.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_81.Location = New System.Drawing.Point(128, 16)
        Me._cmbCil_81.Name = "_cmbCil_81"
        Me._cmbCil_81.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_81.Size = New System.Drawing.Size(216, 21)
        Me._cmbCil_81.TabIndex = 151
        Me._cmbCil_81.Text = "cmbCil"
        '
        '_TextCil_76
        '
        Me._TextCil_76.AcceptsReturn = True
        Me._TextCil_76.AutoSize = False
        Me._TextCil_76.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_76.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_76.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_76.Location = New System.Drawing.Point(94, 220)
        Me._TextCil_76.MaxLength = 0
        Me._TextCil_76.Name = "_TextCil_76"
        Me._TextCil_76.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_76.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_76.TabIndex = 91
        Me._TextCil_76.Text = ""
        '
        '_TextCil_77
        '
        Me._TextCil_77.AcceptsReturn = True
        Me._TextCil_77.AutoSize = False
        Me._TextCil_77.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_77.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_77.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_77.Location = New System.Drawing.Point(256, 220)
        Me._TextCil_77.MaxLength = 0
        Me._TextCil_77.Name = "_TextCil_77"
        Me._TextCil_77.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_77.Size = New System.Drawing.Size(86, 20)
        Me._TextCil_77.TabIndex = 90
        Me._TextCil_77.Text = ""
        '
        '_TextCil_78
        '
        Me._TextCil_78.AcceptsReturn = True
        Me._TextCil_78.AutoSize = False
        Me._TextCil_78.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_78.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_78.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_78.Location = New System.Drawing.Point(93, 239)
        Me._TextCil_78.MaxLength = 0
        Me._TextCil_78.Name = "_TextCil_78"
        Me._TextCil_78.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_78.Size = New System.Drawing.Size(78, 20)
        Me._TextCil_78.TabIndex = 89
        Me._TextCil_78.Text = ""
        '
        '_TextCil_79
        '
        Me._TextCil_79.AcceptsReturn = True
        Me._TextCil_79.AutoSize = False
        Me._TextCil_79.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_79.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_79.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_79.Location = New System.Drawing.Point(257, 238)
        Me._TextCil_79.MaxLength = 0
        Me._TextCil_79.Name = "_TextCil_79"
        Me._TextCil_79.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_79.Size = New System.Drawing.Size(86, 20)
        Me._TextCil_79.TabIndex = 88
        Me._TextCil_79.Text = ""
        '
        '_TextCil_80
        '
        Me._TextCil_80.AcceptsReturn = True
        Me._TextCil_80.AutoSize = False
        Me._TextCil_80.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_80.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_80.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_80.Location = New System.Drawing.Point(297, 299)
        Me._TextCil_80.MaxLength = 0
        Me._TextCil_80.Name = "_TextCil_80"
        Me._TextCil_80.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_80.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_80.TabIndex = 87
        Me._TextCil_80.Text = ""
        '
        '_LabelCil_146
        '
        Me._LabelCil_146.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_146.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_146.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_146.Location = New System.Drawing.Point(176, 220)
        Me._LabelCil_146.Name = "_LabelCil_146"
        Me._LabelCil_146.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_146.Size = New System.Drawing.Size(81, 17)
        Me._LabelCil_146.TabIndex = 336
        Me._LabelCil_146.Tag = "kForce"
        Me._LabelCil_146.Text = "Wm2         "
        '
        '_LabelCil_145
        '
        Me._LabelCil_145.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_145.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_145.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_145.Location = New System.Drawing.Point(176, 238)
        Me._LabelCil_145.Name = "_LabelCil_145"
        Me._LabelCil_145.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_145.Size = New System.Drawing.Size(81, 17)
        Me._LabelCil_145.TabIndex = 335
        Me._LabelCil_145.Tag = "kForce"
        Me._LabelCil_145.Text = "Wm2  H.T. "
        '
        '_LabelCil_181
        '
        Me._LabelCil_181.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_181.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_181.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_181.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_181.Name = "_LabelCil_181"
        Me._LabelCil_181.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_181.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_181.TabIndex = 245
        Me._LabelCil_181.Text = "Materiale flangia"
        '
        '_LabelCil_84
        '
        Me._LabelCil_84.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_84.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_84.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_84.Location = New System.Drawing.Point(8, 223)
        Me._LabelCil_84.Name = "_LabelCil_84"
        Me._LabelCil_84.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_84.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_84.TabIndex = 158
        Me._LabelCil_84.Text = "Larghezza nubbin"
        '
        '_LabelCil_77
        '
        Me._LabelCil_77.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_77.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_77.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_77.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_77.Name = "_LabelCil_77"
        Me._LabelCil_77.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_77.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_77.TabIndex = 97
        Me._LabelCil_77.Text = "Flange identification"
        '
        '_LabelCil_62
        '
        Me._LabelCil_62.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_62.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_62.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_62.Location = New System.Drawing.Point(9, 223)
        Me._LabelCil_62.Name = "_LabelCil_62"
        Me._LabelCil_62.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_62.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_62.TabIndex = 96
        Me._LabelCil_62.Tag = "kForce"
        Me._LabelCil_62.Text = "Wm1 design "
        '
        '_LabelCil_61
        '
        Me._LabelCil_61.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_61.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_61.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_61.Location = New System.Drawing.Point(12, 258)
        Me._LabelCil_61.Name = "_LabelCil_61"
        Me._LabelCil_61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_61.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_61.TabIndex = 95
        Me._LabelCil_61.Tag = "kForce"
        Me._LabelCil_61.Text = "W   design "
        '
        '_LabelCil_60
        '
        Me._LabelCil_60.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_60.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_60.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_60.Location = New System.Drawing.Point(9, 238)
        Me._LabelCil_60.Name = "_LabelCil_60"
        Me._LabelCil_60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_60.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_60.TabIndex = 94
        Me._LabelCil_60.Tag = "kForce"
        Me._LabelCil_60.Text = "Wm1 H.T. "
        '
        '_LabelCil_59
        '
        Me._LabelCil_59.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_59.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_59.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_59.Location = New System.Drawing.Point(12, 276)
        Me._LabelCil_59.Name = "_LabelCil_59"
        Me._LabelCil_59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_59.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_59.TabIndex = 93
        Me._LabelCil_59.Tag = "kForce"
        Me._LabelCil_59.Text = "W      H.T. "
        '
        '_LabelCil_58
        '
        Me._LabelCil_58.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_58.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_58.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_58.Location = New System.Drawing.Point(9, 296)
        Me._LabelCil_58.Name = "_LabelCil_58"
        Me._LabelCil_58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_58.Size = New System.Drawing.Size(258, 17)
        Me._LabelCil_58.TabIndex = 92
        Me._LabelCil_58.Tag = "kLength"
        Me._LabelCil_58.Text = "Diametro equivalente guarnizione"
        '
        '_Frames_0
        '
        Me._Frames_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_0.Controls.Add(Me._cmdCil_1)
        Me._Frames_0.Controls.Add(Me.chkAggancBoltLT)
        Me._Frames_0.Controls.Add(Me._TextCil_15)
        Me._Frames_0.Controls.Add(Me.cmbMatBoltLT)
        Me._Frames_0.Controls.Add(Me._frmCollars_0)
        Me._Frames_0.Controls.Add(Me._cmdCil_6)
        Me._Frames_0.Controls.Add(Me._Check1_2)
        Me._Frames_0.Controls.Add(Me._Check1_1)
        Me._Frames_0.Controls.Add(Me._cmbCil_3)
        Me._Frames_0.Controls.Add(Me._TextCil_2)
        Me._Frames_0.Controls.Add(Me._TextCil_3)
        Me._Frames_0.Controls.Add(Me._TextCil_16)
        Me._Frames_0.Controls.Add(Me._cmdCil_2)
        Me._Frames_0.Controls.Add(Me._TextCil_12)
        Me._Frames_0.Controls.Add(Me._TextCil_11)
        Me._Frames_0.Controls.Add(Me._TextCil_9)
        Me._Frames_0.Controls.Add(Me._TextCil_7)
        Me._Frames_0.Controls.Add(Me._TextCil_6)
        Me._Frames_0.Controls.Add(Me._TextCil_5)
        Me._Frames_0.Controls.Add(Me._LabelCil_5)
        Me._Frames_0.Controls.Add(Me._LabelCil_6)
        Me._Frames_0.Controls.Add(Me._LabelCil_7)
        Me._Frames_0.Controls.Add(Me._LabelCil_21)
        Me._Frames_0.Controls.Add(Me._LabelCil_20)
        Me._Frames_0.Controls.Add(Me._LabelCil_2)
        Me._Frames_0.Controls.Add(Me._LabelCil_17)
        Me._Frames_0.Controls.Add(Me._LabelCil_16)
        Me._Frames_0.Controls.Add(Me._LabelCil_15)
        Me._Frames_0.Controls.Add(Me._LabelCil_13)
        Me._Frames_0.Controls.Add(Me._LabelCil_11)
        Me._Frames_0.Controls.Add(Me._LabelCil_10)
        Me._Frames_0.ForeColor = System.Drawing.Color.Blue
        Me._Frames_0.Location = New System.Drawing.Point(360, 332)
        Me._Frames_0.Name = "_Frames_0"
        Me._Frames_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_0.Size = New System.Drawing.Size(352, 376)
        Me._Frames_0.TabIndex = 14
        Me._Frames_0.TabStop = False
        Me._Frames_0.Text = "Dati bulloni"
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(270, 140)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 29
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_15
        '
        Me._TextCil_15.AcceptsReturn = True
        Me._TextCil_15.AutoSize = False
        Me._TextCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_15.Location = New System.Drawing.Point(193, 160)
        Me._TextCil_15.MaxLength = 0
        Me._TextCil_15.Name = "_TextCil_15"
        Me._TextCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_15.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_15.TabIndex = 31
        Me._TextCil_15.Text = ""
        '
        'cmbMatBoltLT
        '
        Me.cmbMatBoltLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatBoltLT.Location = New System.Drawing.Point(80, 140)
        Me.cmbMatBoltLT.Name = "cmbMatBoltLT"
        Me.cmbMatBoltLT.Size = New System.Drawing.Size(192, 21)
        Me.cmbMatBoltLT.TabIndex = 257
        '
        '_frmCollars_0
        '
        Me._frmCollars_0.BackColor = System.Drawing.SystemColors.Control
        Me._frmCollars_0.Controls.Add(Me._optColl_1)
        Me._frmCollars_0.Controls.Add(Me._optColl_0)
        Me._frmCollars_0.Controls.Add(Me._TextCil_13)
        Me._frmCollars_0.Controls.Add(Me._Label1_0)
        Me._frmCollars_0.Controls.Add(Me._LabelCil_18)
        Me._frmCollars_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmCollars_0.Location = New System.Drawing.Point(8, 296)
        Me._frmCollars_0.Name = "_frmCollars_0"
        Me._frmCollars_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmCollars_0.Size = New System.Drawing.Size(336, 72)
        Me._frmCollars_0.TabIndex = 256
        Me._frmCollars_0.TabStop = False
        Me._frmCollars_0.Text = "Collar bolts"
        '
        '_optColl_1
        '
        Me._optColl_1.BackColor = System.Drawing.SystemColors.Control
        Me._optColl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optColl_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optColl_1.Location = New System.Drawing.Point(240, 48)
        Me._optColl_1.Name = "_optColl_1"
        Me._optColl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optColl_1.Size = New System.Drawing.Size(73, 17)
        Me._optColl_1.TabIndex = 261
        Me._optColl_1.TabStop = True
        Me._optColl_1.Text = "mantello"
        '
        '_optColl_0
        '
        Me._optColl_0.BackColor = System.Drawing.SystemColors.Control
        Me._optColl_0.Checked = True
        Me._optColl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optColl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optColl_0.Location = New System.Drawing.Point(184, 48)
        Me._optColl_0.Name = "_optColl_0"
        Me._optColl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optColl_0.Size = New System.Drawing.Size(57, 17)
        Me._optColl_0.TabIndex = 260
        Me._optColl_0.TabStop = True
        Me._optColl_0.Text = "tubi"
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(128, 16)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(32, 20)
        Me._TextCil_13.TabIndex = 257
        Me._TextCil_13.Text = ""
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(184, 16)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(137, 25)
        Me._Label1_0.TabIndex = 259
        Me._Label1_0.Text = "Il collare permette di serrare la guarnizione lato:"
        '
        '_LabelCil_18
        '
        Me._LabelCil_18.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_18.Location = New System.Drawing.Point(8, 16)
        Me._LabelCil_18.Name = "_LabelCil_18"
        Me._LabelCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_18.Size = New System.Drawing.Size(115, 19)
        Me._LabelCil_18.TabIndex = 258
        Me._LabelCil_18.Text = "N° bulloni con collare"
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(270, 162)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_6.TabIndex = 163
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Check1_2
        '
        Me._Check1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_2.Checked = True
        Me._Check1_2.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_2.Location = New System.Drawing.Point(9, 270)
        Me._Check1_2.Name = "_Check1_2"
        Me._Check1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_2.Size = New System.Drawing.Size(267, 19)
        Me._Check1_2.TabIndex = 42
        Me._Check1_2.Text = "Controllo schiacciamento guarnizione"
        '
        '_Check1_1
        '
        Me._Check1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_1.Checked = True
        Me._Check1_1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_1.Location = New System.Drawing.Point(9, 252)
        Me._Check1_1.Name = "_Check1_1"
        Me._Check1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_1.Size = New System.Drawing.Size(267, 19)
        Me._Check1_1.TabIndex = 41
        Me._Check1_1.Text = "Tiro bulloni differenziato PI / esercizio"
        '
        '_cmbCil_3
        '
        Me._cmbCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_3.Location = New System.Drawing.Point(144, 198)
        Me._cmbCil_3.Name = "_cmbCil_3"
        Me._cmbCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_3.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_3.TabIndex = 37
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(198, 216)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 36
        Me._TextCil_2.Text = ""
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(198, 234)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 35
        Me._TextCil_3.Text = ""
        '
        '_TextCil_16
        '
        Me._TextCil_16.AcceptsReturn = True
        Me._TextCil_16.AutoSize = False
        Me._TextCil_16.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_16.Location = New System.Drawing.Point(193, 181)
        Me._TextCil_16.MaxLength = 0
        Me._TextCil_16.Name = "_TextCil_16"
        Me._TextCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_16.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_16.TabIndex = 32
        Me._TextCil_16.Text = ""
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(224, 18)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 27
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_12
        '
        Me._TextCil_12.AcceptsReturn = True
        Me._TextCil_12.AutoSize = False
        Me._TextCil_12.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_12.Location = New System.Drawing.Point(184, 108)
        Me._TextCil_12.MaxLength = 0
        Me._TextCil_12.Name = "_TextCil_12"
        Me._TextCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_12.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_12.TabIndex = 26
        Me._TextCil_12.Text = ""
        '
        '_TextCil_11
        '
        Me._TextCil_11.AcceptsReturn = True
        Me._TextCil_11.AutoSize = False
        Me._TextCil_11.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_11.Location = New System.Drawing.Point(184, 90)
        Me._TextCil_11.MaxLength = 0
        Me._TextCil_11.Name = "_TextCil_11"
        Me._TextCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_11.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_11.TabIndex = 24
        Me._TextCil_11.Text = ""
        '
        '_TextCil_9
        '
        Me._TextCil_9.AcceptsReturn = True
        Me._TextCil_9.AutoSize = False
        Me._TextCil_9.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_9.Location = New System.Drawing.Point(184, 72)
        Me._TextCil_9.MaxLength = 0
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_9.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_9.TabIndex = 22
        Me._TextCil_9.Text = ""
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(184, 54)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_7.TabIndex = 20
        Me._TextCil_7.Text = ""
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(184, 36)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_6.TabIndex = 18
        Me._TextCil_6.Text = ""
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(184, 18)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_5.TabIndex = 16
        Me._TextCil_5.Text = ""
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(9, 198)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(145, 19)
        Me._LabelCil_5.TabIndex = 40
        Me._LabelCil_5.Text = "Bolt load option"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(9, 216)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(181, 19)
        Me._LabelCil_6.TabIndex = 39
        Me._LabelCil_6.Text = "Disuniformità tiro bulloni"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(9, 234)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(181, 19)
        Me._LabelCil_7.TabIndex = 38
        Me._LabelCil_7.Text = "Frazione Sy bulloni in P.I."
        '
        '_LabelCil_21
        '
        Me._LabelCil_21.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_21.Location = New System.Drawing.Point(9, 181)
        Me._LabelCil_21.Name = "_LabelCil_21"
        Me._LabelCil_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_21.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_21.TabIndex = 34
        Me._LabelCil_21.Tag = "kPress"
        Me._LabelCil_21.Text = "Allowable stress @ temp"
        '
        '_LabelCil_20
        '
        Me._LabelCil_20.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_20.Location = New System.Drawing.Point(9, 163)
        Me._LabelCil_20.Name = "_LabelCil_20"
        Me._LabelCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_20.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_20.TabIndex = 33
        Me._LabelCil_20.Tag = "kPress"
        Me._LabelCil_20.Text = "Allowable stress @ room"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_2.Location = New System.Drawing.Point(9, 144)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_2.Size = New System.Drawing.Size(172, 19)
        Me._LabelCil_2.TabIndex = 30
        Me._LabelCil_2.Text = "Bolt Material"
        '
        '_LabelCil_17
        '
        Me._LabelCil_17.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_17.Location = New System.Drawing.Point(9, 108)
        Me._LabelCil_17.Name = "_LabelCil_17"
        Me._LabelCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_17.Size = New System.Drawing.Size(159, 19)
        Me._LabelCil_17.TabIndex = 25
        Me._LabelCil_17.Tag = "kLength"
        Me._LabelCil_17.Text = "Spaziatura rad.est. [mm]"
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(9, 90)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(118, 19)
        Me._LabelCil_16.TabIndex = 23
        Me._LabelCil_16.Tag = "kLength"
        Me._LabelCil_16.Text = "B.S. minimo [mm]"
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(9, 72)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(151, 19)
        Me._LabelCil_15.TabIndex = 21
        Me._LabelCil_15.Tag = "kArea"
        Me._LabelCil_15.Text = "Sezione bullone [in2]"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(9, 54)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(159, 19)
        Me._LabelCil_13.TabIndex = 19
        Me._LabelCil_13.Tag = "kLength"
        Me._LabelCil_13.Text = "Diametro cerchio"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_11.Location = New System.Drawing.Point(9, 36)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_11.Size = New System.Drawing.Size(118, 19)
        Me._LabelCil_11.TabIndex = 17
        Me._LabelCil_11.Text = "N° bulloni"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_10.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_10.Size = New System.Drawing.Size(151, 19)
        Me._LabelCil_10.TabIndex = 15
        Me._LabelCil_10.Tag = "kLength"
        Me._LabelCil_10.Text = "Diametro nominale"
        '
        '_Frames_3
        '
        Me._Frames_3.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_3.Controls.Add(Me.cmbMatSlLT)
        Me._Frames_3.Controls.Add(Me._cmdCil_201)
        Me._Frames_3.Controls.Add(Me._List2_101)
        Me._Frames_3.Controls.Add(Me._cmbCil_101)
        Me._Frames_3.Controls.Add(Me._TextCil_102)
        Me._Frames_3.Controls.Add(Me._TextCil_103)
        Me._Frames_3.Controls.Add(Me._LabelCil_201)
        Me._Frames_3.Controls.Add(Me._LabelCil_97)
        Me._Frames_3.Controls.Add(Me._LabelCil_96)
        Me._Frames_3.Controls.Add(Me._LabelCil_95)
        Me._Frames_3.ForeColor = System.Drawing.Color.Blue
        Me._Frames_3.Location = New System.Drawing.Point(360, 96)
        Me._Frames_3.Name = "_Frames_3"
        Me._Frames_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_3.Size = New System.Drawing.Size(352, 316)
        Me._Frames_3.TabIndex = 98
        Me._Frames_3.TabStop = False
        Me._Frames_3.Text = "Dati saldatura L.T."
        '
        'cmbMatSlLT
        '
        Me.cmbMatSlLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatSlLT.Location = New System.Drawing.Point(152, 40)
        Me.cmbMatSlLT.Name = "cmbMatSlLT"
        Me.cmbMatSlLT.Size = New System.Drawing.Size(168, 21)
        Me.cmbMatSlLT.TabIndex = 253
        '
        '_cmdCil_201
        '
        Me._cmdCil_201.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_201.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_201.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_201.Image = CType(resources.GetObject("_cmdCil_201.Image"), System.Drawing.Image)
        Me._cmdCil_201.Location = New System.Drawing.Point(323, 40)
        Me._cmdCil_201.Name = "_cmdCil_201"
        Me._cmdCil_201.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_201.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_201.TabIndex = 250
        Me._cmdCil_201.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_List2_101
        '
        Me._List2_101.BackColor = System.Drawing.SystemColors.Window
        Me._List2_101.Cursor = System.Windows.Forms.Cursors.Default
        Me._List2_101.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List2_101.Location = New System.Drawing.Point(16, 104)
        Me._List2_101.Name = "_List2_101"
        Me._List2_101.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List2_101.Size = New System.Drawing.Size(55, 17)
        Me._List2_101.TabIndex = 161
        Me._List2_101.Visible = False
        '
        '_cmbCil_101
        '
        Me._cmbCil_101.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_101.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_101.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_101.Location = New System.Drawing.Point(152, 16)
        Me._cmbCil_101.Name = "_cmbCil_101"
        Me._cmbCil_101.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_101.Size = New System.Drawing.Size(192, 21)
        Me._cmbCil_101.TabIndex = 150
        Me._cmbCil_101.Text = "cmbCil"
        '
        '_TextCil_102
        '
        Me._TextCil_102.AcceptsReturn = True
        Me._TextCil_102.AutoSize = False
        Me._TextCil_102.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_102.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_102.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_102.Location = New System.Drawing.Point(153, 60)
        Me._TextCil_102.MaxLength = 0
        Me._TextCil_102.Name = "_TextCil_102"
        Me._TextCil_102.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_102.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_102.TabIndex = 100
        Me._TextCil_102.Text = ""
        '
        '_TextCil_103
        '
        Me._TextCil_103.AcceptsReturn = True
        Me._TextCil_103.AutoSize = False
        Me._TextCil_103.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_103.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_103.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_103.Location = New System.Drawing.Point(153, 78)
        Me._TextCil_103.MaxLength = 0
        Me._TextCil_103.Name = "_TextCil_103"
        Me._TextCil_103.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_103.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_103.TabIndex = 99
        Me._TextCil_103.Text = ""
        '
        '_LabelCil_201
        '
        Me._LabelCil_201.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_201.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_201.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_201.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_201.Name = "_LabelCil_201"
        Me._LabelCil_201.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_201.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_201.TabIndex = 252
        Me._LabelCil_201.Text = "Materiale cassa"
        '
        '_LabelCil_97
        '
        Me._LabelCil_97.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_97.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_97.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_97.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_97.Name = "_LabelCil_97"
        Me._LabelCil_97.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_97.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_97.TabIndex = 103
        Me._LabelCil_97.Text = "Member identification"
        '
        '_LabelCil_96
        '
        Me._LabelCil_96.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_96.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_96.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_96.Location = New System.Drawing.Point(9, 60)
        Me._LabelCil_96.Name = "_LabelCil_96"
        Me._LabelCil_96.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_96.Size = New System.Drawing.Size(127, 17)
        Me._LabelCil_96.TabIndex = 102
        Me._LabelCil_96.Tag = "kLength"
        Me._LabelCil_96.Text = "Diametro interno"
        '
        '_LabelCil_95
        '
        Me._LabelCil_95.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_95.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_95.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_95.Location = New System.Drawing.Point(9, 78)
        Me._LabelCil_95.Name = "_LabelCil_95"
        Me._LabelCil_95.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_95.Size = New System.Drawing.Size(127, 17)
        Me._LabelCil_95.TabIndex = 101
        Me._LabelCil_95.Tag = "kLength"
        Me._LabelCil_95.Text = "Spessore"
        '
        '_Frames_5
        '
        Me._Frames_5.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_5.Controls.Add(Me._TextCil_91)
        Me._Frames_5.Controls.Add(Me.Frame1)
        Me._Frames_5.Controls.Add(Me._cmdCil_32)
        Me._Frames_5.Controls.Add(Me._TextCil_52)
        Me._Frames_5.Controls.Add(Me._cmdCil_31)
        Me._Frames_5.Controls.Add(Me._cmdCil_30)
        Me._Frames_5.Controls.Add(Me._cmdCil_29)
        Me._Frames_5.Controls.Add(Me._cmdCil_25)
        Me._Frames_5.Controls.Add(Me._cmdCil_24)
        Me._Frames_5.Controls.Add(Me._cmdCil_27)
        Me._Frames_5.Controls.Add(Me._cmdCil_26)
        Me._Frames_5.Controls.Add(Me._Check1_7)
        Me._Frames_5.Controls.Add(Me._Check1_6)
        Me._Frames_5.Controls.Add(Me._Check1_5)
        Me._Frames_5.Controls.Add(Me._TextCil_31)
        Me._Frames_5.Controls.Add(Me._TextCil_30)
        Me._Frames_5.Controls.Add(Me._TextCil_29)
        Me._Frames_5.Controls.Add(Me._TextCil_28)
        Me._Frames_5.Controls.Add(Me._TextCil_10)
        Me._Frames_5.Controls.Add(Me._TextCil_25)
        Me._Frames_5.Controls.Add(Me._TextCil_24)
        Me._Frames_5.Controls.Add(Me._TextCil_27)
        Me._Frames_5.Controls.Add(Me._TextCil_26)
        Me._Frames_5.Controls.Add(Me._LabelCil_141)
        Me._Frames_5.Controls.Add(Me._lblUni_91)
        Me._Frames_5.Controls.Add(Me._lblUni_52)
        Me._Frames_5.Controls.Add(Me._LabelCil_81)
        Me._Frames_5.Controls.Add(Me._lblUni_31)
        Me._Frames_5.Controls.Add(Me._lblUni_30)
        Me._Frames_5.Controls.Add(Me._lblUni_29)
        Me._Frames_5.Controls.Add(Me._lblUni_25)
        Me._Frames_5.Controls.Add(Me._lblUni_24)
        Me._Frames_5.Controls.Add(Me._lblUni_28)
        Me._Frames_5.Controls.Add(Me._lblUni_10)
        Me._Frames_5.Controls.Add(Me._lblUni_27)
        Me._Frames_5.Controls.Add(Me._lblUni_26)
        Me._Frames_5.Controls.Add(Me._LabelCil_37)
        Me._Frames_5.Controls.Add(Me._LabelCil_36)
        Me._Frames_5.Controls.Add(Me._LabelCil_35)
        Me._Frames_5.Controls.Add(Me._LabelCil_34)
        Me._Frames_5.Controls.Add(Me._LabelCil_12)
        Me._Frames_5.Controls.Add(Me._LabelCil_31)
        Me._Frames_5.Controls.Add(Me._LabelCil_30)
        Me._Frames_5.Controls.Add(Me._LabelCil_33)
        Me._Frames_5.Controls.Add(Me._LabelCil_32)
        Me._Frames_5.ForeColor = System.Drawing.Color.Blue
        Me._Frames_5.Location = New System.Drawing.Point(360, 216)
        Me._Frames_5.Name = "_Frames_5"
        Me._Frames_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_5.Size = New System.Drawing.Size(352, 316)
        Me._Frames_5.TabIndex = 51
        Me._Frames_5.TabStop = False
        Me._Frames_5.Text = "Dati di progetto"
        '
        '_TextCil_91
        '
        Me._TextCil_91.AcceptsReturn = True
        Me._TextCil_91.AutoSize = False
        Me._TextCil_91.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_91.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_91.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_91.Location = New System.Drawing.Point(162, 235)
        Me._TextCil_91.MaxLength = 0
        Me._TextCil_91.Name = "_TextCil_91"
        Me._TextCil_91.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_91.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_91.TabIndex = 322
        Me._TextCil_91.Text = ""
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._TextCil_89)
        Me.Frame1.Controls.Add(Me._LabelCil_108)
        Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 256)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(300, 43)
        Me.Frame1.TabIndex = 203
        '
        '_TextCil_89
        '
        Me._TextCil_89.Location = New System.Drawing.Point(216, 0)
        Me._TextCil_89.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me._TextCil_89.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me._TextCil_89.Name = "_TextCil_89"
        Me._TextCil_89.Size = New System.Drawing.Size(48, 20)
        Me._TextCil_89.TabIndex = 209
        Me._TextCil_89.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._TextCil_89.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        '_LabelCil_108
        '
        Me._LabelCil_108.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_108.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_108.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_108.Location = New System.Drawing.Point(0, 0)
        Me._LabelCil_108.Name = "_LabelCil_108"
        Me._LabelCil_108.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_108.Size = New System.Drawing.Size(159, 17)
        Me._LabelCil_108.TabIndex = 208
        Me._LabelCil_108.Text = "Number of load conditions"
        '
        '_TextCil_52
        '
        Me._TextCil_52.AcceptsReturn = True
        Me._TextCil_52.AutoSize = False
        Me._TextCil_52.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_52.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_52.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_52.Location = New System.Drawing.Point(162, 216)
        Me._TextCil_52.MaxLength = 0
        Me._TextCil_52.Name = "_TextCil_52"
        Me._TextCil_52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_52.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_52.TabIndex = 144
        Me._TextCil_52.Text = ""
        '
        '_Check1_7
        '
        Me._Check1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_7.Checked = True
        Me._Check1_7.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_7.Location = New System.Drawing.Point(144, 180)
        Me._Check1_7.Name = "_Check1_7"
        Me._Check1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_7.Size = New System.Drawing.Size(121, 19)
        Me._Check1_7.TabIndex = 72
        Me._Check1_7.Text = "Vacuum Sell Side"
        '
        '_Check1_6
        '
        Me._Check1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_6.Checked = True
        Me._Check1_6.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_6.Location = New System.Drawing.Point(9, 180)
        Me._Check1_6.Name = "_Check1_6"
        Me._Check1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_6.Size = New System.Drawing.Size(163, 19)
        Me._Check1_6.TabIndex = 71
        Me._Check1_6.Text = "Vacuum Tube Side"
        '
        '_Check1_5
        '
        Me._Check1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_5.Checked = True
        Me._Check1_5.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_5.Location = New System.Drawing.Point(9, 198)
        Me._Check1_5.Name = "_Check1_5"
        Me._Check1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_5.Size = New System.Drawing.Size(163, 19)
        Me._Check1_5.TabIndex = 70
        Me._Check1_5.Text = "Design under diff.pressure"
        '
        '_TextCil_31
        '
        Me._TextCil_31.AcceptsReturn = True
        Me._TextCil_31.AutoSize = False
        Me._TextCil_31.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_31.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_31.Location = New System.Drawing.Point(162, 162)
        Me._TextCil_31.MaxLength = 0
        Me._TextCil_31.Name = "_TextCil_31"
        Me._TextCil_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_31.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_31.TabIndex = 68
        Me._TextCil_31.Text = ""
        '
        '_TextCil_30
        '
        Me._TextCil_30.AcceptsReturn = True
        Me._TextCil_30.AutoSize = False
        Me._TextCil_30.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_30.Location = New System.Drawing.Point(162, 144)
        Me._TextCil_30.MaxLength = 0
        Me._TextCil_30.Name = "_TextCil_30"
        Me._TextCil_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_30.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_30.TabIndex = 66
        Me._TextCil_30.Text = ""
        '
        '_TextCil_29
        '
        Me._TextCil_29.AcceptsReturn = True
        Me._TextCil_29.AutoSize = False
        Me._TextCil_29.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_29.Location = New System.Drawing.Point(162, 126)
        Me._TextCil_29.MaxLength = 0
        Me._TextCil_29.Name = "_TextCil_29"
        Me._TextCil_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_29.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_29.TabIndex = 64
        Me._TextCil_29.Text = ""
        '
        '_TextCil_28
        '
        Me._TextCil_28.AcceptsReturn = True
        Me._TextCil_28.AutoSize = False
        Me._TextCil_28.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_28.Location = New System.Drawing.Point(162, 72)
        Me._TextCil_28.MaxLength = 0
        Me._TextCil_28.Name = "_TextCil_28"
        Me._TextCil_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_28.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_28.TabIndex = 62
        Me._TextCil_28.Text = ""
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_10.Location = New System.Drawing.Point(162, 54)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_10.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_10.TabIndex = 60
        Me._TextCil_10.Text = ""
        '
        '_TextCil_25
        '
        Me._TextCil_25.AcceptsReturn = True
        Me._TextCil_25.AutoSize = False
        Me._TextCil_25.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_25.Location = New System.Drawing.Point(162, 108)
        Me._TextCil_25.MaxLength = 0
        Me._TextCil_25.Name = "_TextCil_25"
        Me._TextCil_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_25.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_25.TabIndex = 58
        Me._TextCil_25.Text = ""
        '
        '_TextCil_24
        '
        Me._TextCil_24.AcceptsReturn = True
        Me._TextCil_24.AutoSize = False
        Me._TextCil_24.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_24.Location = New System.Drawing.Point(162, 90)
        Me._TextCil_24.MaxLength = 0
        Me._TextCil_24.Name = "_TextCil_24"
        Me._TextCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_24.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_24.TabIndex = 56
        Me._TextCil_24.Text = ""
        '
        '_TextCil_27
        '
        Me._TextCil_27.AcceptsReturn = True
        Me._TextCil_27.AutoSize = False
        Me._TextCil_27.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_27.Location = New System.Drawing.Point(162, 36)
        Me._TextCil_27.MaxLength = 0
        Me._TextCil_27.Name = "_TextCil_27"
        Me._TextCil_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_27.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_27.TabIndex = 54
        Me._TextCil_27.Text = ""
        '
        '_TextCil_26
        '
        Me._TextCil_26.AcceptsReturn = True
        Me._TextCil_26.AutoSize = False
        Me._TextCil_26.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_26.Location = New System.Drawing.Point(162, 18)
        Me._TextCil_26.MaxLength = 0
        Me._TextCil_26.Name = "_TextCil_26"
        Me._TextCil_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_26.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_26.TabIndex = 52
        Me._TextCil_26.Text = ""
        '
        '_LabelCil_141
        '
        Me._LabelCil_141.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_141.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_141.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_141.Location = New System.Drawing.Point(9, 235)
        Me._LabelCil_141.Name = "_LabelCil_141"
        Me._LabelCil_141.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_141.Size = New System.Drawing.Size(146, 17)
        Me._LabelCil_141.TabIndex = 324
        Me._LabelCil_141.Text = "Differential pressure in H.T."
        '
        '_lblUni_91
        '
        Me._lblUni_91.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_91.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_91.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_91.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_91.Location = New System.Drawing.Point(216, 235)
        Me._lblUni_91.Name = "_lblUni_91"
        Me._lblUni_91.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_91.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_91.TabIndex = 323
        Me._lblUni_91.Text = "Label2"
        Me._lblUni_91.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_52
        '
        Me._lblUni_52.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_52.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_52.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_52.Location = New System.Drawing.Point(216, 216)
        Me._lblUni_52.Name = "_lblUni_52"
        Me._lblUni_52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_52.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_52.TabIndex = 146
        Me._lblUni_52.Text = "Label2"
        Me._lblUni_52.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_LabelCil_81
        '
        Me._LabelCil_81.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_81.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_81.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_81.Location = New System.Drawing.Point(9, 216)
        Me._LabelCil_81.Name = "_LabelCil_81"
        Me._LabelCil_81.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_81.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_81.TabIndex = 145
        Me._LabelCil_81.Text = "Differential pressure"
        '
        '_lblUni_31
        '
        Me._lblUni_31.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_31.Location = New System.Drawing.Point(216, 162)
        Me._lblUni_31.Name = "_lblUni_31"
        Me._lblUni_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_31.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_31.TabIndex = 136
        Me._lblUni_31.Text = "Label2"
        Me._lblUni_31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_30
        '
        Me._lblUni_30.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_30.Location = New System.Drawing.Point(216, 144)
        Me._lblUni_30.Name = "_lblUni_30"
        Me._lblUni_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_30.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_30.TabIndex = 135
        Me._lblUni_30.Text = "Label2"
        Me._lblUni_30.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_29
        '
        Me._lblUni_29.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_29.Location = New System.Drawing.Point(216, 126)
        Me._lblUni_29.Name = "_lblUni_29"
        Me._lblUni_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_29.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_29.TabIndex = 134
        Me._lblUni_29.Text = "Label2"
        Me._lblUni_29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_25
        '
        Me._lblUni_25.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_25.Location = New System.Drawing.Point(216, 108)
        Me._lblUni_25.Name = "_lblUni_25"
        Me._lblUni_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_25.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_25.TabIndex = 133
        Me._lblUni_25.Text = "Label2"
        Me._lblUni_25.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_24
        '
        Me._lblUni_24.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_24.Location = New System.Drawing.Point(216, 90)
        Me._lblUni_24.Name = "_lblUni_24"
        Me._lblUni_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_24.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_24.TabIndex = 132
        Me._lblUni_24.Text = "Label2"
        Me._lblUni_24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_28
        '
        Me._lblUni_28.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_28.Location = New System.Drawing.Point(216, 72)
        Me._lblUni_28.Name = "_lblUni_28"
        Me._lblUni_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_28.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_28.TabIndex = 131
        Me._lblUni_28.Text = "Label2"
        Me._lblUni_28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_10
        '
        Me._lblUni_10.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_10.Location = New System.Drawing.Point(216, 54)
        Me._lblUni_10.Name = "_lblUni_10"
        Me._lblUni_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_10.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_10.TabIndex = 130
        Me._lblUni_10.Text = "Label2"
        Me._lblUni_10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_27
        '
        Me._lblUni_27.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_27.Location = New System.Drawing.Point(216, 36)
        Me._lblUni_27.Name = "_lblUni_27"
        Me._lblUni_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_27.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_27.TabIndex = 129
        Me._lblUni_27.Text = "Label2"
        Me._lblUni_27.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblUni_26
        '
        Me._lblUni_26.BackColor = System.Drawing.Color.Yellow
        Me._lblUni_26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblUni_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUni_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUni_26.Location = New System.Drawing.Point(216, 18)
        Me._lblUni_26.Name = "_lblUni_26"
        Me._lblUni_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUni_26.Size = New System.Drawing.Size(37, 19)
        Me._lblUni_26.TabIndex = 128
        Me._lblUni_26.Text = "Label2"
        Me._lblUni_26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_LabelCil_37
        '
        Me._LabelCil_37.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_37.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_37.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_37.Location = New System.Drawing.Point(9, 162)
        Me._LabelCil_37.Name = "_LabelCil_37"
        Me._LabelCil_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_37.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_37.TabIndex = 69
        Me._LabelCil_37.Text = "Design temperature"
        '
        '_LabelCil_36
        '
        Me._LabelCil_36.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_36.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_36.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_36.Location = New System.Drawing.Point(9, 144)
        Me._LabelCil_36.Name = "_LabelCil_36"
        Me._LabelCil_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_36.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_36.TabIndex = 67
        Me._LabelCil_36.Text = "H.T. pressure S.S."
        '
        '_LabelCil_35
        '
        Me._LabelCil_35.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_35.Location = New System.Drawing.Point(9, 126)
        Me._LabelCil_35.Name = "_LabelCil_35"
        Me._LabelCil_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_35.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_35.TabIndex = 65
        Me._LabelCil_35.Text = "H.T. pressure T.S."
        '
        '_LabelCil_34
        '
        Me._LabelCil_34.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_34.Location = New System.Drawing.Point(9, 72)
        Me._LabelCil_34.Name = "_LabelCil_34"
        Me._LabelCil_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_34.Size = New System.Drawing.Size(118, 19)
        Me._LabelCil_34.TabIndex = 63
        Me._LabelCil_34.Text = "Hydrostatc depth S.S."
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_12.Location = New System.Drawing.Point(9, 54)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_12.Size = New System.Drawing.Size(118, 19)
        Me._LabelCil_12.TabIndex = 61
        Me._LabelCil_12.Text = "Hydrostatc depth T.S."
        '
        '_LabelCil_31
        '
        Me._LabelCil_31.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_31.Location = New System.Drawing.Point(9, 108)
        Me._LabelCil_31.Name = "_LabelCil_31"
        Me._LabelCil_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_31.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_31.TabIndex = 59
        Me._LabelCil_31.Text = "Corrosion S.S."
        '
        '_LabelCil_30
        '
        Me._LabelCil_30.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_30.Location = New System.Drawing.Point(9, 90)
        Me._LabelCil_30.Name = "_LabelCil_30"
        Me._LabelCil_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_30.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_30.TabIndex = 57
        Me._LabelCil_30.Text = "Corrosion T.S."
        '
        '_LabelCil_33
        '
        Me._LabelCil_33.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_33.Location = New System.Drawing.Point(9, 36)
        Me._LabelCil_33.Name = "_LabelCil_33"
        Me._LabelCil_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_33.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_33.TabIndex = 55
        Me._LabelCil_33.Text = "Design pressure S.S."
        '
        '_LabelCil_32
        '
        Me._LabelCil_32.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_32.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_32.Name = "_LabelCil_32"
        Me._LabelCil_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_32.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_32.TabIndex = 53
        Me._LabelCil_32.Text = "Design pressure T.S."
        '
        '_Framesf_1
        '
        Me._Framesf_1.BackColor = System.Drawing.SystemColors.Control
        Me._Framesf_1.Controls.Add(Me.cmbMat)
        Me._Framesf_1.Controls.Add(Me.chkAgganciato1)
        Me._Framesf_1.Controls.Add(Me.Check2)
        Me._Framesf_1.Controls.Add(Me._TextCil_114)
        Me._Framesf_1.Controls.Add(Me._TextCil_113)
        Me._Framesf_1.Controls.Add(Me._cmbCil_6)
        Me._Framesf_1.Controls.Add(Me._cmdCil_7)
        Me._Framesf_1.Controls.Add(Me._TextCil_53)
        Me._Framesf_1.Controls.Add(Me._cmbCil_0)
        Me._Framesf_1.Controls.Add(Me._TextCil_23)
        Me._Framesf_1.Controls.Add(Me._TextCil_19)
        Me._Framesf_1.Controls.Add(Me._TextCil_18)
        Me._Framesf_1.Controls.Add(Me._TextCil_17)
        Me._Framesf_1.Controls.Add(Me._TextCil_14)
        Me._Framesf_1.Controls.Add(Me._TextCil_8)
        Me._Framesf_1.Controls.Add(Me._cmdCil_0)
        Me._Framesf_1.Controls.Add(Me._LabelCil_150)
        Me._Framesf_1.Controls.Add(Me._LabelCil_149)
        Me._Framesf_1.Controls.Add(Me._LabelCil_85)
        Me._Framesf_1.Controls.Add(Me._LabelCil_82)
        Me._Framesf_1.Controls.Add(Me._LabelCil_0)
        Me._Framesf_1.Controls.Add(Me._LabelCil_29)
        Me._Framesf_1.Controls.Add(Me._LabelCil_24)
        Me._Framesf_1.Controls.Add(Me._LabelCil_23)
        Me._Framesf_1.Controls.Add(Me._LabelCil_22)
        Me._Framesf_1.Controls.Add(Me._LabelCil_19)
        Me._Framesf_1.Controls.Add(Me._LabelCil_14)
        Me._Framesf_1.Controls.Add(Me._LabelCil_1)
        Me._Framesf_1.ForeColor = System.Drawing.Color.Blue
        Me._Framesf_1.Location = New System.Drawing.Point(0, 336)
        Me._Framesf_1.Name = "_Framesf_1"
        Me._Framesf_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Framesf_1.Size = New System.Drawing.Size(352, 190)
        Me._Framesf_1.TabIndex = 110
        Me._Framesf_1.TabStop = False
        Me._Framesf_1.Text = "Dati Piastra Tubiera"
        '
        'cmbMat
        '
        Me.cmbMat.Location = New System.Drawing.Point(96, 52)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(152, 21)
        Me.cmbMat.TabIndex = 346
        Me.cmbMat.Text = "ComboBox1"
        '
        'Check2
        '
        Me.Check2.BackColor = System.Drawing.SystemColors.Control
        Me.Check2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check2.Location = New System.Drawing.Point(8, 32)
        Me.Check2.Name = "Check2"
        Me.Check2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check2.Size = New System.Drawing.Size(241, 17)
        Me.Check2.TabIndex = 232
        Me.Check2.Text = "P.T. avvitata sul fondo della cassa"
        Me.Check2.Visible = False
        '
        '_TextCil_114
        '
        Me._TextCil_114.AcceptsReturn = True
        Me._TextCil_114.AutoSize = False
        Me._TextCil_114.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_114.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_114.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_114.Location = New System.Drawing.Point(126, 160)
        Me._TextCil_114.MaxLength = 0
        Me._TextCil_114.Name = "_TextCil_114"
        Me._TextCil_114.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_114.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_114.TabIndex = 342
        Me._TextCil_114.Text = ""
        '
        '_TextCil_113
        '
        Me._TextCil_113.AcceptsReturn = True
        Me._TextCil_113.AutoSize = False
        Me._TextCil_113.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_113.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_113.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_113.Location = New System.Drawing.Point(297, 160)
        Me._TextCil_113.MaxLength = 0
        Me._TextCil_113.Name = "_TextCil_113"
        Me._TextCil_113.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_113.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_113.TabIndex = 341
        Me._TextCil_113.Text = ""
        '
        '_cmbCil_6
        '
        Me._cmbCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_6.Location = New System.Drawing.Point(144, 32)
        Me._cmbCil_6.Name = "_cmbCil_6"
        Me._cmbCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_6.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_6.TabIndex = 166
        Me._cmbCil_6.Text = "cmbCil"
        '
        '_cmdCil_7
        '
        Me._cmdCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_7.Image = CType(resources.GetObject("_cmdCil_7.Image"), System.Drawing.Image)
        Me._cmdCil_7.Location = New System.Drawing.Point(248, 72)
        Me._cmdCil_7.Name = "_cmdCil_7"
        Me._cmdCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_7.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_7.TabIndex = 164
        Me._cmdCil_7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_53
        '
        Me._TextCil_53.AcceptsReturn = True
        Me._TextCil_53.AutoSize = False
        Me._TextCil_53.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_53.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_53.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_53.Location = New System.Drawing.Point(297, 142)
        Me._TextCil_53.MaxLength = 0
        Me._TextCil_53.Name = "_TextCil_53"
        Me._TextCil_53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_53.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_53.TabIndex = 147
        Me._TextCil_53.Text = ""
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 16)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_0.TabIndex = 119
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_TextCil_23
        '
        Me._TextCil_23.AcceptsReturn = True
        Me._TextCil_23.AutoSize = False
        Me._TextCil_23.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_23.Location = New System.Drawing.Point(126, 142)
        Me._TextCil_23.MaxLength = 0
        Me._TextCil_23.Name = "_TextCil_23"
        Me._TextCil_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_23.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_23.TabIndex = 118
        Me._TextCil_23.Text = ""
        '
        '_TextCil_19
        '
        Me._TextCil_19.AcceptsReturn = True
        Me._TextCil_19.AutoSize = False
        Me._TextCil_19.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_19.Location = New System.Drawing.Point(297, 124)
        Me._TextCil_19.MaxLength = 0
        Me._TextCil_19.Name = "_TextCil_19"
        Me._TextCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_19.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_19.TabIndex = 117
        Me._TextCil_19.Text = ""
        '
        '_TextCil_18
        '
        Me._TextCil_18.AcceptsReturn = True
        Me._TextCil_18.AutoSize = False
        Me._TextCil_18.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_18.Location = New System.Drawing.Point(297, 107)
        Me._TextCil_18.MaxLength = 0
        Me._TextCil_18.Name = "_TextCil_18"
        Me._TextCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_18.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_18.TabIndex = 116
        Me._TextCil_18.Text = ""
        '
        '_TextCil_17
        '
        Me._TextCil_17.AcceptsReturn = True
        Me._TextCil_17.AutoSize = False
        Me._TextCil_17.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_17.Location = New System.Drawing.Point(126, 107)
        Me._TextCil_17.MaxLength = 0
        Me._TextCil_17.Name = "_TextCil_17"
        Me._TextCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_17.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_17.TabIndex = 115
        Me._TextCil_17.Text = ""
        '
        '_TextCil_14
        '
        Me._TextCil_14.AcceptsReturn = True
        Me._TextCil_14.AutoSize = False
        Me._TextCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_14.Location = New System.Drawing.Point(176, 88)
        Me._TextCil_14.MaxLength = 0
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_14.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_14.TabIndex = 114
        Me._TextCil_14.Text = "Text1"
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_8.Location = New System.Drawing.Point(176, 72)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 113
        Me._TextCil_8.Text = "Text1"
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(248, 52)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 112
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_150
        '
        Me._LabelCil_150.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_150.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_150.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_150.Location = New System.Drawing.Point(9, 162)
        Me._LabelCil_150.Name = "_LabelCil_150"
        Me._LabelCil_150.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_150.Size = New System.Drawing.Size(120, 17)
        Me._LabelCil_150.TabIndex = 344
        Me._LabelCil_150.Text = "Prof. cava circonf. T.S."
        '
        '_LabelCil_149
        '
        Me._LabelCil_149.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_149.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_149.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_149.Location = New System.Drawing.Point(180, 160)
        Me._LabelCil_149.Name = "_LabelCil_149"
        Me._LabelCil_149.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_149.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_149.TabIndex = 343
        Me._LabelCil_149.Text = "Prof. cava circonf. S.S."
        '
        '_LabelCil_85
        '
        Me._LabelCil_85.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_85.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_85.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_85.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_85.Name = "_LabelCil_85"
        Me._LabelCil_85.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_85.Size = New System.Drawing.Size(128, 20)
        Me._LabelCil_85.TabIndex = 167
        Me._LabelCil_85.Text = "Member type"
        '
        '_LabelCil_82
        '
        Me._LabelCil_82.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_82.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_82.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_82.Location = New System.Drawing.Point(180, 144)
        Me._LabelCil_82.Name = "_LabelCil_82"
        Me._LabelCil_82.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_82.Size = New System.Drawing.Size(128, 17)
        Me._LabelCil_82.TabIndex = 148
        Me._LabelCil_82.Text = "Prof. cava per setti S.S."
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(9, 16)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_0.TabIndex = 127
        Me._LabelCil_0.Text = "Member identification"
        '
        '_LabelCil_29
        '
        Me._LabelCil_29.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_29.Location = New System.Drawing.Point(9, 144)
        Me._LabelCil_29.Name = "_LabelCil_29"
        Me._LabelCil_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_29.Size = New System.Drawing.Size(127, 17)
        Me._LabelCil_29.TabIndex = 126
        Me._LabelCil_29.Text = "Prof. cava per setti T.S."
        '
        '_LabelCil_24
        '
        Me._LabelCil_24.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_24.Location = New System.Drawing.Point(180, 124)
        Me._LabelCil_24.Name = "_LabelCil_24"
        Me._LabelCil_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_24.Size = New System.Drawing.Size(132, 17)
        Me._LabelCil_24.TabIndex = 125
        Me._LabelCil_24.Tag = "kLength"
        Me._LabelCil_24.Text = "Sp. estensione"
        '
        '_LabelCil_23
        '
        Me._LabelCil_23.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_23.Location = New System.Drawing.Point(180, 107)
        Me._LabelCil_23.Name = "_LabelCil_23"
        Me._LabelCil_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_23.Size = New System.Drawing.Size(132, 17)
        Me._LabelCil_23.TabIndex = 124
        Me._LabelCil_23.Tag = "kLength"
        Me._LabelCil_23.Text = "Spessore piastra"
        '
        '_LabelCil_22
        '
        Me._LabelCil_22.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_22.Location = New System.Drawing.Point(9, 107)
        Me._LabelCil_22.Name = "_LabelCil_22"
        Me._LabelCil_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_22.Size = New System.Drawing.Size(115, 17)
        Me._LabelCil_22.TabIndex = 123
        Me._LabelCil_22.Tag = "kLength"
        Me._LabelCil_22.Text = "D. est. piastra"
        '
        '_LabelCil_19
        '
        Me._LabelCil_19.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_19.Location = New System.Drawing.Point(9, 88)
        Me._LabelCil_19.Name = "_LabelCil_19"
        Me._LabelCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_19.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_19.TabIndex = 122
        Me._LabelCil_19.Tag = "kPress"
        Me._LabelCil_19.Text = "Allowable stress @ temp"
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(9, 72)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_14.TabIndex = 121
        Me._LabelCil_14.Tag = "kPress"
        Me._LabelCil_14.Text = "Allowable stress @ room"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_1, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_1, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_1.Location = New System.Drawing.Point(9, 52)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_1, True)
        Me._LabelCil_1.Size = New System.Drawing.Size(172, 20)
        Me._LabelCil_1.TabIndex = 120
        Me._LabelCil_1.Text = "Member Material"
        '
        '_Frames_4
        '
        Me._Frames_4.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_4.Controls.Add(Me.cmbMatSlLM)
        Me._Frames_4.Controls.Add(Me._cmdCil_221)
        Me._Frames_4.Controls.Add(Me._List2_121)
        Me._Frames_4.Controls.Add(Me._cmbCil_121)
        Me._Frames_4.Controls.Add(Me._TextCil_123)
        Me._Frames_4.Controls.Add(Me._TextCil_122)
        Me._Frames_4.Controls.Add(Me._LabelCil_221)
        Me._Frames_4.Controls.Add(Me._LabelCil_80)
        Me._Frames_4.Controls.Add(Me._LabelCil_79)
        Me._Frames_4.Controls.Add(Me._LabelCil_78)
        Me._Frames_4.ForeColor = System.Drawing.Color.Blue
        Me._Frames_4.Location = New System.Drawing.Point(360, 72)
        Me._Frames_4.Name = "_Frames_4"
        Me._Frames_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_4.Size = New System.Drawing.Size(352, 316)
        Me._Frames_4.TabIndex = 104
        Me._Frames_4.TabStop = False
        Me._Frames_4.Text = "Dati saldatura L.M."
        '
        'cmbMatSlLM
        '
        Me.cmbMatSlLM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatSlLM.Location = New System.Drawing.Point(152, 40)
        Me.cmbMatSlLM.Name = "cmbMatSlLM"
        Me.cmbMatSlLM.Size = New System.Drawing.Size(168, 21)
        Me.cmbMatSlLM.TabIndex = 256
        '
        '_cmdCil_221
        '
        Me._cmdCil_221.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_221.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_221.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_221.Image = CType(resources.GetObject("_cmdCil_221.Image"), System.Drawing.Image)
        Me._cmdCil_221.Location = New System.Drawing.Point(323, 40)
        Me._cmdCil_221.Name = "_cmdCil_221"
        Me._cmdCil_221.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_221.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_221.TabIndex = 253
        Me._cmdCil_221.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_List2_121
        '
        Me._List2_121.BackColor = System.Drawing.SystemColors.Window
        Me._List2_121.Cursor = System.Windows.Forms.Cursors.Default
        Me._List2_121.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List2_121.Location = New System.Drawing.Point(27, 141)
        Me._List2_121.Name = "_List2_121"
        Me._List2_121.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List2_121.Size = New System.Drawing.Size(55, 17)
        Me._List2_121.TabIndex = 162
        Me._List2_121.Visible = False
        '
        '_cmbCil_121
        '
        Me._cmbCil_121.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_121.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_121.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_121.Location = New System.Drawing.Point(152, 16)
        Me._cmbCil_121.Name = "_cmbCil_121"
        Me._cmbCil_121.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_121.Size = New System.Drawing.Size(192, 21)
        Me._cmbCil_121.TabIndex = 152
        Me._cmbCil_121.Text = "cmbCil"
        '
        '_TextCil_123
        '
        Me._TextCil_123.AcceptsReturn = True
        Me._TextCil_123.AutoSize = False
        Me._TextCil_123.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_123.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_123.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_123.Location = New System.Drawing.Point(153, 78)
        Me._TextCil_123.MaxLength = 0
        Me._TextCil_123.Name = "_TextCil_123"
        Me._TextCil_123.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_123.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_123.TabIndex = 106
        Me._TextCil_123.Text = ""
        '
        '_TextCil_122
        '
        Me._TextCil_122.AcceptsReturn = True
        Me._TextCil_122.AutoSize = False
        Me._TextCil_122.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_122.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_122.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_122.Location = New System.Drawing.Point(153, 60)
        Me._TextCil_122.MaxLength = 0
        Me._TextCil_122.Name = "_TextCil_122"
        Me._TextCil_122.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_122.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_122.TabIndex = 105
        Me._TextCil_122.Text = ""
        '
        '_LabelCil_221
        '
        Me._LabelCil_221.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_221.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_221.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_221.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_221.Name = "_LabelCil_221"
        Me._LabelCil_221.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_221.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_221.TabIndex = 255
        Me._LabelCil_221.Text = "Materiale mantello"
        '
        '_LabelCil_80
        '
        Me._LabelCil_80.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_80.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_80.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_80.Location = New System.Drawing.Point(9, 78)
        Me._LabelCil_80.Name = "_LabelCil_80"
        Me._LabelCil_80.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_80.Size = New System.Drawing.Size(135, 17)
        Me._LabelCil_80.TabIndex = 109
        Me._LabelCil_80.Tag = "kLength"
        Me._LabelCil_80.Text = "Spessore"
        '
        '_LabelCil_79
        '
        Me._LabelCil_79.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_79.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_79.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_79.Location = New System.Drawing.Point(9, 60)
        Me._LabelCil_79.Name = "_LabelCil_79"
        Me._LabelCil_79.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_79.Size = New System.Drawing.Size(127, 17)
        Me._LabelCil_79.TabIndex = 108
        Me._LabelCil_79.Tag = "kLength"
        Me._LabelCil_79.Text = "Diametro interno"
        '
        '_LabelCil_78
        '
        Me._LabelCil_78.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_78.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_78.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_78.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_78.Name = "_LabelCil_78"
        Me._LabelCil_78.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_78.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_78.TabIndex = 107
        Me._LabelCil_78.Text = "Member identification"
        '
        '_Frames_6
        '
        Me._Frames_6.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_6.Controls.Add(Me.List6)
        Me._Frames_6.Controls.Add(Me._cmbCil_15)
        Me._Frames_6.Controls.Add(Me.List5)
        Me._Frames_6.Controls.Add(Me.List4)
        Me._Frames_6.Controls.Add(Me._cmbCil_14)
        Me._Frames_6.Controls.Add(Me._cmbCil_13)
        Me._Frames_6.Controls.Add(Me._TextCil_106)
        Me._Frames_6.Controls.Add(Me._TextCil_107)
        Me._Frames_6.Controls.Add(Me.Picture1)
        Me._Frames_6.Controls.Add(Me._TextCil_93)
        Me._Frames_6.Controls.Add(Me._cmbCil_11)
        Me._Frames_6.Controls.Add(Me._LabelCil_142)
        Me._Frames_6.Controls.Add(Me._LabelCil_127)
        Me._Frames_6.Controls.Add(Me._LabelCil_126)
        Me._Frames_6.Controls.Add(Me._LabelCil_114)
        Me._Frames_6.Controls.Add(Me._LabelCil_113)
        Me._Frames_6.Controls.Add(Me._LabelCil_112)
        Me._Frames_6.Controls.Add(Me._LabelCil_111)
        Me._Frames_6.ForeColor = System.Drawing.Color.Blue
        Me._Frames_6.Location = New System.Drawing.Point(360, 1156)
        Me._Frames_6.Name = "_Frames_6"
        Me._Frames_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_6.Size = New System.Drawing.Size(352, 396)
        Me._Frames_6.TabIndex = 197
        Me._Frames_6.TabStop = False
        Me._Frames_6.Text = "Dati fondo flottante"
        '
        'List6
        '
        Me.List6.BackColor = System.Drawing.SystemColors.Window
        Me.List6.Cursor = System.Windows.Forms.Cursors.Default
        Me.List6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List6.Location = New System.Drawing.Point(144, 88)
        Me.List6.Name = "List6"
        Me.List6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List6.Size = New System.Drawing.Size(33, 17)
        Me.List6.TabIndex = 327
        Me.List6.Visible = False
        '
        '_cmbCil_15
        '
        Me._cmbCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_15.Location = New System.Drawing.Point(120, 152)
        Me._cmbCil_15.Name = "_cmbCil_15"
        Me._cmbCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_15.Size = New System.Drawing.Size(223, 21)
        Me._cmbCil_15.TabIndex = 325
        '
        'List5
        '
        Me.List5.BackColor = System.Drawing.SystemColors.Window
        Me.List5.Cursor = System.Windows.Forms.Cursors.Default
        Me.List5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List5.Location = New System.Drawing.Point(88, 88)
        Me.List5.Name = "List5"
        Me.List5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List5.Size = New System.Drawing.Size(33, 17)
        Me.List5.TabIndex = 287
        Me.List5.Visible = False
        '
        'List4
        '
        Me.List4.BackColor = System.Drawing.SystemColors.Window
        Me.List4.Cursor = System.Windows.Forms.Cursors.Default
        Me.List4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List4.Location = New System.Drawing.Point(40, 88)
        Me.List4.Name = "List4"
        Me.List4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List4.Size = New System.Drawing.Size(33, 17)
        Me.List4.TabIndex = 286
        Me.List4.Visible = False
        '
        '_cmbCil_14
        '
        Me._cmbCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_14.Location = New System.Drawing.Point(120, 104)
        Me._cmbCil_14.Name = "_cmbCil_14"
        Me._cmbCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_14.Size = New System.Drawing.Size(223, 21)
        Me._cmbCil_14.TabIndex = 285
        '
        '_cmbCil_13
        '
        Me._cmbCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_13.Location = New System.Drawing.Point(120, 40)
        Me._cmbCil_13.Name = "_cmbCil_13"
        Me._cmbCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_13.Size = New System.Drawing.Size(223, 21)
        Me._cmbCil_13.TabIndex = 284
        '
        '_TextCil_106
        '
        Me._TextCil_106.AcceptsReturn = True
        Me._TextCil_106.AutoSize = False
        Me._TextCil_106.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_106.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_106.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_106.Location = New System.Drawing.Point(133, 64)
        Me._TextCil_106.MaxLength = 0
        Me._TextCil_106.Name = "_TextCil_106"
        Me._TextCil_106.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_106.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_106.TabIndex = 280
        Me._TextCil_106.Text = ""
        '
        '_TextCil_107
        '
        Me._TextCil_107.AcceptsReturn = True
        Me._TextCil_107.AutoSize = False
        Me._TextCil_107.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_107.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_107.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_107.Location = New System.Drawing.Point(296, 64)
        Me._TextCil_107.MaxLength = 0
        Me._TextCil_107.Name = "_TextCil_107"
        Me._TextCil_107.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_107.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_107.TabIndex = 279
        Me._TextCil_107.Text = ""
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(48, 184)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(256, 200)
        Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Picture1.TabIndex = 231
        Me.Picture1.TabStop = False
        '
        '_TextCil_93
        '
        Me._TextCil_93.AcceptsReturn = True
        Me._TextCil_93.AutoSize = False
        Me._TextCil_93.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_93.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_93.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_93.Location = New System.Drawing.Point(296, 128)
        Me._TextCil_93.MaxLength = 0
        Me._TextCil_93.Name = "_TextCil_93"
        Me._TextCil_93.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_93.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_93.TabIndex = 229
        Me._TextCil_93.Text = ""
        '
        '_cmbCil_11
        '
        Me._cmbCil_11.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_11.Location = New System.Drawing.Point(88, 16)
        Me._cmbCil_11.Name = "_cmbCil_11"
        Me._cmbCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_11.Size = New System.Drawing.Size(255, 21)
        Me._cmbCil_11.TabIndex = 225
        Me._cmbCil_11.Text = "cmbCil"
        '
        '_LabelCil_142
        '
        Me._LabelCil_142.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_142.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_142.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_142.Location = New System.Drawing.Point(8, 152)
        Me._LabelCil_142.Name = "_LabelCil_142"
        Me._LabelCil_142.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_142.Size = New System.Drawing.Size(111, 19)
        Me._LabelCil_142.TabIndex = 326
        Me._LabelCil_142.Text = "Split Ring"
        '
        '_LabelCil_127
        '
        Me._LabelCil_127.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_127.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_127.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_127.Location = New System.Drawing.Point(8, 64)
        Me._LabelCil_127.Name = "_LabelCil_127"
        Me._LabelCil_127.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_127.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_127.TabIndex = 282
        Me._LabelCil_127.Tag = "kLength"
        Me._LabelCil_127.Text = "Head diameter"
        '
        '_LabelCil_126
        '
        Me._LabelCil_126.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_126.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_126.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_126.Location = New System.Drawing.Point(184, 64)
        Me._LabelCil_126.Name = "_LabelCil_126"
        Me._LabelCil_126.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_126.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_126.TabIndex = 281
        Me._LabelCil_126.Tag = "kLength"
        Me._LabelCil_126.Text = "Head thickness"
        '
        '_LabelCil_114
        '
        Me._LabelCil_114.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_114.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_114.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_114.Location = New System.Drawing.Point(8, 128)
        Me._LabelCil_114.Name = "_LabelCil_114"
        Me._LabelCil_114.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_114.Size = New System.Drawing.Size(281, 17)
        Me._LabelCil_114.TabIndex = 230
        Me._LabelCil_114.Tag = "kLength"
        Me._LabelCil_114.Text = "Distanza assiale centro anello/bordo fondo (hr)"
        '
        '_LabelCil_113
        '
        Me._LabelCil_113.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_113.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_113.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_113.Location = New System.Drawing.Point(8, 104)
        Me._LabelCil_113.Name = "_LabelCil_113"
        Me._LabelCil_113.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_113.Size = New System.Drawing.Size(111, 19)
        Me._LabelCil_113.TabIndex = 228
        Me._LabelCil_113.Text = "Flange identification"
        '
        '_LabelCil_112
        '
        Me._LabelCil_112.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_112.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_112.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_112.Location = New System.Drawing.Point(8, 40)
        Me._LabelCil_112.Name = "_LabelCil_112"
        Me._LabelCil_112.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_112.Size = New System.Drawing.Size(111, 19)
        Me._LabelCil_112.TabIndex = 227
        Me._LabelCil_112.Text = "Head identification"
        '
        '_LabelCil_111
        '
        Me._LabelCil_111.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_111.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_111.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_111.Location = New System.Drawing.Point(8, 16)
        Me._LabelCil_111.Name = "_LabelCil_111"
        Me._LabelCil_111.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_111.Size = New System.Drawing.Size(79, 19)
        Me._LabelCil_111.TabIndex = 226
        Me._LabelCil_111.Text = "Member type"
        '
        '_Framesf_2
        '
        Me._Framesf_2.BackColor = System.Drawing.SystemColors.Control
        Me._Framesf_2.Controls.Add(Me.cmbMat2)
        Me._Framesf_2.Controls.Add(Me.chkAgganciato2)
        Me._Framesf_2.Controls.Add(Me._TextCil_112)
        Me._Framesf_2.Controls.Add(Me._TextCil_111)
        Me._Framesf_2.Controls.Add(Me._cmdCil_11)
        Me._Framesf_2.Controls.Add(Me._TextCil_101)
        Me._Framesf_2.Controls.Add(Me._cmdCil_9)
        Me._Framesf_2.Controls.Add(Me._TextCil_61)
        Me._Framesf_2.Controls.Add(Me._TextCil_60)
        Me._Framesf_2.Controls.Add(Me._TextCil_59)
        Me._Framesf_2.Controls.Add(Me._TextCil_58)
        Me._Framesf_2.Controls.Add(Me._TextCil_57)
        Me._Framesf_2.Controls.Add(Me._TextCil_56)
        Me._Framesf_2.Controls.Add(Me._cmbCil_8)
        Me._Framesf_2.Controls.Add(Me._TextCil_55)
        Me._Framesf_2.Controls.Add(Me._cmdCil_8)
        Me._Framesf_2.Controls.Add(Me._cmbCil_7)
        Me._Framesf_2.Controls.Add(Me._LabelCil_148)
        Me._Framesf_2.Controls.Add(Me._LabelCil_147)
        Me._Framesf_2.Controls.Add(Me._LabelCil_123)
        Me._Framesf_2.Controls.Add(Me._LabelCil_98)
        Me._Framesf_2.Controls.Add(Me._LabelCil_94)
        Me._Framesf_2.Controls.Add(Me._LabelCil_93)
        Me._Framesf_2.Controls.Add(Me._LabelCil_92)
        Me._Framesf_2.Controls.Add(Me._LabelCil_91)
        Me._Framesf_2.Controls.Add(Me._LabelCil_90)
        Me._Framesf_2.Controls.Add(Me._LabelCil_89)
        Me._Framesf_2.Controls.Add(Me._LabelCil_88)
        Me._Framesf_2.Controls.Add(Me._LabelCil_87)
        Me._Framesf_2.Controls.Add(Me._LabelCil_86)
        Me._Framesf_2.ForeColor = System.Drawing.Color.Blue
        Me._Framesf_2.Location = New System.Drawing.Point(0, 336)
        Me._Framesf_2.Name = "_Framesf_2"
        Me._Framesf_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Framesf_2.Size = New System.Drawing.Size(352, 190)
        Me._Framesf_2.TabIndex = 168
        Me._Framesf_2.TabStop = False
        Me._Framesf_2.Text = "Dati Piastra Tubiera"
        '
        'cmbMat2
        '
        Me.cmbMat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat2.Location = New System.Drawing.Point(104, 52)
        Me.cmbMat2.Name = "cmbMat2"
        Me.cmbMat2.Size = New System.Drawing.Size(144, 21)
        Me.cmbMat2.TabIndex = 342
        '
        '_TextCil_112
        '
        Me._TextCil_112.AcceptsReturn = True
        Me._TextCil_112.AutoSize = False
        Me._TextCil_112.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_112.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_112.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_112.Location = New System.Drawing.Point(296, 160)
        Me._TextCil_112.MaxLength = 0
        Me._TextCil_112.Name = "_TextCil_112"
        Me._TextCil_112.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_112.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_112.TabIndex = 338
        Me._TextCil_112.Text = ""
        '
        '_TextCil_111
        '
        Me._TextCil_111.AcceptsReturn = True
        Me._TextCil_111.AutoSize = False
        Me._TextCil_111.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_111.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_111.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_111.Location = New System.Drawing.Point(127, 160)
        Me._TextCil_111.MaxLength = 0
        Me._TextCil_111.Name = "_TextCil_111"
        Me._TextCil_111.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_111.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_111.TabIndex = 337
        Me._TextCil_111.Text = ""
        '
        '_cmdCil_9
        '
        Me._cmdCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_9, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_9, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_9.Image = CType(resources.GetObject("_cmdCil_9.Image"), System.Drawing.Image)
        Me._cmdCil_9.Location = New System.Drawing.Point(248, 52)
        Me._cmdCil_9.Name = "_cmdCil_9"
        Me._cmdCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_9, True)
        Me._cmdCil_9.Size = New System.Drawing.Size(19, 20)
        Me._cmdCil_9.TabIndex = 179
        Me._cmdCil_9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_61
        '
        Me._TextCil_61.AcceptsReturn = True
        Me._TextCil_61.AutoSize = False
        Me._TextCil_61.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_61.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_61.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_61.Location = New System.Drawing.Point(176, 72)
        Me._TextCil_61.MaxLength = 0
        Me._TextCil_61.Name = "_TextCil_61"
        Me._TextCil_61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_61.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_61.TabIndex = 178
        Me._TextCil_61.Text = "Text1"
        '
        '_TextCil_60
        '
        Me._TextCil_60.AcceptsReturn = True
        Me._TextCil_60.AutoSize = False
        Me._TextCil_60.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_60.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_60.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_60.Location = New System.Drawing.Point(176, 88)
        Me._TextCil_60.MaxLength = 0
        Me._TextCil_60.Name = "_TextCil_60"
        Me._TextCil_60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_60.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_60.TabIndex = 177
        Me._TextCil_60.Text = "Text1"
        '
        '_TextCil_59
        '
        Me._TextCil_59.AcceptsReturn = True
        Me._TextCil_59.AutoSize = False
        Me._TextCil_59.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_59.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_59.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_59.Location = New System.Drawing.Point(128, 107)
        Me._TextCil_59.MaxLength = 0
        Me._TextCil_59.Name = "_TextCil_59"
        Me._TextCil_59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_59.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_59.TabIndex = 176
        Me._TextCil_59.Text = ""
        '
        '_TextCil_58
        '
        Me._TextCil_58.AcceptsReturn = True
        Me._TextCil_58.AutoSize = False
        Me._TextCil_58.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_58.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_58.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_58.Location = New System.Drawing.Point(297, 107)
        Me._TextCil_58.MaxLength = 0
        Me._TextCil_58.Name = "_TextCil_58"
        Me._TextCil_58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_58.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_58.TabIndex = 175
        Me._TextCil_58.Text = ""
        '
        '_TextCil_57
        '
        Me._TextCil_57.AcceptsReturn = True
        Me._TextCil_57.AutoSize = False
        Me._TextCil_57.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_57.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_57.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_57.Location = New System.Drawing.Point(297, 124)
        Me._TextCil_57.MaxLength = 0
        Me._TextCil_57.Name = "_TextCil_57"
        Me._TextCil_57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_57.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_57.TabIndex = 174
        Me._TextCil_57.Text = ""
        '
        '_TextCil_56
        '
        Me._TextCil_56.AcceptsReturn = True
        Me._TextCil_56.AutoSize = False
        Me._TextCil_56.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_56.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_56.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_56.Location = New System.Drawing.Point(128, 142)
        Me._TextCil_56.MaxLength = 0
        Me._TextCil_56.Name = "_TextCil_56"
        Me._TextCil_56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_56.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_56.TabIndex = 173
        Me._TextCil_56.Text = ""
        '
        '_cmbCil_8
        '
        Me._cmbCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_8.Location = New System.Drawing.Point(144, 16)
        Me._cmbCil_8.Name = "_cmbCil_8"
        Me._cmbCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_8.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_8.TabIndex = 172
        Me._cmbCil_8.Text = "cmbCil"
        '
        '_TextCil_55
        '
        Me._TextCil_55.AcceptsReturn = True
        Me._TextCil_55.AutoSize = False
        Me._TextCil_55.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_55.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_55.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_55.Location = New System.Drawing.Point(296, 142)
        Me._TextCil_55.MaxLength = 0
        Me._TextCil_55.Name = "_TextCil_55"
        Me._TextCil_55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_55.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_55.TabIndex = 171
        Me._TextCil_55.Text = ""
        '
        '_cmdCil_8
        '
        Me._cmdCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_8.Image = CType(resources.GetObject("_cmdCil_8.Image"), System.Drawing.Image)
        Me._cmdCil_8.Location = New System.Drawing.Point(248, 72)
        Me._cmdCil_8.Name = "_cmdCil_8"
        Me._cmdCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_8.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_8.TabIndex = 170
        Me._cmdCil_8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmbCil_7
        '
        Me._cmbCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_7.Location = New System.Drawing.Point(144, 32)
        Me._cmbCil_7.Name = "_cmbCil_7"
        Me._cmbCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_7.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_7.TabIndex = 169
        Me._cmbCil_7.Text = "cmbCil"
        '
        '_LabelCil_148
        '
        Me._LabelCil_148.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_148.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_148.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_148.Location = New System.Drawing.Point(180, 162)
        Me._LabelCil_148.Name = "_LabelCil_148"
        Me._LabelCil_148.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_148.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_148.TabIndex = 340
        Me._LabelCil_148.Text = "Prof. cava circonf. S.S."
        '
        '_LabelCil_147
        '
        Me._LabelCil_147.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_147.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_147.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_147.Location = New System.Drawing.Point(9, 162)
        Me._LabelCil_147.Name = "_LabelCil_147"
        Me._LabelCil_147.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_147.Size = New System.Drawing.Size(120, 17)
        Me._LabelCil_147.TabIndex = 339
        Me._LabelCil_147.Text = "Prof. cava circonf. T.S."
        '
        '_LabelCil_98
        '
        Me._LabelCil_98.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_98.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_98.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_98, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_98, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_98.Location = New System.Drawing.Point(9, 52)
        Me._LabelCil_98.Name = "_LabelCil_98"
        Me._LabelCil_98.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_98, True)
        Me._LabelCil_98.Size = New System.Drawing.Size(172, 20)
        Me._LabelCil_98.TabIndex = 190
        Me._LabelCil_98.Text = "Member Material"
        '
        '_LabelCil_94
        '
        Me._LabelCil_94.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_94.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_94.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_94.Location = New System.Drawing.Point(9, 71)
        Me._LabelCil_94.Name = "_LabelCil_94"
        Me._LabelCil_94.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_94.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_94.TabIndex = 189
        Me._LabelCil_94.Tag = "kPress"
        Me._LabelCil_94.Text = "Allowable stress @ room"
        '
        '_LabelCil_93
        '
        Me._LabelCil_93.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_93.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_93.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_93.Location = New System.Drawing.Point(9, 88)
        Me._LabelCil_93.Name = "_LabelCil_93"
        Me._LabelCil_93.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_93.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_93.TabIndex = 188
        Me._LabelCil_93.Tag = "kPress"
        Me._LabelCil_93.Text = "Allowable stress @ temp"
        '
        '_LabelCil_92
        '
        Me._LabelCil_92.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_92.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_92.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_92.Location = New System.Drawing.Point(9, 107)
        Me._LabelCil_92.Name = "_LabelCil_92"
        Me._LabelCil_92.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_92.Size = New System.Drawing.Size(135, 17)
        Me._LabelCil_92.TabIndex = 187
        Me._LabelCil_92.Tag = "kLength"
        Me._LabelCil_92.Text = "D. est.  piastra"
        '
        '_LabelCil_91
        '
        Me._LabelCil_91.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_91.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_91.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_91.Location = New System.Drawing.Point(180, 107)
        Me._LabelCil_91.Name = "_LabelCil_91"
        Me._LabelCil_91.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_91.Size = New System.Drawing.Size(124, 17)
        Me._LabelCil_91.TabIndex = 186
        Me._LabelCil_91.Tag = "kLength"
        Me._LabelCil_91.Text = "Spessore piastra"
        '
        '_LabelCil_90
        '
        Me._LabelCil_90.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_90.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_90.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_90.Location = New System.Drawing.Point(180, 124)
        Me._LabelCil_90.Name = "_LabelCil_90"
        Me._LabelCil_90.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_90.Size = New System.Drawing.Size(124, 17)
        Me._LabelCil_90.TabIndex = 185
        Me._LabelCil_90.Tag = "kLength"
        Me._LabelCil_90.Text = "Sp. estensione"
        '
        '_LabelCil_89
        '
        Me._LabelCil_89.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_89.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_89.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_89.Location = New System.Drawing.Point(9, 144)
        Me._LabelCil_89.Name = "_LabelCil_89"
        Me._LabelCil_89.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_89.Size = New System.Drawing.Size(127, 17)
        Me._LabelCil_89.TabIndex = 184
        Me._LabelCil_89.Text = "Prof. cava per setti T.S."
        '
        '_LabelCil_88
        '
        Me._LabelCil_88.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_88.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_88.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_88.Location = New System.Drawing.Point(9, 16)
        Me._LabelCil_88.Name = "_LabelCil_88"
        Me._LabelCil_88.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_88.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_88.TabIndex = 183
        Me._LabelCil_88.Text = "Member identification"
        '
        '_LabelCil_87
        '
        Me._LabelCil_87.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_87.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_87.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_87.Location = New System.Drawing.Point(180, 144)
        Me._LabelCil_87.Name = "_LabelCil_87"
        Me._LabelCil_87.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_87.Size = New System.Drawing.Size(128, 17)
        Me._LabelCil_87.TabIndex = 182
        Me._LabelCil_87.Text = "Prof. cava per setti S.S."
        '
        '_LabelCil_86
        '
        Me._LabelCil_86.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_86.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_86.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_86.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_86.Name = "_LabelCil_86"
        Me._LabelCil_86.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_86.Size = New System.Drawing.Size(128, 20)
        Me._LabelCil_86.TabIndex = 181
        Me._LabelCil_86.Text = "Member type"
        '
        '_Frames_8
        '
        Me._Frames_8.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_8.Controls.Add(Me._cmdCil_401)
        Me._Frames_8.Controls.Add(Me.chkAggancBoltLM)
        Me._Frames_8.Controls.Add(Me.cmbMatBoltLM)
        Me._Frames_8.Controls.Add(Me._TextCil_405)
        Me._Frames_8.Controls.Add(Me._TextCil_406)
        Me._Frames_8.Controls.Add(Me._TextCil_407)
        Me._Frames_8.Controls.Add(Me._TextCil_409)
        Me._Frames_8.Controls.Add(Me._TextCil_411)
        Me._Frames_8.Controls.Add(Me._TextCil_412)
        Me._Frames_8.Controls.Add(Me._cmdCil_402)
        Me._Frames_8.Controls.Add(Me._TextCil_415)
        Me._Frames_8.Controls.Add(Me._TextCil_416)
        Me._Frames_8.Controls.Add(Me._TextCil_403)
        Me._Frames_8.Controls.Add(Me._TextCil_402)
        Me._Frames_8.Controls.Add(Me._cmbCil_403)
        Me._Frames_8.Controls.Add(Me._Check1_401)
        Me._Frames_8.Controls.Add(Me._Check1_402)
        Me._Frames_8.Controls.Add(Me._cmdCil_406)
        Me._Frames_8.Controls.Add(Me._frmCollars_1)
        Me._Frames_8.Controls.Add(Me._LabelCil_140)
        Me._Frames_8.Controls.Add(Me._LabelCil_139)
        Me._Frames_8.Controls.Add(Me._LabelCil_138)
        Me._Frames_8.Controls.Add(Me._LabelCil_137)
        Me._Frames_8.Controls.Add(Me._LabelCil_136)
        Me._Frames_8.Controls.Add(Me._LabelCil_135)
        Me._Frames_8.Controls.Add(Me._LabelCil_134)
        Me._Frames_8.Controls.Add(Me._LabelCil_133)
        Me._Frames_8.Controls.Add(Me._LabelCil_132)
        Me._Frames_8.Controls.Add(Me._LabelCil_131)
        Me._Frames_8.Controls.Add(Me._LabelCil_130)
        Me._Frames_8.Controls.Add(Me._LabelCil_129)
        Me._Frames_8.ForeColor = System.Drawing.Color.Blue
        Me._Frames_8.Location = New System.Drawing.Point(360, 272)
        Me._Frames_8.Name = "_Frames_8"
        Me._Frames_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_8.Size = New System.Drawing.Size(352, 344)
        Me._Frames_8.TabIndex = 289
        Me._Frames_8.TabStop = False
        Me._Frames_8.Text = "Dati bulloni L.M."
        '
        '_cmdCil_401
        '
        Me._cmdCil_401.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_401.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_401.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_401.Image = CType(resources.GetObject("_cmdCil_401.Image"), System.Drawing.Image)
        Me._cmdCil_401.Location = New System.Drawing.Point(272, 144)
        Me._cmdCil_401.Name = "_cmdCil_401"
        Me._cmdCil_401.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_401.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_401.TabIndex = 301
        Me._cmdCil_401.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbMatBoltLM
        '
        Me.cmbMatBoltLM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatBoltLM.Location = New System.Drawing.Point(88, 144)
        Me.cmbMatBoltLM.Name = "cmbMatBoltLM"
        Me.cmbMatBoltLM.Size = New System.Drawing.Size(184, 21)
        Me.cmbMatBoltLM.TabIndex = 322
        '
        '_TextCil_405
        '
        Me._TextCil_405.AcceptsReturn = True
        Me._TextCil_405.AutoSize = False
        Me._TextCil_405.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_405.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_405.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_405.Location = New System.Drawing.Point(192, 18)
        Me._TextCil_405.MaxLength = 0
        Me._TextCil_405.Name = "_TextCil_405"
        Me._TextCil_405.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_405.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_405.TabIndex = 309
        Me._TextCil_405.Text = ""
        '
        '_TextCil_406
        '
        Me._TextCil_406.AcceptsReturn = True
        Me._TextCil_406.AutoSize = False
        Me._TextCil_406.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_406.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_406.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_406.Location = New System.Drawing.Point(192, 36)
        Me._TextCil_406.MaxLength = 0
        Me._TextCil_406.Name = "_TextCil_406"
        Me._TextCil_406.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_406.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_406.TabIndex = 308
        Me._TextCil_406.Text = ""
        '
        '_TextCil_407
        '
        Me._TextCil_407.AcceptsReturn = True
        Me._TextCil_407.AutoSize = False
        Me._TextCil_407.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_407.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_407.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_407.Location = New System.Drawing.Point(192, 54)
        Me._TextCil_407.MaxLength = 0
        Me._TextCil_407.Name = "_TextCil_407"
        Me._TextCil_407.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_407.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_407.TabIndex = 307
        Me._TextCil_407.Text = ""
        '
        '_TextCil_409
        '
        Me._TextCil_409.AcceptsReturn = True
        Me._TextCil_409.AutoSize = False
        Me._TextCil_409.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_409.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_409.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_409.Location = New System.Drawing.Point(192, 72)
        Me._TextCil_409.MaxLength = 0
        Me._TextCil_409.Name = "_TextCil_409"
        Me._TextCil_409.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_409.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_409.TabIndex = 306
        Me._TextCil_409.Text = ""
        '
        '_TextCil_411
        '
        Me._TextCil_411.AcceptsReturn = True
        Me._TextCil_411.AutoSize = False
        Me._TextCil_411.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_411.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_411.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_411.Location = New System.Drawing.Point(192, 90)
        Me._TextCil_411.MaxLength = 0
        Me._TextCil_411.Name = "_TextCil_411"
        Me._TextCil_411.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_411.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_411.TabIndex = 305
        Me._TextCil_411.Text = ""
        '
        '_TextCil_412
        '
        Me._TextCil_412.AcceptsReturn = True
        Me._TextCil_412.AutoSize = False
        Me._TextCil_412.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_412.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_412.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_412.Location = New System.Drawing.Point(192, 108)
        Me._TextCil_412.MaxLength = 0
        Me._TextCil_412.Name = "_TextCil_412"
        Me._TextCil_412.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_412.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_412.TabIndex = 304
        Me._TextCil_412.Text = ""
        '
        '_cmdCil_402
        '
        Me._cmdCil_402.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_402.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_402.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_402.Image = CType(resources.GetObject("_cmdCil_402.Image"), System.Drawing.Image)
        Me._cmdCil_402.Location = New System.Drawing.Point(240, 18)
        Me._cmdCil_402.Name = "_cmdCil_402"
        Me._cmdCil_402.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_402.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_402.TabIndex = 303
        Me._cmdCil_402.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_415
        '
        Me._TextCil_415.AcceptsReturn = True
        Me._TextCil_415.AutoSize = False
        Me._TextCil_415.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_415.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_415.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_415.Location = New System.Drawing.Point(193, 162)
        Me._TextCil_415.MaxLength = 0
        Me._TextCil_415.Name = "_TextCil_415"
        Me._TextCil_415.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_415.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_415.TabIndex = 300
        Me._TextCil_415.Text = ""
        '
        '_TextCil_416
        '
        Me._TextCil_416.AcceptsReturn = True
        Me._TextCil_416.AutoSize = False
        Me._TextCil_416.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_416.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_416.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_416.Location = New System.Drawing.Point(193, 181)
        Me._TextCil_416.MaxLength = 0
        Me._TextCil_416.Name = "_TextCil_416"
        Me._TextCil_416.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_416.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_416.TabIndex = 299
        Me._TextCil_416.Text = ""
        '
        '_TextCil_403
        '
        Me._TextCil_403.AcceptsReturn = True
        Me._TextCil_403.AutoSize = False
        Me._TextCil_403.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_403.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_403.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_403.Location = New System.Drawing.Point(198, 234)
        Me._TextCil_403.MaxLength = 0
        Me._TextCil_403.Name = "_TextCil_403"
        Me._TextCil_403.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_403.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_403.TabIndex = 298
        Me._TextCil_403.Text = ""
        '
        '_TextCil_402
        '
        Me._TextCil_402.AcceptsReturn = True
        Me._TextCil_402.AutoSize = False
        Me._TextCil_402.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_402.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_402.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_402.Location = New System.Drawing.Point(198, 216)
        Me._TextCil_402.MaxLength = 0
        Me._TextCil_402.Name = "_TextCil_402"
        Me._TextCil_402.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_402.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_402.TabIndex = 297
        Me._TextCil_402.Text = ""
        '
        '_cmbCil_403
        '
        Me._cmbCil_403.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_403.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_403.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_403.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_403.Location = New System.Drawing.Point(144, 198)
        Me._cmbCil_403.Name = "_cmbCil_403"
        Me._cmbCil_403.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_403.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_403.TabIndex = 296
        '
        '_Check1_401
        '
        Me._Check1_401.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_401.Checked = True
        Me._Check1_401.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_401.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_401.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_401.Location = New System.Drawing.Point(9, 252)
        Me._Check1_401.Name = "_Check1_401"
        Me._Check1_401.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_401.Size = New System.Drawing.Size(267, 19)
        Me._Check1_401.TabIndex = 295
        Me._Check1_401.Text = "Tiro bulloni differenziato PI / esercizio"
        '
        '_Check1_402
        '
        Me._Check1_402.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_402.Checked = True
        Me._Check1_402.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_402.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_402.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_402.Location = New System.Drawing.Point(9, 270)
        Me._Check1_402.Name = "_Check1_402"
        Me._Check1_402.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_402.Size = New System.Drawing.Size(267, 19)
        Me._Check1_402.TabIndex = 294
        Me._Check1_402.Text = "Controllo schiacciamento guarnizione"
        '
        '_cmdCil_406
        '
        Me._cmdCil_406.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_406.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_406.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_406.Image = CType(resources.GetObject("_cmdCil_406.Image"), System.Drawing.Image)
        Me._cmdCil_406.Location = New System.Drawing.Point(272, 162)
        Me._cmdCil_406.Name = "_cmdCil_406"
        Me._cmdCil_406.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_406.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_406.TabIndex = 293
        Me._cmdCil_406.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_frmCollars_1
        '
        Me._frmCollars_1.BackColor = System.Drawing.SystemColors.Control
        Me._frmCollars_1.Controls.Add(Me._TextCil_413)
        Me._frmCollars_1.Controls.Add(Me._LabelCil_128)
        Me._frmCollars_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmCollars_1.Location = New System.Drawing.Point(88, 296)
        Me._frmCollars_1.Name = "_frmCollars_1"
        Me._frmCollars_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmCollars_1.Size = New System.Drawing.Size(153, 41)
        Me._frmCollars_1.TabIndex = 290
        Me._frmCollars_1.TabStop = False
        Me._frmCollars_1.Text = "Collar bolts"
        '
        '_TextCil_413
        '
        Me._TextCil_413.AcceptsReturn = True
        Me._TextCil_413.AutoSize = False
        Me._TextCil_413.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_413.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_413.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_413.Location = New System.Drawing.Point(112, 16)
        Me._TextCil_413.MaxLength = 0
        Me._TextCil_413.Name = "_TextCil_413"
        Me._TextCil_413.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_413.Size = New System.Drawing.Size(30, 20)
        Me._TextCil_413.TabIndex = 291
        Me._TextCil_413.Text = ""
        '
        '_LabelCil_128
        '
        Me._LabelCil_128.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_128.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_128.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_128.Location = New System.Drawing.Point(8, 16)
        Me._LabelCil_128.Name = "_LabelCil_128"
        Me._LabelCil_128.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_128.Size = New System.Drawing.Size(115, 19)
        Me._LabelCil_128.TabIndex = 292
        Me._LabelCil_128.Text = "N° bulloni con collare"
        '
        '_LabelCil_140
        '
        Me._LabelCil_140.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_140.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_140.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_140.Location = New System.Drawing.Point(9, 18)
        Me._LabelCil_140.Name = "_LabelCil_140"
        Me._LabelCil_140.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_140.Size = New System.Drawing.Size(151, 19)
        Me._LabelCil_140.TabIndex = 321
        Me._LabelCil_140.Tag = "kLength"
        Me._LabelCil_140.Text = "Diametro nominale"
        '
        '_LabelCil_139
        '
        Me._LabelCil_139.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_139.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_139.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_139.Location = New System.Drawing.Point(9, 36)
        Me._LabelCil_139.Name = "_LabelCil_139"
        Me._LabelCil_139.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_139.Size = New System.Drawing.Size(151, 19)
        Me._LabelCil_139.TabIndex = 320
        Me._LabelCil_139.Text = "N° bulloni"
        '
        '_LabelCil_138
        '
        Me._LabelCil_138.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_138.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_138.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_138.Location = New System.Drawing.Point(9, 54)
        Me._LabelCil_138.Name = "_LabelCil_138"
        Me._LabelCil_138.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_138.Size = New System.Drawing.Size(151, 19)
        Me._LabelCil_138.TabIndex = 319
        Me._LabelCil_138.Tag = "kLength"
        Me._LabelCil_138.Text = "Diametro cerchio"
        '
        '_LabelCil_137
        '
        Me._LabelCil_137.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_137.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_137.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_137.Location = New System.Drawing.Point(9, 72)
        Me._LabelCil_137.Name = "_LabelCil_137"
        Me._LabelCil_137.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_137.Size = New System.Drawing.Size(135, 19)
        Me._LabelCil_137.TabIndex = 318
        Me._LabelCil_137.Tag = "kLength"
        Me._LabelCil_137.Text = "Sezione bullone [in2]"
        '
        '_LabelCil_136
        '
        Me._LabelCil_136.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_136.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_136.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_136.Location = New System.Drawing.Point(9, 90)
        Me._LabelCil_136.Name = "_LabelCil_136"
        Me._LabelCil_136.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_136.Size = New System.Drawing.Size(118, 19)
        Me._LabelCil_136.TabIndex = 317
        Me._LabelCil_136.Tag = "kLength"
        Me._LabelCil_136.Text = "B.S. minimo [mm]"
        '
        '_LabelCil_135
        '
        Me._LabelCil_135.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_135.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_135.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_135.Location = New System.Drawing.Point(9, 108)
        Me._LabelCil_135.Name = "_LabelCil_135"
        Me._LabelCil_135.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_135.Size = New System.Drawing.Size(151, 19)
        Me._LabelCil_135.TabIndex = 316
        Me._LabelCil_135.Tag = "kLength"
        Me._LabelCil_135.Text = "Spaziatura rad.est. [mm]"
        '
        '_LabelCil_134
        '
        Me._LabelCil_134.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_134.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_134.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_134.Location = New System.Drawing.Point(9, 144)
        Me._LabelCil_134.Name = "_LabelCil_134"
        Me._LabelCil_134.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_134.Size = New System.Drawing.Size(172, 19)
        Me._LabelCil_134.TabIndex = 315
        Me._LabelCil_134.Text = "Bolt Material"
        '
        '_LabelCil_133
        '
        Me._LabelCil_133.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_133.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_133.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_133.Location = New System.Drawing.Point(9, 163)
        Me._LabelCil_133.Name = "_LabelCil_133"
        Me._LabelCil_133.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_133.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_133.TabIndex = 314
        Me._LabelCil_133.Tag = "kPress"
        Me._LabelCil_133.Text = "Allowable stress @ room"
        '
        '_LabelCil_132
        '
        Me._LabelCil_132.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_132.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_132.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_132.Location = New System.Drawing.Point(9, 181)
        Me._LabelCil_132.Name = "_LabelCil_132"
        Me._LabelCil_132.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_132.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_132.TabIndex = 313
        Me._LabelCil_132.Tag = "kPress"
        Me._LabelCil_132.Text = "Allowable stress @ temp"
        '
        '_LabelCil_131
        '
        Me._LabelCil_131.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_131.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_131.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_131.Location = New System.Drawing.Point(9, 234)
        Me._LabelCil_131.Name = "_LabelCil_131"
        Me._LabelCil_131.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_131.Size = New System.Drawing.Size(181, 19)
        Me._LabelCil_131.TabIndex = 312
        Me._LabelCil_131.Text = "Frazione Sy bulloni in P.I."
        '
        '_LabelCil_130
        '
        Me._LabelCil_130.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_130.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_130.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_130.Location = New System.Drawing.Point(9, 216)
        Me._LabelCil_130.Name = "_LabelCil_130"
        Me._LabelCil_130.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_130.Size = New System.Drawing.Size(181, 19)
        Me._LabelCil_130.TabIndex = 311
        Me._LabelCil_130.Text = "Disuniformità tiro bulloni"
        '
        '_LabelCil_129
        '
        Me._LabelCil_129.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_129.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_129.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_129.Location = New System.Drawing.Point(9, 198)
        Me._LabelCil_129.Name = "_LabelCil_129"
        Me._LabelCil_129.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_129.Size = New System.Drawing.Size(145, 19)
        Me._LabelCil_129.TabIndex = 310
        Me._LabelCil_129.Text = "Bolt load option"
        '
        '_Frames_7
        '
        Me._Frames_7.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_7.Controls.Add(Me.cmbMatShell)
        Me._Frames_7.Controls.Add(Me.framCones)
        Me._Frames_7.Controls.Add(Me._TextCil_100)
        Me._Frames_7.Controls.Add(Me.framPort)
        Me._Frames_7.Controls.Add(Me.chkCalcFBM)
        Me._Frames_7.Controls.Add(Me.List3)
        Me._Frames_7.Controls.Add(Me._cmbCil_10)
        Me._Frames_7.Controls.Add(Me._TextCil_87)
        Me._Frames_7.Controls.Add(Me._Option1_1)
        Me._Frames_7.Controls.Add(Me._Option1_0)
        Me._Frames_7.Controls.Add(Me._TextCil_86)
        Me._Frames_7.Controls.Add(Me._cmdCil_13)
        Me._Frames_7.Controls.Add(Me._LabelCil_122)
        Me._Frames_7.Controls.Add(Me._LabelCil_109)
        Me._Frames_7.Controls.Add(Me._LabelCil_106)
        Me._Frames_7.Controls.Add(Me._LabelCil_105)
        Me._Frames_7.Controls.Add(Me._LabelCil_104)
        Me._Frames_7.Controls.Add(Me._LabelCil_103)
        Me._Frames_7.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me._Frames_7.Location = New System.Drawing.Point(360, 1148)
        Me._Frames_7.Name = "_Frames_7"
        Me._Frames_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_7.Size = New System.Drawing.Size(353, 316)
        Me._Frames_7.TabIndex = 209
        Me._Frames_7.TabStop = False
        Me._Frames_7.Text = "Shell data"
        '
        'cmbMatShell
        '
        Me.cmbMatShell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatShell.Location = New System.Drawing.Point(104, 44)
        Me.cmbMatShell.Name = "cmbMatShell"
        Me.cmbMatShell.Size = New System.Drawing.Size(200, 21)
        Me.cmbMatShell.TabIndex = 273
        '
        'framCones
        '
        Me.framCones.BackColor = System.Drawing.SystemColors.Control
        Me.framCones.Controls.Add(Me._TextCil_104)
        Me.framCones.Controls.Add(Me._TextCil_105)
        Me.framCones.Controls.Add(Me._LabelCil_125)
        Me.framCones.Controls.Add(Me._LabelCil_124)
        Me.framCones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framCones.Location = New System.Drawing.Point(8, 208)
        Me.framCones.Name = "framCones"
        Me.framCones.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framCones.Size = New System.Drawing.Size(233, 57)
        Me.framCones.TabIndex = 272
        Me.framCones.TabStop = False
        Me.framCones.Text = "Kettle cones"
        '
        '_TextCil_104
        '
        Me._TextCil_104.AcceptsReturn = True
        Me._TextCil_104.AutoSize = False
        Me._TextCil_104.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_104.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_104.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_104.Location = New System.Drawing.Point(176, 32)
        Me._TextCil_104.MaxLength = 0
        Me._TextCil_104.Name = "_TextCil_104"
        Me._TextCil_104.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_104.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_104.TabIndex = 273
        Me._TextCil_104.Text = ""
        '
        '_TextCil_105
        '
        Me._TextCil_105.AcceptsReturn = True
        Me._TextCil_105.AutoSize = False
        Me._TextCil_105.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_105.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_105.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_105.Location = New System.Drawing.Point(176, 16)
        Me._TextCil_105.MaxLength = 0
        Me._TextCil_105.Name = "_TextCil_105"
        Me._TextCil_105.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_105.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_105.TabIndex = 274
        Me._TextCil_105.Text = ""
        '
        '_LabelCil_125
        '
        Me._LabelCil_125.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_125.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_125.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_125.Location = New System.Drawing.Point(8, 16)
        Me._LabelCil_125.Name = "_LabelCil_125"
        Me._LabelCil_125.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_125.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_125.TabIndex = 276
        Me._LabelCil_125.Tag = "kLength"
        Me._LabelCil_125.Text = "Thickness"
        '
        '_LabelCil_124
        '
        Me._LabelCil_124.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_124.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_124.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_124.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_124.Name = "_LabelCil_124"
        Me._LabelCil_124.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_124.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_124.TabIndex = 275
        Me._LabelCil_124.Tag = "kLength"
        Me._LabelCil_124.Text = "Axial length"
        '
        '_TextCil_100
        '
        Me._TextCil_100.AcceptsReturn = True
        Me._TextCil_100.AutoSize = False
        Me._TextCil_100.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_100.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_100.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_100.Location = New System.Drawing.Point(198, 112)
        Me._TextCil_100.MaxLength = 0
        Me._TextCil_100.Name = "_TextCil_100"
        Me._TextCil_100.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_100.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_100.TabIndex = 270
        Me._TextCil_100.Text = ""
        '
        'framPort
        '
        Me.framPort.BackColor = System.Drawing.SystemColors.Control
        Me.framPort.Controls.Add(Me._TextCil_99)
        Me.framPort.Controls.Add(Me._TextCil_98)
        Me.framPort.Controls.Add(Me._TextCil_97)
        Me.framPort.Controls.Add(Me._LabelCil_121)
        Me.framPort.Controls.Add(Me._LabelCil_120)
        Me.framPort.Controls.Add(Me._LabelCil_119)
        Me.framPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framPort.Location = New System.Drawing.Point(8, 136)
        Me.framPort.Name = "framPort"
        Me.framPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framPort.Size = New System.Drawing.Size(233, 73)
        Me.framPort.TabIndex = 263
        Me.framPort.TabStop = False
        Me.framPort.Text = "Kettle ports"
        '
        '_TextCil_99
        '
        Me._TextCil_99.AcceptsReturn = True
        Me._TextCil_99.AutoSize = False
        Me._TextCil_99.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_99.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_99.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_99.Location = New System.Drawing.Point(176, 48)
        Me._TextCil_99.MaxLength = 0
        Me._TextCil_99.Name = "_TextCil_99"
        Me._TextCil_99.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_99.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_99.TabIndex = 268
        Me._TextCil_99.Text = ""
        '
        '_TextCil_98
        '
        Me._TextCil_98.AcceptsReturn = True
        Me._TextCil_98.AutoSize = False
        Me._TextCil_98.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_98.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_98.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_98.Location = New System.Drawing.Point(176, 32)
        Me._TextCil_98.MaxLength = 0
        Me._TextCil_98.Name = "_TextCil_98"
        Me._TextCil_98.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_98.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_98.TabIndex = 266
        Me._TextCil_98.Text = ""
        '
        '_TextCil_97
        '
        Me._TextCil_97.AcceptsReturn = True
        Me._TextCil_97.AutoSize = False
        Me._TextCil_97.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_97.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_97.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_97.Location = New System.Drawing.Point(176, 16)
        Me._TextCil_97.MaxLength = 0
        Me._TextCil_97.Name = "_TextCil_97"
        Me._TextCil_97.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_97.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_97.TabIndex = 264
        Me._TextCil_97.Text = ""
        '
        '_LabelCil_121
        '
        Me._LabelCil_121.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_121.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_121.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_121.Location = New System.Drawing.Point(8, 48)
        Me._LabelCil_121.Name = "_LabelCil_121"
        Me._LabelCil_121.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_121.Size = New System.Drawing.Size(136, 17)
        Me._LabelCil_121.TabIndex = 269
        Me._LabelCil_121.Tag = "kLength"
        Me._LabelCil_121.Text = "Internal diameter"
        '
        '_LabelCil_120
        '
        Me._LabelCil_120.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_120.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_120.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_120.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_120.Name = "_LabelCil_120"
        Me._LabelCil_120.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_120.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_120.TabIndex = 267
        Me._LabelCil_120.Tag = "kLength"
        Me._LabelCil_120.Text = "Length"
        '
        '_LabelCil_119
        '
        Me._LabelCil_119.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_119.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_119.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_119.Location = New System.Drawing.Point(8, 16)
        Me._LabelCil_119.Name = "_LabelCil_119"
        Me._LabelCil_119.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_119.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_119.TabIndex = 265
        Me._LabelCil_119.Tag = "kLength"
        Me._LabelCil_119.Text = "Thickness"
        '
        'chkCalcFBM
        '
        Me.chkCalcFBM.BackColor = System.Drawing.SystemColors.Control
        Me.chkCalcFBM.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCalcFBM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCalcFBM.Location = New System.Drawing.Point(256, 96)
        Me.chkCalcFBM.Name = "chkCalcFBM"
        Me.chkCalcFBM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCalcFBM.Size = New System.Drawing.Size(89, 17)
        Me.chkCalcFBM.TabIndex = 262
        Me.chkCalcFBM.Text = "Calcolo FBM"
        '
        'List3
        '
        Me.List3.BackColor = System.Drawing.SystemColors.Window
        Me.List3.Cursor = System.Windows.Forms.Cursors.Default
        Me.List3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List3.Location = New System.Drawing.Point(280, 72)
        Me.List3.Name = "List3"
        Me.List3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List3.Size = New System.Drawing.Size(64, 17)
        Me.List3.TabIndex = 222
        Me.List3.Visible = False
        '
        '_cmbCil_10
        '
        Me._cmbCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_10.Location = New System.Drawing.Point(135, 24)
        Me._cmbCil_10.Name = "_cmbCil_10"
        Me._cmbCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_10.Size = New System.Drawing.Size(190, 21)
        Me._cmbCil_10.TabIndex = 220
        '
        '_TextCil_87
        '
        Me._TextCil_87.AcceptsReturn = True
        Me._TextCil_87.AutoSize = False
        Me._TextCil_87.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_87.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_87.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_87.Location = New System.Drawing.Point(198, 96)
        Me._TextCil_87.MaxLength = 0
        Me._TextCil_87.Name = "_TextCil_87"
        Me._TextCil_87.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_87.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_87.TabIndex = 215
        Me._TextCil_87.Text = ""
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_1.Location = New System.Drawing.Point(203, 79)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(73, 19)
        Me._Option1_1.TabIndex = 214
        Me._Option1_1.TabStop = True
        Me._Option1_1.Text = "Kettle"
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_0.Location = New System.Drawing.Point(133, 79)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(63, 19)
        Me._Option1_0.TabIndex = 213
        Me._Option1_0.TabStop = True
        Me._Option1_0.Text = "Straight"
        '
        '_TextCil_86
        '
        Me._TextCil_86.AcceptsReturn = True
        Me._TextCil_86.AutoSize = False
        Me._TextCil_86.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_86.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_86.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_86.Location = New System.Drawing.Point(198, 61)
        Me._TextCil_86.MaxLength = 0
        Me._TextCil_86.Name = "_TextCil_86"
        Me._TextCil_86.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_86.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_86.TabIndex = 212
        Me._TextCil_86.Text = ""
        '
        '_cmdCil_13
        '
        Me._cmdCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_13.Image = CType(resources.GetObject("_cmdCil_13.Image"), System.Drawing.Image)
        Me._cmdCil_13.Location = New System.Drawing.Point(306, 43)
        Me._cmdCil_13.Name = "_cmdCil_13"
        Me._cmdCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_13.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_13.TabIndex = 211
        Me._cmdCil_13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_122
        '
        Me._LabelCil_122.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_122.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_122.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_122.Location = New System.Drawing.Point(8, 112)
        Me._LabelCil_122.Name = "_LabelCil_122"
        Me._LabelCil_122.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_122.Size = New System.Drawing.Size(168, 17)
        Me._LabelCil_122.TabIndex = 271
        Me._LabelCil_122.Tag = "kLength"
        Me._LabelCil_122.Text = "Length of kettle"
        '
        '_LabelCil_109
        '
        Me._LabelCil_109.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_109.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_109.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_109.Location = New System.Drawing.Point(9, 25)
        Me._LabelCil_109.Name = "_LabelCil_109"
        Me._LabelCil_109.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_109.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_109.TabIndex = 221
        Me._LabelCil_109.Text = "Connected shell"
        '
        '_LabelCil_106
        '
        Me._LabelCil_106.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_106.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_106.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_106.Location = New System.Drawing.Point(8, 96)
        Me._LabelCil_106.Name = "_LabelCil_106"
        Me._LabelCil_106.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_106.Size = New System.Drawing.Size(176, 17)
        Me._LabelCil_106.TabIndex = 219
        Me._LabelCil_106.Tag = "kLength"
        Me._LabelCil_106.Text = "Kettle internal diameter"
        '
        '_LabelCil_105
        '
        Me._LabelCil_105.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_105.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_105.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_105.Location = New System.Drawing.Point(9, 79)
        Me._LabelCil_105.Name = "_LabelCil_105"
        Me._LabelCil_105.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_105.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_105.TabIndex = 218
        Me._LabelCil_105.Text = "Shell type"
        '
        '_LabelCil_104
        '
        Me._LabelCil_104.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_104.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_104.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_104.Location = New System.Drawing.Point(8, 61)
        Me._LabelCil_104.Name = "_LabelCil_104"
        Me._LabelCil_104.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_104.Size = New System.Drawing.Size(152, 17)
        Me._LabelCil_104.TabIndex = 217
        Me._LabelCil_104.Tag = "kLength"
        Me._LabelCil_104.Text = "Shell thickness"
        '
        '_LabelCil_103
        '
        Me._LabelCil_103.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_103.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_103.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_103.Location = New System.Drawing.Point(9, 43)
        Me._LabelCil_103.Name = "_LabelCil_103"
        Me._LabelCil_103.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_103.Size = New System.Drawing.Size(172, 19)
        Me._LabelCil_103.TabIndex = 216
        Me._LabelCil_103.Text = "Shell Material"
        '
        '_Framesf_0
        '
        Me._Framesf_0.BackColor = System.Drawing.SystemColors.Control
        Me._Framesf_0.Controls.Add(Me._Check1_12)
        Me._Framesf_0.Controls.Add(Me._TextCil_83)
        Me._Framesf_0.Controls.Add(Me.txtIBW)
        Me._Framesf_0.Controls.Add(Me._Check1_11)
        Me._Framesf_0.Controls.Add(Me.framltx)
        Me._Framesf_0.Controls.Add(Me._Check1_10)
        Me._Framesf_0.Controls.Add(Me._Check1_9)
        Me._Framesf_0.Controls.Add(Me._TextCil_95)
        Me._Framesf_0.Controls.Add(Me._TextCil_94)
        Me._Framesf_0.Controls.Add(Me._cmdCil_16)
        Me._Framesf_0.Controls.Add(Me._cmbCil_12)
        Me._Framesf_0.Controls.Add(Me._TextCil_90)
        Me._Framesf_0.Controls.Add(Me._TextCil_88)
        Me._Framesf_0.Controls.Add(Me._cmdCil_12)
        Me._Framesf_0.Controls.Add(Me._TextCil_84)
        Me._Framesf_0.Controls.Add(Me._TextCil_82)
        Me._Framesf_0.Controls.Add(Me._cmbCil_9)
        Me._Framesf_0.Controls.Add(Me._Check1_8)
        Me._Framesf_0.Controls.Add(Me._TextCil_22)
        Me._Framesf_0.Controls.Add(Me._cmbCil_5)
        Me._Framesf_0.Controls.Add(Me._TextCil_21)
        Me._Framesf_0.Controls.Add(Me._TextCil_20)
        Me._Framesf_0.Controls.Add(Me._TextCil_4)
        Me._Framesf_0.Controls.Add(Me._Check1_3)
        Me._Framesf_0.Controls.Add(Me._cmbCil_4)
        Me._Framesf_0.Controls.Add(Me._cmbCil_2)
        Me._Framesf_0.Controls.Add(Me._cmbCil_1)
        Me._Framesf_0.Controls.Add(Me._Check1_0)
        Me._Framesf_0.Controls.Add(Me._Check1_4)
        Me._Framesf_0.Controls.Add(Me.LabIBWmm)
        Me._Framesf_0.Controls.Add(Me.labIBW)
        Me._Framesf_0.Controls.Add(Me._LabelCil_117)
        Me._Framesf_0.Controls.Add(Me._LabelCil_116)
        Me._Framesf_0.Controls.Add(Me._LabelCil_115)
        Me._Framesf_0.Controls.Add(Me._LabelCil_110)
        Me._Framesf_0.Controls.Add(Me._LabelCil_107)
        Me._Framesf_0.Controls.Add(Me._LabelCil_102)
        Me._Framesf_0.Controls.Add(Me._LabelCil_101)
        Me._Framesf_0.Controls.Add(Me._LabelCil_100)
        Me._Framesf_0.Controls.Add(Me._LabelCil_99)
        Me._Framesf_0.Controls.Add(Me._LabelCil_8)
        Me._Framesf_0.Controls.Add(Me._LabelCil_28)
        Me._Framesf_0.Controls.Add(Me._LabelCil_27)
        Me._Framesf_0.Controls.Add(Me._LabelCil_26)
        Me._Framesf_0.Controls.Add(Me._LabelCil_25)
        Me._Framesf_0.Controls.Add(Me._LabelCil_9)
        Me._Framesf_0.Controls.Add(Me._LabelCil_4)
        Me._Framesf_0.Controls.Add(Me._LabelCil_3)
        Me._Framesf_0.ForeColor = System.Drawing.Color.Blue
        Me._Framesf_0.Location = New System.Drawing.Point(0, 0)
        Me._Framesf_0.Name = "_Framesf_0"
        Me._Framesf_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Framesf_0.Size = New System.Drawing.Size(350, 308)
        Me._Framesf_0.TabIndex = 0
        Me._Framesf_0.TabStop = False
        Me._Framesf_0.Text = "Dati generali"
        '
        '_Check1_12
        '
        Me._Check1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_12.Checked = True
        Me._Check1_12.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_12, "DatiGenPT.htm#Effetto")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_12, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_12.Location = New System.Drawing.Point(8, 286)
        Me._Check1_12.Name = "_Check1_12"
        Me._Check1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_12, True)
        Me._Check1_12.Size = New System.Drawing.Size(305, 19)
        Me._Check1_12.TabIndex = 349
        Me._Check1_12.Text = "Effetto termico radiale differenziale (UHX-13.8.1/14.6.1)"
        '
        '_TextCil_83
        '
        Me._TextCil_83.AcceptsReturn = True
        Me._TextCil_83.AutoSize = False
        Me._TextCil_83.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_83.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_83.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_83, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_83, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_83.Location = New System.Drawing.Point(280, 72)
        Me._TextCil_83.MaxLength = 0
        Me._TextCil_83.Name = "_TextCil_83"
        Me._TextCil_83.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_83, True)
        Me._TextCil_83.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_83.TabIndex = 198
        Me._TextCil_83.Text = ""
        '
        'txtIBW
        '
        Me.txtIBW.AcceptsReturn = True
        Me.txtIBW.AutoSize = False
        Me.txtIBW.BackColor = System.Drawing.SystemColors.Window
        Me.txtIBW.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIBW.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me.txtIBW, "DatiGenPT.htm#IBW")
        Me.HelpProvider1.SetHelpNavigator(Me.txtIBW, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtIBW.Location = New System.Drawing.Point(264, 268)
        Me.txtIBW.MaxLength = 0
        Me.txtIBW.Name = "txtIBW"
        Me.txtIBW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.txtIBW, True)
        Me.txtIBW.Size = New System.Drawing.Size(46, 20)
        Me.txtIBW.TabIndex = 347
        Me.txtIBW.Text = ""
        '
        '_Check1_11
        '
        Me._Check1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_11.Checked = True
        Me._Check1_11.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_11, "DatiGenPT.htm#IBW")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_11, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_11.Location = New System.Drawing.Point(8, 268)
        Me._Check1_11.Name = "_Check1_11"
        Me._Check1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_11, True)
        Me._Check1_11.Size = New System.Drawing.Size(145, 19)
        Me._Check1_11.TabIndex = 345
        Me._Check1_11.Text = "Giunto tubo-piastra IBW"
        '
        'framltx
        '
        Me.framltx.BackColor = System.Drawing.SystemColors.Control
        Me.framltx.Controls.Add(Me.chkltx)
        Me.framltx.Controls.Add(Me._TextCil_96)
        Me.framltx.Controls.Add(Me._LabelCil_118)
        Me.framltx.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framltx.Location = New System.Drawing.Point(168, 200)
        Me.framltx.Name = "framltx"
        Me.framltx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framltx.Size = New System.Drawing.Size(168, 41)
        Me.framltx.TabIndex = 240
        Me.framltx.TabStop = False
        Me.framltx.Text = "Lunghezza di mandrinatura"
        Me.framltx.Visible = False
        '
        'chkltx
        '
        Me.chkltx.BackColor = System.Drawing.SystemColors.Control
        Me.chkltx.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkltx.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkltx.Location = New System.Drawing.Point(8, 16)
        Me.chkltx.Name = "chkltx"
        Me.chkltx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkltx.Size = New System.Drawing.Size(96, 17)
        Me.chkltx.TabIndex = 242
        Me.chkltx.Text = "in percentuale"
        '
        '_TextCil_96
        '
        Me._TextCil_96.AcceptsReturn = True
        Me._TextCil_96.AutoSize = False
        Me._TextCil_96.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_96.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_96.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_96.Location = New System.Drawing.Point(104, 16)
        Me._TextCil_96.MaxLength = 0
        Me._TextCil_96.Name = "_TextCil_96"
        Me._TextCil_96.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_96.Size = New System.Drawing.Size(32, 20)
        Me._TextCil_96.TabIndex = 241
        Me._TextCil_96.Text = ""
        '
        '_LabelCil_118
        '
        Me._LabelCil_118.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_118.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_118.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_118.Location = New System.Drawing.Point(136, 16)
        Me._LabelCil_118.Name = "_LabelCil_118"
        Me._LabelCil_118.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_118.Size = New System.Drawing.Size(24, 17)
        Me._LabelCil_118.TabIndex = 243
        Me._LabelCil_118.Text = "mm"
        '
        '_Check1_10
        '
        Me._Check1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_10.Checked = True
        Me._Check1_10.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_10, "DatiGenPT.htm#BullDist")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_10, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_10.Location = New System.Drawing.Point(160, 251)
        Me._Check1_10.Name = "_Check1_10"
        Me._Check1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_10, True)
        Me._Check1_10.Size = New System.Drawing.Size(184, 15)
        Me._Check1_10.TabIndex = 328
        Me._Check1_10.Text = "Pressurizzazione indipendente"
        '
        '_Check1_9
        '
        Me._Check1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_9.Checked = True
        Me._Check1_9.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_9, "DatiGenPT.htm#BullDist")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_9, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_9.Location = New System.Drawing.Point(8, 251)
        Me._Check1_9.Name = "_Check1_9"
        Me._Check1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_9, True)
        Me._Check1_9.Size = New System.Drawing.Size(160, 19)
        Me._Check1_9.TabIndex = 288
        Me._Check1_9.Text = "Bulloni distinti tra i due lati"
        '
        '_TextCil_95
        '
        Me._TextCil_95.AcceptsReturn = True
        Me._TextCil_95.AutoSize = False
        Me._TextCil_95.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_95.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_95.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_95, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_95, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_95.Location = New System.Drawing.Point(126, 108)
        Me._TextCil_95.MaxLength = 0
        Me._TextCil_95.Name = "_TextCil_95"
        Me._TextCil_95.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_95, True)
        Me._TextCil_95.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_95.TabIndex = 238
        Me._TextCil_95.Text = ""
        '
        '_TextCil_94
        '
        Me._TextCil_94.AcceptsReturn = True
        Me._TextCil_94.AutoSize = False
        Me._TextCil_94.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_94.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_94.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_94, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_94, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_94.Location = New System.Drawing.Point(280, 104)
        Me._TextCil_94.MaxLength = 0
        Me._TextCil_94.Name = "_TextCil_94"
        Me._TextCil_94.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_94, True)
        Me._TextCil_94.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_94.TabIndex = 236
        Me._TextCil_94.Text = ""
        '
        '_cmbCil_12
        '
        Me._cmbCil_12.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbCil_12, "DatiGenPT.htm#Rules")
        Me.HelpProvider1.SetHelpNavigator(Me._cmbCil_12, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmbCil_12.Location = New System.Drawing.Point(248, 35)
        Me._cmbCil_12.Name = "_cmbCil_12"
        Me._cmbCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbCil_12, True)
        Me._cmbCil_12.Size = New System.Drawing.Size(79, 21)
        Me._cmbCil_12.TabIndex = 234
        '
        '_TextCil_90
        '
        Me._TextCil_90.AcceptsReturn = True
        Me._TextCil_90.AutoSize = False
        Me._TextCil_90.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_90.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_90.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_90.Location = New System.Drawing.Point(279, 187)
        Me._TextCil_90.MaxLength = 0
        Me._TextCil_90.Name = "_TextCil_90"
        Me._TextCil_90.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_90.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_90.TabIndex = 223
        Me._TextCil_90.Text = ""
        '
        '_TextCil_88
        '
        Me._TextCil_88.AcceptsReturn = True
        Me._TextCil_88.AutoSize = False
        Me._TextCil_88.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_88.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_88.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_88, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_88, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_88.Location = New System.Drawing.Point(280, 122)
        Me._TextCil_88.MaxLength = 0
        Me._TextCil_88.Name = "_TextCil_88"
        Me._TextCil_88.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_88, True)
        Me._TextCil_88.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_88.TabIndex = 204
        Me._TextCil_88.Text = ""
        '
        '_TextCil_84
        '
        Me._TextCil_84.AcceptsReturn = True
        Me._TextCil_84.AutoSize = False
        Me._TextCil_84.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_84.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_84.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_84, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_84, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_84.Location = New System.Drawing.Point(126, 125)
        Me._TextCil_84.MaxLength = 0
        Me._TextCil_84.Name = "_TextCil_84"
        Me._TextCil_84.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_84, True)
        Me._TextCil_84.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_84.TabIndex = 200
        Me._TextCil_84.Text = ""
        '
        '_TextCil_82
        '
        Me._TextCil_82.AcceptsReturn = True
        Me._TextCil_82.AutoSize = False
        Me._TextCil_82.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_82.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_82.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_82, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_82, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_82.Location = New System.Drawing.Point(126, 71)
        Me._TextCil_82.MaxLength = 0
        Me._TextCil_82.Name = "_TextCil_82"
        Me._TextCil_82.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_82, True)
        Me._TextCil_82.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_82.TabIndex = 195
        Me._TextCil_82.Text = ""
        '
        '_cmbCil_9
        '
        Me._cmbCil_9.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbCil_9, "DatiGenPT.htm#Diverse")
        Me.HelpProvider1.SetHelpNavigator(Me._cmbCil_9, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmbCil_9.Location = New System.Drawing.Point(224, 144)
        Me._cmbCil_9.Name = "_cmbCil_9"
        Me._cmbCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbCil_9, True)
        Me._cmbCil_9.Size = New System.Drawing.Size(104, 21)
        Me._cmbCil_9.TabIndex = 192
        '
        '_Check1_8
        '
        Me._Check1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_8.Checked = True
        Me._Check1_8.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_8, "DatiGenPT.htm#FullPrint")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_8, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_8.Location = New System.Drawing.Point(8, 235)
        Me._Check1_8.Name = "_Check1_8"
        Me._Check1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_8, True)
        Me._Check1_8.Size = New System.Drawing.Size(137, 19)
        Me._Check1_8.TabIndex = 165
        Me._Check1_8.Text = "Stampa completa"
        '
        '_TextCil_22
        '
        Me._TextCil_22.AcceptsReturn = True
        Me._TextCil_22.AutoSize = False
        Me._TextCil_22.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_22, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_22, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_22.Location = New System.Drawing.Point(280, 88)
        Me._TextCil_22.MaxLength = 0
        Me._TextCil_22.Name = "_TextCil_22"
        Me._TextCil_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_22, True)
        Me._TextCil_22.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_22.TabIndex = 49
        Me._TextCil_22.Text = ""
        '
        '_cmbCil_5
        '
        Me._cmbCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbCil_5, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._cmbCil_5, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmbCil_5.Location = New System.Drawing.Point(81, 89)
        Me._cmbCil_5.Name = "_cmbCil_5"
        Me._cmbCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbCil_5, True)
        Me._cmbCil_5.Size = New System.Drawing.Size(91, 21)
        Me._cmbCil_5.TabIndex = 47
        '
        '_TextCil_21
        '
        Me._TextCil_21.AcceptsReturn = True
        Me._TextCil_21.AutoSize = False
        Me._TextCil_21.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_21, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_21, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_21.Location = New System.Drawing.Point(280, 56)
        Me._TextCil_21.MaxLength = 0
        Me._TextCil_21.Name = "_TextCil_21"
        Me._TextCil_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_21, True)
        Me._TextCil_21.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_21.TabIndex = 45
        Me._TextCil_21.Text = ""
        '
        '_TextCil_20
        '
        Me._TextCil_20.AcceptsReturn = True
        Me._TextCil_20.AutoSize = False
        Me._TextCil_20.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_20, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_20, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_20.Location = New System.Drawing.Point(126, 54)
        Me._TextCil_20.MaxLength = 0
        Me._TextCil_20.Name = "_TextCil_20"
        Me._TextCil_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_20, True)
        Me._TextCil_20.Size = New System.Drawing.Size(46, 20)
        Me._TextCil_20.TabIndex = 43
        Me._TextCil_20.Text = ""
        '
        '_Check1_3
        '
        Me._Check1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_3.Checked = True
        Me._Check1_3.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_3, "DatiGenPT.htm#FlexEstens")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_3, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me._Check1_3, "")
        Me._Check1_3.Location = New System.Drawing.Point(8, 187)
        Me._Check1_3.Name = "_Check1_3"
        Me._Check1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_3, True)
        Me._Check1_3.Size = New System.Drawing.Size(272, 19)
        Me._Check1_3.TabIndex = 8
        Me._Check1_3.Text = "Calcolo della flessione nell'estensione flangiata"
        '
        '_cmbCil_4
        '
        Me._cmbCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbCil_4, "DatiGenPT.htm#DilatAccopp")
        Me.HelpProvider1.SetHelpNavigator(Me._cmbCil_4, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmbCil_4.Location = New System.Drawing.Point(200, 163)
        Me._cmbCil_4.Name = "_cmbCil_4"
        Me._cmbCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbCil_4, True)
        Me._cmbCil_4.Size = New System.Drawing.Size(127, 21)
        Me._cmbCil_4.TabIndex = 6
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbCil_2, "DatiGenPT.htm#TipCalc")
        Me.HelpProvider1.SetHelpNavigator(Me._cmbCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmbCil_2.Location = New System.Drawing.Point(96, 35)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbCil_2, True)
        Me._cmbCil_2.Size = New System.Drawing.Size(79, 21)
        Me._cmbCil_2.TabIndex = 4
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbCil_1, "DatiGenPT.htm#Config")
        Me.HelpProvider1.SetHelpNavigator(Me._cmbCil_1, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmbCil_1.Location = New System.Drawing.Point(96, 14)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbCil_1, True)
        Me._cmbCil_1.Size = New System.Drawing.Size(233, 21)
        Me._cmbCil_1.TabIndex = 3
        '
        '_Check1_0
        '
        Me._Check1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_0.Checked = True
        Me._Check1_0.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_0, "DatiGenPT.htm#EsecComment")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_0.Location = New System.Drawing.Point(8, 219)
        Me._Check1_0.Name = "_Check1_0"
        Me._Check1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_0, True)
        Me._Check1_0.Size = New System.Drawing.Size(163, 19)
        Me._Check1_0.TabIndex = 5
        Me._Check1_0.Text = "Esecuzione commentata"
        '
        '_Check1_4
        '
        Me._Check1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_4.Checked = True
        Me._Check1_4.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._Check1_4, "DatiGenPT.htm#AutomTir")
        Me.HelpProvider1.SetHelpNavigator(Me._Check1_4, System.Windows.Forms.HelpNavigator.Topic)
        Me._Check1_4.Location = New System.Drawing.Point(8, 203)
        Me._Check1_4.Name = "_Check1_4"
        Me._Check1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._Check1_4, True)
        Me._Check1_4.Size = New System.Drawing.Size(152, 19)
        Me._Check1_4.TabIndex = 154
        Me._Check1_4.Text = "Calcolo automatico tiranti"
        '
        'LabIBWmm
        '
        Me.LabIBWmm.BackColor = System.Drawing.SystemColors.Control
        Me.LabIBWmm.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabIBWmm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabIBWmm.Location = New System.Drawing.Point(312, 268)
        Me.LabIBWmm.Name = "LabIBWmm"
        Me.LabIBWmm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabIBWmm.Size = New System.Drawing.Size(24, 17)
        Me.LabIBWmm.TabIndex = 348
        Me.LabIBWmm.Text = "mm"
        '
        'labIBW
        '
        Me.labIBW.BackColor = System.Drawing.SystemColors.Control
        Me.labIBW.Cursor = System.Windows.Forms.Cursors.Default
        Me.labIBW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.labIBW, "DatiGenPT.htm#IBW")
        Me.HelpProvider1.SetHelpNavigator(Me.labIBW, System.Windows.Forms.HelpNavigator.Topic)
        Me.labIBW.Location = New System.Drawing.Point(152, 268)
        Me.labIBW.Name = "labIBW"
        Me.labIBW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.labIBW, True)
        Me.labIBW.Size = New System.Drawing.Size(105, 17)
        Me.labIBW.TabIndex = 346
        Me.labIBW.Text = "Diametro fori PT"
        '
        '_LabelCil_117
        '
        Me._LabelCil_117.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_117.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_117.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_117, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_117, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_117.Location = New System.Drawing.Point(8, 110)
        Me._LabelCil_117.Name = "_LabelCil_117"
        Me._LabelCil_117.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_117, True)
        Me._LabelCil_117.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_117.TabIndex = 239
        Me._LabelCil_117.Tag = "kArea"
        Me._LabelCil_117.Text = "AL (UHX-11.3)"
        '
        '_LabelCil_116
        '
        Me._LabelCil_116.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_116.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_116.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_116, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_116, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_116.Location = New System.Drawing.Point(176, 104)
        Me._LabelCil_116.Name = "_LabelCil_116"
        Me._LabelCil_116.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_116, True)
        Me._LabelCil_116.Size = New System.Drawing.Size(108, 17)
        Me._LabelCil_116.TabIndex = 237
        Me._LabelCil_116.Text = "OTL (Do,UHX-11.3)"
        '
        '_LabelCil_115
        '
        Me._LabelCil_115.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_115.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_115.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_115, "DatiGenPT.htm#Rules")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_115, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_115.Location = New System.Drawing.Point(176, 36)
        Me._LabelCil_115.Name = "_LabelCil_115"
        Me._LabelCil_115.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_115, True)
        Me._LabelCil_115.Size = New System.Drawing.Size(56, 19)
        Me._LabelCil_115.TabIndex = 233
        Me._LabelCil_115.Text = "Rules"
        '
        '_LabelCil_110
        '
        Me._LabelCil_110.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_110.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_110.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_110.Location = New System.Drawing.Point(144, 188)
        Me._LabelCil_110.Name = "_LabelCil_110"
        Me._LabelCil_110.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_110.Size = New System.Drawing.Size(132, 17)
        Me._LabelCil_110.TabIndex = 224
        Me._LabelCil_110.Text = "Diametro interno maggiore"
        '
        '_LabelCil_107
        '
        Me._LabelCil_107.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_107.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_107.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_107, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_107, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_107.Location = New System.Drawing.Point(176, 124)
        Me._LabelCil_107.Name = "_LabelCil_107"
        Me._LabelCil_107.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_107, True)
        Me._LabelCil_107.Size = New System.Drawing.Size(106, 17)
        Me._LabelCil_107.TabIndex = 205
        Me._LabelCil_107.Text = "Lungh. libera tubi"
        '
        '_LabelCil_102
        '
        Me._LabelCil_102.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_102.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_102.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_102, "DatiGenPT.htm#ValoriTubi")
        Me._LabelCil_102.Location = New System.Drawing.Point(9, 126)
        Me._LabelCil_102.Name = "_LabelCil_102"
        Me._LabelCil_102.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_102, True)
        Me._LabelCil_102.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_102.TabIndex = 201
        Me._LabelCil_102.Text = "Numero di tubi"
        '
        '_LabelCil_101
        '
        Me._LabelCil_101.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_101.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_101.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_101, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_101, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_101.Location = New System.Drawing.Point(176, 72)
        Me._LabelCil_101.Name = "_LabelCil_101"
        Me._LabelCil_101.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_101, True)
        Me._LabelCil_101.Size = New System.Drawing.Size(88, 17)
        Me._LabelCil_101.TabIndex = 199
        Me._LabelCil_101.Tag = "kLength"
        Me._LabelCil_101.Text = "Lungh. tubi"
        '
        '_LabelCil_100
        '
        Me._LabelCil_100.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_100.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_100.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_100, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_100, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_100.Location = New System.Drawing.Point(9, 71)
        Me._LabelCil_100.Name = "_LabelCil_100"
        Me._LabelCil_100.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_100, True)
        Me._LabelCil_100.Size = New System.Drawing.Size(115, 17)
        Me._LabelCil_100.TabIndex = 196
        Me._LabelCil_100.Tag = "kLength"
        Me._LabelCil_100.Text = "Spessore tubi"
        '
        '_LabelCil_99
        '
        Me._LabelCil_99.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_99.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_99, "DatiGenPT.htm#Diverse")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_99, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_99.Location = New System.Drawing.Point(8, 146)
        Me._LabelCil_99.Name = "_LabelCil_99"
        Me._LabelCil_99.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_99, True)
        Me._LabelCil_99.Size = New System.Drawing.Size(95, 19)
        Me._LabelCil_99.TabIndex = 193
        Me._LabelCil_99.Text = "Piastre diverse ?"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_8, "DatiGenPT.htm#DilatAccopp")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_8, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 164)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_8, True)
        Me._LabelCil_8.Size = New System.Drawing.Size(127, 19)
        Me._LabelCil_8.TabIndex = 7
        Me._LabelCil_8.Text = "Dilatatore accoppiato"
        '
        '_LabelCil_28
        '
        Me._LabelCil_28.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_28, "DatiGenPT.htm#ValoriTubi")
        Me._LabelCil_28.Location = New System.Drawing.Point(176, 88)
        Me._LabelCil_28.Name = "_LabelCil_28"
        Me._LabelCil_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_28, True)
        Me._LabelCil_28.Size = New System.Drawing.Size(92, 17)
        Me._LabelCil_28.TabIndex = 50
        Me._LabelCil_28.Text = "DL (RCB-7.133)"
        '
        '_LabelCil_27
        '
        Me._LabelCil_27.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_27, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_27, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_27.Location = New System.Drawing.Point(9, 90)
        Me._LabelCil_27.Name = "_LabelCil_27"
        Me._LabelCil_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_27, True)
        Me._LabelCil_27.Size = New System.Drawing.Size(73, 20)
        Me._LabelCil_27.TabIndex = 48
        Me._LabelCil_27.Text = "Tipo di passo"
        '
        '_LabelCil_26
        '
        Me._LabelCil_26.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_26, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_26, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_26.Location = New System.Drawing.Point(176, 56)
        Me._LabelCil_26.Name = "_LabelCil_26"
        Me._LabelCil_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_26, True)
        Me._LabelCil_26.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_26.TabIndex = 46
        Me._LabelCil_26.Tag = "kLength"
        Me._LabelCil_26.Text = "Passo tubi"
        '
        '_LabelCil_25
        '
        Me._LabelCil_25.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_25, "DatiGenPT.htm#ValoriTubi")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_25, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_25.Location = New System.Drawing.Point(9, 54)
        Me._LabelCil_25.Name = "_LabelCil_25"
        Me._LabelCil_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_25, True)
        Me._LabelCil_25.Size = New System.Drawing.Size(114, 17)
        Me._LabelCil_25.TabIndex = 44
        Me._LabelCil_25.Tag = "kLength"
        Me._LabelCil_25.Text = "Diam. est. tubi"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_9, "DatiGenPT.htm#RappEst")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_9, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 147)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_9, True)
        Me._LabelCil_9.Size = New System.Drawing.Size(221, 19)
        Me._LabelCil_9.TabIndex = 10
        Me._LabelCil_9.Text = "Rapporto spessori estensione/piastra"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_4, "DatiGenPT.htm#TipCalc")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_4, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_4.Location = New System.Drawing.Point(9, 36)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_4, True)
        Me._LabelCil_4.Size = New System.Drawing.Size(88, 19)
        Me._LabelCil_4.TabIndex = 2
        Me._LabelCil_4.Text = "Calculation type"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_3, "DatiGenPT.htm#Config")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_3, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_3.Location = New System.Drawing.Point(9, 15)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_3, True)
        Me._LabelCil_3.Size = New System.Drawing.Size(136, 19)
        Me._LabelCil_3.TabIndex = 1
        Me._LabelCil_3.Text = "Configuration"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(672, 449)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(46, 28)
        Me.Command1.TabIndex = 13
        Me.Command1.Text = "OK"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(616, 449)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 28)
        Me.Command2.TabIndex = 12
        Me.Command2.Text = "Cancel"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(256, 200)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'TabStrip1
        '
        Me.TabStrip1.Location = New System.Drawing.Point(352, 0)
        Me.TabStrip1.Name = "TabStrip1"
        Me.TabStrip1.SelectedIndex = 0
        Me.TabStrip1.Size = New System.Drawing.Size(368, 448)
        Me.TabStrip1.TabIndex = 290
        '
        'TabStrip2
        '
        Me.TabStrip2.Location = New System.Drawing.Point(0, 312)
        Me.TabStrip2.Name = "TabStrip2"
        Me.TabStrip2.SelectedIndex = 0
        Me.TabStrip2.Size = New System.Drawing.Size(352, 216)
        Me.TabStrip2.TabIndex = 291
        '
        'frmPT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(726, 583)
        Me.Controls.Add(Me._Frames_1)
        Me.Controls.Add(Me._Frames_2)
        Me.Controls.Add(Me._Frames_0)
        Me.Controls.Add(Me._Frames_8)
        Me.Controls.Add(Me._Framesf_1)
        Me.Controls.Add(Me._Framesf_2)
        Me.Controls.Add(Me._Frames_6)
        Me.Controls.Add(Me._Frames_7)
        Me.Controls.Add(Me._Frames_5)
        Me.Controls.Add(Me._Frames_3)
        Me.Controls.Add(Me._Frames_4)
        Me.Controls.Add(Me._Framesf_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.TabStrip1)
        Me.Controls.Add(Me.TabStrip2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPT"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Piastre Tubiere / Fasci"
        Me._Frames_1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me._Frames_2.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me._Frames_0.ResumeLayout(False)
        Me._frmCollars_0.ResumeLayout(False)
        Me._Frames_3.ResumeLayout(False)
        Me._Frames_5.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me._TextCil_89, System.ComponentModel.ISupportInitialize).EndInit()
        Me._Framesf_1.ResumeLayout(False)
        Me._Frames_4.ResumeLayout(False)
        Me._Frames_6.ResumeLayout(False)
        Me._Framesf_2.ResumeLayout(False)
        Me._Frames_8.ResumeLayout(False)
        Me._frmCollars_1.ResumeLayout(False)
        Me._Frames_7.ResumeLayout(False)
        Me.framCones.ResumeLayout(False)
        Me.framPort.ResumeLayout(False)
        Me._Framesf_0.ResumeLayout(False)
        Me.framltx.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private jSav, kSav
    Private File As String
    Private PT As wn_FTC
    Private Clic, Uno, Bulloni As Short
    Private td1 As Single
    Private savDiv As Short
    Private AllBRoo, AllBOpe As Single
    Private AllBhyd As Single
    Private Index, Indexx, i2 As Short
    Private j, k, indN, indV, iDil As Short
    Private wn As wn_flan
    Private O As wn_PT
    Private PiastraAB As Short
    Private Saltacombo As Boolean
    Private TipoPiastra, iii As Short
    Private actFrames(4) As System.Windows.Forms.GroupBox
    Private VecchiocmbCil1 As Short
    Private NonCambiareTipo As Boolean
    Private NonScollegare As Boolean
    Private Aggiornando As Boolean
    Private FlanM, FlanC As Boolean
    Private Inizializzando As Boolean
    Private ListIndiciCombo11(9) As Short
    Public Cancel As Boolean
    Private TagImageList1() As String = {"1.6 (a)", _
                                         "1.6 (b)", _
                                         "1.6 (c)", _
                                         "1.6 (d)", _
                                         "UHX (a)", _
                                         "UHX (b)", _
                                         "UHX (c)", _
                                         "UHX (d)", _
                                         "1.6 (z)"}
    Private Sub Inizializza()
        Dim i, ifl As Short
        Dim Riga As String
        Dim Nome As String
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(200)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        Me.frmCollarsInitialHeigth = Me._frmCollars_0.Height
        Popola(cmbMat)
        Popola(cmbMat2)
        Popola(cmbMatBoltLM)
        Popola(cmbMatBoltLT)
        Popola(cmbMatFlLM)
        Popola(cmbMatFlLT)
        Popola(cmbMatSlLM)
        Popola(cmbMatSlLT)
        Popola(cmbMatShell)
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("TubeSheet")
        _cmbCil_0.Items.Add("Other (write)")
        _cmbCil_0.Text = Trim(Involucr(kLato, jInvolucr).Mark)
        _cmbCil_8.Items.Clear()
        _cmbCil_8.Items.Add("Floating TubeSheet")
        _cmbCil_8.Items.Add("Other (write)")
        _cmbCil_8.Text = ""
        cmbCil(12).Items.Clear()
        cmbCil(12).Items.Add("TEMA")
        If UltimoAggiornamento >= 3 Then
            cmbCil(12).Items.Add("UHX")
        Else
            cmbCil(12).Items.Add("App AA")
        End If
        cmbCil(12).Items.Add("Both")
        If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Rules > 2 Then CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Rules = 0
        cmbCil(12).SelectedIndex = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Rules
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            Try
                If Not .Piastra Is Nothing And TipoPiastra = 2 Then
                    If CType(.Piastra, wn_FTC).Rear > 0 And CType(.Piastra, wn_FTC).Rear < 3 Then
                        .SetPiastra(2)
                        _cmbCil_8.Text = CType(.Piastra, wn_FTC).TipoPias(2)
                        .SetPiastra(1)
                    End If
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
        _cmbCil_1.Items.Clear()
        ifl = FreeFile()
        Nome = Trim(clsInizio.Archdir) & "\WN5\TipPT.DAT"
        If OpenFile(Nome, ifl) Then
            For i = 1 To 6
                Riga = LineInput(ifl)
                _cmbCil_1.Items.Add(Riga)
            Next
            FileClose(ifl)
        End If
        i = Involucr(kLato, jInvolucr).IndObject
        _cmbCil_2.Items.Clear()
        _cmbCil_2.Items.Add("Progetto")
        _cmbCil_2.Items.Add("Verifica")
        If Config(0).CalcPI = 1 Then
            _cmbCil_2.Items.Add("P.I. + progetto")
            If CType(objMemb(i), wn_PT).TipCalc = 3 Then CType(objMemb(i), wn_PT).TipCalc = 1
        End If
        _cmbCil_3.Items.Clear()
        _cmbCil_3.Items.Add("ASME")
        _cmbCil_3.Items.Add("Full Bolt")
        _cmbCil_3.Items.Add("Fluor Daniel")
        _cmbCil_403.Items.Clear()
        _cmbCil_403.Items.Add("ASME")
        _cmbCil_403.Items.Add("Full Bolt")
        _cmbCil_403.Items.Add("Fluor Daniel")
        _cmbCil_4.Items.Clear()
        List1.Items.Clear()
        List1.Items.Add("0")
        _cmbCil_4.Items.Add("Nessuno")
        List1.Items.Add("0")
        _cmbCil_4.Items.Add("Spring-rate manuale")
        For i = 1 To Config(1).Ninvolucri
            If Involucr(1, i).Tipo = 8 Then
                List1.Items.Add(i.ToString)
                _cmbCil_4.Items.Add(Trim(Involucr(1, i).Mark))
            End If
        Next
        _cmbCil_5.Items.Clear()
        _cmbCil_5.Items.Add("Passo quadrato")
        _cmbCil_5.Items.Add("Passo triangolare")
        _cmbCil_9.Items.Clear()
        _cmbCil_9.Items.Add("NO        ")
        _cmbCil_9.Items.Add("SI, normale")
        _cmbCil_9.Items.Add("SI, speciale")
        List3.Items.Clear()
        cmbCil(10).Items.Clear()
        List3.Items.Add("0")
        cmbCil(10).Items.Add("Nessuno")
        For i = 1 To Config(1).Ninvolucri
            If Involucr(1, i).Tipo = 0 Then
                List3.Items.Add(i.ToString)
                cmbCil(10).Items.Add(Trim(Involucr(1, i).Mark))
            End If
        Next
        InitCombo11()
        If UltimoAggiornamento < 4 Then
            _Check1_11.Visible = False
            _Check1_11.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            _LabelCil_117.Text = "AL(UHX-11.3)"
        End If
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub InitCombo11()
        Dim i As Short
        For i = 0 To 9
            ListIndiciCombo11(i) = -1
        Next
        _cmbCil_11.Items.Clear()
        If Inizializzando Then
            _cmbCil_11.Items.Add("1.6(a)-Fondo torosf. con flangia sciolta")
            _cmbCil_11.Items.Add("1.6(a)-Fondo torosf. con flangia integrale")
            _cmbCil_11.Items.Add("1.6(b)-Calotta sferica con flangia sovrapposta")
            _cmbCil_11.Items.Add("1.6(c)-Calotta sferica con flangia integrale")
            _cmbCil_11.Items.Add("1.6(d)-Calotta sferica con flangia saldata")
            _cmbCil_11.Items.Add("noref.-Calotta conica con flangia saldata")
            _cmbCil_11.Items.Add("UHX-14.3(b)-PT flangiata")
            _cmbCil_11.Items.Add("UHX-14.3(a)-PT saldata")
            _cmbCil_11.Items.Add("UHX-14.3(c)-PT flangiata con Split Ring")
            _cmbCil_11.Items.Add("UHX-14.3(d)-PT internally sealed")
            For i = 0 To 9
                _cmbCil_11.Items.Add(Helpstringa(5015 + i))
                ListIndiciCombo11(i) = i
            Next
        Else
            For i = 0 To 5
                _cmbCil_11.Items.Add(Helpstringa(5015 + i))
                ListIndiciCombo11(i) = i
            Next
            Select Case _cmbCil_7.SelectedIndex
                Case 1 'S - with back-ring
                    _cmbCil_11.Items.Add(Helpstringa(5015 + 8))
                    ListIndiciCombo11(6) = 8
                Case 2 'T - Flanged
                    _cmbCil_11.Items.Add(Helpstringa(5015 + 6))
                    ListIndiciCombo11(6) = 6
            End Select
        End If

    End Sub
    Friend ReadOnly Property Check1(ByVal i As Short) As CheckBox
        Get
            Select Case i
                Case 0 : Return _Check1_0
                Case 1 : Return _Check1_1
                Case 2 : Return _Check1_2
                Case 3 : Return _Check1_3
                Case 4 : Return _Check1_4
                Case 5 : Return _Check1_5
                Case 6 : Return _Check1_6
                Case 7 : Return _Check1_7
                Case 8 : Return _Check1_8
                Case 9 : Return _Check1_9
                Case 10 : Return _Check1_10
                Case 11 : Return _Check1_11
                Case 12 : Return _Check1_12
                Case 401 : Return _Check1_401
                Case 402 : Return _Check1_402
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Check1_CheckStateChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim j, i, n As Short
        Dim Log1 As Boolean
        Dim c As System.Windows.Forms.Control
        Try
            With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
                Select Case Index
                    Case 0
                        .Verbose = (Check1(Index).CheckState = 1)
                        Config(0).Verbose = .Verbose
                    Case 1
                        .DiffPIese(1) = (Check1(Index).CheckState = 1)
                    Case 2
                        .CRUSH(1) = (Check1(Index).CheckState = 1)
                    Case 401
                        .DiffPIese(2) = (Check1(Index).CheckState = 1)
                    Case 402
                        .CRUSH(2) = (Check1(Index).CheckState = 1)
                    Case 3
                        .FLEX = (Check1(Index).CheckState = 1)
                    Case 4
                        .mart = (Check1(Index).CheckState = 1)
                        NubbinVisible(.mart)
                        If .mart Then 'calcolo automatico
                            If Check2.CheckState = 0 Then Nonvisibile(True)
                            BulAutomatico(True)
                            If Check2.CheckState = 1 Then Nonvisibile(False)
                        Else
                            BulAutomatico(False)
                        End If
                        'LabelCil(56).Visible = False
                        'LabelCil(59).Visible = False
                        n = 1
                        cmbMatBoltLT.Enabled = .mart
                        Me.chkAggancBoltLT.Enabled = .mart
                        ' If .BullDistinti Then
                        n = 2
                        Me.chkAggancBoltLM.Enabled = .mart
                        cmbMatBoltLM.Enabled = .mart
                        'End If
                        For j = 1 To n
                            For i = 2 To 16
                                If Not (i = 4 Or i = 7 Or i = 8 Or i = 10 Or i = 13 Or i = 14) Then
                                    TextCil(i + (j - 1) * 400).Enabled = .mart
                                End If
                            Next
                            cmdCil(1 + (j - 1) * 400).Enabled = .mart
                            cmdCil(2 + (j - 1) * 400).Enabled = .mart
                            cmdCil(6 + (j - 1) * 400).Enabled = .mart
                            cmbCil(3 + (j - 1) * 400).Enabled = .mart
                            Check1(1 + (j - 1) * 400).Enabled = .mart
                            Check1(2 + (j - 1) * 400).Enabled = .mart
                        Next
                        If .mart Then
                            LabelCil(40).Visible = True : TextCil(33).Visible = True
                        End If
                        'fin qui vale nei due casi di piastra avvitata e piastra per BL
                        If TipoPiastra = 2 Then
                            If CType(.Piastra, wn_FTC).Gasketed(1) = 2 Then 'la piastra per BL è senza estensione e quindi è tipo FTC
                                _LabelCil_181.Visible = False : cmbMatFlLM.Visible = False : _cmdCil_181.Visible = False
                                For Each c In Controls
                                    If c.Parent Is _Frames_1 Then c.Visible = False
                                Next c
                                _Frames_1.Text = "Virola di spinta"
                                LabelCil(39).Visible = True : TextCil(32).Visible = True
                                _LabelCil_41.Visible = True : TextCil(34).Visible = True
                                _LabelCil_41.Text = "Spessore"
                            End If
                        End If
                    Case 5
                        Log1 = (Check1(Index).CheckState = CheckState.Checked)
                        .ProgDiffPr = Log1 'diff.press
                        LabelCil(81).Visible = Log1
                        _TextCil_52.Visible = Log1
                        _lblUni_52.Visible = Log1
                        LabelCil(141).Visible = Log1
                        _TextCil_91.Visible = Log1
                        _lblUni_91.Visible = Log1
                        AggiustaDiff()
                    Case 6
                        .VacuumTS = (Check1(Index).CheckState = 1) 'Vacuum ts
                    Case 7
                        .VacuumSS = (Check1(Index).CheckState = 1) 'vacumm SS
                    Case 8
                        If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).TipoPT = 2 Then
                            If Check1(Index).CheckState = 1 Then
                                CType(.Piastra, wn_FTC).Documented = 2
                                If Not CType(.Piastra, wn_FTC).SoloDilat And _cmbCil_2.Items.Count > 0 Then
                                    _cmbCil_2.SelectedIndex = 1
                                End If
                            Else
                                CType(.Piastra, wn_FTC).Documented = 1
                            End If
                        End If
                    Case 9 'bulloni distinti
                        .BullDistinti = (Check1(Index).CheckState = 1)
                        _Check1_10.Visible = (Check1(Index).CheckState = 1)
                        AggTab()
                        AggCheck()
                    Case 10 ' pressurizzazione con gli altri bulloni sciolti
                        .BullIndip = (Check1(Index).CheckState = 1)
                    Case 11 'giunto IBW
                        .IBW = (Check1(Index).CheckState = 1)
                        framltx.Visible = Not .IBW
                        labIBW.Visible = .IBW
                        LabIBWmm.Visible = .IBW
                        txtIBW.Visible = .IBW
                    Case 12 '
                        .RadialExp = (Check1(Index).CheckState = CheckState.Checked)
                End Select
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Check2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check2.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim i, j As Short
        i = Involucr(kLato, jInvolucr).IndObject
        If Check2.CheckState = CheckState.Checked Then
            CType(objMemb(i), wn_PT).SlChanDati(1) = -2 '(segnale di piastra avvitata) '170206
            For j = 1 To 4
                If j <> 2 Then CType(objMemb(i), wn_PT).IndAccopp(j) = 0
            Next
            ' objMemb(i).TipoAA = 0
            _Check1_4.CheckState = CheckState.Checked
        Else
            If CType(objMemb(i), wn_PT).SlChanDati(1) = -2 Then CType(objMemb(i), wn_PT).SlChanDati(1) = -1 '170206
            cmbCil_SelectedIndexChanged(1)
            cmbCil_SelectedIndexChanged(12)
        End If
        AggTab()
        Check1_CheckStateChanged(4) '????????????????????
    End Sub
    Private Sub chkCalcFBM_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkCalcFBM.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim PT As wn_FTC
        Dim Logic As Boolean
        PT = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        Logic = chkCalcFBM.CheckState = 1
        PT.CalcFBM = Logic
        LabelCil(122).Visible = Not Logic
        TextCil(100).Visible = Not Logic
        framPort.Visible = Not Logic
        framCones.Visible = Not Logic
    End Sub
    Private Sub chkltx_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkltx.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim PT As wn_PT
        Dim perc As Boolean
        PT = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
        perc = chkltx.CheckState = CheckState.Checked
        PT.ltxperc = perc
        If perc Then
            _LabelCil_118.Text = "%"
        Else
            _LabelCil_118.Text = UnitLength.Substring(1, 2)
        End If
    End Sub
    Private Sub cmbCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim ii As Short
        Dim PT As wn_PT
        If Saltacombo Then Exit Sub
        If TabStrip2.Visible Then
            ii = TabStrip2.SelectedIndex + 1
        Else
            ii = 1
        End If
        PT = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
        With PT
            Select Case Index
                Case 0 'identification
                    Involucr(kLato, jInvolucr).Mark = _cmbCil_0.Text
                    .TipoPias(1) = _cmbCil_0.Text
                    '                    If Not .Piastra Is Nothing Then
                    '                    Select Case .TipoPT
                    '                Case 1
                    '                    CType(.Piastra, wn_UTEMA).TipoPias(1) = _cmbCil_0.Text
                    '                Case 2
                    '                    CType(.Piastra, wn_FTC).TipoPias(1) = _cmbCil_0.Text
                    '            End Select
                    '                    End If
                Case 8
            If Not .Piastra Is Nothing Then
                CType(.Piastra, wn_FTC).TipoPias(2) = _cmbCil_8.Text
            End If
                Case 51, 81, 101, 121
            If Index = 51 And Not FlanC Then Exit Sub
            If Index = 81 And Not FlanM Then Exit Sub
            If Index = 101 And FlanC Then Exit Sub
            If Index = 121 And FlanM Then Exit Sub
            .SetPiastra(ii)
            Select Case Index
                Case 51
                    If FlanC Then
                                .FlChanNome = _cmbCil_51.Text 'Nome Fl LT
                                If Not NonScollegare Then
                                    .IndAccopp(1) = 0
                                    Select Case PiastraAB
                                        Case 1 : Involucr(kLato, jInvolucr).IndAccopp(1) = 0
                                        Case 2 : Involucr(kLato, jInvolucr).IndAccopp2(1) = 0
                                    End Select
                                End If
                            End If
                Case 81
                    If FlanM Then
                                .FlShelNome = _cmbCil_81.Text 'Nome Fl  LM
                                If Not NonScollegare Then
                                    .IndAccopp(2) = 0
                                    Select Case PiastraAB
                                        Case 1 : Involucr(kLato, jInvolucr).IndAccopp(2) = 0
                                        Case 2 : Involucr(kLato, jInvolucr).IndAccopp2(2) = 0
                                    End Select
                                End If
                            End If
                Case 101
                    If Not FlanC Then
                                .SlChanNome = _cmbCil_101.Text 'Nome Sald LT
                                If Not NonScollegare Then
                                    .IndAccopp(3) = 0
                                    Select Case PiastraAB
                                        Case 1 : Involucr(kLato, jInvolucr).IndAccopp(3) = 0
                                        Case 2 : Involucr(kLato, jInvolucr).IndAccopp2(3) = 0
                                    End Select
                                End If
                            End If
                Case 121
                    If Not FlanM Then
                                .SlShelNome = _cmbCil_121.Text 'Nome Sald LM
                                If Not NonScollegare Then
                                    .IndAccopp(4) = 0
                                    Select Case PiastraAB
                                        Case 1 : Involucr(kLato, jInvolucr).IndAccopp(4) = 0
                                        Case 2 : Involucr(kLato, jInvolucr).IndAccopp2(4) = 0
                                    End Select
                                End If
                            End If
            End Select
            'AggiornaCollegFl
            End Select
        End With
    End Sub
    Private Sub cmbCil_SelectedIndexChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim i, l As Short
        Dim n As Short
        Dim Log1 As Boolean
        Dim ii, iDilat As Short
        Dim O As wn_PT
        Dim V As Boolean
        Dim Testo As String
        Dim jSav, kSav As Short
        Dim c As System.Windows.Forms.Control
        If Not cmbCil(Index).Enabled Then Exit Sub
        'Involucr(3, 2).indice(3) = -1
        Try
            If TabStrip2.Visible Then
                ii = TabStrip2.SelectedIndex + 1
            Else
                ii = 1
            End If
            i = Involucr(kLato, jInvolucr).IndObject
            If i = 0 Then Exit Sub
            Select Case Index
                Case 0, 8 'identification
                    'Involucr(kLato, jInvolucr).Mark = cmbCil(Index).Text
                    cmbCil_TextChanged(Index)
                Case 1 'tipo membratura
                    NonCambiareTipo = CheckTubi()
                    For Each c In Controls
                        If c.Parent Is _Frames_1 And Not c.Name = "List2" And Not c.Name = "List1" Then c.Visible = True
                    Next c
                    _Frames_1.Text = "Dati flangiatura L.T."
                    _LabelCil_41.Text = "Spessore max codolo"
                    Frame1.Visible = False
                    _LabelCil_4.Visible = True : _cmbCil_2.Visible = True
                    _LabelCil_22.Visible = True : _TextCil_17.Visible = True
                    _LabelCil_8.Visible = False : _cmbCil_4.Visible = False 'dilat
                    Try
                        If Not (CType(objMemb(i), wn_PT).Rules > 0 And CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 2) Then
                            _LabelCil_101.Visible = False : _TextCil_83.Visible = False 'dilat
                            _LabelCil_102.Visible = False : _TextCil_84.Visible = False 'N° tubi
                            _LabelCil_107.Visible = False : _TextCil_88.Visible = False 'dilat
                        End If
                    Catch
                        _LabelCil_101.Visible = False : _TextCil_83.Visible = False 'dilat
                        _LabelCil_102.Visible = False : _TextCil_84.Visible = False 'N° tubi
                        _LabelCil_107.Visible = False : _TextCil_88.Visible = False 'dilat
                    End Try
                    _LabelCil_110.Visible = True : _TextCil_90.Visible = True 'diam dilat max
                    _LabelCil_9.Visible = False : _TextCil_4.Visible = False
                    _Check1_3.Visible = False
                    _LabelCil_99.Visible = False : _cmbCil_9.Visible = False
                    _Check1_4.Visible = True
                    _LabelCil_100.Visible = True : _TextCil_82.Visible = True
                    _Check1_0.Visible = True : _Check1_8.Visible = True
                    _Check1_9.Visible = False
                    _Check1_12.Visible = False
                    Check2.Visible = False
                    AggTab2(False)
                    CheckTipo()
                    Select Case _cmbCil_1.SelectedIndex
                        Case 0 'U estesa biflangiata
                            UTEMA(i, cmbCil(Index).SelectedIndex)
                            CType(objMemb(i), wn_PT).TipoAA = 0
                            _Check1_9.Visible = True
                            AggCombo6()
                        Case 1 'U estesa flangiata lato cassa
                            UTEMA(i, cmbCil(Index).SelectedIndex)
                            CType(objMemb(i), wn_PT).TipoAA = 4
                        Case 2 'U estesa flangiata lato mantello
                            UTEMA(i, cmbCil(Index).SelectedIndex)
                            CType(objMemb(i), wn_PT).TipoAA = 3
                        Case 3 : TipoPiastra = 2 'fisse
                            Frame1.Visible = True
                            If Not _cmbCil_4.SelectedIndex = 1 Then
                                _LabelCil_110.Visible = False : _TextCil_90.Visible = False 'diam dilat max
                            End If
                            _LabelCil_101.Visible = True : _TextCil_83.Visible = True 'Lunghezza tubi
                            _LabelCil_102.Visible = True : _TextCil_84.Visible = True 'N° tubi
                            _LabelCil_107.Visible = True : _TextCil_88.Visible = True 'lungh.libera
                            _LabelCil_85.Visible = True : _cmbCil_6.Visible = True
                            _LabelCil_99.Visible = True : _cmbCil_9.Visible = True
                            _LabelCil_8.Visible = True : _cmbCil_4.Visible = True 'dilat
                            _Check1_0.Visible = False
                            _Check1_8.Visible = True
                            CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 1
                            AggCombo6()
                            AggTab2(True)
                            _Check1_12.Visible = CType(objMemb(i), wn_PT).Rules > 0 And RadialExpPossible
                        Case 4 : TipoPiastra = 2 'flottante
                            _LabelCil_110.Visible = False : _TextCil_90.Visible = False 'diam dilat max
                            _LabelCil_85.Visible = True : _cmbCil_6.Visible = True
                            _LabelCil_101.Visible = True : _TextCil_83.Visible = True 'Lunghezza tubi
                            V = CType(objMemb(i), wn_PT).Rules > 0
                            _LabelCil_102.Visible = V : _TextCil_84.Visible = V 'N° tubi
                            _LabelCil_107.Visible = V : _TextCil_88.Visible = V 'lungh.libera
                            _Check1_0.Visible = False
                            _Check1_8.Visible = True
                            CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 2
                            AggCombo6()
                            If Not CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).SoloDilat Then _cmbCil_9.SelectedIndex = 1
                            AggTab2(True)
                            If _cmbCil_6.SelectedIndex = 2 Then
                                _LabelCil_22.Visible = False : _TextCil_17.Visible = False
                            End If
                            _Check1_12.Visible = CType(objMemb(i), wn_PT).Rules > 0 And RadialExpPossible
                        Case 5 : TipoPiastra = 2 'U
                            _LabelCil_22.Visible = False : _TextCil_17.Visible = False
                            _LabelCil_110.Visible = False : _TextCil_90.Visible = False 'diam dilat max
                            _LabelCil_4.Visible = False : _cmbCil_2.Visible = False
                            _LabelCil_85.Visible = True : _cmbCil_6.Visible = True
                            _Check1_8.Visible = False
                            _Check1_0.Visible = False
                            _Check1_4.Visible = False
                            CType(objMemb(i), wn_PT).mart = False
                            CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 3
                            _LabelCil_24.Visible = False : _TextCil_19.Visible = False
                            'spessore estensione: nei due casi precednti dipende
                            AggCombo6()
                            If Not CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).SoloDilat Then _cmbCil_9.SelectedIndex = 0
                            AggTab2(True)
                    End Select
                    Select Case TipoPiastra
                        Case 1
                            CType(CType(objMemb(i), wn_PT).Piastra, wn_UTEMA).bdice = cmbCil(Index).SelectedIndex
                            If cmbCil(Index).SelectedIndex = 0 Then
                            Else
                                CType(CType(objMemb(i), wn_PT).Piastra, wn_UTEMA).NumColl(1) = 0
                            End If
                        Case 2
                            '  objMemb(i).Piastra.Rear = cmbCil(Index).ListIndex - 2
                    End Select
                    AggTab()
                Case 2 'tipo di calcolo
                    CType(objMemb(i), wn_PT).TipCalc = cmbCil(Index).SelectedIndex
                    Log1 = (TipoPiastra = 1 And CType(objMemb(i), wn_PT).TipCalc = 0 And CType(objMemb(i), wn_PT).Rules <> 1)
                    _LabelCil_9.Visible = Log1 : _TextCil_4.Visible = Log1
                Case 3, 403 'carico bulloni
                    CType(objMemb(i), wn_PT).FullBolt = cmbCil(Index).SelectedIndex
                Case 4 'dilat
                    With CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC)
                        _LabelCil_110.Visible = False : _TextCil_90.Visible = False
                        Select Case cmbCil(Index).SelectedIndex
                            Case -1
                            Case 0 'nessuno
                                .Zp(1, 26) = 0
                                Stacca(i)
                            Case 1 'manuale
                                _LabelCil_110.Visible = True : _TextCil_90.Visible = True
                                .SoloDilat = False
                                .TipoDilatp = 7
                                If .Zp(1, 26) = 0 Then .Zp(1, 26) = 1000
                                _TextCil_90.Text = GlobalRoutines.myStr(.Zp(1, 26) * kLength, 5, 2, False)
                                Stacca(i)
                            Case Else 'dilat
                                List1.SelectedIndex = cmbCil(Index).SelectedIndex
                                .SoloDilat = False
                                iDilat = GlobalRoutines.ValVir(List1.Text)
                                .IndiceDilat = iDilat
                                objMemb(Involucr(1, iDilat).IndObject) = objMemb(i)
                                k = kLato : j = jInvolucr
                                kLato = 1 : jInvolucr = iDilat
                                TrasfDilat() 'Look
                                kLato = k : jInvolucr = j
                        End Select
                    End With
                Case 5 'tipo passo
                    CType(objMemb(i), wn_PT).TipPass = 1 - cmbCil(Index).SelectedIndex ' + 1
                Case 6 ' tipo flangiatura piastre fisse e flottanti
                    O = objMemb(i)
                    With O
                        Select Case TipoPiastra
                            Case 1
                                If _cmbCil_1.SelectedIndex = 0 Then
                                    .TipoAA = _cmbCil_6.SelectedIndex
                                Else
                                    CType(.Piastra, wn_FTC).Gasketed(1) = (cmbCil(Index).SelectedIndex = 3)
                                    CType(.Piastra, wn_FTC).Flangiata(1) = cmbCil(Index).SelectedIndex - 1
                                End If
                            Case 2
                                Select Case _cmbCil_1.SelectedIndex 'testa fissa o flottante
                                    Case 3, 4
                                        l = 1
                                        Clic = _cmbCil_6.SelectedIndex
                                        If _cmbCil_1.SelectedIndex = 4 Then 'piastre flottanti
                                            Clic = Clic + 2 '2 Fl LM 3 Bifl con est. 4 Bifl senza est.
                                            'fig. 14.2 i sei tipi della stazionaria di un flottante
                                            Select Case Clic
                                                Case 2
                                                    .TipoAA = 105 'AA-3.1b(5)
                                                Case 3
                                                    .TipoAA = 104 'AA-3.1b(4)
                                                Case 4
                                                    .TipoAA = 104 'AA-3.1b(4)
                                                    _LabelCil_22.Visible = False : _TextCil_17.Visible = False
                                                Case 5
                                                    .TipoAA = 101 'AA-3.1b(1)
                                            End Select
                                        Else 'teste fisse
                                            Select Case _cmbCil_6.SelectedIndex
                                                Case 0 : .TipoAA = 6 'AA-2.0(b)
                                                Case 1 : .TipoAA = 5 'AA-2.0(a)
                                                Case 2 : .TipoAA = 7
                                                    MessageBox.Show("Caso di Fig. UHX-13.1(c) non previsto")
                                                Case 3 : .TipoAA = 8
                                                    MessageBox.Show("Caso di Fig. UHX-13.1(d) non previsto")
                                            End Select
                                        End If
                                        CType(.Piastra, wn_FTC).Gasketed(l) = (Clic = 3) Or (Clic = 5 And Not .TipoAA = 101)
                                        CType(.Piastra, wn_FTC).Flangiata(l) = Clic - 1
                                        If _cmbCil_1.SelectedIndex = 4 And CType(.Piastra, wn_FTC).Flangiata(l) = 3 Then
                                            CType(.Piastra, wn_FTC).Flangiata(l) = 2
                                            CType(.Piastra, wn_FTC).Gasketed(l) = 1
                                        ElseIf _cmbCil_1.SelectedIndex = 4 And CType(.Piastra, wn_FTC).Flangiata(l) = 4 Then
                                            CType(.Piastra, wn_FTC).Flangiata(l) = 0
                                            CType(.Piastra, wn_FTC).Gasketed(l) = 0
                                        ElseIf CType(.Piastra, wn_FTC).Flangiata(l) = 3 Then
                                            CType(.Piastra, wn_FTC).Flangiata(l) = 2
                                            CType(.Piastra, wn_FTC).Gasketed(l) = 1 'bifl senza est.
                                        End If
                                        If CType(.Piastra, wn_FTC).Flangiata(l) = 0 Then
                                            For j = 1 To 19
                                                If Not (j = 7 Or j = 8) Then
                                                    .FlChanDati(j) = 0
                                                    .FlShelDati(j) = 0
                                                End If
                                            Next
                                            CType(.Piastra, wn_FTC).Zp(1, 318 + l) = 0.0# 'momento di calcolo=0
                                            CType(.Piastra, wn_FTC).Zp(1, 293 + (l - 1) * (316 - 293)) = 0 'annullamento g di guarn.
                                        End If
                                    Case 5 'piastra per tubi a U non estesa
                                        CType(.Piastra, wn_FTC).Flangiata(1) = 0
                                        Select Case _cmbCil_6.SelectedIndex
                                            Case 0 'Integrale
                                                CType(.Piastra, wn_FTC).Gasketed(1) = 0
                                                .TipoAA = 2
                                            Case 1 'Bifl senza est.
                                                CType(.Piastra, wn_FTC).Gasketed(1) = 1 'bifl. senza est.
                                                .TipoAA = 1
                                            Case 2 'Tipo Breach-Lock
                                                CType(.Piastra, wn_FTC).Gasketed(1) = 2 'tipo BL
                                                .TipoAA = 1
                                                Check2.CheckState = System.Windows.Forms.CheckState.Checked
                                                _Check1_4.CheckState = System.Windows.Forms.CheckState.Checked
                                                Check1_CheckStateChanged(4) '?????????????
                                        End Select
                                        'il perché rimane un mistero
                                End Select
                        End Select
                        AggTab()
                        _Check1_12.Visible = .Rules > 0 And .Piastra.Rear < 3 And RadialExpPossible
                    End With
                Case 7
                    With CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC)
                        If .Rear = 1 Then
                            .Gasketed(2) = (cmbCil(Index).SelectedIndex = 3)
                            .Flangiata(2) = cmbCil(Index).SelectedIndex - 1
                        Else
                            .Flottante = cmbCil(Index).SelectedIndex + 1
                            Select Case .Flottante
                                Case 1 'P - outside packed
                                    .Gasketed(2) = 0
                                    .Flangiata(2) = 1 '0
                                Case 2 'S - with back-ring
                                    .Gasketed(2) = -1
                                    .Flangiata(2) = 2
                                Case 3 'T - Flanged
                                    .Gasketed(2) = 0
                                    .Flangiata(2) = 2 ' -1
                                Case 4 'T - integral
                                    .Gasketed(2) = 0
                                    .Flangiata(2) = 1 ' 0
                                Case 5 'W - internally sealed
                                    .Gasketed(2) = 0
                                    .Flangiata(2) = 2 '  0
                            End Select
                        End If
                    End With
                    AggTab()
                Case 9
                    AggTab2(cmbCil(Index).SelectedIndex > 0)
                    If cmbCil(Index).SelectedIndex = 0 Then _Frames_5.Text = "Dati di progetto"
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Differing = cmbCil(Index).SelectedIndex + 1
                    AggCombo6()
                Case 10 'mantello accoppiato
                    List3.SelectedIndex = cmbCil(Index).SelectedIndex
                    j = GlobalRoutines.ValVir(List3.Text)
                    If j > 0 Then
                        CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).IndiceShell = j
                        Involucr(kLato, jInvolucr).indice(4 - 1) = Involucr(1, j).indice(1 - 1)
                        cmbMatShell.Text = Matdim(Involucr(kLato, jInvolucr).indice(4 - 1)).MatStr
                        _TextCil_86.Text = GlobalRoutines.myStr(Involucr(1, j).Spess * kLength, 4, 3, False)
                        _TextCil_87.Text = GlobalRoutines.myStr(Involucr(1, j).di * kLength, 4, 2, False)
                    Else
                        CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).IndiceShell = 0
                    End If
                Case 11 'tipo FF
                    n = ListIndiciCombo11(_cmbCil_11.SelectedIndex) + 1
                    If n = 6 Then
                        n = 10
                    ElseIf n > 6 Then
                        n = n - 1
                    End If
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).TipoFF = n
                    Figura(i, n)
                Case 12 'regole
                    CType(objMemb(i), wn_PT).Rules = cmbCil(Index).SelectedIndex
                    AggTab()
                    Try
                        If CType(objMemb(i), wn_PT).Rules > 0 And CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 2 Then
                            _LabelCil_102.Visible = True : _TextCil_84.Visible = True 'N° tubi
                            _LabelCil_107.Visible = True : _TextCil_88.Visible = True
                            _LabelCil_101.Visible = True : _TextCil_83.Visible = True 'Lunghezza tubi
                        End If
                        n = CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).TipoFF
                        _Check1_12.Visible = objMemb(i).Rules > 0 And CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear < 3 _
                        And RadialExpPossible
                        Figura(i, n)
                    Catch
                    End Try
                Case 51, 81, 101, 121 'Nome Fl A Nome Fl.B
                    If Index = 51 And Not FlanC Then Exit Sub
                    If Index = 81 And Not FlanM Then Exit Sub
                    If Index = 101 And FlanC Then Exit Sub
                    If Index = 121 And FlanM Then Exit Sub
                    If cmbCil(Index).Enabled Then
                        If cmbCil(Index).SelectedIndex = -1 Then Exit Sub
                        List2(Index).SelectedIndex = cmbCil(Index).SelectedIndex
                        j = System.Math.Abs(Val(List2(Index).Text))
                    Else
                        j = 0
                    End If
                    If Index = 51 Or Index = 101 Then
                        k = 2
                        If Index = 101 And ii = 2 Then
                            If CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 2 Then k = 3
                        End If
                    Else
                        If GlobalRoutines.ValVir(List2(Index).Text) > 0 Then k = 1 Else k = 2
                    End If
                    If Index < 82 Then
                        wn = objMemb(Involucr(k, j).IndObject)
                    End If
                    If Index = 51 Or PiastraAB = 2 Then Indexx = 1 Else Indexx = 2
                    O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                    With O
                        Select Case Index
                            Case 51 'Flangiato TS
                                .IndAccopp(1) = j
                                Involucr(kLato, jInvolucr).IndAccopp(1) = j
                                If kLato = 3 And Involucr(kLato, jInvolucr).Tipo = 6 And PiastraAB = 2 Then
                                    j = CType(.Piastra, wn_FTC).IndiceFlanF
                                    If j > -1 Then wn = objMemb(Involucr(3, j).IndObject)
                                End If
                                TrasferFlanCh(O, wn, j, Indexx)
                                wnbull()
                                .IndAccopp(3) = 0
                                Involucr(kLato, jInvolucr).IndAccopp(3) = 0
                                Involucr(kLato, jInvolucr).indice(5) = Involucr(k, j).indice(0)
                                .FlChanNome = _cmbCil_51.Text 'Nome Fl LT
                            Case 81 'Flangiato SS
                                .IndAccopp(2) = j
                                Involucr(kLato, jInvolucr).IndAccopp(2) = j
                                TrasferFlanSh(O, wn, j, Indexx)
                                wnbull()
                                .IndAccopp(4) = 0
                                Involucr(kLato, jInvolucr).IndAccopp(4) = 0
                                Involucr(kLato, jInvolucr).indice(4) = Involucr(k, j).indice(0)
                                .FlShelNome = _cmbCil_81.Text 'Nome Fl  LM
                            Case 101 'saldato TS
                                .IndAccopp(3) = j
                                Involucr(kLato, jInvolucr).IndAccopp(3) = j
                                .IndAccopp(1) = 0
                                Involucr(kLato, jInvolucr).IndAccopp(1) = 0
                                If j > 0 Then
                                    .SlChanDati(1) = Involucr(k, j).di
                                    .SlChanDati(2) = Involucr(k, j).Spess
                                End If
                                Involucr(kLato, jInvolucr).indice(5) = Involucr(k, j).indice(0)
                                .SlChanNome = _cmbCil_101.Text 'Nome Sald LT
                            Case 121 'saldato SS
                                .IndAccopp(4) = j
                                Involucr(kLato, jInvolucr).IndAccopp(4) = j
                                .IndAccopp(2) = 0
                                Involucr(kLato, jInvolucr).IndAccopp(2) = 0
                                If j > 0 Then
                                    .SlShelDati(1) = Involucr(k, j).di '290506
                                    .SlShelDati(2) = Involucr(k, j).Spess
                                    .SlShelDati(3) = Involucr(k, j).L0
                                End If
                                Involucr(kLato, jInvolucr).indice(4) = Involucr(k, j).indice(0)
                                .SlShelNome = _cmbCil_121.Text 'Nome Sald LM
                        End Select
                    End With
                    AggTesti()
                    AggiornaCollegFl()
                Case 13 'scelta fondo per flottante
                    '_TextCil_91 = Trim(Involucr(iii, j).Mark)
                    List4.SelectedIndex = _cmbCil_13.SelectedIndex
                    With objMemb(Involucr(kLato, jInvolucr).IndObject)
                        j = GlobalRoutines.ValVir(List4.Items(List4.SelectedIndex))
                        .Piastra.IndiceFondo = j
                        If j = 0 Then Exit Sub
                        Select Case .Piastra.Flottante
                            Case 1, 4 'P - outside packed; T - integral
                                For i = 1 To 4
                                    .IndAccopp(i) = 0
                                Next
                                .IndAccopp(3) = j
                                For i = 1 To 4
                                    Involucr(kLato, jInvolucr).IndAccopp2(i) = .IndAccopp(i)
                                Next
                        End Select
                    End With
                    _TextCil_106.Text = GlobalRoutines.myStr(Involucr(iii, j).di * kLength, 5, 2, False)
                    _TextCil_107.Text = GlobalRoutines.myStr(Involucr(iii, j).Spess * kLength, 5, 3, False)
                    If Saltacombo Then Exit Sub
                    jSav = jInvolucr : kSav = kLato
                    Select Case Involucr(iii, j).Tipo
                        Case 2 : DatiCompCon(iii, j, 2)
                        Case 1 : DatiCompFon(iii, j, 2)
                        Case 0 : DatiCompCyl(iii, j, 2)
                    End Select
                    jInvolucr = jSav : kLato = kSav
                Case 14 'scelta flangia per flottante
                    List5.SelectedIndex = _cmbCil_14.SelectedIndex
                    O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                    With O
                        j = GlobalRoutines.ValVir(List5.Items(List5.SelectedIndex))
                        .Piastra.IndiceFlanF = j
                        .IndAccopp(1) = j
                        Involucr(kLato, jInvolucr).IndAccopp2(1) = j
                        Select Case .Piastra.Flottante
                            Case 1 : iii = 2
                            Case Else : iii = 3
                        End Select
                        wn = objMemb(Involucr(iii, j).IndObject)
                        TrasferFlanCh(O, wn, j, 1)
                        .IndAccopp(3) = 0
                        Involucr(kLato, jInvolucr).IndAccopp2(3) = 0
                        TransferDaFondoSuFlan(O, Involucr(iii, j).IndObject)
                    End With
                Case 15 'scelta split ring per flottante
                    List6.SelectedIndex = _cmbCil_15.SelectedIndex
                    O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                    With O
                        j = GlobalRoutines.ValVir(List6.Items(List6.SelectedIndex))
                        If j = 999 Then
                            jSav = jInvolucr : kSav = kLato
                            GeneraSplitR(j, False)
                            jInvolucr = jSav : kLato = kSav
                            _cmbCil_15.Items.Clear()
                            List6.Items.Clear()
                            Dim i1 As Short
                            For i1 = 1 To Config(3).Ninvolucri
                                If Involucr(3, i1).Tipo = 5 Then
                                    _cmbCil_15.Items.Add(Involucr(3, i1).Mark.Trim)
                                    List6.Items.Add(i1.ToString)
                                End If
                            Next
                            _cmbCil_15.Items.Add("Nessuno")
                            List6.Items.Add("0")
                            _cmbCil_15.SelectedIndex = _cmbCil_15.Items.Count - 2
                        End If
                        .Piastra.IndiceSplitR = j
                        .IndAccopp(2) = j
                        Involucr(kLato, jInvolucr).IndAccopp2(2) = j
                        Select Case .Piastra.Flottante
                            Case 1 : iii = 2
                            Case Else : iii = 3
                        End Select
                        wn = objMemb(Involucr(iii, j).IndObject)
                        TrasferFlanSh(O, wn, j, 1)
                        .IndAccopp(4) = 0
                        Involucr(kLato, jInvolucr).IndAccopp2(4) = 0
                    End With
            End Select
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub wnbull()
        If wn Is Nothing Then Exit Sub
        With O
            If wn.Mp(13) > 0 Then
                i2 = 2 : If PiastraAB = 1 And Indexx = 2 Then i2 = 7
                indV = Involucr(k, j).indice(i2 - 1)
                If indV > 0 Then
                    indN = indV
                    Involucr(kLato, jInvolucr).indice(i2 - 1) = indN
                    '080706 Matdim(indN) = Matdim(indV)
                    '080706 Involucr(kLato, jInvolucr).RecInd(i2 - 1) = Involucr(k, j).RecInd(i2 - 1)
                Else
                    CheckMatBull(indN, i2)
                End If
                If i2 = 7 Then
                    cmbMatBoltLM.Text = Matdim(indN).MatStr
                Else
                    cmbMatBoltLT.Text = Matdim(indN).MatStr
                End If
            End If
        End With
        AggTesti()
    End Sub
    Private Sub Figura(ByVal i As Integer, ByRef n As Integer)
        Select Case n
            Case 5
                _LabelCil_114.Visible = True : _TextCil_93.Visible = True
            Case Else
                _LabelCil_114.Visible = False : _TextCil_93.Visible = False
        End Select
        If n > 1 Then n = n - 1
        'If (objMemb(i).Rules = 0 Or objMemb(i).Rules = 2) And n > 0 Then Picture1.Image = ImageList1.Images(n)
        Picture1.Image = ImageList1.Images(n)
    End Sub
    Private Sub Stacca(ByVal i As Integer)
        iDil = CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).IndiceDilat
        If iDil > -1 Then
            With Involucr(1, iDil)
                objMemb(.IndObject) = New wn_PT
                CType(objMemb(.IndObject), wn_PT).TipoPT = 2
                CType(objMemb(.IndObject), wn_PT).Piastra = New wn_FTC
                CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).SoloDilat = True
                CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).objDilat = New wn_Dilat
            End With
            k = kLato : j = jInvolucr
            kLato = 1 : jInvolucr = iDil
            TrasfDilat() 'Look
            kLato = k : jInvolucr = j
        End If
        objMemb(i).Piastra.IndiceDilat = -1
        CheckCollegamenti()
    End Sub
    Private Sub UTEMA(ByVal i As Short, ByVal SelectedIndex As Integer)
        TipoPiastra = 1
        _LabelCil_110.Visible = False : _TextCil_90.Visible = False 'diam dilat max
        _LabelCil_100.Visible = False : _TextCil_82.Visible = False
        Dim Log1 As Boolean = (objMemb(i).TipCalc = 0 And objMemb(i).Rules <> 1) '030506
        _LabelCil_9.Visible = Log1 : _TextCil_4.Visible = Log1 '030506
        _LabelCil_24.Visible = True : _TextCil_19.Visible = True
        _Check1_3.Visible = True
        _Check1_8.Visible = False
        _LabelCil_85.Visible = False : _cmbCil_6.Visible = False
        Check2.Visible = SelectedIndex = 2
        If objMemb(i).SlChanDati(1) = -2 Then   '170206
            Check2.CheckState = CheckState.Checked
        Else
            Check2.CheckState = CheckState.Unchecked
        End If
    End Sub
    Private Sub CheckMatBull(ByRef indice As Short, ByRef j As Short)
        indice = Involucr(kLato, jInvolucr).indice(j - 1)
        If indice < 1 Then
            indice = NuovoIndice()
            Matdim(indice) = New LibMat.MaterialeNew1
            Involucr(kLato, jInvolucr).indice(j - 1) = indice
            indici.Add(indice)
        End If
    End Sub
    Private Sub cmdCil_Click(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim indice As Short
        Dim t As Single
        Dim g As LibMat.clsGuarn
        Dim TIR As LibMat.clsTira
        Dim i As Short
        Dim P0 As Single
        Dim Res As Short
        Dim File As String
        Dim ii, TipoPasso As Short
        Dim ic As Short
        Dim Classe As Short
        Dim objTraccia As traccia.clsTracciatura
        If TabStrip2.Visible Then
            ii = TabStrip2.SelectedIndex + 1
        Else
            ii = 1
        End If
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            Select Case Index
                Case 0 'Materiale P.T.
                    indice = Involucr(kLato, jInvolucr).indice(1 - 1)
                    Classe = Matdim(indice).Classe
                    If Classe = 0 Then Classe = 7
                    MatdimScelta(indice, Classe, kLato, jInvolucr)
                    If Matdim(indice).Editato Then Uniforma(indice)
                    Involucr(kLato, jInvolucr).MATE = Matdim(indice).MatStr
                    PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(0))
                    .MatPias(1) = cmbMat.Text
                    AmmissP()
                Case 9 '2a piastra
                    CheckMatBull(indice, 3)
                    Classe = Matdim(indice).Classe
                    MatdimScelta(indice, Classe, kLato, jInvolucr)
                    If Matdim(indice).Editato Then Uniforma(indice)
                    PostSelMat(cmbMat2, indice)
                    .MatPias(2) = cmbMat2.Text
                    AmmissP2()
                Case 13 'mantello
                    CheckMatBull(indice, 4)
                    MatdimScelta(indice, Matdim(indice).Classe, kLato, jInvolucr)
                    If Matdim(indice).Editato Then Uniforma(indice)
                    PostSelMat(cmbMatShell, indice)
                    ' .MatPias(2) = _TextCil_81
                    'GoSub AmmissP2
                Case 1, 2, 4, 5, 6, 401, 402, 406
                    Select Case ii
                        Case 1, 2 ' la variabile Indprobl si incarica di indirizzare i dati
                            ' sulla piastra di testa o su quella di coda per le guarnizioni
                            ' i bulloni sono invece unici ed identici (se ci sono) fra testa e coda
                            ' metteremo invece i bulloni LT in indice(2) E I BULLONI LM IN INDICE(6)
                            Select Case Index
                                Case 4 'guarnizione TS
                                    g = New LibMat.clsGuarn
                                    g.Class = .ClassGsk(1)
                                    g.Tipo = .TipGsk(1)
                                    g.Face = .IndFac(1)
                                    ' g.Alfa = .Mp(201)
                                    ' g.Radius = .Mp(202)
                                    ' g.Height = .Mp(203)
                                    'g.Formula = .Zp(31)
                                    g.Formula = .FlChanDati(20)
                                    g.Scelta((clsInizio.Archdir), (clsInizio.DiscoTem))
                                    TextCil(38).Text = g.ClassS
                                    TextCil(39).Text = g.TipoS
                                    .ClassGsk(1) = g.Class
                                    .TipGsk(1) = g.Tipo
                                    .IndFac(1) = g.Face
                                    TextCil(41).Text = GlobalRoutines.myStr(g.y, 5, 0, False)
                                    TextCil(40).Text = GlobalRoutines.myStr(g.m, 3, 2, False)
                                    .FlChanDati(20) = g.Formula
                                    NubbinVisible(.mart)
                                    g = Nothing
                                Case 5 'guarnizione SS
                                    g = New LibMat.clsGuarn
                                    g.Class = .ClassGsk(2)
                                    g.Tipo = .TipGsk(2)
                                    g.Face = .IndFac(2)
                                    ' g.Alfa = .Mp(201)
                                    ' g.Radius = .Mp(202)
                                    ' g.Height = .Mp(203)
                                    g.Formula = .FlShelDati(20)
                                    g.Scelta((clsInizio.Archdir), (clsInizio.DiscoTem))
                                    TextCil(68).Text = g.ClassS
                                    TextCil(69).Text = g.TipoS
                                    .ClassGsk(2) = g.Class
                                    .TipGsk(2) = g.Tipo
                                    .IndFac(2) = g.Face
                                    _TextCil_71.Text = GlobalRoutines.myStr(g.y, 5, 0, False)
                                    _TextCil_70.Text = GlobalRoutines.myStr(g.m, 3, 2, False)
                                    .FlShelDati(20) = g.Formula
                                    NubbinVisible(.mart)
                                    g = Nothing
                                Case 1, 401 'materiale bulloni LT e LM
                                    i = 1 : If Index = 401 Then i = 2
                                    CheckMatBull(indice, 2 + 5 * (i - 1))
                                    MatdimScelta(indice, 8, kLato, jInvolucr)
                                    If Matdim(indice).Editato Then Uniforma(indice)
                                    Involucr(kLato, jInvolucr).MATE = Matdim(indice).MatStr
                                    '080706 Involucr(kLato, jInvolucr).RecInd(indice) = Matdim(indice).Indmat
                                    If i = 1 Then
                                        PostSelMat(cmbMatBoltLT, indice)
                                        .MatBull(i) = cmbMatBoltLT.Text
                                        '                                If Not .Piastra Is Nothing Then
                                        '                                        Select Case .TipoPT
                                        '                                            Case 1
                                        '                                        CType(.Piastra, wn_UTEMA).MatBull(i) = cmbMatBoltLT.Text
                                        '                                            Case 2
                                        '                                        CType(.Piastra, wn_FTC).MatBull(i) = cmbMatBoltLT.Text
                                        '                                        End Select
                                        '                                    End If
                                    Else
                                        PostSelMat(cmbMatBoltLM, indice) 'era 401
                                        .MatBull(i) = cmbMatBoltLM.Text
                                        '                                    If Not .Piastra Is Nothing Then
                                        '                                        Select Case .TipoPT
                                        '                                            Case 1, 2
                                        '                                        CType(.Piastra, wn_FTC).MatBull(i) = cmbMatBoltLM.Text
                                        '                                        End Select
                                        '                                    End If
                                    End If
                                    AmmissB(i)
                                Case 2, 402 'diametro nominale bulloni
                                    i = 1 : If Index = 402 Then i = 2
                                    TIR = New LibMat.clsTira
                                    TIR.Xfil = .XFil(i)
                                    TIR.DN = .DiNBull(i)
                                    TIR.Scelta((clsInizio.Archdir), (clsInizio.DiscoTem))
                                    TextCil(5 + (i - 1) * 400).Text = TIR.DN
                                    .XFil(i) = TIR.Xfil
                                    TextCil(11 + (i - 1) * 400).Text = GlobalRoutines.myStr(TIR.BSmin * kLength, 3, 2, False)
                                    TextCil(12 + (i - 1) * 400).Text = GlobalRoutines.myStr(TIR.Emin * kLength, 3, 2, False)
                                    TextCil(9 + (i - 1) * 400).Text = GlobalRoutines.myStr((TIR.Diam / inc) ^ 2 * pi / 4 * kLength * kLength, 3, 4, False)
                                    TIR = Nothing
                                Case 6, 406
                                    i = 1 : If Index = 406 Then i = 2
                                    AmmissB(i) 'amm bulloni
                            End Select
                    End Select
                    Select Case ii 'nel caso si decidesse di differenziare i bulloni
                        'quando presenti su entrambe le piastre (differing)
                    Case 1
                            Select Case Index ' piastra di testa
                                'da fare Index=2 dn, 1 materiale, 6 ammissibile
                            End Select
                        Case 2 'piastra di coda
                            'da fare Index=2 dn, 1 materiale, 6 ammissibile
                    End Select
                Case 7
                    AmmissP() 'amm piastra
                Case 8
                    AmmissP2() 'amm piastra
                Case 11, 12, 16
                    For i = 1 To Config(3).Ninvolucri
                        If Involucr(3, i).Tipo = 7 Then
                            _TextCil_20.Text = GlobalRoutines.myStr(Involucr(3, i).dns * kLength, 3, 2, False)
                            _TextCil_82.Text = GlobalRoutines.myStr(Involucr(3, i).Spess * kLength, 2, 3, False)
                            _TextCil_83.Text = GlobalRoutines.myStr(Involucr(3, i).L0 * kLength, 5, 2, False)
                            File = GenFile(i)
                            If File = "" Then Exit Sub
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                            objTraccia = New traccia.clsTracciatura
                            objTraccia.DoveMotore = Monitor.Motore
                            Res = objTraccia.Esegui(3, File)
                            If Res = 1 Then
                                MessageBox.Show(Me, "Il file " & File & " non è stato trovato: accedere alla tracciatura nelle finestra relativa ai dati sui tubi di scambio")
                            ElseIf Res = 2 Then
                                MessageBox.Show(Me, "La tracciatura " & File & " non possiede i dati finali: accedere alla tracciatura nelle finestra relativa ai dati sui tubi di scambio")
                            Else
                                If Index <= 12 Then objTraccia.Calc4SsP(File, 0)
                            End If
                            If Res = 0 Then
                                _TextCil_84.Text = GlobalRoutines.myStr(objTraccia.NumeroTubi, 5, 0, True)
                                _TextCil_21.Text = GlobalRoutines.myStr(objTraccia.Passo * kLength, 3, 3, False)
                                TipoPasso = objTraccia.TipoPasso
                                _cmbCil_5.SelectedIndex = TipoPasso - 1
                                Select Case Index
                                    Case 12
                                        _TextCil_22.Text = GlobalRoutines.myStr(objTraccia.Diaml * kLength, 5, 2, False)
                                        .Calc7133 = True
                                    Case 16
                                        _TextCil_94.Text = GlobalRoutines.myStr(objTraccia.OTL * kLength, 5, 2, False)
                                    Case 11
                                        _TextCil_101.Text = GlobalRoutines.myStr(System.Math.Sqrt(4 * objTraccia.Area / pi * kLength * kLength), 5, 1, False)
                                End Select
                            Else
                                If Index = 12 Then .Calc7133 = False
                            End If
                            objTraccia = Nothing
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            Exit Sub
                        End If
                    Next
                    MessageBox.Show(Me, "Impossibile procedere, poiché non è stato" & vbCrLf & "ancora introdotto l'elemento 'tubi di scambio'")
                    '      Case 14 'fondo flottante
                    '         ScelFonF
                    '      Case 15
                    '         ScelSplitR
                Case 24 : TextCil(Index).Text = GlobalRoutines.myStr(Config(2).Corr * kLength, 4, 2, False) 'Corr  TS
                Case 25 : TextCil(Index).Text = GlobalRoutines.myStr(Config(1).Corr * kLength, 4, 2, False) 'Corr  SS
                Case 26
                    AggiustaHydr(2, jInvolucr, 0, P0, VerificandoPI)
                    ic = 0 : If VerificandoPI Then ic = 3
                    TextCil(Index + ic).Text = GlobalRoutines.myStr(P0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) 'DesPr TS
                Case 27
                    ic = 0 : If VerificandoPI Then ic = 3
                    AggiustaHydr(1, jInvolucr, 0, P0, VerificandoPI)
                    TextCil(Index + ic).Text = GlobalRoutines.myStr(P0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) 'DesPr SS
                Case 29 : TextCil(Index).Text = GlobalRoutines.myStr(Config(2).pxTest * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) 'HT Pr TS
                Case 30 : TextCil(Index).Text = GlobalRoutines.myStr(Config(1).pxTest * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) 'HT Pr SS
                Case 31 'Design Temp
                    t = Config(1).tdx
                    If Config(2).tdx > t Then t = Config(2).tdx
                    TextCil(Index).Text = GlobalRoutines.myStr(t * kTemp + kTemp32, 4, 2, False)
                Case 32 'Vacuum
                    If Config(1).Vacuum Then _Check1_7.CheckState = CheckState.Checked Else _Check1_7.CheckState = CheckState.Unchecked
                    If Config(2).Vacuum Then _Check1_6.CheckState = CheckState.Checked Else _Check1_6.CheckState = CheckState.Unchecked
                Case 151, 181, 201, 221 'materiale membro accoppiato
                    Select Case Index
                        Case 151, 201 : ii = 6 'Lato tubi
                        Case 181, 221 : ii = 5 'LM
                    End Select
                    Select Case Index
                        Case 151, 181 : ic = 7 'flangia
                        Case 201, 221 : ic = 1 'mantello
                    End Select
                    With Involucr(kLato, jInvolucr)
                        If .indice(ii - 1) <= 0 Then
                            .indice(ii - 1) = NuovoIndice()
                            Matdim(.indice(ii - 1)) = New LibMat.MaterialeNew1
                            indici.Add(.indice(ii - 1))
                        End If
                        If Matdim(.indice(ii - 1)).Classe > 0 Then ic = Matdim(.indice(ii - 1)).Classe
                        MatdimScelta(.indice(ii - 1), ic, kLato, jInvolucr)
                        Dim c As ComboBox
                        Select Case Index
                            Case 151 : c = cmbMatFlLT
                            Case 181 : c = cmbMatFlLM
                            Case 201 : c = cmbMatSlLT
                            Case 221 : c = cmbMatSlLM
                        End Select
                        PostSelMat(c, .indice(ii - 1))
                        'TextCil(Index).Text = Matdim(.indice(ii - 1)).MatStr
                        '080706 .RecInd(ii) = Matdim(.indice(ii - 1)).Indmat
                        If Matdim(.indice(ii - 1)).Editato Then Uniforma(.indice(ii - 1))
                    End With
            End Select
        End With
    End Sub
    Private Sub AmmissB(ByVal i As Short)
        Dim m = Matdim(Involucr(kLato, jInvolucr).indice(2 + 5 * (i - 1) - 1))
        If m.Indmat > 0 Or Not m.agganciato Then
            td1 = Involucr(kLato, jInvolucr).Destemp
            m.SigmaAmm(CodiceStress, td1, AllBRoo, AllBOpe)
            TextCil(16 + (i - 1) * 400).Text = GlobalRoutines.myStr(AllBOpe * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            TextCil(15 + (i - 1) * 400).Text = GlobalRoutines.myStr(AllBRoo * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        End If 'n
    End Sub
    Private Sub AmmissP2()
        Dim m = Matdim(Involucr(kLato, jInvolucr).indice(3 - 1))
        If m.Indmat > 0 Or Not m.agganciato Then
            td1 = Involucr(kLato, jInvolucr).Destemp
            If Not VerificandoPI Then
                m.SigmaAmm(CodiceStress, td1, AllBRoo, AllBOpe)
                _TextCil_60.Text = GlobalRoutines.myStr(AllBOpe * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                _TextCil_61.Text = GlobalRoutines.myStr(AllBRoo * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                AllBhyd = m.Yield() * FractSyPI ' / mpa
                _TextCil_60.Text = GlobalRoutines.myStr(AllBhyd * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
        End If 'n
    End Sub
    Private Sub AmmissP()
        savDiv = Config(0).DiverseTemp
        Config(0).DiverseTemp = 1
        Ammiss(jInvolucr)
        If VerificandoPI Then
            _TextCil_8.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
        Else
            _TextCil_8.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
            _TextCil_14.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
        End If
        Config(0).DiverseTemp = savDiv
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim i As Short
        Dim O As wn_PT
        O = objMemb(Involucr(kLato, jInvolucr).IndObject)
        O.CopiaTiranti()
        If TipoPiastra = 2 Then O.SetPiastra(1)
        For i = 1 To 4
            Involucr(kLato, jInvolucr).IndAccopp(i) = O.IndAccopp(i)
        Next
        If TipoPiastra = 2 Then
            O.SetPiastra(2)
            For i = 1 To 4
                Involucr(kLato, jInvolucr).IndAccopp2(i) = O.IndAccopp(i)
            Next
            O.SetPiastra(1)
            If CType(O.Piastra, wn_FTC).Differing = 2 And CType(O.Piastra, wn_FTC).Rear = 1 Then
                EqualPiastre((O.Piastra))
            End If
        End If
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        Hide()
    End Sub
    Public Sub TEMAAA(ByVal Visibile As Boolean, ByVal VisTEMA As Boolean)
        Try
            Dim O As wn_PT = objMemb(Involucr(kLato, jInvolucr).IndObject)
            LabelCil(28).Visible = VisTEMA
            _TextCil_22.Visible = VisTEMA
            cmdCil(12).Visible = VisTEMA
            _LabelCil_116.Visible = Visibile : _TextCil_94.Visible = Visibile : _cmdCil_16.Visible = Visibile
            _LabelCil_123.Visible = VisTEMA : _TextCil_101.Visible = VisTEMA : _cmdCil_11.Visible = VisTEMA
            _LabelCil_117.Visible = Visibile : _TextCil_95.Visible = Visibile
            _Check1_11.Visible = Visibile
            Dim OFTCIBW As Boolean
            If O.TipoPT = 2 Then
                Dim OFTC As wn_FTC = O.Piastra
                OFTCIBW = OFTC.IBW
            End If
            framltx.Visible = Visibile And Not OFTCIBW
            labIBW.Visible = Visibile And OFTCIBW
            LabIBWmm.Visible = Visibile And OFTCIBW
            txtIBW.Visible = Visibile And OFTCIBW
            _LabelCil_102.Visible = (Visibile Or VisTEMA) And O.TipoPT = 2
            _TextCil_84.Visible = (Visibile Or VisTEMA) And O.TipoPT = 2  'N° tubi
            _LabelCil_107.Visible = (Visibile Or VisTEMA) And O.TipoPT = 2
            _TextCil_88.Visible = (Visibile Or VisTEMA) And O.TipoPT = 2  'lungh.libera
            _LabelCil_100.Visible = (Visibile Or VisTEMA) And O.TipoPT = 2
            _TextCil_82.Visible = (Visibile Or VisTEMA) And O.TipoPT = 2
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Attivata()
        Dim i As Short
        '*********************************************************    'AggCheck
        SuperAggiorna()
        Aggdestemp(False)
        '*******************************************************************
        i = Involucr(kLato, jInvolucr).IndObject
        If TipoPiastra = 2 Then
            AggTab2(CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Differing > 1)
        End If
        SuperVisibili()
        AggTab()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub SuperVisibili()
        Dim i As Short = Involucr(kLato, jInvolucr).IndObject
        Dim ptRules As Integer = CType(objMemb(i), wn_PT).Rules
        Dim VisTEMA As Boolean = ptRules <> 1
        Dim Visibile As Boolean = ptRules > 0
        TEMAAA(Visibile, VisTEMA)
        If VerificandoPI Then
            LabelCil(19).Visible = False
            LabelCil(93).Visible = False
            _TextCil_14.Visible = False
            _TextCil_60.Visible = False
            LabelCil(14).Text = "Allowable stress in H.T."
            LabelCil(94).Text = "Allowable stress in H.T."
        End If
        If Not _Check1_9.Visible Then
            CType(objMemb(i), wn_PT).BullDistinti = False
            _Check1_10.Visible = False
        End If
    End Sub
    Private Sub optColl_CheckedChanged(ByVal Index As Short, ByVal Checked As Boolean)
        If Inizializzando Then Exit Sub
        If Checked Then
            Dim i As Short
            Dim PT As wn_PT
            PT = objMemb(Involucr(kLato, jInvolucr).IndObject)
            i = 1 : If _optColl_1.Checked Then i = -1
            PT.NumColl(1) = i * System.Math.Abs(PT.NumColl(1))
        End If
    End Sub
    Private Sub Option1_CheckedChanged(ByVal Index As Short, ByVal Checked As Boolean)
        If Inizializzando Then Exit Sub
        If Checked Then
            With CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
                If _Option1_0.Checked Then 'Select Case Index
                    ' Case 0: 'straight
                    .Zp(1, 307) = 0
                    _LabelCil_106.Text = "Shell internal diameter"
                    chkCalcFBM.CheckState = System.Windows.Forms.CheckState.Checked
                    chkCalcFBM.Visible = False
                    _LabelCil_104.Text = "Shell thickness"
                Else
                    'Case 1: 'Kettle
                    If GlobalRoutines.ValVir(_TextCil_87.Text) > 0 Then .Zp(1, 307) = GlobalRoutines.ValVir(_TextCil_87.Text) '.Zp(1, 21)
                    .Zp(1, 21) = .Zp(1, 588)
                    _LabelCil_106.Text = "Kettle internal diameter"
                    chkCalcFBM.CheckState = System.Windows.Forms.CheckState.Unchecked
                    chkCalcFBM.Visible = False 'True
                    _LabelCil_104.Text = "Kettle thickness"
                End If 'Select
                chkCalcFBM_CheckStateChanged(chkCalcFBM, New System.EventArgs)
            End With
        End If
    End Sub
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim i As Short
        Dim V As Single
        Dim PT As wn_PT
        If Aggiornando Then Exit Sub
        PT = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
        With PT
            Select Case Index
                Case 0 : .MatPias(1) = TextCil(Index).Text 'mat 2a piastra
                Case 401 To 416
                    Select Case Index
                        Case 401 : .MatBull(2) = TextCil(Index).Text 'mat bulloni
                        Case 402 : If GlobalRoutines.ValVir(TextCil(Index).Text) < 1 Then TextCil(Index).Text = GlobalRoutines.myStr(1.1, 1, 1, False)
                            .SicBullp(2) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 403 : If GlobalRoutines.ValVir(TextCil(Index).Text) > 0.69 Then TextCil(Index).Text = GlobalRoutines.myStr(0.69, 1, 2, False)
                            .FattBoltSy(2) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 404 : .Rapporto(2) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 405 : .DiNBull(2) = TextCil(Index).Text
                        Case 406 : .NumBolt(2) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 407 : .BoltCiD(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 409 : .AreBolt(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength / kLength
                        Case 411 : .BSpcMin(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 412 : .BRadMin(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 413 : i = System.Math.Sign(.NumColl(2))
                            If i = 0 Then i = 1
                            .NumColl(2) = i * GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 415 : .AllBRoo(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm bull @room
                        Case 416 : .AllBOpe(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm bull @temp
                    End Select
                Case 1 To 7, 9, 11 To 13, 15, 16, 32 To 51, 54, 62 To 80, 92, 94 To 96, 102 To 103, 106 To 110, 122 To 123
                    Select Case Index
                        Case 1 : .MatBull(1) = TextCil(Index).Text 'mat bulloni
                        Case 2 : If GlobalRoutines.ValVir(TextCil(Index).Text) < 1 Then TextCil(Index).Text = GlobalRoutines.myStr(1.1, 1, 1, False)
                            .SicBullp(1) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 3 : If GlobalRoutines.ValVir(TextCil(Index).Text) > 0.69 Then TextCil(Index).Text = GlobalRoutines.myStr(0.69, 1, 2, False)
                            .FattBoltSy(1) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 4 : .Rapporto(1) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 5 : .DiNBull(1) = TextCil(Index).Text
                        Case 6 : .NumBolt(1) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 7 : .BoltCiD(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 9 : .AreBolt(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength / kLength
                        Case 11 : .BSpcMin(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 12 : .BRadMin(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 13 : i = System.Math.Sign(.NumColl(1))
                            If i = 0 Then i = 1
                            .NumColl(1) = i * GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 15 : .AllBRoo(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm bull @room
                        Case 16 : .AllBOpe(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm bull @temp
                        Case 38, 39
                            .FlChanDati(Index - 31) = TextCil(Index)
                        Case 32 To 37, 40 To 50
                            .FlChanDati(Index - 31) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(Index - 31)
                        Case 94 : .OTL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 95 : .UL = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength / kLength
                        Case 96
                            If .ltxperc Then
                                .ltx = GlobalRoutines.ValVir(TextCil(Index).Text)
                            Else
                                .ltx = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                            End If
                            'Case 33: '2Di Fl A
                            'Case 34: '3g1 Fl A
                            'Case 35: '4g0 Fl A
                            'Case 36: '5Dmed gua A
                            'Case 37: '6N     A
                            'Case 38: '7Tip gua  A
                            'Case 39: '8Mat gua  A
                            'Case 40: '9m        A
                            'Case 41: '10Y     A
                            'Case 42: '11m trav   A
                            'Case 43: '12Y trav   A
                            'Case 44: '13l trav   A
                            'Case 45: '14b trav   A
                            'Case 46: 'Wm1      A
                            'Case 47: 'W        A
                            'Case 48: 'W   HT   A
                            'Case 49: 'Wm2 HT   A
                            'Case 50: 'Gef  Fl A
                        Case 108
                            .FlChanDati(21) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(21) 'W
                        Case 92
                            .FlChanDati(22) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(22) 'W HT
                        Case 51 : .wn(2) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 54 : .wn(1) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 68, 69
                            .FlShelDati(Index - 61) = TextCil(Index).Text
                        Case 62 To 67, 60 To 80
                            .FlShelDati(Index - 61) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(Index - 61)
                            'Case 63: 'Di Fl B
                            'Case 64: 'g1 Fl B
                            'Case 65: 'g0 Fl B
                            'Case 66: 'Dmed gua B
                            'Case 67: 'N     B
                            'Case 68: 'Tip gua  B
                            'Case 69: 'Mat gua  B
                            'Case 70: 'm        B
                            'Case 71: 'Y     B
                            'Case 72: 'm trav   B
                            'Case 73: 'Y trav   B
                            'Case 74: 'l trav   B
                            'Case 75: 'b trav   B
                            'Case 76: 'Wm1      B
                            'Case 77: 'Wm2      B
                            'Case 78: 'Wm1 HT   B
                            'Case 79: 'Wm2 HT   B
                            'Case 80: 'Gef  Fl B
                        Case 110
                            .FlShelDati(21) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(21) 'W
                        Case 109
                            .FlShelDati(22) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(22) 'W HT
                        Case 102 To 103
                            .SlChanDati(Index - 101) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(Index - 101) ' Di A
                        Case 106 To 107
                            .SlChanDati(Index - 105) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(Index - 105)
                        Case 122 To 123
                            .SlShelDati(Index - 121) = GlobalRoutines.ValVir(TextCil(Index).Text) / .FlDatik(Index - 121)
                            'Case 123: 'Spess B
                    End Select
                Case 8
                    If VerificandoPI Then
                        Involucr(kLato, jInvolucr).Shydr = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        Involucr(kLato, jInvolucr).S0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                    .AllFRoo = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm piastra @room
                Case 10 : Involucr(kLato, jInvolucr).HydrDepth = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 14 : .AllFOpe = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm piastra @temp
                    Involucr(kLato, jInvolucr).St = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 17 : .TSheDes = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxdiamext
                Case 18 : .TSheThk = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxspessore
                Case 19 : .TExtThk = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxspess ext
                Case 20
                    .TubDiam = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxdiametro esterno tubi
                Case 21 : .TubPass = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxpasso tubi
                Case 22 : .EquDiam = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxDL
                Case 23 : .CavChan1 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxprof cava T.S.
                Case 24 : .CorChan = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'CorrTS
                Case 25 : .CorShel = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'Corr SS
                Case 26 : .PDesChan = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 27 : .PDesShel = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 28 : Involucr(kLato, jInvolucr).HydrDepth2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'Hydro SS
                Case 29 : .PHTChan = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 30 : .PHTShel = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 31 : .Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp 'DesTemp
                    Involucr(kLato, jInvolucr).Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
                Case 52 : .DiffPress = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'diffpress
                    AggiustaDiff()
                Case 91 : .DiffPressHT = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'diffpress
                Case 53 : .CavShel1 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'xxxprof cava S.S.
                Case 60
                    CType(.Piastra, wn_FTC).AllFOpe2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm bull @temp
                Case 61
                    CType(.Piastra, wn_FTC).AllFRoo2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress 'amm bull @room
                Case 81 : .MatPias(2) = TextCil(Index).Text 'mat 2a piastra
                Case 82 : .TubSpess = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 55 To 59, 83 To 90, 93, 101
                    Select Case Index
                        Case 55
                            CType(.Piastra, wn_FTC).CavShel2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 56
                            CType(.Piastra, wn_FTC).CavChan2 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 57
                            CType(.Piastra, wn_FTC).Zp(1, 289) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 58
                            CType(.Piastra, wn_FTC).Zp(1, 262) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 59
                            CType(.Piastra, wn_FTC).Zp(1, 309) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 101
                            CType(.Piastra, wn_FTC).Zp(1, 592) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 83
                            CType(.Piastra, wn_FTC).Zp(1, 30) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 84
                            CType(.Piastra, wn_FTC).Zp(1, 29) = GlobalRoutines.ValVir(TextCil(Index).Text)
                        Case 86
                            If CType(.Piastra, wn_FTC).Differing > 1 Then
                                V = GlobalRoutines.ValVir(TextCil(123).Text)
                            Else
                                V = 0
                            End If
                            If GlobalRoutines.ValVir(TextCil(Index).Text) > V Then V = GlobalRoutines.ValVir(TextCil(Index).Text)
                            .SpessMant = V / kLength 'Piastra.Zp(1, 23)
                        Case 87
                            If _Option1_0.Checked And GlobalRoutines.ValVir(List3.Text) > 0 Then
                                V = GlobalRoutines.ValVir(TextCil(122).Text)
                                If GlobalRoutines.ValVir(TextCil(Index).Text) > V Then V = GlobalRoutines.ValVir(TextCil(Index).Text)
                                CType(.Piastra, wn_FTC).Zp(1, 21) = V / kLength
                                CType(.Piastra, wn_FTC).Zp(1, 307) = 0
                            ElseIf Not _Option1_0.Checked Then
                                CType(.Piastra, wn_FTC).Zp(1, 307) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                                ' ctype(.Piastra,wn_FTC).Zp(1, 21) = 0
                            Else
                                'ctype(.Piastra,wn_FTC).Zp(1, 307) = GlobaLroutines.ValVir(TextCil(Index))
                            End If
                        Case 88
                            CType(.Piastra, wn_FTC).Zp(1, 39) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                        Case 90
                            CType(.Piastra, wn_FTC).Zp(1, 26) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                            If GlobalRoutines.ValVir(TextCil(Index).Text) <= 0 Then
                                _cmbCil_4.SelectedIndex = 0
                            End If
                        Case 93
                            CType(.Piastra, wn_FTC).hr = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                            If CType(.Piastra, wn_FTC).IndiceFlanF > 0 Then objMemb(Involucr(3, CType(.Piastra, wn_FTC).IndiceFlanF).IndObject).Mp(125) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    End Select
                    On Error GoTo 0
                Case 100
                    CType(.Piastra, wn_FTC).Zp(1, 583) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'lungh. cilindro kettle
                Case 104
                    CType(.Piastra, wn_FTC).Zp(1, 584) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'lunghezza coni Kettle
                Case 105
                    CType(.Piastra, wn_FTC).Zp(1, 585) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'spessore coni Kettle
                Case 97
                    CType(.Piastra, wn_FTC).Zp(1, 586) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'spessore ports
                Case 98
                    CType(.Piastra, wn_FTC).Zp(1, 587) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength 'lunghezza ports
                Case 99
                    CType(.Piastra, wn_FTC).Zp(1, 588) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength ' diametro ports
                    CType(.Piastra, wn_FTC).Zp(1, 21) = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength ' diametro ports
                Case 112, 113
                    .GrvShel = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 111, 114
                    .GrvChan = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
            End Select
        End With
    End Sub
    Public Sub AggCheck()
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            If .Verbose Then _Check1_0.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_0.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .DiffPIese(1) Then _Check1_1.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_1.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .CRUSH(1) Then _Check1_2.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_2.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .DiffPIese(2) Then Check1(401).CheckState = System.Windows.Forms.CheckState.Checked Else Check1(401).CheckState = System.Windows.Forms.CheckState.Unchecked
            If .CRUSH(2) Then Check1(402).CheckState = System.Windows.Forms.CheckState.Checked Else Check1(402).CheckState = System.Windows.Forms.CheckState.Unchecked
            If .FLEX Then _Check1_3.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_3.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .mart Then _Check1_4.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_4.CheckState = System.Windows.Forms.CheckState.Unchecked : Check1_CheckStateChanged(4)
            If .ProgDiffPr Then _Check1_5.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_5.CheckState = System.Windows.Forms.CheckState.Unchecked : Check1_CheckStateChanged(5)
            If .VacuumTS Then _Check1_6.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_6.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .VacuumSS Then _Check1_7.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_7.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .BullDistinti Then _Check1_9.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_9.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .BullIndip Then _Check1_10.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_10.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .IBW Then _Check1_11.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_11.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .RadialExp Then _Check1_12.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_12.CheckState = System.Windows.Forms.CheckState.Unchecked
            If .Piastra.Documented = 2 Then _Check1_8.CheckState = System.Windows.Forms.CheckState.Checked Else _Check1_8.CheckState = System.Windows.Forms.CheckState.Unchecked
        End With
        SuperVisibili()
    End Sub
    Private Function RadialExpPossible() As Boolean
        Dim O As wn_PT = objMemb(Involucr(kLato, jInvolucr).IndObject)
        If O.TipoPT = 1 Then Return False
        Dim O1 As wn_FTC = O.Piastra
        If O1.Rear = 3 Then Return False 'U
        If O1.Flangiata(1) < 2 Then Return True
        If O1.Differing > 1 Then If O1.Flangiata(2) < 2 Then Return True
        Return False
    End Function
    Public Sub AggTesti()
        Dim i, n As Short
        Dim PT As wn_PT
        Aggiornando = True
        Try
            i = Involucr(kLato, jInvolucr).indice(1 - 1)
            If i > 0 Then
                If Not Matdim(i).MatStr Is Nothing Then
                    cmbMat.Text = Matdim(i).MatStr.Trim
                    chkAgganciato1.Checked = Matdim(i).Agganciato
                Else
                    cmbMat.Text = ""
                End If
            Else
                cmbMat.Text = ""
            End If
            i = Involucr(kLato, jInvolucr).indice(3 - 1)
            If i > 0 Then
                If Not Matdim(i).MatStr Is Nothing Then
                    cmbMat2.Text = Matdim(i).MatStr.Trim
                    chkAgganciato2.Checked = Matdim(i).Agganciato
                Else
                    cmbMat2.Text = ""
                End If
            Else
                cmbMat2.Text = ""
            End If
            PT = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            With PT
                If PiastraAB = 0 Then PiastraAB = 1 : .SetPiastra(1)
                i = Involucr(kLato, jInvolucr).indice(2 - 1)
                cmbMatBoltLT.Text = ""
                If i > -1 Then
                    If i <= UBound(Matdim) Then
                        If Not Matdim(i) Is Nothing Then
                            If Not Matdim(i).MatStr Is Nothing Then
                                cmbMatBoltLT.Text = Matdim(i).MatStr.Trim
                                Me.chkAggancBoltLT.Checked = Matdim(i).Agganciato
                            End If
                        End If
                    End If
                End If
                i = Involucr(kLato, jInvolucr).indice(7 - 1)
                cmbMatBoltLM.Text = ""
                If i > -1 Then
                    If i <= UBound(Matdim) Then
                        If Not Matdim(i) Is Nothing Then
                            If Not Matdim(i).MatStr Is Nothing Then
                                cmbMatBoltLM.Text = Matdim(i).MatStr.Trim
                                Me.chkAggancBoltLM.Checked = Matdim(i).Agganciato
                            End If
                        End If
                    End If
                End If
                '--------------------------------------
                _TextCil_2.Text = GlobalRoutines.myStr(.SicBullp(1), 2, 2, False)
                _TextCil_3.Text = GlobalRoutines.myStr(.FattBoltSy(1), 2, 2, False)
                _TextCil_4.Text = GlobalRoutines.myStr(.Rapporto(1), 2, 2, False)
                _TextCil_5.Text = .DiNBull(1)
                _TextCil_6.Text = CStr(.NumBolt(1))
                _TextCil_7.Text = GlobalRoutines.myStr(.BoltCiD(1) * kLength, 5, 2, False)
                _TextCil_9.Text = GlobalRoutines.myStr(.AreBolt(1) * kLength * kLength, 5, 2, False)
                _TextCil_10.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).HydrDepth * kLength, 5, 2, False)
                _TextCil_11.Text = GlobalRoutines.myStr(.BSpcMin(1) * kLength, 5, 2, False)
                _TextCil_12.Text = GlobalRoutines.myStr(.BRadMin(1) * kLength, 5, 2, False)
                _TextCil_13.Text = CStr(System.Math.Abs(.NumColl(1)))
                _optColl_0.Checked = .NumColl(1) >= 0
                _optColl_1.Checked = .NumColl(1) < 0
                _TextCil_15.Text = GlobalRoutines.myStr(.AllBRoo(1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_16.Text = GlobalRoutines.myStr(.AllBOpe(1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                '---------------------------------------------
                TextCil(402).Text = GlobalRoutines.myStr(.SicBullp(2), 2, 2, False)
                TextCil(403).Text = GlobalRoutines.myStr(.FattBoltSy(2), 2, 2, False)
                ' TextCil(404) = mystr(.Rapporto(2), 2, 2, False)
                TextCil(405).Text = .DiNBull(2)
                TextCil(406).Text = CStr(.NumBolt(2))
                TextCil(407).Text = GlobalRoutines.myStr(.BoltCiD(2) * kLength, 5, 2, False)
                TextCil(409).Text = GlobalRoutines.myStr(.AreBolt(2) * kLength * kLength, 5, 2, False)
                TextCil(411).Text = GlobalRoutines.myStr(.BSpcMin(2) * kLength, 5, 2, False)
                TextCil(412).Text = GlobalRoutines.myStr(.BRadMin(2) * kLength, 5, 2, False)
                TextCil(413).Text = CStr(.NumColl(2))
                TextCil(415).Text = GlobalRoutines.myStr(.AllBRoo(2) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                TextCil(416).Text = GlobalRoutines.myStr(.AllBOpe(2) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                '---------------------------------------------
                TextCil(51).Text = GlobalRoutines.myStr(.wn(2) * kLength, 6, 2, False)
                TextCil(54).Text = GlobalRoutines.myStr(.wn(1) * kLength, 6, 2, False)
                _TextCil_94.Text = GlobalRoutines.myStr(.OTL * kLength, 6, 2, False)
                _TextCil_95.Text = GlobalRoutines.myStr(.UL * kLength * kLength, 6, 2, False)
                If .ltxperc Then
                    TextCil(96).Text = GlobalRoutines.myStr(.ltx, 6, 2, False)
                Else
                    TextCil(96).Text = GlobalRoutines.myStr(.ltx * kLength, 6, 2, False)
                End If
                txtIBW.Text = GlobalRoutines.myStr(.diamIBW * kLength, 6, 2, False)
                For i = 32 To 50
                    Select Case i
                        Case 38, 39
                            TextCil(i).Text = .FlChanDati(i - 31)
                        Case Else
                            TextCil(i).Text = GlobalRoutines.myStr(.FlChanDati(i - 31) * .FlDatik(i - 31), 6, 2, False)
                    End Select
                Next
                TextCil(108).Text = GlobalRoutines.myStr(.FlChanDati(21) * .FlDatik(21), 6, 2, False)
                _TextCil_92.Text = GlobalRoutines.myStr(.FlChanDati(22) * .FlDatik(22), 6, 2, False)
                For i = 62 To 80
                    If i = 68 Or i = 69 Then
                        TextCil(i).Text = .FlShelDati(i - 61)
                    Else
                        TextCil(i).Text = GlobalRoutines.myStr(.FlShelDati(i - 61) * .FlDatik(i - 61), 6, 2, False)
                    End If
                Next
                _TextCil_110.Text = GlobalRoutines.myStr(.FlShelDati(21) * .FlDatik(21), 6, 2, False)
                _TextCil_109.Text = GlobalRoutines.myStr(.FlShelDati(22) * .FlDatik(22), 6, 2, False)
                For i = 102 To 103
                    TextCil(i).Text = GlobalRoutines.myStr(.SlChanDati(i - 101) * .FlDatik(i - 101), 6, 2, False)
                Next
                For i = 122 To 123
                    TextCil(i).Text = GlobalRoutines.myStr(.SlShelDati(i - 121) * .FlDatik(i - 121), 6, 2, False)
                Next
                If Not VerificandoPI Then
                    _TextCil_8.Text = GlobalRoutines.myStr(.AllFRoo * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                Else
                    _TextCil_8.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6, 2, False)
                End If
                _TextCil_14.Text = GlobalRoutines.myStr(.AllFOpe * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_17.Text = GlobalRoutines.myStr(.TSheDes * kLength, 6, 2, False)
                _TextCil_18.Text = GlobalRoutines.myStr(.TSheThk * kLength, 6, 2, False)
                _TextCil_19.Text = GlobalRoutines.myStr(.TExtThk * kLength, 6, 2, False)
                _TextCil_20.Text = GlobalRoutines.myStr(.TubDiam * kLength, 6, 2, False)
                _TextCil_21.Text = GlobalRoutines.myStr(.TubPass * kLength, 6, 2, False)
                _TextCil_22.Text = GlobalRoutines.myStr(.EquDiam * kLength, 6, 2, False)
                _TextCil_23.Text = GlobalRoutines.myStr(.CavChan1 * kLength, 6, 2, False)
                _TextCil_24.Text = GlobalRoutines.myStr(.CorChan * kLength, 6, 2, False)
                _TextCil_25.Text = GlobalRoutines.myStr(.CorShel * kLength, 6, 2, False)
                _TextCil_26.Text = GlobalRoutines.myStr(.PDesChan * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_27.Text = GlobalRoutines.myStr(.PDesShel * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_28.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).HydrDepth2 * kLength, 5, 2, False)
                _TextCil_29.Text = GlobalRoutines.myStr(.PHTChan * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_30.Text = GlobalRoutines.myStr(.PHTShel * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_31.Text = GlobalRoutines.myStr(.Destemp * kTemp + kTemp32, 6, 2, False)
                _TextCil_52.Text = GlobalRoutines.myStr(.DiffPress * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_91.Text = GlobalRoutines.myStr(.DiffPressHT * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                _TextCil_53.Text = GlobalRoutines.myStr(.CavShel1 * kLength, 6, 2, False)
                _TextCil_82.Text = GlobalRoutines.myStr(.TubSpess * kLength, 3, 3, False)
                If .TipoPT = 2 Then
                    _TextCil_55.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).CavShel2 * kLength, 6, 2, False)
                    _TextCil_56.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).CavChan2 * kLength, 6, 2, False)
                    _TextCil_57.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 289) * kLength, 6, 2, False)
                    If CType(.Piastra, wn_FTC).Zp(1, 592) <= 0 Then CType(.Piastra, wn_FTC).Zp(1, 592) = CType(.Piastra, wn_FTC).Zp(1, 309)
                    _TextCil_101.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 592) * kLength, 6, 2, False)
                    TextCil(58).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 262) * kLength, 6, 2, False)
                    TextCil(59).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 309) * kLength, 6, 2, False)
                    _TextCil_61.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).AllFRoo2 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                    _TextCil_60.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).AllFOpe2 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, False)
                    _TextCil_83.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 30) * kLength, 5, 2, False)
                    _TextCil_84.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 29), 5, 0, True)
                    If Involucr(kLato, jInvolucr).indice(4 - 1) > -1 Then
                        cmbMatShell.Text = Matdim(Involucr(kLato, jInvolucr).indice(4 - 1)).MatStr
                    End If
                    _TextCil_86.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 23) * kLength, 3, 2, False)
                    _TextCil_93.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).hr * kLength, 5, 2, False)
                    If _Option1_0.Checked Then
                        _TextCil_87.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 21) * kLength, 6, 2, False)
                    Else
                        _TextCil_87.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 307) * kLength, 6, 2, False)
                    End If
                    _TextCil_88.Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 39) * kLength, 5, 1, False)
                    If CType(.Piastra, wn_FTC).CalcFBM Then
                        chkCalcFBM.CheckState = System.Windows.Forms.CheckState.Checked
                    Else
                        chkCalcFBM.CheckState = System.Windows.Forms.CheckState.Unchecked
                        TextCil(100).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 583) * kLength, 4, 2, False)
                        TextCil(104).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 584) * kLength, 4, 2, False)
                        TextCil(105).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 585) * kLength, 4, 2, False)
                        TextCil(97).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 586) * kLength, 4, 2, False)
                        TextCil(98).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 587) * kLength, 4, 2, False)
                        TextCil(99).Text = GlobalRoutines.myStr(CType(.Piastra, wn_FTC).Zp(1, 588) * kLength, 4, 2, False)
                    End If
                    _TextCil_114.Text = GlobalRoutines.myStr(.GrvChan * kLength, 3, 3, False)
                    _TextCil_113.Text = GlobalRoutines.myStr(.GrvShel * kLength, 3, 3, False)
                    n = CType(.Piastra, wn_FTC).Zp(1, 261)
                    If n > 0 Then _TextCil_89.Value = n Else _TextCil_89.Value = 1
                    If .Piastra.Rear > 0 And .Piastra.Rear < 3 Then
                        .SetPiastra(2)
                        TextCil(111).Text = GlobalRoutines.myStr(.GrvChan * kLength, 3, 3, False)
                        TextCil(112).Text = GlobalRoutines.myStr(.GrvShel * kLength, 3, 3, False)
                        n = CType(.Piastra, wn_FTC).IndiceFondo
                        If n > 0 Then
                            For i = 0 To _cmbCil_13.SelectedIndex - 2
                                If GlobalRoutines.ValVir(List4.Items(i)) = n Then
                                    Saltacombo = True
                                    _cmbCil_13.SelectedIndex = i
                                    Saltacombo = False
                                    Exit For
                                End If
                            Next
                        Else
                            If _cmbCil_13.Items.Count > 0 Then _cmbCil_13.SelectedIndex = 0
                        End If
                        For i = 106 To 107
                            TextCil(i).Text = GlobalRoutines.myStr(.SlChanDati(i - 105) * .FlDatik(i - 105), 6, 2, False)
                        Next
                    End If
                    n = CType(.Piastra, wn_FTC).IndiceFlanF
                    For i = 0 To _cmbCil_14.SelectedIndex - 2
                        If GlobalRoutines.ValVir(List5.Items(i)) = n Then
                            _cmbCil_14.SelectedIndex = i
                            Exit For
                        End If
                    Next
                    n = CType(.Piastra, wn_FTC).IndiceSplitR
                    For i = 0 To _cmbCil_15.SelectedIndex - 2
                        If GlobalRoutines.ValVir(List6.Items(i)) = n Then
                            _cmbCil_15.SelectedIndex = i
                            Exit For
                        End If
                    Next
                    If PiastraAB = 1 Then .SetPiastra(1)
                End If
                If .ltxperc Then chkltx.CheckState = System.Windows.Forms.CheckState.Checked Else chkltx.CheckState = System.Windows.Forms.CheckState.Unchecked
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        Aggiornando = False
    End Sub
    Public Sub AggCombo()
        Dim i, n As Short
        Try
            i = Involucr(kLato, jInvolucr).IndObject
            With CType(objMemb(i), wn_PT)
                Select Case .TipoPT
                    Case 1
                        _cmbCil_1.SelectedIndex = CType(.Piastra, wn_UTEMA).bdice
                    Case 2
                        _cmbCil_1.SelectedIndex = CType(.Piastra, wn_FTC).Rear + 2
                        Select Case CType(.Piastra, wn_FTC).Rear
                            Case 1
                                _cmbCil_6.SelectedIndex = CType(.Piastra, wn_FTC).Flangiata(1) + 1
                                If _cmbCil_9.SelectedIndex > 0 Then _cmbCil_7.SelectedIndex = CType(.Piastra, wn_FTC).Flangiata(2) + 1
                            Case 2
                                If CType(.Piastra, wn_FTC).Gasketed(1) = 1 Then
                                    _cmbCil_6.SelectedIndex = 2
                                Else
                                    If CType(.Piastra, wn_FTC).Flangiata(1) = 0 Then
                                        _cmbCil_6.SelectedIndex = 3
                                    Else
                                        _cmbCil_6.SelectedIndex = CType(.Piastra, wn_FTC).Flangiata(1) - 1
                                    End If
                                End If
                                _cmbCil_7.SelectedIndex = CType(.Piastra, wn_FTC).Flottante - 1
                            Case 3
                                _cmbCil_6.SelectedIndex = CType(.Piastra, wn_FTC).Gasketed(1) '+ 1
                        End Select
                        _Option1_0.Checked = CType(.Piastra, wn_FTC).Zp(1, 307) = 0 ' > .Piastra.Zp(1, 21)
                        _Option1_1.Checked = Not _Option1_0.Checked
                End Select
                If .TipoPT = 2 And .TipCalc < 1 Then .TipCalc = 1
                If .TipCalc > _cmbCil_2.Items.Count - 1 Then .TipCalc = 1
                _cmbCil_2.SelectedIndex = .TipCalc
                _cmbCil_3.SelectedIndex = .FullBolt
                _cmbCil_403.SelectedIndex = .FullBolt
                cmbCil_SelectedIndexChanged(1)
                If .TipoPT = 2 Then
                    If CType(.Piastra, wn_FTC).Zp(1, 26) = 0 Then
                        _cmbCil_4.SelectedIndex = 0
                    ElseIf CType(.Piastra, wn_FTC).TipoDilatp = 7 Then
                        _cmbCil_4.SelectedIndex = -1
                        _cmbCil_4.SelectedIndex = 1
                    Else
                        For i = 0 To List1.Items.Count - 1
                            If GlobalRoutines.ValVir(List1.Items(i)) = CType(.Piastra, wn_FTC).IndiceDilat Then
                                _cmbCil_4.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                End If
                If .TipPass < 0 Then .TipPass = 0
                _cmbCil_5.SelectedIndex = 1 - .TipPass ' - 1
                If .TipoPT = 2 Then
                    If CType(.Piastra, wn_FTC).IndiceShell > -1 Then
                        For i = 0 To List3.Items.Count - 1
                            If GlobalRoutines.ValVir(List3.Items(i)) = CType(.Piastra, wn_FTC).IndiceShell Then
                                cmbCil(10).SelectedIndex = i
                                Exit For
                            End If
                        Next
                    Else
                        If cmbCil(10).SelectedIndex > 1 Then cmbCil(10).SelectedIndex = 1
                    End If
                End If
                If TipoPiastra = 2 Then
                    AggCombo6()
                    Select Case _cmbCil_1.SelectedIndex
                        Case 3
                            _cmbCil_6.SelectedIndex = CType(.Piastra, wn_FTC).Flangiata(1) + 1
                            _cmbCil_9.SelectedIndex = CType(.Piastra, wn_FTC).Differing - 1
                            If _cmbCil_9.SelectedIndex > 0 Then _cmbCil_7.SelectedIndex = CType(.Piastra, wn_FTC).Flangiata(2) + 1
                        Case 4
                            If .Piastra.Gasketed(1) = 1 Then
                                _cmbCil_6.SelectedIndex = 2
                            ElseIf .Piastra.Flangiata(1) = 0 Then
                                _cmbCil_6.SelectedIndex = 3
                            Else
                                _cmbCil_6.SelectedIndex = CType(.Piastra, wn_FTC).Flangiata(1) - 1
                            End If
                            _cmbCil_9.SelectedIndex = CType(.Piastra, wn_FTC).Differing - 1
                            _cmbCil_7.SelectedIndex = CType(.Piastra, wn_FTC).Flottante - 1
                            If CType(.Piastra, wn_FTC).TipoFF = 0 Or CType(.Piastra, wn_FTC).TipoFF > 10 Then CType(.Piastra, wn_FTC).TipoFF = 5
                            Seleziona_cmbCil_11()
                        Case 5
                            Select Case CType(.Piastra, wn_FTC).Gasketed(1)
                                Case 0
                                    _cmbCil_6.SelectedIndex = 0
                                Case 1
                                    _cmbCil_6.SelectedIndex = 1
                            End Select
                    End Select
                End If
            End With
            MaterialeScelto(cmbMat, 0) ' Math.Max(Involucr(kLato, jInvolucr).indice(0) - 1, -1)
            MaterialeScelto(cmbMat2, 2) '  Math.Max(Involucr(kLato, jInvolucr).indice(2) - 1, -1)
            MaterialeScelto(cmbMatBoltLM, 6) ' Math.Max(Involucr(kLato, jInvolucr).indice(6) - 1, -1)
            MaterialeScelto(cmbMatBoltLT, 1) '  Math.Max(Involucr(kLato, jInvolucr).indice(1) - 1, -1)
            MaterialeScelto(cmbMatFlLM, 4) '  Math.Max(Involucr(kLato, jInvolucr).indice(4) - 1, -1)
            MaterialeScelto(cmbMatFlLT, 5) ' Math.Max(Involucr(kLato, jInvolucr).indice(5) - 1, -1)
            MaterialeScelto(cmbMatSlLM, 4) '  Math.Max(Involucr(kLato, jInvolucr).indice(4) - 1, -1)
            MaterialeScelto(cmbMatSlLT, 5) '  Math.Max(Involucr(kLato, jInvolucr).indice(5) - 1, -1)
            MaterialeScelto(cmbMatShell, 3) '  Math.Max(Involucr(kLato, jInvolucr).indice(3) - 1, -1)
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub MaterialeScelto(ByVal c As ComboBox, ByVal i As Short)
        Dim j As Short = Involucr(kLato, jInvolucr).indice(i)
        If j > c.Items.Count - 1 Then j = -1
        PostSelMat(c, Math.Max(j, -1))
    End Sub
    Private Sub Seleziona_cmbCil_11()
        Dim n As Integer = CType(O.Piastra, wn_FTC).TipoFF
        Dim i As Short
        If n = 10 Then
            n = 6
        ElseIf n > 5 Then
            n = n + 1
        End If
        n -= 1
        For i = 0 To 9
            If Me.ListIndiciCombo11(i) = n Then
                _cmbCil_11.SelectedIndex = i
                Exit Sub
            End If
        Next
        _cmbCil_11.SelectedIndex = 0
    End Sub
    Private Sub AggTab()
        Dim i As Short
        i = Involucr(kLato, jInvolucr).IndObject
        O = objMemb(i)
        For i = 0 To 8
            Frames(i).Top = 800 ' GlobalRoutines.TwipsToPixelsY(10000)
        Next i
        _Check1_4.Visible = True
        If _Check1_0.CheckState = 0 Then
            For i = 53 To 56
                LabelCil(i).Visible = True
            Next
            For i = 46 To 49
                TextCil(i).Visible = True
            Next
            For i = 59 To 62
                LabelCil(i).Visible = True
            Next
            For i = 76 To 79
                TextCil(i).Visible = True
            Next
        End If
        _LabelCil_24.Visible = True : _TextCil_19.Visible = True
        _LabelCil_22.Visible = True : _TextCil_17.Visible = True
        _LabelCil_151.Visible = True : cmbMatFlLT.Visible = True : _cmdCil_151.Visible = True
        _LabelCil_181.Visible = True : cmbMatFlLM.Visible = True : _cmdCil_181.Visible = True
        _LabelCil_150.Visible = True : _TextCil_114.Visible = True
        _LabelCil_149.Visible = True : _TextCil_113.Visible = True
        VecchiocmbCil1 = _cmbCil_1.SelectedIndex
        With TabStrip1
            .TabPages.Clear()
            .TabPages.Add(New TabPage("Design data"))
            _Frames_5.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(0) = _Frames_5
            _frmCollars_0.Visible = True
            Select Case TipoPiastra
                Case 1
                    Select Case _cmbCil_1.SelectedIndex
                        Case 0
                            BiFl() 'biflangiata
                            BullLT()
                            If O.BullDistinti Then Bull2()
                        Case 1
                            FlT() 'flangiata lato testata
                            BullLT()
                        Case 2
                            If Check2.CheckState = CheckState.Checked Then
                                BrL()
                                BullLM()
                            Else
                                FlM() 'flangiata lato mantello
                                BullLM()
                            End If
                    End Select
                Case 2
                    Select Case _cmbCil_1.SelectedIndex
                        Case 3, 4 ' fisse flottante
                            Select Case PiastraAB 'TabStrip2.SelectedItem.Index
                                Case 1 'piastra A
                                    Clic = _cmbCil_6.SelectedIndex
                                    If _cmbCil_1.SelectedIndex = 4 Then Clic = Clic + 2
                                    Select Case Clic
                                        Case 0
                                            FlT()
                                            BullLT()
                                            Mant() 'lato cassa
                                        Case 1
                                            Bis()
                                            Mant() 'no
                                        Case 2
                                            FlM()
                                            BullLM() 'lato mant
                                        Case 3
                                            BiFl()
                                            BullLT() 'entrambi
                                            If O.BullDistinti Then Bull2()
                                        Case 4
                                            BiFlS() 'bifl senza estensione
                                            If O.Rules > 0 Then
                                                BullLT()
                                                _frmCollars_0.Visible = False
                                            End If
                                        Case 5
                                            Bis()
                                            Mant()
                                    End Select
                                    'GoSub Shell
                                Case 2
                                    Select Case _cmbCil_1.SelectedIndex
                                        Case 3 'fisse
                                            If _cmbCil_9.SelectedIndex = 1 Then 'differing normale
                                                For i = 1 To 4
                                                    actFrames(i) = Nothing
                                                Next
                                                _Check1_4.Visible = False
                                                O.mart = False
                                            Else
                                                Select Case _cmbCil_7.SelectedIndex
                                                    Case 0
                                                        FlT()
                                                        BullLT() 'lato cassa
                                                    Case 1
                                                        Bis() 'no
                                                    Case 2
                                                        FlM()
                                                        BullLM() 'lato mant
                                                    Case 3
                                                        BiFl()
                                                        BullLT() 'entrambi
                                                End Select
                                                Mant()
                                            End If
                                        Case 4 'flottante
                                            Flott()
                                    End Select
                            End Select
                            'If _cmbCil_1.ListIndex = 3 Then GoSub Shell
                        Case 5 'U
                            Select Case _cmbCil_6.SelectedIndex
                                Case 0
                                    Bis()
                                Case 1
                                    BiFlS()
                                Case 2
                                    BrLock()
                                    BullLT()
                            End Select
                    End Select
            End Select
            If .SelectedIndex = 0 Then
                TabStrip1_Click(Me, New EventArgs)
            Else
                .SelectedIndex = 0
            End If
        End With
        SecExtVis()
    End Sub
    Private Sub BrLock()
        FlanM = True : FlanC = True
        With TabStrip1
            .TabPages.Add(New TabPage("Pushing course"))
            _Frames_1.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = _Frames_1
            .TabPages.Add(New TabPage("Joint data"))
            _Frames_2.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(2) = _Frames_2
        End With
        Uno = 0
        actFrames(4) = Nothing
        _LabelCil_24.Visible = False : _TextCil_19.Visible = False
        _LabelCil_150.Visible = False : _TextCil_114.Visible = False
        _LabelCil_149.Visible = False : _TextCil_113.Visible = False
        If O.Rules = 0 Then
            _LabelCil_22.Visible = False : _TextCil_17.Visible = False
        End If
    End Sub
    Private Sub Flott()
        With TabStrip1
            ' If _cmbCil_7.SelectedIndex < 4 Then .TabPages.Add(New TabPage("Fondo flottante")) 160606
            .TabPages.Add(New TabPage("Fondo flottante"))
            _Frames_6.Top = 36 ' GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = _Frames_6
            _LabelCil_112.Visible = False : _cmbCil_13.Visible = False
            _LabelCil_113.Visible = False : _cmbCil_14.Visible = False
            _LabelCil_111.Visible = False : _cmbCil_11.Visible = False
            _LabelCil_114.Visible = False : _TextCil_93.Visible = False
            _LabelCil_142.Visible = False : _cmbCil_15.Visible = False
            _LabelCil_127.Visible = True : _TextCil_106.Visible = True
            _LabelCil_126.Visible = True : _TextCil_107.Visible = True
            FlanC = False
            Select Case _cmbCil_7.SelectedIndex
                Case 0 'P - outside packed
                    .TabPages.Add(New TabPage("Head weld"))
                    Frames(3).Top = GlobalRoutines.TwipsToPixelsY(400)
                    actFrames(2) = Frames(3)
                    _LabelCil_127.Visible = False : _TextCil_106.Visible = False
                    _LabelCil_126.Visible = False : _TextCil_107.Visible = False
                    Picture1.Image = ImageList1.Images(6)
                    _LabelCil_112.Visible = True : _cmbCil_13.Visible = True
                    ScelFonF()
                    _Check1_4.Visible = False
                    O.mart = False
                    ' Involucr(kLato, jInvolucr).indice(5) = 0 '200606
                Case 1 'S - with back-ring
                    .TabPages.Add(New TabPage("Head flange"))
                    _Frames_1.Top = 36 ' GlobalRoutines.TwipsToPixelsY(400)
                    actFrames(2) = _Frames_1
                    .TabPages.Add(New TabPage("Bulloni"))
                    Frames(0).Top = 36 ' GlobalRoutines.TwipsToPixelsY(400)
                    actFrames(3) = Frames(0)
                    _LabelCil_112.Visible = True : _cmbCil_13.Visible = True
                    _LabelCil_111.Visible = True : _cmbCil_11.Visible = True
                    InitCombo11()
                    Seleziona_cmbCil_11()
                    ScelFonF()
                    _LabelCil_113.Visible = True : _cmbCil_14.Visible = True
                    ScelFlanF()
                    _LabelCil_142.Visible = True : _cmbCil_15.Visible = True
                    ScelSplitR()
                    FlanC = True
                    ' Involucr(kLato, jInvolucr).indice(5) = 0 '200606
                Case 2 'T - Flanged
                    .TabPages.Add(New TabPage("Head flange"))
                    _Frames_1.Top = GlobalRoutines.TwipsToPixelsY(400)
                    actFrames(2) = _Frames_1
                    .TabPages.Add(New TabPage("Bulloni"))
                    Frames(0).Top = GlobalRoutines.TwipsToPixelsY(400)
                    actFrames(3) = Frames(0)
                    _LabelCil_111.Visible = True : _cmbCil_11.Visible = True
                    _LabelCil_114.Visible = True : _TextCil_93.Visible = True
                    _LabelCil_112.Visible = True : _cmbCil_13.Visible = True
                    ': _TextCil_91.Visible = True: cmdCil(14).Visible = True
                    InitCombo11()
                    Seleziona_cmbCil_11()
                    ScelFonF()
                    _LabelCil_113.Visible = True : _cmbCil_14.Visible = True
                    ': _TextCil_92.Visible = True: cmdCil(15).Visible = True
                    ScelFlanF()
                    '_LabelCil_113.Caption = "Flange identification"
                    If O.Piastra.TipoFF < 1 Or O.Piastra.TipoFF > _cmbCil_11.Items.Count Then O.Piastra.TipoFF = 1
                    Seleziona_cmbCil_11()
                    FlanC = True
                Case 3 'T - integral
                    .TabPages.Add(New TabPage("Head weld"))
                    Frames(3).Top = 36 ' GlobalRoutines.TwipsToPixelsY(400)
                    actFrames(2) = Frames(3)
                    _LabelCil_127.Visible = False : _TextCil_106.Visible = False
                    _LabelCil_126.Visible = False : _TextCil_107.Visible = False
                    _LabelCil_112.Visible = True : _cmbCil_13.Visible = True
                    ScelFonF()
                    _LabelCil_113.Visible = False : _cmbCil_14.Visible = False
                    Picture1.Image = ImageList1.Images(6)
                    _Check1_4.Visible = False
                    O.mart = False
                    'Involucr(kLato, jInvolucr).indice(5) = 0 '200606
                Case 4 'W - internally sealed
                    'If O.Rules = 1 Then Picture1.Image = ImageList1.Images(8) 160606
                    _LabelCil_127.Visible = False : _TextCil_106.Visible = False
                    _LabelCil_126.Visible = False : _TextCil_107.Visible = False
                    Picture1.Image = ImageList1.Images(8)
                    _Check1_4.Visible = False
                    O.mart = False
                    Involucr(kLato, jInvolucr).indice(5) = 0
            End Select
        End With
    End Sub
    Private Sub BiFlS()
        Dim i As Short
        FlanM = True : FlanC = True
        With TabStrip1
            .TabPages.Add(New TabPage("T.S. flange"))
            _Frames_1.Top = 36 ' GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = _Frames_1
            .TabPages.Add(New TabPage("S.S. flange"))
            _Frames_2.Top = 36 ' GlobalRoutines.TwipsToPixelsY(400)
            actFrames(2) = _Frames_2
        End With
        _LabelCil_150.Visible = False : _TextCil_114.Visible = False
        _LabelCil_149.Visible = False : _TextCil_113.Visible = False
        _LabelCil_151.Visible = False : cmbMatFlLT.Visible = False : _cmdCil_151.Visible = False
        _LabelCil_181.Visible = False : cmbMatFlLM.Visible = False : _cmdCil_181.Visible = False
        For i = 53 To 56
            LabelCil(i).Visible = O.Rules > 0
        Next
        For i = 46 To 49
            TextCil(i).Visible = O.Rules > 0
        Next
        For i = 59 To 62
            LabelCil(i).Visible = O.Rules > 0
        Next
        For i = 76 To 79
            TextCil(i).Visible = O.Rules > 0
        Next
        If O.GetPiastra = 1 Then
            _TextCil_19.Text = "0"
            _LabelCil_24.Visible = False : _TextCil_19.Visible = False
            Dim V As Boolean = O.Rules > 0
            _LabelCil_22.Visible = V : _TextCil_17.Visible = V
        End If
    End Sub
    Private Sub Bis()
        FlanM = False : FlanC = False
        With TabStrip1
            .TabPages.Add(New TabPage("T.S. weld"))
            Frames(3).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = Frames(3)
            .TabPages.Add(New TabPage("S.S. weld"))
            Frames(4).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(2) = Frames(4)
        End With
        _Check1_4.CheckState = System.Windows.Forms.CheckState.Unchecked
        _Check1_4.Visible = False
        O.mart = False
        If O.GetPiastra = 1 Then
            _LabelCil_24.Visible = False : _TextCil_19.Visible = False
            If O.Rules = 0 Then
                _LabelCil_22.Visible = False : _TextCil_17.Visible = False
            End If
        End If
        If PiastraAB = 0 Then PiastraAB = 1
        Involucr(kLato, jInvolucr).indice(2 - 1) = 0  'Questo dovrebbe essere per la prima piastra solo
    End Sub
    Private Sub Mant()
        With TabStrip1
            .TabPages.Add(New TabPage("Mantello"))
            Frames(7).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(3 + Bulloni) = Frames(7)
        End With
    End Sub
    Private Sub BullLT()
        Bulloni = 1
        With TabStrip1
            If O.BullDistinti Then
                .TabPages.Add(New TabPage("Bulloni L.T."))
                _frmCollars_0.Height = _frmCollars_1.Height
            Else
                .TabPages.Add(New TabPage("Bulloni"))
                _frmCollars_0.Height = frmCollarsInitialHeigth
            End If
            Frames(0).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(3 - Uno) = Frames(0)
        End With
    End Sub
    Private Sub BullLM()
        Bulloni = 1
        With TabStrip1
            If O.BullDistinti Then
                .TabPages.Add(New TabPage("Bulloni L.M."))
            Else
                .TabPages.Add(New TabPage("Bulloni"))
            End If
            Frames(8).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(3 - Uno) = Frames(8)
        End With
    End Sub
    Private Sub Bull2()
        Bulloni = 2
        With TabStrip1
            .TabPages.Add(New TabPage("Bulloni L.M."))
            Frames(8).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(4 - Uno) = Frames(8)
        End With
        actFrames(3 - Uno).Text = "Dati bulloni L.T."
    End Sub
    Private Sub FlM()
        FlanM = True : FlanC = False
        With TabStrip1
            .TabPages.Add(New TabPage("T.S. weld"))
            Frames(3).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = Frames(3)
            .TabPages.Add(New TabPage("S.S. flange"))
            _Frames_2.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(2) = _Frames_2
        End With
    End Sub
    Private Sub BrL()
        FlanM = True : FlanC = False
        With TabStrip1
            .TabPages.Add(New TabPage("Joint data"))
            _Frames_2.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = _Frames_2
        End With
        Uno = 1
        actFrames(3) = Nothing
    End Sub
    Private Sub FlT()
        FlanM = False : FlanC = True
        With TabStrip1
            .TabPages.Add(New TabPage("T.S. flange"))
            _Frames_1.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = _Frames_1
            .TabPages.Add(New TabPage("S.S. weld"))
            Frames(4).Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(2) = Frames(4)
        End With
    End Sub
    Private Sub BiFl()
        FlanM = True : FlanC = True
        With TabStrip1
            .TabPages.Add(New TabPage("T.S. flange"))
            _Frames_1.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(1) = _Frames_1
            .TabPages.Add(New TabPage("S.S. flange"))
            _Frames_2.Top = GlobalRoutines.TwipsToPixelsY(400)
            actFrames(2) = _Frames_2
        End With
    End Sub
    Private Sub AggCombo6()
        'però il combo6 è sempre uguale
        If TipoPiastra = 0 Then TipoPiastra = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).TipoPT
        If TipoPiastra = 2 Then
            Select Case CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC).Rear '_cmbCil_1.SelectedIndex
                Case 1 '3 'piastre fisse
                    A6(6)
                    If _cmbCil_9.SelectedIndex > 0 Then 'differing tubesheets
                        A6(7)
                    End If
                    'If _cmbCil_9.ListIndex = 2 Then GoSub A7
                Case 2 '4 'flottante
                    A6(6)
                    A7()
                Case 3 '5 'U
                    A6(6)
            End Select
        Else
            Select Case _cmbCil_1.SelectedIndex
                Case 0 'U biflangiata
                    '              i = 6: GoSub A6
            End Select
        End If
    End Sub
    Private Sub A7()
        Dim j As Short = _cmbCil_7.SelectedIndex
        _cmbCil_7.Items.Clear()
        _cmbCil_7.Items.Add("P - Outside packed   ")
        _cmbCil_7.Items.Add("S - with back-ring   ")
        _cmbCil_7.Items.Add("T - Flanged          ")
        _cmbCil_7.Items.Add("T - Integral         ")
        _cmbCil_7.Items.Add("W - internally sealed")
        If j < _cmbCil_7.Items.Count Then _cmbCil_7.SelectedIndex = j Else _cmbCil_7.SelectedIndex = 0
    End Sub
    Private Sub A6(ByVal i As Short)
        Dim j As Short = cmbCil(i).SelectedIndex
        If j = -1 Then
            Select Case _cmbCil_1.SelectedIndex
                Case 3, 4 'fisse, flottanti
                    j = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC).Flangiata(i - 5) + 1
                Case 5 'a U
                    j = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC).Gasketed(i - 5)
            End Select
        ElseIf _cmbCil_1.SelectedIndex = 4 Then
            j = j + 2
        End If
        cmbCil(i).Items.Clear()
        If _cmbCil_1.SelectedIndex = 0 Then 'biflangiata tubi a U
            cmbCil(i).Items.Add("Biflang. senza est.")
            cmbCil(i).Items.Add("Biflang. con est.")
        ElseIf _cmbCil_1.SelectedIndex < 4 Then  'tubi a U o piastre fisse
            cmbCil(i).Items.Add("Fl. Lato Cassa")
            cmbCil(i).Items.Add("Nessuna Flangiatura")
            'If _cmbCil_1.ListIndex <> 3 Then 'tubi a U
            cmbCil(i).Items.Add("Fl. Lato Mantello")
            cmbCil(i).Items.Add("Biflang. con est.")
            'End If
        ElseIf _cmbCil_1.SelectedIndex = 4 Then  'flottante
            cmbCil(i).Items.Add("Fl. Lato Mantello")
            cmbCil(i).Items.Add("Biflang. con est.")
            cmbCil(i).Items.Add("Biflang. senza est.")
            cmbCil(i).Items.Add("Integrale")
            j = j - 2
            If j = 1 And CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC).Gasketed(i - 5) = 1 Then j = 2
        Else
            cmbCil(i).Items.Add("Integrale") 'tubia U senza estensione
            cmbCil(i).Items.Add("Biflang. senza est.")
            cmbCil(i).Items.Add("Tipo Breach-Lock")
        End If
        If j < cmbCil(i).Items.Count And j >= 0 Then cmbCil(i).SelectedIndex = j ' Else cmbCil(i).ListIndex = 0
    End Sub
    Private Sub AggTab2(ByRef Modo As Boolean)
        If Not Modo Then
            Framesf(2).Visible = False : TabStrip2.Visible = False
        Else
            If _cmbCil_1.SelectedIndex = 5 Then
                Framesf(2).Visible = False : TabStrip2.Visible = False
            Else
                Framesf(2).Top = Framesf(1).Top
                Framesf(2).Visible = True : TabStrip2.Visible = True
                With TabStrip2
                    .TabPages.Clear()
                    .TabPages.Add(New TabPage("Piastra di testa"))
                    Select Case _cmbCil_1.SelectedIndex
                        Case 3 : .TabPages.Add(New TabPage("Piastra di coda"))
                        Case 4 : .TabPages.Add(New TabPage("Piastra flottante"))
                    End Select
                    If .SelectedIndex = 0 Then
                        TabStrip2_Click(Me, New EventArgs)
                    Else
                        .SelectedIndex = 0
                    End If
                End With
            End If
        End If
        SecExtVis()
    End Sub
    Private Sub CheckTipo()
        Dim Ricrea As Boolean
        Dim i As Short
        Dim nuovoTipo As Short
        Select Case _cmbCil_1.SelectedIndex
            Case 0, 1, 2 : nuovoTipo = 1
            Case 3, 4, 5 : nuovoTipo = 2
        End Select
        i = Involucr(kLato, jInvolucr).IndObject
        Ricrea = CType(objMemb(i), wn_PT).Piastra Is Nothing
        If Not Ricrea Then Ricrea = (nuovoTipo <> CType(objMemb(i), wn_PT).TipoPT)
        If Ricrea Then
            If NonCambiareTipo Then
                MessageBox.Show("Non è consentito cambiare tipo di piastra nel presente contesto")
                _cmbCil_1.SelectedIndex = VecchiocmbCil1
            End If
            Select Case nuovoTipo
                Case 1
                    CType(objMemb(i), wn_PT).Piastra = New wn_UTEMA
                Case 2
                    CType(objMemb(i), wn_PT).Piastra = New wn_FTC
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).SoloDilat = False
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 1
            End Select
            CType(objMemb(i), wn_PT).TipoPT = nuovoTipo
            CType(objMemb(i), wn_PT).Recover()
        End If
    End Sub
    Private Sub RiempiCollegFl()
        Dim i As Short
        Dim i1, i2 As Short
        Dim n As Short
        Dim O As wn_PT
        Dim Vec As Boolean
        _cmbCil_101.Enabled = True
        _cmbCil_51.Enabled = True
        _cmbCil_121.Items.Clear() : List2(121).Items.Clear()
        _cmbCil_101.Items.Clear() : List2(101).Items.Clear()
        _cmbCil_81.Items.Clear() : List2(81).Items.Clear()
        _cmbCil_51.Items.Clear() : List2(51).Items.Clear()
        i = Involucr(kLato, jInvolucr).IndObject
        O = objMemb(i)
        Select Case PiastraAB
            Case 0, 1 'piastra di testa
                If O.SlChanDati(1) = -2 Then 'PT avvitata fondo cassa
                    Standar1()
                Else
                    i1 = 1 : i2 = 2
                    Standard(i1, i2)
                End If
                AggiornaCollegFl()
            Case 2 'Piastra di coda
                Select Case _cmbCil_1.SelectedIndex
                    Case 0, 1, 2 'UTEMA
                    Case 3 'fixed
                        i1 = 1 : i2 = 2
                        Standard(i1, i2)
                        AggiornaCollegFl()
                    Case 4 'floating
                        i1 = 0 : i2 = 3
                        Standard(i1, i2)
                        n = CType(O.Piastra, wn_FTC).IndiceFondo
                        If n > 0 Then
                            Select Case CType(O.Piastra, wn_FTC).Flottante
                                Case 1 : iii = 2
                                Case Else : iii = 3
                            End Select
                            _cmbCil_101.Enabled = False
                            NonScollegare = True
                            _cmbCil_101.Text = Trim(Involucr(iii, n).Mark) & " "
                            List2(101).Text = n.ToString
                            Vec = _cmbCil_101.Enabled
                            _cmbCil_101.Enabled = True
                            NonScollegare = False
                            cmbCil_SelectedIndexChanged(101)
                            _cmbCil_101.Enabled = Vec
                        End If
                        n = CType(O.Piastra, wn_FTC).IndiceFlanF
                        If n > 0 Then
                            _cmbCil_51.Enabled = False
                            NonScollegare = True
                            _cmbCil_51.Text = Trim(Involucr(3, n).Mark)
                            List2(51).Text = n.ToString
                            Vec = _cmbCil_51.Enabled
                            _cmbCil_51.Enabled = True
                            NonScollegare = False
                            cmbCil_SelectedIndexChanged(51)
                            _cmbCil_51.Enabled = Vec
                        End If
                        AggiornaCollegFl()
                    Case 5 'U
                End Select
        End Select
    End Sub
    Private Sub Standard(ByVal i1 As Short, ByVal i2 As Short)
        Dim i As Short
        Try
            If i1 > 0 Then
                For i = 1 To Config(i1).Ninvolucri
                    If Involucr(i1, i).Tipo = 0 Then
                        _List2_121.Items.Add(i.ToString) 'L.M.
                        _cmbCil_121.Items.Add(Involucr(i1, i).Mark.Trim)
                    End If
                    If Involucr(i1, i).Tipo = 5 Then
                        _List2_81.Items.Add(i.ToString) 'L.M.
                        _cmbCil_81.Items.Add(Involucr(i1, i).Mark.Trim)
                    End If
                Next
            End If
            If O Is Nothing Then O = objMemb(Involucr(kLato, jInvolucr).IndObject)
            If O.FlShelNome Is Nothing Then O.FlShelNome = ""
            Dim Testo As String = O.FlShelNome.Trim
            If O.IndAccopp(2) = 0 And Testo.Length > 0 Then
                If InStr(Testo, "(scoll.)") = 0 Then Testo = Testo & " (scoll.)"
            Else
                Testo = "Nessuno"
            End If
            _cmbCil_81.Items.Add(Testo)
            _List2_81.Items.Add("N")
            If O.SlShelNome Is Nothing Then O.SlShelNome = ""
            Testo = O.SlShelNome.Trim
            If O.IndAccopp(4) = 0 And Testo.Length > 0 Then
                If InStr(Testo, "(scoll.)") = 0 Then Testo = Testo & " (scoll.)"
            Else
                Testo = "Nessuno"
            End If
            _cmbCil_121.Items.Add(Testo)
            _List2_121.Items.Add("N")
            For i = 1 To Config(i2).Ninvolucri
                If Involucr(i2, i).Tipo < 2 Then
                    _List2_101.Items.Add(i.ToString) 'L.T.
                    _cmbCil_101.Items.Add(Trim(Involucr(i2, i).Mark))
                End If
                If Involucr(i2, i).Tipo = 5 Then
                    _List2_51.Items.Add(i.ToString) 'L.T.
                    _cmbCil_51.Items.Add(Involucr(i2, i).Mark)
                End If
            Next
            If O.SlChanNome Is Nothing Then O.SlChanNome = ""
            Testo = O.SlChanNome.Trim
            If O.IndAccopp(3) = 0 And Testo.Length > 0 Then
                If InStr(Testo, "(scoll.)") = 0 Then Testo = Testo & " (scoll.)"
            Else
                Testo = "Nessuno"
            End If
            _cmbCil_101.Items.Add(Testo)
            _List2_101.Items.Add("N")
            If O.FlChanNome Is Nothing Then O.FlChanNome = ""
            Testo = O.FlChanNome.Trim
            If O.IndAccopp(1) = 0 And Testo.Length > 0 Then
                If InStr(Testo, "(scoll.)") = 0 Then Testo = Testo & " (scoll.)"
            Else
                Testo = "Nessuno"
            End If
            _cmbCil_51.Items.Add(Testo)
            _List2_51.Items.Add("N")
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Standar1()
        Dim i As Short
        For i = 1 To Config(1).Ninvolucri
            If Involucr(1, i).Tipo = 5 Then
                List2(81).Items.Add(i.ToString) 'L.M.
                _cmbCil_81.Items.Add(Trim(Involucr(1, i).Mark))
            End If
        Next
        For i = 1 To Config(2).Ninvolucri
            If Involucr(2, i).Tipo = 5 Then
                List2(81).Items.Add((-i).ToString) 'L.M.
                _cmbCil_81.Items.Add(Trim(Involucr(2, i).Mark))
            End If
        Next
        Dim Testo As String = Trim(O.FlShelNome)
        If O.IndAccopp(2) = 0 And Len(Testo) > 0 Then
            If InStr(Testo, "(scoll.)") = 0 Then Testo = Testo & " (scoll.)"
        Else
            Testo = "Nessuno"
        End If
        _cmbCil_81.Items.Add(Testo)
        List2(81).Items.Add("N")
    End Sub
    Private Sub BulAutomatico(ByRef l As Boolean)
        '_Frames_2 Lato Mantello Wm1 Wm2 W
        Dim n As Boolean = Config(0).CalcPI
        Dim m As Boolean = l And n
        LabelCil(60).Visible = m : _TextCil_78.Visible = m
        LabelCil(145).Visible = m : _TextCil_79.Visible = m
        LabelCil(59).Visible = Not l And n : _TextCil_109.Visible = Not l And n
        '_Frames_1 Lato Tubi Wm1 Wm2 W
        _LabelCil_55.Visible = m : _TextCil_48.Visible = m
        LabelCil(143).Visible = m : _TextCil_49.Visible = m
        LabelCil(56).Visible = Not l And n : _TextCil_92.Visible = Not l And n
        '_frames_5 Dati di progetto
        _LabelCil_35.Visible = n : _TextCil_29.Visible = n : _lblUni_29.Visible = n : _cmdCil_29.Visible = n
        _LabelCil_36.Visible = n : _TextCil_30.Visible = n : _lblUni_30.Visible = n : _cmdCil_30.Visible = n
        If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).ProgDiffPr Then
            _LabelCil_41.Visible = n : _TextCil_91.Visible = n : _lblUni_91.Visible = n
        End If
        '-----------------
        LabelCil(61).Visible = Not l : _TextCil_110.Visible = Not l
        _LabelCil_146.Visible = l : _TextCil_77.Visible = l
        LabelCil(62).Visible = l : _TextCil_76.Visible = l
        LabelCil(54).Visible = Not l : TextCil(108).Visible = Not l
        LabelCil(53).Visible = l : TextCil(46).Visible = l
        _LabelCil_144.Visible = l : TextCil(47).Visible = l
        Frame2.Visible = l
        Frame3.Visible = l
        LabelCil(58).Visible = Not l : TextCil(80).Visible = Not l
        LabelCil(57).Visible = Not l : TextCil(50).Visible = Not l
    End Sub
    Private Sub Nonvisibile(ByRef l As Boolean)
        If l Then
            LabelCil(77).Text = "Flange identification"
            _Check1_4.Enabled = True
        Else
            LabelCil(77).Text = "Transition piece"
            _Check1_4.CheckState = System.Windows.Forms.CheckState.Checked
            _Check1_4.Enabled = False
        End If
        _frmCollars_0.Visible = l
        _frmCollars_1.Visible = False 'l
        LabelCil(76).Visible = l : TextCil(62).Visible = l
        LabelCil(75).Visible = l : TextCil(63).Visible = l
        LabelCil(74).Visible = l : TextCil(64).Visible = l
        LabelCil(73).Visible = l : TextCil(65).Visible = l
        LabelCil(66).Visible = l : TextCil(72).Visible = l
        LabelCil(65).Visible = l : TextCil(73).Visible = l
        LabelCil(64).Visible = l : TextCil(74).Visible = l
        LabelCil(63).Visible = l : TextCil(75).Visible = l
    End Sub
    Private Sub NubbinVisible(ByRef V As Boolean)
        Dim n As Short
        Dim v1 As Boolean
        n = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).IndFac(1)
        v1 = V And (n = 2 Or n = 3 Or n = 4 Or n = 8)
        LabelCil(83).Visible = v1 : TextCil(51).Visible = v1
        n = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).IndFac(2)
        v1 = V And (n = 2 Or n = 3 Or n = 4 Or n = 8)
        LabelCil(84).Visible = v1 : TextCil(54).Visible = v1
    End Sub
    Private Function CheckTubi() As Boolean
        Dim i As Short
        Dim O As wn_PT
        For i = 1 To Config(3).Ninvolucri
            If Involucr(3, i).Tipo = 7 Then
            End If
        Next
        'qui si vuole verificare se esistono tubi e se il tipo U/diritti
        'è compatibile con la piastra che si vuole scegliere
        'però il tipo di tubi non è gestito in Involucr
        'Tuttavia, almeno se c'è un dilatatore, bisogna rifiutarsi di passare a UTEMA
        CheckTubi = False
        O = objMemb(Involucr(kLato, jInvolucr).IndObject)
        If O.TipoPT = 1 Then Exit Function 'è già UTEMA
        If CType(O.Piastra, wn_FTC).IndiceDilat > -1 Then CheckTubi = True
    End Function
    Private Sub AggiustaDiff()
        Dim Tre As Boolean
        Dim PDIFF As Single
        Dim i As Short
        Dim j As Short
        Try
            With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
                If Not (CType(.Piastra, wn_FTC).Rear = 1 Or CType(.Piastra, wn_FTC).Rear = 2 And CType(.Piastra, wn_FTC).Rules > 0) Then Exit Sub
                PDIFF = System.Math.Abs(.DiffPress)
                Tre = PDIFF > 0 And PDIFF <> System.Math.Abs(.PDesChan - .PDesShel)
                If CType(.Piastra, wn_FTC).pCondizio(1).Trim.Length = 0 Then CType(.Piastra, wn_FTC).pCondizio(1) = "Design Condition"
                If .ProgDiffPr And Tre Then
                    If CType(.Piastra, wn_FTC).Zp(1, 261) > 6 Then
                        MostraAiuto(IDH_CAPIENZACONDIZIONI)
                        .ProgDiffPr = False
                        Exit Sub
                    End If
                    _TextCil_89.Minimum = 3
                    If CType(.Piastra, wn_FTC).Zp(1, 633) <> 1 Then
                        With CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
                            .Zp(1, 261) = .Zp(1, 261) + 2
                            _TextCil_89.Value = CInt(.Zp(1, 261))
                            For i = .Zp(1, 261) To 4 Step -1
                                For j = 1 To 300
                                    .Zp(i, j) = .Zp(i - 2, j)
                                Next
                                .pCondizio(i) = .pCondizio(i - 2)
                                .pNeventi(i) = .pNeventi(i - 2)
                            Next
                            .pCondizio(2) = "Design condition (dp=+" & Str(PDIFF) & ")"
                            .pCondizio(3) = "Design condition (dp=-" & Str(PDIFF) & ")"
                            .pNeventi(2) = 0
                            .pNeventi(3) = 0
                            .Zp(2, 1) = .PDesChan - PDIFF
                            .Zp(2, 2) = .PDesChan
                            .Zp(3, 1) = .PDesShel
                            .Zp(3, 2) = .PDesShel - PDIFF
                        End With
                    Else
                        CType(.Piastra, wn_FTC).Zp(1, 633) = 1
                    End If
                Else
                    _TextCil_89.Minimum = 1
                    If CType(.Piastra, wn_FTC).Zp(1, 633) = 1 Then
                        With CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
                            .Zp(1, 261) = .Zp(1, 261) - 2
                            _TextCil_89.Value = CInt(.Zp(1, 261))
                            For i = 2 To .Zp(1, 261)
                                For j = 1 To 300
                                    .Zp(i, j) = .Zp(i + 2, j)
                                Next
                                .pCondizio(i) = .pCondizio(i + 2)
                                .pNeventi(i) = .pNeventi(i + 2)
                            Next
                        End With
                    Else
                        CType(.Piastra, wn_FTC).Zp(1, 633) = 0
                    End If
                End If
            End With
        Catch
        End Try
    End Sub
    Private Sub AggiornaCollegFl()
        Dim ll, i, l, indic As Short
        Dim ii, j As Short
        Try
            For i = 1 To 4
                l = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).IndAccopp(i)
                Select Case i
                    Case 1 : ll = 51 'LT _cmbCil_51.ListIndex = l - 1
                        ii = 2 : indic = 5
                    Case 2 : ll = 81 'LM _cmbCil_81.ListIndex = l - 1
                        ii = 1 : indic = 4
                    Case 3 : ll = 101 'LT _cmbCil_101.ListIndex = l - 1
                        ii = 2 : indic = 5
                    Case 4 : ll = 121 'LM _cmbCil_121.ListIndex = l - 1
                        ii = 1 : indic = 4
                End Select
                If l > 0 Then
                    If cmbCil(ll).Enabled Then
                        cmdCil(100 + ll).Visible = True
                        cmbMatFl(100 + ll).Text = ""
                        For j = 0 To List2(ll).Items.Count - 1
                            If System.Math.Abs(Val(List2(ll).Items(j))) = l Then
                                cmbCil(ll).SelectedIndex = j
                                NonScollegare = True
                                cmbCil_TextChanged(ll)
                                NonScollegare = False
                                cmdCil(100 + ll).Visible = False
                                If Involucr(ii, l).indice(1 - 1) > 0 Then _
                                cmbMatFl(100 + ll).Text = Matdim(Involucr(ii, l).indice(1 - 1)).MatStr.Trim
                                Exit For
                            End If
                        Next
                    End If
                Else 'scollegato
                    Dim fondo As Boolean = False
                    If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).TipoPT = 2 Then
                        With CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
                            fondo = .IndiceFlanF > 0 Or .IndiceFondo > 0 Or .IndiceSplitR > 0
                        End With
                    End If
                    If Not fondo Then
                        If cmbCil(ll).Enabled Then
                            cmdCil(100 + ll).Visible = True
                            cmbMatFl(100 + ll).Text = ""
                            cmbCil(ll).SelectedIndex = cmbCil(ll).Items.Count - 1
                            NonScollegare = True
                            cmbCil_TextChanged(ll)
                            NonScollegare = False
                        End If
                    End If
                End If
                If cmbMatFl(100 + ll).Text = "" Then
                    If Involucr(kLato, jInvolucr).indice(indic - 1) > 0 Then
                        If Not Matdim(Involucr(kLato, jInvolucr).indice(indic - 1)) Is Nothing Then
                            cmbMatFl(100 + ll).Text = Matdim(Involucr(kLato, jInvolucr).indice(indic - 1)).MatStr.Trim
                        End If
                    End If
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub TextCil_Leave(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim LC, t, l, Lp As Single
        Dim PT As wn_PT
        PT = objMemb(Involucr(kLato, jInvolucr).IndObject)
        If PT.TipoPT = 1 Then Exit Sub
        Select Case Index
            Case 18, 83, 98, 104 'sp piastra, lungh tubi, lungh ports, lungh coni 
                t = GlobalRoutines.ValVir(_TextCil_18.Text) / kLength
                l = GlobalRoutines.ValVir(_TextCil_83.Text) / kLength
                LC = GlobalRoutines.ValVir(TextCil(104).Text) / kLength
                Lp = GlobalRoutines.ValVir(TextCil(98).Text) / kLength
                TextCil(100).Text = GlobalRoutines.myStr((l - 2 * t - 6 - 2 * LC - 2 * Lp) * kLength, 4, 2, False)
            Case 101, 59 'Dc secondo RCB-7.1411
                With CType(PT.Piastra, wn_FTC)
                    If .Zp(1, 309) < .Zp(1, 592) And .Zp(1, 309) > 0 Then
                        If .Zp(1, 592) = 0 Then
                            .Zp(1, 592) = .Zp(1, 309)
                        Else
                            MessageBox.Show("Valori per Dc e per De incompatibili")
                        End If
                    End If
                End With
            Case 100 'lunghezza cilindro
        End Select
        Exit Sub
    End Sub
    Private Sub SecExtVis()
        Dim V As Boolean
        Dim i As Short
        i = Involucr(kLato, jInvolucr).IndObject
        If i = 0 Then Exit Sub
        Try
            With CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC)
                V = .Flottante = 3 And .Rear = 2
                LabelCil(90).Visible = V
                _TextCil_57.Visible = V
                V = .Flottante = 1 And (.Rules = 0 Or .Rules = 2) And .Rear = 2
                LabelCil(123).Visible = V
                cmdCil(11).Visible = V
                _TextCil_101.Visible = V
            End With
        Catch e As Exception
            '   messagebox.show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub EqualPiastre(ByRef PT As wn_FTC)
        Dim buf1 As Object
        Dim i As Short
        Dim buf3 As Object = Nothing
        Dim buf2 As Object = Nothing
        Dim buf4 As Object = Nothing
        With PT
            For i = 1 To 20
                .SetPiastra(1)
                buf1 = .FlChanDati(i)
                buf2 = .FlShelDati(i)
                If i < 3 Then
                    buf3 = .SlChanDati(i)
                    buf4 = .SlShelDati(i)
                End If
                .SetPiastra(2)
                .FlChanDati(i) = buf1
                .FlShelDati(i) = buf2
                If i < 3 Then
                    .SlChanDati(i) = buf3
                    .SlShelDati(i) = buf4
                End If
            Next
            .SetPiastra(1)
        End With
    End Sub
    Private Sub ScelFonF()
        Dim Testo As String
        Dim jj, i As Short
        kSav = kLato : jSav = jInvolucr
        j = 0
        _cmbCil_13.Items.Clear()
        List4.Items.Clear()
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            Select Case .Piastra.Flottante
                Case 1 : iii = 2
                Case Else : iii = 3
            End Select
            For i = 1 To Config(iii).Ninvolucri
                If Involucr(iii, i).Tipo <= 2 Then
                    j = j + 1
                    _cmbCil_13.Items.Add(Trim(Involucr(iii, i).Mark))
                    List4.Items.Add(i.ToString)
                End If
            Next
            _cmbCil_13.Items.Add("Nessuno")
            List4.Items.Add("0")
            If j = 0 Then
                'Testo = "   Non risulta inserito nessun elemento" & vbCrLf
                'Testo = Testo & "che possa giocare il ruolo di cassa" & vbCrLf
                'Testo = Testo & "per la testa flottante." & vbCrLf
                'Testo = Testo & "   Vuoi che te lo inserisca io?"
                Testo = GlobalRoutines.FormatS(Helpstringa(5026), rmHelpStrings.GetString("Cassa"))
                Testo = clsInizio.ConvertiCr(Testo & rmHelpStrings.GetString("nota2_inserisci_elemento"))
                Select Case .Piastra.Flottante
                    Case 1 'P - outside packed 'Virola cassa flottante
                        .Piastra.TipoFF = 7
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        Config(2).Ninvolucri = Config(2).Ninvolucri + 1
                        j = Config(2).Ninvolucri
                        Ridimensiona(j)
                        Introduci(2, j)
                        Involucr(2, j).Tipo = 0
                        Involucr(2, j).ES = 1
                        Involucr(2, j).Mark = "Floating channel course"
                        Involucr(2, j).di = Config(1).di
                        objMemb(Involucr(kSav, jSav).IndObject).Piastra.IndiceFondo = j
                    Case 2 'S - with back-ring
                        If .Piastra.TipoFF < 1 Or .Piastra.TipoFF > 10 Then .Piastra.TipoFF = 8
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        Select Case .Piastra.TipoFF
                            Case 5, 8 '1.6d,generico
                                FonFlott()
                                PT = .Piastra
                                SuperRec()
                            Case 10 'cono
                                MessageBox.Show("Fondo flottante di tipo conico non previsto in ScelFonF")
                        End Select
                    Case 3 'T - Flanged
                        If .Piastra.TipoFF < 1 Or .Piastra.TipoFF > 10 Then .Piastra.TipoFF = 6
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        Select Case .Piastra.TipoFF
                            Case 1, 2, 6 'torosferico
                                FonFlott()
                                PT = .Piastra
                                SuperRec()
                            Case 3, 4
                                MessageBox.Show("Questo tipo di fondo flottante non è ancora previsto")
                                jInvolucr = jSav : kLato = kSav
                                Exit Sub
                            Case 5 'calotta
                                Config(3).Ninvolucri = Config(3).Ninvolucri + 1
                                j = Config(3).Ninvolucri
                                Ridimensiona(j)
                                Introduci(3, j)
                                Involucr(3, j).Tipo = 1
                                Involucr(3, j).ES = 1
                                Involucr(3, j).ms = 8
                                Involucr(3, j).Mark = "Floating dished head"
                                Involucr(3, j).di = Config(1).di
                                PT = .Piastra
                                SuperRec()
                                'If PT.OTL > 0 Then
                                Involucr(3, j).L0 = PT.OTL / 2 / System.Math.Sin(pi / 6)
                                'End If
                                'Involucr(3, j).L0 = Involucr(3, i).di / 2 / Sin(pi / 6)
                            Case 10 ' cono
                                Config(3).Ninvolucri = Config(3).Ninvolucri + 1
                                j = Config(3).Ninvolucri
                                Ridimensiona(j)
                                Introduci(3, j)
                                Involucr(3, j).Tipo = 2
                                Involucr(3, j).ES = 1
                                Involucr(3, j).Mark = "Floating conical head"
                                Involucr(3, j).L0 = 0
                                Involucr(3, j).H0 = 0
                                PT = .Piastra
                                SuperRec()
                                Involucr(3, j).di = Int(PT.OTL) + 40
                                Involucr(3, j).dns = Int(Involucr(3, j).di / 3)
                                Involucr(3, j).R0 = 30
                        End Select
                    Case 4 'T - integral fondo 2:1
                        .Piastra.TipoFF = 7
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        Config(3).Ninvolucri = Config(3).Ninvolucri + 1
                        j = Config(3).Ninvolucri
                        Ridimensiona(j)
                        Introduci(3, j)
                        Involucr(3, j).Tipo = 1
                        Involucr(3, j).ES = 1
                        Involucr(3, j).ms = 1
                        Involucr(3, j).Mark = "Floating dished head"
                        Involucr(3, j).di = Config(1).di
                        SuperRec()
                        .SlChanNome = Trim(Involucr(3, j).Mark)
                        RiempiCollegFl()
                    Case 5 'W - internally sealed
                        .Piastra.TipoFF = 9
                End Select
                If j > 0 Then
                    DatiInputC(1)
                    Select Case Involucr(iii, j).Tipo
                        Case 1
                            If Not DatiCompFon(iii, j, 2) Then
                                jInvolucr = jSav : kLato = kSav
                                Config(iii).Ninvolucri = Config(iii).Ninvolucri - 1
                                Exit Sub
                            End If
                        Case 0
                            If Not DatiCompCyl(iii, j, 2) Then
                                jInvolucr = jSav : kLato = kSav
                                Config(iii).Ninvolucri = Config(iii).Ninvolucri - 1
                                Exit Sub
                            End If
                        Case 2
                            If Not DatiCompCon(iii, j, 2) Then
                                jInvolucr = jSav : kLato = kSav
                                Config(iii).Ninvolucri = Config(iii).Ninvolucri - 1
                                Exit Sub
                            End If
                    End Select
                    If .Piastra.Flottante = 4 Then
                        For iii = 0 To _cmbCil_101.Items.Count - 1
                            If _cmbCil_101.Items(iii) = Trim(Involucr(3, j).Mark) Then
                                _cmbCil_101.SelectedIndex = iii
                                Exit For
                            End If
                        Next
                    End If
                    _cmbCil_13.Items.Clear()
                    List4.Items.Clear()
                    _cmbCil_13.Items.Add(Trim(Involucr(iii, j).Mark))
                    _cmbCil_13.Items.Add("Nessuno")
                    List4.Items.Add(j.ToString)
                    List4.Items.Add("0")
                    _cmbCil_13.SelectedIndex = 0
                End If
                jInvolucr = jSav : kLato = kSav
            Else
                jj = .Piastra.IndiceFondo
                If jj <= 0 Then
                    _cmbCil_13.SelectedIndex = _cmbCil_13.Items.Count - 1
                Else
                    For i = 0 To _cmbCil_13.Items.Count - 2
                        If GlobalRoutines.ValVir(List4.Items(i)) = jj Then
                            Saltacombo = True
                            _cmbCil_13.SelectedIndex = i
                            Saltacombo = False
                            Exit For
                        End If
                    Next
                    jInvolucr = jSav : kLato = kSav
                End If
            End If
        End With
        Exit Sub
    End Sub
    Private Sub SuperRec()
        Dim i As Short
        For i = 1 To Config(3).Ninvolucri
            If Involucr(3, i).Tipo = 7 Then
                kLato = 3 : jInvolucr = i
                If PT.OTL > 0 Then
                    Involucr(3, i).di = PT.OTL 'Int(objTraccia.OTL + 15.4)
                    Exit Sub
                End If
                Dim objTraccia As traccia.clsTracciatura = New traccia.clsTracciatura
                objTraccia.DoveMotore = Monitor.Motore
                File = GenFile(i)
                If Len(File) = 0 Then GoTo Ret
                Dim Res As Integer = objTraccia.Esegui(1, File)
                Select Case Res
                    Case 0
                        Involucr(3, i).di = Int(objTraccia.OTL)
                        PT.OTL = Involucr(3, i).di
                    Case 1
                        MessageBox.Show("La tracciatura " & File & " non è stata trovata. ")
                End Select
Ret:
                objTraccia = Nothing
                jInvolucr = j
                Exit Sub
            End If
        Next
        i = 0
        Dim Testo As String = "  Non è stato trovato l'elemento" & vbCrLf
        Testo = Testo & "'Tubi di scambio'. Non è quindi" & vbCrLf
        Testo = Testo & "possibile desumere dall'OTL il" & vbCrLf
        Testo = Testo & "diametro interno del fondo"
        MessageBox.Show(Me, Testo)
    End Sub
    Private Sub FonFlott()
        Config(3).Ninvolucri = Config(3).Ninvolucri + 1
        j = Config(3).Ninvolucri
        Ridimensiona(j)
        Introduci(3, j)
        Involucr(3, j).Tipo = 1
        Involucr(3, j).ES = 1
        Involucr(3, j).ms = 3
        Involucr(3, j).Mark = "Floating dished head"
        Involucr(3, j).di = Config(1).di
        CType(objMemb(Involucr(kSav, jSav).IndObject), wn_PT).Piastra.IndiceFondo = j
    End Sub
    Private Sub GeneraSplitR(ByRef j As Short, ByVal domanda As Boolean)
        Dim Risp As ChiaviMess
        ' Testo = "   Non risulta inserito nessun elemento" & vbCrLf
        ' Testo = Testo & "che possa giocare il ruolo di split ring" & vbCrLf
        ' Testo = Testo & "per la testa flottante." & vbCrLf
        ' Testo = Testo & "   Vuoi che te lo inserisca io?"
        Dim Testo As String = GlobalRoutines.FormatS(Helpstringa(5026), rmHelpStrings.GetString("Split_Ring"))
        Testo = clsInizio.ConvertiCr(Testo & rmHelpStrings.GetString("nota1_inserisci_elemento"))
        Select Case CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra.TipoFF
            Case 1, 2 'torosferico
                MessageBox.Show(Me, "Questo tipo di fondo flottante non è ancora previsto")
            Case 5 'calotta
                If domanda Then
                    Risp = MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, _
                    Testo, "AsmeVip - Piastre Tubiere")
                Else
                    Risp = ChiaviMess.MessSi
                End If
                If Risp Then
                    FlanCalottR(j)
                End If
            Case 3, 4
                MessageBox.Show(Me, "Questo tipo di fondo flottante non è ancora previsto")
            Case 6 'flangiata
                If domanda Then
                    Risp = MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, _
                    Testo, "AsmeVip - Piastre Tubiere")
                Else
                    Risp = ChiaviMess.MessSi
                End If
                If Risp Then
                    FlanCalottR(j)
                End If
            Case 7 ' tipo P
            Case 8 'con back ring
                If domanda Then
                    Risp = MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, _
                    Testo, "AsmeVip - Piastre Tubiere")
                Else
                    Risp = ChiaviMess.MessSi
                End If
                If Risp Then
                    FlanCalottR(j)
                End If
            Case 9 'tipo W
            Case 10 'cono
        End Select
    End Sub
    Private Sub ScelSplitR()
        Dim jSav, kSav As Short
        Dim i As Short
        Dim Testo As String
        If Involucr(kLato, jInvolucr).IndObject = 0 Then Exit Sub
        kSav = kLato : jSav = jInvolucr
        j = 0
        _cmbCil_15.Items.Clear()
        List6.Items.Clear()
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            For i = 1 To Config(3).Ninvolucri
                If Involucr(3, i).Tipo = 5 Then
                    j = j + 1
                    _cmbCil_15.Items.Add(Trim(Involucr(3, i).Mark))
                    List6.Items.Add(i.ToString)
                End If
            Next
            _cmbCil_15.Items.Add("Aggiungine uno")
            List6.Items.Add("999")
            _cmbCil_15.Items.Add("Nessuno")
            List6.Items.Add("0")
            If j = 0 Then
                GeneraSplitR(j, True)
                If j > 0 Then
                    DatiInputC(1)
                    If Not DatiCompFla(3, j, 2) Then
                        jInvolucr = jSav : kLato = kSav
                        Config(3).Ninvolucri = Config(3).Ninvolucri - 1
                        Exit Sub
                    End If
                    jInvolucr = jSav : kLato = kSav
                    _cmbCil_15.Items.Clear()
                    List6.Items.Clear()
                    j = 0
                    For i = 1 To Config(3).Ninvolucri
                        If Involucr(3, i).Tipo = 5 Then
                            _cmbCil_15.Items.Add(Trim(Involucr(3, i).Mark))
                            List6.Items.Add(i.ToString)
                            j = j + 1
                        End If
                    Next
                    _cmbCil_15.Items.Add("Nessuno")
                    List6.Items.Add("0")
                    _cmbCil_15.SelectedIndex = j - 1
                Else
                    jInvolucr = jSav : kLato = kSav
                End If
            Else
                Dim jj As Short = .Piastra.IndiceSplitR
                If jj <= 0 Then
                    _cmbCil_15.SelectedIndex = _cmbCil_15.Items.Count - 1
                Else
                    For i = 0 To _cmbCil_15.Items.Count - 2
                        If GlobalRoutines.ValVir(List6.Items(i)) = jj Then
                            _cmbCil_15.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                jInvolucr = jSav : kLato = kSav
            End If
        End With
    End Sub
    Private Sub FlanCalottR(ByRef j As Short)
        Dim iij, jj, jjj As Short
        Try
            With CType(objMemb(Involucr(kSav, jSav).IndObject), wn_PT)
                Config(3).Ninvolucri = Config(3).Ninvolucri + 1
                j = Config(3).Ninvolucri
                Ridimensiona(j)
                Introduci(3, j)
                Involucr(3, j).Tipo = 5
                Involucr(3, j).Mark = "Split Ring"
                kLato = 3
                CreaOggetto(j)
                Dim i As Short = Involucr(3, j).IndObject
                CType(objMemb(i), wn_flan).Mem.LOOSE = -1 ' 2 'per la flangia; -1 per lo SR
                CType(objMemb(i), wn_flan).Zp(7) = -1 ' 0 'per la flangia; -1 per lo SR
                CType(objMemb(i), wn_flan).Mp(195) = 0 ' 1 'calcolo per flottante per 1.6d; 2 per cono
                .Piastra.IndiceSplitR = j
                If .Piastra.IndiceFlanF > 0 Then
                    iij = .Piastra.IndiceFlanF
                    Select Case .Piastra.Flottante
                        Case 1 : iii = 2
                        Case Else : iii = 3
                    End Select
                    jj = Involucr(iii, iij).IndObject
                    If jj <= 0 Then
                        Dim Testo As String = "Impossibile completare l'inserimento automatico dei dati" & vbCrLf
                        Testo = Testo & "perché non è stata definita la flangia del fondo flottante" & vbCrLf
                        Testo = Testo & "Completare i dati manualmente"
                        MessageBox.Show(Me, Testo, "AsmeVip - " & Trim(Involucr(kLato, jInvolucr).Mark))
                        Exit Sub
                    End If
                    CType(objMemb(i), wn_flan).Mp(3) = CType(objMemb(jj), wn_flan).Mp(3)
                    CType(objMemb(i), wn_flan).Zp(3) = CType(objMemb(jj), wn_flan).Zp(3)
                    CType(objMemb(i), wn_flan).Mp(4) = CType(objMemb(jj), wn_flan).Mp(4)
                    CType(objMemb(i), wn_flan).Zp(4) = CType(objMemb(jj), wn_flan).Zp(4)
                    CType(objMemb(i), wn_flan).Mp(5) = CType(objMemb(jj), wn_flan).Mp(5)
                    CType(objMemb(i), wn_flan).Zp(5) = CType(objMemb(jj), wn_flan).Zp(5)
                    For jjj = 26 To 41
                        CType(objMemb(i), wn_flan).Mp(jjj) = CType(objMemb(jj), wn_flan).Mp(jjj)
                        CType(objMemb(i), wn_flan).Zp(jjj) = CType(objMemb(jj), wn_flan).Zp(jjj)
                    Next
                    Involucr(iii, iij).AccoppJ = j
                    Involucr(iii, iij).AccoppK = 3
                    Involucr(3, j).AccoppJ = iij
                    Involucr(3, j).AccoppK = iii
                Else
                    Dim Testo As String = "Impossibile completare l'inserimento automatico dei dati" & vbCrLf
                    Testo = Testo & "perché non è stata definita la flangia del fondo flottante." & vbCrLf
                    Testo = Testo & "Completare i dati manualmente"
                    MessageBox.Show(Me, Testo, "AsmeVip - " & Trim(Involucr(kLato, jInvolucr).Mark))
                End If
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub ScelFlanF()
        Dim jSav, kSav As Short
        Dim Testo As String
        Dim i As Short
        Dim jj As Short
        If Involucr(kLato, jInvolucr).IndObject = 0 Then Exit Sub
        kSav = kLato : jSav = jInvolucr
        j = 0
        _cmbCil_14.Items.Clear()
        List5.Items.Clear()
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            For i = 1 To Config(3).Ninvolucri
                If Involucr(3, i).Tipo = 5 Then
                    j = j + 1
                    'indiceD(j) = i
                    'Strin(j) = Trim(Involucr(3, i).Mark)
                    _cmbCil_14.Items.Add(Trim(Involucr(3, i).Mark))
                    List5.Items.Add(i.ToString)
                End If
            Next
            _cmbCil_14.Items.Add("Nessuno")
            List5.Items.Add("0")
            If j = 0 Then
                'Testo = "   Non risulta inserito nessun elemento" & vbCrLf
                'Testo = Testo & "che possa giocare il ruolo di flanga" & vbCrLf
                'Testo = Testo & "per la testa flottante." & vbCrLf
                'Testo = Testo & "   Vuoi che te lo inserisca io?"
                Testo = GlobalRoutines.FormatS(Helpstringa(5026), rmHelpStrings.GetString("Flangia"))
                Testo = clsInizio.ConvertiCr(Testo & rmHelpStrings.GetString("nota2_inserisci_elemento"))
                Select Case .Piastra.TipoFF
                    Case 1, 2 'torosferico
                        MessageBox.Show(Me, "Questo tipo di fondo flottante non è ancora previsto")
                        jInvolucr = jSav : kLato = kSav
                        Exit Sub
                    Case 5 'calotta
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        FlanCalott(1)
                    Case 3, 4
                        MessageBox.Show(Me, "Questo tipo di fondo flottante non è ancora previsto")
                        jInvolucr = jSav : kLato = kSav
                        Exit Sub
                    Case 6 'flangiata
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        FlanCalott(3)
                    Case 7 ' tipo P
                    Case 8 'con back ring
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        FlanCalott(3)
                    Case 9 'tipo W
                    Case 10 'cono
                        If MostraAiuto(5026, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Testo, "AsmeVip - Piastre Tubiere") = ChiaviMess.Messno Then Exit Sub
                        FlanCalott(2)
                End Select
                If j > 0 Then
                    DatiInputC(1)
                    If Not DatiCompFla(3, j, 2) Then
                        jInvolucr = jSav : kLato = kSav
                        Config(3).Ninvolucri = Config(3).Ninvolucri - 1
                        Exit Sub
                    End If
                    jInvolucr = jSav : kLato = kSav
                    _cmbCil_14.Items.Clear()
                    List5.Items.Clear()
                    _cmbCil_14.Items.Add(Trim(Involucr(3, j).Mark))
                    _cmbCil_14.Items.Add("Nessuno")
                    List5.Items.Add(j.ToString)
                    List5.Items.Add("0")
                    _cmbCil_14.SelectedIndex = 0
                    '_TextCil_92 = Trim(Involucr(3, j).Mark)
                End If
            Else
                jj = .Piastra.IndiceFlanF
                If jj <= 0 Then
                    _cmbCil_14.SelectedIndex = _cmbCil_14.Items.Count - 1
                Else
                    For i = 0 To _cmbCil_14.Items.Count - 2
                        If GlobalRoutines.ValVir(List5.Items(i)) = jj Then
                            _cmbCil_14.SelectedIndex = i
                            Exit For
                        End If
                    Next
                    jInvolucr = jSav : kLato = kSav
                End If
            End If
        End With
    End Sub
    Private Sub FlanCalott(ByVal Tipo16 As Short)
        With CType(objMemb(Involucr(kSav, jSav).IndObject), wn_PT)
            Config(3).Ninvolucri = Config(3).Ninvolucri + 1
            j = Config(3).Ninvolucri
            Ridimensiona(j)
            Introduci(3, j)
            Involucr(3, j).Tipo = 5
            Involucr(3, j).Mark = "Floating Head Flange"
            kLato = 3
            CreaOggetto(j)
            Dim i As Short = Involucr(3, j).IndObject
            Select Case Tipo16
                Case 1
                    CType(objMemb(i), wn_flan).Mem.LOOSE = -2 ' 2 'per la flangia; -1 per lo SR
                    CType(objMemb(i), wn_flan).Zp(7) = 0 ' 0 'per la flangia; -1 per lo SR
                    CType(objMemb(i), wn_flan).Mp(195) = 1 ' 1 'calcolo per flottante per 1.6d; 2 per cono
                Case 2
                    CType(objMemb(i), wn_flan).Mem.LOOSE = -2 ' 2 'per la flangia; -1 per lo SR
                    CType(objMemb(i), wn_flan).Zp(7) = 0 ' 0 'per la flangia; -1 per lo SR
                    CType(objMemb(i), wn_flan).Mp(195) = 2 ' 1 'calcolo per flottante per 1.6d; 2 per cono
                Case 3
                    CType(objMemb(i), wn_flan).Mem.LOOSE = 0 ' 2 'per la flangia; -1 per lo SR
                    CType(objMemb(i), wn_flan).Zp(7) = 0 ' 0 'per la flangia; -1 per lo SR
                    CType(objMemb(i), wn_flan).Mp(195) = 0 ' 1 'calcolo per flottante per 1.6d; 2 per cono
            End Select
            .Piastra.IndiceFlanF = j
            TransferDaFondoSuFlan(CType(objMemb(Involucr(kSav, jSav).IndObject), wn_PT), i)
        End With
    End Sub
    Private Sub TransferDaFondoSuFlan(ByVal O As wn_PT, ByVal indObjFlan As Short)
        Dim iij As Short = O.Piastra.IndiceFondo
        If iij > 0 Then
            Select Case O.Piastra.Flottante
                Case 1 : iii = 2
                Case Else : iii = 3
            End Select
            Dim Dfon As Single = Involucr(iii, iij).di
            Dim Rcurv As Single = Involucr(iii, iij).L0
            If Dfon * Rcurv <= 0 Then
                Dim Testo As String = "Impossibile completare l'inserimento automatico dei dati" & vbCrLf
                Testo = Testo & "perché non sono stati definiti il diametro e il raggio di" & vbCrLf
                Testo = Testo & "curvatura della calotta " & Trim(Involucr(iii, O.Piastra.IndiceFondo).Mark)
                MessageBox.Show(Me, Testo, "AsmeVip - " & Trim(Involucr(kLato, jInvolucr).Mark))
                Exit Sub
            End If
            CType(objMemb(indObjFlan), wn_flan).Mp(6) = Dfon
            CType(objMemb(indObjFlan), wn_flan).Zp(6) = Dfon / inc
            Select Case Involucr(3, iij).Tipo
                Case 1 'calotta
                    CType(objMemb(indObjFlan), wn_flan).Mp(126) = 180 / pi * GlobalRoutines.asin(Involucr(3, iij).di / 2 / Rcurv)
                    CType(objMemb(indObjFlan), wn_flan).Zp(126) = CType(objMemb(indObjFlan), wn_flan).Mp(10)
                    CType(objMemb(indObjFlan), wn_flan).Mp(124) = Rcurv
                    CType(objMemb(indObjFlan), wn_flan).Zp(124) = Rcurv / inc
                Case 2 '
                    CType(objMemb(indObjFlan), wn_flan).Mp(126) = 90 - Involucr(3, iij).R0
                    CType(objMemb(indObjFlan), wn_flan).Mp(124) = 0
                    CType(objMemb(indObjFlan), wn_flan).Zp(124) = 0
                    CType(objMemb(indObjFlan), wn_flan).Mp(195) = 2
            End Select
        End If
    End Sub
    Private Sub SuperAggiorna()
        Dim i As Short
        AggCombo()
        AggCombo6()
        AggTesti()
        If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).PrimaVolta Then
            CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).PrimaVolta = False
            For i = 24 To 32
                cmdCil_Click(i)
            Next
        End If
        If TipoPiastra = 2 And _cmbCil_1.SelectedIndex = 3 Then
            AggCombo6()
            AggCombo()
        End If
        RiempiCollegFl()
    End Sub
    Private Sub txtIBW_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtIBW.TextChanged
        If Inizializzando Then Exit Sub
        If Aggiornando Then Exit Sub
        Dim PT As wn_PT
        PT = objMemb(Involucr(kLato, jInvolucr).IndObject)
        PT.diamIBW = GlobalRoutines.ValVir(txtIBW.Text)
    End Sub
    Private Sub _TextCil_89_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TextCil_89.ValueChanged
        If Inizializzando Then Exit Sub
        Dim PT As wn_PT
        If Aggiornando Then Exit Sub
        PT = objMemb(Involucr(kLato, jInvolucr).IndObject)
        PT.Piastra.Zp(1, 261) = _TextCil_89.Value ' GlobaLroutines.ValVir(TextCil(Index).Text)
    End Sub
    Private Sub _Check1_0_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_0.CheckStateChanged
        Check1_CheckStateChanged(0)
    End Sub
    Private Sub _Check1_1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_1.CheckStateChanged
        Check1_CheckStateChanged(1)
    End Sub
    Private Sub _Check1_2_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_2.CheckStateChanged
        Check1_CheckStateChanged(2)
    End Sub
    Private Sub _Check1_3_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_3.CheckStateChanged
        Check1_CheckStateChanged(3)
    End Sub
    Private Sub _Check1_4_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_4.CheckStateChanged
        Check1_CheckStateChanged(4)
    End Sub
    Private Sub _Check1_5_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_5.CheckStateChanged
        Check1_CheckStateChanged(5)
    End Sub
    Private Sub _Check1_6_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_6.CheckStateChanged
        Check1_CheckStateChanged(6)
    End Sub
    Private Sub _Check1_7_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_7.CheckStateChanged
        Check1_CheckStateChanged(7)
    End Sub
    Private Sub _Check1_8_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_8.CheckStateChanged
        Check1_CheckStateChanged(8)
    End Sub
    Private Sub _Check1_9_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_9.CheckStateChanged
        Check1_CheckStateChanged(9)
    End Sub
    Private Sub _Check1_10_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_10.CheckStateChanged
        Check1_CheckStateChanged(10)
    End Sub
    Private Sub _Check1_11_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_11.CheckStateChanged
        Check1_CheckStateChanged(11)
    End Sub
    Private Sub _Check1_12_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_12.CheckStateChanged
        Check1_CheckStateChanged(12)
    End Sub
    Private Sub _Check1_401_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_401.CheckStateChanged
        Check1_CheckStateChanged(401)
    End Sub
    Private Sub _Check1_402_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_402.CheckStateChanged
        Check1_CheckStateChanged(402)
    End Sub
    Public ReadOnly Property LabelCil(ByVal i As Short) As Label
        Get
            Dim c, c1, c2 As Control
            For Each c In Controls
                For Each c1 In c.Controls
                    If c1.Name = "_LabelCil_" & i.ToString Then Return CType(c1, Label)
                    For Each c2 In c1.Controls
                        If c2.Name = "_LabelCil_" & i.ToString Then Return CType(c2, Label)
                    Next
                Next
            Next
            Return Nothing
        End Get
    End Property
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Dim c, c1, c2 As Control
            For Each c In Controls
                For Each c1 In c.Controls
                    If c1.Name = "_TextCil_" & i.ToString Then Return CType(c1, TextBox)
                    For Each c2 In c1.Controls
                        If c2.Name = "_TextCil_" & i.ToString Then Return CType(c2, TextBox)
                    Next
                Next
            Next
            Return Nothing
        End Get
    End Property
    Friend ReadOnly Property lblUni(ByVal i As Short) As Label
        Get
            Select Case i
                Case 10 : Return _lblUni_10
                Case 24 : Return _lblUni_24
                Case 25 : Return _lblUni_25
                Case 26 : Return _lblUni_26
                Case 27 : Return _lblUni_27
                Case 28 : Return _lblUni_28
                Case 29 : Return _lblUni_29
                Case 30 : Return _lblUni_30
                Case 31 : Return _lblUni_31
                Case 52 : Return _lblUni_52
                Case 91 : Return _lblUni_91
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property cmbCil(ByVal i As Short) As ComboBox
        Get
            Dim c, c1, c2 As Control
            For Each c In Controls
                For Each c1 In c.Controls
                    If c1.Name = "_cmbCil_" & i.ToString Then Return CType(c1, ComboBox)
                    For Each c2 In c1.Controls
                        If c2.Name = "_cmbCil_" & i.ToString Then Return CType(c2, ComboBox)
                    Next
                Next
            Next
            Return Nothing
        End Get
    End Property
    Friend ReadOnly Property cmdCil(ByVal i As Short) As Button
        Get
            Dim c, c1, c2 As Control
            For Each c In Controls
                For Each c1 In c.Controls
                    If c1.Name = "_cmdCil_" & i.ToString Then Return CType(c1, Button)
                    For Each c2 In c1.Controls
                        If c2.Name = "_cmdCil_" & i.ToString Then Return CType(c2, Button)
                    Next
                Next
            Next
            Return Nothing
        End Get
    End Property
    Private ReadOnly Property Frames(ByVal i As Short) As GroupBox
        Get
            Select Case i
                Case 0 : Return _Frames_0
                Case 1 : Return _Frames_1
                Case 2 : Return _Frames_2
                Case 3 : Return _Frames_3
                Case 4 : Return _Frames_4
                Case 5 : Return _Frames_5
                Case 6 : Return _Frames_6
                Case 7 : Return _Frames_7
                Case 8 : Return _Frames_8
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Framesf(ByVal i As Short) As GroupBox
        Get
            Select Case i
                Case 0 : Return _Framesf_0
                Case 1 : Return _Framesf_1
                Case 2 : Return _Framesf_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property List2(ByVal i As Short) As ListBox
        Get
            Select Case i
                Case 51 : Return _List2_51
                Case 81 : Return _List2_81
                Case 101 : Return _List2_101
                Case 121 : Return _List2_121
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _Option1_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_0.CheckedChanged
        Option1_CheckedChanged(0, CType(sender, RadioButton).Checked)
    End Sub

    Private Sub _Option1_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_1.CheckedChanged
        Option1_CheckedChanged(1, CType(sender, RadioButton).Checked)
    End Sub
    Private Sub _TextCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.TextChanged
        TextCil_TextChanged(10)
    End Sub

    Private Sub _TextCil_100_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_100.TextChanged
        TextCil_TextChanged(100)
    End Sub

    Private Sub _TextCil_101_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_101.TextChanged
        TextCil_TextChanged(101)
    End Sub

    Private Sub _TextCil_102_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_102.TextChanged
        TextCil_TextChanged(102)
    End Sub

    Private Sub _TextCil_103_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_103.TextChanged
        TextCil_TextChanged(103)
    End Sub

    Private Sub _TextCil_104_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_104.TextChanged
        TextCil_TextChanged(104)
    End Sub

    Private Sub _TextCil_105_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_105.TextChanged
        TextCil_TextChanged(105)
    End Sub

    Private Sub _TextCil_106_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_106.TextChanged
        TextCil_TextChanged(106)
    End Sub

    Private Sub _TextCil_107_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_107.TextChanged
        TextCil_TextChanged(107)
    End Sub

    Private Sub _TextCil_108_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_108.TextChanged
        TextCil_TextChanged(108)
    End Sub

    Private Sub _TextCil_109_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_109.TextChanged
        TextCil_TextChanged(109)
    End Sub

    Private Sub _TextCil_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_11.TextChanged
        TextCil_TextChanged(11)
    End Sub

    Private Sub _TextCil_110_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_110.TextChanged
        TextCil_TextChanged(110)
    End Sub

    Private Sub _TextCil_111_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_111.TextChanged
        TextCil_TextChanged(111)
    End Sub

    Private Sub _TextCil_112_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_112.TextChanged
        TextCil_TextChanged(112)
    End Sub

    Private Sub _TextCil_113_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_113.TextChanged
        TextCil_TextChanged(113)
    End Sub

    Private Sub _TextCil_114_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_114.TextChanged
        TextCil_TextChanged(114)
    End Sub

    Private Sub _TextCil_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.TextChanged
        TextCil_TextChanged(12)
    End Sub

    Private Sub _TextCil_122_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_122.TextChanged
        TextCil_TextChanged(122)
    End Sub

    Private Sub _TextCil_123_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_123.TextChanged
        TextCil_TextChanged(123)
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

    Private Sub _TextCil_25_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_25.TextChanged
        TextCil_TextChanged(25)
    End Sub

    Private Sub _TextCil_26_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_26.TextChanged
        TextCil_TextChanged(26)
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

    Private Sub _TextCil_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_3.TextChanged
        TextCil_TextChanged(3)
    End Sub

    Private Sub _TextCil_30_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_30.TextChanged
        TextCil_TextChanged(30)
    End Sub

    Private Sub _TextCil_31_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_31.TextChanged
        TextCil_TextChanged(31)
    End Sub

    Private Sub _TextCil_32_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_32.TextChanged
        TextCil_TextChanged(32)
    End Sub

    Private Sub _TextCil_33_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_33.TextChanged
        TextCil_TextChanged(33)
    End Sub

    Private Sub _TextCil_34_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_34.TextChanged
        TextCil_TextChanged(34)
    End Sub

    Private Sub _TextCil_35_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_35.TextChanged
        TextCil_TextChanged(35)
    End Sub

    Private Sub _TextCil_36_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_36.TextChanged
        TextCil_TextChanged(36)
    End Sub

    Private Sub _TextCil_37_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_37.TextChanged
        TextCil_TextChanged(37)
    End Sub

    Private Sub _TextCil_38_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_38.TextChanged
        TextCil_TextChanged(38)
    End Sub

    Private Sub _TextCil_39_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_39.TextChanged
        TextCil_TextChanged(39)
    End Sub

    Private Sub _TextCil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_4.TextChanged
        TextCil_TextChanged(4)
    End Sub

    Private Sub _TextCil_40_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_40.TextChanged
        TextCil_TextChanged(40)
    End Sub
    Private Sub _TextCil_402_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_402.TextChanged
        TextCil_TextChanged(402)
    End Sub

    Private Sub _TextCil_403_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_403.TextChanged
        TextCil_TextChanged(403)
    End Sub

    Private Sub _TextCil_405_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_405.TextChanged
        TextCil_TextChanged(405)
    End Sub

    Private Sub _TextCil_406_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_406.TextChanged
        TextCil_TextChanged(406)
    End Sub

    Private Sub _TextCil_407_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_407.TextChanged
        TextCil_TextChanged(407)
    End Sub

    Private Sub _TextCil_409_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_409.TextChanged
        TextCil_TextChanged(409)
    End Sub

    Private Sub _TextCil_41_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_41.TextChanged
        TextCil_TextChanged(41)
    End Sub

    Private Sub _TextCil_411_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_411.TextChanged
        TextCil_TextChanged(411)
    End Sub

    Private Sub _TextCil_412_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_412.TextChanged
        TextCil_TextChanged(412)
    End Sub

    Private Sub _TextCil_413_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_413.TextChanged
        TextCil_TextChanged(413)
    End Sub

    Private Sub _TextCil_415_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_415.TextChanged
        TextCil_TextChanged(415)
    End Sub

    Private Sub _TextCil_416_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_416.TextChanged
        TextCil_TextChanged(416)
    End Sub

    Private Sub _TextCil_42_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_42.TextChanged
        TextCil_TextChanged(42)
    End Sub

    Private Sub _TextCil_43_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_43.TextChanged
        TextCil_TextChanged(43)
    End Sub

    Private Sub _TextCil_44_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_44.TextChanged
        TextCil_TextChanged(44)
    End Sub

    Private Sub _TextCil_45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_45.TextChanged
        TextCil_TextChanged(45)
    End Sub

    Private Sub _TextCil_46_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_46.TextChanged
        TextCil_TextChanged(46)
    End Sub

    Private Sub _TextCil_47_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_47.TextChanged
        TextCil_TextChanged(47)
    End Sub

    Private Sub _TextCil_48_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_48.TextChanged
        TextCil_TextChanged(48)
    End Sub

    Private Sub _TextCil_49_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_49.TextChanged
        TextCil_TextChanged(49)
    End Sub

    Private Sub _TextCil_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_5.TextChanged
        TextCil_TextChanged(5)
    End Sub

    Private Sub _TextCil_50_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_50.TextChanged
        TextCil_TextChanged(50)
    End Sub

    Private Sub _TextCil_51_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_51.TextChanged
        TextCil_TextChanged(51)
    End Sub

    Private Sub _TextCil_52_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_52.TextChanged
        TextCil_TextChanged(52)
    End Sub

    Private Sub _TextCil_53_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_53.TextChanged
        TextCil_TextChanged(53)
    End Sub

    Private Sub _TextCil_54_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_54.TextChanged
        TextCil_TextChanged(54)
    End Sub

    Private Sub _TextCil_55_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_55.TextChanged
        TextCil_TextChanged(55)
    End Sub

    Private Sub _TextCil_56_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_56.TextChanged
        TextCil_TextChanged(56)
    End Sub

    Private Sub _TextCil_57_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_57.TextChanged
        TextCil_TextChanged(57)
    End Sub

    Private Sub _TextCil_58_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_58.TextChanged
        TextCil_TextChanged(58)
    End Sub

    Private Sub _TextCil_59_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_59.TextChanged
        TextCil_TextChanged(59)
    End Sub

    Private Sub _TextCil_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_6.TextChanged
        TextCil_TextChanged(6)
    End Sub

    Private Sub _TextCil_60_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_60.TextChanged
        TextCil_TextChanged(60)
    End Sub

    Private Sub _TextCil_61_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_61.TextChanged
        TextCil_TextChanged(61)
    End Sub

    Private Sub _TextCil_62_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_62.TextChanged
        TextCil_TextChanged(62)
    End Sub

    Private Sub _TextCil_63_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_63.TextChanged
        TextCil_TextChanged(63)
    End Sub

    Private Sub _TextCil_64_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_64.TextChanged
        TextCil_TextChanged(64)
    End Sub

    Private Sub _TextCil_65_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_65.TextChanged
        TextCil_TextChanged(65)
    End Sub

    Private Sub _TextCil_66_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_66.TextChanged
        TextCil_TextChanged(66)
    End Sub

    Private Sub _TextCil_67_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_67.TextChanged
        TextCil_TextChanged(67)
    End Sub

    Private Sub _TextCil_68_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_68.TextChanged
        TextCil_TextChanged(68)
    End Sub

    Private Sub _TextCil_69_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_69.TextChanged
        TextCil_TextChanged(69)
    End Sub

    Private Sub _TextCil_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_7.TextChanged
        TextCil_TextChanged(7)
    End Sub

    Private Sub _TextCil_70_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_70.TextChanged
        TextCil_TextChanged(70)
    End Sub

    Private Sub _TextCil_71_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_71.TextChanged
        TextCil_TextChanged(71)
    End Sub

    Private Sub _TextCil_72_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_72.TextChanged
        TextCil_TextChanged(72)
    End Sub

    Private Sub _TextCil_73_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_73.TextChanged
        TextCil_TextChanged(73)
    End Sub

    Private Sub _TextCil_74_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_74.TextChanged
        TextCil_TextChanged(74)
    End Sub

    Private Sub _TextCil_75_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_75.TextChanged
        TextCil_TextChanged(75)
    End Sub

    Private Sub _TextCil_76_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_76.TextChanged
        TextCil_TextChanged(76)
    End Sub

    Private Sub _TextCil_77_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_77.TextChanged
        TextCil_TextChanged(77)
    End Sub

    Private Sub _TextCil_78_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_78.TextChanged
        TextCil_TextChanged(78)
    End Sub

    Private Sub _TextCil_79_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_79.TextChanged
        TextCil_TextChanged(79)
    End Sub

    Private Sub _TextCil_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_8.TextChanged
        TextCil_TextChanged(8)
    End Sub

    Private Sub _TextCil_80_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_80.TextChanged
        TextCil_TextChanged(80)
    End Sub
    Private Sub _TextCil_82_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_82.TextChanged
        TextCil_TextChanged(82)
    End Sub

    Private Sub _TextCil_83_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_83.TextChanged
        TextCil_TextChanged(83)
    End Sub

    Private Sub _TextCil_84_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_84.TextChanged
        TextCil_TextChanged(84)
    End Sub
    Private Sub _TextCil_86_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_86.TextChanged
        TextCil_TextChanged(86)
    End Sub

    Private Sub _TextCil_87_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_87.TextChanged
        TextCil_TextChanged(87)
    End Sub

    Private Sub _TextCil_88_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_88.TextChanged
        TextCil_TextChanged(88)
    End Sub
    Private Sub _TextCil_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.TextChanged
        TextCil_TextChanged(9)
    End Sub

    Private Sub _TextCil_90_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_90.TextChanged
        TextCil_TextChanged(90)
    End Sub

    Private Sub _TextCil_91_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_91.TextChanged
        TextCil_TextChanged(91)
    End Sub

    Private Sub _TextCil_92_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_92.TextChanged
        TextCil_TextChanged(92)
    End Sub

    Private Sub _TextCil_93_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_93.TextChanged
        TextCil_TextChanged(93)
    End Sub

    Private Sub _TextCil_94_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_94.TextChanged
        TextCil_TextChanged(94)
    End Sub

    Private Sub _TextCil_95_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_95.TextChanged
        TextCil_TextChanged(95)
    End Sub

    Private Sub _TextCil_96_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_96.TextChanged
        TextCil_TextChanged(96)
    End Sub

    Private Sub _TextCil_97_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_97.TextChanged
        TextCil_TextChanged(97)
    End Sub

    Private Sub _TextCil_98_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_98.TextChanged
        TextCil_TextChanged(98)
    End Sub

    Private Sub _TextCil_99_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_99.TextChanged
        TextCil_TextChanged(99)
    End Sub
    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    Private Sub _TextCil_10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.Leave
        TextCil_Leave(10)
    End Sub

    Private Sub _TextCil_100_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_100.Leave
        TextCil_Leave(100)
    End Sub

    Private Sub _TextCil_101_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_101.Leave
        TextCil_Leave(101)
    End Sub

    Private Sub _TextCil_102_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_102.Leave
        TextCil_Leave(102)
    End Sub

    Private Sub _TextCil_103_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_103.Leave
        TextCil_Leave(103)
    End Sub

    Private Sub _TextCil_104_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_104.Leave
        TextCil_Leave(104)
    End Sub

    Private Sub _TextCil_105_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_105.Leave
        TextCil_Leave(105)
    End Sub

    Private Sub _TextCil_106_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_106.Leave
        TextCil_Leave(106)
    End Sub

    Private Sub _TextCil_107_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_107.Leave
        TextCil_Leave(107)
    End Sub

    Private Sub _TextCil_108_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_108.Leave
        TextCil_Leave(108)
    End Sub

    Private Sub _TextCil_109_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_109.Leave
        TextCil_Leave(109)
    End Sub

    Private Sub _TextCil_11_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_11.Leave
        TextCil_Leave(11)
    End Sub

    Private Sub _TextCil_110_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_110.Leave
        TextCil_Leave(110)
    End Sub

    Private Sub _TextCil_111_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_111.Leave
        TextCil_Leave(111)
    End Sub

    Private Sub _TextCil_112_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_112.Leave
        TextCil_Leave(112)
    End Sub

    Private Sub _TextCil_113_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_113.Leave
        TextCil_Leave(113)
    End Sub

    Private Sub _TextCil_114_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_114.Leave
        TextCil_Leave(114)
    End Sub

    Private Sub _TextCil_12_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.Leave
        TextCil_Leave(12)
    End Sub

    Private Sub _TextCil_122_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_122.Leave
        TextCil_Leave(122)
    End Sub

    Private Sub _TextCil_123_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_123.Leave
        TextCil_Leave(123)
    End Sub

    Private Sub _TextCil_13_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_13.Leave
        TextCil_Leave(13)
    End Sub

    Private Sub _TextCil_14_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.Leave
        TextCil_Leave(14)
    End Sub

    Private Sub _TextCil_15_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_15.Leave
        TextCil_Leave(15)
    End Sub
    Private Sub _TextCil_16_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_16.Leave
        TextCil_Leave(16)
    End Sub

    Private Sub _TextCil_17_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_17.Leave
        TextCil_Leave(17)
    End Sub

    Private Sub _TextCil_18_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_18.Leave
        TextCil_Leave(18)
    End Sub
    Private Sub _TextCil_19_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_19.Leave
        TextCil_Leave(19)
    End Sub

    Private Sub _TextCil_2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_2.Leave
        TextCil_Leave(2)
    End Sub

    Private Sub _TextCil_20_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_20.Leave
        TextCil_Leave(20)
    End Sub
    Private Sub _TextCil_21_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_21.Leave
        TextCil_Leave(21)
    End Sub

    Private Sub _TextCil_22_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_22.Leave
        TextCil_Leave(22)
    End Sub
    Private Sub _TextCil_23_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_23.Leave
        TextCil_Leave(23)
    End Sub

    Private Sub _TextCil_24_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_24.Leave
        TextCil_Leave(24)
    End Sub

    Private Sub _TextCil_25_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_25.Leave
        TextCil_Leave(25)
    End Sub

    Private Sub _TextCil_26_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_26.Leave
        TextCil_Leave(26)
    End Sub

    Private Sub _TextCil_27_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_27.Leave
        TextCil_Leave(27)
    End Sub

    Private Sub _TextCil_28_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_28.Leave
        TextCil_Leave(28)
    End Sub

    Private Sub _TextCil_29_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_29.Leave
        TextCil_Leave(29)
    End Sub

    Private Sub _TextCil_3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_3.Leave
        TextCil_Leave(3)
    End Sub

    Private Sub _TextCil_30_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_30.Leave
        TextCil_Leave(30)
    End Sub

    Private Sub _TextCil_31_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_31.Leave
        TextCil_Leave(31)
    End Sub

    Private Sub _TextCil_32_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_32.Leave
        TextCil_Leave(32)
    End Sub

    Private Sub _TextCil_33_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_33.Leave
        TextCil_Leave(33)
    End Sub

    Private Sub _TextCil_34_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_34.Leave
        TextCil_Leave(34)
    End Sub

    Private Sub _TextCil_35_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_35.Leave
        TextCil_Leave(35)
    End Sub

    Private Sub _TextCil_36_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_36.Leave
        TextCil_Leave(36)
    End Sub

    Private Sub _TextCil_37_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_37.Leave
        TextCil_Leave(37)
    End Sub

    Private Sub _TextCil_38_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_38.Leave
        TextCil_Leave(38)
    End Sub

    Private Sub _TextCil_39_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_39.Leave
        TextCil_Leave(39)
    End Sub

    Private Sub _TextCil_4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_4.Leave
        TextCil_Leave(4)
    End Sub

    Private Sub _TextCil_40_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_40.Leave
        TextCil_Leave(40)
    End Sub
    Private Sub _TextCil_402_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_402.Leave
        TextCil_Leave(402)
    End Sub

    Private Sub _TextCil_403_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_403.Leave
        TextCil_Leave(403)
    End Sub

    Private Sub _TextCil_405_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_405.Leave
        TextCil_Leave(405)
    End Sub

    Private Sub _TextCil_406_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_406.Leave
        TextCil_Leave(406)
    End Sub

    Private Sub _TextCil_407_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_407.Leave
        TextCil_Leave(407)
    End Sub

    Private Sub _TextCil_409_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_409.Leave
        TextCil_Leave(409)
    End Sub

    Private Sub _TextCil_41_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_41.Leave
        TextCil_Leave(41)
    End Sub

    Private Sub _TextCil_411_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_411.Leave
        TextCil_Leave(411)
    End Sub

    Private Sub _TextCil_412_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_412.Leave
        TextCil_Leave(412)
    End Sub

    Private Sub _TextCil_413_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_413.Leave
        TextCil_Leave(413)
    End Sub

    Private Sub _TextCil_415_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_415.Leave
        TextCil_Leave(415)
    End Sub

    Private Sub _TextCil_416_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_416.Leave
        TextCil_Leave(416)
    End Sub

    Private Sub _TextCil_42_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_42.Leave
        TextCil_Leave(42)
    End Sub

    Private Sub _TextCil_43_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_43.Leave
        TextCil_Leave(43)
    End Sub

    Private Sub _TextCil_44_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_44.Leave
        TextCil_Leave(44)
    End Sub

    Private Sub _TextCil_45_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_45.Leave
        TextCil_Leave(45)
    End Sub

    Private Sub _TextCil_46_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_46.Leave
        TextCil_Leave(46)
    End Sub

    Private Sub _TextCil_47_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_47.Leave
        TextCil_Leave(47)
    End Sub

    Private Sub _TextCil_48_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_48.Leave
        TextCil_Leave(48)
    End Sub

    Private Sub _TextCil_49_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_49.Leave
        TextCil_Leave(49)
    End Sub

    Private Sub _TextCil_5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_5.Leave
        TextCil_Leave(5)
    End Sub

    Private Sub _TextCil_50_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_50.Leave
        TextCil_Leave(50)
    End Sub

    Private Sub _TextCil_51_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_51.Leave
        TextCil_Leave(51)
    End Sub

    Private Sub _TextCil_52_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_52.Leave
        TextCil_Leave(52)
    End Sub

    Private Sub _TextCil_53_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_53.Leave
        TextCil_Leave(53)
    End Sub

    Private Sub _TextCil_54_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_54.Leave
        TextCil_Leave(54)
    End Sub

    Private Sub _TextCil_55_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_55.Leave
        TextCil_Leave(55)
    End Sub

    Private Sub _TextCil_56_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_56.Leave
        TextCil_Leave(56)
    End Sub

    Private Sub _TextCil_57_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_57.Leave
        TextCil_Leave(57)
    End Sub

    Private Sub _TextCil_58_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_58.Leave
        TextCil_Leave(58)
    End Sub

    Private Sub _TextCil_59_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_59.Leave
        TextCil_Leave(59)
    End Sub

    Private Sub _TextCil_6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_6.Leave
        TextCil_Leave(6)
    End Sub

    Private Sub _TextCil_60_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_60.Leave
        TextCil_Leave(60)
    End Sub

    Private Sub _TextCil_61_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_61.Leave
        TextCil_Leave(61)
    End Sub

    Private Sub _TextCil_62_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_62.Leave
        TextCil_Leave(62)
    End Sub

    Private Sub _TextCil_63_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_63.Leave
        TextCil_Leave(63)
    End Sub

    Private Sub _TextCil_64_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_64.Leave
        TextCil_Leave(64)
    End Sub

    Private Sub _TextCil_65_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_65.Leave
        TextCil_Leave(65)
    End Sub

    Private Sub _TextCil_66_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_66.Leave
        TextCil_Leave(66)
    End Sub

    Private Sub _TextCil_67_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_67.Leave
        TextCil_Leave(67)
    End Sub

    Private Sub _TextCil_68_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_68.Leave
        TextCil_Leave(68)
    End Sub

    Private Sub _TextCil_69_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_69.Leave
        TextCil_Leave(69)
    End Sub

    Private Sub _TextCil_7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_7.Leave
        TextCil_Leave(7)
    End Sub

    Private Sub _TextCil_70_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_70.Leave
        TextCil_Leave(70)
    End Sub

    Private Sub _TextCil_71_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_71.Leave
        TextCil_Leave(71)
    End Sub

    Private Sub _TextCil_72_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_72.Leave
        TextCil_Leave(72)
    End Sub

    Private Sub _TextCil_73_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_73.Leave
        TextCil_Leave(73)
    End Sub

    Private Sub _TextCil_74_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_74.Leave
        TextCil_Leave(74)
    End Sub

    Private Sub _TextCil_75_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_75.Leave
        TextCil_Leave(75)
    End Sub

    Private Sub _TextCil_76_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_76.Leave
        TextCil_Leave(76)
    End Sub

    Private Sub _TextCil_77_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_77.Leave
        TextCil_Leave(77)
    End Sub

    Private Sub _TextCil_78_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_78.Leave
        TextCil_Leave(78)
    End Sub

    Private Sub _TextCil_79_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_79.Leave
        TextCil_Leave(79)
    End Sub

    Private Sub _TextCil_8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_8.Leave
        TextCil_Leave(8)
    End Sub

    Private Sub _TextCil_80_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_80.Leave
        TextCil_Leave(80)
    End Sub
    Private Sub _TextCil_82_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_82.Leave
        TextCil_Leave(82)
    End Sub

    Private Sub _TextCil_83_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_83.Leave
        TextCil_Leave(83)
    End Sub

    Private Sub _TextCil_84_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_84.Leave
        TextCil_Leave(84)
    End Sub
    Private Sub _TextCil_86_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_86.Leave
        TextCil_Leave(86)
    End Sub

    Private Sub _TextCil_87_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_87.Leave
        TextCil_Leave(87)
    End Sub

    Private Sub _TextCil_88_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_88.Leave
        TextCil_Leave(88)
    End Sub
    Private Sub _TextCil_9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.Leave
        TextCil_Leave(9)
    End Sub

    Private Sub _TextCil_90_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_90.Leave
        TextCil_Leave(90)
    End Sub

    Private Sub _TextCil_91_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_91.Leave
        TextCil_Leave(91)
    End Sub

    Private Sub _TextCil_92_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_92.Leave
        TextCil_Leave(92)
    End Sub

    Private Sub _TextCil_93_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_93.Leave
        TextCil_Leave(93)
    End Sub

    Private Sub _TextCil_94_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_94.Leave
        TextCil_Leave(94)
    End Sub

    Private Sub _TextCil_95_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_95.Leave
        TextCil_Leave(95)
    End Sub

    Private Sub _TextCil_96_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_96.Leave
        TextCil_Leave(96)
    End Sub

    Private Sub _TextCil_97_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_97.Leave
        TextCil_Leave(97)
    End Sub

    Private Sub _TextCil_98_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_98.Leave
        TextCil_Leave(98)
    End Sub

    Private Sub _TextCil_99_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_99.Leave
        TextCil_Leave(99)
    End Sub

    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(0)
    End Sub

    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(1)
    End Sub

    Private Sub _cmbCil_10_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_10.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(10)
    End Sub

    Private Sub _cmbCil_101_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_101.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(101)
    End Sub

    Private Sub _cmbCil_11_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_11.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(11)
    End Sub

    Private Sub _cmbCil_12_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_12.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(12)
    End Sub

    Private Sub _cmbCil_121_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_121.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(121)
    End Sub

    Private Sub _cmbCil_13_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_13.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(13)
    End Sub

    Private Sub _cmbCil_14_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_14.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(14)
    End Sub

    Private Sub _cmbCil_15_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_15.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(15)
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
    Private Sub _cmbCil_403_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_403.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(403)
    End Sub

    Private Sub _cmbCil_5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_5.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(5)
    End Sub

    Private Sub _cmbCil_51_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_51.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(51)
    End Sub

    Private Sub _cmbCil_6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_6.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(6)
    End Sub

    Private Sub _cmbCil_7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_7.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(7)
    End Sub

    Private Sub _cmbCil_8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_8.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(8)
    End Sub

    Private Sub _cmbCil_81_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_81.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(81)
    End Sub

    Private Sub _cmbCil_9_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_9.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(9)
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub _cmbCil_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.TextChanged
        cmbCil_TextChanged(0)
    End Sub

    Private Sub _cmbCil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.TextChanged
        cmbCil_TextChanged(1)
    End Sub

    Private Sub _cmbCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_10.TextChanged
        cmbCil_TextChanged(10)
    End Sub

    Private Sub _cmbCil_101_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_101.TextChanged
        cmbCil_TextChanged(101)
    End Sub

    Private Sub _cmbCil_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_11.TextChanged
        cmbCil_TextChanged(11)
    End Sub

    Private Sub _cmbCil_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_12.TextChanged
        cmbCil_TextChanged(12)
    End Sub

    Private Sub _cmbCil_121_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_121.TextChanged
        cmbCil_TextChanged(121)
    End Sub

    Private Sub _cmbCil_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_13.TextChanged
        cmbCil_TextChanged(13)
    End Sub

    Private Sub _cmbCil_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_14.TextChanged
        cmbCil_TextChanged(14)
    End Sub

    Private Sub _cmbCil_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_15.TextChanged
        cmbCil_TextChanged(15)
    End Sub

    Private Sub _cmbCil_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_2.TextChanged
        cmbCil_TextChanged(2)
    End Sub

    Private Sub _cmbCil_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_3.TextChanged
        cmbCil_TextChanged(3)
    End Sub

    Private Sub _cmbCil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_4.TextChanged
        cmbCil_TextChanged(4)
    End Sub
    Private Sub _cmbCil_403_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_403.TextChanged
        cmbCil_TextChanged(403)
    End Sub

    Private Sub _cmbCil_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_5.TextChanged
        cmbCil_TextChanged(5)
    End Sub

    Private Sub _cmbCil_51_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_51.TextChanged
        cmbCil_TextChanged(51)
    End Sub

    Private Sub _cmbCil_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_6.TextChanged
        cmbCil_TextChanged(6)
    End Sub

    Private Sub _cmbCil_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_7.TextChanged
        cmbCil_TextChanged(7)
    End Sub

    Private Sub _cmbCil_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_8.TextChanged
        cmbCil_TextChanged(8)
    End Sub

    Private Sub _cmbCil_81_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_81.TextChanged
        cmbCil_TextChanged(81)
    End Sub

    Private Sub _cmbCil_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_9.TextChanged
        cmbCil_TextChanged(9)
    End Sub

    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        cmdCil_Click(0)
    End Sub

    Private Sub _cmdCil_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        cmdCil_Click(1)
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

    Private Sub _cmdCil_151_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_151.Click
        cmdCil_Click(151)
    End Sub

    Private Sub _cmdCil_16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_16.Click
        cmdCil_Click(16)
    End Sub

    Private Sub _cmdCil_181_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_181.Click
        cmdCil_Click(181)
    End Sub

    Private Sub _cmdCil_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_2.Click
        cmdCil_Click(2)
    End Sub

    Private Sub _cmdCil_201_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_201.Click
        cmdCil_Click(201)
    End Sub

    Private Sub _cmdCil_221_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_221.Click
        cmdCil_Click(221)
    End Sub

    Private Sub _cmdCil_24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_24.Click
        cmdCil_Click(24)
    End Sub

    Private Sub _cmdCil_25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_25.Click
        cmdCil_Click(25)
    End Sub

    Private Sub _cmdCil_26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_26.Click
        cmdCil_Click(26)
    End Sub

    Private Sub _cmdCil_27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_27.Click
        cmdCil_Click(27)
    End Sub

    Private Sub _cmdCil_29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_29.Click
        cmdCil_Click(29)
    End Sub
    Private Sub _cmdCil_30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_30.Click
        cmdCil_Click(30)
    End Sub

    Private Sub _cmdCil_31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_31.Click
        cmdCil_Click(31)
    End Sub

    Private Sub _cmdCil_32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_32.Click
        cmdCil_Click(32)
    End Sub

    Private Sub _cmdCil_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_4.Click
        cmdCil_Click(4)
    End Sub

    Private Sub _cmdCil_401_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_401.Click
        cmdCil_Click(401)
    End Sub

    Private Sub _cmdCil_402_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_402.Click
        cmdCil_Click(402)
    End Sub

    Private Sub _cmdCil_406_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_406.Click
        cmdCil_Click(406)
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
    Private Sub _cmdCil_9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_9.Click
        cmdCil_Click(9)
    End Sub
    Private Sub _optColl_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optColl_0.CheckedChanged
        optColl_CheckedChanged(0, _optColl_0.Checked)
    End Sub
    Private Sub _optColl_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optColl_1.CheckedChanged
        optColl_CheckedChanged(1, _optColl_1.Checked)
    End Sub
    Private Sub TabStrip1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabStrip1.Click
        Dim t, i As Short
        If Involucr(kLato, jInvolucr).IndObject = 0 Then Exit Sub
        t = TabStrip1.SelectedIndex
        For i = 0 To 4
            If Not actFrames(i) Is Nothing Then actFrames(i).Visible = i = t
        Next
        Check1_CheckStateChanged(4)
        Saltacombo = True
        With CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
            If t = 3 Then
                _frmCollars_0.Visible = .BiFlangiata And Not .BullDistinti
                _frmCollars_1.Visible = False ' .BiFlangiata
            End If
            _cmbCil_51.Text = Trim(.FlChanNome)
            _cmbCil_81.Text = Trim(.FlShelNome)
            _cmbCil_101.Text = Trim(.SlChanNome)
            _cmbCil_121.Text = Trim(.SlShelNome)
        End With
        Saltacombo = False
    End Sub
    Private Sub TabStrip2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabStrip2.Click
        Dim i As Short
        PiastraAB = TabStrip2.SelectedIndex + 1
        If PiastraAB = 1 Then _Frames_5.Text = "Dati di progetto piastra di testa" Else _Frames_5.Text = "Dati di progetto piastra di coda"
        For i = 1 To 2
            Framesf(i).Visible = i = PiastraAB
            If Framesf(i).Visible Then Framesf(i).BringToFront()
        Next
        i = Involucr(kLato, jInvolucr).IndObject
        If i = 0 Then Exit Sub
        With CType(objMemb(i), wn_PT)
            .SetPiastra(PiastraAB)
            AggTab()
            AggTesti() 'qui
            If TipoPiastra = 2 Then
                If PiastraAB = 2 Then
                    If .Piastra.Rear = 2 Then 'flottante
                        _LabelCil_86.Visible = True 'differing speciale
                        _cmbCil_7.Visible = True
                        'AggCombo6
                    Else
                        If CType(.Piastra, wn_FTC).Differing = 2 Then
                            _LabelCil_86.Visible = False 'differing normale
                            _cmbCil_7.Visible = False
                        Else
                            _LabelCil_86.Visible = True 'differing speciale
                            _cmbCil_7.Visible = True
                            'AggCombo6
                        End If
                    End If
                End If
            End If
        End With
        RiempiCollegFl()
        AggCheck()
    End Sub
    Private Sub frmPT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Attivata()
    End Sub
    Private Sub chkAgganciato1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato1.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Agganciato = chkAgganciato1.Checked
    End Sub
    Private Sub chkAgganciato2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato2.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(3 - 1)).Agganciato = chkAgganciato2.Checked
    End Sub
    Private Sub frmPT_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim i As Short
        LabIBWmm.Text = UnitLength.Substring(1, 2)
        For i = 10 To 91
            Select Case i
                Case 26, 27, 29, 30, 52, 91 : lblUni(i).Text = UnitPress 'pressione
                Case 31 : lblUni(i).Text = UnitTemp 'temperatura
                Case 10, 28, 24, 25 : lblUni(i).Text = UnitLength
            End Select
        Next
        AggiornaLabels(Me, 150)
    End Sub
    Private ReadOnly Property cmbMatFl(ByVal i) As ComboBox
        Get
            Select Case i
                Case 151 : Return cmbMatFlLT
                Case 181 : Return cmbMatFlLM
                Case 201 : Return cmbMatSlLT
                Case 221 : Return cmbMatSlLM
                Case Else
                    Stop
            End Select
        End Get
    End Property
    Private Sub cmbMat2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat2.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat2, Involucr(kLato, jInvolucr).indice(2), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat2.SelectedIndex = nuovoSelect
        chkAgganciato2.Checked = Matdim(Involucr(kLato, jInvolucr).indice(2)).Agganciato
    End Sub
    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Involucr(kLato, jInvolucr).indice(0), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
        chkAgganciato1.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub
    Private Sub cmbMatBoltLT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMatBoltLT.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatBoltLT, Involucr(kLato, jInvolucr).indice(1), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatBoltLT.SelectedIndex = nuovoSelect
        Me.chkAggancBoltLT.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub
    Private Sub cmbMatSlLT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatSlLT.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatSlLT, Involucr(kLato, jInvolucr).indice(5), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatSlLT.SelectedIndex = nuovoSelect
    End Sub
    Private Sub cmbMatFlLT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatFlLT.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatFlLT, Involucr(kLato, jInvolucr).indice(5), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatFlLT.SelectedIndex = nuovoSelect
    End Sub
    Private Sub cmbMatFlLM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatFlLM.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatFlLM, Involucr(kLato, jInvolucr).indice(4), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatFlLM.SelectedIndex = nuovoSelect
    End Sub
    Private Sub cmbMatSlLM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatSlLM.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatSlLM, Involucr(kLato, jInvolucr).indice(4), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatSlLM.SelectedIndex = nuovoSelect
    End Sub
    Private Sub cmbMatBoltLM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatBoltLM.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatBoltLM, Involucr(kLato, jInvolucr).indice(6), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatBoltLM.SelectedIndex = nuovoSelect
        Me.chkAggancBoltLM.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub
    Private Sub cmbMatShell_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatShell.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMatShell, Involucr(kLato, jInvolucr).indice(3), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMatShell.SelectedIndex = nuovoSelect
    End Sub
    Private Sub chkAggancBoltLT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAggancBoltLT.CheckedChanged
        Try
            Matdim(Involucr(kLato, jInvolucr).indice(1)).Agganciato = chkAggancBoltLT.Checked
        Catch
        End Try
    End Sub
    Private Sub chkAggancBoltLM_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAggancBoltLM.CheckedChanged
        Try
            Matdim(Involucr(kLato, jInvolucr).indice(6)).Agganciato = chkAggancBoltLM.Checked
        Catch
        End Try
    End Sub
End Class