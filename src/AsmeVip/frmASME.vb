Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class Apert
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
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
    Public WithEvents _Frames_2 As System.Windows.Forms.GroupBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
	Public WithEvents _cmdVisual_1 As System.Windows.Forms.Button
	Public WithEvents _cmdVisual_0 As System.Windows.Forms.Button
	Public WithEvents cmdClear As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _Frames_0 As System.Windows.Forms.GroupBox
    Public WithEvents cmdDati As System.Windows.Forms.Button
	Public WithEvents cmdCalc As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _Frames_1 As System.Windows.Forms.GroupBox
    Public WithEvents mnuApri As System.Windows.Forms.MenuItem
	Public WithEvents mnuSalva As System.Windows.Forms.MenuItem
	Public WithEvents mnuSalvaCome As System.Windows.Forms.MenuItem
	Public WithEvents mnuChiudi As System.Windows.Forms.MenuItem
	Public WithEvents mnuEsci As System.Windows.Forms.MenuItem
	Public WithEvents bigMenu As System.Windows.Forms.MenuItem
	Public WithEvents mnuTuttiDati As System.Windows.Forms.MenuItem
	Public WithEvents mnuDatiContr As System.Windows.Forms.MenuItem
	Public WithEvents mnuDatiElem As System.Windows.Forms.MenuItem
	Public WithEvents mnuConvElem As System.Windows.Forms.MenuItem
	Public WithEvents mnuInseElem As System.Windows.Forms.MenuItem
	Public WithEvents mnuElimElemento As System.Windows.Forms.MenuItem
	Public WithEvents mnuDati As System.Windows.Forms.MenuItem
	Public WithEvents mnuCalcTutti As System.Windows.Forms.MenuItem
	Public WithEvents mnuCalcAuto As System.Windows.Forms.MenuItem
	Public WithEvents mnuCalcElem As System.Windows.Forms.MenuItem
	Public WithEvents mnuWRCB As System.Windows.Forms.MenuItem
	Public WithEvents mnuCalc As System.Windows.Forms.MenuItem
	Public WithEvents mnuTTab As System.Windows.Forms.MenuItem
	Public WithEvents mnuRiga As System.Windows.Forms.MenuItem
	Public WithEvents mnuTabMat As System.Windows.Forms.MenuItem
	Public WithEvents mnuTabDesign As System.Windows.Forms.MenuItem
	Public WithEvents mnuTabMAWP As System.Windows.Forms.MenuItem
	Public WithEvents mnuTabPI As System.Windows.Forms.MenuItem
	Public WithEvents mnuTabReqRes As System.Windows.Forms.MenuItem
	Public WithEvents mnuCompil As System.Windows.Forms.MenuItem
	Public WithEvents _mnuDis_0 As System.Windows.Forms.MenuItem
	Public WithEvents _mnuDis_1 As System.Windows.Forms.MenuItem
	Public WithEvents mnuDis0 As System.Windows.Forms.MenuItem
	Public WithEvents mnuAree As System.Windows.Forms.MenuItem
	Public WithEvents mnuTipo As System.Windows.Forms.MenuItem
	Public WithEvents mnuLibr As System.Windows.Forms.MenuItem
	Public WithEvents mnuCoor As System.Windows.Forms.MenuItem
	Public WithEvents _mnuEdiz_0 As System.Windows.Forms.MenuItem
	Public WithEvents _mnuEdiz_1 As System.Windows.Forms.MenuItem
	Public WithEvents mnuEdiz0 As System.Windows.Forms.MenuItem
	Public WithEvents mnuUG40 As System.Windows.Forms.MenuItem
	Public WithEvents mnu As System.Windows.Forms.MenuItem
	Public WithEvents mnuComment As System.Windows.Forms.MenuItem
	Public WithEvents mnuPref As System.Windows.Forms.MenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Public WithEvents mnuInf As System.Windows.Forms.MenuItem
	Public WithEvents _mnuAiuto_0 As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstRapp As System.Windows.Forms.ListView
    Friend WithEvents lstRes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents CommonDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CommonDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuUG22 As System.Windows.Forms.MenuItem
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents mnuWordIn As System.Windows.Forms.MenuItem
    Friend WithEvents TabRapporto As System.Windows.Forms.TabControl
    Friend WithEvents wordPanel As Lancio.Office.Word.WinForms.WordReportPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Apert))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Frames_2 = New System.Windows.Forms.GroupBox
        Me.TabRapporto = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lstRes = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.wordPanel = New Lancio.Office.Word.WinForms.WordReportPanel
        Me._Frames_0 = New System.Windows.Forms.GroupBox
        Me.lstRapp = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me._cmdVisual_1 = New System.Windows.Forms.Button
        Me._cmdVisual_0 = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me._Frames_1 = New System.Windows.Forms.GroupBox
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdDati = New System.Windows.Forms.Button
        Me.cmdCalc = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._mnuAiuto_0 = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuInf = New System.Windows.Forms.MenuItem
        Me._mnuDis_0 = New System.Windows.Forms.MenuItem
        Me._mnuDis_1 = New System.Windows.Forms.MenuItem
        Me._mnuEdiz_0 = New System.Windows.Forms.MenuItem
        Me._mnuEdiz_1 = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.bigMenu = New System.Windows.Forms.MenuItem
        Me.mnuApri = New System.Windows.Forms.MenuItem
        Me.mnuSalva = New System.Windows.Forms.MenuItem
        Me.mnuSalvaCome = New System.Windows.Forms.MenuItem
        Me.mnuChiudi = New System.Windows.Forms.MenuItem
        Me.mnuEsci = New System.Windows.Forms.MenuItem
        Me.mnuDati = New System.Windows.Forms.MenuItem
        Me.mnuTuttiDati = New System.Windows.Forms.MenuItem
        Me.mnuDatiContr = New System.Windows.Forms.MenuItem
        Me.mnuDatiElem = New System.Windows.Forms.MenuItem
        Me.mnuConvElem = New System.Windows.Forms.MenuItem
        Me.mnuInseElem = New System.Windows.Forms.MenuItem
        Me.mnuElimElemento = New System.Windows.Forms.MenuItem
        Me.mnuCalc = New System.Windows.Forms.MenuItem
        Me.mnuCalcTutti = New System.Windows.Forms.MenuItem
        Me.mnuCalcAuto = New System.Windows.Forms.MenuItem
        Me.mnuCalcElem = New System.Windows.Forms.MenuItem
        Me.mnuWRCB = New System.Windows.Forms.MenuItem
        Me.mnuCompil = New System.Windows.Forms.MenuItem
        Me.mnuTTab = New System.Windows.Forms.MenuItem
        Me.mnuRiga = New System.Windows.Forms.MenuItem
        Me.mnuTabMat = New System.Windows.Forms.MenuItem
        Me.mnuTabDesign = New System.Windows.Forms.MenuItem
        Me.mnuTabMAWP = New System.Windows.Forms.MenuItem
        Me.mnuTabPI = New System.Windows.Forms.MenuItem
        Me.mnuTabReqRes = New System.Windows.Forms.MenuItem
        Me.mnuDis0 = New System.Windows.Forms.MenuItem
        Me.mnuPref = New System.Windows.Forms.MenuItem
        Me.mnuAree = New System.Windows.Forms.MenuItem
        Me.mnuTipo = New System.Windows.Forms.MenuItem
        Me.mnuLibr = New System.Windows.Forms.MenuItem
        Me.mnuCoor = New System.Windows.Forms.MenuItem
        Me.mnuEdiz0 = New System.Windows.Forms.MenuItem
        Me.mnuUG22 = New System.Windows.Forms.MenuItem
        Me.mnuUG40 = New System.Windows.Forms.MenuItem
        Me.mnu = New System.Windows.Forms.MenuItem
        Me.mnuComment = New System.Windows.Forms.MenuItem
        Me.mnuWordIn = New System.Windows.Forms.MenuItem
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel
        Me.CommonDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.CommonDialog2 = New System.Windows.Forms.SaveFileDialog
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me._Frames_2.SuspendLayout()
        Me.TabRapporto.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me._Frames_0.SuspendLayout()
        Me._Frames_1.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_Frames_2
        '
        Me._Frames_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Frames_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_2.Controls.Add(Me.TabRapporto)
        Me._Frames_2.ForeColor = System.Drawing.Color.Yellow
        Me._Frames_2.Location = New System.Drawing.Point(488, 0)
        Me._Frames_2.Name = "_Frames_2"
        Me._Frames_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_2.Size = New System.Drawing.Size(265, 465)
        Me._Frames_2.TabIndex = 11
        Me._Frames_2.TabStop = False
        Me._Frames_2.Text = "Risultati del calcolo"
        Me._Frames_2.Visible = False
        '
        'TabRapporto
        '
        Me.TabRapporto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabRapporto.Controls.Add(Me.TabPage1)
        Me.TabRapporto.Controls.Add(Me.TabPage2)
        Me.TabRapporto.Location = New System.Drawing.Point(0, 16)
        Me.TabRapporto.Name = "TabRapporto"
        Me.TabRapporto.SelectedIndex = 0
        Me.TabRapporto.Size = New System.Drawing.Size(264, 448)
        Me.TabRapporto.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstRes)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(256, 421)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Diario"
        '
        'lstRes
        '
        Me.lstRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstRes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstRes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstRes.Location = New System.Drawing.Point(4, 8)
        Me.lstRes.MultiSelect = False
        Me.lstRes.Name = "lstRes"
        Me.lstRes.Size = New System.Drawing.Size(248, 408)
        Me.lstRes.TabIndex = 13
        Me.lstRes.View = System.Windows.Forms.View.List
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 256
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.wordPanel)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(256, 421)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Rapporto"
        '
        'wordPanel
        '
        Me.wordPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wordPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.wordPanel.Location = New System.Drawing.Point(4, 4)
        Me.wordPanel.Name = "wordPanel"
        Me.wordPanel.Size = New System.Drawing.Size(246, 412)
        Me.wordPanel.TabIndex = 0
        '
        '_Frames_0
        '
        Me._Frames_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_0.Controls.Add(Me.lstRapp)
        Me._Frames_0.Controls.Add(Me.Text1)
        Me._Frames_0.Controls.Add(Me.Check1)
        Me._Frames_0.Controls.Add(Me._cmdVisual_1)
        Me._Frames_0.Controls.Add(Me._cmdVisual_0)
        Me._Frames_0.Controls.Add(Me.cmdClear)
        Me._Frames_0.Controls.Add(Me.Label1)
        Me._Frames_0.ForeColor = System.Drawing.Color.Yellow
        Me._Frames_0.Location = New System.Drawing.Point(256, 0)
        Me._Frames_0.Name = "_Frames_0"
        Me._Frames_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_0.Size = New System.Drawing.Size(233, 465)
        Me._Frames_0.TabIndex = 1
        Me._Frames_0.TabStop = False
        Me._Frames_0.Text = "Composizione rapporto"
        Me._Frames_0.Visible = False
        '
        'lstRapp
        '
        Me.lstRapp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstRapp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstRapp.Location = New System.Drawing.Point(8, 88)
        Me.lstRapp.MultiSelect = False
        Me.lstRapp.Name = "lstRapp"
        Me.lstRapp.Size = New System.Drawing.Size(216, 368)
        Me.lstRapp.TabIndex = 11
        Me.lstRapp.View = System.Windows.Forms.View.Details
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.AutoSize = False
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(40, 64)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(177, 19)
        Me.Text1.TabIndex = 9
        Me.Text1.Text = "Text1"
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Checked = True
        Me.Check1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 40)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(217, 25)
        Me.Check1.TabIndex = 8
        Me.Check1.Text = "Con indice e intestazioni"
        '
        '_cmdVisual_1
        '
        Me._cmdVisual_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdVisual_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdVisual_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdVisual_1.Location = New System.Drawing.Point(152, 16)
        Me._cmdVisual_1.Name = "_cmdVisual_1"
        Me._cmdVisual_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdVisual_1.Size = New System.Drawing.Size(73, 25)
        Me._cmdVisual_1.TabIndex = 7
        Me._cmdVisual_1.Text = "Vis. tutto"
        '
        '_cmdVisual_0
        '
        Me._cmdVisual_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdVisual_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdVisual_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdVisual_0.Location = New System.Drawing.Point(64, 16)
        Me._cmdVisual_0.Name = "_cmdVisual_0"
        Me._cmdVisual_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdVisual_0.Size = New System.Drawing.Size(89, 25)
        Me._cmdVisual_0.TabIndex = 6
        Me._cmdVisual_0.Text = "Visualizza"
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClear.Location = New System.Drawing.Point(8, 16)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClear.Size = New System.Drawing.Size(57, 25)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "File: "
        '
        '_Frames_1
        '
        Me._Frames_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_1.Controls.Add(Me.TreeView1)
        Me._Frames_1.Controls.Add(Me.cmdDati)
        Me._Frames_1.Controls.Add(Me.cmdCalc)
        Me._Frames_1.Controls.Add(Me.Command1)
        Me._Frames_1.ForeColor = System.Drawing.Color.Yellow
        Me._Frames_1.Location = New System.Drawing.Point(0, 0)
        Me._Frames_1.Name = "_Frames_1"
        Me._Frames_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_1.Size = New System.Drawing.Size(257, 465)
        Me._Frames_1.TabIndex = 0
        Me._Frames_1.TabStop = False
        Me._Frames_1.Text = "Struttura apparecchio"
        Me._Frames_1.Visible = False
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.HideSelection = False
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.LabelEdit = True
        Me.TreeView1.Location = New System.Drawing.Point(8, 48)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(240, 408)
        Me.TreeView1.TabIndex = 16
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(36, 36)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmdDati
        '
        Me.cmdDati.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDati.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDati.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDati.Location = New System.Drawing.Point(8, 16)
        Me.cmdDati.Name = "cmdDati"
        Me.cmdDati.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDati.Size = New System.Drawing.Size(57, 25)
        Me.cmdDati.TabIndex = 4
        Me.cmdDati.Text = "Dati"
        '
        'cmdCalc
        '
        Me.cmdCalc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalc.Location = New System.Drawing.Point(64, 16)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalc.Size = New System.Drawing.Size(57, 25)
        Me.cmdCalc.TabIndex = 3
        Me.cmdCalc.Text = "Calcola"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(120, 16)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(73, 25)
        Me.Command1.TabIndex = 2
        Me.Command1.Text = "Espandi"
        '
        '_mnuAiuto_0
        '
        Me._mnuAiuto_0.Index = 6
        Me._mnuAiuto_0.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelp, Me.mnuInf})
        Me._mnuAiuto_0.Text = "?"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 0
        Me.mnuHelp.Text = "Aiuto in Linea"
        '
        'mnuInf
        '
        Me.mnuInf.Index = 1
        Me.mnuInf.Text = "Informazioni "
        '
        '_mnuDis_0
        '
        Me._mnuDis_0.Index = 0
        Me._mnuDis_0.Text = "Aggiorna commessa"
        '
        '_mnuDis_1
        '
        Me._mnuDis_1.Index = 1
        Me._mnuDis_1.Text = "Disegno/distinta"
        '
        '_mnuEdiz_0
        '
        Me._mnuEdiz_0.Index = 0
        Me._mnuEdiz_0.Text = "Ed. ASMEVIII applicabile"
        '
        '_mnuEdiz_1
        '
        Me._mnuEdiz_1.Index = 1
        Me._mnuEdiz_1.Text = "Addenda ASME applicabile"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.bigMenu, Me.mnuDati, Me.mnuCalc, Me.mnuCompil, Me.mnuDis0, Me.mnuPref, Me._mnuAiuto_0})
        '
        'bigMenu
        '
        Me.bigMenu.Index = 0
        Me.bigMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuApri, Me.mnuSalva, Me.mnuSalvaCome, Me.mnuChiudi, Me.mnuEsci})
        Me.bigMenu.Text = "&File"
        '
        'mnuApri
        '
        Me.mnuApri.Index = 0
        Me.mnuApri.Text = "&Apri"
        '
        'mnuSalva
        '
        Me.mnuSalva.Index = 1
        Me.mnuSalva.Text = "&Salva"
        '
        'mnuSalvaCome
        '
        Me.mnuSalvaCome.Index = 2
        Me.mnuSalvaCome.Text = "Salva come ..."
        '
        'mnuChiudi
        '
        Me.mnuChiudi.Index = 3
        Me.mnuChiudi.Text = "&Chiudi"
        '
        'mnuEsci
        '
        Me.mnuEsci.Index = 4
        Me.mnuEsci.Text = "&Esci"
        '
        'mnuDati
        '
        Me.mnuDati.Index = 1
        Me.mnuDati.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTuttiDati, Me.mnuDatiContr, Me.mnuDatiElem, Me.mnuConvElem, Me.mnuInseElem, Me.mnuElimElemento})
        Me.mnuDati.Text = "&Dati"
        '
        'mnuTuttiDati
        '
        Me.mnuTuttiDati.Index = 0
        Me.mnuTuttiDati.Text = "&Tutti i dati"
        '
        'mnuDatiContr
        '
        Me.mnuDatiContr.Index = 1
        Me.mnuDatiContr.Text = "Dati &generali"
        '
        'mnuDatiElem
        '
        Me.mnuDatiElem.Index = 2
        Me.mnuDatiElem.Text = "Dati &Elemento"
        '
        'mnuConvElem
        '
        Me.mnuConvElem.Index = 3
        Me.mnuConvElem.Text = "&Converti Elemento"
        '
        'mnuInseElem
        '
        Me.mnuInseElem.Index = 4
        Me.mnuInseElem.Text = "&Inserisci elemento"
        '
        'mnuElimElemento
        '
        Me.mnuElimElemento.Index = 5
        Me.mnuElimElemento.Text = "&Elimina elemento"
        '
        'mnuCalc
        '
        Me.mnuCalc.Index = 2
        Me.mnuCalc.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCalcTutti, Me.mnuCalcAuto, Me.mnuCalcElem, Me.mnuWRCB})
        Me.mnuCalc.Text = "&Calcoli"
        '
        'mnuCalcTutti
        '
        Me.mnuCalcTutti.Index = 0
        Me.mnuCalcTutti.Text = "&Tutti i calcoli in sequenza"
        '
        'mnuCalcAuto
        '
        Me.mnuCalcAuto.Index = 1
        Me.mnuCalcAuto.Text = "Tutti i calcoli in automatico"
        '
        'mnuCalcElem
        '
        Me.mnuCalcElem.Index = 2
        Me.mnuCalcElem.Text = "&Elemento"
        '
        'mnuWRCB
        '
        Me.mnuWRCB.Index = 3
        Me.mnuWRCB.Text = "&Carichi sui Bocchelli"
        '
        'mnuCompil
        '
        Me.mnuCompil.Index = 3
        Me.mnuCompil.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTTab, Me.mnuRiga, Me.mnuTabMat, Me.mnuTabDesign, Me.mnuTabMAWP, Me.mnuTabPI, Me.mnuTabReqRes})
        Me.mnuCompil.Text = "Co&mpilazione tabelle"
        '
        'mnuTTab
        '
        Me.mnuTTab.Index = 0
        Me.mnuTTab.Text = "Tutte le tabelle"
        '
        'mnuRiga
        '
        Me.mnuRiga.Index = 1
        Me.mnuRiga.Text = "-"
        '
        'mnuTabMat
        '
        Me.mnuTabMat.Index = 2
        Me.mnuTabMat.Text = "Tabella materiali"
        '
        'mnuTabDesign
        '
        Me.mnuTabDesign.Index = 3
        Me.mnuTabDesign.Text = "Dati di progetto"
        '
        'mnuTabMAWP
        '
        Me.mnuTabMAWP.Index = 4
        Me.mnuTabMAWP.Text = "Tabella MAWP"
        '
        'mnuTabPI
        '
        Me.mnuTabPI.Index = 5
        Me.mnuTabPI.Text = "Calcolo pressione P.I."
        '
        'mnuTabReqRes
        '
        Me.mnuTabReqRes.Index = 6
        Me.mnuTabReqRes.Text = "Tabella requisiti resilienze"
        '
        'mnuDis0
        '
        Me.mnuDis0.Index = 4
        Me.mnuDis0.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._mnuDis_0, Me._mnuDis_1})
        Me.mnuDis0.Text = "Disegnazione"
        '
        'mnuPref
        '
        Me.mnuPref.Index = 5
        Me.mnuPref.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAree, Me.mnuTipo, Me.mnuLibr, Me.mnuCoor, Me.mnuEdiz0, Me.mnuUG22, Me.mnuUG40, Me.mnu, Me.mnuComment, Me.mnuWordIn})
        Me.mnuPref.Text = "&Preferenze"
        '
        'mnuAree
        '
        Me.mnuAree.Index = 0
        Me.mnuAree.Text = "&Aree di lavoro"
        '
        'mnuTipo
        '
        Me.mnuTipo.Index = 1
        Me.mnuTipo.Text = "&Tipo di Lavori"
        '
        'mnuLibr
        '
        Me.mnuLibr.Index = 2
        Me.mnuLibr.Text = "&Stampa Libreria"
        '
        'mnuCoor
        '
        Me.mnuCoor.Index = 3
        Me.mnuCoor.Text = "Coordinate coperchi"
        '
        'mnuEdiz0
        '
        Me.mnuEdiz0.Index = 4
        Me.mnuEdiz0.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._mnuEdiz_0, Me._mnuEdiz_1})
        Me.mnuEdiz0.Text = "Edizione Codici"
        '
        'mnuUG22
        '
        Me.mnuUG22.Index = 5
        Me.mnuUG22.Text = "Tabella dettagliata UG-22"
        '
        'mnuUG40
        '
        Me.mnuUG40.Index = 6
        Me.mnuUG40.Text = "UG-40 (e-1)"
        '
        'mnu
        '
        Me.mnu.Index = 7
        Me.mnu.Text = "-"
        '
        'mnuComment
        '
        Me.mnuComment.Index = 8
        Me.mnuComment.Text = "Esecuzione commentata"
        '
        'mnuWordIn
        '
        Me.mnuWordIn.Index = 9
        Me.mnuWordIn.Text = "Apri rapporti in Microsoft Word"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 467)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(754, 16)
        Me.StatusBar1.TabIndex = 19
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel1.MinWidth = 500
        Me.StatusBarPanel1.Text = "Area di lavoro:"
        Me.StatusBarPanel1.Width = 500
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel2.MinWidth = 120
        Me.StatusBarPanel2.Text = "Prev:"
        Me.StatusBarPanel2.Width = 120
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel3.MinWidth = 120
        Me.StatusBarPanel3.Text = "Item:"
        Me.StatusBarPanel3.Width = 120
        '
        'CommonDialog1
        '
        Me.CommonDialog1.CheckFileExists = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "bin\AsmeVip.chm"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 72)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Apert
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(754, 483)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me._Frames_2)
        Me.Controls.Add(Me._Frames_0)
        Me.Controls.Add(Me._Frames_1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(29, 103)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Apert"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AsmeVip - Pressure Vessels & Heat Exchangers calculations"
        Me._Frames_2.ResumeLayout(False)
        Me.TabRapporto.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me._Frames_0.ResumeLayout(False)
        Me._Frames_1.ResumeLayout(False)
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Public Espanso As Boolean
    Public SelNode, DragNode As TreeNode
    Private Inizializzando As Boolean
    Private CompilTabGood As Boolean
    Private indrag As Boolean
    Private Indkmax(8) As Short
    Private Equipment(8) As Single
    Private Indjmax(8) As Short
    Private InvNoz(8) As Boolean
    Private FattoMAWP As Boolean
    Private Syo, Sya As Single
    Private i, k As Short
    Private kk, kkk As Short
    Private O As Object
    Private vMAWP As clsValoriMAWP
    Private Nuovo As Boolean
    Private matFlangia As Boolean
    Private Sya1, Syo1 As Single
    Private Testo As String
    Private nAvanz, iAvanz As Short
    Private MAWP(8) As Single
    Private kN, l, ll, i1 As Short
    Private Rear As Short
    Private Nome As String
    Private St As Short
    Private j As Short
    Private ItemUnderMouseToDrop As TreeNode
    Private bm, doveBitmap As Bitmap
    Private g As Graphics
    Private Sub Inizializza()
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Inizializzando Then Exit Sub
        If Check1.CheckState = CheckState.Checked Then
            Template = "HeadNotTec"
            _cmdVisual_0.Enabled = True
            mnuCompil.Enabled = True
        Else
            Template = "HEADER"
            _cmdVisual_0.Enabled = False
            mnuCompil.Enabled = False
        End If
    End Sub
    Private Sub cmdCalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalc.Click
        mnuCalcElem_Click(mnuCalcElem, New System.EventArgs)
    End Sub
    Private Sub cmdClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClear.Click
        CloseioutS(lstRapp)
        lstRes.Items.Clear()
    End Sub
    Private Sub cmdDati_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDati.Click
        mnuDatiElem_Click(mnuDatiElem, New System.EventArgs)
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        EspCom()
    End Sub
    Friend ReadOnly Property Frames(ByVal i As Short) As GroupBox
        Get
            Select Case i
                Case 0 : Return _Frames_0
                Case 1 : Return _Frames_1
                Case 2 : Return _Frames_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Apert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim NewWidth As Single
        Dim dH As Single
        Dim i As Short
        Dim strU As String
        If AddDistinta > 0 Then
            mnuApri.Enabled = False
        End If
        FlanBulDiv1 = True
        mnuCompil.Enabled = False
        Monitor.Motore.Problem.Extension = ".VIP"
        Monitor.Motore.Problem.TipoFile = "Calcolo apparecchi a pressione"
        Monitor.Motore.About.ProgName = "* AsmeVip * Pressure Vessels & Heat Exchangers *"
        Monitor.Motore.About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
        Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
        Monitor.Motore.About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
        Monitor.Motore.About.ProgDesc = "Code Calculations"
        Monitor.Motore.About.Company = "Copyright (c) 2005 SSAP"
        Monitor.Motore.About.Code = CodiceCalc()
        Top = 0
        Left = 0
        dH = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Height - StatusBar1.Height
        For i = 0 To 1 '2
            Frames(i).Height = Frames(i).Height + dH
        Next
        TreeView1.Height = TreeView1.Height + dH
        lstRapp.Height = lstRapp.Height + dH
        'lstRes.Height = lstRes.Height + dH
        Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        NewWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        '_Frames_2.Width = _Frames_2.Width + NewWidth - Width
        'lstRes.Width = lstRes.Width + NewWidth - Width
        lstRapp.Columns(1).Width = lstRapp.Width - lstRapp.Columns(0).Width
        Width = NewWidth
        Libreria()
        Aggiorna()
        Ridimensiona(MaxNozAct)
        Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
        If clsInizio.ReadIniFile("", "Preferenze AsmeVip", "SistemaCoordinateCoperchi") = "Cartesiano" Then SistCoorCop = 1
        OptUG40 = Not clsInizio.ReadIniFile("", "Preferenze AsmeVip", "UG-40(e-1)") = "No"
        mnuUG40.Checked = OptUG40
        OptUG22 = Not clsInizio.ReadIniFile("", "Preferenze AsmeVip", "UG-22") = "No"
        mnuUG22.Checked = OptUG22
        OptWordIn = Not clsInizio.ReadIniFile("", "Preferenze AsmeVip", "WordEmbedded") = "No"
        mnuWordIn.Checked = Not OptWordIn
        mnuWordIn_Click(Me, New ItemDragEventArgs(MouseButtons.Left))
        Text = Text & " (Vers." & Monitor.Motore.About.ProgVers & ", " & Monitor.Motore.About.ProgDate & ")"
        With Monitor.Motore.Inizio
            strU = .ReadIniFile("", "Parametri", "UltimoAggiornamento")
            If strU = "" Then
                strU = " 1"
                .WriteIniFile("", "Parametri", "UltimoAggiornamento", strU)
            End If
            UltimoAggiornamento = GlobalRoutines.ValVir(strU)
        End With
        _mnuDis_0.Enabled = False
        PictureBox1.Width = ClientRectangle.Width
        PictureBox1.Height = ClientRectangle.Height
        doveBitmap = New Bitmap(PictureBox1.ClientRectangle.Width, PictureBox1.ClientRectangle.Height, PictureBox1.CreateGraphics)
        g = Graphics.FromImage(doveBitmap)
        bm = New Bitmap(Monitor.Motore.Inizio.Archdir & "\S&T.jpg")
        g.Clear(Color.LightCyan)
        Dim x As Integer = CInt((ClientRectangle.Width - bm.Width) / 2)
        Dim y As Integer = CInt((ClientRectangle.Height - bm.Height) / 2)
        g.DrawImage(bm, x, y, CInt(bm.Width), CInt(bm.Height))
        PictureBox1.Image = doveBitmap
    End Sub
    Private Sub Apert_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        ChiudeFileU()
        Monitor.Motore.Ammazza("ASME")
        StoCalcolando = False
    End Sub
    Public Sub mnuApri_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.Popup
        mnuApri_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuApri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.Click
        Dim Res As Boolean
        Dim Testo, Rev As String
        Dim documenti As New Collection
        Dim MaxRev As String
        Static Gia As Boolean
        If AddDistinta = 1 And Gia Then Exit Sub
        Gia = True
        mnuChiudi_Click(mnuChiudi, New System.EventArgs)   'ChiudeFileU
        Res = ApriLeggiU()
        If Not Res Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        icome = Trim(icome)
        job.Comm.Arch = Monitor.Motore.Inizio.CommPulita(icome)
        If Len(icome) = 0 Then Exit Sub
        If clsInizio.LavoriSciolti Then
            Text1.Text = VB.Left(icome, Len(icome) - 4) & ".VIS"
        Else
            Text1.Text = VB.Left(icome, Len(icome) - 4) & "SC001R0.DOC"
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            If Len(Dir(Text1.Text)) > 0 Then
                Testo = VB.Left(icome, Len(icome) - 4) & "SC001R*.DOC"
                'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
                Testo = Dir(Testo)
                MaxRev = "0"
                Do
                    Rev = VB.Right(Testo, 5)
                    Rev = VB.Left(Testo, 1)
                    If GlobalRoutines.ValVir(Rev) > GlobalRoutines.ValVir(MaxRev) Then MaxRev = Rev
                    documenti.Add(clsInizio.Directory(icome) & Testo, Rev)
                    'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
                    Testo = Dir()
                Loop While Len(Testo) > 0
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto documenti(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Testo = clsInizio.CommPulita(documenti.Item(MaxRev))
                If Mid(Testo, Len(Testo) - 1, 1) = "R" Then Testo = VB.Left(Testo, Len(Testo) - 2)
                Testo = "Il rapporto di calcolo " & Testo & vbCrLf
                Testo = Testo & "esiste già alla Rev. " & MaxRev & "." & vbCrLf
                Testo = Testo & "Vuoi sovrascriverlo (Si) o vuoi passare (No)" & vbCrLf
                Testo = Testo & "alla revisione successiva ?"
                If MessageBox.Show(Me, Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Testo = documenti.Item(MaxRev)
                    MaxRev = Trim(Str(Val(MaxRev) + 1))
                    Mid(Testo, Len(Testo) - 4, 1) = MaxRev
                    Text1.Text = Testo
                Else
                    Text1.Text = documenti.Item(MaxRev)
                End If
            End If
        End If
        ModifiedData = False
        If Not Res Then
            Frames(0).Visible = False
            Frames(1).Visible = False
            _Frames_2.Visible = False
            mnuDati.Enabled = False
            mnuCalc.Enabled = False
            Exit Sub
        End If
        _mnuDis_0.Enabled = Monitor.Motore.Inizio.LavoriSciolti
        Aggiorna()
        MostraFrame()
        mioGen = New frmGen
        mioGen.Inizializza()
        AggDatiGenerali()
        mioGen.ShowDialog()
        mioGen.Dispose()
        Espanso = True
        EspCom()
    End Sub
    Public Sub mnuAree_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.Popup
        mnuAree_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuAree_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.Click
        If Not Monitor.Motore.Aree(True) Then
            objASME.Out = True
            mnuEsci_Click(mnuEsci, New System.EventArgs)
        End If
    End Sub
    Public Sub mnuCalcAuto_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcAuto.Popup
        mnuCalcAuto_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCalcAuto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcAuto.Click
        Dim Res As Short
        Dim Era As Boolean
        Dim Dimen, i As Short
        CheckPI()
        Era = Config(0).Verbose
        On Error GoTo ErrH
        Dimen = UBound(objMemb)
        '  On Error Resume Next
        For i = 1 To Dimen
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb().Verbose. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Era = Era Or objMemb(i).Verbose
        Next
        If Era Then
            mnuComment.Checked = True
            mnuComment_Click(mnuComment, New System.EventArgs)
        End If
ResH:
        ContinuoAuto = True
        Res = CalcolaTutto()
        NoHeader = False
        ContinuoAuto = False
        If Era Then mnuComment_Click(mnuComment, New System.EventArgs)
        Exit Sub
ErrH:   Resume ResH
    End Sub
    Public Sub mnuCalcElem_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcElem.Popup
        mnuCalcElem_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCalcElem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcElem.Click
        Dim k As String
        Dim iBocc As Short
        Dim Res As Boolean
        Dim n As Short
        CheckPI()
        ContinuoAuto = False
        NoHeader = False
        Distruggi(colMAWP)
        Distruggi(colMDMT)
        CostrMDMT(colMDMT)
        jInvolucr = 0
        If SelNode Is Nothing Then
            Beep()
            mnuCalcElem.Enabled = False
            mnuDatiElem.Enabled = False
            cmdCalc.Enabled = False
            cmdDati.Enabled = False
            Exit Sub
        End If
        k = SelNode.Tag
        If InStr(k, "Inv") > 0 Then
            k = VB.Right(k, Len(k) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(VB.Left(k, n - 1))
            jInvolucr = GlobalRoutines.ValVir(VB.Right(k, Len(k) - n))
        ElseIf InStr(k, "Noz") > 0 Then
            k = VB.Right(k, Len(k) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(VB.Left(k, n - 1))
            iBocc = GlobalRoutines.ValVir(VB.Right(k, Len(k) - n))
        End If
        If jInvolucr = 0 And iBocc = 0 Then Exit Sub
        Res = CalcolaElemento(iBocc)
        ModifiedData = True
    End Sub

    Public Sub mnuCalcTutti_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcTutti.Popup
        mnuCalcTutti_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCalcTutti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcTutti.Click
        Dim Res As Short
        CheckPI()
        ContinuoAuto = False
        Res = CalcolaTutto()
        NoHeader = False
    End Sub

    Public Sub mnuChiudi_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuChiudi.Popup
        mnuChiudi_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuChiudi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuChiudi.Click
        'If ModifiedData Then mnuSalva_Click
        ChiudeFileU()
        TreeView1.Nodes.Clear()
        Text1.Text = ""
        RidimensionaN(10)
        Config(0).Item = " "
        CloseioutS((lstRapp))
        lstRes.Items.Clear()
        Aggiorna()
        Frames(0).Visible = False
        _Frames_2.Visible = False
        Distruggi(colMAWP)
        Distruggi(colMDMT)
        _mnuDis_0.Enabled = False
        ReDim DatiInt(0)
        ReDim Problem(0) 'strutture dati e azzeramento
        Problem(0).Initialize()
        ReDim FlChan(0)
        ReDim FlShel(0)
        FlChan(0).Initialize()
        FlShel(0).Initialize()
    End Sub
    Public Sub mnuComment_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuComment.Popup
        mnuComment_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuComment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuComment.Click
        Dim i, Dimen As Short
        mnuComment.Checked = Not mnuComment.Checked
        Config(0).Verbose = mnuComment.Checked
        On Error GoTo ErrH
        Dimen = UBound(objMemb)
        On Error Resume Next
        For i = 1 To Dimen
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb(i).Verbose. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            objMemb(i).Verbose = Config(0).Verbose
        Next
ErrH:
    End Sub
    Public Sub mnuCompil_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCompil.Popup
        mnuCompil_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCompil_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCompil.Click
        mnuTabMat.Enabled = Check1.CheckState = 1
        mnuTabMAWP.Enabled = Check1.CheckState = 1 And Config(0).CalcMAWP > 0
        mnuTabReqRes.Enabled = Check1.CheckState = 1
    End Sub
    Public Sub mnuConvElem_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuConvElem.Popup
        mnuConvElem_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuConvElem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuConvElem.Click
        Dim Res As Boolean
        Res = ConvertiElemento(-1)
        DatiInputC(1)
    End Sub
    Public Sub mnuCoor_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCoor.Popup
        mnuCoor_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCoor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCoor.Click
        Dim Stringa(2) As String
        Dim Tit As String
        Dim iQ As Short
        Dim Testo, Aiuto As String
        Stringa(1) = "Coordinate polari"
        Stringa(2) = "Coordinate cartesiane"
        Aiuto = "Fornire il tipo di coordinate usate" & vbCrLf
        Aiuto = Aiuto & "per la localizzazione delle aperture" & vbCrLf
        Aiuto = Aiuto & "sui coperchi piani"
        Tit = "Coordinate forature"
        Testo = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "SistemaCoordinateCoperchi")
        If Testo = "Cartesiano" Then iQ = 2 Else iQ = 1
        iQ = Monitor.Motore.Quale(2, Tit, Stringa, Aiuto, iQ)
        If iQ = 2 Then
            SistCoorCop = 1
            Config(0).SistCoorCop = 1
            clsInizio.WriteIniFile("", "Preferenze AsmeVip", "SistemaCoordinateCoperchi", "Cartesiano")
        Else
            SistCoorCop = 0
            Config(0).SistCoorCop = 0
            clsInizio.WriteIniFile("", "Preferenze AsmeVip", "SistemaCoordinateCoperchi", "Polare")
        End If
        ConvertiCop()
    End Sub
    Public Sub mnuDatiContr_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDatiContr.Popup
        mnuDatiContr_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuDatiContr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDatiContr.Click
        MostraFrame()
        mioGen = New frmGen
        mioGen.Inizializza()
        AggDatiGenerali()
        mioGen.ShowDialog()
        mioGen.Dispose()
    End Sub
    Public Sub mnuDatiElem_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDatiElem.Popup
        mnuDatiElem_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuDatiElem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDatiElem.Click
        Dim Nome As String
        Try
            DatiElemento(kLato)
            DatiInputC(1)
            Dim n As TreeNode = SelNode
            If CStr(n.Tag).IndexOf("Inv") > -1 Then
                If Involucr(kLato, jInvolucr).Mark Is Nothing Then Involucr(kLato, jInvolucr).Mark = "senza nome"
                Nome = Involucr(kLato, jInvolucr).Mark.Trim
            Else
                If Nozzles(kLato, kNozzle).Mark Is Nothing Then Nozzles(kLato, kNozzle).Mark = "senza nome"
                Nome = Nozzles(kLato, kNozzle).Mark.Trim
            End If
            n.Text = Nome
            TreeView1.SelectedNode = n
            PulisciIndici()
            ModifiedData = True
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub mnuElimElemento_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuElimElemento.Popup
        mnuElimElemento_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuElimElemento_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuElimElemento.Click
        ElimElemento()
        DatiInputC(1)
    End Sub
    Public Sub mnuEsci_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEsci.Popup
        mnuEsci_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEsci.Click
        If AddDistinta = 1 Then
            ReTransWND()
            MessageBox.Show("chiudere apparecchio")
        End If
        mnuChiudi_Click(Me, New EventArgs)
        If Not wordPanel Is Nothing Then
            Try
                wordPanel.CloseSession()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Microsoft Word")
                Return
            End Try
        End If
        ' rmTestiAsmeVip.ReleaseAllResources()
        rmHelpStrings.ReleaseAllResources()
        rmHelpTopics.ReleaseAllResources()
        Monitor.Motore.Ammazza("ASME")
        Monitor = Nothing
        Me.Dispose()
        mioApert = Nothing
    End Sub
    Public Sub mnuHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub
    Public Sub mnuInf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuInf.Click
        Monitor.Motore.Informazioni(Me, myAssembly)  ',Versione,Desc,Disc
    End Sub

    Public Sub mnuInseElem_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuInseElem.Popup
        mnuInseElem_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuInseElem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuInseElem.Click
        Dim k As String
        Dim n As Short
        jInvolucr = 1
        kNozzle = 1
        If SelNode Is Nothing Then
            If Config(0).NumeroLati = 1 Then GoTo Fai
            Beep()
            mnuInseElem.Enabled = False
        End If
        k = SelNode.Tag
        Select Case k
            Case "LT" : kLato = 2
            Case "LL" : kLato = 3
            Case "LM" : kLato = 1
            Case Else
                If InStr(k, "Inv") > 0 Then
                    k = VB.Right(k, Len(k) - 3)
                    n = InStr(k, "_")
                    kLato = GlobalRoutines.ValVir(VB.Left(k, n - 1))
                    jInvolucr = GlobalRoutines.ValVir(VB.Right(k, Len(k) - n))
                ElseIf InStr(k, "Noz") > 0 Then
                    Beep()
                    mnuInseElem.Enabled = False
                End If
        End Select
Fai:    InseElemento(kLato)
        DatiInputC(1)
    End Sub

    Public Sub mnuLibr_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLibr.Popup
        mnuLibr_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuLibr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLibr.Click
        MEMO()
    End Sub

    Private Sub mnuOpzioni_Click()
        Dim l As Boolean
        l = Len(Trim(icome)) = 0
        mnuAree.Enabled = l
        mnuTipo.Enabled = l
    End Sub

    Public Sub mnuSalva_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalva.Popup
        mnuSalva_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuSalva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalva.Click
        Dim Res As Short
        Res = CheckCianfr(1)
        ApriScriviU()
        ModifiedData = False
    End Sub

    Public Sub mnuSalvaCome_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalvaCome.Popup
        mnuSalvaCome_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuSalvaCome_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalvaCome.Click
        SalvaCome()
    End Sub

    Public Sub mnuTabDesign_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabDesign.Popup
        mnuTabDesign_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTabDesign_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabDesign.Click
        Dim Testo, Nome As String
        CompilTabGood = False
        If UnLato Then
            Nome = "\TabDesign1.doc"
        Else
            Nome = "\TabDesign.doc"
        End If
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        If Documento.VaiInizio("StartDesign") = 0 Then
            MessageBox.Show("La tabella dei dati di progetto per il documento attivo è già stata compilata")
            Exit Sub
        End If
        Try
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella dati di progetto", "AsmeVip")
            InterrompiMAWP = False
            Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        Catch e As Exception
            Testo = e.Message
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Enabled = True
            Warn(Testo)
            Exit Sub
        End Try
        Enabled = False
        Documento.VaiInizio("", 1)
        Documento.Copia(1)
        Documento.sClose(, 1)
        If Not CalcMax() Then GoTo Fine
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo Fine
        Documento.VaiInizio("DesignData")
        Documento.sPaste()
        Documento.VaiInizio("StartDesign")
        Documento.SubstitBookM("StartDesign", CodiceCalc) '"ASME  VIII div.1 1998 ed. 1998 ad."
        Monitor.Motore.Avanzamento = 20
        If InterrompiMAWP Then GoTo Fine
        With Documento
            .MuoviCella(1)
            If Not UnLato Then .Testo(CodiceCalc) '"ASME  VIII div.1 1998 ed. 1998 ad."
            .MuoviCella(1)
            If UnLato Then
                .Testo("TEMA")
            Else
                .Testo("TEMA 'RCB'")
            End If
            Monitor.Motore.Avanzamento = 30
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(1)
            If UnLato Then
                .Testo("N.A.")
            Else
                .Testo("EDITION 1998 + 1994 errata")
            End If
            Monitor.Motore.Avanzamento = 40
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(2)
            If UnLato Then
                .Testo("N.A.")
            Else
                .Testo("???")
            End If
            Monitor.Motore.Avanzamento = 50
            If InterrompiMAWP Then GoTo Fine
            .MuoviCella(2)
            .Testo("Size ?")
            .MuoviCella(5)
            'GoSub DesignP ------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).p0x, 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).p0x * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).p0x, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).p0x * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 60
            If InterrompiMAWP Then GoTo Fine
            'GoSub pHydrDes----------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub DesignT----------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).tdx, 4, 1, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).tdx * 1.8 + 32, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdx, 4, 1, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdx * 1.8 + 32, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 70
            If InterrompiMAWP Then GoTo Fine
            'GoSub Corr--------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).Corr, 4, 1, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).Corr / inc, 2, 3, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).Corr, 4, 1, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).Corr / inc, 2, 3, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub MWDT----------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).tdxMDMT(0), 4, 2, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Config(1).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(2).tdxMDMT(0) * 1.8 + 32, 4, 2, False))
                    .MuoviCella(3)
                End If
            End With
            Monitor.Motore.Avanzamento = 80
            If InterrompiMAWP Then GoTo Fine
            'GoSub MAWP--------------------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Equipment(7), 2, 3, False))
                .MuoviCella(2)
                .Testo(GlobalRoutines.myStr(Equipment(7) * psi, 4, 1, False))
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Equipment(8), 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Equipment(8) * psi, 4, 1, False))
                    .MuoviCella(3)
                End If
            End With
            'GoSub Dp---------------------------------------------------
            With Documento
                .Testo("--")
                .MuoviCella(2)
                .Testo("--")
                If UnLato Then
                    .MuoviCella(4)
                Else
                    .MuoviCella(2)
                    .Testo("--")
                    .MuoviCella(2)
                    .Testo("--")
                    .MuoviCella(3)
                End If
            End With
            If UnLato Then
                .MuoviCella(6)
            Else
                .MuoviCella(9)
            End If
            Monitor.Motore.Avanzamento = 90
            If InterrompiMAWP Then GoTo Fine
            'GoSub Vacuum-----------------------------------------------------
            With Documento
                .Testo("YES")
                .MuoviCella(1)
                If UnLato Then
                    .Testo("")
                Else
                    .Testo("YES")
                End If
                .MuoviCella(2)
            End With
            'GoSub eff----------------------------------------------------------
            With Documento
                .Testo(GlobalRoutines.myStr(Config(1).Efficienza, 2, 2, False))
                .MuoviCella(1)
                If Not UnLato Then .Testo(GlobalRoutines.myStr(Config(2).Efficienza, 2, 2, False))
                .MuoviCella(2)
            End With
            'GoSub Stamp-----------------------------------------------------
            With Documento
                .Testo("YES")
                If UnLato Then
                    .MuoviLinea(13)
                Else
                    .MuoviLinea(12)
                End If
            End With
            Documento.BMAdd("EndDesign")
            Monitor.Motore.Avanzamento = 100
        End With
        CompilTabGood = True
Fine:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
    End Sub
    Public Sub mnuTabMat_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabMat.Popup
        mnuTabMat_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTabMat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabMat.Click
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        If colMAWP Is Nothing Then Nuovo = True : colMAWP = New Collection Else Nuovo = False
        Try
            CompilTabGood = False
            If Documento.VaiInizio("StartMat") = 0 Then
                Testo = "La tabella materiali per il documento attivo" & vbCrLf
                Testo = Testo & "è già stata, almeno parzialmente, compilata." & vbCrLf
                Testo = Testo & "Volete ricompilarla comunque?" & vbCrLf
                Testo = Testo & "(N.B.: La nuova redazione si aggiungerà alla vecchia" & vbCrLf
                Testo = Testo & "redazione, senza sostituzione delle parti obsolete)."
                If MessageBox.Show(Me, Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If
            Documento.Visible = False
            Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella materiali", "AsmeVip")
            InterrompiMAWP = False
            Enabled = False
            Documento.sOpen(clsInizio.Archdir & "\TabMat.doc", True, 1)
            Documento.VaiInizio("", 1)
            Documento.Copia(1)
            Documento.sClose(, 1)
            Monitor.Motore.Avanzamento = 10
            If InterrompiMAWP Then GoTo Fine
            Documento.VaiInizio("Materials")
            'Documento.sPaste ??????
            Documento.ASMEPI()
            Documento.SubstitBookM("StartMat", Trim(Involucr(1, 1).Mark))
            kLato = 1 : jInvolucr = 1
            For k = 1 To Config(0).NumeroLati
                For i = 1 To Config(k).Ninvolucri
                    nAvanz = nAvanz + 1
                Next
            Next
            With Documento
                DatiInv()
                For k = 1 To Config(0).NumeroLati
                    For i = 1 To Config(k).Ninvolucri
                        iAvanz = iAvanz + 1
                        Monitor.Motore.Avanzamento = 10 + 90 * iAvanz / nAvanz
                        If InterrompiMAWP Then GoTo Fine
                        kLato = k
                        jInvolucr = i
                        If i > 1 Or k > 1 Then
                            .TastoTab() '.MuoviCella 1
                            .Testo(Trim(Involucr(k, i).Mark))
                            DatiInv()
                        End If
                        Select Case Involucr(kLato, jInvolucr).Tipo
                            Case 0 To 4
                                DatiNoz()
                                If Sya = 0 Then GoTo Fine
                            Case 5 'fucinati
                                DatiNoz()
                                If Sya = 0 Then GoTo Fine
                                O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                If Not (CType(O, wn_flan).Mem.LOOSE = 5 Or CType(O, wn_flan).Mem.LOOSE = 6) Then
                                    Bolt1()
                                End If
                            Case 6 'PT
                                O = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                If Involucr(kLato, jInvolucr).indice(2 - 1) > 0 Then
                                    If Not Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)) Is Nothing Then
                                        Bolt1()
                                    End If
                                End If
                        End Select
                    Next
                Next
                Documento.BMAdd("EndMat")
            End With
            CompilTabGood = True
        Catch e As Exception
            Warn(e.Message)
        End Try
Fine:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
    End Sub
    Private Sub NozNoz()
        With Documento
            .TastoTab() '.MuoviCella 1
            .Testo(Trim(Nozzles(kLato, kNozzle).Mark))
            .MuoviCella(1)
            .Testo(Trim(Nozzles(kLato, kNozzle).MATE))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Nozzles(kLato, kNozzle).AllN, 5, 2, False))
            .MuoviCella(1)
            If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
                Matdim(Nozzles(kLato, kNozzle).indice).Zitto = True
                Matdim(Nozzles(kLato, kNozzle).indice).SigmaAmm(CodiceStress, TempDes, Sya, Syo)
                Matdim(Nozzles(kLato, kNozzle).indice).Zitto = False
                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                .MuoviCella(1)
                If Matdim(Nozzles(kLato, kNozzle).indice).Indmat > 0 Or Not Matdim(Nozzles(kLato, kNozzle).indice).Agganciato Then
                    Matdim(Nozzles(kLato, kNozzle).indice).Zitto = True
                    Matdim(Nozzles(kLato, kNozzle).indice).YieldTemp(CodiceStress, TempDes, Sya1, Syo1)
                    Matdim(Nozzles(kLato, kNozzle).indice).Zitto = False
                Else
                    Syo1 = 0
                End If
                .Testo(GlobalRoutines.myStr(Syo1, 5, 2, False))
                matFlangia = False
                RegNozzle()
            Else
                Sya = 0
                GlobalRoutines.FormatS("non|")
                Testo = GlobalRoutines.FormatS(Helpstringa(IDH_MANCAINDMAT), Trim(Nozzles(kLato, kNozzle).Mark))
                MostraAiuto(IDH_MANCAINDMAT, , Testo)
            End If
        End With
        If Sya <> 0 Then
            If Nozzles(kLato, kNozzle).IndexF > 0 Then
                If Nozzles(kLato, kNozzle).IndexF <> Nozzles(kLato, kNozzle).indice Then
                    If Not Matdim(Nozzles(kLato, kNozzle).IndexF) Is Nothing And Nozzles(kLato, kNozzle).Rati > 0 Then
                        If Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat <> Matdim(Nozzles(kLato, kNozzle).indice).Indmat And Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat > 0 Then
                            With Documento
                                .TastoTab() '.MuoviCella 1
                                .Testo(Trim(Nozzles(kLato, kNozzle).Mark) & " (fl.)")
                                .MuoviCella(1)
                                .Testo(Trim(Matdim(Nozzles(kLato, kNozzle).IndexF).MatStr))
                                .MuoviCella(1)
                                .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
                                .MuoviCella(1)
                                Matdim(Nozzles(kLato, kNozzle).IndexF).SigmaAmm(CodiceStress, TempDes, Sya, Syo)
                                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                                .MuoviCella(1)
                                .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
                                .MuoviCella(1)
                                Matdim(Nozzles(kLato, kNozzle).IndexF).YieldTemp(CodiceStress, TempDes, Sya, Syo)
                                .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
                                matFlangia = True
                                RegNozzle()
                            End With
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub RegNozzle()
        If Nuovo Then
            vMAWP = New clsValoriMAWP
        Else
            vMAWP = CercavMAWP(kLato, kNozzle, False, , matFlangia)
            If vMAWP Is Nothing Then
                Nuovo = True
                vMAWP = New clsValoriMAWP
            End If
        End If
        With vMAWP
            .St = Syo
            .Sa = Sya
            .Inv = False
            .k = kLato
            .i = kNozzle
            .Mark = Trim(Nozzles(.k, .i).Mark)
            .Flangia = matFlangia
            If matFlangia Then
                .Mark = .Mark & " (fl.)"
            Else
                .Mark = .Mark & " (tr.)"
            End If
        End With
        If Nuovo Then colMAWP.Add(vMAWP)
    End Sub
    Private Sub Bolt1()
        With Documento
            .TastoTab() '.MuoviCella 1
            .Testo(Trim(Involucr(kLato, jInvolucr).Mark) & " (Bolts)")
            .MuoviCella(1)
            .Testo(Trim(Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).MatStr))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr((TempDes() - 32) / 1.8, 4, 0, True))
            .MuoviCella(1)
            Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Zitto = True
            Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).SigmaAmm(CodiceStress(FlanBulDiv1), TempDes, Sya, Syo)
            .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Sya, 5, 2, False))
            .MuoviCella(1)
            Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).YieldTemp(CodiceStress(FlanBulDiv1), TempDes, Sya1, Syo1)
            Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Zitto = False
            .Testo(GlobalRoutines.myStr(Syo1, 6, 2, False))
            If Nuovo Then
                vMAWP = New clsValoriMAWP
            Else
                vMAWP = CercavMAWP(kLato, jInvolucr, True)
                If vMAWP Is Nothing Then
                    Nuovo = True
                    vMAWP = New clsValoriMAWP
                End If
            End If
            With vMAWP
                .St = Syo
                .Sa = Sya
                .Inv = True
                .k = kLato
                .i = jInvolucr
                .Bolt = True
                .Mark = Trim(Involucr(.k, .i).Mark) & " (Bolts)"
            End With
            If Nuovo Then colMAWP.Add(vMAWP)
        End With
    End Sub
    Private Sub DatiNoz()
        For kkk = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            kNozzle = kkk
            NozNoz()
            If Sya = 0 Then Exit Sub
            For kk = Nozzles(kLato, kkk).inizio To Nozzles(kLato, kkk).Fine
                kNozzle = kk
                NozNoz()
                If Sya = 0 Then Exit Sub
            Next
        Next
    End Sub
    Private Sub DatiInv()
        With Documento
            .MuoviCella(1)
            .Testo(Trim(Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).MatStr))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(TempDes, 4, 0, True))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St, 5, 2, False))
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0, 5, 2, False))
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Zitto = True
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).YieldTemp(CodiceStress, TempDes, Sya, Syo)
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Zitto = False
            .MuoviCella(1)
            .Testo(GlobalRoutines.myStr(Syo, 5, 2, False))
            If Nuovo Then
                vMAWP = New clsValoriMAWP
            Else
                vMAWP = CercavMAWP(kLato, jInvolucr, True)
                If vMAWP Is Nothing Then
                    Nuovo = True
                    vMAWP = New clsValoriMAWP
                End If
            End If
            With vMAWP
                .St = Involucr(kLato, jInvolucr).St
                .Sa = Involucr(kLato, jInvolucr).S0
                .Inv = True
                .k = kLato
                .i = jInvolucr
                .Mark = Trim(Involucr(.k, .i).Mark)
            End With
            If Nuovo Then colMAWP.Add(vMAWP)
        End With
    End Sub
    Public Sub mnuTabMAWP_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabMAWP.Popup
        mnuTabMAWP_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTabMAWP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabMAWP.Click
        CompilTabGood = False
        If UnLato Then
            Nome = "\TabMAWP31.doc"
        Else
            Nome = "\TabMAWP3.doc"
        End If
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        'verifica se è già stata compilata-----------
        If Documento.VaiInizio("EndMAWP") = 0 Then
            Documento.ASMEMAWP()
        End If
        '----------------------------
        On Error GoTo ErrAutom
        Documento.Visible = False
        Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        On Error GoTo 0
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella delle MAWP", "AsmeVip")
        InterrompiMAWP = False
        Enabled = False
        Documento.VaiInizio("", 1)
        Documento.Copia(1)
        Documento.sClose(, 1)
        Documento.VaiInizio("HydroTest")
        Monitor.Motore.Avanzamento = 5
        If InterrompiMAWP Then GoTo FineNoSuccess
        Documento.ASMEMAWP1()
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo FineNoSuccess
        i1 = 1
        If Involucr(1, 1).Tipo = 8 Then
            If objMemb(Involucr(1, 1).IndObject).Piastra.IndiceDilat > -1 Then
                i1 = 2
            Else
                i1 = 1
            End If
        End If
        Documento.SubstitBookM("StartMAWP", Trim(Involucr(1, i1).Mark))
        kLato = 1 : jInvolucr = i1
        If Not CalcMax() Then GoTo FineNoSuccess
        Monitor.Motore.Avanzamento = 15
        If InterrompiMAWP Then GoTo FineNoSuccess
        FattoMAWP = True
        With Documento 'Selection
            DatiInvMAWP()
            For k = 1 To Config(0).NumeroLati
                For i = i1 To Config(k).Ninvolucri
                    nAvanz = nAvanz + 1
                Next
            Next
            For k = 1 To Config(0).NumeroLati
                For i = i1 To Config(k).Ninvolucri
                    iAvanz = iAvanz + 1
                    Monitor.Motore.Avanzamento = 15 + 85 * iAvanz / nAvanz
                    If InterrompiMAWP Then GoTo FineNoSuccess
                    If Involucr(k, i).Tipo = 9 Then GoTo Cont
                    If Involucr(k, i).Tipo = 8 Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb(Involucr(k, i).IndObject).Piastra. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If objMemb(Involucr(k, i).IndObject).Piastra.IndiceDilat > -1 Then
                            GoTo Cont
                        End If
                    End If
                    kLato = k
                    jInvolucr = i
                    If i > 1 Or k > 1 Then
                        .TastoTab() '.MuoviCella 1
                        .Testo(Trim(Involucr(k, i).Mark))
                        DatiInvMAWP()
                    End If
                    Select Case Involucr(kLato, jInvolucr).Tipo
                        Case 0 To 5
                            DatiNozMAWP()
                    End Select
