Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.common
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
    Public WithEvents cmbClasse As System.Windows.Forms.ComboBox
    Public WithEvents Disegno As System.Windows.Forms.TextBox
    Public WithEvents Proto As System.Windows.Forms.ListBox
    Public WithEvents ListDisp As System.Windows.Forms.ListBox
    Public WithEvents IndiceClasse As System.Windows.Forms.ListBox
    Public WithEvents Impianto As System.Windows.Forms.TextBox
    Public WithEvents Numero As System.Windows.Forms.TextBox
    Public WithEvents LungM As System.Windows.Forms.TextBox
    Public WithEvents LargM As System.Windows.Forms.TextBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Progettista As System.Windows.Forms.TextBox
    Public WithEvents Denomin As System.Windows.Forms.TextBox
    Public WithEvents Oggetto As System.Windows.Forms.TextBox
    Public WithEvents Cliente As System.Windows.Forms.TextBox
    Public WithEvents cmdProto As System.Windows.Forms.Button
    Public WithEvents Grid1 As DataGrid
    Public WithEvents lblProto As System.Windows.Forms.Label
    Public WithEvents LabHV As System.Windows.Forms.Label
    Public WithEvents FBMLabel As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents TEMA As System.Windows.Forms.Label
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents LabTEMA As System.Windows.Forms.Label
    Public WithEvents LabFBM As System.Windows.Forms.Label
    Public WithEvents LabDisp As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents lblNomeProto As System.Windows.Forms.Label
    Public WithEvents mnuApri As System.Windows.Forms.MenuItem
    Public WithEvents mnuSalva As System.Windows.Forms.MenuItem
    Public WithEvents mnuChiudi As System.Windows.Forms.MenuItem
    Public WithEvents mnuEsci As System.Windows.Forms.MenuItem
    Public WithEvents mnuFile As System.Windows.Forms.MenuItem
    Public WithEvents mnuLibrMat As System.Windows.Forms.MenuItem
    Public WithEvents mnuLibr As System.Windows.Forms.MenuItem
    Public WithEvents mnuAree As System.Windows.Forms.MenuItem
    Public WithEvents mnuLavori As System.Windows.Forms.MenuItem
    Public WithEvents mnuVerboso As System.Windows.Forms.MenuItem
    Public WithEvents mnuPref As System.Windows.Forms.MenuItem
    Public WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Public WithEvents mnuH As System.Windows.Forms.MenuItem
    Public MainMenu1 As System.Windows.Forms.MainMenu
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents Command3D1 As System.Windows.Forms.Button
    Friend WithEvents Command3D2 As System.Windows.Forms.Button
    Friend WithEvents Comannd3D4 As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDataSheet As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDistinta As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGrezzi As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFormati As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCalcoli As System.Windows.Forms.MenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Apert))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbClasse = New System.Windows.Forms.ComboBox
        Me.Disegno = New System.Windows.Forms.TextBox
        Me.Proto = New System.Windows.Forms.ListBox
        Me.ListDisp = New System.Windows.Forms.ListBox
        Me.IndiceClasse = New System.Windows.Forms.ListBox
        Me.Impianto = New System.Windows.Forms.TextBox
        Me.Numero = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.LungM = New System.Windows.Forms.TextBox
        Me.LargM = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Progettista = New System.Windows.Forms.TextBox
        Me.Denomin = New System.Windows.Forms.TextBox
        Me.Oggetto = New System.Windows.Forms.TextBox
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.cmdProto = New System.Windows.Forms.Button
        Me.Grid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.lblProto = New System.Windows.Forms.Label
        Me.LabHV = New System.Windows.Forms.Label
        Me.FBMLabel = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me.TEMA = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.LabTEMA = New System.Windows.Forms.Label
        Me.LabFBM = New System.Windows.Forms.Label
        Me.LabDisp = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me.lblNomeProto = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuApri = New System.Windows.Forms.MenuItem
        Me.mnuSalva = New System.Windows.Forms.MenuItem
        Me.mnuChiudi = New System.Windows.Forms.MenuItem
        Me.mnuEsci = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuDataSheet = New System.Windows.Forms.MenuItem
        Me.mnuDistinta = New System.Windows.Forms.MenuItem
        Me.mnuGrezzi = New System.Windows.Forms.MenuItem
        Me.mnuFormati = New System.Windows.Forms.MenuItem
        Me.mnuCalcoli = New System.Windows.Forms.MenuItem
        Me.mnuLibr = New System.Windows.Forms.MenuItem
        Me.mnuLibrMat = New System.Windows.Forms.MenuItem
        Me.mnuPref = New System.Windows.Forms.MenuItem
        Me.mnuAree = New System.Windows.Forms.MenuItem
        Me.mnuLavori = New System.Windows.Forms.MenuItem
        Me.mnuVerboso = New System.Windows.Forms.MenuItem
        Me.mnuH = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.Command3D1 = New System.Windows.Forms.Button
        Me.Command3D2 = New System.Windows.Forms.Button
        Me.Comannd3D4 = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frame1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbClasse
        '
        Me.cmbClasse.BackColor = System.Drawing.SystemColors.Window
        Me.cmbClasse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbClasse.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbClasse.Location = New System.Drawing.Point(72, 82)
        Me.cmbClasse.Name = "cmbClasse"
        Me.cmbClasse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbClasse.Size = New System.Drawing.Size(249, 21)
        Me.cmbClasse.TabIndex = 39
        '
        'Disegno
        '
        Me.Disegno.AcceptsReturn = True
        Me.Disegno.AutoSize = False
        Me.Disegno.BackColor = System.Drawing.SystemColors.Window
        Me.Disegno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Disegno.Enabled = False
        Me.Disegno.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Disegno.Location = New System.Drawing.Point(488, 56)
        Me.Disegno.MaxLength = 0
        Me.Disegno.Name = "Disegno"
        Me.Disegno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Disegno.Size = New System.Drawing.Size(81, 21)
        Me.Disegno.TabIndex = 37
        Me.Disegno.Text = ""
        '
        'Proto
        '
        Me.Proto.BackColor = System.Drawing.SystemColors.Window
        Me.Proto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Proto.Cursor = System.Windows.Forms.Cursors.Default
        Me.Proto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Proto.Location = New System.Drawing.Point(450, 0)
        Me.Proto.Name = "Proto"
        Me.Proto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Proto.Size = New System.Drawing.Size(61, 54)
        Me.Proto.TabIndex = 36
        Me.Proto.Visible = False
        '
        'ListDisp
        '
        Me.ListDisp.BackColor = System.Drawing.SystemColors.Window
        Me.ListDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListDisp.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListDisp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListDisp.Location = New System.Drawing.Point(390, 124)
        Me.ListDisp.Name = "ListDisp"
        Me.ListDisp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListDisp.Size = New System.Drawing.Size(72, 28)
        Me.ListDisp.TabIndex = 31
        Me.ListDisp.Visible = False
        '
        'IndiceClasse
        '
        Me.IndiceClasse.BackColor = System.Drawing.SystemColors.Window
        Me.IndiceClasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IndiceClasse.Cursor = System.Windows.Forms.Cursors.Default
        Me.IndiceClasse.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IndiceClasse.Location = New System.Drawing.Point(510, 0)
        Me.IndiceClasse.Name = "IndiceClasse"
        Me.IndiceClasse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.IndiceClasse.Size = New System.Drawing.Size(61, 54)
        Me.IndiceClasse.TabIndex = 29
        Me.IndiceClasse.Visible = False
        '
        'Impianto
        '
        Me.Impianto.AcceptsReturn = True
        Me.Impianto.AutoSize = False
        Me.Impianto.BackColor = System.Drawing.SystemColors.Window
        Me.Impianto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Impianto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Impianto.Location = New System.Drawing.Point(72, 60)
        Me.Impianto.MaxLength = 0
        Me.Impianto.Name = "Impianto"
        Me.Impianto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Impianto.Size = New System.Drawing.Size(341, 21)
        Me.Impianto.TabIndex = 14
        Me.Impianto.Text = ""
        '
        'Numero
        '
        Me.Numero.AcceptsReturn = True
        Me.Numero.AutoSize = False
        Me.Numero.BackColor = System.Drawing.SystemColors.Window
        Me.Numero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Numero.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Numero.Location = New System.Drawing.Point(536, 80)
        Me.Numero.MaxLength = 0
        Me.Numero.Multiline = True
        Me.Numero.Name = "Numero"
        Me.Numero.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Numero.Size = New System.Drawing.Size(31, 21)
        Me.Numero.TabIndex = 15
        Me.Numero.Text = ""
        Me.Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.LungM)
        Me.Frame1.Controls.Add(Me.LargM)
        Me.Frame1.Controls.Add(Me.Label12)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(410, 130)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(161, 71)
        Me.Frame1.TabIndex = 9
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Formati lamiere (mm)"
        '
        'LungM
        '
        Me.LungM.AcceptsReturn = True
        Me.LungM.AutoSize = False
        Me.LungM.BackColor = System.Drawing.SystemColors.Window
        Me.LungM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LungM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LungM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LungM.Location = New System.Drawing.Point(100, 40)
        Me.LungM.MaxLength = 0
        Me.LungM.Multiline = True
        Me.LungM.Name = "LungM"
        Me.LungM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LungM.Size = New System.Drawing.Size(51, 21)
        Me.LungM.TabIndex = 18
        Me.LungM.Text = ""
        Me.LungM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LargM
        '
        Me.LargM.AcceptsReturn = True
        Me.LargM.AutoSize = False
        Me.LargM.BackColor = System.Drawing.SystemColors.Window
        Me.LargM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LargM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LargM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LargM.Location = New System.Drawing.Point(100, 20)
        Me.LargM.MaxLength = 0
        Me.LargM.Multiline = True
        Me.LargM.Name = "LargM"
        Me.LargM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LargM.Size = New System.Drawing.Size(51, 21)
        Me.LargM.TabIndex = 17
        Me.LargM.Text = ""
        Me.LargM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(10, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(81, 21)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Larghezza"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(10, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 21)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Lunghezza"
        '
        'Progettista
        '
        Me.Progettista.AcceptsReturn = True
        Me.Progettista.AutoSize = False
        Me.Progettista.BackColor = System.Drawing.SystemColors.Window
        Me.Progettista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Progettista.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Progettista.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Progettista.Location = New System.Drawing.Point(310, 124)
        Me.Progettista.MaxLength = 0
        Me.Progettista.Name = "Progettista"
        Me.Progettista.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Progettista.Size = New System.Drawing.Size(81, 21)
        Me.Progettista.TabIndex = 16
        Me.Progettista.Text = ""
        '
        'Denomin
        '
        Me.Denomin.AcceptsReturn = True
        Me.Denomin.AutoSize = False
        Me.Denomin.BackColor = System.Drawing.SystemColors.Window
        Me.Denomin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Denomin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Denomin.Location = New System.Drawing.Point(72, 40)
        Me.Denomin.MaxLength = 0
        Me.Denomin.Name = "Denomin"
        Me.Denomin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Denomin.Size = New System.Drawing.Size(341, 21)
        Me.Denomin.TabIndex = 13
        Me.Denomin.Text = ""
        '
        'Oggetto
        '
        Me.Oggetto.AcceptsReturn = True
        Me.Oggetto.AutoSize = False
        Me.Oggetto.BackColor = System.Drawing.SystemColors.Window
        Me.Oggetto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Oggetto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Oggetto.Location = New System.Drawing.Point(72, 20)
        Me.Oggetto.MaxLength = 0
        Me.Oggetto.Name = "Oggetto"
        Me.Oggetto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Oggetto.Size = New System.Drawing.Size(341, 21)
        Me.Oggetto.TabIndex = 12
        Me.Oggetto.Text = ""
        '
        'Cliente
        '
        Me.Cliente.AcceptsReturn = True
        Me.Cliente.AutoSize = False
        Me.Cliente.BackColor = System.Drawing.SystemColors.Window
        Me.Cliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Cliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cliente.Location = New System.Drawing.Point(72, 0)
        Me.Cliente.MaxLength = 0
        Me.Cliente.Multiline = True
        Me.Cliente.Name = "Cliente"
        Me.Cliente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cliente.Size = New System.Drawing.Size(341, 21)
        Me.Cliente.TabIndex = 11
        Me.Cliente.Text = ""
        '
        'cmdProto
        '
        Me.cmdProto.BackColor = System.Drawing.SystemColors.Control
        Me.cmdProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdProto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdProto.Location = New System.Drawing.Point(120, 164)
        Me.cmdProto.Name = "cmdProto"
        Me.cmdProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdProto.Size = New System.Drawing.Size(71, 21)
        Me.cmdProto.TabIndex = 35
        Me.cmdProto.Text = "Visualizza"
        Me.cmdProto.Visible = False
        '
        'Grid1
        '
        Me.Grid1.CaptionVisible = False
        Me.Grid1.DataMember = ""
        Me.Grid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid1.Location = New System.Drawing.Point(70, 164)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(311, 121)
        Me.Grid1.TabIndex = 28
        Me.Grid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.Grid1.Visible = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.Grid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        Me.DataGridTableStyle1.RowHeaderWidth = 25
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Descrizione"
        Me.DataGridTextBoxColumn1.MappingName = ""
        Me.DataGridTextBoxColumn1.Width = 141
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Dettagli"
        Me.DataGridTextBoxColumn2.MappingName = ""
        Me.DataGridTextBoxColumn2.Width = 133
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = ""
        Me.DataGridTextBoxColumn3.Width = 17
        '
        'lblProto
        '
        Me.lblProto.BackColor = System.Drawing.SystemColors.Control
        Me.lblProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProto.Location = New System.Drawing.Point(0, 164)
        Me.lblProto.Name = "lblProto"
        Me.lblProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProto.Size = New System.Drawing.Size(71, 21)
        Me.lblProto.TabIndex = 33
        Me.lblProto.Text = "Prototipo"
        Me.lblProto.Visible = False
        '
        'LabHV
        '
        Me.LabHV.BackColor = System.Drawing.SystemColors.Window
        Me.LabHV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabHV.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabHV.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabHV.Location = New System.Drawing.Point(360, 104)
        Me.LabHV.Name = "LabHV"
        Me.LabHV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabHV.Size = New System.Drawing.Size(51, 21)
        Me.LabHV.TabIndex = 32
        '
        'FBMLabel
        '
        Me.FBMLabel.BackColor = System.Drawing.SystemColors.Window
        Me.FBMLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FBMLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FBMLabel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FBMLabel.Location = New System.Drawing.Point(70, 144)
        Me.FBMLabel.Name = "FBMLabel"
        Me.FBMLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FBMLabel.Size = New System.Drawing.Size(311, 21)
        Me.FBMLabel.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(0, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(71, 21)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Sottotipo"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(2, 60)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(51, 21)
        Me._Label1_5.TabIndex = 22
        Me._Label1_5.Text = "Impianto"
        '
        'TEMA
        '
        Me.TEMA.BackColor = System.Drawing.SystemColors.Window
        Me.TEMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEMA.Enabled = False
        Me.TEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TEMA.Location = New System.Drawing.Point(70, 124)
        Me.TEMA.Name = "TEMA"
        Me.TEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEMA.Size = New System.Drawing.Size(51, 21)
        Me.TEMA.TabIndex = 1
        Me.TEMA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_6.Location = New System.Drawing.Point(230, 124)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(81, 21)
        Me._Label1_6.TabIndex = 8
        Me._Label1_6.Text = "Progettista:"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(424, 56)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(41, 21)
        Me._Label1_9.TabIndex = 7
        Me._Label1_9.Text = "N.Dis."
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(496, 80)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(31, 21)
        Me._Label1_8.TabIndex = 6
        Me._Label1_8.Text = "Q.tà"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(2, 40)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(55, 21)
        Me._Label1_4.TabIndex = 4
        Me._Label1_4.Text = "Servizio"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(2, 20)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(61, 21)
        Me._Label1_0.TabIndex = 3
        Me._Label1_0.Text = "Oggetto"
        '
        'LabTEMA
        '
        Me.LabTEMA.BackColor = System.Drawing.SystemColors.Control
        Me.LabTEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabTEMA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabTEMA.Location = New System.Drawing.Point(0, 124)
        Me.LabTEMA.Name = "LabTEMA"
        Me.LabTEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabTEMA.Size = New System.Drawing.Size(71, 21)
        Me.LabTEMA.TabIndex = 0
        Me.LabTEMA.Text = "Tipo TEMA"
        '
        'LabFBM
        '
        Me.LabFBM.BackColor = System.Drawing.SystemColors.Control
        Me.LabFBM.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabFBM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabFBM.Location = New System.Drawing.Point(0, 83)
        Me.LabFBM.Name = "LabFBM"
        Me.LabFBM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabFBM.Size = New System.Drawing.Size(71, 21)
        Me.LabFBM.TabIndex = 19
        Me.LabFBM.Text = "Classe"
        '
        'LabDisp
        '
        Me.LabDisp.BackColor = System.Drawing.SystemColors.Control
        Me.LabDisp.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabDisp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabDisp.Location = New System.Drawing.Point(330, 104)
        Me.LabDisp.Name = "LabDisp"
        Me.LabDisp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabDisp.Size = New System.Drawing.Size(31, 21)
        Me.LabDisp.TabIndex = 5
        Me.LabDisp.Text = "Disp."
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(2, 0)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(61, 21)
        Me._Label1_3.TabIndex = 2
        Me._Label1_3.Text = "Cliente"
        '
        'lblNomeProto
        '
        Me.lblNomeProto.BackColor = System.Drawing.SystemColors.Window
        Me.lblNomeProto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNomeProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNomeProto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNomeProto.Location = New System.Drawing.Point(70, 164)
        Me.lblNomeProto.Name = "lblNomeProto"
        Me.lblNomeProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNomeProto.Size = New System.Drawing.Size(51, 21)
        Me.lblNomeProto.TabIndex = 34
        Me.lblNomeProto.Visible = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.MenuItem1, Me.mnuLibr, Me.mnuPref, Me.mnuH})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuApri, Me.mnuSalva, Me.mnuChiudi, Me.mnuEsci})
        Me.mnuFile.Text = "&File"
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
        'mnuChiudi
        '
        Me.mnuChiudi.Index = 2
        Me.mnuChiudi.Text = "&Chiudi"
        '
        'mnuEsci
        '
        Me.mnuEsci.Index = 3
        Me.mnuEsci.Text = "&Esci"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDataSheet, Me.mnuDistinta, Me.mnuGrezzi, Me.mnuFormati, Me.mnuCalcoli})
        Me.MenuItem1.Text = "Azioni"
        '
        'mnuDataSheet
        '
        Me.mnuDataSheet.Enabled = False
        Me.mnuDataSheet.Index = 0
        Me.mnuDataSheet.Text = "Compila il datasheet"
        '
        'mnuDistinta
        '
        Me.mnuDistinta.Enabled = False
        Me.mnuDistinta.Index = 1
        Me.mnuDistinta.Text = "Compila la distinta"
        '
        'mnuGrezzi
        '
        Me.mnuGrezzi.Enabled = False
        Me.mnuGrezzi.Index = 2
        Me.mnuGrezzi.Text = "Conteggia i grezzi"
        '
        'mnuFormati
        '
        Me.mnuFormati.Enabled = False
        Me.mnuFormati.Index = 3
        Me.mnuFormati.Text = "Esegui i lamieramenti"
        '
        'mnuCalcoli
        '
        Me.mnuCalcoli.Enabled = False
        Me.mnuCalcoli.Index = 4
        Me.mnuCalcoli.Text = "Calcoli meccanici"
        '
        'mnuLibr
        '
        Me.mnuLibr.Index = 2
        Me.mnuLibr.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuLibrMat})
        Me.mnuLibr.Text = "&Librerie"
        '
        'mnuLibrMat
        '
        Me.mnuLibrMat.Index = 0
        Me.mnuLibrMat.Text = "&Materiali"
        '
        'mnuPref
        '
        Me.mnuPref.Index = 3
        Me.mnuPref.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAree, Me.mnuLavori, Me.mnuVerboso})
        Me.mnuPref.Text = "&Preferenze"
        '
        'mnuAree
        '
        Me.mnuAree.Index = 0
        Me.mnuAree.Text = "&Aree di lavoro"
        '
        'mnuLavori
        '
        Me.mnuLavori.Index = 1
        Me.mnuLavori.Text = "&Tipi di Lavori"
        '
        'mnuVerboso
        '
        Me.mnuVerboso.Index = 2
        Me.mnuVerboso.Text = "PPSM verboso"
        '
        'mnuH
        '
        Me.mnuH.Index = 4
        Me.mnuH.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelp})
        Me.mnuH.Text = "?"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 0
        Me.mnuHelp.Text = "Guida di IST"
        '
        'Command3D1
        '
        Me.Command3D1.Image = CType(resources.GetObject("Command3D1.Image"), System.Drawing.Image)
        Me.Command3D1.Location = New System.Drawing.Point(124, 124)
        Me.Command3D1.Name = "Command3D1"
        Me.Command3D1.Size = New System.Drawing.Size(21, 21)
        Me.Command3D1.TabIndex = 44
        '
        'Command3D2
        '
        Me.Command3D2.Image = CType(resources.GetObject("Command3D2.Image"), System.Drawing.Image)
        Me.Command3D2.Location = New System.Drawing.Point(384, 144)
        Me.Command3D2.Name = "Command3D2"
        Me.Command3D2.Size = New System.Drawing.Size(21, 21)
        Me.Command3D2.TabIndex = 45
        '
        'Comannd3D4
        '
        Me.Comannd3D4.Image = CType(resources.GetObject("Comannd3D4.Image"), System.Drawing.Image)
        Me.Comannd3D4.Location = New System.Drawing.Point(416, 104)
        Me.Comannd3D4.Name = "Comannd3D4"
        Me.Comannd3D4.Size = New System.Drawing.Size(21, 21)
        Me.Comannd3D4.TabIndex = 46
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 288)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(580, 24)
        Me.StatusBar1.TabIndex = 47
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 464
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Text = "Item:"
        '
        'Apert
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(580, 312)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.Comannd3D4)
        Me.Controls.Add(Me.Command3D2)
        Me.Controls.Add(Me.Command3D1)
        Me.Controls.Add(Me.cmbClasse)
        Me.Controls.Add(Me.Disegno)
        Me.Controls.Add(Me.Impianto)
        Me.Controls.Add(Me.Numero)
        Me.Controls.Add(Me.Progettista)
        Me.Controls.Add(Me.Denomin)
        Me.Controls.Add(Me.Oggetto)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.Proto)
        Me.Controls.Add(Me.ListDisp)
        Me.Controls.Add(Me.IndiceClasse)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdProto)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.lblProto)
        Me.Controls.Add(Me.LabHV)
        Me.Controls.Add(Me.FBMLabel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me.TEMA)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_9)
        Me.Controls.Add(Me._Label1_8)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me.LabTEMA)
        Me.Controls.Add(Me.LabFBM)
        Me.Controls.Add(Me.LabDisp)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me.lblNomeProto)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(29, 104)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Apert"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "IST - Configurazione apparecchio S&T"
        Me.Frame1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private CandidatoElimina As Short
    Private PassoBaric As Short
    Private OKpuoiIniziare As Boolean '13-5-99
    Private Inizializzando As Boolean
    Private tbGrid As DataTable
    Private dvGrid As DataView
    Public Color13 As Integer
    Private Sub AggiorClasse()
        Dim j As Short
        cmbClasse.Text = ""
        If Asc(DataSheet.DatiSh0.FBMLetter) < 33 Then Exit Sub
        Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
        dbClassi = New OleDbConnection(cString)
        Dim tbClassi = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Tipi", dbClassi)
        cmd.Fill(tbClassi)
        Dim dvClassi As DataView = New DataView(tbClassi)
        Dim jj As Short = 0
        For j = 0 To dvClassi.Count - 1
            If dvClassi(j)("Codice") = DataSheet.DatiSh0.FBMLetter Then
                cmbClasse.Enabled = False
                cmbClasse.SelectedIndex = jj
                cmbClasse.Enabled = True
                Exit Sub
            End If
            jj = jj + 1
        Next
        tbClassi.Close()
        dbClassi.Close()
    End Sub
    Private Sub AggiorFBM()
        Dim i, NRows As Short
        Dim Includi, SW(8) As Boolean
        Dim CodCon(8) As String
        '1 Categoria FBM
        '2 Codice progressivo
        '3 Classe di costruzione
        '4 Classe TEMA
        '5 Descrizione
        '6 Dettagli
        '7 Disposizione
        '8 Prototipo
        Try
            IndiceClasse.Items.Clear()
            Proto.Items.Clear()
            '  Grid1.FixedRows = 0
            '  NRows = Grid1.Rows
            '  For i = NRows - 1 To 1 Step -1 : Grid1.RemoveItem(i) : Next
            For i = 0 To dvGrid.Count - 1
                dvGrid.Delete(0)
            Next
            CodCon(1) = DataSheet.DatiSh0.FBMLetter
            SW(1) = CodCon(1).Trim.Length > 0
            CodCon(4) = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
            SW(4) = CodCon(4).Trim.Length = 3
            CodCon(7) = job.Comm.Asse
            SW(7) = (CodCon(7) = "H" Or CodCon(7) = "V")
            Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
            dbClassi = New OleDbConnection(cString)
            cmdClassi = New OleDbDataAdapter("SELECT * FROM Classi", dbClassi)
            tbClassi = New DataTable
            cmdClassi.Fill(tbClassi)
            CBClassi = New OleDbCommandBuilder(cmdClassi)
            dvClassi = tbClassi.DefaultView
            Dim ii As Short
            For ii = 0 To dvClassi.Count - 1
                Includi = False
                For i = 1 To 8
                    If SW(i) Then
                        If IsDBNull(dvClassi(ii)(i)) Then
                            Includi = Len(Trim(CodCon(i))) = 0
                        Else
                            Includi = (dvClassi(ii)(i) = CodCon(i))
                        End If
                        If Not Includi Then Exit For
                    End If
                Next
                If Includi Then
                    Dim drv As DataRowView = dvGrid.AddNew
                    drv.BeginEdit()
                    drv(0) = dvClassi(ii)(5)
                    drv(1) = dvClassi(ii)(6)
                    drv(2) = dvClassi(ii)(7)
                    drv.EndEdit()
                    '        Grid1.AddItem(dvClassi(ii)(5) & Chr(9) & dvClassi(ii)(6) & Chr(9) + dvClassi(ii)(7))
                    IndiceClasse.Items.Add(dvClassi(ii)(2))
                    If IsDBNull(dvClassi(ii)(8)) Then
                        Proto.Items.Add("")
                    Else
                        Proto.Items.Add(dvClassi(ii)(8))
                    End If
                End If
            Next
            NRows = dvGrid.Count
            If NRows = 0 Then
                Command3D2.Enabled = False
                Exit Sub
            Else
                Command3D2.Enabled = True
            End If
            'Grid1.FixedRows = 1
            'Grid1.Row = 0
            'Grid1.Col = 0 : Grid1.Text = "Descrizione"
            'Grid1.Col = 1 : Grid1.Text = "Dettagli"
            'Grid1.Row = 1 : Grid1.Col = 0
            If NRows > 7 Then
                NRows = 7
                Grid1.TableStyles(0).GridColumnStyles(0).Width = Grid1.Width - Grid1.TableStyles(0).GridColumnStyles(1).Width - _
                                                                 Grid1.TableStyles(0).GridColumnStyles(2).Width - _
                                                                 Grid1.TableStyles(0).RowHeaderWidth * (-CShort(Grid1.TableStyles(0).RowHeadersVisible)) - 20
            Else
                Grid1.TableStyles(0).GridColumnStyles(0).Width = Grid1.Width - Grid1.TableStyles(0).GridColumnStyles(1).Width - _
                                                                 Grid1.TableStyles(0).GridColumnStyles(2).Width - _
                                                                 Grid1.TableStyles(0).RowHeaderWidth * (-CShort(Grid1.TableStyles(0).RowHeadersVisible)) - 4
            End If
            'Grid1.Height = System.Math.Max(3, (NRows + 1)) * Grid1.PreferredRowHeight ' VB6.TwipsToPixelsY(NRows * (Grid1.get_RowHeight(0) + 30)) '???
            AggiorLabel()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggiorLabel()
        Dim Text1 As String
        If Val(DataSheet.DatiSh0.IndCodice) = 0 Then FBMLabel.Text = " " : Exit Sub
        Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
        dbClassi = New OleDbConnection(cString)
        Dim tbClassi = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Classi", dbClassi)
        cmd.Fill(tbClassi)
        Dim dvClassi As DataView = New DataView(tbClassi)
        Dim ii As Short
        For ii = 0 To dvClassi.Count - 1
            If Val(DataSheet.DatiSh0.IndCodice) = dvClassi(ii)("Codice") And DataSheet.DatiSh0.FBMLetter = dvClassi(ii)(1) Then
                Text1 = dvClassi(ii)(5) + " ; " + dvClassi(ii)(6)
                FBMLabel.Text = Text1
                If IsDBNull(dvClassi(ii)("Commessa")) Then
                    ProtoTyp = ""
                Else
                    ProtoTyp = dvClassi(ii)("Commessa")
                End If
                Call AggiorProto()
                Exit Sub
            End If
        Next
        MostraAiuto(IDH_ERR_NOPROTO)
        ' FBMLabel.Caption = ""
    End Sub
    Public Sub AggiorProto()
        lblProto.Visible = True
        lblNomeProto.Visible = True
        cmdProto.Visible = True
        If Len(Trim(ProtoTyp)) > 0 Then
            lblNomeProto.Text = ProtoTyp
            cmdProto.Enabled = True
        Else
            lblNomeProto.Text = "non def."
            cmdProto.Enabled = False
        End If
    End Sub
    'UPGRADE_WARNING: L'evento Cliente.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Cliente_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cliente.TextChanged
        job.Comm.Clie = Cliente.Text
    End Sub
    Private Sub cmbClasse_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbClasse.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        If Not cmbClasse.Enabled Then Exit Sub
        If cmbClasse.SelectedIndex < 0 Then Exit Sub '13-5-99
        If Preserva() Then Exit Sub
        Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
        dbClassi = New OleDbConnection(cString)
        Dim tbClassi = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Tipi WHERE Tipo = '" & cmbClasse.Text & "'", dbClassi)
        cmd.Fill(tbClassi)
        Dim dvClassi As DataView = New DataView(tbClassi)
        ModifiedData = ModifiedData Or (DataSheet.DatiSh0.FBMLetter <> dvClassi(0)("Codice"))
        ModifProto = ModifProto Or (DataSheet.DatiSh0.FBMLetter <> dvClassi(0)("Codice"))
        DataSheet.DatiSh0.FBMLetter = dvClassi(0)("Codice")
        mnuSalva_Click(mnuSalva, New System.EventArgs)
        Call AggiorFBM()
    End Sub

    Private Sub cmdCalcoli_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcoli.Click
        Dim objASME As AsmeVip.CalcASME
        OKpuoiIniziare = True
        Salva(OKpuoiIniziare) '13-5-99
        If Not OKpuoiIniziare Then '13-5-99
            Exit Sub
        End If
        objASME = New AsmeVip.CalcASME
        objASME.DoveMotore = Monitor.Motore
        objASME.DoveFunzioni = Funzioni
        objASME.DoveRoutines = Funzioni.DisRut
        Hide()
        objASME.Trasferisci(job)
        objASME = Nothing
        Show()
    End Sub

    Private Sub cmdFormati_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFormati.Click
        frmForm.DefInstance.ShowDialog()
    End Sub

    Private Sub cmdGrezzi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGrezzi.Click
        Dim Testo As String
        If CheckDoc() Then
            Testo = "Esiste il risultato di una precedente elaborazione." & vbCrLf
            Testo = Testo & "Vuoi aprirlo (Si) o vuoi rielaborare la lista dei grezzi (No)?"
            If MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "PPSM") = MsgBoxResult.Yes Then
                ApriDoc()
                Exit Sub
            End If
        End If
        FileGre = Funzioni.FileDes("GRE")
        ' GrezziMDB = MyWorkspace.OpenDatabase(FileGre)
        CondensaMDB()
        AggiungiLamiereMDB()
        ListaMDB()
        GrezziMDB.Close()
    End Sub

    'Private Sub Baric_Click()
    '       'If PassoBaric Then PassoBaric = False: Exit Sub
    '       If Preserva() Then
    '          'PassoBaric = True
    '          If Baric.Value Then Baric.Value = 0 Else Baric.Value = 1
    '          Exit Sub
    '       End If
    '       'PassoBaric = False
    '       job.Comm.CalcBaric = (Baric.Value = 1)
    '       ModifiedData = True
    'End Sub
    Private Sub cmdProto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProto.Click
        Dim FormProto As New frmProto
        If Not FormProto.Inizializza1() Then Exit Sub
        FormProto.ShowDialog()
    End Sub
    Private Sub Command3D1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3D1.Click
        Dim TemaTyp As String
        If Preserva() Then Exit Sub
        'Salva '13-5-99
        frmTEMA.DefInstance.ShowDialog()
        Call AggiorFBM()
        frmTEMA.DefInstance.Close()
        TemaTyp = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
        If Asc(TemaTyp) < 32 Then TemaTyp = " "
        ModifiedData = ModifiedData Or (TemaTyp <> TEMA.Text)
        ModifProto = ModifProto Or (TemaTyp <> TEMA.Text)
        TEMA.Text = TemaTyp
    End Sub
    Private Sub Command3D2_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3D2.Click
        If Preserva() Then Exit Sub
        Grid1.Visible = True
    End Sub
    Private Sub Command3D4_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Comannd3D4.Click
        If Preserva() Then Exit Sub
        ListDisp.Visible = True
    End Sub
    Private Sub DataSheet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDataSheet.Click
        Dim i, iCod As Short
        Dim Riga As String
        Dim j As Short
        Try
            'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim ifl, iTipo As Short
            DataShee.DefInstance.TexItem.Text = Trim(job.Comm.Ind(job.Comm.indice).Data.Assieme)
            DataShee.DefInstance.Cliente.Text = Cliente.Text
            DataShee.DefInstance.TexServ.Text = Denomin.Text
            DataShee.DefInstance.TexImp.Text = Impianto.Text
            DataShee.DefInstance.TEMA.Text = TEMA.Text
            DataShe1.DefInstance.TexItem.Text = Trim(job.Comm.Ind(job.Comm.indice).Data.Assieme)
            DataShe1.DefInstance.Cliente.Text = Cliente.Text
            DataShe1.DefInstance.TexServ.Text = Denomin.Text
            DataShe1.DefInstance.TexImp.Text = Impianto.Text
            DataShe1.DefInstance.TEMA.Text = TEMA.Text
            DataShe2.DefInstance.TexItem.Text = Trim(job.Comm.Ind(job.Comm.indice).Data.Assieme)
            DataShe2.DefInstance.Cliente.Text = Cliente.Text
            DataShe2.DefInstance.TexServ.Text = Denomin.Text
            DataShe2.DefInstance.TexImp.Text = Impianto.Text
            DataShe2.DefInstance.TEMA.Text = TEMA.Text
            '---------------------------------------------------
            DataShee.DefInstance.NomFluiM.Text = DataSheet.DatiPrg.FluidoMant
            DataShee.DefInstance.NomFluiT.Text = DataSheet.DatiPrg.FluidoTubi
            '---------------------------------------------------
