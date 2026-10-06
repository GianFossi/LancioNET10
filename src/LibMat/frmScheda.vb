Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports RoutBase1.clsInizio
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.common
Imports System.Windows.Forms
Friend Class frmScheda
    Inherits System.Windows.Forms.Form
    Private IsInitializing As Boolean
    Private vecchiomind As Integer
    Private GiaFatto As Boolean
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        IsInitializing = True
        InitializeComponent()
        Inizializza()
        IsInitializing = False
        HelpProvider1.HelpNamespace = RadiceHelp
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
    Public WithEvents _lstChart_0 As System.Windows.Forms.ListBox
    Public WithEvents _Text1_9 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_8 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents _cmbMWDTrule_0 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCurve_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Text2_0 As System.Windows.Forms.TextBox
    Public WithEvents _cmbGN_0 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbPN_0 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbChart_0 As System.Windows.Forms.ComboBox
    Public WithEvents _txtUS_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtSy_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtFonte_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblMWDTrule_0 As System.Windows.Forms.Label
    Public WithEvents _lblCurve_0 As System.Windows.Forms.Label
    Public WithEvents _lblImpactT_0 As System.Windows.Forms.Label
    Public WithEvents _lblGN_0 As System.Windows.Forms.Label
    Public WithEvents _lblPN_0 As System.Windows.Forms.Label
    Public WithEvents _lbl2psi_0 As System.Windows.Forms.Label
    Public WithEvents _lbl1psi_0 As System.Windows.Forms.Label
    Public WithEvents _lblLoaded_0 As System.Windows.Forms.Label
    Public WithEvents _lblChart_0 As System.Windows.Forms.Label
    Public WithEvents _lblUS_0 As System.Windows.Forms.Label
    Public WithEvents _lblSy_0 As System.Windows.Forms.Label
    Public WithEvents _lblFonte_0 As System.Windows.Forms.Label
    Public WithEvents _Picture1_0 As System.Windows.Forms.Panel
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents cmdHelp As System.Windows.Forms.Button
    Public WithEvents _Combo1_6 As System.Windows.Forms.ComboBox
    Public WithEvents _cmdLibr_3 As System.Windows.Forms.Button
    Public WithEvents _List1_6 As System.Windows.Forms.ListBox
    Public WithEvents _List1_5 As System.Windows.Forms.ListBox
    Public WithEvents _List1_4 As System.Windows.Forms.ListBox
    Public WithEvents _List1_3 As System.Windows.Forms.ListBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents _cmdLibr_2 As System.Windows.Forms.Button
    Public WithEvents _cmdLibr_1 As System.Windows.Forms.Button
    Public WithEvents _cmdLibr_0 As System.Windows.Forms.Button
    Public WithEvents Text3 As System.Windows.Forms.TextBox
    Public WithEvents Codici As System.Windows.Forms.ComboBox
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Combo1_5 As System.Windows.Forms.ComboBox
    Public WithEvents _Combo1_4 As System.Windows.Forms.ComboBox
    Public WithEvents _Combo1_3 As System.Windows.Forms.ComboBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Combo1_2 As System.Windows.Forms.ComboBox
    Public WithEvents _Combo1_1 As System.Windows.Forms.ComboBox
    Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Label1_17 As System.Windows.Forms.Label
    Public WithEvents _Label1_16 As System.Windows.Forms.Label
    Public WithEvents _Label1_15 As System.Windows.Forms.Label
    Public WithEvents _Label1_14 As System.Windows.Forms.Label
    Public WithEvents _Label1_13 As System.Windows.Forms.Label
    Public WithEvents _Label1_12 As System.Windows.Forms.Label
    Public WithEvents _Label1_11 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents _GridAm_0 As System.Windows.Forms.DataGrid
    Friend WithEvents _GridSy_0 As System.Windows.Forms.DataGrid
    Friend WithEvents _lblCreep_0 As System.Windows.Forms.Label
    Public WithEvents _txtCreep_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblF_0 As System.Windows.Forms.Label
    Friend WithEvents lCodici As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmScheda))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtCreep_0 = New System.Windows.Forms.TextBox
        Me._lblCreep_0 = New System.Windows.Forms.Label
        Me._lstChart_0 = New System.Windows.Forms.ListBox
        Me._Text1_9 = New System.Windows.Forms.TextBox
        Me._Text1_8 = New System.Windows.Forms.TextBox
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Picture1_0 = New System.Windows.Forms.Panel
        Me._lblF_0 = New System.Windows.Forms.Label
        Me._GridSy_0 = New System.Windows.Forms.DataGrid
        Me._GridAm_0 = New System.Windows.Forms.DataGrid
        Me._cmbMWDTrule_0 = New System.Windows.Forms.ComboBox
        Me._cmbCurve_0 = New System.Windows.Forms.ComboBox
        Me._Text2_0 = New System.Windows.Forms.TextBox
        Me._cmbGN_0 = New System.Windows.Forms.ComboBox
        Me._cmbPN_0 = New System.Windows.Forms.ComboBox
        Me._cmbChart_0 = New System.Windows.Forms.ComboBox
        Me._txtUS_0 = New System.Windows.Forms.TextBox
        Me._txtSy_0 = New System.Windows.Forms.TextBox
        Me._txtFonte_0 = New System.Windows.Forms.TextBox
        Me._lblMWDTrule_0 = New System.Windows.Forms.Label
        Me._lblCurve_0 = New System.Windows.Forms.Label
        Me._lblImpactT_0 = New System.Windows.Forms.Label
        Me._lblGN_0 = New System.Windows.Forms.Label
        Me._lblPN_0 = New System.Windows.Forms.Label
        Me._lbl2psi_0 = New System.Windows.Forms.Label
        Me._lbl1psi_0 = New System.Windows.Forms.Label
        Me._lblLoaded_0 = New System.Windows.Forms.Label
        Me._lblChart_0 = New System.Windows.Forms.Label
        Me._lblUS_0 = New System.Windows.Forms.Label
        Me._lblSy_0 = New System.Windows.Forms.Label
        Me._lblFonte_0 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.Command3 = New System.Windows.Forms.Button
        Me.cmdHelp = New System.Windows.Forms.Button
        Me._Combo1_6 = New System.Windows.Forms.ComboBox
        Me._cmdLibr_3 = New System.Windows.Forms.Button
        Me._List1_6 = New System.Windows.Forms.ListBox
        Me._List1_5 = New System.Windows.Forms.ListBox
        Me._List1_4 = New System.Windows.Forms.ListBox
        Me._List1_3 = New System.Windows.Forms.ListBox
        Me.Command2 = New System.Windows.Forms.Button
        Me._cmdLibr_2 = New System.Windows.Forms.Button
        Me._cmdLibr_1 = New System.Windows.Forms.Button
        Me._cmdLibr_0 = New System.Windows.Forms.Button
        Me.Text3 = New System.Windows.Forms.TextBox
        Me.Codici = New System.Windows.Forms.ComboBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._Combo1_5 = New System.Windows.Forms.ComboBox
        Me._Combo1_4 = New System.Windows.Forms.ComboBox
        Me._Combo1_3 = New System.Windows.Forms.ComboBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Combo1_2 = New System.Windows.Forms.ComboBox
        Me._Combo1_1 = New System.Windows.Forms.ComboBox
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me._Label1_17 = New System.Windows.Forms.Label
        Me._Label1_16 = New System.Windows.Forms.Label
        Me._Label1_15 = New System.Windows.Forms.Label
        Me._Label1_14 = New System.Windows.Forms.Label
        Me._Label1_13 = New System.Windows.Forms.Label
        Me._Label1_12 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lCodici = New System.Windows.Forms.ListBox
        Me._Picture1_0.SuspendLayout()
        CType(Me._GridSy_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridAm_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_txtCreep_0
        '
        Me._txtCreep_0.AcceptsReturn = True
        Me._txtCreep_0.AutoSize = False
        Me._txtCreep_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtCreep_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtCreep_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtCreep_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtCreep_0.Location = New System.Drawing.Point(72, 40)
        Me._txtCreep_0.MaxLength = 0
        Me._txtCreep_0.Name = "_txtCreep_0"
        Me._txtCreep_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtCreep_0.Size = New System.Drawing.Size(55, 19)
        Me._txtCreep_0.TabIndex = 120
        Me._txtCreep_0.TabStop = False
        Me._txtCreep_0.Text = "Text2"
        Me.ToolTip1.SetToolTip(Me._txtCreep_0, "Temperatura al di sotto della quale le proprietà del materiale non dipendono dal " & _
        "tempo")
        '
        '_lblCreep_0
        '
        Me._lblCreep_0.Location = New System.Drawing.Point(0, 40)
        Me._lblCreep_0.Name = "_lblCreep_0"
        Me._lblCreep_0.Size = New System.Drawing.Size(72, 19)
        Me._lblCreep_0.TabIndex = 119
        Me._lblCreep_0.Text = "Creep Range"
        Me.ToolTip1.SetToolTip(Me._lblCreep_0, "Temperatura al di sotto della quale le proprietà del materiale non dipendono dal " & _
        "tempo")
        '
        '_lstChart_0
        '
        Me._lstChart_0.BackColor = System.Drawing.SystemColors.Window
        Me._lstChart_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lstChart_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lstChart_0.Location = New System.Drawing.Point(200, 104)
        Me._lstChart_0.Name = "_lstChart_0"
        Me._lstChart_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lstChart_0.Size = New System.Drawing.Size(41, 17)
        Me._lstChart_0.TabIndex = 148
        Me._lstChart_0.Visible = False
        '
        '_Text1_9
        '
        Me._Text1_9.AcceptsReturn = True
        Me._Text1_9.AutoSize = False
        Me._Text1_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_9.Location = New System.Drawing.Point(432, 368)
        Me._Text1_9.MaxLength = 0
        Me._Text1_9.Name = "_Text1_9"
        Me._Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_9.Size = New System.Drawing.Size(121, 19)
        Me._Text1_9.TabIndex = 146
        Me._Text1_9.TabStop = False
        Me._Text1_9.Text = "Text1"
        '
        '_Text1_8
        '
        Me._Text1_8.AcceptsReturn = True
        Me._Text1_8.AutoSize = False
        Me._Text1_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_8.Location = New System.Drawing.Point(32, 392)
        Me._Text1_8.MaxLength = 0
        Me._Text1_8.Name = "_Text1_8"
        Me._Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_8.Size = New System.Drawing.Size(65, 19)
        Me._Text1_8.TabIndex = 142
        Me._Text1_8.TabStop = False
        Me._Text1_8.Text = "Text1"
        '
        '_Text1_7
        '
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.AutoSize = False
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_7.Location = New System.Drawing.Point(168, 392)
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Name = "_Text1_7"
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.Size = New System.Drawing.Size(73, 19)
        Me._Text1_7.TabIndex = 141
        Me._Text1_7.TabStop = False
        Me._Text1_7.Text = "Text1"
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_6.Location = New System.Drawing.Point(280, 392)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(73, 19)
        Me._Text1_6.TabIndex = 140
        Me._Text1_6.TabStop = False
        Me._Text1_6.Text = "Text1"
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(280, 368)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(73, 19)
        Me._Text1_5.TabIndex = 138
        Me._Text1_5.TabStop = False
        Me._Text1_5.Text = "Text1"
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(168, 368)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(73, 19)
        Me._Text1_4.TabIndex = 136
        Me._Text1_4.TabStop = False
        Me._Text1_4.Text = "Text1"
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_3.Location = New System.Drawing.Point(32, 368)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(65, 19)
        Me._Text1_3.TabIndex = 134
        Me._Text1_3.TabStop = False
        Me._Text1_3.Text = "Text1"
        '
        '_Picture1_0
        '
        Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_0.Controls.Add(Me._lblF_0)
        Me._Picture1_0.Controls.Add(Me._txtCreep_0)
        Me._Picture1_0.Controls.Add(Me._lblCreep_0)
        Me._Picture1_0.Controls.Add(Me._GridSy_0)
        Me._Picture1_0.Controls.Add(Me._GridAm_0)
        Me._Picture1_0.Controls.Add(Me._cmbMWDTrule_0)
        Me._Picture1_0.Controls.Add(Me._cmbCurve_0)
        Me._Picture1_0.Controls.Add(Me._Text2_0)
        Me._Picture1_0.Controls.Add(Me._cmbGN_0)
        Me._Picture1_0.Controls.Add(Me._cmbPN_0)
        Me._Picture1_0.Controls.Add(Me._cmbChart_0)
        Me._Picture1_0.Controls.Add(Me._txtUS_0)
        Me._Picture1_0.Controls.Add(Me._txtSy_0)
        Me._Picture1_0.Controls.Add(Me._txtFonte_0)
        Me._Picture1_0.Controls.Add(Me._lblMWDTrule_0)
        Me._Picture1_0.Controls.Add(Me._lblCurve_0)
        Me._Picture1_0.Controls.Add(Me._lblImpactT_0)
        Me._Picture1_0.Controls.Add(Me._lblGN_0)
        Me._Picture1_0.Controls.Add(Me._lblPN_0)
        Me._Picture1_0.Controls.Add(Me._lbl2psi_0)
        Me._Picture1_0.Controls.Add(Me._lbl1psi_0)
        Me._Picture1_0.Controls.Add(Me._lblLoaded_0)
        Me._Picture1_0.Controls.Add(Me._lblChart_0)
        Me._Picture1_0.Controls.Add(Me._lblUS_0)
        Me._Picture1_0.Controls.Add(Me._lblSy_0)
        Me._Picture1_0.Controls.Add(Me._lblFonte_0)
        Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Picture1_0.Location = New System.Drawing.Point(9, 126)
        Me._Picture1_0.Name = "_Picture1_0"
        Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_0.Size = New System.Drawing.Size(541, 234)
        Me._Picture1_0.TabIndex = 19
        Me._Picture1_0.TabStop = True
        '
        '_lblF_0
        '
        Me._lblF_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblF_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblF_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblF_0.Location = New System.Drawing.Point(128, 40)
        Me._lblF_0.Name = "_lblF_0"
        Me._lblF_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblF_0.Size = New System.Drawing.Size(24, 20)
        Me._lblF_0.TabIndex = 121
        Me._lblF_0.Text = "(°F)"
        '
        '_GridSy_0
        '
        Me._GridSy_0.DataMember = ""
        Me._GridSy_0.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me._GridSy_0.Location = New System.Drawing.Point(8, 152)
        Me._GridSy_0.Name = "_GridSy_0"
        Me._GridSy_0.Size = New System.Drawing.Size(528, 80)
        Me._GridSy_0.TabIndex = 118
        '
        '_GridAm_0
        '
        Me._GridAm_0.AllowSorting = False
        Me._GridAm_0.CaptionVisible = False
        Me._GridAm_0.ColumnHeadersVisible = False
        Me._GridAm_0.DataMember = ""
        Me._GridAm_0.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me._GridAm_0.Location = New System.Drawing.Point(8, 64)
        Me._GridAm_0.Name = "_GridAm_0"
        Me._GridAm_0.Size = New System.Drawing.Size(528, 88)
        Me._GridAm_0.TabIndex = 117
        '
        '_cmbMWDTrule_0
        '
        Me._cmbMWDTrule_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbMWDTrule_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbMWDTrule_0.DropDownWidth = 200
        Me._cmbMWDTrule_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbMWDTrule_0.Location = New System.Drawing.Point(412, 18)
        Me._cmbMWDTrule_0.Name = "_cmbMWDTrule_0"
        Me._cmbMWDTrule_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbMWDTrule_0.Size = New System.Drawing.Size(55, 21)
        Me._cmbMWDTrule_0.TabIndex = 113
        Me._cmbMWDTrule_0.TabStop = False
        Me._cmbMWDTrule_0.Text = "Combo2"
        '
        '_cmbCurve_0
        '
        Me._cmbCurve_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCurve_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCurve_0.DropDownWidth = 100
        Me._cmbCurve_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCurve_0.Location = New System.Drawing.Point(503, 18)
        Me._cmbCurve_0.Name = "_cmbCurve_0"
        Me._cmbCurve_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCurve_0.Size = New System.Drawing.Size(37, 21)
        Me._cmbCurve_0.TabIndex = 112
        Me._cmbCurve_0.TabStop = False
        Me._cmbCurve_0.Text = "Combo2"
        '
        '_Text2_0
        '
        Me._Text2_0.AcceptsReturn = True
        Me._Text2_0.AutoSize = False
        Me._Text2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_0.Location = New System.Drawing.Point(503, 0)
        Me._Text2_0.MaxLength = 0
        Me._Text2_0.Name = "_Text2_0"
        Me._Text2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_0.Size = New System.Drawing.Size(37, 19)
        Me._Text2_0.TabIndex = 111
        Me._Text2_0.TabStop = False
        Me._Text2_0.Text = "Text2"
        '
        '_cmbGN_0
        '
        Me._cmbGN_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbGN_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbGN_0.DropDownWidth = 200
        Me._cmbGN_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbGN_0, "IDH_LB_SCHEDA_PNUMBER")
        Me._cmbGN_0.Location = New System.Drawing.Point(304, 18)
        Me._cmbGN_0.Name = "_cmbGN_0"
        Me._cmbGN_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbGN_0, True)
        Me._cmbGN_0.Size = New System.Drawing.Size(55, 21)
        Me._cmbGN_0.TabIndex = 34
        Me._cmbGN_0.Text = "Combo3"
        '
        '_cmbPN_0
        '
        Me._cmbPN_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbPN_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbPN_0.DropDownWidth = 200
        Me._cmbPN_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbPN_0.Location = New System.Drawing.Point(205, 18)
        Me._cmbPN_0.Name = "_cmbPN_0"
        Me._cmbPN_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbPN_0.Size = New System.Drawing.Size(55, 21)
        Me._cmbPN_0.TabIndex = 32
        Me._cmbPN_0.TabStop = False
        Me._cmbPN_0.Text = "Combo2"
        '
        '_cmbChart_0
        '
        Me._cmbChart_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbChart_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbChart_0.DropDownWidth = 200
        Me._cmbChart_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._cmbChart_0, "IDH_LB_SCHEDA_CHART")
        Me._cmbChart_0.Location = New System.Drawing.Point(36, 18)
        Me._cmbChart_0.Name = "_cmbChart_0"
        Me._cmbChart_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmbChart_0, True)
        Me._cmbChart_0.Size = New System.Drawing.Size(68, 21)
        Me._cmbChart_0.TabIndex = 27
        Me._cmbChart_0.TabStop = False
        Me._cmbChart_0.Text = "Combo2"
        '
        '_txtUS_0
        '
        Me._txtUS_0.AcceptsReturn = True
        Me._txtUS_0.AutoSize = False
        Me._txtUS_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtUS_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtUS_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtUS_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtUS_0.Location = New System.Drawing.Point(368, 0)
        Me._txtUS_0.MaxLength = 0
        Me._txtUS_0.Name = "_txtUS_0"
        Me._txtUS_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtUS_0.Size = New System.Drawing.Size(55, 19)
        Me._txtUS_0.TabIndex = 25
        Me._txtUS_0.TabStop = False
        Me._txtUS_0.Text = "Text2"
        '
        '_txtSy_0
        '
        Me._txtSy_0.AcceptsReturn = True
        Me._txtSy_0.AutoSize = False
        Me._txtSy_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtSy_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtSy_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtSy_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtSy_0.Location = New System.Drawing.Point(241, 0)
        Me._txtSy_0.MaxLength = 0
        Me._txtSy_0.Name = "_txtSy_0"
        Me._txtSy_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtSy_0.Size = New System.Drawing.Size(55, 19)
        Me._txtSy_0.TabIndex = 23
        Me._txtSy_0.TabStop = False
        Me._txtSy_0.Text = "Text2"
        '
        '_txtFonte_0
        '
        Me._txtFonte_0.AcceptsReturn = True
        Me._txtFonte_0.AutoSize = False
        Me._txtFonte_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFonte_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFonte_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFonte_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFonte_0.Location = New System.Drawing.Point(48, 0)
        Me._txtFonte_0.MaxLength = 0
        Me._txtFonte_0.Name = "_txtFonte_0"
        Me._txtFonte_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFonte_0.Size = New System.Drawing.Size(120, 19)
        Me._txtFonte_0.TabIndex = 21
        Me._txtFonte_0.TabStop = False
        Me._txtFonte_0.Text = "Textà"
        '
        '_lblMWDTrule_0
        '
        Me._lblMWDTrule_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblMWDTrule_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMWDTrule_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMWDTrule_0.Location = New System.Drawing.Point(359, 19)
        Me._lblMWDTrule_0.Name = "_lblMWDTrule_0"
        Me._lblMWDTrule_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMWDTrule_0.Size = New System.Drawing.Size(65, 20)
        Me._lblMWDTrule_0.TabIndex = 116
        Me._lblMWDTrule_0.Text = "MWDTrule"
        '
        '_lblCurve_0
        '
        Me._lblCurve_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblCurve_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCurve_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCurve_0.Location = New System.Drawing.Point(467, 19)
        Me._lblCurve_0.Name = "_lblCurve_0"
        Me._lblCurve_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCurve_0.Size = New System.Drawing.Size(37, 20)
        Me._lblCurve_0.TabIndex = 115
        Me._lblCurve_0.Text = "Curve"
        '
        '_lblImpactT_0
        '
        Me._lblImpactT_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblImpactT_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblImpactT_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblImpactT_0.Location = New System.Drawing.Point(448, 0)
        Me._lblImpactT_0.Name = "_lblImpactT_0"
        Me._lblImpactT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblImpactT_0.Size = New System.Drawing.Size(64, 20)
        Me._lblImpactT_0.TabIndex = 114
        Me._lblImpactT_0.Text = "Impact T°F"
        '
        '_lblGN_0
        '
        Me._lblGN_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblGN_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblGN_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblGN_0.Location = New System.Drawing.Point(260, 19)
        Me._lblGN_0.Name = "_lblGN_0"
        Me._lblGN_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblGN_0.Size = New System.Drawing.Size(47, 20)
        Me._lblGN_0.TabIndex = 33
        Me._lblGN_0.Text = " GroupN"
        '
        '_lblPN_0
        '
        Me._lblPN_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblPN_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPN_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPN_0.Location = New System.Drawing.Point(152, 19)
        Me._lblPN_0.Name = "_lblPN_0"
        Me._lblPN_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPN_0.Size = New System.Drawing.Size(56, 20)
        Me._lblPN_0.TabIndex = 31
        Me._lblPN_0.Text = " PNumber"
        '
        '_lbl2psi_0
        '
        Me._lbl2psi_0.BackColor = System.Drawing.SystemColors.Control
        Me._lbl2psi_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl2psi_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl2psi_0.Location = New System.Drawing.Point(421, 0)
        Me._lbl2psi_0.Name = "_lbl2psi_0"
        Me._lbl2psi_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl2psi_0.Size = New System.Drawing.Size(35, 20)
        Me._lbl2psi_0.TabIndex = 30
        Me._lbl2psi_0.Text = " (psi)"
        '
        '_lbl1psi_0
        '
        Me._lbl1psi_0.BackColor = System.Drawing.SystemColors.Control
        Me._lbl1psi_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1psi_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl1psi_0.Location = New System.Drawing.Point(292, 0)
        Me._lbl1psi_0.Name = "_lbl1psi_0"
        Me._lbl1psi_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1psi_0.Size = New System.Drawing.Size(32, 20)
        Me._lbl1psi_0.TabIndex = 29
        Me._lbl1psi_0.Text = " (psi)"
        '
        '_lblLoaded_0
        '
        Me._lblLoaded_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLoaded_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLoaded_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLoaded_0.Location = New System.Drawing.Point(104, 18)
        Me._lblLoaded_0.Name = "_lblLoaded_0"
        Me._lblLoaded_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLoaded_0.Size = New System.Drawing.Size(54, 19)
        Me._lblLoaded_0.TabIndex = 28
        Me._lblLoaded_0.Text = "loaded"
        '
        '_lblChart_0
        '
        Me._lblChart_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblChart_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblChart_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblChart_0.Location = New System.Drawing.Point(0, 18)
        Me._lblChart_0.Name = "_lblChart_0"
        Me._lblChart_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblChart_0.Size = New System.Drawing.Size(37, 19)
        Me._lblChart_0.TabIndex = 26
        Me._lblChart_0.Text = " Chart"
        '
        '_lblUS_0
        '
        Me._lblUS_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblUS_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUS_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUS_0.Location = New System.Drawing.Point(320, 0)
        Me._lblUS_0.Name = "_lblUS_0"
        Me._lblUS_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUS_0.Size = New System.Drawing.Size(48, 20)
        Me._lblUS_0.TabIndex = 24
        Me._lblUS_0.Text = " Rottura"
        '
        '_lblSy_0
        '
        Me._lblSy_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblSy_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSy_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSy_0.Location = New System.Drawing.Point(169, 0)
        Me._lblSy_0.Name = "_lblSy_0"
        Me._lblSy_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSy_0.Size = New System.Drawing.Size(75, 20)
        Me._lblSy_0.TabIndex = 22
        Me._lblSy_0.Text = " Snervamento"
        '
        '_lblFonte_0
        '
        Me._lblFonte_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblFonte_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblFonte_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblFonte_0.Location = New System.Drawing.Point(0, 0)
        Me._lblFonte_0.Name = "_lblFonte_0"
        Me._lblFonte_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblFonte_0.Size = New System.Drawing.Size(47, 19)
        Me._lblFonte_0.TabIndex = 20
        Me._lblFonte_0.Text = " Fonte"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(384, 72)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Multiline = True
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(97, 19)
        Me._Text1_0.TabIndex = 133
        Me._Text1_0.TabStop = False
        Me._Text1_0.Text = "Text1"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(488, 72)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(73, 17)
        Me.Command3.TabIndex = 131
        Me.Command3.TabStop = False
        Me.Command3.Text = "Note"
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(424, 392)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(64, 19)
        Me.cmdHelp.TabIndex = 130
        Me.cmdHelp.TabStop = False
        Me.cmdHelp.Text = "Help"
        '
        '_Combo1_6
        '
        Me._Combo1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_6.Location = New System.Drawing.Point(112, 72)
        Me._Combo1_6.Name = "_Combo1_6"
        Me._Combo1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_6.Size = New System.Drawing.Size(169, 21)
        Me._Combo1_6.TabIndex = 128
        Me._Combo1_6.TabStop = False
        '
        '_cmdLibr_3
        '
        Me._cmdLibr_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdLibr_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdLibr_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdLibr_3.Image = CType(resources.GetObject("_cmdLibr_3.Image"), System.Drawing.Image)
        Me._cmdLibr_3.Location = New System.Drawing.Point(280, 72)
        Me._cmdLibr_3.Name = "_cmdLibr_3"
        Me._cmdLibr_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdLibr_3.Size = New System.Drawing.Size(17, 19)
        Me._cmdLibr_3.TabIndex = 127
        Me._cmdLibr_3.TabStop = False
        Me._cmdLibr_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_List1_6
        '
        Me._List1_6.BackColor = System.Drawing.SystemColors.Window
        Me._List1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._List1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List1_6.Location = New System.Drawing.Point(136, 80)
        Me._List1_6.Name = "_List1_6"
        Me._List1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List1_6.Size = New System.Drawing.Size(41, 17)
        Me._List1_6.TabIndex = 126
        Me._List1_6.Visible = False
        '
        '_List1_5
        '
        Me._List1_5.BackColor = System.Drawing.SystemColors.Window
        Me._List1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._List1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List1_5.Location = New System.Drawing.Point(136, 56)
        Me._List1_5.Name = "_List1_5"
        Me._List1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List1_5.Size = New System.Drawing.Size(41, 17)
        Me._List1_5.TabIndex = 125
        Me._List1_5.Visible = False
        '
        '_List1_4
        '
        Me._List1_4.BackColor = System.Drawing.SystemColors.Window
        Me._List1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._List1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List1_4.Location = New System.Drawing.Point(400, 32)
        Me._List1_4.Name = "_List1_4"
        Me._List1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List1_4.Size = New System.Drawing.Size(41, 17)
        Me._List1_4.TabIndex = 124
        Me._List1_4.Visible = False
        '
        '_List1_3
        '
        Me._List1_3.BackColor = System.Drawing.SystemColors.Window
        Me._List1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._List1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._List1_3.Location = New System.Drawing.Point(136, 32)
        Me._List1_3.Name = "_List1_3"
        Me._List1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._List1_3.Size = New System.Drawing.Size(41, 17)
        Me._List1_3.TabIndex = 123
        Me._List1_3.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Image = CType(resources.GetObject("Command2.Image"), System.Drawing.Image)
        Me.Command2.Location = New System.Drawing.Point(147, 147)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(20, 19)
        Me.Command2.TabIndex = 118
        Me.Command2.TabStop = False
        Me.Command2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdLibr_2
        '
        Me._cmdLibr_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdLibr_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdLibr_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdLibr_2.Image = CType(resources.GetObject("_cmdLibr_2.Image"), System.Drawing.Image)
        Me._cmdLibr_2.Location = New System.Drawing.Point(560, 24)
        Me._cmdLibr_2.Name = "_cmdLibr_2"
        Me._cmdLibr_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdLibr_2.Size = New System.Drawing.Size(17, 19)
        Me._cmdLibr_2.TabIndex = 122
        Me._cmdLibr_2.TabStop = False
        Me._cmdLibr_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdLibr_1
        '
        Me._cmdLibr_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdLibr_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdLibr_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdLibr_1.Image = CType(resources.GetObject("_cmdLibr_1.Image"), System.Drawing.Image)
        Me._cmdLibr_1.Location = New System.Drawing.Point(280, 48)
        Me._cmdLibr_1.Name = "_cmdLibr_1"
        Me._cmdLibr_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdLibr_1.Size = New System.Drawing.Size(17, 19)
        Me._cmdLibr_1.TabIndex = 121
        Me._cmdLibr_1.TabStop = False
        Me._cmdLibr_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdLibr_0
        '
        Me._cmdLibr_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdLibr_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdLibr_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdLibr_0.Image = CType(resources.GetObject("_cmdLibr_0.Image"), System.Drawing.Image)
        Me._cmdLibr_0.Location = New System.Drawing.Point(280, 24)
        Me._cmdLibr_0.Name = "_cmdLibr_0"
        Me._cmdLibr_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdLibr_0.Size = New System.Drawing.Size(17, 19)
        Me._cmdLibr_0.TabIndex = 120
        Me._cmdLibr_0.TabStop = False
        Me._cmdLibr_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.AutoSize = False
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(472, 720)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(49, 20)
        Me.Text3.TabIndex = 119
        Me.Text3.Text = "Text3"
        '
        'Codici
        '
        Me.Codici.BackColor = System.Drawing.SystemColors.Window
        Me.Codici.Cursor = System.Windows.Forms.Cursors.Default
        Me.Codici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Codici.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Codici.Location = New System.Drawing.Point(304, 72)
        Me.Codici.Name = "Codici"
        Me.Codici.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Codici.Size = New System.Drawing.Size(109, 21)
        Me.Codici.TabIndex = 117
        Me.Codici.TabStop = False
        Me.Codici.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(496, 392)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(64, 19)
        Me.cmdOK.TabIndex = 37
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(96, 0)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(464, 19)
        Me._Text1_2.TabIndex = 18
        Me._Text1_2.TabStop = False
        Me._Text1_2.Text = "Text1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(488, 48)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(73, 17)
        Me.Command1.TabIndex = 16
        Me.Command1.TabStop = False
        Me.Command1.Text = "Prezzi"
        '
        '_Combo1_5
        '
        Me._Combo1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_5.DropDownWidth = 240
        Me._Combo1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_5.Location = New System.Drawing.Point(112, 48)
        Me._Combo1_5.Name = "_Combo1_5"
        Me._Combo1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_5.Size = New System.Drawing.Size(169, 21)
        Me._Combo1_5.TabIndex = 15
        Me._Combo1_5.TabStop = False
        '
        '_Combo1_4
        '
        Me._Combo1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_4.Location = New System.Drawing.Point(384, 24)
        Me._Combo1_4.Name = "_Combo1_4"
        Me._Combo1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_4.Size = New System.Drawing.Size(177, 21)
        Me._Combo1_4.TabIndex = 13
        Me._Combo1_4.TabStop = False
        '
        '_Combo1_3
        '
        Me._Combo1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_3.Location = New System.Drawing.Point(80, 24)
        Me._Combo1_3.Name = "_Combo1_3"
        Me._Combo1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_3.Size = New System.Drawing.Size(201, 21)
        Me._Combo1_3.TabIndex = 11
        Me._Combo1_3.TabStop = False
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(384, 48)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Multiline = True
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(49, 19)
        Me._Text1_1.TabIndex = 9
        Me._Text1_1.TabStop = False
        Me._Text1_1.Text = "Text1"
        Me._Text1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Combo1_2
        '
        Me._Combo1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_2.Location = New System.Drawing.Point(512, 0)
        Me._Combo1_2.Name = "_Combo1_2"
        Me._Combo1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_2.Size = New System.Drawing.Size(49, 21)
        Me._Combo1_2.TabIndex = 8
        Me._Combo1_2.TabStop = False
        Me._Combo1_2.Text = "Combo1"
        Me._Combo1_2.Visible = False
        '
        '_Combo1_1
        '
        Me._Combo1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_1.Location = New System.Drawing.Point(384, 0)
        Me._Combo1_1.Name = "_Combo1_1"
        Me._Combo1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_1.Size = New System.Drawing.Size(49, 21)
        Me._Combo1_1.TabIndex = 7
        Me._Combo1_1.TabStop = False
        Me._Combo1_1.Text = "Combo1"
        Me._Combo1_1.Visible = False
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_0.Location = New System.Drawing.Point(234, 0)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(49, 21)
        Me._Combo1_0.TabIndex = 6
        Me._Combo1_0.TabStop = False
        Me._Combo1_0.Text = "Combo1"
        Me._Combo1_0.Visible = False
        '
        '_Label1_17
        '
        Me._Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_17.Location = New System.Drawing.Point(368, 368)
        Me._Label1_17.Name = "_Label1_17"
        Me._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_17.Size = New System.Drawing.Size(65, 17)
        Me._Label1_17.TabIndex = 147
        Me._Label1_17.Text = "Dimensions"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_16.Location = New System.Drawing.Point(0, 392)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(33, 17)
        Me._Label1_16.TabIndex = 145
        Me._Label1_16.Text = "Spec"
        '
        '_Label1_15
        '
        Me._Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_15.Location = New System.Drawing.Point(104, 392)
        Me._Label1_15.Name = "_Label1_15"
        Me._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_15.Size = New System.Drawing.Size(65, 17)
        Me._Label1_15.TabIndex = 144
        Me._Label1_15.Text = "Grade"
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_14.Location = New System.Drawing.Point(248, 392)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(33, 17)
        Me._Label1_14.TabIndex = 143
        Me._Label1_14.Text = "Class"
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_13.Location = New System.Drawing.Point(248, 368)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(33, 17)
        Me._Label1_13.TabIndex = 139
        Me._Label1_13.Text = "Form"
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_12.Location = New System.Drawing.Point(104, 368)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(72, 17)
        Me._Label1_12.TabIndex = 137
        Me._Label1_12.Text = "Composition"
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(0, 368)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(33, 17)
        Me._Label1_11.TabIndex = 135
        Me._Label1_11.Text = "UNS"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(304, 72)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(73, 17)
        Me._Label1_10.TabIndex = 132
        Me._Label1_10.Text = "Denom. comm."
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(0, 72)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(105, 17)
        Me._Label1_9.TabIndex = 129
        Me._Label1_9.Text = " Conducibilità termica"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(0, 48)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(105, 17)
        Me._Label1_8.TabIndex = 14
        Me._Label1_8.Text = " Gruppo mat. B16.5"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(304, 24)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(73, 17)
        Me._Label1_7.TabIndex = 12
        Me._Label1_7.Text = " Dil. termica"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(0, 24)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(73, 17)
        Me._Label1_6.TabIndex = 10
        Me._Label1_6.Text = " Mod.elastico"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(440, 48)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(41, 17)
        Me._Label1_5.TabIndex = 5
        Me._Label1_5.Text = " Kg/m3"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(304, 48)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(73, 17)
        Me._Label1_4.TabIndex = 4
        Me._Label1_4.Text = " Peso specif."
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(432, 0)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(88, 17)
        Me._Label1_3.TabIndex = 3
        Me._Label1_3.Text = " Cod. materiale"
        Me._Label1_3.Visible = False
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(304, 0)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(81, 17)
        Me._Label1_2.TabIndex = 2
        Me._Label1_2.Text = " Codice tecnico"
        Me._Label1_2.Visible = False
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(176, 0)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(57, 17)
        Me._Label1_1.TabIndex = 1
        Me._Label1_1.Text = " Categoria"
        Me._Label1_1.Visible = False
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(0, 0)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(88, 17)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = " Denominazione"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(8, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(544, 272)
        Me.TabControl1.TabIndex = 152
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(536, 246)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'lCodici
        '
        Me.lCodici.Location = New System.Drawing.Point(288, 0)
        Me.lCodici.Name = "lCodici"
        Me.lCodici.Size = New System.Drawing.Size(16, 17)
        Me.lCodici.TabIndex = 153
        Me.lCodici.Visible = False
        '
        'frmScheda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(579, 416)
        Me.Controls.Add(Me.lCodici)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me._Text1_9)
        Me.Controls.Add(Me._Text1_8)
        Me.Controls.Add(Me._Text1_7)
        Me.Controls.Add(Me._Text1_6)
        Me.Controls.Add(Me._Text1_5)
        Me.Controls.Add(Me._Text1_4)
        Me.Controls.Add(Me._Text1_3)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me._lstChart_0)
        Me.Controls.Add(Me._Picture1_0)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me._Combo1_6)
        Me.Controls.Add(Me._cmdLibr_3)
        Me.Controls.Add(Me._List1_6)
        Me.Controls.Add(Me._List1_5)
        Me.Controls.Add(Me._List1_4)
        Me.Controls.Add(Me._List1_3)
        Me.Controls.Add(Me._cmdLibr_2)
        Me.Controls.Add(Me._cmdLibr_1)
        Me.Controls.Add(Me._cmdLibr_0)
        Me.Controls.Add(Me.Codici)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Combo1_5)
        Me.Controls.Add(Me._Combo1_4)
        Me.Controls.Add(Me._Combo1_3)
        Me.Controls.Add(Me._Combo1_2)
        Me.Controls.Add(Me._Combo1_1)
        Me.Controls.Add(Me._Combo1_0)
        Me.Controls.Add(Me._Label1_17)
        Me.Controls.Add(Me._Label1_16)
        Me.Controls.Add(Me._Label1_15)
        Me.Controls.Add(Me._Label1_14)
        Me.Controls.Add(Me._Label1_13)
        Me.Controls.Add(Me._Label1_12)
        Me.Controls.Add(Me._Label1_11)
        Me.Controls.Add(Me._Label1_10)
        Me.Controls.Add(Me._Label1_9)
        Me.Controls.Add(Me._Label1_8)
        Me.Controls.Add(Me._Label1_7)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me.TabControl1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(202, 65)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScheda"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Scheda materiale"
        Me._Picture1_0.ResumeLayout(False)
        CType(Me._GridSy_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridAm_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Public consult As Boolean
    Private m As LibMat.MaterialeNew1
    Private cambiocodice As Boolean
    Private indice As Short
    Private bGridAm As Boolean
    Private PrimoSet, InsertMode As Short
    Private Codice() As String
    Private CodiceCalc As Codes
    Private IndCaract As Integer
    Private dvGridAm, dvGridSy As DataView
    Private dtGridAm, dtGridSy As DataTable
    Private Function Text1(ByVal Index As Short) As TextBox
        Select Case Index
            Case 0 : Return _Text1_0
            Case 1 : Return _Text1_1
            Case 2 : Return _Text1_2
            Case 3 : Return _Text1_3
            Case 4 : Return _Text1_4
            Case 5 : Return _Text1_5
            Case 6 : Return _Text1_6
            Case 7 : Return _Text1_7
            Case 8 : Return _Text1_8
            Case 9 : Return _Text1_9
            Case Else : Return Nothing
        End Select
    End Function
    Private Function cmdLibr(ByVal Index As Short) As Button
        Select Case Index
            Case 0 : Return _cmdLibr_0
            Case 1 : Return _cmdLibr_1
            Case 2 : Return _cmdLibr_2
            Case 3 : Return _cmdLibr_3
            Case Else : Return Nothing
        End Select
    End Function
    Friend Function List1(ByVal Index As Short) As ListBox
        Select Case Index
            Case 3 : Return _List1_3
            Case 4 : Return _List1_4
            Case 5 : Return _List1_5
            Case 6 : Return _List1_6
            Case Else : Return Nothing
        End Select
    End Function
    Friend Function Combo1(ByVal Index As Short) As ComboBox
        Select Case Index
            Case 0 : Return _Combo1_0
            Case 1 : Return _Combo1_1
            Case 2 : Return _Combo1_2
            Case 3 : Return _Combo1_3
            Case 4 : Return _Combo1_4
            Case 5 : Return _Combo1_5
            Case 6 : Return _Combo1_6
            Case Else : Return Nothing
        End Select
    End Function
    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, Monitor.Motore.HelptopicG(IDHS.IDH_CAP_BD_MAT_SCHEDA))
    End Sub
    Private Sub cmdLibr_Click(ByVal Index As Short)
        Dim Table As New DataTable
        Dim Dummy As DataTable
        'Dim TableN As DataTable
        Dim cmd As OleDbDataAdapter
        Dim m As LibMat.MaterialeNew1
        Dim ic, n, i, ii As Short
        Dim File As String
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If Not IniziaBase() Then Exit Sub
        Dim FormDati As New frmDati
        FormDati.IndiceTab = Index
        FormDati.consult = consult
        Try
            Select Case Index
                Case 0 : FormDati.IndiceRig = m.ElasCod 'modelas
                    ic = 3
                Case 3 : FormDati.IndiceRig = m.ConducTer 'modelas
                    ic = 6
                Case 1 ''''frmDati.IndiceRig = m.MatGroup 'gruppo materiale
                    ic = 5
                    If m.MatGroup > 0 Then
                        cmd = New OleDbDataAdapter("SELECT * FROM Groupmt", MatBase)
                        Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
                        cmd.Fill(Table)
                        Dim dvTable As DataView = New DataView(Table)
                        dvTable.Sort = "ID"
                        Dim iFound As Integer = dvTable.Find(m.MatGroup)
                        If CStr(dvTable(iFound)("Tabella")) = "-1" Then
                            File = CStr(dvTable(iFound)("Nome"))
                            n = CShort(File.IndexOf("(") + 1)
                            File = File.Substring(0, n - 1)
                            n = CShort(File.IndexOf(".") + 1)
                            File = "PR" & File.Substring(0, n - 1) & "P" & File.Substring(n, File.Length - n)
                            File = File.Trim
                            'Dim CreateStatement As String = "CREATE TABLE " & File '& " AS (SELECT * FROM PR1P0)"
                            'Dim CreateCommand As New OleDbCommand(CreateStatement, MatBase)
                            Dim copiedColumnCount As Integer = Lancio.Data.Access.AccessDatabase.CloneMaterialSchema(MatBase, "PR1P0", File)
                            Dim tPR1P0 As New DataTable
                            Dim cmdN As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM PR1P0", MatBase)
                            cmdN.Fill(tPR1P0)
                            cmdN = New OleDbDataAdapter("SELECT * FROM " & File, MatBase)
                            Dim custCBN As OleDbCommandBuilder = New OleDbCommandBuilder(cmdN)
                            Dim tFile As New DataTable
                            cmdN.Fill(tFile)
                            Dim dvTableN As DataView = New DataView(tFile)
                            Dim drv As DataRowView = dvTableN.AddNew()
                            For i = 1 To CShort(copiedColumnCount - 1)
                                drv(i) = tPR1P0.Rows(0)(i)
                            Next
                            drv.EndEdit()
                            Dim cmdM As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM PR1P1", MatBase)
                            Dummy = New DataTable
                            cmdM.Fill(Dummy)
                            For ii = 0 To CShort(Dummy.Rows.Count - 1)
                                drv = dvTableN.AddNew()
                                drv(1) = Dummy.Rows(ii)(1)
                                For i = 2 To 8 : drv(i) = 0 : Next
                                drv.EndEdit()
                            Next ii
                            Dim numRighe As Integer = cmdN.Update(tFile)
                            drv = dvTable(iFound)
                            drv.BeginEdit()
                            drv("Tabella") = File
                            drv.EndEdit()
                            cmd.Update(Table)
                        End If
                        FormDati.NomeTabella = CStr(dvTable(iFound)("Nome"))
                        FormDati.File = CStr(dvTable(iFound)("Tabella"))
                        Table.Dispose()
                    Else
                        Funzioni.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
                        Exit Sub
                    End If
                Case 2 : FormDati.IndiceRig = m.alfacod 'alfater
                    ic = 4
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        FormDati.ShowDialog()
        If Not consult And ic <> 5 Then
            Librer(ic)
            If m.Agganciato Then
                For i = 0 To CShort(List1(ic).Items.Count - 1)
                    If CShort(List1(ic).Items(i)) = FormDati.IndiceRig Then
                        Combo1(ic).SelectedIndex = i '''''frmDati.IndiceRig
                        Exit For
                    End If
                Next
            Else
                Combo1(ic).SelectedIndex = 0
            End If
        End If
        FormDati.Close()
        FormDati.Dispose()
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim m As LibMat.MaterialeNew1
        Dim Mat As clsMat
        Cursor.Current = Cursors.WaitCursor
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If Not consult Then
            m.MatStr = Text1(2).Text
            m.AlloyUNS = Text1(3).Text
            m.Composiz = Text1(4).Text
            m.Product = Text1(5).Text
            m.Spec = Text1(8).Text
            m.Grado = Text1(7).Text
            m.ClassTemper = Text1(6).Text
            m.Dimensions = Text1(9).Text
            m.NomeComm = Text1(0).Text
            m.CAT = Combo1(0).Text
            m.CT = Combo1(1).Text
            m.CMT = Combo1(2).Text
            m.PSP = CShort(Funzioni.ValVir(Text1(1).Text))
            SalvaGriglie()
            If m.Agganciato Then
                Mat = FormMat.Item(FormMat.Count()).TextData
                PutMat((Mat.IndiceLista))
            End If
        End If
        Cursor.Current = Cursors.Default
        Me.Close()
    End Sub
    Private Sub Codici_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Codici.SelectedIndexChanged
        If IsInitializing Then Exit Sub
        Dim Index As Integer
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        lCodici.SelectedIndex = Codici.SelectedIndex
        Index = TabControl1.SelectedIndex
        IndCaract = Index + 1
        If IndCaract > m.Caract.Count Then
            Dim c As New CarattMatNew
            m.Caract.Add(c)
        End If
        m.Caract.Item(IndCaract).TextData.Codice = CType(lCodici.SelectedItem, Codes)
        Codici.Visible = False
        TabControl1.TabPages(Index).Text = Codice(CInt(lCodici.SelectedItem))
        AggChart(CShort(Index + 1))
        TabControl1_SelectedIndexChanged(Me, New System.EventArgs)
    End Sub
    Private Sub Codici_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Codici.Leave
        Codici.Visible = False
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal Index As Short)
        If IsInitializing Then Exit Sub
        Dim Table As New DataTable
        Dim i As Short
        Dim m As LibMat.MaterialeNew1
        Dim cmd As OleDbDataAdapter
        Dim iFound As Integer
        m = MatElem()
        If m Is Nothing Then Exit Sub
        Select Case Index
            Case 3 : cmd = New OleDbDataAdapter("SELECT * FROM Modelas", MatBase)
            Case 4 : cmd = New OleDbDataAdapter("SELECT * FROM Alfater", MatBase)
            Case 5 : cmd = New OleDbDataAdapter("SELECT * FROM Groupmt", MatBase)
            Case 6 : cmd = New OleDbDataAdapter("SELECT * FROM ConducTer", MatBase)
            Case Else : Exit Sub
        End Select
        cmd.Fill(Table)
        Dim dvTable As DataView = New DataView(Table)
        dvTable.Sort = "ID"
        If Combo1(Index).SelectedIndex > 0 Then
            If Not Index = 5 Then
                List1(Index).SelectedIndex = Combo1(Index).SelectedIndex
                'Table.Index = "PrimaryKey"
                iFound = dvTable.Find(CInt(List1(Index).Text))
                If iFound > -1 Then i = CShort(dvTable(iFound)("ID")) Else i = 0
            Else
                i = CShort(Table.Rows(Combo1(Index).SelectedIndex)("ID"))
            End If
        Else
            i = 0
        End If
        Select Case Index
            Case 3 : m.ElasCod = i
            Case 4 : m.alfacod = i
            Case 5 : m.MatGroup = i
            Case 6 : m.ConducTer = i
        End Select
        Table.Dispose()
    End Sub
    Private Sub AggiornaGriglie(ByVal k As Short)
        Dim r As Rectangle
        Dim ts As DataGridTableStyle
        Dim kk As Short
        IndCaract = k
        _GridAm_0.Enabled = False
        _GridSy_0.Enabled = False
        RiempiValori(k, True)
        With _GridAm_0
            .ColumnHeadersVisible = False
            .CaptionVisible = False
            .SetDataBinding(dvGridAm, "")
        End With
        With _GridSy_0
            .ColumnHeadersVisible = False
            .CaptionVisible = False
            .SetDataBinding(dvGridSy, "")
        End With
        Try
            Dim cs As DataGridTextBoxColumn
            ts = New DataGridTableStyle
            For kk = 0 To 11
                cs = New DataGridTextBoxColumn
                With cs
                    .Width = 39
                    .Alignment = HorizontalAlignment.Right
                    .MappingName = "dato" & kk.ToString
                End With
                ts.GridColumnStyles.Add(cs)
            Next
            _GridAm_0.TableStyles.Add(ts)
            With _GridAm_0.TableStyles(0)
                .PreferredRowHeight = 19
                .PreferredColumnWidth = 39
                .RowHeaderWidth = 50
                .RowHeadersVisible = True
                .ColumnHeadersVisible = False
                .HeaderBackColor = Color.Yellow
                .MappingName = "Am"
            End With
            ts = New DataGridTableStyle
            For kk = 0 To 11
                cs = New DataGridTextBoxColumn
                With cs
                    .Width = 39
                    .Alignment = HorizontalAlignment.Right
                    .MappingName = "dato" & kk.ToString
                End With
                ts.GridColumnStyles.Add(cs)
            Next
            _GridSy_0.TableStyles.Add(ts)
            With _GridSy_0.TableStyles(0)
                .PreferredRowHeight = 19
                .PreferredColumnWidth = 39
                .RowHeaderWidth = 50
                .RowHeadersVisible = True
                .ColumnHeadersVisible = False
                .HeaderBackColor = Color.Yellow
                .MappingName = "Sy"
            End With
            With _GridAm_0
                r = .GetCellBounds(3, 11)
                .Width = r.Left + r.Width + 4
                .Height = r.Top + r.Height + 4
                .Left = CInt((_Picture1_0.Width - .Width) / 2)
            End With
            With _GridSy_0
                .Width = _GridAm_0.Width
                .Height = _GridAm_0.Height
                .Left = _GridAm_0.Left
            End With
            AggChart(k)
            dvGridAm.AllowNew = False
            dvGridSy.AllowNew = False
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        m.MostraPrezzi()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Dim testo As String
        Dim i, j As Short
        Dim Temp As Short
        Select Case m.Caract.Item(indice + 1).TextData.Codice
            Case Codes.NonDef, Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi '0, 1, 6
                frmChart.DefInstance.ShowDialog()
                testo = _cmbChart_0.Text
                If VB.Left(testo, 1) = "*" Then
                    _lblLoaded_0.Text = "loaded"
                    _cmbChart_0.Items(_cmbChart_0.SelectedIndex) = testo.Substring(2, testo.Length - 2)
                End If
                frmChart.DefInstance.Dispose() ' = Nothing
            Case Codes.EU '8
                For i = 1 To CShort(m.Caract.Count)
                    If m.Caract.Item(i).TextData.Codice = Codes.div1MPa Then
                        m.Caract.Item(indice + 1).TextData.Source = m.Caract.Item(i).TextData.Source
                        m.Caract.Item(indice + 1).TextData.Yield = m.Caract.Item(i).TextData.Yield
                        m.Caract.Item(indice + 1).TextData.US = m.Caract.Item(i).TextData.US * RoutBase1.clsTrigon.MPA
                        For j = 1 To 24
                            Temp = CShort(m.Caract.Item(i).TextData.TempY.Item(j).TextData)
                            If m.Caract.Item(i).TextData.TempY.Item(j).TextData = 0 And m.Caract.Item(i).TextData.AlfaT.Item(j).TextData = 0 Then Temp = 0
                            m.Caract.Item(indice + 1).TextData.Temp.Item(j).TextData = Temp
                            m.Caract.Item(indice + 1).TextData.Ammiss.Item(j).TextData = m.Caract.Item(i).TextData.AlfaT.Item(j).TextData
                        Next
                        RiempiValori(CShort(indice + 1), False)
                        Exit Sub
                    End If
                Next
                For i = 1 To CShort(m.Caract.Count)
                    If m.Caract.Item(i).TextData.Codice = Codes.div1psi Then
                        m.Caract.Item(indice + 1).TextData.Source = m.Caract.Item(i).TextData.Source
                        m.Caract.Item(indice + 1).TextData.Yield = Int(m.Caract.Item(i).TextData.Yield * RoutBase1.clsTrigon.MPA)
                        m.Caract.Item(indice + 1).TextData.US = Int(m.Caract.Item(i).TextData.US * RoutBase1.clsTrigon.MPA)
                        For j = 1 To 24
                            Temp = CShort((m.Caract.Item(i).TextData.TempY.Item(j).TextData - 32) / 1.8)
                            If m.Caract.Item(i).TextData.TempY.Item(j).TextData = 0 And m.Caract.Item(i).TextData.AlfaT.Item(j).TextData = 0 Then Temp = 0
                            m.Caract.Item(indice + 1).TextData.Temp.Item(j).TextData = Temp
                            m.Caract.Item(indice + 1).TextData.Ammiss.Item(j).TextData = Int(m.Caract.Item(i).TextData.AlfaT.Item(j).TextData * RoutBase1.clsTrigon.MPA)
                        Next
                        RiempiValori(CShort(indice + 1), False)
                        Exit For
                    End If
                Next
        End Select
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Dim FormNote As frmNote = New frmNote
        FormNote.consult = consult
        FormNote.ShowDialog()
        FormNote.Dispose()
    End Sub
    Private Sub InitTables()
        Dim kk As Short
        dtGridAm = New DataTable("Am")
        For kk = 0 To 11
            dtGridAm.Columns.Add("dato" & kk.ToString, GetType(Single))
        Next
        dvGridAm = New DataView(dtGridAm)
        dtGridSy = New DataTable("Sy")
        For kk = 0 To 11
            dtGridSy.Columns.Add("dato" & kk.ToString, GetType(Single))
        Next
        dvGridSy = New DataView(dtGridSy)
    End Sub
    Private Function Inizializza() As Boolean
        Dim k, i As Short
        Dim Table As New DataTable
        Dim Temp(25) As Single
        Dim c As System.Windows.Forms.Control
        ReDim Codice(10)
        Inizializza = True
        Try
            m = MatElem()
            If vecchiomind = m.Indmat And m.Indmat > 0 Then Exit Function
            vecchiomind = m.Indmat
            If m Is Nothing Then Exit Function
            If Not IniziaBase() Then Exit Function
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Codici", MatBase)
            cmd.Fill(Table)
            _cmbCurve_0.Text = ""
            _Text2_0.Enabled = False
            _Text2_0.Text = ""
            _Text2_0.Enabled = True
            Dim g As Graphics = Me.CreateGraphics
            Dim ll, larghezza As Integer
            Codice(0) = "Vuoto" : Codici.Items.Clear()
            Codici.Items.Add(Codice(0))
            lCodici.Items.Clear()
            lCodici.Items.Add("0")
            For i = 0 To CShort(Table.Rows.Count - 1)
                If UBound(Codice) < i Then ReDim Preserve Codice(2 * i)
                k = CShort(Table.Rows(i)("Codice"))
                Codice(k) = CStr(Table.Rows(i)("Descrizione"))
                Codici.Items.Add(Codice(k))
                lCodici.Items.Add(CStr(Table.Rows(i)("Codice")))
                ll = CInt(g.MeasureString(Codice(i + 1), Me.Font).Width)
                If ll > larghezza Then larghezza = ll
            Next i
            Codici.DropDownWidth = larghezza
            g.Dispose()
            Table.Dispose()
            Text1(2).Text = m.MatStr
            Text1(3).Text = m.AlloyUNS
            Text1(4).Text = m.Composiz
            Text1(5).Text = m.Product
            Text1(8).Text = m.Spec
            Text1(7).Text = m.Grado
            Text1(6).Text = m.ClassTemper
            Text1(9).Text = m.Dimensions
            Combo1(0).Text = m.CAT
            Combo1(1).Text = m.CT
            Combo1(2).Text = m.CMT
            Text1(1).Text = Str(m.PSP)
            Text1(0).Text = m.NomeComm
            If Not Librer(3) Then Inizializza = False : Exit Function
            Librer(4)
            Librer(5)
            Librer(6)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Dim t As TabPage
        For k = 1 To CShort(m.Caract.Count + 1)
            If k = CShort(m.Caract.Count + 1) Then
                t = New TabPage(Codice(0))
                TabControl1.TabPages.Add(t)
            ElseIf k > 1 Then
                t = New TabPage(Codice(m.Caract.Item(k).TextData.Codice))
                TabControl1.TabPages.Add(t)
            Else
                TabControl1.TabPages(k - 1).Text = Codice(m.Caract.Item(k).TextData.Codice)
            End If
        Next k
        If Not m.Classe = 7 Then
            Combo1(5).Visible = False
            _Label1_8.Visible = False
            cmdLibr(1).Visible = False
        End If
        For Each c In Controls
            c.TabStop = False
        Next c
        Text3.TabStop = True
        Dim ctl As System.Windows.Forms.Control
        If consult Then
            For Each ctl In Controls
                ctl.Enabled = False
            Next ctl
            Command3.Enabled = True
            cmdOK.Enabled = True
            cmdHelp.Enabled = True
            TabControl1.Enabled = True
            Command1.Enabled = True
            Command2.Enabled = True
            cmdLibr(0).Enabled = True
            cmdLibr(1).Enabled = True
            cmdLibr(2).Enabled = True
            cmdLibr(3).Enabled = True
        End If
    End Function
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        If cambiocodice Then
            Codici.Visible = True
            Codici.Focus()
            cambiocodice = False
        End If
    End Sub
    Private Sub AggChart(ByRef k As Short)
        Dim Chart As String
        Dim j As Short
        Dim ii As Integer
        Dim Direct As DataTable
        Dim cmd As OleDbDataAdapter
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        _cmbChart_0.Items.Clear()
        _lstChart_0.Items.Clear()
        If k > m.Caract.Count Then Exit Sub
        If m.Caract.Item(k).TextData.Codice = Codes.NonDef And k = 1 Then m.Caract.Item(k).TextData.Codice = Codes.div1MPa
        Try
            Select Case m.Caract.Item(k).TextData.Codice
                Case Codes.EU
                    _cmbGN_0.Items.Clear()
                    cmd = New OleDbDataAdapter("SELECT * FROM GruppiEN", MatBase)
                    Direct = New DataTable
                    cmd.Fill(Direct)
                    _cmbChart_0.Items.Add("non definito")
                    _lstChart_0.Items.Add("0")
                    ' _cmbChart_0.DropDownWidth = CInt(Funzioni.TwipsToPixelsX(750))
                    For ii = 0 To Direct.Rows.Count - 1
                        Chart = CStr(Direct.Rows(ii)("Gruppo")) & " " & CStr(Direct.Rows(ii)("Descrizione"))
                        _cmbChart_0.Items.Add(Chart)
                        _lstChart_0.Items.Add(Str(Direct.Rows(ii)("ID")))
                    Next
                    Direct.Dispose()
                    _cmbChart_0.SelectedIndex = m.Caract.Item(k).TextData.IndChart
                    '--------------------------------------------------------
                    cmd = New OleDbDataAdapter("SELECT * FROM ClassiSic", MatBase)
                    Direct = New DataTable
                    cmd.Fill(Direct)
                    _cmbGN_0.Items.Add("non definito")
                    _lstChart_0.Items.Add("0")
                    For ii = 0 To Direct.Rows.Count - 1
                        If IsDBNull(Direct.Rows(ii)("ClasseSic")) Then
                            Chart = "N.A."
                        Else
                            Chart = CStr(Direct.Rows(ii)("ClasseSic"))
                        End If
                        _cmbGN_0.Items.Add(Chart)
                        _lstChart_0.Items.Add(Str(Direct.Rows(ii)("ID")))
                    Next ii
                    Direct.Dispose()
                    _cmbGN_0.Text = Trim(m.Caract.Item(k).TextData.Group)
                Case Codes.div1MPa, Codes.div2MPa, Codes.div1psi, Codes.div2psi
                    cmd = New OleDbDataAdapter("SELECT * FROM DirectCH ORDER BY Codice", MatBase)
                    Direct = New DataTable
                    cmd.Fill(Direct)
                    _cmbChart_0.Items.Add("non definito")
                    _lstChart_0.Items.Add("0")
                    For ii = 0 To Direct.Rows.Count - 1
                        Chart = CStr(Direct.Rows(ii)("Codice"))
                        If CStr(Direct.Rows(ii)("Descrizione")) = "Assente" Then Chart = "* " & Chart
                        _cmbChart_0.Items.Add(Chart)
                        _lstChart_0.Items.Add(Str(Direct.Rows(ii)("ID")))
                    Next ii
                    Direct.Dispose()
                    For j = 0 To CShort(_lstChart_0.Items.Count - 1)
                        If CShort(_lstChart_0.Items(j)) = m.Caract.Item(k).TextData.IndChart Then
                            _lstChart_0.SelectedIndex = j
                            _cmbChart_0.SelectedIndex = j
                            Exit For
                        End If
                    Next
                    '         cmbChart(k - 1).ListIndex = m.Caract(k).IndChart
                    _cmbMWDTrule_0.Items.Clear()
                    _cmbMWDTrule_0.Visible = True
                    Select Case m.Caract.Item(k).TextData.Codice
                        Case Codes.div1MPa, Codes.div1psi '1, 2
                            _cmbMWDTrule_0.Items.Add("not appl.")
                            _cmbMWDTrule_0.Items.Add("UCS-66")
                            _cmbMWDTrule_0.Items.Add("UHA-51")
                            _cmbMWDTrule_0.Items.Add("UNF-65")
                            _cmbMWDTrule_0.Items.Add("UHT-5(c)")
                        Case Codes.div2MPa, Codes.div2psi '6
                            _cmbMWDTrule_0.Items.Add("not appl.")
                            _cmbMWDTrule_0.Items.Add("ACS-1")
                            _cmbMWDTrule_0.Items.Add("AHA-1")
                            _cmbMWDTrule_0.Items.Add("ANF-1")
                            _cmbMWDTrule_0.Items.Add("AQT-1")
                            _cmbMWDTrule_0.Items.Add("ABM-1")
                            _cmbMWDTrule_0.Items.Add("ABM-2")
                        Case Else
                            _cmbMWDTrule_0.Visible = False
                    End Select
                    _cmbCurve_0.Enabled = False
                    Select Case VB.Left(m.Caract.Item(k).TextData.MWDTrule, 3)
                        Case "UCS", "ACS"
                            _cmbMWDTrule_0.SelectedIndex = 1
                            AggCmbC(1)
                            _Text2_0.Text = Str(m.Caract.Item(k).TextData.MWDTtemp)
                            If m.Caract.Item(k).TextData.MWDTtemp = 100 Then
                                _Text2_0.Text = "All"
                            ElseIf m.Caract.Item(k).TextData.MWDTtemp = -1000 Then
                                _Text2_0.Text = "N.A."
                            End If
                        Case "UHA", "AHA"
                            _cmbMWDTrule_0.SelectedIndex = 2
                            AggCmbC(2)
                            _Text2_0.Text = m.Caract.Item(k).TextData.MWDTtemp.ToString
                        Case "UNF", "ANF"
                            _cmbMWDTrule_0.SelectedIndex = 3
                            AggCmbC(3)
                            _Text2_0.Text = m.Caract.Item(k).TextData.MWDTtemp.ToString
                        Case "UHT", "AQT"
                            _cmbMWDTrule_0.SelectedIndex = 4
                            AggCmbC(4)
                        Case "ABM"
                            _cmbMWDTrule_0.SelectedIndex = CInt(4 + Val(m.Caract.Item(k).TextData.MWDTrule.Substring(4, 1)))
                            AggCmbC(4)
                        Case Else : If _cmbMWDTrule_0.Items.Count > 0 Then _cmbMWDTrule_0.SelectedIndex = 0
                    End Select
                    _cmbCurve_0.Enabled = True
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        _GridAm_0.Enabled = True
        _GridSy_0.Enabled = True
    End Sub
    Private Sub AggCmbC(ByRef j As Short)
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        _cmbCurve_0.Enabled = False
        Select Case j
            Case 0
                _cmbCurve_0.Visible = False
                _lblCurve_0.Visible = False
                _lblImpactT_0.Visible = False
                _Text2_0.Visible = False
            Case 1
                _cmbCurve_0.Items.Clear()
                _cmbCurve_0.Items.Add("?")
                _cmbCurve_0.Items.Add("A")
                _cmbCurve_0.Items.Add("B")
                _cmbCurve_0.Items.Add("C")
                _cmbCurve_0.Items.Add("D")
                _cmbCurve_0.Items.Add("bolts")
                Select Case Trim(m.Caract.Item(IndCaract).TextData.MWDTclause)
                    Case "A" : _cmbCurve_0.SelectedIndex = 1
                    Case "B" : _cmbCurve_0.SelectedIndex = 2
                    Case "C" : _cmbCurve_0.SelectedIndex = 3
                    Case "D" : _cmbCurve_0.SelectedIndex = 4
                    Case "E" : _cmbCurve_0.SelectedIndex = 5
                    Case Else : _cmbCurve_0.SelectedIndex = 0
                End Select
                _lblCurve_0.Text = "Curve"
                _lblCurve_0.Visible = True
                _cmbCurve_0.Visible = True
                _lblImpactT_0.Visible = True
                _Text2_0.Visible = True
            Case 2
                '    _cmbCurve_0.Clear
                '    _cmbCurve_0.AddItem "Y"
                '    _cmbCurve_0.AddItem "N"
                '                       Select Case Trim(m.Caract(i + 1).MWDTclause)
                '                          Case "Y": _cmbCurve_0.ListIndex = 0
                '                          Case "N": _cmbCurve_0.ListIndex = 1
                '                          Case Else: _cmbCurve_0.ListIndex = 1
                '                       End Select
                '                       _lblCurve_0.Caption = "Incl."
                _lblCurve_0.Visible = False
                _cmbCurve_0.Visible = False
                _lblImpactT_0.Visible = True
                _Text2_0.Visible = True
            Case 3, 4
                _cmbCurve_0.Visible = False
                _lblCurve_0.Visible = False
                _lblImpactT_0.Visible = True
                _Text2_0.Visible = True
        End Select
        _cmbCurve_0.Enabled = True
    End Sub
    Private Sub RiempiValori(ByRef k As Short, ByVal nuovo As Boolean)
        Dim i, kk As Short
        Dim m As LibMat.MaterialeNew1
        Dim drv As DataRowView
        m = MatElem()
        Try
            If nuovo Then InitTables()
            dvGridAm.AllowNew = True
            dvGridSy.AllowNew = True
            For kk = 0 To 1
                If nuovo Then
                    drv = dvGridAm.AddNew
                Else
                    drv = dvGridAm(0)
                    drv.BeginEdit()
                End If
                For i = 1 To 12
                    If k > m.Caract.Count Then
                        drv(i - 1) = 0
                    Else
                        drv(i - 1) = m.Caract.Item(k).TextData.Temp.Item(i + 12 * kk).TextData
                    End If
                Next
                drv.EndEdit()
                If nuovo Then
                    drv = dvGridAm.AddNew
                Else
                    drv = dvGridAm(1)
                    drv.BeginEdit()
                End If
                For i = 1 To 12
                    If k > m.Caract.Count Then
                        drv(i - 1) = 0
                    Else
                        drv(i - 1) = m.Caract.Item(k).TextData.Ammiss.Item(i + 12 * kk).TextData
                    End If
                Next
                drv.EndEdit()
                If nuovo Then
                    drv = dvGridSy.AddNew
                Else
                    drv = dvGridSy(0)
                    drv.BeginEdit()
                End If
                For i = 1 To 12
                    If k > m.Caract.Count Then
                        drv(i - 1) = 0
                    Else
                        drv(i - 1) = m.Caract.Item(k).TextData.TempY.Item(i + 12 * kk).TextData
                    End If
                Next
                drv.EndEdit()
                If nuovo Then
                    drv = dvGridSy.AddNew
                Else
                    drv = dvGridSy(1)
                    drv.BeginEdit()
                End If
                For i = 1 To 12
                    If k > m.Caract.Count Then
                        drv(i - 1) = 0
                    Else
                        drv(i - 1) = m.Caract.Item(k).TextData.AlfaT.Item(i + 12 * kk).TextData
                    End If
                Next
                drv.EndEdit()
            Next
            If k > m.Caract.Count Then
                _txtFonte_0.Text = ""
                _txtSy_0.Text = ""
                _txtUS_0.Text = ""
                _cmbPN_0.Text = ""
                _cmbGN_0.Text = ""
                _txtCreep_0.Text = ""
            Else
                _txtFonte_0.Text = m.Caract.Item(k).TextData.Source
                _txtSy_0.Text = LTrim(Str(m.Caract.Item(k).TextData.Yield))
                _txtUS_0.Text = LTrim(Str(m.Caract.Item(k).TextData.US))
                _cmbPN_0.Text = m.Caract.Item(k).TextData.PNumber
                _cmbGN_0.Text = m.Caract.Item(k).TextData.Group
                _txtCreep_0.Text = LTrim(Str(m.Caract.Item(k).TextData.CreepRange))
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub TabControl1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabControl1.MouseUp
        Dim m As LibMat.MaterialeNew1
        Dim Rect As Rectangle
        If Not e.Button = Windows.Forms.MouseButtons.Right Or consult Then Exit Sub
        cambiocodice = False
        m = MatElem()
        If m Is Nothing Then Exit Sub
        Dim Index As Integer = -1
        Dim i As Integer
        For i = 0 To TabControl1.TabCount - 1
            Rect = TabControl1.GetTabRect(i)
            If Rect.Contains(e.X, e.Y) Then
                Index = i
                TabControl1.SelectedIndex = i
                Exit For
            End If
        Next
        If Index < 0 Then Exit Sub
        Codici.Top = TabControl1.Top + Rect.Top + Rect.Height
        Codici.Left = TabControl1.Left + Rect.Left
        If Codici.Width < Rect.Width Then Codici.Width = Rect.Width
        If Codici.Left + Codici.Width > TabControl1.Width Then _
        Codici.Left = Codici.Left - (TabControl1.Width - (Codici.Left + Codici.Width))
        Try
            Codici.SelectedIndex = m.Caract.Item(Index).TextData.Codice
        Catch
        End Try
        Codici.Visible = True
        Codici.BringToFront()
        Codici.Focus()
        cambiocodice = True
    End Sub

    Private Sub _Text2_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text2_0.TextChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        If Not _Text2_0.Enabled Then Exit Sub
        If InStr(UCase(_Text2_0.Text), "N") > 0 Then
            m.Caract.Item(IndCaract).TextData.MWDTtemp = -1000
        ElseIf InStr(UCase(_Text2_0.Text), "A") > 0 Then
            m.Caract.Item(IndCaract).TextData.MWDTtemp = 100
        Else
            m.Caract.Item(IndCaract).TextData.MWDTtemp = Funzioni.ValVir(_Text2_0.Text)
        End If
    End Sub
    Private Sub _cmdLibr_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdLibr_0.Click
        cmdLibr_Click(0)
    End Sub

    Private Sub _cmdLibr_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdLibr_1.Click
        cmdLibr_Click(1)
    End Sub

    Private Sub _cmdLibr_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdLibr_2.Click
        cmdLibr_Click(2)
    End Sub

    Private Sub _cmdLibr_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdLibr_3.Click
        cmdLibr_Click(3)
    End Sub

    Private Sub _txtFonte_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtFonte_0.TextChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        m.Caract.Item(IndCaract).TextData.Source = _txtFonte_0.Text
    End Sub
    Private Sub _cmbGN_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbGN_0.SelectedIndexChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        Select Case m.Caract.Item(IndCaract).TextData.Codice
            Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi '1, 6
            Case Codes.EU '8
                m.Caract.Item(IndCaract).TextData.Group = _cmbGN_0.Text
        End Select
    End Sub
    Private Sub _cmbCurve_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCurve_0.SelectedIndexChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        If CStr(_cmbCurve_0.Items(_cmbCurve_0.SelectedIndex)) = "bolts" Then
            m.Caract.Item(IndCaract).TextData.MWDTclause = "E"
        Else
            m.Caract.Item(IndCaract).TextData.MWDTclause = CStr(_cmbCurve_0.Items(_cmbCurve_0.SelectedIndex))
        End If
    End Sub
    Private Sub _cmbMWDTrule_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbMWDTrule_0.SelectedIndexChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        m.Caract.Item(IndCaract).TextData.MWDTrule = _cmbMWDTrule_0.Text
        AggCmbC(CShort(_cmbMWDTrule_0.SelectedIndex))
    End Sub
    Private Sub _cmbChart_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbChart_0.SelectedIndexChanged
        Dim testo As String
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        _lstChart_0.SelectedIndex = _cmbChart_0.SelectedIndex
        m.Caract.Item(IndCaract).TextData.IndChart = CShort(_lstChart_0.Items(_cmbChart_0.SelectedIndex))
        Select Case m.Caract.Item(IndCaract).TextData.Codice
            Case Codes.NonDef, Codes.div1MPa, Codes.div2MPa, Codes.div1psi, Codes.div2psi ' 0, 1, 6
            Case Else : Exit Sub
        End Select
        testo = _cmbChart_0.Text
        If VB.Left(testo, 1) = "*" Then _lblLoaded_0.Text = "missing" Else _lblLoaded_0.Text = "loaded"
    End Sub
    Private Sub _txtUS_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtUS_0.TextChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        m.Caract.Item(IndCaract).TextData.US = Funzioni.ValVir(_txtUS_0.Text)
    End Sub
    Private Sub _txtCreep_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCreep_0.TextChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        m.Caract.Item(IndCaract).TextData.CreepRange = Funzioni.ValVir(_txtCreep_0.Text)
    End Sub
    Private Sub _txtSy_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSy_0.TextChanged
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract > m.Caract.Count Then Exit Sub
        m.Caract.Item(IndCaract).TextData.Yield = Funzioni.ValVir(_txtSy_0.Text)
    End Sub
    Private Sub _Combo1_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_0.SelectedIndexChanged
        Combo1_SelectedIndexChanged(0)
    End Sub

    Private Sub _Combo1_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_1.SelectedIndexChanged
        Combo1_SelectedIndexChanged(1)
    End Sub

    Private Sub _Combo1_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_2.SelectedIndexChanged
        Combo1_SelectedIndexChanged(2)
    End Sub

    Private Sub _Combo1_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_3.SelectedIndexChanged
        Combo1_SelectedIndexChanged(3)
    End Sub

    Private Sub _Combo1_4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_4.SelectedIndexChanged
        Combo1_SelectedIndexChanged(4)
    End Sub

    Private Sub _Combo1_5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_5.SelectedIndexChanged
        Combo1_SelectedIndexChanged(5)
    End Sub
    Private Sub _Combo1_6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_6.SelectedIndexChanged
        Combo1_SelectedIndexChanged(6)
    End Sub
    Private Sub _GridSy_0_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _GridSy_0.Paint
        If IsInitializing Or m Is Nothing Then Exit Sub
        Dim Header(3) As String
        Dim b As New SolidBrush(Color.Black)
        Try
            Dim g As Graphics = e.Graphics
            Dim c As Codes
            If indice + 1 > m.Caract.Count Then
                c = Codes.EU
            Else
                c = m.Caract.Item(indice + 1).TextData.Codice
            End If
            Select Case c
                Case Codes.div1psi, Codes.div2psi
                    Header(0) = "T (°F)"
                    Header(2) = "T (°F)"
                    Header(1) = "Sy(psi)"
                    Header(3) = "Sy(psi)"
                Case Codes.div1MPa, Codes.div2MPa
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "Sy(MPa)"
                    Header(3) = "Sy(MPa)"
                Case Codes.Stoomwezen '7
                    'Stoomwezen
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "Rmg"
                    Header(3) = "Rmg"
                Case Codes.EU '8
                    'Euronorm
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "Rm/t"
                    Header(3) = "Rm/t"
            End Select
            Dim row As Integer = 0
            Dim yDelta As Integer
            Dim y As Integer
            Try
                yDelta = _GridSy_0.GetCellBounds(row, 0).Height + 1
                y = _GridSy_0.GetCellBounds(row, 0).Top + 2
            Catch
                Exit Sub
            End Try
            While (y < _GridSy_0.Height - yDelta And row < 4)
                g.DrawString(Header(row), _GridSy_0.Font, b, 12, y)
                y += yDelta
                row += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim i As Short
        If IsInitializing Then Exit Sub
        Dim m As LibMat.MaterialeNew1
        m = MatElem()
        If m Is Nothing Then Exit Sub
        i = CShort(TabControl1.SelectedIndex)
        indice = i
        If i = m.Caract.Count Then
            CodiceCalc = Codes.NonDef
        Else
            CodiceCalc = m.Caract.Item(i + 1).TextData.Codice
        End If
        Command2.Visible = True
        _lblChart_0.Visible = True
        _cmbChart_0.Visible = True
        _lblLoaded_0.Visible = True
        _lblPN_0.Visible = True
        _cmbPN_0.Visible = True
        _lblGN_0.Visible = True
        _cmbGN_0.Visible = True
        _lblMWDTrule_0.Visible = True
        _cmbMWDTrule_0.Visible = True
        _lblCurve_0.Visible = True
        _cmbCurve_0.Visible = True
        HelpProvider1.SetHelpKeyword(CType(_cmbGN_0, Control), Monitor.Motore.HelptopicG(IDHS.IDH_LB_SCHEDA_PNUMBER))
        HelpProvider1.SetHelpKeyword(CType(_cmbChart_0, Control), Monitor.Motore.HelptopicG(IDHS.IDH_LB_SCHEDA_CHART))
        Select Case CodiceCalc
            Case Codes.div1psi, Codes.div2psi
                _lblChart_0.Text = "Chart"
                _lblGN_0.Text = "GroupN"
                _lblPN_0.Visible = True
                _cmbPN_0.Visible = True
                _lblMWDTrule_0.Visible = True
                _cmbMWDTrule_0.Visible = True
                _lblCurve_0.Visible = True
                _cmbCurve_0.Visible = True
                _lbl1psi_0.Text = "psi"
                _lbl2psi_0.Text = "psi"
                _lblImpactT_0.Text = "Impact T°F"
                _lblF_0.Text = "(°F)"
            Case Codes.div1MPa, Codes.div2MPa
                _lblChart_0.Text = "Chart"
                _lblGN_0.Text = "GroupN"
                _lblPN_0.Visible = True
                _cmbPN_0.Visible = True
                _lblMWDTrule_0.Visible = True
                _cmbMWDTrule_0.Visible = True
                _lblCurve_0.Visible = True
                _cmbCurve_0.Visible = True
                _lbl1psi_0.Text = "MPa"
                _lbl2psi_0.Text = "MPa"
                _lblImpactT_0.Text = "Impact T°C"
                _lblF_0.Text = "(°C)"
            Case Codes.Stoomwezen '7 'Stoomwezen
                Command2.Visible = False
                _lblChart_0.Visible = False
                _cmbChart_0.Visible = False
                _lblLoaded_0.Visible = False
                _lblPN_0.Visible = False
                _cmbPN_0.Visible = False
                _lblGN_0.Visible = False
                _cmbGN_0.Visible = False
                _lblMWDTrule_0.Visible = False
                _cmbMWDTrule_0.Visible = False
                _lblCurve_0.Visible = False
                _cmbCurve_0.Visible = False
                _lbl1psi_0.Text = "MPa"
                _lbl2psi_0.Text = "MPa"
                _lblImpactT_0.Text = "Impact T°C"
            Case Codes.EU '8
                _lblChart_0.Text = "Group"
                _lblLoaded_0.Text = "Transl."
                HelpProvider1.SetHelpKeyword(CType(_cmbChart_0, Control), "EU_CHM_MATGROUP")
                _lblPN_0.Visible = False
                _cmbPN_0.Visible = False
                _lblGN_0.Text = "Categ."
                HelpProvider1.SetHelpKeyword(CType(_cmbGN_0, Control), "EU_CHM_MATCATEGORY")
                _lblMWDTrule_0.Visible = False
                _cmbMWDTrule_0.Visible = False
                _lblCurve_0.Visible = False
                _cmbCurve_0.Visible = False
                _lbl1psi_0.Text = "MPa"
                _lbl2psi_0.Text = "MPa"
                _lblImpactT_0.Text = "Impact T°C"
            Case Else
                Command2.Visible = False
        End Select
        If m.Classe = 8 Then
            Command2.Visible = False
            _cmbPN_0.Visible = False
            _lblPN_0.Visible = False
            _cmbGN_0.Visible = False
            _lblGN_0.Visible = False
            _cmbChart_0.Visible = False
            _lblChart_0.Visible = False
            _lblLoaded_0.Visible = False
        End If
        SalvaGriglie()
        AggiornaGriglie(CShort(i + 1))
    End Sub
    Private Sub SalvaGriglie()
        Dim i, kk, k As Short
        Dim m As LibMat.MaterialeNew1
        Dim drv As DataRowView
        m = MatElem()
        If m Is Nothing Then Exit Sub
        If IndCaract = 0 Or consult Or IndCaract > m.Caract.Count Then Exit Sub
        Try
            k = CShort(IndCaract)
            For kk = 0 To 1
                drv = dvGridAm(2 * kk)
                For i = 1 To 12
                    m.Caract.Item(k).TextData.Temp.Item(i + 12 * kk).TextData = CSng(drv(i - 1))
                Next
                drv = dvGridAm(2 * kk + 1)
                For i = 1 To 12
                    m.Caract.Item(k).TextData.Ammiss.Item(i + 12 * kk).TextData = CSng(drv(i - 1))
                Next
                drv = dvGridSy(2 * kk)
                For i = 1 To 12
                    m.Caract.Item(k).TextData.TempY.Item(i + 12 * kk).TextData = CSng(drv(i - 1))
                Next
                drv = dvGridSy(2 * kk + 1)
                For i = 1 To 12
                    m.Caract.Item(k).TextData.AlfaT.Item(i + 12 * kk).TextData = CSng(drv(i - 1))
                Next
            Next
            m.Caract.Item(k).TextData.Source = _txtFonte_0.Text
            m.Caract.Item(k).TextData.Yield = Funzioni.ValVir(_txtSy_0.Text)
            m.Caract.Item(k).TextData.US = CSng(Funzioni.ValVir(_txtUS_0.Text))
            m.Caract.Item(k).TextData.CreepRange = CSng(Funzioni.ValVir(_txtCreep_0.Text))
            m.Caract.Item(k).TextData.PNumber = Funzioni.Adjust(Trim(_cmbPN_0.Text), 3)
            m.Caract.Item(k).TextData.Group = _cmbGN_0.Text
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function Librer(ByRef ic As Short) As Boolean
        Dim i, j As Short
        Dim Table As DataTable
        Dim m As LibMat.MaterialeNew1
        Dim cmd As OleDbDataAdapter
        Dim iFound As Integer
        m = MatElem()
        Librer = True
        If m Is Nothing Then
            MsgBox("Nessun materiale specificato per la function 'Librer'")
            Librer = False
            Exit Function
        End If
        Try
            If m.Agganciato Then
                If ic = 3 Then
                    cmd = New OleDbDataAdapter("SELECT * FROM Modelas", MatBase)
                ElseIf ic = 4 Then
                    cmd = New OleDbDataAdapter("SELECT * FROM Alfater", MatBase)
                ElseIf ic = 6 Then
                    cmd = New OleDbDataAdapter("SELECT * FROM ConducTer", MatBase)
                Else
                    cmd = New OleDbDataAdapter("SELECT * FROM Groupmt", MatBase)
                End If
                Table = New DataTable
                cmd.Fill(Table)
            Else
                If ic = 3 Then
                    Table = m.AlfaYoung.tblEmod
                ElseIf ic = 4 Then
                    Table = m.AlfaYoung.tblAlfa
                ElseIf ic = 6 Then
                    Table = m.AlfaYoung.tblCond
                Else
                    cmd = New OleDbDataAdapter("SELECT * FROM Groupmt", MatBase)
                    Table = New DataTable
                    cmd.Fill(Table)
                End If
            End If
        Catch e1 As OleDbException
            MsgBox(e1.Message)
            Librer = False
            Exit Function
        Catch e2 As Exception
            MsgBox(e2.Message + vbCrLf + e2.StackTrace)
            Librer = False
            Exit Function
        End Try
        If m.Agganciato Then
            Dim dvTable As DataView = New DataView(Table)
            dvTable.Sort = "ID"
            i = 1
            Combo1(ic).Items.Clear()
            List1(ic).Items.Clear()
            Do
                If i = 1 Then
                    Combo1(ic).Items.Add("non definito")
                    List1(ic).Items.Add("0")
                Else
                    Combo1(ic).Items.Add(Table.Rows(i - 1)(1))
                    List1(ic).Items.Add(CStr(Table.Rows(i - 1)("ID")))
                End If
                i = CShort(i + 1)
            Loop While i <= Table.Rows.Count
            If ic = 3 Then
                If m.ElasCod < 0 Then m.ElasCod = 0
                iFound = dvTable.Find(m.ElasCod)
                If iFound < 0 Then
                    Combo1(3).SelectedIndex = 0
                Else
                    For j = 0 To CShort(List1(ic).Items.Count - 1)
                        If CShort(List1(ic).Items(j)) = m.ElasCod Then
                            Combo1(ic).SelectedIndex = j ' Table.AbsolutePosition + 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf ic = 4 Then
                If m.alfacod < 0 Then m.alfacod = 0
                iFound = dvTable.Find(m.alfacod)
                If iFound < 0 Then
                    Combo1(4).SelectedIndex = 0
                Else
                    For j = 0 To CShort(List1(ic).Items.Count - 1)
                        If CShort(List1(ic).Items(j)) = m.alfacod Then
                            Combo1(ic).SelectedIndex = j ' Table.AbsolutePosition + 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf ic = 6 Then
                If m.ConducTer < 0 Then m.ConducTer = 0
                iFound = dvTable.Find(m.ConducTer)
                If iFound < 0 Then
                    Combo1(6).SelectedIndex = 0
                Else
                    For j = 0 To CShort(List1(ic).Items.Count - 1)
                        If CShort(List1(ic).Items(j)) = m.ConducTer Then
                            Combo1(ic).SelectedIndex = j ' Table.AbsolutePosition + 1
                            Exit For
                        End If
                    Next
                End If
            Else
                If m.MatGroup < 0 Then m.MatGroup = 0
                iFound = dvTable.Find(m.MatGroup)
                If iFound < 0 Then
                    Combo1(5).SelectedIndex = 0
                Else
                    Combo1(5).SelectedIndex = iFound '+ 1 ' Table.AbsolutePosition + 1
                End If
            End If
            dvTable.Dispose()
            Table.Dispose()
        Else
            If ic = 3 Or ic = 4 Or ic = 6 Then
                Combo1(ic).Items.Clear()
                List1(ic).Items.Clear()
                Combo1(ic).Items.Add(Table.Rows(1)(1))
                List1(ic).Items.Add(CStr(Table.Rows(1)(0)))
                Combo1(ic).SelectedIndex = 0
            Else
                Dim dvTable As DataView = New DataView(Table)
                dvtable.Sort = "ID"
                i = 1
                Combo1(ic).Items.Clear()
                List1(ic).Items.Clear()
                Do
                    If i = 1 Then
                        Combo1(ic).Items.Add("non definito")
                        List1(ic).Items.Add("0")
                    Else
                        Combo1(ic).Items.Add(Table.Rows(i - 1)(1))
                        List1(ic).Items.Add(CStr(Table.Rows(i - 1)("ID")))
                    End If
                    i = CShort(i + 1)
                Loop While i <= Table.Rows.Count
                If m.MatGroup < 0 Then m.MatGroup = 0
                iFound = dvTable.Find(m.MatGroup)
                If iFound < 0 Then
                    Combo1(5).SelectedIndex = 0
                Else
                    Combo1(5).SelectedIndex = iFound + 1 ' Table.AbsolutePosition + 1
                End If
            End If
        End If
    End Function
    Private Sub _GridAm_0_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _GridAm_0.Paint
        If IsInitializing Or m Is Nothing Then Exit Sub
        Dim Header(3) As String
        Dim b As New SolidBrush(Color.Black)
        Try
            Dim g As Graphics = e.Graphics
            Dim c As Codes
            If indice + 1 > m.Caract.Count Then
                c = Codes.EU
            Else
                c = m.Caract.Item(indice + 1).TextData.Codice
            End If
            Select Case c
                Case Codes.div1psi
                    Header(0) = "T (°F)"
                    Header(2) = "T (°F)"
                    Header(1) = "S (psi)"
                    Header(3) = "S (psi)"
                Case Codes.div2psi    '1, 2, 6
                    Header(0) = "T (°F)"
                    Header(2) = "T (°F)"
                    Header(1) = "Sm(psi)"
                    Header(3) = "Sm(psi)"
                Case Codes.div1MPa
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "S (MPa)"
                    Header(3) = "S (MPa)"
                Case Codes.div2MPa
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "Sm(MPa)"
                    Header(3) = "Sm(MPa)"
                Case Codes.Stoomwezen '7
                    'Stoomwezen
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "Re"
                    Header(3) = "Re"
                Case Codes.EU '8
                    'Euronorm
                    Header(0) = "T (°C)"
                    Header(2) = "T (°C)"
                    Header(1) = "Rp(MPa)"
                    Header(3) = "Rp(MPa)"
            End Select
            Dim row As Integer = 0
            Dim yDelta As Integer
            Dim y As Integer
            Try
                yDelta = _GridAm_0.GetCellBounds(row, 0).Height + 1
                y = _GridAm_0.GetCellBounds(row, 0).Top + 2
            Catch
                Exit Sub
            End Try
            While (y < _GridAm_0.Height - yDelta And row < 4)
                g.DrawString(Header(row), _GridAm_0.Font, b, 12, y)
                y += yDelta
                row += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try

    End Sub
    Private Sub frmScheda_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not GiaFatto Then TabControl1_SelectedIndexChanged(Me, New EventArgs)
        GiaFatto = True
    End Sub
End Class