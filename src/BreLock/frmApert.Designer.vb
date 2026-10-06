<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmApert
#Region "Codice generato da Progettazione Windows Form "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
		InitializeComponent()
        HelpProvider1.SetHelpNavigator(TabStrip1, HelpNavigator.Topic)
        HelpProvider1.SetShowHelp(TabStrip1, True)
        Inizializza()
        Inizializzando = False
        Inizializza1()
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
	Public WithEvents rtLogo As System.Windows.Forms.RichTextBox
	Public WithEvents Labelcom1 As System.Windows.Forms.Label
	Public WithEvents Commento As System.Windows.Forms.GroupBox
	Public WithEvents cmbStampa As System.Windows.Forms.ComboBox
	Public WithEvents _optDiff_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optDiff_0 As System.Windows.Forms.RadioButton
	Public WithEvents framDiff As System.Windows.Forms.GroupBox
	Public WithEvents _optTipo_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optTipo_1 As System.Windows.Forms.RadioButton
	Public WithEvents framTipo As System.Windows.Forms.GroupBox
	Public WithEvents _txtDes_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtDes_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtDes_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtDes_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtDes_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtDes_4 As System.Windows.Forms.TextBox
	Public WithEvents _lblMis_78 As System.Windows.Forms.Label
	Public WithEvents _Label_92 As System.Windows.Forms.Label
	Public WithEvents _lblMis_0 As System.Windows.Forms.Label
	Public WithEvents _Label_0 As System.Windows.Forms.Label
	Public WithEvents _lblMis_1 As System.Windows.Forms.Label
	Public WithEvents _Label_1 As System.Windows.Forms.Label
	Public WithEvents _Label_2 As System.Windows.Forms.Label
	Public WithEvents _lblMis_3 As System.Windows.Forms.Label
	Public WithEvents _Label_3 As System.Windows.Forms.Label
	Public WithEvents _lblMis_2 As System.Windows.Forms.Label
	Public WithEvents _Label_4 As System.Windows.Forms.Label
	Public WithEvents _lblMis_4 As System.Windows.Forms.Label
	Public WithEvents framPDiffHT As System.Windows.Forms.GroupBox
	Public WithEvents _txtMat_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtMat_7 As System.Windows.Forms.TextBox
	Public WithEvents cmbMat As System.Windows.Forms.ComboBox
	Public WithEvents cmdLibMat As System.Windows.Forms.Button
	Public WithEvents _txtMat_8 As System.Windows.Forms.TextBox
	Public WithEvents cmdRic As System.Windows.Forms.Button
    Public WithEvents _lblMat_3 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_3 As System.Windows.Forms.Label
    Public WithEvents _lblMat_2 As System.Windows.Forms.Label
    Public WithEvents _lblMat_1 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_1 As System.Windows.Forms.Label
    Public WithEvents _lblMat_0 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_0 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_2 As System.Windows.Forms.Label
    Public WithEvents _lblMat_4 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_4 As System.Windows.Forms.Label
    Public WithEvents _lblMat_5 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_5 As System.Windows.Forms.Label
    Public WithEvents _lblMat_6 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_6 As System.Windows.Forms.Label
    Public WithEvents _lblMat_7 As System.Windows.Forms.Label
    Public WithEvents _lblMisMat_7 As System.Windows.Forms.Label
    Public WithEvents _Label_8 As System.Windows.Forms.Label
    Public WithEvents framMat As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _pctFrames_0 As System.Windows.Forms.Panel
    Public WithEvents _cmdCalc_1 As System.Windows.Forms.Button
    Public WithEvents _txtShell_15 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_14 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_13 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_12 As System.Windows.Forms.TextBox
    Public WithEvents _Label_24 As System.Windows.Forms.Label
    Public WithEvents _lblMis_16 As System.Windows.Forms.Label
    Public WithEvents _Label_23 As System.Windows.Forms.Label
    Public WithEvents _lblMis_15 As System.Windows.Forms.Label
    Public WithEvents _Label_22 As System.Windows.Forms.Label
    Public WithEvents _lblMis_14 As System.Windows.Forms.Label
    Public WithEvents _Label_21 As System.Windows.Forms.Label
    Public WithEvents _lblMis_13 As System.Windows.Forms.Label
    Public WithEvents framHead As System.Windows.Forms.GroupBox
    Public WithEvents _cmdGuarn1_0 As System.Windows.Forms.Button
    Public WithEvents _txtShell_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_2 As System.Windows.Forms.TextBox
    Public WithEvents _Label_18 As System.Windows.Forms.Label
    Public WithEvents _lblMis_10 As System.Windows.Forms.Label
    Public WithEvents _Label_17 As System.Windows.Forms.Label
    Public WithEvents _lblMis_9 As System.Windows.Forms.Label
    Public WithEvents _Label_16 As System.Windows.Forms.Label
    Public WithEvents _lblMis_8 As System.Windows.Forms.Label
    Public WithEvents _Label_15 As System.Windows.Forms.Label
    Public WithEvents _Label_14 As System.Windows.Forms.Label
    Public WithEvents _lblMis_7 As System.Windows.Forms.Label
    Public WithEvents _Label_13 As System.Windows.Forms.Label
    Public WithEvents _lblMis_6 As System.Windows.Forms.Label
    Public WithEvents _Label_11 As System.Windows.Forms.Label
    Public WithEvents _Label_9 As System.Windows.Forms.Label
    Public WithEvents _lblMis_5 As System.Windows.Forms.Label
    Public WithEvents framGsk1 As System.Windows.Forms.GroupBox
    Public WithEvents _txtShell_11 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtShell_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblMis_12 As System.Windows.Forms.Label
    Public WithEvents _Label_20 As System.Windows.Forms.Label
    Public WithEvents _lblMis_11 As System.Windows.Forms.Label
    Public WithEvents _Label_19 As System.Windows.Forms.Label
    Public WithEvents _lblMis_103 As System.Windows.Forms.Label
    Public WithEvents _Label_12 As System.Windows.Forms.Label
    Public WithEvents _lblMis_102 As System.Windows.Forms.Label
    Public WithEvents _Label_10 As System.Windows.Forms.Label
    Public WithEvents framShell As System.Windows.Forms.GroupBox
    Public WithEvents _pctFrames_1 As System.Windows.Forms.Panel
    Public WithEvents _cmdCalc_3 As System.Windows.Forms.Button
    Public WithEvents _optPlastic_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optPlastic_0 As System.Windows.Forms.RadioButton
    Public WithEvents _txtViti_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_4 As System.Windows.Forms.TextBox
    Public WithEvents _lblMis_31 As System.Windows.Forms.Label
    Public WithEvents _Label_40 As System.Windows.Forms.Label
    Public WithEvents _lblMis_30 As System.Windows.Forms.Label
    Public WithEvents _Label_39 As System.Windows.Forms.Label
    Public WithEvents _lblMis_29 As System.Windows.Forms.Label
    Public WithEvents _Label_38 As System.Windows.Forms.Label
    Public WithEvents _lblMis_26 As System.Windows.Forms.Label
    Public WithEvents _Label_37 As System.Windows.Forms.Label
    Public WithEvents framCarichi As System.Windows.Forms.GroupBox
    Public WithEvents _txtViti_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_10 As System.Windows.Forms.TextBox
    Public WithEvents _cmdtir_0 As System.Windows.Forms.Button
    Public WithEvents _txtViti_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtViti_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label_131 As System.Windows.Forms.Label
    Public WithEvents _lblMis_110 As System.Windows.Forms.Label
    Public WithEvents _Label_126 As System.Windows.Forms.Label
    Public WithEvents _lblMis_105 As System.Windows.Forms.Label
    Public WithEvents _Label_125 As System.Windows.Forms.Label
    Public WithEvents _lblMis_25 As System.Windows.Forms.Label
    Public WithEvents _lblMis_28 As System.Windows.Forms.Label
    Public WithEvents _Label_36 As System.Windows.Forms.Label
    Public WithEvents _lblMis_27 As System.Windows.Forms.Label
    Public WithEvents _Label_35 As System.Windows.Forms.Label
    Public WithEvents _Label_34 As System.Windows.Forms.Label
    Public WithEvents _Label_33 As System.Windows.Forms.Label
    Public WithEvents framViti As System.Windows.Forms.GroupBox
    Public WithEvents _pctFrames_3 As System.Windows.Forms.Panel
    Public WithEvents _txtchan_11 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblMis_65 As System.Windows.Forms.Label
    Public WithEvents _Label_77 As System.Windows.Forms.Label
    Public WithEvents _lblMis_64 As System.Windows.Forms.Label
    Public WithEvents _Label_76 As System.Windows.Forms.Label
    Public WithEvents _lblMis_63 As System.Windows.Forms.Label
    Public WithEvents _Label_75 As System.Windows.Forms.Label
    Public WithEvents _lblMis_62 As System.Windows.Forms.Label
    Public WithEvents _Label_74 As System.Windows.Forms.Label
    Public WithEvents framChan As System.Windows.Forms.GroupBox
    Public WithEvents _txtchan_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtchan_9 As System.Windows.Forms.TextBox
    Public WithEvents _cmdGuarn1_1 As System.Windows.Forms.Button
    Public WithEvents _lblMis_61 As System.Windows.Forms.Label
    Public WithEvents _Label_73 As System.Windows.Forms.Label
    Public WithEvents _Label_72 As System.Windows.Forms.Label
    Public WithEvents _lblMis_60 As System.Windows.Forms.Label
    Public WithEvents _Label_71 As System.Windows.Forms.Label
    Public WithEvents _lblMis_59 As System.Windows.Forms.Label
    Public WithEvents _Label_70 As System.Windows.Forms.Label
    Public WithEvents _Label_69 As System.Windows.Forms.Label
    Public WithEvents _lblMis_58 As System.Windows.Forms.Label
    Public WithEvents _Label_68 As System.Windows.Forms.Label
    Public WithEvents _lblMis_57 As System.Windows.Forms.Label
    Public WithEvents _Label_67 As System.Windows.Forms.Label
    Public WithEvents _lblMis_56 As System.Windows.Forms.Label
    Public WithEvents _Label_66 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCalc_6 As System.Windows.Forms.Button
    Public WithEvents _pctFrames_6 As System.Windows.Forms.Panel
    Public WithEvents _txtVitiInt_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_5 As System.Windows.Forms.TextBox
    Public WithEvents _Label_124 As System.Windows.Forms.Label
    Public WithEvents _lblMis_104 As System.Windows.Forms.Label
    Public WithEvents _lblMis_79 As System.Windows.Forms.Label
    Public WithEvents _Label_93 As System.Windows.Forms.Label
    Public WithEvents framAltri2 As System.Windows.Forms.GroupBox
    Public WithEvents _txtVitiExt_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_7 As System.Windows.Forms.TextBox
    Public WithEvents _Label_90 As System.Windows.Forms.Label
    Public WithEvents _lblMis_76 As System.Windows.Forms.Label
    Public WithEvents _Label_89 As System.Windows.Forms.Label
    Public WithEvents _lblMis_75 As System.Windows.Forms.Label
    Public WithEvents _Label_88 As System.Windows.Forms.Label
    Public WithEvents _lblMis_74 As System.Windows.Forms.Label
    Public WithEvents framCarExt As System.Windows.Forms.GroupBox
    Public WithEvents _txtVitiInt_7 As System.Windows.Forms.TextBox
    Public WithEvents _Label_91 As System.Windows.Forms.Label
    Public WithEvents _lblMis_77 As System.Windows.Forms.Label
    Public WithEvents framCarInt As System.Windows.Forms.GroupBox
    Public WithEvents _txtVitiExt_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiExt_0 As System.Windows.Forms.TextBox
    Public WithEvents _cmdtir_2 As System.Windows.Forms.Button
    Public WithEvents _lblMis_109 As System.Windows.Forms.Label
    Public WithEvents _Label_130 As System.Windows.Forms.Label
    Public WithEvents _lblMis_108 As System.Windows.Forms.Label
    Public WithEvents _Label_129 As System.Windows.Forms.Label
    Public WithEvents _lblMis_101 As System.Windows.Forms.Label
    Public WithEvents _Label_123 As System.Windows.Forms.Label
    Public WithEvents _Label_87 As System.Windows.Forms.Label
    Public WithEvents _lblMis_73 As System.Windows.Forms.Label
    Public WithEvents _Label_86 As System.Windows.Forms.Label
    Public WithEvents _Label_85 As System.Windows.Forms.Label
    Public WithEvents _Label_84 As System.Windows.Forms.Label
    Public WithEvents _lblMis_71 As System.Windows.Forms.Label
    Public WithEvents _Label_83 As System.Windows.Forms.Label
    Public WithEvents _lblMis_70 As System.Windows.Forms.Label
    Public WithEvents framExtScr As System.Windows.Forms.GroupBox
    Public WithEvents _txtVitiInt_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtVitiInt_0 As System.Windows.Forms.TextBox
    Public WithEvents _cmdtir_1 As System.Windows.Forms.Button
    Public WithEvents _lblMis_107 As System.Windows.Forms.Label
    Public WithEvents _Label_128 As System.Windows.Forms.Label
    Public WithEvents _lblMis_106 As System.Windows.Forms.Label
    Public WithEvents _Label_127 As System.Windows.Forms.Label
    Public WithEvents _lblMis_100 As System.Windows.Forms.Label
    Public WithEvents _Label_122 As System.Windows.Forms.Label
    Public WithEvents _Label_82 As System.Windows.Forms.Label
    Public WithEvents _lblMis_69 As System.Windows.Forms.Label
    Public WithEvents _Label_81 As System.Windows.Forms.Label
    Public WithEvents _Label_80 As System.Windows.Forms.Label
    Public WithEvents _Label_79 As System.Windows.Forms.Label
    Public WithEvents _lblMis_67 As System.Windows.Forms.Label
    Public WithEvents _Label_78 As System.Windows.Forms.Label
    Public WithEvents _lblMis_66 As System.Windows.Forms.Label
    Public WithEvents framIntScr2 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCalc_7 As System.Windows.Forms.Button
    Public WithEvents _pctFrames_7 As System.Windows.Forms.Panel
    Public WithEvents _cmdCalc_2 As System.Windows.Forms.Button
    Public WithEvents _txtPT_7 As System.Windows.Forms.TextBox
    Public WithEvents _Label_32 As System.Windows.Forms.Label
    Public WithEvents _lblMis_24 As System.Windows.Forms.Label
    Public WithEvents framHTDiff As System.Windows.Forms.GroupBox
    Public WithEvents _txtPT_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtPT_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtPT_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtPT_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtPT_2 As System.Windows.Forms.TextBox
    Public WithEvents _Label_31 As System.Windows.Forms.Label
    Public WithEvents _lblMis_23 As System.Windows.Forms.Label
    Public WithEvents _Label_30 As System.Windows.Forms.Label
    Public WithEvents _lblMis_22 As System.Windows.Forms.Label
    Public WithEvents _Label_29 As System.Windows.Forms.Label
    Public WithEvents _lblMis_21 As System.Windows.Forms.Label
    Public WithEvents _Label_28 As System.Windows.Forms.Label
    Public WithEvents _lblMis_20 As System.Windows.Forms.Label
    Public WithEvents _Label_27 As System.Windows.Forms.Label
    Public WithEvents _lblMis_19 As System.Windows.Forms.Label
    Public WithEvents framPT As System.Windows.Forms.GroupBox
    Public WithEvents _optPasso_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optPasso_0 As System.Windows.Forms.RadioButton
    Public WithEvents _txtPT_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtPT_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label_26 As System.Windows.Forms.Label
    Public WithEvents _lblMis_18 As System.Windows.Forms.Label
    Public WithEvents _Label_25 As System.Windows.Forms.Label
    Public WithEvents _lblMis_17 As System.Windows.Forms.Label
    Public WithEvents framTubes As System.Windows.Forms.GroupBox
    Public WithEvents _pctFrames_2 As System.Windows.Forms.Panel
    Public WithEvents _txtLR_17 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_16 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_15 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_14 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_13 As System.Windows.Forms.TextBox
    Public WithEvents _lblMis_97 As System.Windows.Forms.Label
    Public WithEvents _Label_116 As System.Windows.Forms.Label
    Public WithEvents _lblMis_96 As System.Windows.Forms.Label
    Public WithEvents _Label_115 As System.Windows.Forms.Label
    Public WithEvents _lblMis_95 As System.Windows.Forms.Label
    Public WithEvents _Label_114 As System.Windows.Forms.Label
    Public WithEvents _lblMis_94 As System.Windows.Forms.Label
    Public WithEvents _Label_113 As System.Windows.Forms.Label
    Public WithEvents _Label_112 As System.Windows.Forms.Label
    Public WithEvents _lblMis_93 As System.Windows.Forms.Label
    Public WithEvents Frame6 As System.Windows.Forms.GroupBox
    Public WithEvents _txtLR_22 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_21 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_20 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_19 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_18 As System.Windows.Forms.TextBox
    Public WithEvents chkDeltaT As System.Windows.Forms.CheckBox
    Public WithEvents cmbPrecis As System.Windows.Forms.ComboBox
    Public WithEvents cmbTipoFil As System.Windows.Forms.ComboBox
    Public WithEvents _txtLR_12 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_11 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_1 As System.Windows.Forms.TextBox
    Public WithEvents _Label_121 As System.Windows.Forms.Label
    Public WithEvents _lblMis_99 As System.Windows.Forms.Label
    Public WithEvents _lblMis_92 As System.Windows.Forms.Label
    Public WithEvents _Label_120 As System.Windows.Forms.Label
    Public WithEvents _lblMis_91 As System.Windows.Forms.Label
    Public WithEvents _Label_119 As System.Windows.Forms.Label
    Public WithEvents _lblMis_90 As System.Windows.Forms.Label
    Public WithEvents _Label_118 As System.Windows.Forms.Label
    Public WithEvents _lblMis_98 As System.Windows.Forms.Label
    Public WithEvents _Label_117 As System.Windows.Forms.Label
    Public WithEvents lblPrecis As System.Windows.Forms.Label
    Public WithEvents lbltipofil As System.Windows.Forms.Label
    Public WithEvents lblFiletti As System.Windows.Forms.Label
    Public WithEvents _Label_111 As System.Windows.Forms.Label
    Public WithEvents _Label_110 As System.Windows.Forms.Label
    Public WithEvents _Label_109 As System.Windows.Forms.Label
    Public WithEvents _Label_107 As System.Windows.Forms.Label
    Public WithEvents _lblMis_88 As System.Windows.Forms.Label
    Public WithEvents _Label_97 As System.Windows.Forms.Label
    Public WithEvents _lblMis_83 As System.Windows.Forms.Label
    Public WithEvents _Label_96 As System.Windows.Forms.Label
    Public WithEvents _lblMis_82 As System.Windows.Forms.Label
    Public WithEvents _Label_95 As System.Windows.Forms.Label
    Public WithEvents _lblMis_81 As System.Windows.Forms.Label
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents _txtLR_7 As System.Windows.Forms.TextBox
    Public WithEvents _Label_106 As System.Windows.Forms.Label
    Public WithEvents _lblMis_87 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents _txtLR_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtLR_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label_108 As System.Windows.Forms.Label
    Public WithEvents _lblMis_89 As System.Windows.Forms.Label
    Public WithEvents _Label_105 As System.Windows.Forms.Label
    Public WithEvents _lblMis_86 As System.Windows.Forms.Label
    Public WithEvents _Label_99 As System.Windows.Forms.Label
    Public WithEvents _lblMis_85 As System.Windows.Forms.Label
    Public WithEvents _Label_98 As System.Windows.Forms.Label
    Public WithEvents _lblMis_84 As System.Windows.Forms.Label
    Public WithEvents _Label_94 As System.Windows.Forms.Label
    Public WithEvents _lblMis_80 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCalc_8 As System.Windows.Forms.Button
    Public WithEvents _pctFrames_8 As System.Windows.Forms.Panel
    Public WithEvents _txtCasson_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_3 As System.Windows.Forms.TextBox
    Public WithEvents _lblCasson_3 As System.Windows.Forms.Label
    Public WithEvents _lblCasson_0 As System.Windows.Forms.Label
    Public WithEvents _Label_61 As System.Windows.Forms.Label
    Public WithEvents _lblMis_51 As System.Windows.Forms.Label
    Public WithEvents _Label_60 As System.Windows.Forms.Label
    Public WithEvents _Label_59 As System.Windows.Forms.Label
    Public WithEvents _lblMis_50 As System.Windows.Forms.Label
    Public WithEvents _Label_58 As System.Windows.Forms.Label
    Public WithEvents _lblMis_49 As System.Windows.Forms.Label
    Public WithEvents _Label_57 As System.Windows.Forms.Label
    Public WithEvents _lblMis_48 As System.Windows.Forms.Label
    Public WithEvents _Label_56 As System.Windows.Forms.Label
    Public WithEvents _lblMis_47 As System.Windows.Forms.Label
    Public WithEvents _Label_55 As System.Windows.Forms.Label
    Public WithEvents _lblMis_46 As System.Windows.Forms.Label
    Public WithEvents _lblCasson_1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents _txtCasson_13 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_12 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_11 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_10 As System.Windows.Forms.TextBox
    Public WithEvents _lblFC_2 As System.Windows.Forms.Label
    Public WithEvents _lblFC_1 As System.Windows.Forms.Label
    Public WithEvents _lblFC_0 As System.Windows.Forms.Label
    Public WithEvents _lblMis_55 As System.Windows.Forms.Label
    Public WithEvents _Label_65 As System.Windows.Forms.Label
    Public WithEvents _lblMis_54 As System.Windows.Forms.Label
    Public WithEvents _Label_64 As System.Windows.Forms.Label
    Public WithEvents _lblMis_53 As System.Windows.Forms.Label
    Public WithEvents _Label_63 As System.Windows.Forms.Label
    Public WithEvents _lblMis_52 As System.Windows.Forms.Label
    Public WithEvents _Label_62 As System.Windows.Forms.Label
    Public WithEvents framFC As System.Windows.Forms.GroupBox
    Public WithEvents _txtCasson_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtCasson_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label_54 As System.Windows.Forms.Label
    Public WithEvents _lblMis_45 As System.Windows.Forms.Label
    Public WithEvents _Label_53 As System.Windows.Forms.Label
    Public WithEvents _lblMis_44 As System.Windows.Forms.Label
    Public WithEvents _Label_52 As System.Windows.Forms.Label
    Public WithEvents _lblMis_43 As System.Windows.Forms.Label
    Public WithEvents framRot As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCalc_5 As System.Windows.Forms.Button
    Public WithEvents _pctFrames_5 As System.Windows.Forms.Panel
    Public WithEvents _txtSplit_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_8 As System.Windows.Forms.TextBox
    Public WithEvents _Label_50 As System.Windows.Forms.Label
    Public WithEvents _lblMis_41 As System.Windows.Forms.Label
    Public WithEvents _Label_49 As System.Windows.Forms.Label
    Public WithEvents _lblMis_40 As System.Windows.Forms.Label
    Public WithEvents framAltri As System.Windows.Forms.GroupBox
    Public WithEvents _txtSplit_10 As System.Windows.Forms.TextBox
    Public WithEvents lblBear As System.Windows.Forms.Label
    Public WithEvents _lblMis_42 As System.Windows.Forms.Label
    Public WithEvents _Label_51 As System.Windows.Forms.Label
    Public WithEvents framBear As System.Windows.Forms.GroupBox
    Public WithEvents _cmdCalc_4 As System.Windows.Forms.Button
    Public WithEvents _txtSplit_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_3 As System.Windows.Forms.TextBox
    Public WithEvents _lblMis_37 As System.Windows.Forms.Label
    Public WithEvents _Label_46 As System.Windows.Forms.Label
    Public WithEvents _Label_48 As System.Windows.Forms.Label
    Public WithEvents _lblMis_39 As System.Windows.Forms.Label
    Public WithEvents _lblMis_36 As System.Windows.Forms.Label
    Public WithEvents _Label_45 As System.Windows.Forms.Label
    Public WithEvents _lblMis_35 As System.Windows.Forms.Label
    Public WithEvents _Label_44 As System.Windows.Forms.Label
    Public WithEvents framInner As System.Windows.Forms.GroupBox
    Public WithEvents _txtSplit_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label_47 As System.Windows.Forms.Label
    Public WithEvents _lblMis_38 As System.Windows.Forms.Label
    Public WithEvents _lblMis_34 As System.Windows.Forms.Label
    Public WithEvents _Label_43 As System.Windows.Forms.Label
    Public WithEvents _lblMis_33 As System.Windows.Forms.Label
    Public WithEvents _Label_42 As System.Windows.Forms.Label
    Public WithEvents _lblMis_32 As System.Windows.Forms.Label
    Public WithEvents _Label_41 As System.Windows.Forms.Label
    Public WithEvents framSplit As System.Windows.Forms.GroupBox
    Public WithEvents _pctFrames_4 As System.Windows.Forms.Panel
    Public WithEvents cmdtir As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents txtDes As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtSplit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtViti As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtVitiExt As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtVitiInt As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents mennuovo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents menapri As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents menSalva As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents line1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents menstampa As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents line2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents menEsci As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents menfile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAnn As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAz As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuGuiBre As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuGuide As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApert))
Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
Me.cmdLibMat = New System.Windows.Forms.Button
Me.cmdRic = New System.Windows.Forms.Button
Me._cmdGuarn1_0 = New System.Windows.Forms.Button
Me._cmdtir_0 = New System.Windows.Forms.Button
Me._cmdGuarn1_1 = New System.Windows.Forms.Button
Me._cmdtir_2 = New System.Windows.Forms.Button
Me._cmdtir_1 = New System.Windows.Forms.Button
Me.UpDownMat = New System.Windows.Forms.NumericUpDown
Me.cmbMat = New System.Windows.Forms.ComboBox
Me.cmdRicalcola = New System.Windows.Forms.Button
Me.cmdRicalcRings = New System.Windows.Forms.Button
Me._Label_57 = New System.Windows.Forms.Label
Me._Label_56 = New System.Windows.Forms.Label
Me._Label_55 = New System.Windows.Forms.Label
Me.cmdRicalcShell = New System.Windows.Forms.Button
Me.cmdRicalcCassa = New System.Windows.Forms.Button
Me.cmdRicalcCasson = New System.Windows.Forms.Button
Me.chkSuperSafe = New System.Windows.Forms.CheckBox
Me.cmdEstensioneAutomatica = New System.Windows.Forms.Button
Me.cmdMinCasson = New System.Windows.Forms.Button
Me.rtLogo = New System.Windows.Forms.RichTextBox
Me.Commento = New System.Windows.Forms.GroupBox
Me.Labelcom1 = New System.Windows.Forms.Label
Me._pctFrames_0 = New System.Windows.Forms.Panel
Me.framNorme = New System.Windows.Forms.GroupBox
Me.optdiv3 = New System.Windows.Forms.RadioButton
Me.optdiv1 = New System.Windows.Forms.RadioButton
Me.optdiv2 = New System.Windows.Forms.RadioButton
Me.cmdSel = New System.Windows.Forms.Button
Me.cmbStampa = New System.Windows.Forms.ComboBox
Me.framDiff = New System.Windows.Forms.GroupBox
Me._optDiff_1 = New System.Windows.Forms.RadioButton
Me._optDiff_0 = New System.Windows.Forms.RadioButton
Me.framTipo = New System.Windows.Forms.GroupBox
Me._optTipo_0 = New System.Windows.Forms.RadioButton
Me._optTipo_1 = New System.Windows.Forms.RadioButton
Me.framPDiffHT = New System.Windows.Forms.GroupBox
Me._txtDes_0 = New System.Windows.Forms.TextBox
Me._lblMis_78 = New System.Windows.Forms.Label
Me._Label_92 = New System.Windows.Forms.Label
Me._lblMis_0 = New System.Windows.Forms.Label
Me._Label_0 = New System.Windows.Forms.Label
Me._lblMis_1 = New System.Windows.Forms.Label
Me._Label_1 = New System.Windows.Forms.Label
Me._Label_2 = New System.Windows.Forms.Label
Me._lblMis_3 = New System.Windows.Forms.Label
Me._Label_3 = New System.Windows.Forms.Label
Me._lblMis_2 = New System.Windows.Forms.Label
Me._Label_4 = New System.Windows.Forms.Label
Me._lblMis_4 = New System.Windows.Forms.Label
Me._txtDes_1 = New System.Windows.Forms.TextBox
Me._txtDes_2 = New System.Windows.Forms.TextBox
Me._txtDes_3 = New System.Windows.Forms.TextBox
Me._txtDes_4 = New System.Windows.Forms.TextBox
Me._txtDes_5 = New System.Windows.Forms.TextBox
Me.framMat = New System.Windows.Forms.GroupBox
Me._txtMat_0 = New System.Windows.Forms.TextBox
Me._txtMat_1 = New System.Windows.Forms.TextBox
Me._txtMat_2 = New System.Windows.Forms.TextBox
Me._txtMat_3 = New System.Windows.Forms.TextBox
Me._txtMat_4 = New System.Windows.Forms.TextBox
Me._txtMat_5 = New System.Windows.Forms.TextBox
Me._txtMat_6 = New System.Windows.Forms.TextBox
Me._txtMat_7 = New System.Windows.Forms.TextBox
Me._txtMat_8 = New System.Windows.Forms.TextBox
Me._lblMat_3 = New System.Windows.Forms.Label
Me._lblMisMat_3 = New System.Windows.Forms.Label
Me._lblMat_2 = New System.Windows.Forms.Label
Me._lblMat_1 = New System.Windows.Forms.Label
Me._lblMisMat_1 = New System.Windows.Forms.Label
Me._lblMat_0 = New System.Windows.Forms.Label
Me._lblMisMat_0 = New System.Windows.Forms.Label
Me._lblMisMat_2 = New System.Windows.Forms.Label
Me._lblMat_4 = New System.Windows.Forms.Label
Me._lblMisMat_4 = New System.Windows.Forms.Label
Me._lblMat_5 = New System.Windows.Forms.Label
Me._lblMisMat_5 = New System.Windows.Forms.Label
Me._lblMat_6 = New System.Windows.Forms.Label
Me._lblMisMat_6 = New System.Windows.Forms.Label
Me._lblMat_7 = New System.Windows.Forms.Label
Me._lblMisMat_7 = New System.Windows.Forms.Label
Me._Label_8 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me._pctFrames_1 = New System.Windows.Forms.Panel
Me._cmdCalc_1 = New System.Windows.Forms.Button
Me.framHead = New System.Windows.Forms.GroupBox
Me.chkNonCalcolaFondo = New System.Windows.Forms.CheckBox
Me._txtShell_15 = New System.Windows.Forms.TextBox
Me._txtShell_14 = New System.Windows.Forms.TextBox
Me._txtShell_13 = New System.Windows.Forms.TextBox
Me._txtShell_12 = New System.Windows.Forms.TextBox
Me._Label_24 = New System.Windows.Forms.Label
Me._lblMis_16 = New System.Windows.Forms.Label
Me._Label_23 = New System.Windows.Forms.Label
Me._lblMis_15 = New System.Windows.Forms.Label
Me._Label_22 = New System.Windows.Forms.Label
Me._lblMis_14 = New System.Windows.Forms.Label
Me._Label_21 = New System.Windows.Forms.Label
Me._lblMis_13 = New System.Windows.Forms.Label
Me.framGsk1 = New System.Windows.Forms.GroupBox
Me._txtShell_18 = New System.Windows.Forms.TextBox
Me._txtShell_2 = New System.Windows.Forms.TextBox
Me._txtShell_4 = New System.Windows.Forms.TextBox
Me._txtShell_5 = New System.Windows.Forms.TextBox
Me._txtShell_6 = New System.Windows.Forms.TextBox
Me._txtShell_7 = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me._txtShell_17 = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.chkAnelloEst = New System.Windows.Forms.CheckBox
Me._txtShell_16 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.chkAnelloInt = New System.Windows.Forms.CheckBox
Me._txtShell_9 = New System.Windows.Forms.TextBox
Me._txtShell_8 = New System.Windows.Forms.TextBox
Me._txtShell_3 = New System.Windows.Forms.TextBox
Me._Label_18 = New System.Windows.Forms.Label
Me._lblMis_10 = New System.Windows.Forms.Label
Me._Label_17 = New System.Windows.Forms.Label
Me._lblMis_9 = New System.Windows.Forms.Label
Me._Label_16 = New System.Windows.Forms.Label
Me._lblMis_8 = New System.Windows.Forms.Label
Me._Label_15 = New System.Windows.Forms.Label
Me._Label_14 = New System.Windows.Forms.Label
Me._lblMis_7 = New System.Windows.Forms.Label
Me._Label_13 = New System.Windows.Forms.Label
Me._lblMis_6 = New System.Windows.Forms.Label
Me._Label_11 = New System.Windows.Forms.Label
Me._Label_9 = New System.Windows.Forms.Label
Me._lblMis_5 = New System.Windows.Forms.Label
Me.framShell = New System.Windows.Forms.GroupBox
Me._txtShell_11 = New System.Windows.Forms.TextBox
Me._txtShell_10 = New System.Windows.Forms.TextBox
Me._txtShell_1 = New System.Windows.Forms.TextBox
Me._txtShell_0 = New System.Windows.Forms.TextBox
Me._lblMis_12 = New System.Windows.Forms.Label
Me._Label_20 = New System.Windows.Forms.Label
Me._lblMis_11 = New System.Windows.Forms.Label
Me._Label_19 = New System.Windows.Forms.Label
Me._lblMis_103 = New System.Windows.Forms.Label
Me._Label_12 = New System.Windows.Forms.Label
Me._lblMis_102 = New System.Windows.Forms.Label
Me._Label_10 = New System.Windows.Forms.Label
Me._pctFrames_3 = New System.Windows.Forms.Panel
Me.txtTroppiTiranti = New System.Windows.Forms.TextBox
Me._cmdCalc_3 = New System.Windows.Forms.Button
Me.framCarichi = New System.Windows.Forms.GroupBox
Me._optPlastic_1 = New System.Windows.Forms.RadioButton
Me._optPlastic_0 = New System.Windows.Forms.RadioButton
Me._txtViti_7 = New System.Windows.Forms.TextBox
Me._txtViti_6 = New System.Windows.Forms.TextBox
Me._txtViti_5 = New System.Windows.Forms.TextBox
Me._txtViti_4 = New System.Windows.Forms.TextBox
Me._lblMis_31 = New System.Windows.Forms.Label
Me._Label_40 = New System.Windows.Forms.Label
Me._lblMis_30 = New System.Windows.Forms.Label
Me._Label_39 = New System.Windows.Forms.Label
Me._lblMis_29 = New System.Windows.Forms.Label
Me._Label_38 = New System.Windows.Forms.Label
Me._lblMis_26 = New System.Windows.Forms.Label
Me._Label_37 = New System.Windows.Forms.Label
Me.framViti = New System.Windows.Forms.GroupBox
Me.txtSizeScr = New System.Windows.Forms.TextBox
Me._txtViti_9 = New System.Windows.Forms.TextBox
Me._txtViti_8 = New System.Windows.Forms.TextBox
Me._txtViti_10 = New System.Windows.Forms.TextBox
Me._txtViti_3 = New System.Windows.Forms.TextBox
Me._txtViti_2 = New System.Windows.Forms.TextBox
Me._txtViti_1 = New System.Windows.Forms.TextBox
Me._txtViti_0 = New System.Windows.Forms.TextBox
Me._Label_131 = New System.Windows.Forms.Label
Me._lblMis_110 = New System.Windows.Forms.Label
Me._Label_126 = New System.Windows.Forms.Label
Me._lblMis_105 = New System.Windows.Forms.Label
Me._Label_125 = New System.Windows.Forms.Label
Me._lblMis_25 = New System.Windows.Forms.Label
Me._lblMis_28 = New System.Windows.Forms.Label
Me._Label_36 = New System.Windows.Forms.Label
Me._lblMis_27 = New System.Windows.Forms.Label
Me._Label_35 = New System.Windows.Forms.Label
Me._Label_34 = New System.Windows.Forms.Label
Me._Label_33 = New System.Windows.Forms.Label
Me._pctFrames_6 = New System.Windows.Forms.Panel
Me.framChan = New System.Windows.Forms.GroupBox
Me._txtchan_11 = New System.Windows.Forms.TextBox
Me._txtchan_10 = New System.Windows.Forms.TextBox
Me._txtchan_1 = New System.Windows.Forms.TextBox
Me._txtchan_0 = New System.Windows.Forms.TextBox
Me._lblMis_65 = New System.Windows.Forms.Label
Me._Label_77 = New System.Windows.Forms.Label
Me._lblMis_64 = New System.Windows.Forms.Label
Me._Label_76 = New System.Windows.Forms.Label
Me._lblMis_63 = New System.Windows.Forms.Label
Me._Label_75 = New System.Windows.Forms.Label
Me._lblMis_62 = New System.Windows.Forms.Label
Me._Label_74 = New System.Windows.Forms.Label
Me.Frame2 = New System.Windows.Forms.GroupBox
Me._txtchan_14 = New System.Windows.Forms.TextBox
Me.Label10 = New System.Windows.Forms.Label
Me.Label11 = New System.Windows.Forms.Label
Me._txtChan_13 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.chkAnelloEst2 = New System.Windows.Forms.CheckBox
Me._txtChan_12 = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.chkAnelloInt2 = New System.Windows.Forms.CheckBox
Me._txtchan_3 = New System.Windows.Forms.TextBox
Me._txtchan_2 = New System.Windows.Forms.TextBox
Me._txtchan_4 = New System.Windows.Forms.TextBox
Me._txtchan_5 = New System.Windows.Forms.TextBox
Me._txtchan_6 = New System.Windows.Forms.TextBox
Me._txtchan_7 = New System.Windows.Forms.TextBox
Me._txtchan_8 = New System.Windows.Forms.TextBox
Me._txtchan_9 = New System.Windows.Forms.TextBox
Me._lblMis_61 = New System.Windows.Forms.Label
Me._Label_73 = New System.Windows.Forms.Label
Me._Label_72 = New System.Windows.Forms.Label
Me._lblMis_60 = New System.Windows.Forms.Label
Me._Label_71 = New System.Windows.Forms.Label
Me._lblMis_59 = New System.Windows.Forms.Label
Me._Label_70 = New System.Windows.Forms.Label
Me._Label_69 = New System.Windows.Forms.Label
Me._lblMis_58 = New System.Windows.Forms.Label
Me._Label_68 = New System.Windows.Forms.Label
Me._lblMis_57 = New System.Windows.Forms.Label
Me._Label_67 = New System.Windows.Forms.Label
Me._lblMis_56 = New System.Windows.Forms.Label
Me._Label_66 = New System.Windows.Forms.Label
Me._cmdCalc_6 = New System.Windows.Forms.Button
Me._pctFrames_7 = New System.Windows.Forms.Panel
Me.framCarInt = New System.Windows.Forms.GroupBox
Me._lblMis_77 = New System.Windows.Forms.Label
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
Me.Label13 = New System.Windows.Forms.Label
Me._txtVitiInt_7 = New System.Windows.Forms.TextBox
Me._Label_91 = New System.Windows.Forms.Label
Me.framAltri2 = New System.Windows.Forms.GroupBox
Me._txtVitiInt_8 = New System.Windows.Forms.TextBox
Me._txtVitiInt_5 = New System.Windows.Forms.TextBox
Me._Label_124 = New System.Windows.Forms.Label
Me._lblMis_104 = New System.Windows.Forms.Label
Me._lblMis_79 = New System.Windows.Forms.Label
Me._Label_93 = New System.Windows.Forms.Label
Me.framCarExt = New System.Windows.Forms.GroupBox
Me._txtVitiExt_5 = New System.Windows.Forms.TextBox
Me._txtVitiExt_6 = New System.Windows.Forms.TextBox
Me._txtVitiExt_7 = New System.Windows.Forms.TextBox
Me._Label_90 = New System.Windows.Forms.Label
Me._lblMis_76 = New System.Windows.Forms.Label
Me._Label_89 = New System.Windows.Forms.Label
Me._lblMis_75 = New System.Windows.Forms.Label
Me._Label_88 = New System.Windows.Forms.Label
Me._lblMis_74 = New System.Windows.Forms.Label
Me.framExtScr = New System.Windows.Forms.GroupBox
Me._txtVitiExt_8 = New System.Windows.Forms.TextBox
Me._txtVitiExt_4 = New System.Windows.Forms.TextBox
Me._txtVitiExt_10 = New System.Windows.Forms.TextBox
Me._txtVitiExt_9 = New System.Windows.Forms.TextBox
Me._txtVitiExt_3 = New System.Windows.Forms.TextBox
Me._txtVitiExt_2 = New System.Windows.Forms.TextBox
Me._txtVitiExt_1 = New System.Windows.Forms.TextBox
Me._txtVitiExt_0 = New System.Windows.Forms.TextBox
Me._lblMis_109 = New System.Windows.Forms.Label
Me._Label_130 = New System.Windows.Forms.Label
Me._lblMis_108 = New System.Windows.Forms.Label
Me._Label_129 = New System.Windows.Forms.Label
Me._lblMis_101 = New System.Windows.Forms.Label
Me._Label_123 = New System.Windows.Forms.Label
Me._Label_87 = New System.Windows.Forms.Label
Me._lblMis_73 = New System.Windows.Forms.Label
Me._Label_86 = New System.Windows.Forms.Label
Me._Label_85 = New System.Windows.Forms.Label
Me._Label_84 = New System.Windows.Forms.Label
Me._lblMis_71 = New System.Windows.Forms.Label
Me._Label_83 = New System.Windows.Forms.Label
Me._lblMis_70 = New System.Windows.Forms.Label
Me.framIntScr2 = New System.Windows.Forms.GroupBox
Me._txtVitiInt_6 = New System.Windows.Forms.TextBox
Me._txtVitiInt_4 = New System.Windows.Forms.TextBox
Me._txtVitiInt_10 = New System.Windows.Forms.TextBox
Me._txtVitiInt_9 = New System.Windows.Forms.TextBox
Me._txtVitiInt_3 = New System.Windows.Forms.TextBox
Me._txtVitiInt_2 = New System.Windows.Forms.TextBox
Me._txtVitiInt_1 = New System.Windows.Forms.TextBox
Me._txtVitiInt_0 = New System.Windows.Forms.TextBox
Me._lblMis_107 = New System.Windows.Forms.Label
Me._Label_128 = New System.Windows.Forms.Label
Me._lblMis_106 = New System.Windows.Forms.Label
Me._Label_127 = New System.Windows.Forms.Label
Me._lblMis_100 = New System.Windows.Forms.Label
Me._Label_122 = New System.Windows.Forms.Label
Me._Label_82 = New System.Windows.Forms.Label
Me._lblMis_69 = New System.Windows.Forms.Label
Me._Label_81 = New System.Windows.Forms.Label
Me._Label_80 = New System.Windows.Forms.Label
Me._Label_79 = New System.Windows.Forms.Label
Me._lblMis_67 = New System.Windows.Forms.Label
Me._Label_78 = New System.Windows.Forms.Label
Me._lblMis_66 = New System.Windows.Forms.Label
Me._cmdCalc_7 = New System.Windows.Forms.Button
Me._pctFrames_2 = New System.Windows.Forms.Panel
Me._cmdCalc_2 = New System.Windows.Forms.Button
Me.framHTDiff = New System.Windows.Forms.GroupBox
Me._txtPT_7 = New System.Windows.Forms.TextBox
Me._Label_32 = New System.Windows.Forms.Label
Me._lblMis_24 = New System.Windows.Forms.Label
Me.framPT = New System.Windows.Forms.GroupBox
Me._txtPT_6 = New System.Windows.Forms.TextBox
Me._txtPT_5 = New System.Windows.Forms.TextBox
Me._txtPT_4 = New System.Windows.Forms.TextBox
Me._txtPT_3 = New System.Windows.Forms.TextBox
Me._txtPT_2 = New System.Windows.Forms.TextBox
Me._txtPT_8 = New System.Windows.Forms.TextBox
Me._txtPT_9 = New System.Windows.Forms.TextBox
Me.Label20 = New System.Windows.Forms.Label
Me.Label21 = New System.Windows.Forms.Label
Me.Label22 = New System.Windows.Forms.Label
Me.Label23 = New System.Windows.Forms.Label
Me._Label_31 = New System.Windows.Forms.Label
Me._lblMis_23 = New System.Windows.Forms.Label
Me._Label_30 = New System.Windows.Forms.Label
Me._lblMis_22 = New System.Windows.Forms.Label
Me._Label_29 = New System.Windows.Forms.Label
Me._lblMis_21 = New System.Windows.Forms.Label
Me._Label_28 = New System.Windows.Forms.Label
Me._lblMis_20 = New System.Windows.Forms.Label
Me._Label_27 = New System.Windows.Forms.Label
Me._lblMis_19 = New System.Windows.Forms.Label
Me.framTubes = New System.Windows.Forms.GroupBox
Me._optPasso_1 = New System.Windows.Forms.RadioButton
Me._optPasso_0 = New System.Windows.Forms.RadioButton
Me._txtPT_1 = New System.Windows.Forms.TextBox
Me._txtPT_0 = New System.Windows.Forms.TextBox
Me._Label_26 = New System.Windows.Forms.Label
Me._lblMis_18 = New System.Windows.Forms.Label
Me._Label_25 = New System.Windows.Forms.Label
Me._lblMis_17 = New System.Windows.Forms.Label
Me._pctFrames_8 = New System.Windows.Forms.Panel
Me.Frame6 = New System.Windows.Forms.GroupBox
Me._txtLR_13 = New System.Windows.Forms.TextBox
Me._txtLR_15 = New System.Windows.Forms.TextBox
Me._txtLR_14 = New System.Windows.Forms.TextBox
Me._txtLR_17 = New System.Windows.Forms.TextBox
Me._txtLR_16 = New System.Windows.Forms.TextBox
Me._lblMis_97 = New System.Windows.Forms.Label
Me._Label_116 = New System.Windows.Forms.Label
Me._lblMis_96 = New System.Windows.Forms.Label
Me._Label_115 = New System.Windows.Forms.Label
Me._lblMis_95 = New System.Windows.Forms.Label
Me._Label_114 = New System.Windows.Forms.Label
Me._lblMis_94 = New System.Windows.Forms.Label
Me._Label_113 = New System.Windows.Forms.Label
Me._Label_112 = New System.Windows.Forms.Label
Me._lblMis_93 = New System.Windows.Forms.Label
Me.Frame5 = New System.Windows.Forms.GroupBox
Me._txtLR_23 = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.Label15 = New System.Windows.Forms.Label
Me._txtLR_22 = New System.Windows.Forms.TextBox
Me._txtLR_21 = New System.Windows.Forms.TextBox
Me._txtLR_20 = New System.Windows.Forms.TextBox
Me._txtLR_19 = New System.Windows.Forms.TextBox
Me._txtLR_18 = New System.Windows.Forms.TextBox
Me.chkDeltaT = New System.Windows.Forms.CheckBox
Me.cmbPrecis = New System.Windows.Forms.ComboBox
Me.cmbTipoFil = New System.Windows.Forms.ComboBox
Me._txtLR_12 = New System.Windows.Forms.TextBox
Me._txtLR_11 = New System.Windows.Forms.TextBox
Me._txtLR_10 = New System.Windows.Forms.TextBox
Me._txtLR_8 = New System.Windows.Forms.TextBox
Me._txtLR_3 = New System.Windows.Forms.TextBox
Me._txtLR_2 = New System.Windows.Forms.TextBox
Me._txtLR_1 = New System.Windows.Forms.TextBox
Me._Label_121 = New System.Windows.Forms.Label
Me._lblMis_99 = New System.Windows.Forms.Label
Me._lblMis_92 = New System.Windows.Forms.Label
Me._Label_120 = New System.Windows.Forms.Label
Me._lblMis_91 = New System.Windows.Forms.Label
Me._Label_119 = New System.Windows.Forms.Label
Me._lblMis_90 = New System.Windows.Forms.Label
Me._Label_118 = New System.Windows.Forms.Label
Me._lblMis_98 = New System.Windows.Forms.Label
Me._Label_117 = New System.Windows.Forms.Label
Me.lblPrecis = New System.Windows.Forms.Label
Me.lbltipofil = New System.Windows.Forms.Label
Me.lblFiletti = New System.Windows.Forms.Label
Me._Label_111 = New System.Windows.Forms.Label
Me._Label_110 = New System.Windows.Forms.Label
Me._Label_109 = New System.Windows.Forms.Label
Me._Label_107 = New System.Windows.Forms.Label
Me._lblMis_88 = New System.Windows.Forms.Label
Me._Label_97 = New System.Windows.Forms.Label
Me._lblMis_83 = New System.Windows.Forms.Label
Me._Label_96 = New System.Windows.Forms.Label
Me._lblMis_82 = New System.Windows.Forms.Label
Me._Label_95 = New System.Windows.Forms.Label
Me._lblMis_81 = New System.Windows.Forms.Label
Me.Frame4 = New System.Windows.Forms.GroupBox
Me._txtLR_26 = New System.Windows.Forms.TextBox
Me.Label25 = New System.Windows.Forms.Label
Me.Label26 = New System.Windows.Forms.Label
Me.Label18 = New System.Windows.Forms.Label
Me.Label19 = New System.Windows.Forms.Label
Me._txtLR_24 = New System.Windows.Forms.TextBox
Me.Label16 = New System.Windows.Forms.Label
Me.Label17 = New System.Windows.Forms.Label
Me._txtLR_7 = New System.Windows.Forms.TextBox
Me._Label_106 = New System.Windows.Forms.Label
Me._lblMis_87 = New System.Windows.Forms.Label
Me._txtLR_25 = New System.Windows.Forms.TextBox
Me.Frame3 = New System.Windows.Forms.GroupBox
Me._txtLR_6 = New System.Windows.Forms.TextBox
Me._txtLR_9 = New System.Windows.Forms.TextBox
Me._txtLR_4 = New System.Windows.Forms.TextBox
Me._txtLR_5 = New System.Windows.Forms.TextBox
Me._txtLR_0 = New System.Windows.Forms.TextBox
Me._Label_108 = New System.Windows.Forms.Label
Me._lblMis_89 = New System.Windows.Forms.Label
Me._Label_105 = New System.Windows.Forms.Label
Me._lblMis_86 = New System.Windows.Forms.Label
Me._Label_99 = New System.Windows.Forms.Label
Me._lblMis_85 = New System.Windows.Forms.Label
Me._Label_98 = New System.Windows.Forms.Label
Me._lblMis_84 = New System.Windows.Forms.Label
Me._Label_94 = New System.Windows.Forms.Label
Me._lblMis_80 = New System.Windows.Forms.Label
Me._cmdCalc_8 = New System.Windows.Forms.Button
Me._pctFrames_5 = New System.Windows.Forms.Panel
Me.Frame1 = New System.Windows.Forms.GroupBox
Me.cmbTipoCassonetto = New System.Windows.Forms.ComboBox
Me.Label24 = New System.Windows.Forms.Label
Me._txtCasson_9 = New System.Windows.Forms.TextBox
Me._txtCasson_8 = New System.Windows.Forms.TextBox
Me._txtCasson_7 = New System.Windows.Forms.TextBox
Me._txtCasson_6 = New System.Windows.Forms.TextBox
Me._txtCasson_5 = New System.Windows.Forms.TextBox
Me._txtCasson_4 = New System.Windows.Forms.TextBox
Me._txtCasson_3 = New System.Windows.Forms.TextBox
Me._lblCasson_3 = New System.Windows.Forms.Label
Me._lblCasson_0 = New System.Windows.Forms.Label
Me._Label_61 = New System.Windows.Forms.Label
Me._lblMis_51 = New System.Windows.Forms.Label
Me._Label_60 = New System.Windows.Forms.Label
Me._Label_59 = New System.Windows.Forms.Label
Me._lblMis_50 = New System.Windows.Forms.Label
Me._Label_58 = New System.Windows.Forms.Label
Me._lblMis_49 = New System.Windows.Forms.Label
Me._lblMis_48 = New System.Windows.Forms.Label
Me._lblMis_47 = New System.Windows.Forms.Label
Me._lblMis_46 = New System.Windows.Forms.Label
Me._lblCasson_1 = New System.Windows.Forms.Label
Me.framFC = New System.Windows.Forms.GroupBox
Me._txtCasson_13 = New System.Windows.Forms.TextBox
Me._txtCasson_12 = New System.Windows.Forms.TextBox
Me._txtCasson_11 = New System.Windows.Forms.TextBox
Me._txtCasson_10 = New System.Windows.Forms.TextBox
Me._lblFC_2 = New System.Windows.Forms.Label
Me._lblFC_1 = New System.Windows.Forms.Label
Me._lblFC_0 = New System.Windows.Forms.Label
Me._lblMis_55 = New System.Windows.Forms.Label
Me._Label_65 = New System.Windows.Forms.Label
Me._lblMis_54 = New System.Windows.Forms.Label
Me._Label_64 = New System.Windows.Forms.Label
Me._lblMis_53 = New System.Windows.Forms.Label
Me._Label_63 = New System.Windows.Forms.Label
Me._lblMis_52 = New System.Windows.Forms.Label
Me._Label_62 = New System.Windows.Forms.Label
Me.framRot = New System.Windows.Forms.GroupBox
Me._txtCasson_2 = New System.Windows.Forms.TextBox
Me._txtCasson_1 = New System.Windows.Forms.TextBox
Me._txtCasson_0 = New System.Windows.Forms.TextBox
Me._Label_54 = New System.Windows.Forms.Label
Me._lblMis_45 = New System.Windows.Forms.Label
Me._Label_53 = New System.Windows.Forms.Label
Me._lblMis_44 = New System.Windows.Forms.Label
Me._Label_52 = New System.Windows.Forms.Label
Me._lblMis_43 = New System.Windows.Forms.Label
Me._cmdCalc_5 = New System.Windows.Forms.Button
Me._pctFrames_4 = New System.Windows.Forms.Panel
Me.framCorr = New System.Windows.Forms.GroupBox
Me._txtSplit_9 = New System.Windows.Forms.TextBox
Me._Label_50 = New System.Windows.Forms.Label
Me._lblMis_41 = New System.Windows.Forms.Label
Me.framAltri = New System.Windows.Forms.GroupBox
Me._txtSplit_8 = New System.Windows.Forms.TextBox
Me._Label_49 = New System.Windows.Forms.Label
Me._lblMis_40 = New System.Windows.Forms.Label
Me.framBear = New System.Windows.Forms.GroupBox
Me._txtSplit_11 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me._txtSplit_10 = New System.Windows.Forms.TextBox
Me.lblBear = New System.Windows.Forms.Label
Me._lblMis_42 = New System.Windows.Forms.Label
Me._Label_51 = New System.Windows.Forms.Label
Me._cmdCalc_4 = New System.Windows.Forms.Button
Me.framInner = New System.Windows.Forms.GroupBox
Me._txtSplit_5 = New System.Windows.Forms.TextBox
Me._txtSplit_7 = New System.Windows.Forms.TextBox
Me._txtSplit_4 = New System.Windows.Forms.TextBox
Me._txtSplit_3 = New System.Windows.Forms.TextBox
Me._lblMis_37 = New System.Windows.Forms.Label
Me._Label_46 = New System.Windows.Forms.Label
Me._Label_48 = New System.Windows.Forms.Label
Me._lblMis_39 = New System.Windows.Forms.Label
Me._lblMis_36 = New System.Windows.Forms.Label
Me._Label_45 = New System.Windows.Forms.Label
Me._lblMis_35 = New System.Windows.Forms.Label
Me._Label_44 = New System.Windows.Forms.Label
Me.framSplit = New System.Windows.Forms.GroupBox
Me._txtSplit_6 = New System.Windows.Forms.TextBox
Me._txtSplit_2 = New System.Windows.Forms.TextBox
Me._txtSplit_1 = New System.Windows.Forms.TextBox
Me._txtSplit_0 = New System.Windows.Forms.TextBox
Me._Label_47 = New System.Windows.Forms.Label
Me._lblMis_38 = New System.Windows.Forms.Label
Me._lblMis_34 = New System.Windows.Forms.Label
Me._Label_43 = New System.Windows.Forms.Label
Me._lblMis_33 = New System.Windows.Forms.Label
Me._Label_42 = New System.Windows.Forms.Label
Me._lblMis_32 = New System.Windows.Forms.Label
Me._Label_41 = New System.Windows.Forms.Label
Me.cmdtir = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
Me.txtDes = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
Me.txtSplit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
Me.txtViti = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
Me.txtVitiExt = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
Me.txtVitiInt = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
Me.MainMenu1 = New System.Windows.Forms.MenuStrip
Me.menfile = New System.Windows.Forms.ToolStripMenuItem
Me.mennuovo = New System.Windows.Forms.ToolStripMenuItem
Me.menapri = New System.Windows.Forms.ToolStripMenuItem
Me.menChiudi = New System.Windows.Forms.ToolStripMenuItem
Me.menSalva = New System.Windows.Forms.ToolStripMenuItem
Me.menSalvaCome = New System.Windows.Forms.ToolStripMenuItem
Me.line1 = New System.Windows.Forms.ToolStripSeparator
Me.menstampa = New System.Windows.Forms.ToolStripMenuItem
Me.line2 = New System.Windows.Forms.ToolStripSeparator
Me.menEsci = New System.Windows.Forms.ToolStripMenuItem
Me.mnuAz = New System.Windows.Forms.ToolStripMenuItem
Me.mnuCalcolaTutto = New System.Windows.Forms.ToolStripMenuItem
Me.mnuAnn = New System.Windows.Forms.ToolStripMenuItem
Me.mnuCalcGeomAuto = New System.Windows.Forms.ToolStripMenuItem
Me.PreferenzeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.mnuPrefBuckling = New System.Windows.Forms.ToolStripMenuItem
Me.mnuVitiSnerv = New System.Windows.Forms.ToolStripMenuItem
Me.menVitiAutomatiche = New System.Windows.Forms.ToolStripMenuItem
Me.mnuAutomEstensioni = New System.Windows.Forms.ToolStripMenuItem
Me.mnuGuide = New System.Windows.Forms.ToolStripMenuItem
Me.mnuGuiBre = New System.Windows.Forms.ToolStripMenuItem
Me.mnuInf = New System.Windows.Forms.ToolStripMenuItem
Me.TabStrip1 = New System.Windows.Forms.TabControl
Me.TabPage1 = New System.Windows.Forms.TabPage
Me.TabPage2 = New System.Windows.Forms.TabPage
Me.TabPage3 = New System.Windows.Forms.TabPage
Me.TabPage4 = New System.Windows.Forms.TabPage
Me.TabPage5 = New System.Windows.Forms.TabPage
Me.TabPage6 = New System.Windows.Forms.TabPage
Me.TabPage7 = New System.Windows.Forms.TabPage
Me.TabPage8 = New System.Windows.Forms.TabPage
Me.TabPage9 = New System.Windows.Forms.TabPage
Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
Me.StatusBar1 = New System.Windows.Forms.StatusBar
Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel
Me.CommonDialog2 = New System.Windows.Forms.SaveFileDialog
CType(Me.UpDownMat,System.ComponentModel.ISupportInitialize).BeginInit
Me.Commento.SuspendLayout
Me._pctFrames_0.SuspendLayout
Me.framNorme.SuspendLayout
Me.framDiff.SuspendLayout
Me.framTipo.SuspendLayout
Me.framPDiffHT.SuspendLayout
Me.framMat.SuspendLayout
Me._pctFrames_1.SuspendLayout
Me.framHead.SuspendLayout
Me.framGsk1.SuspendLayout
Me.framShell.SuspendLayout
Me._pctFrames_3.SuspendLayout
Me.framCarichi.SuspendLayout
Me.framViti.SuspendLayout
Me._pctFrames_6.SuspendLayout
Me.framChan.SuspendLayout
Me.Frame2.SuspendLayout
Me._pctFrames_7.SuspendLayout
Me.framCarInt.SuspendLayout
Me.framAltri2.SuspendLayout
Me.framCarExt.SuspendLayout
Me.framExtScr.SuspendLayout
Me.framIntScr2.SuspendLayout
Me._pctFrames_2.SuspendLayout
Me.framHTDiff.SuspendLayout
Me.framPT.SuspendLayout
Me.framTubes.SuspendLayout
Me._pctFrames_8.SuspendLayout
Me.Frame6.SuspendLayout
Me.Frame5.SuspendLayout
Me.Frame4.SuspendLayout
Me.Frame3.SuspendLayout
Me._pctFrames_5.SuspendLayout
Me.Frame1.SuspendLayout
Me.framFC.SuspendLayout
Me.framRot.SuspendLayout
Me._pctFrames_4.SuspendLayout
Me.framCorr.SuspendLayout
Me.framAltri.SuspendLayout
Me.framBear.SuspendLayout
Me.framInner.SuspendLayout
Me.framSplit.SuspendLayout
CType(Me.cmdtir,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.txtDes,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.txtSplit,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.txtViti,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.txtVitiExt,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.txtVitiInt,System.ComponentModel.ISupportInitialize).BeginInit
Me.MainMenu1.SuspendLayout
Me.TabStrip1.SuspendLayout
Me.TabPage1.SuspendLayout
Me.TabPage2.SuspendLayout
Me.TabPage3.SuspendLayout
Me.TabPage4.SuspendLayout
Me.TabPage5.SuspendLayout
Me.TabPage6.SuspendLayout
Me.TabPage7.SuspendLayout
Me.TabPage8.SuspendLayout
Me.TabPage9.SuspendLayout
CType(Me.StatusBarPanel1,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.StatusBarPanel2,System.ComponentModel.ISupportInitialize).BeginInit
CType(Me.StatusBarPanel3,System.ComponentModel.ISupportInitialize).BeginInit
Me.SuspendLayout
'
'cmdLibMat
'
Me.cmdLibMat.BackColor = System.Drawing.SystemColors.Control
Me.cmdLibMat.Cursor = System.Windows.Forms.Cursors.Default
Me.cmdLibMat.ForeColor = System.Drawing.SystemColors.ControlText
Me.cmdLibMat.Image = CType(resources.GetObject("cmdLibMat.Image"),System.Drawing.Image)
Me.cmdLibMat.Location = New System.Drawing.Point(256, 16)
Me.cmdLibMat.Name = "cmdLibMat"
Me.cmdLibMat.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmdLibMat.Size = New System.Drawing.Size(22, 22)
Me.cmdLibMat.TabIndex = 8
Me.cmdLibMat.TabStop = false
Me.cmdLibMat.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me.cmdLibMat, "Richiama la libreria dei materiali")
Me.cmdLibMat.UseVisualStyleBackColor = false
'
'cmdRic
'
Me.cmdRic.BackColor = System.Drawing.SystemColors.Control
Me.cmdRic.Cursor = System.Windows.Forms.Cursors.Default
Me.cmdRic.ForeColor = System.Drawing.SystemColors.ControlText
Me.cmdRic.Image = CType(resources.GetObject("cmdRic.Image"),System.Drawing.Image)
Me.cmdRic.Location = New System.Drawing.Point(144, 64)
Me.cmdRic.Name = "cmdRic"
Me.cmdRic.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmdRic.Size = New System.Drawing.Size(22, 22)
Me.cmdRic.TabIndex = 6
Me.cmdRic.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me.cmdRic, "Aggiorna la temperatura di progetto in accordo al dato definito nelle Condizioni "& _ 
        "generali di progetto")
Me.cmdRic.UseVisualStyleBackColor = false
'
'_cmdGuarn1_0
'
Me._cmdGuarn1_0.BackColor = System.Drawing.SystemColors.Control
Me._cmdGuarn1_0.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdGuarn1_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdGuarn1_0.Image = CType(resources.GetObject("_cmdGuarn1_0.Image"),System.Drawing.Image)
Me._cmdGuarn1_0.Location = New System.Drawing.Point(256, 16)
Me._cmdGuarn1_0.Name = "_cmdGuarn1_0"
Me._cmdGuarn1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdGuarn1_0.Size = New System.Drawing.Size(22, 22)
Me._cmdGuarn1_0.TabIndex = 91
Me._cmdGuarn1_0.TabStop = false
Me._cmdGuarn1_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me._cmdGuarn1_0, "Richiama la libreria guarnizioni")
Me._cmdGuarn1_0.UseVisualStyleBackColor = false
'
'_cmdtir_0
'
Me._cmdtir_0.BackColor = System.Drawing.SystemColors.Control
Me._cmdtir_0.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdtir_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdtir_0.Image = CType(resources.GetObject("_cmdtir_0.Image"),System.Drawing.Image)
Me.cmdtir.SetIndex(Me._cmdtir_0, CType(0,Short))
Me._cmdtir_0.Location = New System.Drawing.Point(256, 16)
Me._cmdtir_0.Name = "_cmdtir_0"
Me._cmdtir_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdtir_0.Size = New System.Drawing.Size(22, 22)
Me._cmdtir_0.TabIndex = 443
Me._cmdtir_0.TabStop = false
Me._cmdtir_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me._cmdtir_0, "Richiama la libreria dei tiranti")
Me._cmdtir_0.UseVisualStyleBackColor = false
'
'_cmdGuarn1_1
'
Me._cmdGuarn1_1.BackColor = System.Drawing.SystemColors.Control
Me._cmdGuarn1_1.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdGuarn1_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdGuarn1_1.Image = CType(resources.GetObject("_cmdGuarn1_1.Image"),System.Drawing.Image)
Me._cmdGuarn1_1.Location = New System.Drawing.Point(256, 16)
Me._cmdGuarn1_1.Name = "_cmdGuarn1_1"
Me._cmdGuarn1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdGuarn1_1.Size = New System.Drawing.Size(22, 22)
Me._cmdGuarn1_1.TabIndex = 265
Me._cmdGuarn1_1.TabStop = false
Me._cmdGuarn1_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me._cmdGuarn1_1, "Richiama la libreria guarnizioni")
Me._cmdGuarn1_1.UseVisualStyleBackColor = false
'
'_cmdtir_2
'
Me._cmdtir_2.BackColor = System.Drawing.SystemColors.Control
Me._cmdtir_2.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdtir_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdtir_2.Image = CType(resources.GetObject("_cmdtir_2.Image"),System.Drawing.Image)
Me.cmdtir.SetIndex(Me._cmdtir_2, CType(2,Short))
Me._cmdtir_2.Location = New System.Drawing.Point(264, 16)
Me._cmdtir_2.Name = "_cmdtir_2"
Me._cmdtir_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdtir_2.Size = New System.Drawing.Size(22, 22)
Me._cmdtir_2.TabIndex = 445
Me._cmdtir_2.TabStop = false
Me._cmdtir_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me._cmdtir_2, "Richiama la libreria dei materiali")
Me._cmdtir_2.UseVisualStyleBackColor = false
'
'_cmdtir_1
'
Me._cmdtir_1.BackColor = System.Drawing.SystemColors.Control
Me._cmdtir_1.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdtir_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdtir_1.Image = CType(resources.GetObject("_cmdtir_1.Image"),System.Drawing.Image)
Me.cmdtir.SetIndex(Me._cmdtir_1, CType(1,Short))
Me._cmdtir_1.Location = New System.Drawing.Point(264, 16)
Me._cmdtir_1.Name = "_cmdtir_1"
Me._cmdtir_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdtir_1.Size = New System.Drawing.Size(22, 22)
Me._cmdtir_1.TabIndex = 444
Me._cmdtir_1.TabStop = false
Me._cmdtir_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me._cmdtir_1, "Richiama la libreria dei materiali")
Me._cmdtir_1.UseVisualStyleBackColor = false
'
'UpDownMat
'
Me.UpDownMat.Location = New System.Drawing.Point(228, 16)
Me.UpDownMat.Maximum = New Decimal(New Integer() {14, 0, 0, 0})
Me.UpDownMat.Name = "UpDownMat"
Me.UpDownMat.Size = New System.Drawing.Size(18, 20)
Me.UpDownMat.TabIndex = 36
Me.ToolTip1.SetToolTip(Me.UpDownMat, "Scorre le membratre in sequenza")
Me.UpDownMat.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'cmbMat
'
Me.cmbMat.BackColor = System.Drawing.SystemColors.Window
Me.cmbMat.Cursor = System.Windows.Forms.Cursors.Default
Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbMat.ForeColor = System.Drawing.SystemColors.WindowText
Me.cmbMat.Location = New System.Drawing.Point(8, 16)
Me.cmbMat.Name = "cmbMat"
Me.cmbMat.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmbMat.Size = New System.Drawing.Size(209, 21)
Me.cmbMat.TabIndex = 10
Me.ToolTip1.SetToolTip(Me.cmbMat, "Seleziona la membratura")
'
'cmdRicalcola
'
Me.cmdRicalcola.Location = New System.Drawing.Point(168, 200)
Me.cmdRicalcola.Name = "cmdRicalcola"
Me.cmdRicalcola.Size = New System.Drawing.Size(64, 24)
Me.cmdRicalcola.TabIndex = 37
Me.cmdRicalcola.Text = "Ricalcola"
Me.ToolTip1.SetToolTip(Me.cmdRicalcola, "Ricalola le caratteristiche dei materiali a partire dalla banca dati in corrispon"& _ 
        "denza del valore di temperatura indicato")
Me.cmdRicalcola.UseVisualStyleBackColor = true
'
'cmdRicalcRings
'
Me.cmdRicalcRings.Location = New System.Drawing.Point(240, 256)
Me.cmdRicalcRings.Name = "cmdRicalcRings"
Me.cmdRicalcRings.Size = New System.Drawing.Size(120, 24)
Me.cmdRicalcRings.TabIndex = 470
Me.cmdRicalcRings.Text = "Ricalcola i diametri"
Me.ToolTip1.SetToolTip(Me.cmdRicalcRings, "Ricalcola i diametri dei diversi membri a partire"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"dal diametro della cassa e dai"& _ 
        " valori standard"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"per diametri e spessori.")
Me.cmdRicalcRings.UseVisualStyleBackColor = true
'
'_Label_57
'
Me._Label_57.AutoSize = true
Me._Label_57.BackColor = System.Drawing.SystemColors.Control
Me._Label_57.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_57.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_57.Location = New System.Drawing.Point(8, 48)
Me._Label_57.Name = "_Label_57"
Me._Label_57.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_57.Size = New System.Drawing.Size(41, 13)
Me._Label_57.TabIndex = 230
Me._Label_57.Text = "Altezza"
Me.ToolTip1.SetToolTip(Me._Label_57, "da appoggio su PT a faccia inferiore flangia cassonetto")
'
'_Label_56
'
Me._Label_56.AutoSize = true
Me._Label_56.BackColor = System.Drawing.SystemColors.Control
Me._Label_56.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_56.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_56.Location = New System.Drawing.Point(8, 32)
Me._Label_56.Name = "_Label_56"
Me._Label_56.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_56.Size = New System.Drawing.Size(114, 13)
Me._Label_56.TabIndex = 227
Me._Label_56.Text = "Diametro medio minore"
Me.ToolTip1.SetToolTip(Me._Label_56, "Diametro fibra media del cassonetto alla sommità")
'
'_Label_55
'
Me._Label_55.AutoSize = true
Me._Label_55.BackColor = System.Drawing.SystemColors.Control
Me._Label_55.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_55.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_55.Location = New System.Drawing.Point(8, 16)
Me._Label_55.Name = "_Label_55"
Me._Label_55.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_55.Size = New System.Drawing.Size(126, 13)
Me._Label_55.TabIndex = 224
Me._Label_55.Text = "Diametro medio maggiore"
Me.ToolTip1.SetToolTip(Me._Label_55, "diametro fibra media del cassoneto alla sua base")
'
'cmdRicalcShell
'
Me.cmdRicalcShell.Location = New System.Drawing.Point(96, 248)
Me.cmdRicalcShell.Name = "cmdRicalcShell"
Me.cmdRicalcShell.Size = New System.Drawing.Size(120, 24)
Me.cmdRicalcShell.TabIndex = 471
Me.cmdRicalcShell.Text = "Ricalcola lo standard"
Me.ToolTip1.SetToolTip(Me.cmdRicalcShell, "Ricalcola il diametro esterno della parte attiva"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"in funzione del diametro del ma"& _ 
        "ntello e degli"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"altri valori dati.")
Me.cmdRicalcShell.UseVisualStyleBackColor = true
'
'cmdRicalcCassa
'
Me.cmdRicalcCassa.Location = New System.Drawing.Point(88, 248)
Me.cmdRicalcCassa.Name = "cmdRicalcCassa"
Me.cmdRicalcCassa.Size = New System.Drawing.Size(120, 24)
Me.cmdRicalcCassa.TabIndex = 472
Me.cmdRicalcCassa.Text = "Ricalcola lo standard"
Me.ToolTip1.SetToolTip(Me.cmdRicalcCassa, "Ricalcola il diametro esterno della parte attiva"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"in funzione del diametro del ma"& _ 
        "ntello e degli"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"altri valori dati.")
Me.cmdRicalcCassa.UseVisualStyleBackColor = true
'
'cmdRicalcCasson
'
Me.cmdRicalcCasson.Location = New System.Drawing.Point(88, 296)
Me.cmdRicalcCasson.Name = "cmdRicalcCasson"
Me.cmdRicalcCasson.Size = New System.Drawing.Size(120, 24)
Me.cmdRicalcCasson.TabIndex = 472
Me.cmdRicalcCasson.Text = "Ricalcola lo standard"
Me.ToolTip1.SetToolTip(Me.cmdRicalcCasson, "Ricalcola il diametro esterno della parte attiva"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"in funzione del diametro del ma"& _ 
        "ntello e degli"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"altri valori dati.")
Me.cmdRicalcCasson.UseVisualStyleBackColor = true
'
'chkSuperSafe
'
Me.chkSuperSafe.AutoSize = true
Me.chkSuperSafe.ForeColor = System.Drawing.Color.Black
Me.chkSuperSafe.Location = New System.Drawing.Point(8, 120)
Me.chkSuperSafe.Name = "chkSuperSafe"
Me.chkSuperSafe.Size = New System.Drawing.Size(171, 17)
Me.chkSuperSafe.TabIndex = 435
Me.chkSuperSafe.Text = "Condizione di perdita in Design"
Me.ToolTip1.SetToolTip(Me.chkSuperSafe, resources.GetString("chkSuperSafe.ToolTip"))
Me.chkSuperSafe.UseVisualStyleBackColor = true
'
'cmdEstensioneAutomatica
'
Me.cmdEstensioneAutomatica.BackColor = System.Drawing.SystemColors.Control
Me.cmdEstensioneAutomatica.Cursor = System.Windows.Forms.Cursors.Default
Me.cmdEstensioneAutomatica.ForeColor = System.Drawing.SystemColors.ControlText
Me.cmdEstensioneAutomatica.Image = CType(resources.GetObject("cmdEstensioneAutomatica.Image"),System.Drawing.Image)
Me.cmdEstensioneAutomatica.Location = New System.Drawing.Point(264, 60)
Me.cmdEstensioneAutomatica.Name = "cmdEstensioneAutomatica"
Me.cmdEstensioneAutomatica.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmdEstensioneAutomatica.Size = New System.Drawing.Size(22, 22)
Me.cmdEstensioneAutomatica.TabIndex = 468
Me.cmdEstensioneAutomatica.TabStop = false
Me.cmdEstensioneAutomatica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me.cmdEstensioneAutomatica, "Calcola automaticamente il valore ottimale"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"per la sezione resistente dell'estens"& _ 
        "ione.")
Me.cmdEstensioneAutomatica.UseVisualStyleBackColor = false
'
'cmdMinCasson
'
Me.cmdMinCasson.BackColor = System.Drawing.SystemColors.Control
Me.cmdMinCasson.Cursor = System.Windows.Forms.Cursors.Default
Me.cmdMinCasson.ForeColor = System.Drawing.SystemColors.ControlText
Me.cmdMinCasson.Image = CType(resources.GetObject("cmdMinCasson.Image"),System.Drawing.Image)
Me.cmdMinCasson.Location = New System.Drawing.Point(144, 62)
Me.cmdMinCasson.Name = "cmdMinCasson"
Me.cmdMinCasson.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmdMinCasson.Size = New System.Drawing.Size(22, 22)
Me.cmdMinCasson.TabIndex = 473
Me.cmdMinCasson.TabStop = false
Me.cmdMinCasson.TextAlign = System.Drawing.ContentAlignment.BottomCenter
Me.ToolTip1.SetToolTip(Me.cmdMinCasson, "Calcola lo spessore minimo")
Me.cmdMinCasson.UseVisualStyleBackColor = false
'
'rtLogo
'
Me.rtLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
Me.rtLogo.Location = New System.Drawing.Point(0, 600)
Me.rtLogo.MaxLength = 20000
Me.rtLogo.Name = "rtLogo"
Me.rtLogo.ReadOnly = true
Me.rtLogo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
Me.rtLogo.Size = New System.Drawing.Size(624, 462)
Me.rtLogo.TabIndex = 3
Me.rtLogo.Text = "RichTextBox1"
'
'Commento
'
Me.Commento.BackColor = System.Drawing.SystemColors.Control
Me.Commento.Controls.Add(Me.Labelcom1)
Me.Commento.ForeColor = System.Drawing.Color.Blue
Me.Commento.Location = New System.Drawing.Point(8, 432)
Me.Commento.Name = "Commento"
Me.Commento.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Commento.Size = New System.Drawing.Size(609, 73)
Me.Commento.TabIndex = 0
Me.Commento.TabStop = false
Me.Commento.Text = "Situazione del calcolo"
'
'Labelcom1
'
Me.Labelcom1.BackColor = System.Drawing.SystemColors.Control
Me.Labelcom1.Cursor = System.Windows.Forms.Cursors.Default
Me.Labelcom1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Labelcom1.ForeColor = System.Drawing.SystemColors.ControlText
Me.Labelcom1.Location = New System.Drawing.Point(8, 16)
Me.Labelcom1.Name = "Labelcom1"
Me.Labelcom1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Labelcom1.Size = New System.Drawing.Size(585, 49)
Me.Labelcom1.TabIndex = 1
'
'_pctFrames_0
'
Me._pctFrames_0.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_0.Controls.Add(Me.framNorme)
Me._pctFrames_0.Controls.Add(Me.cmdSel)
Me._pctFrames_0.Controls.Add(Me.cmbStampa)
Me._pctFrames_0.Controls.Add(Me.framDiff)
Me._pctFrames_0.Controls.Add(Me.framTipo)
Me._pctFrames_0.Controls.Add(Me.framPDiffHT)
Me._pctFrames_0.Controls.Add(Me.framMat)
Me._pctFrames_0.Controls.Add(Me.Label1)
Me._pctFrames_0.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_0.Location = New System.Drawing.Point(4, 2)
Me._pctFrames_0.Name = "_pctFrames_0"
Me._pctFrames_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_0.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_0.TabIndex = 4
Me._pctFrames_0.TabStop = true
'
'framNorme
'
Me.framNorme.BackColor = System.Drawing.SystemColors.Control
Me.framNorme.Controls.Add(Me.optdiv3)
Me.framNorme.Controls.Add(Me.optdiv1)
Me.framNorme.Controls.Add(Me.optdiv2)
Me.framNorme.ForeColor = System.Drawing.Color.Blue
Me.framNorme.Location = New System.Drawing.Point(16, 200)
Me.framNorme.Name = "framNorme"
Me.framNorme.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framNorme.Size = New System.Drawing.Size(121, 72)
Me.framNorme.TabIndex = 470
Me.framNorme.TabStop = false
Me.framNorme.Text = "Normativa"
'
'optdiv3
'
Me.optdiv3.BackColor = System.Drawing.SystemColors.Control
Me.optdiv3.Cursor = System.Windows.Forms.Cursors.Default
Me.optdiv3.Enabled = false
Me.optdiv3.ForeColor = System.Drawing.SystemColors.ControlText
Me.optdiv3.Location = New System.Drawing.Point(8, 48)
Me.optdiv3.Name = "optdiv3"
Me.optdiv3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.optdiv3.Size = New System.Drawing.Size(81, 17)
Me.optdiv3.TabIndex = 55
Me.optdiv3.TabStop = true
Me.optdiv3.Text = "Altro"
Me.optdiv3.UseVisualStyleBackColor = false
'
'optdiv1
'
Me.optdiv1.BackColor = System.Drawing.SystemColors.Control
Me.optdiv1.Checked = true
Me.optdiv1.Cursor = System.Windows.Forms.Cursors.Default
Me.optdiv1.ForeColor = System.Drawing.SystemColors.ControlText
Me.optdiv1.Location = New System.Drawing.Point(8, 16)
Me.optdiv1.Name = "optdiv1"
Me.optdiv1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.optdiv1.Size = New System.Drawing.Size(73, 17)
Me.optdiv1.TabIndex = 54
Me.optdiv1.TabStop = true
Me.optdiv1.Text = "div. 1"
Me.optdiv1.UseVisualStyleBackColor = false
'
'optdiv2
'
Me.optdiv2.BackColor = System.Drawing.SystemColors.Control
Me.optdiv2.Cursor = System.Windows.Forms.Cursors.Default
Me.optdiv2.ForeColor = System.Drawing.SystemColors.ControlText
Me.optdiv2.Location = New System.Drawing.Point(8, 32)
Me.optdiv2.Name = "optdiv2"
Me.optdiv2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.optdiv2.Size = New System.Drawing.Size(81, 17)
Me.optdiv2.TabIndex = 53
Me.optdiv2.TabStop = true
Me.optdiv2.Text = "div. 2"
Me.optdiv2.UseVisualStyleBackColor = false
'
'cmdSel
'
Me.cmdSel.Location = New System.Drawing.Point(296, 248)
Me.cmdSel.Name = "cmdSel"
Me.cmdSel.Size = New System.Drawing.Size(120, 24)
Me.cmdSel.TabIndex = 469
Me.cmdSel.Text = "Seleziona i materiali"
Me.cmdSel.UseVisualStyleBackColor = true
'
'cmbStampa
'
Me.cmbStampa.BackColor = System.Drawing.SystemColors.Window
Me.cmbStampa.Cursor = System.Windows.Forms.Cursors.Default
Me.cmbStampa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbStampa.ForeColor = System.Drawing.SystemColors.WindowText
Me.cmbStampa.Location = New System.Drawing.Point(128, 288)
Me.cmbStampa.Name = "cmbStampa"
Me.cmbStampa.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmbStampa.Size = New System.Drawing.Size(145, 21)
Me.cmbStampa.TabIndex = 467
'
'framDiff
'
Me.framDiff.BackColor = System.Drawing.SystemColors.Control
Me.framDiff.Controls.Add(Me._optDiff_1)
Me.framDiff.Controls.Add(Me._optDiff_0)
Me.framDiff.ForeColor = System.Drawing.Color.Blue
Me.framDiff.Location = New System.Drawing.Point(152, 144)
Me.framDiff.Name = "framDiff"
Me.framDiff.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framDiff.Size = New System.Drawing.Size(121, 57)
Me.framDiff.TabIndex = 55
Me.framDiff.TabStop = false
Me.framDiff.Text = "Differential pressure"
'
'_optDiff_1
'
Me._optDiff_1.BackColor = System.Drawing.SystemColors.Control
Me._optDiff_1.Cursor = System.Windows.Forms.Cursors.Default
Me._optDiff_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._optDiff_1.Location = New System.Drawing.Point(8, 32)
Me._optDiff_1.Name = "_optDiff_1"
Me._optDiff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optDiff_1.Size = New System.Drawing.Size(81, 17)
Me._optDiff_1.TabIndex = 57
Me._optDiff_1.TabStop = true
Me._optDiff_1.Text = "bilaterale"
Me._optDiff_1.UseVisualStyleBackColor = false
'
'_optDiff_0
'
Me._optDiff_0.BackColor = System.Drawing.SystemColors.Control
Me._optDiff_0.Checked = true
Me._optDiff_0.Cursor = System.Windows.Forms.Cursors.Default
Me._optDiff_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._optDiff_0.Location = New System.Drawing.Point(8, 16)
Me._optDiff_0.Name = "_optDiff_0"
Me._optDiff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optDiff_0.Size = New System.Drawing.Size(97, 17)
Me._optDiff_0.TabIndex = 56
Me._optDiff_0.TabStop = true
Me._optDiff_0.Text = "monolaterale"
Me._optDiff_0.UseVisualStyleBackColor = false
'
'framTipo
'
Me.framTipo.BackColor = System.Drawing.SystemColors.Control
Me.framTipo.Controls.Add(Me._optTipo_0)
Me.framTipo.Controls.Add(Me._optTipo_1)
Me.framTipo.ForeColor = System.Drawing.Color.Blue
Me.framTipo.Location = New System.Drawing.Point(16, 144)
Me.framTipo.Name = "framTipo"
Me.framTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framTipo.Size = New System.Drawing.Size(121, 57)
Me.framTipo.TabIndex = 52
Me.framTipo.TabStop = false
Me.framTipo.Text = "Tipo di Breech-Lock"
'
'_optTipo_0
'
Me._optTipo_0.BackColor = System.Drawing.SystemColors.Control
Me._optTipo_0.Checked = true
Me._optTipo_0.Cursor = System.Windows.Forms.Cursors.Default
Me._optTipo_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._optTipo_0.Location = New System.Drawing.Point(8, 16)
Me._optTipo_0.Name = "_optTipo_0"
Me._optTipo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optTipo_0.Size = New System.Drawing.Size(73, 17)
Me._optTipo_0.TabIndex = 54
Me._optTipo_0.TabStop = true
Me._optTipo_0.Text = "H-L Type"
Me._optTipo_0.UseVisualStyleBackColor = false
'
'_optTipo_1
'
Me._optTipo_1.BackColor = System.Drawing.SystemColors.Control
Me._optTipo_1.Cursor = System.Windows.Forms.Cursors.Default
Me._optTipo_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._optTipo_1.Location = New System.Drawing.Point(8, 32)
Me._optTipo_1.Name = "_optTipo_1"
Me._optTipo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optTipo_1.Size = New System.Drawing.Size(81, 17)
Me._optTipo_1.TabIndex = 53
Me._optTipo_1.TabStop = true
Me._optTipo_1.Text = "H-H Type"
Me._optTipo_1.UseVisualStyleBackColor = false
'
'framPDiffHT
'
Me.framPDiffHT.BackColor = System.Drawing.SystemColors.Control
Me.framPDiffHT.Controls.Add(Me._txtDes_0)
Me.framPDiffHT.Controls.Add(Me._lblMis_78)
Me.framPDiffHT.Controls.Add(Me._Label_92)
Me.framPDiffHT.Controls.Add(Me._lblMis_0)
Me.framPDiffHT.Controls.Add(Me._Label_0)
Me.framPDiffHT.Controls.Add(Me._lblMis_1)
Me.framPDiffHT.Controls.Add(Me._Label_1)
Me.framPDiffHT.Controls.Add(Me._Label_2)
Me.framPDiffHT.Controls.Add(Me._lblMis_3)
Me.framPDiffHT.Controls.Add(Me._Label_3)
Me.framPDiffHT.Controls.Add(Me._lblMis_2)
Me.framPDiffHT.Controls.Add(Me._Label_4)
Me.framPDiffHT.Controls.Add(Me._lblMis_4)
Me.framPDiffHT.Controls.Add(Me._txtDes_1)
Me.framPDiffHT.Controls.Add(Me._txtDes_2)
Me.framPDiffHT.Controls.Add(Me._txtDes_3)
Me.framPDiffHT.Controls.Add(Me._txtDes_4)
Me.framPDiffHT.Controls.Add(Me._txtDes_5)
Me.framPDiffHT.ForeColor = System.Drawing.Color.Blue
Me.framPDiffHT.Location = New System.Drawing.Point(8, 8)
Me.framPDiffHT.Name = "framPDiffHT"
Me.framPDiffHT.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framPDiffHT.Size = New System.Drawing.Size(289, 137)
Me.framPDiffHT.TabIndex = 36
Me.framPDiffHT.TabStop = false
Me.framPDiffHT.Text = "Condizioni di progetto"
'
'_txtDes_0
'
Me._txtDes_0.AcceptsReturn = true
Me._txtDes_0.BackColor = System.Drawing.Color.White
Me._txtDes_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtDes_0.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtDes.SetIndex(Me._txtDes_0, CType(0,Short))
Me._txtDes_0.Location = New System.Drawing.Point(168, 16)
Me._txtDes_0.MaxLength = 0
Me._txtDes_0.Name = "_txtDes_0"
Me._txtDes_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtDes_0.Size = New System.Drawing.Size(65, 20)
Me._txtDes_0.TabIndex = 41
Me._txtDes_0.Tag = "p"
'
'_lblMis_78
'
Me._lblMis_78.BackColor = System.Drawing.Color.Cyan
Me._lblMis_78.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_78.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_78.Location = New System.Drawing.Point(240, 96)
Me._lblMis_78.Name = "_lblMis_78"
Me._lblMis_78.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_78.Size = New System.Drawing.Size(40, 17)
Me._lblMis_78.TabIndex = 349
Me._lblMis_78.Text = "MPa"
'
'_Label_92
'
Me._Label_92.AutoSize = true
Me._Label_92.BackColor = System.Drawing.SystemColors.Control
Me._Label_92.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_92.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_92.Location = New System.Drawing.Point(8, 96)
Me._Label_92.Name = "_Label_92"
Me._Label_92.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_92.Size = New System.Drawing.Size(125, 13)
Me._Label_92.TabIndex = 348
Me._Label_92.Text = "Pressione di PI Lato Tubi"
'
'_lblMis_0
'
Me._lblMis_0.BackColor = System.Drawing.Color.Cyan
Me._lblMis_0.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_0.Location = New System.Drawing.Point(240, 16)
Me._lblMis_0.Name = "_lblMis_0"
Me._lblMis_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_0.Size = New System.Drawing.Size(40, 17)
Me._lblMis_0.TabIndex = 51
Me._lblMis_0.Text = "°C"
'
'_Label_0
'
Me._Label_0.AutoSize = true
Me._Label_0.BackColor = System.Drawing.SystemColors.Control
Me._Label_0.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_0.Location = New System.Drawing.Point(8, 16)
Me._Label_0.Name = "_Label_0"
Me._Label_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_0.Size = New System.Drawing.Size(134, 13)
Me._Label_0.TabIndex = 50
Me._Label_0.Text = "Temperatura Lato Mantello"
'
'_lblMis_1
'
Me._lblMis_1.BackColor = System.Drawing.Color.Cyan
Me._lblMis_1.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_1.Location = New System.Drawing.Point(240, 32)
Me._lblMis_1.Name = "_lblMis_1"
Me._lblMis_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_1.Size = New System.Drawing.Size(40, 17)
Me._lblMis_1.TabIndex = 49
Me._lblMis_1.Text = "MPa"
'
'_Label_1
'
Me._Label_1.AutoSize = true
Me._Label_1.BackColor = System.Drawing.SystemColors.Control
Me._Label_1.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_1.Location = New System.Drawing.Point(8, 32)
Me._Label_1.Name = "_Label_1"
Me._Label_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_1.Size = New System.Drawing.Size(120, 13)
Me._Label_1.TabIndex = 48
Me._Label_1.Text = "Pressione Lato Mantello"
'
'_Label_2
'
Me._Label_2.AutoSize = true
Me._Label_2.BackColor = System.Drawing.SystemColors.Control
Me._Label_2.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_2.Location = New System.Drawing.Point(8, 48)
Me._Label_2.Name = "_Label_2"
Me._Label_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_2.Size = New System.Drawing.Size(115, 13)
Me._Label_2.TabIndex = 47
Me._Label_2.Text = "Temperatura Lato Tubi"
'
'_lblMis_3
'
Me._lblMis_3.BackColor = System.Drawing.Color.Cyan
Me._lblMis_3.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_3.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_3.Location = New System.Drawing.Point(240, 64)
Me._lblMis_3.Name = "_lblMis_3"
Me._lblMis_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_3.Size = New System.Drawing.Size(40, 17)
Me._lblMis_3.TabIndex = 46
Me._lblMis_3.Text = "MPa"
'
'_Label_3
'
Me._Label_3.AutoSize = true
Me._Label_3.BackColor = System.Drawing.SystemColors.Control
Me._Label_3.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_3.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_3.Location = New System.Drawing.Point(8, 64)
Me._Label_3.Name = "_Label_3"
Me._Label_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_3.Size = New System.Drawing.Size(101, 13)
Me._Label_3.TabIndex = 45
Me._Label_3.Text = "Pressione Lato Tubi"
'
'_lblMis_2
'
Me._lblMis_2.BackColor = System.Drawing.Color.Cyan
Me._lblMis_2.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_2.Location = New System.Drawing.Point(240, 48)
Me._lblMis_2.Name = "_lblMis_2"
Me._lblMis_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_2.Size = New System.Drawing.Size(40, 17)
Me._lblMis_2.TabIndex = 44
Me._lblMis_2.Text = "°C"
'
'_Label_4
'
Me._Label_4.AutoSize = true
Me._Label_4.BackColor = System.Drawing.SystemColors.Control
Me._Label_4.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_4.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_4.Location = New System.Drawing.Point(8, 80)
Me._Label_4.Name = "_Label_4"
Me._Label_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_4.Size = New System.Drawing.Size(112, 13)
Me._Label_4.TabIndex = 43
Me._Label_4.Text = "Pressione differenziale"
'
'_lblMis_4
'
Me._lblMis_4.BackColor = System.Drawing.Color.Cyan
Me._lblMis_4.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_4.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_4.Location = New System.Drawing.Point(240, 80)
Me._lblMis_4.Name = "_lblMis_4"
Me._lblMis_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_4.Size = New System.Drawing.Size(40, 17)
Me._lblMis_4.TabIndex = 42
Me._lblMis_4.Text = "MPa"
'
'_txtDes_1
'
Me._txtDes_1.AcceptsReturn = true
Me._txtDes_1.BackColor = System.Drawing.Color.White
Me._txtDes_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtDes_1.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtDes.SetIndex(Me._txtDes_1, CType(1,Short))
Me._txtDes_1.Location = New System.Drawing.Point(168, 32)
Me._txtDes_1.MaxLength = 0
Me._txtDes_1.Name = "_txtDes_1"
Me._txtDes_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtDes_1.Size = New System.Drawing.Size(65, 20)
Me._txtDes_1.TabIndex = 40
Me._txtDes_1.TabStop = false
Me._txtDes_1.Tag = "f"
'
'_txtDes_2
'
Me._txtDes_2.AcceptsReturn = true
Me._txtDes_2.BackColor = System.Drawing.Color.White
Me._txtDes_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtDes_2.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtDes.SetIndex(Me._txtDes_2, CType(2,Short))
Me._txtDes_2.Location = New System.Drawing.Point(168, 48)
Me._txtDes_2.MaxLength = 0
Me._txtDes_2.Name = "_txtDes_2"
Me._txtDes_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtDes_2.Size = New System.Drawing.Size(65, 20)
Me._txtDes_2.TabIndex = 39
'
'_txtDes_3
'
Me._txtDes_3.AcceptsReturn = true
Me._txtDes_3.BackColor = System.Drawing.Color.White
Me._txtDes_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtDes_3.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtDes.SetIndex(Me._txtDes_3, CType(3,Short))
Me._txtDes_3.Location = New System.Drawing.Point(168, 64)
Me._txtDes_3.MaxLength = 0
Me._txtDes_3.Name = "_txtDes_3"
Me._txtDes_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtDes_3.Size = New System.Drawing.Size(65, 20)
Me._txtDes_3.TabIndex = 38
Me._txtDes_3.TabStop = false
Me._txtDes_3.Tag = "f"
'
'_txtDes_4
'
Me._txtDes_4.AcceptsReturn = true
Me._txtDes_4.BackColor = System.Drawing.Color.White
Me._txtDes_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtDes_4.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtDes.SetIndex(Me._txtDes_4, CType(4,Short))
Me._txtDes_4.Location = New System.Drawing.Point(168, 80)
Me._txtDes_4.MaxLength = 0
Me._txtDes_4.Name = "_txtDes_4"
Me._txtDes_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtDes_4.Size = New System.Drawing.Size(65, 20)
Me._txtDes_4.TabIndex = 37
Me._txtDes_4.TabStop = false
Me._txtDes_4.Tag = "f"
'
'_txtDes_5
'
Me._txtDes_5.AcceptsReturn = true
Me._txtDes_5.BackColor = System.Drawing.Color.White
Me._txtDes_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtDes_5.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtDes.SetIndex(Me._txtDes_5, CType(5,Short))
Me._txtDes_5.Location = New System.Drawing.Point(168, 96)
Me._txtDes_5.MaxLength = 0
Me._txtDes_5.Name = "_txtDes_5"
Me._txtDes_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtDes_5.Size = New System.Drawing.Size(65, 20)
Me._txtDes_5.TabIndex = 347
Me._txtDes_5.TabStop = false
Me._txtDes_5.Tag = "f"
'
'framMat
'
Me.framMat.BackColor = System.Drawing.SystemColors.Control
Me.framMat.Controls.Add(Me.cmdRicalcola)
Me.framMat.Controls.Add(Me.UpDownMat)
Me.framMat.Controls.Add(Me._txtMat_0)
Me.framMat.Controls.Add(Me._txtMat_1)
Me.framMat.Controls.Add(Me._txtMat_2)
Me.framMat.Controls.Add(Me._txtMat_3)
Me.framMat.Controls.Add(Me._txtMat_4)
Me.framMat.Controls.Add(Me._txtMat_5)
Me.framMat.Controls.Add(Me._txtMat_6)
Me.framMat.Controls.Add(Me._txtMat_7)
Me.framMat.Controls.Add(Me.cmbMat)
Me.framMat.Controls.Add(Me.cmdLibMat)
Me.framMat.Controls.Add(Me._txtMat_8)
Me.framMat.Controls.Add(Me.cmdRic)
Me.framMat.Controls.Add(Me._lblMat_3)
Me.framMat.Controls.Add(Me._lblMisMat_3)
Me.framMat.Controls.Add(Me._lblMat_2)
Me.framMat.Controls.Add(Me._lblMat_1)
Me.framMat.Controls.Add(Me._lblMisMat_1)
Me.framMat.Controls.Add(Me._lblMat_0)
Me.framMat.Controls.Add(Me._lblMisMat_0)
Me.framMat.Controls.Add(Me._lblMisMat_2)
Me.framMat.Controls.Add(Me._lblMat_4)
Me.framMat.Controls.Add(Me._lblMisMat_4)
Me.framMat.Controls.Add(Me._lblMat_5)
Me.framMat.Controls.Add(Me._lblMisMat_5)
Me.framMat.Controls.Add(Me._lblMat_6)
Me.framMat.Controls.Add(Me._lblMisMat_6)
Me.framMat.Controls.Add(Me._lblMat_7)
Me.framMat.Controls.Add(Me._lblMisMat_7)
Me.framMat.Controls.Add(Me._Label_8)
Me.framMat.ForeColor = System.Drawing.Color.Blue
Me.framMat.Location = New System.Drawing.Point(296, 8)
Me.framMat.Name = "framMat"
Me.framMat.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framMat.Size = New System.Drawing.Size(289, 232)
Me.framMat.TabIndex = 5
Me.framMat.TabStop = false
Me.framMat.Text = "Membrature"
'
'_txtMat_0
'
Me._txtMat_0.AcceptsReturn = true
Me._txtMat_0.BackColor = System.Drawing.Color.White
Me._txtMat_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_0.Location = New System.Drawing.Point(168, 64)
Me._txtMat_0.MaxLength = 0
Me._txtMat_0.Name = "_txtMat_0"
Me._txtMat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_0.Size = New System.Drawing.Size(65, 20)
Me._txtMat_0.TabIndex = 18
Me._txtMat_0.Tag = "p"
'
'_txtMat_1
'
Me._txtMat_1.AcceptsReturn = true
Me._txtMat_1.BackColor = System.Drawing.Color.White
Me._txtMat_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_1.Location = New System.Drawing.Point(168, 80)
Me._txtMat_1.MaxLength = 0
Me._txtMat_1.Name = "_txtMat_1"
Me._txtMat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_1.Size = New System.Drawing.Size(65, 20)
Me._txtMat_1.TabIndex = 17
Me._txtMat_1.TabStop = false
Me._txtMat_1.Tag = "f"
'
'_txtMat_2
'
Me._txtMat_2.AcceptsReturn = true
Me._txtMat_2.BackColor = System.Drawing.Color.White
Me._txtMat_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_2.Location = New System.Drawing.Point(168, 96)
Me._txtMat_2.MaxLength = 0
Me._txtMat_2.Name = "_txtMat_2"
Me._txtMat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_2.Size = New System.Drawing.Size(65, 20)
Me._txtMat_2.TabIndex = 16
'
'_txtMat_3
'
Me._txtMat_3.AcceptsReturn = true
Me._txtMat_3.BackColor = System.Drawing.Color.White
Me._txtMat_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_3.Location = New System.Drawing.Point(168, 112)
Me._txtMat_3.MaxLength = 0
Me._txtMat_3.Name = "_txtMat_3"
Me._txtMat_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_3.Size = New System.Drawing.Size(65, 20)
Me._txtMat_3.TabIndex = 15
Me._txtMat_3.TabStop = false
Me._txtMat_3.Tag = "f"
'
'_txtMat_4
'
Me._txtMat_4.AcceptsReturn = true
Me._txtMat_4.BackColor = System.Drawing.Color.White
Me._txtMat_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_4.Location = New System.Drawing.Point(168, 128)
Me._txtMat_4.MaxLength = 0
Me._txtMat_4.Name = "_txtMat_4"
Me._txtMat_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_4.Size = New System.Drawing.Size(65, 20)
Me._txtMat_4.TabIndex = 14
Me._txtMat_4.TabStop = false
Me._txtMat_4.Tag = "f"
'
'_txtMat_5
'
Me._txtMat_5.AcceptsReturn = true
Me._txtMat_5.BackColor = System.Drawing.Color.White
Me._txtMat_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_5.Location = New System.Drawing.Point(168, 144)
Me._txtMat_5.MaxLength = 0
Me._txtMat_5.Name = "_txtMat_5"
Me._txtMat_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_5.Size = New System.Drawing.Size(65, 20)
Me._txtMat_5.TabIndex = 13
Me._txtMat_5.TabStop = false
Me._txtMat_5.Tag = "f"
'
'_txtMat_6
'
Me._txtMat_6.AcceptsReturn = true
Me._txtMat_6.BackColor = System.Drawing.Color.White
Me._txtMat_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_6.Location = New System.Drawing.Point(168, 160)
Me._txtMat_6.MaxLength = 0
Me._txtMat_6.Name = "_txtMat_6"
Me._txtMat_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_6.Size = New System.Drawing.Size(65, 20)
Me._txtMat_6.TabIndex = 12
Me._txtMat_6.TabStop = false
Me._txtMat_6.Tag = "f"
'
'_txtMat_7
'
Me._txtMat_7.AcceptsReturn = true
Me._txtMat_7.BackColor = System.Drawing.Color.White
Me._txtMat_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_7.Location = New System.Drawing.Point(168, 176)
Me._txtMat_7.MaxLength = 0
Me._txtMat_7.Name = "_txtMat_7"
Me._txtMat_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_7.Size = New System.Drawing.Size(65, 20)
Me._txtMat_7.TabIndex = 11
Me._txtMat_7.TabStop = false
Me._txtMat_7.Tag = "f"
'
'_txtMat_8
'
Me._txtMat_8.AcceptsReturn = true
Me._txtMat_8.BackColor = System.Drawing.Color.White
Me._txtMat_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtMat_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtMat_8.Location = New System.Drawing.Point(88, 40)
Me._txtMat_8.MaxLength = 0
Me._txtMat_8.Name = "_txtMat_8"
Me._txtMat_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtMat_8.Size = New System.Drawing.Size(193, 20)
Me._txtMat_8.TabIndex = 7
Me._txtMat_8.Tag = "p"
'
'_lblMat_3
'
Me._lblMat_3.AutoSize = true
Me._lblMat_3.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_3.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_3.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_3.Location = New System.Drawing.Point(8, 112)
Me._lblMat_3.Name = "_lblMat_3"
Me._lblMat_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_3.Size = New System.Drawing.Size(140, 13)
Me._lblMat_3.TabIndex = 35
Me._lblMat_3.Text = "Snervamento in temperatura"
'
'_lblMisMat_3
'
Me._lblMisMat_3.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_3.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_3.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_3.Location = New System.Drawing.Point(240, 112)
Me._lblMisMat_3.Name = "_lblMisMat_3"
Me._lblMisMat_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_3.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_3.TabIndex = 34
Me._lblMisMat_3.Text = "MPa"
'
'_lblMat_2
'
Me._lblMat_2.AutoSize = true
Me._lblMat_2.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_2.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_2.Location = New System.Drawing.Point(8, 96)
Me._lblMat_2.Name = "_lblMat_2"
Me._lblMat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_2.Size = New System.Drawing.Size(102, 13)
Me._lblMat_2.TabIndex = 33
Me._lblMat_2.Text = "Ammissibile a freddo"
'
'_lblMat_1
'
Me._lblMat_1.AutoSize = true
Me._lblMat_1.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_1.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_1.Location = New System.Drawing.Point(8, 80)
Me._lblMat_1.Name = "_lblMat_1"
Me._lblMat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_1.Size = New System.Drawing.Size(130, 13)
Me._lblMat_1.TabIndex = 32
Me._lblMat_1.Text = "Ammissibile in temperatura"
'
'_lblMisMat_1
'
Me._lblMisMat_1.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_1.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_1.Location = New System.Drawing.Point(240, 80)
Me._lblMisMat_1.Name = "_lblMisMat_1"
Me._lblMisMat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_1.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_1.TabIndex = 31
Me._lblMisMat_1.Text = "MPa"
'
'_lblMat_0
'
Me._lblMat_0.AutoSize = true
Me._lblMat_0.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_0.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_0.Location = New System.Drawing.Point(8, 64)
Me._lblMat_0.Name = "_lblMat_0"
Me._lblMat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_0.Size = New System.Drawing.Size(120, 13)
Me._lblMat_0.TabIndex = 30
Me._lblMat_0.Text = "Temperatura di progetto"
'
'_lblMisMat_0
'
Me._lblMisMat_0.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_0.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_0.Location = New System.Drawing.Point(240, 64)
Me._lblMisMat_0.Name = "_lblMisMat_0"
Me._lblMisMat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_0.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_0.TabIndex = 29
Me._lblMisMat_0.Text = "°C"
'
'_lblMisMat_2
'
Me._lblMisMat_2.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_2.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_2.Location = New System.Drawing.Point(240, 96)
Me._lblMisMat_2.Name = "_lblMisMat_2"
Me._lblMisMat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_2.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_2.TabIndex = 28
Me._lblMisMat_2.Text = "MPa"
'
'_lblMat_4
'
Me._lblMat_4.AutoSize = true
Me._lblMat_4.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_4.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_4.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_4.Location = New System.Drawing.Point(8, 128)
Me._lblMat_4.Name = "_lblMat_4"
Me._lblMat_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_4.Size = New System.Drawing.Size(112, 13)
Me._lblMat_4.TabIndex = 27
Me._lblMat_4.Text = "Snervamento a freddo"
'
'_lblMisMat_4
'
Me._lblMisMat_4.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_4.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_4.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_4.Location = New System.Drawing.Point(240, 128)
Me._lblMisMat_4.Name = "_lblMisMat_4"
Me._lblMisMat_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_4.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_4.TabIndex = 26
Me._lblMisMat_4.Text = "MPa"
'
'_lblMat_5
'
Me._lblMat_5.AutoSize = true
Me._lblMat_5.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_5.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_5.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_5.Location = New System.Drawing.Point(8, 144)
Me._lblMat_5.Name = "_lblMat_5"
Me._lblMat_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_5.Size = New System.Drawing.Size(157, 13)
Me._lblMat_5.TabIndex = 25
Me._lblMat_5.Text = "Modulo di Young in temperatura"
'
'_lblMisMat_5
'
Me._lblMisMat_5.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_5.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_5.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_5.Location = New System.Drawing.Point(240, 144)
Me._lblMisMat_5.Name = "_lblMisMat_5"
Me._lblMisMat_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_5.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_5.TabIndex = 24
Me._lblMisMat_5.Text = "MPa"
'
'_lblMat_6
'
Me._lblMat_6.AutoSize = true
Me._lblMat_6.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_6.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_6.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_6.Location = New System.Drawing.Point(8, 160)
Me._lblMat_6.Name = "_lblMat_6"
Me._lblMat_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_6.Size = New System.Drawing.Size(129, 13)
Me._lblMat_6.TabIndex = 23
Me._lblMat_6.Text = "Modulo di Young a freddo"
'
'_lblMisMat_6
'
Me._lblMisMat_6.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_6.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_6.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_6.Location = New System.Drawing.Point(240, 160)
Me._lblMisMat_6.Name = "_lblMisMat_6"
Me._lblMisMat_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_6.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_6.TabIndex = 22
Me._lblMisMat_6.Text = "MPa"
'
'_lblMat_7
'
Me._lblMat_7.AutoSize = true
Me._lblMat_7.BackColor = System.Drawing.SystemColors.Control
Me._lblMat_7.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMat_7.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMat_7.Location = New System.Drawing.Point(8, 176)
Me._lblMat_7.Name = "_lblMat_7"
Me._lblMat_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMat_7.Size = New System.Drawing.Size(136, 13)
Me._lblMat_7.TabIndex = 21
Me._lblMat_7.Text = "Coefficiente dilataz. termica"
'
'_lblMisMat_7
'
Me._lblMisMat_7.BackColor = System.Drawing.Color.Cyan
Me._lblMisMat_7.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMisMat_7.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMisMat_7.Location = New System.Drawing.Point(240, 176)
Me._lblMisMat_7.Name = "_lblMisMat_7"
Me._lblMisMat_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMisMat_7.Size = New System.Drawing.Size(40, 17)
Me._lblMisMat_7.TabIndex = 20
Me._lblMisMat_7.Text = "1/°C"
'
'_Label_8
'
Me._Label_8.AutoSize = true
Me._Label_8.BackColor = System.Drawing.SystemColors.Control
Me._Label_8.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_8.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_8.Location = New System.Drawing.Point(8, 40)
Me._Label_8.Name = "_Label_8"
Me._Label_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_8.Size = New System.Drawing.Size(50, 13)
Me._Label_8.TabIndex = 19
Me._Label_8.Text = "Materiale"
'
'Label1
'
Me.Label1.BackColor = System.Drawing.SystemColors.Control
Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label1.Location = New System.Drawing.Point(16, 288)
Me.Label1.Name = "Label1"
Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label1.Size = New System.Drawing.Size(105, 25)
Me.Label1.TabIndex = 468
Me.Label1.Text = "Tipo di stampa"
'
'_pctFrames_1
'
Me._pctFrames_1.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_1.Controls.Add(Me._cmdCalc_1)
Me._pctFrames_1.Controls.Add(Me.framHead)
Me._pctFrames_1.Controls.Add(Me.framGsk1)
Me._pctFrames_1.Controls.Add(Me.framShell)
Me._pctFrames_1.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_1.Location = New System.Drawing.Point(4, 2)
Me._pctFrames_1.Name = "_pctFrames_1"
Me._pctFrames_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_1.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_1.TabIndex = 59
Me._pctFrames_1.TabStop = true
'
'_cmdCalc_1
'
Me._cmdCalc_1.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_1.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_1.Location = New System.Drawing.Point(520, 296)
Me._cmdCalc_1.Name = "_cmdCalc_1"
Me._cmdCalc_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_1.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_1.TabIndex = 112
Me._cmdCalc_1.Text = "Calcola"
Me._cmdCalc_1.UseVisualStyleBackColor = false
'
'framHead
'
Me.framHead.BackColor = System.Drawing.SystemColors.Control
Me.framHead.Controls.Add(Me.chkNonCalcolaFondo)
Me.framHead.Controls.Add(Me._txtShell_15)
Me.framHead.Controls.Add(Me._txtShell_14)
Me.framHead.Controls.Add(Me._txtShell_13)
Me.framHead.Controls.Add(Me._txtShell_12)
Me.framHead.Controls.Add(Me._Label_24)
Me.framHead.Controls.Add(Me._lblMis_16)
Me.framHead.Controls.Add(Me._Label_23)
Me.framHead.Controls.Add(Me._lblMis_15)
Me.framHead.Controls.Add(Me._Label_22)
Me.framHead.Controls.Add(Me._lblMis_14)
Me.framHead.Controls.Add(Me._Label_21)
Me.framHead.Controls.Add(Me._lblMis_13)
Me.framHead.ForeColor = System.Drawing.Color.Blue
Me.framHead.Location = New System.Drawing.Point(8, 104)
Me.framHead.Name = "framHead"
Me.framHead.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framHead.Size = New System.Drawing.Size(289, 112)
Me.framHead.TabIndex = 99
Me.framHead.TabStop = false
Me.framHead.Text = "Fondo"
'
'chkNonCalcolaFondo
'
Me.chkNonCalcolaFondo.AutoSize = true
Me.chkNonCalcolaFondo.Location = New System.Drawing.Point(8, 88)
Me.chkNonCalcolaFondo.Name = "chkNonCalcolaFondo"
Me.chkNonCalcolaFondo.Size = New System.Drawing.Size(245, 17)
Me.chkNonCalcolaFondo.TabIndex = 112
Me.chkNonCalcolaFondo.Text = "Non è richiesto il calcolo di questa membratura"
Me.chkNonCalcolaFondo.UseVisualStyleBackColor = true
'
'_txtShell_15
'
Me._txtShell_15.AcceptsReturn = true
Me._txtShell_15.BackColor = System.Drawing.Color.White
Me._txtShell_15.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_15.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_15.Location = New System.Drawing.Point(168, 16)
Me._txtShell_15.MaxLength = 0
Me._txtShell_15.Name = "_txtShell_15"
Me._txtShell_15.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_15.Size = New System.Drawing.Size(65, 20)
Me._txtShell_15.TabIndex = 103
Me._txtShell_15.Tag = "p"
'
'_txtShell_14
'
Me._txtShell_14.AcceptsReturn = true
Me._txtShell_14.BackColor = System.Drawing.Color.White
Me._txtShell_14.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_14.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_14.Location = New System.Drawing.Point(168, 32)
Me._txtShell_14.MaxLength = 0
Me._txtShell_14.Name = "_txtShell_14"
Me._txtShell_14.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_14.Size = New System.Drawing.Size(65, 20)
Me._txtShell_14.TabIndex = 102
Me._txtShell_14.Tag = "p"
'
'_txtShell_13
'
Me._txtShell_13.AcceptsReturn = true
Me._txtShell_13.BackColor = System.Drawing.Color.Yellow
Me._txtShell_13.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_13.Enabled = false
Me._txtShell_13.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_13.Location = New System.Drawing.Point(168, 48)
Me._txtShell_13.MaxLength = 0
Me._txtShell_13.Name = "_txtShell_13"
Me._txtShell_13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_13.Size = New System.Drawing.Size(65, 20)
Me._txtShell_13.TabIndex = 101
Me._txtShell_13.Tag = "p"
'
'_txtShell_12
'
Me._txtShell_12.AcceptsReturn = true
Me._txtShell_12.BackColor = System.Drawing.Color.White
Me._txtShell_12.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_12.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_12.Location = New System.Drawing.Point(168, 64)
Me._txtShell_12.MaxLength = 0
Me._txtShell_12.Name = "_txtShell_12"
Me._txtShell_12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_12.Size = New System.Drawing.Size(65, 20)
Me._txtShell_12.TabIndex = 100
Me._txtShell_12.Tag = "p"
'
'_Label_24
'
Me._Label_24.AutoSize = true
Me._Label_24.BackColor = System.Drawing.SystemColors.Control
Me._Label_24.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_24.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_24.Location = New System.Drawing.Point(8, 16)
Me._Label_24.Name = "_Label_24"
Me._Label_24.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_24.Size = New System.Drawing.Size(106, 13)
Me._Label_24.TabIndex = 111
Me._Label_24.Text = "Raggio interno fondo"
'
'_lblMis_16
'
Me._lblMis_16.BackColor = System.Drawing.Color.Cyan
Me._lblMis_16.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_16.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_16.Location = New System.Drawing.Point(240, 16)
Me._lblMis_16.Name = "_lblMis_16"
Me._lblMis_16.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_16.Size = New System.Drawing.Size(40, 17)
Me._lblMis_16.TabIndex = 110
Me._lblMis_16.Text = "mm"
'
'_Label_23
'
Me._Label_23.AutoSize = true
Me._Label_23.BackColor = System.Drawing.SystemColors.Control
Me._Label_23.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_23.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_23.Location = New System.Drawing.Point(8, 32)
Me._Label_23.Name = "_Label_23"
Me._Label_23.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_23.Size = New System.Drawing.Size(89, 13)
Me._Label_23.TabIndex = 109
Me._Label_23.Text = "Corrosione o clad"
'
'_lblMis_15
'
Me._lblMis_15.BackColor = System.Drawing.Color.Cyan
Me._lblMis_15.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_15.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_15.Location = New System.Drawing.Point(240, 32)
Me._lblMis_15.Name = "_lblMis_15"
Me._lblMis_15.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_15.Size = New System.Drawing.Size(40, 17)
Me._lblMis_15.TabIndex = 108
Me._lblMis_15.Text = "mm"
'
'_Label_22
'
Me._Label_22.AutoSize = true
Me._Label_22.BackColor = System.Drawing.SystemColors.Control
Me._Label_22.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_22.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_22.Location = New System.Drawing.Point(8, 48)
Me._Label_22.Name = "_Label_22"
Me._Label_22.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_22.Size = New System.Drawing.Size(134, 13)
Me._Label_22.TabIndex = 107
Me._Label_22.Text = "Spessore minimo di calcolo"
'
'_lblMis_14
'
Me._lblMis_14.BackColor = System.Drawing.Color.Cyan
Me._lblMis_14.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_14.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_14.Location = New System.Drawing.Point(240, 48)
Me._lblMis_14.Name = "_lblMis_14"
Me._lblMis_14.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_14.Size = New System.Drawing.Size(40, 17)
Me._lblMis_14.TabIndex = 106
Me._lblMis_14.Text = "mm"
'
'_Label_21
'
Me._Label_21.AutoSize = true
Me._Label_21.BackColor = System.Drawing.SystemColors.Control
Me._Label_21.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_21.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_21.Location = New System.Drawing.Point(8, 64)
Me._Label_21.Name = "_Label_21"
Me._Label_21.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_21.Size = New System.Drawing.Size(93, 13)
Me._Label_21.TabIndex = 105
Me._Label_21.Text = "Spessore adottato"
'
'_lblMis_13
'
Me._lblMis_13.BackColor = System.Drawing.Color.Cyan
Me._lblMis_13.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_13.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_13.Location = New System.Drawing.Point(240, 64)
Me._lblMis_13.Name = "_lblMis_13"
Me._lblMis_13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_13.Size = New System.Drawing.Size(40, 17)
Me._lblMis_13.TabIndex = 104
Me._lblMis_13.Text = "mm"
'
'framGsk1
'
Me.framGsk1.BackColor = System.Drawing.SystemColors.Control
Me.framGsk1.Controls.Add(Me._txtShell_18)
Me.framGsk1.Controls.Add(Me._txtShell_2)
Me.framGsk1.Controls.Add(Me._txtShell_4)
Me.framGsk1.Controls.Add(Me._txtShell_5)
Me.framGsk1.Controls.Add(Me._txtShell_6)
Me.framGsk1.Controls.Add(Me._txtShell_7)
Me.framGsk1.Controls.Add(Me.Label8)
Me.framGsk1.Controls.Add(Me.Label9)
Me.framGsk1.Controls.Add(Me.cmdRicalcShell)
Me.framGsk1.Controls.Add(Me._txtShell_17)
Me.framGsk1.Controls.Add(Me.Label5)
Me.framGsk1.Controls.Add(Me.chkAnelloEst)
Me.framGsk1.Controls.Add(Me._txtShell_16)
Me.framGsk1.Controls.Add(Me.Label4)
Me.framGsk1.Controls.Add(Me.chkAnelloInt)
Me.framGsk1.Controls.Add(Me._cmdGuarn1_0)
Me.framGsk1.Controls.Add(Me._txtShell_9)
Me.framGsk1.Controls.Add(Me._txtShell_8)
Me.framGsk1.Controls.Add(Me._txtShell_3)
Me.framGsk1.Controls.Add(Me._Label_18)
Me.framGsk1.Controls.Add(Me._lblMis_10)
Me.framGsk1.Controls.Add(Me._Label_17)
Me.framGsk1.Controls.Add(Me._lblMis_9)
Me.framGsk1.Controls.Add(Me._Label_16)
Me.framGsk1.Controls.Add(Me._lblMis_8)
Me.framGsk1.Controls.Add(Me._Label_15)
Me.framGsk1.Controls.Add(Me._Label_14)
Me.framGsk1.Controls.Add(Me._lblMis_7)
Me.framGsk1.Controls.Add(Me._Label_13)
Me.framGsk1.Controls.Add(Me._lblMis_6)
Me.framGsk1.Controls.Add(Me._Label_11)
Me.framGsk1.Controls.Add(Me._Label_9)
Me.framGsk1.Controls.Add(Me._lblMis_5)
Me.framGsk1.ForeColor = System.Drawing.Color.Blue
Me.framGsk1.Location = New System.Drawing.Point(296, 8)
Me.framGsk1.Name = "framGsk1"
Me.framGsk1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framGsk1.Size = New System.Drawing.Size(289, 280)
Me.framGsk1.TabIndex = 68
Me.framGsk1.TabStop = false
Me.framGsk1.Text = "Guarnizione P.T."
'
'_txtShell_18
'
Me._txtShell_18.AcceptsReturn = true
Me._txtShell_18.BackColor = System.Drawing.Color.White
Me._txtShell_18.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_18.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_18.Location = New System.Drawing.Point(168, 48)
Me._txtShell_18.MaxLength = 0
Me._txtShell_18.Name = "_txtShell_18"
Me._txtShell_18.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_18.Size = New System.Drawing.Size(65, 20)
Me._txtShell_18.TabIndex = 472
Me._txtShell_18.Tag = "p"
'
'_txtShell_2
'
Me._txtShell_2.AcceptsReturn = true
Me._txtShell_2.BackColor = System.Drawing.Color.White
Me._txtShell_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_2.Location = New System.Drawing.Point(168, 64)
Me._txtShell_2.MaxLength = 0
Me._txtShell_2.Name = "_txtShell_2"
Me._txtShell_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_2.Size = New System.Drawing.Size(65, 20)
Me._txtShell_2.TabIndex = 69
Me._txtShell_2.Tag = "p"
'
'_txtShell_4
'
Me._txtShell_4.AcceptsReturn = true
Me._txtShell_4.BackColor = System.Drawing.Color.White
Me._txtShell_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_4.Location = New System.Drawing.Point(168, 80)
Me._txtShell_4.MaxLength = 0
Me._txtShell_4.Name = "_txtShell_4"
Me._txtShell_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_4.Size = New System.Drawing.Size(65, 20)
Me._txtShell_4.TabIndex = 74
Me._txtShell_4.Tag = "p"
'
'_txtShell_5
'
Me._txtShell_5.AcceptsReturn = true
Me._txtShell_5.BackColor = System.Drawing.Color.White
Me._txtShell_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_5.Location = New System.Drawing.Point(168, 96)
Me._txtShell_5.MaxLength = 0
Me._txtShell_5.Name = "_txtShell_5"
Me._txtShell_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_5.Size = New System.Drawing.Size(65, 20)
Me._txtShell_5.TabIndex = 77
Me._txtShell_5.Tag = "p"
'
'_txtShell_6
'
Me._txtShell_6.AcceptsReturn = true
Me._txtShell_6.BackColor = System.Drawing.Color.White
Me._txtShell_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_6.Location = New System.Drawing.Point(168, 112)
Me._txtShell_6.MaxLength = 0
Me._txtShell_6.Name = "_txtShell_6"
Me._txtShell_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_6.Size = New System.Drawing.Size(65, 20)
Me._txtShell_6.TabIndex = 80
Me._txtShell_6.Tag = "p"
'
'_txtShell_7
'
Me._txtShell_7.AcceptsReturn = true
Me._txtShell_7.BackColor = System.Drawing.Color.White
Me._txtShell_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_7.Location = New System.Drawing.Point(168, 128)
Me._txtShell_7.MaxLength = 0
Me._txtShell_7.Name = "_txtShell_7"
Me._txtShell_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_7.Size = New System.Drawing.Size(65, 20)
Me._txtShell_7.TabIndex = 82
Me._txtShell_7.Tag = "p"
'
'Label8
'
Me.Label8.AutoSize = true
Me.Label8.BackColor = System.Drawing.SystemColors.Control
Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label8.Location = New System.Drawing.Point(8, 48)
Me.Label8.Name = "Label8"
Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label8.Size = New System.Drawing.Size(146, 13)
Me.Label8.TabIndex = 474
Me.Label8.Text = "Largh.dente cava lato interno"
'
'Label9
'
Me.Label9.BackColor = System.Drawing.Color.Cyan
Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label9.Location = New System.Drawing.Point(240, 48)
Me.Label9.Name = "Label9"
Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label9.Size = New System.Drawing.Size(40, 17)
Me.Label9.TabIndex = 473
Me.Label9.Text = "mm"
'
'_txtShell_17
'
Me._txtShell_17.AcceptsReturn = true
Me._txtShell_17.BackColor = System.Drawing.Color.White
Me._txtShell_17.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_17.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_17.Location = New System.Drawing.Point(168, 192)
Me._txtShell_17.MaxLength = 0
Me._txtShell_17.Name = "_txtShell_17"
Me._txtShell_17.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_17.Size = New System.Drawing.Size(65, 20)
Me._txtShell_17.TabIndex = 96
Me._txtShell_17.Tag = "p"
Me._txtShell_17.Visible = false
'
'Label5
'
Me.Label5.BackColor = System.Drawing.Color.Cyan
Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label5.Location = New System.Drawing.Point(240, 192)
Me.Label5.Name = "Label5"
Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label5.Size = New System.Drawing.Size(40, 17)
Me.Label5.TabIndex = 97
Me.Label5.Text = "mm"
Me.Label5.Visible = false
'
'chkAnelloEst
'
Me.chkAnelloEst.AutoSize = true
Me.chkAnelloEst.ForeColor = System.Drawing.Color.Black
Me.chkAnelloEst.Location = New System.Drawing.Point(16, 192)
Me.chkAnelloEst.Name = "chkAnelloEst"
Me.chkAnelloEst.Size = New System.Drawing.Size(144, 17)
Me.chkAnelloEst.TabIndex = 95
Me.chkAnelloEst.Text = "Anello esterno: larghezza"
Me.chkAnelloEst.UseVisualStyleBackColor = true
'
'_txtShell_16
'
Me._txtShell_16.AcceptsReturn = true
Me._txtShell_16.BackColor = System.Drawing.Color.White
Me._txtShell_16.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_16.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_16.Location = New System.Drawing.Point(168, 168)
Me._txtShell_16.MaxLength = 0
Me._txtShell_16.Name = "_txtShell_16"
Me._txtShell_16.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_16.Size = New System.Drawing.Size(65, 20)
Me._txtShell_16.TabIndex = 93
Me._txtShell_16.Tag = "p"
Me._txtShell_16.Visible = false
'
'Label4
'
Me.Label4.BackColor = System.Drawing.Color.Cyan
Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label4.Location = New System.Drawing.Point(240, 168)
Me.Label4.Name = "Label4"
Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label4.Size = New System.Drawing.Size(40, 17)
Me.Label4.TabIndex = 94
Me.Label4.Text = "mm"
Me.Label4.Visible = false
'
'chkAnelloInt
'
Me.chkAnelloInt.AutoSize = true
Me.chkAnelloInt.ForeColor = System.Drawing.Color.Black
Me.chkAnelloInt.Location = New System.Drawing.Point(16, 168)
Me.chkAnelloInt.Name = "chkAnelloInt"
Me.chkAnelloInt.Size = New System.Drawing.Size(141, 17)
Me.chkAnelloInt.TabIndex = 92
Me.chkAnelloInt.Text = "Anello interno: larghezza"
Me.chkAnelloInt.UseVisualStyleBackColor = true
'
'_txtShell_9
'
Me._txtShell_9.AcceptsReturn = true
Me._txtShell_9.BackColor = System.Drawing.Color.Yellow
Me._txtShell_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_9.Enabled = false
Me._txtShell_9.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_9.Location = New System.Drawing.Point(168, 224)
Me._txtShell_9.MaxLength = 0
Me._txtShell_9.Name = "_txtShell_9"
Me._txtShell_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_9.Size = New System.Drawing.Size(65, 20)
Me._txtShell_9.TabIndex = 88
Me._txtShell_9.Tag = "p"
'
'_txtShell_8
'
Me._txtShell_8.AcceptsReturn = true
Me._txtShell_8.BackColor = System.Drawing.Color.White
Me._txtShell_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_8.Location = New System.Drawing.Point(168, 144)
Me._txtShell_8.MaxLength = 0
Me._txtShell_8.Name = "_txtShell_8"
Me._txtShell_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_8.Size = New System.Drawing.Size(65, 20)
Me._txtShell_8.TabIndex = 85
Me._txtShell_8.Tag = "p"
'
'_txtShell_3
'
Me._txtShell_3.AcceptsReturn = true
Me._txtShell_3.BackColor = System.Drawing.Color.White
Me._txtShell_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_3.Location = New System.Drawing.Point(96, 16)
Me._txtShell_3.MaxLength = 0
Me._txtShell_3.Name = "_txtShell_3"
Me._txtShell_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_3.Size = New System.Drawing.Size(161, 20)
Me._txtShell_3.TabIndex = 70
Me._txtShell_3.Tag = "p"
'
'_Label_18
'
Me._Label_18.AutoSize = true
Me._Label_18.BackColor = System.Drawing.SystemColors.Control
Me._Label_18.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_18.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_18.Location = New System.Drawing.Point(8, 224)
Me._Label_18.Name = "_Label_18"
Me._Label_18.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_18.Size = New System.Drawing.Size(100, 13)
Me._Label_18.TabIndex = 90
Me._Label_18.Text = "Ampiezza di calcolo"
'
'_lblMis_10
'
Me._lblMis_10.BackColor = System.Drawing.Color.Cyan
Me._lblMis_10.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_10.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_10.Location = New System.Drawing.Point(240, 224)
Me._lblMis_10.Name = "_lblMis_10"
Me._lblMis_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_10.Size = New System.Drawing.Size(40, 17)
Me._lblMis_10.TabIndex = 89
Me._lblMis_10.Text = "mm"
'
'_Label_17
'
Me._Label_17.AutoSize = true
Me._Label_17.BackColor = System.Drawing.SystemColors.Control
Me._Label_17.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_17.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_17.Location = New System.Drawing.Point(8, 144)
Me._Label_17.Name = "_Label_17"
Me._Label_17.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_17.Size = New System.Drawing.Size(44, 13)
Me._Label_17.TabIndex = 87
Me._Label_17.Text = "Formula"
'
'_lblMis_9
'
Me._lblMis_9.BackColor = System.Drawing.Color.Cyan
Me._lblMis_9.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_9.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_9.Location = New System.Drawing.Point(240, 144)
Me._lblMis_9.Name = "_lblMis_9"
Me._lblMis_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_9.Size = New System.Drawing.Size(40, 17)
Me._lblMis_9.TabIndex = 86
Me._lblMis_9.Text = "mm"
'
'_Label_16
'
Me._Label_16.AutoSize = true
Me._Label_16.BackColor = System.Drawing.SystemColors.Control
Me._Label_16.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_16.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_16.Location = New System.Drawing.Point(8, 128)
Me._Label_16.Name = "_Label_16"
Me._Label_16.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_16.Size = New System.Drawing.Size(50, 13)
Me._Label_16.TabIndex = 84
Me._Label_16.Text = "Fattore Y"
'
'_lblMis_8
'
Me._lblMis_8.BackColor = System.Drawing.Color.Cyan
Me._lblMis_8.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_8.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_8.Location = New System.Drawing.Point(240, 128)
Me._lblMis_8.Name = "_lblMis_8"
Me._lblMis_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_8.Size = New System.Drawing.Size(40, 17)
Me._lblMis_8.TabIndex = 83
Me._lblMis_8.Text = "psi"
'
'_Label_15
'
Me._Label_15.AutoSize = true
Me._Label_15.BackColor = System.Drawing.SystemColors.Control
Me._Label_15.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_15.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_15.Location = New System.Drawing.Point(8, 112)
Me._Label_15.Name = "_Label_15"
Me._Label_15.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_15.Size = New System.Drawing.Size(51, 13)
Me._Label_15.TabIndex = 81
Me._Label_15.Text = "Fattore m"
'
'_Label_14
'
Me._Label_14.AutoSize = true
Me._Label_14.BackColor = System.Drawing.SystemColors.Control
Me._Label_14.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_14.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_14.Location = New System.Drawing.Point(8, 96)
Me._Label_14.Name = "_Label_14"
Me._Label_14.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_14.Size = New System.Drawing.Size(86, 13)
Me._Label_14.TabIndex = 79
Me._Label_14.Text = "Spessore nubbin"
'
'_lblMis_7
'
Me._lblMis_7.BackColor = System.Drawing.Color.Cyan
Me._lblMis_7.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_7.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_7.Location = New System.Drawing.Point(240, 96)
Me._lblMis_7.Name = "_lblMis_7"
Me._lblMis_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_7.Size = New System.Drawing.Size(40, 17)
Me._lblMis_7.TabIndex = 78
Me._lblMis_7.Text = "mm"
'
'_Label_13
'
Me._Label_13.AutoSize = true
Me._Label_13.BackColor = System.Drawing.SystemColors.Control
Me._Label_13.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_13.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_13.Location = New System.Drawing.Point(8, 80)
Me._Label_13.Name = "_Label_13"
Me._Label_13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_13.Size = New System.Drawing.Size(85, 13)
Me._Label_13.TabIndex = 76
Me._Label_13.Text = "Larghezza attiva"
'
'_lblMis_6
'
Me._lblMis_6.BackColor = System.Drawing.Color.Cyan
Me._lblMis_6.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_6.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_6.Location = New System.Drawing.Point(240, 80)
Me._lblMis_6.Name = "_lblMis_6"
Me._lblMis_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_6.Size = New System.Drawing.Size(40, 17)
Me._lblMis_6.TabIndex = 75
Me._lblMis_6.Text = "mm"
'
'_Label_11
'
Me._Label_11.AutoSize = true
Me._Label_11.BackColor = System.Drawing.SystemColors.Control
Me._Label_11.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_11.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_11.Location = New System.Drawing.Point(8, 16)
Me._Label_11.Name = "_Label_11"
Me._Label_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_11.Size = New System.Drawing.Size(80, 13)
Me._Label_11.TabIndex = 73
Me._Label_11.Text = "Denominazione"
'
'_Label_9
'
Me._Label_9.AutoSize = true
Me._Label_9.BackColor = System.Drawing.SystemColors.Control
Me._Label_9.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_9.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_9.Location = New System.Drawing.Point(8, 64)
Me._Label_9.Name = "_Label_9"
Me._Label_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_9.Size = New System.Drawing.Size(143, 13)
Me._Label_9.TabIndex = 72
Me._Label_9.Text = "Diametro esterno parte attiva"
'
'_lblMis_5
'
Me._lblMis_5.BackColor = System.Drawing.Color.Cyan
Me._lblMis_5.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_5.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_5.Location = New System.Drawing.Point(240, 64)
Me._lblMis_5.Name = "_lblMis_5"
Me._lblMis_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_5.Size = New System.Drawing.Size(40, 17)
Me._lblMis_5.TabIndex = 71
Me._lblMis_5.Text = "mm"
'
'framShell
'
Me.framShell.BackColor = System.Drawing.SystemColors.Control
Me.framShell.Controls.Add(Me._txtShell_11)
Me.framShell.Controls.Add(Me._txtShell_10)
Me.framShell.Controls.Add(Me._txtShell_1)
Me.framShell.Controls.Add(Me._txtShell_0)
Me.framShell.Controls.Add(Me._lblMis_12)
Me.framShell.Controls.Add(Me._Label_20)
Me.framShell.Controls.Add(Me._lblMis_11)
Me.framShell.Controls.Add(Me._Label_19)
Me.framShell.Controls.Add(Me._lblMis_103)
Me.framShell.Controls.Add(Me._Label_12)
Me.framShell.Controls.Add(Me._lblMis_102)
Me.framShell.Controls.Add(Me._Label_10)
Me.framShell.ForeColor = System.Drawing.Color.Blue
Me.framShell.Location = New System.Drawing.Point(8, 8)
Me.framShell.Name = "framShell"
Me.framShell.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framShell.Size = New System.Drawing.Size(289, 97)
Me.framShell.TabIndex = 61
Me.framShell.TabStop = false
Me.framShell.Text = "Mantello"
'
'_txtShell_11
'
Me._txtShell_11.AcceptsReturn = true
Me._txtShell_11.BackColor = System.Drawing.Color.White
Me._txtShell_11.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_11.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_11.Location = New System.Drawing.Point(168, 64)
Me._txtShell_11.MaxLength = 0
Me._txtShell_11.Name = "_txtShell_11"
Me._txtShell_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_11.Size = New System.Drawing.Size(65, 20)
Me._txtShell_11.TabIndex = 95
Me._txtShell_11.Tag = "p"
'
'_txtShell_10
'
Me._txtShell_10.AcceptsReturn = true
Me._txtShell_10.BackColor = System.Drawing.Color.Yellow
Me._txtShell_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_10.Enabled = false
Me._txtShell_10.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_10.Location = New System.Drawing.Point(168, 48)
Me._txtShell_10.MaxLength = 0
Me._txtShell_10.Name = "_txtShell_10"
Me._txtShell_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_10.Size = New System.Drawing.Size(65, 20)
Me._txtShell_10.TabIndex = 92
Me._txtShell_10.Tag = "p"
'
'_txtShell_1
'
Me._txtShell_1.AcceptsReturn = true
Me._txtShell_1.BackColor = System.Drawing.Color.White
Me._txtShell_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_1.Location = New System.Drawing.Point(168, 32)
Me._txtShell_1.MaxLength = 0
Me._txtShell_1.Name = "_txtShell_1"
Me._txtShell_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_1.Size = New System.Drawing.Size(65, 20)
Me._txtShell_1.TabIndex = 65
Me._txtShell_1.Tag = "p"
'
'_txtShell_0
'
Me._txtShell_0.AcceptsReturn = true
Me._txtShell_0.BackColor = System.Drawing.Color.White
Me._txtShell_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtShell_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtShell_0.Location = New System.Drawing.Point(168, 16)
Me._txtShell_0.MaxLength = 0
Me._txtShell_0.Name = "_txtShell_0"
Me._txtShell_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtShell_0.Size = New System.Drawing.Size(65, 20)
Me._txtShell_0.TabIndex = 62
Me._txtShell_0.Tag = "p"
'
'_lblMis_12
'
Me._lblMis_12.BackColor = System.Drawing.Color.Cyan
Me._lblMis_12.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_12.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_12.Location = New System.Drawing.Point(240, 64)
Me._lblMis_12.Name = "_lblMis_12"
Me._lblMis_12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_12.Size = New System.Drawing.Size(40, 17)
Me._lblMis_12.TabIndex = 97
Me._lblMis_12.Text = "mm"
'
'_Label_20
'
Me._Label_20.AutoSize = true
Me._Label_20.BackColor = System.Drawing.SystemColors.Control
Me._Label_20.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_20.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_20.Location = New System.Drawing.Point(8, 64)
Me._Label_20.Name = "_Label_20"
Me._Label_20.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_20.Size = New System.Drawing.Size(93, 13)
Me._Label_20.TabIndex = 96
Me._Label_20.Text = "Spessore adottato"
'
'_lblMis_11
'
Me._lblMis_11.BackColor = System.Drawing.Color.Cyan
Me._lblMis_11.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_11.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_11.Location = New System.Drawing.Point(240, 48)
Me._lblMis_11.Name = "_lblMis_11"
Me._lblMis_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_11.Size = New System.Drawing.Size(40, 17)
Me._lblMis_11.TabIndex = 94
Me._lblMis_11.Text = "mm"
'
'_Label_19
'
Me._Label_19.AutoSize = true
Me._Label_19.BackColor = System.Drawing.SystemColors.Control
Me._Label_19.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_19.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_19.Location = New System.Drawing.Point(8, 48)
Me._Label_19.Name = "_Label_19"
Me._Label_19.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_19.Size = New System.Drawing.Size(134, 13)
Me._Label_19.TabIndex = 93
Me._Label_19.Text = "Spessore minimo di calcolo"
'
'_lblMis_103
'
Me._lblMis_103.BackColor = System.Drawing.Color.Cyan
Me._lblMis_103.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_103.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_103.Location = New System.Drawing.Point(240, 32)
Me._lblMis_103.Name = "_lblMis_103"
Me._lblMis_103.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_103.Size = New System.Drawing.Size(40, 17)
Me._lblMis_103.TabIndex = 67
Me._lblMis_103.Text = "mm"
'
'_Label_12
'
Me._Label_12.AutoSize = true
Me._Label_12.BackColor = System.Drawing.SystemColors.Control
Me._Label_12.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_12.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_12.Location = New System.Drawing.Point(8, 32)
Me._Label_12.Name = "_Label_12"
Me._Label_12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_12.Size = New System.Drawing.Size(89, 13)
Me._Label_12.TabIndex = 66
Me._Label_12.Text = "Corrosione o clad"
'
'_lblMis_102
'
Me._lblMis_102.BackColor = System.Drawing.Color.Cyan
Me._lblMis_102.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_102.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_102.Location = New System.Drawing.Point(240, 16)
Me._lblMis_102.Name = "_lblMis_102"
Me._lblMis_102.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_102.Size = New System.Drawing.Size(40, 17)
Me._lblMis_102.TabIndex = 64
Me._lblMis_102.Text = "mm"
'
'_Label_10
'
Me._Label_10.AutoSize = true
Me._Label_10.BackColor = System.Drawing.SystemColors.Control
Me._Label_10.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_10.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_10.Location = New System.Drawing.Point(8, 16)
Me._Label_10.Name = "_Label_10"
Me._Label_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_10.Size = New System.Drawing.Size(126, 13)
Me._Label_10.TabIndex = 63
Me._Label_10.Text = "Diametro interno mantello"
'
'_pctFrames_3
'
Me._pctFrames_3.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_3.Controls.Add(Me.txtTroppiTiranti)
Me._pctFrames_3.Controls.Add(Me._cmdCalc_3)
Me._pctFrames_3.Controls.Add(Me.framCarichi)
Me._pctFrames_3.Controls.Add(Me.framViti)
Me._pctFrames_3.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_3.Location = New System.Drawing.Point(5, 3)
Me._pctFrames_3.Name = "_pctFrames_3"
Me._pctFrames_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_3.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_3.TabIndex = 98
Me._pctFrames_3.TabStop = true
'
'txtTroppiTiranti
'
Me.txtTroppiTiranti.BackColor = System.Drawing.Color.Red
Me.txtTroppiTiranti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.txtTroppiTiranti.Location = New System.Drawing.Point(8, 208)
Me.txtTroppiTiranti.Multiline = true
Me.txtTroppiTiranti.Name = "txtTroppiTiranti"
Me.txtTroppiTiranti.Size = New System.Drawing.Size(288, 112)
Me.txtTroppiTiranti.TabIndex = 166
Me.txtTroppiTiranti.Text = resources.GetString("txtTroppiTiranti.Text")
'
'_cmdCalc_3
'
Me._cmdCalc_3.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_3.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_3.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_3.Location = New System.Drawing.Point(512, 288)
Me._cmdCalc_3.Name = "_cmdCalc_3"
Me._cmdCalc_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_3.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_3.TabIndex = 165
Me._cmdCalc_3.Text = "Calcola"
Me._cmdCalc_3.UseVisualStyleBackColor = false
'
'framCarichi
'
Me.framCarichi.BackColor = System.Drawing.SystemColors.Control
Me.framCarichi.Controls.Add(Me._optPlastic_1)
Me.framCarichi.Controls.Add(Me._optPlastic_0)
Me.framCarichi.Controls.Add(Me._txtViti_7)
Me.framCarichi.Controls.Add(Me._txtViti_6)
Me.framCarichi.Controls.Add(Me._txtViti_5)
Me.framCarichi.Controls.Add(Me._txtViti_4)
Me.framCarichi.Controls.Add(Me._lblMis_31)
Me.framCarichi.Controls.Add(Me._Label_40)
Me.framCarichi.Controls.Add(Me._lblMis_30)
Me.framCarichi.Controls.Add(Me._Label_39)
Me.framCarichi.Controls.Add(Me._lblMis_29)
Me.framCarichi.Controls.Add(Me._Label_38)
Me.framCarichi.Controls.Add(Me._lblMis_26)
Me.framCarichi.Controls.Add(Me._Label_37)
Me.framCarichi.ForeColor = System.Drawing.Color.Blue
Me.framCarichi.Location = New System.Drawing.Point(304, 8)
Me.framCarichi.Name = "framCarichi"
Me.framCarichi.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framCarichi.Size = New System.Drawing.Size(281, 152)
Me.framCarichi.TabIndex = 147
Me.framCarichi.TabStop = false
Me.framCarichi.Text = "Carichi sulle viti interne"
'
'_optPlastic_1
'
Me._optPlastic_1.BackColor = System.Drawing.SystemColors.Control
Me._optPlastic_1.Cursor = System.Windows.Forms.Cursors.Default
Me._optPlastic_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._optPlastic_1.Location = New System.Drawing.Point(8, 120)
Me._optPlastic_1.Name = "_optPlastic_1"
Me._optPlastic_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optPlastic_1.Size = New System.Drawing.Size(264, 17)
Me._optPlastic_1.TabIndex = 442
Me._optPlastic_1.TabStop = true
Me._optPlastic_1.Text = "Carico da dilataz. impedita considerato secondario"
Me._optPlastic_1.UseVisualStyleBackColor = false
'
'_optPlastic_0
'
Me._optPlastic_0.BackColor = System.Drawing.SystemColors.Control
Me._optPlastic_0.Cursor = System.Windows.Forms.Cursors.Default
Me._optPlastic_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._optPlastic_0.Location = New System.Drawing.Point(8, 104)
Me._optPlastic_0.Name = "_optPlastic_0"
Me._optPlastic_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optPlastic_0.Size = New System.Drawing.Size(264, 17)
Me._optPlastic_0.TabIndex = 441
Me._optPlastic_0.TabStop = true
Me._optPlastic_0.Text = "Carico da dilataz. impedita considerato primario"
Me._optPlastic_0.UseVisualStyleBackColor = false
'
'_txtViti_7
'
Me._txtViti_7.AcceptsReturn = true
Me._txtViti_7.BackColor = System.Drawing.Color.Yellow
Me._txtViti_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_7.Enabled = false
Me._txtViti_7.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_7, CType(7,Short))
Me._txtViti_7.Location = New System.Drawing.Point(168, 80)
Me._txtViti_7.MaxLength = 0
Me._txtViti_7.Name = "_txtViti_7"
Me._txtViti_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_7.Size = New System.Drawing.Size(65, 20)
Me._txtViti_7.TabIndex = 166
Me._txtViti_7.Tag = "p"
'
'_txtViti_6
'
Me._txtViti_6.AcceptsReturn = true
Me._txtViti_6.BackColor = System.Drawing.Color.Yellow
Me._txtViti_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_6.Enabled = false
Me._txtViti_6.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_6, CType(6,Short))
Me._txtViti_6.Location = New System.Drawing.Point(168, 48)
Me._txtViti_6.MaxLength = 0
Me._txtViti_6.Name = "_txtViti_6"
Me._txtViti_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_6.Size = New System.Drawing.Size(65, 20)
Me._txtViti_6.TabIndex = 162
Me._txtViti_6.Tag = "p"
'
'_txtViti_5
'
Me._txtViti_5.AcceptsReturn = true
Me._txtViti_5.BackColor = System.Drawing.Color.Yellow
Me._txtViti_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_5.Enabled = false
Me._txtViti_5.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_5, CType(5,Short))
Me._txtViti_5.Location = New System.Drawing.Point(168, 32)
Me._txtViti_5.MaxLength = 0
Me._txtViti_5.Name = "_txtViti_5"
Me._txtViti_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_5.Size = New System.Drawing.Size(65, 20)
Me._txtViti_5.TabIndex = 159
Me._txtViti_5.Tag = "p"
'
'_txtViti_4
'
Me._txtViti_4.AcceptsReturn = true
Me._txtViti_4.BackColor = System.Drawing.Color.Yellow
Me._txtViti_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_4.Enabled = false
Me._txtViti_4.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_4, CType(4,Short))
Me._txtViti_4.Location = New System.Drawing.Point(168, 16)
Me._txtViti_4.MaxLength = 0
Me._txtViti_4.Name = "_txtViti_4"
Me._txtViti_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_4.Size = New System.Drawing.Size(65, 20)
Me._txtViti_4.TabIndex = 156
Me._txtViti_4.Tag = "p"
'
'_lblMis_31
'
Me._lblMis_31.BackColor = System.Drawing.Color.Cyan
Me._lblMis_31.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_31.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_31.Location = New System.Drawing.Point(240, 80)
Me._lblMis_31.Name = "_lblMis_31"
Me._lblMis_31.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_31.Size = New System.Drawing.Size(33, 17)
Me._lblMis_31.TabIndex = 168
Me._lblMis_31.Text = "MN"
'
'_Label_40
'
Me._Label_40.BackColor = System.Drawing.SystemColors.Control
Me._Label_40.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_40.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_40.Location = New System.Drawing.Point(8, 75)
Me._Label_40.Name = "_Label_40"
Me._Label_40.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_40.Size = New System.Drawing.Size(145, 29)
Me._Label_40.TabIndex = 167
Me._Label_40.Text = "Carico da dilatazione termica su anello di spinta "
'
'_lblMis_30
'
Me._lblMis_30.BackColor = System.Drawing.Color.Cyan
Me._lblMis_30.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_30.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_30.Location = New System.Drawing.Point(240, 48)
Me._lblMis_30.Name = "_lblMis_30"
Me._lblMis_30.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_30.Size = New System.Drawing.Size(34, 17)
Me._lblMis_30.TabIndex = 164
Me._lblMis_30.Text = "MN"
'
'_Label_39
'
Me._Label_39.AutoSize = true
Me._Label_39.BackColor = System.Drawing.SystemColors.Control
Me._Label_39.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_39.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_39.Location = New System.Drawing.Point(8, 48)
Me._Label_39.Name = "_Label_39"
Me._Label_39.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_39.Size = New System.Drawing.Size(60, 13)
Me._Label_39.TabIndex = 163
Me._Label_39.Text = "In esercizio"
'
'_lblMis_29
'
Me._lblMis_29.BackColor = System.Drawing.Color.Cyan
Me._lblMis_29.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_29.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_29.Location = New System.Drawing.Point(240, 32)
Me._lblMis_29.Name = "_lblMis_29"
Me._lblMis_29.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_29.Size = New System.Drawing.Size(34, 17)
Me._lblMis_29.TabIndex = 161
Me._lblMis_29.Text = "MN"
'
'_Label_38
'
Me._Label_38.AutoSize = true
Me._Label_38.BackColor = System.Drawing.SystemColors.Control
Me._Label_38.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_38.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_38.Location = New System.Drawing.Point(8, 32)
Me._Label_38.Name = "_Label_38"
Me._Label_38.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_38.Size = New System.Drawing.Size(88, 13)
Me._Label_38.TabIndex = 160
Me._Label_38.Text = "In prova idraulica"
'
'_lblMis_26
'
Me._lblMis_26.BackColor = System.Drawing.Color.Cyan
Me._lblMis_26.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_26.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_26.Location = New System.Drawing.Point(240, 16)
Me._lblMis_26.Name = "_lblMis_26"
Me._lblMis_26.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_26.Size = New System.Drawing.Size(34, 17)
Me._lblMis_26.TabIndex = 158
Me._lblMis_26.Text = "MN"
'
'_Label_37
'
Me._Label_37.AutoSize = true
Me._Label_37.BackColor = System.Drawing.SystemColors.Control
Me._Label_37.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_37.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_37.Location = New System.Drawing.Point(8, 16)
Me._Label_37.Name = "_Label_37"
Me._Label_37.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_37.Size = New System.Drawing.Size(53, 13)
Me._Label_37.TabIndex = 157
Me._Label_37.Text = "Al seating"
'
'framViti
'
Me.framViti.BackColor = System.Drawing.SystemColors.Control
Me.framViti.Controls.Add(Me.cmdEstensioneAutomatica)
Me.framViti.Controls.Add(Me.txtSizeScr)
Me.framViti.Controls.Add(Me._txtViti_9)
Me.framViti.Controls.Add(Me._txtViti_8)
Me.framViti.Controls.Add(Me._txtViti_10)
Me.framViti.Controls.Add(Me._cmdtir_0)
Me.framViti.Controls.Add(Me._txtViti_3)
Me.framViti.Controls.Add(Me._txtViti_2)
Me.framViti.Controls.Add(Me._txtViti_1)
Me.framViti.Controls.Add(Me._txtViti_0)
Me.framViti.Controls.Add(Me._Label_131)
Me.framViti.Controls.Add(Me._lblMis_110)
Me.framViti.Controls.Add(Me._Label_126)
Me.framViti.Controls.Add(Me._lblMis_105)
Me.framViti.Controls.Add(Me._Label_125)
Me.framViti.Controls.Add(Me._lblMis_25)
Me.framViti.Controls.Add(Me._lblMis_28)
Me.framViti.Controls.Add(Me._Label_36)
Me.framViti.Controls.Add(Me._lblMis_27)
Me.framViti.Controls.Add(Me._Label_35)
Me.framViti.Controls.Add(Me._Label_34)
Me.framViti.Controls.Add(Me._Label_33)
Me.framViti.ForeColor = System.Drawing.Color.Blue
Me.framViti.Location = New System.Drawing.Point(8, 8)
Me.framViti.Name = "framViti"
Me.framViti.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framViti.Size = New System.Drawing.Size(289, 192)
Me.framViti.TabIndex = 144
Me.framViti.TabStop = false
Me.framViti.Text = "Viti interne"
'
'txtSizeScr
'
Me.txtSizeScr.BackColor = System.Drawing.Color.GreenYellow
Me.txtSizeScr.Enabled = false
Me.txtSizeScr.Location = New System.Drawing.Point(8, 144)
Me.txtSizeScr.Multiline = true
Me.txtSizeScr.Name = "txtSizeScr"
Me.txtSizeScr.Size = New System.Drawing.Size(272, 40)
Me.txtSizeScr.TabIndex = 467
Me.txtSizeScr.Text = "Condizione di carico dimensionante:"
'
'_txtViti_9
'
Me._txtViti_9.AcceptsReturn = true
Me._txtViti_9.BackColor = System.Drawing.Color.Yellow
Me._txtViti_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_9.Enabled = false
Me._txtViti_9.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_9, CType(9,Short))
Me._txtViti_9.Location = New System.Drawing.Point(160, 96)
Me._txtViti_9.MaxLength = 0
Me._txtViti_9.Name = "_txtViti_9"
Me._txtViti_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_9.Size = New System.Drawing.Size(65, 20)
Me._txtViti_9.TabIndex = 449
Me._txtViti_9.Tag = "p"
'
'_txtViti_8
'
Me._txtViti_8.AcceptsReturn = true
Me._txtViti_8.BackColor = System.Drawing.Color.Yellow
Me._txtViti_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_8.Enabled = false
Me._txtViti_8.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_8, CType(8,Short))
Me._txtViti_8.Location = New System.Drawing.Point(160, 80)
Me._txtViti_8.MaxLength = 0
Me._txtViti_8.Name = "_txtViti_8"
Me._txtViti_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_8.Size = New System.Drawing.Size(65, 20)
Me._txtViti_8.TabIndex = 446
Me._txtViti_8.Tag = "p"
'
'_txtViti_10
'
Me._txtViti_10.AcceptsReturn = true
Me._txtViti_10.BackColor = System.Drawing.Color.White
Me._txtViti_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_10.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_10, CType(10,Short))
Me._txtViti_10.Location = New System.Drawing.Point(160, 64)
Me._txtViti_10.MaxLength = 0
Me._txtViti_10.Name = "_txtViti_10"
Me._txtViti_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_10.Size = New System.Drawing.Size(65, 20)
Me._txtViti_10.TabIndex = 464
Me._txtViti_10.Tag = "p"
'
'_txtViti_3
'
Me._txtViti_3.AcceptsReturn = true
Me._txtViti_3.BackColor = System.Drawing.Color.Yellow
Me._txtViti_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_3.Enabled = false
Me._txtViti_3.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_3, CType(3,Short))
Me._txtViti_3.Location = New System.Drawing.Point(160, 48)
Me._txtViti_3.MaxLength = 0
Me._txtViti_3.Name = "_txtViti_3"
Me._txtViti_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_3.Size = New System.Drawing.Size(65, 20)
Me._txtViti_3.TabIndex = 153
Me._txtViti_3.Tag = "p"
'
'_txtViti_2
'
Me._txtViti_2.AcceptsReturn = true
Me._txtViti_2.BackColor = System.Drawing.Color.White
Me._txtViti_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_2.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_2, CType(2,Short))
Me._txtViti_2.Location = New System.Drawing.Point(160, 32)
Me._txtViti_2.MaxLength = 0
Me._txtViti_2.Name = "_txtViti_2"
Me._txtViti_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_2.Size = New System.Drawing.Size(65, 20)
Me._txtViti_2.TabIndex = 150
Me._txtViti_2.Tag = "p"
'
'_txtViti_1
'
Me._txtViti_1.AcceptsReturn = true
Me._txtViti_1.BackColor = System.Drawing.Color.White
Me._txtViti_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_1.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_1, CType(1,Short))
Me._txtViti_1.Location = New System.Drawing.Point(160, 120)
Me._txtViti_1.MaxLength = 0
Me._txtViti_1.Name = "_txtViti_1"
Me._txtViti_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_1.Size = New System.Drawing.Size(65, 20)
Me._txtViti_1.TabIndex = 148
Me._txtViti_1.Tag = "p"
'
'_txtViti_0
'
Me._txtViti_0.AcceptsReturn = true
Me._txtViti_0.BackColor = System.Drawing.Color.White
Me._txtViti_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtViti_0.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtViti.SetIndex(Me._txtViti_0, CType(0,Short))
Me._txtViti_0.Location = New System.Drawing.Point(160, 16)
Me._txtViti_0.MaxLength = 0
Me._txtViti_0.Name = "_txtViti_0"
Me._txtViti_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtViti_0.Size = New System.Drawing.Size(65, 20)
Me._txtViti_0.TabIndex = 145
Me._txtViti_0.Tag = "p"
'
'_Label_131
'
Me._Label_131.AutoSize = true
Me._Label_131.BackColor = System.Drawing.SystemColors.Control
Me._Label_131.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_131.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_131.Location = New System.Drawing.Point(8, 64)
Me._Label_131.Name = "_Label_131"
Me._Label_131.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_131.Size = New System.Drawing.Size(136, 13)
Me._Label_131.TabIndex = 466
Me._Label_131.Text = "Sez. resistente (estensione)"
'
'_lblMis_110
'
Me._lblMis_110.BackColor = System.Drawing.Color.Cyan
Me._lblMis_110.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_110.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_110.Location = New System.Drawing.Point(232, 64)
Me._lblMis_110.Name = "_lblMis_110"
Me._lblMis_110.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_110.Size = New System.Drawing.Size(32, 17)
Me._lblMis_110.TabIndex = 465
Me._lblMis_110.Text = "mm2"
'
'_Label_126
'
Me._Label_126.AutoSize = true
Me._Label_126.BackColor = System.Drawing.SystemColors.Control
Me._Label_126.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_126.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_126.Location = New System.Drawing.Point(8, 96)
Me._Label_126.Name = "_Label_126"
Me._Label_126.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_126.Size = New System.Drawing.Size(92, 13)
Me._Label_126.TabIndex = 451
Me._Label_126.Text = "Spaziatura attuale"
'
'_lblMis_105
'
Me._lblMis_105.BackColor = System.Drawing.Color.Cyan
Me._lblMis_105.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_105.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_105.Location = New System.Drawing.Point(232, 96)
Me._lblMis_105.Name = "_lblMis_105"
Me._lblMis_105.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_105.Size = New System.Drawing.Size(24, 17)
Me._lblMis_105.TabIndex = 450
Me._lblMis_105.Text = "mm"
'
'_Label_125
'
Me._Label_125.AutoSize = true
Me._Label_125.BackColor = System.Drawing.SystemColors.Control
Me._Label_125.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_125.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_125.Location = New System.Drawing.Point(8, 80)
Me._Label_125.Name = "_Label_125"
Me._Label_125.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_125.Size = New System.Drawing.Size(92, 13)
Me._Label_125.TabIndex = 448
Me._Label_125.Text = "Spaziatura minima"
'
'_lblMis_25
'
Me._lblMis_25.BackColor = System.Drawing.Color.Cyan
Me._lblMis_25.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_25.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_25.Location = New System.Drawing.Point(232, 80)
Me._lblMis_25.Name = "_lblMis_25"
Me._lblMis_25.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_25.Size = New System.Drawing.Size(24, 17)
Me._lblMis_25.TabIndex = 447
Me._lblMis_25.Text = "mm"
'
'_lblMis_28
'
Me._lblMis_28.BackColor = System.Drawing.Color.Cyan
Me._lblMis_28.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_28.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_28.Location = New System.Drawing.Point(232, 48)
Me._lblMis_28.Name = "_lblMis_28"
Me._lblMis_28.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_28.Size = New System.Drawing.Size(32, 17)
Me._lblMis_28.TabIndex = 155
Me._lblMis_28.Text = "mm2"
'
'_Label_36
'
Me._Label_36.AutoSize = true
Me._Label_36.BackColor = System.Drawing.SystemColors.Control
Me._Label_36.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_36.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_36.Location = New System.Drawing.Point(8, 48)
Me._Label_36.Name = "_Label_36"
Me._Label_36.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_36.Size = New System.Drawing.Size(146, 13)
Me._Label_36.TabIndex = 154
Me._Label_36.Text = "Sez. resistente (parte filettata)"
'
'_lblMis_27
'
Me._lblMis_27.BackColor = System.Drawing.Color.Cyan
Me._lblMis_27.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_27.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_27.Location = New System.Drawing.Point(232, 32)
Me._lblMis_27.Name = "_lblMis_27"
Me._lblMis_27.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_27.Size = New System.Drawing.Size(24, 17)
Me._lblMis_27.TabIndex = 152
Me._lblMis_27.Text = "mm"
'
'_Label_35
'
Me._Label_35.AutoSize = true
Me._Label_35.BackColor = System.Drawing.SystemColors.Control
Me._Label_35.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_35.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_35.Location = New System.Drawing.Point(8, 32)
Me._Label_35.Name = "_Label_35"
Me._Label_35.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_35.Size = New System.Drawing.Size(114, 13)
Me._Label_35.TabIndex = 151
Me._Label_35.Text = "Diametro di istallazione"
'
'_Label_34
'
Me._Label_34.AutoSize = true
Me._Label_34.BackColor = System.Drawing.SystemColors.Control
Me._Label_34.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_34.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_34.Location = New System.Drawing.Point(8, 120)
Me._Label_34.Name = "_Label_34"
Me._Label_34.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_34.Size = New System.Drawing.Size(44, 13)
Me._Label_34.TabIndex = 149
Me._Label_34.Text = "Numero"
'
'_Label_33
'
Me._Label_33.AutoSize = true
Me._Label_33.BackColor = System.Drawing.SystemColors.Control
Me._Label_33.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_33.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_33.Location = New System.Drawing.Point(8, 16)
Me._Label_33.Name = "_Label_33"
Me._Label_33.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_33.Size = New System.Drawing.Size(94, 13)
Me._Label_33.TabIndex = 146
Me._Label_33.Text = "Diametro nominale"
'
'_pctFrames_6
'
Me._pctFrames_6.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_6.Controls.Add(Me.framChan)
Me._pctFrames_6.Controls.Add(Me.Frame2)
Me._pctFrames_6.Controls.Add(Me._cmdCalc_6)
Me._pctFrames_6.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_6.Location = New System.Drawing.Point(5, 3)
Me._pctFrames_6.Name = "_pctFrames_6"
Me._pctFrames_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_6.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_6.TabIndex = 170
Me._pctFrames_6.TabStop = true
'
'framChan
'
Me.framChan.BackColor = System.Drawing.SystemColors.Control
Me.framChan.Controls.Add(Me._txtchan_11)
Me.framChan.Controls.Add(Me._txtchan_10)
Me.framChan.Controls.Add(Me._txtchan_1)
Me.framChan.Controls.Add(Me._txtchan_0)
Me.framChan.Controls.Add(Me._lblMis_65)
Me.framChan.Controls.Add(Me._Label_77)
Me.framChan.Controls.Add(Me._lblMis_64)
Me.framChan.Controls.Add(Me._Label_76)
Me.framChan.Controls.Add(Me._lblMis_63)
Me.framChan.Controls.Add(Me._Label_75)
Me.framChan.Controls.Add(Me._lblMis_62)
Me.framChan.Controls.Add(Me._Label_74)
Me.framChan.ForeColor = System.Drawing.Color.Blue
Me.framChan.Location = New System.Drawing.Point(0, 8)
Me.framChan.Name = "framChan"
Me.framChan.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framChan.Size = New System.Drawing.Size(289, 129)
Me.framChan.TabIndex = 288
Me.framChan.TabStop = false
Me.framChan.Text = "Cassa"
'
'_txtchan_11
'
Me._txtchan_11.AcceptsReturn = true
Me._txtchan_11.BackColor = System.Drawing.Color.White
Me._txtchan_11.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_11.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_11.Location = New System.Drawing.Point(168, 64)
Me._txtchan_11.MaxLength = 0
Me._txtchan_11.Name = "_txtchan_11"
Me._txtchan_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_11.Size = New System.Drawing.Size(65, 20)
Me._txtchan_11.TabIndex = 298
Me._txtchan_11.Tag = "p"
'
'_txtchan_10
'
Me._txtchan_10.AcceptsReturn = true
Me._txtchan_10.BackColor = System.Drawing.Color.Yellow
Me._txtchan_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_10.Enabled = false
Me._txtchan_10.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_10.Location = New System.Drawing.Point(168, 48)
Me._txtchan_10.MaxLength = 0
Me._txtchan_10.Name = "_txtchan_10"
Me._txtchan_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_10.Size = New System.Drawing.Size(65, 20)
Me._txtchan_10.TabIndex = 295
Me._txtchan_10.Tag = "p"
'
'_txtchan_1
'
Me._txtchan_1.AcceptsReturn = true
Me._txtchan_1.BackColor = System.Drawing.Color.White
Me._txtchan_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_1.Location = New System.Drawing.Point(168, 32)
Me._txtchan_1.MaxLength = 0
Me._txtchan_1.Name = "_txtchan_1"
Me._txtchan_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_1.Size = New System.Drawing.Size(65, 20)
Me._txtchan_1.TabIndex = 292
Me._txtchan_1.Tag = "p"
'
'_txtchan_0
'
Me._txtchan_0.AcceptsReturn = true
Me._txtchan_0.BackColor = System.Drawing.Color.White
Me._txtchan_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_0.Location = New System.Drawing.Point(168, 16)
Me._txtchan_0.MaxLength = 0
Me._txtchan_0.Name = "_txtchan_0"
Me._txtchan_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_0.Size = New System.Drawing.Size(65, 20)
Me._txtchan_0.TabIndex = 289
Me._txtchan_0.Tag = "p"
'
'_lblMis_65
'
Me._lblMis_65.BackColor = System.Drawing.Color.Cyan
Me._lblMis_65.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_65.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_65.Location = New System.Drawing.Point(240, 64)
Me._lblMis_65.Name = "_lblMis_65"
Me._lblMis_65.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_65.Size = New System.Drawing.Size(40, 17)
Me._lblMis_65.TabIndex = 300
Me._lblMis_65.Text = "mm"
'
'_Label_77
'
Me._Label_77.AutoSize = true
Me._Label_77.BackColor = System.Drawing.SystemColors.Control
Me._Label_77.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_77.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_77.Location = New System.Drawing.Point(8, 64)
Me._Label_77.Name = "_Label_77"
Me._Label_77.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_77.Size = New System.Drawing.Size(146, 13)
Me._Label_77.TabIndex = 299
Me._Label_77.Text = "Spessore adottato parte liscia"
'
'_lblMis_64
'
Me._lblMis_64.BackColor = System.Drawing.Color.Cyan
Me._lblMis_64.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_64.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_64.Location = New System.Drawing.Point(240, 48)
Me._lblMis_64.Name = "_lblMis_64"
Me._lblMis_64.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_64.Size = New System.Drawing.Size(40, 17)
Me._lblMis_64.TabIndex = 297
Me._lblMis_64.Text = "mm"
'
'_Label_76
'
Me._Label_76.AutoSize = true
Me._Label_76.BackColor = System.Drawing.SystemColors.Control
Me._Label_76.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_76.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_76.Location = New System.Drawing.Point(8, 48)
Me._Label_76.Name = "_Label_76"
Me._Label_76.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_76.Size = New System.Drawing.Size(134, 13)
Me._Label_76.TabIndex = 296
Me._Label_76.Text = "Spessore minimo di calcolo"
'
'_lblMis_63
'
Me._lblMis_63.BackColor = System.Drawing.Color.Cyan
Me._lblMis_63.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_63.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_63.Location = New System.Drawing.Point(240, 32)
Me._lblMis_63.Name = "_lblMis_63"
Me._lblMis_63.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_63.Size = New System.Drawing.Size(40, 17)
Me._lblMis_63.TabIndex = 294
Me._lblMis_63.Text = "mm"
'
'_Label_75
'
Me._Label_75.AutoSize = true
Me._Label_75.BackColor = System.Drawing.SystemColors.Control
Me._Label_75.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_75.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_75.Location = New System.Drawing.Point(8, 32)
Me._Label_75.Name = "_Label_75"
Me._Label_75.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_75.Size = New System.Drawing.Size(57, 13)
Me._Label_75.TabIndex = 293
Me._Label_75.Text = "Corrosione"
'
'_lblMis_62
'
Me._lblMis_62.BackColor = System.Drawing.Color.Cyan
Me._lblMis_62.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_62.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_62.Location = New System.Drawing.Point(240, 16)
Me._lblMis_62.Name = "_lblMis_62"
Me._lblMis_62.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_62.Size = New System.Drawing.Size(40, 17)
Me._lblMis_62.TabIndex = 291
Me._lblMis_62.Text = "mm"
'
'_Label_74
'
Me._Label_74.AutoSize = true
Me._Label_74.BackColor = System.Drawing.SystemColors.Control
Me._Label_74.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_74.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_74.Location = New System.Drawing.Point(8, 16)
Me._Label_74.Name = "_Label_74"
Me._Label_74.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_74.Size = New System.Drawing.Size(84, 13)
Me._Label_74.TabIndex = 290
Me._Label_74.Text = "Diametro interno"
'
'Frame2
'
Me.Frame2.BackColor = System.Drawing.SystemColors.Control
Me.Frame2.Controls.Add(Me._txtchan_14)
Me.Frame2.Controls.Add(Me.Label10)
Me.Frame2.Controls.Add(Me.Label11)
Me.Frame2.Controls.Add(Me.cmdRicalcCassa)
Me.Frame2.Controls.Add(Me._txtChan_13)
Me.Frame2.Controls.Add(Me.Label6)
Me.Frame2.Controls.Add(Me.chkAnelloEst2)
Me.Frame2.Controls.Add(Me._txtChan_12)
Me.Frame2.Controls.Add(Me.Label7)
Me.Frame2.Controls.Add(Me.chkAnelloInt2)
Me.Frame2.Controls.Add(Me._txtchan_3)
Me.Frame2.Controls.Add(Me._txtchan_2)
Me.Frame2.Controls.Add(Me._txtchan_4)
Me.Frame2.Controls.Add(Me._txtchan_5)
Me.Frame2.Controls.Add(Me._txtchan_6)
Me.Frame2.Controls.Add(Me._txtchan_7)
Me.Frame2.Controls.Add(Me._txtchan_8)
Me.Frame2.Controls.Add(Me._txtchan_9)
Me.Frame2.Controls.Add(Me._cmdGuarn1_1)
Me.Frame2.Controls.Add(Me._lblMis_61)
Me.Frame2.Controls.Add(Me._Label_73)
Me.Frame2.Controls.Add(Me._Label_72)
Me.Frame2.Controls.Add(Me._lblMis_60)
Me.Frame2.Controls.Add(Me._Label_71)
Me.Frame2.Controls.Add(Me._lblMis_59)
Me.Frame2.Controls.Add(Me._Label_70)
Me.Frame2.Controls.Add(Me._Label_69)
Me.Frame2.Controls.Add(Me._lblMis_58)
Me.Frame2.Controls.Add(Me._Label_68)
Me.Frame2.Controls.Add(Me._lblMis_57)
Me.Frame2.Controls.Add(Me._Label_67)
Me.Frame2.Controls.Add(Me._lblMis_56)
Me.Frame2.Controls.Add(Me._Label_66)
Me.Frame2.ForeColor = System.Drawing.Color.Blue
Me.Frame2.Location = New System.Drawing.Point(296, 8)
Me.Frame2.Name = "Frame2"
Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Frame2.Size = New System.Drawing.Size(289, 280)
Me.Frame2.TabIndex = 264
Me.Frame2.TabStop = false
Me.Frame2.Text = "Guarnizione Channel"
'
'_txtchan_14
'
Me._txtchan_14.AcceptsReturn = true
Me._txtchan_14.BackColor = System.Drawing.Color.White
Me._txtchan_14.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_14.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_14.Location = New System.Drawing.Point(168, 48)
Me._txtchan_14.MaxLength = 0
Me._txtchan_14.Name = "_txtchan_14"
Me._txtchan_14.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_14.Size = New System.Drawing.Size(65, 20)
Me._txtchan_14.TabIndex = 473
Me._txtchan_14.Tag = "p"
'
'Label10
'
Me.Label10.BackColor = System.Drawing.Color.Cyan
Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label10.Location = New System.Drawing.Point(240, 48)
Me.Label10.Name = "Label10"
Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label10.Size = New System.Drawing.Size(40, 17)
Me.Label10.TabIndex = 475
Me.Label10.Text = "mm"
'
'Label11
'
Me.Label11.AutoSize = true
Me.Label11.BackColor = System.Drawing.SystemColors.Control
Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label11.Location = New System.Drawing.Point(8, 48)
Me.Label11.Name = "Label11"
Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label11.Size = New System.Drawing.Size(146, 13)
Me.Label11.TabIndex = 474
Me.Label11.Text = "Largh.dente cava lato interno"
'
'_txtChan_13
'
Me._txtChan_13.AcceptsReturn = true
Me._txtChan_13.BackColor = System.Drawing.Color.White
Me._txtChan_13.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtChan_13.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtChan_13.Location = New System.Drawing.Point(168, 192)
Me._txtChan_13.MaxLength = 0
Me._txtChan_13.Name = "_txtChan_13"
Me._txtChan_13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtChan_13.Size = New System.Drawing.Size(65, 20)
Me._txtChan_13.TabIndex = 292
Me._txtChan_13.Tag = "p"
Me._txtChan_13.Visible = false
'
'Label6
'
Me.Label6.BackColor = System.Drawing.Color.Cyan
Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label6.Location = New System.Drawing.Point(240, 192)
Me.Label6.Name = "Label6"
Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label6.Size = New System.Drawing.Size(40, 17)
Me.Label6.TabIndex = 293
Me.Label6.Text = "mm"
Me.Label6.Visible = false
'
'chkAnelloEst2
'
Me.chkAnelloEst2.AutoSize = true
Me.chkAnelloEst2.ForeColor = System.Drawing.Color.Black
Me.chkAnelloEst2.Location = New System.Drawing.Point(16, 192)
Me.chkAnelloEst2.Name = "chkAnelloEst2"
Me.chkAnelloEst2.Size = New System.Drawing.Size(144, 17)
Me.chkAnelloEst2.TabIndex = 291
Me.chkAnelloEst2.Text = "Anello esterno: larghezza"
Me.chkAnelloEst2.UseVisualStyleBackColor = true
'
'_txtChan_12
'
Me._txtChan_12.AcceptsReturn = true
Me._txtChan_12.BackColor = System.Drawing.Color.White
Me._txtChan_12.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtChan_12.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtChan_12.Location = New System.Drawing.Point(168, 168)
Me._txtChan_12.MaxLength = 0
Me._txtChan_12.Name = "_txtChan_12"
Me._txtChan_12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtChan_12.Size = New System.Drawing.Size(65, 20)
Me._txtChan_12.TabIndex = 289
Me._txtChan_12.Tag = "p"
Me._txtChan_12.Visible = false
'
'Label7
'
Me.Label7.BackColor = System.Drawing.Color.Cyan
Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label7.Location = New System.Drawing.Point(240, 168)
Me.Label7.Name = "Label7"
Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label7.Size = New System.Drawing.Size(40, 17)
Me.Label7.TabIndex = 290
Me.Label7.Text = "mm"
Me.Label7.Visible = false
'
'chkAnelloInt2
'
Me.chkAnelloInt2.AutoSize = true
Me.chkAnelloInt2.ForeColor = System.Drawing.Color.Black
Me.chkAnelloInt2.Location = New System.Drawing.Point(16, 168)
Me.chkAnelloInt2.Name = "chkAnelloInt2"
Me.chkAnelloInt2.Size = New System.Drawing.Size(141, 17)
Me.chkAnelloInt2.TabIndex = 288
Me.chkAnelloInt2.Text = "Anello interno: larghezza"
Me.chkAnelloInt2.UseVisualStyleBackColor = true
'
'_txtchan_3
'
Me._txtchan_3.AcceptsReturn = true
Me._txtchan_3.BackColor = System.Drawing.Color.White
Me._txtchan_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_3.Location = New System.Drawing.Point(168, 64)
Me._txtchan_3.MaxLength = 0
Me._txtchan_3.Name = "_txtchan_3"
Me._txtchan_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_3.Size = New System.Drawing.Size(65, 20)
Me._txtchan_3.TabIndex = 273
Me._txtchan_3.Tag = "p"
'
'_txtchan_2
'
Me._txtchan_2.AcceptsReturn = true
Me._txtchan_2.BackColor = System.Drawing.Color.White
Me._txtchan_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_2.Location = New System.Drawing.Point(96, 16)
Me._txtchan_2.MaxLength = 0
Me._txtchan_2.Name = "_txtchan_2"
Me._txtchan_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_2.Size = New System.Drawing.Size(161, 20)
Me._txtchan_2.TabIndex = 272
Me._txtchan_2.Tag = "p"
'
'_txtchan_4
'
Me._txtchan_4.AcceptsReturn = true
Me._txtchan_4.BackColor = System.Drawing.Color.White
Me._txtchan_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_4.Location = New System.Drawing.Point(168, 80)
Me._txtchan_4.MaxLength = 0
Me._txtchan_4.Name = "_txtchan_4"
Me._txtchan_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_4.Size = New System.Drawing.Size(65, 20)
Me._txtchan_4.TabIndex = 271
Me._txtchan_4.Tag = "p"
'
'_txtchan_5
'
Me._txtchan_5.AcceptsReturn = true
Me._txtchan_5.BackColor = System.Drawing.Color.White
Me._txtchan_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_5.Location = New System.Drawing.Point(168, 96)
Me._txtchan_5.MaxLength = 0
Me._txtchan_5.Name = "_txtchan_5"
Me._txtchan_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_5.Size = New System.Drawing.Size(65, 20)
Me._txtchan_5.TabIndex = 270
Me._txtchan_5.Tag = "p"
'
'_txtchan_6
'
Me._txtchan_6.AcceptsReturn = true
Me._txtchan_6.BackColor = System.Drawing.Color.White
Me._txtchan_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_6.Location = New System.Drawing.Point(168, 112)
Me._txtchan_6.MaxLength = 0
Me._txtchan_6.Name = "_txtchan_6"
Me._txtchan_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_6.Size = New System.Drawing.Size(65, 20)
Me._txtchan_6.TabIndex = 269
Me._txtchan_6.Tag = "p"
'
'_txtchan_7
'
Me._txtchan_7.AcceptsReturn = true
Me._txtchan_7.BackColor = System.Drawing.Color.White
Me._txtchan_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_7.Location = New System.Drawing.Point(168, 128)
Me._txtchan_7.MaxLength = 0
Me._txtchan_7.Name = "_txtchan_7"
Me._txtchan_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_7.Size = New System.Drawing.Size(65, 20)
Me._txtchan_7.TabIndex = 268
Me._txtchan_7.Tag = "p"
'
'_txtchan_8
'
Me._txtchan_8.AcceptsReturn = true
Me._txtchan_8.BackColor = System.Drawing.Color.White
Me._txtchan_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_8.Location = New System.Drawing.Point(168, 144)
Me._txtchan_8.MaxLength = 0
Me._txtchan_8.Name = "_txtchan_8"
Me._txtchan_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_8.Size = New System.Drawing.Size(65, 20)
Me._txtchan_8.TabIndex = 267
Me._txtchan_8.Tag = "p"
'
'_txtchan_9
'
Me._txtchan_9.AcceptsReturn = true
Me._txtchan_9.BackColor = System.Drawing.Color.Yellow
Me._txtchan_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtchan_9.Enabled = false
Me._txtchan_9.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtchan_9.Location = New System.Drawing.Point(168, 224)
Me._txtchan_9.MaxLength = 0
Me._txtchan_9.Name = "_txtchan_9"
Me._txtchan_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtchan_9.Size = New System.Drawing.Size(65, 20)
Me._txtchan_9.TabIndex = 266
Me._txtchan_9.Tag = "p"
'
'_lblMis_61
'
Me._lblMis_61.BackColor = System.Drawing.Color.Cyan
Me._lblMis_61.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_61.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_61.Location = New System.Drawing.Point(240, 64)
Me._lblMis_61.Name = "_lblMis_61"
Me._lblMis_61.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_61.Size = New System.Drawing.Size(40, 17)
Me._lblMis_61.TabIndex = 287
Me._lblMis_61.Text = "mm"
'
'_Label_73
'
Me._Label_73.AutoSize = true
Me._Label_73.BackColor = System.Drawing.SystemColors.Control
Me._Label_73.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_73.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_73.Location = New System.Drawing.Point(8, 64)
Me._Label_73.Name = "_Label_73"
Me._Label_73.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_73.Size = New System.Drawing.Size(143, 13)
Me._Label_73.TabIndex = 286
Me._Label_73.Text = "Diametro esterno parte attiva"
'
'_Label_72
'
Me._Label_72.AutoSize = true
Me._Label_72.BackColor = System.Drawing.SystemColors.Control
Me._Label_72.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_72.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_72.Location = New System.Drawing.Point(8, 16)
Me._Label_72.Name = "_Label_72"
Me._Label_72.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_72.Size = New System.Drawing.Size(80, 13)
Me._Label_72.TabIndex = 285
Me._Label_72.Text = "Denominazione"
'
'_lblMis_60
'
Me._lblMis_60.BackColor = System.Drawing.Color.Cyan
Me._lblMis_60.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_60.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_60.Location = New System.Drawing.Point(240, 80)
Me._lblMis_60.Name = "_lblMis_60"
Me._lblMis_60.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_60.Size = New System.Drawing.Size(40, 17)
Me._lblMis_60.TabIndex = 284
Me._lblMis_60.Text = "mm"
'
'_Label_71
'
Me._Label_71.AutoSize = true
Me._Label_71.BackColor = System.Drawing.SystemColors.Control
Me._Label_71.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_71.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_71.Location = New System.Drawing.Point(8, 80)
Me._Label_71.Name = "_Label_71"
Me._Label_71.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_71.Size = New System.Drawing.Size(112, 13)
Me._Label_71.TabIndex = 283
Me._Label_71.Text = "Larghezza parte attiva"
'
'_lblMis_59
'
Me._lblMis_59.BackColor = System.Drawing.Color.Cyan
Me._lblMis_59.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_59.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_59.Location = New System.Drawing.Point(240, 96)
Me._lblMis_59.Name = "_lblMis_59"
Me._lblMis_59.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_59.Size = New System.Drawing.Size(40, 17)
Me._lblMis_59.TabIndex = 282
Me._lblMis_59.Text = "mm"
'
'_Label_70
'
Me._Label_70.AutoSize = true
Me._Label_70.BackColor = System.Drawing.SystemColors.Control
Me._Label_70.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_70.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_70.Location = New System.Drawing.Point(8, 96)
Me._Label_70.Name = "_Label_70"
Me._Label_70.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_70.Size = New System.Drawing.Size(86, 13)
Me._Label_70.TabIndex = 281
Me._Label_70.Text = "Spessore nubbin"
'
'_Label_69
'
Me._Label_69.AutoSize = true
Me._Label_69.BackColor = System.Drawing.SystemColors.Control
Me._Label_69.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_69.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_69.Location = New System.Drawing.Point(8, 112)
Me._Label_69.Name = "_Label_69"
Me._Label_69.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_69.Size = New System.Drawing.Size(51, 13)
Me._Label_69.TabIndex = 280
Me._Label_69.Text = "Fattore m"
'
'_lblMis_58
'
Me._lblMis_58.BackColor = System.Drawing.Color.Cyan
Me._lblMis_58.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_58.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_58.Location = New System.Drawing.Point(240, 128)
Me._lblMis_58.Name = "_lblMis_58"
Me._lblMis_58.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_58.Size = New System.Drawing.Size(40, 17)
Me._lblMis_58.TabIndex = 279
Me._lblMis_58.Text = "psi"
'
'_Label_68
'
Me._Label_68.AutoSize = true
Me._Label_68.BackColor = System.Drawing.SystemColors.Control
Me._Label_68.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_68.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_68.Location = New System.Drawing.Point(8, 128)
Me._Label_68.Name = "_Label_68"
Me._Label_68.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_68.Size = New System.Drawing.Size(50, 13)
Me._Label_68.TabIndex = 278
Me._Label_68.Text = "Fattore Y"
'
'_lblMis_57
'
Me._lblMis_57.BackColor = System.Drawing.Color.Cyan
Me._lblMis_57.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_57.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_57.Location = New System.Drawing.Point(240, 144)
Me._lblMis_57.Name = "_lblMis_57"
Me._lblMis_57.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_57.Size = New System.Drawing.Size(40, 17)
Me._lblMis_57.TabIndex = 277
Me._lblMis_57.Text = "mm"
'
'_Label_67
'
Me._Label_67.AutoSize = true
Me._Label_67.BackColor = System.Drawing.SystemColors.Control
Me._Label_67.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_67.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_67.Location = New System.Drawing.Point(8, 144)
Me._Label_67.Name = "_Label_67"
Me._Label_67.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_67.Size = New System.Drawing.Size(44, 13)
Me._Label_67.TabIndex = 276
Me._Label_67.Text = "Formula"
'
'_lblMis_56
'
Me._lblMis_56.BackColor = System.Drawing.Color.Cyan
Me._lblMis_56.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_56.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_56.Location = New System.Drawing.Point(240, 224)
Me._lblMis_56.Name = "_lblMis_56"
Me._lblMis_56.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_56.Size = New System.Drawing.Size(40, 17)
Me._lblMis_56.TabIndex = 275
Me._lblMis_56.Text = "mm"
'
'_Label_66
'
Me._Label_66.AutoSize = true
Me._Label_66.BackColor = System.Drawing.SystemColors.Control
Me._Label_66.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_66.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_66.Location = New System.Drawing.Point(8, 224)
Me._Label_66.Name = "_Label_66"
Me._Label_66.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_66.Size = New System.Drawing.Size(100, 13)
Me._Label_66.TabIndex = 274
Me._Label_66.Text = "Ampiezza di calcolo"
'
'_cmdCalc_6
'
Me._cmdCalc_6.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_6.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_6.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_6.Location = New System.Drawing.Point(520, 296)
Me._cmdCalc_6.Name = "_cmdCalc_6"
Me._cmdCalc_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_6.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_6.TabIndex = 263
Me._cmdCalc_6.Text = "Calcola"
Me._cmdCalc_6.UseVisualStyleBackColor = false
'
'_pctFrames_7
'
Me._pctFrames_7.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_7.Controls.Add(Me.framCarInt)
Me._pctFrames_7.Controls.Add(Me.framAltri2)
Me._pctFrames_7.Controls.Add(Me.framCarExt)
Me._pctFrames_7.Controls.Add(Me.framExtScr)
Me._pctFrames_7.Controls.Add(Me.framIntScr2)
Me._pctFrames_7.Controls.Add(Me._cmdCalc_7)
Me._pctFrames_7.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_7.Location = New System.Drawing.Point(5, 3)
Me._pctFrames_7.Name = "_pctFrames_7"
Me._pctFrames_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_7.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_7.TabIndex = 262
Me._pctFrames_7.TabStop = true
'
'framCarInt
'
Me.framCarInt.BackColor = System.Drawing.SystemColors.Control
Me.framCarInt.Controls.Add(Me._lblMis_77)
Me.framCarInt.Controls.Add(Me.TextBox1)
Me.framCarInt.Controls.Add(Me.TextBox2)
Me.framCarInt.Controls.Add(Me.Label12)
Me.framCarInt.Controls.Add(Me.Label13)
Me.framCarInt.Controls.Add(Me._txtVitiInt_7)
Me.framCarInt.Controls.Add(Me._Label_91)
Me.framCarInt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.framCarInt.Location = New System.Drawing.Point(8, 160)
Me.framCarInt.Name = "framCarInt"
Me.framCarInt.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framCarInt.Size = New System.Drawing.Size(289, 72)
Me.framCarInt.TabIndex = 333
Me.framCarInt.TabStop = false
Me.framCarInt.Text = "Carichi sulle viti sul diametro interno"
'
'_lblMis_77
'
Me._lblMis_77.BackColor = System.Drawing.Color.Cyan
Me._lblMis_77.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_77.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_77.Location = New System.Drawing.Point(248, 48)
Me._lblMis_77.Name = "_lblMis_77"
Me._lblMis_77.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_77.Size = New System.Drawing.Size(33, 17)
Me._lblMis_77.TabIndex = 345
Me._lblMis_77.Text = "MN"
'
'TextBox1
'
Me.TextBox1.AcceptsReturn = true
Me.TextBox1.BackColor = System.Drawing.Color.Yellow
Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TextBox1.Enabled = false
Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
Me.TextBox1.Location = New System.Drawing.Point(152, 16)
Me.TextBox1.MaxLength = 0
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TextBox1.Size = New System.Drawing.Size(88, 20)
Me.TextBox1.TabIndex = 348
Me.TextBox1.Tag = "p"
Me.TextBox1.Text = "Non applicabile"
'
'TextBox2
'
Me.TextBox2.AcceptsReturn = true
Me.TextBox2.BackColor = System.Drawing.Color.Yellow
Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TextBox2.Enabled = false
Me.TextBox2.ForeColor = System.Drawing.SystemColors.WindowText
Me.TextBox2.Location = New System.Drawing.Point(152, 32)
Me.TextBox2.MaxLength = 0
Me.TextBox2.Name = "TextBox2"
Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TextBox2.Size = New System.Drawing.Size(88, 20)
Me.TextBox2.TabIndex = 347
Me.TextBox2.Tag = "p"
Me.TextBox2.Text = "Non applicabile"
'
'Label12
'
Me.Label12.AutoSize = true
Me.Label12.BackColor = System.Drawing.SystemColors.Control
Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label12.Location = New System.Drawing.Point(16, 16)
Me.Label12.Name = "Label12"
Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label12.Size = New System.Drawing.Size(53, 13)
Me.Label12.TabIndex = 350
Me.Label12.Text = "Al seating"
'
'Label13
'
Me.Label13.AutoSize = true
Me.Label13.BackColor = System.Drawing.SystemColors.Control
Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label13.Location = New System.Drawing.Point(16, 32)
Me.Label13.Name = "Label13"
Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label13.Size = New System.Drawing.Size(88, 13)
Me.Label13.TabIndex = 349
Me.Label13.Text = "In prova idraulica"
'
'_txtVitiInt_7
'
Me._txtVitiInt_7.AcceptsReturn = true
Me._txtVitiInt_7.BackColor = System.Drawing.Color.Yellow
Me._txtVitiInt_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_7.Enabled = false
Me._txtVitiInt_7.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_7, CType(7,Short))
Me._txtVitiInt_7.Location = New System.Drawing.Point(176, 48)
Me._txtVitiInt_7.MaxLength = 0
Me._txtVitiInt_7.Name = "_txtVitiInt_7"
Me._txtVitiInt_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_7.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_7.TabIndex = 344
Me._txtVitiInt_7.Tag = "p"
'
'_Label_91
'
Me._Label_91.AutoSize = true
Me._Label_91.BackColor = System.Drawing.SystemColors.Control
Me._Label_91.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_91.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_91.Location = New System.Drawing.Point(16, 48)
Me._Label_91.Name = "_Label_91"
Me._Label_91.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_91.Size = New System.Drawing.Size(60, 13)
Me._Label_91.TabIndex = 346
Me._Label_91.Text = "In esercizio"
'
'framAltri2
'
Me.framAltri2.BackColor = System.Drawing.SystemColors.Control
Me.framAltri2.Controls.Add(Me._txtVitiInt_8)
Me.framAltri2.Controls.Add(Me._txtVitiInt_5)
Me.framAltri2.Controls.Add(Me._Label_124)
Me.framAltri2.Controls.Add(Me._lblMis_104)
Me.framAltri2.Controls.Add(Me._lblMis_79)
Me.framAltri2.Controls.Add(Me._Label_93)
Me.framAltri2.ForeColor = System.Drawing.Color.Blue
Me.framAltri2.Location = New System.Drawing.Point(8, 232)
Me.framAltri2.Name = "framAltri2"
Me.framAltri2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framAltri2.Size = New System.Drawing.Size(289, 88)
Me.framAltri2.TabIndex = 350
Me.framAltri2.TabStop = false
Me.framAltri2.Text = "Altri dati"
'
'_txtVitiInt_8
'
Me._txtVitiInt_8.AcceptsReturn = true
Me._txtVitiInt_8.BackColor = System.Drawing.Color.White
Me._txtVitiInt_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_8.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_8, CType(8,Short))
Me._txtVitiInt_8.Location = New System.Drawing.Point(168, 32)
Me._txtVitiInt_8.MaxLength = 0
Me._txtVitiInt_8.Name = "_txtVitiInt_8"
Me._txtVitiInt_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_8.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_8.TabIndex = 438
Me._txtVitiInt_8.Tag = "p"
'
'_txtVitiInt_5
'
Me._txtVitiInt_5.AcceptsReturn = true
Me._txtVitiInt_5.BackColor = System.Drawing.Color.White
Me._txtVitiInt_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_5.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_5, CType(5,Short))
Me._txtVitiInt_5.Location = New System.Drawing.Point(168, 16)
Me._txtVitiInt_5.MaxLength = 0
Me._txtVitiInt_5.Name = "_txtVitiInt_5"
Me._txtVitiInt_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_5.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_5.TabIndex = 351
Me._txtVitiInt_5.Tag = "p"
'
'_Label_124
'
Me._Label_124.AutoSize = true
Me._Label_124.BackColor = System.Drawing.SystemColors.Control
Me._Label_124.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_124.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_124.Location = New System.Drawing.Point(8, 32)
Me._Label_124.Name = "_Label_124"
Me._Label_124.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_124.Size = New System.Drawing.Size(119, 13)
Me._Label_124.TabIndex = 440
Me._Label_124.Text = "Spessore del diaframma"
'
'_lblMis_104
'
Me._lblMis_104.BackColor = System.Drawing.Color.Cyan
Me._lblMis_104.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_104.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_104.Location = New System.Drawing.Point(240, 32)
Me._lblMis_104.Name = "_lblMis_104"
Me._lblMis_104.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_104.Size = New System.Drawing.Size(40, 17)
Me._lblMis_104.TabIndex = 439
Me._lblMis_104.Text = "mm"
'
'_lblMis_79
'
Me._lblMis_79.BackColor = System.Drawing.Color.Cyan
Me._lblMis_79.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_79.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_79.Location = New System.Drawing.Point(240, 16)
Me._lblMis_79.Name = "_lblMis_79"
Me._lblMis_79.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_79.Size = New System.Drawing.Size(40, 17)
Me._lblMis_79.TabIndex = 353
Me._lblMis_79.Text = "mm"
'
'_Label_93
'
Me._Label_93.AutoSize = true
Me._Label_93.BackColor = System.Drawing.SystemColors.Control
Me._Label_93.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_93.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_93.Location = New System.Drawing.Point(8, 16)
Me._Label_93.Name = "_Label_93"
Me._Label_93.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_93.Size = New System.Drawing.Size(154, 13)
Me._Label_93.TabIndex = 352
Me._Label_93.Text = "D.I. anello est. di compressione"
'
'framCarExt
'
Me.framCarExt.BackColor = System.Drawing.SystemColors.Control
Me.framCarExt.Controls.Add(Me._txtVitiExt_5)
Me.framCarExt.Controls.Add(Me._txtVitiExt_6)
Me.framCarExt.Controls.Add(Me._txtVitiExt_7)
Me.framCarExt.Controls.Add(Me._Label_90)
Me.framCarExt.Controls.Add(Me._lblMis_76)
Me.framCarExt.Controls.Add(Me._Label_89)
Me.framCarExt.Controls.Add(Me._lblMis_75)
Me.framCarExt.Controls.Add(Me._Label_88)
Me.framCarExt.Controls.Add(Me._lblMis_74)
Me.framCarExt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.framCarExt.Location = New System.Drawing.Point(296, 160)
Me.framCarExt.Name = "framCarExt"
Me.framCarExt.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framCarExt.Size = New System.Drawing.Size(289, 73)
Me.framCarExt.TabIndex = 334
Me.framCarExt.TabStop = false
Me.framCarExt.Text = "Carichi sulle viti sul diametro esterno"
'
'_txtVitiExt_5
'
Me._txtVitiExt_5.AcceptsReturn = true
Me._txtVitiExt_5.BackColor = System.Drawing.Color.Yellow
Me._txtVitiExt_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_5.Enabled = false
Me._txtVitiExt_5.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_5, CType(5,Short))
Me._txtVitiExt_5.Location = New System.Drawing.Point(168, 16)
Me._txtVitiExt_5.MaxLength = 0
Me._txtVitiExt_5.Name = "_txtVitiExt_5"
Me._txtVitiExt_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_5.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_5.TabIndex = 337
Me._txtVitiExt_5.Tag = "p"
'
'_txtVitiExt_6
'
Me._txtVitiExt_6.AcceptsReturn = true
Me._txtVitiExt_6.BackColor = System.Drawing.Color.Yellow
Me._txtVitiExt_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_6.Enabled = false
Me._txtVitiExt_6.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_6, CType(6,Short))
Me._txtVitiExt_6.Location = New System.Drawing.Point(168, 32)
Me._txtVitiExt_6.MaxLength = 0
Me._txtVitiExt_6.Name = "_txtVitiExt_6"
Me._txtVitiExt_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_6.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_6.TabIndex = 336
Me._txtVitiExt_6.Tag = "p"
'
'_txtVitiExt_7
'
Me._txtVitiExt_7.AcceptsReturn = true
Me._txtVitiExt_7.BackColor = System.Drawing.Color.Yellow
Me._txtVitiExt_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_7.Enabled = false
Me._txtVitiExt_7.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_7, CType(7,Short))
Me._txtVitiExt_7.Location = New System.Drawing.Point(168, 48)
Me._txtVitiExt_7.MaxLength = 0
Me._txtVitiExt_7.Name = "_txtVitiExt_7"
Me._txtVitiExt_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_7.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_7.TabIndex = 335
Me._txtVitiExt_7.Tag = "p"
'
'_Label_90
'
Me._Label_90.AutoSize = true
Me._Label_90.BackColor = System.Drawing.SystemColors.Control
Me._Label_90.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_90.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_90.Location = New System.Drawing.Point(8, 16)
Me._Label_90.Name = "_Label_90"
Me._Label_90.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_90.Size = New System.Drawing.Size(53, 13)
Me._Label_90.TabIndex = 343
Me._Label_90.Text = "Al seating"
'
'_lblMis_76
'
Me._lblMis_76.BackColor = System.Drawing.Color.Cyan
Me._lblMis_76.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_76.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_76.Location = New System.Drawing.Point(240, 16)
Me._lblMis_76.Name = "_lblMis_76"
Me._lblMis_76.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_76.Size = New System.Drawing.Size(33, 17)
Me._lblMis_76.TabIndex = 342
Me._lblMis_76.Text = "MN"
'
'_Label_89
'
Me._Label_89.AutoSize = true
Me._Label_89.BackColor = System.Drawing.SystemColors.Control
Me._Label_89.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_89.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_89.Location = New System.Drawing.Point(8, 32)
Me._Label_89.Name = "_Label_89"
Me._Label_89.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_89.Size = New System.Drawing.Size(88, 13)
Me._Label_89.TabIndex = 341
Me._Label_89.Text = "In prova idraulica"
'
'_lblMis_75
'
Me._lblMis_75.BackColor = System.Drawing.Color.Cyan
Me._lblMis_75.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_75.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_75.Location = New System.Drawing.Point(240, 32)
Me._lblMis_75.Name = "_lblMis_75"
Me._lblMis_75.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_75.Size = New System.Drawing.Size(33, 17)
Me._lblMis_75.TabIndex = 340
Me._lblMis_75.Text = "MN"
'
'_Label_88
'
Me._Label_88.AutoSize = true
Me._Label_88.BackColor = System.Drawing.SystemColors.Control
Me._Label_88.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_88.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_88.Location = New System.Drawing.Point(8, 48)
Me._Label_88.Name = "_Label_88"
Me._Label_88.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_88.Size = New System.Drawing.Size(60, 13)
Me._Label_88.TabIndex = 339
Me._Label_88.Text = "In esercizio"
'
'_lblMis_74
'
Me._lblMis_74.BackColor = System.Drawing.Color.Cyan
Me._lblMis_74.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_74.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_74.Location = New System.Drawing.Point(240, 48)
Me._lblMis_74.Name = "_lblMis_74"
Me._lblMis_74.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_74.Size = New System.Drawing.Size(33, 17)
Me._lblMis_74.TabIndex = 338
Me._lblMis_74.Text = "MN"
'
'framExtScr
'
Me.framExtScr.BackColor = System.Drawing.SystemColors.Control
Me.framExtScr.Controls.Add(Me._txtVitiExt_8)
Me.framExtScr.Controls.Add(Me._txtVitiExt_4)
Me.framExtScr.Controls.Add(Me._txtVitiExt_10)
Me.framExtScr.Controls.Add(Me._txtVitiExt_9)
Me.framExtScr.Controls.Add(Me._txtVitiExt_3)
Me.framExtScr.Controls.Add(Me._txtVitiExt_2)
Me.framExtScr.Controls.Add(Me._txtVitiExt_1)
Me.framExtScr.Controls.Add(Me._txtVitiExt_0)
Me.framExtScr.Controls.Add(Me._cmdtir_2)
Me.framExtScr.Controls.Add(Me._lblMis_109)
Me.framExtScr.Controls.Add(Me._Label_130)
Me.framExtScr.Controls.Add(Me._lblMis_108)
Me.framExtScr.Controls.Add(Me._Label_129)
Me.framExtScr.Controls.Add(Me._lblMis_101)
Me.framExtScr.Controls.Add(Me._Label_123)
Me.framExtScr.Controls.Add(Me._Label_87)
Me.framExtScr.Controls.Add(Me._lblMis_73)
Me.framExtScr.Controls.Add(Me._Label_86)
Me.framExtScr.Controls.Add(Me._Label_85)
Me.framExtScr.Controls.Add(Me._Label_84)
Me.framExtScr.Controls.Add(Me._lblMis_71)
Me.framExtScr.Controls.Add(Me._Label_83)
Me.framExtScr.Controls.Add(Me._lblMis_70)
Me.framExtScr.ForeColor = System.Drawing.Color.Blue
Me.framExtScr.Location = New System.Drawing.Point(296, 8)
Me.framExtScr.Name = "framExtScr"
Me.framExtScr.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framExtScr.Size = New System.Drawing.Size(289, 153)
Me.framExtScr.TabIndex = 304
Me.framExtScr.TabStop = false
Me.framExtScr.Text = "Viti e pistoni su diametro esterno"
'
'_txtVitiExt_8
'
Me._txtVitiExt_8.AcceptsReturn = true
Me._txtVitiExt_8.BackColor = System.Drawing.Color.White
Me._txtVitiExt_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_8.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_8, CType(8,Short))
Me._txtVitiExt_8.Location = New System.Drawing.Point(168, 128)
Me._txtVitiExt_8.MaxLength = 0
Me._txtVitiExt_8.Name = "_txtVitiExt_8"
Me._txtVitiExt_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_8.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_8.TabIndex = 435
Me._txtVitiExt_8.Tag = "p"
'
'_txtVitiExt_4
'
Me._txtVitiExt_4.AcceptsReturn = true
Me._txtVitiExt_4.BackColor = System.Drawing.Color.White
Me._txtVitiExt_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_4.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_4, CType(4,Short))
Me._txtVitiExt_4.Location = New System.Drawing.Point(168, 112)
Me._txtVitiExt_4.MaxLength = 0
Me._txtVitiExt_4.Name = "_txtVitiExt_4"
Me._txtVitiExt_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_4.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_4.TabIndex = 321
Me._txtVitiExt_4.Tag = "p"
'
'_txtVitiExt_10
'
Me._txtVitiExt_10.AcceptsReturn = true
Me._txtVitiExt_10.BackColor = System.Drawing.Color.Yellow
Me._txtVitiExt_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_10.Enabled = false
Me._txtVitiExt_10.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_10, CType(10,Short))
Me._txtVitiExt_10.Location = New System.Drawing.Point(168, 96)
Me._txtVitiExt_10.MaxLength = 0
Me._txtVitiExt_10.Name = "_txtVitiExt_10"
Me._txtVitiExt_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_10.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_10.TabIndex = 461
Me._txtVitiExt_10.Tag = "p"
'
'_txtVitiExt_9
'
Me._txtVitiExt_9.AcceptsReturn = true
Me._txtVitiExt_9.BackColor = System.Drawing.Color.Yellow
Me._txtVitiExt_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_9.Enabled = false
Me._txtVitiExt_9.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_9, CType(9,Short))
Me._txtVitiExt_9.Location = New System.Drawing.Point(168, 80)
Me._txtVitiExt_9.MaxLength = 0
Me._txtVitiExt_9.Name = "_txtVitiExt_9"
Me._txtVitiExt_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_9.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_9.TabIndex = 458
Me._txtVitiExt_9.Tag = "p"
'
'_txtVitiExt_3
'
Me._txtVitiExt_3.AcceptsReturn = true
Me._txtVitiExt_3.BackColor = System.Drawing.Color.White
Me._txtVitiExt_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_3.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_3, CType(3,Short))
Me._txtVitiExt_3.Location = New System.Drawing.Point(168, 64)
Me._txtVitiExt_3.MaxLength = 0
Me._txtVitiExt_3.Name = "_txtVitiExt_3"
Me._txtVitiExt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_3.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_3.TabIndex = 330
Me._txtVitiExt_3.Tag = "p"
'
'_txtVitiExt_2
'
Me._txtVitiExt_2.AcceptsReturn = true
Me._txtVitiExt_2.BackColor = System.Drawing.Color.Yellow
Me._txtVitiExt_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_2.Enabled = false
Me._txtVitiExt_2.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_2, CType(2,Short))
Me._txtVitiExt_2.Location = New System.Drawing.Point(168, 48)
Me._txtVitiExt_2.MaxLength = 0
Me._txtVitiExt_2.Name = "_txtVitiExt_2"
Me._txtVitiExt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_2.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_2.TabIndex = 319
Me._txtVitiExt_2.Tag = "p"
'
'_txtVitiExt_1
'
Me._txtVitiExt_1.AcceptsReturn = true
Me._txtVitiExt_1.BackColor = System.Drawing.Color.White
Me._txtVitiExt_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_1.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_1, CType(1,Short))
Me._txtVitiExt_1.Location = New System.Drawing.Point(168, 32)
Me._txtVitiExt_1.MaxLength = 0
Me._txtVitiExt_1.Name = "_txtVitiExt_1"
Me._txtVitiExt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_1.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_1.TabIndex = 320
Me._txtVitiExt_1.Tag = "p"
'
'_txtVitiExt_0
'
Me._txtVitiExt_0.AcceptsReturn = true
Me._txtVitiExt_0.BackColor = System.Drawing.Color.White
Me._txtVitiExt_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiExt_0.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiExt.SetIndex(Me._txtVitiExt_0, CType(0,Short))
Me._txtVitiExt_0.Location = New System.Drawing.Point(168, 16)
Me._txtVitiExt_0.MaxLength = 0
Me._txtVitiExt_0.Name = "_txtVitiExt_0"
Me._txtVitiExt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiExt_0.Size = New System.Drawing.Size(65, 20)
Me._txtVitiExt_0.TabIndex = 322
Me._txtVitiExt_0.Tag = "p"
'
'_lblMis_109
'
Me._lblMis_109.BackColor = System.Drawing.Color.Cyan
Me._lblMis_109.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_109.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_109.Location = New System.Drawing.Point(240, 96)
Me._lblMis_109.Name = "_lblMis_109"
Me._lblMis_109.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_109.Size = New System.Drawing.Size(24, 17)
Me._lblMis_109.TabIndex = 463
Me._lblMis_109.Text = "mm"
'
'_Label_130
'
Me._Label_130.AutoSize = true
Me._Label_130.BackColor = System.Drawing.SystemColors.Control
Me._Label_130.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_130.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_130.Location = New System.Drawing.Point(8, 96)
Me._Label_130.Name = "_Label_130"
Me._Label_130.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_130.Size = New System.Drawing.Size(92, 13)
Me._Label_130.TabIndex = 462
Me._Label_130.Text = "Spaziatura attuale"
'
'_lblMis_108
'
Me._lblMis_108.BackColor = System.Drawing.Color.Cyan
Me._lblMis_108.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_108.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_108.Location = New System.Drawing.Point(240, 80)
Me._lblMis_108.Name = "_lblMis_108"
Me._lblMis_108.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_108.Size = New System.Drawing.Size(24, 17)
Me._lblMis_108.TabIndex = 460
Me._lblMis_108.Text = "mm"
'
'_Label_129
'
Me._Label_129.AutoSize = true
Me._Label_129.BackColor = System.Drawing.SystemColors.Control
Me._Label_129.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_129.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_129.Location = New System.Drawing.Point(8, 80)
Me._Label_129.Name = "_Label_129"
Me._Label_129.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_129.Size = New System.Drawing.Size(92, 13)
Me._Label_129.TabIndex = 459
Me._Label_129.Text = "Spaziatura minima"
'
'_lblMis_101
'
Me._lblMis_101.BackColor = System.Drawing.Color.Cyan
Me._lblMis_101.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_101.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_101.Location = New System.Drawing.Point(240, 128)
Me._lblMis_101.Name = "_lblMis_101"
Me._lblMis_101.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_101.Size = New System.Drawing.Size(40, 17)
Me._lblMis_101.TabIndex = 437
Me._lblMis_101.Text = "mm"
'
'_Label_123
'
Me._Label_123.AutoSize = true
Me._Label_123.BackColor = System.Drawing.SystemColors.Control
Me._Label_123.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_123.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_123.Location = New System.Drawing.Point(8, 128)
Me._Label_123.Name = "_Label_123"
Me._Label_123.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_123.Size = New System.Drawing.Size(120, 13)
Me._Label_123.TabIndex = 436
Me._Label_123.Text = "Spostamento diaframma"
'
'_Label_87
'
Me._Label_87.AutoSize = true
Me._Label_87.BackColor = System.Drawing.SystemColors.Control
Me._Label_87.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_87.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_87.Location = New System.Drawing.Point(8, 64)
Me._Label_87.Name = "_Label_87"
Me._Label_87.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_87.Size = New System.Drawing.Size(82, 13)
Me._Label_87.TabIndex = 332
Me._Label_87.Text = "Diametro pistoni"
'
'_lblMis_73
'
Me._lblMis_73.BackColor = System.Drawing.Color.Cyan
Me._lblMis_73.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_73.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_73.Location = New System.Drawing.Point(240, 64)
Me._lblMis_73.Name = "_lblMis_73"
Me._lblMis_73.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_73.Size = New System.Drawing.Size(24, 17)
Me._lblMis_73.TabIndex = 331
Me._lblMis_73.Text = "mm"
'
'_Label_86
'
Me._Label_86.AutoSize = true
Me._Label_86.BackColor = System.Drawing.SystemColors.Control
Me._Label_86.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_86.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_86.Location = New System.Drawing.Point(8, 16)
Me._Label_86.Name = "_Label_86"
Me._Label_86.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_86.Size = New System.Drawing.Size(94, 13)
Me._Label_86.TabIndex = 329
Me._Label_86.Text = "Diametro nominale"
'
'_Label_85
'
Me._Label_85.AutoSize = true
Me._Label_85.BackColor = System.Drawing.SystemColors.Control
Me._Label_85.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_85.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_85.Location = New System.Drawing.Point(8, 112)
Me._Label_85.Name = "_Label_85"
Me._Label_85.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_85.Size = New System.Drawing.Size(44, 13)
Me._Label_85.TabIndex = 327
Me._Label_85.Text = "Numero"
'
'_Label_84
'
Me._Label_84.AutoSize = true
Me._Label_84.BackColor = System.Drawing.SystemColors.Control
Me._Label_84.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_84.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_84.Location = New System.Drawing.Point(8, 32)
Me._Label_84.Name = "_Label_84"
Me._Label_84.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_84.Size = New System.Drawing.Size(114, 13)
Me._Label_84.TabIndex = 326
Me._Label_84.Text = "Diametro di istallazione"
'
'_lblMis_71
'
Me._lblMis_71.BackColor = System.Drawing.Color.Cyan
Me._lblMis_71.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_71.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_71.Location = New System.Drawing.Point(240, 32)
Me._lblMis_71.Name = "_lblMis_71"
Me._lblMis_71.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_71.Size = New System.Drawing.Size(24, 17)
Me._lblMis_71.TabIndex = 325
Me._lblMis_71.Text = "mm"
'
'_Label_83
'
Me._Label_83.AutoSize = true
Me._Label_83.BackColor = System.Drawing.SystemColors.Control
Me._Label_83.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_83.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_83.Location = New System.Drawing.Point(8, 48)
Me._Label_83.Name = "_Label_83"
Me._Label_83.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_83.Size = New System.Drawing.Size(93, 13)
Me._Label_83.TabIndex = 324
Me._Label_83.Text = "Sezione resistente"
'
'_lblMis_70
'
Me._lblMis_70.BackColor = System.Drawing.Color.Cyan
Me._lblMis_70.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_70.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_70.Location = New System.Drawing.Point(240, 48)
Me._lblMis_70.Name = "_lblMis_70"
Me._lblMis_70.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_70.Size = New System.Drawing.Size(40, 17)
Me._lblMis_70.TabIndex = 323
Me._lblMis_70.Text = "mm2"
'
'framIntScr2
'
Me.framIntScr2.BackColor = System.Drawing.SystemColors.Control
Me.framIntScr2.Controls.Add(Me._txtVitiInt_6)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_4)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_10)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_9)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_3)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_2)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_1)
Me.framIntScr2.Controls.Add(Me._txtVitiInt_0)
Me.framIntScr2.Controls.Add(Me._cmdtir_1)
Me.framIntScr2.Controls.Add(Me._lblMis_107)
Me.framIntScr2.Controls.Add(Me._Label_128)
Me.framIntScr2.Controls.Add(Me._lblMis_106)
Me.framIntScr2.Controls.Add(Me._Label_127)
Me.framIntScr2.Controls.Add(Me._lblMis_100)
Me.framIntScr2.Controls.Add(Me._Label_122)
Me.framIntScr2.Controls.Add(Me._Label_82)
Me.framIntScr2.Controls.Add(Me._lblMis_69)
Me.framIntScr2.Controls.Add(Me._Label_81)
Me.framIntScr2.Controls.Add(Me._Label_80)
Me.framIntScr2.Controls.Add(Me._Label_79)
Me.framIntScr2.Controls.Add(Me._lblMis_67)
Me.framIntScr2.Controls.Add(Me._Label_78)
Me.framIntScr2.Controls.Add(Me._lblMis_66)
Me.framIntScr2.ForeColor = System.Drawing.Color.Blue
Me.framIntScr2.Location = New System.Drawing.Point(8, 8)
Me.framIntScr2.Name = "framIntScr2"
Me.framIntScr2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framIntScr2.Size = New System.Drawing.Size(289, 153)
Me.framIntScr2.TabIndex = 303
Me.framIntScr2.TabStop = false
Me.framIntScr2.Text = "Viti e pistoni su diametro interno"
'
'_txtVitiInt_6
'
Me._txtVitiInt_6.AcceptsReturn = true
Me._txtVitiInt_6.BackColor = System.Drawing.Color.White
Me._txtVitiInt_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_6.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_6, CType(6,Short))
Me._txtVitiInt_6.Location = New System.Drawing.Point(168, 128)
Me._txtVitiInt_6.MaxLength = 0
Me._txtVitiInt_6.Name = "_txtVitiInt_6"
Me._txtVitiInt_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_6.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_6.TabIndex = 432
Me._txtVitiInt_6.Tag = "p"
'
'_txtVitiInt_4
'
Me._txtVitiInt_4.AcceptsReturn = true
Me._txtVitiInt_4.BackColor = System.Drawing.Color.White
Me._txtVitiInt_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_4.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_4, CType(4,Short))
Me._txtVitiInt_4.Location = New System.Drawing.Point(168, 112)
Me._txtVitiInt_4.MaxLength = 0
Me._txtVitiInt_4.Name = "_txtVitiInt_4"
Me._txtVitiInt_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_4.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_4.TabIndex = 307
Me._txtVitiInt_4.Tag = "p"
'
'_txtVitiInt_10
'
Me._txtVitiInt_10.AcceptsReturn = true
Me._txtVitiInt_10.BackColor = System.Drawing.Color.Yellow
Me._txtVitiInt_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_10.Enabled = false
Me._txtVitiInt_10.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_10, CType(10,Short))
Me._txtVitiInt_10.Location = New System.Drawing.Point(168, 96)
Me._txtVitiInt_10.MaxLength = 0
Me._txtVitiInt_10.Name = "_txtVitiInt_10"
Me._txtVitiInt_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_10.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_10.TabIndex = 455
Me._txtVitiInt_10.Tag = "p"
'
'_txtVitiInt_9
'
Me._txtVitiInt_9.AcceptsReturn = true
Me._txtVitiInt_9.BackColor = System.Drawing.Color.Yellow
Me._txtVitiInt_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_9.Enabled = false
Me._txtVitiInt_9.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_9, CType(9,Short))
Me._txtVitiInt_9.Location = New System.Drawing.Point(168, 80)
Me._txtVitiInt_9.MaxLength = 0
Me._txtVitiInt_9.Name = "_txtVitiInt_9"
Me._txtVitiInt_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_9.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_9.TabIndex = 452
Me._txtVitiInt_9.Tag = "p"
'
'_txtVitiInt_3
'
Me._txtVitiInt_3.AcceptsReturn = true
Me._txtVitiInt_3.BackColor = System.Drawing.Color.White
Me._txtVitiInt_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_3.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_3, CType(3,Short))
Me._txtVitiInt_3.Location = New System.Drawing.Point(168, 64)
Me._txtVitiInt_3.MaxLength = 0
Me._txtVitiInt_3.Name = "_txtVitiInt_3"
Me._txtVitiInt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_3.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_3.TabIndex = 316
Me._txtVitiInt_3.Tag = "p"
'
'_txtVitiInt_2
'
Me._txtVitiInt_2.AcceptsReturn = true
Me._txtVitiInt_2.BackColor = System.Drawing.Color.Yellow
Me._txtVitiInt_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_2.Enabled = false
Me._txtVitiInt_2.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_2, CType(2,Short))
Me._txtVitiInt_2.Location = New System.Drawing.Point(168, 48)
Me._txtVitiInt_2.MaxLength = 0
Me._txtVitiInt_2.Name = "_txtVitiInt_2"
Me._txtVitiInt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_2.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_2.TabIndex = 305
Me._txtVitiInt_2.Tag = "p"
'
'_txtVitiInt_1
'
Me._txtVitiInt_1.AcceptsReturn = true
Me._txtVitiInt_1.BackColor = System.Drawing.Color.White
Me._txtVitiInt_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_1.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_1, CType(1,Short))
Me._txtVitiInt_1.Location = New System.Drawing.Point(168, 32)
Me._txtVitiInt_1.MaxLength = 0
Me._txtVitiInt_1.Name = "_txtVitiInt_1"
Me._txtVitiInt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_1.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_1.TabIndex = 306
Me._txtVitiInt_1.Tag = "p"
'
'_txtVitiInt_0
'
Me._txtVitiInt_0.AcceptsReturn = true
Me._txtVitiInt_0.BackColor = System.Drawing.Color.White
Me._txtVitiInt_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtVitiInt_0.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtVitiInt.SetIndex(Me._txtVitiInt_0, CType(0,Short))
Me._txtVitiInt_0.Location = New System.Drawing.Point(168, 16)
Me._txtVitiInt_0.MaxLength = 0
Me._txtVitiInt_0.Name = "_txtVitiInt_0"
Me._txtVitiInt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtVitiInt_0.Size = New System.Drawing.Size(65, 20)
Me._txtVitiInt_0.TabIndex = 308
Me._txtVitiInt_0.Tag = "p"
'
'_lblMis_107
'
Me._lblMis_107.BackColor = System.Drawing.Color.Cyan
Me._lblMis_107.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_107.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_107.Location = New System.Drawing.Point(240, 96)
Me._lblMis_107.Name = "_lblMis_107"
Me._lblMis_107.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_107.Size = New System.Drawing.Size(24, 17)
Me._lblMis_107.TabIndex = 457
Me._lblMis_107.Text = "mm"
'
'_Label_128
'
Me._Label_128.AutoSize = true
Me._Label_128.BackColor = System.Drawing.SystemColors.Control
Me._Label_128.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_128.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_128.Location = New System.Drawing.Point(8, 96)
Me._Label_128.Name = "_Label_128"
Me._Label_128.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_128.Size = New System.Drawing.Size(92, 13)
Me._Label_128.TabIndex = 456
Me._Label_128.Text = "Spaziatura attuale"
'
'_lblMis_106
'
Me._lblMis_106.BackColor = System.Drawing.Color.Cyan
Me._lblMis_106.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_106.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_106.Location = New System.Drawing.Point(240, 80)
Me._lblMis_106.Name = "_lblMis_106"
Me._lblMis_106.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_106.Size = New System.Drawing.Size(24, 17)
Me._lblMis_106.TabIndex = 454
Me._lblMis_106.Text = "mm"
'
'_Label_127
'
Me._Label_127.AutoSize = true
Me._Label_127.BackColor = System.Drawing.SystemColors.Control
Me._Label_127.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_127.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_127.Location = New System.Drawing.Point(8, 80)
Me._Label_127.Name = "_Label_127"
Me._Label_127.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_127.Size = New System.Drawing.Size(92, 13)
Me._Label_127.TabIndex = 453
Me._Label_127.Text = "Spaziatura minima"
'
'_lblMis_100
'
Me._lblMis_100.BackColor = System.Drawing.Color.Cyan
Me._lblMis_100.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_100.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_100.Location = New System.Drawing.Point(240, 128)
Me._lblMis_100.Name = "_lblMis_100"
Me._lblMis_100.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_100.Size = New System.Drawing.Size(24, 17)
Me._lblMis_100.TabIndex = 434
Me._lblMis_100.Text = "mm"
'
'_Label_122
'
Me._Label_122.AutoSize = true
Me._Label_122.BackColor = System.Drawing.SystemColors.Control
Me._Label_122.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_122.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_122.Location = New System.Drawing.Point(8, 128)
Me._Label_122.Name = "_Label_122"
Me._Label_122.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_122.Size = New System.Drawing.Size(120, 13)
Me._Label_122.TabIndex = 433
Me._Label_122.Text = "Spostamento diaframma"
'
'_Label_82
'
Me._Label_82.AutoSize = true
Me._Label_82.BackColor = System.Drawing.SystemColors.Control
Me._Label_82.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_82.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_82.Location = New System.Drawing.Point(8, 64)
Me._Label_82.Name = "_Label_82"
Me._Label_82.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_82.Size = New System.Drawing.Size(82, 13)
Me._Label_82.TabIndex = 318
Me._Label_82.Text = "Diametro pistoni"
'
'_lblMis_69
'
Me._lblMis_69.BackColor = System.Drawing.Color.Cyan
Me._lblMis_69.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_69.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_69.Location = New System.Drawing.Point(240, 64)
Me._lblMis_69.Name = "_lblMis_69"
Me._lblMis_69.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_69.Size = New System.Drawing.Size(24, 17)
Me._lblMis_69.TabIndex = 317
Me._lblMis_69.Text = "mm"
'
'_Label_81
'
Me._Label_81.AutoSize = true
Me._Label_81.BackColor = System.Drawing.SystemColors.Control
Me._Label_81.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_81.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_81.Location = New System.Drawing.Point(8, 16)
Me._Label_81.Name = "_Label_81"
Me._Label_81.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_81.Size = New System.Drawing.Size(94, 13)
Me._Label_81.TabIndex = 315
Me._Label_81.Text = "Diametro nominale"
'
'_Label_80
'
Me._Label_80.AutoSize = true
Me._Label_80.BackColor = System.Drawing.SystemColors.Control
Me._Label_80.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_80.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_80.Location = New System.Drawing.Point(8, 112)
Me._Label_80.Name = "_Label_80"
Me._Label_80.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_80.Size = New System.Drawing.Size(44, 13)
Me._Label_80.TabIndex = 313
Me._Label_80.Text = "Numero"
'
'_Label_79
'
Me._Label_79.AutoSize = true
Me._Label_79.BackColor = System.Drawing.SystemColors.Control
Me._Label_79.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_79.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_79.Location = New System.Drawing.Point(8, 32)
Me._Label_79.Name = "_Label_79"
Me._Label_79.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_79.Size = New System.Drawing.Size(114, 13)
Me._Label_79.TabIndex = 312
Me._Label_79.Text = "Diametro di istallazione"
'
'_lblMis_67
'
Me._lblMis_67.BackColor = System.Drawing.Color.Cyan
Me._lblMis_67.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_67.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_67.Location = New System.Drawing.Point(240, 32)
Me._lblMis_67.Name = "_lblMis_67"
Me._lblMis_67.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_67.Size = New System.Drawing.Size(24, 17)
Me._lblMis_67.TabIndex = 311
Me._lblMis_67.Text = "mm"
'
'_Label_78
'
Me._Label_78.AutoSize = true
Me._Label_78.BackColor = System.Drawing.SystemColors.Control
Me._Label_78.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_78.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_78.Location = New System.Drawing.Point(8, 48)
Me._Label_78.Name = "_Label_78"
Me._Label_78.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_78.Size = New System.Drawing.Size(93, 13)
Me._Label_78.TabIndex = 310
Me._Label_78.Text = "Sezione resistente"
'
'_lblMis_66
'
Me._lblMis_66.BackColor = System.Drawing.Color.Cyan
Me._lblMis_66.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_66.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_66.Location = New System.Drawing.Point(240, 48)
Me._lblMis_66.Name = "_lblMis_66"
Me._lblMis_66.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_66.Size = New System.Drawing.Size(40, 17)
Me._lblMis_66.TabIndex = 309
Me._lblMis_66.Text = "mm2"
'
'_cmdCalc_7
'
Me._cmdCalc_7.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_7.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_7.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_7.Location = New System.Drawing.Point(512, 288)
Me._cmdCalc_7.Name = "_cmdCalc_7"
Me._cmdCalc_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_7.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_7.TabIndex = 302
Me._cmdCalc_7.Text = "Calcola"
Me._cmdCalc_7.UseVisualStyleBackColor = false
'
'_pctFrames_2
'
Me._pctFrames_2.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_2.Controls.Add(Me._cmdCalc_2)
Me._pctFrames_2.Controls.Add(Me.framHTDiff)
Me._pctFrames_2.Controls.Add(Me.framPT)
Me._pctFrames_2.Controls.Add(Me.framTubes)
Me._pctFrames_2.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_2.Location = New System.Drawing.Point(5, 3)
Me._pctFrames_2.Name = "_pctFrames_2"
Me._pctFrames_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_2.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_2.TabIndex = 60
Me._pctFrames_2.TabStop = true
'
'_cmdCalc_2
'
Me._cmdCalc_2.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_2.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_2.Location = New System.Drawing.Point(512, 288)
Me._cmdCalc_2.Name = "_cmdCalc_2"
Me._cmdCalc_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_2.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_2.TabIndex = 142
Me._cmdCalc_2.Text = "Calcola"
Me._cmdCalc_2.UseVisualStyleBackColor = false
'
'framHTDiff
'
Me.framHTDiff.BackColor = System.Drawing.SystemColors.Control
Me.framHTDiff.Controls.Add(Me._txtPT_7)
Me.framHTDiff.Controls.Add(Me._Label_32)
Me.framHTDiff.Controls.Add(Me._lblMis_24)
Me.framHTDiff.ForeColor = System.Drawing.SystemColors.ControlText
Me.framHTDiff.Location = New System.Drawing.Point(8, 120)
Me.framHTDiff.Name = "framHTDiff"
Me.framHTDiff.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framHTDiff.Size = New System.Drawing.Size(289, 89)
Me.framHTDiff.TabIndex = 138
Me.framHTDiff.TabStop = false
Me.framHTDiff.Text = "Pressione differenziale in prova idraulica"
'
'_txtPT_7
'
Me._txtPT_7.AcceptsReturn = true
Me._txtPT_7.BackColor = System.Drawing.Color.White
Me._txtPT_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_7.Location = New System.Drawing.Point(168, 24)
Me._txtPT_7.MaxLength = 0
Me._txtPT_7.Name = "_txtPT_7"
Me._txtPT_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_7.Size = New System.Drawing.Size(65, 20)
Me._txtPT_7.TabIndex = 139
Me._txtPT_7.Tag = "p"
'
'_Label_32
'
Me._Label_32.AutoSize = true
Me._Label_32.BackColor = System.Drawing.SystemColors.Control
Me._Label_32.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_32.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_32.Location = New System.Drawing.Point(8, 24)
Me._Label_32.Name = "_Label_32"
Me._Label_32.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_32.Size = New System.Drawing.Size(115, 13)
Me._Label_32.TabIndex = 141
Me._Label_32.Text = "Pressione lato mantello"
'
'_lblMis_24
'
Me._lblMis_24.BackColor = System.Drawing.Color.Cyan
Me._lblMis_24.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_24.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_24.Location = New System.Drawing.Point(240, 24)
Me._lblMis_24.Name = "_lblMis_24"
Me._lblMis_24.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_24.Size = New System.Drawing.Size(40, 17)
Me._lblMis_24.TabIndex = 140
Me._lblMis_24.Text = "MPa"
'
'framPT
'
Me.framPT.BackColor = System.Drawing.SystemColors.Control
Me.framPT.Controls.Add(Me._txtPT_6)
Me.framPT.Controls.Add(Me._txtPT_5)
Me.framPT.Controls.Add(Me._txtPT_4)
Me.framPT.Controls.Add(Me._txtPT_3)
Me.framPT.Controls.Add(Me._txtPT_2)
Me.framPT.Controls.Add(Me._txtPT_8)
Me.framPT.Controls.Add(Me._txtPT_9)
Me.framPT.Controls.Add(Me.Label20)
Me.framPT.Controls.Add(Me.Label21)
Me.framPT.Controls.Add(Me.Label22)
Me.framPT.Controls.Add(Me.Label23)
Me.framPT.Controls.Add(Me._Label_31)
Me.framPT.Controls.Add(Me._lblMis_23)
Me.framPT.Controls.Add(Me._Label_30)
Me.framPT.Controls.Add(Me._lblMis_22)
Me.framPT.Controls.Add(Me._Label_29)
Me.framPT.Controls.Add(Me._lblMis_21)
Me.framPT.Controls.Add(Me._Label_28)
Me.framPT.Controls.Add(Me._lblMis_20)
Me.framPT.Controls.Add(Me._Label_27)
Me.framPT.Controls.Add(Me._lblMis_19)
Me.framPT.ForeColor = System.Drawing.Color.Blue
Me.framPT.Location = New System.Drawing.Point(304, 8)
Me.framPT.Name = "framPT"
Me.framPT.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framPT.Size = New System.Drawing.Size(281, 152)
Me.framPT.TabIndex = 122
Me.framPT.TabStop = false
Me.framPT.Text = "Piastra tubiera"
'
'_txtPT_6
'
Me._txtPT_6.AcceptsReturn = true
Me._txtPT_6.BackColor = System.Drawing.Color.White
Me._txtPT_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_6.Location = New System.Drawing.Point(168, 128)
Me._txtPT_6.MaxLength = 0
Me._txtPT_6.Name = "_txtPT_6"
Me._txtPT_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_6.Size = New System.Drawing.Size(65, 20)
Me._txtPT_6.TabIndex = 135
Me._txtPT_6.Tag = "p"
'
'_txtPT_5
'
Me._txtPT_5.AcceptsReturn = true
Me._txtPT_5.BackColor = System.Drawing.Color.Yellow
Me._txtPT_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_5.Enabled = false
Me._txtPT_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_5.Location = New System.Drawing.Point(168, 112)
Me._txtPT_5.MaxLength = 0
Me._txtPT_5.Name = "_txtPT_5"
Me._txtPT_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_5.Size = New System.Drawing.Size(65, 20)
Me._txtPT_5.TabIndex = 132
Me._txtPT_5.Tag = "p"
'
'_txtPT_4
'
Me._txtPT_4.AcceptsReturn = true
Me._txtPT_4.BackColor = System.Drawing.Color.White
Me._txtPT_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_4.Location = New System.Drawing.Point(168, 96)
Me._txtPT_4.MaxLength = 0
Me._txtPT_4.Name = "_txtPT_4"
Me._txtPT_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_4.Size = New System.Drawing.Size(65, 20)
Me._txtPT_4.TabIndex = 129
Me._txtPT_4.Tag = "p"
'
'_txtPT_3
'
Me._txtPT_3.AcceptsReturn = true
Me._txtPT_3.BackColor = System.Drawing.Color.White
Me._txtPT_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_3.Location = New System.Drawing.Point(168, 80)
Me._txtPT_3.MaxLength = 0
Me._txtPT_3.Name = "_txtPT_3"
Me._txtPT_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_3.Size = New System.Drawing.Size(65, 20)
Me._txtPT_3.TabIndex = 126
Me._txtPT_3.Tag = "p"
'
'_txtPT_2
'
Me._txtPT_2.AcceptsReturn = true
Me._txtPT_2.BackColor = System.Drawing.Color.White
Me._txtPT_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_2.Location = New System.Drawing.Point(168, 64)
Me._txtPT_2.MaxLength = 0
Me._txtPT_2.Name = "_txtPT_2"
Me._txtPT_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_2.Size = New System.Drawing.Size(65, 20)
Me._txtPT_2.TabIndex = 123
Me._txtPT_2.Tag = "p"
'
'_txtPT_8
'
Me._txtPT_8.AcceptsReturn = true
Me._txtPT_8.BackColor = System.Drawing.Color.White
Me._txtPT_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_8.Location = New System.Drawing.Point(168, 48)
Me._txtPT_8.MaxLength = 0
Me._txtPT_8.Name = "_txtPT_8"
Me._txtPT_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_8.Size = New System.Drawing.Size(65, 20)
Me._txtPT_8.TabIndex = 141
Me._txtPT_8.Tag = "p"
'
'_txtPT_9
'
Me._txtPT_9.AcceptsReturn = true
Me._txtPT_9.BackColor = System.Drawing.Color.White
Me._txtPT_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_9.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_9.Location = New System.Drawing.Point(168, 32)
Me._txtPT_9.MaxLength = 0
Me._txtPT_9.Name = "_txtPT_9"
Me._txtPT_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_9.Size = New System.Drawing.Size(65, 20)
Me._txtPT_9.TabIndex = 138
Me._txtPT_9.Tag = "p"
'
'Label20
'
Me.Label20.AutoSize = true
Me.Label20.BackColor = System.Drawing.SystemColors.Control
Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label20.Location = New System.Drawing.Point(8, 48)
Me.Label20.Name = "Label20"
Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label20.Size = New System.Drawing.Size(82, 13)
Me.Label20.TabIndex = 143
Me.Label20.Text = "Spessore cassa"
'
'Label21
'
Me.Label21.BackColor = System.Drawing.Color.Cyan
Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label21.Location = New System.Drawing.Point(240, 48)
Me.Label21.Name = "Label21"
Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label21.Size = New System.Drawing.Size(40, 17)
Me.Label21.TabIndex = 142
Me.Label21.Text = "mm"
'
'Label22
'
Me.Label22.AutoSize = true
Me.Label22.BackColor = System.Drawing.SystemColors.Control
Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label22.Location = New System.Drawing.Point(8, 32)
Me.Label22.Name = "Label22"
Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label22.Size = New System.Drawing.Size(115, 13)
Me.Label22.TabIndex = 140
Me.Label22.Text = "Diametro interno cassa"
'
'Label23
'
Me.Label23.BackColor = System.Drawing.Color.Cyan
Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label23.Location = New System.Drawing.Point(240, 32)
Me.Label23.Name = "Label23"
Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label23.Size = New System.Drawing.Size(40, 17)
Me.Label23.TabIndex = 139
Me.Label23.Text = "mm"
'
'_Label_31
'
Me._Label_31.AutoSize = true
Me._Label_31.BackColor = System.Drawing.SystemColors.Control
Me._Label_31.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_31.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_31.Location = New System.Drawing.Point(8, 128)
Me._Label_31.Name = "_Label_31"
Me._Label_31.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_31.Size = New System.Drawing.Size(93, 13)
Me._Label_31.TabIndex = 137
Me._Label_31.Text = "Spessore adottato"
'
'_lblMis_23
'
Me._lblMis_23.BackColor = System.Drawing.Color.Cyan
Me._lblMis_23.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_23.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_23.Location = New System.Drawing.Point(240, 128)
Me._lblMis_23.Name = "_lblMis_23"
Me._lblMis_23.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_23.Size = New System.Drawing.Size(40, 17)
Me._lblMis_23.TabIndex = 136
Me._lblMis_23.Text = "mm"
'
'_Label_30
'
Me._Label_30.AutoSize = true
Me._Label_30.BackColor = System.Drawing.SystemColors.Control
Me._Label_30.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_30.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_30.Location = New System.Drawing.Point(8, 112)
Me._Label_30.Name = "_Label_30"
Me._Label_30.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_30.Size = New System.Drawing.Size(134, 13)
Me._Label_30.TabIndex = 134
Me._Label_30.Text = "Spessore minimo di calcolo"
'
'_lblMis_22
'
Me._lblMis_22.BackColor = System.Drawing.Color.Cyan
Me._lblMis_22.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_22.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_22.Location = New System.Drawing.Point(240, 112)
Me._lblMis_22.Name = "_lblMis_22"
Me._lblMis_22.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_22.Size = New System.Drawing.Size(40, 17)
Me._lblMis_22.TabIndex = 133
Me._lblMis_22.Text = "mm"
'
'_Label_29
'
Me._Label_29.AutoSize = true
Me._Label_29.BackColor = System.Drawing.SystemColors.Control
Me._Label_29.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_29.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_29.Location = New System.Drawing.Point(8, 96)
Me._Label_29.Name = "_Label_29"
Me._Label_29.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_29.Size = New System.Drawing.Size(82, 13)
Me._Label_29.TabIndex = 131
Me._Label_29.Text = "Profondità cava"
'
'_lblMis_21
'
Me._lblMis_21.BackColor = System.Drawing.Color.Cyan
Me._lblMis_21.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_21.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_21.Location = New System.Drawing.Point(240, 96)
Me._lblMis_21.Name = "_lblMis_21"
Me._lblMis_21.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_21.Size = New System.Drawing.Size(40, 17)
Me._lblMis_21.TabIndex = 130
Me._lblMis_21.Text = "mm"
'
'_Label_28
'
Me._Label_28.AutoSize = true
Me._Label_28.BackColor = System.Drawing.SystemColors.Control
Me._Label_28.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_28.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_28.Location = New System.Drawing.Point(8, 80)
Me._Label_28.Name = "_Label_28"
Me._Label_28.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_28.Size = New System.Drawing.Size(136, 13)
Me._Label_28.TabIndex = 128
Me._Label_28.Text = "Corrosione PT lato mantello"
'
'_lblMis_20
'
Me._lblMis_20.BackColor = System.Drawing.Color.Cyan
Me._lblMis_20.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_20.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_20.Location = New System.Drawing.Point(240, 80)
Me._lblMis_20.Name = "_lblMis_20"
Me._lblMis_20.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_20.Size = New System.Drawing.Size(40, 17)
Me._lblMis_20.TabIndex = 127
Me._lblMis_20.Text = "mm"
'
'_Label_27
'
Me._Label_27.AutoSize = true
Me._Label_27.BackColor = System.Drawing.SystemColors.Control
Me._Label_27.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_27.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_27.Location = New System.Drawing.Point(8, 64)
Me._Label_27.Name = "_Label_27"
Me._Label_27.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_27.Size = New System.Drawing.Size(114, 13)
Me._Label_27.TabIndex = 125
Me._Label_27.Text = "Corrosione PT lato tubi"
'
'_lblMis_19
'
Me._lblMis_19.BackColor = System.Drawing.Color.Cyan
Me._lblMis_19.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_19.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_19.Location = New System.Drawing.Point(240, 64)
Me._lblMis_19.Name = "_lblMis_19"
Me._lblMis_19.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_19.Size = New System.Drawing.Size(40, 17)
Me._lblMis_19.TabIndex = 124
Me._lblMis_19.Text = "mm"
'
'framTubes
'
Me.framTubes.BackColor = System.Drawing.SystemColors.Control
Me.framTubes.Controls.Add(Me._optPasso_1)
Me.framTubes.Controls.Add(Me._optPasso_0)
Me.framTubes.Controls.Add(Me._txtPT_1)
Me.framTubes.Controls.Add(Me._txtPT_0)
Me.framTubes.Controls.Add(Me._Label_26)
Me.framTubes.Controls.Add(Me._lblMis_18)
Me.framTubes.Controls.Add(Me._Label_25)
Me.framTubes.Controls.Add(Me._lblMis_17)
Me.framTubes.ForeColor = System.Drawing.Color.Blue
Me.framTubes.Location = New System.Drawing.Point(8, 8)
Me.framTubes.Name = "framTubes"
Me.framTubes.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framTubes.Size = New System.Drawing.Size(289, 113)
Me.framTubes.TabIndex = 113
Me.framTubes.TabStop = false
Me.framTubes.Text = "Tubi di scambio"
'
'_optPasso_1
'
Me._optPasso_1.BackColor = System.Drawing.SystemColors.Control
Me._optPasso_1.Cursor = System.Windows.Forms.Cursors.Default
Me._optPasso_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._optPasso_1.Location = New System.Drawing.Point(136, 48)
Me._optPasso_1.Name = "_optPasso_1"
Me._optPasso_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optPasso_1.Size = New System.Drawing.Size(145, 17)
Me._optPasso_1.TabIndex = 121
Me._optPasso_1.TabStop = true
Me._optPasso_1.Text = "Passo quadrato"
Me._optPasso_1.UseVisualStyleBackColor = false
'
'_optPasso_0
'
Me._optPasso_0.BackColor = System.Drawing.SystemColors.Control
Me._optPasso_0.Checked = true
Me._optPasso_0.Cursor = System.Windows.Forms.Cursors.Default
Me._optPasso_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._optPasso_0.Location = New System.Drawing.Point(8, 48)
Me._optPasso_0.Name = "_optPasso_0"
Me._optPasso_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._optPasso_0.Size = New System.Drawing.Size(145, 17)
Me._optPasso_0.TabIndex = 120
Me._optPasso_0.TabStop = true
Me._optPasso_0.Text = "Passo triangolare"
Me._optPasso_0.UseVisualStyleBackColor = false
'
'_txtPT_1
'
Me._txtPT_1.AcceptsReturn = true
Me._txtPT_1.BackColor = System.Drawing.Color.White
Me._txtPT_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_1.Location = New System.Drawing.Point(168, 32)
Me._txtPT_1.MaxLength = 0
Me._txtPT_1.Name = "_txtPT_1"
Me._txtPT_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_1.Size = New System.Drawing.Size(65, 20)
Me._txtPT_1.TabIndex = 117
Me._txtPT_1.Tag = "p"
'
'_txtPT_0
'
Me._txtPT_0.AcceptsReturn = true
Me._txtPT_0.BackColor = System.Drawing.Color.White
Me._txtPT_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtPT_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtPT_0.Location = New System.Drawing.Point(168, 16)
Me._txtPT_0.MaxLength = 0
Me._txtPT_0.Name = "_txtPT_0"
Me._txtPT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtPT_0.Size = New System.Drawing.Size(65, 20)
Me._txtPT_0.TabIndex = 114
Me._txtPT_0.Tag = "p"
'
'_Label_26
'
Me._Label_26.AutoSize = true
Me._Label_26.BackColor = System.Drawing.SystemColors.Control
Me._Label_26.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_26.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_26.Location = New System.Drawing.Point(8, 32)
Me._Label_26.Name = "_Label_26"
Me._Label_26.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_26.Size = New System.Drawing.Size(89, 13)
Me._Label_26.TabIndex = 119
Me._Label_26.Text = "Passo tracciatura"
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
Me._lblMis_18.TabIndex = 118
Me._lblMis_18.Text = "mm"
'
'_Label_25
'
Me._Label_25.AutoSize = true
Me._Label_25.BackColor = System.Drawing.SystemColors.Control
Me._Label_25.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_25.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_25.Location = New System.Drawing.Point(8, 16)
Me._Label_25.Name = "_Label_25"
Me._Label_25.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_25.Size = New System.Drawing.Size(107, 13)
Me._Label_25.TabIndex = 116
Me._Label_25.Text = "Diametro esterno tubi"
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
Me._lblMis_17.TabIndex = 115
Me._lblMis_17.Text = "mm"
'
'_pctFrames_8
'
Me._pctFrames_8.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_8.Controls.Add(Me.Frame6)
Me._pctFrames_8.Controls.Add(Me.Frame5)
Me._pctFrames_8.Controls.Add(Me.Frame4)
Me._pctFrames_8.Controls.Add(Me.Frame3)
Me._pctFrames_8.Controls.Add(Me._cmdCalc_8)
Me._pctFrames_8.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_8.Location = New System.Drawing.Point(5, 3)
Me._pctFrames_8.Name = "_pctFrames_8"
Me._pctFrames_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_8.Size = New System.Drawing.Size(593, 365)
Me._pctFrames_8.TabIndex = 301
Me._pctFrames_8.TabStop = true
'
'Frame6
'
Me.Frame6.BackColor = System.Drawing.SystemColors.Control
Me.Frame6.Controls.Add(Me._txtLR_13)
Me.Frame6.Controls.Add(Me._txtLR_15)
Me.Frame6.Controls.Add(Me._txtLR_14)
Me.Frame6.Controls.Add(Me._txtLR_17)
Me.Frame6.Controls.Add(Me._txtLR_16)
Me.Frame6.Controls.Add(Me._lblMis_97)
Me.Frame6.Controls.Add(Me._Label_116)
Me.Frame6.Controls.Add(Me._lblMis_96)
Me.Frame6.Controls.Add(Me._Label_115)
Me.Frame6.Controls.Add(Me._lblMis_95)
Me.Frame6.Controls.Add(Me._Label_114)
Me.Frame6.Controls.Add(Me._lblMis_94)
Me.Frame6.Controls.Add(Me._Label_113)
Me.Frame6.Controls.Add(Me._Label_112)
Me.Frame6.Controls.Add(Me._lblMis_93)
Me.Frame6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Frame6.Location = New System.Drawing.Point(8, 112)
Me.Frame6.Name = "Frame6"
Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Frame6.Size = New System.Drawing.Size(289, 121)
Me.Frame6.TabIndex = 386
Me.Frame6.TabStop = false
Me.Frame6.Text = "Coperchio piano"
'
'_txtLR_13
'
Me._txtLR_13.AcceptsReturn = true
Me._txtLR_13.BackColor = System.Drawing.Color.White
Me._txtLR_13.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_13.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_13.Location = New System.Drawing.Point(168, 16)
Me._txtLR_13.MaxLength = 0
Me._txtLR_13.Name = "_txtLR_13"
Me._txtLR_13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_13.Size = New System.Drawing.Size(65, 20)
Me._txtLR_13.TabIndex = 396
Me._txtLR_13.Tag = "p"
'
'_txtLR_15
'
Me._txtLR_15.AcceptsReturn = true
Me._txtLR_15.BackColor = System.Drawing.Color.Yellow
Me._txtLR_15.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_15.Enabled = false
Me._txtLR_15.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_15.Location = New System.Drawing.Point(168, 32)
Me._txtLR_15.MaxLength = 0
Me._txtLR_15.Name = "_txtLR_15"
Me._txtLR_15.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_15.Size = New System.Drawing.Size(65, 20)
Me._txtLR_15.TabIndex = 401
Me._txtLR_15.Tag = "p"
'
'_txtLR_14
'
Me._txtLR_14.AcceptsReturn = true
Me._txtLR_14.BackColor = System.Drawing.Color.White
Me._txtLR_14.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_14.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_14.Location = New System.Drawing.Point(168, 48)
Me._txtLR_14.MaxLength = 0
Me._txtLR_14.Name = "_txtLR_14"
Me._txtLR_14.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_14.Size = New System.Drawing.Size(65, 20)
Me._txtLR_14.TabIndex = 400
Me._txtLR_14.Tag = "p"
'
'_txtLR_17
'
Me._txtLR_17.AcceptsReturn = true
Me._txtLR_17.BackColor = System.Drawing.Color.Yellow
Me._txtLR_17.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_17.Enabled = false
Me._txtLR_17.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_17.Location = New System.Drawing.Point(168, 64)
Me._txtLR_17.MaxLength = 0
Me._txtLR_17.Name = "_txtLR_17"
Me._txtLR_17.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_17.Size = New System.Drawing.Size(65, 20)
Me._txtLR_17.TabIndex = 407
Me._txtLR_17.Tag = "p"
'
'_txtLR_16
'
Me._txtLR_16.AcceptsReturn = true
Me._txtLR_16.BackColor = System.Drawing.Color.White
Me._txtLR_16.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_16.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_16.Location = New System.Drawing.Point(168, 80)
Me._txtLR_16.MaxLength = 0
Me._txtLR_16.Name = "_txtLR_16"
Me._txtLR_16.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_16.Size = New System.Drawing.Size(65, 20)
Me._txtLR_16.TabIndex = 406
Me._txtLR_16.Tag = "p"
'
'_lblMis_97
'
Me._lblMis_97.BackColor = System.Drawing.Color.Cyan
Me._lblMis_97.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_97.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_97.Location = New System.Drawing.Point(240, 64)
Me._lblMis_97.Name = "_lblMis_97"
Me._lblMis_97.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_97.Size = New System.Drawing.Size(40, 17)
Me._lblMis_97.TabIndex = 411
Me._lblMis_97.Text = "mm"
'
'_Label_116
'
Me._Label_116.AutoSize = true
Me._Label_116.BackColor = System.Drawing.SystemColors.Control
Me._Label_116.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_116.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_116.Location = New System.Drawing.Point(8, 64)
Me._Label_116.Name = "_Label_116"
Me._Label_116.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_116.Size = New System.Drawing.Size(147, 13)
Me._Label_116.TabIndex = 410
Me._Label_116.Text = "Spessore min. corona esterna"
'
'_lblMis_96
'
Me._lblMis_96.BackColor = System.Drawing.Color.Cyan
Me._lblMis_96.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_96.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_96.Location = New System.Drawing.Point(240, 80)
Me._lblMis_96.Name = "_lblMis_96"
Me._lblMis_96.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_96.Size = New System.Drawing.Size(40, 17)
Me._lblMis_96.TabIndex = 409
Me._lblMis_96.Text = "mm"
'
'_Label_115
'
Me._Label_115.AutoSize = true
Me._Label_115.BackColor = System.Drawing.SystemColors.Control
Me._Label_115.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_115.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_115.Location = New System.Drawing.Point(8, 80)
Me._Label_115.Name = "_Label_115"
Me._Label_115.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_115.Size = New System.Drawing.Size(149, 13)
Me._Label_115.TabIndex = 408
Me._Label_115.Text = "Spessore adottato corona est."
'
'_lblMis_95
'
Me._lblMis_95.BackColor = System.Drawing.Color.Cyan
Me._lblMis_95.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_95.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_95.Location = New System.Drawing.Point(240, 32)
Me._lblMis_95.Name = "_lblMis_95"
Me._lblMis_95.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_95.Size = New System.Drawing.Size(40, 17)
Me._lblMis_95.TabIndex = 405
Me._lblMis_95.Text = "mm"
'
'_Label_114
'
Me._Label_114.AutoSize = true
Me._Label_114.BackColor = System.Drawing.SystemColors.Control
Me._Label_114.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_114.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_114.Location = New System.Drawing.Point(8, 32)
Me._Label_114.Name = "_Label_114"
Me._Label_114.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_114.Size = New System.Drawing.Size(134, 13)
Me._Label_114.TabIndex = 404
Me._Label_114.Text = "Spessore minimo di calcolo"
'
'_lblMis_94
'
Me._lblMis_94.BackColor = System.Drawing.Color.Cyan
Me._lblMis_94.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_94.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_94.Location = New System.Drawing.Point(240, 48)
Me._lblMis_94.Name = "_lblMis_94"
Me._lblMis_94.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_94.Size = New System.Drawing.Size(40, 17)
Me._lblMis_94.TabIndex = 403
Me._lblMis_94.Text = "mm"
'
'_Label_113
'
Me._Label_113.AutoSize = true
Me._Label_113.BackColor = System.Drawing.SystemColors.Control
Me._Label_113.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_113.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_113.Location = New System.Drawing.Point(8, 48)
Me._Label_113.Name = "_Label_113"
Me._Label_113.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_113.Size = New System.Drawing.Size(93, 13)
Me._Label_113.TabIndex = 402
Me._Label_113.Text = "Spessore adottato"
'
'_Label_112
'
Me._Label_112.AutoSize = true
Me._Label_112.BackColor = System.Drawing.SystemColors.Control
Me._Label_112.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_112.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_112.Location = New System.Drawing.Point(8, 16)
Me._Label_112.Name = "_Label_112"
Me._Label_112.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_112.Size = New System.Drawing.Size(87, 13)
Me._Label_112.TabIndex = 398
Me._Label_112.Text = "Diametro esterno"
'
'_lblMis_93
'
Me._lblMis_93.BackColor = System.Drawing.Color.Cyan
Me._lblMis_93.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_93.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_93.Location = New System.Drawing.Point(240, 16)
Me._lblMis_93.Name = "_lblMis_93"
Me._lblMis_93.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_93.Size = New System.Drawing.Size(40, 17)
Me._lblMis_93.TabIndex = 397
Me._lblMis_93.Text = "mm"
'
'Frame5
'
Me.Frame5.BackColor = System.Drawing.SystemColors.Control
Me.Frame5.Controls.Add(Me.chkSuperSafe)
Me.Frame5.Controls.Add(Me._txtLR_23)
Me.Frame5.Controls.Add(Me.Label14)
Me.Frame5.Controls.Add(Me.Label15)
Me.Frame5.Controls.Add(Me._txtLR_22)
Me.Frame5.Controls.Add(Me._txtLR_21)
Me.Frame5.Controls.Add(Me._txtLR_20)
Me.Frame5.Controls.Add(Me._txtLR_19)
Me.Frame5.Controls.Add(Me._txtLR_18)
Me.Frame5.Controls.Add(Me.chkDeltaT)
Me.Frame5.Controls.Add(Me.cmbPrecis)
Me.Frame5.Controls.Add(Me.cmbTipoFil)
Me.Frame5.Controls.Add(Me._txtLR_12)
Me.Frame5.Controls.Add(Me._txtLR_11)
Me.Frame5.Controls.Add(Me._txtLR_10)
Me.Frame5.Controls.Add(Me._txtLR_8)
Me.Frame5.Controls.Add(Me._txtLR_3)
Me.Frame5.Controls.Add(Me._txtLR_2)
Me.Frame5.Controls.Add(Me._txtLR_1)
Me.Frame5.Controls.Add(Me._Label_121)
Me.Frame5.Controls.Add(Me._lblMis_99)
Me.Frame5.Controls.Add(Me._lblMis_92)
Me.Frame5.Controls.Add(Me._Label_120)
Me.Frame5.Controls.Add(Me._lblMis_91)
Me.Frame5.Controls.Add(Me._Label_119)
Me.Frame5.Controls.Add(Me._lblMis_90)
Me.Frame5.Controls.Add(Me._Label_118)
Me.Frame5.Controls.Add(Me._lblMis_98)
Me.Frame5.Controls.Add(Me._Label_117)
Me.Frame5.Controls.Add(Me.lblPrecis)
Me.Frame5.Controls.Add(Me.lbltipofil)
Me.Frame5.Controls.Add(Me.lblFiletti)
Me.Frame5.Controls.Add(Me._Label_111)
Me.Frame5.Controls.Add(Me._Label_110)
Me.Frame5.Controls.Add(Me._Label_109)
Me.Frame5.Controls.Add(Me._Label_107)
Me.Frame5.Controls.Add(Me._lblMis_88)
Me.Frame5.Controls.Add(Me._Label_97)
Me.Frame5.Controls.Add(Me._lblMis_83)
Me.Frame5.Controls.Add(Me._Label_96)
Me.Frame5.Controls.Add(Me._lblMis_82)
Me.Frame5.Controls.Add(Me._Label_95)
Me.Frame5.Controls.Add(Me._lblMis_81)
Me.Frame5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Frame5.Location = New System.Drawing.Point(296, 8)
Me.Frame5.Name = "Frame5"
Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Frame5.Size = New System.Drawing.Size(289, 328)
Me.Frame5.TabIndex = 367
Me.Frame5.TabStop = false
Me.Frame5.Text = "Filettatura"
'
'_txtLR_23
'
Me._txtLR_23.AcceptsReturn = true
Me._txtLR_23.BackColor = System.Drawing.Color.Yellow
Me._txtLR_23.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_23.Enabled = false
Me._txtLR_23.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_23.Location = New System.Drawing.Point(168, 248)
Me._txtLR_23.MaxLength = 0
Me._txtLR_23.Name = "_txtLR_23"
Me._txtLR_23.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_23.Size = New System.Drawing.Size(65, 20)
Me._txtLR_23.TabIndex = 432
Me._txtLR_23.Tag = "p"
'
'Label14
'
Me.Label14.BackColor = System.Drawing.Color.Cyan
Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label14.Location = New System.Drawing.Point(240, 248)
Me.Label14.Name = "Label14"
Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label14.Size = New System.Drawing.Size(40, 17)
Me.Label14.TabIndex = 434
Me.Label14.Text = "mm"
'
'Label15
'
Me.Label15.AutoSize = true
Me.Label15.BackColor = System.Drawing.SystemColors.Control
Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label15.Location = New System.Drawing.Point(8, 248)
Me.Label15.Name = "Label15"
Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label15.Size = New System.Drawing.Size(138, 13)
Me.Label15.TabIndex = 433
Me.Label15.Text = "Altezza filetto in presa (leak)"
'
'_txtLR_22
'
Me._txtLR_22.AcceptsReturn = true
Me._txtLR_22.BackColor = System.Drawing.Color.Yellow
Me._txtLR_22.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_22.Enabled = false
Me._txtLR_22.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_22.Location = New System.Drawing.Point(168, 264)
Me._txtLR_22.MaxLength = 0
Me._txtLR_22.Name = "_txtLR_22"
Me._txtLR_22.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_22.Size = New System.Drawing.Size(65, 20)
Me._txtLR_22.TabIndex = 429
Me._txtLR_22.Tag = "p"
'
'_txtLR_21
'
Me._txtLR_21.AcceptsReturn = true
Me._txtLR_21.BackColor = System.Drawing.Color.White
Me._txtLR_21.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_21.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_21.Location = New System.Drawing.Point(216, 160)
Me._txtLR_21.MaxLength = 0
Me._txtLR_21.Name = "_txtLR_21"
Me._txtLR_21.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_21.Size = New System.Drawing.Size(41, 20)
Me._txtLR_21.TabIndex = 427
Me._txtLR_21.Tag = "p"
'
'_txtLR_20
'
Me._txtLR_20.AcceptsReturn = true
Me._txtLR_20.BackColor = System.Drawing.Color.White
Me._txtLR_20.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_20.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_20.Location = New System.Drawing.Point(80, 160)
Me._txtLR_20.MaxLength = 0
Me._txtLR_20.Name = "_txtLR_20"
Me._txtLR_20.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_20.Size = New System.Drawing.Size(41, 20)
Me._txtLR_20.TabIndex = 424
Me._txtLR_20.Tag = "p"
'
'_txtLR_19
'
Me._txtLR_19.AcceptsReturn = true
Me._txtLR_19.BackColor = System.Drawing.Color.White
Me._txtLR_19.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_19.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_19.Location = New System.Drawing.Point(168, 99)
Me._txtLR_19.MaxLength = 0
Me._txtLR_19.Name = "_txtLR_19"
Me._txtLR_19.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_19.Size = New System.Drawing.Size(65, 20)
Me._txtLR_19.TabIndex = 420
Me._txtLR_19.Tag = "p"
'
'_txtLR_18
'
Me._txtLR_18.AcceptsReturn = true
Me._txtLR_18.BackColor = System.Drawing.Color.Yellow
Me._txtLR_18.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_18.Enabled = false
Me._txtLR_18.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_18.Location = New System.Drawing.Point(168, 232)
Me._txtLR_18.MaxLength = 0
Me._txtLR_18.Name = "_txtLR_18"
Me._txtLR_18.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_18.Size = New System.Drawing.Size(65, 20)
Me._txtLR_18.TabIndex = 417
Me._txtLR_18.Tag = "p"
'
'chkDeltaT
'
Me.chkDeltaT.BackColor = System.Drawing.SystemColors.Control
Me.chkDeltaT.Cursor = System.Windows.Forms.Cursors.Default
Me.chkDeltaT.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkDeltaT.Location = New System.Drawing.Point(8, 140)
Me.chkDeltaT.Name = "chkDeltaT"
Me.chkDeltaT.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkDeltaT.Size = New System.Drawing.Size(201, 18)
Me.chkDeltaT.TabIndex = 416
Me.chkDeltaT.Text = "Differenziale di temperatura"
Me.chkDeltaT.UseVisualStyleBackColor = false
'
'cmbPrecis
'
Me.cmbPrecis.BackColor = System.Drawing.SystemColors.Window
Me.cmbPrecis.Cursor = System.Windows.Forms.Cursors.Default
Me.cmbPrecis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbPrecis.ForeColor = System.Drawing.SystemColors.WindowText
Me.cmbPrecis.Location = New System.Drawing.Point(232, 80)
Me.cmbPrecis.Name = "cmbPrecis"
Me.cmbPrecis.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmbPrecis.Size = New System.Drawing.Size(49, 21)
Me.cmbPrecis.TabIndex = 414
'
'cmbTipoFil
'
Me.cmbTipoFil.BackColor = System.Drawing.SystemColors.Window
Me.cmbTipoFil.Cursor = System.Windows.Forms.Cursors.Default
Me.cmbTipoFil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbTipoFil.DropDownWidth = 200
Me.cmbTipoFil.ForeColor = System.Drawing.SystemColors.WindowText
Me.cmbTipoFil.Location = New System.Drawing.Point(88, 80)
Me.cmbTipoFil.Name = "cmbTipoFil"
Me.cmbTipoFil.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmbTipoFil.Size = New System.Drawing.Size(49, 21)
Me.cmbTipoFil.TabIndex = 412
'
'_txtLR_12
'
Me._txtLR_12.AcceptsReturn = true
Me._txtLR_12.BackColor = System.Drawing.Color.White
Me._txtLR_12.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_12.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_12.Location = New System.Drawing.Point(168, 216)
Me._txtLR_12.MaxLength = 0
Me._txtLR_12.Name = "_txtLR_12"
Me._txtLR_12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_12.Size = New System.Drawing.Size(65, 20)
Me._txtLR_12.TabIndex = 394
Me._txtLR_12.Tag = "p"
'
'_txtLR_11
'
Me._txtLR_11.AcceptsReturn = true
Me._txtLR_11.BackColor = System.Drawing.Color.Yellow
Me._txtLR_11.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_11.Enabled = false
Me._txtLR_11.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_11.Location = New System.Drawing.Point(168, 200)
Me._txtLR_11.MaxLength = 0
Me._txtLR_11.Name = "_txtLR_11"
Me._txtLR_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_11.Size = New System.Drawing.Size(65, 20)
Me._txtLR_11.TabIndex = 392
Me._txtLR_11.Tag = "p"
'
'_txtLR_10
'
Me._txtLR_10.AcceptsReturn = true
Me._txtLR_10.BackColor = System.Drawing.Color.Yellow
Me._txtLR_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_10.Enabled = false
Me._txtLR_10.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_10.Location = New System.Drawing.Point(168, 184)
Me._txtLR_10.MaxLength = 0
Me._txtLR_10.Name = "_txtLR_10"
Me._txtLR_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_10.Size = New System.Drawing.Size(65, 20)
Me._txtLR_10.TabIndex = 390
Me._txtLR_10.Tag = "p"
'
'_txtLR_8
'
Me._txtLR_8.AcceptsReturn = true
Me._txtLR_8.BackColor = System.Drawing.Color.Yellow
Me._txtLR_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_8.Enabled = false
Me._txtLR_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_8.Location = New System.Drawing.Point(168, 64)
Me._txtLR_8.MaxLength = 0
Me._txtLR_8.Name = "_txtLR_8"
Me._txtLR_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_8.Size = New System.Drawing.Size(65, 20)
Me._txtLR_8.TabIndex = 383
Me._txtLR_8.Tag = "p"
'
'_txtLR_3
'
Me._txtLR_3.AcceptsReturn = true
Me._txtLR_3.BackColor = System.Drawing.Color.Yellow
Me._txtLR_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_3.Enabled = false
Me._txtLR_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_3.Location = New System.Drawing.Point(168, 48)
Me._txtLR_3.MaxLength = 0
Me._txtLR_3.Name = "_txtLR_3"
Me._txtLR_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_3.Size = New System.Drawing.Size(65, 20)
Me._txtLR_3.TabIndex = 374
Me._txtLR_3.Tag = "p"
'
'_txtLR_2
'
Me._txtLR_2.AcceptsReturn = true
Me._txtLR_2.BackColor = System.Drawing.Color.Yellow
Me._txtLR_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_2.Enabled = false
Me._txtLR_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_2.Location = New System.Drawing.Point(168, 32)
Me._txtLR_2.MaxLength = 0
Me._txtLR_2.Name = "_txtLR_2"
Me._txtLR_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_2.Size = New System.Drawing.Size(65, 20)
Me._txtLR_2.TabIndex = 371
Me._txtLR_2.Tag = "p"
'
'_txtLR_1
'
Me._txtLR_1.AcceptsReturn = true
Me._txtLR_1.BackColor = System.Drawing.Color.White
Me._txtLR_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_1.Location = New System.Drawing.Point(168, 16)
Me._txtLR_1.MaxLength = 0
Me._txtLR_1.Name = "_txtLR_1"
Me._txtLR_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_1.Size = New System.Drawing.Size(65, 20)
Me._txtLR_1.TabIndex = 368
Me._txtLR_1.Tag = "p"
'
'_Label_121
'
Me._Label_121.AutoSize = true
Me._Label_121.BackColor = System.Drawing.SystemColors.Control
Me._Label_121.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_121.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_121.Location = New System.Drawing.Point(8, 264)
Me._Label_121.Name = "_Label_121"
Me._Label_121.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_121.Size = New System.Drawing.Size(107, 13)
Me._Label_121.TabIndex = 431
Me._Label_121.Text = "Altezza minima anello"
'
'_lblMis_99
'
Me._lblMis_99.BackColor = System.Drawing.Color.Cyan
Me._lblMis_99.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_99.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_99.Location = New System.Drawing.Point(240, 264)
Me._lblMis_99.Name = "_lblMis_99"
Me._lblMis_99.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_99.Size = New System.Drawing.Size(40, 17)
Me._lblMis_99.TabIndex = 430
Me._lblMis_99.Text = "mm"
'
'_lblMis_92
'
Me._lblMis_92.BackColor = System.Drawing.Color.Cyan
Me._lblMis_92.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_92.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_92.Location = New System.Drawing.Point(256, 160)
Me._lblMis_92.Name = "_lblMis_92"
Me._lblMis_92.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_92.Size = New System.Drawing.Size(16, 17)
Me._lblMis_92.TabIndex = 428
Me._lblMis_92.Text = "°C"
'
'_Label_120
'
Me._Label_120.AutoSize = true
Me._Label_120.BackColor = System.Drawing.SystemColors.Control
Me._Label_120.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_120.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_120.Location = New System.Drawing.Point(144, 160)
Me._Label_120.Name = "_Label_120"
Me._Label_120.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_120.Size = New System.Drawing.Size(68, 13)
Me._Label_120.TabIndex = 426
Me._Label_120.Text = "Temp. anello"
'
'_lblMis_91
'
Me._lblMis_91.BackColor = System.Drawing.Color.Cyan
Me._lblMis_91.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_91.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_91.Location = New System.Drawing.Point(120, 160)
Me._lblMis_91.Name = "_lblMis_91"
Me._lblMis_91.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_91.Size = New System.Drawing.Size(16, 17)
Me._lblMis_91.TabIndex = 425
Me._lblMis_91.Text = "°C"
'
'_Label_119
'
Me._Label_119.AutoSize = true
Me._Label_119.BackColor = System.Drawing.SystemColors.Control
Me._Label_119.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_119.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_119.Location = New System.Drawing.Point(8, 160)
Me._Label_119.Name = "_Label_119"
Me._Label_119.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_119.Size = New System.Drawing.Size(68, 13)
Me._Label_119.TabIndex = 423
Me._Label_119.Text = "Temp. cassa"
'
'_lblMis_90
'
Me._lblMis_90.BackColor = System.Drawing.Color.Cyan
Me._lblMis_90.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_90.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_90.Location = New System.Drawing.Point(240, 99)
Me._lblMis_90.Name = "_lblMis_90"
Me._lblMis_90.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_90.Size = New System.Drawing.Size(40, 17)
Me._lblMis_90.TabIndex = 422
Me._lblMis_90.Text = "mm"
'
'_Label_118
'
Me._Label_118.AutoSize = true
Me._Label_118.BackColor = System.Drawing.SystemColors.Control
Me._Label_118.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_118.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_118.Location = New System.Drawing.Point(8, 99)
Me._Label_118.Name = "_Label_118"
Me._Label_118.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_118.Size = New System.Drawing.Size(99, 13)
Me._Label_118.TabIndex = 421
Me._Label_118.Text = "Campo di tolleranza"
'
'_lblMis_98
'
Me._lblMis_98.BackColor = System.Drawing.Color.Cyan
Me._lblMis_98.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_98.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_98.Location = New System.Drawing.Point(240, 232)
Me._lblMis_98.Name = "_lblMis_98"
Me._lblMis_98.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_98.Size = New System.Drawing.Size(40, 17)
Me._lblMis_98.TabIndex = 419
Me._lblMis_98.Text = "mm"
'
'_Label_117
'
Me._Label_117.AutoSize = true
Me._Label_117.BackColor = System.Drawing.SystemColors.Control
Me._Label_117.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_117.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_117.Location = New System.Drawing.Point(8, 232)
Me._Label_117.Name = "_Label_117"
Me._Label_117.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_117.Size = New System.Drawing.Size(149, 13)
Me._Label_117.TabIndex = 418
Me._Label_117.Text = "Altezza filetto in presa (design)"
'
'lblPrecis
'
Me.lblPrecis.BackColor = System.Drawing.SystemColors.Control
Me.lblPrecis.Cursor = System.Windows.Forms.Cursors.Default
Me.lblPrecis.ForeColor = System.Drawing.SystemColors.ControlText
Me.lblPrecis.Location = New System.Drawing.Point(144, 82)
Me.lblPrecis.Name = "lblPrecis"
Me.lblPrecis.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.lblPrecis.Size = New System.Drawing.Size(89, 17)
Me.lblPrecis.TabIndex = 415
Me.lblPrecis.Text = "Precisione di lav."
'
'lbltipofil
'
Me.lbltipofil.BackColor = System.Drawing.SystemColors.Control
Me.lbltipofil.Cursor = System.Windows.Forms.Cursors.Default
Me.lbltipofil.ForeColor = System.Drawing.SystemColors.ControlText
Me.lbltipofil.Location = New System.Drawing.Point(8, 82)
Me.lbltipofil.Name = "lbltipofil"
Me.lbltipofil.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.lbltipofil.Size = New System.Drawing.Size(97, 17)
Me.lbltipofil.TabIndex = 413
Me.lbltipofil.Text = "Tipo filettatura"
'
'lblFiletti
'
Me.lblFiletti.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
Me.lblFiletti.Cursor = System.Windows.Forms.Cursors.Default
Me.lblFiletti.ForeColor = System.Drawing.SystemColors.ControlText
Me.lblFiletti.Location = New System.Drawing.Point(16, 296)
Me.lblFiletti.Name = "lblFiletti"
Me.lblFiletti.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.lblFiletti.Size = New System.Drawing.Size(260, 25)
Me.lblFiletti.TabIndex = 399
Me.lblFiletti.Text = "Altezza anello filettato insufficiente"
'
'_Label_111
'
Me._Label_111.AutoSize = true
Me._Label_111.BackColor = System.Drawing.SystemColors.Control
Me._Label_111.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_111.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_111.Location = New System.Drawing.Point(8, 216)
Me._Label_111.Name = "_Label_111"
Me._Label_111.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_111.Size = New System.Drawing.Size(85, 13)
Me._Label_111.TabIndex = 395
Me._Label_111.Text = "N° filetti adottato"
'
'_Label_110
'
Me._Label_110.AutoSize = true
Me._Label_110.BackColor = System.Drawing.SystemColors.Control
Me._Label_110.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_110.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_110.Location = New System.Drawing.Point(8, 200)
Me._Label_110.Name = "_Label_110"
Me._Label_110.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_110.Size = New System.Drawing.Size(85, 13)
Me._Label_110.TabIndex = 393
Me._Label_110.Text = "N° filetti richiesto"
'
'_Label_109
'
Me._Label_109.AutoSize = true
Me._Label_109.BackColor = System.Drawing.SystemColors.Control
Me._Label_109.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_109.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_109.Location = New System.Drawing.Point(8, 184)
Me._Label_109.Name = "_Label_109"
Me._Label_109.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_109.Size = New System.Drawing.Size(149, 13)
Me._Label_109.TabIndex = 391
Me._Label_109.Text = "N° max. filetti su altezza anello"
'
'_Label_107
'
Me._Label_107.AutoSize = true
Me._Label_107.BackColor = System.Drawing.SystemColors.Control
Me._Label_107.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_107.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_107.Location = New System.Drawing.Point(8, 64)
Me._Label_107.Name = "_Label_107"
Me._Label_107.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_107.Size = New System.Drawing.Size(86, 13)
Me._Label_107.TabIndex = 385
Me._Label_107.Text = "Gioco diametrale"
'
'_lblMis_88
'
Me._lblMis_88.BackColor = System.Drawing.Color.Cyan
Me._lblMis_88.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_88.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_88.Location = New System.Drawing.Point(240, 64)
Me._lblMis_88.Name = "_lblMis_88"
Me._lblMis_88.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_88.Size = New System.Drawing.Size(40, 17)
Me._lblMis_88.TabIndex = 384
Me._lblMis_88.Text = "mm"
'
'_Label_97
'
Me._Label_97.AutoSize = true
Me._Label_97.BackColor = System.Drawing.SystemColors.Control
Me._Label_97.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_97.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_97.Location = New System.Drawing.Point(8, 48)
Me._Label_97.Name = "_Label_97"
Me._Label_97.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_97.Size = New System.Drawing.Size(102, 13)
Me._Label_97.TabIndex = 376
Me._Label_97.Text = "Spessore alla radice"
'
'_lblMis_83
'
Me._lblMis_83.BackColor = System.Drawing.Color.Cyan
Me._lblMis_83.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_83.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_83.Location = New System.Drawing.Point(240, 48)
Me._lblMis_83.Name = "_lblMis_83"
Me._lblMis_83.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_83.Size = New System.Drawing.Size(40, 17)
Me._lblMis_83.TabIndex = 375
Me._lblMis_83.Text = "mm"
'
'_Label_96
'
Me._Label_96.AutoSize = true
Me._Label_96.BackColor = System.Drawing.SystemColors.Control
Me._Label_96.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_96.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_96.Location = New System.Drawing.Point(8, 32)
Me._Label_96.Name = "_Label_96"
Me._Label_96.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_96.Size = New System.Drawing.Size(69, 13)
Me._Label_96.TabIndex = 373
Me._Label_96.Text = "Altezza filetto"
'
'_lblMis_82
'
Me._lblMis_82.BackColor = System.Drawing.Color.Cyan
Me._lblMis_82.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_82.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_82.Location = New System.Drawing.Point(240, 32)
Me._lblMis_82.Name = "_lblMis_82"
Me._lblMis_82.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_82.Size = New System.Drawing.Size(40, 17)
Me._lblMis_82.TabIndex = 372
Me._lblMis_82.Text = "mm"
'
'_Label_95
'
Me._Label_95.AutoSize = true
Me._Label_95.BackColor = System.Drawing.SystemColors.Control
Me._Label_95.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_95.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_95.Location = New System.Drawing.Point(8, 16)
Me._Label_95.Name = "_Label_95"
Me._Label_95.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_95.Size = New System.Drawing.Size(82, 13)
Me._Label_95.TabIndex = 370
Me._Label_95.Text = "Passo filettatura"
'
'_lblMis_81
'
Me._lblMis_81.BackColor = System.Drawing.Color.Cyan
Me._lblMis_81.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_81.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_81.Location = New System.Drawing.Point(240, 16)
Me._lblMis_81.Name = "_lblMis_81"
Me._lblMis_81.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_81.Size = New System.Drawing.Size(40, 17)
Me._lblMis_81.TabIndex = 369
Me._lblMis_81.Text = "mm"
'
'Frame4
'
Me.Frame4.BackColor = System.Drawing.SystemColors.Control
Me.Frame4.Controls.Add(Me._txtLR_26)
Me.Frame4.Controls.Add(Me.Label25)
Me.Frame4.Controls.Add(Me.Label26)
Me.Frame4.Controls.Add(Me.Label18)
Me.Frame4.Controls.Add(Me.Label19)
Me.Frame4.Controls.Add(Me._txtLR_24)
Me.Frame4.Controls.Add(Me.Label16)
Me.Frame4.Controls.Add(Me.Label17)
Me.Frame4.Controls.Add(Me._txtLR_7)
Me.Frame4.Controls.Add(Me._Label_106)
Me.Frame4.Controls.Add(Me._lblMis_87)
Me.Frame4.Controls.Add(Me._txtLR_25)
Me.Frame4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Frame4.Location = New System.Drawing.Point(8, 232)
Me.Frame4.Name = "Frame4"
Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Frame4.Size = New System.Drawing.Size(289, 104)
Me.Frame4.TabIndex = 357
Me.Frame4.TabStop = false
Me.Frame4.Text = "Femmina (madrevite sulla cassa)"
'
'_txtLR_26
'
Me._txtLR_26.AcceptsReturn = true
Me._txtLR_26.BackColor = System.Drawing.Color.White
Me._txtLR_26.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_26.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_26.Location = New System.Drawing.Point(168, 36)
Me._txtLR_26.MaxLength = 0
Me._txtLR_26.Name = "_txtLR_26"
Me._txtLR_26.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_26.Size = New System.Drawing.Size(65, 20)
Me._txtLR_26.TabIndex = 418
Me._txtLR_26.Tag = "p"
'
'Label25
'
Me.Label25.AutoSize = true
Me.Label25.BackColor = System.Drawing.SystemColors.Control
Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label25.Location = New System.Drawing.Point(8, 36)
Me.Label25.Name = "Label25"
Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label25.Size = New System.Drawing.Size(126, 13)
Me.Label25.TabIndex = 420
Me.Label25.Text = "Diam. gola alla base filetti"
'
'Label26
'
Me.Label26.BackColor = System.Drawing.Color.Cyan
Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label26.Location = New System.Drawing.Point(240, 36)
Me.Label26.Name = "Label26"
Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label26.Size = New System.Drawing.Size(40, 17)
Me.Label26.TabIndex = 419
Me.Label26.Text = "mm"
'
'Label18
'
Me.Label18.BackColor = System.Drawing.Color.Cyan
Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label18.Location = New System.Drawing.Point(240, 74)
Me.Label18.Name = "Label18"
Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label18.Size = New System.Drawing.Size(40, 17)
Me.Label18.TabIndex = 417
Me.Label18.Text = "mm"
'
'Label19
'
Me.Label19.AutoSize = true
Me.Label19.BackColor = System.Drawing.SystemColors.Control
Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label19.Location = New System.Drawing.Point(8, 74)
Me.Label19.Name = "Label19"
Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label19.Size = New System.Drawing.Size(93, 13)
Me.Label19.TabIndex = 416
Me.Label19.Text = "Spessore adottato"
'
'_txtLR_24
'
Me._txtLR_24.AcceptsReturn = true
Me._txtLR_24.BackColor = System.Drawing.Color.Yellow
Me._txtLR_24.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_24.Enabled = false
Me._txtLR_24.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_24.Location = New System.Drawing.Point(168, 55)
Me._txtLR_24.MaxLength = 0
Me._txtLR_24.Name = "_txtLR_24"
Me._txtLR_24.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_24.Size = New System.Drawing.Size(65, 20)
Me._txtLR_24.TabIndex = 412
Me._txtLR_24.Tag = "p"
'
'Label16
'
Me.Label16.BackColor = System.Drawing.Color.Cyan
Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label16.Location = New System.Drawing.Point(240, 55)
Me.Label16.Name = "Label16"
Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label16.Size = New System.Drawing.Size(40, 17)
Me.Label16.TabIndex = 414
Me.Label16.Text = "mm"
'
'Label17
'
Me.Label17.AutoSize = true
Me.Label17.BackColor = System.Drawing.SystemColors.Control
Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label17.Location = New System.Drawing.Point(8, 55)
Me.Label17.Name = "Label17"
Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label17.Size = New System.Drawing.Size(136, 13)
Me.Label17.TabIndex = 413
Me.Label17.Text = "Spessore min. zona filettata"
'
'_txtLR_7
'
Me._txtLR_7.AcceptsReturn = true
Me._txtLR_7.BackColor = System.Drawing.Color.Yellow
Me._txtLR_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_7.Enabled = false
Me._txtLR_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_7.Location = New System.Drawing.Point(168, 17)
Me._txtLR_7.MaxLength = 0
Me._txtLR_7.Name = "_txtLR_7"
Me._txtLR_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_7.Size = New System.Drawing.Size(65, 20)
Me._txtLR_7.TabIndex = 380
Me._txtLR_7.Tag = "p"
'
'_Label_106
'
Me._Label_106.AutoSize = true
Me._Label_106.BackColor = System.Drawing.SystemColors.Control
Me._Label_106.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_106.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_106.Location = New System.Drawing.Point(8, 17)
Me._Label_106.Name = "_Label_106"
Me._Label_106.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_106.Size = New System.Drawing.Size(100, 13)
Me._Label_106.TabIndex = 382
Me._Label_106.Text = "Diametro gola filetto"
'
'_lblMis_87
'
Me._lblMis_87.BackColor = System.Drawing.Color.Cyan
Me._lblMis_87.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_87.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_87.Location = New System.Drawing.Point(240, 17)
Me._lblMis_87.Name = "_lblMis_87"
Me._lblMis_87.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_87.Size = New System.Drawing.Size(40, 17)
Me._lblMis_87.TabIndex = 381
Me._lblMis_87.Text = "mm"
'
'_txtLR_25
'
Me._txtLR_25.AcceptsReturn = true
Me._txtLR_25.BackColor = System.Drawing.Color.White
Me._txtLR_25.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_25.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_25.Location = New System.Drawing.Point(168, 74)
Me._txtLR_25.MaxLength = 0
Me._txtLR_25.Name = "_txtLR_25"
Me._txtLR_25.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_25.Size = New System.Drawing.Size(65, 20)
Me._txtLR_25.TabIndex = 415
Me._txtLR_25.Tag = "p"
'
'Frame3
'
Me.Frame3.BackColor = System.Drawing.SystemColors.Control
Me.Frame3.Controls.Add(Me._txtLR_6)
Me.Frame3.Controls.Add(Me._txtLR_9)
Me.Frame3.Controls.Add(Me._txtLR_4)
Me.Frame3.Controls.Add(Me._txtLR_5)
Me.Frame3.Controls.Add(Me._txtLR_0)
Me.Frame3.Controls.Add(Me._Label_108)
Me.Frame3.Controls.Add(Me._lblMis_89)
Me.Frame3.Controls.Add(Me._Label_105)
Me.Frame3.Controls.Add(Me._lblMis_86)
Me.Frame3.Controls.Add(Me._Label_99)
Me.Frame3.Controls.Add(Me._lblMis_85)
Me.Frame3.Controls.Add(Me._Label_98)
Me.Frame3.Controls.Add(Me._lblMis_84)
Me.Frame3.Controls.Add(Me._Label_94)
Me.Frame3.Controls.Add(Me._lblMis_80)
Me.Frame3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Frame3.Location = New System.Drawing.Point(8, 8)
Me.Frame3.Name = "Frame3"
Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Frame3.Size = New System.Drawing.Size(289, 105)
Me.Frame3.TabIndex = 356
Me.Frame3.TabStop = false
Me.Frame3.Text = "Maschio (anello filettato)"
'
'_txtLR_6
'
Me._txtLR_6.AcceptsReturn = true
Me._txtLR_6.BackColor = System.Drawing.Color.White
Me._txtLR_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_6.Location = New System.Drawing.Point(168, 32)
Me._txtLR_6.MaxLength = 0
Me._txtLR_6.Name = "_txtLR_6"
Me._txtLR_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_6.Size = New System.Drawing.Size(65, 20)
Me._txtLR_6.TabIndex = 377
Me._txtLR_6.Tag = "p"
'
'_txtLR_9
'
Me._txtLR_9.AcceptsReturn = true
Me._txtLR_9.BackColor = System.Drawing.Color.White
Me._txtLR_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_9.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_9.Location = New System.Drawing.Point(168, 48)
Me._txtLR_9.MaxLength = 0
Me._txtLR_9.Name = "_txtLR_9"
Me._txtLR_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_9.Size = New System.Drawing.Size(65, 20)
Me._txtLR_9.TabIndex = 387
Me._txtLR_9.Tag = "p"
'
'_txtLR_4
'
Me._txtLR_4.AcceptsReturn = true
Me._txtLR_4.BackColor = System.Drawing.Color.Yellow
Me._txtLR_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_4.Enabled = false
Me._txtLR_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_4.Location = New System.Drawing.Point(168, 64)
Me._txtLR_4.MaxLength = 0
Me._txtLR_4.Name = "_txtLR_4"
Me._txtLR_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_4.Size = New System.Drawing.Size(65, 20)
Me._txtLR_4.TabIndex = 361
Me._txtLR_4.Tag = "p"
'
'_txtLR_5
'
Me._txtLR_5.AcceptsReturn = true
Me._txtLR_5.BackColor = System.Drawing.Color.White
Me._txtLR_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_5.Location = New System.Drawing.Point(168, 80)
Me._txtLR_5.MaxLength = 0
Me._txtLR_5.Name = "_txtLR_5"
Me._txtLR_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_5.Size = New System.Drawing.Size(65, 20)
Me._txtLR_5.TabIndex = 364
Me._txtLR_5.Tag = "p"
'
'_txtLR_0
'
Me._txtLR_0.AcceptsReturn = true
Me._txtLR_0.BackColor = System.Drawing.Color.White
Me._txtLR_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtLR_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtLR_0.Location = New System.Drawing.Point(168, 16)
Me._txtLR_0.MaxLength = 0
Me._txtLR_0.Name = "_txtLR_0"
Me._txtLR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtLR_0.Size = New System.Drawing.Size(65, 20)
Me._txtLR_0.TabIndex = 358
Me._txtLR_0.Tag = "p"
'
'_Label_108
'
Me._Label_108.AutoSize = true
Me._Label_108.BackColor = System.Drawing.SystemColors.Control
Me._Label_108.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_108.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_108.Location = New System.Drawing.Point(8, 48)
Me._Label_108.Name = "_Label_108"
Me._Label_108.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_108.Size = New System.Drawing.Size(135, 13)
Me._Label_108.TabIndex = 389
Me._Label_108.Text = "Diam. int. del tappo filettato"
'
'_lblMis_89
'
Me._lblMis_89.BackColor = System.Drawing.Color.Cyan
Me._lblMis_89.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_89.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_89.Location = New System.Drawing.Point(240, 48)
Me._lblMis_89.Name = "_lblMis_89"
Me._lblMis_89.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_89.Size = New System.Drawing.Size(40, 17)
Me._lblMis_89.TabIndex = 388
Me._lblMis_89.Text = "mm"
'
'_Label_105
'
Me._Label_105.AutoSize = true
Me._Label_105.BackColor = System.Drawing.SystemColors.Control
Me._Label_105.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_105.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_105.Location = New System.Drawing.Point(8, 32)
Me._Label_105.Name = "_Label_105"
Me._Label_105.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_105.Size = New System.Drawing.Size(149, 13)
Me._Label_105.TabIndex = 379
Me._Label_105.Text = "Diam. cresta filetto (al min.toll.)"
'
'_lblMis_86
'
Me._lblMis_86.BackColor = System.Drawing.Color.Cyan
Me._lblMis_86.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_86.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_86.Location = New System.Drawing.Point(240, 32)
Me._lblMis_86.Name = "_lblMis_86"
Me._lblMis_86.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_86.Size = New System.Drawing.Size(40, 17)
Me._lblMis_86.TabIndex = 378
Me._lblMis_86.Text = "mm"
'
'_Label_99
'
Me._Label_99.AutoSize = true
Me._Label_99.BackColor = System.Drawing.SystemColors.Control
Me._Label_99.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_99.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_99.Location = New System.Drawing.Point(8, 80)
Me._Label_99.Name = "_Label_99"
Me._Label_99.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_99.Size = New System.Drawing.Size(83, 13)
Me._Label_99.TabIndex = 366
Me._Label_99.Text = "Altezza adottata"
'
'_lblMis_85
'
Me._lblMis_85.BackColor = System.Drawing.Color.Cyan
Me._lblMis_85.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_85.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_85.Location = New System.Drawing.Point(240, 80)
Me._lblMis_85.Name = "_lblMis_85"
Me._lblMis_85.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_85.Size = New System.Drawing.Size(40, 17)
Me._lblMis_85.TabIndex = 365
Me._lblMis_85.Text = "mm"
'
'_Label_98
'
Me._Label_98.AutoSize = true
Me._Label_98.BackColor = System.Drawing.SystemColors.Control
Me._Label_98.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_98.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_98.Location = New System.Drawing.Point(8, 64)
Me._Label_98.Name = "_Label_98"
Me._Label_98.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_98.Size = New System.Drawing.Size(124, 13)
Me._Label_98.TabIndex = 363
Me._Label_98.Text = "Altezza minima di calcolo"
'
'_lblMis_84
'
Me._lblMis_84.BackColor = System.Drawing.Color.Cyan
Me._lblMis_84.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_84.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_84.Location = New System.Drawing.Point(240, 64)
Me._lblMis_84.Name = "_lblMis_84"
Me._lblMis_84.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_84.Size = New System.Drawing.Size(40, 17)
Me._lblMis_84.TabIndex = 362
Me._lblMis_84.Text = "mm"
'
'_Label_94
'
Me._Label_94.AutoSize = true
Me._Label_94.BackColor = System.Drawing.SystemColors.Control
Me._Label_94.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_94.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_94.Location = New System.Drawing.Point(8, 16)
Me._Label_94.Name = "_Label_94"
Me._Label_94.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_94.Size = New System.Drawing.Size(144, 13)
Me._Label_94.TabIndex = 360
Me._Label_94.Text = "Diam. nom. del tappo filettato"
'
'_lblMis_80
'
Me._lblMis_80.BackColor = System.Drawing.Color.Cyan
Me._lblMis_80.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_80.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_80.Location = New System.Drawing.Point(240, 16)
Me._lblMis_80.Name = "_lblMis_80"
Me._lblMis_80.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_80.Size = New System.Drawing.Size(40, 17)
Me._lblMis_80.TabIndex = 359
Me._lblMis_80.Text = "mm"
'
'_cmdCalc_8
'
Me._cmdCalc_8.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_8.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_8.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_8.Location = New System.Drawing.Point(520, 336)
Me._cmdCalc_8.Name = "_cmdCalc_8"
Me._cmdCalc_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_8.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_8.TabIndex = 355
Me._cmdCalc_8.Text = "Calcola"
Me._cmdCalc_8.UseVisualStyleBackColor = false
'
'_pctFrames_5
'
Me._pctFrames_5.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_5.Controls.Add(Me.Frame1)
Me._pctFrames_5.Controls.Add(Me.framFC)
Me._pctFrames_5.Controls.Add(Me.framRot)
Me._pctFrames_5.Controls.Add(Me._cmdCalc_5)
Me._pctFrames_5.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_5.Location = New System.Drawing.Point(4, 2)
Me._pctFrames_5.Name = "_pctFrames_5"
Me._pctFrames_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_5.Size = New System.Drawing.Size(593, 366)
Me._pctFrames_5.TabIndex = 169
Me._pctFrames_5.TabStop = true
'
'Frame1
'
Me.Frame1.BackColor = System.Drawing.SystemColors.Control
Me.Frame1.Controls.Add(Me.cmbTipoCassonetto)
Me.Frame1.Controls.Add(Me.Label24)
Me.Frame1.Controls.Add(Me.cmdMinCasson)
Me.Frame1.Controls.Add(Me.cmdRicalcCasson)
Me.Frame1.Controls.Add(Me._txtCasson_9)
Me.Frame1.Controls.Add(Me._txtCasson_8)
Me.Frame1.Controls.Add(Me._txtCasson_7)
Me.Frame1.Controls.Add(Me._txtCasson_6)
Me.Frame1.Controls.Add(Me._txtCasson_5)
Me.Frame1.Controls.Add(Me._txtCasson_4)
Me.Frame1.Controls.Add(Me._txtCasson_3)
Me.Frame1.Controls.Add(Me._lblCasson_3)
Me.Frame1.Controls.Add(Me._lblCasson_0)
Me.Frame1.Controls.Add(Me._Label_61)
Me.Frame1.Controls.Add(Me._lblMis_51)
Me.Frame1.Controls.Add(Me._Label_60)
Me.Frame1.Controls.Add(Me._Label_59)
Me.Frame1.Controls.Add(Me._lblMis_50)
Me.Frame1.Controls.Add(Me._Label_58)
Me.Frame1.Controls.Add(Me._lblMis_49)
Me.Frame1.Controls.Add(Me._Label_57)
Me.Frame1.Controls.Add(Me._lblMis_48)
Me.Frame1.Controls.Add(Me._Label_56)
Me.Frame1.Controls.Add(Me._lblMis_47)
Me.Frame1.Controls.Add(Me._Label_55)
Me.Frame1.Controls.Add(Me._lblMis_46)
Me.Frame1.Controls.Add(Me._lblCasson_1)
Me.Frame1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Frame1.Location = New System.Drawing.Point(296, 8)
Me.Frame1.Name = "Frame1"
Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Frame1.Size = New System.Drawing.Size(289, 328)
Me.Frame1.TabIndex = 212
Me.Frame1.TabStop = false
Me.Frame1.Text = "Dimensioni cassonetto"
'
'cmbTipoCassonetto
'
Me.cmbTipoCassonetto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbTipoCassonetto.FormattingEnabled = true
Me.cmbTipoCassonetto.Items.AddRange(New Object() {"Conico", "Cilindrico disassato", "Cilindrico in linea"})
Me.cmbTipoCassonetto.Location = New System.Drawing.Point(168, 136)
Me.cmbTipoCassonetto.Name = "cmbTipoCassonetto"
Me.cmbTipoCassonetto.Size = New System.Drawing.Size(112, 21)
Me.cmbTipoCassonetto.TabIndex = 475
'
'Label24
'
Me.Label24.AutoSize = true
Me.Label24.BackColor = System.Drawing.SystemColors.Control
Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label24.Location = New System.Drawing.Point(8, 136)
Me.Label24.Name = "Label24"
Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label24.Size = New System.Drawing.Size(94, 13)
Me.Label24.TabIndex = 474
Me.Label24.Text = "Tipo di cassonetto"
'
'_txtCasson_9
'
Me._txtCasson_9.AcceptsReturn = true
Me._txtCasson_9.BackColor = System.Drawing.Color.White
Me._txtCasson_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_9.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_9.Location = New System.Drawing.Point(168, 112)
Me._txtCasson_9.MaxLength = 0
Me._txtCasson_9.Name = "_txtCasson_9"
Me._txtCasson_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_9.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_9.TabIndex = 239
Me._txtCasson_9.Tag = "p"
'
'_txtCasson_8
'
Me._txtCasson_8.AcceptsReturn = true
Me._txtCasson_8.BackColor = System.Drawing.Color.White
Me._txtCasson_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_8.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_8.Location = New System.Drawing.Point(168, 96)
Me._txtCasson_8.MaxLength = 0
Me._txtCasson_8.Name = "_txtCasson_8"
Me._txtCasson_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_8.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_8.TabIndex = 237
Me._txtCasson_8.Tag = "p"
'
'_txtCasson_7
'
Me._txtCasson_7.AcceptsReturn = true
Me._txtCasson_7.BackColor = System.Drawing.Color.White
Me._txtCasson_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_7.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_7.Location = New System.Drawing.Point(168, 80)
Me._txtCasson_7.MaxLength = 0
Me._txtCasson_7.Name = "_txtCasson_7"
Me._txtCasson_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_7.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_7.TabIndex = 234
Me._txtCasson_7.Tag = "p"
'
'_txtCasson_6
'
Me._txtCasson_6.AcceptsReturn = true
Me._txtCasson_6.BackColor = System.Drawing.Color.White
Me._txtCasson_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_6.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_6.Location = New System.Drawing.Point(168, 64)
Me._txtCasson_6.MaxLength = 0
Me._txtCasson_6.Name = "_txtCasson_6"
Me._txtCasson_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_6.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_6.TabIndex = 231
Me._txtCasson_6.Tag = "p"
'
'_txtCasson_5
'
Me._txtCasson_5.AcceptsReturn = true
Me._txtCasson_5.BackColor = System.Drawing.Color.White
Me._txtCasson_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_5.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_5.Location = New System.Drawing.Point(168, 48)
Me._txtCasson_5.MaxLength = 0
Me._txtCasson_5.Name = "_txtCasson_5"
Me._txtCasson_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_5.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_5.TabIndex = 228
Me._txtCasson_5.Tag = "p"
'
'_txtCasson_4
'
Me._txtCasson_4.AcceptsReturn = true
Me._txtCasson_4.BackColor = System.Drawing.Color.White
Me._txtCasson_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_4.Location = New System.Drawing.Point(168, 32)
Me._txtCasson_4.MaxLength = 0
Me._txtCasson_4.Name = "_txtCasson_4"
Me._txtCasson_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_4.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_4.TabIndex = 225
Me._txtCasson_4.Tag = "p"
'
'_txtCasson_3
'
Me._txtCasson_3.AcceptsReturn = true
Me._txtCasson_3.BackColor = System.Drawing.Color.White
Me._txtCasson_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_3.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_3.Location = New System.Drawing.Point(168, 16)
Me._txtCasson_3.MaxLength = 0
Me._txtCasson_3.Name = "_txtCasson_3"
Me._txtCasson_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_3.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_3.TabIndex = 222
Me._txtCasson_3.Tag = "p"
'
'_lblCasson_3
'
Me._lblCasson_3.BackColor = System.Drawing.SystemColors.Control
Me._lblCasson_3.Cursor = System.Windows.Forms.Cursors.Default
Me._lblCasson_3.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblCasson_3.Location = New System.Drawing.Point(8, 192)
Me._lblCasson_3.Name = "_lblCasson_3"
Me._lblCasson_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblCasson_3.Size = New System.Drawing.Size(273, 25)
Me._lblCasson_3.TabIndex = 245
Me._lblCasson_3.Text = "Progetto da verificare"
'
'_lblCasson_0
'
Me._lblCasson_0.BackColor = System.Drawing.SystemColors.Control
Me._lblCasson_0.Cursor = System.Windows.Forms.Cursors.Default
Me._lblCasson_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblCasson_0.Location = New System.Drawing.Point(8, 192)
Me._lblCasson_0.Name = "_lblCasson_0"
Me._lblCasson_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblCasson_0.Size = New System.Drawing.Size(273, 25)
Me._lblCasson_0.TabIndex = 242
Me._lblCasson_0.Text = "Progetto adeguato"
'
'_Label_61
'
Me._Label_61.AutoSize = true
Me._Label_61.BackColor = System.Drawing.SystemColors.Control
Me._Label_61.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_61.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_61.Location = New System.Drawing.Point(8, 112)
Me._Label_61.Name = "_Label_61"
Me._Label_61.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_61.Size = New System.Drawing.Size(114, 13)
Me._Label_61.TabIndex = 241
Me._Label_61.Text = "Spessore di corrosione"
'
'_lblMis_51
'
Me._lblMis_51.BackColor = System.Drawing.Color.Cyan
Me._lblMis_51.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_51.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_51.Location = New System.Drawing.Point(240, 112)
Me._lblMis_51.Name = "_lblMis_51"
Me._lblMis_51.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_51.Size = New System.Drawing.Size(40, 17)
Me._lblMis_51.TabIndex = 240
Me._lblMis_51.Text = "mm"
'
'_Label_60
'
Me._Label_60.AutoSize = true
Me._Label_60.BackColor = System.Drawing.SystemColors.Control
Me._Label_60.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_60.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_60.Location = New System.Drawing.Point(8, 96)
Me._Label_60.Name = "_Label_60"
Me._Label_60.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_60.Size = New System.Drawing.Size(86, 13)
Me._Label_60.TabIndex = 238
Me._Label_60.Text = "Numero aperture"
'
'_Label_59
'
Me._Label_59.AutoSize = true
Me._Label_59.BackColor = System.Drawing.SystemColors.Control
Me._Label_59.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_59.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_59.Location = New System.Drawing.Point(8, 80)
Me._Label_59.Name = "_Label_59"
Me._Label_59.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_59.Size = New System.Drawing.Size(122, 13)
Me._Label_59.TabIndex = 236
Me._Label_59.Text = "Diametro medio aperture"
'
'_lblMis_50
'
Me._lblMis_50.BackColor = System.Drawing.Color.Cyan
Me._lblMis_50.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_50.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_50.Location = New System.Drawing.Point(240, 80)
Me._lblMis_50.Name = "_lblMis_50"
Me._lblMis_50.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_50.Size = New System.Drawing.Size(40, 17)
Me._lblMis_50.TabIndex = 235
Me._lblMis_50.Text = "mm"
'
'_Label_58
'
Me._Label_58.AutoSize = true
Me._Label_58.BackColor = System.Drawing.SystemColors.Control
Me._Label_58.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_58.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_58.Location = New System.Drawing.Point(8, 64)
Me._Label_58.Name = "_Label_58"
Me._Label_58.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_58.Size = New System.Drawing.Size(51, 13)
Me._Label_58.TabIndex = 233
Me._Label_58.Text = "Spessore"
'
'_lblMis_49
'
Me._lblMis_49.BackColor = System.Drawing.Color.Cyan
Me._lblMis_49.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_49.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_49.Location = New System.Drawing.Point(240, 64)
Me._lblMis_49.Name = "_lblMis_49"
Me._lblMis_49.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_49.Size = New System.Drawing.Size(40, 17)
Me._lblMis_49.TabIndex = 232
Me._lblMis_49.Text = "mm"
'
'_lblMis_48
'
Me._lblMis_48.BackColor = System.Drawing.Color.Cyan
Me._lblMis_48.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_48.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_48.Location = New System.Drawing.Point(240, 48)
Me._lblMis_48.Name = "_lblMis_48"
Me._lblMis_48.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_48.Size = New System.Drawing.Size(40, 17)
Me._lblMis_48.TabIndex = 229
Me._lblMis_48.Text = "mm"
'
'_lblMis_47
'
Me._lblMis_47.BackColor = System.Drawing.Color.Cyan
Me._lblMis_47.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_47.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_47.Location = New System.Drawing.Point(240, 32)
Me._lblMis_47.Name = "_lblMis_47"
Me._lblMis_47.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_47.Size = New System.Drawing.Size(40, 17)
Me._lblMis_47.TabIndex = 226
Me._lblMis_47.Text = "mm"
'
'_lblMis_46
'
Me._lblMis_46.BackColor = System.Drawing.Color.Cyan
Me._lblMis_46.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_46.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_46.Location = New System.Drawing.Point(240, 16)
Me._lblMis_46.Name = "_lblMis_46"
Me._lblMis_46.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_46.Size = New System.Drawing.Size(40, 17)
Me._lblMis_46.TabIndex = 223
Me._lblMis_46.Text = "mm"
'
'_lblCasson_1
'
Me._lblCasson_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me._lblCasson_1.Cursor = System.Windows.Forms.Cursors.Default
Me._lblCasson_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblCasson_1.Location = New System.Drawing.Point(8, 192)
Me._lblCasson_1.Name = "_lblCasson_1"
Me._lblCasson_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblCasson_1.Size = New System.Drawing.Size(273, 104)
Me._lblCasson_1.TabIndex = 243
Me._lblCasson_1.Text = "Tensioni elevate: aumentare lo spessore"
Me._lblCasson_1.Visible = false
'
'framFC
'
Me.framFC.BackColor = System.Drawing.SystemColors.Control
Me.framFC.Controls.Add(Me._txtCasson_13)
Me.framFC.Controls.Add(Me._txtCasson_12)
Me.framFC.Controls.Add(Me._txtCasson_11)
Me.framFC.Controls.Add(Me._txtCasson_10)
Me.framFC.Controls.Add(Me._lblFC_2)
Me.framFC.Controls.Add(Me._lblFC_1)
Me.framFC.Controls.Add(Me._lblFC_0)
Me.framFC.Controls.Add(Me._lblMis_55)
Me.framFC.Controls.Add(Me._Label_65)
Me.framFC.Controls.Add(Me._lblMis_54)
Me.framFC.Controls.Add(Me._Label_64)
Me.framFC.Controls.Add(Me._lblMis_53)
Me.framFC.Controls.Add(Me._Label_63)
Me.framFC.Controls.Add(Me._lblMis_52)
Me.framFC.Controls.Add(Me._Label_62)
Me.framFC.ForeColor = System.Drawing.Color.Blue
Me.framFC.Location = New System.Drawing.Point(8, 88)
Me.framFC.Name = "framFC"
Me.framFC.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framFC.Size = New System.Drawing.Size(289, 200)
Me.framFC.TabIndex = 246
Me.framFC.TabStop = false
Me.framFC.Text = "Flangia cassonetto"
'
'_txtCasson_13
'
Me._txtCasson_13.AcceptsReturn = true
Me._txtCasson_13.BackColor = System.Drawing.Color.White
Me._txtCasson_13.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_13.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_13.Location = New System.Drawing.Point(168, 64)
Me._txtCasson_13.MaxLength = 0
Me._txtCasson_13.Name = "_txtCasson_13"
Me._txtCasson_13.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_13.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_13.TabIndex = 256
Me._txtCasson_13.Tag = "p"
'
'_txtCasson_12
'
Me._txtCasson_12.AcceptsReturn = true
Me._txtCasson_12.BackColor = System.Drawing.Color.Yellow
Me._txtCasson_12.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_12.Enabled = false
Me._txtCasson_12.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_12.Location = New System.Drawing.Point(168, 48)
Me._txtCasson_12.MaxLength = 0
Me._txtCasson_12.Name = "_txtCasson_12"
Me._txtCasson_12.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_12.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_12.TabIndex = 253
Me._txtCasson_12.Tag = "p"
'
'_txtCasson_11
'
Me._txtCasson_11.AcceptsReturn = true
Me._txtCasson_11.BackColor = System.Drawing.Color.White
Me._txtCasson_11.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_11.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_11.Location = New System.Drawing.Point(168, 32)
Me._txtCasson_11.MaxLength = 0
Me._txtCasson_11.Name = "_txtCasson_11"
Me._txtCasson_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_11.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_11.TabIndex = 250
Me._txtCasson_11.Tag = "p"
'
'_txtCasson_10
'
Me._txtCasson_10.AcceptsReturn = true
Me._txtCasson_10.BackColor = System.Drawing.Color.White
Me._txtCasson_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_10.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_10.Location = New System.Drawing.Point(168, 16)
Me._txtCasson_10.MaxLength = 0
Me._txtCasson_10.Name = "_txtCasson_10"
Me._txtCasson_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_10.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_10.TabIndex = 247
Me._txtCasson_10.Tag = "p"
'
'_lblFC_2
'
Me._lblFC_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me._lblFC_2.Cursor = System.Windows.Forms.Cursors.Default
Me._lblFC_2.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblFC_2.Location = New System.Drawing.Point(8, 88)
Me._lblFC_2.Name = "_lblFC_2"
Me._lblFC_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblFC_2.Size = New System.Drawing.Size(273, 80)
Me._lblFC_2.TabIndex = 261
Me._lblFC_2.Text = "Bearing stress inaccettabile"
'
'_lblFC_1
'
Me._lblFC_1.BackColor = System.Drawing.SystemColors.Control
Me._lblFC_1.Cursor = System.Windows.Forms.Cursors.Default
Me._lblFC_1.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblFC_1.Location = New System.Drawing.Point(8, 88)
Me._lblFC_1.Name = "_lblFC_1"
Me._lblFC_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblFC_1.Size = New System.Drawing.Size(273, 25)
Me._lblFC_1.TabIndex = 260
Me._lblFC_1.Text = "Bearing stress accettabile"
'
'_lblFC_0
'
Me._lblFC_0.BackColor = System.Drawing.SystemColors.Control
Me._lblFC_0.Cursor = System.Windows.Forms.Cursors.Default
Me._lblFC_0.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblFC_0.Location = New System.Drawing.Point(8, 88)
Me._lblFC_0.Name = "_lblFC_0"
Me._lblFC_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblFC_0.Size = New System.Drawing.Size(273, 25)
Me._lblFC_0.TabIndex = 259
Me._lblFC_0.Text = "Progetto da verificare"
'
'_lblMis_55
'
Me._lblMis_55.BackColor = System.Drawing.Color.Cyan
Me._lblMis_55.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_55.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_55.Location = New System.Drawing.Point(240, 64)
Me._lblMis_55.Name = "_lblMis_55"
Me._lblMis_55.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_55.Size = New System.Drawing.Size(40, 17)
Me._lblMis_55.TabIndex = 258
Me._lblMis_55.Text = "mm"
'
'_Label_65
'
Me._Label_65.AutoSize = true
Me._Label_65.BackColor = System.Drawing.SystemColors.Control
Me._Label_65.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_65.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_65.Location = New System.Drawing.Point(8, 64)
Me._Label_65.Name = "_Label_65"
Me._Label_65.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_65.Size = New System.Drawing.Size(93, 13)
Me._Label_65.TabIndex = 257
Me._Label_65.Text = "Spessore adottato"
'
'_lblMis_54
'
Me._lblMis_54.BackColor = System.Drawing.Color.Cyan
Me._lblMis_54.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_54.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_54.Location = New System.Drawing.Point(240, 48)
Me._lblMis_54.Name = "_lblMis_54"
Me._lblMis_54.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_54.Size = New System.Drawing.Size(40, 17)
Me._lblMis_54.TabIndex = 255
Me._lblMis_54.Text = "mm"
'
'_Label_64
'
Me._Label_64.AutoSize = true
Me._Label_64.BackColor = System.Drawing.SystemColors.Control
Me._Label_64.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_64.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_64.Location = New System.Drawing.Point(8, 48)
Me._Label_64.Name = "_Label_64"
Me._Label_64.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_64.Size = New System.Drawing.Size(134, 13)
Me._Label_64.TabIndex = 254
Me._Label_64.Text = "Spessore minimo di calcolo"
'
'_lblMis_53
'
Me._lblMis_53.BackColor = System.Drawing.Color.Cyan
Me._lblMis_53.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_53.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_53.Location = New System.Drawing.Point(240, 32)
Me._lblMis_53.Name = "_lblMis_53"
Me._lblMis_53.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_53.Size = New System.Drawing.Size(40, 17)
Me._lblMis_53.TabIndex = 252
Me._lblMis_53.Text = "mm"
'
'_Label_63
'
Me._Label_63.AutoSize = true
Me._Label_63.BackColor = System.Drawing.SystemColors.Control
Me._Label_63.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_63.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_63.Location = New System.Drawing.Point(8, 32)
Me._Label_63.Name = "_Label_63"
Me._Label_63.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_63.Size = New System.Drawing.Size(84, 13)
Me._Label_63.TabIndex = 251
Me._Label_63.Text = "Diametro interno"
'
'_lblMis_52
'
Me._lblMis_52.BackColor = System.Drawing.Color.Cyan
Me._lblMis_52.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_52.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_52.Location = New System.Drawing.Point(240, 16)
Me._lblMis_52.Name = "_lblMis_52"
Me._lblMis_52.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_52.Size = New System.Drawing.Size(40, 17)
Me._lblMis_52.TabIndex = 249
Me._lblMis_52.Text = "mm"
'
'_Label_62
'
Me._Label_62.AutoSize = true
Me._Label_62.BackColor = System.Drawing.SystemColors.Control
Me._Label_62.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_62.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_62.Location = New System.Drawing.Point(8, 16)
Me._Label_62.Name = "_Label_62"
Me._Label_62.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_62.Size = New System.Drawing.Size(87, 13)
Me._Label_62.TabIndex = 248
Me._Label_62.Text = "Diametro esterno"
'
'framRot
'
Me.framRot.BackColor = System.Drawing.SystemColors.Control
Me.framRot.Controls.Add(Me._txtCasson_2)
Me.framRot.Controls.Add(Me._txtCasson_1)
Me.framRot.Controls.Add(Me._txtCasson_0)
Me.framRot.Controls.Add(Me._Label_54)
Me.framRot.Controls.Add(Me._lblMis_45)
Me.framRot.Controls.Add(Me._Label_53)
Me.framRot.Controls.Add(Me._lblMis_44)
Me.framRot.Controls.Add(Me._Label_52)
Me.framRot.Controls.Add(Me._lblMis_43)
Me.framRot.ForeColor = System.Drawing.Color.Blue
Me.framRot.Location = New System.Drawing.Point(8, 8)
Me.framRot.Name = "framRot"
Me.framRot.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framRot.Size = New System.Drawing.Size(289, 81)
Me.framRot.TabIndex = 211
Me.framRot.TabStop = false
Me.framRot.Text = "Rotazioni anello interno"
'
'_txtCasson_2
'
Me._txtCasson_2.AcceptsReturn = true
Me._txtCasson_2.BackColor = System.Drawing.Color.Yellow
Me._txtCasson_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_2.Enabled = false
Me._txtCasson_2.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_2.Location = New System.Drawing.Point(168, 48)
Me._txtCasson_2.MaxLength = 0
Me._txtCasson_2.Name = "_txtCasson_2"
Me._txtCasson_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_2.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_2.TabIndex = 219
Me._txtCasson_2.Tag = "p"
'
'_txtCasson_1
'
Me._txtCasson_1.AcceptsReturn = true
Me._txtCasson_1.BackColor = System.Drawing.Color.Yellow
Me._txtCasson_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_1.Enabled = false
Me._txtCasson_1.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_1.Location = New System.Drawing.Point(168, 32)
Me._txtCasson_1.MaxLength = 0
Me._txtCasson_1.Name = "_txtCasson_1"
Me._txtCasson_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_1.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_1.TabIndex = 216
Me._txtCasson_1.Tag = "p"
'
'_txtCasson_0
'
Me._txtCasson_0.AcceptsReturn = true
Me._txtCasson_0.BackColor = System.Drawing.Color.Yellow
Me._txtCasson_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtCasson_0.Enabled = false
Me._txtCasson_0.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtCasson_0.Location = New System.Drawing.Point(168, 16)
Me._txtCasson_0.MaxLength = 0
Me._txtCasson_0.Name = "_txtCasson_0"
Me._txtCasson_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtCasson_0.Size = New System.Drawing.Size(65, 20)
Me._txtCasson_0.TabIndex = 213
Me._txtCasson_0.Tag = "p"
'
'_Label_54
'
Me._Label_54.AutoSize = true
Me._Label_54.BackColor = System.Drawing.SystemColors.Control
Me._Label_54.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_54.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_54.Location = New System.Drawing.Point(8, 48)
Me._Label_54.Name = "_Label_54"
Me._Label_54.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_54.Size = New System.Drawing.Size(138, 13)
Me._Label_54.TabIndex = 221
Me._Label_54.Text = "In funzionamento (max 1.5°)"
'
'_lblMis_45
'
Me._lblMis_45.BackColor = System.Drawing.Color.Cyan
Me._lblMis_45.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_45.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_45.Location = New System.Drawing.Point(240, 48)
Me._lblMis_45.Name = "_lblMis_45"
Me._lblMis_45.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_45.Size = New System.Drawing.Size(24, 17)
Me._lblMis_45.TabIndex = 220
Me._lblMis_45.Text = "°"
'
'_Label_53
'
Me._Label_53.AutoSize = true
Me._Label_53.BackColor = System.Drawing.SystemColors.Control
Me._Label_53.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_53.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_53.Location = New System.Drawing.Point(8, 32)
Me._Label_53.Name = "_Label_53"
Me._Label_53.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_53.Size = New System.Drawing.Size(132, 13)
Me._Label_53.TabIndex = 218
Me._Label_53.Text = "In prova idraulica (max 2 °)"
'
'_lblMis_44
'
Me._lblMis_44.BackColor = System.Drawing.Color.Cyan
Me._lblMis_44.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_44.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_44.Location = New System.Drawing.Point(240, 32)
Me._lblMis_44.Name = "_lblMis_44"
Me._lblMis_44.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_44.Size = New System.Drawing.Size(24, 17)
Me._lblMis_44.TabIndex = 217
Me._lblMis_44.Text = "°"
'
'_Label_52
'
Me._Label_52.AutoSize = true
Me._Label_52.BackColor = System.Drawing.SystemColors.Control
Me._Label_52.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_52.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_52.Location = New System.Drawing.Point(8, 16)
Me._Label_52.Name = "_Label_52"
Me._Label_52.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_52.Size = New System.Drawing.Size(103, 13)
Me._Label_52.TabIndex = 215
Me._Label_52.Text = "Al seating (max 1.5°)"
'
'_lblMis_43
'
Me._lblMis_43.BackColor = System.Drawing.Color.Cyan
Me._lblMis_43.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_43.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_43.Location = New System.Drawing.Point(240, 16)
Me._lblMis_43.Name = "_lblMis_43"
Me._lblMis_43.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_43.Size = New System.Drawing.Size(24, 17)
Me._lblMis_43.TabIndex = 214
Me._lblMis_43.Text = "°"
'
'_cmdCalc_5
'
Me._cmdCalc_5.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_5.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_5.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_5.Location = New System.Drawing.Point(520, 336)
Me._cmdCalc_5.Name = "_cmdCalc_5"
Me._cmdCalc_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_5.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_5.TabIndex = 210
Me._cmdCalc_5.Text = "Calcola"
Me._cmdCalc_5.UseVisualStyleBackColor = false
'
'_pctFrames_4
'
Me._pctFrames_4.BackColor = System.Drawing.SystemColors.ActiveBorder
Me._pctFrames_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me._pctFrames_4.Controls.Add(Me.cmdRicalcRings)
Me._pctFrames_4.Controls.Add(Me.framCorr)
Me._pctFrames_4.Controls.Add(Me.framAltri)
Me._pctFrames_4.Controls.Add(Me.framBear)
Me._pctFrames_4.Controls.Add(Me._cmdCalc_4)
Me._pctFrames_4.Controls.Add(Me.framInner)
Me._pctFrames_4.Controls.Add(Me.framSplit)
Me._pctFrames_4.Cursor = System.Windows.Forms.Cursors.Default
Me._pctFrames_4.ForeColor = System.Drawing.SystemColors.WindowText
Me._pctFrames_4.Location = New System.Drawing.Point(4, 2)
Me._pctFrames_4.Name = "_pctFrames_4"
Me._pctFrames_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._pctFrames_4.Size = New System.Drawing.Size(593, 329)
Me._pctFrames_4.TabIndex = 143
Me._pctFrames_4.TabStop = true
'
'framCorr
'
Me.framCorr.BackColor = System.Drawing.SystemColors.Control
Me.framCorr.Controls.Add(Me._txtSplit_9)
Me.framCorr.Controls.Add(Me._Label_50)
Me.framCorr.Controls.Add(Me._lblMis_41)
Me.framCorr.Location = New System.Drawing.Point(8, 184)
Me.framCorr.Name = "framCorr"
Me.framCorr.Size = New System.Drawing.Size(288, 48)
Me.framCorr.TabIndex = 206
Me.framCorr.TabStop = false
Me.framCorr.Text = "Corrosione parti interne"
'
'_txtSplit_9
'
Me._txtSplit_9.AcceptsReturn = true
Me._txtSplit_9.BackColor = System.Drawing.Color.White
Me._txtSplit_9.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_9.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_9, CType(9,Short))
Me._txtSplit_9.Location = New System.Drawing.Point(168, 24)
Me._txtSplit_9.MaxLength = 0
Me._txtSplit_9.Name = "_txtSplit_9"
Me._txtSplit_9.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_9.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_9.TabIndex = 202
Me._txtSplit_9.Tag = "p"
'
'_Label_50
'
Me._Label_50.AutoSize = true
Me._Label_50.BackColor = System.Drawing.SystemColors.Control
Me._Label_50.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_50.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_50.Location = New System.Drawing.Point(8, 24)
Me._Label_50.Name = "_Label_50"
Me._Label_50.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_50.Size = New System.Drawing.Size(114, 13)
Me._Label_50.TabIndex = 204
Me._Label_50.Text = "Spessore di corrosione"
'
'_lblMis_41
'
Me._lblMis_41.BackColor = System.Drawing.Color.Cyan
Me._lblMis_41.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_41.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_41.Location = New System.Drawing.Point(240, 24)
Me._lblMis_41.Name = "_lblMis_41"
Me._lblMis_41.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_41.Size = New System.Drawing.Size(40, 17)
Me._lblMis_41.TabIndex = 203
Me._lblMis_41.Text = "mm"
'
'framAltri
'
Me.framAltri.BackColor = System.Drawing.SystemColors.Control
Me.framAltri.Controls.Add(Me._txtSplit_8)
Me.framAltri.Controls.Add(Me._Label_49)
Me.framAltri.Controls.Add(Me._lblMis_40)
Me.framAltri.ForeColor = System.Drawing.Color.Blue
Me.framAltri.Location = New System.Drawing.Point(8, 104)
Me.framAltri.Name = "framAltri"
Me.framAltri.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framAltri.Size = New System.Drawing.Size(289, 80)
Me.framAltri.TabIndex = 198
Me.framAltri.TabStop = false
Me.framAltri.Text = "Push Ring"
'
'_txtSplit_8
'
Me._txtSplit_8.AcceptsReturn = true
Me._txtSplit_8.BackColor = System.Drawing.Color.White
Me._txtSplit_8.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_8.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_8, CType(8,Short))
Me._txtSplit_8.Location = New System.Drawing.Point(168, 16)
Me._txtSplit_8.MaxLength = 0
Me._txtSplit_8.Name = "_txtSplit_8"
Me._txtSplit_8.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_8.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_8.TabIndex = 199
Me._txtSplit_8.Tag = "p"
'
'_Label_49
'
Me._Label_49.AutoSize = true
Me._Label_49.BackColor = System.Drawing.SystemColors.Control
Me._Label_49.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_49.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_49.Location = New System.Drawing.Point(8, 16)
Me._Label_49.Name = "_Label_49"
Me._Label_49.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_49.Size = New System.Drawing.Size(153, 13)
Me._Label_49.TabIndex = 201
Me._Label_49.Text = "Diametro medio anello di spinta"
'
'_lblMis_40
'
Me._lblMis_40.BackColor = System.Drawing.Color.Cyan
Me._lblMis_40.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_40.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_40.Location = New System.Drawing.Point(240, 16)
Me._lblMis_40.Name = "_lblMis_40"
Me._lblMis_40.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_40.Size = New System.Drawing.Size(40, 17)
Me._lblMis_40.TabIndex = 200
Me._lblMis_40.Text = "mm"
'
'framBear
'
Me.framBear.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.framBear.Controls.Add(Me._txtSplit_11)
Me.framBear.Controls.Add(Me.Label2)
Me.framBear.Controls.Add(Me.Label3)
Me.framBear.Controls.Add(Me._txtSplit_10)
Me.framBear.Controls.Add(Me.lblBear)
Me.framBear.Controls.Add(Me._lblMis_42)
Me.framBear.Controls.Add(Me._Label_51)
Me.framBear.ForeColor = System.Drawing.SystemColors.ControlText
Me.framBear.Location = New System.Drawing.Point(296, 96)
Me.framBear.Name = "framBear"
Me.framBear.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framBear.Size = New System.Drawing.Size(289, 153)
Me.framBear.TabIndex = 205
Me.framBear.TabStop = false
Me.framBear.Text = "Presssioni di contatto"
'
'_txtSplit_11
'
Me._txtSplit_11.AcceptsReturn = true
Me._txtSplit_11.BackColor = System.Drawing.Color.White
Me._txtSplit_11.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_11.Enabled = false
Me._txtSplit_11.ForeColor = System.Drawing.SystemColors.WindowText
Me._txtSplit_11.Location = New System.Drawing.Point(168, 120)
Me._txtSplit_11.MaxLength = 0
Me._txtSplit_11.Name = "_txtSplit_11"
Me._txtSplit_11.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_11.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_11.TabIndex = 210
Me._txtSplit_11.Tag = "p"
'
'Label2
'
Me.Label2.BackColor = System.Drawing.Color.Cyan
Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label2.Location = New System.Drawing.Point(240, 120)
Me.Label2.Name = "Label2"
Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label2.Size = New System.Drawing.Size(24, 17)
Me.Label2.TabIndex = 212
Me.Label2.Text = "mm"
'
'Label3
'
Me.Label3.AutoSize = true
Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label3.Location = New System.Drawing.Point(8, 120)
Me.Label3.Name = "Label3"
Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label3.Size = New System.Drawing.Size(156, 13)
Me.Label3.TabIndex = 211
Me.Label3.Text = "Largh. attuale fascia di contatto"
'
'_txtSplit_10
'
Me._txtSplit_10.AcceptsReturn = true
Me._txtSplit_10.BackColor = System.Drawing.Color.White
Me._txtSplit_10.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_10.Enabled = false
Me._txtSplit_10.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_10, CType(10,Short))
Me._txtSplit_10.Location = New System.Drawing.Point(168, 96)
Me._txtSplit_10.MaxLength = 0
Me._txtSplit_10.Name = "_txtSplit_10"
Me._txtSplit_10.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_10.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_10.TabIndex = 206
Me._txtSplit_10.Tag = "p"
'
'lblBear
'
Me.lblBear.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.lblBear.Cursor = System.Windows.Forms.Cursors.Default
Me.lblBear.ForeColor = System.Drawing.SystemColors.ControlText
Me.lblBear.Location = New System.Drawing.Point(8, 24)
Me.lblBear.Margin = New System.Windows.Forms.Padding(0)
Me.lblBear.Name = "lblBear"
Me.lblBear.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.lblBear.Size = New System.Drawing.Size(265, 64)
Me.lblBear.TabIndex = 209
Me.lblBear.Text = resources.GetString("lblBear.Text")
'
'_lblMis_42
'
Me._lblMis_42.BackColor = System.Drawing.Color.Cyan
Me._lblMis_42.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_42.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_42.Location = New System.Drawing.Point(240, 96)
Me._lblMis_42.Name = "_lblMis_42"
Me._lblMis_42.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_42.Size = New System.Drawing.Size(24, 17)
Me._lblMis_42.TabIndex = 208
Me._lblMis_42.Text = "mm"
'
'_Label_51
'
Me._Label_51.AutoSize = true
Me._Label_51.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me._Label_51.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_51.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_51.Location = New System.Drawing.Point(8, 96)
Me._Label_51.Name = "_Label_51"
Me._Label_51.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_51.Size = New System.Drawing.Size(162, 13)
Me._Label_51.TabIndex = 207
Me._Label_51.Text = "Larghezza min. fascia di contatto"
'
'_cmdCalc_4
'
Me._cmdCalc_4.BackColor = System.Drawing.SystemColors.Control
Me._cmdCalc_4.Cursor = System.Windows.Forms.Cursors.Default
Me._cmdCalc_4.ForeColor = System.Drawing.SystemColors.ControlText
Me._cmdCalc_4.Location = New System.Drawing.Point(520, 296)
Me._cmdCalc_4.Name = "_cmdCalc_4"
Me._cmdCalc_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._cmdCalc_4.Size = New System.Drawing.Size(65, 25)
Me._cmdCalc_4.TabIndex = 191
Me._cmdCalc_4.Text = "Calcola"
Me._cmdCalc_4.UseVisualStyleBackColor = false
'
'framInner
'
Me.framInner.BackColor = System.Drawing.SystemColors.Control
Me.framInner.Controls.Add(Me._txtSplit_5)
Me.framInner.Controls.Add(Me._txtSplit_7)
Me.framInner.Controls.Add(Me._txtSplit_4)
Me.framInner.Controls.Add(Me._txtSplit_3)
Me.framInner.Controls.Add(Me._lblMis_37)
Me.framInner.Controls.Add(Me._Label_46)
Me.framInner.Controls.Add(Me._Label_48)
Me.framInner.Controls.Add(Me._lblMis_39)
Me.framInner.Controls.Add(Me._lblMis_36)
Me.framInner.Controls.Add(Me._Label_45)
Me.framInner.Controls.Add(Me._lblMis_35)
Me.framInner.Controls.Add(Me._Label_44)
Me.framInner.ForeColor = System.Drawing.Color.Blue
Me.framInner.Location = New System.Drawing.Point(296, 8)
Me.framInner.Name = "framInner"
Me.framInner.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framInner.Size = New System.Drawing.Size(289, 88)
Me.framInner.TabIndex = 172
Me.framInner.TabStop = false
Me.framInner.Text = "Inner Ring"
'
'_txtSplit_5
'
Me._txtSplit_5.AcceptsReturn = true
Me._txtSplit_5.BackColor = System.Drawing.Color.White
Me._txtSplit_5.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_5.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_5, CType(5,Short))
Me._txtSplit_5.Location = New System.Drawing.Point(168, 64)
Me._txtSplit_5.MaxLength = 0
Me._txtSplit_5.Name = "_txtSplit_5"
Me._txtSplit_5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_5.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_5.TabIndex = 188
Me._txtSplit_5.Tag = "p"
'
'_txtSplit_7
'
Me._txtSplit_7.AcceptsReturn = true
Me._txtSplit_7.BackColor = System.Drawing.Color.Yellow
Me._txtSplit_7.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_7.Enabled = false
Me._txtSplit_7.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_7, CType(7,Short))
Me._txtSplit_7.Location = New System.Drawing.Point(168, 48)
Me._txtSplit_7.MaxLength = 0
Me._txtSplit_7.Name = "_txtSplit_7"
Me._txtSplit_7.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_7.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_7.TabIndex = 195
Me._txtSplit_7.Tag = "p"
'
'_txtSplit_4
'
Me._txtSplit_4.AcceptsReturn = true
Me._txtSplit_4.BackColor = System.Drawing.Color.White
Me._txtSplit_4.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_4.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_4, CType(4,Short))
Me._txtSplit_4.Location = New System.Drawing.Point(168, 32)
Me._txtSplit_4.MaxLength = 0
Me._txtSplit_4.Name = "_txtSplit_4"
Me._txtSplit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_4.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_4.TabIndex = 185
Me._txtSplit_4.Tag = "p"
'
'_txtSplit_3
'
Me._txtSplit_3.AcceptsReturn = true
Me._txtSplit_3.BackColor = System.Drawing.Color.White
Me._txtSplit_3.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_3.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_3, CType(3,Short))
Me._txtSplit_3.Location = New System.Drawing.Point(168, 16)
Me._txtSplit_3.MaxLength = 0
Me._txtSplit_3.Name = "_txtSplit_3"
Me._txtSplit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_3.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_3.TabIndex = 182
Me._txtSplit_3.Tag = "p"
'
'_lblMis_37
'
Me._lblMis_37.BackColor = System.Drawing.Color.Cyan
Me._lblMis_37.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_37.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_37.Location = New System.Drawing.Point(240, 64)
Me._lblMis_37.Name = "_lblMis_37"
Me._lblMis_37.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_37.Size = New System.Drawing.Size(40, 17)
Me._lblMis_37.TabIndex = 190
Me._lblMis_37.Text = "mm"
'
'_Label_46
'
Me._Label_46.AutoSize = true
Me._Label_46.BackColor = System.Drawing.SystemColors.Control
Me._Label_46.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_46.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_46.Location = New System.Drawing.Point(8, 64)
Me._Label_46.Name = "_Label_46"
Me._Label_46.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_46.Size = New System.Drawing.Size(51, 13)
Me._Label_46.TabIndex = 189
Me._Label_46.Text = "Spessore"
'
'_Label_48
'
Me._Label_48.AutoSize = true
Me._Label_48.BackColor = System.Drawing.SystemColors.Control
Me._Label_48.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_48.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_48.Location = New System.Drawing.Point(8, 48)
Me._Label_48.Name = "_Label_48"
Me._Label_48.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_48.Size = New System.Drawing.Size(134, 13)
Me._Label_48.TabIndex = 197
Me._Label_48.Text = "Spessore minimo di calcolo"
'
'_lblMis_39
'
Me._lblMis_39.BackColor = System.Drawing.Color.Cyan
Me._lblMis_39.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_39.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_39.Location = New System.Drawing.Point(240, 48)
Me._lblMis_39.Name = "_lblMis_39"
Me._lblMis_39.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_39.Size = New System.Drawing.Size(40, 17)
Me._lblMis_39.TabIndex = 196
Me._lblMis_39.Text = "mm"
'
'_lblMis_36
'
Me._lblMis_36.BackColor = System.Drawing.Color.Cyan
Me._lblMis_36.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_36.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_36.Location = New System.Drawing.Point(240, 32)
Me._lblMis_36.Name = "_lblMis_36"
Me._lblMis_36.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_36.Size = New System.Drawing.Size(40, 17)
Me._lblMis_36.TabIndex = 187
Me._lblMis_36.Text = "mm"
'
'_Label_45
'
Me._Label_45.AutoSize = true
Me._Label_45.BackColor = System.Drawing.SystemColors.Control
Me._Label_45.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_45.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_45.Location = New System.Drawing.Point(8, 32)
Me._Label_45.Name = "_Label_45"
Me._Label_45.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_45.Size = New System.Drawing.Size(84, 13)
Me._Label_45.TabIndex = 186
Me._Label_45.Text = "Diametro interno"
'
'_lblMis_35
'
Me._lblMis_35.BackColor = System.Drawing.Color.Cyan
Me._lblMis_35.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_35.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_35.Location = New System.Drawing.Point(240, 16)
Me._lblMis_35.Name = "_lblMis_35"
Me._lblMis_35.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_35.Size = New System.Drawing.Size(40, 17)
Me._lblMis_35.TabIndex = 184
Me._lblMis_35.Text = "mm"
'
'_Label_44
'
Me._Label_44.AutoSize = true
Me._Label_44.BackColor = System.Drawing.SystemColors.Control
Me._Label_44.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_44.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_44.Location = New System.Drawing.Point(8, 16)
Me._Label_44.Name = "_Label_44"
Me._Label_44.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_44.Size = New System.Drawing.Size(87, 13)
Me._Label_44.TabIndex = 183
Me._Label_44.Text = "Diametro esterno"
'
'framSplit
'
Me.framSplit.BackColor = System.Drawing.SystemColors.Control
Me.framSplit.Controls.Add(Me._txtSplit_6)
Me.framSplit.Controls.Add(Me._txtSplit_2)
Me.framSplit.Controls.Add(Me._txtSplit_1)
Me.framSplit.Controls.Add(Me._txtSplit_0)
Me.framSplit.Controls.Add(Me._Label_47)
Me.framSplit.Controls.Add(Me._lblMis_38)
Me.framSplit.Controls.Add(Me._lblMis_34)
Me.framSplit.Controls.Add(Me._Label_43)
Me.framSplit.Controls.Add(Me._lblMis_33)
Me.framSplit.Controls.Add(Me._Label_42)
Me.framSplit.Controls.Add(Me._lblMis_32)
Me.framSplit.Controls.Add(Me._Label_41)
Me.framSplit.ForeColor = System.Drawing.Color.Blue
Me.framSplit.Location = New System.Drawing.Point(8, 8)
Me.framSplit.Name = "framSplit"
Me.framSplit.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.framSplit.Size = New System.Drawing.Size(289, 96)
Me.framSplit.TabIndex = 171
Me.framSplit.TabStop = false
Me.framSplit.Text = "Split Ring"
'
'_txtSplit_6
'
Me._txtSplit_6.AcceptsReturn = true
Me._txtSplit_6.BackColor = System.Drawing.Color.White
Me._txtSplit_6.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_6.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_6, CType(6,Short))
Me._txtSplit_6.Location = New System.Drawing.Point(168, 64)
Me._txtSplit_6.MaxLength = 0
Me._txtSplit_6.Name = "_txtSplit_6"
Me._txtSplit_6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_6.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_6.TabIndex = 192
Me._txtSplit_6.Tag = "p"
'
'_txtSplit_2
'
Me._txtSplit_2.AcceptsReturn = true
Me._txtSplit_2.BackColor = System.Drawing.Color.Yellow
Me._txtSplit_2.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_2.Enabled = false
Me._txtSplit_2.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_2, CType(2,Short))
Me._txtSplit_2.Location = New System.Drawing.Point(168, 48)
Me._txtSplit_2.MaxLength = 0
Me._txtSplit_2.Name = "_txtSplit_2"
Me._txtSplit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_2.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_2.TabIndex = 179
Me._txtSplit_2.Tag = "p"
'
'_txtSplit_1
'
Me._txtSplit_1.AcceptsReturn = true
Me._txtSplit_1.BackColor = System.Drawing.Color.White
Me._txtSplit_1.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_1.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_1, CType(1,Short))
Me._txtSplit_1.Location = New System.Drawing.Point(168, 32)
Me._txtSplit_1.MaxLength = 0
Me._txtSplit_1.Name = "_txtSplit_1"
Me._txtSplit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_1.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_1.TabIndex = 176
Me._txtSplit_1.Tag = "p"
'
'_txtSplit_0
'
Me._txtSplit_0.AcceptsReturn = true
Me._txtSplit_0.BackColor = System.Drawing.Color.White
Me._txtSplit_0.Cursor = System.Windows.Forms.Cursors.IBeam
Me._txtSplit_0.ForeColor = System.Drawing.SystemColors.WindowText
Me.txtSplit.SetIndex(Me._txtSplit_0, CType(0,Short))
Me._txtSplit_0.Location = New System.Drawing.Point(168, 16)
Me._txtSplit_0.MaxLength = 0
Me._txtSplit_0.Name = "_txtSplit_0"
Me._txtSplit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._txtSplit_0.Size = New System.Drawing.Size(65, 20)
Me._txtSplit_0.TabIndex = 173
Me._txtSplit_0.Tag = "p"
'
'_Label_47
'
Me._Label_47.AutoSize = true
Me._Label_47.BackColor = System.Drawing.SystemColors.Control
Me._Label_47.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_47.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_47.Location = New System.Drawing.Point(8, 64)
Me._Label_47.Name = "_Label_47"
Me._Label_47.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_47.Size = New System.Drawing.Size(93, 13)
Me._Label_47.TabIndex = 194
Me._Label_47.Text = "Spessore adottato"
'
'_lblMis_38
'
Me._lblMis_38.BackColor = System.Drawing.Color.Cyan
Me._lblMis_38.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_38.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_38.Location = New System.Drawing.Point(240, 64)
Me._lblMis_38.Name = "_lblMis_38"
Me._lblMis_38.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_38.Size = New System.Drawing.Size(40, 17)
Me._lblMis_38.TabIndex = 193
Me._lblMis_38.Text = "mm"
'
'_lblMis_34
'
Me._lblMis_34.BackColor = System.Drawing.Color.Cyan
Me._lblMis_34.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_34.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_34.Location = New System.Drawing.Point(240, 48)
Me._lblMis_34.Name = "_lblMis_34"
Me._lblMis_34.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_34.Size = New System.Drawing.Size(40, 17)
Me._lblMis_34.TabIndex = 181
Me._lblMis_34.Text = "mm"
'
'_Label_43
'
Me._Label_43.AutoSize = true
Me._Label_43.BackColor = System.Drawing.SystemColors.Control
Me._Label_43.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_43.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_43.Location = New System.Drawing.Point(8, 48)
Me._Label_43.Name = "_Label_43"
Me._Label_43.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_43.Size = New System.Drawing.Size(134, 13)
Me._Label_43.TabIndex = 180
Me._Label_43.Text = "Spessore minimo di calcolo"
'
'_lblMis_33
'
Me._lblMis_33.BackColor = System.Drawing.Color.Cyan
Me._lblMis_33.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_33.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_33.Location = New System.Drawing.Point(240, 32)
Me._lblMis_33.Name = "_lblMis_33"
Me._lblMis_33.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_33.Size = New System.Drawing.Size(40, 17)
Me._lblMis_33.TabIndex = 178
Me._lblMis_33.Text = "mm"
'
'_Label_42
'
Me._Label_42.AutoSize = true
Me._Label_42.BackColor = System.Drawing.SystemColors.Control
Me._Label_42.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_42.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_42.Location = New System.Drawing.Point(8, 32)
Me._Label_42.Name = "_Label_42"
Me._Label_42.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_42.Size = New System.Drawing.Size(84, 13)
Me._Label_42.TabIndex = 177
Me._Label_42.Text = "Diametro interno"
'
'_lblMis_32
'
Me._lblMis_32.BackColor = System.Drawing.Color.Cyan
Me._lblMis_32.Cursor = System.Windows.Forms.Cursors.Default
Me._lblMis_32.ForeColor = System.Drawing.SystemColors.ControlText
Me._lblMis_32.Location = New System.Drawing.Point(240, 16)
Me._lblMis_32.Name = "_lblMis_32"
Me._lblMis_32.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._lblMis_32.Size = New System.Drawing.Size(40, 17)
Me._lblMis_32.TabIndex = 175
Me._lblMis_32.Text = "mm"
'
'_Label_41
'
Me._Label_41.AutoSize = true
Me._Label_41.BackColor = System.Drawing.SystemColors.Control
Me._Label_41.Cursor = System.Windows.Forms.Cursors.Default
Me._Label_41.ForeColor = System.Drawing.SystemColors.ControlText
Me._Label_41.Location = New System.Drawing.Point(8, 16)
Me._Label_41.Name = "_Label_41"
Me._Label_41.RightToLeft = System.Windows.Forms.RightToLeft.No
Me._Label_41.Size = New System.Drawing.Size(87, 13)
Me._Label_41.TabIndex = 174
Me._Label_41.Text = "Diametro esterno"
'
'cmdtir
'
'
'txtDes
'
'
'txtSplit
'
'
'txtViti
'
'
'txtVitiExt
'
'
'txtVitiInt
'
'
'MainMenu1
'
Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menfile, Me.mnuAz, Me.PreferenzeToolStripMenuItem, Me.mnuGuide})
Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
Me.MainMenu1.Name = "MainMenu1"
Me.MainMenu1.Size = New System.Drawing.Size(623, 24)
Me.MainMenu1.TabIndex = 355
'
'menfile
'
Me.menfile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mennuovo, Me.menapri, Me.menChiudi, Me.menSalva, Me.menSalvaCome, Me.line1, Me.menstampa, Me.line2, Me.menEsci})
Me.menfile.Name = "menfile"
Me.menfile.Size = New System.Drawing.Size(35, 20)
Me.menfile.Text = "File"
'
'mennuovo
'
Me.mennuovo.Name = "mennuovo"
Me.mennuovo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N),System.Windows.Forms.Keys)
Me.mennuovo.Size = New System.Drawing.Size(167, 22)
Me.mennuovo.Text = "Nuovo"
'
'menapri
'
Me.menapri.Name = "menapri"
Me.menapri.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A),System.Windows.Forms.Keys)
Me.menapri.Size = New System.Drawing.Size(167, 22)
Me.menapri.Text = "Apri"
'
'menChiudi
'
Me.menChiudi.Name = "menChiudi"
Me.menChiudi.Size = New System.Drawing.Size(167, 22)
Me.menChiudi.Text = "Chiudi"
'
'menSalva
'
Me.menSalva.Name = "menSalva"
Me.menSalva.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S),System.Windows.Forms.Keys)
Me.menSalva.Size = New System.Drawing.Size(167, 22)
Me.menSalva.Text = "Salva"
'
'menSalvaCome
'
Me.menSalvaCome.Name = "menSalvaCome"
Me.menSalvaCome.Size = New System.Drawing.Size(167, 22)
Me.menSalvaCome.Text = "Salva come ..."
'
'line1
'
Me.line1.Name = "line1"
Me.line1.Size = New System.Drawing.Size(164, 6)
'
'menstampa
'
Me.menstampa.Name = "menstampa"
Me.menstampa.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P),System.Windows.Forms.Keys)
Me.menstampa.Size = New System.Drawing.Size(167, 22)
Me.menstampa.Text = "Stampa"
'
'line2
'
Me.line2.Name = "line2"
Me.line2.Size = New System.Drawing.Size(164, 6)
'
'menEsci
'
Me.menEsci.Name = "menEsci"
Me.menEsci.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E),System.Windows.Forms.Keys)
Me.menEsci.Size = New System.Drawing.Size(167, 22)
Me.menEsci.Text = "Esci"
'
'mnuAz
'
Me.mnuAz.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCalcolaTutto, Me.mnuAnn, Me.mnuCalcGeomAuto})
Me.mnuAz.Name = "mnuAz"
Me.mnuAz.Size = New System.Drawing.Size(47, 20)
Me.mnuAz.Text = "Azioni"
'
'mnuCalcolaTutto
'
Me.mnuCalcolaTutto.Name = "mnuCalcolaTutto"
Me.mnuCalcolaTutto.Size = New System.Drawing.Size(296, 22)
Me.mnuCalcolaTutto.Text = "Ricalcola tutto"
'
'mnuAnn
'
Me.mnuAnn.Name = "mnuAnn"
Me.mnuAnn.Size = New System.Drawing.Size(296, 22)
Me.mnuAnn.Text = "Annulla tutto"
'
'mnuCalcGeomAuto
'
Me.mnuCalcGeomAuto.Name = "mnuCalcGeomAuto"
Me.mnuCalcGeomAuto.Size = New System.Drawing.Size(296, 22)
Me.mnuCalcGeomAuto.Text = "Riattiva il calcolo automatico della geometria"
'
'PreferenzeToolStripMenuItem
'
Me.PreferenzeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrefBuckling, Me.mnuVitiSnerv, Me.menVitiAutomatiche, Me.mnuAutomEstensioni})
Me.PreferenzeToolStripMenuItem.Name = "PreferenzeToolStripMenuItem"
Me.PreferenzeToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
Me.PreferenzeToolStripMenuItem.Text = "Preferenze"
'
'mnuPrefBuckling
'
Me.mnuPrefBuckling.Checked = true
Me.mnuPrefBuckling.CheckState = System.Windows.Forms.CheckState.Indeterminate
Me.mnuPrefBuckling.Name = "mnuPrefBuckling"
Me.mnuPrefBuckling.Size = New System.Drawing.Size(284, 22)
Me.mnuPrefBuckling.Text = "Verifica cassonetto a buckling"
'
'mnuVitiSnerv
'
Me.mnuVitiSnerv.Checked = true
Me.mnuVitiSnerv.CheckState = System.Windows.Forms.CheckState.Indeterminate
Me.mnuVitiSnerv.Name = "mnuVitiSnerv"
Me.mnuVitiSnerv.Size = New System.Drawing.Size(284, 22)
Me.mnuVitiSnerv.Text = "Verifica viti a snervamento"
'
'menVitiAutomatiche
'
Me.menVitiAutomatiche.Checked = true
Me.menVitiAutomatiche.CheckState = System.Windows.Forms.CheckState.Indeterminate
Me.menVitiAutomatiche.Name = "menVitiAutomatiche"
Me.menVitiAutomatiche.Size = New System.Drawing.Size(284, 22)
Me.menVitiAutomatiche.Text = "Calcolo automatico viti"
'
'mnuAutomEstensioni
'
Me.mnuAutomEstensioni.Checked = true
Me.mnuAutomEstensioni.CheckState = System.Windows.Forms.CheckState.Indeterminate
Me.mnuAutomEstensioni.Name = "mnuAutomEstensioni"
Me.mnuAutomEstensioni.Size = New System.Drawing.Size(284, 22)
Me.mnuAutomEstensioni.Text = "Calcolo automatico estensione viti interne"
'
'mnuGuide
'
Me.mnuGuide.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGuiBre, Me.mnuInf})
Me.mnuGuide.Name = "mnuGuide"
Me.mnuGuide.Size = New System.Drawing.Size(46, 20)
Me.mnuGuide.Text = "Guide"
'
'mnuGuiBre
'
Me.mnuGuiBre.Name = "mnuGuiBre"
Me.mnuGuiBre.Size = New System.Drawing.Size(160, 22)
Me.mnuGuiBre.Text = "Guida di Brelock"
'
'mnuInf
'
Me.mnuInf.Name = "mnuInf"
Me.mnuInf.Size = New System.Drawing.Size(160, 22)
Me.mnuInf.Text = "Informazioni"
'
'TabStrip1
'
Me.TabStrip1.Controls.Add(Me.TabPage1)
Me.TabStrip1.Controls.Add(Me.TabPage2)
Me.TabStrip1.Controls.Add(Me.TabPage3)
Me.TabStrip1.Controls.Add(Me.TabPage4)
Me.TabStrip1.Controls.Add(Me.TabPage5)
Me.TabStrip1.Controls.Add(Me.TabPage6)
Me.TabStrip1.Controls.Add(Me.TabPage7)
Me.TabStrip1.Controls.Add(Me.TabPage8)
Me.TabStrip1.Controls.Add(Me.TabPage9)
Me.TabStrip1.Location = New System.Drawing.Point(8, 32)
Me.TabStrip1.Name = "TabStrip1"
Me.TabStrip1.SelectedIndex = 0
Me.TabStrip1.Size = New System.Drawing.Size(608, 400)
Me.TabStrip1.TabIndex = 356
'
'TabPage1
'
Me.TabPage1.Controls.Add(Me._pctFrames_0)
Me.TabPage1.Location = New System.Drawing.Point(4, 22)
Me.TabPage1.Name = "TabPage1"
Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage1.Size = New System.Drawing.Size(600, 374)
Me.TabPage1.TabIndex = 0
Me.TabPage1.Text = "Dati generali"
Me.TabPage1.UseVisualStyleBackColor = true
'
'TabPage2
'
Me.TabPage2.Controls.Add(Me._pctFrames_1)
Me.TabPage2.Location = New System.Drawing.Point(4, 22)
Me.TabPage2.Name = "TabPage2"
Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage2.Size = New System.Drawing.Size(600, 374)
Me.TabPage2.TabIndex = 1
Me.TabPage2.Text = "Mantello"
Me.TabPage2.UseVisualStyleBackColor = true
'
'TabPage3
'
Me.TabPage3.Controls.Add(Me._pctFrames_2)
Me.TabPage3.Location = New System.Drawing.Point(4, 22)
Me.TabPage3.Name = "TabPage3"
Me.TabPage3.Size = New System.Drawing.Size(600, 374)
Me.TabPage3.TabIndex = 2
Me.TabPage3.Text = "Piastra Tubiera"
Me.TabPage3.UseVisualStyleBackColor = true
'
'TabPage4
'
Me.TabPage4.Controls.Add(Me._pctFrames_3)
Me.TabPage4.Location = New System.Drawing.Point(4, 22)
Me.TabPage4.Name = "TabPage4"
Me.TabPage4.Size = New System.Drawing.Size(600, 374)
Me.TabPage4.TabIndex = 3
Me.TabPage4.Text = "Viti interne"
Me.TabPage4.UseVisualStyleBackColor = true
'
'TabPage5
'
Me.TabPage5.Controls.Add(Me._pctFrames_4)
Me.TabPage5.Location = New System.Drawing.Point(4, 22)
Me.TabPage5.Name = "TabPage5"
Me.TabPage5.Size = New System.Drawing.Size(600, 374)
Me.TabPage5.TabIndex = 4
Me.TabPage5.Text = "Rings"
Me.TabPage5.UseVisualStyleBackColor = true
'
'TabPage6
'
Me.TabPage6.Controls.Add(Me._pctFrames_5)
Me.TabPage6.Location = New System.Drawing.Point(4, 22)
Me.TabPage6.Name = "TabPage6"
Me.TabPage6.Size = New System.Drawing.Size(600, 374)
Me.TabPage6.TabIndex = 5
Me.TabPage6.Text = "Cassonetto"
Me.TabPage6.UseVisualStyleBackColor = true
'
'TabPage7
'
Me.TabPage7.Controls.Add(Me._pctFrames_6)
Me.TabPage7.Location = New System.Drawing.Point(4, 22)
Me.TabPage7.Name = "TabPage7"
Me.TabPage7.Size = New System.Drawing.Size(600, 374)
Me.TabPage7.TabIndex = 6
Me.TabPage7.Text = "Cassa"
Me.TabPage7.UseVisualStyleBackColor = true
'
'TabPage8
'
Me.TabPage8.Controls.Add(Me._pctFrames_7)
Me.TabPage8.Location = New System.Drawing.Point(4, 22)
Me.TabPage8.Name = "TabPage8"
Me.TabPage8.Size = New System.Drawing.Size(600, 374)
Me.TabPage8.TabIndex = 7
Me.TabPage8.Text = "Viti esterne"
Me.TabPage8.UseVisualStyleBackColor = true
'
'TabPage9
'
Me.TabPage9.Controls.Add(Me._pctFrames_8)
Me.TabPage9.Location = New System.Drawing.Point(4, 22)
Me.TabPage9.Name = "TabPage9"
Me.TabPage9.Size = New System.Drawing.Size(600, 374)
Me.TabPage9.TabIndex = 8
Me.TabPage9.Text = "LockRing"
Me.TabPage9.UseVisualStyleBackColor = true
'
'StatusBar1
'
Me.StatusBar1.Location = New System.Drawing.Point(0, 512)
Me.StatusBar1.Name = "StatusBar1"
Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
Me.StatusBar1.ShowPanels = true
Me.StatusBar1.Size = New System.Drawing.Size(623, 16)
Me.StatusBar1.TabIndex = 357
'
'StatusBarPanel1
'
Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
Me.StatusBarPanel1.MinWidth = 350
Me.StatusBarPanel1.Name = "StatusBarPanel1"
Me.StatusBarPanel1.Text = "Area di lavoro:"
Me.StatusBarPanel1.Width = 350
'
'StatusBarPanel2
'
Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
Me.StatusBarPanel2.MinWidth = 120
Me.StatusBarPanel2.Name = "StatusBarPanel2"
Me.StatusBarPanel2.Text = "Prev:"
Me.StatusBarPanel2.Width = 120
'
'StatusBarPanel3
'
Me.StatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
Me.StatusBarPanel3.MinWidth = 120
Me.StatusBarPanel3.Name = "StatusBarPanel3"
Me.StatusBarPanel3.Text = "Item:"
Me.StatusBarPanel3.Width = 136
'
'frmApert
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.SystemColors.Control
Me.ClientSize = New System.Drawing.Size(623, 528)
Me.Controls.Add(Me.StatusBar1)
Me.Controls.Add(Me.TabStrip1)
Me.Controls.Add(Me.rtLogo)
Me.Controls.Add(Me.Commento)
Me.Controls.Add(Me.MainMenu1)
Me.Cursor = System.Windows.Forms.Cursors.Default
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.HelpButton = true
Me.Location = New System.Drawing.Point(123, 122)
Me.MaximizeBox = false
Me.MinimizeBox = false
Me.Name = "frmApert"
Me.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Progetto chiusure Breech-Lock"
CType(Me.UpDownMat,System.ComponentModel.ISupportInitialize).EndInit
Me.Commento.ResumeLayout(false)
Me._pctFrames_0.ResumeLayout(false)
Me.framNorme.ResumeLayout(false)
Me.framDiff.ResumeLayout(false)
Me.framTipo.ResumeLayout(false)
Me.framPDiffHT.ResumeLayout(false)
Me.framPDiffHT.PerformLayout
Me.framMat.ResumeLayout(false)
Me.framMat.PerformLayout
Me._pctFrames_1.ResumeLayout(false)
Me.framHead.ResumeLayout(false)
Me.framHead.PerformLayout
Me.framGsk1.ResumeLayout(false)
Me.framGsk1.PerformLayout
Me.framShell.ResumeLayout(false)
Me.framShell.PerformLayout
Me._pctFrames_3.ResumeLayout(false)
Me._pctFrames_3.PerformLayout
Me.framCarichi.ResumeLayout(false)
Me.framCarichi.PerformLayout
Me.framViti.ResumeLayout(false)
Me.framViti.PerformLayout
Me._pctFrames_6.ResumeLayout(false)
Me.framChan.ResumeLayout(false)
Me.framChan.PerformLayout
Me.Frame2.ResumeLayout(false)
Me.Frame2.PerformLayout
Me._pctFrames_7.ResumeLayout(false)
Me.framCarInt.ResumeLayout(false)
Me.framCarInt.PerformLayout
Me.framAltri2.ResumeLayout(false)
Me.framAltri2.PerformLayout
Me.framCarExt.ResumeLayout(false)
Me.framCarExt.PerformLayout
Me.framExtScr.ResumeLayout(false)
Me.framExtScr.PerformLayout
Me.framIntScr2.ResumeLayout(false)
Me.framIntScr2.PerformLayout
Me._pctFrames_2.ResumeLayout(false)
Me.framHTDiff.ResumeLayout(false)
Me.framHTDiff.PerformLayout
Me.framPT.ResumeLayout(false)
Me.framPT.PerformLayout
Me.framTubes.ResumeLayout(false)
Me.framTubes.PerformLayout
Me._pctFrames_8.ResumeLayout(false)
Me.Frame6.ResumeLayout(false)
Me.Frame6.PerformLayout
Me.Frame5.ResumeLayout(false)
Me.Frame5.PerformLayout
Me.Frame4.ResumeLayout(false)
Me.Frame4.PerformLayout
Me.Frame3.ResumeLayout(false)
Me.Frame3.PerformLayout
Me._pctFrames_5.ResumeLayout(false)
Me.Frame1.ResumeLayout(false)
Me.Frame1.PerformLayout
Me.framFC.ResumeLayout(false)
Me.framFC.PerformLayout
Me.framRot.ResumeLayout(false)
Me.framRot.PerformLayout
Me._pctFrames_4.ResumeLayout(false)
Me.framCorr.ResumeLayout(false)
Me.framCorr.PerformLayout
Me.framAltri.ResumeLayout(false)
Me.framAltri.PerformLayout
Me.framBear.ResumeLayout(false)
Me.framBear.PerformLayout
Me.framInner.ResumeLayout(false)
Me.framInner.PerformLayout
Me.framSplit.ResumeLayout(false)
Me.framSplit.PerformLayout
CType(Me.cmdtir,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.txtDes,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.txtSplit,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.txtViti,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.txtVitiExt,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.txtVitiInt,System.ComponentModel.ISupportInitialize).EndInit
Me.MainMenu1.ResumeLayout(false)
Me.MainMenu1.PerformLayout
Me.TabStrip1.ResumeLayout(false)
Me.TabPage1.ResumeLayout(false)
Me.TabPage2.ResumeLayout(false)
Me.TabPage3.ResumeLayout(false)
Me.TabPage4.ResumeLayout(false)
Me.TabPage5.ResumeLayout(false)
Me.TabPage6.ResumeLayout(false)
Me.TabPage7.ResumeLayout(false)
Me.TabPage8.ResumeLayout(false)
Me.TabPage9.ResumeLayout(false)
CType(Me.StatusBarPanel1,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.StatusBarPanel2,System.ComponentModel.ISupportInitialize).EndInit
CType(Me.StatusBarPanel3,System.ComponentModel.ISupportInitialize).EndInit
Me.ResumeLayout(false)
Me.PerformLayout

End Sub
    Friend WithEvents TabStrip1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents UpDownMat As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdRicalcola As System.Windows.Forms.Button
    Friend WithEvents cmdSel As System.Windows.Forms.Button
    Friend WithEvents menChiudi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents txtTroppiTiranti As System.Windows.Forms.TextBox
    Friend WithEvents txtSizeScr As System.Windows.Forms.TextBox
    Public WithEvents _txtSplit_11 As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents framCorr As System.Windows.Forms.GroupBox
    Friend WithEvents mnuInf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRicalcRings As System.Windows.Forms.Button
    Public WithEvents _txtShell_16 As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkAnelloInt As System.Windows.Forms.CheckBox
    Public WithEvents _txtShell_17 As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAnelloEst As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRicalcShell As System.Windows.Forms.Button
    Public WithEvents _txtChan_13 As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkAnelloEst2 As System.Windows.Forms.CheckBox
    Public WithEvents _txtChan_12 As System.Windows.Forms.TextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkAnelloInt2 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRicalcCassa As System.Windows.Forms.Button
    Public WithEvents _txtShell_18 As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents _txtchan_14 As System.Windows.Forms.TextBox
    Friend WithEvents cmdRicalcCasson As System.Windows.Forms.Button
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents TextBox2 As System.Windows.Forms.TextBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents _txtLR_23 As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkSuperSafe As System.Windows.Forms.CheckBox
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents _txtLR_24 As System.Windows.Forms.TextBox
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents _txtLR_25 As System.Windows.Forms.TextBox
    Friend WithEvents chkNonCalcolaFondo As System.Windows.Forms.CheckBox
    Public WithEvents cmdEstensioneAutomatica As System.Windows.Forms.Button
    Friend WithEvents PreferenzeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrefBuckling As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVitiSnerv As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cmdMinCasson As System.Windows.Forms.Button
    Friend WithEvents CommonDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuAutomEstensioni As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menSalvaCome As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents framNorme As System.Windows.Forms.GroupBox
    Public WithEvents optdiv1 As System.Windows.Forms.RadioButton
    Public WithEvents optdiv2 As System.Windows.Forms.RadioButton
    Public WithEvents optdiv3 As System.Windows.Forms.RadioButton
    Friend WithEvents menVitiAutomatiche As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCalcolaTutto As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _txtPT_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtPT_9 As System.Windows.Forms.TextBox
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents mnuCalcGeomAuto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbTipoCassonetto As System.Windows.Forms.ComboBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents _txtLR_26 As System.Windows.Forms.TextBox
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
#End Region
End Class