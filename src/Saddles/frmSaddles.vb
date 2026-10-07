Option Strict Off
Option Explicit On 
Imports System.String
Imports System.Windows.Forms
Imports System.Windows.Forms.Application
Imports System.Drawing.Drawing2D
Imports RoutBase1
Friend Class frmSaddles
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
        Inizializza()
        Inizializzando = False
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
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents mnuApri As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuVerb As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPref As System.Windows.Forms.ToolStripMenuItem
	Public MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents mnuSalva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalvaCome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAzioni As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPrimoLivDown As System.Windows.Forms.TabControl
    Friend WithEvents PagCarichi As System.Windows.Forms.TabPage
    Friend WithEvents PagCalcSelle As System.Windows.Forms.TabPage
    Friend WithEvents PagCalcMant As System.Windows.Forms.TabPage
    Friend WithEvents mnuCodice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Commondialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TabCarichiDown As System.Windows.Forms.TabControl
    Friend WithEvents PagDatiGenerali As System.Windows.Forms.TabPage
    Friend WithEvents PagCombinazioni As System.Windows.Forms.TabPage
    Friend WithEvents PagCarichiBocchelli As System.Windows.Forms.TabPage
    Friend WithEvents PagCarichiFondazioni As System.Windows.Forms.TabPage
    Public WithEvents _Text3_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label4_0 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Friend WithEvents TabCombCarDown As System.Windows.Forms.TabControl
    Friend WithEvents PagCombMant As System.Windows.Forms.TabPage
    Friend WithEvents PagCombSelle As System.Windows.Forms.TabPage
    Friend WithEvents PagCombFonda As System.Windows.Forms.TabPage
    Friend WithEvents dgCombMant As System.Windows.Forms.DataGrid
    Friend WithEvents dgCombsadd As System.Windows.Forms.DataGrid
    Friend WithEvents dgCombfond As System.Windows.Forms.DataGrid
    Friend WithEvents dgElemMant As System.Windows.Forms.DataGrid
    Friend WithEvents dgElemSadd As System.Windows.Forms.DataGrid
    Friend WithEvents dgElemfond As System.Windows.Forms.DataGrid
    Friend WithEvents cmdRiprMant As System.Windows.Forms.Button
    Friend WithEvents cmdRiprSadd As System.Windows.Forms.Button
    Friend WithEvents cmdRiprFond As System.Windows.Forms.Button
    Friend WithEvents TabBocchDown As System.Windows.Forms.TabControl
    Friend WithEvents PagListaBocchelli As System.Windows.Forms.TabPage
    Friend WithEvents PagT1 As System.Windows.Forms.TabPage
    Friend WithEvents dgListaBocchelli As System.Windows.Forms.DataGrid
    Friend WithEvents dgCarBocch1 As System.Windows.Forms.DataGrid
    Friend WithEvents TabCarFondDown As System.Windows.Forms.TabControl
    Friend WithEvents PagRisultBocchelli As System.Windows.Forms.TabPage
    Friend WithEvents PagCarichiFinali As System.Windows.Forms.TabPage
    Friend WithEvents lblNienteCarichi As System.Windows.Forms.Label
    Friend WithEvents cmdRiprBocch As System.Windows.Forms.Button
    Friend WithEvents dgCarFond As System.Windows.Forms.DataGrid
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PagVento As System.Windows.Forms.TabPage
    Friend WithEvents PagSisma As System.Windows.Forms.TabPage
    Public WithEvents txtLateralArea As System.Windows.Forms.TextBox
    Public WithEvents lblLateralArea As System.Windows.Forms.Label
    Friend WithEvents rtfLateralArea As System.Windows.Forms.RichTextBox
    Friend WithEvents rtfFrontArea As System.Windows.Forms.RichTextBox
    Public WithEvents txtFrontArea As System.Windows.Forms.TextBox
    Public WithEvents lblFrontArea As System.Windows.Forms.Label
    Friend WithEvents rtfPressure As System.Windows.Forms.RichTextBox
    Public WithEvents txtPressure As System.Windows.Forms.TextBox
    Public WithEvents lblPressure As System.Windows.Forms.Label
    Friend WithEvents rtfFrontForce As System.Windows.Forms.RichTextBox
    Public WithEvents txtFrontForce As System.Windows.Forms.TextBox
    Public WithEvents lblFrontForce As System.Windows.Forms.Label
    Friend WithEvents rtfLateralForce As System.Windows.Forms.RichTextBox
    Public WithEvents txtLateralForce As System.Windows.Forms.TextBox
    Public WithEvents lblLateralForce As System.Windows.Forms.Label
    Friend WithEvents lblCodiceVento As System.Windows.Forms.Label
    Friend WithEvents lblsLateralArea As System.Windows.Forms.Label
    Friend WithEvents lblsFrontArea As System.Windows.Forms.Label
    Friend WithEvents lblsPressure As System.Windows.Forms.Label
    Friend WithEvents lblsLateralForce As System.Windows.Forms.Label
    Friend WithEvents lblsFrontForce As System.Windows.Forms.Label
    Friend WithEvents mnuVento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSisma As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _lblsVento_0 As System.Windows.Forms.Label
    Friend WithEvents _rtfVento_0 As System.Windows.Forms.RichTextBox
    Public WithEvents _txtVento_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblVento_0 As System.Windows.Forms.Label
    Friend WithEvents _lblsSisma_0 As System.Windows.Forms.Label
    Friend WithEvents _rtfSisma_0 As System.Windows.Forms.RichTextBox
    Public WithEvents _txtSisma_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblSisma_0 As System.Windows.Forms.Label
    Friend WithEvents rtfFormulaVento As System.Windows.Forms.RichTextBox
    Friend WithEvents lblsForceSeism As System.Windows.Forms.Label
    Friend WithEvents rtfFormulaSisma As System.Windows.Forms.RichTextBox
    Friend WithEvents rtfForceSeism As System.Windows.Forms.RichTextBox
    Public WithEvents txtForceSeism As System.Windows.Forms.TextBox
    Public WithEvents lblForceSeism As System.Windows.Forms.Label
    Friend WithEvents lblCodiceSisma As System.Windows.Forms.Label
    Friend WithEvents PagCalcFonda As System.Windows.Forms.TabPage
    Public WithEvents Picture2 As System.Windows.Forms.PictureBox
    Public WithEvents Check2 As System.Windows.Forms.CheckBox
    Friend WithEvents TabTensMantDown As System.Windows.Forms.TabControl
    Friend WithEvents PagCalcMantProg As System.Windows.Forms.TabPage
    Friend WithEvents PagCalcMantDim As System.Windows.Forms.TabPage
    Public WithEvents cmdAmmiss As System.Windows.Forms.Button
    Public WithEvents cmdMat As System.Windows.Forms.Button
    Public WithEvents _Text2_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo2_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Friend WithEvents cmdCalcMant As System.Windows.Forms.Button
    Public WithEvents _Check1_0 As System.Windows.Forms.CheckBox
    Public WithEvents _Text41_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label42_0 As System.Windows.Forms.Label
    Public WithEvents _Label41_0 As System.Windows.Forms.Label
    Public WithEvents _Text62_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo62_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Text61_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label62_0 As System.Windows.Forms.Label
    Public WithEvents _Label61_0 As System.Windows.Forms.Label
    Friend WithEvents cmdCalcMant6 As System.Windows.Forms.Button
    Friend WithEvents mnuStampa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pctSimpleComplex As System.Windows.Forms.PictureBox
    Public WithEvents cmdLibrTir As System.Windows.Forms.Button
    Friend WithEvents cmdCalcMant5 As System.Windows.Forms.Button
    Public WithEvents _Text52_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo52_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Text51_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label52_0 As System.Windows.Forms.Label
    Public WithEvents _Label51_0 As System.Windows.Forms.Label
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents PagDown As System.Windows.Forms.TabPage
    Friend WithEvents PagUp As System.Windows.Forms.TabPage
    Friend WithEvents TabPrimoLivUp As System.Windows.Forms.TabControl
    Friend WithEvents PagCarichiT As System.Windows.Forms.TabPage
    Friend WithEvents PagCalcMantT As System.Windows.Forms.TabPage
    Friend WithEvents PagCalcSelleT As System.Windows.Forms.TabPage
    Friend WithEvents TabCarichiUp As System.Windows.Forms.TabControl
    Friend WithEvents PagDatiGeneraliT As System.Windows.Forms.TabPage
    Public WithEvents _Text3T_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label4T_0 As System.Windows.Forms.Label
    Public WithEvents _Label3T_0 As System.Windows.Forms.Label
    Friend WithEvents PagCarichiBocchelliT As System.Windows.Forms.TabPage
    Friend WithEvents PagCarichiFondazioniT As System.Windows.Forms.TabPage
    Friend WithEvents TabBocchUp As System.Windows.Forms.TabControl
    Friend WithEvents PagListaBocchelliT As System.Windows.Forms.TabPage
    Friend WithEvents cmdRiprBocchT As System.Windows.Forms.Button
    Friend WithEvents dgListaBocchelliT As System.Windows.Forms.DataGrid
    Friend WithEvents PagT1T As System.Windows.Forms.TabPage
    Friend WithEvents dgCarBocchT1 As System.Windows.Forms.DataGrid
    Friend WithEvents TabCarFondUp As System.Windows.Forms.TabControl
    Friend WithEvents PagRisultBocchelliT As System.Windows.Forms.TabPage
    Friend WithEvents PagSismaT As System.Windows.Forms.TabPage
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblNienteCarichiT As System.Windows.Forms.Label
    Friend WithEvents PagVentoT As System.Windows.Forms.TabPage
    Friend WithEvents _lblsVentoT_0 As System.Windows.Forms.Label
    Friend WithEvents _rtfVentoT_0 As System.Windows.Forms.RichTextBox
    Public WithEvents _lblVentoT_0 As System.Windows.Forms.Label
    Public WithEvents lblLateralAreaT As System.Windows.Forms.Label
    Friend WithEvents PagCarichifinaliT As System.Windows.Forms.TabPage
    Friend WithEvents lblsFrontForceT As System.Windows.Forms.Label
    Friend WithEvents lblsLateralForceT As System.Windows.Forms.Label
    Friend WithEvents lblsPressureT As System.Windows.Forms.Label
    Friend WithEvents lblsFrontAreaT As System.Windows.Forms.Label
    Friend WithEvents lblsLateralAreaT As System.Windows.Forms.Label
    Friend WithEvents rtfFormulaVentoT As System.Windows.Forms.RichTextBox
    Friend WithEvents rtfFrontForceT As System.Windows.Forms.RichTextBox
    Public WithEvents txtFrontForceT As System.Windows.Forms.TextBox
    Public WithEvents lblFrontForceT As System.Windows.Forms.Label
    Friend WithEvents rtfLateralForceT As System.Windows.Forms.RichTextBox
    Public WithEvents txtLateralForceT As System.Windows.Forms.TextBox
    Public WithEvents lblLateralForceT As System.Windows.Forms.Label
    Friend WithEvents rtfPressureT As System.Windows.Forms.RichTextBox
    Public WithEvents txtPressureT As System.Windows.Forms.TextBox
    Public WithEvents lblPressureT As System.Windows.Forms.Label
    Friend WithEvents rtfFrontAreaT As System.Windows.Forms.RichTextBox
    Public WithEvents txtFrontAreaT As System.Windows.Forms.TextBox
    Public WithEvents lblFrontAreaT As System.Windows.Forms.Label
    Friend WithEvents rtfLateralAreaT As System.Windows.Forms.RichTextBox
    Public WithEvents txtLateralAreaT As System.Windows.Forms.TextBox
    Friend WithEvents _lblsSismaT_0 As System.Windows.Forms.Label
    Friend WithEvents _rtfSismaT_0 As System.Windows.Forms.RichTextBox
    Public WithEvents _lblSismaT_0 As System.Windows.Forms.Label
    Friend WithEvents lblsForceSeismT As System.Windows.Forms.Label
    Friend WithEvents rtfFormulaSismaT As System.Windows.Forms.RichTextBox
    Friend WithEvents lblCodiceSismaT As System.Windows.Forms.Label
    Friend WithEvents rtfForceSeismT As System.Windows.Forms.RichTextBox
    Public WithEvents txtForceSeismT As System.Windows.Forms.TextBox
    Public WithEvents lblForceSeismT As System.Windows.Forms.Label
    Friend WithEvents dgCarFondT As System.Windows.Forms.DataGrid
    Friend WithEvents TabTensMantUp As System.Windows.Forms.TabControl
    Friend WithEvents PagCalcMantProgT As System.Windows.Forms.TabPage
    Public WithEvents cmdAmmissT As System.Windows.Forms.Button
    Public WithEvents cmdMatT As System.Windows.Forms.Button
    Public WithEvents _Text2T_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo2T_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Text1T_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo1T_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Label1T_0 As System.Windows.Forms.Label
    Friend WithEvents PagCalcMantDimT As System.Windows.Forms.TabPage
    Friend WithEvents cmdCalcMant5T As System.Windows.Forms.Button
    Public WithEvents _Text52T_0 As System.Windows.Forms.TextBox
    Public WithEvents _Combo52T_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Text51T_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label52T_0 As System.Windows.Forms.Label
    Public WithEvents _Label51T_0 As System.Windows.Forms.Label
    Public WithEvents _Text41T_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label42T_0 As System.Windows.Forms.Label
    Public WithEvents _Label41T_0 As System.Windows.Forms.Label
    Friend WithEvents cmdCalcMantT As System.Windows.Forms.Button
    Public WithEvents _Check1T_0 As System.Windows.Forms.CheckBox
    Friend WithEvents mnuStacked As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCodiceVentoT As System.Windows.Forms.Label
    Public WithEvents _txtVentoT_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtSismaT_0 As System.Windows.Forms.TextBox
    Friend WithEvents PagCarichiDaSopra As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgCarSopra As System.Windows.Forms.DataGrid
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Public WithEvents _Label2T_0 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSaddles))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdRiprMant = New System.Windows.Forms.Button
        Me.cmdRiprSadd = New System.Windows.Forms.Button
        Me.cmdRiprFond = New System.Windows.Forms.Button
        Me.cmdRiprBocch = New System.Windows.Forms.Button
        Me.cmdRiprBocchT = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuApri = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSalva = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSalvaCome = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAzioni = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStampa = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPref = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVerb = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCodice = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVento = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSisma = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStacked = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPrimoLivDown = New System.Windows.Forms.TabControl
        Me.PagCarichi = New System.Windows.Forms.TabPage
        Me.TabCarichiDown = New System.Windows.Forms.TabControl
        Me.PagDatiGenerali = New System.Windows.Forms.TabPage
        Me.pctSimpleComplex = New System.Windows.Forms.PictureBox
        Me._Text3_0 = New System.Windows.Forms.TextBox
        Me._Label4_0 = New System.Windows.Forms.Label
        Me._Label3_0 = New System.Windows.Forms.Label
        Me.PagCarichiBocchelli = New System.Windows.Forms.TabPage
        Me.TabBocchDown = New System.Windows.Forms.TabControl
        Me.PagListaBocchelli = New System.Windows.Forms.TabPage
        Me.dgListaBocchelli = New System.Windows.Forms.DataGrid
        Me.PagT1 = New System.Windows.Forms.TabPage
        Me.dgCarBocch1 = New System.Windows.Forms.DataGrid
        Me.PagCarichiFondazioni = New System.Windows.Forms.TabPage
        Me.TabCarFondDown = New System.Windows.Forms.TabControl
        Me.PagRisultBocchelli = New System.Windows.Forms.TabPage
        Me.lblNienteCarichi = New System.Windows.Forms.Label
        Me.PagSisma = New System.Windows.Forms.TabPage
        Me._lblsSisma_0 = New System.Windows.Forms.Label
        Me._rtfSisma_0 = New System.Windows.Forms.RichTextBox
        Me._txtSisma_0 = New System.Windows.Forms.TextBox
        Me._lblSisma_0 = New System.Windows.Forms.Label
        Me.lblsForceSeism = New System.Windows.Forms.Label
        Me.rtfFormulaSisma = New System.Windows.Forms.RichTextBox
        Me.lblCodiceSisma = New System.Windows.Forms.Label
        Me.rtfForceSeism = New System.Windows.Forms.RichTextBox
        Me.txtForceSeism = New System.Windows.Forms.TextBox
        Me.lblForceSeism = New System.Windows.Forms.Label
        Me.PagVento = New System.Windows.Forms.TabPage
        Me._lblsVento_0 = New System.Windows.Forms.Label
        Me._rtfVento_0 = New System.Windows.Forms.RichTextBox
        Me._txtVento_0 = New System.Windows.Forms.TextBox
        Me._lblVento_0 = New System.Windows.Forms.Label
        Me.lblsFrontForce = New System.Windows.Forms.Label
        Me.lblsLateralForce = New System.Windows.Forms.Label
        Me.lblsPressure = New System.Windows.Forms.Label
        Me.lblsFrontArea = New System.Windows.Forms.Label
        Me.lblsLateralArea = New System.Windows.Forms.Label
        Me.rtfFormulaVento = New System.Windows.Forms.RichTextBox
        Me.lblCodiceVento = New System.Windows.Forms.Label
        Me.rtfFrontForce = New System.Windows.Forms.RichTextBox
        Me.txtFrontForce = New System.Windows.Forms.TextBox
        Me.lblFrontForce = New System.Windows.Forms.Label
        Me.rtfLateralForce = New System.Windows.Forms.RichTextBox
        Me.txtLateralForce = New System.Windows.Forms.TextBox
        Me.lblLateralForce = New System.Windows.Forms.Label
        Me.rtfPressure = New System.Windows.Forms.RichTextBox
        Me.txtPressure = New System.Windows.Forms.TextBox
        Me.lblPressure = New System.Windows.Forms.Label
        Me.rtfFrontArea = New System.Windows.Forms.RichTextBox
        Me.txtFrontArea = New System.Windows.Forms.TextBox
        Me.lblFrontArea = New System.Windows.Forms.Label
        Me.rtfLateralArea = New System.Windows.Forms.RichTextBox
        Me.txtLateralArea = New System.Windows.Forms.TextBox
        Me.lblLateralArea = New System.Windows.Forms.Label
        Me.PagCarichiDaSopra = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgCarSopra = New System.Windows.Forms.DataGrid
        Me.PagCarichiFinali = New System.Windows.Forms.TabPage
        Me.lblNota = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgCarFond = New System.Windows.Forms.DataGrid
        Me.PagCombinazioni = New System.Windows.Forms.TabPage
        Me.TabCombCarDown = New System.Windows.Forms.TabControl
        Me.PagCombMant = New System.Windows.Forms.TabPage
        Me.dgElemMant = New System.Windows.Forms.DataGrid
        Me.dgCombMant = New System.Windows.Forms.DataGrid
        Me.PagCombSelle = New System.Windows.Forms.TabPage
        Me.dgElemSadd = New System.Windows.Forms.DataGrid
        Me.dgCombsadd = New System.Windows.Forms.DataGrid
        Me.PagCombFonda = New System.Windows.Forms.TabPage
        Me.dgElemfond = New System.Windows.Forms.DataGrid
        Me.dgCombfond = New System.Windows.Forms.DataGrid
        Me.PagCalcMant = New System.Windows.Forms.TabPage
        Me.TabTensMantDown = New System.Windows.Forms.TabControl
        Me.PagCalcMantProg = New System.Windows.Forms.TabPage
        Me.cmdAmmiss = New System.Windows.Forms.Button
        Me.cmdMat = New System.Windows.Forms.Button
        Me._Text2_0 = New System.Windows.Forms.TextBox
        Me._Combo2_0 = New System.Windows.Forms.ComboBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.PagCalcMantDim = New System.Windows.Forms.TabPage
        Me._Text41_0 = New System.Windows.Forms.TextBox
        Me._Label42_0 = New System.Windows.Forms.Label
        Me._Label41_0 = New System.Windows.Forms.Label
        Me.cmdCalcMant = New System.Windows.Forms.Button
        Me._Check1_0 = New System.Windows.Forms.CheckBox
        Me.PagCalcSelle = New System.Windows.Forms.TabPage
        Me.cmdCalcMant5 = New System.Windows.Forms.Button
        Me._Text52_0 = New System.Windows.Forms.TextBox
        Me._Combo52_0 = New System.Windows.Forms.ComboBox
        Me._Text51_0 = New System.Windows.Forms.TextBox
        Me._Label52_0 = New System.Windows.Forms.Label
        Me._Label51_0 = New System.Windows.Forms.Label
        Me.PagCalcFonda = New System.Windows.Forms.TabPage
        Me.cmdLibrTir = New System.Windows.Forms.Button
        Me.cmdCalcMant6 = New System.Windows.Forms.Button
        Me._Text62_0 = New System.Windows.Forms.TextBox
        Me._Combo62_0 = New System.Windows.Forms.ComboBox
        Me._Text61_0 = New System.Windows.Forms.TextBox
        Me._Label62_0 = New System.Windows.Forms.Label
        Me._Label61_0 = New System.Windows.Forms.Label
        Me.Check2 = New System.Windows.Forms.CheckBox
        Me.Picture2 = New System.Windows.Forms.PictureBox
        Me.Commondialog1 = New System.Windows.Forms.SaveFileDialog
        Me.TabMain = New System.Windows.Forms.TabControl
        Me.PagDown = New System.Windows.Forms.TabPage
        Me.PagUp = New System.Windows.Forms.TabPage
        Me.TabPrimoLivUp = New System.Windows.Forms.TabControl
        Me.PagCarichiT = New System.Windows.Forms.TabPage
        Me.TabCarichiUp = New System.Windows.Forms.TabControl
        Me.PagDatiGeneraliT = New System.Windows.Forms.TabPage
        Me._Text3T_0 = New System.Windows.Forms.TextBox
        Me._Label4T_0 = New System.Windows.Forms.Label
        Me._Label3T_0 = New System.Windows.Forms.Label
        Me.PagCarichiBocchelliT = New System.Windows.Forms.TabPage
        Me.TabBocchUp = New System.Windows.Forms.TabControl
        Me.PagListaBocchelliT = New System.Windows.Forms.TabPage
        Me.dgListaBocchelliT = New System.Windows.Forms.DataGrid
        Me.PagT1T = New System.Windows.Forms.TabPage
        Me.dgCarBocchT1 = New System.Windows.Forms.DataGrid
        Me.PagCarichiFondazioniT = New System.Windows.Forms.TabPage
        Me.TabCarFondUp = New System.Windows.Forms.TabControl
        Me.PagRisultBocchelliT = New System.Windows.Forms.TabPage
        Me.lblNienteCarichiT = New System.Windows.Forms.Label
        Me.PagVentoT = New System.Windows.Forms.TabPage
        Me._lblsVentoT_0 = New System.Windows.Forms.Label
        Me._rtfVentoT_0 = New System.Windows.Forms.RichTextBox
        Me._txtVentoT_0 = New System.Windows.Forms.TextBox
        Me._lblVentoT_0 = New System.Windows.Forms.Label
        Me.lblsFrontForceT = New System.Windows.Forms.Label
        Me.lblsLateralForceT = New System.Windows.Forms.Label
        Me.lblsPressureT = New System.Windows.Forms.Label
        Me.lblsFrontAreaT = New System.Windows.Forms.Label
        Me.lblsLateralAreaT = New System.Windows.Forms.Label
        Me.rtfFormulaVentoT = New System.Windows.Forms.RichTextBox
        Me.lblCodiceVentoT = New System.Windows.Forms.Label
        Me.rtfFrontForceT = New System.Windows.Forms.RichTextBox
        Me.txtFrontForceT = New System.Windows.Forms.TextBox
        Me.lblFrontForceT = New System.Windows.Forms.Label
        Me.rtfLateralForceT = New System.Windows.Forms.RichTextBox
        Me.txtLateralForceT = New System.Windows.Forms.TextBox
        Me.lblLateralForceT = New System.Windows.Forms.Label
        Me.rtfPressureT = New System.Windows.Forms.RichTextBox
        Me.txtPressureT = New System.Windows.Forms.TextBox
        Me.lblPressureT = New System.Windows.Forms.Label
        Me.rtfFrontAreaT = New System.Windows.Forms.RichTextBox
        Me.txtFrontAreaT = New System.Windows.Forms.TextBox
        Me.lblFrontAreaT = New System.Windows.Forms.Label
        Me.rtfLateralAreaT = New System.Windows.Forms.RichTextBox
        Me.txtLateralAreaT = New System.Windows.Forms.TextBox
        Me.lblLateralAreaT = New System.Windows.Forms.Label
        Me.PagSismaT = New System.Windows.Forms.TabPage
        Me._lblsSismaT_0 = New System.Windows.Forms.Label
        Me._rtfSismaT_0 = New System.Windows.Forms.RichTextBox
        Me._txtSismaT_0 = New System.Windows.Forms.TextBox
        Me._lblSismaT_0 = New System.Windows.Forms.Label
        Me.lblsForceSeismT = New System.Windows.Forms.Label
        Me.rtfFormulaSismaT = New System.Windows.Forms.RichTextBox
        Me.lblCodiceSismaT = New System.Windows.Forms.Label
        Me.rtfForceSeismT = New System.Windows.Forms.RichTextBox
        Me.txtForceSeismT = New System.Windows.Forms.TextBox
        Me.lblForceSeismT = New System.Windows.Forms.Label
        Me.PagCarichifinaliT = New System.Windows.Forms.TabPage
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.dgCarFondT = New System.Windows.Forms.DataGrid
        Me.PagCalcMantT = New System.Windows.Forms.TabPage
        Me.TabTensMantUp = New System.Windows.Forms.TabControl
        Me.PagCalcMantProgT = New System.Windows.Forms.TabPage
        Me.cmdAmmissT = New System.Windows.Forms.Button
        Me.cmdMatT = New System.Windows.Forms.Button
        Me._Text2T_0 = New System.Windows.Forms.TextBox
        Me._Combo2T_0 = New System.Windows.Forms.ComboBox
        Me._Text1T_0 = New System.Windows.Forms.TextBox
        Me._Combo1T_0 = New System.Windows.Forms.ComboBox
        Me._Label2T_0 = New System.Windows.Forms.Label
        Me._Label1T_0 = New System.Windows.Forms.Label
        Me.PagCalcMantDimT = New System.Windows.Forms.TabPage
        Me._Text41T_0 = New System.Windows.Forms.TextBox
        Me._Label42T_0 = New System.Windows.Forms.Label
        Me._Label41T_0 = New System.Windows.Forms.Label
        Me.cmdCalcMantT = New System.Windows.Forms.Button
        Me._Check1T_0 = New System.Windows.Forms.CheckBox
        Me.PagCalcSelleT = New System.Windows.Forms.TabPage
        Me.cmdCalcMant5T = New System.Windows.Forms.Button
        Me._Text52T_0 = New System.Windows.Forms.TextBox
        Me._Combo52T_0 = New System.Windows.Forms.ComboBox
        Me._Text51T_0 = New System.Windows.Forms.TextBox
        Me._Label52T_0 = New System.Windows.Forms.Label
        Me._Label51T_0 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.TabPrimoLivDown.SuspendLayout()
        Me.PagCarichi.SuspendLayout()
        Me.TabCarichiDown.SuspendLayout()
        Me.PagDatiGenerali.SuspendLayout()
        Me.PagCarichiBocchelli.SuspendLayout()
        Me.TabBocchDown.SuspendLayout()
        Me.PagListaBocchelli.SuspendLayout()
        CType(Me.dgListaBocchelli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagT1.SuspendLayout()
        CType(Me.dgCarBocch1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCarichiFondazioni.SuspendLayout()
        Me.TabCarFondDown.SuspendLayout()
        Me.PagRisultBocchelli.SuspendLayout()
        Me.PagSisma.SuspendLayout()
        Me.PagVento.SuspendLayout()
        Me.PagCarichiDaSopra.SuspendLayout()
        CType(Me.dgCarSopra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCarichiFinali.SuspendLayout()
        CType(Me.dgCarFond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCombinazioni.SuspendLayout()
        Me.TabCombCarDown.SuspendLayout()
        Me.PagCombMant.SuspendLayout()
        CType(Me.dgElemMant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCombMant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCombSelle.SuspendLayout()
        CType(Me.dgElemSadd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCombsadd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCombFonda.SuspendLayout()
        CType(Me.dgElemfond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCombfond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCalcMant.SuspendLayout()
        Me.TabTensMantDown.SuspendLayout()
        Me.PagCalcMantProg.SuspendLayout()
        Me.PagCalcMantDim.SuspendLayout()
        Me.PagCalcSelle.SuspendLayout()
        Me.PagCalcFonda.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.PagDown.SuspendLayout()
        Me.PagUp.SuspendLayout()
        Me.TabPrimoLivUp.SuspendLayout()
        Me.PagCarichiT.SuspendLayout()
        Me.TabCarichiUp.SuspendLayout()
        Me.PagDatiGeneraliT.SuspendLayout()
        Me.PagCarichiBocchelliT.SuspendLayout()
        Me.TabBocchUp.SuspendLayout()
        Me.PagListaBocchelliT.SuspendLayout()
        CType(Me.dgListaBocchelliT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagT1T.SuspendLayout()
        CType(Me.dgCarBocchT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCarichiFondazioniT.SuspendLayout()
        Me.TabCarFondUp.SuspendLayout()
        Me.PagRisultBocchelliT.SuspendLayout()
        Me.PagVentoT.SuspendLayout()
        Me.PagSismaT.SuspendLayout()
        Me.PagCarichifinaliT.SuspendLayout()
        CType(Me.dgCarFondT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagCalcMantT.SuspendLayout()
        Me.TabTensMantUp.SuspendLayout()
        Me.PagCalcMantProgT.SuspendLayout()
        Me.PagCalcMantDimT.SuspendLayout()
        Me.PagCalcSelleT.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdRiprMant
        '
        Me.cmdRiprMant.Location = New System.Drawing.Point(328, 296)
        Me.cmdRiprMant.Name = "cmdRiprMant"
        Me.cmdRiprMant.Size = New System.Drawing.Size(80, 24)
        Me.cmdRiprMant.TabIndex = 2
        Me.cmdRiprMant.Text = "Ripristina"
        Me.ToolTip1.SetToolTip(Me.cmdRiprMant, "Ripristina i coefficienti predefiniti dal programma")
        '
        'cmdRiprSadd
        '
        Me.cmdRiprSadd.Location = New System.Drawing.Point(336, 296)
        Me.cmdRiprSadd.Name = "cmdRiprSadd"
        Me.cmdRiprSadd.Size = New System.Drawing.Size(80, 24)
        Me.cmdRiprSadd.TabIndex = 3
        Me.cmdRiprSadd.Text = "Ripristina"
        Me.ToolTip1.SetToolTip(Me.cmdRiprSadd, "Ripristina i coefficienti predefiniti dal programma")
        '
        'cmdRiprFond
        '
        Me.cmdRiprFond.Location = New System.Drawing.Point(336, 296)
        Me.cmdRiprFond.Name = "cmdRiprFond"
        Me.cmdRiprFond.Size = New System.Drawing.Size(80, 24)
        Me.cmdRiprFond.TabIndex = 3
        Me.cmdRiprFond.Text = "Ripristina"
        Me.ToolTip1.SetToolTip(Me.cmdRiprFond, "Ripristina i coefficienti predefiniti dal programma")
        '
        'cmdRiprBocch
        '
        Me.HelpProvider1.SetHelpKeyword(Me.cmdRiprBocch, "CarBocch.htm#cmdRipristina")
        Me.HelpProvider1.SetHelpNavigator(Me.cmdRiprBocch, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmdRiprBocch.Location = New System.Drawing.Point(416, 288)
        Me.cmdRiprBocch.Name = "cmdRiprBocch"
        Me.HelpProvider1.SetShowHelp(Me.cmdRiprBocch, True)
        Me.cmdRiprBocch.Size = New System.Drawing.Size(80, 24)
        Me.cmdRiprBocch.TabIndex = 3
        Me.cmdRiprBocch.Text = "Ripristina"
        Me.ToolTip1.SetToolTip(Me.cmdRiprBocch, "Ripristina la lista bocchelli predefinita")
        '
        'cmdRiprBocchT
        '
        Me.HelpProvider1.SetHelpKeyword(Me.cmdRiprBocchT, "CarBocch.htm#cmdRipristina")
        Me.HelpProvider1.SetHelpNavigator(Me.cmdRiprBocchT, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmdRiprBocchT.Location = New System.Drawing.Point(416, 288)
        Me.cmdRiprBocchT.Name = "cmdRiprBocchT"
        Me.HelpProvider1.SetShowHelp(Me.cmdRiprBocchT, True)
        Me.cmdRiprBocchT.Size = New System.Drawing.Size(80, 24)
        Me.cmdRiprBocchT.TabIndex = 3
        Me.cmdRiprBocchT.Text = "Ripristina"
        Me.ToolTip1.SetToolTip(Me.cmdRiprBocchT, "Ripristina la lista bocchelli predefinita")
        '
        'Timer1
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuFile, Me.mnuAzioni, Me.mnuPref, Me.MenuItem2})
        '
        'mnuFile
        '

        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuApri, Me.mnuSalva, Me.mnuSalvaCome, Me.mnuExit})
        Me.mnuFile.Text = "File"
        '
        'mnuApri
        '

        Me.mnuApri.Text = "Apri"
        '
        'mnuSalva
        '

        Me.mnuSalva.Text = "Salva"
        '
        'mnuSalvaCome
        '

        Me.mnuSalvaCome.Text = "Salva come ..."
        '
        'mnuExit
        '

        Me.mnuExit.Text = "Esci"
        '
        'mnuAzioni
        '

        Me.mnuAzioni.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuStampa})
        Me.mnuAzioni.Text = "Azioni"
        '
        'mnuStampa
        '

        Me.mnuStampa.Text = "Stampa rapporto"
        '
        'mnuPref
        '

        Me.mnuPref.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuVerb, Me.mnuCodice, Me.mnuVento, Me.mnuSisma, Me.mnuStacked})
        Me.mnuPref.Text = "Preferenze"
        '
        'mnuVerb
        '

        Me.mnuVerb.Text = "Esecuzione commentata"
        '
        'mnuCodice
        '

        Me.mnuCodice.Text = "Normativa verifica mantello"
        '
        'mnuVento
        '

        Me.mnuVento.Text = "Normativa carichi da vento"
        '
        'mnuSisma
        '

        Me.mnuSisma.Text = "Normativa carichi sismici"
        '
        'mnuStacked
        '

        Me.mnuStacked.Text = "Apparecchi stacked"
        '
        'MenuItem2
        '

        Me.MenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem2.Text = "?"
        '
        'MenuItem3
        '

        Me.MenuItem3.Text = "Guida"
        '
        'MenuItem4
        '

        Me.MenuItem4.Text = "Informazioni"
        '
        'TabPrimoLivDown
        '
        Me.TabPrimoLivDown.Controls.Add(Me.PagCarichi)
        Me.TabPrimoLivDown.Controls.Add(Me.PagCalcMant)
        Me.TabPrimoLivDown.Controls.Add(Me.PagCalcSelle)
        Me.TabPrimoLivDown.Controls.Add(Me.PagCalcFonda)
        Me.TabPrimoLivDown.Location = New System.Drawing.Point(8, 8)
        Me.TabPrimoLivDown.Name = "TabPrimoLivDown"
        Me.TabPrimoLivDown.SelectedIndex = 0
        Me.TabPrimoLivDown.Size = New System.Drawing.Size(616, 448)
        Me.TabPrimoLivDown.TabIndex = 21
        '
        'PagCarichi
        '
        Me.PagCarichi.Controls.Add(Me.TabCarichiDown)
        Me.PagCarichi.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichi.Name = "PagCarichi"
        Me.PagCarichi.Size = New System.Drawing.Size(608, 422)
        Me.PagCarichi.TabIndex = 0
        Me.PagCarichi.Text = "Carichi"
        '
        'TabCarichiDown
        '
        Me.TabCarichiDown.Controls.Add(Me.PagDatiGenerali)
        Me.TabCarichiDown.Controls.Add(Me.PagCarichiBocchelli)
        Me.TabCarichiDown.Controls.Add(Me.PagCarichiFondazioni)
        Me.TabCarichiDown.Controls.Add(Me.PagCombinazioni)
        Me.TabCarichiDown.Location = New System.Drawing.Point(8, 8)
        Me.TabCarichiDown.Name = "TabCarichiDown"
        Me.TabCarichiDown.SelectedIndex = 0
        Me.TabCarichiDown.Size = New System.Drawing.Size(592, 400)
        Me.TabCarichiDown.TabIndex = 33
        '
        'PagDatiGenerali
        '
        Me.PagDatiGenerali.Controls.Add(Me.pctSimpleComplex)
        Me.PagDatiGenerali.Controls.Add(Me._Text3_0)
        Me.PagDatiGenerali.Controls.Add(Me._Label4_0)
        Me.PagDatiGenerali.Controls.Add(Me._Label3_0)
        Me.PagDatiGenerali.Location = New System.Drawing.Point(4, 22)
        Me.PagDatiGenerali.Name = "PagDatiGenerali"
        Me.PagDatiGenerali.Size = New System.Drawing.Size(584, 374)
        Me.PagDatiGenerali.TabIndex = 0
        Me.PagDatiGenerali.Text = "Dati generali"
        '
        'pctSimpleComplex
        '
        Me.pctSimpleComplex.Image = CType(resources.GetObject("pctSimpleComplex.Image"), System.Drawing.Image)
        Me.pctSimpleComplex.Location = New System.Drawing.Point(8, 8)
        Me.pctSimpleComplex.Name = "pctSimpleComplex"
        Me.pctSimpleComplex.Size = New System.Drawing.Size(568, 360)
        Me.pctSimpleComplex.TabIndex = 36
        Me.pctSimpleComplex.TabStop = False
        '
        '_Text3_0
        '
        Me._Text3_0.AcceptsReturn = True
        Me._Text3_0.AutoSize = False
        Me._Text3_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_0.Enabled = False
        Me._Text3_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text3_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_0.Location = New System.Drawing.Point(349, 157)
        Me._Text3_0.MaxLength = 0
        Me._Text3_0.Multiline = True
        Me._Text3_0.Name = "_Text3_0"
        Me._Text3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_0.Size = New System.Drawing.Size(71, 21)
        Me._Text3_0.TabIndex = 35
        Me._Text3_0.Text = ""
        Me._Text3_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text3_0.Visible = False
        '
        '_Label4_0
        '
        Me._Label4_0.BackColor = System.Drawing.Color.Cyan
        Me._Label4_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label4_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label4_0.Enabled = False
        Me._Label4_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label4_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label4_0.Location = New System.Drawing.Point(429, 157)
        Me._Label4_0.Name = "_Label4_0"
        Me._Label4_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label4_0.Size = New System.Drawing.Size(46, 21)
        Me._Label4_0.TabIndex = 34
        Me._Label4_0.Visible = False
        '
        '_Label3_0
        '
        Me._Label3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.Enabled = False
        Me._Label3_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_0.Location = New System.Drawing.Point(8, 96)
        Me._Label3_0.Name = "_Label3_0"
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.Size = New System.Drawing.Size(296, 21)
        Me._Label3_0.TabIndex = 33
        Me._Label3_0.Text = "Label1"
        Me._Label3_0.Visible = False
        '
        'PagCarichiBocchelli
        '
        Me.PagCarichiBocchelli.BackColor = System.Drawing.SystemColors.Control
        Me.PagCarichiBocchelli.Controls.Add(Me.TabBocchDown)
        Me.PagCarichiBocchelli.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiBocchelli.Name = "PagCarichiBocchelli"
        Me.PagCarichiBocchelli.Size = New System.Drawing.Size(584, 374)
        Me.PagCarichiBocchelli.TabIndex = 2
        Me.PagCarichiBocchelli.Text = "Carichi sui bocchelli"
        '
        'TabBocchDown
        '
        Me.TabBocchDown.Controls.Add(Me.PagListaBocchelli)
        Me.TabBocchDown.Controls.Add(Me.PagT1)
        Me.TabBocchDown.Location = New System.Drawing.Point(8, 8)
        Me.TabBocchDown.Name = "TabBocchDown"
        Me.TabBocchDown.SelectedIndex = 0
        Me.TabBocchDown.Size = New System.Drawing.Size(568, 352)
        Me.TabBocchDown.TabIndex = 0
        '
        'PagListaBocchelli
        '
        Me.PagListaBocchelli.Controls.Add(Me.cmdRiprBocch)
        Me.PagListaBocchelli.Controls.Add(Me.dgListaBocchelli)
        Me.PagListaBocchelli.Location = New System.Drawing.Point(4, 22)
        Me.PagListaBocchelli.Name = "PagListaBocchelli"
        Me.PagListaBocchelli.Size = New System.Drawing.Size(560, 326)
        Me.PagListaBocchelli.TabIndex = 0
        Me.PagListaBocchelli.Text = "Lista Bocchelli"
        '
        'dgListaBocchelli
        '
        Me.dgListaBocchelli.CaptionText = "LISTA BOCCHELLI"
        Me.dgListaBocchelli.DataMember = ""
        Me.dgListaBocchelli.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.dgListaBocchelli, "CarBocch.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.dgListaBocchelli, System.Windows.Forms.HelpNavigator.Topic)
        Me.dgListaBocchelli.Location = New System.Drawing.Point(64, 47)
        Me.dgListaBocchelli.Name = "dgListaBocchelli"
        Me.HelpProvider1.SetShowHelp(Me.dgListaBocchelli, True)
        Me.dgListaBocchelli.Size = New System.Drawing.Size(432, 232)
        Me.dgListaBocchelli.TabIndex = 1
        '
        'PagT1
        '
        Me.PagT1.Controls.Add(Me.dgCarBocch1)
        Me.PagT1.Location = New System.Drawing.Point(4, 22)
        Me.PagT1.Name = "PagT1"
        Me.PagT1.Size = New System.Drawing.Size(560, 326)
        Me.PagT1.TabIndex = 1
        Me.PagT1.Text = "T1"
        '
        'dgCarBocch1
        '
        Me.dgCarBocch1.DataMember = ""
        Me.dgCarBocch1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCarBocch1.Location = New System.Drawing.Point(8, 8)
        Me.dgCarBocch1.Name = "dgCarBocch1"
        Me.dgCarBocch1.Size = New System.Drawing.Size(544, 312)
        Me.dgCarBocch1.TabIndex = 0
        '
        'PagCarichiFondazioni
        '
        Me.PagCarichiFondazioni.Controls.Add(Me.TabCarFondDown)
        Me.PagCarichiFondazioni.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiFondazioni.Name = "PagCarichiFondazioni"
        Me.PagCarichiFondazioni.Size = New System.Drawing.Size(584, 374)
        Me.PagCarichiFondazioni.TabIndex = 3
        Me.PagCarichiFondazioni.Text = "Carichi sulle fondazioni"
        '
        'TabCarFondDown
        '
        Me.TabCarFondDown.Controls.Add(Me.PagRisultBocchelli)
        Me.TabCarFondDown.Controls.Add(Me.PagVento)
        Me.TabCarFondDown.Controls.Add(Me.PagSisma)
        Me.TabCarFondDown.Controls.Add(Me.PagCarichiDaSopra)
        Me.TabCarFondDown.Controls.Add(Me.PagCarichiFinali)
        Me.TabCarFondDown.Location = New System.Drawing.Point(8, 8)
        Me.TabCarFondDown.Name = "TabCarFondDown"
        Me.TabCarFondDown.SelectedIndex = 0
        Me.TabCarFondDown.Size = New System.Drawing.Size(568, 360)
        Me.TabCarFondDown.TabIndex = 0
        '
        'PagRisultBocchelli
        '
        Me.PagRisultBocchelli.Controls.Add(Me.lblNienteCarichi)
        Me.PagRisultBocchelli.Location = New System.Drawing.Point(4, 22)
        Me.PagRisultBocchelli.Name = "PagRisultBocchelli"
        Me.PagRisultBocchelli.Size = New System.Drawing.Size(560, 334)
        Me.PagRisultBocchelli.TabIndex = 0
        Me.PagRisultBocchelli.Text = "Risultanti dei carichi sui bocchelli"
        '
        'lblNienteCarichi
        '
        Me.lblNienteCarichi.BackColor = System.Drawing.Color.Yellow
        Me.lblNienteCarichi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNienteCarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNienteCarichi.Location = New System.Drawing.Point(96, 96)
        Me.lblNienteCarichi.Name = "lblNienteCarichi"
        Me.lblNienteCarichi.Size = New System.Drawing.Size(376, 120)
        Me.lblNienteCarichi.TabIndex = 0
        Me.lblNienteCarichi.Text = "Non sono stati specificati carichi sui bocchelli. Il calcolo può procedere senza " & _
        "di essi."
        '
        'PagSisma
        '
        Me.PagSisma.Controls.Add(Me._lblsSisma_0)
        Me.PagSisma.Controls.Add(Me._rtfSisma_0)
        Me.PagSisma.Controls.Add(Me._txtSisma_0)
        Me.PagSisma.Controls.Add(Me._lblSisma_0)
        Me.PagSisma.Controls.Add(Me.lblsForceSeism)
        Me.PagSisma.Controls.Add(Me.rtfFormulaSisma)
        Me.PagSisma.Controls.Add(Me.lblCodiceSisma)
        Me.PagSisma.Controls.Add(Me.rtfForceSeism)
        Me.PagSisma.Controls.Add(Me.txtForceSeism)
        Me.PagSisma.Controls.Add(Me.lblForceSeism)
        Me.PagSisma.Location = New System.Drawing.Point(4, 22)
        Me.PagSisma.Name = "PagSisma"
        Me.PagSisma.Size = New System.Drawing.Size(560, 334)
        Me.PagSisma.TabIndex = 3
        Me.PagSisma.Text = "Terremoto"
        '
        '_lblsSisma_0
        '
        Me._lblsSisma_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me._lblsSisma_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblsSisma_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblsSisma_0.Location = New System.Drawing.Point(152, 56)
        Me._lblsSisma_0.Name = "_lblsSisma_0"
        Me._lblsSisma_0.Size = New System.Drawing.Size(32, 24)
        Me._lblsSisma_0.TabIndex = 74
        Me._lblsSisma_0.Text = "Al"
        Me._lblsSisma_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._lblsSisma_0.Visible = False
        '
        '_rtfSisma_0
        '
        Me._rtfSisma_0.BackColor = System.Drawing.Color.Cyan
        Me._rtfSisma_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._rtfSisma_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtfSisma_0.Location = New System.Drawing.Point(184, 56)
        Me._rtfSisma_0.Multiline = False
        Me._rtfSisma_0.Name = "_rtfSisma_0"
        Me._rtfSisma_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtfSisma_0.Size = New System.Drawing.Size(40, 24)
        Me._rtfSisma_0.TabIndex = 73
        Me._rtfSisma_0.Text = ""
        Me._rtfSisma_0.Visible = False
        '
        '_txtSisma_0
        '
        Me._txtSisma_0.AcceptsReturn = True
        Me._txtSisma_0.AutoSize = False
        Me._txtSisma_0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me._txtSisma_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtSisma_0.Enabled = False
        Me._txtSisma_0.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtSisma_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtSisma_0.Location = New System.Drawing.Point(224, 56)
        Me._txtSisma_0.MaxLength = 0
        Me._txtSisma_0.Name = "_txtSisma_0"
        Me._txtSisma_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtSisma_0.Size = New System.Drawing.Size(71, 24)
        Me._txtSisma_0.TabIndex = 72
        Me._txtSisma_0.Text = ""
        Me._txtSisma_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._txtSisma_0.Visible = False
        '
        '_lblSisma_0
        '
        Me._lblSisma_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblSisma_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblSisma_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSisma_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSisma_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSisma_0.Location = New System.Drawing.Point(8, 56)
        Me._lblSisma_0.Name = "_lblSisma_0"
        Me._lblSisma_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSisma_0.Size = New System.Drawing.Size(144, 24)
        Me._lblSisma_0.TabIndex = 71
        Me._lblSisma_0.Text = "Lateral area"
        Me._lblSisma_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._lblSisma_0.Visible = False
        '
        'lblsForceSeism
        '
        Me.lblsForceSeism.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsForceSeism.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsForceSeism.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsForceSeism.Location = New System.Drawing.Point(408, 200)
        Me.lblsForceSeism.Name = "lblsForceSeism"
        Me.lblsForceSeism.Size = New System.Drawing.Size(32, 24)
        Me.lblsForceSeism.TabIndex = 70
        Me.lblsForceSeism.Text = "F"
        Me.lblsForceSeism.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfFormulaSisma
        '
        Me.rtfFormulaSisma.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfFormulaSisma.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFormulaSisma.Location = New System.Drawing.Point(48, 280)
        Me.rtfFormulaSisma.Multiline = False
        Me.rtfFormulaSisma.Name = "rtfFormulaSisma"
        Me.rtfFormulaSisma.Size = New System.Drawing.Size(464, 24)
        Me.rtfFormulaSisma.TabIndex = 69
        Me.rtfFormulaSisma.Text = "RichTextBox3"
        '
        'lblCodiceSisma
        '
        Me.lblCodiceSisma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCodiceSisma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceSisma.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCodiceSisma.Location = New System.Drawing.Point(176, 8)
        Me.lblCodiceSisma.Name = "lblCodiceSisma"
        Me.lblCodiceSisma.Size = New System.Drawing.Size(208, 24)
        Me.lblCodiceSisma.TabIndex = 68
        Me.lblCodiceSisma.Text = "lblCodiceSisma"
        Me.lblCodiceSisma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfForceSeism
        '
        Me.rtfForceSeism.BackColor = System.Drawing.Color.Cyan
        Me.rtfForceSeism.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfForceSeism.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfForceSeism.Location = New System.Drawing.Point(440, 200)
        Me.rtfForceSeism.Multiline = False
        Me.rtfForceSeism.Name = "rtfForceSeism"
        Me.rtfForceSeism.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfForceSeism.Size = New System.Drawing.Size(40, 24)
        Me.rtfForceSeism.TabIndex = 67
        Me.rtfForceSeism.Text = ""
        '
        'txtForceSeism
        '
        Me.txtForceSeism.AcceptsReturn = True
        Me.txtForceSeism.AutoSize = False
        Me.txtForceSeism.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtForceSeism.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtForceSeism.Enabled = False
        Me.txtForceSeism.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForceSeism.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtForceSeism.Location = New System.Drawing.Point(480, 200)
        Me.txtForceSeism.MaxLength = 0
        Me.txtForceSeism.Name = "txtForceSeism"
        Me.txtForceSeism.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtForceSeism.Size = New System.Drawing.Size(71, 24)
        Me.txtForceSeism.TabIndex = 66
        Me.txtForceSeism.Text = ""
        Me.txtForceSeism.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblForceSeism
        '
        Me.lblForceSeism.BackColor = System.Drawing.SystemColors.Control
        Me.lblForceSeism.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblForceSeism.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblForceSeism.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForceSeism.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblForceSeism.Location = New System.Drawing.Point(304, 200)
        Me.lblForceSeism.Name = "lblForceSeism"
        Me.lblForceSeism.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblForceSeism.Size = New System.Drawing.Size(104, 24)
        Me.lblForceSeism.TabIndex = 65
        Me.lblForceSeism.Text = "Horizontal force"
        Me.lblForceSeism.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PagVento
        '
        Me.PagVento.Controls.Add(Me._lblsVento_0)
        Me.PagVento.Controls.Add(Me._rtfVento_0)
        Me.PagVento.Controls.Add(Me._txtVento_0)
        Me.PagVento.Controls.Add(Me._lblVento_0)
        Me.PagVento.Controls.Add(Me.lblsFrontForce)
        Me.PagVento.Controls.Add(Me.lblsLateralForce)
        Me.PagVento.Controls.Add(Me.lblsPressure)
        Me.PagVento.Controls.Add(Me.lblsFrontArea)
        Me.PagVento.Controls.Add(Me.lblsLateralArea)
        Me.PagVento.Controls.Add(Me.rtfFormulaVento)
        Me.PagVento.Controls.Add(Me.lblCodiceVento)
        Me.PagVento.Controls.Add(Me.rtfFrontForce)
        Me.PagVento.Controls.Add(Me.txtFrontForce)
        Me.PagVento.Controls.Add(Me.lblFrontForce)
        Me.PagVento.Controls.Add(Me.rtfLateralForce)
        Me.PagVento.Controls.Add(Me.txtLateralForce)
        Me.PagVento.Controls.Add(Me.lblLateralForce)
        Me.PagVento.Controls.Add(Me.rtfPressure)
        Me.PagVento.Controls.Add(Me.txtPressure)
        Me.PagVento.Controls.Add(Me.lblPressure)
        Me.PagVento.Controls.Add(Me.rtfFrontArea)
        Me.PagVento.Controls.Add(Me.txtFrontArea)
        Me.PagVento.Controls.Add(Me.lblFrontArea)
        Me.PagVento.Controls.Add(Me.rtfLateralArea)
        Me.PagVento.Controls.Add(Me.txtLateralArea)
        Me.PagVento.Controls.Add(Me.lblLateralArea)
        Me.PagVento.Location = New System.Drawing.Point(4, 22)
        Me.PagVento.Name = "PagVento"
        Me.PagVento.Size = New System.Drawing.Size(560, 334)
        Me.PagVento.TabIndex = 2
        Me.PagVento.Text = "Vento"
        '
        '_lblsVento_0
        '
        Me._lblsVento_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me._lblsVento_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblsVento_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblsVento_0.Location = New System.Drawing.Point(152, 56)
        Me._lblsVento_0.Name = "_lblsVento_0"
        Me._lblsVento_0.Size = New System.Drawing.Size(32, 24)
        Me._lblsVento_0.TabIndex = 64
        Me._lblsVento_0.Text = "Al"
        Me._lblsVento_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._lblsVento_0.Visible = False
        '
        '_rtfVento_0
        '
        Me._rtfVento_0.BackColor = System.Drawing.Color.Cyan
        Me._rtfVento_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._rtfVento_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtfVento_0.Location = New System.Drawing.Point(184, 56)
        Me._rtfVento_0.Multiline = False
        Me._rtfVento_0.Name = "_rtfVento_0"
        Me._rtfVento_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtfVento_0.Size = New System.Drawing.Size(40, 24)
        Me._rtfVento_0.TabIndex = 63
        Me._rtfVento_0.Text = ""
        Me._rtfVento_0.Visible = False
        '
        '_txtVento_0
        '
        Me._txtVento_0.AcceptsReturn = True
        Me._txtVento_0.AutoSize = False
        Me._txtVento_0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me._txtVento_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtVento_0.Enabled = False
        Me._txtVento_0.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtVento_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtVento_0.Location = New System.Drawing.Point(224, 56)
        Me._txtVento_0.MaxLength = 0
        Me._txtVento_0.Name = "_txtVento_0"
        Me._txtVento_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtVento_0.Size = New System.Drawing.Size(71, 24)
        Me._txtVento_0.TabIndex = 62
        Me._txtVento_0.Text = ""
        Me._txtVento_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._txtVento_0.Visible = False
        '
        '_lblVento_0
        '
        Me._lblVento_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblVento_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblVento_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVento_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVento_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblVento_0.Location = New System.Drawing.Point(8, 56)
        Me._lblVento_0.Name = "_lblVento_0"
        Me._lblVento_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVento_0.Size = New System.Drawing.Size(144, 24)
        Me._lblVento_0.TabIndex = 61
        Me._lblVento_0.Text = "Lateral area"
        Me._lblVento_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._lblVento_0.Visible = False
        '
        'lblsFrontForce
        '
        Me.lblsFrontForce.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsFrontForce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsFrontForce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsFrontForce.Location = New System.Drawing.Point(408, 200)
        Me.lblsFrontForce.Name = "lblsFrontForce"
        Me.lblsFrontForce.Size = New System.Drawing.Size(32, 24)
        Me.lblsFrontForce.TabIndex = 60
        Me.lblsFrontForce.Text = "Fl"
        Me.lblsFrontForce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsLateralForce
        '
        Me.lblsLateralForce.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsLateralForce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsLateralForce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsLateralForce.Location = New System.Drawing.Point(408, 176)
        Me.lblsLateralForce.Name = "lblsLateralForce"
        Me.lblsLateralForce.Size = New System.Drawing.Size(32, 24)
        Me.lblsLateralForce.TabIndex = 59
        Me.lblsLateralForce.Text = "Fl"
        Me.lblsLateralForce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsPressure
        '
        Me.lblsPressure.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsPressure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsPressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsPressure.Location = New System.Drawing.Point(408, 120)
        Me.lblsPressure.Name = "lblsPressure"
        Me.lblsPressure.Size = New System.Drawing.Size(32, 24)
        Me.lblsPressure.TabIndex = 58
        Me.lblsPressure.Text = "p"
        Me.lblsPressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsFrontArea
        '
        Me.lblsFrontArea.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsFrontArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsFrontArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsFrontArea.Location = New System.Drawing.Point(408, 80)
        Me.lblsFrontArea.Name = "lblsFrontArea"
        Me.lblsFrontArea.Size = New System.Drawing.Size(32, 24)
        Me.lblsFrontArea.TabIndex = 57
        Me.lblsFrontArea.Text = "Af"
        Me.lblsFrontArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsLateralArea
        '
        Me.lblsLateralArea.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsLateralArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsLateralArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsLateralArea.Location = New System.Drawing.Point(408, 56)
        Me.lblsLateralArea.Name = "lblsLateralArea"
        Me.lblsLateralArea.Size = New System.Drawing.Size(32, 24)
        Me.lblsLateralArea.TabIndex = 56
        Me.lblsLateralArea.Text = "Al"
        Me.lblsLateralArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfFormulaVento
        '
        Me.rtfFormulaVento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfFormulaVento.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFormulaVento.Location = New System.Drawing.Point(64, 280)
        Me.rtfFormulaVento.Multiline = False
        Me.rtfFormulaVento.Name = "rtfFormulaVento"
        Me.rtfFormulaVento.Size = New System.Drawing.Size(440, 24)
        Me.rtfFormulaVento.TabIndex = 55
        Me.rtfFormulaVento.Text = "RichTextBox1"
        '
        'lblCodiceVento
        '
        Me.lblCodiceVento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCodiceVento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceVento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCodiceVento.Location = New System.Drawing.Point(176, 8)
        Me.lblCodiceVento.Name = "lblCodiceVento"
        Me.lblCodiceVento.Size = New System.Drawing.Size(208, 24)
        Me.lblCodiceVento.TabIndex = 54
        Me.lblCodiceVento.Text = "Label7"
        Me.lblCodiceVento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfFrontForce
        '
        Me.rtfFrontForce.BackColor = System.Drawing.Color.Cyan
        Me.rtfFrontForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfFrontForce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFrontForce.Location = New System.Drawing.Point(440, 200)
        Me.rtfFrontForce.Multiline = False
        Me.rtfFrontForce.Name = "rtfFrontForce"
        Me.rtfFrontForce.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfFrontForce.Size = New System.Drawing.Size(40, 24)
        Me.rtfFrontForce.TabIndex = 53
        Me.rtfFrontForce.Text = ""
        '
        'txtFrontForce
        '
        Me.txtFrontForce.AcceptsReturn = True
        Me.txtFrontForce.AutoSize = False
        Me.txtFrontForce.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtFrontForce.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFrontForce.Enabled = False
        Me.txtFrontForce.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrontForce.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFrontForce.Location = New System.Drawing.Point(480, 200)
        Me.txtFrontForce.MaxLength = 0
        Me.txtFrontForce.Name = "txtFrontForce"
        Me.txtFrontForce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFrontForce.Size = New System.Drawing.Size(71, 24)
        Me.txtFrontForce.TabIndex = 52
        Me.txtFrontForce.Text = ""
        Me.txtFrontForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFrontForce
        '
        Me.lblFrontForce.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrontForce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFrontForce.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFrontForce.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrontForce.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFrontForce.Location = New System.Drawing.Point(304, 200)
        Me.lblFrontForce.Name = "lblFrontForce"
        Me.lblFrontForce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrontForce.Size = New System.Drawing.Size(104, 24)
        Me.lblFrontForce.TabIndex = 51
        Me.lblFrontForce.Text = "Front force"
        '
        'rtfLateralForce
        '
        Me.rtfLateralForce.BackColor = System.Drawing.Color.Cyan
        Me.rtfLateralForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfLateralForce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfLateralForce.Location = New System.Drawing.Point(440, 176)
        Me.rtfLateralForce.Multiline = False
        Me.rtfLateralForce.Name = "rtfLateralForce"
        Me.rtfLateralForce.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfLateralForce.Size = New System.Drawing.Size(40, 24)
        Me.rtfLateralForce.TabIndex = 50
        Me.rtfLateralForce.Text = ""
        '
        'txtLateralForce
        '
        Me.txtLateralForce.AcceptsReturn = True
        Me.txtLateralForce.AutoSize = False
        Me.txtLateralForce.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtLateralForce.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLateralForce.Enabled = False
        Me.txtLateralForce.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLateralForce.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLateralForce.Location = New System.Drawing.Point(480, 176)
        Me.txtLateralForce.MaxLength = 0
        Me.txtLateralForce.Name = "txtLateralForce"
        Me.txtLateralForce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLateralForce.Size = New System.Drawing.Size(71, 24)
        Me.txtLateralForce.TabIndex = 49
        Me.txtLateralForce.Text = ""
        Me.txtLateralForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLateralForce
        '
        Me.lblLateralForce.BackColor = System.Drawing.SystemColors.Control
        Me.lblLateralForce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLateralForce.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLateralForce.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateralForce.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLateralForce.Location = New System.Drawing.Point(304, 176)
        Me.lblLateralForce.Name = "lblLateralForce"
        Me.lblLateralForce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLateralForce.Size = New System.Drawing.Size(104, 24)
        Me.lblLateralForce.TabIndex = 48
        Me.lblLateralForce.Text = "Lateral force"
        '
        'rtfPressure
        '
        Me.rtfPressure.BackColor = System.Drawing.Color.Cyan
        Me.rtfPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfPressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfPressure.Location = New System.Drawing.Point(440, 120)
        Me.rtfPressure.Multiline = False
        Me.rtfPressure.Name = "rtfPressure"
        Me.rtfPressure.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfPressure.Size = New System.Drawing.Size(40, 24)
        Me.rtfPressure.TabIndex = 47
        Me.rtfPressure.Text = ""
        '
        'txtPressure
        '
        Me.txtPressure.AcceptsReturn = True
        Me.txtPressure.AutoSize = False
        Me.txtPressure.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtPressure.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPressure.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPressure.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPressure.Location = New System.Drawing.Point(480, 120)
        Me.txtPressure.MaxLength = 0
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPressure.Size = New System.Drawing.Size(71, 24)
        Me.txtPressure.TabIndex = 46
        Me.txtPressure.Text = ""
        Me.txtPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPressure
        '
        Me.lblPressure.BackColor = System.Drawing.SystemColors.Control
        Me.lblPressure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPressure.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPressure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressure.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPressure.Location = New System.Drawing.Point(304, 120)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPressure.Size = New System.Drawing.Size(104, 24)
        Me.lblPressure.TabIndex = 45
        Me.lblPressure.Text = "Wind pressure"
        Me.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtfFrontArea
        '
        Me.rtfFrontArea.BackColor = System.Drawing.Color.Cyan
        Me.rtfFrontArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfFrontArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFrontArea.Location = New System.Drawing.Point(440, 80)
        Me.rtfFrontArea.Multiline = False
        Me.rtfFrontArea.Name = "rtfFrontArea"
        Me.rtfFrontArea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfFrontArea.Size = New System.Drawing.Size(40, 24)
        Me.rtfFrontArea.TabIndex = 44
        Me.rtfFrontArea.Text = ""
        '
        'txtFrontArea
        '
        Me.txtFrontArea.AcceptsReturn = True
        Me.txtFrontArea.AutoSize = False
        Me.txtFrontArea.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtFrontArea.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFrontArea.Enabled = False
        Me.txtFrontArea.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrontArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFrontArea.Location = New System.Drawing.Point(480, 80)
        Me.txtFrontArea.MaxLength = 0
        Me.txtFrontArea.Name = "txtFrontArea"
        Me.txtFrontArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFrontArea.Size = New System.Drawing.Size(71, 24)
        Me.txtFrontArea.TabIndex = 43
        Me.txtFrontArea.Text = ""
        Me.txtFrontArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFrontArea
        '
        Me.lblFrontArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrontArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFrontArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFrontArea.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrontArea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFrontArea.Location = New System.Drawing.Point(304, 80)
        Me.lblFrontArea.Name = "lblFrontArea"
        Me.lblFrontArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrontArea.Size = New System.Drawing.Size(104, 24)
        Me.lblFrontArea.TabIndex = 42
        Me.lblFrontArea.Text = "Front area"
        Me.lblFrontArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtfLateralArea
        '
        Me.rtfLateralArea.BackColor = System.Drawing.Color.Cyan
        Me.rtfLateralArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfLateralArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfLateralArea.Location = New System.Drawing.Point(440, 56)
        Me.rtfLateralArea.Multiline = False
        Me.rtfLateralArea.Name = "rtfLateralArea"
        Me.rtfLateralArea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfLateralArea.Size = New System.Drawing.Size(40, 24)
        Me.rtfLateralArea.TabIndex = 41
        Me.rtfLateralArea.Text = ""
        '
        'txtLateralArea
        '
        Me.txtLateralArea.AcceptsReturn = True
        Me.txtLateralArea.AutoSize = False
        Me.txtLateralArea.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtLateralArea.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLateralArea.Enabled = False
        Me.txtLateralArea.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLateralArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLateralArea.Location = New System.Drawing.Point(480, 56)
        Me.txtLateralArea.MaxLength = 0
        Me.txtLateralArea.Name = "txtLateralArea"
        Me.txtLateralArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLateralArea.Size = New System.Drawing.Size(71, 24)
        Me.txtLateralArea.TabIndex = 40
        Me.txtLateralArea.Text = ""
        Me.txtLateralArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLateralArea
        '
        Me.lblLateralArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblLateralArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLateralArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLateralArea.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateralArea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLateralArea.Location = New System.Drawing.Point(304, 56)
        Me.lblLateralArea.Name = "lblLateralArea"
        Me.lblLateralArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLateralArea.Size = New System.Drawing.Size(104, 24)
        Me.lblLateralArea.TabIndex = 38
        Me.lblLateralArea.Text = "Lateral area"
        Me.lblLateralArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PagCarichiDaSopra
        '
        Me.PagCarichiDaSopra.Controls.Add(Me.Label7)
        Me.PagCarichiDaSopra.Controls.Add(Me.Label8)
        Me.PagCarichiDaSopra.Controls.Add(Me.dgCarSopra)
        Me.PagCarichiDaSopra.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiDaSopra.Name = "PagCarichiDaSopra"
        Me.PagCarichiDaSopra.Size = New System.Drawing.Size(560, 334)
        Me.PagCarichiDaSopra.TabIndex = 4
        Me.PagCarichiDaSopra.Text = "Carichi dal top item"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(359, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 24)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "SLIDING SADDLE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(167, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 24)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "FIXED SADDLE"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgCarSopra
        '
        Me.dgCarSopra.CaptionVisible = False
        Me.dgCarSopra.DataMember = ""
        Me.dgCarSopra.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCarSopra.Location = New System.Drawing.Point(7, 31)
        Me.dgCarSopra.Name = "dgCarSopra"
        Me.dgCarSopra.Size = New System.Drawing.Size(546, 296)
        Me.dgCarSopra.TabIndex = 3
        '
        'PagCarichiFinali
        '
        Me.PagCarichiFinali.Controls.Add(Me.lblNota)
        Me.PagCarichiFinali.Controls.Add(Me.Label6)
        Me.PagCarichiFinali.Controls.Add(Me.Label5)
        Me.PagCarichiFinali.Controls.Add(Me.dgCarFond)
        Me.PagCarichiFinali.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiFinali.Name = "PagCarichiFinali"
        Me.PagCarichiFinali.Size = New System.Drawing.Size(560, 334)
        Me.PagCarichiFinali.TabIndex = 1
        Me.PagCarichiFinali.Text = "Carichi totali"
        '
        'lblNota
        '
        Me.lblNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNota.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblNota.Location = New System.Drawing.Point(16, 8)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(152, 16)
        Me.lblNota.TabIndex = 3
        Me.lblNota.Text = "esclusi i carichi dal top item"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(360, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 24)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "SLIDING SADDLE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(168, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "FIXED SADDLE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgCarFond
        '
        Me.dgCarFond.CaptionVisible = False
        Me.dgCarFond.DataMember = ""
        Me.dgCarFond.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCarFond.Location = New System.Drawing.Point(8, 32)
        Me.dgCarFond.Name = "dgCarFond"
        Me.dgCarFond.Size = New System.Drawing.Size(546, 296)
        Me.dgCarFond.TabIndex = 0
        '
        'PagCombinazioni
        '
        Me.PagCombinazioni.Controls.Add(Me.TabCombCarDown)
        Me.PagCombinazioni.Location = New System.Drawing.Point(4, 22)
        Me.PagCombinazioni.Name = "PagCombinazioni"
        Me.PagCombinazioni.Size = New System.Drawing.Size(584, 374)
        Me.PagCombinazioni.TabIndex = 1
        Me.PagCombinazioni.Text = "Combinazioni di carico"
        '
        'TabCombCarDown
        '
        Me.TabCombCarDown.Controls.Add(Me.PagCombMant)
        Me.TabCombCarDown.Controls.Add(Me.PagCombSelle)
        Me.TabCombCarDown.Controls.Add(Me.PagCombFonda)
        Me.TabCombCarDown.Location = New System.Drawing.Point(8, 8)
        Me.TabCombCarDown.Name = "TabCombCarDown"
        Me.TabCombCarDown.SelectedIndex = 0
        Me.TabCombCarDown.Size = New System.Drawing.Size(568, 360)
        Me.TabCombCarDown.TabIndex = 0
        '
        'PagCombMant
        '
        Me.PagCombMant.Controls.Add(Me.cmdRiprMant)
        Me.PagCombMant.Controls.Add(Me.dgElemMant)
        Me.PagCombMant.Controls.Add(Me.dgCombMant)
        Me.PagCombMant.Location = New System.Drawing.Point(4, 22)
        Me.PagCombMant.Name = "PagCombMant"
        Me.PagCombMant.Size = New System.Drawing.Size(560, 334)
        Me.PagCombMant.TabIndex = 0
        Me.PagCombMant.Text = "per il Mantello"
        '
        'dgElemMant
        '
        Me.dgElemMant.BackColor = System.Drawing.Color.Yellow
        Me.dgElemMant.CaptionVisible = False
        Me.dgElemMant.DataMember = ""
        Me.dgElemMant.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgElemMant.Location = New System.Drawing.Point(424, 16)
        Me.dgElemMant.Name = "dgElemMant"
        Me.dgElemMant.Size = New System.Drawing.Size(128, 272)
        Me.dgElemMant.TabIndex = 1
        '
        'dgCombMant
        '
        Me.dgCombMant.CaptionVisible = False
        Me.dgCombMant.DataMember = ""
        Me.dgCombMant.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCombMant.Location = New System.Drawing.Point(16, 16)
        Me.dgCombMant.Name = "dgCombMant"
        Me.dgCombMant.Size = New System.Drawing.Size(392, 272)
        Me.dgCombMant.TabIndex = 0
        '
        'PagCombSelle
        '
        Me.PagCombSelle.Controls.Add(Me.cmdRiprSadd)
        Me.PagCombSelle.Controls.Add(Me.dgElemSadd)
        Me.PagCombSelle.Controls.Add(Me.dgCombsadd)
        Me.PagCombSelle.Location = New System.Drawing.Point(4, 22)
        Me.PagCombSelle.Name = "PagCombSelle"
        Me.PagCombSelle.Size = New System.Drawing.Size(560, 334)
        Me.PagCombSelle.TabIndex = 1
        Me.PagCombSelle.Text = "per le Selle"
        '
        'dgElemSadd
        '
        Me.dgElemSadd.BackColor = System.Drawing.Color.Yellow
        Me.dgElemSadd.CaptionVisible = False
        Me.dgElemSadd.DataMember = ""
        Me.dgElemSadd.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgElemSadd.Location = New System.Drawing.Point(424, 16)
        Me.dgElemSadd.Name = "dgElemSadd"
        Me.dgElemSadd.Size = New System.Drawing.Size(128, 272)
        Me.dgElemSadd.TabIndex = 2
        '
        'dgCombsadd
        '
        Me.dgCombsadd.CaptionVisible = False
        Me.dgCombsadd.DataMember = ""
        Me.dgCombsadd.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCombsadd.Location = New System.Drawing.Point(16, 16)
        Me.dgCombsadd.Name = "dgCombsadd"
        Me.dgCombsadd.Size = New System.Drawing.Size(400, 272)
        Me.dgCombsadd.TabIndex = 0
        '
        'PagCombFonda
        '
        Me.PagCombFonda.Controls.Add(Me.cmdRiprFond)
        Me.PagCombFonda.Controls.Add(Me.dgElemfond)
        Me.PagCombFonda.Controls.Add(Me.dgCombfond)
        Me.PagCombFonda.Location = New System.Drawing.Point(4, 22)
        Me.PagCombFonda.Name = "PagCombFonda"
        Me.PagCombFonda.Size = New System.Drawing.Size(560, 334)
        Me.PagCombFonda.TabIndex = 2
        Me.PagCombFonda.Text = "per le Fondazioni"
        '
        'dgElemfond
        '
        Me.dgElemfond.BackColor = System.Drawing.Color.Yellow
        Me.dgElemfond.CaptionVisible = False
        Me.dgElemfond.DataMember = ""
        Me.dgElemfond.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgElemfond.Location = New System.Drawing.Point(424, 16)
        Me.dgElemfond.Name = "dgElemfond"
        Me.dgElemfond.Size = New System.Drawing.Size(128, 272)
        Me.dgElemfond.TabIndex = 2
        '
        'dgCombfond
        '
        Me.dgCombfond.CaptionVisible = False
        Me.dgCombfond.DataMember = ""
        Me.dgCombfond.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCombfond.Location = New System.Drawing.Point(16, 16)
        Me.dgCombfond.Name = "dgCombfond"
        Me.dgCombfond.Size = New System.Drawing.Size(400, 272)
        Me.dgCombfond.TabIndex = 0
        '
        'PagCalcMant
        '
        Me.PagCalcMant.Controls.Add(Me.TabTensMantDown)
        Me.PagCalcMant.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcMant.Name = "PagCalcMant"
        Me.PagCalcMant.Size = New System.Drawing.Size(608, 422)
        Me.PagCalcMant.TabIndex = 2
        Me.PagCalcMant.Text = "Tensioni sul mantello"
        '
        'TabTensMantDown
        '
        Me.TabTensMantDown.Controls.Add(Me.PagCalcMantProg)
        Me.TabTensMantDown.Controls.Add(Me.PagCalcMantDim)
        Me.TabTensMantDown.Location = New System.Drawing.Point(8, 8)
        Me.TabTensMantDown.Name = "TabTensMantDown"
        Me.TabTensMantDown.SelectedIndex = 0
        Me.TabTensMantDown.Size = New System.Drawing.Size(600, 408)
        Me.TabTensMantDown.TabIndex = 0
        '
        'PagCalcMantProg
        '
        Me.PagCalcMantProg.Controls.Add(Me.cmdAmmiss)
        Me.PagCalcMantProg.Controls.Add(Me.cmdMat)
        Me.PagCalcMantProg.Controls.Add(Me._Text2_0)
        Me.PagCalcMantProg.Controls.Add(Me._Combo2_0)
        Me.PagCalcMantProg.Controls.Add(Me._Text1_0)
        Me.PagCalcMantProg.Controls.Add(Me._Combo1_0)
        Me.PagCalcMantProg.Controls.Add(Me._Label2_0)
        Me.PagCalcMantProg.Controls.Add(Me._Label1_0)
        Me.PagCalcMantProg.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcMantProg.Name = "PagCalcMantProg"
        Me.PagCalcMantProg.Size = New System.Drawing.Size(592, 382)
        Me.PagCalcMantProg.TabIndex = 0
        Me.PagCalcMantProg.Text = "Dati di progetto"
        '
        'cmdAmmiss
        '
        Me.cmdAmmiss.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAmmiss.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAmmiss.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAmmiss.Image = CType(resources.GetObject("cmdAmmiss.Image"), System.Drawing.Image)
        Me.cmdAmmiss.Location = New System.Drawing.Point(353, 229)
        Me.cmdAmmiss.Name = "cmdAmmiss"
        Me.cmdAmmiss.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAmmiss.Size = New System.Drawing.Size(21, 21)
        Me.cmdAmmiss.TabIndex = 58
        Me.cmdAmmiss.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAmmiss.Visible = False
        '
        'cmdMat
        '
        Me.cmdMat.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMat.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMat.Image = CType(resources.GetObject("cmdMat.Image"), System.Drawing.Image)
        Me.cmdMat.Location = New System.Drawing.Point(353, 197)
        Me.cmdMat.Name = "cmdMat"
        Me.cmdMat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMat.Size = New System.Drawing.Size(21, 21)
        Me.cmdMat.TabIndex = 57
        Me.cmdMat.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdMat.Visible = False
        '
        '_Text2_0
        '
        Me._Text2_0.AcceptsReturn = True
        Me._Text2_0.AutoSize = False
        Me._Text2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_0.Enabled = False
        Me._Text2_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_0.Location = New System.Drawing.Point(353, 157)
        Me._Text2_0.MaxLength = 0
        Me._Text2_0.Name = "_Text2_0"
        Me._Text2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_0.Size = New System.Drawing.Size(71, 21)
        Me._Text2_0.TabIndex = 56
        Me._Text2_0.Text = ""
        Me._Text2_0.Visible = False
        '
        '_Combo2_0
        '
        Me._Combo2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo2_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo2_0.Enabled = False
        Me._Combo2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo2_0.Location = New System.Drawing.Point(121, 133)
        Me._Combo2_0.Name = "_Combo2_0"
        Me._Combo2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo2_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo2_0.TabIndex = 54
        Me._Combo2_0.TabStop = False
        Me._Combo2_0.Visible = False
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.Enabled = False
        Me._Text1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(441, 160)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Multiline = True
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(71, 21)
        Me._Text1_0.TabIndex = 52
        Me._Text1_0.Text = ""
        Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_0.Visible = False
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.Enabled = False
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_0.Location = New System.Drawing.Point(441, 133)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo1_0.TabIndex = 51
        Me._Combo1_0.TabStop = False
        Me._Combo1_0.Visible = False
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.Color.Cyan
        Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.Enabled = False
        Me._Label2_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label2_0.Location = New System.Drawing.Point(465, 197)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(46, 21)
        Me._Label2_0.TabIndex = 55
        Me._Label2_0.Visible = False
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Enabled = False
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(81, 197)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(256, 21)
        Me._Label1_0.TabIndex = 53
        Me._Label1_0.Text = "Label1"
        Me._Label1_0.Visible = False
        '
        'PagCalcMantDim
        '
        Me.PagCalcMantDim.Controls.Add(Me._Text41_0)
        Me.PagCalcMantDim.Controls.Add(Me._Label42_0)
        Me.PagCalcMantDim.Controls.Add(Me._Label41_0)
        Me.PagCalcMantDim.Controls.Add(Me.cmdCalcMant)
        Me.PagCalcMantDim.Controls.Add(Me._Check1_0)
        Me.PagCalcMantDim.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcMantDim.Name = "PagCalcMantDim"
        Me.PagCalcMantDim.Size = New System.Drawing.Size(592, 382)
        Me.PagCalcMantDim.TabIndex = 1
        Me.PagCalcMantDim.Text = "Dimensioni"
        '
        '_Text41_0
        '
        Me._Text41_0.AcceptsReturn = True
        Me._Text41_0.AutoSize = False
        Me._Text41_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text41_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text41_0.Enabled = False
        Me._Text41_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text41_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text41_0.Location = New System.Drawing.Point(441, 161)
        Me._Text41_0.MaxLength = 0
        Me._Text41_0.Multiline = True
        Me._Text41_0.Name = "_Text41_0"
        Me._Text41_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text41_0.Size = New System.Drawing.Size(71, 21)
        Me._Text41_0.TabIndex = 56
        Me._Text41_0.Text = ""
        Me._Text41_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text41_0.Visible = False
        '
        '_Label42_0
        '
        Me._Label42_0.BackColor = System.Drawing.Color.Cyan
        Me._Label42_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label42_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label42_0.Enabled = False
        Me._Label42_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label42_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label42_0.Location = New System.Drawing.Point(465, 201)
        Me._Label42_0.Name = "_Label42_0"
        Me._Label42_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label42_0.Size = New System.Drawing.Size(46, 21)
        Me._Label42_0.TabIndex = 58
        Me._Label42_0.Visible = False
        '
        '_Label41_0
        '
        Me._Label41_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label41_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label41_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label41_0.Enabled = False
        Me._Label41_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label41_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label41_0.Location = New System.Drawing.Point(81, 201)
        Me._Label41_0.Name = "_Label41_0"
        Me._Label41_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label41_0.Size = New System.Drawing.Size(256, 21)
        Me._Label41_0.TabIndex = 57
        Me._Label41_0.Text = "Label1"
        Me._Label41_0.Visible = False
        '
        'cmdCalcMant
        '
        Me.cmdCalcMant.Location = New System.Drawing.Point(448, 327)
        Me.cmdCalcMant.Name = "cmdCalcMant"
        Me.cmdCalcMant.Size = New System.Drawing.Size(56, 24)
        Me.cmdCalcMant.TabIndex = 54
        Me.cmdCalcMant.Text = "Calcola"
        '
        '_Check1_0
        '
        Me._Check1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Check1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_0.Location = New System.Drawing.Point(88, 31)
        Me._Check1_0.Name = "_Check1_0"
        Me._Check1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_0.Size = New System.Drawing.Size(169, 17)
        Me._Check1_0.TabIndex = 53
        Me._Check1_0.Text = "Reinforcing Ring"
        Me._Check1_0.Visible = False
        '
        'PagCalcSelle
        '
        Me.PagCalcSelle.Controls.Add(Me.cmdCalcMant5)
        Me.PagCalcSelle.Controls.Add(Me._Text52_0)
        Me.PagCalcSelle.Controls.Add(Me._Combo52_0)
        Me.PagCalcSelle.Controls.Add(Me._Text51_0)
        Me.PagCalcSelle.Controls.Add(Me._Label52_0)
        Me.PagCalcSelle.Controls.Add(Me._Label51_0)
        Me.PagCalcSelle.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcSelle.Name = "PagCalcSelle"
        Me.PagCalcSelle.Size = New System.Drawing.Size(608, 422)
        Me.PagCalcSelle.TabIndex = 1
        Me.PagCalcSelle.Text = "Tensioni nelle selle"
        '
        'cmdCalcMant5
        '
        Me.cmdCalcMant5.Location = New System.Drawing.Point(464, 283)
        Me.cmdCalcMant5.Name = "cmdCalcMant5"
        Me.cmdCalcMant5.Size = New System.Drawing.Size(56, 24)
        Me.cmdCalcMant5.TabIndex = 68
        Me.cmdCalcMant5.Text = "Calcola"
        '
        '_Text52_0
        '
        Me._Text52_0.AcceptsReturn = True
        Me._Text52_0.AutoSize = False
        Me._Text52_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text52_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text52_0.Enabled = False
        Me._Text52_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text52_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text52_0.Location = New System.Drawing.Point(365, 140)
        Me._Text52_0.MaxLength = 0
        Me._Text52_0.Name = "_Text52_0"
        Me._Text52_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text52_0.Size = New System.Drawing.Size(71, 21)
        Me._Text52_0.TabIndex = 67
        Me._Text52_0.Text = ""
        Me._Text52_0.Visible = False
        '
        '_Combo52_0
        '
        Me._Combo52_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo52_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo52_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo52_0.Enabled = False
        Me._Combo52_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo52_0.Location = New System.Drawing.Point(133, 116)
        Me._Combo52_0.Name = "_Combo52_0"
        Me._Combo52_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo52_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo52_0.TabIndex = 65
        Me._Combo52_0.TabStop = False
        Me._Combo52_0.Visible = False
        '
        '_Text51_0
        '
        Me._Text51_0.AcceptsReturn = True
        Me._Text51_0.AutoSize = False
        Me._Text51_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text51_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text51_0.Enabled = False
        Me._Text51_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text51_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text51_0.Location = New System.Drawing.Point(453, 140)
        Me._Text51_0.MaxLength = 0
        Me._Text51_0.Multiline = True
        Me._Text51_0.Name = "_Text51_0"
        Me._Text51_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text51_0.Size = New System.Drawing.Size(71, 21)
        Me._Text51_0.TabIndex = 63
        Me._Text51_0.Text = ""
        Me._Text51_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text51_0.Visible = False
        '
        '_Label52_0
        '
        Me._Label52_0.BackColor = System.Drawing.Color.Cyan
        Me._Label52_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label52_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label52_0.Enabled = False
        Me._Label52_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label52_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label52_0.Location = New System.Drawing.Point(477, 180)
        Me._Label52_0.Name = "_Label52_0"
        Me._Label52_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label52_0.Size = New System.Drawing.Size(46, 21)
        Me._Label52_0.TabIndex = 66
        Me._Label52_0.Visible = False
        '
        '_Label51_0
        '
        Me._Label51_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label51_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label51_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label51_0.Enabled = False
        Me._Label51_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label51_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label51_0.Location = New System.Drawing.Point(93, 180)
        Me._Label51_0.Name = "_Label51_0"
        Me._Label51_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label51_0.Size = New System.Drawing.Size(256, 21)
        Me._Label51_0.TabIndex = 64
        Me._Label51_0.Text = "Label1"
        Me._Label51_0.Visible = False
        '
        'PagCalcFonda
        '
        Me.PagCalcFonda.Controls.Add(Me.cmdLibrTir)
        Me.PagCalcFonda.Controls.Add(Me.cmdCalcMant6)
        Me.PagCalcFonda.Controls.Add(Me._Text62_0)
        Me.PagCalcFonda.Controls.Add(Me._Combo62_0)
        Me.PagCalcFonda.Controls.Add(Me._Text61_0)
        Me.PagCalcFonda.Controls.Add(Me._Label62_0)
        Me.PagCalcFonda.Controls.Add(Me._Label61_0)
        Me.PagCalcFonda.Controls.Add(Me.Check2)
        Me.PagCalcFonda.Controls.Add(Me.Picture2)
        Me.PagCalcFonda.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcFonda.Name = "PagCalcFonda"
        Me.PagCalcFonda.Size = New System.Drawing.Size(608, 422)
        Me.PagCalcFonda.TabIndex = 3
        Me.PagCalcFonda.Text = "Piastre di base e tirafondi"
        '
        'cmdLibrTir
        '
        Me.cmdLibrTir.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLibrTir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLibrTir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLibrTir.Image = CType(resources.GetObject("cmdLibrTir.Image"), System.Drawing.Image)
        Me.cmdLibrTir.Location = New System.Drawing.Point(456, 128)
        Me.cmdLibrTir.Name = "cmdLibrTir"
        Me.cmdLibrTir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLibrTir.Size = New System.Drawing.Size(21, 21)
        Me.cmdLibrTir.TabIndex = 68
        Me.cmdLibrTir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCalcMant6
        '
        Me.cmdCalcMant6.Location = New System.Drawing.Point(464, 320)
        Me.cmdCalcMant6.Name = "cmdCalcMant6"
        Me.cmdCalcMant6.Size = New System.Drawing.Size(56, 24)
        Me.cmdCalcMant6.TabIndex = 67
        Me.cmdCalcMant6.Text = "Calcola"
        '
        '_Text62_0
        '
        Me._Text62_0.AcceptsReturn = True
        Me._Text62_0.AutoSize = False
        Me._Text62_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text62_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text62_0.Enabled = False
        Me._Text62_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text62_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text62_0.Location = New System.Drawing.Point(365, 193)
        Me._Text62_0.MaxLength = 0
        Me._Text62_0.Name = "_Text62_0"
        Me._Text62_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text62_0.Size = New System.Drawing.Size(71, 21)
        Me._Text62_0.TabIndex = 66
        Me._Text62_0.Text = ""
        Me._Text62_0.Visible = False
        '
        '_Combo62_0
        '
        Me._Combo62_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo62_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo62_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo62_0.Enabled = False
        Me._Combo62_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo62_0.Location = New System.Drawing.Point(133, 169)
        Me._Combo62_0.Name = "_Combo62_0"
        Me._Combo62_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo62_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo62_0.TabIndex = 64
        Me._Combo62_0.TabStop = False
        Me._Combo62_0.Visible = False
        '
        '_Text61_0
        '
        Me._Text61_0.AcceptsReturn = True
        Me._Text61_0.AutoSize = False
        Me._Text61_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text61_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text61_0.Enabled = False
        Me._Text61_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text61_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text61_0.Location = New System.Drawing.Point(453, 193)
        Me._Text61_0.MaxLength = 0
        Me._Text61_0.Multiline = True
        Me._Text61_0.Name = "_Text61_0"
        Me._Text61_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text61_0.Size = New System.Drawing.Size(71, 21)
        Me._Text61_0.TabIndex = 62
        Me._Text61_0.Text = ""
        Me._Text61_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text61_0.Visible = False
        '
        '_Label62_0
        '
        Me._Label62_0.BackColor = System.Drawing.Color.Cyan
        Me._Label62_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label62_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label62_0.Enabled = False
        Me._Label62_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label62_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label62_0.Location = New System.Drawing.Point(477, 233)
        Me._Label62_0.Name = "_Label62_0"
        Me._Label62_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label62_0.Size = New System.Drawing.Size(46, 21)
        Me._Label62_0.TabIndex = 65
        Me._Label62_0.Visible = False
        '
        '_Label61_0
        '
        Me._Label61_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label61_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label61_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label61_0.Enabled = False
        Me._Label61_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label61_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label61_0.Location = New System.Drawing.Point(93, 233)
        Me._Label61_0.Name = "_Label61_0"
        Me._Label61_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label61_0.Size = New System.Drawing.Size(256, 21)
        Me._Label61_0.TabIndex = 63
        Me._Label61_0.Text = "Label1"
        Me._Label61_0.Visible = False
        '
        'Check2
        '
        Me.Check2.BackColor = System.Drawing.SystemColors.Control
        Me.Check2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check2.Location = New System.Drawing.Point(200, 199)
        Me.Check2.Name = "Check2"
        Me.Check2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check2.Size = New System.Drawing.Size(217, 25)
        Me.Check2.TabIndex = 42
        Me.Check2.Text = "Sella mobile inchiavardata"
        Me.Check2.Visible = False
        '
        'Picture2
        '
        Me.Picture2.BackColor = System.Drawing.Color.White
        Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture2.Image = CType(resources.GetObject("Picture2.Image"), System.Drawing.Image)
        Me.Picture2.Location = New System.Drawing.Point(248, 153)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture2.Size = New System.Drawing.Size(120, 117)
        Me.Picture2.TabIndex = 38
        Me.Picture2.TabStop = False
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.PagDown)
        Me.TabMain.Controls.Add(Me.PagUp)
        Me.TabMain.Location = New System.Drawing.Point(8, 8)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(640, 496)
        Me.TabMain.TabIndex = 22
        '
        'PagDown
        '
        Me.PagDown.Controls.Add(Me.TabPrimoLivDown)
        Me.PagDown.Location = New System.Drawing.Point(4, 22)
        Me.PagDown.Name = "PagDown"
        Me.PagDown.Size = New System.Drawing.Size(632, 470)
        Me.PagDown.TabIndex = 0
        Me.PagDown.Text = "Bottom item"
        '
        'PagUp
        '
        Me.PagUp.Controls.Add(Me.TabPrimoLivUp)
        Me.PagUp.Location = New System.Drawing.Point(4, 22)
        Me.PagUp.Name = "PagUp"
        Me.PagUp.Size = New System.Drawing.Size(632, 470)
        Me.PagUp.TabIndex = 1
        Me.PagUp.Text = "Top Item"
        '
        'TabPrimoLivUp
        '
        Me.TabPrimoLivUp.Controls.Add(Me.PagCarichiT)
        Me.TabPrimoLivUp.Controls.Add(Me.PagCalcMantT)
        Me.TabPrimoLivUp.Controls.Add(Me.PagCalcSelleT)
        Me.TabPrimoLivUp.Location = New System.Drawing.Point(8, 11)
        Me.TabPrimoLivUp.Name = "TabPrimoLivUp"
        Me.TabPrimoLivUp.SelectedIndex = 0
        Me.TabPrimoLivUp.Size = New System.Drawing.Size(616, 448)
        Me.TabPrimoLivUp.TabIndex = 22
        '
        'PagCarichiT
        '
        Me.PagCarichiT.Controls.Add(Me.TabCarichiUp)
        Me.PagCarichiT.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiT.Name = "PagCarichiT"
        Me.PagCarichiT.Size = New System.Drawing.Size(608, 422)
        Me.PagCarichiT.TabIndex = 0
        Me.PagCarichiT.Text = "Carichi"
        '
        'TabCarichiUp
        '
        Me.TabCarichiUp.Controls.Add(Me.PagDatiGeneraliT)
        Me.TabCarichiUp.Controls.Add(Me.PagCarichiBocchelliT)
        Me.TabCarichiUp.Controls.Add(Me.PagCarichiFondazioniT)
        Me.TabCarichiUp.Location = New System.Drawing.Point(8, 8)
        Me.TabCarichiUp.Name = "TabCarichiUp"
        Me.TabCarichiUp.SelectedIndex = 0
        Me.TabCarichiUp.Size = New System.Drawing.Size(592, 400)
        Me.TabCarichiUp.TabIndex = 34
        '
        'PagDatiGeneraliT
        '
        Me.PagDatiGeneraliT.Controls.Add(Me._Text3T_0)
        Me.PagDatiGeneraliT.Controls.Add(Me._Label4T_0)
        Me.PagDatiGeneraliT.Controls.Add(Me._Label3T_0)
        Me.PagDatiGeneraliT.Location = New System.Drawing.Point(4, 22)
        Me.PagDatiGeneraliT.Name = "PagDatiGeneraliT"
        Me.PagDatiGeneraliT.Size = New System.Drawing.Size(584, 374)
        Me.PagDatiGeneraliT.TabIndex = 0
        Me.PagDatiGeneraliT.Text = "Dati generali"
        '
        '_Text3T_0
        '
        Me._Text3T_0.AcceptsReturn = True
        Me._Text3T_0.AutoSize = False
        Me._Text3T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text3T_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3T_0.Enabled = False
        Me._Text3T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text3T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3T_0.Location = New System.Drawing.Point(349, 157)
        Me._Text3T_0.MaxLength = 0
        Me._Text3T_0.Multiline = True
        Me._Text3T_0.Name = "_Text3T_0"
        Me._Text3T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3T_0.Size = New System.Drawing.Size(71, 21)
        Me._Text3T_0.TabIndex = 35
        Me._Text3T_0.Text = ""
        Me._Text3T_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text3T_0.Visible = False
        '
        '_Label4T_0
        '
        Me._Label4T_0.BackColor = System.Drawing.Color.Cyan
        Me._Label4T_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label4T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label4T_0.Enabled = False
        Me._Label4T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label4T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label4T_0.Location = New System.Drawing.Point(429, 157)
        Me._Label4T_0.Name = "_Label4T_0"
        Me._Label4T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label4T_0.Size = New System.Drawing.Size(46, 21)
        Me._Label4T_0.TabIndex = 34
        Me._Label4T_0.Visible = False
        '
        '_Label3T_0
        '
        Me._Label3T_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label3T_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label3T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3T_0.Enabled = False
        Me._Label3T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label3T_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3T_0.Location = New System.Drawing.Point(8, 32)
        Me._Label3T_0.Name = "_Label3T_0"
        Me._Label3T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3T_0.Size = New System.Drawing.Size(288, 21)
        Me._Label3T_0.TabIndex = 33
        Me._Label3T_0.Text = "Label1"
        Me._Label3T_0.Visible = False
        '
        'PagCarichiBocchelliT
        '
        Me.PagCarichiBocchelliT.BackColor = System.Drawing.SystemColors.Control
        Me.PagCarichiBocchelliT.Controls.Add(Me.TabBocchUp)
        Me.PagCarichiBocchelliT.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiBocchelliT.Name = "PagCarichiBocchelliT"
        Me.PagCarichiBocchelliT.Size = New System.Drawing.Size(584, 374)
        Me.PagCarichiBocchelliT.TabIndex = 2
        Me.PagCarichiBocchelliT.Text = "Carichi sui bocchelli"
        Me.PagCarichiBocchelliT.Visible = False
        '
        'TabBocchUp
        '
        Me.TabBocchUp.Controls.Add(Me.PagListaBocchelliT)
        Me.TabBocchUp.Controls.Add(Me.PagT1T)
        Me.TabBocchUp.Location = New System.Drawing.Point(8, 11)
        Me.TabBocchUp.Name = "TabBocchUp"
        Me.TabBocchUp.SelectedIndex = 0
        Me.TabBocchUp.Size = New System.Drawing.Size(568, 352)
        Me.TabBocchUp.TabIndex = 1
        '
        'PagListaBocchelliT
        '
        Me.PagListaBocchelliT.Controls.Add(Me.cmdRiprBocchT)
        Me.PagListaBocchelliT.Controls.Add(Me.dgListaBocchelliT)
        Me.PagListaBocchelliT.Location = New System.Drawing.Point(4, 22)
        Me.PagListaBocchelliT.Name = "PagListaBocchelliT"
        Me.PagListaBocchelliT.Size = New System.Drawing.Size(560, 326)
        Me.PagListaBocchelliT.TabIndex = 0
        Me.PagListaBocchelliT.Text = "Lista Bocchelli"
        '
        'dgListaBocchelliT
        '
        Me.dgListaBocchelliT.CaptionText = "LISTA BOCCHELLI"
        Me.dgListaBocchelliT.DataMember = ""
        Me.dgListaBocchelliT.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.dgListaBocchelliT, "CarBocch.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.dgListaBocchelliT, System.Windows.Forms.HelpNavigator.Topic)
        Me.dgListaBocchelliT.Location = New System.Drawing.Point(64, 47)
        Me.dgListaBocchelliT.Name = "dgListaBocchelliT"
        Me.HelpProvider1.SetShowHelp(Me.dgListaBocchelliT, True)
        Me.dgListaBocchelliT.Size = New System.Drawing.Size(432, 232)
        Me.dgListaBocchelliT.TabIndex = 1
        '
        'PagT1T
        '
        Me.PagT1T.Controls.Add(Me.dgCarBocchT1)
        Me.PagT1T.Location = New System.Drawing.Point(4, 22)
        Me.PagT1T.Name = "PagT1T"
        Me.PagT1T.Size = New System.Drawing.Size(560, 326)
        Me.PagT1T.TabIndex = 1
        Me.PagT1T.Text = "T1"
        Me.PagT1T.Visible = False
        '
        'dgCarBocchT1
        '
        Me.dgCarBocchT1.DataMember = ""
        Me.dgCarBocchT1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCarBocchT1.Location = New System.Drawing.Point(8, 8)
        Me.dgCarBocchT1.Name = "dgCarBocchT1"
        Me.dgCarBocchT1.Size = New System.Drawing.Size(544, 312)
        Me.dgCarBocchT1.TabIndex = 0
        '
        'PagCarichiFondazioniT
        '
        Me.PagCarichiFondazioniT.Controls.Add(Me.TabCarFondUp)
        Me.PagCarichiFondazioniT.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichiFondazioniT.Name = "PagCarichiFondazioniT"
        Me.PagCarichiFondazioniT.Size = New System.Drawing.Size(584, 374)
        Me.PagCarichiFondazioniT.TabIndex = 3
        Me.PagCarichiFondazioniT.Text = "Carichi sull'item inferiore"
        Me.PagCarichiFondazioniT.Visible = False
        '
        'TabCarFondUp
        '
        Me.TabCarFondUp.Controls.Add(Me.PagRisultBocchelliT)
        Me.TabCarFondUp.Controls.Add(Me.PagVentoT)
        Me.TabCarFondUp.Controls.Add(Me.PagSismaT)
        Me.TabCarFondUp.Controls.Add(Me.PagCarichifinaliT)
        Me.TabCarFondUp.Location = New System.Drawing.Point(8, 7)
        Me.TabCarFondUp.Name = "TabCarFondUp"
        Me.TabCarFondUp.SelectedIndex = 0
        Me.TabCarFondUp.Size = New System.Drawing.Size(568, 360)
        Me.TabCarFondUp.TabIndex = 1
        '
        'PagRisultBocchelliT
        '
        Me.PagRisultBocchelliT.Controls.Add(Me.lblNienteCarichiT)
        Me.PagRisultBocchelliT.Location = New System.Drawing.Point(4, 22)
        Me.PagRisultBocchelliT.Name = "PagRisultBocchelliT"
        Me.PagRisultBocchelliT.Size = New System.Drawing.Size(560, 334)
        Me.PagRisultBocchelliT.TabIndex = 0
        Me.PagRisultBocchelliT.Text = "Risultanti dei carichi sui bocchelli"
        '
        'lblNienteCarichiT
        '
        Me.lblNienteCarichiT.BackColor = System.Drawing.Color.Yellow
        Me.lblNienteCarichiT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNienteCarichiT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNienteCarichiT.Location = New System.Drawing.Point(96, 96)
        Me.lblNienteCarichiT.Name = "lblNienteCarichiT"
        Me.lblNienteCarichiT.Size = New System.Drawing.Size(376, 120)
        Me.lblNienteCarichiT.TabIndex = 0
        Me.lblNienteCarichiT.Text = "Non sono stati specificati carichi sui bocchelli. Il calcolo può procedere senza " & _
        "di essi."
        '
        'PagVentoT
        '
        Me.PagVentoT.Controls.Add(Me._lblsVentoT_0)
        Me.PagVentoT.Controls.Add(Me._rtfVentoT_0)
        Me.PagVentoT.Controls.Add(Me._txtVentoT_0)
        Me.PagVentoT.Controls.Add(Me._lblVentoT_0)
        Me.PagVentoT.Controls.Add(Me.lblsFrontForceT)
        Me.PagVentoT.Controls.Add(Me.lblsLateralForceT)
        Me.PagVentoT.Controls.Add(Me.lblsPressureT)
        Me.PagVentoT.Controls.Add(Me.lblsFrontAreaT)
        Me.PagVentoT.Controls.Add(Me.lblsLateralAreaT)
        Me.PagVentoT.Controls.Add(Me.rtfFormulaVentoT)
        Me.PagVentoT.Controls.Add(Me.lblCodiceVentoT)
        Me.PagVentoT.Controls.Add(Me.rtfFrontForceT)
        Me.PagVentoT.Controls.Add(Me.txtFrontForceT)
        Me.PagVentoT.Controls.Add(Me.lblFrontForceT)
        Me.PagVentoT.Controls.Add(Me.rtfLateralForceT)
        Me.PagVentoT.Controls.Add(Me.txtLateralForceT)
        Me.PagVentoT.Controls.Add(Me.lblLateralForceT)
        Me.PagVentoT.Controls.Add(Me.rtfPressureT)
        Me.PagVentoT.Controls.Add(Me.txtPressureT)
        Me.PagVentoT.Controls.Add(Me.lblPressureT)
        Me.PagVentoT.Controls.Add(Me.rtfFrontAreaT)
        Me.PagVentoT.Controls.Add(Me.txtFrontAreaT)
        Me.PagVentoT.Controls.Add(Me.lblFrontAreaT)
        Me.PagVentoT.Controls.Add(Me.rtfLateralAreaT)
        Me.PagVentoT.Controls.Add(Me.txtLateralAreaT)
        Me.PagVentoT.Controls.Add(Me.lblLateralAreaT)
        Me.PagVentoT.Location = New System.Drawing.Point(4, 22)
        Me.PagVentoT.Name = "PagVentoT"
        Me.PagVentoT.Size = New System.Drawing.Size(560, 334)
        Me.PagVentoT.TabIndex = 2
        Me.PagVentoT.Text = "Vento"
        Me.PagVentoT.Visible = False
        '
        '_lblsVentoT_0
        '
        Me._lblsVentoT_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me._lblsVentoT_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblsVentoT_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblsVentoT_0.Location = New System.Drawing.Point(152, 56)
        Me._lblsVentoT_0.Name = "_lblsVentoT_0"
        Me._lblsVentoT_0.Size = New System.Drawing.Size(32, 24)
        Me._lblsVentoT_0.TabIndex = 64
        Me._lblsVentoT_0.Text = "Al"
        Me._lblsVentoT_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._lblsVentoT_0.Visible = False
        '
        '_rtfVentoT_0
        '
        Me._rtfVentoT_0.BackColor = System.Drawing.Color.Cyan
        Me._rtfVentoT_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._rtfVentoT_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtfVentoT_0.Location = New System.Drawing.Point(184, 56)
        Me._rtfVentoT_0.Multiline = False
        Me._rtfVentoT_0.Name = "_rtfVentoT_0"
        Me._rtfVentoT_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtfVentoT_0.Size = New System.Drawing.Size(40, 24)
        Me._rtfVentoT_0.TabIndex = 63
        Me._rtfVentoT_0.Text = ""
        Me._rtfVentoT_0.Visible = False
        '
        '_txtVentoT_0
        '
        Me._txtVentoT_0.AcceptsReturn = True
        Me._txtVentoT_0.AutoSize = False
        Me._txtVentoT_0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me._txtVentoT_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtVentoT_0.Enabled = False
        Me._txtVentoT_0.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtVentoT_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtVentoT_0.Location = New System.Drawing.Point(224, 56)
        Me._txtVentoT_0.MaxLength = 0
        Me._txtVentoT_0.Name = "_txtVentoT_0"
        Me._txtVentoT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtVentoT_0.Size = New System.Drawing.Size(71, 24)
        Me._txtVentoT_0.TabIndex = 62
        Me._txtVentoT_0.Text = ""
        Me._txtVentoT_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._txtVentoT_0.Visible = False
        '
        '_lblVentoT_0
        '
        Me._lblVentoT_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblVentoT_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblVentoT_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVentoT_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVentoT_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblVentoT_0.Location = New System.Drawing.Point(8, 56)
        Me._lblVentoT_0.Name = "_lblVentoT_0"
        Me._lblVentoT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVentoT_0.Size = New System.Drawing.Size(144, 24)
        Me._lblVentoT_0.TabIndex = 61
        Me._lblVentoT_0.Text = "Lateral area"
        Me._lblVentoT_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._lblVentoT_0.Visible = False
        '
        'lblsFrontForceT
        '
        Me.lblsFrontForceT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsFrontForceT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsFrontForceT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsFrontForceT.Location = New System.Drawing.Point(408, 200)
        Me.lblsFrontForceT.Name = "lblsFrontForceT"
        Me.lblsFrontForceT.Size = New System.Drawing.Size(32, 24)
        Me.lblsFrontForceT.TabIndex = 60
        Me.lblsFrontForceT.Text = "Fl"
        Me.lblsFrontForceT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsLateralForceT
        '
        Me.lblsLateralForceT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsLateralForceT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsLateralForceT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsLateralForceT.Location = New System.Drawing.Point(408, 176)
        Me.lblsLateralForceT.Name = "lblsLateralForceT"
        Me.lblsLateralForceT.Size = New System.Drawing.Size(32, 24)
        Me.lblsLateralForceT.TabIndex = 59
        Me.lblsLateralForceT.Text = "Fl"
        Me.lblsLateralForceT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsPressureT
        '
        Me.lblsPressureT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsPressureT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsPressureT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsPressureT.Location = New System.Drawing.Point(408, 120)
        Me.lblsPressureT.Name = "lblsPressureT"
        Me.lblsPressureT.Size = New System.Drawing.Size(32, 24)
        Me.lblsPressureT.TabIndex = 58
        Me.lblsPressureT.Text = "p"
        Me.lblsPressureT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsFrontAreaT
        '
        Me.lblsFrontAreaT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsFrontAreaT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsFrontAreaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsFrontAreaT.Location = New System.Drawing.Point(408, 80)
        Me.lblsFrontAreaT.Name = "lblsFrontAreaT"
        Me.lblsFrontAreaT.Size = New System.Drawing.Size(32, 24)
        Me.lblsFrontAreaT.TabIndex = 57
        Me.lblsFrontAreaT.Text = "Af"
        Me.lblsFrontAreaT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsLateralAreaT
        '
        Me.lblsLateralAreaT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsLateralAreaT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsLateralAreaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsLateralAreaT.Location = New System.Drawing.Point(408, 56)
        Me.lblsLateralAreaT.Name = "lblsLateralAreaT"
        Me.lblsLateralAreaT.Size = New System.Drawing.Size(32, 24)
        Me.lblsLateralAreaT.TabIndex = 56
        Me.lblsLateralAreaT.Text = "Al"
        Me.lblsLateralAreaT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfFormulaVentoT
        '
        Me.rtfFormulaVentoT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfFormulaVentoT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFormulaVentoT.Location = New System.Drawing.Point(64, 280)
        Me.rtfFormulaVentoT.Multiline = False
        Me.rtfFormulaVentoT.Name = "rtfFormulaVentoT"
        Me.rtfFormulaVentoT.Size = New System.Drawing.Size(440, 24)
        Me.rtfFormulaVentoT.TabIndex = 55
        Me.rtfFormulaVentoT.Text = "RichTextBox1"
        '
        'lblCodiceVentoT
        '
        Me.lblCodiceVentoT.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCodiceVentoT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceVentoT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCodiceVentoT.Location = New System.Drawing.Point(176, 8)
        Me.lblCodiceVentoT.Name = "lblCodiceVentoT"
        Me.lblCodiceVentoT.Size = New System.Drawing.Size(208, 24)
        Me.lblCodiceVentoT.TabIndex = 54
        Me.lblCodiceVentoT.Text = "lblCodiceVentoT"
        Me.lblCodiceVentoT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfFrontForceT
        '
        Me.rtfFrontForceT.BackColor = System.Drawing.Color.Cyan
        Me.rtfFrontForceT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfFrontForceT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFrontForceT.Location = New System.Drawing.Point(440, 200)
        Me.rtfFrontForceT.Multiline = False
        Me.rtfFrontForceT.Name = "rtfFrontForceT"
        Me.rtfFrontForceT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfFrontForceT.Size = New System.Drawing.Size(40, 24)
        Me.rtfFrontForceT.TabIndex = 53
        Me.rtfFrontForceT.Text = ""
        '
        'txtFrontForceT
        '
        Me.txtFrontForceT.AcceptsReturn = True
        Me.txtFrontForceT.AutoSize = False
        Me.txtFrontForceT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtFrontForceT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFrontForceT.Enabled = False
        Me.txtFrontForceT.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrontForceT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFrontForceT.Location = New System.Drawing.Point(480, 200)
        Me.txtFrontForceT.MaxLength = 0
        Me.txtFrontForceT.Name = "txtFrontForceT"
        Me.txtFrontForceT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFrontForceT.Size = New System.Drawing.Size(71, 24)
        Me.txtFrontForceT.TabIndex = 52
        Me.txtFrontForceT.Text = ""
        Me.txtFrontForceT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFrontForceT
        '
        Me.lblFrontForceT.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrontForceT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFrontForceT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFrontForceT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrontForceT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFrontForceT.Location = New System.Drawing.Point(304, 200)
        Me.lblFrontForceT.Name = "lblFrontForceT"
        Me.lblFrontForceT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrontForceT.Size = New System.Drawing.Size(104, 24)
        Me.lblFrontForceT.TabIndex = 51
        Me.lblFrontForceT.Text = "Front force"
        '
        'rtfLateralForceT
        '
        Me.rtfLateralForceT.BackColor = System.Drawing.Color.Cyan
        Me.rtfLateralForceT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfLateralForceT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfLateralForceT.Location = New System.Drawing.Point(440, 176)
        Me.rtfLateralForceT.Multiline = False
        Me.rtfLateralForceT.Name = "rtfLateralForceT"
        Me.rtfLateralForceT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfLateralForceT.Size = New System.Drawing.Size(40, 24)
        Me.rtfLateralForceT.TabIndex = 50
        Me.rtfLateralForceT.Text = ""
        '
        'txtLateralForceT
        '
        Me.txtLateralForceT.AcceptsReturn = True
        Me.txtLateralForceT.AutoSize = False
        Me.txtLateralForceT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtLateralForceT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLateralForceT.Enabled = False
        Me.txtLateralForceT.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLateralForceT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLateralForceT.Location = New System.Drawing.Point(480, 176)
        Me.txtLateralForceT.MaxLength = 0
        Me.txtLateralForceT.Name = "txtLateralForceT"
        Me.txtLateralForceT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLateralForceT.Size = New System.Drawing.Size(71, 24)
        Me.txtLateralForceT.TabIndex = 49
        Me.txtLateralForceT.Text = ""
        Me.txtLateralForceT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLateralForceT
        '
        Me.lblLateralForceT.BackColor = System.Drawing.SystemColors.Control
        Me.lblLateralForceT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLateralForceT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLateralForceT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateralForceT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLateralForceT.Location = New System.Drawing.Point(304, 176)
        Me.lblLateralForceT.Name = "lblLateralForceT"
        Me.lblLateralForceT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLateralForceT.Size = New System.Drawing.Size(104, 24)
        Me.lblLateralForceT.TabIndex = 48
        Me.lblLateralForceT.Text = "Lateral force"
        '
        'rtfPressureT
        '
        Me.rtfPressureT.BackColor = System.Drawing.Color.Cyan
        Me.rtfPressureT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfPressureT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfPressureT.Location = New System.Drawing.Point(440, 120)
        Me.rtfPressureT.Multiline = False
        Me.rtfPressureT.Name = "rtfPressureT"
        Me.rtfPressureT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfPressureT.Size = New System.Drawing.Size(40, 24)
        Me.rtfPressureT.TabIndex = 47
        Me.rtfPressureT.Text = ""
        '
        'txtPressureT
        '
        Me.txtPressureT.AcceptsReturn = True
        Me.txtPressureT.AutoSize = False
        Me.txtPressureT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtPressureT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPressureT.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPressureT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPressureT.Location = New System.Drawing.Point(480, 120)
        Me.txtPressureT.MaxLength = 0
        Me.txtPressureT.Name = "txtPressureT"
        Me.txtPressureT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPressureT.Size = New System.Drawing.Size(71, 24)
        Me.txtPressureT.TabIndex = 46
        Me.txtPressureT.Text = ""
        Me.txtPressureT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPressureT
        '
        Me.lblPressureT.BackColor = System.Drawing.SystemColors.Control
        Me.lblPressureT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPressureT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPressureT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPressureT.Location = New System.Drawing.Point(304, 120)
        Me.lblPressureT.Name = "lblPressureT"
        Me.lblPressureT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPressureT.Size = New System.Drawing.Size(104, 24)
        Me.lblPressureT.TabIndex = 45
        Me.lblPressureT.Text = "Wind pressure"
        Me.lblPressureT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtfFrontAreaT
        '
        Me.rtfFrontAreaT.BackColor = System.Drawing.Color.Cyan
        Me.rtfFrontAreaT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfFrontAreaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFrontAreaT.Location = New System.Drawing.Point(440, 80)
        Me.rtfFrontAreaT.Multiline = False
        Me.rtfFrontAreaT.Name = "rtfFrontAreaT"
        Me.rtfFrontAreaT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfFrontAreaT.Size = New System.Drawing.Size(40, 24)
        Me.rtfFrontAreaT.TabIndex = 44
        Me.rtfFrontAreaT.Text = ""
        '
        'txtFrontAreaT
        '
        Me.txtFrontAreaT.AcceptsReturn = True
        Me.txtFrontAreaT.AutoSize = False
        Me.txtFrontAreaT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtFrontAreaT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFrontAreaT.Enabled = False
        Me.txtFrontAreaT.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrontAreaT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFrontAreaT.Location = New System.Drawing.Point(480, 80)
        Me.txtFrontAreaT.MaxLength = 0
        Me.txtFrontAreaT.Name = "txtFrontAreaT"
        Me.txtFrontAreaT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFrontAreaT.Size = New System.Drawing.Size(71, 24)
        Me.txtFrontAreaT.TabIndex = 43
        Me.txtFrontAreaT.Text = ""
        Me.txtFrontAreaT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFrontAreaT
        '
        Me.lblFrontAreaT.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrontAreaT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFrontAreaT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFrontAreaT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrontAreaT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFrontAreaT.Location = New System.Drawing.Point(304, 80)
        Me.lblFrontAreaT.Name = "lblFrontAreaT"
        Me.lblFrontAreaT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrontAreaT.Size = New System.Drawing.Size(104, 24)
        Me.lblFrontAreaT.TabIndex = 42
        Me.lblFrontAreaT.Text = "Front area"
        Me.lblFrontAreaT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtfLateralAreaT
        '
        Me.rtfLateralAreaT.BackColor = System.Drawing.Color.Cyan
        Me.rtfLateralAreaT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfLateralAreaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfLateralAreaT.Location = New System.Drawing.Point(440, 56)
        Me.rtfLateralAreaT.Multiline = False
        Me.rtfLateralAreaT.Name = "rtfLateralAreaT"
        Me.rtfLateralAreaT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfLateralAreaT.Size = New System.Drawing.Size(40, 24)
        Me.rtfLateralAreaT.TabIndex = 41
        Me.rtfLateralAreaT.Text = ""
        '
        'txtLateralAreaT
        '
        Me.txtLateralAreaT.AcceptsReturn = True
        Me.txtLateralAreaT.AutoSize = False
        Me.txtLateralAreaT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtLateralAreaT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLateralAreaT.Enabled = False
        Me.txtLateralAreaT.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLateralAreaT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLateralAreaT.Location = New System.Drawing.Point(480, 56)
        Me.txtLateralAreaT.MaxLength = 0
        Me.txtLateralAreaT.Name = "txtLateralAreaT"
        Me.txtLateralAreaT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLateralAreaT.Size = New System.Drawing.Size(71, 24)
        Me.txtLateralAreaT.TabIndex = 40
        Me.txtLateralAreaT.Text = ""
        Me.txtLateralAreaT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLateralAreaT
        '
        Me.lblLateralAreaT.BackColor = System.Drawing.SystemColors.Control
        Me.lblLateralAreaT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLateralAreaT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLateralAreaT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateralAreaT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLateralAreaT.Location = New System.Drawing.Point(304, 56)
        Me.lblLateralAreaT.Name = "lblLateralAreaT"
        Me.lblLateralAreaT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLateralAreaT.Size = New System.Drawing.Size(104, 24)
        Me.lblLateralAreaT.TabIndex = 38
        Me.lblLateralAreaT.Text = "Lateral area"
        Me.lblLateralAreaT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PagSismaT
        '
        Me.PagSismaT.Controls.Add(Me._lblsSismaT_0)
        Me.PagSismaT.Controls.Add(Me._rtfSismaT_0)
        Me.PagSismaT.Controls.Add(Me._txtSismaT_0)
        Me.PagSismaT.Controls.Add(Me._lblSismaT_0)
        Me.PagSismaT.Controls.Add(Me.lblsForceSeismT)
        Me.PagSismaT.Controls.Add(Me.rtfFormulaSismaT)
        Me.PagSismaT.Controls.Add(Me.lblCodiceSismaT)
        Me.PagSismaT.Controls.Add(Me.rtfForceSeismT)
        Me.PagSismaT.Controls.Add(Me.txtForceSeismT)
        Me.PagSismaT.Controls.Add(Me.lblForceSeismT)
        Me.PagSismaT.Location = New System.Drawing.Point(4, 22)
        Me.PagSismaT.Name = "PagSismaT"
        Me.PagSismaT.Size = New System.Drawing.Size(560, 334)
        Me.PagSismaT.TabIndex = 3
        Me.PagSismaT.Text = "Terremoto"
        Me.PagSismaT.Visible = False
        '
        '_lblsSismaT_0
        '
        Me._lblsSismaT_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me._lblsSismaT_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblsSismaT_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblsSismaT_0.Location = New System.Drawing.Point(152, 56)
        Me._lblsSismaT_0.Name = "_lblsSismaT_0"
        Me._lblsSismaT_0.Size = New System.Drawing.Size(32, 24)
        Me._lblsSismaT_0.TabIndex = 74
        Me._lblsSismaT_0.Text = "Al"
        Me._lblsSismaT_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._lblsSismaT_0.Visible = False
        '
        '_rtfSismaT_0
        '
        Me._rtfSismaT_0.BackColor = System.Drawing.Color.Cyan
        Me._rtfSismaT_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._rtfSismaT_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._rtfSismaT_0.Location = New System.Drawing.Point(184, 56)
        Me._rtfSismaT_0.Multiline = False
        Me._rtfSismaT_0.Name = "_rtfSismaT_0"
        Me._rtfSismaT_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._rtfSismaT_0.Size = New System.Drawing.Size(40, 24)
        Me._rtfSismaT_0.TabIndex = 73
        Me._rtfSismaT_0.Text = ""
        Me._rtfSismaT_0.Visible = False
        '
        '_txtSismaT_0
        '
        Me._txtSismaT_0.AcceptsReturn = True
        Me._txtSismaT_0.AutoSize = False
        Me._txtSismaT_0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me._txtSismaT_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtSismaT_0.Enabled = False
        Me._txtSismaT_0.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtSismaT_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtSismaT_0.Location = New System.Drawing.Point(224, 56)
        Me._txtSismaT_0.MaxLength = 0
        Me._txtSismaT_0.Name = "_txtSismaT_0"
        Me._txtSismaT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtSismaT_0.Size = New System.Drawing.Size(71, 24)
        Me._txtSismaT_0.TabIndex = 72
        Me._txtSismaT_0.Text = ""
        Me._txtSismaT_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._txtSismaT_0.Visible = False
        '
        '_lblSismaT_0
        '
        Me._lblSismaT_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblSismaT_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblSismaT_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSismaT_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSismaT_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSismaT_0.Location = New System.Drawing.Point(8, 56)
        Me._lblSismaT_0.Name = "_lblSismaT_0"
        Me._lblSismaT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSismaT_0.Size = New System.Drawing.Size(144, 24)
        Me._lblSismaT_0.TabIndex = 71
        Me._lblSismaT_0.Text = "Lateral area"
        Me._lblSismaT_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._lblSismaT_0.Visible = False
        '
        'lblsForceSeismT
        '
        Me.lblsForceSeismT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.lblsForceSeismT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsForceSeismT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsForceSeismT.Location = New System.Drawing.Point(408, 200)
        Me.lblsForceSeismT.Name = "lblsForceSeismT"
        Me.lblsForceSeismT.Size = New System.Drawing.Size(32, 24)
        Me.lblsForceSeismT.TabIndex = 70
        Me.lblsForceSeismT.Text = "F"
        Me.lblsForceSeismT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfFormulaSismaT
        '
        Me.rtfFormulaSismaT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfFormulaSismaT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFormulaSismaT.Location = New System.Drawing.Point(48, 280)
        Me.rtfFormulaSismaT.Multiline = False
        Me.rtfFormulaSismaT.Name = "rtfFormulaSismaT"
        Me.rtfFormulaSismaT.Size = New System.Drawing.Size(464, 24)
        Me.rtfFormulaSismaT.TabIndex = 69
        Me.rtfFormulaSismaT.Text = "RichTextBox3"
        '
        'lblCodiceSismaT
        '
        Me.lblCodiceSismaT.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCodiceSismaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceSismaT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCodiceSismaT.Location = New System.Drawing.Point(176, 8)
        Me.lblCodiceSismaT.Name = "lblCodiceSismaT"
        Me.lblCodiceSismaT.Size = New System.Drawing.Size(208, 24)
        Me.lblCodiceSismaT.TabIndex = 68
        Me.lblCodiceSismaT.Text = "lblCodiceSisma"
        Me.lblCodiceSismaT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtfForceSeismT
        '
        Me.rtfForceSeismT.BackColor = System.Drawing.Color.Cyan
        Me.rtfForceSeismT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfForceSeismT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfForceSeismT.Location = New System.Drawing.Point(440, 200)
        Me.rtfForceSeismT.Multiline = False
        Me.rtfForceSeismT.Name = "rtfForceSeismT"
        Me.rtfForceSeismT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtfForceSeismT.Size = New System.Drawing.Size(40, 24)
        Me.rtfForceSeismT.TabIndex = 67
        Me.rtfForceSeismT.Text = ""
        '
        'txtForceSeismT
        '
        Me.txtForceSeismT.AcceptsReturn = True
        Me.txtForceSeismT.AutoSize = False
        Me.txtForceSeismT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.txtForceSeismT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtForceSeismT.Enabled = False
        Me.txtForceSeismT.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForceSeismT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtForceSeismT.Location = New System.Drawing.Point(480, 200)
        Me.txtForceSeismT.MaxLength = 0
        Me.txtForceSeismT.Name = "txtForceSeismT"
        Me.txtForceSeismT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtForceSeismT.Size = New System.Drawing.Size(71, 24)
        Me.txtForceSeismT.TabIndex = 66
        Me.txtForceSeismT.Text = ""
        Me.txtForceSeismT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblForceSeismT
        '
        Me.lblForceSeismT.BackColor = System.Drawing.SystemColors.Control
        Me.lblForceSeismT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblForceSeismT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblForceSeismT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForceSeismT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblForceSeismT.Location = New System.Drawing.Point(304, 200)
        Me.lblForceSeismT.Name = "lblForceSeismT"
        Me.lblForceSeismT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblForceSeismT.Size = New System.Drawing.Size(104, 24)
        Me.lblForceSeismT.TabIndex = 65
        Me.lblForceSeismT.Text = "Horizontal force"
        Me.lblForceSeismT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PagCarichifinaliT
        '
        Me.PagCarichifinaliT.Controls.Add(Me.Label26)
        Me.PagCarichifinaliT.Controls.Add(Me.Label27)
        Me.PagCarichifinaliT.Controls.Add(Me.dgCarFondT)
        Me.PagCarichifinaliT.Location = New System.Drawing.Point(4, 22)
        Me.PagCarichifinaliT.Name = "PagCarichifinaliT"
        Me.PagCarichifinaliT.Size = New System.Drawing.Size(560, 334)
        Me.PagCarichifinaliT.TabIndex = 1
        Me.PagCarichifinaliT.Text = "Carichi totali trasmessi all'item inferiore"
        Me.PagCarichifinaliT.Visible = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label26.Location = New System.Drawing.Point(360, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(192, 24)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Btm item sliding saddle's roof"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label27.Location = New System.Drawing.Point(168, 8)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(192, 24)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "Btm item fixed saddle's roof"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgCarFondT
        '
        Me.dgCarFondT.CaptionVisible = False
        Me.dgCarFondT.DataMember = ""
        Me.dgCarFondT.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCarFondT.Location = New System.Drawing.Point(8, 32)
        Me.dgCarFondT.Name = "dgCarFondT"
        Me.dgCarFondT.Size = New System.Drawing.Size(546, 296)
        Me.dgCarFondT.TabIndex = 0
        '
        'PagCalcMantT
        '
        Me.PagCalcMantT.Controls.Add(Me.TabTensMantUp)
        Me.PagCalcMantT.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcMantT.Name = "PagCalcMantT"
        Me.PagCalcMantT.Size = New System.Drawing.Size(608, 422)
        Me.PagCalcMantT.TabIndex = 2
        Me.PagCalcMantT.Text = "Tensioni sul mantello"
        Me.PagCalcMantT.Visible = False
        '
        'TabTensMantUp
        '
        Me.TabTensMantUp.Controls.Add(Me.PagCalcMantProgT)
        Me.TabTensMantUp.Controls.Add(Me.PagCalcMantDimT)
        Me.TabTensMantUp.Location = New System.Drawing.Point(4, 7)
        Me.TabTensMantUp.Name = "TabTensMantUp"
        Me.TabTensMantUp.SelectedIndex = 0
        Me.TabTensMantUp.Size = New System.Drawing.Size(600, 408)
        Me.TabTensMantUp.TabIndex = 1
        '
        'PagCalcMantProgT
        '
        Me.PagCalcMantProgT.Controls.Add(Me.cmdAmmissT)
        Me.PagCalcMantProgT.Controls.Add(Me.cmdMatT)
        Me.PagCalcMantProgT.Controls.Add(Me._Text2T_0)
        Me.PagCalcMantProgT.Controls.Add(Me._Combo2T_0)
        Me.PagCalcMantProgT.Controls.Add(Me._Text1T_0)
        Me.PagCalcMantProgT.Controls.Add(Me._Combo1T_0)
        Me.PagCalcMantProgT.Controls.Add(Me._Label2T_0)
        Me.PagCalcMantProgT.Controls.Add(Me._Label1T_0)
        Me.PagCalcMantProgT.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcMantProgT.Name = "PagCalcMantProgT"
        Me.PagCalcMantProgT.Size = New System.Drawing.Size(592, 382)
        Me.PagCalcMantProgT.TabIndex = 0
        Me.PagCalcMantProgT.Text = "Dati di progetto"
        '
        'cmdAmmissT
        '
        Me.cmdAmmissT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAmmissT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAmmissT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAmmissT.Image = CType(resources.GetObject("cmdAmmissT.Image"), System.Drawing.Image)
        Me.cmdAmmissT.Location = New System.Drawing.Point(353, 229)
        Me.cmdAmmissT.Name = "cmdAmmissT"
        Me.cmdAmmissT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAmmissT.Size = New System.Drawing.Size(21, 21)
        Me.cmdAmmissT.TabIndex = 58
        Me.cmdAmmissT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAmmissT.Visible = False
        '
        'cmdMatT
        '
        Me.cmdMatT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMatT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMatT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMatT.Image = CType(resources.GetObject("cmdMatT.Image"), System.Drawing.Image)
        Me.cmdMatT.Location = New System.Drawing.Point(353, 197)
        Me.cmdMatT.Name = "cmdMatT"
        Me.cmdMatT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMatT.Size = New System.Drawing.Size(21, 21)
        Me.cmdMatT.TabIndex = 57
        Me.cmdMatT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdMatT.Visible = False
        '
        '_Text2T_0
        '
        Me._Text2T_0.AcceptsReturn = True
        Me._Text2T_0.AutoSize = False
        Me._Text2T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text2T_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2T_0.Enabled = False
        Me._Text2T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text2T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2T_0.Location = New System.Drawing.Point(353, 157)
        Me._Text2T_0.MaxLength = 0
        Me._Text2T_0.Name = "_Text2T_0"
        Me._Text2T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2T_0.Size = New System.Drawing.Size(71, 21)
        Me._Text2T_0.TabIndex = 56
        Me._Text2T_0.Text = ""
        Me._Text2T_0.Visible = False
        '
        '_Combo2T_0
        '
        Me._Combo2T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo2T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo2T_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo2T_0.Enabled = False
        Me._Combo2T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo2T_0.Location = New System.Drawing.Point(121, 133)
        Me._Combo2T_0.Name = "_Combo2T_0"
        Me._Combo2T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo2T_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo2T_0.TabIndex = 54
        Me._Combo2T_0.TabStop = False
        Me._Combo2T_0.Visible = False
        '
        '_Text1T_0
        '
        Me._Text1T_0.AcceptsReturn = True
        Me._Text1T_0.AutoSize = False
        Me._Text1T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1T_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1T_0.Enabled = False
        Me._Text1T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text1T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1T_0.Location = New System.Drawing.Point(441, 157)
        Me._Text1T_0.MaxLength = 0
        Me._Text1T_0.Multiline = True
        Me._Text1T_0.Name = "_Text1T_0"
        Me._Text1T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1T_0.Size = New System.Drawing.Size(71, 21)
        Me._Text1T_0.TabIndex = 52
        Me._Text1T_0.Text = ""
        Me._Text1T_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1T_0.Visible = False
        '
        '_Combo1T_0
        '
        Me._Combo1T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1T_0.Enabled = False
        Me._Combo1T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1T_0.Location = New System.Drawing.Point(441, 133)
        Me._Combo1T_0.Name = "_Combo1T_0"
        Me._Combo1T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1T_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo1T_0.TabIndex = 51
        Me._Combo1T_0.TabStop = False
        Me._Combo1T_0.Visible = False
        '
        '_Label2T_0
        '
        Me._Label2T_0.BackColor = System.Drawing.Color.Cyan
        Me._Label2T_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2T_0.Enabled = False
        Me._Label2T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label2T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label2T_0.Location = New System.Drawing.Point(465, 197)
        Me._Label2T_0.Name = "_Label2T_0"
        Me._Label2T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2T_0.Size = New System.Drawing.Size(46, 21)
        Me._Label2T_0.TabIndex = 55
        Me._Label2T_0.Visible = False
        '
        '_Label1T_0
        '
        Me._Label1T_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1T_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1T_0.Enabled = False
        Me._Label1T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1T_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1T_0.Location = New System.Drawing.Point(81, 197)
        Me._Label1T_0.Name = "_Label1T_0"
        Me._Label1T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1T_0.Size = New System.Drawing.Size(256, 21)
        Me._Label1T_0.TabIndex = 53
        Me._Label1T_0.Text = "Label1"
        Me._Label1T_0.Visible = False
        '
        'PagCalcMantDimT
        '
        Me.PagCalcMantDimT.Controls.Add(Me._Text41T_0)
        Me.PagCalcMantDimT.Controls.Add(Me._Label42T_0)
        Me.PagCalcMantDimT.Controls.Add(Me._Label41T_0)
        Me.PagCalcMantDimT.Controls.Add(Me.cmdCalcMantT)
        Me.PagCalcMantDimT.Controls.Add(Me._Check1T_0)
        Me.PagCalcMantDimT.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcMantDimT.Name = "PagCalcMantDimT"
        Me.PagCalcMantDimT.Size = New System.Drawing.Size(592, 382)
        Me.PagCalcMantDimT.TabIndex = 1
        Me.PagCalcMantDimT.Text = "Dimensioni"
        Me.PagCalcMantDimT.Visible = False
        '
        '_Text41T_0
        '
        Me._Text41T_0.AcceptsReturn = True
        Me._Text41T_0.AutoSize = False
        Me._Text41T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text41T_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text41T_0.Enabled = False
        Me._Text41T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text41T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text41T_0.Location = New System.Drawing.Point(441, 161)
        Me._Text41T_0.MaxLength = 0
        Me._Text41T_0.Multiline = True
        Me._Text41T_0.Name = "_Text41T_0"
        Me._Text41T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text41T_0.Size = New System.Drawing.Size(71, 21)
        Me._Text41T_0.TabIndex = 56
        Me._Text41T_0.Text = ""
        Me._Text41T_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text41T_0.Visible = False
        '
        '_Label42T_0
        '
        Me._Label42T_0.BackColor = System.Drawing.Color.Cyan
        Me._Label42T_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label42T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label42T_0.Enabled = False
        Me._Label42T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label42T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label42T_0.Location = New System.Drawing.Point(465, 201)
        Me._Label42T_0.Name = "_Label42T_0"
        Me._Label42T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label42T_0.Size = New System.Drawing.Size(46, 21)
        Me._Label42T_0.TabIndex = 58
        Me._Label42T_0.Visible = False
        '
        '_Label41T_0
        '
        Me._Label41T_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label41T_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label41T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label41T_0.Enabled = False
        Me._Label41T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label41T_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label41T_0.Location = New System.Drawing.Point(81, 201)
        Me._Label41T_0.Name = "_Label41T_0"
        Me._Label41T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label41T_0.Size = New System.Drawing.Size(256, 21)
        Me._Label41T_0.TabIndex = 57
        Me._Label41T_0.Text = "Label1"
        Me._Label41T_0.Visible = False
        '
        'cmdCalcMantT
        '
        Me.cmdCalcMantT.Location = New System.Drawing.Point(448, 327)
        Me.cmdCalcMantT.Name = "cmdCalcMantT"
        Me.cmdCalcMantT.Size = New System.Drawing.Size(56, 24)
        Me.cmdCalcMantT.TabIndex = 54
        Me.cmdCalcMantT.Text = "Calcola"
        '
        '_Check1T_0
        '
        Me._Check1T_0.BackColor = System.Drawing.SystemColors.Control
        Me._Check1T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Check1T_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1T_0.Location = New System.Drawing.Point(88, 31)
        Me._Check1T_0.Name = "_Check1T_0"
        Me._Check1T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1T_0.Size = New System.Drawing.Size(169, 17)
        Me._Check1T_0.TabIndex = 53
        Me._Check1T_0.Text = "Reinforcing Ring"
        Me._Check1T_0.Visible = False
        '
        'PagCalcSelleT
        '
        Me.PagCalcSelleT.Controls.Add(Me.cmdCalcMant5T)
        Me.PagCalcSelleT.Controls.Add(Me._Text52T_0)
        Me.PagCalcSelleT.Controls.Add(Me._Combo52T_0)
        Me.PagCalcSelleT.Controls.Add(Me._Text51T_0)
        Me.PagCalcSelleT.Controls.Add(Me._Label52T_0)
        Me.PagCalcSelleT.Controls.Add(Me._Label51T_0)
        Me.PagCalcSelleT.Location = New System.Drawing.Point(4, 22)
        Me.PagCalcSelleT.Name = "PagCalcSelleT"
        Me.PagCalcSelleT.Size = New System.Drawing.Size(608, 422)
        Me.PagCalcSelleT.TabIndex = 1
        Me.PagCalcSelleT.Text = "Tensioni nelle selle"
        Me.PagCalcSelleT.Visible = False
        '
        'cmdCalcMant5T
        '
        Me.cmdCalcMant5T.Location = New System.Drawing.Point(464, 283)
        Me.cmdCalcMant5T.Name = "cmdCalcMant5T"
        Me.cmdCalcMant5T.Size = New System.Drawing.Size(56, 24)
        Me.cmdCalcMant5T.TabIndex = 68
        Me.cmdCalcMant5T.Text = "Calcola"
        '
        '_Text52T_0
        '
        Me._Text52T_0.AcceptsReturn = True
        Me._Text52T_0.AutoSize = False
        Me._Text52T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text52T_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text52T_0.Enabled = False
        Me._Text52T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text52T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text52T_0.Location = New System.Drawing.Point(365, 140)
        Me._Text52T_0.MaxLength = 0
        Me._Text52T_0.Name = "_Text52T_0"
        Me._Text52T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text52T_0.Size = New System.Drawing.Size(71, 21)
        Me._Text52T_0.TabIndex = 67
        Me._Text52T_0.Text = ""
        Me._Text52T_0.Visible = False
        '
        '_Combo52T_0
        '
        Me._Combo52T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo52T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo52T_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo52T_0.Enabled = False
        Me._Combo52T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo52T_0.Location = New System.Drawing.Point(133, 116)
        Me._Combo52T_0.Name = "_Combo52T_0"
        Me._Combo52T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo52T_0.Size = New System.Drawing.Size(71, 21)
        Me._Combo52T_0.TabIndex = 65
        Me._Combo52T_0.TabStop = False
        Me._Combo52T_0.Visible = False
        '
        '_Text51T_0
        '
        Me._Text51T_0.AcceptsReturn = True
        Me._Text51T_0.AutoSize = False
        Me._Text51T_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text51T_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text51T_0.Enabled = False
        Me._Text51T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Text51T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text51T_0.Location = New System.Drawing.Point(453, 140)
        Me._Text51T_0.MaxLength = 0
        Me._Text51T_0.Multiline = True
        Me._Text51T_0.Name = "_Text51T_0"
        Me._Text51T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text51T_0.Size = New System.Drawing.Size(71, 21)
        Me._Text51T_0.TabIndex = 63
        Me._Text51T_0.Text = ""
        Me._Text51T_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text51T_0.Visible = False
        '
        '_Label52T_0
        '
        Me._Label52T_0.BackColor = System.Drawing.Color.Cyan
        Me._Label52T_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label52T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label52T_0.Enabled = False
        Me._Label52T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label52T_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label52T_0.Location = New System.Drawing.Point(477, 180)
        Me._Label52T_0.Name = "_Label52T_0"
        Me._Label52T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label52T_0.Size = New System.Drawing.Size(46, 21)
        Me._Label52T_0.TabIndex = 66
        Me._Label52T_0.Visible = False
        '
        '_Label51T_0
        '
        Me._Label51T_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label51T_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label51T_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label51T_0.Enabled = False
        Me._Label51T_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label51T_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label51T_0.Location = New System.Drawing.Point(93, 180)
        Me._Label51T_0.Name = "_Label51T_0"
        Me._Label51T_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label51T_0.Size = New System.Drawing.Size(256, 21)
        Me._Label51T_0.TabIndex = 64
        Me._Label51T_0.Text = "Label1"
        Me._Label51T_0.Visible = False
        '
        'frmSaddles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(650, 507)
        Me.Controls.Add(Me.TabMain)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(2, 53)
        Me.MaximizeBox = False
        Me.MainMenuStrip = Me.MainMenu1
        Me.Controls.Add(Me.MainMenu1)
        Me.MinimizeBox = False
        Me.Name = "frmSaddles"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BSSD"
        Me.TabPrimoLivDown.ResumeLayout(False)
        Me.PagCarichi.ResumeLayout(False)
        Me.TabCarichiDown.ResumeLayout(False)
        Me.PagDatiGenerali.ResumeLayout(False)
        Me.PagCarichiBocchelli.ResumeLayout(False)
        Me.TabBocchDown.ResumeLayout(False)
        Me.PagListaBocchelli.ResumeLayout(False)
        CType(Me.dgListaBocchelli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagT1.ResumeLayout(False)
        CType(Me.dgCarBocch1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCarichiFondazioni.ResumeLayout(False)
        Me.TabCarFondDown.ResumeLayout(False)
        Me.PagRisultBocchelli.ResumeLayout(False)
        Me.PagSisma.ResumeLayout(False)
        Me.PagVento.ResumeLayout(False)
        Me.PagCarichiDaSopra.ResumeLayout(False)
        CType(Me.dgCarSopra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCarichiFinali.ResumeLayout(False)
        CType(Me.dgCarFond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCombinazioni.ResumeLayout(False)
        Me.TabCombCarDown.ResumeLayout(False)
        Me.PagCombMant.ResumeLayout(False)
        CType(Me.dgElemMant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCombMant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCombSelle.ResumeLayout(False)
        CType(Me.dgElemSadd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCombsadd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCombFonda.ResumeLayout(False)
        CType(Me.dgElemfond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCombfond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCalcMant.ResumeLayout(False)
        Me.TabTensMantDown.ResumeLayout(False)
        Me.PagCalcMantProg.ResumeLayout(False)
        Me.PagCalcMantDim.ResumeLayout(False)
        Me.PagCalcSelle.ResumeLayout(False)
        Me.PagCalcFonda.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.PagDown.ResumeLayout(False)
        Me.PagUp.ResumeLayout(False)
        Me.TabPrimoLivUp.ResumeLayout(False)
        Me.PagCarichiT.ResumeLayout(False)
        Me.TabCarichiUp.ResumeLayout(False)
        Me.PagDatiGeneraliT.ResumeLayout(False)
        Me.PagCarichiBocchelliT.ResumeLayout(False)
        Me.TabBocchUp.ResumeLayout(False)
        Me.PagListaBocchelliT.ResumeLayout(False)
        CType(Me.dgListaBocchelliT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagT1T.ResumeLayout(False)
        CType(Me.dgCarBocchT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCarichiFondazioniT.ResumeLayout(False)
        Me.TabCarFondUp.ResumeLayout(False)
        Me.PagRisultBocchelliT.ResumeLayout(False)
        Me.PagVentoT.ResumeLayout(False)
        Me.PagSismaT.ResumeLayout(False)
        Me.PagCarichifinaliT.ResumeLayout(False)
        CType(Me.dgCarFondT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagCalcMantT.ResumeLayout(False)
        Me.TabTensMantUp.ResumeLayout(False)
        Me.PagCalcMantProgT.ResumeLayout(False)
        Me.PagCalcMantDimT.ResumeLayout(False)
        Me.PagCalcSelleT.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmSaddles
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmSaddles
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmSaddles
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmSaddles)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Friend Label1, Label1T As LabelArray 'descrizione pagina 2
    Friend Label2, Label2T As LabelArray 'unità di misura pagina 2
    Friend Label41, Label41T As LabelArray 'descrizione pagina 4
    Friend Label42, Label42T As LabelArray 'unità di misura pagina 4
    Friend Label3, Label3T As LabelArray 'descrizione pagina 1
    Friend Label51, Label51T As LabelArray 'descrizione pagina 5
    Friend Label52, Label52T As LabelArray 'unità di misura pagina 5
    Friend Label61 As LabelArray 'descrizione pagina 5
    Friend Label62 As LabelArray
    Friend Label4, Label4T As LabelArray 'unità di misura pagina 1
    Friend Text1, Text1T As TextArray
    Friend Text41, Text41T As TextArray
    Friend Text2 As TextArray
    Friend Text51, Text51T As TextArray
    Friend Text52, Text52T As TextArray
    Friend Text61 As TextArray
    Friend Text62 As TextArray
    Friend Text3, Text3T As TextArray
    Friend Combo1 As ComboArray
    Friend Combo2, Combo2T As ComboArray
    Friend Combo52, Combo52T As ComboArray
    Friend Combo62 As ComboArray
    Friend Check1, Check1T As CheckArray
    Friend Codice As String
    Friend tVento, tVentoT As TextArray
    Friend lVento, lVentoT As LabelArray
    Friend lsVento, lsVentoT As LabelArray
    Friend rtfVento, rtfVentoT As rtfArray
    Friend tSisma, tSismaT As TextArray
    Friend lSisma, lSismaT As LabelArray
    Friend lsSisma, lsSismaT As LabelArray
    Friend rtfSisma, rtfSismaT As rtfArray
    Private xv, yv As Single
    Private IndTimer As Short
    Private GiaSotto, GiaSottoT As Boolean
    Private Avanzamento, nFasi As Short
    Private Titoli As String() = {"", "Fx [N]", "Fy [N]", "Fz [N]", "Mx [Nm]", "My [Nm]", "Mz [Nm]"}
    Private Titol1 As String() = {"", "Fx [N]", "Fy [N]", "Fz [N]", "Mx [Nm]", "Fx [N]", "Fy [N]", "Fz [N]", "Mx [Nm]"}
    Private Titol2 As String() = {"", "Fx1", "Fy1", "Fz1", "Mx1", "Fx2", "Fy2", "Fz2", "Mx2"}
    Private Sub Inizializza()
        Label1 = New LabelArray(Me, PagCalcMantProg, "_Label1")
        Label1T = New LabelArray(Me, PagCalcMantProgT, "_Label1T")
        Label2 = New LabelArray(Me, PagCalcMantProg, "_Label2")
        Label2T = New LabelArray(Me, PagCalcMantProgT, "_Label2T")
        Label3 = New LabelArray(Me, PagDatiGenerali, "_Label3")
        Label3T = New LabelArray(Me, PagDatiGeneraliT, "_Label3T")
        Label4 = New LabelArray(Me, PagDatiGenerali, "_Label4")
        Label4T = New LabelArray(Me, PagDatiGeneraliT, "_Label4T")
        Text1 = New TextArray(Me, PagCalcMantProg, "_Text1")
        Text1T = New TextArray(Me, PagCalcMantProgT, "_Text1T")
        Text2 = New TextArray(Me, PagCalcMantProg, "_Text2")
        Text3 = New TextArray(Me, PagDatiGenerali, "_Text3")
        Text3T = New TextArray(Me, PagDatiGeneraliT, "_Text3T")
        Combo1 = New ComboArray(Me, PagCalcMantProg, "_Combo1")
        Combo2 = New ComboArray(Me, PagCalcMantProg, "_Combo2")
        Combo2T = New ComboArray(Me, PagCalcMantProgT, "_Combo2T")
        lVento = New LabelArray(Me, PagVento, "_lblVento")
        lVentoT = New LabelArray(Me, PagVentoT, "_lblVentoT")
        lsVento = New LabelArray(Me, PagVento, "_lblsVento")
        lsVentoT = New LabelArray(Me, PagVentoT, "_lblsVentoT")
        tVento = New TextArray(Me, PagVento, "_txtVento")
        tVentoT = New TextArray(Me, PagVentoT, "_txtVentoT")
        rtfVento = New rtfArray(Me, PagVento, "_rtfVento")
        rtfVentoT = New rtfArray(Me, PagVentoT, "_rtfVentoT")
        lSisma = New LabelArray(Me, PagSisma, "_lblSisma")
        lSismaT = New LabelArray(Me, PagSismaT, "_lblSismaT")
        lsSisma = New LabelArray(Me, PagSisma, "_lblsSisma")
        lsSismaT = New LabelArray(Me, PagSismaT, "_lblsSismaT")
        tSisma = New TextArray(Me, PagSisma, "_txtSisma")
        tSismaT = New TextArray(Me, PagSismaT, "_txtSismaT")
        rtfSisma = New rtfArray(Me, PagSisma, "_rtfSisma")
        rtfSismaT = New rtfArray(Me, PagSismaT, "_rtfSismaT")
        mioContr = New ControlArray
        mioContrT = New ControlArray
        Label41 = New LabelArray(Me, PagCalcMantDim, "_Label41")
        Label41T = New LabelArray(Me, PagCalcMantDimT, "_Label41T")
        Label42 = New LabelArray(Me, PagCalcMantDim, "_Label42")
        Label42T = New LabelArray(Me, PagCalcMantDimT, "_Label42T")
        Text41 = New TextArray(Me, PagCalcMantDim, "_Text41")
        Text41T = New TextArray(Me, PagCalcMantDimT, "_Text41T")
        Check1 = New CheckArray(Me, PagCalcMantDim, "_Check1")
        Check1T = New CheckArray(Me, PagCalcMantDimT, "_Check1T")
        mioContr1 = New ControlArray
        mioContr1T = New ControlArray
        Text51 = New TextArray(Me, PagCalcSelle, "_Text51")
        Text51T = New TextArray(Me, PagCalcSelleT, "_Text51T")
        Text52 = New TextArray(Me, PagCalcSelle, "_Text52")
        Text52T = New TextArray(Me, PagCalcSelleT, "_Text52T")
        Label51 = New LabelArray(Me, PagCalcSelle, "_Label51")
        Label51T = New LabelArray(Me, PagCalcSelleT, "_Label51T")
        Label52 = New LabelArray(Me, PagCalcSelle, "_Label52")
        Label52T = New LabelArray(Me, PagCalcSelleT, "_Label52T")
        Combo52 = New ComboArray(Me, PagCalcSelle, "_Combo52")
        Combo52T = New ComboArray(Me, PagCalcSelleT, "_Combo52T")
        mioContr2 = New ControlArray
        mioContr2T = New ControlArray
        Text61 = New TextArray(Me, PagCalcFonda, "_Text61")
        Text62 = New TextArray(Me, PagCalcFonda, "_Text62")
        Label61 = New LabelArray(Me, PagCalcFonda, "_Label61")
        Label62 = New LabelArray(Me, PagCalcFonda, "_Label62")
        Combo62 = New ComboArray(Me, PagCalcFonda, "_Combo62")
        mioContr3 = New ControlArray
        mioContr3T = New ControlArray
        AddHandler cmdCalcMant.Click, AddressOf Calcola_Click
        AddHandler cmdCalcMant5.Click, AddressOf Calcola_Click
        AddHandler cmdCalcMant6.Click, AddressOf Calcola_Click
        AddHandler cmdCalcMantT.Click, AddressOf CalcolaT_Click
        AddHandler cmdCalcMant5T.Click, AddressOf CalcolaT_Click
        TabMain.DrawMode = TabDrawMode.OwnerDrawFixed
        TabPrimoLivDown.DrawMode = TabDrawMode.OwnerDrawFixed
        TabCarichiDown.DrawMode = TabDrawMode.OwnerDrawFixed
        TabMain.Enabled = False
        TabPrimoLivDown.Enabled = False
        TabCarichiDown.Enabled = False
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub Calcola_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim SaddlesC As Boolean
        Dim Factor, Facto1 As Single
        Dim iCondV, iSaddV As Short
        Dim Res As Boolean
        Dim Forze(5) As Single
        iCondV = iCond : iSaddV = iSadd
        Try
            Select Case iPagina
                Case 1, 2, 3
                    Factor = 0
                    form1 = New frmResultSaddles
                    For iCond = 0 To Problem.NCond(1) - 1
                        SaddlesC = CalcolaSaddles(Facto1, 1)
                        If Not SaddlesC Then Exit For
                        If Facto1 > Factor Then
                            Factor = Facto1
                            iCondMax(1) = iCond
                        End If
                    Next
                    form1.ShowDialog()
                    SaddlesCalcolate = iCond > 0
                Case 4, 5
                    Factor = 0
                    Form3 = New frmFonda
                    For iCond = 0 To Problem.NCond(2) - 1
                        iSadd = 1 : Res = CalcolaSella(Facto1)
                        If Facto1 > Factor Then
                            Factor = Facto1
                            iCondMax(2) = iCond
                        End If
                        If Res Then
                            iSadd = 2 : Res = CalcolaSella(Facto1)
                            SelleCalcolate = True
                            If Facto1 > Factor Then
                                Factor = Facto1
                                iCondMax(2) = iCond
                            End If
                        End If
                    Next
                    Form3.ShowDialog()
                Case 7
                    Factor = 0
                    For iCond = 0 To Problem.NCond(3) - 1
                        For iSadd = 1 To 2
                            Forze(1) = xFondaData(iSadd, iCond).sfx
                            Forze(2) = xFondaData(iSadd, iCond).sfy
                            Forze(3) = xFondaData(iSadd, iCond).n
                            Forze(5) = xFondaData(iSadd, iCond).my
                            Forze(4) = xFondaData(iSadd, iCond).mx
                            If CalcForze(Forze, 3) Then Trasfer3(Forze)
                        Next
                    Next
                    Form3 = New frmFonda
                    For iCond = 0 To Problem.NCond(3) - 1
                        iSadd = 1 : Call CalcolaFonda(Facto1)
                        If Facto1 > Factor Then
                            Factor = Facto1
                            iCondMax(3) = iCond
                        End If
                        iSadd = 2 : Call CalcolaFonda(Facto1)
                        If Facto1 > Factor Then
                            Factor = Facto1
                            iCondMax(3) = iCond
                        End If
                        FondaCalcolate = True
                    Next
                    Form3.ShowDialog()
                    iCond = 0
            End Select
            iSadd = iSaddV : iCond = iCondV
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CalcolaT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim SaddlesC As Boolean
        Dim Factor, Facto1 As Single
        Dim iCondV, iSaddV As Short
        Dim Res As Boolean
        Dim Forze(5) As Single
        iCondV = iCond : iSaddV = iSadd
        Try
            Select Case iPaginaT
                Case 1, 2, 3
                    Factor = 0
                    form1 = New frmResultSaddles
                    For iCond = 0 To Problem.NCond(1) - 1
                        SaddlesC = CalcolaSaddles(Facto1, 2)
                        If Not SaddlesC Then Exit For
                        If Facto1 > Factor Then
                            Factor = Facto1
                            iCondMax(1) = iCond
                        End If
                    Next
                    form1.ShowDialog()
                    SaddlesCalcolateT = iCond > 0
                Case 4, 5
                    Factor = 0
                    Form3 = New frmFonda
                    For iCond = 0 To Problem.NCond(2) - 1
                        iSadd = 1 : Res = CalcolaSella(Facto1)
                        If Facto1 > Factor Then
                            Factor = Facto1
                            iCondMax(2) = iCond
                        End If
                        If Res Then
                            iSadd = 2 : Res = CalcolaSella(Facto1)
                            SelleCalcolateT = True
                            If Facto1 > Factor Then
                                Factor = Facto1
                                iCondMax(2) = iCond
                            End If
                        End If
                    Next
                    Form3.ShowDialog()
            End Select
            iSadd = iSaddV : iCond = iCondV
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Check_CheckStateChanged(ByVal nome As String)
        Dim s() As String = nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "Check1"
                If Problem.Codice = 0 Then
                    MsgBox("Opzione disponibile solo con Stoomwezen", MsgBoxStyle.Information)
                    SaddlesItem.GeomSadd(1).SupRing = False
                    SaddlesItem.GeomSadd(2).SupRing = False
                Else
                    SaddlesItem.GeomSadd(Index - 23).SupRing = (Check1(Index).CheckState = 1)
                End If
                VisRing()
            Case "Check1T"
                If Problem.Codice = 0 Then
                    MsgBox("Opzione disponibile solo con Stoomwezen", MsgBoxStyle.Information)
                    SaddlesItemT.GeomSadd(1).SupRing = False
                    SaddlesItemT.GeomSadd(2).SupRing = False
                Else
                    SaddlesItemT.GeomSadd(Index - 23).SupRing = (Check1T(Index).CheckState = 1)
                End If
                VisRingT()
        End Select
    End Sub
    Private Sub Check2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        xFondaItem(iSadd).Inchiavard = Check2.CheckState = 1
    End Sub
    Public Sub ApplicaCodiceT(ByVal j As Integer)
        Dim i As Short
        i = Problem.Codice
        Problem.Codice = j
        If Problem.Codice = 1 Then
            Problem.NCond(1) = 4
            Problem.LoadCond(1, 1) = "Operating cond. A"
            Problem.LoadCond(1, 2) = "Operating cond. B"
            Problem.LoadCond(1, 3) = "Test condition A"
            Problem.LoadCond(1, 4) = "Test condition B"
            Combo2T(28).SelectedIndex = 0
        Else
            SaddlesItemT.GeomSadd(1).SupRing = False
            SaddlesItemT.GeomSadd(2).SupRing = False
            VisRingT()
        End If
        If i <> Problem.Codice And iPaginaT = 2 Then
            ScaricaT()
            SecondaPaginaT()
        End If
    End Sub
    Public Sub ApplicaCodice(ByVal j As Integer)
        Dim i As Short
        i = Problem.Codice
        Problem.Codice = j
        If Problem.Codice = 1 Then
            Problem.NCond(1) = 4
            Problem.LoadCond(1, 1) = "Operating cond. A"
            Problem.LoadCond(1, 2) = "Operating cond. B"
            Problem.LoadCond(1, 3) = "Test condition A"
            Problem.LoadCond(1, 4) = "Test condition B"
            Combo2(28).SelectedIndex = 0
        Else
            SaddlesItem.GeomSadd(1).SupRing = False
            SaddlesItem.GeomSadd(2).SupRing = False
            VisRing()
        End If
        If i <> Problem.Codice And iPagina = 2 Then
            Scarica()
            SecondaPagina()
        End If
    End Sub
    Private Sub frmSaddles_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Select Case KeyCode
            Case Keys.F1
                Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
        End Select
    End Sub
    Public Sub Combo_TextChanged(ByVal nome As String)
        Dim s() As String = nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim i, j As Short
        Dim Index1 As Short
        Dim iRes As Boolean
        Try
            Select Case Textnum
                Case "Combo2"
                    If Not Combo2(Index).Enabled Then Exit Sub
                    Select Case iPagina
                        Case 2
                            Select Case Index
                                Case 0 'Simple
                                    If Combo2(Index).SelectedIndex = 0 Then
                                        SaddlesLoad(iCond).PesoS(1) = 0 : SaddlesLoad(iCond).PesoS(2) = 0
                                        SaddlesLoad(iCond).MomS(1) = 0 : SaddlesLoad(iCond).MomS(2) = 0
                                        'If SaddlesItem.TipoChius(1) = 0 Then SaddlesItem.TipoChius(1) = 1
                                        'If SaddlesItem.TipoChius(2) = 0 Then SaddlesItem.TipoChius(2) = 1
                                        For i = 4 To 9
                                            Label1(i).Enabled = False : Label2(i).Enabled = False
                                            If i < 8 Then
                                                mioContr(i).Text = "0"
                                            Else
                                                CType(mioContr(i), ComboBox).SelectedIndex = 1
                                            End If
                                            mioContr(i).Enabled = False
                                        Next
                                        SaddlesItem.Simple = "Y"
                                        For i = 23 To Ncontr : Label1(i).Visible = False : Next
                                        Combo2(8).SelectedIndex = 1
                                        Combo2(9).SelectedIndex = 1
                                        Combo2(8).Enabled = False
                                        Combo2(9).Enabled = False
                                    Else
                                        For i = 4 To 9
                                            mioContr(i).Enabled = True
                                            Label1(i).Enabled = True : Label2(i).Enabled = True
                                        Next
                                        SaddlesItem.Simple = "N"
                                        Combo2(8).Enabled = True
                                        Combo2(9).Enabled = True
                                    End If
                                Case 8, 9 'Head
                                    If Combo2(Index).SelectedIndex >= 1 Then 'head
                                        For i = 19 To 20
                                            j = 2 * (Index - 8) + i
                                            mioContr(j).Enabled = True
                                            Label1(j).Enabled = True : Label2(j).Enabled = True
                                        Next
                                        SaddlesItem.TipoChius(Index - 7) = Combo2(Index).SelectedIndex '1 hemi 2 tori
                                        If SaddlesItem.Simple = "N" Then
                                            Label1(23).Visible = True
                                            Label1(24 + Index - 8).Visible = True
                                            Label1(26 + Index - 8).Visible = True
                                        End If
                                    Else
                                        SaddlesLoad(iCond).AmmHead(Index - 7) = 0
                                        SaddlesLoad(iCond).AmmHeadTens(Index - 7) = 0
                                        For i = 19 To 20
                                            j = 2 * (Index - 8) + i
                                            mioContr(j).Enabled = False
                                            Label1(j).Enabled = False : Label2(j).Enabled = False
                                            mioContr(j).Text = "0"
                                        Next
                                        SaddlesItem.TipoChius(Index - 7) = 0
                                        If SaddlesItem.Simple = "N" Then
                                            Label1(24 + Index - 8).Visible = False
                                            Label1(26 + Index - 8).Visible = False
                                            If Index = 8 Then Index1 = 9 Else Index1 = 8
                                            If SaddlesItem.TipoChius(Index1 - 7) = 0 Then Label1(23).Visible = False
                                        End If
                                    End If
                                Case 28
                                    iCond = Combo2(Index).SelectedIndex
                                    If Not CStr(Combo2(Index).Tag) = "-1" Then iRes = ControllaDati1()
                                    Call AggSaddlesPagina()
                                    'Pagina(2).Visible = (iCond = 0)
                                    mioContr(0).Enabled = (iCond = 0)
                                    Label1(0).Enabled = (iCond = 0)
                                    mioContr(8).Enabled = (iCond = 0)
                                    Label1(8).Enabled = (iCond = 0)
                                    mioContr(9).Enabled = (iCond = 0)
                                    Label1(9).Enabled = (iCond = 0)
                                    mioContr(10).Enabled = (iCond = 0)
                                    Label1(10).Enabled = (iCond = 0)
                            End Select
                    End Select
                Case "Combo52"
                    Select Case Index
                        Case 0 : iSadd = Combo52(Index).SelectedIndex + 1
                            iPagina = iSadd + 3
                            '                    Call Scarica
                            '                    Call SellaPagina(Picture1)
                            Call ControllaDati2()
                            Call AggSellaPagina()
                            Text51(2).Focus()
                        Case 1
                            If Combo52(Index).SelectedIndex = 0 Then
                                xSupport(iPagina - 3).Tipo = "C"
                            Else
                                xSupport(iPagina - 3).Tipo = "I"
                            End If
                        Case 27
                            iCond = Combo52(Index).SelectedIndex
                            Call ControllaDati2()
                            Call AggSellaPagina()
                    End Select
                Case "Combo62" 'bulloni fondazione
                    Select Case Index
                        Case 0
                            iCond = Combo62(Index).SelectedIndex
                            Call ControllaDati3()
                            Call AggFondaPagina()
                        Case 23 : iSadd = Combo62(Index).SelectedIndex + 1
                            Call ControllaDati3()
                            Call AggFondaPagina()
                    End Select
                Case "Combo2T"
                    If Not Combo2T(Index).Enabled Then Exit Sub
                    Select Case iPaginaT
                        Case 2
                            Select Case Index
                                Case 0 'Simple
                                    If Combo2T(Index).SelectedIndex = 0 Then
                                        SaddlesLoadT(iCond).PesoS(1) = 0 : SaddlesLoadT(iCond).PesoS(2) = 0
                                        SaddlesLoadT(iCond).MomS(1) = 0 : SaddlesLoadT(iCond).MomS(2) = 0
                                        For i = 4 To 9
                                            Label1T(i).Enabled = False : Label2T(i).Enabled = False
                                            If i < 8 Then
                                                mioContrT(i).Text = "0"
                                            Else
                                                CType(mioContrT(i), ComboBox).SelectedIndex = 1
                                            End If
                                            mioContrT(i).Enabled = False
                                        Next
                                        SaddlesItemT.Simple = "Y"
                                        For i = 23 To Ncontr : Label1T(i).Visible = False : Next
                                        Combo2T(8).SelectedIndex = 1
                                        Combo2T(9).SelectedIndex = 1
                                        Combo2T(8).Enabled = False
                                        Combo2T(9).Enabled = False
                                    Else
                                        For i = 4 To 9
                                            mioContrT(i).Enabled = True
                                            Label1T(i).Enabled = True : Label2T(i).Enabled = True
                                        Next
                                        SaddlesItemT.Simple = "N"
                                        Combo2T(8).Enabled = True
                                        Combo2T(9).Enabled = True
                                    End If
                                Case 8, 9 'Head
                                    If Combo2T(Index).SelectedIndex >= 1 Then 'head
                                        For i = 19 To 20
                                            j = 2 * (Index - 8) + i
                                            mioContrT(j).Enabled = True
                                            Label1T(j).Enabled = True : Label2T(j).Enabled = True
                                        Next
                                        SaddlesItemT.TipoChius(Index - 7) = Combo2T(Index).SelectedIndex '1 hemi 2 tori
                                        If SaddlesItemT.Simple = "N" Then
                                            Label1T(23).Visible = True
                                            Label1T(24 + Index - 8).Visible = True
                                            Label1T(26 + Index - 8).Visible = True
                                        End If
                                    Else
                                        SaddlesLoadT(iCond).AmmHead(Index - 7) = 0
                                        SaddlesLoadT(iCond).AmmHeadTens(Index - 7) = 0
                                        For i = 19 To 20
                                            j = 2 * (Index - 8) + i
                                            mioContrT(j).Enabled = False
                                            Label1T(j).Enabled = False : Label2T(j).Enabled = False
                                            mioContrT(j).Text = "0"
                                        Next
                                        SaddlesItemT.TipoChius(Index - 7) = 0
                                        If SaddlesItemT.Simple = "N" Then
                                            Label1T(24 + Index - 8).Visible = False
                                            Label1T(26 + Index - 8).Visible = False
                                            If Index = 8 Then Index1 = 9 Else Index1 = 8
                                            If SaddlesItemT.TipoChius(Index1 - 7) = 0 Then Label1T(23).Visible = False
                                        End If
                                    End If
                                Case 28
                                    iCond = Combo2T(Index).SelectedIndex
                                    If Not CStr(Combo2T(Index).Tag) = "-1" Then iRes = ControllaDati1T()
                                    Call AggSaddlesPaginaT()
                                    mioContrT(0).Enabled = (iCond = 0)
                                    Label1T(0).Enabled = (iCond = 0)
                                    mioContrT(8).Enabled = (iCond = 0)
                                    Label1T(8).Enabled = (iCond = 0)
                                    mioContrT(9).Enabled = (iCond = 0)
                                    Label1T(9).Enabled = (iCond = 0)
                                    mioContrT(10).Enabled = (iCond = 0)
                                    Label1T(10).Enabled = (iCond = 0)
                            End Select
                    End Select
                Case "Combo52T"
                    Select Case Index
                        Case 0 : iSadd = Combo52T(Index).SelectedIndex + 1
                            iPagina = iSadd + 3
                            Call ControllaDati2T()
                            Call AggSellaPaginaT()
                            Text51T(2).Focus()
                        Case 1
                            If Combo52T(Index).SelectedIndex = 0 Then
                                xSupportT(iPagina - 3).Tipo = "C"
                            Else
                                xSupportT(iPagina - 3).Tipo = "I"
                            End If
                        Case 27
                            iCond = Combo52T(Index).SelectedIndex
                            Call ControllaDati2T()
                            Call AggSellaPaginaT()
                    End Select
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Combo_SelectedIndexChanged(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "Combo2"
                If Not Combo2(Index).Enabled Then Exit Sub
                Select Case Index
                    Case 0, 8, 9, 28 : Call Combo_TextChanged(Nome)
                End Select
            Case "Combo2T"
                If Not Combo2T(Index).Enabled Then Exit Sub
                Select Case Index
                    Case 0, 8, 9, 28 : Call Combo_TextChanged(Nome)
                End Select
            Case "Combo62"
                If Not Combo62(Index).Enabled Then Exit Sub
                Select Case Index
                    Case 0, 23 : Call Combo_TextChanged(Nome)
                End Select
            Case "Combo52", "Combo52T"
                Select Case Index
                    Case 0, 1, 27 : Call Combo_TextChanged(Nome)
                End Select
        End Select
    End Sub
    Private Sub frmSaddles_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        dgSize = TabBocchDown.TabPages(1).Controls(0).Size
        dgLocation = TabBocchDown.TabPages(1).Controls(0).Location
        TabBocchDown.TabPages(1).Controls.RemoveAt(0)
        TabSize = TabBocchDown.TabPages(1).Size
        TabBocchDown.TabPages.RemoveAt(1)
        Picture2.Visible = False
        IniziaLC(False)
        IniziaLCT(False)
        IniziaBocchelli()
        IniziaBocchelliT()
        IniziaVento()
        IniziaSisma()
    End Sub
    Public Sub mnuApri_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.DropDownOpening
        mnuApri_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuApri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.Click
        If Not ChiudiOLE() Then Exit Sub
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        TabCarichiDown.Select()
        If PrimaPagina() Then
            If TabCarichiDown.SelectedIndex = 0 Then
                TabCarichiDown_SelectedIndexChanged(Me, New EventArgs)
            Else
                TabCarichiDown.SelectedIndex = 0
            End If
            Me.pctSimpleComplex.Visible = False
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub mnuExit_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.DropDownOpening
        mnuExit_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
        Monitor.Motore.Ammazza("BSDD")
        Monitor = Nothing
        Dispose()
    End Sub

    Public Sub mnuVerb_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVerb.DropDownOpening
        mnuVerb_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuVerb_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVerb.Click
        mnuVerb.Checked = Not mnuVerb.Checked
        Problem.Verbose = mnuVerb.Checked
    End Sub
    Private Sub CarFonPaginaT()
        Dim i As Integer
        Dim lNcontr As Integer = 14
        Try
            If Text3T.Count > 1 Then Exit Sub
            For i = 0 To lNcontr - 1
                If i > 0 Then
                    Label3T.Load(i)
                    Label4T.Load(i)
                    Text3T.Load(i)
                End If
                Label3T(i).Left = 0
                Label3T(i).Top = i * Label3T(i).Height
                Label3T(i).BringToFront()
                Text3T(i).Left = Label3T(i).Left + Label3T(i).Width
                Label4T(i).Left = Text3T(i).Left + Text3T(i).Width
                Label4T(i).Top = i * Label3T(i).Height
                Text3T(i).Top = i * Label3T(0).Height
                Text3T(i).TabIndex = i
                Text3T(i).Visible = True
                Label3T(i).Visible = True
                Label4T(i).Visible = True
                Text3T(i).Enabled = True
                Select Case i + 1
                    Case 2, 3
                        Label4T(i).Text = "mm"
                    Case 1, 4
                        Label4T(i).Visible = False
                    Case 5 To 8
                        Label4T(i).Text = "N"
                    Case Else
                        Label4T(i).Text = "mm"
                End Select
                Label3T(i).Text = rmHelpStrings.GetString("lblT" & GlobalRoutines.FormatS("0000", i + 1))
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CarFonPagina()
        Dim i As Integer
        Dim lNcontr As Integer = 15
        Try
            If Text3.Count > 1 Then Exit Sub
            For i = 0 To lNcontr - 1
                If i > 0 Then
                    Label3.Load(i)
                    Label4.Load(i)
                    Text3.Load(i)
                End If
                Label3(i).Left = 0
                Label3(i).Top = i * Label3(i).Height
                Label3(i).BringToFront()
                Text3(i).Left = Label3(i).Left + Label3(i).Width
                Label4(i).Left = Text3(i).Left + Text3(i).Width
                Label4(i).Top = i * Label3(i).Height
                Text3(i).Top = i * Label3(0).Height
                Text3(i).TabIndex = i
                Text3(i).Visible = True
                Label3(i).Visible = True
                Label4(i).Visible = True
                Text3(i).Enabled = True
                Select Case i + 1
                    Case 2, 3, 4
                        Label4(i).Text = "mm"
                    Case 1, 5, 6
                        Label4(i).Visible = False
                    Case 7 To 10
                        Label4(i).Text = "N"
                    Case Else
                        Label4(i).Text = "mm"
                End Select
                Label3(i).Text = rmHelpStrings.GetString("lbl" & GlobalRoutines.FormatS("0000", i + 1))
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggFonPaginaT()
        Dim i As Integer
        Text3T(0).Text = SaddlesItemT.Item
        Text3T(1).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.CGdistFromFixed)
        Text3T(2).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.CGHeight)
        Text3T(3).Text = GlobalRoutines.FormatS(FormSng2, SaddlesItemT.bundlefactor)
        For i = 0 To 3
            Text3T(4 + i).Text = GlobalRoutines.FormatS(FormSng0, LoadFoundDataT.Pesi(i))
        Next
        Text3T(8).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.bundleCGheight)
        Text3T(9).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.VesselOD)
        Text3T(10).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.InsulThk)
        Text3T(11).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.VesselLength)
        Text3T(12).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.EquivVesselOD)
        Text3T(12).BackColor = Color.LightYellow
        Text3T(13).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.Heightbtwsaddles)
    End Sub
    Private Sub AggFonPagina()
        Dim i As Integer
        Text3(0).Text = SaddlesItem.Item
        Text3(1).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.Lungh(0))
        Text3(2).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.CGdistFromFixed)
        Text3(3).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.CGHeight)
        Text3(4).Text = GlobalRoutines.FormatS(FormSng2, SaddlesItem.frictionfactor)
        Text3(5).Text = GlobalRoutines.FormatS(FormSng2, SaddlesItem.bundlefactor)
        For i = 0 To 3
            Text3(6 + i).Text = GlobalRoutines.FormatS(FormSng0, LoadFoundData.Pesi(i))
        Next
        Text3(10).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.bundleCGheight)
        Text3(11).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.VesselOD)
        Text3(12).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.InsulThk)
        Text3(13).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.VesselLength)
        Text3(14).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.EquivVesselOD)
        Text3(14).BackColor = Color.LightYellow
    End Sub
    Private Function datiprogetto() As Boolean
        If Not ChiudiOLE() Then Exit Function
        iPagina = 2
        Call SecondaPagina()
        Dim iRes As Boolean = ControllaDati1()
        Call AggSaddlesPagina()
    End Function
    Private Function datiprogettoT() As Boolean
        If Not ChiudiOLET() Then Exit Function
        iPaginaT = 2
        Call SecondaPaginaT()
        Dim iRes As Boolean = ControllaDati1T()
        Call AggSaddlesPaginaT()
    End Function
    Private Function dimensioni() As Boolean
        If Not ChiudiOLE() Then Exit Function
        iPagina = 3
        Call QuartaPagina()
        Call AggQuartaPagina()
    End Function
    Private Function dimensioniT() As Boolean
        If Not ChiudiOLET() Then Exit Function
        iPaginaT = 3
        Call QuartaPaginaT()
        Call AggQuartaPaginaT()
    End Function
    Private Function datisella() As Boolean
        If Not ChiudiOLE() Then Exit Function
        iSadd = 1 : iCond = 0
        iPagina = 3 + iSadd
        Call ControllaDati2()
        Call SellaPagina()
        Call AggSellaPagina()
    End Function
    Private Function datisellaT() As Boolean
        If Not ChiudiOLET() Then Exit Function
        iSadd = 1 : iCond = 0
        iPagina = 3 + iSadd
        Call ControllaDati2T()
        Call SellaPaginaT()
        Call AggSellaPaginaT()
    End Function
    Private Function tirafondi() As Boolean
        If Not ChiudiOLE() Then Exit Function
        iSadd = 1 : iCond = 0
        iPagina = 7
        'Call Scarica()
        Call ControllaDati3()
        iSadd = 2 : ControllaDati3()
        iSadd = 1
        Call FondaPagina()
        Call AggFondaPagina()
    End Function
    Private Function ChiudiOLE() As Boolean
        If iPagina <> 6 Then Return True
        If iSottoPagina = 1 Then 'carichi sui bocchelli
            If iSottoSottoPagina = 0 Then
                invIniziaBocchelli()
                CalcolaRisultante()
            End If
        ElseIf iSottoPagina = 2 Then 'carichi sulle fondazioni
            Dim i As Integer
            For i = iSottoSottoPagina + 1 To 3
                TabCarFondDown.SelectedIndex = i
            Next
        ElseIf iSottoPagina = 3 Then ' combinazioni
            invTrasfLCtoTable(iSottoSottoPagina)
            iSottoSottoPagina = 0
        End If
        Return True
    End Function
    Private Function ChiudiOLET() As Boolean
        If iPaginaT <> 6 Then Return True
        If iSottoPaginaT = 1 Then 'carichi sui bocchelli
            If iSottoSottoPaginaT = 0 Then
                invIniziaBocchelliT()
                CalcolaRisultanteT()
            End If
        ElseIf iSottoPaginaT = 2 Then 'carichi sulle fondazioni
            Dim i As Integer
            For i = iSottoSottoPaginaT + 1 To 3
                TabCarFondUp.SelectedIndex = i
            Next
        End If
        Return True
    End Function
    Public Sub Text_Changed(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "txtVento"
                If Inizializzando Then Exit Sub
                Problem.ParamV(Index) = GlobalRoutines.ValVir(tVento(Index).Text)
                Problem.ParamV(Index) = GlobalRoutines.ValVir(tVento(Index).Text)
                RicalcolaVento()
            Case "txtSisma"
                If Inizializzando Then Exit Sub
                Problem.ParamS(Index) = GlobalRoutines.ValVir(tSisma(Index).Text)
                Problem.ParamS(Index) = GlobalRoutines.ValVir(tSisma(Index).Text)
                RicalcolaSisma()
            Case "txtVentoT"
                If Inizializzando Then Exit Sub
                Problem.ParamV(Index) = GlobalRoutines.ValVir(tVentoT(Index).Text)
                Problem.ParamV(Index) = GlobalRoutines.ValVir(tVentoT(Index).Text)
                RicalcolaVentoT()
            Case "txtSisma"
                If Inizializzando Then Exit Sub
                Problem.ParamS(Index) = GlobalRoutines.ValVir(tSismaT(Index).Text)
                Problem.ParamS(Index) = GlobalRoutines.ValVir(tSismaT(Index).Text)
                RicalcolaSismaT()
        End Select
    End Sub
    Public Sub Text_Leave(ByVal Nome As String)
        Dim j, k As Short
        Dim Msgg As String
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim Valore As Single
        Select Case Textnum
            Case "Text1"
                Valore = GlobalRoutines.ValVir(Text1(Index).Text)
                Select Case iPagina
                    Case 2
                        Select Case Index
                            Case 1 : SaddlesLoad(iCond).DesPress = Valore
                            Case 2 : SaddlesLoad(iCond).DesTemp = Valore
                            Case 3 : SaddlesLoad(iCond).PesoTot = Valore
                            Case 4, 5 : SaddlesLoad(iCond).PesoS(Index - 3) = Valore
                            Case 6, 7 : SaddlesLoad(iCond).MomS(Index - 5) = Valore
                            Case 11
                                SaddlesLoad(iCond).AmmShell(Index - 11) = Valore
                                For j = 1 To 2
                                    If SaddlesLoad(iCond).AmmShell(j) = 0 Then
                                        Text1(Index + j).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmShell(0), 5, 2, 0)
                                        SaddlesLoad(iCond).AmmShell(j) = GlobalRoutines.ValVir(Text1(Index + j).Text)
                                    End If
                                Next
                            Case 12, 13
                                SaddlesLoad(iCond).AmmShell(Index - 11) = Valore
                            Case 14
                                SaddlesLoad(iCond).Young(Index - 14) = Valore
                                For j = 1 To 2
                                    If SaddlesLoad(iCond).Young(j) = 0 Then
                                        Text1(Index + j).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).Young(0), 5, 2, 0)
                                        SaddlesLoad(iCond).Young(j) = GlobalRoutines.ValVir(Text1(Index + j).Text)
                                    End If
                                Next
                            Case 15, 16
                                SaddlesLoad(iCond).Young(Index - 14) = Valore
                            Case 17 : SaddlesLoad(iCond).AmmSadd(Index - 16) = Valore
                                If SaddlesLoad(iCond).AmmSadd(2) = 0 Then
                                    SaddlesLoad(iCond).AmmSadd(2) = SaddlesLoad(iCond).AmmSadd(1)
                                    Text1(18).Text = Text1(17).Text
                                End If
                            Case 18 : SaddlesLoad(iCond).AmmSadd(Index - 16) = Valore
                            Case 19 : SaddlesLoad(iCond).AmmHead(1) = Valore
                                SaddlesLoad(iCond).AmmHeadTens(1) = Calc352(SaddlesLoad(iCond), 1, SaddlesItem)
                                Text1(20).Enabled = False
                                Text1(20).Text = GlobalRoutines.FormatS(FormSng2, SaddlesLoad(iCond).AmmHeadTens(1))
                                Text1(20).Enabled = True
                                If SaddlesLoad(iCond).AmmHead(2) = 0 Then
                                    SaddlesLoad(iCond).AmmHead(2) = SaddlesLoad(iCond).AmmHead(1)
                                    SaddlesLoad(iCond).AmmHeadTens(2) = Calc352(SaddlesLoad(iCond), 2, SaddlesItem)
                                    Text1(21).Text = Text1(19).Text
                                    Text1(22).Text = Text1(20).Text
                                End If
                            Case 20 : SaddlesLoad(iCond).AmmHeadTens(1) = Valore
                                If SaddlesLoad(iCond).AmmHeadTens(2) = 0 Then
                                    SaddlesLoad(iCond).AmmHeadTens(2) = SaddlesLoad(iCond).AmmHeadTens(1)
                                    Text1(22).Enabled = False
                                    Text1(22).Text = Text1(20).Text
                                    Text1(22).Enabled = True
                                End If
                            Case 21 : SaddlesLoad(iCond).AmmHead(2) = Valore
                                SaddlesLoad(iCond).AmmHeadTens(2) = Calc352(SaddlesLoad(iCond), 2, SaddlesItem)
                                Text1(22).Enabled = False
                                Text1(22).Text = GlobalRoutines.FormatS(FormSng2, SaddlesLoad(iCond).AmmHeadTens(2))
                                Text1(22).Enabled = True
                            Case 22 : SaddlesLoad(iCond).AmmHeadTens(2) = Valore
                        End Select
                End Select
            Case "Text41"
                Valore = GlobalRoutines.ValVir(Text41(Index).Text)
                Select Case Index
                    Case 0 : SaddlesItem.Diam = Valore
                    Case 1, 2, 3 : SaddlesItem.Spess(Index - 1) = Valore
                    Case 4, 5, 6 : SaddlesItem.Lungh(Index - 4) = Valore
                    Case 7 : SaddlesItem.GeomSadd(1).AxialWidth = Valore
                        If SaddlesItem.GeomSadd(2).AxialWidth = 0 Then
                            SaddlesItem.GeomSadd(2).AxialWidth = Valore
                            Text41(Index).Text = GlobalRoutines.myStr(Valore, 5, 2, 0)
                        End If
                    Case 8 : SaddlesItem.GeomSadd(2).AxialWidth = Valore
                    Case 9, 10 : SaddlesItem.GeomSadd(Index - 8).IncluAngle = Valore
                        If SaddlesItem.GeomSadd(Index - 8).IncluAngle < 120 Or SaddlesItem.GeomSadd(Index - 8).IncluAngle > 165 Then
                            Msgg = "L'angolo al centro impostato (" & Str(SaddlesItem.GeomSadd(Index - 8).IncluAngle) & ") non rientra" & vbCrLf
                            Msgg = Msgg & "nei limiti raccomandati da G.3.3.2"
                            MsgBox(Msgg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly)
                        End If
                    Case 11, 12 : SaddlesItem.GeomSadd(Index - 10).PlateWidth = Valore
                    Case 13, 14 : SaddlesItem.GeomSadd(Index - 12).PlateAngle = Valore
                    Case 15, 16 : SaddlesItem.GeomSadd(Index - 14).PlateThk = Valore
                    Case 17, 18 : SaddlesItem.GeomSadd(Index - 16).SaddlThk = Valore
                    Case 19, 20 : SaddlesItem.GeomSadd(Index - 18).SaddHeight = Valore
                    Case 21, 22 : SaddlesItem.SpessHead(Index - 20) = Valore
                    Case 23 : SaddlesItem.HeadHeight = Valore
                    Case 26, 27 : SaddlesItem.GeomSadd(Index - 25).Ix = Valore
                    Case 28, 29 : SaddlesItem.GeomSadd(Index - 27).rCrown = Valore
                    Case 30, 31 : SaddlesItem.GeomSadd(Index - 29).rBottom = Valore
                    Case 32, 33 : SaddlesItem.GeomSadd(Index - 31).Ax = Valore
                End Select
            Case "Text51"
                Valore = GlobalRoutines.ValVir(Text51(Index).Text)
                Select Case Index
                    Case 2
                        If xSupport(iSadd).NumeroRibs <> Valore Then
                            xSupport(iSadd).NumeroRibs = Valore
                            IndTimer = 2
                            Timer1.Enabled = True
                        End If
                    Case 3 : xSupport(iSadd).SaddlLength = Valore
                    Case 4 : xSupport(iSadd).SaddlWidth = Valore
                    Case 5 : xSupport(iSadd).SaddlThk = Valore
                    Case 6 : xSupport(iSadd).RibsThk = Valore
                    Case 7 : xSupport(iSadd).material = Text51(Index).Text
                    Case 8 : xSupportData(iSadd, iCond).Allow = Valore
                    Case 9 : xSupportData(iSadd, iCond).NormalForce = Valore
                    Case 10 : xSupportData(iSadd, iCond).ShearLong = Valore
                    Case 11 : xSupportData(iSadd, iCond).ShearTrasv = Valore
                    Case 12 : xSupportData(iSadd, iCond).MomLong = Valore
                    Case 13 : xSupportData(iSadd, iCond).MomTrasv = Valore
                    Case 14 : xSupportData(iSadd, iCond).MomTorc = Valore
                    Case 15 To 21 : xSupport(iSadd).Dist(Index - 14) = Valore
                End Select
            Case "Text61"
                Valore = GlobalRoutines.ValVir(Text61(Index).Text)
                Select Case Index
                    Case 1 : xFondaItem(iSadd).a = Valore
                    Case 2 : xFondaItem(iSadd).b = Valore
                    Case 3 : xFondaItem(iSadd).SP = Valore
                        ' Case 4: xFondaItem(iSadd).h = Valore
                    Case 4 : xFondaItem(iSadd).A1 = Valore
                    Case 5 : xFondaItem(iSadd).B1 = Valore
                    Case 6 : xFondaItem(iSadd).nc = Valore
                    Case 7
                        If xFondaItem(iSadd).nt <> Valore Then
                            xFondaItem(iSadd).nt = Valore
                            If xFondaItem(iSadd).nt < 1 Or xFondaItem(iSadd).nt > 16 Then
                                Msgg = "Numero di bulloni non permesso." & vbCrLf
                                Msgg = Msgg & "(minimo 1, massimo 16)"
                                MsgBox(Msgg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly)
                                xFondaItem(iSadd).nt = 4
                            End If
                            IndTimer = 7
                            Timer1.Enabled = True
                        End If
                    Case 9 : xFondaItem(iSadd).ag = GlobalRoutines.FormatS(FormSng2, GlobalRoutines.ValVir(Text61(Index).Text))
                    Case 10 : xFondaItem(iSadd).an = GlobalRoutines.FormatS(FormSng2, GlobalRoutines.ValVir(Text61(Index).Text))
                    Case 12 : xFondaData(iSadd, iCond).albp = Valore
                    Case 14 : xFondaData(iSadd, iCond).alb = Valore
                    Case 15 : xFondaData(iSadd, iCond).albs = Valore
                    Case 16 : xFondaData(iSadd, iCond).alc = Valore
                    Case 17 : xFondaItem(iSadd).Rm = Valore
                    Case 18 : xFondaData(iSadd, iCond).n = Valore
                    Case 19 : xFondaData(iSadd, iCond).mx = Valore
                    Case 20 : xFondaData(iSadd, iCond).sfx = Valore
                    Case 21 : xFondaData(iSadd, iCond).my = Valore
                    Case 22 : xFondaData(iSadd, iCond).sfy = Valore
                    Case 25 To 25 + xFondaItem(iSadd).nt * 2 - 1
                        j = Index - 24
                        k = j Mod 2
                        j = (Index - 23) \ 2
                        If k = 1 Then
                            xFondaItem(iSadd).xQuota(j) = Valore
                        Else
                            xFondaItem(iSadd).yQuota(j) = Valore
                        End If
                End Select
            Case "Text62"
                Select Case Index
                    Case 8 : xFondaItem(iSadd).BoltSize = Text62(Index).Text
                    Case 11 : xFondaItem(iSadd).BaseMat = Text62(Index).Text
                    Case 13 : xFondaItem(iSadd).BoltMat = Text62(Index).Text
                End Select
            Case "Text1T"
                Valore = GlobalRoutines.ValVir(Text1T(Index).Text)
                Select Case iPaginaT
                    Case 2
                        Select Case Index
                            Case 1 : SaddlesLoadT(iCond).DesPress = Valore
                            Case 2 : SaddlesLoadT(iCond).DesTemp = Valore
                            Case 3 : SaddlesLoadT(iCond).PesoTot = Valore
                            Case 4, 5 : SaddlesLoadT(iCond).PesoS(Index - 3) = Valore
                            Case 6, 7 : SaddlesLoadT(iCond).MomS(Index - 5) = Valore
                            Case 11
                                SaddlesLoadT(iCond).AmmShell(Index - 11) = Valore
                                For j = 1 To 2
                                    If SaddlesLoadT(iCond).AmmShell(j) = 0 Then
                                        Text1T(Index + j).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmShell(0), 5, 2, 0)
                                        SaddlesLoadT(iCond).AmmShell(j) = GlobalRoutines.ValVir(Text1T(Index + j).Text)
                                    End If
                                Next
                            Case 12, 13
                                SaddlesLoadT(iCond).AmmShell(Index - 11) = Valore
                            Case 14
                                SaddlesLoadT(iCond).Young(Index - 14) = Valore
                                For j = 1 To 2
                                    If SaddlesLoadT(iCond).Young(j) = 0 Then
                                        Text1T(Index + j).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).Young(0), 5, 2, 0)
                                        SaddlesLoadT(iCond).Young(j) = GlobalRoutines.ValVir(Text1T(Index + j).Text)
                                    End If
                                Next
                            Case 15, 16
                                SaddlesLoadT(iCond).Young(Index - 14) = Valore
                            Case 17 : SaddlesLoadT(iCond).AmmSadd(Index - 16) = Valore
                                If SaddlesLoadT(iCond).AmmSadd(2) = 0 Then
                                    SaddlesLoadT(iCond).AmmSadd(2) = SaddlesLoadT(iCond).AmmSadd(1)
                                    Text1T(18).Text = Text1T(17).Text
                                End If
                            Case 18 : SaddlesLoadT(iCond).AmmSadd(Index - 16) = Valore
                            Case 19 : SaddlesLoadT(iCond).AmmHead(1) = Valore
                                SaddlesLoadT(iCond).AmmHeadTens(1) = Calc352(SaddlesLoadT(iCond), 1, SaddlesItemT)
                                Text1T(20).Enabled = False
                                Text1T(20).Text = GlobalRoutines.FormatS(FormSng2, SaddlesLoadT(iCond).AmmHeadTens(1))
                                Text1T(20).Enabled = True
                                If SaddlesLoadT(iCond).AmmHead(2) = 0 Then
                                    SaddlesLoadT(iCond).AmmHead(2) = SaddlesLoadT(iCond).AmmHead(1)
                                    SaddlesLoadT(iCond).AmmHeadTens(2) = Calc352(SaddlesLoadT(iCond), 2, SaddlesItemT)
                                    Text1T(21).Text = Text1T(19).Text
                                    Text1T(22).Text = Text1T(20).Text
                                End If
                            Case 20 : SaddlesLoadT(iCond).AmmHeadTens(1) = Valore
                                If SaddlesLoadT(iCond).AmmHeadTens(2) = 0 Then
                                    SaddlesLoadT(iCond).AmmHeadTens(2) = SaddlesLoadT(iCond).AmmHeadTens(1)
                                    Text1T(22).Enabled = False
                                    Text1T(22).Text = Text1T(20).Text
                                    Text1T(22).Enabled = True
                                End If
                            Case 21 : SaddlesLoadT(iCond).AmmHead(2) = Valore
                                SaddlesLoadT(iCond).AmmHeadTens(2) = Calc352(SaddlesLoadT(iCond), 2, SaddlesItemT)
                                Text1T(22).Enabled = False
                                Text1T(22).Text = GlobalRoutines.FormatS(FormSng2, SaddlesLoadT(iCond).AmmHeadTens(2))
                                Text1T(22).Enabled = True
                            Case 22 : SaddlesLoadT(iCond).AmmHeadTens(2) = Valore
                        End Select
                End Select
            Case "Text41T"
                Valore = GlobalRoutines.ValVir(Text41T(Index).Text)
                Select Case Index
                    Case 0 : SaddlesItemT.Diam = Valore
                    Case 1, 2, 3 : SaddlesItemT.Spess(Index - 1) = Valore
                    Case 4, 5, 6 : SaddlesItemT.Lungh(Index - 4) = Valore
                    Case 7, 8 : SaddlesItemT.GeomSadd(Index - 6).AxialWidth = Valore
                    Case 9, 10 : SaddlesItemT.GeomSadd(Index - 8).IncluAngle = Valore
                        If SaddlesItemT.GeomSadd(Index - 8).IncluAngle < 120 Or SaddlesItemT.GeomSadd(Index - 8).IncluAngle > 165 Then
                            Msgg = "L'angolo al centro impostato (" & Str(SaddlesItemT.GeomSadd(Index - 8).IncluAngle) & ") non rientra" & vbCrLf
                            Msgg = Msgg & "nei limiti raccomandati da G.3.3.2"
                            MsgBox(Msgg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly)
                        End If
                    Case 11, 12 : SaddlesItemT.GeomSadd(Index - 10).PlateWidth = Valore
                    Case 13, 14 : SaddlesItemT.GeomSadd(Index - 12).PlateAngle = Valore
                    Case 15, 16 : SaddlesItemT.GeomSadd(Index - 14).PlateThk = Valore
                    Case 17, 18 : SaddlesItemT.GeomSadd(Index - 16).SaddlThk = Valore
                    Case 19, 20 : SaddlesItemT.GeomSadd(Index - 18).SaddHeight = Valore
                    Case 21, 22 : SaddlesItemT.SpessHead(Index - 20) = Valore
                    Case 23 : SaddlesItemT.HeadHeight = Valore
                    Case 26, 27 : SaddlesItemT.GeomSadd(Index - 25).Ix = Valore
                    Case 28, 29 : SaddlesItemT.GeomSadd(Index - 27).rCrown = Valore
                    Case 30, 31 : SaddlesItemT.GeomSadd(Index - 29).rBottom = Valore
                    Case 32, 33 : SaddlesItemT.GeomSadd(Index - 31).Ax = Valore
                End Select
            Case "Text51T"
                Valore = GlobalRoutines.ValVir(Text51T(Index).Text)
                Select Case Index
                    Case 2
                        If xSupportT(iSadd).NumeroRibs <> Valore Then
                            xSupportT(iSadd).NumeroRibs = Valore
                            IndTimer = 12
                            Timer1.Enabled = True
                        End If
                    Case 3 : xSupportT(iSadd).SaddlLength = Valore
                    Case 4 : xSupportT(iSadd).SaddlWidth = Valore
                    Case 5 : xSupportT(iSadd).SaddlThk = Valore
                    Case 6 : xSupportT(iSadd).RibsThk = Valore
                    Case 7 : xSupportT(iSadd).material = Text51T(Index).Text
                    Case 8 : xSupportDataT(iSadd, iCond).Allow = Valore
                    Case 9 : xSupportDataT(iSadd, iCond).NormalForce = Valore
                    Case 10 : xSupportDataT(iSadd, iCond).ShearLong = Valore
                    Case 11 : xSupportDataT(iSadd, iCond).ShearTrasv = Valore
                    Case 12 : xSupportDataT(iSadd, iCond).MomLong = Valore
                    Case 13 : xSupportDataT(iSadd, iCond).MomTrasv = Valore
                    Case 14 : xSupportDataT(iSadd, iCond).MomTorc = Valore
                    Case 15 To 21 : xSupportT(iSadd).Dist(Index - 14) = Valore
                End Select
            Case "Text52"
                Select Case Index
                    Case 7 : xSupport(iSadd).material = Text52(Index).Text
                End Select
            Case "Text52T"
                Select Case Index
                    Case 7 : xSupportT(iSadd).material = Text52T(Index).Text
                End Select
            Case "Text3"
                Dim t As String = Text3(Index).Text
                If t.Length = 0 Then t = "0"
                If Index > 0 Then Valore = GlobalRoutines.ValVir(t)
                Select Case Index
                    Case 0 : SaddlesItem.Item = t
                    Case 1 : SaddlesItem.Lungh(0) = Valore
                    Case 2 : SaddlesItem.CGdistFromFixed = Valore
                    Case 3 : SaddlesItem.CGHeight = Valore
                    Case 4 : SaddlesItem.frictionfactor = Valore
                    Case 5 : SaddlesItem.bundlefactor = Valore
                    Case 6 To 9
                        LoadFoundData.Pesi(Index - 6) = Valore
                    Case 10 : SaddlesItem.bundleCGheight = Valore
                    Case 11 : SaddlesItem.VesselOD = Valore
                        If SaddlesItem.InsulThk > 0 Then
                            SaddlesItem.EquivVesselOD = SaddlesItem.VesselOD + 2 * SaddlesItem.InsulThk
                            Text3(14).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.EquivVesselOD)
                        End If
                    Case 12 : SaddlesItem.InsulThk = Valore
                        If SaddlesItem.VesselOD > 0 Then
                            SaddlesItem.EquivVesselOD = SaddlesItem.VesselOD + 2 * SaddlesItem.InsulThk
                            Text3(14).Text = GlobalRoutines.FormatS(FormInt, SaddlesItem.EquivVesselOD)
                        End If
                    Case 13 : SaddlesItem.VesselLength = Valore
                    Case 14 : SaddlesItem.EquivVesselOD = Valore
                End Select
            Case "Text3T"
                Dim t As String = Text3T(Index).Text
                If t.Length = 0 Then t = "0"
                If Index > 0 Then Valore = GlobalRoutines.ValVir(t)
                Select Case Index
                    Case 0 : SaddlesItemT.Item = t
                    Case 1 : SaddlesItemT.CGdistFromFixed = Valore
                    Case 2 : SaddlesItemT.CGHeight = Valore
                    Case 3 : SaddlesItemT.bundlefactor = Valore
                    Case 4 To 7
                        LoadFoundDataT.Pesi(Index - 4) = Valore
                    Case 8 : SaddlesItemT.bundleCGheight = Valore
                    Case 9 : SaddlesItemT.VesselOD = Valore
                        If SaddlesItemT.InsulThk > 0 Then
                            SaddlesItemT.EquivVesselOD = SaddlesItemT.VesselOD + 2 * SaddlesItemT.InsulThk
                            Text3T(12).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.EquivVesselOD)
                        End If
                    Case 10 : SaddlesItemT.InsulThk = Valore
                        If SaddlesItemT.VesselOD > 0 Then
                            SaddlesItemT.EquivVesselOD = SaddlesItemT.VesselOD + 2 * SaddlesItemT.InsulThk
                            Text3T(12).Text = GlobalRoutines.FormatS(FormInt, SaddlesItemT.EquivVesselOD)
                        End If
                    Case 11 : SaddlesItemT.VesselLength = Valore
                    Case 12 : SaddlesItemT.EquivVesselOD = Valore
                    Case 13 : SaddlesItemT.Heightbtwsaddles = Valore
                End Select
        End Select
    End Sub
    Public Sub Scarica()
        Dim i As Short
        Select Case iPagina
            Case 2
                For i = 1 To mioContr.Count - 1
                    If Not mioContr(i) Is Nothing Then mioContr.UnLoad(1)
                    Label1.UnLoad(1)
                    Label2.UnLoad(1)
                Next
            Case 3
                For i = 1 To mioContr1.Count - 1
                    If Not mioContr1(i) Is Nothing Then mioContr1.UnLoad(1)
                    Label41.UnLoad(1)
                    Label42.UnLoad(1)
                Next
            Case 4, 5
                For i = 1 To mioContr2.Count - 1
                    If Not mioContr2(i) Is Nothing Then mioContr2.UnLoad(1)
                    Label51.UnLoad(1)
                    Label52.UnLoad(1)
                Next
            Case 7
                For i = 1 To mioContr3.Count - 1
                    If Not mioContr3(i) Is Nothing Then mioContr3.UnLoad(1)
                    Label61.UnLoad(1)
                    Label62.UnLoad(1)
                Next
        End Select
        '  Check2.Visible = False
        '  cmdMat.Visible = False
        '  cmdAmmiss.Visible = False
        '  mioContr(0).Enabled = False : mioContr(0).Visible = False
        '  Label1(0).Enabled = False : Label1(0).Visible = False
        '  Label2(0).Enabled = False : Label2(0).Visible = False
    End Sub
    Public Sub ScaricaT()
        Dim i As Short
        Select Case iPaginaT
            Case 2
                For i = 1 To mioContrT.Count - 1
                    If Not mioContrT(i) Is Nothing Then mioContrT.UnLoad(1)
                    Label1T.UnLoad(1)
                    Label2T.UnLoad(1)
                Next
            Case 3
                For i = 1 To mioContr1T.Count - 1
                    If Not mioContr1T(i) Is Nothing Then mioContr1T.UnLoad(1)
                    Label41T.UnLoad(1)
                    Label42T.UnLoad(1)
                Next
            Case 4, 5
                For i = 1 To mioContr2T.Count - 1
                    If Not mioContr2T(i) Is Nothing Then mioContr2T.UnLoad(1)
                    Label51T.UnLoad(1)
                    Label52T.UnLoad(1)
                Next
        End Select
    End Sub
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Select Case IndTimer
            Case 2
                Call Scarica()
                Call ControllaDati2()
                Call SellaPagina()
                Call AggSellaPagina()
            Case 7
                Call Scarica()
                Call ControllaDati3()
                Call FondaPagina()
                Call AggFondaPagina()
            Case 12
                Call ScaricaT()
                Call ControllaDati2T()
                Call SellaPaginaT()
                Call AggSellaPaginaT()
        End Select
    End Sub
    Public Function CalcolaSaddles(ByRef Factor As Single, ByVal iBtmTop As Integer) As Boolean
        Dim Msgg As String
        CalcolaSaddles = True
        Dim i As Short
        Dim SIGMAC, SIGMAT, Facto1 As Single
        '-----------------------Start of the calculations-----------
        If Not Geom(iBtmTop) Then Return False
        '--------Calculation of forces and moments -----------------