Cont:           Next
            Next
            .TastoTab()
            .Testo("Equipment")
            'GoSub PrintTabF---------------------------------------------------
            With Documento
                If UnLato Then St = 2 Else St = 1
                For ll = 1 To 8 Step St
                    .MuoviCella(1)
                    .Testo(GlobalRoutines.myStr(Equipment(ll), 5, 2, True))
                    .ASMESinistra(True)
                Next
            End With
            .BMAdd("EndMAWP")
        End With
        CompilTabGood = True
FineNoSuccess:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
        Exit Sub
ExAutom:
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Enabled = True
        Warn(Testo)
        '  On Error Resume Next
        Documento.Visible = True
        Exit Sub
ErrAutom:
        Testo = Err.Description
        Resume ExAutom
    End Sub
    Private Sub PrintTab()
        If UnLato Then St = 2 Else St = 1
        With Documento 'Selection
            For ll = 1 To 8 Step St
                .MuoviCella(1)
                If MAWP(ll) > 0 Then
                    .Testo(GlobalRoutines.myStr(MAWP(ll), 5, 2, True).Trim)
                    .ASMESinistra(Indkmax(ll) = k And Indjmax(ll) = jInvolucr And InvNoz(ll))
                End If
            Next
        End With
    End Sub
    Private Sub DatiNozMAWP()
        For kN = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            Documento.TastoTab() '.MuoviCella 1
            Documento.Testo(Trim(Nozzles(k, kN).Mark))
            For l = 1 To 8 : MAWP(l) = 0 : Next
            Select Case kLato
                Case 1
                    For l = 1 To 4
                        ll = 1 + (l - 1) * 2
                        MAWP(ll) = Nozzles(kLato, kN).MAWP(l - 1)
                        If MAWP(ll) > 10000000000.0# Then MAWP(ll) = 0
                    Next
                Case 2
                    For l = 1 To 4
                        ll = l * 2
                        MAWP(ll) = Nozzles(kLato, kN).MAWP(l - 1)
                        If MAWP(ll) > 10000000000.0# Then MAWP(ll) = 0
                    Next
            End Select
            With Documento
                If UnLato Then St = 2 Else St = 1
                For ll = 1 To 8 Step St
                    .MuoviCella(1)
                    If MAWP(ll) > 0 Then
                        .Testo(GlobalRoutines.myStr(MAWP(ll), 5, 2, True))
                        'If Indkmax(ll) = k And Indjmax(ll) = kN And Not InvNoz(ll) Then
                        '   .ASMEsinistra
                        'End If
                        .ASMESinistra(Indkmax(ll) = k And Indjmax(ll) = kN And Not InvNoz(ll))
                    End If
                Next
            End With
        Next
    End Sub
    Private Sub DatiInvMAWP()
        For l = 1 To 8 : MAWP(l) = 0 : Next
        Select Case kLato
            Case 1
                For l = 1 To 4
                    ll = 1 + (l - 1) * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
            Case 2
                For l = 1 To 4
                    ll = l * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
            Case 3
                For l = 1 To 4
                    ll = l * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP2(l - 1)
                Next
                For l = 1 To 4
                    ll = 1 + (l - 1) * 2
                    MAWP(ll) = Involucr(kLato, jInvolucr).MAWP(l - 1)
                Next
        End Select
        If kLato = 3 And Involucr(kLato, jInvolucr).Tipo = 6 Then
            O = objMemb(Involucr(kLato, jInvolucr).IndObject)
            If O.TipoPT = 1 Then Rear = O.Piastra.Rear
            If O.ProgDiffPr And Not Rear = 1 Then
                If UnLato Then St = 2 Else St = 1
                With Documento
                    For ll = 1 To 8 Step St
                        .MuoviCella(1)
                        .Testo("DP")
                    Next
                End With
            Else
                PrintTab()
            End If
        Else
            PrintTab()
        End If
    End Sub
    Public Sub mnuTabPI_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabPI.Popup
        mnuTabPI_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTabPI_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabPI.Click
        Dim i, k As Short
        Dim vMAWP As clsValoriMAWP
        Dim Testo, Nome As String
        Dim iAvanz As Short
        Dim iNota As Short
        CompilTabGood = False
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        If Documento.VaiInizio("StartPI") = 0 Then
            MessageBox.Show("I requisiti di prova idraulica per il documento attivo sono già stati compilati")
            Exit Sub
        End If
        Documento.Visible = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella prova idraulica", "AsmeVip")
        On Error GoTo ErrAutom
        Select Case Config(0).MetodoPI
            Case 0
                If Not CalcolaPIb() Then GoTo FineNoSuccess
                If UnLato Then
                    Documento.sOpen(clsInizio.Archdir & "\TabPIb1.doc", True, 1)
                Else
                    Documento.sOpen(clsInizio.Archdir & "\TabPIb.doc", True, 1)
                End If
            Case 1
                If Not FattoMAWP Then
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    MostraAiuto(IDH_MANCATABMAWP)
                    GoTo FineNoSuccess
                End If
                If Not CalcolaPIc() Then GoTo FineNoSuccess
                If UnLato Then
                    Documento.sOpen(clsInizio.Archdir & "\TabPI1.doc", True, 1)
                Else
                    Documento.sOpen(clsInizio.Archdir & "\TabPI.doc", True, 1)
                End If
        End Select
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        Enabled = False
        Monitor.Motore.Avanzamento = 10
        If InterrompiMAWP Then GoTo FineNoSuccess
        With Documento
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            .VaiInizio("HydroTest")
            .ASMEPI()
            '================================
            .SubstitBookM("StartPI", CodiceCalc) ' "ASME  VIII div.1 1998 ed. 1998 ad."
            .SubstitBookM("Rapp", Format(RappPI, Form1_2))
            .SubstitBookM("RulePI", RulePI)
            Monitor.Motore.Avanzamento = 15
            '.Visible = True
            If InterrompiMAWP Then GoTo FineNoSuccess
            If Config(0).MetodoPI = 0 Then
                .MuoviCella(5)
                .MuoviLinea(2)
                'GoSub TabellaMAWPB--------------------------------------------
                With Documento 'Selection
                    For Each vMAWP In colMAWP
                        .InserisciRiga(1)
                        .MuoviCaratt(-1)
                        .Testo(Trim(vMAWP.Mark))
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS, 2, 3, False))
                        End If
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS * psi, 4, 1, False))
                        End If
                        .MuoviCella(1)
                        If Not UnLato Then
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS, 2, 3, False))
                            End If
                            .MuoviCella(1)
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS * psi, 4, 1, False))
                            End If
                        End If
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr((vMAWP.Sa), 4, 2, False))
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr((vMAWP.St), 4, 2, False))
                        .MuoviCella(1)
                        If vMAWP.St > 0 Then
                            .Testo(Format(vMAWP.Sa / vMAWP.St, "##.000"))
                        End If
                        .MuoviCella(1)
                        Monitor.Motore.Avanzamento = 15 + 70 * iAvanz / colMAWP.Count()
                        If InterrompiMAWP Then GoTo FineNoSuccess
                        iAvanz = iAvanz + 1
                    Next vMAWP
                    .MuoviLinea(10)
                End With
                'GoSub pHydrb--------------------------------------------------
                With Documento 'Selection
                    .VaiInizio("HydrTestPr")
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                    .MuoviCella(1)
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                    .MuoviCella(1)
                    If UnLato Then
                    Else
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                        .MuoviCella(1)
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                    End If
                    .MuoviCella(5)
                End With
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then GoTo FineNoSuccess
            Else
                .MuoviCella(3) ' era 3 sono all'inizio dei dati
                .MuoviLinea(1)
                'GoSub TabellaMAWPc-----------------------------------
                With Documento 'Selection
                    For Each vMAWP In colMAWP
                        .InserisciRiga(1)
                        .MuoviCaratt(-1)
                        .Testo(Trim(vMAWP.Mark))
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS, 2, 3, False))
                        End If
                        .MuoviCella(1)
                        .Testo("MPa")
                        .MuoviCella(1)
                        If vMAWP.corrMAWPSS > 0 Then
                            .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPSS * psi, 4, 1, False))
                        End If
                        .MuoviCella(1)
                        .Testo("psi")
                        .MuoviCella(1)
                        If Not UnLato Then
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS, 2, 3, False))
                            End If
                            .MuoviCella(1)
                            .Testo("MPa")
                            .MuoviCella(1)
                            If vMAWP.corrMAWPTS > 0 Then
                                .Testo(GlobalRoutines.myStr(vMAWP.corrMAWPTS * psi, 4, 1, False))
                            End If
                            .MuoviCella(1)
                            .Testo("psi")
                        End If
                        .MuoviCella(1)
                        Monitor.Motore.Avanzamento = 15 + 70 * iAvanz / colMAWP.Count()
                        If InterrompiMAWP Then GoTo FineNoSuccess
                        iAvanz = iAvanz + 1
                    Next vMAWP
                    .MuoviLinea(2)
                    .MuoviCella(1)
                End With
                'GoSub pHydrPI-----------------------------------------
                With Documento 'Selection
                    .VaiInizio("HydrTestPr")
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest, 2, 3, False))
                    .MuoviCella(2)
                    .Testo(GlobalRoutines.myStr(Config(1).pxTest * psi, 4, 1, False))
                    .MuoviCella(2)
                    If UnLato Then
                        .MuoviCella(1)
                    Else
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest, 2, 3, False))
                        .MuoviCella(2)
                        .Testo(GlobalRoutines.myStr(Config(2).pxTest * psi, 4, 1, False))
                        .MuoviCella(3)
                    End If
                End With
                Monitor.Motore.Avanzamento = 90
                If InterrompiMAWP Then GoTo FineNoSuccess
            End If
            .MuoviLinea(1)
        End With
        'GoSub Nota1------------------------------------------------------------
        With Documento 'Selection
            iNota = 1
            If Config(0).HTTestVert > 0 Then
                .Testo("1) Position during hydrotest: VERTICAL")
            Else
                .Testo("1) Position during hydrotest: HORIZONTAL")
            End If
            If Config(0).CalcMAWP = 0 And Config(0).MetodoPI = 0 Then
                iNota = iNota + 1
                .MuoviLinea(1)
                .Testo(Str(iNota) & ") The MAWP's are assumed equal to the Design Pressures")
            End If
            If UnLato Then
                If System.Math.Abs(Config(1).pxTest - pHISS) > 1 Then
                    iNota = iNota + 1
                    .MuoviLinea(1)
                    .Testo(Str(iNota) & ") The calculated HT pressure is " & GlobalRoutines.FormatS("##.### MPa (####.# psi)", pHISS / psi, pHISS))
                End If
            Else
                If System.Math.Abs(Config(1).pxTest - pHISS) > 1 Or System.Math.Abs(Config(2).pxTest - pHITS) > 1 Then
                    iNota = iNota + 1
                    .MuoviLinea(1)
                    .Testo(Str(iNota) & ") The calculated HT pressures are " & GlobalRoutines.FormatS("##.### MPa (####.# psi) shell-side ", pHISS / psi, pHISS) & " and " & GlobalRoutines.FormatS("##.### MPa (####.# psi) tube-side ", pHITS / psi, pHITS))
                End If
            End If
        End With
        Monitor.Motore.Avanzamento = 95
        CompilTabGood = True
