Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports VB = Microsoft.VisualBasic
Public Class frmFlange
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
        'If m_vb6FormDefInstance Is Nothing Then
        'If m_InitializingDefInstance Then
        'm_vb6FormDefInstance = Me
        'Else
        '    Try
        ''La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        'If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        'm_vb6FormDefInstance = Me
        'End If
        '    Catch
        'End Try
        'End If
        'End If
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
    Public WithEvents _Option1_4 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_3 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents cmdVista As System.Windows.Forms.Button
    Public WithEvents cmbTab As System.Windows.Forms.ComboBox
    Public WithEvents cmbFacing As System.Windows.Forms.ComboBox
    Public WithEvents MinASME As System.Windows.Forms.Button
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Text5_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text4_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text3_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text2_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents cmbRating As System.Windows.Forms.ComboBox
    Public WithEvents cmbDiaN As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents _Label3_17 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_4 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_3 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_2 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_1 As System.Windows.Forms.Label
    Public WithEvents _lblTipo_0 As System.Windows.Forms.Label
    Public WithEvents _Label3_16 As System.Windows.Forms.Label
    Public WithEvents _Label3_15 As System.Windows.Forms.Label
    Public WithEvents _Label3_14 As System.Windows.Forms.Label
    Public WithEvents _Label3_13 As System.Windows.Forms.Label
    Public WithEvents _Label3_12 As System.Windows.Forms.Label
    Public WithEvents _Label3_11 As System.Windows.Forms.Label
    Public WithEvents _Label3_10 As System.Windows.Forms.Label
    Public WithEvents _Label3_9 As System.Windows.Forms.Label
    Public WithEvents _Label3_8 As System.Windows.Forms.Label
    Public WithEvents _Label3_7 As System.Windows.Forms.Label
    Public WithEvents _Label3_6 As System.Windows.Forms.Label
    Public WithEvents _Label3_5 As System.Windows.Forms.Label
    Public WithEvents _Label3_4 As System.Windows.Forms.Label
    Public WithEvents _Label3_3 As System.Windows.Forms.Label
    Public WithEvents _Label3_2 As System.Windows.Forms.Label
    Public WithEvents _Label3_1 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Option1 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents Text2 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents Text3 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents Text4 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents Text5 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents lblTipo As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents cnQuery As System.Data.OleDb.OleDbConnection
    Friend WithEvents AdapterQuery As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand5 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand5 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand7 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand7 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand6 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand6 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand8 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand8 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand7 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand7 As System.Data.OleDb.OleDbCommand
    Friend WithEvents AdapterCatalogo As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterDiametri As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterFacings As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterFacValori As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterRatings As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterTabelle As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterTipi As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents AdapterValori As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents QuerySelect As System.Data.OleDb.OleDbCommand
    Friend WithEvents QueryInsert As System.Data.OleDb.OleDbCommand
    Friend WithEvents CatalogoSelect As System.Data.OleDb.OleDbCommand
    Friend WithEvents CatalogoInsert As System.Data.OleDb.OleDbCommand
    Friend WithEvents CatalogoUpdate As System.Data.OleDb.OleDbCommand
    Friend WithEvents CatalogoDelete As System.Data.OleDb.OleDbCommand
    Friend WithEvents DiametriSelect As System.Data.OleDb.OleDbCommand
    Friend WithEvents DiametriInsert As System.Data.OleDb.OleDbCommand
    Friend WithEvents DiametriUpdate As System.Data.OleDb.OleDbCommand
    Friend WithEvents DiametriDelete As System.Data.OleDb.OleDbCommand
    Friend WithEvents FacingsSelect As System.Data.OleDb.OleDbCommand
    Friend WithEvents FacingsInsert As System.Data.OleDb.OleDbCommand
    Friend WithEvents FacingsUpdate As System.Data.OleDb.OleDbCommand
    Friend WithEvents FacingsDelete As System.Data.OleDb.OleDbCommand
    Friend WithEvents RatingsSelect As System.Data.OleDb.OleDbCommand
    Friend WithEvents RatingsInsert As System.Data.OleDb.OleDbCommand
    Friend WithEvents RatingsUpdate As System.Data.OleDb.OleDbCommand
    Friend WithEvents RatingsDelete As System.Data.OleDb.OleDbCommand
    Friend WithEvents dsFlange As Grafica.DataSet1
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents chkReg As System.Windows.Forms.CheckBox
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdVista = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.chkReg = New System.Windows.Forms.CheckBox
        Me._Option1_4 = New System.Windows.Forms.RadioButton
        Me._Option1_3 = New System.Windows.Forms.RadioButton
        Me._Option1_2 = New System.Windows.Forms.RadioButton
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.cmbTab = New System.Windows.Forms.ComboBox
        Me.dsFlange = New Grafica.DataSet1
        Me.cmbFacing = New System.Windows.Forms.ComboBox
        Me.MinASME = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me._Text5_0 = New System.Windows.Forms.TextBox
        Me._Text4_0 = New System.Windows.Forms.TextBox
        Me._Text3_0 = New System.Windows.Forms.TextBox
        Me._Text2_0 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.cmbRating = New System.Windows.Forms.ComboBox
        Me.cmbDiaN = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me._Label3_17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me._lblTipo_4 = New System.Windows.Forms.Label
        Me._lblTipo_3 = New System.Windows.Forms.Label
        Me._lblTipo_2 = New System.Windows.Forms.Label
        Me._lblTipo_1 = New System.Windows.Forms.Label
        Me._lblTipo_0 = New System.Windows.Forms.Label
        Me._Label3_16 = New System.Windows.Forms.Label
        Me._Label3_15 = New System.Windows.Forms.Label
        Me._Label3_14 = New System.Windows.Forms.Label
        Me._Label3_13 = New System.Windows.Forms.Label
        Me._Label3_12 = New System.Windows.Forms.Label
        Me._Label3_11 = New System.Windows.Forms.Label
        Me._Label3_10 = New System.Windows.Forms.Label
        Me._Label3_9 = New System.Windows.Forms.Label
        Me._Label3_8 = New System.Windows.Forms.Label
        Me._Label3_7 = New System.Windows.Forms.Label
        Me._Label3_6 = New System.Windows.Forms.Label
        Me._Label3_5 = New System.Windows.Forms.Label
        Me._Label3_4 = New System.Windows.Forms.Label
        Me._Label3_3 = New System.Windows.Forms.Label
        Me._Label3_2 = New System.Windows.Forms.Label
        Me._Label3_1 = New System.Windows.Forms.Label
        Me._Label3_0 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Option1 = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.Text2 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.Text3 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.Text4 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.Text5 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.lblTipo = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.QuerySelect = New System.Data.OleDb.OleDbCommand
        Me.cnQuery = New System.Data.OleDb.OleDbConnection
        Me.QueryInsert = New System.Data.OleDb.OleDbCommand
        Me.AdapterQuery = New System.Data.OleDb.OleDbDataAdapter
        Me.CatalogoSelect = New System.Data.OleDb.OleDbCommand
        Me.CatalogoInsert = New System.Data.OleDb.OleDbCommand
        Me.CatalogoUpdate = New System.Data.OleDb.OleDbCommand
        Me.CatalogoDelete = New System.Data.OleDb.OleDbCommand
        Me.DiametriSelect = New System.Data.OleDb.OleDbCommand
        Me.DiametriInsert = New System.Data.OleDb.OleDbCommand
        Me.DiametriUpdate = New System.Data.OleDb.OleDbCommand
        Me.DiametriDelete = New System.Data.OleDb.OleDbCommand
        Me.FacingsSelect = New System.Data.OleDb.OleDbCommand
        Me.FacingsInsert = New System.Data.OleDb.OleDbCommand
        Me.FacingsUpdate = New System.Data.OleDb.OleDbCommand
        Me.FacingsDelete = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand5 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand5 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand4 = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand4 = New System.Data.OleDb.OleDbCommand
        Me.RatingsSelect = New System.Data.OleDb.OleDbCommand
        Me.RatingsInsert = New System.Data.OleDb.OleDbCommand
        Me.RatingsUpdate = New System.Data.OleDb.OleDbCommand
        Me.RatingsDelete = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand7 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand7 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand6 = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand6 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand8 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand8 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand7 = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand7 = New System.Data.OleDb.OleDbCommand
        Me.AdapterCatalogo = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterDiametri = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterFacings = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterFacValori = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterRatings = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterTabelle = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterTipi = New System.Data.OleDb.OleDbDataAdapter
        Me.AdapterValori = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
        Me.Picture1 = New System.Windows.Forms.PictureBox
        CType(Me.dsFlange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Option1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdVista
        '
        Me.cmdVista.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVista.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVista.Location = New System.Drawing.Point(256, 424)
        Me.cmdVista.Name = "cmdVista"
        Me.cmdVista.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVista.Size = New System.Drawing.Size(52, 20)
        Me.cmdVista.TabIndex = 40
        Me.cmdVista.Text = "==>"
        Me.ToolTip1.SetToolTip(Me.cmdVista, "Apre la finestra di visualizzazione")
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(376, 424)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(64, 20)
        Me.Command2.TabIndex = 32
        Me.Command2.Text = "Ripristina"
        Me.ToolTip1.SetToolTip(Me.Command2, "Ripristina nelle caselle di testo i valori presenti nel database")
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(314, 424)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(57, 20)
        Me.Command1.TabIndex = 31
        Me.Command1.Text = "Salva"
        Me.ToolTip1.SetToolTip(Me.Command1, "Salva nel database i valori imputati nelle caselle di testo")
        '
        'chkReg
        '
        Me.chkReg.Location = New System.Drawing.Point(8, 424)
        Me.chkReg.Name = "chkReg"
        Me.chkReg.Size = New System.Drawing.Size(240, 16)
        Me.chkReg.TabIndex = 47
        Me.chkReg.Text = "Registrazione automatica cambiamenti"
        Me.ToolTip1.SetToolTip(Me.chkReg, "I valori imputati nelle caselle di testo vengono salvati automaticamente nel data" & _
        "base ")
        '
        '_Option1_4
        '
        Me._Option1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_4, CType(4, Short))
        Me._Option1_4.Location = New System.Drawing.Point(413, 24)
        Me._Option1_4.Name = "_Option1_4"
        Me._Option1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_4.Size = New System.Drawing.Size(17, 13)
        Me._Option1_4.TabIndex = 46
        Me._Option1_4.TabStop = True
        '
        '_Option1_3
        '
        Me._Option1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_3, CType(3, Short))
        Me._Option1_3.Location = New System.Drawing.Point(365, 24)
        Me._Option1_3.Name = "_Option1_3"
        Me._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_3.Size = New System.Drawing.Size(17, 13)
        Me._Option1_3.TabIndex = 45
        Me._Option1_3.TabStop = True
        '
        '_Option1_2
        '
        Me._Option1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_2, CType(2, Short))
        Me._Option1_2.Location = New System.Drawing.Point(317, 24)
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Size = New System.Drawing.Size(17, 13)
        Me._Option1_2.TabIndex = 44
        Me._Option1_2.TabStop = True
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_1, CType(1, Short))
        Me._Option1_1.Location = New System.Drawing.Point(269, 24)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(17, 13)
        Me._Option1_1.TabIndex = 43
        Me._Option1_1.TabStop = True
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.SetIndex(Me._Option1_0, CType(0, Short))
        Me._Option1_0.Location = New System.Drawing.Point(221, 24)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(17, 13)
        Me._Option1_0.TabIndex = 42
        Me._Option1_0.TabStop = True
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.Enabled = False
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 42)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(137, 17)
        Me.Check1.TabIndex = 41
        Me.Check1.Text = "Genera DXF"
        '
        'cmbTab
        '
        Me.cmbTab.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTab.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTab.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsFlange, "Tabelle.Descrizione"))
        Me.cmbTab.DataSource = Me.dsFlange.Tabelle
        Me.cmbTab.DisplayMember = "Descrizione"
        Me.cmbTab.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTab.Location = New System.Drawing.Point(43, 20)
        Me.cmbTab.Name = "cmbTab"
        Me.cmbTab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTab.Size = New System.Drawing.Size(154, 21)
        Me.cmbTab.TabIndex = 39
        Me.cmbTab.ValueMember = "Codice"
        '
        'dsFlange
        '
        Me.dsFlange.DataSetName = "DataSet1"
        Me.dsFlange.Locale = New System.Globalization.CultureInfo("it-IT")
        '
        'cmbFacing
        '
        Me.cmbFacing.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFacing.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbFacing.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsFlange, "Facings.Descrizione"))
        Me.cmbFacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacing.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbFacing.Location = New System.Drawing.Point(369, 0)
        Me.cmbFacing.Name = "cmbFacing"
        Me.cmbFacing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbFacing.Size = New System.Drawing.Size(162, 21)
        Me.cmbFacing.TabIndex = 36
        '
        'MinASME
        '
        Me.MinASME.BackColor = System.Drawing.SystemColors.Control
        Me.MinASME.Cursor = System.Windows.Forms.Cursors.Default
        Me.MinASME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MinASME.Location = New System.Drawing.Point(459, 231)
        Me.MinASME.Name = "MinASME"
        Me.MinASME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MinASME.Size = New System.Drawing.Size(69, 20)
        Me.MinASME.TabIndex = 34
        Me.MinASME.Text = "Min. ASME"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(448, 424)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(40, 20)
        Me.Command3.TabIndex = 33
        Me.Command3.Text = "OK"
        '
        '_Text5_0
        '
        Me._Text5_0.AcceptsReturn = True
        Me._Text5_0.AutoSize = False
        Me._Text5_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text5_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text5_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text5_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text5.SetIndex(Me._Text5_0, CType(0, Short))
        Me._Text5_0.Location = New System.Drawing.Point(398, 58)
        Me._Text5_0.MaxLength = 0
        Me._Text5_0.Multiline = True
        Me._Text5_0.Name = "_Text5_0"
        Me._Text5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text5_0.Size = New System.Drawing.Size(52, 20)
        Me._Text5_0.TabIndex = 25
        Me._Text5_0.Text = ""
        Me._Text5_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text4_0
        '
        Me._Text4_0.AcceptsReturn = True
        Me._Text4_0.AutoSize = False
        Me._Text4_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text4_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text4_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text4_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text4.SetIndex(Me._Text4_0, CType(0, Short))
        Me._Text4_0.Location = New System.Drawing.Point(347, 58)
        Me._Text4_0.MaxLength = 0
        Me._Text4_0.Multiline = True
        Me._Text4_0.Name = "_Text4_0"
        Me._Text4_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text4_0.Size = New System.Drawing.Size(52, 20)
        Me._Text4_0.TabIndex = 24
        Me._Text4_0.Text = ""
        Me._Text4_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text3_0
        '
        Me._Text3_0.AcceptsReturn = True
        Me._Text3_0.AutoSize = False
        Me._Text3_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text3_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.SetIndex(Me._Text3_0, CType(0, Short))
        Me._Text3_0.Location = New System.Drawing.Point(297, 58)
        Me._Text3_0.MaxLength = 0
        Me._Text3_0.Multiline = True
        Me._Text3_0.Name = "_Text3_0"
        Me._Text3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_0.Size = New System.Drawing.Size(52, 20)
        Me._Text3_0.TabIndex = 23
        Me._Text3_0.Text = ""
        Me._Text3_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text2_0
        '
        Me._Text2_0.AcceptsReturn = True
        Me._Text2_0.AutoSize = False
        Me._Text2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text2_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.SetIndex(Me._Text2_0, CType(0, Short))
        Me._Text2_0.Location = New System.Drawing.Point(247, 58)
        Me._Text2_0.MaxLength = 0
        Me._Text2_0.Multiline = True
        Me._Text2_0.Name = "_Text2_0"
        Me._Text2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_0.Size = New System.Drawing.Size(52, 20)
        Me._Text2_0.TabIndex = 22
        Me._Text2_0.Text = ""
        Me._Text2_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_0, CType(0, Short))
        Me._Text1_0.Location = New System.Drawing.Point(196, 58)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Multiline = True
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(52, 20)
        Me._Text1_0.TabIndex = 21
        Me._Text1_0.Text = ""
        Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbRating
        '
        Me.cmbRating.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRating.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbRating.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsFlange, "Ratings.Rating"))
        Me.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRating.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbRating.Location = New System.Drawing.Point(243, 0)
        Me.cmbRating.Name = "cmbRating"
        Me.cmbRating.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbRating.Size = New System.Drawing.Size(73, 21)
        Me.cmbRating.TabIndex = 3
        '
        'cmbDiaN
        '
        Me.cmbDiaN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDiaN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDiaN.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsFlange, "Diametri.DiamNom"))
        Me.cmbDiaN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiaN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDiaN.Location = New System.Drawing.Point(101, 0)
        Me.cmbDiaN.Name = "cmbDiaN"
        Me.cmbDiaN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDiaN.Size = New System.Drawing.Size(96, 21)
        Me.cmbDiaN.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(0, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Tabella"
        '
        '_Label3_17
        '
        Me._Label3_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_17, CType(17, Short))
        Me._Label3_17.Location = New System.Drawing.Point(0, 384)
        Me._Label3_17.Name = "_Label3_17"
        Me._Label3_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_17.Size = New System.Drawing.Size(147, 20)
        Me._Label3_17.TabIndex = 37
        Me._Label3_17.Text = "Diametro gradino (interno)"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(324, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(40, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Facing"
        '
        '_lblTipo_4
        '
        Me._lblTipo_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me._lblTipo_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTipo.SetIndex(Me._lblTipo_4, CType(4, Short))
        Me._lblTipo_4.Location = New System.Drawing.Point(398, 38)
        Me._lblTipo_4.Name = "_lblTipo_4"
        Me._lblTipo_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_4.Size = New System.Drawing.Size(51, 20)
        Me._lblTipo_4.TabIndex = 30
        '
        '_lblTipo_3
        '
        Me._lblTipo_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me._lblTipo_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTipo.SetIndex(Me._lblTipo_3, CType(3, Short))
        Me._lblTipo_3.Location = New System.Drawing.Point(347, 38)
        Me._lblTipo_3.Name = "_lblTipo_3"
        Me._lblTipo_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_3.Size = New System.Drawing.Size(51, 20)
        Me._lblTipo_3.TabIndex = 29
        '
        '_lblTipo_2
        '
        Me._lblTipo_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me._lblTipo_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTipo.SetIndex(Me._lblTipo_2, CType(2, Short))
        Me._lblTipo_2.Location = New System.Drawing.Point(297, 38)
        Me._lblTipo_2.Name = "_lblTipo_2"
        Me._lblTipo_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_2.Size = New System.Drawing.Size(51, 20)
        Me._lblTipo_2.TabIndex = 28
        '
        '_lblTipo_1
        '
        Me._lblTipo_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me._lblTipo_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTipo.SetIndex(Me._lblTipo_1, CType(1, Short))
        Me._lblTipo_1.Location = New System.Drawing.Point(247, 38)
        Me._lblTipo_1.Name = "_lblTipo_1"
        Me._lblTipo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_1.Size = New System.Drawing.Size(51, 20)
        Me._lblTipo_1.TabIndex = 27
        '
        '_lblTipo_0
        '
        Me._lblTipo_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me._lblTipo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTipo_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTipo.SetIndex(Me._lblTipo_0, CType(0, Short))
        Me._lblTipo_0.Location = New System.Drawing.Point(196, 38)
        Me._lblTipo_0.Name = "_lblTipo_0"
        Me._lblTipo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTipo_0.Size = New System.Drawing.Size(51, 20)
        Me._lblTipo_0.TabIndex = 26
        '
        '_Label3_16
        '
        Me._Label3_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_16, CType(16, Short))
        Me._Label3_16.Location = New System.Drawing.Point(0, 365)
        Me._Label3_16.Name = "_Label3_16"
        Me._Label3_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_16.Size = New System.Drawing.Size(147, 20)
        Me._Label3_16.TabIndex = 20
        Me._Label3_16.Text = "Peso lordo"
        '
        '_Label3_15
        '
        Me._Label3_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_15, CType(15, Short))
        Me._Label3_15.Location = New System.Drawing.Point(0, 346)
        Me._Label3_15.Name = "_Label3_15"
        Me._Label3_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_15.Size = New System.Drawing.Size(147, 20)
        Me._Label3_15.TabIndex = 19
        Me._Label3_15.Text = "Peso netto"
        '
        '_Label3_14
        '
        Me._Label3_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_14, CType(14, Short))
        Me._Label3_14.Location = New System.Drawing.Point(0, 327)
        Me._Label3_14.Name = "_Label3_14"
        Me._Label3_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_14.Size = New System.Drawing.Size(147, 20)
        Me._Label3_14.TabIndex = 18
        Me._Label3_14.Text = "Peso tiranti"
        '
        '_Label3_13
        '
        Me._Label3_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_13, CType(13, Short))
        Me._Label3_13.Location = New System.Drawing.Point(0, 308)
        Me._Label3_13.Name = "_Label3_13"
        Me._Label3_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_13.Size = New System.Drawing.Size(147, 20)
        Me._Label3_13.TabIndex = 17
        Me._Label3_13.Text = "Diametro fori"
        '
        '_Label3_12
        '
        Me._Label3_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_12, CType(12, Short))
        Me._Label3_12.Location = New System.Drawing.Point(0, 288)
        Me._Label3_12.Name = "_Label3_12"
        Me._Label3_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_12.Size = New System.Drawing.Size(147, 20)
        Me._Label3_12.TabIndex = 16
        Me._Label3_12.Text = "Diametro tiranti"
        '
        '_Label3_11
        '
        Me._Label3_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_11, CType(11, Short))
        Me._Label3_11.Location = New System.Drawing.Point(0, 269)
        Me._Label3_11.Name = "_Label3_11"
        Me._Label3_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_11.Size = New System.Drawing.Size(147, 20)
        Me._Label3_11.TabIndex = 15
        Me._Label3_11.Text = "Numero fori"
        '
        '_Label3_10
        '
        Me._Label3_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_10, CType(10, Short))
        Me._Label3_10.Location = New System.Drawing.Point(0, 250)
        Me._Label3_10.Name = "_Label3_10"
        Me._Label3_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_10.Size = New System.Drawing.Size(147, 20)
        Me._Label3_10.TabIndex = 14
        Me._Label3_10.Text = "Diametro centro fori"
        '
        '_Label3_9
        '
        Me._Label3_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_9, CType(9, Short))
        Me._Label3_9.Location = New System.Drawing.Point(0, 231)
        Me._Label3_9.Name = "_Label3_9"
        Me._Label3_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_9.Size = New System.Drawing.Size(147, 20)
        Me._Label3_9.TabIndex = 13
        Me._Label3_9.Text = "Raggio di raccordo"
        '
        '_Label3_8
        '
        Me._Label3_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_8, CType(8, Short))
        Me._Label3_8.Location = New System.Drawing.Point(0, 212)
        Me._Label3_8.Name = "_Label3_8"
        Me._Label3_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_8.Size = New System.Drawing.Size(147, 20)
        Me._Label3_8.TabIndex = 12
        Me._Label3_8.Text = "Diametro interno"
        '
        '_Label3_7
        '
        Me._Label3_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_7, CType(7, Short))
        Me._Label3_7.Location = New System.Drawing.Point(0, 192)
        Me._Label3_7.Name = "_Label3_7"
        Me._Label3_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_7.Size = New System.Drawing.Size(147, 20)
        Me._Label3_7.TabIndex = 11
        Me._Label3_7.Text = "Spessore tronchetto"
        '
        '_Label3_6
        '
        Me._Label3_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_6, CType(6, Short))
        Me._Label3_6.Location = New System.Drawing.Point(0, 173)
        Me._Label3_6.Name = "_Label3_6"
        Me._Label3_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_6.Size = New System.Drawing.Size(147, 20)
        Me._Label3_6.TabIndex = 10
        Me._Label3_6.Text = "Diametro tronchetto"
        '
        '_Label3_5
        '
        Me._Label3_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_5, CType(5, Short))
        Me._Label3_5.Location = New System.Drawing.Point(0, 154)
        Me._Label3_5.Name = "_Label3_5"
        Me._Label3_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_5.Size = New System.Drawing.Size(147, 20)
        Me._Label3_5.TabIndex = 9
        Me._Label3_5.Text = "Diametro max. codolo"
        '
        '_Label3_4
        '
        Me._Label3_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_4, CType(4, Short))
        Me._Label3_4.Location = New System.Drawing.Point(0, 135)
        Me._Label3_4.Name = "_Label3_4"
        Me._Label3_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_4.Size = New System.Drawing.Size(147, 20)
        Me._Label3_4.TabIndex = 8
        Me._Label3_4.Text = "Altezza flangia"
        '
        '_Label3_3
        '
        Me._Label3_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_3, CType(3, Short))
        Me._Label3_3.Location = New System.Drawing.Point(0, 116)
        Me._Label3_3.Name = "_Label3_3"
        Me._Label3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_3.Size = New System.Drawing.Size(147, 20)
        Me._Label3_3.TabIndex = 7
        Me._Label3_3.Text = "Spessore gradino"
        '
        '_Label3_2
        '
        Me._Label3_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_2, CType(2, Short))
        Me._Label3_2.Location = New System.Drawing.Point(0, 96)
        Me._Label3_2.Name = "_Label3_2"
        Me._Label3_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_2.Size = New System.Drawing.Size(147, 20)
        Me._Label3_2.TabIndex = 6
        Me._Label3_2.Text = "Diametro gradino (esterno)"
        '
        '_Label3_1
        '
        Me._Label3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_1, CType(1, Short))
        Me._Label3_1.Location = New System.Drawing.Point(0, 77)
        Me._Label3_1.Name = "_Label3_1"
        Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_1.Size = New System.Drawing.Size(147, 20)
        Me._Label3_1.TabIndex = 5
        Me._Label3_1.Text = "Spessore flangia"
        '
        '_Label3_0
        '
        Me._Label3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.SetIndex(Me._Label3_0, CType(0, Short))
        Me._Label3_0.Location = New System.Drawing.Point(0, 58)
        Me._Label3_0.Name = "_Label3_0"
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.Size = New System.Drawing.Size(147, 20)
        Me._Label3_0.TabIndex = 4
        Me._Label3_0.Text = "Diametro esterno"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(202, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(46, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Rating"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Diametro nominale"
        '
        'Option1
        '
        '
        'Text1
        '
        '
        'Text2
        '
        '
        'Text3
        '
        '
        'Text4
        '
        '
        'Text5
        '
        '
        'QuerySelect
        '
        Me.QuerySelect.CommandText = "SELECT Altezza, BC, [Catalogo.ID], codDiametro, codRating, codTipo, codTirante, D" & _
        "GradInt, DiamExt, DiamFori, DiamInt, DiamTr, indDiametro, Indice, indRating, ind" & _
        "Tipo, indTirante, indValori, Nfori, Pesolor, Pesonet, PesoTir, Puntatore, Raggio" & _
        ", Rgradint, Spess, SpessGrad, SpessTr, Tabella, Tiranti, V1, V14, V19, V20, [Val" & _
        "ori.ID], X FROM Query1"
        Me.QuerySelect.Connection = Me.cnQuery
        '
        'cnQuery
        '
        Me.cnQuery.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" & _
        "ocking Mode=1;Data Source=""E:\Programmi\Lancio\Arch\Flange.mdb"";Jet OLEDB:Engine" & _
        " Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:" & _
        "SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;" & _
        "Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLED" & _
        "B:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=Fa" & _
        "lse;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1"
        '
        'QueryInsert
        '
        Me.QueryInsert.CommandText = "INSERT INTO Query1(Altezza, BC, codDiametro, codRating, codTipo, codTirante, DGra" & _
        "dInt, DiamExt, DiamFori, DiamInt, DiamTr, indDiametro, Indice, indRating, indTip" & _
        "o, indTirante, indValori, Nfori, Pesolor, Pesonet, PesoTir, Puntatore, Raggio, R" & _
        "gradint, Spess, SpessGrad, SpessTr, Tabella, Tiranti, V1, V14, V19, V20, X) VALU" & _
        "ES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?" & _
        ", ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.QueryInsert.Connection = Me.cnQuery
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Altezza", System.Data.OleDb.OleDbType.Single, 0, "Altezza"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("BC", System.Data.OleDb.OleDbType.Single, 0, "BC"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, "codDiametro"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codRating", System.Data.OleDb.OleDbType.SmallInt, 0, "codRating"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "codTipo"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTirante", System.Data.OleDb.OleDbType.SmallInt, 0, "codTirante"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("DGradInt", System.Data.OleDb.OleDbType.Single, 0, "DGradInt"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamExt", System.Data.OleDb.OleDbType.Single, 0, "DiamExt"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamFori", System.Data.OleDb.OleDbType.Single, 0, "DiamFori"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamInt", System.Data.OleDb.OleDbType.Single, 0, "DiamInt"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamTr", System.Data.OleDb.OleDbType.Single, 0, "DiamTr"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, "indDiametro"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indRating", System.Data.OleDb.OleDbType.SmallInt, 0, "indRating"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "indTipo"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTirante", System.Data.OleDb.OleDbType.Integer, 0, "indTirante"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indValori", System.Data.OleDb.OleDbType.Integer, 0, "indValori"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Nfori", System.Data.OleDb.OleDbType.Single, 0, "Nfori"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pesolor", System.Data.OleDb.OleDbType.Single, 0, "Pesolor"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pesonet", System.Data.OleDb.OleDbType.Single, 0, "Pesonet"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("PesoTir", System.Data.OleDb.OleDbType.Single, 0, "PesoTir"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Puntatore", System.Data.OleDb.OleDbType.Integer, 0, "Puntatore"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Raggio", System.Data.OleDb.OleDbType.Single, 0, "Raggio"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rgradint", System.Data.OleDb.OleDbType.Single, 0, "Rgradint"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Spess", System.Data.OleDb.OleDbType.Single, 0, "Spess"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("SpessGrad", System.Data.OleDb.OleDbType.Single, 0, "SpessGrad"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("SpessTr", System.Data.OleDb.OleDbType.Single, 0, "SpessTr"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, "Tabella"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tiranti", System.Data.OleDb.OleDbType.VarWChar, 10, "Tiranti"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("V1", System.Data.OleDb.OleDbType.Single, 0, "V1"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("V14", System.Data.OleDb.OleDbType.Single, 0, "V14"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("V19", System.Data.OleDb.OleDbType.Single, 0, "V19"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("V20", System.Data.OleDb.OleDbType.Single, 0, "V20"))
        Me.QueryInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("X", System.Data.OleDb.OleDbType.Single, 0, "X"))
        '
        'AdapterQuery
        '
        Me.AdapterQuery.InsertCommand = Me.QueryInsert
        Me.AdapterQuery.SelectCommand = Me.QuerySelect
        Me.AdapterQuery.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Query1", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Altezza", "Altezza"), New System.Data.Common.DataColumnMapping("BC", "BC"), New System.Data.Common.DataColumnMapping("Catalogo.ID", "Catalogo.ID"), New System.Data.Common.DataColumnMapping("codDiametro", "codDiametro"), New System.Data.Common.DataColumnMapping("codRating", "codRating"), New System.Data.Common.DataColumnMapping("codTipo", "codTipo"), New System.Data.Common.DataColumnMapping("codTirante", "codTirante"), New System.Data.Common.DataColumnMapping("DGradInt", "DGradInt"), New System.Data.Common.DataColumnMapping("DiamExt", "DiamExt"), New System.Data.Common.DataColumnMapping("DiamFori", "DiamFori"), New System.Data.Common.DataColumnMapping("DiamInt", "DiamInt"), New System.Data.Common.DataColumnMapping("DiamTr", "DiamTr"), New System.Data.Common.DataColumnMapping("indDiametro", "indDiametro"), New System.Data.Common.DataColumnMapping("Indice", "Indice"), New System.Data.Common.DataColumnMapping("indRating", "indRating"), New System.Data.Common.DataColumnMapping("indTipo", "indTipo"), New System.Data.Common.DataColumnMapping("indTirante", "indTirante"), New System.Data.Common.DataColumnMapping("indValori", "indValori"), New System.Data.Common.DataColumnMapping("Nfori", "Nfori"), New System.Data.Common.DataColumnMapping("Pesolor", "Pesolor"), New System.Data.Common.DataColumnMapping("Pesonet", "Pesonet"), New System.Data.Common.DataColumnMapping("PesoTir", "PesoTir"), New System.Data.Common.DataColumnMapping("Puntatore", "Puntatore"), New System.Data.Common.DataColumnMapping("Raggio", "Raggio"), New System.Data.Common.DataColumnMapping("Rgradint", "Rgradint"), New System.Data.Common.DataColumnMapping("Spess", "Spess"), New System.Data.Common.DataColumnMapping("SpessGrad", "SpessGrad"), New System.Data.Common.DataColumnMapping("SpessTr", "SpessTr"), New System.Data.Common.DataColumnMapping("Tabella", "Tabella"), New System.Data.Common.DataColumnMapping("Tiranti", "Tiranti"), New System.Data.Common.DataColumnMapping("V1", "V1"), New System.Data.Common.DataColumnMapping("V14", "V14"), New System.Data.Common.DataColumnMapping("V19", "V19"), New System.Data.Common.DataColumnMapping("V20", "V20"), New System.Data.Common.DataColumnMapping("Valori.ID", "Valori.ID"), New System.Data.Common.DataColumnMapping("X", "X")})})
        '
        'CatalogoSelect
        '
        Me.CatalogoSelect.CommandText = "SELECT codDiametro, codRating, codTipo, codTirante, ID, indDiametro, indRating, i" & _
        "ndTipo, indTirante, indValori, Tabella FROM Catalogo"
        Me.CatalogoSelect.Connection = Me.cnQuery
        '
        'CatalogoInsert
        '
        Me.CatalogoInsert.CommandText = "INSERT INTO Catalogo(codDiametro, codRating, codTipo, codTirante, indDiametro, in" & _
        "dRating, indTipo, indTirante, indValori, Tabella) VALUES (?, ?, ?, ?, ?, ?, ?, ?" & _
        ", ?, ?)"
        Me.CatalogoInsert.Connection = Me.cnQuery
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, "codDiametro"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codRating", System.Data.OleDb.OleDbType.SmallInt, 0, "codRating"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "codTipo"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTirante", System.Data.OleDb.OleDbType.SmallInt, 0, "codTirante"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, "indDiametro"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indRating", System.Data.OleDb.OleDbType.SmallInt, 0, "indRating"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "indTipo"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTirante", System.Data.OleDb.OleDbType.Integer, 0, "indTirante"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("indValori", System.Data.OleDb.OleDbType.Integer, 0, "indValori"))
        Me.CatalogoInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, "Tabella"))
        '
        'CatalogoUpdate
        '
        Me.CatalogoUpdate.CommandText = "UPDATE Catalogo SET codDiametro = ?, codRating = ?, codTipo = ?, codTirante = ?, " & _
        "indDiametro = ?, indRating = ?, indTipo = ?, indTirante = ?, indValori = ?, Tabe" & _
        "lla = ? WHERE (ID = ?) AND (Tabella = ? OR ? IS NULL AND Tabella IS NULL) AND (c" & _
        "odDiametro = ? OR ? IS NULL AND codDiametro IS NULL) AND (codRating = ? OR ? IS " & _
        "NULL AND codRating IS NULL) AND (codTipo = ? OR ? IS NULL AND codTipo IS NULL) A" & _
        "ND (codTirante = ? OR ? IS NULL AND codTirante IS NULL) AND (indDiametro = ? OR " & _
        "? IS NULL AND indDiametro IS NULL) AND (indRating = ? OR ? IS NULL AND indRating" & _
        " IS NULL) AND (indTipo = ? OR ? IS NULL AND indTipo IS NULL) AND (indTirante = ?" & _
        " OR ? IS NULL AND indTirante IS NULL) AND (indValori = ? OR ? IS NULL AND indVal" & _
        "ori IS NULL)"
        Me.CatalogoUpdate.Connection = Me.cnQuery
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("codDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, "codDiametro"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("codRating", System.Data.OleDb.OleDbType.SmallInt, 0, "codRating"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "codTipo"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTirante", System.Data.OleDb.OleDbType.SmallInt, 0, "codTirante"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("indDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, "indDiametro"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("indRating", System.Data.OleDb.OleDbType.SmallInt, 0, "indRating"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "indTipo"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTirante", System.Data.OleDb.OleDbType.Integer, 0, "indTirante"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("indValori", System.Data.OleDb.OleDbType.Integer, 0, "indValori"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, "Tabella"))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiametro1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTirante", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTirante1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiametro1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTirante", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTirante1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indValori", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indValori", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indValori1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indValori", System.Data.DataRowVersion.Original, Nothing))
        '
        'CatalogoDelete
        '
        Me.CatalogoDelete.CommandText = "DELETE FROM Catalogo WHERE (ID = ?) AND (Tabella = ? OR ? IS NULL AND Tabella IS " & _
        "NULL) AND (codDiametro = ? OR ? IS NULL AND codDiametro IS NULL) AND (codRating " & _
        "= ? OR ? IS NULL AND codRating IS NULL) AND (codTipo = ? OR ? IS NULL AND codTip" & _
        "o IS NULL) AND (codTirante = ? OR ? IS NULL AND codTirante IS NULL) AND (indDiam" & _
        "etro = ? OR ? IS NULL AND indDiametro IS NULL) AND (indRating = ? OR ? IS NULL A" & _
        "ND indRating IS NULL) AND (indTipo = ? OR ? IS NULL AND indTipo IS NULL) AND (in" & _
        "dTirante = ? OR ? IS NULL AND indTirante IS NULL) AND (indValori = ? OR ? IS NUL" & _
        "L AND indValori IS NULL)"
        Me.CatalogoDelete.Connection = Me.cnQuery
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiametro1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTirante", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTirante1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiametro", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiametro1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiametro", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTirante", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTirante1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTirante", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indValori", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indValori", System.Data.DataRowVersion.Original, Nothing))
        Me.CatalogoDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indValori1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indValori", System.Data.DataRowVersion.Original, Nothing))
        '
        'DiametriSelect
        '
        Me.DiametriSelect.CommandText = "SELECT Codice, DiamNom, ID, Indice FROM Diametri"
        Me.DiametriSelect.Connection = Me.cnQuery
        '
        'DiametriInsert
        '
        Me.DiametriInsert.CommandText = "INSERT INTO Diametri(Codice, DiamNom, Indice) VALUES (?, ?, ?)"
        Me.DiametriInsert.Connection = Me.cnQuery
        Me.DiametriInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.DiametriInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamNom", System.Data.OleDb.OleDbType.VarWChar, 10, "DiamNom"))
        Me.DiametriInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        '
        'DiametriUpdate
        '
        Me.DiametriUpdate.CommandText = "UPDATE Diametri SET Codice = ?, DiamNom = ?, Indice = ? WHERE (ID = ?) AND (Codic" & _
        "e = ? OR ? IS NULL AND Codice IS NULL) AND (DiamNom = ? OR ? IS NULL AND DiamNom" & _
        " IS NULL) AND (Indice = ? OR ? IS NULL AND Indice IS NULL)"
        Me.DiametriUpdate.Connection = Me.cnQuery
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamNom", System.Data.OleDb.OleDbType.VarWChar, 10, "DiamNom"))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamNom", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamNom", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamNom1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamNom", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        '
        'DiametriDelete
        '
        Me.DiametriDelete.CommandText = "DELETE FROM Diametri WHERE (ID = ?) AND (Codice = ? OR ? IS NULL AND Codice IS NU" & _
        "LL) AND (DiamNom = ? OR ? IS NULL AND DiamNom IS NULL) AND (Indice = ? OR ? IS N" & _
        "ULL AND Indice IS NULL)"
        Me.DiametriDelete.Connection = Me.cnQuery
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamNom", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamNom", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamNom1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamNom", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.DiametriDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        '
        'FacingsSelect
        '
        Me.FacingsSelect.CommandText = "SELECT Codice, Descrizione, ID, Indice FROM Facings"
        Me.FacingsSelect.Connection = Me.cnQuery
        '
        'FacingsInsert
        '
        Me.FacingsInsert.CommandText = "INSERT INTO Facings(Codice, Descrizione, Indice) VALUES (?, ?, ?)"
        Me.FacingsInsert.Connection = Me.cnQuery
        Me.FacingsInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.FacingsInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Descrizione", System.Data.OleDb.OleDbType.VarWChar, 20, "Descrizione"))
        Me.FacingsInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        '
        'FacingsUpdate
        '
        Me.FacingsUpdate.CommandText = "UPDATE Facings SET Codice = ?, Descrizione = ?, Indice = ? WHERE (ID = ?) AND (Co" & _
        "dice = ? OR ? IS NULL AND Codice IS NULL) AND (Descrizione = ? OR ? IS NULL AND " & _
        "Descrizione IS NULL) AND (Indice = ? OR ? IS NULL AND Indice IS NULL)"
        Me.FacingsUpdate.Connection = Me.cnQuery
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Descrizione", System.Data.OleDb.OleDbType.VarWChar, 20, "Descrizione"))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        '
        'FacingsDelete
        '
        Me.FacingsDelete.CommandText = "DELETE FROM Facings WHERE (ID = ?) AND (Codice = ? OR ? IS NULL AND Codice IS NUL" & _
        "L) AND (Descrizione = ? OR ? IS NULL AND Descrizione IS NULL) AND (Indice = ? OR" & _
        " ? IS NULL AND Indice IS NULL)"
        Me.FacingsDelete.Connection = Me.cnQuery
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.FacingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbSelectCommand5
        '
        Me.OleDbSelectCommand5.CommandText = "SELECT codDiam, codRating, codTipo, H, ID, indDiam, indFacing, indRating, indTipo" & _
        ", Re, Ri, Tabella FROM FacValori"
        Me.OleDbSelectCommand5.Connection = Me.cnQuery
        '
        'OleDbInsertCommand5
        '
        Me.OleDbInsertCommand5.CommandText = "INSERT INTO FacValori(codDiam, codRating, codTipo, H, indDiam, indFacing, indRati" & _
        "ng, indTipo, Re, Ri, Tabella) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand5.Connection = Me.cnQuery
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("codDiam", System.Data.OleDb.OleDbType.SmallInt, 0, "codDiam"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("codRating", System.Data.OleDb.OleDbType.SmallInt, 0, "codRating"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "codTipo"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("H", System.Data.OleDb.OleDbType.Single, 0, "H"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("indDiam", System.Data.OleDb.OleDbType.SmallInt, 0, "indDiam"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("indFacing", System.Data.OleDb.OleDbType.SmallInt, 0, "indFacing"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("indRating", System.Data.OleDb.OleDbType.SmallInt, 0, "indRating"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "indTipo"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("Re", System.Data.OleDb.OleDbType.Single, 0, "Re"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("Ri", System.Data.OleDb.OleDbType.Single, 0, "Ri"))
        Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, "Tabella"))
        '
        'OleDbUpdateCommand4
        '
        Me.OleDbUpdateCommand4.CommandText = "UPDATE FacValori SET codDiam = ?, codRating = ?, codTipo = ?, H = ?, indDiam = ?," & _
        " indFacing = ?, indRating = ?, indTipo = ?, Re = ?, Ri = ?, Tabella = ? WHERE (I" & _
        "D = ?) AND (H = ? OR ? IS NULL AND H IS NULL) AND (Re = ? OR ? IS NULL AND Re IS" & _
        " NULL) AND (Ri = ? OR ? IS NULL AND Ri IS NULL) AND (Tabella = ? OR ? IS NULL AN" & _
        "D Tabella IS NULL) AND (codDiam = ? OR ? IS NULL AND codDiam IS NULL) AND (codRa" & _
        "ting = ? OR ? IS NULL AND codRating IS NULL) AND (codTipo = ? OR ? IS NULL AND c" & _
        "odTipo IS NULL) AND (indDiam = ? OR ? IS NULL AND indDiam IS NULL) AND (indFacin" & _
        "g = ? OR ? IS NULL AND indFacing IS NULL) AND (indRating = ? OR ? IS NULL AND in" & _
        "dRating IS NULL) AND (indTipo = ? OR ? IS NULL AND indTipo IS NULL)"
        Me.OleDbUpdateCommand4.Connection = Me.cnQuery
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("codDiam", System.Data.OleDb.OleDbType.SmallInt, 0, "codDiam"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("codRating", System.Data.OleDb.OleDbType.SmallInt, 0, "codRating"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "codTipo"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("H", System.Data.OleDb.OleDbType.Single, 0, "H"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("indDiam", System.Data.OleDb.OleDbType.SmallInt, 0, "indDiam"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("indFacing", System.Data.OleDb.OleDbType.SmallInt, 0, "indFacing"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("indRating", System.Data.OleDb.OleDbType.SmallInt, 0, "indRating"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, "indTipo"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Re", System.Data.OleDb.OleDbType.Single, 0, "Re"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Ri", System.Data.OleDb.OleDbType.Single, 0, "Ri"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, "Tabella"))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_H", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "H", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_H1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "H", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Re", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Re", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Re1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Re", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ri", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ri", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ri1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ri", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiam", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiam1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiam", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiam1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indFacing", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indFacing", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indFacing1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indFacing", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDeleteCommand4
        '
        Me.OleDbDeleteCommand4.CommandText = "DELETE FROM FacValori WHERE (ID = ?) AND (H = ? OR ? IS NULL AND H IS NULL) AND (" & _
        "Re = ? OR ? IS NULL AND Re IS NULL) AND (Ri = ? OR ? IS NULL AND Ri IS NULL) AND" & _
        " (Tabella = ? OR ? IS NULL AND Tabella IS NULL) AND (codDiam = ? OR ? IS NULL AN" & _
        "D codDiam IS NULL) AND (codRating = ? OR ? IS NULL AND codRating IS NULL) AND (c" & _
        "odTipo = ? OR ? IS NULL AND codTipo IS NULL) AND (indDiam = ? OR ? IS NULL AND i" & _
        "ndDiam IS NULL) AND (indFacing = ? OR ? IS NULL AND indFacing IS NULL) AND (indR" & _
        "ating = ? OR ? IS NULL AND indRating IS NULL) AND (indTipo = ? OR ? IS NULL AND " & _
        "indTipo IS NULL)"
        Me.OleDbDeleteCommand4.Connection = Me.cnQuery
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_H", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "H", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_H1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "H", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Re", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Re", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Re1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Re", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ri", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ri", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ri1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ri", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tabella1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tabella", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiam", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codDiam1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_codTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "codTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiam", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indDiam1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indDiam", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indFacing", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indFacing", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indFacing1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indFacing", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indRating1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indRating", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_indTipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "indTipo", System.Data.DataRowVersion.Original, Nothing))
        '
        'RatingsSelect
        '
        Me.RatingsSelect.CommandText = "SELECT ID, Indice, Rating, Tipo FROM Ratings"
        Me.RatingsSelect.Connection = Me.cnQuery
        '
        'RatingsInsert
        '
        Me.RatingsInsert.CommandText = "INSERT INTO Ratings(Indice, Rating, Tipo) VALUES (?, ?, ?)"
        Me.RatingsInsert.Connection = Me.cnQuery
        Me.RatingsInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.RatingsInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rating", System.Data.OleDb.OleDbType.VarWChar, 10, "Rating"))
        Me.RatingsInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tipo", System.Data.OleDb.OleDbType.SmallInt, 0, "Tipo"))
        '
        'RatingsUpdate
        '
        Me.RatingsUpdate.CommandText = "UPDATE Ratings SET Indice = ?, Rating = ?, Tipo = ? WHERE (ID = ?) AND (Indice = " & _
        "? OR ? IS NULL AND Indice IS NULL) AND (Rating = ? OR ? IS NULL AND Rating IS NU" & _
        "LL) AND (Tipo = ? OR ? IS NULL AND Tipo IS NULL)"
        Me.RatingsUpdate.Connection = Me.cnQuery
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rating", System.Data.OleDb.OleDbType.VarWChar, 10, "Rating"))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tipo", System.Data.OleDb.OleDbType.SmallInt, 0, "Tipo"))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rating", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rating", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rating1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rating", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        '
        'RatingsDelete
        '
        Me.RatingsDelete.CommandText = "DELETE FROM Ratings WHERE (ID = ?) AND (Indice = ? OR ? IS NULL AND Indice IS NUL" & _
        "L) AND (Rating = ? OR ? IS NULL AND Rating IS NULL) AND (Tipo = ? OR ? IS NULL A" & _
        "ND Tipo IS NULL)"
        Me.RatingsDelete.Connection = Me.cnQuery
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rating", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rating", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rating1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rating", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        Me.RatingsDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbSelectCommand7
        '
        Me.OleDbSelectCommand7.CommandText = "SELECT Codice, Descrizione, ID FROM Tabelle"
        Me.OleDbSelectCommand7.Connection = Me.cnQuery
        '
        'OleDbInsertCommand7
        '
        Me.OleDbInsertCommand7.CommandText = "INSERT INTO Tabelle(Codice, Descrizione) VALUES (?, ?)"
        Me.OleDbInsertCommand7.Connection = Me.cnQuery
        Me.OleDbInsertCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.OleDbInsertCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Descrizione", System.Data.OleDb.OleDbType.VarWChar, 50, "Descrizione"))
        '
        'OleDbUpdateCommand6
        '
        Me.OleDbUpdateCommand6.CommandText = "UPDATE Tabelle SET Codice = ?, Descrizione = ? WHERE (ID = ?) AND (Codice = ? OR " & _
        "? IS NULL AND Codice IS NULL) AND (Descrizione = ? OR ? IS NULL AND Descrizione " & _
        "IS NULL)"
        Me.OleDbUpdateCommand6.Connection = Me.cnQuery
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Descrizione", System.Data.OleDb.OleDbType.VarWChar, 50, "Descrizione"))
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDeleteCommand6
        '
        Me.OleDbDeleteCommand6.CommandText = "DELETE FROM Tabelle WHERE (ID = ?) AND (Codice = ? OR ? IS NULL AND Codice IS NUL" & _
        "L) AND (Descrizione = ? OR ? IS NULL AND Descrizione IS NULL)"
        Me.OleDbDeleteCommand6.Connection = Me.cnQuery
        Me.OleDbDeleteCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Descrizione1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Descrizione", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbSelectCommand8
        '
        Me.OleDbSelectCommand8.CommandText = "SELECT Codice, ID, Indice, Tipo FROM Tipi"
        Me.OleDbSelectCommand8.Connection = Me.cnQuery
        '
        'OleDbInsertCommand8
        '
        Me.OleDbInsertCommand8.CommandText = "INSERT INTO Tipi(Codice, Indice, Tipo) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand8.Connection = Me.cnQuery
        Me.OleDbInsertCommand8.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.OleDbInsertCommand8.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.OleDbInsertCommand8.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tipo", System.Data.OleDb.OleDbType.VarWChar, 10, "Tipo"))
        '
        'OleDbUpdateCommand7
        '
        Me.OleDbUpdateCommand7.CommandText = "UPDATE Tipi SET Codice = ?, Indice = ?, Tipo = ? WHERE (ID = ?) AND (Codice = ? O" & _
        "R ? IS NULL AND Codice IS NULL) AND (Indice = ? OR ? IS NULL AND Indice IS NULL)" & _
        " AND (Tipo = ? OR ? IS NULL AND Tipo IS NULL)"
        Me.OleDbUpdateCommand7.Connection = Me.cnQuery
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Codice", System.Data.OleDb.OleDbType.SmallInt, 0, "Codice"))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tipo", System.Data.OleDb.OleDbType.VarWChar, 10, "Tipo"))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDeleteCommand7
        '
        Me.OleDbDeleteCommand7.CommandText = "DELETE FROM Tipi WHERE (ID = ?) AND (Codice = ? OR ? IS NULL AND Codice IS NULL) " & _
        "AND (Indice = ? OR ? IS NULL AND Indice IS NULL) AND (Tipo = ? OR ? IS NULL AND " & _
        "Tipo IS NULL)"
        Me.OleDbDeleteCommand7.Connection = Me.cnQuery
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Codice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Codice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand7.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tipo1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tipo", System.Data.DataRowVersion.Original, Nothing))
        '
        'AdapterCatalogo
        '
        Me.AdapterCatalogo.DeleteCommand = Me.CatalogoDelete
        Me.AdapterCatalogo.InsertCommand = Me.CatalogoInsert
        Me.AdapterCatalogo.SelectCommand = Me.CatalogoSelect
        Me.AdapterCatalogo.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Catalogo", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("codDiametro", "codDiametro"), New System.Data.Common.DataColumnMapping("codRating", "codRating"), New System.Data.Common.DataColumnMapping("codTipo", "codTipo"), New System.Data.Common.DataColumnMapping("codTirante", "codTirante"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("indDiametro", "indDiametro"), New System.Data.Common.DataColumnMapping("indRating", "indRating"), New System.Data.Common.DataColumnMapping("indTipo", "indTipo"), New System.Data.Common.DataColumnMapping("indTirante", "indTirante"), New System.Data.Common.DataColumnMapping("indValori", "indValori"), New System.Data.Common.DataColumnMapping("Tabella", "Tabella")})})
        Me.AdapterCatalogo.UpdateCommand = Me.CatalogoUpdate
        '
        'AdapterDiametri
        '
        Me.AdapterDiametri.DeleteCommand = Me.DiametriDelete
        Me.AdapterDiametri.InsertCommand = Me.DiametriInsert
        Me.AdapterDiametri.SelectCommand = Me.DiametriSelect
        Me.AdapterDiametri.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Diametri", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Codice", "Codice"), New System.Data.Common.DataColumnMapping("DiamNom", "DiamNom"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Indice", "Indice")})})
        Me.AdapterDiametri.UpdateCommand = Me.DiametriUpdate
        '
        'AdapterFacings
        '
        Me.AdapterFacings.DeleteCommand = Me.FacingsDelete
        Me.AdapterFacings.InsertCommand = Me.FacingsInsert
        Me.AdapterFacings.SelectCommand = Me.FacingsSelect
        Me.AdapterFacings.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Facings", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Codice", "Codice"), New System.Data.Common.DataColumnMapping("Descrizione", "Descrizione"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Indice", "Indice")})})
        Me.AdapterFacings.UpdateCommand = Me.FacingsUpdate
        '
        'AdapterFacValori
        '
        Me.AdapterFacValori.DeleteCommand = Me.OleDbDeleteCommand4
        Me.AdapterFacValori.InsertCommand = Me.OleDbInsertCommand5
        Me.AdapterFacValori.SelectCommand = Me.OleDbSelectCommand5
        Me.AdapterFacValori.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "FacValori", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("codDiam", "codDiam"), New System.Data.Common.DataColumnMapping("codRating", "codRating"), New System.Data.Common.DataColumnMapping("codTipo", "codTipo"), New System.Data.Common.DataColumnMapping("H", "H"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("indDiam", "indDiam"), New System.Data.Common.DataColumnMapping("indFacing", "indFacing"), New System.Data.Common.DataColumnMapping("indRating", "indRating"), New System.Data.Common.DataColumnMapping("indTipo", "indTipo"), New System.Data.Common.DataColumnMapping("Re", "Re"), New System.Data.Common.DataColumnMapping("Ri", "Ri"), New System.Data.Common.DataColumnMapping("Tabella", "Tabella")})})
        Me.AdapterFacValori.UpdateCommand = Me.OleDbUpdateCommand4
        '
        'AdapterRatings
        '
        Me.AdapterRatings.DeleteCommand = Me.RatingsDelete
        Me.AdapterRatings.InsertCommand = Me.RatingsInsert
        Me.AdapterRatings.SelectCommand = Me.RatingsSelect
        Me.AdapterRatings.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Ratings", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Indice", "Indice"), New System.Data.Common.DataColumnMapping("Rating", "Rating"), New System.Data.Common.DataColumnMapping("Tipo", "Tipo")})})
        Me.AdapterRatings.UpdateCommand = Me.RatingsUpdate
        '
        'AdapterTabelle
        '
        Me.AdapterTabelle.DeleteCommand = Me.OleDbDeleteCommand6
        Me.AdapterTabelle.InsertCommand = Me.OleDbInsertCommand7
        Me.AdapterTabelle.SelectCommand = Me.OleDbSelectCommand7
        Me.AdapterTabelle.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Tabelle", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Codice", "Codice"), New System.Data.Common.DataColumnMapping("Descrizione", "Descrizione"), New System.Data.Common.DataColumnMapping("ID", "ID")})})
        Me.AdapterTabelle.UpdateCommand = Me.OleDbUpdateCommand6
        '
        'AdapterTipi
        '
        Me.AdapterTipi.DeleteCommand = Me.OleDbDeleteCommand7
        Me.AdapterTipi.InsertCommand = Me.OleDbInsertCommand8
        Me.AdapterTipi.SelectCommand = Me.OleDbSelectCommand8
        Me.AdapterTipi.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Tipi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Codice", "Codice"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Indice", "Indice"), New System.Data.Common.DataColumnMapping("Tipo", "Tipo")})})
        Me.AdapterTipi.UpdateCommand = Me.OleDbUpdateCommand7
        '
        'AdapterValori
        '
        Me.AdapterValori.DeleteCommand = Me.OleDbDeleteCommand1
        Me.AdapterValori.InsertCommand = Me.OleDbInsertCommand1
        Me.AdapterValori.SelectCommand = Me.OleDbSelectCommand1
        Me.AdapterValori.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Valori", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Altezza", "Altezza"), New System.Data.Common.DataColumnMapping("BC", "BC"), New System.Data.Common.DataColumnMapping("DGradInt", "DGradInt"), New System.Data.Common.DataColumnMapping("DiamExt", "DiamExt"), New System.Data.Common.DataColumnMapping("DiamFori", "DiamFori"), New System.Data.Common.DataColumnMapping("DiamInt", "DiamInt"), New System.Data.Common.DataColumnMapping("DiamTr", "DiamTr"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Indice", "Indice"), New System.Data.Common.DataColumnMapping("Nfori", "Nfori"), New System.Data.Common.DataColumnMapping("Pesolor", "Pesolor"), New System.Data.Common.DataColumnMapping("Pesonet", "Pesonet"), New System.Data.Common.DataColumnMapping("PesoTir", "PesoTir"), New System.Data.Common.DataColumnMapping("Puntatore", "Puntatore"), New System.Data.Common.DataColumnMapping("Raggio", "Raggio"), New System.Data.Common.DataColumnMapping("Rgradint", "Rgradint"), New System.Data.Common.DataColumnMapping("Spess", "Spess"), New System.Data.Common.DataColumnMapping("SpessGrad", "SpessGrad"), New System.Data.Common.DataColumnMapping("SpessTr", "SpessTr"), New System.Data.Common.DataColumnMapping("Tiranti", "Tiranti"), New System.Data.Common.DataColumnMapping("V1", "V1"), New System.Data.Common.DataColumnMapping("V14", "V14"), New System.Data.Common.DataColumnMapping("V19", "V19"), New System.Data.Common.DataColumnMapping("V20", "V20"), New System.Data.Common.DataColumnMapping("X", "X")})})
        Me.AdapterValori.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM Valori WHERE (ID = ?) AND (Altezza = ? OR ? IS NULL AND Altezza IS NU" & _
        "LL) AND (BC = ? OR ? IS NULL AND BC IS NULL) AND (DGradInt = ? OR ? IS NULL AND " & _
        "DGradInt IS NULL) AND (DiamExt = ? OR ? IS NULL AND DiamExt IS NULL) AND (DiamFo" & _
        "ri = ? OR ? IS NULL AND DiamFori IS NULL) AND (DiamInt = ? OR ? IS NULL AND Diam" & _
        "Int IS NULL) AND (DiamTr = ? OR ? IS NULL AND DiamTr IS NULL) AND (Indice = ? OR" & _
        " ? IS NULL AND Indice IS NULL) AND (Nfori = ? OR ? IS NULL AND Nfori IS NULL) AN" & _
        "D (PesoTir = ? OR ? IS NULL AND PesoTir IS NULL) AND (Pesolor = ? OR ? IS NULL A" & _
        "ND Pesolor IS NULL) AND (Pesonet = ? OR ? IS NULL AND Pesonet IS NULL) AND (Punt" & _
        "atore = ? OR ? IS NULL AND Puntatore IS NULL) AND (Raggio = ? OR ? IS NULL AND R" & _
        "aggio IS NULL) AND (Rgradint = ? OR ? IS NULL AND Rgradint IS NULL) AND (Spess =" & _
        " ? OR ? IS NULL AND Spess IS NULL) AND (SpessGrad = ? OR ? IS NULL AND SpessGrad" & _
        " IS NULL) AND (SpessTr = ? OR ? IS NULL AND SpessTr IS NULL) AND (Tiranti = ? OR" & _
        " ? IS NULL AND Tiranti IS NULL) AND (V1 = ? OR ? IS NULL AND V1 IS NULL) AND (V1" & _
        "4 = ? OR ? IS NULL AND V14 IS NULL) AND (V19 = ? OR ? IS NULL AND V19 IS NULL) A" & _
        "ND (V20 = ? OR ? IS NULL AND V20 IS NULL) AND (X = ? OR ? IS NULL AND X IS NULL)" & _
        ""
        Me.OleDbDeleteCommand1.Connection = Me.cnQuery
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Altezza", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altezza", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Altezza1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altezza", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_BC", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BC", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_BC1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BC", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DGradInt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DGradInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DGradInt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DGradInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamExt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamExt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamExt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamExt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamFori", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamFori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamFori1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamFori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamInt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamInt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamTr", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamTr1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nfori", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nfori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nfori1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nfori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PesoTir", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PesoTir", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PesoTir1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PesoTir", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesolor", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesolor", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesolor1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesolor", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesonet", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesonet", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesonet1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesonet", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Puntatore", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Puntatore", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Puntatore1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Puntatore", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Raggio", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Raggio", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Raggio1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Raggio", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rgradint", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rgradint", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rgradint1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rgradint", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Spess", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Spess", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Spess1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Spess", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessGrad", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessGrad", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessGrad1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessGrad", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessTr", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessTr1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tiranti", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tiranti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tiranti1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tiranti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V11", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V14", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V14", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V141", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V14", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V19", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V19", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V191", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V19", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V20", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V20", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V201", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V20", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_X", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "X", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_X1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "X", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO Valori(Altezza, BC, DGradInt, DiamExt, DiamFori, DiamInt, DiamTr, Ind" & _
        "ice, Nfori, Pesolor, Pesonet, PesoTir, Puntatore, Raggio, Rgradint, Spess, Spess" & _
        "Grad, SpessTr, Tiranti, V1, V14, V19, V20, X) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?," & _
        " ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand1.Connection = Me.cnQuery
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Altezza", System.Data.OleDb.OleDbType.Single, 0, "Altezza"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("BC", System.Data.OleDb.OleDbType.Single, 0, "BC"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DGradInt", System.Data.OleDb.OleDbType.Single, 0, "DGradInt"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamExt", System.Data.OleDb.OleDbType.Single, 0, "DiamExt"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamFori", System.Data.OleDb.OleDbType.Single, 0, "DiamFori"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamInt", System.Data.OleDb.OleDbType.Single, 0, "DiamInt"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamTr", System.Data.OleDb.OleDbType.Single, 0, "DiamTr"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Nfori", System.Data.OleDb.OleDbType.Single, 0, "Nfori"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pesolor", System.Data.OleDb.OleDbType.Single, 0, "Pesolor"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pesonet", System.Data.OleDb.OleDbType.Single, 0, "Pesonet"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("PesoTir", System.Data.OleDb.OleDbType.Single, 0, "PesoTir"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Puntatore", System.Data.OleDb.OleDbType.Integer, 0, "Puntatore"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Raggio", System.Data.OleDb.OleDbType.Single, 0, "Raggio"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rgradint", System.Data.OleDb.OleDbType.Single, 0, "Rgradint"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Spess", System.Data.OleDb.OleDbType.Single, 0, "Spess"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("SpessGrad", System.Data.OleDb.OleDbType.Single, 0, "SpessGrad"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("SpessTr", System.Data.OleDb.OleDbType.Single, 0, "SpessTr"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tiranti", System.Data.OleDb.OleDbType.VarWChar, 10, "Tiranti"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V1", System.Data.OleDb.OleDbType.Single, 0, "V1"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V14", System.Data.OleDb.OleDbType.Single, 0, "V14"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V19", System.Data.OleDb.OleDbType.Single, 0, "V19"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V20", System.Data.OleDb.OleDbType.Single, 0, "V20"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("X", System.Data.OleDb.OleDbType.Single, 0, "X"))
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT Altezza, BC, DGradInt, DiamExt, DiamFori, DiamInt, DiamTr, ID, Indice, Nfo" & _
        "ri, Pesolor, Pesonet, PesoTir, Puntatore, Raggio, Rgradint, Spess, SpessGrad, Sp" & _
        "essTr, Tiranti, V1, V14, V19, V20, X FROM Valori"
        Me.OleDbSelectCommand1.Connection = Me.cnQuery
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = "UPDATE Valori SET Altezza = ?, BC = ?, DGradInt = ?, DiamExt = ?, DiamFori = ?, D" & _
        "iamInt = ?, DiamTr = ?, Indice = ?, Nfori = ?, Pesolor = ?, Pesonet = ?, PesoTir" & _
        " = ?, Puntatore = ?, Raggio = ?, Rgradint = ?, Spess = ?, SpessGrad = ?, SpessTr" & _
        " = ?, Tiranti = ?, V1 = ?, V14 = ?, V19 = ?, V20 = ?, X = ? WHERE (ID = ?) AND (" & _
        "Altezza = ? OR ? IS NULL AND Altezza IS NULL) AND (BC = ? OR ? IS NULL AND BC IS" & _
        " NULL) AND (DGradInt = ? OR ? IS NULL AND DGradInt IS NULL) AND (DiamExt = ? OR " & _
        "? IS NULL AND DiamExt IS NULL) AND (DiamFori = ? OR ? IS NULL AND DiamFori IS NU" & _
        "LL) AND (DiamInt = ? OR ? IS NULL AND DiamInt IS NULL) AND (DiamTr = ? OR ? IS N" & _
        "ULL AND DiamTr IS NULL) AND (Indice = ? OR ? IS NULL AND Indice IS NULL) AND (Nf" & _
        "ori = ? OR ? IS NULL AND Nfori IS NULL) AND (PesoTir = ? OR ? IS NULL AND PesoTi" & _
        "r IS NULL) AND (Pesolor = ? OR ? IS NULL AND Pesolor IS NULL) AND (Pesonet = ? O" & _
        "R ? IS NULL AND Pesonet IS NULL) AND (Puntatore = ? OR ? IS NULL AND Puntatore I" & _
        "S NULL) AND (Raggio = ? OR ? IS NULL AND Raggio IS NULL) AND (Rgradint = ? OR ? " & _
        "IS NULL AND Rgradint IS NULL) AND (Spess = ? OR ? IS NULL AND Spess IS NULL) AND" & _
        " (SpessGrad = ? OR ? IS NULL AND SpessGrad IS NULL) AND (SpessTr = ? OR ? IS NUL" & _
        "L AND SpessTr IS NULL) AND (Tiranti = ? OR ? IS NULL AND Tiranti IS NULL) AND (V" & _
        "1 = ? OR ? IS NULL AND V1 IS NULL) AND (V14 = ? OR ? IS NULL AND V14 IS NULL) AN" & _
        "D (V19 = ? OR ? IS NULL AND V19 IS NULL) AND (V20 = ? OR ? IS NULL AND V20 IS NU" & _
        "LL) AND (X = ? OR ? IS NULL AND X IS NULL)"
        Me.OleDbUpdateCommand1.Connection = Me.cnQuery
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Altezza", System.Data.OleDb.OleDbType.Single, 0, "Altezza"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("BC", System.Data.OleDb.OleDbType.Single, 0, "BC"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DGradInt", System.Data.OleDb.OleDbType.Single, 0, "DGradInt"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamExt", System.Data.OleDb.OleDbType.Single, 0, "DiamExt"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamFori", System.Data.OleDb.OleDbType.Single, 0, "DiamFori"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamInt", System.Data.OleDb.OleDbType.Single, 0, "DiamInt"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DiamTr", System.Data.OleDb.OleDbType.Single, 0, "DiamTr"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Indice", System.Data.OleDb.OleDbType.SmallInt, 0, "Indice"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Nfori", System.Data.OleDb.OleDbType.Single, 0, "Nfori"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pesolor", System.Data.OleDb.OleDbType.Single, 0, "Pesolor"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pesonet", System.Data.OleDb.OleDbType.Single, 0, "Pesonet"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("PesoTir", System.Data.OleDb.OleDbType.Single, 0, "PesoTir"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Puntatore", System.Data.OleDb.OleDbType.Integer, 0, "Puntatore"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Raggio", System.Data.OleDb.OleDbType.Single, 0, "Raggio"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Rgradint", System.Data.OleDb.OleDbType.Single, 0, "Rgradint"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Spess", System.Data.OleDb.OleDbType.Single, 0, "Spess"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("SpessGrad", System.Data.OleDb.OleDbType.Single, 0, "SpessGrad"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("SpessTr", System.Data.OleDb.OleDbType.Single, 0, "SpessTr"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tiranti", System.Data.OleDb.OleDbType.VarWChar, 10, "Tiranti"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V1", System.Data.OleDb.OleDbType.Single, 0, "V1"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V14", System.Data.OleDb.OleDbType.Single, 0, "V14"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V19", System.Data.OleDb.OleDbType.Single, 0, "V19"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("V20", System.Data.OleDb.OleDbType.Single, 0, "V20"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("X", System.Data.OleDb.OleDbType.Single, 0, "X"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Altezza", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altezza", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Altezza1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Altezza", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_BC", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BC", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_BC1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BC", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DGradInt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DGradInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DGradInt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DGradInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamExt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamExt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamExt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamExt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamFori", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamFori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamFori1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamFori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamInt", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamInt1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamInt", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamTr", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DiamTr1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DiamTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Indice1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Indice", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nfori", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nfori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nfori1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nfori", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PesoTir", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PesoTir", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PesoTir1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PesoTir", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesolor", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesolor", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesolor1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesolor", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesonet", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesonet", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pesonet1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pesonet", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Puntatore", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Puntatore", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Puntatore1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Puntatore", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Raggio", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Raggio", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Raggio1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Raggio", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rgradint", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rgradint", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Rgradint1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Rgradint", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Spess", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Spess", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Spess1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Spess", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessGrad", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessGrad", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessGrad1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessGrad", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessTr", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_SpessTr1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SpessTr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tiranti", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tiranti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Tiranti1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Tiranti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V11", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V14", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V14", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V141", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V14", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V19", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V19", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V191", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V19", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V20", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V20", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_V201", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "V20", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_X", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "X", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_X1", System.Data.OleDb.OleDbType.Single, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "X", System.Data.DataRowVersion.Original, Nothing))
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Window
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Location = New System.Drawing.Point(544, 32)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(352, 395)
        Me.Picture1.TabIndex = 48
        Me.Picture1.TabStop = False
        '
        'frmFlange
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(906, 496)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbTab)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.chkReg)
        Me.Controls.Add(Me._Option1_4)
        Me.Controls.Add(Me._Option1_3)
        Me.Controls.Add(Me._Option1_2)
        Me.Controls.Add(Me._Option1_1)
        Me.Controls.Add(Me._Option1_0)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me.cmdVista)
        Me.Controls.Add(Me.cmbFacing)
        Me.Controls.Add(Me.MinASME)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Text5_0)
        Me.Controls.Add(Me._Text4_0)
        Me.Controls.Add(Me._Text3_0)
        Me.Controls.Add(Me._Text2_0)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me.cmbRating)
        Me.Controls.Add(Me.cmbDiaN)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me._Label3_17)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me._lblTipo_4)
        Me.Controls.Add(Me._lblTipo_3)
        Me.Controls.Add(Me._lblTipo_2)
        Me.Controls.Add(Me._lblTipo_1)
        Me.Controls.Add(Me._lblTipo_0)
        Me.Controls.Add(Me._Label3_16)
        Me.Controls.Add(Me._Label3_15)
        Me.Controls.Add(Me._Label3_14)
        Me.Controls.Add(Me._Label3_13)
        Me.Controls.Add(Me._Label3_12)
        Me.Controls.Add(Me._Label3_11)
        Me.Controls.Add(Me._Label3_10)
        Me.Controls.Add(Me._Label3_9)
        Me.Controls.Add(Me._Label3_8)
        Me.Controls.Add(Me._Label3_7)
        Me.Controls.Add(Me._Label3_6)
        Me.Controls.Add(Me._Label3_5)
        Me.Controls.Add(Me._Label3_4)
        Me.Controls.Add(Me._Label3_3)
        Me.Controls.Add(Me._Label3_2)
        Me.Controls.Add(Me._Label3_1)
        Me.Controls.Add(Me._Label3_0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(78, 51)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFlange"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Libreria flange"
        CType(Me.dsFlange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Option1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    ' Private Shared m_vb6FormDefInstance As frmFlange
    ' Private Shared m_InitializingDefInstance As Boolean
    ' Public Shared Property DefInstance() As frmFlange
    '     Get
    '         If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '             m_InitializingDefInstance = True
    '             m_vb6FormDefInstance = New frmFlange
    '             m_InitializingDefInstance = False
    '         End If
    '         DefInstance = m_vb6FormDefInstance
    '     End Get
    '     Set(ByVal Value As frmFlange)
    '         m_vb6FormDefInstance = Value
    '     End Set
    ' End Property
#End Region
    Private TextArr() As System.Windows.Forms.Control
    Public Annullato As Boolean
    Private Inizializzando As Boolean
    Private Loading As Boolean
    Private nArr As Short
    Private TitQueryOrig() As String = {"Valori.ID", "Indice", "Puntatore", _
    "V1", "DiamExt", "Spess", "DGradInt", "SpessGrad", "Altezza", _
    "X", "DiamTr", "SpessTr", "DiamInt", "Raggio", "BC", "Nfori", "V14", _
    "DiamFori", "PesoTir", "Pesonet", "Pesolor", "V19", "V20", "Rgradint", "Tiranti"}
    Private Const FinestraLarga As Integer = 912
    Private Const FinestraStretta As Integer = 536
    Private Disegnando As Boolean
    Public Sub IniziaBase()
        Dim cString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Inizio.Archdir & "\Flange.mdb" & ";Persist Security Info=False"
        AdapterQuery.SelectCommand.Connection.ConnectionString = cString
        AdapterQuery.Fill(dsFlange)
        AdapterValori.SelectCommand.Connection.ConnectionString = cString
        AdapterValori.Fill(dsFlange, "Valori")
        AdapterCatalogo.SelectCommand.Connection.ConnectionString = cString
        AdapterCatalogo.Fill(dsFlange, "Catalogo")
        AdapterFacValori.SelectCommand.Connection.ConnectionString = cString
        AdapterFacValori.Fill(dsFlange, "FacValori")
        FacValori = dsFlange.FacValori
        AdapterTabelle.SelectCommand.Connection.ConnectionString = cString
        AdapterTabelle.Fill(dsFlange)
        AdapterTipi.SelectCommand.Connection.ConnectionString = cString
        AdapterTipi.Fill(dsFlange)
        Tipi = dsFlange.Tipi
        AdapterDiametri.SelectCommand.Connection.ConnectionString = cString
        AdapterDiametri.Fill(dsFlange)
        Diametri = dsFlange.Diametri
        AdapterRatings.SelectCommand.Connection.ConnectionString = cString
        AdapterRatings.Fill(dsFlange)
        Ratings = dsFlange.Ratings
        AdapterFacings.SelectCommand.Connection.ConnectionString = cString
        AdapterFacings.Fill(dsFlange)
        Facings = dsFlange.Facings
    End Sub
    Private Sub Inizializza()
        Dim txt As System.Windows.Forms.Control = Nothing
        Dim i, k As Short
        Dim strError As String
        IniziaBase()
        dvDiametri = New DataView(Diametri)
        dvDiametri.Sort = "Codice"
        dvFacings = New DataView(Facings)
        dvFacings.Sort = "Codice"
        dvRatings = New DataView(Ratings)
        dvRatings.Sort = "Tipo"
        AggiornaLabels()
        cmbDiaN.Enabled = False
        cmbRating.Enabled = False
        cmbFacing.Enabled = False
        If globFlangia Is Nothing Then globFlangia = New Flangia
        globFlangia.AggTab(Me)
        cmbDiaN.Enabled = True
        cmbRating.Enabled = True
        cmbFacing.Enabled = True
        RetrieveRECf()
        For i = 1 To 5
            For k = 0 To 17
                Try
                    Select Case i
                        Case 1 : If k > 0 Then Text1.Load(k)
                            txt = Text1(k)
                            txt.Name = "_Text1_" + k.ToString
                        Case 2 : If k > 0 Then Text2.Load(k)
                            txt = Text2(k)
                            txt.Name = "_Text2_" + k.ToString
                        Case 3 : If k > 0 Then Text3.Load(k)
                            txt = Text3(k)
                            txt.Name = "_Text3_" + k.ToString
                        Case 4 : If k > 0 Then Text4.Load(k)
                            txt = Text4(k)
                            txt.Name = "_Text4_" + k.ToString
                        Case 5 : If k > 0 Then Text5.Load(k)
                            txt = Text5(k)
                            txt.Name = "_Text5_" + k.ToString
                    End Select
                    txt.Top = Label3(k).Top
                    txt.Left = lblTipo(CShort(i - 1)).Left
                    If i = 5 And (k >= 4 And k <= 9 Or k = 17) Then
                        txt.Visible = False
                        txt.Enabled = False
                    ElseIf i > 1 And (k < 4 Or k = 5 Or k = 6 Or k = 10 Or (k > 10 And k < 15) Or k = 17) Then
                        txt.Visible = True
                        txt.Enabled = True
                        txt.BackColor = Color.Yellow
                    ElseIf k = 7 And i < 4 And i > 1 Then
                        txt.Visible = True
                        txt.Enabled = True
                        txt.BackColor = Color.Yellow
                    Else
                        txt.Visible = True
                        txt.Enabled = True
                        txt.BackColor = Color.White
                    End If
                    If lblTipo(CShort(i - 1)).Text = "" Then
                        txt.Visible = False
                        txt.Enabled = False
                    End If
                Catch e As Exception
                    strError = ""
                    '  If Not IsNothing(e.InnerException) Then strError = e.InnerException.ToString
                    MsgBox("Form_Load_a" + vbCrLf + e.Message + vbCrLf + strError + vbCrLf + e.StackTrace)
                End Try
Cont1:      Next
        Next
        Loading = True
        myAggFacings()
        AggText()
        nArr = 17
        Loading = False
        ReDim TextArr(nArr)
        For i = 0 To nArr : TextArr(i) = Text1(i) : Next
        Option1(CShort(globFlangia.K3 - 1)).Checked = True
        Label3(17).Visible = False
        Text1(17).Visible = False
        Text2(17).Visible = False
        Text3(17).Visible = False
        Text4(17).Visible = False
        Text5(17).Visible = False
        Dim Sigla As String = ""
        If Not Motore.Autorizzazione("MAT", Sigla) Then
            Command1.Enabled = False
            chkReg.Checked = False
            chkReg.Enabled = False
        End If
        Width = FinestraStretta

    End Sub
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        Select Case Check1.CheckState
            Case CheckState.Checked : Funzioni.DisRut.ApriPri(Inizio.DiscoTem & "SCRATCH", ".DXF", 0, 2, "")
            Case CheckState.Unchecked : Funzioni.DisRut.ChiudiPRI()
        End Select
    End Sub
    Private Function RetrieveRECf() As Boolean
        Dim iRat, iDiam As Short
        Dim Cat As DataView
        iDiam = CShort(cmbDiaN.SelectedIndex + 1)
        iRat = CShort(cmbRating.SelectedIndex + 1)
        If iRat = 0 Then iRat = 1
        If iDiam = 0 Then iDiam = 1
        RetrieveRECf = True
        Try
            With dsFlange
                Cat = New DataView(.Catalogo)
                'If CatalogoR Is Nothing Then
                CatalogoR = New DataView(.Query1)
                CatalogoR1 = New DataView(.Valori)
                CatalogoR2 = New DataView(.Valori)
                CatalogoR3 = New DataView(.Valori)
                CatalogoR4 = New DataView(.Valori)
                CatalogoR5 = New DataView(.Valori)
                'End If
            End With
            CatalogoR.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                                  " AND indDiametro =" & Str(iDiam) & _
                                  " AND indRating=" & Str(iRat)
            Cat.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                                  " AND indDiametro =" & Str(iDiam) & _
                                  " AND indRating=" & Str(iRat) & _
                                  " AND indTipo=1"
            If Cat.Count > 0 Then
                CatalogoR1.RowFilter = "ID=" & CStr(Cat(0)("indValori"))
            Else
                Return False
            End If
            Cat.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                                  " AND indDiametro =" & Str(iDiam) & _
                                  " AND indRating=" & Str(iRat) & _
                                  " AND indTipo=2"
            If Cat.Count > 0 Then CatalogoR2.RowFilter = "ID=" & CStr(Cat(0)("indValori"))
            Cat.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                                  " AND indDiametro =" & Str(iDiam) & _
                                  " AND indRating=" & Str(iRat) & _
                                  " AND indTipo=3"
            If Cat.Count > 0 Then CatalogoR3.RowFilter = "ID=" & CStr(Cat(0)("indValori"))
            Cat.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                                  " AND indDiametro =" & Str(iDiam) & _
                                  " AND indRating=" & Str(iRat) & _
                                  " AND indTipo=4"
            If Cat.Count > 0 Then CatalogoR4.RowFilter = "ID=" & CStr(Cat(0)("indValori"))
            Cat.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                                  " AND indDiametro =" & Str(iDiam) & _
                                  " AND indRating=" & Str(iRat) & _
                                  " AND indTipo=5"
            If Cat.Count > 0 Then CatalogoR5.RowFilter = "ID=" & CStr(Cat(0)("indValori"))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        AggFacing()
    End Function
    Private Sub AggiornaLabels()
        Dim i As Short
        Dim dv As DataView = New DataView(Tipi)
        dv.RowFilter = "Codice=" & Str(globFlangia.TabFlan)
        dv.Sort = "Indice"
        For i = 0 To CShort(dv.Count - 1)
            lblTipo(CShort(CShort(dv(i)("indice")) - 1)).Text = CStr(dv(i)("Tipo"))
        Next
    End Sub
    Private Sub CheckChanges(ByVal eventSender As System.Object)
        If Me.chkReg.Checked Then Command1_Click(eventSender, New System.EventArgs) _
                             Else Command2_Click(eventSender, New System.EventArgs)
    End Sub
    Private Sub cmbDiaN_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDiaN.SelectedIndexChanged
        If cmbDiaN.SelectedIndex = -1 Or Inizializzando Then Exit Sub
        If Not ButtonClick Then Exit Sub
        globFlangia.K1 = CShort(cmbDiaN.SelectedIndex + 1)
        If Not cmbDiaN.Enabled Then Exit Sub
        CheckChanges(eventSender)
        AggiornaMaschere()
        DisegnaVista()
        ButtonClick = False
    End Sub
    Private Sub cmbFacing_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFacing.SelectedIndexChanged
        If cmbFacing.SelectedIndex = -1 Or Inizializzando Then Exit Sub
        If Not ButtonClick Then Exit Sub
        globFlangia.Facing = CShort(cmbFacing.SelectedIndex + 1)
        If Not cmbFacing.Enabled Then Exit Sub
        CheckChanges(eventSender)
        Select Case cmbFacing.SelectedIndex
            Case 0, 1, 2, 3, 4
                Label3(17).Visible = False
                Text1(17).Visible = False
                Text2(17).Visible = False
                Text3(17).Visible = False
                Text4(17).Visible = False
                Text5(17).Visible = False
            Case 11
                Label3(17).Text = "Diametro medio O-ring"
                Label3(17).Visible = True
                Text1(17).Visible = True
                Text2(17).Visible = True
                Text3(17).Visible = True
                Text4(17).Visible = True
                Text5(17).Visible = False
            Case Else
                Label3(17).Visible = True
                Text1(17).Visible = True
                Text2(17).Visible = True
                Text3(17).Visible = True
                Text4(17).Visible = True
                Text5(17).Visible = False
        End Select
        AggFacing()
        DisegnaVista()
        ButtonClick = False
    End Sub
    Public Sub AggFacing()
        Dim iRat, iDiam As Short
        Dim iFac As Short
        iDiam = CShort(cmbDiaN.SelectedIndex + 1) : If iDiam = 0 Then iDiam = 1
        iRat = CShort(cmbRating.SelectedIndex + 1) : If iRat = 0 Then iRat = 1
        iFac = CShort(cmbFacing.SelectedIndex + 1) : If iFac = 0 Then iFac = 1
        If FacValoriR Is Nothing Then FacValoriR = New DataView(FacValori)
        FacValoriR.RowFilter = "Tabella=" & Str(globFlangia.TabFlan) & _
                               " AND indFacing=" & Str(iFac) & _
                               " AND indDiam=" & Str(iDiam) & _
                               " AND indRating=" & Str(iRat)
        If FacValoriR.Count = 0 Then
            Dim d As DataRowView = FacValoriR.AddNew
            d("Tabella") = globFlangia.TabFlan
            d("codDiam") = globFlangia.TabFlan
            d("indFacing") = iFac
            d("indRating") = iRat
            d("indDiam") = iDiam
            d.EndEdit()
        End If
        If iFac = 12 And CShort(FacValori.Rows(0)("Ri")) = 0 Then
            MsgBox("Ring joint non previsto per questa combinazionme DN-Rating.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Information)
            If FacSav - 1 > -1 Then cmbFacing.SelectedIndex = FacSav - 1 Else cmbFacing.SelectedIndex = 0
        End If
    End Sub
    Private Sub cmbRating_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbRating.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        If cmbRating.SelectedIndex = -1 Then Exit Sub
        If Not ButtonClick Then Exit Sub
        globFlangia.K2 = CShort(cmbRating.SelectedIndex + 1)
        If Not cmbRating.Enabled Then Exit Sub
        CheckChanges(eventSender)
        AggiornaMaschere()
        DisegnaVista()
        ButtonClick = False
    End Sub
    Public Function AggiornaMaschere() As Boolean
        If Not RetrieveRECf() Then Return False
        AggText()
        myAggFacings()
        Return True
    End Function
    Private Sub cmbTab_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTab.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        CheckChanges(eventSender)
        globFlangia.TabFlan = CShort(cmbTab.SelectedValue)
        Call AggiornaLabels()
        Call globFlangia.AggTab(Me)
        AggText()
        myAggFacings()
    End Sub
    Private Sub DisegnaVista()
        If Not Disegnando Then Exit Sub
        Dim Index As Short
        For Index = 0 To 4
            If Option1(Index).Checked Then Exit For
        Next
        globFlangia.K3 = CShort(Index + 1)
        Call globFlangia.LeggiTxt()
        globFlangia.K3 = CShort(Index + 1)
        Dim IUNsav As Short
        IUNsav = IUNL
        Dim Bocch As New clsBocch
        Call DisFlangiaSola(Bocch, CShort(cmbFacing.SelectedIndex + 1), 0, True, 0)
        IUNL = IUNsav
        Picture1.Refresh()
    End Sub
    Public Sub Vista()
        Funzioni.DisRut.DoveDisegno = Picture1
        If globFlangia Is Nothing Then globFlangia = New Flangia ' : Cera = False Else Cera = True
        DisegnaVista()
    End Sub
    Private Sub cmdVista_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVista.Click
        If Disegnando Then
            cmdVista.Text = "==>"
            Width = FinestraStretta
            ToolTip1.SetToolTip(cmdVista, HelpStringa(9001))
            Disegnando = False
        Else
            cmdVista.Text = "<=="
            ToolTip1.SetToolTip(cmdVista, HelpStringa(9000))
            Width = FinestraLarga
            Disegnando = True
            Vista()
        End If
    End Sub
    Private Sub AccettaCambi(ByVal bool As Boolean)
        If CatalogoR1 Is Nothing Then Exit Sub
        Dim drv As DataRowView = CatalogoR1(0)
        If bool Then drv.EndEdit() Else drv.CancelEdit()
        drv = CatalogoR2(0)
        If bool Then drv.EndEdit() Else drv.CancelEdit()
        drv = CatalogoR3(0)
        If bool Then drv.EndEdit() Else drv.CancelEdit()
        drv = CatalogoR4(0)
        If bool Then drv.EndEdit() Else drv.CancelEdit()
        drv = CatalogoR5(0)
        If bool Then drv.EndEdit() Else drv.CancelEdit()
        drv = FacValoriR(0)
        If bool Then drv.EndEdit() Else drv.CancelEdit()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim i As Integer, bool As Boolean
        AccettaCambi(True)
        bool = dsFlange.HasChanges(DataRowState.Modified)
        i = AdapterValori.Update(dsFlange, "Valori")
        i = AdapterFacValori.Update(dsFlange, "FacValori")
        DisegnaVista()
    End Sub
    Private Sub AggText()
        Dim i, k As Short
        Dim txt As TextBox = Nothing
        Dim b As Binding
        Dim c As New DataView
        For i = 1 To 5
            For k = 0 To 17
                Select Case i
                    Case 1 : txt = Text1(k)
                        c = CatalogoR1
                    Case 2 : txt = Text2(k)
                        c = CatalogoR2
                    Case 3 : txt = Text3(k)
                        c = CatalogoR3
                    Case 4 : txt = Text4(k)
                        c = CatalogoR4
                    Case 5 : txt = Text5(k)
                        c = CatalogoR5
                End Select
                Try
                    txt.DataBindings.Clear()
                    Select Case k
                        Case 17
                            GoTo Cont
                        Case 12
                            b = New Binding("Text", c, "Tiranti")
                        Case Is < 2
                            b = New Binding("Text", c, dsFlange.Query1.Columns(TitQueryOrig(k + 4)).Caption)
                        Case Is > 3
                            b = New Binding("Text", c, dsFlange.Query1.Columns(TitQueryOrig(k + 4)).Caption)
                        Case Else
                            GoTo Cont
                    End Select
                    AddHandler b.Parse, AddressOf myTextParse
                    AddHandler b.Format, AddressOf myTextFormat
                    txt.DataBindings.Add(b)
                    '                    Dim m As BindingManagerBase = BindingContext(c, dsFlange.Query1.Columns(TitQueryOrig(k + 4)).Caption)
                    '                   m.Position = 1
                    '                  AddHandler m.PositionChanged, AddressOf PosizioneCambiata
                Catch e As Exception
                    MsgBox("AggText" + vbCrLf + e.Message + vbCrLf + e.StackTrace)
                End Try
Cont:       Next
        Next
    End Sub
    ' Private Sub PosizioneCambiata(ByVal s As Object, ByVal e As EventArgs)

    'End Sub
    Private Sub myAggFacings()
        Dim b As Binding
        Try
            Text1(2).DataBindings.Clear()
        Catch
            Exit Sub
        End Try
        Text2(2).DataBindings.Clear()
        Text3(2).DataBindings.Clear()
        Text4(2).DataBindings.Clear()
        Text5(2).DataBindings.Clear()
        Text1(3).DataBindings.Clear()
        Text2(3).DataBindings.Clear()
        Text3(3).DataBindings.Clear()
        Text4(3).DataBindings.Clear()
        Text5(3).DataBindings.Clear()
        Text1(17).DataBindings.Clear()
        Text2(17).DataBindings.Clear()
        Text3(17).DataBindings.Clear()
        Text4(17).DataBindings.Clear()
        Text5(17).DataBindings.Clear()
        Try
            b = New Binding("Text", FacValoriR, "Re")
            AddHandler b.Parse, AddressOf myTextParse
            AddHandler b.Format, AddressOf myTextFormat
            Text1(2).DataBindings.Add(b)
            ' Text2(2).DataBindings.Add(b)
            ' Text3(2).DataBindings.Add(b)
            ' Text4(2).DataBindings.Add(b)
            ' Text5(2).DataBindings.Add(b)
            b = New Binding("Text", FacValoriR, "H")
            AddHandler b.Parse, AddressOf myTextParse
            AddHandler b.Format, AddressOf myTextFormat
            Text1(3).DataBindings.Add(b)
            'Text2(3).DataBindings.Add(b)
            'Text3(3).DataBindings.Add(b)
            'Text4(3).DataBindings.Add(b)
            'Text5(3).DataBindings.Add(b)
            b = New Binding("Text", FacValoriR, "Ri")
            AddHandler b.Parse, AddressOf myTextParse
            AddHandler b.Format, AddressOf myTextFormat
            Text1(17).DataBindings.Add(b)
            'Text2(17).DataBindings.Add(b)
            'Text3(17).DataBindings.Add(b)
            'Text4(17).DataBindings.Add(b)
            'Text5(17).DataBindings.Add(b)
        Catch e As Exception
            MsgBox("myAggFacings" + vbCrLf + e.Message + e.StackTrace)
        End Try
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        AccettaCambi(False)
        myAggFacings()
        AggText()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Dim Index As Short
        If Not globFlangia Is Nothing Then
            For Index = 0 To 4
                If Option1(Index).Checked Then Exit For
            Next
            globFlangia.K3 = CShort(Index + 1)
            Call globFlangia.LeggiTxt()
        End If
        Hide()
    End Sub
    Private Sub myTextFormat(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        Dim cod As String = CType(sender, Binding).Control.Name
        cod = VB.Right$(cod, Len(cod) - 5)
        Dim i As Short = CShort(Val(VB.Left$(cod, 1)))
        cod = VB.Right$(cod, Len(cod) - 2)
        Dim k As Short = CShort(Val(cod))
        If k = 2 Or k = 3 Or k = 17 Then
            cevent.Value = CSng(cevent.Value) * INC
            Exit Sub
        End If
        If cevent.Value.GetType.Equals(GetType(Single)) Then cevent.Value = Format(cevent.Value, "####.#")
        Select Case i
            Case 1
            Case 2
            Case 3
                If Not k = 12 Then
                    If CSng(cevent.Value) = 0 Then Text3(k).Visible = False
                End If
            Case 4
                If k = 5 Then Text4(k).Text = Text4(1).Text
            Case 5
        End Select
    End Sub
    Private Sub myTextParse(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        Dim cod As String = CType(sender, Binding).Control.Name
        cod = VB.Right$(cod, Len(cod) - 5)
        Dim i As Short = CShort(Val(VB.Left$(cod, 1)))
        cod = VB.Right$(cod, Len(cod) - 2)
        Dim k As Short = CShort(Val(cod))
        If k = 2 Or k = 3 Or k = 17 Then
            cevent.Value = CSng(cevent.Value) / INC
        End If
    End Sub
    '  Private Sub SalvaRec1()
    '       Dim kk, iDiam, iRat, k As Short
    '       iDiam = cmbDiaN.SelectedIndex + 1
    '       iRat = cmbRating.SelectedIndex + 1
    '       globFlangia.FacValoriR.Edit()
    '       For kk = 1 To 5
    '           'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tipi().FindFirst. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '           Tipi.Item(globFlangia.TipoTabella).FindFirst("Indice=" & Str(kk))
    '           'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tipi(globFlangia.TipoTabella).NoMatch. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '           If Not Tipi.Item(globFlangia.TipoTabella).NoMatch Then
    '               With globFlangia.CatalogoR
    '                   .FindFirst("indTipo=" & Str(kk))
    '                   If .NoMatch Then
    '                       .AddNew()
    '                       .Fields("codTipo").Value = globFlangia.TipoTabella
    '                       .Fields("indTipo").Value = kk
    '                       .Fields("Tabella").Value = globFlangia.TipoTabella
    '                       .Fields("codDiam").Value = globFlangia.TipoTabella
    '                       .Fields("indDiam").Value = iDiam
    '                       .Fields("codRating").Value = globFlangia.TipoTabella
    '                       .Fields("indRating").Value = iRat
    '                       .Fields("Puntatore").Value = .Fields("Catalogo.iD").Value
    '                       .Fields("indice").Value = kk
    '                   Else
    '                       .Edit()
    '                   End If
    '                   For k = 1 To 18
    '                       If k = 13 Then
    '                           Select Case kk
    '                               Case 1 : .Fields("Tiranti").Value = Text1(k - 1).Text
    '                               Case 2 : .Fields("Tiranti").Value = Text2(k - 1).Text
    '                               Case 3 : .Fields("Tiranti").Value = Text3(k - 1).Text
    '                               Case 4 : .Fields("Tiranti").Value = Text4(k - 1).Text
    '                               Case 5 : .Fields("Tiranti").Value = Text5(k - 1).Text
    '                           End Select
    '                       ElseIf k = 3 Then
    '                           Select Case kk
    '                               Case 1 : globFlangia.FacValoriR.Fields("Re").Value = Val(Text1(k - 1).Text) / INC
    '                               Case 2 : globFlangia.FacValoriR.Fields("Re").Value = Val(Text2(k - 1).Text) / INC
    '                               Case 3 : globFlangia.FacValoriR.Fields("Re").Value = Val(Text3(k - 1).Text) / INC
    '                               Case 4 : globFlangia.FacValoriR.Fields("Re").Value = Val(Text4(k - 1).Text) / INC
    '                               Case 5 : globFlangia.FacValoriR.Fields("Re").Value = Val(Text5(k - 1).Text) / INC
    '                           End Select
    '                       ElseIf k = 4 Then
    '                           Select Case kk
    '                               Case 1 : globFlangia.FacValoriR.Fields("H").Value = Val(Text1(k - 1).Text) / INC
    '                               Case 2 : globFlangia.FacValoriR.Fields("H").Value = Val(Text2(k - 1).Text) / INC
    '                               Case 3 : globFlangia.FacValoriR.Fields("H").Value = Val(Text3(k - 1).Text) / INC
    '                               Case 4 : globFlangia.FacValoriR.Fields("H").Value = Val(Text4(k - 1).Text) / INC
    '                               Case 5 : globFlangia.FacValoriR.Fields("H").Value = Val(Text5(k - 1).Text) / INC
    '                           End Select
    '                       ElseIf k = 18 And Text1(k - 1).Visible Then
    '                           Select Case kk
    '                               Case 1 : globFlangia.FacValoriR.Fields("Ri").Value = Val(Text1(k - 1).Text) / INC
    '                               Case 2 : globFlangia.FacValoriR.Fields("Ri").Value = Val(Text2(k - 1).Text) / INC
    '                               Case 3 : globFlangia.FacValoriR.Fields("Ri").Value = Val(Text3(k - 1).Text) / INC
    '                               Case 4 : globFlangia.FacValoriR.Fields("Ri").Value = Val(Text4(k - 1).Text) / INC
    '                               Case 5 : globFlangia.FacValoriR.Fields("Ri").Value = Val(Text5(k - 1).Text) / INC
    '                           End Select
    '                       ElseIf k < 18 Then
    '                           Select Case kk
    '                               Case 1 : globFlangia.CatalogoR.Fields(k + 3).Value = Val(Text1(k - 1).Text)
    '                               Case 2 : globFlangia.CatalogoR.Fields(k + 3).Value = Val(Text2(k - 1).Text)
    '                               Case 3 : globFlangia.CatalogoR.Fields(k + 3).Value = Val(Text3(k - 1).Text)
    '                               Case 4 : globFlangia.CatalogoR.Fields(k + 3).Value = Val(Text4(k - 1).Text)
    '                               Case 5 : globFlangia.CatalogoR.Fields(k + 3).Value = Val(Text5(k - 1).Text)
    '                           End Select
    '                       End If
    '                   Next
    '                   .Update()
    '               End With
    '           End If
    '       Next kk
    '       globFlangia.FacValoriR.Update()
    '   End Sub
    Private Sub MinASME_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MinASME.Click
        Dim R As Single
        R = (GlobalRoutines.ValVir(Text1(5).Text) - GlobalRoutines.ValVir(Text1(8).Text)) / 2
        R = CSng(0.25 * R)
        If R < 3.0# / 16 * INC Then R = 3.0# / 16 * INC
        R = CShort(R)
        Text1(9).Text = Str(R)
        R = (GlobalRoutines.ValVir(Text2(5).Text) - GlobalRoutines.ValVir(Text2(8).Text)) / 2
        R = CSng(0.25 * R)
        If R < 3.0# / 16 * INC Then R = 3.0# / 16 * INC
        R = CShort(R)
        Text2(9).Text = Str(R)
        R = (GlobalRoutines.ValVir(Text3(5).Text) - GlobalRoutines.ValVir(Text3(8).Text)) / 2
        R = CSng(0.25 * R)
        If R < 3.0# / 16 * INC Then R = 3.0# / 16 * INC
        R = CShort(R)
        Text3(9).Text = Str(R)
        R = (GlobalRoutines.ValVir(Text4(5).Text) - GlobalRoutines.ValVir(Text4(8).Text)) / 2
        R = CSng(0.25 * R)
        If R < 3.0# / 16 * INC Then R = 3.0# / 16 * INC
        R = CShort(R)
        Text4(9).Text = Str(R)
    End Sub
    'UPGRADE_WARNING: L'evento Text1.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        Dim Index As Short = Text1.GetIndex(CType(eventSender, TextBox))
        Select Case Index
            Case 0, 1, 2, 3, 10, 11, 12, 13, 14
                Text2(Index).Text = Text1(Index).Text
                Text3(Index).Text = Text1(Index).Text
                Text4(Index).Text = Text1(Index).Text
                Text5(Index).Text = Text1(Index).Text
            Case 16
                Text2(Index).Text = Text1(Index).Text
                Text3(Index).Text = Text1(Index).Text
                Text4(Index).Text = Text1(Index).Text
            Case 5 'X
                Text2(Index).Text = Text1(Index).Text
                Text3(Index).Text = Text1(Index).Text
                Text4(Index).Text = Text1(Index).Text
                Text4(CShort(Index + 1)).Text = Text1(Index).Text
                Text4(7).Text = GlobalRoutines.myStr(CSng((GlobalRoutines.ValVir(Text4(5).Text) - GlobalRoutines.ValVir(Text4(8).Text)) / 2), 5, 2, 0)
            Case 6 'DiamTr
                Text2(Index).Text = Text1(Index).Text
                Text3(Index).Text = Text1(Index).Text
            Case 7
            Case 8
                Text4(Index).Text = CStr(GlobalRoutines.ConvPoll(cmbDiaN.Text) * INC)
                Text4(7).Text = Str(CShort((GlobalRoutines.ValVir(Text4(5).Text) - GlobalRoutines.ValVir(Text4(8).Text)) / 2))
        End Select
    End Sub
    Private Sub Text1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.Enter
        Dim Index As Short = Text1.GetIndex(CType(eventSender, TextBox))
        'If Focalizza Then txtFocus = Text1(Index)
        '   Call SetInsert(Text1(Index))
    End Sub
    Private Sub Text1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text1.KeyDown
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text1.GetIndex(CType(eventSender, TextBox))
        '   Call TrattaCar(Index, KeyCode, Text1(Index))
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = System.Windows.Forms.Keys.Down
    End Sub

    Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = Text1.GetIndex(CType(eventSender, TextBox))
        ' Stop '  Call TrattaCar(Index, KeyAscii, Text1(Index))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Text1_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text1.KeyUp
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text1.GetIndex(CType(eventSender, TextBox))
        Call TrattaCar(Index, CShort(KeyCode), Text1(Index), TextArr, nArr)
    End Sub
    Private Sub Text2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.Enter
        Dim Index As Short = Text2.GetIndex(CType(eventSender, TextBox))
        ' If Focalizza Then txtFocus = Text2(Index)
        '        Call SetInsert(Text2(Index))
    End Sub
    Private Sub Text2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text2.KeyDown
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text2.GetIndex(CType(eventSender, TextBox))
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = System.Windows.Forms.Keys.Down
    End Sub
    Private Sub Text2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text2.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = Text2.GetIndex(CType(eventSender, TextBox))
        '   Call TrattaCar(Index, KeyAscii, Text2(Index))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Text2_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text2.KeyUp
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text2.GetIndex(CType(eventSender, TextBox))
        Call TrattaCar(Index, KeyCode, Text2(Index), TextArr, nArr)
    End Sub
    Private Sub Text3_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.Enter
        Dim Index As Short = Text3.GetIndex(CType(eventSender, TextBox))
        ' If Focalizza Then txtFocus = Text3(Index)
        ' Call SetInsert(Text3(Index))
    End Sub
    Private Sub Text3_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text3.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text3.GetIndex(CType(eventSender, TextBox))
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = CShort(System.Windows.Forms.Keys.Down)
    End Sub
    Private Sub Text3_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text3.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = Text3.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Text3_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text3.KeyUp
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text3.GetIndex(CType(eventSender, TextBox))
        Call TrattaCar(Index, KeyCode, Text3(Index), TextArr, nArr)
    End Sub
    Private Sub Text4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text4.TextChanged
        If Loading Then Exit Sub
        Dim Index As Short = Text4.GetIndex(CType(eventSender, TextBox))
        If Index = 8 Then
            Text4(7).Text = Str((GlobalRoutines.ValVir(Text4(6).Text) - GlobalRoutines.ValVir(Text4(8).Text)) / 2)
        End If
    End Sub
    Private Sub Text4_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text4.Enter
        Dim Index As Short = Text4.GetIndex(CType(eventSender, TextBox))
        ' If Focalizza Then txtFocus = Text4(Index)
        'Call SetInsert(Text4(Index))
    End Sub
    Private Sub Text4_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text4.KeyDown
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = Text4.GetIndex(CType(eventSender, TextBox))
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = System.Windows.Forms.Keys.Down
    End Sub

    Private Sub Text4_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text4.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
        Dim Index As Short = Text4.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0

        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Text4_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text4.KeyUp
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        Dim Index As Short = Text4.GetIndex(CType(eventSender, TextBox))
        Call TrattaCar(Index, CShort(KeyCode), Text4(Index), TextArr, nArr)
    End Sub
    Private Sub Text5_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text5.Enter
        Dim Index As Short = Text5.GetIndex(CType(eventSender, TextBox))
        ' If Focalizza Then txtFocus = Text5(Index)
        'Call SetInsert(Text5(Index))

    End Sub
    Private Sub Text5_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text5.KeyDown
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        Dim Index As Short = Text5.GetIndex(CType(eventSender, TextBox))
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = System.Windows.Forms.Keys.Down
    End Sub
    Private Sub Text5_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text5.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
        Dim Index As Short = Text5.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Text5_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text5.KeyUp
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        Dim Index As Short = Text5.GetIndex(CType(eventSender, TextBox))
        Call TrattaCar(Index, CShort(KeyCode), Text5(Index), TextArr, nArr)
    End Sub
    Private Sub frmFlange_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        dsFlange.Dispose()
        dvFacings.Dispose()
        dvRatings.Dispose()
        dvDiametri.Dispose()
        Diametri.Dispose()
        Facings.Dispose()
        Ratings.Dispose()
        Tipi.Dispose()
    End Sub
    Private Sub Text1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Text1.Validated
        Dim Index As Short = Text1.GetIndex(CType(sender, TextBox))
        If Text2(Index).BackColor.Equals(Color.Yellow) Then
            BindingContext(CatalogoR2).EndCurrentEdit()
        End If
        If Text3(Index).BackColor.Equals(Color.Yellow) Then
            BindingContext(CatalogoR3).EndCurrentEdit()
        End If
        If Text4(Index).BackColor.Equals(Color.Yellow) Then
            BindingContext(CatalogoR4).EndCurrentEdit()
        End If
        If Text5(Index).BackColor.Equals(Color.Yellow) Then
            BindingContext(CatalogoR5).EndCurrentEdit()
        End If
    End Sub
    Private Sub Option1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Option1.Click
        DisegnaVista()
    End Sub
    Private Sub chkReg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReg.CheckedChanged
        Command1.Visible = Not chkReg.Checked
        Command2.Visible = Not chkReg.Checked
    End Sub
    Private Sub frmFlange_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        globFlangia.AggFlangia(Me)
    End Sub
    Private Sub cmbDiaN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDiaN.Click
        ButtonClick = True
    End Sub
    Private Sub cmbFacing_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFacing.Click
        ButtonClick = True
    End Sub
    Private Sub cmbRating_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRating.Click
        ButtonClick = True
    End Sub
End Class