1970:   pSaddlesItem(iBtmTop).LT = pSaddlesItem(iBtmTop).Lungh(0) + pSaddlesItem(iBtmTop).Lungh(1) + pSaddlesItem(iBtmTop).Lungh(2)
        pSaddlesItem(iBtmTop).LTT = pSaddlesItem(iBtmTop).LT
1971:   If pSaddlesItem(iBtmTop).Simple = "Y" Then pSaddlesItem(iBtmTop).LTT = pSaddlesItem(iBtmTop).LT + 2 * pSaddlesItem(iBtmTop).HeadHeight
1980:   pAreaLav(iCond, iBtmTop).Q = 1000 * (pSaddlesLoad(iCond, iBtmTop).PesoTot - pSaddlesLoad(iCond, iBtmTop).PesoS(1) - pSaddlesLoad(iCond, iBtmTop).PesoS(2)) / pSaddlesItem(iBtmTop).LTT
1981:   If pSaddlesItem(iBtmTop).Simple = "Y" Then Call ForzeSimple(iBtmTop) Else Call ForzeComplex(iBtmTop)
        If Not TensAmm(iBtmTop) Then CalcolaSaddles = False : Exit Function
2720:   '------G.3.3.2.2 Longitudinal stresses in the span----------
        'Stoomwezen 3.1