20:         For i = 0 To 5
                DataShee.DefInstance.ValorM(i).Text = Str(DataSheet.DatiS2.ValorM(i + 1))
                DataShee.DefInstance.ValorT(i).Text = Str(DataSheet.DatiS2.ValorT(i + 1))
            Next
            '------------------------------------------------
            Dim Pass(20) As String
            Pass(1) = "1"
            Pass(2) = "2"
            Pass(3) = "Split flow"
            Pass(4) = "Double split flow"
            Pass(5) = "Divided flow"
            Pass(6) = "Cross flow"
24:         DataShee.DefInstance.PassM.Items.Clear()
            For i = 1 To 6
                DataShee.DefInstance.PassM.Items.Add(Pass(i))
            Next
            Select Case DataSheet.DatiSh0.TEMALetter(2)
                Case "E" : i = 0
                Case "F" : i = 1
                Case "G" : i = 2
                Case "H" : i = 3
                Case "J" : i = 4
                Case "K" : i = 0
                Case "X" : i = 5
                Case "-" : i = 0
                Case Else : i = -1
            End Select
            If i > -1 Then
                DataShee.DefInstance.PassM.SelectedIndex = i
                DataShee.DefInstance.PassM.Enabled = False
            Else
                DataShee.DefInstance.PassM.Enabled = True
            End If
            '------------------------------------------------------