FineNoSuccess:
        '================================
        CompilTabGood = True
        Monitor.Motore.ProgrAmmazza()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
        Exit Sub
ExAutom:
        On Error GoTo 0
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Enabled = True
        Warn(Testo)
        Exit Sub
ErrAutom:
        Testo = Err.Description
        Resume ExAutom
    End Sub
    Public Sub mnuTabReqRes_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabReqRes.Popup
        mnuTabReqRes_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTabReqRes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTabReqRes.Click
        Dim Nome As String
        Dim vMDMT As clsValoriMDMT
        Dim k As Short
        Dim i As Short
        Dim Testo As String
        If Config(1).NMWDT = 0 And Config(2).NMWDT = 0 Then
            If Not ContinuoAuto Then MessageBox.Show("Questa procedura non può essere eseguita in quanto non sono state specificate condizioni di progetto a bassa temperatura")
            Exit Sub
        End If
        CompilTabGood = False
        Nome = "\TabMDMT.doc"
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        If Documento.VaiInizio("StartMDMT") = 0 Then
            MessageBox.Show("Le esenzioni dalle prove di resilienza per il documento attivo sono già state compilate")
            Exit Sub
        End If
        Try
            Documento.sOpen(clsInizio.Archdir & Nome, True, 1)
        Catch e As Exception
            Testo = e.Message
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Enabled = True
            Warn(Testo)
            Documento.Visible = True
        End Try
        Monitor.Motore.ProgrInizio("Attendere la compilazione della tabella esenzioni", "AsmeVip")
        InterrompiMAWP = False
        Enabled = False
        With Documento
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            .VaiInizio("Exemptions")
            .ASMEPI()
            .VaiInizio("StartMDMT")
            Monitor.Motore.Avanzamento = 10
            If InterrompiMAWP Then GoTo FineNoSuccess
            i = 1
            For Each vMDMT In colMDMT
                If i = 1 Then
                    .SubstitBookM("StartMDMT", vMDMT.Mark)
                Else
                    If vMDMT.Secondo Then
                        .Testo("2nd condition")
                    Else
                        .Testo(vMDMT.Mark)
                    End If
                End If
                .MuoviCella(1)
                .Testo(vMDMT.Rule)
                For k = 1 To 5
                    .MuoviCella(1)
                    If vMDMT.Exempt(k) Then
                        .Testo("Y")
                    Else
                        .Testo("N")
                    End If
                    .MuoviCella(1)
                    .Testo(vMDMT.Articl(k))
                Next k
                .InserisciRiga(1)
                .MuoviCaratt(-1)
                Monitor.Motore.Avanzamento = 10 + 90 * i / colMDMT.Count()
                If InterrompiMAWP Then GoTo FineNoSuccess
                i = i + 1
            Next vMDMT
            .MuoviCella(1)
        End With
        CompilTabGood = False