2731:   If pSaddlesItem(iBtmTop).Simple = "Y" Then Call TMSimple(iBtmTop) Else Call TMComplex(iBtmTop)
        Call FactMiddle(SIGMAC, SIGMAT, Factor, iBtmTop)
        FactUs(1, iCond) = Factor
2900:   '----- G.3.3.2.3 Longitudinal stresses at the saddles  -----
        'Stoomwezen 3.2
        Call SaddlesCalc(iBtmTop)
        For iSadd = 1 To 2
            If Not pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                Call FactSaddle(SIGMAC, SIGMAT, Facto1, iBtmTop)
                FactUs(1 + iSadd, iCond) = Facto1
                If Facto1 > Factor Then Factor = Facto1
            End If
        Next
3560:   '----- G.3.3.2.4 Tangential shearing stresses         -----
        'Stoomwezen 3.3
        For i = 1 To 2
            iSadd = i
            If Problem.Codice = 0 Then
                Call CalcK34(i, pAreaLav(iCond, iBtmTop).ShearSaddle.K3, pAreaLav(iCond, iBtmTop).ShearSaddle.K4, iBtmTop)
            Else
                StShearSaddles(iBtmTop)
            End If
            Call FactShear(Facto1, iBtmTop)
            If Facto1 = 0 Then CalcolaSaddles = False : Exit Function
            FactUs(3 + i, iCond) = Facto1
            If Facto1 > Factor Then Factor = Facto1
        Next