30:         If DataSheet.DatiPrg.UniMis < 1 Then DataSheet.DatiPrg.UniMis = 1
            DataShee.DefInstance.Option1(DataSheet.DatiPrg.UniMis - 1).Checked = True
            If DataSheet.DatiSh0.Approved Then DataShee.DefInstance.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked Else DataShee.DefInstance.chkApproved.CheckState = System.Windows.Forms.CheckState.Unchecked
            DataShe1.DefInstance.Option1(DataSheet.DatiPrg.UniMis - 1).Checked = True
            '-------------------------------------------------
            Pass(1) = "Liquido"
            Pass(2) = "Gas"
            Pass(3) = "Gas-liquido"
            Pass(4) = "Condensante"
            Pass(5) = "Evaporante"
            DataShee.DefInstance.FaseM.Items.Clear()
            DataShee.DefInstance.FaseT.Items.Clear()
40:         For i = 1 To 5
                DataShee.DefInstance.FaseM.Items.Add(Pass(i))
                DataShee.DefInstance.FaseT.Items.Add(Pass(i))
            Next
            DataShee.DefInstance.FaseM.SelectedIndex = DataSheet.DatiSh0.FaseM - 1
            DataShee.DefInstance.FaseT.SelectedIndex = DataSheet.DatiSh0.FaseT - 1
            ' --------------VACUUM---------------------------
            DataShe1.DefInstance.ComboM(3).Items.Clear()
            DataShe1.DefInstance.ComboT(3).Items.Clear()
            DataShe1.DefInstance.ComboM(3).Items.Add(" NO")
            DataShe1.DefInstance.ComboT(3).Items.Add(" NO")
            For i = 1 To 9
                DataShe1.DefInstance.ComboM(3).Items.Add(Str(i * 10) & "%")
                DataShe1.DefInstance.ComboT(3).Items.Add(Str(i * 10) & "%")
            Next
            DataShe1.DefInstance.ComboM(3).Items.Add("Full Vacuum")
            DataShe1.DefInstance.ComboT(3).Items.Add("Full Vacuum")
            Select Case DataSheet.DatiPrg.Vacuum
                Case 0
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = 0
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = 0
                Case 1
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = 10
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = 0
                Case 11, 12, 13, 14, 15, 16, 17, 18, 19
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = DataSheet.DatiPrg.Vacuum - 10
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = 0
                Case 2
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = 0
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = 10
                Case 21, 22, 23, 24, 25, 26, 27, 28, 29
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = 0
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = DataSheet.DatiPrg.Vacuum - 20
                Case 3
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = 10
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = 10
                Case 31, 32, 33, 34, 35, 36, 37, 38, 39
                    DataShe1.DefInstance.ComboM(3).SelectedIndex = DataSheet.DatiPrg.Vacuum - 30
                    DataShe1.DefInstance.ComboT(3).SelectedIndex = DataSheet.DatiPrg.Vacuum - 30
            End Select
            '-----------------------------------------------------