FineNoSuccess:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Monitor.Motore.ProgrAmmazza()
        Enabled = True
        If Not OptWordIn Then Documento.Massimizza()
    End Sub
    Public Sub mnuTipo_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTipo.Popup
        mnuTipo_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTipo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTipo.Click
        Dim mode As Short
        If Len(Trim(icome)) > 0 Then mode = 1
        Monitor.Motore.SetLavoriSciolti(mode)
        _mnuDis_0.Enabled = Monitor.Motore.Inizio.LavoriSciolti And mode = 1
    End Sub
    Public Sub mnuTTab_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTTab.Popup
        mnuTTab_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTTab_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTTab.Click
        ContinuoAuto = True
        mnuTabMat_Click(mnuTabMat, New System.EventArgs)
        If Not CompilTabGood Then GoTo ExSub
        mnuTabDesign_Click(mnuTabDesign, New System.EventArgs)
        If Not CompilTabGood Then GoTo ExSub
        mnuTabMAWP_Click(mnuTabMAWP, New System.EventArgs)
        If Not CompilTabGood Then GoTo ExSub
        mnuTabPI_Click(mnuTabPI, New System.EventArgs)
        If Not CompilTabGood Then GoTo ExSub
        mnuTabReqRes_Click(mnuTabReqRes, New System.EventArgs)