4210:   '----- G.3.3.2.5 Circumferential stresses ----------------
        'Stoomwezen 3.4
        For i = 1 To 2
            iSadd = i
            If Problem.Codice = 0 Then
                Call CalcK56(i, pAreaLav(iCond, iBtmTop).CircSaddle.ZETS, _
                pAreaLav(iCond, iBtmTop).CircSaddle.b2, pAreaLav(iCond, iBtmTop).CircSaddle.K5, _
                pAreaLav(iCond, iBtmTop).CircSaddle.K6, pAreaLav(iCond, iBtmTop).CircSaddle.TT, _
                pAreaLav(iCond, iBtmTop).CircSaddle.K6S, pAreaLav(iCond, iBtmTop).CircSaddle.F5, _
                pAreaLav(iCond, iBtmTop).CircSaddle.F6, pAreaLav(iCond, iBtmTop).CircSaddle.F6S, _
                iBtmTop)
            Else
                CompressBott(iBtmTop)
            End If
            Call FactCircum(Facto1, iBtmTop)
            FactUs(5 + i, iCond) = Facto1
            If Facto1 > Factor Then Factor = Facto1
        Next
        'Stoomwezen 3.5
        If Problem.Codice = 1 Then
            For iSadd = 1 To 2
                If Not pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                    If pSaddlesItem(iBtmTop).TipoChius(iSadd) >= 1 And Not pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                        StFondo(iBtmTop)
                        FactFondo(Facto1, iBtmTop)
                        FactUs(9 + iSadd, iCond) = Facto1
                        If Facto1 > Factor Then Factor = Facto1
                    End If
                End If
            Next
        End If
        'Stoomwezen 3.6 support ring
        If Problem.Codice = 1 Then
            For iSadd = 1 To 2
                If pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                    StSupRing(iBtmTop)
                    FactSupRing(Facto1, iBtmTop)
                    FactUs(12 + iSadd, iCond) = Facto1
                    If Facto1 > Factor Then Factor = Facto1
                End If
            Next
        End If