50:         DataShe1.DefInstance.ComboM(0).Items.Clear()
            DataShe1.DefInstance.ComboT(0).Items.Clear()
            DataShe1.DefInstance.ComboM(0).Items.Add(" NO")
            DataShe1.DefInstance.ComboM(0).Items.Add(" SI")
            DataShe1.DefInstance.ComboM(0).Items.Add("p.c.")
            DataShe1.DefInstance.ComboT(0).Items.Add(" NO")
            DataShe1.DefInstance.ComboT(0).Items.Add(" SI")
            DataShe1.DefInstance.ComboT(0).Items.Add("p.c.")
            DataShe1.DefInstance.ComboM(0).SelectedIndex = DataSheet.DatiSh0.PHWTMant
            DataShe1.DefInstance.ComboT(0).SelectedIndex = DataSheet.DatiSh0.PHWTTubi
            '---------------------------------------------------------
            DataShe1.DefInstance.ComboM(1).Items.Clear()
            DataShe1.DefInstance.ComboT(1).Items.Clear()
            DataShe1.DefInstance.ComboM(1).Items.Add("  NO")
            DataShe1.DefInstance.ComboM(1).Items.Add("SPOT")
            DataShe1.DefInstance.ComboM(1).Items.Add("100%")
            DataShe1.DefInstance.ComboT(1).Items.Add("  NO")
            DataShe1.DefInstance.ComboT(1).Items.Add("SPOT")
            DataShe1.DefInstance.ComboT(1).Items.Add("100%")
            DataShe1.DefInstance.ComboM(1).SelectedIndex = DataSheet.DatiSh0.RXMant
            DataShe1.DefInstance.ComboT(1).SelectedIndex = DataSheet.DatiSh0.RXTubi
            '---------------------------------------------------------