ExSub:
        ContinuoAuto = False
    End Sub
    Public Sub mnuTuttiDati_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTuttiDati.Popup
        mnuTuttiDati_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTuttiDati_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTuttiDati.Click
        DatiInputC(2)
    End Sub

    Public Sub mnuUG40_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuUG40.Popup
        mnuUG40_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuUG40_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuUG40.Click
        Dim Testo As String
        OptUG40 = Not OptUG40
        mnuUG40.Checked = OptUG40
        If OptUG40 Then Testo = "Si" Else Testo = "No"
        clsInizio.WriteIniFile("", "Preferenze AsmeVip", "UG-40(e-1)", Testo)
    End Sub

    Public Sub mnuWRCB_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWRCB.Popup
        mnuWRCB_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuWRCB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWRCB.Click
        Dim n, k, i As Short
        Dim j As Short
        Dim Inv As New Involucro
        Dim t As Single
        Dim Noz As NozzleN
        Dim Invc As Short
        Dim pHydr As Single
        For k = 1 To Config(0).NumeroLati
            n = n + NumBocch(k) + NumBocch2(k)
        Next
        If n = 0 Then
            MessageBox.Show("Non sono stati definiti dei bocchelli su questo apparecchio")
            Exit Sub
        End If
        objWRCB = New Wrcb.clsWrcb
        With objWRCB
            .dovejob = job
            .DoveMotore = Monitor.Motore
            .DoveRoutines = Routines
            .Inizia()
            .lstRapp = lstRapp
            .Cliente = Monitor.Motore.Problem.ClientPlant
            .commessa = IO.Path.GetDirectoryName(icome) & "\" & IO.Path.GetFileNameWithoutExtension(icome) & Monitor.Motore.Problem.Extension 'CommPulita
            .NBocch = n
            If Config(0).US = 0 Then .UnitSis = 0 Else .UnitSis = 2
            .Analisi = 0
            .Casi = 1
            .Note = 1
            .Reduced = 0
            .EndEffect = False
            .WRC297 = 4
            .Ammiss = 0
            .Verbose = Config(0).Verbose
            .ConvSumm = 0
            .Item = Config(0).Item
            i = 0
            For k = 1 To Config(0).NumeroLati
                For j = 1 To NumBocch(k) + NumBocch2(k)
                    i = i + 1
                    .Mark(i) = Nozzles(k, j).Mark
                    .Forma(i) = 0
                    .Buco(i) = 0
                    .Incluso(i) = 1
                    .DiaN(i) = Nozzles(k, j).DiaN
                    .Asa(i) = IndiceRat(Nozzles(k, j).Rati)
                    t = Nozzles(k, j).HX
                    If t = 0 Then t = Nozzles(k, j).Spess
                    .R0(i) = Nozzles(k, j).DiIn / 2 + t
                    .T0(i) = t
                    .CorrN(i) = Nozzles(k, j).CorrA
                    If Nozzles(k, j).CorrA = 0 Then .CorrN(i) = Nozzles(k, j).ONn
                    If Nozzles(k, j).Padd * Nozzles(k, j).PadT > 0 Then
                        .Rinforzo(i) = 1
                        .Padd(i) = Nozzles(k, j).Padd
                        .PadT(i) = Nozzles(k, j).PadT
                    Else
                        .Rinforzo(i) = 0
                    End If
                    Invc = Nozzles(k, j).InvolucroSU
                    If Invc < 0 Then
                        Noz = Nozzles(k, -Invc)
                        .ShellT(i) = Noz.Spess
                        .ShellType(i) = 0
                        .di(i) = Noz.DiIn
                        .CylL(i) = Noz.LXdisp
                    Else
                        Inv = Involucr(k, Invc)
                        .Corr(i) = Inv.cs
                        If Inv.cs = 0 Then .Corr(i) = Inv.OS
                        Select Case Inv.Tipo
                            Case 0 'cilindro
                                .ShellType(i) = 0
                                .di(i) = Inv.di
                                .CylL(i) = Inv.L0
                            Case 1 'heads
                                .ShellType(i) = 1
                                Select Case Inv.ms
                                    Case 5 'sfera
                                        .RC(i) = Inv.L0
                                    Case 4 'toro6
                                    Case 3 'toro
                                    Case 2 'ellitt
                                    Case 1 'ell21
                                        .RC(i) = Inv.L0
                                        ' .rc(i) = Inv.R0
                                End Select
                            Case 2, 3 'coni
                        End Select
                        .ShellT(i) = Inv.Spess
                    End If
                    AggiustaHydr(k, 0, j, pHydr)
                    .Pressione(i, 1) = pHydr / psi
                    '.Pressione(i, 1) = -Config(k).p0x
                    kLato = k
                    jInvolucr = -j
                    .Temper(i, 1) = (TempDes() - 32) / 1.8
                    .CaseDesc(i, 1) = "Design Condition"
                    .Materiale(i) = Matdim(Inv.indice(1 - 1))
                Next
            Next
            If Not Monitor.Motore.Problem.FileStream Is Nothing Then
                Monitor.Motore.Problem.FileStream.Close() '  FileClose(iout)
                .Appendi(FileSt)
            End If
            .EseguiDaAsme(Check1.CheckState, Apparecchio)
        End With
        Enabled = False
    End Sub
    Public Sub TreeView1_NodeClick(ByVal nodo As TreeNode)
        TreeView1.SelectedNode = nodo
    End Sub
    Public Sub EspCom()
        Dim Nodex As TreeNode
        For Each Nodex In TreeView1.Nodes
            If Not Espanso Then
                Nodex.ExpandAll()
                Command1.Text = "&Comprimi"
            Else
                Nodex.Collapse()
                Command1.Text = "&Espandi"
            End If
        Next Nodex
        Espanso = Not Espanso
    End Sub
    Public Sub VisualCap()
        Dim cap1 As String
        Dim i As Short
        Dim cap2 As String = ""
        Dim l As ListViewItem
        If lstRapp.SelectedItems.Count = 0 Then
            GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
            MostraAiuto(2150)
        Else
            Try
                l = lstRapp.SelectedItems(0)
                If l Is Nothing Then Exit Sub
                cap1 = TogliBlank((l.SubItems(0).Text))
                Documento.VaiInizio(cap1)
                i = l.Index
                If i < lstRapp.Items.Count - 1 Then
                    cap2 = TogliBlank((lstRapp.Items(i + 1).SubItems(0).Text))
                    Documento.VaiInizio(cap2, 1)
                Else
                    Documento.VaiInizio("\EndOfDoc", 1)
                End If
                Documento.ASMECap(clsInizio.Archdir, clsInizio.DiscoTem, cap1, cap2)
                If Not OptWordIn Then Documento.Massimizza()
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End If
    End Sub
    Public Function CalcMax() As Boolean
        'calcolo delle MAWP di apparecchio dalle MAWP di membratura
        Dim O As Object
        Dim vMAWP As clsValoriMAWP
        Dim Nuovo As Boolean
        If Config(0).CalcMAWP = 0 Then Exit Function
        If colMAWP Is Nothing Then
            If Config(0).MetodoPI = 0 Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                MostraAiuto(IDH_MANCATABMAT)
                Exit Function
            End If
            colMAWP = New Collection
            Nuovo = True
        Else
            Nuovo = False
        End If
        CalcMax = True
        For l = 1 To 8 : Equipment(l) = 10000000000.0# : Next
        For k = 1 To Config(0).NumeroLati
            For i = 1 To Config(k).Ninvolucri
                If Involucr(k, i).Tipo = 9 Then GoTo Cont
                If Involucr(k, i).Tipo = 8 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objMemb(Involucr(k, i).IndObject).Piastra. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If objMemb(Involucr(k, i).IndObject).Piastra.IndiceDilat > -1 Then
                        GoTo Cont
                    End If
                End If
                Select Case k
                    Case 1
                        For j = 1 To 4
                            l = 1 + (j - 1) * 2
                            MaxInv()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, True)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPSS = Involucr(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = True
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Involucr(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                    Case 2
                        For j = 1 To 4
                            l = j * 2
                            MaxInv()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, True)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPTS = Involucr(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = True
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Involucr(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                    Case 3
                        Select Case Involucr(k, i).Tipo
                            Case 6 'PT
                                O = objMemb(Involucr(k, i).IndObject)
                                If CType(O, wn_PT).TipoPT = 1 Then 'UTEMA
                                    If Not CType(O, wn_PT).ProgDiffPr Then Doppio()
                                Else
                                    If CType(CType(O, wn_PT).Piastra, wn_FTC).Rear = 1 Or Not CType(O, wn_PT).ProgDiffPr Then Doppio()
                                End If
                            Case Else
                                Doppio()
                        End Select
                End Select
Cont:       Next
            For i = 1 To NumBocch(k) + NumBocch2(k) 'Involucr(k, Config(k).Ninvolucri).Fine
                Select Case k
                    Case 1
                        For j = 1 To 4
                            l = 1 + (j - 1) * 2
                            MaxInvN()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, False)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPSS = Nozzles(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = False
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Nozzles(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                    Case 2
                        For j = 1 To 4
                            l = j * 2
                            MaxInvN()
                            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                                If Nuovo Then
                                    vMAWP = New clsValoriMAWP
                                Else
                                    vMAWP = CercavMAWP(k, i, False)
                                End If
                                If Not vMAWP Is Nothing Then
                                    With vMAWP
                                        .MAWPTS = Nozzles(k, i).MAWP(j - 1)
                                        If Nuovo Then
                                            .Inv = False
                                            .k = k
                                            .i = i
                                            .Mark = Trim(Nozzles(k, i).Mark)
                                        Else
                                            TransferMAWP(vMAWP)
                                        End If
                                    End With
                                    If Nuovo Then colMAWP.Add(vMAWP)
                                End If
                            End If
                        Next
                End Select
            Next
        Next
        Exit Function
    End Function
    Private Sub MaxInvN()
        If Nozzles(k, i).MAWP(j - 1) < Equipment(l) Then
            Equipment(l) = Nozzles(k, i).MAWP(j - 1)
            Indkmax(l) = k
            Indjmax(l) = i
            InvNoz(l) = False
        End If
    End Sub
    Private Sub Doppio()
        For j = 1 To 4
            l = j * 2
            If Involucr(k, i).MAWP2(j - 1) < Equipment(l) Then
                Equipment(l) = Involucr(k, i).MAWP2(j - 1)
                Indkmax(l) = k
                Indjmax(l) = i
                InvNoz(l) = True
            End If
            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                If Nuovo Then
                    vMAWP = New clsValoriMAWP
                Else
                    vMAWP = CercavMAWP(k, i, True)
                End If
                If Not vMAWP Is Nothing Then
                    With vMAWP
                        .MAWPTS = Involucr(k, i).MAWP2(j - 1)
                        If Nuovo Then
                            .Inv = True
                            .k = k
                            .i = i
                            .Mark = Trim(Involucr(k, i).Mark)
                        Else
                            TransferMAWP(vMAWP)
                        End If
                    End With
                    If Nuovo Then colMAWP.Add(vMAWP)
                End If
            End If
        Next
        For j = 1 To 4
            l = 1 + (j - 1) * 2
            MaxInv()
            If j = 1 And Config(0).MetodoPI = 1 Or j = 4 And Config(0).MetodoPI = 0 Then
                With vMAWP
                    .MAWPSS = Involucr(k, i).MAWP(j - 1)
                    If Nuovo Then
                        .Inv = True
                        .k = k
                        .i = i
                        .Mark = Trim(Involucr(k, i).Mark)
                    Else
                        TransferMAWP(vMAWP)
                    End If
                End With
            End If
        Next
    End Sub
    Private Sub MaxInv()
        If Involucr(k, i).MAWP(j - 1) < Equipment(l) Then
            Equipment(l) = Involucr(k, i).MAWP(j - 1)
            Indkmax(l) = k
            Indjmax(l) = i
            InvNoz(l) = True
        End If
    End Sub
    Private Sub Warn(ByRef Errore As String)
        Dim Testo As String
        'UPGRADE_NOTE: È possibile che l'oggetto Documento non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Documento = Nothing
        Testo = "Si è prodotto l'errore " & Errore & vbCrLf
        Testo = Testo & "E' possibile che non sia stato trovato" & vbCrLf
        Testo = Testo & "il rapporto di calcolo, o l'applicazione" & vbCrLf
        Testo = Testo & "WinWord che lo gestisce." & vbCrLf
        Testo = Testo & "E' possibile che WinWord sia stato chiuso dall'utente." & vbCrLf
        Testo = Testo & "Probabilmente è necessario ricompilare il rapporto."
        MessageBox.Show(Me, Testo)
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal eventargs As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim j, n As Short
        Dim k As String
        If indrag Then
            'Set TreeView1.SelectedItem = Node
            Exit Sub
        End If
        If InStr(eventargs.Node.Tag, "Inv") > 0 Then
            k = VB.Right(eventargs.Node.Tag, Len(eventargs.Node.Tag) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(VB.Left(k, n - 1))
            j = GlobalRoutines.ValVir(VB.Right(k, Len(k) - n))
            mnuDatiElem.Text = "&Dati per " & Trim(Involucr(kLato, j).Mark)
            mnuConvElem.Text = "Con&verti " & Trim(Involucr(kLato, j).Mark)
            mnuInseElem.Text = "&Inserisci prima di &" & Trim(Involucr(kLato, j).Mark)
            mnuCalcElem.Text = "&Calcola " & Trim(Involucr(kLato, j).Mark)
            '  mnuRapp.Caption = "Rapporto " + Trim(Involucr(j).Mark)
            mnuElimElemento.Text = "&Elimina " & Trim(Involucr(kLato, j).Mark)
            mnuDatiElem.Enabled = True
            mnuConvElem.Enabled = True
            mnuInseElem.Enabled = True
            mnuCalcElem.Enabled = True
            mnuElimElemento.Enabled = True
            '  mnuRapp.Enabled = True
            cmdCalc.Enabled = True
            cmdDati.Enabled = True
        End If
        If InStr(eventargs.Node.Tag, "Noz") > 0 Then
            k = VB.Right(eventargs.Node.Tag, Len(eventargs.Node.Tag) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(VB.Left(k, n - 1))
            j = GlobalRoutines.ValVir(VB.Right(k, Len(k) - n))
            mnuDatiElem.Text = "Da&ti per " & Trim(Nozzles(kLato, j).Mark)
            mnuCalcElem.Text = "Ca&lcola " & Trim(Nozzles(kLato, j).Mark)
            mnuElimElemento.Text = "Eli&mina " & Trim(Nozzles(kLato, j).Mark)
            mnuDatiElem.Enabled = True
            mnuCalcElem.Enabled = True
            mnuElimElemento.Enabled = True
            cmdCalc.Enabled = True
            cmdDati.Enabled = True
            mnuConvElem.Enabled = False
            mnuInseElem.Enabled = False
        End If
        'TreeView1.SelectedNode = eventargs.Node
        'TreeView1.DropHighlight = eventargs.Node
        SelNode = eventargs.Node
        'TreeView1.Refresh()
    End Sub
    Private Sub TreeView1_AfterLabelEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        Dim j As Short
        Dim Nodex As TreeNode
        Dim k As String
        Dim n As Short
        Nodex = TreeView1.SelectedNode
        If Nodex Is Nothing Then Exit Sub
        k = Nodex.Tag
        k = VB.Right(k, Len(k) - 3)
        n = InStr(k, "_")
        kLato = GlobalRoutines.ValVir(VB.Left(k, n - 1))
        jInvolucr = GlobalRoutines.ValVir(VB.Right(k, Len(k) - n))
        j = jInvolucr
        If Not e.Label Is Nothing Then
            If InStr(Nodex.Tag, "Inv") > 0 Then
                Involucr(kLato, j).Mark = e.Label
            ElseIf InStr(Nodex.Tag, "Noz") > 0 Then
                Nozzles(kLato, j).Mark = e.Label
            End If
        End If
        TreeView1_NodeClick(Nodex)

    End Sub

    Private Sub TreeView1_DragDrop1(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragDrop
        Dim InNode, OutNode As TreeNode
        Dim n, jIn, kIn, jj As Short
        Dim jInStr As String
        Dim Salva As Involucro
        Dim SalvaN As NozzleN
        Dim jOutStr As String
        Dim jOut, kOut As Short
        Dim Cercanome As clsCercaNome
        Dim NBocch As Short
        Dim OnNozzle As Boolean

        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        DragNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        ItemUnderMouseToDrop = TreeView1.SelectedNode

        'messagebox.show DragNode.Text + " rilasciato su " + TreeView1.DropHighlight.Text
        InNode = DragNode
        OutNode = ItemUnderMouseToDrop
        If InStr(OutNode.Tag, "L") = 0 And InStr(InNode.Tag, "Noz") = 0 Then
            MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "Si può spostare un elemento solo su un altro lato.")
            TreeView1_NodeClick(InNode)
            Exit Sub
        End If
        If InStr(InNode.Tag, "L") > 0 Then
            MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "Non si può spostare un lato.")
            TreeView1_NodeClick(InNode)
            Exit Sub
        End If
        If InStr(InNode.Tag, "Inv") > 0 Then
            jInStr = VB.Right(InNode.Tag, Len(InNode.Tag) - 3)
            n = InStr(jInStr, "_")
            kIn = GlobalRoutines.ValVir(VB.Left(jInStr, n - 1))
            jIn = GlobalRoutines.ValVir(VB.Right(jInStr, Len(jInStr) - n))
            If Involucr(kIn, jIn).Fine >= Involucr(kIn, jIn).inizio Then
                MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "Non è ancora previsto spostare elementi con aperture.")
                TreeView1_NodeClick(InNode)
                Exit Sub
            End If
            If InNode.Parent Is OutNode Then
                MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "Non si può spostare un elemento all'interno del suo lato.")
                TreeView1_NodeClick(InNode)
                Exit Sub
            End If
            If Involucr(kIn, jIn).Tipo = 7 Or Involucr(kIn, jIn).Tipo = 8 Then
                MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "I tubi e le piastre tubiere non si possono spostare.")
                TreeView1_NodeClick(InNode)
                Exit Sub
            End If
            If Involucr(kIn, jIn).Tipo = 9 Then
                MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "I setti partitori sono previsti solo nel lato tubi.")
                TreeView1_NodeClick(InNode)
                Exit Sub
            End If
            kLato = kIn
            If Collega1(jIn) Then
                TreeView1_NodeClick(InNode)
                Exit Sub
            End If
            Salva = Involucr(kIn, jIn)
            SelNode = InNode
            ElimElemento(True)
            kLato = OutNode.ImageIndex - 6
            Config(kLato).Ninvolucri = Config(kLato).Ninvolucri + 1
            Involucr(kLato, Config(kLato).Ninvolucri) = Salva
            If Not ElencoInvolucri Is Nothing Then
                Apparecchio.Elementi(Involucr(kLato, Config(kLato).Ninvolucri).Mark).Genmem.Lato = kLato
                Cercanome = ElencoInvolucri(Involucr(kLato, Config(kLato).Ninvolucri).Mark)
                Cercanome.kLato = kLato
                Cercanome.jInvolucr = Config(kLato).Ninvolucri
            End If
        ElseIf InStr(InNode.Tag, "Noz") > 0 Then
            If InStr(OutNode.Tag, "Inv") = 0 Then
                OnNozzle = True
                'messagebox.show "   Operazione non valida." + vbCrLf + "Lo spostamento di un bocchello può avvenire solo su un involucro.", vbCritical
                'TreeView1_NodeClick InNode
                'Exit Sub
            End If
            jInStr = VB.Right(InNode.Tag, Len(InNode.Tag) - 3)
            n = InStr(jInStr, "_")
            kIn = GlobalRoutines.ValVir(VB.Left(jInStr, n - 1))
            jIn = GlobalRoutines.ValVir(VB.Right(jInStr, Len(jInStr) - n))
            jOutStr = VB.Right(OutNode.Tag, Len(OutNode.Tag) - 3)
            n = InStr(jOutStr, "_")
            kOut = GlobalRoutines.ValVir(VB.Left(jOutStr, n - 1))
            jOut = GlobalRoutines.ValVir(VB.Right(jOutStr, Len(jOutStr) - n))
            If Not OnNozzle Then
                Select Case Involucr(kOut, jOut).Tipo
                    Case 0, 1, 2, 3
                    Case Else
                        MessageBox.Show(Me, "   Operazione non valida." & vbCrLf & "Lo spostamento di un bocchello può avvenire solo su un involucro.")
                        TreeView1_NodeClick(InNode)
                        Exit Sub
                End Select
            End If
            SalvaN = Nozzles(kIn, jIn)
            SelNode = InNode
            ElimElemento(True)
            kLato = kOut
            'jInvolucr = jOut
            jj = jOut
            If OnNozzle Then jj = -jj
            NBocch = NumLoc(kLato, jj)
            AggBocc(jj, NBocch, NBocch + 1)
            If OnNozzle Then
                kNozzle = Nozzles(kLato, -jj).Fine
            Else
                kNozzle = Involucr(kLato, jj).Fine
            End If
            Nozzles(kLato, kNozzle) = SalvaN
            If OnNozzle Then Nozzles(kLato, kNozzle).InvolucroSU = jj
            If Not ElencoInvolucri Is Nothing Then
                Apparecchio.Elementi(Nozzles(kLato, kNozzle).Mark).Genmem.Lato = kLato
                Cercanome = ElencoInvolucri.Item(Trim(Nozzles(kLato, kNozzle).Mark))
                Cercanome.kLato = kLato
                Cercanome.kNozzle = kNozzle
            End If
        End If
        DatiInputC(1)
    End Sub

    Private Sub TreeView1_DragOver1(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragOver
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        'As the mouse moves over nodes, provide feedback to the user
        'by highlighting the node that is the current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = TreeView1.GetNodeAt(pt)

        'See if the targetNode is currently selected, if so no need to validate again
        If Not (TreeView1.SelectedNode Is targetNode) Then 'non c'era selectednode
            'Select the node currently under the cursor
            TreeView1.SelectedNode = targetNode

            'Check that the selected node is not the dropNode and also that it
            'is not a child of the dropNode and therefore an invalid target
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            Do Until targetNode Is Nothing
                If targetNode Is dropNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                targetNode = targetNode.Parent
            Loop
        End If

        'Currently selected node is a suitable target, allow the move
        e.Effect = DragDropEffects.Move

    End Sub
    Private Sub _cmdVisual_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmdVisual_0.Click
        FattoMAWP = False
        Distruggi(colMAWP)
        If Documento Is Nothing Then If Not Visualizza() Then Exit Sub
        VisualCap()
    End Sub
    Private Sub _cmdVisual_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdVisual_1.Click
        FattoMAWP = False
        Distruggi(colMAWP)
        Visualizza()
    End Sub
    Private Sub _mnuDis_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuDis_0.Click
        Monitor.Motore.Inizio.LavoriSciolti = False
        SelezionaJob()
    End Sub
    Private Sub _mnuDis_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuDis_1.Click
        Dim ProtoTyp As String = ""
        Dim crea As Boolean
        Caricajob()
        Libgra.PPSM(Monitor.Motore.Inizio.DiscoRam, job, ProtoTyp, crea)
    End Sub
    Private Sub _mnuEdiz_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuEdiz_0.Click
        Dim Stringa(10) As String
        Dim Result(10) As String
        Dim Ris As Boolean
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Result(1) = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "Division1")
        Result(2) = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "Division2")
        Stringa(1) = "ASME VIII div.1"
        Stringa(2) = "ASME VIII div.2"
        Ris = Monitor.Motore.InputDati(2, "AsmeVip- Codici applicabili", Stringa, Result, "", Archiv, dAiu)
        If Ris Then
            clsInizio.WriteIniFile("", "Preferenze AsmeVip", "Division1", Result(1))
            clsInizio.WriteIniFile("", "Preferenze AsmeVip", "Division2", Result(2))
        End If
    End Sub
    Private Sub _mnuEdiz_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuEdiz_1.Click
        Dim Mat As New LibMat.MaterialeNew1
        Dim File As String = ""
        Mat.Edizioni(UltimoAggiornamento, File)
        Monitor.Motore.Inizio.WriteIniFile("", "Parametri", "UltimoAggiornamento", Str(UltimoAggiornamento))
    End Sub
    Private Sub TreeView1_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        e.Node.SelectedImageIndex = e.Node.ImageIndex
    End Sub
    Private Sub Apert_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Monitor.Motore.Problem = Monitor.Motore.Problems("ASME").Problem
        Monitor.Motore.About = Monitor.Motore.Problems("ASME").About
    End Sub
    Private Sub mnuUG22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUG22.Click
        Dim Testo As String
        OptUG22 = Not OptUG22
        mnuUG22.Checked = OptUG22
        If OptUG22 Then Testo = "Si" Else Testo = "No"
        clsInizio.WriteIniFile("", "Preferenze AsmeVip", "UG-22", Testo)

    End Sub
    Private Sub TreeView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragEnter
        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub TreeView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
        'Set the drag node and initiate the DragDrop
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub
    Private Sub mnuWordIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWordIn.Click
        Dim Testo As String
        mnuWordIn.Checked = Not mnuWordIn.Checked
        OptWordIn = mnuWordIn.Checked
        Try
            If OptWordIn Then
                Testo = "Si"
                wordPanel.EnsureStarted()
                wordPanel.SetTemplate(Monitor.Motore.Inizio.Archdir + "\mioTemplate.dot")
                TabRapporto.Enabled = True
            Else
                Testo = "No"
                TabRapporto.SelectedIndex = 0
                wordPanel.ShowWord()
                TabRapporto.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
        TabRapporto.Enabled = OptWordIn
        clsInizio.WriteIniFile("", "Preferenze AsmeVip", "WordEmbedded", Testo)
    End Sub
    Private Sub Apert_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not wordPanel Is Nothing Then
            Try
                wordPanel.CloseSession()
            Catch ex As Exception
                e.Cancel = True
                MessageBox.Show(ex.Message, "Microsoft Word")
            End Try
        End If
    End Sub
    Private Sub Apert_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        lstRes.Columns(0).Width = lstRes.Width * 0.95
    End Sub
End Class