5910:   '----- G.3.3.2.6 Design of saddles                   -----
        'Stoomwezen 3.7
        For i = 1 To 2
            iSadd = i
            If Problem.Codice = 0 Then
                If Not SadDes(i, pAreaLav(iCond, iBtmTop).SadDesign.K9, _
                pAreaLav(iCond, iBtmTop).SadDesign.h, pAreaLav(iCond, iBtmTop).SadDesign.HSD, _
                pAreaLav(iCond, iBtmTop).SadDesign.FSD, iBtmTop) Then CalcolaSaddles = False : Exit Function
            Else
                StSadDes(iBtmTop)
            End If
            Call FactDesign(Facto1, iBtmTop)
            FactUs(7 + i, iCond) = Facto1
            If Facto1 > Factor Then Factor = Facto1
        Next
        If Problem.Codice = 1 Then
            StBuckling(iBtmTop)
            FactBuckling(Facto1, iBtmTop)
            FactUs(12, iCond) = Facto1
            If Facto1 > Factor Then Factor = Facto1
        End If
6200:   '---------------- Fine dei calcoli --------------------------------------
        If Factor > 1 Then
            FinalCommentFinal = "(*) : LIMIT EXCEEDED. NOT ACCEPTABLE STRESSES"
        Else
            FinalCommentFinal = " Acceptable stresses"
        End If
        For i = 1 To 14
            If FactUs(i, iCond) > 1 Then DoveEccedes(i) = "(*)" Else DoveEccedes(i) = "   "
        Next
        If Problem.LoadCond(1, iCond + 1).Trim.Length = 0 Then Problem.LoadCond(1, iCond + 1) = "(without name)"
        '        "---- RISULTATI -----Condizione: " & RTrim(Problem.LoadCond(1, iCond + 1)) & " (Fattori d'uso)" & vbCrLf
        Msgg = Helpstringa(1010) & RTrim(Problem.LoadCond(1, iCond + 1)) & Helpstringa(1011) & vbCrLf
        '        "Tensioni longitudinali in mezzeria          #0.0000 &"
        Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1012), FactUs(1, iCond), DoveEccedes(1)) & vbCrLf
        If Problem.Codice = 0 Then
            '    "Tensioni longitudinali alle selle     #0.0000 & #0.0000 &"
            Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1013), FactUs(2, iCond), DoveEccedes(2), FactUs(3, iCond), DoveEccedes(3)) & vbCrLf

        Else
            If Not pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Or Not pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
                '"Tensioni locali normali alle selle    #0.0000 & #0.0000 &"
                Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1014), FactUs(2, iCond), DoveEccedes(2), FactUs(3, iCond), DoveEccedes(3)) & vbCrLf
            End If
        End If
        '        "Tensioni tangenziali alle selle       #0.0000 & #0.0000 &"
        Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1015), FactUs(4, iCond), DoveEccedes(4), FactUs(5, iCond), DoveEccedes(5)) & vbCrLf
        If Problem.Codice = 0 Then
            '    "Tensioni circonferenziali alle selle  #0.0000 & #0.0000 &"
            Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1016), FactUs(6, iCond), DoveEccedes(6), FactUs(7, iCond), DoveEccedes(7)) & vbCrLf
        Else
            '    "Tensioni di compressione nel cilindro #0.0000 & #0.0000 &"
            Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1017), FactUs(6, iCond), DoveEccedes(6), FactUs(7, iCond), DoveEccedes(7)) & vbCrLf
        End If
        For i = 1 To 2
            If Problem.Codice = 1 And pSaddlesItem(iBtmTop).TipoChius(i) >= 1 And Not pSaddlesItem(iBtmTop).GeomSadd(i).SupRing Then
                '"Tensioni nel fondo                          #0.0000 &"
                Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1018), FactUs(9 + i, iCond), DoveEccedes(9 + i)) & vbCrLf
            End If
        Next
        '        "Tensioni alla base delle selle        #0.0000 & #0.0000 &"
        Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1019), FactUs(8, iCond), DoveEccedes(8), FactUs(9, iCond), DoveEccedes(9)) & vbCrLf
        If Problem.Codice = 1 Then
            '    "Instabilità a compressione del cilindro     #0.0000 &"
            Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1020), FactUs(12, iCond), DoveEccedes(12)) & vbCrLf
            If pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Or pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
                '"Tensioni negli anelli di supporto     #0.0000 & #0.0000 &"
                Msgg = Msgg & GlobalRoutines.FormatS(Helpstringa(1021), FactUs(13, iCond), DoveEccedes(13), FactUs(14, iCond), DoveEccedes(14)) & vbCrLf
            End If
        End If
        If iCond > 0 Then
            Dim t As TabPage = New TabPage("Cond. " + (iCond + 1).ToString)
            Dim l1 As Label = New Label
            l1.Size = form1.Label1.Size
            l1.Location = form1.Label1.Location
            l1.TextAlign = form1.Label1.TextAlign
            l1.Font = form1.Label1.Font
            t.Controls.Add(l1)
            form1.TabControl1.TabPages.Add(t)
            If Factor > 1 Then t.Tag = "rosso" Else t.Tag = ""
        Else
            form1.TabControl1.TabPages(0).Text = "Cond. 1"
        End If
        Dim l As Label = CType(form1.TabControl1.TabPages(iCond).Controls(0), Label)
        Msgg = Msgg & FinalCommentFinal
        l.Text = Msgg
        Dim g As Graphics = Graphics.FromHwnd(l.Handle)
        Dim s As SizeF = g.MeasureString(Msgg, l.Font)
        Dim deltax As Single = Math.Max(s.Width - l.Width, 0)
        Dim deltay As Single = Math.Max(s.Height - l.Height, 0)
        l.Width += deltax
        l.Height += deltay
        form1.TabControl1.Width += deltax
        form1.TabControl1.Height += deltay
        form1.Width += deltax
        form1.Height += deltay
        g.Dispose()
        '  MsgBox(Msgg, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly)
    End Function

    Public Function CalcolaSella(ByRef Factor As Single) As Boolean
        Dim yRibs, yAnima, yG As Single
        Dim FixSli(2) As String
        Dim i As Short
        Dim Accett, Msgg As String
        FixSli(1) = "fissa" : FixSli(2) = "mobile"
        CalcolaSella = True
        Try
            With xSupportResult(iSadd, iCond)
                .Az = xSupport(iSadd).SaddlThk * xSupport(iSadd).SaddlLength
                .Ay = (xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk) * xSupport(iSadd).NumeroRibs * xSupport(iSadd).RibsThk
                .a = .Az + .Ay
                yAnima = xSupport(iSadd).SaddlThk / 2
                If xSupport(iSadd).Tipo = "I" Then yAnima = xSupport(iSadd).SaddlWidth / 2
                yRibs = (xSupport(iSadd).SaddlWidth + xSupport(iSadd).SaddlThk) / 2
                If xSupport(iSadd).Tipo = "I" Then yRibs = xSupport(iSadd).SaddlWidth / 2
                yG = (.Az * yAnima + .Ay * yRibs) / .a
                .Iz = xSupport(iSadd).SaddlThk ^ 3 / 12 * xSupport(iSadd).SaddlLength + (yG - yAnima) ^ 2 * .Az
                .Iz = .Iz + (xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk) ^ 3 / 12 * xSupport(iSadd).RibsThk + (yG - yRibs) ^ 2 * .Ay
                If xSupport(iSadd).Tipo = "I" Then
                    .Iz = .Iz + 2 * ((xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk) / 2) ^ 3 / 12 + .Ay * ((xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk) / 2) ^ 2
                Else
                    .Iz = .Iz + (xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk) ^ 3 / 12 * xSupport(iSadd).RibsThk + (yG - yRibs) ^ 2 * .Ay
                End If
                .Iy = xSupport(iSadd).SaddlLength ^ 3 / 12 * xSupport(iSadd).SaddlThk + xSupport(iSadd).NumeroRibs * xSupport(iSadd).RibsThk ^ 3 / 12 * (xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk)
                For i = 1 To nDist
                    .Iy = .Iy + 2 * xSupport(iSadd).Dist(i) ^ 2 * xSupport(iSadd).RibsThk * (xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk)
                Next
                .j = xSupport(iSadd).SaddlLength ^ 3 / 12 * xSupport(iSadd).SaddlThk + xSupport(iSadd).NumeroRibs * xSupport(iSadd).RibsThk ^ 3 / 12 * (xSupport(iSadd).SaddlWidth - xSupport(iSadd).SaddlThk)
                .sfx = System.Math.Abs(xSupportData(iSadd, iCond).NormalForce) / .a
                .SMz = 1000 * System.Math.Abs(xSupportData(iSadd, iCond).MomTrasv) * (xSupport(iSadd).SaddlWidth - yG) / .Iz
                .SMy = 1000 * System.Math.Abs(xSupportData(iSadd, iCond).MomLong) * xSupport(iSadd).SaddlLength / 2 / .Iy
                .TFz = System.Math.Abs(xSupportData(iSadd, iCond).ShearLong) / .Az
                .TFy = System.Math.Abs(xSupportData(iSadd, iCond).ShearTrasv) / .Ay
                .TMx = 1000 * System.Math.Abs(xSupportData(iSadd, iCond).MomTorc) / .j * xSupport(iSadd).SaddlThk / 2
                .Stress = System.Math.Sqrt((.sfx + .SMz + .SMy) ^ 2 + 4 * (.TFz + .TFy + .TMx) ^ 2)
                If .Stress > xSupportData(iSadd, iCond).Allow Then Accett = "inaccettabili." Else Accett = "accettabili." 'Exit Function"
                If Problem.LoadCond(2, iCond + 1).Trim = "" Then Problem.LoadCond(2, iCond + 1) = "Senza nome"
                Msgg = ("Condizione di carico: " & RTrim(Problem.LoadCond(2, iCond + 1)) & ". Sella " & FixSli(iSadd)).PadRight(50) & "." & vbCrLf
                Msgg = Msgg & ("Tensioni " & Accett).PadRight(50) & "." & vbCrLf
                Msgg = Msgg & ("Tensione equivalente calcolata: " & GlobalRoutines.FormatS("#####.0", .Stress) & " MPa").PadRight(50) & "." & vbCrLf
                Msgg = Msgg & ("Tensione ammissibile: " & GlobalRoutines.FormatS("#####.0", xSupportData(iSadd, iCond).Allow) & " MPa").PadRight(50) & "."
                'MsgBox(Msgg, MsgBoxStyle.Exclamation)
                If xSupportData(iSadd, iCond).Allow = 0 Then
                    Factor = 1 : Accett = "non valutabili"
                    Msgg = ("Condizione di carico: " & RTrim(Problem.LoadCond(2, iCond + 1)) & ". Sella " & FixSli(iSadd)).PadRight(50) & "." & vbCrLf
                    Msgg = Msgg & ("Non è stata definita la tensione ammissibile").PadRight(50) & "." & vbCrLf
                    Msgg = Msgg & ("per il materiale della sella.").PadRight(50) & "." & vbCrLf
                    Msgg = Msgg & ("Tensioni " & Accett).PadRight(50) & "."
                    'MsgBox(Msgg, MsgBoxStyle.Exclamation)
                Else
                    Factor = .Stress / xSupportData(iSadd, iCond).Allow
                End If
            End With
            Dim t As TabPage
            Dim l As Label
            With Form3
                If iCond > 0 And iSadd = 1 Then
                    t = New TabPage("Cond." + (iCond + 1).ToString)
                    l = New Label
                    l.Height = .Labelup1.Height
                    l.Width = .Labelup1.Width
                    l.Top = .Labelup1.Top
                    l.Left = .Labelup1.Left
                    l.TextAlign = .Labelup1.TextAlign
                    l.BorderStyle = .Labelup1.BorderStyle
                    l.Font = .Labelup1.Font
                    t.Controls.Add(l)
                    l = New Label
                    l.Height = .Labeldo1.Height
                    l.Width = .Labeldo1.Width
                    l.Top = .Labeldo1.Top
                    l.Left = .Labeldo1.Left
                    l.TextAlign = .Labeldo1.TextAlign
                    l.BorderStyle = .Labeldo1.BorderStyle
                    l.Font = .Labeldo1.Font
                    t.Controls.Add(l)
                    .TabControl1.TabPages.Add(t)
                End If
                t = .TabControl1.TabPages(iCond)
                If Not Accett = "accettabili." Then t.Tag = "rosso" Else t.Tag = ""
                CType(t.Controls(iSadd - 1), Label).Text = Msgg
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            CalcolaSella = False
        End Try
    End Function
    Private Sub Leggi(ByVal RigaS As String, ByVal i As Integer)
        Dim kk As Short, skk As Single
        Dim j, k As Integer
        Problem.NCond(i) = 0
        For j = 1 To kk
            skk = 0.0#
            For k = 1 To Problem.NumCondElem
                skk = skk + System.Math.Abs(Problem.LoadCase(i, j, k))
            Next
            If skk > 0 Then Problem.NCond(i) = Problem.NCond(i) + 1
        Next j
    End Sub
    Public Function ControllaDati1() As Boolean
        ControllaDati1 = True
        If Inizializzando Then Exit Function
        Dim PesoTot, PesoEle As Single
        Dim k As Short
        Dim Factor, PesoTot1, Factor1 As Single
        Dim Msgg As String
        If iCond > 0 Then
            For k = 0 To 2
                If SaddlesLoad(iCond).AmmShell(k) = 0 Then SaddlesLoad(iCond).AmmShell(k) = SaddlesLoad(0).AmmShell(k)
                If SaddlesLoad(iCond).Young(k) = 0 Then SaddlesLoad(iCond).Young(k) = SaddlesLoad(0).Young(k)
            Next
            For k = 1 To 2
                If SaddlesLoad(iCond).AmmHead(k) = 0 Then SaddlesLoad(iCond).AmmHead(k) = SaddlesLoad(0).AmmHead(k)
                If SaddlesLoad(iCond).AmmHeadTens(k) = 0 Then SaddlesLoad(iCond).AmmHeadTens(k) = SaddlesLoad(0).AmmHeadTens(k)
                If SaddlesLoad(iCond).AmmSadd(k) = 0 Then SaddlesLoad(iCond).AmmSadd(k) = SaddlesLoad(0).AmmSadd(k)
            Next
        End If
        For k = 1 To Problem.NumCondElem
            PesoEle = LoadFoundData.Sforzi(1).f(k, 3) + LoadFoundData.Sforzi(2).f(k, 3)
            PesoTot = PesoTot + PesoEle * Problem.LoadCase(1, iCond + 1, k)
        Next
        If PesoTot = 0 And LoadsCalcolate Then Exit Function
        PesoTot1 = SaddlesLoad(iCond).PesoTot
        PesoTot1 = PesoTot1 * 1000
        If PesoTot1 = 0 Then
            Msgg = Helpstringa(1006) & Problem.LoadCond(1, iCond + 1) '"Mancano i dati di peso per la condizione di carico "
            Msgg = Msgg & vbCrLf & Helpstringa(1007) ' "Vuoi riportare i dati dal calcolo delle fondazioni?"
            If MostraAiuto(1006, , Msgg, Helpstringa(1008)) = ChiaviMess.Messno Then Return False
            SaddlesLoad(iCond).PesoTot = PesoTot / 1000
            Factor1 = 1
            If SaddlesLoad(0).PesoTot > 0 Then Factor1 = PesoTot / 1000 / SaddlesLoad(0).PesoTot
            For k = 1 To 2
                SaddlesLoad(iCond).PesoS(k) = SaddlesLoad(0).PesoS(k) * Factor1
                SaddlesLoad(iCond).MomS(k) = SaddlesLoad(0).MomS(k) * Factor1
            Next
            PesoTot1 = PesoTot
        End If
        If PesoTot > 0 Then
            If System.Math.Abs(PesoTot - PesoTot1) / PesoTot > 0.01 Then
                ' Msgg = "Condizione di carico: " & Problem.LoadCond(1, iCond + 1) & vbCrLf
                ' Msgg = Msgg & "La risultante verticale dei carichi sulle fondazioni ("
                ' Msgg = Msgg & Str(PesoTot) & " N)" & vbCrLf & "non corrisponde alla risultante dei carichi applicati dall'apparecchio ("
                ' Msgg = Msgg & Str(PesoTot1) & " N)." & vbCrLf
                ' Msgg = Msgg & "Vuoi correggere i carichi generati dall'apparecchio?"
                Msgg = GlobalRoutines.FormatS(Helpstringa(1009), Problem.LoadCond(1, iCond + 1), PesoTot.ToString, PesoTot1.ToString)
                If MostraAiuto(1006, ChiaviMess.MessYesNo + ChiaviMess.MessQuestion + ChiaviMess.MessHelpButton, Msgg, Helpstringa(1008)) = ChiaviMess.MessSi Then
                    '      If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Factor = PesoTot / PesoTot1
                    For k = 1 To 2
                        SaddlesLoad(iCond).PesoS(k) = SaddlesLoad(iCond).PesoS(k) * Factor
                        SaddlesLoad(iCond).MomS(k) = SaddlesLoad(iCond).MomS(k) * Factor
                    Next
                    SaddlesLoad(iCond).PesoTot = PesoTot / 1000
                End If
            End If
        End If
        '   If SaddlesLoad(iCond).DesPress = 0 Then
        '      MsgBox "La pressione di progetto non può essere nulla", vbExclamation
        '      ControllaDati1 = False
        '      Exit Function
        '   End If
    End Function
    Public Function ControllaDati1T() As Boolean
        ControllaDati1T = True
        If Inizializzando Then Exit Function
        Dim PesoTot, PesoEle As Single
        Dim k As Short
        Dim Factor, PesoTot1, Factor1 As Single
        Dim Msgg As String
        If iCond > 0 Then
            For k = 0 To 2
                If SaddlesLoadT(iCond).AmmShell(k) = 0 Then SaddlesLoadT(iCond).AmmShell(k) = SaddlesLoadT(0).AmmShell(k)
                If SaddlesLoadT(iCond).Young(k) = 0 Then SaddlesLoadT(iCond).Young(k) = SaddlesLoadT(0).Young(k)
            Next
            For k = 1 To 2
                If SaddlesLoadT(iCond).AmmHead(k) = 0 Then SaddlesLoadT(iCond).AmmHead(k) = SaddlesLoadT(0).AmmHead(k)
                If SaddlesLoadT(iCond).AmmHeadTens(k) = 0 Then SaddlesLoadT(iCond).AmmHeadTens(k) = SaddlesLoadT(0).AmmHeadTens(k)
                If SaddlesLoadT(iCond).AmmSadd(k) = 0 Then SaddlesLoadT(iCond).AmmSadd(k) = SaddlesLoadT(0).AmmSadd(k)
            Next
        End If
        For k = 1 To Problem.NumCondElem
            PesoEle = LoadFoundDataT.Sforzi(1).f(k, 3) + LoadFoundDataT.Sforzi(2).f(k, 3)
            PesoTot = PesoTot + PesoEle * Problem.LoadCase(1, iCond + 1, k)
        Next
        If PesoTot = 0 And LoadsCalcolate Then Exit Function
        PesoTot1 = SaddlesLoadT(iCond).PesoTot
        PesoTot1 = PesoTot1 * 1000
        If PesoTot1 = 0 Then
            Msgg = "Mancano i dati di peso per la condizione di carico " & Problem.LoadCond(1, iCond + 1)
            If Not LoadsCalcolate Then
                MsgBox(Msgg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly)
                ControllaDati1T = False
                Exit Function
            Else
                Msgg = Msgg & vbCrLf & "Vuoi riportare i dati dal calcolo delle fondazioni?"
                If MsgBox(Msgg, MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then ControllaDati1T = False : Exit Function
                SaddlesLoadT(iCond).PesoTot = PesoTot / 1000
                Factor1 = PesoTot / 1000 / SaddlesLoadT(0).PesoTot
                For k = 1 To 2
                    SaddlesLoadT(iCond).PesoS(k) = SaddlesLoadT(0).PesoS(k) * Factor1
                    SaddlesLoadT(iCond).MomS(k) = SaddlesLoadT(0).MomS(k) * Factor1
                Next
                PesoTot1 = PesoTot
            End If
        End If
        If PesoTot > 0 Then
            If System.Math.Abs(PesoTot - PesoTot1) / PesoTot > 0.01 Then
                Msgg = "Condizione di carico: " & Problem.LoadCond(1, iCond + 1) & vbCrLf
                Msgg = Msgg & "La risultante verticale dei carichi sulle fondazioni ("
                Msgg = Msgg & Str(PesoTot) & " N)" & vbCrLf & "non corrisponde alla risultante dei carichi applicati dall'apparecchio ("
                Msgg = Msgg & Str(PesoTot1) & " N)." & vbCrLf
                Msgg = Msgg & "Vuoi correggere i carichi generati dall'apparecchio?"
                If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Factor = PesoTot / 1000 / PesoTot1
                    For k = 1 To 2
                        SaddlesLoad(iCond).PesoS(k) = SaddlesLoad(iCond).PesoS(k) * Factor
                        SaddlesLoad(iCond).MomS(k) = SaddlesLoad(iCond).MomS(k) * Factor
                    Next
                    SaddlesLoadT(iCond).PesoTot = PesoTot / 1000
                End If
            End If
        End If
        '   If SaddlesLoad(iCond).DesPress = 0 Then
        '      MsgBox "La pressione di progetto non può essere nulla", vbExclamation
        '      ControllaDati1 = False
        '      Exit Function
        '   End If
    End Function
    Private Sub mnuSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSalva.Click
        If Not ChiudiOLE() Then Exit Sub
        Call SaveData()
    End Sub
    Private Sub mnuSalvaCome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSalvaCome.Click
        Dim Ext0 As String = Monitor.Motore.Problem.Extension
        Dim Ext1 As String = Ext0.Substring(1, Ext0.Length - 1)
        If Not ChiudiOLE() Then Exit Sub
        Commondialog1.FileName = FileData 'RTrim$(Datidir)
        Commondialog1.InitialDirectory = Monitor.Motore.Inizio.Datidir
        Commondialog1.Filter = Monitor.Motore.Problem.TipoFile & Ext0 & " (*" & Ext1 & ")|*" & Ext1
        Commondialog1.ShowDialog()
        FileData = Commondialog1.FileName
        Call SaveData()
    End Sub
    Private Function SecondoSpecchio1() As Boolean
        Dim i As Short
        With Stub
            If EliminatoVento Then
                If Not .EliminaCelle("StartV", "FormulaV") Then Return False
            Else
                .SubstitBookM("StartV", "", True)
                .SubstitBookM("NormaV", Problem.NormeVento, True)
                .SubstitBookM("ParV", Me.lsVento(0).Text & ", " & Me.lVento(0).Text, True)
                .MuoviCella(1)
                .Testo(Me.tVento(0).Text)
                .MuoviCella(1)
                .Testo(Me.rtfVento(0).Text)
                For i = 1 To Problem.NumParamV - 1
                    .MuoviLinea(1)
                    .MuoviCella(-2)
                    .Testo(Me.lsVento(i).Text & ", " & Me.lVento(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.tVento(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.rtfVento(i).Text)
                Next
                .SubstitBookM("Al", Me.txtLateralForce.Text, True)
                .MuoviLinea(1)
                .Testo(Me.txtFrontArea.Text)
                .MuoviLinea(2)
                .Testo(Me.txtPressure.Text)
                .MuoviLinea(1)
                .Testo(Me.txtLateralForce.Text)
                .MuoviLinea(1)
                .Testo(Me.txtFrontForce.Text)
                .SubstitBookM("FormulaV", Me.rtfFormulaVento.Text, True)
            End If
            Return True
        End With
    End Function
    Private Function SecondoSpecchio1T() As Boolean
        Dim i As Short
        With Stub
            If EliminatoVento Then
                If Not .EliminaCelle("StartV", "FormulaV") Then Return False
            Else
                .SubstitBookM("StartV", "")
                .SubstitBookM("NormaV", Problem.NormeVento)
                .SubstitBookM("ParV", Me.lsVentoT(0).Text & ", " & Me.lVentoT(0).Text)
                .MuoviCella(1)
                .Testo(Me.tVentoT(0).Text)
                .MuoviCella(1)
                .Testo(Me.rtfVentoT(0).Text)
                For i = 1 To Problem.NumParamV - 1
                    .MuoviLinea(1)
                    .MuoviCella(-2)
                    .Testo(Me.lsVentoT(i).Text & ", " & Me.lVentoT(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.tVentoT(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.rtfVentoT(i).Text)
                Next
                .SubstitBookM("Al", Me.txtLateralForceT.Text)
                .MuoviLinea(1)
                .Testo(Me.txtFrontAreaT.Text)
                .MuoviLinea(2)
                .Testo(Me.txtPressureT.Text)
                .MuoviLinea(1)
                .Testo(Me.txtLateralForceT.Text)
                .MuoviLinea(1)
                .Testo(Me.txtFrontForceT.Text)
                .SubstitBookM("FormulaV", Me.rtfFormulaVentoT.Text)
            End If
            Return True
        End With
    End Function
    Private Function SEcondoSpecchio2() As Boolean
        Dim i As Short
        With Stub
            If EliminatoSisma Then
                If Not .EliminaCelle("StartS", "FormulaS") Then Return False
            Else
                .SubstitBookM("StartS", "", True)
                .SubstitBookM("NormaS", Problem.NormeSisma, True)
                .SubstitBookM("ParS", Me.lsSisma(0).Text & ", " & Me.lSisma(0).Text, True)
                .MuoviCella(1)
                .Testo(Me.tSisma(0).Text)
                .MuoviCella(1)
                .Testo(Me.rtfSisma(0).Text)
                For i = 1 To Problem.NumParamS - 1
                    .MuoviLinea(1)
                    .MuoviCella(-2)
                    .Testo(Me.lsSisma(i).Text & ", " & Me.lSisma(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.tSisma(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.rtfSisma(i).Text)
                Next
                .SubstitBookM("HorF", Me.txtForceSeism.Text, True)
                .SubstitBookM("FormulaS", Me.rtfFormulaSisma.Text, True)
            End If
            Return True
        End With
    End Function
    Private Function SecondoSpecchio2T() As Boolean
        Dim i As Short
        With Stub
            If EliminatoSisma Then
                If Not .EliminaCelle("StartS", "FormulaS") Then Return False
            Else
                .SubstitBookM("StartS", "")
                .SubstitBookM("NormaS", Problem.NormeSisma)
                .SubstitBookM("ParS", Me.lsSismaT(0).Text & ", " & Me.lSismaT(0).Text)
                .MuoviCella(1)
                .Testo(Me.tSismaT(0).Text)
                .MuoviCella(1)
                .Testo(Me.rtfSismaT(0).Text)
                For i = 1 To Problem.NumParamS - 1
                    .MuoviLinea(1)
                    .MuoviCella(-2)
                    .Testo(Me.lsSismaT(i).Text & ", " & Me.lSismaT(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.tSismaT(i).Text)
                    .MuoviCella(1)
                    .Testo(Me.rtfSismaT(i).Text)
                Next
                .SubstitBookM("HorF", Me.txtForceSeismT.Text)
                .SubstitBookM("FormulaS", Me.rtfFormulaSismaT.Text)
            End If
            Return True
        End With
    End Function
    Private Sub PrimoSpecchio()
        Dim i As Short
        With Stub
            .SubstitBookM("JobN", Monitor.Motore.Problem.Commessa, True)
            .MuoviLinea(1)
            .Testo(SaddlesItem.Item)
            .MuoviLinea(1)
            .Testo(SaddlesItem.Lungh(0).ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.CGdistFromFixed.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.CGHeight.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.frictionfactor.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.bundlefactor.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.bundleCGheight.ToString)
            For i = 0 To 3
                .MuoviLinea(1)
                .Testo(LoadFoundData.Pesi(i).ToString)
            Next
            .SubstitBookM("VessOD", SaddlesItem.VesselOD.ToString, True)
            .MuoviLinea(1)
            .Testo(SaddlesItem.InsulThk.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.VesselLength.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItem.EquivVesselOD.ToString)
        End With
    End Sub
    Private Sub PrimoSpecchioT()
        Dim i As Short
        With Stub
            .SubstitBookM("JobN", Monitor.Motore.Problem.Commessa, True)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.Item)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.CGdistFromFixed.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.CGHeight.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.bundlefactor.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.bundleCGheight.ToString)
            For i = 0 To 3
                .MuoviLinea(1)
                .Testo(LoadFoundData.Pesi(i).ToString)
            Next
            .SubstitBookM("VessOD", SaddlesItemT.VesselOD.ToString, True)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.InsulThk.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.VesselLength.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.EquivVesselOD.ToString)
            .MuoviLinea(1)
            .Testo(SaddlesItemT.Heightbtwsaddles.ToString)
        End With
    End Sub
    Private Function StampaCarTopItem() As Boolean
        Dim i, j, k As Integer
        With Stub
            .SubstitBookM("Condition1", Problem.Condiz(1), True)
            For i = 1 To 2
                For k = 1 To 4
                    .MuoviCella(1)
                    .Testo(SforziFromTop.SforziFromTop(i, 1, k).ToString)
                Next
            Next
            Monitor.Motore.Avanzamento = (Avanzamento + 140 + 60 / Problem.NumCondElem) / nFasi
            DoEvents()
            If Interrompi Then Return False
            For j = 2 To Problem.NumCondElem
                .MuoviLinea(1)
                .MuoviCella(-8)
                .Testo(Problem.Condiz(j))
                For i = 1 To 2
                    For k = 1 To 4
                        .MuoviCella(1)
                        .Testo(SforziFromTop.SforziFromTop(i, j, k).ToString(FormInt8))
                    Next
                Next
                Monitor.Motore.Avanzamento = (Avanzamento + 140 + 60 * j / Problem.NumCondElem) / nFasi
                DoEvents()
                If Interrompi Then Return False
            Next
        End With
        Return True
    End Function
    Private Function StampaCarFonda() As Boolean
        Dim i, j, k As Integer
        With Stub
            .SubstitBookM("Condition", Problem.Condiz(1))
            For i = 1 To 2
                For k = 1 To 4
                    .MuoviCella(1)
                    .Testo(LoadFoundData.Sforzi(i).f(1, k).ToString)
                Next
            Next
            Monitor.Motore.Avanzamento = (140 + 60 / Problem.NumCondElem) / nFasi
            DoEvents()
            If Interrompi Then Return False
            For j = 2 To Problem.NumCondElem
                .MuoviLinea(1)
                .MuoviCella(-8)
                .Testo(Problem.Condiz(j))
                For i = 1 To 2
                    For k = 1 To 4
                        .MuoviCella(1)
                        .Testo(LoadFoundData.Sforzi(i).f(j, k).ToString(FormInt8))
                    Next
                Next
                Monitor.Motore.Avanzamento = (140 + 60 * j / Problem.NumCondElem) / nFasi
                DoEvents()
                If Interrompi Then Return False
            Next
        End With
        Return True
    End Function
    Private Function StampaCarFondaT() As Boolean
        Dim i, j, k As Integer
        With Stub
            .SubstitBookM("ConditionT", Problem.Condiz(1))
            For i = 1 To 2
                For k = 1 To 4
                    .MuoviCella(1)
                    .Testo(LoadFoundDataT.Sforzi(i).f(1, k).ToString)
                Next
            Next
            Monitor.Motore.Avanzamento = (Avanzamento + 140 + 60 / Problem.NumCondElem) / nFasi
            DoEvents()
            If Interrompi Then Return False
            For j = 2 To Problem.NumCondElem
                .MuoviLinea(1)
                .MuoviCella(-8)
                .Testo(Problem.Condiz(j))
                For i = 1 To 2
                    For k = 1 To 4
                        .MuoviCella(1)
                        .Testo(LoadFoundDataT.Sforzi(i).f(j, k).ToString(FormInt8))
                    Next
                Next
                Monitor.Motore.Avanzamento = (Avanzamento + 140 + 60 * j / Problem.NumCondElem) / nFasi
                DoEvents()
                If Interrompi Then Return False
            Next
        End With
        Return True
    End Function
    Private Sub mnuStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStampa.Click
        If Not ChiudiOLE() Then Exit Sub
        If Not SelleCalcolate And Not SaddlesCalcolate And Not FondaCalcolate And Not LoadsCalcolate Then
            MostraAiuto(IDH_NIENTEDASTAMPARE)
            Exit Sub
        End If
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto di calcolo", "BSDD")
        Interrompi = False
        Me.Enabled = False
        nFasi = 3
        If SaddlesItem.NumBocch > 0 Then nFasi = 4
        If Not LoadsCalcolate Then nFasi = 1
        If Problem.Stacked Then nFasi *= 2
        Monitor.Motore.Avanzamento = 25 / nFasi
        DoEvents()
        If Interrompi Then GoTo Fine
        If Not Stampa(1) Then GoTo Fine
        Monitor.Motore.Avanzamento = 50 / nFasi
        DoEvents()
        If Interrompi Then GoTo Fine
        Monitor.Motore.Inizio.SuperStampa(NomeFileSt, Stub)  ' Doc
        Monitor.Motore.Avanzamento = 100 / nFasi
        DoEvents()
        If Interrompi Then GoTo Fine
        If Stub Is Nothing Then GoTo Fine
        If Not LoadsCalcolate Then GoTo Fine
        Try
            With Stub
                ' .Visible = False
                .sShowAll(True, True)
                Monitor.Motore.Avanzamento = 105 / nFasi
                DoEvents()
                If Interrompi Then GoTo Fine
                .sOpen(Monitor.Motore.Inizio.Archdir + "\FoundationLoads.doc", True, 1)
                .VaiInizio("", 1)
                .Copia(1)
                .sClose(, 1)
                Monitor.Motore.Avanzamento = 110 / nFasi
                DoEvents()
                If Interrompi Then GoTo Fine
                .VaiInizio("LoadsCalcolate")
                .ASMEPI()
                'primo specchietto ------------------------------------------------
                If Problem.Stacked Then
                    .SubstitBookM("ITEM", "BOTTOM ITEM Number")
                End If
                PrimoSpecchio()
                Monitor.Motore.Avanzamento = 120 / nFasi
                DoEvents()
                If Interrompi Then GoTo Fine
                'secondo specchietto parte 1 ---------------------------------------------------
                If Not SecondoSpecchio1() Then GoTo Fine
                Monitor.Motore.Avanzamento = 130 / nFasi
                DoEvents()
                If Interrompi Then GoTo Fine
                'secondo specchietto parte 2 ---------------------------------------------------
                If Not SEcondoSpecchio2() Then GoTo Fine
                Monitor.Motore.Avanzamento = 140 / nFasi
                DoEvents()
                If Interrompi Then GoTo Fine
                'tabella dei carichi
                If Not StampaCarFonda() Then GoTo Fine
                If Not StampaBocchelli() Then GoTo Fine
                If Not StampaCombinazioni() Then GoTo Fine
                If Problem.Stacked Then
                    .sOpen(Monitor.Motore.Inizio.Archdir + "\FoundationLoadsT.doc", True, 1)
                    .VaiInizio("", 1)
                    .Copia(1)
                    .sClose(, 1)
                    Monitor.Motore.Avanzamento = (Avanzamento + 110) / nFasi
                    DoEvents()
                    If Interrompi Then GoTo Fine
                    .VaiInizio("\EndOfDoc")
                    .ASMEPI()
                    If Not StampaCarTopItem() Then GoTo Fine
                    'primo specchietto ------------------------------------------------
                    PrimoSpecchioT()
                    Monitor.Motore.Avanzamento = (Avanzamento + 120) / nFasi
                    DoEvents()
                    If Interrompi Then GoTo Fine
                    'secondo specchietto parte 1 ---------------------------------------------------
                    If Not SecondoSpecchio1T() Then GoTo Fine
                    Monitor.Motore.Avanzamento = (Avanzamento + 130) / nFasi
                    DoEvents()
                    If Interrompi Then GoTo Fine
                    'secondo specchietto parte 2 ---------------------------------------------------
                    If Not SecondoSpecchio2T() Then GoTo Fine
                    Monitor.Motore.Avanzamento = (Avanzamento + 140) / nFasi
                    DoEvents()
                    If Interrompi Then GoTo Fine
                    If Not StampaCarFondaT() Then GoTo Fine
                    If Not StampaBocchelliT() Then GoTo Fine
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
Fine:   Monitor.Motore.ProgrAmmazza()
        Me.Enabled = True
        If Not Stub Is Nothing Then Stub.Massimizza()
Fine1:  Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Function StampaCombinazioni() As Boolean
        Dim i, j, k As Short
        With Stub
            .sOpen(Monitor.Motore.Inizio.Archdir + "\FoundationLoads2.doc", True, 1)
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            Monitor.Motore.Avanzamento = (Avanzamento + 10) / nFasi
            DoEvents()
            If Interrompi Then Return False
            If SaddlesItem.NumBocch > 0 Then
                .VaiInizio("FineLoads1")
            Else
                .VaiInizio("FineLoads")
            End If
            .ASMEPI(True)
            Monitor.Motore.Avanzamento = (Avanzamento + 20) / nFasi
            DoEvents()
            If Interrompi Then Return False
            Dim segno As String = ""
            Dim testo As String = ""
            For i = 1 To 3
                Select Case i
                    Case 1 : segno = "Combination_a"
                    Case 2 : segno = "Combination_b"
                    Case 3 : segno = "Combination_c"
                End Select
                .SubstitBookM(segno, Problem.LoadCond(i, 1))
                For k = 1 To 11 'Problem.NumCondElem
                    .MuoviCella(1)
                    If k > Problem.NumCondElem Then
                        testo = " "
                    ElseIf Problem.LoadCase(i, 1, k) > 0 Then
                        testo = Problem.LoadCase(i, 1, k).ToString(FormSng1)
                    Else
                        testo = " "
                    End If
                    .Testo(testo)
                Next
                For j = 2 To Problem.NCond(i)
                    .TastoTab()
                    .Testo(Problem.LoadCond(i, j))
                    For k = 1 To 11 'Problem.NumCondElem
                        .MuoviCella(1)
                        If k > Problem.NumCondElem Then
                            testo = " "
                        ElseIf Problem.LoadCase(i, j, k) > 0 Then
                            testo = Problem.LoadCase(i, j, k).ToString(FormSng1)
                        Else
                            testo = " "
                        End If
                        .Testo(testo)
                    Next
                Next
                .BorderBottom()
                Monitor.Motore.Avanzamento = (Avanzamento + 20 + 80 / 3 * i) / nFasi
                DoEvents()
                If Interrompi Then Return False
            Next
        End With
        Return True
    End Function
    Private Function StampaBocchelli() As Boolean
        Dim i As Short
        Avanzamento = 200
        With Stub
            If SaddlesItem.NumBocch > 0 Then
                Avanzamento = 300
                Monitor.Motore.Avanzamento = 205 / nFasi
                DoEvents()
                If Interrompi Then Return False
                .sOpen(Monitor.Motore.Inizio.Archdir + "\FoundationLoads1.doc", True, 1)
                .VaiInizio("", 1)
                .Copia(1)
                .sClose(, 1)
                Monitor.Motore.Avanzamento = 210 / nFasi
                DoEvents()
                If Interrompi Then Return False
                .VaiInizio("FineLoads", , True, True)
                .ASMEPI(True)
                .SubstitBookM("Mark", NozzleData.NozzleNames(1), True)
                .MuoviCella(1)
                .Testo(NozzleData.PositionX(1).ToString)
                .MuoviCella(1)
                .Testo(NozzleData.PositionZ(1).ToString)
                .MuoviCella(1)
                .Testo("mm")
                For i = 2 To SaddlesItem.NumBocch
                    .TastoTab()
                    .Testo(NozzleData.NozzleNames(i))
                    .MuoviCella(1)
                    .Testo(NozzleData.PositionX(i).ToString)
                    .MuoviCella(1)
                    .Testo(NozzleData.PositionZ(i).ToString)
                    .MuoviCella(1)
                    .Testo("mm")
                Next
                .BorderBottom()
                Monitor.Motore.Avanzamento = 240 / nFasi
                DoEvents()
                If Interrompi Then Return False
                .VaiInizio("Inizio", , True, True)
                ' .MuoviLinea(7, True)
                .VaiFine("FineLoads1")
                .sCopy()
                CompilaTab(Stub, 1)
                Monitor.Motore.Avanzamento = (240 + 60 / SaddlesItem.NumBocch) / nFasi
                DoEvents()
                If Interrompi Then Return False
                Dim ii As Integer
                For ii = 2 To SaddlesItem.NumBocch
                    .VaiInizio("FineLoads1", , True, True)
                    .ASMEPI(, True)
                    CompilaTab(Stub, ii)
                    Monitor.Motore.Avanzamento = (240 + 60 * ii / SaddlesItem.NumBocch) / nFasi
                    DoEvents()
                    If Interrompi Then Return False
                    ' .VaiInizio("Inizio", , , True)
                Next
            End If
        End With
        Return True
    End Function
    Private Function StampaBocchelliT() As Boolean
        Dim i As Short
        Avanzamento = 400
        With Stub
            If SaddlesItem.NumBocch > 0 Then
                Avanzamento = 600
                Monitor.Motore.Avanzamento = 405 / nFasi
                DoEvents()
                If Interrompi Then Return False
                .sOpen(Monitor.Motore.Inizio.Archdir + "\FoundationLoads1.doc", True, 1)
                .VaiInizio("", 1)
                .Copia(1)
                .sClose(, 1)
                Monitor.Motore.Avanzamento = 210 / nFasi
                DoEvents()
                If Interrompi Then Return False
                .VaiInizio("FineLoads")
                .ASMEPI(True)
                .SubstitBookM("Mark", NozzleDataT.NozzleNames(1), True)
                .MuoviCella(1)
                .Testo(NozzleDataT.PositionX(1).ToString)
                .MuoviCella(1)
                .Testo(NozzleDataT.PositionZ(1).ToString)
                .MuoviCella(1)
                .Testo("mm")
                For i = 2 To SaddlesItemT.NumBocch
                    .TastoTab()
                    .Testo(NozzleDataT.NozzleNames(i))
                    .MuoviCella(1)
                    .Testo(NozzleDataT.PositionX(i).ToString)
                    .MuoviCella(1)
                    .Testo(NozzleDataT.PositionZ(i).ToString)
                    .MuoviCella(1)
                    .Testo("mm")
                Next
                .BorderBottom()
                Monitor.Motore.Avanzamento = 440 / nFasi
                DoEvents()
                If Interrompi Then Return False
                .VaiInizio("Inizio", , True, True)
                ' .MuoviLinea(7, True)
                .VaiFine("FineLoads1")
                .sCopy()
                CompilaTabT(Stub, 1)
                Monitor.Motore.Avanzamento = (440 + 60 / SaddlesItemT.NumBocch) / nFasi
                DoEvents()
                If Interrompi Then Return False
                Dim ii As Integer
                For ii = 2 To SaddlesItemT.NumBocch
                    .VaiInizio("FineLoads1", , True, True)
                    .ASMEPI(, True)
                    CompilaTabT(Stub, ii)
                    Monitor.Motore.Avanzamento = (440 + 60 * ii / SaddlesItemT.NumBocch) / nFasi
                    DoEvents()
                    If Interrompi Then Return False
                    ' .VaiInizio("Inizio", , , True)
                Next
            End If
        End With
        Return True
    End Function
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Monitor.Motore.Informazioni(Me, Reflection.Assembly.GetExecutingAssembly)
    End Sub

    Private Sub mnuCodice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCodice.Click
        Dim Strin1() As String = {"", "PD5500-G.3.3", "Stoomwezen D1105"}
        Dim Tit As String = rmHelpStrings.GetString("Codice")
        Dim Aiuto As String = RadiceHelp
        Dim j As Integer = Monitor.Motore.Quale(2, Tit, Strin1, Aiuto, Problem.Codice + 1, strIDH:="CodiceCalc.htm") - 1
        If j = 0 Then
            Dim Tit1 As String = rmHelpStrings.GetString("titOutOfRoundness")
            Dim Strin2(1) As String
            Dim Ris1(1) As Boolean
            Strin2(1) = rmHelpStrings.GetString("domOutOfRoundness")
            Ris1(1) = Problem.IgnoreOutOfRoundness
            Monitor.Motore.CheckQuale(1, Tit1, Strin2, Ris1, Aiuto, strIDH:="CodiceCalc.htm#IgnoraOvalizzazione")
            Problem.IgnoreOutOfRoundness = Ris1(1)
        End If
        ApplicaCodice(j)
        ApplicaCodiceT(j)
        Codice = Strin1(j)
    End Sub

    Private Sub TabPrimoLivDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPrimoLivDown.SelectedIndexChanged
        Dim Index As Integer = TabPrimoLivDown.SelectedIndex
        CambiaPagina(Index)
    End Sub
    Public Sub CambiaPagina(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        Select Case Index
            Case 0 : TabCarichiDown.SelectedIndex = 0
            Case 1
                If TabTensMantDown.SelectedIndex = 0 Then
                    TabTensMantDown_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabTensMantDown.SelectedIndex = 0
                End If
            Case 2 : datisella()
            Case 3 : tirafondi()
        End Select
    End Sub
    Public Sub CambiaPaginaT(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        Select Case Index
            Case 0 : TabCarichiUp.SelectedIndex = 0
            Case 1
                If TabTensMantUp.SelectedIndex = 0 Then
                    TabTensMantUp_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabTensMantUp.SelectedIndex = 0
                End If
            Case 2 : datisellaT()
        End Select
    End Sub
    Private Sub cmdMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMat.Click
        Try
            MatShell.Agganciato = True
            MatShell.Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
            SaddlesItem.IndMatShell = MatShell.Indmat
            Text1(29).Text = MatShell.MatStr.Trim
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub cmdAmmiss_Click(ByVal sender As System.Object, ByVal ev As System.EventArgs) Handles cmdAmmiss.Click
        Dim Testo As String
        Dim NonValido As Boolean
        Dim i As Short
        Dim Re, Rm, Sfa As Single
        Dim f, E, Rea As Single
        Select Case Problem.Codice
            Case 0
                Testo = "Calcolo delle tensioni ammissibili |"
                Testo = Testo & "non disponibile per BS5500.|"
                Testo = Testo & "Bisogna fornire i dati manualmente"
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
            Case 1
                NonValido = MatShell Is Nothing
                If Not NonValido Then NonValido = MatShell.Indmat = 0
                If NonValido Then
                    Testo = "Il materiale del mantello non è stato definito correttamente."
                    MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
                    Exit Sub
                End If
                For i = 1 To 4
                    If MatShell.Caract.Item(i).TextData.Codice = 7 Then
                        Rm = MatShell.Caract.Item(i).TextData.US
                        Rea = MatShell.Caract.Item(i).TextData.Yield
                        MatShell.LeggiMat(7, SaddlesLoad(iCond).DesTemp, Sfa, Re, 1)
                        E = MatShell.EmodAlt(SaddlesLoad(iCond).DesTemp * 1.8 + 32) / PSI
                        Select Case iCond
                            Case 0, 1
                                f = 0.67 * Re
                                If 0.44 * Rm < f Then f = 0.44 * Rm
                            Case 2, 3
                                f = Rea
                                If 0.67 * Rm < f Then f = 0.67 * Rm
                                Re = Rea
                        End Select
                        With SaddlesLoad(iCond)
                            .AmmShell(0) = Re
                            .AmmShell(1) = Rm
                            .AmmShell(2) = f
                            .Young(0) = E
                            .Young(1) = 1
                            .Young(2) = 1
                            .AmmSadd(1) = 75
                            .AmmSadd(2) = 75
                            .AmmHead(1) = f 'MMMHHHHHHHHHHHHHHH!
                            .AmmHead(2) = f
                            .AmmHeadTens(1) = Calc352(SaddlesLoad(iCond), 1, SaddlesItem)
                            .AmmHeadTens(2) = Calc352(SaddlesLoad(iCond), 2, SaddlesItem)
                        End With
                        AggSaddlesPagina()
                        Exit Sub
                    End If
                Next
                Testo = "Valori Stoomwezen per il materiale|non caricati in libreria."
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
        End Select
    End Sub
    Private Sub TabCarichiDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCarichiDown.SelectedIndexChanged
        Dim Index As Integer = TabCarichiDown.SelectedIndex
        If Inizializzando Then Exit Sub
        iSottoPagina = Index
        Select Case Index
            Case 0
                iPagina = 6
                Call CarFonPagina()
                Call AggFonPagina()
            Case 1 ' carichi sui bocchelli
                iSottoSottoPagina = 0
                If TabBocchDown.SelectedIndex = 0 Then
                    TabBocchDown_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabBocchDown.SelectedIndex = 0
                End If
            Case 2 'carichi sulle fondazioni
                iSottoSottoPagina = 0
                If TabCarFondDown.SelectedIndex = 0 Then
                    TabCarFondDown_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabCarFondDown.SelectedIndex = 0
                End If
            Case 3 ' combinazioni di carico
        End Select
    End Sub
    Private Sub cmdRiprSadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRiprSadd.Click
        RiprLC(2)
        TrasfLCtoTable(2)
    End Sub
    Private Sub cmdRiprMant_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRiprMant.Click
        RiprLC(1)
        TrasfLCtoTable(1)
    End Sub
    Private Sub cmdRiprFond_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRiprFond.Click
        RiprLC(3)
        TrasfLCtoTable(3)
    End Sub
    Private Sub dgListaBocchelli_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgListaBocchelli.CurrentCellChanged
        RigaLista = dgListaBocchelli.CurrentCell.RowNumber + 1
    End Sub
    Private Sub dgListaBocchelli_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgListaBocchelli.Enter
        Dim j As Short
        Try
            dgListaBocchelli.CurrentCell = New DataGridCell(0, 1)
            For j = 1 To SaddlesItem.NumBocch
                dgListaBocchelli.CurrentCell = New DataGridCell(j - 1, 0)
            Next
        Catch ex As Exception
            ' MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub TabBocchDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabBocchDown.SelectedIndexChanged
        Dim Index As Integer = TabBocchDown.SelectedIndex
        If Inizializzando Then Exit Sub
        Inizializzando = True
        iSottoSottoPagina = Index
        Select Case Index
            Case 0
                If SaddlesItem.NumBocch > 0 Then dgListaBocchelli_Enter(Me, New EventArgs)
            Case Else
                invIniziaBocchelli()
                CalcolaRisultante()
        End Select
        Inizializzando = False
    End Sub
    Private Sub TabBocchDown_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabBocchDown.Leave
        ' If iSottoSottoPagina > 0 Then Exit Sub
        invIniziaBocchelli()
        CalcolaRisultante()
    End Sub
    Friend Sub TabCarFondDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCarFondDown.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim Index As Integer = TabCarFondDown.SelectedIndex
        Dim i, j, k As Short
        Dim dv As DataView
        Dim drv As DataRowView
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        Dim Griglia As DataGrid
        Dim r As Rectangle
        Dim delta As Short
        delta = 0
        If Index > 0 Then
            If EliminatoSisma And EliminatoVento Then
                delta = 2
            ElseIf EliminatoVento Or EliminatoSisma And Index > 1 Then
                delta = 1
            End If
        End If
        Index += delta
        Try
            If Index > 0 And Index > iSottoSottoPagina + 1 And Not GiaSotto Then
                GiaSotto = True
                For i = iSottoSottoPagina + 1 To Index
                    If i - delta > 0 And delta = 1 Or i - delta > 1 And delta = 2 Then TabCarFondDown.SelectedIndex = i - delta
                Next
                GiaSotto = False
                If delta < 2 And Not (Index = 3 And dgCarFond.TableStyles.Count = 0) Then Exit Sub
            End If
            iSottoSottoPagina = Index
            Select Case Index
                Case 0 ' Risultante bocchelli
                    If PagRisultBocchelli.Controls.Count > 1 Then
                        If Not PagRisultBocchelli.Controls(1) Is Nothing Then
                            PagRisultBocchelli.Controls(1).Dispose()
                            '  PagRisultBocchelli.Controls.RemoveAt(1)
                        End If
                    End If
                    If SaddlesItem.NumBocch = 0 Then
                        lblNienteCarichi.Visible = True
                    Else
                        lblNienteCarichi.Visible = False
                        CarBocchR = New DataTable("Risultanti")
                        With CarBocchR
                            .Columns.Add("Condizione", GetType(String))
                            For k = 1 To 6
                                .Columns.Add(Titoli(k), GetType(Single))
                            Next
                        End With
                        dv = New DataView(CarBocchR)
                        For j = 1 To Problem.NumCondElem
                            If Problem.Condiz(j).ToUpper.IndexOf("NOZZLES") > -1 Then
                                i = CShort(i + 1)
                                drv = dv.AddNew
                                drv(0) = Problem.Condiz(j).Substring(8)
                                For k = 1 To 6
                                    drv(k) = NozzleData.NozzleForcesR(i, k)
                                Next
                                drv.EndEdit()
                            End If
                        Next
                        Griglia = New DataGrid
                        Griglia.Size = dgSize ' New Size(344, 312) ' dgCarBocch1.Size
                        Griglia.Location = dgLocation ' New Point(8, 8) ' dgCarBocch1.Location
                        Griglia.CaptionVisible = True
                        Griglia.CaptionText = "Risultanti rispetto al baricentro"
                        AddHandler Griglia.Leave, AddressOf PagRisultBocchelli_Leave
                        PagRisultBocchelli.Controls.Add(Griglia)
                        t = New DataGridTableStyle
                        t.MappingName = CarBocchR.TableName
                        c = New DataGridTextBoxColumn
                        c.Width = 140
                        c.MappingName = "Condizione"
                        c.HeaderText = c.MappingName
                        t.GridColumnStyles.Add(c)
                        For k = 1 To 6
                            c = New DataGridTextBoxColumn
                            c.Width = 60
                            c.MappingName = Titoli(k)
                            c.HeaderText = c.MappingName
                            t.GridColumnStyles.Add(c)
                        Next
                        Griglia.TableStyles.Add(t)
                        Griglia.SetDataBinding(dv, "")
                        r = Griglia.GetCellBounds(Problem.NumCondBocch - 1, 6)
                        Griglia.Width = r.Left + r.Width + Griglia.RowHeaderWidth + 6
                    End If
                Case 1 'vento
                    If Not EliminatoVento Then
                        Me.txtLateralArea.Text = GlobalRoutines.FormatS(FormSng2, SaddlesItem.VesselLength * SaddlesItem.VesselOD / 1000000.0)
                        Me.txtFrontArea.Text = GlobalRoutines.FormatS(FormSng2, SaddlesItem.VesselOD ^ 2 * Math.PI / 4 / 1000000.0)
                        IniziaVento()
                        'AggiornaVento()
                        RicalcolaVento()
                    End If
                Case 2 'terremoto
                    If Not EliminatoSisma Then
                        IniziaSisma()
                        'AggiornaSisma()
                        RicalcolaSisma()
                    End If
                Case 3 ' Carichi fondazioni
                    If Not Problem.Stacked Then
                        CompilaTabCarFond()
                    Else
                        CompilaTabDaSopra()
                    End If
                Case 4 'Carichi fondazioni
                    CompilaTabCarFond()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub CompilaTabDaSopra()
        Dim i, j, k, kk As Short
        Dim dv As DataView
        Dim drv As DataRowView
        Dim c As DataGridTextBoxColumn
        Dim t As DataGridTableStyle
        Dim r As Rectangle
        CalcolaCarichi()
        LoadsCalcolate = True
        CarDaSopra = New DataTable("CarDaSopra")
        With CarDaSopra
            .Columns.Add("Condizione", GetType(String))
            For k = 1 To 8
                .Columns.Add(Titol2(k), GetType(Single))
            Next
        End With
        dv = New DataView(CarDaSopra)
        For j = 1 To Problem.NumCondElem
            drv = dv.AddNew
            drv(0) = Problem.Condiz(j)
            For i = 1 To 2
                For k = 1 To 4
                    kk = (i - 1) * 4 + k
                    drv(kk) = SforziFromTop.SforziFromTop(i, j, k)
                Next
                drv.EndEdit()
            Next
        Next
        t = New DataGridTableStyle
        t.MappingName = CarDaSopra.TableName
        c = New DataGridTextBoxColumn
        c.Width = 124
        c.MappingName = "Condizione"
        c.HeaderText = c.MappingName
        AddHandler c.TextBox.TextChanged, AddressOf CarDaSopraTextChanged
        t.GridColumnStyles.Add(c)
        For k = 1 To 8
            c = New DataGridTextBoxColumn
            c.Width = 48
            c.MappingName = Titol2(k)
            c.HeaderText = Titol1(k)
            AddHandler c.TextBox.TextChanged, AddressOf CarDaSopraTextChanged
            t.GridColumnStyles.Add(c)
        Next
        dgCarSopra.TableStyles.Clear()
        dgCarSopra.TableStyles.Add(t)
        dgCarSopra.SetDataBinding(dv, "")
        r = dgCarSopra.GetCellBounds(0, 8)
        dgCarSopra.Width = r.Left + r.Width + dgCarSopra.RowHeaderWidth '+ 6
    End Sub
    Private Sub CompilaTabCarFond()
        Dim i, j, k, kk As Short
        Dim dv As DataView
        Dim drv As DataRowView
        Dim c As DataGridTextBoxColumn
        Dim t As DataGridTableStyle
        Dim r As Rectangle
        CalcolaCarichi()
        LoadsCalcolate = True
        CarFond = New DataTable("CarFondazioni")
        With CarFond
            .Columns.Add("Condizione", GetType(String))
            For k = 1 To 8
                .Columns.Add(Titol2(k), GetType(Single))
            Next
        End With
        dv = New DataView(CarFond)
        For j = 1 To Problem.NumCondElem
            drv = dv.AddNew
            drv(0) = Problem.Condiz(j)
            For i = 1 To 2
                For k = 1 To 4
                    kk = (i - 1) * 4 + k
                    drv(kk) = LoadFoundData.Sforzi(i).f(j, k)
                Next
                drv.EndEdit()
            Next
        Next
        t = New DataGridTableStyle
        t.MappingName = CarFond.TableName
        c = New DataGridTextBoxColumn
        c.Width = 124
        c.MappingName = "Condizione"
        c.HeaderText = c.MappingName
        AddHandler c.TextBox.TextChanged, AddressOf CarFondTextChanged
        t.GridColumnStyles.Add(c)
        For k = 1 To 8
            c = New DataGridTextBoxColumn
            c.Width = 48
            c.MappingName = Titol2(k)
            c.HeaderText = Titol1(k)
            AddHandler c.TextBox.TextChanged, AddressOf CarFondTextChanged
            t.GridColumnStyles.Add(c)
        Next
        dgCarFond.TableStyles.Clear()
        dgCarFond.TableStyles.Add(t)
        dgCarFond.SetDataBinding(dv, "")
        r = dgCarFond.GetCellBounds(0, 8)
        dgCarFond.Width = r.Left + r.Width + dgCarFond.RowHeaderWidth '+ 6
    End Sub
    Private Sub PagRisultBocchelli_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagRisultBocchelli.Leave
        Dim i, k As Short
        If SaddlesItem.NumBocch = 0 Or Inizializzando Then Exit Sub
        For i = 1 To Math.Min(CarBocchR.Rows.Count, SaddlesItem.NumCondBocch)
            For k = 1 To 6
                NozzleData.NozzleForcesR(i, k) = CarBocchR.Rows(i - 1)(k)
            Next
        Next
    End Sub
    Private Sub CompilaTab(ByVal Stub As StubW2000.clsSW2000, ByVal ii As Integer)
        Dim i, j, k As Integer
        With Stub
            .SubstitBookM("MARK1", NozzleData.NozzleNames(ii), True)
            i = 0
            For j = 1 To Problem.NumCondElem
                If Problem.Condiz(j).ToUpper.IndexOf("NOZZLES") > -1 Then
                    i += 1
                    If i = 1 Then
                        .SubstitBookM("Condition1", Problem.Condiz(j), True)
                        For k = 1 To 6
                            .MuoviCella(1)
                            .Testo(NozzleData.NozzleForces(ii, i, k).ToString(FormInt8))
                        Next
                    Else
                        .TastoTab()
                        .Testo(Problem.Condiz(j))
                        For k = 1 To 6
                            .MuoviCella(1)
                            .Testo(NozzleData.NozzleForces(ii, i, k).ToString(FormInt8))
                        Next
                    End If
                End If
            Next
            .BorderBottom()
        End With
    End Sub
    Private Sub CompilaTabT(ByVal Stub As StubW2000.clsSW2000, ByVal ii As Integer)
        Dim i, j, k As Integer
        With Stub
            .SubstitBookM("MARK1", NozzleDataT.NozzleNames(ii), True)
            i = 0
            For j = 1 To Problem.NumCondElem
                If Problem.Condiz(j).ToUpper.IndexOf("NOZZLES") > -1 Then
                    i += 1
                    If i = 1 Then
                        .SubstitBookM("Condition1", Problem.Condiz(j), True)
                        For k = 1 To 6
                            .MuoviCella(1)
                            .Testo(NozzleDataT.NozzleForces(ii, i, k).ToString(FormInt8))
                        Next
                    Else
                        .TastoTab()
                        .Testo(Problem.Condiz(j))
                        For k = 1 To 6
                            .MuoviCella(1)
                            .Testo(NozzleDataT.NozzleForces(ii, i, k).ToString(FormInt8))
                        Next
                    End If
                End If
            Next
            .BorderBottom()
        End With
    End Sub
    Private Sub cmdRiprBocch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRiprBocch.Click
        RiprBocch()
        SaddlesItem.NumBocch = 0
        dgListaBocchelli_Enter(Me, New EventArgs)
        IniziaBocchelli()
    End Sub
    Private Sub mnuVento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVento.Click
        SetNormeVento(True)
    End Sub
    Private Sub txtLateralForce_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLateralForce.TextChanged
        LoadFoundData.LateralForce = GlobalRoutines.ValVir(txtLateralForce.Text)
    End Sub
    Private Sub txtFrontForce_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrontForce.TextChanged
        LoadFoundData.FrontForce = GlobalRoutines.ValVir(txtFrontForce.Text)
    End Sub
    Private Sub mnuSisma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSisma.Click
        SetNormeSisma(True)
    End Sub
    Private Sub txtForceSeism_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForceSeism.TextChanged
        LoadFoundData.FrontForceS = GlobalRoutines.ValVir(txtForceSeism.Text)
        LoadFoundData.LateralForceS = GlobalRoutines.ValVir(txtForceSeism.Text)
    End Sub
    Private Sub TabTensMantDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabTensMantDown.SelectedIndexChanged
        Select Case TabTensMantDown.SelectedIndex
            Case 0 : Call datiprogetto()
            Case 1 : Call dimensioni()
        End Select
    End Sub
    Private Sub TabCombCarDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCombCarDown.SelectedIndexChanged
        invTrasfLCtoTable(iSottoSottoPagina)
        iSottoSottoPagina = TabCombCarDown.SelectedIndex + 1
    End Sub

    Private Sub cmdLibrTir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLibrTir.Click
        Dim Tir As LibMat.clsTira = New LibMat.clsTira
        Tir.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
        mioContr3(9).Text = GlobalRoutines.FormatS(FormSng2, Tir.Dnom ^ 2 * Math.PI / 4)
        mioContr3(10).Text = GlobalRoutines.FormatS(FormSng2, Tir.Diam ^ 2 * Math.PI / 4)
    End Sub

    Private Sub frmSaddles_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Monitor.Motore.Problem = Monitor.Motore.Problems("BSDD").Problem
        Monitor.Motore.About = Monitor.Motore.Problems("BSDD").About

    End Sub

    Public Sub TabCarFondUp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCarFondUp.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim Index As Integer = TabCarFondUp.SelectedIndex
        Dim i, j, k As Short
        Dim dv As DataView
        Dim drv As DataRowView
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        Dim Griglia As DataGrid
        Dim r As Rectangle
        Dim delta As Short
        delta = 0
        If Index > 0 Then
            If EliminatoSisma And EliminatoVento Then
                delta = 2
            ElseIf EliminatoVento Or EliminatoSisma And Index > 1 Then
                delta = 1
            End If
        End If
        Index += delta
        Try
            If Index > 0 And Index > iSottoSottoPaginaT + 1 And Not GiaSottoT Then
                GiaSottoT = True
                For i = iSottoSottoPaginaT + 1 To Index
                    If i - delta > 0 And delta = 1 Or i - delta > 1 And delta = 2 Then TabCarFondUp.SelectedIndex = i - delta
                Next
                GiaSottoT = False
                If delta < 2 And Not (Index = 3 And dgCarFondT.TableStyles.Count = 0) Then Exit Sub
            End If
            iSottoSottoPaginaT = Index
            Select Case Index
                Case 0 ' Risultante bocchelli
                    If PagRisultBocchelliT.Controls.Count > 1 Then
                        If Not PagRisultBocchelliT.Controls(1) Is Nothing Then
                            PagRisultBocchelliT.Controls(1).Dispose()
                            '  PagRisultBocchelli.Controls.RemoveAt(1)
                        End If
                    End If
                    If SaddlesItemT.NumBocch = 0 Then
                        lblNienteCarichiT.Visible = True
                    Else
                        lblNienteCarichiT.Visible = False
                        CarBocchRT = New DataTable("Risultanti")
                        With CarBocchRT
                            .Columns.Add("Condizione", GetType(String))
                            For k = 1 To 6
                                .Columns.Add(Titoli(k), GetType(Single))
                            Next
                        End With
                        dv = New DataView(CarBocchRT)
                        For j = 1 To Problem.NumCondElem
                            If Problem.Condiz(j).ToUpper.IndexOf("NOZZLES") > -1 Then
                                i = CShort(i + 1)
                                drv = dv.AddNew
                                drv(0) = Problem.Condiz(j).Substring(8)
                                For k = 1 To 6
                                    drv(k) = NozzleDataT.NozzleForcesR(i, k)
                                Next
                                drv.EndEdit()
                            End If
                        Next
                        Griglia = New DataGrid
                        Griglia.Size = dgSize ' New Size(344, 312) ' dgCarBocch1.Size
                        Griglia.Location = dgLocation ' New Point(8, 8) ' dgCarBocch1.Location
                        Griglia.CaptionVisible = True
                        Griglia.CaptionText = "Risultanti rispetto al baricentro"
                        AddHandler Griglia.Leave, AddressOf PagRisultBocchelliT_Leave
                        PagRisultBocchelliT.Controls.Add(Griglia)
                        t = New DataGridTableStyle
                        t.MappingName = CarBocchRT.TableName
                        c = New DataGridTextBoxColumn
                        c.Width = 140
                        c.MappingName = "Condizione"
                        c.HeaderText = c.MappingName
                        t.GridColumnStyles.Add(c)
                        For k = 1 To 6
                            c = New DataGridTextBoxColumn
                            c.Width = 60
                            c.MappingName = Titoli(k)
                            c.HeaderText = c.MappingName
                            t.GridColumnStyles.Add(c)
                        Next
                        Griglia.TableStyles.Add(t)
                        Griglia.SetDataBinding(dv, "")
                        r = Griglia.GetCellBounds(SaddlesItemT.NumCondBocch - 1, 6)
                        Griglia.Width = r.Left + r.Width + Griglia.RowHeaderWidth + 6
                    End If
                Case 1 'vento
                    If Not EliminatoVento Then
                        Me.txtLateralAreaT.Text = GlobalRoutines.FormatS(FormSng2, SaddlesItemT.VesselLength * SaddlesItemT.VesselOD / 1000000.0)
                        Me.txtFrontAreaT.Text = GlobalRoutines.FormatS(FormSng2, SaddlesItemT.VesselOD ^ 2 * Math.PI / 4 / 1000000.0)
                        IniziaVentoT()
                        RicalcolaVentoT()
                    End If
                Case 2 'terremoto
                    If Not EliminatoSisma Then
                        IniziaSismaT()
                        RicalcolaSismaT()
                    End If
                Case 3 ' Carichi fondazioni
                    Dim kk As Short
                    CalcolaCarichiT()
                    LoadsCalcolate = True
                    CarFondT = New DataTable("CarFondazioni")
                    With CarFondT
                        .Columns.Add("Condizione", GetType(String))
                        For k = 1 To 8
                            .Columns.Add(Titol2(k), GetType(Single))
                        Next
                    End With
                    dv = New DataView(CarFondT)
                    For j = 1 To Problem.NumCondElem
                        drv = dv.AddNew
                        drv(0) = Problem.Condiz(j)
                        For i = 1 To 2
                            For k = 1 To 4
                                kk = (i - 1) * 4 + k
                                drv(kk) = LoadFoundDataT.Sforzi(i).f(j, k)
                            Next
                            drv.EndEdit()
                        Next
                    Next
                    t = New DataGridTableStyle
                    t.MappingName = CarFondT.TableName
                    c = New DataGridTextBoxColumn
                    c.Width = 124
                    c.MappingName = "Condizione"
                    c.HeaderText = c.MappingName
                    AddHandler c.TextBox.TextChanged, AddressOf CarFondTTextChanged
                    t.GridColumnStyles.Add(c)
                    For k = 1 To 8
                        c = New DataGridTextBoxColumn
                        c.Width = 48
                        c.MappingName = Titol2(k)
                        c.HeaderText = Titol1(k)
                        AddHandler c.TextBox.TextChanged, AddressOf CarFondTTextChanged
                        t.GridColumnStyles.Add(c)
                    Next
                    dgCarFondT.TableStyles.Clear()
                    dgCarFondT.TableStyles.Add(t)
                    dgCarFondT.SetDataBinding(dv, "")
                    r = dgCarFondT.GetCellBounds(0, 8)
                    dgCarFondT.Width = r.Left + r.Width + dgCarFondT.RowHeaderWidth '+ 6
            End Select
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub TabPrimoLivUp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPrimoLivUp.SelectedIndexChanged
        Dim Index As Integer = TabPrimoLivUp.SelectedIndex
        CambiaPaginaT(Index)
    End Sub
    Public Sub mnuStacked_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuStacked.Click
        mnuStacked.Checked = Not mnuStacked.Checked
        If mnuStacked.Checked Then
            AggiungiScheda()
            Problem.Stacked = True
            PagUp.Enabled = True
            lblNota.Visible = True
        Else
            TogliScheda()
            Problem.Stacked = False
            Me.TabMain.SelectedIndex = 0
            PagUp.Enabled = False
            lblNota.Visible = False
        End If
        TabMain.Invalidate(False)
        TabMain.Update()
    End Sub
    Private Sub TogliScheda()
        If Not TabCarFondDown.Controls.Contains(PagCarichiDaSopra) Then Exit Sub
        Inizializzando = True
        TabCarFondDown.Controls.Remove(Me.PagCarichiDaSopra)
        Inizializzando = False
    End Sub
    Private Sub AggiungiScheda()
        If TabCarFondDown.Controls.Contains(PagCarichiDaSopra) Then Exit Sub
        Inizializzando = True
        TabCarFondDown.Controls.Remove(PagCarichiFinali)
        TabCarFondDown.Controls.Add(Me.PagCarichiDaSopra)
        TabCarFondDown.Controls.Add(PagCarichiFinali)
        Inizializzando = False
    End Sub
    Private Sub TabMain_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabMain.DrawItem
        Dim fntTab As Font
        Dim bshBack As Brush
        Dim bshFore As Brush
        Dim t As TabPage = TabMain.TabPages(e.Index)
        Dim tabName As String = t.Text
        bshBack = New SolidBrush(SystemColors.Control)
        fntTab = e.Font
        If Not TabMain.Enabled Or Not t.Enabled Then
            bshFore = New HatchBrush(HatchStyle.Percent70, Color.Black, SystemColors.Control)
        Else
            bshFore = New SolidBrush(Color.Black)
        End If
        Dim sftTab As StringFormat = New StringFormat
        e.Graphics.FillRectangle(bshBack, e.Bounds)
        Dim x As Single = e.Bounds.X + 2
        Dim y As Single = e.Bounds.Y + 2
        e.Graphics.DrawString(tabName, fntTab, bshFore, x, y, sftTab)
    End Sub

    Private Sub TabPrimoLivDown_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabPrimoLivDown.DrawItem
        Dim fntTab As Font
        Dim bshBack As Brush
        Dim bshFore As Brush
        bshBack = New SolidBrush(SystemColors.Control)
        fntTab = e.Font
        If Not TabPrimoLivDown.Enabled Then
            bshFore = New HatchBrush(HatchStyle.Percent70, Color.Black, SystemColors.Control)
        Else
            bshFore = New SolidBrush(Color.Black)
        End If
        Dim tabName As String = TabPrimoLivDown.TabPages(e.Index).Text
        Dim sftTab As StringFormat = New StringFormat
        e.Graphics.FillRectangle(bshBack, e.Bounds)
        Dim x As Single = e.Bounds.X + 2
        Dim y As Single = e.Bounds.Y + 2
        e.Graphics.DrawString(tabName, fntTab, bshFore, x, y, sftTab)

    End Sub

    Private Sub TabCarichiDown_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabCarichiDown.DrawItem
        Dim fntTab As Font
        Dim bshBack As Brush
        Dim bshFore As Brush
        bshBack = New SolidBrush(SystemColors.Control)
        fntTab = e.Font
        If Not TabCarichiDown.Enabled Then
            bshFore = New HatchBrush(HatchStyle.Percent70, Color.Black, SystemColors.Control)
        Else
            bshFore = New SolidBrush(Color.Black)
        End If
        Dim tabName As String = TabCarichiDown.TabPages(e.Index).Text
        Dim sftTab As StringFormat = New StringFormat
        e.Graphics.FillRectangle(bshBack, e.Bounds)
        Dim x As Single = e.Bounds.X + 2
        Dim y As Single = e.Bounds.Y + 2
        e.Graphics.DrawString(tabName, fntTab, bshFore, x, y, sftTab)

    End Sub
    Private Sub TabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabMain.SelectedIndexChanged
        Dim i As Short = TabMain.SelectedIndex
        If i > 0 And Not TabMain.TabPages(i).Enabled Then
            TabMain.SelectedIndex = i - 1
        ElseIf i = 0 Then
            '      TabCarichiDown.Select()
            If iPagina = 6 Then
                Dim iSS As Short = iSottoSottoPagina
                ChiudiOLE()
                If iSottoPagina = 2 And iSS < 3 Then
                    TabCarFondDown.SelectedIndex = iSS
                End If
            End If
        Else
            If iPaginaT = 6 Then
                Dim iSS As Short = iSottoSottoPaginaT
                ChiudiOLET()
                If iSottoPaginaT = 2 And iSS < 3 Then
                    TabCarFondUp.SelectedIndex = iSS
                End If
            Else
                TabCarichiUp.Select()
                If TabCarichiUp.SelectedIndex = 0 Then
                    TabCarichiUp_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabCarichiUp.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub TabCarichiUp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCarichiUp.SelectedIndexChanged
        Dim Index As Integer = TabCarichiUp.SelectedIndex
        If Inizializzando Then Exit Sub
        iSottoPaginaT = Index
        Select Case Index
            Case 0
                iPaginaT = 6
                Call CarFonPaginaT()
                Call AggFonPaginaT()
            Case 1 ' carichi sui bocchelli
                iSottoSottoPaginaT = 0
                If TabBocchUp.SelectedIndex = 0 Then
                    TabBocchUp_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabBocchUp.SelectedIndex = 0
                End If
            Case 2 'carichi sulle fondazioni
                iSottoSottoPaginaT = 0
                If TabCarFondUp.SelectedIndex = 0 Then
                    TabCarFondUp_SelectedIndexChanged(Me, New EventArgs)
                Else
                    TabCarFondUp.SelectedIndex = 0
                End If
            Case 3 ' combinazioni di carico
        End Select

    End Sub

    Private Sub TabBocchUp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabBocchUp.SelectedIndexChanged
        Dim Index As Integer = TabBocchUp.SelectedIndex
        If Inizializzando Then Exit Sub
        Inizializzando = True
        iSottoSottoPaginaT = Index
        Select Case Index
            Case 0
                dgListaBocchelliT_Enter(Me, New EventArgs)
            Case Else
                invIniziaBocchelliT()
                CalcolaRisultanteT()
        End Select
        Inizializzando = False

    End Sub

    Private Sub TabBocchUp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabBocchUp.Leave
        invIniziaBocchelliT()
        CalcolaRisultanteT()
    End Sub

    Private Sub dgListaBocchelliT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgListaBocchelliT.Enter
        Dim j As Short
        Try
            dgListaBocchelliT.CurrentCell = New DataGridCell(0, 1)
            For j = 1 To SaddlesItemT.NumBocch
                dgListaBocchelliT.CurrentCell = New DataGridCell(j - 1, 0)
            Next
        Catch ex As Exception
            'MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Private Sub PagRisultBocchelliT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagRisultBocchelliT.Leave
        Dim i, k As Short
        If SaddlesItemT.NumBocch = 0 Or Inizializzando Then Exit Sub
        For i = 1 To SaddlesItemT.NumCondBocchT
            For k = 1 To 6
                NozzleDataT.NozzleForcesR(i, k) = CarBocchRT.Rows(i - 1)(k)
            Next
        Next

    End Sub

    Private Sub TabTensMantUp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabTensMantUp.SelectedIndexChanged
        Select Case TabTensMantUp.SelectedIndex
            Case 0 : Call datiprogettoT()
            Case 1 : Call dimensioniT()
        End Select

    End Sub

    Private Sub cmdRiprBocchT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRiprBocchT.Click
        RiprBocchT()
        SaddlesItemT.NumBocch = 0
        dgListaBocchelliT_Enter(Me, New EventArgs)
        IniziaBocchelliT()
    End Sub

    Private Sub cmdAmmissT_Click(ByVal sender As Object, ByVal ev As System.EventArgs) Handles cmdAmmissT.Click
        Dim Testo As String
        Dim NonValido As Boolean
        Dim i As Short
        Dim Re, Rm, Sfa As Single
        Dim f, E, Rea As Single
        Select Case Problem.Codice
            Case 0
                Testo = "Calcolo delle tensioni ammissibili |"
                Testo = Testo & "non disponibile per BS5500.|"
                Testo = Testo & "Bisogna fornire i dati manualmente"
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
            Case 1
                NonValido = MatShellT Is Nothing
                If Not NonValido Then NonValido = MatShellT.Indmat = 0
                If NonValido Then
                    Testo = "Il materiale del mantello non è stato definito correttamente."
                    MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
                    Exit Sub
                End If
                For i = 1 To 4
                    If MatShellT.Caract.Item(i).TextData.Codice = 7 Then
                        Rm = MatShellT.Caract.Item(i).TextData.US
                        Rea = MatShellT.Caract.Item(i).TextData.Yield
                        MatShellT.LeggiMat(7, SaddlesLoadT(iCond).DesTemp, Sfa, Re, 1)
                        E = MatShellT.EmodAlt(SaddlesLoadT(iCond).DesTemp * 1.8 + 32) / PSI
                        Select Case iCond
                            Case 0, 1
                                f = 0.67 * Re
                                If 0.44 * Rm < f Then f = 0.44 * Rm
                            Case 2, 3
                                f = Rea
                                If 0.67 * Rm < f Then f = 0.67 * Rm
                                Re = Rea
                        End Select
                        With SaddlesLoadT(iCond)
                            .AmmShell(0) = Re
                            .AmmShell(1) = Rm
                            .AmmShell(2) = f
                            .Young(0) = E
                            .Young(1) = 1
                            .Young(2) = 1
                            .AmmSadd(1) = 75
                            .AmmSadd(2) = 75
                            .AmmHead(1) = f 'MMMHHHHHHHHHHHHHHH!
                            .AmmHead(2) = f
                            .AmmHeadTens(1) = Calc352(SaddlesLoadT(iCond), 1, SaddlesItemT)
                            .AmmHeadTens(2) = Calc352(SaddlesLoadT(iCond), 2, SaddlesItemT)
                        End With
                        AggSaddlesPaginaT()
                        Exit Sub
                    End If
                Next
                Testo = "Valori Stoomwezen per il materiale|non caricati in libreria."
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
        End Select

    End Sub
    Private Sub TabTensMantDown_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabTensMantDown.Resize
        If Inizializzando Then Exit Sub
        TabPrimoLivDown.Height = Math.Max(TabPrimoLivDown.Height, TabTensMantDown.Top + TabTensMantDown.Height _
                             + TabPrimoLivDown.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
    End Sub
    Private Sub TabPrimoLivDown_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPrimoLivDown.Resize
        If Inizializzando Then Exit Sub
        TabMain.Height = Math.Max(TabMain.Height, TabPrimoLivDown.Top + TabPrimoLivDown.Height _
                             + TabMain.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
    End Sub
    Private Sub TabTensMantUp_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabTensMantUp.Resize
        If Inizializzando Then Exit Sub
        TabPrimoLivUp.Height = Math.Max(TabPrimoLivUp.Height, TabTensMantUp.Top + TabTensMantUp.Height _
                             + TabPrimoLivUp.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
    End Sub
    Private Sub TabPrimoLivUp_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPrimoLivUp.Resize
        If Inizializzando Then Exit Sub
        TabMain.Height = Math.Max(TabMain.Height, TabPrimoLivUp.Top + TabPrimoLivUp.Height _
                             + TabMain.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
    End Sub
    Private Sub TabMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabMain.Resize
        If Inizializzando Then Exit Sub
        Height = Math.Max(Height, CInt(TabMain.Top + TabMain.Height + _
                 SystemInformation.CaptionHeight + SystemInformation.MenuHeight + 8 * SystemInformation.Border3DSize.Height))
    End Sub
    Private Sub cmdMatT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMatT.Click
        Try
            MatShellT.Agganciato = True
            MatShellT.Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
            SaddlesItemT.IndMatShell = MatShellT.Indmat
            Text1T(29).Text = MatShellT.MatStr.Trim
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Private Sub txtLateralForceT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLateralForceT.TextChanged
        LoadFoundDataT.LateralForce = GlobalRoutines.ValVir(txtLateralForceT.Text)
    End Sub

    Private Sub txtFrontForceT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrontForceT.TextChanged
        LoadFoundDataT.FrontForce = GlobalRoutines.ValVir(txtFrontForceT.Text)
    End Sub

    Private Sub txtForceSeismT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForceSeismT.TextChanged
        LoadFoundDataT.FrontForceS = GlobalRoutines.ValVir(txtForceSeismT.Text)
        LoadFoundDataT.LateralForceS = GlobalRoutines.ValVir(txtForceSeismT.Text)
    End Sub
End Class