60:         DataShe1.DefInstance.ValorM(0).Text = Str(DataSheet.DatiSh0.TempMantMin)
            DataShe1.DefInstance.ValorM(1).Text = Str(DataSheet.DatiPrg.TempMant)
            DataShe1.DefInstance.ValorM(2).Text = Str(DataSheet.DatiSh0.TempMantEse)
            DataShe1.DefInstance.ValorM(3).Text = Str(DataSheet.DatiSh0.TempMantStTubi)
            DataShe1.DefInstance.ValorM(4).Text = Str(DataSheet.DatiSh0.TempMantStMant)
            DataShe1.DefInstance.ValorM(5).Text = Str(DataSheet.DatiSh0.TempProgPiastra)
            DataShe1.DefInstance.ValorM(6).Text = Str(DataSheet.DatiPrg.PressMant)
            DataShe1.DefInstance.ValorM(7).Text = Str(DataSheet.DatiSh0.PressMantEse)
            DataShe1.DefInstance.ValorM(8).Text = Str(DataSheet.DatiPrg.NPassMant)
            DataShe1.DefInstance.ValorM(11).Text = Str(DataSheet.DatiPrg.EffMant)
            '---------------------------------------------------------
            DataShe1.DefInstance.ValorT(0).Text = Str(DataSheet.DatiSh0.TempTubiMin)
            DataShe1.DefInstance.ValorT(1).Text = Str(DataSheet.DatiPrg.TempTubi)
            DataShe1.DefInstance.ValorT(2).Text = Str(DataSheet.DatiSh0.TempTubiEse)
            DataShe1.DefInstance.ValorT(3).Text = Str(DataSheet.DatiSh0.TempTubiStTubi)
            DataShe1.DefInstance.ValorT(4).Text = Str(DataSheet.DatiSh0.TempTubiStMant)
            DataShe1.DefInstance.ValorT(6).Text = Str(DataSheet.DatiPrg.PressTubi)
            DataShe1.DefInstance.ValorT(7).Text = Str(DataSheet.DatiSh0.PressTubiEse)
            DataShe1.DefInstance.ValorT(8).Text = Str(DataSheet.DatiPrg.NPassTubi)
            DataShe1.DefInstance.ValorT(11).Text = Str(DataSheet.DatiPrg.EffTubi)
            '---------------------------------------------------------
70:         If DataSheet.DatiPrg.PHyMant > 0 Then
                DataShe1.DefInstance.ProvIdrMant.Enabled = True
                DataShe1.DefInstance.ProvIdrMant.Text = Str(DataSheet.DatiPrg.PHyMant)
                DataShe1.DefInstance.ProvIdrMant.Tag = "Val"
                DataShe1.DefInstance.cmdPHMant.Text = "&Code"
            End If
            If DataSheet.DatiPrg.PHyTubi > 0 Then
                DataShe1.DefInstance.ProvIdrTubi.Enabled = True
                DataShe1.DefInstance.ProvIdrTubi.Text = Str(DataSheet.DatiPrg.PHyTubi)
                DataShe1.DefInstance.ProvIdrTubi.Tag = "Val"
                DataShe1.DefInstance.cmdPHTubi.Text = "&Code"
            End If
            '--------------------------------------------------------
80:         DataShe1.DefInstance.ValorM(9).Text = Str(DataSheet.DatiPrg.CorrMant)
            DataShe1.DefInstance.ValorM(10).Text = Str(DataSheet.DatiPrg.CorrExtMant)
            DataShe1.DefInstance.ValorM(11).Text = Str(DataSheet.DatiPrg.EffMant)
            DataShe1.DefInstance.ValorT(9).Text = Str(DataSheet.DatiPrg.CorrTubi)
            DataShe1.DefInstance.ValorT(10).Text = Str(DataSheet.DatiPrg.CorrExtTubi)
            DataShe1.DefInstance.ValorT(11).Text = Str(DataSheet.DatiPrg.EffTubi)
            '--------------------------------------------------------
            DataShe1.DefInstance.ClasseTEMA.Items.Clear()
            DataShe1.DefInstance.ClasseTEMA.Items.Add("N.A.")
            DataShe1.DefInstance.ClasseTEMA.Items.Add("R")
            DataShe1.DefInstance.ClasseTEMA.Items.Add("C")
            DataShe1.DefInstance.ClasseTEMA.Items.Add("B")
            DataShe1.DefInstance.ClasseTEMA.SelectedIndex = DataSheet.DatiPrg.CodiceM Mod 10
            '---------------------------------------------------------
90:         DataShe1.DefInstance.ComboM(2).Items.Clear()
            DataShe1.DefInstance.ComboT(2).Items.Clear()
            ifl = FreeFile()
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\DIST04.DAT", OpenMode.Input)
            Do
                Riga = LineInput(ifl)
                If Val(Riga) = -1 Then Exit Do
                DataShe1.DefInstance.ComboM(2).Items.Add(Riga)
                DataShe1.DefInstance.ComboT(2).Items.Add(Riga)
            Loop
            FileClose(ifl)
            If DataSheet.DatiPrg.CodiceM < 1 Then DataSheet.DatiPrg.CodiceM = 1
            If DataSheet.DatiPrg.CodiceT < 1 Then DataSheet.DatiPrg.CodiceT = 1
            iCod = DataSheet.DatiPrg.CodiceM
            If iCod > 9 Then iCod = iCod \ 10
            DataShe1.DefInstance.ComboM(2).SelectedIndex = iCod - 1
            iCod = DataSheet.DatiPrg.CodiceT
            If iCod > 9 Then iCod = iCod \ 10
            DataShe1.DefInstance.ComboT(2).SelectedIndex = iCod - 1
            '---------------------------------------------------------
            DataShe1.DefInstance.ValorM(12).Text = Str(DataSheet.DatiPrg.TubiInform.Numero)
            DataShe1.DefInstance.ValorM(13).Text = Str(DataSheet.DatiPrg.TubiInform.Diam)
            DataShe1.DefInstance.ValorM(14).Text = Str(DataSheet.DatiPrg.TubiInform.Spess)
            DataShe1.DefInstance.ValorM(15).Text = Str(DataSheet.DatiPrg.TubiInform.Lungh)
            DataShe1.DefInstance.ValorM(16).Text = Str(DataSheet.DatiPrg.TubiInform.Pitch)
            If DataSheet.DatiPrg.TubiInform.BWG Then DataShe1.DefInstance.TextBWG.Text = Str(DataSheet.DatiPrg.TubiInform.BWG)
            DataShe1.DefInstance.Toller.Items.Clear()
            DataShe1.DefInstance.Toller.Items.Add("AW")
            DataShe1.DefInstance.Toller.Items.Add("MW")
            DataShe1.DefInstance.Toller.SelectedIndex = DataSheet.DatiPrg.TubiInform.Toller
            DataShe1.DefInstance.TipoP.Image = System.Drawing.Image.FromFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\TIPOP" & LTrim(Str(DataSheet.DatiPrg.TubiInform.TipoP)) & ".BMP")
            '---------------------------------------------------------
            DataShe1.DefInstance.ComboM(5).Items.Clear()
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\GIUNTO.DAT", OpenMode.Input)
            For i = 1 To 8
110:            Riga = LineInput(ifl)
                DataShe1.DefInstance.ComboM(5).Items.Add(Riga)
            Next
            For i = 1 To 4
                Riga = LineInput(ifl)
                SaldMand.DefInstance.Option3D1(i - 1).Text = Riga
            Next
            FileClose(ifl)
            iTipo = DataSheet.DatiPrg.TubiInform.TipoG
            If iTipo Then
                DataShe1.DefInstance.ComboM(5).SelectedIndex = (iTipo \ 10)
                iTipo = iTipo Mod 10
                If iTipo Then
                    SaldMand.DefInstance.Option3D1(iTipo - 1).Checked = True
                End If
            End If
            '---------------------------------------------------------
            For i = 0 To 3
120:            DataSheet.DatiS1(i).FirstIndex = i * 7
                For j = i * 7 To i * 7 + 6
                    DataShe2.DefInstance.Mater(j).Text = DataSheet.DatiS1(i).MateInform(j - i * 7).Descr
                Next
            Next
            '---------------------------------------------------------
            DataSheet.DatiPrg.Lati = 2
            Hide()
            DataShee.DefInstance.Show()
            'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Denomin_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Denomin.TextChanged
        If Inizializzando Then Exit Sub
        DataSheet.DatiSh0.DenomItem = Denomin.Text
    End Sub
    Private Sub Denomin_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Denomin.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Distinta_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDistinta.Click
        Dim crea As Boolean
        If Not DataSheet.DatiSh0.Approved And Verboso Then
            If MostraAiuto(IDH_ERR_NODS, RoutBase1.ChiaviMess.MessQuestion + RoutBase1.ChiaviMess.MessYesNo) = RoutBase1.ChiaviMess.Messno Then Exit Sub 'aggiornamento
        End If
        OKpuoiIniziare = True
        Salva(OKpuoiIniziare) '13-5-99
        If Not OKpuoiIniziare Then '13-5-99
            Exit Sub
        End If
        Hide()
        job.Comm.CalcBaric = True
        ScriviPref()
        Funzioni.PPSM(Monitor.Motore.Inizio.DiscoRam, job, ProtoTyp, crea)
        If crea Then CreaPrototipo()
        Funzioni.GetDes(DataSheet)
        Show()
        LeggiPrefGen()
        mnuVerboso.Checked = Verboso
    End Sub
    Private Sub DomSalva()
        If Not ModifiedData Then Exit Sub
        If MsgBox("Vuoi salvare i dati introdotti ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "PPSM") = MsgBoxResult.Yes Then
            Call Salva(OKpuoiIniziare) '13-5-99
            ModifiedData = False
        End If
    End Sub
    Private Sub FillBoxes()
        Dim ifl As Short
        Dim File, TemaTyp As String
        If job.Comm.Ind.Count < 1 Then Exit Sub
        Cliente.Text = job.Comm.Clie
        Cliente.Text = job.Comm.Clie
        Oggetto.Text = job.Comm.Oggetto
        Progettista.Text = job.Comm.Comp
        If job.Comm.indice = 0 Then job.Comm.indice = 1
        Disegno.Text = job.Comm.Arch & job.Comm.Ind(job.Comm.indice).Data.File
        ListDisp.Tag = "A"
        If job.Comm.Asse = "H" Then ListDisp.SelectedIndex = 0 Else ListDisp.SelectedIndex = 1
        ListDisp.Tag = ""
        LabHV.Text = ListDisp.Items(ListDisp.SelectedIndex)
        LargM.Text = Str(job.Comm.LargM)
        LungM.Text = Str(job.Comm.LungM)
        File = Funzioni.FileDes("APR", job)
        If Len(File) = 0 Or InStr(File, "?") Then Exit Sub
        Esiste = System.IO.File.Exists(File)
        FillItem()
        Impianto.Text = DataSheet.DatiSh0.Impianto
        Denomin.Text = DataSheet.DatiSh0.DenomItem
        Numero.Text = LTrim(Str(job.Comm.Ind(job.Comm.indice).Data.Qta))
        TemaTyp = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
        If Asc(TemaTyp) < 32 Then TemaTyp = " "
        TEMA.Text = TemaTyp
    End Sub

    Private Sub FillComm()
        '     Dim File As String, ifl As Integer, i As Integer
        '     Commessa.Clear
        '     If Len(RTrim$(Lav(0).Prev)) = 0 Then Lav(0).Prev = "$"
        '     If Asc(Lav(0).Prev) < 32 Then Lav(0).Prev = "$"
        '     File = RTrim$(Monitor.Motore.Inizio.Workdir) + "\*.JOB"
        '     File = Dir$(File)
        '     While Len(File) > 0
        '        If Not RTrim$(Lav(0).Prev) = "$" Then
        'ifl = FreeFile
        'Open RTrim$(Inizio.Workdir) + "\" + File For Random As #ifl Len = Len(job)
        'If LOF(ifl) = 0 Then
        '   Close #ifl
        '   Kill RTrim$(Inizio.Workdir) + "\" + File
        '   File = Dir$
        'Else
        '   Close #ifl
        '            Commessa.AddItem Left$(File, 4)
        '   File = Dir$
        'End If
        '       Else
        '          Commessa.AddItem Left$(File, 4)
        '          File = Dir$
        '       End If
        '     Wend
        '     For i = 0 To Commessa.ListCount - 1
        '       If Commessa.List(i) = RTrim$(Lav(0).Prev) Then Commessa.ListIndex = i: Exit For
        '     Next

    End Sub
    Private Sub FillItem()
        Dim i As Short
        Dim Item As String
        Item = Trim(job.Comm.Ind(job.Comm.indice).Data.Assieme)
        If Len(Item) = 0 Then
            Item = "(senza nome)"
        Else
            mnuDistinta.Enabled = True
            mnuDataSheet.Enabled = True
            Call Funzioni.GetDes(DataSheet)
            Call AggiorFBM() 'Tipo FBM
            Call AggiorClasse() 'Classe FBM
        End If
        ' Text = Item & " - " & RTrim(job.Comm.Arch)
    End Sub
    Private Sub Inizializza()
        HelpProvider1.HelpNamespace = RadiceHelp
        ListDisp.Items.Clear()
        ListDisp.Items.Add("Orizz.")
        ListDisp.Items.Add("Vertic.")
        '--------------------------------
        Call AggiorListClasse()
        mnuVerboso.Checked = Verboso
        tbGrid = New DataTable("Lista")
        tbGrid.Columns.Add(New DataColumn("Col1", GetType(String)))
        tbGrid.Columns.Add(New DataColumn("Col2", GetType(String)))
        tbGrid.Columns.Add(New DataColumn("Col3", GetType(String)))
        dvGrid = New DataView(tbGrid)
        Grid1.TableStyles(0).MappingName = "Lista"
        Grid1.TableStyles(0).GridColumnStyles(0).MappingName = "Col1"
        Grid1.TableStyles(0).GridColumnStyles(1).MappingName = "Col2"
        Grid1.TableStyles(0).GridColumnStyles(2).MappingName = "Col3"
        Grid1.SetDataBinding(dvGrid, "")
        Color13 = System.Drawing.ColorTranslator.ToOle(Label13.BackColor)
        Call AggiorProto()
        Text = Text & " (Vers." & Monitor.Motore.About.ProgVers & ", " & Monitor.Motore.About.ProgDate & ")"
    End Sub
    Private Sub Grid1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Grid1.Click
        Dim Text1 As String
        ' If Grid1.Row = 0 Then Exit Sub
        ' Grid1.Col = 0
        Dim i As Short = Grid1.CurrentRowIndex
        Text1 = dvGrid(i)(0) & " ; "
        'Grid1.Col = 1
        Text1 = Text1 & dvGrid(i)(1)
        'Grid1.Col = 2
        FBMLabel.Text = Text1
        If IsDBNull(dvGrid(i)(2)) Then
            dvGrid(i).BeginEdit()
            dvGrid(i)(2) = "H"
            dvGrid(i).EndEdit()
        End If
        If dvGrid(i)(2) = "V" Then ListDisp.SelectedIndex = 1 Else ListDisp.SelectedIndex = 0
        LabHV.Text = ListDisp.SelectedItem
        Grid1.Visible = False
        DataSheet.DatiSh0.IndCodice = IndiceClasse.Items(i)
        ProtoTyp = Proto.Items(i)
        Funzioni.PutDes(job)
        AggiorProto()
        ModifProto = False
    End Sub
    Private Sub Impianto_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Impianto.TextChanged
        If Inizializzando Then Exit Sub
        DataSheet.DatiSh0.Impianto = Impianto.Text
    End Sub
    Private Sub Impianto_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Impianto.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub LargM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LargM.TextChanged
        If Inizializzando Then Exit Sub
        job.Comm.LargM = Val(LargM.Text)
    End Sub
    Private Sub LargM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles LargM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub ListDisp_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ListDisp.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        If ListDisp.SelectedIndex > -1 Then
            ModifiedData = ModifiedData Or (LabHV.Text <> ListDisp.Items(ListDisp.SelectedIndex))
            ModifProto = ModifProto Or (LabHV.Text <> ListDisp.Items(ListDisp.SelectedIndex))
            LabHV.Text = ListDisp.Items(ListDisp.SelectedIndex)
        End If
        ListDisp.Visible = False
        If ListDisp.SelectedIndex = 0 Then job.Comm.Asse = "H" Else job.Comm.Asse = "V"
        If ModifiedData Then AggiorFBM()
    End Sub
    Private Sub LungM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LungM.TextChanged
        If Inizializzando Then Exit Sub
        job.Comm.LungM = Val(LungM.Text)
    End Sub
    Private Sub LungM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles LungM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Public Sub mnuApri_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.Popup
        mnuApri_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuApri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.Click
        Dim jobn As RoutBase1.clsjob
        Dim No As Boolean
        OKpuoiIniziare = False '13-5-99
        DomSalva()
        jobn = Monitor.Motore.Sceglijob(job.Contratto, Contr)
        If Contr Is Nothing Then
            No = True
        ElseIf Contr.Length = 0 Then
            No = True
        Else
            No = Not jobn.Selezione
        End If
        If No Then
            mnuDistinta.Enabled = False
            mnuDataSheet.Enabled = False
            mnuGrezzi.Enabled = False
            mnuFormati.Enabled = False
            mnuCalcoli.Enabled = False
        Else
            mnuDistinta.Enabled = True
            mnuDataSheet.Enabled = True
            mnuGrezzi.Enabled = True
            mnuFormati.Enabled = True
            mnuCalcoli.Enabled = True
            mnuChiudi_Click(mnuChiudi, New System.EventArgs)
            job = jobn
            job.Comm.CalcBaric = True
            FillBoxes()
            Aggiorna()
            ModifiedData = False
            Esiste = False
        End If
    End Sub
    Public Sub mnuAree_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.Popup
        mnuAree_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuAree_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.Click
        If Not Monitor.Motore.Aree(True) Then
            mnuEsci_Click(mnuEsci, New System.EventArgs)
            objIFST.Out = False
        End If
    End Sub
    Public Sub mnuChiudi_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuChiudi.Popup
        mnuChiudi_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuChiudi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuChiudi.Click
        If job Is Nothing Then Exit Sub '13-5-99
        DomSalva()
        ListDisp.SelectedIndex = -1
        job.Comm.Arch = ""
        Aggiorna()
    End Sub
    Public Sub mnuEsci_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEsci.Popup
        mnuEsci_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEsci.Click
        ScriviPref()
        If ModifiedData Then
            If MsgBox("Vuoi salvare le modifiche effettuate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IST") = MsgBoxResult.Yes Then Salva(OKpuoiIniziare)
        End If
        rmHelpStrings.ReleaseAllResources()
        rmHelpTopics.ReleaseAllResources()
        mioApert = Nothing
        Me.Dispose()
        Funzioni = Nothing
        objIFST.Out = False
        Monitor.Motore.Ammazza("ISFT")
        Monitor = Nothing
    End Sub
    Public Sub mnuHelp_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelp.Popup
        mnuHelp_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub
    Public Sub mnuLavori_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLavori.Popup
        mnuLavori_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuLavori_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLavori.Click
        Monitor.Motore.SetLavoriSciolti()
    End Sub
    Public Sub mnuLibrMat_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLibrMat.Popup
        mnuLibrMat_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuLibrMat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLibrMat.Click
        Dim Mat As LibMat.MaterialeNew1
        Mat = New LibMat.MaterialeNew1
        Mat.Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
    End Sub
    Public Sub mnuSalva_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalva.Popup
        mnuSalva_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuSalva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalva.Click
        Salva(OKpuoiIniziare) '13-5-99
        ModifiedData = False '13-5-99
    End Sub
    Public Sub mnuVerboso_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVerboso.Popup
        mnuVerboso_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuVerboso_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVerboso.Click
        With mnuVerboso
            .Checked = Not .Checked
            Verboso = .Checked
        End With
    End Sub
    Private Sub Numero_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Numero.TextChanged
        If Inizializzando Then Exit Sub
        If job.Comm.indice = 0 Then Exit Sub
        job.Comm.Ind(job.Comm.indice).Data.Qta = Val(Numero.Text)
    End Sub
    Private Sub Numero_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Numero.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Function Preserva() As Boolean
        Preserva = False
        If Label13.BackColor.Equals(System.Drawing.Color.Yellow) Then Exit Function
        If Esiste Then
            Preserva = (MostraAiuto(IDH_AVV_PRESERVA, RoutBase1.ChiaviMess.MessYesNo + _
                        RoutBase1.ChiaviMess.MessQuestion) = RoutBase1.ChiaviMess.Messno)
        End If
    End Function
    Private Sub Oggetto_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Oggetto.TextChanged
        If Inizializzando Then Exit Sub
        job.Comm.Oggetto = Oggetto.Text
        ModifiedData = True
    End Sub
    Private Sub Progettista_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Progettista.TextChanged
        If Inizializzando Then Exit Sub
        job.Comm.Comp = Progettista.Text
        ModifiedData = True
    End Sub
    Private Sub Progettista_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Progettista.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        ModifiedData = True
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Aggiorna()
        Dim File, Testo, Testo1 As String
        Dim TemaTyp As String
        If Len(Trim(job.Comm.Arch)) > 0 Then
            If Asc(job.Comm.Arch) < 32 Then job.Comm.Arch = ""
        End If
        If Len(Trim(job.Comm.Arch)) > 0 Then
            File = RTrim(Monitor.Motore.Inizio.Workdir) & "\" & job.Comm.Arch & "\" & VB.Right(Disegno.Text, 3) & ".APR"
            Testo = "?"
            Testo1 = Trim(job.Comm.Ind(job.Comm.indice).Data.Assieme)
        Else
            File = "nessuno"
            Testo = "nessuno"
            Testo1 = "nessuno"
        End If
        StatusBar1.Panels(0).Text = "File di lavoro: " & File
        Testo1 = " Item = " & Testo1
        StatusBar1.Panels(1).Text = Testo1
        Cliente.Text = job.Comm.Clie '"" '13-5-99
        Oggetto.Text = job.Comm.Oggetto '13-5-99
        Denomin.Text = DataSheet.DatiSh0.DenomItem '13-5-99
        Impianto.Text = DataSheet.DatiSh0.Impianto '13-5-99
        If job.Comm.indice > 0 Then
            Disegno.Text = job.Comm.Arch & job.Comm.Ind(job.Comm.indice).Data.File '13-5-99
            Numero.Text = LTrim(Str(job.Comm.Ind(job.Comm.indice).Data.Qta))
        Else
            Disegno.Text = ""
            Numero.Text = "0"
        End If
        Progettista.Text = job.Comm.Comp ' "" '13-5-99
        LargM.Text = Str(job.Comm.LargM) '13-5-99
        LungM.Text = Str(job.Comm.LungM) '13-5-99
        TemaTyp = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
        If Asc(TemaTyp) < 32 Then TemaTyp = " "
        TEMA.Text = TemaTyp
    End Sub
    Sub AggiorListClasse()
        Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
        dbClassi = New OleDbConnection(cString)
        tbClassi = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Tipi", dbClassi)
        cmd.Fill(tbClassi)
        Dim dvClassi As DataView = New DataView(tbClassi)
        cmbClasse.Items.Clear()
        Dim j As Short
        For j = 0 To dvClassi.Count - 1
            cmbClasse.Items.Add(dvClassi(j)("Tipo"))
        Next
    End Sub
End Class